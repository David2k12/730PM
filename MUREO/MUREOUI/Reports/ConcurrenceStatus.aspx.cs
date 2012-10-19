using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;
using System.Data;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using System.Collections;
using MUREOBAL;

namespace MUREOUI.Reports
{
    public partial class ConcurrenceStatus : System.Web.UI.Page
    {
        clsSecurity objSecurity = null;
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            objSecurity = new clsSecurity();
            // Declare new security object
            string user_role = objSecurity.UserRole();
            // Get the current user role
            //If admin then show 'Create EO' button else make it invisible
            if (user_role == "MUREO_Admin")
            {
                imgCreateEO.Visible = true;
            }
            else
            {
                imgCreateEO.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                imgGotoEO.Attributes.Add("onclick", "NavigateSpecificEO();");
                imgExport.Attributes.Add("onclick", "NavigateEOExport()");
                //Add javascript attribute to the 'open data export' button
                bar.Visible = false;
                dgdEODetails.Visible = false;
                lblEOdisp.Visible = false;
                lbEOID.Visible = false;
                FillConcStatus();
                //Fill the concurrence status tree view details
            }

        }

        private void FillConcStatus()
        {
            DataSet dsConcStatus = null;
            clsConcurrenceBO objclsConcurrenceBO = null;
            try
            {
                //dsConcStatus = ConcurrenceBO.GetConcurrenceStatusTreeViewBO();

                dsConcStatus = new DataSet();
                objclsConcurrenceBO = new clsConcurrenceBO();
                if (objclsConcurrenceBO.GetConcurrenceStatusTreeViewBO(ref dsConcStatus))
                {

                    //Get the concurrence data from the db
                    //If nothing, quit
                    if (dsConcStatus == null)
                    {
                        NoRecords();
                        //If no tables, quit
                    }
                    else if (dsConcStatus.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsConcStatus.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        //Now we got data
                    }
                    else
                    {
                        bar.Visible = true;
                        DataTable dtConcStatus = new DataTable();
                        DataRow drConcStatus = null;

                        ArrayList arrayStatus = new ArrayList();
                        ArrayList arrayEOID = new ArrayList();
                        ArrayList arrayEOTitle = new ArrayList();

                        dtConcStatus.Columns.Add("Status");
                        dtConcStatus.Columns.Add("EO_ID");
                        dtConcStatus.Columns.Add("EO");

                        //dtConcStatus.Columns.Add("EO_Number")
                        //dtConcStatus.Columns.Add("EO_Title")

                        string strStatus = Convert.ToString(dsConcStatus.Tables[0].Rows[0]["Status"]);
                        string strEOID = Convert.ToString(dsConcStatus.Tables[0].Rows[0]["EO_ID"]);

                        arrayStatus.Add(strStatus);

                        for (int rowCount = 0; rowCount <= dsConcStatus.Tables[0].Rows.Count - 1; rowCount++)
                        {
                            string strStatus1 = Convert.ToString(dsConcStatus.Tables[0].Rows[rowCount]["Status"]);
                            if (!(arrayStatus.Contains(strStatus1)))
                            {
                                arrayStatus.Add(strStatus1);
                            }
                        }
                        for (int rowStatusCount = 0; rowStatusCount <= arrayStatus.Count - 1; rowStatusCount++)
                        {
                            drConcStatus = dtConcStatus.NewRow();
                            drConcStatus["Status"] = arrayStatus[rowStatusCount];
                            drConcStatus["EO_ID"] = "";
                            drConcStatus["EO"] = "";
                            dtConcStatus.Rows.Add(drConcStatus);

                            ArrayList arrayEO = new ArrayList();
                            ArrayList arrayEOID1 = new ArrayList();
                            string strEOID1 = null;


                            for (int rowEOCount = 0; rowEOCount <= dsConcStatus.Tables[0].Rows.Count - 1; rowEOCount++)
                            {

                                if (Convert.ToString(arrayStatus[rowStatusCount]).Trim().ToUpper() == Convert.ToString(dsConcStatus.Tables[0].Rows[rowEOCount]["Status"]).Trim().ToUpper())
                                {
                                    string strEO = dsConcStatus.Tables[0].Rows[rowEOCount]["EO_Number"] + "- " + dsConcStatus.Tables[0].Rows[rowEOCount]["EO_Title"];

                                    strEOID1 = Convert.ToString(dsConcStatus.Tables[0].Rows[rowEOCount]["EO_ID"]);

                                    if (arrayEO.Count == 0)
                                    {
                                        arrayEO.Add(strEO);
                                        arrayEOID1.Add(strEOID1);
                                    }

                                    if (!arrayEO.Contains(strEO))
                                    {
                                        arrayEO.Add(strEO);
                                        arrayEOID1.Add(strEOID1);
                                    }
                                }
                            }

                            for (int rowEO1 = 0; rowEO1 <= arrayEO.Count - 1; rowEO1++)
                            {
                                drConcStatus = dtConcStatus.NewRow();
                                drConcStatus["EO_ID"] = arrayEOID1[rowEO1];
                                drConcStatus["EO"] = arrayEO[rowEO1];
                                dtConcStatus.Rows.Add(drConcStatus);
                            }
                        }
                        dgdStatus.DataSource = dtConcStatus;
                        dgdStatus.DataBind();

                        //Adding Plant name to array` 
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsConcurrenceBO = null;
                dsConcStatus = null;
            }
        }

        private void FillEODetails(int EO_ID)
        {
            DataSet dsEODetails = null;
            clsConcurrenceBO objclsConcurrenceBO = null;

            try
            {
                dsEODetails = new DataSet();
                objclsConcurrenceBO = new clsConcurrenceBO();
                //dsEODetails = ConcurrenceBO.GetConcurrenceStatusTreeViewDetailsBO(EO_ID);
                if (objclsConcurrenceBO.GetConcurrenceStatusTreeViewDetailsBO(EO_ID, ref dsEODetails))
                {
                    if (dsEODetails == null)
                    {
                        NoRecords();
                        dgdEODetails.DataSource = null;
                        dgdEODetails.Visible = false;
                    }
                    else if (dsEODetails.Tables.Count == 0)
                    {
                        NoRecords();
                        dgdEODetails.DataSource = null;
                        dgdEODetails.Visible = false;
                    }
                    else if (dsEODetails.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        dgdEODetails.DataSource = null;
                        dgdEODetails.Visible = false;
                    }
                    else
                    {
                        dgdEODetails.DataSource = dsEODetails;

                        if ((ViewState["SortExp"] != null))
                        {
                            string SortExp = null;
                            string strSort = null;
                            DataView dv = new DataView(dsEODetails.Tables[0]);
                            //Create a data view for the sort
                            string imgAsc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-asc.gif", ">");
                            string imgDesc = string.Concat(" ", "<img border=0 src=", Request.ApplicationPath, "/images/sort-desc.gif", ">");
                            SortExp = ViewState["SortExp"].ToString();
                            strSort = SortExp + ViewState["StrSort"];
                            dv.Sort = strSort;
                            dgdEODetails.DataSource = dv;
                            foreach (DataGridColumn col in dgdEODetails.Columns)
                            {
                                string header_text = col.HeaderText;
                                int position = col.HeaderText.IndexOf(" ");
                                if (col.SortExpression == SortExp)
                                {
                                    if (position > -1)
                                    {
                                        header_text = col.HeaderText.Substring(0, position);
                                    }
                                    if (ViewState["StrSort"] == "Asc")
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
                        }
                        dgdEODetails.DataBind();
                        dgdEODetails.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsConcurrenceBO = null;
                dsEODetails = null;
            }
        }
        private void SetEODetailView(string EO_ID)
        {
            //for (int rowCount = 0; rowCount <= dgdStatus.Items.Count - 1; rowCount++)
            //for (int rowCount = 0; rowCount <= dgdStatus.VisibleColumns; rowCount++)
            for (int rowCount = 0; rowCount <= dgdStatus.VisibleRowCount - 1; rowCount++)
            {
                //Label lblEOID = (Label)dgdStatus.Items(rowCount).FindControl("lblEOID");
                //lbEOID.Text = lblEOID.Text;
                Label lblEOID = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblEOID");
                //Label lblStatus = (Label)dgdStatus.Items(rowCount).FindControl("lblStatus");
                Label lblStatus = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");
                //LinkButton lnkEO = (LinkButton)dgdStatus.Items(rowCount).FindControl("lnkEO");

                LinkButton lnkEO = (LinkButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "lnkEO");
                //ImageButton imgEO1 = (ImageButton)dgdStatus.Items(rowCount).FindControl("imgEO1");
                ImageButton imgE1 = (ImageButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO1");
                //ImageButton imgEO2 = (ImageButton)dgdStatus.Items(rowCount).FindControl("imgEO2");
                ImageButton imgE2 = (ImageButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO2");
                if (lblEOID.Text != EO_ID & !string.IsNullOrEmpty(lblEOID.Text))
                {
                    imgE1.Visible = true;
                    imgE2.Visible = false;
                }
            }
        }

        protected void imgCreateEO_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/NewEO.aspx");
        }

        protected void imgCollapseAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "CollapseMode";
            FillConcStatus();
            lblEOdisp.Visible = false;
            lbEOID.Visible = false;
        }

        protected void imgExpandAll_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["Expand"] = "ExpandMode";           
            FillConcStatus();
            lblEOdisp.Visible = false;
            lbEOID.Visible = false;
        }

        private void NoRecords()
        {
            //string script = null;
            //script = "<script>alert('" + ConfigurationSettings.AppSettings("NoRecords") + "');</script> ";
            //Page.RegisterStartupScript("error_message", script);
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "No Records", strScript);
        }

        protected void dgdStatus_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                objSecurity = new clsSecurity();
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    Label lblStatus = (Label)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");
                    Label lblEoID = (Label)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblEOID");
                    LinkButton lnkEo = (LinkButton)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "lnkEO");
                    ImageButton imgEo1 = (ImageButton)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO1");
                    ImageButton imgEo2 = (ImageButton)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO2");
                    ImageButton imgStatusExpand = (ImageButton)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["Status"], "imgStatusExpand");
                    ImageButton imgStatusCollapse = (ImageButton)dgdStatus.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdStatus.Columns["Status"], "imgStatusCollapse");
                    if (ViewState["Expand"] != null)
                    {
                        if (!(Convert.ToString(ViewState["Expand"]) == "ExpandMode"))
                        {

                            dgdEODetails.Visible = false;
                            lblEOdisp.Visible = false;

                            imgStatusCollapse.Visible = false;
                            lblEoID.Visible = false;
                            imgStatusExpand.Visible = true;
                            imgEo1.Visible = false;
                            lblStatus.Visible = true;
                            imgEo2.Visible = false;
                            lnkEo.Visible = false;

                            if (string.IsNullOrEmpty(lblStatus.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                //e.Row.Visible = false;
                                imgStatusExpand.Visible = false;
                                imgStatusCollapse.Visible = false;
                                lblStatus.Visible = false;
                                imgEo2.Visible = false;
                                imgEo1.Visible = false;
                                lnkEo.Visible = false;
                            }

                        }
                        else
                        {
                            if (dgdEODetails.Visible)
                            {
                                lblEOdisp.Visible = true;
                                lbEOID.Visible = true;
                            }

                            imgStatusCollapse.Visible = true;
                            imgStatusExpand.Visible = false;
                            lnkEo.Visible = false;
                            lblEoID.Visible = false;
                            lblStatus.Visible = true;
                            imgEo1.Visible = false;
                            imgEo2.Visible = false;
                            if (string.IsNullOrEmpty(lblStatus.Text))
                            {
                                imgStatusExpand.Visible = false;
                                imgStatusCollapse.Visible = false;
                                lblStatus.Visible = false;                              
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                imgEo1.Visible = true;
                                imgEo2.Visible = false;
                                lnkEo.Visible = true;
                            }
                            if (string.IsNullOrEmpty(lblStatus.Text) && string.IsNullOrEmpty(lnkEo.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                            }
                            if (string.IsNullOrEmpty(lnkEo.Text))
                            {
                                imgEo1.Visible = false;
                                imgEo2.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        if (ViewState["Single"] == null)
                        {
                            imgStatusCollapse.Visible = false;
                            imgStatusExpand.Visible = true;
                            lblStatus.Visible = true;
                            imgEo1.Visible = false;
                            imgEo2.Visible = false;
                            lnkEo.Visible = false;
                            if (string.IsNullOrEmpty(lblStatus.Text) && string.IsNullOrEmpty(lnkEo.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                            }
                            if (string.IsNullOrEmpty(lblStatus.Text))
                            {
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "hiddencol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "hiddencol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "hiddencol";
                                }
                                imgEo1.Visible = false;
                                imgEo2.Visible = false;
                                
                                imgStatusCollapse.Visible = false;
                                imgStatusExpand.Visible = false;
                                lnkEo.Visible = false;
                            }
                        }
                        else if (objSecurity.IsExists(Convert.ToString(ViewState["SingleMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblStatus.Visible = true;
                            imgStatusCollapse.Visible = true;
                            imgStatusExpand.Visible = false;
                            imgEo1.Visible = false;
                            imgEo2.Visible = false;
                            lnkEo.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
                                if (e.Row != null)
                                    e.Row.CssClass = "viscol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                            }
                        }
                        else if (objSecurity.IsExists(Convert.ToString(ViewState["Single"]), Convert.ToString(e.VisibleIndex)))
                        {
                            //lblEOdisp.Visible = false;
                            //lbEOID.Visible = false;
                            imgStatusCollapse.Visible = false;
                            imgStatusExpand.Visible = false;
                            lblStatus.Visible = false;
                            imgEo1.Visible = false;
                            imgEo2.Visible = false;
                            lnkEo.Visible = false;
                            if (string.IsNullOrEmpty(lblStatus.Text) && (!string.IsNullOrEmpty(lnkEo.Text)))
                            {
                                imgEo1.Visible = true;
                                imgEo2.Visible = false;
                                imgStatusCollapse.Visible = false;
                                imgStatusExpand.Visible = false;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
                                    if (e.Row != null)
                                        e.Row.CssClass = "viscol";
                                }
                                else
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                }
                                lnkEo.Visible = true;
                                lblStatus.Visible = false;
                            }
                        }
                        else
                        {

                            //e.Row.Visible = false;
                            imgStatusCollapse.Visible = false;
                            imgStatusExpand.Visible = false;
                            lblStatus.Visible = false;
                            imgEo1.Visible = false;
                            imgEo2.Visible = false;
                            lnkEo.Visible = false;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "hiddencol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "hiddencol";
                                if (e.Row != null)
                                    e.Row.CssClass = "hiddencol";
                            }
                            else
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "hiddencol";
                            }
                            if ((!string.IsNullOrEmpty(lblStatus.Text)) && string.IsNullOrEmpty(lnkEo.Text))
                            {
                                imgStatusCollapse.Visible = false;
                                imgStatusExpand.Visible = true;
                                lblStatus.Visible = true;
                                if (e.Row.Cells.Count > 1)
                                {
                                    if (e.Row.Cells[0] != null)
                                        e.Row.Cells[0].CssClass = "viscol";
                                    if (e.Row.Cells[1] != null)
                                        e.Row.Cells[1].CssClass = "viscol";
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
                        if (objSecurity.IsExists(Convert.ToString(ViewState["EOMain"]), Convert.ToString(e.VisibleIndex)))
                        {
                            lblEOdisp.Visible = true;
                            lbEOID.Visible = true;
                            lblStatus.Visible = false;
                            imgStatusCollapse.Visible = false;
                            imgStatusExpand.Visible = false;
                            imgEo1.Visible = false;
                            imgEo2.Visible = true;
                            lnkEo.Visible = true;
                            if (e.Row.Cells.Count > 1)
                            {
                                if (e.Row.Cells[0] != null)
                                    e.Row.Cells[0].CssClass = "viscol";
                                if (e.Row.Cells[1] != null)
                                    e.Row.Cells[1].CssClass = "viscol";
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

                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }


        protected void imgStatusExpand_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ViewState["Expand"] = null;
                string st = string.Empty;

                ImageButton imgExpand = (ImageButton)sender;
                imgExpand.Visible = false;
                ImageButton imgPlant2 = (ImageButton)imgExpand.Parent.FindControl("imgStatusCollapse");
                imgPlant2.Visible = true;

                //Page.RegisterStartupScript("clientscript", "document.getElementById('" + imgPlant2.ClientID + "').focus();");
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgExpand.Parent;
                int rowno = gvd.ItemIndex;
                ViewState["SingleMain"] = Convert.ToString(rowno);
                for (int rowCount = rowno + 1; rowCount <= dgdStatus.VisibleRowCount - 1; rowCount++)
                {


                    //If it is not works use 2nd Grid name
                    Label lblStatus = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");
                    LinkButton lnkEo = (LinkButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "lnkEO");

                    //If it is not works use 2nd Grid name
                    ImageButton imgEo1 = (ImageButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO1");
                    ImageButton imgEo2 = (ImageButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO2");

                    if (lblStatus != null)
                    {
                        if (string.IsNullOrEmpty(lblStatus.Text))
                        {
                            if (!string.IsNullOrEmpty(lnkEo.Text))
                            {
                                st = st + Convert.ToString(rowCount) + ",";
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lnkEo.Parent.Parent.Parent;
                                gvdc.Visible = true;
                                imgEo1.Visible = true;
                                imgEo2.Visible = false;
                                //lblBrandSegmentID.Visible = False
                            }
                            else
                            {
                                GridViewTableDataRow gvdc = (GridViewTableDataRow)lnkEo.Parent.Parent.Parent;
                                gvdc.Visible = false;
                                imgEo1.Visible = false;
                                imgEo2.Visible = false;
                                lnkEo.Visible = false;
                            }

                        }
                        else
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    ViewState["Single"] = st.TrimEnd(new char[] { ',' });
                }
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void imgStatusCollapse_Command(object sender, CommandEventArgs e)
        {
            ViewState["Expand"] = null;
            //dgdPrelimSelectedEO.Visible = false;
            //Use 2nd Grid
            dgdEODetails.Visible = false;
            lblEOdisp.Visible = false;
            lbEOID.Visible = false;



            ImageButton imgCollapse = (ImageButton)sender;
            ImageButton imgExpand = (ImageButton)imgCollapse.Parent.FindControl("imgStatusExpand");
            imgCollapse.Visible = false;
            imgExpand.Visible = true;

            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgExpand.Parent;
            int rowno = gvd.ItemIndex;


            for (int rowCount = rowno + 1; rowCount <= dgdStatus.VisibleRowCount - 1; rowCount++)
            {
                ViewState["Single"] = null;
                ViewState["SingleMain"] = null;

                //If it is not work then use 2nd Grid

                Label lblStatus = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");
                Label lblEoId = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblEOID");
                LinkButton lnkEo = (LinkButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "lnkEO");
                //lblPlantName.Visible = false;
                //lblEOMode=lnkEo
                //lblPlantName=lblStatus
                //lblEOID=lblEoId
                ImageButton imgE1 = (ImageButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO1");
                ImageButton imgE2 = (ImageButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "imgEO2");

                if (lblStatus != null)
                {
                    if (string.IsNullOrEmpty(lblStatus.Text))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblStatus.Parent.Parent.Parent;
                        gvdc.Visible = false;
                        imgE1.Visible = false;
                        imgE2.Visible = false;
                        lnkEo.Visible = false;

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

        protected void imgEO1_Command(object sender, CommandEventArgs e)
        {
            FillConcStatus();
            ViewState["Expand"] = null;
            ImageButton imgE1 = (ImageButton)sender;
            ImageButton imgE2 = (ImageButton)imgE1.Parent.FindControl("imgEO2");
            imgE1.Visible = false;
            imgE2.Visible = true;
            GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgE1.Parent;
            int rowno = gvd.ItemIndex;
            ViewState["EOMain"] = rowno;
            dgdEODetails.Visible = true;
            lblEOdisp.Visible = true;
            lbEOID.Visible = true;
            lbEOID.Text = Convert.ToString(e.CommandArgument);
            //If it is not works use 2nd Grid name 
            //Label lblstatus = (Label)dgdStatus.FindRowCellTemplateControl(rowno, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");          
            dgdEODetails.Visible = true;
            ViewState["EO_ID"] = lbEOID.Text;
            FillEODetails(Convert.ToInt32(lbEOID.Text));
            SetEODetailView(lbEOID.Text);
            lblEOHead.Visible = true;
            lblEOdisp.Text = imgE1.Attributes["EO"];
            lblEOdisp.Visible = true;
            imgReadOnly.Visible = true;

            ////ViewState["Plant_ID"] = Convert.ToString(e.CommandArgument);
            ////ViewState["EOMain"] = Convert.ToString(rowno);
            ////FillApprovedSelectedEOs(Convert.ToInt32(e.CommandArgument));
            //intGlobalPlantID = Convert.ToInt32(e.CommandArgument);


        }

        protected void imgEO2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                //FillApprovedEOs();
                ViewState["Expand"] = null;
                ViewState["EOMain"] = null;
                dgdEODetails.Visible = false;

                lblEOdisp.Visible = false;
                lbEOID.Visible = false;

                ImageButton imgE2 = (ImageButton)sender;
                ImageButton imgE1 = (ImageButton)imgE2.Parent.FindControl("imgEO1");
                imgE1.Visible = true;
                imgE2.Visible = false;
                GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)imgE2.Parent;
                int rowno = gvd.ItemIndex;


                for (int rowCount = (rowno + 1); (rowCount <= (dgdStatus.VisibleRowCount - 1)); rowCount++)
                {
                    Label lblstatus = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");
                    Label lblEoid = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblEOID");
                    if (((lblstatus.Text == "") && (lblEoid.Text == "")))
                    {
                        GridViewTableDataRow gvdc = (GridViewTableDataRow)lblstatus.Parent.Parent.Parent;
                        gvdc.Visible = false;
                    }
                    else
                    {
                        break;
                    }
                }
                //for (int rowCount = rowno + 1; rowCount <= dgdStatus.VisibleRowCount - 1; rowCount++)
                //{

                //    Label lblstatus = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblStatus");
                //    Label lblEoid = (Label)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["Status"], "lblEOID");
                //    LinkButton lnkeo = (LinkButton)dgdStatus.FindRowCellTemplateControl(rowCount, (GridViewDataColumn)dgdStatus.Columns["EO Details"], "lnkEO");

                //    //lblPlantName=lblstatus
                //    //lblPlantId=lblEoid
                //    //lblEOMode=lnkeo

                //    if (lblstatus != null)
                //    {
                //        if (string.IsNullOrEmpty(lblstatus.Text) & string.IsNullOrEmpty(lnkeo.Text))
                //        {
                //            GridViewTableDataRow gvdc = (GridViewTableDataRow)lblstatus.Parent.Parent.Parent;
                //            gvdc.Visible = false;
                //        }
                //        else
                //        {
                //            break; // TODO: might not be correct. Was : Exit For
                //        }
                //    }                    
                //}
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void lnkEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View_EO")
                {
                    Response.Redirect("~/Common/ViewEO.aspx?EO_ID=" + e.CommandArgument);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Common/FuzzySearch.aspx");
        }
    }
}