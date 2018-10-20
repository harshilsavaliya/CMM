using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CMMWeb_AdminPanel_Salary_SalaryView : System.Web.UI.Page
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
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_Salary_SelectByPK_FOR_VIEW]";
        objcmd.Parameters.AddWithValue("@SalaryID", Request.QueryString["SalaryID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["AbsentDays"].Equals(DBNull.Value) == false)
            {
                lblAbsentDays.Text = objSdr["AbsentDays"].ToString().Trim();
            }
            if (objSdr["Deduction"].Equals(DBNull.Value) == false)
            {
                lblDeduction.Text = objSdr["Deduction"].ToString().Trim();
            }
            if (objSdr["FinYear"].Equals(DBNull.Value) == false)
            {
                lblFinYear.Text = objSdr["FinYear"].ToString().Trim();
            }
            if (objSdr["IsPaid"].Equals(DBNull.Value) == false)
            {
                lblIsPaid.Text = objSdr["IsPaid"].ToString().Trim();
            }
            if (objSdr["MonthID"].Equals(DBNull.Value) == false)
            {
                lblMonth.Text = (objSdr["MonthID"].ToString().Trim());
            }

            if (objSdr["PerDaySalary"].Equals(DBNull.Value) == false)
            {
                lblPerDaySalary.Text = (objSdr["PerDaySalary"].ToString().Trim());
            }

            if (objSdr["TotalSalary"].Equals(DBNull.Value) == false)
            {
                lblTotalSalary.Text = objSdr["TotalSalary"].ToString().Trim();
            }

            if (objSdr["WorkerID"].Equals(DBNull.Value) == false)
            {
                lblWorker.Text = objSdr["WorkerID"].ToString().Trim();
            }
            if (objSdr["TotalWorkingDays"].Equals(DBNull.Value) == false)
            {
                lblWorkingDays.Text = objSdr["TotalWorkingDays"].ToString().Trim();
            }            
        }
        objcon.Close();
    }
}