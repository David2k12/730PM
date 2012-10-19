using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;
using MUREOUI.Common;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class ModifyEOScopeBudget : System.Web.UI.Page
    {
        int intMapID;
        EOScopeOptionBO esbo = new EOScopeOptionBO();
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["Mode"] == "Edit")
                    {
                        trCreatePC.Visible = false;
                        trEditPC.Visible = true;
                        FillEOScope();
                        FillPlants();
                        lblCompulsory1.Visible = false;
                        lblCompulsory2.Visible = false;
                        drpEOScopeName.SelectedValue = Request.QueryString["Scope_ID"];
                        drpPlant.SelectedValue = Request.QueryString["PlantID"];
                        FillSuggestedBudgetCenter(Convert.ToInt32(Request.QueryString["PlantID"]));
                        drpBudgetName.SelectedValue = Request.QueryString["BudgetID"];
                        drpEOScopeName.Enabled = false;
                        drpPlant.Enabled = false;
                        intMapID = Convert.ToInt32(Request.QueryString["MapID"]);
                        ViewState["MapID"] = intMapID;
                    }
                    else
                    {
                        lblCompulsory1.Visible = true;
                        lblCompulsory2.Visible = true;
                        FillEOScope();
                        FillPlants();
                        int intPlantID = Convert.ToInt32(drpPlant.SelectedValue);
                        FillSuggestedBudgetCenter(intPlantID);
                        trCreatePC.Visible = true;
                        trEditPC.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void FillEOScope()
        {
            DataSet dsEOScope = new DataSet();
            if (esbo.GetSeedDataforBudget(ref dsEOScope))
            {
                if (dsEOScope == null)
                {
                }
                else if (dsEOScope.Tables.Count == 0)
                {
                }
                else if (dsEOScope.Tables[4].Rows.Count == 0)
                {
                }
                else
                {
                    drpEOScopeName.DataSource = dsEOScope.Tables[4];
                    drpEOScopeName.DataTextField = "Scope_Project_Phase_Name";
                    drpEOScopeName.DataValueField = "Scope_Project_Phase_ID";
                    drpEOScopeName.DataBind();
                }
                drpEOScopeName.Items.Insert(0, "--- Select a EO Scope ---");
            }
        }
        protected void FillPlants()
        {
            DataSet dsPlant = new DataSet();
            if (esbo.GetSeedDataforBudget(ref dsPlant))
            {
                if (dsPlant == null)
                {
                }
                else if (dsPlant.Tables.Count == 0)
                {
                }
                else if (dsPlant.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    drpPlant.DataSource = dsPlant.Tables[2];
                    drpPlant.DataTextField = "Plant_Name";
                    drpPlant.DataValueField = "Plant_ID";
                    drpPlant.DataBind();
                }
                drpPlant.Items.Insert(0, "--- Select a Plant ---");
                drpPlant.Items[0].Value = "0";
            }
        }
        protected void FillSuggestedBudgetCenter(int intPlantID)
        {
            drpBudgetName.Items.Clear();
            DataSet dsSuggBudget = new DataSet();
            if (esbo.FillWithSuggestedBudgetcenter(intPlantID, ref dsSuggBudget))
            {
                if (dsSuggBudget == null)
                {
                }
                else if (dsSuggBudget.Tables.Count == 0)
                {
                }
                else if (dsSuggBudget.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    drpBudgetName.DataSource = dsSuggBudget.Tables[0];
                    drpBudgetName.DataTextField = "Budget_Center_Name";
                    drpBudgetName.DataValueField = "Budget_Center_ID";
                    drpBudgetName.DataBind();
                }
                drpBudgetName.Items.Insert(0, "--- Select a Suggested Budget Center ---");
                drpBudgetName.Items[0].Value = "0";
            }
        }


        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Mode"] == "Edit")
            {
                UpdatePurchaseContact();
            }
            else
            {
                InsertPurchaseContact();
            }
        }

        protected void InsertPurchaseContact()
        {
            int returnValue = 0;
            string script = null;
            string strUserName = cls.UserName;
            intMapID =Convert.ToInt32(ViewState["MapID"]);
            SqlParameter[] paramout = new SqlParameter[1];
            if (drpEOScopeName.SelectedValue != "0" & drpPlant.SelectedValue != "0" & drpBudgetName.SelectedValue != "0")
            {
                if (esbo.SetSuggestedBudgetCenter(0, Convert.ToInt32(drpEOScopeName.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpBudgetName.SelectedValue), strUserName, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);

                    if (returnValue == 0)
                    {                     
                        script = ("alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "'); window.location='../Administration/ViewEOScopeBudget.aspx';");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (returnValue == 1)
                    {
                        script = ("alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); window.location='../Administration/ViewEOScopeBudget.aspx';");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);                     
                    }
                    else
                    {
                        script = ("alert('" + ConfigurationManager.AppSettings["InsertError"] + "'); window.location='../Administration/ViewEOScopeBudget.aspx';");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);                      
                    }
                }
            }
        }
        protected void UpdatePurchaseContact()
        {
            int returnValue = 0;
            string strUserName = cls.UserName;
            string script = null;
            intMapID =Convert.ToInt32(ViewState["MapID"]);
            SqlParameter[] paramout=new SqlParameter[1];

            if (drpEOScopeName.SelectedValue != "0" & drpPlant.SelectedValue != "0" & drpBudgetName.SelectedValue != "0")
            {

                if (esbo.SetSuggestedBudgetCenter(intMapID, Convert.ToInt32(drpEOScopeName.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpBudgetName.SelectedValue), strUserName, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);
                    if (returnValue == 0)
                    {
                        script = ("alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "'); window.location='../Administration/ViewEOScopeBudget.aspx';");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);                      
                    }
                    else if (returnValue == 1)
                    {
                        script = ("alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); window.location='../Administration/ViewEOScopeBudget.aspx';");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);                     
                    }
                    else
                    {
                        script = ("alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); window.location='../Administration/ViewEOScopeBudget.aspx';");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
        }

        protected void drpPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intPlantID = Convert.ToInt32(drpPlant.SelectedValue);
            FillSuggestedBudgetCenter(intPlantID);
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Administration/ViewEOScopeBudget.aspx");
        }

    }
}