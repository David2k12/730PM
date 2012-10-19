using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;


namespace MUREODAL
{
    public class ChangeDistributionDA
    {
        string m_strLastError;
        bool bReturn = false;

        public bool GET_EO_OnRoute_FYI_Distribution_List(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
         

            try
            {
                string spName = "GET_EO_OnRoute_FYI_Distribution_List";
             

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams(spName, ref objDS)))
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

        public bool SET_EO_OnRoute_FYI_Distribution_List(string strParamLIst, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_OnRoute_FYI_Distribution_List", strParamLIst);
                paramIn[1] = new SqlParameter("@p_UserName", strUserName);
                paramOut[0] = new SqlParameter("@p_R_OUT", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_OnRoute_FYI_Distribution_List", paramIn, ref paramOut, true)))
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


        //public static int SET_EO_OnRoute_FYI_Distribution_List(string strParamLIst, string strUserName)
        //{
        //    SqlClient.SqlParameter[,] sqlparams;
        //    sqlparams[0] = new SqlClient.SqlParameter("@p_OnRoute_FYI_Distribution_List", SqlDbType.VarChar);
        //    sqlparams[0].Value = strParamLIst;
        //    sqlparams[1] = new SqlClient.SqlParameter("@p_UserName", SqlDbType.VarChar);
        //    sqlparams[1].Value = strUserName;
        //    sqlparams[2] = new SqlClient.SqlParameter("@p_R_OUT", SqlDbType.Int);
        //    sqlparams[2].Direction = ParameterDirection.Output;
        //    DatabaseHelper.ExecuteNonQuery("SET_EO_OnRoute_FYI_Distribution_List", sqlparams);
        //    if ((!(sqlparams[2].Value == null)
        //                && (sqlparams[2].Value == 0)))
        //    {
        //        return sqlparams[2].Value;
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}
        //      public static DataSet GET_EO_OnRoute_FYI_Distribution_List() {
        //        return DataAccess.MUREO.DATA.ChangeDistributionListDAC.GET_EO_OnRoute_FYI_Distribution_List();
        //    }

        //    public static int SET_EO_OnRoute_FYI_Distribution_List(string strParamLIst, string strUserName) {
        //        return DataAccess.MUREO.DATA.ChangeDistributionListDAC.SET_EO_OnRoute_FYI_Distribution_List(strParamLIst, strUserName);
        //}
    }
}
