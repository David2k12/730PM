using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MUREOPROP;

namespace MUREODAL
{
    public class MachinesByCategoryDA
    {
        string m_strLastError;

        public bool FillMachinesByCategory(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Machine_Type_ID", 2);



                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("dbo.GET_MUR_Machine_Tree_View", paramIn, ref objDS)))
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
        public bool DeleteMachine(Int32 intMachineID, String strUserName, ref Int32 resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Machine_ID", intMachineID);
                paramIn[1] = new SqlParameter("@User_Name", strUserName);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryExecuteNonQuery("Delete_Machine_Master", paramIn)))
                {
                    //Set the status to true here.
                    bReturn = true;
                    resout = 0;
                }
                else
                {
                    //Get the last error from DBPool here.
                    resout = -1;
                    m_strLastError = objDBPool.GetLastError();
                }
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
                resout = -1;
            }
            finally
            {
                paramIn = null;
                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }
        public bool FillMachinesByPlant(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Machine_Type_ID", 3);



                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("dbo.GET_MUR_Machine_Tree_View", paramIn, ref objDS)))
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
        public bool GetCategoryName(int CategoryID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Category_ID", CategoryID);



                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("dbo.GET_MUR_Category", paramIn, ref objDS)))
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
        public bool DeleteMachine(int intMachineID, string strUserName, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Machine_ID", intMachineID);
                paramIn[1] = new SqlParameter("@User_Name", strUserName);



                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("Delete_Machine_Master", paramIn, ref objDS)))
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
        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;

        }
    }
}
