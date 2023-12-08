using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Booth_Caroline_HW4
{
    public partial class _Default : Page
    {
        public DataTable GetDataFromDatabase()
        {
            DataTable dt = new DataTable();
            //connection to the database 
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString)) 
            {
                string query = "EXEC sp_GetAllInstitutions"; //stored procedure
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
                Institutions.DataSource = GetDataFromDatabase();
                Institutions.DataBind(); //bind data and load page 
        }
            
        
    }
}