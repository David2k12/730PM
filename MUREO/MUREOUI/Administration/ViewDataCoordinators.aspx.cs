using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;
using DevExpress.Web.ASPxGridView;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class ViewDataCoordinators : System.Web.UI.Page
    {
        ViewDataCoordinatorsBO objDataCoordinatorBO = null;
        clsSecurity clsm = new clsSecurity();
        SqlParameter[] paramout = null;
        string strScript=string.Empty;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                FillDataCoordinatorDetails();
            }
        }

        private void FillDataCoordinatorDetails()
        {
            DataSet dsCoDetails = null;
            try
            {
                dsCoDetails = new DataSet();
                objDataCoordinatorBO = new ViewDataCoordinatorsBO();
                if (objDataCoordinatorBO.GetDataCoordinatorDetailsBO(0, ref dsCoDetails))
                {

                    if (dsCoDetails == null)
                    {
                        NoRecords();
                    }
                    else if (dsCoDetails.Tables.Count == 0)
                    {
                        NoRecords();
                    }
                    else if (dsCoDetails.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {
                        drgCo.DataSource = dsCoDetails;
                        drgCo.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsCoDetails = null;
                objDataCoordinatorBO = null;
            }
        }

       /* private void drgCO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:
                    ImageButton ImgDeleteCo = (ImageButton)e.Item.FindControl("ImgDeleteCo");
                    LinkButton lnkCOName = (LinkButton)e.Item.FindControl("lnkCOName");
                    ImgDeleteCo.Attributes.Add("onclick", "return confirmCODelete('" + lnkCOName.Text + "');");
                    break;
            }

        }*/

        /*private void drgCO_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "View_CO")
            {
                Response.Redirect("../Administration/ViewDataCoordinator.aspx?DO_ID=" + e.CommandArgument);
            }
            else if (e.CommandName.ToLower().StartsWith("deleteco"))
            {
                if (Request.Form("Response") == "Y")
                {
                    DeleteCO(Convert.ToInt32(e.CommandArgument));
                }
            }
        }*/



        protected void lnkCOName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View_CO")
                {   
                    //Response.Redirect("~/Administration/ViewDataCoordinator.aspx?DO_ID=" + e.CommandArgument);
                    Server.Transfer("~/Administration/ViewDataCoordinator.aspx?DO_ID=" + e.CommandArgument);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void DeleteCO(int CO_ID)
        {
            objDataCoordinatorBO = new ViewDataCoordinatorsBO();
            paramout = new SqlParameter[1];
            try
            {
                if (objDataCoordinatorBO.InsertDataCoordinatorBO(CO_ID, 0, "", "", clsm.UserName, "I", ref paramout))
                {
                    int result = Convert.ToInt32(paramout[0].Value);
                    if (result == 0)
                    {
                        strScript = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "'); window.location='ViewDataCoordinators.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                    }
                    else
                    {
                        strScript = "alert('" + Convert.ToString(ConfigurationManager.AppSettings["DeleteError"]) + "');  ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objDataCoordinatorBO = null;
                paramout = null;
            }

        }
        private void NoRecords()
        {   
            strScript = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", strScript, true);
        }

        

        protected void drgCo_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                DevExpress.Web.ASPxEditors.ASPxButton btnDelete = (DevExpress.Web.ASPxEditors.ASPxButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Delete Data Coordinator"], "ImgDeleteCo");
                LinkButton lnkCOName = (LinkButton)gvDetailGridView.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)gvDetailGridView.Columns["Data Coordinator"], "lnkCOName");

                if (btnDelete != null)
                {
                    //btnDelete.Attributes.Add("onclick", "return confirmCODelete('" + lnkCOName.Text + "');");
                    btnDelete.ClientSideEvents.Click = "function(s,e) { e.processOnServer = confirmCODelete('" + lnkCOName.Text + "'); }";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
            }
        }

        protected void imgCreateBdgtCtr_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/Administration/AddDataCoordinator.aspx");
            Server.Transfer("~/Administration/AddDataCoordinator.aspx");
        }

        protected void ImgDeleteCo_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToLower().StartsWith("deleteco"))
                {
                    if (hdnResponse.Value == "Y")
                    {
                        DeleteCO(Convert.ToInt32(e.CommandArgument));
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void drgCo_PageIndexChanged(object sender, EventArgs e)
        {
            FillDataCoordinatorDetails();
        }
    }
}