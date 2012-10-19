using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data.SqlClient;
using MUREOUI.Common;

namespace MUREOUI.Reports
{
    public partial class EODelete : System.Web.UI.Page
    {
        ClsMyEOs clsmeo = new ClsMyEOs();
        clsSecurity clsm= new clsSecurity();
        string hdnValue = string.Empty;
        string hdnstage = string.Empty;
        string btnDel = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnValue = Convert.ToString(Request.QueryString["HdnStat"]);
            hdnstage = Convert.ToString(Request.QueryString["hdnstage"]);
            btnDel = Convert.ToString(Request.QueryString["btnDel"]);
            //Put user code to initialize the page here
            if (!IsPostBack)
            {
                int intEOID = 0;
                string strCurrentStage = null;
                intEOID =Convert.ToInt32(Request.QueryString["EventID"]);
                strCurrentStage = Request.QueryString["stage"];
                ViewState["EOID"] = intEOID;
                ViewState["Stage"] = strCurrentStage;
                SecondTable.Visible = false;
               
                if (strCurrentStage.ToUpper() == "Site Test".ToUpper())
                {
                    DeleteSite.Visible = true;
                    DeleteEO.Visible = false;
                }
                else
                {
                    DeleteEO.Visible = true;
                    DeleteSite.Visible = false;
                }
            }
        }

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnConfirmYes_Click(object sender, EventArgs e)
        {
         
        }

        protected void btnConfirmNo_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnDeleteYes_Click1(object sender, EventArgs e)
        {
            FirstTable.Visible = false;
            SecondTable.Visible = true;
            string strCurrentStage = Convert.ToString(ViewState["Stage"]);
            if (strCurrentStage.ToUpper() == "Site Test".ToUpper())
            {
                DeleteEOEvents.Visible = false;
                DeleteSiteEvents.Visible = true;
            }
            else
            {
                DeleteEOEvents.Visible = true;
                DeleteSiteEvents.Visible = false;
            }
        
        }

        protected void btnDeleteNo_Click1(object sender, EventArgs e)
        {
            string script = null;
            
            script = "window.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void btnConfirmYes_Click1(object sender, EventArgs e)
        {
            string script = null;
            int intEOID = 0;
            if (ViewState["EOID"] != null)
                intEOID = Convert.ToInt32(ViewState["EOID"]);
            int intRetValue = -1;
            SqlParameter[] paramout = new SqlParameter[1];
            if (clsmeo.DeleteEO(intEOID, clsm.UserName, ref paramout))
            {
                intRetValue = Convert.ToInt32(paramout[0].Value);
                if (intRetValue == 0)
                {
                    //strScript = "<script>alert('" & ConfigurationSettings.AppSettings("EOEventDeleteSuccess") & "');</script>"
                    //Page.RegisterStartupScript("ClientScript", strScript)
                    Session["Ret"] = "E";
                    Session["Status"] = Request.QueryString["stage"];
                    //script ="window.opener.document.forms(0)." + hdnValue + ".value ='E';";
                    //script = "window.opener.document.forms(0)." + hdnstage + ".value ='" + Request.QueryString["stage"] + "';";
                    script = "window.opener.document.forms(0)." + btnDel + ".click();";
                    script = script + "window.returnValue = 'E';";
                    script = script + "window.close();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    //dgdEventInfo.Visible = False
                    //lblEOTitleVal.Visible = False
                }
                else if (intRetValue == 1)
                {
                    //strScript = "<script>alert('" & ConfigurationSettings.AppSettings("RecordDeletionFailure") & "');</script>"
                    //Page.RegisterStartupScript("ClientScript", strScript)
                    
                    script = "window.opener.document.forms(0)." + hdnValue + ".value ='F'";
                    script = script + "window.close();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }

        protected void btnConfirmNo_Click1(object sender, EventArgs e)
        {
            string strScript = null;
            string script = null;
            int intEOID = 0;
            if (ViewState["EOID"] != null)
                intEOID = Convert.ToInt32(ViewState["EOID"]);

            int intRetValue = -1;
            SqlParameter[] paramout = new SqlParameter[1];

            if (clsmeo.DeleteStopCancelEO(intEOID, 'D', clsm.UserName, ref paramout))
            {
                intRetValue = Convert.ToInt32(paramout[0].Value);
                if (intRetValue == 0)
                {
                    // strScript = "<script>alert('" & ConfigurationSettings.AppSettings("EODeleteSuccess") & "');</script>"
                    //Page.RegisterStartupScript("ClientScript", strScript)
                    
                    script = "window.opener.document.forms(0)." + hdnValue + ".value ='D'";
                    script = script + "window.close();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    //dgdEventInfo.Visible = False
                    //lblEOTitleVal.Visible = False
                }
                else if (intRetValue == 1)
                {
                 
                    script = script + "window.opener.document.forms(0)." + hdnValue + ".value ='D'";
                    script = script + "window.close();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
        }

    }
}