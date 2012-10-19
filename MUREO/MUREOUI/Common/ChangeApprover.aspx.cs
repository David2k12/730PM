using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Common
{
    public partial class ChangeApprover : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;

        private void Page_Load(System.Object sender,     System.EventArgs e)
        {
            ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"].ToString();
            if (Request.QueryString["From"] == "BackUp")
            {
                lbltitle.Text = "Please select Back-up approver from below dropdown";
            }
            else
            {
                lbltitle.Text = "Please select approver from below dropdown";
            }
            ViewState["EOID"] = Request.QueryString["EOID"];
            if (!Page.IsPostBack)
            {
                ViewState["EOID"] = Request.QueryString["EOID"];
                DataSet ds = null;
                if (objEOBA.GETEOMandatory(Convert.ToInt32(ViewState["EOID"]), ref ds))
                {


                    if ((ds != null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows.Count == 0))
                            {
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


                                //Added on 01/20/2010 
                                //For MUREO PCRs
                                //By: David
                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Smart_Clearance_Number"], System.DBNull.Value)))
                                {
                                    ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["Smart_Clearance_Number"];
                                }
                                else
                                {
                                    ViewState["SmartClearanceNum"] = "Not Assigned";
                                }

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Originator"], System.DBNull.Value)))
                                {
                                    ViewState["Originator"] = ds.Tables[0].Rows[0]["Originator"];
                                }
                                else
                                {
                                    ViewState["Originator"] = string.Empty;
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

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Stage_Status"], System.DBNull.Value)))
                                {
                                    ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"];
                                }
                                else
                                {
                                    ViewState["Status"] = Session["Status"];
                                }

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value)))
                                {
                                    ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"];
                                }
                                else
                                {
                                    ViewState["EOTitle"] = string.Empty;
                                }
                            }
                        }
                    }
                }
                DataSet dsApproverList = new DataSet();
                DataSet dsAdditionalApprover1List = new DataSet();
                DataSet dsAdditionalApprover2List = new DataSet();
                DataSet dsAdditionalApprover3List = new DataSet();
                DataSet dsAdditionalApprover4List = new DataSet();

                string strFunctionName = null;
                if (Request.QueryString["FuncName"].ToString() == "Site HS")
                {
                    strFunctionName = "Site HS&E Resource";
                }
                else if (Request.QueryString["FuncName"].ToString() == "GBU HS")
                {
                    strFunctionName = "GBU HS&E Resource";
                }
                else if (Request.QueryString["FuncName"].ToString() == "PS")
                {
                    strFunctionName = "PS&RA";
                }
                else
                {
                    strFunctionName = Request.QueryString["FuncName"];
                }
                // if function name is additional Approver #1/2/3/4/change the function

                if (strFunctionName == "Additional approver1")
                {
                    if (objEOBA.GETEOFunctionsAdditionalApprover1Plant(ref dsAdditionalApprover1List))
                    {
                        if ((dsAdditionalApprover1List != null))
                        {
                            if (!(dsAdditionalApprover1List.Tables.Count == 0))
                            {
                                if (!(dsAdditionalApprover1List.Tables[0].Rows.Count == 0))
                                {
                                    drpApprover.DataSource = dsAdditionalApprover1List.Tables[0].DefaultView;
                                    drpApprover.DataTextField = "Approver_Name";
                                    drpApprover.DataValueField = "Approver_Name";
                                    drpApprover.DataBind();
                                }
                                else
                                {
                                    string script = null;
                                    script = "<script>alert('No Approver exist for this combination');";
                                    script = script + "window.close();</script>";
                                    Page.RegisterStartupScript("clientscript", script);
                                }
                            }
                            else
                            {
                                string script = null;
                                script = "<script>alert('No Approver exist for this combination');";
                                script = script + "window.close();</script>";
                                Page.RegisterStartupScript("clientscript", script);
                            }
                        }
                    }

                }
                else if (strFunctionName == "Additional approver2")
                {
                    if (objEOBA.GETEOFunctionsAdditionalApprover4Plant(ref dsAdditionalApprover2List))
                    {

                        if ((dsAdditionalApprover2List != null))
                        {
                            if (!(dsAdditionalApprover2List.Tables.Count == 0))
                            {
                                if (!(dsAdditionalApprover2List.Tables[0].Rows.Count == 0))
                                {
                                    drpApprover.DataSource = dsAdditionalApprover2List.Tables[0].DefaultView;
                                    drpApprover.DataTextField = "Approver_Name";
                                    drpApprover.DataValueField = "Approver_Name";
                                    drpApprover.DataBind();
                                }
                                else
                                {
                                    string script = null;
                                    script = "<script>alert('No Approver exist for this combination');";
                                    script = script + "window.close();</script>";
                                    Page.RegisterStartupScript("clientscript", script);
                                }
                            }
                            else
                            {
                                string script = null;
                                script = "<script>alert('No Approver exist for this combination');";
                                script = script + "window.close();</script>";
                                Page.RegisterStartupScript("clientscript", script);
                            }
                        }
                    }

                }
                else if (strFunctionName == "Additional approver3")
                {
                    if (objEOBA.GETEOFunctionsAdditionalApprover3Plant(ref dsAdditionalApprover3List))
                    {
                        if ((dsAdditionalApprover3List != null))
                        {
                            if (!(dsAdditionalApprover3List.Tables.Count == 0))
                            {
                                if (!(dsAdditionalApprover3List.Tables[0].Rows.Count == 0))
                                {
                                    drpApprover.DataSource = dsAdditionalApprover3List.Tables[0].DefaultView;
                                    drpApprover.DataTextField = "Approver_Name";
                                    drpApprover.DataValueField = "Approver_Name";
                                    drpApprover.DataBind();
                                }
                                else
                                {
                                    string script = null;
                                    script = "<script>alert('No Approver exist for this combination');";
                                    script = script + "window.close();</script>";
                                    Page.RegisterStartupScript("clientscript", script);
                                }
                            }
                            else
                            {
                                string script = null;
                                script = "<script>alert('No Approver exist for this combination');";
                                script = script + "window.close();</script>";
                                Page.RegisterStartupScript("clientscript", script);
                            }
                        }

                    }

                }
                else if (strFunctionName == "Additional approver4")
                {
                    if (objEOBA.GETEOFunctionsAdditionalApprover4Plant(ref dsAdditionalApprover4List))
                    {

                        if ((dsAdditionalApprover4List != null))
                        {
                            if (!(dsAdditionalApprover4List.Tables.Count == 0))
                            {
                                if (!(dsAdditionalApprover4List.Tables[0].Rows.Count == 0))
                                {
                                    drpApprover.DataSource = dsAdditionalApprover4List.Tables[0].DefaultView;
                                    drpApprover.DataTextField = "Approver_Name";
                                    drpApprover.DataValueField = "Approver_Name";
                                    drpApprover.DataBind();
                                }
                                else
                                {
                                    string script = null;
                                    script = "<script>alert('No Approver exist for this combination');";
                                    script = script + "window.close();</script>";
                                    Page.RegisterStartupScript("clientscript", script);
                                }
                            }
                            else
                            {
                                string script = null;
                                script = "<script>alert('No Approver exist for this combination');";
                                script = script + "window.close();</script>";
                                Page.RegisterStartupScript("clientscript", script);
                            }
                        }

                    }
                }
                else
                {

                    if (objEOBA.GETEOFunctionsApproverPlant(strFunctionName, Convert.ToInt32(Request.QueryString["PlantID"]), ref dsApproverList))
                    {
                        if ((dsApproverList != null))
                        {
                            if (!(dsApproverList.Tables.Count == 0))
                            {
                                if (!(dsApproverList.Tables[0].Rows.Count == 0))
                                {
                                    drpApprover.DataSource = dsApproverList.Tables[0].DefaultView;
                                    drpApprover.DataTextField = "Approver_Name";
                                    drpApprover.DataValueField = "Approver_Name";
                                    drpApprover.DataBind();
                                }
                                else
                                {
                                    string script = null;
                                    script = "<script>alert('No Approver exist for this combination');";
                                    script = script + "window.close();</script>";
                                    Page.RegisterStartupScript("clientscript", script);
                                }
                            }
                            else
                            {
                                string script = null;
                                script = "<script>alert('No Approver exist for this combination');";
                                script = script + "window.close();</script>";
                                Page.RegisterStartupScript("clientscript", script);
                            }
                        }
                    }
                }

            }
            else
            {
                //Dim script As String
                //script = "<script>alert('No Approver exist for this combination');"
                //script = script + "window.close();</script>"
                //Page.RegisterStartupScript("clientscript", script)
            }
        }

        public void Backupmail()
        {
            string strMailFrom = objSecurity.UserName;
            int intPosOriginator = 0;
            try
            {
                if (!string.IsNullOrEmpty(strMailFrom.Trim()))
                {
                    intPosOriginator = strMailFrom.IndexOf(" ");
                    strMailFrom = strMailFrom.Substring(intPosOriginator);
                    strMailFrom = strMailFrom.Replace("-", ".");
                }
            }
            catch (Exception ex)
            {
            }
            string strURLLockMode = null;
            strURLLockMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"];

            string strURLEditMode = null;
            strURLEditMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"];
            try
            {
                try
                {
                    int intPosition = 0;
                    int i = 0;
                    string appName = null;
                    string senderName = null;
                    string PosOriginator = null;
                    string strOriginator = null;
                    string[] strMailIDs = null;
                    if (!string.IsNullOrEmpty(drpApprover.SelectedItem.Text.ToString().Trim()))
                    {
                        appName = drpApprover.SelectedItem.Text.Trim();
                        intPosition = appName.IndexOf(" ");
                        appName = appName.Substring(intPosition);
                        appName = appName.Replace("-", ".");
                        senderName = appName;
                        senderName = senderName + "@pg.com";
                        try
                        {
                            if ((ViewState["Originator"] != null))
                            {
                                PosOriginator = ViewState["Originator"].ToString();
                                intPosOriginator = PosOriginator.IndexOf(" ");
                                PosOriginator = PosOriginator.Substring(intPosOriginator);
                                PosOriginator = PosOriginator.Replace("-", ".");
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        if (!string.IsNullOrEmpty(senderName))
                        {
                            clsSendMail objSendMail = new clsSendMail();
                            objSendMail.SendTo = senderName;
                            objSendMail.SendFrom = strMailFrom + "@pg.com";
                            objSendMail.MailSubject = "Please Review this EO Document.EO Number - " + ViewState["EONum"] + "-" + ViewState["EOTitle"];
                            objSendMail.MailBody = "Dear Approver," + "<br>" + "<br>" + "This message was originally sent to " + Request.QueryString["OriginalApprover"] + " who is out of the office." + "<br>" + "<br>" + "You are listed as the back-up approver for the " + Request.QueryString["FuncName"] + "  section of this EO." + "<br>" + "<br>" + "Please follow the link to see this EO." + "<br>" + "<br>" + "Eo Number is :" + ViewState["EONum"] + "<br>" + "<br>" + "SAPIO Number is :" + ViewState["SAPIONum"] + "<br>" + "<br>" + "Smart Clearance Number is :" + ViewState["SmartClearanceNum"] + "<br>" + "<br>" + "EO Title is :" + ViewState["EOTitle"] + "<br>" + "EO Location :" + ViewState["PlantName"] + "<br>" + "<br>" + "Current Stage :" + ViewState["stage"] + "<br>" + "<br>" + "NOTE: Use this link to open in Read Only Mode." + "<br>" + "<br><a href='" + strURLLockMode + "'>" + strURLLockMode + "</a><br>" + "<br>" + "Note :Use this link will open the EO in Edit Mode." + "<br>" + "<br><a href='" + strURLEditMode + "'>" + strURLEditMode + "</a><br>" + "<br>" + "Thank you," + "<br>" + objSecurity.UserName + ".";
                            bool IsMailSend = false;
                            IsMailSend = clsSendMail.fnSendMail(objSendMail);
                        
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    int intPosition = 0;
                    int i = 0;
                    string appName = null;
                    string senderName = null;
                    string PosOriginator = null;
                    string strOriginator = null;
                    if (!string.IsNullOrEmpty(Request.QueryString["OriginalApprover"]))
                    {
                        appName = Request.QueryString["OriginalApprover"];
                        intPosition = appName.IndexOf(" ");
                        appName = appName.Substring(intPosition);
                        appName = appName.Replace("-", ".");
                        senderName = appName;
                        senderName = senderName + "@pg.com";
                        try
                        {
                            if ((ViewState["Originator"] != null))
                            {
                                PosOriginator = ViewState["Originator"].ToString();
                                intPosOriginator = PosOriginator.IndexOf(" ");
                                PosOriginator = PosOriginator.Substring(intPosOriginator);
                                PosOriginator = PosOriginator.Replace("-", ".");
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        if (!string.IsNullOrEmpty(senderName))
                        {
                            clsSendMail objSendMail = new clsSendMail();
                            objSendMail.SendTo = senderName;
                            objSendMail.SendFrom = strMailFrom + "@pg.com";
                            objSendMail.MailSubject = "Please Review this EO Document.EO Number - " + ViewState["EONum"] + "-" + ViewState["EOTitle"];
                            objSendMail.MailBody = "Dear Original Approver," + "<br>" + "<br>" + "You were originally listed as an appover for this EO.In your absence,this has been sent to " + drpApprover.SelectedItem.Text.Trim() + " for your back up." + "<br>" + "<br>" + "No further action is needed on your part." + "<br>" + "<br>" + "<br>" + "NOTE: Use this link to open in Read Only Mode." + "<br>" + "<br><a href='" + strURLLockMode + "'>" + strURLLockMode + "</a><br>" + "<br>" + "Eo Number is :" + ViewState["EONum"] + "<br>" + "<br>" + "SAPIO Number is :" + ViewState["SAPIONum"] + "<br>" + "<br>" + "Smart Clearance Number is :" + ViewState["SmartClearanceNum"] + "<br>" + "<br>" + "EO Title is :" + ViewState["EOTitle"] + "<br>" + "EO Location :" + ViewState["PlantName"] + "<br>" + "<br>" + "Current Stage :" + ViewState["stage"] + "<br>" + "<br>" + "Thank you," + "<br>" + objSecurity.UserName + ".";
                            bool IsMailSend = false;
                            //IsMailSend = objSendMail.fnSendMail(objSendMail);
                            IsMailSend = clsSendMail.fnSendMail(objSendMail);
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["From"] == "Pre")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['hdnBudgetOwner'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.opener.parent.NewEO['txtBudgetOwner'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);

            }
            else if (Request.QueryString["From"] == "AdditionalApprover1Final")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalAdditionalApprover1'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "AdditionalApprover2Final")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalAdditionalApprover2'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "AdditionalApprover3Final")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalAdditionalApprover3'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "AdditionalApprover4Final")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalAdditionalApprover4'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);



            }
            else if (Request.QueryString["From"] == "FinalSMARTClearance")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSMARTClearanceFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SmartClear")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSmartClearance'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "PreGBU")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtGBUHSE'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "Final")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtPSInitiative'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "CO")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtCloseSiteFinance'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SiteHSE")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSiteHSE'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SiteConta")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSiteContact'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SitePlan")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSitePlanning'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "QAPre")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtQAPre'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "CentralQAPre")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtCentralQAPre'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "FinalCentralQA")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalCentralQA'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "CenPlan")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtCentralPlanning'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SAP")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSAPCost'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "TGate")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtTimingGate'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "StandsOff")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtStandardOffice'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);

            }
            else if (Request.QueryString["From"] == "AdditionalApprover1")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtAdditionalApp1'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "AdditionalApprover2")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtAdditionalApp2'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "AdditionalApprover3")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtAdditionalApp3'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "AdditionalApprover4")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtAdditionalApp4'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);

                //----------------for Final tab change Approvers
            }
            else if (Request.QueryString["From"] == "FinalProductReSearch")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtProductsResearch'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "FinalBO")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['hdnBudgetOwnerFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.opener.parent.NewEO['txtBudgetOwnerFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);

               
               
            }
            else if (Request.QueryString["From"] == "FinalGBUHSE")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtGBUHSEFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "FinalSiteHSE")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSiteHSEFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "FinalSAP")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSAPCostCenter'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SitePlanFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSitePlanFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SiteContactFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSiteContactFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SiteFinanceFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSiteFinance'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SiteLeaderFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtSiteLeaderShip'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "PSRAFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtPSRAFinal'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "TimiGateFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalTimingGate'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "QAFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalQA'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "StanOfficeFinal")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtFinalStandardsOffice'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "SiteFinaceCO")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtCloseSiteFinance'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "BOCO")
            {
                string script = null;
                script = "<script>window.opener.parent.NewEO['txtCloseBudgetOwner'].value = '" + drpApprover.SelectedItem.Text + "';";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else if (Request.QueryString["From"] == "BackUp")
            {
                try
                {
                    DataSet dsAppList = null;
                    string strFunctionName = null;
                    if (Request.QueryString["FuncName"].ToString() == "Site HS")
                    {
                        strFunctionName = "Site HS&E Resource";
                    }
                    else if (Request.QueryString["FuncName"].ToString() == "GBU HS")
                    {
                        strFunctionName = "GBU HS&E Resource";
                    }
                    else if (Request.QueryString["FuncName"].ToString() == "PS")
                    {
                        strFunctionName = "PS&RA";
                    }
                    else
                    {
                        strFunctionName = Request.QueryString["FuncName"].ToString();
                    }

                    if (strFunctionName == "Additional approver1")
                    {
                        strFunctionName = "Additional approver #1";
                    }
                    else if (strFunctionName == "Additional approver2")
                    {
                        strFunctionName = "Additional approver #2";
                    }
                    else if (strFunctionName == "Additional approver3")
                    {
                        strFunctionName = "Additional approver #3";
                    }
                    else if (strFunctionName == "Additional approver4")
                    {
                        strFunctionName = "Additional approver #4";
                    }

                    //dsAppList = objClsEO.SetApprovarStatus(ViewState["EOID"], ViewState["stage"], strFunctionName, Request.QueryString["OriginalApprover"], "", drpApprover.SelectedItem.Text);

                    if (objEOBA.SetApprovarStatus(Convert.ToInt32(ViewState["EOID"]), ViewState["stage"].ToString(), strFunctionName.ToString(), Request.QueryString["OriginalApprover"].ToString(), Convert.ToChar("$"), drpApprover.SelectedItem.Text.ToString(), ref dsAppList, ref paramOut))
                    { }

                    Backupmail();

                    try
                    {
                        if (!(ViewState["EOID"] == null))
                        {
                            //objClsEO.SET_EO_Lock_Release_User(ViewState["EOID"], objSecurity.UserName);
                            if (objEOBA.SET_EO_Lock_Release_User(Convert.ToInt32(ViewState["EOID"]), objSecurity.UserName))
                            { }
                        }
                    }

                    catch (Exception ex)
                    {
                    }

                    string script = null;
                    script = "<script>window.opener.parent.NewEO['txtBackUpName'].value = '" + drpApprover.SelectedItem.Text + "';";
                    script = script + "window.opener.location.href = 'home.aspx';window.close();</script>";
                    Page.RegisterStartupScript("clientscript", script);
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void imgCancel_Click1(object sender, ImageClickEventArgs e)
        {
            string script = null;
            //script = "<script>window.opener.parent.NewEO['txtBackUpName'].value = '" + drpApprover.SelectedItem.Text + "';"
            script = "<script>window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

    }
}