using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class ViewBasicInfo : System.Web.UI.Page
    {
        #region "Declarations"
        #endregion
        DataSet dsBasicInfo = new DataSet();
        clsSecurity cls = new clsSecurity();

        //***************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	Page_Load
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   To Display all basic information.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/24/07                 chary            1.0           created
        //***************************************************
        protected void Page_Load(object sender, EventArgs e)
        {
           // Page.SmartNavigation = true;

            if (!Page.IsPostBack)
            {
                fillBasicInfo();               
            }
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	fillBasicInfo
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   To fill the basic information when page loads
        //Returns        :   To GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 chary              1.0           created
        //***************************************************
        protected void fillBasicInfo()
        {
            dsBasicInfo = new DataSet();
            clsBasicinfoBO objProjectsByCategory = new clsBasicinfoBO();
            if (objProjectsByCategory.FillBasicInfo(ref dsBasicInfo))
            {
                if (dsBasicInfo == null)
                {
                }
                else if (dsBasicInfo.Tables.Count == 0)
                {
                }
                else if (dsBasicInfo.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    DataTable dtBasicCatInfo = new DataTable();
                    DataRow drBasicCatInfo = null;
                    dtBasicCatInfo.Columns.Add("KeyName");
                    dtBasicCatInfo.Columns.Add("Category_ID");
                    dtBasicCatInfo.Columns.Add("Category_Name");
                    int i = 0;
                    for (i = 0; i <= dsBasicInfo.Tables[0].Rows.Count; i++)
                    {
                        drBasicCatInfo = dtBasicCatInfo.NewRow();
                        if (i == 0)
                        {
                            drBasicCatInfo["KeyName"] = "Category";
                            drBasicCatInfo["Category_ID"] = "";
                            drBasicCatInfo["Category_Name"] = "";
                            dtBasicCatInfo.Rows.Add(drBasicCatInfo);
                        }
                        else
                        {
                            drBasicCatInfo["KeyName"] = "";
                            drBasicCatInfo["Category_ID"] = dsBasicInfo.Tables[0].Rows[i - 1][0];
                            drBasicCatInfo["Category_Name"] = dsBasicInfo.Tables[0].Rows[i - 1][1];
                            dtBasicCatInfo.Rows.Add(drBasicCatInfo);
                        }
                    }
                    drgdCatBasicInfo.DataSource = dtBasicCatInfo;
                    drgdCatBasicInfo.DataBind();
                    if (!(dsBasicInfo.Tables[1].Rows.Count == 0))
                    {
                        DataTable dtBasicPlantInfo = new DataTable();
                        DataRow drBasicPlantInfo = null;
                        dtBasicPlantInfo.Columns.Add("KeyName");
                        dtBasicPlantInfo.Columns.Add("Plant_ID");
                        dtBasicPlantInfo.Columns.Add("Plant_Name");
                        int intPlantCount = 0;
                        for (intPlantCount = 0; intPlantCount <= dsBasicInfo.Tables[1].Rows.Count; intPlantCount++)
                        {
                            drBasicPlantInfo = dtBasicPlantInfo.NewRow();
                            if (intPlantCount == 0)
                            {
                                drBasicPlantInfo["KeyName"] = "Plant";
                                drBasicPlantInfo["Plant_ID"] = "";
                                drBasicPlantInfo["Plant_Name"] = "";
                                dtBasicPlantInfo.Rows.Add(drBasicPlantInfo);
                            }
                            else
                            {
                                drBasicPlantInfo["KeyName"] = "";
                                drBasicPlantInfo["Plant_ID"] = dsBasicInfo.Tables[1].Rows[intPlantCount - 1][0];
                                drBasicPlantInfo["Plant_Name"] = dsBasicInfo.Tables[1].Rows[intPlantCount - 1][1];
                                dtBasicPlantInfo.Rows.Add(drBasicPlantInfo);
                            }
                        }
                        drgdPlantBasicInfo.DataSource = dtBasicPlantInfo;
                        drgdPlantBasicInfo.DataBind();
                    }
                    //To fill EOtype data grid
                    if (!(dsBasicInfo.Tables[2].Rows.Count == 0))
                    {
                        DataTable dtBasicEOInfo = new DataTable();
                        DataRow drBasicEOInfo = null;
                        dtBasicEOInfo.Columns.Add("KeyName");
                        dtBasicEOInfo.Columns.Add("EO_Type_ID");
                        dtBasicEOInfo.Columns.Add("EO_Type_Name");
                        int intEOCount = 0;
                        for (intEOCount = 0; intEOCount <= dsBasicInfo.Tables[2].Rows.Count; intEOCount++)
                        {
                            drBasicEOInfo = dtBasicEOInfo.NewRow();
                            if (intEOCount == 0)
                            {
                                drBasicEOInfo["KeyName"] = "EOType";
                                drBasicEOInfo["EO_Type_ID"] = "";
                                drBasicEOInfo["EO_Type_Name"] = "";
                                dtBasicEOInfo.Rows.Add(drBasicEOInfo);
                            }
                            else
                            {
                                drBasicEOInfo["KeyName"] = "";
                                drBasicEOInfo["EO_Type_ID"] = dsBasicInfo.Tables[2].Rows[intEOCount - 1][0];
                                drBasicEOInfo["EO_Type_Name"] = dsBasicInfo.Tables[2].Rows[intEOCount - 1][1];
                                dtBasicEOInfo.Rows.Add(drBasicEOInfo);
                            }
                        }
                        dgrdEOType.DataSource = dtBasicEOInfo;
                        dgrdEOType.DataBind();
                    }
                    //To fill Project type data grid
                    if (!(dsBasicInfo.Tables[3].Rows.Count == 0))
                    {
                        DataTable dtBasicProjectInfo = new DataTable();
                        DataRow drBasicProjectInfo = null;
                        dtBasicProjectInfo.Columns.Add("KeyName");
                        dtBasicProjectInfo.Columns.Add("Project_Type_ID");
                        dtBasicProjectInfo.Columns.Add("Project_Type_Name");
                        int intProjCount = 0;
                        for (intProjCount = 0; intProjCount <= dsBasicInfo.Tables[3].Rows.Count; intProjCount++)
                        {
                            drBasicProjectInfo = dtBasicProjectInfo.NewRow();
                            if (intProjCount == 0)
                            {
                                drBasicProjectInfo["KeyName"] = "Project Type";
                                drBasicProjectInfo["Project_Type_ID"] = "";
                                drBasicProjectInfo["Project_Type_Name"] = "";
                                dtBasicProjectInfo.Rows.Add(drBasicProjectInfo);
                            }
                            else
                            {
                                drBasicProjectInfo["KeyName"] = "";
                                drBasicProjectInfo["Project_Type_ID"] = dsBasicInfo.Tables[3].Rows[intProjCount - 1][0];
                                drBasicProjectInfo["Project_Type_Name"] = dsBasicInfo.Tables[3].Rows[intProjCount - 1][1];
                                dtBasicProjectInfo.Rows.Add(drBasicProjectInfo);
                            }
                        }
                        dgrdProjectType.DataSource = dtBasicProjectInfo;
                        dgrdProjectType.DataBind();
                    }

                    //To fill Function data grid
                    if (!(dsBasicInfo.Tables[4].Rows.Count == 0))
                    {
                        DataTable dtfunctionInfo = new DataTable();
                        DataRow drfunctionInfo = null;
                        dtfunctionInfo.Columns.Add("KeyName");
                        dtfunctionInfo.Columns.Add("function_ID");
                        dtfunctionInfo.Columns.Add("function_Name");
                        int intfunCount = 0;
                        for (intfunCount = 0; intfunCount <= dsBasicInfo.Tables[4].Rows.Count; intfunCount++)
                        {
                            drfunctionInfo = dtfunctionInfo.NewRow();
                            if (intfunCount == 0)
                            {
                                drfunctionInfo["KeyName"] = "Function";
                                drfunctionInfo["function_ID"] = "";
                                drfunctionInfo["function_Name"] = "";
                                dtfunctionInfo.Rows.Add(drfunctionInfo);
                            }
                            else
                            {
                                drfunctionInfo["KeyName"] = "";
                                drfunctionInfo["function_ID"] = dsBasicInfo.Tables[4].Rows[intfunCount - 1][0];
                                drfunctionInfo["function_Name"] = dsBasicInfo.Tables[4].Rows[intfunCount - 1][1];
                                dtfunctionInfo.Rows.Add(drfunctionInfo);
                            }
                        }
                        dgrdFunction.DataSource = dtfunctionInfo;
                        dgrdFunction.DataBind();
                    }

                    //To fill Function data grid
                    if (!(dsBasicInfo.Tables[5].Rows.Count == 0))
                    {
                        DataTable dtMachineInfo = new DataTable();
                        DataRow drMachineInfo = null;
                        dtMachineInfo.Columns.Add("KeyName");
                        dtMachineInfo.Columns.Add("Machine_ID");
                        dtMachineInfo.Columns.Add("Machine_Name");
                        int intMachCount = 0;
                        for (intMachCount = 0; intMachCount <= dsBasicInfo.Tables[5].Rows.Count; intMachCount++)
                        {
                            drMachineInfo = dtMachineInfo.NewRow();
                            if (intMachCount == 0)
                            {
                                drMachineInfo["KeyName"] = "Machine";
                                drMachineInfo["Machine_ID"] = "";
                                drMachineInfo["Machine_Name"] = "";
                                dtMachineInfo.Rows.Add(drMachineInfo);
                            }
                            else
                            {
                                drMachineInfo["KeyName"] = "";
                                drMachineInfo["Machine_ID"] = dsBasicInfo.Tables[5].Rows[intMachCount - 1][0];
                                drMachineInfo["Machine_Name"] = dsBasicInfo.Tables[5].Rows[intMachCount - 1][1];
                                dtMachineInfo.Rows.Add(drMachineInfo);
                            }
                        }
                        dgrdMachine.DataSource = dtMachineInfo;
                        dgrdMachine.DataBind();
                    }
                }
            }
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	drgdCatBasicInfo_ItemDataBound
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   Displaying only Category names in first load of datagrid
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 chary              1.0           created
        //***************************************************
        protected void drgdCatBasicInfo_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {                
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    ImageButton imgCategory1 = (ImageButton)drgdCatBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "imgCategory1");
                    ImageButton imgCategory2 = (ImageButton)drgdCatBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "imgCategory2");
                    Label lblCategory = (Label)drgdCatBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "lblKeyName");
                    LinkButton lnkCategoryName = (LinkButton)drgdCatBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdCatBasicInfo.Columns["Value"], "lnkCategoryName");                    
                    
                    if (string.IsNullOrEmpty(lblCategory.Text))
                    {
                        imgCategory1.Visible = false;
                        imgCategory2.Visible = false;
                        //e.Row.Visible = false;
                        lnkCategoryName.Visible = false;
                        //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategory.Parent.Parent.Parent;
                        //gvdc.Visible = false;
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
                    else
                    {
                        if (ViewState["SingleCat"] != null)
                        {
                            if (!cls.IsExists(Convert.ToString(ViewState["SingleCat"]), Convert.ToString(e.VisibleIndex)))
                            {
                                imgCategory2.Visible = false;
                            }                          
                        }
                        else
                        {
                            imgCategory2.Visible = false;
                        }

                    }
                    if (ViewState["SingleCatt"] != null)
                    {
                        if (cls.IsExists(Convert.ToString(ViewState["SingleCatt"]), Convert.ToString(e.VisibleIndex)))
                        {
                            if (string.IsNullOrEmpty(lblCategory.Text))
                            {                              
                                lnkCategoryName.Visible = true;
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategory.Parent.Parent.Parent;
                                //gvdc.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //} 
                            }
                        }   
                    }
                    if (ViewState["Expand"] != null)
                    {
                        imgCategory2.Visible = true;
                        imgCategory1.Visible = false;
                        lblCategory.Visible = true;
                        if (string.IsNullOrEmpty(lblCategory.Text))
                        {
                            imgCategory1.Visible = false;
                            imgCategory2.Visible = false;
                            lnkCategoryName.Visible = true;
                            lblCategory.Visible = false;
                            //e.Row.Visible = true;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //} 
                        }
                        if (Convert.ToString(ViewState["Expand"]) == "COLLAPSE")
                        {
                            imgCategory1.Visible = true;
                            imgCategory2.Visible = false;
                            lblCategory.Visible = true;
                            if (string.IsNullOrEmpty(lblCategory.Text))
                            {
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                lnkCategoryName.Visible = false;
                                lblCategory.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }

        //protected void drgdCatBasicInfo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton imgCategory1 = default(ImageButton);
        //            ImageButton imgCategory2 = default(ImageButton);
        //            imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //            imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //            Label lblCategory = default(Label);
        //            lblCategory = (Label)e.Item.FindControl("lblKeyName");
        //            if (string.IsNullOrEmpty(lblCategory.Text))
        //            {
        //                imgCategory1.Visible = false;
        //                imgCategory2.Visible = false;
        //                e.Item.Visible = false;
        //            }
        //            else
        //            {
        //                imgCategory2.Visible = false;
        //            }
        //            break;
        //    }
        //}
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	drgdCatBasicInfo_ItemCommand
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   Displaying category names according to expand / collapse
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 chary              1.0           created
        //***************************************************
    
        protected void imgCategory1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton imgCategory1 = (ImageButton)sender;
                ImageButton imgCategory2 = (ImageButton)imgCategory1.Parent.FindControl("imgCategory2");
                imgCategory2.Visible = true;
                string str=string.Empty;
                imgCategory1.Visible = false;
                ViewState["SingleCat"] = "0";
                  for (int intCatCount = 0; intCatCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCatCount++)
                  {                     
                      //Label lblCatName = default(Label);
                      //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                      if (Convert.ToString(ViewState["SingleCat"]) != Convert.ToString(intCatCount))
                      {
                          str = str + Convert.ToString(intCatCount)+",";
                      }
                      Label lblCatName = (Label)drgdCatBasicInfo.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "lblKeyName");
                     
                  }
                  ViewState["SingleCatt"] = str.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {
                                
            }
        }
        protected void imgCategory2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton imgCategory2 = (ImageButton)sender;
                ImageButton imgCategory1 = (ImageButton)imgCategory2.Parent.FindControl("imgCategory1");
                imgCategory2.Visible = false;
                imgCategory1.Visible = true;
                ViewState["SingleCat"] = null;
                ViewState["SingleCatt"] = null;
                for (int intCatCount = 0; intCatCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblCatName = (Label)drgdCatBasicInfo.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "lblKeyName");
                    if (string.IsNullOrEmpty(lblCatName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCatName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void lnkCategoryName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName!=null)
                {                                                                             
                    LinkButton lnkCatName = (LinkButton)sender;                    
                    Response.Redirect("ViewBasicInfoRO.aspx?Key=Cat" + "&Catname=" + lnkCatName.Text + "&KeyValue=" + Convert.ToInt32(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void drgdCatBasicInfo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Category1")
        //    {
        //        ImageButton imgCategory1 = default(ImageButton);
        //        ImageButton imgCategory2 = default(ImageButton);
        //        imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //        imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //        imgCategory2.Visible = true;
        //        imgCategory1.Visible = false;
        //        for (int intCatCount = 0; intCatCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCatCount++)
        //        {
        //            Label lblCatName = default(Label);
        //            lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
        //            if (string.IsNullOrEmpty(lblCatName.Text))
        //            {
        //                drgdCatBasicInfo.Items(intCatCount).Visible = true;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "Category2")
        //    {
        //        ImageButton imgCategory1 = default(ImageButton);
        //        ImageButton imgCategory2 = default(ImageButton);
        //        imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
        //        imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
        //        imgCategory2.Visible = false;
        //        imgCategory1.Visible = true;
        //        for (int intCatCount = 0; intCatCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCatCount++)
        //        {
        //            Label lblCatName = default(Label);
        //            lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
        //            if (string.IsNullOrEmpty(lblCatName.Text))
        //            {
        //                drgdCatBasicInfo.Items(intCatCount).Visible = false;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "CatName")
        //    {
        //        //Dim lblCategoryID As Label = CType(drgdCatBasicInfo.Items(e.Item.ItemIndex).FindControl("lblCategoryID"), Label)
        //        LinkButton lnkCatName = (LinkButton)drgdCatBasicInfo.Items(e.Item.ItemIndex).FindControl("lnkCategoryName");
        //        Label lnkCatNameValue = (Label)drgdCatBasicInfo.Items(e.Item.ItemIndex).FindControl("lblCategoryID");
        //        //Response.Redirect("MaintainBasicinfo.aspx?Key=Cat" & "&Catname=" & lnkCatName.Text)
        //        Response.Redirect("ViewBasicInfoRO.aspx?Key=Cat" + "&Catname=" + lnkCatName.Text + "&KeyValue=" + lnkCatNameValue.Text);
        //    }
        //}
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	drgdPlantBasicInfo_ItemDataBound
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   Displaying only Plant names in first load of datagrid
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 chary            1.0           created
        //***************************************************
        protected void drgdPlantBasicInfo_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {               
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    //ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
                    //LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
                    //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
                    ImageButton imgPlant1 = (ImageButton)drgdPlantBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "imgPlant1");
                    ImageButton imgPlant2 = (ImageButton)drgdPlantBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "imgPlant2");
                    Label lblplantName = (Label)drgdPlantBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "lblplantName");
                    //Label lblFunctionName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["FunctionName"], "lblFunctionName");
                    LinkButton lnkPlantName = (LinkButton)drgdPlantBasicInfo.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant Name"], "lnkPlantName");                    
                    if (string.IsNullOrEmpty(lblplantName.Text))
                    {
                        imgPlant1.Visible = false;
                        imgPlant2.Visible = false;
                        lnkPlantName.Visible = false;
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
                    else
                    {
                        if (ViewState["SinglePL"] != null)
                        {
                            if (!cls.IsExists(Convert.ToString(ViewState["SinglePL"]), Convert.ToString(e.VisibleIndex)))
                            {
                                imgPlant2.Visible = false;
                            }
                        }
                        else
                        {
                            imgPlant2.Visible = false;
                        }

                    }
                    if (ViewState["SinglePLL"] != null)
                    {
                        if (cls.IsExists(Convert.ToString(ViewState["SinglePLL"]), Convert.ToString(e.VisibleIndex)))
                        {
                            if (string.IsNullOrEmpty(lblplantName.Text))
                            {
                                lnkPlantName.Visible = true;                              
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //}   
                            }
                        }
                    }
                    if (ViewState["Expand"] != null)
                    {
                        imgPlant2.Visible = true;
                        imgPlant1.Visible = false;
                        lblplantName.Visible = true;
                        if (string.IsNullOrEmpty(lblplantName.Text))
                        {
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;
                            lnkPlantName.Visible = true;
                            lblplantName.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //} 
                        }
                        if (Convert.ToString(ViewState["Expand"]) == "COLLAPSE")
                        {
                            imgPlant1.Visible = true;
                            imgPlant2.Visible = false;
                            lblplantName.Visible = true;
                            if (string.IsNullOrEmpty(lblplantName.Text))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lnkPlantName.Visible = false;
                                lblplantName.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void drgdPlantBasicInfo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton imgPlant1 = default(ImageButton);
        //            ImageButton imgPlant2 = default(ImageButton);
        //            imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //            imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //            Label l = default(Label);
        //            l = (Label)e.Item.FindControl("lblplantName");
        //            if (string.IsNullOrEmpty(l.Text))
        //            {
        //                imgPlant1.Visible = false;
        //                imgPlant2.Visible = false;
        //                e.Item.Visible = false;
        //            }
        //            else
        //            {
        //                imgPlant2.Visible = false;
        //            }
        //            break;
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	drgdPlantBasicInfo_ItemCommand
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying Plant names according to expand / collapse
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 chary              1.0           created
        ////***************************************************
        protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ViewState["SinglePL"] = "0";
                string str = string.Empty;
                
                
                ImageButton imgPlant1 = (ImageButton)sender;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");
                imgPlant2.Visible = true;
                imgPlant1.Visible = false;
                for (int intCatCount = 0; intCatCount <= drgdPlantBasicInfo.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblplantName = (Label)drgdPlantBasicInfo.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "lblplantName");
                    if (Convert.ToString(ViewState["SinglePL"]) != Convert.ToString(intCatCount))
                    {
                        str = str + Convert.ToString(intCatCount) + ",";
                    }
                    if (string.IsNullOrEmpty(lblplantName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblplantName.Parent.Parent.Parent;
                        gvdc.Visible = true;
                    }
                }
                ViewState["SinglePLL"] = str.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgPlant2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ViewState["SinglePL"] = null;
                ViewState["SinglePLL"] = null;
                ImageButton imgPlant2 = (ImageButton)sender;
                ImageButton imgPlant1 = (ImageButton)imgPlant2.Parent.FindControl("imgPlant1");
                imgPlant1.Visible = true;
                imgPlant2.Visible = false;
                for (int intCatCount = 0; intCatCount <= drgdPlantBasicInfo.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblplantName = (Label)drgdPlantBasicInfo.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "lblplantName");
                    if (string.IsNullOrEmpty(lblplantName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblplantName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void lnkPlantName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    LinkButton lnkPlantName = (LinkButton)sender;
                    Response.Redirect("ViewBasicInfoRO.aspx?Key=Plant" + "&Catname=" + lnkPlantName.Text + "&KeyValue=" + Convert.ToInt32(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void drgdPlantBasicInfo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //called when user clicks expand icon
        //    if (e.CommandName == "Plant1")
        //    {
        //        ImageButton imgPlant1 = default(ImageButton);
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant2.Visible = true;
        //        imgPlant1.Visible = false;
        //        for (int intPlantCount = 0; intPlantCount <= drgdPlantBasicInfo.VisibleRowCount - 1; intPlantCount++)
        //        {
        //            Label lblPlantName = default(Label);
        //            lblPlantName = (Label)drgdPlantBasicInfo.Items(intPlantCount).FindControl("lblplantName");
        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                drgdPlantBasicInfo.Items(intPlantCount).Visible = true;
        //            }
        //        }

        //        //called when user clicks collapse icon
        //    }
        //    else if (e.CommandName == "Plant2")
        //    {
        //        ImageButton imgPlant1 = default(ImageButton);
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant1.Visible = true;
        //        imgPlant2.Visible = false;
        //        for (int intPlantCount = 0; intPlantCount <= drgdPlantBasicInfo.VisibleRowCount - 1; intPlantCount++)
        //        {
        //            Label lblPlantName = default(Label);
        //            lblPlantName = (Label)drgdPlantBasicInfo.Items(intPlantCount).FindControl("lblplantName");
        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                drgdPlantBasicInfo.Items(intPlantCount).Visible = false;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "PlantName")
        //    {
        //        Label lblCategoryID = (Label)drgdPlantBasicInfo.Items(e.Item.ItemIndex).FindControl("lblPlantID");
        //        LinkButton lnkPlantName = (LinkButton)drgdPlantBasicInfo.Items(e.Item.ItemIndex).FindControl("lnkPlantName");
        //        Response.Redirect("ViewBasicInfoRO.aspx?Key=Plant" + "&Catname=" + lnkPlantName.Text + "&KeyValue=" + lblCategoryID.Text);

        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdEOType_ItemDataBound
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying only EO Types names in first load of datagrid
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 chary              1.0           created
        ////***************************************************
        protected void dgrdEOType_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;                                
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    //ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
                    //LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
                    //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
                    ImageButton imgEOType1 = (ImageButton)dgrdEOType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "imgEOType1");
                    ImageButton imgEOType2 = (ImageButton)dgrdEOType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "imgEOType2");
                    Label lblEO = (Label)dgrdEOType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "lblEO");
                    LinkButton lnkEOTypeName = (LinkButton)dgrdEOType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdEOType.Columns["EOTypeName"], "lnkEOTypeName");                    
                    //Label lblFunctionName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["FunctionName"], "lblFunctionName");
                    if (string.IsNullOrEmpty(lblEO.Text))
                    {
                        imgEOType1.Visible = false;
                        imgEOType2.Visible = false;
                        lnkEOTypeName.Visible = false;
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
                    else
                    {
                        if (ViewState["SingleEO"] != null)
                        {
                            if (!cls.IsExists(Convert.ToString(ViewState["SingleEO"]), Convert.ToString(e.VisibleIndex)))
                            {
                                imgEOType2.Visible = false;
                            }
                        }
                        else
                        {
                            imgEOType2.Visible = false;
                        }

                    }
                    if (ViewState["SingleEOO"] != null)
                    {
                        if (cls.IsExists(Convert.ToString(ViewState["SingleEOO"]), Convert.ToString(e.VisibleIndex)))
                        {
                            if (string.IsNullOrEmpty(lblEO.Text))
                            {
                                lnkEOTypeName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //} 
                            }
                        }
                    }
                    if (ViewState["Expand"] != null)
                    {                        
                        imgEOType2.Visible = true;
                        imgEOType1.Visible = false;
                        lblEO.Visible = true;
                        if (string.IsNullOrEmpty(lblEO.Text))
                        {
                            imgEOType1.Visible = false;
                            imgEOType2.Visible = false;
                            lnkEOTypeName.Visible = true;
                            lblEO.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //} 
                        }
                        if (Convert.ToString(ViewState["Expand"]) == "COLLAPSE")
                        {
                            imgEOType1.Visible = true;
                            imgEOType2.Visible = false;
                            lblEO.Visible = true;
                            if (string.IsNullOrEmpty(lblEO.Text))
                            {
                                imgEOType1.Visible = false;
                                imgEOType2.Visible = false;
                                lnkEOTypeName.Visible = false;
                                lblEO.Visible = false;                                                                
                            }
                        }
                    }
                    
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void dgrdEOType_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton imgEO1 = default(ImageButton);
        //            ImageButton imgEO2 = default(ImageButton);
        //            imgEO1 = (ImageButton)e.Item.FindControl("imgEOType1");
        //            imgEO2 = (ImageButton)e.Item.FindControl("imgEOType2");
        //            Label lblEO = default(Label);
        //            lblEO = (Label)e.Item.FindControl("lblEO");
        //            if (string.IsNullOrEmpty(lblEO.Text))
        //            {
        //                imgEO1.Visible = false;
        //                imgEO2.Visible = false;
        //                e.Item.Visible = false;
        //            }
        //            else
        //            {
        //                imgEO2.Visible = false;
        //            }
        //            break;
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdEOType_ItemCommand
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying EO Types according to expand / collapse
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 chary              1.0           created
        ////***************************************************
        protected void imgEOType1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton imgEOType1 = (ImageButton)sender;
                ImageButton imgEOType2 = (ImageButton)imgEOType1.Parent.FindControl("imgEOType2");
                imgEOType2.Visible = true;
                string str = string.Empty;
                imgEOType1.Visible = false;
                ViewState["SingleEO"] = "0";
                
                for (int intCatCount = 0; intCatCount <= dgrdEOType.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    if (Convert.ToString(ViewState["SingleEO"]) != Convert.ToString(intCatCount))
                    {
                        str = str + Convert.ToString(intCatCount) + ",";
                    }
                    Label lblEO = (Label)dgrdEOType.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "lblEO");
                    if (string.IsNullOrEmpty(lblEO.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEO.Parent.Parent.Parent;
                        gvdc.Visible = true;
                    }
                }
                ViewState["SingleEOO"] = str.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgEOType2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ViewState["SingleEO"] = null;
                ViewState["SingleEOO"] = null;
                ImageButton imgEOType2 = (ImageButton)sender;
                ImageButton imgEOType1 = (ImageButton)imgEOType2.Parent.FindControl("imgEOType1");
                imgEOType2.Visible = false;
                imgEOType1.Visible = true;
                for (int intCatCount = 0; intCatCount <= dgrdEOType.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblEO = (Label)dgrdEOType.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "lblEO");
                    if (string.IsNullOrEmpty(lblEO.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEO.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void lnkEOTypeName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    LinkButton lnkEOTypeName = (LinkButton)sender;                    
                    Response.Redirect("ViewBasicInfoRO.aspx?Key=EO" + "&Catname=" + lnkEOTypeName.Text + "&KeyValue=" + Convert.ToInt32(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void dgrdEOType_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "EO1")
        //    {
        //        ImageButton imgEO1 = default(ImageButton);
        //        ImageButton imgEO2 = default(ImageButton);
        //        imgEO1 = (ImageButton)e.Item.FindControl("imgEOType1");
        //        imgEO2 = (ImageButton)e.Item.FindControl("imgEOType2");
        //        imgEO2.Visible = true;
        //        imgEO1.Visible = false;
        //        for (int intEOCount = 0; intEOCount <= dgrdEOType.VisibleRowCount - 1; intEOCount++)
        //        {
        //            Label lblEOType = default(Label);
        //            lblEOType = (Label)dgrdEOType.Items(intEOCount).FindControl("lblEO");
        //            if (string.IsNullOrEmpty(lblEOType.Text))
        //            {
        //                dgrdEOType.Items(intEOCount).Visible = true;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "EO2")
        //    {
        //        ImageButton imgEO1 = default(ImageButton);
        //        ImageButton imgEO2 = default(ImageButton);
        //        imgEO1 = (ImageButton)e.Item.FindControl("imgEOType1");
        //        imgEO2 = (ImageButton)e.Item.FindControl("imgEOType2");
        //        imgEO2.Visible = false;
        //        imgEO1.Visible = true;
        //        for (int intEOCount = 0; intEOCount <= dgrdEOType.VisibleRowCount - 1; intEOCount++)
        //        {
        //            Label lblEOType = default(Label);
        //            lblEOType = (Label)dgrdEOType.Items(intEOCount).FindControl("lblEO");
        //            if (string.IsNullOrEmpty(lblEOType.Text))
        //            {
        //                dgrdEOType.Items(intEOCount).Visible = false;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "EOType")
        //    {
        //        Label lblEOTypeID = (Label)dgrdEOType.Items(e.Item.ItemIndex).FindControl("lblEOTypeID");
        //        LinkButton lnkEOTypeName = (LinkButton)dgrdEOType.Items(e.Item.ItemIndex).FindControl("lnkEOTypeName");
        //        Response.Redirect("ViewBasicInfoRO.aspx?Key=EO" + "&Catname=" + lnkEOTypeName.Text + "&KeyValue=" + lblEOTypeID.Text);
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdProjectType_ItemDataBound
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying only Project Type in first load of datagrid
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 chary              1.0           created
        ////***************************************************
        protected void dgrdProjectType_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    //ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
                    //LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
                    //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
                    ImageButton ImgProjType1 = (ImageButton)dgrdProjectType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "ImgProjType1");
                    ImageButton ImgProjType2 = (ImageButton)dgrdProjectType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "ImgProjType2");
                    Label lblProjType = (Label)dgrdProjectType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "lblProjType");
                    LinkButton lnkProjTypeName = (LinkButton)dgrdProjectType.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdProjectType.Columns["Project TypeName"], "lnkProjTypeName");                    
                    if (string.IsNullOrEmpty(lblProjType.Text))
                    {
                        ImgProjType1.Visible = false;
                        ImgProjType2.Visible = false;
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
                        lnkProjTypeName.Visible = false;
                    }
                    else
                    {
                        if (ViewState["SinglePR"] != null)
                        {
                            if (!cls.IsExists(Convert.ToString(ViewState["SinglePR"]), Convert.ToString(e.VisibleIndex)))
                            {
                                ImgProjType2.Visible = false;
                            }
                        }
                        else
                        {
                            ImgProjType2.Visible = false;
                        }

                    }
                    if (ViewState["SinglePRR"] != null)
                    {
                        if (cls.IsExists(Convert.ToString(ViewState["SinglePRR"]), Convert.ToString(e.VisibleIndex)))
                        {
                            if (string.IsNullOrEmpty(lblProjType.Text))
                            {
                                lnkProjTypeName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //} 
                            }
                        }
                    }
                    if (ViewState["Expand"] != null)
                    {
                        ImgProjType2.Visible = true;
                        ImgProjType1.Visible = false;
                        lblProjType.Visible = true;
                        if (string.IsNullOrEmpty(lblProjType.Text))
                        {
                            ImgProjType1.Visible = false;
                            ImgProjType2.Visible = false;
                            lnkProjTypeName.Visible = true;
                            lblProjType.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //} 
                        }
                        if (Convert.ToString(ViewState["Expand"]) == "COLLAPSE")
                        {
                            ImgProjType1.Visible = true;
                            ImgProjType2.Visible = false;
                            lblProjType.Visible = true;
                            if (string.IsNullOrEmpty(lblProjType.Text))
                            {
                                ImgProjType1.Visible = false;
                                ImgProjType2.Visible = false;
                                lnkProjTypeName.Visible = false;
                                lblProjType.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void dgrdProjectType_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton imgProj1 = default(ImageButton);
        //            ImageButton imgProj2 = default(ImageButton);
        //            imgProj1 = (ImageButton)e.Item.FindControl("ImgProjType1");
        //            imgProj2 = (ImageButton)e.Item.FindControl("ImgProjType2");
        //            Label lblProj = default(Label);
        //            lblProj = (Label)e.Item.FindControl("lblProjType");
        //            if (string.IsNullOrEmpty(lblProj.Text))
        //            {
        //                imgProj1.Visible = false;
        //                imgProj1.Visible = false;
        //                e.Item.Visible = false;
        //            }
        //            else
        //            {
        //                imgProj2.Visible = false;
        //            }
        //            break;
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdProjectType_ItemCommand
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying Project Types according to expand / collapse
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 chary              1.0           created
        ////***************************************************
        protected void ImgProjType1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton ImgProjType1 = (ImageButton)sender;
                ImageButton ImgProjType2 = (ImageButton)ImgProjType1.Parent.FindControl("ImgProjType2");
                ImgProjType2.Visible = true;
                ImgProjType1.Visible = false;
                ViewState["SinglePR"] = "0";
                string str = string.Empty;
                for (int intCatCount = 0; intCatCount <= dgrdProjectType.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblProjType = (Label)dgrdProjectType.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "lblProjType");
                    if (Convert.ToString(ViewState["SinglePR"]) != Convert.ToString(intCatCount))
                    {
                        str = str + Convert.ToString(intCatCount) + ",";
                    }
                    if (string.IsNullOrEmpty(lblProjType.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblProjType.Parent.Parent.Parent;
                        gvdc.Visible = true;
                    }
                }
                ViewState["SinglePRR"] = str.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void ImgProjType2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton ImgProjType2 = (ImageButton)sender;
                ImageButton ImgProjType1 = (ImageButton)ImgProjType2.Parent.FindControl("ImgProjType1");
                ImgProjType2.Visible = false;
                ImgProjType1.Visible = true;
                ViewState["SinglePR"] = null;
                ViewState["SinglePRR"] = null;
                for (int intCatCount = 0; intCatCount <= dgrdProjectType.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblProjType = (Label)dgrdProjectType.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "lblProjType");
                    if (string.IsNullOrEmpty(lblProjType.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblProjType.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void lnkProjTypeName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    LinkButton lnkProjTypeName = (LinkButton)sender;
                    Response.Redirect("ViewBasicInfoRO.aspx?Key=Project" + "&Catname=" + lnkProjTypeName.Text + "&KeyValue=" + Convert.ToInt32(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }

        //protected void dgrdProjectType_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "ProjType1")
        //    {
        //        ImageButton imgproj1 = default(ImageButton);
        //        ImageButton imgproj2 = default(ImageButton);
        //        imgproj1 = (ImageButton)e.Item.FindControl("ImgProjType1");
        //        imgproj2 = (ImageButton)e.Item.FindControl("ImgProjType2");
        //        imgproj2.Visible = true;
        //        imgproj1.Visible = false;
        //        for (int intProjCount = 0; intProjCount <= dgrdProjectType.VisibleRowCount - 1; intProjCount++)
        //        {
        //            Label lblProjType = default(Label);
        //            lblProjType = (Label)dgrdProjectType.Items(intProjCount).FindControl("lblProjType");
        //            if (string.IsNullOrEmpty(lblProjType.Text))
        //            {
        //                ImageButton imgPro = (ImageButton)dgrdProjectType.Items(intProjCount).FindControl("ImgProjType2");
        //                imgPro.Visible = false;
        //                dgrdProjectType.Items(intProjCount).Visible = true;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "ProjType2")
        //    {
        //        ImageButton imgproj1 = default(ImageButton);
        //        ImageButton imgproj2 = default(ImageButton);
        //        imgproj1 = (ImageButton)e.Item.FindControl("ImgProjType1");
        //        imgproj2 = (ImageButton)e.Item.FindControl("ImgProjType2");
        //        imgproj2.Visible = false;
        //        imgproj1.Visible = true;
        //        for (int intProjCount = 0; intProjCount <= dgrdProjectType.VisibleRowCount - 1; intProjCount++)
        //        {
        //            Label lblProjType = default(Label);
        //            lblProjType = (Label)dgrdProjectType.Items(intProjCount).FindControl("lblProjType");
        //            if (string.IsNullOrEmpty(lblProjType.Text))
        //            {
        //                dgrdProjectType.Items(intProjCount).Visible = false;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "ProjType")
        //    {
        //        Label lblProjTypeID = (Label)dgrdProjectType.Items(e.Item.ItemIndex).FindControl("lblProjTypeID");
        //        LinkButton lnkProjTypeName = (LinkButton)dgrdProjectType.Items(e.Item.ItemIndex).FindControl("lnkProjTypeName");
        //        Response.Redirect("ViewBasicInfoRO.aspx?Key=Project" + "&Catname=" + lnkProjTypeName.Text + "&KeyValue=" + lblProjTypeID.Text);
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdFunction_ItemDataBound
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying only Function in first load of datagrid
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/26/07                 chary              1.0           created
        ////***************************************************
        protected void dgrdFunction_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    //ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
                    //LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
                    //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
                    ImageButton Imagefun1 = (ImageButton)dgrdFunction.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "Imagefun1");
                    ImageButton Imagefun2 = (ImageButton)dgrdFunction.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "Imagefun2");
                    Label lblfunc = (Label)dgrdFunction.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "lblfunc");
                    LinkButton lnkfunction = (LinkButton)dgrdFunction.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdFunction.Columns["Function Name"], "lnkfunction");                    
                    //Label lblFunctionName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["FunctionName"], "lblFunctionName");
                    if (string.IsNullOrEmpty(lblfunc.Text))
                    {
                        Imagefun1.Visible = false;
                        Imagefun2.Visible = false;
                        lnkfunction.Visible = false;
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
                    else
                    {
                        if (ViewState["SingleFU"] != null)
                        {
                            if (!cls.IsExists(Convert.ToString(ViewState["SingleFU"]), Convert.ToString(e.VisibleIndex)))
                            {
                                Imagefun2.Visible = false;
                            }
                        }
                        else
                        {
                            Imagefun2.Visible = false;
                        }

                    }
                    if (ViewState["SingleFUU"] != null)
                    {
                        if (cls.IsExists(Convert.ToString(ViewState["SingleFUU"]), Convert.ToString(e.VisibleIndex)))
                        {
                            if (string.IsNullOrEmpty(lblfunc.Text))
                            {
                                lnkfunction.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //} 
                            }
                        }
                    }
                    if (ViewState["Expand"] != null)
                    {
                        Imagefun2.Visible = true;
                        Imagefun1.Visible = false;
                        lblfunc.Visible = true;
                        if (string.IsNullOrEmpty(lblfunc.Text))
                        {
                            Imagefun1.Visible = false;
                            Imagefun2.Visible = false;
                            lnkfunction.Visible = true;
                            lblfunc.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //} 
                        }
                        if (Convert.ToString(ViewState["Expand"]) == "COLLAPSE")
                        {
                            Imagefun1.Visible = true;
                            Imagefun2.Visible = false;
                            lblfunc.Visible = true;
                            if (string.IsNullOrEmpty(lblfunc.Text))
                            {
                                Imagefun1.Visible = false;
                                Imagefun2.Visible = false;
                                lnkfunction.Visible = false;
                                lblfunc.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void dgrdFunction_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton imgfun1 = default(ImageButton);
        //            ImageButton imgfun2 = default(ImageButton);
        //            imgfun1 = (ImageButton)e.Item.FindControl("Imagefun1");
        //            imgfun2 = (ImageButton)e.Item.FindControl("Imagefun2");
        //            Label lblfun = default(Label);
        //            lblfun = (Label)e.Item.FindControl("lblfunc");
        //            if (string.IsNullOrEmpty(lblfun.Text))
        //            {
        //                imgfun1.Visible = false;
        //                imgfun2.Visible = false;
        //                e.Item.Visible = false;
        //            }
        //            else
        //            {
        //                imgfun2.Visible = false;
        //            }
        //            break;
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdFunction_ItemCommand
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying Functions according to expand / collapse
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/26/07                 chary              1.0           created
        ////***************************************************
        protected void Imagefun1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["SingleFU"] = "0";
                string str = string.Empty;
                ViewState["Expand"] = null;
                
                ImageButton Imagefun1 = (ImageButton)sender;
                ImageButton Imagefun2 = (ImageButton)Imagefun1.Parent.FindControl("Imagefun2");
                Imagefun2.Visible = true;
                Imagefun1.Visible = false;                
                for (int intCatCount = 0; intCatCount <= dgrdFunction.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblfunc = (Label)dgrdFunction.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "lblfunc");
                    if (Convert.ToString(ViewState["SingleFU"]) != Convert.ToString(intCatCount))
                    {
                        str = str + Convert.ToString(intCatCount) + ",";
                    }
                    if (string.IsNullOrEmpty(lblfunc.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblfunc.Parent.Parent.Parent;
                        gvdc.Visible = true;
                    }
                }
                ViewState["SingleFUU"] = str.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void Imagefun2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ViewState["SingleFU"] = null;
                ViewState["SingleFUU"] = null;
                ImageButton Imagefun2 = (ImageButton)sender;
                ImageButton Imagefun1 = (ImageButton)Imagefun2.Parent.FindControl("Imagefun1");
                Imagefun1.Visible = true;
                Imagefun2.Visible = false;
                for (int intCatCount = 0; intCatCount <= dgrdFunction.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblfunc = (Label)dgrdFunction.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "lblfunc");
                    if (string.IsNullOrEmpty(lblfunc.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblfunc.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void lnkfunction_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    LinkButton lnkfunction = (LinkButton)sender;
                    Response.Redirect("ViewBasicInfoRO.aspx?Key=Function" + "&Catname=" + lnkfunction.Text + "&KeyValue=" + Convert.ToInt32(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }

        //protected void dgrdFunction_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Fun1")
        //    {
        //        ImageButton imgfun1 = default(ImageButton);
        //        ImageButton imgfun2 = default(ImageButton);
        //        imgfun1 = (ImageButton)e.Item.FindControl("Imagefun1");
        //        imgfun2 = (ImageButton)e.Item.FindControl("Imagefun2");
        //        imgfun2.Visible = true;
        //        imgfun1.Visible = false;
        //        for (int intfunCount = 0; intfunCount <= dgrdFunction.VisibleRowCount - 1; intfunCount++)
        //        {
        //            Label lblfun = default(Label);
        //            lblfun = (Label)dgrdFunction.Items(intfunCount).FindControl("lblfunc");
        //            if (string.IsNullOrEmpty(lblfun.Text))
        //            {
        //                dgrdFunction.Items(intfunCount).Visible = true;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "Fun2")
        //    {
        //        ImageButton imgfun1 = default(ImageButton);
        //        ImageButton imgfun2 = default(ImageButton);
        //        imgfun1 = (ImageButton)e.Item.FindControl("Imagefun1");
        //        imgfun2 = (ImageButton)e.Item.FindControl("Imagefun2");
        //        imgfun2.Visible = false;
        //        imgfun1.Visible = true;
        //        for (int intfunCount = 0; intfunCount <= dgrdFunction.VisibleRowCount - 1; intfunCount++)
        //        {
        //            Label lblfun = default(Label);
        //            lblfun = (Label)dgrdFunction.Items(intfunCount).FindControl("lblfunc");
        //            if (string.IsNullOrEmpty(lblfun.Text))
        //            {
        //                dgrdFunction.Items(intfunCount).Visible = false;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "Function")
        //    {
        //        Label lblfunId = (Label)dgrdFunction.Items(e.Item.ItemIndex).FindControl("lblfunId");
        //        LinkButton lnkfunction = (LinkButton)dgrdFunction.Items(e.Item.ItemIndex).FindControl("lnkfunction");
        //        Response.Redirect("ViewBasicInfoRO.aspx?Key=Function" + "&Catname=" + lnkfunction.Text + "&KeyValue=" + lblfunId.Text);
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdMachine_ItemDataBound
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying only Machine names in first load of datagrid
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/26/07                 chary              1.0           created
        ////***************************************************
        protected void dgrdMachine_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    //ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
                    //LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
                    //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
                    ImageButton ImageMachine1 = (ImageButton)dgrdMachine.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "ImageMachine1");
                    ImageButton ImageMachine2 = (ImageButton)dgrdMachine.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "ImageMachine2");
                    Label lblMachine = (Label)dgrdMachine.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "lblMachine");
                    LinkButton lnkMachine = (LinkButton)dgrdMachine.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgrdMachine.Columns["Machine Name"], "lnkMachine");                    
                    if (string.IsNullOrEmpty(lblMachine.Text))
                    {
                        ImageMachine1.Visible = false;
                        ImageMachine2.Visible = false;
                        lnkMachine.Visible = false;
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
                    else
                    {
                        if (ViewState["SingleMA"] != null)
                        {
                            if (!cls.IsExists(Convert.ToString(ViewState["SingleMA"]), Convert.ToString(e.VisibleIndex)))
                            {
                                ImageMachine2.Visible = false;
                            }
                        }
                        else
                        {
                            ImageMachine2.Visible = false;
                        }

                    }
                    if (ViewState["SingleMAA"] != null)
                    {
                        if (cls.IsExists(Convert.ToString(ViewState["SingleMAA"]), Convert.ToString(e.VisibleIndex)))
                        {
                            if (string.IsNullOrEmpty(lblMachine.Text))
                            {
                                lnkMachine.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //} 
                            }
                        }
                    }
                    if (ViewState["Expand"] != null)
                    {
                        ImageMachine2.Visible = true;
                        ImageMachine1.Visible = false;
                        lblMachine.Visible = true;
                        if (string.IsNullOrEmpty(lblMachine.Text))
                        {
                            ImageMachine1.Visible = false;
                            ImageMachine2.Visible = false;
                            lnkMachine.Visible = true;
                            lblMachine.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            //else
                            //{
                            //    if (e.Row.Cells[0] != null)
                            //        e.Row.Cells[0].CssClass = "viscol";
                            //} 
                        }
                        if (Convert.ToString(ViewState["Expand"]) == "COLLAPSE")
                        {
                            ImageMachine1.Visible = true;
                            ImageMachine2.Visible = false;
                            lblMachine.Visible = true;
                            if (string.IsNullOrEmpty(lblMachine.Text))
                            {
                                ImageMachine1.Visible = false;
                                ImageMachine2.Visible = false;
                                lnkMachine.Visible = false;
                                lblMachine.Visible = false;
                            }
                        }
                    }

                }

            }
            catch (Exception exc)
            {

            }
        }
        //protected void dgrdMachine_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton ImageMachine1 = default(ImageButton);
        //            ImageButton ImageMachine2 = default(ImageButton);
        //            ImageMachine1 = (ImageButton)e.Item.FindControl("ImageMachine1");
        //            ImageMachine2 = (ImageButton)e.Item.FindControl("ImageMachine2");
        //            Label lblMachine = default(Label);
        //            lblMachine = (Label)e.Item.FindControl("lblMachine");
        //            if (string.IsNullOrEmpty(lblMachine.Text))
        //            {
        //                ImageMachine1.Visible = false;
        //                ImageMachine2.Visible = false;
        //                e.Item.Visible = false;
        //            }
        //            else
        //            {
        //                ImageMachine2.Visible = false;
        //            }
        //            break;
        //    }
        //}
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	dgrdMachine_ItemCommand
        ////Written BY	    :	chary
        ////parameters     :	None
        ////Purpose	    :   Displaying Machine names according to expand / collapse
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 chary              1.0           created
        ////***************************************************

        protected void ImageMachine1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["SingleMA"] = "0";
                string str = string.Empty;
                ViewState["Expand"] = null;
              
                ImageButton ImageMachine1 = (ImageButton)sender;
                ImageButton ImageMachine2 = (ImageButton)ImageMachine1.Parent.FindControl("ImageMachine2");
                ImageMachine2.Visible = true;
                ImageMachine1.Visible = false;
                for (int intCatCount = 0; intCatCount <= dgrdMachine.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblMachine = (Label)dgrdMachine.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "lblMachine");
                    if (Convert.ToString(ViewState["SingleMA"]) != Convert.ToString(intCatCount))
                    {
                        str = str + Convert.ToString(intCatCount) + ",";
                    }
                    if (string.IsNullOrEmpty(lblMachine.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblMachine.Parent.Parent.Parent;
                        gvdc.Visible = true;
                    }
                }
                ViewState["SingleMAA"] = str.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void ImageMachine2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ViewState["SingleMA"] = null;
                ViewState["SingleMAA"] = null;
                ImageButton ImageMachine2 = (ImageButton)sender;
                ImageButton ImageMachine1 = (ImageButton)ImageMachine2.Parent.FindControl("ImageMachine1");
                ImageMachine1.Visible = true;
                ImageMachine2.Visible = false;
                for (int intCatCount = 0; intCatCount <= dgrdMachine.VisibleRowCount - 1; intCatCount++)
                {
                    //Label lblCatName = default(Label);
                    //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
                    Label lblMachine = (Label)dgrdMachine.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "lblMachine");
                    if (string.IsNullOrEmpty(lblMachine.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblMachine.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void lnkMachine_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    LinkButton lnkMachine = (LinkButton)sender;
                    Response.Redirect("ViewBasicInfoRO.aspx?Key=Machine" + "&Catname=" + lnkMachine.Text + "&KeyValue=" + Convert.ToInt32(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }
        //protected void dgrdMachine_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Machine1")
        //    {
        //        ImageButton ImageMachine1 = default(ImageButton);
        //        ImageButton ImageMachine2 = default(ImageButton);
        //        ImageMachine1 = (ImageButton)e.Item.FindControl("ImageMachine1");
        //        ImageMachine2 = (ImageButton)e.Item.FindControl("ImageMachine2");
        //        ImageMachine2.Visible = true;
        //        ImageMachine1.Visible = false;
        //        for (int intCatCount = 0; intCatCount <= dgrdMachine.VisibleRowCount - 1; intCatCount++)
        //        {
        //            Label lblMachine = default(Label);
        //            lblMachine = (Label)dgrdMachine.Items(intCatCount).FindControl("lblMachine");
        //            if (string.IsNullOrEmpty(lblMachine.Text))
        //            {
        //                dgrdMachine.Items(intCatCount).Visible = true;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "Machine2")
        //    {
        //        ImageButton ImageMachine1 = default(ImageButton);
        //        ImageButton ImageMachine2 = default(ImageButton);
        //        ImageMachine1 = (ImageButton)e.Item.FindControl("ImageMachine1");
        //        ImageMachine2 = (ImageButton)e.Item.FindControl("ImageMachine2");
        //        ImageMachine2.Visible = false;
        //        ImageMachine1.Visible = true;
        //        for (int intCatCount = 0; intCatCount <= dgrdMachine.VisibleRowCount - 1; intCatCount++)
        //        {
        //            Label lblMachine = default(Label);
        //            lblMachine = (Label)dgrdMachine.Items(intCatCount).FindControl("lblMachine");
        //            if (string.IsNullOrEmpty(lblMachine.Text))
        //            {
        //                dgrdMachine.Items(intCatCount).Visible = false;
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "Machine")
        //    {
        //        Label lblMachineID = (Label)dgrdMachine.Items(e.Item.ItemIndex).FindControl("lblMachineID");
        //        LinkButton lnkMachine = (LinkButton)dgrdMachine.Items(e.Item.ItemIndex).FindControl("lnkMachine");
        //        Response.Redirect("ViewBasicInfoRO.aspx?Key=Machine" + "&Catname=" + lnkMachine.Text + "&KeyValue=" + lblMachineID.Text);
        //    }
        //}

        protected void imgAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaintainBasicinfo.aspx?Key=AddNew");
        }


        protected void imgExpnadAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "EXPAND";
            //ImageButton imgCategory1 = null;
            //ImageButton imgCategory2 = null;
            //int intCateCount = 0;
            //for (intCateCount = 0; intCateCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCateCount++)
            //{
            //    //imgCategory1 = (ImageButton)drgdCatBasicInfo.Items(intCateCount).FindControl("imgCategory1");
            //    imgCategory1 = (ImageButton)drgdCatBasicInfo.FindRowCellTemplateControl(intCateCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["CategoryName"], "imgCategory1");
            //    imgCategory2 = (ImageButton)drgdCatBasicInfo.FindRowCellTemplateControl(intCateCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["CategoryName"], "imgCategory2");
            //    //imgCategory2 = (ImageButton)drgdCatBasicInfo.Items(intCateCount).FindControl("imgCategory2");
            //    if (intCateCount == 0)
            //    {
            //        imgCategory2.Visible = true;
            //        imgCategory1.Visible = false;
            //    }
            //    else
            //    {
            //        imgCategory2.Visible = false;
            //        imgCategory1.Visible = false;
            //    }
            //    for (int intCatCount = 0; intCatCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCatCount++)
            //    {
            //        //Label lblCatName = default(Label);
            //        //lblCatName = (Label)drgdCatBasicInfo.Items(intCatCount).FindControl("lblKeyName");
            //        Label lblCatName = (Label)drgdCatBasicInfo.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["CategoryName"], "lblKeyName");
            //        if (string.IsNullOrEmpty(lblCatName.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCatName.Parent.Parent.Parent;
            //            gvdc.Visible = true;
            //        }
            //    }
            //}


            //ImageButton imgPlant1 = default(ImageButton);
            //ImageButton imgPlant2 = default(ImageButton);
            //int intPlantCoun = 0;
            //for (intPlantCoun = 0; intPlantCoun <= drgdPlantBasicInfo.VisibleRowCount - 1; intCateCount++)
            //{
            //    //imgPlant1 = (ImageButton)drgdPlantBasicInfo.Items(intCateCount).FindControl("imgPlant1");
            //    //imgPlant2 = (ImageButton)drgdPlantBasicInfo.Items(intCateCount).FindControl("imgPlant2");
            //    imgPlant1 = (ImageButton)drgdPlantBasicInfo.FindRowCellTemplateControl(intPlantCoun, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "imgPlant1");
            //    imgPlant2 = (ImageButton)drgdPlantBasicInfo.FindRowCellTemplateControl(intPlantCoun, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "imgPlant2");

            //    if (intPlantCoun == 0)
            //    {
            //        imgPlant2.Visible = true;
            //        imgPlant1.Visible = false;
            //    }
            //    else
            //    {
            //        imgPlant2.Visible = false;
            //        imgPlant1.Visible = false;
            //    }
            //    for (int intPlantCount = 0; intPlantCount <= drgdPlantBasicInfo.VisibleRowCount - 1; intPlantCount++)
            //    {
            //        //Label lblPlantName = default(Label);
            //        //lblPlantName = (Label)drgdPlantBasicInfo.Items(intPlantCount).FindControl("lblplantName");
            //        Label lblPlantName = (Label)drgdPlantBasicInfo.FindRowCellTemplateControl(intPlantCount, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "lblplantName");
            //        if (string.IsNullOrEmpty(lblPlantName.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
            //            gvdc.Visible = true;
            //        }
            //    }
            //}



            //ImageButton imgEO1 = default(ImageButton);
            //ImageButton imgEO2 = default(ImageButton);
            //int intEOCoun = 0;
            //for (intEOCoun = 0; intEOCoun <= dgrdEOType.VisibleRowCount - 1; intEOCoun++)
            //{
            //    //imgEO1 = (ImageButton)dgrdEOType.Items(intEOCoun).FindControl("imgEOType1");
            //    //imgEO2 = (ImageButton)dgrdEOType.Items(intEOCoun).FindControl("imgEOType2");
            //    imgEO1 = (ImageButton)dgrdEOType.FindRowCellTemplateControl(intEOCoun, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "imgEOType1");
            //    imgEO2 = (ImageButton)dgrdEOType.FindRowCellTemplateControl(intEOCoun, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "imgEOType2");
              
            //    if (intEOCoun == 0)
            //    {
            //        imgEO2.Visible = true;
            //        imgEO1.Visible = false;
            //    }
            //    else
            //    {
            //        imgEO2.Visible = false;
            //        imgEO1.Visible = false;
            //    }
            //    for (int intEOCount = 0; intEOCount <= dgrdEOType.VisibleRowCount - 1; intEOCount++)
            //    {
            //        Label lblEOType = (Label)dgrdEOType.FindRowCellTemplateControl(intEOCount, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "lblEO");
            //        if (string.IsNullOrEmpty(lblEOType.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOType.Parent.Parent.Parent;
            //            gvdc.Visible = true;
            //        }
            //    }
            //}



            //ImageButton imgproj1 = default(ImageButton);
            //ImageButton imgproj2 = default(ImageButton);
            //int intproCoun = 0;
            //for (intproCoun = 0; intproCoun <= dgrdProjectType.VisibleRowCount - 1; intproCoun++)
            //{
            //    //imgproj1 = (ImageButton)dgrdProjectType.Items(intproCoun).FindControl("ImgProjType1");
            //    //imgproj2 = (ImageButton)dgrdProjectType.Items(intproCoun).FindControl("ImgProjType2");
            //    imgproj1 = (ImageButton)dgrdProjectType.FindRowCellTemplateControl(intproCoun, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "ImgProjType1");
            //    imgproj2 = (ImageButton)dgrdProjectType.FindRowCellTemplateControl(intproCoun, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "ImgProjType2");
              
            //    if (intproCoun == 0)
            //    {
            //        imgproj2.Visible = true;
            //        imgproj1.Visible = false;
            //    }
            //    else
            //    {
            //        imgproj2.Visible = false;
            //        imgproj1.Visible = false;
            //    }
            //    for (int intProjCount = 0; intProjCount <= dgrdProjectType.VisibleRowCount - 1; intProjCount++)
            //    {
            //        //Label lblProjType = default(Label);
            //        //lblProjType = (Label)dgrdProjectType.Items(intProjCount).FindControl("lblProjType");
            //        Label lblProjType = (Label)dgrdProjectType.FindRowCellTemplateControl(intProjCount, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "lblProjType");
            //        //If intProjCount = 0 Then
            //        //    imgproj2.Visible = False
            //        //    imgproj1.Visible = False
            //        //End If
            //        if (string.IsNullOrEmpty(lblProjType.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblProjType.Parent.Parent.Parent;
            //            gvdc.Visible = true;
            //        }
            //    }
            //}



            //ImageButton imgfun1 = default(ImageButton);
            //ImageButton imgfun2 = default(ImageButton);
            //int intfunCoun = 0;
            //for (intfunCoun = 0; intfunCoun <= dgrdFunction.VisibleRowCount - 1; intfunCoun++)
            //{
            //    //imgfun1 = (ImageButton)dgrdFunction.Items(intfunCoun).FindControl("Imagefun1");
            //    //imgfun2 = (ImageButton)dgrdFunction.Items(intfunCoun).FindControl("Imagefun2");
            //    imgfun1 = (ImageButton)dgrdFunction.FindRowCellTemplateControl(intfunCoun, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "Imagefun1");
            //    imgfun2 = (ImageButton)dgrdFunction.FindRowCellTemplateControl(intfunCoun, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "Imagefun2");
            //    if (intfunCoun == 0)
            //    {
            //        imgfun2.Visible = true;
            //        imgfun1.Visible = false;
            //    }
            //    else
            //    {
            //        imgfun2.Visible = false;
            //        imgfun1.Visible = false;
            //    }
            //    for (int intfunCount = 0; intfunCount <= dgrdFunction.VisibleRowCount - 1; intfunCount++)
            //    {
            //        //Label lblfun = default(Label);
            //        //lblfun = (Label)dgrdFunction.Items(intfunCount).FindControl("lblfunc");
            //        Label lblfun = (Label)dgrdFunction.FindRowCellTemplateControl(intfunCount, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "lblfunc");
            //        if (string.IsNullOrEmpty(lblfun.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblfun.Parent.Parent.Parent;
            //            gvdc.Visible = true;
            //        }
            //    }
            //}



            //ImageButton ImageMachine1 = default(ImageButton);
            //ImageButton ImageMachine2 = default(ImageButton);
            //int intMachCount = 0;
            //for (intMachCount = 0; intMachCount <= dgrdMachine.VisibleRowCount - 1; intMachCount++)
            //{
            //    //ImageMachine1 = (ImageButton)dgrdMachine.Items(intMachCount).FindControl("ImageMachine1");
            //    //ImageMachine2 = (ImageButton)dgrdMachine.Items(intMachCount).FindControl("ImageMachine2");
            //    ImageMachine1 = (ImageButton)dgrdMachine.FindRowCellTemplateControl(intMachCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "ImageMachine1");
            //    ImageMachine2 = (ImageButton)dgrdMachine.FindRowCellTemplateControl(intMachCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "ImageMachine2");
            //    if (intMachCount == 0)
            //    {
            //        ImageMachine2.Visible = true;
            //        ImageMachine1.Visible = false;
            //    }
            //    else
            //    {
            //        ImageMachine2.Visible = false;
            //        ImageMachine1.Visible = false;
            //    }

            //    for (int intMacCount = 0; intMacCount <= dgrdMachine.VisibleRowCount - 1; intMacCount++)
            //    {
            //        //Label lblMachine = default(Label);
            //        //lblMachine = (Label)dgrdMachine.Items(intMacCount).FindControl("lblMachine");
            //        Label lblMachine = (Label)dgrdMachine.FindRowCellTemplateControl(intMacCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "lblMachine");
            //        if (string.IsNullOrEmpty(lblMachine.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblMachine.Parent.Parent.Parent;
            //            gvdc.Visible = true;
            //        }
            //    }
            //}
        }


        protected void imgCollapseall_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["Expand"] = "COLLAPSE";
                ViewState["SingleCat"] = null;
                ViewState["SingleCatt"] = null;
                ViewState["SinglePL"] = null;
                ViewState["SinglePLL"] = null;
                ViewState["SinglePR"] = null;
                ViewState["SinglePRR"] = null;
                ViewState["SingleMA"] = null;
                ViewState["SingleMAA"] = null;
                ViewState["SingleEO"] = null;
                ViewState["SingleEOO"] = null;
                ViewState["SingleFU"] = null;
                ViewState["SingleFUU"] = null;
                //ImageButton imgCategory1 = default(ImageButton);
                //ImageButton imgCategory2 = default(ImageButton);
                //int intCateCount = 0;
                //for (intCateCount = 0; intCateCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCateCount++)
                //{
                //    //imgCategory1 = (ImageButton)drgdCatBasicInfo.Items(intCateCount).FindControl("imgCategory1");
                //    //imgCategory2 = (ImageButton)drgdCatBasicInfo.Items(intCateCount).FindControl("imgCategory2");
                //    imgCategory1 = (ImageButton)drgdCatBasicInfo.FindRowCellTemplateControl(intCateCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "imgCategory1");
                //    imgCategory2 = (ImageButton)drgdCatBasicInfo.FindRowCellTemplateControl(intCateCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "imgCategory2");

                //    if (intCateCount == 0)
                //    {
                //        imgCategory2.Visible = false;
                //        imgCategory1.Visible = true;
                //    }
                //    else
                //    {
                //        imgCategory2.Visible = false;
                //        imgCategory1.Visible = false;
                //    }
                //    for (int intCatCount = 0; intCatCount <= drgdCatBasicInfo.VisibleRowCount - 1; intCatCount++)
                //    {
                //        Label lblCatName = (Label)drgdCatBasicInfo.FindRowCellTemplateControl(intCatCount, (GridViewDataColumn)drgdCatBasicInfo.Columns["Key"], "lblKeyName");
                //        if (string.IsNullOrEmpty(lblCatName.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCatName.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //    }
                //}


                //ImageButton imgPlant1 = default(ImageButton);
                //ImageButton imgPlant2 = default(ImageButton);
                //int intPlantCoun = 0;
                //for (intPlantCoun = 0; intPlantCoun <= drgdPlantBasicInfo.VisibleRowCount - 1; intCateCount++)
                //{
                //    imgPlant1 = (ImageButton)drgdPlantBasicInfo.FindRowCellTemplateControl(intPlantCoun, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "imgPlant1");
                //    imgPlant2 = (ImageButton)drgdPlantBasicInfo.FindRowCellTemplateControl(intPlantCoun, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "imgPlant2");
                //    if (intPlantCoun == 0)
                //    {
                //        imgPlant2.Visible = false;
                //        imgPlant1.Visible = true;
                //    }
                //    else
                //    {
                //        imgPlant2.Visible = false;
                //        imgPlant1.Visible = false;
                //    }
                //    for (int intPlantCount = 0; intPlantCount <= drgdPlantBasicInfo.VisibleRowCount - 1; intPlantCount++)
                //    {
                //        Label lblPlantName = (Label)drgdPlantBasicInfo.FindRowCellTemplateControl(intPlantCount, (GridViewDataColumn)drgdPlantBasicInfo.Columns["Plant"], "lblplantName");
                //        if (string.IsNullOrEmpty(lblPlantName.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //    }
                //}



                //ImageButton imgEO1 = default(ImageButton);
                //ImageButton imgEO2 = default(ImageButton);
                //int intEOCoun = 0;
                //for (intEOCoun = 0; intEOCoun <= dgrdEOType.VisibleRowCount - 1; intEOCoun++)
                //{
                //    imgEO1 = (ImageButton)dgrdEOType.FindRowCellTemplateControl(intEOCoun, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "imgEOType1");
                //    imgEO2 = (ImageButton)dgrdEOType.FindRowCellTemplateControl(intEOCoun, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "imgEOType2");
                //    if (intEOCoun == 0)
                //    {
                //        imgEO2.Visible = false;
                //        imgEO1.Visible = true;
                //    }
                //    else
                //    {
                //        imgEO2.Visible = false;
                //        imgEO1.Visible = false;
                //    }
                //    for (int intEOCount = 0; intEOCount <= dgrdEOType.VisibleRowCount - 1; intEOCount++)
                //    {
                //        Label lblEOType = (Label)dgrdEOType.FindRowCellTemplateControl(intEOCount, (GridViewDataColumn)dgrdEOType.Columns["EOType"], "lblEO");
                //        if (string.IsNullOrEmpty(lblEOType.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOType.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //    }
                //}


                //ImageButton imgproj1 = default(ImageButton);
                //ImageButton imgproj2 = default(ImageButton);
                //int intproCoun = 0;
                //for (intproCoun = 0; intproCoun <= dgrdProjectType.VisibleRowCount - 1; intproCoun++)
                //{
                //    //imgproj1 = (ImageButton)dgrdProjectType.Items(intproCoun).FindControl("ImgProjType1");
                //    //imgproj2 = (ImageButton)dgrdProjectType.Items(intproCoun).FindControl("ImgProjType2");
                //    imgproj1 = (ImageButton)dgrdProjectType.FindRowCellTemplateControl(intproCoun, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "ImgProjType1");
                //    imgproj1 = (ImageButton)dgrdProjectType.FindRowCellTemplateControl(intproCoun, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "ImgProjType2");
                //    if (intproCoun == 0)
                //    {
                //        imgproj2.Visible = false;
                //        imgproj1.Visible = true;
                //    }
                //    else
                //    {
                //        imgproj2.Visible = false;
                //        imgproj1.Visible = false;
                //    }
                //    for (int intProjCount = 0; intProjCount <= dgrdProjectType.VisibleRowCount - 1; intProjCount++)
                //    {
                //        Label lblProjType = (Label)dgrdProjectType.FindRowCellTemplateControl(intProjCount, (GridViewDataColumn)dgrdProjectType.Columns["ProjectType"], "lblProjType");
                //        if (string.IsNullOrEmpty(lblProjType.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblProjType.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //    }
                //}


                //ImageButton imgfun1 = default(ImageButton);
                //ImageButton imgfun2 = default(ImageButton);
                //int intfunCoun = 0;
                //for (intfunCoun = 0; intfunCoun <= dgrdFunction.VisibleRowCount - 1; intfunCoun++)
                //{
                //    imgfun1 = (ImageButton)dgrdFunction.FindRowCellTemplateControl(intfunCoun, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "Imagefun1");
                //    imgfun2 = (ImageButton)dgrdFunction.FindRowCellTemplateControl(intfunCoun, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "Imagefun2");

                //    if (intfunCoun == 0)
                //    {
                //        imgfun2.Visible = false;
                //        imgfun1.Visible = true;
                //    }
                //    else
                //    {
                //        imgfun2.Visible = false;
                //        imgfun1.Visible = false;
                //    }
                //    for (int intfunCount = 0; intfunCount <= dgrdFunction.VisibleRowCount - 1; intfunCount++)
                //    {
                //        Label lblfun = (Label)dgrdFunction.FindRowCellTemplateControl(intfunCount, (GridViewDataColumn)dgrdFunction.Columns["FunctionName"], "lblfunc");
                //        if (string.IsNullOrEmpty(lblfun.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblfun.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //    }
                //}



                //ImageButton ImageMachine1 = default(ImageButton);
                //ImageButton ImageMachine2 = default(ImageButton);
                //int intMachCount = 0;
                //for (intMachCount = 0; intMachCount <= dgrdMachine.VisibleRowCount - 1; intMachCount++)
                //{
                //    ImageMachine1 = (ImageButton)dgrdMachine.FindRowCellTemplateControl(intMachCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "ImageMachine1");
                //    ImageMachine2 = (ImageButton)dgrdMachine.FindRowCellTemplateControl(intMachCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "ImageMachine2");

                //    if (intMachCount == 0)
                //    {
                //        ImageMachine2.Visible = false;
                //        ImageMachine1.Visible = true;
                //    }
                //    else
                //    {
                //        ImageMachine2.Visible = false;
                //        ImageMachine1.Visible = false;
                //    }

                //    for (int intMacCount = 0; intMacCount <= dgrdMachine.VisibleRowCount - 1; intMacCount++)
                //    {
                //        Label lblMachine = (Label)dgrdMachine.FindRowCellTemplateControl(intMacCount, (GridViewDataColumn)dgrdMachine.Columns["MachineName"], "lblMachine");
                //        if (string.IsNullOrEmpty(lblMachine.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblMachine.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //    }
                //}
            }
            catch (Exception exc)
            {

            }
        }

    }
}