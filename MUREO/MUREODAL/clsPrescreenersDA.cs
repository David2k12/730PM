using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class clsPrescreenersDA
    {
        string m_strLastError;

        public bool GetPreScreenerData(int iPrescreenerGroupID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_PreScreener_Group_ID", iPrescreenerGroupID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_PreScreener_Group", paramIn, ref objDS)))
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

        public bool AddUpdatePreScreenerGroup(string strGroupName, string strPriAppName, string strBackupAppName, string strUserName, int iPrescreenerGroupID, string cStatus, ref SqlParameter[] paramOut)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here               

                paramIn[0] = new SqlParameter("@p_PreScreener_Group_ID", SqlDbType.Int);
                paramIn[0].Value = iPrescreenerGroupID;
                paramIn[1] = new SqlParameter("@p_PreScreener_Group_Name", SqlDbType.VarChar);
                paramIn[1].Value = strGroupName;

                paramIn[2] = new SqlParameter("@p_Primary_Approver_Name", SqlDbType.VarChar);
                paramIn[2].Value = strPriAppName;
                paramIn[3] = new SqlParameter("@p_Backup_Approver_Name", SqlDbType.VarChar);
                paramIn[3].Value = strBackupAppName;
                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = strUserName;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[5].Value = Convert.ToChar(cStatus);

               
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_PreScreener_Group", paramIn, ref paramOut, true)))
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
