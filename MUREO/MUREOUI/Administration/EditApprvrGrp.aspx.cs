using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Configuration;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class EditApprvrGrp : System.Web.UI.Page
    {
        #region "Variable Declaration"
        Approver app = new Approver();
        static DataSet dsAppGrp;
        string script;
        DataSet dsApprovers=new DataSet();
        DataSet dsAdditionalApprovers1=new DataSet();
        DataSet dsAdditionalApprovers2=new DataSet();
        DataSet dsAdditionalApprovers3=new DataSet();
        DataSet dsAdditionalApprovers4=new DataSet();
        static int App_Grp_ID;
        static string Cat_Name;
        static string Brand_Name;
        static string Plant_Name;
        static string EO_Mode;
        int appfound;
        bool SiteHSESet;
        bool GBUHSESet;
        bool SitePlanSet;
        bool CentralPlanSet;
        bool SiteLeaderSet;
        bool SiteFinanceSet;
        bool PSInitSet;
        bool ProdResSet;
        bool PSRASet;
        bool TimingSet;
        bool QASet;
        bool CentralQASet;
        bool AdditionalAppr1;
        bool AdditionalAppr2;
        bool AdditionalAppr3;
        clsSecurity cls = new clsSecurity();
        bool AdditionalAppr4;
        bool StdOfficeSet;
        bool SiteContactSet;
        bool SAPCCCSet;
        #endregion
        DataSet dsBrandbyCat = new DataSet();
        #region "Page_Events"
        //Sub 	        :   Page_Load 
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay              1.0           created

        //***************************************************
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here

            if (!Page.IsPostBack)
            {
                trSAP.Visible = false;

                if (Request.QueryString["App_Grp_ID"] == null | Request.QueryString["Cat_Name"] == null | Request.QueryString["Brd_Name"] == null | Request.QueryString["Plt_Name"] == null | Request.QueryString["EO_Mode"] == null)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an approval group to view this form'); window.location = 'ViewApprovalGroup.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (Request.QueryString["App_Grp_ID"] == string.Empty | Request.QueryString["Cat_Name"] == string.Empty | Request.QueryString["Brd_Name"] == string.Empty | Request.QueryString["Plt_Name"] == string.Empty | Request.QueryString["EO_Mode"] == string.Empty)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an approval group to view this form');window.location = 'ViewApprovalGroup.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                App_Grp_ID = Convert.ToInt32(Request.QueryString["App_Grp_ID"]);
                //Get the approval group details from the view page
                Cat_Name = Request.QueryString["Cat_Name"];
                Brand_Name = Request.QueryString["Brd_Name"];
                Plant_Name = Request.QueryString["Plt_Name"];
                EO_Mode = Request.QueryString["EO_Mode"];
                GetApprovalGroupInfo();
                //Get approval group name
                FillApprovalGroupCategory();
                //Get category name
                FillApporvalGroupPlant();
                //Get plant name
                SetApprGrpFields();
                //Setup form fields with selected values

                if (app.FillEOAdditionalApprover1ByFunctionBO(1, ref dsAdditionalApprovers1))
                {
                    //If dataset is null, quit
                    if (dsAdditionalApprovers1 == null)
                    {
                        NoRecords();
                    }
                    else if (dsAdditionalApprovers1.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsAdditionalApprovers1.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {

                        for (int rowCt = 0; rowCt <= dsAdditionalApprovers1.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsAdditionalApprovers1.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("additional approver #1"))
                            {
                                drpAdditionalAppr1.Items.Add(Convert.ToString(dsAdditionalApprovers1.Tables[0].Rows[rowCt]["Approver_Name"]));
                            }
                        }
                    }
                }

                if (app.FillEOAdditionalApprover1ByFunctionBO(2, ref dsAdditionalApprovers2))
                {
                    //If dataset is null, quit
                    if (dsAdditionalApprovers2 == null)
                    {
                        NoRecords();
                    }
                    else if (dsAdditionalApprovers2.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsAdditionalApprovers2.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {

                        for (int rowCt = 0; rowCt <= dsAdditionalApprovers2.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsAdditionalApprovers2.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("additional approver #2"))
                            {
                                drpAdditionalAppr2.Items.Add(Convert.ToString(dsAdditionalApprovers2.Tables[0].Rows[rowCt]["Approver_Name"]));
                            }
                        }
                    }
                }


                if (app.FillEOAdditionalApprover1ByFunctionBO(3, ref dsAdditionalApprovers3))
                {
                    //If dataset is null, quit
                    if (dsAdditionalApprovers3 == null)
                    {
                        NoRecords();
                    }
                    else if (dsAdditionalApprovers3.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsAdditionalApprovers3.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {

                        for (int rowCt = 0; rowCt <= dsAdditionalApprovers3.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsAdditionalApprovers3.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("additional approver #3"))
                            {
                                drpAdditionalAppr3.Items.Add(Convert.ToString(dsAdditionalApprovers3.Tables[0].Rows[rowCt]["Approver_Name"]));
                            }
                        }
                    }
                }

                if (app.FillEOAdditionalApprover1ByFunctionBO(4, ref dsAdditionalApprovers4))
                {

                    //If dataset is null, quit
                    if (dsAdditionalApprovers4 == null)
                    {
                        NoRecords();
                    }
                    else if (dsAdditionalApprovers4.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsAdditionalApprovers4.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {

                        for (int rowCt = 0; rowCt <= dsAdditionalApprovers4.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsAdditionalApprovers4.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("additional approver #4"))
                            {
                                drpAdditionalAppr4.Items.Add(Convert.ToString(dsAdditionalApprovers4.Tables[0].Rows[rowCt]["Approver_Name"]));
                            }
                        }
                    }
                }

                if (app.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0, ref dsApprovers))
                {
                    //Get info of all approvers and functions from db
                    if (dsApprovers == null)
                    {
                        NoRecords();
                    }
                    else if (dsApprovers.Tables.Count == 0)
                    {
                        NoRecords();
                    }
                    else if (dsApprovers.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();

                    }
                    else
                    {
                        for (int rowCt = 0; rowCt <= dsApprovers.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("site hs&e resource"))
                            {
                                drpSiteHSE.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("gbu hs&e resource"))
                            {
                                drpGBUHSE.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("site planning"))
                            {
                                drpSitePlan.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("central planning"))
                            {
                                drpCentralPlan.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("site leadership"))
                            {
                                drpSiteLeader.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("site finance"))
                            {
                                drpSiteFinance.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("ps initiative manager"))
                            {
                                drpPSInitiative.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("products research"))
                            {
                                drpProductsResearch.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("ps&ra"))
                            {
                                drpPSRA.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("timing gate exception"))
                            {
                                drpTimingGate.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("qa"))
                            {
                                drpQA.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("central qa"))
                            {
                                drpCentralQA.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("standards office"))
                            {
                                drpStdOffice.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("site contact"))
                            {
                                drpSiteContact.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));

                            }
                            else if (Function_Name.ToLower().StartsWith("sap cost center coordinator"))
                            {
                                drpSAPCCC.Items.Add(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]));


                                //Added by David on Dec 02, 2011
                                //ElseIf Function_Name.ToLower().StartsWith("additional approver #1") Then
                                //    drpAdditionalAppr1.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //ElseIf Function_Name.ToLower().StartsWith("additional approver #2") Then
                                //    drpAdditionalAppr2.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //ElseIf Function_Name.ToLower().StartsWith("additional approver #3") Then
                                //    drpAdditionalAppr3.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //ElseIf Function_Name.ToLower().StartsWith("additional approver #4") Then
                                //    drpAdditionalAppr4.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                            }
                        }
                    }
                }


                for (int rowCt = 0; rowCt <= dsAppGrp.Tables[0].Rows.Count - 1; rowCt++)
                {
                    string Function_Name = Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Function_Name"]);
                    if (Function_Name.ToLower().StartsWith("site hs&e resource") & drpSiteHSE.Items.Count != 0)
                    {
                        drpSiteHSE.ClearSelection();
                        ListItem SiteHSEListItem = drpSiteHSE.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (SiteHSEListItem == null)
                        {
                            //drpSiteHSE.Items.Clear()
                            drpSiteHSE.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpSiteHSE.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            SiteHSEListItem.Selected = true;
                            SiteHSESet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("gbu hs&e resource") & drpGBUHSE.Items.Count != 0)
                    {
                        drpGBUHSE.ClearSelection();
                        ListItem GBUListItem = drpGBUHSE.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (GBUListItem == null)
                        {
                            // drpGBUHSE.Items.Clear()
                            drpGBUHSE.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpGBUHSE.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            GBUListItem.Selected = true;
                            GBUHSESet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("site planning") & drpSitePlan.Items.Count != 0)
                    {
                        drpSitePlan.ClearSelection();
                        ListItem SitePlanListItem = drpSitePlan.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (SitePlanListItem == null)
                        {
                            //drpSitePlan.Items.Clear()
                            drpSitePlan.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpSitePlan.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                            SitePlanSet = true;
                        }
                        else
                        {
                            SitePlanListItem.Selected = true;
                            SitePlanSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("central planning") & drpCentralPlan.Items.Count != 0)
                    {
                        drpCentralPlan.ClearSelection();
                        ListItem CentralPlanListItem = drpCentralPlan.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (CentralPlanListItem == null)
                        {
                            //drpCentralPlan.Items.Clear()
                            drpCentralPlan.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpCentralPlan.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            CentralPlanListItem.Selected = true;
                            CentralPlanSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("site leadership") & drpSiteLeader.Items.Count != 0)
                    {
                        drpSiteLeader.ClearSelection();
                        ListItem SiteLeaderListItem = drpSiteLeader.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (SiteLeaderListItem == null)
                        {
                            //drpSiteLeader.Items.Clear()
                            drpSiteLeader.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpSiteLeader.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            SiteLeaderListItem.Selected = true;
                            SiteLeaderSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("site finance") & drpSiteFinance.Items.Count != 0)
                    {
                        drpSiteFinance.ClearSelection();
                        ListItem SiteFinanceListItem = drpSiteFinance.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (SiteFinanceListItem == null)
                        {
                            // drpSiteFinance.Items.Clear()
                            drpSiteFinance.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpSiteFinance.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            SiteFinanceListItem.Selected = true;
                            SiteFinanceSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("ps initiative manager") & drpPSInitiative.Items.Count != 0)
                    {
                        drpPSInitiative.ClearSelection();
                        ListItem PSInitListItem = drpPSInitiative.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (PSInitListItem == null)
                        {
                            //drpPSInitiative.Items.Clear()
                            drpPSInitiative.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpPSInitiative.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            PSInitListItem.Selected = true;
                            PSInitSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("products research") & drpProductsResearch.Items.Count != 0)
                    {
                        drpProductsResearch.ClearSelection();
                        ListItem PRListItem = drpProductsResearch.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (PRListItem == null)
                        {
                            //drpProductsResearch.Items.Clear()
                            drpProductsResearch.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpProductsResearch.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            PRListItem.Selected = true;
                            ProdResSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("ps&ra") & drpPSRA.Items.Count != 0)
                    {
                        drpPSRA.ClearSelection();
                        ListItem PSRAListItem = drpPSRA.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (PSRAListItem == null)
                        {
                            //drpPSRA.Items.Clear()
                            drpPSRA.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpPSRA.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            PSRAListItem.Selected = true;
                            PSRASet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("timing gate exception") & drpTimingGate.Items.Count != 0)
                    {
                        drpTimingGate.ClearSelection();
                        ListItem TimingGateListItem = drpTimingGate.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (TimingGateListItem == null)
                        {
                            //drpTimingGate.Items.Clear()
                            drpTimingGate.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpTimingGate.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            TimingGateListItem.Selected = true;
                            TimingSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("qa") & drpQA.Items.Count != 0)
                    {
                        drpQA.ClearSelection();
                        ListItem QAListItem = drpQA.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (QAListItem == null)
                        {
                            // drpQA.Items.Clear()
                            drpQA.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpQA.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            QAListItem.Selected = true;
                            QASet = true;
                        }


                    }
                    else if (Function_Name.ToLower().StartsWith("central qa") & drpCentralQA.Items.Count != 0)
                    {
                        drpCentralQA.ClearSelection();
                        ListItem CentralQAListItem = drpCentralQA.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (CentralQAListItem == null)
                        {
                            // drpQA.Items.Clear()
                            drpCentralQA.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpCentralQA.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            CentralQAListItem.Selected = true;
                            CentralQASet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("standards office") & drpStdOffice.Items.Count != 0)
                    {
                        drpStdOffice.ClearSelection();
                        ListItem StdOfficeListItem = drpStdOffice.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (StdOfficeListItem == null)
                        {
                            //drpStdOffice.Items.Clear()
                            drpStdOffice.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpStdOffice.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            StdOfficeListItem.Selected = true;
                            StdOfficeSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("site contact") & drpSiteContact.Items.Count != 0)
                    {
                        drpSiteContact.ClearSelection();
                        ListItem SiteContactListItem = drpSiteContact.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (SiteContactListItem == null)
                        {
                            //drpSiteContact.Items.Clear()
                            drpSiteContact.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpSiteContact.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            SiteContactListItem.Selected = true;
                            SiteContactSet = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("sap cost center coordinator") & drpSAPCCC.Items.Count != 0)
                    {
                        drpSAPCCC.ClearSelection();
                        ListItem SAPCCCListItem = drpSAPCCC.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (SAPCCCListItem == null)
                        {
                            drpSAPCCC.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpSAPCCC.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            SAPCCCListItem.Selected = true;
                            SAPCCCSet = true;
                        }


                        //Added by David on Dec 02, 2011

                    }
                    else if (Function_Name.ToLower().StartsWith("additional approver #1") & drpAdditionalAppr1.Items.Count != 0)
                    {
                        drpAdditionalAppr1.ClearSelection();
                        ListItem AdddtlAppr1ListItem = drpAdditionalAppr1.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (AdddtlAppr1ListItem == null)
                        {
                            drpAdditionalAppr1.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpAdditionalAppr1.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            AdddtlAppr1ListItem.Selected = true;
                            AdditionalAppr1 = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("additional approver #2") & drpAdditionalAppr2.Items.Count != 0)
                    {
                        drpAdditionalAppr2.ClearSelection();
                        ListItem AdddtlAppr2ListItem = drpAdditionalAppr2.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (AdddtlAppr2ListItem == null)
                        {
                            drpAdditionalAppr2.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpAdditionalAppr2.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            AdddtlAppr2ListItem.Selected = true;
                            AdditionalAppr2 = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("additional approver #3") & drpAdditionalAppr3.Items.Count != 0)
                    {
                        drpAdditionalAppr3.ClearSelection();
                        ListItem AdddtlAppr3ListItem = drpAdditionalAppr3.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (AdddtlAppr3ListItem == null)
                        {
                            drpAdditionalAppr3.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpAdditionalAppr3.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            AdddtlAppr3ListItem.Selected = true;
                            AdditionalAppr3 = true;
                        }

                    }
                    else if (Function_Name.ToLower().StartsWith("additional approver #4") & drpAdditionalAppr4.Items.Count != 0)
                    {
                        drpAdditionalAppr4.ClearSelection();
                        ListItem AdddtlAppr4ListItem = drpAdditionalAppr4.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                        if (AdddtlAppr4ListItem == null)
                        {
                            drpAdditionalAppr4.Items.Add(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"]));
                            drpAdditionalAppr4.Items.FindByText(Convert.ToString(dsAppGrp.Tables[0].Rows[rowCt]["Approver_Name"])).Selected = true;
                        }
                        else
                        {
                            AdddtlAppr4ListItem.Selected = true;
                            AdditionalAppr4 = true;
                        }


                    }
                }


                if (drpSiteHSE.Items.Count == 0)
                {
                    drpSiteHSE.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpSiteHSE.Items.Count != 0 & SiteHSESet == false)
                {
                    drpSiteHSE.Items.Insert(0, "-- Select an approver --");
                }
                if (drpGBUHSE.Items.Count == 0)
                {
                    drpGBUHSE.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpGBUHSE.Items.Count != 0 & GBUHSESet == false)
                {
                    drpGBUHSE.Items.Insert(0, "-- Select an approver --");
                }
                if (drpSitePlan.Items.Count == 0)
                {
                    drpSitePlan.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpSitePlan.Items.Count != 0 & SitePlanSet == false)
                {
                    drpSitePlan.Items.Insert(0, "-- Select an approver --");
                }
                if (drpCentralPlan.Items.Count == 0)
                {
                    drpCentralPlan.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpCentralPlan.Items.Count != 0 & CentralPlanSet == false)
                {
                    drpCentralPlan.Items.Insert(0, "-- Select an approver --");
                }
                if (drpSiteLeader.Items.Count == 0)
                {
                    drpSiteLeader.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpSiteLeader.Items.Count != 0 & SiteLeaderSet == false)
                {
                    drpSiteLeader.Items.Insert(0, "-- Select an approver --");
                }
                if (drpSiteFinance.Items.Count == 0)
                {
                    drpSiteFinance.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpSiteFinance.Items.Count != 0 & SiteFinanceSet == false)
                {
                    drpSiteFinance.Items.Insert(0, "-- Select an approver --");
                }
                if (drpPSInitiative.Items.Count == 0)
                {
                    drpPSInitiative.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpPSInitiative.Items.Count != 0 & PSInitSet == false)
                {
                    drpPSInitiative.Items.Insert(0, "-- Select an approver --");
                }
                if (drpProductsResearch.Items.Count == 0)
                {
                    drpProductsResearch.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpProductsResearch.Items.Count != 0 & ProdResSet == false)
                {
                    drpProductsResearch.Items.Insert(0, "-- Select an approver --");
                }
                if (drpPSRA.Items.Count == 0)
                {
                    drpPSRA.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpPSRA.Items.Count != 0 & PSRASet == false)
                {
                    drpPSRA.Items.Insert(0, "-- Select an approver --");
                }
                if (drpTimingGate.Items.Count == 0)
                {
                    drpTimingGate.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpTimingGate.Items.Count != 0 & TimingSet == false)
                {
                    drpTimingGate.Items.Insert(0, "-- Select an approver --");
                }

                if (drpQA.Items.Count == 0)
                {
                    drpQA.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpQA.Items.Count != 0 & QASet == false)
                {
                    drpQA.Items.Insert(0, "-- Select an approver --");
                }

                if (drpCentralQA.Items.Count == 0)
                {
                    drpCentralQA.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpCentralQA.Items.Count != 0 & CentralQASet == false)
                {
                    drpCentralQA.Items.Insert(0, "-- Select an approver --");
                }

                if (drpStdOffice.Items.Count == 0)
                {
                    drpStdOffice.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpStdOffice.Items.Count != 0 & StdOfficeSet == false)
                {
                    drpStdOffice.Items.Insert(0, "-- Select an approver --");
                }
                if (drpSiteContact.Items.Count == 0)
                {
                    drpSiteContact.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpSiteContact.Items.Count != 0 & SiteContactSet == false)
                {
                    drpSiteContact.Items.Insert(0, "-- Select an approver --");
                }
                if (drpSAPCCC.Items.Count == 0)
                {
                    drpSAPCCC.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpSAPCCC.Items.Count != 0 & SAPCCCSet == false)
                {
                    drpSAPCCC.Items.Insert(0, "-- Select an approver --");
                }

                //Added by David on Dec 02, 2011

                if (drpAdditionalAppr1.Items.Count == 0)
                {
                    drpAdditionalAppr1.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpAdditionalAppr1.Items.Count != 0 & AdditionalAppr1 == false)
                {
                    drpAdditionalAppr1.Items.Insert(0, "-- Select an approver --");
                }

                if (drpAdditionalAppr2.Items.Count == 0)
                {
                    drpAdditionalAppr2.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpAdditionalAppr2.Items.Count != 0 & AdditionalAppr2 == false)
                {
                    drpAdditionalAppr2.Items.Insert(0, "-- Select an approver --");
                }

                if (drpAdditionalAppr3.Items.Count == 0)
                {
                    drpAdditionalAppr3.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpAdditionalAppr3.Items.Count != 0 & AdditionalAppr3 == false)
                {
                    drpAdditionalAppr3.Items.Insert(0, "-- Select an approver --");
                }

                if (drpAdditionalAppr4.Items.Count == 0)
                {
                    drpAdditionalAppr4.Items.Insert(0, "-- No approvers found --");
                }
                else if (drpAdditionalAppr4.Items.Count != 0 & AdditionalAppr4 == false)
                {
                    drpAdditionalAppr4.Items.Insert(0, "-- Select an approver --");
                }


            }
        }
        #endregion
        #region "User_Defined_Functions"
        //Sub 	        :   SetApprGrpFields
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Populates form fields with approver group related info
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void SetApprGrpFields()
        {
            drpCategory.Items.FindByText(Cat_Name).Selected = true;
            drpPlant.Items.FindByText(Plant_Name).Selected = true;
            rblEOorSite.DataValueField = EO_Mode;
            rblEOorSite.SelectedValue = EO_Mode;
            DataSet dsapp = new DataSet();
            if (app.FillApprovalGroupCategorybyBrandBO(Convert.ToInt32(drpCategory.SelectedValue), ref dsapp))
            {
                //Sets up EO/Site Test/Other radio button value
                drpBrand.DataSource = dsapp;
                    //Sets up Brand segment drop down
                drpBrand.DataTextField = "Brand_Segment_Name";
                drpBrand.DataValueField = "Brand_Segment_ID";
                drpBrand.DataBind();
                drpBrand.Items.FindByText(Brand_Name).Selected = true;
            }
        }
        //Sub 	        :   GetApprovalGroupInfo
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Retrieves approver group name and other related info
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void GetApprovalGroupInfo()
        {
            DataSet dsAllApprvrs = new DataSet();
            if (app.FillEOApprovalGroupDetailsBO(App_Grp_ID, ref dsAppGrp))
            {
                if (app.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0, ref dsAllApprvrs))
                {
                    if (dsAppGrp == null)
                    {
                        NoRecords();
                    }
                    else if (dsAppGrp.Tables.Count == 0)
                    {
                        NoRecords();
                    }
                    else if (dsAppGrp.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {
                        if (dsAllApprvrs == null)
                        {
                            NoRecords();
                        }
                        else if (dsAllApprvrs.Tables.Count == 0)
                        {
                            NoRecords();
                        }
                        else if (dsAllApprvrs.Tables[0].Rows.Count == 0)
                        {
                            NoRecords();
                        }
                        else
                        {
                            txtApproverGroup.Text = Convert.ToString(dsAppGrp.Tables[0].Rows[0]["Approval_Group_Name"]);
                        }
                    }
                }
            }
        }
        //Sub 	        :   FillApprovalGroupCategory
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Populates category drop down 
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void FillApprovalGroupCategory()
        {
            DataSet dsCategory = new DataSet();
            if(app.FillApprovalGroupCategoryBO(0,ref dsCategory))
            {

            //Retrieve all category info from the db
            //If dataset is null, quit
            if (dsCategory == null)
            {
                NoRecords();
                //If no data, quit
            }
            else if (dsCategory.Tables.Count == 0)
            {
                NoRecords();
            }
            else if (dsCategory.Tables[0].Rows.Count == 0)
            {
                NoRecords();
                //Setup data source for the drop down
            }
            else
            {
                drpCategory.DataSource = dsCategory;
                drpCategory.DataTextField = "Category_Name";
                drpCategory.DataValueField = "Category_ID";
                drpCategory.DataBind();
            }
            drpCategory.Items.Insert(0, "-- Select a Category --");
            }
        }
        //Sub 	        :   NoRecords
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void NoRecords()
        {
            script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        //Sub 	        :   FillApporvalGroupPlant
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Populates Plant drop down
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void FillApporvalGroupPlant()
        {
            DataSet dsPlant = new DataSet();
            if (app.FillApproverPlantsBO(0, ref dsPlant))
            {
                //Retrieve all plant info from the db
                //If dataset is null, quit
                if (dsPlant == null)
                {
                    NoRecords();
                    //If no data, quit
                }
                else if (dsPlant.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsPlant.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                    //Setup datasource for plant drop down
                }
                else
                {
                    drpPlant.DataSource = dsPlant;
                    drpPlant.DataTextField = "Plant_Name";
                    drpPlant.DataValueField = "Plant_ID";
                    drpPlant.DataBind();
                }
                drpPlant.Items.Insert(0, "-- Select a Plant --");
            }
        }
        //Sub 	        :   InsertOperationMessage
        //Written BY	    :	Vijay
        //parameters     :	Update result
        //Purpose	    :   Displays Update success/failure message based on update result value (0 - success 1 - failure)
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void InsertOperationMessage(int result)
        {
            if (result == 0)
            {
                script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location ='ViewApprovalGroup.aspx'; ";
            }
            else if (result == 1)
            {
                script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
            }
            else
            {
                script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); ";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        #endregion
        #region "Drop_Down_List_Events"
        //Sub 	        :   Category selectedindexchanged event
        //Written BY	    :	Vijay
        //parameters     :	
        //Purpose	    :   Displays brand segment according to user selected category 
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void drpCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //If no category selection, display appropriate value
            if (drpCategory.SelectedIndex == 0)
            {
                drpBrand.Items.Clear();
                drpBrand.Items.Insert(0, "-- No values Found --");
                //Setup datasource for the brand segment
            }
            else
            {
                //drpBrand.DataSource = Approver.FillApprovalGroupCategorybyBrandBO(drpCategory.SelectedValue) 'Retrieves Brand info for a particular category
                if (app.FillApprovalGroupCategorybyBrandBO(Convert.ToInt32(drpCategory.SelectedValue), ref dsBrandbyCat))
                {
                    //Retrieves Brand info for a particular category
                    if ((dsBrandbyCat != null) & dsBrandbyCat.Tables[0].Rows.Count != 0)
                    {
                        drpBrand.DataSource = dsBrandbyCat;
                        drpBrand.DataTextField = "Brand_Segment_Name";
                        drpBrand.DataValueField = "Brand_Segment_ID";
                        drpBrand.DataBind();
                    }
                    else
                    {
                        drpBrand.Items.Clear();
                        drpBrand.Items.Insert(0, "-- No values Found --");
                    }
                }
            }
        }
        //Sub 	        :   rblEOorSite selectedindexchanged event
        //Written BY	    :	Vijay
        //parameters     :	
        //Purpose	    :   Displays approver group text by concatenating user selected plant and EO mode
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void rblEOorSite_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string EOMode = null;
            string plantName = null;
            plantName = drpPlant.SelectedItem.Text;
            EOMode = rblEOorSite.SelectedItem.Text;
            if (!(drpPlant.SelectedIndex == 0))
            {
                txtApproverGroup.Text = plantName + " " + EOMode;
            }
            else
            {
                txtApproverGroup.Text = "";
            }
        }
        //Sub 	        :   Plant selectedindexchanged event
        //Written BY	    :	Vijay
        //parameters     :	
        //Purpose	    :   Displays approver group text with concatenated user selected Plant and EOmode values
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void drpPlant_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!(drpPlant.SelectedIndex == 0))
            {
                txtApproverGroup.Text = drpPlant.SelectedItem.Text + " " + rblEOorSite.SelectedItem.Text;
            }
            else
            {
                txtApproverGroup.Text = "";
            }
        }
        #endregion
        #region "Button_Events"
        //Sub 	        :   Submit click event
        //Written BY	    :	Vijay
        //parameters     :	
        //Purpose	    :   Updates approver group form details to the db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************

        protected void ImgSubmit_Click(object sender, EventArgs e)
        {
            char EOMOdedb = '\0';
            string ApproverList = null;
            try
            {
                switch (rblEOorSite.SelectedItem.Text)
                {
                    //Set EO Mode flag according to user selection
                    case "EO":
                        EOMOdedb = 'E';
                        break;
                    case "Site Test":
                        EOMOdedb = 'S';
                        break;
                    case "Other":
                        EOMOdedb = 'O';
                        break;
                }
                if (drpCategory.SelectedIndex == 0)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["CategoryErr"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpBrand.SelectedValue.ToLower().StartsWith("-- no values found --"))
                {
                    script = "alert('" + ConfigurationManager.AppSettings["BrandErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpPlant.SelectedIndex == 0)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["PlantErr"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (txtApproverGroup.Text.Trim() == string.Empty)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ApproverGroupErr"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                //For i As Integer = 0 To drgAppGrp.Items.Count - 1 'Iterate through the datagrid control list and add approver list
                //    If ApproverList = String.Empty Then
                //        If Not CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower().StartsWith("-- select an approver --") And Not CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower().StartsWith("-- no approvers found --") Then
                //            ApproverList = drgAppGrp.Items(i).Cells(0).Text & ":" & CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedItem.Text()
                //        End If
                //    Else
                //        If Not CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower().StartsWith("-- select an approver --") And Not CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower().StartsWith("-- no approvers found --") Then
                //            ApproverList &= "," & drgAppGrp.Items(i).Cells(0).Text & ":" & CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedItem.Text()
                //        End If
                //    End If
                //Next

                if (!drpSiteHSE.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpSiteHSE.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Site HS&E Resource:" + drpSiteHSE.SelectedValue + ",";
                }
                if (!drpGBUHSE.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpGBUHSE.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "GBU HS&E Resource:" + drpGBUHSE.SelectedValue + ",";
                }
                if (!drpSitePlan.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpSitePlan.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Site Planning:" + drpSitePlan.SelectedValue + ",";
                }
                if (!drpCentralPlan.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpCentralPlan.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Central Planning:" + drpCentralPlan.SelectedValue + ",";
                }
                if (!drpSiteLeader.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpSiteLeader.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Site Leadership:" + drpSiteLeader.SelectedValue + ",";
                }
                if (!drpSiteFinance.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpSiteFinance.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Site Finance:" + drpSiteFinance.SelectedValue + ",";
                }
                if (!drpPSInitiative.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpPSInitiative.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "PS Initiative Manager:" + drpPSInitiative.SelectedValue + ",";
                }
                if (!drpProductsResearch.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpProductsResearch.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Products Research:" + drpProductsResearch.SelectedValue + ",";
                }
                if (!drpPSRA.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpPSRA.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "PS&RA:" + drpPSRA.SelectedValue + ",";
                }
                if (!drpTimingGate.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpTimingGate.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Timing Gate Exception:" + drpTimingGate.SelectedValue + ",";
                }
                if (!drpQA.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpQA.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "QA:" + drpQA.SelectedValue + ",";
                }

                if (!drpCentralQA.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpCentralQA.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Central QA:" + drpCentralQA.SelectedValue + ",";
                }

                if (!drpStdOffice.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpStdOffice.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Standards Office:" + drpStdOffice.SelectedValue + ",";
                }
                if (!drpSiteContact.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpSiteContact.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Site Contact:" + drpSiteContact.SelectedValue + ",";
                }
                if (!drpSAPCCC.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpSAPCCC.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "SAP Cost Center Coordinator:" + drpSAPCCC.SelectedValue + ",";
                }


                //Added by December 02, 2011

                if (!drpAdditionalAppr1.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpAdditionalAppr1.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Additional approver #1:" + drpAdditionalAppr1.SelectedValue + ",";
                }


                if (!drpAdditionalAppr2.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpAdditionalAppr2.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Additional approver #2:" + drpAdditionalAppr2.SelectedValue + ",";
                }


                if (!drpAdditionalAppr3.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpAdditionalAppr3.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Additional approver #3:" + drpAdditionalAppr3.SelectedValue + ",";
                }


                if (!drpAdditionalAppr4.SelectedValue.ToLower().StartsWith("-- no approvers found --") & !drpAdditionalAppr4.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    ApproverList += "Additional approver #4:" + drpAdditionalAppr4.SelectedValue + ",";
                }



                string strApprovers = null;
                if (ApproverList == null | string.IsNullOrEmpty(ApproverList) | ApproverList == string.Empty)
                {
                    strApprovers = "";
                }
                else
                {
                    strApprovers = ApproverList.Remove(ApproverList.LastIndexOf(","), 1);
                    //Remove the last ',' from the string
                }


                if (drpSitePlan.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ApproverGrpSitePlan"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpSiteFinance.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ApproverGrpSiteFinance"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpQA.SelectedValue.ToLower().StartsWith("-- select an approver --"))
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ApproverGrpSiteQA"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }



                int result = -1;
                SqlParameter[] paramout = new SqlParameter[1];

                if (app.InsertEOApprovalGroupBO(Convert.ToInt32(Request.QueryString["App_Grp_ID"]), txtApproverGroup.Text, Convert.ToInt32(drpBrand.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), EOMOdedb, strApprovers, 'A', cls.UserName, ref paramout))
                {
                    result = Convert.ToInt32(paramout[0].Value);
                    //Update the db with the approver group details
                    InsertOperationMessage(result);
                }
                //Display update success/failure message
            }
            catch (NullReferenceException ex)
            {
            }
        }
        //Sub 	        :   Cancel click event
        //Written BY	    :	Vijay
        //parameters     :	
        //Purpose	    :   Redirects user to 'View Approval Group' page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewApprovalGroup.aspx");
        }
        #endregion

    }
}