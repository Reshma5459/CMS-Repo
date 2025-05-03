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
    public partial class BookingReport : System.Web.UI.Page
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
            if (txtBookingId.Text != "")

                sqlstr = "select Booking_Id,Customer_Id,Customer_Name,Event_Name,Booking_Date,Start_Time,End_Time,Booking_Status,PaymentAmount,PaymentMethod from tbl_BookingDetails where Booking_Id =" + txtBookingId.Text + "";
            else
                sqlstr = "select Booking_Id,Customer_Id,Customer_Name,Event_Name,Booking_Date,Start_Time,End_Time,Booking_Status,PaymentAmount,PaymentMethod from tbl_BookingDetails";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvBookingsReport.DataSource = dt;
                GvBookingsReport.DataBind();

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
            string FileName = "Bookings Reports" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvBookingsReport.GridLines = GridLines.Both;
            GvBookingsReport.HeaderStyle.Font.Bold = true;
            GvBookingsReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }


        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerateExcelReport();
        }
    }
}