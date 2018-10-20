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

public partial class CMMWeb_AdminPanel_Contractor_ContractorAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }

        if (!Page.IsPostBack)
        {
            #region assingining controls
            if (Request.QueryString["ContractorID"] != null)
            {
                lblTitle.Text = "CONTRACTOR EDIT";
                Page.Title = "Contractor Edit";
                SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCon.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_CMM_Contractor_SelectByPK]";
                objCmd.Parameters.AddWithValue("@ContractorID", Request.QueryString["ContractorID"].ToString());
                SqlDataReader objSdr = objCmd.ExecuteReader();
                while (objSdr.Read() == true)
                {
                    if (objSdr["ContractorName"].Equals(DBNull.Value) == false)
                    {
                        txtContractorName.Text = objSdr["ContractorName"].ToString().Trim();
                    }
                    if (objSdr["IsActive"].Equals(DBNull.Value) == false)
                    {
                        cdIsActive.Checked = Convert.ToBoolean(objSdr["IsActive"].ToString().Trim());
                    }
                }
                objCon.Close();
            }
            #endregion
            else
            {
                Page.Title = "Contractor Add";
                lblTitle.Text = "CONTRACTOR ADD";
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Add
        if (Request.QueryString["ContractorID"] == null)
        {
            #region checking for duplicate Entry
            SqlString strContractorName = SqlString.Null;
            SqlInt32 strIsActive = SqlInt32.Null;

            if (txtContractorName.Text != "")
            {
                strContractorName = txtContractorName.Text.Trim();
            }

            if (cdIsActive.Checked == true)
            {
                strIsActive = 1;
            }
            else
            {
                strIsActive = 0;
            }
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Contractor_SelectByUserIDANDContractorName]";
            objCmd.Parameters.AddWithValue("@ContractorName", strContractorName);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows == true)
            {
                lblMessage.Text = "You can't Enter same Contractor<br>Name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtContractorName.Text = "";
                txtContractorName.Focus();
                objCon.Close();
            }
            #endregion

            #region Add
            else
            {
                objCon.Close();
                objCon.Open();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_CMM_Contractor_InsertByUserID";
                objCmd.Parameters.AddWithValue("@IsActive", strIsActive);
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Data has been inserted successfully";
                lblMessage.CssClass = "btn btn-success";
                txtContractorName.Text = "";
                cdIsActive.Checked = false;
                objCon.Close();
            }
            #endregion
        }
        #endregion

        #region Edit
        if (Request.QueryString["ContractorID"] != null)
        {
            #region checking for duplicate entry
            SqlString var = SqlString.Null;
            
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Contractor_SelectByPK]";
            objCmd.Parameters.AddWithValue("@ContractorID", Request.QueryString["ContractorID"].ToString());
            SqlDataReader objSdr = objCmd.ExecuteReader();
            while (objSdr.Read() == true)
            {
                if (objSdr["ContractorName"].Equals(DBNull.Value) == false)
                {
                    var = objSdr["ContractorName"].ToString().Trim();
                }
            }
            objCon.Close();


            SqlString strContractorName = SqlString.Null;
            SqlInt32 strIsActive = SqlInt32.Null;
            if (txtContractorName.Text != "")
            {
                strContractorName = txtContractorName.Text.Trim();
            }

            if (cdIsActive.Checked == true)
            {
                strIsActive = 1;
            }
            else
            {
                strIsActive = 0;
            }

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objConn.Open();
            SqlCommand objCmdd = new SqlCommand();
            objCmdd.Connection = objConn;

            objCmdd.CommandType = CommandType.StoredProcedure;
            objCmdd.CommandText = "[PR_CMM_Contractor_SelectByUserID_AND_ExceptContractorName]";
            objCmdd.Parameters.AddWithValue("@ContractorName", strContractorName);
            objCmdd.Parameters.AddWithValue("@ExceptContractorName", var);
            if (Session["UserID"] != null)
            {
                objCmdd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSd = objCmdd.ExecuteReader();
            if (objSd.HasRows == true)
            {
                lblMessage.Text = "You can't Enter same Contractor<br>Name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtContractorName.Text = "";
                txtContractorName.Focus();
                objConn.Close();
            }
            #endregion

            #region update
            else
            {
                SqlConnection objCo = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCo.Open();
                SqlCommand objCm = new SqlCommand();
                objCm.Connection = objCo;

                objCm.CommandType = CommandType.StoredProcedure;
                objCm.CommandText = "PR_CMM_ContractorUpdateByPK";
                objCm.Parameters.AddWithValue("@ContractorName", strContractorName);
                objCm.Parameters.AddWithValue("@IsActive", strIsActive);
                objCm.Parameters.AddWithValue("@ContractorID", Request.QueryString["ContractorID"].ToString());
                if (Session["UserID"] != null)
                {
                    objCm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                }
                objCm.ExecuteNonQuery();
                Response.Redirect("~/CMMWeb/AdminPanel/Contractor/ContractorList.aspx");
                objCo.Close();
            }
            #endregion
        }
        #endregion
    }
}