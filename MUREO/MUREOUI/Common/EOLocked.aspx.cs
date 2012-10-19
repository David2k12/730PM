using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOPROP;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Mail;
using System.Text;

namespace MUREOUI.Common
{
    public partial class EOLocked : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;
        clsSecurity objclsSecurity = new clsSecurity();
        clsSendMail objclssSendMail = new clsSendMail();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds =  null;
                int intPosition;
                string appName;
                if(objEOBA.GET_EO_Lock_Status(Request.QueryString["EOID"].ToString().Trim(),ref ds))
                {
                            if (!(ds == null))
                {
                    if (!(ds.Tables.Count == 0))
                    {
                        if (!(ds.Tables[0].Rows.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows[0]["Locked_By"] == DBNull.Value))
                            {
                                lblLockOwnerContent.Text = ds.Tables[0].Rows[0]["Locked_By"].ToString().Trim();
                            }
                            else
                            {
                                lblLockOwnerContent.Text = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["EO_Title"] == DBNull.Value))
                            {
                                lblEOTitle.Text = ds.Tables[0].Rows[0]["EO_Title"].ToString().Trim();
                            }
                            else
                            {
                                lblEOTitle.Text = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Locked_By"] == DBNull.Value))
                            {
                                lblLockOwner.Text = ds.Tables[0].Rows[0]["Locked_By"].ToString().Trim();
                            }
                            else
                            {
                                lblLockOwner.Text = String.Empty;
                            }
                            try
                            {
                                intPosition = lblLockOwnerContent.Text.ToString().Trim().IndexOf(" ");
                                appName = lblLockOwnerContent.Text.ToString().Trim().Substring((intPosition + 1));
                                appName = appName.Replace("-", ".");
                                string strPhNumber = objSecurity.getUserTelephoneNumber(appName);
                                if (!(strPhNumber == ""))
                                {
                                    lblPhnum.Text = strPhNumber;
                                    lblPhnumContent.Text = strPhNumber;
                                }
                                else
                                {
                                    lblPhnum.Text = String.Empty;
                                    lblPhnumContent.Text = String.Empty;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
                }
              
        
            }
            catch (Exception ex)
            {
            }
        }
    }
}