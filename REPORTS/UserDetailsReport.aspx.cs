using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.REPORTS
{
    public partial class UserDetailsReport : System.Web.UI.Page
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
        protected void txtUser_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "select USER_ID,USER_NAME,Password,CPassword,Phone_Number,Email_Id,r.Role_Name from tbl_UserCreation u inner join tbl_Role r on r.Role_Id=u.Role  where u.User_Id='" + txtUser_Id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    txtUserName.Text = rdr["User_Name"].ToString();
                }
               

            }
            else
            {

                Response.Write("<script>alert('Record Not Found')</script>");
            }
        }


       

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerateExcelReport();
        }
        protected void GenerateExcelReport()
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Users Reports" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvUsersReport.GridLines = GridLines.Both;
            GvUsersReport.HeaderStyle.Font.Bold = true;
            GvUsersReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnGetdata_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (txtUserName.Text != "")

                sqlstr = "select USER_ID,USER_NAME,Password,CPassword,Phone_Number,Email_Id,r.Role_Name from tbl_UserCreation u inner join tbl_Role r on r.Role_Id=u.Role  where u.User_Id='" + txtUser_Id.Text + "'";
            else
                sqlstr = "select USER_ID,USER_NAME,Password,CPassword,Phone_Number,Email_Id,r.Role_Name from tbl_UserCreation u inner join tbl_Role r on r.Role_Id=u.Role ";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvUsersReport.DataSource = dt;
                GvUsersReport.DataBind();

            }
            else
            {

                Response.Write("<script>alert('Record Not Found')</script>");
            }
        }

       
    }
}
    
