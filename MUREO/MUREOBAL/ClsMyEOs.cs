using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class ClsMyEOs
    {
        string m_strLastError = string.Empty;
        //  ********--- GetCancelledEOs --- ****
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GetCancelledEOs()
        //Written BY	    :	Md.Abdul Allaam
        //parameters     :	parPlantID,parIntEOID, parStrStatus
        //Purpose	    :   To get the List of Approved EOs which can be in the stage of preliminary, final
        //Returns        :   To UI
        //Program Change History:
        //<Date>			         <Editor>	                <Rev>		<Description>
        //09/03/07                Md.Abdul allaam             1.0           created
        //***************************************************
        //public static DataSet GetCancelledEOs(char parStatus, string parUserName)
        //{
        //    System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[2];

        //    @params[0] = new System.Data.SqlClient.SqlParameter("@p_S_C_D_Status", SqlDbType.Char);
        //    @params[0].Value = parStatus;

        //    @params[1] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar, 100);
        //    @params[1].Value = parUserName;

        //    return DatabaseHelper.ExecuteDataSet("GET_EO_S_C_D_Status", @params);
        //}
        public bool GetApprovedSelectedEO(Int32 parPlantID, string parCurrentStage, string parStatus, string parUserName, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetApprovedSelectedEO(parPlantID, parCurrentStage, parStatus, parUserName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        //GetSelectedEOList
        //    Public Shared Function GetSelectedEOList(ByVal parPlantID As Integer, ByVal parOriginator As String, ByVal parUserName As String, ByVal parEOType As Char) As DataSet
        //    Dim params(3) As SqlClient.SqlParameter

        //    params(0) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //    params(0).Value = parPlantID

        //    params(1) = New SqlClient.SqlParameter("@p_Originator", SqlDbType.VarChar, 100)
        //    params(1).Value = parOriginator

        //    params(2) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar, 100)
        //    params(2).Value = parUserName

        //    params(3) = New SqlClient.SqlParameter("@p_EO_Mode", SqlDbType.Char)
        //    params(3).Value = parEOType

        //    Return DatabaseHelper.ExecuteDataSet("GET_EO_ALL_EOs_Details", params)
        //End Function
        public bool GetSelectedEOList(Int32 parPlantID, string parOriginator, string parUserName, char parEOType, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetSelectedEOList(parPlantID, parOriginator, parUserName, parEOType, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetAllEOs(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetAllEOs(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetAllEOsForOriginator(string parValue, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetAllEOsForOriginator(parValue, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetApprovedEO(string parCurrentStage, string parStatus, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetApprovedEO(parCurrentStage, parStatus, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetMyEOs(string strLoginUserName, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetMyEOs(strLoginUserName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool ShowApprovals(Int32 parIntEOID, string parStrStatus, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.ShowApprovals(parIntEOID, parStrStatus, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetCancelledEOs(char parStatus, string parUserName, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetCancelledEOs(parStatus,parUserName,ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool DeleteEO(int intEOID, string strUserName, ref SqlParameter[] paramOut)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.DeleteEO(intEOID, strUserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool DeleteStopCancelEO(int intEOID, char strStatus, string strUserName, ref SqlParameter[] paramOut)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.DeleteStopCancelEO(intEOID, strStatus, strUserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool SetEOActive(int parEOID, string parUserName, ref SqlParameter[] paramOut)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.SetEOActive(parEOID, parUserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
            public bool GetApprovalsConcurrences(Int32 parPlantID, string parCurrentStage, string parStatus, string parUserName, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            clsMyEODA objclsEvent = null;
            try
            {
                objclsEvent = new clsMyEODA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetApprovalsConcurrences(parPlantID, parCurrentStage, parStatus, parUserName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }

        #region "Murali"

            public bool GetAwaitingCloseOutSelectedEO(string strOriginator, ref DataSet objDS)
            {

                //This will be returned back.
                DBPool objDBPool = null;
                bool bReturn = false;
                //Init the data access layer object here
                clsMyEODA objclsEvent = null;
                try
                {
                    objclsEvent = new clsMyEODA();
                    objDBPool = new DBPool();
                    //Call the data access function here
                    if (objclsEvent.GetAwaitingCloseOutSelectedEO(strOriginator, ref objDS))
                        bReturn = true;
                    else
                        //Get the last error from DA class here.
                        m_strLastError = objDBPool.GetLastError();
                }
                catch (Exception ex)
                {
                    //Set the error to this variable
                    m_strLastError = ex.StackTrace;
                }
                finally
                { //Free objects here
                    objclsEvent = null;
                }
                //Return the status here
                return bReturn;

            }

            public bool GetArchivedSelectedEO(int intPlantID, string strCurrentStage, string strEOType, string strUserName, ref DataSet objDS)
            {

                //This will be returned back.
                DBPool objDBPool = null;
                bool bReturn = false;
                //Init the data access layer object here
                clsMyEODA objclsEvent = null;
                try
                {
                    objclsEvent = new clsMyEODA();
                    objDBPool = new DBPool();
                    //Call the data access function here
                    if (objclsEvent.GetArchivedSelectedEO(intPlantID, strCurrentStage, strEOType, strUserName, ref objDS))
                        bReturn = true;
                    else
                        //Get the last error from DA class here.
                        m_strLastError = objDBPool.GetLastError();
                }
                catch (Exception ex)
                {
                    //Set the error to this variable
                    m_strLastError = ex.StackTrace;
                }
                finally
                { //Free objects here
                    objclsEvent = null;
                }
                //Return the status here
                return bReturn;

            }


            public bool GetArchivedEOs(ref DataSet objDS)
            {

                //This will be returned back.
                DBPool objDBPool = null;
                bool bReturn = false;
                //Init the data access layer object here
                clsMyEODA objclsEvent = null;
                try
                {
                    objclsEvent = new clsMyEODA();
                    objDBPool = new DBPool();
                    //Call the data access function here
                    if (objclsEvent.GetArchivedEOs(ref objDS))
                        bReturn = true;
                    else
                        //Get the last error from DA class here.
                        m_strLastError = objDBPool.GetLastError();
                }
                catch (Exception ex)
                {
                    //Set the error to this variable
                    m_strLastError = ex.StackTrace;
                }
                finally
                { //Free objects here
                    objclsEvent = null;
                }
                //Return the status here
                return bReturn;

            }

        #endregion


    }
}
