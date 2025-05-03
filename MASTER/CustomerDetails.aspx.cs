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
    public partial class CustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillgrid();
                if (Session["Role"].ToString() != "Admin")
                {
                    btnDelete.Enabled = false;
                    Gvtbl_CustomerDetails.Visible = false;
                }

            }

        }
        protected void ClearControls()
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtDate_Of_Birth.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlEvent_Name.Items.Insert(0, "--Select Event--");
            ddlEvent_Name.SelectedIndex = -1;
            ddlFacility_Name.Items.Insert(0, "--Select Facility--");
            ddlFacility_Name.SelectedIndex = -1;
            ddlMembership_Type.Items.Insert(0, "--Select Membership--");
            ddlMembership_Type.SelectedIndex = -1;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            chkMembershipStatus.Checked = false;



        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }


        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "select Customer_Id,Customer_Name,Date_Of_Brith,Gender,Phone,Email,Address,Event_Name,Facility_Name,Membership_type,Membership_Status from tbl_CustomerDetails";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_CustomerDetails.DataSource = dt;
                Gvtbl_CustomerDetails.DataBind();

            }
            else
                Response.Write("<script>alert('Records Not found')</script>");

        
        }
        protected void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Customer_Id,Customer_Name,Date_Of_Brith,Gender,Phone,Email,Address,Event_Name,Facility_Name,Membership_type,Membership_Status from tbl_CustomerDetails where Customer_Id=" + txtCustomerId.Text + "";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtCustomerId.Text = rdr["Customer_Id"].ToString();
                    txtCustomerName.Text = rdr["Customer_Name"].ToString();
                    txtDate_Of_Birth.Text = rdr["Date_Of_Brith"].ToString();
                    txtPhone.Text = rdr["Phone"].ToString();
                    txtEmail.Text = rdr["Email"].ToString();
                    txtAddress.Text = rdr["Address"].ToString();
                    ddlEvent_Name.SelectedItem.Text = rdr["Event_Name"].ToString();
                    ddlFacility_Name.SelectedItem.Text = rdr["Facility_Name"].ToString();
                    ddlMembership_Type.SelectedItem.Text = rdr["Membership_Type"].ToString();
                    if (rdr["Gender"].ToString().ToLower() == "Male".ToLower())
                        rdoMale.Checked = true;
                    else if (rdr["Gender"].ToString().ToLower() == "Female".ToLower())
                        rdoFemale.Checked = true;

                    if (rdr["Membership_Status"].ToString() == "1")
                        chkMembershipStatus.Checked = true;
                    else
                        chkMembershipStatus.Checked = false;



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
            string genderstatus = "";
            if (chkMembershipStatus.Checked == true)
                status = 1;
            else
                status = 0;

            if(rdoMale.Checked==true)
                genderstatus ="Male";
            else if(rdoFemale.Checked ==true)
                genderstatus ="Female";

            string sqlstr = "Insert into tbl_CustomerDetails(Customer_Id,Customer_Name,Date_Of_Brith,Gender,Phone,Email,Address,Event_Name,Facility_Name,Membership_Type,Membership_Status)values(" + txtCustomerId.Text + ",'" + txtCustomerName.Text + "','" + Convert.ToDateTime(txtDate_Of_Birth.Text).ToShortDateString() + "', '"+ genderstatus   +"'," + txtPhone.Text + ",'" + txtEmail.Text + "','" + txtAddress.Text + "','" + ddlEvent_Name.SelectedValue + "','" + ddlFacility_Name.SelectedValue + "'," + ddlMembership_Type.SelectedValue + "," + status + ")";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record inserted Sucessfully')</script>");
                //if (Session["User"] != null)
                
                    fillgrid();
                

            }
            con.Close();
            Response.Redirect("~/TRANSACTIONS/BookingDetails.aspx");

            #region "Junk Data"
           
            #endregion
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "update tbl_CustomerDetails  set  Customer_Name='"+txtCustomerName.Text+"',Phone=" + txtPhone.Text + ", Address = '" + txtAddress.Text + "',Event_Name='" + ddlEvent_Name.SelectedItem + "',Email= '" + txtEmail.Text + "',Facility_Name='" + ddlFacility_Name.SelectedItem + "', Membership_Type='" + ddlMembership_Type.SelectedItem + "'  where Customer_Id=" + txtCustomerId.Text + " ";
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
            string sqlstr = "DELETE FROM tbl_CustomerDetails WHERE Customer_Name='" + txtCustomerName.Text + "'";
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
        

        protected void Gvtbl_CustomerDetails_SelectedIndexChanged1(object sender, EventArgs e)
        {
            txtCustomerId.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[1].Text;
            txtCustomerName.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[2].Text;
            txtDate_Of_Birth.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[3].Text;
            if (Gvtbl_CustomerDetails.SelectedRow.Cells[4].Text == "female")
            {
                rdoFemale.Checked = true;
                rdoMale.Checked = false;
            }
            else
            {
                rdoMale.Checked = true;
                rdoFemale.Checked = false;
            }
            txtPhone.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[5].Text;
            txtEmail.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[6].Text;
            txtAddress.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[7].Text;
            ddlEvent_Name.SelectedItem.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[8].Text;
            ddlFacility_Name.SelectedItem.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[9].Text;
            ddlMembership_Type.SelectedItem.Text = Gvtbl_CustomerDetails.SelectedRow.Cells[10].Text;
           if( Gvtbl_CustomerDetails.SelectedRow.Cells[11].Text=="1")
            
                chkMembershipStatus.Checked = true;
            else
                chkMembershipStatus.Checked = false; 
           
        }

       
     
               
    }

}