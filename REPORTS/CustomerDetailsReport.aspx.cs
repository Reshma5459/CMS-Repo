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
    public partial class CustomerDetailsReport : System.Web.UI.Page
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
            if (txtCustomer_Id1.Text != "" && txtCustomer_Id2.Text == "")

                sqlstr = "select  Customer_Id,Customer_Name,Gender,Email,Address,Event_Name,Facility_Name,Membership_Type,Membership_Status from tbl_CustomerDetails where Customer_Id=" + txtCustomer_Id1.Text + "";
            else
                sqlstr = "select  Customer_Id,Customer_Name,Gender,Email,Address,Event_Name,Facility_Name,Membership_Type,Membership_Status from tbl_CustomerDetails where Customer_Id between " + txtCustomer_Id1.Text + " and " + txtCustomer_Id2.Text + "";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvCustomerReport.DataSource = dt;
                GvCustomerReport.DataBind();

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
            string FileName = "Customers Reports" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvCustomerReport.GridLines = GridLines.Both;
            GvCustomerReport.HeaderStyle.Font.Bold = true;
            GvCustomerReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerateExcelReport();
        }

        protected void GvCustomerReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

      

    }
}