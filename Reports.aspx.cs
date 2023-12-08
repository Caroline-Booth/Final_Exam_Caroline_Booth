using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Booth_Caroline_HW4
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //page load method 
            string ReportID = Request.QueryString["ID"]; //checks if reportID is not null
            if (ReportID != null)
            {
                
                Session["ReportID"] = ReportID;
                //stores ReportID in session variable
            }
            else
            {
                CreateReport(); //create new report
            }
            ShowObservation(); //display ibservation 

        }
        protected void ShowObservation()
        {
            if (User.Identity.IsAuthenticated) //is user authenticated
            {
                DataTable dt = new DataTable();

                string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
                string ReportID = Session["ReportID"] as string;
                string query = "SELECT * FROM Observations WHERE ReportID = @ReportID";
                //select all observations for reportID
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", ReportID);
                        cmd.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                ObservationTable.DataSource = dt;
                ObservationTable.DataBind();
                ObservationTablePanel.Visible = true; //binds datato obstable
            }
            else
            {
                Response.Redirect("Login.aspx"); //if not logged in redirect
            }

        }
        private void CreateReport()
        {

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            string userId = HttpContext.Current.User.Identity.GetUserId();
            string ProjectID = Session["ProjectID"] as string;
            //ProjectID and userID are not null

            if (ProjectID != null & userId != null)
            {

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    //executes stored proc
                    using (SqlCommand cmd = new SqlCommand("spCreateNewReport", conn))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                        cmd.Parameters.AddWithValue("@VolunteerID", userId);

                        cmd.Parameters.Add("@ReportID", SqlDbType.Int);
                        cmd.Parameters["@ReportID"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        Session["ReportID"] = cmd.Parameters["@ReportID"].Value.ToString();
                    }
                }
            }
            else
            {
                errorMsgPan.Visible = true;
            }
        }

        protected void btnStartNewObservation_Click(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Retrieve product ID from the query string
                string projectId = Request.QueryString["id"];

                // Redirect 
                Response.Redirect("AddObservations.aspx?reportID=" + Session["ReportID"]);
            }
        }
    }
}