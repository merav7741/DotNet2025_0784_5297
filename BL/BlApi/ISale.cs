using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ISale
    {
        /// <summary>
        /// פונקציה ליצירת אוביקט
        /// </summary>
        /// <param name="item">מקבלת פרטי מבצע</param>
        /// <returns>מחזירה את קוד המבצע שנוצר</returns>
        int Create(BO.Sale item);

        /// <summary>
        /// פונקציה שמחזירה מבצע לפי המזהה שקיבלה 
        /// </summary>
        /// <param name="id">מזהה המבצע הרצוי</param>
        /// <returns>מחזירה את המבצע המבוקש</returns>
        BO.Sale? Read(int id);

        /// <summary>
        /// פונקציה המחזירה רשימה של כל 
        /// </summary>
        /// <returns>רשימה של כל המבצעים</returns>
        List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null);

        /// <summary>
        /// פונקציה המעדכנת נתוני 
        /// </summary>
        /// <param name="item">מקבלת פרטי מבצע</param>
        void Update(BO.Sale item);

        /// <summary>
        /// מוחקת מבצע לפי המזהה שקיבלה
        /// </summary>
        /// <param name="id">מזהה המבצע הרצוי למחיקה</param>
        void Delete(int id);

        BO.Sale? Read(Func<BO.Sale, bool>? filter);

    }
}
