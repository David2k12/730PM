using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using MUREOBAL;
using System.Configuration;
using MUREOUI.Common;
using MUREOPROP;


namespace MUREOUI
{
    public partial class frmNewEvent : System.Web.UI.Page
    {

        #region "Declarations"
        string sqlText;
        string strUser;
        SqlParameter[] paramOut = null;
        SiteTestBA objSiteTestBA = new SiteTestBA();
        //clsEvent clsEvt = new clsEvent();
        clsProject clsPrj = new clsProject();
        string strMachineName;
        DataSet dsSeedData;
        DataSet dsBrand;
        DataSet dsProject;
        string strJavaScript;
        DataSet dsPaper;
        DataSet dsConLine;
        DataSet dsMachine;
        DataSet dsPlantorEvent;
        string strUserRole;
        DataSet dsProjectInfo;
        clsEvent objClsEvent = new clsEvent();
        //clsEO objClsEO = new clsEO();
        ObjSiteTest clsobjSiteTest = new ObjSiteTest();
        clsSecurity objSecurity = new clsSecurity();
       
        // Dim script As String
        #endregion
        #region "Load Event"
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnAuthors.Value))
            {
                txtAuthors.Text = hdnAuthors.Value;
            }
            //Page.SmartNavigation = true;
            strUserRole = objSecurity.UserRole();
            if ((strUserRole == "mureo_admin"))
            {
                imgCancel.Enabled = true;
                imgMigSiteTest.Enabled = true;
                imgSubmit.Enabled = true;
                imgSaveCreate.Enabled = true;
                imgSaveCreateNew.Enabled = true;
            }
            else if ((strUserRole == "MUREO_Editors"))
            {
                imgCancel.Enabled = true;
                imgMigSiteTest.Enabled = true;
                imgSubmit.Enabled = true;
                imgSaveCreate.Enabled = true;
                imgSaveCreateNew.Enabled = true;
            }
            else if ((strUserRole == "MUREO_Readers"))
            {
                imgCancel.Enabled = false;
                imgMigSiteTest.Enabled = false;
                imgSubmit.Enabled = false;
                imgSaveCreate.Enabled = false;
                imgSaveCreateNew.Enabled = false;
                Response.Redirect("../Common/Home.aspx");
            }
            else if ((strUserRole == "Readers"))
            {
                imgCancel.Enabled = false;
                imgMigSiteTest.Enabled = false;
                imgSubmit.Enabled = false;
                imgSaveCreate.Enabled = false;
                imgSaveCreateNew.Enabled = false;
                Response.Redirect("../Common/Home.aspx");
            }
            try
            {
                strUser = objSecurity.UserName;
                if (!IsPostBack)
                {
                    //Page.SmartNavigation = true;
                    imgDeleteName.Attributes.Add("onclick", "javascript: ConfirmDelete(\'Are you sure you want to delete the author name(s)? Click OK to delete or " +
                        "CANCEL to abort.\',\'txtAuthors\')");
                    txtDate.Attributes.Add("onblur", "javascript: isDate(this.value);");
                    txtDays.Attributes.Add("onblur", "javascript: CountDecimalsValueThree(this.value,\'txtDays\');");
                    txtPLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,\'txtPLostValue\');");
                    txtConLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,\'txtConLostValue\');");
                    txtComLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,\'txtComLostValue\');");
                    imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
                    tdGDays.Visible = false;
                    tdDays.Visible = false;
                    tdrdbDays.Visible = false;
                    tdtxtDays.Visible = false;
                    FillDropDownWithPlantorEvent("Get_MUR_Plant", "@p_Plant_ID", 0, "Plant_ID", "Plant_Name", "Select a Plant", "Plant Records are not available in the database.", drpPlant);
                    FillDropDownWithPlantorEvent("GET_MUR_Event_Type", "@p_Event_Type_ID", 0, "Event_Type_ID", "Event_Type_Name", "Select a Event Type", "Event Records are not available in the database.", drpEventType);
                    FillDropDownData("Category_Name", "Category_ID", "Select a Category", drpCategoryDB);
                    FillDropDownWithMachines(1, 0, 0, "Machine_Name", "Machine_ID", "Select a Combining line", drpComLine);
                    lblUser.Text = ("Created by " + (strUser + " on " + System.DateTime.Now.Date.ToShortDateString()));

                }

            }
            catch (Exception ex)
                {

                }


        }
        #endregion


        #region "Methods"
        public void insertMandatory(string eventID)
        {
            DataSet dsSeedDataByEventID=new DataSet();
            //BusinessObject.MUREO.BusinessObject.SiteTest siteTest = new BusinessObject.MUREO.BusinessObject.SiteTest();
            //dsSeedDataByEventID = ClsEO.GETEOSeedDataByEventIDs(eventID);
            if (objClsEvent.GETEOSeedDataByEventIDs("GET_EO_Seed_Data_By_Event_IDs", "@p_Event_IDs", eventID, ref dsSeedDataByEventID))
            {
                int Eo_ID;
                ObjSiteTest objst = new ObjSiteTest();
                string strSelEventname;
                strSelEventname = txtEOName.Text.Trim();
                // getting first 15 characters for creating EO name
                try
                {
                    if ((strSelEventname.Length > 15))
                    {
                        strSelEventname = strSelEventname.Substring(0, 15);
                    }
                    //Need to write code frm here

                    objst.EOID = 0.ToString();
                    objst.StageStatus = DBNull.Value.ToString();
                    objst.CurrentStage = DBNull.Value.ToString();
                    // objEO.Title = strSelEventname
                    if (!(strSelEventname.Trim() == ""))
                    {
                        // objEO.Title = strSelEventname
                        objst.Title = strSelEventname;
                    }
                    else
                    {
                        objst.Title = "NewSitetest" + System.DateTime.Now.Date;
                        
                        // DBNull.Value.ToString
                    }
                    if (!(eventID == ""))
                    {
                        // objEO.EventIDs = eventID
                        objst.EventIDs = eventID;
                    }
                    else
                    {
                        objst.EventIDs = DBNull.Value.ToString();
                    }
                    objst.ProjectID = 0;
                    objst.PlantID = 0;
                    objst.CategoryID = 0;
                    objst.Originator = objSecurity.UserName;
                    objst.PhoneNumber = DBNull.Value.ToString();
                    try
                    {
                        objst.OfficeNumber = objSecurity.getUserTelephoneNumber(objSecurity.UserName);
                    }
                    catch (Exception ex)
                    {
                        objst.OfficeNumber = DBNull.Value.ToString();
                    }
                    objst.Brands = "";
                    objst.CoOrginator = DBNull.Value.ToString();
                    objst.CommsntsToApprover = "";

                    if (!(dsSeedDataByEventID == null))
                    {
                        if (!(dsSeedDataByEventID.Tables.Count == 0))
                        {
                            if (!(dsSeedDataByEventID.Tables[0].Rows.Count == 0))
                            {
                                try
                                {
                                    objst.CategoryID =Convert.ToInt32( dsSeedDataByEventID.Tables[0].Rows[0]["CATEGORY_ID"]);
                                    objst.Brands = dsSeedDataByEventID.Tables[0].Rows[0]["BRAND_SEGMENT_ID"].ToString();
                                    objst.ProjectID = Convert.ToInt32( dsSeedDataByEventID.Tables[0].Rows[0]["PROJECT_ID"]);
                                    // PROJECT_ID()
                                    objst.PlantID = Convert.ToInt32( dsSeedDataByEventID.Tables[0].Rows[0]["PLANT_ID"]);
                                    // PLANT_ID()
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                    }
                    //SqlParameter[] paramOut = null;
                    //if (clsobjSiteTest.SetEOMandatory(objst, ref paramOut))
                    //{
                    //    ViewState["EID"] = Convert.ToInt32(paramOut[0].Value.ToString()); 
                    //}

                    if (objSiteTestBA.SetEOMandatory(objst, ref paramOut))
                    {
                        ViewState["EID"] = Convert.ToInt32(paramOut[0].Value);
                    }

                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        
        private void EmptyProject()
        {
            strJavaScript = ("alert(\'" + (ConfigurationManager.AppSettings["ProjectsEmpty"] + "\')"));
            ClientScript.RegisterStartupScript(GetType(), "clientscript", strJavaScript);
        }
        public void FillDropDownWithPlantorEvent(string SqlText, string spParameter, int parPlantEventID, string colValue, string colText, string optionalValue, string ErrMessage, DropDownList drpName)
        {
            dsPlantorEvent = new DataSet();
            if (objClsEvent.FetchAllPlantsorEvents(SqlText, spParameter, parPlantEventID, ref dsPlantorEvent))
            {
                if ((dsPlantorEvent.Tables[0].Rows.Count == 0))
                {
                    EmptyDataMessage(ErrMessage);                    
                    drpName.Items.Insert(0, new ListItem("None", "0"));
                    drpName.Items[0].Value = 0.ToString();
                    return;
                }
                else
                {
                    drpName.DataSource = dsPlantorEvent.Tables[0].DefaultView;
                    drpName.DataTextField = colText;
                    drpName.DataValueField = colValue;
                    drpName.DataBind();                   
                    drpName.Items.Insert(0, new ListItem(optionalValue, "0"));
                    drpName.Items[0].Value = 0.ToString();
                }
            }
            
        }
        public void FillDropDownData(string colName1, string colName2, string optionalValue, DropDownList drpName)
        {
            dsSeedData = new DataSet();
            if (objClsEvent.FillDropDownSeedData("GET_MUR_Category", ref dsSeedData))
            {
                // For Each dtRow As DataRow In dsSeedData.Tables(0).Rows
                if ((dsSeedData.Tables[0].Rows.Count == 0))
                {
                    // EmptyDataMessage("Machine does not exist(s) for the selected value.")
                    drpName.Items.Insert(0, new ListItem("None", "0"));
                    drpName.Items[0].Value = 0.ToString();
                    return;
                }
                else
                {
                    drpName.DataSource = dsSeedData.Tables[0].DefaultView;
                    drpName.DataTextField = colName1;
                    drpName.DataValueField = colName2;
                    drpName.DataBind();
                    drpName.Items.Insert(0, new ListItem(optionalValue, "0"));
                    drpName.Items[0].Value = 0.ToString();
                }
            }
        }
        public void FillDropDownWithMachines(int MachineType, int PlantId, int CategoryId, string colText, string colValue, string optionalValue, DropDownList drpName)
        {
            drpName.Items.Clear();
            dsMachine = new DataSet();
            if (objClsEvent.FetchMachines(MachineType, PlantId, CategoryId, ref dsMachine, "GET_MUR_Machine_Tree_View_Details"))
            {
                if ((dsMachine.Tables[0].Rows.Count == 0))
                {
                    // EmptyDataMessage("Machine does not exist(s) for the selected value.")                    
                    drpName.Items.Insert(0, new ListItem("None", "0"));
                    drpName.Items[0].Value = 0.ToString();
                }
                else
                {
                    drpName.DataSource = dsMachine.Tables[0].DefaultView;
                    drpName.DataTextField = colText;
                    drpName.DataValueField = colValue;
                    drpName.DataBind();
                    drpName.Items.Insert(0, new ListItem(optionalValue, "0"));
                    drpName.Items[0].Value = 0.ToString();
                }
                if ((PlantId == 0))
                {
                    ClearPaperMachineInfo();
                }
            }

        }
        void ClearPaperMachineInfo()
        {
            // txtPDowntime.Text = 0
            // txtPUptime.Text = 0
            // txtPTons.Text = 0
            txtPLostValue.Text = 0.ToString();
            lblPLostValue.Text = 0.ToString();
        }

        public void CheckForNullValue()
        {
            // setting for shipping days
            if ((txtDays.Text == 0.ToString()))
            {
                txtDays.Text = 0.ToString();
            }
            if ((txtPLostValue.Text== 0.ToString()))
            {
                txtPLostValue.Text = 0.ToString();
            }
            if ((txtConLostValue.Text == 0.ToString()))
            {
                txtConLostValue.Text = 0.ToString();
            }
            if ((txtComLostValue.Text == 0.ToString()))
            {
                txtComLostValue.Text = 0.ToString();
            }
        }
        public void EmptyData()
        {
            strJavaScript = ("alert(\'" + (ConfigurationManager.AppSettings["EventsBrandSegmentsEmpty"] + "\')"));
            ClientScript.RegisterStartupScript(GetType(), "clientscript", strJavaScript);
        }
        public void EmptyDataMessage(string strMess)
        {
            strJavaScript = ("alert(\'"+ (strMess + "\')"));
            ClientScript.RegisterStartupScript(GetType(), "clientscript", strJavaScript);
        }
        void clearExcludingPlantMachine()
        {
            txtEOName.Text = "";
        }

        void ClearProjectInfo()
        {
            lblSelCategory.Text = 0.ToString();
            lblBrandValue.Text = 0.ToString();
            lblPrjTypeValue.Text = 0.ToString();
            lblPrjLeaderValue.Text = 0.ToString();
            lblPOCValue.Text = 0.ToString();
            lblOriginatorValue.Text = 0.ToString();
        }
        
        void ClearConvertingMachineInfo()
        {

            txtConLostValue.Text = 0.ToString();
            lblConLostValue.Text = 0.ToString();
        }
        bool validation()
        {
            if ((Convert.ToInt32(drpCategoryDB.SelectedValue) == 0))
            {
                string script;
                script = "alert('" + ConfigurationManager.AppSettings["CategoryErrMsg"] + "'); document.getElementById('" + drpCategoryDB.ClientID + "').focus();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return false;
                
            }
            if ((Convert.ToInt32(drpBrandSegmentDB.SelectedValue) == 0))
            {
                string script;
                //script = ("alert('" + (ConfigurationManager.AppSettings["CategoryErrMsg"] + "')"));
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                script = ("alert(\'" + (ConfigurationManager.AppSettings["BrandErrMsg"] + "\'); document.getElementById('" + drpBrandSegmentDB.ClientID + "').focus();"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return false;
            }
            if ((Convert.ToInt32(drpProject.SelectedValue) == 0))
            {
                string script;
                script = ("alert('" + (ConfigurationManager.AppSettings["PrjNameSelectErrMsg"] + "'); document.getElementById('" + drpProject.ClientID + "').focus();"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return false;
            }
            if ((txtEOName.Text == ""))
            {
                string script;
                script = ("alert('" + (ConfigurationManager.AppSettings["EventNameSelectErrMsg"] + "'); document.getElementById('" + txtEOName.ClientID + "').focus();"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                
            }
            if ((Convert.ToInt32(drpEventType.SelectedValue) == 0))
            {
                string script;
                script = ("alert('" + (ConfigurationManager.AppSettings["EvTypeSelectErrMsg"] + "'); document.getElementById('" + drpEventType.ClientID + "').focus();"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return false;
            }
            if ((Convert.ToInt32(drpPlant.SelectedValue) == 0))
            {
                string script;
                script = ("alert('" + (ConfigurationManager.AppSettings["PlantNameErrMsg"] + "'); document.getElementById('" + drpPlant.ClientID + "').focus();"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return false;
            }
            if ((txtDate.Text == ""))
            {
                string script;
                script = "alert('Please Select Desired Date'); document.getElementById('" + txtDate.ClientID + "').focus();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return false;
            }
            else 
            {
                return true;
            }
        }
        string checkTotalLostdaysValidation()
        {
            string tempStr="";
            int tempInt;
            try
            {
                if ((txtPLostValue.Text.Trim() != ""))
                {tempInt = Convert.ToInt32(txtPLostValue.Text.Trim());
                    if ((tempInt < 0))
                    {
                        tempStr = "FALSE";
                        
                    }


                }
            }
            catch (Exception ex)
            {
                tempStr = "FALSE"; 
                
            }
            return tempStr;
        }
        #endregion

        #region "selectedIndexChanged\CheckedChanged Event"
        protected void rdbShippable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((rdbShippable.SelectedValue == "Y"))
            {
                tdGDays.Visible = true;
                tdrdbDays.Visible = true;
                rdbOnhold.SelectedValue = "N";
            }
            else
            {
                tdGDays.Visible = false;
                tdrdbDays.Visible = false;
                tdDays.Visible = false;
                tdtxtDays.Visible = false;
                rdbOnhold.SelectedValue = "N";
            }
        }

        protected void rdbOnhold_SelectedIndexChanged(object sender, EventArgs e)
        {
            // setting visibility of onhold days field based on onhold radiobutton value
            if ((rdbOnhold.SelectedValue == "Y"))
            {
                tdDays.Visible = true;
                tdtxtDays.Visible = true;
            }
            else
            {
                tdDays.Visible = false;
                tdtxtDays.Visible = false;
                txtDays.Text = "";
            }
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtDays\').focus();", true);
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtDays\').focus();", true);
        }

        protected void drpPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((drpCategoryDB.SelectedIndex > 0)&& (drpPlant.SelectedIndex > 0)))
            {
                // Filling of converting line
                FillDropDownWithMachines(2,Convert.ToInt32( drpPlant.SelectedValue),Convert.ToInt32( drpCategoryDB.SelectedValue), "Machine_Name", "Machine_ID", "Select a Converting Line", drpConLine);
            }
            else
            {
                // clearing the converting line
                drpConLine.Items.Clear();                
                drpConLine.Items.Insert(0, new ListItem("None", "0"));
                drpConLine.Items[0].Value = 0.ToString();
                ClearConvertingMachineInfo();
            }
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtDate\').focus();", true);
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtDate\').focus();", true);
            // Filling of paper machine
            FillDropDownWithMachines(3, Convert.ToInt32(drpPlant.SelectedValue), 0, "Machine_Name", "Machine_ID", "Select a Paper Machine", drpPaper);
        }

        protected void drpProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((drpProject.SelectedIndex > 0))
            {
                dsProjectInfo = new DataSet();
                if (objClsEvent.FetchProjectDetailsForEvent("GET_MUR_Project", "@p_Project_ID",Convert.ToInt32(drpProject.SelectedValue), ref dsProjectInfo))
                {
                if ((dsProjectInfo == null))
                {
                    EmptyDataMessage("Project information for the selected Project is not available");
                }
                else if ((dsProjectInfo.Tables.Count == 0))
                {
                    EmptyDataMessage("Project information for the selected Project is not available");
                }
                else if ((dsProjectInfo.Tables[0].Rows.Count == 0))
                {
                    EmptyDataMessage("Project information for the selected Project is not available");
                }
                else
                {
                    try
                    {
                        lblSelCategory.Text = dsProjectInfo.Tables[0].Rows[0][6].ToString();
                        lblBrandValue.Text = dsProjectInfo.Tables[0].Rows[0][3].ToString();
                        lblPrjTypeValue.Text = dsProjectInfo.Tables[0].Rows[0][2].ToString();
                        lblPrjLeaderValue.Text = dsProjectInfo.Tables[0].Rows[0][4].ToString();
                        lblPOCValue.Text = dsProjectInfo.Tables[0].Rows[0][5].ToString();
                        lblOriginatorValue.Text = dsProjectInfo.Tables[0].Rows[0][7].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            }
            else if ((drpProject.SelectedIndex == 0))
            {
                ClearProjectInfo();
            }
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtEOName\').focus();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtEOName\').focus();", true);
        }

        protected void drpPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPLostValue.Text = 0.ToString();
            txtPLostValue.Text = 0.ToString();
            txtPComments.Text = "";
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtPLostValue\').focus();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtPLostValue\').focus();", true);
        }

        protected void drpConLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblConLostValue.Text = 0.ToString();
            txtConLostValue.Text = 0.ToString();
            txtConComments.Text = "";
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtConLostValue\').focus();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'txtConLostValue\').focus();", true);
        }

        protected void drpComLine_SelectedIndexChanged(object sender, EventArgs e)
        {
             txtComLostValue.Text = 0.ToString();
            lblComLostValue.Text = 0.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById('txtComLostValue').focus();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById('txtComLostValue').focus();", true);
        }

        protected void drpCategoryDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((drpCategoryDB.SelectedIndex != 0))
            {
                drpBrandSegmentDB.Items.Clear();
                // Else
                dsBrand = new DataSet();
                if (clsPrj.FetchDataSetUsingSqlParameters(Convert.ToInt32(drpCategoryDB.SelectedValue), ref dsBrand, "GET_MUR_BRAND_Segment_By_Category", "@p_Category_ID"))
                {
                     if ((dsBrand.Tables[0].Rows.Count == 0))
                    {
                        EmptyData();                      
                        drpBrandSegmentDB.Items.Insert(0, new ListItem("None", "0"));
                        drpBrandSegmentDB.Items[0].Value = 0.ToString();
                        // Clearing the Project Info as they are indirectly related with Category.
                        drpProject.Items.Clear();                       
                        drpProject.Items.Insert(0, new ListItem("None", "0"));
                        drpProject.Items[0].Value = 0.ToString();
                        // Clearing the project information.
                        ClearProjectInfo();
                    }

                    else
                    {
                        try
                        {
                            drpBrandSegmentDB.DataSource = dsBrand.Tables[0].DefaultView;
                            drpBrandSegmentDB.DataTextField = "Brand_Segment_Name";
                            drpBrandSegmentDB.DataValueField = "Brand_Segment_ID";
                            drpBrandSegmentDB.DataBind();
                        }
                        catch (Exception ex)
                        {
                        }                      
                        drpBrandSegmentDB.Items.Insert(0, new ListItem("Select a Brand Segment", "0"));
                        drpBrandSegmentDB.Items[0].Value =0.ToString();
                    }
                }
            }
            else if ((drpCategoryDB.SelectedIndex == 0))
            {
                // Clearing the brand segements
                drpBrandSegmentDB.Items.Clear();             
                drpBrandSegmentDB.Items.Insert(0, new ListItem("None", "0"));
                drpBrandSegmentDB.Items[0].Value = 0.ToString();
                // Clearing the converting lines machines.
                drpConLine.Items.Clear();
                drpConLine.Items.Insert(0, new ListItem("None", "0"));
                drpConLine.Items[0].Value = 0.ToString();
                ClearConvertingMachineInfo();
                // Clearing the Project Info as they are indirectly related with Category.
                drpProject.Items.Clear();              
                drpProject.Items.Insert(0, new ListItem("None", "0"));
                drpProject.Items[0].Value = 0.ToString();
                // Clearing the project information.
                ClearProjectInfo();
            }
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'drpBrandSegmentDB\').focus();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'drpBrandSegmentDB\').focus();", true);
            // populationg the converting machine
            if ((drpPlant.SelectedIndex > 0))
            {
                FillDropDownWithMachines(2, Convert.ToInt32(drpPlant.SelectedValue),Convert.ToInt32( drpCategoryDB.SelectedValue), "Machine_Name", "Machine_ID", "Select a Converting Line", drpConLine);
            }
        }
       
        protected void drpBrandSegmentDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpProject.Items.Clear();
            dsProject = new DataSet();
            if (objClsEvent.FillDropDownWithProjects(Convert.ToInt32(drpCategoryDB.SelectedValue), Convert.ToInt32(drpBrandSegmentDB.SelectedValue), ref dsProject, "GET_MUR_Projects_By_Category_Brand_Segment"))
            {
                if ((dsProject.Tables[0].Rows.Count == 0))
                {
                    EmptyProject();                    
                    drpProject.Items.Insert(0, new ListItem("None", "0"));
                    drpProject.Items[0].Value = 0.ToString();
                    ClearProjectInfo();
                    return;
                }
                try
                {
                    drpProject.DataSource = dsProject.Tables[0].DefaultView;
                    drpProject.DataTextField = "Project_Name";
                    drpProject.DataValueField = "Project_ID";
                    drpProject.DataBind();
                }
                catch (Exception ex)
                {
                }                
                drpProject.Items.Insert(0, new ListItem("Select a Project", "0"));
                drpProject.Items[0].Value = 0.ToString();
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'drpProject\').focus();", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById(\'drpProject\').focus();", true);
            }
        }
        #endregion

        #region "Button Events"
        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            
            if (validation())
            {
                try
                {
                    string tempStr = checkTotalLostdaysValidation();
                    if ((tempStr == "FALSE"))
                    {
                        string script;
                        script = "alert('Input is Not In Correct Format');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        return;
                    }
                    // Validaion on machine types
                    if (((drpPaper.SelectedIndex == 0)
                                && ((drpConLine.SelectedIndex == 0)
                                && (drpComLine.SelectedIndex == 0))))
                    {
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["MachineErrMsg"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        return;
                    }
                    // 'Calculation of Total lost days for machine types
                    // LostDaysCalculation()
                    // Code for save project button
                    if ((rdbShippable.SelectedValue == "N"))
                    {
                        txtDays.Text = 0.ToString();
                    }
                    //int yr=Convert.ToInt32(txtDate.Text.Split('-')[2]);
                    //int dd=Convert.ToInt32(txtDate.Text.Split('-')[1]);
                    //int mm=Convert.ToInt32(txtDate.Text.Split('-')[0]);

                    DateTime strDate = Convert.ToDateTime(txtDate.Text);
                    CheckForNullValue();
                    lblConLostValue.Text = txtConLostValue.Text;
                    lblPLostValue.Text = txtPLostValue.Text;
                    lblComLostValue.Text = txtComLostValue.Text;
                    SqlParameter[] paramOut = null;
                    if (string.IsNullOrEmpty(txtDays.Text))
                        txtDays.Text = "0";
                    if (objClsEvent.EventInsertDAL(0, Convert.ToInt32(drpProject.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue), strDate, rdbShippable.SelectedValue, Convert.ToDecimal(txtDays.Text), Convert.ToInt32(drpPaper.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblPLostValue.Text), txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblConLostValue.Text), txtConComments.Text.Trim(), Convert.ToInt32(drpComLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblComLostValue.Text), txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
                    {
                        int intResult;
                        if (!(paramOut[1].Value == DBNull.Value))
                        {
                            intResult = Convert.ToInt32(paramOut[1].Value);
                        }
                        else
                        {
                            intResult = -1;
                        }
                        if ((intResult == 0))
                        {
                            string script;
                            script = ("alert('" + (ConfigurationManager.AppSettings["InsertSuccess"] + "');"));
                            script = script + "window.location='../common/Home.aspx';";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            hdnAuthors.Value = string.Empty;
                        }
                        else if ((intResult == 1))
                        {
                            string script;
                            script = ("alert('" + (ConfigurationManager.AppSettings["RecordExist"] + "')"));
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            hdnAuthors.Value = string.Empty;
                        }
                        else
                        {
                            // Failure Message
                            string script;
                            script = ("alert('" + (ConfigurationManager.AppSettings["EventInsertErrMsg"] + "')"));
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string script;
                    string exMessage;
                    exMessage = ex.Message.Replace("\'", " ");
                    script = ("alert(\'"
                                + (exMessage + "\'); "));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                }
            
            }
        }

        protected void imgSaveCreateNew_Click(object sender, ImageClickEventArgs e)
        {

            // Validaion on Project,Plant and Desired start date
            try
            {

                if ((Convert.ToInt32(drpCategoryDB.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["CategoryErrMsg"] + "'); document.getElementById('" + drpCategoryDB.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                    return;
                }
                if ((Convert.ToInt32(drpBrandSegmentDB.SelectedValue) == 0))
                {
                    string script;
                    //script = ("alert('" + (ConfigurationManager.AppSettings["CategoryErrMsg"] + "')"));
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                    script = ("alert(\'" + (ConfigurationManager.AppSettings["BrandErrMsg"] + "\'); document.getElementById('" + drpBrandSegmentDB.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpProject.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["PrjNameSelectErrMsg"] + "'); document.getElementById('" + drpProject.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((txtEOName.Text == ""))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["EventNameSelectErrMsg"] + "'); document.getElementById('" + txtEOName.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpEventType.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["EvTypeSelectErrMsg"] + "'); document.getElementById('" + drpEventType.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpPlant.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["PlantNameErrMsg"] + "'); document.getElementById('" + drpPlant.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((txtDate.Text == ""))
                {
                    string script;
                    script = "alert('Please Select Desired Date'); document.getElementById('" + txtDate.ClientID + "').focus();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                string tempStr = checkTotalLostdaysValidation();
                if ((tempStr == "FALSE"))
                {
                    string script;
                    script = "alert('Input is Not In Correct Format'); ";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    return;
                }
                if ((rdbOnhold.SelectedValue == "Y"))
                {
                    if (((txtDays.Text.Trim() == "") || (txtDays.Text == 0.ToString())))
                    {
                        string script;
                        script = "alert(\'Please enter # Days on Hold.\');document.getElementById(\'txtDays\').focus();";
                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                        return;
                    }
                }
                if (((drpPaper.SelectedIndex == 0)
                                    && ((drpConLine.SelectedIndex == 0)
                                    && (drpComLine.SelectedIndex == 0))))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["MachineErrMsg"] + "')"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                // 'Calculation of Total lost days for machine types
                // LostDaysCalculation()
                // Code for save project button
                if ((rdbShippable.SelectedValue == "N"))
                {
                    txtDays.Text = 0.ToString();
                }
                int yr = Convert.ToInt32(txtDate.Text.Split('/')[2]);
                int dd = Convert.ToInt32(txtDate.Text.Split('/')[1]);
                int mm = Convert.ToInt32(txtDate.Text.Split('/')[0]);

                DateTime strDate = new DateTime(yr, mm, dd);             
                CheckForNullValue();
                lblConLostValue.Text = txtConLostValue.Text;
                lblPLostValue.Text = txtPLostValue.Text;
                lblComLostValue.Text = txtComLostValue.Text;
                SqlParameter[] paramOut = null;
                if (string.IsNullOrEmpty(txtDays.Text))
                    txtDays.Text = "0";
                if (objClsEvent.EventInsertDAL(0, Convert.ToInt32(drpProject.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue), strDate, rdbShippable.SelectedValue, Convert.ToDecimal(txtDays.Text), Convert.ToInt32(drpPaper.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblPLostValue.Text), txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblConLostValue.Text), txtConComments.Text.Trim(), Convert.ToInt32(drpComLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblComLostValue.Text), txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
                {
                    int intResult;
                    if (!(paramOut[1].Value == DBNull.Value))
                    {
                        intResult = Convert.ToInt32(paramOut[1].Value);
                    }
                    else
                    {
                        intResult = -1;
                    }
                    // Dim intResult As Integer = clsEvt.EventInsert(0, drpProject.SelectedValue.Trim, drpPlant.SelectedValue.Trim, txtEOName.Text.Trim, drpEventType.SelectedValue, strDate, rdbShippable.SelectedValue, txtDays.Text.Trim, drpPaper.SelectedValue, txtPDowntime.Text.Trim, txtPUptime.Text.Trim, Convert.ToDecimal(txtPTons.Text.Trim), txtPLostValue.Text.Trim, txtPComments.Text.Trim, drpConLine.SelectedValue, txtConDownTime.Text.Trim, txtConUpTime.Text.Trim, Convert.ToDecimal(txtConBroke.Text.Trim), txtConLostValue.Text.Trim, txtConComments.Text.Trim, drpComLine.SelectedValue, txtComDownTime.Text.Trim, txtComUpTime.Text.Trim, Convert.ToDecimal(txtComBroke.Text.Trim), txtComLostValue.Text.Trim, txtAuthors.Text.Trim, "A", strUser)
                    if ((intResult == 0))
                    {
                        // Success Message
                        string script;
                        script = "alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "'); window.location='frmNewEvent.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        hdnAuthors.Value = string.Empty;
                        //Response.Redirect("frmNewEvent.aspx");
                    }
                    else if ((intResult == 1))
                    {
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["RecordExist"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        hdnAuthors.Value = string.Empty;
                    }
                    else
                    {
                        // Failure Message
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["EventInsertErrMsg"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                //string script;
                //string exMessage;
                //exMessage = ex.Message.Replace("\'", " ");
                //script = ("alert(\'"
                //            + (exMessage + "\');"));
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void imgSaveCreate_Click(object sender, ImageClickEventArgs e)
        {
            // Validaion on Project,Plant and Desired start date
            try
            {

                if ((Convert.ToInt32(drpCategoryDB.SelectedValue) == 0))
                {
                    string script;
                    script = "alert('" + ConfigurationManager.AppSettings["CategoryErrMsg"] + "'); document.getElementById('" + drpCategoryDB.ClientID + "').focus();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                  
                    return;
                }
                if ((Convert.ToInt32(drpBrandSegmentDB.SelectedValue) == 0))
                {
                    string script;
                    //script = ("alert('" + (ConfigurationManager.AppSettings["CategoryErrMsg"] + "')"));
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                    script = ("alert(\'" + (ConfigurationManager.AppSettings["BrandErrMsg"] + "\'); document.getElementById('" + drpBrandSegmentDB.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpProject.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["PrjNameSelectErrMsg"] + "'); document.getElementById('" + drpProject.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((txtEOName.Text == ""))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["EventNameSelectErrMsg"] + "'); document.getElementById('" + txtEOName.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpEventType.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["EvTypeSelectErrMsg"] + "'); document.getElementById('" + drpEventType.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpPlant.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["PlantNameErrMsg"] + "'); document.getElementById('" + drpPlant.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((txtDate.Text == ""))
                {
                    string script;
                    script = "alert('Please Select Desired Date'); document.getElementById('" + txtDate.ClientID + "').focus();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                string tempStr = checkTotalLostdaysValidation();
                if ((tempStr == "FALSE"))
                {
                    string script;
                    script = "alert(\'Input is Not In Correct Format\') ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((rdbOnhold.SelectedValue == "Y"))
                {
                    if (((txtDays.Text.Trim() == "")
                                || (txtDays.Text == 0.ToString())))
                    {
                        string script;
                        script = "alert(\'Please enter # Days on Hold.\');document.getElementById(\'txtDays\').focus()";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        return;
                    }
                    if ((txtDays.Text.Trim() != ""))
                    {
                        if ((Convert.ToInt32(txtDays.Text.Trim()) <= 3))
                        {
                            string script;
                            script = "alert(\'#Days on Hold should be greater than 3.\');document.getElementById(\'txtDays\').focus();";

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            return;
                        }
                            
                    }
                }
                
                if (((drpPaper.SelectedIndex == 0) && ((drpConLine.SelectedIndex == 0) && (drpComLine.SelectedIndex == 0))))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["MachineErrMsg"] + "')"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                if ((rdbShippable.SelectedValue == "N"))
                {
                    txtDays.Text = 0.ToString();
                }
                int yr = Convert.ToInt32(txtDate.Text.Split('/')[2]);
                int dd = Convert.ToInt32(txtDate.Text.Split('/')[1]);
                int mm = Convert.ToInt32(txtDate.Text.Split('/')[0]);

                DateTime strDate = new DateTime(yr, mm, dd);  
                CheckForNullValue();
                lblConLostValue.Text = txtConLostValue.Text;
                lblPLostValue.Text = txtPLostValue.Text;
                lblComLostValue.Text = txtComLostValue.Text;
                SqlParameter[] paramOut = null;

                if (string.IsNullOrEmpty(txtDays.Text))
                    txtDays.Text = "0";
                if (objClsEvent.EventInsertDAL(0, Convert.ToInt32(drpProject.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue), strDate, rdbShippable.SelectedValue, Convert.ToDecimal(txtDays.Text), Convert.ToInt32(drpPaper.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblPLostValue.Text), txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblConLostValue.Text), txtConComments.Text.Trim(), Convert.ToInt32(drpComLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblComLostValue.Text), txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
                {
                    int intResult;
                    if (!(paramOut[1].Value == DBNull.Value))
                    {
                        intResult = Convert.ToInt32(paramOut[1].Value);
                    }
                    else
                    {
                        intResult = -1;
                    }
                    if ((intResult == 0))
                    {
                        // Success Message
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["InsertSuccess"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        hdnAuthors.Value = string.Empty;
                        // Response.Redirect("frmNewEvent.aspx")
                        clearExcludingPlantMachine();
                    }
                    else if ((intResult == 1))
                    {
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["RecordExist"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        hdnAuthors.Value = string.Empty;
                    }
                    else
                    {
                        // Failure Message
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["EventInsertErrMsg"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string script;
                string exMessage;
                //exMessage = ex.Message.Replace("\'", " ");
                //script = ("alert(\'"
                //            + (exMessage + "\');"));
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void imgMigSiteTest_Click(object sender, ImageClickEventArgs e)
        {
            string strWHBCType;
            int intWHBCType;
            bool boolWHBC = false;
            bool boolSimpleSiteTest = false;
            int strEventID;
            // Below options are for checking the event details before they are saved in the database.
            try
            {
                if ((Convert.ToInt32(drpCategoryDB.SelectedValue) == 0))
                {
                    string script;
                    script = "alert('" + (ConfigurationManager.AppSettings["CategoryErrMsg"] + "'); document.getElementById('"+drpCategoryDB.ClientID+"').focus(); ");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpBrandSegmentDB.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["BrandErrMsg"] + "'); document.getElementById('" + drpBrandSegmentDB.ClientID + "').focus(); "));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpProject.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["PrjNameSelectErrMsg"] + "'); document.getElementById('" + drpProject.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((txtEOName.Text == ""))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["EventNameSelectErrMsg"] + "'); document.getElementById('" + txtEOName.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpEventType.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["EvTypeSelectErrMsg"] + "'); document.getElementById('" + drpEventType.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((Convert.ToInt32(drpPlant.SelectedValue) == 0))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["PlantNameErrMsg"] + "'); document.getElementById('" + drpPlant.ClientID + "').focus();"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((txtDate.Text == ""))
                {
                    string script;
                    script = "alert('Please Select Desired Date'); document.getElementById('" + txtDate.ClientID + "').focus();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                string tempStr = checkTotalLostdaysValidation();
                if ((tempStr == "FALSE"))
                {
                    string script;
                    script = "alert(\'Input is Not In Correct Format\');  ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((rdbOnhold.SelectedValue == "Y"))
                {
                    if (((txtDays.Text.Trim() == "") || (txtDays.Text == 0.ToString())))
                    {
                        string script;
                        script = "alert(\'Please enter # Days on Hold.\');document.getElementById(\'txtDays\').focus();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        return;
                    }
                }
                if ((rdbOnhold.SelectedValue == "Y"))
                {
                    if ((txtDays.Text.Trim() != ""))
                    {
                        if ((Convert.ToInt32(txtDays.Text) <= 3))
                        {
                            string script;
                            script = "alert(\'#Days on Hold should be greater than 3.\');document.getElementById(\'txtDays\').focus();<" +
                            "/script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            return;
                        }
                    }
                }
                if (((drpPaper.SelectedIndex == 0) && ((drpConLine.SelectedIndex == 0) && (drpComLine.SelectedIndex == 0))))
                {
                    string script;
                    script = ("alert('" + (ConfigurationManager.AppSettings["MachineErrMsg"] + "')"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if ((rdbShippable.SelectedValue == "N"))
                {
                    txtDays.Text = 0.ToString();
                }
                int yr = Convert.ToInt32(txtDate.Text.Split('/')[2]);
                int dd = Convert.ToInt32(txtDate.Text.Split('/')[1]);
                int mm = Convert.ToInt32(txtDate.Text.Split('/')[0]);

                DateTime strDate = new DateTime(yr, mm, dd); 
                CheckForNullValue();
                // Checking whether the user has selected WHBC plant site and event type as site test.
                if (((drpEventType.SelectedItem.Text.ToUpper() == "site test".ToUpper())
                            && (drpPlant.SelectedItem.Text.ToUpper() != "whbc".ToUpper())))
                {
                    boolSimpleSiteTest = true;
                }
                else if (((drpEventType.SelectedItem.Text.ToUpper() == "site test".ToUpper())
                            && (drpPlant.SelectedItem.Text.ToUpper() == "whbc".ToUpper())))
                {
                    boolWHBC = true;
                }
                if (((boolSimpleSiteTest == false)
                            && (boolWHBC == false)))
                {
                    // strWHBCType = "Simple Site Test"
                    // intWHBCType = 0
                    // ElseIf boolSimpleSiteTest = False Then
                    string script;
                    script = "alert(\'For migration to site test WHBC value for Plant and SiteTest for Event type  or atleast " +
                    " SiteTest for Event type has to be selected.\');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                // End If
                if (((drpPaper.SelectedIndex > 0)
                            && ((drpConLine.SelectedIndex > 0)
                            && (boolWHBC == true))))
                {
                    string script;
                    script = "alert(\'Please select only one machine for migration to site test\'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (((drpPaper.SelectedIndex > 0)
                            && (boolWHBC == true)))
                {
                    strWHBCType = "WHBC Paper Machine";
                    intWHBCType = 1;
                }
                else if (((drpConLine.SelectedIndex > 0)
                            && (boolWHBC == true)))
                {
                    strWHBCType = "WHBC Converting Line";
                    intWHBCType = 2;
                }
                else
                {
                    strWHBCType = "Simple Site Test";
                    intWHBCType = 0;
                }
                lblConLostValue.Text = txtConLostValue.Text;
                lblPLostValue.Text = txtPLostValue.Text;
                lblComLostValue.Text = txtComLostValue.Text;
                SqlParameter[] paramOut = null;
                string intResult = "";

                if (string.IsNullOrEmpty(txtDays.Text))
                    txtDays.Text = "0";
                if (objClsEvent.EventInsertForMigrationDAL(0, Convert.ToInt32(drpProject.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue), strDate, rdbShippable.SelectedValue, Convert.ToDecimal(txtDays.Text.Trim()), Convert.ToInt32(drpPaper.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblPLostValue.Text.Trim()), txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblConLostValue.Text.Trim()), txtConComments.Text.Trim(), Convert.ToInt32(drpComLine.SelectedValue), 0, 0, 0, Convert.ToDecimal(lblComLostValue.Text.Trim()), txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
                {

                    if (!(paramOut[1].Value == DBNull.Value))
                    {
                        if ((paramOut[1].Value != DBNull.Value) && (paramOut[0].Value != DBNull.Value))
                        {
                            //if ((paramOut[1].Value.ToString() == 0.ToString()))
                            //{
                            //    intResult = paramOut[1].Value.ToString();
                            //    intResult = (intResult + ("," + paramOut[1].Value));
                            //}
                            //else
                            //{
                            //    intResult = 0.ToString();
                            //    intResult = (intResult + ("," + paramOut[1].Value));
                            //}

                            intResult = paramOut[0].Value + "," + paramOut[1].Value;
                        }
                    }
                    //else
                    //{
                    //    intResult = -1;
                    //    // when the database results failure dure to database problem.
                    //    intResult = (intResult + ("," + "-1"));
                    //    return - 1;

                    int[] intOTArray = new int[2];
                    string[] strDivideString;
                    if (!(intResult == 0.ToString()))
                    {
                        char[] delimeter = new char[] { ',' };
                        strDivideString = intResult.Split(delimeter, intResult.Length);
                        for (int i = 0; (i
                                    <= (strDivideString.Length - 1)); i++)
                        {
                            intOTArray[i] = Convert.ToInt32(strDivideString[i]);
                        }
                    }
                    if ((intOTArray[1] == 0))
                    {
                        string script;
                        insertMandatory(intOTArray[0].ToString());
                        script = ("alert('" + (ConfigurationManager.AppSettings["InsertSuccess"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        strEventID = intOTArray[0];
                        // reading the event id
                        // Response.Redirect(String.Format("../Common/SiteTest.aspx?EventID={0}&PlantType={1}&From={2}&StartDate={3}", strEventID, intWHBCType, "NewEvent", txtDate.Text.Trim))
                        // Response.Redirect(String.Format("../Common/SiteTest.aspx?EventID={0}&PlantType={1}&From={2}&StartDate={3}", strEventID, intWHBCType, "NewEvent", txtDate.Text.Trim))
                        int intEOID = Convert.ToInt32((ViewState["EID"]));
                        //test
                        Response.Redirect(string.Format("../Common/SiteTest.aspx?From=EDIT&EoID=" + intEOID + "&Page=MigrSt&StartDate=" + Convert.ToDateTime(txtDate.Text).ToShortDateString() + "&PlantType=" + intWHBCType));
                        //test
                    }
                    else if ((intOTArray[1] == 1))
                    {
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["RecordExist"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        hdnAuthors.Value = string.Empty;
                    }
                    else
                    {
                        // Failure Message
                        string script;
                        script = ("alert('" + (ConfigurationManager.AppSettings["EventInsertErrMsg"] + "')"));
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string script;
                string exMessage;
                exMessage = ex.Message.Replace("\'", " ");
                script = ("alert(\'"
                            + (exMessage + "\'); "));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/Home.aspx");
        }
        #endregion
    }
}