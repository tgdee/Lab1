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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Student[] sArray = (Student[])Session["StudentArray"];
            int keeper = (int)Session["ArrayKeeper"];
            string FirstName = txtStudFirstN.Text.ToString();
            string LastName = txtStudLastN.Text.ToString();
            string Major = txtMajor.Text.ToString();
            string Grade = txtGrade.Text.ToString();
            string PhoneNumber = txtPhoneNumber.Text.ToString();
            string GraduationYear = txtGradYear.Text.ToString();
            string Email = txtEmail.Text.ToString();


            sArray[keeper++] = new Student();

            for (int i = 0; i < keeper; i++)
            {
                lstStudentList.Items.Add(sArray[i].ToString());
            }


        }


        

        protected void PopulateButton_Click(object sender, EventArgs e)
        {
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