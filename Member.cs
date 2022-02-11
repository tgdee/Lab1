using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    partial class Member
    {
        private string firstName;
        private string lastName;
        private string email;



        public String FirstName { get; private set; }
        public String LastName { get; private set; }
        public String Email { get; private set; }

    public Member(string fName, string lName, string email)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;

        }

        public override string ToString()
        {
            String description = "";
            description += FirstName + "\t" + LastName + "\t" + Email;

            return description;
        }
    }

}