using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Common
{
    public partial class HelpAttachments : System.Web.UI.Page
    {
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
        }

       /* protected void lnkIntro_Click(object sender, EventArgs e)
        {
            //string strPath = "..\\Common\\Templates\\Help_Mureo_Intro_projEvents_.doc";
            string strPath = Server.MapPath("~/Common/Templates/Help_Mureo_Intro_projEvents_.doc");
            Response.AddHeader("Content-Disposition", "attachment;filename=Help_Mureo_Intro_projEvents_.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void lnkEo_Click(object sender, EventArgs e)
        {
            //string strPath = "..\\Common\\Templates\\Help_Mur_EoSiteTest.doc";
            string strPath = Server.MapPath("~/Common/Templates/Help_Mur_EoSiteTest.doc");
            Response.AddHeader("Content-Disposition", "attachment;filename=Help_Mur_EoSiteTest.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }

        protected void lnkTest_Click(object sender, EventArgs e)
        {
            //string strPath = "..\\Common\\Templates\\Help_Mureo_Administration.doc";
            string strPath = Server.MapPath("~/Common/Templates/Help_Mureo_Administration.doc");
            Response.AddHeader("Content-Disposition", "attachment;filename=Help_Mureo_Administration.doc");
            Response.TransmitFile(strPath);
            Response.End();
        }*/
    }
}