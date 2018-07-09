using CarFi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;

namespace CarFi.Controllers
{
    public class ValuesController : ApiController
    {
        ILog loggerInfo = LogManager.GetLogger("Info");
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public Dictionary<string,string> Userlogin(Credentials credentials) {
            loggerInfo.Info(credentials.username);
            Login login = new Login();
            Dictionary<string, string> datadic = new Dictionary<string, string>();
           
            
            if (login.ValidateUser(credentials))
            {
                datadic.Add("isValid", "true");
                loggerInfo.Info("returning true");
            }
            else
            {
                datadic.Add("isValid", "false");
                loggerInfo.Info("returning false");

            }
           // return login.ValidateUser(credentials);
            return datadic;
        }
    }
}
