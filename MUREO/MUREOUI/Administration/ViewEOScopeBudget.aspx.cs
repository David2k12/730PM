using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using MUREOBAL;
using System.Data;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class ViewEOScopeBudget : System.Web.UI.Page
    {
        EOScopeOptionBO esbo = new EOScopeOptionBO();
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                FillEOScopeByBudgetCenter();
            }
        }
        protected void FillEOScopeByBudgetCenter()
        {
            EOScopeOptionBO eosc = new EOScopeOptionBO();
            // Dim dsApproversByCategory As DataSet
            DataSet dsBudgetByScope = new DataSet();
            if (eosc.GetBudgetByEOScope(ref dsBudgetByScope))
            {
                //Retrieve all approver related info from the db
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
                    DataTable dtScopeByBudget = new DataTable();
                    //Create a new datatable to store function and approver details
                    DataRow drScopeByBudget = null;
                    dtScopeByBudget.Columns.Add("SO_ID");
                    //Create the needed columns for tree view display
                    dtScopeByBudget.Columns.Add("Scope_Option_Name");
                    dtScopeByBudget.Columns.Add("Plant_ID");
                    dtScopeByBudget.Columns.Add("Plant_Name");
                    dtScopeByBudget.Columns.Add("Budget_Center_ID");
                    dtScopeByBudget.Columns.Add("Budget_Center_Name");
                    //dtScopeByBudget.Columns.Add("Scope_Option_ID")

                    //Below code for splitting data for treeview display and binding splitted data into temperory table
                    ArrayList arrayEOScopeName = new ArrayList();
                    ArrayList arrayScopeID = new ArrayList();

                    //First row item of function name
                    string strFunctionName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[0][1]);
                    //Function Name
                    string strFunctionID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[0][0]);
                    //Function ID

                    //Adding function name to array
                    arrayEOScopeName.Add(strFunctionName);
                    arrayScopeID.Add(strFunctionID);

                    //Adding all function names(Without repitition)
                    for (int rowCount = 0; rowCount <= dsBudgetByScope.Tables[0].Rows.Count - 1; rowCount++)
                    {
                        string strFunctionName1 = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowCount][1]);
                        string strFunctionID1 = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowCount][0]);
                        //If function name not already in the list, add it now
                        if (!(arrayEOScopeName.Contains(strFunctionName1)))
                        {
                            arrayEOScopeName.Add(strFunctionName1);
                            arrayScopeID.Add(strFunctionID1);
                        }
                    }
                    //Based on function name storing function id and function name in to temperory table
                    for (int rowFunctionNameCount = 0; rowFunctionNameCount <= arrayEOScopeName.Count - 1; rowFunctionNameCount++)
                    {
                        drScopeByBudget = dtScopeByBudget.NewRow();
                        //Store function name and id
                        drScopeByBudget["SO_ID"] = arrayScopeID[rowFunctionNameCount];
                        drScopeByBudget["Scope_Option_Name"] = arrayEOScopeName[rowFunctionNameCount];
                        drScopeByBudget["Plant_Name"] = "";
                        drScopeByBudget["Budget_Center_Name"] = "";
                        //drScopeByBudget("Scope_Option_ID") = ""
                        dtScopeByBudget.Rows.Add(drScopeByBudget);


                        ArrayList arrayPlantID = new ArrayList();
                        ArrayList arrayPlantName = new ArrayList();
                        ArrayList arrayBudgetName = new ArrayList();
                        ArrayList arrayBudgetID = new ArrayList();
                        ArrayList arrayScopeMappingID = new ArrayList();
                        //Adding approver names(Without repitition) based on function name
                        for (int rowApproverCount = 0; rowApproverCount <= dsBudgetByScope.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {
                            if (Convert.ToString(arrayEOScopeName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Option_Name"]).Trim().ToUpper())
                            {
                                string strPlantName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Plant_Name"]);
                                string strBudgetCenterName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Budget_Center_Name"]);
                                string strBudgetCenterID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Budget_Center_ID"]);
                                string PlantID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
                                string strScopeMappingID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Mapping_ID"]);
                                arrayBudgetName.Add(strBudgetCenterName);
                                arrayPlantName.Add(strPlantName);
                                arrayBudgetID.Add(Convert.ToInt32(strBudgetCenterID));
                                arrayPlantID.Add(Convert.ToInt32(PlantID));
                                arrayScopeMappingID.Add(Convert.ToInt32(strScopeMappingID));
                            }
                        }
                        ArrayList arrayEOScopeID1 = new ArrayList();
                        ArrayList arrayEOScopeName1 = new ArrayList();
                        ArrayList arrayPlantID1 = new ArrayList();
                        ArrayList arrayBudgetCenterID1 = new ArrayList();
                        //Dim arrayBudgetCenterName1 As New ArrayList
                        // Dim arrayScopeMappingID1 As New ArrayList
                        for (int rowApproverCount = 0; rowApproverCount <= dsBudgetByScope.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {
                            if (Convert.ToString(arrayEOScopeName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Option_Name"]).Trim().ToUpper())
                            {
                                string strPlantID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
                                string strEOScopeID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["SO_ID"]);
                                string strBudgetCenterID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Budget_Center_ID"]);
                                string strEOScopeName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Option_Name"]);
                                string strScopeMappingID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Mapping_ID"]);
                                if (arrayEOScopeID1.Count == 0)
                                {
                                    arrayEOScopeID1.Add(strEOScopeID);
                                    arrayPlantID1.Add(strPlantID);
                                    arrayBudgetCenterID1.Add(strBudgetCenterID);
                                    arrayEOScopeName1.Add(strEOScopeName);
                                    //arrayBudgetCenterName1.Add(strBudgetCenterName)
                                    //arrayScopeMappingID1.Add(strScopeMappingID)
                                }
                                if (!(arrayPlantID1.Contains(strPlantID)))
                                {
                                    arrayEOScopeID1.Add(strEOScopeID);
                                    arrayPlantID1.Add(strPlantID);
                                    arrayBudgetCenterID1.Add(strBudgetCenterID);
                                    arrayEOScopeName1.Add(strEOScopeName);
                                    //arrayScopeMappingID1.Add(strScopeMappingID)
                                }
                            }
                        }
                        bool funct_add = false;
                        string funct_id = null;
                        int addCount = 0;
                        //Based on Function name storing Function ID, Approver name,Approver id,Plant name,Plant Id into temperory table
                        for (int rowApproverCount1 = 0; rowApproverCount1 <= arrayPlantName.Count - 1; rowApproverCount1++)
                        {
                            drScopeByBudget = dtScopeByBudget.NewRow();
                            //drAppbyFunction("Function_ID") = dsApproversByCategory.Tables(0).Rows(rowApproverCount1)("Function_ID")
                            drScopeByBudget["SO_ID"] = arrayEOScopeID1[rowApproverCount1];
                            drScopeByBudget["Plant_ID"] = arrayPlantID1[rowApproverCount1];
                            drScopeByBudget["Scope_Option_Name"] = "";
                            drScopeByBudget["Plant_Name"] = arrayPlantName[rowApproverCount1];
                            drScopeByBudget["Budget_Center_Name"] = arrayBudgetName[rowApproverCount1];
                            drScopeByBudget["Budget_Center_ID"] = arrayBudgetCenterID1[rowApproverCount1];
                            // drScopeByBudget("Scope_Option_ID") = arrayScopeMappingID1(rowApproverCount1)
                            dtScopeByBudget.Rows.Add(drScopeByBudget);
                        }
                    }
                    drgdEOScopeBudget.DataSource = dtScopeByBudget;
                    drgdEOScopeBudget.DataBind();
                }
            }
        }

        //protected void FillEOScopeByBudgetCenter()
        //{
        //    // Dim dsApproversByCategory As DataSet
        //    DataSet dsBudgetByScope = new DataSet(); ;
        //    if (esbo.GetBudgetByEOScope(ref dsBudgetByScope))
        //    {
        //        //Retrieve all approver related info from the db
        //        //If dataset is null, quit
        //        if (dsBudgetByScope == null)
        //        {
        //            //If no data, quit
        //        }
        //        else if (dsBudgetByScope.Tables[0].Rows.Count == 0)
        //        {
        //            //NoRecords()
        //        }
        //        else
        //        {
        //            DataTable dtScopeByBudget = new DataTable();
        //            //Create a new datatable to store function and approver details
        //            DataRow drScopeByBudget = null;
        //            dtScopeByBudget.Columns.Add("SO_ID");
        //            //Create the needed columns for tree view display
        //            dtScopeByBudget.Columns.Add("Scope_Option_Name");
        //            dtScopeByBudget.Columns.Add("Plant_ID");
        //            dtScopeByBudget.Columns.Add("Plant_Name");
        //            dtScopeByBudget.Columns.Add("Budget_Center_ID");
        //            dtScopeByBudget.Columns.Add("Budget_Center_Name");
        //            //dtScopeByBudget.Columns.Add("Scope_Option_ID")

        //            //Below code for splitting data for treeview display and binding splitted data into temperory table
        //            ArrayList arrayEOScopeName = new ArrayList();
        //            ArrayList arrayScopeID = new ArrayList();

        //            //First row item of function name
        //            string strFunctionName =Convert.ToString(dsBudgetByScope.Tables[0].Rows[0][1]);
        //            //Function Name
        //            string strFunctionID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[0][0]);
        //            //Function ID

        //            //Adding function name to array
        //            arrayEOScopeName.Add(strFunctionName);
        //            arrayScopeID.Add(strFunctionID);

        //            //Adding all function names(Without repitition)
        //            for (int rowCount = 0; rowCount <= dsBudgetByScope.Tables[0].Rows.Count - 1; rowCount++)
        //            {
        //                string strFunctionName1 = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowCount][1]);
        //                string strFunctionID1 = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowCount][0]);
        //                //If function name not already in the list, add it now
        //                if (!(arrayEOScopeName.Contains(strFunctionName1)))
        //                {
        //                    arrayEOScopeName.Add(strFunctionName1);
        //                    arrayScopeID.Add(strFunctionID1);
        //                }
        //            }
        //            //Based on function name storing function id and function name in to temperory table
        //            for (int rowFunctionNameCount = 0; rowFunctionNameCount <= arrayEOScopeName.Count - 1; rowFunctionNameCount++)
        //            {
        //                drScopeByBudget = dtScopeByBudget.NewRow();
        //                //Store function name and id
        //                drScopeByBudget["SO_ID"] = arrayScopeID[rowFunctionNameCount];
        //                drScopeByBudget["Scope_Option_Name"] = arrayEOScopeName[rowFunctionNameCount];
        //                drScopeByBudget["Plant_Name"] = "";
        //                drScopeByBudget["Budget_Center_Name"] = "";
        //                //drScopeByBudget("Scope_Option_ID") = ""
        //                dtScopeByBudget.Rows.Add(drScopeByBudget);


        //                ArrayList arrayPlantID = new ArrayList();
        //                ArrayList arrayPlantName = new ArrayList();
        //                ArrayList arrayBudgetName = new ArrayList();
        //                ArrayList arrayBudgetID = new ArrayList();
        //                ArrayList arrayScopeMappingID = new ArrayList();
        //                //Adding approver names(Without repitition) based on function name
        //                for (int rowApproverCount = 0; rowApproverCount <= dsBudgetByScope.Tables[0].Rows.Count - 1; rowApproverCount++)
        //                {
        //                    if (Convert.ToString(arrayEOScopeName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Option_Name"]).Trim().ToUpper())
        //                    {
        //                        string strPlantName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Plant_Name"]);
        //                        string strBudgetCenterName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Budget_Center_Name"]);
        //                        string strBudgetCenterID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Budget_Center_ID"]);
        //                        string PlantID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
        //                        string strScopeMappingID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Mapping_ID"]);
        //                        arrayBudgetName.Add(strBudgetCenterName);
        //                        arrayPlantName.Add(strPlantName);
        //                        arrayBudgetID.Add(Convert.ToInt32(strBudgetCenterID));
        //                        arrayPlantID.Add(Convert.ToInt32(PlantID));
        //                        arrayScopeMappingID.Add(Convert.ToInt32(strScopeMappingID));
        //                    }
        //                }
        //                ArrayList arrayEOScopeID1 = new ArrayList();
        //                ArrayList arrayEOScopeName1 = new ArrayList();
        //                ArrayList arrayPlantID1 = new ArrayList();
        //                ArrayList arrayBudgetCenterID1 = new ArrayList();
        //                //Dim arrayBudgetCenterName1 As New ArrayList
        //                // Dim arrayScopeMappingID1 As New ArrayList
        //                for (int rowApproverCount = 0; rowApproverCount <= dsBudgetByScope.Tables[0].Rows.Count - 1; rowApproverCount++)
        //                {
        //                    if (Convert.ToString(arrayEOScopeName[rowFunctionNameCount]).Trim().ToUpper() == Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Option_Name"]).Trim().ToUpper())
        //                    {
        //                        string strPlantID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
        //                        string strEOScopeID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["SO_ID"]);
        //                        string strBudgetCenterID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Budget_Center_ID"]);
        //                        string strEOScopeName = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Option_Name"]);
        //                        string strScopeMappingID = Convert.ToString(dsBudgetByScope.Tables[0].Rows[rowApproverCount]["Scope_Mapping_ID"]);
        //                        if (arrayEOScopeID1.Count == 0)
        //                        {
        //                            arrayEOScopeID1.Add(strEOScopeID);
        //                            arrayPlantID1.Add(strPlantID);
        //                            arrayBudgetCenterID1.Add(strBudgetCenterID);
        //                            arrayEOScopeName1.Add(strEOScopeName);
        //                            //arrayBudgetCenterName1.Add(strBudgetCenterName)
        //                            //arrayScopeMappingID1.Add(strScopeMappingID)
        //                        }
        //                        if (!(arrayPlantID1.Contains(strPlantID)))
        //                        {
        //                            arrayEOScopeID1.Add(strEOScopeID);
        //                            arrayPlantID1.Add(strPlantID);
        //                            arrayBudgetCenterID1.Add(strBudgetCenterID);
        //                            arrayEOScopeName1.Add(strEOScopeName);
        //                            //arrayScopeMappingID1.Add(strScopeMappingID)
        //                        }
        //                    }
        //                }
        //                bool funct_add = false;
        //                string funct_id = null;
        //                int addCount = 0;
        //                //Based on Function name storing Function ID, Approver name,Approver id,Plant,Plant Id into temperory table
        //                for (int rowApproverCount1 = 0; rowApproverCount1 <= arrayPlantName.Count - 1; rowApproverCount1++)
        //                {
        //                    drScopeByBudget = dtScopeByBudget.NewRow();
        //                    //drAppbyFunction("Function_ID") = dsApproversByCategory.Tables(0).Rows(rowApproverCount1)("Function_ID")
        //                    drScopeByBudget["SO_ID"] = arrayEOScopeID1[rowApproverCount1];
        //                    drScopeByBudget["Plant_ID"] = arrayPlantID1[rowApproverCount1];
        //                    drScopeByBudget["Scope_Option_Name"] = "";
        //                    drScopeByBudget["Plant_Name"] = arrayPlantName[rowApproverCount1];
        //                    drScopeByBudget["Budget_Center_Name"] = arrayBudgetName[rowApproverCount1];
        //                    drScopeByBudget["Budget_Center_ID"] = arrayBudgetCenterID1[rowApproverCount1];
        //                    // drScopeByBudget("Scope_Option_ID") = arrayScopeMappingID1(rowApproverCount1)
        //                    dtScopeByBudget.Rows.Add(drScopeByBudget);
        //                }
        //            }
        //            drgdEOScopeBudget.DataSource = dsBudgetByScope.Tables[0];
        //            drgdEOScopeBudget.DataBind();
        //        }
        //    }
        //}
        protected void lnkPlantName_Command(object sender, CommandEventArgs e)
        {
            LinkButton lkbplant = (LinkButton)sender;
            Response.Redirect("MaintainEOScopeBudget.aspx?Scope_ID=" + Convert.ToString(lkbplant.Attributes["ScopeID"]) + "&PlantID=" + Convert.ToString(lkbplant.Attributes["PlantID"]) + "&BudgetID=" + Convert.ToString(lkbplant.Attributes["BudgetID"]) + "&ScName=" + Convert.ToString(lkbplant.Attributes["ScopeName"]) + "&plName=" + lkbplant.Text + "&bdName=" + Convert.ToString(lkbplant.Attributes["BudgetName"]));
        }
        protected void imgFunction1_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            ImageButton imgFunction1 = (ImageButton)sender;
            ImageButton imgFunction2 = (ImageButton)imgFunction1.Parent.FindControl("imgFunction2");
            //imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
            imgFunction2.Visible = true;
            //Make collapse button visible            
            imgFunction1.Visible = false;
            string st = string.Empty;
            //Make expand button invisible
            // ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgFunction1.Parent;
            int rowno = gvd.ItemIndex;
            ViewState["SingleMain"] = Convert.ToString(rowno);
            for (int rowCount = rowno + 1; rowCount <= drgdEOScopeBudget.VisibleRowCount - 1; rowCount++)
            {
                Label lblScopeName = (Label)drgdEOScopeBudget.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdEOScopeBudget.Columns["EO Scope Name"], "lblEOScopeName");
                LinkButton lnkPlantName = (LinkButton)drgdEOScopeBudget.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdEOScopeBudget.Columns["Plant"], "lnkPlantName");
                //ImageButton imgRemoveApprover = (ImageButton)drgdEOScopeBudget.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdEOScopeBudget.Columns["Delete Approver"], "imgRemoveApprover");
                if (lblScopeName != null)
                {
                    if (string.IsNullOrEmpty(lblScopeName.Text))
                    {


                        if (!string.IsNullOrEmpty(lnkPlantName.Text))
                        {
                            st = st + Convert.ToString(rowCount) + ",";
                            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblScopeName.Parent.Parent.Parent;
                            gvdc.Visible = true;
                            lnkPlantName.Visible = true;
                        }
                        else
                        {
                            //drgdEOScopeBudget.Items[rowCount].Visible = false;
                            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblScopeName.Parent.Parent.Parent;
                            gvdc.Visible = false;

                        }
                    }
                    else
                    {

                        break;
                    }
                }
                else
                {
                    break;
                }


                //ImageButton imgFunction2 = default(ImageButton);
                //        imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
                //        imgFunction2.Visible = true;
                //        //Make collapse button visible

                //        ImageButton imgFunction1 = default(ImageButton);
                //        imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
                //        imgFunction1.Visible = false;
                //        //Make expand button invisible
                //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");

                //        int rowno = e.Item.ItemIndex;
                //        for (int rowCount = rowno + 1; rowCount <= drgdEOScopeBudget.Items.Count - 1; rowCount++)
                //        {
                //            Label lblScopeName = (Label)drgdEOScopeBudget.Items(rowCount).FindControl("lblEOScopeName");
                //            LinkButton lnkPlantName = (LinkButton)drgdEOScopeBudget.Items(rowCount).FindControl("lnkPlantName");
                //            // Dim imgRemoveApprover As ImageButton = CType(drgdEOScopeBudget.Items(rowCount).FindControl("imgRemoveApprover"), ImageButton)
                //            if (string.IsNullOrEmpty(lblScopeName.Text))
                //            {
                //                if (!string.IsNullOrEmpty(lnkPlantName.Text))
                //                {
                //                    drgdEOScopeBudget.Items(rowCount).Visible = true;
                //                    lnkPlantName.Visible = true;
                //                    // imgRemoveApprover.Visible = True
                //                }
                //                else
                //                {
                //                    drgdEOScopeBudget.Items(rowCount).Visible = false;
                //                }
                //            }
                //            else
                //            {
                //                break; // TODO: might not be correct. Was : Exit For
                //            }
                //        }
            }
            ViewState["Single"] = st.TrimEnd(new char[] { ',' });
            //FillEOApproversByFunction();      
        }
        protected void imgFunction2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            ImageButton imgFunction2 = (ImageButton)sender;
            imgFunction2.Visible = false;
            //Make collapse button invisible
            ImageButton imgFunction1 = (ImageButton)imgFunction2.Parent.FindControl("imgFunction1");
            imgFunction1.Visible = true;
            //Make collapse button visible                        
            string st = string.Empty;
            //Make expand button invisible
            // ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgFunction1.Parent;
            int rowno = gvd.ItemIndex;
            ViewState["SingleMain"] = Convert.ToString(rowno);
            for (int rowCount = rowno + 1; rowCount <= drgdEOScopeBudget.VisibleRowCount - 1; rowCount++)
            {
                Label lblScopeName = (Label)drgdEOScopeBudget.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdEOScopeBudget.Columns["EO Scope Name"], "lblEOScopeName");
                LinkButton lnkPlantName = (LinkButton)drgdEOScopeBudget.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdEOScopeBudget.Columns["Plant"], "lnkPlantName");
                //ImageButton imgRemoveApprover = (ImageButton)drgdEOScopeBudget.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdEOScopeBudget.Columns["Delete Approver"], "imgRemoveApprover");
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;


                if (lblScopeName != null)
                {
                    if (string.IsNullOrEmpty(lblScopeName.Text))
                    {

                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblScopeName.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }


            }
        }
        protected void NoRecords()
        {
            string script = null;
            script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        protected void drgdEOScopeBudget_PageIndexChanged(object sender, EventArgs e)
        {
            FillEOScopeByBudgetCenter();
        }
        protected void drgdEOScopeBudget_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ImageButton imgFunction1 = (ImageButton)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["FunctionName"], "imgFunction1");
                ImageButton imgFunction2 = (ImageButton)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["FunctionName"], "imgFunction2");
                Label lblEOScopeID = (Label)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["EO Scope Name"], "lblEOScopeID");
                Label lblScopeName = (Label)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["EO Scope Name"], "lblEOScopeName");
                Label lblScopeID = (Label)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["EO Scope Name"], "lblEOScopeID");
                Label lblBudgetName = (Label)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["Suggested Budget center name"], "lblBudgetName");
                LinkButton lblPlantName = (LinkButton)drgdEOScopeBudget.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdEOScopeBudget.Columns["Plant"], "lnkPlantName");
                if (lblPlantName != null)
                {
                    if (ViewState["Expand"] != null)
                    {
                        if (!(ViewState["Expand"] == "ExpandMode"))
                        {
                            //Displaying only Function names in first load of datagrid


                            lblScopeID.Visible = false;

                            imgFunction2.Visible = false;

                            if (string.IsNullOrEmpty(lblScopeName.Text))
                            {
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;                              
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";                                    
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                lblBudgetName.Visible = false;
                                lblPlantName.Visible = false;
                            }

                        }
                        else
                        {

                            imgFunction1.Visible = false;
                            imgFunction2.Visible = true;
                            lblEOScopeID.Visible = false;
                            if (string.IsNullOrEmpty(lblScopeName.Text))
                            {
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    //if (e.Row != null)
                                    //    e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }                              
                            }

                            lblBudgetName.Visible = true;
                            lblPlantName.Visible = true;
                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgFunction1.Visible = true;
                            imgFunction2.Visible = false;
                            lblEOScopeID.Visible = false;

                            if (string.IsNullOrEmpty(lblScopeName.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                            }

                            lblBudgetName.Visible = false;
                            lblPlantName.Visible = false;
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblEOScopeID.Visible = false;
                            imgFunction2.Visible = true;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row.Cells[2] != null)
                                    e.Row.Cells[2].CssClass = "viscol";
                                //if (e.Row != null)
                                //    e.Row.CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            }  
                        }
                        else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblEOScopeID.Visible = false;
                            imgFunction2.Visible = false;
                            if (string.IsNullOrEmpty(lblScopeName.Text))
                            {
                                lblEOScopeID.Visible = false;
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;                                                              
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    //if (e.Row != null)
                                    //    e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }  
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                            }

                            lblBudgetName.Visible = true;
                            lblPlantName.Visible = true;
                        }
                        else
                        {
                            imgFunction2.Visible = false;


                            lblEOScopeID.Visible = false;

                            if (string.IsNullOrEmpty(lblScopeName.Text))
                            {
                                //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = false;
                            }

                            lblBudgetName.Visible = false;
                            lblPlantName.Visible = false;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
            }

        }


        //protected void drgdEOScopeBudget_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            //Dim imgRemoveButton As ImageButton = CType(e.Item.FindControl("ImgRemoveApprover"), ImageButton)
        //            //Dim lnkApproverName2 As LinkButton = CType(e.Item.FindControl("lnkApproverName"), LinkButton)
        //            //Dim labeltest As Label = CType(e.Item.FindControl("Label"), Label)
        //            //'imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" & lnkApproverName2.Text & "');")
        //            //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" & lnkApproverName2.Text & "','" & CheckApproverGroup(CType(e.Item.FindControl("lnkApproverName"), LinkButton).Text) & "');")
        //            if (!(ViewState["Expand") == "ExpandMode"))
        //            {
        //                //Displaying only Function names in first load of datagrid
        //                ImageButton imgFunction1 = default(ImageButton);
        //                ImageButton imgFunction2 = default(ImageButton);
        //                ImageButton imgRemoveApprover = default(ImageButton);
        //                imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
        //                imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
        //                //imgRemoveApprover = CType(e.Item.FindControl("imgRemoveApprover"), ImageButton)
        //                imgFunction2.Visible = false;
        //                //imgRemoveApprover.Visible = False
        //                Label lblScopeID = default(Label);
        //                lblScopeID = (Label)e.Item.FindControl("lblEOScopeID");
        //                lblScopeID.Visible = false;
        //                Label lblScopeName = default(Label);
        //                lblScopeName = (Label)e.Item.FindControl("lblEOScopeName");
        //                if (string.IsNullOrEmpty(lblScopeName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgFunction1.Visible = false;
        //                    imgFunction2.Visible = false;
        //                    //imgRemoveapprover.Visible = True
        //                }
        //            }
        //            else
        //            {
        //                ImageButton imgFunction1 = default(ImageButton);
        //                ImageButton imgFunction2 = default(ImageButton);
        //                ImageButton imgRemoveApprover = default(ImageButton);
        //                imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
        //                imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
        //                //imgRemoveApprover = CType(e.Item.FindControl("imgRemoveApprover"), ImageButton)
        //                imgFunction1.Visible = false;
        //                imgFunction2.Visible = true;
        //                //imgRemoveApprover.Visible = False
        //                Label lblFunctionID = default(Label);
        //                lblFunctionID = (Label)e.Item.FindControl("lblEOScopeID");
        //                lblFunctionID.Visible = false;
        //                Label lblFunctionName = default(Label);
        //                lblFunctionName = (Label)e.Item.FindControl("lblEOScopeName");
        //                if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                {
        //                    //e.Item.Visible = False
        //                    imgFunction1.Visible = false;
        //                    imgFunction2.Visible = false;
        //                    //imgRemoveApprover.Visible = True
        //                }
        //                LinkButton lnkPlantName = default(LinkButton);
        //                lnkPlantName = (LinkButton)e.Item.FindControl("lnkPlantName");
        //                lnkPlantName.Visible = true;
        //                Label lblBudgetName = default(Label);
        //                lblBudgetName = (Label)e.Item.FindControl("lblBudgetName");
        //                lblBudgetName.Visible = true;
        //            }
        //            break;
        //    }
        //}

        //protected void drgdEOScopeBudget_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //If view command event
        //    if (e.CommandName == "View_Plant")
        //    {
        //        Label lblScopeID = (Label)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lblScopeID");
        //        Label lblBudgetID = (Label)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lblBudgetID");
        //        Label lblPlantID = (Label)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lblPlantID");
        //        Label lblScopeName = (Label)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lblEOScopeName");
        //        LinkButton lnkPlantName = (LinkButton)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lnkPlantName");
        //        Label lblBudgetName = (Label)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lblBudgetName");
        //        Label lblScopeMappingID = (Label)drgdEOScopeBudget.Items(e.Item.ItemIndex).FindControl("lblScopeMappingID");
        //        //Response.Redirect("MaintainEOScopeBudget.aspx?Scope_ID=" & lblScopeID.Text & "&PlantID=" & lblPlantID.Text & "&BudgetID=" & lblBudgetID.Text & "&MapID=" & lblScopeMappingID.Text & "&ScName=" & lblScopeName.Text & "&plName=" & lnkPlantName.Text & "&bdName=" & lblBudgetName.Text) 'Redirect to view page 
        //        Response.Redirect("MaintainEOScopeBudget.aspx?Scope_ID=" + lblScopeID.Text + "&PlantID=" + lblPlantID.Text + "&BudgetID=" + lblBudgetID.Text + "&ScName=" + lblScopeName.Text + "&plName=" + lnkPlantName.Text + "&bdName=" + lblBudgetName.Text);
        //        //Redirect to view page 

        //    }
        //    //when user clicks on expand image button then application will execute below code
        //    //this code will diplay approver names
        //    //If expand
        //    if (e.CommandName == "Function1")
        //    {
        //        ImageButton imgFunction2 = default(ImageButton);
        //        imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
        //        imgFunction2.Visible = true;
        //        //Make collapse button visible

        //        ImageButton imgFunction1 = default(ImageButton);
        //        imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
        //        imgFunction1.Visible = false;
        //        //Make expand button invisible
        //        Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;
        //        for (int rowCount = rowno + 1; rowCount <= drgdEOScopeBudget.Items.Count - 1; rowCount++)
        //        {
        //            Label lblScopeName = (Label)drgdEOScopeBudget.Items(rowCount).FindControl("lblEOScopeName");
        //            LinkButton lnkPlantName = (LinkButton)drgdEOScopeBudget.Items(rowCount).FindControl("lnkPlantName");
        //            // Dim imgRemoveApprover As ImageButton = CType(drgdEOScopeBudget.Items(rowCount).FindControl("imgRemoveApprover"), ImageButton)
        //            if (string.IsNullOrEmpty(lblScopeName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lnkPlantName.Text))
        //                {
        //                    drgdEOScopeBudget.Items(rowCount).Visible = true;
        //                    lnkPlantName.Visible = true;
        //                    // imgRemoveApprover.Visible = True
        //                }
        //                else
        //                {
        //                    drgdEOScopeBudget.Items(rowCount).Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //        }
        //    }

        //    //when user clicks on collapse image button then application will execute below code
        //    // this code will diplay only function names and hiding approver names
        //    //If collapse
        //    if (e.CommandName == "Function2")
        //    {
        //        ImageButton imgFunction2 = default(ImageButton);
        //        imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
        //        imgFunction2.Visible = false;
        //        //Make collapse button invisible

        //        ImageButton imgFunction1 = default(ImageButton);
        //        imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
        //        imgFunction1.Visible = true;
        //        //Make expand button visible

        //        //Dim imgRemoveApprover As ImageButton
        //        // imgRemoveApprover = CType(e.Item.FindControl("imgRemoveApprover"), ImageButton)
        //        // imgRemoveApprover.Visible = False
        //        // Page.RegisterStartupScript("clientscript", "document.getElementById('" & imgFunction1.ClientID & "').focus();")

        //        int rowno = e.Item.ItemIndex;
        //        for (int rowCount = rowno + 1; rowCount <= drgdEOScopeBudget.Items.Count - 1; rowCount++)
        //        {
        //            Label lblScopeName = (Label)drgdEOScopeBudget.Items(rowCount).FindControl("lblEOScopeName");
        //            LinkButton lnkPlantName = (LinkButton)drgdEOScopeBudget.Items(rowCount).FindControl("lnkPlantName");
        //            if (string.IsNullOrEmpty(lblScopeName.Text))
        //            {
        //                drgdEOScopeBudget.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //        }
        //    }
        //}

        protected void imgExpand_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            FillEOScopeByBudgetCenter();
            //Call the function to fill the function/approver details
        }

        protected void imgCollapse_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillEOScopeByBudgetCenter();
            //Call the function to fill the function/approver details
        }

        protected void imgCreateApprover_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyEOScopeBudget.aspx?Mode=New");
        }

    }
}