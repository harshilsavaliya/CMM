using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Material_MaterialView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (Request.QueryString["MaterialID"] != null)
        {
            fillControls();
        }
    }
    protected void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_Material_SelectByPK_For_View]";
        objcmd.Parameters.AddWithValue("@MaterialID", Request.QueryString["MaterialID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["MaterialName"].Equals(DBNull.Value) == false)
            {
                lblMaterialName.Text = objSdr["MaterialName"].ToString().Trim();
            }
            if (objSdr["IsSystem"].Equals(DBNull.Value) == false)
            {
                lblIsSystem.Text = (objSdr["IsSystem"].ToString().Trim());
            }

            if (objSdr["UnitName"].Equals(DBNull.Value) == false)
            {
                lblUnit.Text = objSdr["UnitName"].ToString().Trim();
            }

            if (objSdr["MaterialTypeName"].Equals(DBNull.Value) == false)
            {
                lblMaterialType.Text = objSdr["MaterialTypeName"].ToString().Trim();
            }

        }
        objcon.Close();
    }
}