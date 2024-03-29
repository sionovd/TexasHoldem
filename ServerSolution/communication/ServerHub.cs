﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace communication
{
    public class ServerHub : Hub
    {

        //uList is a list of UserConnection, each userConnection has userName(unique) and ConnectionId
        static List<UserConnection> uList = new List<UserConnection>();
        static List<ClientObserver> allObservers = new List<ClientObserver>();

        /*
        THIS METHODS OVERRIDE FROM Hub
        OnConnected- add connected user to uList
        OnDisconnected- remove connected user from uList
        OnReconnected- doesn't implemented.

        context is the current client
        */

        public override Task OnConnected()
        {
            var us = new UserConnection();
            us.UserName = Context.QueryString["id"];
            us.ConnectionID = Context.ConnectionId;
            uList.Add(us);
            /*Groups.Add(Context.ConnectionId, 1.ToString());
            Groups.Add(Context.ConnectionId, 1.ToString()+"chat");*/
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                uList.RemoveAt(uList.FindIndex(o => o.UserName == Context.QueryString["id"]));
                //it's auto remove connectionId from all groups.
            }
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        /*
        THIS METHODS THE SERVER EXPOSE TO THE CLIENTS
        */
        public void chat(string message,int tableId)
        {
            Clients.Group(tableId.ToString(),message).chatMessage(message,tableId);
        }

        /*
        THIS METHODS CALLS FROM SERVER TO MANAGE THE HUB
        */
        internal static void addPlayerToTableCom(string username,int tableId)
        {
            allObservers.Add(new ClientObserver(username, tableId));
        }

        internal static void removePlayerFromTableCom(string username, int tableId)
        {
            foreach (var o in allObservers)
            {
                if (o.Username == username)
                    o.Unsubscribe();
            }
        }

        internal static void sendMessageToUser(string senderUsername, string receiverUsername, string message, int gameID)
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            var user = uList.Where(u => u.UserName == receiverUsername);
            if (user.Any())
                ctx.Clients.Client(user.First().ConnectionID).updateMessage(senderUsername, message, gameID);
        }

        internal static void sendWhisperToUser(string senderUsername, string receiverUsername, string whisper, int gameID)
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            var sourceUser = uList.Where(u => u.UserName == senderUsername);
            if (sourceUser.Any())
                ctx.Clients.Client(sourceUser.First().ConnectionID).updateWhisper(senderUsername, whisper, gameID);
            var destUser = uList.Where(u => u.UserName == receiverUsername);
            if (destUser.Any())
                ctx.Clients.Client(destUser.First().ConnectionID).updateWhisper(senderUsername, whisper, gameID);
        }

        internal static void sendCardsToUser(string username,string message)
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            var user = uList.Where(u => u.UserName == username);
            if(user.Any())
                ctx.Clients.Client(user.First().ConnectionID).updateCards(message);
        }

        internal static void sendGameInfoToUser(string username, string message)
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            var user = uList.Where(u => u.UserName == username);
            if (user.Any())
                ctx.Clients.Client(user.First().ConnectionID).updateGameState(message);
        }

        internal static void sendEndGameToUser(string username, string message)
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            var user = uList.Where(u => u.UserName == username);
            if (user.Any())
                ctx.Clients.Client(user.First().ConnectionID).endGame(message);
        }

    }
}