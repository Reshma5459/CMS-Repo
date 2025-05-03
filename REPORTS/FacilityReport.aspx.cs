using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WebApplication2.REPORTS
{
    public partial class FacilityReport : System.Web.UI.Page
    {
        string sqlconstr = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"].ToString() != "Admin" && Session["Role"].ToString() != "staff")
                {
                    btnReport.Enabled = false;
                    btnGetdata.Enabled = false;

                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        public override bool EnableEventValidation
        {
            get { return false; }
            // set { /Do nothing/ }
        }

        

        protected void btnGetdata_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (txtFacility_Id.Text != "")

                sqlstr = "select Facility_Id,Facility_Name,description,Available from tbl_FacilityTypeDetails where Facility_Id=" + txtFacility_Id.Text + "";
            else
                sqlstr = "select Facility_Id,Facility_Name,description,Available from tbl_FacilityTypeDetails";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvFacilityReport.DataSource = dt;
                GvFacilityReport.DataBind();

            }
            else
            {

                Response.Write("<script>alert('Record Not Found')</script>");
            }

        }
        protected void GenerateExcelReport()
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Facilities Reports" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvFacilityReport.GridLines = GridLines.Both;
            GvFacilityReport.HeaderStyle.Font.Bold = true;
            GvFacilityReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerateExcelReport();
        }
    }
}