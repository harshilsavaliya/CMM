using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.ComponentModel;
using System.Drawing;

public partial class CMMWeb_AdminPanel_Worker_WorkerView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (Request.QueryString["WorkerID"] != null)
        {
            fillControls();
            showImage();
        }
    }
    protected void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_Worker_SelectByPK_For_View]";
        objcmd.Parameters.AddWithValue("@WorkerID", Request.QueryString["WorkerID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (!objSdr["WorkerName"].Equals(DBNull.Value))
            {
                lblWorker.Text = objSdr["WorkerName"].ToString().Trim();
            }
            if (!objSdr["Address"].Equals(DBNull.Value))
            {
                lblAddress.Text = objSdr["Address"].ToString().Trim();
            }
            if (!objSdr["AMobileNo"].Equals(DBNull.Value))
            {
                lblAMobile.Text = objSdr["AMobileNo"].ToString().Trim();
            }
            if (!objSdr["MobileNo"].Equals(DBNull.Value))
            {
                lblMobile.Text = objSdr["MobileNo"].ToString().Trim();
            }
            if (!objSdr["CityName"].Equals(DBNull.Value))
            {
                lblCity.Text = objSdr["CityName"].ToString().Trim();
            }
            if (!objSdr["ProofNo"].Equals(DBNull.Value))
            {
                lblProofNo.Text = objSdr["ProofNo"].ToString().Trim();
            }
            if (!objSdr["ConstructionSiteName"].Equals(DBNull.Value))
            {
                lblConstructionSite.Text = objSdr["ConstructionSiteName"].ToString().Trim();
            }
            if (!objSdr["ProofName"].Equals(DBNull.Value))
            {
                lblProof.Text = objSdr["ProofName"].ToString().Trim();
            }
            if (!objSdr["WorkerTypeName"].Equals(DBNull.Value))
            {
                lblWorkerType.Text = objSdr["WorkerTypeName"].ToString().Trim();
            }
            if (objSdr["IsActive"].Equals(DBNull.Value) == false)
            {
                lblActive.Text= (objSdr["IsActive"].ToString().Trim());
            }
            if (!objSdr["PerDayRupees"].Equals(DBNull.Value))
            {
                 lblPerDayRs.Text= objSdr["PerDayRupees"].ToString().Trim();
            }
            if (!objSdr["WorkerCode"].Equals(DBNull.Value))
            {
                 lblWorkerCode.Text= objSdr["WorkerCode"].ToString().Trim();
            }
        }
        objcon.Close();
    }

    private void showImage()
    {
        string cs = ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ConnectionString;
        SqlConnection objCon = new SqlConnection(cs);
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_Worker_SelectByPK_And_UserID]";
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        objCmd.Parameters.AddWithValue("@WorkerID",Request.QueryString["WorkerID"].ToString());
        SqlDataAdapter myAdapter1 = new SqlDataAdapter(objCmd);
        DataTable dt = new DataTable();
        myAdapter1.Fill(dt);

        foreach (DataRow row in dt.Rows)
        {
            // Get the byte array from image file
            byte[] imgBytes = (byte[])row["ImageData"];

            // If you want convert to a bitmap file
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap MyBitmap = (Bitmap)tc.ConvertFrom(imgBytes);

            string imgString = Convert.ToBase64String(imgBytes);
            //Set the source with data:image/bmp
            Image1.ImageUrl = "data:Image/Bmp;base64," + imgString;
        }
    }

}