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

            }
        }

        protected int NumberOfRows()
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];
            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                int count = 0;
                try
                {
                    
                    string qString = "SELECT * FROM Student";
                    SqlCommand cmd = new SqlCommand(qString, dbConnection);
                    dbConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count++;
                            
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
                return count;

            }

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int count = NumberOfRows();
            string FirstName = txtStudFirstN.Text.ToString();
            string LastName = txtStudLastN.Text.ToString();
            string Major = txtMajor.Text.ToString();
            string Grade = txtGrade.Text.ToString();
            string PhoneNumber = txtPhoneNumber.Text.ToString();
            string GraduationYear = txtGradYear.Text.ToString();
            string Email = txtEmail.Text.ToString();

            Student[] sArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
            sArray[keeper++] = new Student(++count, FirstName, LastName, GraduationYear, Grade, Email, Major, PhoneNumber);

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
                            sArray[keeper++] = new Student(StudentId, FirstName, LastName, GraduationYear, Grade, Email, Major, PhoneNumber);
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
                        string studentId = sArray[i].StudentId.ToString();
                        string firstName = sArray[i].FirstName.ToString();
                        string lastName = sArray[i].LastName.ToString();
                        string graduationYear = sArray[i].GraduationYear.ToString();
                        string grade = sArray[i].Grade.ToString();
                        string email = sArray[i].Email.ToString();
                        string major = sArray[i].Major.ToString();
                        string phoneNumber = sArray[i].PhoneNumber.ToString();

                        string insertString = "INSERT INTO Student (StudentID, FirstName, LastName, GraduationYear, Grade, Email, Major, PhoneNumber)" +
                            " VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";

                        dbConnection.Open();
                        using(SqlCommand cmd = new SqlCommand(insertString, dbConnection))
                        {
                            cmd.Parameters.Add("@param1", SqlDbType.Int).Value = studentId;
                            cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = firstName;
                            cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = lastName;
                            cmd.Parameters.Add("@param4", SqlDbType.Int).Value = graduationYear;
                            cmd.Parameters.Add("@param5", SqlDbType.NChar, 10).Value = grade;
                            cmd.Parameters.Add("@param6", SqlDbType.NVarChar, 50).Value = email;
                            cmd.Parameters.Add("@param7", SqlDbType.NChar, 10).Value = major;
                            cmd.Parameters.Add("@param8", SqlDbType.NChar, 10).Value = phoneNumber;

                            cmd.ExecuteNonQuery();

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

    }
}