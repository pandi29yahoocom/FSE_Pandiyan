using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20_MVC_Assignment_1_DOTNET.Models;
namespace _20_MVC_Assignment_1_DOTNET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return View();
            Session["User_ID"] = null;
            Session.Clear();
            return View("~/Views/Account/Login.cshtml");
        }

        public ActionResult Login(PersonViewModel model)
        {
            PersonViewModel emp = new PersonViewModel();

            emp = emp.GetPersonById(model.userId);
            if (emp.password == model.password)
            {
                Session["User_ID"] = emp.userId;
                Session["UserName"] = emp.fullName;
                return RedirectToAction("TweetHome");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("~/Views/Account/Login.cshtml");
            }

        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = model.AddPerson(model);
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Error Occured while registering user");
            return View("~/Views/Account/Register.cshtml", model);
        }
        public ActionResult TweetHome()
        {
            return View();
        }

        public JsonResult GetTweets()
        {
            TweetViewModel tweet = new TweetViewModel();
            List<TweetViewModel> tweets = tweet.GetTweetsByUserId(Convert.ToString(Session["User_ID"]));
            HomeModel tweetsInfo = new HomeModel();
            tweetsInfo.Tweets = tweets;
            tweetsInfo.TweetsCnt = tweets.Where(x => x.userid == Convert.ToString(Session["User_ID"])).Count();
            tweetsInfo.FollowersCnt = 0;
            tweetsInfo.FollowingCnt = tweets.Where(x => x.userid != Convert.ToString(Session["User_ID"])).Count();
            return Json(tweetsInfo, JsonRequestBehavior.AllowGet); ;

        }

        public JsonResult Twitt(string msg)
        {
            TweetViewModel tweets = new TweetViewModel();
            tweets.message = msg;
            tweets.userid = Convert.ToString(Session["User_ID"]);
            tweets.AddTweets(tweets);
            return GetTweets();
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