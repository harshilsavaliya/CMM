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

public partial class CMMWeb_AdminPanel_Unit_UnitAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["UnitID"] != null)
            {
                Page.Title = "Unit Edit";
                lblTitle.Text = "UNIT EDIT";
                fillControls();
            }
            else
            {
                Page.Title = "Unit Add";
                lblTitle.Text = "UNIT ADD";
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
        objcmd.CommandText = "[PR_CMM_Unit_SelectByPK]";
        objcmd.Parameters.AddWithValue("@UnitID", Request.QueryString["UnitID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["UnitName"].Equals(DBNull.Value) == false)
            {
                txtUnitName.Text = objSdr["UnitName"].ToString().Trim();
            }
            if (objSdr["IsSystem"].Equals(DBNull.Value) == false)
            {
                cdIsActive.Checked = Convert.ToBoolean(objSdr["IsSystem"].ToString().Trim());
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strUnitName = SqlString.Null;
        SqlInt32 strIsSystem = SqlInt32.Null;

        if (txtUnitName.Text != "")
        {
            strUnitName = txtUnitName.Text.Trim();
        }
        if (cdIsActive.Checked == true)
        {
            strIsSystem = 1;
        }
        else
        {
            strIsSystem = 0;
        }
        if (Request.QueryString["UnitID"] == null)
        {
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_Unit_SelectByUserID_AND_UnitName]";
            if (Session["UserID"] != null)
            {
                objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objcmd.Parameters.AddWithValue("@UnitName", strUnitName);
            SqlDataReader objSdr = objcmd.ExecuteReader();
            if (objSdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Unit<br>enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtUnitName.Text = "";
                cdIsActive.Checked = false;
                txtUnitName.Focus();
                objcon.Close();
            }
            else
            {
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_CMM_Unit_InsertByUserID]";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objCmd.Parameters.AddWithValue("@UnitName", strUnitName);
                objCmd.Parameters.AddWithValue("@IsSystem", strIsSystem);
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data has been Inserted sucessfully";
                lblMessage.Attributes["class"] = "btn btn-success";
                txtUnitName.Text = "";
                cdIsActive.Checked = false;
                txtUnitName.Focus();
                objCon.Close();
            }
        }
        if(Request.QueryString["UnitID"]!=null)
        {
            SqlString var = SqlString.Null;
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_Unit_SelectByPK]";
            objcmd.Parameters.AddWithValue("@UnitID", Request.QueryString["UnitID"].ToString());
            SqlDataReader objSdr = objcmd.ExecuteReader();
            while (objSdr.Read())
            {
                if (objSdr["UnitName"].Equals(DBNull.Value) == false)
                {
                    var = objSdr["UnitName"].ToString().Trim();
                }
            }
            objcon.Close();

            SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objco.Open();
            SqlCommand objcm = new SqlCommand();
            objcm.Connection = objco;
            objcm.CommandType = CommandType.StoredProcedure;
            objcm.CommandText = "[PR_CMM_Unit_SelectByUserID_AND_Except_UnitName]";
            if (Session["UserID"] != null)
            {
                objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objcm.Parameters.AddWithValue("@UnitName", strUnitName);
            objcm.Parameters.AddWithValue("@ExceptUnitName", var);
            SqlDataReader objsdr = objcm.ExecuteReader();
            if (objsdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Unit<br>enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtUnitName.Text = "";
                txtUnitName.Focus();
                objco.Close();
            }
            else
            {
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_CMM_Unit_UpdateByPK]";
                if (Session["UserID"] != null)
                {
                    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objCmd.Parameters.AddWithValue("@UnitName", strUnitName);
                objCmd.Parameters.AddWithValue("@IsSystem", strIsSystem);
                objCmd.Parameters.AddWithValue("@UnitID",Request.QueryString["UnitID"].ToString());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/CMMWeb/AdminPanel/Unit/UnitList.aspx");
                objCon.Close();
            }
        }
    }
}