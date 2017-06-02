using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;


namespace Presentation
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
            UserControlProfile profile = new UserControlProfile();
            profile.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            this.Content = profile;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

    }
}
