using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication2
{
    public partial class frmLogin : System.Web.UI.Page
    {
        string sqlconn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(sqlconn);
                con.Open();
                string sqlstr = "select r.Role_Name,User_Name from tbl_UserCreation u inner join tbl_Role r on u.Role =r.Role_Id where User_Name='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                string role = Convert.ToString(cmd.ExecuteScalar());
                if (role != "")
                {
                    Session["Role"] = role;
                    string homepage = @"~\Home.aspx";
                    Response.Redirect(homepage);

                }
                else
                    Response.Write("<script>alert('Plz Enter Correct UserName and Password')</script >");




            }
            else
                Response.Write("<script>alert('Plz Enter UserName and password')</script>");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {

        }
    }

    }

