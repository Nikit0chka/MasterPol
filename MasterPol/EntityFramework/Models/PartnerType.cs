namespace MasterPol.EntityFramework.Models;

public class PartnerType
{
    public int Id { get; set; }
    public string Name { get; set; }
    virtual public ICollection<Partner> Partners { get; set; } = [];
}