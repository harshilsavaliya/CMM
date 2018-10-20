using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Attendance_AttendanceView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillControls();
        }
    }
    private void fillControls()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Attendance_SelectByPK_For_View]";
        objCmd.Parameters.AddWithValue("@AttendanceID", Request.QueryString["AttendanceID"].ToString());
        SqlDataReader objSdr = objCmd.ExecuteReader();
        while (objSdr.Read() == true)
        {
            if (objSdr["Date"].Equals(DBNull.Value) == false)
            {
                lblDate.Text = objSdr["Date"].ToString().Trim();
            }

            if (objSdr["Hour"].Equals(DBNull.Value) == false)
            {
                lblHour.Text = objSdr["Hour"].ToString().Trim();
            }

            if (objSdr["ConstructionSiteName"].Equals(DBNull.Value) == false)
            {
               lblConstructionSite.Text = (objSdr["ConstructionSiteName"].ToString().Trim());
            }

            if (objSdr["WorkerName"].Equals(DBNull.Value) == false)
            {
                lblWorker.Text = (objSdr["WorkerName"].ToString().Trim());
            }

            if (objSdr["ShiftID"].Equals(DBNull.Value) == false)
            {
                lblShift.Text= (objSdr["ShiftID"].ToString().Trim());
            }

            if (objSdr["Attendance"].Equals(DBNull.Value) == false)
            {
                lblAttedance.Text = (objSdr["Attendance"].ToString().Trim());
            }
        }
        objCon.Close();

    }

}