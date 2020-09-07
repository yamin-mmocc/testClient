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
using Test.Common;

namespace Test.View
{
    public partial class Login : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44334/api/Users/authenticate";
            using var client = new HttpClient();

            var user = new Users();
            //dept.Department_ID = 3;
            user.User_Name = txtusername.Text.Trim();
            user.Password = txtPassword.Text.Trim();
            

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;

            if(result != null)


            Label3.Text = "Login Success";

            //DataCommon.LoginUserName = txtusername.Text.Trim();

            GetUserInfoByName();

            if(DataCommon.LoginRoleType == "Developer")
            {
                //AdminHomePage admin = new AdminHomePage();
                //admin.Visible=true; // Shows Form2
                Session["User_Name"] = txtusername.Text.Trim();
                Response.Redirect("Compose.aspx");
                Session.RemoveAll();
            }
            else
            {
                Session["User_Name"] = txtusername.Text.Trim();
                Response.Redirect("AdminHomePage.aspx");
                Session.RemoveAll();
            }
        }

        protected async System.Threading.Tasks.Task GetUserInfoByName()
        {
            List<UserDepartmentRole> reservationList = new List<UserDepartmentRole>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Users/GetUserInfoByName";

            var udr = new UserDepartmentRole();
            udr.User_Name = txtusername.Text;

            var json = JsonConvert.SerializeObject(udr);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<UserDepartmentRole>>(result);

            DataCommon.LoginUserID = Convert.ToInt64(reservationList[0].User_ID);
            DataCommon.LoginDeptID = Convert.ToInt64(reservationList[0].Department_ID);
            DataCommon.LoginRoleID = Convert.ToInt64(reservationList[0].Role_ID);
            DataCommon.LoginDeptName = reservationList[0].Department_Name.ToString();
            DataCommon.LoginRoleType = reservationList[0].Role_Type.ToString();

            //Session["User_ID"] = Convert.ToInt64(reservationList[0].User_ID);
        }
    }
}