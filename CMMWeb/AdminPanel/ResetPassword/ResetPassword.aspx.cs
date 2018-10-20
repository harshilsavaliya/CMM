using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Login_ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlString strEmail = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        if(txtPassword.Text.Trim()!="")
        {
            strPassword = txtPassword.Text.Trim();
        }
        if (txtLEmail.Text.Trim() != "")
        {
            strEmail = txtLEmail.Text.Trim();
        }
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = System.Data.CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_User_SelectByEmail]";
        objcmd.Parameters.AddWithValue("@Email",strEmail);
        SqlDataReader objSdr = objcmd.ExecuteReader();
        if(objSdr.HasRows)
        {
            while (objSdr.Read() == true)
            {
                if (objSdr["Email"].Equals(DBNull.Value) == false)
                {
                    Session["Email"] = objSdr["Email"].ToString().Trim();
                }
                if (objSdr["UserID"].Equals(DBNull.Value) == false)
                {
                    Session["UserID"] = objSdr["UserID"].ToString().Trim();
                }
                
            }
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = System.Data.CommandType.StoredProcedure;
            objCmd.CommandText = "[CMM_User_ResetPassword]";
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            objCmd.ExecuteNonQuery();
            objCon.Close();
            lblMessage.Text = "Password has been changed sucessfully";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            txtConfirmPassword.Text = "";
            txtLEmail.Text = "";
            txtPassword.Text = "";
            txtPassword.Focus();
        }
        else
        {
            lblMessage.Text = "Email-ID is not same as your login Email-ID";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}