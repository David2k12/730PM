using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;
using DevExpress.Web.ASPxGridView;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class SearchApproverNames : System.Web.UI.Page
    {
        #region "Variable Declarations"
        SearchApprover objApprNames = new SearchApprover();
        DataSet dsApproverNames;
        DataSet dsFunction;

        public static Int16 count;

        #endregion

        protected void Page_Load(Object sender, EventArgs e)
        {
            //Page.SmartNavigation = true;
            imgAddressBook.Attributes.Add("onclick", "javascript: AddBooksingUser();");
            if (!Page.IsPostBack)
            {
                FillApprovers();
                FillFunctions();
                dgrdApproverGroups.Visible = false;
                //drpPlantName.Items(drpPlantName.Items.IndexOf(drpPlantName.Items.FindByText(CStr(dsMachineNames.Tables(0).Rows(0)(2))))).Selected = True
            }
        }
        protected void FillApprovers()
        {
            dsApproverNames = new DataSet();
             objApprNames.FillApprovers(ref dsApproverNames);
            drpApproverName.DataSource = dsApproverNames;
            drpApproverName.DataTextField = "Approver_Name";
            //drpApproverName.DataValueField = "Approver_ID"
            drpApproverName.DataBind();
            drpApproverName.Items.Insert(0, "--- Select Approver Name ---");
        }
        protected void FillFunctions()
        {
            dsFunction = new DataSet();
            DataTable dtFunc = new DataTable();
            DataRow drFunc = null;
            dtFunc.Columns.Add("Function_Name");
            dtFunc.Columns.Add("Function_ID");
             objApprNames.FillFunctions(ref dsFunction);

            for (int rowCt = 0; rowCt <= dsFunction.Tables[0].Rows.Count - 1; rowCt++)
            {
                string func_name =Convert.ToString(dsFunction.Tables[0].Rows[rowCt]["Function_Name"]);
                int func_id = Convert.ToInt32(dsFunction.Tables[0].Rows[rowCt]["Function_ID"]);
                switch (func_name)
                {
                    case "Site HS&E Resource":
                    case "GBU HS&E Resource":
                    case "Site Planning":
                    case "Central Planning":
                    case "Site Leadership":
                    case "Site Finance":
                    case "PS Initiative Manager":
                    case "Products Research":
                    case "PS&RA":
                    case "Timing Gate Exception":
                    case "Standards Office":
                    case "Site Contact":
                    case "SAP Cost Center Coordinator":
                    case "Central QA":
                        drFunc = dtFunc.NewRow();
                        drFunc["Function_Name"] = func_name;
                        drFunc["Function_ID"] = func_id;
                        dtFunc.Rows.Add(drFunc);
                        break;
                    case "QA":
                        drFunc = dtFunc.NewRow();
                        drFunc["Function_Name"] = "Site QA";
                        drFunc["Function_ID"] = func_id;
                        dtFunc.Rows.Add(drFunc);
                        break;
                }
            }
            //drpFunction.DataSource = dsFunction
            drpFunction.DataSource = dtFunc;
            drpFunction.DataTextField = "Function_Name";
            drpFunction.DataValueField = "Function_ID";
            drpFunction.DataBind();
            drpFunction.Items.Insert(0, "--- Select Function Name ---");
        }


        protected void imgOK_Click(Object sender, EventArgs e)
        {
            string apprName = null;
            string FuncName = null;
            int FuncId = 0;
            DataSet dsApprGrp = new DataSet();
            string script = null;
            apprName = drpApproverName.SelectedItem.Text;
            FuncName = drpFunction.SelectedItem.Text;

            if (apprName == "--- Select Approver Name ---" | FuncName == "--- Select Function Name ---")
            {
            }
            else
            {
                FuncId =Convert.ToInt32(drpFunction.SelectedValue);
                objApprNames.GetApprGrpName(apprName, FuncId, ref dsApprGrp);
                if (dsApprGrp == null)
                {
                }
                else if (dsApprGrp.Tables.Count == 0)
                {
                    dgrdApproverGroups.Visible = false;
                }
                else if (dsApprGrp.Tables[0].Rows.Count == 0)
                {
                    dgrdApproverGroups.Visible = false;
                    script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                }
                else
                {
                    dgrdApproverGroups.Visible = true;
                    dgrdApproverGroups.DataSource = dsApprGrp;
                    dgrdApproverGroups.DataBind();
                }
            }
        }

        protected void imgChgApprName_Click(Object sender, EventArgs e)
        {
            string apprName = null;
            string script = null;
            string FuncName = null;
            int FuncId = 0;
            int rowCount = 0;
            string GrpIdList = null;
            apprName = drpApproverName.SelectedItem.Text;
            FuncName = drpFunction.SelectedItem.Text;
            if (!string.IsNullOrEmpty(hdntxtNewApproverName.Value)) ;
            txtNewApproverName.Text = hdntxtNewApproverName.Value;
            if (string.IsNullOrEmpty(txtNewApproverName.Text))
            {
                script = "alert('" + ConfigurationManager.AppSettings["EnterAppr"] + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            else
            {
                FuncId =Convert.ToInt32(drpFunction.SelectedValue);
                for (rowCount = 0; rowCount <= dgrdApproverGroups.VisibleRowCount - 1; rowCount++)
                {
                    CheckBox chkApproverGrp = (CheckBox)dgrdApproverGroups.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgrdApproverGroups.Columns["Select"], "chkAppGrp");
                        //(CheckBox)dgrdApproverGroups.items[rowCount].FindControl("chkAppGrp");                    
                    if (chkApproverGrp.Checked == true)
                    {
                        if (string.IsNullOrEmpty(GrpIdList))
                        {
                            Label lblGrpID = (Label)dgrdApproverGroups.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgrdApproverGroups.Columns["Approver Group Name"], "lblApprGrpID");
                            GrpIdList = lblGrpID.Text;
                        }
                        else
                        {
                            Label lblGrpID = (Label)dgrdApproverGroups.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgrdApproverGroups.Columns["Approver Group Name"], "lblApprGrpID");
                            GrpIdList = GrpIdList + "," + lblGrpID.Text;
                        }
                    }
                    else
                    {
                        //GrpIdList = ""
                    }
                }
                if (!string.IsNullOrEmpty(GrpIdList))
                {
                    int x = 0;
                    SqlParameter[] paramout=new SqlParameter[1];
                    if (objApprNames.SetSearchApproverName(apprName, FuncId, GrpIdList, txtNewApproverName.Text, ref paramout))
                    {
                        x =Convert.ToInt32(paramout[0].Value);
                        if (x == 0)
                        {
                            script = "alert('" + ConfigurationManager.AppSettings["ChangeSuccessMsg"] + "');window.navigate('../Administration/ViewApprovalGroup.aspx');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                        else
                        {
                            script = "alert('" + ConfigurationManager.AppSettings["ChangeErrMsg"] + "');window.navigate('../Administration/ViewApprovalGroup.aspx');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                    }
                }
                else
                {
                    script = "alert('" + ConfigurationManager.AppSettings["SelectApprGrpName"] + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }

        protected void imgCancel_Click(Object sender, EventArgs e)
        {
            Response.Redirect("../Administration/ViewApprovalGroup.aspx");
        }

        protected void drpFunction_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //count = count + 1
            //If count >= 2 Then
            //    Dim apprName, FuncName As String
            //    Dim FuncId As Integer
            //    Dim dsApprGrp As DataSet
            //    Dim script As String
            //    apprName = drpApproverName.SelectedItem.Text
            //    FuncName = drpFunction.SelectedItem.Text
            //    If apprName = "--- Select Approver Name ---" Or FuncName = "--- Select Function Name ---" Then

            //    Else
            //        FuncId = drpFunction.SelectedValue
            //        'dsApprGrp = objApprNames.GetApprGrpName(apprName, FuncId)
            //        'If dsApprGrp Is Nothing Then
            //        'ElseIf dsApprGrp.Tables.Count = 0 Then
            //        'ElseIf dsApprGrp.Tables(0).Rows.Count = 0 Then
            //        '    dgrdApproverGroups.Visible = False
            //        '    script = "alert('" & ConfigurationManager.AppSettings["NoRecords") & "');"
            //        '    Page.RegisterStartupScript("clientscript", script)
            //        'Else
            //        '    dgrdApproverGroups.Visible = True
            //        '    dgrdApproverGroups.DataSource = dsApprGrp
            //        '    dgrdApproverGroups.DataBind()
            //        'End If
            //    End If
            //End If
        }


        protected void drpApproverName_SelectedIndexChanged(Object sender, EventArgs e)
        {
        }

    }
}