﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class _Default : Page
    {
        public static List<Student> studentsList = new List<Student>();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //As the page loads we want to create an array of students
                Session["StudentArray"] = new Student[10];
                Session["ArrayKeeper"] = 0;
                


            }

        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int keeper = (int)Session["ArrayKeeper"];
            
            String studfName = txtStudFisrtN.Text.ToString();
            String studlName = txtStudLastN.Text.ToString();
            String studMajor = txtMajor.Text.ToString();
            int studGradYear = int.Parse(intGradYear.Text);
            string studAcademicYear = intAcademicYear.Text.ToString();
            String studEmail = txtEmail.Text.ToString();

            Student studentObj = new Student(1, studfName, studlName, studGradYear, studAcademicYear, studEmail, 1, 1);

            studentsList.Add(studentObj);

            // Trying to print array to test
            Console.WriteLine(studentObj.studentId.ToString() + studentObj.firstName.ToString());


            //Reference the stored array and use type cast to store as object
            //Student[] stuArray = (Student[])Session["StudentArray"];
            
        }

        protected void CommitButton_Click(object sender, EventArgs e)
        {
            // List is sent to database

        }

        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            // Disables the populate button after first click
            Populate.Enabled = false;

            this.txtStudFisrtN.Text += "John";
            this.txtStudLastN.Text += "Doe";
            this.txtEmail.Text += "fake@fake.com";
            this.txtMajor.Text += "BasketWeaving";
            this.intPhoneNumber.Text += "000";
            

        }
    }
}