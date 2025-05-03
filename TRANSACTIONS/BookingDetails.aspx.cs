using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.TRANSACTIONS
{
    public partial class BookingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                fillgrid();

            }
        }
        protected void ClearControls()
        {
            txtBookingId.Text = string.Empty;
            txtCustomerId.Text = string.Empty;
            txtCustomer_Name.Text = string.Empty;
            txtEvent_Name.Text = string.Empty;
            txtBooking_Date.Text = string.Empty;
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;
            chkStatus.Checked = false;
            txtPaymentAmount.Text = string.Empty;
            ddlPaymentMethod.Items.Insert(0, "--Select PaymentMethod--");
            ddlPaymentMethod.SelectedIndex = -1;
           



        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void txtBookingId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Booking_Id,Customer_Id,Customer_Name,Event_Name,Booking_Date,Start_Time,End_Time,Booking_Status ,PaymentAmount,PaymentMethod from tbl_BookingDetails where Booking_Id='" + txtBookingId.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtBookingId.Text = rdr["Booking_Id"].ToString();
                    txtBooking_Date.Text = rdr["Booking_Date"].ToString();
                    txtStartTime.Text = rdr["Start_Time"].ToString();
                    txtEndTime.Text = rdr["End_Time"].ToString();
                    txtPaymentAmount.Text = rdr["PaymentAmount"].ToString();
                    ddlPaymentMethod.SelectedValue = rdr["PaymentMethod"].ToString();
                   

                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Record Not Found')</script>");
            }

        }

        protected void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Customer_Id,Customer_Name,Event_Name from tbl_CustomerDetails where Customer_Id='" + txtCustomerId.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                   
                    txtCustomerId.Text = rdr["Customer_Id"].ToString();
                    txtCustomer_Name.Text = rdr["Customer_Name"].ToString();
                    txtEvent_Name.Text = rdr["Event_Name"].ToString();
                    
                    

                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Record Not Found')</script>");
            }

        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "select Booking_Id,Customer_Id,Customer_Name,Event_Name,Booking_Date,Start_Time,End_Time,Booking_Status ,PaymentAmount,PaymentMethod from tbl_BookingDetails;";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_BookingDetails.DataSource = dt;
                Gvtbl_BookingDetails.DataBind();

            }
            else
                Response.Write("<script>alert('Record Not Found')</script>");


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            int status;

            if (chkStatus.Checked == true)
                status = 1;
            else
                status = 0;

            string sqlstr = "Insert into tbl_BookingDetails(Booking_Id,Customer_Id,Customer_Name,Event_Name,Booking_Date,Start_Time, End_Time,Booking_Status,PaymentAmount,PaymentMethod)values(" + txtBookingId.Text + ",'" + txtCustomerId.Text + "','" + txtCustomer_Name.Text + "','" + txtEvent_Name.Text + "','" + txtBooking_Date.Text + "','" + txtStartTime.Text + "','" + txtEndTime.Text + "'," + status + ",'" + txtPaymentAmount.Text + "','" + ddlPaymentMethod.SelectedItem + "')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("<script>alert('Record inserted Sucessfully')</script>");
                // if (Session["User"] != null)

                fillgrid();


            }
            con.Close();
            Response.Redirect("~/TRANSACTIONS/TransactionDetails.aspx");

            #region "Junk Data"

            #endregion
        }

        protected void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "update tbl_BookingDetails set  Booking_Id='" + txtBookingId.Text + "',Customer_Id= '" + txtCustomerId.Text + "',Customer_Name='" + txtCustomer_Name.Text+ "',Event_Name='" + txtEvent_Name.Text + "', Booking_Date= '" + txtBooking_Date.Text + "', Start_Time= '" + txtStartTime.Text + "',End_Time= '" + txtEndTime.Text + "' ,PaymentAmount='" + txtPaymentAmount.Text + "' ,PaymentMethod='" + ddlPaymentMethod.SelectedItem + "' where Booking_Id='" + txtBookingId.Text + "' ";
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
            string sqlstr = "DELETE FROM tbl_BookingDetails WHERE Booking_Id ='" + txtBookingId.Text + "'";
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

        protected void Gvtbl_BookingDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookingId.Text = Gvtbl_BookingDetails.SelectedRow.Cells[1].Text;
            txtCustomerId.Text = Gvtbl_BookingDetails.SelectedRow.Cells[2].Text;
            txtCustomer_Name.Text = Gvtbl_BookingDetails.SelectedRow.Cells[3].Text;
            txtEvent_Name.Text = Gvtbl_BookingDetails.SelectedRow.Cells[4].Text;
            txtBooking_Date.Text = Gvtbl_BookingDetails.SelectedRow.Cells[5].Text;
            txtStartTime.Text = Gvtbl_BookingDetails.SelectedRow.Cells[6].Text;
            txtEndTime.Text = Gvtbl_BookingDetails.SelectedRow.Cells[7].Text;
            if (Gvtbl_BookingDetails.SelectedRow.Cells[8].Text == "1")

                chkStatus.Checked = true;
            else
                chkStatus.Checked = false; 
            txtPaymentAmount.Text = Gvtbl_BookingDetails.SelectedRow.Cells[9].Text;
            ddlPaymentMethod.SelectedItem.Text = Gvtbl_BookingDetails.SelectedRow.Cells[10].Text;
            
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TRANSACTIONS/TransactionDetails.aspx");
        }
    }
}