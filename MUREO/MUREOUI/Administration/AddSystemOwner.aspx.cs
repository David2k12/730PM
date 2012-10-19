using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;
using MUREOUI.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class AddSystemOwner : System.Web.UI.Page
    {
        clsSystemOwnerBO objclsSystemOwnerBO = null;
        clsPlantMachineBO objclsPlantMachineBO = null;
        DataSet dsPlant = null;
        clsSecurity objclsSecurity=null;
        string strScript=string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["Mode"]) == "Edit")
                {
                    trCrSo.Visible = false;
                    trEdSo.Visible = true;

                    
                    if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["PlantID"])))
                    {
                        FillPlantNames();
                        //drpPlantName.SelectedValue = Convert.ToString(Request.QueryString["PlantID"]);
                        drpPlantName.Items.FindByValue(Convert.ToString(Request.QueryString["PlantID"])).Selected = true;
                        txtSystemOwner.Text = Convert.ToString(Request.QueryString["OwnerName"]);
                        hdntxtCOName.Value = txtSystemOwner.Text;
                        //txtHiddenPurchaseContactID.Text = Convert.ToString(Request.QueryString["SysOwnID");
                        txtHiddenPurchaseContactID.Value = Convert.ToString(Request.QueryString["SysOwnID"]);
                        txtPhoneNumber.Text = Convert.ToString(Request.QueryString["PhoneNumber"]);
                    }
                    else
                    {
                        FillPlantNames();

                    }
                }
                else
                {
                    trEdSo.Visible = false;
                    trCrSo.Visible = true;
                    FillPlantNames();
                }
            }


        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToString(Request.QueryString["Mode"]) == "Edit")
            {
                UpdateSystemOwner();
            }
            else
            {
                InsertSystemOwner();
            }

        }

        private void FillPlantNames()
        {
            try
            {
                dsPlant = new DataSet();
                objclsPlantMachineBO = new clsPlantMachineBO();
                
                //BusinessObject.MUREO.BusinessObject.PlantMachine objPlantMachine = new BusinessObject.MUREO.BusinessObject.PlantMachine();
                if (objclsPlantMachineBO.FillPlantNames(0, ref dsPlant))
                {

                    //dsPlant = objPlantMachine.FillPlantNames(0);

                    if (dsPlant == null)
                    {
                    }
                    else if (dsPlant.Tables.Count == 0)
                    {
                    }
                    else if (dsPlant.Tables[0].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        drpPlantName.DataSource = dsPlant.Tables[0];
                        drpPlantName.DataTextField = "Plant_Name";
                        drpPlantName.DataValueField = "Plant_ID";
                        drpPlantName.DataBind();
                    }
                    drpPlantName.Items.Insert(0, "--- Select a Plant ---");
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsPlant = null;
                objclsPlantMachineBO = null;
            }

        }
        private void InsertSystemOwner()
        {
            string strplantId=string.Empty;
            int plantId;
            string strSystemOwnerName=string.Empty;
            string strphoneNeumber=string.Empty;
            SqlParameter[] paramOut = null;
            int returnValue;
            try
            {
                strplantId = drpPlantName.SelectedValue.ToString();


                if (drpPlantName.SelectedValue != "--- Select a Plant ---")
                {
                    plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());

                    if (Convert.ToString(hdntxtCOName.Value) != "")
                    {
                        txtSystemOwner.Text = hdntxtCOName.Value;
                    }

                    strSystemOwnerName = txtSystemOwner.Text;
                    strphoneNeumber = txtPhoneNumber.Text;
                    dsPlant = new DataSet();
                    objclsSystemOwnerBO = new clsSystemOwnerBO();
                    objclsSecurity = new clsSecurity();
                    paramOut = new SqlParameter[1];
                    string strStatus = string.Empty;
                    if (objclsSystemOwnerBO.InsUpdateEoSystemOwner(plantId, strSystemOwnerName, strphoneNeumber, 0, objclsSecurity.UserName,strStatus, ref paramOut))
                    {
                        //returnValue = Convert.ToInt32(objAddSystemOwner.AddEoSystemOwner(plantId, SystemOwnerName, phoneNeumber));
                        returnValue = Convert.ToInt32(paramOut[0].Value);
                        //txtApprover.Text = ""
                        //txtPhoneNumber.Text = ""
                        //drpPlantName.SelectedIndex = 0
                        if (returnValue == 0)
                        {
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                            // Page.RegisterStartupScript("clientscript", script);

                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "InsertSuccess", strScript);
                        }
                        else if (returnValue == 1)
                        {
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", strScript);
                        }
                        else 
                        {
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertError"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
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
                dsPlant = null;
                objclsSystemOwnerBO = null;
                objclsSecurity = null;
                paramOut = null;
            }
        }


        private void UpdateSystemOwner()
        {
            //BusinessObject.MUREO.BusinessObject.SystemOwner objAddSystemOwner = new BusinessObject.MUREO.BusinessObject.SystemOwner();
            //plantIdString = drpPlantName.SelectedValue.ToString();
            //materialIdString = drpMaterialType.SelectedValue.ToString()

            string strplantId=string.Empty;
            int plantId;
            string strSystemOwnerName=string.Empty;
            string strphoneNeumber=string.Empty;
            SqlParameter[] paramOut = null;
            int SysOwnID=0;
            int returnValue;
            try
            {
                strplantId = drpPlantName.SelectedValue.ToString();
                if (drpPlantName.SelectedValue != "--- Select a Plant ---")
                {
                    plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                    //materialID = Convert.ToInt32(drpMaterialType.SelectedValue.ToString())
                    strSystemOwnerName = txtSystemOwner.Text;
                    strphoneNeumber = txtPhoneNumber.Text;
                    //purchaseContactID = txtHiddenPurchaseContactID.Text;
                    string strIDValue = Convert.ToString(txtHiddenPurchaseContactID.Value);
                    if(strIDValue!="")
                    {
                        SysOwnID=Convert.ToInt32(strIDValue);
                    }

                    //returnValue = Convert.ToInt32(objAddSystemOwner.UpdateEoSystemOwner(plantId, SystemOwnerName, phoneNeumber, txtHiddenPurchaseContactID.Text));

                    dsPlant = new DataSet();
                    objclsSystemOwnerBO = new clsSystemOwnerBO();
                    objclsSecurity = new clsSecurity();
                    paramOut = new SqlParameter[1];
                    string strStatus = "A";
                    if (objclsSystemOwnerBO.InsUpdateEoSystemOwner(plantId, strSystemOwnerName, strphoneNeumber, SysOwnID, objclsSecurity.UserName,strStatus, ref paramOut))
                    {
                        //returnValue = Convert.ToInt32(objAddSystemOwner.AddEoSystemOwner(plantId, SystemOwnerName, phoneNeumber));
                        returnValue = Convert.ToInt32(paramOut[0].Value);
                        if (returnValue == 0)
                        {
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateSuccess") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", strScript);

                        }
                        else if (returnValue == 1)
                        {
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", strScript);
                        }
                        else 
                        {
                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');window.navigate('../Administration/MaintainSystemOwner.aspx');</script>";
                            //Page.RegisterStartupScript("clientscript", script);
                            strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateError"] + "');window.location='../Administration/MaintainSystemOwner.aspx';</script>";
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
                dsPlant = null;
                objclsSystemOwnerBO = null;
                objclsSecurity = null;
                paramOut = null;
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/MaintainSystemOwner.aspx");

        }

    }
}