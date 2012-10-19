using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class AddPreScreenerGroup : System.Web.UI.Page
    {
        string strScript = string.Empty;
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgAddressBook1.Attributes.Add("onclick", "javascript: AddBookMultiUser();");
            //imgAddressBook2.Attributes.Add("onclick", "javascript: AddBookMultiUser1();");
            if (!string.IsNullOrEmpty(hdntxtPrjLead.Value))
            {
                txtPreScreenerGroup.Text = hdntxtPrjLead.Value;
            }
            if (!string.IsNullOrEmpty(hdntxtPrjLead1.Value))
            {
                txtPreScreenerBackup.Text = hdntxtPrjLead1.Value;
            }
            imgAddressBook1.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
            imgAddressBook2.Attributes.Add("onclick", "javascript:return AddBookMultiUser1();");
            imgSaveExit.Attributes.Add("OnClick", "javascript:return Validate();");
            //Confirm box for Deleting project lead and PoC names
            imgDeletePrescreener.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the prescreener backup name? Click OK to delete or CANCEL to abort.');");

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Mode"] == "New")
                {
                    trEdPS.Visible = false;
                    trViPs.Visible = false;
                    trCrPs.Visible = true;
                    trMFields.Visible = true;

                    ShowFields("New");
                    imgEdit.Visible = false;
                    imgSaveExit.Visible = true;
                    lblComp1.Visible = true;
                    lblComp2.Visible = true;
                    imgDeletePrescreener.Visible = true;
                }
                else if (Request.QueryString["Mode"] == "Edit")
                {
                    trEdPS.Visible = true;
                    trViPs.Visible = false;
                    trCrPs.Visible = false;
                    trMFields.Visible = true;


                    if ((Request.QueryString["ID"] != null))
                    {
                        GetPrescreenerData(Convert.ToInt32(Request.QueryString["ID"]));
                        ShowFields("Edit");

                        imgEdit.Visible = false;
                        imgSaveExit.Visible = true;
                        lblComp1.Visible = true;
                        lblComp2.Visible = true;
                        imgDeletePrescreener.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("~/Administration/ViewPreScreenerGroup.aspx");

                    }
                }
                else if (Request.QueryString["Mode"] == "View")
                {
                    trEdPS.Visible = false;
                    trViPs.Visible = true;
                    trCrPs.Visible = false;
                    trMFields.Visible = false;

                    if (Convert.ToString(Request.QueryString["ID"] )!= "")
                    {
                        GetPrescreenerData(Convert.ToInt32(Request.QueryString["ID"]));
                        ShowFields("View");

                        imgEdit.Visible = true;
                        imgSaveExit.Visible = false;
                        imgAddressBook1.Visible = false;
                        imgAddressBook2.Visible = false;
                        lblComp1.Visible = false;
                        lblComp2.Visible = false;
                        imgDeletePrescreener.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("~/Administration/ViewPreScreenerGroup.aspx");
                    }
                }
            }

        }

        protected void imgDeletePrescreener_Click(object sender, ImageClickEventArgs e)
        {
            txtPreScreenerBackup.Text = "";
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Mode"] == "View")
            {
                Response.Redirect("~/Administration/ViewPreScreenerGroup.aspx");
            }
            else if (Request.QueryString["Mode"] == "Edit")
            {
                Response.Redirect("~/Administration/AddPreScreenerGroup.aspx?Mode=View&ID=" + Request.QueryString["ID"]);
            }
            else if (Request.QueryString["Mode"] == "New")
            {
                Response.Redirect("~/Administration/ViewPreScreenerGroup.aspx");
            }

        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddPreScreenerGroup.aspx?Mode=Edit&ID=" + Request.QueryString["ID"]);

        }

        protected void imgSaveExit_Click(object sender, ImageClickEventArgs e)
        {
            int RetValue = 0;
            clsPrescreenersBO objclsPrescreenersBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            try
            {
                if (Request.QueryString["Mode"] == "New")
                {
                    objclsPrescreenersBO = new clsPrescreenersBO();
                    if (Convert.ToString(hdntxtPrjLead.Value) != "")
                        txtPreScreenerGroup.Text = hdntxtPrjLead.Value;
                    if (Convert.ToString(hdntxtPrjLead1.Value) != "")
                        txtPreScreenerBackup.Text = hdntxtPrjLead1.Value;
                    if (objclsPrescreenersBO.AddUpdatePreScreenerGroup(txtPreScreener.Text.Trim(), txtPreScreenerGroup.Text, txtPreScreenerBackup.Text, cls.UserName, 0, "A", ref paramOut))
                    {
                        RetValue = Convert.ToInt32(paramOut[0].Value);
                        // RetValue = BusinessObject.MUREO.BusinessObject.clsPreScreeners.AddUpdatePreScreenerGroup(txtPreScreener.Text.Trim(), txtPreScreenerGroup.Text, txtPreScreenerBackup.Text, 0, "A");
                        if (RetValue == 0)
                        {
                            //Success Message
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');";
                            // script = script + "window.location='../Administration/ViewPrescreenerGroup.aspx'</script> ";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='../Administration/ViewPrescreenerGroup.aspx';</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "InsertSuccess", strScript);
                        }
                        else if (RetValue == 1)
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
                else if (Request.QueryString["Mode"] == "Edit")
                {
                    RetValue = 0;
                    objclsPrescreenersBO = new clsPrescreenersBO();
                   // RetValue = BusinessObject.MUREO.BusinessObject.clsPreScreeners.AddUpdatePreScreenerGroup(txtPreScreener.Text.Trim(), txtPreScreenerGroup.Text, txtPreScreenerBackup.Text, Request.QueryString["ID"], "A");
                    if (objclsPrescreenersBO.AddUpdatePreScreenerGroup(txtPreScreener.Text.Trim(), txtPreScreenerGroup.Text, txtPreScreenerBackup.Text, cls.UserName, Convert.ToInt32(Request.QueryString["ID"]), "A", ref paramOut))
                    {
                        RetValue = Convert.ToInt32(paramOut[0].Value);
                        if (RetValue == 0)
                        {
                            //Success Message
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateSuccess") + "');";
                            //script = script + "window.location='../Administration/ViewPrescreenerGroup.aspx'</script> ";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='../Administration/ViewPrescreenerGroup.aspx';</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", strScript);
                        }
                        else if (RetValue == 1)
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
                objclsPrescreenersBO = null;
            }
        }

        private void GetPrescreenerData(int iPreScreenerGroupID)
        {
            hdntxtPrjLead.Value="";
            hdntxtPrjLead1.Value = "";
            DataSet dsPreScreenerData = null;
            clsPrescreenersBO objclsPrescreenersBO = null;
            try
            {
                dsPreScreenerData = new DataSet();
                objclsPrescreenersBO = new clsPrescreenersBO();
                if (objclsPrescreenersBO.GetPreScreenerData(iPreScreenerGroupID, ref dsPreScreenerData))
                {
                    //dsPreScreenerData = BusinessObject.MUREO.BusinessObject.clsPreScreeners.GetPreScreenerData(iPreScreenerGroupID);
                    //for Defect ID 337 swapping these fields 
                    txtPreScreener.Text = Convert.ToString(dsPreScreenerData.Tables[0].Rows[0]["PreScreener_Group_Name"]);
                    txtPreScreenerGroup.Text = Convert.ToString(dsPreScreenerData.Tables[0].Rows[0]["Primary_Approver_Name"]);
                    hdntxtPrjLead.Value = txtPreScreenerGroup.Text;

                    txtPreScreenerBackup.Text =Convert.ToString(dsPreScreenerData.Tables[0].Rows[0]["Backup_Approver_Name"]);
                    hdntxtPrjLead1.Value = txtPreScreenerBackup.Text;
                    lblPreScreenerDB.Text = Convert.ToString(dsPreScreenerData.Tables[0].Rows[0]["PreScreener_Group_Name"]);
                    lblPreScreenerNameDB.Text = Convert.ToString(dsPreScreenerData.Tables[0].Rows[0]["Primary_Approver_Name"]);
                    hdntxtPrjLead.Value = lblPreScreenerNameDB.Text;
                    lblPreScreenerBackupDB.Text = Convert.ToString(dsPreScreenerData.Tables[0].Rows[0]["Backup_Approver_Name"]);
                    hdntxtPrjLead1.Value = lblPreScreenerBackupDB.Text;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsPreScreenerData = null;
                objclsPrescreenersBO = null;
            }
        }

        private void ShowFields(string mode)
        {
            lblPreScreenerDB.Visible = false;
            lblPreScreenerNameDB.Visible = false;
            lblPreScreenerBackupDB.Visible = false;
            txtPreScreener.Visible = false;
            txtPreScreenerGroup.Visible = false;
            txtPreScreenerBackup.Visible = false;

            if (mode == "New" | mode == "Edit")
            {
                txtPreScreener.Visible = true;
                txtPreScreenerGroup.Visible = true;
                txtPreScreenerBackup.Visible = true;
            }
            else if (mode == "View")
            {
                lblPreScreenerDB.Visible = true;
                lblPreScreenerNameDB.Visible = true;
                lblPreScreenerBackupDB.Visible = true;
            }
        }

        public void ShowAddUpdateDetails()
        {
            lblPreScreenerDB.Visible = false;
            lblPreScreenerNameDB.Visible = false;
            lblPreScreenerBackupDB.Visible = false;
            txtPreScreener.Visible = true;
            txtPreScreenerGroup.Visible = true;
            txtPreScreenerBackup.Visible = true;
        }
        public void ShowViewDetails()
        {
            lblPreScreenerDB.Visible = true;
            lblPreScreenerNameDB.Visible = true;
            lblPreScreenerBackupDB.Visible = true;
            txtPreScreener.Visible = false;
            txtPreScreenerGroup.Visible = false;
            txtPreScreenerBackup.Visible = false;
        }
    }
}