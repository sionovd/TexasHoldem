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
    /// Interaction logic for SearchToSpectateWindow.xaml
    /// </summary>
    public partial class SearchToSpectateWindow : Window
    {
        public SearchToSpectateWindow()
        {
            InitializeComponent();
            UserControlSearchToSpectate searchToSpectate = new UserControlSearchToSpectate();
            searchToSpectate.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            searchToSpectate.btnSearch.Click += new RoutedEventHandler(Button_Click_Search);
            this.Content = searchToSpectate;
        }




        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {

            SpectateGameWindow spectateGame = new SpectateGameWindow();
            spectateGame.Show();
            this.Close();
        }
    }
}
