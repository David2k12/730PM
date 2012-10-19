using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class SendConcurrenceDAL
    {
        string m_strLastError = string.Empty;
        public bool FillConGrpNames(int PlantID, int ConGrpID, ref DataSet ConGrp)
        {
            try
            {              

                //Variable Declarations
                bool bReturn = false;
                SqlParameter[] paramIn = new SqlParameter[2];
                DBPool objDBPool = null;
                try
                {
                    //Set procedure params here
                    paramIn[0] = new SqlParameter("@p_Concurrence_Group_ID", ConGrpID);
                    paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);                    

                    //Instantiate DBPool Object here
                    objDBPool = new DBPool();
                    //Calling the SPQueryDataset which is in the DBPOOL.
                    if ((objDBPool.SPQueryDataset("GET_EO_Concurrence_Group", paramIn, ref ConGrp)))
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
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public bool AddBackUpApprover(int conAppID, string BUapproverName)
        {
            try
            {
                //System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[2];
                //DataSet ConGrp = null;
                //sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_EO_Con_App_ID", SqlDbType.Int);
                //sqlparams[0].Value = conAppID;
                //sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_Backup_Approver_Name", SqlDbType.VarChar);
                //sqlparams[1].Value = BUapproverName;
                //DatabaseHelper.ExecuteNonQuery("[dbo].SET_Concurrence_Backup_Approver", sqlparams);

                //Variable Declarations
                bool bReturn = false;
                SqlParameter[] paramIn = new SqlParameter[2];
                DBPool objDBPool = null;
                try
                {
                    //Set procedure params here
                    paramIn[0] = new SqlParameter("@p_EO_Con_App_ID", conAppID);
                    paramIn[1] = new SqlParameter("@p_Backup_Approver_Name", BUapproverName);

                    //Instantiate DBPool Object here
                    objDBPool = new DBPool();
                    //Calling the SPQueryDataset which is in the DBPOOL.
                    if ((objDBPool.SPQueryExecuteNonQuery("GET_EO_Concurrence_Group", paramIn)))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
