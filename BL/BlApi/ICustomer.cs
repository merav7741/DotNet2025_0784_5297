using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ICustomer
    {
        /// <summary>
        /// פונקציה ליצירת אוביקט
        /// </summary>
        /// <param name="item">מקבלת פרטי לקוח</param>
        /// <returns>מחזירה את קוד הלקוח שנוצר</returns>
        int Create(BO.Customer item);

        /// <summary>
        /// פונקציה שמחזירה לקוח לפי המזהה שקיבלה 
        /// </summary>
        /// <param name="id">מזהה הלקוח הרצוי</param>
        /// <returns>מחזירה את הלקוח המבוקש</returns>
        BO.Customer? Read(int id);

        /// <summary>
        /// פונקציה המחזירה רשימה של כל 
        /// </summary>
        /// <returns>רשימה של כל הלקוחות</returns>
        List<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null);

        /// <summary>
        /// פונקציה המעדכנת נתוני 
        /// </summary>
        /// <param name="item">מקבלת פרטי לקוח</param>
        void Update(BO.Customer item);

        /// <summary>
        /// מוחקת לקוח לפי המזהה שקיבלה
        /// </summary>
        /// <param name="id">מזהה הלקוח הרצוי למחיקה</param>
        void Delete(int id);

        BO.Customer? Read(Func<BO.Customer, bool>? filter);
        /// <summary>
        /// בדיקה האם לקוח קיים
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExist(int id);
    }
}
