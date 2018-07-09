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
        
        public Boolean ValidateUser(Credentials credentials)
        {

            loggerInfo.Info("before comparing password");
            try
            {
                var password = GetUserPassword(credentials.username);
                if (password == credentials.pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) {
                loggerInfo.Info("Unable to get password for user:" + credentials.username);
                return false;
            }
            
        }

        private string GetUserPassword(string username)
        {

            Db db = new Db();
            Credentials userCredentials = db.GetLoginData(username);
            return userCredentials.pass;
        }
    }
}