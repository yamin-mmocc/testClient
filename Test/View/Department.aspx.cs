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
using System.Linq;


namespace Test.View
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btnDeptCreate_Click(object sender, EventArgs e)
        {

            PostDepartMent();
            

        }

        protected async System.Threading.Tasks.Task PostDepartMent()
        {
            string url = "https://localhost:44334/api/Departments/CreateDept";
            using var client = new HttpClient();


            //Departments dept = new Departments();
            //if (txtdeptname.Text.Trim() != null)
            //{
            //    dept.Department_ID = 2;
            //    dept.Department_Name = txtdeptname.Text.Trim();
            //    dept.IsActive = true;
            //    dept.timeStamp = DateTime.Now;
            //}

            ////var response = string.Empty;

            //var stringContent = new StringContent(JsonConvert.SerializeObject(dept), UnicodeEncoding.UTF8, "application/json");
            ////var client = new HttpClient();
            //var response = await client.PostAsync(url, stringContent);

            //string result = response.Content.ReadAsStringAsync().Result;

            //Label2.Text = result.ToString();

            var dept = new Departments();
            //dept.Department_ID = 3;
            dept.Department_Name = txtdeptname.Text.Trim();
            dept.IsActive = true;
            dept.timeStamp = DateTime.Now;

            var json = JsonConvert.SerializeObject(dept);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response =  client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            

           Label2.Text = result.ToString();
        }
    }

}
    
