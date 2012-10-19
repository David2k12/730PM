using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;
using MUREOPROP;
namespace MUREOBAL
{
    public class ClsSearch
    {
          private static string connectionString;
          string m_strLastError;
        static ClsSearch() {
       //     connectionString = ConfigurationSettings.AppSettings("connectionstring");
        }
        
        //   ************************************************
        // Developed by   :    Vertex Computer Systems, Inc.,
        // Name           :    FillSearchDataGrid
        // Written BY        :    Md.Abdul Allaam
        // parameters     :    SP Name,Parameter Value
        // Purpose        :   Executes the SP and returns a Dataset for Search projects.Specifically used
        //                    for filling datagrid for the input search given.
        // Returns        :   to GUI
        // ***************************************************
        public bool FillSearchDataGrid(string sqlText, string parSearchFor, string parProjName, string parEventName, string parProjLead, string parPlantName, string parEONumber, string parProjectDate, string parOrderBy, int parCount, string parSearchType, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillSearchDataGrid(sqlText, parSearchFor, parProjName, parEventName, parProjLead,parPlantName,parEONumber, parProjectDate, parOrderBy, parCount, parSearchType,ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }
        
        //   ************************************************
        // Developed by   :    Vertex Computer Systems, Inc.,
        // Name           :    FillFuzzyDataGrid
        // Written BY        :    Md.Abdul Allaam
        // parameters     :    SP Name,Parameter Value
        // Purpose        :   Executes the SP and returns a Dataset for Fuzzy Search .Specifically used
        //                    for filling datagrid for the input search given.
        // Returns        :   to GUI
        // <Date>                     <Editor>              <Rev>        <Description>
        // 09/19/07                 Abdul             1.0         Initial version
        // ***************************************************
        public bool FillFuzzyDataGrid(string parSearchString, string parSortBy, int parLimit, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillFuzzyDataGrid(parSearchString, parSortBy, parLimit, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }
    }
}
