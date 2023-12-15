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
                
            }
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
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string deleteObs = "DELETE FROM Reports WHERE ReportID = @ReportID";

                using (SqlCommand cmd = new SqlCommand(deleteObs, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    conn.Open();
                    cmd.ExecuteNonQuery();


                }
            }

            Response.Redirect("MyReports.aspx");
        }
    }
}