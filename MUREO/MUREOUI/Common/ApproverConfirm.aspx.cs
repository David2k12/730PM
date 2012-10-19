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
using System.Web.Mail;

namespace MUREOUI.Common
{
    public partial class ApproverConfirm : System.Web.UI.Page
    {
        clsSendMail objMail = new clsSendMail();
        SqlParameter[] paramOut = null;
        string UserAgent = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            UserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
            //if (Session["btn_click"] != null)
            //    Label1.Text = Session["btn_click"].ToString();
            //else
            //    Label1.Text = "Session Empty";
            btnSubmit.Attributes.Add("onclick", "javascript: hourglass();"); 
            btnNo.Attributes.Add("OnClick", "javascript: closeWindow();");
            if ((Request.QueryString["appStatus"].ToString() == "N"))
            {
                lblYesNo.Visible = false;
                lblDecline.Visible = true;
            }
            else
            {
                lblYesNo.Visible = true;
                lblDecline.Visible = false;
            }

            //if ((lblDecline.Visible) && (txtCommnets.Text == ""))
            //{}
            //else
            //{
            //btnSubmit.Attributes.Add("onClientClick", "javascript: test();");
            //}
            trYesNo.Visible = true;
            trComments.Visible = false;
            TrSAPIO.Visible = false;
            TrSmartClearance.Visible = false;
            //if (!Page.IsPostBack)
            //{
            //    Session["btn_click"] = "YES";
            //}
            Session["btn_click"] = "YES";
            ViewState["servername"] = System.Configuration.ConfigurationManager.AppSettings["ServerName"];
            ViewState["EOID"] = Request.QueryString["EOID"];

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            trYesNo.Visible = false;
            trComments.Visible = true;
            if ((Request.QueryString["appFunName"].ToString() == "SAP Cost Center Coordinator"))
            {
                TrSAPIO.Visible = true;
                //DataSet ds;
                //ClsEO objEOBA = new ClsEO();
                EOBA objEOBABA = new EOBA();
                DataSet objDS = null;
                try
                {
                    if (objEOBABA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref objDS))
                    {
                        if (!(objDS == null))
                        {
                            if (!(objDS.Tables.Count == 0))
                            {
                                if (!(objDS.Tables[0].Rows.Count == 0))
                                {
                                    if (!(objDS.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                                    {
                                        txtSAPIO.Text = objDS.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                    }
                                    else
                                    {
                                        txtSAPIO.Text = String.Empty;
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
            // Added on 05/14/2010 For Smart Clearance
            // Added on 01/20/2010 
            // For MUREO PCRs
            // By: David
            if ((Request.QueryString["appFunName"].ToString() == "SMART Clearance"))
            {
                TrSmartClearance.Visible = true;
                DataSet ds = null;
                EOBA objEOBABA = new EOBA();
                try
                {
                    if (objEOBABA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                    {
                        if (!(ds == null))
                        {
                            if (!(ds.Tables.Count == 0))
                            {

                                if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                                {
                                    if ((ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim() == "In Process"))
                                    {
                                        txtSmartClearance.Text = String.Empty;
                                    }
                                    else
                                    {
                                        txtSmartClearance.Text = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                    }
                                }
                                else
                                {
                                    txtSmartClearance.Text = String.Empty;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            if (!Page.IsPostBack)
            {
                Session["btn_click"] = "YES";
            }
        }

        private void sendAllApprovalMail(string strmailfrom)
        {
            DataSet ds =  null;
            DataSet dscloseout = null;
            DataSet dsFinal = null;
            EOBA objEOBABA = new EOBA();
            clsSecurity Security = new clsSecurity();
            

            if (objEOBABA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
            {
                ViewState["EOID"] = Request.QueryString["EOID"];
                if (!(ds == null))
                {
                    if (!(ds.Tables.Count == 0))
                    {
                        if (!(ds.Tables[0].Rows.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows[0]["EO_Number"] == System.DBNull.Value))
                            {
                                ViewState["EONum"]= ds.Tables[0].Rows[0]["EO_Number"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["EONum"] = "New EO";
                            }
                            if (!(ds.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                            {
                                ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["SAPIONum"] = "Not Assigned";
                            }
                            // Added on 01/20/2010 
                            // For MUREO PCRs
                            // By: David
                            if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                            {
                                ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["SmartClearanceNum"] = "Not Assigned";
                            }
                            if (!(ds.Tables[0].Rows[0]["Plant_ID"] == System.DBNull.Value))
                            {
                                ViewState["PlantID"] = ds.Tables[0].Rows[0]["Plant_ID"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["PlantID"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Plant_Name"] == System.DBNull.Value))
                            {
                                ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["PlantName"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Current_Stage"] == System.DBNull.Value))
                            {
                                ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"].ToString().Trim();
                            }
                            else
                            {
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
                            if (!(ds.Tables[0].Rows[0]["Originator"] == System.DBNull.Value))
                            {
                                ViewState["Originator"] = ds.Tables[0].Rows[0]["Originator"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["Originator"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Stage_Status"] == System.DBNull.Value))
                            {
                                if ((Session["Status"] == null))
                                {
                                    ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["Status"] = Session["Status"].ToString().Trim();
                                }
                            }
                            else
                            {
                                ViewState["Status"] = String.Empty;
                            }
                            if ((ViewState["stage"].ToString().ToUpper() == "CloseOut".ToUpper()))
                            {
                                if ((ViewState["Status"].ToString().ToUpper() == "Approved".ToUpper()))
                                {
                                    ViewState["Status"] = "Completed";
                                }
                            }
                            if (!(ds.Tables[0].Rows[0]["Category_ID"] == System.DBNull.Value))
                            {
                                ViewState["CategoryID"] = ds.Tables[0].Rows[0]["Category_ID"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["CategoryID"] = String.Empty;
                            }
                        }
                    }
                }
            }
            if (objEOBABA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
            {

            if (!(ds == null)) 
            {
                if (!(ds.Tables.Count == 0)) 
                {
                    try 
                    {
                        if (!(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] == System.DBNull.Value)) 
                        {
                            if ((ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"].ToString().Trim()== "-- Select Budget Center --")) 
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
                    try {
                        // Modified by Murthy on 04-Mar-2009 reg issue the total cost should get updated
                        // 'Start here
                        if ((ViewState["Status"].ToString().Trim() == "Completed"))
                        {

                            if(objEOBABA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                            {

                                ViewState["TotCost"] = paramOut[0].Value.ToString().Trim();
                            }
                            // After closeout approved no stage to reduce.
                        }
                        else 
                        {
                              if(objEOBABA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "Y", ref paramOut))
                            {

                                ViewState["TotCost"] = paramOut[0].Value.ToString().Trim();
                            }
                            // 'Y' Means moving to next stage.
                        }
                    }
                    catch (Exception ex) 
                    {
                        ViewState["TotCost"] = "0";
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
                    if (!(ds.Tables[12].Rows.Count == 0)) 
                    {
                        int intRowCount;
                        
                        for (intRowCount = 0; (intRowCount <= (ds.Tables[12].Rows.Count - 1)); intRowCount++) 
                                    
                        {
                            if ((ds.Tables[12].Rows[intRowCount]["Function_Name"] == "Site Planning")) 
                            {
                                if (!(ds.Tables[12].Rows[intRowCount]["Approver_Name"] == System.DBNull.Value)) 
                                {
                                    ViewState["SitePlanner"] = ds.Tables[12].Rows[intRowCount]["Approver_Name"].ToString().Trim();
                                }
                                else {
                                    ViewState["SitePlanner"] = String.Empty;
                                }
                            }
                            if ((ds.Tables[12].Rows[intRowCount]["Function_Name"] == "Site Contact")) 
                            {
                                if (!(ds.Tables[12].Rows[intRowCount]["Approver_Name"] == System.DBNull.Value)) 
                                {
                                    ViewState["SiteContact"] = ds.Tables[12].Rows[intRowCount]["Approver_Name"].ToString().Trim();
                                }
                                else {
                                    ViewState["SiteContact"] = String.Empty;
                                }
                            }
                        }
                    }
                }
            }
            // TO send mail after All the approvers approve
            string appName;
            string senderName = string.Empty;
            int intPosition;
            try {
                if (!(ViewState["Originator"] == null))
                {
                    appName = ViewState["Originator"].ToString().Trim();
                    intPosition = appName.IndexOf(" ");
                    appName = appName.Substring(intPosition);
                    appName = appName.Replace("-", ".");
                    senderName = (appName + "@pg.com");
                }
            }
            catch (Exception ex) {
            }
            string fromName = string.Empty;
            string decFromName = string.Empty; ;
            int intPos;
            try {
                if (!(strmailfrom == "")) {
                    fromName = strmailfrom;
                    intPos = fromName.IndexOf(" ");
                    fromName = fromName.Substring(intPos);
                    fromName = fromName.Replace("-", ".");
                    decFromName = (fromName + "@pg.com");
                }
            }
            catch (Exception ex) {
            }
            try {
                string strURLLockMode;
                strURLLockMode = ("http://" + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                string strURLEditMode;
                strURLEditMode = ("http://" 
                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
               //  EOBA objEOBABA = new EOBA();
                
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = senderName;
                objSendMail.SendFrom = decFromName;
                objSendMail.MailSubject = ("The " 
                            + (Request.QueryString["EoStage"] + (" stage for the following EO Request has been approved.EO Number - " 
                            + (ViewState["EONum"].ToString().Trim() + (" Title - " + ViewState["EOTitle"])))));
                string strTotCost = "";
                if (ViewState["TotCost"] != null)
                    strTotCost = ViewState["TotCost"].ToString().Trim();
               

                objSendMail.MailBody = ("<br>" + ("<br>" + ("Dear " 
                            + (ViewState["Originator"] + ("," + ("<br>" + ("<br>" + ("The " 
                            + (Request.QueryString["EoStage"] + (" stage for the following EO Request has been approved. Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE: This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'" 
                            + (strURLLockMode + ("\'>" 
                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("EO Number is :" 
                            + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("SAP IO Number :" 
                            + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearance Number :" 
                            + (ViewState["SmartClearanceNum"] + ("<br>" + ("EO Title is  :" 
                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :" 
                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :" 
                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                            + (strTotCost + ("<br>" + ("Current Stage  :" 
                            + (ViewState["stage"] + ("<br>" + ("<br>" + ("Thank you," + ("<br>" 
                            + (Security.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))));
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend) 
                
                {
                    if (objEOBABA.addingMailDetails(objSendMail.SendFrom, objSendMail.SendTo, objSendMail.SendCCTo, objSendMail.SendBCCTo, objSendMail.MailSubject, "MailAfterAllApprove", ""))
                    {
                    }

                }
                // Dim objMail As New MailMessage
                // objMail.To = senderName
                // objMail.From = decFromName
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Subject = "The " & Request.QueryString("EoStage") & " stage for the following EO Request has been approved.EO Number - " & ViewState["EONum") & " Title - " & ViewState["EOTitle")
                // objMail.Body = "<br>" & "<br>" & "Dear " & ViewState["Originator") & "," & "<br>" & "<br>" & "The " & Request.QueryString("EoStage") & " stage for the following EO Request has been approved. Please follow the link to see this EO." & "<br>" & "<br>" & "NOTE: This link will open the EO in 'Read Only' Mode." & "<br>" & "<br><a href='" & strURLLockMode & "'>" & strURLLockMode & "</a><br>" & "<br>" & "<br>" & "EO Number is :" & ViewState["EONum") & "<br>" & "SAP IO Number :" & ViewState["SAPIONum") & "<br>" & "EO Title is  :" & ViewState["EOTitle") & "<br>" & "EO Location :" & ViewState["PlantName") & "<br>" & "Budget Center :" & ViewState["BudgetCenter") & "<br>" & "Expected Cost : $" & ViewState["TotCost") & "<br>" & "Current Stage  :" & ViewState["stage") & "<br>" & "<br>" & "Thank you," & "<br>" & Security.UserName & "."
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP") '"clev.vertexcs.com"
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "MailAfterAllApprove", "")
            }
            catch (Exception ex) {
            }
            // For data co ordinators
            string strDataCoordinatorName;
                
            try {
                if (objEOBABA.GET_EO_Data_Coordinator_By_Category(ViewState["CategoryID"].ToString().Trim(), ref ds))
                {
                    if (!(ds == null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows.Count == 0))
                            {
                                strDataCoordinatorName = ds.Tables[0].Rows[0]["Data_Coordinator_Name"].ToString().Trim();
                            }
                        }
                    }
                }
              
            }
            catch (Exception ex) {
            }
            DataSet dsFYIAppNames = null;
            int intFYIAppCount;
            string strFYIAppNamesList = string.Empty;
            string strFYIAppNamesListPGMailName = string.Empty;
            if (objEOBABA.GET_EO_FYI_Recipient_Approvers(Convert.ToInt32(ViewState["PlantID"].ToString().Trim()), Convert.ToInt32(ViewState["CategoryID"].ToString().Trim()), ref paramOut))
                {
                    if (!(dsFYIAppNames == null))
                    {
                        if (!(dsFYIAppNames.Tables.Count == 0))
                        {
                            if (!(dsFYIAppNames.Tables[0].Rows.Count == 0))
                            {
                                for (intFYIAppCount = 0; (intFYIAppCount <= (dsFYIAppNames.Tables[0].Rows.Count - 1)); intFYIAppCount++)
                                {
                                    if (!(dsFYIAppNames.Tables[0].Rows[intFYIAppCount]["Approver_Name"].ToString().Trim() == ""))
                                    {
                                        strFYIAppNamesListPGMailName = dsFYIAppNames.Tables[0].Rows[intFYIAppCount]["Approver_Name"].ToString().Trim();
                                        intPosition = strFYIAppNamesListPGMailName.IndexOf(" ");
                                        strFYIAppNamesListPGMailName = strFYIAppNamesListPGMailName.Substring(intPosition);
                                        strFYIAppNamesListPGMailName = strFYIAppNamesListPGMailName.Replace("-", ".");
                                        strFYIAppNamesListPGMailName = (strFYIAppNamesListPGMailName + "@pg.com");
                                        if ((strFYIAppNamesList == ""))
                                        {
                                            strFYIAppNamesList = strFYIAppNamesListPGMailName;
                                        }
                                        else
                                        {
                                            strFYIAppNamesList = (strFYIAppNamesList + (";" + strFYIAppNamesListPGMailName));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
 
            // 'Other FYI mail content
            try 
            {
                string strURLLockMode;
                strURLLockMode = ("http://" + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                string strURLEditMode;
                strURLEditMode = ("http://" + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = senderName;
                objSendMail.SendFrom = senderName;
                objSendMail.SendCCTo = strFYIAppNamesList;
                objSendMail.MailSubject = ("The " + (Request.QueryString["EoStage"] + (" stage of your EO Request has been approved.EO Number - " + (ViewState["EONum"].ToString().Trim() + (" Title - " + ViewState["EOTitle"])))));
                string strTotCost = "";
                if (ViewState["TotCost"] != null)
                    strTotCost = ViewState["TotCost"].ToString().Trim();
                objSendMail.MailBody = ("<br>" + ("<br>" + ("Dear " 
                            + (ViewState["Originator"] + ("," + ("<br>" + ("<br>" + ("The " 
                            + (Request.QueryString["EoStage"] + (" stage of your EO Request has been approved. Please follow the link to see this EO." + ("<br>" + ("<br><a href=\'" 
                            + (strURLEditMode + ("\'>" 
                            + (strURLEditMode + ("</a><br>" + ("<br>" + ("NOTE: This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'" 
                            + (strURLLockMode + ("\'>" 
                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("EO Number is :" 
                            + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("SAP IO Number :" 
                            + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearance Number :" 
                            + (ViewState["SmartClearanceNum"] + ("<br>" + ("EO Title is  :" 
                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :" 
                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :" 
                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                            + (strTotCost + ("<br>" + ("Current Stage  :" 
                            + (ViewState["stage"] + ("<br>" + ("<br>" + ("Thank you," + ("<br>" 
                            + (Security.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))))))))));
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend) 
                {
                    if (objEOBABA.addingMailDetails(objSendMail.SendFrom, objSendMail.SendTo, objSendMail.SendCCTo, objSendMail.SendBCCTo, objSendMail.MailSubject, "Other_FYI_Mail", ""))
                    {

                    }
                }
                // Dim objMail As New MailMessage
                // objMail.To = senderName
                // objMail.From = senderName
                // objMail.Cc = strFYIAppNamesList
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Subject = "The " & Request.QueryString("EoStage") & " stage of your EO Request has been approved.EO Number - " & ViewState["EONum") & " Title - " & ViewState["EOTitle")
                // objMail.Body = "<br>" & "<br>" & "Dear " & ViewState["Originator") & "," & "<br>" & "<br>" & "The " & Request.QueryString("EoStage") & " stage of your EO Request has been approved. Please follow the link to see this EO." & "<br>" & "<br><a href='" & strURLEditMode & "'>" & strURLEditMode & "</a><br>" & "<br>" & "NOTE: This link will open the EO in 'Read Only' Mode." & "<br>" & "<br><a href='" & strURLLockMode & "'>" & strURLLockMode & "</a><br>" & "<br>" & "<br>" & "EO Number is :" & ViewState["EONum") & "<br>" & "SAP IO Number :" & ViewState["SAPIONum") & "<br>" & "EO Title is  :" & ViewState["EOTitle") & "<br>" & "EO Location :" & ViewState["PlantName") & "<br>" & "Budget Center :" & ViewState["BudgetCenter") & "<br>" & "Expected Cost : $" & ViewState["TotCost") & "<br>" & "Current Stage  :" & ViewState["stage") & "<br>" & "<br>" & "Thank you," & "<br>" & Security.UserName & "."
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP")
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "Other_FYI_Mail", "")
            }
            catch (Exception ex) 
            {
            }
            // 'Purchasing contacts mail.
            try 
            {
                string strURLLockMode;
                strURLLockMode = ("http://" 
                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"].ToString().Trim())));
                string strURLEditMode;
                strURLEditMode = ("http://" 
                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"].ToString().Trim())));
                MailMessage objMail = new MailMessage();
                DataSet dsDistributionList = null;
                ChangeDistributionBO objDistributionList = new ChangeDistributionBO();
                string strCCEOMail = string.Empty;
                string strMDCMail = string.Empty;
                string strPCMail = string.Empty;
                string strAS = string.Empty;
                string strCCEO = string.Empty;
                string strMDC = string.Empty;
                string strPC = string.Empty;
            
                    if(objDistributionList.GET_EO_OnRoute_FYI_Distribution_List( ref  dsDistributionList))
                    {
                        if (!(dsDistributionList == null))
                        {
                            if (!(dsDistributionList.Tables.Count == 0))
                            {
                                if (!(dsDistributionList.Tables[0].Rows.Count == 0))
                                {
                                    strCCEOMail = dsDistributionList.Tables[0].Rows[0]["FYI_Mail_ID"].ToString().Trim();
                                    strMDCMail = dsDistributionList.Tables[0].Rows[1]["FYI_Mail_ID"].ToString().Trim();
                                    strPCMail = dsDistributionList.Tables[0].Rows[2]["FYI_Mail_ID"].ToString().Trim();
                                    strCCEO = dsDistributionList.Tables[0].Rows[0]["FYI_USer_Name"].ToString().Trim();
                                    strMDC = dsDistributionList.Tables[0].Rows[1]["FYI_USer_Name"].ToString().Trim();
                                    strPC = dsDistributionList.Tables[0].Rows[2]["FYI_USer_Name"].ToString().Trim();
                                    strAS = dsDistributionList.Tables[0].Rows[3]["FYI_USer_Name"].ToString().Trim();
                                }
                            }
                        }
                    }
   
                clsSendMail objSendMail = new clsSendMail();
                //objSendMail.SendTo = (senderName + (";" 
                //            + (strCCEOMail + (";" 
                //            + (strMDCMail + (";" + strPCMail))))));
                //objSendMail.SendFrom = senderName;
                objSendMail.SendTo = senderName;
                objSendMail.SendFrom = senderName;
                objSendMail.MailSubject = ("The " 
                            + (Request.QueryString["EoStage"] + (" stage for the following EO Request has been approved.EO Number - " 
                            + (ViewState["EONum"].ToString().Trim() + (" Title - " + ViewState["EOTitle"].ToString().Trim())))));
                string strTotCost = "";
                if (ViewState["TotCost"] != null)
                    strTotCost = ViewState["TotCost"].ToString().Trim();
                objSendMail.MailBody = ("<br>" + ("<br>" + ("Dear " 
                            + (ViewState["Originator"].ToString().Trim() + ("," + ("<br>" + ("<br>" + ("The " 
                            + (Request.QueryString["EoStage"] + (" stage for the following EO Request has been approved. Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE: This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'" 
                            + (strURLLockMode + ("\'>" 
                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("EO Number is :" 
                            + (ViewState["EONum"].ToString().Trim().ToString().Trim() + ("<br>" + ("SAP IO Number :" 
                            + (ViewState["SAPIONum"].ToString().Trim() + ("<br>" + ("Smart Clearance Number :" 
                            + (ViewState["SmartClearanceNum"].ToString().Trim() + ("<br>" + ("EO Title is  :" 
                            + (ViewState["EOTitle"].ToString().Trim() + ("<br>" + ("EO Location :" 
                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :" 
                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                            + (strTotCost + ("<br>" + ("Current Stage  :" 
                            + (ViewState["stage"] + ("<br>" + ("Site Planner :" 
                            + (ViewState["SitePlanner"] + ("<br>" + ("Analytical Services :" 
                            + (strAS + ("<br>" + ("Purchasing Contact for EO:" 
                            + (strPC + ("<br>" + ("Site Contact :" 
                            + (ViewState["SiteContact"] + ("<br>" + ("Master Data Coordinator :" 
                            + (strMDC + ("<br>" + ("Thank you," + ("<br>" 
                            + (Security.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))));
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend) 
                {
                    if (objEOBABA.addingMailDetails(objSendMail.SendFrom, objSendMail.SendTo, objSendMail.SendCCTo, objSendMail.SendBCCTo, objSendMail.MailSubject, "Purchasing_contacts_mail", ""))
                    {
                    }
                }
                // objMail.To = senderName & ";" & strCCEOMail & ";" & strMDCMail & ";" & strPCMail
                // objMail.From = senderName
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Subject = "The " & Request.QueryString("EoStage") & " stage for the following EO Request has been approved.EO Number - " & ViewState["EONum") & " Title - " & ViewState["EOTitle")
                // 'objMail.Body = "<br>" & "<br>" & "Dear " & ViewState["Originator") & "," & "<br>" & "<br>" & "The " & Request.QueryString("EoStage") & " stage for the following EO Request has been approved. Please follow the link to see this EO." & "<br>" & "<br>" & "NOTE: This link will open the EO in 'Read Only' Mode." & "<br>" & "<br><a href='" & strURLLockMode & "'>" & strURLLockMode & "</a><br>" & "<br>" & "<br>" & "EO Number is :" & ViewState["EONum") & "<br>" & "SAP IO Number :" & ViewState["SAPIONum") & "<br>" & "EO Title is  :" & ViewState["EOTitle") & "<br>" & "EO Location :" & ViewState["PlantName") & "<br>" & "Budget Center :" & ViewState["BudgetCenter") & "<br>" & "Expected Cost : $" & ViewState["TotCost") & "<br>" & "Current Stage  :" & ViewState["stage") & "<br>" & "Site Planner :" & ViewState["SitePlanner") & "<br>" & "Analytical Services :" & ConfigurationSettings.AppSettings("AnalyticalServices") & "<br>" & "Purchasing Contact for EO:" & ConfigurationSettings.AppSettings("PurchasingContacts") & "<br>" & "Site Contact :" & ViewState["SiteContact") & "<br>" & "Master Data Coordinator :" & ConfigurationSettings.AppSettings("MasterDataCoordinator") & "<br>" & "Thank you," & "<br>" & Security.UserName & "."
                // objMail.Body = "<br>" & "<br>" & "Dear " & ViewState["Originator") & "," & "<br>" & "<br>" & "The " & Request.QueryString("EoStage") & " stage for the following EO Request has been approved. Please follow the link to see this EO." & "<br>" & "<br>" & "NOTE: This link will open the EO in 'Read Only' Mode." & "<br>" & "<br><a href='" & strURLLockMode & "'>" & strURLLockMode & "</a><br>" & "<br>" & "<br>" & "EO Number is :" & ViewState["EONum") & "<br>" & "SAP IO Number :" & ViewState["SAPIONum") & "<br>" & "EO Title is  :" & ViewState["EOTitle") & "<br>" & "EO Location :" & ViewState["PlantName") & "<br>" & "Budget Center :" & ViewState["BudgetCenter") & "<br>" & "Expected Cost : $" & ViewState["TotCost") & "<br>" & "Current Stage  :" & ViewState["stage") & "<br>" & "Site Planner :" & ViewState["SitePlanner") & "<br>" & "Analytical Services :" & strAS & "<br>" & "Purchasing Contact for EO:" & strPC & "<br>" & "Site Contact :" & ViewState["SiteContact") & "<br>" & "Master Data Coordinator :" & strMDC & "<br>" & "Thank you," & "<br>" & Security.UserName & "."
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP")
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "Purchasing_contacts_mail", "")
            }
            catch (Exception ex) {
            }
        }



    }

        private void sendDeclineMail(string strmailfrom)
        {
            DataSet ds = null;
            DataSet dscloseout = null;
            DataSet dsFinal = null;
            EOBA objEOBABA = new EOBA();
            clsSecurity Security = new clsSecurity();

            if (objEOBABA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
            {
                ViewState["EOID"] = Request.QueryString["EOID"];
                if (!(ds == null))
                {
                    if (!(ds.Tables.Count == 0))
                    {
                        if (!(ds.Tables[0].Rows.Count == 0))
                        {
                            if (!(ds.Tables[0].Rows[0]["EO_Number"] == System.DBNull.Value))
                            {
                                ViewState["EONum"] = ds.Tables[0].Rows[0]["EO_Number"].ToString();
                            }
                            else
                            {
                                ViewState["EONum"] = "New EO";
                            }
                            // Added on 05/14/2010 for Smart Clearance #
                            if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                            {
                                ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString();
                            }
                            else
                            {
                                ViewState["SmartClearanceNum"] = "Not Assigned";
                            }
                            if (!(ds.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                            {
                                ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                            }
                            else
                            {
                                ViewState["SAPIONum"] = "Not Assigned";
                            }
                            // Added on 01/20/2010 
                            // For MUREO PCRs
                            // By: David
                            if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                            {
                                ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim(); ;
                            }
                            else
                            {
                                ViewState["SmartClearanceNum"] = "Not Assigned";
                            }
                            if (!(ds.Tables[0].Rows[0]["Plant_Name"] == System.DBNull.Value))
                            {
                                ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"].ToString().Trim(); ;
                            }
                            else
                            {
                                ViewState["PlantName"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Current_Stage"] == System.DBNull.Value))
                            {
                                ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"];
                            }
                            else
                            {
                                ViewState["stage"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["EO_Title"] == System.DBNull.Value))
                            {
                                ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"].ToString();
                            }
                            else
                            {
                                ViewState["EOTitle"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Originator"] == System.DBNull.Value))
                            {
                                ViewState["Originator"] = ds.Tables[0].Rows[0]["Originator"];
                            }
                            else
                            {
                                ViewState["Originator"] = String.Empty;
                            }
                            if (!(ds.Tables[0].Rows[0]["Stage_Status"] == System.DBNull.Value))
                            {
                                if ((Session["Status"] == null))
                                {
                                    ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"];
                                }
                                else
                                {
                                    ViewState["Status"] = Session["Status"];
                                }
                            }
                            else
                            {
                                ViewState["Status"] = String.Empty;
                            }
                            if ((ViewState["stage"].ToString().ToUpper() == "CloseOut".ToUpper()))
                            {
                                if ((ViewState["Status"].ToString().ToUpper() == "Approved".ToUpper()))
                                {
                                    ViewState["Status"] = "Completed";
                                }
                            }
                        }
                    }
                }

            }




            if (objEOBABA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
            {
                if (!(ds == null))
                {
                    if (!(ds.Tables.Count == 0))
                    {
                        // jagan 06/01/08
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

                            if (objEOBABA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                            {
                                ViewState["TotCost"] = paramOut[0].Value.ToString().Trim();
                            }
                            // 'N' Means stage not changing.
                        }
                        catch (Exception ex)
                        {
                            ViewState["TotCost"] = "0";
                            // 'End Here
                        }
                        // end 06/01/08
                        if (!(ds.Tables[7].Rows.Count == 0))
                        {
                            if (!(ds.Tables[7].Rows[0]["Planned_Start_Date"] == System.DBNull.Value))
                            {
                                ViewState["PlannedStartDate"] = ds.Tables[7].Rows[0]["Planned_Start_Date"].ToString();
                            }
                            else
                            {
                                ViewState["PlannedStartDate"] = String.Empty;
                            }
                        }
                    }
                }
            }

            // strmailfrom()
            string appName = string.Empty;
            string senderName = string.Empty;
            string strOriginatorName = string.Empty;
            int intPosition = 0;
            try
            {
                if (!(ViewState["Originator"] == null))
                {
                    appName = ViewState["Originator"].ToString().Trim();
                    strOriginatorName = ViewState["Originator"].ToString().Trim();
                    intPosition = appName.IndexOf(" ");
                    appName = appName.Substring(intPosition);
                    appName = appName.Replace("-", ".");
                    senderName = (appName + "@pg.com");
                }
            }
            catch (Exception ex)
            {
            }
            string fromName = string.Empty;
            string decFromName = string.Empty;
            int intPos;
            try
            {
                if (!(strmailfrom == ""))
                {
                    fromName = strmailfrom;
                    intPos = fromName.IndexOf(" ");
                    fromName = fromName.Substring(intPos);
                    fromName = fromName.Replace("-", ".");
                    decFromName = (fromName + "@pg.com");
                }
            }
            catch (Exception ex)
            {
            }
            try
            {
                string strURLLockMode;
                strURLLockMode = ("http://"
                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                string strURLEditMode;
                strURLEditMode = ("http://"
                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                string strDeclineCommnets = string.Empty;
                try
                {
                    DataSet dsDecCommnets = null;
                    if (objEOBABA.getEOComments(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ref dsDecCommnets))
                    {
                        if (!(dsDecCommnets == null))
                        {
                            if (!(dsDecCommnets.Tables.Count == 0))
                            {
                                if (!(dsDecCommnets.Tables[0].Rows.Count == 0))
                                {
                                    strDeclineCommnets = dsDecCommnets.Tables[0].Rows[0]["Pre Comments"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                string strTotCost = "";
                if (ViewState["TotCost"] != null)
                    strTotCost = ViewState["TotCost"].ToString().Trim();
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = senderName;
                objSendMail.SendFrom = decFromName;
                objSendMail.MailSubject = ("The "
                            + (ViewState["stage"] + " stage of your EO Request has been returned with comments."));
                objSendMail.MailBody = ("<br>" + ("<br>" + ("Dear "
                            + (strOriginatorName + ("," + ("<br>" + ("<br>" + ("An Approver has returned your EO stage for the following reasons: " + ("<br>" + ("<br>"
                            + (strDeclineCommnets + ("<br>" + ("<br>" + ("Please follow the link to see your EO and comments." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'"
                            + (strURLLockMode + ("\'>"
                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br>" + ("<br><a href=\'"
                            + (strURLEditMode + ("\'>"
                            + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                            + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("SAP IO Number :"
                            + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearance Number :"
                            + (ViewState["SmartClearance"] + ("<br>" + ("EO Title is  :"
                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                            + (strTotCost + ("<br>" + ("Current Stage  :"
                            + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                            + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                            + (Security.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))));
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend)
                {
                    if (objEOBABA.addingMailDetails(objSendMail.SendFrom.ToString().Trim(), objSendMail.SendTo.ToString().Trim(), objSendMail.SendCCTo.ToString().Trim(), objSendMail.SendBCCTo.ToString().Trim(), objSendMail.MailSubject.ToString().Trim(), "DeclineMail", ""))
                    {

                    }
                }
                // Dim objMail As New MailMessage
                // objMail.To = senderName
                // objMail.From = decFromName
                // objMail.Subject = "The " & ViewState["stage") & " stage of your EO Request has been returned with comments."
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Body = "<br>" & "<br>" & "Dear " & strOriginatorName & "," & "<br>" & "<br>" & "An Approver has returned your EO stage for the following reasons: " & "<br>" & "<br>" & strDeclineCommnets & "<br>" & "<br>" & "Please follow the link to see your EO and comments." & "<br>" & "<br>" & "NOTE:  Use this link to open the EO in 'Read Only' Mode." & "<br>" & "<br><a href='" & strURLLockMode & "'>" & strURLLockMode & "</a><br>" & "<br>" & "NOTE:  Use this link to open the EO in 'Edit' Mode." & "<br>" & "<br><a href='" & strURLEditMode & "'>" & strURLEditMode & "</a><br>" & "<br>" & "EO Number is :" & ViewState["EONum") & "<br>" & "SAP IO Number :" & ViewState["SAPIONum") & "<br>" & "EO Title is  :" & ViewState["EOTitle") & "<br>" & "EO Location :" & ViewState["PlantName") & "<br>" & "Budget Center :" & ViewState["BudgetCenter") & "<br>" & "Expected Cost : $" & ViewState["TotCost") & "<br>" & "Current Stage  :" & ViewState["stage") & "<br><font color=red><b>" & "Proposed Testing Start Date :" & ViewState["PlannedStartDate") & "</b></font><br>" & "<br>" & "Thank you," & "<br>" & Security.UserName & "."
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP") 
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "DeclineMail", "")
            }
            catch (Exception ex)
            {
            }
        }

        private void EO_Lock_Release()
        {
            EOBA objEOBA = new EOBA();
            clsSecurity Security = new clsSecurity();
            try
            {
                if (!(ViewState["EOID"] == null))
                {
                    objEOBA.SET_EO_Lock_Release_User(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), Security.UserName.ToString().Trim());
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


        }

        private void SendMailFYI(string strFYI, string strFYIfunctionname)
        {
            try
            {
                EOBA objEOBA = new EOBA();
                clsSecurity Security = new clsSecurity();
                SqlParameter[] paramOut = null;
                int intResult = 0;
                int intRow = 0;
                // Dim dsAppList As DataSet
                string strMailIDs;
                strMailIDs = strFYI;
                string strCurrentStage;
                string strStatus;
                int intPlantID = 0;
                // Added on 01/20/2010 
                // For MUREO PCRs
                // By: David
                string strEOnum;
                string strSAPIO;
                string strSmartClearance;
                DataSet ds = null;
                DataSet dscloseout = null;
                DateTime currentDate = DateTime.Now.Date;
                DateTime nextTwoDate = DateTime.Now.Date;
                if ((DateTime.Now.DayOfWeek == 0))
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                else if ((DateTime.Now.DayOfWeek.ToString() == "6"))
                {
                    nextTwoDate = currentDate.AddDays(3);
                }
                else if ((DateTime.Now.DayOfWeek.ToString() == "5"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else if ((DateTime.Now.DayOfWeek.ToString() == "4"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                try
                {
                    ViewState["nextTwoDate"] = nextTwoDate;
                }
                catch (Exception ex)
                {
                }
                if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                {
                    ViewState["EOID"] = Request.QueryString["EOID"];
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
                                // Added on 05/14/2010 for Smart Clearance
                                // Added on 01/20/2010 
                                // For MUREO PCRs
                                // By: David
                                if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                                {
                                    strSmartClearance = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                    ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSmartClearance = "0";
                                    ViewState["SmartClearanceNum"] = "Not Assigned";
                                }
                                if (!(ds.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                                {
                                    strSAPIO = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                    ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSAPIO = "0";
                                    ViewState["SAPIONum"] = "Not Assigned";
                                }
                                if (!(ds.Tables[0].Rows[0]["Plant_Name"] == System.DBNull.Value))
                                {
                                    ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["PlantName"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["Current_Stage"] == System.DBNull.Value))
                                {
                                    strCurrentStage = ds.Tables[0].Rows[0]["Current_Stage"].ToString().Trim(); ;
                                    ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"].ToString().Trim(); ;
                                }
                                else
                                {
                                    strCurrentStage = String.Empty;
                                    ViewState["stage"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["EO_Title"] == System.DBNull.Value))
                                {
                                    ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"].ToString().Trim(); ;
                                }
                                else
                                {
                                    ViewState["EOTitle"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["Originator"] == System.DBNull.Value))
                                {
                                    ViewState["Originator"] = ds.Tables[0].Rows[0]["Originator"].ToString().Trim(); ;
                                }
                                else
                                {
                                    ViewState["Originator"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["Stage_Status"] == System.DBNull.Value))
                                {
                                    if ((Session["Status"] == null))
                                    {
                                        strStatus = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim(); ;
                                        ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim(); ;
                                    }
                                    else
                                    {
                                        strStatus = Session["Status"].ToString().Trim(); ;
                                        ViewState["Status"] = Session["Status"].ToString().Trim(); ;
                                    }
                                }
                                else
                                {
                                    strStatus = String.Empty;
                                    ViewState["Status"] = String.Empty;
                                }
                                if ((ViewState["stage"].ToString().ToUpper() == "CloseOut".ToUpper()))
                                {
                                    if ((ViewState["Status"].ToString().ToUpper() == "Approved".ToUpper()))
                                    {
                                        ViewState["Status"] = "Completed";
                                    }
                                }
                            }
                        }
                    }
                }

                if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(ViewState["EOID"]), ref ds))
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
                                        ViewState["BudgetCenter"] = ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"].ToString().Trim(); ;
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
                            // for total cost
                            try
                            {
                                // Modified by Murthy on 04-Mar-2009 reg issue the total cost should get updated
                                // 'Start here
                                if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                                {
                                    ViewState["TotCost"] = paramOut.ToString().Trim();
                                }
                                // 'N' Means stage not changing.
                            }
                            catch (Exception ex)
                            {
                                ViewState["TotCost"] = "0";
                                // 'End Here
                            }
                            if (!(ds.Tables[7].Rows.Count == 0))
                            {
                                if (!(ds.Tables[7].Rows[0]["Planned_Start_Date"] == System.DBNull.Value))
                                {
                                    ViewState["PlannedStartDate"] = ds.Tables[7].Rows[0]["Planned_Start_Date"].ToString();
                                }
                                else
                                {
                                    ViewState["PlannedStartDate"] = String.Empty;
                                }
                            }
                        }
                    }
                }
                if (!(strMailIDs == ""))
                {
                    int intPosition;
                    int i;
                    int intPosOriginator;
                    string appName;
                    string senderName;
                    string PosOriginator;
                    string appfunname;
                    string strOriginator;
                    string[] strMailIDs1 = null;
                    string[] arrstrFYIfunctionname = null;
                    strMailIDs1 = strMailIDs.Split(';');
                    arrstrFYIfunctionname = strFYIfunctionname.Split(';');
                    for (i = 0; (i
                                <= (strMailIDs1.Length - 1)); i++)
                    {
                        if ((arrstrFYIfunctionname[i] == "QA"))
                        {
                            arrstrFYIfunctionname[i] = "Site QA";
                        }
                        appName = strMailIDs1[i];
                        try
                        {
                            intPosition = appName.IndexOf(" ");
                            appName = appName.Substring(intPosition);
                            appName = appName.Replace("-", ".");
                        }
                        catch (Exception ex)
                        {
                        }
                        senderName = appName;
                        senderName = (senderName + "@pg.com");
                        try
                        {
                            string strURLLockMode;
                            // strURLLockMode = "http://" & ViewState["servername") & "/MUREO/Common/NewEO.aspx?From=ForEOLock&EOID=" & ViewState["EOID"]
                            strURLLockMode = ("http://"
                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&For=FYI&EOID=" + ViewState["EOID"])));
                            string strURLEditMode;
                            strURLEditMode = ("http://"
                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                            string strTotCost = "";
                            if (ViewState["TotCost"] != null)
                                strTotCost = ViewState["TotCost"].ToString().Trim();
                            SendMailFYI(senderName, ("Please Review by "
                                            + (ViewState["nextTwoDate"] + (". EO Number - "
                                            + (ViewState["EONum"].ToString().Trim() + (" - " + ViewState["EOTitle"]))))), ("<br>" + ("<br>" + ("Dear "
                                            + (arrstrFYIfunctionname[i] + (" (FYI ONLY)," + ("<br>" + ("<br>" + ("You are receiving this link as an FYI.  Please communicate any issues with the proposed timing of thi" +
                                            "s EO to the originator." + ("<br>" + ("<br>" + ("Please follow the link below to review this EO" + ("<br>" + ("<br>" + ("NOTE:  This link will open the EO in 'Read Only' Mode." + ("<br>" + ("<br><a href=\'"
                                            + (strURLLockMode + ("\'>"
                                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("<br>" + ("<br>" + ("EO Number is :"
                                            + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("SAP IO Number :"
                                            + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearance Number :"
                                            + (ViewState["SmartClearanceNum"].ToString().Trim() + ("<br>" + ("EO Title is  :"
                                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                            + (strTotCost + ("<br>" + ("Current Stage  :"
                                            + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                            + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                            + (Security.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))))))))))));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SendMail(string strNames, string strAppfunctionname)
        {
            try
            {
                EOBA objEOBA = new EOBA();
                clsSecurity Security = new clsSecurity();
                SqlParameter[] paramOut = null;
                int intResult;
                int intRow;
                // Dim dsAppList As DataSet
                string strMailIDs =  null;
                strMailIDs = strNames;
                string strCurrentStage;
                string strStatus;
                int intPlantID;
                // Added on 01/20/2010 
                // For MUREO PCRs
                // By: David
                string strEOnum;
                string strSAPIO;
                string strSmartClearance;
                DataSet ds = null;
                DataSet dscloseout;
                // For mail date to add 2 business days to current date
                DateTime currentDate = DateTime.Now.Date;
                DateTime nextTwoDate = DateTime.Now.Date;
                if ((DateTime.Now.DayOfWeek == 0))
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                else if ((DateTime.Now.DayOfWeek.ToString().Trim() == "6"))
                {
                    nextTwoDate = currentDate.AddDays(3);
                }
                else if ((DateTime.Now.DayOfWeek.ToString().Trim() == "5"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else if ((DateTime.Now.DayOfWeek.ToString().Trim() == "4"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                try
                {
                    ViewState["nextTwoDate"] = nextTwoDate;
                }
                catch (Exception ex)
                {
                }
                if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), ref ds))
                {
                    ViewState["EOID"] = Request.QueryString["EOID"];
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
                                if (!(ds.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                                {
                                    strSAPIO = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                    ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSAPIO = "0";
                                    ViewState["SAPIONum"] = "Not Assigned";
                                }
                                // Added on 01/20/2010 
                                // For MUREO PCRs
                                // By: David
                                if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                                {
                                    strSmartClearance = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                    ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSmartClearance = "0";
                                    ViewState["SmartClearanceNum"] = "Not Assigned";
                                }
                                if (!(ds.Tables[0].Rows[0]["Plant_Name"] == System.DBNull.Value))
                                {
                                    ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["PlantName"] = String.Empty;
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
                                if (!(ds.Tables[0].Rows[0]["Stage_Status"] == System.DBNull.Value))
                                {
                                    if ((Session["Status"] == null))
                                    {
                                        strStatus = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim();
                                        ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"].ToString().Trim();
                                    }
                                    else
                                    {
                                        strStatus = Session["Status"].ToString().Trim(); ;
                                        ViewState["Status"] = Session["Status"];
                                    }
                                }
                                else
                                {
                                    strStatus = String.Empty;
                                    ViewState["Status"] = String.Empty;
                                }
                                if ((ViewState["stage"].ToString().Trim().ToUpper() == "CloseOut".ToUpper()))
                                {
                                    if ((ViewState["Status"].ToString().Trim().ToUpper() == "Approved".ToUpper()))
                                    {
                                        ViewState["Status"] = "Completed";
                                    }
                                }
                            }
                        }
                    }
                }

                //  ds = objEOBA.GET_EO_Preliminary(ViewState["EOID"]);

                if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ref ds))
                {

                    if (!(ds == null))
                    {
                        try
                        {
                            if (!(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] == System.DBNull.Value))
                            {
                                if ((ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] == "-- Select Budget Center --"))
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

                            if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                            {
                                ViewState["TotCost"] = paramOut.ToString().Trim();

                            }
                            // 'N' Means stage not changing.
                        }
                        catch (Exception ex)
                        {
                            ViewState["TotCost"] = "0";
                            // 'End Here
                        }
                        if (!(ds.Tables.Count == 0))
                        {
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

                if (!(strMailIDs == ""))
                {
                    int intPosition;
                    int i;
                    int intPosOriginator;
                    string appName;
                    string senderName;
                    string PosOriginator;
                    string appfunname = string.Empty;
                    string strOriginator = string.Empty;
                    string[] strMailIDs1 = null;
                    string[] arrstrAppfunctionname = null;
                    strMailIDs1 = strMailIDs.Split(';');
                    arrstrAppfunctionname = strAppfunctionname.Split(';');
                    for (i = 0; (i <= (strMailIDs1.Length - 1)); i++)
                    {
                        if ((arrstrAppfunctionname[i] == "QA"))
                        {
                            arrstrAppfunctionname[i] = "Site QA";
                        }
                        appName = strMailIDs1[i];
                        try
                        {
                            intPosition = appName.IndexOf(" ");
                            appName = appName.Substring(intPosition);
                            appName = appName.Replace("-", ".");
                        }
                        catch (Exception ex)
                        {
                        }
                        senderName = appName;
                        senderName = (senderName + "@pg.com");
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

                            if (ViewState["TotCost"] == null)
                                ViewState["TotCost"] = "";
                            string strTotCost = "";
                            if (ViewState["TotCost"] != null)
                                strTotCost = ViewState["TotCost"].ToString().Trim();
                            SendMail(senderName, ("Please Review by "
                                            + (ViewState["nextTwoDate"] + (". EO Number - "
                                            + (ViewState["EONum"].ToString().Trim() + (" - " + ViewState["EOTitle"]))))), ("Dear "
                                            + (arrstrAppfunctionname[i] + (" Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'"
                                            + (strURLLockMode + ("\'>"
                                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br>" + ("<br><a href=\'"
                                            + (strURLEditMode + ("\'>"
                                            + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                            + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("SAP IO Number :"
                                            + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearance Number :"
                                            + (ViewState["SmartClearanceNum"] + ("<br>" + ("EO Title is  :"
                                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                            + (strTotCost + ("<br>" + ("Current Stage  :"
                                            + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                            + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                            + (Security.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))))))))))));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SendMail(string strApprName, string strSubject, string strBody)
        {
            int intPosition;
            int i;
            int intPosOriginator;
            string appName = string.Empty;
            string senderName = string.Empty;
            string PosOriginator = string.Empty;
            string appfunname = string.Empty;
            EOBA objEOBA = new EOBA();
            clsSecurity Security = new clsSecurity();
            SqlParameter[] paramOut = null;
            // Try
            //     intPosition = strApprName.IndexOf(" ")
            //     appName = strApprName.Substring(intPosition + 1)
            //     appName = appName.Replace("-", ".")
            //     senderName = appName
            //     senderName = senderName + "@pg.com"
            // Catch ex As Exception
            // End Try
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
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = strApprName;
                objSendMail.SendFrom = (PosOriginator + "@pg.com");
                objSendMail.MailSubject = strSubject;
                objSendMail.MailBody = strBody;
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend)
                {
                    if (objEOBA.addingMailDetails(objSendMail.SendFrom.ToString().Trim(), objSendMail.SendTo.ToString().Trim(), objSendMail.SendCCTo.ToString().Trim(), objSendMail.SendBCCTo.ToString().Trim(), objSendMail.MailSubject.ToString().Trim(), "ApproveMail", ""))
                    {

                    }
                }
                // Dim objMail As New MailMessage
                // objMail.To = strApprName
                // objMail.From = PosOriginator & "@pg.com"
                // objMail.Subject = strSubject
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Body = strBody
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP") '"clev.vertexcs.com"
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "ApproveMail", "")
            }
            catch (Exception ex)
            {
            }
            // Next
        }

        private void SendMail2tab(string strApprName, string strSubject, string strBody)
        {
            EOBA objEOBA = new EOBA();
            SqlParameter[] paramOut = null;
            int intPosition;
            int i;
            int intPosOriginator;
            string appName = "";
            string senderName = "";
            string PosOriginator = "";
            string appfunname = "";
            try
            {
                intPosition = strApprName.IndexOf(" ");
                appName = strApprName.Substring((intPosition + 1));
                appName = appName.Replace("-", ".");
                senderName = appName;
                senderName = (senderName + "@pg.com");
            }
            catch (Exception ex)
            {
            }
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
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = senderName.ToString().Trim();
                objSendMail.SendFrom = (PosOriginator + "@pg.com");
                objSendMail.MailSubject = strSubject;
                objSendMail.MailBody = strBody;
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend)
                {
                    if (objEOBA.addingMailDetails(objSendMail.SendFrom, objSendMail.SendTo, objSendMail.SendCCTo, objSendMail.SendBCCTo, objSendMail.MailSubject, "ApproveMail_2tab_Route", ""))
                    {

                    }

                }
                // Dim objMail As New MailMessage
                // objMail.To = senderName
                // objMail.From = PosOriginator & "@pg.com"
                // objMail.Subject = strSubject
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Body = strBody
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP") '"clev.vertexcs.com"
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "ApproveMail_2tab_Route", "")
            }
            catch (Exception ex)
            {
            }
            // Next
        }

        private void SendMailFYI(string strApprName, string strSubject, string strBody)
        {
            int intPosOriginator;
            string PosOriginator = "";
            EOBA objEOBA = new EOBA();
            SqlParameter[] paramOut = null;
            // Dim intPosOriginator As Integer
            // Dim appName, senderName, PosOriginator As String
            // Dim strOriginator As String
            // Dim strMailIDs() As String
            // strMailIDs = Split(strApprName, ";")
            // For i = 0 To strMailIDs.Length - 1
            //     appName = strMailIDs(i)
            //     Try
            //         intPosition = appName.IndexOf(" ")
            //         appName = appName.Substring(intPosition)
            //         appName = appName.Replace("-", ".")
            //     Catch ex As Exception
            //     End Try
            //     senderName = appName
            //     senderName = senderName + "@pg.com"
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
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = strApprName;
                objSendMail.SendFrom = (PosOriginator + "@pg.com");
                objSendMail.MailSubject = strSubject;
                objSendMail.MailBody = strBody;
                bool IsMailSend;
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend)
                {
                    if (objEOBA.addingMailDetails(objSendMail.SendFrom, objSendMail.SendTo, objSendMail.SendCCTo, objSendMail.SendBCCTo, objSendMail.MailSubject, "FYI_Mail", ""))
                    {

                    }
                }
                // Dim objMail As New MailMessage
                // objMail.To = strApprName
                // objMail.From = PosOriginator & "@pg.com"
                // objMail.Subject = strSubject
                // objMail.BodyFormat = MailFormat.Html
                // objMail.Body = strBody
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP") '"clev.vertexcs.com"
                // SmtpMail.Send(objMail)
                // objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "FYI_Mail", "")
            }
            catch (Exception ex)
            {
            }
            // Next
        }

        private void mandataroinfoforEmail()
        {
            EOBA objEOBA = new EOBA();
            SqlParameter[] paramOut = null;
            DataSet ds = null;
            try
            {
                string strCurrentStage;
                string strStatus;
                int intPlantID;
                string strEOnum;
                string strSAPIO;
                string strSmartClearance;
                // For mail date to add 2 business days to current date
                DateTime currentDate = DateTime.Now.Date;
                DateTime nextTwoDate = DateTime.Now.Date;
                if ((DateTime.Now.DayOfWeek.ToString().Trim() == "0"))
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                else if ((DateTime.Now.DayOfWeek.ToString().Trim() == "6"))
                {
                    nextTwoDate = currentDate.AddDays(3);
                }
                else if ((DateTime.Now.DayOfWeek.ToString().Trim() == "5"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else if ((DateTime.Now.DayOfWeek.ToString().Trim() == "4"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                try
                {
                    ViewState["nextTwoDate"] = nextTwoDate;
                }
                catch (Exception ex)
                {
                }
                if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), ref ds))
                {
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
                                    strEOnum = "New EO";
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
                                // CoOriginator
                                if (!(ds.Tables[0].Rows[0]["CoOriginator"] == System.DBNull.Value))
                                {
                                    ViewState["CoOriginator"] = ds.Tables[0].Rows[0]["CoOriginator"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["CoOriginator"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                                {
                                    strSAPIO = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                    ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSAPIO = "Not Assigned";
                                    ViewState["SAPIONum"] = "Not Assigned";
                                }
                                // Added on 01/20/2010 
                                // For MUREO PCRs
                                // By: David
                                if (!(ds.Tables[0].Rows[0]["SMART_Clearance_Number"] == System.DBNull.Value))
                                {
                                    strSmartClearance = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                    ViewState["SmartClearanceNum"] = ds.Tables[0].Rows[0]["SMART_Clearance_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSmartClearance = "Not Assigned";
                                    ViewState["SmartClearanceNum"] = "Not Assigned";
                                }
                                if (!(ds.Tables[0].Rows[0]["Plant_Name"] == System.DBNull.Value))
                                {
                                    ViewState["PlantName"] = ds.Tables[0].Rows[0]["Plant_Name"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["PlantName"] = String.Empty;
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
                                if ((ViewState["stage"].ToString().ToUpper() == "CloseOut".ToUpper()))
                                {
                                    if ((ViewState["Status"].ToString().ToUpper() == "Approved".ToUpper()))
                                    {
                                        ViewState["Status"] = "Completed";
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }

            if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), ref ds))
            {

                if (!(ds == null))
                {
                    if (!(ds.Tables.Count == 0))
                    {
                        // jagan 06/01/08
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

                            if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                            {
                                ViewState["TotCost"] = paramOut;
                            }
                            // 'N' Means stage not changing.
                        }
                        catch (Exception ex)
                        {
                            ViewState["TotCost"] = "0";
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
                        if (!(ds.Tables[12].Rows.Count == 0))
                        {
                            int intRowCount;
                            for (intRowCount = 0; (intRowCount <= (ds.Tables[12].Rows.Count - 1)); intRowCount++)
                            {
                                if (!(ds.Tables[12].Rows[intRowCount]["Function_Name"] == System.DBNull.Value))
                                {
                                    if ((ds.Tables[12].Rows[intRowCount]["Function_Name"].ToString().Trim() == "Site Planning"))
                                    {
                                        if (!(ds.Tables[12].Rows[intRowCount]["Approver_Name"] == System.DBNull.Value))
                                        {
                                            ViewState["SitePlanning"] = ds.Tables[12].Rows[intRowCount]["Approver_Name"].ToString().Trim();
                                        }
                                        else
                                        {
                                            ViewState["SitePlanning"] = String.Empty;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            EOBA objEOBA = new EOBA();
            clsSecurity Security = new clsSecurity();
            SqlParameter[] paramOut = null;
            string checkSmartVal;
            checkSmartVal = "Yes";
            if ((Session["btn_click"] != null) && (Session["btn_click"].ToString() == "YES"))
            {
                Session["btn_click"] = "NO";
                string script = string.Empty;
                try
                {
                    if (!(Request.QueryString["EOID"] == null))
                    {
                        if (((Request.QueryString["appStatus"].ToString() == "N")
                                    && (txtCommnets.Text.ToString().Trim() == "")))
                        {
                            Session["btn_click"] = "YES";
                            script = "<script>alert('Please enter comments');</script>";
                            //ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                            return;
                        }
                        if (!(txtCommnets.Text.ToString().Trim() == ""))
                        {
                            // Dim objClsEO As New ClsEO

                            if (objEOBA.addEOCommentsTest(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), txtCommnets.Text.ToString().Trim(), Security.UserName, ref paramOut))
                            {

                            }
                        }

                        int intResult;
                        int intRow;
                        DataSet dsAppList = null;
                        string strNames = string.Empty;
                        string strFYI = string.Empty;
                        string strAppfunctionname = string.Empty;
                        string strFYIfunctionname = string.Empty;
                        if ((Request.QueryString["appFunName"].ToString() == "GBU HS_E Resource"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "GBU HS&E Resource", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                {


                                }

                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {
                                  
                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                sendDeclineMail(Security.UserName);

                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "GBU HS&E Resource", Security.UserName, 'Y', "", ref dsAppList, ref paramOut))
                                {

                                    // script = "<script>alert('approval is successfully completed');</script> "
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    EO_Lock_Release();
                                    if (UserAgent.Contains("MSIE"))
                                    {
                                        script = "<script>";
                                        script = (script + "window.returnValue = \'T\';");
                                        script = (script + "window.close();</script>");
                                    }
                                    else
                                    {

                                        script = "<script>";
                                        script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                    }
                                }
                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "SAP Cost Center Coordinator"))
                        {
                            try
                            {
                                if (objEOBA.SET_SAP_IO_Number(int.Parse(Request.QueryString["EOID"]), txtSAPIO.Text.ToString().Trim(), ref paramOut))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "SAP Cost Center Coordinator", Security.UserName, 'N', "", ref dsAppList, ref paramOut))
                                {

                                }
                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }


                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "SAP Cost Center Coordinator", Security.UserName, 'Y', "", ref dsAppList, ref paramOut))
                                {
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    EO_Lock_Release();
                                    //script = "<script>";
                                    //script = (script + "window.returnValue = 'T';");
                                    //script = (script + "window.close();</script>");

                                    if (UserAgent.Contains("MSIE"))
                                    {
                                        script = "<script>";
                                        script = (script + "window.returnValue = 'T';");
                                        script = (script + "window.close();</script>");
                                    }
                                    else
                                    {

                                        script = "<script>";
                                        script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                    }
                                }

                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "SMART Clearance"))
                        {

                            // Added on 01/20/2010 
                            // For MUREO PCRs
                            // By: David
                            string strSmartClText;
                            string strSmartClTextTrim;
                            strSmartClText = txtSmartClearance.Text.ToString().Trim();
                            if ((strSmartClText.Length == 0))
                            {

                            }
                            else if ((strSmartClText.Length > 0))
                            {
                                if ((strSmartClText.Length < 9))
                                {

                                    script = "<script>alert('Please Enter five 9 characters of any format (number or letter) separated by a comma a" +
                                    "nd a space (up to 53 characters).');</script>";
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                    trYesNo.Visible = false;
                                    TrSmartClearance.Visible = true;
                                    trComments.Visible = true;
                                    checkSmartVal = "No";
                                    Session["btn_click"] = "YES";
                                }
                                else if ((strSmartClText.Length > 9))
                                {
                                    if ((strSmartClText.Length < 20))
                                    {

                                        script = "<script>alert('Please Enter five 9 characters of any format (number or letter) separated by a comma a" +
                                        "nd a space (up to 53 characters).');</script>";
                                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                        trYesNo.Visible = false;
                                        TrSmartClearance.Visible = true;
                                        trComments.Visible = true;
                                        checkSmartVal = "No";
                                        Session["btn_click"] = "YES";
                                    }
                                    else if ((strSmartClText.Length > 20))
                                    {
                                        if ((strSmartClText.Length < 31))
                                        {

                                            script = "<script>alert('Please Enter five 9 characters of any format (number or letter) separated by a comma a" +
                                            "nd a space (up to 53 characters).');</script>";
                                            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                            trYesNo.Visible = false;
                                            TrSmartClearance.Visible = true;
                                            trComments.Visible = true;
                                            checkSmartVal = "No";
                                            Session["btn_click"] = "YES";
                                        }
                                        else if ((strSmartClText.Length > 31))
                                        {
                                            if ((strSmartClText.Length < 42))
                                            {

                                                script = "<script>alert('Please Enter five 9 characters of any format (number or letter) separated by a comma a" +
                                                "nd a space (up to 53 characters).');</script>";
                                                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                                trYesNo.Visible = false;
                                                TrSmartClearance.Visible = true;
                                                trComments.Visible = true;
                                                checkSmartVal = "No";
                                                Session["btn_click"] = "YES";
                                            }
                                            else if ((strSmartClText.Length > 42))
                                            {
                                                if ((strSmartClText.Length < 53))
                                                {

                                                    script = "<script>alert('Please Enter five 9 characters of any format (number or letter) separated by a comma a" +
                                                    "nd a space (up to 53 characters).');</script>";
                                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                                    trYesNo.Visible = false;
                                                    TrSmartClearance.Visible = true;
                                                    trComments.Visible = true;
                                                    checkSmartVal = "No";
                                                    Session["btn_click"] = "YES";
                                                }
                                                else if ((strSmartClText.Length > 53))
                                                {

                                                    script = "<script>alert('Please Enter five 9 characters of any format (number or letter) separated by a comma a" +
                                                    "nd a space (up to 53 characters).');</script>";
                                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                                    trYesNo.Visible = false;
                                                    TrSmartClearance.Visible = true;
                                                    trComments.Visible = true;
                                                    checkSmartVal = "No";
                                                    Session["btn_click"] = "YES";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if ((checkSmartVal == "Yes"))
                            {
                                try
                                {
                                    if (objEOBA.SET_Smart_Clearance_Number(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), txtSmartClearance.Text.Trim(), ref paramOut))
                                    {

                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            if ((checkSmartVal == "Yes"))
                            {
                                if ((Request.QueryString["appStatus"].ToString() == "N"))
                                {

                                    if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "SMART Clearance", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                    {

                                    }

                                    EO_Lock_Release();
                                    //script = "<script>";
                                    //script = (script + "window.returnValue = 'T';");
                                    //script = (script + "window.close();</script>");

                                    if (UserAgent.Contains("MSIE"))
                                    {
                                        script = "<script>";
                                        script = (script + "window.returnValue = 'T';");
                                        script = (script + "window.close();</script>");
                                    }
                                    else
                                    {

                                        script = "<script>";
                                        script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                    }

                                    sendDeclineMail(Security.UserName);
                                }
                                else
                                {

                                    if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "SMART Clearance", Security.UserName.ToString().Trim(), 'Y', "", ref dsAppList, ref paramOut))
                                    {

                                        try
                                        {
                                            if (!(dsAppList == null))
                                            {
                                                if (!(dsAppList.Tables.Count == 0))
                                                {
                                                    if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                    {
                                                        if ((dsAppList.Tables[4].Rows[0][0].ToString().Trim() == "Yes"))
                                                        {
                                                            sendAllApprovalMail(Security.UserName);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    EO_Lock_Release();
                                    //script = "<script>";
                                    //script = (script + "window.returnValue = 'T';");
                                    //script = (script + "window.close();</script>");

                                    if (UserAgent.Contains("MSIE"))
                                    {
                                        script = "<script>";
                                        script = (script + "window.returnValue = 'T';");
                                        script = (script + "window.close();</script>");
                                    }
                                    else
                                    {

                                        script = "<script>";
                                        script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                    }

                                }
                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "Site HS_E Resource"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {

                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Site HS&E Resource", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                {

                                }

                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }

                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "Site HS&E Resource", Security.UserName, 'Y', "", ref dsAppList, ref paramOut))
                                {
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }

                            }

                            // Added by David on 01/03/2011 - MUREO PCR
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "Additional approver1"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {

                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Additional approver #1", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                {

                                }

                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Additional approver #1", Security.UserName.ToString().Trim(), 'Y', "", ref dsAppList, ref paramOut))
                                {

                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }


                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "Additional approver2"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Additional approver #2", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                {

                                }
                                // script = "<script>alert('Declined Successfully');</script> "
                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Additional approver #2", Security.UserName.ToString().Trim(), 'Y', "", ref dsAppList, ref paramOut))
                                {
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "Additional approver3"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Additional approver #3", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                {

                                }
                                // script = "<script>alert('Declined Successfully');</script> "
                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "Additional approver #3", Security.UserName.ToString().Trim(), 'Y', "", ref dsAppList, ref paramOut))
                                {

                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                // script = "<script>alert('approval is successfully completed');</script> "

                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }

                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "Additional approver4"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "Additional approver #4", Security.UserName, 'N', "", ref dsAppList, ref paramOut))
                                {

                                }

                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "Additional approver #4", Security.UserName, 'Y', "", ref dsAppList, ref paramOut))
                                {
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString().Trim() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }


                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }

                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "PS_RA"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "PS&RA", Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                                {

                                }
                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), "PS&RA", Security.UserName.ToString().Trim(), 'Y', "", ref dsAppList, ref paramOut))
                                {
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString().Trim() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                            }
                        }
                        else if ((Request.QueryString["appFunName"].ToString() == "Budget Center"))
                        {
                            if ((Request.QueryString["appStatus"].ToString() == "N"))
                            {
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "Budget Center", Security.UserName, 'N', "", ref dsAppList, ref paramOut))
                                {

                                }
                                EO_Lock_Release();
                                //script = "<script>";
                                //script = (script + "window.returnValue = 'T';");
                                //script = (script + "window.close();</script>");

                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = 'T';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }

                                sendDeclineMail(Security.UserName);
                            }
                            else
                            {
                               
                                if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"], "Budget Center", Security.UserName, 'Y', "", ref dsAppList, ref paramOut))
                                {
                                    try
                                    {
                                        if (!(dsAppList == null))
                                        {
                                            if (!(dsAppList.Tables.Count == 0))
                                            {
                                                if (!(dsAppList.Tables[4].Rows.Count == 0))
                                                {
                                                    if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                    {
                                                        sendAllApprovalMail(Security.UserName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }

                                EO_Lock_Release();
                                if (UserAgent.Contains("MSIE"))
                                {
                                    script = "<script>";
                                    script = (script + "window.returnValue = \'T\';");
                                    script = (script + "window.close();</script>");
                                }
                                else
                                {

                                    script = "<script>";
                                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                }
                                if (!(dsAppList == null))
                                {
                                    if (!(dsAppList.Tables.Count == 0))
                                    {
                                        if (!(dsAppList.Tables[0].Rows.Count == 0))
                                        {
                                            if ((Request.QueryString["EoStage"].ToUpper() == "Preliminary".ToUpper()))
                                            {
                                                for (intRow = 0; (intRow
                                                            <= (dsAppList.Tables[0].Rows.Count - 1)); intRow++)
                                                {
                                                    if (((dsAppList.Tables[0].Rows[intRow][0].ToString() == "GBU HS&E Resource")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Site HS&E Resource")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Site Contact")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Site Planning")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Central QA")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "QA")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Additional approver #1")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Additional approver #2")
                                                                || ((dsAppList.Tables[0].Rows[intRow][0].ToString() == "Additional approver #3")
                                                                || (dsAppList.Tables[0].Rows[intRow][0].ToString() == "Additional approver #4")))))))))))
                                                    {
                                                        if ((strFYI == ""))
                                                        {
                                                            strFYI = dsAppList.Tables[0].Rows[intRow][1].ToString();
                                                        }
                                                        else
                                                        {
                                                            strFYI = (strFYI + (";" + dsAppList.Tables[0].Rows[intRow][1].ToString()));
                                                        }
                                                        // to get all function names of approvers other than budget center
                                                        if ((strFYIfunctionname == ""))
                                                        {
                                                            strFYIfunctionname = dsAppList.Tables[0].Rows[intRow][0].ToString();
                                                        }
                                                        else
                                                        {
                                                            strFYIfunctionname = (strFYIfunctionname + (";" + dsAppList.Tables[0].Rows[intRow][0].ToString()));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if ((strNames == ""))
                                                        {
                                                            strNames = dsAppList.Tables[0].Rows[intRow][1].ToString();
                                                        }
                                                        else
                                                        {
                                                            strNames = (strNames + (";" + dsAppList.Tables[0].Rows[intRow][1].ToString()));
                                                        }
                                                        if ((strAppfunctionname == ""))
                                                        {
                                                            strAppfunctionname = dsAppList.Tables[0].Rows[intRow][0].ToString();
                                                        }
                                                        else
                                                        {
                                                            strAppfunctionname = (strAppfunctionname + (";" + dsAppList.Tables[0].Rows[intRow][0].ToString()));
                                                        }
                                                    }
                                                }
                                            }
                                            else if ((Request.QueryString["EoStage"].ToUpper() == "Final".ToUpper()))
                                            {
                                                try
                                                {
                                                    DataSet ds = null;

                                                    if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                                                    {


                                                        if (!(ds == null))
                                                        {
                                                            if (!(ds.Tables.Count == 0))
                                                            {
                                                                if (!(ds.Tables[0].Rows[0]["Two_Tab_Routing"] == System.DBNull.Value))
                                                                {
                                                                    if ((ds.Tables[0].Rows[0]["Two_Tab_Routing"].ToString().Trim().ToUpper() == "Y".ToUpper()))
                                                                    {
                                                                        // For 2 tab route --sending mails to all remaining Approvers when Budget Owner clicks Approve
                                                                        try
                                                                        {
                                                                            mandataroinfoforEmail();
                                                                            DataSet dsAppListFinal = null;
                                                                            string strbudgetcenter;
                                                                            //dsAppListFinal = 
                                                                            if (objEOBA.GET_EO_Final_Approvers_List(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), ref dsAppListFinal))
                                                                            {
                                                                                if (!(dsAppListFinal == null))
                                                                                {
                                                                                    if (!(dsAppListFinal.Tables.Count == 0))
                                                                                    {
                                                                                        if (!(dsAppListFinal.Tables[0].Rows.Count == 0))
                                                                                        {
                                                                                            for (intRow = 0; (intRow
                                                                                                        <= (dsAppListFinal.Tables[0].Rows.Count - 1)); intRow++)
                                                                                            {
                                                                                                DataSet dsPreliminary = null;
                                                                                                try
                                                                                                {
                                                                                                    //dsPreliminary = .GET_EO_Preliminary(Request.QueryString["EOID"]);
                                                                                                    if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), ref dsAppListFinal))
                                                                                                    {
                                                                                                        if (!(dsAppListFinal.Tables[0].Rows[intRow][0] == System.DBNull.Value))
                                                                                                        {
                                                                                                            if ((dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() == "Budget Center"))
                                                                                                            {
                                                                                                                if (!(dsAppListFinal.Tables[0].Rows[intRow][1] == System.DBNull.Value))
                                                                                                                {
                                                                                                                    strbudgetcenter = dsAppListFinal.Tables[0].Rows[intRow][1].ToString().Trim();
                                                                                                                }
                                                                                                            }
                                                                                                        }

                                                                                                    }

                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                }
                                                                                                if (!(dsAppListFinal.Tables[0].Rows[intRow][0] == System.DBNull.Value))
                                                                                                {
                                                                                                    if ((dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() == "Site HS&E Resource"))
                                                                                                    {
                                                                                                        if (!(dsAppListFinal.Tables[0].Rows[intRow][1] == System.DBNull.Value))
                                                                                                        {
                                                                                                            if (!(dsAppListFinal.Tables[0].Rows[intRow][1].ToString().Trim() == "Approval Not Needed"))
                                                                                                            {
                                                                                                                if (!(dsPreliminary.Tables.Count == 0))
                                                                                                                {
                                                                                                                    if (!(dsPreliminary.Tables[4].Rows.Count == 0))
                                                                                                                    {
                                                                                                                        if (((dsPreliminary.Tables[4].Rows[0][0] == System.DBNull.Value)
                                                                                                                                    || ((dsPreliminary.Tables[4].Rows[0][1] == System.DBNull.Value)
                                                                                                                                    || ((dsPreliminary.Tables[4].Rows[0][2] == System.DBNull.Value)
                                                                                                                                    || (dsPreliminary.Tables[4].Rows[0][3] == System.DBNull.Value)))))
                                                                                                                        {

                                                                                                                        }
                                                                                                                        else if (((dsPreliminary.Tables[4].Rows[0][0].ToString().Trim() == "Y")
                                                                                                                                    || ((dsPreliminary.Tables[4].Rows[0][1].ToString().Trim() == "Y")
                                                                                                                                    || ((dsPreliminary.Tables[4].Rows[0][2].ToString().Trim() == "Y")
                                                                                                                                    || (dsPreliminary.Tables[4].Rows[0][3].ToString().Trim() == "Y")))))
                                                                                                                        {
                                                                                                                            try
                                                                                                                            {
                                                                                                                                string strURLLockMode;
                                                                                                                                strURLLockMode = ("http://"
                                                                                                                                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                                                                                                                                string strURLEditMode;
                                                                                                                                strURLEditMode = ("http://"
                                                                                                                                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                                                                                                string strTotCost = "";
                                                                                                                                if (ViewState["TotCost"] != null)
                                                                                                                                    strTotCost = ViewState["TotCost"].ToString().Trim();
                                                                                                                                SendMail2tab(dsAppListFinal.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                                                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                                                                                                + (ViewState["EONum"].ToString().Trim() + (" - " + ViewState["EOTitle"].ToString().Trim()))))), ("Dear "
                                                                                                                                                + (dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() + (" Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                                                                                                + (strURLLockMode + ("\'>"
                                                                                                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                                                                                                + (strURLEditMode + ("\'>"
                                                                                                                                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                                                                                                + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("SAP IO Number :"
                                                                                                                                                + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearance Number :"
                                                                                                                                                + (ViewState["SmartClearanceNum"] + ("<br>" + ("EO Title is  :"
                                                                                                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                                                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                                                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                                                                                                + (strTotCost + ("<br>" + ("Current Stage  :"
                                                                                                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                                                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                                                                                                + (Security.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))))))))));
                                                                                                                            }
                                                                                                                            catch (Exception ex)
                                                                                                                            {
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            try
                                                                                                                            {
                                                                                                                                string strTotCost = "";
                                                                                                                                if (ViewState["TotCost"] != null)
                                                                                                                                    strTotCost = ViewState["TotCost"].ToString().Trim();
                                                                                                                                string strURLLockMode;
                                                                                                                                // strURLLockMode = "http://" & ViewState["servername") & "/MUREO/Common/NewEO.aspx?From=ForEOLock&EOID=" & ViewState["EOID"]
                                                                                                                                strURLLockMode = ("http://"
                                                                                                                                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=ForEOLock&For=FYI&EOID=" + ViewState["EOID"])));
                                                                                                                                string strURLEditMode;
                                                                                                                                strURLEditMode = ("http://"
                                                                                                                                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                                                                                                SendMail2tab(dsAppListFinal.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                                                                                                + (ViewState["nextTwoDate"].ToString().Trim() + (". EO Number - "
                                                                                                                                                + (ViewState["EONum"].ToString().Trim().ToString().Trim() + (" - " + ViewState["EOTitle"].ToString().Trim()))))), ("<br>" + ("<br>" + ("Dear "
                                                                                                                                                + (dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() + (" (FYI ONLY)," + ("<br>" + ("<br>" + ("You are receiving this link as an FYI.  Please communicate any issues with the proposed timing of thi" +
                                                                                                                                                "s EO to the originator." + ("<br>" + ("Please follow the link below to review this EO." + ("<br>" + ("<br>" + ("NOTE:  This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                                                                                                + (strURLLockMode + ("\'>"
                                                                                                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("EO Number is :"
                                                                                                                                                + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("EO Title is  :"
                                                                                                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                                                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                                                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                                                                                                + (strTotCost + ("<br>" + ("Current Stage  :"
                                                                                                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                                                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                                                                                                + (Security.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))));
                                                                                                                            }
                                                                                                                            catch (Exception ex)
                                                                                                                            {
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                        // End If
                                                                                                    }
                                                                                                    else if (((dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() == "GBU HS&E Resource")
                                                                                                                || (dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() == "Central QA")))
                                                                                                    {
                                                                                                        // For FYI
                                                                                                        try
                                                                                                        {
                                                                                                            string strTotCost = "";
                                                                                                            if (ViewState["TotCost"] != null)
                                                                                                                strTotCost = ViewState["TotCost"].ToString().Trim();
                                                                                                            string strURLLockMode;
                                                                                                            // strURLLockMode = "http://" & ViewState["servername") & "/MUREO/Common/NewEO.aspx?From=ForEOLock&EOID=" & ViewState["EOID"]
                                                                                                            strURLLockMode = ("http://"
                                                                                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&For=FYI&EOID=" + ViewState["EOID"])));
                                                                                                            string strURLEditMode;
                                                                                                            strURLEditMode = ("http://"
                                                                                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                                                                            SendMail2tab(dsAppListFinal.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                                                                            + (ViewState["nextTwoDate"].ToString().Trim() + (". EO Number - "
                                                                                                                            + (ViewState["EONum"].ToString().Trim() + (" - " + ViewState["EOTitle"]))))), ("<br>" + ("<br>" + ("Dear "
                                                                                                                            + (dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() + (" (FYI ONLY)," + ("<br>" + ("<br>" + ("You are receiving this link as an FYI.  Please communicate any issues with the proposed timing of thi" +
                                                                                                                            "s EO to the originator." + ("<br>" + ("Please follow the link below to review this EO." + ("<br>" + ("<br>" + ("NOTE:  This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                                                                            + (strURLLockMode + ("\'>"
                                                                                                                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("<br>" + ("EO Number is :"
                                                                                                                            + (ViewState["EONum"].ToString().Trim() + ("<br>" + ("EO Title is  :"
                                                                                                                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                                                                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                                                                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                                                                            + (strTotCost + ("<br>" + ("Current Stage  :"
                                                                                                                            + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                                                                            + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                                                                            + (Security.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))));
                                                                                                        }
                                                                                                        catch (Exception ex)
                                                                                                        {
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        // For Approve
                                                                                                        try
                                                                                                        {
                                                                                                            if (!(dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() == "Budget Center"))
                                                                                                            {
                                                                                                                string strURLLockMode;
                                                                                                                // strURLLockMode = "http://" & ViewState["servername") & "/MUREO/Common/NewEO.aspx?From=ForEOLock&EOID=" & ViewState["EOID"]
                                                                                                                strURLLockMode = ("http://"
                                                                                                                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=ForEOLock&For=FYI&EOID=" + ViewState["EOID"])));
                                                                                                                string strURLEditMode;
                                                                                                                strURLEditMode = ("http://"
                                                                                                                            + (ViewState["servername"].ToString().Trim() + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                                                                                string strTotCost = "";
                                                                                                                if (ViewState["TotCost"] != null)
                                                                                                                    strTotCost = ViewState["TotCost"].ToString().Trim();
                                                                                                                SendMail2tab(dsAppListFinal.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                                                                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear "
                                                                                                                                + (dsAppListFinal.Tables[0].Rows[intRow][0].ToString().Trim() + (" Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                                                                                + (strURLLockMode + ("\'>"
                                                                                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                                                                                + (strURLEditMode + ("\'>"
                                                                                                                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                                                                                + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                                                                                                                + (ViewState["SAPIONum"] + ("<br>" + ("Smart Clearnace Number :"
                                                                                                                                + (ViewState["SmartClearanceNum"] + ("<br>" + ("EO Title is  :"
                                                                                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                                                                                + (strTotCost + ("<br>" + ("Current Stage  :"
                                                                                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                                                                                + (Security.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))))))))));
                                                                                                            }
                                                                                                        }
                                                                                                        catch (Exception ex)
                                                                                                        {
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                // End If
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }

                                                                            }

                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                        }
                                                                        // -------------------
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
                                }
                            }
                            if (!(strNames == ""))
                            {
                                SendMail(strNames, strAppfunctionname);
                            }
                            if (!(strFYI == ""))
                            {
                                SendMailFYI(strFYI, strFYIfunctionname);
                            }
                        }
                        else if ((Request.QueryString["appStatus"].ToString() == "N"))
                        {
                            if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), Request.QueryString["appFunName"].ToString().Trim(), Security.UserName.ToString().Trim(), 'N', "", ref dsAppList, ref paramOut))
                            {

                            }

                            EO_Lock_Release();
                            if (UserAgent.Contains("MSIE"))
                            {
                                script = "<script>";
                                script = (script + "window.returnValue = \'T\';");
                                script = (script + "window.close();</script>");
                            }
                            else
                            {

                                script = "<script>";
                                script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                            }
                            sendDeclineMail(Security.UserName);
                        }
                        else
                        {
                            if (objEOBA.SetApprovarStatus(Convert.ToInt32(Request.QueryString["EOID"].ToString().Trim()), Request.QueryString["EoStage"].ToString().Trim(), Request.QueryString["appFunName"].ToString().Trim(), Security.UserName.ToString().Trim(), 'Y', "", ref dsAppList, ref paramOut))
                            {
                                try
                                {
                                    if (!(dsAppList == null))
                                    {
                                        if (!(dsAppList.Tables.Count == 0))
                                        {
                                            if (!(dsAppList.Tables[4].Rows.Count == 0))
                                            {
                                                if ((dsAppList.Tables[4].Rows[0][0].ToString() == "Yes"))
                                                {
                                                    sendAllApprovalMail(Security.UserName);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            EO_Lock_Release();
                            if (UserAgent.Contains("MSIE"))
                            {
                                script = "<script>";
                                script = (script + "window.returnValue = \'T\';");
                                script = (script + "window.close();</script>");
                            }
                            else
                            {

                                script = "<script>";
                                script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                            }
                        }
                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    }
                    // btnSubmit.Visible = True
                }
                catch (Exception ex)
                {
                    //  btnSubmit.Visible = True
                }
            }
            else
            {
                string script;
                if (UserAgent.Contains("MSIE"))
                {
                    script = "<script>";
                    script = (script + "window.returnValue = \'T\';");
                    script = (script + "window.close();</script>");
                }
                else
                {

                    script = "<script>";
                    script = (script + "if ('" + Request.QueryString["appStatus"].ToString() + "'== 'N') {alert('Declined Successfully');}else {alert('Approval is successfully completed');}window.opener.location.href = '../Reports/MyApprovals.aspx';window.close();</script>");
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                }
            }
        }

    }
}