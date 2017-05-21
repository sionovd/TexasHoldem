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
    /// Interaction logic for JoinGameWindow.xaml
    /// </summary>
    public partial class JoinGameWindow : Window
    {
        public JoinGameWindow()
        {
            InitializeComponent();
            UserControlJoinGame joinGame = new UserControlJoinGame();
            joinGame.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            this.Content = joinGame;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {

            SearchToJoinWindow searchToJoin = new SearchToJoinWindow();
            searchToJoin.Show();
            this.Close();
        }

    }
}
