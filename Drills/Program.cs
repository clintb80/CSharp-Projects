using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Drill46
{
    class Program
    {
        static void Main(string[] args)
        {
            loopforfiles();
        }




        private static void loopforfiles()
        {
            string pathWithFiles = Assembly.GetExecutingAssembly().Location; //creates a string and sets pathwithfile equal to the .EXE file path
            pathWithFiles = Path.GetDirectoryName(pathWithFiles) + "\\pathWithFiles\\"; //re-sets pathwithfiles equal to the DIRECTORY that our EXE is in

            string pathToMoveFilesTo = Assembly.GetExecutingAssembly().Location;
            pathToMoveFilesTo = Path.GetDirectoryName(pathToMoveFilesTo) + "\\pathToMoveFilesTo\\";

            foreach (var file in Directory.GetFiles(pathWithFiles)) //loops through all the files in our folder
            {
                TimeSpan fileage = DateTime.Now - File.GetLastWriteTime(file); //gets the files 'age' since last edit
                string fileName = file.Remove(0, file.LastIndexOf('\\') + 1); //gets the files name from its path

                if (fileage.Days <= 1) //makes sure the file is less than one day old
                {
                    Console.WriteLine("Moving " + file + " to " + pathToMoveFilesTo + fileName); //telling the user we are moving the file
                    File.Move(file, pathToMoveFilesTo + fileName); //moves the file
                }
                else //file is less than a day old!
                {
                    Console.WriteLine("NOT moving " + fileName + " because it is only " + fileage.Hours.ToString() + " Hours and " + fileage.Minutes.ToString() + " minutes old!");
                }

                //Console.ReadLine(); //waits for user to press enter
            }
        }
    }
}
