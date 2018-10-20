using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


public partial class CMMWeb_AdminPanel_Salary_SalaryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillSalaryList();
        }
    }

    private void fillSalaryList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Salary_SelectByUserID_And_FinYear]";
        objCmd.Parameters.AddWithValue("@UserID",Session["UserID"].ToString());
        objCmd.Parameters.AddWithValue("@FinYear", Session["FinName"].ToString());
        SqlDataAdapter sda = new SqlDataAdapter(objCmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        gvSalaryList.DataSource = dt;
        gvSalaryList.DataBind();
        
        objCon.Close();
    }
    protected void gvSalaryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String SalaryID = e.CommandArgument.ToString();
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Salary_Delete";
        objCmd.Parameters.AddWithValue("@SalaryID", SalaryID);
        objCmd.ExecuteNonQuery();
        objCon.Close();
        fillSalaryList();
    }
}