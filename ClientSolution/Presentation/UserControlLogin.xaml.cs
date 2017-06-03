using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Communication;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
        }


        private async void  Button_Click_Login(object sender, RoutedEventArgs e)
        {
            Reply accept;
            try
            {
                accept = await Client.Login(txbxUsername.Text, txbxPassword.Password);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.StringContext, "Warning");
                }
                else
                {
                    Menu menu = new Menu();
                    menu.btnLogout.Visibility = Visibility.Visible;
                    this.Content = menu;

                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
                Menu menu = new Menu();
                menu.btnLogout.Visibility = Visibility.Visible;
                this.Content = menu;
            }
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
           UserControlRegister register = new UserControlRegister();
           this.Content = register;
        }

    }
}
