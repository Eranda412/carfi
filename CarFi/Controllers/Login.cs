using CarFi.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CarFi.Controllers
{
    public static class Login
    {

        private static string ConnetionString = "server = localhost; database = CarFi; uid = sa; Password = tiqri123@; ";

        public static string getUserData(credentials credentials)
        {
            try {
                ILog loggerInfo = LogManager.GetLogger("Info");
                loggerInfo.Info("Login");
                loggerInfo.Info(credentials.username.ToString());
            }
            catch (Exception e)
            {
                ILog loggerError = LogManager.GetLogger("Error");
                loggerError.Error(e);
                return e.ToString();
            }
            //GetUser();
            return "userName";
        }
        
        private static void GetUser() {
            string select_qry = "SELECT * FROM users"; // ID is primary key
            SqlConnection cnn = new SqlConnection(ConnetionString);
           
            SqlCommand cmd = new SqlCommand(select_qry);
            
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ILog loggerInfo = LogManager.GetLogger("Info");
                    loggerInfo.Info(reader.GetString(1));
                    
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            cnn.Close();

        }
    }
}