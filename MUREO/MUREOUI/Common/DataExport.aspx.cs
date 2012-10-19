﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Common
{
    public partial class DataExport : System.Web.UI.Page
    {
        static DataSet dsProjDetails;
        static DataSet dsEventDetails;
        string script;
        static DataTable Eventdt;
        static DataTable Projectdt;
        clsEvent objclsEvent = new clsEvent();

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ImgExport.Attributes.Add("onclick", "return setHourglass();")
                //dsProjDetails = DataExportBO.GetProjectDetailsBO(0);
                if (objclsEvent.FetchProjectDetailsForEvent("GET_MUR_Project", "@p_Project_ID", 0, ref dsProjDetails))
                {
                    //Get Project details from db
                    //dsEventDetails = DataExportBO.GetEventDetailsBO();
                    if (objclsEvent.GetEventDetailsBO(ref dsEventDetails))
                    {
                        //Get Event details from db
                        //if dataset is null, quit
                        if (dsProjDetails == null & dsEventDetails == null)
                        {
                            NoRecords();
                        }
                        else if (dsProjDetails.Tables.Count == 0 & dsEventDetails.Tables.Count == 0)
                        {
                            NoRecords();
                            //if no data, quit
                        }
                        else if (dsProjDetails.Tables[0].Rows.Count == 0 & dsEventDetails.Tables[0].Rows.Count == 0)
                        {
                            NoRecords();
                        }
                    }
                    
                }
               
            }
        }

        private void NoRecords()
        {
            script = "<script>alert('" + ConfigurationSettings.AppSettings["NoRecords"] + "');</script>";
            Page.RegisterStartupScript("error_message", script);
        }

        protected void ImgExport_Click(object sender, ImageClickEventArgs e)
        {
            string sFile = null;
            string strFileName = null;

            //strFileName = "GetMUREODataTemplate-r01.xls" 'Production purpose & Local
            strFileName = "GetMUREODataTemplate_QA-r01.xls";
            //QA purpose

            //Set the server path of the residing template file
            //sFile = "http://" & Request.Url.Host() & "/MUREO/MURDATA/" & strFileName  'Local purpose
            //sFile = "http://bdc-intra528.internal.pg.com/MUREO/MURDATA/" & strFileName 'Production purpose
            sFile = "http://bdc-intra528.internal.pg.com/MUREO/MURDATA/" + strFileName;
            //QA purpose

            string appstr = "Excel.Application";
            StringBuilder str = default(StringBuilder);

            str = new StringBuilder();
            str.Append("<SCRIPT language=VBScript>");
            str.Append("\r\n");
            str.Append("On Error Resume Next ");
            str.Append("\r\n");
            // Set up constants
            str.Append("Const ForReading = 1");
            str.Append("\r\n");
            str.Append("Const Create = False");
            str.Append("\r\n");
            // Declare local variables
            str.Append("Dim objFSO");
            // FileSystemObject
            str.Append("\r\n");
            str.Append("Dim objSheet");
            str.Append("\r\n");
            // Instantiate the FileSystemObject
            str.Append("set objFSO = CreateObject(\"Scripting.FileSystemObject\")");
            str.Append("\r\n");
            str.Append("Dim tempLoc");
            str.Append("\r\n");
            str.Append("set tempLoc = objFSO.getSpecialFolder(2)");
            str.Append("\r\n");
            str.Append("If objFSO.FileExists(tempLoc + \"\\" + strFileName + "\") Then");
            str.Append("\r\n");
            str.Append("objFSO.DeleteFile(tempLoc + \"\\" + strFileName + "\")");
            str.Append("\r\n");
            str.Append("End If");
            str.Append("\r\n");
            str.Append("If err.Number = 70 Then");
            str.Append("\r\n");
            str.Append("Msgbox(\"File already open. Please close and click on Data Export button again\")");
            str.Append("\r\n");
            str.Append("Else");
            str.Append("\r\n");
            str.Append("Dim strPath");
            str.Append("\r\n");
            str.Append("strPath = tempLoc + \"\\" + strFileName + "\"");
            str.Append("\r\n");
            str.Append("Dim objApp");
            str.Append("\r\n");
            //// Create excel application object
            str.Append("set objApp = CreateObject(\"" + appstr + "\")");
            str.Append("\r\n");
            str.Append("if objApp = NULL or err.Number > 0 then");
            str.Append("\r\n");
            str.Append("msgBox(\"Unable to create ActiveX object!! Please change security settings in your browser to run the export!\"+chr(13)+chr(13)+\"Follow the steps below to change the security settings:\"+chr(13)+chr(9)+\"(1) Click Tools->Internet Options\" +chr(13)+chr(9)+\"(2) Click on Security tab and click Custom Level button \" +chr(13)+chr(9)+\"(3) Navigate to 'ActiveX Controls and Plugins' Settings\"+chr(13)+chr(9)+\"(4) Change 'Download unsigned ActiveX controls' setting to 'Prompt'\"+chr(13)+chr(9)+\"      Change 'Initialize and script ActiveX Controls not marked as safe as scripting' setting to 'Prompt'\"+chr(13)+chr(9)+\"(5) Click OK to save the settings and click YES when prompted with a warning dialog \")");
            str.Append("\r\n");
            str.Append("else");
            str.Append("\r\n");
            str.Append("Dim objBook");
            str.Append("\r\n");
            str.Append("objApp.DisplayAlerts =False");
            str.Append("\r\n");
            str.Append("objApp.Visible = True");
            str.Append("\r\n");
            str.Append("set objbook = objApp.workbooks.open(\"" + sFile + "\")");
            str.Append("\r\n");
            str.Append("objbook.saveas(strPath)");
            str.Append("\r\n");
            str.Append("if err.Number = 424 then");
            str.Append("\r\n");
            str.Append("msgBox(\"Export Failed: Could not open the template file !!\"+chr(13)+chr(13)+\" Possible Reason(s): Template file is missing \"+chr(13)+chr(9)+chr(9)+\"  User credentials is invalid!!\"+chr(13)+chr(9)+chr(9)+\"  Username/password not provided \" )");
            str.Append("\r\n");
            str.Append("objApp.quit");
            str.Append("\r\n");
            str.Append("else");
            str.Append("\r\n");
            str.Append("objbook.Sheets(\"RawEventData\").Cells(2, 7).Value = 1");
            //Use this value in excel work book in first save.
            str.Append("\r\n");
            str.Append("set objSheet = objbook.Sheets(\"BaselineData\")");
            str.Append("\r\n");
            str.Append("objSheet.Activate()");
            str.Append("\r\n");
            str.Append("objSheet.Range(objSheet.Cells(7,1),objSheet.Cells(65536,20)).value =\"\"");
            str.Append("\r\n");
            str.Append("objBook.save");
            str.Append("\r\n");
            str.Append("End If");
            str.Append("\r\n");
            str.Append("End If");
            str.Append("\r\n");
            str.Append("End If");
            str.Append("\r\n");
            str.Append("</script>");
            Page.RegisterStartupScript("clientscript", str.ToString());
        }

        //
      

    }
}