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
    public partial class PaymentProcessing : System.Web.UI.Page
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
            txtTransaction_Id.Text = string.Empty;
            txtCustomerId.Text = string.Empty;
            txtBookingId.Text = string.Empty;
            txtCustomer_Name.Text = string.Empty;
            txtBank_Name.Text = string.Empty;
            txtAccount_Number.Text = string.Empty;
            txtPaymentAmount.Text = string.Empty;
            txtPaymentDate.Text = string.Empty;
            txtCard_Number.Text = string.Empty;
            txtCard_Holder.Text = string.Empty;
            ddlPaymentMethod.Items.Insert(0, "--Select PaymentMethod--");
            ddlPaymentMethod.SelectedIndex = -1;
            ddlCard_Type.Items.Insert(0, "--Select CardType--");
            ddlCard_Type.SelectedIndex = -1;
            
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            //con.Open();
            string sqlstr = "select Transaction_Id,Customer_Id,Customer_Name,Booking_Id,PaymentAmount,PaymentMethod,Bank_Name,Account_Number,PaymentDate,Card_Type,Card_Number,Card_Holder  from tbl_TransactionDetails   ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_TransactionDetails.DataSource = dt;
                Gvtbl_TransactionDetails.DataBind();

            }
            else
                Response.Write("<script>alert('Records Not found')</script>");
           }

        protected void txtTransaction_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Transaction_Id,Customer_Id,Customer_Name,Booking_Id,PaymentAmount,PaymentMethod,Bank_Name,Account_Number,PaymentDate,Card_Type,Card_Number,Card_Holder  from tbl_TransactionDetails where Transaction_Id=" + txtTransaction_Id.Text + " ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtTransaction_Id.Text = rdr["Transaction_Id"].ToString();
                    txtCustomerId.Text = rdr["Customer_Id"].ToString();
                    txtCustomer_Name.Text = rdr["Customer_Name"].ToString();
                    txtBookingId.Text = rdr["Booking_Id"].ToString();
                    txtPaymentAmount.Text = rdr["PaymentAmount"].ToString();
                    ddlPaymentMethod.SelectedItem.Text = rdr["PaymentMethod"].ToString();
                    txtBank_Name.Text = rdr["Bank_Name"].ToString();
                    txtAccount_Number.Text = rdr["Account_Number"].ToString();
                    txtPaymentDate.Text = rdr["PaymentDate"].ToString();
                    ddlCard_Type.SelectedValue = rdr["Card_Type"].ToString();
                    txtCard_Number.Text = rdr["Card_Number"].ToString();
                    txtCard_Holder.Text = rdr["Card_Holder"].ToString();
                   

                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Records Not found')</script>");
            }

        }
        protected void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Customer_Id,Customer_Name from tbl_CustomerDetails where Customer_Id='" + txtCustomerId.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {


                    txtCustomerId.Text = rdr["Customer_Id"].ToString();
                    txtCustomer_Name.Text = rdr["Customer_Name"].ToString();
                   


                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Records Not found')</script>");
            }

        }
        protected void txtBookingId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "select Booking_Id,PaymentAmount,PaymentMethod from tbl_BookingDetails where Booking_Id='" + txtBookingId.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtBookingId.Text = rdr["Booking_Id"].ToString();
                    txtPaymentAmount.Text = rdr["PaymentAmount"].ToString();
                    ddlPaymentMethod.SelectedItem.Text = rdr["PaymentMethod"].ToString();


                }
            }
            else
            {
                //ClearControls();
                Response.Write("<script>alert('Records Not found')</script>");
            }

        }


       protected void btnPay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
            con.Open();

            string sqlstr = "Insert into tbl_TransactionDetails(Transaction_Id,Customer_Id,Customer_Name,Booking_Id,PaymentAmount,PaymentMethod,Bank_Name,Account_Number,PaymentDate,Card_Type,Card_Number,Card_Holder )values(" + txtTransaction_Id.Text + "," + txtCustomerId.Text + ",'" + txtCustomer_Name.Text + "'," + txtBookingId.Text + "," + txtPaymentAmount.Text + ",'" + ddlPaymentMethod.SelectedItem + "','" + txtBank_Name.Text + "'," + txtAccount_Number.Text + ",'" + txtPaymentDate.Text + "','" + ddlCard_Type.SelectedItem + "'," + txtCard_Number.Text + ",'" + txtCard_Holder.Text + "')";
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
       protected void btnDelete_Click(object sender, EventArgs e)
       {
           SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CMS;User ID=sa;Password=123456");
           con.Open();
           string sqlstr = "DELETE FROM tbl_TransactionDetails WHERE Transaction_Id ='" + txtTransaction_Id.Text + "'";
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

       protected void btnCancel_Click(object sender, EventArgs e)
       {
            Response.Redirect(@"~/Home.aspx");
        }

       protected void Gvtbl_TransactionDetails_SelectedIndexChanged(object sender, EventArgs e)
       {
           txtTransaction_Id.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[1].Text;
           txtCustomerId.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[2].Text;
           txtCustomer_Name.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[3].Text;
           txtBookingId.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[4].Text;
           txtPaymentAmount.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[5].Text;
           ddlPaymentMethod.SelectedItem.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[6].Text;
           txtBank_Name.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[7].Text;
           txtAccount_Number.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[8].Text;
           txtPaymentDate.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[9].Text;
           ddlCard_Type.SelectedItem.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[10].Text;
           txtCard_Number.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[11].Text;
           txtCard_Holder.Text = Gvtbl_TransactionDetails.SelectedRow.Cells[12].Text;
          
           
           
       }
    }


}