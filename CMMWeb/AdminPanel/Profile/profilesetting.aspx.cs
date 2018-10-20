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
using System.IO;

public partial class CMMWeb_AdminPanel_Profile_profilesetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/CMMWeb/AdminPanel/Login/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            fillddlState();
            fillddlState1();
            fillControls2();
            fillControls();
        }
        if (this.IsPostBack)
        {
            TabName.Value = Request.Form[TabName.UniqueID];
        }
    }

    private void fillddlState1()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "CMM_State1_Select";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlStateID1.DataSource = objSdr;
            ddlStateID1.DataValueField = "StateID";
            ddlStateID1.DataTextField = "StateName";
            ddlStateID1.DataBind();
        }
        ddlStateID1.Items.Insert(0, new ListItem("Select State", "-1"));
        objCon.Close();
    }

    private void fillddlState()
    {
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "CMM_State1_Select";
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            ddlStateID.DataSource = objSdr;
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
        }
        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        objCon.Close();
    }
    private void fillControls()
    {

        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_User_SelectByUserID";
        if (Session["UserID"].ToString() != null)
        {
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["DisplayName"].Equals(DBNull.Value) == false)
            {
                txtDisplayName.Text = objSdr["DisplayName"].ToString().Trim();
            }
            if (objSdr["Email"].Equals(DBNull.Value) == false)
            {
                txtEmail.Text = objSdr["Email"].ToString().Trim();
            }
            if (objSdr["OrganizationName"].Equals(DBNull.Value) == false)
            {
                txtOrganization.Text = objSdr["OrganizationName"].ToString().Trim();
            }
            if (objSdr["CityName"].Equals(DBNull.Value) == false)
            {
                txtCityName.Text = objSdr["CityName"].ToString().Trim();
            }
            if (objSdr["Address"].Equals(DBNull.Value) == false)
            {
                txtAddress.Text = objSdr["Address"].ToString().Trim();
            }
            if (objSdr["StateID"].Equals(DBNull.Value) == false)
            {
                ddlStateID.SelectedValue = objSdr["StateID"].ToString();
            }
        }
        objCon.Close();
    }
    private void fillControls2()
    {

        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_CMM_User_SelectByUserID";
        if (Session["UserID"].ToString() != null)
        {
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"].ToString());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        while (objSdr.Read())
        {
            if (objSdr["DisplayName"].Equals(DBNull.Value) == false)
            {
                txtName1.Text = objSdr["DisplayName"].ToString().Trim();
            }
            if (objSdr["Email"].Equals(DBNull.Value) == false)
            {
                txtEmail1.Text = objSdr["Email"].ToString().Trim();
            }
            if (objSdr["OrganizationName"].Equals(DBNull.Value) == false)
            {
                txtOrganization1.Text = objSdr["OrganizationName"].ToString().Trim();
            }
            if (objSdr["CityName"].Equals(DBNull.Value) == false)
            {
                txtCity1.Text = objSdr["CityName"].ToString().Trim();
            }
            if (objSdr["Address"].Equals(DBNull.Value) == false)
            {
                txtAddress1.Text = objSdr["Address"].ToString().Trim();
            }
            if (objSdr["StateID"].Equals(DBNull.Value) == false)
            {
                ddlStateID1.SelectedValue = objSdr["StateID"].ToString();
            }
        }
        objCon.Close();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlString var = SqlString.Null;
        SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objcon.Open();
        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objcon;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[PR_CMM_User_SelectByUserID]";
        if (Session["UserID"].ToString() != null)
        {
            objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        }
        SqlDataReader objsdr = objcmd.ExecuteReader();
        while (objsdr.Read())
        {
            if (objsdr["Email"].Equals(DBNull.Value) == false)
            {
                var = objsdr["Email"].ToString().Trim();
            }
        }
        objcon.Close();
        SqlString strEmail = SqlString.Null;
        SqlString strName = SqlString.Null;
        SqlString strOrganization = SqlString.Null;
        SqlString strCity = SqlString.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;

        if (txtEmail1.Text.ToString() != "")
        {
            strEmail = txtEmail1.Text.ToString().Trim();
        }
        if (txtName1.Text.ToString() != "")
        {
            strName = txtName1.Text.ToString().Trim();
        }
        if (txtOrganization1.Text.ToString() != "")
        {
            strOrganization = txtOrganization1.Text.ToString().Trim();
        }
        if (txtCity1.Text.ToString() != "")
        {
            strCity = txtCity1.Text.ToString().Trim();
        }
        if (txtAddress1.Text.Trim() != "")
        {
            strAddress = txtAddress1.Text.Trim();
        }
        strStateID = Convert.ToInt32(ddlStateID1.SelectedValue);
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_User_SelectByExceptEmail]";
        objCmd.Parameters.AddWithValue("@Email", strEmail);
        objCmd.Parameters.AddWithValue("@ExceptEmail", var);
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            lblMessage.Text = "You can't Enter same Email<br> enter another one";
            lblMessage.CssClass = "btn btn-danger";
            txtEmail1.Text = "";
            txtName1.Text = "";
            txtOrganization1.Text = "";
            txtCity1.Text = "";
            ddlStateID1.SelectedIndex = 0;
            txtName1.Focus();
            objCon.Close();
            txtAddress1.Text="";
        }
        else
        {            
            SqlConnection obCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            obCon.Open();
            SqlCommand obCmd = new SqlCommand();
            obCmd.Connection = obCon;
            obCmd.CommandType = CommandType.StoredProcedure;
            obCmd.CommandText = "PR_CMM_User_UpdateByPK";
            obCmd.Parameters.AddWithValue("DisplayName", strName);
            obCmd.Parameters.AddWithValue("Email", strEmail);
            obCmd.Parameters.AddWithValue("CityName", strCity);
            obCmd.Parameters.AddWithValue("Address", strAddress);
            obCmd.Parameters.AddWithValue("OrganizationName", strOrganization);
            obCmd.Parameters.AddWithValue("StateID", strStateID);
            if (Session["UserID"] != null)
            {
                obCmd.Parameters.AddWithValue("UserID", Session["UserID"].ToString().Trim());
            }
            obCmd.ExecuteNonQuery();
            lblMessage.Text = "Data has been updated Successfully";
            lblMessage.CssClass = "btn btn-success";
            //Response.Redirect("~/CMMWeb/AdminPanel/Profile/profilesetting.aspx");
            obCon.Close();
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        SqlString strPassword = SqlString.Null;
        SqlString strNewPassword = SqlString.Null;

        if (txtCurrentPassword.Text.ToString() != "")
        {
            strPassword = txtCurrentPassword.Text.Trim().ToString();
        }
        if (txtNewPassword.Text.ToString() != "")
        {
            strNewPassword = txtNewPassword.Text.Trim().ToString();
        }
        SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
        objCon.Open();
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = objCon;
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_CMM_User_SelectByPasswordAndUserID]";
        objCmd.Parameters.AddWithValue("Password", strPassword);
        if (Session["UserID"] != null)
        {
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"].ToString().Trim());
        }
        SqlDataReader objSdr = objCmd.ExecuteReader();
        if (objSdr.HasRows)
        {
            SqlConnection obCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ToString());
            obCon.Open();
            SqlCommand obCmd = new SqlCommand();
            obCmd.Connection = obCon;
            obCmd.CommandType = CommandType.StoredProcedure;
            obCmd.CommandText = "[PR_CMM_User_UpdatePasswordByPK]";
            obCmd.Parameters.AddWithValue("Password", strNewPassword);
            if (Session["UserID"] != null)
            {
                obCmd.Parameters.AddWithValue("UserID", Session["UserID"].ToString().Trim());
            }
            obCmd.ExecuteNonQuery();
            lblMessage1.Text = "Data has been updated Successfully";
            lblMessage1.CssClass = "btn btn-success";
            //Response.Redirect("~/CMMWeb/AdminPanel/Profile/profilesetting.aspx");
            obCon.Close();
        }
        else
        {
            lblMessage1.Text = "Your Current password in not same";
            lblMessage1.CssClass = "btn btn-danger";
        }
        objCon.Close();
    }
    protected void btnLogo_Click(object sender, EventArgs e)
    {
        HttpPostedFile postedFile = FileUpload1.PostedFile;
        string filename = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(filename);
        int fileSize = postedFile.ContentLength;

        if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
            || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
        {
            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);


            string cs = ConfigurationManager.ConnectionStrings["CMMConnectionStrings"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("[PR_CMM_Image_InsertByUserID]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter()
                {
                    ParameterName = @"ImageName",
                    Value = filename
                };
                cmd.Parameters.Add(paramName);

                SqlParameter paramSize = new SqlParameter()
                {
                    ParameterName = "@ImageSize",
                    Value = fileSize
                };
                cmd.Parameters.Add(paramSize);

                SqlParameter paramImageData = new SqlParameter()
                {
                    ParameterName = "@ImageData",
                    Value = bytes
                };
                cmd.Parameters.Add(paramImageData);

                SqlParameter paramNewId = new SqlParameter()
                {
                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramNewId);

                SqlParameter UserID = new SqlParameter()
                {
                    ParameterName = "@UserID",
                    Value = Session["UserID"].ToString()
                };
                cmd.Parameters.Add(UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage2.Visible = true;
                lblMessage2.CssClass = "btn btn-success";
                lblMessage2.Text = "Upload Successful";
                //hyperlink.Visible = true;
                //hyperlink.NavigateUrl = "~/CMMWeb/AdminPanel/Sample.aspx?ImageID=" +
                //    cmd.Parameters["@NewId"].Value.ToString();
            }
        }
        else
        {
            lblMessage2.Visible = true;
            lblMessage2.CssClass = "btn btn-danger";
            lblMessage2.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
            //hyperlink.Visible = false;
        }
    }
}