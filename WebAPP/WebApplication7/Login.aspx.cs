using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected async void Send_Button_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            Reply ans = await Client.Login(username.Text, password.Text.ToString());
            if (ans.Sucsses)
            {
             
                Session[user] = user;
                username.Text = "";
                password.Text = "";
                FormsAuthentication.RedirectFromLoginPage(user, true);
            }
            else
            {
                errorLogin.Visible = true;
            }
        }
    }
}