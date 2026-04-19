using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal
{

    internal class SaleImplementation : ISale
    {
        const string SALES_FILE_PATH = "../xml/sales.xml";

        public int Create(Sale s)
        {
            int myId = DalXml.Config.SaleNum;
            s = s with { Id = myId };
            List<Sale> salesList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(SALES_FILE_PATH))
                salesList = serializer.Deserialize(sr) as List<Sale>;
            salesList.Add(s);
            using (StreamWriter sw = new StreamWriter(SALES_FILE_PATH))
                serializer.Serialize(sw, salesList);
            return s.Id;
        }

        public void Delete(int id)
        {
            List<Sale> salesList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(SALES_FILE_PATH))
                salesList = serializer.Deserialize(sr) as List<Sale>;
            if (salesList.Exists(sale => sale != null && sale.Id == id))
            {
                salesList.Remove(salesList.Find(sale => sale!.Id == id));
                using (StreamWriter sw = new StreamWriter(SALES_FILE_PATH))
                    serializer.Serialize(sw, salesList);
            }
            else
                throw new DalNotExistException($"Sale with id: {id} was not found");
        }

        public Sale? Read(int id)
        {
            List<Sale> salesList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(SALES_FILE_PATH))
                salesList = serializer.Deserialize(sr) as List<Sale>;
            if (salesList.Exists(sale => sale != null && sale.Id == id))
                return salesList.Find(sale => sale!.Id == id);
            else
                throw new DalNotExistException($"Sale with id: {id} was not found");
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            List<Sale> salesList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(SALES_FILE_PATH))
                salesList = serializer.Deserialize(sr) as List<Sale>;
            return salesList.FirstOrDefault(filter!);
        }

        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            List<Sale> salesList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(SALES_FILE_PATH))
                salesList = serializer.Deserialize(sr) as List<Sale>;
            if (filter != null)
                return salesList!.Where<Sale>(filter).ToList()!;
            return new List<Sale?>(salesList != null ? salesList : new List<Sale?>())!;
        }

        public void Update(Sale sale)
        {
            List<Sale> salesList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
            using (StreamReader sr = new StreamReader(SALES_FILE_PATH))
                salesList = serializer.Deserialize(sr) as List<Sale>;
            if (salesList.Exists(s => s != null && s.Id == sale.Id))
            {
                salesList.Remove(salesList.Find(s => s.Id == sale.Id));
                salesList.Add(sale);
                using (StreamWriter sw = new StreamWriter(SALES_FILE_PATH))
                    serializer.Serialize(sw, salesList);
            }
            else
                throw new DalNotExistException($"Sale with id: {sale.Id} was not found");
        }
    }
}
