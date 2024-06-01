using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using EasySave_V3._0.ViewModels;
using EasySave_V3._0.Models;

namespace EasySave_V3._0.Views
{
    static class Messages
    {

        static public void ErrorUnknownInput()
        {
            if (ViewModel.language == "EN")
            {
                MessageBox.Show("ERROR : Unknown Input");
            }
            else if (ViewModel.language == "FR")
            {
                MessageBox.Show("ERREUR : Entrée Inconnue");
            }
        }

        static public void ErrorTryAgain()
        {
            if (ViewModel.language == "EN")
            {
                MessageBox.Show("ERROR : Try Again");
            }
            else if (ViewModel.language == "FR")
            {
                MessageBox.Show("ERREUR : Réessayez");
            }
        }

        static public void ErrorAlreadySaved()
        {
            if (ViewModel.language == "EN")
            {
                MessageBox.Show("ERROR : This name is already used");
            }
            else if (ViewModel.language == "FR")
            {
                MessageBox.Show("ERREUR : Ce nom est déjà utilisé");
            }
        }

        static public void ErrorAlreadyIn(string name)
        {
            if (ViewModel.language == "EN")
                MessageBox.Show("ERROR : " + name + " is already inside the list");
            else if (ViewModel.language == "FR")
                MessageBox.Show("ERREUR : " + name + " est déjà dans la liste");
        }

        static public string ErrorBackup(BackUp backupProperties)
        {
            if (ViewModel.language == "EN")
                return "ERROR : " + backupProperties.name + " Failed : Check Arguments & Try Again \n";
            else if (ViewModel.language == "FR")
               return "ERREUR : " + backupProperties.name + " a échoué : Vérifiez les arguments et réessayez \n";

            return "";
        }

        static public void ErrorProcessIsRunning()
        {
            if (ViewModel.language == "EN")
                MessageBox.Show("ERROR : An ERP software is running, please close it & try again");
            else if (ViewModel.language == "FR")
                MessageBox.Show("ERREUR : Un logiciel PGI est en cours d'execution, veuillez le fermer et réessayez");

        }

        static public void ErrorAlreadyRunning()
        {
            if (ViewModel.language == "EN")
            {
                MessageBox.Show("ERROR : The Application is already running");
            }
            else if (ViewModel.language == "FR")
            {
                MessageBox.Show("ERREUR : L'application est déjà en cours");
            }
        }



        /**************************SUCCESS*********************************/

        static public string SuccessBackUp(BackUp backupProperties)
        {
            if (ViewModel.language == "EN")
                return "Backup " + backupProperties.name + " succeeded : " + backupProperties.duration + "ms, size : " + ViewModel.model.ConvertByte(backupProperties.curSizeByte) + " Files : " + backupProperties.curFiles +" \n";
            else if (ViewModel.language == "FR")
                return "Sauvegarde " + backupProperties.name + " a réussi : " + backupProperties.duration + "ms, taille : " + ViewModel.model.ConvertByte(backupProperties.curSizeByte) + " Nombre de Fichiers : " + backupProperties.curFiles + "\n";
            
            return "";
        }


    }
}
