using System;
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
            myHub.On<string>("particularMessage", message => Console.WriteLine(message));
           
            /*
                MORE METHODS...
            */
        }

        public static async void sendMessage(IHubProxy h, string message, int tableId)
        {
            await h.Invoke("chat", message, tableId);
        }

        public static HubConnection connection()
        {
            var context = SynchronizationContext.Current;
            var querystringData = new Dictionary<string, string>();
            querystringData.Add("id", "anik");
            var connection = new HubConnection("http://localhost:53133/signalr", querystringData);  // the address we eant to connect
            IHubProxy myHub = connection.CreateHubProxy("ServerHub");    // the name of the hub we want to
            apiConfigure(myHub);
            connection.Start();
            return connection;
        }


        private static void Main(string[] args)
        {
            HubConnection con;
            con=connection();
            Console.ReadLine();
            disconnect(con);
        }
        
    }
}
