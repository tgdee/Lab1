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
                            int EmployerId = Int32.Parse(reader["EmployerID"].ToString());
                            int InternshipNumber = Int32.Parse(reader["InternshipNumber"].ToString());
                            string Grade = reader["Grade"].ToString();
                            sArray[keeper++] = new Student(StudentId, FirstName, LastName, GraduationYear, Grade, Email, EmployerId, InternshipNumber, Major);
                            Session["ArrayKeeper"] = keeper;
                            Session["StudentArray"] = sArray;
                        }
                    }
                }


            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Student[] sArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
            string fName = txtStudFirstN.Text.ToString();
            string lName = txtStudLastN.Text.ToString();
            string major = txtMajor.Text.ToString();
            string grade = txtGrade.Text.ToString();
            string phoneNumber = txtPhoneNumber.Text.ToString();
            string gradYear = txtGradYear.Text.ToString();
            string email = txtEmail.Text.ToString();
            string graduationYear = txtGradYear.Text.ToString();

            sArray[keeper++] = new Student()


        }

        

        protected void PopulateButton_Click(object sender, EventArgs e)
        {

            Student[] sArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
            for(int i = 0; i < keeper; i++)
            {
                lstStudentList.Items.Add(sArray[i].ToString());
            }
            
        }



        protected void BindDataToGridView()
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT StudentID, FirstName, LastName FROM Student ORDER BY StudentID", dbConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
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

        protected void gvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ltError.Text = string.Empty;    // Set error text to empty in case there was error already there 
            gvStudent.EditIndex = e.NewEditIndex; // The new edit index is what is passed into e parameter
            BindDataToGridView();
        }

        protected void gvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvStudent.Rows[e.RowIndex];
            HiddenField hdnStudentId = (HiddenField)gvRow.FindControl("hdnStudentId");
            TextBox TxtFirstName = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox TxtLastName = (TextBox)gvRow.Cells[2].Controls[0];

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = string.Format("UPDATE Student SET FirstName='{0}', LastName='{1}' WHERE StudentId={2}", TxtFirstName.Text, TxtLastName.Text, hdnStudentId.Value);
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvStudent.EditIndex = -1;   // By setting editing index to -1 means we are no longer editing
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

        protected void gvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvStudent.EditIndex = -1;
            BindDataToGridView();
        }
        protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvStudent.Rows[e.RowIndex];
            HiddenField hdnStudentId = (HiddenField)gvRow.FindControl("hdnStudentId");

            var connetionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connetionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = string.Format("DELETE FROM Student WHERE StudentID={0}", hdnStudentId.Value);
                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvStudent.EditIndex = -1;
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

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Student (FirstName, LastName) VALUES ('', '')", dbConnection);
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



        protected void CommitButton_Click(object sender, EventArgs e)
        {

        }



        //    protected void CommitButton_Click(object sender, EventArgs e)
        //    {
        //        var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

        //        using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
        //        {
        //            try
        //            {
        //                dbConnection.Open();
        //                string sql = string.Format("UPDATE Student SET FirstName='{0}', LastName='{1}' WHERE StudentId={2}", TxtFirstName.Text, TxtLastName.Text, hdnStudentId.Value);
        //                SqlCommand command = new SqlCommand(sql, dbConnection);
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            finally
        //            {
        //                dbConnection.Close();
        //                dbConnection.Dispose();
        //            }


        //        }

        //    //protected void PopulateButton_Click(object sender, EventArgs e)
        //    //{
        //    //    string sqlQuery = "Select * from dbo.Student";

        //    //    // Define the connection to the DB
        //    //    SqlConnection sqlConnect = new SqlConnection
        //    //        (WebConfigurationManager.ConnectionStrings
        //    //        ["Lab1"].ConnectionString);

        //    //    // Create the SQL Command Itself
        //    //    SqlCommand sqlCommand = new SqlCommand();
        //    //    sqlCommand.Connection = sqlConnect;
        //    //    sqlCommand.CommandType = CommandType.Text;
        //    //    sqlCommand.CommandText = sqlQuery;

        //    //    // Issue the query and retrieve the results
        //    //    sqlConnect.Open();
        //    //    SqlDataReader queryResults = sqlCommand.ExecuteReader();

        //    //    // Fill the ListBox with the query's Results
        //    //    while (queryResults.Read())
        //    //    {
        //    //        lstStudentsManual.Items.Add(queryResults["StudentID"].ToString() + " - "
        //    //            + queryResults["FirstName"].ToString()
        //    //            + " " + queryResults["LastName"].ToString() + " " + queryResults["Email"].ToString());
        //    //    }

        //    //    sqlConnect.Close();
        //    //    queryResults.Close();


        //    //}

        //    //protected void lstStudentsAuto_SelectedIndexChanged(object sender, EventArgs e)
        //    //{
        //    //    lblSelectedIndex.Text = lstStudentsAuto.SelectedValue;
        //    //}

        //    //protected void PopulateButton_Click(object sender, EventArgs e)
        //    //{
        //    //    var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

        //    //    using(SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
        //    //    {
        //    //        try
        //    //        {
        //    //            dbConnection.Open();
        //    //            SqlCommand command = new SqlCommand("SELECT StudentID, FirstName, LastName, GraduationYear, AcademicYear," +
        //    //                "Email, EmployerID, InternshipNumber FROM Student ORDER BY StudentID", dbConnection);
        //    //            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //    //            DataTable dataTable = new DataTable();
        //    //            dataAdapter.Fill(dataTable);
        //    //            for(int i = 0; i < dataTable.Rows.Count; i++)
        //    //            {
        //    //                string studentId = dataTable.Rows[i]["StudentID"].ToString();
        //    //                string firstName = dataTable.Rows[i]["FirstName"].ToString();
        //    //                string lastName = dataTable.Rows[i]["LastName"].ToString();
        //    //                string graduationYear = dataTable.Rows[i]["GraduationYear"].ToString();
        //    //                string academicYear = dataTable.Rows[i]["Email"].ToString();
        //    //                string empId = dataTable.Rows[i]["EmployerID"].ToString();
        //    //                string intNum = dataTable.Rows[i]["InternshipNumber"].ToString();
        //    //                Student studentObj = new Student(studentId, firstName, lastName, graduationYear, grade,
        //    //                    email, empId, intNum, major);
        //    //                    )

        //    //            }
        //    //        }
        //    //    }
        //    //}
    }
}