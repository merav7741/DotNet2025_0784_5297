using BlApi;
using BO;
namespace BlImplementation;

internal class SaleImplementation : ISale
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Sale item) => _dal.Sale.Create(item.ConvertBoSaleToDo());

    public BO.Sale? Read(int id)
    {
        var sale = _dal.Sale.Read(id);
        return sale?.ConvertDoSaleToBo();
    }

    public BO.Sale? Read(Func<BO.Sale, bool>? filter)
    {
        if (filter == null) return null;
        return _dal.Sale.ReadAll().Select(s => s.ConvertDoSaleToBo()).FirstOrDefault(filter);
    }

    public List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
    {
        var sales = _dal.Sale.ReadAll().Select(s => s.ConvertDoSaleToBo());
        return filter == null ? sales.ToList() : sales.Where(filter).ToList();
    }

    public void Update(BO.Sale item) => _dal.Sale.Update(item.ConvertBoSaleToDo());

    public void Delete(int id) => _dal.Sale.Delete(id);
}
