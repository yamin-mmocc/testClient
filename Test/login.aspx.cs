using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Controller;

namespace Test
{
    public partial class login : System.Web.UI.Page
    {
        UserController Repo = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            //lblresult.Text = Convert.ToString(Repo.LoginUser(name, password));
        }
    }
}