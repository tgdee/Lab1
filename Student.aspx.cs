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
                Session["StudentList"] = new List<Student>();
                Session["ArrayKeeper"] = 0;

            }
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {

            string studfName = txtStudFirstN.Text.ToString();
            string studlName = txtStudLastN.Text.ToString();
            string studMajor = txtMajor.Text.ToString();
            string studGradYear = txtGradYear.Text.ToString();
            string studAcademicYear = txtGrade.Text.ToString();
            string studEmail = txtEmail.Text.ToString();
            string grade = txtGrade.Text.ToString();
            string phoneNum = txtPhoneNumber.Text.ToString();

            int keeper = (int)Session["ArrayKeeper"];
            List<Student> studentList = (List<Student>)Session["StudentList"];

            studentList.Add(new Student(1, studfName, studlName, studGradYear, grade, studEmail,
                1, 1, studMajor));

            Session["StudentArray"] = studentList;

            lstStudentList.Items.Clear();

            for( int i = 0; i < studentList.Count; i++)
            {
                lstStudentList.Items.Add(studentList[i].ToString());            
            }

            txtStudFirstN.Text = "";
            txtStudLastN.Text = "";
            txtEmail.Text = "";
            txtGrade.Text = "";
            txtGradYear.Text = "";
            txtPhoneNumber.Text = "";
            txtMajor.Text = "";



        }

        protected void PopulateButton_Click(object sender, EventArgs e)
        {

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



        //}
    }
}