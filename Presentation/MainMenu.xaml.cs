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
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            Menu menu = new Menu();
            menu.btnLogout.Visibility = Visibility.Visible;
            menu.btnProfile.Click += new RoutedEventHandler(Button_Click_Profile);
            menu.btnCreateGame.Click += new RoutedEventHandler(Button_Click_CreateGame);
            menu.btnJoinGame.Click += new RoutedEventHandler(Button_Click_SearchToJoin);
            menu.btnSpectateGame.Click += new RoutedEventHandler(Button_Click_SpectateGame);
            menu.btnWatchReplayes.Click += new RoutedEventHandler(Button_Click_WatchReplays);
            this.Content = menu;
            
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
           
            ProfileWindow profile = new ProfileWindow();
            profile.Show();
            this.Close();


        }

        private void Button_Click_CreateGame(object sender, RoutedEventArgs e)
        {

           CreateGame createGame = new CreateGame();
           createGame.Show();
           this.Close();


        }


        private void Button_Click_SearchToJoin(object sender, RoutedEventArgs e)
        {

            SearchToJoinWindow SearchToJoin = new SearchToJoinWindow();
            SearchToJoin.Show();
            this.Close();


        }

        private void Button_Click_SpectateGame(object sender, RoutedEventArgs e)
        {

            SearchToSpectateWindow searchToSpectate = new SearchToSpectateWindow();
            searchToSpectate.Show();
            this.Close();


        }

        private void Button_Click_WatchReplays(object sender, RoutedEventArgs e)
        {

            WatchReplayesWindow watchReplays = new WatchReplayesWindow();
            watchReplays.Show();
            this.Close();


        }


    }
}
