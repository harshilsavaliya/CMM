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

public partial class CMMWeb_AdminPanel_FinYear_FinYearAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["FinYearID"] != null)
            {
                lblTitle.Text = "FIN. YEAR EDIT";
                Page.Title = "Fin. Year Edit";
                fillControls();
            }
            else
            {
                Page.Title = "Fin. Year Add";
                lblTitle.Text = "FIN. YEAR ADD";
            }
        }
    }

    private void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_MST_FinYear_SelectByPK]";
        objcmd.Parameters.AddWithValue("@FinYearID", Request.QueryString["FinYearID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["FinName"].Equals(DBNull.Value) == false)
            {
                txtFinYear.Text = objSdr["FinName"].ToString().Trim();
            }

            if (objSdr["IsActive"].Equals(DBNull.Value) == false)
            {
                cdIsActive.Checked = Convert.ToBoolean(objSdr["IsActive"].ToString().Trim());
            }
            if (!objSdr["FromDate"].Equals(DBNull.Value))
            {
                txtFromDate.Text = objSdr["FromDate"].ToString().Trim();
            }
            if (!objSdr["ToDate"].Equals(DBNull.Value))
            {
                txtToDate.Text = objSdr["ToDate"].ToString().Trim();
            }
            if (!objSdr["Sequence"].Equals(DBNull.Value))
            {
                txtSequence.Text = objSdr["Sequence"].ToString().Trim();
            }
        }
        objcon.Close();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlDateTime strFromDate=SqlDateTime.Null;
        SqlDateTime strToDate=SqlDateTime.Null;
        SqlString strFinYear=SqlString.Null;
        SqlString strSequence=SqlString.Null;
        SqlInt32 strIsActive=SqlInt32.Null;
        
        if(txtFromDate.Text.Trim()!="")
        {
            strFromDate=Convert.ToDateTime(txtFromDate.Text.Trim());
        }
        if(txtToDate.Text.Trim()!="")
        {
            strToDate=Convert.ToDateTime(txtToDate.Text.Trim());
        }
        if(txtFinYear.Text.Trim()!="")
        {
            strFinYear=txtFinYear.Text.Trim();
        }
        if (cdIsActive.Checked)
        {
            strIsActive = 1;
        }
        else
        {
            strIsActive = 0;
        }
        if (txtSequence.Text.Trim() !="")
        {
            strSequence = txtSequence.Text.Trim();
        }
#region insert
        if (Request.QueryString["FinYearID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "CMM_MST_FinYear_Insert";
            objCmd.Parameters.AddWithValue("@FromDate", strFromDate);
            objCmd.Parameters.AddWithValue("@ToDate", strToDate);
            objCmd.Parameters.AddWithValue("@FinName", strFinYear);
            objCmd.Parameters.AddWithValue("@IsActive", strIsActive);
            objCmd.Parameters.AddWithValue("@Sequence", strSequence);
            
            objCmd.ExecuteNonQuery();
            lblMessage.Text = "Data has been inserted successfully";
            lblMessage.CssClass = "btn btn-success";
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtSequence.Text = "";
            txtFinYear.Text = "";
            cdIsActive.Checked = false;
            objCon.Close();
        }
#endregion
        #region update
        else
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "CMM_MST_FinYear_UpdateByPK";
            
            objCmd.Parameters.AddWithValue("@FromDate", strFromDate);
            objCmd.Parameters.AddWithValue("@ToDate", strToDate);
            objCmd.Parameters.AddWithValue("@FinName", strFinYear);
            objCmd.Parameters.AddWithValue("@IsActive", strIsActive);
            objCmd.Parameters.AddWithValue("@Sequence", strSequence);
            objCmd.Parameters.AddWithValue("@FinYearID", Request.QueryString["FinYearID"].ToString());
            objCmd.ExecuteNonQuery();
            objCon.Close();
            Response.Redirect("~/CMMWeb/AdminPanel/FinYear/FinYearList.aspx");
        }
        #endregion
    }
        
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        DateTime strToDate;

        int strFromDate=0;
        string todate = "";

        if (txtFromDate.Text.Trim() != "")
        {
            strFromDate = Convert.ToDateTime(txtFromDate.Text.Trim()).Year;
        }
        if (txtToDate.Text.Trim() != "")
        {
            strToDate = Convert.ToDateTime(txtToDate.Text.Trim());
            //intToDate = Convert.ToDateTime(txtToDate.Text.Trim()).Year;
            todate = strToDate.ToString("yy");
        }
        txtFinYear.Text = strFromDate + "-" + todate;
    }

}