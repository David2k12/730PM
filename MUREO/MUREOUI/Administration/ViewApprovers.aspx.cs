using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Collections;
using System.Data.SqlClient;
using MUREOUI.Common;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Administration
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region "Variable Declaration"
        #endregion
        string script;
        clsSecurity cls = new clsSecurity();
        #region "Page_Events"
        //Sub 	        :   Page load event
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Loads form related info on page load
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                //ViewState["Expand"] = "CollapseMode";
                ViewState["FunctionMain"] = "True";
                FillEOApproversByFunction();
                ViewState["FunctionMain"] = null;
            }
        }
        #endregion
        #region "User_Defined_Functions"
        //Sub 	        :   FillEOApproversByFunction
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Displays approver details grouped by function in tree view format
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        private void FillEOApproversByFunction()
        {
            DataSet dsApproversByCategory = new DataSet();
            Approver app = new Approver();
            if (app.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0, ref dsApproversByCategory))
            {
                //Retrieve all approver related info from the db
                //If dataset is null, quit
                if (dsApproversByCategory == null)
                {
                    //If no data, quit
                }
                else if (dsApproversByCategory.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    DataTable dtAppbyFunction = new DataTable();
                    //Create a new datatable to store function and approver details
                    DataRow drAppbyFunction = null;
                    dtAppbyFunction.Columns.Add("Function_ID");
                    //Create the needed columns for tree view display
                    dtAppbyFunction.Columns.Add("Function_Name");
                    dtAppbyFunction.Columns.Add("Approver_Name");
                    dtAppbyFunction.Columns.Add("Plant_Name");
                    dtAppbyFunction.Columns.Add("Approver_ID");
                    dtAppbyFunction.Columns.Add("Plant_ID");

                    //Below code for splitting data for treeview display and binding splitted data into temperory table
                    ArrayList arrayFunctionName = new ArrayList();
                    ArrayList arrayFunctionID = new ArrayList();

                    //First row item of function name
                    string strFunctionName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[0][1]);
                    //Function Name
                    string strFunctionID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[0][0]);
                    //Function ID

                    //Adding function name to array
                    arrayFunctionName.Add(strFunctionName);
                    arrayFunctionID.Add(strFunctionID);

                    //Adding all function names(Without repitition)
                    for (int rowCount = 0; rowCount <= dsApproversByCategory.Tables[0].Rows.Count - 1; rowCount++)
                    {
                        string strFunctionName1 = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowCount][1]);
                        string strFunctionID1 = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowCount][0]);
                        //If function name not already in the list, add it now
                        if (!(arrayFunctionName.Contains(strFunctionName1)))
                        {
                            arrayFunctionName.Add(strFunctionName1);
                            arrayFunctionID.Add(strFunctionID1);
                        }
                    }
                    //Based on function name storing function id and function name in to temperory table
                    for (int rowFunctionNameCount = 0; rowFunctionNameCount <= arrayFunctionName.Count - 1; rowFunctionNameCount++)
                    {
                        drAppbyFunction = dtAppbyFunction.NewRow();
                        //Store function name and id
                        drAppbyFunction["Function_ID"] = arrayFunctionID[rowFunctionNameCount];
                        drAppbyFunction["Function_Name"] = arrayFunctionName[rowFunctionNameCount];
                        drAppbyFunction["Approver_Name"] = "";
                        drAppbyFunction["Plant_Name"] = "";
                        dtAppbyFunction.Rows.Add(drAppbyFunction);

                        ArrayList arrayApproverName = new ArrayList();
                        ArrayList arrayApproverID = new ArrayList();
                        ArrayList arrayPlantID = new ArrayList();
                        ArrayList arrayPlantName = new ArrayList();
                        //Adding approver names(Without repitition) based on function name
                        for (int rowApproverCount = 0; rowApproverCount <= dsApproversByCategory.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {
                            if (arrayFunctionName[rowFunctionNameCount].ToString().Trim().ToUpper() == Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_Name"]).Trim().ToUpper())
                            {
                                string strPlantName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Plant_Name"]);
                                string strApproverName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Approver_Name"]);
                                string ApproverID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Approver_ID"]);
                                string PlantID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
                                arrayApproverName.Add(strApproverName);
                                arrayPlantName.Add(strPlantName);
                                arrayApproverID.Add(Convert.ToInt32(ApproverID));
                                arrayPlantID.Add(Convert.ToInt32(PlantID));
                            }
                        }
                        ArrayList arrayApproverID1 = new ArrayList();
                        ArrayList arrayPlantID1 = new ArrayList();
                        ArrayList arrayFunctionID1 = new ArrayList();
                        ArrayList arrayFunctionName1 = new ArrayList();
                        for (int rowApproverCount = 0; rowApproverCount <= dsApproversByCategory.Tables[0].Rows.Count - 1; rowApproverCount++)
                        {
                            if (arrayFunctionName[rowFunctionNameCount].ToString().Trim().ToUpper() == Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_Name"]).Trim().ToUpper())
                            {
                                string strApproverID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Approver_ID"]);
                                string strPlantID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
                                string strFuncID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_ID"]);
                                string strFuncName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_Name"]);
                                if (arrayApproverID1.Count == 0)
                                {
                                    arrayApproverID1.Add(strApproverID);
                                    arrayPlantID1.Add(strPlantID);
                                    arrayFunctionID1.Add(strFuncID);
                                    arrayFunctionName1.Add(strFuncName);
                                }
                                if (!(arrayApproverID1.Contains(strApproverID)))
                                {
                                    arrayApproverID1.Add(strApproverID);
                                    arrayPlantID1.Add(strPlantID);
                                    arrayFunctionID1.Add(strFuncID);
                                    arrayFunctionName1.Add(strFuncName);
                                }
                            }
                        }
                        bool funct_add = false;
                        string funct_id = null;
                        int addCount = 0;
                        //Based on Function name storing Function ID, Approver name,Approver id,Plant name,Plant Id into temperory table
                        for (int rowApproverCount1 = 0; rowApproverCount1 <= arrayApproverName.Count - 1; rowApproverCount1++)
                        {
                            drAppbyFunction = dtAppbyFunction.NewRow();
                            //drAppbyFunction("Function_ID") = dsApproversByCategory.Tables(0).Rows(rowApproverCount1)("Function_ID")
                            drAppbyFunction["Function_ID"] = arrayFunctionID1[rowApproverCount1];
                            drAppbyFunction["Function_Name"] = "";
                            drAppbyFunction["Approver_Name"] = arrayApproverName[rowApproverCount1];
                            drAppbyFunction["Plant_Name"] = arrayPlantName[rowApproverCount1];
                            drAppbyFunction["Approver_ID"] = arrayApproverID1[rowApproverCount1];
                            drAppbyFunction["Plant_ID"] = arrayPlantID1[rowApproverCount1];
                            dtAppbyFunction.Rows.Add(drAppbyFunction);
                        }
                    }
                    int i = 0;
                    for (i = 0; i <= dtAppbyFunction.Rows.Count - 1; i++)
                    {
                        if (dtAppbyFunction.Rows[i]["Function_Name"] == "QA")
                        {
                            dtAppbyFunction.Rows[i]["Function_Name"] = "Site QA";
                        }
                    }
                    //if (ViewState["FunctionID"] != null)
                    //{
                    //    DataView functionmain =dtAppbyFunction.DefaultView;
                    //    functionmain.RowFilter = "Function_ID=" + Convert.ToInt32(ViewState["FunctionID"]);
                    //    int temp = 0;
                    //    ViewState["SingleMain"] = "0";
                    //    string sttemp=string.Empty;
                    //    foreach (DataRow dr in functionmain.ToTable().Rows)
                    //    {

                    //        if (string.IsNullOrEmpty(Convert.ToString(dr["Function_Name"])))
                    //        {
                    //            sttemp =sttemp +Convert.ToString(temp)+",";
                    //        }
                    //        temp++;
                    //    }
                    //    ViewState["Single"] = sttemp.TrimEnd(new char[] { ',' });
                    //    drgdAppGrp.DataSource = functionmain;
                    //    drgdAppGrp.DataBind();
                    //    functionmain.Dispose();
                    //}
                    //else if (ViewState["FunctionMain"] != null)
                    //{
                    Session["DataTable"] = dtAppbyFunction;
                    DataTable functionmain = dtAppbyFunction.DefaultView.ToTable(true, "Function_ID", "Function_Name");
                    functionmain.Columns.Add("Approver_Name");
                    functionmain.Columns.Add("Plant_Name");
                    functionmain.Columns.Add("Approver_ID");
                    functionmain.Columns.Add("Plant_ID");
                    functionmain.AcceptChanges();
                    drgdAppGrp.DataSource = functionmain;
                    drgdAppGrp.DataBind();
                    functionmain.Dispose();
                    //}
                    ////else
                    ////{
                    //drgdAppGrp.DataSource = dtAppbyFunction;
                    //drgdAppGrp.DataBind();
                    ////}
                }
            }
        }


        //protected void FillEOApproversByFunction()
        //{
        //    DataSet dsApproversByCategory = null;
        //    Approver app = new Approver();
        //    if (app.FillEOApproversByFunctionBO(Convert.DBNull.ToString(), 0, 0, ref dsApproversByCategory))
        //    {
        //        //Retrieve all approver related info from the db
        //        //If dataset is null, quit
        //        if (dsApproversByCategory == null)
        //        {
        //            //If no data, quit
        //        }
        //        else if (dsApproversByCategory.Tables[0].Rows.Count == 0)
        //        {
        //            NoRecords();
        //        }
        //        else
        //        {
        //            DataTable dtAppbyFunction = new DataTable();
        //            //Create a new datatable to store function and approver details
        //            DataRow drAppbyFunction = null;
        //            dtAppbyFunction.Columns.Add("Function_ID");
        //            //Create the needed columns for tree view display
        //            dtAppbyFunction.Columns.Add("Function_Name");
        //            dtAppbyFunction.Columns.Add("Approver_Name");
        //            dtAppbyFunction.Columns.Add("Plant_Name");
        //            dtAppbyFunction.Columns.Add("Approver_ID");
        //            dtAppbyFunction.Columns.Add("Plant_ID");

        //            //Below code for splitting data for treeview display and binding splitted data into temperory table
        //            ArrayList arrayFunctionName = new ArrayList();
        //            ArrayList arrayFunctionID = new ArrayList();

        //            //First row item of function name
        //            string strFunctionName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[0][1]);
        //            //Function Name
        //            string strFunctionID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[0][0]);
        //            //Function ID

        //            //Adding function name to array
        //            arrayFunctionName.Add(strFunctionName);
        //            arrayFunctionID.Add(strFunctionID);

        //            //Adding all function names(Without repitition)
        //            for (int rowCount = 0; rowCount <= dsApproversByCategory.Tables[0].Rows.Count - 1; rowCount++)
        //            {
        //                string strFunctionName1 = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowCount][1]);
        //                string strFunctionID1 = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowCount][0]);
        //                //If function name not already in the list, add it now
        //                if (!(arrayFunctionName.Contains(strFunctionName1)))
        //                {
        //                    arrayFunctionName.Add(strFunctionName1);
        //                    arrayFunctionID.Add(strFunctionID1);
        //                }
        //            }
        //            //Based on function name storing function id and function name in to temperory table
        //            for (int rowFunctionNameCount = 0; rowFunctionNameCount <= arrayFunctionName.Count - 1; rowFunctionNameCount++)
        //            {
        //                drAppbyFunction = dtAppbyFunction.NewRow();
        //                //Store function name and id
        //                drAppbyFunction["Function_ID"] = arrayFunctionID[rowFunctionNameCount];
        //                drAppbyFunction["Function_Name"] = arrayFunctionName[rowFunctionNameCount];
        //                drAppbyFunction["Approver_Name"] = "";
        //                drAppbyFunction["Plant_Name"] = "";
        //                dtAppbyFunction.Rows.Add(drAppbyFunction);

        //                ArrayList arrayApproverName = new ArrayList();
        //                ArrayList arrayApproverID = new ArrayList();
        //                ArrayList arrayPlantID = new ArrayList();
        //                ArrayList arrayPlantName = new ArrayList();
        //                //Adding approver names(Without repitition) based on function name
        //                for (int rowApproverCount = 0; rowApproverCount <= dsApproversByCategory.Tables[0].Rows.Count - 1; rowApproverCount++)
        //                {
        //                    if (arrayFunctionName[rowFunctionNameCount] == dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_Name"])
        //                    {
        //                        string strPlantName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Plant_Name"]);
        //                        string strApproverName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Approver_Name"]);
        //                        string ApproverID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Approver_ID"]);
        //                        string PlantID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
        //                        arrayApproverName.Add(strApproverName);
        //                        arrayPlantName.Add(strPlantName);
        //                        arrayApproverID.Add(Convert.ToInt32(ApproverID));
        //                        arrayPlantID.Add(Convert.ToInt32(PlantID));
        //                    }
        //                }
        //                ArrayList arrayApproverID1 = new ArrayList();
        //                ArrayList arrayPlantID1 = new ArrayList();
        //                ArrayList arrayFunctionID1 = new ArrayList();
        //                ArrayList arrayFunctionName1 = new ArrayList();
        //                for (int rowApproverCount = 0; rowApproverCount <= dsApproversByCategory.Tables[0].Rows.Count - 1; rowApproverCount++)
        //                {
        //                    if (arrayFunctionName[rowFunctionNameCount] == dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_Name"])
        //                    {
        //                        string strApproverID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Approver_ID"]);
        //                        string strPlantID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Plant_ID"]);
        //                        string strFuncID = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_ID"]);
        //                        string strFuncName = Convert.ToString(dsApproversByCategory.Tables[0].Rows[rowApproverCount]["Function_Name"]);
        //                        if (arrayApproverID1.Count == 0)
        //                        {
        //                            arrayApproverID1.Add(strApproverID);
        //                            arrayPlantID1.Add(strPlantID);
        //                            arrayFunctionID1.Add(strFuncID);
        //                            arrayFunctionName1.Add(strFuncName);
        //                        }
        //                        if (!(arrayApproverID1.Contains(strApproverID)))
        //                        {
        //                            arrayApproverID1.Add(strApproverID);
        //                            arrayPlantID1.Add(strPlantID);
        //                            arrayFunctionID1.Add(strFuncID);
        //                            arrayFunctionName1.Add(strFuncName);
        //                        }
        //                    }
        //                }
        //                bool funct_add = false;
        //                string funct_id = null;
        //                int addCount = 0;
        //                //Based on Function name storing Function ID, Approver name,Approver id,Plant name,Plant Id into temperory table
        //                for (int rowApproverCount1 = 0; rowApproverCount1 <= arrayApproverName.Count - 1; rowApproverCount1++)
        //                {
        //                    drAppbyFunction = dtAppbyFunction.NewRow();
        //                    //drAppbyFunction("Function_ID") = dsApproversByCategory.Tables(0).Rows(rowApproverCount1)("Function_ID")
        //                    drAppbyFunction["Function_ID"] = arrayFunctionID1[rowApproverCount1];
        //                    drAppbyFunction["Function_Name"] = "";
        //                    drAppbyFunction["Approver_Name"] = arrayApproverName[rowApproverCount1];
        //                    drAppbyFunction["Plant_Name"] = arrayPlantName[rowApproverCount1];
        //                    drAppbyFunction["Approver_ID"] = arrayApproverID1[rowApproverCount1];
        //                    drAppbyFunction["Plant_ID"] = arrayPlantID1[rowApproverCount1];
        //                    dtAppbyFunction.Rows.Add(drAppbyFunction);
        //                }
        //            }
        //            int i = 0;
        //            for (i = 0; i <= dtAppbyFunction.Rows.Count - 1; i++)
        //            {
        //                if (Convert.ToString(dtAppbyFunction.Rows[i]["Function_Name"]) == "QA")
        //                {
        //                    dtAppbyFunction.Rows[i]["Function_Name"] = "Site QA";
        //                }
        //            }
        //            //dtAppbyFunction.AcceptChanges();
        //            drgdAppGrp.DataSource = dtAppbyFunction;
        //            drgdAppGrp.DataBind();
        //        }
        //    }
        //}
        //Sub 	        :   deleteApprover
        //Written BY	    :	Vijay
        //parameters     :	Approver id
        //Purpose	    :   Delete specified approver from the db
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void deleteApprover(int ApproverID)
        {
            int Result = -1;
            Approver app = new Approver();
            SqlParameter[] paramout = new SqlParameter[1];

            if (app.InsertEOApproverBO(ApproverID, "", 0, 0, cls.getUserFullName(cls.UserName), 'I', ref paramout))
            {
                Result = Convert.ToInt32(paramout[0].Value);
            }
            this.InsertOperationMessage(Result);
        }
        //Sub 	        :   InsertOperationMessage
        //Written BY	    :	Vijay
        //parameters     :	Approver id
        //Purpose	    :   Display delete success/failure message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void InsertOperationMessage(int deleteResult)
        {
            if (deleteResult == 0)
            {
                script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');";
                FillEOApproversByFunction();
            }
            else
            {
                script = "alert('" + ConfigurationManager.AppSettings["DeleteError"] + "'); ";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        //Sub 	        :   NoRecords
        //Written BY	    :	Vijay
        //parameters     :	Approver id
        //Purpose	    :   Display customized error message to the user
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void NoRecords()
        {
            script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected bool CheckApproverGroup(string Approver_Name)
        {
            DataSet dsApprovers = null;
            Approver app = new Approver();
            if (app.FillEOApprovalGroupDetailsBO(0, ref dsApprovers))
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
                else if (dsApprovers.Tables[0].Rows.Count > 0)
                {
                    for (int rowCt = 0; rowCt <= dsApprovers.Tables[0].Rows.Count - 1; rowCt++)
                    {
                        if (Convert.ToString(dsApprovers.Tables[0].Rows[rowCt]["Approver_Name"]) == Approver_Name)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        protected void drgdAppGrp_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillEOApproversByFunction();
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgFunction1_Command(object sender, CommandEventArgs e)
        {
            //ViewState["FunctionID"] = Convert.ToString(e.CommandName);
            ViewState["Expand"] = null;
            DevExpress.Web.ASPxEditors.ASPxButton imgfun1 = (DevExpress.Web.ASPxEditors.ASPxButton)sender;
            DevExpress.Web.ASPxEditors.ASPxButton imgFunction2 = (DevExpress.Web.ASPxEditors.ASPxButton)imgfun1.Parent.FindControl("imgFunction2");
            //imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
            imgFunction2.Visible = true;
            //Make collapse button visible            
            imgfun1.Visible = false;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgfun1.Parent;
            int rowno = gvd.ItemIndex;
            ASPxGridView drgdAppNames = (ASPxGridView)drgdAppGrp.FindRowCellTemplateControl(rowno, (GridViewDataColumn)drgdAppGrp.Columns[1], "drgdAppNames");
            drgdAppNames.Visible = true;
            DataTable dt = (DataTable)Session["DataTable"];
            DataView functionmain = dt.DefaultView;
            functionmain.RowFilter = "Function_ID IN (" + Convert.ToInt32(Convert.ToString(e.CommandName)) + ")";
            drgdAppNames.DataSource = functionmain;
            drgdAppNames.DataBind();
            //int temp = 0;
            //ViewState["SingleMain"] = "0";
            //string sttemp = string.Empty;
            //foreach (DataRow dr in functionmain.ToTable().Rows)
            //{

            //    if (string.IsNullOrEmpty(Convert.ToString(dr["Function_Name"])))
            //    {
            //        sttemp = sttemp + Convert.ToString(temp) + ",";
            //    }
            //    temp++;
            //}
            //ViewState["Single"] = sttemp.TrimEnd(new char[] { ',' });
            //drgdAppGrp.DataSource = functionmain;
            //drgdAppGrp.DataBind();
            //functionmain.Dispose();
            //ViewState["Expand"] = null;
            //ViewState["FunctionID"] = Convert.ToString(e.CommandName);
            ////FillEOApproversByFunction();
            //ImageButton imgfun1 = (ImageButton)sender;
            //ImageButton imgFunction2 = (ImageButton)imgfun1.Parent.FindControl("imgFunction2");
            ////imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
            //imgFunction2.Visible = true;
            ////Make collapse button visible            
            //imgfun1.Visible = false;
            //string st = string.Empty;
            ////Make expand button invisible
            //// ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");
            //GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgfun1.Parent;
            //int rowno = gvd.ItemIndex;
            //ViewState["SingleMain"] = Convert.ToString(rowno);
            //for (int rowCount = rowno + 1; rowCount <= drgdAppGrp.VisibleRowCount - 1; rowCount++)
            //{
            //    Label lblFunctionName = (Label)drgdAppGrp.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdAppGrp.Columns["Function Name"], "lblFunctionName");
            //    LinkButton lnkApproverName = (LinkButton)drgdAppGrp.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdAppGrp.Columns["Approver Name"], "lnkApproverName");
            //    ImageButton imgRemoveApprover = (ImageButton)drgdAppGrp.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdAppGrp.Columns["Delete Approver"], "imgRemoveApprover");
            //    if (lblFunctionName != null)
            //    {
            //        if (string.IsNullOrEmpty(lblFunctionName.Text))
            //        {


            //            if (!string.IsNullOrEmpty(lnkApproverName.Text))
            //            {
            //                st = st + Convert.ToString(rowCount) + ",";
            //                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
            //                gvdc.Visible = true;
            //                lnkApproverName.Visible = true;
            //                imgRemoveApprover.Visible = true;
            //            }
            //            else
            //            {
            //                //drgdAppGrp.Items[rowCount].Visible = false;
            //                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
            //                gvdc.Visible = false;

            //            }
            //        }
            //        else
            //        {

            //            break;
            //        }
            //    }
            //}
            //ViewState["Single"] = st.TrimEnd(new char[] { ',' });
            //FillEOApproversByFunction();      
        }

        protected void imgFunction2_Command(object sender, CommandEventArgs e)
        {
            //ViewState["Expand"] = null;
            //if (e.CommandName == "Function2")
            //    {
            //        ImageButton imgFunction2 = default(ImageButton);
            //        imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
            //        imgFunction2.Visible = false;
            //        //Make collapse button invisible

            //        ImageButton imgFunction1 = default(ImageButton);
            //        imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
            //        imgFunction1.Visible = true;
            //        //Make expand button visible

            //        ImageButton imgRemoveApprover = default(ImageButton);
            //        imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
            //        imgRemoveApprover.Visible = false;
            //        ClientScript.RegisterStartupScript(this.GetType(),"clientscript", "document.getElementById('" + imgFunction1.ClientID + "').focus();");

            //        int rowno = e.Item.ItemIndex;
            //        for (int rowCount = rowno + 1; rowCount <= drgdAppGrp.Items.Count - 1; rowCount++)
            //        {
            //            Label lblFunctionName = (Label)drgdAppGrp.Items(rowCount).FindControl("lblFunctionName");
            //            LinkButton lnkApproverName = (LinkButton)drgdAppGrp.Items(rowCount).FindControl("lnkApproverName");
            //            if (string.IsNullOrEmpty(lblFunctionName.Text))
            //            {
            //                drgdAppGrp.Items(rowCount).Visible = false;
            //            }
            //            else
            //            {
            //                break; // TODO: might not be correct. Was : Exit For
            //            }
            //        }
            //    }



            DevExpress.Web.ASPxEditors.ASPxButton imgFunction2 = (DevExpress.Web.ASPxEditors.ASPxButton)sender;
            imgFunction2.Visible = false;
            //Make collapse button invisible
            DevExpress.Web.ASPxEditors.ASPxButton imgFunction1 = (DevExpress.Web.ASPxEditors.ASPxButton)imgFunction2.Parent.FindControl("imgFunction1");
            imgFunction1.Visible = true;
            //Make expand button visible
            //GridViewTableDataRow gvdd = (GridViewTableDataRow)imgFunction2.Parent.Parent.Parent;
            GridViewDataItemTemplateContainer gvd = (GridViewDataItemTemplateContainer)imgFunction2.Parent;
            int rowno = gvd.ItemIndex;
            ASPxGridView drgdAppNames = (ASPxGridView)drgdAppGrp.FindRowCellTemplateControl(rowno, (GridViewDataColumn)drgdAppGrp.Columns[1], "drgdAppNames");
            drgdAppNames.Visible = false;
            //ImageButton imgRemoveApprover = (ImageButton)drgdAppGrp.FindRowCellTemplateControl(rowno, (GridViewDataColumn)drgdAppGrp.Columns["Delete Approver"], "ImgRemoveApprover");
            //imgRemoveApprover.Visible = false;
            //ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('" + imgFunction1.ClientID + "').focus();");


            //for (int rowCount = rowno + 1; rowCount <= drgdAppGrp.VisibleRowCount - 1; rowCount++)
            //{
            //    ViewState["Single"] = null;
            //    ViewState["SingleMain"] = null;

            //    Label lblFunctionName = (Label)drgdAppGrp.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdAppGrp.Columns["Function Name"], "lblFunctionName");
            //    LinkButton lnkApproverName = (LinkButton)drgdAppGrp.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)drgdAppGrp.Columns["Approver Name"], "lnkApproverName");
            //    if (lblFunctionName != null)
            //    {
            //        if (string.IsNullOrEmpty(lblFunctionName.Text))
            //        {

            //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
            //            gvdc.Visible = false;
            //            lnkApproverName.Visible = true;
            //            imgRemoveApprover.Visible = true;
            //        }
            //        else
            //        {
            //            break; // TODO: might not be correct. Was : Exit For
            //        }
            //    }
            //}
        }
        protected void lnkApproverName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                LinkButton lkb = (LinkButton)sender;
                Label lblFunctionID = (Label)lkb.Parent.FindControl("lblFunctID");
                Label lblApproverID = (Label)lkb.Parent.FindControl("lblApprvrID");
                Label lblPlantID = (Label)lkb.Parent.FindControl("lblPlantID");
                Label lblFunctName = (Label)lkb.Parent.FindControl("lblFunctName");
                Response.Redirect("ViewApprvr.aspx?Funct_ID=" + lblFunctionID.Text + "&Apprv_ID=" + lblApproverID.Text + "&Plant_ID=" + lblPlantID.Text);
            }
            catch (Exception exc)
            {

            }
        }
        protected void RemoveApprover_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (hdnresponse.Value == "Y")
                {
                    //ViewState["Expand"] = null;
                    //ViewState["Single"] = null;
                    //ViewState["SingleMain"] = null;
                    deleteApprover(Convert.ToInt32(e.CommandArgument));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void drgdAppGrp_OnHtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {

                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    DevExpress.Web.ASPxEditors.ASPxButton imgFunction1 = (DevExpress.Web.ASPxEditors.ASPxButton)drgdAppGrp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdAppGrp.Columns["Function Name"], "imgFunction1");
                    DevExpress.Web.ASPxEditors.ASPxButton imgFunction2 = (DevExpress.Web.ASPxEditors.ASPxButton)drgdAppGrp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdAppGrp.Columns["Function Name"], "imgFunction2");

                   // DevExpress.Web.ASPxEditors.ASPxLabel lblFunctionName = (DevExpress.Web.ASPxEditors.ASPxLabel)drgdAppGrp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdAppGrp.Columns["Function Name"], "lblFunctionName");
                    
                    if (imgFunction1.Text == string.Empty)
                    {
                        if (e.Row.Cells.Count > 1)
                        {
                            if (e.Row.Cells[0] != null)
                                e.Row.Cells[0].CssClass = "hiddencol";
                            if (e.Row.Cells[1] != null)
                                e.Row.Cells[1].CssClass = "hiddencol";
                            if (e.Row.Cells[2] != null)
                                e.Row.Cells[2].CssClass = "hiddencol";
                            if (e.Row.Cells[3] != null)
                                e.Row.Cells[3].CssClass = "hiddencol";
                            if (e.Row != null)
                                e.Row.CssClass = "hiddencol";
                        }
                        else
                        {
                            if (e.Row.Cells[0] != null)
                                e.Row.Cells[0].CssClass = "hiddencol";
                        }

                    }
                    else
                    {
                        
                        if (ViewState["Expand"] != null)
                        {
                            if ((ViewState["Expand"].ToString() == "ExpandMode"))
                            {
                                imgFunction1.Visible = false;
                                imgFunction2.Visible = true;
                                ASPxGridView drgdAppNames = (ASPxGridView)drgdAppGrp.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)drgdAppGrp.Columns[1], "drgdAppNames");
                                drgdAppNames.Visible = true;
                                DataTable dt = (DataTable)Session["DataTable"];
                                DataView functionmain = dt.DefaultView;
                                functionmain.RowFilter = "Function_ID IN (" + Convert.ToInt32(Convert.ToString(imgFunction1.Attributes["functionID"])) + ")";
                                drgdAppNames.DataSource = functionmain;
                                drgdAppNames.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void drgdAppNames_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
                    LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
                    if (lnkApproverName2.Text == string.Empty)
                    {
                        if (e.Row.Cells.Count > 1)
                        {
                            if (e.Row.Cells[0] != null)
                                e.Row.Cells[0].CssClass = "hiddencol";
                            if (e.Row.Cells[1] != null)
                                e.Row.Cells[1].CssClass = "hiddencol";
                            if (e.Row.Cells[2] != null)
                                e.Row.Cells[2].CssClass = "hiddencol";
                            if (e.Row.Cells[3] != null)
                                e.Row.Cells[3].CssClass = "hiddencol";
                            if (e.Row != null)
                                e.Row.CssClass = "hiddencol";
                        }
                        else
                        {
                            if (e.Row.Cells[0] != null)
                                e.Row.Cells[0].CssClass = "hiddencol";
                        }
                    }
                    imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
                }
            }
            catch (Exception ex)
            {
                //objErrorLog.SaveErrorLog(strModule + "gvRecords_HtmlRowCreated", "Error", ex.Message, "gvRecords_HtmlRowCreated", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }

        //protected void drgdAppGrp_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        //{
        //    try
        //    {
        //        ASPxGridView gvDetailGridView = (ASPxGridView)sender;
        //        if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
        //        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        //        {
        //            ImageButton imgRemoveButton = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Approver"], "ImgRemoveApprover");
        //            LinkButton lnkApproverName2 = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
        //            imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(lnkApproverName2.Text) + "');");
        //            ImageButton imgFunction1 = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Function Name"], "imgFunction1");
        //            ImageButton imgFunction2 = (ImageButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Function Name"], "imgFunction2");
        //            Label lblFunctionID = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Function Name"], "lblFunctionID");
        //            Label lblFunctionName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Function Name"], "lblFunctionName");

        //            // ImageButton imgFunction1 = (ImageButton)imgRemoveButton.Parent.FindControl("imgFunction1");
        //            // ImageButton imgFunction2 = (ImageButton)imgRemoveButton.Parent.FindControl("imgFunction2");
        //            //Label lblFunctionID = (Label)imgRemoveButton.Parent.FindControl("lblFunctionID");
        //            //Label lblFunctionName = (Label)imgRemoveButton.Parent.FindControl("lblFunctionName");
        //            if (ViewState["Expand"] != null)
        //            {
        //                if (!(ViewState["Expand"] == "ExpandMode"))
        //                {
        //                    //Displaying only Function names in first load of datagrid


        //                    imgFunction2.Visible = false;
        //                    imgRemoveButton.Visible = false;

        //                    lblFunctionID.Visible = false;

        //                    if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                    {
        //                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
        //                        gvdc.Visible = false;
        //                        if (e.Row.Cells.Count > 1)
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "hiddencol";
        //                            if (e.Row.Cells[1] != null)
        //                                e.Row.Cells[1].CssClass = "hiddencol";
        //                            if (e.Row.Cells[2] != null)
        //                                e.Row.Cells[2].CssClass = "hiddencol";
        //                            if (e.Row.Cells[3] != null)
        //                                e.Row.Cells[3].CssClass = "hiddencol";
        //                            if (e.Row != null)
        //                                e.Row.CssClass = "hiddencol";
        //                        }
        //                        else
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "hiddencol";
        //                        }
        //                        imgFunction1.Visible = false;
        //                        imgFunction2.Visible = false;
        //                        imgRemoveButton.Visible = false;
        //                        LinkButton lnkApproverName = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
        //                        lnkApproverName.Visible = false;
        //                        Label lblPlantName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Plant Name"], "lblPlantName");
        //                        lblPlantName.Visible = false;
        //                    }

        //                }
        //                else
        //                {

        //                    imgFunction1.Visible = false;
        //                    imgFunction2.Visible = true;
        //                    imgRemoveButton.Visible = false;
        //                    lblFunctionID.Visible = false;
        //                    if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                    {
        //                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
        //                        gvdc.Visible = true;
        //                        if (e.Row.Cells.Count > 1)
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "viscol";
        //                            if (e.Row.Cells[1] != null)
        //                                e.Row.Cells[1].CssClass = "viscol";
        //                            if (e.Row.Cells[2] != null)
        //                                e.Row.Cells[2].CssClass = "viscol";
        //                            if (e.Row.Cells[3] != null)
        //                                e.Row.Cells[3].CssClass = "viscol";
        //                            //if (e.Row != null)
        //                            //    e.Row.CssClass = "viscol";
        //                        }
        //                        else
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "viscol";
        //                        }
        //                        imgFunction1.Visible = false;
        //                        imgFunction2.Visible = false;
        //                        imgRemoveButton.Visible = true;
        //                    }
        //                    LinkButton lnkApproverName = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
        //                    lnkApproverName.Visible = true;
        //                    Label lblPlantName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Plant Name"], "lblPlantName");
        //                    lblPlantName.Visible = true;

        //                }
        //            }
        //            else
        //            {
        //                if (ViewState["Single"] == null)
        //                {
        //                    imgFunction1.Visible = true;
        //                    imgFunction2.Visible = false;
        //                    imgRemoveButton.Visible = false;

        //                    lblFunctionID.Visible = false;

        //                    if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                    {
        //                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
        //                        gvdc.Visible = false;
        //                        if (e.Row.Cells.Count > 1)
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "hiddencol";
        //                            if (e.Row.Cells[1] != null)
        //                                e.Row.Cells[1].CssClass = "hiddencol";
        //                            if (e.Row.Cells[2] != null)
        //                                e.Row.Cells[2].CssClass = "hiddencol";
        //                            if (e.Row.Cells[3] != null)
        //                                e.Row.Cells[3].CssClass = "hiddencol";
        //                            if (e.Row != null)
        //                                e.Row.CssClass = "hiddencol";
        //                        }
        //                        else
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "hiddencol";
        //                        }
        //                        imgFunction1.Visible = false;
        //                        imgFunction2.Visible = false;
        //                        imgRemoveButton.Visible = false;
        //                    }
        //                    LinkButton lnkApproverName = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
        //                    lnkApproverName.Visible = false;
        //                    Label lblPlantName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Plant Name"], "lblPlantName");
        //                    lblPlantName.Visible = false;
        //                }
        //                else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
        //                {
        //                    lblFunctionID.Visible = false;
        //                    imgFunction2.Visible = true;
        //                    imgFunction1.Visible = false;
        //                    imgRemoveButton.Visible = false;
        //                    if (e.Row.Cells.Count > 1)
        //                    {
        //                        if (e.Row.Cells[0] != null)
        //                            e.Row.Cells[0].CssClass = "viscol";
        //                        if (e.Row.Cells[1] != null)
        //                            e.Row.Cells[1].CssClass = "viscol";
        //                        if (e.Row.Cells[2] != null)
        //                            e.Row.Cells[2].CssClass = "viscol";
        //                        if (e.Row.Cells[3] != null)
        //                            e.Row.Cells[3].CssClass = "viscol";
        //                        //if (e.Row != null)
        //                        //    e.Row.CssClass = "viscol";
        //                    }
        //                    else
        //                    {
        //                        if (e.Row.Cells[0] != null)
        //                            e.Row.Cells[0].CssClass = "viscol";
        //                    }
        //                }
        //                else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
        //                {
        //                    lblFunctionID.Visible = false;
        //                    imgFunction2.Visible = false;
        //                    imgRemoveButton.Visible = true;
        //                    lblFunctionID.Visible = false;
        //                    if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                    {
        //                        lblFunctionID.Visible = false;
        //                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;
        //                        gvdc.Visible = true;
        //                        if (e.Row.Cells.Count > 1)
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "viscol";
        //                            if (e.Row.Cells[1] != null)
        //                                e.Row.Cells[1].CssClass = "viscol";
        //                            if (e.Row.Cells[2] != null)
        //                                e.Row.Cells[2].CssClass = "viscol";
        //                            if (e.Row.Cells[3] != null)
        //                                e.Row.Cells[3].CssClass = "viscol";
        //                            //if (e.Row != null)
        //                            //    e.Row.CssClass = "viscol";
        //                        }
        //                        else
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "viscol";
        //                        }
        //                        imgFunction1.Visible = false;
        //                        imgFunction2.Visible = false;
        //                    }
        //                    LinkButton lnkApproverName = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
        //                    lnkApproverName.Visible = true;
        //                    Label lblPlantName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Plant Name"], "lblPlantName");
        //                    lblPlantName.Visible = true;
        //                }
        //                else
        //                {
        //                    LinkButton lnkApproverName = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Approver Name"], "lnkApproverName");
        //                    Label lblPlantName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Plant Name"], "lblPlantName");
        //                    imgFunction2.Visible = false;
        //                    imgRemoveButton.Visible = false;
        //                    imgFunction1.Visible = true;
        //                    lblFunctionID.Visible = false;
        //                    if (!string.IsNullOrEmpty(lblFunctionName.Text))
        //                    {
        //                        imgFunction1.Visible = true;
        //                        imgFunction2.Visible = false;
        //                        imgRemoveButton.Visible = false;
        //                        lblPlantName.Visible = true;
        //                        lnkApproverName.Visible = false;
        //                        if (e.Row.Cells.Count > 1)
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "viscol";
        //                            if (e.Row.Cells[1] != null)
        //                                e.Row.Cells[1].CssClass = "viscol";
        //                            if (e.Row.Cells[2] != null)
        //                                e.Row.Cells[2].CssClass = "viscol";
        //                            if (e.Row.Cells[3] != null)
        //                                e.Row.Cells[3].CssClass = "viscol";
        //                            //if (e.Row != null)
        //                            //    e.Row.CssClass = "viscol";
        //                        }
        //                        else
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "viscol";
        //                        }
        //                    }
        //                    if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                    {
        //                        if (e.Row.Cells.Count > 1)
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "hiddencol";
        //                            if (e.Row.Cells[1] != null)
        //                                e.Row.Cells[1].CssClass = "hiddencol";
        //                            if (e.Row.Cells[2] != null)
        //                                e.Row.Cells[2].CssClass = "hiddencol";
        //                            if (e.Row.Cells[3] != null)
        //                                e.Row.Cells[3].CssClass = "hiddencol";
        //                            if (e.Row != null)
        //                                e.Row.CssClass = "hiddencol";
        //                        }
        //                        else
        //                        {
        //                            if (e.Row.Cells[0] != null)
        //                                e.Row.Cells[0].CssClass = "hiddencol";
        //                        }
        //                        imgFunction1.Visible = false;
        //                        imgFunction2.Visible = false;
        //                        imgRemoveButton.Visible = false;
        //                        lnkApproverName.Visible = false;
        //                        lblPlantName.Visible = false;
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //objErrorLog.SaveErrorLog(strModule + "gvRecords_HtmlRowCreated", "Error", ex.Message, "gvRecords_HtmlRowCreated", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
        //    }
        //}
        #endregion
        //#region "Datagrid_Events"
        ////Sub 	        :   Datagrid item command event
        ////Written BY	    :	Vijay
        ////parameters     :	 
        ////Purpose	    :   To detect delete command and view command event and perform appropriate operations
        ////Returns        :   
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 Vijay          1.0           created

        ////***************************************************
        //protected void drgdAppGrp_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //If view command event
        //    if (e.CommandName == "View_Approver")
        //    {
        //        Label lblFunctionID = (Label)drgdAppGrp.Items(e.Item.ItemIndex).FindControl("lblFunctID");
        //        Label lblApproverID = (Label)drgdAppGrp.Items(e.Item.ItemIndex).FindControl("lblApprvrID");
        //        Label lblPlantID = (Label)drgdAppGrp.Items(e.Item.ItemIndex).FindControl("lblPlantID");
        //        Label lblFunctName = (Label)drgdAppGrp.Items(e.Item.ItemIndex).FindControl("lblFunctName");
        //        Response.Redirect("ViewApprvr.aspx?Funct_ID=" + lblFunctionID.Text + "&Apprv_ID=" + lblApproverID.Text + "&Plant_ID=" + lblPlantID.Text);
        //        //Redirect to view page 
        //        //If delete command event
        //    }
        //    else if (e.CommandName == "RemoveApprover")
        //    {
        //        //Make sure of user's positive response
        //        //if (Request.Form("Response") == "Y")
        //        //{
        //            this.deleteApprover(Convert.ToInt32(e.CommandArgument));
        //            //Delete the approver
        //        //}
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
        //        ClientScript.RegisterStartupScript(this.GetType(),"clientscript", "document.getElementById('" + imgFunction2.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;
        //        for (int rowCount = rowno + 1; rowCount <= drgdAppGrp.Items.Count - 1; rowCount++)
        //        {
        //            Label lblFunctionName = (Label)drgdAppGrp.Items(rowCount).FindControl("lblFunctionName");
        //            LinkButton lnkApproverName = (LinkButton)drgdAppGrp.Items(rowCount).FindControl("lnkApproverName");
        //            ImageButton imgRemoveApprover = (ImageButton)drgdAppGrp.Items(rowCount).FindControl("imgRemoveApprover");
        //            if (string.IsNullOrEmpty(lblFunctionName.Text))
        //            {
        //                if (!string.IsNullOrEmpty(lnkApproverName.Text))
        //                {
        //                    drgdAppGrp.Items(rowCount).Visible = true;
        //                    lnkApproverName.Visible = true;
        //                    imgRemoveApprover.Visible = true;
        //                }
        //                else
        //                {
        //                    drgdAppGrp.Items(rowCount).Visible = false;
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

        //        ImageButton imgRemoveApprover = default(ImageButton);
        //        imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
        //        imgRemoveApprover.Visible = false;
        //        ClientScript.RegisterStartupScript(this.GetType(),"clientscript", "document.getElementById('" + imgFunction1.ClientID + "').focus();");

        //        int rowno = e.Item.ItemIndex;
        //        for (int rowCount = rowno + 1; rowCount <= drgdAppGrp.Items.Count - 1; rowCount++)
        //        {
        //            Label lblFunctionName = (Label)drgdAppGrp.Items(rowCount).FindControl("lblFunctionName");
        //            LinkButton lnkApproverName = (LinkButton)drgdAppGrp.Items(rowCount).FindControl("lnkApproverName");
        //            if (string.IsNullOrEmpty(lblFunctionName.Text))
        //            {
        //                drgdAppGrp.Items(rowCount).Visible = false;
        //            }
        //            else
        //            {
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //        }
        //    }
        //}
        ////Sub 	        :   Datagrid item data bound event
        ////Written BY	    :	Vijay
        ////parameters     :	 
        ////Purpose	    :   To detect delete command and view command event and perform appropriate operations
        ////Returns        :   
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 Vijay          1.0           created

        ////***************************************************
        //protected void drgdAppGrp_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch (e.Item.ItemType)
        //    {
        //        case ListItemType.AlternatingItem:
        //        case ListItemType.Item:
        //            ImageButton imgRemoveButton = (ImageButton)e.Item.FindControl("ImgRemoveApprover");
        //            LinkButton lnkApproverName2 = (LinkButton)e.Item.FindControl("lnkApproverName");
        //            Label labeltest = (Label)e.Item.FindControl("Label");
        //            //imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" & lnkApproverName2.Text & "');")
        //            imgRemoveButton.Attributes.Add("onclick", "return confirmApproverDelete('" + lnkApproverName2.Text + "','" + CheckApproverGroup(((LinkButton)e.Item.FindControl("lnkApproverName")).Text) + "');");
        //            if (!(ViewState["Expand"] == "ExpandMode"))
        //            {
        //                //Displaying only Function names in first load of datagrid
        //                ImageButton imgFunction1 = default(ImageButton);
        //                ImageButton imgFunction2 = default(ImageButton);
        //                ImageButton imgRemoveApprover = default(ImageButton);
        //                imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
        //                imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
        //                imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
        //                imgFunction2.Visible = false;
        //                imgRemoveApprover.Visible = false;
        //                Label lblFunctionID = default(Label);
        //                lblFunctionID = (Label)e.Item.FindControl("lblFunctionID");
        //                lblFunctionID.Visible = false;
        //                Label lblFunctionName = default(Label);
        //                lblFunctionName = (Label)e.Item.FindControl("lblFunctionName");
        //                if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                {
        //                    e.Item.Visible = false;
        //                    imgFunction1.Visible = false;
        //                    imgFunction2.Visible = false;
        //                    imgRemoveApprover.Visible = true;
        //                }
        //            }
        //            else
        //            {
        //                ImageButton imgFunction1 = default(ImageButton);
        //                ImageButton imgFunction2 = default(ImageButton);
        //                ImageButton imgRemoveApprover = default(ImageButton);
        //                imgFunction1 = (ImageButton)e.Item.FindControl("imgFunction1");
        //                imgFunction2 = (ImageButton)e.Item.FindControl("imgFunction2");
        //                imgRemoveApprover = (ImageButton)e.Item.FindControl("imgRemoveApprover");
        //                imgFunction2.Visible = false;
        //                imgRemoveApprover.Visible = false;
        //                Label lblFunctionID = default(Label);
        //                lblFunctionID = (Label)e.Item.FindControl("lblFunctionID");
        //                lblFunctionID.Visible = false;
        //                Label lblFunctionName = default(Label);
        //                lblFunctionName = (Label)e.Item.FindControl("lblFunctionName");
        //                if (string.IsNullOrEmpty(lblFunctionName.Text))
        //                {
        //                    //e.Item.Visible = False
        //                    imgFunction1.Visible = false;
        //                    imgFunction2.Visible = false;
        //                    imgRemoveApprover.Visible = true;
        //                }
        //                LinkButton lnkApproverName = default(LinkButton);
        //                lnkApproverName = (LinkButton)e.Item.FindControl("lnkApproverName");
        //                lnkApproverName.Visible = true;
        //                Label lblPlantName = default(Label);
        //                lblPlantName = (Label)e.Item.FindControl("lblPlantName");
        //                lblPlantName.Visible = true;
        //            }
        //            break;
        //    }
        //}
        //#endregion
        //#region "Anchor Tag Events"
        ////
        ////  ************************************************
        ////Name   	    :	acnhExpand_ServerClick
        ////Written BY	    :	Bharath
        ////parameters     :	None
        ////Purpose	    :   Displaying Projects by category in Expand Mode in datagrid
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/23/07                 Bharath            1.0           created
        ////***************************************************
        ////
        //protected void acnhExpand_ServerClick(object sender, System.EventArgs e)
        //{
        //    ViewState["Expand"] = "ExpandMode";
        //    FillEOApproversByFunction();
        //}
        ////
        ////  ************************************************
        ////Name   	    :	anchCollapse_ServerClick
        ////Written BY	    :	Bharath
        ////parameters     :	None
        ////Purpose	    :   Displaying Projects by category in Collapse Mode in datagrid
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/23/07                 Bharath            1.0           created
        ////***************************************************
        ////
        //protected void anchCollapse_ServerClick(object sender, System.EventArgs e)
        //{
        //    ViewState["Expand"] = "CollapseMode";
        //    FillEOApproversByFunction();
        //}
        //#endregion

        #region "Button_Events"
        //Sub 	        :   Create approver button click event
        //Written BY	    :	Vijay
        //parameters     :	 
        //Purpose	    :   Redirects user to add approver page
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void imgCreateApprover_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddApprvr.aspx");
        }
        //Sub 	        :   Expand button click event
        //Written BY	    :	Vijay
        //parameters     :	 
        //Purpose	    :   To display function/approver details in expand view
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************
        protected void imgExpand_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            FillEOApproversByFunction();
            //Call the function to fill the function/approver details
        }
        //Sub 	        :   Collapse button click event
        //Written BY	    :	Vijay
        //parameters     :	 
        //Purpose	    :   To display function/approver details in collapse view
        //Returns        :   
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Vijay          1.0           created

        //***************************************************

        protected void imgCollapse_Click(object sender, EventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillEOApproversByFunction();
            //Call the function to fill the function/approver details
        }
        #endregion

    }
}                                                                                                                                                                                                                                                                                                                                                                                       