using Newtonsoft.Json.Linq;
using RestSharp;
using SeeThisMovieQuestionMark.DAL;
using SeeThisMovieQuestionMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeeThisMovieQuestionMark.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext db = new MovieContext();
        
        //INDEX GET
        public ActionResult Index()
        {
            return View();
        }

        //INDEX POST
        [HttpPost]
        public ActionResult Result(FormCollection form)
        {
            int mylevel;
            string title;
            string genres;
            int duration;
            string country;
            string language;
            string description;

            mylevel = Int32.Parse(form["mylevel"]);
            title = form["title"];
            genres = form["genre1"];
            if(form["genre2"] != "")
            {
                genres += (" " + form["genre2"]);
            }
            if (form["genre3"] != "")
            {
                genres += (" " + form["genre3"]);
            }

            genres = genres.Trim();
            duration = Int32.Parse(form["duration"]);
            country = form["country"];
            language = form["language"];
            description = form["description"];

            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/f4fee65609f84a32b84caffa99a61f30/services/6c7d584e7c06450ba7fedfa904549270/execute?api-version=2.0&details=true");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer 7ZlkHBdNVikj14uU99/pyfAsj7+KbnCZ42DkMqyOMud3Mx9JFVY/Q4B1dUvzduEj6jmYlG57rgisFQ1I+YnioQ==");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json,application/json", "{\r\n  \"Inputs\": {\r\n    \"input1\": {\r\n      \"ColumnNames\": [\r\n        \"genre\",\r\n        \"duration\",\r\n        \"country\",\r\n        \"language\",\r\n        \"description\",\r\n        \"avg_vote\"\r\n      ],\r\n      \"Values\": [\r\n        [\r\n          \"" + genres + "\",\r\n          \"" + duration + "\",\r\n          \"" + country + "\",\r\n          \"" + language + "\",\r\n          \"" + description + "\",\r\n          \"0\"\r\n        ]\r\n      ]\r\n    }\r\n  },\r\n  \"GlobalParameters\": {}\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = JObject.Parse(response.Content);
            string prediction = result["Results"]["output1"]["value"]["Values"].ToString().Replace("[", "").Replace("]", "").Replace("\"", "");
            System.Double num_prediction = Math.Round(Convert.ToDouble(prediction),2);
            ViewBag.PredictedAvgVote = "This movie's rating will be close to " + num_prediction;

            ViewBag.PickLevel = mylevel;

            if (num_prediction >= mylevel)
            {
                ViewBag.Decision = "You should give this movie a shot";
            }
            else
            {
                ViewBag.Decision = "This movie will probably not satisfy you";
            }

            try
            {
                string title_query = "SELECT title FROM movies WHERE avg_vote >" + mylevel + "ORDER BY NEWID()"; 
                var suggested_title = db.Database.SqlQuery<string>(title_query).FirstOrDefault().ToString();
                string year_query = "SELECT year FROM movies WHERE title='" + suggested_title + "'";
                var year = db.Database.SqlQuery<int>(year_query).FirstOrDefault().ToString();
                ViewBag.Suggestion = ("We think you might also like this movie: " + suggested_title + " (" + year + ")");
            }
            catch (Exception e)
            {
                ViewBag.Suggestion = "Sorry, something went wrong, and we have nothing to suggest for you today! :(";
            }

            return View(form);
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
    }
}