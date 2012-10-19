using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsConcurrenceDA
    {
        string m_strLastError;

        public bool GetConcurrenceStatusTreeViewDA(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                if (objDBPool.SPQueryDatasetNoParams("GET_EO_Concurrence_Status_Tree_View", ref objDS))
                {
                    //Set the status to true here.
                    bReturn = true;
                }
                else
                {
                    //Get the last error from DBPool here.
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
                //Dispose the Objects
                objDBPool = null;
            }
            return bReturn;//Return the status here.
        }

        public bool GetConcurrenceStatusTreeViewDetailsDA(int intEOID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", intEOID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Concurrence_Status_Tree_View_Details", paramIn, ref objDS)))
                    //Set the status to true here.
                    bReturn = true;
                else
                    //Get the last error from DBPool here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            {
                paramIn = null;
                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }
    }
}
