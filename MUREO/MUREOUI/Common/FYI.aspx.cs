using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Common
{
    public partial class FYI : System.Web.UI.Page
    {
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;
        clsSecurity objSecurity = new clsSecurity();
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            imgAddressBook.Attributes.Add("onclick", "javascript: AddBookMultiUser();");
            lnkAddBook.Attributes.Add("onclick", "javascript: AddBookMultiUser();");
            ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];
            if (!IsPostBack)
            {
                string script = null;
                DataSet dsGetFYI = null;
               
                dsGetFYI = new DataSet();
                //dsGetFYI = objFYI.GET_EO_FYI(Convert.ToInt32(Request.QueryString("EOID")));
                if (objEOBA.GET_EO_FYI(Convert.ToInt32(Request.QueryString["EOID"]), ref dsGetFYI))
                {
                    if (dsGetFYI == null)
                    {
                    }
                    else if (dsGetFYI.Tables.Count == 0)
                    {
                        ViewState["FYID"] = 0;
                    }
                    else if (dsGetFYI.Tables[0].Rows.Count == 0)
                    {
                        ViewState["FYID"] = 0;
                    }
                    else
                    {
                        ViewState["FYID"] = 0;
                    }
                }
                DataSet ds = null;
                try
                {
                    //ds = objClsEO.GETEOMandatory(Request.QueryString("EOID"));
                    if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                    {
                        if ((ds != null))
                        {
                            if (!(ds.Tables.Count == 0))
                            {
                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Originator"], System.DBNull.Value)))
                                {
                                    ViewState["Originator"] = ds.Tables[0].Rows[0]["Originator"];
                                }
                                else
                                {
                                    ViewState["Originator"] = string.Empty;
                                }
                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Number"], System.DBNull.Value)))
                                {
                                    ViewState["EONum"] = ds.Tables[0].Rows[0]["EO_Number"];
                                }
                                else
                                {
                                    ViewState["EONum"] = "New EO";
                                }
                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["SAP_IO_Number"], System.DBNull.Value)))
                                {
                                    ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"];
                                }
                                else
                                {
                                    ViewState["SAPIONum"] = "Not Assigned";
                                }
                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value)))
                                {
                                    ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"];
                                }
                                else
                                {
                                    ViewState["EOTitle"] = string.Empty;
                                }
                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Plant_Name"], System.DBNull.Value)))
                                {
                                    ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"];
                                }
                                else
                                {
                                    ViewState["PlantName"] = string.Empty;
                                }

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Current_Stage"], System.DBNull.Value)))
                                {
                                    ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"];
                                }
                                else
                                {
                                    ViewState["stage"] = string.Empty;
                                }

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value)))
                                {
                                    ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"];
                                }
                                else
                                {
                                    ViewState["EOTitle"] = string.Empty;
                                }
                                //for total cost
                                try
                                {
                                    //ViewState["TotCost"] = ClsEO.GET_EO_Total_Cost(Request.QueryString("EoID"), ViewState("stage"), "N");
                                    if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"]), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                                    {
                                        ViewState["TotCost"] = paramOut[0].Value.ToString().Trim();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ViewState["TotCost"] = 0.0;
                                }

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Current_Stage"], System.DBNull.Value)))
                                {
                                    ViewState["Status"] = ds.Tables[0].Rows[0]["Current_Stage"];
                                }
                                else
                                {
                                    ViewState["Status"] = Session["Status"];
                                }
                            }
                        }
                    }
                    //ds = objClsEO.GET_EO_Preliminary(Request.QueryString["EoID"]);
                    if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EoID"]), ref ds))
                    {
                        if ((ds != null))
                        {
                            if (!(ds.Tables.Count == 0))
                            {
                                //jagan 07/01/08

                                try
                                {
                                    if (ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] != System.DBNull.Value)
                                    {
                                        if (ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] == "-- Select Budget Center --")
                                        {
                                            ViewState["Budget_Center_Name"] = string.Empty;
                                        }
                                        else
                                        {
                                            ViewState["Budget_Center_Name"] = ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"];
                                        }
                                    }
                                    else
                                    {
                                        ViewState["Budget_Center_Name"] = string.Empty;
                                    }

                                }
                                catch (Exception ex)
                                {
                                }
                                //for total cost
                                try
                                {
                                   
                                    //ViewState["TotCost"] = ClsEO.GET_EO_Total_Cost(Request.QueryString("EoID"), ViewState("stage"), "N");
                                    if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(Request.QueryString["EoID"]), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                                    {
                                        ViewState["TotCost"] = paramOut[0].Value.ToString().Trim();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ViewState["TotCost"] = 0.0;
                                    //'End Here
                                }
                                //end 07/01/08

                                if (!(ds.Tables[7].Rows.Count == 0))
                                {
                                    if ((!object.ReferenceEquals(ds.Tables[7].Rows[0]["Planned_Start_Date"], System.DBNull.Value)))
                                    {
                                        ViewState["PlannedStartDate"] = ds.Tables[7].Rows[0]["Planned_Start_Date"];
                                    }
                                    else
                                    {
                                        ViewState["PlannedStartDate"] = string.Empty;
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

        protected void imgSendFYI_Click(object sender, ImageClickEventArgs e)
        {
            string script = null;
            string senderName = null;
            string SendersList = null;
            int FYID = 0;
            DataSet dsGetFYI = null;
            string apprName = null;
            int i = 0;
            int j = 0;
            int k = 0;
            int m = 0;
            string oName = null;
            dsGetFYI = new DataSet();
            FYID = Convert.ToInt32(ViewState["FYID"]);
            SendersList = "";
            // i = objFYI.SET_EO_FYI(FYID, Request.QueryString("EOID"), txtUserNames.Text.Trim, txtComments.Text.TrimEnd);
            if (objEOBA.SET_EO_FYI(FYID, Convert.ToInt32(Request.QueryString["EOID"]), hdntxtPrjLead.Value, txtComments.Text.Trim(), ref paramOut))
            {
                i = Convert.ToInt32(paramOut[0].Value);
            }

            if (FYID == 0)
            {
                if (i == 0)
                {
                    try
                    {
                        apprName = hdntxtPrjLead.Value;
                        string[] a = null;
                        a = apprName.Split(',');
                        for (k = 0; k <= a.Length - 1; k++)
                        {
                            try
                            {
                                string appName = a[k];
                                oName = Request.QueryString["oName"];
                                j = appName.IndexOf(" ");
                                if (j > -1)
                                {
                                    appName = appName.Substring(j);
                                }
                                appName = appName.Replace("-", ".");
                                appName = appName.Replace(" ", "");
                                senderName = appName;
                                senderName = senderName + "@pg.com";
                                m = oName.IndexOf(" ");
                                if (m > -1)
                                {
                                    oName = oName.Substring(m);
                                }
                                oName = oName.Replace("-", ".");
                                oName = oName.Replace(" ", "");

                                clsSendMail objSendMail = new clsSendMail();
                                bool IsMailSend = false;
                                objSendMail.SendTo = senderName;
                                string strURL = null;
                                string strURLEditMode = null;

                                if (Request.QueryString["From"] == "EO")
                                {
                                    objSendMail.MailSubject = "Here is a link to EO Number -  " + ViewState["EONum"] + " " + "titled - " + ViewState["EOTitle"];
                                    objSendMail.SendCCTo = oName + "@pg.com";
                                    objSendMail.SendFrom = oName + "@pg.com";
                                    strURLEditMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=ForEOLock&EOID=" + Request.QueryString["EOID"];
                                    objSendMail.MailBody = "Dear " + a[k] + "," + "<br>" + "<br>" + txtComments.Text + "<br>" + "Please follow the link below to see this EO." + "<br>" + "<br>" + "NOTE:  This link will open the document in Read Only Mode." + "<br>" + "<br><a href='" + strURLEditMode + "'>" + strURLEditMode + "</a><br>" + "<br>" + "EO Number is :" + ViewState["EONum"] + "<br>" + "SAP IO Number :" + ViewState["SAPIONum"] + "<br>" + "EO Title is  :" + ViewState["EOTitle"] + "<br>" + "EO Location :" + ViewState["PlantName"] + "<br>" + "Budget Center :" + ViewState["Budget_Center_Name"] + "<br>" + "Expected Cost : $" + ViewState["TotCost"] + "<br>" + "Current Stage  :" + ViewState["stage"] + "<br><font color=red><b>" + "Proposed Testing Start Date :" + ViewState["PlannedStartDate"] + "</b></font><br>" + "<br>" + "Thank you," + "<br>" + objSecurity.UserName + ".";
                                    IsMailSend = clsSendMail.fnSendMail(objSendMail);
                                }
                                else
                                {
                                    objSendMail.MailSubject = "Here is a link to Site Test Number -  " + ViewState["EONum"] + " " + "titled - " + ViewState["EOTitle"];
                                    objSendMail.SendCCTo = oName + "@pg.com";
                                    objSendMail.SendFrom = oName + "@pg.com";
                                    strURL = "http://" + ViewState["servername"] + "/Common/ViewSitetest.aspx?EoID=" + Request.QueryString["EOID"];
                                    objSendMail.MailBody = "Dear " + a[k] + "," + "<br>" + "<br>" + txtComments.Text + "<br>" + "<br>" + "Please follow the link below to see this Site Test." + "<br>" + "<br>" + "NOTE:  This link will open the document in 'Read Only' Mode." + "<br>" + "<br><a href='" + strURL + "'>" + strURL + "</a><br>" + "<br>" + "Site Test Number :" + ViewState["EONum"] + "<br>" + "Site Test Title :" + ViewState["EOTitle"] + "<br>" + "Site Test Location :" + ViewState["PlantName"] + "<br>" + "Current Stage :" + ViewState["Status"] + "<br>" + "<br>" + "Thank you," + "<br>" + objSecurity.UserName + ".";
                                    IsMailSend = clsSendMail.fnSendMail(objSendMail);
                                }
                            }
                            catch (Exception ex)
                            {
                                string str = ex.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                    script = "<script>alert('" + ConfigurationSettings.AppSettings["MailSuccess"] + "');window.close();</script>";
                    Page.RegisterStartupScript("clientscript", script);
                }
                else
                {
                    script = "<script>alert('" + ConfigurationSettings.AppSettings["RecordExist"] + "');window.close();</script>";
                    Page.RegisterStartupScript("clientscript", script);
                }
            }
            else
            {
            }
        }

        protected void imgCanc_Click(object sender, ImageClickEventArgs e)
        {
            string script = null;
            script = "<script>window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }
    }
}