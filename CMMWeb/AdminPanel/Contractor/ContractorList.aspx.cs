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

public partial class CMMWeb_AdminPanel_Contractor_ContractorList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillContractorList();
        }
    }
    private void fillContractorList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType =CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Contractor_SelectByUserID]";
        if (Session["UserID"].ToString() != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if(objSdr.HasRows)
        {
            gvContractorList.DataSource = objSdr;
            gvContractorList.DataBind();
        }
        objCon.Close();

    }

    protected void gvContractorList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteContractor")
        {
            SqlString ContractorID = e.CommandArgument.ToString().Trim();
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Contractor_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@ContractorID",ContractorID);
            objCmd.ExecuteNonQuery();
            fillContractorList();
            objCon.Close();
        }
    }
}