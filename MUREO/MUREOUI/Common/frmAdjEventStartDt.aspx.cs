using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Common
{
    public partial class frmAdjEventStartDt : System.Web.UI.Page
    {
        string sqlText;
        string strUser;
        clsSecurity objSecurity = new clsSecurity();
        DataSet ds = new DataSet();
        SqlParameter[] paramOut = null;

        clsProject clsPrj = new clsProject();

        private void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            strUser = objSecurity.UserName;
            imgCancel.Attributes.Add("onclick", "close1();");
            if (!IsPostBack)
            {
                //Code for populating project dropdown
                //FillDropdown("GET_MUR_Project", drpProject);

                if (clsPrj.FillHistoryofProject(0, ref ds))
                {
                   if ((ds.Tables[0].Rows.Count != 0))
                    {
                        drpProject.Visible = true;
                        drpProject.DataSource = ds.Tables[0].DefaultView;
                        drpProject.DataTextField = "Project_Name";
                        drpProject.DataValueField = "Project_ID";
                        drpProject.DataBind();
                        drpProject.Items.Insert(0, "Select a Project");
                    }
                }
            }
        }


        private void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            //Validation for project and weeks to adjust fields
            strUser = objSecurity.UserName;
            string script = null;
            if (drpProject.SelectedValue == "0")
            {
                //string script = null;
                //script = "<script>alert('" + ConfigurationSettings.AppSettings["PrjselErrMsg"] + "');</script> ";
                //Page.RegisterStartupScript("clientscript", script);
                //return;

                script = "<script>alert('" + ConfigurationManager.AppSettings["PrjselErrMsg"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "PrjselErrMsg", script);
                return;
            }
            if (string.IsNullOrEmpty(txtWeeks.Text))
            {
                //string script = null;
                //script = "<script>alert('" + ConfigurationSettings.AppSettings["WeeksErrMsg"] + "');</script> ";
                //Page.RegisterStartupScript("clientscript", script);
                //return;
                script = "<script>alert('" + ConfigurationManager.AppSettings["WeeksErrMsg"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "WeeksErrMsg", script);
                return;
            }

            //Code for Save button
            //int intResult = clsPrj.EventStartDate(drpProject.SelectedValue.Trim, txtWeeks.Text.Trim, strUser);
            int intResult = 0;
            paramOut = new SqlParameter[1];
            if (clsPrj.EventStartDate(Convert.ToInt32(drpProject.SelectedValue.Trim()), txtWeeks.Text.Trim(), strUser, ref paramOut))
            {
                intResult = Convert.ToInt32(paramOut[0].Value);

            }

            if ((intResult == 0))
            {
                //Success Message
                //string script = null;
                //script = "<script>alert('" + ConfigurationSettings.AppSettings["AdjustStartSuccess"] + "');</script> ";
                //Page.RegisterStartupScript("clientscript", script);
                //Response.Redirect("Home.aspx");

                script = "<script>alert('" + ConfigurationManager.AppSettings["AdjustStartSuccess"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "AdjustStartSuccess", script);
                Response.Redirect("Home.aspx");
            }
            else
            {
                //Failure Message
                //string script = null;
                //script = "<script>alert('" + ConfigurationSettings.AppSettings["InsertErrMsg"] + "');</script> ";
                //Page.RegisterStartupScript("clientscript", script);
                script = "<script>alert('" + ConfigurationManager.AppSettings["InsertErrMsg"] + "');</script> ";
                ClientScript.RegisterStartupScript(this.GetType(), "InsertErrMsg", script);
                return;

            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //Code for Save button
            string script = null;
            if (Convert.ToInt32(txtWeeks.Text) <= 250)
            {
                //int intResult = clsPrj.EventStartDate(drpProject.SelectedValue.Trim, txtWeeks.Text.Trim, strUser);

                int intResult = 0;
                paramOut = new SqlParameter[1];
                if (clsPrj.EventStartDate(Convert.ToInt32(drpProject.SelectedValue.Trim()), txtWeeks.Text.Trim(), strUser, ref paramOut))
                {
                    intResult = Convert.ToInt32(paramOut[0].Value);

                }
                if ((intResult == 0))
                {
                    //Success Message

                    //script = "<script>alert('" + ConfigurationSettings.AppSettings["AdjustStartSuccess"] + "');window.close();</script> ";
                    //Page.RegisterStartupScript("clientscript", script);
                    script = "<script>alert('" + ConfigurationManager.AppSettings["AdjustStartSuccess"] + "');window.close();</script> ";
                    ClientScript.RegisterStartupScript(this.GetType(), "AdjustStartSuccess", script);
                }
                else
                {
                    //Failure Message
                    //script = "<script>alert('" + ConfigurationSettings.AppSettings["InsertErrMsg"] + "');</script> ";
                    //Page.RegisterStartupScript("clientscript", script);
                    script = "<script>alert('" + ConfigurationManager.AppSettings["InsertErrMsg"] + "');</script> ";
                    ClientScript.RegisterStartupScript(this.GetType(), "InsertErrMsg", script);
                    return;
                }
            }
            else
            {
                script = "<script>alert('Day(s) to adjust should not be greater than 250.');</script> ";
               // Page.RegisterStartupScript("clientscript", script);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);

            }
        }
    }
}