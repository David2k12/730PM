using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Administration
{
    public partial class ViewCoachingBoxes : System.Web.UI.Page
    {
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCoachMsg();
            }

        }

        private void FillCoachMsg()
        {
            DataSet dsCoach = null;
            CoachingBoxBO objCoachingBoxBO = null;
            try
            {

                dsCoach = new DataSet();
                objCoachingBoxBO = new CoachingBoxBO();
                if (objCoachingBoxBO.GetCoachingBoxBO(0, ref dsCoach))
                {
                    //dsCoach = CoachingBoxBO.GetCoachingBoxDA(0);
                    if (dsCoach == null)
                    {
                        NoRecords();
                    }
                    else if (dsCoach.Tables.Count == 0)
                    {
                        NoRecords();
                    }
                    else if (dsCoach.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {
                        dgdCoach.DataSource = dsCoach;
                        dgdCoach.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
            finally
            {
                dsCoach = null;
                objCoachingBoxBO = null;
            }

        }
        private void NoRecords()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "NoRecords", strScript);

        }

        protected void dgdCoach_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                ASPxGridView gvDetailGridView = (ASPxGridView)sender;
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {

                    ImageButton ImgDelGrp = (ImageButton)dgdCoach.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdCoach.Columns["Delete Message"], "imgDeleteGroup");
                    ImgDelGrp.Attributes.Add("onclick", "return confirmBrandSegDelete();");
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //objErrorLog.SaveErrorLog(strModule + "dgdPreScreener_HtmlRowPrepared", "Error", ex.Message, "dgdPreScreener_HtmlRowPrepared", m_strDnsHostName, m_strLoggedUser, ErrorLog.LogMessageType.LogError);
            }
        }

        protected void imgAdd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/AddCoachingBox.aspx");

        }

        protected void imgDeleteGroup_Command(object sender, CommandEventArgs e)
        {
            clsBasicinfoBO objclsBasicinfoBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            clsSecurity cls=new clsSecurity();
            int BrandSegId;
            if (hdnResponse.Value == "Y")
            {
                if (e.CommandArgument != null)
                {
                    try
                    {
                        objclsBasicinfoBO = new clsBasicinfoBO();



                        if (e.CommandName == "DeleteMessage")
                        {
                            Label lblCoachMsgID = (Label)dgdCoach.FindControl("lblCoachMsgID");
                            ImageButton imgDeleteAppGrp = (ImageButton)dgdCoach.FindControl("imgDeleteGroup");
                            BrandSegId = Convert.ToInt32(e.CommandArgument);

                            if (objclsBasicinfoBO.BasicInfoDeleteCheck("Coaching_Box", BrandSegId, cls.UserName, ref paramOut))
                            {

                                int Result = Convert.ToInt32(paramOut[0].Value);
                                if (Result == 1)
                                {
                                    //Me.DeleteOperationMessage(Result)
                                   // string tempStr = null;
                                    //script = "<script>confirmBrandSegDelete('" + BrandSegId + "','" + System.Security.UserName + "' );</script> ";
                                    //popResult=window.showModalDialog('ApproveYesNo.aspx?EOID='+EoID+'&Type=A',null,'dialogHeight:200px;dialogWidth:400px');
                                    strScript = "<script>BrandSegDelete('" + BrandSegId + "','" + cls.UserName + "' );</script> ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Delete", strScript);
                                    FillCoachMsg();
                                }
                                else
                                {
                                    //script = "<script>alert('Message.'+ '\n' + 'Please update respective projects information with other brands before deleting.');</script> "
                                   // script = "<script>alert('Coaching Box message cannot be deleted as it is associated with other records.');</script> ";

                                    strScript = "<script>alert('Coaching Box message cannot be deleted as it is associated with other records.');</script> ";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Error", strScript);

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
                        objclsBasicinfoBO = null;
                    }
                }
            }
        }

        protected void lnkCoachMsgName_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View_Coach")
                {  
                    Response.Redirect("~/Administration/ViewCoachingBox.aspx?Co_Box_id=" + e.CommandArgument);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}