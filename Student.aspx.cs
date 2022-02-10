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
            }
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int keeper = (int)Session["ArrayKeeper"];

            
            string studfName = txtStudFirstN.Text.ToString();
            string studlName = txtStudLastN.Text.ToString();
            string studMajor = txtMajor.Text.ToString();
            int studGradYear = int.Parse(intGradYear.Text);
            string studAcademicYear = txtGrade.Text.ToString();
            string studEmail = txtEmail.Text.ToString();
            string grade = 

           // Student object created using text field data


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

        //protected void PopulateButton_Click(object sender, EventArgs e)
        //{
        //    var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

        //    using(SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
        //    {
        //        try
        //        {
        //            dbConnection.Open();
        //            SqlCommand command = new SqlCommand("SELECT StudentID, FirstName, LastName, GraduationYear, AcademicYear," +
        //                "Email, EmployerID, InternshipNumber FROM Student ORDER BY StudentID", dbConnection);
        //            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //            DataTable dataTable = new DataTable();
        //            dataAdapter.Fill(dataTable);
        //            for(int i = 0; i < dataTable.Rows.Count; i++)
        //            {
        //                string studentId = dataTable.Rows[i]["StudentID"].ToString();
        //                string firstName = dataTable.Rows[i]["FirstName"].ToString();
        //                string lastName = dataTable.Rows[i]["LastName"].ToString();
        //                string graduationYear = dataTable.Rows[i]["GraduationYear"].ToString();
        //                string academicYear = dataTable.Rows[i]["Email"].ToString();
        //                string empId = dataTable.Rows[i]["EmployerID"].ToString();
        //                string intNum = dataTable.Rows[i]["InternshipNumber"].ToString();
        //                Student studentObj = new Student(studentId, firstName, lastName, graduationYear, grade,
        //                    email, empId, intNum, major);
        //                    )

        //            }
        //        }
        //    }
        //}

        

    }
}