using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using MUREOUI.Common;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class MaintainBasicInfo : System.Web.UI.Page
    {
        clsSecurity objclsSecurity = null;
        DataSet dsBasicInfo = null;
        SqlParameter[] paramOut = null;
        string strScript = string.Empty;
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	Page_Load
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :  
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 chary              1.0           created
        //***************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["Key"]) == "AddNew")
                {
                    trEdBi.Visible = false;
                    trCrBi.Visible = true;
                    drpkey.SelectedIndex = 0;
                }
                else if (Convert.ToString(Request.QueryString["Key"]) == "Cat")
                {
                    trEdBi.Visible = true;
                    trCrBi.Visible = false;
                    drpkey.SelectedIndex = 1;
                }
                else if (Convert.ToString(Request.QueryString["Key"]) == "Plant")
                {
                    trEdBi.Visible = true;
                    trCrBi.Visible = false;
                    drpkey.SelectedIndex = 5;
                }
                else if (Convert.ToString(Request.QueryString["Key"]) == "EO")
                {
                    trEdBi.Visible = true;
                    trCrBi.Visible = false;
                    drpkey.SelectedIndex = 2;
                }
                else if (Convert.ToString(Request.QueryString["Key"]) == "Project")
                {
                    trEdBi.Visible = true;
                    trCrBi.Visible = false;
                    drpkey.SelectedIndex = 6;
                }
                else if (Convert.ToString(Request.QueryString["Key"]) == "Function")
                {
                    trEdBi.Visible = true;
                    trCrBi.Visible = false;
                    drpkey.SelectedIndex = 3;
                }
                else if (Convert.ToString(Request.QueryString["Key"]) == "Machine")
                {
                    trEdBi.Visible = true;
                    trCrBi.Visible = false;
                    drpkey.SelectedIndex = 4;
                }
                fillKeyValues();
            }

        }

        private void fillKeyValues()
        {

            clsBasicinfoBO objProjectsByCategory = null;
            try
            {
                objProjectsByCategory = new clsBasicinfoBO();
                dsBasicInfo = new DataSet();
                objclsSecurity = new clsSecurity();
                if (objProjectsByCategory.FillBasicInfo(ref dsBasicInfo))
                {
                    //   dsBasicInfo = objProjectsByCategory.FillBasicInfo;
                    if (drpkey.SelectedIndex == 1)
                    {
                        //GET_MUR_Category
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[0].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[0];
                                    lbKeyValues.DataTextField = "Category_Name";
                                    lbKeyValues.DataValueField = "Category_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                    lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(Request.QueryString["Catname"]))].Selected = true;
                                    txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 5)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[1].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[1];
                                    lbKeyValues.DataTextField = "Plant_Name";
                                    lbKeyValues.DataValueField = "Plant_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                    lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(Request.QueryString["Catname"]))].Selected = true;
                                    txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 2)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[2].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[2];
                                    lbKeyValues.DataTextField = "EO_Type_Name";
                                    lbKeyValues.DataValueField = "EO_Type_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                    lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(Request.QueryString["Catname"]))].Selected = true;
                                    txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 6)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[3].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[3];
                                    lbKeyValues.DataTextField = "Project_Type_Name";
                                    lbKeyValues.DataValueField = "Project_Type_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                    lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(Request.QueryString["Catname"]))].Selected = true;
                                    txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 3)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[4].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[4];
                                    lbKeyValues.DataTextField = "Function_Name";
                                    lbKeyValues.DataValueField = "Function_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                    lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(Request.QueryString["Catname"]))].Selected = true;
                                    txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 4)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[5].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[5];
                                    lbKeyValues.DataTextField = "Machine_Name";
                                    lbKeyValues.DataValueField = "Machine_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                    lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(Request.QueryString["Catname"]))].Selected = true;
                                    txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsBasicInfo = null;
                objclsSecurity = null;
                objProjectsByCategory = null;

            }
        }

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	lbKeyValues_SelectedIndexChanged
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 chary              1.0           created
        //***************************************************


        protected void lbKeyValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
            {
                txtKeyValue.Text = string.Empty;
            }
            else
            {
                txtKeyValue.Text = lbKeyValues.SelectedItem.Text;
            }

        }

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	drpkey_SelectedIndexChanged
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   To change the values depends on Key selection
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 chary              1.0           created
        //***************************************************



        protected void drpkey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpkey.SelectedIndex == 0)
            {
                txtKeyValue.Text = string.Empty;
                lbKeyValues.Items.Clear();
            }
            else
            {
                txtKeyValue.Text = string.Empty;
                fillValueBykey();
                lbKeyValues.SelectedIndex = 0;
            }

        }

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	fillValueBykey
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   To change fill values depends when Key selection changed
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 chary              1.0           created
        //***************************************************
        private void fillValueBykey()
        {
            clsBasicinfoBO objProjectsByCategory = null;
            try
            {
                objProjectsByCategory = new clsBasicinfoBO();
                dsBasicInfo = new DataSet();
                objclsSecurity = new clsSecurity();
                if (objProjectsByCategory.FillBasicInfo(ref dsBasicInfo))
                {
                    //dsBasicInfo = new DataSet();
                    //clsBasicinfoBO objProjectsByCategory = new clsBasicinfoBO();
                    //dsBasicInfo = objProjectsByCategory.FillBasicInfo;
                    if (drpkey.SelectedIndex == 1)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[0].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[0];
                                    lbKeyValues.DataTextField = "Category_Name";
                                    lbKeyValues.DataValueField = "Category_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 5)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[1].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[1];
                                    lbKeyValues.DataTextField = "Plant_Name";
                                    lbKeyValues.DataValueField = "Plant_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 2)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[2].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[2];
                                    lbKeyValues.DataTextField = "EO_Type_Name";
                                    lbKeyValues.DataValueField = "EO_Type_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 6)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[3].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[3];
                                    lbKeyValues.DataTextField = "Project_Type_Name";
                                    lbKeyValues.DataValueField = "Project_Type_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 3)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[4].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[4];
                                    lbKeyValues.DataTextField = "Function_Name";
                                    lbKeyValues.DataValueField = "Function_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                }
                            }
                        }
                    }
                    else if (drpkey.SelectedIndex == 4)
                    {
                        if ((dsBasicInfo != null))
                        {
                            if (!(dsBasicInfo.Tables.Count == 0))
                            {
                                if (!(dsBasicInfo.Tables[5].Rows.Count == 0))
                                {
                                    lbKeyValues.DataSource = dsBasicInfo.Tables[5];
                                    lbKeyValues.DataTextField = "Machine_Name";
                                    lbKeyValues.DataValueField = "Machine_ID";
                                    lbKeyValues.DataBind();
                                    lbKeyValues.Items.Insert(0, "--Select Key Value--");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsBasicInfo = null;
                objclsSecurity = null;
                objProjectsByCategory = null;
            }
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            clsBasicinfoBO objCategory = null;
            objclsSecurity = null;
            int intResults = 0;
            string strUserName = string.Empty;
            string strStatus = "A";
            try
            {
                if (drpkey.SelectedIndex == 1)
                {
                    int intCatid = 0;
                    if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
                    {
                        intCatid = 0;
                    }
                    else
                    {
                        intCatid = Convert.ToInt32(lbKeyValues.SelectedValue);
                    }
                    string strCatName = txtKeyValue.Text;
                    //lbKeyValues.SelectedItem.Text
                    //string strStatus = "A";
                    //string strUserName = System.Security.UserName();
                    //objclsSecurity = new clsSecurity();
                    if (objclsSecurity == null)
                    {
                        objclsSecurity = new clsSecurity();
                    }
                    
                    objCategory = new clsBasicinfoBO();
                    paramOut = new SqlParameter[1];
                    strUserName = objclsSecurity.UserName;
                    //intResults = objCategory.UpdateInsertCategory(intCatid, strCatName, strStatus, strUserName);
                    if (objCategory.UpdateInsertCategory(intCatid, strCatName, strStatus, strUserName, ref paramOut))
                    {
                        intResults = Convert.ToInt32(paramOut[0].Value);
                        if (intResults == 0)
                        {

                            //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');window.navigate('../Administration/ViewBasicInfo.aspx');</script>";
                            //Page.RegisterStartupScript("clientscript", script);
                            InsertUpdateSuccess();
                            fillValueBykey();
                            lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(strCatName))].Selected = true;
                        }
                        else if (intResults == 1)
                        {
                            BasicRecordExist();
                        }
                        else
                        {
                            InsertUpdateerr();
                        }
                    }
                }
                else if (drpkey.SelectedIndex == 5)
                {
                    int intPlantid = 0;
                    if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
                    {
                        intPlantid = 0;
                    }
                    else
                    {
                        intPlantid = Convert.ToInt32(lbKeyValues.SelectedValue);
                    }
                    string strPlantName = txtKeyValue.Text;
                    //lbKeyValues.SelectedItem.Text
                    //string strStatus = "A";
                    //string strUserName = System.Security.UserName();

                    if (objclsSecurity == null)
                    {
                        objclsSecurity = new clsSecurity();
                    }

                   
                    if (objCategory == null)
                    {
                        objCategory = new clsBasicinfoBO();
                    }
                    if (paramOut == null)
                    {
                        paramOut = new SqlParameter[1];
                    }
                    strUserName = objclsSecurity.UserName;
                    //clsBasicinfoBO objCategory = new clsBasicinfoBO();
                    //int intResults = 0;
                    //intResults = objCategory.UpdateInsertPlant(intPlantid, strPlantName, strStatus, strUserName);
                    if (objCategory.UpdateInsertPlant(intPlantid, strPlantName, strStatus, strUserName, ref paramOut))
                    {
                        intResults = Convert.ToInt32(paramOut[0].Value);
                        if (intResults == 0)
                        {

                            InsertUpdateSuccess();
                            fillValueBykey();
                            lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(strPlantName))].Selected = true;
                        }
                        else if (intResults == 1)
                        {
                            BasicRecordExist();
                        }
                        else
                        {
                            InsertUpdateerr();
                        }
                    }
                }
                else if (drpkey.SelectedIndex == 2)
                {
                    int intEOid = 0;
                    if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
                    {
                        intEOid = 0;
                    }
                    else
                    {
                        intEOid = Convert.ToInt32(lbKeyValues.SelectedValue);
                    }
                    string strEOName = txtKeyValue.Text;
                    //lbKeyValues.SelectedItem.Text
                    //string strStatus = "A";
                    //string strUserName = System.Security.UserName();
                    //clsBasicinfoBO objCategory = new clsBasicinfoBO();
                    //int intResults = 0;
                    if (objclsSecurity == null)
                    {
                        objclsSecurity = new clsSecurity();
                    }
                   
                    if (objCategory == null)
                    {
                        objCategory = new clsBasicinfoBO();
                    }
                    if (paramOut == null)
                    {
                        paramOut = new SqlParameter[1];
                    }
                    strUserName = objclsSecurity.UserName;

                    //intResults = objCategory.UpdateInsertEO(intEOid, strEOName, strStatus, strUserName);
                    if (objCategory.UpdateInsertEO(intEOid, strEOName, strStatus, strUserName, ref paramOut))
                    {
                        intResults = Convert.ToInt32(paramOut[0].Value);
                        if (intResults == 0)
                        {
                            InsertUpdateSuccess();
                            fillValueBykey();
                            lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(strEOName))].Selected = true;
                        }
                        else if (intResults == 1)
                        {
                            BasicRecordExist();
                        }
                        else
                        {
                            InsertUpdateerr();
                        }
                    }
                }
                else if (drpkey.SelectedIndex == 6)
                {
                    int intprojid = 0;
                    if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
                    {
                        intprojid = 0;
                    }
                    else
                    {
                        intprojid = Convert.ToInt32(lbKeyValues.SelectedValue);
                    }
                    string strProjName = txtKeyValue.Text;
                    //lbKeyValues.SelectedItem.Text
                    //string strStatus = "A";
                    if (objclsSecurity == null)
                    {
                        objclsSecurity = new clsSecurity();
                    }
                    
                    //clsBasicinfoBO objCategory = new clsBasicinfoBO();
                    //int intResults = 0;
                    //intResults = objCategory.UpdateInsertProjectType(intprojid, strProjName, strStatus, strUserName);

                    //strUserName = objclsSecurity.UserName;
                    if (objCategory == null)
                    {
                        objCategory = new clsBasicinfoBO();
                    }
                    if (paramOut == null)
                    {
                        paramOut = new SqlParameter[1];
                    }

                    strUserName = objclsSecurity.UserName;

                    if (objCategory.UpdateInsertProjectType(intprojid, strProjName, strStatus, strUserName, ref paramOut))
                    {
                        intResults = Convert.ToInt32(paramOut[0].Value);

                        if (intResults == 0)
                        {
                            InsertUpdateSuccess();
                            fillValueBykey();
                            lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(strProjName))].Selected = true;
                        }
                        else if (intResults == 1)
                        {
                            BasicRecordExist();
                        }
                        else
                        {
                            InsertUpdateerr();
                        }
                    }
                }
                else if (drpkey.SelectedIndex == 3)
                {
                    int intfunid = 0;
                    if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
                    {
                        intfunid = 0;
                    }
                    else
                    {
                        intfunid = Convert.ToInt32(lbKeyValues.SelectedValue);
                    }
                    string strfunName = txtKeyValue.Text;
                    //lbKeyValues.SelectedItem.Text
                    //string strStatus = "A";
                    if (objclsSecurity == null)
                    {
                        objclsSecurity = new clsSecurity();
                    }
                   
                    //clsBasicinfoBO objCategory = new clsBasicinfoBO();
                    //int intResults = 0;
                    //intResults = objCategory.UpdateInsertFunction(intfunid, strfunName, strUserName, strStatus);

                    if (objCategory == null)
                    {
                        objCategory = new clsBasicinfoBO();
                    }
                    if (paramOut == null)
                    {
                        paramOut = new SqlParameter[1];
                    }
                    strUserName = objclsSecurity.UserName;
                    if (objCategory.UpdateInsertFunction(intfunid, strfunName, strUserName, strStatus, ref paramOut))
                    {
                        intResults = Convert.ToInt32(paramOut[0].Value);
                        if (intResults == 0)
                        {

                            InsertUpdateSuccess();
                            fillValueBykey();
                            lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(strfunName))].Selected = true;
                        }
                        else if (intResults == 1)
                        {

                            BasicRecordExist();
                        }
                        else
                        {

                            InsertUpdateerr();
                        }
                    }

                }
                else if (drpkey.SelectedIndex == 4)
                {
                    int intMachID = 0;
                    if (lbKeyValues.SelectedItem.Text == "--Select Key Value--")
                    {
                        intMachID = 0;
                    }
                    else
                    {
                        intMachID = Convert.ToInt32(lbKeyValues.SelectedValue);
                    }

                    int intMachTypeID = 1;
                    int intPlantID = 0;
                    int intCatID = 0;
                    string strMachName = txtKeyValue.Text;
                    //lbKeyValues.SelectedItem.Text
                    //string strStatus = "A";
                    //string strUserName = System.Security.UserName();
                    //clsBasicinfoBO objCategory = new clsBasicinfoBO();
                    //int intResults = 0;
                    //intResults = objCategory.UpdateInsertMachine(intMachID, intMachTypeID, intPlantID, intCatID, strMachName, strStatus, strUserName);
                    if (objclsSecurity == null)
                    {
                        objclsSecurity = new clsSecurity();
                    }
                    
                    if (objCategory == null)
                    {
                        objCategory = new clsBasicinfoBO();
                    }
                    if (paramOut == null)
                    {
                        paramOut = new SqlParameter[1];
                    }
                    strUserName = objclsSecurity.UserName;

                    if (objCategory.UpdateInsertMachine(intMachID, intMachTypeID, intPlantID, intCatID, strMachName, strStatus, strUserName, ref paramOut))
                    {
                        intResults = Convert.ToInt32(paramOut[0].Value);
                        if (intResults == 0)
                        {
                            InsertUpdateSuccess();
                            fillValueBykey();
                            lbKeyValues.Items[lbKeyValues.Items.IndexOf(lbKeyValues.Items.FindByText(strMachName))].Selected = true;
                        }
                        else if (intResults == 1)
                        {
                            BasicRecordExist();
                        }
                        else
                        {
                            InsertUpdateerr();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objCategory = null;
                paramOut = null;
                objclsSecurity = null;
            }


        }

        private void InsertSuccess()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='../Administration/ViewBasicInfo.aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "InsertSuccess", strScript);
        }

        private void InsertUpdateSuccess()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertUpdateSuccess"] + "');window.location='../Administration/ViewBasicInfo.aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "InsertUpdateSuccess", strScript);
        }

        private void BasicRecordExist()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["BasicRecordExist"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "BasicRecordExist", strScript);
        }

        private void InsertUpdateerr()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertUpdateerr"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "InsertUpdateerr", strScript);
        }

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	imgCancel_Click
        //Written BY	    :	chary
        //parameters     :	None
        //Purpose	    :   To navigate VieBasicInfo Page
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/26/07                 chary              1.0           created
        //***************************************************


        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewBasicInfo.aspx");
        }
    }
}