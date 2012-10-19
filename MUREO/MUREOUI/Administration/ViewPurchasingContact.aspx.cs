using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data.SqlClient;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class ViewPurchasingContact : System.Web.UI.Page
    {
        #region "Variable Declarations"
        public Int32 PlantID;
        Int32 MaterialID;
        string PhNo;
        string ApproverName;
        string PlantName;
        string MaterialType;
        string PcontactID;
        Int32 returnvalue;
        #endregion
        string Script;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                txthiddenPlantID.Value = Request.QueryString["PlantID"];
                txthiddenMaterialID.Value = Request.QueryString["MaterialID"];

                PhNo = Request.QueryString["PhNo"];
                ApproverName = Request.QueryString["ApproverName"];
                PlantName = Request.QueryString["PlantName"];
                MaterialType = Request.QueryString["MaterialType"];
                PcontactID = Request.QueryString["PContactID"];
                txthiddenPurchaseContactId.Value = PcontactID;

                lblPlantName.Text = PlantName;
                lblMaterialType.Text = MaterialType;
                lblPhoneNumber.Text = PhNo;
                lblApprover.Text = ApproverName;


            }

        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Administration/AddPurchasingContact.aspx?PcontactID=" + txthiddenPurchaseContactId.Value + "&PlantID=" + txthiddenPlantID.Value + "&MaterialID=" + txthiddenMaterialID.Value + "&Mode=Edit" + "&MaterialType=" + lblMaterialType.Text + "&ApproverName=" + lblApprover.Text + "&PhoneNumber=" + Server.UrlEncode(lblPhoneNumber.Text));
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            DeleteMachine();

        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/MaintainPurchasingContacts.aspx");
        }

        protected void DeleteMachine()
        {
            PurchasingContact objDeletePurchasingContact = new PurchasingContact();

            returnvalue = -1;
            SqlParameter[] paramout = new SqlParameter[1];
            if (objDeletePurchasingContact.DeletePurchasingContact(Convert.ToInt32(txthiddenPurchaseContactId.Value), ref paramout)) ;
            if (returnvalue == 0)
            {
                //' Script = "x=alert('" & ConfigurationManager.AppSettings["DeletedSuccess") & "');if (x)window.navigate('~/Administration/MaintainPurchasingContacts.aspx') "
                //Script = "alert('" & ConfigurationManager.AppSettings["DeletedSuccess") & "');window.navigate('~/Administration/MaintainPurchasingContacts.aspx');"
                //Page.RegisterStartupScript("clientscript", script)

                //'Page.RegisterStartupScript("error_message", script)

                string script = null;
                script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

            }
            else
            {
                Script = "alert('" + ConfigurationManager.AppSettings["DeletedError"] + "');window.location='../Administration/MaintainPurchasingContacts.aspx';";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
            }
            //Response.Redirect("~/Administration/MaintainPurchasingContacts.aspx")
        }

        }
}