using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class ChangeDistributionList : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtAS.Value))
            {
                txtAS.Text = hdntxtAS.Value;
            }
            if (!string.IsNullOrEmpty(hdntxtCCEO.Value))
            {
                txtCCEO.Text = hdntxtCCEO.Value;
            }
            if (!string.IsNullOrEmpty(hdntxtMDC.Value))
            {
                txtMDC.Text = hdntxtMDC.Value;
            }
            if (!string.IsNullOrEmpty(hdntxtPC.Value))
            {
                txtPC.Text = hdntxtPC.Value;
            }
            //Put user code to initialize the page here
            ChangeDistributionBO obj = new ChangeDistributionBO();

            imgAddBookCCEO.Attributes.Add("onclick", "javascript: AddBooksingUserCCEO();");
            imgAddBookMDC.Attributes.Add("onclick", "javascript: AddBooksingUserMDC();");
            imgAddressBookPC.Attributes.Add("onclick", "javascript: AddBooksingUserPC();");
            imageAddBookAS.Attributes.Add("onclick", "javascript: AddBooksingUserAS();");

            if (!Page.IsPostBack)
            {
                DataSet ds = null;
                if (obj.GET_EO_OnRoute_FYI_Distribution_List(ref  ds))
                {
                    if (!(ds == null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows.Count == 0))
                            {
                                txtCCEO.Text = ds.Tables[0].Rows[0]["FYI_USer_Name"].ToString();
                                txtMDC.Text = ds.Tables[0].Rows[1]["FYI_USer_Name"].ToString();
                                txtPC.Text = ds.Tables[0].Rows[2]["FYI_USer_Name"].ToString();
                                txtAS.Text = ds.Tables[0].Rows[3]["FYI_USer_Name"].ToString();
                            }
                        }
                    }
                }
            }
        }

    
       

        protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                StringBuilder paramList = default(StringBuilder);
                SqlParameter[] paramOut = null;
                string strUserName = objSecurity.UserName;
                ChangeDistributionBO obj = new ChangeDistributionBO();
                int intReturn = 0;
                paramList = new StringBuilder();
                paramList.Append("1,");
                paramList.Append(txtCCEO.Text);
                paramList.Append("~");
                paramList.Append("2,");
                paramList.Append(txtMDC.Text);
                paramList.Append("~");
                paramList.Append("3,");
                paramList.Append(txtPC.Text);
                paramList.Append("~");
                paramList.Append("4,");
                paramList.Append(txtAS.Text);
                //intReturn = obj.SET_EO_OnRoute_FYI_Distribution_List(paramList.ToString(), strUserName);
                if (obj.SET_EO_OnRoute_FYI_Distribution_List(paramList.ToString(), strUserName, ref paramOut))
                {
                    intReturn = Convert.ToInt32(paramOut[0].Value);
                }

                if (intReturn == 0)
                {
                    string script1 = null;
                    script1 = "<script>alert('Updated successfully.');window.navigate('Home.aspx');</script> ";
                    Page.RegisterStartupScript("clientscript", script1);
                }
                else
                {
                    string script1 = null;
                    script1 = "<script>alert('Updated failed.');</script>";
                    Page.RegisterStartupScript("clientscript", script1);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/home.aspx");
        }

    }
}