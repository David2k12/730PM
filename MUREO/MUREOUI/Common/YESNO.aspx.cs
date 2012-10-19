using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Common
{
    public partial class YESNO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnNo_Click(object sender, EventArgs e)
        {
            //Session["GCAS"] = "No";
            //string script = null;
            //script = "<script>";
            //script = script + " window.opener.document.getElementById('imgPreRoute').focus();window.close();</script>";
            //ClientScript.RegisterStartupScript(GetType(), "clientscript", script);

            Session["GCAS"] = "No";
            string script = null;
            script = "<script>";
            script = script + "window.opener.document.getElementById('hdnGCASValue').value='No';window.opener.document.getElementById('imgPreRoute').focus();window.close();</script>";
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            //Session["GCAS"] = "Yes";
            //string script = null;
            //script = "<script>";
            //script = script + " window.opener.document.getElementById('btnAddGCAS').focus();window.close();</script>";
            //ClientScript.RegisterStartupScript(GetType(), "clientscript", script);

            Session["GCAS"] = "Yes";
            string script = null;
            script = "<script>";
            script = script + "window.opener.document.getElementById('hdnGCASValue').value='Yes';window.opener.document.getElementById('btnAddGCAS').focus();window.close();</script>";
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
        }
    }
}