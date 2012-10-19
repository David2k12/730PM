using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class ViewEOScope : System.Web.UI.Page
    {
        #region "Variable Declarations"
        EOScopeOptionBO esbo = new EOScopeOptionBO();
        BudgetCtrBO bdg = new BudgetCtrBO();        

        #endregion
        int Scope_Id;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (Request.QueryString["SO_ID"] == null | Request.QueryString["SO_ID"] == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an scope option to view this form');window.location = 'ViewEOScopeOptions.aspx'; ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            Scope_Id = Convert.ToInt32(Request.QueryString["SO_ID"]);
            FillScopeDetailsSingleView();
        }
        protected bool CheckBudgetCenter(int Budget_Center_Id)
        {
            DataSet dsBudget = new DataSet();
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
        protected void FillScopeDetailsSingleView()
        {
            DataSet dsScopeDetails = null;
            if (esbo.GetEOScopeOptionDetailsBO(Scope_Id, ref dsScopeDetails))
            {
                if (dsScopeDetails == null)
                {
                    NoRecords();
                }
                else if (dsScopeDetails.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsScopeDetails.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    lblScope.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Scope_Option_Name"]);
                    if (CheckBudgetCenter(Convert.ToInt32(dsScopeDetails.Tables[0].Rows[0]["Budget_Center_ID"])) == true)
                    {
                        lblBudget.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Budget_Center_Name"]);
                        lblBounty.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Bounty_Approver_Name"]);
                        lblCharmin.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Charmin_Approver_Name"]);
                        lblPuffs.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Puffs_Approver_Name"]);
                        lblDefault.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Default_Approver_Name"]);
                        lblSAPCCC.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["SAP_CCC_Approver_Name"]);
                    }
                    else
                    {
                        lblBudget.Text = "";
                        lblBounty.Text = "";
                        lblCharmin.Text = "";
                        lblPuffs.Text = "";
                        lblDefault.Text = "";
                        lblSAPCCC.Text = "";
                    }
                }
            }
        }
        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewEOScopeOptions.aspx");
        }

        protected void imgEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/EditScopeOption.aspx?SO_ID=" + Scope_Id);
        }

    }
}