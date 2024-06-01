using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySave_V3._0.Views;
using EasySave_V3._0.Models;
using System.Threading;
using System.Diagnostics;

namespace EasySave_V3._0.ViewModels
{
    static class ViewModel
    {
        static public string language = "EN";
        static public Model model = new Model();
        static public Thread backupThread;
        static public List<BackUp> selected_list;
        static public string curState;
        static public bool once = false;


        static public void AppStart()
        {
            monoInstance();
            model.CreateFile();
            if (!once) //open a list of instructions that must be ran only once, it checks if it has been ran already once
            {
                SocketServer serv = new SocketServer(); 
                Thread threadsocket = new Thread(serv.InitServer);
                threadsocket.Start();
                once = true;

            }
        }

        /**************************************************************/


        static public Page PageSelector(string selectedPage) //Return the requested page following the application current language
        {
            if (language == "EN") //check the current language
            {
                switch (selectedPage) //check the requested page
                {
                    case "Create":
                        Create create_page = new Create();
                        return create_page; //return the requested page in the language
                        break;

                    case "Settings":
                        Settings settings_page = new Settings();
                        return settings_page;
                        break;

                    case "Launch":
                        Launch launch_page = new Launch();
                        return launch_page;
                        break;

                    case "Index":
                        MainView mainView = new MainView();
                        return mainView;
                        break;
                }

            }
            else if (language == "FR")
            {
                switch (selectedPage)
                {
                    case "Create":
                        CreateFR create_pageFR = new CreateFR();
                        return create_pageFR;
                        break;

                    case "Settings":
                        SettingsFR settings_page = new SettingsFR();
                        return settings_page;
                        break;

                    case "Launch":
                        LaunchFR launch_page = new LaunchFR();
                        return launch_page;
                        break;

                    case "Index":
                        MainViewFR mainViewFR = new MainViewFR();
                        return mainViewFR;
                        break;
                }
            }
            MainView mainView_page = new MainView();
            return mainView_page;
        }

        static public bool BackUpCreator(string name, string source, string destination, string type)
        {
            BackUp backupProperties = new BackUp(name, source, destination, type);
            if ((type == "Full") || (type == "Diff"))
            {
                if (!model.IsInArray(backupProperties.name, Database.SelectAll())) //Check if the entered name isn't already used by an existing backUp
                {
                    if (Database.Insert(backupProperties))
                    {
                        return true;
                    }
                    else
                    {
                        Messages.ErrorTryAgain();
                    }
                }
                else
                {
                    Messages.ErrorAlreadySaved();
                }
            }
            else
            {
                Messages.ErrorUnknownInput();
            }

            return false;
        }

        static public bool BackUpLauncher(List<BackUp> list) //Launch ALL the backup simultaneously
        {
            Thread ProcessSurveillance = new Thread(() => { //check if any ERP software is running
                bool once = false;
                while (curState != "Stop")       //While the BackUp is running or is suspended
                {
                    if (model.ProcessIsRunning())   //Check if any ERP is running
                    {
                        curState = "Pause"; //Pause the running backups session
                        foreach (BackUp curBackUp in list)
                        {
                            curBackUp.currentStatus = "Pause"; //Pause each of the running back ups
                            
                            if (!once)
                            {
                                Messages.ErrorProcessIsRunning(); //Display the error only once as it is a while loop
                                once = true;
                            }
                        }
                    }
                }
            });

            selected_list = list;   //store the back up list session in the view model to make it reachable by all the program
            curState = "Play";
            ProcessSurveillance.Start();
            foreach (BackUp backUp in list) //reads the list of backup
            {

                backupThread = new Thread(() => BackUpLaunch(backUp));
                backupThread.Start();

            }
            backupThread.Join(); //wait for all the backups to be finished
            curState = "Stop";
            model.WriteLog();
            return true;
        }


