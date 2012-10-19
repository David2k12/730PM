using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;
using System.Configuration;
using MUREOPROP;

namespace MUREOUI.Common
{
    public partial class frmEditEvent : System.Web.UI.Page
    {
        string sqlText;
        string strUser;
        int intPrjID;
        clsProject clsPrj = new clsProject();
        clsEvent clsEvt = new clsEvent();
        DataSet dsSeedData = new DataSet();
        DataSet dsProject = new DataSet();
        DataSet dsBrand = new DataSet();
        string strJavaScript;
        int intBrandSegmentID;
        DataSet dsHistory;
        int intPaperMachineID;
        int intConvertingMachineID;
        DataSet dsPaper = new DataSet();
        DataSet dsConLine = new DataSet();
        DataSet dsMachine = new DataSet();
        DataSet dsEventDetails = new DataSet();
        DataSet dsProjectDetails = new DataSet();
        int intEventTypeValue;
        DataSet dsPlantorEvent = new DataSet();
        int intCombiningValue;
        int intPlantValue;
        static string strUserRole;
        DataSet dsCheckUser = new DataSet();
        bool boolAllowUser = false;
        string strCreatedUser;
        DataSet dsProjectInfo = new DataSet();
        clsSecurity objSecurity = new clsSecurity();
        SqlParameter[] paramOut = null;
        EOBA objEOBA = new EOBA();
        SiteTestBA objSiteTestBA = new SiteTestBA();
        clsEvent objClsEvent = new clsEvent();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnAuthors.Value))
            {
                txtAuthors.Text = hdnAuthors.Value;
            }
            Page.SmartNavigation = true;
            strUser = objSecurity.UserName;
            strUserRole = objSecurity.UserRole();
            dsCheckUser = new DataSet();
            //dsCheckUser = clsEvent.FetchEventDetails(Request.QueryString["EventID"]);
            clsEvent objclsEvent = new clsEvent();
            //dsEventdays = clsEvent.FetchEventDetails(EventID);
            if (objclsEvent.FetchEventDetails(Convert.ToInt32(Request.QueryString["EventID"]), ref dsCheckUser))
            {

                if ((dsCheckUser != null))
                {
                    if (!(dsCheckUser.Tables.Count == 0))
                    {
                        if (!(dsCheckUser.Tables[0].Rows.Count == 0))
                        {
                            //Getting the name of the created user 
                            strCreatedUser = dsCheckUser.Tables[0].Rows[0][10].ToString();
                        }
                    }
                }
            }

            //int intConfResult = clsEvt.CountForDeletion(Request.QueryString["EventID"], strUser);

            int intConfResult = 0;
            if (clsEvt.CountForDeletion(Convert.ToInt32(Request.QueryString["EventID"]), strUser, ref paramOut))
            {
                intConfResult = Convert.ToInt32(paramOut[0].Value);
            }

            if (intConfResult == 0)
            {
                imgDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the project? Click OK to delete or CANCEL to abort.');");
            }

            if ((dsCheckUser != null))
            {
                if (!(dsCheckUser.Tables.Count == 0))
                {
                    if (!(dsCheckUser.Tables[5].Rows.Count == 0))
                    {
                        //Getting the other author names and if exist make their eligibilty for modification to true
                        foreach (DataRow drAuthors in dsCheckUser.Tables[5].Rows)
                        {
                            if (strUser == drAuthors[0].ToString())
                            {
                                boolAllowUser = true;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                    if (!(dsCheckUser.Tables[6].Rows.Count == 0))
                    {
                        //Getting the POC names and if exist make their eligibilty for modification to true
                        foreach (DataRow drAuthors in dsCheckUser.Tables[6].Rows)
                        {
                            if (strUser == drAuthors[0].ToString())
                            {
                                boolAllowUser = true;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                }
            }



            if (strCreatedUser == strUser)
            {
                imgCancel.Enabled = true;
                imgMigSiteTest.Enabled = true;
                imgSubmit.Enabled = true;
            }
            else if (boolAllowUser == true)
            {
                imgCancel.Enabled = true;
                imgMigSiteTest.Enabled = true;
                imgSubmit.Enabled = true;
            }
            else if (strUserRole == "MUREO_Admin")
            {
                imgCancel.Enabled = true;
                imgMigSiteTest.Enabled = true;
                imgSubmit.Enabled = true;
            }
            else
            {
                imgCancel.Enabled = false;
                imgMigSiteTest.Enabled = false;
                imgSubmit.Enabled = false;
                Response.Redirect("../Common/Home.aspx");
            }


            try
            {
                //btnDelete.Attributes.Add("OnClick", "return confirm('Are you sure do you want to delete this event')")
                lblUser.Visible = false;
                if (!IsPostBack)
                {
                    lblGDays.Visible = false;
                    lblDays.Visible = false;
                    rdbOnhold.Visible = false;
                    txtDays.Visible = false;

                    //Confirm box for Deleting authors name
                    //imgDeleteName.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the author name(s)? Click OK to delete or CANCEL to abort.');")
                    imgDeleteName.Attributes.Add("onclick", "javascript: ConfirmDelete('Are you sure you want to delete the author name(s)? Click OK to delete or CANCEL to abort.','txtAuthors')");
                    txtDate.Attributes.Add("onblur", "javascript: isDate(this.value);");
                    //added by abdul for lost value text box
                    txtPLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,'txtPLostValue');");
                    txtConLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,'txtConLostValue');");
                    txtComLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,'txtComLostValue');");
                    imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
                    txtDays.Attributes.Add("onblur", "javascript: CountDecimalsValueThree(this.value,'txtDays');");

                    //New Code by Abdul filling Text Boxes using datasets
                    if (!IsPostBack)
                    {
                        dsEventDetails = new DataSet();
                        //dsEventDetails = clsEvent.FetchEventDetails(Request.QueryString["EventID"]);
                        if (objclsEvent.FetchEventDetails(Convert.ToInt32(Request.QueryString["EventID"]), ref dsEventDetails))
                        {
                            if (dsEventDetails == null)
                            {
                                return;
                            }
                            else if (dsEventDetails.Tables.Count == 0)
                            {
                                return;
                            }
                            else if (dsEventDetails.Tables[0].Rows.Count == 0)
                            {
                                return;
                            }
                            //Displaying General Sectiion of event.
                            foreach (DataRow drEventRow in dsEventDetails.Tables[0].Rows)
                            {
                                txtEOName.Text = drEventRow[4].ToString();
                                //txtDate.Text = Strings.Format(drEventRow[7], "MM/dd/yyyy");
                                txtDate.Text = String.Format("{0:MM/dd/yyyy}", drEventRow[7]);
                                rdbShippable.SelectedValue = drEventRow[8].ToString();

                                if (rdbShippable.SelectedValue == "Y")
                                {
                                    lblGDays.Visible = true;
                                    rdbOnhold.Visible = true;
                                }
                                else
                                {
                                    rdbOnhold.Visible = false;
                                    txtDays.Visible = false;
                                }
                                txtDays.Text =Convert.ToString(Convert.ToInt32(Convert.ToDouble(drEventRow[9].ToString())));
                                if (txtDays.Text == "0")
                                {
                                    lblGDays.Visible = false;
                                    lblDays.Visible = false;
                                    rdbOnhold.Visible = false;
                                    txtDays.Visible = false;
                                    rdbOnhold.SelectedValue = "N";
                                    rdbShippable.SelectedValue = "N";
                                }
                                else
                                {
                                    lblGDays.Visible = true;
                                    lblDays.Visible = true;
                                    rdbOnhold.Visible = true;
                                    txtDays.Visible = true;
                                    rdbOnhold.SelectedValue = "Y";
                                }
                                intPrjID = Convert.ToInt32(drEventRow[0]);
                                intPlantValue = Convert.ToInt32(drEventRow[2]);
                                intEventTypeValue = Convert.ToInt32(drEventRow[5]);
                                intBrandSegmentID = Convert.ToInt32(drEventRow[14]);
                            }

                            lblHeading.CssClass = "FormHeader";
                            lblHeading.Text = txtEOName.Text + " - Event File";


                            FillDropDownWithPlantorEvent("Get_MUR_Plant", "@p_Plant_ID", 0, "Plant_ID", "Plant_Name", "Select a Plant", "Plant Records are not available in the database.", drpPlant);
                            FillDropDownWithPlantorEvent("GET_MUR_Event_Type", "@p_Event_Type_ID", 0, "Event_Type_ID", "Event_Type_Name", "Select a Event", "Event Records are not available in the database.", drpEventType);
                            FillDropDownData("Category_Name", "Category_ID", "Select a Category", drpCategoryDB);
                            drpPlant.SelectedValue = intPlantValue.ToString();
                            drpEventType.SelectedValue = intEventTypeValue.ToString();

                            //Displaying combining line machine type details
                            foreach (DataRow drCombiningRow in dsEventDetails.Tables[1].Rows)
                            {
                                intCombiningValue = Convert.ToInt32(drCombiningRow[0]);
                                txtComLostValue.Text = drCombiningRow[2].ToString();
                            }

                            //Displaying converting line machine type details
                            foreach (DataRow drConvertingRow in dsEventDetails.Tables[2].Rows)
                            {
                                intConvertingMachineID = Convert.ToInt32(drConvertingRow[0]);
                                txtConLostValue.Text = drConvertingRow[2].ToString();
                                if (drConvertingRow[3] == DBNull.Value)
                                {
                                    txtConComments.Text = string.Empty;
                                }
                                else
                                {
                                    txtConComments.Text = drConvertingRow[3].ToString();
                                }
                            }


                            //Displaying Paper machine machine type details
                            foreach (DataRow drPaperMachineRow in dsEventDetails.Tables[3].Rows)
                            {
                                intPaperMachineID = Convert.ToInt32(drPaperMachineRow[0]);
                                txtPLostValue.Text = drPaperMachineRow[2].ToString();
                                if (drPaperMachineRow[3] == DBNull.Value)
                                {
                                    txtPComments.Text = string.Empty;
                                }
                                else
                                {
                                    txtPComments.Text = drPaperMachineRow[3].ToString();
                                }
                            }


                            //Displaying Authors if exist
                            foreach (DataRow drAuthors in dsEventDetails.Tables[5].Rows)
                            {
                                if (txtAuthors.Text == string.Empty)
                                {
                                    txtAuthors.Text = drAuthors[0].ToString();
                                }
                                else
                                {
                                    txtAuthors.Text = txtAuthors.Text + "," + drAuthors[0];
                                }
                            }

                        }
                        //Displaying project related data for the event based project id
                        //dsProjectDetails = clsEvent.FetchProjectDetailsForEvent(intPrjID);
                        if (objClsEvent.FetchProjectDetailsForEvent("GET_MUR_Project", "@p_Project_ID", Convert.ToInt32(intPrjID), ref dsProjectDetails))
                        {
                            foreach (DataRow drProjectDetails in dsProjectDetails.Tables[0].Rows)
                            {
                                lblSelCategory.Text = drProjectDetails[6].ToString();
                                //Displaying a particular item in the category drop down
                                drpCategoryDB.SelectedValue = drProjectDetails[8].ToString();
                                lblBrandValue.Text = drProjectDetails[3].ToString();
                                lblPrjTypeValue.Text = drProjectDetails[2].ToString();
                                lblPrjLeaderValue.Text = drProjectDetails[4].ToString();
                                lblPOCValue.Text = drProjectDetails[5].ToString();
                                lblOriginatorValue.Text = drProjectDetails[7].ToString();
                            }
                        }

                        //filling up brand segments based on the category id 
                        FillBrandSegments(Convert.ToInt32(drpCategoryDB.SelectedValue));
                        drpBrandSegmentDB.SelectedValue = intBrandSegmentID.ToString();

                        //filling projects based on brand segments
                        PopulateProjectDropDown(Convert.ToInt32(drpCategoryDB.SelectedValue), Convert.ToInt32(intBrandSegmentID));
                        drpProject.SelectedValue = intPrjID.ToString();

                        //filling of History details in the datagrid.
                        FillHistoryGrid(Request.QueryString["EventID"]);

                        //Showing a paper machine line machine type details
                        FillDropDownWithMachines(3, Convert.ToInt32(drpPlant.SelectedValue), 0, "Machine_Name", "Machine_ID", "Select a Paper Machine", drpPaper);
                        drpPaper.Items.FindByValue(Convert.ToString(intPaperMachineID)).Selected = true;

                        //Showing a converting line machine type details
                        FillDropDownWithMachines(2, Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpCategoryDB.SelectedValue), "Machine_Name", "Machine_ID", "Select a Converting Line", drpConLine);
                        //drpConLine.SelectedValue = intConvertingMachineID.ToString();
                        drpConLine.Items.FindByValue(Convert.ToString(intConvertingMachineID)).Selected = true;

                        //Showing a combining line machine type details
                        FillDropDownWithMachines(1, 0, 0, "Machine_Name", "Machine_ID", "Select a Combining line", drpComLine);                        
                        drpComLine.Items.FindByValue(Convert.ToString(intCombiningValue)).Selected = true;

                    }

                }
            }
            catch (Exception ex)
            {
                string script = null;
                script = "alert('" + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaion on ProjectName,EO Name,EventType,Plant and Desired start date
                if (drpCategoryDB.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["CategoryErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpBrandSegmentDB.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["BrandErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpProject.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["PrjNameSelectErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (string.IsNullOrEmpty(txtEOName.Text))
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["EventNameSelectErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpEventType.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["EvTypeSelectErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpPlant.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["PlantNameErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (string.IsNullOrEmpty(txtDate.Text))
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["DateErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (rdbOnhold.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDays.Text.Trim()))
                    {
                        string script = null;
                        script = "alert('Please enter # Days on Hold.');document.getElementById('txtDays').focus();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        return;

                    }
                    //"#Days on Hold should be greater than 3."
                    try
                    {
                        if (rdbOnhold.SelectedValue == "Y")
                        {
                            if (!string.IsNullOrEmpty(txtDays.Text.Trim()))
                            {
                                txtDays.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(txtDays.Text.Trim())));
                                if (Convert.ToInt32(txtDays.Text.Trim()) <= 3)
                                {
                                    string script = null;
                                    script = "alert('#Days on Hold should be greater than 3.');document.getElementById('txtDays').focus();";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
                string tempStr = null;
                tempStr = checkTotalLostdaysValidation();

                if (tempStr == "FALSE")
                {
                    string script = null;
                    script = "alert('Input is Not In Correct Format'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }



                //Validaion on machine types
                if (drpPaper.SelectedIndex == 0 && drpConLine.SelectedIndex == 0 && drpComLine.SelectedIndex == 0)
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["MachineErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                //Code for save project button
                if (rdbShippable.SelectedValue == "N")
                {
                    txtDays.Text = "0";
                }
                System.DateTime strDate = Convert.ToDateTime(txtDate.Text.Trim());

                CheckForNullValue();

                lblConLostValue.Text = txtConLostValue.Text;
                lblPLostValue.Text = txtPLostValue.Text;
                lblComLostValue.Text = txtComLostValue.Text;
                int intResult = 0;
                //int intResult = clsEvt.EventInsert(Convert.ToInt32(Request.QueryString["EventID"]), drpProject.SelectedValue.Trim, drpPlant.SelectedValue.Trim, txtEOName.Text.Trim, drpEventType.SelectedValue, strDate, rdbShippable.SelectedValue, Convert.ToDecimal(txtDays.Text.Trim), drpPaper.SelectedValue, 0,
                //0, 0, Convert.ToDecimal(lblPLostValue.Text.Trim), txtPComments.Text.Trim, drpConLine.SelectedValue, 0, 0, 0, Convert.ToDecimal(lblConLostValue.Text.Trim), txtConComments.Text.Trim,
                //drpComLine.SelectedValue, 0, 0, 0, Convert.ToDecimal(lblComLostValue.Text.Trim), txtAuthors.Text.Trim, "A", strUser);

                if (objClsEvent.EventInsertDAL(Convert.ToInt32(Request.QueryString["EventID"]),
                    Convert.ToInt32(drpProject.SelectedValue.Trim()),
                    Convert.ToInt32(drpPlant.SelectedValue.Trim()),
                    txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue.Trim()),
                    strDate,
                    rdbShippable.SelectedValue.ToString(),
                    Convert.ToDecimal(txtDays.Text.Trim()),
                    Convert.ToInt32(drpPaper.SelectedValue),
                    Convert.ToDecimal(0), Convert.ToDecimal(0),
                    Convert.ToDecimal(0), Convert.ToDecimal(lblPLostValue.Text.Trim()),
                    txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue),
                    Convert.ToDecimal(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(lblConLostValue.Text.Trim()),
                   txtConComments.Text.Trim(),
                    Convert.ToInt32(drpComLine.SelectedValue), Convert.ToDecimal(0),
                    Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(lblComLostValue.Text.Trim()),
                    txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
                {
                    if (intResult == 0)
                    {
                        string script = null;
                        script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "'); window.location.href=\'../Common/Home.aspx\'; ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (intResult == 1)
                    {
                        string script = null;
                        script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else
                    {
                        string script = null;
                        script = "alert('" + ConfigurationManager.AppSettings["EventInsertErrMsg"] + "'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void calc_Click(object sender, EventArgs e)
        {
            string jvscript = null;
            jvscript = "CalculateLostDays(); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", jvscript, true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int intResult = 0;
            //int intResult = clsEvt.EventInsert(Request.QueryString["EventID"], 0, 0, 0, 0, "", 0, 0, 0, 0,
            //0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //0, 0, 0, 0, 0, 0, "I", strUser);

            //if (objClsEvent.EventInsertDAL(Convert.ToInt32(Request.QueryString["EventID"]),
            //        Convert.ToInt32(drpProject.SelectedValue.Trim()),
            //        Convert.ToInt32(drpPlant.SelectedValue.Trim()),
            //        txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue.Trim()),
            //        strDate,
            //        rdbShippable.SelectedValue.ToString(),
            //        Convert.ToDecimal(txtDays.Text.Trim()),
            //        Convert.ToInt32(drpPaper.SelectedValue),
            //        Convert.ToDecimal(0), Convert.ToDecimal(0),
            //        Convert.ToDecimal(0), Convert.ToDecimal(lblPLostValue.Text.Trim()),
            //        txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue),
            //        Convert.ToDecimal(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(lblConLostValue.Text.Trim()),
            //       txtConComments.Text.Trim(),
            //        Convert.ToInt32(drpComLine.SelectedValue), Convert.ToDecimal(0),
            //        Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(lblComLostValue.Text.Trim()),
            //        txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
            if (objClsEvent.EventInsertDAL(Convert.ToInt32(Request.QueryString["EventID"]), 0, 0,
                "0", 0, Convert.ToDateTime(""), "0", 0, 0, 0,
            0, 0, 0, "0", 0, 0, 0, 0, 0,
            "0", 0, 0, 0, 0, 0, "0", "I", strUser, ref paramOut))
            {
                if ((intResult == 0))
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["DeleteSuccessMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["DeleteErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }

        protected void imgMigSiteTest_Click(object sender, EventArgs e)
        {
            try
            {
                string strWHBCType = null;
                int intWHBCType = 0;
                bool boolWHBC = false;
                bool boolSimpleSiteTest = false;

                int strEventID = 0;
                //Below options are for checking the event details before they are saved in the database.
                if (drpCategoryDB.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["CategoryErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpBrandSegmentDB.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["BrandErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpProject.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["PrjNameSelectErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (string.IsNullOrEmpty(txtEOName.Text))
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["EventNameSelectErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpEventType.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["EvTypeSelectErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (drpPlant.SelectedValue == "0")
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["PlantNameErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                if (string.IsNullOrEmpty(txtDate.Text))
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["DateErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                if (rdbOnhold.SelectedValue == "Y")
                {
                    if (string.IsNullOrEmpty(txtDays.Text.Trim()))
                    {
                        string script = null;
                        script = "alert('Please enter # Days on Hold.');document.getElementById('txtDays').focus();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        return;

                    }
                    //"#Days on Hold should be greater than 3."
                    try
                    {
                        if (rdbOnhold.SelectedValue == "Y")
                        {
                            if (!string.IsNullOrEmpty(txtDays.Text.Trim()))
                            {
                                if (Convert.ToInt32(txtDays.Text.Trim()) <= 3)
                                {
                                    string script = null;
                                    script = "alert('#Days on Hold should be greater than 3.');document.getElementById('txtDays').focus();";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                //Validaion on machine types
                if (drpPaper.SelectedIndex == 0 && drpConLine.SelectedIndex == 0 && drpComLine.SelectedIndex == 0)
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["MachineErrMsg"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                string tempStr = null;
                tempStr = checkTotalLostdaysValidation();

                if (tempStr == "FALSE")
                {
                    string script = null;
                    script = "alert('Input is Not In Correct Format'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                //Code for save project button
                if (rdbShippable.SelectedValue == "N")
                {
                    txtDays.Text = "0";
                }
                System.DateTime strDate = Convert.ToDateTime(txtDate.Text.Trim());

                CheckForNullValue();

                //Checking whether the user has selected WHBC plant site and event type as site test.
                if (drpEventType.SelectedItem.Text.ToUpper() == "site test".ToUpper() && drpPlant.SelectedItem.Text.ToUpper() != "WHBC")
                {
                    boolSimpleSiteTest = true;
                }
                else if (drpEventType.SelectedItem.Text.ToUpper() == "site test".ToUpper() && drpPlant.SelectedItem.Text.ToUpper() == "WHBC")
                {
                    boolWHBC = true;
                }

                if (boolSimpleSiteTest == false && boolWHBC == false)
                {
                    string script = null;
                    script = "alert('For migration to site test WHBC value for Plant and SiteTest for Event type  or atleast SiteTest for Event type has to be selected.');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                if (drpPaper.SelectedIndex > 0 && drpConLine.SelectedIndex > 0 && boolWHBC == true)
                {
                    string script = null;
                    script = "alert('Please select only one machine for migration to site test'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpPaper.SelectedIndex > 0 && boolWHBC == true)
                {
                    strWHBCType = "WHBC Paper Machine";
                    intWHBCType = 1;
                }
                else if (drpConLine.SelectedIndex > 0 && boolWHBC == true)
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
                int intResult = 0;
                //Dim intResult As Integer = clsEvt.EventInsert(0, drpProject.SelectedValue.Trim, drpPlant.SelectedValue.Trim, txtEOName.Text.Trim, drpEventType.SelectedValue, strDate, rdbShippable.SelectedValue, txtDays.Text.Trim, drpPaper.SelectedValue, txtPDowntime.Text.Trim, txtPUptime.Text.Trim, Convert.ToDecimal(txtPTons.Text.Trim), lblPLostValue.Text.Trim, txtPComments.Text.Trim, drpConLine.SelectedValue, txtConDownTime.Text.Trim, txtConUpTime.Text.Trim, Convert.ToDecimal(txtConBroke.Text.Trim), lblConLostValue.Text.Trim, txtConComments.Text.Trim, drpComLine.SelectedValue, txtComDownTime.Text.Trim, txtComUpTime.Text.Trim, Convert.ToDecimal(txtComBroke.Text.Trim), lblComLostValue.Text.Trim, txtAuthors.Text.Trim, "A", strUser)


                if (objClsEvent.EventInsertDAL(Convert.ToInt32(Request.QueryString["EventID"]),
       Convert.ToInt32(drpProject.SelectedValue.Trim()),
       Convert.ToInt32(drpPlant.SelectedValue.Trim()),
       txtEOName.Text.Trim(), Convert.ToInt32(drpEventType.SelectedValue.Trim()),
       strDate,
       rdbShippable.SelectedValue.ToString(),
       Convert.ToDecimal(txtDays.Text.Trim()),
       Convert.ToInt32(drpPaper.SelectedValue),
       Convert.ToDecimal(0), Convert.ToDecimal(0),
       Convert.ToDecimal(0), Convert.ToDecimal(lblPLostValue.Text.Trim()),
       txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue),
       Convert.ToDecimal(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(lblConLostValue.Text.Trim()),
      txtConComments.Text.Trim(),
       Convert.ToInt32(drpComLine.SelectedValue), Convert.ToDecimal(0),
       Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(lblComLostValue.Text.Trim()),
       txtAuthors.Text.Trim(), "A", strUser, ref paramOut))
                {


                    if (intResult == 0)
                    {
                        //Success Message
                        string script = null;
                        script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (intResult == 1)
                    {
                        string script = null;
                        script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else
                    {
                        //Failure Message
                        string script = null;
                        script = "alert('" + ConfigurationManager.AppSettings["EventInsertErrMsg"] + "'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }

                    if (intResult == 0)
                    {
                        strEventID = Convert.ToInt32(Request.QueryString["EventID"]);
                        //assigning the event id
                        insertMandatory(strEventID.ToString());
                        int intEOID = Convert.ToInt32(ViewState["EID"]);
                        Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}&StartDate={3}&PlantType={4}", "EDIT", intEOID, "MigrSt", Convert.ToDateTime(txtDate.Text.Trim()).ToShortDateString(), intWHBCType));

                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        public void insertMandatory(string eventID)
        {
            DataSet dsSeedDataByEventID = null;
            //dsSeedDataByEventID = ClsEO.GETEOSeedDataByEventIDs(eventID);

            int Eo_ID = 0;
            ObjSiteTest objst = new ObjSiteTest();
            string strSelEventname = null;
            strSelEventname = txtEOName.Text.Trim();
            try
            {
                if (strSelEventname.Length > 15)
                {
                    strSelEventname = strSelEventname.Substring(0, 15);
                }
            }
            catch (Exception ex)
            {
            }
            objst.EOID = "0";
            objst.StageStatus = DBNull.Value.ToString();
            objst.CurrentStage = DBNull.Value.ToString();
            if (!string.IsNullOrEmpty(strSelEventname.Trim()))
            {
                objst.Title = strSelEventname;
            }
            else
            {
                objst.Title = "NewSitetest" + System.DateTime.Now;
                //DBNull.Value.ToString
            }

            if (!string.IsNullOrEmpty(eventID))
            {
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
            try
            {
                if (objEOBA.GETEOSeedDataByEventIDs(eventID, ref dsSeedDataByEventID))
                {
                    if ((dsSeedDataByEventID != null))
                    {
                        if (!(dsSeedDataByEventID.Tables.Count == 0))
                        {
                            if (!(dsSeedDataByEventID.Tables[0].Rows.Count == 0))
                            {
                                try
                                {
                                    objst.CategoryID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["CATEGORY_ID"]);
                                    objst.Brands = dsSeedDataByEventID.Tables[0].Rows[0]["BRAND_SEGMENT_ID"].ToString();
                                    objst.ProjectID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["PROJECT_ID"]);
                                    objst.PlantID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["PLANT_ID"]);
                                }
                                catch (Exception ex)
                                {
                                }
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
                //Eo_ID = siteTest.SetEOMandatory(objst);
                if (objSiteTestBA.SetEOMandatory(objst, ref paramOut))
                {
                    Eo_ID = Convert.ToInt32(paramOut[0].Value);
                }
                ViewState["EID"] = Eo_ID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected string checkTotalLostdaysValidation()
        {
            string tempStr = "TRUE";
            int tempInt = 0;
            if (!string.IsNullOrEmpty(txtPLostValue.Text.Trim()))
            {
                try
                {
                    if(!string.IsNullOrEmpty(txtPLostValue.Text))
                    tempInt = Convert.ToInt32(Convert.ToDouble(txtPLostValue.Text.Trim()));
                    if (tempInt < 0)
                    {
                        tempStr = "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    tempStr = "FALSE";
                }
            }
            if (!string.IsNullOrEmpty(txtConLostValue.Text.Trim()))
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtConLostValue.Text))
                    tempInt =Convert.ToInt32(Convert.ToDouble(txtConLostValue.Text.Trim()));

                    if (tempInt < 0)
                    {
                        tempStr = "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    tempStr = "FALSE";
                }
            }

            if (!string.IsNullOrEmpty(txtComLostValue.Text.Trim()))
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtComLostValue.Text))
                        tempInt = Convert.ToInt32(Convert.ToDouble(txtComLostValue.Text.Trim()));                    
                    if (tempInt < 0)
                    {
                        tempStr = "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    tempStr = "FALSE";
                }
            }

            return tempStr;

        }

        protected void imgDeleteName_Click(object sender, EventArgs e)
        {
            txtAuthors.Text = "";
        }

        public void EmptyProject()
        {
            strJavaScript = "alert('" + ConfigurationManager.AppSettings["ProjectsEmpty"] + "')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strJavaScript, true);
        }

        public void PopulateProjectDropDown(int parCategoryID, int parBrandSegmentID)
        {
            drpProject.Items.Clear();
            dsProject = new DataSet();
            //dsProject = clsProject.FillDropDownWithProjects("GET_MUR_Projects_By_Category_Brand_Segment", parCategoryID, parBrandSegmentID);
            if (objClsEvent.FillDropDownWithProjects(parCategoryID, parBrandSegmentID, ref dsProject, "GET_MUR_Projects_By_Category_Brand_Segment"))
            {
                if (dsProject.Tables.Count == 0)
                {
                    EmptyProject();
                    drpProject.Items.Insert(0, new ListItem("None", "0"));
                    ClearProjectInfo();
                    return;
                }
                else if (dsProject.Tables[0].Rows.Count == 0)
                {
                    EmptyProject();
                    drpProject.Items.Insert(0,new ListItem("None","0"));
                    ClearProjectInfo();
                    return;
                }
                drpProject.DataSource = dsProject.Tables[0].DefaultView;
                drpProject.DataTextField = "Project_Name";
                drpProject.DataValueField = "Project_ID";
                drpProject.DataBind();
                drpProject.Items.Insert(0,new ListItem("Select a Project","0"));
                drpProject.Items[0].Value = "0";
            }
        }

        public void CheckForNullValue()
        {
            //setting for shipping days
            if (txtDays.Text == string.Empty)
            {
                txtDays.Text = "0";
            }
            if (txtPLostValue.Text == string.Empty)
            {
                txtPLostValue.Text = "0";
            }

            if (txtConLostValue.Text == string.Empty)
            {
                txtConLostValue.Text = "0";
            }

            if (txtComLostValue.Text == string.Empty)
            {
                txtComLostValue.Text = "0";
            }

        }

        public void FillDropDownWithPlantorEvent(string SqlText, string spParameter, int parPlantEventID, string colValue, string colText, string optionalValue, string ErrMessage, DropDownList drpName)
        {
            dsPlantorEvent = new DataSet();
            //dsPlantorEvent = clsEvent.FetchAllPlantsorEvents(SqlText, spParameter, parPlantEventID);
            if (objClsEvent.FetchAllPlantsorEvents(SqlText, spParameter, parPlantEventID, ref dsPlantorEvent))
            {
                if (dsPlantorEvent.Tables.Count == 0)
                {
                    EmptyDataMessage(ErrMessage);
                    drpName.Items.Insert(0, new ListItem("None", "0"));                    
                    drpName.Items[0].Value = "0";
                    return;
                }
                else if (dsPlantorEvent.Tables[0].Rows.Count == 0)
                {
                    EmptyDataMessage(ErrMessage);
                    drpName.Items.Insert(0, new ListItem("None", "0"));
                    drpName.Items[0].Value = "0";
                    return;
                }
                else
                {
                    drpName.DataSource = dsPlantorEvent.Tables[0].DefaultView;
                    drpName.DataTextField = colText;
                    drpName.DataValueField = colValue;
                    drpName.DataBind();
                    drpName.Items.Insert(0, new ListItem(optionalValue, "0"));
                    drpName.Items[0].Value = "0";
                }
            }
        }

        public void FillDropDownWithMachines(int MachineType, int PlantId, int CategoryId, string colText, string colValue, string optionalValue, DropDownList drpName)
        {
            drpName.Items.Clear();
            dsMachine = new DataSet();
            //dsMachine = clsProject.FetchMachines(MachineType, PlantId, CategoryId);
            if (objClsEvent.FetchMachines(MachineType, PlantId, CategoryId, ref dsMachine, "GET_MUR_Machine_Tree_View_Details"))
            {
                if (dsMachine.Tables.Count == 0)
                {
                    //EmptyDataMessage("Machine does not exist(s) for the selected value.")
                    drpName.Items.Insert(0, new ListItem("None", "0"));
                    drpName.Items[0].Value = "0";
                }
                else if (dsMachine.Tables[0].Rows.Count == 0)
                {
                    //EmptyDataMessage("Machine does not exist(s) for the selected value.")
                    drpName.Items.Insert(0, new ListItem("None", "0"));
                    drpName.Items[0].Value = "0";
                }
                else
                {
                    drpName.DataSource = dsMachine.Tables[0].DefaultView;
                    drpName.DataTextField = colText;
                    drpName.DataValueField = colValue;
                    drpName.DataBind();                  
                    drpName.Items.Insert(0, new ListItem(optionalValue, "0"));
                    drpName.Items[0].Value = "0";
                }
                if (PlantId == 0 & MachineType != 1)
                {
                    ClearPaperMachineInfo();
                }
            }
        }

        public void EmptyDataMessage(string strMess)
        {
            strJavaScript = "alert('" + strMess + "')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strJavaScript, true);
        }

        public void FillDropDownPaperMachine()
        {
            drpPaper.Items.Clear();
            //Else
            dsPaper = new DataSet();
            //dsPaper = clsProject.FillDropDownWithPaperMachine("Get_MUR_Machine_By_Plant", drpPlant.SelectedValue);
            if (objEOBA.FillDropDownWithPaperMachine(Convert.ToInt32(drpPlant.SelectedValue), ref dsCheckUser))
            {
                if (dsPaper.Tables.Count == 0)
                {
                    EmptyDataMessage("Paper Machine does not exist(s) for the selected Plant");                   
                    drpPaper.Items.Insert(0, new ListItem("None", "0"));
                    drpPaper.Items[0].Value = "0";
                    return;
                }
                else if (dsPaper.Tables[0].Rows.Count == 0)
                {
                    EmptyDataMessage("Paper Machine does not exist(s) for the selected Plant");
                    drpPaper.Items.Insert(0, new ListItem("None", "0"));
                    drpPaper.Items[0].Value = "0";
                    return;
                }
                drpPaper.DataSource = dsPaper.Tables[0].DefaultView;
                drpPaper.DataTextField = "Machine_Name";
                drpPaper.DataValueField = "Machine_ID";
                drpPaper.DataBind();
                drpPaper.Items.Insert(0, new ListItem("Select a Paper Machine", "0"));
                drpPaper.Items[0].Value = "0";
            }
        }

        public void FillDropDownConvertingLine()
        {
            drpConLine.Items.Clear();
            //Else
            dsConLine = new DataSet();
            //dsConLine = clsProject.FillDropDownWithConvertingMachine("GET_MUR_Machine_By_Plant_Category", drpCategoryDB.SelectedValue, drpPlant.SelectedValue);
            if (objEOBA.FillDropDownWithConvertingMachine(Convert.ToInt32(drpCategoryDB.SelectedValue), drpPlant.SelectedValue, ref dsConLine))
            {
                if (dsConLine.Tables.Count == 0)
                {
                    EmptyDataMessage("Paper Machine does not exist(s) for the selected Plant");                    
                    drpConLine.Items.Insert(0, new ListItem("None", "0"));
                    drpConLine.Items[0].Value = "0";
                    return;
                }
                else if (dsConLine.Tables[0].Rows.Count == 0)
                {
                    EmptyDataMessage("Converting Line does not exist(s) for the selected Category and Plant");
                    drpConLine.Items.Insert(0, new ListItem("None", "0"));
                    drpConLine.Items[0].Value = "0";
                    return;
                }
                drpConLine.DataSource = dsConLine.Tables[0].DefaultView;
                drpConLine.DataTextField = "Machine_Name";
                drpConLine.DataValueField = "Machine_ID";
                drpConLine.DataBind();                
                drpConLine.Items.Insert(0, new ListItem("Select a Converting Line", "0"));
                drpConLine.Items[0].Value = "0";
            }
        }

        public void FillHistoryGrid(string parEventID)
        {
            dsHistory = new DataSet();
            //dsHistory = clsEvent.FillHistoryofEvent(parEventID);
            if (objClsEvent.FetchEventDetails(Convert.ToInt32(parEventID), ref dsHistory))
            {
                dgdShowHistory.DataSource = dsHistory.Tables[4].DefaultView;
                dgdShowHistory.DataBind();
            }
        }

        public void EmptyData()
        {
            strJavaScript = "alert('" + ConfigurationManager.AppSettings["EventsBrandSegmentsEmpty"] + "')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strJavaScript, true);
        }

        public void FillBrandSegments(int parCategoryid)
        {
            if (parCategoryid != 0)
            {
                drpBrandSegmentDB.Items.Clear();
                //Else
                dsBrand = new DataSet();
                //dsBrand = clsProject.FillDropDownWithBrands("GET_MUR_BRAND_Segment_By_Category", parCategoryid);
                if (objEOBA.FillDropDownWithBrands(parCategoryid, ref dsBrand))
                {

                    DataRow drBrand = null;
                    //drBrand = dsBrand.Tables[0].Rows
                    if (dsBrand.Tables.Count == 0)
                    {
                        EmptyData();
                        
                        drpBrandSegmentDB.Items.Insert(0, new ListItem("None", "0"));
                        drpBrandSegmentDB.Items[0].Value = "0";
                        //Clearing the Project Info as they are indirectly related with Category.
                        drpProject.Items.Clear();
                        drpProject.Items.Insert(0, new ListItem("None", "0"));
                        drpProject.Items[0].Value = "0";
                        //Clearing the project information.
                        ClearProjectInfo();
                    }
                    else if (dsBrand.Tables[0].Rows.Count == 0)
                    {
                        EmptyData();
                        drpBrandSegmentDB.Items.Insert(0, new ListItem("None", "0"));
                        drpBrandSegmentDB.Items[0].Value = "0";
                        //Clearing the Project Info as they are indirectly related with Category.
                        drpProject.Items.Clear();
                        drpProject.Items.Insert(0, new ListItem("None", "0"));
                        drpProject.Items[0].Value = "0";
                        //Clearing the project information.
                        ClearProjectInfo();
                    }
                    else
                    {
                        drpBrandSegmentDB.DataSource = dsBrand.Tables[0].DefaultView;
                        drpBrandSegmentDB.DataTextField = "Brand_Segment_Name";
                        drpBrandSegmentDB.DataValueField = "Brand_Segment_ID";
                        drpBrandSegmentDB.DataBind();                
                        drpBrandSegmentDB.Items.Insert(0, new ListItem("Select a Brand Segment", "0"));
                        drpBrandSegmentDB.Items[0].Value = "0";
                    }
                }
            }
            else
            {
                drpBrandSegmentDB.Items.Clear();
                drpBrandSegmentDB.Items.Insert(0, new ListItem("None", "0"));
                drpBrandSegmentDB.Items[0].Value = "0";
                //Clearing the converting lines machines.
                drpConLine.Items.Clear();                
                drpConLine.Items.Insert(0, new ListItem("None", "0"));
                drpConLine.Items[0].Value = "0";
                ClearConvertingMachineInfo();
                //Clearing the Project Info as they are indirectly related with Category.
                drpProject.Items.Clear();
                drpProject.Items.Insert(0, new ListItem("None", "0"));
                drpProject.Items[0].Value = "0";
                //Clearing the project information.
                ClearProjectInfo();
            }
        }

        public void FillDropDownData(string colName1, string colName2, string optionalValue, DropDownList drpName)
        {
            dsSeedData = new DataSet();
            //dsSeedData = clsProject.FillDropDownSeedData("GET_MUR_Category");
            if (objEOBA.FillDropDownSeedData(ref dsSeedData))
            {
                //For Each dtRow As DataRow In dsSeedData.Tables[0].Rows
                drpName.DataSource = dsSeedData.Tables[0].DefaultView;
                drpName.DataTextField = colName1;
                drpName.DataValueField = colName2;
                drpName.DataBind();              
                drpName.Items.Insert(0, new ListItem(optionalValue, "0"));
                drpName.Items[0].Value = "0";
            }
        }

        //Method for Populating values into dropdown
        //public void FillDropdown1(string sqlText, DropDownList drp)
        //{
        //    //Method for Populating values into dropdown
        //    drp.Items.Clear();
        //    //SqlDataReader drField = default(SqlDataReader);
        //    DataSet drField = new DataSet();

        //    if (drp.ID == "drpProject")
        //    {
        //        //drField = clsPrj.GetDr(sqlText, "@p_Project_ID", 0);
        //        if (objClsEvent.FetchProjectDetailsForEvent(sqlText, "@p_Project_ID", 0, ref drField))
        //        { }

        //        drp.Items.Insert(0, "Select a Project");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpPlant")
        //    {
        //        drField = clsPrj.GetDr(sqlText, "@p_Plant_ID", 0);
        //        drp.Items.Insert(0, "Select a Plant");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpEventType")
        //    {
        //        drField = clsPrj.GetDr(sqlText, "@p_Event_Type_ID", 0);
        //        drp.Items.Insert(0, "Select Event Type");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpComLine")
        //    {
        //        drField = clsPrj.GetDrCombiningMahcine(sqlText, "@p_Machine_Type_ID", 1);
        //        // "@p_Plant_ID", drpPlant.SelectedValue)
        //        drp.Items.Insert(0, "None");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpConLine")
        //    {
        //        drField = clsPrj.GetDrMachine(sqlText, "@p_Category_ID", drpCategoryDB.SelectedValue, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "None");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpPaper")
        //    {
        //        drField = clsPrj.GetDrPlantMachine(sqlText, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "Select Plant First");
        //        drp.Items[0].Value = "0";
        //    }

        //    //if (drField.HasRows)
        //    //{
        //    //    while (drField.Read)
        //    //    {
        //    //        ListItem lstItem = new ListItem();
        //    //        lstItem.Text = drField.GetString(1).ToString;
        //    //        if (drp.ID == "drpPrjType")
        //    //        {
        //    //            lstItem.Value = drField.GetByte(0);
        //    //        }
        //    //        else
        //    //        {
        //    //            lstItem.Value = drField.GetInt32(0);
        //    //        }
        //    //        drp.Items.Add(lstItem);
        //    //    }
        //    //}

        //    //drField.Close();
        //}

        //public void FillDropdown(string sqlText, DropDownList drp, int drpValue)
        //{
        //    drp.Items.Clear();
        //    SqlDataReader drField = default(SqlDataReader);
        //    if (drp.ID == "drpComLine" & sqlText == "GET_MUR_Machine_By_MType_Plant")
        //    {
        //        drField = clsPrj.GetDrMachine(sqlText, "@p_Machine_Type_ID", 1, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "None");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpConLine" & sqlText == "GET_MUR_Machine_By_MType_Plant")
        //    {
        //        drField = clsPrj.GetDrMachine(sqlText, "@p_Machine_Type_ID", 2, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "None");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpPaper" & sqlText == "GET_MUR_Machine_By_MType_Plant")
        //    {
        //        drField = clsPrj.GetDrMachine(sqlText, "@p_Machine_Type_ID", 3, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "Select Plant First");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpProject")
        //    {
        //        drField = clsPrj.GetDr(sqlText, "@p_Project_ID", 0);
        //        drp.Items.Insert(0, "Select a Project");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpPlant")
        //    {
        //        drField = clsPrj.GetDr(sqlText, "@p_Plant_ID", 0);
        //        drp.Items.Insert(0, "Select a Plant");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpEventType")
        //    {
        //        drField = clsPrj.GetDr(sqlText, "@p_Event_Type_ID", 0);
        //        drp.Items.Insert(0, "Select Event Type");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpComLine")
        //    {
        //        drField = clsPrj.GetDrMachine(sqlText, "@p_Machine_ID", 0, "@p_Machine_Type_ID", 1);
        //        drp.Items.Insert(0, "None");
        //        drp.Items[0].Value = "0";

        //    }
        //    else if (drp.ID == "drpConLine")
        //    {
        //        drField = clsPrj.GetDrMachine(sqlText, "@p_Category_ID", drpCategoryDB.SelectedValue, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "None");
        //        drp.Items[0].Value = "0";
        //    }
        //    else if (drp.ID == "drpPaper")
        //    {
        //        drField = clsPrj.GetDrPlantMachine(sqlText, "@p_Plant_ID", drpPlant.SelectedValue);
        //        drp.Items.Insert(0, "Select Plant First");
        //        drp.Items[0].Value = "0";
        //    }

        //    if (drField.HasRows)
        //    {
        //        while (drField.Read)
        //        {
        //            ListItem lstItem = new ListItem();
        //            lstItem.Text = drField.GetString(1).ToString();
        //            if (drp.ID == "drpPrjType")
        //            {
        //                lstItem.Value = drField.GetByte(0);
        //            }
        //            else
        //            {
        //                lstItem.Value = drField.GetInt32(0);
        //            }
        //            if (lstItem.Value == drpValue)
        //            {
        //                lstItem.Selected = true;
        //            }
        //            drp.Items.Add(lstItem);
        //        }
        //    }

        //    drField.Close();
        //}

        public void ClearProjectInfo()
        {
            lblSelCategory.Text = string.Empty;
            lblBrandValue.Text = string.Empty;
            lblPrjTypeValue.Text = string.Empty;
            lblPrjLeaderValue.Text = string.Empty;
            lblPOCValue.Text = string.Empty;
            lblOriginatorValue.Text = string.Empty;
        }

        public void ClearPaperMachineInfo()
        {
            txtPLostValue.Text = "0";
            lblPLostValue.Text = "0";
        }

        public void ClearConvertingMachineInfo()
        {
            txtConLostValue.Text = "0";
            lblConLostValue.Text = "0";
        }

        protected void drpBrandSegmentDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCategoryID = 0;
            int intBrandSegmentID = 0;
            intCategoryID = Convert.ToInt32(drpCategoryDB.SelectedValue);
            intBrandSegmentID = Convert.ToInt32(drpBrandSegmentDB.SelectedValue);
            PopulateProjectDropDown(intCategoryID, intBrandSegmentID);
        }

        protected void drpCategoryDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBrandSegments(Convert.ToInt32(drpCategoryDB.SelectedValue));
            //populating paper machines.
            if (drpPlant.SelectedIndex > 0 & drpCategoryDB.SelectedIndex > 0)
            {
                //filling of converting line
                FillDropDownWithMachines(2, Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpCategoryDB.SelectedValue), "Machine_Name", "Machine_ID", "Select a Converting Line", drpConLine);
            }

        }

        protected void rdbShippable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting visibility of onhold radiobutton field based on product shippable value
            if (rdbShippable.SelectedValue == "Y")
            {
                lblGDays.Visible = true;
                //tdrdbDays.Style.Value = "display:block";
                rdbOnhold.Visible = true;
                //Added By Abdul
                rdbOnhold.SelectedValue = "N";
            }
            else
            {
                lblGDays.Visible = false;
                //tdrdbDays.Style.Value = "display:none";
                rdbOnhold.Visible = false;
                lblDays.Visible = false;
                txtDays.Visible = false;
                //Added By Abdul
                rdbOnhold.SelectedValue = "N";
            }
        }

        protected void rdbOnhold_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setting visibility of onhold days field based on onhold radiobutton value
            if (rdbOnhold.SelectedValue == "Y")
            {
                lblDays.Visible = true;
                txtDays.Visible = true;
            }
            else
            {
                lblDays.Visible = false;
                txtDays.Visible = false;
                //added by abdul to rectify the error of shipping value when selected as no.
                txtDays.Text = "";
            }
        }

        protected void drpPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCategoryDB.SelectedIndex > 0 && drpPlant.SelectedIndex > 0)
            {
                FillDropDownWithMachines(2, Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpCategoryDB.SelectedValue), "Machine_Name", "Machine_ID", "Select a Converting Line", drpConLine);
            }
            else
            {
                //clearing the converting line
                drpConLine.Items.Clear();
                drpConLine.Items.Insert(0, new ListItem("None", "0"));                
                drpConLine.Items[0].Value = "0";
                ClearConvertingMachineInfo();
            }
            //Filling paper machine.
            FillDropDownWithMachines(3, Convert.ToInt32(drpPlant.SelectedValue), 0, "Machine_Name", "Machine_ID", "Select a Paper Machine", drpPaper);
        }

        protected void drpProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpProject.SelectedIndex > 0)
            {
                dsProjectInfo = new DataSet();
                //dsProjectInfo = clsEvent.FetchProjectDetailsForEvent(drpProject.SelectedValue);
                if (objClsEvent.FetchProjectDetailsForEvent("GET_MUR_Project", "@p_Project_ID", Convert.ToInt32(drpProject.SelectedValue), ref dsProjectInfo))
                {
                    if (dsProjectInfo == null)
                    {
                        EmptyDataMessage("Project information for the selected Project is not available");
                    }
                    else if (dsProjectInfo.Tables.Count == 0)
                    {
                        EmptyDataMessage("Project information for the selected Project is not available");
                    }
                    else if (dsProjectInfo.Tables[0].Rows.Count == 0)
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
            else if (drpProject.SelectedIndex == 0)
            {
                ClearProjectInfo();
            }

        }

        protected void drpPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            //'To set Paper machine machine type values to zero
            lblPLostValue.Text = "0";
            txtPLostValue.Text = "0";
            txtPComments.Text = "";
        }

        protected void drpConLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //'To set converting line machine type values to zero
            lblConLostValue.Text = "0";
            txtConLostValue.Text = "0";
            txtConComments.Text = "";
        }

        protected void drpComLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //'To set combining line machine type values to zero

            lblComLostValue.Text = "0";
            txtComLostValue.Text = "0";
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        protected void DeleteEvent()
        {
            string script = null;
            int intResult = 0;
            //int intConfResult = clsEvt.CountForDeletion(Request.QueryString["EventID"], strUser);
            //int intResult = clsEvt.DeleteEvent(Request.QueryString["EventID"], strUser);
            if (clsEvt.CountForDeletion(Convert.ToInt32(Request.QueryString["EventID"]), strUser, ref paramOut))
            {
                intResult = Convert.ToInt32(paramOut[0].Value);
            }
            if (intResult > 0)
            {
                script = "alert('Event could not be deleted.');";
                //script = script + "window.location='../Common/Home.aspx' "
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            else
            {
               
                if ((intResult == 0))
                {
                    script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');";
                    script = script + "window.location='../Common/Home.aspx' ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                }
                else
                {
                    script = "alert('" + ConfigurationManager.AppSettings["DeleteError"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }

    }
}