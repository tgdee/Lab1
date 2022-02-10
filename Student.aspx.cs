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
        private List<Student> studentList = new List<Student>();
        
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataToGridView();
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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int keeper = (int)Session["ArrayKeeper"];

            String studfName = txtStudFirstN.Text.ToString();
            String studlName = txtStudLastN.Text.ToString();
            String studMajor = txtMajor.Text.ToString();
            int studGradYear = int.Parse(intGradYear.Text);
            string studAcademicYear = txtGrade.Text.ToString();
            String studEmail = txtEmail.Text.ToString();

           // Student object created using text field data
          Student studentObj = new Student(1, studfName, studlName, studGradYear, studAcademicYear, studEmail,
               1, 1, studMajor);

            //Student object added to studentList
            studentList.Add(studentObj);



            //Reference the stored array and use type cast to store as object
            Student[] stuArray = (Student[])Session["StudentArray"];

        }

        //protected void CommitButton_Click(object sender, EventArgs e)
        //{
        //    // List is sent to database

        //}

        //protected void PopulateButton_Click(object sender, EventArgs e)
        //{
        //    string sqlQuery = "Select * from dbo.Student";

        //    // Define the connection to the DB
        //    SqlConnection sqlConnect = new SqlConnection
        //        (WebConfigurationManager.ConnectionStrings
        //        ["Lab1"].ConnectionString);

        //    // Create the SQL Command Itself
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Connection = sqlConnect;
        //    sqlCommand.CommandType = CommandType.Text;
        //    sqlCommand.CommandText = sqlQuery;

        //    // Issue the query and retrieve the results
        //    sqlConnect.Open();
        //    SqlDataReader queryResults = sqlCommand.ExecuteReader();

        //    // Fill the ListBox with the query's Results
        //    while (queryResults.Read())
        //    {
        //        lstStudentsManual.Items.Add(queryResults["StudentID"].ToString() + " - "
        //            + queryResults["FirstName"].ToString()
        //            + " " + queryResults["LastName"].ToString() + " " + queryResults["Email"].ToString());
        //    }

        //    sqlConnect.Close();
        //    queryResults.Close();


        //}

        //protected void lstStudentsAuto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblSelectedIndex.Text = lstStudentsAuto.SelectedValue;
        //}

        protected void PopulateButton_Click(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using(SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT StudentID, FirstName, LastName, GraduationYear, AcademicYear," +
                        "Email, EmployerID, InternshipNumber FROM Student ORDER BY StudentID", dbConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    for(int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string studentId = dataTable.Rows[i]["StudentID"].ToString();
                        string firstName = dataTable.Rows[i]["FirstName"].ToString();
                        string lastName = dataTable.Rows[i]["LastName"].ToString();
                        string graduationYear = dataTable.Rows[i]["GraduationYear"].ToString();
                        string academicYear = dataTable.Rows[i]["Email"].ToString();
                        
                        
                    }
                }
            }
        }

        

    }
}