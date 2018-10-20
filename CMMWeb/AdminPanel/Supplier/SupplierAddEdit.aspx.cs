using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Supplier_SupplierAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SupplierID"] != null)
            {
                Page.Title = "Supplier Edit";
                lblTitle.Text = "SUPPLIER EDIT";
                fillControls();
            }
            else
            {
                Page.Title = "Supplier Add";
                lblTitle.Text = "SUPPLIER ADD";
            }
        }
    }
    private void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_Supplier_SelectByPK]";
        objcmd.Parameters.AddWithValue("@SupplierID", Request.QueryString["SupplierID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["SupplierName"].Equals(DBNull.Value) == false)
            {
                txtSupplierName.Text = objSdr["SupplierName"].ToString().Trim();
            }

            if(objSdr["IsActive"].Equals(DBNull.Value)==false)
            {
                cdIsActive.Checked= Convert.ToBoolean(objSdr["IsActive"].ToString().Trim());
            }
            if (objSdr["Email"].Equals(DBNull.Value) == false)
            {
                txtEmail.Text= objSdr["Email"].ToString().Trim();
            }
            if (objSdr["Mobile"].Equals(DBNull.Value) == false)
            {
                txtMobile.Text= objSdr["Mobile"].ToString().Trim();
            }
            if (objSdr["State"].Equals(DBNull.Value) == false)
            {
                txtState.Text= objSdr["State"].ToString().Trim();
            }
            if (objSdr["City"].Equals(DBNull.Value) == false)
            {
                txtCity.Text= objSdr["City"].ToString().Trim();
            }
            if (objSdr["ContactPerson"].Equals(DBNull.Value) == false)
            {
                txtContactPerson.Text= objSdr["ContactPerson"].ToString().Trim();
            }
            if (objSdr["Address"].Equals(DBNull.Value) == false)
            {
                txtAddress.Text= objSdr["Address"].ToString().Trim();
            }
        }
        objcon.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strSupplierName = SqlString.Null;
        SqlString strMobile = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strState = SqlString.Null;
        SqlString strCity = SqlString.Null;
        SqlString strContactPerson = SqlString.Null;
        SqlInt32 strIsActive = SqlInt32.Null;

        if(txtSupplierName.Text.Trim()!="")
        {
            strSupplierName = txtSupplierName.Text.Trim();
        }
        if (txtMobile.Text.Trim() != "")
        {
            strMobile = txtMobile.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            strEmail = txtEmail.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            strAddress = txtAddress.Text.Trim();
        }
        if (txtState.Text.Trim() != "")
        {
            strState = txtState.Text.Trim();
        }
        if (txtCity.Text.Trim() != "")
        {
            strCity = txtCity.Text.Trim();
        }
        if (txtContactPerson.Text.Trim() != "")
        {
            strContactPerson = txtContactPerson.Text.Trim();
        }
        if(cdIsActive.Checked)
        {
            strIsActive = 1;
        }
        else
        {
            strIsActive = 0;
        }

        if(Request.QueryString["SupplierID"]==null)
        {
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_Supplier_SelectByUserID_AND_SupplierName]";
            if (Session["UserID"] != null)
            {
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objcmd.Parameters.AddWithValue("@SupplierName", strSupplierName);
            

            SqlDataReader objSdr = objcmd.ExecuteReader();
            if (objSdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Supplier<br>enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtContactPerson.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtState.Text = "";
                txtSupplierName.Text = "";
                cdIsActive.Checked = false;
                txtSupplierName.Focus();
                objcon.Close();
            }
            else
            {
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_CMM_Supplier_InsertByUserID]";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objCmd.Parameters.AddWithValue("@SupplierName", strSupplierName);
                objCmd.Parameters.AddWithValue("@IsActive", strIsActive);
                objCmd.Parameters.AddWithValue("@Email", strEmail);
                objCmd.Parameters.AddWithValue("@Mobile", strMobile);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@State", strState);
                objCmd.Parameters.AddWithValue("@City", strCity);
                objCmd.Parameters.AddWithValue("@ContactPerson", strContactPerson);
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data has been Inserted sucessfully";
                lblMessage.Attributes["class"] = "btn btn-success";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtContactPerson.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtState.Text = "";
                txtSupplierName.Text = "";
                cdIsActive.Checked = false;
                txtSupplierName.Focus();
                objCon.Close();
            }
        }
        if (Request.QueryString["SupplierID"] != null)
        {
            SqlString var = SqlString.Null;
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_Supplier_SelectByPK]";
            objcmd.Parameters.AddWithValue("@SupplierID", Request.QueryString["SupplierID"].ToString());
            SqlDataReader objSdr = objcmd.ExecuteReader();
            while (objSdr.Read())
            {
                if (objSdr["SupplierName"].Equals(DBNull.Value) == false)
                {
                    var = objSdr["SupplierName"].ToString().Trim();
                }
            }
            objcon.Close();

            SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objco.Open();
            SqlCommand objcm = new SqlCommand();
            objcm.Connection = objco;
            objcm.CommandType = CommandType.StoredProcedure;
            objcm.CommandText = "[PR_CMM_Supplier_SelectByUserID_AND_ExceptSupplierName]";
            if (Session["UserID"] != null)
            {
                objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objcm.Parameters.AddWithValue("@SupplierName", strSupplierName);
            objcm.Parameters.AddWithValue("@ExceptSupplierName", var);
            SqlDataReader objsdr = objcm.ExecuteReader();
            if (objsdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Supplier<br>enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtContactPerson.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtState.Text = "";
                txtSupplierName.Text = "";
                cdIsActive.Checked = false;
                txtSupplierName.Focus();
                objco.Close();
            }
            else
            {
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_CMM_Supplier_UpdateByPK]";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objCmd.Parameters.AddWithValue("@SupplierName", strSupplierName);
                objCmd.Parameters.AddWithValue("@IsActive", strIsActive);
                objCmd.Parameters.AddWithValue("@Email", strEmail);
                objCmd.Parameters.AddWithValue("@Mobile", strMobile);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@State", strState);
                objCmd.Parameters.AddWithValue("@City", strCity);
                objCmd.Parameters.AddWithValue("@ContactPerson", strContactPerson);
                objCmd.Parameters.AddWithValue("@SupplierID", Request.QueryString["SupplierID"].ToString());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/CMMWeb/AdminPanel/Supplier/SupplierList.aspx");
                objCon.Close();
            }
        }
    }
}