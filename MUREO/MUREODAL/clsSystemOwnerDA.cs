using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class clsSystemOwnerDA
    {
        string m_strLastError;

        public bool FillSystemOwner(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                if (objDBPool.SPQueryDatasetNoParams("GET_EO_System_Owner", ref objDS))
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

       /* public bool AddEoSystemOwner(int PlantID, string SystemOwnerName, string PhoneNumber,string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Sys_Owner_ID", SqlDbType.Int);
                paramIn[0].Value = 0;

                paramIn[1] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[1].Value = PlantID;

                paramIn[2] = new SqlParameter("@p_System_Owner_Name", SqlDbType.VarChar);
                paramIn[2].Value = SystemOwnerName;

                paramIn[3] = new SqlParameter("@p_Phone_Number", SqlDbType.VarChar);
                paramIn[3].Value = PhoneNumber;

                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = DBNull.Value;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[5].Value = DBNull.Value;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_System_Owner", paramIn, ref paramOut, true)))
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
        }*/

        public bool InsUpdateEoSystemOwner(int PlantID, string SystemOwnerName, string PhoneNumber, int SysOwnID, string strUserName,string strStatus, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                
                paramIn[0] = new SqlParameter("@p_Sys_Owner_ID", SqlDbType.Int);
                paramIn[0].Value = SysOwnID;

                paramIn[1] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[1].Value = PlantID;

                paramIn[2] = new SqlParameter("@p_System_Owner_Name", SqlDbType.VarChar);
                paramIn[2].Value = SystemOwnerName;

                paramIn[3] = new SqlParameter("@p_Phone_Number", SqlDbType.VarChar);
                paramIn[3].Value = PhoneNumber;

                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = DBNull.Value;
                
                
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                //paramIn[5].Value = Convert.ToChar(strStatus);

                if (Convert.ToString(strStatus)=="")
                {
                    paramIn[5].Value = System.DBNull.Value;
                }
                else
                {
                    paramIn[5].Value = Convert.ToChar(strStatus);
                }

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_System_Owner", paramIn, ref paramOut, true)))
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

        public bool DeleteSysOwner(int SysOwnID,ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Sys_Owner_ID", SqlDbType.Int);
                paramIn[0].Value = SysOwnID;

                paramIn[1] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[1].Value = 1;

                paramIn[2] = new SqlParameter("@p_System_Owner_Name", SqlDbType.VarChar);
                paramIn[2].Value = DBNull.Value; ;

                paramIn[3] = new SqlParameter("@p_Phone_Number", SqlDbType.VarChar);
                paramIn[3].Value = DBNull.Value; ;

                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = DBNull.Value;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[5].Value = "I";

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_System_Owner", paramIn, ref paramOut, true)))
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
