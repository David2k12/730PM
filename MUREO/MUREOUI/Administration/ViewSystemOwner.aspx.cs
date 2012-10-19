using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MUREOBAL;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MUREOUI.Administration
{
    public partial class ViewSystemOwner : System.Web.UI.Page
    {
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strPhNo = string.Empty;
                string strApproverName = string.Empty;
                string strPlantName = string.Empty;
                string strPcontactID = string.Empty;
                //txthiddenPlantID.Text = Convert.ToString(Request.QueryString["PlantID"]);
                //txthiddenSysOwnID.Text = Convert.ToString(Request.QueryString["lblSysOwnID"]);

                txthiddenPlantID.Value = Convert.ToString(Request.QueryString["PlantID"]);
                txthiddenSysOwnId.Value = Convert.ToString(Request.QueryString["lblSysOwnId"]);
                
                strPhNo = Convert.ToString(Request.QueryString["PhNo"]);
                string strPhNorAmpercent = strPhNo.Contains("amp") ? Regex.Replace(strPhNo, "amp", "&", RegexOptions.None) : strPhNo;

                string strPhNorValue = strPhNorAmpercent.Contains("hash") ? Regex.Replace(strPhNorAmpercent, "hash", "#", RegexOptions.None) : strPhNorAmpercent;

                strApproverName = Convert.ToString(Request.QueryString["OwnerName"]);
                strPlantName = Request.QueryString["PlantName"];

                //MaterialType = Request.QueryString["MaterialType")
                strPcontactID = Convert.ToString(Request.QueryString["lblSysOwnID"]);
                //txthiddenPurchaseContactId.Text = PcontactID

                lblPlantName.Text = strPlantName;
                //lblMaterialType.Text = MaterialType
                //lblPhoneNumber.Text = strPhNo;
                lblPhoneNumber.Text = strPhNorValue;
                lblApprover.Text = strApproverName;


            }

        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddSystemOwner.aspx?PlantID=" + txthiddenPlantID.Value + "&Mode=Edit" + "&OwnerName=" + lblApprover.Text + "&PhoneNumber=" + Server.UrlEncode(lblPhoneNumber.Text) + "&SysOwnID=" + txthiddenSysOwnId.Value);

        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/MaintainSystemOwner.aspx");

        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            //BusinessObject.MUREO.BusinessObject.SystemOwner objDeleteSystemOwner = new BusinessObject.MUREO.BusinessObject.SystemOwner();
            clsSystemOwnerBO objclsSystemOwnerBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            int returnvalue;
            try
            {
                objclsSystemOwnerBO = new clsSystemOwnerBO();
                if (objclsSystemOwnerBO.DeleteSysOwner(Convert.ToInt32(txthiddenSysOwnId.Value), ref paramOut))
                {
                    returnvalue=Convert.ToInt32(paramOut[0].Value);
                    if (returnvalue == 0)
                    {
                        //string script = null;
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("DeletedSuccess") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "DeletedSuccess", strScript);
                    }
                    else
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("DeletedError") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["DeletedError"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "error_message", strScript);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsSystemOwnerBO = null;
            }

        }
    }
}