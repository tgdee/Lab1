using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    partial class Internship
    {
        private string type1;
        private string start;
        private string city;



        public string Type1 { get; private set; }
        public string Start { get; private set; }
        public string City { get; private set; }

        public Internship(string type1, string start, string city) 
            {
            Type1 = type1;
            Start = start;
            City = city;
            
            }
        public override string ToString()
        {
            String description = "";
            description+= Type1 + type1 + "\t" + start + "\t" + city;
            return description;
        }

        public Internship()
        {
            Type1 = "Johnny";
            Start = "January 10th";
            City = "Los Angelos";
        }
    }

}