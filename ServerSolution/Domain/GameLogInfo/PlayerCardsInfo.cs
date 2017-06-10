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

        public PlayerCardsInfo() { }

        public PlayerCardsInfo(CardType first, CardType second, int gameID, int playerID)
        {
            PlayerCards = new CardType[2];
            PlayerCards[0] = first;
            PlayerCards[1] = second;
            GameID = gameID;
            PlayerID = playerID;
        }

        public static string ConvertToString(PlayerCardsInfo pci)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(pci);
        }

    }
}
