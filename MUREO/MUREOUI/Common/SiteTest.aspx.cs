using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;
using System.Collections;
using MUREOPROP;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MUREOUI.Common
{
    public partial class SiteTest : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        objEOSiteTest objSiteTestProp = new objEOSiteTest();
        ObjSiteTest objSiteTestBA1 = new ObjSiteTest();
        SqlParameter[] paramOut = null;
        SiteTestBA objSiteTestBA = new SiteTestBA();
        clsAttachmentsBA objclsAttachmentsBA = new clsAttachmentsBA();
        SqlDateTime sqldatenull = default(SqlDateTime);

        string PlantType;
        string EventID;
        string EoID;
        //ClsEO objClsEO = new ClsEO();
        ArrayList files = new ArrayList();
        int filesUploaded = 0;
        string Script;
        DateTime StartDate;
        //BusinessObject.MUREO.BusinessObject.ObjSiteTest objSiteTest = new BusinessObject.MUREO.BusinessObject.ObjSiteTest();
        //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
        //BusinessObject.MUREO.BusinessObject.attachments objGetAttachSiteTest = new BusinessObject.MUREO.BusinessObject.attachments();
        //SqlDateTime sqldatenull;
        static string strDateTime;
        DataSet dsSiteTest = new DataSet();
        string responce;
        string ApprName;
        string Comment;
        string stMode;
        string stageStatus;
        //BusinessObject.MUREO.BusinessObject.SendConcurrence objConGrp = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
        //BusinessObject.MUREO.BusinessObject.clsEvent objEventDays = new BusinessObject.MUREO.BusinessObject.clsEvent();
        LinkButton Linkbut;
        string strUserRole;
        static string strDateTime1;
        int intStripthePath;
        int intAttachResult;
        byte[] bytContent;
        char cContentType;
        int fSize;
        string strAttachvalue;
        string strFileName;
        string sContentType;
        EOBA objEOBA = new EOBA();
        private static ArrayList arTestPlans = new ArrayList();
        private static ArrayList arFinal = new ArrayList();
        private static ArrayList arFinalReport = new ArrayList();




        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            ViewState["servername"] = ConfigurationSettings.AppSettings["ServerName"];
            if (Request.QueryString["PlantType"] != null && Request.QueryString["PlantType"].ToString() == "1")
            {
                txtStartDate.Attributes.Add("onblur", "javascript: isStartDate(this.value,'txtStartDate','txtPMDays');");
            }
            else if (Request.QueryString["PlantType"] != null && Request.QueryString["PlantType"].ToString() == "2")
            {
                txtStartDate.Attributes.Add("onblur", "javascript: isStartDate(this.value,'txtStartDate','txtDays');");
            }
            else
            {
                txtStartDate.Attributes.Add("onblur", "javascript: isTestDate(this.value,'txtStartDate');");
            }

            txtEndDate.Attributes.Add("onblur", "javascript: isTestDate(this.value,'txtEndDate');");
            strUserRole = objSecurity.UserRole();
            if (strUserRole.ToUpper() == "MUREO_Readers".ToUpper())
            {
                imgCancel.Enabled = false;
                imgSubmit.Enabled = false;
                Response.Redirect("../Common/Home.aspx");
            }
            else if (strUserRole.ToUpper() == "Readers".ToUpper())
            {
                imgCancel.Enabled = false;
                imgSubmit.Enabled = false;
                Response.Redirect("../Common/Home.aspx");
            }
            Page.SmartNavigation = true;
            txtPreRunDates.Attributes.Add("onblur", "javascript: isDate(this.value,'txtPreRunDates');");
            txtEarlRunDates.Attributes.Add("onblur", "javascript: isDate(this.value,'txtEarlRunDates');");
            txtLRDates.Attributes.Add("onblur", "javascript: isDate(this.value,'txtLRDates');");
            txtPPMPRDate.Attributes.Add("onblur", "javascript: isDate(this.value,'txtPPMPRDate');");
            txtPPMERDate.Attributes.Add("onblur", "javascript: isDate(this.value,'txtPPMERDate');");
            txtPPMLRDates.Attributes.Add("onblur", "javascript: isDate(this.value,'txtPPMLRDates');");
            lnkSendconGrp.Attributes.Add("onClick", "javascript:tt();");
            imgPOCAddressBook.Attributes.Add("onclick", "javascript: AddBooksingUser();");
            txtPMDays.Attributes.Add("onblur", "javascript: CountDecimals(this.value,'txtPMDays');");
            txtDays.Attributes.Add("onblur", "javascript: CountDecimals(this.value,'txtDays');");
            txtGallons.Attributes.Add("onblur", "javascript: CountDecimalsOnly(this.value,'txtGallons');");
            txtYellow.Attributes.Add("onblur", "javascript: CountDecimalsOnly(this.value,'txtYellow');");
            txtMagneta.Attributes.Add("onblur", "javascript: CountDecimalsOnly(this.value,'txtMagneta');");
            txtCyan.Attributes.Add("onblur", "javascript: CountDecimalsOnly(this.value,'txtCyan');");
            txtBlack.Attributes.Add("onblur", "javascript: CountDecimalsOnly(this.value,'txtBlack');");
            txtExtrusionHeads.Attributes.Add("onblur", "javascript: CountDecimalsOnly(this.value,'txtExtrusionHeads');");
            try
            {
                if ((Request.QueryString["EoID"] != null))
                {
                    DataSet dsmandatory = null;
                    if (objEOBA.GETEOMandatory(Convert.ToInt32(Request.QueryString["EoID"]), ref dsmandatory))
                    {
                        //dsmandatory = objClsEO.GETEOMandatory(Request.QueryString["EoID"]);
                        if ((dsmandatory != null))
                        {
                            if (!(dsmandatory.Tables.Count == 0))
                            {
                                if (!(dsmandatory.Tables[0].Rows.Count == 0))
                                {
                                    if ((dsmandatory.Tables[0].Rows[0]["Status"]).ToString().Trim() == "I")
                                    {
                                        //string script1 = null;
                                        //script1 = "<script>alert('EO/Site Test has been cancelled.');window.navigate('Home.aspx');</script> ";
                                        //Page.RegisterStartupScript("clientscript", script1);

                                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('EO/Site Test has been cancelled.');window.location='Home.aspx';", true);
                                        return;
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


            if (Request.QueryString["From"].ToUpper() == "EDIT")
            {
                EoID = Request.QueryString["EoID"];
            }
            else if (Request.QueryString["From"].ToUpper() == "EO")
            {
                EoID = Request.QueryString["EoID"];
            }

            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTestSC = new BusinessObject.MUREO.BusinessObject.SiteTest();

            dsSiteTest = new DataSet();
            //dsSiteTest = objGetSiteTestSC.FillSiteTest(EoID);

            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {

                if (dsSiteTest == null)
                {

                }
                else if (dsSiteTest.Tables.Count == 0)
                {

                }
                else
                {
                    if (dsSiteTest.Tables[3].Rows.Count == 0)
                    {
                        txthdnSiteTestID.Text = "0";
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"], System.DBNull.Value))
                        {
                            objSiteTestBA1.SiteTestID = 0;
                            txthdnSiteTestID.Text = "0";
                        }
                        else
                        {
                            objSiteTestBA1.SiteTestID = Convert.ToInt32(dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"]);
                            txthdnSiteTestID.Text = dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"].ToString();
                        }
                    }
                }
            }

            //Starting Header




            if (!Page.IsPostBack)
            {
                txtPhoneNum.Text = objSecurity.getUserTelephoneNumber(objSecurity.UserName);
                txtOfficeNum.Text = objSecurity.getUserTelephoneNumber(objSecurity.UserName);
                txtOriginator.Text = lblOriginator.Text;
                string role = objSecurity.UserRole();
                if (role.ToUpper() == "MUREO_Admin".ToUpper())
                {
                    imgAdminCloseOut.Visible = true;
                }
                else
                {
                    imgAdminCloseOut.Visible = false;
                }

                trApproval.Visible = false;
                dlstConcGrp.Visible = true;


                FillDropDownData(0, "Category_Name", "Category_ID", "--Select a Category--", ddlCategory);
                FillDropDownData(1, "Project_Name", "Project_ID", "--Select a Project--", ddlProject);
                FillDropDownData(2, "Plant_Name", "Plant_ID", "--Select a Plant--", drpPlant);
                lblOriginator.Text = objSecurity.UserName;

                if (Request.QueryString["From"] != null && Request.QueryString["From"].ToUpper() == "EO")
                {
                    txthdnEoID.Text = Request.QueryString["EoID"];
                    ViewState["EID"] = Request.QueryString["EoID"];
                    tblConverting.Visible = false;
                    tblPPM.Visible = false;
                    btnFYI.Visible = true;
                    if (!string.IsNullOrEmpty(txthdnEoID.Text))
                    {
                        //  lblEONum.Text = ViewState["EID")
                    }
                    else
                    {
                        if (objSiteTestBA.GetSitetestID(ref paramOut))
                        {
                            if (Convert.ToInt32(paramOut[0].Value) == 0)
                            {

                            }
                            int intSitestNo = Convert.ToInt32(paramOut[0].Value);
                            lblEONum.Text = (intSitestNo + 1).ToString();

                        }


                    }
                    if (txthdnEoID.Text == "0")
                    {
                        txthdnPlantType.Text = "0";
                        btnFYI.Visible = false;
                        lnkSendconGrp.Visible = false;
                        if (objSiteTestBA.GetSitetestID(ref paramOut))
                        {
                            if (Convert.ToInt32(paramOut[0].Value) == 0)
                            {

                            }
                            int intSitestNo = Convert.ToInt32(paramOut[0].Value);
                            lblEONum.Text = (intSitestNo + 1).ToString();
                        }


                        if ((Session["objEOSiteTest"] != null))
                        {
                            objEOSiteTest o = new objEOSiteTest();
                            o = (objEOSiteTest)Session["objEOSiteTest"];
                            if (!(o.CategoryID <= 0))
                            {
                                int i = 0;
                                string strStaus = null;
                                for (i = 0; i <= ddlCategory.Items.Count - 1; i++)
                                {
                                    if (!(ddlCategory.Items[i].Value == "--Select a Category--"))
                                    {
                                        if (ddlCategory.Items[i].Value == (o.ProjectID).ToString())
                                        {
                                            strStaus = "Yes";
                                        }
                                    }
                                }
                                if (strStaus == "Yes")
                                {
                                    //ddlCategory.Items[ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue((o.CategoryID).ToString())))].Selected = true;
                                    ddlCategory.Items[ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue((o.CategoryID).ToString()))].Selected = true;
                                }
                                else
                                {
                                    ddlCategory.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                ddlCategory.SelectedIndex = 0;
                            }

                            if (!(o.ProjectID <= 0))
                            {
                                int i = 0;
                                string strStaus = null;
                                for (i = 0; i <= ddlProject.Items.Count - 1; i++)
                                {
                                    if (!(ddlProject.Items[i].Value == "--Select a Project--"))
                                    {
                                        if (ddlProject.Items[i].Value == (o.ProjectID).ToString())
                                        {
                                            strStaus = "Yes";
                                        }
                                    }
                                }
                                if (strStaus == "Yes")
                                {
                                    //ddlProject.Items(ddlProject.Items.IndexOf(ddlProject.Items.FindByValue(o.ProjectID))).Selected = true;
                                    ddlProject.Items[ddlProject.Items.IndexOf(ddlProject.Items.FindByValue((o.ProjectID).ToString()))].Selected = true;
                                }
                                else
                                {
                                    ddlProject.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                ddlProject.SelectedIndex = 0;
                            }
                            if (!(o.PlantID <= 0))
                            {
                                int i = 0;
                                string strStaus = null;
                                for (i = 0; i <= drpPlant.Items.Count - 1; i++)
                                {
                                    if (!(drpPlant.Items[i].Value == "--Select a Plant--"))
                                    {
                                        if (drpPlant.Items[i].Value == (o.PlantID).ToString())
                                        {
                                            strStaus = "Yes";
                                        }
                                    }
                                }
                                if (strStaus == "Yes")
                                {
                                    //drpPlant.Items(drpPlant.Items.IndexOf(drpPlant.Items.FindByValue(o.PlantID))).Selected = true;
                                    drpPlant.Items[drpPlant.Items.IndexOf(drpPlant.Items.FindByValue((o.PlantID).ToString()))].Selected = true;
                                }
                                else
                                {
                                    drpPlant.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                drpPlant.SelectedIndex = 0;
                            }

                            DataSet dsBrand = null;
                            dsBrand = new DataSet();
                            // dsBrand = ClsEO.FillListBoxWithBrands("GET_MUR_BRAND_Segment_By_Category", ddlCategory.SelectedValue);

                            if (objEOBA.FillListBoxWithBrands(ddlCategory.SelectedItem.Value, ref dsBrand))
                            {
                                if ((dsBrand != null))
                                {
                                    if (!(dsBrand.Tables.Count == 0))
                                    {
                                        if (!(dsBrand.Tables[0].Rows.Count == 0))
                                        {
                                            lbEOBrandsDB.DataSource = dsBrand.Tables[0].DefaultView;
                                            lbEOBrandsDB.DataTextField = "Brand_Segment_Name";
                                            lbEOBrandsDB.DataValueField = "Brand_Segment_ID";
                                            lbEOBrandsDB.DataBind();
                                        }
                                    }
                                }
                            }

                            if ((o.Brands != null))
                            {
                                string strBrandsIDs = null;
                                strBrandsIDs = o.Brands;
                                string[] strbrandID = strBrandsIDs.Split(',');
                                int intBrandNum = 0;
                                for (intBrandNum = 0; intBrandNum <= strbrandID.Length - 1; intBrandNum++)
                                {
                                    int i = 0;
                                    string strsta = null;
                                    for (i = 0; i <= lbEOBrandsDB.Items.Count - 1; i++)
                                    {
                                        if (lbEOBrandsDB.Items[i].Value == strbrandID[intBrandNum])
                                        {
                                            strsta = "Yes";
                                        }
                                    }
                                    if (strsta == "Yes")
                                    {
                                        //lbEOBrandsDB.Items(lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue(strbrandID[intBrandNum]))).Selected = true;
                                        lbEOBrandsDB.Items[lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue((strbrandID[intBrandNum]).ToString()))].Selected = true;
                                    }
                                    else
                                    {
                                    }
                                }
                            }

                            //New Code
                            lblEoSelectedBrandDB.Text = "";
                            int intBrand = 0;
                            for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
                            {
                                if (lbEOBrandsDB.Items[intBrand].Selected == true)
                                {
                                    if (string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
                                    {
                                        lblEoSelectedBrandDB.Text = lbEOBrandsDB.Items[intBrand].Text;
                                    }
                                    else
                                    {
                                        lblEoSelectedBrandDB.Text = lblEoSelectedBrandDB.Text + "," + lbEOBrandsDB.Items[intBrand].Text;
                                    }
                                }
                            }
                            lblBrandIDList.Text = "";
                            for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
                            {
                                if (lbEOBrandsDB.Items[intBrand].Selected == true)
                                {
                                    if (string.IsNullOrEmpty(lblBrandIDList.Text))
                                    {
                                        lblBrandIDList.Text = lbEOBrandsDB.Items[intBrand].Value;
                                    }
                                    else
                                    {
                                        lblBrandIDList.Text = lblBrandIDList.Text + "," + lbEOBrandsDB.Items[intBrand].Value;
                                    }
                                }
                            }

                            try
                            {
                                //effected machines
                                if ((o.EffectedMachineInfo != null))
                                {
                                    txtAffected.Text = o.EffectedMachineInfo;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            //Ending 
                            if ((o.EventIDs != null))
                            {
                                FillListEvents();
                                string streventIDs = null;
                                streventIDs = o.EventIDs;
                                string[] strEventID = streventIDs.Split(',');
                                int intEvenNum = 0;
                                for (intEvenNum = 0; intEvenNum <= strEventID.Length - 1; intEvenNum++)
                                {
                                    int i = 0;
                                    string strsta = null;
                                    for (i = 0; i <= lbEOEventsDB.Items.Count - 1; i++)
                                    {
                                        if (lbEOEventsDB.Items[i].Value == strEventID[intEvenNum])
                                        {
                                            strsta = "Yes";
                                        }
                                    }
                                    if (strsta == "Yes")
                                    {
                                        //lbEOEventsDB.Items(lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue(strEventID[intEvenNum]))).Selected = true;
                                        lbEOEventsDB.Items[lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue((strEventID[intEvenNum]).ToString()))].Selected = true;
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            if ((o.OfficeNumber != null))
                            {
                                txtOfficeNum.Text = o.OfficeNumber;
                            }
                            else
                            {
                                txtOfficeNum.Text = string.Empty;
                            }

                            if ((o.CoOrginator != null))
                            {
                                txtCoOriginator.Text = o.CoOrginator;
                                hdntxtPrjLead.Value = o.CoOrginator;
                            }
                            else
                            {
                                txtCoOriginator.Text = string.Empty;
                                hdntxtPrjLead.Value = string.Empty;
                            }

                            if ((o.PhoneNumber != null))
                            {
                                txtPhoneNum.Text = o.PhoneNumber;
                            }
                            else
                            {
                                txtPhoneNum.Text = string.Empty;
                            }

                            if ((o.Title != null))
                            {
                                txtTitle.Text = o.Title;
                            }
                            else
                            {
                                txtTitle.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        txthdnPlantType.Text = "0";
                        lnkSendconGrp.Visible = true;
                        //lnkRevisionHistory.Visible = True
                        btnFYI.Visible = true;
                        Get_EO_Mandatory_Edit(Convert.ToInt32(Request.QueryString["EoID"]));
                    }
                    //Added by Abdul


                }
                else if (Request.QueryString["From"].ToUpper() == "EDIT")
                {
                    EoID = Request.QueryString["EoID"];
                    ViewState["EID"] = Request.QueryString["EoID"];
                    //To Get EventID

                    txthdnEoID.Text = EoID;
                    dsSiteTest = new DataSet();
                    //Fill Preferred Converting Line DropDown
                    //dsSiteTest = objGetSiteTest.FillSiteTest(EoID);
                    btnFYI.Visible = true;
                    if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
                    {
                        if (dsSiteTest == null)
                        {
                        }
                        else if (dsSiteTest.Tables.Count == 0)
                        {
                        }
                        else
                        {
                            if (dsSiteTest.Tables[1].Rows.Count == 0)
                            {
                            }
                            else
                            {
                                if (object.ReferenceEquals(dsSiteTest.Tables[1].Rows[0]["Event_ID"], System.DBNull.Value))
                                {
                                    EventID = "";
                                }
                                else
                                {
                                    EventID = dsSiteTest.Tables[1].Rows[0]["Event_ID"].ToString();
                                    ViewState["EventID"] = EventID;
                                }
                            }
                            if (dsSiteTest.Tables[3].Rows.Count == 0)
                            {
                                txthdnPlantType.Text = "0";
                            }
                            else
                            {
                                stMode = dsSiteTest.Tables[3].Rows[0]["ST_Mode"].ToString();
                                if (stMode == "P")
                                {
                                    txthdnPlantType.Text = "1";
                                }
                                else if (stMode == "C")
                                {
                                    txthdnPlantType.Text = "2";
                                }
                                else
                                {
                                    txthdnPlantType.Text = "0";
                                }
                            }
                        }
                    }



                    //Starting Header

                    if (Request.QueryString["Page"] == "MigrSt")
                    {
                        //string script2 = null;
                        //script2 = "<script>alert('Event(s) information is migrated successfully to Site Test.');</script>";
                        //Page.RegisterStartupScript("clientscript2", script2);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Event(s) information is migrated successfully to Site Test.');", true); 


                        PlantType = Request.QueryString["PlantType"];
                        txthdnPlantType.Text = PlantType;
                        txtStartDate.Text = Request.QueryString["StartDate"];

                    }
                    //End Of Getting EventID

                    if (txthdnPlantType.Text == "1")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = true;
                        FillPlantEquipment();
                        UpdateValuesForPlant();
                        UpdateStraightSiteTest();
                    }
                    else if (txthdnPlantType.Text == "2")
                    {
                        tblPPM.Visible = false;
                        tblConverting.Visible = true;
                        FillConvertEquipment();
                        UpdateValuesForConvertLine();
                        UpdateStraightSiteTest();
                    }
                    else if (txthdnPlantType.Text == "0")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = false;
                        UpdateStraightSiteTest();
                    }
                    FillEditSiteTestHeader();
                    trSenGrp.Visible = true;
                    trRevHis.Visible = true;
                    lnkSendconGrp.Visible = true;
                    //lnkRevisionHistory.Visible = True
                    btnFYI.Visible = true;
                    if (Request.QueryString["Page"] == "MigrSt")
                    {
                        setTestEndDate(EventID);
                    }
                    EnableGeneralSection(false);
                    try
                    {
                        if (Request.QueryString["Page"] == "Approval")
                        {
                            if (strUserRole.ToUpper() == "MUREO_Admin".ToUpper() || objSecurity.UserName.ToUpper() == lblOriginator.Text.ToUpper() || objSecurity.UserName == hdntxtPrjLead.Value.ToUpper())
                            {
                                imgSubmit.Visible = true;
                                btnFYI.Visible = true;
                            }
                            else
                            {
                                imgSubmit.Visible = false;
                                btnFYI.Visible = false;
                            }
                        }
                        else
                        {
                            imgSubmit.Visible = true;
                            btnFYI.Visible = true;

                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
                else if (Request.QueryString["From"] == "NewEvent")
                {
                    PlantType = Request.QueryString["PlantType"];
                    EventID = Request.QueryString["EventID"];
                    txthdnPlantType.Text = PlantType;
                    txtStartDate.Text = Request.QueryString["StartDate"];
                    if (txthdnPlantType.Text == "1")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = true;
                        FillPlantEquipment();
                    }
                    else if (txthdnPlantType.Text == "2")
                    {
                        tblPPM.Visible = false;
                        tblConverting.Visible = true;
                        FillConvertEquipment();
                    }
                    else if (txthdnPlantType.Text == "0")
                    {
                        tblConverting.Visible = false;
                        tblPPM.Visible = false;
                    }
                    FillSiteTestHeader(EventID);
                    btnFYI.Visible = false;
                    trSenGrp.Visible = false;
                    trRevHis.Visible = false;
                    lnkSendconGrp.Visible = false;
                    //lnkRevisionHistory.Visible = False
                    dlstConcGrp.Visible = false;
                    dgrdRevHis.Visible = false;
                    setTestEndDate(EventID);
                    //Added by Abdul
                    EnableGeneralSection(false);
                }
                txthdnPlantID.Text = drpPlant.SelectedItem.Value;
                ViewState["EventID"] = EventID;
            }

            if (!(Page.IsPostBack))
            {
                if (dlstConcGrp.Items.Count > 0)
                {
                    showcon();
                }
            }
        }

        public void setTestEndDate(string EventID)
        {
            DataSet dsEventdays = null;
            double totDays = 0;
            DateTime startDate = default(DateTime);

            startDate = Convert.ToDateTime(txtStartDate.Text).Date;
            dsEventdays = new DataSet();
            clsEvent objclsEvent = new clsEvent();
            //dsEventdays = clsEvent.FetchEventDetails(EventID);
            if (objclsEvent.FetchEventDetails(Convert.ToInt32(EventID), ref dsEventdays))
            {
                if (dsEventdays == null)
                {

                }
                else if (dsEventdays.Tables.Count == 0)
                {
                    return;
                }
                else
                {
                    if (dsEventdays.Tables[3].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (txthdnPlantType.Text == "1")
                        {
                            if (object.ReferenceEquals(dsEventdays.Tables[3].Rows[0]["Total_Lost_Days"], System.DBNull.Value))
                            {
                                txtPMDays.Text = "0";

                            }
                            else
                            {
                                txtPMDays.Text = dsEventdays.Tables[3].Rows[0]["Total_Lost_Days"].ToString();
                            }

                            txtEndDate.Text = startDate.AddDays(Convert.ToDouble(txtPMDays.Text)).Date.ToShortDateString();
                        }
                    }


                    if (dsEventdays.Tables[2].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (txthdnPlantType.Text == "2")
                        {
                            if (object.ReferenceEquals(dsEventdays.Tables[2].Rows[0]["Total_Lost_Days"], System.DBNull.Value))
                            {
                                txtDays.Text = "0";

                            }
                            else
                            {
                                txtDays.Text = dsEventdays.Tables[2].Rows[0]["Total_Lost_Days"].ToString();
                            }

                            txtEndDate.Text = startDate.AddDays(Convert.ToDouble(txtDays.Text)).Date.ToShortDateString();
                        }
                    }

                    if (dsEventdays.Tables[1].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (txthdnPlantType.Text == "0")
                        {
                            if (object.ReferenceEquals(dsEventdays.Tables[1].Rows[0]["Total_Lost_Days"], System.DBNull.Value))
                            {
                                totDays = 0;

                            }
                            else
                            {
                                totDays = Convert.ToDouble(dsEventdays.Tables[1].Rows[0]["Total_Lost_Days"]);
                            }
                            txtEndDate.Text = startDate.AddDays(totDays).Date.ToShortDateString();
                        }
                    }
                }

            }
        }

        public void FillDropDownData(int tabValue, string colNameText, string colNameID, string optionalValue, DropDownList drpName)
        {
            DataSet objDS = null;
            if (objEOBA.FillDropDownSeedData(ref objDS))
            {
                if (objDS.Tables.Count > 0)
                {
                    drpName.DataSource = objDS.Tables[tabValue].DefaultView;
                    drpName.DataTextField = colNameText;
                    drpName.DataValueField = colNameID;
                    drpName.DataBind();
                    drpName.Items.Insert(0, optionalValue);
                }
            }
        }

        public void EnableGeneralSection(Boolean boolValue)
        {
            ddlCategory.Enabled = boolValue;
            lbEOBrandsDB.Enabled = boolValue;
            ddlProject.Enabled = boolValue;
            lbEOEventsDB.Enabled = boolValue;
            drpPlant.Enabled = boolValue;
        }

        public void Get_EO_Mandatory_Edit(int EoID)
        {
            object functionReturnValue = null;
            DataSet ds = null;
            DataSet dsBrand = null;
            //ds = objClsEO.GETEOMandatory(EoID);
            if (objEOBA.GETEOMandatory(EoID, ref ds))
            {
                if ((ds != null))
                {
                    if (!(ds.Tables.Count == 0))
                    {

                        if (!(ds.Tables[0].Rows.Count == 0))
                        {
                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value)))
                            {
                                txtTitle.Text = ds.Tables[0].Rows[0]["EO_Title"].ToString();
                            }
                            else
                            {
                                txtTitle.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["EO_Number"], System.DBNull.Value)))
                            {
                                lblEONum.Text = ds.Tables[0].Rows[0]["EO_Number"].ToString();
                            }
                            else
                            {
                                lblEONum.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Stage_Status"], System.DBNull.Value)))
                            {
                                ViewState["stageStatus"] = ds.Tables[0].Rows[0]["Stage_Status"];
                            }
                            else
                            {
                                ViewState["stageStatus"] = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Category_ID"], System.DBNull.Value)))
                            {
                                int intPrjList = 0;
                                string strProjStatus = null;
                                for (intPrjList = 1; intPrjList <= ddlCategory.Items.Count - 1; intPrjList++)
                                {
                                    if (ds.Tables[0].Rows[0]["Category_ID"] == ddlCategory.Items[intPrjList].Value)
                                    {
                                        strProjStatus = "Yes";
                                    }
                                }
                                if (strProjStatus == "Yes")
                                {
                                    //ddlCategory.Items(ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(ds.Tables[0].Rows[0]["Category_ID"]))).Selected = true;
                                    ddlCategory.Items[ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(ds.Tables[0].Rows[0]["Category_ID"].ToString()))].Selected = true;
                                }
                                else
                                {
                                    ddlCategory.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                ddlCategory.SelectedIndex = 0;
                            }
                            //TO fill Brands with respective to above category selection

                            string intDrpValue = null;
                            intDrpValue = ddlCategory.SelectedIndex.ToString();
                            if (intDrpValue == "0")
                            {
                                lbEOBrandsDB.Items.Clear();
                            }
                            else
                            {
                                dsBrand = new DataSet();
                                //dsBrand = ClsEO.FillListBoxWithBrands("GET_MUR_BRAND_Segment_By_Category", ddlCategory.SelectedValue);
                                if (objEOBA.FillListBoxWithBrands(ddlCategory.SelectedValue, ref dsBrand))
                                {
                                    if (dsBrand.Tables.Count == 0)
                                    {
                                        return;
                                    }
                                    lbEOBrandsDB.DataSource = dsBrand.Tables[0].DefaultView;
                                    lbEOBrandsDB.DataTextField = "Brand_Segment_Name";
                                    lbEOBrandsDB.DataValueField = "Brand_Segment_ID";
                                    lbEOBrandsDB.DataBind();
                                }
                            }
                            lblEoSelectedBrandDB.Text = string.Empty;

                            //Filling/Selecting Brand List box
                            if ((ds != null))
                            {
                                if (!(ds.Tables.Count == 0))
                                {
                                    if (!(ds.Tables[2].Rows.Count == 0))
                                    {
                                        int intRowCount = 0;
                                        for (intRowCount = 0; intRowCount <= ds.Tables[2].Rows.Count - 1; intRowCount++)
                                        {
                                            if ((!object.ReferenceEquals(ds.Tables[2].Rows[intRowCount][0], System.DBNull.Value)))
                                            {
                                                int intPrjList = 0;
                                                string strProjStatus = null;
                                                for (intPrjList = 0; intPrjList <= lbEOBrandsDB.Items.Count - 1; intPrjList++)
                                                {
                                                    if (ds.Tables[2].Rows[intRowCount][0] == lbEOBrandsDB.Items[intPrjList].Value)
                                                    {
                                                        strProjStatus = "Yes";
                                                    }
                                                }
                                                if (strProjStatus == "Yes")
                                                {
                                                    //lbEOBrandsDB.Items(lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue(ds.Tables[2].Rows[intRowCount][0]))).Selected = true;
                                                    lbEOBrandsDB.Items[lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue(ds.Tables[2].Rows[intRowCount][0].ToString()))].Selected = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Plant_Name"], System.DBNull.Value)))
                            {
                                int intPrjList = 0;
                                string strProjStatus = null;
                                for (intPrjList = 1; intPrjList <= drpPlant.Items.Count - 1; intPrjList++)
                                {
                                    if (ds.Tables[0].Rows[0]["Plant_Name"] == drpPlant.Items[intPrjList].Text)
                                    {
                                        strProjStatus = "Yes";
                                    }
                                }
                                if (strProjStatus == "Yes")
                                {
                                    //drpPlant.Items(drpPlant.Items.IndexOf(drpPlant.Items.FindByText(ds.Tables[0].Rows[0]["Plant_Name"]))).Selected = true;
                                    drpPlant.Items[drpPlant.Items.IndexOf(drpPlant.Items.FindByValue(ds.Tables[0].Rows[0]["Plant_Name"].ToString()))].Selected = true;
                                }
                                else
                                {
                                    drpPlant.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                drpPlant.SelectedIndex = 0;
                            }

                            //BrandSegmentSelect()

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Project_ID"], System.DBNull.Value)))
                            {
                                int intPrjList = 0;
                                string strProjStatus = null;
                                for (intPrjList = 1; intPrjList <= ddlProject.Items.Count - 1; intPrjList++)
                                {
                                    if (ds.Tables[0].Rows[0]["Project_ID"] == ddlProject.Items[intPrjList].Value)
                                    {
                                        strProjStatus = "Yes";
                                    }
                                }
                                if (strProjStatus == "Yes")
                                {
                                    //ddlProject.Items(ddlProject.Items.IndexOf(ddlProject.Items.FindByValue(ds.Tables[0].Rows[0]["Project_ID"]))).Selected = true;
                                    ddlProject.Items[ddlProject.Items.IndexOf(ddlProject.Items.FindByValue(ds.Tables[0].Rows[0]["Project_ID"].ToString()))].Selected = true;
                                }
                                else
                                {
                                    ddlProject.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                ddlProject.SelectedIndex = 0;
                            }

                            lbEOEventsDB.Items.Clear();
                            FillListEvents();

                            if ((ds != null))
                            {
                                if (!(ds.Tables.Count == 0))
                                {
                                    if (!(ds.Tables[1].Rows.Count == 0))
                                    {
                                        int intRowCount = 0;
                                        for (intRowCount = 0; intRowCount <= ds.Tables[1].Rows.Count - 1; intRowCount++)
                                        {
                                            if ((!object.ReferenceEquals(ds.Tables[1].Rows[intRowCount][0], System.DBNull.Value)))
                                            {
                                                int i = 0;
                                                string strsta = null;
                                                for (i = 0; i <= lbEOEventsDB.Items.Count - 1; i++)
                                                {
                                                    if (lbEOEventsDB.Items[i].Value == ds.Tables[1].Rows[intRowCount][0])
                                                    {
                                                        strsta = "Yes";
                                                    }
                                                }
                                                if (strsta == "Yes")
                                                {
                                                    //lbEOEventsDB.Items(lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue(ds.Tables[1].Rows[intRowCount][0]))).Selected = true;
                                                    lbEOEventsDB.Items[lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue(ds.Tables[1].Rows[intRowCount][0].ToString()))].Selected = true;

                                                }
                                            }
                                        }
                                    }
                                }
                            }


                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Originator"], System.DBNull.Value)))
                            {
                                lblCoordinator.Text = ds.Tables[0].Rows[0]["Originator"].ToString();
                            }
                            else
                            {
                                lblCoordinator.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Office_Num"], System.DBNull.Value)))
                            {
                                txtOfficeNum.Text = ds.Tables[0].Rows[0]["Office_Num"].ToString();
                            }
                            else
                            {
                                txtOfficeNum.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["Phone_Num"], System.DBNull.Value)))
                            {
                                txtPhoneNum.Text = ds.Tables[0].Rows[0]["Phone_Num"].ToString();
                            }
                            else
                            {
                                txtPhoneNum.Text = string.Empty;
                            }

                            if ((!object.ReferenceEquals(ds.Tables[0].Rows[0]["CoOriginator"], System.DBNull.Value)))
                            {
                                txtCoOriginator.Text = ds.Tables[0].Rows[0]["CoOriginator"].ToString();
                                hdntxtPrjLead.Value = ds.Tables[0].Rows[0]["CoOriginator"].ToString();
                            }
                            else
                            {
                                txtCoOriginator.Text = string.Empty;
                                hdntxtPrjLead.Value = string.Empty;
                            }
                        }
                    }
                }
            }

        }

        public void FillPlantEquipment()
        {
            DataSet dsEquipData = new DataSet();

            //Fill Preferred Converting Line DropDown
            // dsEquipData = objFinalEquip.FillEquipment(1);

            if (objSiteTestBA.FillEquipment(1, ref dsEquipData))
            {
                if ((dsEquipData != null))
                {
                    if (!(dsEquipData.Tables.Count == 0))
                    {

                        drpDrying.DataSource = dsEquipData.Tables[0].DefaultView;
                        drpDrying.DataTextField = "Equipment_Name";
                        drpDrying.DataValueField = "Equipment_ID";
                        drpDrying.DataBind();
                        drpDrying.Items.Insert(0, "--Please Select a value--");
                    }
                }

            }

            if (objSiteTestBA.FillEquipment(2, ref dsEquipData))
            {
                if ((dsEquipData != null))
                {
                    if (!(dsEquipData.Tables.Count == 0))
                    {
                        drpFormat.DataSource = dsEquipData.Tables[0].DefaultView;
                        drpFormat.DataTextField = "Equipment_Name";
                        drpFormat.DataValueField = "Equipment_ID";
                        drpFormat.DataBind();
                        drpFormat.Items.Insert(0, "--Please Select a value--");
                    }
                }
            }


            if (objSiteTestBA.FillEquipment(3, ref dsEquipData))
            {
                if ((dsEquipData != null))
                {
                    if (!(dsEquipData.Tables.Count == 0))
                    {  //Fill E/L SetUp
                        drpHeadbox.DataSource = dsEquipData.Tables[0].DefaultView;
                        drpHeadbox.DataTextField = "Equipment_Name";
                        drpHeadbox.DataValueField = "Equipment_ID";
                        drpHeadbox.DataBind();
                        drpHeadbox.Items.Insert(0, "--Please Select a value--");
                    }
                }
            }

        }

        public void FillConvertEquipment()
        {
            DataSet dsEquipData = new DataSet();
            if (objSiteTestBA.FillEquipment(4, ref dsEquipData))
            {
                if ((dsEquipData != null))
                {
                    if (!(dsEquipData.Tables.Count == 0))
                    {
                        ddlPrefConline.DataSource = dsEquipData.Tables[0].DefaultView;
                        ddlPrefConline.DataTextField = "Equipment_Name";
                        ddlPrefConline.DataValueField = "Equipment_ID";
                        ddlPrefConline.DataBind();
                        ddlPrefConline.Items.Insert(0, "--Please Select a value--");
                    }
                }
            }

            if (objSiteTestBA.FillEquipment(5, ref dsEquipData))
            {
                if ((dsEquipData != null))
                {
                    if (!(dsEquipData.Tables.Count == 0))
                    {
                        //Fill Alternate Converting Line DropDown
                        ddlaltConvLine.DataSource = dsEquipData.Tables[0].DefaultView;
                        ddlaltConvLine.DataTextField = "Equipment_Name";
                        ddlaltConvLine.DataValueField = "Equipment_ID";
                        ddlaltConvLine.DataBind();
                        ddlaltConvLine.Items.Insert(0, "--Please Select a value--");
                    }
                }
            }

            if (objSiteTestBA.FillEquipment(6, ref dsEquipData))
            {
                if ((dsEquipData != null))
                {
                    if (!(dsEquipData.Tables.Count == 0))
                    {
                        //Fill E/L SetUp
                        ddlElSetup.DataSource = dsEquipData.Tables[0].DefaultView;
                        ddlElSetup.DataTextField = "Equipment_Name";
                        ddlElSetup.DataValueField = "Equipment_ID";
                        ddlElSetup.DataBind();
                        ddlElSetup.Items.Insert(0, "--Please Select a value--");
                    }
                }
            }
        }

        public void FillSiteTestHeader(string EventID)
        {
            DataSet ds11 = null;
            DataSet dsBrand = null;
            int i = 0;

            //ds11 = objClsEO.GETEOSeedDataByEventIDs(EventID);
            if (objEOBA.GETEOSeedDataByEventIDs(EventID, ref ds11))
            {
                if (ds11.Tables[0].Rows.Count != 0)
                {
                    for (i = 0; i <= ds11.Tables[0].Rows.Count - 1; i++)
                    {
                        //ddlCategory.Items(ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(ds11.Tables[0].Rows[i][8]))).Selected = true;
                        ddlCategory.Items[ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue((ds11.Tables[0].Rows[i][8]).ToString()))].Selected = true;
                    }

                    dsBrand = new DataSet();
                    //dsBrand = ClsEO.FillListBoxWithBrands("GET_MUR_BRAND_Segment_By_Category", ddlCategory.SelectedValue);

                    if (objEOBA.FillListBoxWithBrands(ddlCategory.SelectedValue, ref dsBrand))
                    {
                        if ((dsBrand != null))
                        {
                            if (!(dsBrand.Tables.Count == 0))
                            {
                                if (!(dsBrand.Tables[0].Rows.Count == 0))
                                {

                                    //For Brand Segment
                                    lbEOBrandsDB.DataSource = dsBrand.Tables[0].DefaultView;
                                    lbEOBrandsDB.DataTextField = "Brand_Segment_Name";
                                    lbEOBrandsDB.DataValueField = "Brand_Segment_ID";
                                    lbEOBrandsDB.DataBind();
                                }
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    else
                        return;


                    for (i = 0; i <= ds11.Tables[0].Rows.Count - 1; i++)
                    {
                        //lbEOBrandsDB.Items(lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue(ds11.Tables[0].Rows[i][6]))).Selected = true;
                        lbEOBrandsDB.Items[lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue((ds11.Tables[0].Rows[i][6]).ToString()))].Selected = true;
                    }

                    lblEoSelectedBrandDB.Text = "";
                    lblBrandIDList.Text = "";
                    int intBrand = 0;
                    for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
                    {
                        if (lbEOBrandsDB.Items[intBrand].Selected == true)
                        {
                            if (string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
                            {
                                lblEoSelectedBrandDB.Text = lbEOBrandsDB.Items[intBrand].Text;
                            }
                            else
                            {
                                lblEoSelectedBrandDB.Text = lblEoSelectedBrandDB.Text + "," + lbEOBrandsDB.Items[intBrand].Text;
                            }
                        }
                    }

                    for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
                    {
                        if (lbEOBrandsDB.Items[intBrand].Selected == true)
                        {
                            if (string.IsNullOrEmpty(lblBrandIDList.Text))
                            {
                                lblBrandIDList.Text = lbEOBrandsDB.Items[intBrand].Value;
                            }
                            else
                            {
                                lblBrandIDList.Text = lblBrandIDList.Text + "," + lbEOBrandsDB.Items[intBrand].Value;
                            }
                        }
                    }

                    DataSet dsProj = new DataSet();
                    int intCatID = 0;
                    if (ddlCategory.SelectedItem.Text == "--Select a Category--")
                    {
                        intCatID = 0;
                    }
                    else
                    {
                        intCatID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                    }
                    //For Category
                    //dsProj = objClsEO.GET_MUR_Projects_By_Category_Brand_Segment(intCatID, lblBrandIDList.Text);

                    if (objEOBA.GET_MUR_Projects_By_Category_Brand_Segment(intCatID, lblBrandIDList.Text, ref dsProj))
                    {
                        ddlProject.DataSource = dsProj;
                        ddlProject.DataTextField = "Project_Name";
                        ddlProject.DataValueField = "Project_ID";
                        ddlProject.DataBind();
                        ddlProject.Items.Insert(0, "--Select a Project--");
                    }



                    for (i = 0; i <= ds11.Tables[0].Rows.Count - 1; i++)
                    {
                        Int32 j = Convert.ToInt32(ds11.Tables[0].Rows[i]["Project_ID"]);
                        ddlProject.SelectedValue = ds11.Tables[0].Rows[i]["Project_ID"].ToString();
                    }

                    //For events
                    FillListEvents();
                    for (i = 0; i <= ds11.Tables[0].Rows.Count - 1; i++)
                    {
                        //lbEOEventsDB.Items(lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue(ds11.Tables[0].Rows[i][0]))).Selected = true;
                        lbEOBrandsDB.Items[lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue((ds11.Tables[0].Rows[i][0]).ToString()))].Selected = true;
                    }
                    //For Plant
                    for (i = 0; i <= ds11.Tables[0].Rows.Count - 1; i++)
                    {
                        //drpPlant.Items(drpPlant.Items.IndexOf(drpPlant.Items.FindByValue(ds11.Tables[0].Rows[i][4]))).Selected = true;
                        drpPlant.Items[drpPlant.Items.IndexOf(drpPlant.Items.FindByValue((ds11.Tables[0].Rows[i][4]).ToString()))].Selected = true;
                    }
                }
            }

            // Begin AffectedLineMachine
            //BusinessObject.MUREO.BusinessObject.SiteTest objAddsiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            DataSet dsAm = new DataSet();
            //dsAm = objAddsiteTest.GetAffectedMachine(EventID);

            if (objSiteTestBA.GetAffectedMachine(Convert.ToInt32(EventID), ref dsAm))
            {
                if ((dsAm != null))
                {
                    if (!(dsAm.Tables.Count == 0))
                    {
                        if (dsAm.Tables[1].Rows.Count != 0)
                        {
                            if (object.ReferenceEquals(dsAm.Tables[1].Rows[0]["Combining_Line_Machine_Name"], System.DBNull.Value))
                            {
                                txtAffected.Text = string.Empty;
                            }
                            else
                            {
                                txtAffected.Text = dsAm.Tables[1].Rows[0]["Combining_Line_Machine_Name"].ToString();
                            }
                        }
                        if (dsAm.Tables[2].Rows.Count != 0)
                        {
                            if (object.ReferenceEquals(dsAm.Tables[2].Rows[0]["Converting_Line_Machine_Name"], System.DBNull.Value))
                            {
                                txtAffected.Text = txtAffected.Text + string.Empty;
                            }
                            else
                            {
                                if (txtAffected.Text == string.Empty)
                                {
                                    txtAffected.Text = dsAm.Tables[2].Rows[0]["Converting_Line_Machine_Name"].ToString();
                                }
                                else
                                {
                                    txtAffected.Text = txtAffected.Text + "," + dsAm.Tables[2].Rows[0]["Converting_Line_Machine_Name"];
                                }
                            }

                        }
                        if (dsAm.Tables[1].Rows.Count != 0)
                        {
                            if (object.ReferenceEquals(dsAm.Tables[3].Rows[0]["Paper_Machine_Name"], System.DBNull.Value))
                            {
                                txtAffected.Text = txtAffected.Text + string.Empty;
                            }
                            else
                            {
                                if (txtAffected.Text == string.Empty)
                                {
                                    txtAffected.Text = dsAm.Tables[3].Rows[0]["Paper_Machine_Name"].ToString();
                                }
                                else
                                {
                                    txtAffected.Text = txtAffected.Text + "," + dsAm.Tables[3].Rows[0]["Paper_Machine_Name"];
                                }

                            }
                        }
                    }
                }
            }
        }

        public void FillListEvents()
        {
            DataSet dsEvent = new DataSet();
            dsEvent = new DataSet();

            if (Request.QueryString["From"] != null && Request.QueryString["From"].ToUpper() == "EDIT")
            {
                int EID = Convert.ToInt32(txthdnEoID.Text);
                int intProjectID = 0;
                if (ddlProject.SelectedItem.Text == "--Select a Project--")
                {
                    intProjectID = -1;
                }
                else
                {
                    intProjectID = Convert.ToInt32(ddlProject.SelectedValue);
                }

                if (objEOBA.FillListBoxWithEventsByEoID(intProjectID, EID, ref dsEvent))
                { }

            }
            else
            {
                int EID = Convert.ToInt32(txthdnEoID.Text);
                int intProjectID = 0;
                if (ddlProject.SelectedItem.Text == "--Select a Project--")
                {
                    intProjectID = -1;
                }
                else
                {
                    intProjectID = Convert.ToInt32(ddlProject.SelectedValue);
                }

                if (objEOBA.FillListBoxWithEventsByEoID(intProjectID, EID, ref dsEvent))
                { }
            }

            if (dsEvent != null)
            {
                if (dsEvent.Tables.Count != 0)
                {
                    if (dsEvent.Tables[0].Rows.Count != 0)
                    {
                        lbEOEventsDB.DataSource = dsEvent.Tables[0].DefaultView;
                        lbEOEventsDB.DataTextField = "Event_Name";
                        lbEOEventsDB.DataValueField = "Event_ID";
                        lbEOEventsDB.DataBind();
                    }
                }
            }
        }

        public void FillEditSiteTestHeader()
        {
            //object functionReturnValue = null;
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();

            dsSiteTest = new DataSet();
            //Fill Preferred Converting Line DropDown
            //dsSiteTest = objGetSiteTest.FillSiteTest(EoID);
            DataSet dsBrand = null;
            int i = 0;
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {
                if (dsSiteTest.Tables.Count == 0)
                {
                }
                else if (dsSiteTest.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    for (i = 0; i <= dsSiteTest.Tables[0].Rows.Count - 1; i++)
                    {
                        // ddlCategory.Items(ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(dsSiteTest.Tables[0].Rows(i)["Category_ID")))).Selected = true;
                        ddlCategory.Items[ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(dsSiteTest.Tables[0].Rows[i]["Category_ID"].ToString()))].Selected = true;
                    }

                    dsBrand = new DataSet();
                    //dsBrand = ClsEO.FillListBoxWithBrands("GET_MUR_BRAND_Segment_By_Category", ddlCategory.SelectedValue);

                    if (objEOBA.FillListBoxWithBrands(ddlCategory.SelectedValue, ref dsBrand))
                    {
                        if (dsBrand != null)
                        {
                            if (dsBrand.Tables.Count != null)
                            {
                                //For Brand Segment
                                lbEOBrandsDB.DataSource = dsBrand.Tables[0].DefaultView;
                                lbEOBrandsDB.DataTextField = "Brand_Segment_Name";
                                lbEOBrandsDB.DataValueField = "Brand_Segment_ID";
                                lbEOBrandsDB.DataBind();
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    else
                        return;

                    try
                    {
                        for (i = 0; i <= dsSiteTest.Tables[2].Rows.Count - 1; i++)
                        {
                            //lbEOBrandsDB.Items(lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue(dsSiteTest.Tables[2].Rows(i)["Brand_Segment_ID")))).Selected = true;
                            lbEOBrandsDB.Items[lbEOBrandsDB.Items.IndexOf(lbEOBrandsDB.Items.FindByValue(dsSiteTest.Tables[2].Rows[i]["Brand_Segment_ID"].ToString()))].Selected = true;
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    lblEoSelectedBrandDB.Text = "";
                    lblBrandIDList.Text = "";
                    int intBrand = 0;
                    for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
                    {
                        if (lbEOBrandsDB.Items[intBrand].Selected == true)
                        {
                            if (string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
                            {
                                lblEoSelectedBrandDB.Text = lbEOBrandsDB.Items[intBrand].Text;
                            }
                            else
                            {
                                lblEoSelectedBrandDB.Text = lblEoSelectedBrandDB.Text + "," + lbEOBrandsDB.Items[intBrand].Text;
                            }
                        }
                    }


                    for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
                    {
                        if (lbEOBrandsDB.Items[intBrand].Selected == true)
                        {
                            if (string.IsNullOrEmpty(lblBrandIDList.Text))
                            {
                                lblBrandIDList.Text = lbEOBrandsDB.Items[intBrand].Value;
                            }
                            else
                            {
                                lblBrandIDList.Text = lblBrandIDList.Text + "," + lbEOBrandsDB.Items[intBrand].Value;
                            }
                        }
                    }

                    DataSet dsProj = new DataSet();
                    int intCatID = 0;
                    if (ddlCategory.SelectedItem.Text == "--Select a Category--")
                    {
                        intCatID = 0;
                    }
                    else
                    {
                        intCatID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                    }
                    //For Category
                    //dsProj = objClsEO.GET_MUR_Projects_By_Category_Brand_Segment(intCatID, lblBrandIDList.Text);
                    if (objEOBA.GET_MUR_Projects_By_Category_Brand_Segment(intCatID, lblBrandIDList.Text, ref dsProj))
                    {
                        if (dsProj != null)
                        {
                            ddlProject.DataSource = dsProj;
                            ddlProject.DataTextField = "Project_Name";
                            ddlProject.DataValueField = "Project_ID";
                            ddlProject.DataBind();
                            ddlProject.Items.Insert(0, "--Select a Project--");
                        }
                    }


                    try
                    {
                        for (i = 0; i <= dsSiteTest.Tables[0].Rows.Count - 1; i++)
                        {
                            Int32 j = Convert.ToInt32(dsSiteTest.Tables[0].Rows[i]["Project_ID"]);
                            ddlProject.SelectedValue = dsSiteTest.Tables[0].Rows[i]["Project_ID"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                    }


                    //For events
                    FillListEvents();

                    try
                    {
                        for (i = 0; i <= dsSiteTest.Tables[1].Rows.Count - 1; i++)
                        {
                            //lbEOEventsDB.Items(lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue(dsSiteTest.Tables[1].Rows(i)["Event_ID")))).Selected = true;
                            lbEOEventsDB.Items[lbEOEventsDB.Items.IndexOf(lbEOEventsDB.Items.FindByValue(dsSiteTest.Tables[1].Rows[i]["Event_ID"].ToString()))].Selected = true;
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    //For Plant
                    try
                    {
                        for (i = 0; i <= dsSiteTest.Tables[0].Rows.Count - 1; i++)
                        {
                            //drpPlant.Items(drpPlant.Items.IndexOf(drpPlant.Items.FindByValue(dsSiteTest.Tables[0].Rows(i)["Plant_ID")))).Selected = true;
                            drpPlant.Items[drpPlant.Items.IndexOf(drpPlant.Items.FindByValue(dsSiteTest.Tables[0].Rows[i]["Plant_ID"].ToString()))].Selected = true;
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
            }

            //Filling StartDate and No of days 
            //BusinessObject.MUREO.BusinessObject.SiteTest objAddsiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            DataSet dsAm = new DataSet();
            if (Request.QueryString["Page"] == "MigrSt")
            {
                //dsAm = objAddsiteTest.GetAffectedMachine(ViewState["EventID"]);
                if (objSiteTestBA.GetAffectedMachine(Convert.ToInt32(ViewState["EventID"]), ref dsAm))
                {
                    if ((dsAm != null))
                    {
                        if (!(dsAm.Tables.Count == 0))
                        {
                            if (dsAm.Tables[1].Rows.Count != 0)
                            {
                                if (object.ReferenceEquals(dsAm.Tables[1].Rows[0]["Combining_Line_Machine_Name"], System.DBNull.Value))
                                {
                                    txtAffected.Text = string.Empty;
                                }
                                else
                                {
                                    txtAffected.Text = dsAm.Tables[1].Rows[0]["Combining_Line_Machine_Name"].ToString();
                                }
                            }
                            if (dsAm.Tables[2].Rows.Count != 0)
                            {
                                if (object.ReferenceEquals(dsAm.Tables[2].Rows[0]["Converting_Line_Machine_Name"], System.DBNull.Value))
                                {
                                    txtAffected.Text = txtAffected.Text + string.Empty;
                                }
                                else
                                {
                                    if (txtAffected.Text == string.Empty)
                                    {
                                        txtAffected.Text = dsAm.Tables[2].Rows[0]["Converting_Line_Machine_Name"].ToString();
                                    }
                                    else
                                    {
                                        txtAffected.Text = txtAffected.Text + "," + dsAm.Tables[2].Rows[0]["Converting_Line_Machine_Name"];
                                    }
                                }
                            }
                            if (dsAm.Tables[3].Rows.Count != 0)
                            {
                                if (object.ReferenceEquals(dsAm.Tables[3].Rows[0]["Paper_Machine_Name"], System.DBNull.Value))
                                {
                                    txtAffected.Text = txtAffected.Text + string.Empty;
                                }
                                else
                                {
                                    if (txtAffected.Text == string.Empty)
                                    {
                                        txtAffected.Text = dsAm.Tables[3].Rows[0]["Paper_Machine_Name"].ToString();
                                    }
                                    else
                                    {
                                        txtAffected.Text = txtAffected.Text + "," + dsAm.Tables[3].Rows[0]["Paper_Machine_Name"];
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateValuesForPlant()
        {
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            DataSet dsSiteTest = new DataSet();
            //dsSiteTest = objGetSiteTest.FillSiteTest(EoID);
            //Starting Header


            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {


                if (dsSiteTest == null)
                {

                }
                else if (dsSiteTest.Tables.Count == 0)
                {

                }
                else if (dsSiteTest.Tables[7].Rows.Count == 0)
                {
                }
                else
                {
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Run_Investigate_Module"], System.DBNull.Value))
                    {
                        rbPPMModelsYes.Checked = false;
                        rbPPMModelsNo.Checked = false;
                        objSiteTestBA1.RunInvestigateModule = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Run_Investigate_Module"].ToString() .ToString() == "Y")
                    {
                        rbPPMModelsYes.Checked = true;
                        objSiteTestBA1.RunInvestigateModule = "Y";
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Run_Investigate_Module"].ToString() == "N")
                    {
                        rbPPMModelsNo.Checked = true;
                        objSiteTestBA1.RunInvestigateModule = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Test_COordinator"], System.DBNull.Value))
                    {
                        lblPPMCoordiator.Text = "";
                        objSiteTestBA1.TestCoordinator = DBNull.Value.ToString();
                    }
                    else
                    {
                        lblPPMCoordiator.Text = dsSiteTest.Tables[7].Rows[0]["Test_COordinator"].ToString();
                        objSiteTestBA1.TestCoordinator = lblPPMCoordiator.Text;
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Number_Of_Days"], System.DBNull.Value))
                    {
                        txtPMDays.Text = "";
                    }
                    else
                    {
                        txtPMDays.Text = dsSiteTest.Tables[7].Rows[0]["Number_Of_Days"].ToString();
                        objSiteTestBA1.PPMNumberOfDays = Convert.ToDecimal(txtPMDays.Text);
                    }

                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Preferred_Run_Dates"], System.DBNull.Value))
                    {
                        txtPPMPRDate.Text = "";
                        objSiteTestBA1.PPMPreferredRunDate = System.DateTime.MinValue;
                    }
                    else
                    {
                        System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[7].Rows[0]["Preferred_Run_Dates"]);
                        txtPPMPRDate.Text = d.Date.ToShortDateString();
                        objSiteTestBA1.PPMPreferredRunDate = Convert.ToDateTime(txtPPMPRDate.Text);
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Earliest_Run_Dates"], System.DBNull.Value))
                    {
                        txtPPMERDate.Text = "";
                    }
                    else
                    {
                        System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[7].Rows[0]["Earliest_Run_Dates"]);
                        txtPPMERDate.Text = d.Date.ToShortDateString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Latest_Run_Dates"], System.DBNull.Value))
                    {
                        txtPPMLRDates.Text = "";
                    }
                    else
                    {
                        System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[7].Rows[0]["Latest_Run_Dates"]);
                        txtPPMLRDates.Text = d.Date.ToShortDateString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Consumer_Test_Production"], System.DBNull.Value))
                    {
                        rbPPMCTPYes.Checked = false;
                        rbPPMModelsNo.Checked = false;
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Consumer_Test_Production"] .ToString() .ToString() == "Y")
                    {
                        rbPPMCTPYes.Checked = true;

                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Consumer_Test_Production"].ToString() == "N")
                    {
                        rbPPMCTPNo.Checked = true;

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Equ_Drying_Format"], System.DBNull.Value))
                    {
                        drpDrying.SelectedIndex = 0;
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Equ_Drying_Format"] == "0")
                    {
                        drpDrying.SelectedIndex = 0;
                    }
                    else
                    {
                        drpDrying.SelectedValue = dsSiteTest.Tables[7].Rows[0]["Equ_Drying_Format"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Equ_PM_Format"], System.DBNull.Value))
                    {
                        drpFormat.SelectedIndex = 0;
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Equ_PM_Format"] == "0")
                    {
                        drpFormat.SelectedIndex = 0;
                    }
                    else
                    {
                        drpFormat.SelectedValue = dsSiteTest.Tables[7].Rows[0]["Equ_PM_Format"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Equ_Headbox_Type"], System.DBNull.Value))
                    {
                        drpHeadbox.SelectedIndex = 0;
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Equ_Headbox_Type"] == "0")
                    {
                        drpHeadbox.SelectedIndex = 0;
                    }
                    else
                    {
                        drpHeadbox.SelectedValue = dsSiteTest.Tables[7].Rows[0]["Equ_Headbox_Type"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_Is_Karlinal"], System.DBNull.Value))
                    {
                        rbKarliYes.Checked = false;
                        rbKarliNo.Checked = false;
                        objSiteTestBA1.RunInvestigateModule = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Mat_Is_Karlinal"] .ToString() .ToString() == "Y")
                    {
                        rbKarliYes.Checked = true;

                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Mat_Is_Karlinal"].ToString() == "N")
                    {
                        rbKarliNo.Checked = true;

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_Karlinal_Gallons"], System.DBNull.Value))
                    {
                        txtGallons.Text = "";
                    }
                    else
                    {
                        txtGallons.Text = dsSiteTest.Tables[7].Rows[0]["Mat_Karlinal_Gallons"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_CPN_Belts"], System.DBNull.Value))
                    {
                        rdCPNYes.Checked = false;
                        rbCPNNo.Checked = false;
                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Mat_CPN_Belts"] .ToString() .ToString() == "Y")
                    {
                        rdCPNYes.Checked = true;

                    }
                    else if (dsSiteTest.Tables[7].Rows[0]["Mat_CPN_Belts"].ToString() == "N")
                    {
                        rbCPNNo.Checked = true;
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Mat_Patter_Per_Belt"], System.DBNull.Value))
                    {
                        txtPatterns.Text = "";
                    }
                    else
                    {
                        txtPatterns.Text = dsSiteTest.Tables[7].Rows[0]["Mat_Patter_Per_Belt"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Other_Equipment"], System.DBNull.Value))
                    {
                        txtEquip.Text = "";
                    }
                    else
                    {
                        txtEquip.Text = dsSiteTest.Tables[7].Rows[0]["Other_Equipment"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Other_Material"], System.DBNull.Value))
                    {
                        txtMaterials.Text = "";
                    }
                    else
                    {
                        txtMaterials.Text = dsSiteTest.Tables[7].Rows[0]["Other_Material"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[7].Rows[0]["Other_Other"], System.DBNull.Value))
                    {
                        txtPPMOther.Text = "";
                    }
                    else
                    {
                        txtPPMOther.Text = dsSiteTest.Tables[7].Rows[0]["Other_Other"].ToString();
                    }
                }
            }
            objSiteTestBA1.PPMOtherUniqueReq = DBNull.Value.ToString();
            objSiteTestBA1.StMode = "P";
        }

        public void UpdateStraightSiteTest()
        {
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();

            dsSiteTest = new DataSet();

            //dsSiteTest = objGetSiteTest.FillSiteTest(EoID);
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {

                //Starting Header

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
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["EO_Title"], System.DBNull.Value))
                        {

                        }
                        else
                        {
                            objSiteTestBA1.Title = dsSiteTest.Tables[0].Rows[0]["EO_Title"].ToString();
                            txtTitle.Text = dsSiteTest.Tables[0].Rows[0]["EO_Title"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["EO_Number"], System.DBNull.Value))
                        {
                        }
                        else
                        {
                            lblEONum.Text = dsSiteTest.Tables[0].Rows[0]["EO_Number"].ToString();

                        }

                        try
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Stage_Status"], System.DBNull.Value))
                            {
                                ViewState["stageStatus"] = string.Empty;

                            }
                            else
                            {
                                objSiteTestBA1.StageStatus = dsSiteTest.Tables[0].Rows[0]["Stage_Status"].ToString();
                                ViewState["stageStatus"] = dsSiteTest.Tables[0].Rows[0]["Stage_Status"];
                            }

                        }
                        catch (Exception ex)
                        {
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Originator"], System.DBNull.Value))
                        {
                        }
                        else
                        {
                            objSiteTestBA1.Originator = dsSiteTest.Tables[0].Rows[0]["Originator"].ToString();
                            lblOriginator.Text = dsSiteTest.Tables[0].Rows[0]["Originator"].ToString();
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Phone_Num"], System.DBNull.Value))
                        {

                        }
                        else
                        {
                            objSiteTestBA1.PhoneNumber = dsSiteTest.Tables[0].Rows[0]["Phone_Num"].ToString();
                            txtPhoneNum.Text = dsSiteTest.Tables[0].Rows[0]["Phone_Num"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["Office_Num"], System.DBNull.Value))
                        {

                        }
                        else
                        {
                            objSiteTestBA1.OfficeNumber = dsSiteTest.Tables[0].Rows[0]["Office_Num"].ToString();
                            txtOfficeNum.Text = dsSiteTest.Tables[0].Rows[0]["Office_Num"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[0].Rows[0]["CoOriginator"], System.DBNull.Value))
                        {

                        }
                        else
                        {
                            objSiteTestBA1.CoOrginator = dsSiteTest.Tables[0].Rows[0]["CoOriginator"].ToString();

                            txtCoOriginator.Text = dsSiteTest.Tables[0].Rows[0]["CoOriginator"].ToString();
                            hdntxtPrjLead.Value = dsSiteTest.Tables[0].Rows[0]["CoOriginator"].ToString();
                        }

                    }


                    if (dsSiteTest.Tables[3].Rows.Count == 0)
                    {
                        txthdnSiteTestID.Text = "0";
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"], System.DBNull.Value))
                        {
                            objSiteTestBA1.SiteTestID = 0;
                            txthdnSiteTestID.Text = "0";
                        }
                        else
                        {
                            objSiteTestBA1.SiteTestID = Convert.ToInt32(dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"]);
                            txthdnSiteTestID.Text = dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"].ToString();
                        }
                        //if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != "MigrSt")
                        if (Request.QueryString["Page"] != "MigrSt")
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"], System.DBNull.Value))
                            {
                                txtStartDate.Text = "";
                            }
                            else
                            {
                                System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"]);
                                txtStartDate.Text = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"]).Date.ToShortDateString();
                                DateTime dtime = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_Start_Date"]);
                                int hr = dtime.Hour;
                                int min = dtime.Minute;
                                int sec = dtime.Second;
                                string Part = null;
                                if (hr > 11)
                                {
                                    if (hr == 24)
                                    {
                                        hr = hr - 12;
                                        Part = "AM";
                                    }
                                    else
                                    {
                                        hr = hr - 12;
                                        Part = "PM";
                                    }

                                }
                                else
                                {
                                    Part = "AM";

                                }
                                drpDay.SelectedValue = hr.ToString();
                                drpMonth.SelectedValue = min.ToString();
                                drpPart.SelectedValue = Part;

                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Test_End_Date"], System.DBNull.Value))
                            {
                                txtEndDate.Text = "";
                            }
                            else
                            {
                                txtEndDate.Text = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_End_Date"].ToString()).Date.ToShortDateString();
                                DateTime dtime = Convert.ToDateTime(dsSiteTest.Tables[3].Rows[0]["Test_End_Date"]);
                                int hr = dtime.Hour;
                                int min = dtime.Minute;
                                int sec = dtime.Second;
                                string Part = null;
                                if (hr > 11)
                                {
                                    if (hr == 24)
                                    {
                                        hr = hr - 12;
                                        Part = "AM";
                                    }
                                    else
                                    {
                                        hr = hr - 12;
                                        Part = "PM";
                                    }

                                }
                                else
                                {
                                    Part = "AM";

                                }
                                drpEndTime.SelectedValue = hr.ToString();
                                drpEndMin.SelectedValue = min.ToString();
                                drpEndPart.SelectedValue = Part;
                            }
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Objective"], System.DBNull.Value))
                        {
                            txtObjective.Text = "";
                        }
                        else
                        {
                            txtObjective.Text = dsSiteTest.Tables[3].Rows[0]["Objective"].ToString();
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Site_Test_ID"], System.DBNull.Value))
                        {

                        }
                        else
                        {
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Description"], System.DBNull.Value))
                        {
                            txtDescription.Text = "";
                        }
                        else
                        {
                            txtDescription.Text = dsSiteTest.Tables[3].Rows[0]["Description"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Memo"], System.DBNull.Value))
                        {
                            txtMemo.Text = "";
                        }
                        else
                        {
                            txtMemo.Text = dsSiteTest.Tables[3].Rows[0]["Memo"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Affected_Lines_Machines"], System.DBNull.Value))
                        {
                            txtAffected.Text = "";
                        }
                        else
                        {
                            txtAffected.Text = dsSiteTest.Tables[3].Rows[0]["Affected_Lines_Machines"].ToString();
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[3].Rows[0]["Final_Report_Due"], System.DBNull.Value))
                        {
                            txtReportDue.Text = "";
                        }
                        else
                        {
                            txtReportDue.Text = dsSiteTest.Tables[3].Rows[0]["Final_Report_Due"].ToString();
                        }

                    }

                    if (dsSiteTest.Tables[4].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["Additional_Info"], System.DBNull.Value))
                        {
                            txtAddInfo.Text = "";
                        }
                        else
                        {
                            txtAddInfo.Text = dsSiteTest.Tables[4].Rows[0]["Additional_Info"].ToString();
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Chemical_Change"], System.DBNull.Value))
                        {
                            changeYes.Checked = false;
                            changeNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Chemical_Change"] .ToString() .ToString() == "Y")
                        {
                            changeYes.Checked = true;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Chemical_Change"].ToString() == "N")
                        {
                            changeNo.Checked = true;
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Raw_Material_Change"], System.DBNull.Value))
                        {
                            RMYes.Checked = false;
                            RMNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Raw_Material_Change"] .ToString() .ToString() == "Y")
                        {
                            RMYes.Checked = true;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Raw_Material_Change"].ToString() == "N")
                        {
                            RMNo.Checked = true;
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Equip_Process_System"], System.DBNull.Value))
                        {
                            eqpYes.Checked = false;
                            eqpNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Equip_Process_System"] .ToString() .ToString() == "Y")
                        {
                            eqpYes.Checked = true;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Equip_Process_System"].ToString() == "N")
                        {
                            eqpNo.Checked = true;
                        }

                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"], System.DBNull.Value))
                        {
                            jobYes.Checked = false;
                            jobNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"] .ToString() .ToString() == "Y")
                        {
                            jobYes.Checked = true;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"].ToString() == "N")
                        {
                            jobNo.Checked = true;
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"], System.DBNull.Value))
                        {
                            jobYes.Checked = false;
                            jobNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"] .ToString() .ToString() == "Y")
                        {
                            jobYes.Checked = true;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Job_Task_Change"].ToString() == "N")
                        {
                            jobNo.Checked = true;
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["New_Storage_Concers"], System.DBNull.Value))
                        {
                            stgYes.Checked = false;
                            stgNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Storage_Concers"] .ToString() .ToString() == "Y")
                        {
                            stgYes.Checked = true;
                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["New_Storage_Concers"].ToString() == "N")
                        {
                            stgNo.Checked = true;
                        }
                        if (object.ReferenceEquals(dsSiteTest.Tables[4].Rows[0]["Is_Chemical_Approval_Needed"], System.DBNull.Value))
                        {
                            apprYes.Checked = false;
                            apprNo.Checked = false;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["Is_Chemical_Approval_Needed"] .ToString() .ToString() == "Y")
                        {
                            apprYes.Checked = true;

                        }
                        else if (dsSiteTest.Tables[4].Rows[0]["Is_Chemical_Approval_Needed"].ToString() == "N")
                        {
                            apprNo.Checked = true;
                        }
                    }

                    if (apprYes.Checked == true)
                    {
                        trApproval.Visible = true;
                        //Begin Chemical Approval

                        if (dsSiteTest.Tables[5].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_USE"], System.DBNull.Value))
                            {
                                txtPrecautions.Text = "";
                            }
                            else
                            {
                                txtPrecautions.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_USE"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_SAMPLING"], System.DBNull.Value))
                            {
                                txtSampling.Text = "";
                            }
                            else
                            {
                                txtSampling.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_SAMPLING"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_EQUIPMENT"], System.DBNull.Value))
                            {
                                txtEquipment.Text = "";
                            }
                            else
                            {
                                txtEquipment.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_EQUIPMENT"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Disposal_UnUsed_Chemical"], System.DBNull.Value))
                            {
                                txtDispose.Text = "";
                            }
                            else
                            {
                                txtDispose.Text = dsSiteTest.Tables[5].Rows[0]["Disposal_UnUsed_Chemical"].ToString();
                            }

                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Precaution_STORAGE"], System.DBNull.Value))
                            {
                                txtStorage.Text = "";
                            }
                            else
                            {
                                txtStorage.Text = dsSiteTest.Tables[5].Rows[0]["Precaution_STORAGE"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Spill_Response"], System.DBNull.Value))
                            {
                                txtSpill.Text = "";
                            }
                            else
                            {
                                txtSpill.Text = dsSiteTest.Tables[5].Rows[0]["Spill_Response"].ToString();
                            }
                            if (object.ReferenceEquals(dsSiteTest.Tables[5].Rows[0]["Potential_Environmental_Impact"], System.DBNull.Value))
                            {
                                txtEnvImpacts.Text = "";
                            }
                            else
                            {
                                txtEnvImpacts.Text = dsSiteTest.Tables[5].Rows[0]["Potential_Environmental_Impact"].ToString();
                            }
                        }


                    }
                    else
                    {
                        trApproval.Visible = false;
                    }

                    //Setting Attachments
                    if (!(dsSiteTest.Tables[14].Rows.Count == 0))
                    {
                        lbTestPlansAttach.DataSource = dsSiteTest.Tables[14].DefaultView;
                        lbTestPlansAttach.DataTextField = "Test_Plan_Attachment_File_Name";
                        lbTestPlansAttach.DataValueField = "Test_Plan_Attach_ID";
                        lbTestPlansAttach.DataBind();

                        dgrdTestPlan.DataSource = dsSiteTest.Tables[14].DefaultView;
                        dgrdTestPlan.DataBind();

                    }


                    if (!(dsSiteTest.Tables[15].Rows.Count == 0))
                    {
                        lbSupDocAttach.DataSource = dsSiteTest.Tables[15].DefaultView;
                        lbSupDocAttach.DataTextField = "Other_Supporting_Doc_Attachment_File_Name";
                        lbSupDocAttach.DataValueField = "Other_Supporting_Doc_Attach_ID";
                        lbSupDocAttach.DataBind();

                        dgrdSupAttach.DataSource = dsSiteTest.Tables[15].DefaultView;
                        dgrdSupAttach.DataBind();

                    }


                    if (!(dsSiteTest.Tables[16].Rows.Count == 0))
                    {
                        lbFinalReportAttach.DataSource = dsSiteTest.Tables[16].DefaultView;
                        lbFinalReportAttach.DataTextField = "Final_Report_Attachment_File_Name";
                        lbFinalReportAttach.DataValueField = "Final_Report_Attach_ID";
                        lbFinalReportAttach.DataBind();

                        dgrdAttachment.DataSource = dsSiteTest.Tables[16].DefaultView;
                        dgrdAttachment.DataBind();

                    }
                    //End of setting attachments
                    objSiteTestBA1.UserName = objSecurity.UserName;
                    int dlRowCount = 0;
                    if (dsSiteTest.Tables[12].Rows.Count == 0)
                    {

                    }
                    else
                    {
                        dlstConcGrp.Visible = true;
                        dlstConcGrp.DataSource = dsSiteTest.Tables[12];
                        dlstConcGrp.DataBind();
                        if (dlstConcGrp.Items.Count == 0)
                        {
                        }
                        else
                        {
                            dlstConcGrp.Visible = true;
                            string strRole = objSecurity.UserRole();
                            for (dlRowCount = 0; dlRowCount <= dlstConcGrp.Items.Count - 1; dlRowCount++)
                            {
                                if (object.ReferenceEquals(dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"], System.DBNull.Value))
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                }
                                else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "No Response")
                                {
                                    if (objSiteTestBA1.UserName.ToUpper() == hdntxtPrjLead.Value.ToString().ToUpper() || objSiteTestBA1.UserName.ToUpper() == lblOriginator.Text.ToString().ToUpper() || strRole.ToUpper() == "MUREO_Admin".ToUpper())
                                    {
                                        if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                        {
                                            dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                            dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                            dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                        }
                                        else
                                        {
                                            dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                            dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                            dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;

                                        }

                                    }
                                    else if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                    }
                                    else
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                    }

                                }
                                else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Approved")
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;


                                }
                                else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Declined")
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                }
                            }

                        }
                    }

                }
            }
            // BusinessObject.MUREO.BusinessObject.SiteTest objGetRev = new BusinessObject.MUREO.BusinessObject.SiteTest();
            dsSiteTest = new DataSet();

            int EId = Convert.ToInt32(txthdnEoID.Text);
            //dsSiteTest = objGetRev.FillSiteTest(EId);

            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EId), ref dsSiteTest))
            {
                if (dsSiteTest == null)
                {

                }
                else if (dsSiteTest.Tables.Count == 0)
                {

                }
                else if (dsSiteTest.Tables[13].Rows.Count == 0)
                {

                }
                else
                {
                    dgrdRevHis.DataSource = dsSiteTest.Tables[13];
                    dgrdRevHis.DataBind();
                    dgrdRevHis.Visible = true;
                }
            }
        }

        public void UpdateValuesForConvertLine()
        {
            //Update values for convert line
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            dsSiteTest = new DataSet();

            //dsSiteTest = objGetSiteTest.FillSiteTest(EoID);
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {

                //Starting Header
                if (dsSiteTest == null)
                {
                }
                else if (dsSiteTest.Tables.Count == 0)
                {
                }
                else if (dsSiteTest.Tables[6].Rows.Count == 0)
                {
                }
                else
                {
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Conv_Test_Coordinator"], System.DBNull.Value))
                    {
                        lblCoordinator.Text = "";
                        objSiteTestBA1.ConvTestCoordinator = DBNull.Value.ToString();
                    }
                    else
                    {
                        lblCoordinator.Text = dsSiteTest.Tables[6].Rows[0]["Conv_Test_Coordinator"].ToString();
                        objSiteTestBA1.ConvTestCoordinator = lblCoordinator.Text;
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Number_Of_Days"], System.DBNull.Value))
                    {
                        txtDays.Text = "";
                        objSiteTestBA1.ConvNumberOfDays = Convert.ToDecimal(0.0);
                    }
                    else
                    {
                        txtDays.Text = dsSiteTest.Tables[6].Rows[0]["Number_Of_Days"].ToString();
                        objSiteTestBA1.ConvNumberOfDays = Convert.ToDecimal(txtDays.Text);
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Preferred_Run_Dates"], System.DBNull.Value))
                    {
                        txtPreRunDates.Text = "";
                        objSiteTestBA1.ConvPreferredRunDate = System.DateTime.MinValue;
                    }
                    else
                    {
                        System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[6].Rows[0]["Preferred_Run_Dates"]);
                        txtPreRunDates.Text = d.Date.ToString();
                        objSiteTestBA1.ConvPreferredRunDate = Convert.ToDateTime(txtPreRunDates.Text);
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Earliest_Run_Dates"], System.DBNull.Value))
                    {
                        txtEarlRunDates.Text = "";
                        objSiteTestBA1.ConvEarliestRunDates = System.DateTime.MinValue;
                    }
                    else
                    {
                        System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[6].Rows[0]["Earliest_Run_Dates"]);
                        txtEarlRunDates.Text = d.Date.ToString();
                        objSiteTestBA1.ConvEarliestRunDates = Convert.ToDateTime(txtEarlRunDates.Text);
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Latest_Run_Dates"], System.DBNull.Value))
                    {
                        txtLRDates.Text = "";
                        objSiteTestBA1.ConvLatestRunDates = System.DateTime.MinValue;
                    }
                    else
                    {
                        System.DateTime d = Convert.ToDateTime(dsSiteTest.Tables[6].Rows[0]["Latest_Run_Dates"]);
                        txtLRDates.Text = d.Date.ToString();
                        objSiteTestBA1.ConvLatestRunDates = Convert.ToDateTime(txtLRDates.Text);
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"], System.DBNull.Value))
                    {
                        rdCTPYes.Checked = false;
                        rdCTPNo.Checked = false;
                        objSiteTestBA1.ConvConsumerTestProduction = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"].ToString() == "Y")
                    {
                        rdCTPYes.Checked = true;
                        objSiteTestBA1.ConvConsumerTestProduction = "Y";
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"].ToString() == "N")
                    {
                        rdCTPNo.Checked = false;
                        objSiteTestBA1.ConvConsumerTestProduction = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line"], System.DBNull.Value))
                    {
                        ddlPrefConline.SelectedIndex = 0;
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line"].ToString() == "0")
                    {
                        ddlPrefConline.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlPrefConline.SelectedValue = dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line"].ToString();
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line"], System.DBNull.Value))
                    {
                        ddlaltConvLine.SelectedIndex = 0;
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line"].ToString() == "0")
                    {
                        ddlaltConvLine.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlaltConvLine.SelectedValue = dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line"].ToString();
                    }
                    //------------------------------------------------------------------------
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"], System.DBNull.Value))
                    {
                        ddlElSetup.SelectedIndex = 0;
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"].ToString() == "0")
                    {
                        ddlElSetup.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlElSetup.SelectedValue = dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"].ToString();
                        objSiteTestBA1.EquELSetup = Convert.ToInt32(dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"]);
                    }
                    //----------------------------------------------------------------------------------

                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Emboss_Pattern"], System.DBNull.Value))
                    {
                        txtEquEmbossPattern.Text = "";
                        objSiteTestBA1.EquEmbossPattern = "";

                    }
                    else
                    {
                        txtEquEmbossPattern.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Emboss_Pattern"].ToString();
                        objSiteTestBA1.EquEmbossPattern = txtEquEmbossPattern.Text;
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"], System.DBNull.Value))
                    {
                        rbHotMeltYes.Checked = false;
                        rbHotMeltNo.Checked = false;
                        objSiteTestBA1.EquHotMelt = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"].ToString() == "Y")
                    {
                        rbHotMeltYes.Checked = true;
                        objSiteTestBA1.EquHotMelt = "Y";
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"].ToString() == "N")
                    {
                        rbHotMeltNo.Checked = true;
                        objSiteTestBA1.EquHotMelt = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"], System.DBNull.Value))
                    {
                        rbextrHeadsYes.Checked = false;
                        rbextrHeadsNo.Checked = false;
                        objSiteTestBA1.EquIsExtrusionHeads = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"].ToString() == "Y")
                    {
                        rbextrHeadsYes.Checked = true;
                        objSiteTestBA1.EquIsExtrusionHeads = "Y";
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"].ToString() == "N")
                    {
                        rbextrHeadsNo.Checked = true;
                        objSiteTestBA1.EquIsExtrusionHeads = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Extrusion_Heads_Count"], System.DBNull.Value))
                    {
                        txtExtrusionHeads.Text = "";
                        objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(0.0);
                    }
                    else
                    {
                        txtExtrusionHeads.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Extrusion_Heads_Count"].ToString();
                        objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(txtExtrusionHeads.Text);

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"], System.DBNull.Value))
                    {
                        rbHeadsHeatedYes.Checked = false;
                        rbHeadsHeatedNo.Checked = false;
                        objSiteTestBA1.EquIsHeadsHeated = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"].ToString() == "Y")
                    {
                        rbHeadsHeatedYes.Checked = true;
                        objSiteTestBA1.EquIsHeadsHeated = "Y";
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"].ToString() == "N")
                    {
                        rbHeadsHeatedNo.Checked = true;
                        objSiteTestBA1.EquIsHeadsHeated = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"], System.DBNull.Value))
                    {
                        rbStreamreqdYes.Checked = false;
                        rbStreamreqdNo.Checked = false;

                        objSiteTestBA1.EquIsStream = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"].ToString() == "Y")
                    {
                        rbStreamreqdYes.Checked = true;
                        objSiteTestBA1.EquIsStream = "Y";
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"].ToString() == "N")
                    {
                        rbStreamreqdNo.Checked = true;
                        objSiteTestBA1.EquIsStream = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"], System.DBNull.Value))
                    {
                        rdInkYes.Checked = false;
                        rdInkNo.Checked = false;
                        objSiteTestBA1.MatIsStdProcessInk = DBNull.Value.ToString();
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"].ToString() == "Y")
                    {
                        rdInkYes.Checked = true;
                        objSiteTestBA1.MatIsStdProcessInk = "Y";
                    }
                    else if (dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"].ToString() == "N")
                    {
                        rdInkNo.Checked = true;
                        objSiteTestBA1.MatIsStdProcessInk = "N";
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Yellow_Gallons"], System.DBNull.Value))
                    {
                        txtYellow.Text = "";
                        objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(0.0);
                    }
                    else
                    {
                        txtYellow.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Yellow_Gallons"].ToString();
                        objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(txtYellow.Text);

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Magenta_Gallons"], System.DBNull.Value))
                    {
                        txtMagneta.Text = "";
                        objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(0.022);
                    }
                    else
                    {
                        txtMagneta.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Magenta_Gallons"].ToString();
                        objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(txtMagneta.Text);

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Cyan_Gallons"], System.DBNull.Value))
                    {
                        txtCyan.Text = "";
                        objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(0.0);
                    }
                    else
                    {
                        txtCyan.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Cyan_Gallons"].ToString();
                        objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(txtCyan.Text);
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"], System.DBNull.Value))
                    {
                        txtBlack.Text = "";
                        objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(0.0);
                    }
                    else
                    {
                        txtBlack.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"].ToString();
                        objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(txtBlack.Text);

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"], System.DBNull.Value))
                    {
                        txtBlack.Text = "";
                        objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(0.0);
                    }
                    else
                    {
                        txtBlack.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"].ToString();
                        objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(txtBlack.Text);

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Equipment"], System.DBNull.Value))
                    {
                        txtOtherEquipment.Text = "";
                        objSiteTestBA1.ConvOtherEquipment = DBNull.Value.ToString();
                    }
                    else
                    {
                        txtOtherEquipment.Text = dsSiteTest.Tables[6].Rows[0]["Other_Equipment"].ToString();
                        objSiteTestBA1.ConvOtherEquipment = txtOtherEquipment.Text;

                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Material"], System.DBNull.Value))
                    {
                        txtOtherMat.Text = "";
                        objSiteTestBA1.ConvOtherMaterial = DBNull.Value.ToString();
                    }
                    else
                    {
                        txtOtherMat.Text = dsSiteTest.Tables[6].Rows[0]["Other_Material"].ToString();
                        objSiteTestBA1.ConvOtherMaterial = txtOtherMat.Text;
                    }
                    if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Other"], System.DBNull.Value))
                    {
                        txtOther.Text = "";
                        objSiteTestBA1.ConvOtherOther = DBNull.Value.ToString();
                    }
                    else
                    {
                        txtOther.Text = dsSiteTest.Tables[6].Rows[0]["Other_Other"].ToString();
                        objSiteTestBA1.ConvOtherOther = txtOther.Text;
                    }
                    objSiteTestBA1.ConvOtherUniqueReq = DBNull.Value.ToString();
                    objSiteTestBA1.StMode = "C";
                }
            }
        }

        protected void rdInkYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdInkYes.Checked)
                trApproval.Visible = false;
        }

        protected void apprYes_CheckedChanged(object sender, EventArgs e)
        {
            if (apprYes.Checked)
                trApproval.Visible = true;
            else
                trApproval.Visible = false;
        }

        protected void apprNo_CheckedChanged(object sender, EventArgs e)
        {
            if (apprNo.Checked)
                trApproval.Visible = false;
        }

        public void FillStraightSiteTest()
        {
            sqldatenull = SqlDateTime.Null;
            //Setting Test Start Time
            string strDateTime = null;
            string strTime = null;
            string strEndDateTime = null;
            string strEndTime = null;
            if (!(drpDay.SelectedIndex == -1))
            {
                strTime = drpDay.SelectedItem.Value;
            }
            else
            {
                strTime = "";
            }
            if (!(drpMonth.SelectedIndex == -1))
            {

                if (string.IsNullOrEmpty(strTime))
                {
                }
                else
                {
                    strTime = strTime + ":" + drpMonth.SelectedItem.Value;
                }
            }
            else
            {
                strTime = "";
            }
            if (!(drpPart.SelectedIndex == -1))
            {

                if (string.IsNullOrEmpty(strTime))
                {
                }
                else
                {
                    strTime = strTime + " " + drpPart.SelectedItem.Value;
                }
            }
            else
            {
                strTime = "";
            }


            if (!string.IsNullOrEmpty(txtStartDate.Text))
            {
                objSiteTestBA1.TestStartDate = Convert.ToDateTime(txtStartDate.Text + " " + strTime);

            }
            else
            {
                objSiteTestBA1.TestStartDate = System.DateTime.MinValue;
            }
            //Setting DateTime For TestEndDate
            if (!(drpEndTime.SelectedIndex == -1))
            {
                strEndTime = drpEndTime.SelectedItem.Value;
            }
            else
            {
                strEndTime = "";
            }
            if (!(drpEndMin.SelectedIndex == -1))
            {

                if (string.IsNullOrEmpty(strEndTime))
                {
                }
                else
                {
                    strEndTime = strEndTime + ":" + drpEndMin.SelectedItem.Value;
                }
            }
            else
            {
                strEndTime = "";
            }
            if (!(drpEndPart.SelectedIndex == -1))
            {

                if (string.IsNullOrEmpty(strEndTime))
                {
                }
                else
                {
                    strEndTime = strEndTime + " " + drpEndPart.SelectedItem.Value;
                }
            }
            else
            {
                strEndTime = "";
            }

            if (txthdnPlantType.Text == "1")
            {
                if (!string.IsNullOrEmpty(txtPMDays.Text))
                {
                    txtEndDate.Text = Convert.ToDateTime(txtStartDate.Text).Date.AddDays(Convert.ToDouble(txtPMDays.Text)).ToString();
                }
            }
            else if (txthdnPlantType.Text == "2")
            {
                if (!string.IsNullOrEmpty(txtPMDays.Text))
                {
                    txtEndDate.Text = Convert.ToDateTime(txtStartDate.Text).Date.AddDays(Convert.ToDouble(txtDays.Text)).ToString();
                }
            }
            if (!string.IsNullOrEmpty(txtEndDate.Text))
            {
                DateTime d = Convert.ToDateTime(txtEndDate.Text).Date;

                //objSiteTestBA1.TestEndDate = Convert.ToDateTime(d.Date + " " + strEndTime);
                try
                {
                    objSiteTestBA1.TestEndDate = Convert.ToDateTime(d.Date.ToShortDateString() + " " + strEndTime);
                }
                catch (Exception ex)
                {
                }
                

            }
            else
            {
                objSiteTestBA1.TestEndDate = System.DateTime.MinValue;
            }
            if (!string.IsNullOrEmpty(txtDescription.Text))
            {
                objSiteTestBA1.Description = txtDescription.Text;
            }
            else
            {
                objSiteTestBA1.Description = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtObjective.Text))
            {
                objSiteTestBA1.Objective = txtObjective.Text;
            }
            else
            {
                objSiteTestBA1.Objective = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtMemo.Text))
            {
                objSiteTestBA1.Memo = txtMemo.Text;
            }
            else
            {
                objSiteTestBA1.Memo = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtAffected.Text))
            {
                objSiteTestBA1.AffectedLinesMachines = txtAffected.Text;
            }
            else
            {
                objSiteTestBA1.AffectedLinesMachines = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtReportDue.Text))
            {
                objSiteTestBA1.FinalReportDue = txtReportDue.Text;
            }
            else
            {
                objSiteTestBA1.FinalReportDue = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtReportDue.Text))
            {
                objSiteTestBA1.FinalReportDue = txtReportDue.Text;
            }
            else
            {
                objSiteTestBA1.FinalReportDue = DBNull.Value.ToString();
            }

            objSiteTestBA1.TestPlans = DBNull.Value.ToString();

            objSiteTestBA1.OtherSupprtingDoc = DBNull.Value.ToString();

            objSiteTestBA1.FinalReportAttachment = DBNull.Value.ToString();

            objSiteTestBA1.StMode = "S";

            if (!string.IsNullOrEmpty(txtAddInfo.Text))
            {
                objSiteTestBA1.AdditionalInfo = txtAddInfo.Text;
            }
            else
            {
                objSiteTestBA1.AdditionalInfo = DBNull.Value.ToString();
            }
            if (changeYes.Checked == true)
            {
                objSiteTestBA1.NewChemicalChange = "Y";
            }
            else if (changeNo.Checked == true)
            {
                objSiteTestBA1.NewChemicalChange = "N";

            }
            else
            {
                changeNo.Checked = true;
                objSiteTestBA1.NewChemicalChange = "N";

            }
            if (RMYes.Checked == true)
            {
                objSiteTestBA1.NewRawMaterialChange = "Y";
            }
            else if (RMNo.Checked == true)
            {
                objSiteTestBA1.NewRawMaterialChange = "N";
            }
            else
            {
                RMNo.Checked = true;
                objSiteTestBA1.NewRawMaterialChange = "N";
            }
            if (eqpYes.Checked == true)
            {
                objSiteTestBA1.NewEquipProcessSystem = "Y";
            }
            else if (eqpNo.Checked == true)
            {
                objSiteTestBA1.NewEquipProcessSystem = "N";
            }
            else
            {
                eqpNo.Checked = true;
                objSiteTestBA1.NewEquipProcessSystem = "N";
            }
            if (jobYes.Checked == true)
            {
                objSiteTestBA1.NewJobTaskChange = "Y";
            }
            else if (jobNo.Checked == true)
            {
                objSiteTestBA1.NewJobTaskChange = "N";
            }
            else
            {
                jobNo.Checked = true;
                objSiteTestBA1.NewJobTaskChange = "N";
            }
            if (stgYes.Checked == true)
            {
                objSiteTestBA1.NewStorageConcers = "Y";
            }
            else if (stgNo.Checked == true)
            {
                objSiteTestBA1.NewStorageConcers = "N";

            }
            else
            {
                stgNo.Checked = true;
                objSiteTestBA1.NewStorageConcers = "N";

            }

            if (apprYes.Checked == true)
            {
                objSiteTestBA1.IsChemicalApprovalNeeded = "Y";
                //Setting Values For Chemical Approval Description
                if (!string.IsNullOrEmpty(txtPrecautions.Text))
                {
                    objSiteTestBA1.PrecautionUSE = txtPrecautions.Text;
                }
                else
                {
                    objSiteTestBA1.PrecautionUSE = DBNull.Value.ToString();
                }
                if (!string.IsNullOrEmpty(txtSampling.Text))
                {
                    objSiteTestBA1.PrecautionSAMPLING = txtSampling.Text;
                }
                else
                {
                    objSiteTestBA1.PrecautionSAMPLING = DBNull.Value.ToString();
                }
                if (!string.IsNullOrEmpty(txtStorage.Text))
                {
                    objSiteTestBA1.PrecautionStorage = txtStorage.Text;
                }
                else
                {
                    objSiteTestBA1.PrecautionStorage = DBNull.Value.ToString();
                }
                if (!string.IsNullOrEmpty(txtEquipment.Text))
                {
                    objSiteTestBA1.PrecautionEquipment = txtEquipment.Text;
                }
                else
                {
                    objSiteTestBA1.PrecautionEquipment = DBNull.Value.ToString();
                }
                if (!string.IsNullOrEmpty(txtDispose.Text))
                {
                    objSiteTestBA1.DisposalUnUsedChemical = txtDispose.Text;
                }
                else
                {
                    objSiteTestBA1.DisposalUnUsedChemical = DBNull.Value.ToString();
                }
                if (!string.IsNullOrEmpty(txtSpill.Text))
                {
                    objSiteTestBA1.SpillResponse = txtSpill.Text;
                }
                else
                {
                    objSiteTestBA1.SpillResponse = DBNull.Value.ToString();
                }
                if (!string.IsNullOrEmpty(txtEnvImpacts.Text))
                {
                    objSiteTestBA1.PotentialEnvironmentalImpact = txtEnvImpacts.Text;
                }
                else
                {
                    objSiteTestBA1.PotentialEnvironmentalImpact = DBNull.Value.ToString();
                }
            }
            else if (apprNo.Checked == true)
            {
                objSiteTestBA1.IsChemicalApprovalNeeded = "N";
                objSiteTestBA1.PrecautionUSE = DBNull.Value.ToString();
                objSiteTestBA1.PrecautionSAMPLING = DBNull.Value.ToString();
                objSiteTestBA1.PrecautionStorage = DBNull.Value.ToString();
                objSiteTestBA1.PrecautionEquipment = DBNull.Value.ToString();
                objSiteTestBA1.DisposalUnUsedChemical = DBNull.Value.ToString();
                objSiteTestBA1.SpillResponse = DBNull.Value.ToString();
                objSiteTestBA1.PotentialEnvironmentalImpact = DBNull.Value.ToString();

            }
            else
            {
                objSiteTestBA1.PrecautionUSE = DBNull.Value.ToString();
                objSiteTestBA1.PrecautionSAMPLING = DBNull.Value.ToString();
                objSiteTestBA1.PrecautionStorage = DBNull.Value.ToString();
                objSiteTestBA1.PrecautionEquipment = DBNull.Value.ToString();
                objSiteTestBA1.DisposalUnUsedChemical = DBNull.Value.ToString();
                objSiteTestBA1.SpillResponse = DBNull.Value.ToString();
                objSiteTestBA1.PotentialEnvironmentalImpact = DBNull.Value.ToString();
                objSiteTestBA1.IsChemicalApprovalNeeded = DBNull.Value.ToString();
                apprNo.Checked = true;
                objSiteTestBA1.IsChemicalApprovalNeeded = "N";

            }
            //Temporary
            objSiteTestBA1.UserName = DBNull.Value.ToString();
            objSiteTestBA1.Status = "A";

        }

        public void SetValuesForConvertLine()
        {
            if (!string.IsNullOrEmpty(lblCoordinator.Text))
            {
                objSiteTestBA1.ConvTestCoordinator = lblCoordinator.Text;
            }
            else
            {
                objSiteTestBA1.ConvTestCoordinator = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtDays.Text))
            {
                objSiteTestBA1.ConvNumberOfDays = Convert.ToDecimal(txtDays.Text);
            }
            else
            {
                objSiteTestBA1.ConvNumberOfDays = Convert.ToDecimal(0.0);
            }

            if (!string.IsNullOrEmpty(txtPreRunDates.Text))
            {
                objSiteTestBA1.ConvPreferredRunDate = Convert.ToDateTime(txtPreRunDates.Text);

            }
            else
            {
                objSiteTestBA1.ConvPreferredRunDate = System.DateTime.MinValue;
            }
            if (!string.IsNullOrEmpty(txtEarlRunDates.Text))
            {
                objSiteTestBA1.ConvEarliestRunDates = Convert.ToDateTime(txtEarlRunDates.Text);

            }
            else
            {
                objSiteTestBA1.ConvEarliestRunDates = System.DateTime.MinValue;
            }

            if (!string.IsNullOrEmpty(txtLRDates.Text))
            {
                objSiteTestBA1.ConvLatestRunDates = Convert.ToDateTime(txtLRDates.Text);

            }
            else
            {
                objSiteTestBA1.ConvLatestRunDates = System.DateTime.MinValue;
            }


            if (!(rdCTPYes.Checked == true))
            {
                objSiteTestBA1.ConvConsumerTestProduction = "Y";
            }
            else if (rdCTPNo.Checked == true)
            {
                objSiteTestBA1.ConvConsumerTestProduction = "N";
            }
            else
            {
                rdCTPNo.Checked = true;
                objSiteTestBA1.ConvConsumerTestProduction = "N";
            }

            if (!(ddlPrefConline.SelectedIndex <= 0))
            {
                objSiteTestBA1.EquPreferredConvLine = Convert.ToInt32(ddlPrefConline.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.EquPreferredConvLine = 0;
            }

            if (!(ddlaltConvLine.SelectedIndex <= 0))
            {
                objSiteTestBA1.EquAltConvLine = Convert.ToInt32(ddlaltConvLine.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.EquAltConvLine = 0;
            }

            if (!(ddlElSetup.SelectedIndex <= 0))
            {
                objSiteTestBA1.EquELSetup = Convert.ToInt32(ddlElSetup.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.EquELSetup = 0;
            }

            if (!string.IsNullOrEmpty(txtEquEmbossPattern.Text))
            {
                objSiteTestBA1.EquEmbossPattern = txtEquEmbossPattern.Text;

            }
            else
            {
                objSiteTestBA1.EquEmbossPattern = DBNull.Value.ToString();
            }

            if (rbHotMeltYes.Checked == true)
            {
                objSiteTestBA1.EquHotMelt = "Y";
            }
            else if (rbHotMeltNo.Checked == true)
            {
                objSiteTestBA1.EquHotMelt = "N";
            }
            else
            {
                rbHotMeltNo.Checked = true;
                objSiteTestBA1.EquHotMelt = "N";
            }

            if (rbextrHeadsYes.Checked == true)
            {
                objSiteTestBA1.EquIsExtrusionHeads = "Y";
            }
            else if (rbextrHeadsNo.Checked == true)
            {
                objSiteTestBA1.EquIsExtrusionHeads = "N";
            }
            else
            {
                rbextrHeadsNo.Checked = true;
                objSiteTestBA1.EquIsExtrusionHeads = "N";
            }

            if (!string.IsNullOrEmpty(txtExtrusionHeads.Text))
            {
                objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(txtExtrusionHeads.Text);
            }
            else
            {
                objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(0.0);
            }

            if (rbHeadsHeatedYes.Checked == true)
            {
                objSiteTestBA1.EquIsHeadsHeated = "Y";
            }
            else if (rbHeadsHeatedNo.Checked == true)
            {
                objSiteTestBA1.EquIsHeadsHeated = "N";
            }
            else
            {
                rbHeadsHeatedNo.Checked = true;
                objSiteTestBA1.EquIsHeadsHeated = "N";
            }

            if (rbStreamreqdYes.Checked == true)
            {
                objSiteTestBA1.EquIsStream = "Y";
            }
            else if (rbStreamreqdNo.Checked == true)
            {
                objSiteTestBA1.EquIsStream = "N";
            }
            else
            {
                rbStreamreqdNo.Checked = true;
                objSiteTestBA1.EquIsStream = "N";
            }
            //Materials
            if (rdInkYes.Checked == true)
            {
                objSiteTestBA1.MatIsStdProcessInk = "Y";
            }
            else if (rdInkNo.Checked == true)
            {
                objSiteTestBA1.MatIsStdProcessInk = "N";
            }
            else
            {
                rdInkNo.Checked = true;
                objSiteTestBA1.MatIsStdProcessInk = "N";
            }

            if (!string.IsNullOrEmpty(txtYellow.Text))
            {
                objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(txtYellow.Text);
            }
            else
            {
                objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(0.0);
            }
            if (!string.IsNullOrEmpty(txtMagneta.Text))
            {
                objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(txtMagneta.Text);
            }
            else
            {
                objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(0.0);
            }
            if (!string.IsNullOrEmpty(txtCyan.Text))
            {
                objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(txtCyan.Text);
            }
            else
            {
                objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(0.0);
            }
            if (!string.IsNullOrEmpty(txtBlack.Text))
            {
                objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(txtBlack.Text);
            }
            else
            {
                objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(0.0);
            }
            if (!string.IsNullOrEmpty(txtOtherEquipment.Text))
            {
                objSiteTestBA1.ConvOtherEquipment = txtOtherEquipment.Text;
            }
            else
            {
                objSiteTestBA1.ConvOtherEquipment = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtOtherMat.Text))
            {
                objSiteTestBA1.ConvOtherMaterial = txtOtherMat.Text;
            }
            else
            {
                objSiteTestBA1.ConvOtherMaterial = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtOther.Text))
            {
                objSiteTestBA1.ConvOtherOther = txtOther.Text;
            }
            else
            {
                objSiteTestBA1.ConvOtherOther = DBNull.Value.ToString();
            }
            objSiteTestBA1.ConvOtherUniqueReq = DBNull.Value.ToString();
            objSiteTestBA1.StMode = "C";
        }

        public void SetNullSForPlant()
        {
            objSiteTestBA1.RunInvestigateModule = DBNull.Value.ToString();
            objSiteTestBA1.TestCoordinator = DBNull.Value.ToString();
            objSiteTestBA1.PPMNumberOfDays = Convert.ToDecimal(0.0);
            objSiteTestBA1.PPMPreferredRunDate = System.DateTime.MinValue;
            objSiteTestBA1.PPMEarliestRunDates = System.DateTime.MinValue;
            objSiteTestBA1.PPMLatestRunDates = System.DateTime.MinValue;
            objSiteTestBA1.PPMConsumerTestProduction = DBNull.Value.ToString();
            objSiteTestBA1.EquDryingFormat = 0;
            objSiteTestBA1.EquPMFormat = 0;
            objSiteTestBA1.EquHeadboxType = 0;
            objSiteTestBA1.MatIsKarlinal = DBNull.Value.ToString();
            objSiteTestBA1.MatKarlinalGallons = Convert.ToDecimal(0.0);
            objSiteTestBA1.MatCPNBelts = DBNull.Value.ToString();
            objSiteTestBA1.MatPatterPerBelt = DBNull.Value.ToString();
            objSiteTestBA1.PPMOtherUniqueReq = DBNull.Value.ToString();
            objSiteTestBA1.PPMOtherEquipment = DBNull.Value.ToString();
            objSiteTestBA1.PPMOtherMaterial = DBNull.Value.ToString();
            objSiteTestBA1.PPMOtherOther = DBNull.Value.ToString();
        }

        public void SetNullSForConvertLine()
        {
            objSiteTestBA1.ConvTestCoordinator = DBNull.Value.ToString();
            objSiteTestBA1.ConvNumberOfDays = Convert.ToDecimal(0.0);
            objSiteTestBA1.ConvPreferredRunDate = System.DateTime.MinValue;
            objSiteTestBA1.ConvEarliestRunDates = System.DateTime.MinValue;
            objSiteTestBA1.ConvLatestRunDates = System.DateTime.MinValue;
            objSiteTestBA1.ConvConsumerTestProduction = DBNull.Value.ToString();
            objSiteTestBA1.EquPreferredConvLine = 0;
            objSiteTestBA1.EquAltConvLine = 0;
            objSiteTestBA1.EquELSetup = 0;
            objSiteTestBA1.EquEmbossPattern = DBNull.Value.ToString();
            objSiteTestBA1.EquHotMelt = DBNull.Value.ToString();
            objSiteTestBA1.EquIsExtrusionHeads = DBNull.Value.ToString();
            objSiteTestBA1.EquIsHeadsHeated = DBNull.Value.ToString();
            objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(0.0);
            objSiteTestBA1.EquIsStream = DBNull.Value.ToString();
            objSiteTestBA1.MatIsStdProcessInk = DBNull.Value.ToString();
            objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(0.0);
            objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(0.0);
            objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(0.0);
            objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(0.0);
            objSiteTestBA1.ConvOtherUniqueReq = DBNull.Value.ToString();
            objSiteTestBA1.ConvOtherEquipment = DBNull.Value.ToString();
            objSiteTestBA1.ConvOtherMaterial = DBNull.Value.ToString();
            objSiteTestBA1.ConvOtherOther = DBNull.Value.ToString();
        }

        public void SetValuesForPlant()
        {
            if (rbPPMModelsYes.Checked == true)
            {
                objSiteTestBA1.RunInvestigateModule = "Y";
            }
            else if (rbPPMModelsNo.Checked == true)
            {
                objSiteTestBA1.RunInvestigateModule = "N";
            }
            else
            {
                rbPPMModelsNo.Checked = true;
                objSiteTestBA1.RunInvestigateModule = "N";
            }

            if (!string.IsNullOrEmpty(lblPPMCoordiator.Text))
            {
                objSiteTestBA1.TestCoordinator = lblPPMCoordiator.Text;

            }
            else
            {
                objSiteTestBA1.TestCoordinator = DBNull.Value.ToString();
            }

            if (!string.IsNullOrEmpty(txtPMDays.Text))
            {
                objSiteTestBA1.PPMNumberOfDays = Convert.ToDecimal(txtPMDays.Text);
            }
            else
            {
                objSiteTestBA1.PPMNumberOfDays = Convert.ToDecimal(0.0);
            }

            if (!string.IsNullOrEmpty(txtPPMPRDate.Text))
            {
                objSiteTestBA1.PPMPreferredRunDate = Convert.ToDateTime(txtPPMPRDate.Text);
            }
            else
            {
                objSiteTestBA1.PPMPreferredRunDate = System.DateTime.MinValue;
            }
            if (!string.IsNullOrEmpty(txtPPMERDate.Text))
            {
                objSiteTestBA1.PPMEarliestRunDates = Convert.ToDateTime(txtPPMERDate.Text);
            }
            else
            {
                objSiteTestBA1.PPMEarliestRunDates = System.DateTime.MinValue;
            }
            if (!string.IsNullOrEmpty(txtPPMLRDates.Text))
            {
                objSiteTestBA1.PPMLatestRunDates = Convert.ToDateTime(txtPPMLRDates.Text);
            }
            else
            {
                objSiteTestBA1.PPMLatestRunDates = System.DateTime.MinValue;
            }
            if (rbPPMCTPYes.Checked == true)
            {
                objSiteTestBA1.PPMConsumerTestProduction = "Y";
            }
            else if (rbPPMCTPNo.Checked == true)
            {
                objSiteTestBA1.PPMConsumerTestProduction = "N";
            }
            else
            {
                rbPPMCTPNo.Checked = true;
                objSiteTestBA1.PPMConsumerTestProduction = "N";
            }
            if (!(drpDrying.SelectedIndex <= 0))
            {
                objSiteTestBA1.EquDryingFormat = Convert.ToInt32(drpDrying.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.EquDryingFormat = 0;
            }
            if (!(drpFormat.SelectedIndex <= 0))
            {
                objSiteTestBA1.EquPMFormat = Convert.ToInt32(drpFormat.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.EquPMFormat = 0;
            }
            if (!(drpHeadbox.SelectedIndex <= 0))
            {
                objSiteTestBA1.EquHeadboxType = Convert.ToInt32(drpHeadbox.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.EquHeadboxType = 0;
            }
            if (rbKarliYes.Checked == true)
            {
                objSiteTestBA1.MatIsKarlinal = "Y";
            }
            else if (rbKarliYes.Checked == true)
            {
                objSiteTestBA1.MatIsKarlinal = "N";
            }
            else
            {
                rbKarliYes.Checked = true;
                objSiteTestBA1.MatIsKarlinal = "N";
            }
            if (!string.IsNullOrEmpty(txtGallons.Text))
            {
                objSiteTestBA1.MatKarlinalGallons = Convert.ToDecimal(txtGallons.Text);
            }
            else
            {
                objSiteTestBA1.MatKarlinalGallons = Convert.ToDecimal(0.0);
            }
            if (rdCPNYes.Checked == true)
            {
                objSiteTestBA1.MatCPNBelts = "Y";
            }
            else if (rdCPNYes.Checked == true)
            {
                objSiteTestBA1.MatCPNBelts = "N";
            }
            else
            {
                rdCPNYes.Checked = true;
                objSiteTestBA1.MatCPNBelts = "N";
            }
            if (!string.IsNullOrEmpty(txtPatterns.Text))
            {
                objSiteTestBA1.MatPatterPerBelt = txtPatterns.Text;
            }
            else
            {
                objSiteTestBA1.MatPatterPerBelt = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtEquip.Text))
            {
                objSiteTestBA1.PPMOtherEquipment = txtEquip.Text;
            }
            else
            {
                objSiteTestBA1.PPMOtherEquipment = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtMaterials.Text))
            {
                objSiteTestBA1.PPMOtherMaterial = txtMaterials.Text;
            }
            else
            {
                objSiteTestBA1.PPMOtherMaterial = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtPPMOther.Text))
            {
                objSiteTestBA1.PPMOtherOther = txtPPMOther.Text;
            }
            else
            {
                objSiteTestBA1.PPMOtherOther = DBNull.Value.ToString();
            }
            objSiteTestBA1.PPMOtherUniqueReq = DBNull.Value.ToString();
            objSiteTestBA1.StMode = "P";
        }

        public void FilesUpload(ListBox lb, ArrayList ar, string sectionName)
        {

            string script = null;
            if (((lb.Items.Count == 0)))
            {
            }
            else
            {
                System.Web.UI.HtmlControls.HtmlInputFile HIFAttchFinalTestPlan = null;
                string strTestFile = null;
                try
                {

                    foreach (System.Web.UI.HtmlControls.HtmlInputFile HIFAttchFinalTestPlan_loopVariable in ar)
                    {
                        HIFAttchFinalTestPlan = HIFAttchFinalTestPlan_loopVariable;
                        try
                        {
                            //**********Reading File Attachment and Converting to Bytes*********
                            // ERROR: Not supported in C#: ReDimStatement
                            bytContent = new byte[HIFAttchFinalTestPlan.PostedFile.InputStream.Length];
                            //byte array, set to file size 
                            sContentType = HIFAttchFinalTestPlan.PostedFile.ContentType;
                            //strip the path off the filename 
                            //intStripthePath = Strings.InStrRev(HIFAttchFinalTestPlan.PostedFile.FileName.Trim(), "\\");
                            intStripthePath = HIFAttchFinalTestPlan.PostedFile.FileName.Trim().LastIndexOf("\\");
                            if (intStripthePath == 0)
                            {
                                strFileName = HIFAttchFinalTestPlan.PostedFile.FileName.Trim();
                            }
                            else
                            {
                                //strFileName = Strings.Right(HIFAttchFinalTestPlan.PostedFile.FileName.Trim(), Strings.Len(HIFAttchFinalTestPlan.PostedFile.FileName.Trim()) - intStripthePath);
                                strFileName = HIFAttchFinalTestPlan.PostedFile.FileName.Trim().Substring(intStripthePath + 1);
                                //strFileName = HIFAttchFinalTestPlan.PostedFile.FileName.Trim().Substring(intStripthePath + 1);
                            }
                            //strTestFile = Strings.LCase(strFileName);
                            strTestFile = strFileName.ToLower();

                            if (!string.IsNullOrEmpty(strFileName))
                            {
                                HIFAttchFinalTestPlan.PostedFile.InputStream.Read(bytContent, 0, Convert.ToInt32(HIFAttchFinalTestPlan.PostedFile.InputStream.Length));

                            }

                        }
                        catch (Exception ex)
                        {
                            //script = "<script>alert(" + ex.Message + ")</script>";
                            //Page.RegisterStartupScript("clientscript", script);

                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(" + ex.Message + ");", true);
                        }

                        if (!string.IsNullOrEmpty(strFileName))
                        {
                            if (bytContent.Length == 0)
                            {
                                fSize = 0;
                            }
                            else
                            {
                                fSize = bytContent.Length;
                            }


                            sContentType = HIFAttchFinalTestPlan.PostedFile.ContentType;
                            //jagan 13/01/2008 to change attachment file name
                            string strFinalFile = strFileName;

                            //intAttachResult = objGetAttachSiteTest.SubmitCommonAttachments(strFinalFile, bytContent, sContentType, objSiteTestBA1.EOID, sectionName);

                            if (objclsAttachmentsBA.SubmitCommonAttachments(strFinalFile, bytContent, sContentType, Convert.ToInt32(objSiteTestBA1.EOID), sectionName, ref paramOut))
                            {
                                intAttachResult = Convert.ToInt32(paramOut[0].Value);
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    string strErr = ex.Message;
                }
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string intDrpValue = null;
            DataSet dsBrand = null;
            DataSet dsEventdays = null;

            intDrpValue = ddlCategory.SelectedIndex.ToString();
            if (intDrpValue == "0")
            {
                lbEOBrandsDB.Items.Clear();
            }
            else
            {
                dsBrand = new DataSet();
                //dsBrand = ClsEO.FillListBoxWithBrands("GET_MUR_BRAND_Segment_By_Category", ddlCategory.SelectedValue);
                if (objEOBA.FillListBoxWithBrands(ddlCategory.SelectedItem.Value, ref dsBrand))
                {
                    if ((dsBrand != null))
                    {
                        if (!(dsBrand.Tables.Count == 0))
                        {
                            if (!(dsBrand.Tables[0].Rows.Count == 0))
                            {
                                lbEOBrandsDB.DataSource = dsBrand.Tables[0].DefaultView;
                                lbEOBrandsDB.DataTextField = "Brand_Segment_Name";
                                lbEOBrandsDB.DataValueField = "Brand_Segment_ID";
                                lbEOBrandsDB.DataBind();
                            }
                        }
                        else
                            return;
                    }
                    else
                        return;
                }
                else
                    return;

            }
            lblEoSelectedBrandDB.Text = string.Empty;
        }

        protected void lbEOBrandsDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEoSelectedBrandDB.Text = "";
            lblBrandIDList.Text = "";
            int intBrand = 0;
            for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
            {
                if (lbEOBrandsDB.Items[intBrand].Selected == true)
                {
                    if (string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
                    {
                        lblEoSelectedBrandDB.Text = lbEOBrandsDB.Items[intBrand].Text;
                    }
                    else
                    {
                        lblEoSelectedBrandDB.Text = lblEoSelectedBrandDB.Text + "," + lbEOBrandsDB.Items[intBrand].Text;
                    }
                }
            }
            for (intBrand = 0; intBrand <= lbEOBrandsDB.Items.Count - 1; intBrand++)
            {
                if (lbEOBrandsDB.Items[intBrand].Selected == true)
                {
                    if (string.IsNullOrEmpty(lblBrandIDList.Text))
                    {
                        lblBrandIDList.Text = lbEOBrandsDB.Items[intBrand].Value;
                    }
                    else
                    {
                        lblBrandIDList.Text = lblBrandIDList.Text + "," + lbEOBrandsDB.Items[intBrand].Value;
                    }
                }
            }

            //To fill Project dropdown based on category & Brand Segment selection 
            DataSet dsProj = new DataSet();
            int intCatID = 0;
            if (ddlCategory.SelectedItem.Text == "--Select a Category--")
            {
                intCatID = 0;
            }
            else
            {
                intCatID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            }
            //dsProj = objClsEO.GET_MUR_Projects_By_Category_Brand_Segment(intCatID, lblBrandIDList.Text);
            if (objEOBA.GET_MUR_Projects_By_Category_Brand_Segment(intCatID, lblBrandIDList.Text, ref dsProj))
            {
                ddlProject.DataSource = dsProj;
                ddlProject.DataTextField = "Project_Name";
                ddlProject.DataValueField = "Project_ID";
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, "--Select a Project--");
            }
        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbEOEventsDB.Items.Clear();
            FillListEvents();
        }

        //public void UpdateValuesForConvertLine()
        //{
        //    //Update values for convert line
        //    //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
        //    dsSiteTest = new DataSet();

        //    // dsSiteTest = objGetSiteTest.FillSiteTest(EoID);
        //    if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
        //    {
        //        //Starting Header
        //        if (dsSiteTest == null)
        //        {
        //        }
        //        else if (dsSiteTest.Tables.Count == 0)
        //        {
        //        }
        //        else if (dsSiteTest.Tables[6].Rows.Count == 0)
        //        {
        //        }
        //        else
        //        {
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Conv_Test_Coordinator"], System.DBNull.Value))
        //            {
        //                lblCoordinator.Text = "";
        //                objSiteTestBA1.ConvTestCoordinator = DBNull.Value.ToString();
        //            }
        //            else
        //            {
        //                lblCoordinator.Text = dsSiteTest.Tables[6].Rows[0]["Conv_Test_Coordinator"].ToString();
        //                objSiteTestBA1.ConvTestCoordinator = lblCoordinator.Text;
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Number_Of_Days"], System.DBNull.Value))
        //            {
        //                txtDays.Text = "";
        //                objSiteTestBA1.ConvNumberOfDays = 0.0;
        //            }
        //            else
        //            {
        //                txtDays.Text = dsSiteTest.Tables[6].Rows[0]["Number_Of_Days"].ToString();
        //                objSiteTestBA1.ConvNumberOfDays = Convert.ToDecimal(txtDays.Text);
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Preferred_Run_Dates"], System.DBNull.Value))
        //            {
        //                txtPreRunDates.Text = "";
        //                objSiteTestBA1.ConvPreferredRunDate = System.DateTime.MinValue;
        //            }
        //            else
        //            {
        //                System.DateTime d = dsSiteTest.Tables[6].Rows[0]["Preferred_Run_Dates"].ToString();
        //                txtPreRunDates.Text = d.Date.ToString();
        //                objSiteTestBA1.ConvPreferredRunDate = Convert.ToDateTime(txtPreRunDates.Text);
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Earliest_Run_Dates"], System.DBNull.Value))
        //            {
        //                txtEarlRunDates.Text = "";
        //                objSiteTestBA1.ConvEarliestRunDates = System.DateTime.MinValue;
        //            }
        //            else
        //            {
        //                System.DateTime d = dsSiteTest.Tables[6].Rows[0]["Earliest_Run_Dates"];
        //                txtEarlRunDates.Text = d.Date;
        //                objSiteTestBA1.ConvEarliestRunDates = Convert.ToDateTime(txtEarlRunDates.Text);
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Latest_Run_Dates"], System.DBNull.Value))
        //            {
        //                txtLRDates.Text = "";
        //                objSiteTestBA1.ConvLatestRunDates = System.DateTime.MinValue;
        //            }
        //            else
        //            {
        //                System.DateTime d = dsSiteTest.Tables[6].Rows[0]["Latest_Run_Dates"];
        //                txtLRDates.Text = d.Date;
        //                objSiteTestBA1.ConvLatestRunDates = Convert.ToDateTime(txtLRDates.Text);
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"], System.DBNull.Value))
        //            {
        //                rdCTPYes.Checked = false;
        //                rdCTPNo.Checked = false;
        //                objSiteTestBA1.ConvConsumerTestProduction = DBNull.Value.ToString();
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"].ToString() == "Y")
        //            {
        //                rdCTPYes.Checked = true;
        //                objSiteTestBA1.ConvConsumerTestProduction = "Y";
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Consumer_Test_Production"].ToString() == "N")
        //            {
        //                rdCTPNo.Checked = false;
        //                objSiteTestBA1.ConvConsumerTestProduction = "N";
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line"], System.DBNull.Value))
        //            {
        //                ddlPrefConline.SelectedIndex = 0;
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line"] == "0")
        //            {
        //                ddlPrefConline.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                ddlPrefConline.SelectedValue = dsSiteTest.Tables[6].Rows[0]["Equ_Preferred_Conv_Line"].ToString();
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line"], System.DBNull.Value))
        //            {
        //                ddlaltConvLine.SelectedIndex = 0;
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line"] == "0")
        //            {
        //                ddlaltConvLine.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                ddlaltConvLine.SelectedValue = dsSiteTest.Tables[6].Rows[0]["Equ_Alt_Conv_Line"].ToString();
        //            }
        //            //------------------------------------------------------------------------
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"], System.DBNull.Value))
        //            {
        //                ddlElSetup.SelectedIndex = 0;
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"] == "0")
        //            {
        //                ddlElSetup.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                ddlElSetup.SelectedValue = dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"].ToString();
        //                objSiteTestBA1.EquELSetup = Convert.ToInt32(dsSiteTest.Tables[6].Rows[0]["Equ_EL_Setup"]);
        //            }
        //            //----------------------------------------------------------------------------------

        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Emboss_Pattern"], System.DBNull.Value))
        //            {
        //                txtEquEmbossPattern.Text = "";
        //                objSiteTestBA1.EquEmbossPattern = "";

        //            }
        //            else
        //            {
        //                txtEquEmbossPattern.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Emboss_Pattern"].ToString();
        //                objSiteTestBA1.EquEmbossPattern = txtEquEmbossPattern.Text;
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"], System.DBNull.Value))
        //            {
        //                rbHotMeltYes.Checked = false;
        //                rbHotMeltNo.Checked = false;
        //                objSiteTestBA1.EquHotMelt = DBNull.Value.ToString();
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"].ToString() == "Y")
        //            {
        //                rbHotMeltYes.Checked = true;
        //                objSiteTestBA1.EquHotMelt = "Y";
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Hot_Melt"].ToString() == "N")
        //            {
        //                rbHotMeltNo.Checked = true;
        //                objSiteTestBA1.EquHotMelt = "N";
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"], System.DBNull.Value))
        //            {
        //                rbextrHeadsYes.Checked = false;
        //                rbextrHeadsNo.Checked = false;
        //                objSiteTestBA1.EquIsExtrusionHeads = DBNull.Value.ToString();
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"].ToString() == "Y")
        //            {
        //                rbextrHeadsYes.Checked = true;
        //                objSiteTestBA1.EquIsExtrusionHeads = "Y";
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Extrusion_Heads"].ToString() == "N")
        //            {
        //                rbextrHeadsNo.Checked = true;
        //                objSiteTestBA1.EquIsExtrusionHeads = "N";
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Extrusion_Heads_Count"], System.DBNull.Value))
        //            {
        //                txtExtrusionHeads.Text = "";
        //                objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(0.0);
        //            }
        //            else
        //            {
        //                txtExtrusionHeads.Text = dsSiteTest.Tables[6].Rows[0]["Equ_Extrusion_Heads_Count"].ToString();
        //                objSiteTestBA1.EquExtrusionHeadsCount = Convert.ToDecimal(txtExtrusionHeads.Text);

        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"], System.DBNull.Value))
        //            {
        //                rbHeadsHeatedYes.Checked = false;
        //                rbHeadsHeatedNo.Checked = false;
        //                objSiteTestBA1.EquIsHeadsHeated = DBNull.Value.ToString();
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"].ToString() == "Y")
        //            {
        //                rbHeadsHeatedYes.Checked = true;
        //                objSiteTestBA1.EquIsHeadsHeated = "Y";
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Heads_Heated"].ToString() == "N")
        //            {
        //                rbHeadsHeatedNo.Checked = true;
        //                objSiteTestBA1.EquIsHeadsHeated = "N";
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"], System.DBNull.Value))
        //            {
        //                rbStreamreqdYes.Checked = false;
        //                rbStreamreqdNo.Checked = false;

        //                objSiteTestBA1.EquIsStream = DBNull.Value.ToString();
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"].ToString() == "Y")
        //            {
        //                rbStreamreqdYes.Checked = true;
        //                objSiteTestBA1.EquIsStream = "Y";
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Equ_Is_Stream"].ToString() == "N")
        //            {
        //                rbStreamreqdNo.Checked = true;
        //                objSiteTestBA1.EquIsStream = "N";
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"], System.DBNull.Value))
        //            {
        //                rdInkYes.Checked = false;
        //                rdInkNo.Checked = false;
        //                objSiteTestBA1.MatIsStdProcessInk = DBNull.Value.ToString();
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"].ToString() == "Y")
        //            {
        //                rdInkYes.Checked = true;
        //                objSiteTestBA1.MatIsStdProcessInk = "Y";
        //            }
        //            else if (dsSiteTest.Tables[6].Rows[0]["Mat_Is_Std_Process_Ink"].ToString() == "N")
        //            {
        //                rdInkNo.Checked = true;
        //                objSiteTestBA1.MatIsStdProcessInk = "N";
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Yellow_Gallons"], System.DBNull.Value))
        //            {
        //                txtYellow.Text = "";
        //                objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(0.0);
        //            }
        //            else
        //            {
        //                txtYellow.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Yellow_Gallons"].ToString();
        //                objSiteTestBA1.MatYellowGallons = Convert.ToDecimal(txtYellow.Text);

        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Magenta_Gallons"], System.DBNull.Value))
        //            {
        //                txtMagneta.Text = "";
        //                objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(0.022);
        //            }
        //            else
        //            {
        //                txtMagneta.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Magenta_Gallons"].ToString();
        //                objSiteTestBA1.MatMagentaGallons = Convert.ToDecimal(txtMagneta.Text);

        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Cyan_Gallons"], System.DBNull.Value))
        //            {
        //                txtCyan.Text = "";
        //                objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(0.0);
        //            }
        //            else
        //            {
        //                txtCyan.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Cyan_Gallons"].ToString();
        //                objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(txtCyan.Text);
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"], System.DBNull.Value))
        //            {
        //                txtBlack.Text = "";
        //                objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(0.0);
        //            }
        //            else
        //            {
        //                txtBlack.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"].ToString();
        //                objSiteTestBA1.MatCyanGallons = Convert.ToDecimal(txtBlack.Text);

        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"], System.DBNull.Value))
        //            {
        //                txtBlack.Text = "";
        //                objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(0.0);
        //            }
        //            else
        //            {
        //                txtBlack.Text = dsSiteTest.Tables[6].Rows[0]["Mat_Black_Gallons"].ToString();
        //                objSiteTestBA1.MatBlackGallons = Convert.ToDecimal(txtBlack.Text);

        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Equipment"], System.DBNull.Value))
        //            {
        //                txtOtherEquipment.Text = "";
        //                objSiteTestBA1.ConvOtherEquipment = DBNull.Value.ToString();
        //            }
        //            else
        //            {
        //                txtOtherEquipment.Text = dsSiteTest.Tables[6].Rows[0]["Other_Equipment"].ToString();
        //                objSiteTestBA1.ConvOtherEquipment = txtOtherEquipment.Text;

        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Material"], System.DBNull.Value))
        //            {
        //                txtOtherMat.Text = "";
        //                objSiteTestBA1.ConvOtherMaterial = DBNull.Value.ToString();
        //            }
        //            else
        //            {
        //                txtOtherMat.Text = dsSiteTest.Tables[6].Rows[0]["Other_Material"].ToString();
        //                objSiteTestBA1.ConvOtherMaterial = txtOtherMat.Text;
        //            }
        //            if (object.ReferenceEquals(dsSiteTest.Tables[6].Rows[0]["Other_Other"], System.DBNull.Value))
        //            {
        //                txtOther.Text = "";
        //                objSiteTestBA1.ConvOtherOther = DBNull.Value.ToString();
        //            }
        //            else
        //            {
        //                txtOther.Text = dsSiteTest.Tables[6].Rows[0]["Other_Other"].ToString();
        //                objSiteTestBA1.ConvOtherOther = txtOther.Text;
        //            }
        //            objSiteTestBA1.ConvOtherUniqueReq = DBNull.Value.ToString();
        //            objSiteTestBA1.StMode = "C";
        //        }
        //    }
        //}

        protected void imgAddAttchFinalTestPlans_Click(object sender, ImageClickEventArgs e)
        {
            if ((Page.IsPostBack == true))
            {

                if (!string.IsNullOrEmpty(fTestPlan.Value))
                {
                    string strFullPostFileName = fTestPlan.PostedFile.FileName;
                    string strPostFileName = strFullPostFileName.Substring(strFullPostFileName.LastIndexOf("\\") + 1, (strFullPostFileName.Length - 1) - (strFullPostFileName.LastIndexOf("\\")));
                    string strTestFile = strPostFileName.ToLower();

                    if (strTestFile.EndsWith(".txt") || strTestFile.EndsWith(".doc") || strTestFile.EndsWith(".ppt") || strTestFile.EndsWith(".xls") || strTestFile.EndsWith(".docx") || strTestFile.EndsWith(".pptx") || strTestFile.EndsWith(".xlsx") || strTestFile.EndsWith(".pdf") || strTestFile.EndsWith(".htm") || strTestFile.EndsWith(".html"))
                    {
                        arTestPlans.Add(fTestPlan);
                        lbTestPlansAttach.Items.Add(strPostFileName);

                        //string Script = "<script>alert('Attachment will be inserted into the database after the Site Test is submitted')</script>";
                        //Page.RegisterStartupScript("clientscript", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Attachment will be inserted into the database after the Site Test is submitted');", true); 

                    }
                    else
                    {
                        //string Script = "<script>alert('Please Upload txt or doc or ppt or xls')</script>";
                        //Page.RegisterStartupScript("clientscript", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Upload txt or doc or ppt or xls');", true); 

                    }
                }
            }

        }

        protected void imgDelAttchFinalTestPlans_Click(object sender, ImageClickEventArgs e)
        {
            int rowCount = 0;
            string str = null;
            bool bolDeleted = false;
            str = "";
            for (rowCount = 0; rowCount <= lbTestPlansAttach.Items.Count - 1; rowCount++)
            {
                try
                {
                    if (lbTestPlansAttach.Items[rowCount].Selected == true)
                    {
                        bolDeleted = true;
                        if (string.IsNullOrEmpty(str))
                        {
                            str = lbTestPlansAttach.Items[rowCount].Value;
                        }
                        else
                        {
                            str = str + "," + lbTestPlansAttach.Items[rowCount].Value;
                        }
                        lbTestPlansAttach.Items.RemoveAt(rowCount);
                        arTestPlans.RemoveAt(rowCount);

                    }
                }
                catch (Exception ex)
                {
                }
            }
            string eid = string.Empty;
            if (ViewState["EID"] != null)
                eid = ViewState["EID"].ToString();
            try
            {
                int Eoid_Del = Convert.ToInt32(eid);
                //intAttachResult = objGetAttachSiteTest.DeleteCommonAttachments(str, Eoid_Del, "Test_Plan");

                if (objclsAttachmentsBA.DeleteCommonAttachments(str, Eoid_Del, "Test_Plan", ref paramOut))
                {
                    intAttachResult = Convert.ToInt32(paramOut[0].Value);
                }

            }
            catch (Exception ex)
            {
            }

            if (bolDeleted == true)
            {
                //string Script = "<script>alert('Attachment will be deleted from the database after the Site Test is submitted')</script>";
                //Page.RegisterStartupScript("clientscript", Script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Attachment will be deleted from the database after the Site Test is submitted');", true); 
            }
        }

        protected void imgAddAttchFinalOtherSup_Click(object sender, ImageClickEventArgs e)
        {
            if ((Page.IsPostBack == true))
            {
                if (!string.IsNullOrEmpty(fSuppDocs.Value))
                {
                    arFinal.Add(fSuppDocs);
                    string strFullPostFileName = fSuppDocs.PostedFile.FileName;
                    string strPostFileName = strFullPostFileName.Substring(strFullPostFileName.LastIndexOf("\\") + 1, (strFullPostFileName.Length - 1) - (strFullPostFileName.LastIndexOf("\\")));
                    lbSupDocAttach.Items.Add(strPostFileName);

                    //string Script = "<script>alert('Attachment will be inserted into the database after the Site Test is submitted')</script>";
                    //Page.RegisterStartupScript("clientscript", Script);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Attachment will be inserted into the database after the Site Test is submitted');", true); 
                }
            }
        }

        protected void imgDelAttchFinalOtherSup_Click(object sender, ImageClickEventArgs e)
        {
            int rowCount = 0;
            bool bolDeleted = false;
            string str = null;
            str = "";
            for (rowCount = 0; rowCount <= lbSupDocAttach.Items.Count - 1; rowCount++)
            {
                try
                {
                    if (lbSupDocAttach.Items[rowCount].Selected == true)
                    {
                        bolDeleted = true;
                        if (string.IsNullOrEmpty(str))
                        {
                            str = lbSupDocAttach.Items[rowCount].Value;
                        }
                        else
                        {
                            str = str + "," + lbSupDocAttach.Items[rowCount].Value;
                        }
                        lbSupDocAttach.Items.Remove(lbSupDocAttach.SelectedItem);
                        arFinal.RemoveAt(lbSupDocAttach.SelectedIndex);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            string eid = string.Empty;
            if (ViewState["EID"] != null)
                eid = ViewState["EID"].ToString();
            try
            {
                int Eoid_Del = Convert.ToInt32(eid);
                //intAttachResult = objGetAttachSiteTest.DeleteCommonAttachments(str, Eoid_Del, "Other_Supporting_Doc");

                if (objclsAttachmentsBA.DeleteCommonAttachments(str, Eoid_Del, "Other_Supporting_Doc", ref paramOut))
                {
                    intAttachResult = Convert.ToInt32(paramOut[0].Value);
                }
            }
            catch (Exception ex)
            {
            }
            if (bolDeleted == true)
            {
                //string Script = "<script>alert('Attachment will be deleted from the database after the Site Test is submitted')</script>";
                //Page.RegisterStartupScript("clientscript", Script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Attachment will be deleted from the database after the Site Test is submitted');", true); 
            }

        }

        protected void imgAddFinalReport_Click(object sender, ImageClickEventArgs e)
        {
            if ((Page.IsPostBack == true))
            {
                if (!string.IsNullOrEmpty(fFinalReport.Value))
                {
                    arFinalReport.Add(fFinalReport);
                    string strFullPostFileName = fFinalReport.PostedFile.FileName;
                    string strPostFileName = strFullPostFileName.Substring(strFullPostFileName.LastIndexOf("\\") + 1, (strFullPostFileName.Length - 1) - (strFullPostFileName.LastIndexOf("\\")));
                    lbFinalReportAttach.Items.Add(strPostFileName);
                    //string Script = "<script>alert('Attachment will be inserted into the database after the Site Test is submitted')</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Attachment will be inserted into the database after the Site Test is submitted');", true); 
                }

            }

        }

        protected void imgDelFinalReport_Click(object sender, ImageClickEventArgs e)
        {
            int rowCount = 0;
            string str = null;
            str = "";
            bool bolDeleted = false;

            for (rowCount = 0; rowCount <= lbFinalReportAttach.Items.Count - 1; rowCount++)
            {
                try
                {
                    if (lbFinalReportAttach.Items[rowCount].Selected == true)
                    {
                        bolDeleted = true;
                        if (string.IsNullOrEmpty(str))
                        {
                            str = lbFinalReportAttach.Items[rowCount].Value;
                        }
                        else
                        {
                            str = str + "," + lbFinalReportAttach.Items[rowCount].Value;
                        }
                        lbFinalReportAttach.Items.Remove(lbFinalReportAttach.SelectedItem);
                        arFinalReport.RemoveAt(lbFinalReportAttach.SelectedIndex);

                    }
                }
                catch (Exception ex)
                {
                }
            }
            string eid = ViewState["EID"].ToString();
            try
            {
                int Eoid_Del = Convert.ToInt32(eid);
                //intAttachResult = objGetAttachSiteTest.DeleteCommonAttachments(str, Eoid_Del, "Final_Report");
                if (objclsAttachmentsBA.DeleteCommonAttachments(str, Eoid_Del, "Final_Report", ref paramOut))
                {
                    intAttachResult = Convert.ToInt32(paramOut[0].Value);
                }

            }
            catch (Exception ex)
            {
            }

            if (bolDeleted == true)
            {
                //string Script = "<script>alert('Attachment will be deleted from the database after the Site Test is submitted')</script>";
                //Page.RegisterStartupScript("clientscript", Script);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Attachment will be deleted from the database after the Site Test is submitted');", true); 
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/Home.aspx");
        }

        protected void btnFYI_Click(object sender, ImageClickEventArgs e)
        {
            //string script = null;
            int intEoID = Convert.ToInt32(txthdnEoID.Text);
            //script = "<script>window.showModalDialog('FYI.aspx?oName=" + lblOriginator.Text + "&EOID=" + intEoID + "',null,'dialogHeight:200px;dialogWidth:520px');</script>";
            //Page.RegisterStartupScript("clientscript", script);
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "window.showModalDialog('FYI.aspx?oName=" + lblOriginator.Text + "&EOID=" + intEoID + "',null,'dialogHeight:200px;dialogWidth:520px');", true); 
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "window.open('FYI.aspx?EOID=" + intEoID + "&oName=" + lblOriginator.Text + "',null,'location=0,status=0,scrollbars=0,toolbar=0,menubar=0,resizable=0,width=500,height=180');", true);
        }

        protected void lnkSendconGrp_Click(object sender, EventArgs e)
        {
            string script = null;
            int intEoID = 0;
            intEoID = Convert.ToInt32(txthdnEoID.Text);
            objSiteTestBA1.UserName = objSecurity.UserName;
            int dlRowCount = 0;
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            objSiteTestBA1.UserName = objSecurity.UserName;
            dsSiteTest = new DataSet();
            //dsSiteTest = objGetSiteTest.FillSiteTest(intEoID);
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {
                if (dsSiteTest.Tables[12].Rows.Count == 0)
                {

                }
                else
                {
                    dlstConcGrp.Visible = true;
                    dlstConcGrp.DataSource = dsSiteTest.Tables[12];
                    dlstConcGrp.DataBind();
                    if (dlstConcGrp.Items.Count == 0)
                    {
                    }
                    else
                    {
                        dlstConcGrp.Visible = true;
                        string strRole = objSecurity.UserRole();
                        for (dlRowCount = 0; dlRowCount <= dlstConcGrp.Items.Count - 1; dlRowCount++)
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"], System.DBNull.Value))
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"].ToString() == "No Response")
                            {
                                if (objSiteTestBA1.UserName.ToUpper() == hdntxtPrjLead.Value.ToString().ToUpper() || objSiteTestBA1.UserName.ToUpper() == lblOriginator.Text.ToUpper() || strRole.ToUpper() == "MUREO_Admin".ToUpper())
                                {
                                    if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                    }
                                    else
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                    }
                                }
                                else if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                }
                                else
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                }

                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Approved")
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Declined")
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                            }
                        }
                    }
                }
            }
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetRev = new BusinessObject.MUREO.BusinessObject.SiteTest();
            dsSiteTest = new DataSet();

            int EId = Convert.ToInt32(txthdnEoID.Text);
            //dsSiteTest = objGetRev.FillSiteTest(EId);

            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {
                if (dsSiteTest == null)
                {

                }
                else if (dsSiteTest.Tables.Count == 0)
                {

                }
                else if (dsSiteTest.Tables[13].Rows.Count == 0)
                {
                }
                else
                {
                    dgrdRevHis.DataSource = dsSiteTest.Tables[13];
                    dgrdRevHis.DataBind();
                    dgrdRevHis.Visible = true;
                }
            }
            //submitting data
            if (!string.IsNullOrEmpty(txtStartDate.Text.ToString().Trim()) && !string.IsNullOrEmpty(txtEndDate.Text.ToString().Trim()))
            {
                System.DateTime strtDate = default(System.DateTime);
                System.DateTime endDate = default(System.DateTime);

                try
                {
                    //strtDate = Strings.Format(Convert.ToDateTime(txtStartDate.Text.Trim), "MM-dd-yyyy");
                    //strDateTime1 = String.Format("{0:MM-dd-yyyy_hh-mm-ss}", System.DateTime.Now);
                    strtDate = Convert.ToDateTime(String.Format("{0:MM-dd-yyyy}", Convert.ToDateTime(txtStartDate.Text.Trim().ToString())));
                    endDate = Convert.ToDateTime(String.Format("{0:MM-dd-yyyy}", Convert.ToDateTime(txtEndDate.Text.Trim().ToString())));

                    if (endDate < strtDate)
                    {
                        //script = "<script>alert('End Date should be greater than OR Equal to the Start Date');</script>";
                        //Page.RegisterStartupScript("clientscript", script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('End Date should be greater than OR Equal to the Start Date');", true); 
                        return;
                    }

                }
                catch (Exception ex)
                {
                }
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                //script = "<script>alert('Please Enter Title');document.getElementById('txtTitle').focus();</script> ";
                //Page.RegisterStartupScript("clientscript", script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Title');document.getElementById('txtTitle').focus();", true); 

                return;
            }

            //BusinessObject.MUREO.BusinessObject.SiteTest objAddsiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            //BusinessObject.MUREO.BusinessObject.SendConcurrence objAddSiteTestConcurrence = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
            Int32 x = default(Int32);
            string strName = "";
            strDateTime1 = String.Format("{0:MM-dd-yyyy_hh-mm-ss}", System.DateTime.Now);
            //For SetMandatory
            objSiteTestBA1.EOID = "0";
            objSiteTestBA1.StageStatus = ViewState["stageStatus"].ToString();
            if (objSiteTestBA1.StageStatus == null)
            {
                objSiteTestBA1.StageStatus = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                objSiteTestBA1.Title = txtTitle.Text;
            }
            else
            {
                objSiteTestBA1.Title = DBNull.Value.ToString();
            }

            //Evnets ListBox
            int intEvents = 0;
            string EventID = null;
            for (intEvents = 0; intEvents <= lbEOEventsDB.Items.Count - 1; intEvents++)
            {
                if (lbEOEventsDB.Items[intEvents].Selected == true)
                {
                    if (string.IsNullOrEmpty(EventID))
                    {
                        EventID = lbEOEventsDB.Items[intEvents].Value;
                    }
                    else
                    {
                        EventID = EventID + "," + lbEOEventsDB.Items[intEvents].Value;
                    }
                }
            }
            if (!string.IsNullOrEmpty(EventID))
            {
                objSiteTestBA1.EventIDs = EventID;
            }
            else
            {
                objSiteTestBA1.EventIDs = DBNull.Value.ToString();
            }

            //Project dropdown
            if (!(ddlProject.SelectedIndex == -1))
            {
                objSiteTestBA1.ProjectID = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.ProjectID = 0;
            }

            //Plant dropdown
            if (!(drpPlant.SelectedIndex == -1))
            {
                objSiteTestBA1.PlantID = Convert.ToInt32(drpPlant.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.PlantID = 0;
            }

            //Category dropdown
            if (!(ddlCategory.SelectedIndex == -1))
            {
                objSiteTestBA1.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.CategoryID = 0;
            }

            //Originator label
            if (!string.IsNullOrEmpty(lblOriginator.Text))
            {
                objSiteTestBA1.Originator = lblOriginator.Text;
            }
            else
            {
                objSiteTestBA1.Originator = DBNull.Value.ToString();
            }

            //Office Number
            if (!string.IsNullOrEmpty(txtOfficeNum.Text))
            {
                objSiteTestBA1.OfficeNumber = txtOfficeNum.Text;
            }
            else
            {
                objSiteTestBA1.OfficeNumber = DBNull.Value.ToString();
            }

            //PhNumber
            if (!string.IsNullOrEmpty(txtPhoneNum.Text))
            {
                objSiteTestBA1.PhoneNumber = txtPhoneNum.Text;
            }
            else
            {
                objSiteTestBA1.PhoneNumber = DBNull.Value.ToString();
            }

            //Brand Segment list

            if (!string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
            {
                objSiteTestBA1.Brands = lblBrandIDList.Text;
            }
            else
            {
                objSiteTestBA1.Brands = DBNull.Value.ToString();
            }

            //Coorginator
            if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
            {
                objSiteTestBA1.CoOrginator = hdntxtPrjLead.Value;
            }
            else
            {
                objSiteTestBA1.CoOrginator = DBNull.Value.ToString();
            }
            try
            {
                objSiteTestBA1.SiteTestID = Convert.ToInt32(txthdnSiteTestID.Text);

            }
            catch (Exception ex)
            {
            }
            Int32 intresSetEOMandatory = default(Int32);
            //To Get EO#
            if (Request.QueryString["From"].ToUpper() == "EDIT" | Request.QueryString["From"].ToUpper() == "EO")
            {
                objSiteTestBA1.EOID = txthdnEoID.Text.ToString().Trim();
                if (!(objSiteTestBA1.EOID == "0"))
                {
                    int s = 0;
                    //s = objAddsiteTest.SetEOMandatory(objSiteTestBA1);
                    if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                    {
                        s = Convert.ToInt32(paramOut[0].Value);
                    }
                }
                else
                {
                    //intresSetEOMandatory = objAddsiteTest.SetEOMandatory(objSiteTestBA1);
                    if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                    {
                        intresSetEOMandatory = Convert.ToInt32(paramOut[0].Value);
                        if (intresSetEOMandatory > 0)
                        {
                            objSiteTestBA1.EOID = intresSetEOMandatory.ToString();
                            txthdnEoID.Text = intresSetEOMandatory.ToString();
                        }
                    }

                }
                ViewState["EID"] = objSiteTestBA1.EOID;
            }
            else
            {
                //intresSetEOMandatory = objAddsiteTest.SetEOMandatory(objSiteTestBA1);
                if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                {
                    intresSetEOMandatory = Convert.ToInt32(paramOut[0].Value);
                    if (intresSetEOMandatory > 0)
                    {
                        objSiteTestBA1.EOID = intresSetEOMandatory.ToString();
                        txthdnEoID.Text = intresSetEOMandatory.ToString();
                        ViewState["EID"] = objSiteTestBA1.EOID;
                    }
                }


            }
            objSiteTestBA1.CommsntsToApprover = DBNull.Value.ToString();
            //End of SetMandatory
            if (txthdnPlantType.Text == "1")
            {
                FillStraightSiteTest();
                SetValuesForPlant();
                SetNullSForConvertLine();

            }
            else if (txthdnPlantType.Text == "2")
            {
                FillStraightSiteTest();
                SetValuesForConvertLine();
                SetNullSForPlant();

            }
            else if (txthdnPlantType.Text == "0")
            {
                //Call Straight Site Test (Making null for Plant,Convert)
                FillStraightSiteTest();
                SetNullSForPlant();
                SetNullSForConvertLine();
            }
            if (Request.QueryString["From"].ToUpper() == "EDIT")
            {
                string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                arTestPlans.Clear();
                FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                arFinal.Clear();
                FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                arFinalReport.Clear();
                //x = objAddsiteTest.UpdateSiteTest(objSiteTestBA1);
                if (objSiteTestBA.UpdateSiteTest(objSiteTestBA1, ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }
                if (x == 0)
                {
                }
                else
                {
                }
            }
            else
            {
                string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                arTestPlans.Clear();
                FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                arFinal.Clear();
                FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                arFinalReport.Clear();
                //x = objAddsiteTest.AddSiteTest(objSiteTestBA1);
                if (objSiteTestBA.UpdateSiteTest(objSiteTestBA1, ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }
                if (x == 0)
                {
                }
                else
                {
                }
            }

            txtStartDate.Text = Convert.ToDateTime(txtStartDate.Text).Date.ToShortDateString();
            txtEndDate.Text = Convert.ToDateTime(txtEndDate.Text).Date.ToShortDateString();

        }

        protected void dlstConcGrp_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Approval_Link")
            {
                Label lblApprName = (Label)e.Item.FindControl("lnkapprName");
                Label lblEoConAppID = (Label)e.Item.FindControl("lblConAppID");
                Label lblConGrpID = (Label)e.Item.FindControl("lblConAppGrpID");
                //string script = null;
                //script = "<script>concurenceConfirm('" + lblEoConAppID.Text + "','" + ViewState["EOID"] + "','Approved','" + lblConGrpID.Text + "','" + lblApprName.Text + "');</script> ";
                //Page.RegisterStartupScript("db_error_message", script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "concurenceConfirm('" + lblEoConAppID.Text + "','" + txthdnEoID.Text + "','Approved','" + lblConGrpID.Text + "','" + lblApprName.Text + "');", true);
            }
            if (e.CommandName == "Declined_Link")
            {
                LinkButton lnkApproval = (LinkButton)e.Item.FindControl("lnkApproval");
                LinkButton lnkDeclined = (LinkButton)e.Item.FindControl("lnkDeclined");
                Label lblApprName = (Label)e.Item.FindControl("lnkapprName");
                Label lblEoConAppID = (Label)e.Item.FindControl("lblConDecAppID");
                Label lblConGrpID = (Label)e.Item.FindControl("lblConDecGrpID");
                //string script = null;
                //script = "<script>concurenceConfirm('" + lblEoConAppID.Text + "','" + ViewState["EOID"] + "','Declined','" + lblConGrpID.Text + "','" + lblApprName.Text + "');</script> ";
                //Page.RegisterStartupScript("db_error_message", script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "concurenceConfirm('" + lblEoConAppID.Text + "','" + txthdnEoID.Text + "','Declined','" + lblConGrpID.Text + "','" + lblApprName.Text + "');", true);
            }



            //if (e.CommandName == "Approval_Link")
            //{
            //    LinkButton lnkApproval = (LinkButton)e.Item.FindControl("lnkApproval");
            //    LinkButton lnkDeclined = (LinkButton)e.Item.FindControl("lnkDeclined");
            //    objSiteTestBA1.IsResponded = "Approved";
            //    Label lblApprName = (Label)e.Item.FindControl("lnkapprName");
            //    objSiteTestBA1.ApprNameList = lblApprName.Text;
            //    Label lblEoConAppID = (Label)e.Item.FindControl("lblConAppID");
            //    objSiteTestBA1.ConAppID = Convert.ToInt32(lblEoConAppID.Text);
            //    Label lblConGrpID = (Label)e.Item.FindControl("lblConGrpID");
            //    objSiteTestBA1.ConGrpID = Convert.ToInt32(lblConGrpID.Text);
            //    objSiteTestBA1.EOID = txthdnEoID.Text;
            //    objSiteTestBA1.UserName = objSecurity.UserName;
            //    objSiteTestBA1.Comment = "";

            //    //string script = null;
            //    //script = "<script>concurenceConfirm('" + lblEoConAppID.Text + "','" + txthdnEoID.Text + "','Approved','" + lblConGrpID.Text + "','" + lblApprName.Text + "');</script> ";
            //    //Page.RegisterStartupScript("db_error_message", script);

            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "concurenceConfirm('" + lblEoConAppID.Text + "','" + txthdnEoID.Text + "','Approved','" + lblConGrpID.Text + "','" + lblApprName.Text + "');", true); 
            //}
            //if (e.CommandName == "Declined_Link")
            //{
            //    LinkButton lnkApproval = (LinkButton)e.Item.FindControl("lnkApproval");
            //    LinkButton lnkDeclined = (LinkButton)e.Item.FindControl("lnkDeclined");
            //    Label lblApprName = (Label)e.Item.FindControl("lnkapprName");
            //    objSiteTestBA1.ApprNameList = lblApprName.Text;
            //    Label lblEoConAppID = (Label)e.Item.FindControl("lblConAppID");
            //    Label lblConGrpID = (Label)e.Item.FindControl("lblConGrpID");
            //    objSiteTestBA1.ConAppID = Convert.ToInt32(lblEoConAppID.Text);
            //    objSiteTestBA1.ConGrpID = Convert.ToInt32(lblConGrpID.Text);
            //    objSiteTestBA1.EOID = txthdnEoID.Text;
            //    objSiteTestBA1.UserName = objSecurity.UserName;
            //    objSiteTestBA1.Comment = "";
            //    objSiteTestBA1.IsResponded = "Declined";
            //    //string script = null;
            //    //script = "<script>concurenceConfirm('" + lblEoConAppID.Text + "','" + txthdnEoID.Text + "','Declined','" + lblConGrpID.Text + "','" + lblApprName.Text + "');</script> ";
            //    //Page.RegisterStartupScript("db_error_message", script);

            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "concurenceConfirm('" + lblEoConAppID.Text + "','" + txthdnEoID.Text + "','Approved','" + lblConGrpID.Text + "','" + lblApprName.Text + "');", true); 
            //}
            if (e.CommandName == "Backup_Link")
            {
               
            }


        }

        protected void dgrdAttachment_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    //Opening Attachments by clicking on Attachment link
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblFullfname");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = string.Empty;
                    if (ViewState["EID"] != null)
                        EoiDString = ViewState["EID"].ToString();
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

        protected void dgrdSupAttach_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblSupFullfName");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = string.Empty;
                    if (ViewState["EID"] != null)
                        EoiDString = ViewState["EID"].ToString();
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

        protected void drpPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            txthdnPlantID.Text = drpPlant.SelectedItem.Value;

            if (txthdnPlantType.Text == "1" || txthdnPlantType.Text == "2")
            {
                if (!(drpPlant.SelectedItem.Text == "WHBC"))
                {
                    drpPlant.SelectedItem.Text = "--Select a Plant--";
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["SelectPlant"] + "');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["SelectPlant"] + "');", true); 
                }
            }
            else
            {
            }
        }

        protected void imgCloseOutThitSite_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (lbTestPlansAttach.Items.Count <= 0)
                {
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["TestPlansMsg"] + "');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["TestPlansMsg"] + "');", true); 
                    return;
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                if (lbFinalReportAttach.Items.Count <= 0)
                {
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["FinalReportMsg"] + "');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["FinalReportMsg"] + "');", true); 
                    return;
                }
            }
            catch (Exception ex)
            {
            }


            if (lbFinalReportAttach.Items.Count > 0)
            {
                ViewState["stageStatus"] = "Close-Out";
                if (ViewState["stageStatus"] != null)
                    objSiteTestBA1.StageStatus = ViewState["stageStatus"].ToString();
                //BusinessObject.MUREO.BusinessObject.SiteTest objAddsiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
                //BusinessObject.MUREO.BusinessObject.SendConcurrence objAddSiteTestConcurrence = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
                Int32 x = default(Int32);
                string strName = "";
                //For SetMandatory
                objSiteTestBA1.EOID = "0";
                if (!string.IsNullOrEmpty(txtTitle.Text))
                {
                    objSiteTestBA1.Title = txtTitle.Text;
                }
                else
                {
                    objSiteTestBA1.Title = DBNull.Value.ToString();
                }
                //Evnets ListBox
                int intEvents = 0;
                string EventID = null;
                for (intEvents = 0; intEvents <= lbEOEventsDB.Items.Count - 1; intEvents++)
                {
                    if (lbEOEventsDB.Items[intEvents].Selected == true)
                    {
                        if (string.IsNullOrEmpty(EventID))
                        {
                            EventID = lbEOEventsDB.Items[intEvents].Value;
                        }
                        else
                        {
                            EventID = EventID + "," + lbEOEventsDB.Items[intEvents].Value;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(EventID))
                {
                    objSiteTestBA1.EventIDs = EventID;
                }
                else
                {
                    objSiteTestBA1.EventIDs = DBNull.Value.ToString();
                }

                //Project dropdown
                if (!(ddlProject.SelectedIndex == -1))
                {
                    objSiteTestBA1.ProjectID = Convert.ToInt32(ddlProject.SelectedItem.Value);
                }
                else
                {
                    objSiteTestBA1.ProjectID = 0;
                }

                //Plant dropdown
                if (!(drpPlant.SelectedIndex == -1))
                {
                    objSiteTestBA1.PlantID = Convert.ToInt32(drpPlant.SelectedItem.Value);
                }
                else
                {
                    objSiteTestBA1.PlantID = 0;
                }

                //Category dropdown
                if (!(ddlCategory.SelectedIndex == -1))
                {
                    objSiteTestBA1.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                }
                else
                {
                    objSiteTestBA1.CategoryID = 0;
                }

                //Originator label
                if (!string.IsNullOrEmpty(lblOriginator.Text))
                {
                    objSiteTestBA1.Originator = lblOriginator.Text;
                }
                else
                {
                    objSiteTestBA1.Originator = DBNull.Value.ToString();
                }

                if (!string.IsNullOrEmpty(txtOfficeNum.Text))
                {
                    objSiteTestBA1.OfficeNumber = txtOfficeNum.Text;
                }
                else
                {
                    objSiteTestBA1.OfficeNumber = DBNull.Value.ToString();
                }

                //PhNumber
                if (!string.IsNullOrEmpty(txtPhoneNum.Text))
                {
                    objSiteTestBA1.PhoneNumber = txtPhoneNum.Text;
                }
                else
                {
                    objSiteTestBA1.PhoneNumber = DBNull.Value.ToString();
                }

                //Brand Segment list

                if (!string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
                {
                    objSiteTestBA1.Brands = lblBrandIDList.Text;
                }
                else
                {
                    objSiteTestBA1.Brands = DBNull.Value.ToString();
                }

                //Coorginator
                if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
                {
                    objSiteTestBA1.CoOrginator = hdntxtPrjLead.Value;
                }
                else
                {
                    objSiteTestBA1.CoOrginator = DBNull.Value.ToString();
                }
                Int32 intresSetEOMandatory = default(Int32);

                //To Get EO#

                if (Request.QueryString["From"] != null && Request.QueryString["From"].ToUpper() == "EDIT")
                {
                    objSiteTestBA1.EOID = txthdnEoID.Text.ToString();
                    int s = 0;
                    //s = objAddsiteTest.SetEOMandatory(objSiteTest);
                    if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                    {
                        s = Convert.ToInt32(paramOut[0].Value);
                    }
                }
                else
                {
                    //intresSetEOMandatory = objAddsiteTest.SetEOMandatory(objSiteTest);
                    if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                    {
                        intresSetEOMandatory = Convert.ToInt32(paramOut[0].Value);
                    }
                    if (intresSetEOMandatory > 0)
                    {
                        objSiteTestBA1.EOID = intresSetEOMandatory.ToString();
                        txthdnEoID.Text = intresSetEOMandatory.ToString();
                    }
                }
                objSiteTestBA1.CommsntsToApprover = DBNull.Value.ToString();

                objSiteTestBA1.SiteTestID = Convert.ToInt32(txthdnSiteTestID.Text);
                //End of SetMandatory
                if (txthdnPlantType.Text == "1")
                {
                    FillStraightSiteTest();
                    SetValuesForPlant();
                    SetNullSForConvertLine();

                }
                else if (txthdnPlantType.Text == "2")
                {
                    FillStraightSiteTest();
                    SetValuesForConvertLine();
                    SetNullSForPlant();

                }
                else if (txthdnPlantType.Text == "0")
                {
                    //Call Straight Site Test (Making null for Plant,Convert)

                    FillStraightSiteTest();
                    SetNullSForPlant();
                    SetNullSForConvertLine();
                }

                if (Request.QueryString["From"] != null && Request.QueryString["From"].ToUpper() == "EDIT")
                {
                    string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                    FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                    arTestPlans.Clear();
                    FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                    arFinal.Clear();
                    FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                    arFinalReport.Clear();
                    //x = objAddsiteTest.UpdateSiteTest(objSiteTest);
                    if (objSiteTestBA.UpdateSiteTest(objSiteTestBA1, ref paramOut))
                    {
                        x = Convert.ToInt32(paramOut[0].Value);
                    }
                    if (x == 0)
                    {
                        //Script = "<script>alert('" + ConfigurationSettings.AppSettings["StUpdateSuccess"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["StUpdateSuccess"] + "');window.location='../Reports/MYEOs.aspx';", true); 
                    }
                    else
                    {
                        //Script = "<script>alert('" + ConfigurationSettings.AppSettings["UpdateError"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", Script);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["UpdateError"] + "');window.location='../Reports/MYEOs.aspx';", true); 
                    }
                }
                else
                {
                    string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                    FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                    arTestPlans.Clear();
                    FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                    arFinal.Clear();
                    FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                    arFinalReport.Clear();
                    //x = objAddsiteTest.AddSiteTest(objSiteTest);
                    if (objSiteTestBA.UpdateSiteTest(objSiteTestBA1, ref paramOut))
                    {
                        x = Convert.ToInt32(paramOut[0].Value);
                    }
                    if (x == 0)
                    {
                        //Script = "<script>alert('Record updated successfully');window.navigate('../Reports/MYEOs.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Record updated successfully');window.location='../Reports/MYEOs.aspx';", true); 

                    }
                    else
                    {
                        //Script = "<script>alert('" + ConfigurationSettings.AppSettings["InsertError"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", Script);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["InsertError"] + "');window.location='../Reports/MYEOs.aspx';", true); 
                    }
                }
            }
            else
            {
                //Script = "<script>alert('" + ConfigurationSettings.AppSettings["SelectFinalReprt"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                //Page.RegisterStartupScript("clientscript", Script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["SelectFinalReprt"] + "');window.location='../Reports/MYEOs.aspx';", true); 
            }

        }

        protected void imgAdminCloseOut_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["stageStatus"] = "Admin Close-Out";
            if(ViewState["stageStatus"] != null)
            objSiteTestBA1.StageStatus = ViewState["stageStatus"].ToString();
            //BusinessObject.MUREO.BusinessObject.SiteTest objAddsiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            //BusinessObject.MUREO.BusinessObject.SendConcurrence objAddSiteTestConcurrence = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
            Int32 x = default(Int32);
            string strName = null;
            //For SetMandatory
            objSiteTestBA1.EOID = "0";
            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                objSiteTestBA1.Title = txtTitle.Text;
            }
            else
            {
                objSiteTestBA1.Title = DBNull.Value.ToString();
            }

            //Evnets ListBox
            int intEvents = 0;
            string EventID = null;
            for (intEvents = 0; intEvents <= lbEOEventsDB.Items.Count - 1; intEvents++)
            {
                if (lbEOEventsDB.Items[intEvents].Selected == true)
                {
                    if (string.IsNullOrEmpty(EventID))
                    {
                        EventID = lbEOEventsDB.Items[intEvents].Value;
                    }
                    else
                    {
                        EventID = EventID + "," + lbEOEventsDB.Items[intEvents].Value;
                    }
                }
            }
            if (!string.IsNullOrEmpty(EventID))
            {
                objSiteTestBA1.EventIDs = EventID;
            }
            else
            {
                objSiteTestBA1.EventIDs = DBNull.Value.ToString();
            }

            //Project dropdown
            if (!(ddlProject.SelectedIndex == -1))
            {
                objSiteTestBA1.ProjectID = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.ProjectID = 0;
            }

            //Plant dropdown
            if (!(drpPlant.SelectedIndex == -1))
            {
                objSiteTestBA1.PlantID = Convert.ToInt32(drpPlant.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.PlantID = 0;
            }

            //Category dropdown
            if (!(ddlCategory.SelectedIndex == -1))
            {
                objSiteTestBA1.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.CategoryID = 0;
            }

            //Originator label
            if (!string.IsNullOrEmpty(lblOriginator.Text))
            {
                objSiteTestBA1.Originator = lblOriginator.Text;
            }
            else
            {
                objSiteTestBA1.Originator = DBNull.Value.ToString();
            }
            //Office Number
            if (!string.IsNullOrEmpty(txtOfficeNum.Text))
            {
                objSiteTestBA1.OfficeNumber = txtOfficeNum.Text;
            }
            else
            {
                objSiteTestBA1.OfficeNumber = DBNull.Value.ToString();
            }

            //PhNumber
            if (!string.IsNullOrEmpty(txtPhoneNum.Text))
            {
                objSiteTestBA1.PhoneNumber = txtPhoneNum.Text;
            }
            else
            {
                objSiteTestBA1.PhoneNumber = DBNull.Value.ToString();
            }

            //Brand Segment list

            if (!string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
            {
                objSiteTestBA1.Brands = lblBrandIDList.Text;
            }
            else
            {
                objSiteTestBA1.Brands = DBNull.Value.ToString();
            }

            //Coorginator
            if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
            {
                objSiteTestBA1.CoOrginator = hdntxtPrjLead.Value;
            }
            else
            {
                objSiteTestBA1.CoOrginator = DBNull.Value.ToString();
            }
            Int32 intresSetEOMandatory = default(Int32);
            //To Get EO#
            if (Request.QueryString["From"] != null && Request.QueryString["From"].ToUpper() == "EDIT")
            {
                objSiteTestBA1.EOID = txthdnEoID.Text.ToString();
                int s = 0;
                //s = objAddsiteTest.SetEOMandatory(objSiteTest);

                if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                {
                    s = Convert.ToInt32(paramOut[0].Value);
                }
            }
            else
            {
                //intresSetEOMandatory = objAddsiteTest.SetEOMandatory(objSiteTest);

                if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                {
                    intresSetEOMandatory = Convert.ToInt32(paramOut[0].Value);
                    if (intresSetEOMandatory > 0)
                    {
                        objSiteTestBA1.EOID = intresSetEOMandatory.ToString();
                        txthdnEoID.Text = intresSetEOMandatory.ToString();
                    }
                }
               
            }
            objSiteTestBA1.CommsntsToApprover = DBNull.Value.ToString();
            //End of SetMandatory
            if (txthdnPlantType.Text == "1")
            {
                FillStraightSiteTest();
                SetValuesForPlant();
                SetNullSForConvertLine();

            }
            else if (txthdnPlantType.Text == "2")
            {
                FillStraightSiteTest();
                SetValuesForConvertLine();
                SetNullSForPlant();

            }
            else if (txthdnPlantType.Text == "0")
            {
                //Call Straight Site Test (Making null for Plant,Convert)
                FillStraightSiteTest();
                SetNullSForPlant();
                SetNullSForConvertLine();
            }

            objSiteTestBA1.SiteTestID = Convert.ToInt32(txthdnSiteTestID.Text);
            if (Request.QueryString["From"] != null && Request.QueryString["From"].ToUpper() == "EDIT")
            {
                string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                arTestPlans.Clear();
                FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                arFinal.Clear();
                FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                arFinalReport.Clear();
                //x = objAddsiteTest.UpdateSiteTest(objSiteTest);
                if (objSiteTestBA.UpdateSiteTest(objSiteTestBA1, ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }
                if (x == 0)
                {
                    //Script = "<script>alert('Record updated successfully');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Record updated successfully');window.location='../Reports/MYEOs.aspx';", true);
                }
                else
                {
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["UpdateError"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["UpdateError"] + "');window.location='../Reports/MYEOs.aspx';", true);
                }
            }
            else
            {
                string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                arTestPlans.Clear();
                FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                arFinal.Clear();
                FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                arFinalReport.Clear();
                //x = objAddsiteTest.AddSiteTest(objSiteTest);
                if (objSiteTestBA.AddSiteTest(objSiteTestBA1, ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }
                if (x == 0)
                {
                    //Script = "<script>alert('Record updated successfully');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Record updated successfully');window.location='../Reports/MYEOs.aspx';", true);
                }
                else
                {
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["InsertError"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["InsertError"] + "');window.location='../Reports/MYEOs.aspx';", true);
                }
            }

        }

        protected void imgTplanTemp_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "..\\Common\\Templates\\EO Test Plan template 030703.doc";
            Response.AddHeader("Content-Disposition", "attachment;filename=EO Test Plan template 030703.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void imgBounTestReq_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Bounty FP Lab test request.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=Bounty FP Lab test request.xls");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void imgExTestPlan_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Test Plan example.doc";
            Response.AddHeader("Content-Disposition", "attachment;filename=Test Plan example.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void imgCharTeReq_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Charmin FP Lab test request.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=Charmin FP Lab test request.xls");
            Response.TransmitFile(strPath);
            Response.End();

        }

        protected void imgFinRepTemp_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Final report template.doc";
            Response.AddHeader("Content-Disposition", "attachment;filename=Final report template.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void imgPapMakLabReq_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Papermaking lab request form.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=Papermaking lab request form.xls");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void imgExFinRep_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Final report example.doc";
            Response.AddHeader("Content-Disposition", "attachment;filename=Final report example.doc");
            Response.TransmitFile(strPath);
            Response.End();

        }

        protected void imgTesRequ_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Ultra Soft test request form.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=Ultra Soft test request form.xls");
            Response.TransmitFile(strPath);
            Response.End();

        }

        protected void imgNapTeReq_Click(object sender, ImageClickEventArgs e)
        {
            string strPath = "../Common/Templates/Napkins FP Lab test request.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=Napkins FP Lab test request.xls");
            Response.TransmitFile(strPath);
            Response.End();

        }

        protected void dlstConcGrp_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblOrigAppr = (Label)e.Item.FindControl("lblapprName");
                Label lblConAppID = (Label)e.Item.FindControl("lblConAppID");
                LinkButton lnkBakUp = (LinkButton)e.Item.FindControl("lnkBackUp");
                lnkBakUp.Attributes.Add("onclick", "javascript:return AddBooksingUserForBakUp(this);");
                lnkBakUp.Attributes.Add("hdnApprClientID", hdnApprover.ClientID);
                //lnkBakUp.Attributes.Add("hdnConAppID", hdnConAppID.ClientID);
                //lnkBakUp.Attributes.Add("hdnOrigAppr", hdnOrigAppr.ClientID);
                lnkBakUp.Attributes.Add("lblConAppID", lblConAppID.Text);
                lnkBakUp.Attributes.Add("lblOrigAppr", lblOrigAppr.Text);
                lnkBakUp.Attributes.Add("btnApp", btnApp.ClientID);

                //Script = "<script>document.getElementById('t11').value = window.showModalDialog('ShowUser.aspx?from=CheckingUser');</script>"
                //Page.RegisterStartupScript("clientscript", Script)
            }
        }

        protected void rbKarliYes_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //ds = objGetSiteTest.GetMessage(2);
            if (objSiteTestBA.GetMessage(2, ref ds))
            {
                if ((ds != null))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string messsage = null;
                        messsage = ds.Tables[0].Rows[0]["Key_Value"].ToString();
                        //Script = "<script>alert('" + messsage + "');</script>";
                        //Page.RegisterStartupScript("clientscript1", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messsage + "');", true);
                    }
                }
            }
        }

        protected void rbPPMModelsNo_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //ds = objGetSiteTest.GetMessage(1);
            if (objSiteTestBA.GetMessage(1, ref ds))
            {
                if ((ds != null))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string messsage = null;
                        messsage = ds.Tables[0].Rows[0]["Key_Value"].ToString();
                        //Script = "<script>alert('" + messsage + "');</script>";
                        //Page.RegisterStartupScript("clientscript2", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messsage + "');", true);
                    }
                }
            }

        }

        protected void rdCPNYes_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //ds = objGetSiteTest.GetMessage(3);
            if (objSiteTestBA.GetMessage(3, ref ds))
            {
                if ((ds != null))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string messsage = null;
                        messsage = ds.Tables[0].Rows[0]["Key_Value"].ToString();
                        //Script = "<script>alert('" + messsage + "');</script>";
                        //Page.RegisterStartupScript("clientscript3", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messsage + "');", true);
                    }
                }
            }

        }

        protected void lnkinfoPPM_Click(object sender, EventArgs e)
        {
            string strPath = "..\\Common\\Templates\\Initial PPM set up sheet - first cond_061201.pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=Initial PPM set up sheet - first cond_061201.pdf");
            Response.TransmitFile(strPath);
            Response.End();

        }

        protected void lnkinfoconv_Click(object sender, EventArgs e)
        {
            string strPath = "..\\Common\\Templates\\PCL Equipement checklist_061101.xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=PCL Equipement checklist_061101.xls");
            Response.TransmitFile(strPath);
            Response.End();

        }

        protected void dgrdTestPlan_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Final_Click")
            {
                try
                {
                    //Opening Attachments by clicking on Attachment link
                    Label lblEoConAppID = (Label)e.Item.FindControl("lblattachID");
                    int intAttachmentId = Convert.ToInt32(lblEoConAppID.Text);
                    string EoiDString = string.Empty;
                        if(ViewState["EID"] != null)
                            EoiDString = ViewState["EID"].ToString();
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


                                //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
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

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtStartDate.Text.ToString().Trim()) && !string.IsNullOrEmpty(txtEndDate.Text.ToString().Trim()))
            {
                System.DateTime strtDate = default(System.DateTime);
                System.DateTime endDate = default(System.DateTime);

                try
                {
                    //strtDate = Strings.Format(Convert.ToDateTime(txtStartDate.Text.Trim), "MM-dd-yyyy");
                    strtDate = Convert.ToDateTime(String.Format("{0:MM-dd-yyyy_hh-mm-ss}", txtStartDate.Text));
                    endDate = Convert.ToDateTime(String.Format("{0:MM-dd-yyyy_hh-mm-ss}", txtEndDate.Text));
                    //endDate = Strings.Format(Convert.ToDateTime(txtEndDate.Text.Trim), "MM-dd-yyyy");

                    if (endDate < strtDate)
                    {
                        //Script = "<script>alert('End Date should be greater than OR Equal to the Start Date');</script>";
                        //Page.RegisterStartupScript("clientscript", Script);

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('End Date should be greater than OR Equal to the Start Date.');", true);

                        return;
                    }

                }
                catch (Exception ex)
                {
                }
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                //Script = "<script>alert('Please Enter Title');document.getElementById('txtTitle').focus();</script> ";
                //Page.RegisterStartupScript("clientscript", Script);

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Title');document.getElementById('txtTitle').focus();", true);

                return;
            }

            //BusinessObject.MUREO.BusinessObject.SiteTest objAddsiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            //BusinessObject.MUREO.BusinessObject.SendConcurrence objAddSiteTestConcurrence = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
            Int32 x = default(Int32);
            string strName = null;
            //strDateTime1 = Strings.Format(System.DateTime.Now, "MM-dd-yyyy_hh-mm-ss");
            strDateTime1 = String.Format("{0:MM-dd-yyyy_hh-mm-ss}", System.DateTime.Now);
            //For SetMandatory
            objSiteTestBA1.EOID = "0";
            objSiteTestBA1.StageStatus = ViewState["stageStatus"].ToString();
            if (objSiteTestBA1.StageStatus == null)
            {
                objSiteTestBA1.StageStatus = DBNull.Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                objSiteTestBA1.Title = txtTitle.Text;
            }
            else
            {
                objSiteTestBA1.Title = DBNull.Value.ToString();
            }
            try
            {
                objSiteTestBA1.SiteTestID = Convert.ToInt32(txthdnSiteTestID.Text);

            }
            catch (Exception ex)
            {
            }
            //Evnets ListBox
            int intEvents = 0;
            string EventID = null;
            for (intEvents = 0; intEvents <= lbEOEventsDB.Items.Count - 1; intEvents++)
            {
                if (lbEOEventsDB.Items[intEvents].Selected == true)
                {
                    if (string.IsNullOrEmpty(EventID))
                    {
                        EventID = lbEOEventsDB.Items[intEvents].Value;
                    }
                    else
                    {
                        EventID = EventID + "," + lbEOEventsDB.Items[intEvents].Value;
                    }
                }
            }
            if (!string.IsNullOrEmpty(EventID))
            {
                objSiteTestBA1.EventIDs = EventID;
            }
            else
            {
                objSiteTestBA1.EventIDs = DBNull.Value.ToString();
            }

            //Project dropdown
            if (!(ddlProject.SelectedIndex == -1))
            {
                objSiteTestBA1.ProjectID = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.ProjectID = 0;
            }

            //Plant dropdown
            if (!(drpPlant.SelectedIndex == -1))
            {
                objSiteTestBA1.PlantID = Convert.ToInt32(drpPlant.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.PlantID = 0;
            }

            //Category dropdown
            if (!(ddlCategory.SelectedIndex == -1))
            {
                objSiteTestBA1.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            }
            else
            {
                objSiteTestBA1.CategoryID = 0;
            }

            //Originator label
            if (!string.IsNullOrEmpty(lblOriginator.Text))
            {
                objSiteTestBA1.Originator = lblOriginator.Text;
            }
            else
            {
                objSiteTestBA1.Originator = DBNull.Value.ToString();
            }

            //Office Number
            if (!string.IsNullOrEmpty(txtOfficeNum.Text))
            {
                objSiteTestBA1.OfficeNumber = txtOfficeNum.Text;
            }
            else
            {
                objSiteTestBA1.OfficeNumber = DBNull.Value.ToString();
            }

            //PhNumber
            if (!string.IsNullOrEmpty(txtPhoneNum.Text))
            {
                objSiteTestBA1.PhoneNumber = txtPhoneNum.Text;
            }
            else
            {
                objSiteTestBA1.PhoneNumber = DBNull.Value.ToString();
            }

            //Brand Segment list

            if (!string.IsNullOrEmpty(lblEoSelectedBrandDB.Text))
            {
                objSiteTestBA1.Brands = lblBrandIDList.Text;
            }
            else
            {
                objSiteTestBA1.Brands = DBNull.Value.ToString();
            }



            //Coorginator
            if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
            {
                objSiteTestBA1.CoOrginator = hdntxtPrjLead.Value;
                txtCoOriginator.Text = hdntxtPrjLead.Value;
            }
            else
            {
                objSiteTestBA1.CoOrginator = DBNull.Value.ToString();
                txtCoOriginator.Text = string.Empty;
            }


            Int32 intresSetEOMandatory = default(Int32);


            //To Get EO#

            if (Request.QueryString["From"].ToUpper() == "EDIT" | Request.QueryString["From"].ToUpper() == "EO")
            {
                objSiteTestBA1.EOID = txthdnEoID.Text.ToString();
                if (!(objSiteTestBA1.EOID == "0"))
                {
                    int s = 0;
                    //s = objAddsiteTest.SetEOMandatory(objSiteTest);
                    if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                    {
                        s = Convert.ToInt32(paramOut[0].Value);
                    }
                }
                else
                {
                    //intresSetEOMandatory = objAddsiteTest.SetEOMandatory(objSiteTest);
                    if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                    {
                        intresSetEOMandatory = Convert.ToInt32(paramOut[0].Value);
                        if (intresSetEOMandatory > 0)
                        {
                            objSiteTestBA1.EOID = intresSetEOMandatory.ToString();
                            txthdnEoID.Text = intresSetEOMandatory.ToString();
                        }
                    }
                }
                ViewState["EID"] = objSiteTestBA1.EOID;

            }
            else
            {
                if (objSiteTestBA.SetEOMandatory(objSiteTestBA1, ref paramOut))
                {
                    intresSetEOMandatory = Convert.ToInt32(paramOut[0].Value);
                    if (intresSetEOMandatory > 0)
                    {
                        objSiteTestBA1.EOID = intresSetEOMandatory.ToString();
                        txthdnEoID.Text = intresSetEOMandatory.ToString();
                        ViewState["EID"] = objSiteTestBA1.EOID;
                    }
                }

                //intresSetEOMandatory = objAddsiteTest.SetEOMandatory(objSiteTest);
                //if (intresSetEOMandatory > 0)
                //{
                //    objSiteTestBA1.EOID = intresSetEOMandatory;
                //    txthdnEoID.Text = intresSetEOMandatory;
                //    ViewState["EID"] = objSiteTestBA1.EOID;
                //}

            }
            objSiteTestBA1.CommsntsToApprover = DBNull.Value.ToString();
            //End of SetMandatory
            if (txthdnPlantType.Text == "1")
            {
                FillStraightSiteTest();
                SetValuesForPlant();
                SetNullSForConvertLine();

            }
            else if (txthdnPlantType.Text == "2")
            {
                FillStraightSiteTest();
                SetValuesForConvertLine();
                SetNullSForPlant();

            }
            else if (txthdnPlantType.Text == "0")
            {
                //Call Straight Site Test (Making null for Plant,Convert)
                FillStraightSiteTest();
                SetNullSForPlant();
                SetNullSForConvertLine();
            }
            if (Request.QueryString["From"].ToUpper() == "EDIT")
            {
                FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                arTestPlans.Clear();
                FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                arFinal.Clear();
                FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                arFinalReport.Clear();

                //x = objAddsiteTest.UpdateSiteTest(objSiteTest);
                if (objSiteTestBA.UpdateSiteTest(objSiteTestBA1, ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }
                if (x == 0)
                {
                    //Script = "<script>alert('Record updated successfully');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Record updated successfully.');window.location='../Reports/MYEOs.aspx';", true);
                }
                else
                {
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["UpdateError"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["UpdateError"] + "');window.location='../Reports/MYEOs.aspx';", true);

                }
            }
            else
            {
                string strbaseLocation = Server.MapPath("..") + "\\Common\\Upload\\SiteTest\\";
                FilesUpload(lbTestPlansAttach, arTestPlans, "Test_Plan");
                arTestPlans.Clear();
                FilesUpload(lbSupDocAttach, arFinal, "Other_Supporting_Doc");
                arFinal.Clear();
                FilesUpload(lbFinalReportAttach, arFinalReport, "Final_Report");
                arFinalReport.Clear();
                //x = objAddsiteTest.AddSiteTest(objSiteTestBA1);
                if (objSiteTestBA.AddSiteTest(objSiteTestBA1, ref paramOut))
                {
                    x = Convert.ToInt32(paramOut[0].Value);
                }

                if (x == 0)
                {
                    //Script = "<script>alert('Record updated successfully');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Record updated successfully.');window.location='../Reports/MYEOs.aspx';", true);
                }
                else
                {
                    //Script = "<script>alert('" + ConfigurationSettings.AppSettings["InsertError"] + "');window.navigate('../Reports/MYEOs.aspx');</script>";
                    //Page.RegisterStartupScript("clientscript", Script);

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ConfigurationSettings.AppSettings["InsertError"] + "');window.location='../Reports/MYEOs.aspx';", true);
                }
            }

        }

        protected void btnConApp_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string script1 = string.Empty;
            script1 = "window.location.href = '" + url + "';";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script1, true);
        }

        protected void btnApp_Click(object sender, EventArgs e)
        {
            //Label lblEoConAppID = (Label)e.Item.FindControl("lblConAppID");
            //Label lblConGrpID = (Label)e.Item.FindControl("lblConGrpID");
            //Label lblOriginalApprName = (Label)e.Item.FindControl("lblapprName");
            //objSiteTestBA1.ConAppID = Convert.ToInt32(lblEoConAppID.Text);
            //objSiteTestBA1.ConGrpID = Convert.ToInt32(lblConGrpID.Text);
            //objSiteTestBA1.EOID = txthdnEoID.Text;
            //string BackUpApprover = hdnApprover.Text;
            //string origApprover = lblOriginalApprName.Text;
            //string BkUpApprover = BackUpApprover;

          
            //BusinessObject.MUREO.BusinessObject.SendConcurrence objAddSiteTestConcurrence = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
            //objAddSiteTestConcurrence.AddBackUpApprover(objSiteTestBA1.ConAppID, BackUpApprover);

            string origApprover = hdnOrigAppr.Value;
            string BkUpApprover = hdnApprover.Text;
            int conAppID = Convert.ToInt32(hdnConAppID.Value);
            string BackUpApprover = hdnApprover.Text;
            if (!string.IsNullOrEmpty(hdnApprover.Text))
            {
                objEOBA.AddBackUpApprover(conAppID, BackUpApprover);
                //BusinessObject.MUREO.BusinessObject.SendConcurrence objAddSiteTestConcurrence = new BusinessObject.MUREO.BusinessObject.SendConcurrence();
                //objAddSiteTestConcurrence.AddBackUpApprover;
            }
            else
            {
                return;
            }
         
            try
            {
                int i = 0;
                i = origApprover.IndexOf(" ");
                origApprover = origApprover.Substring(i);
                origApprover = origApprover.Replace("-", ".");
                origApprover = origApprover.Replace(" ", "");
                i = BkUpApprover.IndexOf(" ");
                BkUpApprover = BkUpApprover.Substring(i);
                BkUpApprover = BkUpApprover.Replace("-", ".");
                BkUpApprover = BkUpApprover.Replace(" ", "");
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

            string SendersList = null;
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

            try
            {
                if (!string.IsNullOrEmpty(hdnApprover.Text))
                {
                    SendersList = BkUpApprover + "@pg.com";

                    clsSendMail objSendMail = new clsSendMail();
                    objSendMail.SendTo = SendersList;
                    string strURL = null;
                    strURL = "http://" + ViewState["servername"] + "/Common/Sitetest.aspx?From=EDIT&EoID=" + Request.QueryString["EoID"].ToString().Trim();
                    string strLockURL = "http://" + ViewState["servername"] + "/Common/ViewSiteTest.aspx?EoID=" + Request.QueryString["EoID"].ToString().Trim();
                    objSendMail.MailSubject = "Please Review this Site Test Document-Site Test Title: " + txtTitle.Text;
                    objSendMail.SendFrom = strMailFrom + "@pg.com";
                    objSendMail.MailBody = "Dear Concurrer," + "<br>" + "<br>" + "This message was originally sent to " + origApprover + " who is out of the office." + "<br>" + "You are listed as the back-up approver for this Site Test." + "<br>" + "Your concurrence is needed for this Site Test.Please follow the link below to review this Site Test." + "<br>" + "<br><a href='" + strLockURL + "'>" + strLockURL + "</a><br>" + "<br>" + "Note :Use this link to open the Site Test in Edit Mode." + "<br>" + "<br><a href='" + strURL + "'>" + strURL + "</a><br><br>" + "EO Number is " + lblEONum.Text + "<br>" + "Site Test Title is " + txtTitle.Text + "<br>" + "Site Test Location is " + drpPlant.SelectedItem.Text + "<br><br>" + "Thank you," + "<br>" + objSecurity.UserName;
                    bool IsMailSend = false;
                    IsMailSend = clsSendMail.fnSendMail(objSendMail);

                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

            try
            {
                if (!string.IsNullOrEmpty(hdnApprover.Text))
                {
                    SendersList = origApprover + "@pg.com";
                    clsSendMail objSendMail = new clsSendMail();
                    bool IsMailSend = false;
                    objSendMail.SendTo = SendersList;
                    string strURL = null;
                    string strLockURL = "http://" + ViewState["servername"] + "/Common/ViewSiteTest.aspx?EoID=" + Request.QueryString["EoID"].ToString().Trim();
                    objSendMail.MailSubject = "Please Review this Site Test Document-Site Test Title: " + txtTitle.Text;
                    objSendMail.SendFrom = strMailFrom + "@pg.com";
                    objSendMail.MailBody = "Dear Original Approver," + "<br>" + "<br>" + "You were originally listed as an appover for this Site Test.In your absence,this has been sent to " + hdnApprover.Text + " for your back up." + "<br>" + "<br>" + "No further action is needed on your part." + "<br>" + "<br>" + "NOTE: Use this link to open in Read Only Mode." + "<br>" + "<br><a href='" + strLockURL + "'>" + strLockURL + "</a><br>" + "<br><br>" + "EO Number is " + lblEONum.Text + "<br>" + "Site Test Title is " + txtTitle.Text + "<br>" + "Site Test Location is " + drpPlant.SelectedItem.Text + "<br><br>" + "Thank you," + "<br>" + objSecurity.UserName;
                    IsMailSend = clsSendMail.fnSendMail(objSendMail);
                }

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            //End of sending mail
            //Refresh datagrid
            string script = null;
            int intEoID = 0;
            intEoID = Convert.ToInt32(txthdnEoID.Text);
            objSiteTestBA1.UserName = objSecurity.UserName;
            int dlRowCount = 0;
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            objSiteTestBA1.UserName = objSecurity.UserName;
            dsSiteTest = new DataSet();

            //dsSiteTest = objGetSiteTest.FillSiteTest(intEoID);
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {
                if (dsSiteTest.Tables[12].Rows.Count == 0)
                {

                }
                else
                {
                    dlstConcGrp.Visible = true;
                    dlstConcGrp.DataSource = dsSiteTest.Tables[12];
                    dlstConcGrp.DataBind();
                    if (dlstConcGrp.Items.Count == 0)
                    {
                    }
                    else
                    {
                        dlstConcGrp.Visible = true;
                        string strRole = objSecurity.UserRole();

                        for (dlRowCount = 0; dlRowCount <= dlstConcGrp.Items.Count - 1; dlRowCount++)
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"], System.DBNull.Value))
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "No Response")
                            {
                                if (objSiteTestBA1.UserName.ToUpper() == txtCoOriginator.Text.ToUpper() || objSiteTestBA1.UserName.ToUpper() == lblOriginator.Text.ToUpper() || strRole.ToUpper() == "MUREO_Admin".ToUpper())
                                {
                                    if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                    }
                                    else
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;

                                    }

                                }
                                else if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                }
                                else
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                }

                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Approved")
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;

                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Declined")
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                            }
                        }

                    }
                }
            }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string script1 = string.Empty;
            script1 = "window.location.href = '" + url + "';";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script1, true);
        }


        public void showcon()
        {
            string script = null;
            int intEoID = 0;
            intEoID = Convert.ToInt32(txthdnEoID.Text);
            objSiteTestBA1.UserName = objSecurity.UserName;
            int dlRowCount = 0;
            //BusinessObject.MUREO.BusinessObject.SiteTest objGetSiteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            objSiteTestBA1.UserName = objSecurity.UserName;
            dsSiteTest = new DataSet();

            //dsSiteTest = objGetSiteTest.FillSiteTest(intEoID);
            if (objSiteTestBA.FillSiteTest(Convert.ToInt32(EoID), ref dsSiteTest))
            {
                if (dsSiteTest.Tables[12].Rows.Count == 0)
                {

                }
                else
                {
                    dlstConcGrp.Visible = true;
                    dlstConcGrp.DataSource = dsSiteTest.Tables[12];
                    dlstConcGrp.DataBind();
                    if (dlstConcGrp.Items.Count == 0)
                    {
                    }
                    else
                    {
                        dlstConcGrp.Visible = true;
                        string strRole = objSecurity.UserRole();

                        for (dlRowCount = 0; dlRowCount <= dlstConcGrp.Items.Count - 1; dlRowCount++)
                        {
                            if (object.ReferenceEquals(dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"], System.DBNull.Value))
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"].ToString().Trim() == "No Response")
                            {
                                if (objSiteTestBA1.UserName.ToUpper() == txtCoOriginator.Text.ToUpper() || objSiteTestBA1.UserName.ToUpper() == lblOriginator.Text.ToUpper() || strRole.ToUpper() == "MUREO_Admin".ToUpper())
                                {
                                    if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                    }
                                    else
                                    {
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = true;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                        dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;

                                    }

                                }
                                else if (objSiteTestBA1.UserName.ToUpper() == dsSiteTest.Tables[12].Rows[dlRowCount]["Approver_Name"].ToString().ToUpper())
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = true;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                }
                                else
                                {
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                    dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;
                                }

                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Approved")
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkBackUp").Visible = false;

                            }
                            else if (dsSiteTest.Tables[12].Rows[dlRowCount]["Is_Responded"] == "Declined")
                            {
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkApproval").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                                dlstConcGrp.Items[dlRowCount].FindControl("lnkDeclined").Visible = false;
                            }
                        }

                    }
                }
            }
        }

    }
}