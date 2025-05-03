using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.MASTER
{
    public partial class MembershipTypeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillgrid();
                if (Session["Role"].ToString() != "Admin" && Session["Role"].ToString() != "staff")
                {
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                    buttonUpdate.Enabled = false;
                    Gvtbl_MembershipTypeDetails.Visible = false;
                }
            }
        }
        protected void ClearControls()
        {
            txtMembership_Id.Text = string.Empty;
            ddlMembership_Type.Items.Insert(0, "--Select Membership--");
            ddlMembership_Type.SelectedIndex = -1;
            txtBenefits.Text = string.Empty;
            txtFees.Text = string.Empty; 
            //ddlFees.Items.Insert(0, "--Select Fees--");
            //ddlFees.SelectedIndex = -1;
            //ddlBenefits.Items.Insert(0, "--Select Membership--");
            //ddlBenefits.SelectedIndex=-1;
            chkMembership_Status.Checked = false;
           
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "select Membership_Id,Membership_Type,Membership_Status,Fees,Benefits from tbl_MembershipTypeDetails;";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Session["mtype"] = dt;
            if (dt.Rows.Count > 0)
            {
                Gvtbl_MembershipTypeDetails.DataSource = dt;
                Gvtbl_MembershipTypeDetails.DataBind();

            }
            else
                Response.Write("<script>alert('Records Not found')</script>");


        }
        protected void txtMembership_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "  select Membership_Id,Membership_Type,Membership_Status,Fees,Benefits from tbl_MembershipTypeDetails where Membership_Id=" + txtMembership_Id.Text + "";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtMembership_Id.Text = rdr["Membership_Id"].ToString();
                    ddlMembership_Type.Text = rdr["Membership_Type"].ToString();
                    txtFees .Text = rdr["Fees"].ToString();
                    txtBenefits.Text = rdr["Benefits"].ToString();
                    
                   }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Record Not Found')</script>");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            int status;
            
            if (chkMembership_Status.Checked == true)
                status = 1;
            else
                status = 0;

            

            string sqlstr = "Insert into tbl_MembershipTypeDetails(Membership_Id,Membership_Type,Membership_Status,Fees,Benefits)values(" + txtMembership_Id.Text + ",'" + ddlMembership_Type.SelectedItem + "','" + status + ",'"+txtFees.Text+"','"+txtBenefits.Text+"')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record inserted Sucessfully')</script>");
                //if (Session["User"] != null)

                fillgrid();


            }
            con.Close();

            #region "Junk Data"

            #endregion
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            int status;

            if (chkMembership_Status.Checked == true)
                status = 1;
            else
                status = 0;
            string sqlstr = "update tbl_MembershipTypeDetails set  Membership_Id = '" + txtMembership_Id.Text + "',Membership_Type='" + ddlMembership_Type.SelectedItem + "',Fees= '" + txtFees.Text + "',Benefits='" + txtBenefits.Text + "', Membership_Status=" + status + "  where Membership_Id='" + txtMembership_Id.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record Updated Sucessfully')</script>");
                fillgrid();
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
            string sqlstr = "DELETE FROM tbl_MembershipTypeDetails WHERE Membership_Id='" + txtMembership_Id.Text + "'";
            using (SqlCommand cmd = new SqlCommand(sqlstr, con))
            {
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("<script>alert('Deletion Successfull')</script>");
                    fillgrid();

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

        protected void Gvtbl_MembershipTypeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMembership_Id.Text = Gvtbl_MembershipTypeDetails.SelectedRow.Cells[1].Text;
            ddlMembership_Type.SelectedItem.Text = Gvtbl_MembershipTypeDetails.SelectedRow.Cells[2].Text;
            if (Gvtbl_MembershipTypeDetails.SelectedRow.Cells[3].Text == "1")

                chkMembership_Status.Checked = true;
            else
                chkMembership_Status.Checked = false; 
            txtFees.Text = Gvtbl_MembershipTypeDetails.SelectedRow.Cells[4].Text;
            txtBenefits.Text = Gvtbl_MembershipTypeDetails.SelectedRow.Cells[5].Text;
        }

        protected void ddlMembership_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Session["mtype"] as DataTable;
            DataRow[] dr = dt.Select("Membership_Type= '" + ddlMembership_Type.SelectedItem.Text.Trim() + "'");
            foreach (DataRow row in dr)
            {
                txtBenefits.Text = row["Benefits"].ToString();
                txtFees.Text = row["Fees"].ToString(); 
            
            }
        }
    }
}