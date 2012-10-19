using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Administration
{
    public partial class MaintainEOScopeBudget : System.Web.UI.Page
    {
        #region "Variable Declaration"
        string strScopeName;
        string strPlantName;
        string strBudgetName;
        #endregion
        int intMapID;
        EOScopeOptionBO esbo = new EOScopeOptionBO();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            try
            {

                if (!Page.IsPostBack)
                {
                    imgDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete suggested budgdet center? Click OK to delete or CANCEL to abort.');");

                    //strScopeName = Request.QueryString["ScName")
                    strPlantName = Request.QueryString["plName"];
                    strBudgetName = Request.QueryString["bdName"];

                    lblScopeID.Text = Request.QueryString["Scope_ID"];
                    lblBudgetID.Text = Request.QueryString["BudgetID"];
                    lblPlantID.Text = Request.QueryString["PlantID"];

                    int intScopeID = Convert.ToInt32(lblScopeID.Text);
                    string strScopeName = null;
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
                            for (int intRow = 0; intRow <= dsEOScope.Tables[4].Rows.Count; intRow++)
                            {
                                if (intScopeID ==Convert.ToInt32(dsEOScope.Tables[4].Rows[intRow][0]))
                                {
                                    strScopeName =Convert.ToString(dsEOScope.Tables[4].Rows[intRow][1]);
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                        }
                        //Getting the Map ID
                        DataSet dsBudgetByScope = new DataSet();
                        if (esbo.GetBudgetByEOScope(ref dsBudgetByScope))
                        {
                            //If dataset is null, quit
                            if (dsBudgetByScope == null)
                            {
                                //If no data, quit
                            }
                            else if (dsBudgetByScope.Tables[0].Rows.Count == 0)
                            {
                                //NoRecords()
                            }
                            else
                            {
                                for (int intRowLoop = 0; intRowLoop <= dsBudgetByScope.Tables[0].Rows.Count; intRowLoop++)
                                {
                                    if (Convert.ToInt32(lblScopeID.Text) == Convert.ToInt32(dsBudgetByScope.Tables[0].Rows[intRowLoop][0]) & Convert.ToInt32(lblBudgetID.Text) == Convert.ToInt32(dsBudgetByScope.Tables[0].Rows[intRowLoop][4]) & Convert.ToInt32(lblPlantID.Text) == Convert.ToInt32(dsBudgetByScope.Tables[0].Rows[intRowLoop][2]))
                                    {
                                        intMapID = Convert.ToInt32(dsBudgetByScope.Tables[0].Rows[intRowLoop][6]);
                                        break; // TODO: might not be correct. Was : Exit For
                                    }
                                }
                            }
                            ViewState["MapID"] = intMapID;
                            lblBudgetCenter.Text = strBudgetName;
                            lblPlantName.Text = strPlantName;
                            lblScopeName.Text = strScopeName;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            intMapID =Convert.ToInt32(ViewState["MapID"]);
            Response.Redirect("ModifyEOScopeBudget.aspx?Scope_ID=" + lblScopeID.Text + "&PlantID=" + lblPlantID.Text + "&BudgetID=" + lblBudgetID.Text + "&MapID=" + intMapID + "&Mode=Edit");
            //Redirect to view page 
        }

        //protected Sub imgDelete_Click(ByVal sender As object, ByVal e As EventArgs) Handles imgDelete.Click
        //    Dim returnValue As Integer
        //    Dim script As String
        //    intMapID = ViewState["MapID")
        //    returnValue = EOScopeOptionBO.DeleteSuggestedBudgetcenter(intMapID, Security.UserName)
        //    If returnValue = 0 Then
        //        script = "<script>alert('" & ConfigurationSettings.AppSettings("DeletedSuccess") & "');window.navigate('~/Administration/ViewEOScopeBudget.aspx');</script>"
        //        Page.RegisterStartupScript("clientscript", script)
        //    Else
        //        script = "<script>alert('" & ConfigurationSettings.AppSettings("DeleteError") & "');window.navigate('~/Administration/ViewEOScopeBudget.aspx');</script>"
        //        Page.RegisterStartupScript("clientscript", script)
        //    End If
        //End Sub

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewEOScopeBudget.aspx");
        }

    }
}