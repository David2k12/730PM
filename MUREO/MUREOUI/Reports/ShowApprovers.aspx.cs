using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOPROP;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Mail;
using System.Text;
using MUREOUI.Common;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
namespace MUREOUI.Reports
{
    public partial class ShowApprovers : System.Web.UI.Page
    {
        ClsMyEOs objClsMyEOs = new ClsMyEOs();

        protected void Page_Load(object sender, EventArgs e)
        {
            int intEOID;
            string strCurrentStage;
            intEOID = Convert.ToInt32(Request.QueryString["EventID"].ToString().Trim());
            strCurrentStage = Request.QueryString["stage"];
            DataSet dsApprovar = new DataSet();
            if (objClsMyEOs.ShowApprovals(intEOID, strCurrentStage, ref dsApprovar))
            {
                if (dsApprovar == null)
                {
                }
                else if (dsApprovar.Tables.Count == 0)
                {
                }
                else if (dsApprovar.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    dgdApprovalsnew.DataSource = dsApprovar.Tables[0];
                    dgdApprovalsnew.DataBind();
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            string script;
            script = "self.opener = this;self.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string script;
            script = "window.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

    
    }
}