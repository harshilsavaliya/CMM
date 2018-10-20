using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Worker_WorkerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillWorkerList();
        }
    }

    private void fillWorkerList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Worker_SelectByUserID]";
        if (Session["UserID"].ToString() != "")
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvWorkerList.DataSource = objSdr;
            gvWorkerList.DataBind();
        }
        objCon.Close();
    }
    protected void gvWorkerList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String WorkerID = e.CommandArgument.ToString();
        String ConstructionSiteID = e.CommandArgument.ToString();
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Worker_DeleteByPK]";
        objCmd.Parameters.AddWithValue("@WorkerID", WorkerID);
        objCmd.ExecuteNonQuery();
        objCon.Close();
        fillWorkerList();
    }
}