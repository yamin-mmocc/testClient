using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Test.Model;

namespace Test.View
{
    public partial class UserList : System.Web.UI.Page
    {
        string name = "";
        string deptname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartment();
                GetUsers(name, deptname);
            }
        }

        protected async System.Threading.Tasks.Task GetUsers(string name, string deptname)
        {
            List<UserDepartmentRole> reservationList = new List<UserDepartmentRole>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Users/GetUsers";

            var udr = new UserDepartmentRole();
            //dept.Department_ID = 3;
            udr.User_Name = txtname.Text.Trim();
            udr.Department_Name = ddlDept.SelectedItem.ToString();

            var json = JsonConvert.SerializeObject(udr);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<UserDepartmentRole>>(result);

            //Console.WriteLine(reservationList);
            GridView1.DataSource = reservationList;
            GridView1.DataBind();

        }


        protected async System.Threading.Tasks.Task GetDepartment()
        {
            List<Departments> reservationList = new List<Departments>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Departments/GetDepartments";
            var response = client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<Departments>>(result);
            ddlDept.Items
           .AddRange(reservationList
            .Select(p => new ListItem()
            {
                Text = p.Department_Name,

                Value = p.Department_ID.ToString()

            }).ToArray());



        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string deptname = ddlDept.SelectedItem.ToString();
            GetUsers(name, deptname);
        }
    }
}