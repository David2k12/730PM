using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOUI.Common;
using System.Data;
using MUREOBAL;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using System.Data.SqlClient;
using System.Text;

namespace MUREOUI.Reports
{
    public partial class MYEOs : System.Web.UI.Page
    {
        #region "Member Variables"
        string strUserName;
        clsSecurity objSecurity = new clsSecurity();
        string strScript;
        string strCurrentStage;
        #endregion
        static string strUserRole;

        #region "Page Events"
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        FillMYEODataGrid();
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            strUserRole = objSecurity.UserRole();
            if (strUserRole == "MUREO_Admin")
            {
                imgCreateEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Editors")
            {
                imgCreateEO.Enabled = true;
            }
            else if (strUserRole == "MUREO_Readers")
            {
                imgCreateEO.Enabled = false;
                //Response.Redirect("~/Common/Home.aspx")
            }
            else if (strUserRole == "Readers")
            {
                imgCreateEO.Enabled = false;
                //Response.Redirect("~/Common/Home.aspx")
            }
            if (!IsPostBack)
            {
                FillMYEODataGrid();
            }
        }

        #endregion

        #region "DataGrid Events"
        public void NoApprovarList()
        {
            strScript = "<script>alert('Approvar list is not available.');</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Ret"] != null)
                {
                    string script = "DeleteMessage('" + Convert.ToString(Session["Ret"]) + "', '" + Convert.ToString(Session["Status"]) + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void hypModifiedDate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void ImgReadOnlyEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strstage = Convert.ToString(e.CommandArgument);

                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/ViewSiteTest.aspx?EoID={0}", intEOID));
                }
                else
                {
                    if (strstage.ToUpper() == "Preliminary".ToUpper())
                    {
                        view = "1";
                    }
                    else if (strstage.ToUpper() == "Final".ToUpper())
                    {
                        view = "2";
                    }
                    else if (strstage.ToUpper() == "Closeout".ToUpper())
                    {
                        view = "3";
                    }
                    Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", Convert.ToString(intEOID), Convert.ToString(view), "Report"));
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void imgDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string view = string.Empty;
                string strCurrentStage = Convert.ToString(e.CommandArgument);
                string script = null;
                script = "DeleteEO('" + intEOID + "','" + strCurrentStage + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgStopEO_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ClsMyEOs clsmyeo = new ClsMyEOs();
                int intEOID = Convert.ToInt32(e.CommandName);
                int intRetValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (clsmyeo.DeleteStopCancelEO(intEOID, 'S', objSecurity.UserName, ref paramout))
                {
                    intRetValue = Convert.ToInt32(paramout[0].Value);
                    if (intRetValue == 0)
                    {
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["EORecordStopSucc"] + "'); window.location = 'MyEOs.aspx';</script>";
                        ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
                    }
                    else if (intRetValue == 1)
                    {
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["EORecordStopFail"] + "'); window.location = 'MyEOs.aspx';</script>";
                        ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
                    }
                }               
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCheckApproval_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ClsMyEOs clsme = new ClsMyEOs();
                int intEOID = Convert.ToInt32(e.CommandName);
                string strCurrentStage = Convert.ToString(e.CommandArgument);
                DataSet dsApprovar = new DataSet();
                if (clsme.ShowApprovals(intEOID, strCurrentStage, ref dsApprovar))
                {

                    if (dsApprovar == null)
                    {
                        NoApprovarList();
                    }
                    else if (dsApprovar.Tables.Count == 0)
                    {
                        NoApprovarList();
                    }
                    else if (dsApprovar.Tables[0].Rows.Count == 0)
                    {
                        NoApprovarList();
                    }
                    else
                    {
                        DataTable dt = null;
                        dt = dsApprovar.Tables[0];
                        int rowCount = dt.Rows.Count;
                        Int16 colCount = Convert.ToInt16(dt.Columns.Count);
                        int rowLoop = 0;
                        int colLoop = 0;
                        StringBuilder sb = new StringBuilder();
                        string strApprovar = null;
                        for (rowLoop = 0; rowLoop <= rowCount - 1; rowLoop++)
                        {
                            //For colLoop = 0 To colCount - 1
                            // strApprovar = strApprovar & dt.Rows(rowLoop).Item(colLoop) & "\n"
                            strApprovar = strApprovar + dt.Rows[rowLoop][0] + "\\t\\t\\t" + dt.Rows[rowLoop][1] + "\\t\\t\\t" + dt.Rows[rowLoop][2] + "\\n";
                            //Next
                        }
                        if (!(strApprovar == string.Empty))
                        {
                            string script = null;
                            //Added by abdul on 31-jan-2008
                            //New code where the user can view the approvers in a show modal dialog box.
                            if (strCurrentStage.ToUpper() == "Preliminary".ToUpper())
                            {
                                script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:300px');</script>";
                                ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", script);
                            }
                            else if (strCurrentStage.ToUpper() == "Final".ToUpper())
                            {
                                script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:400px');</script>";
                                ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", script);
                            }
                            else if (strCurrentStage.ToUpper() == "Closeout".ToUpper())
                            {
                                script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:200px');</script>";
                                ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", script);
                            }
                            //Previous code where the approvers are shown in a alert box where the format was not proper
                            //strScript = "<script>alert('" & strApprovar & "');</script>"
                            //Page.RegisterStartupScript("ClientScript", strScript)
                        }
                        else
                        {
                            strScript = "<script>alert('Approvar list is not available.');</script>";
                            ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCancel_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ClsMyEOs clsmyeo = new ClsMyEOs();
                int intEOID = Convert.ToInt32(e.CommandName);
                string strCurrentStage = Convert.ToString(e.CommandArgument);
                int intRetValue = -1;
                SqlParameter[] paramout = new SqlParameter[1];
                if (clsmyeo.DeleteStopCancelEO(intEOID, 'C', objSecurity.UserName, ref paramout))
                {
                    intRetValue = Convert.ToInt32(paramout[0].Value);
                    if (intRetValue == 0)
                    {
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["CancelSuccessMsg"] + "');</script>";
                        ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
                        //dgdEventInfo.Visible = False
                        //lblEOTitleVal.Visible = False
                    }
                    else if (intRetValue == 1)
                    {
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["CancelErrMsg"] + "');</script>";
                        ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
                    }
                    FillMYEODataGrid();
                }
            }
            catch (Exception exc)
            {

            }
        }
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	DisplayBoundColumnValues()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	Built in
        //Purpose	    :   for execution of commondname utility of the datagrid.
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //08/22/07                Md.Abdul allaam             1.0           created
        //10/09/07                Md.Abdul Allaam             2.0          'Previous the links were
        //***************************************************

        //public void DisplayBoundColumnValues(object sender, DataGridCommandEventArgs e)
        //{
        //    if (e.CommandName == "EONum_Link")
        //    {
        //        //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
        //        //following get the current stage of the Eo
        //        Label lnkStage = default(Label);
        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        string strStage = lnkStage.Text;

        //        if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
        //        }
        //        else
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //        }
        //    }
        //    else if (e.CommandName == "EOStage_Link")
        //    {
        //        //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
        //        //following gets the title of the EO
        //        LinkButton lblEOTitle = default(LinkButton);
        //        lblEOTitle = (LinkButton)e.Item.FindControl("hypEOTitle");
        //        string strEOTitle = lblEOTitle.Text;

        //        //following get the current stage of the Eo
        //        Label lnkStage = default(Label);
        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        string strStage = lnkStage.Text;

        //        if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            //lblEOTitleVal.Text = strEOTitle
        //            //FillEventInfoForEO(intEOID)
        //        }
        //        else
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            //lblEOTitleVal.Text = strEOTitle
        //            //FillEventInfoForEO(intEOID)
        //        }
        //    }
        //    else if (e.CommandName == "EOTitle_Link")
        //    {
        //        //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
        //        //following get the current stage of the Eo
        //        Label lnkStage = default(Label);

        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        string strStage = lnkStage.Text;
        //        if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));

        //        }
        //        else
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //        }
        //    }
        //    else if (e.CommandName == "ModifiedDate_Link")
        //    {
        //        //following get the current stage of the Eo
        //        Label lnkStage = default(Label);
        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        string strStage = lnkStage.Text;
        //        if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
        //        }
        //        else
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
        //        }
        //    }
        //    else if (e.CommandName == "ReadOnly")
        //    {
        //        //If dgdMyEO.Items(e.Item.ItemIndex).Cells(4).Text = "Site Test" Then
        //        //following get the current stage of the Eo
        //        Label lnkStage = default(Label);
        //        string view = null;
        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        string strStage = lnkStage.Text;
        //        if (Strings.UCase(strStage) == Strings.UCase("Site Test"))
        //        {
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/ViewSiteTest.aspx?EoID={0}", intEOID));
        //        }
        //        else
        //        {
        //            if (Strings.UCase(strStage) == Strings.UCase("Preliminary"))
        //            {
        //                view = "1";
        //            }
        //            else if (Strings.UCase(strStage) == Strings.UCase("Final"))
        //            {
        //                view = "2";
        //            }
        //            else if (Strings.UCase(strStage) == Strings.UCase("Closeout"))
        //            {
        //                view = "3";
        //            }
        //            int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //            Response.Redirect(string.Format("~/Common/ViewEO.aspx?EO_ID={0}&view={1}&From={2}", intEOID.ToString(), view.ToString(), "Report"));
        //        }
        //    }
        //    else if (e.CommandName == "Delete")
        //    {
        //        //Added by Abdul as the deleting of an EO has to be done with two confirmations i.e why below code.
        //        int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //        Label lnkStage = default(Label);
        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        strCurrentStage = lnkStage.Text;

        //        string script = null;
        //        script = "<script>DeleteEO('" + intEOID + "','" + strCurrentStage + "');</script> ";
        //        ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);

        //    }
        //    else if (e.CommandName == "Stop")
        //    {
        //        int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //        int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "S", objSecurity.UserName);
        //        if (intRetValue == 0)
        //        {
        //            strScript = "<script>alert('" + ConfigurationManager.AppSettings["EORecordStopSucc") + "');</script>";
        //            ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //        }
        //        else if (intRetValue == 1)
        //        {
        //            strScript = "<script>alert('" + ConfigurationManager.AppSettings["EORecordStopFail") + "');</script>";
        //            ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //        }

        //    }
        //    else if (e.CommandName == "CheckApproval")
        //    {
        //        //following get the current stage of the Eo
        //        Label lnkStage = default(Label);
        //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //        string strStage = lnkStage.Text;

        //        int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //        //strCurrentStage = e.Item.Cells(4).Text
        //        strCurrentStage = strStage;

        //        DataSet dsApprovar = new DataSet();
        //        dsApprovar = BusinessObject.MUREO.BusinessObject.ClsMyEOs.ShowApprovals(intEOID, strCurrentStage);
        //        if (dsApprovar == null)
        //        {
        //            NoApprovarList();
        //        }
        //        else if (dsApprovar.Tables.Count == 0)
        //        {
        //            NoApprovarList();
        //        }
        //        else if (dsApprovar.Tables[0].Rows.Count == 0)
        //        {
        //            NoApprovarList();
        //        }
        //        else
        //        {
        //            DataTable dt = null;
        //            dt = dsApprovar.Tables[0];
        //            int rowCount = dt.Rows.Count;
        //            Int16 colCount = dt.Columns.Count;
        //            int rowLoop = 0;
        //            int colLoop = 0;
        //            StringBuilder sb = new StringBuilder();
        //            string strApprovar = null;
        //            for (rowLoop = 0; rowLoop <= rowCount - 1; rowLoop++)
        //            {
        //                //For colLoop = 0 To colCount - 1
        //                // strApprovar = strApprovar & dt.Rows(rowLoop).Item(colLoop) & "\n"
        //                strApprovar = strApprovar + dt.Rows[rowLoop][0] + "\\t\\t\\t" + dt.Rows[rowLoop][1] + "\\t\\t\\t" + dt.Rows[rowLoop][2] + "\\n";
        //                //Next
        //            }
        //            if (!(strApprovar == string.Empty))
        //            {
        //                string script = null;
        //                //Added by abdul on 31-jan-2008
        //                //New code where the user can view the approvers in a show modal dialog box.
        //                if (Strings.UCase(strCurrentStage) == Strings.UCase("Preliminary"))
        //                {
        //                    script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:300px');</script>";
        //                    ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //                }
        //                else if (Strings.UCase(strCurrentStage) == Strings.UCase("Final"))
        //                {
        //                    script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:400px');</script>";
        //                    ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //                }
        //                else if (Strings.UCase(strCurrentStage) == Strings.UCase("Closeout"))
        //                {
        //                    script = "<script>window.showModalDialog('ShowApprovers.aspx?EventID=" + intEOID + "&stage=" + strCurrentStage + "',null,'dialogWidth:650px;dialogHeight:200px');</script>";
        //                    ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //                }
        //                //Previous code where the approvers are shown in a alert box where the format was not proper
        //                //strScript = "<script>alert('" & strApprovar & "');</script>"
        //                //Page.RegisterStartupScript("ClientScript", strScript)
        //            }
        //            else
        //            {
        //                strScript = "<script>alert('Approvar list is not available.');</script>";
        //                ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //            }
        //        }

        //    }
        //    else if (e.CommandName == "Cancel")
        //    {
        //        int intEOID = Convert.ToInt32(dgdMyEO.DataKeys(e.Item.ItemIndex));
        //        int intRetValue = BusinessObject.MUREO.BusinessObject.ClsMyEOs.DeleteStopCancelEO(intEOID, "C", objSecurity.UserName);
        //        if (intRetValue == 0)
        //        {
        //            strScript = "<script>alert('" + ConfigurationManager.AppSettings["CancelSuccessMsg") + "');</script>";
        //            ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //            //dgdEventInfo.Visible = False
        //            //lblEOTitleVal.Visible = False
        //        }
        //        else if (intRetValue == 1)
        //        {
        //            strScript = "<script>alert('" + ConfigurationManager.AppSettings["CancelErrMsg") + "');</script>";
        //            ClientScript.RegisterStartupScript(typeof(Page),"ClientScript",script);
        //        }
        //    }
        //    FillMYEODataGrid();
        //}

        //protected void dgdMyEO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        //Dim imgbDelete As ImageButton = CType(e.Item.FindControl("imgDelete"), ImageButton)
        //        //imgbDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();")
        //        ImageButton imgbStop = (ImageButton)e.Item.FindControl("imgStopEO");
        //        imgbStop.Attributes.Add("OnClick", "javascript:return confirmStop();");
        //        ImageButton imgbCancel = (ImageButton)e.Item.FindControl("imgCancel");
        //        imgbCancel.Attributes.Add("OnClick", "javascript:return confirmCancel();");
        //    }
        //    e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        //    e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Center;

        //    //Dim imgbDelete As ImageButton = CType(e.Item.FindControl("imgDelete"), ImageButton)
        //    //Dim imgbStop As ImageButton = CType(e.Item.FindControl("imgStop"), ImageButton)
        //    //If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

        //    //    imgbDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();")
        //    //End If

        //    //Added by Abdul on 15-Sept-08 for changing the status from Approved to Completed.
        //    Label lnkStage = default(Label);
        //    lnkStage = (Label)e.Item.FindControl("hypEOStage1");
        //    if ((lnkStage != null))
        //    {
        //        if (Strings.UCase(lnkStage.Text) == Strings.UCase("CloseOut") & Strings.UCase(e.Item.Cells[5].Text) == Strings.UCase("Approved"))
        //        {
        //            e.Item.Cells[5].Text = "Completed";
        //        }
        //    }
        //}

        protected void EOTitle_Link_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int intEOID = Convert.ToInt32(e.CommandName);
                string strstage = Convert.ToString(e.CommandArgument);
                //    
                if (strstage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void hypEONumber_Command(object sender, CommandEventArgs e)
        {
            try
            {
                LinkButton lnkEONum = (LinkButton)sender;

                //        lnkStage = (Label)e.Item.FindControl("hypEOStage1");
                string strStage = Convert.ToString(e.CommandArgument);
                int intEOID = 0;
                if (e.CommandName != null)
                    intEOID = Convert.ToInt32(e.CommandName);
                if (strStage.ToUpper() == "Site Test".ToUpper())
                {
                    Response.Redirect(string.Format("~/Common/SiteTest.aspx?From={0}&EoID={1}&Page={2}", "EDIT", intEOID, "MYEOs"));
                }
                else
                {
                    Response.Redirect(string.Format("~/Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID));
                }
            }
            catch (Exception exc)
            {

            }
        }

        //protected void dgdMyEO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        //{
        //    dgdMyEO.PageIndex = e.NewPageIndex;
        //    //FillMYEODataGrid()
        //}

        //protected void dgdMyEO_ItemSortCommand(object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        //{
        //    if (Convert.ToString(ViewState["StrSort")) == " Desc")
        //    {
        //        ViewState["StrSort") = " Asc";
        //    }
        //    else
        //    {
        //        ViewState["StrSort") = " Desc";
        //    }
        //    ViewState["SortExp") = e.SortExpression;
        //    FillMYEODataGrid();
        //}
        #endregion

        #region "User Define Methods"

        protected void NoDataForGrid()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRec"] + "');</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", strScript);
        }
        protected void dgdMyEO_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillMYEODataGrid();
                //FillMYEODataGrid();
            }
            catch (Exception exc)
            {


            }
        }
        public void FillMYEODataGrid()
        {
            try
            {
                ClsMyEOs clsmyeo = new ClsMyEOs();
                strUserName = objSecurity.UserName;
                //strUserName = "Surendra Bolla-su"

                DataSet dsSeedData = new DataSet();
                if (clsmyeo.GetMyEOs(strUserName, ref dsSeedData))
                {
                    if (dsSeedData == null)
                    {
                        NoDataForGrid();
                        return;
                    }
                    else if (dsSeedData.Tables.Count == 0)
                    {
                        //dgdMyEO.Visible = False
                        NoDataForGrid();
                        return;
                    }
                    else if (dsSeedData.Tables[0].Rows.Count == 0)
                    {
                        //dgdMyEO.Visible = False
                        NoDataForGrid();
                        return;
                    }
                    //dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data")
                    dgdMyEO.DataSource = dsSeedData.Tables[0].DefaultView;
                    if (((dsSeedData.Tables[0].Rows.Count) <= dgdMyEO.VisibleRowCount))
                    {
                        if (dgdMyEO.PageIndex != 0)
                        {
                            dgdMyEO.PageIndex -= 1;
                        }
                    }

                    dgdMyEO.DataBind();


                    //following code is for hiding and showing of buttons based on the condition.

                    //for (int numRows = 0; numRows <= dgdMyEO.VisibleRowCount - 1; numRows++)
                    //{
                    //    //following code get the EO Title of the Eo
                    //    //Dim lblEoTitle As Label = CType(dgdMyEO.Items(numRows).FindControl("hypEONumber"), Label)

                    //    LinkButton lblEONumber = (LinkButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["EO Num"], "hypEONumber");
                    //    Label lnkStage = (Label)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Current Stage"], "hypEOStage1");
                    //    //DevExpress.Web.ASPxEditors.ASPxButton imgApprovar = (DevExpress.Web.ASPxEditors.ASPxButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Check Approvals"], "imgCheckApproval");
                    //    ImageButton imgApprovar = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Check Approvals"], "imgCheckApproval");
                    //    ImageButton imgCancel = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Cancel EO?"], "imgCancel");
                    //    ImageButton imgDelete = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Delete EO?"], "imgDelete");
                    //    string strEONumber = string.Empty;
                    //    if (lblEONumber != null)
                    //    {
                    //        strEONumber = lblEONumber.Text;

                    //        //following code get the current stage of the Eo                   
                    //        string strStage = lnkStage.Text;
                    //        if (imgApprovar != null)
                    //        {
                    //            if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Draft".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "&nbsp;".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Admin Close-Out".ToUpper())
                    //            {
                    //                imgApprovar.Visible = false;
                    //            }
                    //            else
                    //            {
                    //                imgApprovar.Visible = true;
                    //            }
                    //        }

                    //        //Displaying of cancel button when EO has a EO Number.                  
                    //        if (imgCancel != null)
                    //        {
                    //            if (strEONumber == string.Empty)
                    //            {
                    //                imgCancel.Visible = false;
                    //            }
                    //            else if (strEONumber.Trim().ToUpper() == "NEW EO")
                    //            {
                    //                imgCancel.Visible = false;
                    //                //Modified by Abdul on 15-Sept-08 for considering completed status
                    //            }
                    //            else if (strStage.ToUpper() == "closeout".ToUpper() & lblEONumber.Attributes["Stage_Status"].ToUpper() == "Routed".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Approved".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Completed".ToUpper())
                    //            {
                    //                imgCancel.Visible = false;
                    //            }
                    //            else
                    //            {
                    //                imgCancel.Visible = true;
                    //            }
                    //        }

                    //        //Hiding of Delete button when EO has a EO Number.                  
                    //        if (imgDelete != null)
                    //        {
                    //            if (strEONumber == string.Empty & strStage.ToUpper() == "Preliminary".ToUpper())
                    //            {
                    //                imgDelete.Visible = true;
                    //                //Added by abdul on 26-feb-2008 for checking of NewEO as the eo number
                    //            }
                    //            else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & strStage.ToUpper() == "Preliminary".ToUpper())
                    //            {
                    //                imgDelete.Visible = true;
                    //            }
                    //            else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & strStage.ToUpper() == "Site Test".ToUpper() & !(lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper()))
                    //            {
                    //                imgDelete.Visible = true;
                    //            }
                    //            else if (strEONumber == string.Empty & strStage.ToUpper() == "Site Test".ToUpper() & !(lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper()))
                    //            {
                    //                imgDelete.Visible = true;
                    //            }
                    //            else if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper())
                    //            {
                    //                imgDelete.Visible = false;
                    //            }
                    //            else
                    //            {
                    //                imgDelete.Visible = false;
                    //            }
                    //        }

                    //        //Displaying of stop button when EO is in Routed stage.                    
                    //        ImageButton imgStop = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Stop this EO?"], "imgStopEO");
                    //        if (imgStop != null)
                    //        {
                    //            if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Routed".ToUpper() & !(strStage.ToUpper() == "closeout".ToUpper()))
                    //            {
                    //                imgStop.Visible = true;
                    //            }
                    //            else if (strStage == "Site Test" | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Draft".ToUpper())
                    //            {
                    //                imgStop.Visible = false;
                    //                //Modified by Abdul on 15-Sept-08 for considering completed status
                    //            }
                    //            else if (strStage.ToUpper() == "closeout".ToUpper() & lblEONumber.Attributes["Stage_Status"].ToUpper() == "Routed".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Approved".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Completed".ToUpper())
                    //            {
                    //                imgStop.Visible = false;
                    //            }
                    //        }
                    //        //Disabling a particular  row of site test when the site test is close out
                    //        if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper())
                    //        {
                    //            //Following code to get EO title of the EO
                    //            LinkButton lnkEOTitle = (LinkButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["EO Title"], "hypEOTitle");

                    //            //Following code to get Modified date of the EO                        
                    //            LinkButton lnkModifiedDate = (LinkButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Last Modified"], "hypModifiedDate");

                    //            //lblEONumber.Enabled = False
                    //            //lnkStage.Enabled = False
                    //            //lnkEOTitle.Enabled = False
                    //            //lnkModifiedDate.Enabled = False


                    //            //New code
                    //            Label lblEoTitle = (Label)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["EO Title"], "lblEOTitle");
                    //            Label lblENum = (Label)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["EO Num"], "lblEnum");
                    //            Label lblModiLink = (Label)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Last Modified"], "lblModiLink");
                    //            if (lnkEOTitle != null)
                    //                lnkEOTitle.Visible = false;
                    //            if (lblEoTitle != null)
                    //                lblEoTitle.Visible = true;
                    //            if (lnkStage != null)
                    //                lnkStage.Visible = true;
                    //            if (lblEONumber != null)
                    //                lblEONumber.Visible = false;
                    //            if (lblENum != null)
                    //                lblENum.Visible = true;
                    //            if (lblModiLink != null)
                    //                lblModiLink.Visible = true;
                    //            if (lnkModifiedDate != null)
                    //                lnkModifiedDate.Visible = false;
                    //            //End of New code
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception exc)
            {

            }

        }
        protected void dgdMyEO_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                    LinkButton lblEONumber = (LinkButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["EO Num"], "hypEONumber");
                        Label lnkStage = (Label)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Current Stage"], "hypEOStage1");
                        DevExpress.Web.ASPxEditors.ASPxButton imgApprovar = (DevExpress.Web.ASPxEditors.ASPxButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Check Approvals"], "imgCheckApproval");
                       //ImageButton imgApprovar = (ImageButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Check Approvals"], "imgCheckApproval");
                        DevExpress.Web.ASPxEditors.ASPxButton imgCancel = (DevExpress.Web.ASPxEditors.ASPxButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Cancel EO?"], "imgCancel");
                        DevExpress.Web.ASPxEditors.ASPxButton imgDelete = (DevExpress.Web.ASPxEditors.ASPxButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Delete EO?"], "imgDelete");
                        string strEONumber = string.Empty;
                        if (lblEONumber != null)
                        {
                            strEONumber = lblEONumber.Text;

                            //following code get the current stage of the Eo                   
                            string strStage = lnkStage.Text;
                            if (imgApprovar != null)
                            {
                                if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Draft".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "&nbsp;".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Admin Close-Out".ToUpper())
                                {
                                    imgApprovar.Visible = false;
                                }
                                else
                                {
                                    imgApprovar.Visible = true;
                                }
                            }

                            //Displaying of cancel button when EO has a EO Number.                  
                            if (imgCancel != null)
                            {
                                if (strEONumber == string.Empty)
                                {
                                    imgCancel.Visible = false;
                                }
                                else if (strEONumber.Trim().ToUpper() == "NEW EO")
                                {
                                    imgCancel.Visible = false;
                                    //Modified by Abdul on 15-Sept-08 for considering completed status
                                }
                                else if (strStage.ToUpper() == "closeout".ToUpper() & lblEONumber.Attributes["Stage_Status"].ToUpper() == "Routed".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Approved".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Completed".ToUpper())
                                {
                                    imgCancel.Visible = false;
                                }
                                else
                                {
                                    imgCancel.Visible = true;
                                }
                            }

                            //Hiding of Delete button when EO has a EO Number.                  
                            if (imgDelete != null)
                            {
                                if (strEONumber == string.Empty & strStage.ToUpper() == "Preliminary".ToUpper())
                                {
                                    imgDelete.Visible = true;
                                    //Added by abdul on 26-feb-2008 for checking of NewEO as the eo number
                                }
                                else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & strStage.ToUpper() == "Preliminary".ToUpper())
                                {
                                    imgDelete.Visible = true;
                                }
                                else if (strEONumber.Trim().ToUpper() == "NEW EO".Trim().ToUpper() & strStage.ToUpper() == "Site Test".ToUpper() & !(lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper()))
                                {
                                    imgDelete.Visible = true;
                                }
                                else if (strEONumber == string.Empty & strStage.ToUpper() == "Site Test".ToUpper() & !(lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper()))
                                {
                                    imgDelete.Visible = true;
                                }
                                else if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper())
                                {
                                    imgDelete.Visible = false;
                                }
                                else
                                {
                                    imgDelete.Visible = false;
                                }
                            }

                            //Displaying of stop button when EO is in Routed stage.                    
                            DevExpress.Web.ASPxEditors.ASPxButton imgStop = (DevExpress.Web.ASPxEditors.ASPxButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Stop this EO?"], "imgStopEO");
                            if (imgStop != null)
                            {
                                if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Routed".ToUpper() & !(strStage.ToUpper() == "closeout".ToUpper()))
                                {
                                    imgStop.Visible = true;
                                }
                                else if (strStage == "Site Test" | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Draft".ToUpper())
                                {
                                    imgStop.Visible = false;
                                    //Modified by Abdul on 15-Sept-08 for considering completed status
                                }
                                else if (strStage.ToUpper() == "closeout".ToUpper() & lblEONumber.Attributes["Stage_Status"].ToUpper() == "Routed".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Approved".ToUpper() | lblEONumber.Attributes["Stage_Status"].ToUpper() == "Completed".ToUpper())
                                {
                                    imgStop.Visible = false;
                                }
                                //imgStop.Attributes.Add("OnClick", "javascript:return confirmStop();");
                            }
                            //Disabling a particular  row of site test when the site test is close out
                            if (lblEONumber.Attributes["Stage_Status"].ToUpper() == "Close-Out".ToUpper())
                            {
                                //Following code to get EO title of the EO
                                LinkButton lnkEOTitle = (LinkButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["EO Title"], "hypEOTitle");

                                //Following code to get Modified date of the EO                        
                                LinkButton lnkModifiedDate = (LinkButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Last Modified"], "hypModifiedDate");

                                //lblEONumber.Enabled = False
                                //lnkStage.Enabled = False
                                //lnkEOTitle.Enabled = False
                                //lnkModifiedDate.Enabled = False


                                //New code
                                Label lblEoTitle = (Label)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["EO Title"], "lblEOTitle");
                                Label lblENum = (Label)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["EO Num"], "lblEnum");
                                Label lblModiLink = (Label)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Last Modified"], "lblModiLink");
                                if (lnkEOTitle != null)
                                    lnkEOTitle.Visible = false;
                                if (lblEoTitle != null)
                                    lblEoTitle.Visible = true;
                                if (lnkStage != null)
                                    lnkStage.Visible = true;
                                if (lblEONumber != null)
                                    lblEONumber.Visible = false;
                                if (lblENum != null)
                                    lblENum.Visible = true;
                                if (lblModiLink != null)
                                    lblModiLink.Visible = true;
                                if (lnkModifiedDate != null)
                                    lnkModifiedDate.Visible = false;
                                //End of New code
                            }
                        }
                    //ImageButton imgApprovar = (ImageButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Check Approvals"], "imgCheckApproval");
                    //ImageButton imgCancel = (ImageButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Cancel EO?"], "imgCancel");
                    //ImageButton imgDelete = (ImageButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Delete EO?"], "imgDelete");
                    //ImageButton imgStopEO = (ImageButton)dgdMyEO.FindRowCellTemplateControl(e.VisibleIndex, (GridViewDataColumn)dgdMyEO.Columns["Stop this EO?"], "imgStopEO");

                       // imgDelete.Attributes.Add("OnClick", "javascript:return confirmDelete();");
                       //
                       // imgCancel.Attributes.Add("OnClick", "javascript:return confirmCancel();");
                 
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void imgCheckApproval_Click(object sender, EventArgs e)
        {

        }
        public void EnableDisableLinks(bool optBool)
        {
            //following code is for hiding and showing of buttons based on the condition.
            for (int numRows = 0; numRows <= dgdMyEO.VisibleRowCount - 1; numRows++)
            {
                ImageButton imgApprovar = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Check Approvals"], "imgCheckApproval");
                if (imgApprovar != null && (!optBool))
                    imgApprovar.Enabled = optBool;
             
                //Displaying of cancel button when EO has a EO Number.
                ImageButton imgCancel = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Cancel EO?"], "imgCancel");
                if (imgCancel != null && (!optBool))
                imgCancel.Enabled = optBool;
                //Hiding of Delete button when EO has a EO Number.
                ImageButton imgDelete = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Delete EO?"], "imgDelete");
                if (imgDelete != null && (!optBool))
                imgDelete.Enabled = optBool;
                //Displaying of stop button when EO is in Routed stage.
                ImageButton imgStop = (ImageButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Stop this EO?"], "imgStopEO");
                if (imgStop != null && (!optBool))
                imgStop.Enabled = optBool;
                LinkButton lblEONumber = (LinkButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["EO Num"], "hypEONumber");
                if (lblEONumber != null && (!optBool))
                lblEONumber.Enabled = optBool;
                LinkButton lnkEOTitle = (LinkButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["EO Title"], "hypEOTitle");
                if (lnkEOTitle != null && (!optBool))
                lnkEOTitle.Enabled = optBool;
                LinkButton lnkModifiedDate = (LinkButton)dgdMyEO.FindRowCellTemplateControl(numRows, (GridViewDataColumn)dgdMyEO.Columns["Last Modified"], "hypModifiedDate");
                if (lnkModifiedDate != null && (!optBool))
                lnkModifiedDate.Enabled = optBool;
            }
        }

        //Sub FillEventInfoForEO(ByVal parIntEOID As Integer)
        //    Dim dsEventInfo As New DataSet
        //    dsEventInfo = BusinessObject.MUREO.BusinessObject.ClsMyEOs.FetchEventInfoforEO(parIntEOID)
        //    If dsEventInfo Is Nothing Then
        //        'dgdEventInfo.Visible = False
        //        NoDataForGrid()
        //        Exit Sub
        //    ElseIf dsEventInfo.Tables.Count = 0 Then
        //        'dgdEventInfo.Visible = False
        //        NoDataForGrid()
        //        Exit Sub
        //    ElseIf dsEventInfo.Tables(0).Rows.Count = 0 Then
        //        'dgdEventInfo.Visible = False
        //        NoDataForGrid()
        //        Exit Sub
        //    Else
        //        'dsSeedData = ClsEO.FillDropDownSeedData("GET_EO_Seed_Data")
        //        dgdEventInfo.DataSource = dsEventInfo.Tables(0).DefaultView
        //        dgdEventInfo.DataBind()
        //    End If

        //End Sub

        #endregion

        #region "Click Events"

        protected void imgCreateEO_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("~/Common/NewEO.aspx");
        }
        #endregion



    }
}