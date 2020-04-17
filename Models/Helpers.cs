using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace intex2.Models
{
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["Campaigns"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["intex210"];
            string password = appConfig["ISRocks!"];
            string hostname = appConfig["intex210.cboto09td07y.us-east-2.rds.amazonaws.com"];
            string port = appConfig["1433"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}