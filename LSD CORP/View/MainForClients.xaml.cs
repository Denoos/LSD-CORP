using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LSD_CORP.View
{
    /// <summary>
    /// Логика взаимодействия для MainForClients.xaml
    /// </summary>
    public partial class MainForClients : Window, INotifyPropertyChanged
    {
        private List<Furniture> furnitures;
        private Furniture selectedFurniture;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Furniture> Furnitures { get => furnitures; set { furnitures = value; Signal(); } }
        public Furniture SelectedFurniture { get => selectedFurniture; set { selectedFurniture = value; Signal(); } }

        private void Signal([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public MainForClients()
        {
            InitializeComponent();
            GetAll();
            this.DataContext = this;
        }

        private async Task GetAll()
        {
            Furnitures = await DataBase.Instance.GetAllFurnitures();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            new FurnitureAddForm().Show();
            Close();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            new FurnitureAddForm(SelectedFurniture).Show();
            Close();
        }

        private async void DelClick(object sender, RoutedEventArgs e)
        {
            var dialogResult = MessageBox.Show("Вы уверенны?", "It will ban u))", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes || dialogResult == MessageBoxResult.OK)
            {
                await DataBase.Instance.DelFur(SelectedFurniture);
                Furnitures = await DataBase.Instance.GetAllFurnitures();
            }
        }

        private void NewMatClick(object sender, RoutedEventArgs e)
        {
            new MaterialForm().Show();
            Close();
        }
        private void NewClientClick(object sender, RoutedEventArgs e)
        {
            new ClientForm().Show();
            Close();
        }

        private async void DupeClick(object sender, RoutedEventArgs e)
        {
            await DataBase.Instance.DupeFur(SelectedFurniture);
            Furnitures = await DataBase.Instance.GetAllFurnitures();
        }
    }
}