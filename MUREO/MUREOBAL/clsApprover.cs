using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsApprover
    {
        clsApproverDAL objclsApproverDAL = new clsApproverDAL();
        string m_strLastError;
        Boolean bReturn = false;
        public bool FillEOApprovalGroupDetails(int ApprovalGrpID, ref DataSet objds, string SPName)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objclsApproverDAL.FillEOApprovalGroupDetailsDAL(ApprovalGrpID, ref objds, SPName))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
