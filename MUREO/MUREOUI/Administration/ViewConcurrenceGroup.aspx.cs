using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using MUREOBAL;
using System.Data;

namespace MUREOUI.Administration
{
    public partial class ViewConcurrenceGroup : System.Web.UI.Page
    {
        #region "Variable Declarations"
        public Int32 PlantID;
        Int32 MaterialID;
        string PhNo;
        string ApproverName;
        string PlantName;
        string MaterialType;
        string PcontactID;
        Int32 returnvalue;
        string Script;
        DataSet dsPlant;
        #endregion
        Int32 ConGrpID;

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //lblConGrplID.Text(+"&Mode=Edit" + "&PlantID=" + lblPlantID.Text + "&conGrpName=" + lblConGrpName.Text + "&ApproverName=" + lblApproverName.Text + "&PlantName=" + lblPlantName.Text)

                txthiddenPlantID.Value = Request.QueryString["PlantID"];
                txthiddenConGrpID.Value = Request.QueryString["ConGrpID"];
                lblConGrpNames.Text = Request.QueryString["conGrpName"];

                ApproverName = Request.QueryString["ApproverName"];
                PlantName = Request.QueryString["PlantName"];
                PlantID = Convert.ToInt32(Request.QueryString["PlantID"]);
                FillPlantName(Convert.ToInt32(Request.QueryString["ConGrpID"]));

                lblNameforGroup.Text = ApproverName;

                //lblPlantName.Text = Request.QueryString("PlantName")
                //lblMaterialType.Text = MaterialType
                //lblPhoneNumber.Text = PhNo
                //lblApprover.Text = ApproverName


            }
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/MaintainConcurrenceGroup.aspx");
        }


        protected void FillPlantName(int PlantID)
        {
            dsPlant = new DataSet();
            PlantMachine objPlantMachine = new PlantMachine();

            if (objPlantMachine.GetConPlantName(PlantID, ref dsPlant))
            {

                if (dsPlant == null)
                {
                }
                else if (dsPlant.Tables.Count == 0)
                {
                }
                else if (dsPlant.Tables[0].Rows.Count == 0)
                {
                }
                else
                {
                    lblPlantName.Text = Convert.ToString(dsPlant.Tables[0].Rows[0]["Plant_Name"]);
                    txthiddenPlantID.Value = Convert.ToString(dsPlant.Tables[0].Rows[0]["Plant_id"]);
                }
            }
            // drpPlantName.Items.Insert(0, "--- Select a Plant ---")

        }

        protected void DeleteConcurrenceGroup()
        {
            ConcurrenceGroup objDeleteConGroup = new ConcurrenceGroup();

            returnvalue = -1;
            SqlParameter[] paramout=new SqlParameter[1];
            if (objDeleteConGroup.DeleteConcurrenceGroup(Convert.ToInt32(txthiddenConGrpID.Value), ref paramout))
            {
                returnvalue = Convert.ToInt32(paramout[0].Value);
                if (returnvalue == 0)
                {
                    //' Script = "x=alert('" & ConfigurationManager.AppSettings["DeletedSuccess") & "');if (x)window.location='~/Administration/MaintainPurchasingContacts.aspx') "
                    //Script = "alert('" & ConfigurationManager.AppSettings["DeletedSuccess") & "');window.location='~/Administration/MaintainPurchasingContacts.aspx');"
                    //Page.RegisterStartupScript("clientscript", script)

                    //'Page.RegisterStartupScript("error_message", script)

                    string script = null;
                    script = "alert('" + ConfigurationManager.AppSettings["DeletedSuccess"] + "');window.location='../Administration/MaintainConcurrenceGroup.aspx');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                }
                else
                {
                    Script = "alert('" + ConfigurationManager.AppSettings["DeletedError"] + "');window.location='../Administration/MaintainConcurrenceGroup.aspx';";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                }
                //Response.Redirect("~/Administration/MaintainPurchasingContacts.aspx")
            }
                
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            DeleteConcurrenceGroup();
        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddConcurrenceGroup.aspx?PlantID=" + txthiddenPlantID.Value + "&Mode=Edit" + "&ConGrpName=" + lblConGrpNames.Text + "&NameForGrp=" + lblNameforGroup.Text + "&ConGrpID=" + txthiddenConGrpID.Value);
        }

    }
}