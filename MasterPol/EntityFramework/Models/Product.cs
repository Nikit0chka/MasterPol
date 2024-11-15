namespace MasterPol.EntityFramework.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProductTypeId { get; set; }
    virtual public ProductType ProductType { get; set; }
    public string Article { get; set; }
    public double MinimalPriceForPartner { get; set; }
}