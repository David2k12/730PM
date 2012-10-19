using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using MUREOPROP;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.Web.ASPxGridView;

namespace MUREOUI.Reports
{
    public partial class EventsbyCategory : System.Web.UI.Page
    {
        DataSet dsMyEvents;
        string strUserName = string.Empty;
        string strScript = string.Empty;
        static int intGlobalProjectTypeID;
        static int intGlobalPlantID;
        static int intGlobalProjectID;
        static string strUserRole = string.Empty;
        EOBA objEOBA = new EOBA();
        clsSecurity objSecurity = new clsSecurity();
        Approver app = new Approver();
        clsEvent objclsEvent = new clsEvent();
        SqlParameter[] paramOut = null;

        protected void Page_Load(Object sender, EventArgs e)
        {
            strUserRole = objSecurity.UserRole();
            if (strUserRole == "MUREO_Admin")
            {
                imgAdjStartDate.Enabled = true;
                imgOpenDataExportPage.Enabled = true;
                btnMigrate.Enabled = true;
                imgMyEvents.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgAdjStartDate.Enabled = true;
                imgOpenDataExportPage.Enabled = true;
                btnMigrate.Enabled = true;
                imgMyEvents.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgAdjStartDate.Enabled = false;
                imgOpenDataExportPage.Enabled = true;
                btnMigrate.Enabled = false;
                imgMyEvents.Enabled = false;
                //Response.Redirect("~/Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgAdjStartDate.Enabled = false;
                imgOpenDataExportPage.Enabled = true;
                btnMigrate.Enabled = false;
                imgMyEvents.Enabled = false;
                //Response.Redirect("~/Common/Home.aspx")
            }
            if (!Page.IsPostBack)
            {
                btnMigrate.Attributes.Add("OnClick", "javascript:return CheckMigrate();");
                imgAdjStartDate.Attributes.Add("onclick", "return NavigateAdjstrtDt()");
                imgOpenDataExportPage.Attributes.Add("onclick", "return NavigateDataExport()");
                btnSearch.Attributes.Add("OnClick", "javascript:return selprojectplant();");
                dgEventDetails.Visible = false;
                FillEventsByProjectType();
                drpProject.Items.Insert(0, "Select Project");
                drpProject.Items[0].Value = "0";
            }
        }
        protected void dgEventDetails_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {               
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    CheckBox chkEvent = (CheckBox)dgEventDetails.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgEventDetails.Columns["Check"], "chkEvent");
                    chkEvent.Attributes.Add("OnClick", "javascript:return CheckChanged(this);");
                }
            }
            catch (Exception exc)
            {
            }
        }
        protected void Linkbutton1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if(e.CommandName!=null)
                Response.Redirect("~/Common/frmViewEvent.aspx?EventID=" + Convert.ToString(e.CommandName));
            }
            catch (Exception exc)
            {
                                
            }
        }
        protected void dgEventDetails_CustomColumnSor(object sender, EventArgs e)
        {
            fillDetails(Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpProject.SelectedValue));
        }
        protected void dgEventDetails_PageIndexChanged(object sender, EventArgs e)
        {
            fillDetails(Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpProject.SelectedValue));
        }
        //protected void dgEventDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{

        //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        CheckBox chkEvent = (CheckBox)e.Item.FindControl("chkEvent");
        //        chkEvent.Attributes.Add("OnClick", "javascript:return CheckChanged(this);");
        //    }
        //}

        //protected void dgEventDetails_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "Event_Name")
        //    {
        //        Response.Redirect("~/Common/frmViewEvent.aspx?EventID=" + Convert.ToString(dgEventDetails.DataKeys[e.Item.ItemIndex]));
        //    }
        //}

        //protected void dgEventDetails_ItemSortCommand(object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        //{
        //    if (Convert.ToString(ViewState["StrSort"]) == " Desc")
        //    {
        //        ViewState["StrSort"] = " Asc";
        //    }
        //    else
        //    {
        //        ViewState["StrSort"] = " Desc";
        //    }
        //    ViewState["SortExp"]= e.SortExpression;
        //    fillDetails(Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpProject.SelectedValue));
        //}


        protected void FillEventsByProjectType()
        {
            try
            {
                DataSet dsPlants = null;
                ReportsBO objEventsByProjectType = new ReportsBO();
                //dsPlants = objEventsByProjectType.GET_MUR_Plant;
                if (app.FillApproverPlantsBO(0, ref dsPlants))
                {
                    if ((dsPlants != null))
                    {
                        if (!(dsPlants.Tables.Count == 0))
                        {
                            if (!(dsPlants.Tables[0].Rows.Count == 0))
                            {
                                drpPlant.DataSource = dsPlants.Tables[0].DefaultView;
                                drpPlant.DataTextField = "Plant_Name";
                                drpPlant.DataValueField = "Plant_ID";
                                drpPlant.DataBind();
                                drpPlant.Items.Insert(0, "Select Plant");
                                drpPlant.Items[0].Value = "0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void drpPlant_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (!(drpPlant.SelectedIndex == 0))
            {
                DataSet dsproj = null;
                ReportsBO objEventsByProjectType = new ReportsBO();
               // dsproj = objEventsByProjectType.GET_MUR_Projects_By_Plant(drpPlant.SelectedValue);
                if (objclsEvent.GET_MUR_Projects_By_Plant(Convert.ToInt32(drpPlant.SelectedValue),ref dsproj))
                if ((dsproj != null))
                {
                    if (!(dsproj.Tables.Count == 0))
                    {
                        if (!(dsproj.Tables[0].Rows.Count == 0))
                        {
                            drpProject.DataSource = dsproj.Tables[0].DefaultView;
                            drpProject.DataTextField = "Project_Name";
                            drpProject.DataValueField = "Project_ID";
                            drpProject.DataBind();
                            drpProject.Items.Insert(0, "Select Project");
                            drpProject.Items[0].Value = "0";
                        }
                    }
                }
            }
            else
            {
                drpProject.Items.Clear();
                drpProject.Items.Insert(0, "Select Project");
                drpProject.Items[0].Value = "0";
            }
            dgEventDetails.Visible = false;
            dgEventDetails.DataSource = null;
            dgEventDetails.DataBind();           
        }

        protected void btnSearch_Click(Object sender, EventArgs e)
        {
            dgEventDetails.DataSource = null;
            dgEventDetails.DataBind();
            fillDetails(Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpProject.SelectedValue));
        }

        protected void imgProjectsbyCategory_Click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/ProjectsByCategory.aspx");
        }

        protected void imgMyEvents_Click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/MyEvents.aspx");
        }

        protected void fillDetails(int plantID, int projID)
        {
            try
            {
                DataSet dsEventDetails = new DataSet();

                dgEventDetails.Visible = true;

                ReportsBO objEventDetails = new ReportsBO();
                //dsEventDetails = objEventDetails.GET_MUR_Events_By_Project_Or_Plant(plantID, projID);
                if (objclsEvent.GET_MUR_Events_By_Project_Or_Plant(plantID, projID, ref dsEventDetails))
                {
                    if (dsEventDetails.Tables[0].Rows.Count > 0)
                    {
                        dgEventDetails.DataSource = dsEventDetails;
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
                        //            if (Convert.ToString(ViewState["StrSort"]) == " Asc")
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
                    }
                }
                else
                {
                    NoDataForGrid();
                    dgEventDetails.DataSource = null;
                    dgEventDetails.DataBind();
                }
                //Following code is for enabling and disabling the links on the form based on the user roles.
                if (strUserRole.ToUpper() == "MUREO_Admin".ToUpper())
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole.ToUpper() == "MUREO_Editors".ToUpper())
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole.ToUpper() == "MUREO_Readers".ToUpper())
                {
                    EnableDisableLinks(true);
                }
                else if (strUserRole.ToUpper() == "Readers".ToUpper())
                {
                    EnableDisableLinks(true);
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

        protected void NoDataForGrid()
        {
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRec"] + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }


        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgEventDetails.VisibleRowCount - 1; numRows++)
            {
                //LinkButton lnkEventName = default(LinkButton);
                //lnkEventName = (LinkButton)dgEventDetails.Items[numRows].FindControl("Linkbutton1");
                LinkButton lnkEventName = (LinkButton)dgEventDetails.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgEventDetails.Columns["Event"], "Linkbutton1");
                if (lnkEventName != null && (!optBool))
                    lnkEventName.Enabled = optBool;                
            }
        }

        protected void btnMigrate_Click(Object sender, EventArgs e)
        {
            string eventID = null;
            string strSelEventname = "";
            //selected first event name
            for (int i = 0; i <= dgEventDetails.VisibleRowCount - 1; i++)
            {
                //CheckBox chkEvent = (CheckBox)dgEventDetails.Items[i].FindControl("chkEvent");
                CheckBox chkEvent = (CheckBox)dgEventDetails.FindRowCellTemplateControl(i, (GridViewDataColumn)dgEventDetails.Columns["Check"], "chkEvent");
                if (chkEvent != null)
                {
                    if (chkEvent.Checked)
                    {
                        if (string.IsNullOrEmpty(eventID))
                        {
                            eventID = chkEvent.Attributes["EventID"];
                            strSelEventname = chkEvent.Attributes["Event_Name"];
                        }
                        else
                        {
                            eventID = eventID + "," + chkEvent.Attributes["EventID"];
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(eventID))
            {
                string script="alert('Please select atleast one Event to migrate');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            else
            {
                DataSet dsSeedDataByEventID = null;
                //dsSeedDataByEventID = ClsEO.GETEOSeedDataByEventIDs(eventID);
             
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
                objEO.EOSiteTestOther = "E";
                objEO.ProjectID = 0;
                objEO.PlantID = 0;
                objEO.CategoryID = 0;
                objEO.Originator = objSecurity.UserName;
                objEO.PhoneNumber = DBNull.Value.ToString();
                try
                {
                    objEO.OfficeNumber = objSecurity.getUserTelephoneNumber(objSecurity.UserName);
                }
                catch (Exception ex)
                {
                    objEO.OfficeNumber = DBNull.Value.ToString();
                }

                objEO.Brands = "";
                objEO.CoOrginator = DBNull.Value.ToString();

                objEO.CommsntsToApprover = "";
                if (objEOBA.GETEOSeedDataByEventIDs(eventID, ref dsSeedDataByEventID))
                {

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
                                        objEO.Brands = dsSeedDataByEventID.Tables[0].Rows[0]["BRAND_SEGMENT_ID"].ToString();
                                        objEO.ProjectID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["PROJECT_ID"]);
                                        //PROJECT_ID()
                                        objEO.PlantID = Convert.ToInt32(dsSeedDataByEventID.Tables[0].Rows[0]["PLANT_ID"]);
                                        //PLANT_ID()
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
                }
                try
                {
                    //Eo_ID = ClsEO.SetEOMandatory(objEO);
                    if (objEOBA.SetEOMandatory(objEO, ref paramOut))
                    {
                        Eo_ID = Convert.ToInt32(paramOut[0].Value);
                    }
                    //Int16 i = ClsEO.SetEOEvenMerge(Eo_ID);
                    objEOBA.SetEOEvenMerge(Eo_ID);
                    Response.Redirect("~/Common/NewEO.aspx?From=ForEOEdit&EoID=" + Eo_ID + "&Mig=YES");
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Common/NewEO.aspx?From=ForEOEdit&EoID=" + Eo_ID + "&Mig=YES");
                }
            }

        }

    }
}