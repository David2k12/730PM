using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class ViewDataCoordinatorsDAL
    {
        string m_strLastError;

        public bool GetDataCoordinatorDetailsDA(int Co_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
           
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_DO_ID", Co_ID);

                
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Data_Coordinator", paramIn, ref objDS)))
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

        public bool InsertDataCoordinatorDA(int Co_ID, int Category_ID, string Co_Name, string Phone_Number, string User_Name, string Status, ref SqlParameter[] paramOut)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here               

                paramIn[0] = new SqlParameter("@p_DO_ID", SqlDbType.Int);
                paramIn[0].Value = Co_ID;
                paramIn[1] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[1].Value = Category_ID;

                paramIn[2] = new SqlParameter("@p_Data_Coordinator_Name", SqlDbType.VarChar);
                paramIn[2].Value = Co_Name;
                paramIn[3] = new SqlParameter("@p_Phone_Number", SqlDbType.VarChar);
                paramIn[3].Value = Phone_Number;
                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = User_Name;
                paramIn[5] = new SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[5].Value = Convert.ToChar(Status);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Data_Coordinator", paramIn, ref paramOut, true)))
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
