using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Administration
{
    public partial class View_PaperMachine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txthiddenPlantID.Value = Request.QueryString["PlantID"];
                //txthiddenCategoryId.Text = Request.QueryString["CategoryID")
                txthiddenMachineID.Value = Request.QueryString["MachineID"];
                lblMachineName.Text = Request.QueryString["Machine"];
                FillPlantName(Convert.ToInt32(Request.QueryString["PlantID"]));
                //FillCategoryName(CInt(Request.QueryString["CategoryID")))
            }
        }
        protected void FillPlantName(int PlantID)
        {
            DataSet dsPlant = null;
            dsPlant = new DataSet();
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();

            if (objPlantMachine.GetPlantName(PlantID, ref dsPlant))
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
                }
            }
            // drpPlantName.Items.Insert(0, "--- Select a Plant ---")

        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/AddMachine.aspx?MachineID=" + txthiddenMachineID.Value + "&Mode=Edit" + "&PlantID=" + txthiddenPlantID.Value + "&Machine=" + lblMachineName.Text);
        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/ViewPaperMachine.aspx");
        }

    }
}