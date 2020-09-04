using Intuit.Ipp.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Model;
//using System.Net.Http;

namespace Test.View
{
    public partial class DepartmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDepartment();
        }
        //    public async System.Threading.Tasks.Task GetDepartmentAsync()
        //    {
        //    //HttpClient client = new HttpClient();
        //    //    string url = "https://localhost:44334/api/Departments/GetDept";
        //    //using (var client = new HttpClient())
        //    //{
        //    //    //string path = "uri";
        //    //    var response = client.GetAsync(url);
        //    //        GridView1.DataSource = JsonConvert.SerializeObject(response);
        //    //        GridView1.DataBind();

        //    //    //}
        //    //}


        //}

        //private async Task<IEnumerable<Departments>> GetDepartmentAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    string url = "https://localhost:44334/api/Departments/GetDept";

        //    //client.BaseAddress = new Uri("https://api.github.com");
        //    //client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
        //    //client.DefaultRequestHeaders.Accept.Add(
        //    //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    //var url = "repos/symfony/symfony/contributors";
        //    HttpResponseMessage response = await client.GetAsync(url);
        //    response.EnsureSuccessStatusCode();
        //    var resp = await response.Content.ReadAsStringAsync();

        //    List<Departments> dept = JsonConvert.DeserializeObject<List<Departments>>(resp);
        //    //contributors.ForEach(Console.WriteLine);
        //    return dept;
        //}

        //    public async Task<ActionResult> index()
        //{
        //    Departments model = new Departments();
        //    List<Departments> deptList = new List<Departments>();
        //    Departments dept = null;
        //    using (var client = new HttpClient())
        //    {
        //        string url = "https://localhost:44334/api/Departments/GetDept";
        //        var responseTask = client.GetAsync(url);
        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var departments = await result.Content.ReadAsStringAsync();
        //            //foreach (var department in departments)
        //            //{
        //            //    dept = new Departments();
        //            //    dept.Department_Name = department.Department_Name;
        //            //    dept.City = student.City;
        //            //    studentList.Add(stu);
        //            //}
        //        }
        //       // model.StudentList = studentList;
        //    }
        // return await Task.Run(() => View(model));
        //}
        protected async System.Threading.Tasks.Task GetDepartment()
        {

            //List<Departments> reservationList = new List<Departments>();
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response1 = await httpClient.GetAsync("https://localhost:44334/api/Departments/GetDepartments"))
            //    {
            //        string apiResponse = await response1.Content.ReadAsStringAsync();
            //        reservationList = JsonConvert.DeserializeObject<List<Departments>>(apiResponse);
            //    }
            //}

            List<Departments> reservationList = new List<Departments>();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Departments/GetDepartments";
            var response =  client.GetAsync(url).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            reservationList = JsonConvert.DeserializeObject<List<Departments>>(result);

            //Console.WriteLine(reservationList);
            GridView1.DataSource = reservationList;
            GridView1.DataBind();

        }


            // GridView1.DataSource = reservationList;
            //GridView1.DataBind();
        
    }

}
