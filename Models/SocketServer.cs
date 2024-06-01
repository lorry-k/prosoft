using EasySave_V3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace EasySave_V3._0.Models
{
    class SocketServer
    {
              
        TcpListener tcpListener;
        Socket socketForClient;
        public static NetworkStream networkStream;
        public static bool status = true;
        public SocketServer()
        {
        }
        public  void InitServer()
        {

            IPAddress ip = IPAddress.Parse("127.0.10.1");//Initializing the IP address of the server

            try
            {
                tcpListener = new TcpListener(ip ,8100);//Creation of a communication protocol at port 8100 
                tcpListener.Start();//Launch the communication
                socketForClient = tcpListener.AcceptSocket();//Socket creation and listening to the tcpListener
                networkStream = new NetworkStream(socketForClient);
                while (status)
                {
                    byte[] data = new byte[1024];
                    int recv = networkStream.Read(data);
                    Thread t = new Thread(() => Send(ViewModel.selected_list));//Sending the selected backup list to the function that will calculate the global progression

                    t.Start();// Start the thread


                    switch (Encoding.UTF8.GetString(data, 0, recv))//If the received message is :
                    {
                        case "play":
                            ViewModel.PlayAll(ViewModel.selected_list);//Launch backups
                            break;
                        case "pause":
                            ViewModel.PauseAll(ViewModel.selected_list);//Pause backups
                            break;
                        case "stop":
                            ViewModel.StopAll(ViewModel.selected_list);//Pause backups
                            break;
                    }

                    if (Encoding.UTF8.GetString(data, 0, recv).Contains("End Connection"))//If the received message is "End Connection" stop the connection
                    {
                        status = false;
                    }
                    
            }
                
                
                networkStream.Close();
                socketForClient.Close();
                tcpListener.Stop();


            }
            catch (Exception)
            {
               
            }

        } 

       
        public static void Send(string e)
        {
            networkStream.Write(Encoding.UTF8.GetBytes(e));//Send the message e
        }
        public static void Send(List<BackUp> e)
        {


            while (status)
            {

                string s = "";
                long globalProgression = 0;

                try
                {
                    foreach (var item in e)//For all element in list e
                    {
                        if (item.progression > 99 || item.currentStatus == "Stop") //if the current backup is stopped or its progression is near 100
                        {
                            globalProgression += 100;// Add 100 to the progression
                        }
                        else
                        {
                            globalProgression += item.progression;//else add the progression of the element at the global progression
                        }
                    }
                    globalProgression = globalProgression / e.Count; ;//average the progress
                    s = globalProgression.ToString() + ";" + ViewModel.curState;
                    networkStream.Write(Encoding.UTF8.GetBytes(s));//send the progression
                }
                catch (Exception)
                {
                                        
                }
            }
        }
    }
}
