using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Administration
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        #region "Member Variables"
        string strUserName;
        cls objSecurity = new Security();
        string strScript;
        string strCurrentStage;
        #endregion
        static string strUserRole;

        #region "Page Events"

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            strUserRole = System.Security.UserRole();
            if (strUserRole == "MUREO_Admin")
            {
                imgCreateEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgCreateEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgCreateEO.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgCreateEO.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }
            if (!IsPostBack)
            {
                imgNext.Visible = false;
                imgPrevious.Visible = false;
                FillMYEODataGrid();
            }
        }

        #endregion

        #region "DataGrid Events"
        public void NoApprovarList()
        {
            strScript = "<script>alert('Approvar list is not available.');</script>";
            Page.RegisterStartupScript("ClientScript", strScript);
        }

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	DisplayBoundColumnValues()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of commondname utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/22/07                Md.Abdul allaam             1.0           created
        //10/09/07                Md.Abdul Allaam             2.0          'Previous the links were
        //***************************************************

        public void DisplayBoundColumnValues(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "EONum_Link")
            {
                //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
                //following get the current stage of the Eo
                Label lnkStage = default(Label);
                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = lnkStage.Text;

                if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            else if (e.CommandName == "EOStage_Link")
            {
                //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
                //following gets the title of the EO
                LinkButton lblEOTitle = default(LinkButton);
                lblEOTitle = (LinkButton)e.Item.FindControl("hypEOTitle");
                string strEOTitle = lblEOTitle.Text;

                //following get the current stage of the Eo
                Label lnkStage = default(Label);
                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = lnkStage.Text;

                if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    //lblEOTitleVal.Text = strEOTitle
                    //FillEventInfoForEO(intEOID)
                }
                else
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    //lblEOTitleVal.Text = strEOTitle
                    //FillEventInfoForEO(intEOID)
                }
            }
            else if (e.CommandName == "EOTitle_Link")
            {
                //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
                //following get the current stage of the Eo
                Label lnkStage = default(Label);

                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = lnkStage.Text;
                if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));

                }
                else
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            else if (e.CommandName == "ModifiedDate_Link")
            {
                //following get the current stage of the Eo
                Label lnkStage = default(Label);
                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = lnkStage.Text;
                if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            else if (e.CommandName == "ReadOnly")
            {
                //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
                //following get the current stage of the Eo
                Label lnkStage = default(Label);
                string view = null;
                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = lnkStage.Text;
                if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
                {
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/ViewSiteTest.aspx?EoID={0}", intEOID));
                }
                else
                {
                    if (Strings.UCase(strStage) == Strings.UCase("Preliminary"))
                    {
                        view = "1";
                    }
                    else if (Strings.UCase(strStage) == Strings.UCase("Final"))
                    {
                        view = "2";
                    }
                    else if (Strings.UCase(strStage) == Strings.UCase("Closeout"))
                    {
                        view = "3";
                    }
                    int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", intEOID.ToString(), view.ToString(), "Report"));
                }
            }
            else if (e.CommandName == "Delete")
            {
                //Added by Abdul as the deleting of an EO has to be done with two confirmations i.e why below code.
                int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                Label lnkStage = default(Label);
                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                strCurrentStage = lnkStage.Text;

                string script = null;
                script = "<script>DeleteEO('" + intEOID + "','" + strCurrentStage + "');</script> ";
                Page.RegisterStartupScript("db_error_message", script);

            }
            else if (e.CommandName == "Stop")
            {
                int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "S", System.Security.UserName);
                if (intRetValue == 0)
                {
                    strScript = "<script>alert('" + ConfigurationSettings.AppSettings("EORecordStopSucc") + "');</script>";
                    Page.RegisterStartupScript("ClientScript", strScript);
                }
                else if (intRetValue == 1)
                {
                    strScript = "<script>alert('" + ConfigurationSettings.AppSettings("EORecordStopFail") + "');</script>";
                    Page.RegisterStartupScript("ClientScript", strScript);
                }

            }
            else if (e.CommandName == "CheckApproval")
            {
                //following get the current stage of the Eo
                Label lnkStage = default(Label);
                lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = lnkStage.Text;

                int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                //strCurrentStage = e.Item.Cells(4).Text
                strCurrentStage = strStage;

                DataSet dsApprovar = new DataSet();
                dsApprovar = BusinessObject.MUREO.BusinessObject.ClsMyEOs.ShowApprovals(intEOID, strCurrentStage);
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
                    Int16 colCount = dt.Columns.Count;
                    int rowLoop = 0;
                    int colLoop = 0;
                    StringBuilder sb = new StringBuilder();
                    string strApprovar = null;
                    for (rowLoop = 0; rowLoop <= rowCount - 1; rowLoop++)
                    {
                        //For colLoop = 0 To colCount - 1
                        // strApprovar = strApprovar & dt.Rows(rowLoop).Item(colLoop) & "\n"
                        strApprovar = strApprovar + dt.Rows[rowLoop][0] + "\\t\\t\\t" + dt.Rows[rowLoop][1] + "\\t\\t\\t" + dt.Rows[rowLoop][2] + "\\n";
                        //Next
                    }
                    if (!(strApprovar == string.Empty))
                    {
                        string script = null;
                        //Added by abdul on 31-jan-2008
                        //New code where the user can view the approvers in a show modal dialog box.
                        if (Strings.UCase(strCurrentStage) == Strings.UCase("Preliminary"))
                        {
                            script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:300px');</script>";
                            Page.RegisterStartupScript("clientscript", script);
                        }
                        else if (Strings.UCase(strCurrentStage) == Strings.UCase("Final"))
                        {
                            script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:400px');</script>";
                            Page.RegisterStartupScript("clientscript", script);
                        }
                        else if (Strings.UCase(strCurrentStage) == Strings.UCase("Closeout"))
                        {
                            script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:200px');</script>";
                            Page.RegisterStartupScript("clientscript", script);
                        }
                        //Previous code where the approvers are shown in a alert box where the format was not proper
                        //strScript = "<script>alert('" & strApprovar & "');</script>"
                        //Page.RegisterStartupScript("ClientScript", strScript)
                    }
                    else
                    {
                        strScript = "<script>alert('Approvar list is not available.');</script>";
                        Page.RegisterStartupScript("ClientScript", strScript);
                    }
                }

            }
            else if (e.CommandName == "Cancel")
            {
                int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
                int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "C", System.Security.UserName);
                if (intRetValue == 0)
                {
                    strScript = "<script>alert('" + ConfigurationSettings.AppSettings("CancelSuccessMsg") + "');</script>";
                    Page.RegisterStartupScript("ClientScript", strScript);
                    //dgdEventInfo.Visible = False
                    //lblEOTitleVal.Visible = False
                }
                else if (intRetValue == 1)
                {
                    strScript = "<script>alert('" + ConfigurationSettings.AppSettings("CancelErrMsg") + "');</script>";
                    Page.RegisterStartupScript("ClientScript", strScript);
                }
            }
            FillMYEODataGrid();
        }

        private void dgdMyEO_ItemDataBound(System.Object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Dim imgbDelete As ImageButton = CType(e.Item.FindControl("imgDelete"), ImageButton)
                //imgbDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();")
                ImageButton imgbStop = (ImageButton)e.Item.FindControl("imgStopEO");
                imgbStop.Attributes.Add("OnClick", "javascript:return confirmStop();");
                ImageButton imgbCancel = (ImageButton)e.Item.FindControl("imgCancel");
                imgbCancel.Attributes.Add("OnClick", "javascript:return confirmCancel();");
            }
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Center;
            e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Center;

            //Dim imgbDelete As ImageButton = CType(e.Item.FindControl("imgDelete"), ImageButton)
            //Dim imgbStop As ImageButton = CType(e.Item.FindControl("imgStop"), ImageButton)
            //If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            //    imgbDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();")
            //End If

            //Added by Abdul on 15-Sept-08 for changing the status from Approved to Completed.
            Label lnkStage = default(Label);
            lnkStage = (Label)e.Item.FindControl("hypEOStage1");
            if ((lnkStage != null))
            {
                if (Strings.UCase(lnkStage.Text) == Strings.UCase("CloseOut") & Strings.UCase(e.Item.Cells[5].Text) == Strings.UCase("Approved"))
                {
                    e.Item.Cells[5].Text = "Completed";
                }
            }
        }

        private void dgdMyEO_PageIndexChanged(System.Object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgdMyEO.CurrentPageIndex = e.NewPageIndex;
            //FillMYEODataGrid()
        }

        private void dgdMyEO_ItemSortCommand(System.Object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            if (Convert.ToString(viewState("StrSort")) == " Desc")
            {
                viewstate("StrSort") = " Asc";
            }
            else
            {
                viewstate("StrSort") = " Desc";
            }
            viewstate("SortExp") = e.SortExpression;
            FillMYEODataGrid();
        }
        #endregion

        #region "User Define Methods"

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

        public void PagerButtonClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string arg = sender.CommandArgument;

            switch (arg)
            {
                case "Next":
                    if ((dgdMyEO.CurrentPageIndex == (dgdMyEO.PageCount - 1)))
                    {
                        //Dim jvScript As String
                        //jvScript = "<script>alert('" & ConfigurationSettings.AppSettings("DataGridLastPage") & "');</script>"
                        //Page.RegisterStartupScript("ClientScript", jvScript)
                        imgNext.Enabled = false;
                        imgPrevious.Enabled = true;
                    }
                    else if ((dgdMyEO.CurrentPageIndex > 0) & (dgdMyEO.CurrentPageIndex < (dgdMyEO.PageCount - 1)))
                    {
                        imgNext.Enabled = true;
                        imgPrevious.Enabled = true;
                    }
                    if ((dgdMyEO.CurrentPageIndex < (dgdMyEO.PageCount - 1)))
                    {
                        dgdMyEO.CurrentPageIndex += 1;
                        imgPrevious.Enabled = true;
                        imgNext.Enabled = true;
                    }
                    break;
                case "Prev":
                    if ((dgdMyEO.CurrentPageIndex == 0))
                    {
                        //Dim jvScript As String
                        //jvScript = "<script>alert('" & ConfigurationSettings.AppSettings("DataGridFirstPage") & "');</script>"
                        //Page.RegisterStartupScript("ClientScript", jvScript)
                        imgPrevious.Enabled = false;
                        imgNext.Enabled = true;
                    }
                    else if (dgdMyEO.CurrentPageIndex > 0 & (dgdMyEO.CurrentPageIndex < (dgdMyEO.PageCount - 1)))
                    {
                        imgPrevious.Enabled = true;
                        imgNext.Enabled = true;
                    }
                    if ((dgdMyEO.CurrentPageIndex > 0))
                    {
                        dgdMyEO.CurrentPageIndex -= 1;
                        imgPrevious.Enabled = true;
                        imgNext.Enabled = true;
                    }
                    break;
                //Case "Last"
                //dgdMyEO.CurrentPageIndex = (dgdMyEO.PageCount - 1)
                //Case Else
                //dgdMyEO.CurrentPageIndex = Convert.ToInt32(arg)
            }
            FillMYEODataGrid();
        }

        private void NoDataForGrid()
        {
            strScript = "<script>alert('" + ConfigurationSettings.AppSettings("NoRec") + "');</script>";
            Page.RegisterStartupScript("ClientScript", strScript);
        }

        public void FillMYEODataGrid()
        {
            strUserName = objSecurity.UserName;
            //strUserName = "Surendra Bolla-su"

            DataSet dsSeedData = new DataSet();
            dsSeedData = BusinessObject.MUREO.BusinessObject.ClsMyEOs.GetMyEOs(strUserName);
            if (dsSeedData == null)
            {
                NoDataForGrid();
                return;
            }
            else if (dsSeedData.Tables.Count == 0)
            {
                //dgdMyEO.Visible = False
                NoDataForGrid();
                return;
            }
            else if (dsSeedData.Tables[0].Rows.Count == 0)
            {
                //dgdMyEO.Visible = False
                NoDataForGrid();
                return;
            }
            //dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data")
            dgdMyEO.DataSource = dsSeedData.Tables[0].DefaultView;
            if (((dsSeedData.Tables[0].Rows.Count) <= dgdMyEO.PageSize))
            {
                imgNext.Visible = false;
                imgPrevious.Visible = false;
                if (dgdMyEO.CurrentPageIndex != 0)
                {
                    dgdMyEO.CurrentPageIndex -= 1;
                }
            }
            else if (dgdMyEO.Items.Count % dgdMyEO.PageSize == 1 & dgdMyEO.CurrentPageIndex == dgdMyEO.PageCount - 1 & dgdMyEO.CurrentPageIndex != 0)
            {
                dgdMyEO.CurrentPageIndex -= 1;
                imgNext.Visible = true;
                imgPrevious.Visible = true;
                //End If
            }
            else
            {
                imgNext.Visible = true;
                imgPrevious.Visible = true;
            }

            //Code added by Vijay
            if ((viewState("SortExp") != null))
            {
                string SortExp = null;
                string strSort = null;
                DataView dv = new DataView(dsSeedData.Tables[0]);
                //Create a data view for the sort
                string imgAsc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                string imgDesc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                SortExp = viewState("SortExp");
                strSort = SortExp + viewState("StrSort");
                dv.Sort = strSort;
                dgdMyEO.DataSource = dv;
                foreach (DataGridColumn col in dgdMyEO.Columns)
                {
                    string header_text = col.HeaderText;
                    int position = col.HeaderText.IndexOf("&nbsp;");
                    if (col.SortExpression == SortExp)
                    {
                        if (position > -1)
                        {
                            header_text = col.HeaderText.Substring(0, position);
                        }
                        if (viewState("StrSort") == " Asc")
                        {
                            col.HeaderText = string.Concat(header_text, imgAsc);
                        }
                        else
                        {
                            col.HeaderText = string.Concat(header_text, imgDesc);
                        }
                    }
                    else
                    {
                        if (position > -1)
                        {
                            header_text = col.HeaderText.Substring(0, position);
                            col.HeaderText = header_text;
                        }
                    }
                }
            }

            dgdMyEO.DataBind();

            //'Following code is for enabling and disabling the links on the form based on the user roles.
            //If strUserRole = "MUREO_Admin" Then
            //    EnableDisableLinks(True)
            //ElseIf strUserRole = "MUREO_Editors" Then
            //    EnableDisableLinks(True)
            //ElseIf strUserRole = "MUREO_Readers" Then
            //    EnableDisableLinks(False)
            //ElseIf strUserRole = "Readers" Then
            //    EnableDisableLinks(False)
            //End If

            //following code is for hiding and showing of buttons based on the condition.

            for (int numRows = 0; numRows <= dgdMyEO.Items.Count - 1; numRows++)
            {
                //following code get the EO Title of the Eo
                //Dim lblEoTitle As Label = CType(dgdMyEO.Items(numRows).FindControl("hypEONumber"), Label)

                LinkButton lblEONumber = default(LinkButton);
                lblEONumber = (LinkButton)dgdMyEO.Items(numRows).FindControl("hypEONumber");
                string strEONumber = lblEONumber.Text;
                //If strEONumber Is String.Empty Then
                //    dgdMyEO.Items(numRows).FindControl("hypEONumber") = "New"
                //End If

                //following code get the current stage of the Eo
                Label lnkStage = default(Label);
                lnkStage = (Label)dgdMyEO.Items(numRows).FindControl("hypEOStage1");
                string strStage = lnkStage.Text;

                ImageButton imgApprovar = default(ImageButton);
                imgApprovar = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgCheckApproval");
                if (Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Draft") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("&nbsp;") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Close-Out") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Admin Close-Out"))
                {
                    imgApprovar.Visible = false;
                }
                else
                {
                    imgApprovar.Visible = true;
                }

                //Displaying of cancel button when EO has a EO Number.
                ImageButton imgCancel = default(ImageButton);
                imgCancel = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgCancel");
                if (strEONumber == string.Empty)
                {
                    imgCancel.Visible = false;
                }
                else if (Strings.UCase(Strings.Trim(strEONumber)) == "NEW EO")
                {
                    imgCancel.Visible = false;
                    //Modified by Abdul on 15-Sept-08 for considering completed status
                }
                else if (Strings.UCase(strStage) == Strings.UCase("closeout") & Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Routed") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Approved") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Completed"))
                {
                    imgCancel.Visible = false;
                }
                else
                {
                    imgCancel.Visible = true;
                }

                //Hiding of Delete button when EO has a EO Number.
                ImageButton imgDelete = default(ImageButton);
                imgDelete = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgDelete");
                if (strEONumber == string.Empty & Strings.UCase(strStage) == Strings.UCase("Preliminary"))
                {
                    imgDelete.Visible = true;
                    //Added by abdul on 26-feb-2008 for checking of NewEO as the eo number
                }
                else if (Strings.UCase(Strings.Trim(strEONumber)) == Strings.UCase(Strings.Trim("NEW EO")) & Strings.UCase(strStage) == Strings.UCase("Preliminary"))
                {
                    imgDelete.Visible = true;
                }
                else if (Strings.UCase(Strings.Trim(strEONumber)) == Strings.UCase(Strings.Trim("NEW EO")) & Strings.UCase(strStage) == Strings.UCase("Site Test") & !(Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Close-Out")))
                {
                    imgDelete.Visible = true;
                }
                else if (strEONumber == string.Empty & Strings.UCase(strStage) == Strings.UCase("Site Test") & !(Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Close-Out")))
                {
                    imgDelete.Visible = true;
                }
                else if (Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Close-Out"))
                {
                    imgDelete.Visible = false;
                }
                else
                {
                    imgDelete.Visible = false;
                }

                //Displaying of stop button when EO is in Routed stage.
                ImageButton imgStop = default(ImageButton);
                imgStop = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgStopEO");
                if (Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Routed") & !(Strings.UCase(strStage) == Strings.UCase("closeout")))
                {
                    imgStop.Visible = true;
                }
                else if (strStage == "Site Test" | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Draft"))
                {
                    imgStop.Visible = false;
                    //Modified by Abdul on 15-Sept-08 for considering completed status
                }
                else if (Strings.UCase(strStage) == Strings.UCase("closeout") & Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Routed") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Approved") | Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Completed"))
                {
                    imgStop.Visible = false;
                }

                //Disabling a particular  row of site test when the site test is close out
                if (Strings.UCase(dgdMyEO.Items(numRows).Cells(5).Text) == Strings.UCase("Close-Out"))
                {
                    //Following code to get EO title of the EO
                    LinkButton lnkEOTitle = default(LinkButton);
                    lnkEOTitle = (LinkButton)dgdMyEO.Items(numRows).Cells(1).FindControl("hypEOTitle");

                    //Following code to get Modified date of the EO
                    LinkButton lnkModifiedDate = default(LinkButton);
                    lnkModifiedDate = (LinkButton)dgdMyEO.Items(numRows).FindControl("hypModifiedDate");

                    //lblEONumber.Enabled = False
                    //lnkStage.Enabled = False
                    //lnkEOTitle.Enabled = False
                    //lnkModifiedDate.Enabled = False


                    //New code

                    Label lblEoTitle = default(Label);
                    lblEoTitle = (Label)dgdMyEO.Items(numRows).Cells(1).FindControl("lblEOTitle");
                    Label lblENum = default(Label);
                    lblENum = (Label)dgdMyEO.Items(numRows).Cells(1).FindControl("lblEnum");
                    Label lblModiLink = default(Label);
                    lblModiLink = (Label)dgdMyEO.Items(numRows).Cells(1).FindControl("lblModiLink");
                    lnkEOTitle.Visible = false;
                    lblEoTitle.Visible = true;
                    lnkStage.Visible = true;
                    lblEONumber.Visible = false;
                    lblENum.Visible = true;
                    lblModiLink.Visible = true;
                    lnkModifiedDate.Visible = false;
                    //End of New code
                }
            }

        }

        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgdMyEO.Items.Count - 1; numRows++)
            {
                ImageButton imgApprovar = default(ImageButton);
                imgApprovar = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgCheckApproval");
                imgApprovar.Enabled = optBool;
                //Displaying of cancel button when EO has a EO Number.
                ImageButton imgCancel = default(ImageButton);
                imgCancel = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgCancel");
                imgCancel.Enabled = optBool;
                //Hiding of Delete button when EO has a EO Number.
                ImageButton imgDelete = default(ImageButton);
                imgDelete = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgDelete");
                imgDelete.Enabled = optBool;
                //Displaying of stop button when EO is in Routed stage.
                ImageButton imgStop = default(ImageButton);
                imgStop = (ImageButton)dgdMyEO.Items(numRows).FindControl("imgStopEO");
                imgStop.Enabled = optBool;
                LinkButton lnkEONum = default(LinkButton);
                lnkEONum = (LinkButton)dgdMyEO.Items(numRows).FindControl("hypEONumber");
                lnkEONum.Enabled = optBool;
                LinkButton lnkEOTitle = default(LinkButton);
                lnkEOTitle = (LinkButton)dgdMyEO.Items(numRows).FindControl("hypEOTitle");
                lnkEOTitle.Enabled = optBool;
                LinkButton lnkEOModDate = default(LinkButton);
                lnkEOModDate = (LinkButton)dgdMyEO.Items(numRows).FindControl("hypModifiedDate");
                lnkEOModDate.Enabled = optBool;
            }
        }

        //Sub FillEventInfoForEO(ByVal parIntEOID As Integer)
        //    Dim dsEventInfo As New DataSet
        //    dsEventInfo = BusinessObject.MUREO.BusinessObject.ClsMyEOs.FetchEventInfoforEO(parIntEOID)
        //    If dsEventInfo Is Nothing Then
        //        'dgdEventInfo.Visible = False
        //        NoDataForGrid()
        //        Exit Sub
        //    ElseIf dsEventInfo.Tables.Count = 0 Then
        //        'dgdEventInfo.Visible = False
        //        NoDataForGrid()
        //        Exit Sub
        //    ElseIf dsEventInfo.Tables(0).Rows.Count = 0 Then
        //        'dgdEventInfo.Visible = False
        //        NoDataForGrid()
        //        Exit Sub
        //    Else
        //        'dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data")
        //        dgdEventInfo.DataSource = dsEventInfo.Tables(0).DefaultView
        //        dgdEventInfo.DataBind()
        //    End If

        //End Sub

        #endregion

        #region "Click Events"

        private void imgCreateEO_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("../Common/NewEO.aspx");
        }
        #endregion

    }
}