using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class ConcurrenceGroupDA
    {
        string m_strLastError = string.Empty;
        //Public Shared Function FillConcurrenceGroup() As DataSet
        //    Return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Concurrence_Group")
        //End Function


        //Public Shared Function DeleteConcurrenceGroup(ByVal ConcurrenceGroupID As Integer) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Concurrence_Group_ID", SqlDbType.Int)
        //        sqlparams(0).Value = ConcurrenceGroupID
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Concurrence_Group_Name", SqlDbType.VarChar)
        //        sqlparams(1).Value = Convert.DBNull
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //        sqlparams(2).Value = 1
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar)
        //        sqlparams(3).Value = Convert.DBNull
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Phone_Number ", SqlDbType.VarChar)
        //        sqlparams(4).Value = Convert.DBNull
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.Char)
        //        sqlparams(5).Value = Convert.DBNull
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_Status", SqlDbType.VarChar)
        //        sqlparams(6).Value = "I"
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = Convert.DBNull

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Concurrence_Group", sqlparams)

        //        Return sqlparams(7).Value

        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function
        public bool AddEoConcurrenceGroup(Int32 PlantID,string ConGrpName,string NameforGrp,ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Concurrence_Group_ID", 0);
                paramIn[1] = new SqlParameter("@p_Concurrence_Group_Name", ConGrpName);
                paramIn[2] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[3] = new SqlParameter("@p_Approver_Name", NameforGrp);
                paramIn[4] = new SqlParameter("@p_Phone_Number", "");
                paramIn[5] = new SqlParameter("@p_User_Name", "");
                paramIn[6] = new SqlParameter("@p_Status", "A");
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Concurrence_Group", paramIn, ref resout, true)))
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

        public bool UpdateEoConcurrenceGroup(Int32 ConGrpID,Int32 PlantID, string ConGrpName, string NameforGrp, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Concurrence_Group_ID", ConGrpID);
                paramIn[1] = new SqlParameter("@p_Concurrence_Group_Name", ConGrpName);
                paramIn[2] = new SqlParameter("@p_Plant_ID",PlantID );
                paramIn[3] = new SqlParameter("@p_Approver_Name", NameforGrp);
                paramIn[4] = new SqlParameter("@p_Phone_Number", "");
                paramIn[5] = new SqlParameter("@p_User_Name", "");
                paramIn[6] = new SqlParameter("@p_Status", "A");
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Concurrence_Group", paramIn, ref resout, true)))
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
        
        //Public Shared Function AddEoConcurrenceGroup(ByVal PlantID As Integer, ByVal ConGrpName As String, ByVal NameforGrp As String) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Concurrence_Group_ID", SqlDbType.Int)
        //        sqlparams(0).Value = 0
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Concurrence_Group_Name", SqlDbType.VarChar)
        //        sqlparams(1).Value = ConGrpName
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //        sqlparams(2).Value = PlantID
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar)
        //        sqlparams(3).Value = NameforGrp
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Phone_Number ", SqlDbType.VarChar)
        //        sqlparams(4).Value = Convert.DBNull
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.Char)
        //        sqlparams(5).Value = Convert.DBNull
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_Status", SqlDbType.VarChar)
        //        sqlparams(6).Value = "A"
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = 0

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Concurrence_Group", sqlparams)

        //        Return sqlparams(7).Value

        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function

        //Public Shared Function UpdateEoConcurrenceGroup(ByVal ConGrpID As Integer, ByVal PlantID As Integer, ByVal ConGrpName As String, ByVal NameforGrp As String) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Concurrence_Group_ID", SqlDbType.Int)
        //        sqlparams(0).Value = ConGrpID
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Concurrence_Group_Name", SqlDbType.VarChar)
        //        sqlparams(1).Value = ConGrpName
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //        sqlparams(2).Value = PlantID
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar)
        //        sqlparams(3).Value = NameforGrp
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Phone_Number ", SqlDbType.VarChar)
        //        sqlparams(4).Value = Convert.DBNull
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.Char)
        //        sqlparams(5).Value = Convert.DBNull
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_Status", SqlDbType.VarChar)
        //        sqlparams(6).Value = "A"
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = 0

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Concurrence_Group", sqlparams)

        //        Return sqlparams(7).Value

        //    Catch ex As Exception
        //        Throw ex

        //    End Try


        //End Function
        public bool DeleteConcurrenceGroup(Int32 ConcurrenceGroupID, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Concurrence_Group_ID", ConcurrenceGroupID);
                paramIn[1] = new SqlParameter("@p_Concurrence_Group_Name", 1);
                paramIn[2] = new SqlParameter("@p_Plant_ID", 1);
                paramIn[3] = new SqlParameter("@p_Approver_Name", "");
                paramIn[4] = new SqlParameter("@p_Phone_Number", "");
                paramIn[5] = new SqlParameter("@p_User_Name", "");
                paramIn[6] = new SqlParameter("@p_Status", "I");
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Concurrence_Group", paramIn, ref resout, true)))
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
        public bool FillConcurrenceGroup(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_Concurrence_Group", ref objDS)))
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
