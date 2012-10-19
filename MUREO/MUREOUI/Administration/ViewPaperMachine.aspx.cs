using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;
using System.Collections;
using System.Configuration;
using MUREOUI.Common;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Administration
{
    public partial class ViewPaperMachine : System.Web.UI.Page
    {
        MachinesByCategory MCcat = new MachinesByCategory();
        clsSecurity cls = new clsSecurity();
        #region "Declarations"
        DataSet dsMachinesByPlant;
        #endregion
        string script;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillMachinesByPlant();
            }
        }
        #region "Functions"
        //
        //
        //  ************************************************
        //Name   	    :	FillMachinesByPlant
        //Written BY	    :	Srilakshmi
        //parameters     :	None
        //Purpose	    :   Fill Datagris and Splitting Data for Tree View
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/23/07                 Srilakshmi            1.0           created
        //***************************************************
        //

        protected void FillMachinesByPlant()
        {
            dsMachinesByPlant = new DataSet();

            if (MCcat.FillMachinesByPlant(ref dsMachinesByPlant))
            {

                if (dsMachinesByPlant == null)
                {
                    NoRecords();
                }
                else if (dsMachinesByPlant.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsMachinesByPlant.Tables[0].Rows.Count == 0)
                {
                    NoRecords();

                }
                else
                {
                    DataTable dtMachineByPlant = new DataTable();
                    DataRow drMachineByPlant = null;

                    dtMachineByPlant.Columns.Add("Plant_ID");
                    dtMachineByPlant.Columns.Add("Plant_Name");
                    dtMachineByPlant.Columns.Add("Machine_ID");
                    dtMachineByPlant.Columns.Add("Machine_Name");

                    //Below code for splitting data for treeview display and binding splitted data into temperory table
                    ArrayList arrayPlantName = new ArrayList();
                    ArrayList arrayPlantID = new ArrayList();
                    string strPlantName = null;
                    string strPlantID = null;
                    //First row item of Plant name
                    strPlantID = Convert.ToString(dsMachinesByPlant.Tables[0].Rows[0]["Plant_ID"]);
                    strPlantName = Convert.ToString(dsMachinesByPlant.Tables[0].Rows[0]["Plant_Name"]);

                    //Adding Plantname to array
                    arrayPlantName.Add(strPlantName);
                    arrayPlantID.Add(strPlantID);

                    //Adding all Plant names(Without repitition)

                    for (int rowCount = 0; rowCount <= dsMachinesByPlant.Tables[0].Rows.Count - 1; rowCount++)
                    {
                        string strPlantName1 = Convert.ToString(dsMachinesByPlant.Tables[0].Rows[rowCount]["Plant_Name"]);
                        string strPlantID1 = Convert.ToString(dsMachinesByPlant.Tables[0].Rows[rowCount]["Plant_ID"]);


                        if (!(arrayPlantName.Contains(strPlantName1)))
                        {
                            arrayPlantName.Add(strPlantName1);
                            arrayPlantID.Add(strPlantID1);

                        }
                    }




                    //Based on Plant name storing Plant ID and Plant name in to temperory table

                    for (int rowFunctionNameCount = 0; rowFunctionNameCount <= arrayPlantName.Count - 1; rowFunctionNameCount++)
                    {
                        drMachineByPlant = dtMachineByPlant.NewRow();
                        drMachineByPlant["Plant_ID"] = arrayPlantID[rowFunctionNameCount];
                        drMachineByPlant["Plant_Name"] = arrayPlantName[rowFunctionNameCount];
                        drMachineByPlant["Machine_ID"] = "";
                        drMachineByPlant["Machine_Name"] = "";

                        dtMachineByPlant.Rows.Add(drMachineByPlant);

                        ArrayList arrayMachineName = new ArrayList();
                        ArrayList arrayMachineID = new ArrayList();



                        for (int rowApproverCount = 0; rowApproverCount <= dsMachinesByPlant.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {

                            if (Convert.ToString(arrayPlantName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsMachinesByPlant.Tables[0].Rows[rowApproverCount]["Plant_Name"]).Trim().ToUpper())
                            {
                                string strMachinetName = Convert.ToString(dsMachinesByPlant.Tables[0].Rows[rowApproverCount]["Machine_Name"]);
                                string strMachineID = Convert.ToString(dsMachinesByPlant.Tables[0].Rows[rowApproverCount]["Machine_ID"]);


                                arrayMachineName.Add(strMachinetName);
                                arrayMachineID.Add(strMachineID);


                            }

                        }




                        for (int rowApproverCount1 = 0; rowApproverCount1 <= arrayMachineName.Count - 1; rowApproverCount1++)
                        {
                            drMachineByPlant = dtMachineByPlant.NewRow();
                            drMachineByPlant["Plant_ID"] = arrayPlantID[rowFunctionNameCount];
                            drMachineByPlant["Plant_Name"] = "";
                            drMachineByPlant["Machine_Name"] = arrayMachineName[rowApproverCount1];
                            drMachineByPlant["Machine_ID"] = arrayMachineID[rowApproverCount1];

                            dtMachineByPlant.Rows.Add(drMachineByPlant);


                        }
                    }
                    DataColumn dc = new DataColumn("Index");
                    dtMachineByPlant.Columns.Add(dc);
                    Int32 ind = 0;
                    foreach (DataRow dr in dtMachineByPlant.Rows)
                    {

                        dr["Index"] = ind;
                        ind++;
                    }


                    drgdMachinesByPlant.DataSource = dtMachineByPlant;
                    drgdMachinesByPlant.DataBind();
                }
            }

        }
        protected void ImgRemoveMachine_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (hdnresponse.Value == "Y")
                {
                    if (e.CommandArgument != null)
                        deletePaperMachine(Convert.ToInt32(e.CommandArgument));
                    //Delete the approver
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
                LinkButton lnkMachineName = (LinkButton)sender;

                if (e.CommandName != null)
                {
                    Response.Redirect("~/Administration/View_PaperMachine.aspx?PlantID=" + Convert.ToString(e.CommandName) + "&Mode=" + "Edit" + "&Machine=" + lnkMachineName.Text + "&MachineID=" + Convert.ToString(e.CommandArgument));
                }
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
                ImageButton imgPlant1 = (ImageButton)sender;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");
                imgPlant1.Visible = true;
                imgPlant2.Visible = false;

                //        ImageButton ImgRemoveMachine = default(ImageButton);
                GridViewDataRowTemplateContainer gvFYI = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvFYI.ItemIndex;

                //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant1.ClientID + "').focus();");

                //        int rowno = e.Item.ItemIndex;


                for (int rowCount = rowno + 1; rowCount <= drgdMachinesByPlant.VisibleRowCount - 1; rowCount++)
                {
                    ViewState["Single"] = null;
                    ViewState["SingleMain"] = null;
                    LinkButton lnkMachineName = (LinkButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Machine"], "lnkMachineName");
                    ImageButton imgRegion1 = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Region"], "imgPlant1");
                    ImageButton imgRegion2 = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Region"], "imgPlant2");
                    Label lblPlantName = (Label)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Plant"], "lblPlantName");
                    ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Delete Machine"], "ImgRemoveMachine");

                    if (lblPlantName != null)
                    {

                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                            lnkMachineName.Visible = false;
                            lblPlantName.Visible = false;
                            imgRegion1.Visible = false;
                            imgRegion2.Visible = false;
                            ImgRemoveMachine.Visible = false;
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
        protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton imgPlant1 = (ImageButton)sender;
                //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2"); ;
                string st = string.Empty;
                imgPlant1.Visible = false;
                imgPlant2.Visible = true;

                //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvFYI = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvFYI.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);


                for (int rowCount = rowno + 1; rowCount <= drgdMachinesByPlant.VisibleRowCount - 1; rowCount++)
                {
                    //            //Dim lblCategoryName As Label = CType(drgdMachinesByPlant.Items(rowCount).FindControl("lblCategoryName"), Label)
                    //            Label lblPlantName = (Label)drgdMachinesByPlant.Items(rowCount).FindControl("lblPlantName");
                    LinkButton lnkMachineName = (LinkButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Machine"], "lnkMachineName");
                    ImageButton imgRegion1 = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Region"], "imgPlant1");
                    ImageButton imgRegion2 = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Region"], "imgPlant2");
                    Label lblPlantName = (Label)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Plant"], "lblPlantName");
                    ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdMachinesByPlant.Columns["Delete Machine"], "ImgRemoveMachine");

                    //            // Dim lblMachineName As Label = CType(drgdMachinesByPlant.Items(rowCount).FindControl("lblMachineName"), Label)
                    //            LinkButton lnkMachineName = (LinkButton)drgdMachinesByPlant.Items(rowCount).FindControl("lnkMachineName");
                    //            Label lblMachineID = (Label)drgdMachinesByPlant.Items(rowCount).FindControl("lblMachineID");
                    //            ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByPlant.Items(rowCount).FindControl("ImgRemoveMachine");
                    if (lblPlantName != null)
                    {

                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                            imgRegion1.Visible = false;
                            imgRegion2.Visible = false;
                            lblPlantName.Visible = false;                           
                         
                            if (!string.IsNullOrEmpty(lnkMachineName.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lnkMachineName.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                GridViewDataRowTemplateContainer gvFYIi = (GridViewDataRowTemplateContainer)lnkMachineName.Parent;
                                gvFYIi.Visible = true;
                                lnkMachineName.Visible = true;
                                ImgRemoveMachine.Visible = true;
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lnkMachineName.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                GridViewDataRowTemplateContainer gvFYIii = (GridViewDataRowTemplateContainer)lnkMachineName.Parent;
                                gvFYIii.Visible = false;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }                   

                }
                ViewState["Single"] = st.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {

            }
        }
        protected void NoRecords()
        {
            script = "alert('No Results Found')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

        }
        #endregion
        #region "DataGridEvents"
        protected void drgdMachinesByPlant_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillMachinesByPlant();
            }
            catch (Exception exc)
            {

            }
        }

        protected void drgdMachinesByPlant_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView drgdMachinesByPlant = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    LinkButton lnkMachineName = (LinkButton)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Machine"], "lnkMachineName");
                    ImageButton imgRegion1 = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Region"], "imgPlant1");
                    ImageButton imgRegion2 = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Region"], "imgPlant2");
                    Label lblPlantName = (Label)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Plant"], "lblPlantName");
                    Label lblPlantID = (Label)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Machine"], "lblPlantID");
                    Label lblMachineID = (Label)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Machine"], "lblMachineID");
                    ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByPlant.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdMachinesByPlant.Columns["Delete Machine"], "ImgRemoveMachine");
                    ImgRemoveMachine.Attributes.Add("onclick", "javascript:return confirmMachineDelete('" + lnkMachineName.Text + "');");
                    if (ViewState["Expand"] != null)
                    {
                        if (!(ViewState["Expand"] == "ExpandMode"))
                        {
                            //Displaying only Function names in first load of datagrid
                            imgRegion2.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            imgRegion1.Visible = true;
                            lblPlantName.Visible = true;                          
                            if (string.IsNullOrEmpty(lblPlantName.Text))
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
                                e.Row.Visible = false;
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                lblPlantName.Visible = false;
                                lnkMachineName.Visible = false;
                            }

                        }
                        else
                        {

                            imgRegion1.Visible = false;
                            imgRegion2.Visible = true;
                            lblPlantName.Visible = true;
                            lnkMachineName.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                e.Row.Visible = true;                         
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                lnkMachineName.Visible = true;
                                ImgRemoveMachine.Visible = true;
                            }

                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgRegion1.Visible = true;
                            imgRegion2.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            lblPlantName.Visible = true;
                            lnkMachineName.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
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
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                lnkMachineName.Visible = false;
                                ImgRemoveMachine.Visible = false;
                            }

                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblPlantName.Visible = true;
                            imgRegion2.Visible = true;
                            imgRegion1.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            lnkMachineName.Visible = false;
                            e.Row.Visible = true;
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {
                            imgRegion1.Visible = true;
                            imgRegion2.Visible = false;
                            ImgRemoveMachine.Visible = true;
                            lnkMachineName.Visible = false;
                            lblPlantName.Visible = true;
                           
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                e.Row.Visible = true;                           
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                ImgRemoveMachine.Visible = true;
                                lnkMachineName.Visible = true;
                            }
                        }
                        else
                        {
                            imgRegion1.Visible = false;
                            imgRegion2.Visible = false;
                            ImgRemoveMachine.Visible = false;
                            lnkMachineName.Visible = false;
                            lblPlantName.Visible = false;                                                        
                            if (string.IsNullOrEmpty(lblPlantName.Text))
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
                                imgRegion1.Visible = false;
                                imgRegion2.Visible = false;
                                ImgRemoveMachine.Visible = false;
                                lnkMachineName.Visible = false;
                            }
                            if (!string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                e.Row.Visible = true;
                                imgRegion1.Visible = true;
                                imgRegion2.Visible = false;
                                lblPlantName.Visible = true;
                                lnkMachineName.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
            }
        }
        protected void deletePaperMachine(int paperMachineId)
        {
            int Result = -1;
            if (MCcat.DeleteMachine(paperMachineId, cls.UserName, ref Result))
            {
                this.DeleteOperationMessage(Result);
            }

        }

    
        protected void DeleteOperationMessage(int deleteResult)
        {
            string script = null;
            if (deleteResult == 0)
            {
                script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');";
                FillMachinesByPlant();
            }
            else
            {
                script = "alert('" + ConfigurationManager.AppSettings["DeleteError"] + "'); ";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        //
        //
        //  ************************************************
        //Name   	    :	drgdMachinesByPlant_ItemDataBound
        //Written BY	    :	Srilakshmi
        //parameters     :	None
        //Purpose	    :   Displaying Plant names,Machine  Names  based on user click event
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/23/07                 Srilakshmi            1.0           created
        //***************************************************
        //

        //protected void drgdMachinesByPlant_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //If delete command event
        //    if (e.CommandName == "RemoveMachine")
        //    {
        //        //Make sure of user's positive response
        //        if (Request.Form("Response") == "Y")
        //        {
        //            this.deletePaperMachine(Convert.ToInt32(e.CommandArgument));
        //            //Delete the approver
        //        }
        //    }

        //    //when user clicks on Brand Name Expand image button then application will execute below code


        //    if (e.CommandName == "Plant1")
        //    {
        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant1.Visible = false;
        //        imgPlant2.Visible = true;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= drgdMachinesByPlant.Items.Count - 1; rowCount++)
        //        {
        //            //Dim lblCategoryName As Label = CType(drgdMachinesByPlant.Items(rowCount).FindControl("lblCategoryName"), Label)
        //            Label lblPlantName = (Label)drgdMachinesByPlant.Items(rowCount).FindControl("lblPlantName");

        //            // Dim lblMachineName As Label = CType(drgdMachinesByPlant.Items(rowCount).FindControl("lblMachineName"), Label)
        //            LinkButton lnkMachineName = (LinkButton)drgdMachinesByPlant.Items(rowCount).FindControl("lnkMachineName");
        //            Label lblMachineID = (Label)drgdMachinesByPlant.Items(rowCount).FindControl("lblMachineID");
        //            ImageButton ImgRemoveMachine = (ImageButton)drgdMachinesByPlant.Items(rowCount).FindControl("ImgRemoveMachine");


        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lblMachineID.Text))
        //                {
        //                    drgdMachinesByPlant.Items(rowCount).Visible = true;
        //                    lnkMachineName.Visible = true;
        //                    lblMachineID.Visible = false;
        //                    ImgRemoveMachine.Visible = true;

        //                }
        //                else
        //                {
        //                    drgdMachinesByPlant.Items(rowCount).Visible = false;
        //                }

        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }


        //    //when user clicks on Plant Name collapse image button then application will execute below code
        //    // this code will diplay only Plant names and hiding all Machine Details

        //    if (e.CommandName == "Plant2")
        //    {
        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant1.Visible = true;
        //        imgPlant2.Visible = false;

        //        ImageButton ImgRemoveMachine = default(ImageButton);
        //        ImgRemoveMachine = (ImageButton)e.Item.FindControl("ImgRemoveMachine");
        //        ImgRemoveMachine.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= drgdMachinesByPlant.Items.Count - 1; rowCount++)
        //        {
        //            Label lblPlantName = (Label)drgdMachinesByPlant.Items(rowCount).FindControl("lblPlantName");



        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                drgdMachinesByPlant.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }


        //    //code added by bharath
        //    // this code for navigating to edit machine form
        //    if (e.CommandName == "MachineName_Link")
        //    {
        //        Label lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //        string strPlantID = lblPlantID.Text;

        //        Label lblMachineName = (Label)e.Item.FindControl("lblMachineName");
        //        Label lblMachineID = (Label)e.Item.FindControl("lblMachineID");


        //        Response.Redirect("~/Administration/View_PaperMachine.aspx?PlantID=" + strPlantID + "&Mode=" + "Edit" + "&Machine=" + lblMachineName.Text + "&MachineID=" + lblMachineID.Text);
        //    }
        //}
        //protected void drgdMachinesByPlant_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:

        //            ImageButton imgRemoveButton = (ImageButton)e.Item.FindControl("ImgRemoveMachine");
        //            Label lnkMachineName1 = (Label)e.Item.FindControl("lblMachineName");

        //            imgRemoveButton.Attributes.Add("onclick", "return confirmMachineDelete('" + lnkMachineName1.Text + "');");

        //            if (!(ViewState["Expand") == "ExpandMode"))
        //            {
        //                ImageButton imgPlant1 = default(ImageButton);
        //                ImageButton imgPlant2 = default(ImageButton);
        //                ImageButton ImgRemoveMachine = default(ImageButton);

        //                imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //                imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //                ImgRemoveMachine = (ImageButton)e.Item.FindControl("ImgRemoveMachine");
        //                ImgRemoveMachine.Visible = false;
        //                imgPlant2.Visible = false;
        //                Label lblPlantName = default(Label);
        //                Label lblPlantID = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");
        //                lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //                lblPlantID.Visible = false;
        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgPlant1.Visible = false;
        //                    imgPlant2.Visible = false;
        //                    ImgRemoveMachine.Visible = true;
        //                }

        //            }
        //            else
        //            {

        //                ImageButton imgPlant1 = default(ImageButton);
        //                ImageButton imgPlant2 = default(ImageButton);
        //                ImageButton ImgRemoveMachine = default(ImageButton);

        //                imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //                imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //                ImgRemoveMachine = (ImageButton)e.Item.FindControl("ImgRemoveMachine");
        //                ImgRemoveMachine.Visible = false;
        //                imgPlant1.Visible = false;
        //                imgPlant2.Visible = true;

        //                Label lblPlantName = default(Label);
        //                Label lblPlantID = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");
        //                lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //                lblPlantID.Visible = false;

        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    e.Item.Visible = true;
        //                    imgPlant2.Visible = false;
        //                    ImgRemoveMachine.Visible = true;
        //                }

        //                Label lblMachineID = default(Label);
        //                lblMachineID = (Label)e.Item.FindControl("lblMachineID");
        //                lblMachineID.Visible = false;

        //                LinkButton lnkMachineName = (LinkButton)e.Item.FindControl("lnkMachineName");
        //                lnkMachineName.Visible = true;

        //            }
        //            break;
        //    }
        //}
        #endregion
        #region "AddingMachine"
        //
        //
        //  ************************************************
        //Name   	    :	imgAddPaperMachine_Click
        //Written BY	    :	Srilakshmi
        //parameters     :	None
        //Purpose	    :   Adding Machine to Database
        //Returns        :   to GUI  
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/23/07                 Srilakshmi            1.0           created
        //***************************************************
        //
        protected void imgAddPaperMachine_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddMachine.aspx");
        }
        #endregion

        protected void imgExpnadAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            FillMachinesByPlant();
        }

        protected void imgCollapseAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillMachinesByPlant();
        }

    }
}