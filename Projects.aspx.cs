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
    public partial class Projects : System.Web.UI.Page
    {
        public DataTable LoadProjectDetails(string idValue)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query;
                SqlCommand cmd;

                if (!string.IsNullOrEmpty(idValue))
                {

                    query = "EXEC sp_GetAllProjects @IDValue";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDValue", idValue);
                }
                else
                {

                    query = "EXEC sp_GetAllProjects";
                    cmd = new SqlCommand(query, conn);
                }

                using (cmd)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }


            }

            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idValue = Request.QueryString["ID"];
                if (string.IsNullOrEmpty(idValue))
                {
                    Response.Redirect("ResearchAreas.Aspx");
                }
                else
                {
                   Project.DataSource = LoadProjectDetails(idValue);
                    Project.DataBind();
                }
            }
        }
    }
}    
    
