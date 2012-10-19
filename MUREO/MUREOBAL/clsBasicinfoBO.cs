using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsBasicinfoBO
    {
        string m_strLastError;


        public bool FillBasicInfo(ref DataSet objDS)
        {

            //Variable Declarations
            //This will be returned back.
            bool bReturn = false;
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            //Init the data access layer object here

            try
            {
                //Initialize the data access layer object here
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.FillBasicInfo(ref objDS))
                {
                    //Set the status to true here.
                    bReturn = true;
                }
                else
                {
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
                }
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            {
                //Dispose objects here
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;//Return the status here
        }

        public bool UpdateInsertCategory(int intCatID, string strCatName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.UpdateInsertCategory(intCatID, strCatName, strStatus, strUserName, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool UpdateInsertPlant(int intPlantID, string strPlantName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.UpdateInsertPlant(intPlantID, strPlantName, strStatus, strUserName, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool UpdateInsertEO(int intEOID, string strEOName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.UpdateInsertEO(intEOID, strEOName, strStatus, strUserName, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool UpdateInsertProjectType(int intProjID, string strProjName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.UpdateInsertProjectType(intProjID, strProjName, strStatus, strUserName, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool UpdateInsertMachine(int intMachID, int intMachTypeID, int intPlantID, int intCatID, string strMachName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.UpdateInsertMachine(intMachID, intMachTypeID, intPlantID, intCatID, strMachName, strStatus,strUserName, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool UpdateInsertFunction(int intFunID, string strFunName, string strUserName, string strStatus, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.UpdateInsertFunction(intFunID, strFunName, strUserName, strStatus, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        //BasicInfoDeleteCheck

        public bool BasicInfoDeleteCheck(string strFunctionName, int intKeyID, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.BasicInfoDeleteCheck(strFunctionName, intKeyID, strUserName,  ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool BasicInfoDelete(string strFunctionName, int intKeyID, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBasicinfoDA objclsBasicinfoDADAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsBasicinfoDADAL = new clsBasicinfoDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBasicinfoDADAL.BasicInfoDelete(strFunctionName, intKeyID, strUserName, ref paramOut))
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
                objclsBasicinfoDADAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
