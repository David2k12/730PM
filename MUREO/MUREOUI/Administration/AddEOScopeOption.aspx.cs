using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddEOScopeOption : System.Web.UI.Page
    {
        #region "Variable Declarations"
        DataSet dsBudget = new DataSet();
        clsSecurity cls = new clsSecurity();
        BudgetCtrBO bdg = new BudgetCtrBO();
        EOScopeOptionBO eosbo = new EOScopeOptionBO();

        #endregion
        int Budget_Center_ID;
        #region "Page_Events"
        //Sub 	        :   Page_Load 
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/10/07               Vijay          1.0           created

        //***************************************************
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                //FillBudgetCenter() 'Fill budget center drop down list
                //drpBudget.Items.Insert(0, "-- Select a Budget Center --")
                //drpBudget.Items.Insert(1, "0510 - Albany")
                //drpBudget.SelectedIndex = 1
                //Set javascript onclick attribute to address book icon 
                //imgDeleteSAPCCC.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the SAP Cost Center Coordinator name? Click OK to delete or CANCEL to abort.');")
                //imgAddrbkTowel.Attributes.Add("onclick", "javascript: AddBookSingUser1();")
                //ImgAddrbkBath.Attributes.Add("onclick", "javascript: AddBookSingUser2();")
                //ImgAddrbkTissue.Attributes.Add("onclick", "javascript: AddBookSingUser3();")
                //ImgAddrbkDefault.Attributes.Add("onclick", "javascript: AddBookSingUser4();")
                //ImgAddrBkSAPCC.Attributes.Add("onclick", "javascript: AddBookSingUser5();")
                //dsBudget = BudgetCtrBO.GetBudgetCenterDetailsBO(0) 'Get the budget center info from the db
                txtTowel.Text = "Julie Moore-JL.3";
                txtBath.Text = "Willie Johnson-WK";
                txtTissue.Text = "Larry Seward-LO";
                txtDefault.Text = "Willie Johnson-WK";
                txtSAPCCC.Text = "Jean Linneman-JM";
            }
        }
        #endregion
        #region "User_Defined_Functions"
        //Sub 	        :   FillBudgetCenter()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills budget center drop down list with data from the db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/10/07               Vijay          1.0           created

        //***************************************************
        protected void FillBudgetCenter()
        {
            if (bdg.GetBudgetCenterDetailsBO(0, ref dsBudget))
            {
                //Get the budget center info from the db
                //If dataset is null, quit
                if (dsBudget == null)
                {
                    NoRecords();
                    //If no data, quit
                }
                else if (dsBudget.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                    //Setup data for the budget center drop down list
                }
                else
                {
                    drpBudget.DataSource = dsBudget;
                    drpBudget.DataTextField = "Budget_Center_Name";
                    drpBudget.DataValueField = "Budget_Center_ID";
                    drpBudget.DataBind();
                    drpBudget.Items.Insert(0, "-- Select a Budget Center --");
                    drpBudget.SelectedIndex = 1;
                    //Make sure default selection is provided
                }
            }
        }
        //Sub 	        :   NoRecords()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/10/07               Vijay          1.0           created

        //***************************************************
        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void drpBudget_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (drpBudget.SelectedIndex != 0)
            {
                //Budget_Center_ID = Convert.ToInt32(drpBudget.Items.FindByValue(drpBudget.SelectedValue).Value)
                txtTowel.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Towel_Approver_Name"]);
                txtBath.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Bath_Approver_Name"]);
                txtTissue.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Tissue_Approver_Name"]);
                txtDefault.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["Default_Approver_Name"]);
                txtSAPCCC.Text = Convert.ToString(dsBudget.Tables[0].Rows[drpBudget.SelectedIndex - 1]["SAP_Cost_Center_Coordinator"]);
            }
            else
            {
                txtTowel.Text = "";
                txtBath.Text = "";
                txtTissue.Text = "";
                txtDefault.Text = "";
                txtSAPCCC.Text = "";
            }

        }
        #endregion
        #region "Button_Events"

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (txtScopeOption.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["ScopeOptionErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (drpBudget.SelectedIndex == 0)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["BudgetCtrErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (txtBath.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["BathErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (txtTissue.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["TissueErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (txtDefault.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["DefaultErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }

            //Dim result As Integer = EOScopeOptionBO.InsertEOScopeOptionBO(0, txtScopeOption.Text, Convert.ToInt32(drpBudget.SelectedValue), txtTowel.Text, txtBath.Text, txtTissue.Text, txtDefault.Text, txtSAPCCC.Text, cls.getUserFullName(cls.UserName), "A")
            int result = -1;
            SqlParameter[] paramout=new SqlParameter[1];

            if (eosbo.InsertEOScopeOptionBO(0, txtScopeOption.Text, Convert.ToInt32(1), txtTowel.Text, txtBath.Text, txtTissue.Text, txtDefault.Text, txtSAPCCC.Text, cls.getUserFullName(cls.UserName), 'A', ref paramout))
            {
                result =Convert.ToInt32(paramout[0].Value);
                if (result == 0)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='ViewEOScopeOptions.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else if (result == 1)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["InsertError"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewEOScopeOptions.aspx");
        }
        #endregion

        protected void imgDeleteSAPCCC_Click(object sender, EventArgs e)
        {
            txtSAPCCC.Text = "";
        }

    }
}