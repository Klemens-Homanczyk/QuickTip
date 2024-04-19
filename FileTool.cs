using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file
{
    internal class FileTool
    {

        #region dir and exe
            //list files on disk into collection
            internal static List<string> GetListOfFullPathFiles(string directory)
            {
                return Directory.EnumerateFiles(directory).ToList<string>();
                //filered list of files
                //return Directory.EnumerateFiles(directory,"*.log").ToList<string>();
            }

            //list files on disk into collection
            //include sub directories
            internal static List<string> GetListOfFullPathFilesFromFullTree(string directory)
            {
                return Directory.EnumerateFiles(directory,"*",SearchOption.AllDirectories).ToList<string>();
            }

            //exe location dir
            internal static string GetExeLocationDirectory()
            {
                return Environment.CurrentDirectory;
            }

            //exe full path
            internal static string? GetExeFullPath()
            {
                return Environment.ProcessPath;
            }
        #endregion

        #region file


        //read text from file
        internal static string GetTextFromFile(string filePath)
        {
            string? text = null;

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }

        //read lines from file
        internal static List<string> GetLinesTextFromFile(string filePath)
        {
            string? text = null;
            List<string> result = new List<string>();
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    text = streamReader.ReadLine();
                    result.Add(text);
                }
            }

            return result;
        }
		
		//write line into file
        internal static void WriteLineIntoFile(string line, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath,true))
            {
                writer.WriteLine(line);
            }
        }


        #endregion


    }
}
