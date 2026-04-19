using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IProduct
    {
        /// <summary>
        /// פונקציה ליצירת אוביקט
        /// </summary>
        /// <param name="item">מקבלת פרטי מוצר</param>
        /// <returns>מחזירה את קוד המוצר שנוצר</returns>
        int Create(BO.Product item);

        /// <summary>
        /// פונקציה שמחזירה מוצר לפי המזהה שקיבלה 
        /// </summary>
        /// <param name="id">מזהה המוצר הרצוי</param>
        /// <returns>מחזירה את המוצר המבוקש</returns>
        BO.Product? Read(int id);

        /// <summary>
        /// פונקציה המחזירה רשימה של כל 
        /// </summary>
        /// <returns>רשימה של כל המוצרים</returns>
        List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null);

        /// <summary>
        /// פונקציה המעדכנת נתוני 
        /// </summary>
        /// <param name="item">מקבלת פרטי מוצר</param>
        void Update(BO.Product item);

        /// <summary>
        /// מוחקת מוצר לפי המזהה שקיבלה
        /// </summary>
        /// <param name="id">מזהה המוצר הרצוי למחיקה</param>
        void Delete(int id);

        BO.Product? Read(Func<BO.Product, bool>? filter);
        /// <summary>
        /// פונקצייה להחזרת כל מוצרים שבתוקף על המדף
        /// </summary>
        /// <param name="productInOrder"></param>
        /// <param name="isPreferedCus"></param>
        void AllSalesInDate(BO.ProductInOrder productInOrder, bool isPreferedCus);
    }
}
