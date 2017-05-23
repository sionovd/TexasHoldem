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
    /// Interaction logic for SpectateGameWindow.xaml
    /// </summary>
    public partial class SpectateGameWindow : Window
    {
        public SpectateGameWindow()
        {
            InitializeComponent();
            UserControlSpectateGame spectateGame = new UserControlSpectateGame();
            spectateGame.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            this.Content = spectateGame;
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            SearchToSpectateWindow searchToSpectate = new SearchToSpectateWindow();
            searchToSpectate.Show();
            this.Close();
        }
    }
}
