using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using MUREOUI.Common;
using MUREOBAL;
using System.Data.SqlClient;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Administration
{
    public partial class ViewBrandSegments : System.Web.UI.Page
    {
        DataSet dsBrandSeg = null;
        string strScript = string.Empty;
        clsSecurity objclsSecurity = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.SmartNavigation = true;
            if (!Page.IsPostBack)
            {
                fillbrandseg();
            }

        }

        protected void fillbrandseg()
        {
            clsBrandSegmentBO objBrandSeg = null;
            try
            {
                dsBrandSeg = new DataSet();

                //Creating object from ReportsBo class
                objBrandSeg = new clsBrandSegmentBO();
               // dsBrandSeg = objBrandSeg.FillAllCategoryBrandSegment;
                if (objBrandSeg.FillAllCategoryBrandSegment(ref dsBrandSeg))
                {
                    if (dsBrandSeg == null)
                    {
                    }
                    else if (dsBrandSeg.Tables.Count == 0)
                    {
                    }
                    else if (dsBrandSeg.Tables[0].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        DataTable dtBrandSeg = new DataTable();
                        DataRow drBrandSeg = null;
                        dtBrandSeg.Columns.Add("Brand_Segment_ID");
                        dtBrandSeg.Columns.Add("Brand_Segment_Name");
                        dtBrandSeg.Columns.Add("Category_ID");
                        dtBrandSeg.Columns.Add("Category_Name");

                        ArrayList arrayCategoryName = new ArrayList();
                        ArrayList arrayCategoryID = new ArrayList();

                        string strCategoryName = Convert.ToString(dsBrandSeg.Tables[0].Rows[0].ItemArray[3]);
                        string strCategoryID = Convert.ToString(dsBrandSeg.Tables[0].Rows[0].ItemArray[2]);

                        arrayCategoryName.Add(strCategoryName);
                        arrayCategoryID.Add(strCategoryID);

                        for (int rowCount = 0; rowCount <= dsBrandSeg.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            string strCategoryName1 = Convert.ToString(dsBrandSeg.Tables[0].Rows[rowCount].ItemArray[3]);
                            string strCategoryID1 = Convert.ToString(dsBrandSeg.Tables[0].Rows[rowCount].ItemArray[2]);

                            if (!(arrayCategoryName.Contains(strCategoryName1)))
                            {
                                arrayCategoryName.Add(strCategoryName1);
                                arrayCategoryID.Add(strCategoryID1);
                            }
                        }
                        for (int rowCategoryNameCount = 0; rowCategoryNameCount <= arrayCategoryName.Count - 1; rowCategoryNameCount++)
                        {
                            drBrandSeg = dtBrandSeg.NewRow();
                            drBrandSeg["Category_ID"] = arrayCategoryID[rowCategoryNameCount];
                            drBrandSeg["Category_Name"] = arrayCategoryName[rowCategoryNameCount];
                            drBrandSeg["Brand_Segment_ID"] = "";
                            drBrandSeg["Brand_Segment_Name"] = "";
                            dtBrandSeg.Rows.Add(drBrandSeg);
                            ArrayList arrayBrandName = new ArrayList();
                            ArrayList arrayBrandID = new ArrayList();


                            for (int rowBrandCount = 0; rowBrandCount <= dsBrandSeg.Tables[0].Rows.Count - 1; rowBrandCount++)
                            {
                                if (Convert.ToString(arrayCategoryName[rowCategoryNameCount]) == Convert.ToString(dsBrandSeg.Tables[0].Rows[rowBrandCount][3]))
                                {
                                    string strBrandName = Convert.ToString(dsBrandSeg.Tables[0].Rows[rowBrandCount][1]);
                                    string strBrandID = Convert.ToString(dsBrandSeg.Tables[0].Rows[rowBrandCount][0]);

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
                            for (int rowBrandCount1 = 0; rowBrandCount1 <= arrayBrandName.Count - 1; rowBrandCount1++)
                            {
                                drBrandSeg = dtBrandSeg.NewRow();
                                drBrandSeg["Category_ID"] = arrayCategoryID[rowCategoryNameCount];
                                drBrandSeg["Category_Name"] = "";
                                drBrandSeg["Brand_Segment_ID"] = arrayBrandID[rowBrandCount1];
                                drBrandSeg["Brand_Segment_Name"] = arrayBrandName[rowBrandCount1];
                                dtBrandSeg.Rows.Add(drBrandSeg);
                            }
                        }
                        drgdBrandSegment.DataSource = dtBrandSeg;
                        drgdBrandSegment.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsBrandSeg = null;
                objclsSecurity = null;
                objBrandSeg = null;
            }
        }


        protected void deleteBrandSegment(int BrandSegId)
        {
            int Result = 0;
            clsBrandSegmentBO objclsBrandSegmentBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            try
            {
                objclsSecurity = new clsSecurity();
                objclsBrandSegmentBO = new clsBrandSegmentBO();
                //Result = clsBrandSegmentBO.DeleteBrandSegment(BrandSegId, objclsSecurity.UserName, "Y");
                if (objclsBrandSegmentBO.DeleteBrandSegment(BrandSegId, objclsSecurity.UserName, "Y", ref paramOut))
                {
                    Result = Convert.ToInt32(paramOut[0].Value);
                    if (Result == 0)
                    {
                        //objclsSecurity = new clsSecurity();
                        //Me.DeleteOperationMessage(Result)
                        //string tempStr = null;
                        //script = "confirmBrandSegDelete('" + BrandSegId + "','" + System.Security.UserName + "','0' ); ";
                        //popResult=window.showModalDialog('ApproveYesNo.aspx?EOID='+EoID+'&Type=A',null,'dialogHeight:200px;dialogWidth:400px');
                        //strScript = "confirmBrandSegDelete('" + BrandSegId + "','" + objclsSecurity.UserName + "','0' ); ";
                        strScript = "confirmBrandSegDelete('" + BrandSegId + "','" + objclsSecurity.UserName + "','0' ); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);

                    }
                    else
                    {
                        //script = "confirmBrandSegDelete('" & BrandSegId & "','" & Security.UserName & "','1' ); "
                        //script = "alert('This Brand segment is associated with few projects.'+ '\\n' + 'Please update respective projects information with other brands before deleting.'); ";
                        //strScript = "alert('This Brand segment is associated with few projects.'+ '\\n' + 'Please update respective projects information with other brands before deleting.'); ";
                        strScript = "alert('This Brand segment is associated with few projects.'+ '\\n' + 'Please update respective projects information with other brands before deleting.'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);

                    }
                    //Page.RegisterStartupScript("db_error_message", script);
                    //ClientScript.RegisterStartupScript(this.GetType(), "db_error_message", strScript);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsSecurity = null;
                objclsBrandSegmentBO = null;
            }

        }

        protected void DeleteOperationMessage(int deleteResult)
        {
            //string script = null;
            if (deleteResult == 0)
            {
              //  script = "alert('" + ConfigurationSettings.AppSettings["DeletedSuccess"] + "');";
                strScript = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "'); ";
                
                fillbrandseg();
            }
            else if (deleteResult > 0)
            {
                //script = "alert('" & ConfigurationSettings.AppSettings("BrandMsg") & "'); "
                strScript = "alert('This Brand segment is associated with few projects.'+ '\\n' + 'Please update respective projects information with other brands before deleting.'); ";
            }
            else
            {
                //script = "alert('" + ConfigurationSettings.AppSettings("DeleteError") + "'); ";
                strScript = "alert('" + ConfigurationManager.AppSettings["DeleteError"] + "'); ";
            }
            //Page.RegisterStartupScript("db_error_message", script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }

        protected void imgAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/MaintainBrandSegments.aspx?CatID=Add");
        }

        protected void imgExpnadAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            fillbrandseg();
        }

        protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            fillbrandseg();
        }

        protected void lnkbrandSegmentName_Command(object sender, CommandEventArgs e)
        {
            try
            {

                LinkButton lkb = (LinkButton)sender;
                Label lblCategoryID = (Label)lkb.Parent.FindControl("lblCategoryID");                
                Label lblCName = (Label)lkb.Parent.FindControl("lblCName");

                Response.Redirect("~/Administration/ViewBrandSegment.aspx?CatID=" + lblCategoryID.Text + "&Brandname=" + lkb.Text + "&CatName=" + lblCName.Text);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void drgdBrandSegment_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            clsSecurity objclsSecurity = new clsSecurity();

            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    Label lblcategoryName = (Label)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Category"], "lblCategoryName");
                    ImageButton imgCat1 = (ImageButton)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Category"], "imgCategory1");
                    ImageButton imgCat2 = (ImageButton)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Category"], "imgCategory2");

                    Label lblCatId = (Label)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lblCategoryID");
                    Label lblcName = (Label)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lblCName");
                    Label lblBrandsegmentid = (Label)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lblBrandSegmentID");
                    LinkButton lnkcName = (LinkButton)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lnkbrandSegmentName");

                    ImageButton ImgRemoveBrandSegment = (ImageButton)drgdBrandSegment.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdBrandSegment.Columns["Delete Brand"], "ImgRemoveBrandSegment");
                    if (lblcategoryName != null)
                    {
                        if (ViewState["Expand"] != null)
                        {
                            if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                            {

                                imgCat2.Visible = false;
                                imgCat1.Visible = true;
                                lblcategoryName.Visible = true;
                                lblcName.Visible = false;
                                lnkcName.Visible = true;
                                lblBrandsegmentid.Visible = false;
                                lblCatId.Visible = false;
                                ImgRemoveBrandSegment.Visible = false;

                                if (string.IsNullOrEmpty(lblcategoryName.Text))
                                {                                 
                                    if (e.Row.Cells.Count > 1)
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "hiddencol";
                                        if (e.Row.Cells[1] != null)
                                            e.Row.Cells[1].CssClass = "hiddencol";
                                        if (e.Row.Cells[2] != null)
                                            e.Row.Cells[2].CssClass = "hiddencol";
                                        if (e.Row != null)
                                            e.Row.CssClass = "hiddencol";
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "hiddencol";
                                    } 
                                    imgCat1.Visible = false;
                                    imgCat2.Visible = false;
                                    lblcategoryName.Visible = false;
                                    lblCatId.Visible = false;
                                    lblcName.Visible = false;
                                    lblBrandsegmentid.Visible = false;
                                    lnkcName.Visible = false;
                                    ImgRemoveBrandSegment.Visible = false;
                                    //imgDelBrandSegment.Visible = false;
                                }

                            }
                            else
                            {

                                imgCat2.Visible = true;
                                imgCat1.Visible = false;
                                lblCatId.Visible = false;
                                lblcategoryName.Visible = true;
                                //lblcName.Visible = false;
                                //lnkcName.Visible = false;
                                ImgRemoveBrandSegment.Visible = false;
                                if (string.IsNullOrEmpty(lblcategoryName.Text))
                                {
                                    imgCat2.Visible = false;
                                    imgCat1.Visible = false;
                                    ImgRemoveBrandSegment.Visible = true;
                                    e.Row.Visible = true;
                                    //else
                                    //{
                                    //    if (e.Row.Cells[0] != null)
                                    //        e.Row.Cells[0].CssClass = "viscol";
                                    //} 
                                }
                            }
                        }
                        else
                        {
                            if (ViewState["Single"] == null)
                            {
                                imgCat2.Visible = false;
                                imgCat1.Visible = true;
                                lblcategoryName.Visible = true;
                                lblBrandsegmentid.Visible = false;
                                lnkcName.Visible = false;
                                ImgRemoveBrandSegment.Visible = false;
                                if (string.IsNullOrEmpty(lblcategoryName.Text))
                                {
                                    //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                    imgCat2.Visible = false;
                                    imgCat1.Visible = false;
                                    if (e.Row.Cells.Count > 1)
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "hiddencol";
                                        if (e.Row.Cells[1] != null)
                                            e.Row.Cells[1].CssClass = "hiddencol";
                                        if (e.Row.Cells[2] != null)
                                            e.Row.Cells[2].CssClass = "hiddencol";
                                        if (e.Row != null)
                                            e.Row.CssClass = "hiddencol";
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "hiddencol";
                                    }     
                                    lblBrandsegmentid.Visible = false;
                                    lblcategoryName.Visible = false;
                                    lnkcName.Visible = false;
                                    ImgRemoveBrandSegment.Visible = false;
                                }
                            }
                            else if (objclsSecurity.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                            {
                                lblcategoryName.Visible = true;
                                imgCat2.Visible = true;
                                imgCat1.Visible = false;
                                ImgRemoveBrandSegment.Visible = false;
                                lblcName.Visible = false;
                                lblCatId.Visible = false;
                                e.Row.Visible = true;
                                //else
                                //{
                                //    if (e.Row.Cells[0] != null)
                                //        e.Row.Cells[0].CssClass = "viscol";
                                //} 

                            }
                            else if (objclsSecurity.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                            {                                
                                imgCat2.Visible = false;
                                imgCat1.Visible = false;
                                lblcategoryName.Visible = false;
                                ImgRemoveBrandSegment.Visible = false;
                                if (string.IsNullOrEmpty(lblcategoryName.Text))
                                {
                                    e.Row.Visible = true;
                                    //else
                                    //{
                                    //    if (e.Row.Cells[0] != null)
                                    //        e.Row.Cells[0].CssClass = "viscol";
                                    //} 
                                    ImgRemoveBrandSegment.Visible = true;
                                    lnkcName.Visible = true;
                                }
                                                                                               
                            }
                            else
                            {
                                e.Row.Visible = false;
                                imgCat2.Visible = false;
                                imgCat1.Visible = false;
                                lblcategoryName.Visible = false;
                                ImgRemoveBrandSegment.Visible = false;
                                lblcName.Visible = false;
                                lblCatId.Visible = false;
                                lnkcName.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                } 
                                if (!string.IsNullOrEmpty(lblcategoryName.Text))
                                {
                                    imgCat1.Visible = true;
                                    imgCat2.Visible = false;
                                    lblcategoryName.Visible = true;
                                    e.Row.Visible = true;
                                    if (e.Row.Cells.Count > 1)
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                        if (e.Row.Cells[1] != null)
                                            e.Row.Cells[1].CssClass = "viscol";
                                        if (e.Row.Cells[2] != null)
                                            e.Row.Cells[2].CssClass = "viscol";
                                        if (e.Row != null)
                                            e.Row.CssClass = "viscol";
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                    } 
                                    //else
                                    //{
                                    //    if (e.Row.Cells[0] != null)
                                    //        e.Row.Cells[0].CssClass = "viscol";
                                    //} 
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
            }
        }

        protected void imgCategory1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                string st = string.Empty;
                ImageButton imgCat1 = (ImageButton)sender;
                ImageButton imgCategory2 = (ImageButton)imgCat1.Parent.FindControl("imgCategory2");
                imgCategory2.Visible = true;
                imgCat1.Visible = false;
                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgCategory2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgCat1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);

                for (int rowCount = rowno + 1; rowCount <= drgdBrandSegment.VisibleRowCount - 1; rowCount++)
                {
                   
                   
                    Label lblCategoryName = (Label)drgdBrandSegment.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdBrandSegment.Columns["Category"], "lblCategoryName");

                    LinkButton lnkbrandSegmentName = (LinkButton)drgdBrandSegment.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lnkbrandSegmentName");

                    Label lblBrandSegmentID = (Label)drgdBrandSegment.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lblBrandSegmentID");
                    ImageButton ImgRemoveBrandSegment = (ImageButton)drgdBrandSegment.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdBrandSegment.Columns["Delete Brand"], "ImgRemoveBrandSegment");
                    if (lblCategoryName != null)
                    {
                        if (string.IsNullOrEmpty(lblCategoryName.Text))
                        {
                            if (!string.IsNullOrEmpty(lnkbrandSegmentName.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                //drgdBrandSegment.Items(rowCount).Visible = true;
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lnkbrandSegmentName.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                lblBrandSegmentID.Visible = false;
                                lnkbrandSegmentName.Visible = true;
                                ImgRemoveBrandSegment.Visible = true;
                            }
                            else
                            {
                                //drgdBrandSegment.Items(rowCount).Visible = true;
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lnkbrandSegmentName.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                ImgRemoveBrandSegment.Visible = true;
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

        protected void imgCategory2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            ImageButton imgCategory2 = (ImageButton) sender;
            //imgCategory2 = (ImageButton)e.Item.FindControl("imgCategory2");
            //imgCategory2.Visible = false;
            //ImageButton imgCategory1 = default(ImageButton);
            //imgCategory1 = (ImageButton)e.Item.FindControl("imgCategory1");
            //imgCategory1.Visible = true;

            ImageButton imgCategory1 = (ImageButton)imgCategory2.Parent.FindControl("imgCategory1");
            imgCategory1.Visible = true;
            imgCategory2.Visible = false;
            //ImageButton ImgRemoveBrandSegment = default(ImageButton);
            //ImgRemoveBrandSegment = (ImageButton)e.Item.FindControl("ImgRemoveBrandSegment");
            //ImgRemoveBrandSegment.Visible = false;

            //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgCategory1.ClientID + "').focus();");
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgCategory2.Parent;
            //int rowno = e.Item.ItemIndex;
            int rowno = gvd.ItemIndex;
            //for (int rowCount = rowno + 1; rowCount <= drgdBrandSegment.Items.Count - 1; rowCount++)
            for (int rowCount = rowno + 1; rowCount <= drgdBrandSegment.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;
                //Label lblCategoryName = (Label)drgdBrandSegment.Items(rowCount).FindControl("lblCategoryName");
                //LinkButton lnkbrandSegmentName = (LinkButton)drgdBrandSegment.Items(rowCount).FindControl("lnkbrandSegmentName");
                //Dim lnkprojectName As LinkButton = CType(drgdBrandSegment.Items(rowCount).FindControl("lnkprojectName"), LinkButton)

                Label lblCategoryName = (Label)drgdBrandSegment.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdBrandSegment.Columns["Category"], "lblCategoryName");
                LinkButton lnkbrandSegmentName = (LinkButton)drgdBrandSegment.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdBrandSegment.Columns["Brand Segment"], "lnkbrandSegmentName");            
                
                if (string.IsNullOrEmpty(lblCategoryName.Text))
                {
                    //drgdBrandSegment.Items(rowCount).Visible = false;
                    GridViewTableDataRow gvdc = (GridViewTableDataRow)lblCategoryName.Parent.Parent.Parent;
                    gvdc.Visible = true;
                }
                else
                {
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

        }

        protected void drgdBrandSegment_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillbrandseg();
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
            

        }

        protected void ImgRemoveBrandSegment_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "RemoveBrandSegment")
            {
                if (e.CommandArgument != null)
                {
                    if (Convert.ToString(e.CommandArgument) != "")
                        deleteBrandSegment(Convert.ToInt32(e.CommandArgument));

                }
            }
        }
    }
}