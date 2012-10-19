using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Common
{
    public partial class frmViewEvent : System.Web.UI.Page
    {
        clsProject clsPrj = new clsProject();
        int intPrjID;
        string strUser;
        DataSet dsHistory;
        DataSet dsEventDetails;
        DataSet dsProjectDetails;
        static string strUserRole;
        DataSet dsCheckUser;
        string strCreatedUser;
        EOBA objEOBA = new EOBA();
        clsSecurity objSecurity = new clsSecurity();
        bool boolAllowUser = false;
        clsEvent objclsEvent = new clsEvent();

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            try
            {

                strUser = objSecurity.UserName;
                lblUser.Visible = false;
                if (!IsPostBack)
                {
                    dsEventDetails = new DataSet();
                    //dsEventDetails = clsEvent.FetchEventDetails(Request.QueryString["EventID"]);
                    if (objclsEvent.FetchEventDetails(Convert.ToInt32(Request.QueryString["EventID"]), ref dsEventDetails))
                    {
                        if (dsEventDetails == null)
                        {
                            return;
                        }
                        else if (dsEventDetails.Tables.Count == 0)
                        {
                            return;
                        }
                        else if (dsEventDetails.Tables[0].Rows.Count == 0)
                        {
                            return;
                        }
                        //Displaying General Sectiion of event.
                        foreach (DataRow drEventRow in dsEventDetails.Tables[0].Rows)
                        {
                            intPrjID = Convert.ToInt32(drEventRow[0]);
                            lblProjectValue.Text = drEventRow[1].ToString();
                            lblEONameValue.Text = drEventRow[4].ToString();
                            lblEventTypeValue.Text = drEventRow[6].ToString();
                            lblPlantValue.Text = drEventRow[3].ToString();
                            //lblDSDateValue.Text = Strings.Format(drEventRow[7], "MM/dd/yyyy");
                            lblDSDateValue.Text = String.Format("{0:MM/dd/yyyy}", drEventRow[7]);
                            if (drEventRow[8].ToString() == "N")
                            {
                                lblShippableValue.Text = "No";
                            }
                            else
                            {
                                lblShippableValue.Text = "Yes";
                            }

                           
                            if (Convert.ToString(Convert.ToInt32(Convert.ToDouble(drEventRow[9].ToString()))) == "0" || drEventRow[9] == DBNull.Value)
                            {
                                lblGDaysValue.Text = "No";
                            }
                            else
                            {
                                if (lblShippableValue.Text.ToUpper() == "NO")
                                    lblGDaysValue.Text = "No";
                                else
                                    lblGDaysValue.Text = "Yes";
                            }
                            lblDaysValue.Text = drEventRow[9].ToString();
                            lblBrandSegmentDB.Text = drEventRow[15].ToString();
                        }

                        //Displaying combining line machine type details
                        foreach (DataRow drCombiningRow in dsEventDetails.Tables[1].Rows)
                        {
                            lblComLineValue.Text = drCombiningRow[1].ToString();

                            lblComLostValue.Text = drCombiningRow[2].ToString();

                        }

                        //Displaying converting line machine type details
                        foreach (DataRow drConvertingRow in dsEventDetails.Tables[2].Rows)
                        {
                            lblConLineValue.Text = drConvertingRow[1].ToString();
                            lblConLostValue.Text = drConvertingRow[2].ToString();
                            if (drConvertingRow[3] == DBNull.Value)
                            {
                                lblConCommentsValue.Text = string.Empty;
                            }
                            else
                            {
                                lblConCommentsValue.Text = drConvertingRow[3].ToString();
                            }

                        }

                        //Displaying Paper machine machine type details
                        foreach (DataRow drPaperMachineRow in dsEventDetails.Tables[3].Rows)
                        {
                            lblPaperValue.Text = drPaperMachineRow[1].ToString();

                            lblPTotalLostValue.Text = drPaperMachineRow[2].ToString();


                            if (drPaperMachineRow[3] == DBNull.Value)
                            {
                                lblPCommentsValue.Text = string.Empty;
                            }
                            else
                            {
                                lblPCommentsValue.Text = drPaperMachineRow[3].ToString();
                            }
                        }

                        //Displaying Authors if exist
                        foreach (DataRow drAuthors in dsEventDetails.Tables[5].Rows)
                        {
                            if (lblAuthorsValue.Text == string.Empty)
                            {
                                lblAuthorsValue.Text = drAuthors[0].ToString();
                            }
                            else
                            {
                                lblAuthorsValue.Text = lblAuthorsValue.Text + "," + drAuthors[0];
                            }
                        }
                    }
                    //Displaying project related data for the event based project id
                    //dsProjectDetails = clsEvent.FetchProjectDetailsForEvent(intPrjID);
                    if (objclsEvent.FetchProjectDetailsForEvent("GET_MUR_Project", "@p_Project_ID", Convert.ToInt32(intPrjID), ref dsProjectDetails))
                    {
                        foreach (DataRow drProjectDetails in dsProjectDetails.Tables[0].Rows)
                        {
                            lblSelCategory.Text = drProjectDetails[6].ToString();
                            lblCategoryDB.Text = drProjectDetails[6].ToString();
                            lblBrandValue.Text = drProjectDetails[3].ToString();
                            lblPrjTypeValue.Text = drProjectDetails[2].ToString();
                            lblPrjLeaderValue.Text = drProjectDetails[4].ToString();
                            lblPOCValue.Text = drProjectDetails[5].ToString();
                            lblOriginatorValue.Text = drProjectDetails[7].ToString();
                            //lblBrandSegmentDB.Text = drProjectDetails.Item(8)
                        }
                    }

                    //filling of History details in the datagrid.
                    FillHistoryGrid(Request.QueryString["EventID"]);
                }
            }
            catch (Exception ex)
            {
                string script = null;
                script = "<script>alert('" + ex.Message + "')</script>";
                Page.RegisterStartupScript("error_message", script);
            }
        }

        public void FillHistoryGrid(string parEventID)
        {
            dsHistory = new DataSet();
            //dsHistory = clsEvent.FillHistoryofEvent(parEventID);
            if (objclsEvent.FetchEventDetails(Convert.ToInt32(parEventID), ref dsHistory))
            {
                dgdShowHistory.DataSource = dsHistory.Tables[4].DefaultView;
                dgdShowHistory.DataBind();
            }
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            strUser = objSecurity.UserName;
            strUserRole = objSecurity.UserRole();

            dsCheckUser = new DataSet();
            //dsCheckUser = clsEvent.FetchEventDetails(Request.QueryString["EventID"]);
            if (objclsEvent.FetchEventDetails(Convert.ToInt32(Request.QueryString["EventID"]), ref dsCheckUser))
            {

                if ((dsCheckUser != null))
                {
                    if (!(dsCheckUser.Tables.Count == 0))
                    {
                        if (!(dsCheckUser.Tables[0].Rows.Count == 0))
                        {
                            //Getting the name of the created user 
                            strCreatedUser = dsCheckUser.Tables[0].Rows[0][10].ToString();
                        }

                        if (!(dsCheckUser.Tables[5].Rows.Count == 0))
                        {
                            //Getting the other author names and if exist make their eligibilty for modification to true
                            foreach (DataRow drAuthors in dsCheckUser.Tables[5].Rows)
                            {
                                if (strUser == drAuthors[0].ToString())
                                {
                                    boolAllowUser = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                        }

                        if (!(dsCheckUser.Tables[5].Rows.Count == 0))
                        {
                            foreach (DataRow drAuthors in dsCheckUser.Tables[6].Rows)
                            {
                                if (strUser == drAuthors[0].ToString())
                                {
                                    boolAllowUser = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                        }
                    }
                }
            }

            if (strCreatedUser == strUser)
            {
                Response.Redirect("frmEditEvent.aspx?EventID=" + Request.QueryString["EventID"]);
            }
            if (boolAllowUser == true)
            {
                Response.Redirect("frmEditEvent.aspx?EventID=" + Request.QueryString["EventID"]);
            }
            if (strUserRole == "MUREO_Admin")
            {
                Response.Redirect("frmEditEvent.aspx?EventID=" + Request.QueryString["EventID"]);
            }
            else
            {
                string script = null;
                script = "<script>alert('Access Denied.\\nYou donot have sufficient privelages to perform the operation.');window.navigate('Home.aspx');</script> ";
                Page.RegisterStartupScript("clientscript", script);
            }
        }

        protected void ingCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}