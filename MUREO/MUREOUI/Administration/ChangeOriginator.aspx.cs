using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class ChangeOriginator : System.Web.UI.Page
    {
        DataSet dsChangeOriginator = new DataSet();
        private void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtCoOriginator.Value))
            {
                txtCoOriginator.Text = hdntxtCoOriginator.Value;
            }
            if (!string.IsNullOrEmpty(hdntxtOriginator.Value))
            {
                txtOriginator.Text = hdntxtOriginator.Value;
            }
            if (!Page.IsPostBack)
            {
                imgAddressBook.Attributes.Add("onclick", "javascript: AddBooksingUserOrg();");
                imageAddBook.Attributes.Add("onclick", "javascript: AddBooksingUserCoorgi();");
                imgSubmit.Attributes.Add("OnClick", "javascript:return CheckSelected();");
                imgUpdate.Attributes.Add("OnClick", "javascript:return CheckSelected_Submit();");
                FillEONumbers();
            }
        }

        public void FillEONumbers()
        {
            ChangeOriginatorBO objChangeOrginator = new ChangeOriginatorBO();
            DataSet dsEONumber = null;
            dsEONumber = new DataSet();
            //dsEONumber = objChangeOrginator.GET_EO_NUMBERS();
            if (objChangeOrginator.GET_EO_NUMBERS(ref  dsEONumber))
            {
                if ((dsEONumber != null))
                {
                    if (!(dsEONumber.Tables.Count == 0))
                    {
                        if (!(dsEONumber.Tables[0].Rows.Count == 0))
                        {
                            drpEONumber.DataSource = dsEONumber.Tables[0].DefaultView;
                            drpEONumber.DataTextField = "EO_Number";
                            drpEONumber.DataValueField = "EO_ID";
                            drpEONumber.DataBind();
                            drpEONumber.Items.Insert(0, "--Select EO Number--");
                            drpEONumber.Items[0].Value = "0";
                        }
                        else
                        {
                            NoDataForDropDown();
                            drpEONumber.Items.Insert(0, "None");
                            drpEONumber.Items[0].Value = "0";
                            return;
                        }
                    }
                    else
                    {
                        NoDataForDropDown();
                        drpEONumber.Items.Insert(0, "None");
                        drpEONumber.Items[0].Value = "0";
                        return;
                    }
                }
                else
                {
                    NoDataForDropDown();
                    drpEONumber.Items.Insert(0, "None");
                    drpEONumber.Items[0].Value = "0";
                    return;
                }
            }
        }

        public void NoDataForDropDown()
        {
            dynamic strJavascript = null;
            strJavascript = "<script>alert('" + ConfigurationSettings.AppSettings["NoRecords"] + "')</script>";
            Page.RegisterStartupScript("clientscript", strJavascript);
        }

    


        protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
        {
            ChangeOriginatorBO objChangeOrginator = new ChangeOriginatorBO();
            int intResult = 0;
            SqlParameter[] paramOut = null;
            //intResult = objChangeOrginator.SET_EO_Change_Originator(drpEONumber.SelectedItem.Value, txtOriginator.Text.Trim, txtCoOriginator.Text.Trim);

            if (objChangeOrginator.SET_EO_Change_Originator(Convert.ToInt32(drpEONumber.SelectedItem.Value), txtOriginator.Text.ToString().Trim(), txtCoOriginator.Text.ToString().Trim(), ref paramOut))
            {
                intResult = Convert.ToInt32(paramOut[0].Value);
            }
            if (intResult == 0)
            {
                string script1 = null;
                script1 = "<script>alert('Updated successfully.');window.navigate('Home.aspx');</script> ";
                Page.RegisterStartupScript("clientscript", script1);
            }
            else
            {
                string script1 = null;
                script1 = "<script>alert('Updated failed.');</script> ";
                Page.RegisterStartupScript("clientscript", script1);
            }
        }

        protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/home.aspx");
        }

        protected void imgSubmit_Click1(object sender, ImageClickEventArgs e)
        {
            ChangeOriginatorBO objChangeOrginator = new ChangeOriginatorBO();
            //dsChangeOriginator = objChangeOrginator.GET_EO_Change_Originator(drpEONumber.SelectedItem.Text);

            if (objChangeOrginator.GET_EO_Change_Originator(drpEONumber.SelectedItem.Text, ref  dsChangeOriginator))
            {
                if ((dsChangeOriginator != null))
                {
                    if (!(dsChangeOriginator.Tables.Count == 0))
                    {
                        if (!(dsChangeOriginator.Tables[0].Rows.Count == 0))
                        {
                            txtOriginator.Text = dsChangeOriginator.Tables[0].Rows[0]["Originator"].ToString();
                            txtCoOriginator.Text = dsChangeOriginator.Tables[0].Rows[0]["CoOriginator"].ToString();
                        }
                        else
                        {
                            string script1 = null;
                            script1 = "<script>alert('No records found with this EO Number');document.getElementById(ctrlName).focus();</script> ";
                            Page.RegisterStartupScript("clientscript", script1);
                        }
                    }
                    else
                    {
                        string script1 = null;
                        script1 = "<script>alert('No records found with this EO Number');document.getElementById(ctrlName).focus();</script> ";
                        Page.RegisterStartupScript("clientscript", script1);
                    }
                }
                else
                {
                    string script1 = null;
                    script1 = "<script>alert('No records found with this EO Number');document.getElementById(ctrlName).focus();</script> ";
                    Page.RegisterStartupScript("clientscript", script1);
                }
            }
        }

    }
}