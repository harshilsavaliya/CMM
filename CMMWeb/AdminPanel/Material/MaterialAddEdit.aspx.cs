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

public partial class CMMWeb_AdminPanel_Material_MaterialAddEdit : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillddlMaterialType();
            fillddlUnit();
            if (Request.QueryString["MaterialID"] != null)
            {
                Page.Title = "Material Edit";
                lblTitle.Text = "MATERIAL EDIT";
                fillControls();
            }
            else
            {
                Page.Title = "Material Add";
                lblTitle.Text = "MATERIAL ADD";
            }
        }        
    }

    protected void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_Material_SelectByPK]";
        objcmd.Parameters.AddWithValue("@MaterialID", Request.QueryString["MaterialID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["MaterialName"].Equals(DBNull.Value) == false)
            {
                txtMaterialName.Text = objSdr["MaterialName"].ToString().Trim();
            }
            if (objSdr["IsSystem"].Equals(DBNull.Value) == false)
            {
                cdIsActive.Checked = Convert.ToBoolean(objSdr["IsSystem"].ToString().Trim());
            }

            if (objSdr["UnitID"].Equals(DBNull.Value)==false)
            {
                ddlUnitID.SelectedValue = objSdr["UnitID"].ToString().Trim();
            }

            if (objSdr["MaterialTypeID"].Equals(DBNull.Value) == false)
            {
                ddlMaterialTypeID.SelectedValue = objSdr["MaterialTypeID"].ToString().Trim();
            }

        }
        objcon.Close();
    }

    protected void fillddlMaterialType()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_MaterialType_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if(objSdr.HasRows)
        {
            ddlMaterialTypeID.DataSource = objSdr;
            ddlMaterialTypeID.DataValueField = "MaterialTypeID";
            ddlMaterialTypeID.DataTextField = "MaterialTypeName";
            ddlMaterialTypeID.DataBind();
        }
        ddlMaterialTypeID.Items.Insert(0, new ListItem("Select Material type", "-1"));
        objCon.Close();
    }

    protected void fillddlUnit()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Unit_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlUnitID.DataSource = objSdr;
            ddlUnitID.DataValueField = "UnitID";
            ddlUnitID.DataTextField = "UnitName";
            ddlUnitID.DataBind();
        }
        ddlUnitID.Items.Insert(0, new ListItem("Select Unit", "-1"));
        objCon.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strMaterialName = SqlString.Null;
        SqlInt32 strMaterialTypeID = SqlInt32.Null;
        SqlInt32 strUnitID = SqlInt32.Null;
        SqlInt32 strIsSystem = SqlInt32.Null;

        if (cdIsActive.Checked)
        {
            strIsSystem = 1;
        }
        else
        {
            strIsSystem = 0;
        }
        if (txtMaterialName.Text != "")
        {
            strMaterialName = txtMaterialName.Text.Trim();
        }
        strMaterialTypeID = Convert.ToInt32(ddlMaterialTypeID.SelectedValue);
        strUnitID = Convert.ToInt32(ddlUnitID.SelectedValue);
        if (Request.QueryString["MaterialID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_CMM_Material_SelectByUserID_AND_MaterialName";
            objCmd.Parameters.AddWithValue("@MaterialName", strMaterialName);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Material<br> enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtMaterialName.Text = "";
                cdIsActive.Checked = false;
                ddlMaterialTypeID.SelectedIndex = 0;
                ddlUnitID.SelectedIndex = 0;
                txtMaterialName.Focus();
                objCon.Close();
            }
            else
            {
                SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objco.Open();
                SqlCommand objcm = new SqlCommand();
                objcm.Connection = objco;
                objcm.CommandType = CommandType.StoredProcedure;
                objcm.CommandText = "[PR_CMM_Material_InsertByUserID]";
                if (Session["UserID"] != null)
                {
                    objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objcm.Parameters.AddWithValue("@MaterialName", strMaterialName);
                objcm.Parameters.AddWithValue("@UnitID", strUnitID);
                objcm.Parameters.AddWithValue("@MaterialTypeID", strMaterialTypeID);
                objcm.Parameters.AddWithValue("@IsSystem", strIsSystem);
                objcm.ExecuteNonQuery();
                lblMessage.Text = "Data has been inserted successfully";
                lblMessage.CssClass = "btn btn-success";
                txtMaterialName.Text = "";
                cdIsActive.Checked = false;
                ddlMaterialTypeID.SelectedIndex = 0;
                ddlUnitID.SelectedIndex = 0;
                txtMaterialName.Focus();
                objco.Close();
            }

        }

        if (Request.QueryString["MaterialID"] != null)
        {
            SqlString var = SqlString.Null;
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_Material_SelectByPK]";
            objcmd.Parameters.AddWithValue("@MaterialID", Request.QueryString["MaterialID"].ToString());
            SqlDataReader objsdr = objcmd.ExecuteReader();
            while (objsdr.Read())
            {
                if (objsdr["MaterialName"].Equals(DBNull.Value) == false)
                {
                    var = objsdr["MaterialName"].ToString().Trim();
                }
            }
            objcon.Close();

            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_CMM_Material_SelectByUserID_AND_ExceptMaterialName";
            objCmd.Parameters.AddWithValue("@MaterialName", strMaterialName);
            objCmd.Parameters.AddWithValue("@ExceptMaterialName", var);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Material<br> enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtMaterialName.Text = "";
                cdIsActive.Checked = false;
                ddlMaterialTypeID.SelectedIndex = 0;
                ddlUnitID.SelectedIndex = 0;
                txtMaterialName.Focus();
                objCon.Close();
            }
            else
            {
                SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objco.Open();
                SqlCommand objcm = new SqlCommand();
                objcm.Connection = objco;
                objcm.CommandType = CommandType.StoredProcedure;
                objcm.CommandText = "[PR_CMM_Material_UpdateByPK]";
                if (Session["UserID"] != null)
                {
                    objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objcm.Parameters.AddWithValue("@MaterialName", strMaterialName);
                objcm.Parameters.AddWithValue("@UnitID", strUnitID);
                objcm.Parameters.AddWithValue("@MaterialTypeID", strMaterialTypeID);
                objcm.Parameters.AddWithValue("@IsSystem", strIsSystem);
                objcm.Parameters.AddWithValue("@MaterialID", Request.QueryString["MaterialID"].ToString());
                objcm.ExecuteNonQuery();
                objco.Close();
                Response.Redirect("~/CMMWeb/AdminPanel/Material/MaterialList.aspx");
            }
        }
    }
}