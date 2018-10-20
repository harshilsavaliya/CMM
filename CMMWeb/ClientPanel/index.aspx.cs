using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_ClientPanel_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            //if(Session["UserID"].ToString()!=null)
            //{
            //    hlLogin.Attributes["href"] = "CMMWeb/AdminPanel/ConstructionSite/ConstructionSiteAddEdit.aspx";
            //}
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (Session["UserID"]!=null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/ConstructionSite/ConstructionSiteAddEdit.aspx");
        }        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (!this.IsPostBack)
        //{
        //    if ((txtEmail.Text.Equals(""))||(txtMessage.Text.Equals("")) || txtName.Text.Equals = ("") || txtSubject.Text.Equals(""))
        //    {
        //        ModalPopupExtender1.Show();
        //    }
        //}
        MailMessage msg = new MailMessage("harshilsavaliya47@gmail.com", "harshilsavaliya47@gmail.com");
        msg.Subject = txtSubject.Text.Trim();
        msg.Body = "Name:- "+txtName.Text.Trim()+"<br>"+"Mail from:- "+txtEmail.Text.Trim()+"<br>"+"Message:-<br>"+txtMessage.Text.Trim();
        msg.IsBodyHtml = true;
        SmtpClient smt = new SmtpClient();
        smt.Host = "smtp.gmail.com";
        smt.EnableSsl = true;
        NetworkCredential NetworkCred = new NetworkCredential();
        NetworkCred.UserName = "harshilsavaliya47@gmail.com"; // senders
        NetworkCred.Password =   "150540107091@123"; // senders
        smt.UseDefaultCredentials = true;
        smt.Credentials = NetworkCred;
        smt.Port = 587;
        smt.Send(msg);
        txtEmail.Text = "";
        txtMessage.Text = "";
        txtName.Text = "";
        txtSubject.Text = "";
        //lblMessage.Text = "Your message has been sent.";
        btnSubmit.Attributes["class"] = "btn btn-danger";
        //lblMessage.ForeColor = System.Drawing.Color.Red;
    }
}