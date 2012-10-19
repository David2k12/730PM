using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data.SqlClient;
using MUREOPROP;
using System.Data;

namespace MUREOBAL
{
    public class clsAttachmentsBA
    {
        string m_strLastError;

        public bool DeleteCommonAttachments(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsAttachmentsDA objclsAttachmentsDA = new clsAttachmentsDA();
            try
            {
                //Call the data access function here
                if (objclsAttachmentsDA.DeleteCommonAttachments(attchIDs, EoID, sectionName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objclsAttachmentsDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsAttachmentsDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SubmitCommonAttachments(string fName, byte[] fContent, string sConType, int EoID,string sectionName,ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsAttachmentsDA objclsAttachmentsDA = new clsAttachmentsDA();
            try
            {
                //Call the data access function here
                if (objclsAttachmentsDA.SubmitCommonAttachments(fName,  fContent,  sConType,  EoID, sectionName,ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objclsAttachmentsDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsAttachmentsDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetAttachmentsInfo(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsAttachmentsDA objclsAttachmentsDA = new clsAttachmentsDA();
            try
            {
                //Call the data access function here
                if (objclsAttachmentsDA.GetAttachmentsInfo(intAttachmentID, EoId, sectionName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objclsAttachmentsDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsAttachmentsDA = null;
            }
            //Return the status here
            return bReturn;
        }
    }
}
