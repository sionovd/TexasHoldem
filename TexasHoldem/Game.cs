using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class Game
    {
        private static int id=0; 
        private GamePreferences pref; 
        private Player[] sits; 
        private Deck cards; 
        private int pot;
        private Card[] tableCards;

    

        public Game(GamePreferences pref)
        {
            id++;
            this.pref = pref;
            sits = new Player[pref.MaxPlayers];
            tableCards = new Card[5];
            cards = new Deck();
            pot = 0;
        }

        public Player addPlayer(User user)
        {
            //TODO
            return null;
        }

        public bool Bet(Player player,int amount)
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

        internal GamePreferences Pref
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

        /*int getTurn();

        void setMinimumBet(int bet);
        int getMinimumBet();

        void setMinimumPlayers(int num);

        void check(Player player);

        void leaveGame(Player player, int userID);

        void allIn(Player player);



        void setMaximumPlayers(int num);

        void setChipNum(int num);

        int getMaxPlayers();

        int getMinPlayers();

        int getChips();

        int getBuyIn();

        int getId();

        void publishMessage(String msg, Player player);

        boolean isPlayerInGame(String name);

        boolean join(Player player) throws NoMutchMany;

        int getPot();

        boolean spectaAble();



        int getPlayersNum();

        void terminateGame();

        void startGame();


        boolean inMax();

        String getType();

        Hashtable<String, ArrayList<String>> getAllTurnsByAllPlayers();

        void endTurn(Player player);

        void endRound();

        ArrayList<String> getAllTurnsOfPlayer(Player p, ArrayList<String> allTurns);

        void spectateGame(User user);

        void raise(int amount, Player player) throws NotAllowedNumHigh;

        void fold(Player player);

        void win(Player player);

        void dealCard(Player player);

        void bet(int amount, Player player);

        void call(int amount, Player player);

        boolean isLocked();

        Player findPlayer(User usr);

        boolean canJoin(User user);
        */
    }
}
