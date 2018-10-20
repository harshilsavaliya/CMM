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

public partial class CMMWeb_AdminPanel_Salary_SalaryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SalaryID"] != null)
            {
                fillControls();
                Page.Title = "Salary Edit";
                lblTitle.Text = "SALARY EDIT";
            }
            else
            {
                lblTitle.Text = "SALARY ADD";
                Page.Title = "Salary Add";
            }
            fillddlWorker();
            fillddlMonth();
            txtFinYear.Text = Session["FinName"].ToString();
         
        }
    }


    private void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_Salary_SelectByPK]";
        objcmd.Parameters.AddWithValue("@SalaryID", Request.QueryString["SalaryID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["WorkerID"].Equals(DBNull.Value) == false)
            {
                ddlWorkerID.SelectedValue = objSdr["WorkerID"].ToString().Trim();
            }

            if (objSdr["MonthID"].Equals(DBNull.Value) == false)
            {
                ddlMonthID.SelectedValue = objSdr["MonthID"].ToString().Trim();
            }

            if (objSdr["FinYear"].Equals(DBNull.Value) == false)
            {
                txtFinYear.Text = objSdr["FinYear"].ToString().Trim();
            }
            if (objSdr["TotalWorkingDays"].Equals(DBNull.Value) == false)
            {
                txtWorkingDays.Text = objSdr["TotalWorkingDays"].ToString().Trim();
            }

            if (objSdr["AbsentDays"].Equals(DBNull.Value) == false)
            {
                txtAbsentDays.Text = objSdr["AbsentDays"].ToString().Trim();
            }
            if (objSdr["PerDaySalary"].Equals(DBNull.Value) == false)
            {
                txtPerDaySalary.Text = objSdr["PerDaySalary"].ToString().Trim();
            }

            if (objSdr["Deduction"].Equals(DBNull.Value) == false)
            {
               txtDeduction.Text = objSdr["Deduction"].ToString().Trim();
            }
            if (objSdr["TotalSalary"].Equals(DBNull.Value) == false)
            {
                txtTotalSalary.Text = objSdr["TotalSalary"].ToString().Trim();
            }

            if (objSdr["IsPaid"].Equals(DBNull.Value) == false)
            {
                cdIsPaid.Checked = Convert.ToBoolean(objSdr["IsPaid"].ToString().Trim());
            }
        }
        objcon.Close();
    }
    private void fillddlWorker()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.Text;
        objCmd.CommandText = "Select WorkerName+' - '+WorkerCode AS Worker,WorkerID FROM CMM_Worker";

        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlWorkerID.DataSource = objSdr;
            ddlWorkerID.DataValueField = "WorkerID";
            ddlWorkerID.DataTextField = "Worker";
            ddlWorkerID.DataBind();
        }
        ddlWorkerID.Items.Insert(0, new ListItem("Select Worker", "-1"));
        objCon.Close();
    }
    
    private void fillddlMonth()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Month_Select]";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlMonthID.DataSource = objSdr;
            ddlMonthID.DataValueField = "MonthID";
            ddlMonthID.DataTextField = "MonthName";
            ddlMonthID.DataBind();
        }
        ddlMonthID.Items.Insert(0,new ListItem("Select Month","-1"));
        objCon.Close();        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlInt32 strWorkerID = SqlInt32.Null;
        SqlInt32 strMonthID = SqlInt32.Null;
        SqlInt32 strIsPaid = SqlInt32.Null;

        SqlString strWorkingDays = SqlString.Null;
        SqlString strPerDaySalary = SqlString.Null;
        SqlString strAbsentDays = SqlString.Null;
        SqlString strTotalSalary = SqlString.Null;
        SqlString strDeduction = SqlString.Null;

        strWorkerID = Convert.ToInt32(ddlWorkerID.SelectedValue);
        strMonthID = Convert.ToInt32(ddlMonthID.SelectedValue);

        if (cdIsPaid.Checked == true)
        {
            strIsPaid = 1;
        }
        else
        {
            strIsPaid = 0;
        }

        if (txtWorkingDays.Text.Trim() != "")
        {
            strWorkingDays = txtWorkingDays.Text.Trim();
        }
        if (txtPerDaySalary.Text.Trim() != "")
        {
            strPerDaySalary = txtPerDaySalary.Text.Trim();
        }
        if (txtAbsentDays.Text.Trim() != "")
        {
            strAbsentDays = txtAbsentDays.Text.Trim();
        }
        if (txtTotalSalary.Text.Trim() != "")
        {
            strTotalSalary = txtTotalSalary.Text.Trim();
        }
        if (txtDeduction.Text.Trim() != "")
        {
            strDeduction = txtDeduction.Text.Trim();
        }

        if (Request.QueryString["SalaryID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_CMM_Salary_Insert]";
            objCmd.Parameters.AddWithValue("@WorkerID", strWorkerID);
            objCmd.Parameters.AddWithValue("@MonthID", strMonthID);
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
            txtDeduction.Text = "";
            txtPerDaySalary.Text = "";
            txtTotalSalary.Text = "";
            txtWorkingDays.Text = "";
            txtAbsentDays.Text = "";
            txtTotalSalaryInWords.Text = "";
            ddlMonthID.SelectedIndex = -1;
            ddlWorkerID.SelectedIndex = -1;
        }

        else
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_CMM_Salary_UpdateByPK]";
            objCmd.Parameters.AddWithValue("@WorkerID", strWorkerID);
            objCmd.Parameters.AddWithValue("@MonthID", strMonthID);
            objCmd.Parameters.AddWithValue("@TotalWorkingDays", strWorkingDays);
            objCmd.Parameters.AddWithValue("@PerDaySalary", strPerDaySalary);
            objCmd.Parameters.AddWithValue("@TotalSalary", strTotalSalary);
            objCmd.Parameters.AddWithValue("@AbsentDays", strAbsentDays);
            objCmd.Parameters.AddWithValue("@Deduction", strDeduction);
            objCmd.Parameters.AddWithValue("@IsPaid", strIsPaid);

            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            objCmd.Parameters.AddWithValue("@FinYear", Session["FinName"].ToString());
            objCmd.Parameters.AddWithValue("@SalaryID",Request.QueryString["SalaryID"].ToString());
            objCmd.ExecuteNonQuery();
            Response.Redirect("~/CMMWeb/AdminPanel/Salary/SalaryList.aspx");
            objCon.Close();
        }
    }
    public void txtPerDaySalary_TextChanged()
    {
        SqlInt32 WorkingDays = SqlInt32.Null;
        SqlInt32 PerDaySalary = SqlInt32.Null;
        SqlInt32 AbsentDays = SqlInt32.Null;
        SqlInt32 Deduction = SqlInt32.Null;

        if (txtWorkingDays.Text.Trim() != "")
        {
            WorkingDays = Convert.ToInt32(txtWorkingDays.Text.Trim());
        }
        else
        {
            WorkingDays = 0;
        }
        if (txtPerDaySalary.Text.Trim() != "")
        {
            PerDaySalary = Convert.ToInt32(txtPerDaySalary.Text.Trim());
        }
        else
        {
            PerDaySalary = 0;
        }
        if (txtAbsentDays.Text.Trim() != "")
        {
            AbsentDays = Convert.ToInt32(txtAbsentDays.Text.Trim());
        }
        else
        {
            AbsentDays = 0;
        }
        if (txtDeduction.Text.Trim() != "")
        {
            Deduction = Convert.ToInt32(txtDeduction.Text.Trim());
        }
        else
        {
            Deduction = 0;
        }
        SqlInt32 salary;
        salary=WorkingDays*PerDaySalary;
        Deduction=AbsentDays*PerDaySalary;
        txtDeduction.Text = Convert.ToString(Deduction);
        txtTotalSalary.Text = Convert.ToString(salary-Deduction);
        txtTotalSalaryInWords.Text = ConvertNumbertoWords(Convert.ToInt32(txtTotalSalary.Text));
    }
    protected void txtAbsentDays_TextChanged(object sender, EventArgs e)
    {
        SqlInt32 WorkingDays = SqlInt32.Null;
        SqlInt32 PerDaySalary = SqlInt32.Null;
        SqlInt32 AbsentDays = SqlInt32.Null;
        SqlInt32 Deduction = SqlInt32.Null;

        if (txtWorkingDays.Text.Trim() != "")
        {
            WorkingDays = Convert.ToInt32(txtWorkingDays.Text.Trim());
        }
        else
        {
            WorkingDays = 0;
        }
        if (txtPerDaySalary.Text.Trim() != "")
        {
            PerDaySalary = Convert.ToInt32(txtPerDaySalary.Text.Trim());
        }
        else
        {
            PerDaySalary=0;
        }
        if (txtAbsentDays.Text.Trim() != "")
        {
            AbsentDays = Convert.ToInt32(txtAbsentDays.Text.Trim());
        }
        else
        {
            AbsentDays = 0;
        }
        if (txtDeduction.Text.Trim() != "")
        {
            Deduction = Convert.ToInt32(txtDeduction.Text.Trim());
        }
        else
        {
            Deduction = 0;
        }
        SqlInt32 salary;
        salary = WorkingDays * PerDaySalary;
        Deduction = AbsentDays * PerDaySalary;
        txtDeduction.Text=Convert.ToString(Deduction);
        txtTotalSalary.Text = Convert.ToString(salary - Deduction);
        txtTotalSalaryInWords.Text = ConvertNumbertoWords(Convert.ToInt32(txtTotalSalary.Text));
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
    protected void ddlWorkerID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.Text;
        objCmd.CommandText = "Select PerDayRupees from CMM_Worker Where WorkerID="+ddlWorkerID.SelectedValue;
        SqlDataReader objSdr = objCmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["PerDayRupees"].Equals(DBNull.Value) == false)
            {
                txtPerDaySalary.Text = objSdr["PerDayRupees"].ToString().Trim();
            }
        }
        txtPerDaySalary_TextChanged();
     }
    protected void ddlMonthID_SelectedIndexChanged(object sender, EventArgs e)
    {
        calculateDays();
    }


    public void calculateDays()
    {
        string strFinyear = txtFinYear.Text; 
        string year = strFinyear.Substring(5,2);
        year = "20" + year;
        string month = ddlMonthID.SelectedValue;
        int days = DateTime.DaysInMonth(Convert.ToInt32(year),Convert.ToInt32(month));
        txtWorkingDays.Text = days.ToString();
        txtPerDaySalary_TextChanged();

    }
}