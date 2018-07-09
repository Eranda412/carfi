using CarFi.CarfiCommon;
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
    public class Login
    {
        ILog loggerInfo = LogManager.GetLogger("Info");
        //public Credentials getUserData(Credentials credentials)
        //{
        //    try
        //    {
        //        loggerInfo.Info("Login");
        //        GetUserData(credentials);

        //    }
        //    catch (Exception e)
        //    {
        //        ILog loggerError = LogManager.GetLogger("Error");
        //        loggerError.Error(e);

        //    }

        //    return credentials;
        //}

        //private void GetUserData(Credentials credentials)
        //{
        //    Db db = new Db();
        //    SqlDataReader reader = db.GetUserData(credentials);

        //    if (reader.HasRows)
        //    {
        //        var password = reader[0];
        //        ILog loggerInfo = LogManager.GetLogger("Info");
        //        loggerInfo.Info(password);
        //    }
        //}

        public Boolean ValidateUser(Credentials credentials)
        {

            try
            {
                var password = GetUserPassword(credentials.username);

                if(password == credentials.pass)
                {
                    return true;
                }
            }
            catch (Exception e) {
                loggerInfo.Error("Unable to get password for user:" + credentials.username);
                return false;
            }
            
            return true;
        }

        private string GetUserPassword(string username)
        {

            Db db = new Db();
            Credentials userCredentials = db.GetLoginData(username);
            return userCredentials.pass;
        }
    }
}