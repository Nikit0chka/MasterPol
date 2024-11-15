using System.Windows.Controls;
using MasterPol.MVVM.ViewModels;
using MasterPol.MVVM.Views;

namespace MasterPol;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    /// <summary>
    /// Логика смены отображаемого контрола
    /// </summary>
    /// <param name="view"></param>
    public void SetCurrentView(ContentControl view)
    {
        // Получение основного окна
        var mainView = (MainView) MainWindow!;

        // Получение его вьюмодели
        var mainViewModel = (MainViewModel) mainView.DataContext;

        // Смена контрола
        mainViewModel.CurrentView = view;
    }
}