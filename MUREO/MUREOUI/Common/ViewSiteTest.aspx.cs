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
    public partial class ViewSiteTest : System.Web.UI.Page
    {
        SiteTest objGetSiteTest = new SiteTest();
        SiteTestBA objSiteTestBA = new SiteTestBA();
        clsAttachmentsBA objclsAttachmentsBA = new clsAttachmentsBA();

        //BusinessObject.MUREO.BusinessObject.attachments objGetAttachSiteTest;

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            btnPrintStage.Attributes.Add("OnClick", "javascript:return printStage(1);");
            if (!Page.IsPostBack)
            {
                txthdnEOID.Text = Request.QueryString["EoID"];
                if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "Print")
                {
                    trheader.Visible = false;
                    trFooter.Visible = false;
                    DataSet dsSiteTest = new DataSet();
                    dsSiteTest = new DataSet();
                    //dsSiteTest = objGetSiteTest.FillSiteTest(Convert.ToInt32(txthdnEOID.Text));
                    if (objSiteTestBA.FillSiteTest(Convert.ToInt32(txthdnEOID.Text), ref dsSiteTest))
                    {
                        if (dsSiteTest == null)
                        {
                        }
                        else if (dsSiteTest.Tables.Count == 0)
                        {
                        }
                        else if (dsSiteTest.Tables[3].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            string stMode = null;
                            stMode = dsSiteTest.Tables[3].Rows[0]["ST_Mode"].ToString();
                            if (stMode == "P")
                            {
                                txthdnPlantType.Text = "1";
                            }
                            else if (stMode == "C")
                            {
                                txthdnPlantType.Text = "2";
                            }
                            else if (stMode == "S")
                            {
                                txthdnPlantType.Text = "0";
                            }
                        }
                    }
                    if (txthdnPlantType.Text == "1")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = true;
                    }
                    else if (txthdnPlantType.Text == "2")
                    {
                        tblPPM.Visible = false;
                        tblConverting.Visible = true;
                    }
                    else if (txthdnPlantType.Text == "0")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = false;
                    }
                    trApproval.Visible = false;
                    FillSiteTest();
                    Response.Write("<script>window.print();</script>");
                }
                else
                {
                    DataSet dsSiteTest = new DataSet();
                    dsSiteTest = new DataSet();
                    //dsSiteTest = objGetSiteTest.FillSiteTest(Convert.ToInt32(txthdnEOID.Text));
                    if (objSiteTestBA.FillSiteTest(Convert.ToInt32(txthdnEOID.Text), ref dsSiteTest))
                    {
                        if (dsSiteTest == null)
                        {
                        }
                        else if (dsSiteTest.Tables.Count == 0)
                        {
                        }
                        else if (dsSiteTest.Tables[3].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            string stMode = null;
                            stMode = dsSiteTest.Tables[3].Rows[0]["ST_Mode"].ToString();
                            if (stMode == "P")
                            {
                                txthdnPlantType.Text = "1";
                            }
                            else if (stMode == "C")
                            {
                                txthdnPlantType.Text = "2";
                            }
                            else if (stMode == "S")
                            {
                                txthdnPlantType.Text = "0";
                            }
                        }
                    }
                    if (txthdnPlantType.Text == "1")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = true;
                    }
                    else if (txthdnPlantType.Text == "2")
                    {
                        tblPPM.Visible = false;
                        tblConverting.Visible = true;
                    }
                    else if (txthdnPlantType.Text == "0")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = false;
                    }
                    trApproval.Visible = false;
                    FillSiteTest();
                }
            }
        }

        private void FillSiteTest()
        {
            SiteTest objGetSiteTest = new SiteTest();
            DataSet dsSiteTest = new DataSet();
            dsSiteTest = new DataSet();
            //dsSiteTest = objGetSiteTest.FillSiteTest(Convert.ToInt32(txthdnEOID.Text));
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(txthdnEOID.Text), ref dsSiteTest))
            {
                if (dsSiteTest == null)
                {
                }
                else if (dsSiteTest.Tables.Count == 0)
                {

                }
                else
                {

                    if (dsSiteTest.Tables[0].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["EO_Number"], System.DBNull.Value))
                        {
                            lblEONum.Text = "";
                        }
                        else
                        {
                            lblEONum.Text = dsSiteTest.Tables[0].Rows[0]["EO_Number"].ToString();
                        }


                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value))
                        {
                            lblTitle.Text = "";
                        }
                        else
                        {
                            lblTitle.Text = dsSiteTest.Tables[0].Rows[0]["EO_Title"].ToString();
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Category_Name"], System.DBNull.Value))
                        {
                            lblCategory.Text = "";
                        }
                        else
                        {
                            lblCategory.Text = dsSiteTest.Tables[0].Rows[0]["Category_Name"].ToString();
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Plant_Name"], System.DBNull.Value))
                        {
                            lblPlantName.Text = "";
                        }
                        else
                        {
                            lblPlantName.Text = dsSiteTest.Tables[0].Rows[0]["Plant_Name"].ToString();
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Project_Name"], System.DBNull.Value))
                        {
                            lblProject.Text = "";
                        }
                        else
                        {
                            lblProject.Text = dsSiteTest.Tables[0].Rows[0]["Project_Name"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Office_Num"], System.DBNull.Value))
                        {
                            lblOfficeNum.Text = "";
                        }
                        else
                        {
                            lblOfficeNum.Text = dsSiteTest.Tables[0].Rows[0]["Office_Num"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Originator"], System.DBNull.Value))
                        {
                            lblOriginator.Text = "";
                        }
                        else
                        {
                            lblOriginator.Text = dsSiteTest.Tables[0].Rows[0]["Originator"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["CoOriginator"], System.DBNull.Value))
                        {
                            lblCoOriginator.Text = "";
                        }
                        else
                        {
                            lblCoOriginator.Text = dsSiteTest.Tables[0].Rows[0]["CoOriginator"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Phone_Num"], System.DBNull.Value))
                        {
                            lblPhoneNum.Text = "";
                        }
                        else
                        {
                            lblPhoneNum.Text = dsSiteTest.Tables[0].Rows[0]["Phone_Num"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Phone_Num"], System.DBNull.Value))
                        {
                            lblPhoneNum.Text = "";
                        }
                        else
                        {
                            lblPhoneNum.Text = dsSiteTest.Tables[0].Rows[0]["Phone_Num"].ToString();
                        }

                        if (dsSiteTest.Tables[2].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[2].Rows[0]["Brand_Segment_Name"], System.DBNull.Value))
                            {
                                lblBrandsDB.Text = "";
                            }
                            else
                            {
                                lblBrandsDB.Text = dsSiteTest.Tables[2].Rows[0]["Brand_Segment_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[2].Rows[0]["Brand_Segment_Name"], System.DBNull.Value))
                            {
                                lblEOSelectedBrandDB.Text = "";
                            }
                            else
                            {
                                lblEOSelectedBrandDB.Text = dsSiteTest.Tables[2].Rows[0]["Brand_Segment_Name"].ToString();
                            }
                        }

                        if (dsSiteTest.Tables[1].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[1].Rows[0]["Event_Name"], System.DBNull.Value))
                            {
                                lblEventDB.Text = "";
                            }
                            else
                            {
                                lblEventDB.Text = dsSiteTest.Tables[1].Rows[0]["Event_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[1].Rows[0]["Event_ID"], System.DBNull.Value))
                            {
                                txthdnEventID.Text = "";
                            }
                            else
                            {
                                txthdnEventID.Text = dsSiteTest.Tables[1].Rows[0]["Event_ID"].ToString();
                            }
                        }
                    }

                    if (dsSiteTest.Tables[3].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"], System.DBNull.Value))
                        {
                        }
                        else
                        {
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"], System.DBNull.Value))
                        {
                            lblStartDate.Text = "";
                        }
                        else
                        {
                            System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"]);
                            lblStartDate.Text = d.Date.ToShortDateString();
                            DateTime dtime = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"]);
                            int hr = dtime.Hour;
                            int min = dtime.Minute;
                            int sec = dtime.Second;
                            string Part = null;
                            if (hr > 11)
                            {
                                hr = hr - 12;
                                Part = "PM";
                            }
                            else
                            {
                                Part = "AM";
                            }
                            string sTime = hr + ":" + min + ":" + sec + " " + Part;
                            lblStartTime.Text = sTime;
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Test_End_Date"], System.DBNull.Value))
                        {
                            lblEndDate.Text = "";
                        }
                        else
                        {
                            System.DateTime dt = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_End_Date"]);
                            lblEndDate.Text = dt.Date.ToShortDateString();
                            DateTime dtime = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_End_Date"]);
                            int hr = dtime.Hour;
                            int min = dtime.Minute;
                            int sec = dtime.Second;
                            string Part = null;
                            if (hr > 11)
                            {
                                hr = hr - 12;
                                Part = "PM";
                            }
                            else
                            {
                                Part = "AM";
                            }
                            string sTime = hr + ":" + min + ":" + sec + " " + Part;
                            lblEndTime.Text = sTime;
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Objective"], System.DBNull.Value))
                        {
                            lblObjective.Text = "";
                        }
                        else
                        {
                            lblObjective.Text = dsSiteTest.Tables[3].Rows[0]["Objective"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Description"], System.DBNull.Value))
                        {
                            lblDescription.Text = "";
                        }
                        else
                        {
                            lblDescription.Text = dsSiteTest.Tables[3].Rows[0]["Description"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Memo"], System.DBNull.Value))
                        {
                            lblMemo.Text = "";
                        }
                        else
                        {
                            lblMemo.Text = dsSiteTest.Tables[3].Rows[0]["Memo"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Affected_Lines_Machines"], System.DBNull.Value))
                        {
                            lblAffectedMachines.Text = "";
                        }
                        else
                        {
                            lblAffectedMachines.Text = dsSiteTest.Tables[3].Rows[0]["Affected_Lines_Machines"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Final_Report_Due"], System.DBNull.Value))
                        {
                            lblReportDue.Text = "";
                        }
                        else
                        {
                            lblReportDue.Text = dsSiteTest.Tables[3].Rows[0]["Final_Report_Due"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Final_Report_Due"], System.DBNull.Value))
                        {
                            lblReportDue.Text = "";
                        }
                        else
                        {
                            lblReportDue.Text = dsSiteTest.Tables[3].Rows[0]["Final_Report_Due"].ToString();
                        }
                    }
                    if (dsSiteTest.Tables[4].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["Additional_Info"], System.DBNull.Value))
                        {
                            lblAddInfo.Text = "";
                        }
                        else
                        {
                            lblAddInfo.Text = dsSiteTest.Tables[4].Rows[0]["Additional_Info"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Chemical_Change"], System.DBNull.Value))
                        {
                            lblrbChange.Text = "";
                        }
                        else
                        {
                            lblrbChange.Text = dsSiteTest.Tables[4].Rows[0]["New_Chemical_Change"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Raw_Material_Change"], System.DBNull.Value))
                        {
                            lblrbRM.Text = "";
                        }
                        else
                        {
                            lblrbRM.Text = dsSiteTest.Tables[4].Rows[0]["New_Raw_Material_Change"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Equip_Process_System"], System.DBNull.Value))
                        {
                            lblrbEqp.Text = "";
                        }
                        else
                        {
                            lblrbEqp.Text = dsSiteTest.Tables[4].Rows[0]["New_Equip_Process_System"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"], System.DBNull.Value))
                        {
                            lblrbJob.Text = "";
                        }
                        else
                        {
                            lblrbJob.Text = dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Storage_Concers"], System.DBNull.Value))
                        {
                            lblrbStg.Text = "";
                        }
                        else
                        {
                            lblrbStg.Text = dsSiteTest.Tables[4].Rows[0]["New_Storage_Concers"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"], System.DBNull.Value))
                        {
                            lblrbJob.Text = "";
                        }
                        else
                        {
                            lblrbJob.Text = dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["Is_Chemical_Approval_Needed"], System.DBNull.Value))
                        {
                            lblrbAppr.Text = "";
                        }
                        else
                        {
                            lblrbAppr.Text = dsSiteTest.Tables[4].Rows[0]["Is_Chemical_Approval_Needed"].ToString();
                        }
                        if (lblrbAppr.Text == "Y")
                        {
                            trApproval.Visible = true;
                        }
                        else
                        {
                            trApproval.Visible = false;
                        }
                    }
                    if (dsSiteTest.Tables[5].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_USE"], System.DBNull.Value))
                        {
                            lblPrecautions.Text = "";
                        }
                        else
                        {
                            lblPrecautions.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_USE"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_SAMPLING"], System.DBNull.Value))
                        {
                            lblSampling.Text = "";
                        }
                        else
                        {
                            lblSampling.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_SAMPLING"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_EQUIPMENT"], System.DBNull.Value))
                        {
                            lblEquipment.Text = "";
                        }
                        else
                        {
                            lblEquipment.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_EQUIPMENT"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Disposal_UnUsed_Chemical"], System.DBNull.Value))
                        {
                            lblDispose.Text = "";
                        }
                        else
                        {
                            lblDispose.Text = dsSiteTest.Tables[5].Rows[0]["Disposal_UnUsed_Chemical"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_STORAGE"], System.DBNull.Value))
                        {
                            lblStorage.Text = "";
                        }
                        else
                        {
                            lblStorage.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_STORAGE"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Spill_Response"], System.DBNull.Value))
                        {
                            lblSpill.Text = "";
                        }
                        else
                        {
                            lblSpill.Text = dsSiteTest.Tables[5].Rows[0]["Spill_Response"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Potential_Environmental_Impact"], System.DBNull.Value))
                        {
                            lblEnvImpacts.Text = "";
                        }
                        else
                        {
                            lblEnvImpacts.Text = dsSiteTest.Tables[5].Rows[0]["Potential_Environmental_Impact"].ToString();
                        }
                    }
                    int intRowCount = 0;
                    if (!(dsSiteTest.Tables[14].Rows.Count == 0))
                    {
                        dgrdTestPlan.DataSource = dsSiteTest.Tables[14].DefaultView;
                        dgrdTestPlan.DataBind();
                    }
                    if (!(dsSiteTest.Tables[15].Rows.Count == 0))
                    {
                        dgrdSupAttach.DataSource = dsSiteTest.Tables[15].DefaultView;
                        dgrdSupAttach.DataBind();
                    }
                    if (!(dsSiteTest.Tables[16].Rows.Count == 0))
                    {
                        dgrdAttachment.DataSource = dsSiteTest.Tables[16].DefaultView;
                        dgrdAttachment.DataBind();
                    }
                    if (txthdnPlantType.Text == "2")
                    {

                        if (dsSiteTest.Tables[6].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Conv_Test_Coordinator"], System.DBNull.Value))
                            {
                                lblCoordinator.Text = "";
                            }
                            else
                            {
                                lblCoordinator.Text = dsSiteTest.Tables[6].Rows[0]["Conv_Test_Coordinator"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Number_Of_Days"], System.DBNull.Value))
                            {
                                lblDays.Text = "";
                            }
                            else
                            {
                                lblDays.Text = dsSiteTest.Tables[6].Rows[0]["Number_Of_Days"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Preferred_Run_Dates"], System.DBNull.Value))
                            {
                                lblPreRunDates.Text = "";
                            }
                            else
                            {
                                lblPreRunDates.Text = dsSiteTest.Tables[6].Rows[0]["Preferred_Run_Dates"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Earliest_Run_Dates"], System.DBNull.Value))
                            {
                                lblEarlRunDates.Text = "";
                            }
                            else
                            {
                                lblEarlRunDates.Text = dsSiteTest.Tables[6].Rows[0]["Earliest_Run_Dates"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Latest_Run_Dates"], System.DBNull.Value))
                            {
                                lblLRDates.Text = "";
                            }
                            else
                            {
                                lblLRDates.Text = dsSiteTest.Tables[6].Rows[0]["Latest_Run_Dates"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"], System.DBNull.Value))
                            {
                                lblrdCTPYes.Text = "";
                            }
                            else
                            {
                                lblrdCTPYes.Text = dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line_Name"], System.DBNull.Value))
                            {
                                lblPrefConline.Text = "";
                            }
                            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line_Name"] == "--SELECT--")
                            {
                                lblPrefConline.Text = "";
                            }
                            else
                            {
                                lblPrefConline.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line_Name"], System.DBNull.Value))
                            {
                                lblAltConvLine.Text = "";
                            }
                            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line_Name"] == "--SELECT--")
                            {
                                lblAltConvLine.Text = "";
                            }
                            else
                            {
                                lblAltConvLine.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup_Machine_Name"], System.DBNull.Value))
                            {
                                lblElsetup.Text = "";
                            }
                            else if (dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup_Machine_Name"] == "--SELECT--")
                            {
                                lblElsetup.Text = "";
                            }
                            else
                            {
                                lblElsetup.Text = dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup_Machine_Name"].ToString();
                            }

                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Emboss_Pattern"], System.DBNull.Value))
                            {
                                lblEquEmbossPattern.Text = "";
                            }
                            else
                            {
                                lblEquEmbossPattern.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Emboss_Pattern"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"], System.DBNull.Value))
                            {
                                lblHotMelt.Text = "";
                            }
                            else
                            {
                                lblHotMelt.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"], System.DBNull.Value))
                            {
                                lblExtrHeads.Text = "";
                            }
                            else
                            {
                                lblExtrHeads.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Extrusion_Heads_Count"], System.DBNull.Value))
                            {
                                lblExtrusionHeads.Text = "";
                            }
                            else
                            {
                                lblExtrusionHeads.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Extrusion_Heads_Count"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"], System.DBNull.Value))
                            {
                                lblrbHeadsHeated.Text = "";
                            }
                            else
                            {
                                lblrbHeadsHeated.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"], System.DBNull.Value))
                            {
                                lblrbIstreamreqd.Text = "";
                            }
                            else
                            {
                                lblrbIstreamreqd.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"], System.DBNull.Value))
                            {
                                lblrbInk.Text = "";
                            }
                            else
                            {
                                lblrbInk.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Yellow_Gallons"], System.DBNull.Value))
                            {
                                lblYellow.Text = "";
                            }
                            else
                            {
                                lblYellow.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Yellow_Gallons"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Magenta_Gallons"], System.DBNull.Value))
                            {
                                lblMagneta.Text = "";
                            }
                            else
                            {
                                lblMagneta.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Magenta_Gallons"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Cyan_Gallons"], System.DBNull.Value))
                            {
                                lblCyan.Text = "";
                            }
                            else
                            {
                                lblCyan.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Cyan_Gallons"], System.DBNull.Value))
                            {
                                lblBlack.Text = "";
                            }
                            else
                            {
                                lblBlack.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Equipment"], System.DBNull.Value))
                            {
                                lblOtheEquipment.Text = "";
                            }
                            else
                            {
                                lblOtheEquipment.Text = dsSiteTest.Tables[6].Rows[0]["Other_Equipment"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Material"], System.DBNull.Value))
                            {
                                lblOtherMat.Text = "";
                            }
                            else
                            {
                                lblOtherMat.Text = dsSiteTest.Tables[6].Rows[0]["Other_Material"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Other"], System.DBNull.Value))
                            {
                                lblOther.Text = "";
                            }
                            else
                            {
                                lblOther.Text = dsSiteTest.Tables[6].Rows[0]["Other_Other"].ToString();
                            }
                        }
                    }
                    if (txthdnPlantType.Text == "1")
                    {
                        if (dsSiteTest.Tables[7].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Run_Investigate_Module"], System.DBNull.Value))
                            {
                                lblrbPPMMOdel.Text = "";
                            }
                            else
                            {
                                lblrbPPMMOdel.Text = dsSiteTest.Tables[7].Rows[0]["Run_Investigate_Module"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Test_COordinator"], System.DBNull.Value))
                            {
                                lblPPMCoordiator.Text = "";
                            }
                            else
                            {
                                lblPPMCoordiator.Text = dsSiteTest.Tables[7].Rows[0]["Test_COordinator"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Number_Of_Days"], System.DBNull.Value))
                            {
                                lblPMDays.Text = "";
                            }
                            else
                            {
                                lblPMDays.Text = dsSiteTest.Tables[7].Rows[0]["Number_Of_Days"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Preferred_Run_Dates"], System.DBNull.Value))
                            {
                                lblPPMPRDate.Text = "";
                            }
                            else
                            {
                                lblPPMPRDate.Text = dsSiteTest.Tables[7].Rows[0]["Preferred_Run_Dates"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Earliest_Run_Dates"], System.DBNull.Value))
                            {
                                lblPPMERDate.Text = "";
                            }
                            else
                            {
                                lblPPMERDate.Text = dsSiteTest.Tables[7].Rows[0]["Earliest_Run_Dates"].ToString();
                            }

                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Latest_Run_Dates"], System.DBNull.Value))
                            {
                                lblPPMLRDates.Text = "";
                            }
                            else
                            {
                                lblPPMLRDates.Text = dsSiteTest.Tables[7].Rows[0]["Latest_Run_Dates"].ToString();
                            }

                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Consumer_Test_Production"], System.DBNull.Value))
                            {
                                lblrbPPMCTP.Text = "";
                            }
                            else
                            {
                                lblrbPPMCTP.Text = dsSiteTest.Tables[7].Rows[0]["Consumer_Test_Production"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Equ_Drying_Format_Machine_Name"], System.DBNull.Value))
                            {
                                lblDrying.Text = "";
                            }
                            else if (dsSiteTest.Tables[7].Rows[0]["Equ_Drying_Format_Machine_Name"] == "--SELECT--")
                            {
                                lblDrying.Text = "";
                            }
                            else
                            {
                                lblDrying.Text = dsSiteTest.Tables[7].Rows[0]["Equ_Drying_Format_Machine_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Equ_PM_Format_Machine_Name"], System.DBNull.Value))
                            {
                                lblFormat.Text = "";
                            }
                            else if (dsSiteTest.Tables[7].Rows[0]["Equ_PM_Format_Machine_Name"] == "--SELECT--")
                            {
                                lblFormat.Text = "";
                            }
                            else
                            {
                                lblFormat.Text = dsSiteTest.Tables[7].Rows[0]["Equ_PM_Format_Machine_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Equ_Headbox_Type_Machine_Name"], System.DBNull.Value))
                            {
                                lblHeadbox.Text = "";
                            }
                            else if (dsSiteTest.Tables[7].Rows[0]["Equ_Headbox_Type_Machine_Name"] == "--SELECT--")
                            {
                                lblHeadbox.Text = "";
                            }
                            else
                            {
                                lblHeadbox.Text = dsSiteTest.Tables[7].Rows[0]["Equ_Headbox_Type_Machine_Name"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_Is_Karlinal"], System.DBNull.Value))
                            {
                                lblrbKarli.Text = "";
                            }
                            else
                            {
                                lblrbKarli.Text = dsSiteTest.Tables[7].Rows[0]["Mat_Is_Karlinal"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_Karlinal_Gallons"], System.DBNull.Value))
                            {
                                lblGallons.Text = "";
                            }
                            else
                            {
                                lblGallons.Text = dsSiteTest.Tables[7].Rows[0]["Mat_Karlinal_Gallons"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_CPN_Belts"], System.DBNull.Value))
                            {
                                lblrdCPN.Text = "";
                            }
                            else
                            {
                                lblrdCPN.Text = dsSiteTest.Tables[7].Rows[0]["Mat_CPN_Belts"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_Patter_Per_Belt"], System.DBNull.Value))
                            {
                                lblPatterns.Text = "";
                            }
                            else
                            {
                                lblPatterns.Text = dsSiteTest.Tables[7].Rows[0]["Mat_Patter_Per_Belt"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Other_Equipment"], System.DBNull.Value))
                            {
                                lblEquip.Text = "";
                            }
                            else
                            {
                                lblEquip.Text = dsSiteTest.Tables[7].Rows[0]["Other_Equipment"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Other_Material"], System.DBNull.Value))
                            {
                                lblMaterials.Text = "";
                            }
                            else
                            {
                                lblMaterials.Text = dsSiteTest.Tables[7].Rows[0]["Other_Material"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Other_Other"], System.DBNull.Value))
                            {
                                lblOtherPPM.Text = "";
                            }
                            else
                            {
                                lblOtherPPM.Text = dsSiteTest.Tables[7].Rows[0]["Other_Other"].ToString();
                            }
                        }
                    }
                    //Fill Concurrence
                    if (dsSiteTest.Tables[12].Rows.Count == 0)
                    {
                        tdLstConAppr.Visible = false;
                        dlstConcGrp.Visible = false;
                    }
                    else
                    {
                        tdLstConAppr.Visible = true;
                        dlstConcGrp.Visible = true;
                        dlstConcGrp.DataSource = dsSiteTest.Tables[12];
                        dlstConcGrp.DataBind();
                    }
                    if (dsSiteTest.Tables[11].Rows.Count == 0)
                    {
                        dgrdFYI.Visible = false;
                    }
                    else
                    {
                        dgrdFYI.DataSource = dsSiteTest.Tables[11];
                        dgrdFYI.DataBind();
                        dgrdFYI.Visible = true;
                    }
                    if (dsSiteTest.Tables[13].Rows.Count == 0)
                    {
                        dgrdRevHis.Visible = false;
                    }
                    else
                    {
                        dgrdRevHis.DataSource = dsSiteTest.Tables[13];
                        dgrdRevHis.DataBind();
                        dgrdRevHis.Visible = true;
                    }
                }
            }

        }

        private void imgSubmit_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("../Common/SiteTest.aspx?EoID=" + txthdnEOID.Text + "&From=EDIT&PlantType=" + txthdnPlantType.Text + "&EventID=" + txthdnEventID.Text);
        }

        private void imgCancel_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string Page = null;
            Response.Redirect("../Common/Home.aspx");
        }

        private void btnPrintStage_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
        }

        private void dgrdTestPlan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblattachID");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = txthdnEOID.Text;
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();
                    //dsAttachments = objGetAttachSiteTest.GetAttachmentsInfo(intAttachmentId, eoiD, "Test_Plan");
                    if (objclsAttachmentsBA.GetAttachmentsInfo(intAttachmentId, eoiD, "Test_Plan", ref dsAttachments))
                    {
                        Response.Clear();
                        if (!(dsAttachments.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                            {
                                Response.ContentType = dsAttachments.Tables[0].Rows[0]["Attachment_Type"].ToString();
                            }
                        }
                        else
                        {
                        }
                        byte[] content = null;
                        content = (byte[])dsAttachments.Tables[0].Rows[0]["ST_TP_Attachment_Content"];
                        string len = null;
                        len = Convert.ToString(content.Length);
                        byte[] bytArray = (byte[])dsAttachments.Tables[0].Rows[0]["ST_TP_Attachment_Content"];
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
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Test_Plan_Attachment_File_Name"]));
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
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        private void dgrdSupAttach_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblSupFullfName");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = txthdnEOID.Text;
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();
                    //dsAttachments = objGetAttachSiteTest.GetAttachmentsInfo(intAttachmentId, eoiD, "Other_Supporting_Doc");
                    if (objclsAttachmentsBA.GetAttachmentsInfo(intAttachmentId, eoiD, "Other_Supporting_Doc", ref dsAttachments))
                    {
                        Response.Clear();
                        if (!(dsAttachments.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                            {
                                Response.ContentType = dsAttachments.Tables[0].Rows[0]["Attachment_Type"].ToString();
                            }
                        }
                        else
                        {
                        }
                        byte[] content = null;
                        content = (byte[])dsAttachments.Tables[0].Rows[0]["ST_OSD_Attachment_Content"];
                        string len = null;
                        len = Convert.ToString(content.Length);
                        byte[] bytArray = (byte[])dsAttachments.Tables[0].Rows[0]["ST_OSD_Attachment_Content"];
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
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Other_Supporting_Doc_Attachment_File_Name"]));
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
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        private void dgrdAttachment_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {

                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFullfname");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = txthdnEOID.Text;
                    int eoiD = Convert.ToInt32(EoiDString);
                    DataSet dsAttachments = new DataSet();
                    //dsAttachments = objGetAttachSiteTest.GetAttachmentsInfo(intAttachmentId, eoiD, "Final_Report");
                    if (objclsAttachmentsBA.GetAttachmentsInfo(intAttachmentId, eoiD, "Final_Report", ref dsAttachments))
                    {
                        Response.Clear();
                        if (!(dsAttachments.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(dsAttachments.Tables[0].Rows[0]["Attachment_Type"], DBNull.Value)))
                            {
                                Response.ContentType = dsAttachments.Tables[0].Rows[0]["Attachment_Type"].ToString();
                            }
                        }
                        else
                        {
                        }
                        byte[] content = null;
                        content = (byte[])dsAttachments.Tables[0].Rows[0]["ST_FR_Attachment_Content"];
                        string len = null;
                        len = Convert.ToString(content.Length);
                        byte[] bytArray = (byte[])dsAttachments.Tables[0].Rows[0]["ST_FR_Attachment_Content"];
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
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + Convert.ToString(dsAttachments.Tables[0].Rows[0]["Final_Report_Attachment_File_Name"]));
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
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

    }
}