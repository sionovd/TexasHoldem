
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
using Communication.Replies;

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
            this.KeyDown += new KeyEventHandler(MainKeyDown);
            txbxUsername.Focus();
        }

        private void MainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txbxUsername.IsFocused)
                {
                    txbxEmail.Focus();
                }

                else if (txbxEmail.IsFocused)
                {
                   txbxPassword.Focus();
                }

                else if (txbxPassword.IsFocused)
                {
                    btnRegister.Focus();
                }


            }

             if (e.Key == Key.Tab)
            {
                if (txbxUsername.IsFocused)
                {
                    txbxEmail.Focus();
                }

                else if (txbxEmail.IsFocused)
                {
                    txbxPassword.Focus();
                }

                else if (txbxPassword.IsFocused)
                {
                    btnRegister.Focus();
                }

                else if (btnRegister.IsFocused)
                {
                    btnBack.Focus();
                }

                else if (btnBack.IsFocused)
                {
                    txbxUsername.Focus();
                }

            }
        }

        private async void Button_Click_Register (object sender, RoutedEventArgs e)
        {
            if (MainWindow.debug)
            {
                Menu menu = new Menu();
                menu.btnLogout.Visibility = Visibility.Visible;
                this.Content = menu;
            }
            else
            {

                Reply accept;
                try
                {
                    accept = await Client.Register(txbxUsername.Text, txbxPassword.Password, txbxEmail.Text);

                    if (!accept.Sucsses)
                    {
                        MessageBox.Show(accept.ErrorMessage, "Warning");
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
                }
            }

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
           UserControlLogin login = new UserControlLogin();
           this.Content = login;
        }

    }
    }

