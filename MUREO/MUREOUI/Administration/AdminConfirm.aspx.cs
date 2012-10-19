using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data.SqlClient;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class AdminConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNo.Attributes.Add("OnClick", "javascript: closeWindow();");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            int deleteResult = 0;
            clsBrandSegmentBO objclsBrandSegmentBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            try
            {
                objclsBrandSegmentBO = new clsBrandSegmentBO();
                if (objclsBrandSegmentBO.DeleteBrandSegment(Convert.ToInt32(Request.QueryString["BrandSegId"]), Convert.ToString(Request.QueryString["userName"]), "N", ref paramOut))
                {
                    //deleteResult = clsBrandSegmentBO.DeleteBrandSegment(Request.QueryString("BrandSegId"), Request.QueryString("userName"), "N");
                    deleteResult = Convert.ToInt32(paramOut[0].Value);
                    string script = null;
                    if (deleteResult == 0)
                    {
                        script = "<script>alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');</script>";
                        script = "<script>";
                        script = script + "window.returnValue = 'T';";
                        script = script + "window.close();</script>";
                       // script = "<script>alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');window.returnValue = 'T';window.close();</script> ";

                    }
                    else
                    {
                        script = "<script>alert('" + ConfigurationManager.AppSettings["DeleteError"] + "');</script> ";
                        script = "<script>";
                        script = script + "window.returnValue = 'F';";
                        script = script + "window.close();</script>";
                        //script = "<script>alert('" + ConfigurationManager.AppSettings["DeleteError"] + "');window.returnValue = 'F';window.close();</script> ";
                    }
                    //Page.RegisterStartupScript("clientscript", script);

                    ClientScript.RegisterStartupScript(this.GetType(), "Message", script);
                }
                //script = "<script>window.returnValue = '';"
                //script = script + "window.close();</script>"
                //Page.RegisterStartupScript("clientscript", script)
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsBrandSegmentBO = null;
            }

        }
        
    }
}