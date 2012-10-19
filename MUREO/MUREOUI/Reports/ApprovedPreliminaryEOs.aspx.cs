using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Collections;
using MUREOUI.Common;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Reports
{
    public partial class ApprovedPreliminaryEOs : System.Web.UI.Page
    {
        #region "Member Variables"

        DataSet dsAppPrelimEO;
        string strScript;
        static int intGlobalPlantID;
        static string strUserRole;
        #endregion
        static string strUserName;
        clsSecurity cls = new clsSecurity();
        #region "Page Events"

        protected void Page_Load(object sender, System.EventArgs e)
        {
            strUserRole = cls.UserRole();
            strUserName = cls.UserName;
            if (strUserRole == "MUREO_Admin")
            {
                imgCreateNewEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgCreateNewEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgCreateNewEO.Enabled = false;
                //Response.Redirect("~/Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgCreateNewEO.Enabled = false;
                //Response.Redirect("~/Common/Home.aspx")
            }
            if (!IsPostBack)
            {
                // HeadLabelVisible(False)               
                FillAppPreliminaryEOs();
                dgdPrelimSelectedEO.Visible = false;
            }
        }

        #endregion

        #region "User Define Methods"

        public void HeadLabelVisible(bool optVisible)
        {
            lblPlant.Visible = lblEOModeType.Visible = optVisible;
            if (optVisible == true && dgdPrelimSelectedEO.Visible == true)
                lblPlantVal.Visible = lblEOTypeVal.Visible = optVisible;
            else
                lblPlantVal.Visible = lblEOTypeVal.Visible = false;
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



        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAppPrelimSelectedEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in normal form.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/03/07                Md.Abdul allaam             1.0           created
        //***************************************************

        protected void FillAppPrelimSelectedEOs(int intPlantID)
        {

            try
            {
                DataSet dsSelectPrelimEOs = new DataSet();

                ClsMyEOs objEOs = new ClsMyEOs();
                if (objEOs.GetApprovedSelectedEO(intPlantID, "Preliminary", "", strUserName, ref dsSelectPrelimEOs))
                {

                    if (dsSelectPrelimEOs == null)
                    {
                        NoRecords();
                        dgdPrelimSelectedEO.DataSource = null;
                        dgdPrelimSelectedEO.Visible = false;
                    }
                    else if (dsSelectPrelimEOs.Tables.Count == 0)
                    {
                        NoRecords();
                        dgdPrelimSelectedEO.DataSource = null;
                        dgdPrelimSelectedEO.Visible = false;
                    }
                    else if (dsSelectPrelimEOs.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        dgdPrelimSelectedEO.DataSource = null;
                        dgdPrelimSelectedEO.Visible = false;
                    }
                    else if (dsSelectPrelimEOs.Tables[0].Rows.Count > 0)
                    {
                        dgdPrelimSelectedEO.DataSource = dsSelectPrelimEOs.Tables[0].DefaultView;

                        //Code added by Vijay
                        //if ((ViewState["SortExp"] != null))
                        //{
                        //    string SortExp = null;
                        //    string strSort = null;
                        //    DataView dv = new DataView(dsSelectPrelimEOs.Tables[0]);
                        //    //Create a data view for the sort
                        //    string imgAsc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                        //    string imgDesc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                        //    SortExp = ViewState["SortExp"];
                        //    strSort = SortExp + ViewState["StrSort"];
                        //    dv.Sort = strSort;
                        //    dgdPrelimSelectedEO.DataSource = dv;
                        //    foreach (DataGridColumn col in dgdPrelimSelectedEO.Columns)
                        //    {
                        //        string header_text = col.HeaderText;
                        //        int position = col.HeaderText.IndexOf("&nbsp;");
                        //        if (col.SortExpression == SortExp)
                        //        {
                        //            if (position > -1)
                        //            {
                        //                header_text = col.HeaderText.Substring(0, position);
                        //            }
                        //            if (Convert.ToString(ViewState["StrSort"]) == " Asc")
                        //            {
                        //                col.HeaderText = string.Concat(header_text, imgAsc);
                        //            }
                        //            else
                        //            {
                        //                col.HeaderText = string.Concat(header_text, imgDesc);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            if (position > -1)
                        //            {
                        //                header_text = col.HeaderText.Substring(0, position);
                        //                col.HeaderText = header_text;
                        //            }
                        //        }
                        //    }
                        //}
                        dgdPrelimSelectedEO.DataBind();
                        dgdPrelimSelectedEO.Visible = true;
                        lblPlantVal.Text = Convert.ToString(dsSelectPrelimEOs.Tables[0].Rows[0][8]);

                        //Following code is for enabling and disabling the links on the form based on the user roles.
                        if (strUserRole == "MUREO_Admin")
                        {
                            EnableDisableLinks(true);
                        }
                        else
                        {
                            EnableDisableLinks(false);
                        }
                        for (int numRows = 0; numRows <= dgdPrelimSelectedEO.VisibleRowCount - 1; numRows++)
                        {
                            Label lblISApproved = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Last Modified"], "lblISApprovar");
                            if (lblISApproved != null)
                            {
                                if (lblISApproved.Text.ToUpper() == "Yes".ToUpper())
                                {
                                    EnableDisableLinksForRow(true, numRows);
                                }
                                else
                                {
                                    EnableDisableLinksForRow(false, numRows);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + exMessage + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }
        public void EnableDisableLinksForRow(bool optBool, int numRows)
        {
            //following code is for hiding and showing of buttons based on the condition.            
            LinkButton lnkEONum = (LinkButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Num"], "hypEONumber");
            if (lnkEONum != null && (!optBool))
                lnkEONum.Enabled = optBool;

            LinkButton lnkEOTitle = (LinkButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Title"], "hypEOTitle");
            if (lnkEOTitle != null && (!optBool))
                lnkEOTitle.Enabled = optBool;

            LinkButton lnkEOModDate = (LinkButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Last Modified"], "hypModifiedDate");
            if (lnkEOModDate != null && (!optBool))
                lnkEOModDate.Enabled = optBool;
        }


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
            for (int numRows = 0; numRows <= dgdPrelimSelectedEO.VisibleRowCount - 1; numRows++)
            {
                LinkButton lnkEONum = (LinkButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Num"], "hypEONumber");
                if (lnkEONum != null && (!optBool))
                    lnkEONum.Enabled = optBool;
                LinkButton lnkEOTitle = (LinkButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Title"], "hypEOTitle");
                if (lnkEOTitle != null && (!optBool))
                    lnkEOTitle.Enabled = optBool;
                LinkButton lnkEOModDate = (LinkButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Last Modified"], "hypModifiedDate");
                if (lnkEOModDate != null && (!optBool))
                    lnkEOModDate.Enabled = optBool;
            }
        }


        //  *******--- FillAppPreliminaryEOs --- ***************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAppPreliminaryEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in the form of tree view.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/03/07                Md.Abdul allaam             1.0           created
        //***************************************************
        public void FillAppPreliminaryEOs()
        {
            try
            {
                dsAppPrelimEO = new DataSet();

                //Creating object from ReportsBo class
                ClsMyEOs objAllEos = new ClsMyEOs();
                //Dim objProjectsByCategory As New BusinessObject.MUREO.BusinessObject.MachinesByCategory

                if (objAllEos.GetApprovedEO("Preliminary", "", ref dsAppPrelimEO))
                {
                    if (dsAppPrelimEO == null)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        HeadLabelVisible(false);
                    }
                    else if (dsAppPrelimEO.Tables.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        HeadLabelVisible(false);
                    }
                    else if (dsAppPrelimEO.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        HeadLabelVisible(false);
                    }
                    else
                    {
                        tdDivider.Visible = true;
                        HeadLabelVisible(true);

                        //Temprary table for Approved Prelim Eo's

                        DataTable dtAppPrelimEos = new DataTable();

                        DataRow drAppPrelimEos = null;

                        dtAppPrelimEos.Columns.Add("Plant_ID");
                        dtAppPrelimEos.Columns.Add("Plant_Name");
                        dtAppPrelimEos.Columns.Add("EO_Mode");

                        //Below code for splitting data for treeview display and binding splitted data into temperory table
                        ArrayList arrayPlantName = new ArrayList();
                        ArrayList arrayPlantID = new ArrayList();

                        //First row item  from the dataset into the array i.e plant id and plant name mode.
                        string strPlantName = Convert.ToString(dsAppPrelimEO.Tables[0].Rows[0]["Plant_Name"]);
                        string strPlantID = Convert.ToString(dsAppPrelimEO.Tables[0].Rows[0]["Plant_ID"]);

                        //Adding Plant name to array`
                        arrayPlantName.Add(strPlantName);
                        arrayPlantID.Add(strPlantID);

                        //Adding all Plant names(Without repitition)

                        for (int rowCount = 0; rowCount <= dsAppPrelimEO.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            string strPlantName1 = Convert.ToString(dsAppPrelimEO.Tables[0].Rows[rowCount]["Plant_Name"]);
                            string strPlantID1 = Convert.ToString(dsAppPrelimEO.Tables[0].Rows[rowCount]["Plant_ID"]);


                            if (!(arrayPlantName.Contains(strPlantName1)))
                            {
                                arrayPlantName.Add(strPlantName1);
                                arrayPlantID.Add(strPlantID1);

                            }
                        }

                        //Based on Plant name storing Plant ID and Plant name into temperory table

                        for (int rowPlantNameCount = 0; rowPlantNameCount <= arrayPlantName.Count - 1; rowPlantNameCount++)
                        {
                            drAppPrelimEos = dtAppPrelimEos.NewRow();

                            drAppPrelimEos["Plant_ID"] = arrayPlantID[rowPlantNameCount];
                            drAppPrelimEos["Plant_Name"] = arrayPlantName[rowPlantNameCount];
                            drAppPrelimEos["EO_Mode"] = "";

                            dtAppPrelimEos.Rows.Add(drAppPrelimEos);

                            ArrayList arrayEOMode = new ArrayList();

                            string strPlanID = null;


                            //Adding EO Modes(Without repitition) based on Plant Name

                            for (int rowEOModeCount = 0; rowEOModeCount <= dsAppPrelimEO.Tables[0].Rows.Count - 1; rowEOModeCount++)
                            {

                                if (Convert.ToString(arrayPlantName[rowPlantNameCount]) == Convert.ToString(dsAppPrelimEO.Tables[0].Rows[rowEOModeCount][1]))
                                {
                                    string strEOMode = Convert.ToString(dsAppPrelimEO.Tables[0].Rows[rowEOModeCount][2]);

                                    strPlanID = Convert.ToString(dsAppPrelimEO.Tables[0].Rows[rowEOModeCount][0]);

                                    if (arrayEOMode.Count == 0)
                                    {
                                        arrayEOMode.Add(strEOMode);
                                    }

                                    if (!(arrayEOMode.Contains(strEOMode)))
                                    {
                                        arrayEOMode.Add(strEOMode);
                                    }

                                }

                            }


                            //Based on EO Mode storing Plant ID and EO Mode in to temperory table

                            for (int rowEOMode1 = 0; rowEOMode1 <= arrayEOMode.Count - 1; rowEOMode1++)
                            {
                                drAppPrelimEos = dtAppPrelimEos.NewRow();
                                drAppPrelimEos["Plant_ID"] = strPlanID;
                                drAppPrelimEos["EO_Mode"] = arrayEOMode[rowEOMode1];
                                dtAppPrelimEos.Rows.Add(drAppPrelimEos);

                            }
                        }
                        DataColumn dc = new DataColumn("Index");
                        dtAppPrelimEos.Columns.Add(dc);
                        Int32 ind = 0;
                        foreach (DataRow dr in dtAppPrelimEos.Rows)
                        {

                            dr["Index"] = ind;
                            ind++;
                        }
                        dgdAppPrelimEOTree.DataSource = dtAppPrelimEos;
                        dgdAppPrelimEOTree.DataBind();

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
        protected void dgdAppPrelimEOTree_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillAppPreliminaryEOs();
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgPlant2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            dgdPrelimSelectedEO.Visible = false;
            lblPlantVal.Visible = false;
            lblEOTypeVal.Visible = false;



            ImageButton imgPlant2 = (ImageButton)sender;
            ImageButton imgPlant1 = (ImageButton)imgPlant2.Parent.FindControl("imgPlant1");
            imgPlant2.Visible = false;
            imgPlant1.Visible = true;

            //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant1.ClientID + "').focus();");

            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
            int rowno = gvd.ItemIndex;


            for (int rowCount = rowno + 1; rowCount <= dgdAppPrelimEOTree.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                Label lblPlantName = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "lblPlantName");
                Label lblPlantId = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "lblPlanID");
                Label lblEOMode = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Type"], "lblEOMode");
                //lblPlantName.Visible = false;
                ImageButton imgEOMode1 = (ImageButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Type"], "imgEOMode1");
                ImageButton imgEOMode2 = (ImageButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Type"], "imgEOMode2");
                //ImageButton imgPlant2 = (ImageButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "imgPlant2");
                //ImageButton imgPlant1 = (ImageButton)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "imgPlant1");

                //Label lblPlantName = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblPlantName");
                //Label lblEOMode = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblEOMode");
                // Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)
                //ImageButton imgEOMode1 = default(ImageButton);
                //imgEOMode1 = (ImageButton)dgdAppPrelimEOTree.Items(rowCount).FindControl("imgEOMode1");
                //ImageButton imgEOMode2 = default(ImageButton);
                //imgEOMode2 = (ImageButton)dgdAppPrelimEOTree.Items(rowCount).FindControl("imgEOMode2");
                if (lblPlantName != null)
                {
                    if (string.IsNullOrEmpty(lblPlantName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        imgEOMode1.Visible = false;
                        imgEOMode2.Visible = false;
                        lblEOMode.Visible = false;

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
        protected void NoRecords()
        {
            string script = null;
            script = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        //  ************************************************
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
        //Sub DisplayBoundColumnValues(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
        //    'strCurrentStage = e.Item.Cells(4).Text
        //    'Dim intEOID As Integer = CInt(dgdSelectedEO.DataKeys(e.Item.ItemIndex))
        //    ' Dim strStatus As String = dgdMyEO.DataKeys(e.Item.Cells(6).Text))
        //    'aligining centre for open read only image.
        //    e.Item.Cells(3).HorizontalAlign = HorizontalAlign.Center
        //    If e.CommandName = "EONum_Link" Then
        //        'Response.Redirect("~/Common/NewEO.aspx?Mode=View&ID=" + intEOID.ToString())
        //        strScript = "alert('Page under construction');"
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
        //    ElseIf e.CommandName = "EOTitle_Link" Then
        //        strScript = "alert('Page under construction');"
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
        //    ElseIf e.CommandName = "ModifiedDate_Link" Then
        //        strScript = "alert('Page under construction');"
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
        //    ElseIf e.CommandName = "ReadOnly" Then
        //        strScript = "alert('Page under construction');"
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
        //    End If
        //    'FillSelectedEOs(intGlobalPlantID, strGlobalOriginator)
        //End Sub
        #endregion

        #region "Data Grid Events"
        protected void imgEOMode2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                FillAppPreliminaryEOs();
                ViewState["Expand"] = null;
                ViewState["EOMain"] = null;
                dgdPrelimSelectedEO.Visible = false;
                lblPlantVal.Visible = false;
                lblEOTypeVal.Visible = false;

                ImageButton imgEOMode1 = (ImageButton)sender;
                ImageButton imgEOMode2 = (ImageButton)imgEOMode1.Parent.FindControl("imgEOMode2");
                imgEOMode1.Visible = true;
                imgEOMode2.Visible = false;
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgEOMode1.Parent;
                int rowno = gvd.ItemIndex;
                //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgEOMode1.ClientID + "').focus();");             

                for (int rowCount = rowno + 1; rowCount <= dgdAppPrelimEOTree.VisibleRowCount - 1; rowCount++)
                {

                    Label lblPlantName = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "lblPlantName");
                    Label lblPlantId = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "lblPlantId");
                    Label lblEOMode = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Type"], "lblEOMode");

                    //Label lblPlantName = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblPlantName");
                    //Label lblEOMode = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblEOMode");
                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text) & string.IsNullOrEmpty(lblEOMode.Text))
                        {
                            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                            gvdc.Visible = false;
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
            catch (Exception exc)
            {

            }
        }
        protected void imgEOMode1_Command(object sender, CommandEventArgs e)
        {
            FillAppPreliminaryEOs();
            ViewState["Expand"] = null;
            ImageButton imgEOMode1 = (ImageButton)sender;
            ImageButton imgEOMode2 = (ImageButton)imgEOMode1.Parent.FindControl("imgEOMode2");
            imgEOMode1.Visible = false;
            imgEOMode2.Visible = true;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgEOMode1.Parent;
            int rowno = gvd.ItemIndex;
            dgdPrelimSelectedEO.Visible = true;
            lblPlantVal.Visible = true;
            lblEOTypeVal.Visible = true;
            Label lblPlantName = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "lblPlantName");
            //  Label lblPlantId = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["Plant"], "lblPlantId");
            // Label lblEOMode = (Label)dgdPrelimSelectedEO.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdPrelimSelectedEO.Columns["EO Type"], "lblEOMode");
            //lblPlantName.Visible = false;                            

            //hdID.Value = lblPlanID.Text + "," + lblOriginator.Text
            //Code added by Vijay
            ViewState["Plant_ID"] = Convert.ToString(e.CommandArgument);
            ViewState["EOMain"] = Convert.ToString(rowno);
            FillAppPrelimSelectedEOs(Convert.ToInt32(e.CommandArgument));
            intGlobalPlantID = Convert.ToInt32(e.CommandArgument);
            lblEOTypeVal.Text = Convert.ToString(e.CommandName);

            //strGlobalOriginator = Convert.ToString(lblOriginator.Text)                

        }
        protected void dgdAppPrelimEOTree_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    Label lblPlantName = (Label)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["Plant"], "lblPlantName");
                    Label lblPlantId = (Label)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["Plant"], "lblPlantId");
                    Label lblEOMode = (Label)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["EO Type"], "lblEOMode");
                    ImageButton imgEOMode1 = (ImageButton)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["EO Type"], "imgEOMode1");
                    ImageButton imgEOMode2 = (ImageButton)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["EO Type"], "imgEOMode2");
                    ImageButton imgPlant1 = (ImageButton)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["Plant"], "imgPlant1");
                    ImageButton imgPlant2 = (ImageButton)dgdAppPrelimEOTree.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["Plant"], "imgPlant2");
                    if (ViewState["Expand"] != null)
                    {
                        if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                        {

                            dgdPrelimSelectedEO.Visible = false;
                            lblPlantVal.Visible = false;
                            lblEOTypeVal.Visible = false;
                            //Displaying only Plant names in first load of datagrid                      
                            imgPlant2.Visible = false;
                            lblPlantId.Visible = false;
                            imgPlant1.Visible = true;
                            imgEOMode1.Visible = false;
                            lblPlantName.Visible = true;
                            imgEOMode2.Visible = false;
                            lblEOMode.Visible = false;

                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {

                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = false;
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = false;
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
                        else
                        {
                            if (dgdPrelimSelectedEO.Visible)
                            {
                                lblPlantVal.Visible = true;
                                lblEOTypeVal.Visible = true;
                            }

                            //Displaying only Plant names in first load of datagrid

                            imgPlant2.Visible = true;
                            imgPlant1.Visible = false;
                            lblEOMode.Visible = false;
                            lblPlantId.Visible = false;
                            lblPlantName.Visible = true;
                            imgEOMode1.Visible = false;
                            imgEOMode2.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = false;
                                imgEOMode1.Visible = true;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = true;
                                e.Row.Visible = true;

                            }



                            //Dim lblBrandSegmentID As Label
                            //lblBrandSegmentID = CType(e.Item.FindControl("lblBrandSegmentID"), Label)
                            //lblBrandSegmentID.Visible = False


                            if (string.IsNullOrEmpty(lblEOMode.Text))
                            {
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
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
                            imgEOMode1.Visible = false;
                            imgEOMode2.Visible = false;
                            lblEOMode.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = false;
                                lblEOMode.Visible = false;
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
                            imgEOMode1.Visible = false;
                            imgEOMode2.Visible = false;
                            lblEOMode.Visible = false;
                            e.Row.Visible = true;
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblPlantVal.Visible = false;
                            lblEOTypeVal.Visible = false;
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            lblPlantName.Visible = false;
                            imgEOMode1.Visible = false;
                            imgEOMode2.Visible = false;
                            lblEOMode.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text) && (!string.IsNullOrEmpty(lblEOMode.Text)))
                            {
                                imgEOMode1.Visible = true;
                                imgEOMode2.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = false;
                                lblEOMode.Visible = true;
                                lblPlantName.Visible = false;
                                e.Row.Visible = true;
                            }
                        }
                        else
                        {
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            lblPlantName.Visible = false;
                            imgEOMode1.Visible = false;
                            imgEOMode2.Visible = false;
                            lblEOMode.Visible = false;
                            if (!string.IsNullOrEmpty(lblPlantName.Text))
                            {

                                imgPlant1.Visible = true;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = true;
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = false;
                                e.Row.Visible = true;
                            }
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
                            }
                            if (string.IsNullOrEmpty(lblPlantName.Text) && string.IsNullOrEmpty(lblEOMode.Text))
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
                            lblEOTypeVal.Visible = true;
                            lblPlantName.Visible = false;
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            imgEOMode1.Visible = false;
                            imgEOMode2.Visible = true;
                            lblEOMode.Visible = true;
                            e.Row.Visible = true;
                        }
                    }

                }
            }
            catch (Exception exc)
            {
            }
        }
        //protected void dgdPrelimSelectedEO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    //strCurrentStage = e.Item.Cells(4).Text
        //    //Dim intEOID As Integer = CInt(dgdSelectedEO.DataKeys(e.Item.ItemIndex))
        //    // Dim strStatus As String = dgdMyEO.DataKeys(e.Item.Cells(6).Text))
        //    //aligining centre for open read only image.
        //    e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Center;

        //}

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgdAppPrelimEOTree_ItemDataBound()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of itemDataBound utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/03/07                Md.Abdul allaam             1.0           created
        //***************************************************

        //protected void dgdAppPrelimEOTree_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:

        //            if (!(Convert.ToString(ViewState["Expand")) == "ExpandMode"))
        //            {
        //                dgdPrelimSelectedEO.Visible = false;
        //                imgPrevious.Visible = false;
        //                imgNext.Visible = false;
        //                lblPlantVal.Visible = false;
        //                lblEOTypeVal.Visible = false;
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

        //                ImageButton imgEOMode1 = default(ImageButton);
        //                ImageButton imgEOMode2 = default(ImageButton);
        //                imgEOMode1 = (ImageButton)e.Item.FindControl("imgEOMode1");
        //                imgEOMode2 = (ImageButton)e.Item.FindControl("imgEOMode2");
        //                imgEOMode1.Visible = false;
        //                imgEOMode2.Visible = false;


        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgPlant1.Visible = false;
        //                    imgPlant2.Visible = false;
        //                }

        //            }
        //            else
        //            {
        //                dgdPrelimSelectedEO.Visible = false;
        //                imgPrevious.Visible = false;
        //                imgNext.Visible = false;
        //                lblPlantVal.Visible = false;
        //                lblEOTypeVal.Visible = false;

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

        //                ImageButton imgEOMode1 = default(ImageButton);
        //                ImageButton imgEOMode2 = default(ImageButton);
        //                imgEOMode1 = (ImageButton)e.Item.FindControl("imgEOMode1");
        //                imgEOMode2 = (ImageButton)e.Item.FindControl("imgEOMode2");
        //                imgEOMode1.Visible = true;
        //                imgEOMode2.Visible = false;

        //                //Dim lblBrandSegmentID As Label
        //                //lblBrandSegmentID = CType(e.Item.FindControl("lblBrandSegmentID"), Label)
        //                //lblBrandSegmentID.Visible = False
        //                Label lblEOMode = default(Label);
        //                lblEOMode = (Label)e.Item.FindControl("lblEOMode");

        //                if (string.IsNullOrEmpty(lblEOMode.Text))
        //                {
        //                    imgEOMode1.Visible = false;
        //                    imgEOMode2.Visible = false;
        //                }

        //            }
        //            break;
        //    }
        //}

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	dgdAppPrelimEOTree_ItemCommand()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of itemDataBound utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/31/07                Md.Abdul allaam             1.0           created
        //***************************************************

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
                for (int rowCount = rowno + 1; rowCount <= dgdAppPrelimEOTree.VisibleRowCount - 1; rowCount++)
                {


                    Label lblPlantName = (Label)dgdAppPrelimEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["Plant"], "lblPlantName");
                    Label lblEOMode = (Label)dgdAppPrelimEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["EO Type"], "lblEOMode");


                    ImageButton imgEOMode1 = (ImageButton)dgdAppPrelimEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["EO Type"], "imgEOMode1");
                    ImageButton imgEOMode2 = (ImageButton)dgdAppPrelimEOTree.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdAppPrelimEOTree.Columns["EO Type"], "imgEOMode2");

                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                            if (!string.IsNullOrEmpty(lblEOMode.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgEOMode1.Visible = true;
                                imgEOMode2.Visible = false;
                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = false;
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

        //protected void dgdAppPrelimEOTree_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //when user clicks on Plant expand image button then application will execute below code
        //    // this code will diplay Originator

        //    if (e.CommandName == "PlantExpand")
        //    {
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant2.Visible = true;

        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant1.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdAppPrelimEOTree.Items.Count - 1; rowCount++)
        //        {


        //            Label lblPlantName = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblPlantName");
        //            Label lblEOMode = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblEOMode");
        //            Label lblPlantId = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblPlanID");

        //            ImageButton imgEOMode1 = default(ImageButton);
        //            ImageButton imgEOMode2 = default(ImageButton);
        //            imgEOMode1 = (ImageButton)dgdAppPrelimEOTree.Items(rowCount).FindControl("imgEOMode1");
        //            imgEOMode2 = (ImageButton)dgdAppPrelimEOTree.Items(rowCount).FindControl("imgEOMode2");


        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lblEOMode.Text))
        //                {
        //                    dgdAppPrelimEOTree.Items(rowCount).Visible = true;
        //                    imgEOMode1.Visible = true;
        //                    imgEOMode2.Visible = false;
        //                    //lblBrandSegmentID.Visible = False
        //                }
        //                else
        //                {
        //                    dgdAppPrelimEOTree.Items(rowCount).Visible = false;
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
        //        dgdPrelimSelectedEO.Visible = false;
        //        imgPrevious.Visible = false;
        //        imgNext.Visible = false;
        //        lblPlantVal.Visible = false;
        //        lblEOTypeVal.Visible = false;

        //        dgdPrelimSelectedEO.Visible = false;
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


        //        for (int rowCount = rowno + 1; rowCount <= dgdAppPrelimEOTree.Items.Count - 1; rowCount++)
        //        {


        //            Label lblPlantName = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblPlantName");
        //            Label lblEOMode = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblEOMode");
        //            // Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)


        //            ImageButton imgEOMode1 = default(ImageButton);
        //            imgEOMode1 = (ImageButton)dgdAppPrelimEOTree.Items(rowCount).FindControl("imgEOMode1");
        //            ImageButton imgEOMode2 = default(ImageButton);
        //            imgEOMode2 = (ImageButton)dgdAppPrelimEOTree.Items(rowCount).FindControl("imgEOMode2");

        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                dgdAppPrelimEOTree.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }

        //    //when user clicks on EO Mode Expand image button then application will execute below code
        //    // this code will diplay all the EO related info in a new datagrid.
        //    if (e.CommandName == "EOModeExpand")
        //    {
        //        dgdPrelimSelectedEO.Visible = true;
        //        dgdPrelimSelectedEO.CurrentPageIndex = 0;
        //        imgNext.Visible = true;
        //        imgPrevious.Visible = true;
        //        lblPlantVal.Visible = true;
        //        lblEOTypeVal.Visible = true;

        //        Label lblPlantID = (Label)e.Item.FindControl("lblPlanID");
        //        Label lblEOMode = (Label)e.Item.FindControl("lblEOMode");

        //        //hdID.Value = lblPlanID.Text + "," + lblOriginator.Text
        //        //Code added by Vijay
        //        ViewState["Plant_ID") = lblPlantID.Text;

        //        FillAppPrelimSelectedEOs(Convert.ToInt32(lblPlantID.Text));
        //        intGlobalPlantID = Convert.ToInt32(lblPlantID.Text);
        //        lblEOTypeVal.Text = lblEOMode.Text;

        //        //strGlobalOriginator = Convert.ToString(lblOriginator.Text)


        //        ImageButton imgEOMode1 = default(ImageButton);
        //        imgEOMode1 = (ImageButton)e.Item.FindControl("imgEOMode1");
        //        ImageButton imgEOMode2 = default(ImageButton);
        //        imgEOMode2 = (ImageButton)e.Item.FindControl("imgEOMode2");
        //        imgEOMode1.Visible = false;
        //        imgEOMode2.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgEOMode2.ClientID + "').focus();");
        //    }


        //    //when user clicks on Originator collapse image button then application will execute below code
        //    // this code will diplay only Originator and hiding EO related datagrid.

        //    if (e.CommandName == "EOModeCollapse")
        //    {
        //        dgdPrelimSelectedEO.Visible = false;
        //        imgPrevious.Visible = false;
        //        imgNext.Visible = false;
        //        lblPlantVal.Visible = false;
        //        lblEOTypeVal.Visible = false;
        //        //hdID.Value = ""
        //        //displayHead(False)

        //        ImageButton imgEOMode1 = default(ImageButton);
        //        imgEOMode1 = (ImageButton)e.Item.FindControl("imgEOMode1");
        //        ImageButton imgEOMode2 = default(ImageButton);
        //        imgEOMode2 = (ImageButton)e.Item.FindControl("imgEOMode2");
        //        imgEOMode1.Visible = true;
        //        imgEOMode2.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgEOMode1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdAppPrelimEOTree.Items.Count - 1; rowCount++)
        //        {


        //            Label lblPlantName = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblPlantName");
        //            Label lblEOMode = (Label)dgdAppPrelimEOTree.Items(rowCount).FindControl("lblEOMode");



        //            if (string.IsNullOrEmpty(lblPlantName.Text) & string.IsNullOrEmpty(lblEOMode.Text))
        //            {
        //                dgdAppPrelimEOTree.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }
        //}

        //protected void dgdPrelimSelectedEO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    int intEOID = 0;
        //    if (e.CommandName == "EONum_Link")
        //    {
        //        intEOID = Convert.ToInt32(dgdPrelimSelectedEO.DataKeys(e.Item.ItemIndex));
        //        Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //        //strScript = "alert('Page under construction');"
        //        //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
        //    }
        //    else if (e.CommandName == "EOTitle_Link")
        //    {
        //        intEOID = Convert.ToInt32(dgdPrelimSelectedEO.DataKeys(e.Item.ItemIndex));
        //        Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //    }
        //    else if (e.CommandName == "ModifiedDate_Link")
        //    {
        //        intEOID = Convert.ToInt32(dgdPrelimSelectedEO.DataKeys(e.Item.ItemIndex));
        //        Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //    }
        //    else if (e.CommandName == "ReadOnly")
        //    {
        //        string view = null;
        //        intEOID = Convert.ToInt32(dgdPrelimSelectedEO.DataKeys(e.Item.ItemIndex));
        //        if (Strings.UCase(e.Item.Cells[4].Text) == Strings.UCase("Preliminary"))
        //        {
        //            view = "1";
        //        }
        //        else if (Strings.UCase(e.Item.Cells[4].Text) == Strings.UCase("Final"))
        //        {
        //            view = "2";
        //        }
        //        else if (Strings.UCase(e.Item.Cells[4].Text) == Strings.UCase("Closeout"))
        //        {
        //            view = "3";
        //        }
        //        Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", intEOID.ToString(), view.ToString(), "Report"));
        //    }
        //}

        protected void dgdPrelimSelectedEO_PageIndexChanged(object source, EventArgs e)
        {
            try
            {
                FillAppPrelimSelectedEOs(intGlobalPlantID);
            }
            catch (Exception exc)
            {

            }

        }

        //protected void dgdPrelimSelectedEO_SortCommand(object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        //{
        //    if (Convert.ToString(ViewState["StrSort")) == " Desc")
        //    {
        //        ViewState["StrSort"] = " Asc";
        //    }
        //    else
        //    {
        //        ViewState["StrSort"] = " Desc";
        //    }
        //    ViewState["SortExp"] = e.SortExpression;
        //    FillAppPrelimSelectedEOs(Convert.ToInt32(ViewState["Plant_ID")));
        //}
        #endregion

        #region "Button Events"

        protected void imgExpandAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            ViewState["EOMain"] = null;
            FillAppPreliminaryEOs();
            dgdPrelimSelectedEO.Visible = false;
            lblEOTypeVal.Visible = false;
            lblPlantVal.Visible = false;
        }

        protected void imgCollapseAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            ViewState["EOMain"] = null;
            FillAppPreliminaryEOs();
            dgdPrelimSelectedEO.Visible = false;
        }



        protected void ImgReadOnlyEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    string view = null;
                    int intEOID = Convert.ToInt32(e.CommandName);
                    if (Convert.ToString(e.CommandArgument).ToUpper() == "Preliminary".ToUpper())
                    {
                        view = "1";
                    }
                    else if (Convert.ToString(e.CommandArgument).ToUpper() == "Final".ToUpper())
                    {
                        view = "2";
                    }
                    else if (Convert.ToString(e.CommandArgument).ToUpper() == "Closeout".ToUpper())
                    {
                        view = "3";
                    }
                    Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", intEOID.ToString(), view.ToString(), "Report"));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void hypModifiedDate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", Convert.ToInt32(e.CommandName)));
            }
            catch (Exception exc)
            {

            }
        }
        protected void hypEOTitle_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", Convert.ToInt32(e.CommandName)));
            }
            catch (Exception exc)
            {

            }
        }
        protected void hypEONumber_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", Convert.ToInt32(e.CommandName)));
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCreateNewEO_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/NewEO.aspx");
        }
        #endregion

    }
}