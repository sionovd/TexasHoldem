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
using Communication.GameLogInfo;
using Communication.Replies;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlReplay.xaml
    /// </summary>
    public partial class UserControlReplay : UserControl
    {

        private Seat[] seats;
        private bool seatsHaveBeenTaken;
        private ReplayInfo replayInfo;
        private int nextMove;
        public UserControlReplay(ReplayInfo replayInfo)
        {
            InitializeComponent();
            this.replayInfo = replayInfo;
            nextMove = 0;
            seatsHaveBeenTaken = false;
            seats = new Seat[9] { new Seat(ImgSmallBigBlind1, TxtUsername1, TxtChips1, TxtBet1), new Seat(ImgSmallBigBlind2, TxtUsername2, TxtChips2, TxtBet2), new Seat(ImgSmallBigBlind3, TxtUsername3, TxtChips3, TxtBet3),
                new Seat(ImgSmallBigBlind4, TxtUsername4,TxtChips4, TxtBet4), new Seat(ImgSmallBigBlind5, TxtUsername5, TxtChips5, TxtBet5), new Seat(ImgSmallBigBlind6, TxtUsername6, TxtChips6, TxtBet6),
                new Seat(ImgSmallBigBlind7, TxtUsername7, TxtChips7, TxtBet7), new Seat(ImgSmallBigBlind8, TxtUsername8, TxtChips8, TxtBet8), new Seat(ImgSmallBigBlind9, TxtUsername9, TxtChips9, TxtBet9) };

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
        public void Update(GameInfo gameInfo)
        {
                        txtPotSize.Text = gameInfo.PotSize.ToString();
                        UpdateCommunityCards(gameInfo.RoundNumber, gameInfo.TableCards);
                        UpdateSeats(gameInfo.PlayersInfo, gameInfo.PlayerTurnID, gameInfo.SmallBlindPlayerID, gameInfo.BigBlindPlayerID);
        }

        private void UpdateSeats(List<PlayerInfo> gameInfoPlayersInfo, int gameInfoPlayerTurnId, int smallBlindPlayerID, int bigBlindPlayerID)
        {
            if (!seatsHaveBeenTaken)
            {
                seatsHaveBeenTaken = true;
                int numOfPlayers = gameInfoPlayersInfo.Count;
                switch (numOfPlayers)
                {
                    case 2:
                        seats[0].TakeSeat(gameInfoPlayersInfo[0].Username, gameInfoPlayersInfo[0].PlayerID);
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
                    if (seat.PlayerID == gameInfoPlayerTurnId)
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
                                seat.UpdateState(playerInfo.MoneyBalance, playerInfo.AmountBetOnCurrentRound);
                                if (gameInfoPlayerTurnId == playerInfo.PlayerID)
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

        private void UpdateCommunityCards(int roundNumber, CardType[] cards)
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
        public void Update(EndGameInfo endGameInfo)
        {    
           this.Content = new UserControlEndGame(endGameInfo);
        }

        private void BtnNextMove_OnClick(object sender, RoutedEventArgs e)
        {
            if (nextMove >= replayInfo.GameInfoList.Count)
                Update(new EndGameInfo(replayInfo.EndGameInfo));
            else
            {
                Update(new GameInfo(replayInfo.GameInfoList[nextMove]));
                nextMove++;
            }

            
        }
    }
}
