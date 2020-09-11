using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Common;
using Test.Model;

namespace Test.View
{
    public partial class InboxHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InboxData();
        }



        public void InboxData()
        {
            List<InboxModel> reservationList = new List<InboxModel>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/LogReceives/GetInboxData";

            var inbox = new InboxModel();
            inbox.User_ID = Convert.ToInt64(Session["User_ID"]);

            var json = JsonConvert.SerializeObject(inbox);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<InboxModel>>(result);

            GridView1.DataSource = reservationList;
            GridView1.DataBind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            DataCommon.Sender_Name = GridView1.SelectedRow.Cells[0].Text;
            DataCommon.Sender_Department = GridView1.SelectedRow.Cells[1].Text;
            GridView1.Columns[13].Visible = true;
            DataCommon.Card_Style = GridView1.SelectedRow.Cells[13].Text;
            Label1.Text = DataCommon.Card_Style;
            //Label2.Text = DataCommon.Sender_Department;
            Response.Redirect("InboxView.aspx");
        }
    }
}