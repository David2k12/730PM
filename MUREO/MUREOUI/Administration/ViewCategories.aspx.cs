using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOPROP;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Mail;
using System.Text;
using MUREOUI.Common;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Administration
{
    public partial class ViewCategories : System.Web.UI.Page
    {
        DataSet dsMachinesByCategory;
        string script;
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.SmartNavigation = true;
            if (!Page.IsPostBack)
            {
                FillMachinesByCategory();
                ViewState["username"] = cls.getUserFullName(cls.UserName.ToString().Trim());
            }
        }

        private void FillMachinesByCategory()
        {
            //  Dim i, j As Integer
            dsMachinesByCategory = new DataSet();
            // Creating object from ReportsBo class
            MachinesByCategoryBA objMachinesByCategoryBA = new MachinesByCategoryBA();
            //BusinessObject.MUREO.BusinessObject.MachinesByCategory objProjectsByCategory = new BusinessObject.MUREO.BusinessObject.MachinesByCategory();
            if (objMachinesByCategoryBA.FillMachinesByCategory(ref dsMachinesByCategory))
            {
                if ((dsMachinesByCategory == null))
                {

                }
                else if ((dsMachinesByCategory.Tables.Count == 0))
                {

                }
                else if ((dsMachinesByCategory.Tables[0].Rows.Count == 0))
                {

                }
                else
                {
                    // Preaparing temerory table for ProjectsBycategory
                    DataTable dtMachineByCategory = new DataTable();
                    DataRow drMachineByCategory;
                    dtMachineByCategory.Columns.Add("Category_ID");
                    dtMachineByCategory.Columns.Add("Category_Name");
                    dtMachineByCategory.Columns.Add("Plant_ID");
                    dtMachineByCategory.Columns.Add("Plant_Name");
                    dtMachineByCategory.Columns.Add("Machine_ID");
                    dtMachineByCategory.Columns.Add("Machine_Name");
                    // Below code for splitting data for treeview display and binding splitted data into temperory table
                    ArrayList arrayCategoryName = new ArrayList();
                    ArrayList arrayCategoryID = new ArrayList();
                    // First row item of category name
                    string strCategoryName = dsMachinesByCategory.Tables[0].Rows[0]["Category_Name"].ToString().Trim();
                    string strCategoryID = dsMachinesByCategory.Tables[0].Rows[0]["Category_ID"].ToString().Trim();
                    // Adding Category name to array
                    arrayCategoryName.Add(strCategoryName);
                    arrayCategoryID.Add(strCategoryID);
                    // Adding all categoory names(Without repitition)
                    for (int rowCount = 0; (rowCount
                                <= (dsMachinesByCategory.Tables[0].Rows.Count - 1)); rowCount++)
                    {
                        string strCategoryName1 = dsMachinesByCategory.Tables[0].Rows[rowCount]["Category_Name"].ToString().Trim();
                        string strCategoryID1 = dsMachinesByCategory.Tables[0].Rows[rowCount]["Category_ID"].ToString().Trim();
                        if (!arrayCategoryName.Contains(strCategoryName1))
                        {
                            arrayCategoryName.Add(strCategoryName1);
                            arrayCategoryID.Add(strCategoryID1);
                        }
                    }
                    // Based on Category name storing Category ID and Category name in to temperory table
                    for (int rowCategoryNameCount = 0; (rowCategoryNameCount
                                <= (arrayCategoryName.Count - 1)); rowCategoryNameCount++)
                    {
                        drMachineByCategory = dtMachineByCategory.NewRow();
                        drMachineByCategory["Category_ID"] = "";
                        drMachineByCategory["Category_Name"] = arrayCategoryName[rowCategoryNameCount];
                        drMachineByCategory["Plant_ID"] = "";
                        drMachineByCategory["Plant_Name"] = "";
                        drMachineByCategory["Machine_ID"] = "";
                        drMachineByCategory["Machine_Name"] = "";
                        dtMachineByCategory.Rows.Add(drMachineByCategory);
                        ArrayList arrayBrandName = new ArrayList();
                        ArrayList arrayBrandID = new ArrayList();
                        // Adding brand names(Without repitition) based on Category Name
                        for (int rowBrandCount = 0; (rowBrandCount
                                    <= (dsMachinesByCategory.Tables[0].Rows.Count - 1)); rowBrandCount++)
                        {
                            if ((arrayCategoryName[rowCategoryNameCount].ToString().ToUpper() == dsMachinesByCategory.Tables[0].Rows[rowBrandCount]["Category_Name"].ToString().ToUpper()))
                            {
                                string strBrandName = dsMachinesByCategory.Tables[0].Rows[rowBrandCount]["Plant_Name"].ToString().Trim();
                                string strBrandID = dsMachinesByCategory.Tables[0].Rows[rowBrandCount]["Plant_ID"].ToString().Trim();
                                if ((arrayBrandName.Count == 0))
                                {
                                    arrayBrandName.Add(strBrandName);
                                    arrayBrandID.Add(strBrandID);
                                }
                                if (!arrayBrandName.Contains(strBrandName))
                                {
                                    arrayBrandName.Add(strBrandName);
                                    arrayBrandID.Add(strBrandID);
                                }
                            }
                        }
                        // Based on Brand name storing Plant ID and Plant name in to temperory table
                        for (int rowBrandCount1 = 0; (rowBrandCount1
                                    <= (arrayBrandName.Count - 1)); rowBrandCount1++)
                        {
                            drMachineByCategory = dtMachineByCategory.NewRow();
                            drMachineByCategory["Category_ID"] = "";
                            drMachineByCategory["Category_Name"] = "";
                            drMachineByCategory["Plant_ID"] = "";
                            drMachineByCategory["Plant_Name"] = arrayBrandName[rowBrandCount1];
                            drMachineByCategory["Machine_ID"] = "";
                            drMachineByCategory["Machine_Name"] = "";
                            dtMachineByCategory.Rows.Add(drMachineByCategory);
                            for (int rowBrandCount2 = 0; (rowBrandCount2
                                        <= (dsMachinesByCategory.Tables[0].Rows.Count - 1)); rowBrandCount2++)
                            {
                                if (((arrayCategoryName[rowCategoryNameCount].ToString().ToUpper() == dsMachinesByCategory.Tables[0].Rows[rowBrandCount2]["Category_Name"].ToString().ToUpper())
                                            && (arrayBrandName[rowBrandCount1].ToString().ToUpper() == dsMachinesByCategory.Tables[0].Rows[rowBrandCount2]["Plant_Name"].ToString().ToUpper())))
                                {
                                    drMachineByCategory = dtMachineByCategory.NewRow();
                                    drMachineByCategory["Category_ID"] = arrayCategoryID[rowCategoryNameCount];
                                    drMachineByCategory["Category_Name"] = "";
                                    drMachineByCategory["Plant_ID"] = arrayBrandID[rowBrandCount1];
                                    drMachineByCategory["Plant_Name"] = "";
                                    drMachineByCategory["Machine_ID"] = dsMachinesByCategory.Tables[0].Rows[rowBrandCount2]["Machine_ID"].ToString().Trim();
                                    drMachineByCategory["Machine_Name"] = dsMachinesByCategory.Tables[0].Rows[rowBrandCount2]["Machine_Name"].ToString().Trim();
                                    dtMachineByCategory.Rows.Add(drMachineByCategory);
                                }
                            }
                        }
                    }
                    drgdMachinesByCategoryNew.DataSource = dtMachineByCategory;
                    drgdMachinesByCategoryNew.DataBind();
                }

            }


        }

        protected void imgConvertAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/AddConvertingMachine.aspx");
        }

        private void NoRecords()
        {
            script = "alert('No Results Found')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void imgExpnadAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            ViewState["Single"] = null;
            ViewState["SingleMain"] = null;
            ViewState["EOMain"] = null;
            ViewState["EOSingle"] = null;
            ViewState["EOSingleSub"] = null;
            FillMachinesByCategory();
        }

        protected void imgCollapseAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            ViewState["Single"] = null;
            ViewState["SingleMain"] = null;
            ViewState["EOMain"] = null;
            ViewState["EOSingle"] = null;
            ViewState["EOSingleSub"] = null;
            FillMachinesByCategory();
        }

        protected void deleteMachine(int MachineId)
        {
            int Result = -1; ;
            MachinesByCategoryBA objMachinesByCategoryBA = new MachinesByCategoryBA();
            clsSecurity objclsSecurity = new clsSecurity();            
            if (objMachinesByCategoryBA.DeleteMachine(MachineId, Convert.ToString(ViewState["username"]),ref Result))
            {
                Result = 0;
                DeleteOperationMessage(Result);
            }
            else
            {
                Result = -1;
                DeleteOperationMessage(Result);
            }


        }
        public void DeleteOperationMessage(int deleteResult)
        {
            string script;
            if ((deleteResult == 0))
            {
                script = ("alert('"
                            + (ConfigurationManager.AppSettings["DeletedSuccess"] + "');"));
                FillMachinesByCategory();
            }
            else
            {
                script = ("alert('"
                            + (ConfigurationManager.AppSettings["DeleteError"] + "');"));
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        protected void ImgRemoveMachine_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument != null)
                {
                    if (hdnResponse.Value == "Y")
                        deleteMachine(Convert.ToInt32(e.CommandArgument));
                }
                FillMachinesByCategory();
            }
            catch (Exception exc)
            {

            }
        }
        protected void drgdMachinesByCategoryNew_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {


            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {

                    ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Delete Machine"], "ImgRemoveMachine");
                    LinkButton lnkMachineName = (LinkButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lnkMachineName");
                    Label lblPlantID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblPlantID");
                    Label lblCategoryID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblCategoryID");
                    Label lblMachineID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblMachineID");
                    Label lblMachineName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblMachineName");

                    ImgRemoveMachine.Attributes.Add("onclick", ("javascript:return confirmConMachineDelete('" + (lnkMachineName.Text + "');")));

                    ImageButton imgCategory1 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "imgCategory1");
                    ImageButton imgCategory2 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "imgCategory2");
                    Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");

                    ImageButton imgPlant1 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "imgPlant1");
                    ImageButton imgPlant2 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "imgPlant2");
                    Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");

                    if (ViewState["Expand"] != null)
                    {
                        if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                        {

                            //imgCategory2.Visible = false;
                            //ImgRemoveMachine.Visible = false;
                            //lblCategoryID.Visible = false;
                            //imgPlant1.Visible = false;
                            //imgPlant2.Visible = false;


                            //if (string.IsNullOrEmpty(lblCategoryName.Text))
                            //{
                            //    e.Row.Visible = false;
                            //    imgCategory1.Visible = false;
                            //    imgCategory2.Visible = false;

                            //    if (string.IsNullOrEmpty(lblPlantName.Text))
                            //    {
                            //        ImgRemoveMachine.Visible = true;
                            //    }
                            //    else
                            //    {
                            //        ImgRemoveMachine.Visible = false;
                            //    }


                            //}

                            imgCategory2.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            lblCategoryID.Visible = false;

                            if (string.IsNullOrEmpty(lblCategoryName.Text))
                            {
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                ImgRemoveMachine.Visible = false;
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
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;
                            lblPlantID.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                imgPlant1.Visible = false;
                                imgPlant2.Visible = false;
                                if (string.IsNullOrEmpty(lblCategoryName.Text))
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
                                    ImgRemoveMachine.Visible = true;
                                }

                            }
                            lblMachineID.Visible = false;

                        }
                        else
                        {
                            imgCategory1.Visible = false;
                            imgCategory2.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            lblCategoryID.Visible = false;

                            //if (string.IsNullOrEmpty(lblCategoryName.Text))
                            //{
                            //    imgCategory1.Visible = false;
                            //    imgCategory2.Visible = false;
                            //    ImgRemoveMachine.Visible = false;

                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row.Cells[2] != null)
                                    e.Row.Cells[2].CssClass = "viscol";
                                if (e.Row.Cells[3] != null)
                                    e.Row.Cells[3].CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            }
                            //}
                            imgPlant1.Visible = false;
                            imgPlant2.Visible = false;

                            lblPlantID.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                //imgPlant1.Visible = false;
                                //imgPlant2.Visible = false;
                                if (string.IsNullOrEmpty(lblCategoryName.Text))
                                {
                                    ImgRemoveMachine.Visible = true;
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
                            if ((!string.IsNullOrEmpty(lblPlantName.Text)) && string.IsNullOrEmpty(lblCategoryName.Text))
                            {
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                imgPlant1.Visible = true;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = true;
                                ImgRemoveMachine.Visible = false;
                                lblMachineName.Visible = false;
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
                            if (string.IsNullOrEmpty(lblPlantName.Text) && (!string.IsNullOrEmpty(lblCategoryName.Text)))
                            {
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = true;
                                lblCategoryName.Visible = true;
                                ImgRemoveMachine.Visible = false;
                                lblMachineName.Visible = false;
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
                            lblMachineID.Visible = false;


                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            lblPlantName.Visible = false;
                            imgCategory1.Visible = true;
                            imgCategory2.Visible = false;
                            lblCategoryName.Visible = true;
                            lnkMachineName.Visible = false;
                            ImgRemoveMachine.Visible = false;

                            if (string.IsNullOrEmpty(lblCategoryName.Text))
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
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = false;
                                lblCategoryName.Visible = false;
                                lnkMachineName.Visible = false;
                                ImgRemoveMachine.Visible = false;

                            }
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblPlantName.Visible = false;
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            imgCategory1.Visible = false;
                            imgCategory2.Visible = true;
                            lblCategoryName.Visible = true;
                            lnkMachineName.Visible = false;
                            ImgRemoveMachine.Visible = false;
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
                            lblPlantName.Visible = false;
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            imgCategory1.Visible = false;
                            imgCategory2.Visible = false;
                            lblCategoryName.Visible = false;
                            lnkMachineName.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text) && string.IsNullOrEmpty(lblCategoryName.Text))
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
                            if ((!string.IsNullOrEmpty(lblPlantName.Text)) && string.IsNullOrEmpty(lblCategoryName.Text))
                            {
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                imgPlant1.Visible = true;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = true;
                                ImgRemoveMachine.Visible = false;
                                lblMachineName.Visible = false;
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
                        }
                        else
                        {
                            imgPlant2.Visible = false;
                            imgPlant1.Visible = false;
                            lblPlantName.Visible = false;
                            imgCategory1.Visible = false;
                            imgCategory2.Visible = false;
                            lblCategoryName.Visible = false;
                            lnkMachineName.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            if ((!string.IsNullOrEmpty(lblCategoryName.Text)) && string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                imgCategory1.Visible = true;
                                imgCategory2.Visible = false;
                                lblCategoryName.Visible = true;
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
                            if (string.IsNullOrEmpty(lblCategoryName.Text) && (!string.IsNullOrEmpty(lblPlantName.Text)))
                            {
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
                            if (string.IsNullOrEmpty(lblCategoryName.Text) && string.IsNullOrEmpty(lblPlantName.Text))
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
                        }
                        if (ViewState["EOMain"] != null)
                        {
                            if (cls.IsExists(Convert.ToString(ViewState["EOMain"]), Convert.ToString(e.VisibleIndex)))
                            {
                                lblPlantName.Visible = true;
                                imgPlant2.Visible = true;
                                imgPlant1.Visible = false;
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                lblCategoryName.Visible = false;
                                lnkMachineName.Visible = false;
                                ImgRemoveMachine.Visible = false;
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
                            else if (cls.IsExists(Convert.ToString(ViewState["EOSingle"]), Convert.ToString(e.VisibleIndex)))
                            {
                                lblPlantName.Visible = false;
                                imgPlant2.Visible = false;
                                imgPlant1.Visible = false;
                                imgCategory1.Visible = false;
                                imgCategory2.Visible = false;
                                lblCategoryName.Visible = false;
                                lnkMachineName.Visible = false;
                                ImgRemoveMachine.Visible = false;
                                lnkMachineName.Visible = true;
                                ImgRemoveMachine.Visible = true;
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
                                if (string.IsNullOrEmpty(lnkMachineName.Text))
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
                            }
                            else if (cls.IsExists(Convert.ToString(ViewState["EOSingleSub"]), Convert.ToString(e.VisibleIndex)))
                            {
                                imgPlant1.Visible = true;
                                imgPlant2.Visible = false;
                                lblPlantName.Visible = true;
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
                                if (string.IsNullOrEmpty(lblCategoryName.Text) && string.IsNullOrEmpty(lblPlantName.Text))
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
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }



        }

        protected void drgdMachinesByCategoryNew_PageIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                FillMachinesByCategory();
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgCategory1_Command(object sender, CommandEventArgs e)
        {
            FillMachinesByCategory();
            ViewState["Expand"] = null;
            ImageButton imgCategory1 = (ImageButton)sender;
            ImageButton imgCategory2 = (ImageButton)imgCategory1.Parent.FindControl("imgCategory2");
            string st = string.Empty;
            imgCategory2.Visible = true;
            imgCategory1.Visible = false;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgCategory1.Parent;
            int rowno = gvd.ItemIndex;
            ViewState["Category_ID"] = Convert.ToString(e.CommandArgument);
            ViewState["SingleMain"] = Convert.ToString(rowno);
            for (int rowCount = rowno + 1; rowCount <= drgdMachinesByCategoryNew.VisibleRowCount - 1; rowCount++)
            {
                Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");
                Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");
                Label lblPlantID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblPlantID");
                ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Delete Machine"], "ImgRemoveMachine");
                ImageButton imgPlant1 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "imgPlant1");
                ImageButton imgPlant2 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "imgPlant2");
                if (string.IsNullOrEmpty(lblCategoryName.Text))
                {

                    if (!(string.IsNullOrEmpty(lblPlantName.Text)))
                    {
                        st = st + Convert.ToString(rowCount) + ",";
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                        gvdc.Visible = true;

                        imgPlant1.Visible = true;
                        imgPlant2.Visible = false;
                        lblPlantID.Visible = false;
                        if (!(string.IsNullOrEmpty(lblPlantName.Text)))
                        {
                            ImgRemoveMachine.Visible = false;
                        }
                        else
                        {
                            ImgRemoveMachine.Visible = true;
                        }
                    }
                    else
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                        gvdc.Visible = false;

                    }
                }
                else
                {
                    break;
                }
            }
            ViewState["Single"] = st.TrimEnd(new char[] { ',' });

        }

        protected void imgCategory2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                FillMachinesByCategory();

                ViewState["Expand"] = null;
                ViewState["SingleMain"] = null;
                ViewState["Single"] = null;
                ImageButton imgCategory2 = (ImageButton)sender;
                ImageButton imgCategory1 = (ImageButton)imgCategory2.Parent.FindControl("imgCategory1");

                imgCategory2.Visible = false;
                imgCategory1.Visible = true;

                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgCategory2.Parent;
                int rowno = gvd.ItemIndex;
                for (int rowCount = rowno + 1; rowCount <= drgdMachinesByCategoryNew.VisibleRowCount - 1; rowCount++)
                {


                    Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");
                    Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");
                    Label lblPlantID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblPlantID");

                    ImageButton imgPlant1 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "imgPlant1");
                    ImageButton imgPlant2 = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "imgPlant2");
                    ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Delete Machine"], "ImgRemoveMachine");
                    ImgRemoveMachine.Visible = false;



                    if (string.IsNullOrEmpty(lblCategoryName.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                        gvdc.Visible = false;



                    }
                    else
                    {
                        return;
                    }



                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                string st = string.Empty;
                string sttemp = string.Empty;
                ImageButton imgPlant1 = (ImageButton)sender;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");

                imgPlant1.Visible = false;
                imgPlant2.Visible = true;

                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["EOMain"] = Convert.ToString(rowno);


                for (int rowCount = rowno + 1; rowCount <= drgdMachinesByCategoryNew.VisibleRowCount - 1; rowCount++)
                {
                    Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");
                    Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");
                    Label lblMachineName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblMachineName");
                    Label lblMachineID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblMachineID");

                    //Label lblCategoryName = ((Label)(drgdMachinesByCategory.Items(rowCount).FindControl("lblCategoryName")));
                    //Label lblPlantName = ((Label)(drgdMachinesByCategory.Items(rowCount).FindControl("lblPlantName")));
                    //Label lblMachineName = ((Label)(drgdMachinesByCategory.Items(rowCount).FindControl("lblMachineName")));
                    //Label lblMachineID = ((Label)(drgdMachinesByCategory.Items(rowCount).FindControl("lblMachineID")));
                    if (((lblPlantName.Text == "") && (lblCategoryName.Text == "")))
                    {
                        if (string.IsNullOrEmpty(sttemp))
                        {
                            if (!(lblMachineName.Text == ""))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                                gvdc.Visible = true;
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                                gvdc.Visible = false;

                            }
                        }
                    }
                    else if (((!string.IsNullOrEmpty(lblPlantName.Text)) && (string.IsNullOrEmpty(lblCategoryName.Text))))
                    {
                        sttemp = sttemp + Convert.ToString(rowCount) + ",";
                    }
                    else if (((string.IsNullOrEmpty(lblPlantName.Text)) && (!string.IsNullOrEmpty(lblCategoryName.Text))))
                    {
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                ViewState["EOSingle"] = st.TrimEnd(new char[] { ',' });
                ViewState["EOSingleSub"] = sttemp.TrimEnd(new char[] { ',' });
                //for (int rowCount = rowno + 1; rowCount <= drgdMachinesByCategoryNew.VisibleRowCount - 1; rowCount++)
                //{
                //    st = st + Convert.ToString(rowCount) + ",";
                //    ViewState["Single"] = st.TrimEnd(new char[] { ',' });

                //    Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");
                //    Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");
                //    Label lblMachineName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblMachineName");
                //    Label lblMachineID = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Machine"], "lblMachineID");





                //    if ( (string.IsNullOrEmpty(lblCategoryName.Text)) && (string.IsNullOrEmpty(lblPlantName.Text)))
                //    {
                //        if (string.IsNullOrEmpty(lblMachineName.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblMachineName.Parent.Parent.Parent;
                //            gvdc.Visible = true;
                //            lblMachineID.Visible = false;
                //        }
                //        else
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblMachineName.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }




                //    }
                //    else
                //    {
                //        return;
                //    }



                //}
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
                ViewState["EOSingle"] = null;
                ViewState["EOMain"] = null;
                ImageButton imgPlant2 = (ImageButton)sender;
                ImageButton imgPlant1 = (ImageButton)imgPlant2.Parent.FindControl("imgPlant1");
                imgPlant1.Visible = true;
                imgPlant2.Visible = false;

                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvd.ItemIndex;
                //for (int rowCount = rowno + 1; rowCount <= drgdMachinesByCategoryNew.VisibleRowCount - 1; rowCount++)
                //{
                //    ViewState["Single"] = null;
                //    ViewState["SingleMain"] = null;

                //    Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");
                //    Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");
                //    if ((string.IsNullOrEmpty(lblCategoryName.Text)) && (string.IsNullOrEmpty(lblPlantName.Text)))
                //    {
                //        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                //        gvdc.Visible = false;

                //    }
                //    else
                //    {
                //        return;
                //    }


                //}
                for (int rowCount = (rowno + 1); (rowCount <= (drgdMachinesByCategoryNew.VisibleRowCount - 1)); rowCount++)
                {
                    Label lblCategoryName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Category"], "lblCategoryName");
                    Label lblPlantName = (Label)drgdMachinesByCategoryNew.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByCategoryNew.Columns["Plant"], "lblPlantName");
                    if (((lblCategoryName.Text == "") && (lblPlantName.Text == "")))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                        gvdc.Visible = false;
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

        protected void lnkMachineName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    LinkButton lblCategoryID = (LinkButton)sender;

                    Response.Redirect("../Administration/View_ConvertMachine.aspx?MachineID="
                                    + lblCategoryID.Attributes["Machine_ID"] + "&Mode=Edit" + "&CategoryID="
                                    + Convert.ToString(e.CommandName) + "&PlantID="
                                    + Convert.ToString(e.CommandArgument) + "&MachineName=" + lblCategoryID.Attributes["Machine_Name"]);
                }

            }
            catch (Exception exc)
            {


            }

        }


    }
}