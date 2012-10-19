using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;

namespace MUREOUI.Common
{
    public partial class frmViewProject : System.Web.UI.Page
    {
        #region "Declaration"
        clsProject clsPrj = new clsProject();
        clsSecurity cls = new clsSecurity();
        DataSet dsHistory;
        DataSet dsProject;
        static string strUserRole;
        string strUser;
        DataSet dsCheckUser;
        string strCreatedUser;
        bool boolAllowPOC = false;
        string strProjectLead;
        #endregion
        bool boolAllowProjectLead = false;

        #region "Load Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strUserRole = null;
                strUserRole = cls.UserRole();

                //Put user code to initialize the page here
                //Dim drPrjDetails As SqlDataReader = clsPrj.GetDr("GET_MUR_Project", "@p_Project_ID", Request.QueryString["ProjectID"))

                //'Displaying project related data based project id
                //If drPrjDetails.HasRows Then
                //    While drPrjDetails.Read()
                //        lblCategoryValue.Text = drPrjDetails.GetString(6)
                //        lblBrandValue.Text = drPrjDetails.GetString(3)
                //        lblPrjNameValue.Text = drPrjDetails.GetString(1)
                //        lblPrjTypeValue.Text = drPrjDetails.GetString(2)
                //        lblPrjLeadValue.Text = drPrjDetails.GetString(4)
                //        lblPOCValue.Text = drPrjDetails.GetString(5)
                //    End While
                //End If
                //drPrjDetails.Close()
                dsProject = new DataSet();
                if(clsPrj.FetchProjectDetails(Convert.ToInt32(Request.QueryString["ProjectID"]), ref dsProject))
                {
                if (dsProject == null)
                {
                    NoData("Project details does not exist(s) in the database.");
                    return;
                }
                else if (dsProject.Tables.Count == 0)
                {
                    NoData("Project details does not exist(s) in the database.");
                    return;
                }
                else if (dsProject.Tables[0].Rows.Count == 0)
                {
                    NoData("Project details does not exist(s) in the database.");
                    return;
                }
                lblCategoryValue.Text = Convert.ToString(dsProject.Tables[0].Rows[0][6]);
                //drPrjDetails.GetString(6)
                lblBrandValue.Text = Convert.ToString(dsProject.Tables[0].Rows[0][3]);
                lblPrjNameValue.Text = Convert.ToString(dsProject.Tables[0].Rows[0][1]);
                lblPrjTypeValue.Text = Convert.ToString(dsProject.Tables[0].Rows[0][2]);
                lblPrjLeadValue.Text = Convert.ToString(dsProject.Tables[0].Rows[0][4]);
                lblPOCValue.Text = Convert.ToString(dsProject.Tables[0].Rows[0][5]);
                lblHeading.Text = "Project -  " + lblPrjNameValue.Text;
                FillHistoryGrid(Request.QueryString["ProjectID"]);
                if (!Page.IsPostBack)
                {
                    if (strUserRole.ToUpper() == "MUREO_Admin".ToUpper() | cls.UserName.ToUpper() == Convert.ToString(dsProject.Tables[0].Rows[0]["Created_By"]).ToUpper())
                    {
                        imgEdit.Visible = true;
                        imgCancel.Visible = true;
                    }
                    else
                    {
                        imgEdit.Visible = false;
                        imgCancel.Visible = false;
                    }

                }
                }
            }
            catch (Exception ex)
            {
                string script = null;
                string exMessage = null;
                exMessage = ex.Message.Replace("'", " ");
                script = "alert('" + exMessage + "'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }


        #endregion

        #region "Click Events"
        protected void imgEdit_Click(object sender, EventArgs e)
        {
            strUser = cls.UserName;
            strUserRole = cls.UserRole();

            dsCheckUser = new DataSet();
            if(clsPrj.FetchProjectDetails(Convert.ToInt32(Request.QueryString["ProjectID"]),ref dsCheckUser))
            {

            //Getting the name of the created user 
            strCreatedUser = Convert.ToString(dsCheckUser.Tables[0].Rows[0][7]);

            if (strCreatedUser == strUser)
            {
                Response.Redirect("frmNewProject.aspx?ProjectID=" + Request.QueryString["ProjectID"] + "&Mode=Edit");
            }

            //code for reading the values from POC field
            string strReadExistingNames = null;
            string[] strDivideString = null;
            strReadExistingNames = Convert.ToString(dsCheckUser.Tables[0].Rows[0][5]);
            if (!(strReadExistingNames == string.Empty))
            {
                strDivideString = strReadExistingNames.Split(',');               
                for (int i = 0; i <= strDivideString.Length - 1; i++)
                {
                    if (strUser == strDivideString[i])
                    {
                        boolAllowPOC = true;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }

            if (boolAllowPOC == true)
            {
                Response.Redirect("frmNewProject.aspx?ProjectID=" + Request.QueryString["ProjectID"] + "&Mode=Edit");
            }

            //code for reading the values from project lead
            string strReadProjectLead = null;
            string[] strDivideStringProjectlead = null;
            strReadProjectLead = Convert.ToString(dsCheckUser.Tables[0].Rows[0][4]);

            if (!(strReadProjectLead == string.Empty))
            {
                strDivideStringProjectlead = strReadProjectLead.Split(',');
                for (int i = 0; i <= strDivideStringProjectlead.Length - 1; i++)
                {
                    if (strUser == strDivideStringProjectlead[i])
                    {
                        boolAllowProjectLead = true;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }

            if (boolAllowProjectLead == true)
            {
                Response.Redirect("frmNewProject.aspx?ProjectID=" + Request.QueryString["ProjectID"] + "&Mode=Edit");
            }
            if (strUserRole == "MUREO_Admin")
            {
                Response.Redirect("frmNewProject.aspx?ProjectID=" + Request.QueryString["ProjectID"] + "&Mode=Edit");
                //ElseIf strUserRole = "MUREO_Editors" Then
                //    Response.Redirect("frmEditEvent.aspx?EventID=" & Request.QueryString["EventID"))
                //ElseIf strUserRole = "MUREO_Readers" Then
                //    Dim script As String
                //    script = "alert('Access Denied.\nYou donot have sufficient privelages to perform the operation.'); "
                //    Page.RegisterStartupScript("clientscript", script)
                //ElseIf strUserRole = "Readers" Then
            }
            else
            {
                string script = null;
                script = "alert('Access Denied.\\nYou donot have sufficient privelages to perform the operation.');window.navigate('Home.aspx'); ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            }

        }

        protected void imgCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../common/Home.aspx");
        }

        #endregion


        #region "User Define Methods / Functions"

        public void NoData(string strMessage)
        {            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "alert('" + strMessage + "');", true);
        }

        //  ************************************************
        //Name   	    :	FillHistoryGrid
        //Written BY	    :	Abdul
        //parameters     :	parProjectid
        //Purpose	    :   fills the datagrid for displaying history details of the project
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/27/07                 Abdul            1.0           initial (Created)
        //***************************************************
        public void FillHistoryGrid(string parProjectID)
        {
            dsHistory = new DataSet();
            if (clsPrj.FillHistoryofProject(Convert.ToInt32(parProjectID), ref dsHistory))
            {
                dgdShowHistory.DataSource = dsHistory.Tables[1].DefaultView;
                dgdShowHistory.DataBind();
            }
        }

        #endregion

    }
}