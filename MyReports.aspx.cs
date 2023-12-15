using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Booth_Caroline_HW4
{
    public partial class MyReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String UserID = HttpContext.Current.User.Identity.GetUserId();
                if (UserID != null)
                {
                    ShowReports();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
//Authenticating user and redirecting to login page
        protected void ShowReports()
        {
            if (User.Identity.IsAuthenticated)
            {
                MyReportsPanel.Visible = true;
                string UserID = HttpContext.Current.User.Identity.GetUserId();
                string query = "SELECT * FROM Reports R Inner Join Projects P on P.ProjectID = R.ProjectID WHERE VolunteerID = @UserID";
                DataTable dt = new DataTable();
                string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
                using (SqlConnection conn = new SqlConnection(connString))
                {
   //authenticating user and selecting all reports where projectID is equal and the volunteer is the authenticated user                  
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                ReportsTable.DataSource = dt;
                ReportsTable.DataBind();
                
            }//binding the data 
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void User_Delete(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName =="Delete")
            {
                string ReportID = e.CommandArgument.ToString();
                DeleteReport(ReportID);
            }
        }
//this is my extra thing. I had to look this up but apparently you need e.CommandName and then it takes the ReportID and deletes that report 
        private void DeleteReport(string ReportID)
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string deleteObs = "DELETE FROM Observations WHERE ReportID = @ReportID";

                using (SqlCommand cmd = new SqlCommand(deleteObs, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }//method to delete the report used in method above. executing query 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string deleteObs = "DELETE FROM Reports WHERE ReportID = @ReportID";

                using (SqlCommand cmd = new SqlCommand(deleteObs, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    conn.Open();
                    cmd.ExecuteNonQuery();


                }//executing query where reports equal. needed to delte both report and the observations for it to run correctly 
            }

            Response.Redirect("MyReports.aspx");
        }
    } //after that redirect to MyReports 
}
