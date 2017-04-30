using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public class Game
    {

        public Game(int gameID)
        {
            //this = gameCenter.getGame(gameID);
        }

        private static int counter = 0;
        private int id;
        private GamePreferences pref;
        private Player[] sits;
        private List<Spectator> spectators;
        private Deck cards;
        private int pot;
        private Card[] tableCards;
        private System.Object lockThis = new System.Object();
        private int numOfPlayers;    // players that sits

        public Game(GamePreferences pref)
        {
            counter++;
            id = counter;
            this.pref = pref;
            sits = new Player[pref.MaxPlayers];
            spectators = new List<Spectator>();
            tableCards = new Card[5];
            cards = new Deck();
            pot = 0;
            numOfPlayers = 0;
        }

        public Player GetPlayerById(int playerID)
        {
            foreach (Player player in sits)
            {
                if (player != null && player.PlayerId == playerID)
                    return player;
            }
            return null;
        }

        public bool RemovePlayer(Player player)
        {
            for (int i = 0; i < sits.Length; i++)
                if (sits[i] != null && sits[i].PlayerId == player.PlayerId)
                {
                    sits[i] = null;
                    player.GetUp();
                    return true;
                }
            return false;
        }

        public Player AddPlayer(User user)
        {
            if (numOfPlayers == pref.MaxPlayers)
                throw new FullTableException();
            Player p;
            if (pref.ChipPolicy == 0)
            {
                if (user.getmoneyBalance() < pref.BuyIn + pref.MinBet)
                    throw new notEnoughMoneyException(user.getmoneyBalance().ToString(), pref.BuyIn.ToString());
                int m = user.decreaseMoney(pref.BuyIn);
                p = new Player(m, user.getUsername());
                p.TakeSit(AddPlayerToSit(p));
                numOfPlayers++;
                return p;
            }
            p = new Player(pref.ChipPolicy, user.getUsername());
            p.TakeSit(AddPlayerToSit(p));
            numOfPlayers++;
            return p;
        }

        private int AddPlayerToSit(Player player)
        {
            for (int i = 0; i < sits.Length; i++)
                if (sits[i] == null)
                {
                    sits[i] = player;
                    return i;
                }
            return -1;
        }

        public Spectator AddSpectatingPlayer(User user)
        {
            if(!pref.SpectateGame)
                throw new DomainException("game not spectatable");
            if(IsSpectatorExist(user.getUsername()))
                throw new DomainException("the user " + user + " is already watching this game");
            Spectator spec = new Spectator(user.getUsername());
            spectators.Add(spec);
            return spec;
        }


        public bool RemoveSpectatingPlayer(Spectator spectator)
        {
            foreach (Spectator spec in spectators)
                if (spec.Id == spectator.Id)
                {
                    spectators.Remove(spec);
                    return true;
                }
            return false;
        }


        public bool IsSpectatorExist(Spectator spec)
        {
            foreach (Spectator s in spectators)
                if (s.Id == spec.Id)
                    return true;
            return false;
        }

        public bool IsSpectatorExist(string name)
        {
            foreach (Spectator s in spectators)
                if (s.Name.Equals(name))
                    return true;
            return false;
        }

        public bool IsPlayerExist(Player player)
        {
            foreach (Player p in sits)
                if (p != null && p.PlayerId == player.PlayerId)
                    return true;
            return false;
        }


        public bool IsPlayerExist(string name)
        {
            foreach (Player p in sits)
                if (p != null && p.Name.Equals(name))
                    return true;
            return false;
        }

        public bool Bet(Player player, int amount)
        {
            //TODO
            return true;
        }
        public bool Call(Player player)
        {
            //TODO
            return true;
        }
        public bool Check(Player player)
        {
            //TODO
            return true;
        }

        public bool Fold(Player player)
        {
            //TODO
            return true;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public GamePreferences Pref
        {
            get
            {
                return pref;
            }

            set
            {
                pref = value;
            }
        }

        public Player[] Sits
        {
            get
            {
                return sits;
            }
        }

        public Deck Cards
        {
            get
            {
                return cards;
            }
            set
            {
                cards = value;
            }
        }

        public int Pot
        {
            get
            {
                return pot;
            }
            set
            {
                pot = value;
            }
        }

    }
}
