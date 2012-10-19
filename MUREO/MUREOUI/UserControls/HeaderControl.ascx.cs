using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;

namespace MUREOUI.UserControls
{
    public partial class HeaderControl : System.Web.UI.UserControl
    {
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            //Dim objSecurity As New Security
            clsSecurity objSecurity = new clsSecurity();
            lbGlobal.Attributes.Add("OnClick", "javascript: GlobalTeamSpaceWindow();");
            lbHelp.Attributes.Add("OnClick", "javascript: OpenHelpWindow();");
            string role = objSecurity.UserRole();
            if (role.ToUpper() == "MUREO_Admin".ToUpper())
            {
                lblAdmin.Visible = true;
                imgadmin.Visible = true;
                lblSysOwner.Visible = true;
                imgSysOwner.Visible = true;
                lblSysOwnerUsers.Visible = false;
            }
            else
            {
                lblAdmin.Visible = false;
                imgadmin.Visible = false;
                imgSysOwner.Visible = true;
                lblSysOwnerUsers.Visible = true;
                lblSysOwner.Visible = false;
            }
        }

        private void lbFaq_Click(System.Object sender, System.EventArgs e)
        {
            string strPath = "..\\Common\\Templates\\MUREO_Faq.doc";
            Response.AddHeader("Content-Disposition", "attachment;filename=MUREO_Faq.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }


        private void lbGlobal_Click(System.Object sender, System.EventArgs e)
        {
        }

    }
}