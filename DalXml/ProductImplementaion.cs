using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal;

internal class ProductImplementation : IProduct
{
    private const string PRODUCTS_FILE_PATH = "../xml/products.xml";

    public int Create(Product item)
    {
        XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
        int id = Config.ProductNum;
        Product newItem = item with { Id = id };
        productList.Add(new XElement("Product",
            new XElement("Id", newItem.Id),
            new XElement("Name", newItem.Name),
            new XElement("Category", newItem.Category),
            new XElement("Price", newItem.Price),
            new XElement("CountStock", newItem.CountStock)));
        productList.Save(PRODUCTS_FILE_PATH);
        return id;
    }

    public void Delete(int id)
    {
        XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
        XElement? product = productList.Elements("Product").FirstOrDefault(p => (int?)p.Element("Id") == id);
        if (product == null)
            throw new DalNotExistException($"There is no product with the id: {id}");
        product.Remove();
        productList.Save(PRODUCTS_FILE_PATH);
    }

    public Product? Read(int id)
    {
        XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
        XElement? product = productList.Elements("Product").FirstOrDefault(p => (int?)p.Element("Id") == id);
        if (product == null)
            throw new DalNotExistException($"There is no product with the id: {id}");
        return ParseProduct(product);
    }

    public Product? Read(Func<Product, bool> filter)
    {
        return ReadAll(filter).FirstOrDefault();
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
        var products = productList.Elements("Product").Select(ParseProduct).ToList();
        return filter == null ? products : products.Where(filter).ToList();
    }

    public void Update(Product item)
    {
        XElement productList = XElement.Load(PRODUCTS_FILE_PATH);
        XElement? product = productList.Elements("Product").FirstOrDefault(p => (int?)p.Element("Id") == item.Id);
        if (product == null)
            throw new DalNotExistException($"There is no product with the id: {item.Id}");
        product.SetElementValue("Name", item.Name);
        product.SetElementValue("Category", item.Category);
        product.SetElementValue("Price", item.Price);
        product.SetElementValue("CountStock", item.CountStock);
        productList.Save(PRODUCTS_FILE_PATH);
    }

    private static Product ParseProduct(XElement p)
    {
        return new Product(
            (int?)p.Element("Id") ?? 0,
            (string?)p.Element("Name") ?? string.Empty,
            Enum.TryParse<Categories>((string?)p.Element("Category"), out var category) ? category : Categories.Necklace,
            (double?)p.Element("Price") ?? 0,
            (int?)p.Element("CountStock") ?? 0);
    }
}
