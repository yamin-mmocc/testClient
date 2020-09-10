using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Providers.Entities;

namespace Test.Common
{
    class DataCommon
    {
        public static string Depturl = "https://localhost:44373/api/Departments/";

        //public static HttpClient client = new HttpClient();

        public static string LoginUserName = "";
        public static long LoginUserID = 0;
        public static long LoginDeptID = 0;
        public static long LoginRoleID = 0;
        public static string LoginDeptName = "";
        public static string LoginRoleType = "";


        //LogSends LogReceives Data
        public static string LsSenderID = "";
        public static string LsReseiverID = "";
        public static string CardID = "";
        public static DateTime createdate = DateTime.Now;
    }
}