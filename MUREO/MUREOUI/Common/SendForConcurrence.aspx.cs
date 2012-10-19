using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using MUREOBAL;
using System.Data;
using MUREOPROP;

namespace MUREOUI.Common
{
    public partial class SendForConcurrence : System.Web.UI.Page
    {
        ObjSiteTest objSitetest = new ObjSiteTest();
        Int32 PlantID;
        Int32 ConGrpID;
        Int32 EoID;
        MailMessage objMail = new MailMessage();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;
        clsSecurity objSecurity = new clsSecurity();

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];

                if (Request.QueryString["PlantID"] == "--Select a Plant--" || string.IsNullOrEmpty(Request.QueryString["PlantID"]))
                {
                    PlantID = 0;
                }
                else
                {
                    PlantID = Convert.ToInt32(Request.QueryString["PlantID"]);
                }
                PlantID = Convert.ToInt32(Request.QueryString["PlantID"]);
                ViewState["EoID"] = Request.QueryString["EoID"];
                ConGrpID = 0;
                FillConGroups(PlantID, ConGrpID);
                DataSet ds = null;
                try
                {
                    //ds = objClsEO.GETEOMandatory(Request.QueryString["EoID"]);
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
                                try
                                {
                                    //ViewState["TotCost"] = ClsEO.GET_EO_Total_Cost(ViewState["EoID"], ViewState["stage"), "N");
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
                                    //ViewState["TotCost"] = ClsEO.GET_EO_Total_Cost(ViewState["EoID"], ViewState["stage"), "N");
                                    //'N' Means stage not changing.
                                    if (objEOBA.GET_EO_Total_Cost(Convert.ToInt32(ViewState["EOID"]), ViewState["stage"].ToString().Trim(), "N", ref paramOut))
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
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void FillConGroups(int PlantID, int ConGrpID)
        {
            DataSet dsCGName = null;
            dsCGName = new DataSet();
            ConcurrenceGroup con = new ConcurrenceGroup();
            //BusinessObject.MUREO.BusinessObject.SendConcurrence objConGrp = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
            //dsCGName = objConGrp.FillConGroups(PlantID, ConGrpID);
            if (objEOBA.FillConGroups(PlantID, ConGrpID, ref dsCGName))
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
                    lbConcGrp.DataSource = dsCGName;
                    lbConcGrp.DataTextField = "Concurrence_Group_Name";
                    lbConcGrp.DataValueField = "Concurrence_Group_ID";
                    lbConcGrp.DataBind();

                }
            }
        }

