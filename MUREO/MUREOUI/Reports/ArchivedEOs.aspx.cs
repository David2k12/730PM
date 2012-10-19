using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using MUREOUI.Common;
using System.Configuration;
using System.Data;
using MUREOBAL;
using System.Collections;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Reports
{
    public partial class ArchivedEOs : System.Web.UI.Page
    {
        clsSecurity objclsSecurity = null;
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            objclsSecurity = new clsSecurity();
            string strUserRole = string.Empty;
            string strUserName = string.Empty;
            strUserRole = objclsSecurity.UserRole();
            strUserName = objclsSecurity.UserName;
            if (strUserRole == "MUREO_Admin")
            {
                imgCreateNewEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgCreateNewEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgCreateNewEO.Enabled = false;
            }
            else if (strUserRole == "Readers")
            {
                imgCreateNewEO.Enabled = false;
            }

            if (!IsPostBack)
            {
                //TotalHeadData(False)
                PageButtonVisibility(false);
                FillArchivedEOs();
                dgdArchSelectedEO.Visible = false;
            }

        }

        #region "user Define Functions"

        public void TotalHeadData(bool optVisible)
        {
            lblPlantNameVal.Visible = optVisible;
            lblEOTypeVal.Visible = optVisible;
            lblStageVal.Visible = optVisible;
            lblPlant.Visible = optVisible;
            lblStagelb.Visible = optVisible;
            lblEOTypelb.Visible = optVisible;
        }

        public void PageButtonVisibility(bool optVisible)
        {
            //imgPrevious.Visible = optVisible;
            //imgNext.Visible = optVisible;
        }

        public void SelectedHeadData(bool optVisible)
        {
            lblPlantNameVal.Visible = optVisible;
            lblEOTypeVal.Visible = optVisible;
            lblStageVal.Visible = optVisible;
        }

        //  **************PagerButtonClick******************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	PagerButtonClick()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for custom paging of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/11/07                Md.Abdul allaam             1.0           created
        //***************************************************

        /*public void PagerButtonClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                string arg = sender.CommandArgument;
                switch (arg)
                {
                    case "Next":

                        if ((dgdArchSelectedEO.CurrentPageIndex < (dgdArchSelectedEO.PageCount - 1)))
                        {
                            dgdArchSelectedEO.CurrentPageIndex += 1;
                            imgNext.Enabled = true;
                            imgPrevious.Enabled = true;
                        }
                        if ((dgdArchSelectedEO.CurrentPageIndex == (dgdArchSelectedEO.PageCount - 1)))
                        {
                            //Dim jvScript As String
                            //jvScript = "alert('" & ConfigurationSettings.AppSettings("DataGridLastPage") & "');"
                            //Page.RegisterStartupScript("ClientScript", jvScript)
                            imgNext.Enabled = false;
                            imgPrevious.Enabled = true;

                        }
                        else if ((dgdArchSelectedEO.CurrentPageIndex >= 0) & (dgdArchSelectedEO.CurrentPageIndex < (dgdArchSelectedEO.PageCount - 1)))
                        {
                            imgNext.Enabled = true;
                            imgPrevious.Enabled = true;
                        }
                        break;
                    case "Prev":

                        if ((dgdArchSelectedEO.CurrentPageIndex > 0))
                        {
                            dgdArchSelectedEO.CurrentPageIndex -= 1;
                            imgNext.Enabled = true;
                            imgPrevious.Enabled = true;
                        }
                        if ((dgdArchSelectedEO.CurrentPageIndex == 0))
                        {
                            //Dim jvScript As String
                            //jvScript = "alert('" & ConfigurationSettings.AppSettings("DataGridFirstPage") & "');"
                            //Page.RegisterStartupScript("ClientScript", jvScript)
                            imgPrevious.Enabled = false;
                            imgNext.Enabled = true;
                        }
                        else if (dgdArchSelectedEO.CurrentPageIndex > 0 & (dgdArchSelectedEO.CurrentPageIndex < (dgdArchSelectedEO.PageCount - 1)))
                        {
                            imgPrevious.Enabled = true;
                            imgNext.Enabled = true;
                        }
                        break;
                    //Case "Last"
                    //dgdMyEO.CurrentPageIndex = (dgdMyEO.PageCount - 1)
                    //Case Else
                    //dgdMyEO.CurrentPageIndex = Convert.ToInt32(arg)
                }
                FillArchivedSelectedEOs(intGlobalPlantId, strGlobalStage, strGlobalEOType);
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                Page.RegisterStartupScript("clientscript", script);
            }
        }*/

        //
        protected void NoRecords()
        {
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "'); ";
            //ClientScript.RegisterStartupScript(this.GetType(), "No Records", strScript);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "No Records", strScript, true);
        }
        //  ************************************************
        //Name   	    :	FillArchivedEOs
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	None
        //Purpose	    :   Fills the datarid in tree view form.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //09/04/07                 Abdul            1.0           created
        //***************************************************
        //protected void FillArchivedEOs()
        //{
        //    DataSet dsArchivedEOs = null;
        //    ClsMyEOs objClsMyEOs = null;

        //    try
        //    {
        //        dsArchivedEOs = new DataSet();
        //        objClsMyEOs = new ClsMyEOs();
        //        //Creating object from ReportsBo class
        //        if (objClsMyEOs.GetArchivedEOs(ref dsArchivedEOs))
        //        {
        //            if (dsArchivedEOs == null)
        //            {
        //                NoRecords();
        //                tdDivider.Visible = false;
        //                lblPlant.Visible = false;
        //                lblStagelb.Visible = false;
        //                lblEOTypelb.Visible = false;
        //            }
        //            else if (dsArchivedEOs.Tables.Count == 0)
        //            {
        //                NoRecords();
        //                tdDivider.Visible = false;
        //                lblPlant.Visible = false;
        //                lblStagelb.Visible = false;
        //                lblEOTypelb.Visible = false;
        //            }
        //            else if (dsArchivedEOs.Tables[0].Rows.Count == 0)
        //            {
        //                NoRecords();
        //                tdDivider.Visible = false;
        //                lblPlant.Visible = false;
        //                lblStagelb.Visible = false;
        //                lblEOTypelb.Visible = false;
        //            }
        //            else
        //            {
        //                for (int i = 0; i <= dsArchivedEOs.Tables[0].Rows.Count - 1; i++)
        //                {
        //                    if (Convert.ToString(dsArchivedEOs.Tables[0].Rows[i].ItemArray[2]) != "")
        //                    {
        //                        if (dsArchivedEOs.Tables[0].Rows[i].ItemArray[2] == "Approved")
        //                        {
        //                            dsArchivedEOs.Tables[0].Rows[i].ItemArray[2] = "Completed";
        //                        }
        //                    }
        //                }
        //                tdDivider.Visible = true;
        //                lblPlant.Visible = true;
        //                lblStagelb.Visible = true;
        //                lblEOTypelb.Visible = true;
        //                //Preaparing temerory table for MyEvents
        //                DataTable dtArchivedEOs = new DataTable();
        //                DataRow drArchivedEO = null;
        //                dtArchivedEOs.Columns.Add("Plant_ID");
        //                dtArchivedEOs.Columns.Add("Plant_Name");
        //                dtArchivedEOs.Columns.Add("Stage_Status");
        //                dtArchivedEOs.Columns.Add("EO_Mode");

        //                //Below code for splitting data for treeview display and binding splitted data into temperory table
        //                ArrayList arrayPlant_Name = new ArrayList();
        //                ArrayList arrayPlant_id = new ArrayList();

        //                //First row item of Plant name
        //                string strPlant_Name = Convert.ToString(dsArchivedEOs.Tables[0].Rows[0].ItemArray[1]);
        //                string strPlant_ID = Convert.ToString(dsArchivedEOs.Tables[0].Rows[0].ItemArray[0]);

        //                //Adding Plant name to array
        //                arrayPlant_Name.Add(strPlant_Name);
        //                arrayPlant_id.Add(strPlant_ID);

        //                //Adding all Plant names(Without repitition)

        //                for (int rowCount = 0; rowCount <= dsArchivedEOs.Tables[0].Rows.Count - 1; rowCount++)
        //                {
        //                    string strPlant_Name1 = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowCount].ItemArray[1]);
        //                    string strPlant_ID1 = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowCount].ItemArray[0]);

        //                    if (!(arrayPlant_Name.Contains(strPlant_Name1)))
        //                    {
        //                        arrayPlant_Name.Add(strPlant_Name1);
        //                        arrayPlant_id.Add(strPlant_ID1);

        //                    }
        //                }


        //                //storing Plant name in to temperory table

        //                for (int rowPlant_NameCount = 0; rowPlant_NameCount <= arrayPlant_Name.Count - 1; rowPlant_NameCount++)
        //                {
        //                    drArchivedEO = dtArchivedEOs.NewRow();
        //                    drArchivedEO["Plant_ID"] = "";
        //                    drArchivedEO["Plant_Name"] = arrayPlant_Name[rowPlant_NameCount];
        //                    drArchivedEO["Stage_Status"] = "";
        //                    drArchivedEO["EO_Mode"] = "";


        //                    dtArchivedEOs.Rows.Add(drArchivedEO);

        //                    ArrayList arrayStage = new ArrayList();
        //                    //Dim arrayProjectID As New ArrayList


        //                    //Adding Project names(Without repitition) based on Project_Type Name

        //                    for (int rowProjectCount = 0; rowProjectCount <= dsArchivedEOs.Tables[0].Rows.Count - 1; rowProjectCount++)
        //                    {

        //                        if (Convert.ToString(arrayPlant_Name[rowPlant_NameCount]).Trim().ToUpper() == Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowProjectCount][1]).Trim().ToUpper())
        //                        {
        //                            string strStage = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowProjectCount][2]);
        //                            //Dim strProjectID As String = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowProjectCount](2))

        //                            if (arrayStage.Count == 0)
        //                            {
        //                                arrayStage.Add(strStage);
        //                                //arrayProjectID.Add(strProjectID)
        //                            }

        //                            if (!(arrayStage.Contains(strStage)))
        //                            {
        //                                arrayStage.Add(strStage);
        //                                //arrayProjectID.Add(strProjectID)
        //                            }

        //                        }

        //                    }


        //                    //storing  Project name in to temperory table

        //                    for (int rowProjectCount1 = 0; rowProjectCount1 <= arrayStage.Count - 1; rowProjectCount1++)
        //                    {
        //                        drArchivedEO = dtArchivedEOs.NewRow();
        //                        drArchivedEO["Plant_ID"] = "";
        //                        drArchivedEO["Plant_Name"] = "";
        //                        drArchivedEO["Stage_Status"] = arrayStage[rowProjectCount1];
        //                        drArchivedEO["EO_Mode"] = "";

        //                        dtArchivedEOs.Rows.Add(drArchivedEO);

        //                        ArrayList arrayEOMode = new ArrayList();
        //                        //Dim arrayPlantID As New ArrayList


        //                        //Adding EO Mode names(Without repitition) based on Stage Name

        //                        for (int rowPlantCount = 0; rowPlantCount <= dsArchivedEOs.Tables[0].Rows.Count - 1; rowPlantCount++)
        //                        {

        //                            if (Convert.ToString(arrayPlant_Name[rowPlant_NameCount]).Trim().ToUpper() == Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount][1]).Trim().ToUpper() & Convert.ToString(arrayStage[rowProjectCount1]).Trim().ToUpper() == Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount].ItemArray[2]).Trim().ToUpper())
        //                            {
        //                                string strEOMode = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount][3]);
        //                                //Dim strPlantID As String = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount][4))

        //                                if (arrayEOMode.Count == 0)
        //                                {
        //                                    arrayEOMode.Add(strEOMode);
        //                                    //arrayPlantID.Add(strPlantID)
        //                                }

        //                                if (!(arrayEOMode.Contains(strEOMode)))
        //                                {
        //                                    arrayEOMode.Add(strEOMode);
        //                                    //arrayPlantID.Add(strPlantID)
        //                                }

        //                            }

        //                        }


        //                        for (int rowPlantCount1 = 0; rowPlantCount1 <= arrayEOMode.Count - 1; rowPlantCount1++)
        //                        {
        //                            drArchivedEO = dtArchivedEOs.NewRow();
        //                            drArchivedEO["Plant_ID"] = arrayPlant_id[rowPlant_NameCount];
        //                            drArchivedEO["Plant_Name"] = "";
        //                            drArchivedEO["Stage_Status"] = "";
        //                            drArchivedEO["EO_Mode"] = Convert.ToString(arrayEOMode[rowPlantCount1]);

        //                            dtArchivedEOs.Rows.Add(drArchivedEO);


        //                        }

        //                    }
        //                }
        //                //now the splitted data is available in dtEventsbyProject table
        //                //binding temperory table to datagrid
        //                dgdArchivedEOs.DataSource = dtArchivedEOs;
        //                dgdArchivedEOs.DataBind();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        string exMessage = null;
        //        exMessage = ex.Message.Replace("'", " ");
        //        strScript = "alert('" + ex.Message + "'); ";
        //        //Page.RegisterStartupScript("clientscript", script);
        //        ExceptionMsg(strScript);
        //    }
        //    finally
        //    {
        //        dsArchivedEOs = null;
        //        objClsMyEOs = null;
        //    }
        //}
        protected void FillArchivedEOs()
        {
            try
            {
                ClsMyEOs cls = new ClsMyEOs();
               DataSet dsArchivedEOs = new DataSet();
                //Creating object from ReportsBo class

                if (cls.GetArchivedEOs(ref dsArchivedEOs))
                {
                    if (dsArchivedEOs == null)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblPlant.Visible = false;
                        lblStagelb.Visible = false;
                        lblEOTypelb.Visible = false;
                    }
                    else if (dsArchivedEOs.Tables.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblPlant.Visible = false;
                        lblStagelb.Visible = false;
                        lblEOTypelb.Visible = false;
                    }
                    else if (dsArchivedEOs.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        tdDivider.Visible = false;
                        lblPlant.Visible = false;
                        lblStagelb.Visible = false;
                        lblEOTypelb.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i <= dsArchivedEOs.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Convert.ToString(dsArchivedEOs.Tables[0].Rows[i][2]) == "Approved")
                            {
                                dsArchivedEOs.Tables[0].Rows[i][2] = "Completed";
                            }
                        }
                        tdDivider.Visible = true;
                        lblPlant.Visible = true;
                        lblStagelb.Visible = true;
                        lblEOTypelb.Visible = true;
                        //Preaparing temerory table for MyEvents
                        DataTable dtArchivedEOs = new DataTable();
                        DataRow drArchivedEO = null;
                        dtArchivedEOs.Columns.Add("Plant_ID");
                        dtArchivedEOs.Columns.Add("Plant_Name");
                        dtArchivedEOs.Columns.Add("Stage_Status");
                        dtArchivedEOs.Columns.Add("EO_Mode");

                        //Below code for splitting data for treeview display and binding splitted data into temperory table
                        ArrayList arrayPlant_Name = new ArrayList();
                        ArrayList arrayPlant_id = new ArrayList();

                        //First row item of Plant name
                        string strPlant_Name = Convert.ToString(dsArchivedEOs.Tables[0].Rows[0][1]);
                        string strPlant_ID = Convert.ToString(dsArchivedEOs.Tables[0].Rows[0][0]);

                        //Adding Plant name to array
                        arrayPlant_Name.Add(strPlant_Name);
                        arrayPlant_id.Add(strPlant_ID);

                        //Adding all Plant names(Without repitition)

                        for (int rowCount = 0; rowCount <= dsArchivedEOs.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            string strPlant_Name1 = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowCount][1]);
                            string strPlant_ID1 = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowCount][0]);


                            if (!(arrayPlant_Name.Contains(strPlant_Name1)))
                            {
                                arrayPlant_Name.Add(strPlant_Name1);
                                arrayPlant_id.Add(strPlant_ID1);

                            }
                        }


                        //storing Plant name in to temperory table

                        for (int rowPlant_NameCount = 0; rowPlant_NameCount <= arrayPlant_Name.Count - 1; rowPlant_NameCount++)
                        {
                            drArchivedEO = dtArchivedEOs.NewRow();
                            drArchivedEO["Plant_ID"] = "";
                            drArchivedEO["Plant_Name"] = arrayPlant_Name[rowPlant_NameCount];
                            drArchivedEO["Stage_Status"] = "";
                            drArchivedEO["EO_Mode"] = "";


                            dtArchivedEOs.Rows.Add(drArchivedEO);

                            ArrayList arrayStage = new ArrayList();
                            //Dim arrayProjectID As New ArrayList


                            //Adding Project names(Without repitition) based on Project_Type Name

                            for (int rowProjectCount = 0; rowProjectCount <= dsArchivedEOs.Tables[0].Rows.Count - 1; rowProjectCount++)
                            {

                                if (Convert.ToString(arrayPlant_Name[rowPlant_NameCount]).Trim().ToUpper() == Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowProjectCount][1]).Trim().ToUpper())
                                {
                                    string strStage = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowProjectCount][2]);
                                    //Dim strProjectID As String = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowProjectCount](2))

                                    if (arrayStage.Count == 0)
                                    {
                                        arrayStage.Add(strStage);
                                        //arrayProjectID.Add(strProjectID)
                                    }

                                    if (!(arrayStage.Contains(strStage)))
                                    {
                                        arrayStage.Add(strStage);
                                        //arrayProjectID.Add(strProjectID)
                                    }

                                }

                            }


                            //storing  Project name in to temperory table

                            for (int rowProjectCount1 = 0; rowProjectCount1 <= arrayStage.Count - 1; rowProjectCount1++)
                            {
                                if(!string.IsNullOrEmpty(Convert.ToString(arrayStage[rowProjectCount1])))
                                {
                                drArchivedEO = dtArchivedEOs.NewRow();
                                drArchivedEO["Plant_ID"] = "";
                                drArchivedEO["Plant_Name"] = "";
                                drArchivedEO["Stage_Status"] = arrayStage[rowProjectCount1];
                                drArchivedEO["EO_Mode"] = "";

                                dtArchivedEOs.Rows.Add(drArchivedEO);
                                }

                                ArrayList arrayEOMode = new ArrayList();
                                //Dim arrayPlantID As New ArrayList


                                //Adding EO Mode names(Without repitition) based on Stage Name

                                for (int rowPlantCount = 0; rowPlantCount <= dsArchivedEOs.Tables[0].Rows.Count - 1; rowPlantCount++)
                                {

                                    if (Convert.ToString(arrayPlant_Name[rowPlant_NameCount]).Trim().ToUpper() == Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount][1]).Trim().ToUpper() & Convert.ToString(arrayStage[rowProjectCount1]).Trim().ToUpper() == Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount][2]).Trim().ToUpper())
                                    {
                                        string strEOMode = Convert.ToString(dsArchivedEOs.Tables[0].Rows[rowPlantCount][3]);
                                        //Dim strPlantID As String = Convert.ToString(dsArchivedEOs.Tables[0].Rows(rowPlantCount)(4))

                                        if (arrayEOMode.Count == 0)
                                        {
                                            arrayEOMode.Add(strEOMode);
                                            //arrayPlantID.Add(strPlantID)
                                        }

                                        if (!(arrayEOMode.Contains(strEOMode)))
                                        {
                                            arrayEOMode.Add(strEOMode);
                                            //arrayPlantID.Add(strPlantID)
                                        }

                                    }

                                }


                                for (int rowPlantCount1 = 0; rowPlantCount1 <= arrayEOMode.Count - 1; rowPlantCount1++)
                                {
                                    drArchivedEO = dtArchivedEOs.NewRow();
                                    drArchivedEO["Plant_ID"] = arrayPlant_id[rowPlant_NameCount];
                                    drArchivedEO["Plant_Name"] = "";
                                    drArchivedEO["Stage_Status"] = "";
                                    drArchivedEO["EO_Mode"] = Convert.ToString(arrayEOMode[rowPlantCount1]);

                                    dtArchivedEOs.Rows.Add(drArchivedEO);


                                }

                            }
                        }
                        //now the splitted data is available in dtEventsbyProject table
                        //binding temperory table to datagrid
                        dgdArchivedEOs.DataSource = dtArchivedEOs;
                        dgdArchivedEOs.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                //Page.RegisterStartupScript("clientscript", script);
                ExceptionMsg(script);
            }
        }

        protected void ExceptionMsg(string strScriptMsg)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Exception", strScriptMsg);
        }

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAppPrelimSelectedEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   fills the datagrid in normal form.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/03/07                Md.Abdul allaam             1.0           created
        //***************************************************

        protected void FillArchivedSelectedEOs(int intPlantID, string strStage, string strEOType)
        {
            DataSet dsSelectArchivedEOs = null;
            ClsMyEOs objClsMyEOs = null;
            string strEOMode = string.Empty;
            string strUserName=string.Empty;
            clsSecurity objclsSecurity=null;
            string strUserRole = string.Empty;
            try
            {
                dgdArchSelectedEO.DataSource = null;

                dsSelectArchivedEOs = new DataSet();
               
                if (strEOType == "EO")
                {
                    strEOMode = "E";
                }
                else if (strEOType == "Routed")
                {
                    strEOMode = "R";
                }
                objclsSecurity=new clsSecurity();
                strUserName= objclsSecurity.UserName;
                strUserRole = objclsSecurity.UserRole();

                //BusinessObject.MUREO.BusinessObject.ClsMyEOs objEOs = new BusinessObject.MUREO.BusinessObject.ClsMyEOs();
                //dsSelectArchivedEOs = objEOs.GetArchivedSelectedEO(intPlantID, strStage, strEOType, strUserName);

                objClsMyEOs = new ClsMyEOs();
                if(objClsMyEOs.GetArchivedSelectedEO(intPlantID,strStage,strEOType,strUserName,ref dsSelectArchivedEOs))
                {

                if (dsSelectArchivedEOs == null)
                {
                    NoRecords();
                    dgdArchSelectedEO.DataSource = null;
                    dgdArchSelectedEO.Visible = false;
                }
                else if (dsSelectArchivedEOs.Tables.Count == 0)
                {
                    NoRecords();
                    dgdArchSelectedEO.DataSource = null;
                    dgdArchSelectedEO.Visible = false;
                }
                else if (dsSelectArchivedEOs.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                    dgdArchSelectedEO.DataSource = null;
                    dgdArchSelectedEO.Visible = false;
                }
                else if (dsSelectArchivedEOs.Tables[0].Rows.Count > 0)
                {
                    dgdArchSelectedEO.DataSource = dsSelectArchivedEOs.Tables[0].DefaultView;
                    /*if (((dsSelectArchivedEOs.Tables[0].Rows.Count) <= dgdArchSelectedEO.VisibleRowCount))
                    {
                        //PageButtonVisibility(false);
                    }
                    else
                    {
                        //PageButtonVisibility(true);
                    }*/
                    //Code added by Vijay
                   /* if ((viewState("SortExp") != null))
                    {
                        string SortExp = null;
                        string strSort = null;
                        DataView dv = new DataView(dsSelectArchivedEOs.Tables[0]);
                        //Create a data view for the sort
                        string imgAsc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                        string imgDesc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                        SortExp = viewState("SortExp");
                        strSort = SortExp + viewState("StrSort");
                        dv.Sort = strSort;
                        dgdArchSelectedEO.DataSource = dv;
                        foreach (DataGridColumn col in dgdArchSelectedEO.Columns)
                        {
                            string header_text = col.HeaderText;
                            int position = col.HeaderText.IndexOf(" ");
                            if (col.SortExpression == SortExp)
                            {
                                if (position > -1)
                                {
                                    header_text = col.HeaderText.Substring(0, position);
                                }
                                if (viewState("StrSort") == " Asc")
                                {
                                    col.HeaderText = string.Concat(header_text, imgAsc);
                                }
                                else
                                {
                                    col.HeaderText = string.Concat(header_text, imgDesc);
                                }
                            }
                            else
                            {
                                if (position > -1)
                                {
                                    header_text = col.HeaderText.Substring(0, position);
                                    col.HeaderText = header_text;
                                }
                            }
                        }
                    }*/

                    dgdArchSelectedEO.DataBind();
                    dgdArchSelectedEO.Visible = true;
                    lblPlantNameVal.Text = Convert.ToString(dsSelectArchivedEOs.Tables[0].Rows[0][8]);
                    //Following code is for enabling and disabling the links on the form based on the user roles.
                    if (strUserRole == "MUREO_Admin")
                    {
                        EnableDisableLinks(true);
                    }
                    else
                    {
                        EnableDisableLinks(false);
                    }
                    for (int numRows = 0; numRows <= dgdArchSelectedEO.VisibleRowCount - 1; numRows++)
                    {
                        /*Label lblISApproved = default(Label);
                        lblISApproved = (Label)dgdArchSelectedEO.Items(numRows).FindControl("lblISApprovar");

                        if (Strings.UCase(lblISApproved.Text) == Strings.UCase("Yes"))
                        {
                            EnableDisableLinksForRow(true, numRows);
                        }
                        else
                        {
                            EnableDisableLinksForRow(false, numRows);
                        }*/

                        Label lblModiLink = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["Last Modified"], "lblModiLink");
                        if (lblModiLink != null)
                        {
                            if (lblModiLink.Text.ToUpper() == "Yes".ToUpper())
                            {
                                EnableDisableLinksForRow(true, numRows);
                            }
                            else
                            {
                                EnableDisableLinksForRow(false, numRows);
                            }
                        }
                    }
                }
                
            }
            }
            catch (Exception ex)
            {
                strScript = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                strScript = "alert('" + ex.Message + "'); ";
                ExceptionMsg(strScript);
            }
        }

        public void EnableDisableLinksForRow(bool optBool, int numRows)
        {
            //following code is for hiding and showing of buttons based on the condition.
            //LinkButton lnkEONum = default(LinkButton);
            //lnkEONum = (LinkButton)dgdArchSelectedEO.Items(numRows).FindControl("hypEONumber");
            //lnkEONum.Enabled = optBool;
            //LinkButton lnkEOTitle = default(LinkButton);
            //lnkEOTitle = (LinkButton)dgdArchSelectedEO.Items(numRows).FindControl("hypEOTitle");
            //lnkEOTitle.Enabled = optBool;
            //LinkButton lnkEOModDate = default(LinkButton);
            //lnkEOModDate = (LinkButton)dgdArchSelectedEO.Items(numRows).FindControl("hypModifiedDate");
            //lnkEOModDate.Enabled = optBool;

            LinkButton lnkEONum = (LinkButton)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Num"], "hypEONumber");
            lnkEONum.Enabled = optBool;
            LinkButton lnkEOTitle = (LinkButton)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Title"], "hypEOTitle");
            lnkEOTitle.Enabled = optBool;
            LinkButton lnkEOModDate = (LinkButton)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["Last Modified"], "hypModifiedDate");
            lnkEOTitle.Enabled = optBool;
        }

        //  **************EnableDisableLinks*********************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillAllEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	optBool
        //Purpose	    :   enables and disables the links based on user Role.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/25/07                Md.Abdul allaam             1.0           created
        //***************************************************
        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgdArchSelectedEO.VisibleRowCount - 1; numRows++)
            {
                //LinkButton lnkEONum = default(LinkButton);
                //lnkEONum = (LinkButton)dgdArchSelectedEO.Items(numRows).FindControl("hypEONumber");
                //lnkEONum.Enabled = optBool;
                //LinkButton lnkEOTitle = default(LinkButton);
                //lnkEOTitle = (LinkButton)dgdArchSelectedEO.Items(numRows).FindControl("hypEOTitle");
                //lnkEOTitle.Enabled = optBool;
                //LinkButton lnkEOModDate = default(LinkButton);
                //lnkEOModDate = (LinkButton)dgdArchSelectedEO.Items(numRows).FindControl("hypModifiedDate");
                //lnkEOModDate.Enabled = optBool;

                LinkButton lnkEONum = (LinkButton)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Num"], "hypEONumber");
                lnkEONum.Enabled = optBool;
                LinkButton lnkEOTitle = (LinkButton)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Title"], "hypEOTitle");
                lnkEOTitle.Enabled = optBool;
                LinkButton lnkEOModDate = (LinkButton)dgdArchSelectedEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdArchSelectedEO.Columns["Last Modified"], "hypModifiedDate");
                lnkEOTitle.Enabled = optBool;
            }
        }

        #endregion


        protected void dgdArchivedEOs_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            clsSecurity cls = new clsSecurity();
            try
            {           
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    ImageButton imgplant1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "imgPlant1");
                    ImageButton imgplant2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "imgPlant2");
                    Label lblplantName = (Label)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "lblPlantName");
                    Label lblPlantId = (Label)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "lblPlantID");

                    ImageButton imgstage1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "imgStage1");
                    ImageButton imgstage2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "imgStage2");
                    Label lblstage = (Label)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "lblStage");

                    Label lblEoMode = (Label)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "lblEOMode");
                    ImageButton imgEoMode1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "imgEOMode1");
                    ImageButton imgEoMode2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "imgEOMode2");
                    if (imgplant1 != null)
                    {
                        if (ViewState["Expand"] != null)
                        {
                            if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                            {

                                dgdArchSelectedEO.Visible = false;
                                lblPlantNameVal.Visible = false;
                                lblStageVal.Visible = false;
                                lblEOTypeVal.Visible = false;
                                //Displaying only Plant names in first load of datagrid                      
                                imgplant2.Visible = false;
                                lblPlantId.Visible = false;
                                imgplant1.Visible = true;
                                imgEoMode1.Visible = false;
                                lblplantName.Visible = true;
                                imgEoMode2.Visible = false;
                                lblEoMode.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                if (string.IsNullOrEmpty(lblplantName.Text) && string.IsNullOrEmpty(lblstage.Text) && string.IsNullOrEmpty(lblEoMode.Text))
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
                                }
                                if (string.IsNullOrEmpty(lblplantName.Text))
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
                                    imgplant1.Visible = false;
                                    imgplant2.Visible = false;
                                    lblplantName.Visible = false;
                                    lblPlantId.Visible = false;
                                    imgEoMode1.Visible = false;
                                    imgEoMode2.Visible = false;
                                    lblEoMode.Visible = false;
                                    imgstage1.Visible = false;
                                    imgstage2.Visible = false;
                                    lblstage.Visible = false;
                                }

                            }
                            else
                            {
                                if (dgdArchSelectedEO.Visible)
                                {
                                    lblPlantNameVal.Visible = false;
                                    lblStageVal.Visible = false;
                                    lblEOTypeVal.Visible = false;
                                }

                                //Displaying only Plant names in first load of datagrid

                                imgplant2.Visible = true;
                                imgplant1.Visible = false;
                                lblEoMode.Visible = false;
                                lblPlantId.Visible = false;
                                lblplantName.Visible = true;
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                if (string.IsNullOrEmpty(lblplantName.Text))
                                {
                                    imgplant1.Visible = false;
                                    imgplant2.Visible = false;
                                    lblplantName.Visible = false;
                                    imgEoMode1.Visible = false;
                                    imgEoMode2.Visible = false;
                                    lblEoMode.Visible = false;
                                    imgstage1.Visible = true;
                                    imgstage2.Visible = false;
                                    lblstage.Visible = true;
                                    if (e.Row.Cells.Count > 1)
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                        if (e.Row.Cells[1] != null)
                                            e.Row.Cells[1].CssClass = "viscol";
                                        if (e.Row.Cells[2] != null)
                                            e.Row.Cells[2].CssClass = "viscol";
                                        if (e.Row != null)
                                            e.Row.CssClass = "viscol";
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                    }
                                }
                                if (!string.IsNullOrEmpty(lblEoMode.Text) && string.IsNullOrEmpty(lblplantName.Text))
                                {
                                    imgplant1.Visible = false;
                                    imgplant2.Visible = false;
                                    lblplantName.Visible = false;
                                    imgEoMode1.Visible = true;
                                    imgEoMode2.Visible = false;
                                    lblEoMode.Visible = true;
                                    imgstage1.Visible = false;
                                    imgstage2.Visible = false;
                                    lblstage.Visible = false;
                                    if (e.Row.Cells.Count > 1)
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                        if (e.Row.Cells[1] != null)
                                            e.Row.Cells[1].CssClass = "viscol";
                                        if (e.Row.Cells[2] != null)
                                            e.Row.Cells[2].CssClass = "viscol";
                                        if (e.Row != null)
                                            e.Row.CssClass = "viscol";
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                    }
                                }
                                if (string.IsNullOrEmpty(lblplantName.Text) && string.IsNullOrEmpty(lblEoMode.Text) && string.IsNullOrEmpty(lblstage.Text))
                                {
                                    imgplant1.Visible = false;
                                    imgplant2.Visible = false;
                                    lblplantName.Visible = false;
                                    imgEoMode1.Visible = false;
                                    imgEoMode2.Visible = false;
                                    lblEoMode.Visible = false;
                                    imgstage1.Visible = false;
                                    imgstage2.Visible = false;
                                    lblstage.Visible = false;
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
                                }

                            }
                        }
                        else
                        {
                            if (ViewState["Single"] == null)
                            {
                                imgplant2.Visible = false;
                                imgplant1.Visible = true;
                                lblplantName.Visible = true;
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = false;
                                lblEoMode.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                if (string.IsNullOrEmpty(lblplantName.Text))
                                {
                                    //GridViewTableDataRow gvdc = (GridViewTableDataRow)lblFunctionName.Parent.Parent.Parent;    
                                    imgEoMode1.Visible = false;
                                    imgEoMode2.Visible = false;
                                    imgplant2.Visible = false;
                                    imgplant1.Visible = false;
                                    lblEoMode.Visible = false;
                                    imgstage1.Visible = false;
                                    imgstage2.Visible = false;
                                    lblstage.Visible = false;
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
                                }
                                if (string.IsNullOrEmpty(lblplantName.Text) && string.IsNullOrEmpty(lblstage.Text) && string.IsNullOrEmpty(lblEoMode.Text))
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
                                }
                            }
                            else if (cls.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                            {
                                lblplantName.Visible = true;
                                imgplant2.Visible = true;
                                imgplant1.Visible = false;
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = false;
                                lblEoMode.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";

                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                            }
                            else if (cls.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                            {
                                imgplant2.Visible = false;
                                imgplant1.Visible = false;
                                lblplantName.Visible = false;
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = false;
                                lblEoMode.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                if (string.IsNullOrEmpty(lblplantName.Text))
                                {
                                    imgEoMode1.Visible = false;
                                    imgEoMode2.Visible = false;
                                    imgplant2.Visible = false;
                                    imgplant1.Visible = false;
                                    lblEoMode.Visible = false;
                                    lblplantName.Visible = false;
                                    imgstage1.Visible = true;
                                    imgstage2.Visible = false;
                                    lblstage.Visible = true;
                                    if (e.Row.Cells.Count > 1)
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                        if (e.Row.Cells[1] != null)
                                            e.Row.Cells[1].CssClass = "viscol";
                                        if (e.Row.Cells[2] != null)
                                            e.Row.Cells[2].CssClass = "viscol";
                                        if (e.Row != null)
                                            e.Row.CssClass = "viscol";
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[0] != null)
                                            e.Row.Cells[0].CssClass = "viscol";
                                    }
                                }
                            }
                            else
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
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = false;
                                imgplant2.Visible = false;
                                imgplant1.Visible = false;
                                lblEoMode.Visible = false;
                                lblplantName.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                            }
                            if (cls.IsExists(Convert.ToString(ViewState["EOMain"]), Convert.ToString(e.VisibleIndex)))
                            {

                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = false;
                                imgplant2.Visible = false;
                                imgplant1.Visible = false;
                                lblEoMode.Visible = false;
                                lblplantName.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = true;
                                lblstage.Visible = true;
                            }
                            if (cls.IsExists(Convert.ToString(ViewState["EOMainSingle"]), Convert.ToString(e.VisibleIndex)))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                imgEoMode1.Visible = true;
                                imgEoMode2.Visible = false;
                                imgplant2.Visible = false;
                                imgplant1.Visible = false;
                                lblEoMode.Visible = true;
                                lblplantName.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                            }
                            if (cls.IsExists(Convert.ToString(ViewState["EOOMain"]), Convert.ToString(e.VisibleIndex)))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row.Cells[2] != null)
                                        e.Row.Cells[2].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                imgEoMode1.Visible = false;
                                imgEoMode2.Visible = true;
                                imgplant2.Visible = false;
                                imgplant1.Visible = false;
                                lblEoMode.Visible = true;
                                lblplantName.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                            }
                        }

                    }
                }
            }
            catch (Exception exc)
            {
            }
        }

        protected void imgExpnadAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";
            FillArchivedEOs();
        }

        protected void imgCollapseAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillArchivedEOs();
            dgdArchSelectedEO.Visible = false;
        }

        protected void imgCreateNewEO_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/Common/NewEO.aspx");
        }


        protected void dgdArchSelectedEO_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    Label lblCurrentStage = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchSelectedEO.Columns["Current Stage"], "lblCurrentStage");
                    Label lblStageStatus = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdArchSelectedEO.Columns["Status"], "lblStageStatus");
                    if (lblCurrentStage.Text.ToUpper() == "CloseOut".ToUpper() & lblStageStatus.Text.ToUpper() == "Approved".ToUpper())
                    {
                        lblStageStatus.Text = "Completed";
                    }
                }
            }
            catch (Exception exc)
            {


            }
        }

        protected void ImgReadOnlyEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strstage = Convert.ToString(e.CommandArgument);


                if (strstage.ToUpper() == "Preliminary".ToUpper())
                {
                    view = "1";
                }
                else if (strstage.ToUpper() == "Final".ToUpper())
                {
                    view = "2";
                }
                else if (strstage.ToUpper() == "Closeout".ToUpper())
                {
                    view = "3";
                }
                Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", Convert.ToString(intEOID), Convert.ToString(view), "Report"));

            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void hypEONumber_Command(object sender, CommandEventArgs e)
        {
            try
            {
                LinkButton lnkEONum = (LinkButton)sender;
                string strStage = Convert.ToString(e.CommandArgument);
                int intEOID = 0;
                if (e.CommandName != null)
                    intEOID = Convert.ToInt32(e.CommandName);
                if (strStage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "AllEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void hypEOTitle_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void hypModifiedDate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", Convert.ToInt32(e.CommandName)));
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                //FillArchivedEOs();
                ViewState["Expand"] = null;
                string st = string.Empty;

                ImageButton imgPlant1 = (ImageButton)sender;
                imgPlant1.Visible = false;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");
                imgPlant2.Visible = true;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= dgdArchivedEOs.VisibleRowCount - 1; rowCount++)
                {


                    Label lblPlantName = (Label)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "lblPlantName");
                    Label lblEOMode = (Label)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "lblEOMode");


                    ImageButton imgEOMode1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "imgEOMode1");
                    ImageButton imgEOMode2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "imgEOMode2");

                    ImageButton imgstage1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "imgStage1");
                    ImageButton imgstage2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "imgStage2");
                    Label lblstage = (Label)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "lblStage");
                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                            if (!string.IsNullOrEmpty(lblstage.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgEOMode1.Visible = true;
                                imgEOMode2.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                            }

                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                ViewState["Single"] = st.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void imgPlant2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            dgdArchSelectedEO.Visible = false;
            lblPlantNameVal.Visible = false;
            lblStageVal.Visible = false;
            lblEOTypeVal.Visible = false;

            ImageButton imgPlant2 = (ImageButton)sender;
            ImageButton imgPlant1 = (ImageButton)imgPlant2.Parent.FindControl("imgPlant1");
            imgPlant2.Visible = false;
            imgPlant1.Visible = true;

            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
            int rowno = gvd.ItemIndex;


            for (int rowCount = rowno + 1; rowCount <= dgdArchivedEOs.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                Label lblplantname = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "lblPlantName");
                Label lblplantid = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "lblPlantID");
                Label lbleoMode = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "lblEOMode");

                ImageButton imgEoMode1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "imgEOMode1");
                ImageButton imgEoMode2 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "imgEOMode2");

                ImageButton imgstage1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "imgStage1");
                ImageButton imgstage2 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "imgStage2");
                Label lblstage = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "lblStage");

                if (lblplantname != null)
                {
                    if (string.IsNullOrEmpty(lblplantname.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblplantname.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        imgEoMode1.Visible = false;
                        imgEoMode2.Visible = false;
                        lbleoMode.Visible = false;
                        imgstage1.Visible = false;
                        imgstage2.Visible = false;
                        lblstage.Visible = false;
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
                else
                {
                    break;
                }
            }
        }


        /*protected void imgPlant1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                string st = string.Empty;

                ImageButton imgPlant1 = (ImageButton)sender;
                imgPlant1.Visible = false;
                ImageButton imgPlant2 = (ImageButton)imgPlant1.Parent.FindControl("imgPlant2");
                imgPlant2.Visible = true;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgPlant1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= dgdArchivedEOs.VisibleRowCount - 1; rowCount++)
                {
                    st = st + Convert.ToString(rowCount) + ",";
                    ViewState["Single"] = st.TrimEnd(new char[] { ',' });
                    Label lblPlantName = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "lblPlantName");
                    Label lblEOMode = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "lblEOMode");


                    ImageButton imgEOMode1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "imgEOMode1");
                    ImageButton imgEOMode2 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "imgEOMode2");

                    ImageButton imgstage1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "imgStage1");
                    ImageButton imgstage2 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "imgStage2");
                    Label lblstage = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "lblStage");
                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text))
                        {
                            if (!string.IsNullOrEmpty(lblEOMode.Text))
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgEOMode1.Visible = true;
                                imgEOMode2.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = false;
                                imgstage1.Visible = false;
                                imgstage2.Visible = false;
                                lblstage.Visible = false;
                            }

                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }*/

        protected void imgStage2_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            dgdArchSelectedEO.Visible = false;
            lblPlantNameVal.Visible = false;
            lblStageVal.Visible = false;
            lblEOTypeVal.Visible = false;

            ImageButton imgStage2 = (ImageButton)sender;
            ImageButton imgStage1 = (ImageButton)imgStage2.Parent.FindControl("imgStage1");
            imgStage2.Visible = false;
            imgStage1.Visible = true;

            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgStage1.Parent;
            int rowno = gvd.ItemIndex;


            for (int rowCount = rowno + 1; rowCount <= dgdArchivedEOs.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                Label lblstage = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "lblStage");
                Label lblplantid = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "lblPlantID");
                Label lbleoMode = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "lblEOMode");

                ImageButton imgplant1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "imgPlant1");
                ImageButton imgplant2 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "imgPlant2");

                ImageButton imgEoMode1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "imgEOMode1");
                ImageButton imgEoMode12 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "imgEOMode2");


                if (lblstage != null)
                {
                    if (string.IsNullOrEmpty(lblstage.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblstage.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        imgplant1.Visible = false;
                        imgplant2.Visible = false;
                        lbleoMode.Visible = false;
                        imgEoMode1.Visible = false;
                        imgEoMode12.Visible = false;
                        lblstage.Visible = false;
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
                else
                {
                    break;
                }
            }
        }

        protected void imgStage1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                FillArchivedEOs();
                ViewState["Expand"] = null;
                string st = string.Empty;

                ImageButton imgStage1 = (ImageButton)sender;
                imgStage1.Visible = false;
                ImageButton imgStage2 = (ImageButton)imgStage1.Parent.FindControl("imgStage2");
                imgStage2.Visible = true;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgStage1.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["EOMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= dgdArchivedEOs.VisibleRowCount - 1; rowCount++)
                {
                                    

                    Label lblEOMode = (Label)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "lblEOMode");
                    Label lblplantname = (Label)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "lblPlantName");

                    ImageButton imgEOMode1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "imgEOMode1");
                    ImageButton imgEOMode2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["EO Type"], "imgEOMode2");

                    //ImageButton imgstage1 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "imgStage1");
                    //ImageButton imgstage2 = (ImageButton)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Stage"], "imgStage2");
                    Label lblstage = (Label)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "lblStage");

                    ImageButton imgplant1 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "imgPlant1");
                    ImageButton imgplant2 = (ImageButton)dgdArchivedEOs.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchivedEOs.Columns["Plant"], "imgPlant2");
                    if (lblstage != null)
                    {
                        if (string.IsNullOrEmpty(lblstage.Text))
                        {
                            if (!string.IsNullOrEmpty(lblEOMode.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";   
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgEOMode1.Visible = true;
                                imgEOMode2.Visible = false;
                                imgplant1.Visible = false;
                                imgplant2.Visible = false;
                                lblplantname.Visible = false;
                                lblEOMode.Visible = true;

                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lblEOMode.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgEOMode1.Visible = false;
                                imgEOMode2.Visible = false;
                                lblEOMode.Visible = false;
                                imgplant1.Visible = false;
                                imgplant2.Visible = false;
                                lblplantname.Visible = false;
                            }

                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }                    
                }
                ViewState["EOMainSingle"] = st.TrimEnd(new char[] { ',' });
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void imgEOMode2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                FillArchivedEOs();
                ViewState["Expand"] = null;
                ViewState["EOMain"] = null;
                dgdArchSelectedEO.Visible = false;
                lblPlantNameVal.Visible = false;
                lblStageVal.Visible = false;
                lblEOTypeVal.Visible = false;


                ImageButton imgEOMode1 = (ImageButton)sender;
                ImageButton imgEOMode2 = (ImageButton)imgEOMode1.Parent.FindControl("imgEOMode2");
                imgEOMode1.Visible = true;
                imgEOMode2.Visible = false;
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgEOMode1.Parent;
                int rowno = gvd.ItemIndex;

                for (int rowCount = rowno + 1; rowCount <= dgdArchivedEOs.VisibleRowCount - 1; rowCount++)
                {

                    Label lblPlantName = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "lblPlantName");
                    Label lblPlantId = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["Plant"], "lblPlantId");
                    Label lblEOMode = (Label)dgdArchSelectedEO.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdArchSelectedEO.Columns["EO Type"], "lblEOMode");

                    //Label lblPlantName = (Label)dgdAppEOTree.Items(rowCount).FindControl("lblPlantName");
                    //Label lblEOMode = (Label)dgdAppEOTree.Items(rowCount).FindControl("lblEOMode");
                    if (lblPlantName != null)
                    {
                        if (string.IsNullOrEmpty(lblPlantName.Text) & string.IsNullOrEmpty(lblEOMode.Text))
                        {
                            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblPlantName.Parent.Parent.Parent;
                            gvdc.Visible = false;
                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }
        protected void imgEOMode1_Command(object sender, CommandEventArgs e)
        {
            FillArchivedEOs();
            ViewState["Expand"] = null;
            ImageButton imgEOMode1 = (ImageButton)sender;
            ImageButton imgEOMode2 = (ImageButton)imgEOMode1.Parent.FindControl("imgEOMode2");
            imgEOMode1.Visible = false;
            imgEOMode2.Visible = true;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgEOMode1.Parent;
            int rowno = gvd.ItemIndex;
            dgdArchSelectedEO.Visible = true;
            lblPlantNameVal.Visible = false;
            lblStageVal.Visible = false;            
            lblEOTypeVal.Visible = false;
            string stage=string.Empty;
            for(int ro=0;ro<rowno;ro++)
            {            
            Label lblstage = (Label)dgdArchivedEOs.FindRowCellTemplateControl(ro, (GridViewDataColumn)dgdArchivedEOs.Columns["Stage"], "lblStage");
            if (lblstage != null)
            {
                if (!string.IsNullOrEmpty(lblstage.Text))
                    stage = lblstage.Text;
            }
            }
            
            
            ViewState["Plant_ID"] = Convert.ToString(e.CommandArgument);
            ViewState["EOMain"] = Convert.ToString(rowno);
            
            
            lblEOTypeVal.Text = Convert.ToString(e.CommandName);
            FillArchivedSelectedEOs(Convert.ToInt32(ViewState["Plant_ID"]), stage, lblEOTypeVal.Text);
            

        }


        protected void dgdArchivedEOs_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillArchivedEOs();
            }
            catch (Exception exc)
            {

            }
        }
    }
}