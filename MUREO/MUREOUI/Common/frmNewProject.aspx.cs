using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using MUREOBAL;
using System.Configuration;
using MUREOUI.Common;


namespace MUREOUI
{

    public partial class frmNewProject : System.Web.UI.Page
    {
        //string constr = System.Configuration.ConfigurationManager.ConnectionStrings["mureoConnectionString"].ConnectionString;
        #region Declaration
            string sqlText;
        string strUser;

        clsProject clsPrj = new clsProject(); 
        clsSecurity objSecurity = new clsSecurity();
        
        string script;
        //added by abdul
        DataSet dsHistory;
        DataSet dsCategory;
        DataSet dsProjectType;
        DataSet dsBrand;
        DataSet dsProject;
        int intCategoryValue;
        int intBrandSegmentValue;
        int intProjectTypeValue;
        static string strUserRole;
        DataSet dsCheckUser;
        string strCreatedUser;
        bool boolAllowPOC = false;
        string strProjectLead;
        bool boolAllowProjectLead = false;
        bool boolAllowCreated = false;
        #endregion
        MUREOBO objMureoBo = new MUREOBO();
        SqlParameter[] paramOut = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            strUserRole = objSecurity.UserRole();
            try
            {
                if (!string.IsNullOrEmpty(hdnPOC.Value))
                {
                    txtPOC.Text = hdnPOC.Value;
                }
                if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
                {
                    txtPrjLead.Text = hdntxtPrjLead.Value;
                }
                SqlParameter[] paramOut = null;
                //Page.SmartNavigation = True;
                strUser = objSecurity.UserName;
                //test
                int Project_ID=Convert.ToInt32( Request.QueryString["ProjectID"]);
                Session["PrjID"] = Project_ID;
                if (clsPrj.GetEventsCount(Project_ID, ref paramOut))
                {
                    int intResult=Convert.ToInt32(paramOut[0].Value.ToString());
                    // Code for calling address book functionality for projectLead and POC
                    imgLeadAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
                    imgPOCAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser1();");
                    int x = 1;
                    if ((intResult == 0))
                    {
                        imgDelete.Attributes.Add("onclick", "return confirm(\'Are you sure you want to delete the project? Click OK to delete or CANCEL to abort.\')" + ";");
                    }
                    // Confirm box for Deleting project lead and PoC names
                    // imgDeleteLead.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the project lead? Click OK to delete or CANCEL to abort.');")
                    // imgDeletePOC.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the POC? Click OK to delete or CANCEL to abort.');")
                    imgDeleteLead.Attributes.Add("onclick", "javascript:return ConfirmDelete(\'Are you sure you want to delete the project lead? Click OK to delete or CA" + "NCEL to abort.\',\'txtPrjLead\');");
                    imgDeletePOC.Attributes.Add("onclick", "javascript:return ConfirmDelete(\'Are you sure you want to delete the POC? Click OK to delete or CANCEL to a" + "bort.\',\'txtPOC\');");

                    // giving focus when required field is empty
                    imgSubmit.Attributes.Add("onclick", "ValidateFocus();");
                    imgSubmit_CreateNewProject.Attributes.Add("onclick", "ValidateFocus();");
                    if (!Page.IsPostBack)
                    {
                        
                        //test
                        ViewState["servername"]=Convert.ToString(ConfigurationManager.AppSettings["ServerName"]);
                        if ((Request.QueryString["Mode"] == "Edit"))
                        {
                            strUser = objSecurity.UserName;
                            strUserRole = objSecurity.UserRole();
                            dsCheckUser = new DataSet();
                            //test
                            clsProject clsprj = new clsProject();
                            if (clsprj.FetchProjectDetails(Convert.ToInt32(Request.QueryString["ProjectID"]), ref dsCheckUser))
                            {
                                // Getting the name of the created user 
                                strCreatedUser = dsCheckUser.Tables[0].Rows[0][7].ToString();
                                if ((strCreatedUser == strUser))
                                {
                                    // Response.Redirect("frmNewProject.aspx?ProjectID=" & Request.QueryString("ProjectID") + "&Mode=Edit")
                                    boolAllowCreated = true;
                                }
                                string strReadExistingNames;
                                string[] strDivideString;
                                strReadExistingNames = dsCheckUser.Tables[0].Rows[0][5].ToString();
                                if (!(strReadExistingNames == String.Empty))
                                {
                                    char[] delimiter1 = new char[] { ',' };
                                    strDivideString = strReadExistingNames.Split(delimiter1, strReadExistingNames.Length);
                                    for (int i = 0; (i <= (strDivideString.Length - 1)); i++)
                                    {
                                        if ((strUser == strDivideString[i]))
                                        {
                                            boolAllowPOC = true;
                                            break;
                                        }
                                    }
                                }
                                string strReadProjectLead;
                                string[] strDivideStringProjectlead;
                                strReadProjectLead = dsCheckUser.Tables[0].Rows[0][5].ToString();
                                if (!(strReadProjectLead == String.Empty))
                                {
                                    char[] delimiter1 = new char[] { ',' };
                                    strDivideStringProjectlead = strReadProjectLead.Split(delimiter1, strReadProjectLead.Length);
                                    for (int i = 0; (i
                                                <= (strDivideStringProjectlead.Length - 1)); i++)
                                    {
                                        if ((strUser == strDivideStringProjectlead[i]))
                                        {
                                            boolAllowProjectLead = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (((strUserRole == "mureo_admin") || ((boolAllowPOC == true) || ((boolAllowProjectLead == true) || (boolAllowCreated == true)))))
                            {
                                // Response.Redirect("frmNewProject.aspx?ProjectID=" & Request.QueryString("ProjectID") + "&Mode=Edit")
                                // ElseIf strUserRole = "MUREO_Editors" Then
                                //     Response.Redirect("frmEditEvent.aspx?EventID=" & Request.QueryString("EventID"))
                                // ElseIf strUserRole = "MUREO_Readers" Then
                                //     Dim script As String
                                //     script = "alert('Access Denied.\nYou donot have sufficient privelages to perform the operation.'); "
                                //     Page.RegisterStartupScript("   ", script)
                                // ElseIf strUserRole = "Readers" Then
                            }
                            else
                            {
                                string script;
                                script = "alert(\'Access Denied.\\nYou donot have sufficient privelages to perform the operation.\');windo" +
                                "window.location='Home.aspx'; ";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                                return;
                            }
                            imgDelete.Visible = true;
                            imgSubmit_CreateNewProject.Visible = false;
                            // New Code
                            dsProject = new DataSet();
                            if (clsPrj.FetchDataSetUsingSqlParameters(Project_ID, ref dsProject, "GET_MUR_Project", "@p_Project_ID"))
                            {
                                if (dsProject.Tables[0].Rows.Count == 0)
                                {
                                    NoData("Project details does not exist(s) in the database.");
                                    return;

                                }

                                foreach (DataRow drProject in dsProject.Tables[0].Rows)
                                {
                                    txtPrjName.Text = drProject.ItemArray[1].ToString();
                                    txtPrjLead.Text = drProject.ItemArray[4].ToString();
                                    txtPOC.Text = drProject.ItemArray[5].ToString();
                                    intCategoryValue = Convert.ToInt32(drProject.ItemArray[8].ToString());
                                    intBrandSegmentValue = Convert.ToInt32(drProject.ItemArray[9].ToString());
                                    intProjectTypeValue = Convert.ToInt32(drProject.ItemArray[10].ToString());
                                }
                                FillDropdownWithCategory();
                                drpCategory.Items.FindByValue(Convert.ToString(intCategoryValue)).Selected=true;
                                FillDropdownWithProjectType();
                                drpPrjType.Items.FindByValue(Convert.ToString(intProjectTypeValue)).Selected=true;
                                FillDropdownWithBrandSegments(Convert.ToInt32(drpCategory.SelectedItem.Value));
                                drpBrand.Items.FindByValue(Convert.ToString(intBrandSegmentValue)).Selected=true;
                                lblHeading.Text = ("Project -  " + txtPrjName.Text);
                                lblUser.Visible = false;
                                FillHistoryGrid(Request.QueryString["ProjectID"]);

                            }

                        }


                        else
                        {
                            if ((strUserRole.ToUpper() == "mureo_admin".ToUpper()))
                            {
                                imgCancel.Enabled = true;
                                imgSubmit_CreateNewProject.Enabled = true;
                                imgSubmit.Enabled = true;
                            }
                            else if ((strUserRole.ToUpper() == "MUREO_Editors".ToUpper()))
                            {
                                imgCancel.Enabled = true;
                                imgSubmit_CreateNewProject.Enabled = true;
                                imgSubmit.Enabled = true;
                            }
                            else if ((strUserRole.ToUpper() == "MUREO_Readers".ToUpper()))
                            {
                                imgCancel.Enabled = false;
                                imgSubmit_CreateNewProject.Enabled = false;
                                imgSubmit.Enabled = false;
                                Response.Redirect("../Common/Home.aspx");
                            }
                            else
                            {
                                imgCancel.Enabled = false;
                                imgSubmit_CreateNewProject.Enabled = false;
                                imgSubmit.Enabled = false;
                                Response.Redirect("../Common/Home.aspx");
                            }
                            // Insert mode
                            // Code fof Populating dropdowns category,brand and project type
                            imgDelete.Visible = false;
                            imgSubmit_CreateNewProject.Visible = true;
                            txtPrjLead.Text = objSecurity.UserName;
                            FillDropdownWithCategory();
                            FillDropdownWithProjectType();
                            lblUser.Visible = true;
                            lblUser.Text = ("Created by " + (strUser + " on " + System.DateTime.Now.Date.ToShortDateString()));
                            drpCategory.SelectedIndex = 0;
                            drpBrand.SelectedIndex = 0;
                            drpPrjType.SelectedIndex = 0;
                        }
                       
                    }
                }
                


            }
            catch (Exception ex)
            {
                string script;
                script = ("alert(\'"+ (ex.Message + "\');"));

                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                //Page.RegisterStartupScript("clientscript", script);
            }
        }

        #region "Methods/Functions"
        public void NoData(string strMessage) {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "clientscript", ("alert(\'" + (strMessage + "\');")),true);
    }
        private void FillDropdownWithCategory()
        {
            dsCategory = new DataSet();
            if (clsPrj.FetchDataSetUsingSqlParameters(0, ref dsCategory, "GET_MUR_Category", "@p_Category_ID"))
            {
                if ((dsCategory.Tables[0].Rows.Count == 0))
                {
                    NoData("Category does not exist(s) in the database.");
                    return;
                }
                drpCategory.DataSource = dsCategory.Tables[0].DefaultView;
                drpCategory.DataTextField = "Category_Name";
                drpCategory.DataValueField = "Category_ID";
                drpCategory.DataBind();
                drpCategory.Items.Insert(0, new ListItem("Select a Category", "0"));
                //drpCategory.Items[0].Value = "0";
            }
            
        }
        private void FillDropdownWithProjectType()
        {
            dsProjectType = new DataSet();
            if (clsPrj.FetchDataSetUsingSqlParameters(0, ref dsProjectType, "GET_MUR_Project_Type", "@p_Project_Type_ID"))
            {
                if ((dsProjectType.Tables[0].Rows.Count == 0))
                {
                    NoData("Project type does not exist(s) in the database.");
                    return;
                }
                drpPrjType.DataSource = dsProjectType.Tables[0].DefaultView;
                drpPrjType.DataTextField = "Project_Type_Name";
                drpPrjType.DataValueField = "Project_Type_ID";
                drpPrjType.DataBind();
                drpPrjType.Items.Insert(0, new ListItem("Select a Project Type", "0"));

            }

        }
        private void FillDropdownWithBrandSegments(int intCategoryID)
        {
            if ((intCategoryID == 0))
            {
                drpBrand.Items.Clear();
                drpBrand.Items.Insert(0, new ListItem("None", "0"));
                return;
            }
            drpBrand.Items.Clear();
            dsBrand = new DataSet();
            if (clsPrj.FetchDataSetUsingSqlParameters(intCategoryID, ref dsBrand, "GET_MUR_Brand_Segment_By_Category", "@p_Category_ID"))
            {
                if ((dsBrand.Tables.Count == 0))
                {
                    NoData("Brand segments does not exist(s) in the database.");
                    drpBrand.Items.Insert(0, new ListItem("None", "0"));
                    return;
                }
                else if ((dsBrand.Tables[0].Rows.Count == 0))
                {
                    NoData("Brand segments does not exist(s) in the database.");
                    drpBrand.Items.Insert(0, new ListItem("None", "0"));
                    return;
                }
                drpBrand.DataSource = dsBrand.Tables[0].DefaultView;
                drpBrand.DataTextField = "Brand_Segment_Name";
                drpBrand.DataValueField = "Brand_Segment_ID";
                drpBrand.DataBind();
                drpBrand.Items.Insert(0, new ListItem("Select a Brand Segment", "0"));
            }
        }

        private void FillHistoryGrid(string parProjectID)
        {
            dsHistory = new DataSet();
            if (clsPrj.FillHistoryofProject(parProjectID, ref dsHistory))
            {
                //if ((dsHistory.Tables.Count == 0))
                //{
                //    NoData("History details does not exist\'s in the database.");
                //    return;
                //}
                //else 
                if ((dsHistory.Tables[0].Rows.Count == 0))
                {
                    NoData("History details does not exist\'s in the database.");
                    return;
                }
                dgdShowHistory.Visible = true;
                dgdShowHistory.DataSource = dsHistory.Tables[1].DefaultView;
                dgdShowHistory.DataBind();
            }
        }

        #endregion
        #region selectedIndexChanged Event"     
        
        //protected void drpBrand_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtPOC.Text))
        //        ViewState["POC"] = hdnPOC.Value;
        //    if (string.IsNullOrEmpty(txtPrjLead.Text))
        //        ViewState["Lead"] = hdntxtPrjLead.Value;
        //    ClientScript.RegisterStartupScript(GetType(), "clientscript", "document.getElementById('txtPrjName').focus();");
        //}

        //protected void drpPrjType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtPOC.Text))
        //        ViewState["POC"] = hdnPOC.Value;
        //    if (string.IsNullOrEmpty(txtPrjLead.Text))
        //        ViewState["Lead"] = hdntxtPrjLead.Value;
        //    ClientScript.RegisterStartupScript(GetType(), "clientscript", "document.getElementById('imgLeadAddressBook').focus();");
        //}

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(string.IsNullOrEmpty(txtPOC.Text))
            ViewState["POC"] = hdnPOC.Value;
            if (string.IsNullOrEmpty(txtPrjLead.Text))
            ViewState["Lead"] = hdntxtPrjLead.Value;
            FillDropdownWithBrandSegments(Convert.ToInt32(drpCategory.SelectedValue));
            drpBrand.SelectedIndex = 0;
            drpPrjType.SelectedIndex = 0;
        }
        #endregion
        private void InsertProject()
        {
            int ProjectTypeID, BrandID;
            SqlParameter[] paramOut = null;
            ProjectTypeID =Convert.ToInt32(drpPrjType.SelectedValue);
            BrandID = Convert.ToInt32(drpBrand.SelectedValue);
            if (clsPrj.ProjectInsert(0, ProjectTypeID, BrandID, txtPrjName.Text.Trim(), txtPrjLead.Text.Trim(), hdnPOC.Value.Trim(), "A", strUser, ref paramOut))
            {
                int intResult = Convert.ToInt32(paramOut[0].Value.ToString());
                if ((intResult == 0))
                {
                    SqlParameter[] paramOut1 = null;
                    if (clsPrj.GetProjectID(txtPrjName.Text, BrandID, ProjectTypeID, ref paramOut1))
                    {
                        int intProjID = Convert.ToInt32(paramOut1[0].Value.ToString());
                    if ((intProjID > 0))
                    {
                        int rowCount, i, k, m, intPosOriginator;
                        string SendersList, s, senderName;
                        MailMessage objMail = new MailMessage();
                        string PosOriginator;
                        PosOriginator = objSecurity.UserName;
                        try
                        {
                            if (!(PosOriginator == null))
                            {
                                // PosOriginator = ViewState("Originator")
                                intPosOriginator = PosOriginator.IndexOf(" ");
                                PosOriginator = PosOriginator.Substring(intPosOriginator);
                                PosOriginator = PosOriginator.Replace("-", ".");
                            }
                            s = txtPOC.Text.Trim();
                            if (!(txtPOC.Text == ""))
                            {
                                string[] a;
                                char[] delimeter1 = new char[] { ',' };
                                a = s.Split(delimeter1);
                                for (k = 0; (k <= (a.Length - 1)); k++)
                                {
                                    string appName = a[k];
                                    i = appName.IndexOf(" ");
                                    if ((i > -1))
                                    {
                                        appName = appName.Substring(i);
                                    }
                                    appName = appName.Replace("-", ".");
                                    appName = appName.Replace(" ", "");
                                    senderName = appName;
                                    senderName = (senderName + "@pg.com");
                                    clsSendMail objSendMail = new clsSendMail();
                                    objSendMail.SendTo = senderName;
                                    objSendMail.SendFrom = (PosOriginator + "@pg.com");
                                    objSendMail.MailSubject = ("MUR POC Project Notification:  " + txtPrjName.Text);
                                    string strURLLockMode = ("http://"
                                                + (ViewState["servername"] + ("/Common/frmViewProject.aspx?ProjectID="
                                                + (intProjID + "&Mode=Edit"))));
                                    objSendMail.MailBody = ("Dear "
                                                + (a[k] + (" :" + ("<BR>" + ("<BR>" + ("FYI: you have been assigned as the POC for the "
                                                + (txtPrjName.Text + (" in the Machine Utilization database. Below is the URL to the Project document. " + ("<br>" + ("<BR>" + ("<a href=\'"
                                                + (strURLLockMode + ("\'>"
                                                + (strURLLockMode + ("</a><BR>" + ("<BR>" + ("Project Name is "
                                                + (txtPrjName.Text + ("<BR>" + ("Project Manager is "
                                                + (txtPrjLead.Text + ("<BR>" + ("<BR>" + ("Thank you," + ("<BR>"
                                                + (objSecurity.UserName + "."))))))))))))))))))))))))));
                                    bool IsMailSend;
                                    IsMailSend = clsSendMail.fnSendMail(objSendMail);



                                    

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                    script = "alert(\'" + ConfigurationManager.AppSettings["InsertSuccess"] + "\'); ";
                    script = script + "window.location.href=\'../Common/Home.aspx\'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        
                    }
                    

                }
                else if (intResult == 1)
                {
                    script = ("alert(\'" + ConfigurationManager.AppSettings["RecordExist"] + "\')");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    script = ("alert(\'" + ConfigurationManager.AppSettings["PrjInsertErrMsg"] + "\')");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }

        }
        private void UpdateProject()
        {
            // Code for save project button
            int ProjectTypeID, BrandID;
            ProjectTypeID = Convert.ToInt32(drpPrjType.SelectedValue);
            BrandID = Convert.ToInt32(drpBrand.SelectedValue); 
            //ProjectTypeID = Convert.ToInt32(drpPrjType.Items.FindByText(drpPrjType.Text));
            //BrandID = Convert.ToInt32(drpBrand.Items.FindByText(drpBrand.Text));
            if (clsPrj.ProjectInsert(Convert.ToInt32(Session["PrjID"]), ProjectTypeID, BrandID, txtPrjName.Text.Trim(), txtPrjLead.Text.Trim(), txtPOC.Text.Trim(), "A", strUser, ref paramOut))
            {
                int intResult = Convert.ToInt32(paramOut[0].Value.ToString());
                if ((intResult == 0))
                {
                    // Success Message
                    script = "alert(\'" + ConfigurationManager.AppSettings["UpdateSuccess"] + "\'); window.location.href=\'../Common/Home.aspx\';";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                }
                else if ((intResult == 1))
                {
                    script = "alert(\'" + ConfigurationManager.AppSettings["RecordExist"] + "\'); window.location.href=\'../Common/Home.aspx\';";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    // Failure Message
                    script = ("alert(\'" + ConfigurationManager.AppSettings["Updateerr"] + "\')");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                }
            }
        }
        private void DeleteProject() {
        // Code for save project button
            int ProjectTypeID, BrandID;
            ProjectTypeID = Convert.ToInt32(drpPrjType.SelectedValue);
            BrandID = Convert.ToInt32(drpBrand.SelectedValue); 
            //ProjectTypeID = Convert.ToInt32(drpPrjType.Items.FindByText(drpPrjType.Text));
            //BrandID = Convert.ToInt32(drpBrand.Items.FindByText(drpBrand.Text));
            if (clsPrj.DeleteProject(Convert.ToInt32( Request.QueryString["ProjectID"].ToString()), ProjectTypeID, BrandID, txtPrjName.Text.Trim(), txtPrjLead.Text.Trim(), txtPOC.Text.Trim(), "I", strUser, ref paramOut))
            {
                int intResult = Convert.ToInt32(paramOut[0].Value.ToString());
                    if ((intResult == 0)) {
                        script = "alert(\'" + ConfigurationManager.AppSettings["DeletedSuccess"] + "\'); window.location.href=\'../Common/Home.aspx\';";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if ((intResult == 2)) {
                        // should not delete if event exists for the project Message
                        script = "alert(\'Project could not be deleted (Event exists for this project).\')";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
           
                    }
                    else {
                        // Failure Message
                        script = ("alert(\'" + ConfigurationManager.AppSettings["DeleteError"] + "\')");
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
            }
    }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if ((Request.QueryString["Mode"] == "Edit"))
                {
                    UpdateProject();
                }
                else
                {
                    InsertProject();
                }
                drpCategory.SelectedIndex = 0;
                drpBrand.SelectedIndex = 0;
                drpPrjType.SelectedIndex = 0;
                txtPrjName.Text = string.Empty;
                txtPrjLead.Text = string.Empty;
                ViewState["POC"] = null;
                ViewState["Lead"] = null;
            }
            catch (Exception ex)
            {
                string script;
                script = ("alert(\'"+ (ex.Message + "\')"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }

        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/Home.aspx");
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            DeleteProject();
            ViewState["POC"] = null;
            ViewState["Lead"] = null;
        }

        protected void imgSubmit_CreateNewProject_Click(object sender, ImageClickEventArgs e)
        {
            int ProjectTypeID, BrandID;
            SqlParameter[] paramOut = null;
            ProjectTypeID = Convert.ToInt32(drpPrjType.SelectedValue);
            BrandID = Convert.ToInt32(drpBrand.SelectedValue);
            if (clsPrj.ProjectInsert(0, ProjectTypeID, BrandID, txtPrjName.Text.Trim(), txtPrjLead.Text.Trim(), hdnPOC.Value.Trim(), "A", strUser, ref paramOut))
            {
                int intResult = Convert.ToInt32(paramOut[0].Value.ToString());
                if ((intResult == 0))
                {
                    SqlParameter[] paramOut1 = null;
                    if (clsPrj.GetProjectID(txtPrjName.Text, BrandID, ProjectTypeID, ref paramOut1))
                    {
                        int intProjID = Convert.ToInt32(paramOut1[0].Value.ToString());
                        if ((intProjID > 0))
                        {
                            int rowCount, i, k, m, intPosOriginator;
                            string SendersList, s, senderName;
                            MailMessage objMail = new MailMessage();
                            string PosOriginator;
                            PosOriginator = objSecurity.UserName;
                            try
                            {
                                if (!(PosOriginator == null))
                                {
                                    // PosOriginator = ViewState("Originator")
                                    intPosOriginator = PosOriginator.IndexOf(" ");
                                    PosOriginator = PosOriginator.Substring(intPosOriginator);
                                    PosOriginator = PosOriginator.Replace("-", ".");
                                }
                                s = txtPOC.Text.Trim();
                                if (!(txtPOC.Text == ""))
                                {
                                    string[] a;
                                    char[] delimeter1 = new char[] { ',' };
                                    a = s.Split(delimeter1);
                                    for (k = 0; (k <= (a.Length - 1)); k++)
                                    {
                                        string appName = a[k];
                                        i = appName.IndexOf(" ");
                                        if ((i > -1))
                                        {
                                            appName = appName.Substring(i);
                                        }
                                        appName = appName.Replace("-", ".");
                                        appName = appName.Replace(" ", "");
                                        senderName = appName;
                                        senderName = (senderName + "@pg.com");
                                        clsSendMail objSendMail = new clsSendMail();
                                        objSendMail.SendTo = senderName;
                                        objSendMail.SendFrom = (PosOriginator + "@pg.com");
                                        objSendMail.MailSubject = ("MUR POC Project Notification:  " + txtPrjName.Text);
                                        string strURLLockMode = ("http://"
                                                    + (ViewState["servername"] + ("/Common/frmViewProject.aspx?ProjectID="
                                                    + (intProjID + "&Mode=Edit"))));
                                        objSendMail.MailBody = ("Dear "
                                                    + (a[k] + (" :" + ("<BR>" + ("<BR>" + ("FYI: you have been assigned as the POC for the "
                                                    + (txtPrjName.Text + (" in the Machine Utilization database. Below is the URL to the Project document. " + ("<br>" + ("<BR>" + ("<a href=\'"
                                                    + (strURLLockMode + ("\'>"
                                                    + (strURLLockMode + ("</a><BR>" + ("<BR>" + ("Project Name is "
                                                    + (txtPrjName.Text + ("<BR>" + ("Project Manager is "
                                                    + (txtPrjLead.Text + ("<BR>" + ("<BR>" + ("Thank you," + ("<BR>"
                                                    + (objSecurity.UserName + "."))))))))))))))))))))))))));
                                        bool IsMailSend;
                                        IsMailSend = clsSendMail.fnSendMail(objSendMail);





                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                        script = "alert(\'" + ConfigurationManager.AppSettings["InsertSuccess"] + "\'); ";
                        script = script + "window.location.href=\'../Common/frmNewProject.aspx\'; ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                    }


                }
                else if (intResult == 1)
                {
                    script = ("alert(\'" + ConfigurationManager.AppSettings["RecordExist"] + "\')");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    script = ("alert(\'" + ConfigurationManager.AppSettings["PrjInsertErrMsg"] + "\')");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
            ViewState["POC"] = null;
            ViewState["Lead"] = null;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ViewState["POC"] != null)
            {
                txtPOC.Text = ViewState["POC"].ToString();
            }
            if (ViewState["Lead"] != null)
            {
                txtPrjLead.Text = ViewState["Lead"].ToString();
            }
        }


    }
  
}