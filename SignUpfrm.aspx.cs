using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SignUpfrm : System.Web.UI.Page
    {
        string sqlconstr = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fillgrid();

                


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
            set { /*Do nothing*/ }
        }
        protected void clearControls()
        {
            txtUserID.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEMail.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            //ddlRole.SelectedIndex = -1;


        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            //con.Open();
            string sqlstr = "select u.Id,u.UserName,u.Password,u.ConfirmPassword,u.PhoneNo,u.EMail  from tbl_Registration u  inner join tbl_Role r on u.Role =r.Role_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //GvUserDetails.DataSource = dt;
                //GvUserDetails.DataBind();
            }
            else
                

                Response.Write("<script>alert('Records Not found')</script>");


        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearControls();
            btnRegister.Text = "Register";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (btnRegister.Text == "Register")
            {
                SqlConnection con = new SqlConnection(sqlconstr);
                con.Open();
                string sqlstr = "Insert into tbl_Registration(Id,UserName,PhoneNo,EMail,Password,ConfirmPassword)values(" + txtUserID.Text + ",'" + txtUserName.Text + "'," + txtMobileNumber.Text + ",'" + txtEMail.Text + "','" + txtPassword.Text + "','" + txtConfirmPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("<script>alert('Record Inserted Sucessfully')</script>");
                    if (Session["User"] != null)
                    {
                        fillgrid();
                    }

                }
                con.Close();
            }
            else if (btnRegister.Text == "Update Profile")
            {

                SqlConnection con = new SqlConnection(sqlconstr);
                con.Open();
                string sqlstr = "update tbl_Registration set PhoneNo= " + txtMobileNumber.Text + ",EMail='" + txtEMail.Text + "',Password='" + txtPassword.Text + "',ConfirmPassword='" + txtConfirmPassword.Text + "' where UserName='" + txtUserName.Text + "' ";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("<script>alert('Record Inserted Sucessfully')</script>");
                    if (Session["User"] != null)
                    {
                        fillgrid();
                    }

                }
                con.Close();
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/frmLogin.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home.aspx");
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "select ID,UserName,PhoneNo,EMail,Password,ConfirmPassword from tbl_Registration where UserName='" + txtUserName.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtUserID.Text = rdr["ID"].ToString();
                    txtUserName.Text = rdr["UserName"].ToString();
                    txtPassword.Text = rdr["Password"].ToString();
                    txtConfirmPassword.Text = rdr["ConfirmPassword"].ToString();
                    txtMobileNumber.Text = rdr["PhoneNo"].ToString();
                    txtEMail.Text = rdr["EMail"].ToString();
                    //ddlrole.SelectedValue = rdr["Role"].ToString();
                    btnRegister.Text = "Update Profile";

                }
            }
            else
            {
                //ClearControls();
                // Response.Write("Record Not Found");
                Response.Write("<script>alert('Record Not Found')</script>");
            }
        }
    }
}