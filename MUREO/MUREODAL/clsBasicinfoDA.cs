using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsBasicinfoDA
    {
        string m_strLastError;

        public bool FillBasicInfo(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                if (objDBPool.SPQueryDatasetNoParams("GET_MUR_Basic_Information", ref objDS))
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


        public bool UpdateInsertCategory(int intCatID, string strCatName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[0].Value = intCatID;

                paramIn[1] = new SqlParameter("@p_Category_Name", SqlDbType.VarChar);
                paramIn[1].Value = strCatName;

                paramIn[2] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[2].Value = strStatus;

                paramIn[3] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[3].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Category", paramIn, ref paramOut,true)))
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

        public bool UpdateInsertPlant(int intPlantID, string strPlantName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[0].Value = intPlantID;

                paramIn[1] = new SqlParameter("@p_Plant_Name", SqlDbType.VarChar);
                paramIn[1].Value = strPlantName;

                paramIn[2] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[2].Value = strStatus;

                paramIn[3] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[3].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Plant", paramIn, ref paramOut, true)))
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

        public bool UpdateInsertEO(int intEOID, string strEOName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_EO_Type_ID", SqlDbType.Int);
                paramIn[0].Value = intEOID;

                paramIn[1] = new SqlParameter("@p_EO_Type_Name", SqlDbType.VarChar);
                paramIn[1].Value = strEOName;

                paramIn[2] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[2].Value = strStatus;

                paramIn[3] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[3].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Type", paramIn, ref paramOut, true)))
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

        public bool UpdateInsertProjectType(int intProjID, string strProjName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Project_Type_ID", SqlDbType.Int);
                paramIn[0].Value = intProjID;

                paramIn[1] = new SqlParameter("@p_Project_Type_Name", SqlDbType.VarChar);
                paramIn[1].Value = strProjName;

                paramIn[2] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[2].Value = strStatus;

                paramIn[3] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[3].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Project_Type", paramIn, ref paramOut, true)))
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

        public bool UpdateInsertMachine(int intMachID, int intMachTypeID, int intPlantID, int intCatID, string strMachName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                intMachTypeID = 1;

                paramIn[0] = new SqlParameter("@p_Machine_ID", SqlDbType.Int);
                paramIn[0].Value = intMachID;

                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[1].Value = intMachTypeID;

                paramIn[2] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[2].Value = DBNull.Value;

                paramIn[3] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[3].Value = DBNull.Value;

                paramIn[4] = new SqlParameter("@p_Machine_Name", SqlDbType.VarChar);
                paramIn[4].Value = strMachName;

                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[5].Value = strStatus;

                paramIn[6] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[6].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Machine", paramIn, ref paramOut, true)))
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

        public bool UpdateInsertFunction(int intFunID, string strFunName, string strUserName, string strStatus, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Function_ID", SqlDbType.Int);
                paramIn[0].Value = intFunID;

                paramIn[1] = new SqlParameter("@p_Function_Name", SqlDbType.VarChar);
                paramIn[1].Value = strFunName;

                paramIn[2] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[2].Value = strUserName;

                paramIn[3] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[3].Value = strStatus;
                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Functions", paramIn, ref paramOut, true)))
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


        public bool BasicInfoDeleteCheck(string strFunName, int intKeyID, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@From_Table", SqlDbType.VarChar);
                paramIn[0].Value = strFunName;

                paramIn[1] = new SqlParameter("@Key_ID", SqlDbType.Int);
                paramIn[1].Value = intKeyID;

                paramIn[2] = new SqlParameter("@Check", SqlDbType.Char);
                paramIn[2].Value = Convert.ToChar("Y");

                paramIn[3] = new SqlParameter("@User_Name", SqlDbType.VarChar);
                paramIn[3].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("Check_And_Delete", paramIn, ref paramOut, true)))
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

        public bool BasicInfoDelete(string strFunName, int intKeyID, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@From_Table", SqlDbType.VarChar);
                paramIn[0].Value = strFunName;

                paramIn[1] = new SqlParameter("@Key_ID", SqlDbType.Int);
                paramIn[1].Value = intKeyID;

                paramIn[2] = new SqlParameter("@Check", SqlDbType.Char);
                paramIn[2].Value = Convert.ToChar("N");

                paramIn[3] = new SqlParameter("@User_Name", SqlDbType.VarChar);
                paramIn[3].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("Check_And_Delete", paramIn, ref paramOut, true)))
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
