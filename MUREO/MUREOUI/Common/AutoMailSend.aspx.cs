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
    public partial class AutoMailSend : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];
                
            DataSet dsMailRemainders = null;
            SqlParameter[] paramOut = null;
            if (objEOBA.GET_EO_Mail_Reminders(ref dsMailRemainders))
            {
                string strMailIDList;
                string strMailID;
                int intMailCount;
                int intIndex;
                  DataSet objDS = null;
                if (!(dsMailRemainders == null))
                {
                    if (!(dsMailRemainders.Tables.Count == 0))
                    {
                        if (!(dsMailRemainders.Tables[0].Rows.Count == 0))
                        {
                            for (intMailCount = 0; (intMailCount
                                        <= (dsMailRemainders.Tables[0].Rows.Count - 1)); intMailCount++)
                            {
                                try
                                {
                                    if (!(dsMailRemainders.Tables[0].Rows[intMailCount]["Approver_Name"] == System.DBNull.Value))
                                    {
                                        if (!(dsMailRemainders.Tables[0].Rows[intMailCount]["EO_ID"] == System.DBNull.Value))
                                        {
                                            int intEOID;
                                         
                                            intEOID = Convert.ToInt32(dsMailRemainders.Tables[0].Rows[intMailCount]["EO_ID"].ToString());

                                            if (objEOBA.GETEOMandatory(intEOID, ref objDS))
                                            {

                                                try
                                                {
                                                    DateTime EO_Created_Date = DateTime.Now.Date;
                                                    if (!(dsMailRemainders.Tables[0].Rows[intMailCount]["Created_Date"] == DBNull.Value))
                                                    {
                                                        EO_Created_Date = Convert.ToDateTime(dsMailRemainders.Tables[0].Rows[intMailCount]["Created_Date"]);
                                                    }
                                                    string strURLLockMode;
                                                    strURLLockMode = ("http://"
                                                                + (ViewState["servername"] + ("/Common/NewEO.aspx?From=ForEOLock&EOID=" + intEOID)));
                                                    string strURLEditMode;
                                                    strURLEditMode = ("http://"
                                                                + (ViewState["servername"] + ("/Common/NewEO.aspx?From=MailEdit&EOID=" + intEOID)));
                                                    SendMail_remainder(dsMailRemainders.Tables[0].Rows[intMailCount]["Originator"].ToString().Trim(), dsMailRemainders.Tables[0].Rows[intMailCount]["Approver_Name"].ToString().Trim(), ("REMINDER - Your approval is needed for EO Number - "
                                                                    + (ViewState["EONum"] + (" - " + ViewState["EOTitle"]))), ("Dear "
                                                                    + (dsMailRemainders.Tables[0].Rows[intMailCount]["Approver_Name"].ToString().Trim() + (" :"
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine + ("This EO was routed on "
                                                                    + (EO_Created_Date.ToString().Trim() + (" and requires your approval. "
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine + ("Please follow the link below to review this EO for approval. "
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine
                                                                    + (strURLLockMode
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine + (@"Reminder - If you were out of the office during this time and did not enable your 'Out of Office' feature, please remember to do so the next time and include the name of your back-up in the message.  This will enable the originator to 'Send to Back-up' and therefore, you would no longer be responsible for approving that EO. "
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine + ("If you are no longer in this role, please contact the originator and your Site System Owner informing" +
                                                                    " them of your replacement."
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine
                                                                    + (strURLEditMode
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine + ("EO Number is :"
                                                                    + (ViewState["EONum"]
                                                                    + (System.Environment.NewLine + ("SAP IO Number :"
                                                                    + ViewState["SAPIONum"]
                                                                    + (System.Environment.NewLine + ("EO Title is  :"
                                                                    + (ViewState["EOTitle"]
                                                                    + (System.Environment.NewLine + ("EO Location :"
                                                                    + ViewState["PlantName"]
                                                                    + (System.Environment.NewLine + ("Budget Center :"
                                                                    + (ViewState["Budget_Center_Name"]
                                                                    + (System.Environment.NewLine + ("Expected Cost :"
                                                                    + (ViewState["TotCost"]
                                                                    + (System.Environment.NewLine + ("Current Stage  :"
                                                                    + (ViewState["stage"]
                                                                    + (System.Environment.NewLine + ("Proposed Testing Start Date :"
                                                                    + (ViewState["PlannedStartDate"]
                                                                    + (System.Environment.NewLine
                                                                    + (System.Environment.NewLine + ("Thank you,"
                                                                    + (System.Environment.NewLine + ("MUREO" + "."))))))))))))))))))))))))))))))))))))))))))))))))))));
                                                }
                                                catch (Exception ex)
                                                {
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
           

            
            Response.Write("Success");
        }

        private void GetEOMandatoryInfo(int EOID)
        {


            try
            {
                EOBA objEOBABA = new EOBA();
                DataSet ds = null;

                int intResult;
                int intRow;
                string strMailIDs;
                string strCurrentStage;
                string strStatus;
                int intPlantID;
                string strEOnum;
                string strSAPIO;

                if (objEOBABA.GETEOMandatory(EOID, ref ds))
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
                                    strEOnum = "0";
                                    ViewState["EONum"] = String.Empty;
                                }
                                if (!(ds.Tables[0].Rows[0]["SAP_IO_Number"] == System.DBNull.Value))
                                {
                                    strSAPIO = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                    ViewState["SAPIONum"] = ds.Tables[0].Rows[0]["SAP_IO_Number"].ToString().Trim();
                                }
                                else
                                {
                                    strSAPIO = "0";
                                    ViewState["SAPIONum"] = String.Empty;
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
                //ds = objClsEO.GET_EO_Preliminary(ViewState("EOID"));
                if (objEOBABA.GET_EO_Preliminary(EOID, ref ds))
                {
                    if (!(ds == null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            try
                            {
                                if (!(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"] == System.DBNull.Value))
                                {
                                    ViewState["Budget_Center_Name"] = ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"].ToString().Trim();
                                }
                                else
                                {
                                    ViewState["Budget_Center_Name"] = "";
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                if (!(ds.Tables[0].Rows[0]["Total_Cost"] == System.DBNull.Value))
                                {
                                    ViewState["TotCost"] = ds.Tables[0].Rows[0]["Total_Cost"].ToString();
                                }
                                else
                                {
                                    ViewState["TotCost"] = 0;
                                }
                            }
                            catch (Exception ex)
                            {
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

            }
            catch (Exception ex)
            {
            }

            //ds = objClsEO.GETEOMandatory(EOID);


        }

        private void SendMail_remainder(string strOriginatorName, string strApprName, string strSubject, string strBody)
        {
            EOBA objEOBABA = new EOBA();
            DataSet ds = null;
             SqlParameter[] paramOut = null;
            int intPosition;
            string appName;
            string senderName;
            string orginator;
            string orginatorName;
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
            orginator = strOriginatorName;
            try
            {
                intPosition = orginator.IndexOf(" ");
                orginator = orginator.Substring(intPosition);
                orginator = orginator.Replace("-", ".");
            }
            catch (Exception ex)
            {
            }
            orginatorName = orginator;
            orginatorName = (orginatorName + "@pg.com");
            try
            {
                MailMessage objMail = new MailMessage();
                objMail.To = senderName;
                objMail.From = orginatorName;
                // Uncomment for local use
                // objMail.To = "sreevani.j@vertexcs.com; sreevani.j@vertexcs.com; sreevani.j@vertexcs.com"
                // objMail.From = "mureo@vertexcs.com"
                objMail.Subject = strSubject;
                objMail.Body = strBody;
                // SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP")
                // SmtpMail.Send(objMail)
                if ((ConfigurationSettings.AppSettings["MailLog"].ToString().ToUpper() == "Yes".ToUpper()))
                
                {
                    if (objEOBABA.addingMailDetails(objMail.From, objMail.To, objMail.Cc, objMail.Bcc, objMail.Subject, "WEBMON", ""))
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}