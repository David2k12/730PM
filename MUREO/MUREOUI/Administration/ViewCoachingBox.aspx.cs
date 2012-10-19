using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;

namespace MUREOUI.Administration
{
    public partial class ViewCoachingBox : System.Web.UI.Page
    {
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["Co_Box_Id"])=="")
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

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/EditCoachingBox.aspx?Co_Box_ID=" + Request.QueryString["Co_Box_Id"]);

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
                        lblMsgName.Text = Convert.ToString(dsCoach.Tables[0].Rows[0]["Key_Name"]);
                        lblMsg.Text = Convert.ToString(dsCoach.Tables[0].Rows[0]["Key_Value"]);
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

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/Administration/ViewCoachingBoxes.aspx");
        }


    }
}