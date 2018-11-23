using _20_MVC_Assignment_1_DOTNET.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20_MVC_Assignment_1_DOTNET.Models
{
    public class TweetViewModel
    {
        public int tweetid { get; set; }

        public string message { get; set; }
        public string created { get; set; }

        public string userid { get; set; }




        internal List<TweetViewModel> GetTweetsByUserId(string usrId)
        {
            TweetBL rep = new TweetBL();
            List<TweetBL> per = rep.GetTweetsByUserId(usrId);
            List<TweetViewModel> ret = new List<TweetViewModel>();
            per.ForEach(u => { ret.Add(ConvertObj(u)); });
            return ret;
        }

        internal TweetViewModel AddTweets(TweetViewModel personViewModel)
        {
            TweetBL per = ConvertBLObj(personViewModel);
            per = per.AddTweets(per);
            return ConvertObj(per);
        }

        private TweetViewModel ConvertObj(TweetBL per)
        {
            return new TweetViewModel()
            {
                tweetid = per.tweetid,
                message = per.message,
                created = per.created.ToString("MM/dd/yyyy hh:mm tt"),
                userid = per.userid

            };
        }
        private TweetBL ConvertBLObj(TweetViewModel per)
        {
            return new TweetBL()
            {
                tweetid = per.tweetid,
                message = per.message,
                userid = per.userid
            };
        }
    }

    public class HomeModel
    {
        public List<TweetViewModel> Tweets { get; set; }

        public int TweetsCnt { get; set; }

        public int FollowingCnt { get; set; }

        public int FollowersCnt { get; set; }

    }
}