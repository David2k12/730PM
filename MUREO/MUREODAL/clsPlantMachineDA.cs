using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsPlantMachineDA
    {
        string m_strLastError;

        public bool FillCategoryNames(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                paramIn[0] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[0].Value = 0;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Category", paramIn, ref objDS)))
                {
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

        public bool FillPlantNames(int intPlantID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_plant_ID", SqlDbType.Int);
                paramIn[0].Value = intPlantID;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Plant", paramIn, ref objDS)))
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

        public bool GetPlantName(int intPlantID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_plant_ID", SqlDbType.Int);
                paramIn[0].Value = intPlantID;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Plant", paramIn, ref objDS)))
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

        public bool GetConPlantName(int intconGrpID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@Concurrence_Group_Id", SqlDbType.Int);
                paramIn[0].Value = intconGrpID;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("Get_Concurrent_Plant_Info", paramIn, ref objDS)))
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

        public bool FillMachineNames(int intPlantID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[0].Value = 3;

                paramIn[1] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[1].Value = intPlantID;

                paramIn[2] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[2].Value = 0;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Machine_Tree_View_Details", paramIn, ref objDS)))
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

        public bool AddMachineNames(int PlantID, string MachineName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Machine_ID", SqlDbType.Int);
                paramIn[0].Value = 0;

                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[1].Value = 3;

                paramIn[2] = new SqlParameter("@p_plant_ID", SqlDbType.Int);
                paramIn[2].Value = PlantID;

                paramIn[3] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[3].Value = DBNull.Value;

                paramIn[4] = new SqlParameter("@p_Machine_Name", SqlDbType.VarChar);
                paramIn[4].Value = MachineName;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[5].Value = DBNull.Value;

                paramIn[6] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[6].Value = DBNull.Value;

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

        public bool EditMachineNameDALC(int PlantID, string MachineName,int intMachineID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Machine_ID", SqlDbType.Int);
                paramIn[0].Value = intMachineID;

                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[1].Value = 3;

                paramIn[2] = new SqlParameter("@p_plant_ID", SqlDbType.Int);
                paramIn[2].Value = PlantID;

                paramIn[3] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[3].Value = DBNull.Value;

                paramIn[4] = new SqlParameter("@p_Machine_Name", SqlDbType.VarChar);
                paramIn[4].Value = MachineName;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[5].Value = DBNull.Value;

                paramIn[6] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[6].Value = DBNull.Value;

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

        public bool FillConvertMachineNames(int intPlantID,int intCategoryID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[0].Value = 2;

                paramIn[1] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                paramIn[1].Value = intPlantID;

                paramIn[2] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[2].Value = intCategoryID;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Machine_Tree_View_Details", paramIn, ref objDS)))
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

        public bool AddConvertMachineNames(int PlantID, int intCategoryID, string MachineName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Machine_ID", SqlDbType.Int);
                paramIn[0].Value = 0;

                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[1].Value = 2;

                paramIn[2] = new SqlParameter("@p_plant_ID", SqlDbType.Int);
                paramIn[2].Value = PlantID;

                paramIn[3] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[3].Value = intCategoryID;

                paramIn[4] = new SqlParameter("@p_Machine_Name", SqlDbType.VarChar);
                paramIn[4].Value = MachineName;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[5].Value = DBNull.Value;

                paramIn[6] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[6].Value = DBNull.Value;

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

        public bool UpdateConvertMachineNames(int PlantID, int CategoryID, string MachineName,int intMachineID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Machine_ID", SqlDbType.Int);
                paramIn[0].Value = intMachineID;

                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", SqlDbType.Int);
                paramIn[1].Value = 2;

                paramIn[2] = new SqlParameter("@p_plant_ID", SqlDbType.Int);
                paramIn[2].Value = PlantID;

                paramIn[3] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[3].Value = CategoryID;

                paramIn[4] = new SqlParameter("@p_Machine_Name", SqlDbType.VarChar);
                paramIn[4].Value = MachineName;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[5].Value = Convert.ToChar("A");

                paramIn[6] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[6].Value = DBNull.Value;

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
    }
}
