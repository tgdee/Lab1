using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //As the page loads we want to create an array of students
                Session["StudentArray"] = new Student[10];
                Session["ArrayKeeper"] = 0;


            }
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            String studfName = txtStudFisrtN.Text.ToString();
            String studlName = txtStudLastN.Text.ToString();
            String studMajor = txtMajor.Text.ToString();
            int studGradYear = int.Parse(intGradYear.Text);
            int studAcademicYear = int.Parse(intAcademicYear.Text);
            String studEmail = txtEmail.Text.ToString();
            int studPhoneNumber = int.Parse(intPhoneNumber.Text);
            

            //Reference the stored array and use type cast to store as object
            Student[] stuArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}