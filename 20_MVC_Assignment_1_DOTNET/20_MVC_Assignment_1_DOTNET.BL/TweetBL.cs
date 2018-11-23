using _20_MVC_Assignment_1_DOTNET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_MVC_Assignment_1_DOTNET.BL
{
    public class TweetBL
    {
        public int tweetid { get; set; }

        public string message { get; set; }
        public DateTime created { get; set; }

        public string userid { get; set; }


        public List<TweetBL> GetTweetsByUserId(string userId)
        {
            TwitterCloneRepository rep = new TwitterCloneRepository();
            List<TWEET> per = rep.GetTweetsByUserId(userId);
            List<TweetBL> ret = new List<TweetBL>();
            per.ForEach(u => { ret.Add(ConvertObj(u)); });
            return ret;
        }

        public TweetBL AddTweets(TweetBL personBL)
        {
            TwitterCloneRepository rep = new TwitterCloneRepository();
            TWEET per = ConvertBLObj(personBL);
            per = rep.AddTweet(per);
            return personBL;
        }


        private TweetBL ConvertObj(TWEET per)
        {
            return new TweetBL()
            {
                tweetid = per.tweet_id,
                message = per.message,
                created = per.created,
                userid = per.user_id

            };
        }
        private TWEET ConvertBLObj(TweetBL per)
        {
            return new TWEET()
            {
                tweet_id = per.tweetid,
                message = per.message,
                created = per.created,
                user_id = per.userid
            };
        }

    }
}
