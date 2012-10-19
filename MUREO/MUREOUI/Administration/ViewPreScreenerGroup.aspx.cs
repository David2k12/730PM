using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web.ASPxGridView;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class ViewPreScreenerGroup : System.Web.UI.Page
    {
        clsSecurity cls = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            if (!IsPostBack)
            {
                FillDataGrid();
            }
        }

        private void FillDataGrid()
        {
            DataSet dsSeedData = null;
            clsPrescreenersBO objclsPrescreenersBO = null;
            try
            {
                dsSeedData = new DataSet();
                objclsPrescreenersBO=new clsPrescreenersBO();
                //dsSeedData = BusinessObject.MUREO.BusinessObject.clsPreScreeners.GetPreScreenerData(0);
                if (objclsPrescreenersBO.GetPreScreenerData(0, ref dsSeedData))
                {
                    if (dsSeedData == null)
                    {
                        dgdPreScreener.Visible = false;
                        return;
                    }
                    else if (dsSeedData.Tables.Count == 0)
                    {
                        dgdPreScreener.Visible = false;
                        return;
                    }
                    else if (dsSeedData.Tables[0].Rows.Count == 0)
                    {
                        dgdPreScreener.Visible = false;
                        return;
                    }
                    else
                    {
                        //dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data")
                        dgdPreScreener.DataSource = dsSeedData.Tables[0].DefaultView;
                        dgdPreScreener.DataBind();
                    }
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

        protected void btnCreateNewPrescreen_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddPreScreenerGroup.aspx?Mode=New");
        }

        protected void dgdPreScreener_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    ImageButton ImgDelGrp = (ImageButton)dgdPreScreener.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdPreScreener.Columns["Delete Group"], "imgbDelete");
                    //LinkButton lnkPrescreeners = (LinkButton)dgdPreScreener.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdPreScreener.Columns["Prescreener"], "hylPrescreeners");
                   
                    ImgDelGrp.Attributes.Add("onclick", "return confirmDelete();");
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //objErrorLog.SaveErrorLog(strModule + "dgdPreScreener_HtmlRowPrepared", "Error", ex.Message, "dgdPreScreener_HtmlRowPrepared", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }
        protected void hylPrescreeners_Command(object sender, CommandEventArgs e)
        {   
            try
            {
                if (e.CommandArgument != null)
                    Response.Redirect("~/Administration/AddPreScreenerGroup.aspx?Mode=View&ID=" + e.CommandArgument.ToString());
            }
            catch (Exception exc)
            {
                exc.Message.ToString();
            }
        }

        protected void imgbDelete_Command(object sender, CommandEventArgs e)
        {
            clsPrescreenersBO objclsPrescreenersBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            if (hdnResponse.Value == "Y")
            {
                if (e.CommandArgument != null)
                {
                    try
                    {
                        objclsPrescreenersBO = new clsPrescreenersBO();
                        if(objclsPrescreenersBO.AddUpdatePreScreenerGroup("","","",cls.UserName,Convert.ToInt32(e.CommandArgument),"I",ref paramOut))
                        {
                            int iRetValue=Convert.ToInt32(paramOut[0].Value);
                            FillDataGrid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                    finally
                    {
                        objclsPrescreenersBO=null;
                    }
                }
            }
        }

        protected void dgdPreScreener_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDataGrid();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }       
    }
}