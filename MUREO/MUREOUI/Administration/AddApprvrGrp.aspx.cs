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
    public partial class WebForm1 : System.Web.UI.Page
    {
        clsSecurity clssec = new clsSecurity();

        #region "Variable Declaration"
        #endregion
        DataSet dsBrandbyCat = new DataSet();
        #region "Page_Events"
        //Sub 	        :   Page_Load 
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************

        protected void Page_Load(Object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                trSAP.Visible = false;
                DataSet dsFunctions = null;
                DataSet dsApprovers = new DataSet();
                DataSet dsAdditionalApprovers1 = null;
                DataSet dsAdditionalApprovers2 = null;
                DataSet dsAdditionalApprovers3 = null;
                DataSet dsAdditionalApprovers4 = null;
                string strSiteID = null;
                string strGBUID = null;
                string strSitePlanID = null;
                string strCentralPlanID = null;
                string strSiteLeadID = null;
                string strFinID = null;
                string strPSId = null;
                string strPRID = null;
                string strPSRAID = null;
                string strTimingID = null;
                string strQAID = null;
                string strSOID = null;
                string strSCID = null;
                string strSAPID = null;

                //Added by David on 12/02/2011
                string strAddtlAppr1ID = null;
                string strAddtlAppr2ID = null;
                string strAddtlAppr3ID = null;
                string strAddtlAppr4ID = null;

                FillApprovalGroupCategory();
                //Get category info from db and fill it in the category drop down list
                FillApprovalGroupPlant();
                //Get plant info from db and fill it in the plant drop down list
                Approver app = new Approver();
                if (app.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0, ref dsApprovers))
                {


                    //Get info of all approvers and functions from db

                    //FillAdditionalApprover1()
                    //FillAdditionalApprover2()
                    //FillAdditionalApprover3()
                    //FillAdditionalApprover4()



                    //If dataset is null, quit
                    if (dsApprovers == null)
                    {
                        NoRecords();
                    }
                    else if (dsApprovers.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsApprovers.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();

                    }
                    else
                    {
                        for (int rowCt = 0; rowCt <= dsApprovers.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("site hs&e resource"))
                            {
                                drpSiteHSE.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("gbu hs&e resource"))
                            {
                                drpGBUHSE.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("site planning"))
                            {
                                drpSitePlan.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("central planning"))
                            {
                                drpCentralPlan.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("site leadership"))
                            {
                                drpSiteLeader.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("site finance"))
                            {
                                drpSiteFinance.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("ps initiative manager"))
                            {
                                drpPSInitiative.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("products research"))
                            {
                                drpProductsResearch.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                                //ElseIf Function_Name.ToLower.StartsWith("ps&ra") Then
                                //    drpPSRA.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))
                            }
                            else if (Function_Name.ToLower().StartsWith("timing gate exception"))
                            {
                                drpTimingGate.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("qa"))
                            {
                                drpQA.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("central qa"))
                            {
                                drpCentralQA.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("standards office"))
                            {
                                drpStdOffice.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("site contact"))
                            {
                                drpSiteContact.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));
                            }
                            else if (Function_Name.ToLower().StartsWith("sap cost center coordinator"))
                            {
                                drpSAPCCC.Items.Add(new ListItem(Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"])));

                                //Added by David on 12/02/2011


                                //ElseIf Function_Name.ToLower.StartsWith("additional approver #1") Then
                                //    drpAdditionalAppr1.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //ElseIf Function_Name.ToLower.StartsWith("additional approver #2") Then
                                //    drpAdditionalAppr2.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //ElseIf Function_Name.ToLower.StartsWith("additional approver #3") Then
                                //    drpAdditionalAppr3.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //ElseIf Function_Name.ToLower.StartsWith("additional approver #4") Then
                                //    drpAdditionalAppr4.Items.Add(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name"))

                                //The above code is commented on 01/24/2012 - change in PCR Requirement

                            }
                        }

                        Approver app1=new Approver();
                        if (app1.FillEOAdditionalApprover1ByFunctionBO(1,ref dsAdditionalApprovers1))
                        {
                            //If dataset is null, quit
                            if (dsAdditionalApprovers1 == null)
                            {
                                NoRecords();
                            }
                            else if (dsAdditionalApprovers1.Tables.Count == 0)
                            {
                                NoRecords();
                                //If no data, quit
                            }
                            else if (dsAdditionalApprovers1.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                            }
                            else
                            {

                                for (int rowCt = 0; rowCt <= dsAdditionalApprovers1.Tables[0].Rows.Count - 1; rowCt++)
                                {
                                    string Function_Name = Convert.ToString(dsAdditionalApprovers1.Tables[0].Rows[rowCt]["Function_Name"]);
                                    if (Function_Name.ToLower().StartsWith("additional approver #1"))
                                    {
                                        drpAdditionalAppr1.Items.Add(new ListItem(Convert.ToString(dsAdditionalApprovers1.Tables[0].Rows[rowCt]["Approver_Name"])));
                                    }
                                }
                            }
                        }

                        if (app1.FillEOAdditionalApprover1ByFunctionBO(2, ref dsAdditionalApprovers2))
                        {
                            //If dataset is null, quit
                            if (dsAdditionalApprovers2 == null)
                            {
                                NoRecords();
                            }
                            else if (dsAdditionalApprovers2.Tables.Count == 0)
                            {
                                NoRecords();
                                //If no data, quit
                            }
                            else if (dsAdditionalApprovers2.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                            }
                            else
                            {

                                for (int rowCt = 0; rowCt <= dsAdditionalApprovers2.Tables[0].Rows.Count - 1; rowCt++)
                                {
                                    string Function_Name = Convert.ToString(dsAdditionalApprovers2.Tables[0].Rows[rowCt]["Function_Name"]);
                                    if (Function_Name.ToLower().StartsWith("additional approver #2"))
                                    {
                                        drpAdditionalAppr2.Items.Add(new ListItem(Convert.ToString(dsAdditionalApprovers2.Tables[0].Rows[rowCt]["Approver_Name"])));
                                    }
                                }
                            }
                        }


                        if (app1.FillEOAdditionalApprover1ByFunctionBO(3, ref dsAdditionalApprovers3))
                        {
                            //If dataset is null, quit
                            if (dsAdditionalApprovers3 == null)
                            {
                                NoRecords();
                            }
                            else if (dsAdditionalApprovers3.Tables.Count == 0)
                            {
                                NoRecords();
                                //If no data, quit
                            }
                            else if (dsAdditionalApprovers3.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                            }
                            else
                            {

                                for (int rowCt = 0; rowCt <= dsAdditionalApprovers3.Tables[0].Rows.Count - 1; rowCt++)
                                {
                                    string Function_Name = Convert.ToString(dsAdditionalApprovers3.Tables[0].Rows[rowCt]["Function_Name"]);
                                    if (Function_Name.ToLower().StartsWith("additional approver #3"))
                                    {
                                        drpAdditionalAppr3.Items.Add(new ListItem(Convert.ToString(dsAdditionalApprovers3.Tables[0].Rows[rowCt]["Approver_Name"])));
                                    }
                                }
                            }
                        }

                        if (app1.FillEOAdditionalApprover1ByFunctionBO(4, ref dsAdditionalApprovers4))
                        {

                            //If dataset is null, quit
                            if (dsAdditionalApprovers4 == null)
                            {
                                NoRecords();
                            }
                            else if (dsAdditionalApprovers4.Tables.Count == 0)
                            {
                                NoRecords();
                                //If no data, quit
                            }
                            else if (dsAdditionalApprovers4.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                            }
                            else
                            {

                                for (int rowCt = 0; rowCt <= dsAdditionalApprovers4.Tables[0].Rows.Count - 1; rowCt++)
                                {
                                    string Function_Name = Convert.ToString(dsAdditionalApprovers4.Tables[0].Rows[rowCt]["Function_Name"]);
                                    if (Function_Name.ToLower().StartsWith("additional approver #4"))
                                    {
                                        drpAdditionalAppr4.Items.Add(new ListItem(Convert.ToString(dsAdditionalApprovers4.Tables[0].Rows[rowCt]["Approver_Name"])));
                                    }
                                }
                            }
                        }



                        if (drpSiteHSE.Items.Count == 0)
                        {
                            drpSiteHSE.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpSiteHSE.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpGBUHSE.Items.Count == 0)
                        {
                            drpGBUHSE.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpGBUHSE.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpSitePlan.Items.Count == 0)
                        {
                            drpSitePlan.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpSitePlan.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpCentralPlan.Items.Count == 0)
                        {
                            drpCentralPlan.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpCentralPlan.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpSiteLeader.Items.Count == 0)
                        {
                            drpSiteLeader.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpSiteLeader.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpSiteFinance.Items.Count == 0)
                        {
                            drpSiteFinance.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpSiteFinance.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpPSInitiative.Items.Count == 0)
                        {
                            drpPSInitiative.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpPSInitiative.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpProductsResearch.Items.Count == 0)
                        {
                            drpProductsResearch.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpProductsResearch.Items.Insert(0, "-- Select an approver --");
                        }

                        //If drpPSRA.Items.Count = 0 Then
                        //    drpPSRA.Items.Insert(0, "-- No approvers found --")
                        //Else
                        //    drpPSRA.Items.Insert(0, "-- Select an approver --")
                        //End If

                        if (drpTimingGate.Items.Count == 0)
                        {
                            drpTimingGate.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpTimingGate.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpQA.Items.Count == 0)
                        {
                            drpQA.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpQA.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpCentralQA.Items.Count == 0)
                        {
                            drpCentralQA.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpCentralQA.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpStdOffice.Items.Count == 0)
                        {
                            drpStdOffice.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpStdOffice.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpSiteContact.Items.Count == 0)
                        {
                            drpSiteContact.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpSiteContact.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpSAPCCC.Items.Count == 0)
                        {
                            drpSAPCCC.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpSAPCCC.Items.Insert(0, "-- Select an approver --");
                        }


                        //Added by David on 12/02/2011


                        if (drpAdditionalAppr1.Items.Count == 0)
                        {
                            drpAdditionalAppr1.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpAdditionalAppr1.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpAdditionalAppr2.Items.Count == 0)
                        {
                            drpAdditionalAppr2.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpAdditionalAppr2.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpAdditionalAppr3.Items.Count == 0)
                        {
                            drpAdditionalAppr3.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpAdditionalAppr3.Items.Insert(0, "-- Select an approver --");
                        }

                        if (drpAdditionalAppr4.Items.Count == 0)
                        {
                            drpAdditionalAppr4.Items.Insert(0, "-- No approvers found --");
                        }
                        else
                        {
                            drpAdditionalAppr4.Items.Insert(0, "-- Select an approver --");
                        }



                    }
                }
                //dsFunctions = Approver.FillEOFunctionBO(0)
                //If dsFunctions Is Nothing Then
                //    NoFunctions()
                //ElseIf dsFunctions.Tables.Count = 0 Then
                //    NoFunctions()
                //ElseIf dsFunctions.Tables(0).Rows.Count = 0 Then
                //    NoFunctions()
                //Else
                //    For rowCt As Integer = 0 To dsFunctions.Tables(0).Rows.Count - 1
                //        Dim strFunction As String = dsFunctions.Tables(0).Rows(rowCt)("Function_Name")
                //        Dim strFunctionID As String = dsFunctions.Tables(0).Rows(rowCt)("Function_ID")
                //        Select Case strFunction.ToLower
                //            Case "site hs&e resource" : strSiteID = strFunctionID
                //            Case "gbu hs&e resource" : strGBUID = strFunctionID
                //            Case "site planning" : strSitePlanID = strFunctionID
                //            Case "central planning" : strCentralPlanID = strFunctionID
                //            Case "site leadership" : strSiteLeadID = strFunctionID
                //            Case "site finance" : strFinID = strFunctionID
                //            Case "ps initiative manager" : strPSId = strFunctionID
                //            Case "products research" : strPRID = strFunctionID
                //            Case "timing gate exception" : strTimingID = strFunctionID
                //            Case "qa" : strQAID = strFunctionID
                //            Case "standards office" : strSOID = strFunctionID
                //            Case "site contact" : strSCID = strFunctionID
                //            Case "sap cost center coordinator" : strSAPID = strFunctionID
                //        End Select
                //    Next
                //End If
            }
        }
        #endregion
        #region "Drop_DownList_Events"
        //Sub 	        :   Category selectedindexchanged event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Display Brand values according to category selection
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void drpCategory_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                //Make sure category is selected
                if (!(drpCategory.SelectedIndex == 0))
                {                   
                    Approver app=new Approver();
                    if (app.FillApprovalGroupCategorybyBrandBO(Convert.ToInt32(drpCategory.SelectedValue),ref dsBrandbyCat))
                    //dsBrandbyCat = app.FillApprovalGroupCategorybyBrandBO(drpCategory.SelectedValue);
                    //Get brand info from db using category id as parameter
                    //If data set is null, quit
                    if (dsBrandbyCat == null)
                    {
                        NoRecords();
                        return;
                    }
                    //If no data, make sure brand drop down list is reset
                    if (dsBrandbyCat.Tables[0].Rows.Count == 0)
                    {
                        drpBrand.Items.Clear();
                        drpBrand.Items.Insert(0, "-- No values Found --");
                        //Setup data in brand drop down list
                    }
                    else
                    {
                        drpBrand.DataSource = dsBrandbyCat;
                        drpBrand.DataTextField = "Brand_Segment_Name";
                        drpBrand.DataValueField = "Brand_Segment_ID";
                        drpBrand.DataBind();
                    }
                    //If no category selection, reset brand values
                }
                else
                {
                    drpBrand.Items.Clear();
                    drpBrand.Items.Insert(0, "-- No values Found --");
                }
            }
            catch (System.FormatException ex)
            {
                drpBrand.Items.Clear();
                drpBrand.Items.Insert(0, "-- No values Found --");
            }
        }
        //Sub 	        :   Plant selectedindexchanged event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Sets Approval Group text box with selected plant and EO mode values
        //Returns        :   Flag indicating true/false
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************

        protected void drpPlant_SelectedIndexChanged(Object sender,EventArgs e)
        {
            
        }
        #endregion
        #region "User_Defined_Functions"

        //Sub 	        :   FillApporvalGroupCategory()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills category drop down list with category data from db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void FillApprovalGroupCategory()
        {
            DataSet dsCategory = new DataSet();
            Approver app=new Approver();
            if(app.FillApprovalGroupCategoryBO(0,ref dsCategory))
            {
            //Get all category info from the db
            //If dataset is null, quit
            if (dsCategory == null)
            {
                NoRecords();
            }
            else if (dsCategory.Tables.Count == 0)
            {
                NoRecords();
                //If no data, quit
            }
            else if (dsCategory.Tables[0].Rows.Count == 0)
            {
                NoRecords();
                // Set up the data in the drop down list
            }
            else
            {
                drpCategory.DataSource = dsCategory;
                drpCategory.DataTextField = "Category_Name";
                drpCategory.DataValueField = "Category_ID";
                drpCategory.DataBind();
            }
            drpCategory.Items.Insert(0, "-- Select a Category --");
            //If category is not selected, make sure brand value is reset
            if (drpCategory.SelectedIndex == 0)
            {
                drpBrand.Items.Clear();
                drpBrand.Items.Insert(0, "-- No values Found --");
            }
            }
        }
        //Sub 	        :   FillApprovalGroupPlant()
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Fills plant drop down list with plant data from db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void FillApprovalGroupPlant()
        {
            DataSet dsPlant = null;
            Approver app = new Approver();
            if (app.FillApproverPlantsBO(0, ref dsPlant))
            {
                //Get plant info from db
                //If dataset is null, quit
                if (dsPlant == null)
                {
                    NoRecords();
                    //If no table, quit
                }
                else if (dsPlant.Tables.Count == 0)
                {
                    NoRecords();
                    //If no data, quit
                }
                else if (dsPlant.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                    //Setup data in plant drop down list
                }
                else
                {
                    drpPlant.DataSource = dsPlant;
                    drpPlant.DataTextField = "Plant_Name";
                    drpPlant.DataValueField = "Plant_ID";
                    drpPlant.DataBind();
                }
                drpPlant.Items.Insert(0, "-- Select a Plant --");
            }
        }
        //Sub 	        :   InsertOperationMessage
        //Written BY	    :	Vijay
        //parameters     :	Db result string
        //Purpose	    :   Displays insert success/failure message
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void InsertOperationMessage(int result)
        {
            string script = null;
            if (result == 0)
            {
                script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["InsertSuccess"]) + "'); window.location ='ViewApprovalGroup.aspx';";
            }
            else if (result == 1)
            {
                script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["RecordExist"])+ "'); ";
            }
            else
            {
                script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["InsertError"]) + "'); ";
            }
            //ClientScript.RegisterStartupScript(typeof(Page),"db_error_message", script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
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
            string script = null;
            script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["NoRecords"]) + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void NoFunctions()
        {
            string script = null;
            script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["NoFunctions"]) + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        #endregion
        #region "RadioButtonList_Events"
        //Sub 	        :   rblEOorSite_SelectedIndexChanged
        //Written BY	    :	Vijay
        //parameters     :	Db result string
        //Purpose	    :   Sets Approval Group text box with selected plant and EO mode values
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void rblEOorSite_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string plantName = drpPlant.SelectedItem.Text;
            string EOMode = rblEOorSite.SelectedItem.Text;
            //Make sure that plant is selected
            if (!(drpPlant.SelectedIndex == 0))
            {
                txtAppGrp.Text = plantName + " " + EOMode;
            }
            else
            {
                txtAppGrp.Text = "";
            }
        }
        #endregion
        #region "Button_Events"
        //Sub 	        :   Cancel click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects user to 'View Approval Group' page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void imgCancel_Click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewApprovalGroup.aspx");
        }
        //Sub 	        :   Submit click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Adds new approver group to the db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void ImgSubmit_Click(Object sender, EventArgs e)
        {
            try
            {
                Approver app = new Approver();

                string ApproverList = null;
                char EOMOdedb = '\0';
                string script = null;

                //Make sure all the required fields are filled up, before going for insert operation
                if (drpCategory.SelectedIndex == 0)
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["CategoryErr"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpBrand.SelectedValue.ToLower().StartsWith("-- no values found --"))
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["BrandErrMsg"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpPlant.SelectedIndex == 0)
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["PlantErr"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (rblEOorSite.SelectedIndex == -1)
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["EOErr"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (txtAppGrp.Text.Trim() == string.Empty)
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["ApproverGroupErr"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpSitePlan.SelectedIndex == 0 & !drpSitePlan.SelectedItem.Text.ToLower().StartsWith("-- no approvers found --"))
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["ApproverGrpSitePlan"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpSiteFinance.SelectedIndex == 0 & !drpSiteFinance.SelectedItem.Text.ToLower().StartsWith("-- no approvers found --"))
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["ApproverGrpSiteFinance"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (drpQA.SelectedIndex == 0 & !drpQA.SelectedItem.Text.ToLower().StartsWith("-- no approvers found --"))
                {
                    script = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["ApproverGrpSiteQA"]) + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }

                switch (rblEOorSite.SelectedItem.Text)
                {
                    case "EO":
                        EOMOdedb = 'E';
                        break;
                    case "Site Test":
                        EOMOdedb = 'S';
                        break;
                    case "Other":
                        EOMOdedb = 'O';
                        break;
                }

                if (drpSiteHSE.SelectedIndex != 0 & !drpSiteHSE.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Site HS&E Resource:" + drpSiteHSE.SelectedItem.Text + ",";
                }
                if (drpGBUHSE.SelectedIndex != 0 & !drpGBUHSE.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "GBU HS&E Resource:" + drpGBUHSE.SelectedItem.Text + ",";
                }
                if (drpSitePlan.SelectedIndex != 0 & !drpSitePlan.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Site Planning:" + drpSitePlan.SelectedItem.Text + ",";
                }
                if (drpCentralPlan.SelectedIndex != 0 & !drpCentralPlan.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Central Planning:" + drpCentralPlan.SelectedItem.Text + ",";
                }
                if (drpSiteLeader.SelectedIndex != 0 & !drpSiteLeader.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Site Leadership:" + drpSiteLeader.SelectedItem.Text + ",";
                }
                if (drpSiteFinance.SelectedIndex != 0 & !drpSiteFinance.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Site Finance:" + drpSiteFinance.SelectedItem.Text + ",";
                }
                if (drpPSInitiative.SelectedIndex != 0 & !drpPSInitiative.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "PS Initiative Manager:" + drpPSInitiative.SelectedItem.Text + ",";
                }
                if (drpProductsResearch.SelectedIndex != 0 & !drpProductsResearch.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Products Research:" + drpProductsResearch.SelectedItem.Text + ",";
                }
                //If drpPSRA.SelectedIndex <> 0 And Not drpPSRA.SelectedValue.ToLower.StartsWith("-- no approvers found --") Then
                //    ApproverList &= "PS&RA:" & drpPSRA.SelectedItem.Text & ","
                //End If
                if (drpTimingGate.SelectedIndex != 0 & !drpTimingGate.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Timing Gate Exception:" + drpTimingGate.SelectedItem.Text + ",";
                }
                if (drpQA.SelectedIndex != 0 & !drpQA.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "QA:" + drpQA.SelectedItem.Text + ",";
                }
                if (drpCentralQA.SelectedIndex != 0 & !drpCentralQA.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Central QA:" + drpCentralQA.SelectedItem.Text + ",";
                }
                if (drpStdOffice.SelectedIndex != 0 & !drpStdOffice.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Standards Office:" + drpStdOffice.SelectedItem.Text + ",";
                }
                if (drpSiteContact.SelectedIndex != 0 & !drpSiteContact.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Site Contact:" + drpSiteContact.SelectedItem.Text + ",";
                }
                if (drpSAPCCC.SelectedIndex != 0 & !drpSAPCCC.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "SAP Cost Center Coordinator:" + drpSAPCCC.SelectedItem.Text + ",";
                }

                //Added by David on Dec 2, 2011

                if (drpAdditionalAppr1.SelectedIndex != 0 & !drpAdditionalAppr1.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Additional approver #1:" + drpAdditionalAppr1.SelectedItem.Text + ",";
                }

                if (drpAdditionalAppr2.SelectedIndex != 0 & !drpAdditionalAppr2.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Additional approver #2:" + drpAdditionalAppr2.SelectedItem.Text + ",";
                }

                if (drpAdditionalAppr3.SelectedIndex != 0 & !drpAdditionalAppr3.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Additional approver #3:" + drpAdditionalAppr3.SelectedItem.Text + ",";
                }

                if (drpAdditionalAppr4.SelectedIndex != 0 & !drpAdditionalAppr4.SelectedValue.ToLower().StartsWith("-- no approvers found --"))
                {
                    ApproverList += "Additional approver #4:" + drpAdditionalAppr4.SelectedItem.Text + ",";
                }

                string strApprovers = ApproverList.Remove(ApproverList.LastIndexOf(","), 1);
                //Remove the last ',' from the string

                //For i As Integer = 0 To drgAppGrp.Items.Count - 1
                //    'Make sure the Approvers for QA, Site Finance and Site Planner are selected
                //    If drgAppGrp.Items(i).Cells(1).Text.ToLower = "qa" And CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower.StartsWith("-- select an approver --") Then
                //        script = "alert('" & Convert.ToString(ConfigurationManager.AppSettings["ApproverGrpSiteQA") & "'); "
                //        ClientScript.RegisterStartupScript(typeof(Page),"error_message", script)
                //        Exit Sub
                //    ElseIf drgAppGrp.Items(i).Cells(1).Text.ToLower = "site planner" And CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower.StartsWith("-- select an approver --") Then
                //        script = "alert('" & Convert.ToString(ConfigurationManager.AppSettings["ApproverGrpSitePlan") & "'); "
                //        ClientScript.RegisterStartupScript(typeof(Page),"error_message", script)
                //        Exit Sub
                //    ElseIf drgAppGrp.Items(i).Cells(1).Text.ToLower = "site finance" And CType(drgAppGrp.Items(i).Cells(2).FindControl("drpApprovers"), DropDownList).SelectedValue.ToLower.StartsWith("-- select an approver --") Then
                //        script = "alert('" & Convert.ToString(ConfigurationManager.AppSettings["ApproverGrpSiteFinance") & "'); "
                //        ClientScript.RegisterStartupScript(typeof(Page),"error_message", script)
                //        Exit Sub
                //    End If
                //    'Now add approver list, the list is appended in the format: 'FunctionName1:ApproverName1,....FunctionNameX:ApproverNameX'
                //    If ApproverList = String.Empty Then 'In data grid, find the drop down control and get the selected value
                //        If CType(drgAppGrp.Items(i).Cells(1).FindControl("drpApprovers"), DropDownList).SelectedIndex <> 0 Then 'If value not equals '-- Select an Approver --' add the approver name
                //            ApproverList = drgAppGrp.Items(i).Cells(0).Text & ":" & CType(drgAppGrp.Items(i).Cells(1).FindControl("drpApprovers"), DropDownList).SelectedItem.Text()
                //        End If
                //    Else ' Continue adding the approver list
                //        If CType(drgAppGrp.Items(i).Cells(1).FindControl("drpApprovers"), DropDownList).SelectedIndex <> 0 Then
                //            ApproverList &= "," & drgAppGrp.Items(i).Cells(0).Text & ":" & CType(drgAppGrp.Items(i).Cells(1).FindControl("drpApprovers"), DropDownList).SelectedItem.Text()
                //        End If
                //    End If
                //    'CType(dgrdUpload.Items(i).Cells(1).FindControl("drpApprovers"), DropDownList).SelectedItem.Text()
                //Next
                //ValidateApprGrpName(AppGrpExist) ' Check if approver group already exists
                //If (AppGrpExist = 1) Then 'If true, display message and quit
                //    Dim script As String
                //    script = "alert('" & Convert.ToString(ConfigurationManager.AppSettings["RecordExist") & "'); "
                //    ClientScript.RegisterStartupScript(typeof(Page),"clientscript", script)
                //    Exit Sub
                //End If
                //All validations passed, now we can insert the approver group data
                SqlParameter[] paramout = new SqlParameter[1];
                if (app.InsertEOApprovalGroupBO(0, txtAppGrp.Text, Convert.ToInt32(drpBrand.SelectedValue), Convert.ToInt32(drpPlant.SelectedValue), EOMOdedb, strApprovers, 'A', clssec.UserName, ref paramout))
                {
                    int Result = Convert.ToInt32(paramout[0].Value);
                    InsertOperationMessage(Result);
                }
            }
            catch (NullReferenceException ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

        protected void drpPlant_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                //Make sure plant selection is valid
                if (!(drpPlant.SelectedIndex == 0))
                {
                    if (!string.IsNullOrEmpty(rblEOorSite.SelectedItem.Text))
                        txtAppGrp.Text = String.Format("{0} {1}", drpPlant.SelectedItem.Text, rblEOorSite.SelectedItem.Text);
                    else
                        txtAppGrp.Text = string.Empty;
                }
                else
                {
                    txtAppGrp.Text = "";
                }

            }
            catch (System.NullReferenceException ex)
            {
                ex.Message.ToString();
            }
        }

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         