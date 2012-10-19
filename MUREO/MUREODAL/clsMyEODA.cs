using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsMyEODA
    {
        string m_strLastError;
        bool bReturn = false;
        //'  ************************************************
        //'Developed by   :	Vertex Computer Systems, Inc.,
        //'Name   	    :	DeleteEO()
        //'Written BY	    :	Md.Abdul Allaam
        //'parameters     :	intEOID,strUserName
        //'Purpose	    :   To delete an EO and as well deleting an events.
        //'Returns        :   To UI
        //'Program Change History:
        //'<Date>			         <Editor>	                <Rev>		<Description>
        //'02/26/08                Md.Abdul allaam             1.0           created
        //'***************************************************
        //Public Shared Function DeleteEO(ByVal intEOID As Integer, ByVal strUserName As String) As Integer
        //    Dim params(2) As SqlClient.SqlParameter

        //    params(0) = New SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int)
        //    params(0).Value = intEOID

        //    params(1) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar, 100)
        //    params(1).Value = strUserName

        //    params(2) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //    params(2).Direction = ParameterDirection.Output

        //    DatabaseHelper.ExecuteNonQuery("SET_InActivate_EO_And_Events", params)

        //    Return params(2).Value

        //End Function
        //GetSelectedEOList
        //    Public Shared Function GetSelectedEOList(ByVal parPlantID As Integer, ByVal parOriginator As String, ByVal parUserName As String, ByVal parEOType As Char) As DataSet
        //    Dim params(3) As SqlClient.SqlParameter

        //    params(0) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //    params(0).Value = parPlantID

        //    params(1) = New SqlClient.SqlParameter("@p_Originator", SqlDbType.VarChar, 100)
        //    params(1).Value = parOriginator

        //    params(2) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar, 100)
        //    params(2).Value = parUserName

        //    params(3) = New SqlClient.SqlParameter("@p_EO_Mode", SqlDbType.Char)
        //    params(3).Value = parEOType

        //    Return DatabaseHelper.ExecuteDataSet("GET_EO_ALL_EOs_Details", params)
        //End Function
        // Public Shared Function GetAllEOsForOriginator(Optional ByVal parValue As String = "Originator") As DataSet
        //    Dim sqlParams(0) As SqlClient.SqlParameter

        //    sqlParams(0) = New SqlClient.SqlParameter("@p_Order_By", SqlDbType.VarChar, 50)
        //    sqlParams(0).Value = parValue

        //    Return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_ALL_EOs", sqlParams)
        //End Function
        public bool GetSelectedEOList(Int32 parPlantID, string parOriginator, string parUserName, char parEOType, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here              
                paramIn[0] = new SqlParameter("@p_Plant_ID", parPlantID);
                paramIn[1] = new SqlParameter("@p_Originator", parOriginator);
                paramIn[2] = new SqlParameter("@p_User_Name", parUserName);
                paramIn[3] = new SqlParameter("@p_EO_Mode", parEOType);
                
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_ALL_EOs_Details", paramIn, ref objDS)))
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
        //  Public Shared Function GetAllEOs() As DataSet
        //    Return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_ALL_EOs")
        //End Function

        public bool GetAllEOs(ref DataSet objDS)
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
                if ((objDBPool.SPQueryDatasetwithoutParameters("GET_EO_ALL_EOs", ref objDS)))
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
        public bool GetAllEOsForOriginator(string parValue,ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Order_By", parValue);                
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_ALL_EOs", paramIn, ref objDS)))
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

        public bool DeleteEO(int intEOID, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[2];

            try
            {
                paramIn[0] = new SqlParameter("@p_EO_ID", intEOID);
                paramIn[1] = new SqlParameter("@p_User_Name", strUserName);                
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_InActivate_EO_And_Events", paramIn, ref paramOut, true)))
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

        public bool GetApprovedSelectedEO(Int32 parPlantID, string parCurrentStage, string parStatus, string parUserName, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here              
                paramIn[0] = new SqlParameter("@p_Plant_ID", parPlantID);
                paramIn[1] = new SqlParameter("@p_Current_Stage", parCurrentStage);
                paramIn[2] = new SqlParameter("@p_Status", parStatus);
                paramIn[3] = new SqlParameter("@p_User_Name", parUserName);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Status_Tree_View_Detail", paramIn, ref objDS)))
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

        public bool GetApprovedEO(string parCurrentStage, string parStatus, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Current_Stage", parCurrentStage);
                paramIn[1] = new SqlParameter("@p_Status", parStatus);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Status_Tree_View", paramIn, ref objDS)))
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
        public bool ShowApprovals(Int32 parIntEOID,string parStrStatus,ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", parIntEOID);
                paramIn[1] = new SqlParameter("@p_EO_Status", parStrStatus);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Approval_Status_Comment", paramIn, ref objDS)))
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
        public bool DeleteStopCancelEO(int intEOID, char strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[3];

            try
            {
                paramIn[0] = new SqlParameter("@p_EO_ID", intEOID);
                paramIn[1] = new SqlParameter("@p_Status", strStatus);
                paramIn[2] = new SqlParameter("@p_User_Name", strUserName);
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_ALL_EO_S_C_D", paramIn, ref paramOut, true)))
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

        public bool GetMyEOs(string strLoginUserName, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_User_Name", strLoginUserName);             
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_MyEOs", paramIn, ref objDS)))
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


        public bool GetCancelledEOs(char parStatus, string parUserName, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_S_C_D_Status", parStatus);
                paramIn[1] = new SqlParameter("@p_User_Name", parUserName);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_S_C_D_Status", paramIn, ref objDS)))
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
        public bool SetEOActive(int parEOID, string parUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[2];

            try
            {
                paramIn[0] = new SqlParameter("@p_EO_ID", parEOID);
                paramIn[1] = new SqlParameter("@p_User_Name", parUserName);
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Reactivate", paramIn, ref paramOut, true)))
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

         public bool GetApprovalsConcurrences(Int32 parPlantID, string parCurrentStage, string parStatus, string parUserName, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here              
                paramIn[0] = new SqlParameter("@p_Plant_ID", parPlantID);
                paramIn[1] = new SqlParameter("@p_Current_Stage", parCurrentStage);
                paramIn[2] = new SqlParameter("@p_Status", parStatus);
                paramIn[3] = new SqlParameter("@p_User_Name", parUserName);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Status_Tree_View_Detail", paramIn, ref objDS)))
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

        #region "Murali"

         public bool GetAwaitingCloseOutSelectedEO(string strOriginator, ref DataSet objDS)
         {
             //Variable Declarations
             bool bReturn = false;
             SqlParameter[] paramIn = new SqlParameter[1];
             DBPool objDBPool = null;
             try
             {
                 //Set procedure params here
                 paramIn[0] = new SqlParameter("@p_Originator", SqlDbType.VarChar);
                 paramIn[0].Value = strOriginator;

                 //Instantiate DBPool Object here
                 objDBPool = new DBPool();
                 //Calling the SPQueryDataset which is in the DBPOOL.
                 if ((objDBPool.SPQueryDataset("GET_EO_My_Awaiting_Closeout_Tree_View_Details", paramIn, ref objDS)))
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

         public bool GetArchivedSelectedEO(int intPlantID, string strCurrentStage, string strEOType, string strUserName, ref DataSet objDS)
         {
             //Variable Declarations
             bool bReturn = false;
             DBPool objDBPool = null;
             SqlParameter[] paramIn = new SqlParameter[4];

             try
             {   
                 paramIn[0] = new SqlParameter("@p_Plant_ID", SqlDbType.Int);
                 paramIn[0].Value = intPlantID;
                 paramIn[1] = new SqlParameter("@p_Stage_Status", SqlDbType.VarChar);
                 paramIn[1].Value = strCurrentStage;
                 paramIn[2] = new SqlParameter("@p_EO_Mode", SqlDbType.VarChar);
                 paramIn[2].Value = strEOType;
                 paramIn[3] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                 paramIn[3].Value = strUserName;

                 objDBPool = new DBPool();
                 if ((objDBPool.SPQueryDataset("GET_EO_Archived_Data_Tree_View_Details", paramIn, ref objDS)))
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

         public bool GetArchivedEOs(ref DataSet objDS)
         {
             //Variable Declarations
             bool bReturn = false;
             m_strLastError = string.Empty;
             DBPool objDBPool = null;

             try
             {
                 objDBPool = new DBPool();
                 //Input Parameter List
                 if (objDBPool.SPQueryDatasetNoParams("GET_EO_Archived_Data_Tree_View", ref objDS))
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

        #endregion

    }
}
