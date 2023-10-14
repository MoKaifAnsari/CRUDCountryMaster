using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDCountryMaster
{
    public partial class PrintRDLC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LocalReport rep = rptReportViewer.LocalReport;
                rep.ReportPath = "PackageBookingList.rdlc";
                ReportDataSource rds = new ReportDataSource();

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection"));
                cmd = new SqlCommand("ExportPacketBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand = cmd;
                sda.Fill(dt);


                if (dt.Rows.Count > 0)
                {

                    rds.Name = "DataSet1";
                    rds.Value = dt;
                    rep.DataSources.Add(rds);
                }
            }
        }
    }
}
