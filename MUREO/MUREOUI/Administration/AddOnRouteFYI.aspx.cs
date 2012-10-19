using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddOnRouteFYI : System.Web.UI.Page
    {
        string strScript = string.Empty;
        DataSet dsSeedData = null;
        clsFYIRecipientsBO objclsFYIRecipientsBO = null;
        clsSecurity clsm = new clsSecurity();
        EOBA objclsEOBA = null;
        SqlParameter[] paramOut = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
            {
                txtFYIRoutedName.Text = hdntxtPrjLead.Value;
            }
            imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
            imgSaveExit.Attributes.Add("onclick", "javascript:return Validate();");

            if (!IsPostBack)
            {
                FillDropDownData();

                if (Request.QueryString["Mode"] == "New")
                {
                    trEdFYI.Visible = false;
                    trViewFYI.Visible = false;
                    trcrFYI.Visible = true;

                    ShowAddDetails();

                    imgSaveExit.Visible = true;
                    imgEdit.Visible = false;
                    imgCancel.Visible = true;
                    trMFields.Visible = true;
                    //imgDelete.Visible = False
                }
                else if (Request.QueryString["Mode"] == "View")
                {
                    trEdFYI.Visible = false;
                    trViewFYI.Visible = true;
                    trcrFYI.Visible = false;
                    trMFields.Visible = false;
                    ShowViewDetails("View");
                    GetRecipientDetails("View");
                    imgSaveExit.Visible = false;
                    imgEdit.Visible = true;
                    imgCancel.Visible = true;
                    imgAddressBook.Visible = false;
                    //imgDelete.Visible = True
                }
                else if (Request.QueryString["Mode"] == "Edit")
                {
                    trEdFYI.Visible = true;
                    trViewFYI.Visible = false;
                    trcrFYI.Visible = false;
                    trMFields.Visible = true;
                    ShowViewDetails("Edit");
                    GetRecipientDetails("Edit");

                    imgSaveExit.Visible = true;
                    imgEdit.Visible = false;
                    imgCancel.Visible = true;
                    //imgDelete.Visible = False
                }
                else
                {
                    Response.Redirect("~/Administration/ViewOnRouteFYI.aspx");
                }
                //(0, "Category_Name", "Category_ID", "--Select a Category--", drpCategoryDB)
                //FillDropDownData(2, "Plant_Name", "Plant_ID", "--Select a Plant--", drpPlantSiteDB)
            }
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddOnRouteFYI.aspx?Mode=Edit&ID=" + Request.QueryString["ID"]);
            imgEdit.Visible = false;
            imgSaveExit.Visible = true;
        }

        protected void imgSaveExit_Click(object sender, ImageClickEventArgs e)
        {
            int intResult = 0;
            //int regionID=0,categoryID=0,siteorPlantID=0;
            int regionID, categoryID, siteorPlantID;
            string strFYIRoutedName = string.Empty;
            paramOut = new SqlParameter[1];

            string strKeyID = Convert.ToString(Request.QueryString["ID"]);

            if (strKeyID != "")
            {
                try
                {
                    objclsFYIRecipientsBO = new clsFYIRecipientsBO();

                    int intKeyID = Convert.ToInt32(strKeyID);
                    if (Request.QueryString["Mode"] == "New")
                    {

                        //intResult = BusinessObject.MUREO.BusinessObject.clsFYIRecipients.AddFYIRecipient(drpRegionDB.SelectedValue, drpCategoryDB.SelectedValue, drpPlantSiteDB.SelectedValue, txtFYIRoutedName.Text.Trim());

                        regionID = Convert.ToInt32(drpRegionDB.SelectedValue);
                        categoryID = Convert.ToInt32(drpCategoryDB.SelectedValue);
                        siteorPlantID = Convert.ToInt32(drpPlantSiteDB.SelectedValue);
                        strFYIRoutedName = Convert.ToString(txtFYIRoutedName.Text);

                        if (objclsFYIRecipientsBO.AddFYIRecipient(regionID, categoryID, siteorPlantID, strFYIRoutedName, clsm.UserName, 0, ref paramOut))
                        {
                            intResult = Convert.ToInt32(paramOut[0].Value);
                            if (intResult == 0)
                            {
                                //Success Message
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');";
                                //script = script + "window.location='../Administration/ViewOnRouteFYI.aspx'</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='../Administration/ViewOnRouteFYI.aspx';</script>";
                                ClientScript.RegisterStartupScript(this.GetType(), "InsertSuccess", strScript);
                            }
                            else if (intResult == 1)
                            {
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("RecordExist") + "');</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');</script> ";
                                ClientScript.RegisterStartupScript(this.GetType(), "RecordExist", strScript);
                            }
                            else
                            {
                                //Failure Message
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertError") + "');</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertError"] + "');</script> ";
                                ClientScript.RegisterStartupScript(this.GetType(), "InsertError", strScript);
                            }
                        }
                    }
                    else if (Convert.ToString(Request.QueryString["Mode"]) == "Edit")
                    {
                        intResult = 0;
                        //intResult = BusinessObject.MUREO.BusinessObject.clsFYIRecipients.AddFYIRecipient(drpRegionDB.SelectedValue, drpCategoryDB.SelectedValue, drpPlantSiteDB.SelectedValue, txtFYIRoutedName.Text.Trim(), Convert.ToInt32(Request.QueryString["ID")));

                        regionID = Convert.ToInt32(drpRegionDB.SelectedValue);
                        categoryID = Convert.ToInt32(drpCategoryDB.SelectedValue);
                        siteorPlantID = Convert.ToInt32(drpPlantSiteDB.SelectedValue);
                        strFYIRoutedName = Convert.ToString(txtFYIRoutedName.Text);
                        int receiptID = Convert.ToInt32(Request.QueryString["ID"]);

                        if (objclsFYIRecipientsBO.AddFYIRecipient(regionID, categoryID, siteorPlantID, strFYIRoutedName, clsm.UserName, receiptID, ref paramOut))
                        {
                            intResult = Convert.ToInt32(paramOut[0].Value);

                            if ((intResult == 0))
                            {
                                //Success Message
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateSuccess") + "');";
                                //script = script + "window.location='../Administration/ViewOnRouteFYI.aspx'</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='../Administration/ViewOnRouteFYI.aspx';</script>";
                                ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", strScript);
                            }
                            else if ((intResult == 1))
                            {
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("RecordExist") + "');</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');</script> ";
                                ClientScript.RegisterStartupScript(this.GetType(), "RecordExist", strScript);
                            }
                            else
                            {
                                //Failure Message
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateError"] + "');</script> ";
                                ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", strScript);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();

                }
                finally
                {
                    objclsFYIRecipientsBO = null;
                    paramOut = null;
                }
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            if ((Request.QueryString["Mode"]) == "View")
            {
                Response.Redirect("~/Administration/ViewOnRouteFYI.aspx");
            }
            else if ((Request.QueryString["Mode"]) == "New")
            {
                Response.Redirect("~/Administration/ViewOnRouteFYI.aspx");
            }
            else if ((Request.QueryString["Mode"]) == "Edit")
            {
                Response.Redirect("~/Administration/AddOnRouteFYI.aspx?Mode=View&ID" + Request.QueryString["ID"]);
            }
        }

       

        public void FillDropDownData(int tabValue, string colName1, string colName2, string optionalValue, DropDownList drpName)
        {
            try
            {
                objclsEOBA = new EOBA();
                dsSeedData = new DataSet();
                if (objclsEOBA.FillDropDownSeedData(ref dsSeedData))
                {
                    //dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data");
                    drpName.DataSource = dsSeedData.Tables[tabValue].DefaultView;
                    drpName.DataTextField = colName1;
                    drpName.DataValueField = colName2;
                    drpName.DataBind();
                    drpName.Items.Insert(0, optionalValue);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsEOBA = null;
                dsSeedData = null;
            }
        }

        private void FillDropDownData()
        {
            DataSet dsRegions = null;
            try
            {
                dsRegions = new DataSet();
                objclsEOBA = new EOBA();
                //dsRegions = ClsEO.FillDropDownSeedData("GET_EO_Region");

                if (objclsEOBA.FillEORegion(ref dsRegions))
                {

                    drpRegionDB.DataSource = dsRegions.Tables[0].DefaultView;
                    drpRegionDB.DataTextField = "Region_Name";
                    drpRegionDB.DataValueField = "Region_ID";


                    dsSeedData = new DataSet();
                    //dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data");
                    if (objclsEOBA.FillDropDownSeedData(ref dsSeedData))
                    {

                        drpCategoryDB.DataSource = dsSeedData.Tables[0].DefaultView;
                        drpCategoryDB.DataTextField = "Category_Name";
                        drpCategoryDB.DataValueField = "Category_ID";


                        drpPlantSiteDB.DataSource = dsSeedData.Tables[2].DefaultView;
                        drpPlantSiteDB.DataTextField = "Plant_Name";
                        drpPlantSiteDB.DataValueField = "Plant_ID";
                        DataBind();

                        drpRegionDB.Items.Insert(0, "--Select a Region--");
                        drpCategoryDB.Items.Insert(0, "--Select a Category--");
                        drpPlantSiteDB.Items.Insert(0, "--Select a Site--");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsEOBA = null;
                dsSeedData = null;
                dsRegions = null;
            }
        }

        private void GetRecipientDetails(string mode)
        {
            int iRecipientID = Convert.ToInt32(Request.QueryString["ID"]);
            DataSet dsRecipientDet = null;

            try
            {
                objclsFYIRecipientsBO = new clsFYIRecipientsBO();
                dsRecipientDet = new DataSet();
                // dsRecipientDet = BusinessObject.MUREO.BusinessObject.clsFYIRecipients.GetRecipients(iRecipientID);
                if (objclsFYIRecipientsBO.GetRecipients(iRecipientID, ref dsRecipientDet))
                {
                    if (mode == "Edit")
                    {
                        //For i As Integer = 0 To dsRecipientDet.Tables(0).Rows.Count - 1
                        drpRegionDB.SelectedIndex = drpRegionDB.Items.IndexOf(drpRegionDB.Items.FindByText(Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Region_Name"])));
                        drpCategoryDB.SelectedIndex = drpCategoryDB.Items.IndexOf(drpCategoryDB.Items.FindByText(Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Category_Name"])));
                        drpPlantSiteDB.SelectedIndex = drpPlantSiteDB.Items.IndexOf(drpPlantSiteDB.Items.FindByText(Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Plant_Name"])));
                        txtFYIRoutedName.Text = Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Approver_Name"]);
                        //Next
                        //drpCategoryDB.SelectedIndex = 
                    }
                    else if (mode == "View")
                    {
                        lblCategoryDB.Text = Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Category_Name"]);
                        lblRegionDB.Text = Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Region_Name"]);
                        lblSiteDB.Text = Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Plant_Name"]);
                        lblFYIMessageNameDB.Text = Convert.ToString(dsRecipientDet.Tables[0].Rows[0]["Approver_Name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsFYIRecipientsBO = null;
                dsRecipientDet = null;
            }
        }
        public void ShowAddDetails()
        {
            lblCategoryDB.Visible = false;
            lblRegionDB.Visible = false;
            lblSiteDB.Visible = false;
            lblFYIMessageNameDB.Visible = false;
            drpCategoryDB.Visible = true;
            drpPlantSiteDB.Visible = true;
            drpRegionDB.Visible = true;
            txtFYIRoutedName.Visible = true;
            lblComp1.Visible = true;
            lblComp2.Visible = true;
            lblComp3.Visible = true;
            lblComp4.Visible = true;
        }
        public void ShowViewDetails(string mode)
        {
            lblCategoryDB.Visible = false;
            lblRegionDB.Visible = false;
            lblSiteDB.Visible = false;
            lblFYIMessageNameDB.Visible = false;
            drpCategoryDB.Visible = false;
            drpPlantSiteDB.Visible = false;
            drpRegionDB.Visible = false;
            txtFYIRoutedName.Visible = false;
            lblComp1.Visible = false;
            lblComp2.Visible = false;
            lblComp3.Visible = false;
            lblComp4.Visible = false;
            if (mode == "View")
            {
                lblCategoryDB.Visible = true;
                lblRegionDB.Visible = true;
                lblSiteDB.Visible = true;
                lblFYIMessageNameDB.Visible = true;
                lblComp1.Visible = false;
                lblComp2.Visible = false;
                lblComp3.Visible = false;
            }
            else if (mode == "Edit")
            {
                drpCategoryDB.Visible = true;
                drpPlantSiteDB.Visible = true;
                drpRegionDB.Visible = true;
                txtFYIRoutedName.Visible = true;
                lblComp1.Visible = true;
                lblComp2.Visible = true;
                lblComp3.Visible = true;
                lblComp4.Visible = true;
            }
        }

    }
}