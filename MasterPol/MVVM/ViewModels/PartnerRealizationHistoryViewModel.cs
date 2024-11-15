using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MasterPol.EntityFramework.Models;

namespace MasterPol.MVVM.ViewModels;

public partial class PartnerRealizationHistoryViewModel(Partner partner):ObservableObject
{
    [ObservableProperty] private ObservableCollection<PartnerRealizationHistory> _partnerRealizationHistory = new(partner.PartnerRealizationHistories);
}