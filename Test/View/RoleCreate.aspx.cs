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
    public partial class RoleCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRole_Click(object sender, EventArgs e)
        {
            PostRole();
        }

        protected async System.Threading.Tasks.Task PostRole()
        {
            string url = "https://localhost:44339/api/Roles/CreateRoles";
            using var client = new HttpClient();



            var role = new Roles();
            //dept.Department_ID = 3;
            role.Role_Type = txtRole.Text.Trim();
            role.IsActive = true;
            role.timeStamp = DateTime.Now;

            var json = JsonConvert.SerializeObject(role);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;


            Label2.Text = result.ToString();
        }
    }
}