using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using DevExpress.Web.ASPxGridView;
using MUREOUI.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MUREOUI.Administration
{
    public partial class MaintainSystemOwner : System.Web.UI.Page
    {
        DataSet dsSystemOwner = null;
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillSystemOwners();
            }

        }
        private void FillSystemOwners()
        {
            clsSystemOwnerBO objclsSystemOwnerBO = null;
            try
            {
                dsSystemOwner = new DataSet();
                objclsSystemOwnerBO = new clsSystemOwnerBO();
                //dsSystemOwner = BusinessObject.MUREO.BusinessObject.SystemOwner.FillSystemOwner();
                if (objclsSystemOwnerBO.FillSystemOwner(ref dsSystemOwner))
                {

                    if (dsSystemOwner == null)
                    {

                    }
                    else if (dsSystemOwner.Tables.Count == 0)
                    {
                    }
                    else if (dsSystemOwner.Tables[0].Rows.Count == 0)
                    {
                        dtgrdPurchaseContact.Visible = false;

                    }
                    else
                    {
                        dtgrdPurchaseContact.DataSource = dsSystemOwner.Tables[0];
                        dtgrdPurchaseContact.DataBind();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsSystemOwner = null;
                objclsSystemOwnerBO = null;
            }

        }

        protected void imgAddSysOwner_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddSystemOwner.aspx");

        }

        protected void lnkSysOwnerName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "OwnerName_Link")
                {
                    string strApproverName = string.Empty;
                    LinkButton lkb = (LinkButton)sender;
                   // Label lblPlantID = (Label)lkb.Parent.FindControl("lblPlantID");
                   // Label lblPhNo = (Label)lkb.Parent.FindControl("lblPhNo");
                   // Label lblPlantName = (Label)lkb.Parent.FindControl("lblPlantName");
                   // Label lblApproverName = (Label)lkb.Parent.FindControl("lblApproverName");
                   //strApproverName= lkb.Text;
                   // Label lblSysOwnID = (Label)lkb.Parent.FindControl("lblSysOwnID");

                    Label lblPlntID = (Label)lkb.Parent.FindControl("lblPlantID");
                    Label lblPhNor = (Label)lkb.Parent.FindControl("lblPhNo");
                    string strHTMLSymb = string.Empty;
                    strHTMLSymb = lblPhNor.Text;
                    //string result = Regex.Replace(strHTMLSymb, "([&])", "*:", RegexOptions.None);
                    string lblPhNorValue = strHTMLSymb.Contains("&") ? Regex.Replace(strHTMLSymb, "&", "amp", RegexOptions.None) : strHTMLSymb;
                    string lblPhNorHash = lblPhNorValue.Contains("#") ? Regex.Replace(lblPhNorValue, "#", "hash", RegexOptions.None) : lblPhNorValue;
                    //string PhNorresult = lblPhNorValue;
                    string PhNorresult = lblPhNorHash;
                    Label lblPlntName = (Label)lkb.Parent.FindControl("lblPName");
                    //Label lblApproverName = (Label)lkb.Parent.FindControl("lblApproverName");
                    strApproverName = lkb.Text;
                    Label lblSysID = (Label)lkb.Parent.FindControl("lblSysOwnID");

                    Response.Redirect("~/Administration/ViewSystemOwner.aspx?PlantID=" + lblPlntID.Text + "&Mode=Edit" + "&PhNo=" + Server.UrlEncode(PhNorresult) + "&OwnerName=" + strApproverName + "&PlantName=" + lblPlntName.Text + "&lblSysOwnId=" + lblSysID.Text);
                    //Response.Redirect("~/Administration/ViewSystemOwner.aspx?PlantID=" + lblPlantID.Text + "&Mode=Edit" + "&PhNo=" + lblBrandSegment.Text);

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }




        protected void dtgrdPurchaseContact_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {

                    //Label lblPhNumber = (Label)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Phone Number"], "lblPhNumber");
                    //lblPhNumber.Text = Server.UrlEncode(lblPhNumber.Text);
                    DevExpress.Web.ASPxEditors.ASPxButton ImgDelGrp = (DevExpress.Web.ASPxEditors.ASPxButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Remove Site System Owner?"], "imgDeleteGroup");
                    //ImgDelGrp.Attributes.Add("onclick", "return confirmSystemOwnerDelete();");
                    ImgDelGrp.ClientSideEvents.Click = "function(s,e) { e.processOnServer = confirmSystemOwnerDelete(); }";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //objErrorLog.SaveErrorLog(strModule + "dgdPreScreener_HtmlRowPrepared", "Error", ex.Message, "dgdPreScreener_HtmlRowPrepared", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }

        protected void imgDeleteGroup_Command(object sender, CommandEventArgs e)
        {
            clsSystemOwnerBO objclsSystemOwnerBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            clsSecurity cls = new clsSecurity();
            int pcID;
            if (hdnResponse.Value == "Y")
            {
                if (e.CommandArgument != null)
                {
                    try
                    {
                        objclsSystemOwnerBO = new clsSystemOwnerBO();

                        if (e.CommandName == "DeletePcontact")
                        {
                            //ImageButton imgDeleteAppGrp = (ImageButton)dtgrdPurchaseContact.FindControl("imgDeleteGroup");
                            pcID = Convert.ToInt32(e.CommandArgument);

                            if (objclsSystemOwnerBO.DeleteSysOwner(pcID, ref paramOut))
                            {

                                int Result = Convert.ToInt32(paramOut[0].Value);
                                if (Result == 0)
                                {
                                    strScript = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "'); ";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                                    FillSystemOwners();

                                }
                                else
                                {

                                    strScript = "alert('" + ConfigurationManager.AppSettings["DeletedError"] + "'); ";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);

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
                        objclsSystemOwnerBO = null;
                    }
                }
            }
        }

        protected void dtgrdPurchaseContact_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillSystemOwners();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();   
            }
        }

    }
}