using MasterPol.EntityFramework.Models;

namespace MasterPol.EntityFramework;

/// <summary>
/// Класс подсчета скидки партнеров
/// </summary>
public static class SaleCalculator
{
    /// <summary>
    /// Логика подсчета скидки партнера
    /// </summary>
    /// <param name="partnersRealizationHistories">История реализации партнера</param>
    /// <returns></returns>
    public static double GetPartnerSale(ICollection<PartnerRealizationHistory> partnersRealizationHistories)
    {
        // Скидка
        double sale = 0;

        // Общее количество реализованной продукции партнером
        var totalNumberOfSales = partnersRealizationHistories.Sum(realizationHistory => realizationHistory.CountOfRealizations);

        // Простой свитч
        sale = totalNumberOfSales switch
        {
            < 10000 => 0,
            < 50000 => 5,
            < 300000 => 10,
            > 300000 => 15,
            _ => sale
        };

        // Возврат скидки
        return sale;
    }
}