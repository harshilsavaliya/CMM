using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CMMWeb_AdminPanel_FinYear_FinYearList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillFinYearList();
        }
    }
    protected void gvFinYearList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteFinYear")
        {
            String FinYearID = e.CommandArgument.ToString();
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_MST_FinYear_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@FinYearID",FinYearID);
            objCmd.ExecuteNonQuery();
            objCon.Close();
            fillFinYearList();
        }
    }
    private void fillFinYearList()
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
            gvFinYearList.DataSource = objSdr;
            gvFinYearList.DataBind();
        }
        objCon.Close();
    }
}