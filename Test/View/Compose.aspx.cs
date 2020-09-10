using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Common;
using Test.Model;

namespace Test.View
{
    public partial class Compose : System.Web.UI.Page
    {
        string deptid = "";
        string username = "";
        string resID = "";
        List<Cards> cards = new List<Cards>();
        string cardID;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["User_Name"].ToString();

            lblSender.Text = username + " From  " + DataCommon.LoginDeptName;
            if (!IsPostBack)
            {
                GetDepartment();
                GetCard();
            }
        }
        

        protected async System.Threading.Tasks.Task GetDepartment()
        {
            List<Departments> reservationList = new List<Departments>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Departments/GetDepartments";
            var response = client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<Departments>>(result);

            //Console.WriteLine(reservationList);
            ddlDept.Items
           .AddRange(reservationList
            .Select(p => new ListItem()
            {
                Text = p.Department_Name
               ,
                Value = p.Department_ID.ToString()

            }).ToArray());
        }

        //protected async System.Threading.Tasks.Task GetUserByDept()
        //{
        //    List<Users> reservationList = new List<Users>();
        //    HttpClient client = new HttpClient();
        //    string url = "https://localhost:44334/api/Users/GetUserByDept";

        //    var d = new Departments();
        //    d.Department_Name = deptname;            

        //    var json = JsonConvert.SerializeObject(d);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = client.PostAsync(url,data).Result;

        //    string result = response.Content.ReadAsStringAsync().Result;
        //    reservationList = JsonConvert.DeserializeObject<List<Users>>(result);

        //    //Console.WriteLine(reservationList);
        //    ddlUser.Items.Clear();
        //    ddlUser.Items
        //   .AddRange(reservationList
        //    .Select(p => new ListItem()
        //    {
        //        Text = p.User_Name
        //       ,
        //        Value = p.User_ID.ToString()

        //    }).ToArray());

        //   // var img = reservationList.
        //}

        protected async System.Threading.Tasks.Task GetUserByDept()
        {
            List<Users> reservationList = new List<Users>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Users/GetUserByDept";

            var u = new Users();
            u.Department_ID = Convert.ToInt64(deptid);
            u.User_Name = Session["User_Name"].ToString();

            var json = JsonConvert.SerializeObject(u);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<Users>>(result);

            //Console.WriteLine(reservationList);
            ddlUser.Items.Clear();
            ddlUser.Items
           .AddRange(reservationList
            .Select(p => new ListItem()
            {
                Text = p.User_Name
               ,
                Value = p.User_ID.ToString()

            }).ToArray());

            // var img = reservationList.
        }

        protected async System.Threading.Tasks.Task GetCard()
        {
            List<Cards> reservationList = new List<Cards>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Cards/GetCards";

            var response = client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<Cards>>(result);

            //Console.WriteLine(reservationList);
            ddlCard.Items
           .AddRange(reservationList
            .Select(p => new ListItem()
            {
                Text = p.Card_Type,Value = p.Card_ID.ToString()

            }).ToArray());

            cards.AddRange(reservationList);

        }
        protected void ddlCard_Selected(object sender, EventArgs e)
        {

            ddlCard.Items.Clear();
            GetCard();

            var iRe = cards.Where(a => a.Card_ID.ToString() == ddlCard.SelectedValue);
            foreach (var re in iRe)
            {
                ImgCard.ImageUrl = re.Card_Style;
            }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

            // (!IsPostBack)
            //{
            deptid = ddlDept.SelectedValue.ToString();
            //if (!IsPostBack)
            //{
                GetUserByDept();
            //}

            //}
        }

        protected void ddlDept_TextChanged(object sender, EventArgs e)
        {
            //deptid = ddlDept.SelectedValue.ToString();
            //Label1.Text = deptid;
            //// (!IsPostBack)
            ////{
            //GetUserByDept(deptid);
            //}
        }

        //Start PPTA Add
        protected void click_SendMsg(object sender, EventArgs e)
        {
            saveLogSend();
        }
        //End PPTA Add

        public void saveLogSend()
        {
            List<LogSends> reservationList = new List<LogSends>();
            string url = "https://localhost:44334/api/LogSends/SaveSends";
            using var client = new HttpClient();
            DataCommon.LsReseiverID = ddlUser.SelectedValue.ToString();
            DataCommon.CardID = ddlCard.SelectedValue.ToString();
            DataCommon.LsSenderID = Session["User_ID"].ToString();
            var ls = new LogSends();
            ls.CreatedDateTime = DataCommon.createdate;
            ls.Card_ID = Convert.ToInt64(DataCommon.CardID);
            ls.Status_Code = 1;
            ls.Sender_ID = Convert.ToInt64(DataCommon.LsSenderID);
            ls.Receiver_ID = Convert.ToInt64(DataCommon.LsReseiverID);
            ls.replyMsg = "";
            ls.MessageText = txt_Msg.Text;

            var json = JsonConvert.SerializeObject(ls);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            

            //testServer.Text = result;

            if (response != null)
            {
                savelogReceive();
            }
            else
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var deljson = JsonConvert.SerializeObject(result);
                var deldata = new StringContent(deljson, Encoding.UTF8, "application/json");
                string delurl = "https://localhost:44334/api/LogSends/DeleteSend";
                var delresponse = client.PostAsync(delurl, deldata);
                string delresult = response.Content.ReadAsStringAsync().Result;

                testServer.Text = delresult;

            }
        }

        public void savelogReceive()
        {
            string url = "https://localhost:44334/api/LogReceives/SaveReceives";
            using var client = new HttpClient();
            //resID = ddlUser.SelectedValue.ToString();
            var lr = new LogRecieves();
            lr.CreatedDateTime = DataCommon.createdate;
            lr.Card_ID = Convert.ToInt64(DataCommon.CardID);
            lr.Status_Code = 2;
            lr.Sender_ID = Convert.ToInt64(DataCommon.LsReseiverID);
            lr.Receiver_ID = Convert.ToInt64(DataCommon.LsSenderID);
            lr.replyMsg = "";
            var json = JsonConvert.SerializeObject(lr);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;

            testServer.Text = result;
        }
    }
}