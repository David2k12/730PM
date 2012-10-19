using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsPrescreenersBO
    {
        string m_strLastError;

        public bool GetPreScreenerData(int iPrescreenerGroupID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPrescreenersDA objclsPrescreenersDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPrescreenersDA = new clsPrescreenersDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPrescreenersDA.GetPreScreenerData(iPrescreenerGroupID, ref objDS))
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
                objDBPool = null;
                objclsPrescreenersDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddUpdatePreScreenerGroup(string strGroupName, string strPriAppName, string strBackupAppName, string strUserName, int iPrescreenerGroupID, string cStatus, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPrescreenersDA objclsPrescreenersDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPrescreenersDA = new clsPrescreenersDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPrescreenersDA.AddUpdatePreScreenerGroup(strGroupName, strPriAppName, strBackupAppName, strUserName, iPrescreenerGroupID, cStatus, ref paramOut))
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
                objclsPrescreenersDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
