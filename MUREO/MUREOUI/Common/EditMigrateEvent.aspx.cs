using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Common
{
    public partial class EditMigrateEvent : System.Web.UI.Page
    {
        clsProject clsPrj = new clsProject();
        static int intPrjID;
        string strUser;
        DataSet dsHistory;
        DataSet dsEventDetails;
        DataSet dsProjectDetails;
        static string strUserRole;
        static int intEventTypeValue;
        static int intPlantValue;
        int intBrandSegmentID;
        int intCombiningValue;
        int intConvertingMachineID;
        int intPaperMachineID;
        int intCategoryID;
        DataSet dsMachine;
        static string strShippable;
        clsSecurity objSecurity = new clsSecurity();
        clsEvent objClsEvent = new clsEvent();
        SqlParameter[] paramOut = null;
       

        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                strUser = objSecurity.UserName;
                // New Code by Abdul filling labels using datasets
                txtDays.Attributes.Add("onblur", "javascript: CountDecimalsValueThree(this.value,\'txtDays\');");
                if (!IsPostBack)
                {
                    imgDeleteName.Attributes.Add("onclick", "return confirm(\'Are you sure you want to delete the author name(s)? Click OK to delete or CANCEL to a" +
                        "bort.\');");
                    txtDate.Attributes.Add("onblur", "javascript: isDate(this.value);");
                    imgAddressBook.Attributes.Add("onclick", "javascript: AddBookMultiUser();");
                    txtPLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,\'txtPLostValue\');");
                    txtConLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,\'txtConLostValue\');");
                    txtComLostValue.Attributes.Add("onblur", "javascript: CountDecimals(this.value,\'txtComLostValue\');");
                  
                    lblGDays.Visible = false;
                    lblDays.Visible = false;
                    //tdrdbDays.Style.Value = "display:none";
                    rdbOnhold.Visible = false;
                    //tdtxtDays.Visible = false;
                    txtDays.Visible = false;
                    dsEventDetails = new DataSet();
                    clsEvent objclsEvent = new clsEvent();
                    // dsEventDetails = clsEvent.FetchEventDetails(Request.QueryString["EventID"]);
                    if (objclsEvent.FetchEventDetails(Convert.ToInt32(Request.QueryString["EventID"]), ref dsEventDetails))
                    {
                        if ((dsEventDetails == null))
                        {
                            return;
                        }
                        else if ((dsEventDetails.Tables.Count == 0))
                        {
                            return;
                        }
                        else if ((dsEventDetails.Tables[0].Rows.Count == 0))
                        {
                            return;
                        }
                        // Displaying General Sectiion of event.
                        foreach (DataRow drEventRow in dsEventDetails.Tables[0].Rows)
                        {
                            intPrjID = Convert.ToInt32(drEventRow[0]);
                            lblProjectValue.Text = drEventRow[1].ToString();
                            lblEONameValue.Text = drEventRow[4].ToString();
                            lblEventTypeValue.Text = drEventRow[6].ToString();
                            lblPlantValue.Text = drEventRow[3].ToString();
                            //txtDate.Text = Format(drEventRow[7], "MM/dd/yyyy");
                            txtDate.Text = String.Format("{0:MM/dd/yyyy}", drEventRow[7]);
                            if ((Convert.ToString(drEventRow[8]) == "N"))
                            {
                                lblShippableValue.Text = "No";
                                rdbShippable.SelectedValue = "N";
                                strShippable = "N";
                            }
                            else
                            {
                                rdbShippable.SelectedValue = "Y";
                                lblShippableValue.Text = "Yes";
                                strShippable = "Y";
                            }
                            if ((rdbShippable.SelectedValue == "Y"))
                            {
                                //tdGDays.Visible = true;
                                lblGDays.Visible = true;
                                //lblDays.Visible = false;
                                //tdrdbDays.Style.Value = "display:block";
                                rdbOnhold.Visible = true;
                            }
                            if ((Convert.ToInt32(drEventRow[9]) == 0) || (drEventRow[9] == DBNull.Value))
                            {
                                lblGDaysValue.Text = "No";
                                rdbOnhold.SelectedValue = "N";
                            }
                            else
                            {
                                lblGDaysValue.Text = "Yes";
                                rdbOnhold.SelectedValue = "Y";
                            }
                            lblDaysValue.Text = drEventRow[9].ToString();
                            txtDays.Text = drEventRow[9].ToString();
                            if ((Convert.ToInt32(Convert.ToDecimal(txtDays.Text)).ToString() == "0"))
                            {                               
                                lblGDays.Visible = false;
                                lblDays.Visible = false;
                                //tdrdbDays.Style.Value = "display:none";
                                rdbOnhold.Visible = true;
                                //tdtxtDays.Visible = false;
                                txtDays.Visible = false;
                                rdbOnhold.Visible = false;
                                rdbOnhold.SelectedValue = "N";
                            }
                            else
                            {
                                lblGDays.Visible = true;
                                lblDays.Visible = true;
                                //tdrdbDays.Style.Value = "display:block";
                                //tdtxtDays.Visible = true;
                                txtDays.Visible = true;
                                rdbOnhold.SelectedValue = "Y";
                            }
                            lblBrandSegmentDB.Text = drEventRow[15].ToString();
                            intPrjID = Convert.ToInt32(drEventRow[0]);
                            intPlantValue = Convert.ToInt32(drEventRow[2]);
                            intEventTypeValue = Convert.ToInt32(drEventRow[5]);
                            intBrandSegmentID = Convert.ToInt32(drEventRow[14]);
                        }
                        // Displaying combining line machine type details
                        foreach (DataRow drCombiningRow in dsEventDetails.Tables[1].Rows)
                        {
                            intCombiningValue = Convert.ToInt32(drCombiningRow[0]);
                            txtComLostValue.Text = drCombiningRow[2].ToString();
                        }
                        // Displaying converting line machine type details
                        foreach (DataRow drConvertingRow in dsEventDetails.Tables[2].Rows)
                        {
                            intConvertingMachineID = Convert.ToInt32(drConvertingRow[0]);
                            txtConLostValue.Text = drConvertingRow[2].ToString();
                            if (drConvertingRow[3] == DBNull.Value)
                            {
                                txtConComments.Text = String.Empty;
                            }
                            else
                            {
                                txtConComments.Text = drConvertingRow[3].ToString();
                            }
                        }
                        // Displaying Paper machine machine type details
                        foreach (DataRow drPaperMachineRow in dsEventDetails.Tables[3].Rows)
                        {
                            intPaperMachineID = Convert.ToInt32(drPaperMachineRow[0]);
                            txtPLostValue.Text = drPaperMachineRow[2].ToString();
                            if (drPaperMachineRow[3] == DBNull.Value)
                            {
                                txtPComments.Text = String.Empty;
                            }
                            else
                            {
                                txtPComments.Text = drPaperMachineRow[3].ToString();
                            }
                        }
                        // Displaying Authors if exist
                        foreach (DataRow drAuthors in dsEventDetails.Tables[5].Rows)
                        {
                            if ((txtAuthors.Text == String.Empty))
                            {
                                txtAuthors.Text = drAuthors[0].ToString();
                                hdntxtPrjLead.Value = drAuthors[0].ToString();
                            }
                            else
                            {
                                txtAuthors.Text = (txtAuthors.Text + ("," + drAuthors[0]));
                                hdntxtPrjLead.Value = (txtAuthors.Text + ("," + drAuthors[0]));
                            }
                        }
                    }
                    // Displaying project related data for the event based project id
                    //dsProjectDetails = clsEvent.FetchProjectDetailsForEvent(intPrjID);
                    if (objClsEvent.FetchProjectDetailsForEvent("GET_MUR_Project", "@p_Project_ID", Convert.ToInt32(intPrjID), ref dsProjectDetails))
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
                            intCategoryID = Convert.ToInt32(drProjectDetails[8]);
                            // lblBrandSegmentDB.Text = drProjectDetails.Item(8)
                        }
                    }
                    
                    // Showing a paper machine line machine type details
                    FillDropDownWithMachines(3, intPlantValue, 0, "Machine_Name", "Machine_ID", "Select a Paper Machine", drpPaper);
                    drpPaper.SelectedValue = intPaperMachineID.ToString();
                    // Showing a converting line machine type details
                    FillDropDownWithMachines(2, intPlantValue, intCategoryID, "Machine_Name", "Machine_ID", "Select a Converting Line", drpConLine);
                    drpConLine.SelectedValue = intConvertingMachineID.ToString();
                    // Showing a combining line machine type details
                    FillDropDownWithMachines(1, 0, 0, "Machine_Name", "Machine_ID", "Select a Combining line", drpComLine);
                    drpComLine.SelectedValue = intCombiningValue.ToString();
                    // filling of History details in the datagrid.
                    FillHistoryGrid(Request.QueryString["EventID"]);
                }
            }
            catch (Exception ex)
            {
                string script;
                script = ("<script>alert(\'"
                            + (ex.Message + "\')</script>"));
                Page.RegisterStartupScript("error_message", script);
            }
        }

        public void FillDropDownWithMachines(int MachineType, int PlantId, int CategoryId, string colText, string colValue, string optionalValue, DropDownList drpName)
        {
            drpName.Items.Clear();
            dsMachine = new DataSet();
            //dsMachine = clsProject.FetchMachines(MachineType, PlantId, CategoryId);
            if (objClsEvent.FetchMachines(MachineType, PlantId, CategoryId, ref dsMachine, "GET_MUR_Machine_Tree_View_Details"))
            {
                if ((dsMachine.Tables.Count == 0))
                {
                    // EmptyDataMessage("Machine does not exist(s) for the selected value.")
                    drpName.Items.Insert(0, "None");
                    drpName.Items[0].Value = "0";
                }
                else if ((dsMachine.Tables[0].Rows.Count == 0))
                {
                    // EmptyDataMessage("Machine does not exist(s) for the selected value.")
                    drpName.Items.Insert(0, "None");
                    drpName.Items[0].Value = "0";
                }
                else
                {
                    drpName.DataSource = dsMachine.Tables[0].DefaultView;
                    drpName.DataTextField = colText;
                    drpName.DataValueField = colValue;
                    drpName.DataBind();
                    drpName.Items.Insert(0, optionalValue);
                    drpName.Items[0].Value = "0";
                }
            }
        }

        void FillHistoryGrid(string parEventID)
        {
            dsHistory = new DataSet();
            //dsHistory = clsEvent.FillHistoryofEvent(parEventID);
            if (objClsEvent.FetchEventDetails(Convert.ToInt32(parEventID), ref dsHistory))
            {
                dgdShowHistory.DataSource = dsHistory.Tables[4].DefaultView;
                dgdShowHistory.DataBind();
            }
        }

        public void CheckForNullValue()
        {
            //setting for shipping days
            if (txtDays.Text == string.Empty)
            {
                txtDays.Text = "0";
            }
            if (txtPLostValue.Text == string.Empty)
            {
                txtPLostValue.Text = "0";
            }

            if (txtConLostValue.Text == string.Empty)
            {
                txtConLostValue.Text = "0";
            }

            if (txtComLostValue.Text == string.Empty)
            {
                txtComLostValue.Text = "0";
            }

        }

        //private void calc_Click(object sender, System.EventArgs e)
        //{
        //    string jvscript;
        //    jvscript = "<script>CalculateLostDays();</script> ";
        //    Page.RegisterStartupScript("clientscript", jvscript);
        //}

        private string checkTotalLostdaysValidation()
        {
            string tempStr = "TRUE";
            decimal tempInt;
            if ((txtPLostValue.Text.Trim() != ""))
            {
                try
                {
                    tempInt = Convert.ToDecimal(txtPLostValue.Text.Trim());
                    if ((tempInt < 0))
                    {
                        tempStr = "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    tempStr = "FALSE";
                }
            }
            if ((txtConLostValue.Text.Trim() != ""))
            {
                try
                {
                    tempInt = Convert.ToDecimal(txtConLostValue.Text.Trim());
                    if ((tempInt < 0))
                    {
                        tempStr = "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    tempStr = "FALSE";
                }
            }
            if ((txtComLostValue.Text.Trim() != ""))
            {
                try
                {
                    tempInt = Convert.ToDecimal(txtComLostValue.Text.Trim());
                    if ((tempInt < 0))
                    {
                        tempStr = "FALSE";
                    }
                }
                catch (Exception ex)
                {
                    tempStr = "FALSE";
                }
            }
            return tempStr;
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // Validaion on ProjectName,EO Name,EventType,Plant and Desired start date
                if ((txtDate.Text == ""))
                {
                    string script;
                    script = ("<script>alert(\'"
                                + (ConfigurationSettings.AppSettings["DateErrMsg"] + "\');</script> "));
                    Page.RegisterStartupScript("clientscript", script);
                    return;
                }
                // Validaion on machine types
                if (((drpPaper.SelectedIndex == 0)
                            && ((drpConLine.SelectedIndex == 0)
                            && (drpComLine.SelectedIndex == 0))))
                {
                    string script;
                    script = ("<script>alert(\'"
                                + (ConfigurationSettings.AppSettings["MachineErrMsg"] + "\');</script> "));
                    Page.RegisterStartupScript("clientscript", script);
                    return;
                }
                string tempStr;
                tempStr = checkTotalLostdaysValidation();
                if ((tempStr == "FALSE"))
                {
                    string script;
                    script = "<script>alert(\'Input is Not In Correct Format\');</script> ";
                    Page.RegisterStartupScript("clientscript", script);
                    return;
                }
                DateTime strDate = Convert.ToDateTime(txtDate.Text.Trim());
                if ((rdbOnhold.SelectedValue == "Y"))
                {
                    if (((txtDays.Text == "")
                                || (txtDays.Text == 0.ToString())))
                    {
                        string script;
                        script = "<script>alert(\'# Days on Hold should be greater than 3.\');document.getElementById(\'txtDays\').focus();" +
                        "</script>";
                        Page.RegisterStartupScript("clientscript", script);
                    }
                }
                if ((rdbShippable.SelectedValue == "N"))
                {
                    txtDays.Text = "0";
                }
                CheckForNullValue();
                lblConLostValue.Text = txtConLostValue.Text;
                lblPLostValue.Text = txtPLostValue.Text;
                lblComLostValue.Text = txtComLostValue.Text;
                Session["EventsEditied"] = null;

                //int intResult = clsEvent.EventInsert(Convert.ToInt32(Request.QueryString["EventID"]), 
                //    intPrjID, 
                //    intPlantValue, 
                //    lblEONameValue.Text, intEventTypeValue, 
                //    strDate, 
                //    rdbShippable.SelectedValue,
                //    txtDays.Text,
                //    drpPaper.SelectedValue, 0, 0, 0, Convert.ToDecimal(lblPLostValue.Text.Trim), 
                //    txtPComments.Text.Trim, drpConLine.SelectedValue, 0, 0, 0, Convert.ToDecimal(lblConLostValue.Text.Trim), 
                //    txtConComments.Text.Trim, drpComLine.SelectedValue, 0, 0, 0, Convert.ToDecimal(lblComLostValue.Text.Trim), txtAuthors.Text.Trim, "A", strUser); 

                if (objClsEvent.EventInsertDAL(Convert.ToInt32(Request.QueryString["EventID"]),
                  Convert.ToInt32(intPrjID),
                  Convert.ToInt32(intPlantValue),
                  lblEONameValue.Text, Convert.ToInt32(intEventTypeValue),
                  strDate,
                  rdbShippable.SelectedValue.ToString(),
                  Convert.ToDecimal(txtDays.Text.Trim()),
                  Convert.ToInt32(drpPaper.SelectedValue),
                  Convert.ToDecimal(0), Convert.ToDecimal(0),
                  Convert.ToDecimal(0), Convert.ToDecimal(lblPLostValue.Text.Trim()),
                  txtPComments.Text.Trim(), Convert.ToInt32(drpConLine.SelectedValue),
                  Convert.ToDecimal(0), Convert.ToDecimal(0), 0, Convert.ToDecimal(lblConLostValue.Text.Trim()),
                 txtConComments.Text.Trim(),
                  Convert.ToInt32(drpComLine.SelectedValue), Convert.ToDecimal(0),
                  Convert.ToDecimal(0), Convert.ToDecimal(0), Convert.ToDecimal(lblComLostValue.Text.Trim()),
                  hdntxtPrjLead.Value, "A", strUser, ref paramOut))
                {
                    if (Convert.ToInt32(paramOut[1].Value) == 0)
                    {
                        Session["EventsEditied"] = "Yes";
                        string script;
                        script = "<script>window.returnValue =\'\' ;";
                        script = (script + "window.opener.RefreshPage();window.close();</script>");
                        script = (script + "window.close();</script>");
                        Page.RegisterStartupScript("clientscript", script);
                    }
                    else if (Convert.ToInt32(paramOut[1].Value) == 1)
                    {
                        string script;
                        script = ("<script>alert(\'"
                                    + (ConfigurationSettings.AppSettings["RecordExist"] + "\');</script> "));
                        Page.RegisterStartupScript("clientscript", script);
                    }
                    else
                    {
                        // Failure Message
                        string script;
                        script = ("<script>alert(\'"
                                    + (ConfigurationSettings.AppSettings["EventInsertErrMsg"] + "\');</script> "));
                        Page.RegisterStartupScript("clientscript", script);
                    }
                    if ((rdbShippable.SelectedValue == "N"))
                    {
                        txtDays.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                string script;
                string exMessage;
                exMessage = ex.Message.Replace("\'", " ");
                script = ("<script>alert(\'"
                            + (exMessage + "\');</script> "));
                Page.RegisterStartupScript("clientscript", script);
            }
        }

        protected void ingCancel_Click(object sender, ImageClickEventArgs e)
        {
            string script;
            script = "<script>window.returnValue =\'\' ;";
            script = (script + "window.close(); </script>");
            Page.RegisterStartupScript("clientscript", script);
        }

        protected void imgDeleteName_Click(object sender, ImageClickEventArgs e)
        {
            txtAuthors.Text = "";
            hdntxtPrjLead.Value = "";
        }

        protected void drpPaper_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Page.SmartNavigation = false;
        }

        protected void drpConLine_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Page.SmartNavigation = false;
        }

        protected void rdbShippable_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if ((rdbShippable.SelectedValue == "Y"))
            {
                //tdGDays.Visible = true;
                lblGDays.Visible = true;
                //lblDays.Visible = false;
                //tdrdbDays.Style.Value = "display:block";
                rdbOnhold.Visible = true;
                rdbOnhold.SelectedValue = "N";
            }
            else
            {
               
                lblGDays.Visible = false;
                lblDays.Visible = false;
                //tdrdbDays.Style.Value = "display:none";
                rdbOnhold.Visible = false;
               
                //tdtxtDays.Visible = false;
                //txtDays.Visible = false;
                rdbOnhold.SelectedValue = "N";
            }
        }

        protected void rdbOnhold_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if ((rdbOnhold.SelectedValue == "Y"))
            {
                lblGDays.Visible = true;
                lblDays.Visible = true;
                //tdtxtDays.Visible = true;
                txtDays.Visible = true;
            }
            else
            {
                //lblGDays.Visible = false;
                lblDays.Visible = false;
                //tdtxtDays.Visible = false;
                txtDays.Visible = false;
                //tdGDays.Visible = false;
                txtDays.Text = "0";
            }
        }
    }
}