using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_Contractor_ContractorView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }

        if (!Page.IsPostBack)
        {            
            if (Request.QueryString["ContractorID"] != null)
            {
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
                        lblContractorName.Text = objSdr["ContractorName"].ToString().Trim();
                    }
                    if (objSdr["IsActive"].Equals(DBNull.Value) == false)
                    {
                        lblIsActive.Text = (objSdr["IsActive"].ToString().Trim());
                    }
                }
                objCon.Close();
            }
        }
    }
}