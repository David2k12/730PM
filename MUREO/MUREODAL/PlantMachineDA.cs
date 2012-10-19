using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class PlantMachineDA
    {
        string m_strLastError = string.Empty;
        //       Public Shared Function FillPlantNames(ByVal PlantID As Integer) As DataSet
        //    Try
        //        Dim sqlparams(0) As SqlClient.SqlParameter
        //        Dim plantDataSet As DataSet

        //        sqlparams(0) = New SqlClient.SqlParameter("@p_plant_ID", SqlDbType.Int)
        //        sqlparams(0).Value = 0

        //        Return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Plant", sqlparams)


        //    Catch ex As Exception
        //        Throw ex

        //    End Try

            
        //End Function


        //Public Shared Function GetConPlantName(ByVal conGrpID As Integer) As DataSet
        //    Try
        //        Dim sqlparams(0) As SqlClient.SqlParameter
        //        Dim plantDataSet As DataSet

        //        sqlparams(0) = New SqlClient.SqlParameter("@Concurrence_Group_Id", SqlDbType.Int)
        //        sqlparams(0).Value = conGrpID

        //        Return DatabaseHelper.ExecuteDataSet("dbo.Get_Concurrent_Plant_Info", sqlparams)


        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function

        //Public Shared Function GetPlantName(ByVal PlantID As Integer) As DataSet
        //    Try
        //        Dim sqlparams(0) As SqlClient.SqlParameter
        //        Dim plantDataSet As DataSet

        //        sqlparams(0) = New SqlClient.SqlParameter("@p_plant_ID", SqlDbType.Int)
        //        sqlparams(0).Value = PlantID

        //        Return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Plant", sqlparams)


        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function
        //        Public Shared Function FillMachineNames(ByVal PlantID As Integer) As DataSet

        //    'Try
        //    '    Dim sqlparams(0) As SqlClient.SqlParameter
        //    '    Dim plantDataSet As DataSet

        //    '    sqlparams(0) = New SqlClient.SqlParameter("@p_plant_ID", SqlDbType.Int)
        //    '    sqlparams(0).Value = PlantID

        //    '    Return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Machine_By_Plant", sqlparams)


        //    'Catch ex As Exception
        //    '    Throw ex

        //    'End Try
        //    Try
        //        Dim sqlparams(2) As SqlClient.SqlParameter
        //        Dim plantDataSet As DataSet

        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Machine_Type_ID", SqlDbType.Int)
        //        sqlparams(0).Value = 3
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //        sqlparams(1).Value = PlantID
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_Category_ID", SqlDbType.Int)
        //        sqlparams(2).Value = 0

        //        Return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Machine_Tree_View_Details", sqlparams)


        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function


        public bool FillMachineNames(Int32 PlantID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Machine_Type_ID", 3);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[2] = new SqlParameter("@p_Category_ID", 0);
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
        public bool GetPlantName(Int32 PlantID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_plant_ID", PlantID);
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

        public bool GetConPlantName(Int32 Concurrence_Group_Id, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Concurrence_Group_Id", Concurrence_Group_Id);
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


        //  Public Shared Function EditMachineNameDALC(ByVal PlantID As Integer, ByVal MachineName As String, ByVal intMachineID As Integer) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Machine_ID", SqlDbType.Int)
        //        sqlparams(0).Value = intMachineID
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Machine_Type_ID", SqlDbType.Int)
        //        sqlparams(1).Value = 3
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_plant_ID", SqlDbType.Int)
        //        sqlparams(2).Value = PlantID
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Category_ID", SqlDbType.Int)
        //        sqlparams(3).Value = Convert.DBNull
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Machine_Name ", SqlDbType.VarChar)
        //        sqlparams(4).Value = MachineName
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_Status", SqlDbType.Char)
        //        sqlparams(5).Value = "A"
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar)
        //        sqlparams(6).Value = Convert.DBNull
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = Convert.DBNull

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_MUR_Machine", sqlparams)

        //        Return sqlparams(7).Value()

        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function


        public bool EditMachineNameDALC(int PlantID, string MachineName, Int32 intMachineID, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Machine_ID", intMachineID);
                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", 3);
                paramIn[2] = new SqlParameter("@p_plant_ID", PlantID);
                paramIn[3] = new SqlParameter("@p_Category_ID", DBNull.Value);
                paramIn[4] = new SqlParameter("@p_Machine_Name", MachineName);
                paramIn[5] = new SqlParameter("@p_Status", "A");
                paramIn[6] = new SqlParameter("@p_User_Name", System.DBNull.Value);
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_MUR_Machine", paramIn, ref resout, true)))
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
        public bool AddMachineNames(int PlantID, string MachineName, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Machine_ID", 0);
                paramIn[1] = new SqlParameter("@p_Machine_Type_ID", 3);
                paramIn[2] = new SqlParameter("@p_plant_ID", PlantID);
                paramIn[3] = new SqlParameter("@p_Category_ID", DBNull.Value);
                paramIn[4] = new SqlParameter("@p_Machine_Name", MachineName);
                paramIn[5] = new SqlParameter("@p_Status", DBNull.Value);
                paramIn[6] = new SqlParameter("@p_User_Name", DBNull.Value);           
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_MUR_Machine", paramIn, ref resout, true)))
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

        //Public Shared Function AddMachineNames(ByVal PlantID As Integer, ByVal MachineName As String) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Machine_ID", SqlDbType.Int)
        //        sqlparams(0).Value = 0
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Machine_Type_ID", SqlDbType.Int)
        //        sqlparams(1).Value = 3
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_plant_ID", SqlDbType.Int)
        //        sqlparams(2).Value = PlantID
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Category_ID", SqlDbType.Int)
        //        sqlparams(3).Value = Convert.DBNull
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Machine_Name ", SqlDbType.VarChar)
        //        sqlparams(4).Value = MachineName
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_Status", SqlDbType.Char)
        //        sqlparams(5).Value = Convert.DBNull
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar)
        //        sqlparams(6).Value = Convert.DBNull
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = Convert.DBNull

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_MUR_Machine", sqlparams)

        //        Return sqlparams(7).Value()

        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function
        public bool FillPlantNames(Int32 PlantID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_plant_ID", PlantID);
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
    }
}
