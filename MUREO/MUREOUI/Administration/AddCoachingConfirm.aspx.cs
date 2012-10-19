using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddCoachingConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNo.Attributes.Add("OnClick", "javascript: closeWindow();");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            int deleteResult = 0;
            clsBasicinfoBO objclsBasicinfoBO = null;
            SqlParameter[] paramOut = new SqlParameter[1];
            string script = null;
            try
            {
                objclsBasicinfoBO = new clsBasicinfoBO();

                //deleteResult = clsBrandSegmentBO.DeleteBrandSegment(, , "N")
                if (objclsBasicinfoBO.BasicInfoDelete("Coaching_Box", Convert.ToInt32(Request.QueryString["BrandSegId"]), Convert.ToString(Request.QueryString["userName"]), ref paramOut))
                {
                    //deleteResult = clsBasicinfoBO.BasicInfoDelete("Coaching_Box", Request.QueryString("BrandSegId"), Request.QueryString("userName"));

                   
                    if (deleteResult == 0)
                    {
                        //script = "<script>alert('" & ConfigurationSettings.AppSettings("DeletedSuccess") & "');"
                        script = "<script>";
                        script = script + "window.returnValue = 'T';";
                        script = script + "window.close();</script>";
                    }
                    else
                    {
                        //script = "<script>alert('" & ConfigurationSettings.AppSettings("DeleteError") & "');</script> "
                        script = "<script>";
                        script = script + "window.returnValue = 'F';";
                        script = script + "window.close();</script>";
                    }
                    //Page.RegisterStartupScript("clientscript", script);
                    ClientScript.RegisterStartupScript(this.GetType(), "clientscript", script);
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