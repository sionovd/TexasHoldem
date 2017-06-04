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
        {
            myHub.On<string>("chatMessage", message => Console.WriteLine(message));

            /*
                MORE METHODS...
            */
        }

        public static async void sendMessage(IHubProxy h, string message)
        {
            await h.Invoke("chat", message);
        }

        public static void connection()
        {
            var context = SynchronizationContext.Current;
            var querystringData = new Dictionary<string, string>();
            queryStringByUserName(querystringData);
            var connection = new HubConnection("http://localhost:29939/signalr", querystringData);  // the address we want to connect
            IHubProxy myHub = connection.CreateHubProxy("myHub");    // the name of the hub we want to
            apiConfigure(myHub);
            connection.Start().Wait(); // not sure if you need this if you are simply posting to the hub
            
            /*
                from this point the connection established and the client ready to get and send messages
            */
        }




        /*  await myHub.Invoke("Announce", "pizza");*/// invoke the hub we want to








        /*   static void Main(string[] args)
           {
               ex();
               Console.ReadLine();
           }*/
    }
}
