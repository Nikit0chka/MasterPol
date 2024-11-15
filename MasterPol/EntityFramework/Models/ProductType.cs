namespace MasterPol.EntityFramework.Models;

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Coefficient { get; set; }
    virtual public ICollection<Product> Products { get; set; } = [];
}