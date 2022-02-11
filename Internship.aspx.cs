using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab1
{
    public partial class Internship : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if there is a postback 

            if (!Page.IsPostBack)
            {
                Session["InternshipArray"] = new Internship[10];
                Session["InternshipKeeper"] = 0;

                var connectionConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];
                int keeper = (int)Session["InternshipKeeper"];
                Internship[] internArray = (Internship[])Session["InternshipArray"];
                using (SqlConnection dbConnection = new SqlConnection(connectionConfiguration.ConnectionString))
                {
                    try
                    {
                        //Open the database connection 
                        string qString = "SELECT * FROM Student";
                        SqlCommand cmd = new SqlCommand(qString, dbConnection);
                        dbConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //Read the information in the database
                            while (reader.Read())
                            {
                                string type = reader["InternshipType"].ToString();
                                string start = reader["InternshipStartDate"].ToString();
                                string city = reader["InternshipCity"].ToString();
                                Session["InternshipKeeper"] = keeper;
                                Session["InternshipArray"] = internArray;
                            }    
                        }
                    }
                    catch
                    {

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

            if (txtType.Text.Equals("") && txtStart.Text.Equals("") && txtCity.Equals(""))
            {
                txtStart.Text = "January 1st";
                txtType.Text = "Academic";
                txtCity.Text = "Harrisonburg";
            }
            else
            {

            }


        }

        protected void CommitButton_Click(object sender, EventArgs e)
        {
     
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            txtType.Text = "";
            txtCity.Text = "";
            txtStart.Text = "";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //Crate the validators enabling function 
            reqFieldValidatorType.Enabled = true;
            reqFieldValidatorStart.Enabled = true;
            reqFieldValidatorCity.Enabled = true;
            //set the values
            string type = txtType.Text.ToString();
            string date = txtStart.Text.ToString();
            string city = txtCity.Text.ToString();
            //Mkes the arrays
            Internship[] internArray = (Internship[])Session["InternArray"];
            int InternshipKeeper = (int)Session["InternshipKeeper"];
            internArray[InternshipKeeper++] = new Internship(type, date, city);
            Session["InternshipKeeper"] = InternshipKeeper;
            Session["InternshipArray"] = internArray;

            lstInternList.Items.Clear();

            for (int i = 0; i < InternshipKeeper; i++)
            {
                lstInternList.Items.Add(internArray[i].ToString());
            }

            txtType.Text = "";
            txtCity.Text = "";
            txtStart.Text = "";

            reqFieldValidatorType.Enabled = false;
            reqFieldValidatorStart.Enabled = false;
            reqFieldValidatorCity.Enabled = false;
        }
    }
}