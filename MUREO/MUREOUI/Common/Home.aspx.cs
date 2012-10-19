using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Common
{
    public partial class Home : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {
            tdMainNewProject.Disabled = false;
            tdMainNewEvent.Disabled = false;
            tdMainNewEo.Disabled = false;
            tdEoSitetest.Disabled = false;
            tdMyApproval.Disabled = false;
            tdMySiteColse.Disabled = false;
            string role = objSecurity.UserRole();
            if ((role == "MUREO_Readers"))
            {
                tdMainNewProject.Visible = false;
                tdMainNewEvent.Visible = false;
                tdMainNewEo.Visible = false;
                tdEoSitetest.Visible = false;
                tdMyApproval.Visible = false;
                tdMySiteColse.Visible = false;
                tdTemporary1.Visible = true;
                tdTemporary2.Visible = true;
                tdTemporary3.Visible = true;
                tdTemporary4.Visible = true;
                tdTemporary5.Visible = true;
                tdTemporary6.Visible = true;
            }
            else
            {
                tdMainNewProject.Visible = true;
                tdMainNewEvent.Visible = true;
                tdMainNewEo.Visible = true;
                tdEoSitetest.Visible = true;
                tdMyApproval.Visible = true;
                tdMySiteColse.Visible = true;
                tdTemporary1.Visible = false;
                tdTemporary2.Visible = false;
                tdTemporary3.Visible = false;
                tdTemporary4.Visible = false;
                tdTemporary5.Visible = false;
                tdTemporary6.Visible = false;
            }
            if (!IsPostBack)
            {
                string script;
                script = "<script>IsPopupBlocker();</script> ";
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
               
            }
        }
    }
}