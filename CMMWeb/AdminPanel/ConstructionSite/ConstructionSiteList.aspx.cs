using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_ConstuctionSite_ConstructionSiteList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserID"]==null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillConstuctionSiteGridView();
        }
    }

    private void fillConstuctionSiteGridView()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_ConstructionSite_SelectByUserID]";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows == true)
        {
            gvConstructionSiteList.DataSource = objSdr;
            gvConstructionSiteList.DataBind();
        }
        objCon.Close();
    }

    protected void gvConstructionSiteList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteConstructionSite")
        {
            String ConstructionSiteID = e.CommandArgument.ToString();
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_ConstructionSite_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@ConstructionSiteID", ConstructionSiteID);
            objCmd.ExecuteNonQuery();
            objCon.Close();
            fillConstuctionSiteGridView();
        }
    }
}