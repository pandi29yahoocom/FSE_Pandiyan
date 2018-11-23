using _20_MVC_Assignment_1_DOTNET.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_MVC_Assignment_1_DOTNET.BL
{
    public class PersonBL
    {
        public string userId { get; set; }

        public string password { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public DateTime joined { get; set; }
        public bool active { get; set; }
        public List<PersonBL> folllowing { get; set; }

        public List<PersonBL> followers { get; set; }

        public List<TweetBL> tweets { get; set; }

        public PersonBL GetPersonById(string userId)
        {
            TwitterCloneRepository rep = new TwitterCloneRepository();
            PERSON per = rep.GetPersonById(userId);
            return ConvertObj(per);
        }

        public PersonBL AddPerson(PersonBL personBL)
        {
            TwitterCloneRepository rep = new TwitterCloneRepository();
            PERSON per = ConvertBLObj(personBL);
            per = rep.AddPerson(per);
            return ConvertObj(per);
        }


        private PersonBL ConvertObj(PERSON per)
        {
            return new PersonBL()
            {
                active = per.active,
                email = per.email,
                fullName = per.fullName,
                joined = per.joined,
                userId = per.user_id,
                password = per.password
            };
        }
        private PERSON ConvertBLObj(PersonBL per)
        {
            return new PERSON()
            {
                active = per.active,
                email = per.email,
                fullName = per.fullName,
                joined = per.joined,
                user_id = per.userId,
                password = per.password
            };
        }

    }


}
