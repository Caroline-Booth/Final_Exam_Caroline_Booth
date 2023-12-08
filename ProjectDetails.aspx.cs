using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Booth_Caroline_HW4
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        private void LoadProjectDetails(string projectID)
        {

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "EXEC sp_ProjectDetailsByProject @projectID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("projectID", projectID);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblProjectName.Text = reader["ProjectName"].ToString();
                    lblStartDate.Text = reader["StartDate"].ToString();
                    lblEndDate.Text = reader["EndDate"].ToString();
                    lblDescription.Text = reader["Description"].ToString();
                }

                reader.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string projectID = Request.QueryString["id"];
                if(string.IsNullOrEmpty(projectID))
                {
                        Response.Redirect("Default.aspx");
                } else
                {
                    LoadProjectDetails(projectID);
                    Session["ProjectID"] = projectID;
                }
            }
        }
        protected void btnStartNewReport_Click(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Retrieve product ID from the query string
                string projectId = Request.QueryString["id"];

                // Redirect to the Reports page
                Response.Redirect("Reports.aspx?projectID=" + projectId);
            }
        }
    }
}
    
