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
using Xceed.Wpf.Toolkit;

namespace Test.View
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDepartment();
            GetRole();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44334/api/Users/CreateUser";
            using var client = new HttpClient();



            var user = new Users();
            //dept.Department_ID = 3;
            user.User_Name = txtname.Text;
            user.Role_ID = Convert.ToInt64(RoleddList.SelectedValue.ToString());
            user.Department_ID = Convert.ToInt64(DeptddList.SelectedValue.ToString());
            user.IsActive = true;
            user.timeStamp = DateTime.Now;

            if (txtpwd.Text != txtcfmpwd.Text)
            {
                Label6.Text = "password does not match";
                return;
            }
            else
                user.Password = txtpwd.Text;

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
                      
            Label6.Text = result.ToString();

            //messagebox
            string message = "Order Placed Successfully.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
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
            DeptddList.Items
           .AddRange(reservationList
            .Select(p => new ListItem()
            {
                Text = p.Department_Name
               ,
                Value = p.Department_ID.ToString()

            }).ToArray());

        }

        protected async System.Threading.Tasks.Task GetRole()
        {
            List<Roles> reservationList = new List<Roles>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Roles/GetRoles";
            var response = client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<Roles>>(result);


            //Console.WriteLine(reservationList);
            //RoleddList.DataSource = reservationList;
            //RoleddList.DataBind();

            RoleddList.Items
           .AddRange(reservationList
            .Select(p => new ListItem()
            {
                Text = p.Role_Type
               ,
                Value = p.Role_ID.ToString()
               
            }).ToArray());

        }
    }
}