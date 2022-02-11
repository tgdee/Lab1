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
    public partial class MentoringProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                string selectedText = StudentDropDownList.DataTextField;
                SetStudentLabel(selectedText);

            }

        }

        protected void SetStudentLabel(string value)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    string qString = "SELECT FirstName, LastName FROM Student WHERE StudentID=" + value;
                    SqlCommand cmd = new SqlCommand(qString, dbConnection);
                    dbConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentName.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    dbConnection.Close();
                    lblError.Text = ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }

            }
        }






        protected void PopulateButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void CommitButton_Click(object sender, EventArgs e)
        {

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {

        }

        protected void MentorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void StudentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStudentLabel(StudentDropDownList.SelectedItem.ToString());

        }
    }
}
