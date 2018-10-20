using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Supplier_SupplierView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SupplierID"] != null)
            {
                fillControls();
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
        objcmd.CommandText = "[PR_CMM_Supplier_SelectByPK]";
        objcmd.Parameters.AddWithValue("@SupplierID", Request.QueryString["SupplierID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["SupplierName"].Equals(DBNull.Value) == false)
            {
                lblSupplierName.Text = objSdr["SupplierName"].ToString().Trim();
            }

            if (objSdr["IsActive"].Equals(DBNull.Value) == false)
            {
                lblIsSystem.Text = (objSdr["IsActive"].ToString().Trim());
            }
            if (objSdr["Email"].Equals(DBNull.Value) == false)
            {
                lblEmail.Text = objSdr["Email"].ToString().Trim();
            }
            if (objSdr["Mobile"].Equals(DBNull.Value) == false)
            {
                lblMobile.Text = objSdr["Mobile"].ToString().Trim();
            }
            if (objSdr["State"].Equals(DBNull.Value) == false)
            {
                lblState.Text = objSdr["State"].ToString().Trim();
            }
            if (objSdr["City"].Equals(DBNull.Value) == false)
            {
                lblCity.Text = objSdr["City"].ToString().Trim();
            }
            if (objSdr["ContactPerson"].Equals(DBNull.Value) == false)
            {
                lblContactPerson.Text = objSdr["ContactPerson"].ToString().Trim();
            }
            if (objSdr["Address"].Equals(DBNull.Value) == false)
            {
                lblAddress.Text = objSdr["Address"].ToString().Trim();
            }
        }
        objcon.Close();
    }
}