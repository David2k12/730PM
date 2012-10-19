using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MUREOBAL;
using System.Data;

namespace MUREOUI.Administration
{
    public partial class ViewGrp : System.Web.UI.Page
    {
        #region "Variable Declaration"
        Approver app = new Approver();
        #endregion
        #region "Page_Events"
        //Sub 	        :   Page_Load 
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay              1.0           created

        //***************************************************
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here

            if (!Page.IsPostBack)
            {
                trSap.Visible = false;
                if (Request.QueryString["App_Grp_ID"] == null | Request.QueryString["App_Grp_ID"] == string.Empty)
                {
                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select an approval group to view this form'); window.location = 'ViewApprovalGroup.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                FillAppGrpDetails();
                //Retrieves approver group details and populates it in the form in read-only mode            
            }
        }
        #endregion
        #region "User_Defined_Functions"
        //Sub 	        :   FillAppGrpDetails
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Retrieves the approver group details from the db and populated the values in the form 
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay              1.0           created

        //***************************************************
        protected void FillAppGrpDetails()
        {
            DataSet dsApprovers = null;
            DataSet dsAppGrpOthers = null;
            DataSet dsCatbyBrd = null;
            DataSet dsPlant = null;
            string script = null;
            string CategoryName = null;
            string BrandName = null;
            int App_Grp_ID = 0;
            int Brand_Seg_ID = 0;

            App_Grp_ID = Convert.ToInt32(Request.QueryString["App_Grp_ID"]);
            //Get the approver group id from the view form
            if (app.FillEOApprovalGroupDetailsBO(App_Grp_ID, ref dsApprovers))
            {
                //Retrieve the approver group details
                if (dsApprovers == null)
                {
                    NoRecords();
                }
                else if (dsApprovers.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsApprovers.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    lblCat.Text = Convert.ToString(dsApprovers.Tables[0].Rows[0]["Approval_Group_Name"]);
                    if (app.GetEOApprovalGroupOtherDetailsBO(App_Grp_ID, ref dsAppGrpOthers))
                    {
                        //Retrieve other approver group details
                        if (app.FillApprovalGroupCategorybyBrandBO(0, ref dsCatbyBrd))
                        {
                            //Retrieve category details

                            if (dsAppGrpOthers == null)
                            {
                                NoRecords();
                                return;
                            }
                            else if (dsAppGrpOthers.Tables.Count == 0)
                            {
                                NoRecords();
                                return;
                            }
                            else if (dsAppGrpOthers.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                                return;
                            }

                            if (dsCatbyBrd == null)
                            {
                                NoRecords();
                                return;
                            }
                            else if (dsCatbyBrd.Tables.Count == 0)
                            {
                                NoRecords();
                                return;
                            }
                            else if (dsCatbyBrd.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                                return;
                            }

                            if (app.FillApproverPlantsBO(Convert.ToInt32(dsAppGrpOthers.Tables[0].Rows[0]["Plant_ID"]), ref dsPlant))
                            {
                                //Retrieve plant details
                                if (dsPlant == null)
                                {
                                    NoRecords();
                                    return;
                                }
                                else if (dsPlant.Tables.Count == 0)
                                {
                                    NoRecords();
                                    return;
                                }
                                else if (dsPlant.Tables[0].Rows.Count == 0)
                                {
                                    NoRecords();
                                    return;
                                }

                                Brand_Seg_ID = Convert.ToInt32(dsAppGrpOthers.Tables[0].Rows[0]["Brand_Segment_ID"]);
                            }
                        }
                        //Retrieve brand details
                        //These loop iterations are done to extract the required category and brand name details
                        for (int RowCount = 0; RowCount <= dsCatbyBrd.Tables[0].Rows.Count - 1; RowCount++)
                        {
                            int Brand_Seg_ID2 = Convert.ToInt32(dsCatbyBrd.Tables[0].Rows[RowCount]["Brand_Segment_ID"]);
                            if (Brand_Seg_ID2 == Brand_Seg_ID)
                            {
                                CategoryName = Convert.ToString(dsCatbyBrd.Tables[0].Rows[RowCount]["Category_Name"]);
                                BrandName = Convert.ToString(dsCatbyBrd.Tables[0].Rows[RowCount]["Brand_Segment_Name"]);
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                        char EO = Convert.ToChar(dsAppGrpOthers.Tables[0].Rows[0]["EO_Mode"]);
                        switch (EO)
                        {
                            case 'E':
                                lblE.Text = "EO";
                                break;
                            case 'S':
                                lblE.Text = "Site Test";
                                break;
                            case 'O':
                                lblE.Text = "Other";
                                break;
                        }

                        for (int rowCt = 0; rowCt <= dsApprovers.Tables[0].Rows.Count - 1; rowCt++)
                        {
                            string Function_Name = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Function_Name"]);
                            if (Function_Name.ToLower().StartsWith("site hs&e resource"))
                            {
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblSiteHSE.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //lblSiteHSE.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("gbu hs&e resource"))
                            {
                                // If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblGBUHSE.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblGBUHSE.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("site planning"))
                            {
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblSitePlan.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //lblSitePlan.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("central planning"))
                            {
                                // If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblCentralPlan.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblCentralPlan.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("site leadership"))
                            {
                                // If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblSiteLeader.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblSiteLeader.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("site finance"))
                            {
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblSiteFinance.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblSiteFinance.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("ps initiative manager"))
                            {
                                // If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblPSInitiative.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblPSInitiative.Text = ""
                                //End If
                            }
                            else if (Function_Name.ToLower().StartsWith("products research"))
                            {
                                // If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblProductsResearch.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblProductsResearch.Text = ""
                                //End If
                                //ElseIf Function_Name.ToLower.StartsWith("ps&ra") Then
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                //lblPSRA.Text = dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")
                                //Else
                                //    lblPSRA.Text = ""
                                //End If
                            }
                            else if (Function_Name.ToLower().StartsWith("timing gate exception"))
                            {
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblTimingGate.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblTimingGate.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("qa"))
                            {
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblQA.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblQA.Text = ""
                                //End If
                            }
                            else if (Function_Name.ToLower().StartsWith("central qa"))
                            {
                                lblCentralQA.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                            }
                            else if (Function_Name.ToLower().StartsWith("standards office"))
                            {
                                //If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblStdOffice.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblStdOffice.Text = ""
                                //End If

                            }
                            else if (Function_Name.ToLower().StartsWith("site contact"))
                            {
                                // If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                lblSiteContact.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                                //Else
                                //    lblSiteContact.Text = ""
                                //End If

                                //ElseIf Function_Name.ToLower.StartsWith("sap cost center coordinator") Then
                                //    ' If CheckApproverNameChange(dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")) = True Then
                                //    lblSAPCCC.Text = dsApprovers.Tables(0).Rows(rowCt)("Approver_Name")
                                //    'Else
                                //    '    lblSAPCCC.Text = ""
                                //    'End If



                                //Added by David - MUREO PCR - Date 01-03-2012

                            }
                            else if (Function_Name.ToLower().StartsWith("additional approver #1"))
                            {
                                lblAdditionalAppr1.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);

                            }
                            else if (Function_Name.ToLower().StartsWith("additional approver #2"))
                            {
                                lblAdditionalAppr2.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);

                            }
                            else if (Function_Name.ToLower().StartsWith("additional approver #3"))
                            {
                                lblAdditionalAppr3.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);

                            }
                            else if (Function_Name.ToLower().StartsWith("additional approver #4"))
                            {
                                lblAdditionalAppr4.Text = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                            }

                        }
                        lblCat.Text = CategoryName;
                        //Set the category name label
                        lblBrd.Text = BrandName;
                        //Set the brand name label
                        lblPlt.Text = Convert.ToString(dsPlant.Tables[0].Rows[0]["Plant_Name"]);
                        //Set the plant name label
                        lblAppGrp.Text = Convert.ToString(dsApprovers.Tables[0].Rows[0]["Approval_Group_Name"]);
                        //Set the approver group label                   
                    }
                }
            }
        }
        protected bool CheckApproverNameChange(string Appr_Name)
        {
            DataSet dsApprovers = new DataSet();
            if (app.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0, ref dsApprovers))
            {
                if (dsApprovers == null)
                {
                }
                else if (dsApprovers.Tables.Count == 0)
                {
                }
                else if (dsApprovers.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    for (int rowCt = 0; rowCt <= dsApprovers.Tables[0].Rows.Count - 1; rowCt++)
                    {
                        string approver_name = Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]);
                        if (approver_name.Trim().ToLower() == Appr_Name.Trim().ToLower())
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }
        //Sub 	        :   NoRecords
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay              1.0           created

        //***************************************************
        protected void NoRecords()
        {
            string script = null;
            script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        #endregion
        #region "Button_Events"
        //Sub 	        :   Edit click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects user to edit approver group page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay              1.0           created

        //***************************************************
        protected void ImgEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditApprvrGrp.aspx?App_Grp_ID=" + Request.QueryString["App_Grp_ID"] + "&App_Grp_Name=" + lblAppGrp.Text + "&Cat_Name=" + lblCat.Text + "&Brd_Name=" + lblBrd.Text + "&Plt_Name=" + lblPlt.Text + "&EO_Mode=" + lblE.Text);
        }
        //Sub 	        :   Cancel click event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Redirects user to view approver group page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay              1.0           created

        //***************************************************
        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewApprovalGroup.aspx");
        }
        #endregion

    }
}