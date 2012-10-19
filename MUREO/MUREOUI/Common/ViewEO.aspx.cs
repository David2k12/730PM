using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Common
{
    public partial class ViewEO : System.Web.UI.Page
    {
        EOBA objEOBA = new EOBA();
        int EO_ID = 0;   
        DataSet dsMandatory = null;
        DataSet dsPreliminary = null;
        DataSet dsFinal = null;

        string strUserRole = string.Empty;
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            strUserRole = cls.UserRole();
            if (strUserRole == "MUREO_Readers" | strUserRole == "Readers")
            {
                ImageButton1.Visible = false;
            }
            else
            {
                ImageButton1.Visible = true;
            }

            ViewState["EOID"] = Request.QueryString["EO_ID"];

            string strCurrentStage = null;
            string strStatus = null;
            DataSet ds = new DataSet();
            try
            {
                objEOBA.GETEOMandatory(Convert.ToInt32(Convert.ToString(ViewState["EOID"])), ref ds);
            }
            catch (Exception ex)
            {
            }


            if ((ds != null))
            {

                if (!(ds.Tables.Count == 0))
                {

                    if (!(ds.Tables[0].Rows.Count == 0))
                    {
                        int intEOIDFlag = 0;
                        intEOIDFlag = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[0]["IsNewEO"]));

                        ViewState["EOIDFlag"] = intEOIDFlag;
                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["SMART_Clearance_Number"], System.DBNull.Value)))
                        {
                            lblSmartClearanceDB.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMART_Clearance_Number"]);
                        }
                        else
                        {
                            lblSmartClearanceDB.Text = "Not Needed";
                        }
                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Status"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]).Trim().ToUpper() =="I")
                            {
                                ImageButton1.Visible = false;
                            }
                            else
                            {
                                ImageButton1.Visible = true;
                            }
                        }
                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Current_Stage"], System.DBNull.Value)))
                        {
                            strCurrentStage = Convert.ToString(ds.Tables[0].Rows[0]["Current_Stage"]);
                            ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"];
                        }
                        else
                        {
                            strCurrentStage = string.Empty;
                            ViewState["stage"] = ds.Tables[0].Rows[0]["Current_Stage"];
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Stage_Status"], System.DBNull.Value)))
                        {
                            ViewState["Status"] = ds.Tables[0].Rows[0]["Stage_Status"];
                            strStatus = Convert.ToString(ds.Tables[0].Rows[0]["Stage_Status"]);
                        }
                        else
                        {
                            ViewState["Status"] = string.Empty;
                            strStatus = string.Empty;
                        }
                    }
                }
            }


            //To carry selected BudgetCenter in preliminary tab to other tabs
            try
            {
                DataSet dsSelBudgetCenter = new DataSet();
                objEOBA.GET_EO_Preliminary(Convert.ToInt32(ViewState["EOID"]), ref dsSelBudgetCenter);
                if ((dsSelBudgetCenter != null))
                {

                    if (!(dsSelBudgetCenter.Tables.Count == 0))
                    {

                        if (Convert.ToInt32(ViewState["EOIDFlag"]) == 1)
                        {

                        }
                        else
                        {
                            lblMaterialsQ1.Visible = false;
                            lblMaterialsQ2.Visible = false;
                            lblMaterialsQ3.Visible = false;
                        }


                        if (Convert.ToInt32(ViewState["EOIDFlag"]) == 1)
                        {
                            Label49.Visible = false;
                            Label50.Visible = false;
                            trRM1.Visible = false;
                            trRM2.Visible = false;
                            trNewRowMaterials.Visible = true;
                            trNewPSRARow.Visible = true;
                            trSmartClearanceApproval.Visible = true;
                            lblSmartClearanceDBText.Visible = true;
                            lblSmartClearanceDB.Visible = true;
                            TrFinalMaterialsBrands.Visible = true;
                            TrPSRA.Visible = true;


                            //trNewRowMaterials.Visible = True
                            if (!(dsSelBudgetCenter.Tables[2].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[2].Rows[0]["Is_Understood_Policy_37"], DBNull.Value)))
                                {
                                    lblMaterials1.Text = Convert.ToString(dsSelBudgetCenter.Tables[2].Rows[0]["Is_Understood_Policy_37"]);
                                }
                                else
                                {
                                    lblMaterials1.Text = "";
                                }

                            }
                            else
                            {

                            }

                            if (!(dsSelBudgetCenter.Tables[2].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[2].Rows[0]["Is_Exception_Policy_37"], DBNull.Value)))
                                {
                                    lblMaterials2.Text = Convert.ToString(dsSelBudgetCenter.Tables[2].Rows[0]["Is_Exception_Policy_37"]);
                                }
                                else
                                {
                                    lblMaterials2.Text = "";
                                }

                            }
                            else
                            {

                            }

                            if (!(dsSelBudgetCenter.Tables[2].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[2].Rows[0]["Is_EO_Covered_Policy_37"], DBNull.Value)))
                                {
                                    lblMaterials3.Text = Convert.ToString(dsSelBudgetCenter.Tables[2].Rows[0]["Is_EO_Covered_Policy_37"]);
                                }
                                else
                                {
                                    lblMaterials3.Text = "";
                                }

                            }
                            else
                            {
                            }



                            if (!(dsSelBudgetCenter.Tables[20].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Product_Go_To_Customers"], DBNull.Value)))
                                {
                                    lblPSRANAns1.Text = Convert.ToString(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Product_Go_To_Customers"]);
                                }
                                else
                                {
                                    lblPSRANAns1.Text = "";
                                }
                            }

                            if (!(dsSelBudgetCenter.Tables[20].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Using_Approved_FC_R_ATS"], DBNull.Value)))
                                {
                                    lblPSRANAns2.Text = Convert.ToString(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Using_Approved_FC_R_ATS"]);
                                }
                                else
                                {
                                    lblPSRANAns2.Text = "";
                                }
                            }

                            if (!(dsSelBudgetCenter.Tables[20].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_At_Level"], DBNull.Value)))
                                {
                                    lblPSRANAns3.Text = Convert.ToString(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_At_Level"]);
                                }
                                else
                                {
                                    lblPSRANAns3.Text = "";

                                }
                            }


                            if (!(dsSelBudgetCenter.Tables[20].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_For_Region"], DBNull.Value)))
                                {
                                    lblPSRANAns4.Text = Convert.ToString(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_For_Region"]);

                                }
                                else
                                {
                                    lblPSRANAns4.Text = "";
                                }
                            }

                            if (!(dsSelBudgetCenter.Tables[20].Rows.Count == 0))
                            {

                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_For_Application"], DBNull.Value)))
                                {
                                    lblPSRANAns5.Text = Convert.ToString(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_For_Application"]);

                                }
                                else
                                {
                                    lblPSRANAns5.Text = "";
                                }
                            }

                            if (!(dsSelBudgetCenter.Tables[20].Rows.Count == 0))
                            {
                                if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_At_Prev_Application_Rate"], DBNull.Value)))
                                {
                                    lblPSRANAns6.Text = Convert.ToString(dsSelBudgetCenter.Tables[20].Rows[0]["Is_Approved_At_Prev_Application_Rate"]);

                                }
                                else
                                {
                                    lblPSRANAns6.Text = "";

                                }
                            }


                        }
                        else
                        {
                            lblMaterials1.Visible = false;
                            lblMaterials2.Visible = false;
                            lblMaterials3.Visible = false;

                            lblPSRANQ1.Visible = false;
                            lblPSRANAns1.Visible = false;

                            lblPSRANQ2.Visible = false;
                            lblPSRANAns2.Visible = false;

                            lblPSRANQ3.Visible = false;
                            lblPSRANAns3.Visible = false;

                            lblPSRANQ4.Visible = false;
                            lblPSRANAns4.Visible = false;

                            lblPSRANQ5.Visible = false;
                            lblPSRANAns5.Visible = false;

                            lblPSRANQ6.Visible = false;
                            lblPSRANAns6.Visible = false;

                        }


                        if (lblPSRANAns1.Text == "Yes" & lblPSRANAns2.Text == "No")
                        {

                        }
                        else
                        {
                            lblPSRANQ3.Visible = false;
                            lblPSRANQ4.Visible = false;
                            lblPSRANQ5.Visible = false;
                            lblPSRANQ6.Visible = false;
                            lblPSRANAns3.Visible = false;
                            lblPSRANAns4.Visible = false;
                            lblPSRANAns5.Visible = false;
                            lblPSRANAns6.Visible = false;
                        }


                        if (!(dsSelBudgetCenter.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(dsSelBudgetCenter.Tables[0].Rows[0]["Selected_Budget_Center_Name"], System.DBNull.Value)))
                            {
                                if (!(Convert.ToString(dsSelBudgetCenter.Tables[0].Rows[0]["Selected_Budget_Center_Name"]) == "--SELECT--"))
                                {
                                    lblPreCOBudgetCenter.Text = Convert.ToString(dsSelBudgetCenter.Tables[0].Rows[0]["Selected_Budget_Center_Name"]);
                                    lblPreFinalBudgetCenter.Text = Convert.ToString(dsSelBudgetCenter.Tables[0].Rows[0]["Selected_Budget_Center_Name"]);

                                }
                                else
                                {
                                    lblPreCOBudgetCenter.Text = string.Empty;
                                    lblPreFinalBudgetCenter.Text = string.Empty;
                                }
                            }
                            else
                            {
                                lblPreCOBudgetCenter.Text = string.Empty;
                                lblPreFinalBudgetCenter.Text = string.Empty;
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }


            if (!Page.IsPostBack)
            {
                if (Convert.ToString(strCurrentStage) == Convert.ToString("Preliminary") & Convert.ToString(strStatus) == Convert.ToString("Draft"))
                {
                    ViewState["stage"] = "Preliminary";
                    ViewState["Status"] = "Draft";
                    lblStageLevel.Text = "Preliminary";
                    lblStatusType.Text = "Draft";
                    hidEOstage.Value = "1";


                }
                else if (Convert.ToString(strCurrentStage) == Convert.ToString("Preliminary") & Convert.ToString(strStatus) == Convert.ToString("Routed"))
                {
                    ViewState["stage"] = "Preliminary";
                    ViewState["Status"] = "Routed";
                    lblStageLevel.Text = "Preliminary";
                    lblStatusType.Text = "Routed";
                    hidEOstage.Value = "1";
                }
                else if (Convert.ToString(strCurrentStage) == Convert.ToString("Final") & Convert.ToString(strStatus) == Convert.ToString("Draft"))
                {
                    ViewState["stage"] = "Final";
                    ViewState["Status"] = "Draft";
                    lblStageLevel.Text = "Final";
                    lblStatusType.Text = "Draft";
                    hidEOstage.Value = "2";
                }
                else if (Convert.ToString(strCurrentStage) == Convert.ToString("Final") & Convert.ToString(strStatus) == Convert.ToString("Routed"))
                {
                    ViewState["stage"] = "Final";
                    ViewState["Status"] = "Routed";
                    lblStageLevel.Text = "Final";
                    lblStatusType.Text = "Routed";
                    hidEOstage.Value = "2";
                }
                else if (Convert.ToString(strCurrentStage) == Convert.ToString("CloseOut") & Convert.ToString(strStatus) == Convert.ToString("Draft"))
                {
                    ViewState["stage"] = "CloseOut";
                    ViewState["Status"] = "Draft";

                    lblStageLevel.Text = "CloseOut";
                    lblStatusType.Text = "Draft";
                    hidEOstage.Value = "3";
                }
                else if (Convert.ToString(strCurrentStage) == Convert.ToString("CloseOut") & Convert.ToString(strStatus) == Convert.ToString("Routed"))
                {
                    ViewState["stage"] = "CloseOut";
                    ViewState["Status"] = "Routed";
                    lblStageLevel.Text = "CloseOut";
                    lblStatusType.Text = "Routed";
                    hidEOstage.Value = "3";
                }
                else if (Convert.ToString(strCurrentStage) == Convert.ToString("CloseOut") & (Convert.ToString(strStatus) == Convert.ToString("Closed") | Convert.ToString(strStatus) == Convert.ToString("Approved")))
                {
                    hidEOstage.Value = "3";
                    if (Convert.ToString(strStatus) == Convert.ToString("Closed"))
                    {
                        ViewState["stage"] = "CloseOut";
                        ViewState["Status"] = "Closed";
                        lblStageLevel.Text = "CloseOut";
                        lblStatusType.Text = "Closed";
                    }
                    else if (Convert.ToString(strStatus) == Convert.ToString("Approved"))
                    {
                        ViewState["stage"] = "CloseOut";
                        ViewState["Status"] = "Approved";
                        lblStageLevel.Text = "CloseOut";
                        lblStatusType.Text = "Completed";
                    }
                }
            }




            if (Request.QueryString["EO_ID"]!= null)
            {
                hidEOID.Value = Request.QueryString["EO_ID"];
                EO_ID = Convert.ToInt32(Request.QueryString["EO_ID"]);
                if ((Request.QueryString["mode"] != null))
                {
                    if ((Request.QueryString["view"] != null))
                    {
                        if (Convert.ToString(Request.QueryString["mode"]) == "print")
                        {
                            //Display printable objects
                            trPHeader.Visible = true;

                            //Hide non-printable objects
                            trHeader.Visible = false;
                            trNavigation.Visible = false;

                            getEOMandatory();
                            if (Convert.ToInt32(Request.QueryString["view"]) == 1)
                            {
                                lblPrintHeader.Text = "Experimental Order - Preliminary Stage Data";
                                getEOPreliminary();
                                trFinal.Visible = false;
                                trCloseOut.Visible = false;
                            }
                            else if (Convert.ToInt32(Request.QueryString["view"]) == 2)
                            {
                                lblPrintHeader.Text = "Experimental Order - Final Stage Data";
                                getEOFinal();
                                trPreliminary.Visible = false;
                                trCloseOut.Visible = false;
                            }
                            else if (Convert.ToInt32(Request.QueryString["view"]) == 3)
                            {
                                lblPrintHeader.Text = "Experimental Order - Close Out Stage Data";
                                getEOCloseOut();
                                trPreliminary.Visible = false;
                                trFinal.Visible = false;
                            }
                            getEORevision();
                            Response.Write("<script>window.print();</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>window.close();</script>");
                    }
                    //Srilakshmi
                }
                else if (Request.QueryString["From"] == "Report")
                {
                    //hidEOstage.Value = 1
                    trPHeader.Visible = false;

                    btnPrintStage.Attributes.Add("OnClick", "javascript:return printStage(1);");
                    getEOMandatory();
                    if (Convert.ToInt32(Request.QueryString["view"]) == 1)
                    {
                        lblPrintHeader.Text = "Experimental Order - Preliminary Stage Data";
                        getEOPreliminary();
                        trFinal.Visible = false;
                        trCloseOut.Visible = false;
                        btnTabPreliminary.ImageUrl = "../Images/preliminary-over.gif";
                        btnTabFinal.ImageUrl = "../Images/final-nor.gif";
                        btnTabCloseOut.ImageUrl = "../Images/close-out-nor.gif";
                    }
                    else if (Convert.ToInt32(Request.QueryString["view"]) == 2)
                    {
                        lblPrintHeader.Text = "Experimental Order - Final Stage Data";
                        getEOFinal();
                        trPreliminary.Visible = false;
                        trCloseOut.Visible = false;
                        btnTabPreliminary.ImageUrl = "../Images/preliminary-nor.gif";
                        btnTabFinal.ImageUrl = "../Images/final-over.gif";
                        btnTabCloseOut.ImageUrl = "../Images/close-out-nor.gif";
                    }
                    else if (Convert.ToInt32(Request.QueryString["view"]) == 3)
                    {
                        lblPrintHeader.Text = "Experimental Order - Close Out Stage Data";
                        getEOCloseOut();
                        trPreliminary.Visible = false;
                        trFinal.Visible = false;
                        btnTabPreliminary.ImageUrl = "../Images/preliminary-nor.gif";
                        btnTabFinal.ImageUrl = "../Images/final-nor.gif";
                        btnTabCloseOut.ImageUrl = "../Images/close-out-over.gif";
                    }
                    getEORevision();

                }
                else
                {
                    //Hide nonprintable data
                    //hidEOstage.Value = 1
                    trPHeader.Visible = false;

                    btnPrintStage.Attributes.Add("OnClick", "javascript:return printStage(1);");
                    getEOMandatory();
                    getEORevision();
                    if (Convert.ToString(lblCurStage.Text) == Convert.ToString("Preliminary"))
                    {
                        getEOPreliminary();
                        lblStageLevel.Text = "Preliminary Stage";
                        lblStatusType.Text = "Draft";
                        btnTabPreliminary.ImageUrl = "../Images/preliminary-over.gif";
                        btnTabFinal.ImageUrl = "../Images/final-nor.gif";
                        btnTabCloseOut.ImageUrl = "../Images/close-out-nor.gif";
                        trPreliminary.Visible = true;
                        trFinal.Visible = false;
                        trCloseOut.Visible = false;

                    }
                    else if (Convert.ToString(lblCurStage.Text) == Convert.ToString("Final"))
                    {
                        lblPrintHeader.Text = "Experimental Order - Final Stage Data";
                        getEOFinal();
                        trPreliminary.Visible = false;
                        trCloseOut.Visible = false;
                        btnTabPreliminary.ImageUrl = "../Images/preliminary-nor.gif";
                        btnTabFinal.ImageUrl = "../Images/final-over.gif";
                        btnTabCloseOut.ImageUrl = "../Images/close-out-nor.gif";
                    }
                    else if (Convert.ToString(lblCurStage.Text) == Convert.ToString("CloseOut"))
                    {
                        lblPrintHeader.Text = "Experimental Order - Close Out Stage Data";
                        getEOCloseOut();
                        trPreliminary.Visible = false;
                        trFinal.Visible = false;
                        btnTabPreliminary.ImageUrl = "../Images/preliminary-nor.gif";
                        btnTabFinal.ImageUrl = "../Images/final-nor.gif";
                        btnTabCloseOut.ImageUrl = "../Images/close-out-over.gif";

                    }




                }

            }



        }
        protected void getEORevision()
        {
            DataSet ds = new DataSet();
            objEOBA.GET_EO_Preliminary(EO_ID, ref ds);
            if ((ds != null))
            {
                if (!(ds.Tables.Count == 0))
                {
                    if (!(ds.Tables[16].Rows.Count == 0))
                    {
                        dgrdRevHistory.DataSource = ds.Tables[16];
                        dgrdRevHistory.DataBind();
                    }
                    if (!(ds.Tables[17].Rows.Count == 0))
                    {
                        dgrdAppHistory.DataSource = ds.Tables[17];
                        dgrdAppHistory.DataBind();
                    }
                }
            }
        }

        protected void getEOMandatory()
        {
            objEOBA = new EOBA();
            dsMandatory = new DataSet();

            if (objEOBA.GETEOMandatory(EO_ID, ref dsMandatory))
            {

                if ((dsMandatory != null))
                {
                    if (!(dsMandatory.Tables.Count == 0))
                    {
                        if (!(dsMandatory.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Current_Stage"], System.DBNull.Value)))
                            {
                                lblCurStage.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Current_Stage"]);
                            }
                            else
                            {
                                lblCurStage.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Stage_Status"], System.DBNull.Value)))
                            {
                                lblstatus.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Stage_Status"]);
                            }
                            else
                            {
                                lblstatus.Text = string.Empty;
                            }


                            if (lblCurStage.Text.ToUpper() == "CloseOut".ToUpper())
                            {
                                if (lblstatus.Text.ToUpper() == "Approved".ToUpper())
                                {
                                    lblstatus.Text = "Completed";
                                }
                            }


                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value)))
                            {
                                lblTitle.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["EO_Title"]);
                            }
                            else
                            {
                                lblTitle.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["EO_Number"], System.DBNull.Value)))
                            {
                                lblEOnum.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["EO_Number"]);
                            }
                            else
                            {
                                lblEOnum.Text = "New EO";
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["SMART_Clearance_Number"], System.DBNull.Value)))
                            {
                                lblSmartClearanceDB.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["SMART_Clearance_Number"]);
                            }
                            else
                            {
                                lblSmartClearanceDB.Text = "Not Needed";
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["SAP_IO_Number"], System.DBNull.Value)))
                            {
                                lblSAPIO.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["SAP_IO_Number"]);
                            }
                            else
                            {
                                lblSAPIO.Text = "Not Assigned";
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Category_Name"], System.DBNull.Value)))
                            {
                                lblCategory.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Category_Name"]);
                            }
                            else
                            {
                                lblCategory.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Plant_Name"], System.DBNull.Value)))
                            {
                                lblPlant.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Plant_Name"]);
                            }
                            else
                            {
                                lblPlant.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Project_Name"], System.DBNull.Value)))
                            {
                                lblProjects.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Project_Name"]);
                            }
                            else
                            {
                                lblProjects.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Originator"], System.DBNull.Value)))
                            {
                                lblOriginator.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Originator"]);
                            }
                            else
                            {
                                lblOriginator.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Office_Num"], System.DBNull.Value)))
                            {
                                lblOfficeNo.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Office_Num"]);
                            }
                            else
                            {
                                lblOfficeNo.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Phone_Num"], System.DBNull.Value)))
                            {
                                lblPhno.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Phone_Num"]);
                            }
                            else
                            {
                                lblPhno.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["CoOriginator"], System.DBNull.Value)))
                            {
                                lblCoOrginator.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["CoOriginator"]);
                            }
                            else
                            {
                                lblCoOrginator.Text = string.Empty;
                            }

                            try
                            {
                                if ((!object.ReferenceEquals(dsMandatory.Tables[0].Rows[0]["Originator"], System.DBNull.Value)))
                                {
                                    lblCloseOriginatorDB.Text = Convert.ToString(dsMandatory.Tables[0].Rows[0]["Originator"]);
                                }
                                else
                                {
                                    lblCloseOriginatorDB.Text = string.Empty;
                                }

                            }
                            catch (Exception ex)
                            {
                            }

                        }
                    }
                }

                if ((dsMandatory != null))
                {
                    if (!(dsMandatory.Tables.Count == 0))
                    {
                        if (!(dsMandatory.Tables[1].Rows.Count == 0))
                        {
                            int intRowCount = 0;
                            for (intRowCount = 0; intRowCount <= dsMandatory.Tables[1].Rows.Count - 1; intRowCount++)
                            {
                                if (string.IsNullOrEmpty(lblEvents.Text))
                                {
                                    lblEvents.Text = Convert.ToString(dsMandatory.Tables[1].Rows[intRowCount]["Event_Name"]);
                                }
                                else
                                {
                                    lblEvents.Text = Convert.ToString(dsMandatory.Tables[1].Rows[intRowCount]["Event_Name"]);
                                }
                            }
                        }
                    }
                }

                if ((dsMandatory != null))
                {
                    if (!(dsMandatory.Tables.Count == 0))
                    {
                        if (!(dsMandatory.Tables[2].Rows.Count == 0))
                        {
                            int intRowCount = 0;
                            string s = null;
                            for (intRowCount = 0; intRowCount <= dsMandatory.Tables[2].Rows.Count - 1; intRowCount++)
                            {
                                if (string.IsNullOrEmpty(s))
                                {
                                    s = Convert.ToString(dsMandatory.Tables[2].Rows[intRowCount]["Brand_Segment_Name"]);
                                }
                                else
                                {
                                    s = s + "," + Convert.ToString(dsMandatory.Tables[2].Rows[intRowCount]["Brand_Segment_Name"]);
                                }
                            }
                            lblSelBrands.Text = s;
                            lblBrands.Text = s;
                            //For intRowCount = 0 To dsMandatory.Tables(2).Rows.Count - 1
                            //    If lblSelBrands.Text = "" Then
                            //        lblSelBrands.Text = dsMandatory.Tables(2).Rows(intRowCount).Item("Brand_Segment_Name")
                            //    Else
                            //        lblSelBrands.Text = lblSelBrands.Text & "," & dsMandatory.Tables(2).Rows(intRowCount).Item("Brand_Segment_Name")
                            //    End If
                            //Next
                        }
                    }
                }
            }
        }


        protected void getEOPreliminary()
        {
            DataSet ds = new DataSet();
            //ds = objEOBA.GET_EO_Preliminary(299)
            objEOBA.GET_EO_Preliminary(EO_ID, ref ds);
            //TrGeneralPreliminaryRO


            if ((ds != null))
            {

                if (!(ds.Tables.Count == 0))
                {




                    if (!(ds.Tables[19].Rows.Count == 0))
                    {
                        dgrdAttachment_ReadOnly.DataSource = ds.Tables[19].DefaultView;
                        dgrdAttachment_ReadOnly.DataBind();
                    }

                    if (!(ds.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["New_EO_Type_Name"], System.DBNull.Value)))
                        {
                            lblOtherEOType.Text = Convert.ToString(ds.Tables[0].Rows[0]["New_EO_Type_Name"]);
                        }
                        else
                        {
                            lblOtherEOType.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Scope_Project_Phase_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[0].Rows[0]["Scope_Project_Phase_Name"]) == "--SELECT--"))
                            {
                                lblEOScopeProjectPhase.Text = Convert.ToString(ds.Tables[0].Rows[0]["Scope_Project_Phase_Name"]);
                            }
                            else
                            {
                                lblEOScopeProjectPhase.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblEOScopeProjectPhase.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["New_Scope_Project_Type_Name"], System.DBNull.Value)))
                        {
                            lblEOScopeProjectPhaseOther.Text = Convert.ToString(ds.Tables[0].Rows[0]["New_Scope_Project_Type_Name"]);
                        }
                        else
                        {
                            lblEOScopeProjectPhaseOther.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Description"], System.DBNull.Value)))
                        {
                            lblBriefDecription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                        }
                        else
                        {
                            lblBriefDecription.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Paper_Making_Days"], System.DBNull.Value)))
                        {
                            lblTotPaperMakingTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["Paper_Making_Days"]);
                        }
                        else
                        {
                            lblTotPaperMakingTime.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Converting_Time_Days"], System.DBNull.Value)))
                        {
                            lblTotPaperConvertingTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["Converting_Time_Days"]);
                        }
                        else
                        {
                            lblTotPaperConvertingTime.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["New_Material_Cost"], System.DBNull.Value)))
                        {
                            lblTotCostOfNewMaterials.Text = Convert.ToString(ds.Tables[0].Rows[0]["New_Material_Cost"]);
                        }
                        else
                        {
                            lblTotCostOfNewMaterials.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Specific_Cost"], System.DBNull.Value)))
                        {
                            lblTotCostOfanyEPSpecific.Text = Convert.ToString(ds.Tables[0].Rows[0]["EO_Specific_Cost"]);
                        }
                        else
                        {
                            lblTotCostOfanyEPSpecific.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Total_Pre_Spending"], System.DBNull.Value)))
                        {
                            lblTotPreSpending.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Pre_Spending"]);
                        }
                        else
                        {
                            lblTotPreSpending.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Executing_Cost"], System.DBNull.Value)))
                        {
                            lblEoExecutionCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["EO_Executing_Cost"]);
                        }
                        else
                        {
                            lblEoExecutionCost.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Total_Cost"], System.DBNull.Value)))
                        {
                            lblTotCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Cost"]);
                        }
                        else
                        {
                            lblTotCost.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Suggested_Budget_Center_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[0].Rows[0]["Suggested_Budget_Center_Name"]) == "--SELECT--"))
                            {
                                lblSuggestedBudCenter.Text = Convert.ToString(ds.Tables[0].Rows[0]["Suggested_Budget_Center_Name"]);
                            }
                            else
                            {
                                lblSuggestedBudCenter.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblSuggestedBudCenter.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Other_Center_Department"], System.DBNull.Value)))
                        {
                            lblOtherSuggestedBudCenter.Text = Convert.ToString(ds.Tables[0].Rows[0]["Other_Center_Department"]);
                        }
                        else
                        {
                            lblOtherSuggestedBudCenter.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"]) == "--SELECT--"))
                            {
                                lblSelectedBudgetCenter.Text = Convert.ToString(ds.Tables[0].Rows[0]["Selected_Budget_Center_Name"]);
                            }
                            else
                            {
                                lblSelectedBudgetCenter.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblSelectedBudgetCenter.Text = string.Empty;
                        }


                    }
                    if (!(ds.Tables[1].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[1].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[1].Rows[intRowCount][1], System.DBNull.Value)))
                            {
                                if (string.IsNullOrEmpty(lblEOType.Text))
                                {
                                    lblEOType.Text = Convert.ToString(ds.Tables[1].Rows[intRowCount][1]);
                                }
                                else
                                {
                                    lblEOType.Text = lblEOType.Text + "," + ds.Tables[1].Rows[intRowCount][1];
                                }
                            }
                        }
                    }

                    //NewMaterialandBrandsReadOnly
                    if (!(ds.Tables[2].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_Raw_Packing_Material"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_Raw_Packing_Material"]) == "Y")
                            {
                                lblNewRawPackMaterials.Text = "Yes";
                            }
                            else
                            {
                                lblNewRawPackMaterials.Text = "No";
                            }

                        }
                        else
                        {
                            lblNewRawPackMaterials.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_Parent_Rolls"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_Parent_Rolls"]) == "Y")
                            {
                                lblParentRolls.Text = "Yes";
                            }
                            else
                            {
                                lblParentRolls.Text = "No";
                            }
                        }
                        else
                        {
                            lblParentRolls.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_Intermediate_Material"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_Intermediate_Material"]) == "Y")
                            {
                                lblEOProduceOrInvolve.Text = "Yes";
                            }
                            else
                            {
                                lblEOProduceOrInvolve.Text = "No";
                            }
                        }
                        else
                        {
                            lblEOProduceOrInvolve.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_Regulated_Product"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_Regulated_Product"]).ToUpper() == "Y")
                            {
                                lblIsRegulatedProduct.Text = "Yes";
                            }
                            else
                            {
                                lblIsRegulatedProduct.Text = "No";
                            }
                        }
                        else
                        {
                            lblIsRegulatedProduct.Text = string.Empty;
                        }

                        trProdRegulatedProductRQ1Final.Visible = false;

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_GMP_Classification"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_GMP_Classification"]).ToUpper() == "Y")
                            {
                                lblGMPClassification.Text = "Yes";
                            }
                            else
                            {
                                lblGMPClassification.Text = "No";
                            }
                        }
                        else
                        {
                            lblGMPClassification.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_Current_Brand"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_Current_Brand"]).ToUpper() == "Y")
                            {
                                lblCurrentBrand.Text = "Yes";
                            }
                            else
                            {
                                lblCurrentBrand.Text = "No";
                            }
                        }
                        else
                        {
                            lblCurrentBrand.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_Consumer_Lab_Evaluation"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_Consumer_Lab_Evaluation"]).ToUpper() == "Y")
                            {
                                lblLabEvaluation.Text = "Yes";
                            }
                            else
                            {
                                lblLabEvaluation.Text = "No";
                            }
                        }
                        else
                        {
                            lblLabEvaluation.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["EO_GCAS"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[2].Rows[0]["EO_GCAS"]).ToUpper() == "Y")
                            {
                                lblUMOF.Text = "Yes";
                            }
                            else
                            {
                                lblUMOF.Text = "No";
                            }
                        }
                        else
                        {
                            lblUMOF.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["Is_Understood_Policy_37"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[2].Rows[0]["Is_Understood_Policy_37"]) == false)
                            {
                                lblMaterials1.Text = "Yes";
                            }
                            else
                            {
                                lblMaterials1.Text = "No";
                            }
                        }
                        else
                        {
                            lblMaterials1.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["Is_Exception_Policy_37"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[2].Rows[0]["Is_Exception_Policy_37"]) == false)
                            {
                                lblMaterials2.Text = "Yes";
                            }
                            else
                            {
                                lblMaterials2.Text = "No";
                            }
                        }
                        else
                        {
                            lblMaterials2.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[2].Rows[0]["Is_EO_Covered_Policy_37"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[2].Rows[0]["Is_EO_Covered_Policy_37"]) == false)
                            {
                                lblMaterials3.Text = "Yes";
                            }
                            else
                            {
                                lblMaterials3.Text = "No";
                            }
                        }
                        else
                        {
                            lblMaterials3.Text = string.Empty;
                        }


                    }


                    if (!(ds.Tables[20].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[0]["Is_Product_Go_To_Customers"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[20].Rows[0]["Is_Product_Go_To_Customers"]) == false)
                            {
                                lblPSRANAns1.Text = "No";
                            }
                            else
                            {
                                lblPSRANAns1.Text = "Yes";
                            }
                        }
                        else
                        {
                            lblPSRANAns1.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[0]["Is_Using_Approved_FC_R_ATS"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[20].Rows[0]["Is_Using_Approved_FC_R_ATS"]) == false)
                            {
                                lblPSRANAns2.Text = "No";
                            }
                            else
                            {
                                lblPSRANAns2.Text = "Yes";
                            }
                        }
                        else
                        {
                            lblPSRANAns2.Text = string.Empty;
                        }

                        if ((lblPSRANAns1.Text == "Yes" & lblPSRANAns2.Text == "No"))
                        {
                            lblPSRANAns3.Visible = true;
                            lblPSRANAns4.Visible = true;
                            lblPSRANAns5.Visible = true;
                            lblPSRANAns6.Visible = true;
                        }
                        else
                        {
                            lblPSRANAns3.Visible = false;
                            lblPSRANAns4.Visible = false;
                            lblPSRANAns5.Visible = false;
                            lblPSRANAns6.Visible = false;

                        }

                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[0]["Is_Approved_At_Level"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[20].Rows[0]["Is_Approved_At_Level"]) == false)
                            {
                                lblPSRANAns3.Text = "No";
                            }
                            else
                            {
                                lblPSRANAns3.Text = "Yes";
                            }
                        }
                        else
                        {
                            lblPSRANAns3.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[0]["Is_Approved_For_Region"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[20].Rows[0]["Is_Approved_For_Region"]) == false)
                            {
                                lblPSRANAns4.Text = "No";
                            }
                            else
                            {
                                lblPSRANAns4.Text = "Yes";
                            }
                        }
                        else
                        {
                            lblPSRANAns4.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[0]["Is_Approved_For_Application"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[20].Rows[0]["Is_Approved_For_Application"]) == false)
                            {
                                lblPSRANAns5.Text = "No";
                            }
                            else
                            {
                                lblPSRANAns5.Text = "Yes";
                            }
                        }
                        else
                        {
                            lblPSRANAns5.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[0]["Is_Approved_At_Prev_Application_Rate"], System.DBNull.Value)))
                        {
                            if (Convert.ToBoolean(ds.Tables[20].Rows[0]["Is_Approved_At_Prev_Application_Rate"]) == false)
                            {
                                lblPSRANAns6.Text = "No";
                            }
                            else
                            {
                                lblPSRANAns6.Text = "Yes";
                            }
                        }
                        else
                        {
                            lblPSRANAns6.Text = string.Empty;
                        }


                    }


                    if (!(ds.Tables[3].Rows.Count == 0))
                    {
                        dgdGCASInfoRO.DataSource = ds.Tables[3];
                        dgdGCASInfoRO.DataBind();
                    }
                    //HSandSEReadOnly
                    if (!(ds.Tables[4].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["New_Chemical_Change"], System.DBNull.Value)))
                        {
                            if (ds.Tables[4].Rows[0]["New_Chemical_Change"] == "Y")
                            {
                                lblExistingChemical.Text = "Yes";
                            }
                            else
                            {
                                lblExistingChemical.Text = "No";
                            }
                        }
                        else
                        {
                            lblExistingChemical.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["New_Raw_Material_Change"], System.DBNull.Value)))
                        {
                            if (ds.Tables[4].Rows[0]["New_Raw_Material_Change"] == "Y")
                            {
                                lblPhysicalProperties.Text = "Yes";
                            }
                            else
                            {
                                lblPhysicalProperties.Text = "No";
                            }
                        }
                        else
                        {
                            lblPhysicalProperties.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["New_Equipment_Change"], System.DBNull.Value)))
                        {
                            if (ds.Tables[4].Rows[0]["New_Equipment_Change"] == "Y")
                            {
                                lblEqupProcessSupSystem.Text = "Yes";
                            }
                            else
                            {
                                lblEqupProcessSupSystem.Text = "No";
                            }
                        }
                        else
                        {
                            lblEqupProcessSupSystem.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["New_Job_Task_Change"], System.DBNull.Value)))
                        {
                            if (ds.Tables[4].Rows[0]["New_Job_Task_Change"] == "Y")
                            {
                                lblNewJobTask.Text = "Yes";
                            }
                            else
                            {
                                lblNewJobTask.Text = "No";
                            }
                        }
                        else
                        {
                            lblNewJobTask.Text = string.Empty;
                        }
                    }
                    //PSandRAReadOnly
                    //If Not ds.Tables(6).Rows.Count = 0 Then
                    //    If Not ds.Tables(6).Rows(0).Item("PSRA_Name") Is System.DBNull.Value Then
                    //        lblPSRADB.Text = ds.Tables(6).Rows(0).Item("PSRA_Name")
                    //    Else
                    //        lblPSRADB.Text = String.Empty
                    //    End If
                    //End If
                    //Added by Abdul
                    if (!(ds.Tables[6].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[6].Rows[0]["PSRA_Name"], System.DBNull.Value)))
                        {
                            lblPSRADB.Text = Convert.ToString(ds.Tables[6].Rows[0]["PSRA_Name"]);

                            //jagan 12/28/07 Two Tab Route
                            // lblPSRADB_TwoTbRte.Text = ds.Tables(6).Rows(0).Item("PSRA_Name")
                        }
                        else
                        {
                            lblPSRADB.Text = string.Empty;
                            //jagan 12/28/07 Two Tab Route
                            // lblPSRADB_TwoTbRte.Text = String.Empty
                        }

                        if ((!object.ReferenceEquals(ds.Tables[6].Rows[0]["Additional_Info"], System.DBNull.Value)))
                        {
                            lblOtherPSRADB.Text = Convert.ToString(ds.Tables[6].Rows[0]["Additional_Info"]);
                        }
                        else
                        {
                            lblOtherPSRADB.Text = string.Empty;
                        }
                        //lblOtherPSRADB.Text = ds.Tables(6).Rows(0).Item("Additional_Info")

                    }

                    //PSRA Datagrid RaedOnly
                    if (!(ds.Tables[5].Rows.Count == 0))
                    {
                        dgdPSRAInfoRO.DataSource = ds.Tables[5];
                        dgdPSRAInfoRO.DataBind();
                    }

                    //PlanningandBudgetInfoReadOnly
                    if (!(ds.Tables[7].Rows.Count == 0))
                    {
                        //If Not ds.Tables(7).Rows(0).Item("PSRA_Name") = DBNull.Value.ToString Then
                        //    lblPlantSiteRO.Text = ds.Tables(7).Rows(0).Item("PSRA_Name")
                        //Else
                        //    lblPlantSiteRO.Text = String.Empty
                        //End If
                        if ((!object.ReferenceEquals(ds.Tables[7].Rows[0]["Lines_Machines"], System.DBNull.Value)))
                        {
                            lblLinesMachineRO.Text = Convert.ToString(ds.Tables[7].Rows[0]["Lines_Machines"]);
                        }
                        else
                        {
                            lblLinesMachineRO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[7].Rows[0]["Planned_Start_Date"], System.DBNull.Value)))
                        {
                            lblPlannesStDateRO.Text = Convert.ToString(ds.Tables[7].Rows[0]["Planned_Start_Date"]);
                        }
                        else
                        {
                            lblPlannesStDateRO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[7].Rows[0]["Formula_Card_Number"], System.DBNull.Value)))
                        {
                            lblFormulaCardNORO.Text = Convert.ToString(ds.Tables[7].Rows[0]["Formula_Card_Number"]);
                        }
                        else
                        {
                            lblFormulaCardNORO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[7].Rows[0]["IGCAS_Number"], System.DBNull.Value)))
                        {
                            lblIPSGCASViewEO.Text = Convert.ToString(ds.Tables[7].Rows[0]["IGCAS_Number"]);
                        }
                        else
                        {
                            lblIPSGCASViewEO.Text = string.Empty;
                        }
                    }
                    //ProductionandPackagingReadOnly
                    if (!(ds.Tables[8].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[8].Rows[0]["PP_Format"], System.DBNull.Value)))
                        {
                            lblFormats.Text = Convert.ToString(ds.Tables[8].Rows[0]["PP_Format"]);
                        }
                        else
                        {
                            lblFormats.Text = string.Empty;
                        }
                    }
                    //Packaging / Disposition Information REadOnly
                    if (!(ds.Tables[10].Rows.Count == 0))
                    {
                        //If Not ds.Tables(7).Rows(0).Item("PSRA_Name") = DBNull.Value.ToString Then
                        //    lblPlantSiteRO.Text = ds.Tables(7).Rows(0).Item("PSRA_Name")
                        //Else
                        //    lblPlantSiteRO.Text = String.Empty
                        //End If
                        //If Not ds.Tables(13).Rows(0).Item("Prod_Pack_Name") Is System.DBNull.Value Then
                        //    lblProdBePacked.Text = ds.Tables(13).Rows(0).Item("Prod_Pack_Name")
                        //Else
                        //    lblProdBePacked.Text = String.Empty
                        //End If

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Current_Packaging"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Current_Packaging"]).ToUpper() == "Y")
                            {
                                lblCurrentPackagingRO.Text = "Yes";
                            }
                            else
                            {
                                lblCurrentPackagingRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblCurrentPackagingRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Experimental_Packaging"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Experimental_Packaging"]).ToUpper() == "Y")
                            {
                                lblExperimPackagingRO.Text = "Yes";
                            }
                            else
                            {
                                lblExperimPackagingRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblExperimPackagingRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Exp_Pack_Clear_Poly"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Exp_Pack_Clear_Poly"]).ToUpper() == "Y")
                            {
                                lblClearPolyRO.Text = "Yes";
                            }
                            else
                            {
                                lblClearPolyRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblClearPolyRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Exp_Pack_Blank_KDF"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Exp_Pack_Blank_KDF"]).ToUpper() == "Y")
                            {
                                lblBlankKDFRO.Text = "Yes";
                            }
                            else
                            {
                                lblBlankKDFRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblBlankKDFRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Prod_Disposition_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[10].Rows[0]["Prod_Disposition_Name"]) == "--SELECT--"))
                            {
                                lbProductDisposition.Text = Convert.ToString(ds.Tables[10].Rows[0]["Prod_Disposition_Name"]);
                            }
                            else
                            {
                                lbProductDisposition.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lbProductDisposition.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Prod_Disp_Add_Comments"], System.DBNull.Value)))
                        {
                            lbAdditionalCommnets.Text = Convert.ToString(ds.Tables[10].Rows[0]["Prod_Disp_Add_Comments"]);
                        }
                        else
                        {
                            lbAdditionalCommnets.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Pallet_Patter_SKU"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Pallet_Patter_SKU"]).ToUpper() == "Y")
                            {
                                lblUniquePallet.Text = "Yes";
                            }
                            else
                            {
                                lblUniquePallet.Text = "No";
                            }
                        }
                        else
                        {
                            lblUniquePallet.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Stack_Testing"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Stack_Testing"]).ToUpper() == "Y")
                            {
                                lblStackTesting.Text = "Yes";
                            }
                            else
                            {
                                lblStackTesting.Text = "No";
                            }
                        }
                        else
                        {
                            lblStackTesting.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Ship_Testing"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Ship_Testing"]).ToUpper() == "Y")
                            {
                                lblShipTesting.Text = "Yes";
                            }
                            else
                            {
                                lblShipTesting.Text = "No";
                            }
                        }
                        else
                        {
                            lblShipTesting.Text = string.Empty;
                        }

                        //If Not ds.Tables(10).Rows(0).Item("") = DBNull.Value.ToString Then
                        //    lblClearPoly.Text = 
                        //Else
                        //    lblClearPoly.Text = String.Empty
                        //End If

                        //If Not ds.Tables(10).Rows(0).Item("") = DBNull.Value.ToString Then
                        //    lblBlankKDF.Text = 
                        //Else
                        //    lblBlankKDF.Text = String.Empty
                        //End If

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Material_Disposition_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[10].Rows[0]["Material_Disposition_Name"]) == "--SELECT--"))
                            {
                                lblMaterialDisposition.Text = Convert.ToString(ds.Tables[10].Rows[0]["Material_Disposition_Name"]);
                            }
                            else
                            {
                                lblMaterialDisposition.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblMaterialDisposition.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Mat_Disp_Add_Comments"], System.DBNull.Value)))
                        {
                            lblAdditionalMaterialDisposition.Text = Convert.ToString(ds.Tables[10].Rows[0]["Mat_Disp_Add_Comments"]);
                        }
                        else
                        {
                            lblAdditionalMaterialDisposition.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Broke_Disp_Normal"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Broke_Disp_Normal"]).ToUpper() == "Y")
                            {
                                lblEOGraterNormalBroke.Text = "Yes";
                            }
                            else
                            {
                                lblEOGraterNormalBroke.Text = "No";
                            }
                        }
                        else
                        {
                            lblEOGraterNormalBroke.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Printer_Broke"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Printer_Broke"]).ToUpper() == "Y")
                            {
                                lblPrinyBrokeRO.Text = "Yes";
                            }
                            else
                            {
                                lblPrinyBrokeRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblPrinyBrokeRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Ink_Coverage"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[10].Rows[0]["Ink_Coverage"]).ToUpper() == "Y")
                            {
                                lblinkCovBrokeRO.Text = "Yes";
                            }
                            else
                            {
                                lblinkCovBrokeRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblinkCovBrokeRO.Text = string.Empty;
                        }

                        //If Not ds.Tables(10).Rows(0).Item("Ink_Coverage") Is System.DBNull.Value Then
                        //    lblinkCovBrokeRO.Text = ds.Tables(10).Rows(0).Item("Ink_Coverage")
                        //Else
                        //    lblinkCovBrokeRO.Text = String.Empty
                        //End If

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Lab_Notebook_Number"], System.DBNull.Value)))
                        {
                            lblLabNoteBookRO.Text = Convert.ToString(ds.Tables[10].Rows[0]["Lab_Notebook_Number"]);
                        }
                        else
                        {
                            lblLabNoteBookRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[10].Rows[0]["Comments"], System.DBNull.Value)))
                        {
                            lblApproverComments.Text = Convert.ToString(ds.Tables[10].Rows[0]["Comments"]);
                        }
                        else
                        {
                            lblApproverComments.Text = string.Empty;
                        }

                        //If Not ds.Tables(10).Rows(0).Item("Ink_Coverage") = DBNull.Value.ToString Then
                        //    lblApproverComments.Text = ds.Tables(10).Rows(0).Item("Ink_Coverage")
                        //Else
                        //    lblApproverComments.Text = String.Empty
                        //End If

                    }
                    if (!(ds.Tables[11].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[11].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[11].Rows[intRowCount][0], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[11].Rows[intRowCount][0]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblAdditonalAttachmentsRO.Text))
                                {
                                    lblAdditonalAttachmentsRO.Text = strFileSubName;
                                }
                                else
                                {
                                    lblAdditonalAttachmentsRO.Text = lblAdditonalAttachmentsRO.Text + "," + strFileSubName;
                                }
                            }
                        }
                    }

                    //for concurece group
                    //If Not ds.Tables(14).Rows.Count = 0 Then
                    //    dgrConcurenceGrp.Visible = True
                    //    dgrConcurenceGrp.DataSource = ds.Tables(14)
                    //    dgrConcurenceGrp.DataBind()

                    //    Dim dlRowCount As Integer
                    //    If dgrConcurenceGrp.Items.Count = 0 Then
                    //    Else
                    //        dgrConcurenceGrp.Visible = True
                    //        For dlRowCount = 0 To dgrConcurenceGrp.Items.Count - 1
                    //            If ds.Tables(14).Rows(dlRowCount).Item("Is_Responded") Is System.DBNull.Value Then
                    //                dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkDeclined").Visible = True
                    //                dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkApproval").Visible = True
                    //            ElseIf ds.Tables(14).Rows(dlRowCount).Item("Is_Responded") = "No Response" Then
                    //                If UCase(Security.UserName) = UCase(ds.Tables(14).Rows(dlRowCount).Item("Approver_Name")) Then
                    //                    dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkDeclined").Visible = True
                    //                    dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkApproval").Visible = True
                    //                Else
                    //                    dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkDeclined").Visible = False
                    //                    dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkApproval").Visible = False
                    //                End If

                    //            ElseIf ds.Tables(14).Rows(dlRowCount).Item("Is_Responded") = "Approved" Then
                    //                dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkDeclined").Visible = False
                    //                dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkApproval").Visible = False
                    //                'lnkDeclined.Visible = True
                    //            ElseIf ds.Tables(14).Rows(dlRowCount).Item("Is_Responded") = "Declined" Then
                    //                dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkApproval").Visible = False
                    //                dgrConcurenceGrp.Items(dlRowCount).FindControl("lnkDeclined").Visible = False
                    //            End If
                    //        Next
                    //    End If

                    //End If

                    //for pre screeners
                    //If Not ds.Tables(15).Rows.Count = 0 Then
                    //    dgrPrescrenners.Visible = True
                    //    dgrPrescrenners.DataSource = ds.Tables(15)
                    //    dgrPrescrenners.DataBind()

                    //    Dim dlRowCountp As Integer
                    //    If dgrPrescrenners.Items.Count = 0 Then
                    //    Else
                    //        dgrPrescrenners.Visible = True
                    //        For dlRowCountp = 0 To dgrPrescrenners.Items.Count - 1
                    //            If ds.Tables(15).Rows(dlRowCountp).Item("Is_Responded") Is System.DBNull.Value Then
                    //                dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreDeclined").Visible = True
                    //                dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreApproval").Visible = True
                    //            ElseIf ds.Tables(15).Rows(dlRowCountp).Item("Is_Responded") = "No Response" Then
                    //                If UCase(Security.UserName) = UCase(ds.Tables(15).Rows(dlRowCountp).Item("Approver_Name")) Then
                    //                    dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreDeclined").Visible = True
                    //                    dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreApproval").Visible = True
                    //                Else
                    //                    dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreDeclined").Visible = False
                    //                    dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreApproval").Visible = False
                    //                End If

                    //            ElseIf ds.Tables(15).Rows(dlRowCountp).Item("Is_Responded") = "Approved" Then
                    //                dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreDeclined").Visible = False
                    //                dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreApproval").Visible = False
                    //                'lnkDeclined.Visible = True
                    //            ElseIf ds.Tables(15).Rows(dlRowCountp).Item("Is_Responded") = "Declined" Then
                    //                dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreApproval").Visible = False
                    //                dgrPrescrenners.Items(dlRowCountp).FindControl("lnkpreDeclined").Visible = False
                    //            End If


                    //        Next
                    //    End If
                    //End If
                    //jagan end code......
                    //Packaging and Disposition information
                    try
                    {
                        if (!(ds.Tables[13].Rows.Count == 0))
                        {
                            int intRowCount = 0;
                            for (intRowCount = 0; intRowCount <= ds.Tables[13].Rows.Count - 1; intRowCount++)
                            {
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Prod_Pack_Name"], System.DBNull.Value)))
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[13].Rows[intRowCount]["Prod_Pack_Name"])))
                                    {
                                        if (string.IsNullOrEmpty(lblProdBePacked.Text))
                                        {
                                            lblProdBePacked.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Prod_Pack_Name"]);
                                        }
                                        else
                                        {
                                            lblProdBePacked.Text = lblProdBePacked.Text + "," + ds.Tables[13].Rows[intRowCount]["Prod_Pack_Name"];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    //For Current packaging and Experimental Packaging
                    try
                    {
                        if (!(ds.Tables[18].Rows.Count == 0))
                        {
                            int intRowCount = 0;
                            for (intRowCount = 0; intRowCount <= ds.Tables[18].Rows.Count - 1; intRowCount++)
                            {
                                if ((!object.ReferenceEquals(ds.Tables[18].Rows[intRowCount][0], System.DBNull.Value)))
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[18].Rows[intRowCount][0])))
                                    {
                                        if (Convert.ToString(ds.Tables[18].Rows[intRowCount][0]) == "1")
                                        {
                                            if (string.IsNullOrEmpty(lblPackaging.Text))
                                            {
                                                lblPackaging.Text = "Brown Box";
                                            }
                                            else
                                            {
                                                lblPackaging.Text = lblPackaging.Text + "," + "Brown Box";
                                            }
                                        }
                                        else if (Convert.ToString(ds.Tables[18].Rows[intRowCount][0]) == "2")
                                        {
                                            if (string.IsNullOrEmpty(lblPackaging.Text))
                                            {
                                                lblPackaging.Text = "LCP";
                                            }
                                            else
                                            {
                                                lblPackaging.Text = lblPackaging.Text + "," + "LCP";
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


                    //Preliminary-Approval Section Read Only
                    if (!(ds.Tables[12].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[12].Rows.Count - 1; intRowCount++)
                        {
                            //If ds.Tables(12).Rows(intRowCount).Item("Function_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Function_Name") = "" Then
                            //For Preliminary Approval GrpID
                            if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approval_Group_Name"], System.DBNull.Value)))
                            {
                                lblPreliminaryAppGrp.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approval_Group_Name"]);
                            }
                            else
                            {
                                lblPreliminaryAppGrp.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Function_Name"], System.DBNull.Value)))
                            {
                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Budget Center")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblBORO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgBudgetYes.Visible = true;
                                                imgBudgetNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgBudgetNo.Visible = true;
                                                imgBudgetYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblBORO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "GBU HS&E Resource")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblGBUHSERO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgGbuHseYes.Visible = true;
                                                imgGbuHseNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgGbuHseNo.Visible = true;
                                                imgGbuHseYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblGBUHSERO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Site HS&E Resource")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblSiteHSERO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgSiteHseYes.Visible = true;
                                                imgSiteHseNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgSiteHseNo.Visible = true;
                                                imgSiteHseYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblSiteHSERO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Site Contact")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblSiteContactRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgSiteContactYes.Visible = true;
                                                imgSiteContactNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgSiteContactNo.Visible = true;
                                                imgSiteContactYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblSiteContactRO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Site Planning")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblSitePlanningRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgSitePlanningYes.Visible = true;
                                                imgSitePlanningNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgSitePlanningNo.Visible = true;
                                                imgSitePlanningYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblSitePlanningRO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "QA")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblQAPreRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                    }
                                    else
                                    {
                                        lblQAPreRO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Central QA")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblCentralQAPreRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                    }
                                    else
                                    {
                                        lblCentralQAPreRO.Text = string.Empty;
                                    }
                                }


                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Central Planning")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblCenPlanningRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgCentralPlanningYes.Visible = true;
                                                imgCentralPlanningNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgCentralPlanningNo.Visible = true;
                                                imgCentralPlanningYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblCenPlanningRO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "SAP Cost Center Coordinator")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblSAPRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgSapYes.Visible = true;
                                                imgSapNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgSapNo.Visible = true;
                                                imgSapYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblSAPRO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "SMART Clearance")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblSmartClearance.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgSmartClearanceYes.Visible = true;
                                                imgSmartClearanceNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgSmartClearanceNo.Visible = true;
                                                imgSmartClearanceYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblSmartClearance.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Timing Gate Exception")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblTimingGateRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgTimingGateYes.Visible = true;
                                                imgTimingGateNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgTimingGateNo.Visible = true;
                                                imgTimingGateYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblTimingGateRO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Standards Office")
                                {
                                    //If Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblStansOffRO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgStandardOfficeYes.Visible = true;
                                                imgStandardOfficeNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgStandardOfficeNo.Visible = true;
                                                imgStandardOfficeYes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblStansOffRO.Text = string.Empty;
                                    }
                                }

                                //Added by David - MUREO PCR : 4 Additional Approvers - Date: 01/03/2012


                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Additional approver #1")
                                {
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblAdditionalApprover1RO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgAdditionalApprover1Yes.Visible = true;
                                                imgAdditionalApprover1No.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgAdditionalApprover1No.Visible = true;
                                                imgAdditionalApprover1Yes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblAdditionalApprover1RO.Text = string.Empty;
                                    }
                                }


                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Additional approver #2")
                                {
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblAdditionalApprover2RO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgAdditionalApprover2Yes.Visible = true;
                                                imgAdditionalApprover2No.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgAdditionalApprover2No.Visible = true;
                                                imgAdditionalApprover2Yes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblAdditionalApprover2RO.Text = string.Empty;
                                    }
                                }


                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Additional approver #3")
                                {
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblAdditionalApprover3RO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgAdditionalApprover3Yes.Visible = true;
                                                imgAdditionalApprover3No.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgAdditionalApprover3No.Visible = true;
                                                imgAdditionalApprover3Yes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblAdditionalApprover3RO.Text = string.Empty;
                                    }
                                }

                                if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Function_Name"]) == "Additional approver #4")
                                {
                                    if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblAdditionalApprover4RO.Text = Convert.ToString(ds.Tables[12].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgAdditionalApprover4Yes.Visible = true;
                                                imgAdditionalApprover4No.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[12].Rows[intRowCount]["Is_Approved"]).ToUpper().ToUpper() == "N")
                                            {
                                                imgAdditionalApprover4No.Visible = true;
                                                imgAdditionalApprover4Yes.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblAdditionalApprover4RO.Text = string.Empty;
                                    }
                                }


                            }

                        }
                        if (!(ds.Tables[16].Rows.Count == 0))
                        {
                            dgrdRevHistory.DataSource = ds.Tables[16];
                            dgrdRevHistory.DataBind();
                        }
                        if (!(ds.Tables[17].Rows.Count == 0))
                        {
                            dgrdAppHistory.DataSource = ds.Tables[17];
                            dgrdAppHistory.DataBind();
                        }
                    }
                    else
                    {
                    }
                }
            }

        }


        protected void getEOFinal()
        {
            DataSet ds = new DataSet();
            objEOBA.GET_EO_Final(EO_ID, ref ds);
            if ((ds != null))
            {
                if (!(ds.Tables.Count == 0))
                {
                    if (!(ds.Tables[26].Rows.Count == 0))
                    {
                        dgrdTestMatrix_Readonly.DataSource = ds.Tables[26].DefaultView;
                        dgrdTestMatrix_Readonly.DataBind();
                    }

                    if (!(ds.Tables[27].Rows.Count == 0))
                    {
                        dgrdOtherDocFinal_Readonly.DataSource = ds.Tables[27].DefaultView;
                        dgrdOtherDocFinal_Readonly.DataBind();
                    }

                    if (!(ds.Tables[25].Rows.Count == 0))
                    {
                        dgrdLabSamp_Readonly.DataSource = ds.Tables[25].DefaultView;
                        dgrdLabSamp_Readonly.DataBind();
                    }

                    //TestPlan
                    if (!(ds.Tables[24].Rows.Count == 0))
                    {
                        dgrdTestPlansFinal_Readonly.DataSource = ds.Tables[24].DefaultView;
                        dgrdTestPlansFinal_Readonly.DataBind();
                    }

                    if (!(ds.Tables[23].Rows.Count == 0))
                    {
                        dgrdFormulaCard_Readonly.DataSource = ds.Tables[23].DefaultView;
                        dgrdFormulaCard_Readonly.DataBind();
                    }

                    if (!(ds.Tables[22].Rows.Count == 0))
                    {
                        dgrdQAFinalTabAttachment_Readonly.DataSource = ds.Tables[22].DefaultView;
                        dgrdQAFinalTabAttachment_Readonly.DataBind();
                    }

                    if (!(ds.Tables[21].Rows.Count == 0))
                    {
                        dgrdCostSheetFinal_ReadOnly.DataSource = ds.Tables[21].DefaultView;
                        dgrdCostSheetFinal_ReadOnly.DataBind();
                    }

                    if (!(ds.Tables[1].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Current_Packaging"], System.DBNull.Value)))
                        {
                            if (ds.Tables[1].Rows[0]["Current_Packaging"] == "Y")
                            {
                                lblCurPackageFinalRO.Text = "Yes";
                            }
                            else
                            {
                                lblCurPackageFinalRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblCurPackageFinalRO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Experimental_Packaging"], System.DBNull.Value)))
                        {
                            if (ds.Tables[1].Rows[0]["Experimental_Packaging"] == "Y")
                            {
                                lblExpPackFinalRO.Text = "Yes";
                            }
                            else
                            {
                                lblExpPackFinalRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblExpPackFinalRO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Exp_Pack_Clear_Poly"], System.DBNull.Value)))
                        {
                            if (ds.Tables[1].Rows[0]["Exp_Pack_Clear_Poly"] == "Y")
                            {
                                lblCurPolyFinalRO.Text = "Yes";
                            }
                            else
                            {
                                lblCurPolyFinalRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblCurPolyFinalRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Exp_Pack_Blank_KDF"], System.DBNull.Value)))
                        {
                            if (ds.Tables[1].Rows[0]["Exp_Pack_Blank_KDF"] == "Y")
                            {
                                lblBlankKDFFinalRO.Text = "Yes";
                            }
                            else
                            {
                                lblBlankKDFFinalRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblBlankKDFFinalRO.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Prod_Disposition_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[1].Rows[0]["Prod_Disposition_Name"]) == "--SELECT--"))
                            {
                                lblProDispositionFinalRO.Text = Convert.ToString(ds.Tables[1].Rows[0]["Prod_Disposition_Name"]);
                            }
                            else
                            {
                                lblProDispositionFinalRO.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblProDispositionFinalRO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Prod_Disp_Add_Comments"], System.DBNull.Value)))
                        {
                            lblProDispositionFinalAddCommRO.Text = Convert.ToString(ds.Tables[1].Rows[0]["Prod_Disp_Add_Comments"]);
                        }
                        else
                        {
                            lblProDispositionFinalAddCommRO.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Pallet_Patter_SKU"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[1].Rows[0]["Pallet_Patter_SKU"]).ToUpper() == "Y")
                            {
                                lblPalletFinalRO.Text = "Yes";
                            }
                            else
                            {
                                lblPalletFinalRO.Text = "No";
                            }
                        }
                        else
                        {
                            lblPalletFinalRO.Text = string.Empty;
                        }

                        try
                        {
                            if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Stack_Testing"], System.DBNull.Value)))
                            {
                                if (Convert.ToString(ds.Tables[1].Rows[0]["Stack_Testing"]).ToUpper() == "Y")
                                {
                                    lblStockShipTesting.Text = "Stack Testing";
                                }
                                else if (Convert.ToString(ds.Tables[1].Rows[0]["Ship_Testing"]).ToUpper() == "Y")
                                {
                                    lblStockShipTesting.Text = "Ship Testing";
                                }
                                else
                                {
                                    lblStockShipTesting.Text = string.Empty;
                                }
                            }
                            else
                            {
                                lblStockShipTesting.Text = string.Empty;
                            }

                        }
                        catch (Exception ex)
                        {
                        }


                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Material_Disposition_Name"], System.DBNull.Value)))
                        {
                            if (!(Convert.ToString(ds.Tables[1].Rows[0]["Material_Disposition_Name"]) == "--SELECT--"))
                            {
                                lblMaterialDispositionreadonly.Text = Convert.ToString(ds.Tables[1].Rows[0]["Material_Disposition_Name"]);
                            }
                            else
                            {
                                lblMaterialDispositionreadonly.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblMaterialDispositionreadonly.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Mat_Disp_Add_Comments"], System.DBNull.Value)))
                        {
                            lblMaterialDispositionComments.Text = Convert.ToString(ds.Tables[1].Rows[0]["Mat_Disp_Add_Comments"]);
                        }
                        else
                        {
                            lblMaterialDispositionComments.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Broke_Disp_Normal"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[1].Rows[0]["Broke_Disp_Normal"]).ToUpper() == "Y")
                            {
                                lblEOGraterThanNormalBroke.Text = "Yes";
                            }
                            else
                            {
                                lblEOGraterThanNormalBroke.Text = "No";
                            }
                        }
                        else
                        {
                            lblEOGraterThanNormalBroke.Text = string.Empty;
                        }

                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Printer_Broke"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[1].Rows[0]["Printer_Broke"]).ToUpper() == "Y")
                            {
                                lblPrintBroke.Text = "Yes";
                            }
                            else
                            {
                                lblPrintBroke.Text = "No";
                            }
                        }
                        else
                        {
                            lblPrintBroke.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Ink_Coverage"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[1].Rows[0]["Ink_Coverage"]).ToUpper() == "Y")
                            {
                                lblinkConerage.Text = "Yes";
                            }
                            else
                            {
                                lblinkConerage.Text = "No";
                            }
                        }
                        else
                        {
                            lblinkConerage.Text = string.Empty;
                        }
                    }
                    if (!(ds.Tables[4].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[4].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[intRowCount]["Cost Sheet Attachment Paths"], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[4].Rows[intRowCount]["Cost Sheet Attachment Paths"]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblCostSheetAttachments.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblCostSheetAttachments.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblCostSheetAttachments.Text = lblCostSheetAttachments.Text + "," + strFileSubName;
                                    }
                                }
                            }
                            else
                            {
                                lblCostSheetAttachments.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        lblCostSheetAttachments.Text = string.Empty;
                    }


                    if (!(ds.Tables[3].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[3].Rows[0]["Amount_Preliminary_Stage"], System.DBNull.Value)))
                        {
                            lblEstimateAmount.Text = Convert.ToString(ds.Tables[3].Rows[0]["Amount_Preliminary_Stage"]);
                        }
                        else
                        {
                            lblEstimateAmount.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[3].Rows[0]["Total_Cost_Diff"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[3].Rows[0]["Total_Cost_Diff"]).ToUpper() == "Y")
                            {
                                lblTotCostsheet.Text = "Yes";
                            }
                            else
                            {
                                lblTotCostsheet.Text = "No";
                            }

                        }
                        else
                        {
                            lblTotCostsheet.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[3].Rows[0]["Cost_Cost_Sheet"], System.DBNull.Value)))
                        {
                            lblYesOptionTotCostsheet.Text = Convert.ToString(ds.Tables[3].Rows[0]["Cost_Cost_Sheet"]);
                        }
                        else
                        {
                            lblYesOptionTotCostsheet.Text = string.Empty;
                        }
                        if ((!object.ReferenceEquals(ds.Tables[3].Rows[0]["Comments"], System.DBNull.Value)))
                        {
                            lblCostSheetAddCommentsFinalRO.Text = Convert.ToString(ds.Tables[3].Rows[0]["Comments"]);
                        }
                        else
                        {
                            lblCostSheetAddCommentsFinalRO.Text = string.Empty;
                        }
                    }
                    //Formula Card Information
                    if (!(ds.Tables[5].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[5].Rows[0]["Formula_Card_Info"], System.DBNull.Value)))
                        {
                            lblEOFormulaCardInfoFinalRO.Text = Convert.ToString(ds.Tables[5].Rows[0]["Formula_Card_Info"]);
                        }
                        else
                        {
                            lblEOFormulaCardInfoFinalRO.Text = string.Empty;
                        }
                    }
                    if (!(ds.Tables[6].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[6].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[6].Rows[intRowCount]["Formula Card Information Attachment Paths"], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[6].Rows[intRowCount]["Formula Card Information Attachment Paths"]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblEOFormulaCardInfoAttachFinalRO.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblEOFormulaCardInfoAttachFinalRO.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblEOFormulaCardInfoAttachFinalRO.Text = lblEOFormulaCardInfoAttachFinalRO.Text + "," + strFileSubName;
                                    }
                                }
                            }
                            else
                            {
                                lblEOFormulaCardInfoAttachFinalRO.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        lblEOFormulaCardInfoAttachFinalRO.Text = string.Empty;
                    }


                    //End If
                    //TestPlan
                    //If Not ds.Tables(7).Rows.Count = 0 Then
                    //    'If Not ds.Tables(7).Rows(0).Item("Test Plans Attachment Paths") Is System.DBNull.Value Or Not ds.Tables(7).Rows(0).Item("Test Plans Attachment Paths") = "" Then
                    //    If Not ds.Tables(7).Rows(0).Item("Test Plans Attachment Paths") Is System.DBNull.Value Then
                    //        lblTestPlanFinalRO.Text = ds.Tables(7).Rows(0).Item("Test Plans Attachment Paths")
                    //    Else
                    //        lblTestPlanFinalRO.Text = String.Empty
                    //    End If
                    //End If

                    if (!(ds.Tables[7].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[7].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[7].Rows[intRowCount]["Test Plans Attachment Paths"], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[7].Rows[intRowCount]["Test Plans Attachment Paths"]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblTestPlanFinalRO.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblTestPlanFinalRO.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblTestPlanFinalRO.Text = lblTestPlanFinalRO.Text + "," + strFileSubName;
                                    }
                                }
                            }
                            else
                            {
                                lblTestPlanFinalRO.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        lblTestPlanFinalRO.Text = string.Empty;
                    }

                    //Lab Sampling Plans
                    if (!(ds.Tables[8].Rows.Count == 0))
                    {
                        //If Not ds.Tables(8).Rows(0).Item("Central_Analytical_Lab") Is System.DBNull.Value Or Not ds.Tables(8).Rows(0).Item("Central_Analytical_Lab") = "" Then
                        if ((!object.ReferenceEquals(ds.Tables[8].Rows[0]["Central_Analytical_Lab"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[8].Rows[0]["Central_Analytical_Lab"]).ToUpper() == "Y")
                            {
                                lblCentralAnalyticalLab.Text = "Yes";
                            }
                            else
                            {
                                lblCentralAnalyticalLab.Text = "No";
                            }
                        }
                        else
                        {
                            lblCentralAnalyticalLab.Text = string.Empty;
                        }
                        //If Not ds.Tables(8).Rows(0).Item("Site_Testing_Lab") Is System.DBNull.Value Or Not ds.Tables(8).Rows(0).Item("Site_Testing_Lab") = "" Then
                        if ((!object.ReferenceEquals(ds.Tables[8].Rows[0]["Site_Testing_Lab"], System.DBNull.Value)))
                        {
                            if (Convert.ToString(ds.Tables[8].Rows[0]["Site_Testing_Lab"]).ToUpper() == "Y")
                            {
                                lblSiteTestingLabs.Text = "Yes";
                            }
                            else
                            {
                                lblSiteTestingLabs.Text = "No";
                            }
                        }
                        else
                        {
                            lblSiteTestingLabs.Text = string.Empty;
                        }
                    }
                    //If Not ds.Tables(9).Rows.Count = 0 Then
                    //    'If Not ds.Tables(9).Rows(0).Item("Lab Samplings Plans Attachment Paths") Is System.DBNull.Value Or Not ds.Tables(9).Rows(0).Item("Lab Samplings Plans Attachment Paths") = "" Then
                    //    If Not ds.Tables(9).Rows(0).Item("Lab Samplings Plans Attachment Paths") Is System.DBNull.Value Then
                    //        lblLabSamplingAttachementsFinal.Text = ds.Tables(9).Rows(0).Item("Lab Samplings Plans Attachment Paths")
                    //    Else
                    //        lblLabSamplingAttachementsFinal.Text = String.Empty
                    //    End If
                    //End If


                    if (!(ds.Tables[9].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[9].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[9].Rows[intRowCount]["Lab Samplings Plans Attachment Paths"], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[9].Rows[intRowCount]["Lab Samplings Plans Attachment Paths"]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblLabSamplingAttachementsFinal.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblLabSamplingAttachementsFinal.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblLabSamplingAttachementsFinal.Text = lblLabSamplingAttachementsFinal.Text + "," + strFileSubName;
                                    }
                                }
                            }
                            else
                            {
                                lblLabSamplingAttachementsFinal.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        lblLabSamplingAttachementsFinal.Text = string.Empty;
                    }


                    //'Product or Detailed Test Flow Matrix
                    if (!(ds.Tables[10].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        lblTestFlowMatrixFinalRO.Text = "";
                        for (intRowCount = 0; intRowCount <= ds.Tables[10].Rows.Count - 1; intRowCount++)
                        {
                            //If Not ds.Tables(10).Rows(intRowCount).Item(0) Is System.DBNull.Value Or Not ds.Tables(10).Rows(intRowCount).Item(0) = "" Then
                            if ((!object.ReferenceEquals(ds.Tables[10].Rows[intRowCount][0], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[10].Rows[intRowCount][0]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblTestFlowMatrixFinalRO.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblTestFlowMatrixFinalRO.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblTestFlowMatrixFinalRO.Text = lblTestFlowMatrixFinalRO.Text + "," + strFileSubName;
                                    }
                                }
                            }
                        }
                    }
                    //'Other Supporting Documentation
                    if (!(ds.Tables[12].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        lblOtheSupDocAttach.Text = "";
                        for (intRowCount = 0; intRowCount <= ds.Tables[12].Rows.Count - 1; intRowCount++)
                        {
                            //If Not ds.Tables(12).Rows(intRowCount).Item(0) Is System.DBNull.Value Or Not ds.Tables(12).Rows(intRowCount).Item(0) = "" Then
                            if ((!object.ReferenceEquals(ds.Tables[12].Rows[intRowCount][0], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[12].Rows[intRowCount][0]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblTestFlowMatrixFinalRO.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblOtheSupDocAttach.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblOtheSupDocAttach.Text = lblOtheSupDocAttach.Text + "," + strFileSubName;
                                    }
                                }
                            }
                        }
                    }
                    //lblSupDocCommnets()
                    if (!(ds.Tables[11].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(ds.Tables[11].Rows[0]["Comments_Approvers"], System.DBNull.Value)))
                        {
                            lblSupDocCommnets.Text = Convert.ToString(ds.Tables[11].Rows[0]["Comments_Approvers"]);
                        }
                        else
                        {
                            lblSupDocCommnets.Text = string.Empty;
                        }
                    }
                    //Approvals
                    try
                    {
                        if (!(ds.Tables[13].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(ds.Tables[13].Rows[0]["Approval_Group_Name"], System.DBNull.Value)))
                            {
                                lblApprovalGrpFinal.Text = Convert.ToString(ds.Tables[13].Rows[0]["Approval_Group_Name"]);
                            }
                            else
                            {
                                //drpAppGrpFinal.SelectedIndex = 0
                                lblApprovalGrpFinal.Text = string.Empty;
                            }
                        }
                        else
                        {
                            //drpAppGrpFinal.SelectedIndex = 0
                            lblApprovalGrpFinal.Text = string.Empty;
                        }

                    }
                    catch (Exception ex)
                    {
                    }



                    if (!(ds.Tables[13].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[13].Rows.Count - 1; intRowCount++)
                        {
                            //If ds.Tables(13).Rows(intRowCount).Item("Function_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Function_Name") = "" Then
                            if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Function_Name"], System.DBNull.Value)))
                            {
                                if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "PS Initiative Manager")
                                {
                                    //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                    {
                                        lblPSInitiativeAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                        if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                        {
                                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                            {
                                                imgFinalPSIniYes.Visible = true;
                                                imgFinalPSIniNo.Visible = false;
                                            }
                                            else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                            {
                                                imgFinalPSIniYes.Visible = true;
                                                imgFinalPSIniNo.Visible = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblPSInitiativeAppGrp.Text = string.Empty;
                                    }
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Products Research")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblProdResearchAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalProdResYes.Visible = true;
                                            imgFinalProdResNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalProdResYes.Visible = true;
                                            imgFinalProdResNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblProdResearchAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Budget Center")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblBOFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalBOYes.Visible = true;
                                            imgFinalBONo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalBOYes.Visible = true;
                                            imgFinalBONo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblBOFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "GBU HS&E Resource")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblGBUHSEFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalGBUHSEYes.Visible = true;
                                            imgFinalGBUHSENo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalGBUHSEYes.Visible = true;
                                            imgFinalGBUHSENo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblGBUHSEFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Site HS&E Resource")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSiteHSEFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSiteHSEYes.Visible = true;
                                            imgFinalSiteHSENo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSiteHSEYes.Visible = true;
                                            imgFinalSiteHSENo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSiteHSEFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "SAP Cost Center Coordinator")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSAPCostCenterFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSAPYes.Visible = true;
                                            imgFinalSAPNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSAPYes.Visible = true;
                                            imgFinalSAPNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSAPCostCenterFinalAppGrp.Text = string.Empty;
                                }
                            }

                            //Added for PCRs
                            //Date: 06/20/2010
                            //By: David

                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "SMART Clearance")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSmartClearanceFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSmartClearanceYes.Visible = true;
                                            imgFinalSmartClearanceNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSmartClearanceYes.Visible = true;
                                            imgFinalSmartClearanceNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSmartClearanceFinalAppGrp.Text = string.Empty;
                                }
                            }

                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Site Planning")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSiteplanningFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSitePlanYes.Visible = true;
                                            imgFinalSitePlanNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSitePlanYes.Visible = true;
                                            imgFinalSitePlanNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSiteplanningFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Site Contact")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSiteContactFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgSiteConYes.Visible = true;
                                            imgSiteConNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgSiteConYes.Visible = true;
                                            imgSiteConNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSiteContactFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Site Finance")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSiteFinanceFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSiteFinanceYes.Visible = true;
                                            imgFinalSiteFinanceNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSiteFinanceYes.Visible = true;
                                            imgFinalSiteFinanceNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSiteFinanceFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Site Leadership")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblSiteLeadeshipFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSiteLeaderYes.Visible = true;
                                            imgFinalSiteLeaderNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSiteLeaderYes.Visible = true;
                                            imgFinalSiteLeaderNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblSiteLeadeshipFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "PS&RA")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblPSRAFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalSiteHSEYes.Visible = true;
                                            imgFinalSiteHSENo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalSiteHSEYes.Visible = true;
                                            imgFinalSiteHSENo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblPSRAFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "PS&RA")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblPSRAFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalPSRAYes.Visible = true;
                                            imgFinalPSRANo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalPSRAYes.Visible = true;
                                            imgFinalPSRANo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblPSRAFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Timing Gate Exception")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblTimingGateFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalTimingGateYes.Visible = true;
                                            imgFinalTimingGateNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalTimingGateYes.Visible = true;
                                            imgFinalTimingGateNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblTimingGateFinalAppGrp.Text = string.Empty;
                                }
                            }
                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "QA")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblQAFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalQAYes.Visible = true;
                                            imgFinalQANo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalQAYes.Visible = true;
                                            imgFinalQANo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblQAFinalAppGrp.Text = string.Empty;
                                }
                            }

                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Central QA")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblCentralQAFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                }
                                else
                                {
                                    lblCentralQAFinalAppGrp.Text = string.Empty;
                                }
                            }

                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Standards Office")
                            {
                                //If Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(13).Rows(intRowCount).Item("Approver_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblStandsOfficeFinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalStandsYes.Visible = true;
                                            imgFinalStandsNo.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalStandsYes.Visible = true;
                                            imgFinalStandsNo.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblStandsOfficeFinalAppGrp.Text = string.Empty;
                                }
                            }

                            //Added by David - MUREO PCR : 4 Additional Approvers - Date: 01/03/2012



                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Additional approver #1")
                            {
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblAdditionalApprover1FinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalAdditionalApprover1Yes.Visible = true;
                                            imgFinalAdditionalApprover1No.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalAdditionalApprover1Yes.Visible = true;
                                            imgFinalAdditionalApprover1No.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblAdditionalApprover1FinalAppGrp.Text = string.Empty;
                                }
                            }

                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Additional approver #2")
                            {
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblAdditionalApprover2FinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalAdditionalApprover2Yes.Visible = true;
                                            imgFinalAdditionalApprover2No.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalAdditionalApprover2Yes.Visible = true;
                                            imgFinalAdditionalApprover2No.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblAdditionalApprover2FinalAppGrp.Text = string.Empty;
                                }
                            }

                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Additional approver #3")
                            {
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblAdditionalApprover3FinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalAdditionalApprover3Yes.Visible = true;
                                            imgFinalAdditionalApprover3No.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalAdditionalApprover3Yes.Visible = true;
                                            imgFinalAdditionalApprover3No.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblAdditionalApprover3FinalAppGrp.Text = string.Empty;
                                }
                            }


                            if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Function_Name"]) == "Additional approver #4")
                            {
                                if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                {
                                    lblAdditionalApprover4FinalAppGrp.Text = Convert.ToString(ds.Tables[13].Rows[intRowCount]["Approver_Name"]);
                                    if ((!object.ReferenceEquals(ds.Tables[13].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                    {
                                        if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                        {
                                            imgFinalAdditionalApprover4Yes.Visible = true;
                                            imgFinalAdditionalApprover4No.Visible = false;
                                        }
                                        else if (Convert.ToString(ds.Tables[13].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                        {
                                            imgFinalAdditionalApprover4Yes.Visible = true;
                                            imgFinalAdditionalApprover4No.Visible = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblAdditionalApprover4FinalAppGrp.Text = string.Empty;
                                }
                            }


                        }
                    }
                    else
                    {
                        lblPSInitiativeAppGrp.Text = string.Empty;
                        lblProdResearchAppGrp.Text = string.Empty;
                        lblBOFinalAppGrp.Text = string.Empty;
                        lblGBUHSEFinalAppGrp.Text = string.Empty;
                        lblSiteHSEFinalAppGrp.Text = string.Empty;
                        lblSAPCostCenterFinalAppGrp.Text = string.Empty;

                        //Added by David
                        lblSmartClearanceFinalAppGrp.Text = string.Empty;

                        lblSiteplanningFinalAppGrp.Text = string.Empty;
                        lblSiteContactFinalAppGrp.Text = string.Empty;
                        lblSiteFinanceFinalAppGrp.Text = string.Empty;
                        lblSiteLeadeshipFinalAppGrp.Text = string.Empty;
                        lblPSRAFinalAppGrp.Text = string.Empty;
                        lblTimingGateFinalAppGrp.Text = string.Empty;
                        lblQAFinalAppGrp.Text = string.Empty;
                        lblStandsOfficeFinalAppGrp.Text = string.Empty;
                    }
                }
                //for Product Packaging
                try
                {
                    if (!(ds.Tables[14].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[14].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[14].Rows[intRowCount]["Prod_Pack_Name"], System.DBNull.Value)))
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[14].Rows[intRowCount]["Prod_Pack_Name"])))
                                {
                                    if (string.IsNullOrEmpty(lblFinalPackagingInfoDB.Text))
                                    {
                                        lblFinalPackagingInfoDB.Text = Convert.ToString(ds.Tables[14].Rows[intRowCount]["Prod_Pack_Name"]);
                                    }
                                    else
                                    {
                                        lblFinalPackagingInfoDB.Text = lblFinalPackagingInfoDB.Text + "," + ds.Tables[14].Rows[intRowCount]["Prod_Pack_Name"];
                                    }
                                }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                }



                if (!(ds.Tables[20].Rows.Count == 0))
                {
                    int intRowCount = 0;
                    for (intRowCount = 0; intRowCount <= ds.Tables[20].Rows.Count - 1; intRowCount++)
                    {
                        if ((!object.ReferenceEquals(ds.Tables[20].Rows[intRowCount]["QA_Info_Attachment"], System.DBNull.Value)))
                        {
                            string strFullFileName = Convert.ToString(ds.Tables[20].Rows[intRowCount]["QA_Info_Attachment"]);
                            string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                            string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                            if (string.IsNullOrEmpty(lblTableFinalQARO.Text))
                            {
                                if (!string.IsNullOrEmpty(strFileSubName))
                                {
                                    lblTableFinalQARO.Text = strFileSubName;
                                }
                                else
                                {
                                    lblTableFinalQARO.Text = lblTableFinalQARO.Text + "," + strFileSubName;
                                }
                            }
                        }
                        else
                        {
                            lblTableFinalQARO.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    lblTableFinalQARO.Text = string.Empty;
                }

                if (!(ds.Tables[29].Rows.Count == 0))
                {
                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["EO_Raw_Packing_Material"], System.DBNull.Value)))
                    {
                        if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Raw_Packing_Material"]).ToUpper() == "Y")
                        {
                            lblNewRawPackMaterialsFinal.Text = "Yes";
                        }
                        else if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Raw_Packing_Material"]).ToUpper() == "N")
                        {
                            lblNewRawPackMaterialsFinal.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["EO_Parent_Rolls"], System.DBNull.Value)))
                    {
                        if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Parent_Rolls"]).ToUpper() == "Y")
                        {
                            lblParentRollsFinal.Text = "Yes";
                        }
                        else if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Parent_Rolls"]).ToUpper() == "N")
                        {
                            lblParentRollsFinal.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["EO_Intermediate_Material"], System.DBNull.Value)))
                    {
                        if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Intermediate_Material"]).ToUpper() == "Y")
                        {
                            lblEOProduceOrInvolveFinal.Text = "Yes";
                        }
                        else if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Intermediate_Material"]).ToUpper() == "N")
                        {
                            lblEOProduceOrInvolveFinal.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["EO_Current_Brand"], System.DBNull.Value)))
                    {
                        if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Current_Brand"]).ToUpper() == "Y")
                        {
                            lblCurrentBrandFinal.Text = "Yes";
                        }
                        else if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Current_Brand"]).ToUpper() == "N")
                        {
                            lblCurrentBrandFinal.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["EO_Consumer_Lab_Evaluation"], System.DBNull.Value)))
                    {
                        if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Consumer_Lab_Evaluation"]).ToUpper() == "Y")
                        {
                            lblLabEvaluationFinal.Text = "Yes";
                        }
                        else if (Convert.ToString(ds.Tables[29].Rows[0]["EO_Consumer_Lab_Evaluation"]).ToUpper() == "N")
                        {
                            lblLabEvaluationFinal.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["EO_GCAS"], System.DBNull.Value)))
                    {
                        if (Convert.ToString(ds.Tables[29].Rows[0]["EO_GCAS"]).ToUpper() == "Y")
                        {
                            lblUMOFFinal.Text = "Yes";
                        }
                        else if (Convert.ToString(ds.Tables[29].Rows[0]["EO_GCAS"]).ToUpper() == "N")
                        {
                            lblUMOFFinal.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["Is_Understood_Policy_37"], DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[29].Rows[0]["Is_Understood_Policy_37"]) == false)
                        {
                            lblYesNoMat1Final.Text = "Yes";
                            lblYesNoMat2Final.Text = "No";
                            lblYesNoMat3Final.Text = "No";
                        }
                    }
                    else
                    {
                        lblYesNoMat1Final.Text = "";
                        lblYesNoMat2Final.Text = "";
                        lblYesNoMat3Final.Text = "";
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["Is_Exception_Policy_37"], DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[29].Rows[0]["Is_Exception_Policy_37"]) == false)
                        {
                            lblYesNoMat2Final.Text = "Yes";
                            lblYesNoMat1Final.Text = "No";
                            lblYesNoMat3Final.Text = "No";
                        }
                    }
                    else
                    {
                        lblYesNoMat1Final.Text = "";
                        lblYesNoMat2Final.Text = "";
                        lblYesNoMat3Final.Text = "";
                    }

                    if ((!object.ReferenceEquals(ds.Tables[29].Rows[0]["Is_EO_Covered_Policy_37"], DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[29].Rows[0]["Is_EO_Covered_Policy_37"]) == false)
                        {
                            lblYesNoMat3Final.Text = "Yes";
                            lblYesNoMat1Final.Text = "No";
                            lblYesNoMat2Final.Text = "No";
                        }
                    }
                    else
                    {
                        lblYesNoMat1Final.Text = "";
                        lblYesNoMat2Final.Text = "";
                        lblYesNoMat3Final.Text = "";
                    }

                }


                if (!(ds.Tables[30].Rows.Count == 0))
                {
                    if ((!object.ReferenceEquals(ds.Tables[30].Rows[0]["Is_Product_Go_To_Customers"], System.DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Product_Go_To_Customers"]) == true)
                        {
                            lblReadonlyPSR1Final.Text = "Yes";
                        }
                        else if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Product_Go_To_Customers"]) == false)
                        {
                            lblReadonlyPSR1Final.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[30].Rows[0]["Is_Using_Approved_FC_R_ATS"], System.DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Using_Approved_FC_R_ATS"]) == true)
                        {
                            lblReadonlyPSR2Final.Text = "Yes";
                        }
                        else if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Using_Approved_FC_R_ATS"]) == false)
                        {
                            lblReadonlyPSR2Final.Text = "No";
                        }
                    }


                    if ((!object.ReferenceEquals(ds.Tables[30].Rows[0]["Is_Approved_At_Level"], System.DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_At_Level"]) == true)
                        {
                            lblReadonlyPSR3Final.Text = "Yes";
                        }
                        else if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_At_Level"]) == false)
                        {
                            lblReadonlyPSR3Final.Text = "No";
                        }
                    }


                    if ((!object.ReferenceEquals(ds.Tables[30].Rows[0]["Is_Approved_For_Region"], System.DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_For_Region"]) == true)
                        {
                            lblReadonlyPSR4Final.Text = "Yes";
                        }
                        else if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_For_Region"]) == false)
                        {
                            lblReadonlyPSR4Final.Text = "No";
                        }
                    }


                    if ((!object.ReferenceEquals(ds.Tables[30].Rows[0]["Is_Approved_For_Application"], System.DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_For_Application"]) == true)
                        {
                            lblReadonlyPSR5Final.Text = "Yes";
                        }
                        else if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_For_Application"]) == false)
                        {
                            lblReadonlyPSR5Final.Text = "No";
                        }
                    }

                    if ((!object.ReferenceEquals(ds.Tables[30].Rows[0]["Is_Approved_At_Prev_Application_Rate"], System.DBNull.Value)))
                    {
                        if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_At_Prev_Application_Rate"]) == true)
                        {
                            lblReadonlyPSR6Final.Text = "Yes";
                        }
                        else if (Convert.ToBoolean(ds.Tables[30].Rows[0]["Is_Approved_At_Prev_Application_Rate"]) == false)
                        {
                            lblReadonlyPSR6Final.Text = "No";
                        }
                    }


                }

            }
        }

        protected void getEOCloseOut()
        {
            DataSet ds = new DataSet();
            if (objEOBA.GET_EO_Closeout(EO_ID, ref ds))
            {
                if ((ds != null))
                {

                    if (!(ds.Tables.Count == 0))
                    {
                        if (!(ds.Tables[11].Rows.Count == 0))
                        {
                            dgrdActualCostCloseOut_Readonly.DataSource = ds.Tables[11].DefaultView;
                            dgrdActualCostCloseOut_Readonly.DataBind();
                        }
                        if (!(ds.Tables[12].Rows.Count == 0))
                        {
                            dgrdILR_Readonly.DataSource = ds.Tables[12].DefaultView;
                            dgrdILR_Readonly.DataBind();
                        }
                        if (!(ds.Tables[13].Rows.Count == 0))
                        {
                            dgrdTestPlansCloseOut_Readonly.DataSource = ds.Tables[13].DefaultView;
                            dgrdTestPlansCloseOut_Readonly.DataBind();
                        }
                        if (!(ds.Tables[14].Rows.Count == 0))
                        {
                            dgrdCOReport_Readonly.DataSource = ds.Tables[14].DefaultView;
                            dgrdCOReport_Readonly.DataBind();
                        }

                        if (!(ds.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Lab_NoteBook_Number"], System.DBNull.Value)))
                            {
                                lblLabNoteBookNumberFinal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lab_NoteBook_Number"]);
                            }
                            else
                            {
                                lblLabNoteBookNumberFinal.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Completion_Date"], System.DBNull.Value)))
                            {
                                lblComplateionDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Completion_Date"]);
                            }
                            else
                            {
                                lblComplateionDate.Text = string.Empty;
                            }
                        }
                        //Actual Cost Sheet
                        if (!(ds.Tables[1].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(ds.Tables[1].Rows[0]["Total_CostSheet"], System.DBNull.Value)))
                            {
                                lblAttchFinalCost.Text = Convert.ToString(ds.Tables[1].Rows[0]["Total_CostSheet"]);
                            }
                            else
                            {
                                lblAttchFinalCost.Text = string.Empty;
                            }
                            if (!(ds.Tables[1].Rows.Count == 0))
                            {
                                int intRowCount = 0;
                                for (intRowCount = 0; intRowCount <= ds.Tables[1].Rows.Count - 1; intRowCount++)
                                {
                                    if ((!object.ReferenceEquals(ds.Tables[1].Rows[intRowCount]["Cost Sheet Attachment Paths"], System.DBNull.Value)))
                                    {
                                        string strFullFileName = Convert.ToString(ds.Tables[1].Rows[intRowCount]["Cost Sheet Attachment Paths"]);
                                        string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                        string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                        if (string.IsNullOrEmpty(lblTotAttchFinalCost.Text))
                                        {
                                            if (!string.IsNullOrEmpty(strFileSubName))
                                            {
                                                lblTotAttchFinalCost.Text = strFileSubName;
                                            }
                                            else
                                            {
                                                lblTotAttchFinalCost.Text = lblTotAttchFinalCost.Text + "," + strFileSubName;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblTotAttchFinalCost.Text = string.Empty;
                                    }
                                }
                            }
                            else
                            {
                                lblTotAttchFinalCost.Text = string.Empty;
                            }
                        }
                        //ILR
                        if (!(ds.Tables[2].Rows.Count == 0))
                        {
                            int intRowCount = 0;
                            for (intRowCount = 0; intRowCount <= ds.Tables[2].Rows.Count - 1; intRowCount++)
                            {
                                if ((!object.ReferenceEquals(ds.Tables[2].Rows[intRowCount]["Initial Learning Report Attachment Paths"], System.DBNull.Value)))
                                {
                                    string strFullFileName = Convert.ToString(ds.Tables[2].Rows[intRowCount]["Initial Learning Report Attachment Paths"]);
                                    string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                    string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                    if (string.IsNullOrEmpty(lblILRAttach.Text))
                                    {
                                        if (!string.IsNullOrEmpty(strFileSubName))
                                        {
                                            lblILRAttach.Text = strFileSubName;
                                        }
                                        else
                                        {
                                            lblILRAttach.Text = lblILRAttach.Text + "," + strFileSubName;
                                        }
                                    }
                                }
                                else
                                {
                                    lblILRAttach.Text = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            lblILRAttach.Text = string.Empty;
                        }

                        //Test Plans Used
                        if (!(ds.Tables[3].Rows.Count == 0))
                        {
                            int intRowCount = 0;
                            for (intRowCount = 0; intRowCount <= ds.Tables[3].Rows.Count - 1; intRowCount++)
                            {
                                if ((!object.ReferenceEquals(ds.Tables[3].Rows[intRowCount]["Test Plans Used Attachment Paths"], System.DBNull.Value)))
                                {
                                    string strFullFileName = Convert.ToString(ds.Tables[3].Rows[intRowCount]["Test Plans Used Attachment Paths"]);
                                    string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                    string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                    if (string.IsNullOrEmpty(lblTestPlanUsedFinal.Text))
                                    {
                                        if (!string.IsNullOrEmpty(strFileSubName))
                                        {
                                            lblTestPlanUsedFinal.Text = strFileSubName;
                                        }
                                        else
                                        {
                                            lblTestPlanUsedFinal.Text = lblTestPlanUsedFinal.Text + "," + strFileSubName;
                                        }
                                    }
                                }
                                else
                                {
                                    lblTestPlanUsedFinal.Text = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            lblTestPlanUsedFinal.Text = string.Empty;
                        }

                        //Close Out Report
                        if (!(ds.Tables[4].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Keyword_1"], System.DBNull.Value)))
                            {
                                lblCloseKeyword1.Text = Convert.ToString(ds.Tables[4].Rows[0]["Keyword_1"]);
                            }
                            else
                            {
                                lblCloseKeyword1.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Keyword_2"], System.DBNull.Value)))
                            {
                                lblCloseKeyword2.Text = Convert.ToString(ds.Tables[4].Rows[0]["Keyword_2"]);
                            }
                            else
                            {
                                lblCloseKeyword2.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Keyword_3"], System.DBNull.Value)))
                            {
                                lblCloseKeyword3.Text = Convert.ToString(ds.Tables[4].Rows[0]["Keyword_3"]);
                            }
                            else
                            {
                                lblCloseKeyword3.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Keyword_4"], System.DBNull.Value)))
                            {
                                lblCloseKeyword4.Text = Convert.ToString(ds.Tables[4].Rows[0]["Keyword_4"]);
                            }
                            else
                            {
                                lblCloseKeyword4.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Keyword_5"], System.DBNull.Value)))
                            {
                                lblCloseKeyword5.Text = Convert.ToString(ds.Tables[4].Rows[0]["Keyword_5"]);
                            }
                            else
                            {
                                lblCloseKeyword5.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Keyword_6"], System.DBNull.Value)))
                            {
                                lblCloseKeyword6.Text = Convert.ToString(ds.Tables[4].Rows[0]["Keyword_6"]);
                            }
                            else
                            {
                                lblCloseKeyword6.Text = string.Empty;
                            }
                            if ((!object.ReferenceEquals(ds.Tables[4].Rows[0]["Comments_Approvers"], System.DBNull.Value)))
                            {
                                lblAppCommentsFinal.Text = Convert.ToString(ds.Tables[4].Rows[0]["Comments_Approvers"]);
                            }
                            else
                            {
                                lblAppCommentsFinal.Text = string.Empty;
                            }
                        }
                        //Approvals GroupID
                        //If Not ds.Tables(5).Rows.Count = 0 Then
                        //    If Not ds.Tables(5).Rows(0).Item("Approval_Group_ID") Is System.DBNull.Value Then
                        //        lblAppgrpCO.Text = ds.Tables(5).Rows(0).Item("Approval_Group_ID")
                        //    Else
                        //        lblAppgrpCO.Text = String.Empty
                        //    End If
                        //    'lblSiteFinanceAppCO()
                        //    'lblBOAppCO()
                        //End If
                        //Close Out Approvals
                        if (!(ds.Tables[5].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(ds.Tables[5].Rows[0]["Approval_Group_Name"], System.DBNull.Value)))
                            {
                                lblAppgrpCO.Text = Convert.ToString(ds.Tables[5].Rows[0]["Approval_Group_Name"]);
                            }
                            else
                            {
                                lblAppgrpCO.Text = string.Empty;
                            }
                            int intRowCount = 0;
                            for (intRowCount = 0; intRowCount <= ds.Tables[5].Rows.Count - 1; intRowCount++)
                            {
                                //If ds.Tables(5).Rows(intRowCount).Item("Function_Name") Is System.DBNull.Value Or Not ds.Tables(5).Rows(intRowCount).Item("Function_Name") = "" Then
                                if ((!object.ReferenceEquals(ds.Tables[5].Rows[intRowCount]["Function_Name"], System.DBNull.Value)))
                                {
                                    if (Convert.ToString(ds.Tables[5].Rows[intRowCount]["Function_Name"]) == "Site Finance")
                                    {
                                        //If Not ds.Tables(5).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(5).Rows(intRowCount).Item("Approver_Name") = "" Then
                                        if ((!object.ReferenceEquals(ds.Tables[5].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                        {
                                            lblSiteFinanceAppCO.Text = Convert.ToString(ds.Tables[5].Rows[intRowCount]["Approver_Name"]);
                                            if ((!object.ReferenceEquals(ds.Tables[5].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                            {
                                                if (Convert.ToString(ds.Tables[5].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                                {
                                                    imgCloseOutSiteFinanceYes.Visible = true;
                                                    imgCloseOutSiteFinanceNo.Visible = false;
                                                }
                                                else if (Convert.ToString(ds.Tables[5].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                                {
                                                    imgCloseOutSiteFinanceYes.Visible = true;
                                                    imgCloseOutSiteFinanceNo.Visible = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            lblSiteFinanceAppCO.Text = string.Empty;
                                        }
                                    }
                                    if (Convert.ToString(ds.Tables[5].Rows[intRowCount]["Function_Name"]) == "Budget Center")
                                    {
                                        //If Not ds.Tables(5).Rows(intRowCount).Item("Approver_Name") Is System.DBNull.Value Or Not ds.Tables(5).Rows(intRowCount).Item("Approver_Name") = "" Then
                                        if ((!object.ReferenceEquals(ds.Tables[5].Rows[intRowCount]["Approver_Name"], System.DBNull.Value)))
                                        {
                                            lblBOAppCO.Text = Convert.ToString(ds.Tables[5].Rows[intRowCount]["Approver_Name"]);
                                            if ((!object.ReferenceEquals(ds.Tables[5].Rows[intRowCount]["Is_Approved"], System.DBNull.Value)))
                                            {
                                                if (Convert.ToString(ds.Tables[5].Rows[intRowCount]["Is_Approved"]).ToUpper() == "Y")
                                                {
                                                    imgCloseOutBudgetOwnerYes.Visible = true;
                                                    imgCloseOutBudgetOwnerNo.Visible = false;
                                                }
                                                else if (Convert.ToString(ds.Tables[5].Rows[intRowCount]["Is_Approved"]).ToUpper() == "N")
                                                {
                                                    imgCloseOutBudgetOwnerYes.Visible = true;
                                                    imgCloseOutBudgetOwnerNo.Visible = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            lblBOAppCO.Text = string.Empty;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            lblAppgrpCO.Text = string.Empty;
                            lblSiteFinanceAppCO.Text = string.Empty;
                            lblBOAppCO.Text = string.Empty;
                        }
                    }
                    //CloseOut Report
                    if (!(ds.Tables[10].Rows.Count == 0))
                    {
                        int intRowCount = 0;
                        for (intRowCount = 0; intRowCount <= ds.Tables[10].Rows.Count - 1; intRowCount++)
                        {
                            if ((!object.ReferenceEquals(ds.Tables[10].Rows[intRowCount]["Closeout Report Attachment Paths"], System.DBNull.Value)))
                            {
                                string strFullFileName = Convert.ToString(ds.Tables[10].Rows[intRowCount]["Closeout Report Attachment Paths"]);
                                string strFileName = strFullFileName.Substring(strFullFileName.LastIndexOf("\\") + 1, (strFullFileName.Length - 1) - (strFullFileName.LastIndexOf("\\")));
                                string strFileSubName = strFileName.Substring(strFileName.LastIndexOf("_") + 1, (strFileName.Length - 1) - (strFileName.LastIndexOf("_")));
                                if (string.IsNullOrEmpty(lblCloseoutReportRO.Text))
                                {
                                    if (!string.IsNullOrEmpty(strFileSubName))
                                    {
                                        lblCloseoutReportRO.Text = strFileSubName;
                                    }
                                    else
                                    {
                                        lblCloseoutReportRO.Text = lblCloseoutReportRO.Text + "," + strFileSubName;
                                    }
                                }
                            }
                            else
                            {
                                lblCloseoutReportRO.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        lblCloseoutReportRO.Text = string.Empty;
                    }
                }
            }
        }

        protected void btnTabPreliminary_Click(object sender, EventArgs e)
        {
            btnTabPreliminary.ImageUrl = "../Images/preliminary-over.gif";
            btnTabFinal.ImageUrl = "../Images/final-nor.gif";
            btnTabCloseOut.ImageUrl = "../Images/close-out-nor.gif";


            if (Convert.ToString(ViewState["stage"]) == Convert.ToString("Preliminary") & Convert.ToString(ViewState["Status"]) == Convert.ToString("Draft"))
            {
                lblStageLevel.Text = "Preliminary";
                lblStatusType.Text = "Draft";
            }
            else
            {
                lblStageLevel.Text = "Preliminary";
                lblStatusType.Text = "Routed";
            }

            //lblStageLevel.Text = "Preliminary Stage"
            //lblStatusType.Text = "Draft"

            getEOPreliminary();

            trPreliminary.Visible = true;
            trFinal.Visible = false;
            trCloseOut.Visible = false;
        }

        protected void btnTabFinal_Click(object sender, EventArgs e)
        {
            btnTabFinal.ImageUrl = "../Images/final-over.gif";
            btnTabPreliminary.ImageUrl = "../Images/preliminary-nor.gif";
            btnTabCloseOut.ImageUrl = "../Images/close-out-nor.gif";

            //lblStageLevel.Text = "Final Stage"
            //lblStatusType.Text = "Draft"


            if (Convert.ToString(ViewState["stage"]) == Convert.ToString("Preliminary"))
            {
                lblStageLevel.Text = "Final";
                lblStatusType.Text = "Draft";
            }
            else if (Convert.ToString(ViewState["stage"]) == Convert.ToString("Final") & Convert.ToString(ViewState["Status"]) == Convert.ToString("Draft"))
            {
                lblStageLevel.Text = "Final";
                lblStatusType.Text = "Draft";
            }
            else
            {
                lblStageLevel.Text = "Final";
                lblStatusType.Text = "Routed";
            }

            getEOFinal();

            trPreliminary.Visible = false;
            trFinal.Visible = true;
            trCloseOut.Visible = false;
            hidEOstage.Value = "2";
        }

        protected void btnTabCloseOut_Click(object sender, EventArgs e)
        {
            btnTabPreliminary.ImageUrl = "../Images/preliminary-nor.gif";
            btnTabFinal.ImageUrl = "../Images/final-nor.gif";
            btnTabCloseOut.ImageUrl = "../Images/close-out-over.gif";

            //lblStageLevel.Text = "Close-Out Stage"
            //lblStatusType.Text = "Draft"


            if (Convert.ToString(ViewState["stage"]) == Convert.ToString("Preliminary"))
            {
                lblStageLevel.Text = "CloseOut";
                lblStatusType.Text = "Draft";
            }
            else if (Convert.ToString(ViewState["stage"]) == Convert.ToString("Final"))
            {
                lblStageLevel.Text = "CloseOut";
                lblStatusType.Text = "Draft";
            }
            else if (Convert.ToString(ViewState["stage"]) == Convert.ToString("CloseOut") & Convert.ToString(ViewState["Status"]) == Convert.ToString("Draft"))
            {
                lblStageLevel.Text = "CloseOut";
                lblStatusType.Text = "Draft";
            }
            else if (Convert.ToString(ViewState["stage"]) == Convert.ToString("CloseOut") & Convert.ToString(ViewState["Status"]) == Convert.ToString("Approved"))
            {
                lblStageLevel.Text = "CloseOut";
                lblStatusType.Text = "Completed";
            }
            else
            {
                lblStageLevel.Text = "CloseOut";
                lblStatusType.Text = "Routed";
            }



            getEOCloseOut();

            trPreliminary.Visible = false;
            trFinal.Visible = false;
            trCloseOut.Visible = true;
            hidEOstage.Value = "3";
        }


        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEO.aspx?From=ForEOEdit&EOID=" + Request.QueryString["EO_ID"]);
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgrdAttachment_ReadOnly_ItemCommand
        //Written BY	    :	chary
        //parameters     :	source,DataGridCommandEventArgs
        //Purpose	    :   To Open the attachments when user clicks on the attachment link in Readonly/Lock mode
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/02/08                 chary              1.0       
        //***************************************************
        protected void dgrdAttachment_ReadOnly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString =Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfo(intAttachmentId, eoiD, "PDI", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }
            }
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgrdCostSheetFinal_ReadOnly_ItemCommand
        //Written BY	    :	chary
        //parameters     :	source,DataGridCommandEventArgs
        //Purpose	    :   To Open the attachments when user clicks on the attachment link in Readonly/Lock mode
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/02/08                 chary              1.0       
        //***************************************************
        protected void dgrdCostSheetFinal_ReadOnly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameCostSheetFinalRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "Cost", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])dsAttachments.Tables[0].Rows[0]["Attachment_Content"];
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                    string s = null;
                    s = ex.Message;
                }
            }
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgrdQAFinalTabAttachment_Readonly_ItemCommand
        //Written BY	    :	chary
        //parameters     :	source,DataGridCommandEventArgs
        //Purpose	    :   To Open the attachments when user clicks on the attachment link in Readonly/Lock mode
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //06/02/08                 chary              1.0       
        //***************************************************
        protected void dgrdQAFinalTabAttachment_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameQARO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "QA", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])dsAttachments.Tables[0].Rows[0]["Attachment_Content"];
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }
            }
        }
        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgrdFormulaCard_Readonly_ItemCommand
        //Written BY	    :	chary
        //parameters     :	source,DataGridCommandEventArgs
        //Purpose	    :   To Open the attachments when user clicks on the attachment link in Readonly/Lock mode
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //06/02/08                 chary              1.0       
        //***************************************************
        protected void dgrdFormulaCard_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameFormulaCardRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "Formula", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }
            }
        }
        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgrdTestPlansFinal_Readonly_ItemCommand
        //Written BY	    :	chary
        //parameters     :	source,DataGridCommandEventArgs
        //Purpose	    :   To Open the attachments when user clicks on the attachment link in Readonly/Lock mode
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //06/02/08                 chary              1.0       
        //***************************************************
        protected void dgrdTestPlansFinal_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameTestPlansFinalRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "Test_Plans", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }
            }
        }
        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgrdLabSamp_Readonly_ItemCommand
        //Written BY	    :	chary
        //parameters     :	source,DataGridCommandEventArgs
        //Purpose	    :   To Open the attachments when user clicks on the attachment link in Readonly/Lock mode
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //06/02/08                 chary              1.0       
        //***************************************************
        protected void dgrdLabSamp_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameLabSampRO");
                    int intAttachmentId =Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "Lab", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();


                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void dgrdTestMatrix_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameTestMatrixRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "Matrix", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //'Response.ContentType = "image/jpeg"
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();


                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void dgrdOtherDocFinal_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameOtherDocFinalRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoFinal(intAttachmentId, eoiD, "Others", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();


                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void dgrdActualCostCloseOut_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Final_Click")
                {
                    try
                    {
                        Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameActualCostCloseOutRO");
                        int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                        string EoiDString = Convert.ToString(ViewState["EOID"]);
                        int eoiD = Convert.ToInt32(EoiDString);
                        DataSet dsAttachments = new DataSet();

                        objEOBA.GetAttachmentsInfoCO(intAttachmentId, eoiD, "Actual", ref dsAttachments);
                        Response.Clear();
                        //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                        //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                        //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                        //    End If
                        //Else
                        //End If
                        //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                        //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                        //Response.End()

                        if (!(dsAttachments.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                            {
                                Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                                //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                            }
                        }
                        else
                        {
                        }

                        byte[] content = null;
                        content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                        string len = null;
                        len = Convert.ToString(content.Length);


                        byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                        byte[] bytTempArray = null;


                        if ((bytArray.Length < 2 | bytArray.Length == 2))
                        {
                            bytTempArray = new byte[bytArray.Length + 3];
                            Array.Copy(bytArray, bytTempArray, bytArray.Length);
                        }
                        else
                        {
                            bytTempArray = new byte[bytArray.Length - 1];
                            Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                        }


                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                            {
                                Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                                Response.BinaryWrite(bytTempArray);
                            }
                            else
                            {
                                Response.AddHeader("Content-Length", content.Length.ToString());
                                Response.BinaryWrite(content);
                            }
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }


                        Response.Flush();

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

        protected void dgrdILR_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameILRRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoCO(intAttachmentId, eoiD, "Learning", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then

                    //    End If
                    //Else
                    //End If
                    //Response.ContentType = "application/octet-stream"
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void dgrdTestPlansCloseOut_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameTestPlansCloseOutRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoCO(intAttachmentId, eoiD, "Plans_Used", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }

            }
        }

        protected void dgrdCOReport_Readonly_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFileNameCOReportRO");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = Convert.ToString(ViewState["EOID"]);
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();

                    objEOBA.GetAttachmentsInfoCO(intAttachmentId, eoiD, "Report", ref dsAttachments);
                    Response.Clear();
                    //If Not dsAttachments.Tables(0).Rows.Count = 0 Then
                    //    If Not dsAttachments.Tables(0).Rows(0).Item("Attachment_Type") Is DBNull.Value Then
                    //        Response.ContentType = dsAttachments.Tables(0).Rows(0).Item("Attachment_Type")
                    //    End If
                    //Else
                    //End If
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + CStr(dsAttachments.Tables(0).Rows(0).Item("Attachment_File_Name")))
                    //Response.BinaryWrite(CType(dsAttachments.Tables(0).Rows(0).Item("Attachment_Content"), Byte()))
                    //Response.End()

                    if (!(dsAttachments.Tables[0].Rows.Count == 0))
                    {
                        if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                        {
                            Response.ContentType = Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]);


                            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
                        }
                    }
                    else
                    {
                    }

                    byte[] content = null;
                    content = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    string len = null;
                    len = Convert.ToString(content.Length);


                    byte[] bytArray = (byte[])(dsAttachments.Tables[0].Rows[0]["Attachment_Content"]);
                    byte[] bytTempArray = null;


                    if ((bytArray.Length < 2 | bytArray.Length == 2))
                    {
                        bytTempArray = new byte[bytArray.Length + 3];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length);
                    }
                    else
                    {
                        bytTempArray = new byte[bytArray.Length - 1];
                        Array.Copy(bytArray, bytTempArray, bytArray.Length - 2);
                    }


                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_File_Name"]));


                    if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                    {
                        if (((Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") | (Convert.ToString(dsAttachments.Tables[0].Rows[0]["Attachment_Type"]) == "application/vnd.openxmlformats-officedocument.pres")))
                        {
                            Response.AddHeader("Content-Length", bytTempArray.Length.ToString());
                            Response.BinaryWrite(bytTempArray);
                        }
                        else
                        {
                            Response.AddHeader("Content-Length", content.Length.ToString());
                            Response.BinaryWrite(content);
                        }
                    }
                    else
                    {
                        Response.AddHeader("Content-Length", content.Length.ToString());
                        Response.BinaryWrite(content);
                    }


                    Response.Flush();

                }
                catch (Exception ex)
                {
                }

            }
        }

    }
}