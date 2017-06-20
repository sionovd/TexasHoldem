using System.Collections.Generic;
using System.Web.Script.Serialization;
using Domain.GameModule;

namespace Domain.GameLogInfo
{
    public class EndGameInfo
    {
        public int GameID { get; set; }
        public bool IsSplitPot { get; set; }
        public string UsernameWinner { get; set; }
        public List<PlayerCardsInfo> PlayersCards { get; set; }
        public CardType[] CommunityCards { get; set; }
        public bool OnePlayerLeft { get; set; }

        public EndGameInfo()
        {

        }

        public EndGameInfo(string content)
        {
            EndGameInfo endGameInfo = new JavaScriptSerializer().Deserialize<EndGameInfo>(content);
            GameID = endGameInfo.GameID;
            IsSplitPot = endGameInfo.IsSplitPot;
            UsernameWinner = endGameInfo.UsernameWinner;
            PlayersCards = endGameInfo.PlayersCards;
            CommunityCards = endGameInfo.CommunityCards;
            OnePlayerLeft = endGameInfo.OnePlayerLeft;
        }
        public EndGameInfo(int gameID, bool isSplitPot ,string usernameWinner, List<PlayerCardsInfo> playersCards, CardType[] communityCards, bool onePlayerLeft)
        {
            GameID = gameID;
            IsSplitPot = isSplitPot;
            UsernameWinner = usernameWinner;
            PlayersCards = playersCards;
            CommunityCards = communityCards;
            OnePlayerLeft = onePlayerLeft;

        }

        public static string ConvertToString(EndGameInfo endGameInfo)
        {
            return new JavaScriptSerializer().Serialize(endGameInfo);
        }
    }


}
