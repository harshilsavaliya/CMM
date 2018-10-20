using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.ComponentModel;

public partial class CMMWeb_AdminPanel_Sample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string cs = ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(cs))
        //{
        //    SqlCommand cmd = new SqlCommand("[PR_CMM_Image_SelectByImageID]", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    SqlParameter paramId = new SqlParameter()
        //    {
        //        ParameterName = "@ImageId",
        //        Value = Request.QueryString["ImageId"]
        //    };
        //    cmd.Parameters.Add(paramId);

        //    //SqlParameter UserID = new SqlParameter()
        //    //{
        //    //    ParameterName = "@UserID",
        //    //    Value = Session["UserID"].ToString()
        //    //};
        //    //cmd.Parameters.Add(UserID);
        //    con.Open();
        //    byte[] bytes = (byte[])cmd.ExecuteScalar();
        //    string strBase64 = Convert.ToBase64String(bytes);
        //    Image1.ImageUrl = "data:Image/png;base64," + strBase64;
        //}

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
    
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //StringReader sr = new StringReader(Request.Form[hfGridHtml.UniqueID]);
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //pdfDoc.Close();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=HTML.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.Write(pdfDoc);
        //Response.End();

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        pnl.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}