using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class StatisticsPage : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                char[] delimiterChars = {',' };
                ReplyString rep= await Client.GetUserStats(Context.User.Identity.Name);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Statistics a = serializer.Deserialize<Statistics>(rep.StringContent);
                pointsLabel.Text = a.Points.ToString();
                numberOfGamesLabel.Text = a.NumOfGames.ToString();
                totalProfitLabel.Text = a.TotalGrossProfit.ToString();
                HighestCashGainLabel.Text = a.HighestCashGain.ToString();
                AverageProfitLabel.Text = a.AvgGrossProfit.ToString(); 
                AverageCashGainLabel.Text = a.AvgCashGain.ToString();
            }
        }
    }
}