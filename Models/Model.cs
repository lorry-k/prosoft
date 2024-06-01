using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Threading;

namespace EasySave_V3._0.Models
{
	class Model
	{
		public int threadCounter = 0;
		public string log = "";
		public string ConvertByte(long bytes)
		{
			//Converted according to the value of the bytes in gb to mb or kb.

			string size = "0 byte";
			if (bytes >= 1073741824.0)
				size = String.Format("{0:##.##}", bytes / 1073741824.0) + " GB";
			else if (bytes >= 1048576.0)
				size = String.Format("{0:##.##}", bytes / 1048576.0) + " MB";
			else if (bytes >= 1024.0)
				size = String.Format("{0:##.##}", bytes / 1024.0) + " KB";
			else if (bytes > 0 && bytes < 1024.0)
				size = bytes.ToString() + "bytes";
			return size;
		}

		public bool BackUp(BackUp backupProperties)
		{
			backupProperties.currentStatus = "Play";  //The backup is active
			string original_destination = backupProperties.destination;
			int startTime = Environment.TickCount; //Start the clock
			backupProperties.progression = 0;
			threadCounter++;
			DirectoryInfo source = new DirectoryInfo(backupProperties.source);  //Create couple of DirectoryInfo objects using the current backup properties
			backupProperties.destination = Directory.CreateDirectory(backupProperties.destination + "/" + backupProperties.name + "" + source.Name + "" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")).ToString(); // create a directory named after the source directory & the timestamping
			
			DirectoryInfo target = new DirectoryInfo(backupProperties.destination);

			if (Directory.Exists(backupProperties.source))      //Check if the destination directory exists 
			{


				if (backupProperties.finalStatus = CopyFilesRecursively(source, target, backupProperties))  //check if the backup succeeded
				{
					CryptosoftRecursive(target, target, backupProperties);
					backupProperties.lastSave = DateTime.Now;                       //Update the lastSave Time to now
					backupProperties.duration = Environment.TickCount - startTime;  //Stop the clock
				}
				else
				{
					backupProperties.duration = -1;
				}
				backupProperties.destination = original_destination;
				backupProperties.currentStatus = "Stop";         //Indicate that the backup is over
				threadCounter--;
				return backupProperties.finalStatus;            //Indicate if the backup failed or not
			}
			else
			{
				backupProperties.duration = -1;
				backupProperties.destination = original_destination;
				threadCounter--;
				return backupProperties.finalStatus = false;
			}
		}

		public bool CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, BackUp backupProperties, bool rec = false)
		{
			string name;
			if (!rec)
				CountAndSize(source, target, backupProperties); // Calculate total Size & number of files that will be saved
			try
			{
				foreach (DirectoryInfo dir in source.GetDirectories())
					CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name), backupProperties, true); //Launch recursively the method in order to save files in directory
				foreach (FileInfo file in source.GetFiles())
				{
					if (backupProperties.currentStatus != "Stop") //if the status is pause, it doesn't copy files anymore but keep the backup running.
					{
						while (backupProperties.currentStatus == "Pause") //suspend the backup with an infinite loop.
						{
						}

						if (file.Name.Contains(' '))
							name = file.Name.Replace(' ', '_'); //delete the spaces in the file name that causes errors
						else
							name = file.Name;


						if (backupProperties.type.Equals("Diff", StringComparison.CurrentCultureIgnoreCase)
							&& DateTime.Compare(file.LastWriteTime, backupProperties.lastSave) >= 0) // Check if the BackUp type is Diff & the file currently checked was modified since the last save
						{
							file.CopyTo(Path.Combine(target.FullName, name), true);    //Copy The File
							if (!rec)// Check if the recursive mode is activated
								UpdateProgression(backupProperties, file.Length);   //Update the progression, the number & size of files already saved
						}
						else if (backupProperties.type.Equals("Full", StringComparison.CurrentCultureIgnoreCase))   //Check if the Back Up Type is Full
						{
							file.CopyTo(Path.Combine(target.FullName, name), true);    //Copy the file
							if (!rec) // Check if the recursive mode is activated
							{
								UpdateProgression(backupProperties, file.Length);   //Update the progression, the number & size of files already saved
							}
						}
					}
					else
					{
						return true; //when the back up is stopped it returns true to the BackUp() method
					}
					Thread.Sleep(400);
				}
				return true;
			}
			catch (IOException)
			{
				return false;
			}
		}

		public void CountAndSize(DirectoryInfo source, DirectoryInfo target, BackUp backupProperties, bool rec = false)
		{
			foreach (DirectoryInfo dir in source.GetDirectories())
				CountAndSize(dir, target.CreateSubdirectory(dir.Name), backupProperties, true); //Launch recursively the method in order to save files in directory
			foreach (FileInfo file in source.GetFiles())
			{
				if (backupProperties.type.Equals("Diff", StringComparison.CurrentCultureIgnoreCase) && DateTime.Compare(file.LastWriteTime, backupProperties.lastSave) >= 0) // Check if the BackUp type is Diff & the file currently checked was modified since the last save
				{
					if (!rec)// Check if the recursive mode is activated
					{
						backupProperties.totalFiles++;  //Add 1 to the number of files copied
						backupProperties.totalSizeByte += file.Length;   //Add the current file size to the total size of the backUp
					}
				}
				else if (backupProperties.type.Equals("Full", StringComparison.CurrentCultureIgnoreCase))   //Check if the Back Up Type is Full
				{
					if (!rec)// Check if the recursive mode is activated
					{
						backupProperties.totalFiles++;                                      //Add 1 to the number of files copied
						backupProperties.totalSizeByte += file.Length;                      //Add the current file size to the total size of the backUp
					}

				}

				backupProperties.totalSize = ConvertByte(backupProperties.totalSizeByte);
			}
		}

		public void UpdateProgression(BackUp backupProperties, long fileSize)
		{
			backupProperties.curFiles++;    //Add 1 to the number of files copied
			backupProperties.curSizeByte += fileSize;    //Add the current file size to the total size of the backUp
			backupProperties.progression = backupProperties.curSizeByte * 100 / backupProperties.totalSizeByte;
		}

		public void CreateFile()
		{
			string path = @"..\..\..\File\log.json";

			if (!File.Exists(path))
			{
				using (StreamWriter sw = File.CreateText(path))
				{
					sw.Write(
								"[\n{}\n]"
							);
				}
			}
		}

		public void AddLog(BackUp backupProperties)
		{
			DateTime date = DateTime.Now;
			log += 
			",{ \n" +
				"\"Date\"		:" + "\"" + date + "\",\n" +
				"\"Name\"		:" + "\"" + backupProperties.name + "\",\n" +
				"\"Source\"		:" + "\"" + backupProperties.source + "\",\n" +
				"\"Dest\"		:" + "\"" + backupProperties.destination + "\",\n" +
				"\"Size\"		:" + +backupProperties.totalSizeByte + ",\n" +
				"\"Time\"		:" + backupProperties.duration + ",\n" +
				"\"TimeEncrypt\":" + backupProperties.durationEncrypt + "\n" +
			"}";
		}

		public void WriteLog()
        {
			string path = @"..\..\..\File\log.json";
			DateTime date = DateTime.Now;

			//Last character deleting
			using (FileStream fs = new FileStream(path, FileMode.Open))
			{
				fs.Position = fs.Seek(-1, SeekOrigin.End);
				if (fs.ReadByte() == ']')
					fs.SetLength(fs.Length - 1);
			}

			log += "]";

			 
			//Log file adding content
			using (StreamWriter sw = File.AppendText(path))
			{
				sw.Write(log);
			}
			log = "";
		}

		public bool IsInArray(string name, BackUp[] array)
		{
			foreach (BackUp curBackUp in array)
			{

				if ((curBackUp != null) && (name.Equals(curBackUp.name, StringComparison.CurrentCultureIgnoreCase))) //is checking for each element in an array if the parameter name isn't equals
					return true;
			}

			return false;
		}
		public bool IsInArray(string name, List<BackUp> listBackUp)
		{
			foreach (BackUp curBackUp in listBackUp)
			{

				if (name.Equals(curBackUp.name, StringComparison.CurrentCultureIgnoreCase)) //is checking for each element in the list if the parameter name isn't equals
					return true;
			}

			return false;
		}
		public bool IsInArray(string name, List<string> list)
		{
			foreach (string element in list)
			{

				if (name.Equals(element, StringComparison.CurrentCultureIgnoreCase)) //is checking for each element in the list if the parameter name isn't equals
					return true;
			}

			return false;
		}

		public void StartCryptosoft(string filePath)
		{

			using (Process process = new Process())
			{
				try
				{
					process.StartInfo.FileName = @"..\..\..\..\CryptoSoft\bin\Debug\netcoreapp3.0\CryptoSoft.exe";
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.Arguments = filePath + " " + filePath.Substring(0, filePath.Length - Path.GetExtension(filePath).Length) + "crypte" + Path.GetExtension(filePath);
					process.Start();
					process.WaitForExit();
				}
                catch (ThreadInterruptedException)
                {

                }

			}
		}


		//Crypt 
		public bool CryptosoftRecursive(DirectoryInfo source, DirectoryInfo target, BackUp backupProperties)
		{

			try
			{
				Stopwatch chrono = new Stopwatch();

				foreach (DirectoryInfo dir in source.GetDirectories())
					CryptosoftRecursive(dir, target.CreateSubdirectory(dir.Name), backupProperties); //Launch recursively the method in order to encrypt files in directory
				foreach (FileInfo file in source.GetFiles())
				{
					if (IsInArray(file.Extension, Database.GetExtensions()))    //Check if the current file's extension is indexed as an extension to encrypt 
					{
						chrono.Start();	//Start the stopwatch
						StartCryptosoft(file.FullName); //Launch the encrypting function
						chrono.Stop(); //Stop 
						backupProperties.durationEncrypt += chrono.ElapsedMilliseconds; //Store the encryption duration in the Backup Object
						chrono.Reset(); //Reset the stopwatch
						
					}
				}
				return true;

			}

			catch (IOException)
			{
				return false;
			}
		}

		public bool ProcessIsRunning()
		{
			foreach (var process in Database.GetSoftwares())
			{
				if (Process.GetProcessesByName(process).Length > 0) //search for a process using the database
					return true;
			}
			return false;
		}

	}
}
