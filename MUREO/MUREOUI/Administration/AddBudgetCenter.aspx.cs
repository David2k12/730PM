using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;
using MUREOBAL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
	public partial class AddBudgetCenter : System.Web.UI.Page
	{
        clsSecurity cls = new clsSecurity();
        BudgetCtrBO bdg = new BudgetCtrBO();
        Approver app = new Approver();
		#region "Page_Event"
//Sub 	        :   Page_Load 
//Written BY	    :	Vijay
//parameters     :	None
//Purpose	    :   Loads form related info on page load
//Returns        :   
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07               Vijay          1.0           created

//***************************************************
protected void Page_Load(object sender, System.EventArgs e)
{
    if (!string.IsNullOrEmpty(hdntxtTowel.Value))
        txtTowel.Text = hdntxtTowel.Value;
    if (!string.IsNullOrEmpty(hdntxtBath.Value))
        txtBath.Text = hdntxtBath.Value;
    if (!string.IsNullOrEmpty(hdntxtDefault.Value))
        txtDefault.Text = hdntxtDefault.Value;
    if (!string.IsNullOrEmpty(hdntxtSAPCCC.Value))
        txtSAPCCC.Text = hdntxtSAPCCC.Value;
    if (!string.IsNullOrEmpty(hdntxtTissue.Value))
        txtTissue.Text = hdntxtTissue.Value;
	//Put user code to initialize the page here
	if (!Page.IsPostBack) {
		FillPlant();
		//Fill plant drop down list
		FillArea();
		//Fill Area drop down list

		//Enable javascript onclick event to address book icons for LDAP 
        imgDeleteSAPCCC.Attributes.Add("onclick", "javascript:return ConfirmDelete();");
		imgAddrbkTowel.Attributes.Add("onclick", "javascript:return AddBookSingUser1();");
        ImgAddrbkBath.Attributes.Add("onclick", "javascript:return AddBookSingUser2();");
        ImgAddrbkTissue.Attributes.Add("onclick", "javascript:return AddBookSingUser3();");
        ImgAddrbkDefault.Attributes.Add("onclick", "javascript:return AddBookSingUser4();");
        ImgAddrBkSAPCC.Attributes.Add("onclick", "javascript:return AddBookSingUser5();");
	}
}
#endregion
#region "User_Defined_Functions"
//Sub 	        :   FillPlant()
//Written BY	    :	Vijay
//parameters     :	None
//Purpose	    :   Fills Plant drop down list with data from db
//Returns        :   
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07               Vijay          1.0           created

//***************************************************
protected void FillPlant()
{
	DataSet dsPlant = new DataSet();
    if (app.FillApproverPlantsBO(0, ref dsPlant))
    {
        //Get the plant info from db
        //If dataset is null, quit
        if (dsPlant == null)
        {
            NoRecords();
        }
        else if (dsPlant.Tables.Count == 0)
        {
            NoRecords();
            //If no data, quit
        }
        else if (dsPlant.Tables[0].Rows.Count == 0)
        {
            NoRecords();
            //Setup data for plant drop down list
        }
        else
        {
            drpPlant.DataSource = dsPlant;
            drpPlant.DataTextField = "Plant_Name";
            drpPlant.DataValueField = "Plant_ID";
            drpPlant.DataBind();
            drpPlant.Items.Insert(0, "-- Select a Plant --");
        }
    }

}
//Sub 	        :   FillArea()
//Written BY	    :	Vijay
//parameters     :	None
//Purpose	    :   Fills Area drop down list with data from db
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07               Vijay          1.0           created

//***************************************************
protected void FillArea()
{
	DataSet dsArea = null;
    if (bdg.FillEOBudgetAreaBO(0, ref dsArea))
    {
        //Get the Area info from db
        //If dataset is null, quit
        if (dsArea == null)
        {
            NoRecords();
        }
        else if (dsArea.Tables.Count == 0)
        {
            NoRecords();
            //If no data, quit
        }
        else if (dsArea.Tables[0].Rows.Count == 0)
        {
            NoRecords();
            //Setup data for Area drop down list
        }
        else
        {
            drpArea.DataSource = dsArea;
            drpArea.DataTextField = "Area_Name";
            drpArea.DataValueField = "Area_ID";
            drpArea.DataBind();
            drpArea.Items.Insert(0, "-- Select a Area --");
        }
    }

}
//Sub 	        :   No Records
//Written BY	    :	Vijay
//parameters     :	None
//Purpose	    :   Displays customized error message to the user
//Returns        :   
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07                 Vijay          1.0           created

//***************************************************
protected void NoRecords()
{
	string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
	ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
}
//Sub 	        :   ValidateBudgetCenter
//Written BY	    :	Vijay
//parameters     :	BudgetCenterName, Valid flag
//Purpose	    :   Checks if new budget center already exists in the db
//Returns        :   Flag indicating true/false
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07                 Vijay          1.0           created

//***************************************************

protected void ValidateBudgetCenter(string NewBudgetCenterName, ref int valid)
{
	DataSet dsBudget = new DataSet();
    if (bdg.GetBudgetCenterDetailsBO(0, ref dsBudget))
    {
        //Get the Budget Center details from db
        if (dsBudget == null)
        {
            NoRecords();
        }
        else if (dsBudget.Tables[0].Rows.Count == 0)
        {
            NoRecords();
        }
        else
        {
            valid = 1;
            //Iterate through the data set and check if record already exists 
            for (int rowCt = 0; rowCt <= dsBudget.Tables[0].Rows.Count - 1; rowCt++)
            {
                string BCN = Convert.ToString(dsBudget.Tables[0].Rows[rowCt]["Budget_Center_Name"]);
                if (NewBudgetCenterName.ToLower() == BCN)
                {
                    valid = 0;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
        }
    }
}
#endregion
#region "Button_Events"
//Sub 	        :   imgSubmit_Click
//Written BY	    :	Vijay
//parameters     :	None
//Purpose	    :   Adds new budget center to db
//Returns        :   None
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07                 Vijay          1.0           created

//***************************************************

protected void imgSubmit_Click(object sender, EventArgs e)
{   
	int valid = 0;
	//Make sure all the required fields are filled out properly
	if (txtBdgtCtrName.Text == string.Empty) {
		string script = "alert('" + ConfigurationManager.AppSettings["BudgetCtrNameErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	} else if (drpPlant.SelectedIndex == 0) {
		string script = "alert('" + ConfigurationManager.AppSettings["PlantErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	} else if (drpArea.SelectedIndex == 0) {
		string script = "alert('" + ConfigurationManager.AppSettings["BudgetCtrAreaErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	} else if (txtTowel.Text == string.Empty) {
		string script = "alert('" + ConfigurationManager.AppSettings["TowelErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	} else if (txtBath.Text == string.Empty) {
		string script = "alert('" + ConfigurationManager.AppSettings["BathErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	} else if (txtTissue.Text == string.Empty) {
		string script = "alert('" + ConfigurationManager.AppSettings["TissueErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	} else if (txtDefault.Text == string.Empty) {
		string script = "alert('" + ConfigurationManager.AppSettings["DefaultErr"] + "'); ";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
		return;
	}

	//ValidateBudgetCenter(txtBdgtCtrName.Text, valid) 'Check if budget center already exists

	//If valid = 0 Then 'If true, display message and quit
	//    Dim script As String = "alert('" & ConfigurationManager.AppSettings["RecordExist") & "') "
	//    Page.RegisterStartupScript("error_message", script)
	//    Exit Sub
	//End If

	//All validations passed, now we can insert budget center details
    int result = -1;
    SqlParameter[] paramout = new SqlParameter[1];
    if (bdg.InsertEOBudgetCenterBO(0, txtBdgtCtrName.Text, Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpArea.SelectedValue), txtTowel.Text, txtBath.Text, txtTissue.Text, txtDefault.Text, txtSAPCCC.Text, cls.UserName, 'A', ref paramout))
    {
        result =Convert.ToInt32(paramout[0].Value);
        //Display insert success/failure message
        if (result == 0)
        {
            string script = "alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='ViewBudgetCenters.aspx' ";
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
//Sub 	        :   imgCancel_Click
//Written BY	    :	Vijay
//parameters     :	None
//Purpose	    :   Redirects user to 'View Budget Centers' page
//Returns        :   None
//Program Change History:
//<Date>			         <Editor>	      	<Rev>		<Description>
//08/06/07                 Vijay          1.0           created

//***************************************************
protected void imgCancel_Click(object sender, EventArgs e)
{
	Response.Redirect("../Administration/ViewBudgetCenters.aspx");
}
#endregion

protected void imgDeleteSAPCCC_Click(object sender, EventArgs e)
{
	txtSAPCCC.Text = "";
}

	}
}