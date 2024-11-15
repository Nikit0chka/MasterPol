using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPol.EntityFramework;
using MasterPol.EntityFramework.Models;
using MasterPol.MVVM.Views;
using MasterPol.Repositories;

namespace MasterPol.MVVM.ViewModels;

public partial class HomeViewModel:ObservableObject
{
    /// <summary>
    /// Коллекция партнеров для вывода в ListView
    /// </summary>
    [ObservableProperty] private ObservableCollection<Partner> _partners = [];

    /// <summary>
    /// Выбранный из списка партнер
    /// </summary>
    [ObservableProperty] private Partner? _selectedPartner;

    /// <summary>
    /// Логика отображения информации о партнере
    /// </summary>
    [RelayCommand]
    private void ShowPartnerInfo()
    {
        // Если нет выбранного партнера
        if (SelectedPartner is null)
            return;

        // Получение объекта приложения
        var app = Application.Current as App;

        // Переход на страницу информации о партнере
        app?.SetCurrentView(new PartnerInfoView(SelectedPartner));
    }

    /// <summary>
    /// Логика отображения информации о партнере
    /// </summary>
    [RelayCommand]
    private static void CreatePartner()
    {
        // Получение объекта приложения
        var app = Application.Current as App;

        // Переход на страницу информации о партнере
        app?.SetCurrentView(new PartnerInfoView());
    }

    /// <summary>
    /// Логика ассинхронной инициализации
    /// </summary>
    public async Task InitializeAsync()
    {
        // Создание объекта репозитория партнеров
        var partnerRepository = new PartnerRepository(new Context());

        // Получение партнеров из БД
        Partners = new(await partnerRepository.GetAllAsync());
    }
}