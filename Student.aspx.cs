using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace Lab2
{
    public partial class _Default : Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {




                var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab2"];

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
            reqFieldValidatorFirstName.Enabled = true;
            RequiredFieldValidatorEmail.Enabled = true;
            RequiredFieldValidatorGrade.Enabled = true;
            RequiredFieldValidatorGradYear.Enabled = true;
            RequiredFieldValidatorPhoneNumber.Enabled = true;
            RequiredFieldValidatorMajor.Enabled = true;
            RequiredFieldValidatorLastName.Enabled = true;



            string FirstName = txtStudFirstN.Text.ToString();
            string LastName = txtStudLastN.Text.ToString();
            string Major = txtMajor.Text.ToString();
            string Grade = txtGrade.Text.ToString();
            string PhoneNumber = txtPhoneNumber.Text.ToString();
            string GraduationYear = txtGradYear.Text.ToString();
            string Email = txtEmail.Text.ToString();


            lstStudentList.Items.Clear();


            txtStudFirstN.Text = "";
            txtStudLastN.Text = "";
            txtMajor.Text = "";
            txtGrade.Text = "";
            txtPhoneNumber.Text = "";
            txtGradYear.Text = "";
            txtEmail.Text = "";

            reqFieldValidatorFirstName.Enabled = false;
            RequiredFieldValidatorEmail.Enabled = false;
            RequiredFieldValidatorGrade.Enabled = false;
            RequiredFieldValidatorGradYear.Enabled = false;
            RequiredFieldValidatorPhoneNumber.Enabled = false;
            RequiredFieldValidatorMajor.Enabled = false;
            RequiredFieldValidatorLastName.Enabled = false;

        }


        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtStudFirstN.Text.Equals("") && txtEmail.Text.Equals("") && txtGrade.Text.Equals("") && txtGradYear.Text.Equals("") && txtPhoneNumber.Text.Equals("")
                && txtMajor.Text.Equals("") && txtStudLastN.Text.Equals(""))
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

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab2"];

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

        }

        protected void ClearListBoxButton_Click(object sender, EventArgs e)
        {
            lstStudentList.Items.Clear();

        }

        protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ltError.Text = string.Empty;            // Set error literal to empty in case of previous errors
            gvStudent.EditIndex = e.NewEditIndex;   // Set the edit index to the passed in GridViewEditEventArgs
            BindDataToGridView();                   // Bind edited data to grid

        }

        protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvStudent.Rows[e.RowIndex];
            HiddenField hdnStudentId = (HiddenField)gvRow.FindControl("hdnStudentId");
            TextBox txtFirstName = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox txtLastName = (TextBox)gvRow.Cells[2].Controls[0];
            TextBox txtGrade = (TextBox)gvRow.Cells[3].Controls[0];
            TextBox txtGraduationYear = (TextBox)gvRow.Cells[4].Controls[0];
            TextBox txtMajor = (TextBox)gvRow.Cells[5].Controls[0];
            TextBox txtPhoneNumber = (TextBox)gvRow.Cells[6].Controls[0];
            TextBox txtEmail = (TextBox)gvRow.Cells[7].Controls[0];

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab2"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Close();
                    string sql = string.Format("UPDATE Student SET FirstName='{0}', LastName='{1}', Grade='{2}', GraduationYear='{3}', Major='{4}'" +
                        ", PhoneNumber='{5}', Email='{6}' WHERE StudentID={7}", txtFirstName.Text, txtLastName.Text, txtGrade.Text, txtGraduationYear.Text,
                        txtMajor.Text, txtPhoneNumber.Text, txtEmail.Text, hdnStudentId.Value);
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvStudent.EditIndex = -1;
                    BindDataToGridView();
                }
                catch(Exception ex)
                {
                    ltError.Text = ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                }
            }


        }

        protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudent.EditIndex = -1;
            BindDataToGridView();
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab2"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Student (FirstName, LastName, Grade, GraduationYear, Major," +
                        " PhoneNumber, Email) VALUES ('', '', '', '', '', '', '')", dbConnection);
                    command.ExecuteNonQuery();
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                    ltError.Text = ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }

        }


        protected void BindDataToGridView()
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab2"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT FirstName, LastName, Grade, GraduationYear, Major, PhoneNumber, Email FROM Student ORDER BY StudentID", dbConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if(dataSet.Tables[0].Rows.Count > 0)    // Checks if there are rows present in the dataset
                    {
                        gvStudent.DataSource = dataSet;
                        gvStudent.DataBind();
                    }
                }
                catch (SqlException ex)
                {
                    ltError.Text = "Error: " + ex.Message;
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