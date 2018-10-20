using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            fillddlState();
            fillddlFinYear();
        }
    }

    private void fillddlState()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "CMM_State1_Select";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if(objSdr.HasRows)
        {
            ddlStateID.DataSource = objSdr;
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
        }
        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        objCon.Close();
    }

    private void fillddlFinYear()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_MST_FinYear_Select";        
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlFinYearID.DataSource = objSdr;
            ddlFinYearID.DataValueField = "FinYearID";
            ddlFinYearID.DataTextField = "FinName";
            ddlFinYearID.DataBind();
        }
        ddlFinYearID.Items.Insert(0, new ListItem("Select Financial year", "-1"));
        objCon.Close();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            SqlString strDisplayName = SqlString.Null;
            SqlString strOrganizationName = SqlString.Null;
            SqlInt32 strStateID = SqlInt32.Null;
            SqlString strCity = SqlString.Null;
            SqlString strEmailID = SqlString.Null;
            SqlString strPassword = SqlString.Null;
            SqlInt32 strIsActive = SqlInt32.Null;
            SqlString strAddress = SqlString.Null;

            if (cdIsActive.Checked)
            {
                strIsActive = 1;
            }
            else
            {
                strIsActive = 0;
            }

            if (txtEmailID.Text.Trim() != "")
            {
                strEmailID = txtEmailID.Text.Trim();
            }

            if (txtAddress.Text.Trim() != "")
            {
                strAddress = txtAddress.Text.Trim();
            }
            if (txtPassword.Text.Trim() != "")
            {
                strPassword = txtPassword.Text.Trim();
            }
            if (txtUserName.Text.Trim() != "")
            {
                strDisplayName = txtUserName.Text.Trim();
            }
            if (txtOrganizationName.Text.Trim() != "")
            {
                strOrganizationName = txtOrganizationName.Text.Trim();
            }
            if (txtCity.Text.Trim() != "")
            {
                strCity = txtCity.Text.Trim();
            }
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[CMM_User_Insert]";
            objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
            objCmd.Parameters.AddWithValue("@OrganizationName", strOrganizationName);
            objCmd.Parameters.AddWithValue("@CityName", strCity);
            objCmd.Parameters.AddWithValue("@Email", strEmailID);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@IsActive", strIsActive);
            objCmd.ExecuteNonQuery();
            objCon.Close();
            lblMessage.Text = "You are successfully registered";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            txtEmailID.Text = "";
            txtOrganizationName.Text = "";
            txtPassword.Text = "";
            txtRetypePassword.Text = "";
            txtUserName.Text = "";
            txtCity.Text = "";
            ddlStateID.SelectedIndex = 0;
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2601)
            {
                lblMessage.Text = "Enter another Email-ID";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtEmailID.Text = "";
                txtOrganizationName.Text = "";
                txtPassword.Text = "";
                txtRetypePassword.Text = "";
                txtUserName.Text = "";
                txtCity.Text = "";
                txtAddress.Text="";
                ddlStateID.SelectedIndex = 0;
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
        SqlString strEmailID = SqlString.Null;
        SqlString strPassword = SqlString.Null;

        if (txtLEmail.Text.Trim() != "")
        {
            strEmailID = txtLEmail.Text.Trim();
        }

        if (txtLPassword.Text.Trim() != "")
        {
            strPassword = txtLPassword.Text.Trim();
        }
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_User_SelectByEmailAndPassword";
        objCmd.Parameters.AddWithValue("@Email", strEmailID);
        objCmd.Parameters.AddWithValue("@Password", strPassword);
        SqlDataReader objSdr = objCmd.ExecuteReader();

        if (objSdr.HasRows == true)
        {
            while (objSdr.Read() == true)
            {
                if (objSdr["Email"].Equals(DBNull.Value) == false)
                {
                    Session["Email"] = objSdr["Email"].ToString().Trim();
                }
                if (objSdr["StateID"].Equals(DBNull.Value) == false)
                {
                    Session["StateID"] = objSdr["StateID"].ToString().Trim();
                }
                if (objSdr["UserID"].Equals(DBNull.Value) == false)
                {
                    Session["UserID"] = objSdr["UserID"].ToString().Trim();
                }
                if (objSdr["DisplayName"].Equals(DBNull.Value) == false)
                {
                    Session["DisplayName"] = objSdr["DisplayName"].ToString().Trim();
                }
                if (objSdr["OrganizationName"].Equals(DBNull.Value) == false)
                {
                    Session["OrganizationName"] = objSdr["OrganizationName"].ToString().Trim();
                }
                if (objSdr["Address"].Equals(DBNull.Value) == false)
                {
                    Session["Address"] = objSdr["Address"].ToString().Trim();
                }
            }
            Response.Redirect("~/CMMWeb/AdminPanel/Dashboard/Dashboard.aspx");
        }
        else
        {
            lblMessage.Text = "EmailID and Password is not matched";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
        objCon.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage("harshilsavaliya47@gmail.com", txtForgetEmailID.Text.Trim());
        msg.Subject = "Change your Password";
        msg.Body = string.Format("Click on below link for changing password<br>" +
            "http://localhost:25534/CMMWeb/ResetPassword/ResetPassword.aspx");
        msg.IsBodyHtml = true;
        SmtpClient smt = new SmtpClient();
        smt.Host = "smtp.gmail.com";
        smt.EnableSsl = true;
        NetworkCredential NetworkCred = new NetworkCredential();
        NetworkCred.UserName = "harshilsavaliya47@gmail.com"; // senders
        NetworkCred.Password = "150540107091@123"; // senders
        smt.UseDefaultCredentials = true;
        smt.Credentials = NetworkCred;
        smt.Port = 587;
        smt.Send(msg);
        txtForgetEmailID.Text = "";
        lblMessage.Text = "Link has been sent to "+txtForgetEmailID.Text;
        lblMessage.ForeColor = System.Drawing.Color.Red;
    }
    protected void ddlFinYearID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["FinName"] = ddlFinYearID.SelectedItem;
        Session["FinID"] = ddlFinYearID.SelectedValue;
    }
}
