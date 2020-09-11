using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Common;

namespace Test.View
{
    public partial class InboxView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sender_lbl.Text = DataCommon.Sender_Name;
            subtext_lbl.Text = DataCommon.Sender_Department;
            TC_img.ImageUrl = DataCommon.Card_Style;
        }
    }
}