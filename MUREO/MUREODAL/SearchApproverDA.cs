using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class SearchApproverDA
    {
        string m_strLastError;
        bool bReturn = false;
        public bool GetApprovers(ref DataSet objDS)
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
                if ((objDBPool.SPQueryDatasetwithoutParameters("GET_EO_Search_Approver_Names",ref objDS)))
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
        public bool GetFunction(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Function_ID", 0);               
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Functions", paramIn, ref objDS)))
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
        public bool GetApprGrpName(string ApprName, int FuncID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Approver_Name", ApprName);
                paramIn[1] = new SqlParameter("@p_Function_ID", FuncID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Search_Approver_Groups", paramIn, ref objDS)))
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
        public bool SetSearchApproverName(string oldApprName, int FuncID, string GrpIDList, string NewApprName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[4];

            try
            {
                paramIn[0] = new SqlParameter("@p_Old_Approver_Name", oldApprName);
                paramIn[1] = new SqlParameter("@p_Function_ID", FuncID);
                paramIn[2] = new SqlParameter("@p_Group_ID_List", GrpIDList);
                paramIn[3] = new SqlParameter("@p_New_Approver_Name", NewApprName);              
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Search_Approver_Names", paramIn, ref paramOut, true)))
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
        //public static DataSet GetApprovers()
        //{
        //    try
        //    {
        //        //Dim sqlparams(0) As SqlClient.SqlParameter
        //        //Dim ApprDataset As DataSet

        //        //sqlparams(0) = New SqlClient.SqlParameter("@p_Approver_ID", SqlDbType.Int)
        //        //sqlparams(0).Value = 0

        //        return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Search_Approver_Names");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static DataSet GetFunction()
        //{
        //    try
        //    {
        //        System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[1];
        //        DataSet FunctionDataset = null;

        //        sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_Function_ID", SqlDbType.Int);
        //        sqlparams[0].Value = 0;

        //        return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Functions", sqlparams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static DataSet GetApprGrpName(string ApprName, int FuncID)
        //{
        //    try
        //    {
        //        System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[2];
        //        DataSet FunctionDataset = null;
        //        sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar);
        //        sqlparams[0].Value = ApprName;
        //        sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_Function_ID", SqlDbType.Int);
        //        sqlparams[1].Value = FuncID;
        //        return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Search_Approver_Groups", sqlparams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static int SetSearchApproverName(string oldApprName, int FuncID, string GrpIDList, string NewApprName)
        //{
        //    try
        //    {
        //        System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[5];
        //        DataSet FunctionDataset = null;
        //        sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_Old_Approver_Name", SqlDbType.VarChar);
        //        sqlparams[0].Value = oldApprName;
        //        sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_Function_ID", SqlDbType.Int);
        //        sqlparams[1].Value = FuncID;
        //        sqlparams[2] = new System.Data.SqlClient.SqlParameter("@p_Group_ID_List", SqlDbType.VarChar);
        //        sqlparams[2].Value = GrpIDList;
        //        sqlparams[3] = new System.Data.SqlClient.SqlParameter("@p_New_Approver_Name", SqlDbType.VarChar);
        //        sqlparams[3].Value = NewApprName;
        //        sqlparams[4] = new System.Data.SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int);
        //        sqlparams[4].Direction = ParameterDirection.Output;
        //        sqlparams[4].Value = Convert.DBNull;
        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Search_Approver_Names", sqlparams);
        //        return sqlparams[4].Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
