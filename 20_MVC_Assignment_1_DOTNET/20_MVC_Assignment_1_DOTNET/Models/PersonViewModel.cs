using _20_MVC_Assignment_1_DOTNET.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20_MVC_Assignment_1_DOTNET.Models
{
    public class PersonViewModel
    {
        internal PersonBL personBL;

        public PersonViewModel()
        {
            if (object.ReferenceEquals(personBL, null))
                this.personBL = new PersonBL();
        }
        public string userId { get; set; }

        public string password { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public DateTime joined { get; set; }
        public bool active { get; set; }

        internal PersonViewModel GetPersonById(string usrId)
        {
            PersonBL per = personBL.GetPersonById(usrId);
            return ConvertObj(per);
        }

        internal PersonViewModel AddPerson(PersonViewModel personViewModel)
        {
            PersonBL per = ConvertBLObj(personViewModel);
            per = personBL.AddPerson(per);
            return ConvertObj(per);
        }

        private PersonViewModel ConvertObj(PersonBL per)
        {
            return new PersonViewModel()
            {
                active = per.active,
                email = per.email,
                fullName = per.fullName,
                joined = per.joined,
                userId = per.userId,
                password = per.password
            };
        }
        private PersonBL ConvertBLObj(PersonViewModel per)
        {
            return new PersonBL()
            {
                active = per.active,
                email = per.email,
                fullName = per.fullName,
                joined = per.joined,
                userId = per.userId,
                password = per.password
            };
        }


    }
}