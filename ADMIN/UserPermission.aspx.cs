using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication2.ADMIN
{
    public partial class UserPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillroles();
            }
        }

        protected void fillroles()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "Select Role_Id,Role_Name from tbl_Role order by Role_Id";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlRole.DataSource = dt;

                ddlRole.DataTextField = "Role_Name";
                ddlRole.DataValueField = "Role_Id";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, "--Select--");

            }


        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select User_Name ,User_id from tbl_UserCreation  where Role =" + ddlRole.SelectedValue + "";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlUserName.DataSource = dt;
                ddlUserName.DataTextField = "User_Name";
                ddlUserName.DataValueField = "User_id";
                ddlUserName.DataBind();
                ddlUserName.Items.Insert(0, "--Select--");

            }
        }

        protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            GvUserPermission.DataSource = null;
            GvUserPermission.DataBind();
            con.Open();
            string sqlstr = "select RoleName,UserName, ScreenName,Is_Create,Is_Update,Is_Delete,Is_View from tbl_UserPermission where UserName='" + ddlUserName.SelectedItem + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvUserPermission.DataSource = dt;
                GvUserPermission.DataBind();
               
                

            }












































            else
            {
                GvUserPermission.DataSource = null;
                GvUserPermission.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE tblUserPermission SET set Is_Create=@Is_Created, Is_Update=@Is_Updated,Is_Delete=@Is_Deleted,Is_View= = @Is_Viewd WHERE UserName=@User_Id";
                    cmd.Connection = con;
                    con.Open();
                    foreach (GridViewRow row in GvUserPermission.Rows)
                    {
                        //Get the HobbyId from the DataKey property.
                        int userId = Convert.ToInt32(GvUserPermission.DataKeys[row.RowIndex].Values[0]);

                        //Get the checked value of the CheckBox.
                        bool isCreate = (row.FindControl("chkIs_Create") as CheckBox).Checked;
                        bool isUpdate = (row.FindControl("chkIs_Create") as CheckBox).Checked;
                        bool isDelete = (row.FindControl("chkIs_Create") as CheckBox).Checked;
                        bool isView = (row.FindControl("chkIs_Create") as CheckBox).Checked;

                        //Save to database.
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Is_Created", isCreate);
                        cmd.Parameters.AddWithValue("@Is_Updated", isUpdate);
                        cmd.Parameters.AddWithValue("@Is_Deleted", isDelete);
                        cmd.Parameters.AddWithValue("@Is_Viewed", isView);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }
    }
}