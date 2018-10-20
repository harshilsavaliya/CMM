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

public partial class CMMWeb_AdminPanel_MaterialType_MaterialTypeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillMaterialTypeList();
        }
    }

    private void fillMaterialTypeList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_MaterialType_SelectByUserID]";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows == true)
        {
            gvMaterialTypeList.DataSource = objSdr;
            gvMaterialTypeList.DataBind();
        }
        objCon.Close();
    }


    protected void gvMaterialTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName== "DeleteMaterialType")
        {
            SqlString MTID = e.CommandArgument.ToString().Trim();
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_MaterialType_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@MaterialTypeID",MTID);
            objCmd.ExecuteNonQuery();
            objCon.Close();
            fillMaterialTypeList();
        }
    }
}