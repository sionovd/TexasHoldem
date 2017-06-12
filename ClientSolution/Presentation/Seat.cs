using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using Image = System.Windows.Controls.Image;

namespace Presentation
{
   public class Seat
   {
       public int PlayerID { get; set; } 
       public bool IsActive { get; set; } 
       public Image Blind { get; set; }
       public TextBlock Username { get; set;}
       public TextBlock Chips { get; set; }
       public TextBlock Bet { get; set; }

       public Seat(Image blind, TextBlock username, TextBlock chips, TextBlock bet)
       {
           Blind = blind;
           Username = username;
           Chips = chips;
           Bet = bet;
           IsActive = false;
           this.Hidden();

       }

       public void TakeSeat(string username, int playerID)
       {
           
           Username.Text = username;
           PlayerID = playerID;
           Visible();
           IsActive = true;
       }

       public void UpdateState(int chips ,int bet)
       {
           
               Chips.Text = "Chips: " + chips;
               Bet.Text = "Bet: " + bet;

       }


       private void Hidden()
       {
           Blind.Visibility = Visibility.Hidden;
           Username.Visibility =  Visibility.Hidden;
           Chips.Visibility = Visibility.Hidden;
           Bet.Visibility = Visibility.Hidden;

       }

       private void Visible()
       {
           Blind.Visibility = Visibility.Visible;
           Username.Visibility = Visibility.Visible;
           Chips.Visibility = Visibility.Visible;
           Bet.Visibility = Visibility.Visible;

       }

       private void ChangeColor(Brush brush)
       {
           Username.Background = brush;
           Chips.Background = brush;
           Bet.Background = brush;
       }

       public void Fold()
       {
           this.ChangeColor(Brushes.DarkSlateGray);
           Bet.Text = "";
           Username.Foreground = Brushes.White;
           Chips.Foreground = Brushes.White;
           IsActive = false;
       }

       public void NowTurn()
       {
           this.ChangeColor(Brushes.LightGreen);
       }

       public void WaitToTurn()
       {
           this.ChangeColor(Brushes.DarkSalmon);
       }

        public void LeaveRoom()
       {
           Blind.Visibility = Visibility.Hidden;
           Username.Visibility = Visibility.Hidden;
           Chips.Visibility = Visibility.Hidden;
           Bet.Visibility = Visibility.Hidden;
           IsActive = false;
       }

    }
}
