using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Model;

namespace Test.View
{
    public partial class CardList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCard();
        }

        protected async System.Threading.Tasks.Task GetCard()
        {

            List<Cards> cardList = new List<Cards>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Cards/GetCards";
            var response = client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            cardList = JsonConvert.DeserializeObject<List<Cards>>(result);

            //Console.WriteLine(reservationList);
            GridView1.DataSource = cardList;
            GridView1.DataBind();

        }

        
    }
}