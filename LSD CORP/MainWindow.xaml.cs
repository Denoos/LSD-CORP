using LSD_CORP.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LSD_CORP;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private List<Furniture> furnitures;
    private Furniture selectedFurniture;

    public event PropertyChangedEventHandler? PropertyChanged;

    public List<Furniture> Furnitures { get => furnitures; set { furnitures = value; Signal(); } }
    public Furniture SelectedFurniture { get => selectedFurniture; set { selectedFurniture = value; Signal(); }}

    private void Signal([CallerMemberName] string? prop = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    public MainWindow()
    {
        InitializeComponent();
        Furnitures = DataBase.Instance.GetAllFurnitures();
        this.DataContext = this;
    }

    private void AddClick(object sender, RoutedEventArgs e)
    {

    }

    private void EditClick(object sender, RoutedEventArgs e)
    {

    }

    private void DelClick(object sender, RoutedEventArgs e)
    {

    }

    private void NewMatClick(object sender, RoutedEventArgs e)
        => new MaterialForm().Show();

    private void NewClientClick(object sender, RoutedEventArgs e)
    {

    }
}