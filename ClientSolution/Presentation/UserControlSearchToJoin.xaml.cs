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
    /// Interaction logic for UserControlSearchToJoin.xaml
    /// </summary>
    public partial class UserControlSearchToJoin : UserControl
    {
        private List<Game> results;
        private bool searchbyPreferences_isChecked = false;
        private bool searchbyUsername_isChecked = false;
        private bool searchbyPotSize_isChecked = false;

        public UserControlSearchToJoin()
        {
            results = new List<Game>();
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
            txtMinBet.Visibility = Visibility.Hidden;
            lblMinBet.Visibility = Visibility.Hidden;
            cmdDown3.Visibility = Visibility.Hidden;
            cmdUp3.Visibility = Visibility.Hidden;
            cmdDown1.Visibility = Visibility.Hidden;
            cmdDown2.Visibility = Visibility.Hidden;
            cmdUp1.Visibility = Visibility.Hidden;
            cmdUp2.Visibility = Visibility.Hidden;
            lblBuyIn.Visibility = Visibility.Hidden;
            lblChipPolicy.Visibility = Visibility.Hidden;
            txtPlayerName.Visibility = Visibility.Hidden;
            txtPotSize.Visibility = Visibility.Hidden;
            lblChbx.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Content = menu;

        }

        private void slMaxPlayers_DragCompleted(object sender,
            System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (slMaxPlayers.Value < slMinPlayers.Value)
                slMinPlayers.Value = slMaxPlayers.Value;
        }

        private void txtMaxPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (slMaxPlayers.Value < slMinPlayers.Value)
                slMinPlayers.Value = slMaxPlayers.Value;
        }

        private void slMinPlayers_DragCompleted(object sender,
            System.Windows.Controls.Primitives.DragCompletedEventArgs e)
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
        private int _numValue3 = 0;

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

        public int NumValue3
        {
            get { return _numValue3; }
            set
            {
                _numValue3 = value;
                txtMinBet.Text = value.ToString();
            }
        }



        private void cmdUp_Click3(object sender, RoutedEventArgs e)
        {
            NumValue3++;
        }

        private void cmdDown_Click3(object sender, RoutedEventArgs e)
        {
            if (NumValue3 > 0)
                NumValue3--;
        }

        private void txtNum_TextChanged3(object sender, TextChangedEventArgs e)
        {
            if (txtMinBet == null)
            {
                return;
            }

            if (!int.TryParse(txtMinBet.Text, out _numValue3))
                txtMinBet.Text = _numValue3.ToString();
            else
            {
                if (_numValue3 < 10)
                    txtMinBet.Text = "10";
            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            bool success;
           if(rdBtnSearchbyPreferences.IsChecked == true)
               success = await SearchbyPreferences(GetGameType(), GetBuyIn(), GetChipPolicy(), GetMinBet(), GetMaxPlayers(), GetMinPlayers(), GetSpectateGame());
           else if (rdBtnSearchbyPlayerName.IsChecked == true)
               success = await SearchbyPlayerName(txtPlayerName.Text);
           else if (rdBtnSearchbyPotSize.IsChecked == true)
               success = await SearchbyPotSize(Int32.Parse(txtPotSize.Text));
            else
           {
               int all = -1;
               success = await SearchbyPreferences(all, all, all, all, all, all, all);
           }
           
            if (success)
            {
                UserControlJoinGame joinGame = new UserControlJoinGame(results);
                this.Content = joinGame;
            }
        }

        private async Task<bool> SearchbyPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayer, int minPlayer, int spectateGame )
        {
            Reply accept;
            try
            {
                accept = await Client.SearchActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet,  maxPlayer,  minPlayer,  spectateGame);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(((DataString)accept.Content).Content, "Warning");
                    results.Clear();
                    return false;
                }
                else
                {

                    foreach (int gameID in ((DataListInt)accept.Content).Content)
                    {
                        results.Add(new Game(gameID));
                    }

                    return true;
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
                results.Clear();
                return false;

            }
        }

        private async Task<bool> SearchbyPlayerName(String playerName)
        {
            Reply accept;
            try
            {
                accept = await Client.SearchActiveGamesByPlayerName(playerName);

                if (!accept.Sucsses)
                {
                    results.Clear();
                    MessageBox.Show(((DataString)accept.Content).Content, "Warning");
                    return false;

                }
                else
                {

                    foreach (int gameID in ((DataListInt)accept.Content).Content)
                    {
                        results.Add(new Game(gameID));
                    }

                    return true;

                }
            }
            catch (HttpRequestException exception)
            {
                results.Clear();
                MessageBox.Show(exception.Message, "Warning");
                return false;

            }

        }



        private async Task<bool> SearchbyPotSize(int potSize)
        {
            Reply accept;
            try
            {
                accept = await Client.SearchActiveGamesByPot(potSize);

                if (!accept.Sucsses)
                {
                    results.Clear();
                    MessageBox.Show(((DataString)accept.Content).Content, "Warning");
                    return false;

                }
                else
                {

                    foreach (int gameID in ((DataListInt)accept.Content).Content)
                    {
                        results.Add(new Game(gameID));
                    }

                    return true;

                }
            }
            catch (HttpRequestException exception)
            {
                results.Clear();
                MessageBox.Show(exception.Message, "Warning");
                return false;

            }

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

        private void rdBtnSearchbyPotSize_Click(object sender, RoutedEventArgs e)

        {
            if (!searchbyPotSize_isChecked)
            {
                txtPotSize.Visibility = Visibility.Visible;
                txtPlayerName.Visibility = Visibility.Hidden;
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
                txtMinBet.Visibility = Visibility.Hidden;
                lblMinBet.Visibility = Visibility.Hidden;
                cmdDown3.Visibility = Visibility.Hidden;
                cmdUp3.Visibility = Visibility.Hidden;
                cmdDown1.Visibility = Visibility.Hidden;
                cmdDown2.Visibility = Visibility.Hidden;
                cmdUp1.Visibility = Visibility.Hidden;
                cmdUp2.Visibility = Visibility.Hidden;
                lblBuyIn.Visibility = Visibility.Hidden;
                lblChipPolicy.Visibility = Visibility.Hidden;
                lblChbx.Visibility = Visibility.Hidden;
                searchbyPotSize_isChecked = true;
                searchbyPreferences_isChecked = false;
                searchbyUsername_isChecked = false;
            }
            else
            {
                txtPotSize.Visibility = Visibility.Hidden;
                searchbyPotSize_isChecked = false;
                rdBtnSearchbyPotSize.IsChecked = false;
            }
        }

        private void rdBtnSearchbyPlayerName_Click(object sender, RoutedEventArgs e)
        {
            if (!searchbyUsername_isChecked)
            {
                txtPlayerName.Visibility = Visibility.Visible;
                txtPotSize.Visibility = Visibility.Hidden;
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
                txtMinBet.Visibility = Visibility.Hidden;
                lblMinBet.Visibility = Visibility.Hidden;
                cmdDown3.Visibility = Visibility.Hidden;
                cmdUp3.Visibility = Visibility.Hidden;
                cmdDown1.Visibility = Visibility.Hidden;
                cmdDown2.Visibility = Visibility.Hidden;
                cmdUp1.Visibility = Visibility.Hidden;
                cmdUp2.Visibility = Visibility.Hidden;
                lblBuyIn.Visibility = Visibility.Hidden;
                lblChipPolicy.Visibility = Visibility.Hidden;
                lblChbx.Visibility = Visibility.Hidden;
                searchbyUsername_isChecked = true;
                searchbyPreferences_isChecked = false;
                searchbyPotSize_isChecked = false;
            }
            else
            {
                txtPlayerName.Visibility = Visibility.Hidden;
                searchbyUsername_isChecked = false;
                rdBtnSearchbyPlayerName.IsChecked = false;
            }
        }



        private void rdBtnSearchbyPreferences_Checked(object sender, RoutedEventArgs e)
        {
            if (!searchbyPreferences_isChecked)
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
                txtMinBet.Visibility = Visibility.Visible;
                lblMinBet.Visibility = Visibility.Visible;
                cmdDown3.Visibility = Visibility.Visible;
                cmdUp3.Visibility = Visibility.Visible;
                cmdDown1.Visibility = Visibility.Visible;
                cmdDown2.Visibility = Visibility.Visible;
                cmdUp1.Visibility = Visibility.Visible;
                cmdUp2.Visibility = Visibility.Visible;
                lblBuyIn.Visibility = Visibility.Visible;
                lblChipPolicy.Visibility = Visibility.Visible;
                lblChbx.Visibility = Visibility.Visible;
                txtPlayerName.Visibility = Visibility.Hidden;
                txtPotSize.Visibility = Visibility.Hidden;
                searchbyPreferences_isChecked = true;
                searchbyPotSize_isChecked = false;
                searchbyUsername_isChecked = false;
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
                txtMinBet.Visibility = Visibility.Hidden;
                lblMinBet.Visibility = Visibility.Hidden;
                cmdDown3.Visibility = Visibility.Hidden;
                cmdUp3.Visibility = Visibility.Hidden;
                cmdDown1.Visibility = Visibility.Hidden;
                cmdDown2.Visibility = Visibility.Hidden;
                cmdUp1.Visibility = Visibility.Hidden;
                cmdUp2.Visibility = Visibility.Hidden;
                lblBuyIn.Visibility = Visibility.Hidden;
                lblChipPolicy.Visibility = Visibility.Hidden;
                lblChbx.Visibility = Visibility.Hidden;
                searchbyPreferences_isChecked = false;
                rdBtnSearchbyPreferences.IsChecked = false;

            }

        }


        private int GetGameType()
        {
            if (rdbtnLimit.IsChecked == true)
                return 0;
            if (rdbtnNoLimit.IsChecked == true)
                return 1;
            return 2;
        }

        private int GetMinPlayers()
        {
            return (int)slMinPlayers.Value;
        }

        private int GetMaxPlayers()
        {
            return (int)slMaxPlayers.Value;
        }

        private int GetChipPolicy()
        {
            return Int32.Parse(txtChipPolicy.Text);
        }

        private int GetSpectateGame()
        {
            if (chbxCanSpectate.IsChecked == true)
                return 1;
            return 0;
        }

        private int GetBuyIn()
        {
            return Int32.Parse(txtBuyIn.Text);
        }

        private int GetMinBet()
        {
            return Int32.Parse(txtMinBet.Text);
        }
    }
}
