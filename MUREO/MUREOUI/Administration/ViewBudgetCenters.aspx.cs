using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using MUREOUI.Common;
using System.Configuration;
using MUREOBAL;
using System.Data.SqlClient;
using DevExpress.Web.ASPxGridView;

namespace MUREOUI.Administration
{
    public partial class ViewBudgetCenters : System.Web.UI.Page
    {
        BudgetCtrBO bdg = new BudgetCtrBO();
        EOScopeOptionBO eosc = new EOScopeOptionBO();
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here        
            if (!Page.IsPostBack)
            {
                FillBudgetDetails();
            }
        }

        protected void FillBudgetDetails()
        {
            DataSet dsBdgtCtr = null;
            StringBuilder sbApprovers = new StringBuilder();
            string strApprovers = null;
            string strApproverName = null;

            if (bdg.GetBudgetCenterDetailsBO(0, ref dsBdgtCtr))
            {
                if (dsBdgtCtr == null)
                {
                    NoRecords();
                }
                else if (dsBdgtCtr.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsBdgtCtr.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    DataRow dr = null;
                    DataTable dtApprovers = new DataTable();
                    dtApprovers.Columns.Add("Budget_Center_Name");
                    dtApprovers.Columns.Add("Approvers");
                    dtApprovers.Columns.Add("Budget_Center_ID");
                    //added by abdul plant name is added to the datagrid
                    dtApprovers.Columns.Add("Plant_Name");
                    for (int rowCt = 0; rowCt <= dsBdgtCtr.Tables[0].Rows.Count - 1; rowCt++)
                    {
                        sbApprovers.Append("<b>Bounty:</b>");
                        strApprovers += sbApprovers.ToString() + dsBdgtCtr.Tables[0].Rows[rowCt]["Towel_Approver_Name"] + " ";
                        sbApprovers.Length = 0;

                        sbApprovers.Append("<b>Charmin:</b>");
                        strApprovers += sbApprovers.ToString() + dsBdgtCtr.Tables[0].Rows[rowCt]["Bath_Approver_Name"] + " ";
                        sbApprovers.Length = 0;

                        sbApprovers.Append("<b>Puffs:</b>");
                        strApprovers += sbApprovers.ToString() + dsBdgtCtr.Tables[0].Rows[rowCt]["Tissue_Approver_Name"] + " ";
                        sbApprovers.Length = 0;

                        sbApprovers.Append("<b>Default:</b>");
                        strApprovers += sbApprovers.ToString() + dsBdgtCtr.Tables[0].Rows[rowCt]["Default_Approver_Name"] + " ";
                        sbApprovers.Length = 0;

                        sbApprovers.Append("<b>SAP Cost Center Coordinator:</b>");

                        if (string.IsNullOrEmpty(Convert.ToString((dsBdgtCtr.Tables[0].Rows[rowCt]["SAP_Cost_Center_Coordinator"]))))
                        {
                            strApproverName = "";
                        }
                        else if (Convert.ToString(dsBdgtCtr.Tables[0].Rows[rowCt]["SAP_Cost_Center_Coordinator"]) == string.Empty)
                        {
                            strApproverName = "";
                        }
                        else if (Convert.ToString(dsBdgtCtr.Tables[0].Rows[rowCt]["SAP_Cost_Center_Coordinator"]) == " ")
                        {
                            strApproverName = "";
                        }
                        else
                        {
                            strApproverName = Convert.ToString(dsBdgtCtr.Tables[0].Rows[rowCt]["SAP_Cost_Center_Coordinator"]);
                        }
                        //strApprovers += sbApprovers.ToString() + strApproverName + "<br/>" + "<br/>" + "<hr/>";//Commneted by Muralikrishna.CH
                        strApprovers += sbApprovers.ToString() + strApproverName + "<br/>" + "<br/>" ;
                        //& "<br/>" '& "<hr/>"
                        //sbApprovers.Append(ControlChars.CrLf & "<hr/>")
                        sbApprovers.Length = 0;

                        //strApprovers &= "Puffs: " & dsBdgtCtr.Tables(0).Rows(rowCt)("Tissue_Approver_Name") & " "
                        //strApprovers &= "Default: " & dsBdgtCtr.Tables(0).Rows(rowCt)("Default_Approver_Name") & " "
                        //strApprovers &= "SAP Cost Center Coordinator: " & dsBdgtCtr.Tables(0).Rows(rowCt)("SAP_Cost_Center_Coordinator") & " "

                        dr = dtApprovers.NewRow();
                        dr[0] = dsBdgtCtr.Tables[0].Rows[rowCt]["Budget_Center_Name"];
                        dr[1] = strApprovers;
                        dr[2] = dsBdgtCtr.Tables[0].Rows[rowCt]["Budget_Center_ID"];
                        //added by abdul plant name is added to the datagrid
                        dr[3] = dsBdgtCtr.Tables[0].Rows[rowCt]["Plant_Name"];
                        dtApprovers.Rows.Add(dr);

                        strApprovers = "";
                    }
                    drgBudget.DataSource = dtApprovers;
                    drgBudget.DataBind();
                }
            }
        }

        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        protected void imgCreateBdgtCtr_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddBudgetCenter.aspx");
        }
        protected void drgBudget_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    DevExpress.Web.ASPxEditors.ASPxButton ImgRemoveBdgtCtr = (DevExpress.Web.ASPxEditors.ASPxButton)drgBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgBudget.Columns["Delete BudgetCenter"], "ImgDeleteBudgetCenter");
                    LinkButton lblBdgtCtrName = (LinkButton)drgBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgBudget.Columns["BudgetName"], "lblBdgtCtrName");
                    //            //ImgRemoveBdgtCtr.Attributes.Add("onclick", "return confirmBudgetCenterDelete('" & lblBdgtCtrName.Text & "','" & CheckScopeOption(e.Item.Cells(0).Text) & "');")
                    //ImgRemoveBdgtCtr.Attributes.Add("onclick", "return confirmBudgetCenterDelete('" + lblBdgtCtrName.Text + "','" + CheckScopeOption(Convert.ToString(lblBdgtCtrName.Attributes["BudgetCenterID"])) + "');");
                    ImgRemoveBdgtCtr.ClientSideEvents.Click = "function(s,e) { e.processOnServer = confirmBudgetCenterDelete('" + lblBdgtCtrName.Text + "','" + CheckScopeOption(Convert.ToString(lblBdgtCtrName.Attributes["BudgetCenterID"])) + "'); }";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //objErrorLog.SaveErrorLog(strModule + "gvRecords_HtmlRowCreated", "Error", ex.Message, "gvRecords_HtmlRowCreated", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }       
        protected void ImgDeleteBudgetCenter_Command(object sender, CommandEventArgs e)
        {
            if (hdnResponse.Value == "Y")
            {
                if (e.CommandArgument != null)
                    DeleteBudgetCenter(Convert.ToInt32(e.CommandArgument));
            }
        }       
        protected bool CheckScopeOption(string Budget_Center_Id)
        {
            DataSet dsScope = null;

            if (eosc.GetEOScopeOptionDetailsBO(0, ref dsScope))
            {
                if (dsScope == null)
                {
                }
                else if (dsScope.Tables.Count == 0)
                {
                }
                else if (dsScope.Tables[0].Rows.Count == 0)
                {
                }
                else if (dsScope.Tables[0].Rows.Count > 0)
                {
                    for (int rowCt = 0; rowCt <= dsScope.Tables[0].Rows.Count - 1; rowCt++)
                    {
                        if (dsScope.Tables[0].Rows[rowCt]["Budget_Center_ID"] == Budget_Center_Id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected void DeleteBudgetCenter(int budget_center_id)
        {
            int result = -1;
            SqlParameter[] paramin = new SqlParameter[1];
            if (bdg.InsertEOBudgetCenterBO(budget_center_id, "", 0, 0, "", "", "", "", "", cls.UserName, 'I', ref paramin))
            {
                result =Convert.ToInt32(paramin[0].Value);
                if (result == 0)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "'); window.location.href='ViewBudgetCenters.aspx'";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["DeletedFailure"] + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }

        protected void lblBdgtCtrName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument != null)
                    Response.Redirect("ViewBudgetCenter.aspx?Budget_Center_ID=" + e.CommandArgument);
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void drgBudget_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillBudgetDetails();
            }
            catch (Exception ex)
            {
               ex.Message.ToString();
            }
        }
    }
}