using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    partial class Member
    {
        public int memberID { get; private set; }
        public String fName { get; private set; }
        public String lName { get; private set; }
        public String email { get; private set; }

    public Member(int memberID, String fName, String lName, String email)
        {
            this.memberID = memberID;
            this.fName = fName;
            this.lName = lName;
            this.email = email;

        }

        public override string ToString()
        {
            String description = "";
            description += this.fName + "\t" + this.lName + "\t" + this.email;

            return description;
        }
    }

}