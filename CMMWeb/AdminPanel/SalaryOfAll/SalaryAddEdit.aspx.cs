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

public partial class CMMWeb_AdminPanel_SalaryOfAll_SalaryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            txtFinYear.Text = Session["FinName"].ToString();
            fillMonth();
            fillddlConstuctionSite();
        }
    }
    private void fillMonth()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Month_Select";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlMonthID.DataSource = objSdr;
            ddlMonthID.DataValueField = "MonthID";
            ddlMonthID.DataTextField = "MonthName";
            ddlMonthID.DataBind();
        }
        ddlMonthID.Items.Insert(0, new ListItem("Select month", "-1"));
        objCon.Close();
    }

    private void fillddlConstuctionSite()
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
        ddlConstructionSiteID.Items.Insert(0, new ListItem("Select Construction site", "-1"));
        objCon.Close();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Worker_SelectByConstructionSiteID]";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        objCmd.Parameters.AddWithValue("@ConstructionSiteID",ddlConstructionSiteID.SelectedValue);
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvWorkerList.DataSource = objSdr;
            gvWorkerList.DataBind();
        }
        objCon.Close();
        calculateDays();
        findPerDaySalary();
        txtPerDaySalary_Calculation();
    }

    public void txtPerDaySalary_Calculation()
    {
        SqlInt32 WorkingDays = SqlInt32.Null;
        SqlInt32 PerDaySalary = SqlInt32.Null;
        SqlInt32 AbsentDays = SqlInt32.Null;
        SqlInt32 Deduction = SqlInt32.Null;

        foreach (GridViewRow row in gvWorkerList.Rows)
        {
            if (((TextBox)row.FindControl("txtWorkingDays")).Text.ToString().Trim() != "")
            {
                WorkingDays = Convert.ToInt32(((TextBox)row.FindControl("txtWorkingDays")).Text.ToString().Trim());
            }
            else
            {
                WorkingDays = 0;
            }
            if (((TextBox)row.FindControl("txtPerDaySalary")).Text.ToString().Trim() != "")
            {
                PerDaySalary = Convert.ToInt32(((TextBox)row.FindControl("txtPerDaySalary")).Text.ToString().Trim());
            }
            else
            {
                PerDaySalary = 0;
            }
            if (((TextBox)row.FindControl("txtAbsentDays")).Text.ToString().Trim() != "")
            {
                AbsentDays = Convert.ToInt32(((TextBox)row.FindControl("txtAbsentDays")).Text.ToString().Trim());
            }
            else
            {
                AbsentDays = 0;
            }
            if (((TextBox)row.FindControl("txtDeduction")).Text.ToString().Trim() != "")
            {
                Deduction = Convert.ToInt32(((TextBox)row.FindControl("txtDeduction")).Text.ToString().Trim());
            }
            else
            {
                Deduction = 0;
            }
            SqlInt32 salary;
            salary = WorkingDays * PerDaySalary;
            Deduction = AbsentDays * PerDaySalary;
            ((TextBox)row.FindControl("txtDeduction")).Text = Convert.ToString(Deduction);
            ((TextBox)row.FindControl("txtTotalSalary")).Text = Convert.ToString(salary - Deduction);
            ((TextBox)row.FindControl("txtTotalSalaryInWords")).Text = ConvertNumbertoWords(Convert.ToInt32(((TextBox)row.FindControl("txtTotalSalary")).Text));
        }      
    }

    public void findPerDaySalary()
    {
        foreach (GridViewRow row in gvWorkerList.Rows)
        {
            String strWorkerName;
            strWorkerName = (gvWorkerList.Rows[row.RowIndex].Cells[1].Text.ToString());
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Worker_Select_PerDayRupees_By_WorkerName]";
            objCmd.Parameters.AddWithValue("@WorkerName",strWorkerName);
            SqlDataReader objSdr = objCmd.ExecuteReader();
            while (objSdr.Read())
            {
                if (objSdr["PerDayRupees"].Equals(DBNull.Value) == false)
                {
                    ((TextBox)row.FindControl("txtPerDaySalary")).Text = objSdr["PerDayRupees"].ToString().Trim();
                }
            }
            objCon.Close();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlInt32 strMonthId = SqlInt32.Null;
        strMonthId = Convert.ToInt32(ddlMonthID.SelectedValue);
        foreach (GridViewRow row in gvWorkerList.Rows)
        {
            SqlInt32 strWorkerID = SqlInt32.Null;
            SqlInt32 strIsPaid = SqlInt32.Null;
            SqlInt32 strWorkingDays = SqlInt32.Null;
            SqlInt32 strPerDaySalary = SqlInt32.Null;
            SqlInt32 strAbsentDays = SqlInt32.Null;
            SqlInt32 strTotalSalary = SqlInt32.Null;
            SqlInt32 strDeduction = SqlInt32.Null;

            strWorkerID = Convert.ToInt32(gvWorkerList.Rows[row.RowIndex].Cells[0].Text);
            

            if (((TextBox)row.FindControl("txtWorkingDays")).Text.ToString().Trim() != "")
            {
                strWorkingDays = Convert.ToInt32(((TextBox)row.FindControl("txtWorkingDays")).Text.ToString().Trim());
            }
            else
            {
                strWorkingDays = 0;
            }
            if (((TextBox)row.FindControl("txtPerDaySalary")).Text.ToString().Trim() != "")
            {
                strPerDaySalary = Convert.ToInt32(((TextBox)row.FindControl("txtPerDaySalary")).Text.ToString().Trim());
            }
            else
            {
                strPerDaySalary = 0;
            }
            if (((TextBox)row.FindControl("txtAbsentDays")).Text.ToString().Trim() != "")
            {
                strAbsentDays = Convert.ToInt32(((TextBox)row.FindControl("txtAbsentDays")).Text.ToString().Trim());
            }
            else
            {
                strAbsentDays = 0;
            }
            if (((TextBox)row.FindControl("txtDeduction")).Text.ToString().Trim() != "")
            {
                strDeduction = Convert.ToInt32(((TextBox)row.FindControl("txtDeduction")).Text.ToString().Trim());
            }
            else
            {
                strDeduction = 0;
            }

            if (((TextBox)row.FindControl("txtTotalSalary")).Text.ToString().Trim() != "")
            {
                strTotalSalary = Convert.ToInt32(((TextBox)row.FindControl("txtTotalSalary")).Text.ToString().Trim());
            }
            else
            {
                strTotalSalary = 0;
            }

            if (((CheckBox)row.FindControl("chkIsPaid")).Checked)
            {
                strIsPaid = 1;
            }
            else 
            {
                strIsPaid = 0;
            }

            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_CMM_Salary_Insert]";
            objCmd.Parameters.AddWithValue("@WorkerID", strWorkerID);
            objCmd.Parameters.AddWithValue("@MonthID", strMonthId);
            objCmd.Parameters.AddWithValue("@TotalWorkingDays", strWorkingDays);
            objCmd.Parameters.AddWithValue("@PerDaySalary", strPerDaySalary);
            objCmd.Parameters.AddWithValue("@TotalSalary", strTotalSalary);
            objCmd.Parameters.AddWithValue("@AbsentDays", strAbsentDays);
            objCmd.Parameters.AddWithValue("@Deduction", strDeduction);
            objCmd.Parameters.AddWithValue("@IsPaid", strIsPaid);

            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@FinYear", Session["FinName"].ToString());
            objCmd.ExecuteNonQuery();
            objCon.Close();
            lblMessage.Text = "Data has been inserted successfully.";
            lblMessage.CssClass = "btn btn-success";
            ((TextBox)row.FindControl("txtWorkingDays")).Text = "";
            ddlMonthID.SelectedIndex = -1;
            ddlConstructionSiteID.SelectedIndex = -1;
            ddlMonthID.Focus();
            gvWorkerList.Visible = false;
        }
    }
    protected void ddlMonthID_SelectedIndexChanged(object sender, EventArgs e)
    {
        calculateDays();
    }

    public void calculateDays()
    {
        foreach (GridViewRow row in gvWorkerList.Rows)
        {
            string strFinyear = txtFinYear.Text;
            string year = strFinyear.Substring(5, 2);
            year = "20" + year;
            string month = ddlMonthID.SelectedValue;
            int days = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));
            ((TextBox)row.FindControl("txtWorkingDays")).Text = days.ToString();
        }
        txtPerDaySalary_Calculation();
    }
    protected void txtAbsentDays_TextChanged(object sender, EventArgs e)
    {
        txtPerDaySalary_Calculation();
    }

    public string ConvertNumbertoWords(long number)
    {

        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "") words += "AND ";
            var unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
            var tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
}