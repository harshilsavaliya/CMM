using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Drawing;
using System.ComponentModel;

public partial class CMMWeb_AdminPanel_MaterialReceipt_MaterialReceiptView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (Request.QueryString["MaterialReceiptID"] != null)
        {
            fillControls();
            string cs = ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ConnectionString;
            SqlConnection objCon = new SqlConnection(cs);
            objCon.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objCon;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_CMM_Image_SelectByPKANDUserID]";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
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
    protected void fillControls()
    {
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_MaterialReceipt_SelectByPK_For_View]";
        objcmd.Parameters.AddWithValue("@MaterialReceiptID", Request.QueryString["MaterialReceiptID"].ToString());
        SqlDataReader objSdr = objcmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["Address"].Equals(DBNull.Value) == false)
            {
                lblAddress.Text = objSdr["Address"].ToString().Trim();
            }
            if (objSdr["OrganizationName"].Equals(DBNull.Value) == false)
            {
                lblOrganization.Text = objSdr["OrganizationName"].ToString().Trim();
            }
                //lblAddress.Text = Session["Address"].ToString().Trim();
                //lblOrganization.Text = Session["OrganizationName"].ToString().Trim();
            if (objSdr["MaterialName"].Equals(DBNull.Value) == false)
            {
                lblMaterialName.Text = objSdr["MaterialName"].ToString().Trim();
            }
            if (objSdr["SupplierName"].Equals(DBNull.Value) == false)
            {
                lblSupplierName.Text = objSdr["SupplierName"].ToString().Trim();
            }
            if (objSdr["ReceiptNo"].Equals(DBNull.Value) == false)
            {
                lblReceiptNo.Text = (objSdr["ReceiptNo"].ToString().Trim());
            }

            if (objSdr["ReceiptDate"].Equals(DBNull.Value) == false)
            {
                lblReceiptDate.Text = (objSdr["ReceiptDate"].ToString().Trim());
            }

            if (objSdr["UnitName"].Equals(DBNull.Value) == false)
            {
                lblUnitName.Text = objSdr["UnitName"].ToString().Trim();
            }

            if (objSdr["MaterialTypeName"].Equals(DBNull.Value) == false)
            {
                lblMaterialTypeName.Text = objSdr["MaterialTypeName"].ToString().Trim();
            }
            if (objSdr["ConstructionSiteName"].Equals(DBNull.Value) == false)
            {
                lblConstructionSite.Text = objSdr["ConstructionSiteName"].ToString().Trim();
            }

            if (objSdr["ContractorName"].Equals(DBNull.Value) == false)
            {
                lblContractorName.Text = objSdr["ContractorName"].ToString().Trim();
            }
            if (objSdr["Quantity"].Equals(DBNull.Value) == false)
            {
                lblQuantity.Text = objSdr["Quantity"].ToString().Trim();
            }
            if (objSdr["DriverName"].Equals(DBNull.Value) == false)
            {
                lblDriverName.Text = objSdr["DriverName"].ToString().Trim();
            }
            if (objSdr["OtherDetail"].Equals(DBNull.Value) == false)
            {
                lblOtherDetail.Text = objSdr["OtherDetail"].ToString().Trim();
            }
            if (objSdr["VehicleNo"].Equals(DBNull.Value) == false)
            {
                lblVehicleNo.Text = objSdr["VehicleNo"].ToString().Trim();
            }
        }
        objcon.Close();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //StringReader sr = new StringReader(Request.Form[hfGridHtml.UniqueID]);
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //pdfDoc.Close();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=HTML.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.Write(pdfDoc);
        //Response.End();

        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //pnl.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

        Session["ctrl"] = pnl;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=600px,width=600px,scrollbars=1');</script>");
    }
    protected string GetUrl(string imagepath)
    {
        string[] splits = Request.Url.AbsoluteUri.Split('/');
        if (splits.Length >= 2)
        {
            imagepath = imagepath.Replace("~/", "");
            string url = splits[0] + "//";
            for (int i = 2; i < splits.Length - 1; i++)
            {
                url += splits[i];
                url += "/";
            }
            return url + imagepath;
        }
        return imagepath;
    }
}