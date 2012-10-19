using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class CoachingBoxBO
    {
        string m_strLastError;

        public bool GetCoachingBoxBO(int Coach_Box_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            CoachingBoxDA objCoachingBoxDA = null;
            DBPool objDBPool = null;
            try
            {
                objCoachingBoxDA = new CoachingBoxDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objCoachingBoxDA.GetCoachingBoxDA(Coach_Box_ID, ref objDS))
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
                objCoachingBoxDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool InsertCoachingBoxDA(int Coach_Box_Id, string MsgName, string Msg, string UserName, string Status, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            CoachingBoxDA objCoachingBoxDA = null;
            DBPool objDBPool = null;
            try
            {
                objCoachingBoxDA = new CoachingBoxDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objCoachingBoxDA.InsertCoachingBoxDA(Coach_Box_Id, MsgName, Msg, UserName, Status, ref paramOut))
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
                objCoachingBoxDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
