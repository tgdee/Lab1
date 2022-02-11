using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public partial class Company
    {
        private string meetingTimee;
        private string companyName;
        private string email;
        private string firstName;
        private string lastName;


        public Company(string firstName, string lastName, string companyName, string email, string meetingTime)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Email = email;
            MeetingTime = meetingTime;
        }

        public override string ToString()
        {
            string description = "";
            description += FirstName + "\t" + LastName + "\t" + CompanyName + "\t" + Email + "\t" + MeetingTime;
            return description;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CompanyName { get; private set; }
        public string Email { get; private set; }
        public string MeetingTime { get; private set; }
    }
}