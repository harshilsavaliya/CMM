using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

public partial class CMMWeb_AdminPanel_Material_MaterialList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillMaterialList();
            fillddlMaterialType();
        }
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
        if (objSdr.HasRows)
        {
            ddlMaterialTypeID.DataSource = objSdr;
            ddlMaterialTypeID.DataValueField = "MaterialTypeID";
            ddlMaterialTypeID.DataTextField = "MaterialTypeName";
            ddlMaterialTypeID.DataBind();
        }
        ddlMaterialTypeID.Items.Insert(0, new ListItem("Select Material type", "-1"));
        objCon.Close();
    }

    protected void fillMaterialList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Material_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvMaterialList.DataSource = objSdr;
            gvMaterialList.DataBind();
        }
        objCon.Close();
    }
    protected void gvMaterialList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMaterial")
        {
            SqlString MTID = e.CommandArgument.ToString().Trim();
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Material_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@MaterialID", MTID);
            objCmd.ExecuteNonQuery();
            objCon.Close();
            fillMaterialList();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlInt32 strMaterialTypeID = SqlInt32.Null;
        //strMaterialTypeID = ddlMaterialTypeID.SelectedIndex;
        strMaterialTypeID = Convert.ToInt32(ddlMaterialTypeID.SelectedValue);

        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Material_SearchByMaterialType";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        objCmd.Parameters.AddWithValue("@MaterialTypeID", strMaterialTypeID);
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvMaterialList.DataSource = objSdr;
            gvMaterialList.DataBind();
        }
        objCon.Close();
    }
}