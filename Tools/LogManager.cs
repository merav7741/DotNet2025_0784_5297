using System;
using System.IO;

namespace Tools
{
    /// <summary>
    /// מחלקה לניהול הלוגים, כל פונקציה שמבקשת לכתוב ללוג תשתמש בפונקציה WriteToLog שמקבלת את שם הפונקציה, שם הפרויקט וההודעה לכתיבה
    /// </summary>
    public static class LogManager
    {
        public static string Check = "malkaConnect";
        private static string logRoot = "Log";

        public static string GetFolder()
        {
            return Path.Combine(logRoot, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
        }

        public static string GetFile()
        {
            return Path.Combine(GetFolder(), DateTime.Now.Day + ".txt");
        }

        /// <summary>
        /// פונקציה לכתיבת הודעה לקובץ הלוג, מקבלת את שם הפונקציה, שם הפרויקט וההודעה לכתיבה
        /// </summary>
        public static void WriteToLog(string funcName, string nameProject, string message)
        {
            try
            {
                string folder = GetFolder();
                string file = GetFile();

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    sw.WriteLine($"{DateTime.Now}\t{nameProject}.{funcName}:\t{message}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error writing to log: {ex.Message}");
            }
        }

        /// <summary>
        /// פונקציה למחיקת תיקיות ישנות, התיקיות נשמרות לפי שנה וחודש, אם התיקייה בת יותר מחודשיים היא נמחקת
        /// </summary>
        public static void DeleteOldFolder()
        {
            try
            {
                if (!Directory.Exists(logRoot))
                    return;

                foreach (var yearDir in Directory.GetDirectories(logRoot))
                {
                    string yearName = Path.GetFileName(yearDir);
                    if (!int.TryParse(yearName, out int year))
                        continue;

                    foreach (var monthDir in Directory.GetDirectories(yearDir))
                    {
                        string monthName = Path.GetFileName(monthDir);
                        if (!int.TryParse(monthName, out int month))
                            continue;

                        DateTime folderDate = new DateTime(year, month, 1);
                        DateTime now = DateTime.Now;
                        if ((now.Year - folderDate.Year) * 12 + now.Month - folderDate.Month > 2)
                        {
                            Directory.Delete(monthDir, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error deleting old log folders: {ex.Message}");
            }
        }
    }
}
