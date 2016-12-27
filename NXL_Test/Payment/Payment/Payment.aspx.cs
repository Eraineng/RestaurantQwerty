using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payment
{
    public partial class Payment : System.Web.UI.Page
    {
     private string amount;
        private string host;
        private string regNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

           
            PaymentT myPayment = (PaymentT)Session["MyPayment"];
            this.amount = String.Format("{0:0.00}", myPayment.TotalAmount);
            string hostName = Request.Url.GetLeftPart(UriPartial.Authority);
            this.host = hostName + "/";
            this.regNo = myPayment.ReservationID;
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            
           //added by SumWF
            btnPayWithCC.Enabled = false;
            txtCCNoP1.Enabled = false;
            txtCCNoP2.Enabled = false;
            txtCCNoP3.Enabled = false;
            txtCCNoP4.Enabled = false;
            rbtPaypal.Checked = true;
            
        }


        public string Amounts { get { return amount; } }
        public string Host { get { return host; } }
        public string RegNo { get { return regNo; } }

        protected void rbtPaypal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPaypal.Checked)
            {
                btnPayWithCC.Enabled = false;
                txtCCNoP1.Enabled = false;
                txtCCNoP2.Enabled = false;
                txtCCNoP3.Enabled = false;
                txtCCNoP4.Enabled = false;
            }
        }

        protected void rbtCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCreditCard.Checked)
            {
                btnPayWithCC.Enabled = true;
                txtCCNoP1.Enabled = true;
                txtCCNoP2.Enabled = true;
                txtCCNoP3.Enabled = true;
                txtCCNoP4.Enabled = true;
            }
        }

        protected void btnPayWithCC_Click(object sender, EventArgs e)
        {

            Response.Redirect("CreditCardPaymentAccepted.aspx");
            //Response.AddHeader("REFRESH", "10;URL=Login.aspx"); 
        }
    
    }
}