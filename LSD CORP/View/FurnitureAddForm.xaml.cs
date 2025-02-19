﻿using System;
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
    /// Логика взаимодействия для FurnitureAddForm.xaml
    /// </summary>
    public partial class FurnitureAddForm : Window, INotifyPropertyChanged
    {
        private Furniture furniture;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public Furniture Furniture { get => furniture; set { furniture = value; Signal(); } }
        public FurnitureAddForm()
        {
            InitializeComponent();
            Furniture = new();
            DataContext = this;
        }

        private async void SaveClick(object sender, RoutedEventArgs e)
        {
            if (await DataBase.Instance.AddFur(Furniture))
                BackClick(sender, e);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
