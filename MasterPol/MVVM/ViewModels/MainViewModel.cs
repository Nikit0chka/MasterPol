using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPol.MVVM.Views;

namespace MasterPol.MVVM.ViewModels;

public partial class MainViewModel:ObservableObject
{
    /// <summary>
    /// Контрол для отображения во фрейме
    /// </summary>
    [ObservableProperty] private ContentControl _currentView = new HomeView();

    /// <summary>
    /// Логика отображения домашней страницы
    /// </summary>
    [RelayCommand]
    private void ShowHomeView() => CurrentView = new PartnerListView();

    /// <summary>
    /// Логика отображения страницы подсчета материалов
    /// </summary>
    [RelayCommand]
    private void ShowMaterialsCalculatorView() => CurrentView = new MaterialsCalculatorView();
}