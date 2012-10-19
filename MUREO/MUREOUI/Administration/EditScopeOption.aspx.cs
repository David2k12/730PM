using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Configuration;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class EditScopeOption : System.Web.UI.Page
    {
        #region "Variable Declaration"
        int Scope_Id;
        DataSet dsScopeDetails=new DataSet();
        BudgetCtrBO bdg = new BudgetCtrBO();
        EOScopeOptionBO esbo = new EOScopeOptionBO();
        DataSet dsBudget = new DataSet();
        clsSecurity cls = new clsSecurity();
        #endregion
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {               
                //Set javascript onclick attribute to address book icon 
                if (Request.QueryString["SO_ID"] == null | Request.QueryString["SO_ID"] == string.Empty)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an scope option to view this form');window.location = 'ViewEOScopeOptions.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                //imgDeleteSAPCC.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the SAP Cost Center Coordinator name? Click OK to delete or CANCEL to abort.');")
                //imgAddrbkTowel.Attributes.Add("onclick", "javascript: AddBookSingUser1();")
                //ImgAddrbkBath.Attributes.Add("onclick", "javascript: AddBookSingUser2();")
                //ImgAddrbkTissue.Attributes.Add("onclick", "javascript: AddBookSingUser3();")
                //ImgAddrbkDefault.Attributes.Add("onclick", "javascript: AddBookSingUser4();")
                //ImgAddrBkSAPCC.Attributes.Add("onclick", "javascript: AddBookSingUser5();")
                Scope_Id = Convert.ToInt32(Request.QueryString["SO_ID"]);
                FillEOScopeDetails();
            }
        }
        protected bool CheckBudgetCenter(int Budget_Center_Id)
        {
            DataSet dsBudgett = new DataSet();
            if (bdg.GetBudgetCenterDetailsBO(Budget_Center_Id, ref dsBudgett))
            {
                if (dsBudgett == null)
                {
                }
                else if (dsBudgett.Tables.Count == 0)
                {
                }
                else if (dsBudgett.Tables[0].Rows.Count == 0)
                {
                }
                else if (dsBudgett.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        protected void FillBudgetCenter(ref DataSet dsScopeDetails)
        {
            int i = 0;
            char @bool = '\0';
            if (bdg.GetBudgetCenterDetailsBO(0, ref dsBudget))
            {
                //Get the budget center info from the db
                //If dataset is null, quit
                if (dsBudget == null)
                {
                    NoRecords();
                }
                else if (dsBudget.Tables.Count == 0)
                {
                    NoRecords();
                    //If no data, quit
                }
                else if (dsBudget.Tables[0].Rows.Count == 0)
                {
                    //Setup data for the budget center drop down list
                }
                else
                {
                    drpBudget.DataSource = dsBudget;
                    drpBudget.DataTextField = "Budget_Center_Name";
                    drpBudget.DataValueField = "Budget_Center_ID";
                    drpBudget.DataBind();

                    if (CheckBudgetCenter(Convert.ToInt32(dsScopeDetails.Tables[0].Rows[0]["Budget_Center_ID"])) == true)
                    {
                        drpBudget.Items.FindByValue(dsScopeDetails.Tables[0].Rows[0]["Budget_Center_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        drpBudget.Items.Insert(0, "-- Select a Budget Center --");
                        drpBudget.SelectedIndex = 0;
                    }
                }
            }
        }
        protected void FillEOScopeDetails()
        {
            if (esbo.GetEOScopeOptionDetailsBO(Scope_Id, ref dsScopeDetails))
            {
                if (dsScopeDetails == null)
                {
                    NoRecords();
                }
                else if (dsScopeDetails.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    FillBudgetCenter(ref dsScopeDetails);
                    txtScopeOption.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Scope_Option_Name"]);
                    if (drpBudget.Items.Count != 0)
                    {
                        if (drpBudget.Items[0].Equals("-- Select a Budget Center --") == false)
                        {
                            txtBounty.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Bounty_Approver_Name"]);
                            txtCharmin.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Charmin_Approver_Name"]);
                            txtPuffs.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Puffs_Approver_Name"]);
                            txtDefault.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["Default_Approver_Name"]);
                            txtSAPCCC.Text = Convert.ToString(dsScopeDetails.Tables[0].Rows[0]["SAP_CCC_Approver_Name"]);
                        }
                        else
                        {
                            txtBounty.Text = "";
                            txtCharmin.Text = "";
                            txtPuffs.Text = "";
                            txtDefault.Text = "";
                            txtSAPCCC.Text = "";
                        }
                    }
                    else
                    {
                        drpBudget.Items.Insert(0, "-- No budget centers found --");
                        drpBudget.SelectedIndex = 0;
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
            Response.Redirect("../Administration/ViewEOScopeOptions.aspx");
        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (txtScopeOption.Text.Trim() == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["ScopeOptionErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (drpBudget.SelectedIndex == 0 & (drpBudget.SelectedValue.Equals("-- Select a Budget Center --") == true || drpBudget.Items[0].Equals("-- No budget centers found --") == true))
            {
                string script = "alert('" + ConfigurationManager.AppSettings["BudgetCtrErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }

            int result = -1;
            SqlParameter[] paramout=new SqlParameter[1];
            if (esbo.InsertEOScopeOptionBO(Scope_Id, txtScopeOption.Text, Convert.ToInt32(drpBudget.SelectedValue), txtBounty.Text, txtCharmin.Text, txtPuffs.Text, txtDefault.Text, txtSAPCCC.Text, cls.getUserFullName(cls.UserName), 'A', ref paramout))
            {
                result = Convert.ToInt32(paramout[0].Value);
                if (result == 0)
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location ='ViewEOScopeOptions.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else if (result == 1)
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }


        protected void drpBudget_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Budget_Center_ID = Convert.ToInt32(drpBudget.Items.FindByValue(drpBudget.SelectedValue).Value)

            if (drpBudget.SelectedIndex != 0 & drpBudget.SelectedValue.Equals("-- Select a Budget Center --") == true)
            {
                txtBounty.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Towel_Approver_Name"]);
                txtCharmin.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Bath_Approver_Name"]);
                txtPuffs.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Tissue_Approver_Name"]);
                txtDefault.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Default_Approver_Name"]);
                txtSAPCCC.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["SAP_Cost_Center_Coordinator"]);
            }
            else if ((drpBudget.SelectedIndex != 0 | drpBudget.SelectedIndex == 0) & drpBudget.Items[0].Equals("-- Select a Budget Center --") == false)
            {
                txtBounty.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex]["Towel_Approver_Name"]);
                txtCharmin.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex]["Bath_Approver_Name"]);
                txtPuffs.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex]["Tissue_Approver_Name"]);
                txtDefault.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex]["Default_Approver_Name"]);
                txtSAPCCC.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex]["SAP_Cost_Center_Coordinator"]);
            }
            else
            {
                txtBounty.Text = "";
                txtCharmin.Text = "";
                txtPuffs.Text = "";
                txtDefault.Text = "";
                txtSAPCCC.Text = "";
            }

        }
        protected void imgDeleteSAPCC_Click(object sender, EventArgs e)
        {
            txtSAPCCC.Text = "";
        }

    }
}