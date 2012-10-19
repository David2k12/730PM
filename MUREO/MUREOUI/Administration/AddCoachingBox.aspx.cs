using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddCoachingBox : System.Web.UI.Page
    {
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            CoachingBoxBO objCoachingBoxBO = null;
            clsSecurity objClsSecurity=null;
             SqlParameter[] paramOut = new SqlParameter[1];
             
            try
            {
                if (txtBoxMsgName.Text == string.Empty)
                {

                    //script = "<script>alert('" + ConfigurationSettings.AppSettings("CoachingBoxMsgNameErr") + "');</script> ";
                    //Page.RegisterStartupScript("error", script);
                    strScript = "<script>alert('" + ConfigurationManager.AppSettings["CoachingBoxMsgNameErr"] + "');</script> ";
                    ClientScript.RegisterStartupScript(this.GetType(), "error", strScript);
                    return;
                }
                else if (txtBoxMsg.Text == string.Empty)
                {

                    //script = "<script>alert('" + ConfigurationSettings.AppSettings("CoachingBoxMsgErr") + "');</script> ";
                    //Page.RegisterStartupScript("error", script);
                    strScript = "<script>alert('" + ConfigurationManager.AppSettings["CoachingBoxMsgErr"] + "');</script> ";
                    ClientScript.RegisterStartupScript(this.GetType(), "error", strScript);
                    return;
                }

                //int result = CoachingBoxBO.InsertCoachingBoxBO(0, txtBoxMsgName.Text, txtBoxMsg.Text, System.Security.UserName, "A");
                objCoachingBoxBO=new CoachingBoxBO();
                objClsSecurity=new clsSecurity();
                if (objCoachingBoxBO.InsertCoachingBoxDA(0, txtBoxMsgName.Text.Trim(), txtBoxMsg.Text.Trim(), objClsSecurity.UserName, "A", ref paramOut))
                {
                    int result = Convert.ToInt32(paramOut[0].Value);
                    if (result == 0)
                    {

                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');window.location='ViewCoachingBoxes.aspx';</script> ";
                        //Page.RegisterStartupScript("success", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='ViewCoachingBoxes.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "Success", strScript);
                    }
                    else if (result == 1)
                    {

                        // script = "<script>alert('" + ConfigurationSettings.AppSettings("RecordExist") + "');</script> ";
                        // Page.RegisterStartupScript("duplicate", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');</script> ";
                        ClientScript.RegisterStartupScript(this.GetType(), "RecordExist", strScript);

                    }
                    else
                    {

                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertError") + "');</script> ";
                        // Page.RegisterStartupScript("error", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertError"] + "');</script> ";
                        ClientScript.RegisterStartupScript(this.GetType(), "InsertError", strScript);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objClsSecurity = null;
                objCoachingBoxBO = null;
            }

        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewCoachingBoxes.aspx");

        }
    }
}