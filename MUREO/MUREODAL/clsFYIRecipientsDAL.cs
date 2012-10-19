using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsFYIRecipientsDAL
    {
        string m_strLastError;

        public bool GetRecipients(int iRecipientID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                
                paramIn[0] = new SqlParameter("@p_FYI_Recipient_ID", SqlDbType.Int);
                paramIn[0].Value = iRecipientID;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_FYI_Recipients", paramIn, ref objDS)))
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


        public bool GetRecipients(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                if (objDBPool.SPQueryDatasetNoParams("GET_EO_FYI_Recipients", ref objDS))
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

        public bool AddFYIRecipient(int iRegionID, int iCategoryID, int iSiteID, string strApproverNames, string strUserName, int iRecipientID, ref SqlParameter[] paramOut)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here               
                iRecipientID = 0;
                paramIn[0] = new SqlParameter("@p_Region_ID", SqlDbType.Int);
                paramIn[0].Value = iRegionID;
                paramIn[1] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[1].Value = iCategoryID;

                paramIn[2] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[2].Value = iSiteID;
                paramIn[3] = new SqlParameter("@p_Approver_Name", SqlDbType.VarChar);
                paramIn[3].Value = strApproverNames;
                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = strUserName;
                paramIn[5] = new SqlParameter("@p_FYI_Recipient_ID", SqlDbType.Int);
                paramIn[5].Value = iRecipientID;

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_FYI_Recipient", paramIn, ref paramOut, true)))
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
