using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace Lab1
{
    public partial class _Default : Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Session["StudentArray"] = new Student[10];
                Session["ArrayKeeper"] = 0;

                var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];
                int keeper = (int)Session["ArrayKeeper"];
                Student[] sArray = (Student[])Session["StudentArray"];
                using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
                {
                    try
                    {
                        string qString = "SELECT * FROM Student";
                        SqlCommand cmd = new SqlCommand(qString, dbConnection);
                        dbConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int StudentId = Int32.Parse(reader["StudentID"].ToString());
                                string FirstName = reader["FirstName"].ToString();
                                string LastName = reader["LastName"].ToString();
                                string GraduationYear = reader["GraduationYear"].ToString();
                                string Email = reader["Email"].ToString();
                                string Major = reader["Major"].ToString();
                                string PhoneNumber = reader["PhoneNumber"].ToString();
                                string Grade = reader["Grade"].ToString();
                                sArray[keeper++] = new Student(FirstName, LastName, GraduationYear, Grade, Email, Major, PhoneNumber);
                                Session["ArrayKeeper"] = keeper;
                                Session["StudentArray"] = sArray;
                            }
                        }

                    }
                    catch (SqlException ex)
                    {
                        lblError.Text = ex.Message;

                    }
                    finally
                    {
                        dbConnection.Close();
                        dbConnection.Dispose();
                    }

                }

            }
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            

            string FirstName = txtStudFirstN.Text.ToString();
            string LastName = txtStudLastN.Text.ToString();
            string Major = txtMajor.Text.ToString();
            string Grade = txtGrade.Text.ToString();
            string PhoneNumber = txtPhoneNumber.Text.ToString();
            string GraduationYear = txtGradYear.Text.ToString();
            string Email = txtEmail.Text.ToString();

            Student[] sArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
            sArray[keeper++] = new Student(FirstName, LastName, GraduationYear, Grade, Email, Major, PhoneNumber);
            Session["ArrayKeeper"] = keeper;
            Session["StudentArray"] = sArray;



            lstStudentList.Items.Clear();


            for (int i = 0; i < keeper; i++)
            {
                
                lstStudentList.Items.Add(sArray[i].ToString());
            }

            txtStudFirstN.Text = "";
            txtStudLastN.Text = "";
            txtMajor.Text = "";
            txtGrade.Text = "";
            txtPhoneNumber.Text = "";
            txtGradYear.Text = "";
            txtEmail.Text = "";



        }


        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            if (txtStudFirstN.Text.Equals("")&&txtEmail.Text.Equals("")&&txtGrade.Equals("")&&txtGradYear.Equals("")&&txtPhoneNumber.Equals("")
                &&txtMajor.Equals("")&&txtStudLastN.Text.Equals(""))
            {
                txtStudFirstN.Text = "Facey";
                txtStudLastN.Text = "McFaceFace";
                txtMajor.Text = "HorseBreeding";
                txtGrade.Text = "Freshman";
                txtPhoneNumber.Text = "00000000";
                txtGradYear.Text = "1900";
                txtEmail.Text = "email@email.com";
            }
            else
            {
                lblError.Text = "Please Clear Data Before Populating";
            }
        }



        protected void CommitButton_Click(object sender, EventArgs e)
        {
            Student[] sArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    for (int i = 0; i < keeper; i++)
                    {
                        string firstName = sArray[i].FirstName.ToString();
                        string lastName = sArray[i].LastName.ToString();
                        string graduationYear = sArray[i].GraduationYear.ToString();
                        string grade = sArray[i].Grade.ToString();
                        string email = sArray[i].Email.ToString();
                        string major = sArray[i].Major.ToString();
                        string phoneNumber = sArray[i].PhoneNumber.ToString();

                        string insertString = "INSERT INTO Student (FirstName, LastName, GraduationYear, Grade, Email, Major, PhoneNumber)" +
                            " VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";

                        dbConnection.Open();
                        using (SqlCommand cmd = new SqlCommand(insertString, dbConnection))
                        {

                            cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = firstName;
                            cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = lastName;
                            cmd.Parameters.Add("@param3", SqlDbType.Int).Value = graduationYear;
                            cmd.Parameters.Add("@param4", SqlDbType.NChar, 10).Value = grade;
                            cmd.Parameters.Add("@param5", SqlDbType.NVarChar, 50).Value = email;
                            cmd.Parameters.Add("@param6", SqlDbType.NChar, 10).Value = major;
                            cmd.Parameters.Add("@param7", SqlDbType.NChar, 10).Value = phoneNumber;

                            cmd.ExecuteNonQuery();

                            dbConnection.Close();


                        }
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;

                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
                

            }
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

                txtStudFirstN.Text = "";
                txtStudLastN.Text = "";
                txtMajor.Text = "";
                txtGrade.Text = "";
                txtPhoneNumber.Text = "";
                txtGradYear.Text = "";
                txtEmail.Text = "";
            lstStudentList.Items.Clear();

        }
    }
}