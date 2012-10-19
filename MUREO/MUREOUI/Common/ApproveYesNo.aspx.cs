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
using System.Web.Mail;


namespace MUREOUI.Common
{
    public partial class ApproveYesNo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnYes.Attributes.Add("onclick", "javascript: hourglass();");
            btnSubmit.Attributes.Add("onclick", "javascript: hourglass();");
            if ((Request.QueryString["Type"] == "D"))
            {
                lblYesNo.Visible = false;
                lblDecline.Visible = true;
            }
            else
            {
                lblYesNo.Visible = true;
                lblDecline.Visible = false;
            }
            TR1.Visible = true;
            TR3.Visible = false;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            TR1.Visible = false;
            TR3.Visible = true;
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            string strAllValues = "No";
            string script;
            script = ("<script>window.returnValue ='"
                        + (strAllValues + "';"));
            script = (script + "window.close();</script>");
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EOBA objEOBA = new EOBA();
              clsSecurity Security = new clsSecurity();
              SqlParameter[] paramOut = null;
            try
            {
                int strEOID = 0;
                if (!(Request.QueryString["EOID"] == null))
                {
                    //  strEOID = CInt(Request.QueryString("EOID"))
                    strEOID = 1;
                    if (((Request.QueryString["Type"] == "D") && (txtCommnets.Text.ToString().Trim() == String.Empty)))
                    {
                        string script1;
                        script1 = "<script>alert('Please enter comments');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "clientscript", script1);
                        return;
                    }
                }
                
                if (!(txtCommnets.Text.ToString().Trim() == ""))
                {
                    // Dim objClsEO As New ClsEO
                    if (objEOBA.addEOCommentsTest(Convert.ToInt32(strEOID.ToString().Trim()), txtCommnets.Text.ToString().Trim(), Security.UserName, ref paramOut))
                    {
                    }
                }
                string strAllValues = "Yes";
                string script;
                script = ("<script>window.returnValue = '"
                            + (strAllValues + "';"));
                script = (script + "window.close();</script>");
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
            }
            catch (Exception ex)
            {
            }


        }
    }
}