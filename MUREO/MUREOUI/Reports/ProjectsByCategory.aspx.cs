using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOUI.Common;
using System.Collections;
using MUREOBAL;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Reports
{
    public partial class ProjectsByCategory : System.Web.UI.Page
    {
        #region "Declarations"
        DataSet dsProjByCategory;
        string strScript;
        DataTable dtProjByCategory;
        static int intGlobalCategoryID;
        static int intGlobalBrandID;
        clsSecurity cls = new clsSecurity();
        clsProjectsByCategory objclsProjectsByCategory = new clsProjectsByCategory();
        #endregion
        static string strUserRole;

        #region "Page Events"
        //
        //  ************************************************
        //Name   	    :	Page_Load
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Filling Basic information of the page
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07                 Bharath            1.0           created
        //***************************************************
        //

        protected void Page_Load(object sender, System.EventArgs e)
        {
            strUserRole = cls.UserRole();
            if (strUserRole == "MUREO_Admin")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = true;
                imgMyEvents.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = true;
                imgMyEvents.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = false;
                imgMyEvents.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = false;
                imgMyEvents.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }

            if (!Page.IsPostBack)
            {
                imgAdjStartDate.Attributes.Add("onclick", "javascript:return NavigateAdjstrtDt()");
                imgOpenDataExportPage.Attributes.Add("onclick", "javascript:return NavigateDataExport()");
                FillProjectsByCategory();
                dgProjects.Visible = false;
            }
        }
        #endregion

        #region "Functions"

        protected void NoDataForGrid()
        {
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true); ;
        }


        protected void FillProjects(int catID, int BSID)
        {
            try
            {
                DataSet dsProjects = new DataSet();

                if (objclsProjectsByCategory.FillProjectsByBrand(catID, BSID, ref dsProjects, "GET_MUR_Projects_By_Category_Details"))
                {

                    if (dsProjects.Tables[0].Rows.Count > 0)
                    {
                        dgProjects.DataSource = dsProjects.Tables[0].DefaultView;

                        //Code added by Vijay on 09/26/2007
                        //if ((ViewState["SortExp"] != null))
                        //{
                        //    string SortExp = null;
                        //    string strSort = null;
                        //    DataView dv = new DataView(dsProjects.Tables[0]);
                        //    //Create a data view for the sort
                        //    string imgAsc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                        //    string imgDesc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                        //    SortExp = ViewState["SortExp"];
                        //    strSort = SortExp + ViewState["StrSort"];
                        //    dv.Sort = strSort;
                        //    dgProjects.DataSource = dv;
                        //    foreach (DataGridColumn col in dgProjects.Columns)
                        //    {
                        //        string header_text = col.HeaderText;
                        //        int position = col.HeaderText.IndexOf("&nbsp;");
                        //        if (col.SortExpression == SortExp)
                        //        {
                        //            if (position > -1)
                        //            {
                        //                header_text = col.HeaderText.Substring(0, position);
                        //            }
                        //            if (ViewState["StrSort"] == " Asc")
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

                        dgProjects.DataBind();
                        dgProjects.Visible = true;
                    }
                }
                else
                {
                    NoDataForGrid();
                    dgProjects.DataSource = null;
                    dgProjects.Visible = false;
                    hdID.Value = "";
                }

                if (dsProjects.Tables[1].Rows.Count > 0)
                {
                    lblBrand.Text = Convert.ToString(dsProjects.Tables[1].Rows[0]["Brand_Segment_Name"]);
                    lblCategory.Text = Convert.ToString(dsProjects.Tables[1].Rows[0]["Category_Name"]);

                    // displayHead(True)
                }

                //If Not Session("Projects") Is Nothing Then
                //    Dim dtProj As DataTable = CType(Session("Projects"), DataTable)
                //    Dim dtProjects As New DataTable
                //    dtProjects = dtProj.Clone()

                //    For i As Integer = 0 To dtProj.Rows.Count - 1
                //        If Convert.ToString(dtProj.Rows(i).Item("Category_ID")) <> "" And Convert.ToString(dtProj.Rows(i).Item("Brand_Segment_ID")) <> "" Then
                //            Dim categoryID As Integer
                //            If Convert.ToInt32(dtProj.Rows(i).Item("Category_ID")) = catID And Convert.ToInt32(dtProj.Rows(i).Item("Brand_Segment_ID")) = BSID Then
                //                If Convert.ToString(dtProj.Rows(i).Item("Project_Name")) <> "" Then
                //                    dtProjects.ImportRow(dtProj.Rows(i))
                //                End If
                //            End If
                //        End If
                //    Next


                //End If

                //Following code is for enabling and disabling the links on the form based on the user roles.
                if (strUserRole == "MUREO_Admin")
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole == "MUREO_Editors")
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole == "MUREO_Readers")
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole == "Readers")
                {
                    EnableDisableLinks(true);
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
            for (int numRows = 0; numRows <= dgProjects.VisibleRowCount - 1; numRows++)
            {
                //LinkButton lnkProjectName = default(LinkButton);
                //lnkProjectName = (LinkButton)dgProjects.Items(numRows).FindControl("Linkbutton1");
                //lnkProjectName.Enabled = optBool;
            }
        }


        protected void displayHead(bool opt)
        {
            //lblBrand.Visible = opt
            //lblBrandHead.Visible = opt
            //lblCategory.Visible = opt
            //lblCategoryHead.Visible = opt
        }


        public void HeaderLabelData(bool optVisible)
        {
            lblCategory.Visible = optVisible;
            lblBrand.Visible = optVisible;
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



        //
        //  ************************************************
        //Name   	    :	FillProjectsByCategory class
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying Projects by Category.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07                 Bharath            1.0           created
        //**
        protected void FillProjectsByCategory()
        {
            try
            {
                // Dim i, j As Integer
                dsProjByCategory = new DataSet();

                //Creating object from ReportsBo class

                if (objclsProjectsByCategory.FillProjectsByCategoryBO("GET_MUR_Projects_By_Category", ref dsProjByCategory))
                {


                    if (dsProjByCategory == null)
                    {
                        NoRecords();
                        //tdDivider.Visible = false;
                        lblCategoryHead.Visible = false;
                        lblBrandHead.Visible = false;
                    }
                    else if (dsProjByCategory.Tables.Count == 0)
                    {
                        NoRecords();
                        //tdDivider.Visible = false;
                        lblCategoryHead.Visible = false;
                        lblBrandHead.Visible = false;
                    }
                    else if (dsProjByCategory.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        //tdDivider.Visible = false;
                        lblCategoryHead.Visible = false;
                        lblBrandHead.Visible = false;
                    }
                    else
                    {
                        //tdDivider.Visible = true;
                        lblCategoryHead.Visible = true;
                        lblBrandHead.Visible = true;
                        //Preaparing temerory table for ProjectsBycategory
                        dtProjByCategory = new DataTable();
                        DataRow drProjByCategory = null;
                        dtProjByCategory.Columns.Add("Category_ID");
                        dtProjByCategory.Columns.Add("Category_Name");
                        dtProjByCategory.Columns.Add("Brand_Segment_ID");
                        dtProjByCategory.Columns.Add("Brand_Segment_Name");
                        //Varma
                        //dtProjByCategory.Columns.Add("Project_ID")
                        //dtProjByCategory.Columns.Add("Project_Name")
                        //dtProjByCategory.Columns.Add("Project_Type_Name")
                        //dtProjByCategory.Columns.Add("Project_Lead")
                        //dtProjByCategory.Columns.Add("Point_Of_Contact")
                        //dtProjByCategory.Columns.Add("Modified_Date")



                        //Below code for splitting data for treeview display and binding splitted data into temperory table
                        ArrayList arrayCategoryName = new ArrayList();
                        ArrayList arrayCategoryID = new ArrayList();

                        //First row item of category name
                        string strCategoryName = Convert.ToString(dsProjByCategory.Tables[0].Rows[0][1]);
                        string strCategoryID = Convert.ToString(dsProjByCategory.Tables[0].Rows[0][0]);

                        //Adding Category name to array
                        arrayCategoryName.Add(strCategoryName);
                        arrayCategoryID.Add(strCategoryID);

                        //Adding all categoory names(Without repitition)

                        for (int rowCount = 0; rowCount <= dsProjByCategory.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            string strCategoryName1 = Convert.ToString(dsProjByCategory.Tables[0].Rows[rowCount][1]);
                            string strCategoryID1 = Convert.ToString(dsProjByCategory.Tables[0].Rows[rowCount][0]);


                            if (!(arrayCategoryName.Contains(strCategoryName1)))
                            {
                                arrayCategoryName.Add(strCategoryName1);
                                arrayCategoryID.Add(strCategoryID1);

                            }
                        }



                        //Based on Category name storing Category ID and Category name in to temperory table

                        for (int rowCategoryNameCount = 0; rowCategoryNameCount <= arrayCategoryName.Count - 1; rowCategoryNameCount++)
                        {
                            drProjByCategory = dtProjByCategory.NewRow();
                            drProjByCategory["Category_ID"] = arrayCategoryID[rowCategoryNameCount];
                            drProjByCategory["Category_Name"] = arrayCategoryName[rowCategoryNameCount];
                            drProjByCategory["Brand_Segment_ID"] = "";
                            drProjByCategory["Brand_Segment_Name"] = "";
                            //Varma
                            //drProjByCategory("Project_ID") = ""
                            //drProjByCategory("Project_Name") = ""
                            //drProjByCategory("Project_Type_Name") = ""
                            //drProjByCategory("Project_Lead") = ""
                            //drProjByCategory("Point_Of_Contact") = ""
                            //drProjByCategory("Modified_Date") = ""

                            dtProjByCategory.Rows.Add(drProjByCategory);

                            ArrayList arrayBrandName = new ArrayList();
                            ArrayList arrayBrandID = new ArrayList();

                            string strCatID = null;
                            //Category ID

                            //Adding brand names(Without repitition) based on Category Name

                            for (int rowBrandCount = 0; rowBrandCount <= dsProjByCategory.Tables[0].Rows.Count - 1; rowBrandCount++)
                            {

                                if (Convert.ToString(arrayCategoryName[rowCategoryNameCount]) == Convert.ToString(dsProjByCategory.Tables[0].Rows[rowBrandCount][1]))
                                {
                                    string strBrandName = Convert.ToString(dsProjByCategory.Tables[0].Rows[rowBrandCount][3]);
                                    string strBrandID = Convert.ToString(dsProjByCategory.Tables[0].Rows[rowBrandCount][2]);

                                    strCatID = Convert.ToString(dsProjByCategory.Tables[0].Rows[rowBrandCount][0]);

                                    if (arrayBrandName.Count == 0)
                                    {
                                        arrayBrandName.Add(strBrandName);
                                        arrayBrandID.Add(strBrandID);
                                    }

                                    if (!(arrayBrandName.Contains(strBrandName)))
                                    {
                                        arrayBrandName.Add(strBrandName);
                                        arrayBrandID.Add(strBrandID);
                                    }

                                }

                            }


                            //Based on Brand name storing Brand ID and Brand name in to temperory table

                            for (int rowBrandCount1 = 0; rowBrandCount1 <= arrayBrandName.Count - 1; rowBrandCount1++)
                            {
                                drProjByCategory = dtProjByCategory.NewRow();
                                drProjByCategory["Category_ID"] = strCatID;
                                drProjByCategory["Category_Name"] = "";
                                drProjByCategory["Brand_Segment_ID"] = arrayBrandID[rowBrandCount1];
                                drProjByCategory["Brand_Segment_Name"] = arrayBrandName[rowBrandCount1];
                                //Varma
                                //drProjByCategory("Project_ID") = ""
                                //drProjByCategory("Project_Name") = ""
                                //drProjByCategory("Project_Type_Name") = ""
                                //drProjByCategory("Project_Lead") = ""
                                //drProjByCategory("Point_Of_Contact") = ""
                                //drProjByCategory("Modified_Date") = ""

                                dtProjByCategory.Rows.Add(drProjByCategory);

                                //For rowBrandCount2 As Integer = 0 To dsProjByCategory.Tables(0).Rows.Count - 1

                                //    If Convert.ToString(arrayBrandName(rowBrandCount1)) = Convert.ToString(dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(3)) Then

                                //        drProjByCategory = dtProjByCategory.NewRow
                                //        drProjByCategory("Category_ID") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(0)
                                //        drProjByCategory("Category_Name") = ""
                                //        drProjByCategory("Brand_Segment_ID") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(2)
                                //        drProjByCategory("Brand_Segment_Name") = ""
                                //        drProjByCategory("Project_ID") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(4)
                                //        drProjByCategory("Project_Name") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(5)
                                //        drProjByCategory("Project_Type_Name") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(7)
                                //        drProjByCategory("Project_Lead") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(8)
                                //        drProjByCategory("Point_Of_Contact") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(9)
                                //        drProjByCategory("Modified_Date") = dsProjByCategory.Tables(0).Rows(rowBrandCount2).Item(10)

                                //        dtProjByCategory.Rows.Add(drProjByCategory)


                                //    End If

                                //Next
                            }
                        }
                        DataColumn dc = new DataColumn("Index");
                        dtProjByCategory.Columns.Add(dc);
                        Int32 ind = 0;
                        foreach (DataRow dr in dtProjByCategory.Rows)
                        {

                            dr["Index"] = ind;
                            ind++;
                        }
                        drgdProjByCategory.DataSource = dtProjByCategory;
                        drgdProjByCategory.DataBind();
                        //Session("Projects") = dtProjByCategory
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
        protected void drgdProjByCategory_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    Label lblCategoryName = (Label)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "lblCategoryName");
                    Label lblCategoryID = (Label)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "lblCategoryID");
                    Label lblbrandSegmentName = (Label)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "lblbrandSegmentName");
                    ImageButton imgBrandSegment1 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "imgBrandSegment1");
                    ImageButton imgBrandSegment2 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "imgBrandSegment2");
                    ImageButton imgCategory1 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "imgCategory1");
                    ImageButton imgCategory2 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "imgCategory2");
                    if (ViewState["Expand"] != null)
                    {
                        if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                        {

                            dgProjects.Visible = false;
                            lblCategory.Visible = false;
                            lblBrand.Visible = false;
                            //Displaying only Plant names in first load of datagrid                      
                            imgCategory2.Visible = false;
                            lblCategoryID.Visible = false;
                            imgCategory1.Visible = true;
                            imgBrandSegment1.Visible = false;
                            lblCategoryName.Visible = true;
                            imgBrandSegment2.Visible = false;
                            lblbrandSegmentName.Visible = false;

                            if (string.IsNullOrEmpty(lblCategoryName.Text))
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
                                //e.Row.Visible = false;
                                //e.Row.CssClass = "hiddencol";    
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                lblCategoryName.Visible = false;
                                imgBrandSegment1.Visible = false;
                                imgBrandSegment2.Visible = false;
                                lblbrandSegmentName.Visible = false;
                            }

                        }
                        else
                        {
                            if (dgProjects.Visible)
                            {
                                lblCategory.Visible = true;
                                lblBrand.Visible = true;
                            }

                            //Displaying only Plant names in first load of datagrid

                            imgCategory2.Visible = true;
                            imgCategory1.Visible = false;
                            lblbrandSegmentName.Visible = false;
                            lblCategoryID.Visible = false;
                            lblCategoryName.Visible = true;
                            imgBrandSegment1.Visible = false;
                            imgBrandSegment2.Visible = false;
                            if (string.IsNullOrEmpty(lblCategoryName.Text))
                            {
                                //if (e.Row.Cells.Count > 1)
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //    if (e.Row.Cells[1] != null)
                                //        e.Row.Cells[1].CssClass = "viscol";
                                //    if (e.Row != null)
                                //        e.Row.CssClass = "viscol";
                                //}
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //}
                                e.Row.Visible = true;

                                //e.Row.CssClass = "viscol"; 
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                lblCategoryName.Visible = false;
                                imgBrandSegment1.Visible = true;
                                imgBrandSegment2.Visible = false;
                                lblbrandSegmentName.Visible = true;
                            }
                            //Dim lblBrandSegmentID As Label
                            //lblBrandSegmentID = CType(e.Item.FindControl("lblBrandSegmentID"), Label)
                            //lblBrandSegmentID.Visible = False
                            //if (string.IsNullOrEmpty(lblbrandSegmentName.Text))
                            //{                               
                            //    imgBrandSegment1.Visible = false;
                            //    imgBrandSegment2.Visible = false;
                            //}
                            //if (string.IsNullOrEmpty(lblbrandSegmentName.Text) && string.IsNullOrEmpty(lblCategoryName.Text))
                            //{
                            //    if (e.Row.Cells.Count > 1)
                            //    {
                            //        if (e.Row.Cells[0] != null)
                            //            e.Row.Cells[0].CssClass = "hiddencol";
                            //        if (e.Row.Cells[1] != null)
                            //            e.Row.Cells[1].CssClass = "hiddencol";
                            //        if (e.Row != null)
                            //            e.Row.CssClass = "hiddencol";
                            //    }
                            //    else
                            //    {
                            //        if (e.Row.Cells[0] != null)
                            //            e.Row.Cells[0].CssClass = "hiddencol";
                            //    }
                            //    //e.Row.CssClass = "hiddencol";  
                            //    imgBrandSegment1.Visible = false;
                            //    imgBrandSegment2.Visible = false;
                            //}

                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgCategory2.Visible = false;
                            imgCategory1.Visible = true;
                            lblCategoryName.Visible = true;
                            imgBrandSegment1.Visible = false;
                            imgBrandSegment2.Visible = false;
                            lblbrandSegmentName.Visible = false;
                            if (string.IsNullOrEmpty(lblCategoryName.Text))
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
                                //e.Row.Visible = false;
                                //e.Row.CssClass = "hiddencol";    
                                imgBrandSegment1.Visible = false;
                                lblCategoryName.Visible = false;
                                imgBrandSegment2.Visible = false;
                                imgCategory2.Visible = false;
                                imgCategory1.Visible = false;
                                lblbrandSegmentName.Visible = false;
                            }
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblCategoryName.Visible = true;
                            imgCategory2.Visible = true;
                            imgCategory1.Visible = false;
                            imgBrandSegment1.Visible = false;
                            imgBrandSegment2.Visible = false;
                            lblbrandSegmentName.Visible = false;
                            //if (e.Row.Cells.Count > 1)
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //    if (e.Row.Cells[1] != null)
                            //        e.Row.Cells[1].CssClass = "viscol";
                            //    if (e.Row != null)
                            //        e.Row.CssClass = "viscol";
                            //}
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //}
                            e.Row.Visible = true;
                            //e.Row.CssClass = "viscol"; 
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {                          
                            imgCategory2.Visible = false;
                            imgCategory1.Visible = false;
                            lblCategoryName.Visible = false;
                            imgBrandSegment1.Visible = false;
                            imgBrandSegment2.Visible = false;
                            lblbrandSegmentName.Visible = false;

                            if (string.IsNullOrEmpty(lblCategoryName.Text) && !string.IsNullOrEmpty(lblbrandSegmentName.Text))
                            {
                                //if (e.Row.Cells.Count > 1)
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //    if (e.Row.Cells[1] != null)
                                //        e.Row.Cells[1].CssClass = "viscol";
                                //    if (e.Row != null)
                                //        e.Row.CssClass = "viscol";
                                //}
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //}
                                e.Row.Visible = true;
                                //e.Row.CssClass = "viscol"; 
                                imgBrandSegment1.Visible = true;
                                imgBrandSegment2.Visible = false;                               
                                imgCategory2.Visible = false;
                                imgCategory1.Visible = false;
                                lblbrandSegmentName.Visible = true;
                                lblCategoryName.Visible = false;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(lblCategoryName.Text))
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
                            //e.Row.Visible = false;
                            //e.Row.CssClass = "hiddencol"; 
                            imgCategory2.Visible = false;
                            imgCategory1.Visible = false;
                            lblCategoryName.Visible = false;
                            imgBrandSegment1.Visible = false;
                            imgBrandSegment2.Visible = false;
                            lblbrandSegmentName.Visible = false;
                            if (!string.IsNullOrEmpty(lblCategoryName.Text))
                            {
                                imgCategory2.Visible = false;
                                imgCategory1.Visible = true;
                                lblCategoryName.Visible = true;
                                imgBrandSegment1.Visible = false;
                                imgBrandSegment2.Visible = false;
                                lblbrandSegmentName.Visible = false;
                                //if (e.Row.Cells.Count > 1)
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //    if (e.Row.Cells[1] != null)
                                //        e.Row.Cells[1].CssClass = "viscol";
                                //    if (e.Row != null)
                                //        e.Row.CssClass = "viscol";
                                //}
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //}
                                e.Row.Visible = true;
                            }
                            if (string.IsNullOrEmpty(lblbrandSegmentName.Text) && string.IsNullOrEmpty(lblCategoryName.Text))
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
                            lblCategory.Visible = true;
                            lblBrand.Visible = true;
                            lblCategoryName.Visible = false;
                            imgCategory2.Visible = false;
                            imgCategory1.Visible = false;
                            imgBrandSegment1.Visible = false;
                            imgBrandSegment2.Visible = true;
                            lblbrandSegmentName.Visible = true;
                            //if (e.Row.Cells.Count > 1)
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //    if (e.Row.Cells[1] != null)
                            //        e.Row.Cells[1].CssClass = "viscol";
                            //    if (e.Row != null)
                            //        e.Row.CssClass = "viscol";
                            //}
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //}
                            e.Row.Visible = true;
                            //e.Row.CssClass = "viscol"; 
                        }
                    }

                }
            }
            catch (Exception exc)
            {
            }
        }

        protected void drgdProjByCategory_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillProjectsByCategory();
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCategory2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            dgProjects.Visible = false;
            lblCategory.Visible = false;
            lblBrand.Visible = false;



            ImageButton imgCategory2 = (ImageButton)sender;
            ImageButton imgCategory1 = (ImageButton)imgCategory2.Parent.FindControl("imgCategory1");
            imgCategory2.Visible = false;
            imgCategory1.Visible = true;

            //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgCategory1.ClientID + "').focus();");

            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgCategory1.Parent;
            int rowno = gvd.ItemIndex;


            for (int rowCount = rowno + 1; rowCount <= drgdProjByCategory.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                Label lblCategoryName = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "lblCategoryName");
                Label lblPlantId = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "lblCategoryID");
                Label lblbrandSegmentName = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "lblbrandSegmentName");
                //lblCategoryName.Visible = false;
                ImageButton imgBrandSegment1 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "imgBrandSegment1");
                ImageButton imgBrandSegment2 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "imgBrandSegment2");
                //ImageButton imgCategory2 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgProjects.Columns["Plant"], "imgCategory2");
                //ImageButton imgCategory1 = (ImageButton)dgProjects.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgProjects.Columns["Plant"], "imgCategory1");

                //Label lblCategoryName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName");
                //Label lblbrandSegmentName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName");
                // Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)
                //ImageButton imgBrandSegment1 = default(ImageButton);
                //imgBrandSegment1 = (ImageButton)drgdProjByCategory.Items(rowCount).FindControl("imgBrandSegment1");
                //ImageButton imgBrandSegment2 = default(ImageButton);
                //imgBrandSegment2 = (ImageButton)drgdProjByCategory.Items(rowCount).FindControl("imgBrandSegment2");
                if (lblCategoryName != null)
                {
                    if (string.IsNullOrEmpty(lblCategoryName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        imgBrandSegment1.Visible = false;
                        imgBrandSegment2.Visible = false;
                        lblbrandSegmentName.Visible = false;

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
        protected void imgCategory1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                string st = string.Empty;

                ImageButton imgCategory1 = (ImageButton)sender;
                imgCategory1.Visible = false;
                ImageButton imgCategory2 = (ImageButton)imgCategory1.Parent.FindControl("imgCategory2");
                imgCategory2.Visible = true;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgCategory2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgCategory1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= drgdProjByCategory.VisibleRowCount - 1; rowCount++)
                {
                   
                 
                    Label lblCategoryName = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "lblCategoryName");
                    Label lblbrandSegmentName = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "lblbrandSegmentName");


                    ImageButton imgBrandSegment1 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "imgBrandSegment1");
                    ImageButton imgBrandSegment2 = (ImageButton)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "imgBrandSegment2");

                    
                        if (string.IsNullOrEmpty(lblCategoryName.Text))
                        {
                            if (!string.IsNullOrEmpty(lblbrandSegmentName.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblbrandSegmentName.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgBrandSegment1.Visible = true;
                                imgBrandSegment2.Visible = false;
                                lblbrandSegmentName.Visible = true;
                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblbrandSegmentName.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgBrandSegment1.Visible = false;
                                imgBrandSegment2.Visible = false;
                                lblbrandSegmentName.Visible = false;
                            }

                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                   

                }
                ViewState["Single"] = st.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        //
        //  ************************************************
        //Name   	    :	NoRecords
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying alert message when no results found
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/23/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void NoRecords()
        {
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }
        #endregion

        #region "Datagrid Events"
        //
        //  ************************************************
        //Name   	    :	drgdProjByCategory_ItemDataBound
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying only Category names in first load of datagrid
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/23/07                 Bharath            1.0           created
        //***************************************************
        //
        //protected void drgdProjByCategory_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:

        //            if (!(Convert.ToString(ViewState["Expand")) == "ExpandMode"))
        //            {
        //                dgProjects.Visible = false;
        //                PageButtonVisibility(false);
        //                HeaderLabelData(false);

        //                //Displaying only Category names in first load of datagrid
        //                ImageButton imgCategory1 = default(ImageButton);
        //                ImageButton imgCategory2 = default(ImageButton);
        //                imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //                imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //                imgCategory2.Visible = false;
        //                Label lblCategoryID = default(Label);
        //                lblCategoryID = (Label)e.Item.FindControl("lblCategoryID");
        //                lblCategoryID.Visible = false;
        //                Label lblCategoryName = default(Label);
        //                lblCategoryName = (Label)e.Item.FindControl("lblCategoryName");

        //                ImageButton imgBrandSegment1 = default(ImageButton);
        //                ImageButton imgBrandSegment2 = default(ImageButton);
        //                imgBrandSegment1 = (ImageButton)e.Item.FindControl("imgBrandSegment1");
        //                imgBrandSegment2 = (ImageButton)e.Item.FindControl("imgBrandSegment2");
        //                imgBrandSegment1.Visible = false;
        //                imgBrandSegment2.Visible = false;


        //                if (string.IsNullOrEmpty(lblCategoryName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgCategory1.Visible = false;
        //                    imgCategory2.Visible = false;
        //                }


        //            }
        //            else
        //            {
        //                dgProjects.Visible = false;
        //                PageButtonVisibility(false);
        //                HeaderLabelData(false);

        //                //this code for when user clicks on Expand button then diplaying all details in expand mode
        //                //If (e.Item.ItemIndex Mod 2 = 0) Then

        //                //    e.Item.Cells(2).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(3).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(4).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(5).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(6).Attributes("Class") = "AlterNateRow2"
        //                //Else
        //                //    e.Item.Cells(2).Attributes("Class") = "AlterNateRow1"
        //                //    e.Item.Cells(3).Attributes("Class") = "AlterNateRow1"
        //                //    e.Item.Cells(4).Attributes("Class") = "AlterNateRow1"
        //                //    e.Item.Cells(5).Attributes("Class") = "AlterNateRow1"
        //                //    e.Item.Cells(6).Attributes("Class") = "AlterNateRow1"

        //                //End If


        //                //Displaying only Category names in first load of datagrid
        //                ImageButton imgCategory1 = default(ImageButton);
        //                ImageButton imgCategory2 = default(ImageButton);
        //                imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //                imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //                imgCategory2.Visible = true;
        //                imgCategory1.Visible = false;

        //                Label lblCategoryID = default(Label);
        //                lblCategoryID = (Label)e.Item.FindControl("lblCategoryID");
        //                lblCategoryID.Visible = false;
        //                Label lblCategoryName = default(Label);
        //                lblCategoryName = (Label)e.Item.FindControl("lblCategoryName");

        //                if (string.IsNullOrEmpty(lblCategoryName.Text))
        //                {
        //                    imgCategory1.Visible = false;
        //                    imgCategory2.Visible = false;
        //                }

        //                ImageButton imgBrandSegment1 = default(ImageButton);
        //                ImageButton imgBrandSegment2 = default(ImageButton);
        //                imgBrandSegment1 = (ImageButton)e.Item.FindControl("imgBrandSegment1");
        //                imgBrandSegment2 = (ImageButton)e.Item.FindControl("imgBrandSegment2");
        //                imgBrandSegment1.Visible = true;
        //                imgBrandSegment2.Visible = false;

        //                Label lblBrandSegmentID = default(Label);
        //                lblBrandSegmentID = (Label)e.Item.FindControl("lblBrandSegmentID");
        //                lblBrandSegmentID.Visible = false;
        //                Label lblbrandSegmentName = default(Label);
        //                lblbrandSegmentName = (Label)e.Item.FindControl("lblbrandSegmentName");

        //                if (string.IsNullOrEmpty(lblbrandSegmentName.Text))
        //                {
        //                    imgBrandSegment1.Visible = false;
        //                    imgBrandSegment2.Visible = false;
        //                }

        //                //Dim lblProjectID As Label
        //                //lblProjectID = CType(e.Item.FindControl("lblProjectID"), Label)
        //                //lblProjectID.Visible = False

        //                //If lblProjectID.Text = "" Then
        //                //    e.Item.Cells(2).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(3).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(4).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(5).Attributes("Class") = "AlterNateRow2"
        //                //    e.Item.Cells(6).Attributes("Class") = "AlterNateRow2"
        //                //End If

        //            }
        //            break;
        //    }
        //}

        protected void imgBrandSegment1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                FillProjectsByCategory();
                ViewState["Expand"] = null;
                ImageButton imgBrandSegment1 = (ImageButton)sender;
                ImageButton imgBrandSegment2 = (ImageButton)imgBrandSegment1.Parent.FindControl("imgBrandSegment2");
                imgBrandSegment1.Visible = false;
                imgBrandSegment2.Visible = true;
                dgProjects.Visible = true;

                //dgProjects.Visible = True
                    
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgBrandSegment1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["EOMain"] = Convert.ToString(rowno);
                Label lblCatID = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowno, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "lblCatID");
                Label lblBrandID = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowno, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "lblBrandSegmentID");
                hdID.Value = lblCatID.Text + "," + lblBrandID.Text;

                //Code added by Vijay 
                ViewState["Cat_ID"] = lblCatID.Text;
                ViewState["Brand_ID"] = lblBrandID.Text;

                FillProjects(Convert.ToInt32(lblCatID.Text), Convert.ToInt32(lblBrandID.Text));
                intGlobalCategoryID = Convert.ToInt32(lblCatID.Text);
                intGlobalBrandID = Convert.ToInt32(lblBrandID.Text);



                //Dim rowno As Integer = e.Item.ItemIndex

                //For rowCount As Integer = rowno + 1 To drgdProjByCategory.Items.Count - 1

                //    Dim lblCategoryName As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName"), Label)
                //    Dim lblbrandSegmentName As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName"), Label)
                //    Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)
                //    Dim lblProjectTypeName As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblProjectTypeName"), Label)
                //    Dim lblProjectID As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblProjectID"), Label)


                //    If lblbrandSegmentName.Text = "" And lblCategoryName.Text = "" Then

                //        If Not lblProjectTypeName.Text = "" Then
                //            drgdProjByCategory.Items(rowCount).Visible = True
                //            lblProjectID.Visible = False


                //            If (rowCount Mod 2 = 0) Then
                //                drgdProjByCategory.Items(rowCount).Cells(2).Attributes("Class") = "AlterNateRow2"
                //                drgdProjByCategory.Items(rowCount).Cells(3).Attributes("Class") = "AlterNateRow2"
                //                drgdProjByCategory.Items(rowCount).Cells(4).Attributes("Class") = "AlterNateRow2"
                //                drgdProjByCategory.Items(rowCount).Cells(5).Attributes("Class") = "AlterNateRow2"
                //                drgdProjByCategory.Items(rowCount).Cells(6).Attributes("Class") = "AlterNateRow2"

                //            Else
                //                drgdProjByCategory.Items(rowCount).Cells(2).Attributes("Class") = "AlterNateRow1"
                //                drgdProjByCategory.Items(rowCount).Cells(3).Attributes("Class") = "AlterNateRow1"
                //                drgdProjByCategory.Items(rowCount).Cells(4).Attributes("Class") = "AlterNateRow1"
                //                drgdProjByCategory.Items(rowCount).Cells(5).Attributes("Class") = "AlterNateRow1"
                //                drgdProjByCategory.Items(rowCount).Cells(6).Attributes("Class") = "AlterNateRow1"
                //            End If




                //        Else
                //            drgdProjByCategory.Items(rowCount).Visible = False
                //        End If

                //    Else
                //        Exit For
                //    End If

                //Next          
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgBrandSegment2_Command(object sender, CommandEventArgs e)
        {
            try
            {

                dgProjects.Visible = false;

                hdID.Value = "";
                ViewState["Expand"] = null;
                ViewState["EOMain"] = null;
                ImageButton imgBrandSegment2 = (ImageButton)sender;
                ImageButton imgBrandSegment1 = (ImageButton)imgBrandSegment2.Parent.FindControl("imgBrandSegment1");
                imgBrandSegment1.Visible = true;
                imgBrandSegment2.Visible = false;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgBrandSegment1.ClientID + "').focus();");

                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgBrandSegment1.Parent;
                int rowno = gvd.ItemIndex;


                for (int rowCount = rowno + 1; rowCount <= drgdProjByCategory.VisibleRowCount - 1; rowCount++)
                {

                    Label lblCategoryName = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Category"], "lblCategoryName");
                    Label lblbrandSegmentName = (Label)drgdProjByCategory.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdProjByCategory.Columns["Brand"], "lblbrandSegmentName");

                    //Label lblCategoryName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName");
                    //Label lblbrandSegmentName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName");

                    if (lblCategoryName != null)
                    {
                        if (string.IsNullOrEmpty(lblCategoryName.Text) & string.IsNullOrEmpty(lblbrandSegmentName.Text))
                        {
                            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblbrandSegmentName.Parent.Parent.Parent;
                            gvdc.Visible = true;
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                }

            }
            catch (Exception exc)
            {

            }
        }
        //
        //  ************************************************
        //Name   	    :	drgdProjByCategory_ItemDataBound
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying Category names,Brand Names amd Project details based on user click event
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/23/07                 Bharath            1.0           created
        //***************************************************
        //

        //protected void drgdProjByCategory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //when user clicks on category expand image button then application will execute below code
        //    // this code will diplay brand names
        //    if (e.CommandName == "CategoryExpand")
        //    {
        //        dgProjects.Visible = false;
        //        PageButtonVisibility(false);
        //        HeaderLabelData(false);

        //        ImageButton imgCategory2 = default(ImageButton);
        //        imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //        imgCategory2.Visible = true;

        //        ImageButton imgCategory1 = default(ImageButton);
        //        imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //        imgCategory1.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgCategory2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= drgdProjByCategory.Items.Count - 1; rowCount++)
        //        {
        //            Label lblCategoryName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName");
        //            Label lblbrandSegmentName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName");
        //            Label lblBrandSegmentID = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblBrandSegmentID");

        //            ImageButton imgBrandSegment1 = default(ImageButton);
        //            ImageButton imgBrandSegment2 = default(ImageButton);
        //            imgBrandSegment1 = (ImageButton)drgdProjByCategory.Items(rowCount).FindControl("imgBrandSegment1");
        //            imgBrandSegment2 = (ImageButton)drgdProjByCategory.Items(rowCount).FindControl("imgBrandSegment2");


        //            if (string.IsNullOrEmpty(lblCategoryName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lblbrandSegmentName.Text))
        //                {
        //                    drgdProjByCategory.Items(rowCount).Visible = true;
        //                    imgBrandSegment1.Visible = true;
        //                    imgBrandSegment2.Visible = false;
        //                    lblBrandSegmentID.Visible = false;
        //                }
        //                else
        //                {
        //                    drgdProjByCategory.Items(rowCount).Visible = false;
        //                }

        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }

        //    }

        //    //when user clicks on category collapse image button then application will execute below code
        //    // this code will diplay only category names and hiding Brand names
        //    if (e.CommandName == "CategoryCollapse")
        //    {
        //        PageButtonVisibility(false);
        //        HeaderLabelData(false);
        //        dgProjects.Visible = false;
        //        hdID.Value = "";
        //        //           displayHead(False)

        //        ImageButton imgCategory2 = default(ImageButton);
        //        imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //        imgCategory2.Visible = false;

        //        ImageButton imgCategory1 = default(ImageButton);
        //        imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //        imgCategory1.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgCategory1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= drgdProjByCategory.Items.Count - 1; rowCount++)
        //        {
        //            Label lblCategoryName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName");
        //            Label lblbrandSegmentName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName");
        //            LinkButton lnkprojectName = (LinkButton)drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName");


        //            ImageButton imgBrandSegment1 = default(ImageButton);
        //            imgBrandSegment1 = (ImageButton)drgdProjByCategory.Items(rowCount).FindControl("imgBrandSegment1");
        //            ImageButton imgBrandSegment2 = default(ImageButton);
        //            imgBrandSegment2 = (ImageButton)drgdProjByCategory.Items(rowCount).FindControl("imgBrandSegment2");

        //            if (string.IsNullOrEmpty(lblCategoryName.Text))
        //            {
        //                drgdProjByCategory.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }

        //    //when user clicks on Brand Name Expand image button then application will execute below code
        //    // this code will diplay only Project names and project details
        //    if (e.CommandName == "BrandSegmentExpand")
        //    {
        //        dgProjects.CurrentPageIndex = 0;
        //        dgProjects.Visible = true;
        //        PageButtonVisibility(true);
        //        HeaderLabelData(true);
        //        imgNext.Enabled = true;
        //        imgPrevious.Enabled = true;

        //        //dgProjects.Visible = True

        //        Label lblCatID = (Label)e.Item.FindControl("lblCatID");
        //        Label lblBrandID = (Label)e.Item.FindControl("lblBrandSegmentID");

        //        hdID.Value = lblCatID.Text + "," + lblBrandID.Text;

        //        //Code added by Vijay 
        //        ViewState["Cat_ID") = lblCatID.Text;
        //        ViewState["Brand_ID") = lblBrandID.Text;

        //        FillProjects(Convert.ToInt32(lblCatID.Text), Convert.ToInt32(lblBrandID.Text));
        //        intGlobalCategoryID = Convert.ToInt32(lblCatID.Text);
        //        intGlobalBrandID = Convert.ToInt32(lblBrandID.Text);

        //        ImageButton imgBrandSegment1 = default(ImageButton);
        //        imgBrandSegment1 = (ImageButton)e.Item.FindControl("imgBrandSegment1");
        //        ImageButton imgBrandSegment2 = default(ImageButton);
        //        imgBrandSegment2 = (ImageButton)e.Item.FindControl("imgBrandSegment2");
        //        imgBrandSegment1.Visible = false;
        //        imgBrandSegment2.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgBrandSegment2.ClientID + "').focus();");

        //        //Dim rowno As Integer = e.Item.ItemIndex

        //        //For rowCount As Integer = rowno + 1 To drgdProjByCategory.Items.Count - 1

        //        //    Dim lblCategoryName As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName"), Label)
        //        //    Dim lblbrandSegmentName As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName"), Label)
        //        //    Dim lnkprojectName As LinkButton = CType(drgdProjByCategory.Items(rowCount).FindControl("lnkprojectName"), LinkButton)
        //        //    Dim lblProjectTypeName As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblProjectTypeName"), Label)
        //        //    Dim lblProjectID As Label = CType(drgdProjByCategory.Items(rowCount).FindControl("lblProjectID"), Label)


        //        //    If lblbrandSegmentName.Text = "" And lblCategoryName.Text = "" Then

        //        //        If Not lblProjectTypeName.Text = "" Then
        //        //            drgdProjByCategory.Items(rowCount).Visible = True
        //        //            lblProjectID.Visible = False


        //        //            If (rowCount Mod 2 = 0) Then
        //        //                drgdProjByCategory.Items(rowCount).Cells(2).Attributes("Class") = "AlterNateRow2"
        //        //                drgdProjByCategory.Items(rowCount).Cells(3).Attributes("Class") = "AlterNateRow2"
        //        //                drgdProjByCategory.Items(rowCount).Cells(4).Attributes("Class") = "AlterNateRow2"
        //        //                drgdProjByCategory.Items(rowCount).Cells(5).Attributes("Class") = "AlterNateRow2"
        //        //                drgdProjByCategory.Items(rowCount).Cells(6).Attributes("Class") = "AlterNateRow2"

        //        //            Else
        //        //                drgdProjByCategory.Items(rowCount).Cells(2).Attributes("Class") = "AlterNateRow1"
        //        //                drgdProjByCategory.Items(rowCount).Cells(3).Attributes("Class") = "AlterNateRow1"
        //        //                drgdProjByCategory.Items(rowCount).Cells(4).Attributes("Class") = "AlterNateRow1"
        //        //                drgdProjByCategory.Items(rowCount).Cells(5).Attributes("Class") = "AlterNateRow1"
        //        //                drgdProjByCategory.Items(rowCount).Cells(6).Attributes("Class") = "AlterNateRow1"
        //        //            End If




        //        //        Else
        //        //            drgdProjByCategory.Items(rowCount).Visible = False
        //        //        End If

        //        //    Else
        //        //        Exit For
        //        //    End If

        //        //Next
        //    }


        //    //when user clicks on Brand Name collapse image button then application will execute below code
        //    // this code will diplay only brand names and hiding all project details
        //    if (e.CommandName == "BrandSegmentCollapse")
        //    {
        //        dgProjects.Visible = false;
        //        PageButtonVisibility(false);
        //        HeaderLabelData(false);

        //        hdID.Value = "";
        //        //                displayHead(False)

        //        ImageButton imgBrandSegment1 = default(ImageButton);
        //        imgBrandSegment1 = (ImageButton)e.Item.FindControl("imgBrandSegment1");
        //        ImageButton imgBrandSegment2 = default(ImageButton);
        //        imgBrandSegment2 = (ImageButton)e.Item.FindControl("imgBrandSegment2");
        //        imgBrandSegment1.Visible = true;
        //        imgBrandSegment2.Visible = false;

        //        //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgBrandSegment1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= drgdProjByCategory.Items.Count - 1; rowCount++)
        //        {


        //            Label lblCategoryName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblCategoryName");
        //            Label lblbrandSegmentName = (Label)drgdProjByCategory.Items(rowCount).FindControl("lblbrandSegmentName");



        //            if (string.IsNullOrEmpty(lblCategoryName.Text) & string.IsNullOrEmpty(lblbrandSegmentName.Text))
        //            {
        //                drgdProjByCategory.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }
        //}

        //protected void dgProjects_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Project_Links")
        //    {
        //        Response.Redirect("..\\Common\\frmViewProject.aspx?ProjectID=" + Convert.ToString(dgProjects.DataKeys(e.Item.ItemIndex)) + "&Mode=Edit");
        //    }
        //}

        //protected void dgProjects_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        //{
        //    dgProjects.CurrentPageIndex = e.NewPageIndex;

        //    string[] IDs = hdID.Value.Split(Convert.ToChar(","));
        //    FillProjects(Convert.ToInt32(IDs[0]), Convert.ToInt32(IDs[1]));
        //}

        //protected void dgProjects_ItemSortCommand(object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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
        //    FillProjects(Convert.ToInt32(ViewState["Cat_ID")), Convert.ToInt32(ViewState["Brand_ID")));
        //}

        #endregion


        #region "Button Events"
        //
        //  ************************************************
        //Name   	    :	imgExpnadAll_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying Events by Project Type in Expand Mode in datagrid
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void lnkProject_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument != null)
                {
                    Response.Redirect("~/Common/frmViewProject.aspx?ProjectID=" + Convert.ToString(e.CommandArgument) + "&Mode=Edit");
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void dgProjects_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillProjects(Convert.ToInt32(ViewState["Cat_ID"]), Convert.ToInt32(ViewState["Brand_ID"]));
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgExpnadAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            ViewState["EOMain"]=null;
            ViewState["Single"] = null;
            ViewState["SingleMain"] = null;
            dgProjects.Visible = false;
            lblBrand.Visible = false;
            lblCategory.Visible = false;
            FillProjectsByCategory();
        }
        //
        //  ************************************************
        //Name   	    :	imgCollapseAll_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying Events by Project Type in Collapse Mode in datagrid
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void imgCollapseAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            ViewState["EOMain"] = null;
            ViewState["Single"] = null;
            ViewState["SingleMain"] = null;
            FillProjectsByCategory();
        }
        //
        //  ************************************************
        //Name   	    :	imgEventsbyCategory_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Navigating to EventsbyCategory Report
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void imgEventsbyCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/EventsbyCategory.aspx");
        }
        //
        //  ************************************************
        //Name   	    :	imgMyEvents_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Navigating to MyEvents Report
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void imgMyEvents_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/MyEvents.aspx");
        }
        #endregion

    }
}