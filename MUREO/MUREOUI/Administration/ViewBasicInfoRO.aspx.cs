using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class ViewBasicInfoRO : System.Web.UI.Page
    {

        clsBasicinfoBO objclsBasicinfoBO = null;
        clsSecurity objclsSecurity = null;
        SqlParameter[] paramOut = null;
        string strUser = string.Empty;
        int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here

            if (!Page.IsPostBack)
            {

                try
                {
                    if (Convert.ToString(Request.QueryString["Key"]) == "Cat")
                    {
                        lblKey.Text = "Category";
                        lblKeyText.Text = "Category";
                        index = 0;
                    }
                    else if (Convert.ToString(Request.QueryString["Key"]) == "Plant")
                    {
                        lblKey.Text = "Plant";
                        lblKeyText.Text = "Plant";
                        index = 1;
                    }
                    else if (Convert.ToString(Request.QueryString["Key"]) == "EO")
                    {
                        lblKey.Text = "EO_Type";
                        lblKeyText.Text = "EO Type";
                        index = 2;
                    }
                    else if (Convert.ToString(Request.QueryString["Key"]) == "Project")
                    {
                        lblKey.Text = "Project_Type";
                        lblKeyText.Text = "Project Type";
                        index = 3;
                    }
                    else if (Convert.ToString(Request.QueryString["Key"]) == "Function")
                    {
                        lblKey.Text = "Function";
                        lblKeyText.Text = "Function";
                        index = 4;
                    }
                    else if (Convert.ToString(Request.QueryString["Key"]) == "Machine")
                    {
                        lblKey.Text = "Machine_Type";
                        lblKeyText.Text = "Machine";
                        index = 5;
                    }
                    fillKeyValues();
                    objclsBasicinfoBO = new clsBasicinfoBO();
                    objclsSecurity = new clsSecurity();
                    paramOut = new SqlParameter[1];
                    strUser = objclsSecurity.UserName;
                    //int intResult = clsBasicinfoBO.BasicInfoDeleteCheck(lblKey.Text, lblKeyValue.Text, strUser);
                    if (objclsBasicinfoBO.BasicInfoDeleteCheck(Convert.ToString(lblKey.Text), Convert.ToInt32(lblKeyValue.Text), strUser, ref paramOut))
                    {
                        int intResult = Convert.ToInt32(paramOut[0].Value);
                        if (intResult == 0)
                        {
                            imgDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the Basic Information? Click OK to delete or CANCEL to abort.');");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    objclsBasicinfoBO = null;
                    paramOut = null;
                    objclsSecurity = null;

                }

            }
        }

        private void fillKeyValues()
        {
            lblValue.Text = Convert.ToString(Request.QueryString["CatName"]);
            lblKeyValue.Text = Convert.ToString(Request.QueryString["KeyValue"]);
        }



        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("MaintainBasicinfo.aspx?Key=" + Request.QueryString("Key") + "&Catname=" + Request.QueryString("CatName").ToString());
            Server.Transfer("~/Administration/MaintainBasicinfo.aspx?Key=" + Convert.ToString(Request.QueryString["Key"]) + "&Catname=" + Convert.ToString(Request.QueryString["CatName"]));

        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/Administration/ViewBasicInfo.aspx");
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            string strScript = string.Empty;
            string strUser = string.Empty;
            clsBasicinfoBO objclsBasicinfoBO = null;
            clsSecurity objclsSecurity = null;
            SqlParameter[] paramOut = null;
            int intConfResult;
            //int intConfResult = clsBasicinfoBO.BasicInfoDeleteCheck(lblKey.Text, lblKeyValue.Text, strUser);
            try
            {
                objclsSecurity = new clsSecurity();
                objclsBasicinfoBO = new clsBasicinfoBO();
                paramOut = new SqlParameter[1];
                strUser = objclsSecurity.UserName;
                if (objclsBasicinfoBO.BasicInfoDeleteCheck(Convert.ToString(lblKey.Text), Convert.ToInt32(lblKeyValue.Text), strUser, ref paramOut))
                {
                    intConfResult = Convert.ToInt32(paramOut[0].Value);
                    if (intConfResult > 0)
                    {
                        //script = "<script>alert('Basic Information cannot be deleted as it is associated with other records.');</script>";
                        ////script = script + "window.location='../Common/Home.aspx'</script> "
                        //Page.RegisterStartupScript("clientscript", script);

                        strScript = "<script>alert('Basic Information cannot be deleted as it is associated with other records.');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "BasicRecordExist", strScript);
                    }
                    else
                    {
                        //int intResult = clsBasicinfoBO.BasicInfoDelete(lblKey.Text, lblKeyValue.Text, strUser);
                        if (objclsBasicinfoBO.BasicInfoDelete(Convert.ToString(lblKey.Text), Convert.ToInt32(lblKeyValue.Text), strUser, ref paramOut))
                        {
                            intConfResult = Convert.ToInt32(paramOut[0].Value);
                            if ((intConfResult == 0))
                            {
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("DeletedSuccess") + "');";
                                //script = script + "window.location='../Administration/ViewBasicInfo.aspx'</script> ";
                                //Page.RegisterStartupScript("clientscript", script);
                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');window.location='../Administration/ViewBasicInfo.aspx';</script>";
                                ClientScript.RegisterStartupScript(this.GetType(), "DeletedSuccess", strScript);
                            }
                            else
                            {
                                //Failure Message
                                //script = "<script>alert('" + ConfigurationSettings.AppSettings("DeleteError") + "');</script> ";
                                //Page.RegisterStartupScript("clientscript", script);

                                strScript = "<script>alert('" + ConfigurationManager.AppSettings["DeleteError"] + "');</script> ";
                                ClientScript.RegisterStartupScript(this.GetType(), "DeleteError", strScript);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsBasicinfoBO = null;
                paramOut = null;
                objclsSecurity = null;

            }

        }


    }
}