using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Context.User.Identity.IsAuthenticated)
            {
                usernameWelcome.Text = "Guest";
                Log_Out.Visible = false;
            }
            else
            {
                Log_Out.Visible = true;
                usernameWelcome.Text = Context.User.Identity.Name;
            }               
         
        }

        protected async void Log_Out_Click(object sender, EventArgs e)
        {
            Reply reply = await Client.Logout(Context.User.Identity.Name);
            if (reply.Sucsses)
            {
                usernameWelcome.Text = "";
                Log_Out.Visible = false;
                FormsAuthentication.SignOut();
                Session.Remove(Context.User.Identity.Name);
                Context.Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}