using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPol.EntityFramework;
using MasterPol.EntityFramework.Models;
using MasterPol.Repositories;

namespace MasterPol.MVVM.ViewModels;

public partial class MaterialsCalculatorViewModel:ObservableObject
{
    [ObservableProperty] private ObservableCollection<ProductType> _productTypes;
    [ObservableProperty] private ObservableCollection<MaterialType> _materialTypes;
    [ObservableProperty] private ProductType _selectedProductType;
    [ObservableProperty] private MaterialType _selectedMaterialType;

    [ObservableProperty] private int _countOfNeedProduction;
    [ObservableProperty] private int _countOfNeedMaterial;

    public async Task InitializeAsync()
    {
        var productTypesRepository = new ProductTypesRepository(new Context());
        var materialTypesRepository = new MaterialTypeRepository(new Context());

        ProductTypes = new(await productTypesRepository.GetAllAsync());
        MaterialTypes = new(await materialTypesRepository.GetAllAsync());
    }

    [RelayCommand]
    private void CalculateNeedMaterials() => CountOfNeedMaterial = 1111111111;
}