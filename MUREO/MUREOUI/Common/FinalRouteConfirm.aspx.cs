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
    public partial class FinalRouteConfirm : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;
        clsSecurity objclsSecurity = new clsSecurity();
        clsSendMail objclssSendMail = new clsSendMail();
        protected void Page_Load(object sender, EventArgs e)
        {
            TrPreliminary.Visible = false;
            TrFinal.Visible = false;
            TrCloseOut.Visible = false;
            TrOK.Visible = false;
            btnOk.Attributes.Add("onclick", "javascript: hourglass();");
            btnYes.Attributes.Add("onclick", "javascript: hourglass();"); 
            ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];
            ViewState["EOID"] = Request.QueryString["EOID"];
            //if (!Page.IsPostBack)
            //{
            //    Session["Route_Click"] = "YES";
            //}
            Session["Route_Click"] = "YES";
            if (!Page.IsPostBack)
            {
                string script = null;
                script = "<script>";
                script = script + "window.opener.document.getElementById('hdnGCASValue').value='';</script>";
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
            }
          

        }
        private void btnYes_Click(object sender, System.EventArgs e)
        {
           
        }
        private void btnNo_Click(object sender, System.EventArgs e)
        {
          
        }
        private void SendMail(string strApprName, string strSubject, string strBody)
        {
            int intPosition;
            int i;
            int intPosOriginator;
            string appName;
            string senderName;
            string PosOriginator = string.Empty;
            string strOriginator = string.Empty;
            string[] strMailIDs = null;
            appName = strApprName;
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
                clsSendMail objSendMail = new clsSendMail();
                objSendMail.SendTo = senderName;
                objSendMail.SendFrom = (PosOriginator + "@pg.com");
                objSendMail.MailSubject = strSubject;
                objSendMail.MailBody = strBody;
                bool IsMailSend;
                //objSendMail.SendTo = "sreevani.j@vertexcs.com";
                //objSendMail.SendFrom = "sreevani.j@vertexcs.com";
                //objSendMail.SendCCTo = "sreevani.j@vertexcs.com";
                //objSendMail.SendBCCTo = "sreevani.j@vertexcs.com";
                IsMailSend = clsSendMail.fnSendMail(objSendMail);
                if (IsMailSend)
                {
                    if ((ConfigurationSettings.AppSettings["MailLog"].ToString().ToUpper() == "Yes".ToUpper()))
                    {
                        if (objEOBA.addingMailDetails(objSendMail.SendFrom, objSendMail.SendTo, objSendMail.SendCCTo, objSendMail.SendBCCTo, objSendMail.MailSubject, "MailForRoute_Approve_the_EO", ""))
                        {

                        }
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
                // If UCase(ConfigurationSettings.AppSettings("MailLog")) = UCase("Yes") Then
                //     objClsEO.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "MailForRoute_Approve_the_EO", "")
                // End If
            }
            catch (Exception ex)
            {
            }
        }
        private void mandataroinfoforEmail()
        {
            DataSet ds = null;
            try
            {
                string strCurrentStage;
                string strStatus;
                int intPlantID=0;
                string strEOnum;
                string strSAPIO;
                // For mail date to add 2 business days to current date
                DateTime currentDate = DateTime.Today.Date;
                DateTime nextTwoDate = DateTime.Today.Date;
                if ((DateTime.Today.DayOfWeek == 0))
                {
                    nextTwoDate = currentDate.AddDays(2);
                }
                else if ((DateTime.Today.DayOfWeek.ToString() == "6"))
                {
                    nextTwoDate = currentDate.AddDays(3);
                }
                else if ((DateTime.Today.DayOfWeek.ToString() == "5"))
                {
                    nextTwoDate = currentDate.AddDays(4);
                }
                else if ((DateTime.Today.DayOfWeek.ToString() == "4"))
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
                if (objEOBA.GETEOMandatory(Convert.ToInt32(ViewState["EOID"]), ref ds))
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
                                        ViewState["Status"] = Session["Status"];
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


            }
            catch (Exception ex)
            {
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
                            ViewState["BudgetCenter"] = String.Empty;
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
                            ViewState["TotCost"] = 0;
                            // 'End Here
                        }
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
                            for (intRowCount = 0; (intRowCount
                                        <= (ds.Tables[12].Rows.Count - 1)); intRowCount++)
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
        private void final2tabRouteSendMails()
        {
            try
            {
                mandataroinfoforEmail();
                string strURLLockMode;
                strURLLockMode = ("http://" 
                    + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                string strURLEditMode;
                strURLEditMode = ("http://"
                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                SendMail(Request.QueryString["BO"], ("Please Review by "
                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear Budget Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                + (strURLLockMode + ("\'>"
                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br><a href=\'"
                                + (strURLEditMode + ("\'>"
                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                + (objclsSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))));
            }
            catch (Exception ex)
            {
            }
        }
        private void finalRouteSendMails()
        {
            try
            {
                mandataroinfoforEmail();
                DataSet dsAppList =  null;
                int intResult = 0;
                int intRow;
                string strNames ="";
                string strbudgetcenter;
                string strFYI = "";
        
                    if (objEOBA.GET_EO_Final_Approvers_List(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ref dsAppList))
                    {
                        if (!(dsAppList == null))
                        {
                            if (!(dsAppList.Tables.Count == 0))
                            {
                                if (!(dsAppList.Tables[0].Rows.Count == 0))
                                {
                                    for (intRow = 0; (intRow
                                                <= (dsAppList.Tables[0].Rows.Count - 1)); intRow++)
                                    {
                                        DataSet dsPreliminary = null;
                                        try
                                        {
                                          //  dsPreliminary = objClsEO.GET_EO_Preliminary(ViewState["EOID"));
                                            if(objEOBA.GET_EO_Preliminary(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ref dsPreliminary))
                                            {
                                                if (!(dsAppList.Tables[0].Rows[intRow][0] == System.DBNull.Value))
                                                {
                                                    if ((dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() == "Budget Center"))
                                                    {
                                                        if (!(dsAppList.Tables[0].Rows[intRow][1] == System.DBNull.Value))
                                                        {
                                                            strbudgetcenter = dsAppList.Tables[0].Rows[intRow][1].ToString().Trim();
                                                        }
                                                    }
                                                }
                                            }
                                           
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                        try
                                        {
                                            if (!(dsAppList.Tables[0].Rows[intRow][0] == System.DBNull.Value))
                                            {
                                                if ((dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() == "Site HS&E Resource"))
                                                {
                                                    if (!(dsAppList.Tables[0].Rows[intRow][1] == System.DBNull.Value))
                                                    {
                                                        if (!(dsAppList.Tables[0].Rows[intRow][1].ToString().Trim() == "Approval Not Needed"))
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
                                                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&For=FYI&EOID=" + ViewState["EOID"])));
                                                                            string strURLEditMode;
                                                                            strURLEditMode = ("http://"
                                                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                                            SendMail(dsAppList.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                                            + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                                            + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear "
                                                                                            + (dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() + (" Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                                            + (strURLLockMode + ("\'>"
                                                                                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                                            + (strURLEditMode + ("\'>"
                                                                                            + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                                            + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                                                                            + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                                                                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                                            + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                                            + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                                            + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                                            + (objclsSecurity.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))))))));
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        try
                                                                        {
                                                                            string strURLLockMode;
                                                                            strURLLockMode = ("http://"
                                                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                                                                            string strURLEditMode;
                                                                            strURLEditMode = ("http://"
                                                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                                            SendMail(dsAppList.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                                            + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                                            + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("<br>" + ("<br>" + ("Dear "
                                                                                            + (dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() + (" (FYI ONLY)," + ("<br>" + ("<br>" + ("You are receiving this link as an FYI.  Please communicate any issues with the proposed timing of thi" +
                                                                                            "s EO to the originator." + ("<br>" + ("Please follow the link below to review this EO." + ("<br>" + ("<br>" + ("NOTE:  This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                                            + (strURLLockMode + ("\'>"
                                                                                            + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("EO Number is :"
                                                                                            + (ViewState["EONum"] + ("<br>" + ("EO Title is  :"
                                                                                            + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                                            + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                                            + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                                            + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                                            + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                                            + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                                            + (objclsSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))));
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                        }
                                                                    }
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
                                        if ((dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() == "GBU HS&E Resource"))
                                        {
                                            // For FYI
                                            try
                                            {
                                                string strURLLockMode;
                                                strURLLockMode = ("http://"
                                                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&For=FYI&EOID=" + ViewState["EOID"])));
                                                string strURLEditMode;
                                                strURLEditMode = ("http://"
                                                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                SendMail(dsAppList.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("<br>" + ("<br>" + ("Dear "
                                                                + (dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() + (" (FYI ONLY)," + ("<br>" + ("<br>" + ("You are receiving this link as an FYI.  Please communicate any issues with the proposed timing of thi" +
                                                                "s EO to the originator." + ("<br>" + ("Please follow the link below to review this EO." + ("<br>" + ("<br>" + ("NOTE:  This link will open the EO in \'Read Only\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                + (strURLEditMode + ("\'>"
                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("<br>" + ("<br>" + ("EO Number is :"
                                                                + (ViewState["EONum"] + ("<br>" + ("EO Title is  :"
                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                + (ViewState["stage"] + ("<br>" + ("Proposed Testing Start Date :"
                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                + (objclsSecurity.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))));
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }
                                        else if ((dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() == "QA"))
                                        {
                                            try
                                            {
                                                string strURLLockMode;
                                                strURLLockMode = ("http://"
                                                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                                                string strURLEditMode;
                                                strURLEditMode = ("http://"
                                                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                SendMail(dsAppList.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear Site QA Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                + (strURLLockMode + ("\'>"
                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br><a href=\'"
                                                                + (strURLEditMode + ("\'>"
                                                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                                                + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                + (objclsSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))));
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }
                                        else if (!(dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() == "Site HS&E Resource"))
                                        {
                                            // For Approve
                                            try
                                            {
                                                string strURLLockMode;
                                                strURLLockMode = ("http://"
                                                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                                                string strURLEditMode;
                                                strURLEditMode = ("http://"
                                                            + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                                SendMail(dsAppList.Tables[0].Rows[intRow][1].ToString().Trim(), ("Please Review by "
                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear "
                                                                + (dsAppList.Tables[0].Rows[intRow][0].ToString().Trim() + (" Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                + (strURLLockMode + ("\'>"
                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br><a href=\'"
                                                                + (strURLEditMode + ("\'>"
                                                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                                                + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                                                + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                + (objclsSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))))));
                                            }
                                            catch (Exception ex)
                                            {
                                            }
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
        }
        private void btnOk_Click(object sender, System.EventArgs e)
        {
          
        }
        protected void btnOk_Click1(object sender, EventArgs e)
        {
            string script1;
            script1 = "<script>window.opener.location = '../Reports/MYEOs.aspx';window.close();</script>";
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script1);
        }
        protected void btnYes_Click1(object sender, EventArgs e)
        {
            EOBA objEOBA = new EOBA();
            SqlParameter[] paramOut = null;
            DataSet ds = null;

            if ((Session["Route_Click"] != null) && (Session["Route_Click"].ToString() == "YES"))
            {
                Session["Route_Click"] = "NO";
                string struserName;
                struserName = objclsSecurity.UserName;
                
                if (objEOBA.SET_EO_Stage(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), Request.QueryString["Stage"], struserName, ref paramOut))
                {

                }
                if (!(Request.QueryString["EOID"] == null))
                {
                    objEOBA.SET_EO_Lock_Release_User(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), struserName);

                }
                if ((Request.QueryString["Stage"].ToUpper() == "Preliminary".ToUpper()))
                {
                    try
                    {
                        mandataroinfoforEmail();
                        string strURLLockMode;
                        strURLLockMode = ("http://"
                                    + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                        string strURLEditMode;
                        strURLEditMode = ("http://"
                                    + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                        SendMail(Request.QueryString["BO"], ("Please Review by "
                                        + (ViewState["nextTwoDate"] + (". EO Number - "
                                        + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear Budget Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                        + (strURLLockMode + ("\'>"
                                        + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in Edit Mode." + ("<br><a href=\'"
                                        + (strURLEditMode + ("\'>"
                                        + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                        + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                        + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                        + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                        + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                        + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost : $"
                                        + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                        + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                        + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                        + (objclsSecurity.UserName + ".")))))))))))))))))))))))))))))))))))))))))))))))));
                    }
                    catch (Exception ex)
                    {
                    }
                    string script;
                    TrPreliminary.Visible = true;
                    TrOK.Visible = true;
                    trYesNo.Visible = false;
                }
                else if ((Request.QueryString["Stage"].ToUpper() == "Final".ToUpper()))
                {

                    if (objEOBA.GETEOMandatory(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), ref ds))
                    {
                        if (!(ds == null))
                        {
                            if (!(ds.Tables.Count == 0))
                            {
                                if (!(ds.Tables[0].Rows.Count == 0))
                                {
                                    if (!(ds.Tables[0].Rows[0]["Two_Tab_Routing"] == System.DBNull.Value))
                                    {
                                        ViewState["Two_Tab_Routing"] = ds.Tables[0].Rows[0]["Two_Tab_Routing"].ToString().Trim();
                                    }
                                    else
                                    {
                                        ViewState["Two_Tab_Routing"] = "N";
                                    }
                                }
                            }
                        }
                        if ((ViewState["Two_Tab_Routing"] == "Y"))
                        {
                            final2tabRouteSendMails();
                        }
                        else
                        {
                            finalRouteSendMails();
                        }
                        TrFinal.Visible = true;
                        TrOK.Visible = true;
                        trYesNo.Visible = false;

                    }

                }
                else if ((Request.QueryString["Stage"].ToUpper() == "closeout".ToUpper()))
                {
                    try
                    {
                        mandataroinfoforEmail();
                        DataSet dsCloseOutAppList = null;
                        int intCloseOutAppList;
                        if (objEOBA.GET_EO_Closeout(Convert.ToInt32(ViewState["EOID"]), ref dsCloseOutAppList))
                        {
                            if (!(dsCloseOutAppList == null))
                            {
                                if (!(dsCloseOutAppList.Tables.Count == 0))
                                {
                                    if (!(dsCloseOutAppList.Tables[5].Rows.Count == 0))
                                    {
                                        for (intCloseOutAppList = 0; (intCloseOutAppList
                                                    <= (dsCloseOutAppList.Tables[5].Rows.Count - 1)); intCloseOutAppList++)
                                        {
                                            string strURLLockMode;
                                            strURLLockMode = ("http://"
                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EOID"])));
                                            string strURLEditMode;
                                            strURLEditMode = ("http://"
                                                        + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EOID"])));
                                            if ((dsCloseOutAppList.Tables[5].Rows[intCloseOutAppList]["Function_Name"].ToString().Trim() == "Budget Center"))
                                            {
                                                SendMail(dsCloseOutAppList.Tables[5].Rows[intCloseOutAppList]["Approver_Name"].ToString().Trim(), ("Please Review by "
                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear Budget Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                + (strURLLockMode + ("\'>"
                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in Edit Mode." + ("<br>" + ("<br><a href=\'"
                                                                + (strURLEditMode + ("\'>"
                                                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                                                + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost :"
                                                                + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                + (objclsSecurity.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))))));
                                            }
                                            else
                                            {
                                                SendMail(dsCloseOutAppList.Tables[5].Rows[intCloseOutAppList]["Approver_Name"].ToString(), ("Please Review by "
                                                                + (ViewState["nextTwoDate"] + (". EO Number - "
                                                                + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))))), ("Dear "
                                                                + (dsCloseOutAppList.Tables[5].Rows[intCloseOutAppList]["Function_Name"].ToString().Trim() + (" Approver," + ("<br>" + ("<br>" + ("You are listed as an approver for this EO.  Please follow the link to see this EO." + ("<br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Read Only\' Mode." + ("<br><a href=\'"
                                                                + (strURLLockMode + ("\'>"
                                                                + (strURLLockMode + ("</a><br>" + ("<br>" + ("NOTE:  Use this link to open the EO in \'Edit\' Mode." + ("<br>" + ("<br><a href=\'"
                                                                + (strURLEditMode + ("\'>"
                                                                + (strURLEditMode + ("</a><br>" + ("<br>" + ("EO Number is :"
                                                                + (ViewState["EONum"] + ("<br>" + ("SAP IO Number :"
                                                                + (ViewState["SAPIONum"] + ("<br>" + ("EO Title is  :"
                                                                + (ViewState["EOTitle"] + ("<br>" + ("EO Location :"
                                                                + (ViewState["PlantName"] + ("<br>" + ("Budget Center :"
                                                                + (ViewState["BudgetCenter"] + ("<br>" + ("Expected Cost :"
                                                                + (ViewState["TotCost"] + ("<br>" + ("Current Stage  :"
                                                                + (ViewState["stage"] + ("<br><font color=red><b>" + ("Proposed Testing Start Date :"
                                                                + (ViewState["PlannedStartDate"] + ("</b></font><br>" + ("<br>" + ("Thank you," + ("<br>"
                                                                + (objclsSecurity.UserName + "."))))))))))))))))))))))))))))))))))))))))))))))))))));
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
                    TrCloseOut.Visible = true;
                    TrOK.Visible = true;
                    trYesNo.Visible = false;
                }
            }
            else
            {
                string script1;
                if ((Request.QueryString["Stage"].ToUpper() == "Preliminary".ToUpper()))
                {
                    TrPreliminary.Visible = true;
                    TrOK.Visible = true;
                    trYesNo.Visible = false;
                }
                else if ((Request.QueryString["Stage"].ToUpper() == "Final".ToUpper()))
                {
                    TrFinal.Visible = true;
                    TrOK.Visible = true;
                    trYesNo.Visible = false;
                }
                else if ((Request.QueryString["Stage"].ToUpper() == "closeout".ToUpper()))
                {
                    TrCloseOut.Visible = true;
                    TrOK.Visible = true;
                    trYesNo.Visible = false;
                }
            }
        }
        protected void btnNo_Click1(object sender, EventArgs e)
        {
            try
            {
                if (objEOBA.SET_EO_Check_And_Lock(Convert.ToInt32(ViewState["EOID"].ToString().Trim()), objclsSecurity.UserName, ref paramOut))
                {
                }
            }
            catch (Exception ex)
            {
            }
            string script;
            script = "<script>";
            script = (script + "window.close();</script>");
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);

        }
    }
}