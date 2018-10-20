using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CMMWeb_AdminPanel_FinYear_FinYearView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillControls();
        }
    }
    private void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_MST_FinYear_SelectByPK]";
        objcmd.Parameters.AddWithValue("@FinYearID", Request.QueryString["FinYearID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["FinName"].Equals(DBNull.Value) == false)
            {
                lblFinYear.Text = objSdr["FinName"].ToString().Trim();
            }

            if (objSdr["IsActive"].Equals(DBNull.Value) == false)
            {
                lblIsActive.Text = (objSdr["IsActive"].ToString().Trim());
            }
            if (!objSdr["FromDate"].Equals(DBNull.Value))
            {
                lblFromDate.Text= objSdr["FromDate"].ToString().Trim();
            }
            if (!objSdr["ToDate"].Equals(DBNull.Value))
            {
                lblToDate.Text = objSdr["ToDate"].ToString().Trim();
            }
            if (!objSdr["Sequence"].Equals(DBNull.Value))
            {
                lblSequence.Text = objSdr["Sequence"].ToString().Trim();
            }
        }
        objcon.Close();
    }
}