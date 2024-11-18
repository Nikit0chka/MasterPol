using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPol.EntityFramework;
using MasterPol.EntityFramework.Models;
using MasterPol.Repositories;

namespace MasterPol.MVVM.ViewModels;

public partial class MaterialsCalculatorViewModel:ObservableObject
{
    [ObservableProperty] private ObservableCollection<ProductType>? _productTypes;
    [ObservableProperty] private ObservableCollection<MaterialType>? _materialTypes;
    [ObservableProperty] private ProductType? _selectedProductType;
    [ObservableProperty] private MaterialType? _selectedMaterialType;
    [ObservableProperty] private double _firstParameter;
    [ObservableProperty] private double _secondParameter;
    [ObservableProperty] private int _countOfNeedProduction;
    [ObservableProperty] private int _countOfNeedMaterial;

    /// <summary>
    /// Логика ассинхронной инициализации
    /// </summary>
    public async Task InitializeAsync()
    {
        // Созадние репозиториев
        var productTypesRepository = new ProductTypesRepository(new Context());
        var materialTypesRepository = new MaterialTypeRepository(new Context());

        // Установка значений из репозиториев
        ProductTypes = new(await productTypesRepository.GetAllAsync());
        MaterialTypes = new(await materialTypesRepository.GetAllAsync());
        SelectedProductType = ProductTypes?.FirstOrDefault();
        SelectedMaterialType = MaterialTypes?.FirstOrDefault();
    }

    /// <summary>
    /// Логика подсчета необходимого количества материалов
    /// </summary>
    /// <exception cref="NullReferenceException"></exception>
    [RelayCommand]
    private void CalculateNeedMaterials()
    {
        if (SelectedProductType is null)
            throw new NullReferenceException("SelectedProductType is null");

        if (SelectedMaterialType is null)
            throw new NullReferenceException("SelectedProductType is null");

        var countOfNeedMaterials = FirstParameter * SecondParameter * SelectedProductType.Coefficient * CountOfNeedProduction;
        CountOfNeedMaterial = (int) Math.Round(countOfNeedMaterials / (1 - SelectedMaterialType.PercentageOfMarriage), MidpointRounding.AwayFromZero);
    }
}