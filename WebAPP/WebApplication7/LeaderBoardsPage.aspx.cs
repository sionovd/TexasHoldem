using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class LeaderBoardsPage : System.Web.UI.Page
    {
        List<PlayerLeader> leader = new List<PlayerLeader>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataListLeader.DataSource = leader;
            DataListLeader.DataBind();
            
        }

        protected async void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReplyListString res;
            
            if (DropDownList1.SelectedItem.Text.Equals("Gross profit"))
            {
                res = await Client.Get20TopTotalGrossProfit();
            }
            else if (DropDownList1.SelectedItem.Text.Equals("Higest cash per game"))
                res = await Client.Get20TopHighestCashInGame();
            else if (DropDownList1.SelectedItem.Text.Equals("Number of games played"))
                res = await Client.Get20TopAmountOfGames();
            else
                res = new ReplyListString(false,null, null);
            if (res.Sucsses)
            {
                DataListLeader.Visible = true;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<string> todes = res.ListStringContent;
                foreach (string s in todes)
                {
                    leader.Add(serializer.Deserialize<PlayerLeader>(s));
                }
                DataListLeader.DataBind();
            }
            else
                DataListLeader.Visible = false;
        }
    }
}