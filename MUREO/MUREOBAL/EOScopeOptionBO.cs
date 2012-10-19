using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data.SqlClient;
using System.Data;

namespace MUREOBAL
{
    public class EOScopeOptionBO
    {
        string m_strLastError = string.Empty;
        public bool GetSeedDataforBudget(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            EOScopeOptionDA objclsEvent = null;
            try
            {
                objclsEvent = new EOScopeOptionDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetSeedDataforBudget(ref objDS))
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
        public bool GetBudgetByEOScope(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            EOScopeOptionDA objclsEvent = null;
            try
            {
                objclsEvent = new EOScopeOptionDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetBudgetByEOScope(ref objDS))
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
        public bool FillWithSuggestedBudgetcenter(Int32 parValue, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            EOScopeOptionDA objclsEvent = null;
            try
            {
                objclsEvent = new EOScopeOptionDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillWithSuggestedBudgetcenter(parValue, ref objDS))
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

        public bool GetEOScopeOptionDetailsBO(Int32 Scope_ID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            EOScopeOptionDA objclsEvent = null;
            try
            {
                objclsEvent = new EOScopeOptionDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetEOScopeOptionDetailsDA(Scope_ID, ref objDS))
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

        public bool SetSuggestedBudgetCenter(int scopeMapID, Int32 strScopeID, int strPlantID, int strBudgetID, string strUserName, ref SqlParameter[] resout)
        {            
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            EOScopeOptionDA objclsEvent = null;
            try
            {
                objclsEvent = new EOScopeOptionDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.SetSuggestedBudgetCenter(scopeMapID, strScopeID, strPlantID, strBudgetID, strUserName,ref resout))
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
        public bool InsertEOScopeOptionBO(int Scope_ID, string Scope_Name, int Budget_Center_Id, string Bounty_Approver_Name, string Charmin_Approver_Name, string Puffs_Approver_Name, string Default_Approver_Name, string SAP_CCC_Apporver_Name, string UserName, char Status, ref SqlParameter[] resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            EOScopeOptionDA objclsEvent = null;
            try
            {
                objclsEvent = new EOScopeOptionDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.InsertEOScopeOptionDA(Scope_ID, Scope_Name, Budget_Center_Id, Bounty_Approver_Name, Charmin_Approver_Name, Puffs_Approver_Name, Default_Approver_Name, SAP_CCC_Apporver_Name, UserName, Status, ref resout))
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
