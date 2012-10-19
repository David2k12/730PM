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
    public partial class EditDataCoordinator : System.Web.UI.Page
    {
        string strScript = string.Empty;
        int CO_ID;
        DataSet dsCO = null;
        DataSet dsCategory = null;
        ViewDataCoordinatorsBO objDataCoordinatorBO = null;
        Approver objApprover = null;
        clsSecurity clsm = new clsSecurity();
        SqlParameter[] paramout = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtCOName.Value))
            {
                txtCOName.Text = hdntxtCOName.Value;
            }
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["CO_ID"])== "")
                {
                    //string script = "<script>alert('" + ConfigurationSettings.AppSettings("ViewErr") + "Please select a data coordinator to view this form');window.location = 'ViewDataCoordinators.aspx';</script> ";
                    //Page.RegisterStartupScript("error", script);
                    strScript = "<script>alert('" + ConfigurationManager.AppSettings["ViewErr"] + "'+'Please select a data coordinator to view this form');window.location='ViewDataCoordinators.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "error", strScript);
                    return;
                }

               // imgAddressBook.Attributes.Add("onclick", "javascript: AddBooksingUser();");
                //imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
                imgAddressBook.Attributes.Add("onclick", "javascript:return AddBooksingUser();");
                // Enable onclick event to address book image button
                try
                {
                    objDataCoordinatorBO = new ViewDataCoordinatorsBO();
                    dsCO = new DataSet();
                    dsCategory = new DataSet();
                    CO_ID = Convert.ToInt32(Request.QueryString["CO_ID"]);
                    if (objDataCoordinatorBO.GetDataCoordinatorDetailsBO(CO_ID, ref dsCO))
                    {
                        objApprover = new Approver();
                        if (objApprover.FillApprovalGroupCategoryBO(0, ref dsCategory))
                        {
                            if (dsCO == null)
                            {
                                NoRecords();
                            }
                            else if (dsCO.Tables[0].Rows.Count == 0)
                            {
                                NoRecords();
                            }
                            else
                            {
                                //drpCategory.DataSource = dsCategory;
                                drpCategory.DataSource = dsCategory.Tables[0];
                                drpCategory.DataTextField = "Category_Name";
                                drpCategory.DataValueField = "Category_ID";
                                drpCategory.DataBind();
                                drpCategory.Items.FindByValue(dsCO.Tables[0].Rows[0]["Category_ID"].ToString()).Selected = true;
                                txtCOName.Text = dsCO.Tables[0].Rows[0]["Data_Coordinator_Name"].ToString();
                                txtPhone.Text = dsCO.Tables[0].Rows[0]["Phone_Number"].ToString();
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
                    objApprover = null;
                    objDataCoordinatorBO = null;
                    dsCategory = null;
                    dsCO = null;
                }

            }
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                if (Convert.ToString(txtPhone.Text.Trim()) == "")
                {
                    // string script = null;
                    //script = "<script>alert('" + ConfigurationSettings.AppSettings("DataCoPhoneErr") + "');</script> ";
                    //Page.RegisterStartupScript("error", script);
                    strScript = "<script>alert('" + ConfigurationManager.AppSettings["DataCoPhoneErr"] + "');</script> ";
                    ClientScript.RegisterStartupScript(this.GetType(), "DataCoPhoneErr", strScript);
                    return;
                }
                objDataCoordinatorBO = new ViewDataCoordinatorsBO();
                paramout = new SqlParameter[1];
                //int result = DataCoordinatorBO.InsertDataCoordinatorBO(CO_ID, Convert.ToInt32(drpCategory.SelectedValue), txtCOName.Text, txtPhone.Text, System.Security.UserName, "A");
                if (objDataCoordinatorBO.InsertDataCoordinatorBO(Convert.ToInt32(Request.QueryString["CO_ID"]), Convert.ToInt32(drpCategory.SelectedValue), txtCOName.Text, txtPhone.Text, clsm.UserName, "A", ref paramout))
                {
                    int result = Convert.ToInt32(paramout[0].Value);
                    if (result == 0)
                    {
                        //string script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateSuccess") + "');window.location='ViewDataCoordinators.aspx';</script> ";
                        //Page.RegisterStartupScript("error_message", script);

                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='ViewDataCoordinators.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", strScript);
                    }
                    else if (result == 1)
                    {
                        //string script = "<script>alert('" + ConfigurationSettings.AppSettings("RecordExist") + "');</script> ";
                        //Page.RegisterStartupScript("error_message", script);

                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');</script> ";
                        ClientScript.RegisterStartupScript(this.GetType(), "RecordExist", strScript);
                    }
                    else
                    {
                        //string script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');</script> ";
                        //Page.RegisterStartupScript("error_message", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateError"] + "');</script> ";
                        ClientScript.RegisterStartupScript(this.GetType(), "Update_Error", strScript);

                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewDataCoordinators.aspx");
        }
        private void NoRecords()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "No Records", strScript);
        }
    }
}