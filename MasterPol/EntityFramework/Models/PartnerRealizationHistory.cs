namespace MasterPol.EntityFramework.Models;

public class PartnerRealizationHistory
{
    public int Id { get; set; }
    public int CountOfRealizations { get; set; }
    public DateTime DateOfSale { get; set; }
    public int PartnerId { get; set; }
    virtual public Partner Partner { get; set; }
    public int ProductId { get; set; }
    virtual public Product Product { get; set; }
}