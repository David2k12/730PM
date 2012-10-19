using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;
using System.Configuration;
using System.Data;
using DevExpress.Web.ASPxGridView;
using MUREOBAL;

namespace MUREOUI.Reports
{
    public partial class MyEOsAwaiting : System.Web.UI.Page
    {
        //string strUserName;
        clsSecurity objSecurity = null;
        string strScript;
        static string strUserRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserName = string.Empty;
            objSecurity = new clsSecurity();
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
            }
            else if (strUserRole == "Readers")
            {
                imgCreateEO.Enabled = false;
            }
            if (!IsPostBack)
            {
               // PageButtonVisibility(false);
                FillAwaitingEOs(strUserName);
            }

        }

        #region "User Define Methods"
        public void PageButtonVisibility(bool optVisible)
        {
           //imgPrevious.Visible = optVisible;
            //imgNext.Visible = optVisible;
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

       /* public void PagerButtonClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                string arg = sender.CommandArgument;
                switch (arg)
                {
                    case "Next":

                        if ((dgdMyEOsAwaiting.CurrentPageIndex < (dgdMyEOsAwaiting.PageCount - 1)))
                        {
                            dgdMyEOsAwaiting.CurrentPageIndex += 1;
                            imgNext.Enabled = true;
                            imgPrevious.Enabled = true;
                        }
                        if ((dgdMyEOsAwaiting.CurrentPageIndex == (dgdMyEOsAwaiting.PageCount - 1)))
                        {
                            //Dim jvScript As String
                            //jvScript = "<script>alert('" & ConfigurationSettings.AppSettings("DataGridLastPage") & "');</script>"
                            //Page.RegisterStartupScript("ClientScript", jvScript)
                            imgNext.Enabled = false;
                            imgPrevious.Enabled = true;

                        }
                        else if ((dgdMyEOsAwaiting.CurrentPageIndex >= 0) & (dgdMyEOsAwaiting.CurrentPageIndex < (dgdMyEOsAwaiting.PageCount - 1)))
                        {
                            imgNext.Enabled = true;
                            imgPrevious.Enabled = true;
                        }
                        break;
                    case "Prev":

                        if ((dgdMyEOsAwaiting.CurrentPageIndex > 0))
                        {
                            dgdMyEOsAwaiting.CurrentPageIndex -= 1;
                            imgNext.Enabled = true;
                            imgPrevious.Enabled = true;
                        }
                        if ((dgdMyEOsAwaiting.CurrentPageIndex == 0))
                        {
                            //Dim jvScript As String
                            //jvScript = "<script>alert('" & ConfigurationSettings.AppSettings("DataGridFirstPage") & "');</script>"
                            //Page.RegisterStartupScript("ClientScript", jvScript)
                            imgPrevious.Enabled = false;
                            imgNext.Enabled = true;
                        }
                        else if (dgdMyEOsAwaiting.CurrentPageIndex > 0 & (dgdMyEOsAwaiting.CurrentPageIndex < (dgdMyEOsAwaiting.PageCount - 1)))
                        {
                            imgPrevious.Enabled = true;
                            imgNext.Enabled = true;
                        }
                        break;
                    //Case "Last"
                    //dgdMyEO.CurrentPageIndex = (dgdMyEO.PageCount - 1)
                    //Case Else
                    //dgdMyEO.CurrentPageIndex = Convert.ToInt32(arg)
                }
                FillAwaitingEOs(strGlobalOriginator);
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "<script>alert('" + ex.Message + "');</script> ";
                Page.RegisterStartupScript("clientscript", script);
            }
        }*/

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAwaitingEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in normal form.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/07/07                Md.Abdul allaam             1.0           created
        //09/19/07                Md.Abdul allaam             2.0           tree view has been removed and only
        //single data grid will show the values.
        //10/25/07                Md.Abdul Allaam             3.0           Function will accept only one parameter i.e the 
        //originator name which will display the EO's in close out - routed stage.the name passed in the function 
        //will have the originator and the cooriginator name checked and displays there related EOs.
        //***************************************************

        //ByVal parPlantID As Integer,
        private void FillAwaitingEOs(string strOriginator)
        {
            DataSet dsSelectEOs = null;
            ClsMyEOs objEOs = null;
            try
            {
                dsSelectEOs = new DataSet();
                objEOs = new ClsMyEOs();
                if (objEOs.GetAwaitingCloseOutSelectedEO(strOriginator, ref dsSelectEOs))
                {

                    //BusinessObject.MUREO.BusinessObject.ClsMyEOs objEOs = new BusinessObject.MUREO.BusinessObject.ClsMyEOs();
                    //dsSelectEOs = objEOs.GetAwaitingCloseOutSelectedEO(strOriginator);

                    if (dsSelectEOs == null)
                    {
                        NoRecords();
                        NoDataForGrid();
                    }
                    else if (dsSelectEOs.Tables.Count == 0)
                    {
                        NoRecords();
                        NoDataForGrid();
                    }
                    else if (dsSelectEOs.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        NoDataForGrid();
                    }
                    else if (dsSelectEOs.Tables[0].Rows.Count > 0)
                    {
                        dgdMyEOsAwaiting.DataSource = dsSelectEOs.Tables[0].DefaultView;
                        /*if (((dsSelectEOs.Tables[0].Rows.Count) <= dgdMyEOsAwaiting.PageSize))
                        {
                            PageButtonVisibility(false);
                        }
                        else
                        {
                            PageButtonVisibility(true);
                        }*/

                        if (((dsSelectEOs.Tables[0].Rows.Count) <= dgdMyEOsAwaiting.VisibleRowCount))
                        {
                            //PageButtonVisibility(false);
                            if (dgdMyEOsAwaiting.PageIndex != 0)
                            {
                                dgdMyEOsAwaiting.PageIndex -= 1;
                            }
                        }
                        else
                        {
                            //PageButtonVisibility(true);
                        }

                        
                        //Code added by Vijay
                        /*if ((Convert.ToString(ViewState["SortExp"]) != ""))
                        {
                            string SortExp = null;
                            string strSort = null;
                            DataView dv = new DataView(dsSelectEOs.Tables[0]);
                            //Create a data view for the sort
                            string imgAsc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                            string imgDesc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                            SortExp = Convert.ToString(ViewState["SortExp"]);
                            strSort = SortExp + Convert.ToString(ViewState["StrSort"]);
                            dv.Sort = strSort;
                            dgdMyEOsAwaiting.DataSource = dv;
                            foreach (DataGridColumn col in dgdMyEOsAwaiting.Columns)
                            {
                                string header_text = col.HeaderText;
                                int position = col.HeaderText.IndexOf(" ");
                                if (col.SortExpression == SortExp)
                                {
                                    if (position > -1)
                                    {
                                        header_text = col.HeaderText.Substring(0, position);
                                    }
                                    if (Convert.ToString(ViewState["StrSort"]) == " Asc")
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
                        }*/

                        dgdMyEOsAwaiting.DataBind();
                        dgdMyEOsAwaiting.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //string script = null;
               // string exMessage = null;
               // exMessage = ex.Message.Replace("'", " ");
                //script = "<script>alert('" + ex.Message + "');</script> ";
                //Page.RegisterStartupScript("clientscript", script);
            }
        }

        private void NoDataForGrid()
        {
            dgdMyEOsAwaiting.DataSource = null;
            dgdMyEOsAwaiting.Visible = false;
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
            //for (int numRows = 0; numRows <= dgdMyEOsAwaiting.Items.Count - 1; numRows++)
            for (int numRows = 0; numRows <= dgdMyEOsAwaiting.VisibleRowCount - 1; numRows++)
            {
                /*LinkButton lnkEONum = default(LinkButton);
                lnkEONum = (LinkButton)dgdMyEOsAwaiting.Items(numRows).FindControl("hypEONumber");
                lnkEONum.Enabled = optBool;
                LinkButton lnkEOTitle = default(LinkButton);
                lnkEOTitle = (LinkButton)dgdMyEOsAwaiting.Items(numRows).FindControl("hypEOTitle");
                lnkEOTitle.Enabled = optBool;*/

                LinkButton lnkEONum = (LinkButton)dgdMyEOsAwaiting.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEOsAwaiting.Columns["EO Num"], "hypEONumber");
                lnkEONum.Enabled = optBool;
                LinkButton lnkEOTitle = (LinkButton)dgdMyEOsAwaiting.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEOsAwaiting.Columns["EO Title"], "hypEOTitle");
                lnkEOTitle.Enabled = optBool;
            }
        }

        private void NoRecords()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRec"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "ClientScript", strScript);
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
        /*public void DisplayBoundColumnValues(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "EONum_Link")
            {
                if (dgdMyEOsAwaiting.Items(e.Item.ItemIndex).Cells(4).Text == "Site Test")
                {
                    int intEOID = Convert.ToInt32(dgdMyEOsAwaiting.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));

                }
                else
                {
                    int intEOID = Convert.ToInt32(dgdMyEOsAwaiting.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            else if (e.CommandName == "EOTitle_Link")
            {
                if (dgdMyEOsAwaiting.Items(e.Item.ItemIndex).Cells(4).Text == "Site Test")
                {
                    int intEOID = Convert.ToInt32(dgdMyEOsAwaiting.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
                }
                else
                {
                    int intEOID = Convert.ToInt32(dgdMyEOsAwaiting.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            else if (e.CommandName == "ReadOnly")
            {
                if (dgdMyEOsAwaiting.Items(e.Item.ItemIndex).Cells(4).Text == "Site Test")
                {
                    int intEOID = Convert.ToInt32(dgdMyEOsAwaiting.DataKeys(e.Item.ItemIndex));
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
                }
                else
                {
                    string view = null;
                    int intEOID = 0;
                    intEOID = Convert.ToInt32(dgdMyEOsAwaiting.DataKeys(e.Item.ItemIndex));
                    if (Strings.UCase(e.Item.Cells(4).Text) == Strings.UCase("Preliminary"))
                    {
                        view = "1";
                    }
                    else if (Strings.UCase(e.Item.Cells(4).Text) == Strings.UCase("Final"))
                    {
                        view = "2";
                    }
                    else if (Strings.UCase(e.Item.Cells(4).Text) == Strings.UCase("Closeout"))
                    {
                        view = "3";
                    }
                    Response.Redirect(string.Format("../Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", intEOID.ToString(), view.ToString(), "Report"));
                }
            }
        }*/

       

        #endregion

        protected void ImgReadOnlyEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strstage = Convert.ToString(e.CommandArgument);

               
                    if (strstage.ToUpper() == "Preliminary".ToUpper())
                    {
                        view = "1";
                    }
                    else if (strstage.ToUpper() == "Final".ToUpper())
                    {
                        view = "2";
                    }
                    else if (strstage.ToUpper() == "Closeout".ToUpper())
                    {
                        view = "3";
                    }
                    Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", Convert.ToString(intEOID), Convert.ToString(view), "Report"));
                
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void hypEONumber_Command(object sender, CommandEventArgs e)
        {
            try
            {
                LinkButton lnkEONum = (LinkButton)sender;
                string strStage = Convert.ToString(e.CommandArgument);
                int intEOID = 0;
                if (e.CommandName != null)
                    intEOID = Convert.ToInt32(e.CommandName);
                if (strStage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void hypEOTitle_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        /*protected void hypModifiedDate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }*/

        protected void dgdMyEOsAwaiting_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objSecurity = new clsSecurity();
                FillAwaitingEOs(objSecurity.UserName);
            }
            catch (Exception exc)
            {
                exc.Message.ToString();

            }
            finally
            {
                objSecurity = null;
            }
        }

        protected void imgCreateEO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/NewEO.aspx");
        }
    }
}