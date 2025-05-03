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
    public partial class EventManagement : System.Web.UI.Page
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
                    Gvtbl_EventManagement.Visible = false;
                }

            }

        }
        protected void ClearControls()
        {
            txtEventId.Text = string.Empty;
            ddlEvent_Name.Items.Insert(0, "--Select Event--");
            ddlEvent_Name.SelectedIndex = -1;
            txtEventDate.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtOrganizer.Text = string.Empty;
            txtDeadline.Text = string.Empty;



        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "Select Event_Id,Event_Name,Event_Date,Location,Organizer,Registration_Deadline from tbl_EventManagement;";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_EventManagement.DataSource = dt;
                Gvtbl_EventManagement.DataBind();

            }
            else
                Response.Write("<script>alert('Records Not found')</script>");


        }
        protected void txtEventId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "  Select Event_Id,Event_Name,Event_Date,Location,Organizer,Registration_Deadline from tbl_EventManagement where Event_Id=" + txtEventId.Text + " ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtEventId.Text = rdr["Event_Id"].ToString();
                    ddlEvent_Name.SelectedItem.Text = rdr["Event_Name"].ToString();
                    txtEventDate.Text = rdr["Event_Date"].ToString();
                    txtLocation.Text = rdr["Location"].ToString();
                    txtOrganizer.Text = rdr["Organizer"].ToString();
                    txtDeadline.Text = rdr["Registration_Deadline"].ToString();
                   


                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Records Not found')</script>");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            
            string sqlstr = "Insert into tbl_EventManagement(Event_Id,Event_Name,Event_Date,Location, Organizer,Registration_Deadline)values(" + txtEventId.Text + ",'" + ddlEvent_Name.SelectedItem + "'," + txtEventDate.Text + ",'" + txtLocation.Text + "','" + txtOrganizer.Text + "','" + txtDeadline.Text + "')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record inserted Sucessfully')</script>");
               // if (Session["User"] != null)
                
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
            string sqlstr = "update tbl_EventManagement set  Event_Name='" + ddlEvent_Name.SelectedItem + "',Event_Date= '" + txtEventDate.Text + "', Location= '" + txtLocation.Text + "', Organizer= '" + txtOrganizer.Text + "',Registration_Deadline= '" + txtDeadline.Text + "'  where Event_Name='" + ddlEvent_Name.SelectedItem + "' ";
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
            string sqlstr = "DELETE FROM tbl_EventManagement WHERE Event_Id='" + txtEventId.Text+ "'";
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

        protected void Gvtbl_EventManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEventId.Text = Gvtbl_EventManagement.SelectedRow.Cells[1].Text;
            ddlEvent_Name.SelectedItem.Text = Gvtbl_EventManagement.SelectedRow.Cells[2].Text;
            txtEventDate.Text = Gvtbl_EventManagement.SelectedRow.Cells[3].Text;
            txtLocation.Text = Gvtbl_EventManagement.SelectedRow.Cells[4].Text;
            txtOrganizer.Text = Gvtbl_EventManagement.SelectedRow.Cells[5].Text;
            txtDeadline.Text = Gvtbl_EventManagement.SelectedRow.Cells[6].Text;
            

        }



      }
   }
