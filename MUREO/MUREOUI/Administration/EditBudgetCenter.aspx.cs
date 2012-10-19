using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Configuration;
using MUREOUI.Common;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class EditBudgetCenter : System.Web.UI.Page
    {
        #region "variable declarations"
        Approver app = new Approver();
        BudgetCtrBO bdg=new BudgetCtrBO();
        clsSecurity cls = new clsSecurity();
         int Budget_Center_Id;
         int plant_id;
         int Area_Id;
        #endregion
        int ResultNo;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!string.IsNullOrEmpty(hdntxtTowel.Value))
                txtTowel.Text = hdntxtTowel.Value;
            if (!string.IsNullOrEmpty(hdntxtBath.Value))
                txtBath.Text = hdntxtBath.Value;
            if (!string.IsNullOrEmpty(hdntxtDefault.Value))
                txtDefault.Text = hdntxtDefault.Value;
            if (!string.IsNullOrEmpty(hdntxtSAPCCC.Value))
                txtSAPCCC.Text = hdntxtSAPCCC.Value;
            if (!string.IsNullOrEmpty(hdntxtTissue.Value))
                txtTissue.Text = hdntxtTissue.Value;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Budget_Center_ID"] == null | Request.QueryString["Plant_ID"] == null | Request.QueryString["Area_ID"] == null)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select a budget center to view this form');window.location = 'ViewBudgetCenters.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                else if (Request.QueryString["Budget_Center_ID"] == string.Empty | Request.QueryString["Plant_ID"] == string.Empty | Request.QueryString["Area_ID"] == string.Empty)
                {
                    string script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select a budget center to view this form');window.location = 'ViewBudgetCenters.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    return;
                }
                Budget_Center_Id = Convert.ToInt32(Request.QueryString["Budget_Center_ID"]);
                plant_id = Convert.ToInt32(Request.QueryString["Plant_ID"]);
                Area_Id = Convert.ToInt32(Request.QueryString["Area_ID"]);
                imgDeleteSAPCCC.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the SAP Cost Center Coordinator name? Click OK to delete or CANCEL to abort.');");
                imgAddrbkTowel.Attributes.Add("onclick", "javascript:return AddBookSingUser1();");
                ImgAddrbkBath.Attributes.Add("onclick", "javascript:return AddBookSingUser2();");
                ImgAddrbkTissue.Attributes.Add("onclick", "javascript:return AddBookSingUser3();");
                ImgAddrbkDefault.Attributes.Add("onclick", "javascript:return AddBookSingUser4();");
                ImgAddrBkSAPCC.Attributes.Add("onclick", "javascript:return AddBookSingUser5();");
                FillBudgetCenterDetails();
                FillPlantDetails();
                FillAreaDetails();
            }

        }

        protected void FillBudgetCenterDetails()
        {
            DataSet dsBudgetCtr = null;
            if (bdg.GetBudgetCenterDetailsBO(Convert.ToInt32(Request.QueryString["Budget_Center_ID"]), ref dsBudgetCtr))
            {
                if (dsBudgetCtr == null)
                {
                    NoRecords();
                }
                else if (dsBudgetCtr.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsBudgetCtr.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Budget_Center_Name"])))
                    {
                        txtBdgtCtrName.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Budget_Center_Name"]) == string.Empty)
                    {
                        txtBdgtCtrName.Text = "";
                    }
                    else
                    {
                        txtBdgtCtrName.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Budget_Center_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"])))
                    {
                        txtTowel.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"]) == string.Empty)
                    {
                        txtTowel.Text = "";
                    }
                    else
                    {
                        txtTowel.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"])))
                    {
                        txtBath.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"]) == string.Empty)
                    {
                        txtBath.Text = "";
                    }
                    else
                    {
                        txtBath.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"])))
                    {
                        txtTissue.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"]) == string.Empty)
                    {
                        txtTissue.Text = "";
                    }
                    else
                    {
                        txtTissue.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"])))
                    {
                        txtDefault.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"]) == string.Empty)
                    {
                        txtDefault.Text = "";
                    }
                    else
                    {
                        txtDefault.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"])))
                    {
                        txtSAPCCC.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"]) == string.Empty)
                    {
                        txtSAPCCC.Text = "";
                    }
                    else
                    {
                        txtSAPCCC.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"]);
                    }
                }
            }
        }

        protected void FillPlantDetails()
        {
            DataSet dsPlant = new DataSet();

            if (app.FillApproverPlantsBO(0, ref dsPlant))
            {
                if (dsPlant == null)
                {
                    NoRecords();
                }
                else if (dsPlant.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsPlant.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    drpPlant.DataSource = dsPlant;
                    drpPlant.DataTextField = "Plant_Name";
                    drpPlant.DataValueField = "Plant_ID";
                    drpPlant.DataBind();
                    drpPlant.SelectedValue = plant_id.ToString();
                }
            }
        }

        protected void FillAreaDetails()
        {
            DataSet dsArea = new DataSet();
            if (bdg.FillEOBudgetAreaBO(0, ref dsArea))
            {
                if (dsArea == null)
                {
                    NoRecords();
                }
                else if (dsArea.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsArea.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
                else
                {
                    drpArea.DataSource = dsArea;
                    drpArea.DataTextField = "Area_Name";
                    drpArea.DataValueField = "Area_ID";
                    drpArea.DataBind();
                    drpArea.SelectedValue = Area_Id.ToString();
                }
            }
        }

        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewBudgetCenters.aspx");
        }
        //Sub 	        :   imgSubmit_Click
        //Written BY	    :	Vijay
        //parameters     :	None
        //Purpose	    :   Adds new budget center to db
        //Returns        :   None
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/06/07                 Vijay             1.0           created
        //01/07/07               Abdul Allaam        2.0        Validation check is been kept for saving of edit 
        //budget centers which previously was not there.
        //***************************************************
        protected void imgSubmit_Click(object sender, EventArgs e)
        {          
            //Make sure all the required fields are filled out properly
            if (txtBdgtCtrName.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["BudgetCtrNameErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
                //ElseIf drpPlant.SelectedIndex = 0 Then
                //    Dim script As String = "alert('" & ConfigurationManager.AppSettings["PlantErr") & "'); "
                //    Page.RegisterStartupScript("error_message", script)
                //    Exit Sub
                //ElseIf drpArea.SelectedIndex = 0 Then
                //    Dim script As String = "alert('" & ConfigurationManager.AppSettings["BudgetCtrAreaErr") & "'); "
                //    Page.RegisterStartupScript("error_message", script)
                //    Exit Sub
            }
            else if (txtTowel.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["TowelErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (txtBath.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["BathErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (txtTissue.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["TissueErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            else if (txtDefault.Text == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["DefaultErr"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
            SqlParameter[] paramout=new SqlParameter[1];
            int result = -1;

            if (bdg.InsertEOBudgetCenterBO(Convert.ToInt32(Request.QueryString["Budget_Center_ID"]), txtBdgtCtrName.Text, Convert.ToInt32(drpPlant.SelectedValue), Convert.ToInt32(drpArea.SelectedValue), txtTowel.Text, txtBath.Text, txtTissue.Text, txtDefault.Text, txtSAPCCC.Text, cls.UserName, 'A', ref paramout))
            {
                result=Convert.ToInt32(paramout[0].Value);
            if (result == 0)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='ViewBudgetCenters.aspx' ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            else if (result == 1)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["RecordExist"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            else
            {
                string script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            }
        }

        protected void imgDeleteSAPCCC_Click(object sender, EventArgs e)
        {
            txtSAPCCC.Text = "";
        }

    }
}