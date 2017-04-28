﻿using System;
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
        private System.Object lockThis = new System.Object();


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
            Player p;
            if (pref.ChipPolicy == 0)
            {
                if (user.getmoneyBalance() < pref.BuyIn + pref.MinBet)
                    throw new notEnoughMoneyException(user.getmoneyBalance().ToString(), pref.BuyIn.ToString());
                int m = user.decreaseMoney(pref.BuyIn);
                user.decreaseMoney(m);
                p = new Player(m, user.getUsername());
                return p;
            }
            else
                p = new Player(pref.ChipPolicy, user.getUsername());
            return p;
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
        
    }
}
