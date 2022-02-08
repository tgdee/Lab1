using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class Member : System.Web.UI.Page
    {
        public Member()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //As the page loads we want to create an array of students
                Session["MemberArray"] = new Member[10];
                Session["ArrayKeeper"] = 0;


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String firstName = txtFirstName.Text.ToString();
            String lastName = txtLastName.Text.ToString();
            String email = txtEmail.Text.ToString();


            //Create the array 
            Member[] memArray = (Member[])Session["MemberArray"];
            int keeper = (int)Session["ArrayKeeper"];

            //Add Member to the array
            memArray[keeper++] = new Member(firstName, lastName, email);

            //Update the index tracker
            Session["ArrayKeeper"] = keeper;

            Session["MemberArray"] = memArray;

        }
    }
}