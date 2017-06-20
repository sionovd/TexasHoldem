﻿using System.Collections.Generic;
using Domain.GameLogInfo;
using Domain.GameModule;

namespace Domain
{
    public class GameLog
    {
        private List<string> logOfCards;
        private Game game;
        public List<string> LogOfGameStates { get; }
        public int GameID { get; }
        public string LatestAction { get; private set; }
        public bool IsSplitPot { get; private set; }
        public GameLog(Game game)
        {
            //this = database.getGameLog(gameLogID);
            this.game = game;
            logOfCards = new List<string>();
            LogOfGameStates = new List<string>();
            GameID = game.Id;
        }

        public void LogPlayerCards(Player player, Card[] cards)
        {
            PlayerCardsInfo pci = new PlayerCardsInfo(cards[0].getCardId(), cards[1].getCardId(), game.Id, player.PlayerId, player.Username);
            string str = PlayerCardsInfo.ConvertToString(pci);
            LatestAction = str;
            logOfCards.Add(str);
            game.Subject.NotifyCards(player.Username);
        }

        public void LogEndGame(bool onePlayerLeft, bool isSplitPot)
        {
            IsSplitPot = isSplitPot;
            CardType[] communityCards = new CardType[5];
            for (int i = 0; i < 5; i++)
            {
                if (game.State.TableCards[i] != null)
                    communityCards[i] = game.State.TableCards[i].getCardId();
            }
            List<PlayerCardsInfo> playersCards = new List<PlayerCardsInfo>();
            foreach (var player in game.Seats)
            {
                if(!player.Folded)
                    playersCards.Add(new PlayerCardsInfo(player.Cards[0].getCardId(), player.Cards[1].getCardId(), game.Id, player.PlayerId, player.Username));
            }
            EndGameInfo endGameInfo = new EndGameInfo(game.Id, isSplitPot,game.Winner.Username, playersCards, communityCards,
                onePlayerLeft);
            string str = EndGameInfo.ConvertToString(endGameInfo);
            LatestAction = str;
            game.Subject.NotifyEndGame();
        }

        public void LogGameState()
        {
            CardType[] tableCards = new CardType[5];
            for (int i = 0; i < 5; i++)
            {   
                if(game.State.TableCards[i] != null)
                    tableCards[i] = game.State.TableCards[i].getCardId();
            }
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();
            foreach (var player in game.Seats)
            {
                playerInfos.Add(new PlayerInfo(player.PlayerId, player.Username, player.ChipBalance, player.AmountBetOnCurrentRound, player.Folded));
            }
            GameInfo gameInfo = new GameInfo(game.Id, game.State.Pot, game.State.CurrentStake, game.State.RoundNumber, game.State.CurrentPlayer.PlayerId, playerInfos, tableCards, game.State.SmallBlind.PlayerId, game.State.BigBlind.PlayerId);
            string str = GameInfo.ConvertToString(gameInfo);
            LogOfGameStates.Add(str);
            LatestAction = str;
            game.Subject.NotifyGameState();
        }

        
    }
}