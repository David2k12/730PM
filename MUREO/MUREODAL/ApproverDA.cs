using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class ApproverDA
    {
        string m_strLastError = string.Empty;
        public bool FillEOFunctionDA(Int32 FunctionID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_function_ID", FunctionID);
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
        public bool GetEOApprovalGroupOtherDetailsDA(Int32 Approval_Group_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_approval_group_id", Approval_Group_ID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Approval_Group", paramIn, ref objDS)))
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
        public bool GetEOApproverDA(Int32 ApproverID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here             
                paramIn[0] = new SqlParameter("@p_approver_ID", ApproverID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Approvers", paramIn, ref objDS)))
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
        public bool FillEOApproversByFunctionDAMod(string FunctionName, Int32 PlantID, Int32 FunctionID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                if (string.IsNullOrEmpty(FunctionName))
                    paramIn[0] = new SqlParameter("@p_Function_Name", null);
                else
                    paramIn[0] = new SqlParameter("@p_Function_Name", FunctionName);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[2] = new SqlParameter("@p_Function_ID", FunctionID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Functions_Approver_Plant_View", paramIn, ref objDS)))
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
        public bool FillEOAdditionalApprover1ByFunctionDA(Int32 Additional_Approver, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Additional_Approver", Additional_Approver);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Functions_Approver_Plant_AllDistinct", paramIn, ref objDS)))
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
        public bool FillApproverPlantsDA(Int32 p_plant_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_plant_ID", p_plant_ID);
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
        public bool FillApprovalGroupCategorybyBrandDA(Int32 CategoryID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_category_ID", CategoryID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Brand_Segment_By_Category", paramIn, ref objDS)))
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
        public bool FillApprovalGroupCategoryDA(Int32 CategoryID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_category_ID", CategoryID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Category", paramIn, ref objDS)))
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
        public bool InsertEOApproverDA(int ApproverID, string ApproverName, int PlantID, int FunctionID, string UserName, char Status, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_approver_ID", ApproverID);
                paramIn[1] = new SqlParameter("@p_approver_Name", ApproverName);
                paramIn[2] = new SqlParameter("@p_plant_ID", PlantID);
                paramIn[3] = new SqlParameter("@p_function_ID", FunctionID);
                paramIn[4] = new SqlParameter("@p_user_Name", UserName);
                paramIn[5] = new SqlParameter("@p_Status", Status);
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Approver", paramIn, ref resout, true)))
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
        public bool InsertEOApprovalGroupDA(int ApproverGroupID, string ApprovalGroupName, int BrandSegID, int PlantID, char EOMode, string ApproverList, char Status, string UserName, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[8];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_approval_group_ID", ApproverGroupID);
                paramIn[1] = new SqlParameter("@p_approval_group_Name", ApprovalGroupName);
                paramIn[2] = new SqlParameter("@p_brand_segment_ID", BrandSegID);
                paramIn[3] = new SqlParameter("@p_plant_ID", PlantID);
                paramIn[4] = new SqlParameter("@p_EO_mode", EOMode);
                paramIn[5] = new SqlParameter("@p_approver_names_list", ApproverList);
                paramIn[6] = new SqlParameter("@p_status", Status);
                paramIn[7] = new SqlParameter("@p_user_name", UserName);
                resout[0] = new SqlParameter("@p_result_no", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Approval_Group", paramIn, ref resout, true)))
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
        // Public Shared Function FillEOApprovalGroupDetailsDA(ByVal ApprovalGrpID As Integer) As DataSet

        //    Dim sqlparams(0) As SqlClient.SqlParameter

        //    sqlparams(0) = New SqlClient.SqlParameter("@p_approval_Group_ID", SqlDbType.Int)
        //    sqlparams(0).Value = ApprovalGrpID
        //    Return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Approval_Groups_Details", sqlparams)

        //End Function
        public bool FillEOApprovalGroupDetailsDA(Int32 ApprovalGrpID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here               
                paramIn[0] = new SqlParameter("@p_approval_Group_ID", ApprovalGrpID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Approval_Groups_Details", paramIn, ref objDS)))
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
        public bool FillEOApproversByFunctionDA(string FunctionName, Int32 PlantID, Int32 FunctionID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                if (string.IsNullOrEmpty(FunctionName))
                    paramIn[0] = new SqlParameter("@p_Function_Name", null);
                else
                    paramIn[0] = new SqlParameter("@p_Function_Name", FunctionName);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[2] = new SqlParameter("@p_Function_ID", FunctionID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Functions_Approver_Plant", paramIn, ref objDS)))
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
        //Public Shared Function FillEOApproversByFunctionDA(ByVal FunctionName As String, ByVal PlantID As Integer, ByVal FunctionID As Integer) As DataSet
        //    Dim sqlparams(2) As SqlClient.SqlParameter
        //    sqlparams(0) = New SqlClient.SqlParameter("@p_Function_Name", SqlDbType.VarChar, 50)
        //    sqlparams(0).Value = IIf(FunctionName = "", DBNull.Value, FunctionName)
        //    sqlparams(1) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //    sqlparams(1).Value = PlantID
        //    sqlparams(2) = New SqlClient.SqlParameter("@p_Function_ID", SqlDbType.Int)
        //    sqlparams(2).Value = FunctionID
        //    Return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Functions_Approver_Plant", sqlparams)
        //End Function
    }
}
