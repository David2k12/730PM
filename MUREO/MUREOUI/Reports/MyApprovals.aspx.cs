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

namespace MUREOUI.Reports
{
    public partial class MyApprovals : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        ClsMyEOs objMyEOs = new ClsMyEOs();
        DataSet dsApprvlConcurrence = null;
        string strScript = string.Empty;
        string strCurrentStage = string.Empty;
        string strUserRole = string.Empty;
        string strUserName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            strUserRole = objSecurity.UserRole();
            strUserName = objSecurity.UserName;
            if ((strUserRole == "MUREO_Admin"))
            {
                imgCreateEO.Enabled = true;
            }
            else if ((strUserRole == "MUREO_Editors"))
            {
                imgCreateEO.Enabled = true;
            }
            else if ((strUserRole == "MUREO_Readers"))
            {
                imgCreateEO.Enabled = false;
            }
            else if ((strUserRole == "Readers"))
            {
                imgCreateEO.Enabled = false;
            }
            if (!IsPostBack)
            {
                FillApprovalsandConcurrences();
            }
        }
        private void NoDataForGrid()
        {
            strScript = ("alert('"
                        + (ConfigurationSettings.AppSettings["NoRec"] + "');"));
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }
        public void FillApprovalsandConcurrences()
        {
            try
            {
                // strUserName = "Surendra Bolla-su"
                dsApprvlConcurrence = new DataSet();
                if (objMyEOs.GetApprovalsConcurrences(0, String.Empty, "Declined", strUserName, ref dsApprvlConcurrence))
                {
                    if ((dsApprvlConcurrence == null))
                    {
                        NoDataForGrid();
                        return;
                    }
                    else if ((dsApprvlConcurrence.Tables.Count == 0))
                    {
                        NoDataForGrid();
                        return;
                    }
                    else if ((dsApprvlConcurrence.Tables[0].Rows.Count == 0))
                    {
                        NoDataForGrid();
                        return;
                    }
                    else
                    {
                        dgdAprvlConcurrencenew.DataSource = dsApprvlConcurrence.Tables[0].DefaultView;
                        if ((dsApprvlConcurrence.Tables[0].Rows.Count <= dgdAprvlConcurrencenew.PageCount))
                        {

                            // If dgdAprvlConcurrence.CurrentPageIndex <> 0 Then
                            // dgdAprvlConcurrence.CurrentPageIndex -= 1
                            // End If
                        }
                        else
                        {

                        }
                        // Code added by Vijay
                        if (!(ViewState["SortExp"] == null))
                        {
                            string SortExp;
                            string strSort;
                            DataView dv = new DataView(dsApprvlConcurrence.Tables[0]);
                            // Create a data view for the sort
                            string imgAsc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                            string imgDesc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                            SortExp = ViewState["SortExp"].ToString().Trim();
                            strSort = (SortExp + ViewState["StrSort"]);
                            dv.Sort = strSort;
                            dgdAprvlConcurrencenew.DataSource = dv;
                            foreach (DataGridColumn col in dgdAprvlConcurrencenew.Columns)
                            {
                                string header_text = col.HeaderText;
                                int position = col.HeaderText.IndexOf(" ");
                                if ((col.SortExpression == SortExp))
                                {
                                    if ((position > -1))
                                    {
                                        header_text = col.HeaderText.Substring(0, position);
                                    }
                                    if ((ViewState["StrSort"] == " Asc"))
                                    {
                                        col.HeaderText = string.Concat(header_text, imgAsc);
                                    }
                                    else
                                    {
                                        col.HeaderText = string.Concat(header_text, imgDesc);
                                    }
                                }
                                else if ((position > -1))
                                {
                                    header_text = col.HeaderText.Substring(0, position);
                                    col.HeaderText = header_text;
                                }
                            }
                        }
                        dgdAprvlConcurrencenew.DataBind();
                        for (int numRows = 0; (numRows
                                    <= (dgdAprvlConcurrencenew.VisibleRowCount - 1)); numRows++)
                        {
                            ImageButton imgApprovar;
                            imgApprovar = (ImageButton)dgdAprvlConcurrencenew.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdAprvlConcurrencenew.Columns["Check Approvals"], "imgApprovar");


                            //if (((dgdAprvlConcurrencenew.Items(numRows).Cells[6].Text == "Draft")
                            //            || ((dgdAprvlConcurrencenew.Items(numRows).Cells[6].Text == "")
                            //            || (dgdAprvlConcurrencenew.Items(numRows).Cells[5].Text.ToUpper() == "Site Test".ToUpper()))))
                            //{
                            //    imgApprovar.Visible = false;
                            //}






                        }
                    }

                }
                

            }
            catch (Exception ex)
            {
                string script;
                string exMessage;
                exMessage = ex.Message.Replace("'", " ");
                script = ("alert('"
                            + (ex.Message + "');"));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
            }
        }

        public void EnableDisableLinks(bool optBool)
        {
            // following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; (numRows
                        <= (dgdAprvlConcurrencenew.VisibleRowCount - 1)); numRows++)
            {
                ImageButton imgApprovar;
                imgApprovar = (ImageButton)dgdAprvlConcurrencenew.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdAprvlConcurrencenew.Columns["Check Approvals"], "imgApprovar");
                imgApprovar.Enabled = optBool;


                LinkButton lnkEONum;
                lnkEONum = (LinkButton)dgdAprvlConcurrencenew.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdAprvlConcurrencenew.Columns["EO Num"], "lnkEONum");
                lnkEONum.Enabled = optBool;


                LinkButton lnkEOTitle;
                lnkEOTitle = (LinkButton)dgdAprvlConcurrencenew.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdAprvlConcurrencenew.Columns["EO Title"], "lnkEOTitle");
                lnkEOTitle.Enabled = optBool;
            }
        }

        

        void NoApprovarList()
        {
            strScript = "alert('Approvar list is not available.');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }

        protected void imgCreateEO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Common/NewEO.aspx");
        }

        protected void dgdAprvlConcurrencenew_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void dgdAprvlConcurrencenew_PageIndexChanged(object sender, EventArgs e)
        {

            FillApprovalsandConcurrences();
        }

        protected void EONumLink_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                LinkButton lkb = (LinkButton)sender;
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)lkb.Parent;
                if (Convert.ToString(e.CommandArgument) == "Site Test")
                {
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", Convert.ToInt32(e.CommandName), "Approval"));

                }


                else
                {
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", Convert.ToInt32(e.CommandName)));
                }
            }


        }
        protected void EOTitleLink_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName != null)
            {
                LinkButton lkb = (LinkButton)sender;
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)lkb.Parent;
                if (Convert.ToString(e.CommandArgument) == "Site Test")
                {
                    Response.Redirect(string.Format("../Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", Convert.ToInt32(e.CommandName), "Approval"));


                }


                else
                {
                    Response.Redirect(string.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", Convert.ToInt32(e.CommandName)));

                }
            }


        }
        protected void ImgReadOnlyEO_Click(object sender, CommandEventArgs e)
        {
            //if (e.CommandName != null)
            //{
            //    ImageButton lkb = (ImageButton)sender;
            //    GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)lkb.Parent;
            //    if (Convert.ToString(e.CommandArgument) == "Site Test")
            //    {
            //        Response.Redirect(string.Format("../Common/ViewSiteTest.aspx?EoID={0}", Convert.ToInt32(e.CommandName)));

            //    }
            //    else
            //    {
            //        string view;
            //        view = string.Empty;
            //        if (Convert.ToString(e.CommandArgument) == "Preliminary".ToUpper())
            //        {
            //            view = "1";
            //        }
            //        else if (Convert.ToString(e.CommandArgument) == "Final".ToUpper())
            //        {
            //            view = "2";
            //        }

            //        else if (Convert.ToString(e.CommandArgument) == "Closeout".ToUpper())
            //        {
            //            view = "3";
            //        }
            //        Response.Redirect(string.Format("../Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", Convert.ToInt32(e.CommandName), view.ToString(), "Report"));


            //    }
            //}
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strstage = Convert.ToString(e.CommandArgument);

                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/ViewSiteTest.aspx?EoID={0}", intEOID));
                }
                else
                {
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
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgCheckApproval_Click(object sender, CommandEventArgs e)
        {
            ImageButton lkb = (ImageButton)sender;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)lkb.Parent;

            strCurrentStage = Convert.ToString(e.CommandArgument);

            int intEOID = Convert.ToInt32(e.CommandName);
            DataSet dsApprovar = new DataSet();
            ClsMyEOs objClsMyEOs = new ClsMyEOs();

            if (objClsMyEOs.ShowApprovals(intEOID, strCurrentStage, ref dsApprovar))
            {
                if ((dsApprovar == null))
                {
                    NoApprovarList();
                }
                else if ((dsApprovar.Tables.Count == 0))
                {
                    NoApprovarList();
                }
                else if ((dsApprovar.Tables[0].Rows.Count == 0))
                {
                    NoApprovarList();
                }
                else
                {
                    DataTable dt;
                    dt = dsApprovar.Tables[0];
                    int rowCount = dt.Rows.Count;
                    Int32 colCount = dt.Columns.Count;
                    int rowLoop;
                    int colLoop;
                    string strApprovar=string.Empty;
                    for (rowLoop = 0; (rowLoop
                                <= (rowCount - 1)); rowLoop++)
                    {
                        for (colLoop = 0; (colLoop
                                    <= (colCount - 1)); colLoop++)
                        {
                            strApprovar = (strApprovar
                                        + (dt.Rows[rowLoop][colLoop] + "\\n"));
                        }
                    }
                    if (!(strApprovar == String.Empty))
                    {
                        string script;
                        // Added by abdul on 31-jan-2008
                        // New code where the user can view the approvers in a show modal dialog box.
                        if ((strCurrentStage.ToUpper() == "Preliminary".ToUpper()))
                        {
                            script = ("window.showModalDialog('ShowApprovers.aspx?EventID="
                                        + (intEOID + ("&stage="
                                        + (strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:300px');"))));
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                        else if ((strCurrentStage.ToUpper() == "Final".ToUpper()))
                        {
                            script = ("window.showModalDialog('ShowApprovers.aspx?EventID="
                                        + (intEOID + ("&stage="
                                        + (strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:400px');"))));
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                        else if ((strCurrentStage.ToUpper() == "Closeout".ToUpper()))
                        {
                            script = ("window.showModalDialog('ShowApprovers.aspx?EventID="
                                        + (intEOID + ("&stage="
                                        + (strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:200px');"))));
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                       
                    }
                    else
                    {
                        strScript = "alert('Approvar list is not available.');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                    }
                }


            }
            
        }
        
    }
}