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
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CompanyArray"] = new Company[10];
                Session["CompanyKeeper"] = 0;

                var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];
                int keeper = (int)Session["CompanyKeeper"];
                Company[] cArray = (Company[])Session["CompanyArray"];
                using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
                {
                    try
                    {
                        string qString = "SELECT * FROM Company";
                        SqlCommand cmd = new SqlCommand(qString, dbConnection);
                        dbConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int employerId = Int32.Parse(reader["EmployerID"].ToString());
                                string FirstName = reader["FirstName"].ToString();
                                string LastName = reader["LastName"].ToString();
                                string MeetingTime = reader["MeetingTime"].ToString();
                                string Email = reader["Email"].ToString();
                                string CompanyName = reader["CompanyName"].ToString();
                                int memberId = Int32.Parse(reader["MemberID"].ToString());
                                int studentId = Int32.Parse(reader["StudentID"].ToString());
                                cArray[keeper++] = new Company(FirstName, LastName, CompanyName, Email, MeetingTime); 
                                Session["CompanyKeeper"] = keeper;
                                Session["StArray"] = cArray;
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

        protected void PopulateButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

            string FirstName = txtFirstName.Text.ToString();
            string LastName = txtLastName.Text.ToString();
            string meeting = txtMeeting.Text.ToString();
            string email = txtEmail.Text.ToString();
            string companyName = txtName.Text.ToString();

            Company[] cArray = (Company[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
            cArray[keeper++] = new Company(FirstName, LastName, companyName, email, MeetingTime);
            Session["CompanyKeeper"] = keeper;
            Session["CompanyArray"] = cArray;

            CompanyListBox.Items.Clear();


            for (int i = 0; i < keeper; i++)
            {

                CompanyListBox.Items.Add(cArray[i].ToString());
            }


            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMeeting.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";

        }

        protected void CommitButton_Click(object sender, EventArgs e)
        {
            //Company[] cArray = (Company[])Session["CompanyArray"];
            //int keeper = (int)Session["CompanyKeeper"];

            //var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            //using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            //{
            //    try
            //    {
            //        for (int i = 0; i < keeper; i++)
            //        {
            //            string firstName = cArray[i].FirstName.ToString();
            //            string lastName = cArray[i].LastName.ToString();
            //            string meetingTime = cArray[i].MeetingTime.ToString();
            //            string companyName = cArray[i].CompanyName.ToString();
            //            string email = cArray[i].Email.ToString();

            //            string insertString = "INSERT INTO Company (MeetingTime, CompanyName, Email, FirstName, LastName, MemberID, StudentID)" +
            //                " VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";

            //            dbConnection.Open();
            //            using (SqlCommand cmd = new SqlCommand(insertString, dbConnection))
            //            {

            //                cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = firstName;
            //                cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = lastName;
            //                cmd.Parameters.Add("@param3", SqlDbType.Int).Value = graduationYear;
            //                cmd.Parameters.Add("@param4", SqlDbType.NChar, 10).Value = grade;
            //                cmd.Parameters.Add("@param5", SqlDbType.NVarChar, 50).Value = email;
            //                cmd.Parameters.Add("@param6", SqlDbType.NChar, 10).Value = major;
            //                cmd.Parameters.Add("@param7", SqlDbType.NChar, 10).Value = phoneNumber;

            //                cmd.ExecuteNonQuery();

            //                dbConnection.Close();


            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        lblError.Text = ex.Message;

            //    }
            //    finally
            //    {
            //        dbConnection.Close();
            //        dbConnection.Dispose();
            //    }


            //}

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

        }
    }
}