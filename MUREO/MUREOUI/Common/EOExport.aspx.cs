using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Configuration;

namespace MUREOUI.Common
{
    public partial class EOExport : System.Web.UI.Page
    {

    //        Declare Function EndTask Lib "user32.dll" (ByVal hWnd As IntPtr) As Integer
    //Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" _
    //       (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    //Declare Function GetWindowThreadProcessId Lib "user32.dll" _
    //       (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    //Declare Function SetLastError Lib "kernel32.dll" (ByVal dwErrCode As Integer) As IntPtr


        static DataSet dsEO;
        clsEvent objclsEvent = new clsEvent();
        
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                FillEODetails();
            }
        }

        private void FillEODetails()
        {
            //dsEO = DataExportBO.GetEODetailsBO();
            if (objclsEvent.GetEventDetailsBO(ref dsEO))
            {
                if (dsEO == null)
                {
                    NoRecords();
                }
                else if (dsEO.Tables.Count == 0)
                {
                    NoRecords();
                }
                else if (dsEO.Tables[0].Rows.Count == 0)
                {
                    NoRecords();
                }
            }
        }

        private void CreateExcel(DataTable EOtable)
        {
            if (EOtable == null)
            {
                NoRecords();
                return;
            }
            string sFile = null;
            string ColCount = null;
            DataRow dr = null;
            int intColLoop = 0;
            int rowCount = 0;
            object[,] args = null;
            string endCount = null;

            int rowIndex = 7;
            //Make sure cell row index is after the template header
            int colIndex = 0;
            //Set cell column index = 0 

            //sFile = "http://" & Request.Url.Host() & "/MUREO/MURDATA/GetEODataTemplateRev1.xls" 'Set the server path of the residing template file
            sFile = "http://bdc-intra528.internal.pg.com/MUREO/MURDATA/GetEODataTemplateRev1.xls";
            //Set the server path of the residing template file
            //<script language=javascript>window.opener='x';window.close();</script>

            string appstr = "Excel.Application";
            string str = "<SCRIPT language=VBScript>";

            str += "\r\n";
            // By damodar on 04-08-05
            str += "On Error Resume Next ";
            // by damodar 
            str += "\r\n";
            // Set up constants
            str += "Const ForReading = 1";
            str += "\r\n";
            str += "Const Create = False";
            str += "\r\n";
            // Declare local variables
            str += "Dim objFSO";
            // FileSystemObject
            str += "\r\n";
            str += "Dim TS";
            // TextStreamObject
            str += "\r\n";
            str += "Dim strLine";
            // local variable to store Line
            str += "\r\n";
            str += "Dim strFileName";
            // local variable to store fileName
            str += "\r\n";
            // Instantiate the FileSystemObject
            str += "set objFSO = CreateObject(\"Scripting.FileSystemObject\")";
            str += "\r\n";


            str += "Dim tempLoc";
            str += "\r\n";
            str += "set tempLoc = objFSO.getSpecialFolder(2)";
            str += "\r\n";

            str += "Dim strPath";
            str += "\r\n";

            str += "strPath = tempLoc + \"\\GetEODataTemplateRev1.xls\"";
            str += "\r\n";

            str += "Dim objApp";
            str += "\r\n";

            //// Create excel application object
            str += "set objApp = CreateObject(\"" + appstr + "\")";
            str += "\r\n";
            // Make it visible 
            // Add a new workbook

            str += "if objApp = NULL or err.Number > 0 then";
            str += "\r\n";

            str += "msgBox(\"Unable to create ActiveX object!! Please change security settings in your browser to run the export!\"+chr(13)+chr(13)+\"Follow the steps below to change the security settings:\"+chr(13)+chr(9)+\"(1) Click Tools->Internet Options\" +chr(13)+chr(9)+\"(2) Click on Security tab and click Custom Level button \" +chr(13)+chr(9)+\"(3) Navigate to 'ActiveX Controls and Plugins' Settings\"+chr(13)+chr(9)+\"(4) Change 'Download unsigned ActiveX controls' setting to 'Prompt'\"+chr(13)+chr(9)+\"      Change 'Initialize and script ActiveX Controls not marked as safe as scripting' setting to 'Prompt'\"+chr(13)+chr(9)+\"(5) Click OK to save the settings and click YES when prompted with a warning dialog \")";
            str += "\r\n";

            str += "else";
            str += "\r\n";


            str += "Dim objBook";
            str += "\r\n";

            str += "objApp.DisplayAlerts =False";
            str += "\r\n";

            //// Open the workbook (.xls) file
            str += "objApp.Visible = True";
            str += "\r\n";

            str += "set objbook = objApp.workbooks.open(\"" + sFile + "\") ";
            str += "\r\n";

            //str += "set objbook = objApp.workbooks.open(strPath)"
            //str += vbCrLf

            str += "objbook.saveas(strPath)";
            str += "\r\n";

            str += "if err.Number = 424 then";
            str += "\r\n";

            str += "msgBox(\"Export Failed: Could not open the template file !!\"+chr(13)+chr(13)+\" Possible Reason(s): Template file is missing \"+chr(13)+chr(9)+chr(9)+\"  User credentials is invalid!!\"+chr(13)+chr(9)+chr(9)+\"  Username/password not provided \" )";
            str += "\r\n";

            str += "objApp.quit";
            str += "\r\n";

            str += "else";
            str += "\r\n";

            str += "set Sheet1=objbook.worksheets(\"Sheet1\")";
            str += "\r\n";

            str += "Sheet1.activate()";
            str += "\r\n";

            str += "dim colIndex";
            str += "\r\n";

            str += "colIndex=0";
            str += "\r\n";

            str += "dim rowIndex";
            str += "\r\n";

            str += "rowIndex=7";
            str += "\r\n";

            str += "Dim args(" + EOtable.Rows.Count + "," + EOtable.Columns.Count + ")";
            str += "\r\n";
            ColCount = EOtable.Columns.Count.ToString();

            args = new object[EOtable.Rows.Count + 1, EOtable.Columns.Count + 1];

            foreach (DataRow dr_loopVariable in EOtable.Rows)
            {
                dr = dr_loopVariable;
                for (intColLoop = 0; intColLoop <= (Convert.ToInt32(ColCount) - 1); intColLoop++)
                {
                    str += "args(" + rowCount + "," + intColLoop + ") = \"" + dr[intColLoop].ToString() + "\"";
                    str += "\r\n";
                }
                rowCount = rowCount + 1;
            }

            endCount = "P" + EOtable.Rows.Count + 7;
            str += "Sheet1.Range(\"A7:" + endCount + "\").Value = args";
            str += "\r\n";

            str += "BaseSheet.Range(\"A7:A7\").Select";
            str += "\r\n";

            str += "objBook.save";
            str += "\r\n";

            str += "msgBox(\"Data Export Completed Successfully!!\")";
            str += "\r\n";

            str += "end if";
            str += "\r\n";
            str += "end if";
            str += "\r\n";

            str += "</script>";
            Page.RegisterStartupScript("clientscript", str);


        }

        //public void EnsureProcessKilled(IntPtr MainWindowHandle, string Caption)
        //{
        //    SetLastError(0);
        //    // for Excel versions <10, this won't be set yet
        //    if (IntPtr.Equals(MainWindowHandle, IntPtr.Zero))
        //        MainWindowHandle = FindWindow(null, Caption);
        //    if (IntPtr.Equals(MainWindowHandle, IntPtr.Zero))
        //        return;
        //    // at this point, presume the window has been closed.
        //    int iRes = 0;
        //    int iProcID = 0;
        //    iRes = GetWindowThreadProcessId(MainWindowHandle, ref iProcID);
        //    // can’t get Process ID
        //    if (iProcID == 0)
        //    {
        //        if (EndTask(MainWindowHandle) != 0)
        //            return;
        //        // success
        //        throw new ApplicationException("Failed to close.");
        //    }
        //    System.Diagnostics.Process proc = null;
        //    proc = System.Diagnostics.Process.GetProcessById(iProcID);
        //    proc.CloseMainWindow();
        //    proc.Refresh();
        //    if (proc.HasExited)
        //        return;
        //    proc.Kill();
        //}

        //private object FillExcelSheet(ref DataTable table, ref Excel.Range xlCells)
        //{
        //    object functionReturnValue = null;
        //    DataRow dr = null;
        //    int intColLoop = 0;
        //    int rowCount = 0;
        //    int colCount = 0;
        //    object[,] args = null;
        //    string endCount = null;

        //    if (table == null)
        //    {
        //        return functionReturnValue;
        //    }

        //    int rowIndex = 7;
        //    //Make sure cell row index is after the template header
        //    int colIndex = 0;
        //    //Set cell column index = 0 

        //    colCount = table.Columns.Count;
        //    args = new object[table.Rows.Count + 1, table.Columns.Count + 1];

        //    foreach (DataRow dr_loopVariable in table.Rows)
        //    {
        //        dr = dr_loopVariable;
        //        for (intColLoop = 0; intColLoop <= colCount - 1; intColLoop++)
        //        {
        //            args[rowCount, intColLoop] = dr[intColLoop].ToString();
        //        }
        //        rowCount = rowCount + 1;
        //    }
        //    endCount = "P" + table.Rows.Count + 7;
        //    xlCells.Range("A7:" + endCount).Value = args;
        //    return functionReturnValue;

        //}

        private void NoRecords()
        {
            string script = null;
            script = "<script>alert('" + ConfigurationSettings.AppSettings["NoRecords"] + "');</script> ";
            Page.RegisterStartupScript("error_message", script);
        }

        private void ImgExport_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (dsEO.Tables.Count != 0)
            {
                CreateExcel(dsEO.Tables[0]);
            }
        }

    }
}