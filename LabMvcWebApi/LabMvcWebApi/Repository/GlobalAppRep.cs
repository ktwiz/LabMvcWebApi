using LabMvcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMvcWebApi.Repository
{
    public class GlobalAppRep
    {
        public static string APP_CLIENT_ID = "EMPTY";
        public static string APP_CLIENT_SECRET = "EMPTY";

        public static string[] APP_COMPANY_CD = new string[] { };
        public static List<Employee> listEmployees = Employee.initListEmpl();
        public static List<TokensManager> tokenStorage = new List<TokensManager>();
    }
}