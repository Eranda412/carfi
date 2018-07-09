using CarFi.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarFi.CarfiCommon
{
    public class Db
    {
        private static string ConnetionString = "server = localhost; database = CarFi; uid = sa; Password = tiqri123@; ";

        public void CreateConnection()
        {

        }
        public Credentials GetLoginData(string username)
        {

            string select_qry = $"SELECT * FROM login where username = '{username}' "; // ID is primary key
            SqlConnection cnn = new SqlConnection(ConnetionString);
            SqlCommand cmd = new SqlCommand(select_qry);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Credentials userCredentials = new Credentials();

            if (reader.HasRows)
            {
                if (reader.FieldCount == 1)
                {
                    while (reader.Read())
                    {
                       
                        userCredentials.username = reader["username"].ToString();
                        userCredentials.pass = reader["pass"].ToString();
                        return userCredentials;
                    }
                }
                else
                {
                    ILog loggerInfo = LogManager.GetLogger("Info");
                    loggerInfo.Info("More than one user found for user name : " + username);
                }
            }
            else
            {
                ILog loggerInfo = LogManager.GetLogger("Info");
                loggerInfo.Info("No Rows Found");
            }
            reader.Close();
            cnn.Close();
            return userCredentials;
        }

    }
}