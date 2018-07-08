using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTRS.DataAccess;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
namespace LTRS
{
    public partial class postproperty : System.Web.UI.Page
    {
        DataSet ds = null;
        PropertyDA PropertyDA = new PropertyDA();
        LoginDA LoginDA = new LoginDA();
        DataSet dschecklandlord  = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["UserID"] != null && Session["UserID"].ToString() != "")
            {
                dschecklandlord = LoginDA.FetchFirstname(Convert.ToInt32(Session["UserID"]));
                string usertype = dschecklandlord.Tables[0].Rows[0]["USER_TYPE"].ToString();
                if (usertype == "Landlord" || usertype=="Admin")
                {
                    divproperty.Attributes.Add("style", "display");
                  
                }
                else
                {
                    lblinvalidmessage.InnerHtml = "You cannot post property, because you are a Tenant.";
                }
 
               
            }
            else
            {
                lblinvalidmessage.InnerHtml = "Please login to post property.";
                divproperty.Attributes.Add("style", "display:none");
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] != null && Session["UserID"].ToString() != "")
                {
                    if (fileupload1.HasFile)
                    {

                        string fileExt = System.IO.Path.GetExtension(fileupload1.FileName);

                        if ((fileExt == ".jpg") || (fileExt == ".JPG") || (fileExt == ".jpeg") || (fileExt == ".JPEG") || (fileExt == ".png") || (fileExt == ".PNG"))
                        {
                            ds = PropertyDA.Postpropertyforrent(Convert.ToString(drppropertytype.Value), txtownername.Text, txtcontactnumber.Text, txtaddress.Text, txtcity.Text, txtstate.Text, txtzipcode.Text, txtdate.Value, txtbedbath.Text, "", Convert.ToDouble(txtrent.Text), Convert.ToInt32(Session["UserID"]));

                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                int propertid = Convert.ToInt32(ds.Tables[0].Rows[0]["PROPERTY_ID"]);


                                if (!System.IO.Directory.Exists(Server.MapPath("~/PropertyPhotos/" + propertid.ToString() + "/")))
                                {
                                    System.IO.Directory.CreateDirectory(Server.MapPath("~/PropertyPhotos/" + propertid.ToString() + "/"));
                                }

                                string filename1 = DateTime.Now.ToString("yyyyMMddHHmmssf");
                                string fileExtension1 = System.IO.Path.GetExtension(fileupload1.FileName).ToLower();
                                string filenamenew = filename1 + "" + System.IO.Path.GetFileName(fileupload1.PostedFile.FileName);
                                string path1 = Server.MapPath("~/PropertyPhotos/" + propertid.ToString() + "/" + filenamenew);
                                string realpath = "~/PropertyPhotos/" + propertid.ToString() + "/" + filenamenew;
                                fileupload1.SaveAs(path1);
                                PropertyDA.Updatephoto(propertid, realpath);
                                lblmessage.InnerHtml = "Your Property posted Successfully.";
                            }
                        }
                        else
                        {
                            lblmessage.InnerHtml = "Please upload only .jpg, .jpeg or .png files.";
                        }
                    }
                    else
                    {
                        lblmessage.InnerHtml = "Please upload property image";
                    }
                }

            }
            catch (Exception ex)
            {

            }
            txtaddress.Text = "";
            txtbedbath.Text = "";
            txtcity.Text = "";
            txtcontactnumber.Text = "";
            txtdate.Value = "";
            txtownername.Text = "";
            txtrent.Text = "";
            txtstate.Text = "";
            txtzipcode.Text = "";
            drppropertytype.SelectedIndex = -1;
            fileupload1.Attributes.Clear();
        }
        protected void btnhome_Click(object sender, EventArgs e)
        {
            try
            {
                //Session["UserID"] = null;
                Page.Response.Redirect("~/index.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Response.Redirect("~/myaccount.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Response.Redirect("~/submitratings.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            txtaddress.Text = "";
            txtbedbath.Text = "";
            txtcity.Text = "";
            txtcontactnumber.Text = "";
            txtdate.Value = "";
            txtownername.Text = "";
            txtrent.Text = "";
            txtstate.Text = "";
            txtzipcode.Text = "";
            drppropertytype.SelectedIndex = -1;
            fileupload1.Attributes.Clear();
           
        }
        protected void btnexit_Click(object sender, EventArgs e)
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                    string s = process.ProcessName.ToLower();
                    if (s == "iexplore" || s == "iexplorer" || s == "chrome" || s == "firefox")
                        process.Kill();
                }
            }
        }
    }
}

