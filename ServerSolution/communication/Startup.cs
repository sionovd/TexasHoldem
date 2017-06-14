using communication;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace communication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/signalr", new HubConfiguration());
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
            //ConfigureAuth(app);
        }
    }
}