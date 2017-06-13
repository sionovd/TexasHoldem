using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
        private Seat[] seats;
        private bool seatsHaveBeenTaken;

        public UserControlGame(int gameID, int playerID)
        {   
            InitializeComponent();
            Receiver.GetReceiver().Attach(this);
            this.gameID = gameID;
            this.playerID = playerID;
            seatsHaveBeenTaken = false;
            seats = new Seat[9] { new Seat(ImgSmallBigBlind1, TxtUsername1, TxtChips1, TxtBet1), new Seat(ImgSmallBigBlind2, TxtUsername2, TxtChips2, TxtBet2), new Seat(ImgSmallBigBlind3, TxtUsername3, TxtChips3, TxtBet3),
                    new Seat(ImgSmallBigBlind4, TxtUsername4,TxtChips4, TxtBet4), new Seat(ImgSmallBigBlind5, TxtUsername5, TxtChips5, TxtBet5), new Seat(ImgSmallBigBlind6, TxtUsername6, TxtChips6, TxtBet6),
                    new Seat(ImgSmallBigBlind7, TxtUsername7, TxtChips7, TxtBet7), new Seat(ImgSmallBigBlind8, TxtUsername8, TxtChips8, TxtBet8), new Seat(ImgSmallBigBlind9, TxtUsername9, TxtChips9, TxtBet9) };
           
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
                /*rdbtFold.IsEnabled = false;
                rdbtnBet.IsEnabled = false;
                rdbtnCall.IsEnabled = false;
                rdbtnCheck.IsEnabled = false;
                btnConfirm.IsEnabled = false;*/
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

                        txtPotSize.Text = gameInfo.PotSize.ToString();
                        UpdateCommunityCards(gameInfo.RoundNumber, gameInfo.TableCards);
                        UpdateSeats(gameInfo.PlayersInfo, gameInfo.PlayerTurnID, gameInfo.SmallBlindPlayerID, gameInfo.BigBlindPlayerID);


                        // stateGameBoard.ItemsSource = gameInfo.PlayersInfo;

                    }
                }
            );


            }

        private void UpdateSeats(List<PlayerInfo> gameInfoPlayersInfo, int gameInfoPlayerTurnId, int smallBlindPlayerID, int bigBlindPlayerID )
        {
            if (!seatsHaveBeenTaken)
            {
                seatsHaveBeenTaken = true;
                int numOfPlayers = gameInfoPlayersInfo.Count;
                switch (numOfPlayers)
                {
                    case 2:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username , gameInfoPlayersInfo[0].PlayerID);
                        seats[5].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        break;
                    case 3:
                        seats[2].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[5].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[8].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        break;
                    case 4:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[2].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[5].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        seats[7].TakeSeat(gameInfoPlayersInfo[3].Username, gameInfoPlayersInfo[3].PlayerID);
                        break;
                    case 5:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[2].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[4].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        seats[6].TakeSeat(gameInfoPlayersInfo[3].Username, gameInfoPlayersInfo[3].PlayerID);
                        seats[8].TakeSeat(gameInfoPlayersInfo[4].Username, gameInfoPlayersInfo[4].PlayerID);
                        break;
                    case 6:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[1].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[3].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        seats[4].TakeSeat(gameInfoPlayersInfo[3].Username, gameInfoPlayersInfo[3].PlayerID);
                        seats[6].TakeSeat(gameInfoPlayersInfo[4].Username, gameInfoPlayersInfo[4].PlayerID);
                        seats[7].TakeSeat(gameInfoPlayersInfo[5].Username, gameInfoPlayersInfo[5].PlayerID);
                        break;
                    case 7:
                        seats[1].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[2].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[3].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        seats[4].TakeSeat(gameInfoPlayersInfo[3].Username, gameInfoPlayersInfo[3].PlayerID);
                        seats[6].TakeSeat(gameInfoPlayersInfo[4].Username, gameInfoPlayersInfo[4].PlayerID);
                        seats[7].TakeSeat(gameInfoPlayersInfo[5].Username, gameInfoPlayersInfo[5].PlayerID);
                        seats[8].TakeSeat(gameInfoPlayersInfo[6].Username, gameInfoPlayersInfo[6].PlayerID);
                        break;
                    case 8:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[1].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[2].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        seats[3].TakeSeat(gameInfoPlayersInfo[3].Username, gameInfoPlayersInfo[3].PlayerID);
                        seats[4].TakeSeat(gameInfoPlayersInfo[4].Username, gameInfoPlayersInfo[4].PlayerID);
                        seats[5].TakeSeat(gameInfoPlayersInfo[5].Username, gameInfoPlayersInfo[5].PlayerID);
                        seats[6].TakeSeat(gameInfoPlayersInfo[6].Username, gameInfoPlayersInfo[6].PlayerID);
                        seats[7].TakeSeat(gameInfoPlayersInfo[7].Username, gameInfoPlayersInfo[7].PlayerID);
                        break;
                    case 9:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
                        seats[1].TakeSeat(gameInfoPlayersInfo[1].Username, gameInfoPlayersInfo[1].PlayerID);
                        seats[2].TakeSeat(gameInfoPlayersInfo[2].Username, gameInfoPlayersInfo[2].PlayerID);
                        seats[3].TakeSeat(gameInfoPlayersInfo[3].Username, gameInfoPlayersInfo[3].PlayerID);
                        seats[4].TakeSeat(gameInfoPlayersInfo[4].Username, gameInfoPlayersInfo[4].PlayerID);
                        seats[5].TakeSeat(gameInfoPlayersInfo[5].Username, gameInfoPlayersInfo[5].PlayerID);
                        seats[6].TakeSeat(gameInfoPlayersInfo[6].Username, gameInfoPlayersInfo[6].PlayerID);
                        seats[7].TakeSeat(gameInfoPlayersInfo[7].Username, gameInfoPlayersInfo[7].PlayerID);
                        seats[8].TakeSeat(gameInfoPlayersInfo[8].Username, gameInfoPlayersInfo[8].PlayerID);
                        break;
                }


                foreach (Seat seat in seats)
                {
                    if (seat.IsActive)
                    {
                        if (seat.PlayerID == smallBlindPlayerID)
                            seat.Blind.Source = new BitmapImage(new Uri(@"pack://application:,,,/Presentation;component/images/SB.png"));
                        if (seat.PlayerID == bigBlindPlayerID)
                            seat.Blind.Source = new BitmapImage(new Uri(@"pack://application:,,,/Presentation;component/images/BB.png"));

                    }
                }
            }

          
            
            
                foreach (Seat seat in seats)
                {
                    if (seat.IsActive)
                    {
                        if(seat.PlayerID == gameInfoPlayerTurnId)
                            seat.NowTurn();
                        bool found = false;
                        foreach (PlayerInfo playerInfo in gameInfoPlayersInfo)
                        {
                            if (playerInfo.PlayerID == seat.PlayerID)
                            {
                                found = true;
                                if (playerInfo.IsFold)
                                    seat.Fold();
                                else
                                {
                                    seat.UpdateState(playerInfo.MoneyBalance , playerInfo.AmountBetOnCurrentRound);
                                if(gameInfoPlayerTurnId == playerInfo.PlayerID)
                                    seat.NowTurn();
                                else
                                    seat.WaitToTurn();
                               
                                }
                                break;
                            }
                        }

                        if (!found)
                            seat.LeaveRoom();


                    }
                    
                }
                
            
        }

        private void UpdateCommunityCards(int roundNumber , CardType[] cards)
        {
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
        }

        public void Update(PlayerCardsInfo playerCardsInfo)
        {
            if (playerCardsInfo.GameID == gameID && playerCardsInfo.PlayerID == playerID)
            {
                this.Dispatcher.Invoke(() =>
                {
                    hole1.Source = GUICards.GetImageSource(playerCardsInfo.PlayerCards[0]);
                    hole2.Source = GUICards.GetImageSource(playerCardsInfo.PlayerCards[1]);
                });
                
            }
        }

        public void Update(EndGameInfo endGameInfo)
        {
            Dispatcher.Invoke(() =>
            {
                if (endGameInfo.GameID == gameID)
                {
                    this.Content = new UserControlEndGame(endGameInfo);
                }
            });
        }

        private void Expander_OnExpanded(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
