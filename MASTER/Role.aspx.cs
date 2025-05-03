using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace WebApplication2.MASTER
{
    public partial class Role : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //{
                
                fillRole();
                if (Session["Role"].ToString() != "Admin")
                {
                    btnDelete.Enabled = false;
                    Gvtbl_Role.Visible = false;
                }
                // }


            }
        }
        
        protected void txtRoleId_TextChanged(object sender, EventArgs e)
        { 
             
        
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Role_Id,Role_Name  from tbl_Role where Role_id="+ txtRole_Id.Text  +" or Role_Name='"+ txtRole_Name.Text  +"'";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtRole_Id.Text = rdr["Role_Id"].ToString();
                    txtRole_Name.Text = rdr["Role_Name"].ToString();
                   

                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Record Not Found')</script>");
            }

       
        }
        protected void fillRole()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "Select Role_Id,Role_Name,IsActive from tbl_Role order by Role_Id";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_Role.DataSource = dt;
                Gvtbl_Role.DataBind();

            }
        }

        protected void ClearControls()
        {
            txtRole_Id.Text = string.Empty;
            txtRole_Name.Text = string.Empty;
            chkIsActive.Text = string.Empty;



        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "insert into tbl_Role (Role_Id,Role_Name) values('"+txtRole_Id.Text+"','"+txtRole_Name.Text+"')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record inserted Sucessfully')</script>");
                //if (Session["User"] != null)
                
                    fillRole();
                

            }
            con.Close();

            #region "Junk Data"
           
            #endregion
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "update tbl_Role  set Role_Name='" + txtRole_Name.Text + "' where Role_Id='" + txtRole_Id.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record Updated Sucessfully')</script>");
                fillRole();
            }
            else
            {

                Response.Write("<script>alert('Error Occured while Updating')</script>");

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "DELETE FROM tbl_Role WHERE Role_Id='" + txtRole_Id.Text + "'";
            using (SqlCommand cmd = new SqlCommand(sqlstr, con))
            {
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("<script>alert('Deletion Successfull')</script>");
                    fillRole();

                }
                else
                {
                    Response.Write("<script>alert('Deletion Failed')</script>");
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Home.aspx");
        }

        protected void Gvtbl_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRole_Id.Text = Gvtbl_Role.SelectedRow.Cells[1].Text;
            txtRole_Name.Text = Gvtbl_Role.SelectedRow.Cells[2].Text;
            if (Gvtbl_Role.SelectedRow.Cells[3].Text == "1")

                chkIsActive.Checked = true;
            else
                chkIsActive.Checked = false; 
        }

    }
}