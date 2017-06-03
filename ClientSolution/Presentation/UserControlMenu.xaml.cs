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
            if (GameWindow.firstInitiate == false)
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

            Reply accept;
            try
            {
                accept = await Client.Logout();

                if (!accept.Sucsses)
                {
                    MessageBox.Show(accept.StringContext, "Warning");
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
                UserControlLogin login = new UserControlLogin();
                this.Content = login;
            }
           
        }

        private void btnJoinActiveGame_Click(object sender, RoutedEventArgs e)
        {
            UserControlSearchToJoin searchTojoin = new UserControlSearchToJoin();
            this.Content= searchTojoin;
            
        }
        
        private void btnSpectateGame_Click(object sender, RoutedEventArgs e)
        {
            UserControlSpectateGame spectate = new UserControlSpectateGame();
            this.Content = spectate;
        }

        private void btnWatchReplayes_Click(object sender, RoutedEventArgs e)
        {

            UserControlWatchReplayes watchReplays = new UserControlWatchReplayes();
            this.Content = watchReplays;

        }
    }
}
