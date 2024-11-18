using System.Windows;
using MasterPol.MVVM.ViewModels;

namespace MasterPol.MVVM.Views;

public partial class PartnerListView
{
    public PartnerListView()
    {
        InitializeComponent();

        // Установка дата контекста контрола
        DataContext = new PartnerListViewModel();

        // Подписка на событие загрузки контрола
        Loaded += LoadedView;
    }

    /// <summary>
    /// Логика обработки загрузки контрола
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void LoadedView(object sender, RoutedEventArgs e)
    {
        // Получение вью модели из контекста окна
        var homeViewModel = (PartnerListViewModel) DataContext;

        // Вызов метода ассинхронной инициализации
        await homeViewModel.InitializeAsync();

        var alo = 1;
    }
}