using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPol.EntityFramework;
using MasterPol.EntityFramework.Models;
using MasterPol.MVVM.Views;
using MasterPol.Repositories;

namespace MasterPol.MVVM.ViewModels;

public partial class PartnerInfoViewModel():ObservableObject
{
    private Partner? _partner;

    [ObservableProperty] private bool _isEdit;

    [ObservableProperty] private string _name = "";
    [ObservableProperty] private string _ownerFullName = "";
    [ObservableProperty] private string _email = "";
    [ObservableProperty] private string _inn = "";
    [ObservableProperty] private string _phone = "";
    [ObservableProperty] private string _legalAddress = "";
    [ObservableProperty] private int _rating;
    [ObservableProperty] private ObservableCollection<PartnerType>? _partnerTypes;
    [ObservableProperty] private PartnerType? _selectedPartnerType;

    public PartnerInfoViewModel(Partner partner):this()
    {
        Name = partner.Name;
        OwnerFullName = partner.OwnerFullName;
        Email = partner.Email;
        Inn = partner.Inn;
        Phone = partner.Phone;
        LegalAddress = partner.LegalAddress;
        Rating = partner.Rating;

        _partner = partner;
        _isEdit = true;
    }

    /// <summary>
    /// Логика ассинхронной инициализации
    /// </summary>
    public async Task InitializeAsync()
    {
        // Создание репозитория
        var partnerTypeRepository = new PartnerTypeRepository(new Context());

        // Получение типов партнеров
        PartnerTypes = new(await partnerTypeRepository.GetAllAsync());

        // Установка первого типа по умолчанию
        SelectedPartnerType = PartnerTypes.First();

        // Если партнер редактируется - установить значение из бд
        if (IsEdit)
            SelectedPartnerType = PartnerTypes.FirstOrDefault(partnerType => _partner != null && partnerType.Id == _partner.PartnerTypeId);
    }

    /// <summary>
    /// Логика сохранения информации о партнере
    /// </summary>
    [RelayCommand]
    private async Task SavePartnerInfo()
    {
        // Создание экземпляра партнера
        var changedPartner = new Partner();

        // Если редактирование - приравниваем экземпляр
        if (IsEdit)
            changedPartner = _partner;

        // Если не выбран тип партнера - ошибка
        if (SelectedPartnerType is null)
            throw new ArgumentNullException(nameof(_partner));

        // Если созданный экземпляр == null - ошибка
        if (changedPartner is null)
            throw new ArgumentNullException(nameof(_partner));

        // Установка значений
        changedPartner.Name = Name;
        changedPartner.OwnerFullName = OwnerFullName;
        changedPartner.PartnerTypeId = SelectedPartnerType.Id;
        changedPartner.Email = Email;
        changedPartner.Phone = Phone;
        changedPartner.Rating = Rating;
        changedPartner.Inn = Inn;
        changedPartner.LegalAddress = LegalAddress;

        // Создание репозитория
        var partnerRepository = new PartnerRepository(new Context());

        // Если партнер редактировался
        if (IsEdit)
        {
            // Обновление партнера в бд
            await partnerRepository.UpdateAsync(changedPartner);

            // Вывод информационного сообщения
            MessageBox.Show("Партнер обновлен успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Если партнер создается новый
        else
        {
            // Добавление партнера в бд
            await partnerRepository.AddAsync(changedPartner);

            // Вывод информационного сообщения
            MessageBox.Show("Партнер добавлен успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    /// <summary>
    /// Логика удаления партнера
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    [RelayCommand]
    private async Task DeletePartner()
    {
        // Если партнер == null - ошибка
        if (_partner is null)
            throw new ArgumentNullException(nameof(_partner));

        // Вывод сообщения для подтверждения удаления
        var messageBoxResult = MessageBox.Show($"Вы уверены, что хотите удалить партнера '{_partner.Name}'? Нажмите 'Да', чтобы подтвердить, или 'Нет', чтобы отменить.", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

        // Если удаление не подтверждено
        if (messageBoxResult != MessageBoxResult.Yes)
            return;

        // Сооздание репозитория
        var partnerRepository = new PartnerRepository(new Context());

        // Удаление партнера из бд
        await partnerRepository.DeleteAsync(_partner.Id);

        // Вывод информационного сообщения
        MessageBox.Show("Партнер удален успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

        // Получение объекта приложения
        var app = Application.Current as App;

        // Переход на домашнюю страницу
        app?.SetCurrentView(new HomeView());
    }

    [RelayCommand]
    private void ShowPartnerHistory()
    {
        // Если партнер == null - ошибка
        if (_partner is null)
            throw new ArgumentNullException(nameof(_partner));

        // Получение объекта приложения
        var app = Application.Current as App;

        // Переход на домашнюю страницу
        app?.SetCurrentView(new PartnerRealizationHistoryView(_partner));
    }
}