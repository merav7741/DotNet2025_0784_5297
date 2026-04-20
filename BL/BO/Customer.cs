namespace BO;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string Phone { get; set; } = string.Empty;

    public Customer() { }

    public Customer(int id, string name, string? address, string phone)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
    }

    public override string ToString() => this.ToStringProperty();
}
