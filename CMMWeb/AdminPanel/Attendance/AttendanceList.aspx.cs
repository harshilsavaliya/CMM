using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Attendance_AttendanceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillAttendanceList();
        }
    }

    private void fillAttendanceList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_AttendanceSelectByFinYear_And_UserID]";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        if (Session["FinID"] != null)
        {
            objCmd.Parameters.AddWithValue("@FinYearID", Session["FinID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvAttendanceList.DataSource = objSdr;
            gvAttendanceList.DataBind();
        }
        objCon.Close();
    }
    protected void gvAttendanceList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String AttendanceID = e.CommandArgument.ToString();
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Attendance_DeleteByPK]";
        objCmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);
        objCmd.ExecuteNonQuery();
        objCon.Close();
        fillAttendanceList();
    }
}