using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using MUREOBAL;
using System.Configuration;
using System.Collections;
using DevExpress.Web.ASPxPager;
using MUREOUI.Common;
using DevExpress.Web.ASPxGridView;


namespace MUREOUI.Administration
{
    public partial class ViewApprovalGroup : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        #region "Page_Load"
        protected void Page_Load(object sender, EventArgs e)
        {

            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                // dsAppList = Approver.GetEOApprovalGroupApproversBO(0) 'Retrieve all approval group name and approvers
                FillApproversDetails();
            }
        }
        protected void drgAppGrp_PageIndexChanged(object sender, EventArgs e)
        {
            FillApproversDetails();
        }
        protected void imgCreateAppGrp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddApprvrGrp.aspx");
        }
        protected void lnkAppGroupName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                    Response.Redirect("~/Administration/ViewGrp.aspx?App_Grp_Id=" + Convert.ToString(e.CommandName));
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }
        //Sub 	        :   InsertOperationMessage
        //Written BY	    :	Vijay
        //parameters     :	Delete result
        //Purpose	    :   Displays delete success/failure message
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        private void InsertOperationMessage(int Result)
        {
            string script = null;
            if (Result == 0)
            {
                script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["DeletedSuccess"]) + "'); window.location='ViewApprovalGroup.aspx'; ";
            }
            else
            {
                script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["DeleteError"]) + "');  ";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void imgDeleteGroup_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {

                    SqlParameter[] paramout = new SqlParameter[1];
                    int Result = -1;
                    Approver ap = new Approver();
                    if (ap.InsertEOApprovalGroupBO(Convert.ToInt32(e.CommandName), "", 0, 0, ' ', "", 'I', objSecurity.UserName, ref paramout))
                    {
                        Result = Convert.ToInt32(paramout[0].Value);
                    }
                    // Ok, now delete the group
                    InsertOperationMessage(Result);
                    //Display delete success/failure message

                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void drgAppGrp_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                //ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    DevExpress.Web.ASPxEditors.ASPxButton imgRemoveButton = (DevExpress.Web.ASPxEditors.ASPxButton)drgAppGrp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgAppGrp.Columns["Delete Group"], "imgDeleteGroup");
                    LinkButton lnkAppGroupName = (LinkButton)drgAppGrp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgAppGrp.Columns["Approval Group"], "lnkAppGroupName");
                    lnkAppGroupName.Enabled = true;
                    //imgRemoveButton.Attributes.Add("onclick", "javascript:return confirmApproverGrpDelete('" + lnkAppGroupName.Text + "');");
                    imgRemoveButton.ClientSideEvents.Click = "function(s,e) { e.processOnServer = confirm('Are you sure you want to delete this Approval Group " + lnkAppGroupName.Text + " ?'); }";
                }
            }
            catch (Exception exc)
            {
            }
        }
        //private void drgAppGrp_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //If view command event
        //    if (e.CommandName == "AppGrpLink")
        //    {
        //        Label lblAppGrpID = (Label)drgAppGrp.Items(e.Item.ItemIndex).FindControl("lblAppGrpID");
        //        Response.Redirect("ViewGrp.aspx?App_Grp_Id=" + lblAppGrpID.Text);
        //        //Redirect user to single view form
        //        //If delete command event
        //    }
        //    else if (e.CommandName == "DeleteAppGroup")
        //    {
        //        Label lblAppGrpID = (Label)drgAppGrp.Items(e.Item.ItemIndex).FindControl("lblAppGrpID");
        //        ImageButton imgDeleteAppGrp = (ImageButton)drgAppGrp.Items(e.Item.ItemIndex).FindControl("imgDeleteGroup");
        //        int app_grp_id = Convert.ToInt32(e.CommandArgument);
        //        //Confirm whether the user really wants to delete the group
        //        if (Request.Form("Response") == "Y")
        //        {
        //            int Result = Approver.InsertEOApprovalGroupBO(app_grp_id, "", 0, 0, "", "", "I", System.Security.UserName);
        //            // Ok, now delete the group
        //            this.InsertOperationMessage(Result);
        //            //Display delete success/failure message
        //        }
        //    }
        //}


        #endregion
        #region "Methods"
        private void NoRecords()
        {
            string script;
            script = ("alert(\'" + (ConfigurationManager.AppSettings["NoRecords"] + "\')"));
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        //protected void InsertOperationMessage(int Result)
        //{
        //    string script;
        //    if ((Result == 0))
        //    {
        //        script = ("alert(\'" + (ConfigurationManager.AppSettings["DeletedSuccess"] + "\')"));
        //    }
        //    else
        //    {
        //        script = ("alert(\'" + (ConfigurationManager.AppSettings["DeleteError"] + "\')"));
        //    }
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        //}
        protected void FillApproversDetails()
        {
            clsApprover objclsApprover = new clsApprover();
            DataSet dsAppList = new DataSet();
            if (objclsApprover.FillEOApprovalGroupDetails(0, ref dsAppList, "GET_EO_Approval_Groups_Details"))
            {
                if ((dsAppList == null))
                {
                    // If dataset is null, quit
                    NoRecords();
                }
                else if ((dsAppList.Tables.Count == 0))
                {
                    NoRecords();
                }
                else if ((dsAppList.Tables[0].Rows.Count == 0))
                {
                    // If no data, quit
                    NoRecords();
                }
                else
                {
                    DataTable table = new DataTable();
                    // NewRow to create a DataRow.
                    DataRow dr;
                    dr = table.NewRow();
                    string app_grp_id;
                    DataTable dtapprovers = new DataTable();
                    System.Text.StringBuilder sbApprovers = new System.Text.StringBuilder();

                    int rowCount;
                    string apptmp = "";
                    string strApproverName = "";
                    // Create a new data table and add the following columns. This is done so that only row for each
                    // approval group will exist in the datatable
                    dtapprovers.Columns.Add("Approval_Group_ID");
                    dtapprovers.Columns.Add("Approval_Group_Name");
                    dtapprovers.Columns.Add("Names");
                    for (int rowCt = 0; (rowCt
                                <= (dsAppList.Tables[0].Rows.Count - 1)); rowCt++)
                    {
                        // Iterate through the dataset
                        if ((dsAppList.Tables[0].Rows[rowCt]["Function_Name"].ToString().ToLower() == "qa"))
                        {
                            dsAppList.Tables[0].Rows[rowCt]["Function_Name"] = "Site QA";
                        }
                        rowCount = rowCt;
                        // app_grp_name = dsAppList.Tables(0).Rows(rowCt)("Approval_Group_Name") 'Get the approval group name
                        app_grp_id = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_Id"].ToString();
                        // Get the approval group name
                        if ((apptmp == String.Empty))
                        {
                            // This is will kick start the process
                            dr = dtapprovers.NewRow();
                            // We are on first record, create a new data row
                            dr[0] = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_ID"];
                            // Get the approval group id
                            dr[1] = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_Name"];
                            // Get the approval group name
                            string appr_name = dsAppList.Tables[0].Rows[rowCt]["Approver_Name"].ToString();
                            sbApprovers.Append(("<b> "
                                            + (dsAppList.Tables[0].Rows[rowCt]["Function_Name"] + ":</b>")));
                            // Now make the function name as bold using string builder  
                            strApproverName = (sbApprovers.ToString()
                                        + (appr_name + ", "));
                        }
                        else if ((app_grp_id == apptmp))
                        {
                            // If the next record is for the same approval group id
                            sbApprovers.Length = 0;
                            //  clear the string builder
                            dr[0] = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_ID"];
                            // Set the data rows for approval group id and name
                            dr[1] = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_Name"];
                            string appr_name = dsAppList.Tables[0].Rows[rowCt]["Approver_Name"].ToString();
                            sbApprovers.Append("<b> " + dsAppList.Tables[0].Rows[rowCt]["Function_Name"].ToString() + ":</b>");
                            //Now make the function name as bold using string builder 
                            //Append the function name in bold with the approver name 
                            strApproverName += sbApprovers.ToString() + appr_name + ", ";
                            if ((rowCt
                                        == (dsAppList.Tables[0].Rows.Count - 1)))
                            {
                                // This check is for the last record
                                dr[2] = strApproverName.Remove(strApproverName.LastIndexOf(", "), 1);
                                // We already got the first two data rows , so add only the last row for approvers
                                dtapprovers.Rows.Add(dr);
                                // Add the data row to the data table
                                break;
                            }
                        }
                        else
                        {
                            sbApprovers.Length = 0;
                            // Reset the string buffer
                            //  sbApprovers.Append(ControlChars.CrLf & "<hr/>") 'Insert a horizontal line after each approval group
                            if (((strApproverName == "")
                                        || ((strApproverName == String.Empty)
                                        || (strApproverName == null))))
                            {
                                dr[2] = ("<br>" + sbApprovers.ToString());
                            }
                            else
                            {
                                dr[2] = (strApproverName.Remove(strApproverName.LastIndexOf(", "), 1) + sbApprovers.ToString());
                                // Append approver to the data row
                            }
                            dtapprovers.Rows.Add(dr);
                            // Add the data row to the data table
                            strApproverName = "";
                            sbApprovers.Length = 0;
                            // Reset the string buffer
                            dr = dtapprovers.NewRow();
                            // Create a new row for the next record
                            dr[0] = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_ID"];
                            // Set the data rows for approval group id and name
                            dr[1] = dsAppList.Tables[0].Rows[rowCt]["Approval_Group_Name"];
                            string appr_name = dsAppList.Tables[0].Rows[rowCt]["Approver_Name"].ToString();
                            sbApprovers.Append("<b> " + dsAppList.Tables[0].Rows[rowCt]["Function_Name"] + ":</b>");
                            //Now make the function name as bold using string builder 
                            //Append the function name in bold with the approver name 
                            strApproverName += sbApprovers.ToString() + appr_name + ", ";
                            dr[2] = strApproverName;
                        }
                        apptmp = app_grp_id;
                        // Make a copy of the approval_group_name. Note:This is done to check for a change in approval group id
                    }
                    drgAppGrp.DataSource = dtapprovers;
                    // Now set the new data source for the data grid
                    drgAppGrp.DataBind();
                }
            }
        }
        //private bool CheckApproverNameChange(string Appr_Name, string Func_Name)
        //{
        //    DataSet dsApprovers=new DataSet();
        //    if (objclsApprover.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0))
        //    {
        //        if ((dsApprovers == null))
        //        {

        //        }
        //        else if ((dsApprovers.Tables.Count == 0))
        //        {

        //        }
        //        else if ((dsApprovers.Tables[0].Rows.Count == 0))
        //        {

        //        }
        //        else
        //        {
        //            for (int rowCt = 0; (rowCt
        //                        <= (dsApprovers.Tables[0].Rows.Count - 1)); rowCt++)
        //            {
        //                if (((dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"].ToString() == Appr_Name) && (dsApprovers.Tables[0].Rows[rowCt]["Function_Name"].ToString() == Func_Name)))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //        return false;
        //    }
        //}
        #endregion
        protected void imgSearchAppr_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Administration/SearchApproverNames.aspx");
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }
    }
}