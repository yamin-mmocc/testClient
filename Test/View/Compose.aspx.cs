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
    public partial class Compose : System.Web.UI.Page
    {
        string deptname = "";
        string username = "";
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

        protected async System.Threading.Tasks.Task GetUserByDept()
        {
            List<Users> reservationList = new List<Users>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Users/GetUserByDept";

            var d = new Departments();
            d.Department_Name = deptname;

            var json = JsonConvert.SerializeObject(d);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url,data).Result;

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
                Text = p.Card_Type
               ,
                Value = p.Card_ID.ToString()

            }).ToArray());
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

            // (!IsPostBack)
            //{
            deptname = ddlDept.SelectedItem.ToString();
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
    }
}