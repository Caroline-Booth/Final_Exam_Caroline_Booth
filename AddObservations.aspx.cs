using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Booth_Caroline_HW4
{
    public partial class AddObservations : System.Web.UI.Page
    {
        //page load method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //retrieves the reportID value URL
                string reportID = Request.QueryString["reportID"];
               
                //displays reportID on page
                lblReportID.Text = reportID;
            }
        }
        //save observation to database
        private void SaveObservation(string reportID, string notes)
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            DateTime observedDate = DateTime.Now; //current date and time
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "Insert into Observations (ReportID, Notes, ObservedDate) VALUES (@ReportID, @Notes, @ObservedDate); SELECT SCOPE_IDENTITY();";
                //inserting data 
                using (SqlCommand cmd= new SqlCommand(sql, conn))
                {
                    //parameters
                    cmd.Parameters.AddWithValue("@ReportID", reportID);
                    cmd.Parameters.AddWithValue("@Notes", notes);
                    cmd.Parameters.AddWithValue("ObservedDate", observedDate);

                    conn.Open();
                    //executes and converts to int (had to look this up)
                    int newObservationID = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
        }

        protected void SubmitObservation_Click(object sender, EventArgs e)
        {
            string reportID = lblReportID.Text;
            string observationNotes = txtObservationNotes.Text;

            SaveObservation(reportID, observationNotes);

            Response.Redirect("reports.aspx?ID=" + reportID); //button click method ; calls method and redirects 
        }
    } 

}