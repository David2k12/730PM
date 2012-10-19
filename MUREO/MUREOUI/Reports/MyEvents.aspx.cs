#region "Imports"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOUI.Common;
using MUREOPROP;
using MUREOBAL;
using System.Data.SqlClient;
using DevExpress.Web.ASPxGridView;
#endregion

namespace MUREOUI
{
    public partial class MyEvents : System.Web.UI.Page
    {

        #region "Declarations"
        DataSet dsMyEvents;
        string strUserName;
        string strScript;
        static int intGlobalProjectTypeID;
        static int intGlobalPlantID;
        static int intGlobalProjectID;
        static string strUserRole;
        clsSecurity objSecurity = new clsSecurity();
        #endregion
        
        #region "Events"
        private void Page_Load(Object sender, EventArgs e)
        {
          
            strUserRole = objSecurity.UserRole();
            if (strUserRole == "MUREO_Admin")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = true;
                btnMigrate.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = true;
                btnMigrate.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = false;
                btnMigrate.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgOpenDataExportPage.Enabled = true;
                imgAdjStartDate.Enabled = false;
                btnMigrate.Enabled = false;
                //Response.Redirect("../Common/Home.aspx")
            }

            if (!Page.IsPostBack)
            {
                imgDeleteEvents.Attributes.Add("onClick", "javascript:return confirmDelete();");
                imgAdjStartDate.Attributes.Add("onClick", "NavigateAdjstrtDt()");
                btnMigrate.Attributes.Add("OnClick", "javascript:return CheckMigrate();");
                imgOpenDataExportPage.Attributes.Add("onclick", "NavigateDataExport()");
                //PageButtonVisibility(false);
                //FillMyEvents()
                fillDetails();
            }

        }

