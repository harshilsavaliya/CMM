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

public partial class CMMWeb_AdminPanel_Attendance_AttendanceAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillddlConstructionSite();
            fillddlShift();
            ddlWorkerID.Items.Insert(0, new ListItem("Select Worker", "-1"));

            if (Request.QueryString["AttendanceID"] != null)
            {
                fillControls();
                lblTitle.Text = "ATTENDANCE EDIT";
                Page.Title = "Attendance Edit";
            }
            else
            {
                lblTitle.Text = "ATTENDANCE ADD";
                Page.Title = "Attendance Add";
            }
        }
    }

    private void fillControls()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_AttendanceSelectByPK]";
        objCmd.Parameters.AddWithValue("@AttendanceID", Request.QueryString["AttendanceID"].ToString());
        SqlDataReader objSdr = objCmd.ExecuteReader();
        while (objSdr.Read() == true)
        {
            if (objSdr["Date"].Equals(DBNull.Value) == false)
            {
                txtDate.Text = objSdr["Date"].ToString().Trim();
            }

            if (objSdr["Hour"].Equals(DBNull.Value) == false)
            {
                txtHour.Text = objSdr["Hour"].ToString().Trim();
            }

            if (objSdr["ConstructionSiteID"].Equals(DBNull.Value) == false)
            {
                ddlConstructionSiteID.SelectedValue = (objSdr["ConstructionSiteID"].ToString().Trim());
            }

            if (objSdr["WorkerID"].Equals(DBNull.Value) == false)
            {
                ddlWorkerID.SelectedValue = (objSdr["WorkerID"].ToString().Trim());
            }

            if (objSdr["ShiftID"].Equals(DBNull.Value) == false)
            {
                ddlShiftID.SelectedValue = (objSdr["ShiftID"].ToString().Trim());
            }

            if (objSdr["Attendance"].Equals(DBNull.Value) == false)
            {
                cdAttendance.Checked = Convert.ToBoolean(objSdr["Attendance"].ToString().Trim());
            }
        }
        objCon.Close();

    }

    private void fillddlConstructionSite()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_ConstructionSite_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlConstructionSiteID.DataSource = objSdr;
            ddlConstructionSiteID.DataValueField = "ConstructionSiteID";
            ddlConstructionSiteID.DataTextField = "ConstructionSiteName";
            ddlConstructionSiteID.DataBind();
        }
        ddlConstructionSiteID.Items.Insert(0, new ListItem("Select Constructionsite", "-1"));
        objCon.Close();
    }

    private void fillddlShift()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Shift_Select";

        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlShiftID.DataSource = objSdr;
            ddlShiftID.DataValueField = "ShiftID";
            ddlShiftID.DataTextField = "ShiftName";
            ddlShiftID.DataBind();
        }
        ddlShiftID.Items.Insert(0, new ListItem("Select Shift", "-1"));
        objCon.Close();
    }

    protected void ddlConstructionSiteID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlInt32 strConstructionSiteID = SqlInt32.Null;
        strConstructionSiteID = Convert.ToInt32(ddlConstructionSiteID.SelectedValue);
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Worker_SelectByConstructionSiteID]";
        objCmd.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlWorkerID.DataSource = objSdr;
            ddlWorkerID.DataValueField = "WorkerID";
            ddlWorkerID.DataTextField = "WorkerName";
            ddlWorkerID.DataBind();
        }
        ddlWorkerID.Items.Insert(0, new ListItem("Select Worker", "-1"));
        objCon.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strHour = SqlString.Null;
        SqlDateTime strDate = SqlDateTime.Null;
        SqlInt32 strConstructionSiteID = SqlInt32.Null;
        SqlInt32 strWorkerID = SqlInt32.Null;
        SqlInt32 strShiftID = SqlInt32.Null;
        SqlInt32 strAttendance = SqlInt32.Null;
       
        if (txtDate.Text != "")
        {
            strDate = Convert.ToDateTime(txtDate.Text.Trim());
        }
        if (txtHour.Text.Trim() != "")
        {
            strHour = txtHour.Text.Trim();
        }
        strConstructionSiteID = Convert.ToInt32(ddlConstructionSiteID.SelectedValue);
        strWorkerID = Convert.ToInt32(ddlWorkerID.SelectedValue);
        strShiftID = Convert.ToInt32(ddlShiftID.SelectedValue);

        if (cdAttendance.Checked)
        {
            strAttendance = 1;
        }
        else
        {
            strAttendance = 0;
        }
        if (Request.QueryString["AttendanceID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Attendance_Insert";
            objCmd.Parameters.AddWithValue("@Date", strDate);
            objCmd.Parameters.AddWithValue("@Hour", strHour);
            objCmd.Parameters.AddWithValue("@Attendance", strAttendance);
            objCmd.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
            objCmd.Parameters.AddWithValue("@ShiftID", strShiftID);
            objCmd.Parameters.AddWithValue("@WorkerID", strWorkerID);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            if (Session["FinID"] != null)
            {
                objCmd.Parameters.AddWithValue("@FinYearID", Session["FinID"].ToString());
            }
            objCmd.ExecuteNonQuery();
            lblMessage.Text = "Data has been inserted successfully";
            lblMessage.CssClass = "btn btn-success";
            txtDate.Text = "";
            txtHour.Text = "";
            ddlConstructionSiteID.SelectedIndex = 0;
            ddlShiftID.SelectedIndex = 0;
            ddlWorkerID.SelectedIndex = 0;
            cdAttendance.Checked = false;
            objCon.Close();
        }
        else
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Attendance_UpdateByPK]";
            objCmd.Parameters.AddWithValue("@Date", strDate);
            objCmd.Parameters.AddWithValue("@Hour", strHour);
            objCmd.Parameters.AddWithValue("@Attendance", strAttendance);
            objCmd.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
            objCmd.Parameters.AddWithValue("@ShiftID", strShiftID);
            objCmd.Parameters.AddWithValue("@WorkerID", strWorkerID);
            
            if (Request.QueryString["AttendanceID"].ToString()!=null)
            {
                objCmd.Parameters.AddWithValue("@AttendanceID", Request.QueryString["AttendanceID"].ToString());
            }
            objCmd.ExecuteNonQuery();
            Response.Redirect("~/CMMWeb/AdminPanel/Attendance/AttendanceList.aspx");
            objCon.Close();
        }
    }
}