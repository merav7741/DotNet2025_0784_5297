namespace BO;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Categories Category { get; set; }
    public double Price { get; set; }
    public int CountStock { get; set; }

    public Product() { }

    public Product(int id, string name, Categories category, double price, int countStock)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        CountStock = countStock;
    }

    public override string ToString() => this.ToStringProperty();
}
