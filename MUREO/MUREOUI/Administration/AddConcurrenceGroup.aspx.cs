using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MUREOUI.Administration
{
    public partial class AddConcurrenceGroup : System.Web.UI.Page
    {
        #region "Variable Declarations"
        DataSet dsPlant;
        string plantIdString;
        Int32 plantId;
        string ConGrpName;
        string NameforGrp;
        Int32 returnValue;
        #endregion
        string Script;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdntxtNameforGroup.Value))
                txtNameforGroup.Text = hdntxtNameforGroup.Value;
            imgAddressBook.Attributes.Add("onclick", "javascript:return AddBookMultiUser();");
            //Page.SmartNavigation = true;
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Mode"] == "Edit")
                {
                    trCrCG.Visible = false;
                    trEdCG.Visible = true;

                    //../Administration/AddConcurrenceGroup.aspx?PlantID=" + txthiddenPlantID.Text + "&Mode=Edit" + "&ConGrpName=" + lblConGrpNames.Text + "&NameForGrp=" + lblNameforGroup.Text)
                    //Edit Mode 
                    plantId = Convert.ToInt32(Request.QueryString["PlantID"]);
                    // PlantName=" + lblPlantName.Text + "&Mode=Edit" + "&MaterialType=" + lblMaterialType.Text + "&ApproverName=" + lblApprover.Text + "&PhoneNumber=" + lblPhoneNumber.Text)

                    FillPlantNames();
                    //FillMaterials()
                    drpPlantName.SelectedValue = Request.QueryString["PlantID"];
                    txtConcurrenceGroupName.Text = Request.QueryString["ConGrpName"];
                    txtNameforGroup.Text = Request.QueryString["NameForGrp"];
                    txtHiddenConGrpID.Value = Request.QueryString["ConGrpID"];
                    //txtHiddenPurchaseContactID.Text = Request.QueryString("ConGrpName")
                    //txtPhoneNumber.Text = Request.QueryString("PhoneNumber")



                }
                else
                {
                    trEdCG.Visible = false;
                    trCrCG.Visible = true;
                    FillPlantNames();

                }

            }
        }


        protected void FillPlantNames()
        {
            dsPlant = new DataSet();
            PlantMachine objPlantMachine = new PlantMachine();

            if (objPlantMachine.FillPlantMachines(0, ref dsPlant))
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
                    drpPlantName.DataSource = dsPlant;
                    drpPlantName.DataTextField = "Plant_Name";
                    drpPlantName.DataValueField = "Plant_ID";
                    drpPlantName.DataBind();
                }
                drpPlantName.Items.Insert(0, "--- Select a Plant ---");
            }

        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Mode"] == "Edit")
            {
                UpdatePurchaseContact();
            }
            else
            {
                InsertPurchaseContact();
            }
        }
        protected void InsertPurchaseContact()
        {
            ConcurrenceGroup objAddConcurrenceGroup = new ConcurrenceGroup();
            plantIdString = drpPlantName.SelectedValue.ToString();
         
            if (drpPlantName.SelectedValue != "--- Select a Plant ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());

                ConGrpName = txtConcurrenceGroupName.Text;
                NameforGrp = txtNameforGroup.Text;
                returnValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (objAddConcurrenceGroup.AddEoConcurrenceGroup(plantId, ConGrpName, NameforGrp, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);
                    txtConcurrenceGroupName.Text = "";
                    txtNameforGroup.Text = "";
                    //drpPlantName.SelectedIndex = 0
                    if (returnValue == 0)
                    {
                        Script = "alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "'); window.location='../Administration/MaintainConcurrenceGroup.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                    }
                    else
                    {
                        Script = "alert('" + ConfigurationManager.AppSettings["InsertError"] + "'); window.location='../Administration/MaintainConcurrenceGroup.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                    }

                }
            }
        }

        protected void UpdatePurchaseContact()
        {
            ConcurrenceGroup objAddConcurrenceGroup = new ConcurrenceGroup();
            plantIdString = drpPlantName.SelectedValue.ToString();


            if (drpPlantName.SelectedValue != "--- Select a Plant ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                ConGrpName = txtConcurrenceGroupName.Text;
                NameforGrp = txtNameforGroup.Text;
                returnValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (objAddConcurrenceGroup.UpdateEoConcurrenceGroup(Convert.ToInt32(txtHiddenConGrpID.Value), plantId, ConGrpName, NameforGrp, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);
                    txtConcurrenceGroupName.Text = "";
                    txtNameforGroup.Text = "";
                    //drpPlantName.SelectedIndex = 0
                    if (returnValue == 0)
                    {
                        Script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "'); window.location='../Administration/MaintainConcurrenceGroup.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                    }
                    else
                    {
                        Script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); window.location='../Administration/MaintainConcurrenceGroup.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", Script, true);
                    }
                }
            }
        }




        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/MaintainConcurrenceGroup.aspx");
        }

    }
}