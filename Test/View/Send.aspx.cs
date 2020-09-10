using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Model;

namespace Test.View
{
    public partial class Send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SendData();
        }

        public void SendData()
        {
            List<SendModel> reservationList = new List<SendModel>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/LogSends/GetSendData";

            var send = new SendModel();
            send.User_ID = Convert.ToInt64(Session["User_ID"]);

            var json = JsonConvert.SerializeObject(send);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<SendModel>>(result);

            GridView1.DataSource = reservationList;
            GridView1.DataBind();

        }
    }
}