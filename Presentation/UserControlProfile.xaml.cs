using System;
using Microsoft.Win32;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlProfile.xaml
    /// </summary>
    public partial class UserControlProfile : UserControl
    {
        public UserControlProfile()
        {
            InitializeComponent();
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
            btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnSaveMail_Click));
        }

        private void btnSaveMail_Click(object sender, RoutedEventArgs e)
        {
            btnChangePassword.IsEnabled = true;
            txbxMail.IsEnabled = false;
            btnBack.IsEnabled = true;
            btnEditMail.Content = "Edit Email";
            btnEditMail.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEditMail_Click));

        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            btnEditMail.IsEnabled = false;
            btnChangePassword.Content = "Save Password";
            txbxPassword.IsEnabled = true;
            btnBack.IsEnabled = false;
            btnChangePassword.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnSavePassword_Click));

        }

        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            btnEditMail.IsEnabled = true;
            btnChangePassword.Content = "Change password";
            txbxPassword.IsEnabled = false;
            btnBack.IsEnabled = true;
            btnChangePassword.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnChangePassword_Click));


        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            
            Menu menu = new Menu();
            this.Content = menu;
        }
    }
}
