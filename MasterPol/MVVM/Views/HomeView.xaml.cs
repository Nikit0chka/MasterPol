using System.Windows;
using MasterPol.MVVM.ViewModels;

namespace MasterPol.MVVM.Views;

public partial class HomeView
{
    public HomeView()
    {
        InitializeComponent();

        // Установка дата контекста контрола
        DataContext = new HomeViewModel();

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
        var homeViewModel = (HomeViewModel) DataContext;

        // Вызов метода ассинхронной инициализации
        await homeViewModel.InitializeAsync();
    }
}