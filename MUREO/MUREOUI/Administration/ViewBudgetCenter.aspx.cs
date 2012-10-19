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
    public partial class WebForm3 : System.Web.UI.Page
    {
        #region "variable declarations"
        static string PlantId;
        BudgetCtrBO bdg = new BudgetCtrBO();
       
        #endregion
        static string AreaID;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                GetBudgetCenterDetails();
            }
        }

        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        protected void GetBudgetCenterDetails()
        {
            if (Request.QueryString["Budget_Center_ID"] == null | Request.QueryString["Budget_Center_ID"] == string.Empty)
            {
                string script = "alert('" + ConfigurationManager.AppSettings["ViewErr"] + "Please select a budget center to view this form');window.location = 'ViewBudgetCenters.aspx'; ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                return;
            }
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
                        lblBudgetCenterName.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Budget_Center_Name"]) == string.Empty)
                    {
                        lblBudgetCenterName.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Budget_Center_Name"]) == " ")
                    {
                        lblBudgetCenterName.Text = "";
                    }
                    else
                    {
                        lblBudgetCenterName.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Budget_Center_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Plant_Name"])))
                    {
                        lblPlant.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Plant_Name"]) == string.Empty)
                    {
                        lblPlant.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Plant_Name"]) == " ")
                    {
                        lblPlant.Text = "";
                    }
                    else
                    {
                        lblPlant.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Plant_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Area_Name"])))
                    {
                        lblArea.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Area_Name"]) == string.Empty)
                    {
                        lblArea.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Area_Name"]) == " ")
                    {
                        lblArea.Text = "";
                    }
                    else
                    {
                        lblArea.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Area_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"])))
                    {
                        lblTowel.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"]) == string.Empty)
                    {
                        lblTowel.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"]) == " ")
                    {
                        lblTowel.Text = "";
                    }
                    else
                    {
                        lblTowel.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Towel_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"])))
                    {
                        lblBath.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"]) == string.Empty)
                    {
                        lblBath.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"]) == " ")
                    {
                        lblBath.Text = "";
                    }
                    else
                    {
                        lblBath.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Bath_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"])))
                    {
                        lblTissue.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"]) == string.Empty)
                    {
                        lblTissue.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"]) == " ")
                    {
                        lblTissue.Text = "";
                    }
                    else
                    {
                        lblTissue.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Tissue_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"])))
                    {
                        lblDefault.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"]) == string.Empty)
                    {
                        lblDefault.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"]) == " ")
                    {
                        lblDefault.Text = "";
                    }
                    else
                    {
                        lblDefault.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Default_Approver_Name"]);
                    }

                    if (string.IsNullOrEmpty(Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"])))
                    {
                        lblSAPCCC.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"]) == string.Empty)
                    {
                        lblSAPCCC.Text = "";
                    }
                    else if (Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"]) == " ")
                    {
                        lblSAPCCC.Text = "";
                    }
                    else
                    {
                        lblSAPCCC.Text = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["SAP_Cost_Center_Coordinator"]);
                    }
                    PlantId = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Plant_ID"]);
                    AreaID = Convert.ToString(dsBudgetCtr.Tables[0].Rows[0]["Area_ID"]);
                }
            }

        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewBudgetCenters.aspx");
        }

        protected void imgEdit_click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/EditBudgetCenter.aspx?Budget_Center_Id=" + Request.QueryString["Budget_Center_ID"] + "&Plant_ID=" + PlantId + "&Area_Id=" + AreaID);

        }

    }
}