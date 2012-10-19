using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class ConcurrenceGroup
    {
        string m_strLastError = string.Empty;

        public bool UpdateEoConcurrenceGroup(Int32 ConGrpID, Int32 PlantID, string ConGrpName, string NameforGrp, ref SqlParameter[] resout)
        {
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ConcurrenceGroupDA objclsEvent = null;
            try
            {
                objclsEvent = new ConcurrenceGroupDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.UpdateEoConcurrenceGroup(ConGrpID,PlantID, ConGrpName, NameforGrp, ref resout))
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

        public bool AddEoConcurrenceGroup(Int32 PlantID, string ConGrpName, string NameforGrp, ref SqlParameter[] resout)
        {
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ConcurrenceGroupDA objclsEvent = null;
            try
            {
                objclsEvent = new ConcurrenceGroupDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.AddEoConcurrenceGroup(PlantID, ConGrpName, NameforGrp, ref resout))
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
        public bool DeleteConcurrenceGroup(int ConcurrenceGroupID, ref SqlParameter[] resout)
        {
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ConcurrenceGroupDA objclsEvent = null;
            try
            {
                objclsEvent = new ConcurrenceGroupDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.DeleteConcurrenceGroup(ConcurrenceGroupID, ref resout))
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
        public bool FillConcurrenceGroup(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ConcurrenceGroupDA objclsEvent = null;
            try
            {
                objclsEvent = new ConcurrenceGroupDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillConcurrenceGroup(ref objDS))
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
