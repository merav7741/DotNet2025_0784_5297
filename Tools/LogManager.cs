using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private static string Log = "Log";

        public static string GetFolder()
        {
            return Log + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
        }
        public static string GetFile()
        {
            return GetFolder() + "/" + DateTime.Now.Day.ToString() + ".txt";
        }
        public static void WriteToLog(string funcName, string nameProject, string message)
        {
            string folder = GetFolder();
            string file = GetFile();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine($"{DateTime.Now}\t{nameProject}.{funcName}:\t{message}");
            }
        }
        public static void DeleteOldFolder()
        {
            if (!Directory.Exists(GetFolder()))
                return;
            string[] nameFolders = Directory.GetDirectories(Log);
           
            foreach (string nameFolder in nameFolders)
            {
                string[] dateFolter=nameFolder.Split('/');
                if (dateFolter.Length > 2)
                    continue;
                int year = (int.Parse(dateFolter[1]));
                int month = (int.Parse(dateFolter[2]));
                if (year == DateTime.Now.Year)
                {
                    if (month+2 < DateTime.Now.Month)
                    {                    
                        Directory.Delete(nameFolder, true);
                    }
                }
                else
                    Directory.Delete(nameFolder, true);

            }

        }
    }
}
