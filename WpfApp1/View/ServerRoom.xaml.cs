﻿using System;
using System.Collections.Generic;
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

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для ServerRoom.xaml
    /// </summary>
    public partial class ServerRoom : Page
    {
        public ServerRoom()
        {
            InitializeComponent();
            titleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("kke");
        }
    }
}
