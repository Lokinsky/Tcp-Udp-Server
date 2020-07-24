using System;
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
using WpfApp1.Controller;
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private static readonly object padlock = new object();
        private static Login instance = null;
        private MainWindow context;
        Login()
        {
            InitializeComponent();
            pBar.Maximum = 3;
        }
        public static Login Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Login();
                    }
                    return instance;
                }
            }
        }
        public void SetContext(MainWindow context)
        {
            this.context = context;
        }
        private void TextBox_TouchEnter(object sender, TouchEventArgs e)
        {
        }
        void Access()
        {
            pBar.Value = 0;
            pBar.Value += 1;
            LoginController lController = new LoginController();
            pBar.Value += 1;
            object usr = lController.TryLogin(loginText.Text,passwordText.Text);
            if(usr.GetType() == typeof(string))
            {
                pBar.Value += 1;
                this.statusLabel.Content = usr.ToString();
            }
            else
            {
                pBar.Value += 1;
                Home home = Home.Instance;
                home.user = (User)usr;
                home.UpdateView();
                context.Content = home;
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Access();
        }

        private void Grid_TouchEnter(object sender, TouchEventArgs e)
        {
            Access();
        }
    }
}
