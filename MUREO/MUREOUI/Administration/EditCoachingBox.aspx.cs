using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class EditCoachingBox : System.Web.UI.Page
    {
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["Co_Box_Id"]) == "")
                {
                    //string script = null;
                    //script = "<script>alert('" + ConfigurationSettings.AppSettings("ViewErr") + "Please select a message name to view this form');window.location = 'ViewCoachingBoxes.aspx';</script> ";
                    //Page.RegisterStartupScript("error", script);
                    strScript = "<script>alert('" + ConfigurationManager.AppSettings["ViewErr"] + " Please select a message name to view this form');window.location='ViewCoachingBoxes.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "db_Success_message", strScript);
                    return;
                }
               FillCoachBox(Convert.ToInt32(Request.QueryString["Co_Box_Id"]));
            }
           

        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            CoachingBoxBO objCoachingBoxBO = null;
            clsSecurity objClsSecurity = null;
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
                objCoachingBoxBO = new CoachingBoxBO();
                objClsSecurity = new clsSecurity();
                if (objCoachingBoxBO.InsertCoachingBoxDA(Convert.ToInt32(Request.QueryString["Co_Box_Id"]),  txtBoxMsgName.Text.Trim(), txtBoxMsg.Text.Trim(), objClsSecurity.UserName, "A", ref paramOut))
                {
                    int result = Convert.ToInt32(paramOut[0].Value);
                    if (result == 0)
                    {

                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');window.location='ViewCoachingBoxes.aspx';</script> ";
                        //Page.RegisterStartupScript("success", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='ViewCoachingBoxes.aspx';</script>";
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
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateError"] + "');</script> ";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", strScript);
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

        private void FillCoachBox(int Co_Box_Id)
        {
            DataSet dsCoach = null;
            CoachingBoxBO objCoachingBoxBO = null;
            try
            {
                dsCoach = new DataSet();
                objCoachingBoxBO = new CoachingBoxBO();
                if (objCoachingBoxBO.GetCoachingBoxBO(Co_Box_Id, ref dsCoach))
                {
                    // dsCoach = CoachingBoxBO.GetCoachingBoxDA(Co_Box_Id);
                    if (dsCoach == null)
                    {
                        NoRecords();
                    }
                    else if (dsCoach.Tables.Count == 0)
                    {
                        NoRecords();
                    }
                    else if (dsCoach.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                    }
                    else
                    {
                        txtBoxMsgName.Text = Convert.ToString(dsCoach.Tables[0].Rows[0]["Key_Name"]);
                        txtBoxMsg.Text = Convert.ToString(dsCoach.Tables[0].Rows[0]["Key_Value"]);

                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsCoach = null;
                objCoachingBoxBO = null;
            }
        }

        private void NoRecords()
        {
            //string script = "<script>alert('" + ConfigurationSettings.AppSettings("NoRecords") + "');</script> ";
            //Page.RegisterStartupScript("error_message", script);
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "error_message", strScript);
            return;
        }


    }
}