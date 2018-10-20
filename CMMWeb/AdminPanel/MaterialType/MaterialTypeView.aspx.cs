using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_MaterialType_MaterialTypeView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["MaterialTypeID"] != null)
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
        objcmd.CommandText = "[PR_CMM_MaterialType_SelectByPK]";
        objcmd.Parameters.AddWithValue("@MaterialTypeID", Request.QueryString["MaterialTypeID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["MaterialTypeName"].Equals(DBNull.Value) == false)
            {
                lblMaterialTypeName.Text = objSdr["MaterialTypeName"].ToString().Trim();
            }
            if (objSdr["IsSystem"].Equals(DBNull.Value) == false)
            {
                lblIsSystem.Text = (objSdr["IsSystem"].ToString().Trim());
            }
        }
        objcon.Close();
    }
}