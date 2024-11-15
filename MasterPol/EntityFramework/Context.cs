using MasterPol.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.EntityFramework;

sealed public class Context:DbContext
{
    public DbSet<PartnerType> PartnerTypes { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<PartnerRealizationHistory> PartnerRealizationHistories { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public Context() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=NIKTA;Database=MasterPol;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var type1 = new PartnerType { Id = 1, Name = "ЗАО" };
        var type2 = new PartnerType { Id = 2, Name = "ООО" };
        var type3 = new PartnerType { Id = 3, Name = "ПАО" };
        var type4 = new PartnerType { Id = 4, Name = "ОАО" };

        var partner1 = new Partner
                       {
                           Id = 1, Name = "База Строитель", OwnerFullName = "Иванова Александра Ивановна", Email = "aleksandraivanova@ml.ru", Phone = "493 123 45 67", LegalAddress = "652050, Кемеровская область, город Юрга, ул. Лесная, 15",
                           Inn = "2222455179", Rating = 7, PartnerTypeId = type1.Id
                       };

        var partner2 = new Partner
                       {
                           Id = 2, Name = "Паркет 29", OwnerFullName = "Петров Василий Петрович", Email = "vppetrov@vl.ru", Phone = "987 123 56 78", LegalAddress = "164500, Архангельская область, город Северодвинск, ул. Строителей, 18",
                           Inn = "3333888520", Rating = 7, PartnerTypeId = type2.Id
                       };

        var partner3 = new Partner
                       {
                           Id = 3, Name = "Стройсервис", OwnerFullName = "Соловьев Андрей Николаевич", Email = "ansolovev@st.ru", Phone = "812 223 32 00", LegalAddress = "188910, Ленинградская область, город Приморск, ул. Парковая, 21",
                           Inn = "4440391035", Rating = 7, PartnerTypeId = type3.Id
                       };

        var partner4 = new Partner
                       {
                           Id = 4, Name = "Ремонт и отделка", OwnerFullName = "Воробьева Екатерина Валерьевна", Email = "ekaterina.vorobeva@ml.ru", Phone = "444 222 33 11", LegalAddress = "143960, Московская область, город Реутов, ул. Свободы, 51",
                           Inn = "1111520857", Rating = 5, PartnerTypeId = type4.Id
                       };

        var partner5 = new Partner
                       {
                           Id = 5, Name = "МонтажПро", OwnerFullName = "Степанов Степан Сергеевич", Email = "stepanov@stepan.ru", Phone = "912 888 33 33", LegalAddress = "309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122",
                           Inn = "5552431140", Rating = 10, PartnerTypeId = type1.Id
                       };

        var productType1 = new ProductType { Id = 1, Name = "Ламинат", Coefficient = 2.35 };
        var productType2 = new ProductType { Id = 2, Name = "Массивная доска", Coefficient = 5.15 };
        var productType3 = new ProductType { Id = 3, Name = "Паркетная доска", Coefficient = 4.34 };
        var productType4 = new ProductType { Id = 4, Name = "Пробковое покрытие", Coefficient = 1.5 };

        var product1 = new Product { Id = 1, Name = "Паркетная доска Ясень темный однополосная 14 мм", Article = "8758385", MinimalPriceForPartner = 4456.90, ProductTypeId = 3 };
        var product2 = new Product { Id = 2, Name = "Инженерная доска Дуб Французская елка однополосная 12 мм", Article = "8858958", MinimalPriceForPartner = 7330.99, ProductTypeId = 3 };
        var product3 = new Product { Id = 3, Name = "Ламинат Дуб дымчато-белый 33 класс 12 мм", Article = "7750282", MinimalPriceForPartner = 1799.33, ProductTypeId = 1 };
        var product4 = new Product { Id = 4, Name = "Ламинат Дуб серый 32 класс 8 мм с фаской", Article = "7028748", MinimalPriceForPartner = 3890.41, ProductTypeId = 1 };
        var product5 = new Product { Id = 5, Name = "Пробковое напольное клеевое покрытие 32 класс 4 мм", Article = "5012543", MinimalPriceForPartner = 5450.59, ProductTypeId = 4 };

        var realizationHistory1 = new PartnerRealizationHistory { Id = 1, PartnerId = 1, ProductId = 1, CountOfRealizations = 15500, DateOfSale = new(2023, 3, 23) };
        var realizationHistory2 = new PartnerRealizationHistory { Id = 2, PartnerId = 1, ProductId = 3, CountOfRealizations = 12350, DateOfSale = new(2023, 12, 18) };
        var realizationHistory3 = new PartnerRealizationHistory { Id = 3, PartnerId = 1, ProductId = 4, CountOfRealizations = 37400, DateOfSale = new(2024, 6, 7) };

        var realizationHistory4 = new PartnerRealizationHistory { Id = 4, PartnerId = 2, ProductId = 2, CountOfRealizations = 35000, DateOfSale = new(2022, 12, 2) };
        var realizationHistory5 = new PartnerRealizationHistory { Id = 5, PartnerId = 2, ProductId = 5, CountOfRealizations = 1250, DateOfSale = new(2023, 5, 17) };
        var realizationHistory6 = new PartnerRealizationHistory { Id = 6, PartnerId = 2, ProductId = 3, CountOfRealizations = 1000, DateOfSale = new(2024, 6, 7) };
        var realizationHistory7 = new PartnerRealizationHistory { Id = 7, PartnerId = 2, ProductId = 1, CountOfRealizations = 7550, DateOfSale = new(2024, 7, 1) };

        var realizationHistory8 = new PartnerRealizationHistory { Id = 8, PartnerId = 3, ProductId = 1, CountOfRealizations = 7250, DateOfSale = new(2023, 1, 22) };
        var realizationHistory9 = new PartnerRealizationHistory { Id = 9, PartnerId = 3, ProductId = 2, CountOfRealizations = 2500, DateOfSale = new(2024, 7, 5) };

        var realizationHistory10 = new PartnerRealizationHistory { Id = 10, PartnerId = 4, ProductId = 4, CountOfRealizations = 59050, DateOfSale = new(2023, 3, 20) };
        var realizationHistory11 = new PartnerRealizationHistory { Id = 11, PartnerId = 4, ProductId = 3, CountOfRealizations = 37200, DateOfSale = new(2024, 3, 12) };
        var realizationHistory12 = new PartnerRealizationHistory { Id = 12, PartnerId = 4, ProductId = 5, CountOfRealizations = 4500, DateOfSale = new(2024, 5, 14) };

        var realizationHistory13 = new PartnerRealizationHistory { Id = 13, PartnerId = 5, ProductId = 3, CountOfRealizations = 50000, DateOfSale = new(2023, 9, 19) };
        var realizationHistory14 = new PartnerRealizationHistory { Id = 14, PartnerId = 5, ProductId = 4, CountOfRealizations = 670000, DateOfSale = new(2024, 11, 10) };
        var realizationHistory15 = new PartnerRealizationHistory { Id = 15, PartnerId = 5, ProductId = 1, CountOfRealizations = 35000, DateOfSale = new(2024, 4, 15) };
        var realizationHistory16 = new PartnerRealizationHistory { Id = 16, PartnerId = 5, ProductId = 2, CountOfRealizations = 25000, DateOfSale = new(2024, 6, 12) };

        var material1 = new MaterialType { Id = 1, Name = "Тип материала 1", PercentageOfMarriage = 0.10 };
        var material2 = new MaterialType { Id = 2, Name = "Тип материала 2", PercentageOfMarriage = 0.95 };
        var material3 = new MaterialType { Id = 3, Name = "Тип материала 3", PercentageOfMarriage = 0.28 };
        var material4 = new MaterialType { Id = 4, Name = "Тип материала 4", PercentageOfMarriage = 0.55 };
        var material5 = new MaterialType { Id = 5, Name = "Тип материала 5", PercentageOfMarriage = 0.34 };

        modelBuilder.Entity<PartnerType>().HasData(type1, type2, type3, type4);
        modelBuilder.Entity<Partner>().HasData(partner1, partner2, partner3, partner4, partner5);
        modelBuilder.Entity<ProductType>().HasData(productType1, productType2, productType3, productType4);
        modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4, product5);
        modelBuilder.Entity<PartnerRealizationHistory>().HasData(realizationHistory1,
                                                                 realizationHistory2,
                                                                 realizationHistory3,
                                                                 realizationHistory4,
                                                                 realizationHistory5,
                                                                 realizationHistory6,
                                                                 realizationHistory7,
                                                                 realizationHistory8,
                                                                 realizationHistory9,
                                                                 realizationHistory10,
                                                                 realizationHistory11,
                                                                 realizationHistory12,
                                                                 realizationHistory13,
                                                                 realizationHistory14,
                                                                 realizationHistory15,
                                                                 realizationHistory16);

        modelBuilder.Entity<MaterialType>().HasData(material1, material2, material3, material4, material5);
    }
}