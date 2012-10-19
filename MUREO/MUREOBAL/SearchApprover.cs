using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class SearchApprover
    {
        string m_strLastError;
        bool bReturn = false;
        public bool FillApprovers(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            SearchApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new SearchApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetApprovers(ref objDS))
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
        public bool FillFunctions(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            SearchApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new SearchApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetFunction(ref objDS))
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
        public bool GetApprGrpName(string ApprName, int FuncID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            SearchApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new SearchApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetApprGrpName(ApprName,FuncID,ref objDS))
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
        public bool SetSearchApproverName(string oldApprName, int FuncID, string GrpIDList, string NewApprName, ref SqlParameter[] paramOut)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            SearchApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new SearchApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.SetSearchApproverName(oldApprName,FuncID,GrpIDList,NewApprName, ref paramOut))
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
    }
}
