using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using System.Reflection;
using DO;
using System.Reflection.Metadata.Ecma335;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        /// <summary>
        /// נתיב קובץ ה-XML של המוצרים
        /// </summary>
        const string PRODUCTS_FILE_PATH = "../xml/products.xml";
        /// <summary>
        /// יצירת מוצר חדש ושמירתו בקובץ ה-XML
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Create(Product item)
        {
            XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
            //שגיאה לבדוק למה ?
            int id = DalXml.Config.ProductNum;
            productList.Add(new XElement("Product",
                new XElement("ID", id),
                new XElement("Name", item.Name),
                new XElement("Category", item.Category),
                new XElement("Price", item.Price),
                new XElement("InStock", item.CountStock)));
            productList.Save(PRODUCTS_FILE_PATH);
            return id;
        }
        /// <summary>
        /// מחיקת מוצר מהקובץ ה-XML לפי מזהה המוצר
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DalNotExistException"></exception>
        public void Delete(int id)
        {
            XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
            XElement IsExist = productList.Descendants("Id").FirstOrDefault(Id => (int.Parse)(Id.Value) == id);
            if (IsExist == null)
                throw new DalNotExistException($"There is no product with the id: {id}");
            IsExist.Parent.Remove();
            productList.Save(PRODUCTS_FILE_PATH);
        }
        /// <summary>
        /// קריאת מוצר מהקובץ ה-XML לפי מזהה המוצר
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="DalNotExistException"></exception>
        public Product? Read(int id)
        {
            XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
            XElement IsExist = productList.Descendants("Id").FirstOrDefault(Id => (int.Parse)(Id.Value) == id);
            if (IsExist == null)
                throw new DalNotExistException($"There is no product with the id: {id}");
            else
            {
                XElement product = IsExist.Parent;
                return new Product(int.Parse(IsExist.Element("Id").Value),
                    IsExist.Element("Name") != null ? IsExist.Element("Name").Value : null,
                    IsExist.Element("Category") != null ? (Categories)Enum.Parse(typeof(Categories), IsExist.Element("Category").Value) : 0,
                    IsExist.Element("Price") != null ? double.Parse(IsExist.Element("Price").Value) : 0,
                    IsExist.Element("CountStock") != null ? int.Parse(IsExist.Element("countStock").Value) : 1);

            }
        }
        /// <summary>
        /// קריאת מוצר מהקובץ ה-XML לפי תנאי מסוים
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="DalNotExistException"></exception>
        public Product? Read(Func<Product, bool> filter)
        {
            List<Product> products = ReadAll();
            Product foundProd = products.FirstOrDefault(p => filter(p));
            if (foundProd != null)
                return foundProd;
            else throw new DalNotExistException("Product with requested conditions was not found");
        }
        /// <summary>
        /// קריאת כל המוצרים מהקובץ ה-XML, עם אפשרות לסינון לפי תנאי מסוים
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Product> ReadAll(Func<Product, bool> filter = null)
        {
            XElement productList = XElement.Load(PRODUCTS_FILE_PATH);

            List<Product> products = (from p in productList.Elements()
                    select new Product(int.Parse(p.Element("Id").Value),
                    p.Element("Name") != null ? p.Element("Name").Value : null,
                    p.Element("Category") != null ? (Categories)Enum.Parse(typeof(Categories), p.Element("Category").Value) : 0,
                    p.Element("Price") != null ? double.Parse(p.Element("Price").Value) : 0,
                    p.Element("CountStock") != null ? int.Parse(p.Element("countStock").Value) : 1)).ToList();
            if (filter != null)
                products = products.Where(p => filter(p)).ToList();
            return products;
        }
        /// <summary>
        /// עדכון מוצר בקובץ ה-XML לפי מזהה המוצר
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(Product item)
        {
            XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
            XElement IsExist = productList.Descendants("Id").FirstOrDefault(Id => (int.Parse)(Id.Value) == item.Id);
            if (IsExist == null)
                throw new DalNotExistException($"There is no product with the id: {item.Id}");
            else
            {
                IsExist.Element("Id").SetValue(item.Id);
                IsExist.Element("Name").SetValue(item.Name);
                IsExist.Element("Category").SetValue(item.Category);
                IsExist.Element("Price").SetValue(item.Price);
                IsExist.Element("CountStock").SetValue(item.CountStock);

                productList.Save(PRODUCTS_FILE_PATH);
            }
        }
    }
}
