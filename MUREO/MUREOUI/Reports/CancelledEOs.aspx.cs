using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Reports
{
    public partial class CancelledEOs : System.Web.UI.Page
    {
        clsSecurity sec = new clsSecurity();
        #region "Member Variables"

        DataSet DsCancelEO;
        string strScript;
        string strSort;
        static string SortExp;
        static string strUserName;
        clsSecurity objSecurity = new clsSecurity();
        static string strUserRole;

        #endregion
    


        #region "Page Events"
        protected void dgdCancelledEO_PageIndexChanged(object sender, EventArgs e)
        {
            FillCancelledEOs();
        }
        protected void Page_Load(System.Object sender, System.EventArgs e)
        {
            strUserRole = objSecurity.UserRole();
            strUserName = objSecurity.UserName;
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
                //Response.Redirect("~/Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgCreateEO.Enabled = false;
                // Response.Redirect("~/Common/Home.aspx")
            }
            if (!IsPostBack)
            {               
                FillCancelledEOs();
            }
        }
        #endregion

        #region "User Define Methods"

        //public void PageButtonVisibility(bool optVisible)
        //{
        //    imgNext.Visible = optVisible;
        //    imgPrevious.Visible = optVisible;
        //}

        //  **************PagerButtonClick******************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	PagerButtonClick()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for custom paging of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/12/07                Md.Abdul allaam             1.0           created
        //***************************************************

        //public void PagerButtonClick(object sender, CommandEventArgs e)
        //{
        //    try
        //    {                
        //        switch (Convert.ToString(e.CommandArgument))
        //        {
        //            case "Next":
        //                if ((dgdCancelledEO.PageIndex < (dgdCancelledEO.VisibleRowCount - 1)))
        //                {
        //                    dgdCancelledEO.PageIndex += 1;
        //                    imgNext.Enabled = true;
        //                    imgPrevious.Enabled = true;
        //                }
        //                if ((dgdCancelledEO.PageIndex == (dgdCancelledEO.VisibleRowCount - 1)))
        //                {
        //                    //Dim jvScript As String
        //                    //jvScript = "alert('" & ConfigurationSettings.AppSettings("DataGridLastPage") & "');"
        //                    //Page.RegisterStartupScript("ClientScript", jvScript)
        //                    imgNext.Enabled = false;
        //                    imgPrevious.Enabled = true;
        //                }
        //                else if ((dgdCancelledEO.PageIndex > 0) & (dgdCancelledEO.PageIndex < (dgdCancelledEO.VisibleRowCount - 1)))
        //                {
        //                    imgNext.Enabled = true;
        //                    imgPrevious.Enabled = true;
        //                }
        //                break;
        //            case "Prev":
        //                if ((dgdCancelledEO.PageIndex > 0))
        //                {
        //                    dgdCancelledEO.PageIndex -= 1;
        //                    imgNext.Enabled = true;
        //                    imgPrevious.Enabled = true;
        //                }
        //                if ((dgdCancelledEO.PageIndex == 0))
        //                {
        //                    //Dim jvScript As String
        //                    //jvScript = "alert('" & ConfigurationSettings.AppSettings("DataGridFirstPage") & "');"
        //                    //Page.RegisterStartupScript("ClientScript", jvScript)
        //                    imgPrevious.Enabled = false;
        //                    imgNext.Enabled = true;
        //                }
        //                else if (dgdCancelledEO.PageIndex > 0 & (dgdCancelledEO.PageIndex < (dgdCancelledEO.VisibleRowCount - 1)))
        //                {
        //                    imgPrevious.Enabled = true;
        //                    imgNext.Enabled = true;
        //                }
        //                break;
        //            //Case "Last"
        //            //dgdMyEO.PageIndex = (dgdMyEO.VisibleRowCount - 1)
        //            //Case Else
        //            //dgdMyEO.PageIndex = Convert.ToInt32(arg)
        //        }

        //        FillCancelledEOs();
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

        public void NoDataForGrid()
        {
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillCancelledEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Nothing
        //Purpose	    :   filling the datagrid with cancelled EOs data.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/04/07                Md.Abdul allaam             1.0           created
        //26/10/07                Md.Abdul Allaam             2.0        LDAP security implemented where it will
        //display the cancelled eos to admin and to originator , cooriginator and approver
        //***************************************************
        public void FillCancelledEOs()
        {
            try
            {
                DsCancelEO = new DataSet();
                ClsMyEOs clsmyEo = new ClsMyEOs();
                if (clsmyEo.GetCancelledEOs('C', strUserName, ref DsCancelEO))
                {
                    if (DsCancelEO == null)
                    {
                        NoDataForGrid();
                        return;
                    }
                    else if (DsCancelEO.Tables.Count == 0)
                    {
                        NoDataForGrid();
                        return;
                    }
                    else if (DsCancelEO.Tables[0].Rows.Count == 0)
                    {
                        NoDataForGrid();
                        return;
                    }
                    else
                    {
                        dgdCancelledEO.DataSource = DsCancelEO.Tables[0].DefaultView;
                        //if (((DsCancelEO.Tables[0].Rows.Count) <= dgdCancelledEO.PageCount))
                        //{
                        //    PageButtonVisibility(false);
                        //    If dgdCancelledEO.PageIndex <> 0 Then
                        //    dgdCancelledEO.PageIndex -= 1
                        //    End If
                        //}
                        //else
                        //{
                        //    PageButtonVisibility(true);
                        //}
                        //Code added by Vijay on 09/26/2007
                        //if ((ViewState["SortExp"] != null))
                        //{
                        //    DataView dv = new DataView(DsCancelEO.Tables[0]);
                        //    //Create a data view for the sort
                        //    string imgAsc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                        //    string imgDesc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                        //    SortExp = Convert.ToString(ViewState["SortExp"]);
                        //    strSort = SortExp + Convert.ToString(ViewState["SortExp"]);
                        //    dv.Sort = strSort;
                        //    dgdCancelledEO.DataSource = dv;
                        //    foreach (DataGridColumn col in dgdCancelledEO.Columns)
                        //    {
                        //        string header_text = col.HeaderText;
                        //        int position = col.HeaderText.IndexOf("&nbsp;");
                        //        if (col.SortExpression == SortExp)
                        //        {
                        //            if (position > -1)
                        //            {
                        //                header_text = col.HeaderText.Substring(0, position);
                        //            }
                        //            if (ViewState["SortExp"] == " Asc")
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
                        dgdCancelledEO.DataBind();
                        // 'Following code is for enabling and disabling the links on the form based on the logged in username.
                        //If strOriginator = strUser Then
                        //    EnableDisableLinks(True)
                        if (strUserRole == "MUREO_Admin")
                        {
                            EnableDisableLinks(true);
                        }
                        else
                        {
                            EnableDisableLinks(false);
                        }
                        for (int numRows = 0; numRows <= dgdCancelledEO.VisibleRowCount - 1; numRows++)
                        {
                            Label lblISApproved = default(Label);
                            lblISApproved = (Label)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["Last Modified"], "lblISApprovar");
                            if (lblISApproved != null)
                            {
                                if (lblISApproved.Text.ToUpper() == "YES")
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
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgdCancelledEO.VisibleRowCount - 1; numRows++)
            {
                LinkButton lnkEONum = default(LinkButton);
                lnkEONum = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["EO"], "hypEONumber");
                    //dgdCancelledEO.Items[numRows].FindControl("hypEONumber");
                if (lnkEONum != null && (!optBool))
                    lnkEONum.Enabled = optBool;               
                LinkButton lnkEOTitle = default(LinkButton);
                lnkEOTitle = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["EO Title"], "hypEOTitle");
                    //dgdCancelledEO.Items[numRows].FindControl("hypEOTitle");                
                if (lnkEOTitle != null && (!optBool))
                    lnkEOTitle.Enabled = optBool;                
                LinkButton lnkEOModDate = default(LinkButton);
                lnkEOModDate = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["Last Modified"], "Linkbutton1");
                    //dgdCancelledEO.Items[numRows].FindControl("hypModifiedDate");                                
                if (lnkEOModDate != null && (!optBool))
                    lnkEOModDate.Enabled = optBool;
            }
        }
        protected void dgdOnRouteFYI_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView dgdOnRouteFYI = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    LinkButton hypEONumber = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdCancelledEO.Columns["EO"], "hypEONumber");
                    Label lblOrig = (Label)dgdCancelledEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdCancelledEO.Columns["Originator"], "lblOriginator");
                    if (hypEONumber.Enabled)
                    {
                        if (lblOrig.Text.ToUpper() == sec.UserName.ToUpper())
                        {
                            hypEONumber.Attributes.Add("OnClick", "javascript:return confirmReactivate();");
                        }

                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        //private void dgdCancelledEO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        LinkButton lnkEOTitle = (LinkButton)e.Item.FindControl("hypEONumber");
        //        Label originator = (Label)e.Item.FindControl("lblOriginator");
        //        if (lnkEOTitle.Enabled == true)
        //        {
        //            if (Strings.UCase(originator.Text) == Strings.UCase(System.Security.UserName))
        //            {
        //                lnkEOTitle.Attributes.Add("OnClick", "javascript:return confirmReactivate();");
        //            }

        //        }
        //    }
        //}

        public void EnableDisableLinksForRow(bool optBool, int numRows)
        {
            //following code is for hiding and showing of buttons based on the condition.
            LinkButton lnkEONum = default(LinkButton);
            lnkEONum = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["EO #"], "hypEONumber");            
            if (lnkEONum != null && (!optBool))
                lnkEONum.Enabled = optBool;
            LinkButton lnkEOTitle = default(LinkButton);
            lnkEOTitle = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["EO Title"], "hypEOTitle");            
            if (lnkEOTitle != null && (!optBool))
                lnkEOTitle.Enabled = optBool;
            LinkButton lnkEOModDate = default(LinkButton);
            lnkEOModDate = (LinkButton)dgdCancelledEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdCancelledEO.Columns["Last Modified"], "Linkbutton1");            
            if (lnkEOModDate != null && (!optBool))
                lnkEOModDate.Enabled = optBool;
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
        //***************************************************
        public void DisplayBoundColumnValues(object sender, DataGridCommandEventArgs e)
        {
            
        }
        #endregion

        #region "Click Events"

        protected void imgCreateEO_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/NewEO.aspx");
        }
        #endregion

        #region "DataGrid Events"


        //protected void dgdCancelledEO_SortCommand(object source, DataGridSortCommandEventArgs e)
        //{

        //}

        //protected void dgdCancelledEO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //if (e.CommandName == "Sort")
        //    //{
        //    //    if (Convert.ToString(ViewState["SortExp"]) == " Desc")
        //    //    {
        //    //        ViewState["SortExp"] = " Asc";
        //    //    }
        //    //    else
        //    //    {
        //    //        ViewState["SortExp"] = " Desc";
        //    //    }
        //    //    ViewState["SortExp"] = e.CommandArgument;
        //    //    FillCancelledEOs();
        //    //    return;
        //    //}
        //    //int intEOID = Convert.ToInt32(dgdCancelledEO.DataKeys[e.Item.ItemIndex]);
        //    //if (e.CommandName == "EONum_Link")
        //    //{

        //    //    if (dgdCancelledEO.Items[e.Item.ItemIndex].Cells[3].Text == "Site Test")
        //    //    {
        //    //        int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.SetEOActive(intEOID, strUserName);
        //    //        if (intRetValue == 0)
        //    //        {
        //    //            strScript = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["EOActivationSuccess"]) + "');";
        //    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    //            Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
        //    //        }
        //    //        else if (intRetValue == 1)
        //    //        {
        //    //            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
        //    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    //        }
        //    //        else
        //    //        {
        //    //            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
        //    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        //Dim intEOID As Integer = CInt(dgdMyEO.DataKeys(e.Item.ItemIndex))
        //    //        int intRetValue = ClsMyEOs.SetEOActive(intEOID, strUserName);
        //    //        if (intRetValue == 0)
        //    //        {
        //    //            strScript = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["EOActivationSuccess"]) + "');";
        //    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    //            Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //    //        }
        //    //        else if (intRetValue == 1)
        //    //        {
        //    //            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
        //    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    //        }
        //    //        else
        //    //        {
        //    //            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
        //    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //    //        }
        //    //    }
        //    //}
        //    //else if (e.CommandName == "EOTitle_Link")
        //    //{
        //    //    if (dgdCancelledEO.Items[e.Item.ItemIndex].Cells[3].Text == "Site Test")
        //    //    {
        //    //        Response.Redirect(string.Format("~/Common/viewSiteTest.aspx?EoID={0}", intEOID));
        //    //    }
        //    //    else
        //    //    {
        //    //        //Response.Redirect(String.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID))
        //    //        Response.Redirect("~/Common/ViewEO.aspx?EO_ID=" + intEOID.ToString());
        //    //    }
        //    //}
        //    //else if (e.CommandName == "ModifiedDate_Link")
        //    //{
        //    //    if (dgdCancelledEO.Items[e.Item.ItemIndex].Cells[3].Text == "Site Test")
        //    //    {
        //    //        Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
        //    //    }
        //    //    else
        //    //    {
        //    //        //Response.Redirect(String.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID))
        //    //        Response.Redirect("~/Common/ViewEO.aspx?EO_ID=" + intEOID.ToString());
        //    //    }
        //    //}


        //}
        
        protected void hypModifiedDate_Command(object sender, CommandEventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            if (e.CommandName != null)
            {
                if (lkb.Attributes["CurrentStage"].ToString() == "Site Test")
                {
                    Response.Redirect("~/Common/SiteTest.aspx?From=EDIT&EoID=" + e.CommandName + "&Page=AllEOs");
                }
                else
                {                    
                    Response.Redirect("~/Common/ViewEO.aspx?EO_ID=" + e.CommandName.ToString());
                }
            }
        }
        protected void EOTitle_Link_Command(object sender, CommandEventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            if (e.CommandName != null)
            {
                if (lkb.Attributes["CurrentStage"].ToString() == "Site Test")
                {
                    Response.Redirect("~/Common/viewSiteTest.aspx?EoID="+Convert.ToString(e.CommandName));
                }
                else
                {                    
                    Response.Redirect("~/Common/ViewEO.aspx?EO_ID=" + Convert.ToString(e.CommandName));
                }
            }
        }
        protected void EONum_Link_Command(object sender, CommandEventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            if (e.CommandName != null)
            {
                if (lkb.Attributes["CurrentStage"].ToString() == "Site Test")
                {
                    int intRetValue = -1;
                    ClsMyEOs clsmeo = new ClsMyEOs();
                    SqlParameter[] paramout = new SqlParameter[1];

                    if (clsmeo.SetEOActive(Convert.ToInt32(e.CommandName), strUserName, ref paramout))
                    {
                        intRetValue = Convert.ToInt32(paramout[0].Value);
                        if (intRetValue == 0)
                        {
                            strScript = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["EOActivationSuccess"]) + "');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                            Response.Redirect("~/Common/SiteTest.aspx?From=EDIT&EoID=" + e.CommandName + "&Page=AllEOs");
                        }
                        else if (intRetValue == 1)
                        {
                            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                        }
                        else
                        {
                            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                        }
                    }
                }
                else
                {
                    //Dim intEOID As Integer = CInt(dgdMyEO.DataKeys(e.Item.ItemIndex))
                    int intRetValue = 0;
                        //ClsMyEOs.SetEOActive(intEOID, strUserName);
                     ClsMyEOs clsmeo = new ClsMyEOs();
                    SqlParameter[] paramout = new SqlParameter[1];

                    if (clsmeo.SetEOActive(Convert.ToInt32(e.CommandName), strUserName, ref paramout))
                    {
                        intRetValue = Convert.ToInt32(paramout[0].Value);
                        if (intRetValue == 0)
                        {
                            strScript = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["EOActivationSuccess"]) + "');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                            Response.Redirect("~/Common/NewEO.aspx?From=ForEOEdit&EOID=" + e.CommandName);
                        }
                        else if (intRetValue == 1)
                        {
                            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                        }
                        else
                        {
                            strScript = "alert('" + ConfigurationManager.AppSettings["EOActivationFail"].ToString() + "');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                        }
                    }
                }
            }
        }
        #endregion

        //protected void dgdCancelledEO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        LinkButton lnkEOTitle = (LinkButton)e.Item.FindControl("hypEONumber");
        //        Label originator = (Label)e.Item.FindControl("lblOriginator");
        //        if (lnkEOTitle.Enabled == true)
        //        {
        //            if (originator.Text.ToUpper() == objSecurity.UserName.ToUpper())
        //            {
        //                lnkEOTitle.Attributes.Add("OnClick", "javascript:return confirmReactivate();");
        //            }

        //        }
        //    }
        //}

    }
}