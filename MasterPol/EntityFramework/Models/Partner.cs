namespace MasterPol.EntityFramework.Models;

public class Partner
{
    public int Id { get; set; }
    public int PartnerTypeId { get; set; }
    virtual public PartnerType PartnerType { get; set; }
    public string Name { get; set; }
    public string LegalAddress { get; set; }
    public string Inn { get; set; }
    public string OwnerFullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Rating { get; set; }
    public double Sale => SaleCalculator.GetPartnerSale(PartnerRealizationHistories);
    virtual public ICollection<PartnerRealizationHistory> PartnerRealizationHistories { get; set; } = [];
}