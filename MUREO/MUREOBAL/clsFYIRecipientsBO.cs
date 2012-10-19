using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsFYIRecipientsBO
    {
        string m_strLastError;

        public bool GetRecipients(int iRecipientID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsFYIRecipientsDAL objclsFYIRecipientsDAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsFYIRecipientsDAL = new clsFYIRecipientsDAL();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsFYIRecipientsDAL.GetRecipients(iRecipientID, ref objDS))
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
                objclsFYIRecipientsDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddFYIRecipient(int iRegionID, int iCategoryID, int iSiteID, string strApproverNames, string strUserName, int iRecipientID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsFYIRecipientsDAL objclsFYIRecipientsDAL = null;
            DBPool objDBPool = null;
            try
            {
                objclsFYIRecipientsDAL = new clsFYIRecipientsDAL();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsFYIRecipientsDAL.AddFYIRecipient(iRegionID, iCategoryID, iSiteID, strApproverNames, strUserName, iRecipientID, ref paramOut))
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
                objclsFYIRecipientsDAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetRecipients(ref DataSet objDS)
        {

            //Variable Declarations
            //This will be returned back.
            bool bReturn = false;
            clsFYIRecipientsDAL objclsFYIRecipientsDAL = null;
            DBPool objDBPool = null;
            //Init the data access layer object here

            try
            {
                //Initialize the data access layer object here
                objclsFYIRecipientsDAL = new clsFYIRecipientsDAL();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsFYIRecipientsDAL.GetRecipients(ref objDS))
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
                objclsFYIRecipientsDAL = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;//Return the status here
        }
    }
}
