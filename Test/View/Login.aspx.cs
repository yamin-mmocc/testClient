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
        }
    }
}