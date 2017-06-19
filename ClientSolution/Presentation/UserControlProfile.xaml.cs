using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;
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
using UserInfo = Communication.UserInfo;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlProfile.xaml
    /// </summary>
    public partial class UserControlProfile : UserControl
    {
        private UserDetails userDetails; 
        public UserControlProfile(UserDetails userDetails)
        {
            InitializeComponent();
            this.userDetails = userDetails;
            LabelUsername.Content = UserInfo.GetUser().GetUsername();
            txbxPassword.Text = UserInfo.GetUser().GetPassword();
            txbxMail.Text = userDetails.Email;
            txbxMoney.Text = userDetails.MoneyBalance.ToString();
        }

        


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imageAvatar.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        private void btnEditMail_Click(object sender, RoutedEventArgs e)
        {
            btnChangePassword.IsEnabled = false;
            btnEditMail.Content = "Save Email";
            txbxMail.IsEnabled = true;
            btnBack.IsEnabled = false;
            btnEditMail.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(btnEditMail_Click));
            btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnSaveMail_Click));
        }

        private async void btnSaveMail_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.debug)
            {
               
                btnChangePassword.IsEnabled = true;
                txbxMail.IsEnabled = false;
                btnBack.IsEnabled = true;
                btnEditMail.Content = "Edit Email";
                btnEditMail.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(btnSaveMail_Click));
                btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEditMail_Click));

            }
            else
            {
                Reply accept;
                try
                {
                    accept = await Client.EditProfileEmail(txbxMail.Text);

                    if (!accept.Sucsses)
                    {
                        MessageBox.Show(accept.ErrorMessage, "Warning");
                        txbxMail.Text = userDetails.Email;
                        btnChangePassword.IsEnabled = true;
                        txbxMail.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        btnEditMail.Content = "Edit Email";
                        btnEditMail.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(btnSaveMail_Click));
                        btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEditMail_Click));
                    }
                    else
                    {
                        userDetails.Email = txbxMail.Text;
                        btnChangePassword.IsEnabled = true;
                        txbxMail.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        btnEditMail.Content = "Edit Email";
                        btnEditMail.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(btnSaveMail_Click));
                        btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEditMail_Click));

                    }
                }
                catch (HttpRequestException exception)
                {
                    MessageBox.Show(exception.Message, "Warning");
                    txbxMail.Text = userDetails.Email;
                    btnChangePassword.IsEnabled = true;
                    txbxMail.IsEnabled = false;
                    btnBack.IsEnabled = true;
                    btnEditMail.Content = "Edit Email";
                    btnEditMail.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(btnSaveMail_Click));
                    btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEditMail_Click));
                }
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            btnEditMail.IsEnabled = false;
            btnChangePassword.Content = "Save Password";
            txbxPassword.IsEnabled = true;
            btnBack.IsEnabled = false;
            btnChangePassword.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(btnChangePassword_Click));
            btnChangePassword.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnSavePassword_Click));

        }

        private async void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.debug)
            {
                
                btnEditMail.IsEnabled = true;
                btnChangePassword.Content = "Change password";
                txbxPassword.IsEnabled = false;
                btnBack.IsEnabled = true;
                btnChangePassword.RemoveHandler(Button.ClickEvent,
                    new RoutedEventHandler(btnSavePassword_Click));
                btnChangePassword.AddHandler(Button.ClickEvent,
                    new RoutedEventHandler(btnChangePassword_Click));

            }
            else
            {
                Reply accept;
                try
                {
                    accept = await Client.EditProfilePassword(txbxPassword.Text, userDetails.Email);

                    if (!accept.Sucsses)
                    {
                        MessageBox.Show(accept.ErrorMessage, "Warning");
                        txbxPassword.Text = UserInfo.GetUser().GetPassword();
                        btnEditMail.IsEnabled = true;
                        btnChangePassword.Content = "Change password";
                        txbxPassword.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        btnChangePassword.RemoveHandler(Button.ClickEvent,
                            new RoutedEventHandler(btnSavePassword_Click));
                        btnChangePassword.AddHandler(Button.ClickEvent,
                            new RoutedEventHandler(btnChangePassword_Click));
                    }
                    else
                    {   UserInfo.GetUser().SetPassword(txbxPassword.Text);
                        btnEditMail.IsEnabled = true;
                        btnChangePassword.Content = "Change password";
                        txbxPassword.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        btnChangePassword.RemoveHandler(Button.ClickEvent,
                            new RoutedEventHandler(btnSavePassword_Click));
                        btnChangePassword.AddHandler(Button.ClickEvent,
                            new RoutedEventHandler(btnChangePassword_Click));

                    }
                }
                catch (HttpRequestException exception)
                {
                    MessageBox.Show(exception.Message, "Warning");
                    txbxPassword.Text = UserInfo.GetUser().GetPassword();
                    btnEditMail.IsEnabled = true;
                    btnChangePassword.Content = "Change password";
                    txbxPassword.IsEnabled = false;
                    btnBack.IsEnabled = true;
                    btnChangePassword.RemoveHandler(Button.ClickEvent,
                        new RoutedEventHandler(btnSavePassword_Click));
                    btnChangePassword.AddHandler(Button.ClickEvent,
                        new RoutedEventHandler(btnChangePassword_Click));
                }
            }


        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            
            Menu menu = new Menu();
            this.Content = menu;
        }

        private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Reply accept;
            try
            {
                accept = await Client.DeleteAccount();
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
                {
                    MessageBox.Show("Account has been deleted", "Success");
                    UserControlLogin login = new UserControlLogin();
                    this.Content = login;
                }

            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
            }
        }
    }
}
