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
using System.Windows.Shapes;
using WpfApp1.View.Elements;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCreateServer.xaml
    /// </summary>
    public partial class WindowCreateServer : Window
    {
        Home context;
        public WindowCreateServer(object context)
        {
            InitializeComponent();
            this.context = (Home)context; 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.serverNameText.Text = "";
        }

        private void btnCreateServer_Click(object sender, RoutedEventArgs e)
        {
            //if(this.serverNameText.Text!=null)

            context.serverList.Items.Add(new ServerShowButton(this.serverNameText.Text, context));
            this.Close();
        }
 
    }
}
