using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsApproverDAL
    {
        string m_strLastError;
        bool bReturn = false;
        public bool FillEOApprovalGroupDetailsDAL(int ApprovalGrpID, ref DataSet ds, string SPName)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter("@p_approval_Group_ID", ApprovalGrpID);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(SPName, paramIn, ref ds)))
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

                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }
    }
}
