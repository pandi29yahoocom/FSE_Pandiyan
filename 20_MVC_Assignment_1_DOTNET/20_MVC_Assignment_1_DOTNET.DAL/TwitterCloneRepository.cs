using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_MVC_Assignment_1_DOTNET.DAL
{
    public class TwitterCloneRepository
    {
        internal TwitterCloneEntities context;
        public TwitterCloneRepository()
        {
            if (object.ReferenceEquals(context, null))
                this.context = new TwitterCloneEntities();
        }


        public IQueryable<PERSON> GetPERSONs()
        {
            return context.People;
        }


        public PERSON GetPersonById(string id)
        {
            PERSON person = context.People.Where(x => x.user_id == id).FirstOrDefault();
            return person;
        }
        public PERSON AddPerson(PERSON person)
        {
            person.active = true;
            person.joined = DateTime.Now;
            context.People.Add(person);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ITEMExists(person.user_id))
                {
                    return person;//Conflict();
                }
                else
                {
                    throw;
                }
            }
            return person;


        }


        public bool DeleteITEM(string id)
        {
            PERSON person = context.People.Find(id);
            if (person == null)
            {
                return false;
            }

            context.People.Remove(person);
            context.SaveChanges();

            return true;
        }

        private bool ITEMExists(string id)
        {
            return context.People.Count(e => e.user_id == id) > 0;
        }


        public List<TWEET> GetTweetsByUserId(string id)
        {
            List<TWEET> twt = new List<TWEET>();
            List<USP_GETTWEETS_Result> tweet = context.USP_GETTWEETS(id).ToList(); //context.TWEETs.Where(x => x.user_id == id).ToList();
            tweet.ForEach(u =>
            {
                twt.Add(new TWEET() { created = u.CREATED, message = u.MESSAGE, user_id = u.USER_ID, tweet_id = u.TWEET_ID });
            });
            return twt;
        }
        public TWEET AddTweet(TWEET tweet)
        {
            tweet.created = DateTime.Now;
            context.TWEETs.Add(tweet);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;

            }
            return tweet;


        }


        public bool DeleteTweet(int id)
        {
            TWEET tweet = context.TWEETs.Where(x => x.tweet_id == id).FirstOrDefault();
            if (tweet == null)
            {
                return false;
            }

            context.TWEETs.Remove(tweet);
            context.SaveChanges();

            return true;
        }



    }
}
