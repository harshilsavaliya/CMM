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

public partial class CMMWeb_AdminPanel_MaterialType_MaterialTypeAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["MaterialTypeID"] != null)
            {
                lblTitle.Text = "MATERIALTYPE EDIT";
                Page.Title = "MaterialType Edit";
                fillControls();
            }
            else
            {
                Page.Title = "MaterialType Add";
                lblTitle.Text = "MATERIALTYPE ADD";
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
        objcmd.CommandText = "[PR_CMM_MaterialType_SelectByPK]";
        objcmd.Parameters.AddWithValue("@MaterialTypeID", Request.QueryString["MaterialTypeID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while(objSdr.Read())
        {
            if(objSdr["MaterialTypeName"].Equals(DBNull.Value)==false)
            {
                txtMaterialTypeName.Text = objSdr["MaterialTypeName"].ToString().Trim();
            }

            if (objSdr["IsSystem"].Equals(DBNull.Value) == false)
            {
                cdIsActive.Checked =Convert.ToBoolean(objSdr["IsSystem"].ToString().Trim());
            }
        }
        objcon.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strMaterialTypeName = SqlString.Null;
        SqlInt32 strIsSystem = SqlInt32.Null;

        if(txtMaterialTypeName.Text!="")
        {
            strMaterialTypeName = txtMaterialTypeName.Text.Trim();
        }
        if (cdIsActive.Checked == true)
        {
            strIsSystem = 1;
        }
        else
        {
            strIsSystem = 0;
        }
        if (Request.QueryString["MaterialTypeID"]==null)
        {
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_MaterialType_SelectByUserID_AND_MTN]";
            if (Session["UserID"] != null)
            {
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objcmd.Parameters.AddWithValue("@MaterialTypeName", strMaterialTypeName);
            SqlDataReader objSdr = objcmd.ExecuteReader();
            if(objSdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Material<br> Type Name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtMaterialTypeName.Text = "";
                cdIsActive.Checked = false;
                txtMaterialTypeName.Focus();
                objcon.Close();
            }
            else
            {
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_MaterialType_InsertByUserID";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objCmd.Parameters.AddWithValue("@MaterialTypeName", strMaterialTypeName);
                objCmd.Parameters.AddWithValue("@IsSystem", strIsSystem);
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data has been Inserted sucessfully";
                lblMessage.Attributes["class"] = "btn btn-success";
                txtMaterialTypeName.Text = "";
                cdIsActive.Checked = false;
                txtMaterialTypeName.Focus();
                objCon.Close();
            }
        }

        if (Request.QueryString["MaterialTypeID"]!=null)
        {
            SqlString var = SqlString.Null;
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_MaterialType_SelectByPK]";
            objcmd.Parameters.AddWithValue("@MaterialTypeID", Request.QueryString["MaterialTypeID"].ToString());
            SqlDataReader objSdr = objcmd.ExecuteReader();
            while (objSdr.Read())
            {
                if (objSdr["MaterialTypeName"].Equals(DBNull.Value) == false)
                {
                    var = objSdr["MaterialTypeName"].ToString().Trim();
                }
            }
            objcon.Close();

            SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objco.Open();
            SqlCommand objcm = new SqlCommand();
            objcm.Connection = objco;
            objcm.CommandType = CommandType.StoredProcedure;
            objcm.CommandText = "[PR_CMM_MaterialType_SelectByUserID_AND_Except_MTN]";
            if (Session["UserID"] != null)
            {
                objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objcm.Parameters.AddWithValue("@MaterialTypeName", strMaterialTypeName);
            objcm.Parameters.AddWithValue("@ExceptMaterialTypeName", var);
            SqlDataReader objsdr = objcm.ExecuteReader();
            if (objsdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Material<br> Type Name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtMaterialTypeName.Text = "";
                cdIsActive.Checked = false;
                txtMaterialTypeName.Focus();
                objco.Close();
            }
            else
            {
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_CMM_MaterialType_UpdateByPK";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objCmd.Parameters.AddWithValue("@MaterialTypeName", strMaterialTypeName);
                objCmd.Parameters.AddWithValue("@IsSystem", strIsSystem);
                objCmd.Parameters.AddWithValue("@MaterialTypeID", Request.QueryString["MaterialTypeID"].ToString());
                objCmd.ExecuteNonQuery();
                objCon.Close();
                Response.Redirect("~/CMMWeb/AdminPanel/MaterialType/MaterialTypeList.aspx");
            }
        }
    }
}