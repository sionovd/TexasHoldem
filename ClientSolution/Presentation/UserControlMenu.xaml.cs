using Communication;
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
using Communication.Replies;
using UserInfo = Communication.UserInfo;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            LblUserWelcome.Content = LblUserWelcome.Content + UserInfo.GetUser().GetUsername() + "!";
            if (UserControlTabs.firstInitiate == false)
                btnLogout.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            UserControlProfile profile = new UserControlProfile();
            this.Content = profile;

        }

        private void Button_Click_CreateGame(object sender, RoutedEventArgs e)
        {
            UserControlCreateGame createGame = new UserControlCreateGame();
            this.Content = createGame;
        }

        private async void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            if (MainWindow.debug)
            {
                UserControlLogin login = new UserControlLogin();
                this.Content = login;
            }
            else
            {
                Reply accept;
                try
                {
                    accept = await Client.Logout();

                    if (!accept.Sucsses)
                    {
                        MessageBox.Show(accept.ErrorMessage, "Warning");
                    }
                    else
                    {
                        UserControlLogin login = new UserControlLogin();
                        this.Content = login;

                    }
                }
                catch (HttpRequestException exception)
                {
                    MessageBox.Show(exception.Message, "Warning");
                }
            }
        }

        private void btnJoinActiveGame_Click(object sender, RoutedEventArgs e)
        {
            UserControlSearchToJoin searchTojoin = new UserControlSearchToJoin();
            this.Content = searchTojoin;

        }

        private async void btnSpectateGame_Click(object sender, RoutedEventArgs e)
        {
            ReplyListInt accept;
            try
            {
                accept = await Client.ViewSpectatableGames();


                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.ErrorMessage, "Warning");
                }
                else
                {
                    List<Game> games = new List<Game>();
                    foreach (int gameID in (accept.ListIntContent))
                    {
                        games.Add(new Game(gameID));
                    }
                   
                    UserControlSpectateGame spectate = new UserControlSpectateGame(games);
                    this.Content = spectate;
                }
            }
            catch (HttpRequestException exception)
            {
                MessageBox.Show(exception.Message, "Warning");
            }
        }

        private void btnWatchReplayes_Click(object sender, RoutedEventArgs e)
        {

            UserControlWatchReplayes watchReplays = new UserControlWatchReplayes();
            this.Content = watchReplays;

        }
    }
}
