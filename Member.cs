using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    partial class Member
    {
        private string lastName;
        private string email;



        public string FirstName { get; set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

    public Member(string fName, string lName, string email)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;

        }

        public override string ToString()
        {
            string description = "";
            description += FirstName + "\t" + LastName + "\t" + Email;

            return description;
        }
    }

}