using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Domain.GameModule;

namespace Domain.GameLogInfo
{

   
    public class PlayerCardsInfo
    {
        public CardType[] PlayerCards { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public string Username { get; set; }

        public PlayerCardsInfo() { }

        public PlayerCardsInfo(CardType first, CardType second, int gameID, int playerID, string username)
        {
            PlayerCards = new CardType[2];
            PlayerCards[0] = first;
            PlayerCards[1] = second;
            GameID = gameID;
            PlayerID = playerID;
            Username = username;
        }

        public static string ConvertToString(PlayerCardsInfo pci)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(pci);
        }

    }
}
