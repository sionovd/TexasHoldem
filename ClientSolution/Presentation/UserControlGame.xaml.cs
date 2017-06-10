using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Communication;
using Communication.GameLogInfo;
using Communication.Replies;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlGame.xaml
    /// </summary>
    public partial class UserControlGame : UserControl , GameListener
    {
       
        private int gameID;
        private int playerID;

        public UserControlGame(int gameID, int playerID)
        {
            this.gameID = gameID;
            this.playerID = playerID;
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

        private async void BtnLeaveTable_Click(object sender, RoutedEventArgs e)
        {

            Reply accept;
            try
            {
                accept = await Client.LeaveGame(gameID);
            
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
                {

                    if (UserControlTabs.userControlTabs.tabControl.Items.Count <= 2)
                    {
                        UserControlTabs.firstInitiate = true;
                        Menu menu = new Menu();
                        UserControlTabs.userControlTabs.Content = menu;
                    }
                    else
                    {

                        UserControlTabs.userControlTabs.tabControl.Items.Remove(UserControlTabs.userControlTabs
                            .tabControl.SelectedItem);
                    }

                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
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

        private int GetBetAmount()
        {
            return Int32.Parse(txtBetSize.Text);
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            if (rdbtFold.IsChecked == true)
                success = await MakeFold(playerID, gameID); 
            else if (rdbtnCall.IsChecked == true)
                success = await MakeCall(playerID, gameID);
            else if (rdbtnCheck.IsChecked == true)
                success = await MakeCheck(playerID, gameID);
            else if (rdbtnBet.IsChecked == true)
                success = await MakeBet(playerID, gameID, GetBetAmount());

            else
                success = false;

            if (success)
            {
                rdbtFold.IsChecked = false;
                rdbtnBet.IsChecked = false;
                rdbtnCall.IsChecked = false;
                rdbtnCheck.IsChecked = false;
                rdbtFold.IsEnabled = false;
                rdbtnBet.IsEnabled = false;
                rdbtnCall.IsEnabled = false;
                rdbtnCheck.IsEnabled = false;
                btnConfirm.IsEnabled = false;
                btnConfirm.Visibility = Visibility.Hidden;
                txtBetSize.IsEnabled = false;
                txtBetSize.Visibility = Visibility.Hidden;
            }
        }

        private async Task<bool> MakeFold(int playerID, int gameID)
        {
            Reply accept;
            try
            {
               accept = await Client.Fold(playerID, gameID);
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
                return false;
            }
            
        }

        private async Task<bool> MakeCall(int playerID, int gameID)
        {
            Reply accept;
            try
            {
                accept = await Client.Call(playerID , gameID);
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
                return false;
            }

        }

        private async Task<bool> MakeCheck(int playerID, int gameID)
        {
            Reply accept;
            try
            {
                accept = await Client.Check(playerID, gameID);
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
                return false;
            }

        }

        private async Task<bool> MakeBet(int playerID, int gameID, int amount)
        {
            Reply accept;
            try
            {
                accept = await Client.Bet(playerID, gameID, amount);
                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
                return false;
            }

        }

        private async void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
          
            Reply accept;
            try
            {
                accept = await Client.StartGame(gameID);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
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
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
            }
        }

        public void Update(GameInfo gameInfo)
        {
            this.Dispatcher.Invoke(() =>
                {
                    if (gameInfo.GameID == gameID)
                    {
                        if (gameInfo.PlayerTurnID == playerID)
                        {
                            rdbtFold.IsEnabled = true;
                            rdbtnBet.IsEnabled = true;
                            rdbtnCall.IsEnabled = true;
                            rdbtnCheck.IsEnabled = true;
                        }

                        txtPotSize.Text = gameInfo.PotSize.ToString();
                        CardType[] cards = gameInfo.TableCards;
                        int roundNumber = gameInfo.RoundNumber;
                        switch (roundNumber)
                        {
                            case 2:
                                com1.Source = GUICards.GetImageSource(cards[0]);
                                com2.Source = GUICards.GetImageSource(cards[1]);
                                com3.Source = GUICards.GetImageSource(cards[2]);
                                break;
                            case 3:
                                com4.Source = GUICards.GetImageSource(cards[3]);
                                break;
                            case 4:
                                com5.Source = GUICards.GetImageSource(cards[4]);
                                break;
                        }

                        stateGameBoard.ItemsSource = gameInfo.PlayersInfo;

                    }
                }
            );


            }

        public void Update(PlayerCardsInfo playerCardsInfo)
        {
            throw new NotImplementedException();
        }

        public void Update(EndGameInfo endGameInfo)
        {
            if (endGameInfo.GameID == gameID)
            {
                this.Content = new UserControlEndGame(endGameInfo);
            }
        }
    }
}
