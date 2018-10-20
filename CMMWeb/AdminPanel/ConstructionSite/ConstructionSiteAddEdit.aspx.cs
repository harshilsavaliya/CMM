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

public partial class CMMWeb_AdminPanel_ConstuctionSite_ConstructionSiteAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }

        if (!Page.IsPostBack)
        {
            fillControls();
        }
    }

    protected void fillControls()
    {
        if (Request.QueryString["ConstructionSiteID"] != null)
        {
            lblTitle.Text = "CONSTRUCTIONSITE EDIT";
            Page.Title="ConstructionSite Edit";
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_ConstructionSite_SelectByPK]";
            objCmd.Parameters.AddWithValue("@ConstructionSiteID", Request.QueryString["ConstructionSiteID"].ToString());
            SqlDataReader objSdr = objCmd.ExecuteReader();
            while (objSdr.Read() == true)
            {
                if (objSdr["ConstructionSiteName"].Equals(DBNull.Value) == false)
                {
                    txtConstructionSiteName.Text = objSdr["ConstructionSiteName"].ToString().Trim();
                }

                if (objSdr["SiteAddress"].Equals(DBNull.Value) == false)
                {
                    txtSiteAddress.Text = objSdr["SiteAddress"].ToString().Trim();
                }

                if (objSdr["State"].Equals(DBNull.Value) == false)
                {
                    txtState.Text = objSdr["State"].ToString().Trim();
                }

                if (objSdr["City"].Equals(DBNull.Value) == false)
                {
                    txtCity.Text = objSdr["City"].ToString().Trim();
                }

                if (objSdr["IsActive"].Equals(DBNull.Value) == false)
                {
                    cdIsActive.Checked = Convert.ToBoolean(objSdr["IsActive"].ToString().Trim());
                }
            }
            objCon.Close();
        }
        else
        {
            Page.Title = "ConstructionSite Add";
            lblTitle.Text = "CONSTRUCTIONSITE ADD";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString var = SqlString.Null;
        SqlString strConstructionSiteName = SqlString.Null;
        SqlString strConstructionSiteAddress = SqlString.Null;
        SqlString strState = SqlString.Null;
        SqlString strCity = SqlString.Null;
        SqlInt32 strISACtive = SqlInt32.Null;

        if (txtConstructionSiteName.Text.Trim() != "")
        {
            strConstructionSiteName = txtConstructionSiteName.Text.Trim();
        }

        if (txtSiteAddress.Text.Trim() != "")
        {
            strConstructionSiteAddress = txtSiteAddress.Text.Trim();
        }

        if (txtState.Text.Trim() != "")
        {
            strState = txtState.Text.Trim();
        }

        if (txtCity.Text.Trim() != "")
        {
            strCity = txtCity.Text.Trim();
        }

        if (cdIsActive.Checked == true)
        {
            strISACtive = 1;
        }
        else
        {
            strISACtive = 0;
        }
        if (Request.QueryString["ConstructionSiteID"] != null)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objConn.Open();
            SqlCommand objCmdd = new SqlCommand();
            objCmdd.Connection = objConn;
            objCmdd.CommandType = CommandType.StoredProcedure;
            objCmdd.CommandText = "[PR_CMM_ConstructionSite_SelectByPK]";
            objCmdd.Parameters.AddWithValue("@ConstructionSiteID", Request.QueryString["ConstructionSiteID"].ToString());
            SqlDataReader objSdrr = objCmdd.ExecuteReader();
            while (objSdrr.Read() == true)
            {
                if (objSdrr["ConstructionSiteName"].Equals(DBNull.Value) == false)
                {
                    var = objSdrr["ConstructionSiteName"].ToString().Trim();
                }
            }
            objConn.Close();

            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_ConstructionSite_SelectByUserID_AND_ExceptSiteName]";
            objCmd.Parameters.AddWithValue("@ConstructionSiteName", strConstructionSiteName);
            objCmd.Parameters.AddWithValue("@ExceptConstructionSiteName", var);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows == true)
            {
                lblMessage.Text = "You can't Enter same Construction<br> Site Name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtConstructionSiteName.Text = "";
                txtSiteAddress.Text = "";
                txtState.Text = "";
                txtCity.Text = "";
                txtConstructionSiteName.Focus();
                objCon.Close();
            }
            else
            {
                SqlConnection objCo = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objCo.Open();
                SqlCommand objCm = new SqlCommand();
                objCm.Connection = objCo;

                objCm.CommandType = CommandType.StoredProcedure;
                objCm.CommandText = "[PR_CMM_ConstructionSite_UpdateByPK]";
                objCm.Parameters.AddWithValue("@ConstructionSiteID", Request.QueryString["ConstructionSiteID"].ToString().Trim());
                objCm.Parameters.AddWithValue("@SiteAddress", strConstructionSiteAddress);
                objCm.Parameters.AddWithValue("@State", strState);
                objCm.Parameters.AddWithValue("@City", strCity);
                objCm.Parameters.AddWithValue("@IsActive", strISACtive);
                objCm.Parameters.AddWithValue("@ConstructionSiteName", strConstructionSiteName);
                if (Session["UserID"] != null)
                {
                    objCm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                }
                objCm.ExecuteNonQuery();
                Response.Redirect("~/CMMWeb/AdminPanel/ConstructionSite/ConstructionSiteList.aspx");
                objCo.Close();
            }
        }



        if (Request.QueryString["ConstructionSiteID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_ConstructionSite_SelectByUserIDANDSiteName]";
            objCmd.Parameters.AddWithValue("@ConstructionSiteName", strConstructionSiteName);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows == true)
            {
                lblMessage.Text = "You can't Enter same Construction<br> Site Name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtConstructionSiteName.Text = "";
                txtSiteAddress.Text = "";
                txtState.Text = "";
                txtCity.Text = "";
                txtConstructionSiteName.Focus();
                objCon.Close();
            }
            else
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objConn.Open();
                SqlCommand objCmdd = new SqlCommand();
                objCmdd.Connection = objConn;

                objCmdd.CommandType = CommandType.StoredProcedure;
                objCmdd.CommandText = "[PR_CMM_ConstructionSite_InsertByUserID]";
                objCmdd.Parameters.AddWithValue("@SiteAddress", strConstructionSiteAddress);
                objCmdd.Parameters.AddWithValue("@State", strState);
                objCmdd.Parameters.AddWithValue("@City", strCity);
                objCmdd.Parameters.AddWithValue("@IsActive", strISACtive);
                objCmdd.Parameters.AddWithValue("@ConstructionSiteName", strConstructionSiteName);
                if (Session["UserID"] != null)
                {
                    objCmdd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                }
                objCmdd.ExecuteNonQuery();
                objConn.Close();
                txtConstructionSiteName.Text = "";
                txtSiteAddress.Text = "";
                txtState.Text = "";
                txtCity.Text = "";
                cdIsActive.Checked = false;
                txtConstructionSiteName.Focus();
                lblMessage.Text = "Data has been Inserted sucessfully";
                lblMessage.Attributes["class"] = "btn btn-success";
            }

        }
    }
}