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
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window, INotifyPropertyChanged
    {
        private User user;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public User User { get => user; set { user = value; Signal(); } }
        public LoginForm()
        {
            InitializeComponent();
            User = new();
            DataContext = this;
        }
        private async void EnterClick(object sender, RoutedEventArgs e)
        {
            if (await DataBase.Instance.Authorization(User))
            {
                new MainWindow().Show();
                Close();
            }
            else MessageBox.Show("Неверный логин или пароль!");
        }

        private async void RegClick(object sender, RoutedEventArgs e)
        {
            if (await DataBase.Instance.Registraition(User))
            {
                MessageBox.Show("Успешно!");
            }
            else MessageBox.Show("Произошла ошибка!");
        }

        private void ExitClick(object sender, RoutedEventArgs e)
            => Close();
    }
}
