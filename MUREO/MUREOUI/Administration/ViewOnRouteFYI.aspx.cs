using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using System.Data;
using System.Collections;
using DevExpress.Web.ASPxGridView.Rendering;
using System.Configuration;
using MUREOBAL;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class ViewOnRouteFYI : System.Web.UI.Page
    {
        string strScript = string.Empty;
        clsFYIRecipientsBO objclsFYIRecipientsBO = null;
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillDataGrid()
                FillApprovarByCategory();
            }
        }

        protected void imgExpandAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            ViewState["Single"] = null;
            ViewState["SingleMain"] = null;
            ViewState["PlantSingleMain"] = null;
            ViewState["PlantSingle"] = null;
            FillApprovarByCategory();
        }

        protected void imgCollapseAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            ViewState["Single"] = null;
            ViewState["SingleMain"] = null;
            ViewState["PlantSingleMain"] = null;
            ViewState["PlantSingle"] = null;
            FillApprovarByCategory();
        }

        protected void imgCreateNewFYI_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddOnRouteFYI.aspx?Mode=New");
        }

        protected void dgdOnRouteFYI_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView dgdOnRouteFYI = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    LinkButton lnkApproverName2 = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");
                    ImageButton imgRegion1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "imgRegion1");
                    ImageButton imgRegion2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "imgRegion2");
                    Label lblRegionID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionId");
                    Label lblRegionName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionName");
                    ImageButton imgPlant1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant1");
                    ImageButton imgPlant2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant2");
                    Label lblPlantID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantID");
                    Label lblPlanttName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
                    Label lblCategoryID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lblCategoryId");
                    Label lblRecipientName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdOnRouteFYI.Columns["FYI Recipients"], "lblRecipientName");
                    // ImageButton imgFunction1 = (ImageButton)imgRemoveButton.Parent.FindControl("imgFunction1");
                    // ImageButton imgFunction2 = (ImageButton)imgRemoveButton.Parent.FindControl("imgFunction2");
                    //Label lblFunctionID = (Label)imgRemoveButton.Parent.FindControl("lblFunctionID");
                    //Label lblFunctionName = (Label)imgRemoveButton.Parent.FindControl("lblFunctionName");
                    if (ViewState["Expand"] != null)
                    {
                        if (!(ViewState["Expand"] == "ExpandMode"))
                        {
                            //Displaying only Function names in first load of datagrid

                            //Displaying only Category names in first load of datagrid

                            imgRegion2.Visible = false;
                            lblRegionID.Visible = false;
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;
                            if (string.IsNullOrEmpty(lblRegionName.Text) && string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                //e.Row.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                            }
                            if (string.IsNullOrEmpty(lblRegionName.Text))
                            {
                                e.Row.Visible = false;
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                lblPlanttName.Visible = false;
                                lblRecipientName.Visible = false;
                                lnkApproverName2.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
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
                            //Displaying only Category names in first load of datagrid

                            imgRegion1.Visible = true;
                            imgRegion2.Visible = false;
                            lblRegionID.Visible = false;
                            if (string.IsNullOrEmpty(lblRegionName.Text))
                            {
                                //e.Row.Visible = false;
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                            }
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row.Cells[2] != null)
                                    e.Row.Cells[2].CssClass = "viscol";
                                if (e.Row.Cells[3] != null)
                                    e.Row.Cells[3].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            }
                            e.Row.Visible = true;
                            imgPlant1.Visible = true;
                            imgPlant2.Visible = false;
                            lblPlantID.Visible = false;

                            if (string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                            }
                            if (string.IsNullOrEmpty(lblRegionName.Text) && string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                            }
                            lblCategoryID.Visible = false;



                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgRegion2.Visible = false;
                            lblRegionName.Visible = true;
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            if ((!string.IsNullOrEmpty(lblRegionName.Text)) && string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                imgRegion1.Visible = true;
                                lblRegionName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                e.Row.Visible = true;
                            }
                            if (string.IsNullOrEmpty(lblRegionName.Text))
                            {
                                imgRegion1.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                e.Row.Visible = false;
                            }
                            lblPlanttName.Visible = false;
                            lblRecipientName.Visible = false;
                            lblRecipientName.Visible = false;
                            lnkApproverName2.Visible = false;
                            lblCategoryID.Visible = false;
                            //if (string.IsNullOrEmpty(lblRegionName.Text) && string.IsNullOrEmpty(lblPlanttName.Text))
                            //{
                            //    //e.Row.Visible = false;
                            //    if (e.Row.Cells.Count > 1)
                            //    {
                            //        if (e.Row.Cells[0] != null)
                            //            e.Row.Cells[0].CssClass = "hiddencol";
                            //        if (e.Row.Cells[1] != null)
                            //            e.Row.Cells[1].CssClass = "hiddencol";
                            //        if (e.Row.Cells[2] != null)
                            //            e.Row.Cells[2].CssClass = "hiddencol";
                            //        if (e.Row.Cells[3] != null)
                            //            e.Row.Cells[3].CssClass = "hiddencol";
                            //        if (e.Row != null)
                            //            e.Row.CssClass = "hiddencol";
                            //    }
                            //    else
                            //    {
                            //        if (e.Row.Cells[0] != null)
                            //            e.Row.Cells[0].CssClass = "hiddencol";
                            //    }
                            //}
                            if (string.IsNullOrEmpty(lblRegionName.Text) && string.IsNullOrEmpty(lblPlanttName.Text) && string.IsNullOrEmpty(lnkApproverName2.Text))
                            {
                                
                                //e.Row.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
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
                            imgRegion1.Visible = false;
                            imgRegion2.Visible = true;
                            lblRegionName.Visible = true;
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row.Cells[2] != null)
                                    e.Row.Cells[2].CssClass = "viscol";
                                if (e.Row.Cells[3] != null)
                                    e.Row.Cells[3].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            }
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {
                            //lblFunctionID.Visible = false;
                            imgPlant1.Visible = true;
                            imgPlant2.Visible = false;
                            lblPlanttName.Visible = true;
                            // lblFunctionID.Visible = false;                         
                            if (string.IsNullOrEmpty(lblRegionName.Text) && (!string.IsNullOrEmpty(lblPlanttName.Text)))
                            {
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                imgPlant1.Visible = true;
                                imgPlant2.Visible = false;
                                lblRecipientName.Visible = false;
                                lnkApproverName2.Visible = false;
                                lblPlanttName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                e.Row.Visible = true;
                            }
                            if (string.IsNullOrEmpty(lblRegionName.Text) && string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                imgPlant1.Visible = false;
                                e.Row.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
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
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;
                            lblPlanttName.Visible = false;
                            imgRegion1.Visible = false;
                            imgRegion2.Visible = false;
                            lblRegionName.Visible = false;
                            // lblFunctionID.Visible = false;
                            if ((!string.IsNullOrEmpty(lblRegionName.Text)) && string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                imgRegion1.Visible = true;
                                imgRegion2.Visible = false;
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lblPlanttName.Visible = false;
                                lnkApproverName2.Visible = false;
                                lblRecipientName.Visible = false;
                                lblRegionName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                e.Row.Visible = true;
                            }
                            if (string.IsNullOrEmpty(lblRegionName.Text) && string.IsNullOrEmpty(lblPlanttName.Text))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                lblPlanttName.Visible = false;
                                lnkApproverName2.Visible = false;
                                lblRecipientName.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                //e.Row.Visible = false;
                            }
                        }
                        if (cls.IsExists(Convert.ToString(ViewState["PlantSingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = true;
                            lblPlanttName.Visible = true;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row.Cells[2] != null)
                                    e.Row.Cells[2].CssClass = "viscol";
                                if (e.Row.Cells[3] != null)
                                    e.Row.Cells[3].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            }
                            //e.Row.Visible = true;
                        }
                        else if (ViewState["PlantSingle"] != null)
                        {
                            if (cls.IsExists(Convert.ToString(ViewState["PlantSingle"]), Convert.ToString(e.VisibleIndex)))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                //lblPlanttName.Visible = true;
                                lnkApproverName2.Visible = true;
                                lblRecipientName.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }                                              
                                //e.Row.Visible = true;
                            }
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["PlantSingleEX"]), Convert.ToString(e.VisibleIndex)))
                        {
                            imgPlant1.Visible = true;
                            imgPlant2.Visible = false;
                            lblPlanttName.Visible = true;
                            lnkApproverName2.Visible = false;
                            lblRecipientName.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row.Cells[2] != null)
                                    e.Row.Cells[2].CssClass = "viscol";
                                if (e.Row.Cells[3] != null)
                                    e.Row.Cells[3].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            } 
                            //e.Row.Visible = true;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                //objErrorLog.SaveErrorLog(strModule + "gvRecords_HtmlRowCreated", "Error", ex.Message, "gvRecords_HtmlRowCreated", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }
        //private void dgdOnRouteFYI_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //when user clicks on category expand image button then application will execute below code
        //    // this code will diplay brand names

        //    if (e.CommandName == "Region1")
        //    {
        //        ImageButton imgRegion2 = default(ImageButton);
        //        imgRegion2 = (ImageButton)e.Item.FindControl("imgRegion2");
        //        imgRegion2.Visible = true;
        //        //imgCategory2.Attributes.Add(  

        //        ImageButton imgRegion1 = default(ImageButton);
        //        imgRegion1 = (ImageButton)e.Item.FindControl("imgRegion1");
        //        imgRegion1.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgRegion2.ClientID + "').focus();</script>");

        //        int rowno = e.Item.ItemIndex;



        //        for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
        //        {


        //            Label lblRegionName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblRegionName");
        //            Label lblPlantName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblPlantName");
        //            Label lblPlantID = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblPlantID");



        //            ImageButton imgPlant1 = default(ImageButton);
        //            ImageButton imgPlant2 = default(ImageButton);
        //            imgPlant1 = (ImageButton)dgdOnRouteFYI.Items(rowCount).FindControl("imgPlant1");
        //            imgPlant2 = (ImageButton)dgdOnRouteFYI.Items(rowCount).FindControl("imgPlant2");


        //            if (string.IsNullOrEmpty(lblRegionName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    dgdOnRouteFYI.Items(rowCount).Visible = true;
        //                    imgPlant1.Visible = true;
        //                    imgPlant2.Visible = false;
        //                    lblPlantID.Visible = false;
        //                }
        //                else
        //                {
        //                    dgdOnRouteFYI.Items(rowCount).Visible = false;
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

        //    if (e.CommandName == "Region2")
        //    {
        //        ImageButton imgRegion2 = default(ImageButton);
        //        imgRegion2 = (ImageButton)e.Item.FindControl("imgRegion2");
        //        imgRegion2.Visible = false;

        //        ImageButton imgRegion1 = default(ImageButton);
        //        imgRegion1 = (ImageButton)e.Item.FindControl("imgRegion1");
        //        imgRegion1.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgRegion1.ClientID + "').focus();</script>");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
        //        {

        //            Label lblRegionName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblRegionName");
        //            Label lblPlantName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblPlantName");
        //            LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.Items(rowCount).FindControl("lnkCategoryName");


        //            ImageButton imgPlant1 = default(ImageButton);
        //            imgPlant1 = (ImageButton)dgdOnRouteFYI.Items(rowCount).FindControl("imgPlant1");
        //            ImageButton imgPlant2 = default(ImageButton);
        //            imgPlant2 = (ImageButton)dgdOnRouteFYI.Items(rowCount).FindControl("imgPlant2");

        //            if (string.IsNullOrEmpty(lblRegionName.Text))
        //            {
        //                dgdOnRouteFYI.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }

        //    //when user clicks on Brand Name Expand image button then application will execute below code
        //    // this code will diplay only Project names and project details

        //    if (e.CommandName == "Plant1")
        //    {
        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant1.Visible = false;
        //        imgPlant2.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgPlant2.ClientID + "').focus();</script>");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
        //        {
        //            LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.Items(rowCount).FindControl("lnkCategoryName");
        //            Label lblPlantName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblPlantName");

        //            //Dim lblMachineName As Label = CType(dgdOnRouteFYI.Items(rowCount).FindControl("lblMachineName"), Label)
        //            //Dim lblMachineID As Label = CType(dgdOnRouteFYI.Items(rowCount).FindControl("lblMachineID"), Label)




        //            if (string.IsNullOrEmpty(lblPlantName.Text) & !string.IsNullOrEmpty(lnkCategoryName.Text))
        //            {
        //                //If Not lblMachineName.Text = "" Then
        //                //    dgdOnRouteFYI.Items(rowCount).Visible = True
        //                //    lblMachineID.Visible = False

        //                //Else

        //                dgdOnRouteFYI.Items(rowCount).Visible = true;
        //                //End If

        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }


        //    //when user clicks on Brand Name collapse image button then application will execute below code
        //    // this code will diplay only brand names and hiding all project details

        //    if (e.CommandName == "Plant2")
        //    {
        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant1.Visible = true;
        //        imgPlant2.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgPlant1.ClientID + "').focus();</script>");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
        //        {
        //            LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.Items(rowCount).FindControl("lnkCategoryName");
        //            Label lblPlantName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblPlantName");


        //            if (string.IsNullOrEmpty(lnkCategoryName.Text) & !string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //            else
        //            {
        //                dgdOnRouteFYI.Items(rowCount).Visible = false;
        //            }
        //        }
        //    }

        //    // This part has to be completed

        //    if (e.CommandName == "Category_Link")
        //    {
        //        Label lblRecipientID = (Label)e.Item.FindControl("lblRecipientID");

        //        //Dim lblCategoryID As Label = CType(e.Item.FindControl("lblCategoryID"), Label)
        //        //Dim lblPlantID As Label = CType(e.Item.FindControl("lblPlantID"), Label)
        //        //Dim lblMachineID As Label = CType(e.Item.FindControl("lblMachineID"), Label)
        //        //Dim lblMachineName As Label = CType(e.Item.FindControl("lblMachineName"), Label)

        //        //Response.Redirect("../Administration/AddConvertingMachine.aspx?MachineID=" + lblMachineID.Text + "&Mode=Edit" + "&CategoryID=" + lblCategoryID.Text + "&PlantID=" + lblPlantID.Text + "&MachineName=" + lblMachineName.Text)
        //        Response.Redirect("../Administration/AddOnRouteFYI.aspx?Mode=View&ID=" + lblRecipientID.Text);
        //    }
        //}

        private void FillApprovarByCategory()
        {
            DataSet dsApproverByRegion = new DataSet();
            //dsMachinesByCategory = New DataSet

            //Creating object from ReportsBo class
            //clsFYIRecipients objFYINamesByCategory = new clsFYIRecipients();
            clsFYIRecipientsBO objclsFYIRecipientsBO = new clsFYIRecipientsBO();
            //Dim objProjectsByCategory As New BusinessObject.MUREO.BusinessObject.MachinesByCategory

            if (objclsFYIRecipientsBO.GetRecipients(ref dsApproverByRegion))
            {
                //dsMachinesByCategory = objProjectsByCategory.FillMachinesByCategory()


                if (dsApproverByRegion == null)
                {
                    NoRecords();
                }
                else if (dsApproverByRegion.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsApproverByRegion.Tables[0].Rows.Count == 0)
                {
                    NoRecords();

                }
                else
                {
                    //Temprary table for ProjectsBycategory
                    //Dim dtMachineByCategory As New DataTable
                    DataTable dtApprovarByRegion = new DataTable();

                    DataRow drApprovarByRegion = null;
                    //Dim drMachineByCategory As DataRow

                    dtApprovarByRegion.Columns.Add("Region_ID");
                    dtApprovarByRegion.Columns.Add("Region_Name");
                    dtApprovarByRegion.Columns.Add("Plant_ID");
                    dtApprovarByRegion.Columns.Add("Plant_Name");
                    dtApprovarByRegion.Columns.Add("Category_ID");
                    dtApprovarByRegion.Columns.Add("Category_Name");
                    dtApprovarByRegion.Columns.Add("Approver_Name");
                    dtApprovarByRegion.Columns.Add("FYI_Recipient_ID");


                    //Below code for splitting data for treeview display and binding splitted data into temperory table
                    ArrayList arrayRegionName = new ArrayList();
                    //Dim arrayCategoryName As New ArrayList

                    ArrayList arrayRegionID = new ArrayList();
                    //Dim arrayCategoryID As New ArrayList

                    //First row item of category name
                    string strRegionName = Convert.ToString(dsApproverByRegion.Tables[0].Rows[0]["Region_Name"]);
                    //Dim strCategoryName As String = dsApproverByRegion.Tables(0).Rows(0).Item("Category_Name")

                    string strRegionID = Convert.ToString(dsApproverByRegion.Tables[0].Rows[0]["Region_ID"]);
                    //Dim strCategoryID As String = dsApproverByRegion.Tables(0).Rows(0).Item("Category_ID")

                    //Adding Category name to array`
                    arrayRegionName.Add(strRegionName);
                    arrayRegionID.Add(strRegionID);

                    //Adding all categoory names(Without repitition)

                    for (int rowCount = 0; rowCount <= dsApproverByRegion.Tables[0].Rows.Count - 1; rowCount++)
                    {
                        string strRegionName1 = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowCount]["Region_Name"]);
                        string strRegionID1 = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowCount]["Region_ID"]);


                        if (!(arrayRegionName.Contains(strRegionName1)))
                        {
                            arrayRegionName.Add(strRegionName1);
                            arrayRegionID.Add(strRegionID1);

                        }
                    }



                    //Based on Category name storing Category ID and Category name in to temperory table

                    for (int rowCategoryNameCount = 0; rowCategoryNameCount <= arrayRegionName.Count - 1; rowCategoryNameCount++)
                    {
                        drApprovarByRegion = dtApprovarByRegion.NewRow();
                        drApprovarByRegion["Region_ID"] = "";
                        drApprovarByRegion["Region_Name"] = arrayRegionName[rowCategoryNameCount];
                        drApprovarByRegion["Plant_ID"] = "";
                        drApprovarByRegion["Plant_Name"] = "";
                        drApprovarByRegion["Category_ID"] = "";
                        drApprovarByRegion["Category_Name"] = "";
                        drApprovarByRegion["Approver_Name"] = "";
                        drApprovarByRegion["FYI_Recipient_ID"] = "";
                        dtApprovarByRegion.Rows.Add(drApprovarByRegion);

                        ArrayList arrayPlantName = new ArrayList();
                        //Dim arrayBrandName As New ArrayList
                        ArrayList arrayPlantID = new ArrayList();
                        //Dim arrayBrandID As New ArrayList


                        //Adding brand names(Without repitition) based on Category Name

                        for (int rowBrandCount = 0; rowBrandCount <= dsApproverByRegion.Tables[0].Rows.Count - 1; rowBrandCount++)
                        {

                            if (Convert.ToString(arrayRegionName[rowCategoryNameCount]).Trim().ToUpper() == Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount]["Region_Name"]).Trim().ToUpper())
                            {
                                string strPlantName = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount]["Plant_Name"]);
                                string strPlantID = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount]["Plant_ID"]);

                                if (arrayPlantName.Count == 0)
                                {
                                    arrayPlantName.Add(strPlantName);
                                    arrayPlantID.Add(strPlantID);
                                }

                                if (!(arrayPlantName.Contains(strPlantName)))
                                {
                                    arrayPlantName.Add(strPlantName);
                                    arrayPlantID.Add(strPlantID);
                                }

                            }

                        }


                        //Based on Brand name storing Plant ID and Plant name in to temperory table

                        for (int rowBrandCount1 = 0; rowBrandCount1 <= arrayPlantName.Count - 1; rowBrandCount1++)
                        {
                            drApprovarByRegion = dtApprovarByRegion.NewRow();
                            drApprovarByRegion["Region_ID"] = "";
                            drApprovarByRegion["Region_Name"] = "";
                            drApprovarByRegion["Plant_ID"] = "";
                            drApprovarByRegion["Plant_Name"] = arrayPlantName[rowBrandCount1];
                            drApprovarByRegion["Category_ID"] = "";
                            drApprovarByRegion["Category_Name"] = "";
                            drApprovarByRegion["Approver_Name"] = "";
                            drApprovarByRegion["FYI_Recipient_ID"] = "";

                            dtApprovarByRegion.Rows.Add(drApprovarByRegion);


                            for (int rowBrandCount2 = 0; rowBrandCount2 <= dsApproverByRegion.Tables[0].Rows.Count - 1; rowBrandCount2++)
                            {

                                if (Convert.ToString(arrayRegionName[rowCategoryNameCount]).Trim().ToUpper() == Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Region_Name"]).Trim().ToUpper() & Convert.ToString(arrayPlantName[rowBrandCount1]).Trim().ToUpper() == Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Plant_Name"]).Trim().ToUpper())
                                {
                                    drApprovarByRegion = dtApprovarByRegion.NewRow();
                                    drApprovarByRegion["Region_ID"] = arrayRegionID[rowCategoryNameCount];
                                    drApprovarByRegion["Region_Name"] = "";
                                    drApprovarByRegion["Plant_ID"] = arrayPlantID[rowBrandCount1];
                                    drApprovarByRegion["Plant_Name"] = "";
                                    drApprovarByRegion["Category_ID"] = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Category_ID"]);
                                    drApprovarByRegion["Category_Name"] = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Category_Name"]);
                                    drApprovarByRegion["Approver_Name"] = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Approver_Name"]);
                                    drApprovarByRegion["FYI_Recipient_ID"] = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["FYI_Recipient_ID"]);
                                    dtApprovarByRegion.Rows.Add(drApprovarByRegion);


                                }

                            }
                        }
                    }

                    dgdOnRouteFYI.DataSource = dtApprovarByRegion;
                    dgdOnRouteFYI.DataBind();
                }


            }
        }

        //private void FillApprovarByCategory()
        //{
        //    DataSet dsApproverByRegion = null;
        //    //dsMachinesByCategory = New DataSet

        //    //Creating object from ReportsBo class
        //    try
        //    {
        //        dsApproverByRegion = new DataSet();
        //        objclsFYIRecipientsBO = new clsFYIRecipientsBO();

        //        //Dim objProjectsByCategory As New BusinessObject.MUREO.BusinessObject.MachinesByCategory
        //        if (objclsFYIRecipientsBO.GetRecipients(ref dsApproverByRegion))
        //            //dsApproverByRegion = objFYINamesByCategory.GetRecipients();
        //            //dsMachinesByCategory = objProjectsByCategory.FillMachinesByCategory()


        //            if (dsApproverByRegion == null)
        //            {
        //                NoRecords();
        //            }
        //            else if (dsApproverByRegion.Tables.Count == 0)
        //            {
        //                NoRecords();
        //            }
        //            else if (dsApproverByRegion.Tables[0].Rows.Count == 0)
        //            {
        //                NoRecords();

        //            }
        //            else
        //            {
        //                //Temprary table for ProjectsBycategory
        //                //Dim dtMachineByCategory As New DataTable
        //                DataTable dtApprovarByRegion = new DataTable();

        //                DataRow drApprovarByRegion = null;
        //                //Dim drMachineByCategory As DataRow

        //                dtApprovarByRegion.Columns.Add("Region_ID");
        //                dtApprovarByRegion.Columns.Add("Region_Name");
        //                dtApprovarByRegion.Columns.Add("Plant_ID");
        //                dtApprovarByRegion.Columns.Add("Plant_Name");
        //                dtApprovarByRegion.Columns.Add("Category_ID");
        //                dtApprovarByRegion.Columns.Add("Category_Name");
        //                dtApprovarByRegion.Columns.Add("Approver_Name");
        //                dtApprovarByRegion.Columns.Add("FYI_Recipient_ID");


        //                //Below code for splitting data for treeview display and binding splitted data into temperory table
        //                ArrayList arrayRegionName = new ArrayList();
        //                //Dim arrayCategoryName As New ArrayList

        //                ArrayList arrayRegionID = new ArrayList();
        //                //Dim arrayCategoryID As New ArrayList

        //                //First row item of category name
        //                string strRegionName = Convert.ToString(dsApproverByRegion.Tables[0].Rows[0]["Region_Name"]);
        //                //Dim strCategoryName As String = dsApproverByRegion.Tables[0].Rows[0]["Category_Name")

        //                string strRegionID = Convert.ToString(dsApproverByRegion.Tables[0].Rows[0]["Region_ID"]);
        //                //Dim strCategoryID As String = dsApproverByRegion.Tables[0].Rows[0]["Category_ID")

        //                //Adding Category name to array`
        //                arrayRegionName.Add(strRegionName);
        //                arrayRegionID.Add(strRegionID);

        //                //Adding all categoory names(Without repitition)

        //                for (int rowCount = 0; rowCount <= dsApproverByRegion.Tables[0].Rows.Count - 1; rowCount++)
        //                {
        //                    string strRegionName1 = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowCount]["Region_Name"]);
        //                    string strRegionID1 = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowCount]["Region_ID"]);


        //                    if (!(arrayRegionName.Contains(strRegionName1)))
        //                    {
        //                        arrayRegionName.Add(strRegionName1);
        //                        arrayRegionID.Add(strRegionID1);

        //                    }
        //                }



        //                //Based on Category name storing Category ID and Category name in to temperory table

        //                for (int rowCategoryNameCount = 0; rowCategoryNameCount <= arrayRegionName.Count - 1; rowCategoryNameCount++)
        //                {
        //                    drApprovarByRegion = dtApprovarByRegion.NewRow();
        //                    drApprovarByRegion["Region_ID"] = arrayRegionID[rowCategoryNameCount];
        //                    drApprovarByRegion["Region_Name"] = arrayRegionName[rowCategoryNameCount];
        //                    drApprovarByRegion["Plant_ID"] = "";
        //                    drApprovarByRegion["Plant_Name"] = "";
        //                    drApprovarByRegion["Category_ID"] = "";
        //                    drApprovarByRegion["Category_Name"] = "";
        //                    drApprovarByRegion["Approver_Name"] = "";
        //                    drApprovarByRegion["FYI_Recipient_ID"] = "";
        //                    dtApprovarByRegion.Rows.Add(drApprovarByRegion);

        //                    ArrayList arrayPlantName = new ArrayList();
        //                    //Dim arrayBrandName As New ArrayList
        //                    ArrayList arrayPlantID = new ArrayList();
        //                    //Dim arrayBrandID As New ArrayList


        //                    //Adding brand names(Without repitition) based on Category Name

        //                    for (int rowBrandCount = 0; rowBrandCount <= dsApproverByRegion.Tables[0].Rows.Count - 1; rowBrandCount++)
        //                    {

        //                        if (Convert.ToString(arrayRegionName[rowCategoryNameCount]).Trim().ToUpper() == Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount]["Region_Name"]).Trim().ToUpper())
        //                        {
        //                            string strPlantName = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount]["Plant_Name"]);
        //                            string strPlantID = Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount]["Plant_ID"]);

        //                            if (arrayPlantName.Count == 0)
        //                            {
        //                                arrayPlantName.Add(strPlantName);
        //                                arrayPlantID.Add(strPlantID);
        //                            }

        //                            if (!(arrayPlantName.Contains(strPlantName)))
        //                            {
        //                                arrayPlantName.Add(strPlantName);
        //                                arrayPlantID.Add(strPlantID);
        //                            }

        //                        }

        //                    }


        //                    //Based on Brand name storing Plant ID and Plant name in to temperory table

        //                    for (int rowBrandCount1 = 0; rowBrandCount1 <= arrayPlantName.Count - 1; rowBrandCount1++)
        //                    {
        //                        drApprovarByRegion = dtApprovarByRegion.NewRow();
        //                        drApprovarByRegion["Region_ID"] = arrayRegionID[rowCategoryNameCount];
        //                        drApprovarByRegion["Region_Name"] = "";
        //                        drApprovarByRegion["Plant_ID"] = "";
        //                        drApprovarByRegion["Plant_Name"] = arrayPlantName[rowBrandCount1];
        //                        drApprovarByRegion["Category_ID"] = "";
        //                        drApprovarByRegion["Category_Name"] = "";
        //                        drApprovarByRegion["Approver_Name"] = "";
        //                        drApprovarByRegion["FYI_Recipient_ID"] = "";

        //                        dtApprovarByRegion.Rows.Add(drApprovarByRegion);


        //                        for (int rowBrandCount2 = 0; rowBrandCount2 <= dsApproverByRegion.Tables[0].Rows.Count - 1; rowBrandCount2++)
        //                        {

        //                            if (Convert.ToString(arrayRegionName[rowCategoryNameCount]).Trim().Trim().ToUpper() == Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Region_Name"]) && Convert.ToString(arrayPlantName[rowBrandCount1]) == Convert.ToString(dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Plant_Name"]).Trim().ToUpper())
        //                            {
        //                                drApprovarByRegion = dtApprovarByRegion.NewRow();
        //                                drApprovarByRegion["Region_ID"] = arrayRegionID[rowCategoryNameCount];
        //                                drApprovarByRegion["Region_Name"] = "";
        //                                drApprovarByRegion["Plant_ID"] = arrayPlantID[rowBrandCount1];
        //                                drApprovarByRegion["Plant_Name"] = "";
        //                                drApprovarByRegion["Category_ID"] = dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Category_ID"];
        //                                drApprovarByRegion["Category_Name"] = dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Category_Name"];
        //                                drApprovarByRegion["Approver_Name"] = dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["Approver_Name"];
        //                                drApprovarByRegion["FYI_Recipient_ID"] = dsApproverByRegion.Tables[0].Rows[rowBrandCount2]["FYI_Recipient_ID"];
        //                                dtApprovarByRegion.Rows.Add(drApprovarByRegion);
        //                            }

        //                        }
        //                    }
        //                }
        //                DataColumn dc = new DataColumn("Index");
        //                dtApprovarByRegion.Columns.Add(dc);
        //                int ind = 0;
        //                foreach (DataRow dr in dtApprovarByRegion.Rows)
        //                {
        //                    dr["Index"] = ind;
        //                    ind++;
        //                }
        //                dgdOnRouteFYI.DataSource = dtApprovarByRegion;
        //                dgdOnRouteFYI.DataBind();


        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();


        //    }
        //    finally
        //    {
        //        objclsFYIRecipientsBO = null;
        //        dsApproverByRegion = null;
        //    }
        //}


        private void NoRecords()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "No Records", strScript);

        }

        protected void imgRegion1_Command(object sender, CommandEventArgs e)
        {
            FillApprovarByCategory();
            ViewState["Expand"] = null;
            ViewState["PlantSingleMain"] = null;
            ViewState["PlantSingle"] = null;
            ViewState["PlantSingleEX"] = null;
            ImageButton imgReg1 = (ImageButton)sender;
            ImageButton imgReg2 = (ImageButton)imgReg1.Parent.FindControl("imgRegion2");
            imgReg2.Visible = true;
            //Make collapse button visible            
            imgReg1.Visible = false;
            string st = string.Empty;
            //Make expand button invisible
            // ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");
            GridViewDataRowTemplateContainer gvFYI = (GridViewDataRowTemplateContainer)imgReg1.Parent;
            int rowno = gvFYI.ItemIndex;
            ViewState["SingleMain"] = Convert.ToString(rowno);
            for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.VisibleRowCount - 1; rowCount++)
            {
                Label lblRegionName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionName");
                Label lblPlantName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
                Label lblPlantID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantId");
                ImageButton imgPlant1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant1");
                ImageButton imgPlant2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant2");
                LinkButton lnkApproverName2 = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");
                Label lblRecipientName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["FYI Recipients"], "lblRecipientName");
                if (string.IsNullOrEmpty(lblRegionName.Text))
                {
                    if (!string.IsNullOrEmpty(lblPlantName.Text))
                    {
                        st = st + Convert.ToString(rowCount) + ",";
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                        gvdc.Visible = true;
                        imgPlant1.Visible = true;
                        imgPlant2.Visible = false;
                        lblPlantID.Visible = false;
                    }
                    else
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }

                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit For
                }

            }
            ViewState["Single"] = st.TrimEnd(new char[] { ',' });
        }

        protected void imgRegion2_Command(object sender, CommandEventArgs e)
        {

            ViewState["Expand"] = null;
            ViewState["SingleMain"] = null;
            ViewState["Single"] = null;
            FillApprovarByCategory();
            ImageButton imgReg2 = (ImageButton)sender;
            ImageButton imgRegion1 = (ImageButton)imgReg2.Parent.FindControl("imgRegion2");
            imgReg2.Visible = false;
            //ImageButton imgRegion2 = default(ImageButton);
            //        imgRegion2 = (ImageButton)e.Item.FindControl("imgRegion2");
            //        imgRegion2.Visible = false;

            //        ImageButton imgRegion1 = default(ImageButton);
            //        imgRegion1 = (ImageButton)e.Item.FindControl("imgRegion1");
            //        imgRegion1.Visible = true;

            //        Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgRegion1.ClientID + "').focus();</script>");

            //        int rowno = e.Item.ItemIndex;


            //        for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
            //        {

            //            Label lblRegionName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblRegionName");
            //            Label lblPlantName = (Label)dgdOnRouteFYI.Items(rowCount).FindControl("lblPlantName");
            //            LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.Items(rowCount).FindControl("lnkCategoryName");


            //            ImageButton imgPlant1 = default(ImageButton);
            //            imgPlant1 = (ImageButton)dgdOnRouteFYI.Items(rowCount).FindControl("imgPlant1");
            //            ImageButton imgPlant2 = default(ImageButton);
            //            imgPlant2 = (ImageButton)dgdOnRouteFYI.Items(rowCount).FindControl("imgPlant2");

            //            if (string.IsNullOrEmpty(lblRegionName.Text))
            //            {
            //                dgdOnRouteFYI.Items(rowCount).Visible = false;
            //            }
            //            else
            //            {
            //                break; // TODO: might not be correct. Was : Exit For
            //            }

            //        }

            //ImageButton imgReg1 = (ImageButton)sender;
            //ImageButton imgRegion1 = (ImageButton)imgReg1.Parent.FindControl("imgRegion1");
            imgRegion1.Visible = true;

            //Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgRegion1.ClientID + "').focus();</script>");

            //int rowno = e.Item.ItemIndex;
            GridViewDataRowTemplateContainer gvFYI = (GridViewDataRowTemplateContainer)imgRegion1.Parent;
            int rowno = gvFYI.ItemIndex;
            for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.VisibleRowCount - 1; rowCount++)
            {

                Label lblRegionName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionName");
                Label lblPlantName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
                LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");

                ImageButton imgPlant1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant1");
                ImageButton imgPlant2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant2");
                LinkButton lnkApproverName2 = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");


                if (string.IsNullOrEmpty(lblRegionName.Text))
                {
                    GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                    gvdc.Visible = false;
                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit For
                }

            }
            //for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.VisibleRowCount - 1; rowCount++)
            //{


            //    Label lblRegionName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionName");
            //    Label lblPlantName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
            //    LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");

            //    ImageButton imgPlant1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant1");
            //    ImageButton imgPlant2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant2");
            //    LinkButton lnkApproverName2 = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");

            //    if (string.IsNullOrEmpty(lblRegionName.Text))
            //    {
            //        if (!string.IsNullOrEmpty(lblPlantName.Text))
            //        {
            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
            //            gvdc.Visible = false;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

            //}

        }

        protected void imgplant1_Command(object sender, CommandEventArgs e)
        {
            FillApprovarByCategory();
            ViewState["Expand"] = null;
            ImageButton imgPlnt1 = (ImageButton)sender;
            ImageButton imgPlant2 = (ImageButton)imgPlnt1.Parent.FindControl("imgPlant2");
            imgPlant2.Visible = true;
            imgPlnt1.Visible = false;
            string st = string.Empty;
            string sttemp = string.Empty;
            GridViewDataRowTemplateContainer gvFYI = (GridViewDataRowTemplateContainer)imgPlnt1.Parent;
            int rowno = gvFYI.ItemIndex;
            ViewState["PlantSingleMain"] = Convert.ToString(rowno);


            for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.VisibleRowCount - 1; rowCount++)
            {
                Label lblPlantName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
                LinkButton lnkApproverName2 = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");
                ImageButton imgRegion1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "imgRegion1");
                ImageButton imgRegion2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "imgRegion2");
                Label lblRegionID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionId");
                Label lblRegionName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionName");
                ImageButton imgP1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant1");
                ImageButton imgP2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant2");
                Label lblPlantID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantID");
                Label lblPlanttName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
                Label lblCategoryID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lblCategoryId");
                Label lblRecipientName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["FYI Recipients"], "lblRecipientName");
                LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");
                if (!string.IsNullOrEmpty(lnkCategoryName.Text))
                {
                    if (string.IsNullOrEmpty(sttemp))
                    {
                        st = st + Convert.ToString(rowCount) + ",";
                        lnkApproverName2.Visible = true;
                        lblRecipientName.Visible = true;
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                        gvdc.Visible = true;
                    }
                    //End If

                }
                else if (string.IsNullOrEmpty(lblRegionName.Text) && (!string.IsNullOrEmpty(lblPlanttName.Text)))
                {
                    sttemp = sttemp + Convert.ToString(rowCount) + ",";                    
                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit For
                }

            }
            ViewState["PlantSingle"] = st.TrimEnd(new char[] { ',' });
            ViewState["PlantSingleEX"] = sttemp.TrimEnd(new char[] { ',' });
            // for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
            //for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.VisibleRowCount - 1; rowCount++)
            //{
            //    Label lblPlantName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
            //    LinkButton lnkApproverName2 = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");
            //    ImageButton imgRegion1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "imgRegion1");
            //    ImageButton imgRegion2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "imgRegion2");
            //    Label lblRegionID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionId");
            //    Label lblRegionName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Region"], "lblRegionName");
            //    ImageButton imgP1 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant1");
            //    ImageButton imgP2 = (ImageButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "imgplant2");
            //    Label lblPlantID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantID");
            //    Label lblPlanttName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
            //    Label lblCategoryID = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lblCategoryId");
            //    Label lblRecipientName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["FYI Recipients"], "lblRecipientName");


            //    LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");


            //    if (string.IsNullOrEmpty(lblPlantName.Text))
            //    {
            //        st = st + Convert.ToString(rowCount) + ",";
            //        ViewState["PlantSingle"] = st.TrimEnd(new char[] { ',' });
            //        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
            //        gvdc.Visible = true;
            //        imgPlnt1.Visible = false;
            //        imgPlant2.Visible = false;
            //        lblPlantName.Visible = false;
            //        lblPlantID.Visible = false;
            //        lnkApproverName2.Visible = false;
            //        lblRecipientName.Visible = false;
            //    }
            //    else
            //    {
            //        break; // TODO: might not be correct. Was : Exit For
            //    }

            //}

        }

        protected void imgplant2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            ImageButton imgPlnt2 = (ImageButton)sender;
            ImageButton imgPlant1 = (ImageButton)imgPlnt2.Parent.FindControl("imgplant1");
            imgPlant1.Visible = true;
            imgPlnt2.Visible = false;

            //Page.RegisterStartupScript("clientscript", "<script>document.getElementById('" + imgPlant1.ClientID + "').focus();</script>");

            //int rowno = e.Item.ItemIndex;

            GridViewDataRowTemplateContainer gvFYI = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
            int rowno = gvFYI.ItemIndex;

            // for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.Items.Count - 1; rowCount++)
            for (int rowCount = rowno + 1; rowCount <= dgdOnRouteFYI.VisibleRowCount - 1; rowCount++)
            {
                ViewState["PlantSingleMain"] = null;
                ViewState["PlantSingle"] = null;
                Label lblPlantName = (Label)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Plant"], "lblPlantName");
                LinkButton lnkCategoryName = (LinkButton)dgdOnRouteFYI.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdOnRouteFYI.Columns["Category"], "lnkCategoryName");
            }
        }

        protected void lnkCategoryName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                // LinkButton lkb = (LinkButton)sender;
                //Label lblRecipientID = (Label)lkb.Parent.FindControl("lblRecipientID");
                if (e.CommandName == "Category_Link")
                {
                    //Response.Redirect("../Administration/AddConvertingMachine.aspx?MachineID=" + lblMachineID.Text + "&Mode=Edit" + "&CategoryID=" + lblCategoryID.Text + "&PlantID=" + lblPlantID.Text + "&MachineName=" + lblMachineName.Text)
                    Response.Redirect("~/Administration/AddOnRouteFYI.aspx?Mode=View&ID=" + e.CommandArgument);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void dgdOnRouteFYI_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillApprovarByCategory();
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }

        }


    }
}