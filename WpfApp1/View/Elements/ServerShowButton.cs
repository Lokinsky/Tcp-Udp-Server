using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.View.Elements
{
    class ServerShowButton : Button
    {
        Home context;
        public ServerShowButton(string name, object ctx)
        {
            this.Width = 92;
            this.Height = 68;
            this.MaxHeight = 102;
            this.MaxWidth = 68;
            this.Content = name;
            context = (Home)ctx;
            this.Click += Button_pressed;
        }
        public void Button_pressed(object sender, RoutedEventArgs e)
        {
            context.FrameContainer.Content = new ServerRoom();
        }

    }
}
