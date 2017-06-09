using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Presentation
{
    public static class GUICards
    {
        public static readonly Dictionary<CardType, string> PATHS = new Dictionary<CardType, string>()
        {
            { CardType.HeartTwo, "images\\cards\\Heart\\Two.png"}, { CardType.DiamondTwo, "images\\cards\\Diamond\\Two.png"}, {CardType.SpadesTwo, "images\\cards\\Spade\\Two.png"}, { CardType.ClubsTwo, "images\\cards\\Club\\Two.png"},
            { CardType.HeartThree, "images\\cards\\Heart\\Three.png"}, { CardType.DiamondThree, "images\\cards\\Diamond\\Three.png"}, {CardType.SpadesThree, "images\\cards\\Spade\\Three.png"}, { CardType.ClubsThree, "images\\cards\\Club\\Three.png"},
            { CardType.HeartFour, "images\\cards\\Heart\\Four.png"}, { CardType.DiamondFour, "images\\cards\\Diamond\\Four.png"}, {CardType.SpadesFour, "images\\cards\\Spade\\Four.png"}, { CardType.ClubsFour, "images\\cards\\Club\\Four.png"},
            { CardType.HeartFive, "images\\cards\\Heart\\Five.png"}, { CardType.DiamondFive, "images\\cards\\Diamond\\Five.png"}, {CardType.SpadesFive, "images\\cards\\Spade\\Five.png"}, { CardType.ClubsFive, "images\\cards\\Club\\Five.png"},
            { CardType.HeartSix, "images\\cards\\Heart\\Six.png"}, { CardType.DiamondSix, "images\\cards\\Diamond\\Six.png"}, {CardType.SpadesSix, "images\\cards\\Spade\\Six.png"}, { CardType.ClubsSix, "images\\cards\\Club\\Six.png"},
            { CardType.HeartSeven, "images\\cards\\Heart\\Seven.png"}, { CardType.DiamondSeven, "images\\cards\\Diamond\\Seven.png"}, {CardType.SpadesSeven, "images\\cards\\Spade\\Seven.png"}, { CardType.ClubsSeven, "images\\cards\\Club\\Seven.png"},
            { CardType.HeartEight, "images\\cards\\Heart\\Eight.png"}, { CardType.DiamondEight, "images\\cards\\Diamond\\Eight.png"}, {CardType.SpadesEight, "images\\cards\\Spade\\Eight.png"}, { CardType.ClubsEight, "images\\cards\\Club\\Eight.png"},
            { CardType.HeartNine, "images\\cards\\Heart\\Nine.png"}, { CardType.DiamondNine, "images\\cards\\Diamond\\Nine.png"}, {CardType.SpadesNine, "images\\cards\\Spade\\Nine.png"}, { CardType.ClubsNine, "images\\cards\\Club\\Nine.png"},
            { CardType.HeartTen, "images\\cards\\Heart\\Ten.png"}, { CardType.DiamondTen, "images\\cards\\Diamond\\Ten.png"}, {CardType.SpadesTen, "images\\cards\\Spade\\Ten.png"}, { CardType.ClubsTen, "images\\cards\\Club\\Ten.png"},
            { CardType.HeartJack, "images\\cards\\Heart\\Jack.png"}, { CardType.DiamondJack, "images\\cards\\Diamond\\Jack.png"}, {CardType.SpadesJack, "images\\cards\\Spade\\Jack.png"}, { CardType.ClubsJack, "images\\cards\\Club\\Jack.png"},
            { CardType.HeartQueen, "images\\cards\\Heart\\Queen.png"}, { CardType.DiamondQueen, "images\\cards\\Diamond\\Queen.png"}, {CardType.SpadesQueen, "images\\cards\\Spade\\Queen.png"}, { CardType.ClubsQueen, "images\\cards\\Club\\Queen.png"},
            { CardType.HeartKing, "images\\cards\\Heart\\King.png"}, { CardType.DiamondKing, "images\\cards\\Diamond\\King.png"}, {CardType.SpadesKing, "images\\cards\\Spade\\King.png"}, { CardType.ClubsKing, "images\\cards\\Club\\King.png"},
            { CardType.HeartAce, "images\\cards\\Heart\\Ace.png"}, { CardType.DiamondAce, "images\\cards\\Diamond\\Ace.png"}, {CardType.SpadesAce, "images\\cards\\Spade\\Ace.png"}, { CardType.ClubsAce, "images\\cards\\Club\\Ace.png"},
        };

        public static BitmapImage GetImageSource(CardType cardType)
        {
            string uriString = "pack://application:,,,/Presentation;component/" + GUICards.PATHS[cardType];
            Uri uriSource = new Uri(uriString);
            return new BitmapImage(uriSource);
        }

       
    }
}
