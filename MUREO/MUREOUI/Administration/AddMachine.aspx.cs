using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class AddMachine : System.Web.UI.Page
    {
        #region "Variable Declaration"
        DataSet dsMachinePlant;
        DataSet dsMachineNames;
        Int32 plantId;
        string plantName;
        string script;
        string machineName;
        Int32 returnValue;

        string plantIdString;
        #endregion
        #region "Page Events"
        //
        //  ************************************************
        //Name   	    :	Page_Load
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Filling Basic information of the page
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/27/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
           // Page.SmartNavigation = true;

            if (!Page.IsPostBack)
            {

                //imgSubmit.Attributes.Add("onclick", "ValidateFocus()")

                if (Request.QueryString["Mode"] == "Edit")
                {
                    trCrPM.Visible = false;
                    trEdPM.Visible = true;

                    //Edit Mode 
                    //Displaying machine Names based on plant ID
                    plantId = Convert.ToInt32(Request.QueryString["PlantID"]);
                    PlantMachine objPlantMachine = new PlantMachine();
                    dsMachineNames = new DataSet();
                    if(objPlantMachine.FillMachineNames(plantId,ref dsMachineNames))
                    {
                    FillPlantNames();
                    //drpPlantName.SelectedValue = Request.QueryString["PlantID"];
                    //drpPlantName.Items(drpPlantName.Items.IndexOf(drpPlantName.Items.FindByText(CStr(dsMachineNames.Tables(0).Rows(0)(2))))).Selected = True
                    drpPlantName.Items.FindByValue(Convert.ToString(Request.QueryString["PlantID"])).Selected = true;

                    if ((Request.QueryString["Machine"] != null))
                    {
                        txtMachineName.Text = Request.QueryString["Machine"];
                    }

                    if ((Request.QueryString["MachineID"] != null))
                    {
                        txthiddenMachineID.Value = Request.QueryString["MachineID"];
                    }

                    lstMachineName.DataSource = dsMachineNames;
                    lstMachineName.DataTextField = "Machine_Name";
                    lstMachineName.DataValueField = "Machine_ID";
                    lstMachineName.DataBind();
                    }

                }
                else
                {
                    // Insert Mode
                    //Filling all plant names
                    trEdPM.Visible = false;
                    trCrPM.Visible = true;
                    FillPlantNames();
                }


            }

        }
        #endregion
        #region "Functions"
        //
        //  ************************************************
        //Name   	    :	FillPlantNames
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Filling all plant names
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/27/07                 Bharath            1.0           created
        //***************************************************
        //

        protected void FillPlantNames()
        {
            dsMachinePlant = new DataSet();
            PlantMachine objPlantMachine = new PlantMachine();

            if (objPlantMachine.FillPlantMachines(0, ref dsMachinePlant))
            {

                if (dsMachinePlant == null)
                {
                }
                else if (dsMachinePlant.Tables.Count == 0)
                {
                }
                else if (dsMachinePlant.Tables[0].Rows.Count == 0)
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
        //
        //  ************************************************
        //Name   	    :	NoRecords
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Diplaying alert with msg as no results found
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/27/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void NoRecords()
        {
            script = "alert('" + ConfigurationManager.AppSettings["NoRec"] + ")";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
        //
        //  ************************************************
        //Name   	    :	FillMachineNames
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Filling Machine Names
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/27/07                 Bharath            1.0           created
        //***************************************************
        //

        protected void FillMachineNames()
        {
            dsMachineNames = new DataSet();
            PlantMachine objPlantMachine = new PlantMachine();
            plantIdString = drpPlantName.SelectedValue.ToString();
            // plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString())
            if (plantIdString != "--- Select a Plant ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                if (objPlantMachine.FillMachineNames(plantId, ref dsMachineNames))
                {
                    if (dsMachineNames == null)
                    {
                    }
                    else if (dsMachineNames.Tables.Count == 0)
                    {
                    }
                    else if (dsMachineNames.Tables[0].Rows.Count == 0)
                    {
                    }
                    else
                    {
                        lstMachineName.DataSource = dsMachineNames;
                        lstMachineName.DataTextField = "Machine_Name";
                        lstMachineName.DataBind();
                    }
                }
            }
            else
            {
                lstMachineName.Items.Clear();
            }
            //txtMachineName.Text = ""

        }
        //  ************************************************
        //Name   	    :	InsertMachine
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   adding machine Names for perticular Plant
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 Bharath            1.0           created
        //**
        protected void InsertMachine()
        {
            PlantMachine objAddPlantMachine = new PlantMachine();
            plantIdString = drpPlantName.SelectedValue.ToString();
            if (drpPlantName.SelectedValue != "--- Select a Plant ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                machineName = txtMachineName.Text;
                returnValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];

                if (objAddPlantMachine.AddMachineNames(plantId, machineName, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);
                    FillMachineNames();
                    txtMachineName.Text = "";
                    //drpPlantName.SelectedIndex = 0
                    if (returnValue == 0)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "'); window.location='../Administration/ViewPaperMachine.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (returnValue == 1)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["InsertMachineDuplicate"] + "'); window.location='../Administration/ViewPaperMachine.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["InsertError"] + "'); window.location='../Administration/ViewPaperMachine.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }

            }
        }
        //  ************************************************
        //Name   	    :	UpdateMachine
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Updating machine Name based on Plant name
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 Bharath            1.0           created
        //**
        protected void UpdateMachine()
        {
            PlantMachine objAddPlantMachine = new PlantMachine();
            plantIdString = drpPlantName.SelectedValue.ToString();
            if (drpPlantName.SelectedItem.Text != "--- Select a Plant ---")
            {
                plantId = Convert.ToInt32(drpPlantName.SelectedValue.ToString());
                machineName = txtMachineName.Text;
                int intMachineID = 0;

                if (!(lstMachineName.SelectedIndex == -1))
                {
                    intMachineID = Convert.ToInt32(lstMachineName.SelectedItem.Value);
                }
                else
                {
                    intMachineID = Convert.ToInt32(txthiddenMachineID.Value);
                }

                returnValue = -1;
                SqlParameter[] paramout=new SqlParameter[1];
                if (objAddPlantMachine.EditMachineNameBO(plantId, machineName, intMachineID, ref paramout))
                {
                    returnValue = Convert.ToInt32(paramout[0].Value);
                    txtMachineName.Text = "";
                    //drpPlantName.SelectedIndex = 0
                    if (returnValue == 0)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "'); window.location='../Administration/ViewPaperMachine.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else if (returnValue == 1)
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["InsertMachineDuplicate"] + "'); window.location='../Administration/ViewPaperMachine.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                    else
                    {
                        script = "alert('" + ConfigurationManager.AppSettings["UpdateError"] + "'); window.location='../Administration/ViewPaperMachine.aspx';";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                    }
                }
            }
        }

        #endregion
        #region "Dropdown Events"
        //
        //  ************************************************
        //Name   	    :	FillMachineNames
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Filling Machine Names
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/27/07                 Bharath            1.0           created
        //***************************************************
        //
        protected void drpPlantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstMachineName.Items.Clear();
            FillMachineNames();

        }
        #endregion
        #region "Button Events"
        //
        //  ************************************************
        //Name   	    :	imgCancel_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Redirecting to ViewPaperMachine
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/27/07                 Bharath            1.0           created
        //***************************************************
        //


        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewPaperMachine.aspx");
        }


        //
        //  ************************************************
        //Name   	    :	lstMachineName_SelectedIndexChanged
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   displaying selected machinename(listbox) in txtmachinenname
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 Bharath            1.0           created
        //**

        protected void lstMachineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMachineName.Text = lstMachineName.SelectedItem.Text;
        }


        //
        //  ************************************************
        //Name   	    :	imgEdit_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   Updating machine Name based on Plant name
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 Bharath            1.0           created
        //**
        /*protected void imgEdit_Click(object sender, EventArgs e)
        {
            UpdateMachine();
        }*/

        
        //  ************************************************
        //Name   	    :	imgSubmit_Click
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   adding machine Names for perticular Plant
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 Bharath            1.0           created
        //**


        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Mode"] == "Edit")
            {
                UpdateMachine();
            }
            else
            {
                InsertMachine();
            }
        }

        #endregion

       
        

    }
}