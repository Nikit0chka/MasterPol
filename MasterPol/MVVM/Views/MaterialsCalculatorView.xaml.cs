using System.Windows;
using MasterPol.MVVM.ViewModels;

namespace MasterPol.MVVM.Views;

public partial class MaterialsCalculatorView
{
    public MaterialsCalculatorView()
    {
        // Подписка на событие загрузки
        Loaded += OnLoaded;

        InitializeComponent();

        DataContext = new MaterialsCalculatorViewModel();
    }

    /// <summary>
    /// Вызов метода ассинхронной инициализации при загрузке
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        var materialsCalculatorViewModel = (MaterialsCalculatorViewModel) DataContext;

        await materialsCalculatorViewModel.InitializeAsync();
    }
}