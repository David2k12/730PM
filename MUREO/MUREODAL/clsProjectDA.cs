using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsProjectDA
    {
        string m_strLastError = string.Empty;
        //       Public Shared Function FillHistoryofProject(ByVal parValue As Integer) As DataSet
        //    Try
        //        Dim sqlparams(0) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Project_ID", SqlDbType.Int)
        //        sqlparams(0).Value = parValue
        //        Return DatabaseHelper.ExecuteDataSet("GET_MUR_Project", sqlparams)
        //    Catch ex As Exception
        //        Throw (ex)
        //        Return Nothing
        //    End Try
        //End Function
        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;
        }
        public bool FillHistoryofProject(Int32 parValue, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Project_ID", parValue);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Project", paramIn, ref objDS)))
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
        public bool FetchProjectDetails(Int32 parProjectId, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];       
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Project_ID", parProjectId);
              
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Project", paramIn, ref objDS)))
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

        //Public Shared Function FetchProjectDetails(ByVal parProjectId As Integer) As DataSet
        //    Try
        //        Dim sqlParams(0) As SqlClient.SqlParameter
        //        sqlParams(0) = New SqlClient.SqlParameter("@p_Project_ID", SqlDbType.Int)
        //        sqlParams(0).Value = parProjectId
        //        Return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Project", sqlParams)
        //    Catch ex As Exception
        //        Throw (ex)
        //        Return Nothing
        //    End Try
        //End Function

        //By Murali

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GetDr()
        //Written BY	    :	UdayaSri
        //parameters     :	ProjectID,weeks,User
        //Purpose	    :   To insert Event start date datails into database
        //Returns        :   to BO
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/21/07                 Abdul             2.0           Modified where one of the parameters 
        //will now be days instead of Weeks i.e arparams(1)
        //***************************************************

        public bool EventStartDate(int intPrjID, string strWeeks, string strUser, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Project_ID", SqlDbType.Int);
                paramIn[0].Value = intPrjID;

                paramIn[1] = new SqlParameter("@p_No_Of_Days", SqlDbType.VarChar);
                paramIn[1].Value = strWeeks;

                paramIn[2] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[2].Value = strUser;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Adjust_Event_Start_Date", paramIn, ref paramOut, true)))
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

        //end by Murali
    }
}
