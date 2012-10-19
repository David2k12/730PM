using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Configuration;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddPurchasingContact : System.Web.UI.Page
    {
        #region "Variable Declarations"
        DataSet dsPlant;
        DataSet dsMaterial;
        Int32 plantId;
        string plantName;
        string script;
        string machineName;
        Int32 returnValue;
        string plantIdString;
        string ApproverName;
        string materialIdString;
        Int32 materialID;
        string phoneNeumber;
        #endregion
        Int32 purchaseContactID;

        protected void Page_Load(object sender, EventArgs e)
        {
            imgAddressBook.Attributes.Add("onclick", "javascript:return AddBooksingUser();");
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Mode"] == "Edit")
                {
                    trCreatePC.Visible = false;
                    trEditPC.Visible = true;

                    //Edit Mode 
                    //plantId = CInt(Request.QueryString["PlantID"))
                    //materialID = CInt(Request.QueryString["MaterialID"))
                    //PlantName=" + lblPlantName.Text + "&Mode=Edit" + "&MaterialType=" + lblMaterialType.Text + "&ApproverName=" + lblApprover.Text + "&PhoneNumber=" + lblPhoneNumber.Text)
                    if (!string.IsNullOrEmpty(Request.QueryString["MaterialID"]) & !string.IsNullOrEmpty(Request.QueryString["PlantID"]))
                    {
                        FillPlantNames();
                        FillMaterials();
                        drpPlantName.SelectedValue = Request.QueryString["PlantID"];
                        drpMaterialType.SelectedValue = Request.QueryString["MaterialID"];
                        txtApprover.Text = Request.QueryString["ApproverName"];
                        txtHiddenPurchaseContactID.Value = Request.QueryString["PcontactID"];
                        txtPhoneNumber.Text = Request.QueryString["PhoneNumber"];
                    }
                    else
                    {
                        FillPlantNames();
                        FillMaterials();

                    }
                }
                else
                {
                    trEditPC.Visible = false;
                    trCreatePC.Visible = true;

                    FillPlantNames();
                    FillMaterials();

                }


            }


        }

        protected void FillPlantNames()
        {
            dsPlant = new DataSet();
            PlantMachine objPlantMachine = new PlantMachine();

            if (objPlantMachine.FillPlantMachines(0, ref dsPlant))
            {

            }

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
                drpPlantName.DataSource = dsPlant;
                drpPlantName.DataTextField = "Plant_Name";
                drpPlantName.DataValueField = "Plant_ID";
                drpPlantName.DataBind();
            }
            drpPlantName.Items.Insert(0, "--- Select a Plant ---");
        }
        protected void FillMaterials()
        {
            dsMaterial = new DataSet();
            //Dim objPlantMachine As New BusinessObject.MUREO.BusinessObject.PurchasingContact
            PurchasingContact pur = new PurchasingContact();
            if (pur.FillMaterial(ref dsMaterial))
            {
                if (dsMaterial == null)
                {
                }
                else if (dsMaterial.Tables.Count == 0)
                {
                }
                else if (dsMaterial.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    drpMaterialType.DataSource = dsMaterial;
                    drpMaterialType.DataTextField = "Material_Type_Name";
                    drpMaterialType.DataValueField = "Material_Type_ID";
                    drpMaterialType.DataBind();

                }
                drpMaterialType.Items.Insert(0, "--- Select Material Type ---");
            }

        }


        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtApprover.Value))
                txtApprover.Text = hdntxtApprover.Value;
            if (Request.QueryString["Mode"] == "Edit")
            {
                UpdatePurchaseContact();
            }
            else
            {
                InsertPurchaseContact();
            }
        }

        protected void InsertPurchaseContact()
        {
            PurchasingContact objAddPurchasingContact = new PurchasingContact();
            plantIdString = drpPlantName.SelectedValue.ToString();
            materialIdString = drpMaterialType.SelectedValue.ToString();
            if (drpPlantName.SelectedValue != "--- Select a Plant ---" & drpMaterialType.SelectedValue != "--- Select Material Type ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                materialID = Convert.ToInt32(drpMaterialType.SelectedValue.ToString());
                ApproverName = txtApprover.Text;
                phoneNeumber = txtPhoneNumber.Text;
                returnValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (objAddPurchasingContact.AddEoPurchasingContact(plantId, materialID, ApproverName, phoneNeumber, ref paramout))
                {
                    returnValue =Convert.ToInt32(paramout[0].Value);
                    //txtApprover.Text = ""
                    //txtPhoneNumber.Text = ""
                    //drpPlantName.SelectedIndex = 0
                    if (returnValue == 0)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (returnValue == 1)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["DuplicatePurchasing"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["InsertError"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
        }
        protected void UpdatePurchaseContact()
        {
            PurchasingContact objAddPurchasingContact = new PurchasingContact();
            plantIdString = drpPlantName.SelectedValue.ToString();
            materialIdString = drpMaterialType.SelectedValue.ToString();

            if (drpPlantName.SelectedValue != "--- Select a Plant ---" & drpMaterialType.SelectedValue != "--- Select Material Type ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                materialID = Convert.ToInt32(drpMaterialType.SelectedValue.ToString());
                ApproverName = txtApprover.Text;
                phoneNeumber = txtPhoneNumber.Text;
                purchaseContactID =Convert.ToInt32(txtHiddenPurchaseContactID.Value);
                returnValue =-1;
                SqlParameter[] paramout=new SqlParameter[1];
                if (objAddPurchasingContact.UpdateEoPurchasingContact(plantId, materialID, ApproverName, phoneNeumber, purchaseContactID, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);
                    txtApprover.Text = "";
                    txtPhoneNumber.Text = "";
                    //drpPlantName.SelectedIndex = 0
                    returnValue =Convert.ToInt32(paramout[0].Value);
                    if (returnValue == 0)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (returnValue == 1)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["DuplicatePurchasing"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                    }
                    else
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }

            }
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/MaintainPurchasingContacts.aspx");

        }


    }
}