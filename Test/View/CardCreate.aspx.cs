using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Model;

namespace Test.View
{
    public partial class CardCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void ImgFileUpload_DataBinding(object sender, EventArgs e)
        //{
        //    if (ImgFileUpload.HasFile)
        //    {

        //        ImgFileUpload.SaveAs(Server.MapPath("images//" + ImgFileUpload.FileName));
        //        Label2.Text = "Image Uploaded";
        //        Label2.ForeColor = System.Drawing.Color.ForestGreen;
        //    }
        //    else
        //    {
        //        Label2.Text = "Please Select your file";
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("Test/Images/Thanks Card (Without Name).png");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            ImgFileUpload.SaveAs(folderPath + Path.GetFileName(ImgFileUpload.FileName));

            //Label2.Text = ImgFileUpload.FileName;

            //Display the Picture in Image control.
            imgCard.ImageUrl = "Test/Images/Thanks Card (Without Name).png" + Path.GetFileName(ImgFileUpload.FileName);

            Label2.Text = "Test/Images/Thanks Card (Without Name).png" + Path.GetFileName(ImgFileUpload.FileName);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44334/api/Cards/CreateCard";
            using var client = new HttpClient();

            var card = new Cards();
            //dept.Department_ID = 3;
            card.Card_Type = txtcardname.Text;
            card.Card_Style = Label2.Text;            
            card.IsActive = true;
            card.timeStamp = DateTime.Now;
                       

            var json = JsonConvert.SerializeObject(card);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, data).Result;

            string result = response.Content.ReadAsStringAsync().Result;


            Label2.Text = result.ToString();
        }
    }
}