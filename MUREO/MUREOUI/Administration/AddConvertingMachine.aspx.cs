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
    public partial class AddConvertingMachine : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        DataSet dsMachinePlant;
        DataSet dsMachineNames;
        DataSet dsCategoryNames;
        Int32 plantId;
        Int32 categoryId;
        string plantName;
        string script;
        string machineName;
        Int32 returnValue;
        string plantIdString;
        string categoryIdString;
        protected void Page_Load(object sender, EventArgs e)
        {
           // Page.SmartNavigation = true;
            if (!IsPostBack)
            {
                FillPlantNames();
                FillCategoryNames();

                if ((Request.QueryString["Mode"] == null))
                {
                    trECM.Visible = false;
                    trCCM.Visible = true;
                }
                else if ((Request.QueryString["Mode"] == "Edit"))
                {
                    trCCM.Visible = false;
                    trECM.Visible = true;
                    drpPlantName.SelectedValue = Request.QueryString["PlantID"];
                    drpCategoryName.SelectedValue = Request.QueryString["CategoryID"];
                    txtMachineName.Text = Request.QueryString["MachineName"];
                    hdntxthiddenMachineID.Value = Request.QueryString["MachineID"];
                    clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
                    if (objPlantMachine.FillConvertMachineNames(Convert.ToInt32(Request.QueryString["PlantID"]), Convert.ToInt32(Request.QueryString["CategoryID"]), ref dsMachineNames))
                    {
                        if ((dsMachineNames == null))
                        {

                        }
                        else if ((dsMachineNames.Tables.Count == 0))
                        {

                        }
                        else if ((dsMachineNames.Tables[0].Rows.Count == 0))
                        {

                        }
                        else
                        {
                            lstMachineName.DataSource = dsMachineNames;
                            lstMachineName.DataTextField = "Machine_Name";
                            lstMachineName.DataValueField = "Machine_ID";
                            lstMachineName.DataBind();
                        }
                    }
                    else
                    {
                        trECM.Visible = false;
                        trCCM.Visible = true;
                    }
                    

                }

            }
        }

        private void FillPlantNames()
        {
            dsMachinePlant = new DataSet();
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
            //BusinessObject.MUREO.BusinessObject.PlantMachine objPlantMachine = new BusinessObject.MUREO.BusinessObject.PlantMachine();
            //dsMachinePlant = objPlantMachine.FillPlantMachines(0);
            if (objPlantMachine.FillPlantNames(0, ref dsMachinePlant))
            {
                if ((dsMachinePlant == null))
                {

                }
                else if ((dsMachinePlant.Tables.Count == 0))
                {

                }
                else if ((dsMachinePlant.Tables[0].Rows.Count == 0))
                {

                }
                else
                {
                    drpPlantName.DataSource = dsMachinePlant;
                    drpPlantName.DataTextField = "Plant_Name";
                    drpPlantName.DataValueField = "Plant_ID";
                    drpPlantName.DataBind();
                }
                drpPlantName.Items.Insert(0, "--- Select a Plant ---");
            }
            
        }

        private void NoRecords()
        {
            script = "alert('No Results Found')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        private void InsertRecord()
        {
            script = "alert('Machine Is Inserted')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        private void selectPlant()
        {
            script = "alert('Select Plant Name')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        private void selectCategory()
        {
            script = "alert('Select Category Name')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }

        private void FillCategoryNames()
        {
            dsCategoryNames = new DataSet();
            //BusinessObject.MUREO.BusinessObject.PlantMachine objCategoryNames = new BusinessObject.MUREO.BusinessObject.PlantMachine();
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
            if (objPlantMachine.FillCategoryNames(ref dsCategoryNames))
            {
                if ((dsCategoryNames == null))
                {

                }
                else if ((dsCategoryNames.Tables.Count == 0))
                {

                }
                else if ((dsCategoryNames.Tables[0].Rows.Count == 0))
                {

                }
                else
                {
                    drpCategoryName.DataSource = dsCategoryNames;
                    drpCategoryName.DataTextField = "Category_Name";
                    drpCategoryName.DataValueField = "Category_ID";
                    drpCategoryName.DataBind();
                }
                drpCategoryName.Items.Insert(0, "--- Select a Category ---");
            }
            
            
        }

        private void insertMachine()
        {
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
            SqlParameter[] dsCategoryNames = new SqlParameter[1];
            // BusinessObject.MUREO.BusinessObject.PlantMachine objAddPlantMachine = new BusinessObject.MUREO.BusinessObject.PlantMachine();
            plantIdString = drpPlantName.SelectedValue.ToString();
            categoryIdString = drpCategoryName.SelectedValue.ToString();
            plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
            categoryId = Convert.ToInt32(drpCategoryName.SelectedValue.ToString());
            machineName = txtMachineName.Text;

            if (objPlantMachine.AddConvertMachineNames(plantId, categoryId, machineName, ref dsCategoryNames))
            {
                returnValue = Convert.ToInt32(dsCategoryNames[0].Value);
                FillMachineNames();
                txtMachineName.Text = "";
                if ((returnValue == 0))
                {
                    script = ("alert('"
                                + (ConfigurationSettings.AppSettings["InsertSuccess"] + "');window.navigate('../Administration/ViewCategories.aspx');"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    script = ("alert('"
                                + (ConfigurationSettings.AppSettings["InsertError"] + "');window.navigate('../Administration/ViewCategories.aspx');"));
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
            
        }

        private void UpdateMachine()
        {
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();
            SqlParameter[] dsCategoryNames = new SqlParameter[1];
            plantIdString = drpPlantName.SelectedValue.ToString();
            categoryIdString = drpCategoryName.SelectedValue.ToString();
            plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
            categoryId = Convert.ToInt32(drpCategoryName.SelectedValue.ToString());
            machineName = txtMachineName.Text;
            int intMachineID;
            if (!(lstMachineName.SelectedIndex == -1))
            {
                intMachineID = Convert.ToInt32(lstMachineName.SelectedItem.Value);
            }
            else
            {
                intMachineID = Convert.ToInt32(hdntxthiddenMachineID.Value.ToString());
            }
            if (objPlantMachine.UpdateConvertMachineNames(plantId, categoryId, machineName, intMachineID, ref dsCategoryNames))
            {
                returnValue = Convert.ToInt32(dsCategoryNames[0].Value);
                FillMachineNames();
                txtMachineName.Text = "";
                if ((returnValue == 0))
                {
                    script = ("alert('"
                                + (ConfigurationSettings.AppSettings["UpdateSuccess"] + "');window.navigate('../Administration/ViewCategories.aspx');"));
                    //Page.RegisterStartupScript("clientscript", script);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
                else
                {
                    script = ("alert('"
                                + (ConfigurationSettings.AppSettings["UpdateError"] + "');window.navigate('../Administration/ViewCategories.aspx');"));
                    //Page.RegisterStartupScript("clientscript", script);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
         
          
        }

        private void FillMachineNames()
        {
            dsMachineNames = new DataSet();
            clsPlantMachineBO objPlantMachine = new clsPlantMachineBO();

            plantIdString = drpPlantName.SelectedValue.ToString();
            categoryIdString = drpCategoryName.SelectedValue.ToString();
            if (((plantIdString != "--- Select a Plant ---")
                        && (categoryIdString != "--- Select a Category ---")))
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                categoryId = Convert.ToInt32(drpCategoryName.SelectedValue.ToString());
                if (objPlantMachine.FillConvertMachineNames(plantId, categoryId, ref dsMachineNames))
                {
                    if ((dsMachineNames == null))
                    {
                        lstMachineName.Items.Clear();
                    }
                    else if ((dsMachineNames.Tables.Count == 0))
                    {
                        lstMachineName.Items.Clear();
                    }
                    else if ((dsMachineNames.Tables[0].Rows.Count == 0))
                    {
                        lstMachineName.Items.Clear();
                    }
                    else
                    {
                        lstMachineName.DataSource = dsMachineNames;
                        lstMachineName.DataTextField = "Machine_Name";
                        lstMachineName.DataValueField = "Machine_ID";
                        lstMachineName.DataBind();
                    }
                }
                else
                {
                    lstMachineName.Items.Clear();
                }
             }

             
        }

        protected void drpPlantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMachineNames();
        }

        protected void drpCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMachineNames();
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewCategories.aspx");
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if ((Request.QueryString["Mode"] == "Edit"))
            {
                UpdateMachine();
            }
            else
            {
                insertMachine();
            }
        }

        protected void lstMachineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMachineName.Text = lstMachineName.SelectedItem.Text.ToString().Trim();
        }
    }
}






