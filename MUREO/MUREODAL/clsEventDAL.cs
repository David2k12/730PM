using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsEventDAL
    {
        string m_strLastError;
        bool bReturn = false;

        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;
        }

        public bool GET_MUR_Events_By_Project_Or_Plant(int intPlantID, int intProjectID, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[2];

            try
            {
                paramIn[0] = new SqlParameter("@p_Plant_ID", intPlantID);
                paramIn[1] = new SqlParameter("@p_Project_ID", intProjectID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset("GET_MUR_Events_By_Project_Or_Plant", paramIn, ref objds)))
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

        public bool GET_MUR_Projects_By_Plant(int intPlantID, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter("@p_Plant_ID", intPlantID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset("GET_MUR_Projects_By_Plant", paramIn, ref objds)))
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

        public bool GetDr(string sqlText,string param, int intParmValue, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter(param, intParmValue);
                objDBPool = new DBPool();
                if (objDBPool.SPQueryDataset(sqlText, paramIn, ref objds))
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

        public bool GetEventDetailsBO(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_MUR_Raw_Event_Data_new", ref objDS)))
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

        public bool FetchAllPlantsorEventsDAL(string spName, string spColumnName, int parPlantEventID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter(spColumnName, parPlantEventID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(spName, paramIn, ref objDS)))
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

        public bool FetchEventDetails(int parEventID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter("@p_Event_ID", parEventID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset("GET_MUR_Event", paramIn, ref objDS)))
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

        public bool FillDropDownSeedDataDAL(string spName, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetwithoutParameters(spName, ref objds)))
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

        public bool FetchMachinesDAL(string spname, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;


                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetwithoutParameters(spname, ref objds)))
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

        public bool FetchMachinesDAL(int parMachineType, int parPlantID, int parCategoryId, ref DataSet ds, string SPName)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[3];

            try
            {
                paramIn[0] = new SqlParameter("@p_Machine_Type_ID", parMachineType);
                paramIn[1] = new SqlParameter("@p_Plant_ID", parPlantID);
                paramIn[2] = new SqlParameter("@p_Category_ID", parCategoryId);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(SPName, paramIn, ref ds)))
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

        public bool FetchProjectDetailsForEventsDAL(string spName, string spColumnName, int parPlantEventID, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter(spColumnName, parPlantEventID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(spName, paramIn, ref objds)))
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

        public bool GETEOSeedDataByEventIDsDAL(string spName, string spColumnName, string parPlantEventID, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[1];

            try
            {
                paramIn[0] = new SqlParameter(spColumnName, parPlantEventID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(spName, paramIn, ref objds)))
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

        public bool FillDropDownWithProjectsDAL(int catogeryID, int brandID, ref DataSet ds, string SPName)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[2];

            try
            {
                paramIn[0] = new SqlParameter("@p_Category_ID", catogeryID);
                paramIn[1] = new SqlParameter("@p_Brand_Segment_ID", brandID);

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(SPName, paramIn, ref ds)))
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

        public bool CountForDeletion(int intEventID, string strUser, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@Event_ID", intEventID);
                paramIn[1] = new SqlParameter("@User_Name", strUser);
                paramIn[2] = new SqlParameter("@Check", "Y");


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("Delete_Events", paramIn, ref paramOut, true)))
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
