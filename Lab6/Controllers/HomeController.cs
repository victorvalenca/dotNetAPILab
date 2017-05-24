using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using Newtonsoft.Json;
using Lab6.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            string apiGet = "YOUR API ENDPOINT HERE";
            var client = new HttpClient();
            var resultSet = await client.GetAsync(apiGet);

            var content = await resultSet.Content.ReadAsStringAsync();
            var tweets = JsonConvert.DeserializeObject<List<Tweet>>(content);
            //var hi = (from h in tweets where h.Content.StartsWith("h") select h).FirstOrDefault();
            return View(tweets.OrderByDescending(o => o.TweetId));
        }

        [HttpPost]
        public async Task<IActionResult> PostTweet()
        {
            var tweet = new Tweet();
            tweet.Username = HttpContext.Request.Form["username"];
            tweet.Content = HttpContext.Request.Form["content"];

            var json = JsonConvert.SerializeObject(tweet);

            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var client = new HttpClient();
            string apiPost = "YOUR API ENDPOINT HERE";
            await client.PostAsync("apiPost", httpContent);

            return RedirectToAction("Index");
        }
    }
}
