using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_AddWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"]== null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["WorkerID"] != null)
            {
                fillControls();
                Page.Title = "Worker Edit";
                lblTitle.Text="WORKER EDIT";
            }
            else
            {
                lblTitle.Text="WORKER ADD";
                Page.Title="Worker Add";
            }
            fillddlWorkerType();
            fillddlProof();
            fillddlConstuctionSite();
        }
    }

    private void fillControls()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Worker_SelectByPK";
        objCmd.Parameters.AddWithValue("@WorkerID",Request.QueryString["WorkerID"].ToString());
        SqlDataReader objSdr = objCmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (!objSdr["PerDayRupees"].Equals(DBNull.Value))
            {
                txtPerDayRupees.Text = objSdr["PerDayRupees"].ToString().Trim();
            }
            if (!objSdr["WorkerCode"].Equals(DBNull.Value))
            {
                txtWorkerCode.Text = objSdr["WorkerCode"].ToString().Trim();
            }
            if (!objSdr["WorkerName"].Equals(DBNull.Value))
            {
                txtWorkerName.Text = objSdr["WorkerName"].ToString().Trim();
            }
            if (!objSdr["Address"].Equals(DBNull.Value))
            {
                txtAddress.Text = objSdr["Address"].ToString().Trim();
            }
            if (!objSdr["AMobileNo"].Equals(DBNull.Value))
            {
                txtAMobile.Text = objSdr["AMobileNo"].ToString().Trim();
            }
            if (!objSdr["MobileNo"].Equals(DBNull.Value))
            {
                txtMobile.Text = objSdr["MobileNo"].ToString().Trim();
            }
            if (!objSdr["CityName"].Equals(DBNull.Value))
            {
                txtCity.Text = objSdr["CityName"].ToString().Trim();
            }
            if (!objSdr["ProofNo"].Equals(DBNull.Value))
            {
                txtDocumentNumber.Text = objSdr["ProofNo"].ToString().Trim();
            }
            if (!objSdr["ConstructionSiteID"].Equals(DBNull.Value))
            {
                ddlConstructionSiteID.SelectedValue = objSdr["ConstructionSiteID"].ToString().Trim();
            }
            if (!objSdr["ProofID"].Equals(DBNull.Value))
            {
                ddlProofID.SelectedValue = objSdr["ProofID"].ToString().Trim();
            }
            if (!objSdr["WorkerTypeID"].Equals(DBNull.Value))
            {
                ddlWorkerTypeID.SelectedValue = objSdr["WorkerTypeID"].ToString().Trim();
            }
            if (objSdr["IsActive"].Equals(DBNull.Value) == false)
            {
                cdIsActive.Checked = Convert.ToBoolean(objSdr["IsActive"].ToString().Trim());
            }
        }
        objCon.Close();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strWorkerName=SqlString.Null;
        SqlString strCity=SqlString.Null;
        SqlString strDocumentNo=SqlString.Null;
        SqlString strMobileNo=SqlString.Null;
        SqlString strAMobileNo=SqlString.Null;
        SqlString strAddress=SqlString.Null;
        SqlString strWorkerCode = SqlString.Null;
        SqlString strPerDayRupees = SqlString.Null;

        SqlInt32 strIsActive=SqlInt32.Null;
        SqlInt32 strWorkerTypeID=SqlInt32.Null;
        SqlInt32 strConstructionSiteID=SqlInt32.Null;
        SqlInt32 strProofID=SqlInt32.Null;

        if (txtPerDayRupees.Text.Trim() != "")
        {
            strPerDayRupees = txtPerDayRupees.Text.Trim();
        }
        if (txtWorkerCode.Text.Trim() != "")
        {
            strWorkerCode = txtWorkerCode.Text.Trim();
        }
        if(txtAddress.Text.Trim().ToString()!="")
        {
            strAddress=txtAddress.Text.ToString().Trim();
        }
        if(txtAMobile.Text.Trim()!="")
        {
            strAMobileNo=txtAMobile.Text.ToString().Trim();
        }
        if(txtCity.Text.Trim()!="")
        {
            strCity=txtCity.Text.ToString().Trim();
        }
        if(txtDocumentNumber.Text.Trim()!="")
        {
            strDocumentNo=txtDocumentNumber.Text.Trim();
        }
        if(txtMobile.Text.Trim()!="")
        {
            strMobileNo=txtMobile.Text.Trim();
        }
        if(txtWorkerName.Text.Trim()!="")
        {
            strWorkerName=txtWorkerName.Text.Trim();
        }
        strWorkerTypeID=Convert.ToInt32(ddlWorkerTypeID.SelectedValue);
        strProofID=Convert.ToInt32(ddlProofID.SelectedValue);
        strConstructionSiteID=Convert.ToInt32(ddlConstructionSiteID.SelectedValue);

        if(cdIsActive.Checked)
        {
            strIsActive=1;
        }
        else
        {
            strIsActive=0;
        }

        #region add
        if (Request.QueryString["WorkerID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Worker_SelectByUserID_And_WokerName]";
            objCmd.Parameters.AddWithValue("@WorkerName", strWorkerName);
            if (Session["UserID"].ToString() != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows)
            {
                lblMessage.Text = "Enter another WorkerName";
                lblMessage.CssClass = "btn btn-danger";
                txtAddress.Text = "";
                txtAMobile.Text = "";
                txtCity.Text = "";
                txtDocumentNumber.Text = "";
                txtMobile.Text = "";
                txtWorkerName.Text = "";
                txtPerDayRupees.Text = "";
                txtWorkerCode.Text="";
                ddlConstructionSiteID.SelectedIndex = 0;
                ddlProofID.SelectedIndex = 0;
                ddlWorkerTypeID.SelectedIndex = 0;
                txtWorkerName.Focus();
                objCon.Close();
            }
            else
            {
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                    objConn.Open();
                    SqlCommand objCmdd = new SqlCommand();
                    objCmdd.Connection = objConn;
                    objCmdd.CommandType = CommandType.StoredProcedure;
                    objCmdd.CommandText = "[CMM_Worker_Insert]";
                    objCmdd.Parameters.AddWithValue("@WorkerName", strWorkerName);
                    objCmdd.Parameters.AddWithValue("@CityName", strCity);
                    objCmdd.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
                    objCmdd.Parameters.AddWithValue("@ProofID", strProofID);
                    objCmdd.Parameters.AddWithValue("@ProofNo", strDocumentNo);
                    objCmdd.Parameters.AddWithValue("@MobileNo", strMobileNo);
                    objCmdd.Parameters.AddWithValue("@AMobileNo", strAMobileNo);
                    objCmdd.Parameters.AddWithValue("@Address", strAddress);
                    objCmdd.Parameters.AddWithValue("@WorkerTypeID", strWorkerTypeID);
                    objCmdd.Parameters.AddWithValue("@IsActive", strIsActive);
                    objCmdd.Parameters.AddWithValue("@ImageName",filename);
                    objCmdd.Parameters.AddWithValue("@ImageSize",fileSize);
                    objCmdd.Parameters.AddWithValue("@ImageData",bytes);
                    objCmdd.Parameters.AddWithValue("@PerDayRupees",strPerDayRupees);
                    objCmdd.Parameters.AddWithValue("@WorkerCode",strWorkerCode);
                    SqlParameter paramNewId = new SqlParameter()
                    {
                        ParameterName = "@NewID",
                        Value = -1,
                        Direction = ParameterDirection.Output
                    };
                    objCmdd.Parameters.Add(paramNewId);
                    if (Session["UserID"].ToString() != null)
                    {
                        objCmdd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    }
                    objCmdd.ExecuteNonQuery();
                    objConn.Close();
                    lblMessage.Text = "Data has been inserted successfully";
                    lblMessage.CssClass = "btn btn-success";
                    txtAddress.Text = "";
                    txtAMobile.Text = "";
                    txtCity.Text = "";
                    txtDocumentNumber.Text = "";
                    txtPerDayRupees.Text = "";
                    txtWorkerCode.Text = "";
                    txtMobile.Text = "";
                    txtWorkerName.Text = "";
                    ddlConstructionSiteID.SelectedIndex = 0;
                    ddlProofID.SelectedIndex = 0;
                    ddlWorkerTypeID.SelectedIndex = 0;
                    txtWorkerName.Focus();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.CssClass = "btn btn-danger";
                    lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                    //hyperlink.Visible = false;
                }
            }
        }
        #endregion

        #region update
        else
        {
            SqlString var = SqlString.Null;
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objConn.Open();
            SqlCommand objCmdd = new SqlCommand();
            objCmdd.Connection = objConn;
            objCmdd.CommandType = CommandType.StoredProcedure;
            objCmdd.CommandText = "[PR_CMM_Worker_SelectByPK]";
            objCmdd.Parameters.AddWithValue("@WorkerID", Request.QueryString["WorkerID"].ToString());
            SqlDataReader objSdrr = objCmdd.ExecuteReader();
            while (objSdrr.Read() == true)
            {
                if (objSdrr["WorkerName"].Equals(DBNull.Value) == false)
                {
                    var = objSdrr["WorkerName"].ToString().Trim();
                }
            }
            objConn.Close();

            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_CMM_Worker_SelectByUserID_And_ExceptWokerName";
            objCmd.Parameters.AddWithValue("@WorkerName", strWorkerName);
            objCmd.Parameters.AddWithValue("@ExceptWorkerName", var);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows == true)
            {
                lblMessage.Text = "You can't Enter same Worker name enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtAddress.Text = "";
                txtAMobile.Text = "";
                txtCity.Text = "";
                txtDocumentNumber.Text = "";
                txtMobile.Text = "";
                txtWorkerName.Text = "";
                ddlConstructionSiteID.SelectedIndex = 0;
                ddlProofID.SelectedIndex = 0;
                ddlWorkerTypeID.SelectedIndex = 0;
                txtWorkerName.Focus();
                objCon.Close();
            }
            else
            {
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    SqlConnection objCo = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                    objCo.Open();
                    SqlCommand objCm = new SqlCommand();
                    objCm.Connection = objCo;

                    objCm.CommandType = CommandType.StoredProcedure;
                    objCm.CommandText = "[CMM_Worker_UpdateByPK]";
                    objCm.Parameters.AddWithValue("@WorkerName", strWorkerName);
                    objCm.Parameters.AddWithValue("@CityName", strCity);
                    objCm.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
                    objCm.Parameters.AddWithValue("@ProofID", strProofID);
                    objCm.Parameters.AddWithValue("@ProofNo", strDocumentNo);
                    objCm.Parameters.AddWithValue("@MobileNo", strMobileNo);
                    objCm.Parameters.AddWithValue("@AMobileNo", strAMobileNo);
                    objCm.Parameters.AddWithValue("@Address", strAddress);
                    objCm.Parameters.AddWithValue("@WorkerTypeID", strWorkerTypeID);
                    objCm.Parameters.AddWithValue("@IsActive", strIsActive);
                    objCm.Parameters.AddWithValue("@WorkerID", Request.QueryString["WorkerID"].ToString());
                    objCm.Parameters.AddWithValue("@WorkerCode", strWorkerCode);
                    objCm.Parameters.AddWithValue("@PerDayRupees", strPerDayRupees);
                    if (Session["UserID"] != null)
                    {
                        objCm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    }
                    objCm.Parameters.AddWithValue("@ImageName", filename);
                    objCm.Parameters.AddWithValue("@ImageSize", fileSize);
                    objCm.Parameters.AddWithValue("@ImageData", bytes);
                    SqlParameter paramNewId = new SqlParameter()
                    {
                        ParameterName = "@NewID",
                        Value = -1,
                        Direction = ParameterDirection.Output
                    };
                    objCm.Parameters.Add(paramNewId);
                    objCm.ExecuteNonQuery();
                    Response.Redirect("~/CMMWeb/AdminPanel/Worker/WorkerList.aspx");
                    objCo.Close();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.CssClass = "btn btn-danger";
                    lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                    //hyperlink.Visible = false;
                }
            }
        }
        #endregion
    }

    private void fillddlProof()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Proof_Select]";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlProofID.DataSource = objSdr;
            ddlProofID.DataTextField = "ProofName";
            ddlProofID.DataValueField = "ProofID";
            ddlProofID.DataBind();
        }
        ddlProofID.Items.Insert(0, new ListItem("Select Proof", "-99"));
        objCon.Close();
    }
    private void fillddlWorkerType()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_WorkerType_Select]";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlWorkerTypeID.DataSource = objSdr;
            ddlWorkerTypeID.DataTextField = "WorkerTypeName";
            ddlWorkerTypeID.DataValueField = "WorkerTypeID";
            ddlWorkerTypeID.DataBind();
        }
        ddlWorkerTypeID.Items.Insert(0,new ListItem("Select Worker type","-1"));
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
}