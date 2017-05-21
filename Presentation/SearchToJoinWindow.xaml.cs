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
    /// Interaction logic for SearchToJoinWindow.xaml
    /// </summary>
    public partial class SearchToJoinWindow : Window
    {
        public SearchToJoinWindow()
        {
            InitializeComponent();
            UserControlSearchToJoin sraechToJoin = new UserControlSearchToJoin();
            sraechToJoin.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            sraechToJoin.btnSearch.Click += new RoutedEventHandler(Button_Click_Search);
            this.Content = sraechToJoin;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {

            JoinGameWindow joinGame = new JoinGameWindow();
            joinGame.Show();
            this.Close();
        }
    }
}
