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
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private static readonly object padlock = new object();
        private static Home instance = null;
        public User user;
        Home()
        {
            InitializeComponent();
            this.user = new User();
            this.userLabel.Content = user.Name;
            this.roleLabel.Content = user.Role; 
            
        }

        public static Home Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Home();
                    }
                    return instance;
                }
            }
        }
        
        public void UpdateView()
        {
            this.userLabel.Content = user.Name;
            this.roleLabel.Content = user.Role;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            new WindowCreateServer(context:this).ShowDialog();
        }

        private void serverList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void serverList_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
