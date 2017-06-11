﻿using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;


namespace Communication
{
    class signalRClient
    {
        
        // this method make the query to send while connection established 
        private static void queryStringByUserName(Dictionary<string, string> query)
        {
            query.Add("id", "anik");
        }

        // this method for disconnect normally from server hub.
        public static void disconnect(HubConnection con)
        {
            con.Dispose();
        }

        // this method include all the methods the client expose to the server
        private static void apiConfigure(IHubProxy myHub)
        {   // at future will send to method that print message at the suitable table
            myHub.On<string,int>("chatMessage", (message,tableNumber) => Console.WriteLine(message));
            // at future will pop-up message
            myHub.On<string>("updateCards", message => ReceiveCards(message));
            myHub.On<string>("updateGameState", message => ReceiveGameInfo(message));
            myHub.On<string>("endGame", message => ReceiveWinner(message));
            /*
                MORE METHODS...
            */
        }

        static void ReceiveCards(string content)
        {
            Receiver.GetReceiver().UpdatePlayerCardsInfo(content);
        }

        static void ReceiveGameInfo(string content)
        {
            Receiver.GetReceiver().UpdateGameInfo(content);
        }

        static void ReceiveWinner(string content)
        {
            Receiver.GetReceiver().UpdateEndGameInfo(content);
        }

        public static async void sendMessage(IHubProxy h, string message, int tableId)
        {
            await h.Invoke("chat", message, tableId);
        }

        public static HubConnection connection(string username)
        {
            var context = SynchronizationContext.Current;
            var querystringData = new Dictionary<string, string>();
            querystringData.Add("id", username);
            var connection = new HubConnection("http://texasholdem1.azurewebsites.net/signalr", querystringData);  // the address we eant to connect
            IHubProxy myHub = connection.CreateHubProxy("ServerHub");    // the name of the hub we want to
            apiConfigure(myHub);
            connection.Start();
            return connection;
        }
        
    }
}
