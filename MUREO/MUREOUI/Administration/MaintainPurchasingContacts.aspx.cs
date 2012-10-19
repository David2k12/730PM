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
using DevExpress.Web.ASPxGridView;

namespace MUREOUI.Administration
{
    public partial class MaintainPurchasingContacts : System.Web.UI.Page
    {
        #region "Variable Declarations"
        DataSet dsPurchaseContact;
        Int32 returnvalue;
        #endregion
        string Script;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillMachinesByPlant();
            }


        }


        protected void FillMachinesByPlant()
        {
            dsPurchaseContact = new DataSet();
            PurchasingContact psc = new PurchasingContact();
            if (psc.FillPurchaseContact(ref dsPurchaseContact))
            {
                if (dsPurchaseContact == null)
                {

                }
                else if (dsPurchaseContact.Tables.Count == 0)
                {
                }
                else if (dsPurchaseContact.Tables[0].Rows.Count == 0)
                {
                    dtgrdPurchaseContact.Visible = false;


                }
                else
                {
                    dtgrdPurchaseContact.DataSource = dsPurchaseContact;
                    dtgrdPurchaseContact.DataBind();
                }
            }

        }
        protected void lnkApproverName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                LinkButton lkb = (LinkButton)sender;
                
                if(e.CommandName!=null)
                    Response.Redirect("~/Administration/ViewPurchasingContact.aspx?MaterialID=" + Convert.ToString(e.CommandName) + "&Mode=Edit" + "&PlantID=" + Convert.ToString(e.CommandArgument) + "&PhNo=" + Server.UrlEncode(Convert.ToString(lkb.Attributes["phno"])) + "&ApproverName=" + Convert.ToString(lkb.Attributes["ApproverName"]) + "&PlantName=" + Convert.ToString(lkb.Attributes["PlantName"]) + "&MaterialType=" + Convert.ToString(lkb.Attributes["MaterialType"]) + "&PContactID=" + Convert.ToString(lkb.Attributes["PContactID"]));
            }
            catch (Exception exc)
            {
                
                
            }
        }

        //        
        //    
        protected void imgDeleteGroup_Command(object sender, CommandEventArgs e)
        {

            if (hdnresponse.Value == "Y" && e.CommandName != null)
            {
                int pcID = Convert.ToInt32(e.CommandArgument);
                DeleteMachine(pcID);
                dtgrdPurchaseContact.DataSource = "";
                dtgrdPurchaseContact.DataBind();
                FillMachinesByPlant();
            }
        }


        //protected void dtgrdPurchaseContact_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    //when user clicks on category expand image button then application will execute below code
        //    // this code will diplay brand names

        //    if (e.CommandName == "DeletePcontact")
        //    {
        //        if (hdnresponse.Value == "Y")
        //        {
        //            int pcID = Convert.ToInt32(e.CommandArgument);
        //            DeleteMachine(pcID);
        //            dtgrdPurchaseContact.DataSource = "";
        //            dtgrdPurchaseContact.DataBind();
        //            FillMachinesByPlant();
        //        }

        //    }

        //    if (e.CommandName == "MachineName_Link")
        //    {
        //        Label lblMaterialID = (Label)e.Item.FindControl("lblMaterialID");
        //        Label lblPlantID = (Label)e.Item.FindControl("lblPlantID");
        //        Label lblPhNo = (Label)e.Item.FindControl("lblPhNo");
        //        Label lblPlantName = (Label)e.Item.FindControl("lblPName");
        //        Label lblMaterialName = (Label)e.Item.FindControl("lblMname");
        //        Label lblApproverName = (Label)e.Item.FindControl("lblApproverName");
        //        Label lblPContactID = (Label)e.Item.FindControl("lblPcontactID");
        //        Response.Redirect("~/Administration/ViewPurchasingContact.aspx?MaterialID=" + lblMaterialID.Text + "&Mode=Edit" + "&PlantID=" + lblPlantID.Text + "&PhNo=" + lblPhNo.Text + "&ApproverName=" + lblApproverName.Text + "&PlantName=" + lblPlantName.Text + "&MaterialType=" + lblMaterialName.Text + "&PContactID=" + lblPContactID.Text);
        //    }





        //}
        protected void DeleteMachine(int pcID)
        {
            PurchasingContact objDeletePurchasingContact = new PurchasingContact();

            returnvalue = -1;
            SqlParameter[] paramout = new SqlParameter[1];
            if (objDeletePurchasingContact.DeletePurchasingContact(pcID, ref paramout))
            {
                returnvalue = Convert.ToInt32(paramout[0].Value);
                if (returnvalue == 0)
                {
                    Script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                }
                else
                {
                    Script = "alert('" + ConfigurationManager.AppSettings["DeletedError"] + "')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                }
            }

        }

        protected void dtgrdPurchaseContact_PageIndexChanged(object sender, EventArgs e)
        {
            FillMachinesByPlant();
        }
        protected void dtgrdPurchaseContact_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    DevExpress.Web.ASPxEditors.ASPxButton imgDeleteGroup = (DevExpress.Web.ASPxEditors.ASPxButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Remove Purchasing Contact"], "imgDeleteGroup");
                    Label lnkApproverName = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Purchasing Contact"], "lblApproverName");
                   // imgDeleteGroup.Attributes.Add("onclick", "javascript:return confirmPurchasingContactDelete('" + lnkApproverName.Text + "');");
                    imgDeleteGroup.ClientSideEvents.Click = "function(s,e) { e.processOnServer = confirmPurchasingContactDelete('" + lnkApproverName.Text + "'); }";
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void dtgrdPurchaseContact_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void imgAddPContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddPurchasingContact.aspx");
        }

    }
}