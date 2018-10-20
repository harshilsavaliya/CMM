using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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

public partial class CMMWeb_AdminPanel_MaterialReceiptReceipt_MaterialReceiptReceiptList : System.Web.UI.Page
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
            fillddlMaterial();
            fillddlContractor();
            fillddlSupplier();
            fillMaterialReceiptList();
        }
    }
    protected void fillMaterialReceiptList()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_MaterialReceipt_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvMaterialReceiptList.DataSource = objSdr;
            gvMaterialReceiptList.DataBind();
        }
        objCon.Close();
    }

    protected void gvMaterialReceiptList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMaterialReceipt")
        {
            SqlString MTID = e.CommandArgument.ToString().Trim();
            SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_MaterialReceipt_DeleteByPK]";
            objCmd.Parameters.AddWithValue("@MaterialReceiptID", MTID);
            objCmd.ExecuteNonQuery();
            objCon.Close();
            fillMaterialReceiptList();
        }
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
        ddlContractorID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Contractor", "-1"));
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
        ddlSupplierID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Supplier", "-1"));
        objCon.Close();
    }

    private void fillddlMaterial()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_Material_SelectByUserID";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlMaterialID.DataSource = objSdr;
            ddlMaterialID.DataValueField = "MaterialID";
            ddlMaterialID.DataTextField = "MaterialName";
            ddlMaterialID.DataBind();
        }
        ddlMaterialID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Material", "-1"));
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
        ddlConstructionSiteID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Constructionsite", "-1"));
        objCon.Close();
    }

    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        SqlInt32 strConstructionSiteID = SqlInt32.Null;
        SqlInt32 strSupplierID = SqlInt32.Null;
        SqlInt32 strContractorID = SqlInt32.Null;
        SqlInt32 strMaterialID = SqlInt32.Null;
        SqlDateTime strFromDate = SqlDateTime.Null;
        SqlDateTime strToDate = SqlDateTime.Null;
        DateTime today = DateTime.Today;

        strConstructionSiteID = Convert.ToInt32(ddlConstructionSiteID.SelectedValue);
        strContractorID = Convert.ToInt32(ddlContractorID.SelectedValue);
        strMaterialID = Convert.ToInt32(ddlMaterialID.SelectedValue);
        strSupplierID = Convert.ToInt32(ddlSupplierID.SelectedValue);

        if (txtFromDate.Text.Trim() != "")
        {
            strFromDate = DateTime.Parse(txtFromDate.Text.Trim());
        }
        if (txtToDate.Text.Trim() != "")
        {
            strToDate = DateTime.Parse(txtToDate.Text.Trim());
        }
        if (txtFromDate.Text.Trim() == "")
        {
            strFromDate = Convert.ToDateTime("30-Apr-12 12:00:00 AM");
        }
        if (txtToDate.Text.Trim() == "")
        {
            strToDate = Convert.ToDateTime("30-Apr-12 12:00:00 AM");
        }
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() == "")
        {
            strFromDate = DateTime.Parse(txtFromDate.Text.Trim());
            strToDate = today;
        }
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_MaterialReceipt_SelectBy";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        objCmd.Parameters.AddWithValue("@ConstructionSiteID", strConstructionSiteID);
        objCmd.Parameters.AddWithValue("@FromDate", strFromDate);
        objCmd.Parameters.AddWithValue("@ToDate", strToDate);
        objCmd.Parameters.AddWithValue("@MaterialID", strMaterialID);
        objCmd.Parameters.AddWithValue("@SupplierID", strSupplierID);
        objCmd.Parameters.AddWithValue("@ContractorID", strContractorID);
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            gvMaterialReceiptList.DataSource = objSdr;
            gvMaterialReceiptList.DataBind();
        }
        objCon.Close();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        Session["ctrl"] = gvMaterialReceiptList;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=600px,width=600px,scrollbars=1');</script>");
    }

}