        private void AddConGroups(int conGrpID, string strComments)
        {
            DataSet dsCGName = null;
            int x = 0;
            int intPosOriginator = 0;
            string script = null;
            string PosOriginator = null;
            dsCGName = new DataSet();
            if (Request.QueryString["PlantID"] == "--Select a Plant--" | string.IsNullOrEmpty(Request.QueryString["PlantID"]))
            {
                PlantID = 0;
            }
            else
            {
                PlantID = Convert.ToInt32(Request.QueryString["PlantID"]);
            }
            SendConcurrence objConGrp = new SendConcurrence();
            if (objEOBA.FillConGroups(PlantID, conGrpID, ref dsCGName))
            {
                //dsCGName = objConGrp.FillConGroups(PlantID, conGrpID);
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
                    objSitetest.ApprNameList = dsCGName.Tables[0].Rows[0]["Approver_Name"].ToString();
                    objSitetest.ConGrpID = Convert.ToInt32(dsCGName.Tables[0].Rows[0]["Concurrence_Group_ID"]);
                }
                objSitetest.ConAppID = 0;
                objSitetest.Comment = strComments;
                objSitetest.UserName = objSecurity.UserName;
                objSitetest.EOID = Request.QueryString["EoID"];
                objSitetest.IsResponded = "No Response";
                //x = objConGrp.AddConGrpNames(objSitetest);
                if (objEOBA.AddConGrpNames(Convert.ToInt32(objSitetest.ConAppID.ToString().Trim()), Convert.ToInt32(objSitetest.EOID.ToString().Trim()), Convert.ToInt32(objSitetest.ConGrpID.ToString().Trim()), objSitetest.ApprNameList.ToString().Trim(), objSitetest.IsResponded.ToString().Trim(), objSitetest.Comment.ToString().Trim(), objSecurity.UserName.ToString().Trim(), ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }
                if (x == 0)
                {
                    MailMessage objMail = new MailMessage();
                    int rowCount = 0;
                    int i = 0;
                    int k = 0;
                    int m = 0;
                    string SendersList = null;
                    string s = null;
                    string senderName = null;
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
                        for (rowCount = 0; rowCount <= dsCGName.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            s = dsCGName.Tables[0].Rows[rowCount]["Approver_Name"].ToString();
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
                                    if (Request.QueryString["From"] == "EO")
                                    {
                                        try
                                        {
                                            clsSendMail objSendMail = new clsSendMail();
                                            bool IsMailSend = false;
                                            objSendMail.SendTo = senderName;
                                            objSendMail.SendFrom = PosOriginator + "@pg.com";
                                            objSendMail.MailSubject = "Your concurrence is requested for EO Number - " + ViewState["EONum"] + "-" + ViewState["EOTitle"];
                                            string strURLLockMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=ForEOLock&EOID=" + ViewState["EoID"];
                                            string strURLEditMode = "http://" + ViewState["servername"] + "/Common/NewEO.aspx?From=MailEdit&EOID=" + ViewState["EoID"];
                                            objSendMail.MailBody = "Dear " + a[k] + " :" + "<BR>" + "<BR>" + "Concurrence comments :" + "<br>" + txtComments.Text.Trim() + "<br>" + "<br>" + "Your concurrence is needed for this EO. Please follow the link below to review this EO." + "<BR>" + "<BR>" + "NOTE: Use this link to open the EO in 'Read Only' Mode." + "<BR>" + "<BR><a href='" + strURLLockMode + "'>" + strURLLockMode + "</a><BR>" + "<BR>" + " NOTE: Use this link will open the EO in 'Edit' Mode." + "<BR>" + "<BR><a href='" + strURLEditMode + "'>" + strURLEditMode + "</a><BR>" + "<BR>" + "EO Number is :" + ViewState["EONum"] + "<BR>" + "SAP IO Number :" + ViewState["SAPIONum"] + "<BR>" + "EO Title is  :" + ViewState["EOTitle"] + "<BR>" + "EO Location :" + ViewState["PlantName"] + "<BR>" + "Budget Center :" + ViewState["Budget_Center_Name"] + "<BR>" + "Expected Cost : $" + ViewState["TotCost"] + "<BR>" + "Current Stage  :" + ViewState["stage"] + "<BR>" + "<font color=red><b>Proposed Testing Start Date :" + ViewState["PlannedStartDate"] + "</b></font><BR>" + "<BR>" + "Thank you," + "<BR>" + ViewState["Originator"] + ".";
                                            IsMailSend = clsSendMail.fnSendMail(objSendMail);
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            clsSendMail objSendMail = new clsSendMail();
                                            bool IsMailSend = false;
                                            objSendMail.SendTo = senderName;
                                            objSendMail.SendFrom = PosOriginator + "@pg.com";
                                            objSendMail.MailSubject = "Your concurrence is requested for EO Number - " + ViewState["EONum"] + "-" + ViewState["EOTitle"];
                                            string strLockURL = "http://" + ViewState["servername"] + "/Common/ViewSiteTest.aspx?EoID=" + ViewState["EoID"];
                                            string strURL = "http://" + ViewState["servername"] + "/Common/SiteTest.aspx?From=EDIT&EoID=" + ViewState["EoID"];
                                            objSendMail.MailBody = "Dear " + a[k] + " :" + "<BR>" + "<BR>" + "Concurrence comments :" + "<br>" + txtComments.Text.Trim() + "<br>" + "<br>" + "Your concurrence is needed for this Sitetest. Please follow the link below to review this Sitetest." + "<BR>" + "<BR>" + "NOTE: Use this link to open the Sitetest in 'Read Only' Mode." + "<BR>" + "<BR><a href='" + strLockURL + "'>" + strLockURL + "</a><BR>" + "<BR>" + " NOTE: Use this link will open the Sitetest in 'Edit' Mode." + "<BR>" + "<BR><a href='" + strURL + "'>" + strURL + "</a><BR>" + "<BR>" + "EO Number  :" + ViewState["EONum"] + "<BR>" + "EO Title :" + ViewState["EOTitle"] + "<BR>" + "EO Location :" + ViewState["PlantName"] + "<BR>" + "<BR>" + "Thank you," + "<BR>" + ViewState["Originator"] + ".";
                                            IsMailSend = clsSendMail.fnSendMail(objSendMail);
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                        //script = "<script>window.returnValue ='" + x.ToString() + "';";
                        //script = script + "window.close(); </script>";
                        //Page.RegisterStartupScript("clientscript", script);
                       
                    }

                    //script = "<script>window.returnValue ='" + x.ToString() + "';";
                    //script = script + "window.close(); window.opener.location.reload(true);</script>";
                    //Page.RegisterStartupScript("clientscript", script);
                }
                else
                {
                    //script = "<script>window.returnValue = '" + x.ToString() + "';";
                    //script = script + "window.close(); window.opener.location.reload(true);</script>";
                    //Page.RegisterStartupScript("clientscript", script);
                }

            }
          script = "<script>window.returnValue ='" + x.ToString() + "';";
          script = script + "window.opener.document.forms(0)." + "btnConApp" + ".click();";
          //script = script + "window.opener.RefreshPage();";
          //script = script + "window.opener.document.forms(0)." + "btnAppPreScreen" + ".click();";
            script = script + "window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

        protected void imgSendCon_Click(object sender, ImageClickEventArgs e)
        {
            int intGrp = 0;
            for (intGrp = 0; intGrp <= lbConcGrp.Items.Count - 1; intGrp++)
            {
                if (lbConcGrp.Items[intGrp].Selected == true)
                {
                    AddConGroups(Convert.ToInt32(lbConcGrp.Items[intGrp].Value), txtComments.Text);
                }
            }
        }

        protected void imgNewCancel_Click(object sender, ImageClickEventArgs e)
        {
            string script = null;
            script = "<script>window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

    }
}