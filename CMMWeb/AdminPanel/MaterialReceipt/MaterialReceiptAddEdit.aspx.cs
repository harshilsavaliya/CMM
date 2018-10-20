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

public partial class CMMWeb_AdminPanel_MaterialReceipt_MaterialReceiptAddEdit : System.Web.UI.Page
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
            fillddlMaterialType();
            fillddlMaterial();
            fillddlUnit();
            fillddlContractor();
            fillddlSupplier();
            if (Request.QueryString["MaterialReceiptID"] != null)
            {
                fillControls();
                lblTitle.Text = "MATERIALRECEIPT EDIT";
                Page.Title = "Material Receipt Edit";
            }
            else
            {
                lblTitle.Text = "MATERIALRECEIPT ADD";
                Page.Title = "Material Receipt Add";
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
        objcmd.CommandText = "[PR_CMM_MaterialReceipt_SelectByPK]";
        objcmd.Parameters.AddWithValue("@MaterialReceiptID", Request.QueryString["MaterialReceiptID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["ReceiptDate"].Equals(DBNull.Value) == false)
            {
                txtReceiptDate.Text = objSdr["ReceiptDate"].ToString().Trim();
            }
            if (objSdr["ReceiptNo"].Equals(DBNull.Value) == false)
            {
                txtReceiptNo.Text = objSdr["ReceiptNo"].ToString().Trim();
            }
            if (objSdr["Quantity"].Equals(DBNull.Value) == false)
            {
                txtQuantity.Text = objSdr["Quantity"].ToString().Trim();
            }
            if (objSdr["DriverName"].Equals(DBNull.Value) == false)
            {
                txtDriverName.Text = objSdr["DriverName"].ToString().Trim();
            }
            if (objSdr["OtherDetail"].Equals(DBNull.Value) == false)
            {
                txtOtherDetail.Text = objSdr["OtherDetail"].ToString().Trim();
            }
            if (objSdr["VehicleNo"].Equals(DBNull.Value) == false)
            {
                txtVehicle.Text = objSdr["VehicleNo"].ToString().Trim();
            }
            if (objSdr["ConstructionSiteID"].Equals(DBNull.Value) == false)
            {
                ddlConstructionSiteID.SelectedValue = (objSdr["ConstructionSiteID"].ToString().Trim());
            }

            if (objSdr["UnitID"].Equals(DBNull.Value) == false)
            {
                ddlUnitID.SelectedValue = objSdr["UnitID"].ToString().Trim();
            }

            if (objSdr["MaterialTypeID"].Equals(DBNull.Value) == false)
            {
                ddlMaterialTypeID.SelectedValue = objSdr["MaterialTypeID"].ToString().Trim();
            }
            if (objSdr["ContractorID"].Equals(DBNull.Value) == false)
            {
                ddlContractorID.SelectedValue = (objSdr["ContractorID"].ToString().Trim());
            }

            if (objSdr["SupplierID"].Equals(DBNull.Value) == false)
            {
                ddlSupplierID.SelectedValue = objSdr["SupplierID"].ToString().Trim();
            }

            if (objSdr["MaterialID"].Equals(DBNull.Value) == false)
            {
                ddlMaterialID.SelectedValue = objSdr["MaterialID"].ToString().Trim();
            }

        }
        objcon.Close();
    }

    private void fillddlContractor()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Contractor_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlContractorID.DataSource = objSdr;
            ddlContractorID.DataValueField = "ContractorID";
            ddlContractorID.DataTextField = "ContractorName";
            ddlContractorID.DataBind();
        }
        ddlContractorID.Items.Insert(0, new ListItem("Select Contractor", "-1"));
        objCon.Close();
    }

    private void fillddlSupplier()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Supplier_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlSupplierID.DataSource = objSdr;
            ddlSupplierID.DataValueField = "SupplierID";
            ddlSupplierID.DataTextField = "SupplierName";
            ddlSupplierID.DataBind();
        }
        ddlSupplierID.Items.Insert(0, new ListItem("Select Supplier", "-1"));
        objCon.Close();
    }

    private void fillddlMaterial()
    {
        SqlInt32 strMaterialTypeID = SqlInt32.Null;
        strMaterialTypeID = Convert.ToInt32(ddlMaterialTypeID.SelectedValue);
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Material_SelectByPKForDropDown";        
        objCmd.Parameters.AddWithValue("@MaterialTypeID",strMaterialTypeID);
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlMaterialID.DataSource = objSdr;
            ddlMaterialID.DataValueField = "MaterialID";
            ddlMaterialID.DataTextField = "MaterialName";
            ddlMaterialID.DataBind();
            ddlMaterialID.Items.Insert(0, new ListItem("Select Material", "-1"));
        }
        else
        {
            ddlMaterialID.Items.Clear();
            ddlMaterialID.Items.Insert(0, new ListItem("Select Material", "-1"));
        }
        objCon.Close();
    }

    private void fillddlMaterialType()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_MaterialType_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlMaterialTypeID.DataSource = objSdr;
            ddlMaterialTypeID.DataValueField = "MaterialTypeID";
            ddlMaterialTypeID.DataTextField = "MaterialTypeName";
            ddlMaterialTypeID.DataBind();
        }
        ddlMaterialTypeID.Items.Insert(0, new ListItem("Select Material type", "-1"));
        objCon.Close();
    }

    private void fillddlUnit()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Unit_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlUnitID.DataSource = objSdr;
            ddlUnitID.DataValueField = "UnitID";
            ddlUnitID.DataTextField = "UnitName";
            ddlUnitID.DataBind();
        }
        ddlUnitID.Items.Insert(0, new ListItem("Select Unit", "-1"));
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString strReceiptNo = SqlString.Null;
        SqlDateTime strReceiptDate = SqlDateTime.Null;
        SqlInt32 strConstructionSiteID = SqlInt32.Null;
        SqlInt32 strMaterialTypeID = SqlInt32.Null;
        SqlInt32 strSupplierID = SqlInt32.Null;
        SqlInt32 strContractorID = SqlInt32.Null;
        SqlInt32 strUnitID = SqlInt32.Null;
        SqlInt32 strMaterialID = SqlInt32.Null;
        SqlString strQuantity = SqlString.Null;
        SqlString strVehicleNo = SqlString.Null;
        SqlString strDriverName = SqlString.Null;
        SqlString strOtherDetails = SqlString.Null;


        if (txtReceiptNo.Text.Trim() != "")
        {
            strReceiptNo = txtReceiptNo.Text.Trim();
        }
        if (txtVehicle.Text.Trim() != "")
        {
            strVehicleNo = txtVehicle.Text.Trim();
        }
        if (txtDriverName.Text.Trim() != "")
        {
            strDriverName = txtDriverName.Text.Trim();
        }
        if (txtOtherDetail.Text.Trim() != "")
        {
            strOtherDetails = txtOtherDetail.Text.Trim();
        }
        if (txtQuantity.Text.Trim() != "")
        {
            strQuantity = txtQuantity.Text.Trim();
        }
        if (txtReceiptDate.Text.Trim() != "")
        {
            strReceiptDate = Convert.ToDateTime(txtReceiptDate.Text.Trim());
        }
        strConstructionSiteID = Convert.ToInt32(ddlConstructionSiteID.SelectedValue);
        strContractorID = Convert.ToInt32(ddlContractorID.SelectedValue);
        strMaterialID = Convert.ToInt32(ddlMaterialID.SelectedValue);
        strMaterialTypeID = Convert.ToInt32(ddlMaterialTypeID.SelectedValue);
        strSupplierID = Convert.ToInt32(ddlSupplierID.SelectedValue);
        strUnitID = Convert.ToInt32(ddlUnitID.SelectedValue);

        if (Request.QueryString["MaterialReceiptID"] == null)
        {
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_CMM_MaterialReceipt_SelectByUserID_AND_ReceiptNo";
            objCmd.Parameters.AddWithValue("@ReceiptNo", strReceiptNo);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objSdr = objCmd.ExecuteReader();
            if (objSdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Receipt no<br> enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtReceiptDate.Text = "";
                txtReceiptNo.Text = "";
                txtDriverName.Text = "";
                txtOtherDetail.Text = "";
                txtQuantity.Text = "";
                txtVehicle.Text = "";
                ddlMaterialTypeID.SelectedIndex = 0;
                ddlUnitID.SelectedIndex = 0;
                ddlConstructionSiteID.SelectedIndex = 0;
                ddlContractorID.SelectedIndex = 0;
                ddlMaterialID.SelectedIndex = 0;
                ddlSupplierID.SelectedIndex = 0;
                txtReceiptNo.Focus();
                objCon.Close();
            }
            else
            {
                SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objco.Open();
                SqlCommand objcm = new SqlCommand();
                objcm.Connection = objco;
                objcm.CommandType = CommandType.StoredProcedure;
                objcm.CommandText = "[PR_CMM_MaterialReceipt_InsertByUserID]";
                if (Session["UserID"] != null)
                {
                    objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objcm.Parameters.AddWithValue("@ReceiptNo", strReceiptNo);
                objcm.Parameters.AddWithValue("@UnitID", strUnitID);
                objcm.Parameters.AddWithValue("@MaterialTypeID", strMaterialTypeID);
                objcm.Parameters.AddWithValue("@MaterialID", strMaterialID);
                objcm.Parameters.AddWithValue("@SupplierID", strSupplierID);
                objcm.Parameters.AddWithValue("@ContractorID", strContractorID);
                objcm.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);

                objcm.Parameters.AddWithValue("@ReceiptDate", strReceiptDate);
                objcm.Parameters.AddWithValue("@DriverName", strDriverName);
                objcm.Parameters.AddWithValue("@Quantity", strQuantity);
                objcm.Parameters.AddWithValue("@VehicleNo", strVehicleNo);
                objcm.Parameters.AddWithValue("@OtherDetail", strOtherDetails);
                objcm.ExecuteNonQuery();
                lblMessage.Text = "Data has been inserted successfully";
                lblMessage.CssClass = "btn btn-success";
                txtReceiptDate.Text = "";
                txtReceiptNo.Text = "";
                txtDriverName.Text = "";
                txtOtherDetail.Text = "";
                txtQuantity.Text = "";
                txtVehicle.Text = "";
                ddlMaterialTypeID.SelectedIndex = 0;
                ddlUnitID.SelectedIndex = 0;
                ddlConstructionSiteID.SelectedIndex = 0;
                ddlContractorID.SelectedIndex = 0;
                ddlMaterialID.SelectedIndex = 0;
                ddlSupplierID.SelectedIndex = 0;
                txtReceiptNo.Focus();
                objCon.Close();
            }

        }

        if (Request.QueryString["MaterialReceiptID"] != null)
        {
            SqlString var = SqlString.Null;
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objcon.Open();
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objcon;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[PR_CMM_MaterialReceipt_SelectByPK]";
            objcmd.Parameters.AddWithValue("@MaterialReceiptID", Request.QueryString["MaterialReceiptID"].ToString());
            SqlDataReader objSdr = objcmd.ExecuteReader();
            while (objSdr.Read())
            {
                if (objSdr["ReceiptNo"].Equals(DBNull.Value) == false)
                {
                    var = objSdr["ReceiptNo"].ToString().Trim();
                }
            }
            objcon.Close();

            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_CMM_MaterialReceipt_SelectByUserID_AND_ExceptReceiptNo";
            objCmd.Parameters.AddWithValue("@ReceiptNo", strReceiptNo);
            objCmd.Parameters.AddWithValue("@ExceptReceiptNo", var);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            }
            SqlDataReader objsdr = objCmd.ExecuteReader();
            if (objsdr.HasRows)
            {
                lblMessage.Text = "You can't Enter same Receipt no<br> enter another one";
                lblMessage.CssClass = "btn btn-danger";
                txtReceiptDate.Text = "";
                txtReceiptNo.Text = "";
                txtDriverName.Text = "";
                txtOtherDetail.Text = "";
                txtQuantity.Text = "";
                txtVehicle.Text = "";
                ddlMaterialTypeID.SelectedIndex = 0;
                ddlUnitID.SelectedIndex = 0;
                ddlConstructionSiteID.SelectedIndex = 0;
                ddlContractorID.SelectedIndex = 0;
                ddlMaterialID.SelectedIndex = 0;
                ddlSupplierID.SelectedIndex = 0;
                txtReceiptNo.Focus();
                objCon.Close();
            }
            else
            {
                SqlConnection objco = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
                objco.Open();
                SqlCommand objcm = new SqlCommand();
                objcm.Connection = objco;
                objcm.CommandType = CommandType.StoredProcedure;
                objcm.CommandText = "[PR_CMM_MaterialReceipt_UpdateByPK]";
                if (Session["UserID"] != null)
                {
                    objcm.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
                }
                objcm.Parameters.AddWithValue("@ReceiptNo", strReceiptNo);
                objcm.Parameters.AddWithValue("@UnitID", strUnitID);
                objcm.Parameters.AddWithValue("@MaterialTypeID", strMaterialTypeID);
                objcm.Parameters.AddWithValue("@MaterialID", strMaterialID);
                objcm.Parameters.AddWithValue("@SupplierID", strSupplierID);
                objcm.Parameters.AddWithValue("@ContractorID", strContractorID);
                objcm.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
                objcm.Parameters.AddWithValue("@MaterialReceiptID", Request.QueryString["MaterialReceiptID"].ToString());
                objcm.Parameters.AddWithValue("@ReceiptDate", strReceiptDate);
                objcm.Parameters.AddWithValue("@DriverName", strDriverName);
                objcm.Parameters.AddWithValue("@Quantity", strQuantity);
                objcm.Parameters.AddWithValue("@VehicleNo", strVehicleNo);
                objcm.Parameters.AddWithValue("@OtherDetail", strOtherDetails);
                objcm.ExecuteNonQuery();
                Response.Redirect("~/CMMWeb/AdminPanel/MaterialReceipt/MaterialReceiptList.aspx");
                objCon.Close();
            }
        }
    }

    protected void ddlMaterialTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlMaterial();
    }
}