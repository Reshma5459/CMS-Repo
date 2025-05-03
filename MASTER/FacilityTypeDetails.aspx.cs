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
    public partial class FacilityTypeDetails : System.Web.UI.Page
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
                    Gvtbl_FacilityTypeDetails.Visible = false;
                }

            }
        }
        protected void ClearControls()
        {
            txtFacilityId.Text = string.Empty;
            ddlFacility.Items.Insert(0, "--Select Facility--");
            ddlFacility.SelectedIndex = -1;
            txtDescription.Text = string.Empty;
            rdoYes.Checked = false;
            rdoNo.Checked = false;

           


        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "select  facility_Id,Facility_Name,description,Available from tbl_FacilityTypeDetails;";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Session["fname"] = dt;
            if (dt.Rows.Count > 0)
            {
                Gvtbl_FacilityTypeDetails.DataSource = dt;
                Gvtbl_FacilityTypeDetails.DataBind();

            }
            else
                Response.Write("<script>alert('Records Not found')</script>");


        }
        protected void txtFacilityId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = " select  facility_Id,Facility_Name,description,Available from tbl_FacilityTypeDetails where facility_Id=" + txtFacilityId.Text + "";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtFacilityId.Text = rdr["Facility_Id"].ToString();
                    ddlFacility.SelectedItem.Text = rdr["Facility_Name"].ToString();
                    txtDescription.Text = rdr["description"].ToString();
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
            string Availablestatus = "";
            if (rdoYes.Checked == true)
                Availablestatus = "Yes";
            else if (rdoNo.Checked == true)
                Availablestatus = "No";
            string sqlstr = "Insert into tbl_FacilityTypeDetails( Facility_Id,Facility_Name,description,Available )values(" + txtFacilityId.Text + ",'" + ddlFacility.SelectedItem + "','" + txtDescription.Text + "', '" + Availablestatus + "')";
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
            string Availablestatus = "";
            if (rdoYes.Checked == true)
                Availablestatus = "Yes";
            else if (rdoNo.Checked == true)
                Availablestatus = "No";
            string sqlstr = "update tbl_FacilityTypeDetails set  Facility_Id = " + txtFacilityId.Text + ",Facility_Name='" + ddlFacility.SelectedItem + "',description= '" + txtDescription.Text + "',Available='" + Availablestatus + "'  where Facility_Id='" +txtFacilityId.Text+ "' "; 
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
            string sqlstr = "DELETE FROM tbl_FacilityTypeDetails WHERE Facility_Id='" + txtFacilityId.Text + "'";
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

        protected void Gvtbl_FacilityTypeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFacilityId.Text = Gvtbl_FacilityTypeDetails.SelectedRow.Cells[1].Text;
            ddlFacility.SelectedItem.Text = Gvtbl_FacilityTypeDetails.SelectedRow.Cells[2].Text;
            txtDescription.Text = Gvtbl_FacilityTypeDetails.SelectedRow.Cells[3].Text;
            if (Gvtbl_FacilityTypeDetails.SelectedRow.Cells[4].Text == "yes")
                rdoYes.Checked = true;
            else
                rdoNo.Checked = false; 
  
            

           
            
        }

        protected void ddlFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Session["fname"] as DataTable;
            DataRow[] dr = dt.Select("Facility_Name= '" + ddlFacility.SelectedItem.Text.Trim() + "'");
            foreach (DataRow row in dr)
            {
                txtDescription.Text = row["description"].ToString();
               

            }

        }
    }
}

