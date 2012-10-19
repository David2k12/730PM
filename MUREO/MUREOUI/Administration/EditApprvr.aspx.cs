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
    public partial class EditApprvr : System.Web.UI.Page
    {
        #region "Variable Declaration"
        static string FunctionID;
        static string ApproverID;
        static string PlantID;
        Approver app = new Approver();
        clsSecurity cls = new clsSecurity();
        #endregion
        string script;
        #region "Page_Events"
        //Sub 	        :   Page_Load 
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Func_ID"] == null | Request.QueryString["App_ID"] == null | Request.QueryString["Plant_ID"] == null)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an approver to view this form'); window.location = 'ViewApprovers.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                imgAddressBook.Attributes.Add("onclick", "javascript:return AddBooksingUser();");
                //Enable javascript onclick event 
                ApproverID = Request.QueryString["App_ID"];
                //Get the approver details 
                FunctionID = Request.QueryString["Func_ID"];
                PlantID = Request.QueryString["Plant_ID"];
                FillEOFunctions();
                //Fill Function drop down list
                FillEOPlant();
                //Fill Plant drop down list
                FillApproverDetail();
                //Fill Approver text box 
                drpFunction.Items.FindByValue(FunctionID).Selected = true;
                //Make sure that the function and plant values are selected accordingly
                drpPlant.Items.FindByValue(PlantID).Selected = true;
                txtApprover.ReadOnly = true;
                //Disable text box edit
            }
        }
        #endregion
        #region "User_Defined_Functions"

        //Sub 	        :   UpdateApprover()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Updates Approver details
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void UpdateApprover()
        {
            int result = -1;
            SqlParameter[] paramout = new SqlParameter[1];
            if (app.InsertEOApproverBO(Convert.ToInt32(Request.QueryString["App_ID"]), txtApprover.Text, Convert.ToInt32(drpPlant.SelectedItem.Value), Convert.ToInt32(drpFunction.SelectedItem.Value), cls.getUserFullName(cls.UserName), 'A', ref paramout))
            {
                result =Convert.ToInt32(paramout[0].Value);
                InsertOperationMessage(result);
            }
        }
        //Sub 	        :   FillApproverDetail()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills Approver name in the text box
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void FillApproverDetail()
        {
            string ApproverName = null;
            DataSet dsapp = new DataSet();
            try
            {

                if (app.GetEOApproverBO(Convert.ToInt32(ApproverID), ref dsapp))
                {

                    ApproverName = Convert.ToString(dsapp.Tables[0].Rows[0]["Approver_Name"]);
                    //Get the approver name using the approver_id obtained from the previous page
                    txtApprover.Text = ApproverName;
                }
                //Set approver name
            }
            catch (System.FormatException ex)
            {
                script = "alert('" + ConfigurationManager.AppSettings["FormatException"] + "'); ";
                Page.RegisterStartupScript("err_msg", script);
            }
        }
        //Sub 	        :   NoRecords()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void NoRecords()
        {
            script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            Page.RegisterStartupScript("error_message", script);
        }
        //Sub 	        :   FillEOFunctions()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills Function drop down list
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void FillEOFunctions()
        {
            DataSet dsEOFunction = new DataSet();
            DataTable dtFunc = new DataTable();
            DataRow drFunc = null;
            dtFunc.Columns.Add("Function_Name");
            dtFunc.Columns.Add("Function_ID");
            if (app.FillEOFunctionBO(0, ref dsEOFunction))
            {
                //Retrieve Function details from the db
                //If dataset is null, display customized error message
                if (dsEOFunction == null)
                {
                    NoRecords();
                    //If no data available, display customized error message
                }
                else if (dsEOFunction.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                    //Function data is available so fill the drop down list
                }
                else
                {
                    for (int rowCt = 0; rowCt <= dsEOFunction.Tables[0].Rows.Count - 1; rowCt++)
                    {
                        string func_name = Convert.ToString(dsEOFunction.Tables[0].Rows[rowCt]["Function_Name"]);
                        int func_id = Convert.ToInt32(dsEOFunction.Tables[0].Rows[rowCt]["Function_ID"]);
                        switch (func_name)
                        {
                            case "QA":
                                drFunc = dtFunc.NewRow();
                                drFunc["Function_Name"] = "Site QA";
                                drFunc["Function_ID"] = func_id;
                                dtFunc.Rows.Add(drFunc);
                                break;
                            default:
                                drFunc = dtFunc.NewRow();
                                drFunc["Function_Name"] = func_name;
                                drFunc["Function_ID"] = func_id;
                                dtFunc.Rows.Add(drFunc);
                                break;
                        }
                    }
                    drpFunction.DataSource = dtFunc;
                    //Set the data source of the drop down list
                    drpFunction.DataTextField = "Function_Name";
                    //Set the display text for the drop down list
                    drpFunction.DataValueField = "Function_ID";
                    //Set the display value for the drop down list
                    drpFunction.DataBind();
                    //Now bind the dataset
                }
                drpFunction.Items.Insert(0, "-- Select a Function --");
            }
        }
        //Sub 	        :   FillEOPlant()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills Plant drop down list
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void FillEOPlant()
        {
            DataSet dsApprovalPlant = new DataSet();
            if (app.FillApproverPlantsBO(0, ref dsApprovalPlant))
            {
                //Get Plant info from db
                //If dataset is null, quit
                if (dsApprovalPlant == null)
                {
                    NoRecords();
                    //If no data, quit
                }
                else if (dsApprovalPlant.Tables.Count == 0)
                {
                    NoRecords();
                    //If no data, quit
                }
                else if (dsApprovalPlant.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    drpPlant.DataSource = dsApprovalPlant;
                    drpPlant.DataTextField = "Plant_Name";
                    drpPlant.DataValueField = "Plant_ID";
                    drpPlant.DataBind();
                }
            }
        }
        //Sub 	        :   InsertOperationMessage
        //Written BY	    :	Vijay
        //parameters     :	Error message string
        //Purpose	    :   Displays update success/failure message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void InsertOperationMessage(int result)
        {
            if (result == 0)
            {
                script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "'); window.location ='ViewApprovers.aspx'; ";
            }
            else if (result == 1)
            {
                script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
            }
            else
            {
                script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); ";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        #endregion
        #region "Button_Events"
        //Sub 	        :   Submit click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Updates approver details when submit button is clicked
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtApprover.Value))
            {
                txtApprover.Text = hdntxtApprover.Value;
            }
            UpdateApprover();
        }
        //Sub 	        :   Cancel click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects user to 'View Approvers' page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07               Vijay          1.0           created

        //***************************************************
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewApprovers.aspx");
        }
        #endregion

    }
}