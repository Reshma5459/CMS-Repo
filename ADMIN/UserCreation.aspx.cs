using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication2.ADMIN
{
    public partial class UserCreation : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //{
                fillgrid();
                fillRole();
                if (Session["Role"].ToString() != "Admin")
                {
                    btnDelete.Enabled = false;
                    Gvtbl_UserCreation.Visible = false;
                }

                // }


            } 

            

        }
        protected void ClearControls()
        {
            txtUserId.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCpassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            ddlGender.Items.Insert(0, "--Select Gender--");
            ddlGender.SelectedIndex = -1;
            ddlRole.SelectedIndex = -1;



        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

       
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "select u.User_Id,u.User_Name,r.Role_Name,u.Password,u.Cpassword,u.Phone_Number,u.Email_Id,u.Gender  from tbl_UserCreation u  inner join tbl_Role r on u.Role =r.Role_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_UserCreation.DataSource = dt;
                Gvtbl_UserCreation.DataBind();

            }
            else
                Response.Write("Records Not found");



        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "Insert into tbl_UserCreation(User_Id,User_Name,Password,CPassword,Phone_Number,Email_Id,Gender,Role)values('" + txtUserId.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "','" + txtCpassword.Text + "'," + txtPhoneNumber.Text + ",'" + txtEmail.Text + "','" + ddlGender.SelectedValue + "'," + ddlRole.SelectedValue + ")";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("Record inserted Sucessfully");
                //if (Session["User"] != null)
                
                    fillgrid();
                

            }
            con.Close();

            #region "Junk Data"
            ////// Values of variables 'a' and 'b' are assigned to TextBox1 and TextBox2
            ////txtUserName.Text = a;
            ////txtPassword.Text = b;


            //// If ViewState values are not null, assign them to TextBoxes
            //if (ViewState["Username"] != null)
            //{ 

            //    txtUserName.Text = ViewState["Username"].ToString();
            //}

            //if (ViewState["phoneNumber"] != null)
            //{
            //    txtPhoneNumber.Text = ViewState["phoneNumber"].ToString();
            //}
            #endregion
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "update tbl_UserCreation  set User_Name='"+txtUserName.Text+"', Password= '" + txtPassword.Text + "',CPassword='" + txtCpassword.Text + "',Phone_Number=" + txtPhoneNumber.Text + ",Email_Id= '" + txtEmail.Text + "',Role=" + ddlRole.SelectedValue + ", Gender='" + ddlGender.SelectedItem + "' where User_Id=" + txtUserId.Text + " ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("Record Updated Sucessfully");
                fillgrid();
            }
            else
            {

                Response.Write("Error Occured while Updating");

            }
        }

      
        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select u.User_Id,u.User_Name,r.Role_Name,r.Role_id,u.Password,u.Cpassword,u.Phone_Number,u.Email_Id,u.Gender  from tbl_UserCreation u  inner join tbl_Role r on u.Role =r.Role_Id where u.User_Name='" + txtUserName.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtUserName.Text = rdr["User_Name"].ToString();
                    txtPassword.Text = rdr["Password"].ToString();
                    txtCpassword.Text = rdr["CPassword"].ToString();
                    txtPhoneNumber.Text = rdr["Phone_Number"].ToString();
                    txtEmail.Text = rdr["Email_Id"].ToString();
                    ddlGender.SelectedValue = rdr["Gender"].ToString();
                    ddlRole.SelectedValue = rdr["Role_id"].ToString();

                }
            }
            else
            {
                //ClearControls();
                Response.Write("Record Not Found");
            }

        }
        protected void fillRole()
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
                

            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "DELETE FROM tbl_UserCreation WHERE User_Name='" + txtUserName.Text + "'";
            using (SqlCommand cmd = new SqlCommand(sqlstr, con))
            {
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Deletion Successfull");
                    fillgrid();

                }
                else
                {
                    Response.Write("Deletion Failed");
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Home.aspx");
        }

        protected void Gvtbl_UserCreation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserId.Text = Gvtbl_UserCreation.SelectedRow.Cells[1].Text;
            txtUserName.Text = Gvtbl_UserCreation.SelectedRow.Cells[2].Text;
            ddlRole.SelectedItem.Text  = Gvtbl_UserCreation.SelectedRow.Cells[3].Text;
            txtPassword.Text = Gvtbl_UserCreation.SelectedRow.Cells[4].Text;
            txtCpassword.Text = Gvtbl_UserCreation.SelectedRow.Cells[5].Text;
            txtPhoneNumber.Text = Gvtbl_UserCreation.SelectedRow.Cells[6].Text;
            txtEmail.Text = Gvtbl_UserCreation.SelectedRow.Cells[7].Text;
            ddlGender.SelectedItem.Text = Gvtbl_UserCreation.SelectedRow.Cells[8].Text;
            
             
                   
        }

       
    }
}


