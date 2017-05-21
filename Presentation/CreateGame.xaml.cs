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
    /// Interaction logic for CreateGame.xaml
    /// </summary>
    public partial class CreateGame : Window
    {
        public CreateGame()
        {
            InitializeComponent();
            UserControlCreateGame createGame = new UserControlCreateGame();
            createGame.btnBack.Click += new RoutedEventHandler(Button_Click_Back);
            this.Content = createGame;

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }


       
    }
}
