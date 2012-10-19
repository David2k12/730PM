using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;
using System.Data;
using MUREOBAL;
using System.Configuration;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddApprvr : System.Web.UI.Page
    {
        #region "Variable Declaration"
        clsSecurity cls = new clsSecurity();
         Approver app = new Approver();
        #endregion
        string script;
        #region "Button_Events"
        //Sub 	        :   Submit_Click Event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Adds details of new approver to the db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            //If approver text field empty, display customized error message
            if (!string.IsNullOrEmpty(hdntxtAuthApprover.Value))
            {
                txtAuthApprover.Text = hdntxtAuthApprover.Value;
            }
            if (txtAuthApprover.Text == string.Empty)
            {
                script = "<script>alert('" + ConfigurationManager.AppSettings["ApproverErr"] + "');</script> ";
                ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
                return;
                //If function is not selected, display customized error message
            }
            else if (drpFunction.SelectedIndex == 0)
            {
                script = "<script>alert('" + ConfigurationManager.AppSettings["FunctionErr"] + "');</script> ";
                ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
                return;
                //If plant is not selected, display customized error message
            }
            else if (drpPlant.SelectedIndex == 0)
            {
                script = "<script>alert('" + ConfigurationManager.AppSettings["PlantErr"] + "');</script> ";
                ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
                return;
            }
            //All validations passed, now insert Approver details 
            SqlParameter[] paramout = new SqlParameter[1];
           
            if (app.InsertEOApproverBO(0, txtAuthApprover.Text, Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpFunction.SelectedValue), cls.getUserFullName(cls.UserName), 'A', ref paramout))
            {
                result =Convert.ToInt32(paramout[0].Value);
                InsertOperationMessage(result);
            }            
            txtAuthApprover.Text = string.Empty;
            // Make sure, to reset the fields after the insert operation
            drpFunction.SelectedIndex = 0;
            drpPlant.SelectedIndex = 0;
        }
        //Sub 	        :   Cancel_Click Event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects user to View Approvers page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewApprovers.aspx");
        }
        #endregion
        #region "Page_Events"
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                imgAddressBook.Attributes.Add("onclick", "javascript:return AddBooksingUser();");
                // Enable onclick event to address book image button
                FillApproverPlant();
                //Fill the Plant drop down list
                FillEOFunction();
                // Fill the Function drop down list              
                txtAuthApprover.ReadOnly = true;
                // Make sure the user cannot enter values in text box
            }
        }
        #endregion
        #region "User_Defined_Functions"

        //Sub 	        :   Fill Approver Plant
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills Plant Details in form drop down list  
        //Returns        :   to GUI  
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void FillApproverPlant()
        {
            DataSet dsApprovalPlant = null;
            app.FillApproverPlantsBO(0, ref dsApprovalPlant);
            //Retrieve Plant details from the db
            //If dataset is null, display customized error message
            if (dsApprovalPlant == null)
            {
                NoRecords();
                //If no data available, display customized error message
            }
            else if (dsApprovalPlant.Tables[0].Rows.Count == 0)
            {
                NoRecords();
                //Plant data is available so fill the drop down list
            }
            else
            {
                drpPlant.DataSource = dsApprovalPlant;
                //Set the data source of the drop down list
                drpPlant.DataTextField = "Plant_Name";
                //Set the display text for the drop down list
                drpPlant.DataValueField = "Plant_ID";
                //Set the display value for the drop down list 
                drpPlant.DataBind();
                //Now bind the dataset 
            }
            drpPlant.Items.Insert(0, "-- Select a Plant --");

        }
        //Sub 	        :   No Records
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void NoRecords()
        {
            script = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(),"error_message", script);
        }
        //Sub 	        :   InsertOperationMessage
        //Written BY	    :	Vijay
        //parameters     :	Insert result
        //Purpose	    :   Displays insert success/failure message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void InsertOperationMessage(int insertResult)
        {
            if (insertResult == 0)
            {
                script = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "'); window.location ='ViewApprovers.aspx';</script> ";
            }
            else if (insertResult == 1)
            {
                script = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');</script> ";
            }
            else
            {
                script = "<script>alert('" + ConfigurationManager.AppSettings["InsertError"] + "');</script> ";
            }
            ClientScript.RegisterStartupScript(this.GetType(),"db_error_message", script);
        }
        //Sub 	        :   FillEOFunction()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills function details in function drop down 
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void FillEOFunction()
        {
            DataSet dsEOFunction = null;
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
        #endregion

    }
}