using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;

namespace MUREOUI.UserControls
{
    public partial class LeftNavigationControl : System.Web.UI.UserControl
    {
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            clsSecurity objSecurity = new clsSecurity();
            string role = objSecurity.UserRole();
            if (role.ToUpper() == "MUREO_Readers".ToUpper())
            {
                tdNewEvent.Visible = false;
                tdNewProject.Visible = false;
                tdNewEO.Visible = false;
                tdEoSitetest.Visible = false;
                tdMySiteCloseOut.Visible = false;
                tdMyApproval.Visible = false;
                tdTemporary1.Visible = true;
                tdTemporary2.Visible = true;
                tdTemporary3.Visible = true;
                tdTemporary4.Visible = true;
                tdTemporary5.Visible = true;
                tdTemporary6.Visible = true;

            }
            else
            {
                tdNewEvent.Visible = true;
                tdNewProject.Visible = true;
                tdNewEO.Visible = true;
                tdEoSitetest.Visible = true;
                tdMyApproval.Visible = true;
                tdMySiteCloseOut.Visible = true;
                tdTemporary1.Visible = false;
                tdTemporary2.Visible = false;
                tdTemporary3.Visible = false;
                tdNewEvent.Disabled = false;
                tdNewProject.Disabled = false;
                tdNewEO.Disabled = false;
                tdTemporary4.Visible = false;
                tdTemporary5.Visible = false;
                tdTemporary6.Visible = false;


            }
        }

    }
}