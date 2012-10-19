using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOPROP;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Mail;
using System.Text;
using MUREOUI.Common;
namespace MUREOUI.Administration
{
    public partial class View_ConvertMachine : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hdntxthiddenPlantID.Value = Request.QueryString["PlantID"];
                hdntxthiddenCategoryId.Value = Request.QueryString["CategoryID"];
                hdntxthiddenMachineID.Value = Request.QueryString["MachineID"];
                lblMachineName.Text = Request.QueryString["MachineName"];
                FillPlantName(int.Parse(Request.QueryString["PlantID"]));
                FillCategoryName(int.Parse(Request.QueryString["CategoryID"]));
            }

        }
        private void FillPlantName(int PlantID)
        {
            DataSet dsPlant;
            dsPlant = new DataSet();
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
            //BusinessObject.MUREO.BusinessObject.PlantMachine objPlantMachine = new BusinessObject.MUREO.BusinessObject.PlantMachine();
            if (objPlantMachine.GetPlantName(PlantID, ref dsPlant))
            {
                if ((dsPlant == null))
                {

                }
                else if ((dsPlant.Tables.Count == 0))
                {

                }
                else if ((dsPlant.Tables[0].Rows.Count == 0))
                {

                }
                else
                {
                    lblPlantName.Text = dsPlant.Tables[0].Rows[0]["Plant_Name"].ToString().Trim();
                }
            }


            //  drpPlantName.Items.Insert(0, "--- Select a Plant ---")
        }

        private void FillCategoryName(int CategoryID)
        {
            DataSet dsCategory;
            dsCategory = new DataSet();
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
            MachinesByCategory objMachinesByCategory = new MachinesByCategory();
            if (objMachinesByCategory.GetCategoryName(CategoryID, ref dsCategory))
            {
                if ((dsCategory == null))
                {

                }
                else if ((dsCategory.Tables.Count == 0))
                {

                }
                else if ((dsCategory.Tables[0].Rows.Count == 0))
                {

                }
                else
                {
                    lblCategory.Text = dsCategory.Tables[0].Rows[0]["Category_Name"].ToString().Trim();
                }
                
            }
           
           

            //  drpPlantName.Items.Insert(0, "--- Select a Plant ---")
        }


        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
          

        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewCategories.aspx");
        }

        protected void imgSubmit_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/AddConvertingMachine.aspx?MachineID=" + hdntxthiddenMachineID.Value.ToString() + "&Mode=Edit" + "&CategoryID=" + hdntxthiddenCategoryId.Value.ToString() + "&PlantID=" + hdntxthiddenPlantID.Value.ToString() + "&MachineName=" + lblMachineName.Text);
        }

        protected void imgCancel_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewCategories.aspx");
        }
    }
}