using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
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
using Communication.Replies;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for UserControlCreateGame.xaml
    /// </summary>
    public partial class UserControlCreateGame : UserControl
    {
         
 

        public UserControlCreateGame()
        {
            InitializeComponent();
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
            return (int) slMinPlayers.Value;
        }

        private int GetMaxPlayers()
        {
            return (int) slMaxPlayers.Value;
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
        private async void btnJoinGame_Click(object sender, RoutedEventArgs e)
        {   
            List<KeyValuePair<string, int>> preferenceList = new List<KeyValuePair<string, int>>();
            KeyValuePair<string, int> gameType = new KeyValuePair<string, int>("gameType" , GetGameType());
            KeyValuePair<string, int> minPlayers = new KeyValuePair<string, int>("minPlayers", GetMinPlayers());
            KeyValuePair<string, int> maxPlayers = new KeyValuePair<string, int>("maxPlayers", GetMaxPlayers());
            KeyValuePair<string, int> minBet = new KeyValuePair<string, int>("minBet", GetMinBet());
            KeyValuePair<string, int> chipPolicy = new KeyValuePair<string, int>("chipPolicy", GetChipPolicy());
            KeyValuePair<string, int> spectateGame = new KeyValuePair<string, int>("spectateGame", GetSpectateGame());
            KeyValuePair<string, int> buyIn = new KeyValuePair<string, int>("buyIn", GetBuyIn());
            preferenceList.Add(gameType);
            preferenceList.Add(minPlayers);
            preferenceList.Add(maxPlayers);
            preferenceList.Add(minBet);
            preferenceList.Add(chipPolicy);
            preferenceList.Add(spectateGame);
            preferenceList.Add(buyIn);

            Reply accept;
            try
            {
                accept = await Client.CreateGame(User.GetUser().GetUsername(), preferenceList);

                if (!accept.Sucsses)
                {
                    MessageBox.Show(((DataString)accept.Content).Content, "Warning");
                }
                else
                {
                    int gameID = ((DataInt) accept.Content).Content;
                    int playerID = 1;
                    if (!UserControlTabs.firstInitiate)
                    {

                        (UserControlTabs.userControlTabs.tabControl.SelectedItem as TabItem).Header = "Active Game";
                        TabItem newTabItem = new TabItem();
                        newTabItem.Header = "Menu";
                        Menu newMenu = new Menu();
                        newMenu.btnLogout.Visibility = Visibility.Hidden;
                        newTabItem.Content = newMenu;
                        UserControlTabs.userControlTabs.tabControl.Items.Add(newTabItem);
                        UserControlGame game = new UserControlGame(gameID, playerID);
                        this.Content = game;
                    }
                    else
                    {
                        UserControlTabs.firstInitiate = false;
                        UserControlTabs.userControlTabs = new UserControlTabs();
                        UserControlTabs.userControlTabs.firstTab.Content = new UserControlGame(gameID, playerID);
                        UserControlTabs.userControlTabs.firstTab.Header = "Active Game";
                        this.Content = UserControlTabs.userControlTabs;

                    }
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
            }
        }
    }
}
