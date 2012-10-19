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
namespace MUREOUI.Common
{
    public partial class PreScreenApproverConfirm : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNo.Attributes.Add("OnClick", "javascript: closeWindow();");
            ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];
            ViewState["EOID"] = Request.QueryString["EOID"];
            if ((Request.QueryString["EoStage"] == "PRESCREEN"))
            {
                lblYesNo.Text = "Are you granting your Prescreen Alignment? ";
                lblDecline.Text = "Are you OPPOSED to granting Prescreen Alignment?";
            }
            else
            {
                lblYesNo.Text = "Are you aligned to this test?";
                lblDecline.Text = "Are you NOT aligned to this test?";
            }
            if ((Request.QueryString["appStatus"].ToUpper() == "Declined".ToUpper()))
            {
                lblYesNo.Visible = false;
                lblDecline.Visible = true;
            }
            else
            {
                lblYesNo.Visible = true;
                lblDecline.Visible = false;
            }
            // lblYesNo.Visible = True
            trYesNo.Visible = true;
            trComments.Visible = false;
            trSAPIO.Visible = false;

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            trYesNo.Visible = false;
            trComments.Visible = true;
        }

        private void EO_Lock_Release()
        {
            try
            {
                if (!(ViewState["EOID"] == null))
                {
                    objEOBA.SET_EO_Lock_Release_User(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), objSecurity.UserName.ToString().Trim());
                  
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
        }

        private void SendMail()
        {
            try
            {

                // Dim intResult, intRow As Integer
                // Dim dsAppList As DataSet
                string strCurrentStage;
                string strStatus;
                int intPlantID=0;
                string strEOnum;
                string strSAPIO= string.Empty;
                DataSet ds= null;
                DataSet dscloseout = null;
                if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                {
                    ViewState["EOID"] = Convert.ToInt32(Request.QueryString["EOID"]);

                    if (!(ds == null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows.Count == 0))
                            {
                                if (!(ds.Tables[0].Rows[0]["EO_Number"] == System.DBNull.Value))
                                {
                                    strEOnum = ds.Tables[0].Rows[0]["EO_Number"].ToString().Trim();
                                    ViewState["EONum"] = ds.Tables[0].Rows[0]["EO_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strEOnum = "0";
                                    ViewState["EONum"] = "New EO";
                                }
                                if (!(ds.Tables[0].Rows[0]["Originator"] == System.DBNull.Value))
                                {
                                    ViewState["Originator"] = ds.Tables[0].Rows[0]["Originator"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["Originator"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["Current_Stage"] == System.DBNull.Value))
                                {
                                    strCurrentStage = ds.Tables[0].Rows[0]["Current_Stage"].ToString().Trim();
                                    ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"].ToString().Trim();
                                }
                                else
                                {
                                    strCurrentStage = String.Empty;
                                    ViewState["stage"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["EO_Title"] == System.DBNull.Value))
                                {
                                    ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["EOTitle"] = String.Empty;
                                }
                                try
                                {
                                    if (!(ds.Tables[0].Rows[0]["Plant_Name"] == System.DBNull.Value))
                                    {
                                        ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"].ToString().Trim();
                                    }
                                    else
                                    {
                                        ViewState["PlantName"] = String.Empty;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ViewState["PlantName"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["Stage_Status"] == System.DBNull.Value))
                                {
                                    if ((Session["Status"] == null))
                                    {
                                        strStatus = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim();
                                        ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim();
                                    }
                                    else
                                    {
                                        strStatus = Session["Status"].ToString().Trim();
                                        ViewState["Status"] = Session["Status"].ToString().Trim();
                                    }
                                }
                                else
                                {
                                    strStatus = String.Empty;
                                    ViewState["Status"] = String.Empty;
                                }
                            }
                        }
                    }

                }


                if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ref ds))
                {
                    if (!(ds == null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            try
                            {
                                if (!(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] == System.DBNull.Value))
                                {
                                    if ((ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"].ToString().Trim() == "-- Select Budget Center --"))
                                    {
                                        ViewState["BudgetCenter"] = String.Empty;
                                    }
                                    else
                                    {
                                        ViewState["BudgetCenter"] = ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"].ToString().Trim();
                                    }
                                }
                                else
                                {
                                    ViewState["BudgetCenter"] = String.Empty;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            // for total cost
                            try
                            {
                                // Modified by Murthy on 04-Mar-2009 reg issue the total cost should get updated
                                // 'Start here
                                
                                    if(objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                                    {
                                          ViewState["TotCost"] =  paramOut[0].ToString().Trim();
                                    }
                                // 'N' Means stage not changing.
                            }
                            catch (Exception ex)
                            {
                                ViewState["TotCost"] = 0;
                                // 'End Here
                            }
                            // end 06/01/08
                            if (!(ds.Tables[7].Rows.Count == 0))
                            {
                                if (!(ds.Tables[7].Rows[0]["Planned_Start_Date"] == System.DBNull.Value))
                                {
                                    ViewState["PlannedStartDate"] = ds.Tables[7].Rows[0]["Planned_Start_Date"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["PlannedStartDate"] = String.Empty;
                                }
                            }
                        }
                    }
                }



                // If Not strMailIDs = "" Then
                int intPosition;
                int i;
                int intPosOriginator;
                string PosOriginator;
                try
                {
                    if (!(ViewState["Originator"] == null))
                    {
                        PosOriginator = ViewState["Originator"].ToString().Trim();
                        intPosOriginator = PosOriginator.IndexOf(" ");
                        PosOriginator = PosOriginator.Substring(intPosOriginator);
                        PosOriginator = PosOriginator.Replace("-", ".");
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    // jagan code start
                    string strURLLockMode;
                    strURLLockMode = ("http://"
                                + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                    string strURLEditMode;
                    strURLEditMode = ("http://"
                                + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                    string strLockURL = ("http://"
                                + (ViewState["servername"] + ("/Common/ViewSiteTest.aspx?EoID=" + ViewState["EOID"])));
                    string strURL = ("http://"
                                + (ViewState["servername"] + ("/Common/SiteTest.aspx?From=EDIT&EoID=" + ViewState["EOID"])));
                    string strBody=string.Empty;
                    string strSub = string.Empty;
                    if ((Request.QueryString["EoStage"].ToUpper() == "PRESCREEN"))
                    {
                        // strSub = "Your EO, '" & ViewState["EOTitle") & "', has been prescreened. (" & ViewState["EONum") & " )"
                        strSub = ("Your EO(Number - "
                                    + (ViewState["EONum"] + (") titled "
                                    + (ViewState["EOTitle"] + " has been prescreened."))));
                        strBody = ("Dear "
                                    + (ViewState["Originator"] + ", "));
                        if ((Request.QueryString["appStatus"].ToUpper() == "Declined".ToUpper()))
                        {
                            strBody = (strBody + ("<br>" + ("<br>" + "Prescreen approved? Response: \'No\'.")));
                        }
                        else
                        {
                            strBody = (strBody + ("<br>" + ("<br>" + "Prescreen approved? Response: \'Yes\'.")));
                        }
                        strBody = (strBody + ("<br>" + ("<br>" + ("Responder comments, if any: \'"
                                    + (txtCommnets.Text.ToString().Trim() + ("\'" + ("<br>" + ("Please follow the link to see this EO." + ("<br>" + ("<br><a href=\'"
                                    + (strURLEditMode + ("\'>"
                                    + (strURLEditMode + ("</a>" + ("<br>" + ("<br>" + ("EO Number is :"
                                    + (ViewState["EONum"] + ("<br>" + ("EO Title is :"
                                    + (ViewState["EOTitle"] + ("<br>" + ("Current Stage :"
                                    + (ViewState["stage"] + ("<br>" + ("Budget Center :"
                                    + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost  :$"
                                    + (ViewState["TotCost"] + ("<br>" + ("<font color=red><b>Proposed Testing Start Date :"
                                    + (ViewState["PlannedStartDate"] + ("</b></font>" + ("<br>" + ("<br>" + ("Thank you," + ("<br>"
                                    + (objSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))));
                    }
                    else if ((Request.QueryString["EoStage"].ToUpper() == "CONCURENCE"))
                    {
                        strSub = ("Your EO(Number - "
                                    + (ViewState["EONum"] + (") titled "
                                    + (ViewState["EOTitle"] + " has been concurred."))));
                        strBody = ("Dear "
                                    + (ViewState["Originator"] + ", "));
                        if ((Request.QueryString["appStatus"].ToUpper() == "Declined".ToUpper()))
                        {
                            strBody = (strBody + ("<br>" + ("<br>" + "Concurence approved? Response: \'No\'.")));
                        }
                        else
                        {
                            strBody = (strBody + ("<br>" + ("<br>" + "Concurence approved? Response: \'Yes\'.")));
                        }
                        if ((Request.QueryString["FormName"] == "SITETEST"))
                        {
                            strBody = (strBody + ("<br>" + ("<br>" + ("Responder comments, if any: \'"
                                        + (txtCommnets.Text.ToString().Trim() + ("\'" + ("<br>" + ("Please follow the link to see this EO." + ("<br>" + ("<br><a href=\'"
                                        + (strURL + ("\'>"
                                        + (strURL + ("</a>" + ("<br>" + ("<br>" + ("EO Number :"
                                        + (ViewState["EONum"] + ("<br>" + ("EO Title :"
                                        + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                        + (ViewState["PlantName"] + ("<br>" + ("<br>" + ("Thank you," + ("<br>"
                                        + (objSecurity.UserName + ".")))))))))))))))))))))))))))));
                        }
                        else
                        {
                            strBody = (strBody + ("<br>" + ("<br>" + ("Responder comments, if any: \'"
                                        + (txtCommnets.Text.ToString().Trim() + ("\'" + ("<br>" + ("Please follow the link to see this EO." + ("<br>" + ("<br><a href=\'"
                                        + (strURLEditMode + ("\'>"
                                        + (strURLEditMode + ("</a>" + ("<br>" + ("<br>" + ("EO Number :"
                                        + (ViewState["EONum"] + ("<br>" + ("EO Title is :"
                                        + (ViewState["EOTitle"] + ("<br>" + ("Current Stage :"
                                        + (ViewState["stage"] + ("<br>" + ("Budget Center :"
                                        + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost  :$"
                                        + (ViewState["TotCost"] + ("<br>" + ("<font color=red><b>Proposed Testing Start Date :"
                                        + (ViewState["PlannedStartDate"] + ("</b></font>" + ("<br>" + ("<br>" + ("Thank you," + ("<br>"
                                        + (objSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))));
                        }
                    }
                    //  strBody = "hello"
                    SendMail(objSecurity.UserName, strSub, strBody);
                }
                catch (Exception ex)
                {
                }
                // End If
            }
            catch (Exception ex)
            {
            }
        }

        private void SendMail(string ApprName, string strSubject, string strBody)
        {
            int intPosOriginator;
            string PosOriginator = string.Empty;
            string strApprName = string.Empty; 
            try
            {
                if (!(ViewState["Originator"] == null))
                {
                    PosOriginator = ViewState["Originator"].ToString().Trim();
                    intPosOriginator = PosOriginator.IndexOf(" ");
                    PosOriginator = PosOriginator.Substring(intPosOriginator);
                    PosOriginator = PosOriginator.Replace("-", ".");
                }
            }
            catch (Exception ex)
            {
            }
            try
            {
                if ((ApprName.ToString().Trim() != ""))
                {
                    // strApprName = ApprName
                    intPosOriginator = ApprName.IndexOf(" ");
                    ApprName = ApprName.Substring(intPosOriginator);
                    ApprName = ApprName.Replace("-", ".");
                }
            }
            catch (Exception ex)
            {
            }
            try
            {
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = (PosOriginator.ToString().Trim() + "@pg.com");
                objSendMail.SendFrom = (ApprName + "@pg.com");
                objSendMail.MailSubject = strSubject;
                objSendMail.MailBody = strBody;
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                // Dim objMail As New MailMessage
                // objMail.To = PosOriginator & "@pg.com"
                // objMail.From = ApprName & "@pg.com"
                // objMail.Subject = strSubject
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Body = strBody
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP") '"clev.vertexcs.com"
                // SmtpMail.Send(objMail)
            }
            catch (Exception ex)
            {
            }
            // Next
        }

        protected void btnYes_Click1(object sender, EventArgs e)
        {
            trYesNo.Visible = false;
            trComments.Visible = true;
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string script;
            if ((Request.QueryString["EoStage"].ToUpper() == "PRESCREEN"))
            {
                if (((Request.QueryString["appStatus"].ToUpper() == "Declined".ToUpper())
                            && (txtCommnets.Text.ToString().Trim() == String.Empty)))
                {
                    script = "<script>alert('Please enter comments');</script>";
                    //script = script + "window.opener.document.forms(0)." + "btnConApp" + ".click();";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    return;
                }
                int intRes;
                objEO objEO = new objEO();
                objEO.IsResponded = Request.QueryString["appStatus"];
                objEO.ConAppID = Convert.ToInt32(Request.QueryString["PSAppID"].ToString().Trim());
                objEO.EOID = Request.QueryString["EOID"];
                objEO.UserName = objSecurity.UserName;
                if ((txtCommnets.Text.ToString().Trim() == String.Empty))
                {
                    objEO.Comment = "";
                }
                else
                {
                    objEO.Comment = txtCommnets.Text.ToString().Trim();
                }
                //intRes = 
                if (objEOBA.setPrescreenStatus(Convert.ToInt32(objEO.EOID.ToString().Trim()), Convert.ToInt32(objEO.ConAppID.ToString().Trim()), objEO.IsResponded.ToString().Trim(), objEO.Comment.ToString().Trim(), objSecurity.UserName.ToString().Trim(), ref paramOut))
                {
                    intRes = Convert.ToInt32(paramOut[0].Value.ToString().Trim());
                }
                SendMail();
                EO_Lock_Release();
                script = "<script>";
                script = (script + "window.returnValue = 'T';");
                script = script + "window.opener.document.forms(0)." + "btnAppPreScreen" + ".click();";
                script = (script + "window.close();</script>");
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
            }
            else if ((Request.QueryString["EoStage"].ToUpper() == "CONCURENCE"))
            {
                if (((Request.QueryString["appStatus"].ToUpper() == "Declined".ToUpper())
                            && (txtCommnets.Text.ToString().Trim() == String.Empty)))
                {
                    script = "<script>alert('Please enter comments');</script>";
                    //script = script + "window.opener.document.forms(0)." + "btnConApp" + ".click();";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    return;
                }
                int intRes;
                objEO objEO = new objEO();
                objEO.IsResponded = Request.QueryString["appStatus"];
                objEO.ConAppID = Convert.ToInt32(Request.QueryString["ConAppID"].ToString().Trim());
                objEO.EOID = Request.QueryString["EOID"];
                objEO.UserName = objSecurity.UserName;
                objEO.ApprNameList = Request.QueryString["AppName"];
                objEO.ConGrpID = Convert.ToInt32(Request.QueryString["ConGrpID"].ToString().Trim());
                if ((txtCommnets.Text.ToString().Trim() == String.Empty))
                {
                    objEO.Comment = "";
                }
                else
                {
                    objEO.Comment = txtCommnets.Text.ToString().Trim();
                }
                if (objEOBA.AddConGrpNames(Convert.ToInt32(objEO.ConAppID.ToString().Trim()), Convert.ToInt32(objEO.EOID.ToString().Trim()), Convert.ToInt32(objEO.ConGrpID.ToString().Trim()), objEO.ApprNameList.ToString().Trim(), objEO.IsResponded.ToString().Trim(), objEO.Comment.ToString().Trim(), objSecurity.UserName.ToString().Trim(), ref paramOut))
                {
                    intRes = Convert.ToInt32(paramOut[0].Value.ToString());
                }

                SendMail();
                EO_Lock_Release();


                script = "<script>";
                script = script + "window.returnValue = 'T';";
                script = script + "window.opener.document.forms(0)." + "btnConApp" + ".click();";
                script = script + "window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
        }

       
    }
}