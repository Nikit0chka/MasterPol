using System.Windows.Controls;
using MasterPol.EntityFramework.Models;
using MasterPol.MVVM.ViewModels;

namespace MasterPol.MVVM.Views;

public partial class PartnerRealizationHistoryView
{
    public PartnerRealizationHistoryView(Partner partner)
    {
        InitializeComponent();

        DataContext = new PartnerRealizationHistoryViewModel(partner);
    }
}