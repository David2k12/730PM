using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MUREOUI.Common;
using MUREOBAL;

namespace MUREOUI.Administration
{
    public partial class AddDataCoordinator : System.Web.UI.Page
    {
        string strScript = string.Empty;
        clsSecurity clsm = new clsSecurity();
        SqlParameter[] paramout = null;
        ViewDataCoordinatorsBO objDataCoordinatorBO = null;
        Approver objApprover = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            //imgAddressBook.Attributes.Add("onclick", "javascript: AddBooksingUser();");
            imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
            // Enable onclick event to address book image button
            if (!Page.IsPostBack)
            {
                FillCategory();
                // Fill Category drop down list
            }
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToString(hdntxtCOName.Value) != "")
            {
                txtCoName.Text = hdntxtCOName.Value;
            }
            //Validate the required fields
            if (drpCategory.SelectedIndex == 0)
            {
                //script = "<script>alert('" + ConfigurationSettings.AppSettings("CategoryErrMsg") + "');</script> ";
                //Page.RegisterStartupScript("error", script);
                strScript = "<script>alert('" + ConfigurationManager.AppSettings["CategoryErrMsg"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "CategoryErrMsg", strScript);
                return;
            }
            else if (Convert.ToString(txtCoName.Text) == "")
            {
                //script = "<script>alert('" + ConfigurationSettings.AppSettings("DataCoNameErr") + "');</script> ";
                //Page.RegisterStartupScript("error", script);
                strScript = "<script>alert('" + ConfigurationManager.AppSettings["DataCoNameErr"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "DataCoNameErr", strScript);
                return;
            }
            else if (Convert.ToString(txtPhoneNum.Text) == "")
            {
                //script = "<script>alert('" + ConfigurationSettings.AppSettings("DataCoPhoneErr") + "');</script> ";
                //Page.RegisterStartupScript("error", script);
                strScript = "<script>alert('" + ConfigurationManager.AppSettings["DataCoPhoneErr"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "DataCoPhoneErr", strScript);
                return;
            }


            //All validations passed, now insert the data coordinator details
            try
            {
                objDataCoordinatorBO = new ViewDataCoordinatorsBO();
                paramout = new SqlParameter[1];
                //int result = DataCoordinatorBO.InsertDataCoordinatorBO(0, Convert.ToInt32(drpCategory.SelectedValue), txtCoName.Text, txtPhoneNum.Text, System.Security.UserName, "A");
                if (objDataCoordinatorBO.InsertDataCoordinatorBO(0, Convert.ToInt32(drpCategory.SelectedValue), txtCoName.Text, txtPhoneNum.Text, clsm.UserName, "A", ref paramout))
                {
                    int result = Convert.ToInt32(paramout[0].Value);
                    if (result == 0)
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');window.location='ViewDataCoordinators.aspx';</script> ";
                        //Page.RegisterStartupScript("success", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='ViewDataCoordinators.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "success", strScript);
                    }
                    else if (result == 1)
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("RecordExist") + "');</script> ";
                       // Page.RegisterStartupScript("duplicate", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["RecordExist"] + "');</script> ";
                        ClientScript.RegisterStartupScript(this.GetType(), "RecordExist", strScript);
                    }
                    else
                    {
                       // script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertError") + "');</script> ";
                        //Page.RegisterStartupScript("error", script);
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
                objDataCoordinatorBO = null;
                paramout = null;
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewDataCoordinators.aspx");
        }

        private void NoRecords()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "error_message", strScript);
        }

        private void FillCategory()
        {
            DataSet dsCategory = null;
            try
            {
                dsCategory = new DataSet();
                objApprover = new Approver();
               // dsCategory = Approver.FillApprovalGroupCategoryBO(0);

                // Get category info from the db
                if (objApprover.FillApprovalGroupCategoryBO(0, ref dsCategory))
                {
                    //If dataset is null, quit
                    if (dsCategory == null)
                    {
                        NoRecords();
                    }
                    else if (dsCategory.Tables.Count == 0)
                    {
                        NoRecords();
                        //If no data, quit
                    }
                    else if (dsCategory.Tables[0].Rows.Count == 0)
                    {
                        NoRecords();
                        //Setup data for the category drop down list
                    }
                    else
                    {
                        drpCategory.DataSource = dsCategory.Tables[0];
                        drpCategory.DataTextField = "Category_Name";
                        drpCategory.DataValueField = "Category_ID";
                        drpCategory.DataBind();
                        drpCategory.Items.Insert(0, "-- Select a Category --");
                        drpCategory.SelectedIndex = 0;
                        //Make sure default selection is provided
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
            }
        }
    }
}