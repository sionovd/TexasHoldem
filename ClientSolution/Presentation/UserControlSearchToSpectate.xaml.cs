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
    /// Interaction logic for UserControlSearchToSpectate.xaml
    /// </summary>
    public partial class UserControlSearchToSpectate : UserControl
    {
        public UserControlSearchToSpectate()
        {
            InitializeComponent();
            lblGameType.Visibility = Visibility.Hidden;
            rdbtnLimit.Visibility = Visibility.Hidden;
            rdbtnNoLimit.Visibility = Visibility.Hidden;
            rdbtnPotLimit.Visibility = Visibility.Hidden;
            chbxCanSpectate.Visibility = Visibility.Hidden;
            lblMinPlayers.Visibility = Visibility.Hidden;
            lblMxPlayers.Visibility = Visibility.Hidden;
            slMaxPlayers.Visibility = Visibility.Hidden;
            slMinPlayers.Visibility = Visibility.Hidden;
            txtMaxPlayers.Visibility = Visibility.Hidden;
            txtMinPlayers.Visibility = Visibility.Hidden;
            txtBuyIn.Visibility = Visibility.Hidden;
            txtChipPolicy.Visibility = Visibility.Hidden;
            cmdDown1.Visibility = Visibility.Hidden;
            cmdDown2.Visibility = Visibility.Hidden;
            cmdUp1.Visibility = Visibility.Hidden;
            cmdUp2.Visibility = Visibility.Hidden;
            lblBuyIn.Visibility = Visibility.Hidden;
            lblChipPolicy.Visibility = Visibility.Hidden;
            txtPlayerName.Visibility = Visibility.Hidden;
            txtPotSize.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;

        }

        private void slMaxPlayers_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (slMaxPlayers.Value < slMinPlayers.Value)
                slMinPlayers.Value = slMaxPlayers.Value;
        }
        private void txtMaxPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (slMaxPlayers.Value < slMinPlayers.Value)
                slMinPlayers.Value = slMaxPlayers.Value;
        }

        private void slMinPlayers_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (slMinPlayers.Value > slMaxPlayers.Value)
                slMaxPlayers.Value = slMinPlayers.Value;
        }

        private void txtMinPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (slMinPlayers.Value > slMaxPlayers.Value)
                slMaxPlayers.Value = slMinPlayers.Value;

        }

        private int _numValue1 = 0;
        private int _numValue2 = 0;

        public int NumValue1
        {
            get { return _numValue1; }
            set
            {
                _numValue1 = value;
                txtBuyIn.Text = value.ToString();
            }
        }

        private void cmdUp_Click1(object sender, RoutedEventArgs e)
        {
            NumValue1++;
        }

        private void cmdDown_Click1(object sender, RoutedEventArgs e)
        {
            if (NumValue1 > 0)
                NumValue1--;
        }

        private void txtNum_TextChanged1(object sender, TextChangedEventArgs e)
        {
            if (txtBuyIn == null)
            {
                return;
            }

            if (!int.TryParse(txtBuyIn.Text, out _numValue1))
            {
                txtBuyIn.Text = _numValue1.ToString();
            }
            else
            {
                if (_numValue1 < 0)
                    txtBuyIn.Text = "0";
            }
        }

        public int NumValue2
        {
            get { return _numValue2; }
            set
            {
                _numValue2 = value;
                txtChipPolicy.Text = value.ToString();
            }
        }



        private void cmdUp_Click2(object sender, RoutedEventArgs e)
        {
            NumValue2++;
        }

        private void cmdDown_Click2(object sender, RoutedEventArgs e)
        {
            if (NumValue2 > 0)
                NumValue2--;
        }

        private void txtNum_TextChanged2(object sender, TextChangedEventArgs e)
        {
            if (txtChipPolicy == null)
            {
                return;
            }

            if (!int.TryParse(txtChipPolicy.Text, out _numValue2))
                txtChipPolicy.Text = _numValue2.ToString();
            else
            {
                if (_numValue2 < 0)
                    txtChipPolicy.Text = "0";
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void chbxSearchbyPreferences_Click(object sender, RoutedEventArgs e)
        {
            if (chbxSearchbyPreferences.IsChecked == true)
            {
                lblGameType.Visibility = Visibility.Visible;
                rdbtnLimit.Visibility = Visibility.Visible;
                rdbtnNoLimit.Visibility = Visibility.Visible;
                rdbtnPotLimit.Visibility = Visibility.Visible;
                chbxCanSpectate.Visibility = Visibility.Visible;
                lblMinPlayers.Visibility = Visibility.Visible;
                lblMxPlayers.Visibility = Visibility.Visible;
                slMaxPlayers.Visibility = Visibility.Visible;
                slMinPlayers.Visibility = Visibility.Visible;
                txtMaxPlayers.Visibility = Visibility.Visible;
                txtMinPlayers.Visibility = Visibility.Visible;
                txtBuyIn.Visibility = Visibility.Visible;
                txtChipPolicy.Visibility = Visibility.Visible;
                cmdDown1.Visibility = Visibility.Visible;
                cmdDown2.Visibility = Visibility.Visible;
                cmdUp1.Visibility = Visibility.Visible;
                cmdUp2.Visibility = Visibility.Visible;
                lblBuyIn.Visibility = Visibility.Visible;
                lblChipPolicy.Visibility = Visibility.Visible;
            }
            else
            {
                lblGameType.Visibility = Visibility.Hidden;
                rdbtnLimit.Visibility = Visibility.Hidden;
                rdbtnNoLimit.Visibility = Visibility.Hidden;
                rdbtnPotLimit.Visibility = Visibility.Hidden;
                chbxCanSpectate.Visibility = Visibility.Hidden;
                lblMinPlayers.Visibility = Visibility.Hidden;
                lblMxPlayers.Visibility = Visibility.Hidden;
                slMaxPlayers.Visibility = Visibility.Hidden;
                slMinPlayers.Visibility = Visibility.Hidden;
                txtMaxPlayers.Visibility = Visibility.Hidden;
                txtMinPlayers.Visibility = Visibility.Hidden;
                txtBuyIn.Visibility = Visibility.Hidden;
                txtChipPolicy.Visibility = Visibility.Hidden;
                cmdDown1.Visibility = Visibility.Hidden;
                cmdDown2.Visibility = Visibility.Hidden;
                cmdUp1.Visibility = Visibility.Hidden;
                cmdUp2.Visibility = Visibility.Hidden;
                lblBuyIn.Visibility = Visibility.Hidden;
                lblChipPolicy.Visibility = Visibility.Hidden;

            }


        }

        private void chbxSearchbyPlayerName_Click(object sender, RoutedEventArgs e)
        {
            if (chbxSearchbyPlayerName.IsChecked == true)
                txtPlayerName.Visibility = Visibility.Visible;
            else
                txtPlayerName.Visibility = Visibility.Hidden;

        }

        private void chbxSearchbyPotSize_Click(object sender, RoutedEventArgs e)
        {
            if (chbxSearchbyPotSize.IsChecked == true)
                txtPotSize.Visibility = Visibility.Visible;
            else
                txtPotSize.Visibility = Visibility.Hidden;

        }

        private void txtPotSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value = 0;
            if (txtPotSize.Text == null)
            {
                return;
            }

            if (!int.TryParse(txtPotSize.Text, out value))
            {
                txtPotSize.Text = value.ToString();
            }
            else
            {
                if (value < 0)
                    txtPotSize.Text = "0";
            }
        }
    }
}
