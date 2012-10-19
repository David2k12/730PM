using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.Web.ASPxGridView;

namespace MUREOUI.Administration
{
    public partial class ViewEOScopeOptions : System.Web.UI.Page
    {
        #region "Variable Declarations"
        EOScopeOptionBO esbo = new EOScopeOptionBO();
        BudgetCtrBO bdg = new BudgetCtrBO();
        clsSecurity cls = new clsSecurity();
        #endregion
        DataSet dsEOdetails;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                FillEOScopeDetails();
            }
        }
        protected bool CheckBudgetCenter(int Budget_Center_Id)
        {
            DataSet dsBudget = null;
            if (bdg.GetBudgetCenterDetailsBO(Budget_Center_Id, ref dsBudget))
            {
                if (dsBudget == null)
                {
                }
                else if (dsBudget.Tables.Count == 0)
                {
                }
                else if (dsBudget.Tables[0].Rows.Count == 0)
                {
                }
                else if (dsBudget.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        protected void drgEOScope_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillEOScopeDetails();
            }
            catch (Exception exc)
            {
                                
            }
        }
        protected void FillEOScopeDetails()
        {
            if (esbo.GetEOScopeOptionDetailsBO(0, ref dsEOdetails))
            {
                if (dsEOdetails == null)
                {
                    NoRecords();
                }
                else if (dsEOdetails.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsEOdetails.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    //ViewState["bool") = "N"
                    //For rowCt As Integer = 0 To dsEOdetails.Tables(0).Rows.Count - 1
                    //    If CheckBudgetCenter(Convert.ToInt32(dsEOdetails.Tables(0).Rows(rowCt)("Budget_Center_ID"))) = False Then
                    //        ViewState["bool") &= dsEOdetails.Tables(0).Rows(rowCt)("Budget_Center_ID") & " "
                    //        dsEOdetails.Tables(0).Rows(rowCt)("Budget_Center_Name") = ""
                    //        dsEOdetails.Tables(0).Rows(rowCt)("Bounty_Approver_Name") = ""
                    //        dsEOdetails.Tables(0).Rows(rowCt)("Charmin_Approver_Name") = ""
                    //        dsEOdetails.Tables(0).Rows(rowCt)("Puffs_Approver_Name") = ""
                    //        dsEOdetails.Tables(0).Rows(rowCt)("Default_Approver_Name") = ""
                    //        dsEOdetails.Tables(0).Rows(rowCt)("SAP_CCC_Approver_Name") = ""
                    //    End If
                    //Next
                    drgEOScope.DataSource = dsEOdetails;
                    drgEOScope.DataBind();

                    if ((ViewState["bool"] != null))
                    {
                        for (int rowCt = 0; rowCt <= drgEOScope.VisibleRowCount - 1; rowCt++)
                        {
                            string[] arrstr = ViewState["bool"].ToString().Split(' ');
                            for (int count = 0; count <= arrstr.Length - 1; count++)
                            {
                                Label lbl=(Label)drgEOScope.FindRowCellTemplateControl(count, (GridViewDataColumn)drgEOScope.Columns["Delete BudgetCenter"], "lblBudgetCenterID");
                                Label lblApp = (Label)drgEOScope.FindRowCellTemplateControl(count, (GridViewDataColumn)drgEOScope.Columns["Approver Name"], "lblApprovers");
                                if (arrstr[count] == lbl.Text)

                                {
                                    lblApp.Text = "";
                                }
                            }
                        }

                    }


                }
            }
        }
        protected void drgEOScope_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                //if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Header)
                //{
                    
                //}
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    DevExpress.Web.ASPxEditors.ASPxButton ImgRemoveScope = (DevExpress.Web.ASPxEditors.ASPxButton)drgEOScope.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgEOScope.Columns["Delete EO Scope Option"], "ImgRemoveScope");
                    LinkButton lnkScopeName = (LinkButton)drgEOScope.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgEOScope.Columns["Scope Option"], "lnkScopeName");
                    //Label lblApprovers = (Label)drgEOScope.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgEOScope.Columns["Approver Name"], "lblApprovers");                    
                    ImgRemoveScope.ClientSideEvents.Click = "function(s,e) { e.processOnServer = confirmScopeDelete('" + lnkScopeName.Text + "'); }";
                    //ImgRemoveScope.Attributes.Add("onclick", "return confirmScopeDelete('" + lnkScopeName.Text + "');");                   
                    //drgEOScope.Properties.View.Columns("Delete BudgetCenter").Visible = false;
                    //drgEOScope.Properties.View.Columns("Approver Name").Visible = false;
                    drgEOScope.Columns["Delete BudgetCenter"].Visible = false;
                    drgEOScope.Columns["Approver Name"].Visible = false;
                }
            }
            catch (Exception exc)
            {
                                
            }
        }
        //protected void drgEOScope_ItemDataBound(object source, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton ImgRemoveScope = (ImageButton)e.Item.FindControl("ImgRemoveScope");
        //            LinkButton lnkScopeName = (LinkButton)e.Item.FindControl("lnkScopeName");
        //            ImgRemoveScope.Attributes.Add("onclick", "return confirmScopeDelete('" + lnkScopeName.Text + "');");
        //            break;
        //    }
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.Header:
        //            e.Item.Cells[2].Visible = false;
        //            e.Item.Cells[3].Visible = false;
        //            break;
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            e.Item.Cells[2].Visible = false;
        //            e.Item.Cells[3].Visible = false;
        //            break;
        //    }
        //}
        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        protected void lnkScopeName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if(e.CommandArgument!=null)
                Response.Redirect("~/Administration/ViewEOScope.aspx?SO_ID=" + e.CommandArgument);
            }
            catch (Exception exc)
            {
                                
            }
        }
        protected void ImgRemoveScope_Command(object sender, CommandEventArgs e)
        {
            try
            {
                 if (hdnresponse.Value == "Y")
                {
                    if (e.CommandArgument != null)
                    {
                        DeleteScope(Convert.ToInt32(e.CommandArgument));
                        FillEOScopeDetails();
                    }
                }
            }
            catch (Exception exc)
            {
                                
            }
        }
        //protected void drgEOScope_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "View_Scope")
        //    {
        //        Response.Redirect("../Administration/ViewEOScope.aspx?SO_ID=" + e.CommandArgument);
        //    }
        //    else if (e.CommandName == "RemoveScope")
        //    {
        //        if (Request.Form("Response") == "Y")
        //        {
        //            DeleteScope(ref Convert.ToInt32(e.CommandArgument));
        //            FillEOScopeDetails();
        //        }
        //    }
        //}
        protected void DeleteScope(int Scope_ID)
        {
            SqlParameter[] paramout = new SqlParameter[1];
            int result = -1;
            if (esbo.InsertEOScopeOptionBO(Scope_ID, "", 0, "", "", "", "", "", cls.getUserFullName(cls.UserName), 'I', ref paramout))
            {
                result =Convert.ToInt32(paramout[0].Value);
                if (result == 0)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "'); window.location='ViewEOScopeOptions.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["DeleteError"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }
        protected void imgCreateApprover_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddEOScopeOption.aspx");
        }

        protected void imgSuggestBudgetCenter_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewEOScopeBudget.aspx");
        }

    }
}