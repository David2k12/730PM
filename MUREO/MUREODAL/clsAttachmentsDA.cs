using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class clsAttachmentsDA
    {
        string m_strLastError;

        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;
        }

        public bool DeleteCommonAttachments(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", EoID);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_IDs", attchIDs);
                paramIn[3] = new SqlParameter("@p_Attachment_File_Name", DBNull.Value);
                paramIn[4] = new SqlParameter("@p_Attachment_Type", DBNull.Value);
                paramIn[5] = new SqlParameter("@p_Attachment",SqlDbType.Image);
                paramIn[5].Value = DBNull.Value;


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_ST_Attachment", paramIn, ref paramOut, true)))
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

        public bool SubmitCommonAttachments(string fName, byte[] fContent, string sConType, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", EoID);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_IDs", DBNull.Value);
                if (fName != "")
                {
                    paramIn[3] = new SqlParameter("@p_Attachment_File_Name", fName);
                    paramIn[4] = new SqlParameter("@p_Attachment_Type", sConType);
                }
                if (fContent.Length != 0)
                    paramIn[5] = new SqlParameter("@p_Attachment", fContent);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_ST_Attachment", paramIn, ref paramOut, true)))
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

        public bool GetAttachmentsInfo(int intAttachmentID, int EoId, string sectionName,ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EoId);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_ID", intAttachmentID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_ST_Attachment", paramIn, ref objDS)))
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
