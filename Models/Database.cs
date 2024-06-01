using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows;

namespace EasySave_V3._0.Models
{
    static class Database
    {
        // Modify the path of AttachDbFilename if no db founded
        static SqlConnection connexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 23) + @"Database\Database.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        //Connexion to the database
        static public bool Connexion()
        {
            try
            {
                

                connexion.Open();
                return true;
                
            }
            catch (Exception)
            {
               
                return false;
            }
            
        }
        /*-------------------------------------------------------------------------------
         
                            Table : Save
         
         -------------------------------------------------------------------------------
         */
        //Insert of data in the database
       static  public bool Insert(BackUp backupproperties)
        {
            SqlCommand command = new SqlCommand();
            DateTime lastSave = DateTime.Now;
            command.Connection = connexion;
            command.CommandText = "INSERT INTO [dbo].[Save] ( [Name], [Source], [Destination], [Type], [LastSave]  )" +
                                   "VALUES" +
                                    "('" + backupproperties.name + "','" + backupproperties.source + "','" + backupproperties.destination + "','" + backupproperties.type + "','"+ DateTime.MinValue.ToString() +"');";
            
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }

           
        }
        //Select all the data of the database
        static public List<BackUp> SelectAll()
        {
            SqlCommand command = new SqlCommand();
            //BackUp backupproperties = new BackUp();

            command.Connection = connexion;
            command.CommandText = "SELECT * FROM [Save] ";

            command.ExecuteNonQuery();

            SqlDataReader reader = command.ExecuteReader();
            List<BackUp> backUps = new List<BackUp>();

            while (reader.HasRows)
            {

                while (reader.Read())

                {
                    BackUp b = new BackUp();
                    b.name = reader.GetValue(0).ToString();
                    b.source = reader.GetValue(1).ToString();
                    b.destination = reader.GetValue(2).ToString();
                    b.type = reader.GetValue(3).ToString();
                    b.lastSave = Convert.ToDateTime(reader.GetValue(4));
                    backUps.Add(b);
                }

                reader.NextResult();
            }
            reader.Close();
            return backUps;

        }

        //Select only the name that we want in the database
        static public BackUp GetBackupByName(string name)
        {
            
            SqlCommand command = new SqlCommand();
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            //DateTime lastSave = DateTime.Now;
            command.Connection = connexion;

            command.CommandText = "SELECT * FROM [Save]" +
                                  "WHERE Name ='" + name + "';";

            command.ExecuteNonQuery();
            DbDataReader reader = command.ExecuteReader();

            //on boucle sur les données
            BackUp backupproperties = new BackUp();
            while (reader.Read())

            {
                backupproperties.name           = reader.GetValue(0).ToString();
                backupproperties.source         = reader.GetValue(1).ToString();
                backupproperties.destination    = reader.GetValue(2).ToString();
                backupproperties.type           = reader.GetValue(3).ToString();
                backupproperties.lastSave       = Convert.ToDateTime( reader.GetValue(4)) ;
            }
            reader.Close();
            return backupproperties;
        }

        //Update the lastSave when a backup is done 
        static public void UpdateLastSave(BackUp backupproperties)
        {
            
            SqlCommand command = new SqlCommand();
            command.Connection = connexion;
            command.CommandText = "UPDATE [dbo].[Save]" +
                                    "SET [LastSave] = '"+ DateTime.Now.ToString()  +"'"+
                                    "WHERE [name] = '"+ backupproperties.name +"' ;";

            DbDataReader reader = command.ExecuteReader();
            reader.Close();

        }
        /*-------------------------------------------------------------------------------
         
                            Table : Extensions
         
         -------------------------------------------------------------------------------
         */
        static public bool InsertExtension(string extension)
        {
            SqlCommand command  = new SqlCommand();
            command.Connection  = connexion;
            command.CommandText = "INSERT INTO [dbo].[Extensions] ([Extension])" +
                                   "VALUES" +
                                    "('" + extension + "');";

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        //select extension
        static public List<string> GetExtensions()
        {
            List<string> listExtension = new List<string>();
            SqlCommand command = new SqlCommand();

            SqlDataAdapter adapter = new SqlDataAdapter();

            command.Connection = connexion;

            command.CommandText = "SELECT * FROM [Extensions];";
                                  

            command.ExecuteNonQuery();
            DbDataReader reader = command.ExecuteReader();

            //on boucle sur les données
            string s ="";
            while (reader.Read())

            {
               s = reader.GetValue(0).ToString();
                listExtension.Add(s);
            }
            reader.Close();
            return listExtension ;
        }



        /*
        -------------------------------------------------------------------------------

                    Table : Softwares

        -------------------------------------------------------------------------------
        */

        static public bool InsertSoftware(string software)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connexion;
            command.CommandText = "INSERT INTO [dbo].[Softwares] ([Softwares])" +
                                   "VALUES" +
                                    "('" + software + "');";

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        //select extension
        static public List<string> GetSoftwares()
        {
            List<string> listSoftware = new List<string>();
            SqlCommand command = new SqlCommand();

            SqlDataAdapter adapter = new SqlDataAdapter();

            command.Connection = connexion;

            command.CommandText = "SELECT * FROM [Softwares];";


            command.ExecuteNonQuery();
            DbDataReader reader = command.ExecuteReader();

            //on boucle sur les données
            string s = "";
            while (reader.Read())

            {
                s = reader.GetValue(0).ToString();
                listSoftware.Add(s);
            }
            reader.Close();
            return listSoftware;
        }
    }
}
