using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class CoachingBoxDA
    {
        string m_strLastError;

        public bool GetCoachingBoxDA(int Coach_Box_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Help_Page_Id", Coach_Box_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Help_Page", paramIn, ref objDS)))
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

        public bool InsertCoachingBoxDA(int Coach_Box_Id, string MsgName, string Msg, string UserName, string Status, ref SqlParameter[] paramOut)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[5];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here               

                paramIn[0] = new SqlParameter("@p_Help_Page_ID", SqlDbType.Int);
                paramIn[0].Value = Coach_Box_Id;
                paramIn[1] = new SqlParameter("@p_Key_Name", SqlDbType.VarChar);
                paramIn[1].Value = MsgName;

                paramIn[2] = new SqlParameter("@p_Key_Value", SqlDbType.VarChar);
                paramIn[2].Value = Msg;

                paramIn[3] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[3].Value = UserName;
                paramIn[4] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[4].Value = Convert.ToChar(Status);

                
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Help_Page", paramIn, ref paramOut, true)))
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
