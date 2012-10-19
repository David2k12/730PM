using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class EOScopeOptionDA
    {
        //
        string m_strLastError = string.Empty;
        //        Public Shared Function SetSuggestedBudgetCenter(ByVal scopeMapID As Integer, ByVal strScopeID As Integer, ByVal strPlantID As Integer, ByVal strBudgetID As Integer, ByVal strUserName As String) As Integer
        //    Dim sqlparams(5) As SqlClient.SqlParameter


        //    sqlparams(0) = New SqlClient.SqlParameter("@Scope_Mapping_ID ", SqlDbType.Int)
        //    sqlparams(0).Value = scopeMapID

        //    sqlparams(1) = New SqlClient.SqlParameter("@Scope_ID", SqlDbType.Int)
        //    sqlparams(1).Value = strScopeID

        //    sqlparams(2) = New SqlClient.SqlParameter("@Plant_ID ", SqlDbType.Int)
        //    sqlparams(2).Value = strPlantID

        //    sqlparams(3) = New SqlClient.SqlParameter("@Budget_Center_ID", SqlDbType.Int)
        //    sqlparams(3).Value = strBudgetID

        //    sqlparams(4) = New SqlClient.SqlParameter("@User_Name", SqlDbType.VarChar)
        //    sqlparams(4).Value = strUserName

        //    sqlparams(5) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //    sqlparams(5).Direction = ParameterDirection.Output

        //    DatabaseHelper.ExecuteNonQuery("SET_EO_Scope_Mapping", sqlparams)

        //    If Not sqlparams(5).Value Is DBNull.Value Then
        //        Return CInt(sqlparams(5).Value)
        //    Else
        //        Return -1
        //    End If
        //    'Return sqlparams(1).Value

        //End Function
        public bool SetSuggestedBudgetCenter(int scopeMapID, Int32 strScopeID, int strPlantID, int strBudgetID, string strUserName, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[5];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Scope_Mapping_ID", scopeMapID);
                paramIn[1] = new SqlParameter("@Scope_ID", strScopeID);
                paramIn[2] = new SqlParameter("@Plant_ID", strPlantID);
                paramIn[3] = new SqlParameter("@Budget_Center_ID", strBudgetID);
                paramIn[4] = new SqlParameter("@User_Name", strUserName);                
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Scope_Mapping", paramIn, ref resout, true)))
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

        //  ************************************************
        //Name   	    :	InsertEOScopeOptionDA
        //Written BY	    :	Vijay Selvaganapathy
        //parameters     :	Scope_Id,Scope_Name,Budget_Center_Id,Bounty_Approver_Name,Charmin_Approver_Name,
        //                   Puffs_Approver_Name,Default_Approver_Name,SAP_CCC_Apporver_Name,User Name,Status
        //Purpose	    :   To insert/update new/existing EO Scope options
        //Returns        :   Number indicating insert/update success/failure
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        // 08-22-07          Vijay Selvaganapathy                    Created
        //***************************************************
        public bool InsertEOScopeOptionDA(int Scope_ID, string Scope_Name, int Budget_Center_Id, string Bounty_Approver_Name, string Charmin_Approver_Name, string Puffs_Approver_Name, string Default_Approver_Name, string SAP_CCC_Apporver_Name, string UserName, char Status, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[10];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_SO_ID", Scope_ID);
                paramIn[1] = new SqlParameter("@p_Scope_Option_Name", Scope_Name);
                paramIn[2] = new SqlParameter("@p_Budget_Center_ID", Budget_Center_Id);
                paramIn[3] = new SqlParameter("@p_Bounty_Approver_Name", Bounty_Approver_Name);
                paramIn[4] = new SqlParameter("@p_Charmin_Approver_Name", Charmin_Approver_Name);
                paramIn[5] = new SqlParameter("@p_Puffs_Approver_Name", Puffs_Approver_Name);
                paramIn[6] = new SqlParameter("@p_Default_Approver_Name", Default_Approver_Name);
                paramIn[7] = new SqlParameter("@p_SAP_CCC_Approver_Name", SAP_CCC_Apporver_Name);
                paramIn[8] = new SqlParameter("@p_User_Name", UserName);
                paramIn[9] = new SqlParameter("@p_Status", Status);
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Scope_Options", paramIn, ref resout, true)))
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
        public bool GetSeedDataforBudget(ref DataSet objDS)
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
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_Seed_Data", ref objDS)))
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

        public bool GetBudgetByEOScope(ref DataSet objDS)
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
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_SCOPE_MAPPING", ref objDS)))
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




        public bool FillWithSuggestedBudgetcenter(Int32 parValue, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Plant_ID", parValue);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Scope_Budget_Center", paramIn, ref objDS)))
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

        public bool GetEOScopeOptionDetailsDA(Int32 Scope_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_SO_ID", Scope_ID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Scope_Options", paramIn, ref objDS)))
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
