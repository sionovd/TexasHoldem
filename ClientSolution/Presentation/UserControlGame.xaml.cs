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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlGame.xaml
    /// </summary>
    public partial class UserControlGame : UserControl
    {
        public UserControlGame()
        {
            InitializeComponent();
            rdbtFold.Visibility = Visibility.Hidden;
            rdbtnBet.Visibility = Visibility.Hidden;
            rdbtnCall.Visibility = Visibility.Hidden;
            rdbtnCheck.Visibility = Visibility.Hidden;
            btnConfirm.Visibility = Visibility.Hidden;
            txtBetSize.Visibility = Visibility.Hidden;
            txtPotSize.Visibility = Visibility.Hidden;
            lblPotSize.Visibility = Visibility.Hidden;
            hole1.Visibility = Visibility.Hidden;
            hole2.Visibility = Visibility.Hidden;
            com1.Visibility = Visibility.Hidden;
            com2.Visibility = Visibility.Hidden;
            com3.Visibility = Visibility.Hidden;
            com4.Visibility = Visibility.Hidden;
            com5.Visibility = Visibility.Hidden;


        }

        private void BtnLeaveTable_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlTabs.userControlTabs.tabControl.Items.Count <= 2)
            {
                UserControlTabs.firstInitiate = true;
                Menu menu = new Menu();
                UserControlTabs.userControlTabs.Content = menu;
            }
            else
            {

                UserControlTabs.userControlTabs.tabControl.Items.Remove(UserControlTabs.userControlTabs.tabControl.SelectedItem);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value;
            if (!int.TryParse(txtBetSize.Text, out value))
                txtBetSize.Text = value.ToString();
            else
            {
                if (value < 0)
                    txtBetSize.Text = "0";
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbtnBet.IsChecked == true)
            {
                txtBetSize.Visibility = Visibility.Visible;
                txtBetSize.IsEnabled = true;
            }
            else
            {
                txtBetSize.Visibility = Visibility.Hidden;
                txtBetSize.IsEnabled = false;
            }

            btnConfirm.Visibility = Visibility.Visible;
            btnConfirm.IsEnabled = true;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            rdbtFold.IsChecked = false;
            rdbtnBet.IsChecked = false;
            rdbtnCall.IsChecked = false;
            rdbtnCheck.IsChecked = false;
            btnConfirm.IsEnabled = false;
            btnConfirm.Visibility = Visibility.Hidden;
            txtBetSize.IsEnabled = false;
            txtBetSize.Visibility = Visibility.Hidden;

        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            btnStartGame.Visibility = Visibility.Hidden;

            rdbtFold.Visibility = Visibility.Visible;
            rdbtnBet.Visibility = Visibility.Visible;
            rdbtnCall.Visibility = Visibility.Visible;
            rdbtnCheck.Visibility = Visibility.Visible;
            txtPotSize.Visibility = Visibility.Visible;
            lblPotSize.Visibility = Visibility.Visible;
            hole1.Visibility = Visibility.Visible;
            hole2.Visibility = Visibility.Visible;
            com1.Visibility = Visibility.Visible;
            com2.Visibility = Visibility.Visible;
            com3.Visibility = Visibility.Visible;
            com4.Visibility = Visibility.Visible;
            com5.Visibility = Visibility.Visible;

        }
    }
}
