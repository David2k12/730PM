using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using System.Data;
using System.Configuration;
using System.Collections;
using MUREOBAL;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class MaintainConcurrenceGroup : System.Web.UI.Page
    {
        #region "Variable Declarations"
        clsSecurity cls = new clsSecurity();
        DataSet dsConcurrenceGrp;
        DataTable dtConGrp = new DataTable();
        DataRow drConGrp;
        Int32 returnvalue;
        ConcurrenceGroup con = new ConcurrenceGroup();
        #endregion
        string Script;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.SmartNavigation = true;
            if (!Page.IsPostBack)
            {
                //FillConcurrenceGroup()
                FillConGroup();
            }
        }
        //protected Sub dtgrdConcurrenceGroup_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgrdConcurrenceGroup.ItemDataBound
        //    Select Case e.Item.ItemType
        //        Case ListItemType.AlternatingItem, ListItemType.Item

        //            If Not ViewState["Expand") = "ExpandMode" Then

        //                'Displaying only Category names in first load of datagrid
        //                Dim imgPlant1 As ImageButton
        //                Dim imgPlant2 As ImageButton
        //                Dim imgRemoveApprover As ImageButton
        //                imgPlant1 = CType(e.Item.FindControl("imgPlant1"), ImageButton)
        //                imgPlant2 = CType(e.Item.FindControl("imgPlant2"), ImageButton)
        //                imgRemoveApprover = CType(e.Item.FindControl("imgRemoveApprover"), ImageButton)
        //                imgPlant2.Visible = False
        //                imgRemoveApprover.Visible = False

        //                Dim lblFunctionID As Label
        //                lblFunctionID = CType(e.Item.FindControl("lblFunctionID"), Label)
        //                lblFunctionID.Visible = False
        //                Dim lblFunctionName As Label
        //                lblFunctionName = CType(e.Item.FindControl("lblFunctionName"), Label)


        //                If lblFunctionName.Text = "" Then
        //                    e.Item.Visible = False
        //                    imgPlant1.Visible = False
        //                    imgPlant2.Visible = False
        //                    imgRemoveapprover.Visible = True

        //                End If


        //            Else

        //                Dim imgPlant1 As ImageButton
        //                Dim imgPlant2 As ImageButton
        //                Dim imgRemoveApprover As ImageButton
        //                imgPlant1 = CType(e.Item.FindControl("imgFunction1"), ImageButton)
        //                imgPlant2 = CType(e.Item.FindControl("imgFunction2"), ImageButton)
        //                imgRemoveApprover = CType(e.Item.FindControl("imgRemoveApprover"), ImageButton)
        //                imgPlant2.Visible = False
        //                imgRemoveApprover.Visible = False

        //                Dim lblPlantID As Label
        //                lblPlantID = CType(e.Item.FindControl("lblPlantID"), Label)
        //                lblPlantID.Visible = False
        //                Dim lblPlantName As Label
        //                lblPlantName = CType(e.Item.FindControl("lblPlantName"), Label)

        //                If lblPlantName.Text = "" Then
        //                    'e.Item.Visible = False
        //                    imgPlant1.Visible = False
        //                    imgPlant2.Visible = False
        //                    imgRemoveApprover.Visible = True
        //                End If

        //                Dim lnkconGrpName As LinkButton
        //                lnkconGrpName = CType(e.Item.FindControl("lnkconGrpName"), LinkButton)
        //                lnkconGrpName.Visible = True


        //                Dim lblconGrpName As Label
        //                lblconGrpName = CType(e.Item.FindControl("Concurrence_Group_Name"), Label)
        //                lblconGrpName.Visible = True
        //            End If



        //    End Select
        //End Sub


        private void FillConGroup()
        {

            dsConcurrenceGrp = new DataSet();
            ArrayList arrayPlantName = new ArrayList();
            ArrayList arrayPlantID = new ArrayList();


            if (con.FillConcurrenceGroup(ref dsConcurrenceGrp))
            {

                if (dsConcurrenceGrp == null)
                {
                }
                else if (dsConcurrenceGrp.Tables[0].Rows.Count == 0)
                {
                    dtgrdConcurrenceGroup.Visible = false;

                }
                else
                {
                    DataTable dtConGrp = new DataTable();
                    DataRow drConGrp = null;


                    dtConGrp.Columns.Add("Plant_ID");
                    dtConGrp.Columns.Add("Plant_Name");
                    dtConGrp.Columns.Add("Concurrence_Group_Name");
                    dtConGrp.Columns.Add("Approver_Name");
                    //dtConcurrenceGrp.Columns.Add("Approver_ID")
                    dtConGrp.Columns.Add("Concurrence_Group_ID");



                    //Below code for splitting data for treeview display and binding splitted data into temperory table


                    //First row item of category name
                    string strPlantName = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[0][3]);
                    string strPlantID = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[0][2]);

                    //Adding Category name to array
                    arrayPlantName.Add(strPlantName);
                    arrayPlantID.Add(strPlantID);

                    //Adding all categoory names(Without repitition)

                    for (int rowCount = 0; rowCount <= dsConcurrenceGrp.Tables[0].Rows.Count - 1; rowCount++)
                    {
                        string strPlantName1 = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowCount][3]);
                        string strPlantID1 = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowCount][2]);


                        if (!(arrayPlantName.Contains(strPlantName1)))
                        {
                            arrayPlantName.Add(strPlantName1);
                            arrayPlantID.Add(strPlantID1);

                        }
                    }

                    //Dim dtConGrp As New DataTable
                    //Dim drConGrp As DataRow
                    //Based on Category name storing Category ID and Category name in to temperory table

                    for (int rowFunctionNameCount = 0; rowFunctionNameCount <= arrayPlantName.Count - 1; rowFunctionNameCount++)
                    {
                        drConGrp = dtConGrp.NewRow();
                        drConGrp["Plant_ID"] = arrayPlantID[rowFunctionNameCount];
                        drConGrp["Plant_Name"] = arrayPlantName[rowFunctionNameCount];
                        drConGrp["Concurrence_Group_Name"] = "";
                        drConGrp["Approver_Name"] = "";

                        dtConGrp.Rows.Add(drConGrp);

                        ArrayList arrayApproverName = new ArrayList();
                        ArrayList arrayApproverID = new ArrayList();
                        ArrayList arrayConcuurenceGroupID = new ArrayList();
                        ArrayList arrayConcuurenceGroupName = new ArrayList();


                        //Adding brand names(Without repitition) based on Category Name

                        for (int rowApproverCount = 0; rowApproverCount <= dsConcurrenceGrp.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {

                            if (Convert.ToString(arrayPlantName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Plant_Name"]).Trim().ToUpper())
                            {
                                string strConGrpName = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Concurrence_Group_Name"]);
                                string strApproverName = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Approver_Name"]);

                                // Dim ApproverID As String = dsConcurrenceGrp.Tables[0].Rows(rowApproverCount)("Approver_ID")
                                string conGrpID = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Concurrence_Group_ID"]);

                                arrayApproverName.Add(strApproverName);
                                arrayConcuurenceGroupName.Add(strConGrpName);
                                //arrayApproverID.Add(Convert.ToInt32(ApproverID))
                                arrayConcuurenceGroupID.Add(Convert.ToInt32(conGrpID));


                            }

                        }

                        // Dim arrayApproverID1 As New ArrayList
                        ArrayList arrayConcuurenceGroupID1 = new ArrayList();
                        ArrayList arrayPlantID1 = new ArrayList();


                        for (int rowApproverCount = 0; rowApproverCount <= dsConcurrenceGrp.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {
                            if (Convert.ToString(arrayPlantName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Plant_Name"]).Trim().ToUpper())
                            {
                                //Dim strApproverID As String = dsApproversByCategory.Tables[0].Rows(rowApproverCount)("Approver_ID")
                                string strconGrpID = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Concurrence_Group_ID"]);
                                string strPlaID = Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount]["Plant_ID"]);

                                if (arrayConcuurenceGroupID1.Count == 0)
                                {
                                    arrayConcuurenceGroupID1.Add(strconGrpID);
                                    arrayPlantID1.Add(strPlantID);

                                }

                                if (!(arrayConcuurenceGroupID1.Contains(strconGrpID)))
                                {
                                    arrayConcuurenceGroupID1.Add(strconGrpID);
                                    arrayPlantID1.Add(strPlantID);
                                    //arrayFunctionID1.Add(strFuncID)
                                }
                            }
                        }


                        //Based on Brand name storing Brand ID and Brand name in to temperory table

                        for (int rowApproverCount1 = 0; rowApproverCount1 <= arrayApproverName.Count - 1; rowApproverCount1++)
                        {
                            drConGrp = dtConGrp.NewRow();
                            drConGrp["Plant_ID"] =Convert.ToString(dsConcurrenceGrp.Tables[0].Rows[rowApproverCount1]["Plant_ID"]);
                            drConGrp["Plant_ID"] = arrayPlantID1[rowApproverCount1];
                            drConGrp["Plant_Name"] = "";
                            //drConGrp("Plant_Name1") = dsConcurrenceGrp.Tables[0].Rows(rowApproverCount1)("Plant_Name")
                            drConGrp["Approver_Name"] = arrayApproverName[rowApproverCount1];
                            drConGrp["Concurrence_Group_Name"] = arrayConcuurenceGroupName[rowApproverCount1];

                            drConGrp["Concurrence_Group_ID"] = dsConcurrenceGrp.Tables[0].Rows[rowApproverCount1]["Concurrence_Group_ID"];
                            drConGrp["Plant_ID"] = dsConcurrenceGrp.Tables[0].Rows[rowApproverCount1]["Plant_ID"];


                            drConGrp["Concurrence_Group_ID"] = arrayConcuurenceGroupID1[rowApproverCount1];
                            drConGrp["Plant_ID"] = arrayPlantID1[rowApproverCount1];


                            dtConGrp.Rows.Add(drConGrp);


                        }
                    }
                    DataColumn dc = new DataColumn("Index");
                    dtConGrp.Columns.Add(dc);
                    Int32 ind = 0;
                    foreach (DataRow dr in dtConGrp.Rows)
                    {

                        dr["Index"] = ind;
                        ind++;
                    }
                    dtConGrp.AcceptChanges();
                    dtgrdConcurrenceGroup.DataSource = dtConGrp;
                    dtgrdConcurrenceGroup.DataBind();

                }
            }
        }


        protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                ImageButton imgPlant1 = (ImageButton)sender;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");
                //imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
                imgPlant2.Visible = true;
                //Make collapse button visible            
                imgPlant1.Visible = false;
                string st = string.Empty;
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "document.getElementById('" + imgPlant2.ClientID + "').focus();", true);
                //Make expand button invisible
                // ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= dtgrdConcurrenceGroup.VisibleRowCount - 1; rowCount++)
                {
                    Label lblPlantName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Plant"], "lblPlantName");
                    LinkButton lnkconGrpName = (LinkButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence Group"], "lnkconGrpName");
                    Label lblconGrpName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence Group"], "lblconGrpName");
                    ImageButton imgRemoveApprover = (ImageButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Delete Group"], "imgRemoveApprover");
                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                           
                            
                            if (!string.IsNullOrEmpty(lblconGrpName.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                lnkconGrpName.Visible = true;
                                imgRemoveApprover.Visible = true;
                                lblconGrpName.Visible = false;
                            }
                            else
                            {
                                //drConGrp.Items[rowCount].Visible = false;
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                lblconGrpName.Visible = false;
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
        protected void lnkconGrpName_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                LinkButton lkb = (LinkButton)sender;
                Response.Redirect("~/Administration/ViewConcurrenceGroup.aspx?ConGrpID=" + Convert.ToString(e.CommandName) + "&Mode=Edit" + "&PlantID=" + Convert.ToString(lkb.Attributes["Plant_ID"]) + "&conGrpName=" + Convert.ToString(lkb.Attributes["Concurrence_Group_Name"]) + "&ApproverName=" + e.CommandArgument);
            }
        }
        protected void ImgRemoveApprover_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName != null && hdnresponse.Value == "Y")
            {
                int pcID = Convert.ToInt32(e.CommandArgument);
                DeleteConcurrenceGroup(pcID);
                dtgrdConcurrenceGroup.DataSource = "";
                dtgrdConcurrenceGroup.DataBind();
                ViewState["Expand"] = "CollapseMode";
                FillConGroup();
            }
        }

        protected void imgPlant2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            ImageButton imgPlant2 = (ImageButton)sender;
            imgPlant2.Visible = false;
            //Make collapse button invisible
            ImageButton imgPlant1 = (ImageButton)imgPlant2.Parent.FindControl("imgPlant1");
            imgPlant1.Visible = true;
            //Make expand button visible
            //GridViewTableDataRow gvdd = (GridViewTableDataRow)imgFunction2.Parent.Parent.Parent;
            GridViewDataItemTemplateContainer gvd = (GridViewDataItemTemplateContainer)imgPlant2.Parent;
            int rowno = gvd.ItemIndex;
            ImageButton imgRemoveApprover = (ImageButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Delete Group?"], "ImgRemoveApprover");
            imgRemoveApprover.Visible = false;

            for (int rowCount = rowno + 1; rowCount <= dtgrdConcurrenceGroup.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                Label lblPlantName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Plant"], "lblPlantName");
                LinkButton lnkconGrpName = (LinkButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence Group"], "lnkconGrpName");
                if (lblPlantName != null)
                {
                    if (string.IsNullOrEmpty(lblPlantName.Text))
                    {

                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        lnkconGrpName.Visible = true;
                        imgRemoveApprover.Visible = true;
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
        }
        //protected void dtgrdConcurrenceGroup_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{

        //    if (e.CommandName == "View_Approver")
        //    {

        //        Label lblPlantID = (Label)dtgrdConcurrenceGroup.Items(e.Item.ItemIndex).FindControl("lblPlantID");
        //        // Dim lblApproverID As Label = CType(dtgrdConcurrenceGroup.Items(e.Item.ItemIndex).FindControl("lblApprvrID"), Label)
        //        Label lblConcGrpID = (Label)dtgrdConcurrenceGroup.Items(e.Item.ItemIndex).FindControl("lblPlantID");

        //        //Response.Redirect("ViewApprvr.aspx?Funct_ID=" & lblFunctionID.Text & "&Apprv_ID=" & lblApproverID.Text & "&Plant_ID=" & lblPlantID.Text)

        //        //ElseIf e.CommandName = "RemoveApprover" Then
        //        //    Dim lblMaterialID As Label = CType(e.Item.FindControl("lblMaterialID"), Label)
        //        //    Dim lblPlantID As Label = CType(e.Item.FindControl("lblPlantID"), Label)
        //        //    Dim lblPhNo As Label = CType(e.Item.FindControl("lblPhNo"), Label)
        //        //    Dim lblPlantName As Label = CType(e.Item.FindControl("lblPName"), Label)
        //        //    Dim lblMaterialName As Label = CType(e.Item.FindControl("lblMname"), Label)
        //        //    Dim lblApproverName As Label = CType(e.Item.FindControl("lblApproverName"), Label)
        //        //    Dim lblPContactID As Label = CType(e.Item.FindControl("lblPcontactID"), Label)
        //        //    Response.Redirect("~/Administration/ViewPurchasingContact.aspx?MaterialID=" + lblMaterialID.Text + "&Mode=Edit" + "&PlantID=" + lblPlantID.Text + "&PhNo=" + lblPhNo.Text + "&ApproverName=" + lblApproverName.Text + "&PlantName=" + lblPlantName.Text + "&MaterialType=" + lblMaterialName.Text + "&PContactID=" + lblPContactID.Text)

        //    }

        //    if (e.CommandName == "RemoveApprover")
        //    {
        //        if (hdnresponse.Value == "Y")
        //        {
        //            int pcID = Convert.ToInt32(e.CommandArgument);
        //            DeleteConcurrenceGroup(pcID);
        //            dtgrdConcurrenceGroup.DataSource = "";
        //            dtgrdConcurrenceGroup.DataBind();
        //            FillConGroup();
        //        }

        //    }


        //    if (e.CommandName == "ConGrpName_Link")
        //    {
        //        Label lblConGrpID = (Label)e.Item.FindControl("lblconGrpID");
        //        Label lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //        Label lblPhNo = (Label)e.Item.FindControl("lblPhNo");
        //        //Dim lblPlantName As Label = CType(e.Item.FindControl("lblPlantName"), Label)
        //        Label lblPlantName = (Label)dtgrdConcurrenceGroup.Items(e.Item.ItemIndex - 1).Cells(3).FindControl("lblPName");
        //        Label lblConGrpName = (Label)e.Item.FindControl("lblconGrpName");
        //        Label lblApproverName = (Label)e.Item.FindControl("lblApproverName");
        //        Label lblPContactID = (Label)e.Item.FindControl("lblPcontactID");
        //        //Response.Redirect("~/Administration/ViewConcurrenceGroup.aspx?ConGrpID=" + lblConGrpID.Text + "&Mode=Edit" + "&PlantID=" + lblPlantID.Text + "&conGrpName=" + lblConGrpName.Text + "&ApproverName=" + lblApproverName.Text + "&PlantName=" + lblPlantName.Text)
        //        Response.Redirect("~/Administration/ViewConcurrenceGroup.aspx?ConGrpID=" + lblConGrpID.Text + "&Mode=Edit" + "&PlantID=" + lblPlantID.Text + "&conGrpName=" + lblConGrpName.Text + "&ApproverName=" + lblApproverName.Text);
        //    }




        //    //when user clicks on category expand image button then application will execute below code
        //    // this code will diplay brand names


        //    if (e.CommandName == "Plant1")
        //    {
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant2.Visible = true;

        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant1.Visible = false;


        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dtgrdConcurrenceGroup.Items.Count - 1; rowCount++)
        //        {
        //            Label lblPlantName = (Label)dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblPlantName");
        //            LinkButton lnkconGrpName = (LinkButton)dtgrdConcurrenceGroup.Items(rowCount).FindControl("lnkconGrpName");
        //            Label lblconGrpName = (Label)dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblconGrpName");
        //            ImageButton imgRemoveApprover = (ImageButton)dtgrdConcurrenceGroup.Items(rowCount).FindControl("imgRemoveApprover");
        //            // imgRemoveApprover.Attributes.Add("onclick", "javascript:if(confirm('Are you sure you want to delete this Approver?')==false){ window.event.returnValue = false; return true;} else return false; ")
        //            // imgRemoveApprover.Attributes.Add("onclick", "return confirmApproverDelete();")



        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lnkconGrpName.Text))
        //                {
        //                    dtgrdConcurrenceGroup.Items(rowCount).Visible = true;
        //                    lnkconGrpName.Visible = true;
        //                    imgRemoveApprover.Visible = true;
        //                    lblconGrpName.Visible = false;
        //                }
        //                else
        //                {
        //                    dtgrdConcurrenceGroup.Items(rowCount).Visible = true;
        //                    lblconGrpName.Visible = false;
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

        //    if (e.CommandName == "Plant2")
        //    {
        //        ImageButton imgPlant2 = default(ImageButton);
        //        imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //        imgPlant2.Visible = false;

        //        ImageButton imgPlant1 = default(ImageButton);
        //        imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //        imgPlant1.Visible = true;

        //        ImageButton imgRemoveApprover = default(ImageButton);
        //        imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
        //        imgRemoveApprover.Visible = false;

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;


        //        for (int rowCount = rowno + 1; rowCount <= dtgrdConcurrenceGroup.Items.Count - 1; rowCount++)
        //        {
        //            Label lblPlantName = (Label)dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblPlantName");
        //            LinkButton lnkconGrpName = (LinkButton)dtgrdConcurrenceGroup.Items(rowCount).FindControl("lnkconGrpName");
        //            if (string.IsNullOrEmpty(lblPlantName.Text))
        //            {
        //                dtgrdConcurrenceGroup.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }

        //        }
        //    }

        //}
        //protected Sub dtgrdConcurrenceGroup_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgrdConcurrenceGroup.ItemCommand


        //    'when user clicks on Brand Name Expand image button then application will execute below code

        //    If e.CommandName = "Plant1" Then

        //        Dim imgPlant1 As ImageButton
        //        imgPlant1 = CType(e.Item.FindControl("imgPlant1"), ImageButton)
        //        Dim imgPlant2 As ImageButton
        //        imgPlant2 = CType(e.Item.FindControl("imgPlant2"), ImageButton)
        //        imgPlant1.Visible = False
        //        imgPlant2.Visible = True

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" & imgPlant2.ClientID & "').focus();")

        //        Dim rowno As Integer = e.Item.ItemIndex

        //        For rowCount As Integer = rowno + 1 To dtgrdConcurrenceGroup.Items.Count - 1

        //            'Dim lblCategoryName As Label = CType(drgdMachinesByPlant.Items(rowCount).FindControl("lblCategoryName"), Label)
        //            Dim lblPlantName As Label = CType(dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblPlantName"), Label)

        //            ' Dim lblMachineName As Label = CType(drgdMachinesByPlant.Items(rowCount).FindControl("lblMachineName"), Label)
        //            Dim lnkconGrpName As LinkButton = CType(dtgrdConcurrenceGroup.Items(rowCount).FindControl("lnkconGrpName"), LinkButton)
        //            Dim lblconGrpID As Label = CType(dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblconGrpID"), Label)
        //            Dim lblApproverName As Label = CType(dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblApproverName"), Label)
        //            If lblPlantName.Text = "" Then

        //                If Not lblconGrpID.Text = "" Then
        //                    dtgrdConcurrenceGroup.Items(rowCount).Visible = True
        //                    lnkconGrpName.Visible = True
        //                    lblconGrpID.Visible = False
        //                    lblApproverName.Visible = True


        //                Else
        //                    dtgrdConcurrenceGroup.Items(rowCount).Visible = False
        //                End If

        //            Else
        //                Exit For
        //            End If

        //        Next
        //    End If


        //    'when user clicks on Concurrence List collapse image button then application will execute below code
        //    ' this code will diplay only Concurrence Lists and hiding all Machine Details
        //    If e.CommandName = "Plant2" Then

        //        Dim imgPlant1 As ImageButton
        //        imgPlant1 = CType(e.Item.FindControl("imgPlant1"), ImageButton)
        //        Dim imgPlant2 As ImageButton
        //        imgPlant2 = CType(e.Item.FindControl("imgPlant2"), ImageButton)
        //        imgPlant1.Visible = True
        //        imgPlant2.Visible = False

        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" & imgPlant1.ClientID & "').focus();")

        //        Dim rowno As Integer = e.Item.ItemIndex

        //        For rowCount As Integer = rowno + 1 To dtgrdConcurrenceGroup.Items.Count - 1

        //            Dim lblPlantName As Label = CType(dtgrdConcurrenceGroup.Items(rowCount).FindControl("lblPlantName"), Label)



        //            If lblPlantName.Text = "" Then
        //                dtgrdConcurrenceGroup.Items(rowCount).Visible = False
        //            Else
        //                Exit For
        //            End If

        //        Next
        //    End If


        //    'code added by bharath
        //    ' this code for navigating to edit machine form
        //    If e.CommandName = "ConGrpName_Link" Then
        //        Dim lblPlantID As Label = CType(e.Item.FindControl("lblPlantID"), Label)
        //        Dim strPlantID As String = lblPlantID.Text

        //        Dim lblconGrpName As Label = CType(e.Item.FindControl("lblconGrpName"), Label)
        //        Dim lblconGrpID As Label = CType(e.Item.FindControl("lblconGrpID"), Label)


        //        'Response.Redirect("~/Administration/AddMachine.aspx?PlantID=" + strPlantID + "&Mode=" + "Edit" + "&Machine=" + lblMachineName.Text + "&MachineID=" + lblMachineID.Text)
        //    End If
        //End Sub
        protected void dtgrdConcurrenceGroup_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillConGroup();
            }
            catch (Exception exc)
            {
              
            }
        }
        protected void dtgrdConcurrenceGroup_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView dtgrdConcurrenceGroup = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    ImageButton imgRemoveButton = (ImageButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Delete Group"], "ImgRemoveApprover");
                    Label lblApproverName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence List"], "lblApproverName");
                    Label lblPlantName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Plant"], "lblPlantName");

                    LinkButton lnkconGrpName = (LinkButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence Group"], "lnkconGrpName");
                    ImageButton imgFunction1 = (ImageButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Plant"], "imgPlant1");
                    ImageButton imgFunction2 = (ImageButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Plant"], "imgPlant2");
                    //Label lblFunctionID = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["FunctionName"], "lblFunctionID");
                    //Label lblFunctionName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["FunctionName"], "lblFunctionName");
                    imgRemoveButton.Attributes.Add("onclick", "javascript:return confirmPurchasingContactDelete('" + lnkconGrpName.Text + "');");

                    // ImageButton imgFunction1 = (ImageButton)imgRemoveButton.Parent.FindControl("imgFunction1");
                    // ImageButton imgFunction2 = (ImageButton)imgRemoveButton.Parent.FindControl("imgFunction2");
                    //Label lblFunctionID = (Label)imgRemoveButton.Parent.FindControl("lblFunctionID");
                    //Label lblFunctionName = (Label)imgRemoveButton.Parent.FindControl("lblFunctionName");
                    if (ViewState["Expand"] != null)
                    {
                        if (Convert.ToString(ViewState["Expand"]) != "ExpandMode")
                        {
                            //Displaying only Function names in first load of datagrid


                            imgFunction2.Visible = false;
                            imgRemoveButton.Visible = false;

                            //lblFunctionID.Visible = false;

                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                   
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                imgRemoveButton.Visible = false;
                                lblApproverName.Visible = false;
                                lnkconGrpName.Visible = false;

                            }
                            lblPlantName.Visible = true;

                        }
                        else
                        {

                            imgFunction1.Visible = false;
                            imgFunction2.Visible = true;
                            imgRemoveButton.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                e.Row.Visible = true;
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                imgRemoveButton.Visible = true;
                                lblApproverName.Visible = true;
                                lnkconGrpName.Visible = true;
                            }
                            lblPlantName.Visible = true;
                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgFunction1.Visible = true;
                            imgFunction2.Visible = false;
                            imgRemoveButton.Visible = false;

                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                   
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                imgRemoveButton.Visible = false;
                                lblApproverName.Visible = false;
                                lnkconGrpName.Visible = false;
                            }
                            lblPlantName.Visible = true;
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]),Convert.ToString(e.VisibleIndex)))
                        {
                            //lblFunctionID.Visible = false;
                            imgFunction1.Visible = false;
                            imgFunction2.Visible = true;
                            imgRemoveButton.Visible = false;
                            e.Row.Visible = true;
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]),Convert.ToString(e.VisibleIndex)))
                        {
                            //lblFunctionID.Visible = false;
                            imgFunction2.Visible = false;
                            imgRemoveButton.Visible = true;
                            // lblFunctionID.Visible = false;
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                //lblFunctionID.Visible = false;
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                e.Row.Visible = true;
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                imgRemoveButton.Visible = true;
                            }
                            lblPlantName.Visible = true;
                        }
                        else
                        {
                            imgFunction2.Visible = false;
                            imgRemoveButton.Visible = false;
                            imgFunction1.Visible = false;
                            //lblFunctionID.Visible = false;
                            lblPlantName.Visible = false;
                            if (!string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                e.Row.Visible = true;                            
                                imgFunction1.Visible = true;
                                imgFunction2.Visible = false;
                                lblPlantName.Visible = true;
                                lnkconGrpName.Visible = false;
                                imgRemoveButton.Visible = false;
                                lblApproverName.Visible = false;
                            }
                          
                            if (string.IsNullOrEmpty(lblPlantName.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row.Cells[3] != null)
                                        e.Row.Cells[3].CssClass = "hiddencol";
                                  
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                imgRemoveButton.Visible = false;
                                lnkconGrpName.Visible = false;
                                lblApproverName.Visible = false;
                            }
                            //LinkButton lnkApproverName = (LinkButton)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence Group"], "lnkApproverName");
                            //lnkApproverName.Visible = false;
                            //Label lblPlantName = (Label)dtgrdConcurrenceGroup.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dtgrdConcurrenceGroup.Columns["Concurrence List"], "lblPlantName");
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //objErrorLog.SaveErrorLog(strModule + "gvRecords_HtmlRowCreated", "Error", ex.Message, "gvRecords_HtmlRowCreated", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }



        //protected Sub dtgrdConcurrenceGroup_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgrdConcurrenceGroup.ItemDataBound
        //    Select Case e.Item.ItemType
        //        Case ListItemType.AlternatingItem, ListItemType.Item

        //            If Not ViewState["Expand") = "ExpandMode" Then


        //                Dim imgPlant1 As ImageButton
        //                Dim imgPlant2 As ImageButton
        //                imgPlant1 = CType(e.Item.FindControl("imgPlant1"), ImageButton)
        //                imgPlant2 = CType(e.Item.FindControl("imgPlant2"), ImageButton)

        //                imgPlant2.Visible = False
        //                Dim lblPlantName As Label
        //                Dim lblPlantID As Label
        //                lblPlantName = CType(e.Item.FindControl("lblPlantName"), Label)
        //                lblPlantID = CType(e.Item.FindControl("lblPlantID"), Label)
        //                lblPlantID.Visible = False
        //                If lblPlantName.Text = "" Then
        //                    e.Item.Visible = False
        //                    imgPlant1.Visible = False
        //                    imgPlant2.Visible = False
        //                End If
        //            Else


        //                Dim imgPlant1 As ImageButton
        //                Dim imgPlant2 As ImageButton
        //                imgPlant1 = CType(e.Item.FindControl("imgPlant1"), ImageButton)
        //                imgPlant2 = CType(e.Item.FindControl("imgPlant2"), ImageButton)
        //                imgPlant1.Visible = False
        //                imgPlant2.Visible = True

        //                Dim lblPlantName As Label
        //                Dim lblPlantID As Label
        //                lblPlantName = CType(e.Item.FindControl("lblPlantName"), Label)
        //                lblPlantID = CType(e.Item.FindControl("lblPlantID"), Label)
        //                lblPlantID.Visible = False

        //                If lblPlantName.Text = "" Then
        //                    e.Item.Visible = True
        //                    imgPlant2.Visible = False
        //                End If

        //                Dim lblconGrpID As Label
        //                lblconGrpID = CType(e.Item.FindControl("lblconGrpID"), Label)
        //                lblconGrpID.Visible = False

        //                Dim lnkconGrpName As LinkButton = CType(e.Item.FindControl("lnkconGrpName"), LinkButton)
        //                lnkconGrpName.Visible = True

        //            End If
        //    End Select
        //End Sub

        //protected Sub FillConcurrenceGroup()

        //    dsConcurrenceGrp = New DataSet

        //    dsConcurrenceGrp = BusinessObject.MUREO.BusinessObject.ConcurrenceGroup.FillConcurrenceGroup()

        //    If dsConcurrenceGrp Is Nothing Then

        //    ElseIf dsConcurrenceGrp.Tables.Count = 0 Then

        //    ElseIf dsConcurrenceGrp.Tables[0].Rows.Count = 0 Then

        //    Else

        //        Dim dtConGrp As New DataTable
        //        Dim drConGrp As DataRow

        //        dtConGrp.Columns.Add("Plant_ID")
        //        dtConGrp.Columns.Add("Plant_Name")
        //        dtConGrp.Columns.Add("Concurrence_Group_ID")
        //        dtConGrp.Columns.Add("Concurrence_Group_Name")
        //        dtConGrp.Columns.Add("Approver_Name")


        //        'Below code for splitting data for treeview display and binding splitted data into temperory table
        //        Dim arrayPlantName As New ArrayList
        //        Dim arrayPlantID As New ArrayList

        //        'First row item of Concurrence List
        //        Dim strPlantName As String = dsConcurrenceGrp.Tables[0].Rows[0].Item[3]
        //        Dim strPlantID As String = dsConcurrenceGrp.Tables[0].Rows[0].Item[2]

        //        'Adding Plantname to array
        //        arrayPlantName.Add(strPlantName)
        //        arrayPlantID.Add(strPlantID)

        //        'Adding all Concurrence Lists(Without repitition)
        //        For rowCount As Integer = 0 To dsConcurrenceGrp.Tables[0].Rows.Count - 1

        //            Dim strPlantName1 As String = dsConcurrenceGrp.Tables[0].Rows(rowCount).Item[3]
        //            Dim strPlantID1 As String = dsConcurrenceGrp.Tables[0].Rows(rowCount).Item[2]

        //            If Not (arrayPlantName.Contains(strPlantName1)) Then

        //                arrayPlantName.Add(strPlantName1)
        //                arrayPlantID.Add(strPlantID1)

        //            End If
        //        Next




        //        'Based on Concurrence List storing Plant ID and Concurrence List in to temperory table
        //        For rowFunctionNameCount As Integer = 0 To arrayPlantName.Count - 1

        //            drConGrp = dtConGrp.NewRow
        //            drConGrp("Plant_ID") = ""
        //            drConGrp("Plant_Name") = arrayPlantName(rowFunctionNameCount)
        //            drConGrp("Concurrence_Group_ID") = ""
        //            drConGrp("Concurrence_Group_Name") = ""
        //            drConGrp("Approver_Name") = ""

        //            dtConGrp.Rows.Add(drConGrp)

        //            Dim arrayMachineName As New ArrayList
        //            Dim arrayMachineID As New ArrayList
        //            Dim arrayApproveName As New ArrayList


        //            For rowApproverCount As Integer = 0 To dsConcurrenceGrp.Tables[0].Rows.Count - 1

        //                If arrayPlantName(rowFunctionNameCount) = dsConcurrenceGrp.Tables[0].Rows(rowApproverCount)(1) Then

        //                    Dim strMachinetName As String = dsConcurrenceGrp.Tables[0].Rows(rowApproverCount)(1)
        //                    Dim strMachineID As String = dsConcurrenceGrp.Tables[0].Rows(rowApproverCount)(0)
        //                    Dim ApproverName As String = dsConcurrenceGrp.Tables[0].Rows(rowApproverCount)(4)


        //                    arrayMachineName.Add(strMachinetName)
        //                    arrayMachineID.Add(strMachineID)
        //                    arrayApproveName.Add(ApproverName)


        //                End If

        //            Next



        //            For rowApproverCount1 As Integer = 0 To arrayMachineName.Count - 1

        //                drConGrp = dtConGrp.NewRow
        //                drConGrp("Plant_ID") = arrayPlantID(rowFunctionNameCount)
        //                drConGrp("Plant_Name") = ""
        //                drConGrp("Concurrence_Group_Name") = arrayMachineName(rowApproverCount1)
        //                drConGrp("Concurrence_Group_ID") = arrayMachineID(rowApproverCount1)
        //                drConGrp("Approver_Name") = arrayApproveName(rowApproverCount1)
        //                dtConGrp.Rows.Add(drConGrp)


        //            Next
        //        Next



        //        dtgrdConcurrenceGroup.DataSource = dtConGrp
        //        dtgrdConcurrenceGroup.DataBind()
        //    End If

        //End Sub



        //protected void dtgrdConcurrenceGroup_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            Label lblConGrpName = default(Label);

        //            if (!(ViewState["Expand") == "ExpandMode"))
        //            {
        //                //Displaying only Category names in first load of datagrid
        //                ImageButton imgPlant1 = default(ImageButton);
        //                ImageButton imgPlant2 = default(ImageButton);
        //                ImageButton imgRemoveApprover = default(ImageButton);
        //                imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //                imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //                imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
        //                imgPlant2.Visible = false;
        //                imgRemoveApprover.Visible = false;

        //                Label lblPlantID = default(Label);
        //                lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //                lblPlantID.Visible = false;
        //                Label lblPlantName = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");


        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgPlant1.Visible = false;
        //                    imgPlant2.Visible = false;
        //                    imgRemoveApprover.Visible = true;

        //                }
        //                //Dim imgDeleteGroup As ImageButton = CType(e.Item.FindControl("imgDeleteGroup"), ImageButton)
        //                //Dim lnkcGrpName As Label = CType(e.Item.FindControl("lblconGrpName"), Label)
        //                //imgDeleteGroup.Attributes.Add("onclick", "return confirmPurchasingContactDelete('" & lnkcGrpName.Text & "');")




        //            }
        //            else
        //            {
        //                ImageButton imgPlant1 = default(ImageButton);
        //                ImageButton imgPlant2 = default(ImageButton);
        //                ImageButton imgRemoveApprover = default(ImageButton);
        //                imgPlant1 = (ImageButton)e.Item.FindControl("imgPlant1");
        //                imgPlant2 = (ImageButton)e.Item.FindControl("imgPlant2");
        //                imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
        //                imgPlant2.Visible = false;
        //                imgRemoveApprover.Visible = false;

        //                Label lblPlantID = default(Label);
        //                lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //                lblPlantID.Visible = false;
        //                Label lblPlantName = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");

        //                if (string.IsNullOrEmpty(lblPlantName.Text))
        //                {
        //                    //e.Item.Visible = False
        //                    imgPlant1.Visible = false;
        //                    imgPlant2.Visible = false;
        //                    imgRemoveApprover.Visible = true;
        //                }

        //                LinkButton lnkconGrpName = default(LinkButton);
        //                lnkconGrpName = (LinkButton)e.Item.FindControl("lnkconGrpName");
        //                lnkconGrpName.Visible = true;
        //                lblConGrpName = (Label)e.Item.FindControl("lblconGrpName");
        //                lblConGrpName.Visible = false;
        //                //imgDeleteGroup.Attributes.Add("onclick", "return confirmSystemOwnerDelete('" & lblConGrpName.Text & "');")
        //                //ImgRemoveApprover.Attributes.Add("onclick", "return confirmPurchasingContactDelete('" & lblConGrpName.Text & "');")

        //                //Dim imgDeleteGroup As ImageButton = CType(e.Item.FindControl("imgDeleteGroup"), ImageButton)
        //                //Dim lnkcGrpName As Label = CType(e.Item.FindControl("lblconGrpName"), Label)
        //                //imgDeleteGroup.Attributes.Add("onclick", "return confirmPurchasingContactDelete('" & lnkcGrpName.Text & "');")
        //            }

        //            //Dim imgDeleteGroup As ImageButton = CType(e.Item.FindControl("imgDeleteGroup"), ImageButton)
        //            //'Dim lnkcGrpName As Label = CType(e.Item.FindControl("lblconGrpName"), Label)
        //            //imgDeleteGroup.Attributes.Add("onclick", "return confirmPurchasingContactDelete('" & lnkcGrpName.Text & "');")
        //            ImageButton imgDeleteGroup = (ImageButton)e.Item.FindControl("ImgRemoveApprover");
        //            Label lnkApproverName = (Label)e.Item.FindControl("lblconGrpName");

        //            imgDeleteGroup.Attributes.Add("onclick", "return confirmPurchasingContactDelete('" + lnkApproverName.Text + "');");

        //            break;

        //    }


        //    //Select Case e.Item.ItemType
        //    //    Case ListItemType.AlternatingItem, ListItemType.Item
        //    //        Dim imgDeleteGroup As ImageButton = CType(e.Item.FindControl("ImgRemoveApprover"), ImageButton)
        //    //        Dim lnkApproverName As Label = CType(e.Item.FindControl("lblconGrpName"), Label)

        //    //        imgDeleteGroup.Attributes.Add("onclick", "return confirmPurchasingContactDelete('" & lnkApproverName.Text & "');")
        //    //End Select






        //}


        protected void imgAddConcuGrp_Click(object sender, EventArgs e)
        {
            Response.Redirect("..\\Administration\\AddConcurrenceGroup.aspx");
        }

        protected void DeleteConcurrenceGroup(int pcID)
        {
            ConcurrenceGroup objDeleteConcGroup = new ConcurrenceGroup();

            returnvalue = -1;
            SqlParameter[] paramout = new SqlParameter[1];
            if (objDeleteConcGroup.DeleteConcurrenceGroup(pcID, ref paramout))
            {
                returnvalue = Convert.ToInt32(paramout[0].Value);
                if (returnvalue == 0)
                {
                    Script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);

                }
                else
                {
                    Script = "alert('" + ConfigurationManager.AppSettings["DeletedError"] + "')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                }
            }
        }

        protected void imgExpnadAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            FillConGroup();
        }

        protected void imgCollapseAll_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillConGroup();
        }

    }
}