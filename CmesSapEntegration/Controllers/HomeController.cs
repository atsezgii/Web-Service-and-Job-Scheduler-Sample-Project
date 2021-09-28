using CmesSapEntegration.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CmesSapEntegration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // Example();
          //  Example2();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<string> Example()
        {
            //The data that needs to be sent. Any object works.
            var pocoObject = new
            {
                username = "119828",
                password = "119828"
            };

            //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
            string json = JsonConvert.SerializeObject(pocoObject);

            //Needed to setup the body of the request
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            //The url to post to.
            var url = "http://localhost:9003/api/Auth/login";
            var client = new HttpClient();
                var response = await client.PostAsync(url, data);
                string result = await response.Content.ReadAsStringAsync();
                //close out the client
                client.Dispose();
            return result;
        }

        public async Task<string> Example2()
        {
            //The data that needs to be sent. Any object works.
            var conicColor = new ConicColor()
            {
                ColorName = "test"
            };

            //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
            string json = JsonConvert.SerializeObject(conicColor);

            //Needed to setup the body of the request
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            //The url to post to.
            var url = "http://localhost:9003/api/ConicColor/PostConicColor";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIzODU5IiwiVXNlck5hbWUiOiIxMTk4MjgiLCJuYmYiOjE2Mjk4MDU1MTAsImV4cCI6MTYyOTg5MTkxMCwiaWF0IjoxNjI5ODA1NTEwfQ.RJ17--dtAz63W_4XgyLrfsD4nVJ_etLATwKpbHOKNyU");

            var response = await client.PostAsync(url, data);
            string result = await response.Content.ReadAsStringAsync();
            //close out the client
            client.Dispose();
            return result;
        }


    }
}