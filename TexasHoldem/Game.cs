﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class Game
    {

        public Game(int gameID)
        {
            //this = gameCenter.getGame(gameID);
        }

        private static int counter = 0;
        private int id;
        private GamePreferences pref; 
        private List<Player> sits; 
        private Deck cards; 
        private int pot;
        private Card[] tableCards;
        private System.Object lockThis = new System.Object();


        public Game(GamePreferences pref)
        {
            counter++;
            id = counter;
            this.pref = pref;
            sits = new List<Player>();
            tableCards = new Card[5];
            cards = new Deck();
            pot = 0;
        }

        public Player AddPlayer(User user)
        {
            if(sits.Count() >= pref.MaxPlayers)
                throw new FullTableException();
            Player p;
            if (pref.ChipPolicy == 0)
            {
                if (user.getmoneyBalance() < pref.BuyIn + pref.MinBet)
                    throw new notEnoughMoneyException(user.getmoneyBalance().ToString(), pref.BuyIn.ToString());
                int m = user.decreaseMoney(pref.BuyIn);
                user.decreaseMoney(m);
                p = new Player(m, user.getUsername());
                sits.Add(p);
                return p;
            }
            p = new Player(pref.ChipPolicy, user.getUsername());
            sits.Add(p);
            return p;
        }

        public bool IsPlayerExist(string name)
        {
            foreach (Player p in sits)
                if (p.Name.Equals(name))
                    return true;
            return false;
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

        public List<Player> Sits
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
