using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;

namespace MUREOUI.Administration
{
    public partial class ViewApprvr : System.Web.UI.Page
    {
        #region "Variable Declaration"
        static int FunctionID;
        static int ApproverID;
        static int PlantID;
        string script;
         Approver app = new Approver();
        #endregion
        DataSet dsApproversByFunction;
        #region "Page_Events"
        //Sub 	        :   Page_Load 
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07               Vijay          1.0           created

        //***************************************************
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Funct_ID"] == null | Request.QueryString["Apprv_ID"] == null | Request.QueryString["Plant_ID"] == null)
                {
                    script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an approver to view this form'); window.location = 'ViewApprovers.aspx'; ";
                   ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                FunctionID = Convert.ToInt32(Request.QueryString["Funct_ID"]);
                //Get approver related info from previous page
                ApproverID = Convert.ToInt32(Request.QueryString["Apprv_ID"]);
                PlantID = Convert.ToInt32(Request.QueryString["Plant_ID"]);
                FillEOApproversByFunction();
                //Retrieve approver details from the db
                FillApproverDetail();
                //
            }
        }
        #endregion
        #region "User_Defined_Functions"
        //Sub 	        :   FillEOApproversByFunction
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Retrieves approver details for specific function and plant
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07               Vijay          1.0           created

        //***************************************************
        protected void FillEOApproversByFunction()
        {
            //dsApproversByFunction = Approver.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), PlantID, FunctionID) 'Retrieve approver details for specific function and plant
            //Added by Abdul
           
            if (app.FillEOApproversByFunctionBOMod(Convert.DBNull.ToString(), PlantID, FunctionID, ref dsApproversByFunction))
            {
                //Retrieve approver details for specific function and plant
                if (dsApproversByFunction == null)
                {
                    NoRecords();
                }
                else if (dsApproversByFunction.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
            }
        }
        //Sub 	        :   FillApproverDetail()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Sets form fields with approver details
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07               Vijay          1.0           created

        //***************************************************
        protected void FillApproverDetail()
        {
            string ApproverName = null;
            DataSet dsapp = new DataSet();
            if (app.GetEOApproverBO(ApproverID, ref dsapp))
            {

                ApproverName = Convert.ToString(dsapp.Tables[0].Rows[0]["Approver_Name"]);
                // If ApproverName = dsApproversByFunction.Tables(0).Rows(0)("Approver_Name") Then
                //If there are more approvers for a specific function, iterate until we find the required one
                for (int rowCount = 0; rowCount <= dsApproversByFunction.Tables[0].Rows.Count - 1; rowCount++)
                {
                    //Make sure we got the correct approver
                    if (ApproverName.Trim().ToUpper() == Convert.ToString(dsApproversByFunction.Tables[0].Rows[rowCount]["Approver_Name"]).Trim().ToUpper())
                    {
                        lblApproverName.Text = Convert.ToString(dsApproversByFunction.Tables[0].Rows[rowCount]["Approver_Name"]);
                        //Set the form fields
                        lblFunctionName.Text = Convert.ToString(dsApproversByFunction.Tables[0].Rows[rowCount]["Function_Name"]);
                        if (Convert.ToString(dsApproversByFunction.Tables[0].Rows[rowCount]["Function_Name"]) == "QA")
                        {
                            lblFunctionName.Text = "Site QA";
                        }
                        lblSiteName.Text = Convert.ToString(dsApproversByFunction.Tables[0].Rows[rowCount]["Plant_Name"]);
                        break; // TODO: might not be correct. Was : Exit For
                        //Form fields setup, now we can exit the iteration completely
                    }
                }
            }
            // End If
        }
        //Sub 	        :   NoRecords()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07               Vijay          1.0           created

        //***************************************************
        protected void NoRecords()
        {
            script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        #endregion
        #region "Button_Events"
        //Sub 	        :   Cancel click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects users to 'View Approvers' page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07               Vijay          1.0           created

        //***************************************************
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewApprovers.aspx");
        }
        //Sub 	        :   Edit click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects user to 'Edit approver' page. The user details are sent as query parameters to edit approvers page.
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07               Vijay          1.0           created

        //***************************************************
        protected void imgEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditApprvr.aspx?App_ID=" + ApproverID + "&Func_ID=" + FunctionID + "&Plant_ID=" + PlantID);
        }
        #endregion

    }
}