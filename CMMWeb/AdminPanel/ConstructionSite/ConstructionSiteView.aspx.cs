using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_ConstuctionSite_ConstructionView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Request.QueryString["ConstructionSiteID"] != null)
            {
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
                        lblConstructionSiteName.Text = objSdr["ConstructionSiteName"].ToString().Trim();
                    }

                    if (objSdr["SiteAddress"].Equals(DBNull.Value) == false)
                    {
                        lblConstructionSiteAddress.Text = objSdr["SiteAddress"].ToString().Trim();
                    }

                    if (objSdr["State"].Equals(DBNull.Value) == false)
                    {
                        lblState.Text = objSdr["State"].ToString().Trim();
                    }

                    if (objSdr["City"].Equals(DBNull.Value) == false)
                    {
                        lblCity.Text = objSdr["City"].ToString().Trim();
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