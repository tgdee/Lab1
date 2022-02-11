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
    public partial class MemberTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //As the page loads we want to create an array of members
                Session["MemberArray"] = new Member[10];
                Session["MArrayKeeper"] = 0;

                var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];
                int keeper = (int)Session["MArrayKeeper"];
                Member[] mArray = (Member[])Session["MemberArray"];

                using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
                {
                    try
                    {
                        string qString = "SELECT * FROM Member";
                        SqlCommand cmd = new SqlCommand(qString, dbConnection);
                        dbConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int MemberID = Int32.Parse(reader["MemberID"].ToString());
                                string FirstName = reader["FirstName"].ToString();
                                string LastName = reader["LastName"].ToString();
                                string Email = reader["Email"].ToString();
                                mArray[keeper++] = new Member(FirstName, LastName, Email);
                                Session["MArrayKeeper"] = keeper;
                                Session["MemberArray"] = mArray;
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
            if (txtEmail.Text.Equals("") && txtFirstName.Text.Equals("") && txtLastName.Text.Equals(""))
            {
                txtFirstName.Text = "John";
                txtLastName.Text = "Doe";
                txtEmail.Text = "email@email.com";
            }
            else
            {
                lblError.Text = "Please Clear Values Before Populating";
            }


        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.ToString();
            string lastName = txtLastName.Text.ToString();
            string email = txtEmail.Text.ToString();

            Member[] mArray = (Member[])Session["MemberArray"];
            int keeper = (int)Session["MArrayKeeper"];

            mArray[keeper++] = new Member(firstName, lastName, email);

            Session["ArrayKeeper"] = keeper;
            Session["MemberArray"] = mArray;

            for (int i = 0; i < keeper; i++)
            {
                lbMember.Items.Add(mArray[i].ToString());
            }

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";


        }

        protected void CommitButton_Click(object sender, EventArgs e)
        {
            Member[] mArray = (Member[])Session["MemberArray"];
            int keeper = (int)Session["MArrayKeeper"];

            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["Lab1"];

            using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    for (int i = 0; i < keeper; i++)
                    {
                        string firstName = mArray[i].FirstName.ToString();
                        string lastName = mArray[i].LastName.ToString();
                        string email = mArray[i].Email.ToString();

                        string insertString = "INSERT INTO Member (FirstName, LastName, Email)" +
                            " VALUES (@param1, @param2, @param3)";

                        dbConnection.Open();
                        using (SqlCommand cmd = new SqlCommand(insertString, dbConnection))
                        {
                            cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = firstName;
                            cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 50).Value = lastName;
                            cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = email;

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
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            lbMember.Items.Clear();

        }
    }
}