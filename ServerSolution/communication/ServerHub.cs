using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace communication
{
    public class ServerHub : Hub
    {
        private static ServerHub serverHub;

        private ServerHub(){}

        public static ServerHub GetInstance
        {
            get
            {
                if (serverHub == null)
                    serverHub = new ServerHub();
                return serverHub;
            }
        }

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
            if (stopCalled == true)
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
        internal void addPlayerToTableCom(string username,int tableId)
        {
            int index=uList.FindIndex(user => user.UserName == username);
            Groups.Add(uList[index].ConnectionID, tableId.ToString());
            allObservers.Add(new ClientObserver(username, tableId));
        }

        internal void removePlayerFromTableCom(string username, int tableId)
        {
            int index = uList.FindIndex(user => user.UserName == username);
            Groups.Remove(uList[index].ConnectionID, tableId.ToString());
            foreach (var o in allObservers)
            {
                if (o.Username == username)
                    o.Unsubscribe();
            }
        }

        internal void sendMessageToUser(string username,string message)
        {
            var user = uList.Where(u => u.UserName == username);
            if(user.Any())
                Clients.Client(user.First().ConnectionID).particularMessage(message);
        }
        
    }
}