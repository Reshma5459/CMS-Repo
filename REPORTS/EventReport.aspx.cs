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
    public partial class EventReport : System.Web.UI.Page
    {
        string sqlconstr = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillEventRole();
                
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
        protected void fillEventRole()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "Select Event_Id,Event_Name from tbl_EventManagement order by Event_Id";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlEvent_Name.DataSource = dt;

                ddlEvent_Name.DataTextField = "Event_Name";
                ddlEvent_Name.DataValueField = "Event_Id";
                ddlEvent_Name.DataBind();
                ddlEvent_Name.Items.Insert(0, "-- Select Event Name --");

            }


        }

        protected void txtEvent_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Event_Id,Event_Name from tbl_EventManagement where Event_Id ="+txtEvent_Id.Text+"";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtEvent_Id.Text = rdr["Event_Id"].ToString();
                    ddlEvent_Name.SelectedItem.Text = rdr["Event_Name"].ToString();
                 }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Record Not Found')</script>");
            }
        }
        protected void ddlEvent_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (ddlEvent_Name.SelectedItem.Text != "-- Select Event Name--")

                sqlstr = "select Event_Id,Event_Name,Event_Date,Location,Organizer,Registration_DeadLine from tbl_EventManagement where Event_Name='"+ddlEvent_Name.SelectedItem+"'";
            else
                sqlstr = "select Event_Id,Event_Name,Event_Date,Location,Organizer,Registration_DeadLine from tbl_EventManagement ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvEventReport.DataSource = dt;
                ddlEvent_Name.DataTextField="Event_Id";
                ddlEvent_Name.DataValueField="Event_Name";
                GvEventReport.DataBind();
                ddlEvent_Name.Items.Insert(0,"-- Select Event Name --");

            }
            else
            {

                Response.Write("<script>alert('Record Not Found')</script>");
            }
        }

        protected void btnGetdata_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (ddlEvent_Name.SelectedItem.Text != "-- Select Event Name--")

                sqlstr = "select Event_Name,Event_Date,Location,Organizer,Registration_DeadLine from tbl_EventManagement where Event_Name='"+ddlEvent_Name.SelectedItem+"'";
            else
                sqlstr = "select Event_Name,Event_Date,Location,Organizer,Registration_DeadLine from tbl_EventManagement ";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvEventReport.DataSource = dt;
                GvEventReport.DataBind();

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
            string FileName = "Events Reports" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvEventReport.GridLines = GridLines.Both;
            GvEventReport.HeaderStyle.Font.Bold = true;
            GvEventReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

       
            
        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerateExcelReport();
        }

       // protected void GvEventReport_SelectedIndexChanged(object sender, EventArgs e)
        //{}

       
    }
}