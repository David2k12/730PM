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
using System.Web.Mail;

namespace MUREOUI.Common
{
    public partial class SendForPreScreners : System.Web.UI.Page
    {
         EOBA objEOBA = new EOBA();
         SqlParameter[] paramOut = null;
         clsSecurity objSecurity = new clsSecurity();

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];
                ViewState["EoID"] = Request.QueryString["EoID"];

                DataSet ds = null;
                //ds = objClsEO.GETEOMandatory(Request.QueryString["EoID"]);
                if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EoID"]), ref ds))
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

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value)))
                                {
                                    ViewState["EOTitle"] = ds.Tables[0].Rows[0]["EO_Title"];
                                }
                                else
                                {
                                    ViewState["EOTitle"] = string.Empty;
                                }

                                if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Stage_Status"], System.DBNull.Value)))
                                {
                                    if (Session["Status"] == null)
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
                                    ViewState["Status"] = string.Empty;
                                }
                            }
                        }
                    }
                }
                //ds = objClsEO.GET_EO_Preliminary(Request.QueryString["EoID"]);
                if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(ViewState["EoID"]), ref ds))
                {
                    if ((ds != null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
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
                            try
                            {
                                //ViewState["TotCost"] = ClsEO.GET_EO_Total_Cost(ViewState["EoID"], ViewState["stage"], "N");
                                if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EoID"]), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
                                {
                                    ViewState["TotCost"] = paramOut[0].Value.ToString().Trim();
                                }

                            }
                            catch (Exception ex)
                            {
                                ViewState["TotCost"] = 0.0;

                            }
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
                FillPreScreenGrps();
            }
        }

        private void FillPreScreenGrps()
        {
            DataSet dsCGName = null;
            dsCGName = new DataSet();
            //BusinessObject.MUREO.BusinessObject.PreScrenersBo objConGrp = new BusinessObject.MUREO.BusinessObject.PreScrenersBo();
            //dsCGName = objConGrp.FillPrescreneGroups();
            if (objEOBA.FillPrescreneGroups(ref dsCGName))
            {
                if (dsCGName == null)
                {
                }
                else if (dsCGName.Tables.Count == 0)
                {
                }
                else if (dsCGName.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    ddlPrescrenNames.DataSource = dsCGName;
                    ddlPrescrenNames.DataTextField = "PreScreener_Group_Name";
                    ddlPrescrenNames.DataValueField = "PreScreener_Group_ID";
                    ddlPrescrenNames.DataBind();
                }
                ddlPrescrenNames.Items.Insert(0, "-- Select a Group --");
            }
        }

        private void AddPrescrrenUsers(int prescrenGrpID, string strComments)
        {
            //ViewState["EoID"] = 100
            DataSet dsPrescren = null;
            int x = 0;
            string script = null;
            dsPrescren = new DataSet();
            //BusinessObject.MUREO.BusinessObject.PreScrenersBo objConGrp = new BusinessObject.MUREO.BusinessObject.PreScrenersBo();

            //x = objConGrp.AddPrescreenGrpNames(Convert.ToInt32(ViewState["EoID"]), prescrenGrpID, strComments, System.Security.UserName);

            if (objEOBA.AddPrescreenGrpNames(Convert.ToInt32(ViewState["EoID"]), prescrenGrpID, strComments, objSecurity.UserName, ref paramOut))
            {
                x = Convert.ToInt32(paramOut[0].Value);
            }



            if (x == 0)
            {
                MailMessage objMail = new MailMessage();

                //Dim intPosition, i As Integer
                int intPosOriginator = 0;
                string PosOriginator = null;
                string strOriginator = null;
                string[] strMailIDs = null;

                int rowCount = 0;
                int i = 0;
                int k = 0;
                string SendersList = null;
                string s = null;
                string senderName = null;
                DataSet dsPreGroup = new DataSet();
                int EoId = 0;
                //dsPreGroup = BusinessObject.MUREO.BusinessObject.PreScrenersBo.getPreGroupUsers(ViewState["EoID"]);
                if (objEOBA.getPreGroupUsers(Convert.ToInt32(ViewState["EoID"]), ref dsPreGroup))
                {
                    if (dsPreGroup == null)
                    {
                    }
                    else if (dsPreGroup.Tables.Count == 0)
                    {
                    }
                    else if (dsPreGroup.Tables[0].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        for (rowCount = 0; rowCount <= dsPreGroup.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            s = dsPreGroup.Tables[0].Rows[rowCount]["Approver_Name"].ToString();
                            string[] a = null;
                            a = s.Split(',');

                            for (k = 0; k <= a.Length - 1; k++)
                            {
                                try
                                {
                                    string appName = a[k];
                                    i = appName.IndexOf(" ");
                                    if (i > -1)
                                    {
                                        appName = appName.Substring(i);
                                    }

                                    appName = appName.Replace("-", ".");
                                    appName = appName.Replace(" ", "");
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
                                    clsSendMail objSendMail = new clsSendMail();
                                    bool IsMailSend = false;
                                    objSendMail.SendTo = senderName;
                                    objSendMail.SendFrom = PosOriginator + "@pg.com";
                                    objSendMail.MailSubject = "Please Prescreen this new EO (Number - " + ViewState["EONum"] + ") titled as " + ViewState["EOTitle"];

                                    //objMail.To = senderName
                                    //objMail.From = PosOriginator & "@pg.com"
                                    //objMail.Subject = "Please Prescreen this new EO (Number - " & ViewState("EONum") & ") titled as " & ViewState("EOTitle")
                                    //objMail.BodyFormat = MailFormat.Html
                                    string strURLLockMode = null;
                                    strURLLockMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EoID"];

                                    string strURLEditMode = null;
                                    strURLEditMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EoID"];

                                    //objMail.Body = "Dear " & a(k) & " :" & _
                                    objSendMail.MailBody = "Dear " + a[k] + " :" + "<BR>" + "<BR>" + "Prescreen comments :" + "<BR>" + txtComments.Text.Trim() + "<BR>" + "<BR>" + "Please follow the appropriate link below for Pre-screen alignment." + "<BR>" + "Granting this alignment means you have evaluated the EO for budget funding versus your category trendline and test plan technical direction to determine the readiness of this EO to route." + "<BR>" + "<BR>" + "Please follow the link below to see this EO." + "<BR>" + "<BR>" + "NOTE:  Use this link to open the EO in 'Read Only' Mode." + "<BR>" + "<BR><a href='" + strURLLockMode + "'>" + strURLLockMode + "</a>" + "<BR>" + "<BR>" + "NOTE: Use this link will open the EO in 'Edit' Mode." + "<BR>" + "<BR><a href='" + strURLEditMode + "'>" + strURLEditMode + "</a>" + "<BR>" + "<BR>" + "<BR>" + "<BR>" + "EO Number is :" + ViewState["EONum"] + "<BR>" + "SAP IO Number :" + ViewState["SAPIONum"] + "<BR>" + "EO Title is  :" + ViewState["EOTitle"] + "<BR>" + "EO Location :" + ViewState["PlantName"] + "<BR>" + "Budget Center :" + ViewState["Budget_Center_Name"] + "<BR>" + "Expected Cost : $" + ViewState["TotCost"] + "<BR>" + "Current Stage  :" + ViewState["stage"] + "<BR>" + "<font color=red><b>Proposed Testing Start Date :" + ViewState["PlannedStartDate"] + "</b></font><BR>" + "<BR>" + "Thank you," + "<BR>" + objSecurity.UserName + ".";
                                    //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("SMTP")
                                    //SmtpMail.Send(objMail)
                                    IsMailSend = clsSendMail.fnSendMail(objSendMail);

                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                    }
                }
                //we have to send mails top users...
                //script = "<script>window.returnValue ='" + x.ToString() + "';";
                ////script = "<script>window.returnValue = " + x + ";"
                //script = script + "window.close(); </script>";
                //Page.RegisterStartupScript("clientscript", script);

            }
            else
            {
                //script = "<script>window.returnValue = '" + x.ToString() + "';";
                //script = script + "window.close(); </script>";
                //Page.RegisterStartupScript("clientscript", script);

            }

            script = "<script>window.returnValue ='" + x.ToString() + "';";
            script = script + "window.opener.document.forms(0)." + "btnAppPreScreen" + ".click();";
            //script = script + "window.opener.RefreshPage();window.close();</script>";
            script = script + "window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

        protected void imgSendCon_Click(object sender, ImageClickEventArgs e)
        {
            int prescrenGrpID = 0;
            int x = 0;
            if (ddlPrescrenNames.SelectedValue == "-- Select a Group --")
            {
                prescrenGrpID = 0;
            }
            else
            {
                prescrenGrpID = Convert.ToInt32(ddlPrescrenNames.SelectedValue);
            }
            if (ddlPrescrenNames.SelectedValue == "-- Select a Group --")
            {
            }
            else
            {
                AddPrescrrenUsers(prescrenGrpID, txtComments.Text);
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            string script = null;
            script = "<script>window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

    }
}