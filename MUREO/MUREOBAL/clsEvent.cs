using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsEvent
    {
        clsEventDAL objClsEventDAL = new clsEventDAL();
        string m_strLastError;
        Boolean bReturn = false;

        public bool GET_MUR_Events_By_Project_Or_Plant(int intPlantID, int intProjectID,ref DataSet objds)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.GET_MUR_Events_By_Project_Or_Plant(intPlantID, intProjectID, ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_MUR_Projects_By_Plant(int intPlantID, ref DataSet objds)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.GET_MUR_Projects_By_Plant(intPlantID, ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetDr(string sqlText, string param, int intParmValue, ref DataSet objds)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.GetDr(sqlText, param, intParmValue, ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetEventDetailsBO(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            try
            {
                //Call the data access function here
                if (objClsEventDAL.GetEventDetailsBO(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objClsEventDAL.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FetchAllPlantsorEvents(string spName, string spColumnName, int parPlantEventID, ref DataSet objDS) 
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.FetchAllPlantsorEventsDAL(spName, spColumnName, parPlantEventID,ref objDS))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillDropDownSeedData(string spName, ref DataSet objds)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.FillDropDownSeedDataDAL(spName,ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FetchEventDetails(int parEventID,ref DataSet objds)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.FetchEventDetails(parEventID, ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FetchMachines(int parMachineType, int parPlantID, int parCategoryId, ref DataSet objds, string SPName)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.FetchMachinesDAL(parMachineType, parPlantID, parCategoryId, ref objds, SPName))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FetchProjectDetailsForEvent(string spName, string spColumnName, int parPlantEventID, ref DataSet objds)
        {
            //Init the data access layer object here
           

            try
            {
                //Call the data access function here
                if (objClsEventDAL.FetchProjectDetailsForEventsDAL(spName, spColumnName, parPlantEventID,ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GETEOSeedDataByEventIDs(string spName, string spColumnName, string parPlantEventID, ref DataSet objds)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.GETEOSeedDataByEventIDsDAL(spName, spColumnName, parPlantEventID,ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool EventInsertDAL(int intEventID, int intPrjID, int intPlantID, string strEventName, int intEventType, DateTime dtDDate, string strShippable, Decimal decDHold, int intPMachineID, Decimal decPTDownTime, Decimal decPTUpTime, Decimal decPPercent, Decimal decPTLostDays, string strPComments, int intConMachineID, Decimal decConTDownTime, Decimal decConTUpTime, Decimal decConPercent, Decimal decConTLostDays, string strConComments, int intComMachineID, Decimal decComTDownTime, Decimal decComTUpTime, Decimal decComPercent, Decimal decComTLostDays, string strAuthors, string strStatus, string strUser, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[28];
            paramOut = new SqlParameter[2];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_Event_ID", intEventID);
                paramIn[1] = new SqlParameter("@p_Project_ID", intPrjID);
                paramIn[2] = new SqlParameter("@p_Plant_ID", intPlantID);
                paramIn[3] = new SqlParameter("@p_Event_Name", strEventName);
                paramIn[4] = new SqlParameter("@p_Event_Type_ID", intEventType);
                paramIn[5] = new SqlParameter("@p_Desired_Start_Date", dtDDate);
                paramIn[6] = new SqlParameter("@p_Is_Product_Shippable", strShippable);
                paramIn[7] = new SqlParameter("@p_Days_On_Hold", decDHold);
                paramIn[8] = new SqlParameter("@p_Paper_Machine_ID", intPMachineID);
                paramIn[9] = new SqlParameter("@p_PM_Total_Downtime", System.DBNull.Value);
                paramIn[10] = new SqlParameter("@p_PM_Total_Uptime", System.DBNull.Value);
                paramIn[11] = new SqlParameter("@p_PM_Percentage", System.DBNull.Value);
                paramIn[12] = new SqlParameter("@p_PM_Total_Lost_Days", decPTLostDays);
                paramIn[13] = new SqlParameter("@p_PM_Comments", strPComments);
                paramIn[14] = new SqlParameter("@p_Conv_Machine_ID", intConMachineID);
                paramIn[15] = new SqlParameter("@p_Conv_Total_Downtime", System.DBNull.Value);
                paramIn[16] = new SqlParameter("@p_Conv_Total_Uptime", System.DBNull.Value);
                paramIn[17] = new SqlParameter("@p_Conv_Percentage", System.DBNull.Value);
                paramIn[18] = new SqlParameter("@p_Conv_Total_Lost_Days", decConTLostDays);
                paramIn[19] = new SqlParameter("@p_Conv_Comments", strConComments);
                paramIn[20] = new SqlParameter("@p_Com_Machine_ID", intComMachineID);
                paramIn[21] = new SqlParameter("@p_Com_Total_Downtime", System.DBNull.Value);
                paramIn[22] = new SqlParameter("@p_Com_Total_Uptime", System.DBNull.Value);
                paramIn[23] = new SqlParameter("@p_Com_Percentage", System.DBNull.Value);
                paramIn[24] = new SqlParameter("@p_Com_Total_Lost_Days", decComTLostDays);
                paramIn[25] = new SqlParameter("@p_Other_Authors", strAuthors);
                paramIn[26] = new SqlParameter("@p_Status", strStatus);
                paramIn[27] = new SqlParameter("@p_User_Name", strUser);
                paramOut[0] = new SqlParameter("@p_New_Event_ID", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                paramOut[1] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[1].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Event", paramIn, ref paramOut, true)))
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

        public bool EventInsertForMigrationDAL(int intEventID, int intPrjID, int intPlantID, string strEventName, int intEventType, DateTime dtDDate, string strShippable, Decimal decDHold, int intPMachineID, Decimal decPTDownTime, Decimal decPTUpTime, Decimal decPPercent, Decimal decPTLostDays, string strPComments, int intConMachineID, Decimal decConTDownTime, Decimal decConTUpTime, Decimal decConPercent, Decimal decConTLostDays, string strConComments, int intComMachineID, Decimal decComTDownTime, Decimal decComTUpTime, Decimal decComPercent, Decimal decComTLostDays, string strAuthors, string strStatus, string strUser, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[28];
            paramOut = new SqlParameter[2];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_Event_ID", intEventID);
                paramIn[1] = new SqlParameter("@p_Project_ID", intPrjID);
                paramIn[2] = new SqlParameter("@p_Plant_ID", intPlantID);
                paramIn[3] = new SqlParameter("@p_Event_Name", strEventName);
                paramIn[4] = new SqlParameter("@p_Event_Type_ID", intEventType);
                paramIn[5] = new SqlParameter("@p_Desired_Start_Date", dtDDate);
                paramIn[6] = new SqlParameter("@p_Is_Product_Shippable", strShippable);
                paramIn[7] = new SqlParameter("@p_Days_On_Hold", decDHold);
                paramIn[8] = new SqlParameter("@p_Paper_Machine_ID", intPMachineID);
                paramIn[9] = new SqlParameter("@p_PM_Total_Downtime", System.DBNull.Value);
                paramIn[10] = new SqlParameter("@p_PM_Total_Uptime", System.DBNull.Value);
                paramIn[11] = new SqlParameter("@p_PM_Percentage", System.DBNull.Value);
                paramIn[12] = new SqlParameter("@p_PM_Total_Lost_Days", decPTLostDays);
                paramIn[13] = new SqlParameter("@p_PM_Comments", strPComments);
                paramIn[14] = new SqlParameter("@p_Conv_Machine_ID", intConMachineID);
                paramIn[15] = new SqlParameter("@p_Conv_Total_Downtime", System.DBNull.Value);
                paramIn[16] = new SqlParameter("@p_Conv_Total_Uptime", System.DBNull.Value);
                paramIn[17] = new SqlParameter("@p_Conv_Percentage", System.DBNull.Value);
                paramIn[18] = new SqlParameter("@p_Conv_Total_Lost_Days", decConTLostDays);
                paramIn[19] = new SqlParameter("@p_Conv_Comments", strConComments);
                paramIn[20] = new SqlParameter("@p_Com_Machine_ID", intComMachineID);
                paramIn[21] = new SqlParameter("@p_Com_Total_Downtime", System.DBNull.Value);
                paramIn[22] = new SqlParameter("@p_Com_Total_Uptime", System.DBNull.Value);
                paramIn[23] = new SqlParameter("@p_Com_Percentage", System.DBNull.Value);
                paramIn[24] = new SqlParameter("@p_Com_Total_Lost_Days", decComTLostDays);
                paramIn[25] = new SqlParameter("@p_Other_Authors", strAuthors);
                paramIn[26] = new SqlParameter("@p_Status", strStatus);
                paramIn[27] = new SqlParameter("@p_User_Name", strUser);
                paramOut[0] = new SqlParameter("@p_New_Event_ID", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                paramOut[1] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[1].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Event", paramIn, ref paramOut, true)))
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

        public bool FillDropDownWithProjects(int catogeryID, int brandID, ref DataSet objds, string SPName)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objClsEventDAL.FillDropDownWithProjectsDAL(catogeryID, brandID, ref objds, SPName))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool CountForDeletion(int intEventID, string strUser, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsEventDAL objclsEventDAL = new clsEventDAL();
            try
            {
                //Call the data access function here
                if (objclsEventDAL.CountForDeletion(intEventID, strUser, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objclsEventDAL.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }
        
    }
}
