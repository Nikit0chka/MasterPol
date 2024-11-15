using System.Windows;
using MasterPol.EntityFramework.Models;
using MasterPol.MVVM.ViewModels;

namespace MasterPol.MVVM.Views;

public partial class PartnerInfoView
{
    /// <summary>
    /// Конструктор для создания новго партнера
    /// </summary>
    public PartnerInfoView()
    {
        // Подписка на загрузку контрола
        Loaded += OnLoaded;

        InitializeComponent();

        // Установка контекста контрола
        DataContext = new PartnerInfoViewModel();
    }

    /// <summary>
    /// Конструктор для редактирования партнера
    /// </summary>
    /// <param name="partner"></param>
    public PartnerInfoView(Partner partner)
    {
        // Подписка на загрузку контрола
        Loaded += OnLoaded;

        InitializeComponent();

        // Установка контекста контрола
        DataContext = new PartnerInfoViewModel(partner);
    }

    /// <summary>
    /// Логика вызова ассинхронной инициализации по загрузке view
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        var partnerInfoViewModel = (PartnerInfoViewModel) DataContext;

        await partnerInfoViewModel.InitializeAsync();
    }
}