using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using Newtonsoft.Json.Linq;

namespace Booth_Caroline_HW4
{
    public partial class ResearchAreas : System.Web.UI.Page
    {
        public DataTable GetDataFromDatabase(string idValue)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query;
                SqlCommand cmd;
                
                //this one uses the ID to get research areas 

                if (!string.IsNullOrEmpty(idValue))
                {
                    
                    query = "EXEC sp_GetInstitutionResearchAreas @IDValue";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDValue", idValue);
                }
                else
                {
                  //all research areas if no value is given for ID
                    query = "EXEC sp_GetAllResearchAreas";
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
                Research.DataSource = GetDataFromDatabase(idValue);
                Research.DataBind();
            }
        }
    }
}



           
                 
             