        protected void Linkbutton1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName != null)
                {
                    Response.Redirect("~/Common/frmViewEvent.aspx?EventID=" + Convert.ToString(e.CommandName));
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgDeleteEvents_Click(Object sender, EventArgs e)
        {
            try
            {
                string eventID = null;
                for (int i = 0; i <= dgEventDetails.VisibleRowCount - 1; i++)
                {
                    CheckBox chkEvent = (CheckBox)dgEventDetails.FindRowCellTemplateControl(i, (GridViewDataColumn)dgEventDetails.Columns["Check"], "chkEvent");
                    //CheckBox chkEvent = (CheckBox)dgEventDetails.Items(i).FindControl("chkEvent");
                    if (chkEvent != null)
                    {
                        if (chkEvent.Checked == true)
                        {
                            if (string.IsNullOrEmpty(eventID))
                            {
                                eventID = chkEvent.Attributes["EventID"].ToString();
                            }
                            else
                            {
                                eventID = eventID + "," + chkEvent.Attributes["EventID"].ToString();
                            }
                        }
                    }
                }
                if (string.IsNullOrEmpty(eventID))
                {
                    string script = null;
                    script = "alert('Please select Event(s)');";
                   ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;

                }
                else
                {
                    int intResult = 0;
                    EOBA objEOBA = new EOBA();
                    SqlParameter[] paramOut = null;
                    clsSecurity clsuser = new clsSecurity();
                    //p_Event_IDs, string strUserName, ref SqlParameter[] paramOut
                    objEOBA.SET_MUR_Delete_Multiple_Events(eventID, clsuser.UserName, ref paramOut);
                    intResult = Convert.ToInt32(paramOut[0].Value);
                    if (intResult == 0)
                    {
                        string script = null;
                        script = "alert('Selected Event(s) deleted successfully'); window.location='../Common/Home.aspx';";
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        dgEventDetails.DataSource = null;
                        dgEventDetails.DataBind();
                        fillDetails();
                    }
                    else
                    {
                        string script = null;
                        script = "alert('Deletion failed');";
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void btnMigrate_Click(Object sender, EventArgs e)
        {
            string eventID = string.Empty;
            bool tempFlag = false;
            bool categoryFlag = false;
            bool brandsegmentFlag = false;
            string tempBrandSegment = "";
            string tempCategory = "";
            string tempPlant = "";
            string strSelEventname = "";
            //selected first event name
            string strBrandsegmentID = null;
            EOBA objEOBA = new EOBA();
            for (int i = 0; i <= dgEventDetails.VisibleRowCount - 1; i++)
            {
                CheckBox chkEvent = (CheckBox)dgEventDetails.FindRowCellTemplateControl(i, (GridViewDataColumn)dgEventDetails.Columns["Check"], "chkEvent");
                //CheckBox chkEvent = (CheckBox)dgEventDetails.FindDetailRowTemplateControl(i, "chkEvent");
                if (chkEvent != null)
                {
                    if (chkEvent.Checked)
                    {
                        if (string.IsNullOrEmpty(eventID))
                        {
                            eventID = chkEvent.Attributes["EventID"].ToString();
                            //Convert.ToString(dgEventDetails.GetRowValues(i, "Event_ID"));
                            strSelEventname = chkEvent.Attributes["Event_Name"].ToString();

                            //tempFlag = True
                            tempPlant = chkEvent.Attributes["Plant_Name"].ToString();
                            //Checking for category code added by abdul on 26/01/2008

                            tempCategory = chkEvent.Attributes["Category_Name"].ToString();



                            //tempFlag = True
                            tempBrandSegment = chkEvent.Attributes["Brand_Segment_name"].ToString();

                        }
                        else
                        {
                            if (chkEvent.Attributes["Plant_Name"].ToString() != tempPlant)
                            {
                                tempFlag = true;

                            }
                            else
                            {
                                tempPlant = chkEvent.Attributes["Plant_Name"].ToString();
                            }
                            //'Checking for category code added by abdul on 26/01/2008
                            if (chkEvent.Attributes["Category_Name"].ToString() != tempCategory)
                            {
                                categoryFlag = true;
                            }
                            else
                            {
                                tempCategory = chkEvent.Attributes["Category_Name"].ToString();
                            }

                            //'Checking for brand segment
                            if (chkEvent.Attributes["Brand_Segment_name"].ToString() != tempBrandSegment)
                            {
                                brandsegmentFlag = true;
                            }
                            else
                            {
                                tempBrandSegment = chkEvent.Attributes["Brand_Segment_name"].ToString();
                            }
                            eventID = eventID + "," + chkEvent.Attributes["EventID"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(eventID))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "alert('Please select atleast one Event to migrate');", true);                
            }
            else
            {

                if (brandsegmentFlag == false)
                {

                    if (categoryFlag == false)
                    {
                        if (tempFlag == false)
                        {
                            //Response.Redirect("..\Common\NewEO.aspx?From=EOReports&EventIDs=" & eventID)

                            //jagan start 09/01/2008
                            DataSet dsSeedDataByEventID = new DataSet();
                            objEOBA.GETEOSeedDataByEventIDs(eventID, ref dsSeedDataByEventID);


                            //getting first 15 characters for creating EO name
                            try
                            {
                                if (strSelEventname.Length > 15)
                                {
                                    strSelEventname = strSelEventname.Substring(0, 15);
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            int Eo_ID = 0;
                            objEO objEO = new objEO();

                            objEO.TwoTabRoute = "N";
                            objEO.EOID = "0";
                            objEO.FinalCurrentStagePre = "Preliminary";
                            objEO.FinalStageStatus = "Draft";

                            //objEO.Title = strSelEventname
                            if (!string.IsNullOrEmpty(strSelEventname.Trim()))
                            {
                                objEO.Title = strSelEventname;
                            }
                            else
                            {
                                objEO.Title = "NewEO" + System.DateTime.Now;
                                //DBNull.Value.ToString
                            }

                            if (!string.IsNullOrEmpty(eventID))
                            {
                                objEO.EventIDs = eventID;
                            }
                            else
                            {
                                objEO.EventIDs = DBNull.Value.ToString();
                            }
                            clsSecurity clsuser = new clsSecurity();
                            objEO.ProjectID = 0;
                            objEO.PlantID = 0;
                            objEO.CategoryID = 0;
                            objEO.Originator = clsuser.UserName;
                            objEO.OfficeNumber = DBNull.Value.ToString();
                            try
                            {

                                objEO.PhoneNumber = objSecurity.getUserTelephoneNumber(clsuser.UserName);
                            }
                            catch (Exception ex)
                            {
                                objEO.PhoneNumber = DBNull.Value.ToString();
                            }

                            objEO.Brands = "";
                            objEO.CoOrginator = DBNull.Value.ToString();

                            objEO.CommsntsToApprover = "";
                            objEO.EOSiteTestOther = "E";


                            try
                            {
                                if ((dsSeedDataByEventID != null))
                                {
                                    if (!(dsSeedDataByEventID.Tables.Count == 0))
                                    {
                                        if (!(dsSeedDataByEventID.Tables[0].Rows.Count == 0))
                                        {
                                            try
                                            {
                                                objEO.CategoryID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["CATEGORY_ID"]);
                                                //Commented by abdul
                                                //objEO.Brands = dsSeedDataByEventID.Tables(0).Rows(0).Item("BRAND_SEGMENT_ID")
                                                objEO.ProjectID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["PROJECT_ID"]);
                                                //PROJECT_ID()
                                                objEO.PlantID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["PLANT_ID"]);
                                                //PLANT_ID()
                                                //added by abdul for getting multiple brand ids
                                                for (int intBrandLoop = 0; intBrandLoop <= dsSeedDataByEventID.Tables[0].Rows.Count - 1; intBrandLoop++)
                                                {
                                                    if (string.IsNullOrEmpty(strBrandsegmentID))
                                                    {
                                                        strBrandsegmentID = Convert.ToString(dsSeedDataByEventID.Tables[0].Rows[intBrandLoop]["BRAND_SEGMENT_ID"]);
                                                    }
                                                    else
                                                    {
                                                        strBrandsegmentID = strBrandsegmentID + "," + dsSeedDataByEventID.Tables[0].Rows[intBrandLoop]["BRAND_SEGMENT_ID"];
                                                    }
                                                }
                                                objEO.Brands = strBrandsegmentID;
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {
                                SqlParameter[] paramOut = new SqlParameter[2];

                                if (objEOBA.SetEOMandatory(objEO, ref paramOut))
                                {
                                    Eo_ID = Convert.ToInt32(paramOut[0].Value);
                                }

                                objEOBA.SetEOEvenMerge(Eo_ID);
                                Response.Redirect("../Common/NewEO.aspx?From=ForEOEdit&EoID=" + Eo_ID + "&Mig=YES");

                            }
                            catch (Exception ex)
                            {
                                //Response.Redirect("..\Common\NewEO.aspx?From=EOReports&EventIDs=" & eventID)
                                Response.Redirect("../Common/NewEO.aspx?From=ForEOEdit&EoID=" + Eo_ID + "&Mig=YES");


                            }
                            //@p_EO_ID = 0, @p_EO_Title = 'zcasdad', @p_Event_ID_List = '958', @p_Project_ID = 6, @p_Plant_ID = 1, @p_Category_ID = 1, @p_Originator = 'srinivasachary.n', @p_Office_Num = NULL, @p_Phone_Num = NULL, @p_Brand_Seg_ID_List = '1', @p_CoOriginator = NULL, @p_Comments_To_Approver = NULL, @p_Current_Stage = 'Preliminary', @p_Stage_Status  = 'Draft', @p_New_EO_ID = @P1 output, @p_EO_Mode = 'E', @p_Two_Tab_Routing = 'N', @p_Result_No = @P2

                            //jagan END 09/01/2008

                        }
                        else
                        {
                            string script = null;
                            script = "alert('Please select Events of same site'); ";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                    }
                    else
                    {
                        string script = null;
                        script = "alert('Please select Events of same categories'); ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
                else
                {
                    string script = null;
                    script = "alert('Please select Events of same brand segment'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
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
        protected void dgEventDetails_PageIndexChanged(object sender, EventArgs e)
        {
            fillDetails();
        }

        public void PagerButtonClick(object sender, CommandEventArgs e)
        {
            try
            {
                string arg = Convert.ToString(e.CommandArgument);
                switch (arg)
                {
                    case "Next":

                        if ((dgEventDetails.PageIndex < (dgEventDetails.VisibleRowCount - 1)))
                        {
                            dgEventDetails.PageIndex += 1;
                        }
                        if ((dgEventDetails.PageIndex == (dgEventDetails.VisibleRowCount - 1)))
                        {
                            //Dim jvScript As String
                            //jvScript = "alert('" & ConfigurationSettings.AppSettings("DataGridLastPage") & "');"
                            //Page.RegisterStartupScript("ClientScript", jvScript)
                            //imgNext.Enabled = false;
                            //imgPrevious.Enabled = true;

                        }
                        else if ((dgEventDetails.PageIndex >= 0) & (dgEventDetails.PageIndex < (dgEventDetails.VisibleRowCount - 1)))
                        {
                            //imgNext.Enabled = true;
                            //imgPrevious.Enabled = true;
                        }
                        break;
                    case "Prev":

                        if ((dgEventDetails.PageIndex > 0))
                        {
                            dgEventDetails.PageIndex -= 1;
                        }
                        if ((dgEventDetails.PageIndex == 0))
                        {
                            //Dim jvScript As String
                            //jvScript = "alert('" & ConfigurationSettings.AppSettings("DataGridFirstPage") & "');"
                            //Page.RegisterStartupScript("ClientScript", jvScript)
                            //imgPrevious.Enabled = false;
                            //imgNext.Enabled = true;
                        }
                        else if (dgEventDetails.PageIndex > 0 & (dgEventDetails.PageIndex < (dgEventDetails.VisibleRowCount - 1)))
                        {
                            //imgPrevious.Enabled = true;
                            //imgNext.Enabled = true;
                        }
                        break;
                    //Case "Last"
                    //dgdMyEO.CurrentPageIndex = (dgdMyEO.PageCount - 1)
                    //Case Else
                    //dgdMyEO.CurrentPageIndex = Convert.ToInt32(arg)
                }
                fillDetails();
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void dgEventDetails_CustomColumnSor(object sender, EventArgs e)
        {
            fillDetails();
        }
        //  ************************************************
        //Name   	    :	imgProjectsbyCategory_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Navigating to ProjectsByCategory Report
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void imgProjectsbyCategory_Click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/ProjectsByCategory.aspx");
        }
        //
        //  ************************************************
        //Name   	    :	imgEventsbyCategory_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Navigating to EventsbyCategory Report
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void imgEventsbyCategory_Click(Object sender,EventArgs e)
        {
            Response.Redirect("~/Reports/EventsbyCategory.aspx");
        }

        #endregion

        #region "Methods"
        //public void PageButtonVisibility(bool optVisible)
        //{
        //    imgPrevious.Visible = optVisible;
        //    imgNext.Visible = optVisible;
        //}

        protected void fillDetails()
        {
            try
            {
                clsSecurity objUserName = new clsSecurity();

                strUserName = objUserName.UserName;

                DataSet dsEventDetails = new DataSet();
                dgEventDetails.Visible = true;

                ReportsBO objEventDetails = new ReportsBO();
                if (!objEventDetails.FillMyEventDetailseBO(strUserName, ref dsEventDetails)) ;
                //dsEventDetails = objEventDetails.FillMyEventDetailseBO("Surendra Bolla-su")


                if (dsEventDetails == null)
                {
                    NoRecords();

                }
                else if (dsEventDetails.Tables[0].Rows.Count == 0)
                {
                    NoRecords();

                }
                else
                {
                    for (int index = 0; index <= dsEventDetails.Tables[0].Rows.Count - 1; index++)
                    {
                        dsEventDetails.Tables[0].Rows[index]["Machine_IDs"] = Convert.ToString(dsEventDetails.Tables[0].Rows[index]["Machine_IDs"]).Replace("--,", "");
                        dsEventDetails.Tables[0].Rows[index]["Machine_IDs"] = Convert.ToString(dsEventDetails.Tables[0].Rows[index]["Machine_IDs"]).Replace(",--", "");
                        dsEventDetails.Tables[0].Rows[index]["Machine_Names"] = Convert.ToString(dsEventDetails.Tables[0].Rows[index]["Machine_Names"]).Replace("--,", "");
                        dsEventDetails.Tables[0].Rows[index]["Machine_Names"] = Convert.ToString(dsEventDetails.Tables[0].Rows[index]["Machine_Names"]).Replace(",--", "");
                    }



                    if (dsEventDetails.Tables[0].Rows.Count > 0)
                    {
                        dgEventDetails.DataSource = dsEventDetails.Tables[0];
                        //if (((dsEventDetails.Tables[0].Rows.Count) <= dgEventDetails.PageCount))
                        //{
                        //    //PageButtonVisibility(false);
                        //    //If dgdArchSelectedEO.CurrentPageIndex <> 0 Then
                        //    //dgdArchSelectedEO.CurrentPageIndex -= 1
                        //    //End If
                        //}
                        //else
                        //{
                        //    //PageButtonVisibility(true);
                        //}
                        //dgEventDetails.DataSource = dsEventDetails.Tables[0];
                        //Code added by Vijay on 09/26/2007
                        //if ((ViewState["SortExp"] != null))
                        //{
                        //    string SortExp = null;
                        //    string strSort = null;
                        //    DataView dv = new DataView(dsEventDetails.Tables[0]);
                        //    //Create a data view for the sort
                        //    string imgAsc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                        //    string imgDesc = string.Concat("&nbsp;", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                        //    SortExp = ViewState["SortExp"].ToString();
                        //    strSort = SortExp + ViewState["StrSort"].ToString();
                        //    dv.Sort = strSort;
                        //    dgEventDetails.DataSource = dv;
                        //    foreach (DataGridColumn col in dgEventDetails.Columns)
                        //    {
                        //        string header_text = col.HeaderText;
                        //        int position = col.HeaderText.IndexOf("&nbsp;");
                        //        if (col.SortExpression == SortExp)
                        //        {
                        //            if (position > -1)
                        //            {
                        //                header_text = col.HeaderText.Substring(0, position);
                        //            }
                        //            if (ViewState["StrSort"].ToString() == " Asc")
                        //            {
                        //                col.HeaderText = string.Concat(header_text, imgAsc);
                        //            }
                        //            else
                        //            {
                        //                col.HeaderText = string.Concat(header_text, imgDesc);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            if (position > -1)
                        //            {
                        //                header_text = col.HeaderText.Substring(0, position);
                        //                col.HeaderText = header_text;
                        //            }
                        //        }
                        //    }
                        //}



                        dgEventDetails.DataBind();               
                        //dgEventDetails.SortBy(dgEventDetails.Columns["Modified_Datee"], DevExpress.Data.ColumnSortOrder.Descending);
                        //If dsEventDetails.Tables(0).Rows.Count > dgdgEventDetails.PageCount Then
                        //    dgEventDetails.PagerStyle.Visible = True
                        //End If

                    }
                    else
                    {
                        dgEventDetails.DataSource = null;
                        dgEventDetails.DataBind();
                        NoRecords();
                        //PageButtonVisibility(false);
                    }
                }


                //Following code is for enabling and disabling the links on the form based on the user roles.
                if (strUserRole == "MUREO_Admin")
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole == "MUREO_Editors")
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole == "MUREO_Readers")
                {
                    EnableDisableLinks(false);
                }
                else if (strUserRole == "Readers")
                {
                    EnableDisableLinks(false);
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + ex.Message + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        //
        //  ************************************************
        //Name   	    :	NoRecords
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Displaying alert message when no results found
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath            1.0           created
        //***************************************************
        //
        private void NoRecords()
        {
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRec"].ToString() + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
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
        //09/26/07                Md.Abdul allaam             1.0           created
        //***************************************************
        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgEventDetails.VisibleRowCount - 1; numRows++)
            {

                LinkButton lnkEventName = (LinkButton)dgEventDetails.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgEventDetails.Columns["Event"], "Linkbutton1");
                if (lnkEventName != null)
                    lnkEventName.Enabled = optBool;
            }

            //for(int i = 0;i < ASPxGridView1.VisibleRowCount;i++) {
            //       string qty = ((TextBox)ASPxGridView1.FindRowCellTemplateControl(i,(GridViewDataColumn)ASPxGridView1.Columns["Event"], "txtQty")).Text;
        }
        #endregion
    }
}