using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{   ///check if malka succeed connect github
    /// <summary>
    /// מחלקה לניהול הלוגים, כל פונקציה שמבקשת לכתוב ללוג תשתמש בפונקציה WriteToLog שמקבלת את שם הפונקציה, שם הפרויקט וההודעה לכתיבה
    /// </summary>
    public static class LogManager
    {
        public static string check = "malkaConnect";
        private static string Log = "Log";

        public static string GetFolder()
        {
            return Log + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
        }
        public static string GetFile()
        {
            return GetFolder() + "/" + DateTime.Now.Day.ToString() + ".txt";
        }
        /// <summary>
        /// פונקציה לכתיבת הודעה לקובץ הלוג, מקבלת את שם הפונקציה, שם הפרויקט וההודעה לכתיבה
        /// </summary>
        /// <param name="funcName"></param>
        /// <param name="nameProject"></param>
        /// <param name="message"></param>
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
            using (StreamWriter sw = new StreamWriter(file,true))
            {
                sw.WriteLine($"{DateTime.Now}\t{nameProject}.{funcName}:\t{message}");
            }
        }
        /// <summary>
        /// פונקציה למחיקת תיקיות ישנות, התיקיות נשמרות לפי שנה וחודש, אם התיקייה בת יותר מחודשיים היא נמחקת
        /// </summary>
        public static void DeleteOldFolder()
        {//לבדוק האם הפונקציה הזו טובה...
            if (!Directory.Exists(GetFolder()))
                return;
            string[] nameFolders = Directory.GetDirectories(Log);

            foreach (string nameFolder in nameFolders)
            {
                string[] dateFolter = nameFolder.Split('/');
                if (dateFolter.Length < 2)
                    continue;
                int year = (int.Parse(dateFolter[1]));
                int month = (int.Parse(dateFolter[2]));
                if (year == DateTime.Now.Year)
                {
                    if (month + 2 < DateTime.Now.Month)
                    {
                        Directory.Delete(nameFolder, true);
                    }
                }
                else
                {
                    if (DateTime.Now.Month == 1)
                    {
                        if (month < 11)
                        { Directory.Delete(nameFolder, true); }
                    }
                    if (DateTime.Now.Month == 2)
                    {
                        if (month < 10)
                        { Directory.Delete(nameFolder, true); }
                    }
                    else
                        Directory.Delete(nameFolder, true);
                }

            }
        }
    }
}
