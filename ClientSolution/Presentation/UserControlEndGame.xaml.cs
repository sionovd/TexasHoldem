using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Communication.GameLogInfo;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlEndGame.xaml
    /// </summary>
    public partial class UserControlEndGame : UserControl
    {
        private Image [] images;
        private Label[] labels;
        public UserControlEndGame(EndGameInfo endGameInfo)
        {
            InitializeComponent();
            images = new Image[16] { Img11, Img12, Img21, Img22, Img31, Img32, Img41, Img42,
                                     Img51, Img52, Img61, Img62, Img71, Img72, Img81, Img82 };
            labels = new Label[8]{Lbl1, Lbl2, Lbl3, Lbl4, Lbl5, Lbl6, Lbl7, Lbl8 };

            UpdateEndGameWindow(endGameInfo);
            
        }

        private void UpdateEndGameWindow(EndGameInfo endGameInfo)
        {
            string usernameWinner = endGameInfo.UsernameWinner;
            LblWinnerName.Content = usernameWinner;
            if (!endGameInfo.OnePlayerLeft)
            {
                List<PlayerCardsInfo> playersCards = endGameInfo.PlayersCards;
                int i = 0;
                foreach (PlayerCardsInfo playerCards in playersCards)
                {
                    if (!playerCards.Username.Equals(usernameWinner))
                    {
                        images[2 * i].Source = GUICards.GetImageSource(playerCards.PlayerCards[0]);
                        images[2 * i + 1].Source = GUICards.GetImageSource(playerCards.PlayerCards[1]);
                        labels[i].Content = playerCards.Username;
                        i++;
                    }
                    else
                    {
                        ImgWinner1.Source = GUICards.GetImageSource(playerCards.PlayerCards[0]);
                        ImgWinner2.Source = GUICards.GetImageSource(playerCards.PlayerCards[1]);
                    }

                }

                for (int j = i; j < 8; j++)
                {
                    images[2 * i].Visibility = Visibility.Hidden;
                    images[2 * i + 1].Visibility = Visibility.Hidden;
                    labels[i].Visibility = Visibility.Hidden;


                }

                ImgCom1.Source = GUICards.GetImageSource(endGameInfo.CommunityCards[0]);
                ImgCom2.Source = GUICards.GetImageSource(endGameInfo.CommunityCards[1]);
                ImgCom3.Source = GUICards.GetImageSource(endGameInfo.CommunityCards[2]);
                ImgCom4.Source = GUICards.GetImageSource(endGameInfo.CommunityCards[3]);
                ImgCom5.Source = GUICards.GetImageSource(endGameInfo.CommunityCards[4]);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    images[2 * i].Visibility = Visibility.Hidden;
                    images[2 * i + 1].Visibility = Visibility.Hidden;
                    labels[i].Visibility = Visibility.Hidden;  
                }
                ImgCom1.Visibility = Visibility.Hidden;
                ImgCom2.Visibility = Visibility.Hidden;
                ImgCom3.Visibility = Visibility.Hidden;
                ImgCom4.Visibility = Visibility.Hidden;
                ImgCom5.Visibility = Visibility.Hidden;
                ImgWinner1.Visibility = Visibility.Hidden;
                ImgWinner2.Visibility = Visibility.Hidden;
            }
        }
        private void BtnLeave_OnClick(object sender, RoutedEventArgs e)
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
}
