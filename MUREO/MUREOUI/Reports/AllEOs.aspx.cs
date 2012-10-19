using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView.Rendering;
using DevExpress.Web.ASPxGridView;
using System.Data;
using MUREOBAL;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Reports
{
    public partial class AllEOs : System.Web.UI.Page
    {
        #region "Member Variables"
        DataSet dsAllEO;
        string script;
        string strScript;
        string strCurrentStage;
        static int intGlobalPlantID;
        static string strGlobalOriginator;
        static string strUserRole;
        static string strEOMode;
        string strUser;
        clsSecurity cls = new clsSecurity();
        #endregion
        bool boolAllowUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            strUserRole = cls.UserRole();
            strUser = cls.UserName;
            if (strUserRole == "MUREO_Admin")
            {
                imgCreateNewEO.Enabled = true;
                imgGotoEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgCreateNewEO.Enabled = true;
                imgGotoEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgCreateNewEO.Enabled = false;
                imgGotoEO.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgCreateNewEO.Enabled = false;
                imgGotoEO.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }
            if (!IsPostBack)
            {
                imgGotoEO.Attributes.Add("onclick", "NavigateSpecificEO();");
                imgbtnExtractEOCostSheet.Attributes.Add("onclick", "RedirectPage();");
                FillAllEOs();
                dgdSelectedEO.Visible = false;
                //FillAllEOsWithOriginator()
                rdbAllEOFilter.SelectedValue = Convert.ToString(0);
                dgdAllEOTreeforOriginator.Visible = false;
            }
        }

        
        

        #region "User Define Methods"

        public void NoApprovarList()
        {
            strScript = "alert('Approvar list is not available.');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }

        public void LabelHeadVisible(bool optVisible)
        {
            lblOriginatorVal.Visible = optVisible;
            lblPlantVal.Visible = optVisible;
        }
        //  **************PagerButtonClick******************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	PagerButtonClick()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for custom paging of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/11/07                Md.Abdul allaam             1.0           created
        //***************************************************

        //  *************FillSelectedEOs*******************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillSelectedEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in normal form.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/31/07                Md.Abdul allaam             1.0           created
        //02/27/08                Md.Abdul Allaam             2.0        Modified the code for accomdating delete button which
        //has to be shown for the EO which has the EO number as "New EO"
        //***************************************************
        protected void FillSelectedEOs(int intPlantID, string strOriginator, string strEOMode)
        {
            try
            {
                DataSet dsSelectEOs = new DataSet();

                ClsMyEOs objEOs = new ClsMyEOs();
                if (objEOs.GetSelectedEOList(intPlantID, strOriginator, strUser, Convert.ToChar(strEOMode), ref dsSelectEOs))
                {

                    if (dsSelectEOs == null)
                    {
                        NoRecords();
                        dgdSelectedEO.DataSource = null;
                        dgdSelectedEO.Visible = false;
                    }
                    else if (dsSelectEOs.Tables.Count == 0)
                    {
                        NoRecords();
                        dgdSelectedEO.DataSource = null;
                        dgdSelectedEO.Visible = false;
                    }
                    else if (dsSelectEOs.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        dgdSelectedEO.DataSource = null;
                        dgdSelectedEO.Visible = false;
                    }
                    else if (dsSelectEOs.Tables[0].Rows.Count > 0)
                    {
                        dgdSelectedEO.DataSource = dsSelectEOs.Tables[0].DefaultView;


                        dgdSelectedEO.DataBind();
                        dgdSelectedEO.Visible = true;

                        // 'Following code is for enabling and disabling the links on the form based on the logged in username.
                        if (strOriginator == strUser)
                        {
                            EnableDisableLinks(true);
                            //Following code is for enabling and disabling the links on the form based on the user roles.
                        }
                        else if (strUserRole == "MUREO_Admin")
                        {
                            EnableDisableLinks(true);
                        }
                        else
                        {
                            EnableDisableLinks(false);
                        }

                        //for (int numRows = 0; numRows <= dgdSelectedEO.VisibleRowCount - 1; numRows++)
                        //{
                        //    //following code get the EO Title of the Eo                           
                        //    LinkButton lblEONumber = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["EO#"], "hypEONumber");
                        //    string strEONumber = lblEONumber.Text;

                        //    //following code get the current stage of the Eo
                        //    //Dim lnkStage As LinkButton
                        //    //lnkStage = CType(dgdSelectedEO.Items(numRows).FindControl("hypEOStage"), LinkButton)
                        //    //Dim strStage As String = lnkStage.Text
                        //    ImageButton imgApprovar = (ImageButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Check Approvals"], "imgCheckApproval");
                        //    Label lblCurrentStage = (Label)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Current Stage"], "lblCurrentStage");
                        //    Label lblStatus = (Label)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Status"], "lblStatus");
                        //    if (lblStatus.Text.ToUpper() == "Draft".ToUpper() | lblStatus.Text.ToUpper() == "&nbsp;".ToUpper() | lblCurrentStage.Text.ToUpper() == "site test".ToUpper())
                        //    {
                        //        imgApprovar.Visible = false;
                        //    }
                        //    //Displaying of cancel button when EO has a EO Number.
                        //    //ImageButton imgCancel = default(ImageButton);
                        //    //imgCancel = (ImageButton)dgdSelectedEO.Items(numRows).FindControl("imgCancel");
                        //    ImageButton imgCancel = (ImageButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Cancel EO?"], "imgCancel");
                        //    if (strEONumber == string.Empty)
                        //    {
                        //        imgCancel.Visible = false;
                        //    }
                        //    else if (strEONumber.Trim().ToUpper() == "NEW EO".ToUpper())
                        //    {
                        //        imgCancel.Visible = false;
                        //        //Modified by Abdul on 15-Sept-08 for considering completed status
                        //    }
                        //    else if (lblCurrentStage.Text.ToUpper() == "closeout".ToUpper() & lblStatus.Text.ToUpper() == "Routed".ToUpper() | lblStatus.Text.ToUpper() == "Approved".ToUpper() | lblStatus.Text.ToUpper() == "Completed".ToUpper())
                        //    {
                        //        imgCancel.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        imgCancel.Visible = true;
                        //    }
                        //    //Hiding of Delete button when EO has a EO Number.
                        //    ImageButton imgDelete = (ImageButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Delete EO?"], "imgDelete");
                        //    if (strEONumber == string.Empty & lblCurrentStage.Text.ToUpper() == "Preliminary".ToUpper())
                        //    {
                        //        imgDelete.Visible = true;
                        //        // Added by abdul on 27-feb-2008 for checking of NewEO as the eo number
                        //    }
                        //    else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & lblCurrentStage.Text.ToUpper() == "Preliminary".ToUpper())
                        //    {
                        //        imgDelete.Visible = true;
                        //    }
                        //    else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & lblCurrentStage.Text.ToUpper() == "Site Test".ToUpper() & !(lblStatus.Text.ToUpper() == "Close-Out".ToUpper()))
                        //    {
                        //        imgDelete.Visible = true;
                        //    }
                        //    else if (strEONumber == string.Empty & lblCurrentStage.Text.ToUpper() == "Site Test".ToUpper() & !(lblStatus.Text.ToUpper() == "Close-Out".ToUpper()))
                        //    {
                        //        imgDelete.Visible = true;
                        //    }
                        //    else if (lblStatus.Text.ToUpper() == "Close-Out".ToUpper())
                        //    {
                        //        imgDelete.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        imgDelete.Visible = false;
                        //    }
                        //    //Displaying of stop button when EO is in Routed stage.
                        //    ImageButton imgStop = (ImageButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Stop this EO?"], "imgStopEO");
                        //    if (lblStatus.Text.ToUpper() == "Routed".ToUpper() & !(lblCurrentStage.Text.ToUpper() == "closeout".ToUpper()))
                        //    {
                        //        imgStop.Visible = true;
                        //    }
                        //    else if (lblCurrentStage.Text.ToUpper() == "Site Test".ToUpper() | lblStatus.Text.ToUpper() == "Draft".ToUpper())
                        //    {
                        //        imgStop.Visible = false;
                        //        //Modified by Abdul on 15-Sept-08 for considering completed status
                        //    }
                        //    else if (lblCurrentStage.Text.ToUpper() == "closeout".ToUpper() & lblStatus.Text.ToUpper() == "Routed".ToUpper() | lblStatus.Text.ToUpper() == "Approved".ToUpper() | lblStatus.Text.ToUpper() == "Completed".ToUpper())
                        //    {
                        //        imgStop.Visible = false;
                        //        //Elseif 
                        //        //imgStop.Visible = False
                        //    }

                        //    //Following code is for checking the cooriginator and approvals
                        //    if ((!(strOriginator == strUser)) | (!(strUserRole == "MUREO_Admin")))
                        //    {
                        //        Label lblISApproved = (Label)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Last Modified"], "lblISApprovar");
                        //        //Label lblISApproved = default(Label);
                        //        //lblISApproved = (Label)dgdSelectedEO.Items(numRows).FindControl("lblISApprovar");
                        //        if (lblISApproved.Text.ToUpper() == "Yes".ToUpper())
                        //        {
                        //            EnableDisableLinksForRow(true, numRows);
                        //        }
                        //        else
                        //        {
                        //            EnableDisableLinksForRow(false, numRows);
                        //        }
                        //    }

                        //    //Disabling a particular  row of site test when the site test is close out
                        //    if (lblStatus.Text.ToUpper() == "Close-Out".ToUpper())
                        //    {
                        //        //Following code to get EO title of the EO
                        //        //LinkButton lnkEOTitle = default(LinkButton);
                        //        //lnkEOTitle = (LinkButton)dgdSelectedEO.Items(numRows).Cells(1).FindControl("hypEOTitle");
                        //        LinkButton lnkEOTitle = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["EO Title"], "hypEOTitle");
                        //        //Following code to get Modified date of the EO
                        //        //LinkButton lnkModifiedDate = default(LinkButton);
                        //        //lnkModifiedDate = (LinkButton)dgdSelectedEO.Items(numRows).FindControl("hypModifiedDate");
                        //        LinkButton lnkModifiedDate = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Last Modified"], "hypModifiedDate");

                        //        lblEONumber.Enabled = false;
                        //        //lnkStage.Enabled = False

                        //        lnkEOTitle.Enabled = false;
                        //        lnkModifiedDate.Visible = false;

                        //    }
                        //}
                        // hdID.Value = ""
                        lblPlantVal.Text = Convert.ToString(dsSelectEOs.Tables[0].Rows[0][7]);

                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        public void EnableDisableLinksForRow(bool optBool, int numRows)
        {
            DevExpress.Web.ASPxEditors.ASPxButton imgApprovar = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Check Approvals"], "imgCheckApproval");
            if (imgApprovar != null && (!optBool))
                imgApprovar.Enabled = optBool;
            DevExpress.Web.ASPxEditors.ASPxButton imgCancel = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Cancel EO?"], "imgCancel");
            if (imgCancel != null && (!optBool))
                imgCancel.Enabled = optBool;
            DevExpress.Web.ASPxEditors.ASPxButton imgDelete = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Delete EO?"], "imgDelete");
            if (imgDelete != null && (!optBool))
                imgDelete.Enabled = optBool;
            DevExpress.Web.ASPxEditors.ASPxButton imgStop = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Stop this EO?"], "imgStopEO");
            if (imgStop != null && (!optBool))
                imgStop.Enabled = optBool;
            LinkButton lnkEONum = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["EO#"], "hypEONumber");
            if (lnkEONum != null && (!optBool))
                lnkEONum.Enabled = optBool;
            LinkButton lnkEOTitle = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["EO Title"], "hypEOTitle");
            if (lnkEOTitle != null && (!optBool))
                lnkEOTitle.Enabled = optBool;
            LinkButton lnkEOModDate = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Last Modified"], "hypModifiedDate");
            if (lnkEOModDate != null && (!optBool))
                lnkEOModDate.Enabled = optBool;
        }


        //
        //  **************EnableDisableLinks*********************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAllEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	optBool
        //Purpose	    :   enables and disables the links based on user Role.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/25/07                Md.Abdul allaam             1.0           created
        //***************************************************
        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgdSelectedEO.VisibleRowCount - 1; numRows++)
            {

                DevExpress.Web.ASPxEditors.ASPxButton imgApprovar = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Check Approvals"], "imgCheckApproval");
                if (imgApprovar != null && (!optBool))
                    imgApprovar.Enabled = optBool;
                DevExpress.Web.ASPxEditors.ASPxButton imgCancel = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Cancel EO?"], "imgCancel");
                if (imgCancel != null && (!optBool))
                    imgCancel.Enabled = optBool;
                DevExpress.Web.ASPxEditors.ASPxButton imgDelete = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Delete EO?"], "imgDelete");
                if (imgDelete != null && (!optBool))
                    imgDelete.Enabled = optBool;
                DevExpress.Web.ASPxEditors.ASPxButton imgStop = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Stop this EO?"], "imgStopEO");
                if (imgStop != null && (!optBool))
                    imgStop.Enabled = optBool;
                LinkButton lnkEONum = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["EO#"], "hypEONumber");
                if (lnkEONum != null && (!optBool))
                    lnkEONum.Enabled = optBool;
                LinkButton lnkEOTitle = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["EO Title"], "hypEOTitle");
                if (lnkEOTitle != null && (!optBool))
                    lnkEOTitle.Enabled = optBool;
                LinkButton lnkEOModDate = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdSelectedEO.Columns["Last Modified"], "hypModifiedDate");
                if (lnkEOModDate != null && (!optBool))
                    lnkEOModDate.Enabled = optBool;
            }
        }
        //  **************FillAllEOs*********************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAllEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in the form of tree view.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/31/07                Md.Abdul allaam             1.0           created
        //11/06/07                Md.Abdul Allaam             2.0           EO mode is also added to the datagrid
        //so as to filter the data on the tree
        //***************************************************
        public void FillAllEOs()
        {
            try
            {
                dsAllEO = new DataSet();

                //Creating object from ReportsBo class
                ClsMyEOs objAllEos = new ClsMyEOs();
                //Dim objProjectsByCategory As New BusinessObject.MUREO.BusinessObject.MachinesByCategory

                if (objAllEos.GetAllEOs(ref dsAllEO))
                {
                    if (dsAllEO == null)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblOriginatorlb.Visible = false;
                        lblPlantlb.Visible = false;
                    }
                    else if (dsAllEO.Tables.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblOriginatorlb.Visible = false;
                        lblPlantlb.Visible = false;
                    }
                    else if (dsAllEO.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblOriginatorlb.Visible = false;
                        lblPlantlb.Visible = false;
                    }
                    else
                    {
                        tdDivider.Visible = true;
                        lblOriginatorlb.Visible = true;
                        lblPlantlb.Visible = true;
                        //Temprary table for All Eo's

                        DataTable dtAllEos = new DataTable();

                        DataRow drAllEos = null;

                        dtAllEos.Columns.Add("Plant_ID");
                        dtAllEos.Columns.Add("Plant_Name_Mode");
                        dtAllEos.Columns.Add("EO_Mode");
                        dtAllEos.Columns.Add("Originator");

                        //Below code for splitting data for treeview display and binding splitted data into temperory table
                        ArrayList arrayPlantName = new ArrayList();
                        ArrayList arrayPlantID = new ArrayList();
                        ArrayList arrayEOMode = new ArrayList();

                        //First row item  from the dataset into the array i.e plant id and plant name mode.
                        string strPlantName = Convert.ToString(dsAllEO.Tables[0].Rows[0]["Plant_Name_Mode"]);

                        string strPlantID = Convert.ToString(dsAllEO.Tables[0].Rows[0]["Plant_ID"]);

                        string strEOMode = Convert.ToString(dsAllEO.Tables[0].Rows[0]["EO_Mode"]);

                        //Adding Plant name to array`
                        arrayPlantName.Add(strPlantName);
                        arrayPlantID.Add(strPlantID);
                        arrayEOMode.Add(strEOMode);

                        //Adding all Plant names(Without repitition)

                        for (int rowCount = 0; rowCount <= dsAllEO.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            string strPlantName1 = Convert.ToString(dsAllEO.Tables[0].Rows[rowCount]["Plant_Name_Mode"]);
                            string strPlantID1 = Convert.ToString(dsAllEO.Tables[0].Rows[rowCount]["Plant_ID"]);
                            string strEOMode1 = Convert.ToString(dsAllEO.Tables[0].Rows[0]["EO_Mode"]);


                            if (!(arrayPlantName.Contains(strPlantName1)))
                            {
                                arrayPlantName.Add(strPlantName1);
                                arrayPlantID.Add(strPlantID1);
                                arrayEOMode.Add(strEOMode1);

                            }
                        }

                        //Based on Plant name storing Plant ID and Plant name into temperory table

                        for (int rowPlantNameCount = 0; rowPlantNameCount <= arrayPlantName.Count - 1; rowPlantNameCount++)
                        {
                            drAllEos = dtAllEos.NewRow();

                            drAllEos["Plant_ID"] = arrayPlantID[rowPlantNameCount];
                            drAllEos["Plant_Name_Mode"] = arrayPlantName[rowPlantNameCount];
                            drAllEos["EO_Mode"] = arrayPlantName[rowPlantNameCount];

                            drAllEos["Originator"] = "";

                            dtAllEos.Rows.Add(drAllEos);

                            ArrayList arrayOriginator = new ArrayList();

                            string strPlanID = null;
                            string strEOModeType = null;

                            //Adding originator based on plant names

                            for (int rowOriginatorCount = 0; rowOriginatorCount <= dsAllEO.Tables[0].Rows.Count - 1; rowOriginatorCount++)
                            {

                                if (Convert.ToString(arrayPlantName[rowPlantNameCount]).Trim().ToUpper() == Convert.ToString(dsAllEO.Tables[0].Rows[rowOriginatorCount][1]).Trim().ToUpper())
                                {
                                    string strOriginator = Convert.ToString(dsAllEO.Tables[0].Rows[rowOriginatorCount][3]);

                                    strPlanID = Convert.ToString(dsAllEO.Tables[0].Rows[rowOriginatorCount][0]);
                                    strEOModeType = Convert.ToString(dsAllEO.Tables[0].Rows[rowOriginatorCount][2]);

                                    if (arrayOriginator.Count == 0)
                                    {
                                        arrayOriginator.Add(strOriginator);

                                    }

                                    if (!(arrayOriginator.Contains(strOriginator)))
                                    {
                                        arrayOriginator.Add(strOriginator);
                                    }

                                }

                            }


                            //Based on Originator storing Plant ID and Plant name in to temperory table

                            for (int rowOriginator1 = 0; rowOriginator1 <= arrayOriginator.Count - 1; rowOriginator1++)
                            {
                                drAllEos = dtAllEos.NewRow();
                                drAllEos["Plant_Id"] = strPlanID;
                                //arrayPlantID(rowOriginator1)
                                drAllEos["Originator"] = arrayOriginator[rowOriginator1];
                                drAllEos["EO_Mode"] = strEOModeType;
                                dtAllEos.Rows.Add(drAllEos);

                            }
                        }
                        DataColumn dc = new DataColumn("Index");
                        dtAllEos.Columns.Add(dc);
                        Int32 ind = 0;
                        foreach (DataRow dr in dtAllEos.Rows)
                        {

                            dr["Index"] = ind;
                            ind++;
                        }
                        dgdAllEOTree.DataSource = dtAllEos;
                        dgdAllEOTree.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void NoRecords()
        {
            script = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }


        protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                string st = string.Empty;

                ImageButton imgPlant1 = (ImageButton)sender;
                imgPlant1.Visible = false;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");
                imgPlant2.Visible = true;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= dgdAllEOTree.VisibleRowCount - 1; rowCount++)
                {
                   
                 
                    Label lblPlantName = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantName");
                    Label lblOriginator = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "lblOriginator");


                    ImageButton imgOriginator1 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOriginator1");
                    ImageButton imgOriginator2 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOriginator2");

                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                            if (!string.IsNullOrEmpty(lblOriginator.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblOriginator.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgOriginator1.Visible = true;
                                imgOriginator2.Visible = false;
                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblOriginator.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgOriginator1.Visible = false;
                                imgOriginator2.Visible = false;
                                lblOriginator.Visible = false;
                            }

                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }                    

                }
                ViewState["Single"] = st.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgOriginator1_Command(object sender, CommandEventArgs e)
        {
            FillAllEOs();
            ViewState["Expand"] = null;
            dgdSelectedEO.Visible = true;
            LabelHeadVisible(true);
            ImageButton imgOriginator1 = (ImageButton)sender;
            ImageButton imgOriginator2 = (ImageButton)imgOriginator1.Parent.FindControl("imgOriginator2");
            imgOriginator1.Visible = false;
            imgOriginator2.Visible = true;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgOriginator1.Parent;
            int rowno = gvd.ItemIndex;
            ViewState["EOMain"] = Convert.ToString(rowno);
            Label lblPlantName = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantName");
            Label lblPlantId = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantId");
            Label lblOriginator = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "lblOriginator");
            Label lblEOMode = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblEOMode");
            //        Label lblPlanID = (Label)e.Item.FindControl("lblPlanID");
            //        Label lblOriginator = (Label)e.Item.FindControl("lblOriginator");
            //        Label lblEOMode = (Label)e.Item.FindControl("lblEOMode");
            //        //hdID.Value = lblPlanID.Text + "," + lblOriginator.Text
            ViewState["Plt_ID"] = lblPlantId.Text;
            //        // Code added by Vijay
            ViewState["Origin"] = lblOriginator.Text;
            //        // Code added by Vijay
            FillSelectedEOs(Convert.ToInt32(lblPlantId.Text), Convert.ToString(lblOriginator.Text), lblEOMode.Text);
            intGlobalPlantID = Convert.ToInt32(lblPlantId.Text);
            Session["intGlobalPlantID"] = lblPlantId.Text;
            Session["lblOriginator"] = lblOriginator.Text;
            Session["lblEOMode"] = lblEOMode.Text;
            strGlobalOriginator = Convert.ToString(lblOriginator.Text);
            strEOMode = lblEOMode.Text;
            lblOriginatorVal.Text = lblOriginator.Text;
        }
        protected void imgOriginator2_Command(object sender, CommandEventArgs e)
        {
            ViewState["EOMain"] = null;
            ViewState["Expand"] = null;
            dgdSelectedEO.Visible = false;
            LabelHeadVisible(false);          
            //hdID.Value = ""
            //displayHead(False)

            ImageButton imgOriginator2 =(ImageButton)sender;
            ImageButton imgOriginator1 = (ImageButton)imgOriginator2.Parent.FindControl("imgOriginator1");                     
            imgOriginator1.Visible = true;
            imgOriginator2.Visible = false;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgOriginator1.Parent;
            int rowno = gvd.ItemIndex;

            for (int rowCount = rowno + 1; rowCount <= dgdAllEOTree.VisibleRowCount - 1; rowCount++)
            {


                //Label lblPlantName = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblPlantName");
                //Label lblOriginator = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblOriginator");
                Label lblPlantName = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantName");
                Label lblPlantId = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantId");
                Label lblOriginator = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "lblOriginator");
                Label lblEOMode = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblEOMode");
           


                if (string.IsNullOrEmpty(lblPlantName.Text) & string.IsNullOrEmpty(lblOriginator.Text))
                {
                    GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                    gvdc.Visible = false;
                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit For
                }

            }
        }
        protected void imgPlant2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            dgdSelectedEO.Visible = false;
            lblPlantVal.Visible = false;
            lblOriginatorVal.Visible = false;



            ImageButton imgPlant2 = (ImageButton)sender;
            ImageButton imgPlant1 = (ImageButton)imgPlant2.Parent.FindControl("imgPlant1");
            imgPlant2.Visible = false;
            imgPlant1.Visible = true;

            //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant1.ClientID + "').focus();");

            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
            int rowno = gvd.ItemIndex;


            for (int rowCount = rowno + 1; rowCount <= dgdAllEOTree.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                Label lblPlantName = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantName");
                Label lblPlantId = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlanID");
                Label lblOriginator = (Label)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "lblOriginator");
                //lblPlantName.Visible = false;
                ImageButton imgOriginator1 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOriginator1");
                ImageButton imgOriginator2 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOriginator2");
                //ImageButton imgPlant2 = (ImageButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "imgPlant2");
                //ImageButton imgPlant1 = (ImageButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "imgPlant1");

                //Label lblPlantName = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblPlantName");
                //Label lblEOMode = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblEOMode");
                // Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)
                //ImageButton imgEOMode1 = default(ImageButton);
                //imgEOMode1 = (ImageButton)dgdAllEOTree.Items(rowCount).FindControl("imgEOMode1");
                //ImageButton imgEOMode2 = default(ImageButton);
                //imgEOMode2 = (ImageButton)dgdAllEOTree.Items(rowCount).FindControl("imgEOMode2");
                if (lblPlantName != null)
                {
                    if (string.IsNullOrEmpty(lblPlantName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        imgOriginator1.Visible = false;
                        imgOriginator2.Visible = false;
                        lblOriginator.Visible = false;

                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
                else
                {
                    break;
                }
            }
        }



        protected void dgdSelectedEO_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {

                    DevExpress.Web.ASPxEditors.ASPxButton imgbStop = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Stop this EO?"], "imgStopEO");
                    DevExpress.Web.ASPxEditors.ASPxButton imgCancel = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Cancel EO?"], "imgCancel");
                  
                    Label lblCurrentStage = (Label)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Current Stage"], "lblCurrentStage");
                    Label lblStatus = (Label)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Status"], "lblStatus");
                    if (lblCurrentStage.Text.ToUpper() == "CloseOut".ToUpper() & lblStatus.Text.ToUpper() == "Approved".ToUpper())
                    {
                        lblStatus.Text = "Completed";
                    }
                    LinkButton lblEONumber = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["EO#"], "hypEONumber");
                    string strEONumber = lblEONumber.Text;

                    //following code get the current stage of the Eo
                    //Dim lnkStage As LinkButton
                    //lnkStage = CType(dgdSelectedEO.Items(numRows).FindControl("hypEOStage"), LinkButton)
                    //Dim strStage As String = lnkStage.Text
                    DevExpress.Web.ASPxEditors.ASPxButton imgApprovar = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Check Approvals"], "imgCheckApproval");
                   // Label lblCurrentStage = (Label)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Current Stage"], "lblCurrentStage");
                   // Label lblStatus = (Label)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Status"], "lblStatus");
                    if (lblStatus.Text.ToUpper() == "Draft".ToUpper() | lblStatus.Text.ToUpper() == "&nbsp;".ToUpper() | lblCurrentStage.Text.ToUpper() == "site test".ToUpper())
                    {
                        imgApprovar.Visible = false;
                    }
                    //Displaying of cancel button when EO has a EO Number.
                    //ImageButton imgCancel = default(ImageButton);
                    //imgCancel = (ImageButton)dgdSelectedEO.Items(numRows).FindControl("imgCancel");
                    //ImageButton imgCancel = (ImageButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Cancel EO?"], "imgCancel");
                    if (strEONumber == string.Empty)
                    {
                        imgCancel.Visible = false;
                    }
                    else if (strEONumber.Trim().ToUpper() == "NEW EO".ToUpper())
                    {
                        imgCancel.Visible = false;
                        //Modified by Abdul on 15-Sept-08 for considering completed status
                    }
                    else if (lblCurrentStage.Text.ToUpper() == "closeout".ToUpper() & lblStatus.Text.ToUpper() == "Routed".ToUpper() | lblStatus.Text.ToUpper() == "Approved".ToUpper() | lblStatus.Text.ToUpper() == "Completed".ToUpper())
                    {
                        imgCancel.Visible = false;
                    }
                    else
                    {
                        imgCancel.Visible = true;
                    }
                    //Hiding of Delete button when EO has a EO Number.
                    DevExpress.Web.ASPxEditors.ASPxButton imgDelete = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Delete EO?"], "imgDelete");
                    if (strEONumber == string.Empty & lblCurrentStage.Text.ToUpper() == "Preliminary".ToUpper())
                    {
                        imgDelete.Visible = true;
                        // Added by abdul on 27-feb-2008 for checking of NewEO as the eo number
                    }
                    else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & lblCurrentStage.Text.ToUpper() == "Preliminary".ToUpper())
                    {
                        imgDelete.Visible = true;
                    }
                    else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & lblCurrentStage.Text.ToUpper() == "Site Test".ToUpper() & !(lblStatus.Text.ToUpper() == "Close-Out".ToUpper()))
                    {
                        imgDelete.Visible = true;
                    }
                    else if (strEONumber == string.Empty & lblCurrentStage.Text.ToUpper() == "Site Test".ToUpper() & !(lblStatus.Text.ToUpper() == "Close-Out".ToUpper()))
                    {
                        imgDelete.Visible = true;
                    }
                    else if (lblStatus.Text.ToUpper() == "Close-Out".ToUpper())
                    {
                        imgDelete.Visible = false;
                    }
                    else
                    {
                        imgDelete.Visible = false;
                    }
                    //Displaying of stop button when EO is in Routed stage.
                    DevExpress.Web.ASPxEditors.ASPxButton imgStop = (DevExpress.Web.ASPxEditors.ASPxButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Stop this EO?"], "imgStopEO");
                    if (lblStatus.Text.ToUpper() == "Routed".ToUpper() & !(lblCurrentStage.Text.ToUpper() == "closeout".ToUpper()))
                    {
                        imgStop.Visible = true;
                    }
                    else if (lblCurrentStage.Text.ToUpper() == "Site Test".ToUpper() | lblStatus.Text.ToUpper() == "Draft".ToUpper())
                    {
                        imgStop.Visible = false;
                        //Modified by Abdul on 15-Sept-08 for considering completed status
                    }
                    else if (lblCurrentStage.Text.ToUpper() == "closeout".ToUpper() & lblStatus.Text.ToUpper() == "Routed".ToUpper() | lblStatus.Text.ToUpper() == "Approved".ToUpper() | lblStatus.Text.ToUpper() == "Completed".ToUpper())
                    {
                        imgStop.Visible = false;
                        //Elseif 
                        //imgStop.Visible = False
                    }

                    //Following code is for checking the cooriginator and approvals
                    if ((!(Convert.ToString(ViewState["Origin"]) == strUser)) | (!(strUserRole == "MUREO_Admin")))
                    {
                        Label lblISApproved = (Label)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Last Modified"], "lblISApprovar");
                        //Label lblISApproved = default(Label);
                        //lblISApproved = (Label)dgdSelectedEO.Items(numRows).FindControl("lblISApprovar");
                        if (lblISApproved.Text.ToUpper() == "Yes".ToUpper())
                        {
                            EnableDisableLinksForRow(true, e.VisibleIndex);
                        }
                        else
                        {
                            EnableDisableLinksForRow(false, e.VisibleIndex);
                        }
                    }

                    //Disabling a particular  row of site test when the site test is close out
                    if (lblStatus.Text.ToUpper() == "Close-Out".ToUpper())
                    {
                        //Following code to get EO title of the EO
                        //LinkButton lnkEOTitle = default(LinkButton);
                        //lnkEOTitle = (LinkButton)dgdSelectedEO.Items(numRows).Cells(1).FindControl("hypEOTitle");
                        LinkButton lnkEOTitle = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["EO Title"], "hypEOTitle");
                        //Following code to get Modified date of the EO
                        //LinkButton lnkModifiedDate = default(LinkButton);
                        //lnkModifiedDate = (LinkButton)dgdSelectedEO.Items(numRows).FindControl("hypModifiedDate");
                        LinkButton lnkModifiedDate = (LinkButton)dgdSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdSelectedEO.Columns["Last Modified"], "hypModifiedDate");

                        lblEONumber.Enabled = false;
                        //lnkStage.Enabled = False

                        lnkEOTitle.Enabled = false;
                        lnkModifiedDate.Visible = false;

                    }
                }
            }
            catch (Exception exc)
            {
            }
        }
        protected void dgdAllEOTree_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    Label lblPlantName = (Label)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantName");
                    Label lblPlantId = (Label)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "lblPlantId");
                    Label lblOriginator = (Label)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "lblOriginator");
                    ImageButton imgOriginator1 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOriginator1");
                    ImageButton imgOriginator2 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOriginator2");
                    ImageButton imgPlant1 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "imgPlant1");
                    ImageButton imgPlant2 = (ImageButton)dgdAllEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTree.Columns["Plant"], "imgPlant2");
                    if (ViewState["Expand"] != null)
                    {
                        if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                        {

                            dgdSelectedEO.Visible = false;
                            lblPlantVal.Visible = false;
                            //lblEOTypeVal.Visible = false;
                            //Displaying only Plant names in first load of datagrid                      
                            imgPlant2.Visible = false;
                            lblPlantId.Visible = false;
                            imgPlant1.Visible = true;
                            imgOriginator1.Visible = false;
                            lblPlantName.Visible = true;
                            imgOriginator2.Visible = false;
                            lblOriginator.Visible = false;

                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = false;
                                imgOriginator1.Visible = false;
                                imgOriginator2.Visible = false;
                                lblOriginator.Visible = false;
                            }

                        }
                        else
                        {
                            if (dgdSelectedEO.Visible)
                            {
                                lblPlantVal.Visible = true;
                                lblOriginatorVal.Visible = true;
                            }

                            //Displaying only Plant names in first load of datagrid

                            imgPlant2.Visible = true;
                            imgPlant1.Visible = false;
                            lblOriginator.Visible = false;
                            lblPlantId.Visible = false;
                            lblPlantName.Visible = true;
                            imgOriginator1.Visible = false;
                            imgOriginator2.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = false;
                                imgOriginator1.Visible = true;
                                imgOriginator2.Visible = false;
                                lblOriginator.Visible = true;                                
                                e.Row.Visible = true;
                            }



                            //Dim lblBrandSegmentID As Label
                            //lblBrandSegmentID = CType(e.Item.FindControl("lblBrandSegmentID"), Label)
                            //lblBrandSegmentID.Visible = False


                            if (string.IsNullOrEmpty(lblOriginator.Text))
                            {
                                imgOriginator1.Visible = false;
                                imgOriginator2.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = true;
                            lblPlantName.Visible = true;
                            imgOriginator1.Visible = false;
                            imgOriginator2.Visible = false;
                            lblOriginator.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                imgOriginator1.Visible = false;
                                imgOriginator2.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = false;
                                lblOriginator.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                            }
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblPlantName.Visible = true;
                            imgPlant2.Visible = true;
                            imgPlant1.Visible = false;
                            imgOriginator1.Visible = false;
                            imgOriginator2.Visible = false;
                            lblOriginator.Visible = false;
                            e.Row.Visible = true;
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {                          
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            lblPlantName.Visible = false;
                            imgOriginator1.Visible = false;
                            imgOriginator2.Visible = false;
                            lblOriginator.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text) && (!string.IsNullOrEmpty(lblOriginator.Text)))
                            {
                                imgOriginator1.Visible = true;
                                imgOriginator2.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = false;
                                lblOriginator.Visible = true;
                                lblPlantName.Visible = false;
                                e.Row.Visible = true;
                            }
                        }
                        else
                        {
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "hiddencol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "hiddencol";
                                if (e.Row != null)
                                    e.Row.CssClass = "hiddencol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "hiddencol";
                            }
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            lblPlantName.Visible = false;
                            imgOriginator1.Visible = false;
                            imgOriginator2.Visible = false;
                            lblOriginator.Visible = false;
                            if (!string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                imgOriginator1.Visible = false;
                                imgOriginator2.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = true;
                                lblOriginator.Visible = false;
                                lblPlantName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                            }
                            if (string.IsNullOrEmpty(lblPlantName.Text) && string.IsNullOrEmpty(lblOriginator.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                            }
                        }
                        if (cls.IsExists(Convert.ToString(ViewState["EOMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblPlantVal.Visible = true;
                            lblOriginatorVal.Visible = true;
                            lblPlantName.Visible = false;
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            imgOriginator1.Visible = false;
                            imgOriginator2.Visible = true;
                            lblOriginator.Visible = true;
                            e.Row.Visible = true;
                        }
                    }

                }
            }
            catch (Exception exc)
            {
            }
        }

        //  **************DisplayBoundColumnValues*********************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	DisplayBoundColumnValues()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of itemcommand utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/31/07                Md.Abdul allaam             1.0           created
        //***************************************************
        //public void DisplayBoundColumnValues(object sender, DataGridCommandEventArgs e)
        //{
        //    try
        //    {
        //        // Dim strStatus As String = dgdMyEO.DataKeys(e.Item.Cells(6).Text))
        //        if (e.CommandName == "EONum_Link")
        //        {
        //            if (dgdSelectedEO.Items(e.Item.ItemIndex).Cells(5).Text == "Site Test")
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
        //            }
        //            else
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //            }
        //        }
        //        else if (e.CommandName == "EOTitle_Link")
        //        {
        //            if (dgdSelectedEO.Items(e.Item.ItemIndex).Cells(5).Text == "Site Test")
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
        //            }
        //            else
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //            }
        //        }
        //        else if (e.CommandName == "ModifiedDate_Link")
        //        {
        //            if (dgdSelectedEO.Items(e.Item.ItemIndex).Cells(5).Text == "Site Test")
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
        //            }
        //            else
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //            }
        //        }
        //        else if (e.CommandName == "ReadOnly")
        //        {
        //            if (dgdSelectedEO.Items(e.Item.ItemIndex).Cells(5).Text == "Site Test")
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect(string.Format("../Common/ViewSiteTest.aspx?EoID={0}&Page={1}", intEOID, "AllEOs"));
        //            }
        //            else
        //            {
        //                int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //                Response.Redirect("../Common/ViewEO.aspx?EO_ID=" + intEOID.ToString());
        //            }
        //        }
        //        else if (e.CommandName == "Delete")
        //        {
        //            //Added by Abdul as the deleting of an EO has to be done with two confirmations i.e why below code.
        //            int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //            strCurrentStage = dgdSelectedEO.Items(e.Item.ItemIndex).Cells(5).Text;

        //            string script = null;
        //            script = "DeleteEO('" + intEOID + "','" + strCurrentStage + "'); ";
        //            Page.RegisterStartupScript("db_error_message", script);

        //            //Commented by abdul as the below code is directly deleting Eo with singe confirmation
        //            //Dim intEOID As Integer = CInt(dgdSelectedEO.DataKeys(e.Item.ItemIndex))
        //            //Dim intRetValue As Integer = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "D", Security.UserName)
        //            //'Dim intRetvalue As Integer
        //            //If intRetValue = 0 Then
        //            //    strScript = "alert('" & ConfigurationManager.AppSettings["DeleteSuccessMsg") & "');"
        //            //    Page.RegisterStartupScript("ClientScript", strScript)
        //            //ElseIf intRetValue = 1 Then
        //            //    strScript = "alert('" & ConfigurationManager.AppSettings["RecordDeletionFailure") & "');"
        //            //    Page.RegisterStartupScript("ClientScript", strScript)
        //            //End If
        //        }
        //        else if (e.CommandName == "Stop")
        //        {
        //            int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //            int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "S", cls.UserName);
        //            //Dim intRetvalue As Integer
        //            if (intRetValue == 0)
        //            {
        //                strScript = "alert('" + ConfigurationManager.AppSettings["EORecordStopSucc") + "');";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //            }
        //            else if (intRetValue == 1)
        //            {
        //                strScript = "alert('" + ConfigurationManager.AppSettings["EORecordStopFail") + "');";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //            }
        //        }
        //        else if (e.CommandName == "CheckApproval")
        //        {
        //            int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //            strCurrentStage = e.Item.Cells(5).Text;
        //            DataSet dsApprovar = new DataSet();
        //            dsApprovar = BusinessObject.MUREO.BusinessObject.ClsMyEOs.ShowApprovals(intEOID, strCurrentStage);
        //            if (dsApprovar == null)
        //            {
        //                NoApprovarList();
        //            }
        //            else if (dsApprovar.Tables.Count == 0)
        //            {
        //                NoApprovarList();
        //            }
        //            else if (dsApprovar.Tables[0].Rows.Count == 0)
        //            {
        //                NoApprovarList();
        //            }
        //            else
        //            {
        //                DataTable dt = null;
        //                dt = dsApprovar.Tables[0];
        //                int rowCount = dt.Rows.Count;
        //                Int16 colCount = dt.Columns.Count;
        //                int rowLoop = 0;
        //                int colLoop = 0;

        //                string strApprovar = null;
        //                for (rowLoop = 0; rowLoop <= rowCount - 1; rowLoop++)
        //                {
        //                    // For colLoop = 0 To colCount - 1
        //                    //strApprovar = strApprovar & dt.Rows(rowLoop).Item(colLoop) & "\n"
        //                    strApprovar = strApprovar + dt.Rows[rowLoop][0] + "\\t\\t\\t" + dt.Rows[rowLoop][1] + "\\t\\t\\t" + dt.Rows[rowLoop][2] + "\\n";
        //                    //Next
        //                }

        //                if (!(strApprovar == string.Empty))
        //                {
        //                    string script = null;
        //                    //Added by abdul on 31-jan-2008
        //                    //New code where the user can view the approvers in a show modal dialog box.
        //                    if (Strings.UCase(strCurrentStage) == Strings.UCase("Preliminary"))
        //                    {
        //                        script = "window.open('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:300px');";
        //                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //                    }
        //                    else if (Strings.UCase(strCurrentStage) == Strings.UCase("Final"))
        //                    {
        //                        script = "window.open('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:400px');";
        //                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //                    }
        //                    else if (Strings.UCase(strCurrentStage) == Strings.UCase("Closeout"))
        //                    {
        //                        script = "window.open('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:200px');";
        //                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //                    }

        //                    //strScript = "alert('" & strApprovar & "');"
        //                    //Page.RegisterStartupScript("ClientScript", strScript)
        //                }
        //                else
        //                {
        //                    strScript = "alert('Approvar list is not available.');";
        //                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //                }
        //            }
        //        }
        //        else if (e.CommandName == "Cancel")
        //        {
        //            int intEOID = Convert.ToInt32(dgdSelectedEO.DataKeys(e.Item.ItemIndex));
        //            int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "C", cls.UserName);
        //            //Dim intRetvalue As Integer
        //            if (intRetValue == 0)
        //            {
        //                strScript = "alert('" + ConfigurationManager.AppSettings["CancelSuccessMsg") + "');";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //            }
        //            else if (intRetValue == 1)
        //            {
        //                strScript = "alert('" + ConfigurationManager.AppSettings["CancelErrMsg") + "');";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //            }
        //        }
        //        FillSelectedEOs(intGlobalPlantID, strGlobalOriginator, strEOMode);
        //    }
        //    catch (Exception ex)
        //    {
        //        string script = null;
        //        string exMessage = null;
        //        exMessage = ex.Message.Replace("'", " ");
        //        script = "alert('" + ex.Message + "'); ";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    }
        //}

        //  **************FillAllEOs*********************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAllEOsWithOriginator()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in the form of tree view with only originator column.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //10/08/07                Md.Abdul allaam             1.0           created
        //***************************************************

        protected void hypModifiedDate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCancel_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ClsMyEOs clsmyeo = new ClsMyEOs();
                int intEOID = Convert.ToInt32(e.CommandName);
                string strCurrentStage = Convert.ToString(e.CommandArgument);
                int intRetValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (clsmyeo.DeleteStopCancelEO(intEOID, 'C', cls.UserName, ref paramout))
                {
                    intRetValue = Convert.ToInt32(paramout[0].Value);
                    if (intRetValue == 0)
                    {
                        strScript = "alert('" + ConfigurationManager.AppSettings["CancelSuccessMsg"] + "');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                        //dgdEventInfo.Visible = False
                        //lblEOTitleVal.Visible = False
                    }
                    else if (intRetValue == 1)
                    {
                        strScript = "alert('" + ConfigurationManager.AppSettings["CancelErrMsg"] + "');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                    }
                }
                FillSelectedEOs(intGlobalPlantID, strGlobalOriginator, strEOMode);
            }
            catch (Exception exc)
            {

            }
        }
        protected void dgdAllEOTree_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillAllEOs();
            }
            catch (Exception exc)
            {

            }
        }
        protected void EOTitle_Link_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                //    
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void hypEONumber_Command(object sender, CommandEventArgs e)
        {
            try
            {
                LinkButton lnkEONum = (LinkButton)sender;

                //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = Convert.ToString(e.CommandArgument);
                int intEOID = 0;
                if (e.CommandName != null)
                    intEOID = Convert.ToInt32(e.CommandName);
                if (strStage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void ImgReadOnlyEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strstage = Convert.ToString(e.CommandArgument);

                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/ViewSiteTest.aspx?EoID={0}", intEOID));
                }
                else
                {
                    if (strstage.ToUpper() == "Preliminary".ToUpper())
                    {
                        view = "1";
                    }
                    else if (strstage.ToUpper() == "Final".ToUpper())
                    {
                        view = "2";
                    }
                    else if (strstage.ToUpper() == "Closeout".ToUpper())
                    {
                        view = "3";
                    }
                    Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", Convert.ToString(intEOID), Convert.ToString(view), "Report"));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Ret"] != null)
                {
                    string script = "DeleteMessage('" + Convert.ToString(Session["Ret"]) + "', '" + Convert.ToString(Session["Status"]) + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strCurrentStage = Convert.ToString(e.CommandArgument);
                string script = null;
                script = "DeleteEO('" + intEOID + "','" + strCurrentStage + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgStopEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ClsMyEOs clsmyeo = new ClsMyEOs();
                int intEOID = Convert.ToInt32(e.CommandName);
                int intRetValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (clsmyeo.DeleteStopCancelEO(intEOID, 'S', cls.UserName, ref paramout))
                {
                    intRetValue = Convert.ToInt32(paramout[0].Value);
                    if (intRetValue == 0)
                    {
                        strScript = "alert('" + ConfigurationManager.AppSettings["EORecordStopSucc"] + "');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                    }
                    else if (intRetValue == 1)
                    {
                        strScript = "alert('" + ConfigurationManager.AppSettings["EORecordStopFail"] + "');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCheckApproval_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ClsMyEOs clsmyeo = new ClsMyEOs();
                int intEOID = Convert.ToInt32(e.CommandName);
                strCurrentStage = Convert.ToString(e.CommandArgument);
                DataSet dsApprovar = new DataSet();
                if (clsmyeo.ShowApprovals(intEOID, strCurrentStage, ref dsApprovar))
                {
                    if (dsApprovar == null)
                    {
                        NoApprovarList();
                    }
                    else if (dsApprovar.Tables.Count == 0)
                    {
                        NoApprovarList();
                    }
                    else if (dsApprovar.Tables[0].Rows.Count == 0)
                    {
                        NoApprovarList();
                    }
                    else
                    {
                        DataTable dt = null;
                        dt = dsApprovar.Tables[0];
                        int rowCount = dt.Rows.Count;
                        Int16 colCount = Convert.ToInt16(dt.Columns.Count);
                        int rowLoop = 0;
                        int colLoop = 0;

                        string strApprovar = null;
                        for (rowLoop = 0; rowLoop <= rowCount - 1; rowLoop++)
                        {
                            // For colLoop = 0 To colCount - 1
                            //strApprovar = strApprovar & dt.Rows(rowLoop).Item(colLoop) & "\n"
                            strApprovar = strApprovar + dt.Rows[rowLoop][0] + "\\t\\t\\t" + dt.Rows[rowLoop][1] + "\\t\\t\\t" + dt.Rows[rowLoop][2] + "\\n";
                            //Next
                        }

                        if (!(strApprovar == string.Empty))
                        {
                            string script = null;
                            //Added by abdul on 31-jan-2008
                            //New code where the user can view the approvers in a show modal dialog box.
                            if (strCurrentStage.ToUpper() == "Preliminary".ToUpper())
                            {
                                script = "window.open('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:300px');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            }
                            else if (strCurrentStage == "Final".ToUpper())
                            {
                                script = "window.open('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:400px');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            }
                            else if (strCurrentStage.ToUpper() == "Closeout".ToUpper())
                            {
                                script = "window.open('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:200px');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                            }

                            //strScript = "alert('" & strApprovar & "');"
                            //Page.RegisterStartupScript("ClientScript", strScript)
                        }
                        else
                        {
                            strScript = "alert('Approvar list is not available.');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        public void FillAllEOsWithOriginator()
        {
            try
            {
                dsAllEO = new DataSet();

                ClsMyEOs objAllEos = new ClsMyEOs();

                if (objAllEos.GetAllEOsForOriginator("Originator", ref dsAllEO))
                {

                    if (dsAllEO == null)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblOriginatorlb.Visible = false;
                        lblPlantlb.Visible = false;
                    }
                    else if (dsAllEO.Tables.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblOriginatorlb.Visible = false;
                        lblPlantlb.Visible = false;
                    }
                    else if (dsAllEO.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblOriginatorlb.Visible = false;
                        lblPlantlb.Visible = false;
                    }
                    else
                    {
                        tdDivider.Visible = true;
                        lblOriginatorlb.Visible = true;
                        lblPlantlb.Visible = true;

                        dgdAllEOTreeforOriginator.DataSource = dsAllEO.Tables[0];
                        dgdAllEOTreeforOriginator.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        #endregion

        #region "Data Grid Events"
        //DataGrid which shows plant and originator - related events
        //

        //protected void dgdSelectedEO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        //Dim imgbDelete As ImageButton = CType(e.Item.FindControl("imgDelete"), ImageButton)
        //        //imgbDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();")
        //        ImageButton imgbStop = (ImageButton)e.Item.FindControl("imgStopEO");
        //        imgbStop.Attributes.Add("OnClick", "javascript:return confirmStop();");
        //        ImageButton imgbCancel = (ImageButton)e.Item.FindControl("imgCancel");
        //        imgbCancel.Attributes.Add("OnClick", "javascript:return confirmCancel();");
        //    }
        //    e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Center;

        //    //Dim imgbDelete As ImageButton = CType(e.Item.FindControl("imgDelete"), ImageButton)
        //    //Dim imgbStop As ImageButton = CType(e.Item.FindControl("imgStop"), ImageButton)
        //    //If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

        //    //    imgbDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();")
        //    //End If
        //    //// Added by Abdul on 15-Sept-08 for changing the status from Approved to Completed.
        //    if (Strings.UCase(e.Item.Cells[5].Text) == Strings.UCase("CloseOut") & Strings.UCase(e.Item.Cells[6].Text) == Strings.UCase("Approved"))
        //    {
        //        e.Item.Cells[6].Text = "Completed";
        //    }

        //}

        //protected void dgdSelectedEO_ItemSortCommand(object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        //{
        //    if (Convert.ToString(ViewState["StrSort")) == " Desc")
        //    {
        //        ViewState["StrSort") = " Asc";
        //    }
        //    else
        //    {
        //        ViewState["StrSort") = " Desc";
        //    }
        //    ViewState["SortExp") = e.SortExpression;
        //    FillSelectedEOs(Convert.ToInt32(ViewState["Plt_ID")), ViewState["Origin"), strEOMode);
        //}
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgdAllEOTree_ItemDataBound()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of itemDataBound utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/31/07                Md.Abdul allaam             1.0           created
        //***************************************************
        //protected void dgdAllEOTree_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:

        //            if (!(Convert.ToString(ViewState["Expand")) == "ExpandMode"))
        //            {
        //                dgdSelectedEO.Visible = false;
        //                LabelHeadVisible(false);
        //                PagerButtonVisibility(false);
        //                //Displaying only Plant names in first load of datagrid
        //                ImageButton imgPlant1 = default(ImageButton);
        //                ImageButton imgPlant2 = default(ImageButton);
        //                imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //                imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //                imgPlant2.Visible = false;
        //                Label lblPlantID = default(Label);
        //                lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //                lblPlantID.Visible = false;
        //                Label lblPlantName = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");

        //                ImageButton imgOriginator1 = default(ImageButton);
        //                ImageButton imgOriginator2 = default(ImageButton);
        //                imgOriginator1 = (ImageButton)e.Item.FindControl("imgOriginator1");
        //                imgOriginator2 = (ImageButton)e.Item.FindControl("imgOriginator2");
        //                imgOriginator1.Visible = false;
        //                imgOriginator2.Visible = false;


        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgPlant1.Visible = false;
        //                    imgPlant2.Visible = false;
        //                }


        //            }
        //            else
        //            {
        //                dgdSelectedEO.Visible = false;
        //                LabelHeadVisible(false);
        //                PagerButtonVisibility(false);
        //                //Displaying only Plant names in first load of datagrid
        //                ImageButton imgPlant1 = default(ImageButton);
        //                ImageButton imgPlant2 = default(ImageButton);
        //                imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //                imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //                imgPlant2.Visible = true;
        //                imgPlant1.Visible = false;

        //                Label lblPlantID = default(Label);
        //                lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //                lblPlantID.Visible = false;
        //                Label lblPlantName = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");

        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    imgPlant1.Visible = false;
        //                    imgPlant2.Visible = false;
        //                }

        //                ImageButton imgOriginator1 = default(ImageButton);
        //                ImageButton imgOriginator2 = default(ImageButton);
        //                imgOriginator1 = (ImageButton)e.Item.FindControl("imgOriginator1");
        //                imgOriginator2 = (ImageButton)e.Item.FindControl("imgOriginator2");
        //                imgOriginator1.Visible = true;
        //                imgOriginator2.Visible = false;

        //                //Dim lblBrandSegmentID As Label
        //                //lblBrandSegmentID = CType(e.Item.FindControl("lblBrandSegmentID"), Label)
        //                //lblBrandSegmentID.Visible = False
        //                Label lblOriginator = default(Label);
        //                lblOriginator = (Label)e.Item.FindControl("lblOriginator");

        //                if (string.IsNullOrEmpty(lblOriginator.Text))
        //                {
        //                    imgOriginator1.Visible = false;
        //                    imgOriginator2.Visible = false;
        //                }

        //            }
        //            break;
        //    }
        //}

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgdAllEOTree_ItemCommand()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of itemDataBound utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/31/07                Md.Abdul allaam             1.0           created
        //***************************************************
        //protected void dgdAllEOTree_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //when user clicks on Plant expand image button then application will execute below code
        //    // this code will diplay Originator
        //    if (e.CommandName == "PlantExpand")
        //    {
        //        dgdSelectedEO.Visible = false;
        //        LabelHeadVisible(false);
        //        PagerButtonVisibility(false);

        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant2.Visible = true;

        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant1.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdAllEOTree.Items.Count - 1; rowCount++)
        //        {


        //            Label lblPlantName = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblPlantName");
        //            Label lblOriginator = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblOriginator");
        //            Label lblPlantId = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblPlantID");

        //            ImageButton imgOriginator1 = default(ImageButton);
        //            ImageButton imgOriginator2 = default(ImageButton);
        //            imgOriginator1 = (ImageButton)dgdAllEOTree.Items(rowCount).FindControl("imgOriginator1");
        //            imgOriginator2 = (ImageButton)dgdAllEOTree.Items(rowCount).FindControl("imgOriginator2");


        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lblOriginator.Text))
        //                {
        //                    dgdAllEOTree.Items(rowCount).Visible = true;
        //                    imgOriginator1.Visible = true;
        //                    imgOriginator2.Visible = false;
        //                }
        //                else
        //                {
        //                    dgdAllEOTree.Items(rowCount).Visible = false;
        //                }

        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }

        //    }

        //    //when user clicks on plantname collapse image button then application will execute below code
        //    // this code will diplay only  plant names and hiding Originator.
        //    if (e.CommandName == "PlantCollapse")
        //    {
        //        dgdSelectedEO.Visible = false;
        //        LabelHeadVisible(false);
        //        PagerButtonVisibility(false);

        //        dgdSelectedEO.Visible = false;
        //        imgPrevious.Visible = false;
        //        imgNext.Visible = false;
        //        //hdID.Value = ""
        //        //displayHead(False)

        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant2.Visible = false;

        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant1.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdAllEOTree.Items.Count - 1; rowCount++)
        //        {
        //            Label lblPlantName = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblPlantName");
        //            Label lblOriginator = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblOriginator");
        //            // Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)

        //            ImageButton imgBrandSegment1 = default(ImageButton);
        //            imgBrandSegment1 = (ImageButton)dgdAllEOTree.Items(rowCount).FindControl("imgBrandSegment1");
        //            ImageButton imgBrandSegment2 = default(ImageButton);
        //            imgBrandSegment2 = (ImageButton)dgdAllEOTree.Items(rowCount).FindControl("imgBrandSegment2");

        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                dgdAllEOTree.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }

        //    //when user clicks on Originator Expand image button then application will execute below code
        //    // this code will diplay all the EO related info in a new datagrid.
        //    if (e.CommandName == "OriginatorExpand")
        //    {
        //        dgdSelectedEO.CurrentPageIndex = 0;
        //        dgdSelectedEO.Visible = true;
        //        LabelHeadVisible(true);
        //        PagerButtonVisibility(true);
        //        imgNext.Enabled = true;
        //        imgPrevious.Enabled = true;

        //        Label lblPlanID = (Label)e.Item.FindControl("lblPlanID");
        //        Label lblOriginator = (Label)e.Item.FindControl("lblOriginator");
        //        Label lblEOMode = (Label)e.Item.FindControl("lblEOMode");
        //        //hdID.Value = lblPlanID.Text + "," + lblOriginator.Text

        //        ViewState["Plt_ID") = lblPlanID.Text;
        //        // Code added by Vijay
        //        ViewState["Origin") = lblOriginator.Text;
        //        // Code added by Vijay

        //        FillSelectedEOs(Convert.ToInt32(lblPlanID.Text), Convert.ToString(lblOriginator.Text), lblEOMode.Text);
        //        intGlobalPlantID = Convert.ToInt32(lblPlanID.Text);
        //        strGlobalOriginator = Convert.ToString(lblOriginator.Text);
        //        strEOMode = lblEOMode.Text;
        //        lblOriginatorVal.Text = lblOriginator.Text;


        //        ImageButton imgOriginator1 = default(ImageButton);
        //        imgOriginator1 = (ImageButton)e.Item.FindControl("imgOriginator1");
        //        ImageButton imgOriginator2 = default(ImageButton);
        //        imgOriginator2 = (ImageButton)e.Item.FindControl("imgOriginator2");
        //        imgOriginator1.Visible = false;
        //        imgOriginator2.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgOriginator2.ClientID + "').focus();");
        //    }


        //    //when user clicks on Originator collapse image button then application will execute below code
        //    // this code will diplay only Originator and hiding EO related datagrid.

        //    if (e.CommandName == "OriginatorCollapse")
        //    {
        //        dgdSelectedEO.Visible = false;
        //        LabelHeadVisible(false);
        //        PagerButtonVisibility(false);
        //        //hdID.Value = ""
        //        //displayHead(False)

        //        ImageButton imgOriginator1 = default(ImageButton);
        //        imgOriginator1 = (ImageButton)e.Item.FindControl("imgOriginator1");
        //        ImageButton imgOriginator2 = default(ImageButton);
        //        imgOriginator2 = (ImageButton)e.Item.FindControl("imgOriginator2");
        //        imgOriginator1.Visible = true;
        //        imgOriginator2.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgOriginator1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdAllEOTree.Items.Count - 1; rowCount++)
        //        {


        //            Label lblPlantName = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblPlantName");
        //            Label lblOriginator = (Label)dgdAllEOTree.Items(rowCount).FindControl("lblOriginator");



        //            if (string.IsNullOrEmpty(lblPlantName.Text) & string.IsNullOrEmpty(lblOriginator.Text))
        //            {
        //                dgdAllEOTree.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }
        //}

        protected void dgdSelectedEO_PageIndexChanged(object source, EventArgs e)
        {
            try
            {                
                if(Session["intGlobalPlantID"]!=null)
                FillSelectedEOs(Convert.ToInt32(Session["intGlobalPlantID"]),Convert.ToString(Session["lblOriginator"]), Convert.ToString(Session["lblEOMode"] ));
            }
            catch (Exception exc)
            {

            }

        }

        //DataGrid which shows only originator - related events
        //


        //protected void dgdAllEOTreeforOriginator_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}

        //protected void dgdAllEOTreeforOriginator_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:

        //            if (!(Convert.ToString(ViewState["Expand")) == "ExpandMode"))
        //            {
        //                dgdSelectedEO.Visible = false;
        //                LabelHeadVisible(false);
        //                PagerButtonVisibility(false);
        //                //Displaying only Plant names in first load of datagrid
        //                ImageButton imgOrg1 = default(ImageButton);
        //                ImageButton imgOrg2 = default(ImageButton);
        //                imgOrg1 = (ImageButton)e.Item.FindControl("imgOrg1");
        //                imgOrg2 = (ImageButton)e.Item.FindControl("imgOrg2");
        //                imgOrg2.Visible = false;
        //                Label lblOnlyOriginator = default(Label);
        //                lblOnlyOriginator = (Label)e.Item.FindControl("lblOnlyOriginator");
        //                if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgOrg1.Visible = false;
        //                    imgOrg2.Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                dgdSelectedEO.Visible = false;
        //                LabelHeadVisible(false);
        //                PagerButtonVisibility(false);
        //                //Displaying only Plant names in first load of datagrid
        //                ImageButton imgOrg1 = default(ImageButton);
        //                ImageButton imgOrg2 = default(ImageButton);
        //                imgOrg1 = (ImageButton)e.Item.FindControl("imgOrg1");
        //                imgOrg2 = (ImageButton)e.Item.FindControl("imgOrg2");
        //                imgOrg2.Visible = true;
        //                imgOrg1.Visible = false;

        //                Label lblOnlyOriginator = default(Label);
        //                lblOnlyOriginator = (Label)e.Item.FindControl("lblOnlyOriginator");

        //                if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
        //                {
        //                    imgOrg1.Visible = false;
        //                    imgOrg2.Visible = false;
        //                }

        //            }
        //            break;
        //    }
        //}        
        protected void dgdAllEOTreeforOriginator_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    ImageButton imgOrg1 = (ImageButton)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTreeforOriginator.Columns["Originator"], "imgOrg1");
                    ImageButton imgOrg2 = (ImageButton)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTreeforOriginator.Columns["Originator"], "imgOrg2");
                    Label lblOnlyOriginator = (Label)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAllEOTreeforOriginator.Columns["Originator"], "lblOnlyOriginator");
                    if (ViewState["Expand"] != null)
                    {

                        if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                        {
                            dgdSelectedEO.Visible = false;
                            LabelHeadVisible(false);
                            //Displaying only Plant names in first load of datagrid                                                    
                            imgOrg2.Visible = false;

                            if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
                            {
                                imgOrg1.Visible = false;
                                imgOrg2.Visible = false;
                            }
                        }
                        else
                        {
                            dgdSelectedEO.Visible = false;
                            LabelHeadVisible(false);
                            //Displaying only Plant names in first load of datagrid                          
                            imgOrg2.Visible = true;
                            imgOrg1.Visible = false;
                            if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
                            {
                                imgOrg1.Visible = false;
                                imgOrg2.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        if (ViewState["OriginMain"] == null)
                        {
                            imgOrg1.Visible = false;
                            imgOrg2.Visible = false;
                            if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
                            {
                                imgOrg1.Visible = false;
                                imgOrg2.Visible = false;
                            }
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["OriginMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            imgOrg1.Visible = false;
                            imgOrg2.Visible = true;
                            if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
                            {
                                imgOrg1.Visible = false;
                                imgOrg2.Visible = false;
                            }
                        }
                        else
                        {
                            imgOrg1.Visible = true;
                            imgOrg2.Visible = false;
                            if (string.IsNullOrEmpty(lblOnlyOriginator.Text))
                            {
                                imgOrg1.Visible = false;
                                imgOrg2.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
            }
        }
        protected void imgOrg1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                
                FillAllEOsWithOriginator();
                ViewState["Expand"] = null;
                  ImageButton imgOriginator1=(ImageButton)sender;
                  ImageButton imgOriginator2 = (ImageButton)imgOriginator1.Parent.FindControl("imgOrg2");
                  imgOriginator1.Visible = false;
                  imgOriginator2.Visible = true;
                  GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgOriginator1.Parent;
                  int rowno = gvd.ItemIndex;
                  ViewState["OriginMain"] = Convert.ToString(rowno);
                 
                  strEOMode = Convert.ToString("0");
                  Label lblOnlyOriginator = (Label)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTreeforOriginator.Columns["Originator"], "lblOnlyOriginator");                      
                  FillSelectedEOs(0, lblOnlyOriginator.Text, strEOMode);
                  ViewState["Origin"] = lblOnlyOriginator.Text;
                  lblOriginatorVal.Visible = true;
                  lblOriginatorVal.Text = lblOnlyOriginator.Text;
                  Session["intGlobalPlantID"] = 0;
                  Session["lblOriginator"] = lblOnlyOriginator.Text;
                  Session["lblEOMode"] = strEOMode;

                        //for (int rowCount = rowno; rowCount <= dgdAllEOTreeforOriginator.VisibleRowCount - 1; rowCount++)
                        //{
                        //   // Label lblOnlyOriginator = (Label)dgdAllEOTreeforOriginator.Items(rowCount).FindControl("lblOnlyOriginator");
                        //    Label lblOnlyOriginator = (Label)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAllEOTreeforOriginator.Columns["Originator"], "lblOnlyOriginator");                      
                        //    for (int rowCount2 = 0; rowCount2 <= dgdAllEOTreeforOriginator.VisibleRowCount - 1; rowCount2++)
                        //    {
                        //        if (rowCount2 != rowCount)
                        //        {
                        //            ImageButton imgCollapse = (ImageButton)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(rowCount2, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOrg2");
                        //            imgCollapse.Visible = false;                                                               
                        //            //Make collapse button visible
                                    
                        //            ImageButton imgExpand = (ImageButton)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(rowCount2, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOrg1");
                        //            imgExpand.Visible = true;
                        //            //Make expand button invisible
                        //        }
                        //    }
                        //    ImageButton imgOrg2 = (ImageButton)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOrg2");
                            
                        //    imgOrg2.Visible = true;
                        //    //Make collapse button visible
                        //    ImageButton imgOrg1 = (ImageButton)dgdAllEOTreeforOriginator.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdAllEOTree.Columns["Originator"], "imgOrg1");                                                        
                        //    imgOrg1.Visible = false;
                        //    //Make expand button invisible                            

                        //    if (!string.IsNullOrEmpty(lblOnlyOriginator.Text))
                        //    {                          
                        //        strEOMode = Convert.ToString("0");
                        //        ViewState["Origin"] = lblOnlyOriginator.Text;
                        //        FillSelectedEOs(0, lblOnlyOriginator.Text, strEOMode);
                        //        intGlobalPlantID = 0;
                        //        strGlobalOriginator = lblOnlyOriginator.Text;
                        //        lblOriginatorlb.Visible = true;
                        //        lblOriginatorVal.Visible = true;
                        //        lblOriginatorVal.Text = lblOnlyOriginator.Text;
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        break; // TODO: might not be correct. Was : Exit For
                        //    }
                        //}
            }
            catch (Exception exc)
            {
                                
            }

        }
        protected void imgOrg2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ViewState["OriginMain"] = null;
                ViewState["Expand"] = "CollapseMode";
                ImageButton imgOrg2 = (ImageButton)sender;               
                imgOrg2.Visible = false;
                //Make collapse button invisible
                 ImageButton imgOrg1 = (ImageButton)imgOrg2.Parent.FindControl("imgOrg1");
                imgOrg1.Visible = true;
                //Make expand button visible
                dgdSelectedEO.Visible = false;              
                LabelHeadVisible(false);
            }
            catch (Exception exc)
            {

            }

        }
        //protected void dgdAllEOTreeforOriginator_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //If expand       
        //    if (e.CommandName == "ExpandOriginator")
        //    {

        //        int rowno = e.Item.ItemIndex;

        //        for (int rowCount = rowno; rowCount <= dgdAllEOTreeforOriginator.Items.Count - 1; rowCount++)
        //        {
        //            Label lblOnlyOriginator = (Label)dgdAllEOTreeforOriginator.Items(rowCount).FindControl("lblOnlyOriginator");

        //            for (int rowCount2 = 0; rowCount2 <= dgdAllEOTreeforOriginator.Items.Count - 1; rowCount2++)
        //            {
        //                if (rowCount2 != rowCount)
        //                {
        //                    ImageButton imgCollapse = default(ImageButton);
        //                    imgCollapse = (ImageButton)dgdAllEOTreeforOriginator.Items(rowCount2).FindControl("imgOrg2");
        //                    imgCollapse.Visible = false;
        //                    //Make collapse button visible

        //                    ImageButton imgExpand = default(ImageButton);
        //                    imgExpand = (ImageButton)dgdAllEOTreeforOriginator.Items(rowCount2).FindControl("imgOrg1");
        //                    imgExpand.Visible = true;
        //                    //Make expand button invisible
        //                }
        //            }

        //            ImageButton imgOrg2 = default(ImageButton);
        //            imgOrg2 = (ImageButton)dgdAllEOTreeforOriginator.Items(rowCount).FindControl("imgOrg2");
        //            imgOrg2.Visible = true;
        //            //Make collapse button visible

        //            ImageButton imgOrg1 = default(ImageButton);
        //            imgOrg1 = (ImageButton)dgdAllEOTreeforOriginator.Items(rowCount).FindControl("imgOrg1");
        //            imgOrg1.Visible = false;
        //            //Make expand button invisible
        //            Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgOrg2.ClientID + "').focus();");

        //            if (!string.IsNullOrEmpty(lblOnlyOriginator.Text))
        //            {
        //                dgdSelectedEO.Visible = true;
        //                dgdSelectedEO.CurrentPageIndex = 0;
        //                strEOMode = Convert.ToChar("0");
        //                ViewState["Origin") = lblOnlyOriginator.Text;
        //                FillSelectedEOs(0, lblOnlyOriginator.Text, strEOMode);
        //                intGlobalPlantID = 0;
        //                strGlobalOriginator = lblOnlyOriginator.Text;
        //                lblOriginatorlb.Visible = true;
        //                lblOriginatorVal.Visible = true;
        //                lblOriginatorVal.Text = lblOnlyOriginator.Text;
        //                return;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //        }
        //    }

        //    //when user clicks on collapse image button then application will execute below code
        //    // this code will diplay only Originator names and hiding selected eos for the originator.
        //    //If collapse
        //    if (e.CommandName == "CollapseOriginator")
        //    {
        //        ImageButton imgOrg2 = default(ImageButton);
        //        imgOrg2 = (ImageButton)e.Item.FindControl("imgOrg2");
        //        imgOrg2.Visible = false;
        //        //Make collapse button invisible

        //        ImageButton imgOrg1 = default(ImageButton);
        //        imgOrg1 = (ImageButton)e.Item.FindControl("imgOrg1");
        //        imgOrg1.Visible = true;
        //        //Make expand button visible
        //        dgdSelectedEO.Visible = false;
        //        PagerButtonVisibility(false);
        //        LabelHeadVisible(false);
        //    }
        //}
        #endregion

        #region "Click Events"

        protected void imgExpandAll_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            dgdSelectedEO.Visible = false;
            lblOriginatorVal.Visible = false;
            lblPlantVal.Visible = false;
            FillAllEOs();
        }

        protected void imgCollapseAll_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillAllEOs();
        }

        protected void imgCreateNewEO_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("../Common/NewEO.aspx");
        }

        #endregion

        #region "Radio Button Events"
        protected void dgdAllEOTreeforOriginator_PageIndexChanged(object sender, EventArgs e)
        {
            FillAllEOsWithOriginator();
        }
        protected void rdbAllEOFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(rdbAllEOFilter.SelectedValue) == 0)
            {
                dgdAllEOTree.Visible = true;
                dgdAllEOTreeforOriginator.Visible = false;
                ViewState["Expand"] = "CollapseMode";
                FillAllEOs();
                imgExpandAll.Visible = true;
                imgCollapseAll.Visible = true;
                dgdSelectedEO.Visible = false;
                lblPlantlb.Visible = true;
                lblPlantVal.Visible = false;
            }
            else if (Convert.ToInt32(rdbAllEOFilter.SelectedValue) == 1)
            {
                dgdAllEOTree.Visible = false;
                dgdAllEOTreeforOriginator.Visible = true;
                ViewState["Expand"] = "CollapseMode";
                FillAllEOsWithOriginator();
                imgExpandAll.Visible = false;
                imgCollapseAll.Visible = false;
                dgdSelectedEO.Visible = false;
                lblPlantlb.Visible = false;
                lblPlantVal.Visible = false;
            }
        }

        #endregion
    }
}