        static public void BackUpLaunch(BackUp backupProperties) //Launch A SINGLE back up.
        {
            string Info = "";
            if (!model.BackUp(backupProperties))
            {
                Info += Messages.ErrorBackup(backupProperties);
            }
            else
            {
                Database.UpdateLastSave(backupProperties);  //set the current date as the last save in the database
                model.AddLog(backupProperties);
                Info += Messages.SuccessBackUp(backupProperties);
            }
            MessageBox.Show(Info);
            BackUpCleaner(backupProperties);
        }

        static public void BackUpCleaner(BackUp backupProperties) //Clean the back up object of the temporary data.
        {
            backupProperties.curFiles = 0;
            backupProperties.curSizeByte = 0;
            backupProperties.progression = 0;
            backupProperties.totalSizeByte = 0;
            backupProperties.duration = 0;
            backupProperties.durationEncrypt = 0;
            backupProperties.totalFiles = 0;
        }

        static public bool AddExtension(string extension)
        {
            if (!model.IsInArray(extension, Database.GetExtensions())) //Check if the extension isn't already in the database
            {
                if (!Database.InsertExtension(extension))
                {
                    Messages.ErrorTryAgain();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Messages.ErrorAlreadySaved();
            }

            return false;
        }

        static public bool AddSoftware(string software)
        {
            if (!model.IsInArray(software, Database.GetSoftwares())) //Check if the ERP software isn't already in the database
            {
                if (!Database.InsertSoftware(software))
                {
                    Messages.ErrorTryAgain();
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Messages.ErrorAlreadySaved();
            }

            return false;
        }

        static public List<BackUp> AddToList(string name, List<BackUp> selectedList)
        {

            if (!model.IsInArray(name, Database.SelectAll()))   //check if the wanted backup exists
            {
                Messages.ErrorUnknownInput();
            }
            else
            {
                if (!model.IsInArray(name, selectedList))   //check if the backup isn't already in the list
                {
                    BackUp backUpAdded = Database.GetBackupByName(name);
                    selectedList.Add(backUpAdded);
                }
                else
                {
                    Messages.ErrorAlreadyIn(name);
                }
            }
            return selectedList;
        }

        static public void monoInstance() //Check if the app isn't already running
        {
            Process Proc_Running = Process.GetCurrentProcess(); 
            Process[] ProcArray = Process.GetProcesses();
            foreach (Process Processus in ProcArray)
            {
                if (Proc_Running.Id != Processus.Id) //Check for every process but this one
                {
                    if (Proc_Running.ProcessName == Processus.ProcessName) //Check if one process has a similar name
                    {
                        Messages.ErrorAlreadyRunning();
                        Proc_Running.Close();   //Close the current process
                    }
                }
            }
        }

        /********************************CONTROLS************************************/

        static public void PauseAll(List<BackUp> selectedList)
        {
            if (selectedList.Count > 0)
            {
                foreach (BackUp curbackUp in selectedList)
                {
                    curbackUp.currentStatus = "Pause";
                }

                curState = "Pause";
            }

        }

        static public void PlayAll(List<BackUp> selectedList)
        {
            if (selectedList.Count > 0)
            {
                foreach (BackUp curbackUp in selectedList)
                {
                    curbackUp.currentStatus = "Play";
                }

                curState = "Play";
            }
        }

        static public void StopAll(List<BackUp> selectedList)
        {
            if (selectedList.Count > 0)
            {
                foreach (BackUp curbackUp in selectedList)
                {
                    curbackUp.currentStatus = "Stop";
                }

                curState = "Stop";
            }
        }
        static public void Pause(BackUp backupProperties)
        {
            backupProperties.currentStatus = "Pause";
        }

        static public void Play(BackUp backupProperties)
        {
            backupProperties.currentStatus = "Play";
        }

        static public void Stop(BackUp backupProperties)
        {
            backupProperties.currentStatus = "Stop";
        }

    }


}
