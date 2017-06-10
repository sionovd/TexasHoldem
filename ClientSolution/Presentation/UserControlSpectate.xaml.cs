using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Communication;
using Communication.GameLogInfo;
using Communication.Replies;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlSpectate.xaml
    /// </summary>
    public partial class UserControlSpectate : UserControl , GameListener
    {
        private int gameID;
        private int spectatorID;
        public UserControlSpectate(int gameID, int spectatorID)
        {
            this.gameID = gameID;
            this.spectatorID = spectatorID;
            InitializeComponent();
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


        public void Update(GameInfo gameInfo)
        {
            this.Dispatcher.Invoke(() =>
                {
                    if (gameInfo.GameID == gameID)
                    {
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
