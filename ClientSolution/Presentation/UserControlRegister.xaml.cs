
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
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
    /// Interaction logic for UserControlRegister.xaml
    /// </summary>
    public partial class UserControlRegister : UserControl
    {
        public UserControlRegister()
        {
            InitializeComponent();
        }

        private async void Button_Click_Register (object sender, RoutedEventArgs e)
        {
            Reply accept;

            try
            {
                accept = await Client.Register(txbxUsername.Text, txbxPassword.Password, txbxEmail.Text);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.StringContext, "Warning");
                }
                else
                {
                    User.GetUser().SetUserName(txbxUsername.Text);
                    User.GetUser().SetPassword(txbxPassword.Password);
                    User.GetUser().SetEmail(txbxEmail.Text);
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

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           UserControlLogin login = new UserControlLogin();
           this.Content = login;
        }

    }
    }

