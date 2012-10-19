using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MUREOPROP;

namespace MUREODAL
{
    public class EODA
    {
        string m_strLastError;

        public bool SET_EO_Lock_Release(string parEOID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            paramOut = new SqlParameter[0];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID_String", parEOID);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Lock_Release", paramIn, ref paramOut, true)))
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

        public bool GET_EO_Lock_Users(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_All_EO_Lock_Status", ref objDS)))
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

        public bool GET_EO_Extract_Cost_Sheet_Data(string dtFromDate, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                if (dtFromDate != string.Empty || dtFromDate != "")
                    paramIn[0] = new SqlParameter("@p_dtFromDate", dtFromDate);
                else
                    paramIn[0] = new SqlParameter("@p_dtFromDate", DBNull.Value);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Extract_Cost_Sheet_Data", paramIn, ref objDS)))
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

        public bool FillDropDownWithBrands(int parCategoryid, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Category_ID", parCategoryid);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_BRAND_Segment_By_Category", paramIn, ref objDS)))
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

        public bool FillDropDownWithConvertingMachine(int parCategoryId, string parPlantId, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Category_ID", parCategoryId);
                paramIn[0] = new SqlParameter("@p_Plant_ID", parPlantId);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Machine_By_Plant_Category", paramIn, ref objDS)))
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

        public bool FillDropDownWithPaperMachine(int parPlantID, ref DataSet objDS)
        {//Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Plant_ID", parPlantID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("Get_MUR_Machine_By_Plant", paramIn, ref objDS)))
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

        public bool FetchEONumbers(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_IDs", ref objDS)))
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

        public bool FillPrescreneGroups(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_PreScreener_Group", ref objDS)))
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

        public bool AddPrescreenGrpNames(int EoID, int preScreneGrpId, string emailSentance, string userName, ref SqlParameter[] paramOut)
        {

            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_PS_App_ID", 0);
                paramIn[1] = new SqlParameter("@p_EO_ID", EoID);
                paramIn[2] = new SqlParameter("@p_Prescreener_Group_ID", preScreneGrpId);
                paramIn[3] = new SqlParameter("@p_Approver_Name", "");
                paramIn[4] = new SqlParameter("@p_Is_Responded", "");
                paramIn[5] = new SqlParameter("@p_Email_Sentence", emailSentance);
                paramIn[6] = new SqlParameter("@p_User_Name", userName);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Prescreener_Approvers", paramIn, ref paramOut, true)))
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

        public bool FillPrescreenGrpNames(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_PreScreener_Group", ref objDS)))
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

        public bool FillConGroups(int PlantID, int ConGrpID, ref DataSet objDS)
        {//Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Concurrence_Group_ID", ConGrpID);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Concurrence_Group", paramIn, ref objDS)))
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

        public bool SET_EO_FYI(int intFYIID, int intEOID, string strApproverNames, string strcomments, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_FYI_ID", intFYIID);
                paramIn[0] = new SqlParameter("@p_EO_ID", intEOID);
                paramIn[0] = new SqlParameter("@p_Approver_Names", strApproverNames);
                paramIn[0] = new SqlParameter("@p_Comments", strcomments);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_FYI", paramIn, ref paramOut, true)))
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

        public bool GET_EO_FYI(int intEOID, ref DataSet objDS)
        {//Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", intEOID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_FYI", paramIn, ref objDS)))
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

        public bool GET_EO_Lock_Status(string parEOID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            SqlParameter[] paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", parEOID);

                paramOut[0] = new SqlParameter("@Lock_State", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDatasetOutputParam("GET_EO_Lock_Status", paramIn, ref objDS, ref paramOut)))
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

        public bool GETEOFunctionsAdditionalApprover4Plant(ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Additional_Approver", 4);

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

        public bool GETEOFunctionsAdditionalApprover3Plant(ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Additional_Approver", 3);

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

        public bool GETEOFunctionsAdditionalApprover2Plant(ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Additional_Approver", 2);

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

        public bool GETEOFunctionsAdditionalApprover1Plant(ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Additional_Approver", 1);

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

        public bool GETEOFunctionsApproverPlant(string strFunctionName, int PlantID, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Function_Name", strFunctionName);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[2] = new SqlParameter("@p_Function_ID", 0);

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

        public bool FillDropDownSeedData(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
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

        public bool FillDropDownSeedData1(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_MUR_Project_Lead", ref objDS)))
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

        public bool GETEOSeedDataByEventIDs(string p_Event_IDs, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Event_IDs", p_Event_IDs);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Seed_Data_By_Event_IDs", paramIn, ref objDS)))
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

        public bool GET_Budget_Centre_ID(int p_SO_ID, int Plant_ID, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_SO_ID", p_SO_ID);
                paramIn[1] = new SqlParameter("@Plant_ID", Plant_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_Budget_Centre_ID", paramIn, ref objDS)))
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

        public bool FillListBoxWithBrands(string p_Category_ID, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Category_ID", p_Category_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_BRAND_Segment_By_Category", paramIn, ref objDS)))
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

        public bool GET_EO_Data_Coordinator_By_Category(string p_Category_ID, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Category_ID", p_Category_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Data_Coordinator_By_Category", paramIn, ref objDS)))
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

        public bool FetchMigratedEventInfo(string p_Event_ID_List, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Event_ID_List", p_Event_ID_List);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Event_Migration_Details", paramIn, ref objDS)))
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

        public bool GET_EO_Approval_Groups_Details(int p_Approval_Group_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Approval_Group_ID", p_Approval_Group_ID);

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

        public bool GET_EO_Final_Approvers_List(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Final_Approvers_List", paramIn, ref objDS)))
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

        public bool GETGSRAData(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_GCASNo", paramIn, ref objDS)))
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

        public bool GET_EO_Preliminary(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Preliminary", paramIn, ref objDS)))
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

        public bool GET_EO_Final(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Final", paramIn, ref objDS)))
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

        public bool getPreGroupUsers(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Prescreener_Approvers", paramIn, ref objDS)))
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

        public bool GETPSRAData(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_PSRANo", paramIn, ref objDS)))
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

        //public bool GETGSRAData(int p_EO_ID, ref DataSet objDS)
        //{
        //    //Variable Declarations
        //    bool bReturn = false;
        //    SqlParameter[] paramIn = new SqlParameter[1];
        //    DBPool objDBPool = null;
        //    try
        //    {
        //        //Set procedure params here
        //        paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

        //        //Instantiate DBPool Object here
        //        objDBPool = new DBPool();
        //        //Calling the SPQueryDataset which is in the DBPOOL.
        //        if ((objDBPool.SPQueryDataset("GET_EO_GCASNo", paramIn, ref objDS)))
        //            //Set the status to true here.
        //            bReturn = true;
        //        else
        //            //Get the last error from DBPool here.
        //            m_strLastError = objDBPool.GetLastError();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Set the error to this variable
        //        m_strLastError = ex.StackTrace;
        //    }
        //    finally
        //    {
        //        paramIn = null;
        //        objDBPool = null;
        //    }
        //    //Return status here
        //    return bReturn;
        //}

        public bool GET_EO_Closeout(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Closeout", paramIn, ref objDS)))
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

        public bool GETEOMandatory(int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Mandatory", paramIn, ref objDS)))
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

        public bool GET_EO_Is_Approved(int p_EO_ID, string p_Function_Name, string p_Approver_Name, string p_Stage, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[4];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);
                paramIn[1] = new SqlParameter("@p_Function_Name", p_Function_Name);
                paramIn[2] = new SqlParameter("@p_Approver_Name", p_Approver_Name);
                paramIn[3] = new SqlParameter("@p_Stage", p_Stage);
                paramOut[0] = new SqlParameter("@p_Is_Approved", SqlDbType.Char, 1);
                paramOut[0].Direction = ParameterDirection.Output;

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("GET_EO_Is_Approved", paramIn, ref paramOut, true)))
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

        public bool GET_MUR_Projects_By_Category_Brand_Segment(int p_Category_ID, string p_Brand_Segment_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Category_ID", p_Category_ID);
                paramIn[1] = new SqlParameter("@p_Brand_Segment_ID", p_Brand_Segment_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Projects_By_Category_Brand_Segment", paramIn, ref objDS)))
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

        public bool FillListBoxWithEventsByEoID(int p_Project_ID, int p_EO_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Project_ID", p_Project_ID);
                paramIn[1] = new SqlParameter("@p_EO_ID", p_EO_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Events_By_Project", paramIn, ref objDS)))
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

        public bool GetAttachmentsInfoCO(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EoId);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_ID", intAttachmentID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_CloseOut_Attachment", paramIn, ref objDS)))
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

        public bool GetAttachmentsInfo(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EoId);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_ID", intAttachmentID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Preliminary_Attachment", paramIn, ref objDS)))
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

        public bool GetAttachmentsInfoFinal(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EoId);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_ID", intAttachmentID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Final_Attachment", paramIn, ref objDS)))
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

        public bool GET_EO_Approval_Groups_By_Plant_Brand_EOMode(int p_Plant_ID, string p_Brand_ID_List, char p_EOMode, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Plant_ID", p_Plant_ID);
                paramIn[1] = new SqlParameter("@p_Brand_ID_List", p_Brand_ID_List);
                paramIn[2] = new SqlParameter("@p_EOMode", p_EOMode);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Approval_Groups_By_Plant_Brand_EOMode", paramIn, ref objDS)))
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

        public bool UpdateGCASNo(int GCAS_ID, int GCAS_Material_Number, string GCAS_Site_Short_Name, char New_To_Site, char New_To_Category, char Intermediate, char Type_Developmental, char Type_Regulated, char Type_Contingent, char Type_Needs_Activation, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[10];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new System.Data.SqlClient.SqlParameter("@p_GCAS_ID", SqlDbType.Int);
                paramIn[0].Value = GCAS_ID;
                paramIn[1] = new System.Data.SqlClient.SqlParameter("@p_GCAS_Material_Number", SqlDbType.Int);
                paramIn[1].Value = GCAS_Material_Number;
                paramIn[2] = new System.Data.SqlClient.SqlParameter("@p_GCAS_Site_Short_Name", SqlDbType.VarChar);
                paramIn[2].Value = GCAS_Site_Short_Name;
                paramIn[3] = new System.Data.SqlClient.SqlParameter("@p_New_To_Site", SqlDbType.Char);
                paramIn[3].Value = New_To_Site;
                paramIn[4] = new System.Data.SqlClient.SqlParameter("@p_New_To_Category", SqlDbType.Char);
                paramIn[4].Value = New_To_Category;
                paramIn[5] = new System.Data.SqlClient.SqlParameter("@p_Intermediate", SqlDbType.Char);
                paramIn[5].Value = Intermediate;
                paramIn[6] = new System.Data.SqlClient.SqlParameter("@p_Type_Developmental", SqlDbType.Char);
                paramIn[6].Value = Type_Developmental;
                paramIn[7] = new System.Data.SqlClient.SqlParameter("@p_Type_Regulated", SqlDbType.Char);
                paramIn[7].Value = Type_Regulated;
                paramIn[8] = new System.Data.SqlClient.SqlParameter("@p_Type_Contingent", SqlDbType.Char);
                paramIn[8].Value = Type_Contingent;
                paramIn[9] = new System.Data.SqlClient.SqlParameter("@p_Type_Needs_Activation", SqlDbType.Char);
                paramIn[9].Value = Type_Needs_Activation;

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("Update_EO_GCASNo", paramIn, ref paramOut, true)))
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

        public bool AddGCASNo(int EO_ID, int GCAS_Material_Number, string GCAS_Site_Short_Name, char New_To_Site, char New_To_Category, char Intermediate, char Type_Developmental, char Type_Regulated, char Type_Contingent, char Type_Needs_Activation, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[10];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[0].Value = EO_ID;
                paramIn[1] = new System.Data.SqlClient.SqlParameter("@p_GCAS_Material_Number", SqlDbType.Int);
                paramIn[1].Value = GCAS_Material_Number;
                paramIn[2] = new System.Data.SqlClient.SqlParameter("@p_GCAS_Site_Short_Name", SqlDbType.VarChar);
                paramIn[2].Value = GCAS_Site_Short_Name;
                paramIn[3] = new System.Data.SqlClient.SqlParameter("@p_New_To_Site", SqlDbType.Char);
                paramIn[3].Value = New_To_Site;
                paramIn[4] = new System.Data.SqlClient.SqlParameter("@p_New_To_Category", SqlDbType.Char);
                paramIn[4].Value = New_To_Category;
                paramIn[5] = new System.Data.SqlClient.SqlParameter("@p_Intermediate", SqlDbType.Char);
                paramIn[5].Value = Intermediate;
                paramIn[6] = new System.Data.SqlClient.SqlParameter("@p_Type_Developmental", SqlDbType.Char);
                paramIn[6].Value = Type_Developmental;
                paramIn[7] = new System.Data.SqlClient.SqlParameter("@p_Type_Regulated", SqlDbType.Char);
                paramIn[7].Value = Type_Regulated;
                paramIn[8] = new System.Data.SqlClient.SqlParameter("@p_Type_Contingent", SqlDbType.Char);
                paramIn[8].Value = Type_Contingent;
                paramIn[9] = new System.Data.SqlClient.SqlParameter("@p_Type_Needs_Activation", SqlDbType.Char);
                paramIn[9].Value = Type_Needs_Activation;


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_GCASNo", paramIn, ref paramOut, true)))
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

        public bool AddPSRANo(int EO_ID, string CT_Tracking_Number, string Supplier_Name, string Material_Application, string Material_Usage_Amount, string PSRA_Level, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[10];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[0].Value = EO_ID;
                paramIn[1] = new System.Data.SqlClient.SqlParameter("@p_CT_Tracking_Number", SqlDbType.VarChar);
                paramIn[1].Value = CT_Tracking_Number;
                paramIn[2] = new System.Data.SqlClient.SqlParameter("@p_Supplier_Name", SqlDbType.VarChar);
                paramIn[2].Value = Supplier_Name;
                paramIn[3] = new System.Data.SqlClient.SqlParameter("@p_Material_Application", SqlDbType.Char);
                paramIn[3].Value = Material_Application;
                paramIn[4] = new System.Data.SqlClient.SqlParameter("@p_Material_Usage_Amount", SqlDbType.Char);
                paramIn[4].Value = Material_Usage_Amount;
                paramIn[5] = new System.Data.SqlClient.SqlParameter("@p_PSRA_Level", SqlDbType.Char);
                paramIn[5].Value = PSRA_Level;


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_PSRANo", paramIn, ref paramOut, true)))
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

        public bool updatePSRANo(int PSRA_Info_ID, string CT_Tracking_Number, string Supplier_Name, string Material_Application, string Material_Usage_Amount, string PSRA_Level, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new System.Data.SqlClient.SqlParameter("@p_PSRA_Info_ID", SqlDbType.Int);
                paramIn[0].Value = PSRA_Info_ID;
                paramIn[1] = new System.Data.SqlClient.SqlParameter("@p_CT_Tracking_Number", SqlDbType.VarChar);
                paramIn[1].Value = CT_Tracking_Number;
                paramIn[2] = new System.Data.SqlClient.SqlParameter("@p_Supplier_Name", SqlDbType.VarChar);
                paramIn[2].Value = Supplier_Name;
                paramIn[3] = new System.Data.SqlClient.SqlParameter("@p_Material_Application", SqlDbType.Char);
                paramIn[3].Value = Material_Application;
                paramIn[4] = new System.Data.SqlClient.SqlParameter("@p_Material_Usage_Amount", SqlDbType.Char);
                paramIn[4].Value = Material_Usage_Amount;
                paramIn[5] = new System.Data.SqlClient.SqlParameter("@p_PSRA_Level", SqlDbType.Char);
                paramIn[5].Value = PSRA_Level;


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("Update_EO_PSRANo", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Check_And_Lock(int p_EO_ID, string Locked_By, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);
                paramIn[1] = new SqlParameter("@Locked_By", Locked_By);
                paramOut[0] = new SqlParameter("@Lock_State", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Check_And_Lock", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Delete_Upon_Error(int parEOID, char parMode, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", parEOID);
                paramIn[1] = new SqlParameter("@Locked_By", parMode);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Delete_Upon_Error", paramIn, ref paramOut, true)))
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

        public bool SubmitCommonAttachments(string fName, byte[] fContent, string sConType, int EoID, string sectionName, string SPName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", EoID);

                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);

                paramIn[2] = new SqlParameter("@p_Attachment_IDs", DBNull.Value);

                if (fName == "")
                    paramIn[3] = new SqlParameter("@p_Attachment_File_Name", DBNull.Value);
                else
                    paramIn[3] = new SqlParameter("@p_Attachment_File_Name", fName);

                if (fName == "")
                    paramIn[4] = new SqlParameter("@p_Attachment_Type", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_Attachment_Type", sConType);

                if (fContent.Length == 0)
                    paramIn[5] = new SqlParameter("@p_Attachment", DBNull.Value);
                else
                    paramIn[5] = new SqlParameter("@p_Attachment", fContent);


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam(SPName, paramIn, ref paramOut, true)))
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

        public bool SetEOMandatory(objEO objEO, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[17];
            paramOut = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[0].Value = objEO.EOID;
                if (objEO.Title == "")
                    paramIn[1] = new SqlParameter("@p_EO_Title", DBNull.Value);
                else
                    paramIn[1] = new SqlParameter("@p_EO_Title", objEO.Title);

                paramIn[2] = new SqlParameter("@p_Event_ID_List", objEO.EventIDs);
                paramIn[3] = new SqlParameter("@p_Project_ID", objEO.ProjectID);
                paramIn[4] = new SqlParameter("@p_Plant_ID", objEO.PlantID);
                paramIn[5] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[5].Value = objEO.CategoryID;


                if (objEO.Originator == "")
                    paramIn[6] = new SqlParameter("@p_Originator", DBNull.Value);
                else
                    paramIn[6] = new SqlParameter("@p_Originator", objEO.Originator);

                if (objEO.OfficeNumber == "")
                    paramIn[7] = new SqlParameter("@p_Office_Num", DBNull.Value);
                else
                    paramIn[7] = new SqlParameter("@p_Office_Num", objEO.OfficeNumber);

                if (objEO.PhoneNumber == "")
                    paramIn[8] = new SqlParameter("@p_Phone_Num", DBNull.Value);
                else
                    paramIn[8] = new SqlParameter("@p_Phone_Num", objEO.PhoneNumber);

                if (objEO.Brands == "")
                    paramIn[9] = new SqlParameter("@p_Brand_Seg_ID_List", DBNull.Value);
                else
                    paramIn[9] = new SqlParameter("@p_Brand_Seg_ID_List", objEO.Brands);

                if (objEO.CoOrginator == "")
                    paramIn[10] = new SqlParameter("@p_CoOriginator", DBNull.Value);
                else
                    paramIn[10] = new SqlParameter("@p_CoOriginator", objEO.CoOrginator);


                if (objEO.CommsntsToApprover == "")
                    paramIn[11] = new SqlParameter("@p_Comments_To_Approver", DBNull.Value);
                else
                    paramIn[11] = new SqlParameter("@p_Comments_To_Approver", objEO.CommsntsToApprover);

                if (objEO.CurrentStagePre == "")
                    paramIn[12] = new SqlParameter("@p_Current_Stage", DBNull.Value);
                else
                    paramIn[12] = new SqlParameter("@p_Current_Stage", objEO.CurrentStagePre);

                if (objEO.StageStatus == "")
                    paramIn[13] = new SqlParameter("@p_Stage_Status", DBNull.Value);
                else
                    paramIn[13] = new SqlParameter("@p_Stage_Status", objEO.StageStatus);

                if (objEO.EOSiteTestOther == "")
                    paramIn[14] = new SqlParameter("@p_EO_Mode", DBNull.Value);
                else
                    paramIn[14] = new SqlParameter("@p_EO_Mode", objEO.EOSiteTestOther);

                if (objEO.TwoTabRoute == "")
                    paramIn[15] = new SqlParameter("@p_Two_Tab_Routing", DBNull.Value);
                else
                    paramIn[15] = new SqlParameter("@p_Two_Tab_Routing", objEO.TwoTabRoute);

                if (objEO.Smart_Clearance_Number == "" || objEO.Smart_Clearance_Number == null)
                    paramIn[16] = new SqlParameter("@p_SMART_Clearance_Number", DBNull.Value);
                else
                    paramIn[16] = new SqlParameter("@p_SMART_Clearance_Number", objEO.Smart_Clearance_Number);


                paramOut[0] = new SqlParameter("@p_New_EO_ID", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                paramOut[1] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[1].Direction = ParameterDirection.Output;

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Mandatory", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Preliminary(objEO objEO, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[72];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", objEO.EOID);
                if (objEO.EOType == "")
                    paramIn[1] = new SqlParameter("@p_EO_Type_ID_List", DBNull.Value);
                else
                    paramIn[1] = new SqlParameter("@p_EO_Type_ID_List", objEO.EOType);

                if (objEO.NewTypeOfEOType == "")
                    paramIn[2] = new SqlParameter("@p_New_EO_Type_Name", DBNull.Value);
                else
                    paramIn[2] = new SqlParameter("@p_New_EO_Type_Name", objEO.NewTypeOfEOType);

                paramIn[3] = new SqlParameter("@p_Scope_Type_ID", objEO.EOScopeProjectType);

                if (objEO.NewTypeOfEOScope == "")
                    paramIn[4] = new SqlParameter("@p_New_Scope_Type_Name", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_New_Scope_Type_Name", objEO.NewTypeOfEOScope);

                if (objEO.BriefDesc == "")
                    paramIn[5] = new SqlParameter("@p_Description", DBNull.Value);
                else
                    paramIn[5] = new SqlParameter("@p_Description", objEO.BriefDesc);


                paramIn[6] = new SqlParameter("@p_Paper_Making_Days", objEO.TotPaperMaking);
                paramIn[7] = new SqlParameter("@p_Converting_Time_Days", objEO.TotConverting);
                paramIn[8] = new SqlParameter("@p_Material_Cost", objEO.TotCostNewMaterials);
                paramIn[9] = new SqlParameter("@p_Specific_Cost", objEO.CostofEOSpecific);
                paramIn[10] = new System.Data.SqlClient.SqlParameter("@p_Total_Pre_Spending", SqlDbType.Decimal);
                paramIn[10].Value = objEO.TotPreSpend;
                //@p_EO_Executing_Cost
                paramIn[11] = new System.Data.SqlClient.SqlParameter("@p_EO_Executing_Cost", SqlDbType.Decimal);
                paramIn[11].Value = objEO.EOExecuCost;
                //@p_Total_Cost
                paramIn[12] = new System.Data.SqlClient.SqlParameter("@p_Total_Cost", SqlDbType.Decimal);
                paramIn[12].Value = objEO.TotCost;
                //@p_Budget_Center_ID
                paramIn[13] = new System.Data.SqlClient.SqlParameter("@p_Budget_Center_ID", SqlDbType.Int);
                paramIn[13].Value = objEO.SujBudgetCenter;
                //@p_Other_Center_Number
                paramIn[14] = new System.Data.SqlClient.SqlParameter("@p_Other_Center_Number", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.OtherBudgCenter))
                {
                    paramIn[14].Value = DBNull.Value;
                }
                else
                {
                    paramIn[14].Value = objEO.OtherBudgCenter;
                }
                //       '-- New Material And Brands Section
                //'@p_Raw_Pack_Mat
                paramIn[15] = new System.Data.SqlClient.SqlParameter("@p_Raw_Pack_Mat", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.NewRawPackage))
                {
                    paramIn[15].Value = DBNull.Value;
                }
                else
                {
                    paramIn[15].Value = objEO.NewRawPackage;
                }
                //@p_Parent_Rolls
                paramIn[16] = new System.Data.SqlClient.SqlParameter("@p_Parent_Rolls", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.EOProduce))
                {
                    paramIn[16].Value = DBNull.Value;
                }
                else
                {
                    paramIn[16].Value = objEO.EOProduce;
                }

                //@p_Intermediate_Mat
                paramIn[17] = new System.Data.SqlClient.SqlParameter("@p_Intermediate_Mat", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.EOProduceInterMaterial))
                {
                    paramIn[17].Value = DBNull.Value;
                }
                else
                {
                    paramIn[17].Value = objEO.EOProduceInterMaterial;
                }

                //@p_Regulated_Prod
                paramIn[18] = new System.Data.SqlClient.SqlParameter("@p_Regulated_Prod", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.EOProduceRegProd))
                {
                    paramIn[18].Value = DBNull.Value;
                }
                else
                {
                    paramIn[18].Value = objEO.EOProduceRegProd;
                }

                //@p_GMP_Classsify
                paramIn[19] = new System.Data.SqlClient.SqlParameter("@p_GMP_Classsify", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.appropriateGMP))
                {
                    paramIn[19].Value = DBNull.Value;
                }
                else
                {
                    paramIn[19].Value = objEO.appropriateGMP;
                }

                //@p_Current_Brand
                paramIn[20] = new System.Data.SqlClient.SqlParameter("@p_Current_Brand", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.EOShippedTrade))
                {
                    paramIn[20].Value = DBNull.Value;
                }
                else
                {
                    paramIn[20].Value = objEO.EOShippedTrade;
                }

                //@p_Cons_Lab_Eval
                paramIn[21] = new System.Data.SqlClient.SqlParameter("@p_Cons_Lab_Eval", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.TestProdSample))
                {
                    paramIn[21].Value = DBNull.Value;
                }
                else
                {
                    paramIn[21].Value = objEO.TestProdSample;
                }

                //@p_GCAS
                paramIn[22] = new System.Data.SqlClient.SqlParameter("@p_GCAS", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.GCASUMOF))
                {
                    paramIn[22].Value = DBNull.Value;
                }
                else
                {
                    paramIn[22].Value = objEO.GCASUMOF;
                }
                //-- GCAS Section 
                //@p_Is_GCAS_Rec			INT=0, 
                paramIn[23] = new System.Data.SqlClient.SqlParameter("@p_Is_GCAS_Rec", SqlDbType.Int);
                paramIn[23].Value = objEO.IsGCASRec;

                //@p_GCAS_XML_Str			TEXT,
                paramIn[24] = new System.Data.SqlClient.SqlParameter("@p_GCAS_XML_Str", SqlDbType.Text);
                paramIn[24].Value = objEO.GCASXMLStr;

                // HS&E Section
                //@p_Chemical_Change	
                paramIn[25] = new System.Data.SqlClient.SqlParameter("@p_Chemical_Change", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.NewChemExistChem))
                {
                    paramIn[25].Value = DBNull.Value;
                }
                else
                {
                    paramIn[25].Value = objEO.NewChemExistChem;
                }

                //@p_Raw_Material_Change	
                paramIn[26] = new System.Data.SqlClient.SqlParameter("@p_Raw_Material_Change", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.NewRawExistRaw))
                {
                    paramIn[26].Value = DBNull.Value;
                }
                else
                {
                    paramIn[26].Value = objEO.NewRawExistRaw;
                }

                // '@p_Equipment_Change	
                paramIn[27] = new System.Data.SqlClient.SqlParameter("@p_Equipment_Change", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.NewEqipExistEuip))
                {
                    paramIn[27].Value = DBNull.Value;
                }
                else
                {
                    paramIn[27].Value = objEO.NewEqipExistEuip;
                }

                //@p_Job_Task_Change	
                paramIn[28] = new System.Data.SqlClient.SqlParameter("@p_Job_Task_Change", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.NewjobExistjob))
                {
                    paramIn[28].Value = DBNull.Value;
                }
                else
                {
                    paramIn[28].Value = objEO.NewjobExistjob;
                }

                //-- PSRA Section
                //@p_Is_PSRA
                paramIn[29] = new System.Data.SqlClient.SqlParameter("@p_Is_PSRA", SqlDbType.Int);
                paramIn[29].Value = objEO.IsPSRA;
                //@p_PSRA_XML_Str

                paramIn[30] = new System.Data.SqlClient.SqlParameter("@p_PSRA_XML_Str", SqlDbType.Text);
                paramIn[30].Value = objEO.PSRAXMLStr;

                //@p_PSRA_ID_List
                paramIn[31] = new System.Data.SqlClient.SqlParameter("@p_PSRA_ID_List", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PSRAIDList))
                {
                    paramIn[31].Value = DBNull.Value;
                }
                else
                {
                    paramIn[31].Value = objEO.PSRAIDList;
                }


                //-- Planning and Budget Information Section
                //@p_Plant_ID	
                //paramIn[32) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
                //paramIn[32).Value = objEO.PlantSite
                //@p_Lines_Machines	
                paramIn[32] = new System.Data.SqlClient.SqlParameter("@p_Lines_Machines", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.LineMachine))
                {
                    paramIn[32].Value = DBNull.Value;
                }
                else
                {
                    paramIn[32].Value = objEO.LineMachine;
                }

                //@p_Planned_Start_Date
                paramIn[33] = new System.Data.SqlClient.SqlParameter("@p_Planned_Start_Date", SqlDbType.SmallDateTime);
                if (objEO.PlannedStartDate == System.DateTime.MinValue)
                {
                    paramIn[33].Value = DBNull.Value;
                }
                else
                {
                    paramIn[33].Value = Convert.ToDateTime(objEO.PlannedStartDate);
                }

                //@p_Formula_Card_Number
                paramIn[34] = new System.Data.SqlClient.SqlParameter("@p_Formula_Card_Number", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.FormulaCardNumber))
                {
                    paramIn[34].Value = DBNull.Value;
                }
                else
                {
                    paramIn[34].Value = objEO.FormulaCardNumber;
                }

                //-- Production and Packaging Section
                //@p_PP_Format
                paramIn[35] = new System.Data.SqlClient.SqlParameter("@p_PP_Format", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.Formats))
                {
                    paramIn[35].Value = DBNull.Value;
                }
                else
                {
                    paramIn[35].Value = objEO.Formats;
                }

                //@p_PP_Attachment
                paramIn[36] = new System.Data.SqlClient.SqlParameter("@p_PP_Attachment", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PPAttachment))
                {
                    paramIn[36].Value = DBNull.Value;
                }
                else
                {
                    paramIn[36].Value = objEO.PPAttachment;
                }

                //@p_PP_Lab_Notebook_Number
                paramIn[37] = new System.Data.SqlClient.SqlParameter("@p_PP_Lab_Notebook_Number", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PPLabNotebookNumber))
                {
                    paramIn[37].Value = DBNull.Value;
                }
                else
                {
                    paramIn[37].Value = objEO.PPLabNotebookNumber;
                }

                //-- Packaging Disposition Information Section
                //@p_Prod_Pack_ID_List
                paramIn[38] = new System.Data.SqlClient.SqlParameter("@p_Prod_Pack_ID_List", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.ProductPacked))
                {
                    paramIn[38].Value = DBNull.Value;
                }
                else
                {
                    paramIn[38].Value = objEO.ProductPacked;
                }

                //@p_Current_Packaging
                paramIn[39] = new System.Data.SqlClient.SqlParameter("@p_Current_Packaging", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.CurPackage))
                {
                    paramIn[39].Value = DBNull.Value;
                }
                else
                {
                    paramIn[39].Value = objEO.CurPackage;
                }
                //@p_Current_Packaging_Type--changed to @p_Packaging_Type
                paramIn[40] = new System.Data.SqlClient.SqlParameter("@p_Packaging_Type", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PackagingList))
                {
                    paramIn[40].Value = DBNull.Value;
                }
                else
                {
                    paramIn[40].Value = objEO.PackagingList;
                }
                //@p_Experimental_Packaging
                paramIn[41] = new System.Data.SqlClient.SqlParameter("@p_Experimental_Packaging", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.ExpPackage))
                {
                    paramIn[41].Value = DBNull.Value;
                }
                else
                {
                    paramIn[41].Value = objEO.ExpPackage;
                }

                //@p_Exp_Pack_Clear_Poly
                paramIn[42] = new System.Data.SqlClient.SqlParameter("@p_Exp_Pack_Clear_Poly", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.ClearPoly))
                {
                    paramIn[42].Value = DBNull.Value;
                }
                else
                {
                    paramIn[42].Value = objEO.ClearPoly;
                }

                //@p_Exp_Pack_Blank_KDF
                paramIn[43] = new System.Data.SqlClient.SqlParameter("@p_Exp_Pack_Blank_KDF", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.BlankKDF))
                {
                    paramIn[43].Value = DBNull.Value;
                }
                else
                {
                    paramIn[43].Value = objEO.BlankKDF;
                }

                //@p_Prod_Disp_ID
                paramIn[44] = new System.Data.SqlClient.SqlParameter("@p_Prod_Disp_ID", SqlDbType.Int);
                paramIn[44].Value = objEO.ProdDisposition;

                //@p_Prod_Disp_Add_Comments
                paramIn[45] = new System.Data.SqlClient.SqlParameter("@p_Prod_Disp_Add_Comments", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.AddCommnets))
                {
                    paramIn[45].Value = DBNull.Value;
                }
                else
                {
                    paramIn[45].Value = objEO.AddCommnets;
                }

                //@p_Pallet_Patter_SKU
                paramIn[46] = new System.Data.SqlClient.SqlParameter("@p_Pallet_Patter_SKU", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PalletPatternYesNo))
                {
                    paramIn[46].Value = DBNull.Value;
                }
                else
                {
                    paramIn[46].Value = objEO.PalletPatternYesNo;
                }

                //@p_Stack_Testing
                paramIn[47] = new System.Data.SqlClient.SqlParameter("@p_Stack_Testing", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.StacTesting))
                {
                    paramIn[47].Value = DBNull.Value;
                }
                else
                {
                    paramIn[47].Value = objEO.StacTesting;
                }

                //@@p_Ship_Testing
                paramIn[48] = new System.Data.SqlClient.SqlParameter("@p_Ship_Testing", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.ShipTesting))
                {
                    paramIn[48].Value = DBNull.Value;
                }
                else
                {
                    paramIn[48].Value = objEO.ShipTesting;
                }

                //@p_Material_Disposition_ID
                paramIn[49] = new System.Data.SqlClient.SqlParameter("@p_Material_Disposition_ID", SqlDbType.Int);
                paramIn[49].Value = objEO.MaterialDisposition;
                //@p_Mat_Disp_Add_Comments
                paramIn[50] = new System.Data.SqlClient.SqlParameter("@p_Mat_Disp_Add_Comments", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.MaterialDispoOtherComments))
                {
                    paramIn[50].Value = DBNull.Value;
                }
                else
                {
                    paramIn[50].Value = objEO.MaterialDispoOtherComments;
                }

                //@p_Broke_Disp_Normal
                paramIn[51] = new System.Data.SqlClient.SqlParameter("@p_Broke_Disp_Normal", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.EOgengreaternormalbroke))
                {
                    paramIn[51].Value = DBNull.Value;
                }
                else
                {
                    paramIn[51].Value = objEO.EOgengreaternormalbroke;
                }

                //@p_Printer_Broke
                paramIn[52] = new System.Data.SqlClient.SqlParameter("@p_Printer_Broke", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PrintBroke))
                {
                    paramIn[52].Value = DBNull.Value;
                }
                else
                {
                    paramIn[52].Value = objEO.PrintBroke;
                }

                //@p_Ink_Coverage
                paramIn[53] = new System.Data.SqlClient.SqlParameter("@p_Ink_Coverage", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PrintBrokeYesOption))
                {
                    paramIn[53].Value = DBNull.Value;
                }
                else
                {
                    paramIn[53].Value = objEO.PrintBrokeYesOption;
                }

                //@p_PDI_Lab_Notebook_Number
                paramIn[54] = new System.Data.SqlClient.SqlParameter("@p_PDI_Lab_Notebook_Number", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.LabNoteBook))
                {
                    paramIn[54].Value = DBNull.Value;
                }
                else
                {
                    paramIn[54].Value = objEO.LabNoteBook;
                }

                //@p_PDI_Attachments
                paramIn[55] = new System.Data.SqlClient.SqlParameter("@p_PDI_Attachments", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.AdditionalItems))
                {
                    paramIn[55].Value = DBNull.Value;
                }
                else
                {
                    paramIn[55].Value = objEO.AdditionalItems;
                }

                // '@p_Approval_Group_ID
                paramIn[56] = new System.Data.SqlClient.SqlParameter("@p_Approval_Group_ID", SqlDbType.Int);
                paramIn[56].Value = objEO.ApprovalGroup;

                //@p_FuncID_App_Name_List need to send	
                paramIn[57] = new System.Data.SqlClient.SqlParameter("@p_FuncName_App_Name_List", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.FuncIDAppNameList))
                {
                    paramIn[57].Value = DBNull.Value;
                }
                else
                {
                    paramIn[57].Value = objEO.FuncIDAppNameList;
                }

                //@p_Suggested_Budget_Center_Name
                paramIn[58] = new System.Data.SqlClient.SqlParameter("@p_Suggested_Budget_Center_Name", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.SelectedBudgCenter))
                {
                    paramIn[58].Value = DBNull.Value;
                }
                else
                {
                    paramIn[58].Value = objEO.SelectedBudgCenter;
                }

                //@p_PSRA_Additional_Info
                paramIn[59] = new System.Data.SqlClient.SqlParameter("@p_PSRA_Additional_Info", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PSRAAdditionalInfo))
                {
                    paramIn[59].Value = DBNull.Value;
                }
                else
                {
                    paramIn[59].Value = objEO.PSRAAdditionalInfo;
                }

                //@p_PDI_Comments	
                paramIn[60] = new System.Data.SqlClient.SqlParameter("@p_PDI_Comments", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.PrevComments))
                {
                    paramIn[60].Value = DBNull.Value;
                }
                else
                {
                    paramIn[60].Value = objEO.PrevComments;
                }

                //@p_IGCAS_Number	
                paramIn[61] = new System.Data.SqlClient.SqlParameter("@p_IGCAS_Number", SqlDbType.VarChar);
                if (string.IsNullOrEmpty(objEO.IGCASNumber))
                {
                    paramIn[61].Value = DBNull.Value;
                }
                else
                {
                    paramIn[61].Value = objEO.IGCASNumber;
                }

                paramIn[62] = new System.Data.SqlClient.SqlParameter("@p_Is_Understood_Policy_37", SqlDbType.Bit);

                if (objEO.ProdSelectIs_Understood_Policy_37 == true)
                {
                    paramIn[62].Value = 0;
                }
                else
                {
                    paramIn[62].Value = 1;
                }

                //@p_Is_Exception_Policy_37
                paramIn[63] = new System.Data.SqlClient.SqlParameter("@p_Is_Exception_Policy_37", SqlDbType.Bit);

                if (objEO.ProdSelectIs_Exception_Policy_37 == true)
                {
                    paramIn[63].Value = 0;
                }
                else
                {
                    paramIn[63].Value = 1;
                }

                //@p_Is_EO_Covered_Policy_37
                paramIn[64] = new System.Data.SqlClient.SqlParameter("@p_Is_EO_Covered_Policy_37", SqlDbType.Bit);

                if (objEO.ProdSelectIs_EO_Covered_Policy_37 == true)
                {
                    paramIn[64].Value = 0;
                }
                else
                {
                    paramIn[64].Value = 1;
                }

                //@p_Is_Product_Go_To_Customers
                paramIn[65] = new System.Data.SqlClient.SqlParameter("@p_Is_Product_Go_To_Customers", SqlDbType.Bit);

                if (objEO.Is_Product_Go_To_Customers == true)
                {
                    paramIn[65].Value = 1;
                }
                else
                {
                    paramIn[65].Value = 0;
                }

                if (objEO.Is_Product_Go_To_CustomersNull == "NULL")
                {
                    paramIn[65].Value = DBNull.Value;
                }

                //@p_Is_Using_Approved_FC_R_ATS
                paramIn[66] = new System.Data.SqlClient.SqlParameter("@p_Is_Using_Approved_FC_R_ATS", SqlDbType.Bit);

                if (objEO.Is_Using_Approved_FC_R_ATS == true)
                {
                    paramIn[66].Value = 1;
                }
                else
                {
                    paramIn[66].Value = 0;
                }

                if (objEO.Is_Using_Approved_FC_R_ATSNull == "NULL")
                {
                    paramIn[66].Value = DBNull.Value;
                }

                //@p_Is_Approved_At_Level
                paramIn[67] = new System.Data.SqlClient.SqlParameter("@p_Is_Approved_At_Level", SqlDbType.Bit);

                if (objEO.Is_Approved_At_Level == true)
                {
                    paramIn[67].Value = 1;
                }
                else if (objEO.Is_Approved_At_Level == false)
                {
                    paramIn[67].Value = 0;
                }
                else
                {
                    //paramIn[67).Value = DBNull.Value

                }
                if (objEO.Is_Approved_At_LevelNull == "NULL")
                {
                    paramIn[67].Value = DBNull.Value;
                }

                //@p_Is_Approved_For_Region
                paramIn[68] = new System.Data.SqlClient.SqlParameter("@p_Is_Approved_For_Region", SqlDbType.Bit);


                if (objEO.Is_Approved_For_Region == true)
                {
                    paramIn[68].Value = 1;


                }
                else if (objEO.Is_Approved_For_Region == false)
                {
                    paramIn[68].Value = 0;

                }
                else
                {
                    //paramIn[68).Value = DBNull.Value

                }
                if (objEO.Is_Approved_At_RegionNull == "NULL")
                {
                    paramIn[68].Value = DBNull.Value;
                }

                //@p_Is_Approved_For_Application
                paramIn[69] = new System.Data.SqlClient.SqlParameter("@p_Is_Approved_For_Application", SqlDbType.Bit);

                if (objEO.Is_Approved_For_Application == true)
                {
                    paramIn[69].Value = 1;
                }
                else if (objEO.Is_Approved_For_Application == false)
                {
                    paramIn[69].Value = 0;
                }
                else
                {
                    //paramIn[69).Value = DBNull.Value
                }

                if (objEO.Is_Approved_At_ApplicationNull == "NULL")
                {
                    paramIn[69].Value = DBNull.Value;
                }

                //@p_Is_Approved_At_Prev_Application_Rate
                paramIn[70] = new System.Data.SqlClient.SqlParameter("@p_Is_Approved_At_Prev_Application_Rate", SqlDbType.Bit);

                if (objEO.Is_Approved_At_Prev_Application_Rate == true)
                {
                    paramIn[70].Value = 1;
                }
                else if (objEO.Is_Approved_At_Prev_Application_Rate == false)
                {
                    paramIn[70].Value = 0;
                }
                else
                {
                    // paramIn[70).Value = DBNull.Value
                }
                if (objEO.Is_Approved_At_Application_RateNull == "NULL")
                {
                    paramIn[70].Value = DBNull.Value;
                }

                //@p_User_Name
                paramIn[71] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[71].Value = objEO.UserName;


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Preliminary", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Final(objEO objEO, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[57];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[0].Value = objEO.EOID;

                paramIn[1] = new SqlParameter("@p_Budget_Center_ID", objEO.BudgetCenterFinal);


                if (objEO.NewChemicalChange == "")
                    paramIn[2] = new SqlParameter("@p_New_Chemical_Change", DBNull.Value);
                else
                    paramIn[2] = new SqlParameter("@p_New_Chemical_Change", objEO.NewChemicalChange);

                if (objEO.NewRawMaterialChange == "")
                    paramIn[3] = new SqlParameter("@p_New_RawMaterial_Change", DBNull.Value);
                else
                    paramIn[3] = new SqlParameter("@p_New_RawMaterial_Change", objEO.NewRawMaterialChange);

                if (objEO.ProductPack == "")
                    paramIn[4] = new SqlParameter("@p_Prod_Pack_ID_List", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_Prod_Pack_ID_List", objEO.ProductPack);

                if (objEO.CurrentPackage == "")
                    paramIn[5] = new SqlParameter("@p_Current_Packaging", DBNull.Value);
                else
                    paramIn[5] = new SqlParameter("@p_Current_Packaging", objEO.CurrentPackage);

                if (objEO.CurrentPackagingType == "")
                    paramIn[6] = new SqlParameter("@p_Packaging_Type", DBNull.Value);
                else
                    paramIn[6] = new SqlParameter("@p_Packaging_Type", objEO.CurrentPackagingType);


                if (objEO.ExperimentPackage == "")
                    paramIn[7] = new SqlParameter("@p_Experimental_Packaging", DBNull.Value);
                else
                    paramIn[7] = new SqlParameter("@p_Experimental_Packaging", objEO.ExperimentPackage);

                if (objEO.ClearPolyFinal == "")
                    paramIn[8] = new SqlParameter("@p_Exp_Pack_Clear_Poly", DBNull.Value);
                else
                    paramIn[8] = new SqlParameter("@p_Exp_Pack_Clear_Poly", objEO.ClearPolyFinal);

                if (objEO.BlankKDFFinal == "")
                    paramIn[9] = new SqlParameter("@p_Exp_Pack_Blank_KDF", DBNull.Value);
                else
                    paramIn[9] = new SqlParameter("@p_Exp_Pack_Blank_KDF", objEO.BlankKDFFinal);

                paramIn[10] = new SqlParameter("@p_Prod_Disp_ID", objEO.ProdDispoID);

                if (objEO.OtherProdDispo == "")
                    paramIn[11] = new SqlParameter("@p_Prod_Disp_Add_Comments", DBNull.Value);
                else
                    paramIn[11] = new SqlParameter("@p_Prod_Disp_Add_Comments", objEO.OtherProdDispo);

                if (objEO.EOUniquePalletPaerns == "")
                    paramIn[12] = new SqlParameter("@p_Pallet_Patter_SKU", DBNull.Value);
                else
                    paramIn[12] = new SqlParameter("@p_Pallet_Patter_SKU", objEO.EOUniquePalletPaerns);

                if (objEO.EOUniqPaletPatStackTesing == "")
                    paramIn[13] = new SqlParameter("@p_Stack_Testing", DBNull.Value);
                else
                    paramIn[13] = new SqlParameter("@p_Stack_Testing", objEO.EOUniqPaletPatStackTesing);

                if (objEO.EOUniqPaletPatShipTesing == "")
                    paramIn[14] = new SqlParameter("@p_Ship_Testing", DBNull.Value);
                else
                    paramIn[14] = new SqlParameter("@p_Ship_Testing", objEO.EOUniqPaletPatShipTesing);

                paramIn[15] = new SqlParameter("@p_Material_Disposition_ID", objEO.MaterialDispostion);

                if (objEO.MaterialDispoAddCommnets == "")
                    paramIn[16] = new SqlParameter("@p_Mat_Disp_Add_Comments", DBNull.Value);
                else
                    paramIn[16] = new SqlParameter("@p_Mat_Disp_Add_Comments", objEO.MaterialDispoAddCommnets);

                if (objEO.EOGraterNormalBroke == "")
                    paramIn[17] = new SqlParameter("@p_Broke_Disp_Normal", DBNull.Value);
                else
                    paramIn[17] = new SqlParameter("@p_Broke_Disp_Normal", objEO.EOGraterNormalBroke);

                if (objEO.EOPrintedBroke == "")
                    paramIn[18] = new SqlParameter("@p_Printer_Broke", DBNull.Value);
                else
                    paramIn[18] = new SqlParameter("@p_Printer_Broke", objEO.EOPrintedBroke);

                if (objEO.EOPrintedBrokeIncCov == "")
                    paramIn[19] = new SqlParameter("@p_Ink_Coverage", DBNull.Value);
                else
                    paramIn[19] = new SqlParameter("@p_Ink_Coverage", objEO.EOPrintedBrokeIncCov);

                if (objEO.PDILabNotebookNumber == "")
                    paramIn[20] = new SqlParameter("@p_PDI_Lab_Notebook_Number", DBNull.Value);
                else
                    paramIn[20] = new SqlParameter("@p_PDI_Lab_Notebook_Number", objEO.PDILabNotebookNumber);

                if (objEO.PDIAttachment == "")
                    paramIn[21] = new SqlParameter("@p_PDI_Attachment", DBNull.Value);
                else
                    paramIn[21] = new SqlParameter("@p_PDI_Attachment", objEO.PDIAttachment);

                paramIn[22] = new SqlParameter("@p_Amount_Preliminary_Stage", objEO.EstmAmtCostSheet);

                if (objEO.TotDiffCostSheet == "")
                    paramIn[23] = new SqlParameter("@p_Total_Cost_Diff", DBNull.Value);
                else
                    paramIn[23] = new SqlParameter("@p_Total_Cost_Diff", objEO.TotDiffCostSheet);

                paramIn[24] = new SqlParameter("@p_Cost_Cost_Sheet", objEO.TotDiffCostSheetYesOpt);

                if (objEO.AddCommnetsCostSheet == "")
                    paramIn[25] = new SqlParameter("@p_CS_Comments", DBNull.Value);
                else
                    paramIn[25] = new SqlParameter("@p_CS_Comments", objEO.AddCommnetsCostSheet);

                if (objEO.AttaCostSheet == "")
                    paramIn[26] = new SqlParameter("@p_CS_Attachments", DBNull.Value);
                else
                    paramIn[26] = new SqlParameter("@p_CS_Attachments", objEO.AttaCostSheet);


                if (objEO.EOFormulaCardInformation == "")
                    paramIn[27] = new SqlParameter("@p_Formula_Card_Info", DBNull.Value);
                else
                    paramIn[27] = new SqlParameter("@p_Formula_Card_Info", objEO.EOFormulaCardInformation);

                if (objEO.AttachFormulaCard == "")
                    paramIn[28] = new SqlParameter("@p_FC_Attachment", DBNull.Value);
                else
                    paramIn[28] = new SqlParameter("@p_FC_Attachment", objEO.AttachFormulaCard);

                if (objEO.TestPlantAttachments == "")
                    paramIn[29] = new SqlParameter("@p_TP_Attachment", DBNull.Value);
                else
                    paramIn[29] = new SqlParameter("@p_TP_Attachment", objEO.TestPlantAttachments);

                if (objEO.CentralAnalyticalLab == "")
                    paramIn[30] = new SqlParameter("@p_Central_Analytical_Lab", DBNull.Value);
                else
                    paramIn[30] = new SqlParameter("@p_Central_Analytical_Lab", objEO.CentralAnalyticalLab);

                if (objEO.SiteTestingLab == "")
                    paramIn[31] = new SqlParameter("@p_Site_Testing_Lab", DBNull.Value);
                else
                    paramIn[31] = new SqlParameter("@p_Site_Testing_Lab", objEO.SiteTestingLab);

                if (objEO.AttchLabforTesting == "")
                    paramIn[32] = new SqlParameter("@p_LS_Attachment", DBNull.Value);
                else
                    paramIn[32] = new SqlParameter("@p_LS_Attachment", objEO.AttchLabforTesting);

                if (objEO.ProdDetailTest == "")
                    paramIn[33] = new SqlParameter("@p_PTF_Attachment", DBNull.Value);
                else
                    paramIn[33] = new SqlParameter("@p_PTF_Attachment", objEO.ProdDetailTest);

                if (objEO.Comments == "")
                    paramIn[34] = new SqlParameter("@p_Comments_Approvers", DBNull.Value);
                else
                    paramIn[34] = new SqlParameter("@p_Comments_Approvers", objEO.Comments);

                if (objEO.OtherSupAttach == "")
                    paramIn[35] = new SqlParameter("@p_OD_Attachment", DBNull.Value);
                else
                    paramIn[35] = new SqlParameter("@p_OD_Attachment", objEO.OtherSupAttach);

                paramIn[36] = new SqlParameter("@p_Approval_Group_ID", objEO.AppGrp);

                if (objEO.FuncIDAppNameListFinal == "")
                    paramIn[37] = new SqlParameter("@p_FuncName_App_Name_List", DBNull.Value);
                else
                    paramIn[37] = new SqlParameter("@p_FuncName_App_Name_List", objEO.FuncIDAppNameListFinal);

                paramIn[38] = new SqlParameter("@p_Current_Stage", objEO.FinalCurrentStagePre);
                paramIn[39] = new SqlParameter("@p_Stage_Status", objEO.FinalStageStatus);
                paramIn[40] = new SqlParameter("@p_QA_Info_Attachment", objEO.FinalAttachQA);

                paramIn[41] = new SqlParameter("@p_Raw_Pack_Mat", objEO.NewRawPackageFinal);
                paramIn[42] = new SqlParameter("@p_Parent_Rolls", objEO.ParentRollsFinal);
                paramIn[43] = new SqlParameter("@p_Intermediate_Mat", objEO.InterMaterialFinal);

                paramIn[44] = new SqlParameter("@p_Current_Brand", objEO.CurrentBrandFinal);
                paramIn[45] = new SqlParameter("@p_Cons_Lab_Eval", objEO.ConsLabEvalFinal);
                paramIn[46] = new SqlParameter("@p_GCAS", objEO.GCASFinal);
                if (objEO.ProdSelectIs_Understood_Policy_37Final == true)
                    paramIn[47] = new SqlParameter("@p_Is_Understood_Policy_37", true);
                else
                    paramIn[47] = new SqlParameter("@p_Is_Understood_Policy_37", false);

                if (objEO.ProdSelectIs_Exception_Policy_37Final == true)
                    paramIn[48] = new SqlParameter("@p_Is_Exception_Policy_37", true);
                else
                    paramIn[48] = new SqlParameter("@p_Is_Exception_Policy_37", false);

                if (objEO.ProdSelectIs_EO_Covered_Policy_37Final == true)
                    paramIn[49] = new SqlParameter("@p_Is_EO_Covered_Policy_37", true);
                else
                    paramIn[49] = new SqlParameter("@p_Is_EO_Covered_Policy_37", false);

                if (objEO.Is_Product_Go_To_CustomersFinal == true)
                    paramIn[50] = new SqlParameter("@p_Is_Product_Go_To_Customers", true);
                else
                    paramIn[50] = new SqlParameter("@p_Is_Product_Go_To_Customers", false);

                if (objEO.Is_Product_Go_To_CustomersFinal.ToString() == "NULL")
                    paramIn[50] = new SqlParameter("@p_Is_Product_Go_To_Customers", DBNull.Value);

                if (objEO.Is_Using_Approved_FC_R_ATSFinal == true)
                    paramIn[51] = new SqlParameter("@p_Is_Using_Approved_FC_R_ATS", true);
                else
                    paramIn[51] = new SqlParameter("@p_Is_Using_Approved_FC_R_ATS", false);

                if (objEO.Is_Using_Approved_FC_R_ATSFinal.ToString() == "NULL")
                    paramIn[51] = new SqlParameter("@p_Is_Using_Approved_FC_R_ATS", DBNull.Value);



                if (objEO.Is_Approved_At_LevelFinal == true)
                    paramIn[52] = new SqlParameter("@p_Is_Approved_At_Level", true);
                else if (objEO.Is_Approved_At_LevelFinal == false)
                    paramIn[52] = new SqlParameter("@p_Is_Approved_At_Level", false);
                else if (objEO.Is_Approved_At_LevelFinal.ToString() == "NULL")
                    paramIn[52] = new SqlParameter("@p_Is_Approved_At_Level", DBNull.Value);

                if (objEO.Is_Approved_For_RegionFinal == true)
                    paramIn[53] = new SqlParameter("@p_Is_Approved_For_Region", true);
                else if (objEO.Is_Approved_For_RegionFinal == false)
                    paramIn[53] = new SqlParameter("@p_Is_Approved_For_Region", false);
                else if (objEO.Is_Approved_For_RegionFinal.ToString() == "NULL")
                    paramIn[53] = new SqlParameter("@p_Is_Approved_For_Region", DBNull.Value);

                if (objEO.Is_Approved_For_ApplicationFinal == true)
                    paramIn[54] = new SqlParameter("@p_Is_Approved_For_Application", true);
                else if (objEO.Is_Approved_For_ApplicationFinal == false)
                    paramIn[54] = new SqlParameter("@p_Is_Approved_For_Application", false);
                else if (objEO.Is_Approved_For_ApplicationFinal.ToString() == "NULL")
                    paramIn[54] = new SqlParameter("@p_Is_Approved_For_Application", DBNull.Value);


                if (objEO.Is_Approved_At_Prev_Application_RateFinal == true)
                    paramIn[55] = new SqlParameter("@p_Is_Approved_At_Prev_Application_Rate", true);
                else if (objEO.Is_Approved_At_Prev_Application_RateFinal == false)
                    paramIn[55] = new SqlParameter("@p_Is_Approved_At_Prev_Application_Rate", false);
                else if (objEO.Is_Approved_At_Prev_Application_RateFinal.ToString() == "NULL")
                    paramIn[55] = new SqlParameter("@p_Is_Approved_At_Prev_Application_Rate", DBNull.Value);

                paramIn[56] = new SqlParameter("@p_User_Name", objEO.UserName);

                //out

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Final", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Closeout(objEO objEO, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[20];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", objEO.EOID);

                if (objEO.LabNoteBookCO == "")
                    paramIn[1] = new SqlParameter("@p_Lab_NoteBook_Num", DBNull.Value);
                else
                    paramIn[1] = new SqlParameter("@p_Lab_NoteBook_Num", objEO.LabNoteBookCO);

                if (objEO.CompletionDate == DateTime.MinValue)
                    paramIn[2] = new SqlParameter("@p_Completion_Date", DBNull.Value);
                else
                    paramIn[2] = new SqlParameter("@p_Completion_Date", objEO.CompletionDate);

                if (objEO.AttFinalCostSheetCO == "")
                    paramIn[3] = new SqlParameter("@p_AC_Attachment", DBNull.Value);
                else
                    paramIn[3] = new SqlParameter("@p_AC_Attachment", objEO.AttFinalCostSheetCO);

                if (objEO.TotCostSheetCO.ToString() == "")
                    paramIn[4] = new SqlParameter("@p_Total_CostSheet", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_Total_CostSheet", objEO.TotCostSheetCO);

                if (objEO.AttCOILR == "")
                    paramIn[5] = new SqlParameter("@p_ILR_Attachment", DBNull.Value);
                else
                    paramIn[5] = new SqlParameter("@p_ILR_Attachment", objEO.AttCOILR);

                if (objEO.AttchTestPlanTepmpalteCO == "")
                    paramIn[6] = new SqlParameter("@p_TP_Attachment", DBNull.Value);
                else
                    paramIn[6] = new SqlParameter("@p_TP_Attachment", objEO.AttchTestPlanTepmpalteCO);

                if (objEO.KeyWords1CO == "")
                    paramIn[7] = new SqlParameter("@p_Keyword1", DBNull.Value);
                else
                    paramIn[7] = new SqlParameter("@p_Keyword1", objEO.KeyWords1CO);

                if (objEO.KeyWords2CO == "")
                    paramIn[8] = new SqlParameter("@p_Keyword2", DBNull.Value);
                else
                    paramIn[8] = new SqlParameter("@p_Keyword2", objEO.KeyWords2CO);

                if (objEO.KeyWords3CO == "")
                    paramIn[9] = new SqlParameter("@p_Keyword3", DBNull.Value);
                else
                    paramIn[9] = new SqlParameter("@p_Keyword3", objEO.KeyWords3CO);

                if (objEO.KeyWords4CO == "")
                    paramIn[10] = new SqlParameter("@p_Keyword4", DBNull.Value);
                else
                    paramIn[10] = new SqlParameter("@p_Keyword4", objEO.KeyWords4CO);

                if (objEO.KeyWords5CO == "")
                    paramIn[11] = new SqlParameter("@p_Keyword5", DBNull.Value);
                else
                    paramIn[11] = new SqlParameter("@p_Keyword5", objEO.KeyWords5CO);

                if (objEO.KeyWords6CO == "")
                    paramIn[12] = new SqlParameter("@p_Keyword6", DBNull.Value);
                else
                    paramIn[12] = new SqlParameter("@p_Keyword6", objEO.KeyWords6CO);

                if (objEO.CommentsApproverCO == "")
                    paramIn[13] = new SqlParameter("@p_Comments_Approver", DBNull.Value);
                else
                    paramIn[13] = new SqlParameter("@p_Comments_Approver", objEO.CommentsApproverCO);

                paramIn[14] = new SqlParameter("@p_Approval_Group_ID", objEO.AppGroupCloseOut);

                if (objEO.FuncIDAppNameListCloseOut == "")
                    paramIn[15] = new SqlParameter("@p_FuncName_App_Name_List", DBNull.Value);
                else
                    paramIn[15] = new SqlParameter("@p_FuncName_App_Name_List", objEO.FuncIDAppNameListCloseOut);

                if (objEO.CloseOutCurrentStage == "")
                    paramIn[16] = new SqlParameter("@p_Current_Stage", DBNull.Value);
                else
                    paramIn[16] = new SqlParameter("@p_Current_Stage", objEO.CloseOutCurrentStage);

                if (objEO.CloseOutStageStatus == "")
                    paramIn[17] = new SqlParameter("@p_Stage_Status", DBNull.Value);
                else
                    paramIn[17] = new SqlParameter("@p_Stage_Status", objEO.CloseOutStageStatus);

                if (objEO.AttCOReport == "")
                    paramIn[18] = new SqlParameter("@p_CRA_Attachment", DBNull.Value);
                else
                    paramIn[18] = new SqlParameter("@p_CRA_Attachment", objEO.AttCOReport);

                paramIn[19] = new SqlParameter("@p_User_Name", objEO.UserName);
                //out
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Closeout", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Lock_Release_User(int p_EO_ID, string username)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID_String", p_EO_ID);
                paramIn[1] = new SqlParameter("@p_User_Name", username);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryExecuteNonQuery("SET_EO_Lock_Release_User", paramIn)))
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

        public bool DeleteGCSANo(int GCAS_ID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_GCAS_ID", GCAS_ID);
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("Delete_EO_GCASNo", paramIn, ref paramOut, true)))
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

        public bool DeletePSRANo(int p_PSRA_Info_ID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_PSRA_Info_ID", p_PSRA_Info_ID);
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("Delete_EO_PSRANo", paramIn, ref paramOut, true)))
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

        public bool SET_EO_DELETE_Upon_EDIT(int parEOID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", parEOID);
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Delete_Upon_Error", paramIn, ref paramOut, true)))
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

        public bool DeleteCommonAttachments(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", EoID);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_IDs", attchIDs);
                paramIn[3] = new SqlParameter("@p_Attachment_File_Name", DBNull.Value);
                paramIn[4] = new SqlParameter("@p_Attachment_Type", DBNull.Value);
                paramIn[5] = new SqlParameter("@p_Attachment", DBNull.Value);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Preliminary_Attachment", paramIn, ref paramOut, true)))
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

        public bool DeleteCommonAttachmentsFinal(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", EoID);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_IDs", attchIDs);
                paramIn[3] = new SqlParameter("@p_Attachment_File_Name", DBNull.Value);
                paramIn[4] = new SqlParameter("@p_Attachment_Type", DBNull.Value);
                paramIn[5] = new SqlParameter("@p_Attachment", DBNull.Value);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Final_Attachment", paramIn, ref paramOut, true)))
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

        public bool DeleteCommonAttachmentsCloseOut(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", EoID);
                paramIn[1] = new SqlParameter("@p_Section_Name", sectionName);
                paramIn[2] = new SqlParameter("@p_Attachment_IDs", attchIDs);
                paramIn[3] = new SqlParameter("@p_Attachment_File_Name", DBNull.Value);
                paramIn[4] = new SqlParameter("@p_Attachment_Type", DBNull.Value);
                paramIn[5] = new SqlParameter("@p_Attachment", DBNull.Value);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_CloseOut_Attachment", paramIn, ref paramOut, true)))
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

        public bool SetEOEvenMerge(Int32 p_EO_ID)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];

            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", p_EO_ID);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryExecuteNonQuery("SET_EO_Merge", paramIn)))
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

        public bool SET_MUR_Delete_Multiple_Events(string p_Event_IDs, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_Event_IDs", p_Event_IDs);
                paramIn[1] = new SqlParameter("@p_User_Name", strUserName);
                paramOut[0] = new SqlParameter("@p_R_OUT", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Delete_Multiple_Events", paramIn, ref paramOut, true)))
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

        public bool SetApprovarStatus(int parEOID, string parStage, string parFunctionName, string parApprovarName, char parApprovarStatus, string parBackupApprovarName, ref DataSet objDS, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", parEOID);
                if (parStage == "")
                    paramIn[1] = new SqlParameter("@p_Stage", DBNull.Value);
                else
                    paramIn[1] = new SqlParameter("@p_Stage", parStage);

                if (parFunctionName == "")
                    paramIn[2] = new SqlParameter("@p_Function_Name", DBNull.Value);
                else
                    paramIn[2] = new SqlParameter("@p_Function_Name", parFunctionName);

                if (parApprovarName == "")
                    paramIn[3] = new SqlParameter("@p_Approver_Name", DBNull.Value);
                else
                    paramIn[3] = new SqlParameter("@p_Approver_Name", parApprovarName);

                if (parApprovarStatus.ToString() == "")
                    paramIn[4] = new SqlParameter("@p_Is_Approved", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_Is_Approved", parApprovarStatus);

                if (parBackupApprovarName.ToString() == "")
                    paramIn[5] = new SqlParameter("@p_Backup_Approver_Name", DBNull.Value);
                else
                    paramIn[5] = new SqlParameter("@p_Backup_Approver_Name", parBackupApprovarName);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if (objDBPool.SPQueryDatasetOutputParam("SET_EO_Approval_Status", paramIn, ref objDS, ref paramOut))
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

        public bool AddBackUpApprover(int conAppID, string BUapproverName)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_Con_App_ID", conAppID);
                paramIn[1] = new SqlParameter("@p_Backup_Approver_Name", BUapproverName);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryExecuteNonQuery("SET_Concurrence_Backup_Approver", paramIn)))
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

        public bool GetBudgetCenterDetailsDA(int Budget_Center_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Budget_Center_Id", Budget_Center_ID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Budget_Center", paramIn, ref objDS)))
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

        public bool FillEORegion(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //SqlParameter[] paramIn = null;
            try
            {
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_Region", ref objDS)))
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

        #endregion


        #region "David"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parEOID"></param>
        /// <param name="UserName"></param>
        /// <param name="paramOut"></param>
        /// <returns></returns>
        public bool GET_EO_Lock_Status_Approve(string parEOID, string UserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", parEOID);
                paramIn[1] = new SqlParameter("@p_User_Name", UserName);
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("GET_EO_Lock_Status_Approve", paramIn, ref paramOut, true)))
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

        public bool getEOComments(int EOID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.

                if ((objDBPool.SPQueryDataset("GET_EO_Comments", paramIn, ref objDS)))
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EOID"></param>
        /// <param name="stage"></param>
        /// <param name="paramOut"></param>
        /// <returns></returns>
        public bool GET_EO_Can_Route(int EOID, string stage, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[1] = new SqlParameter("@p_Stage", stage);
                paramOut[0] = new SqlParameter("@Route_YN", SqlDbType.Char);
                paramOut[0].Direction = ParameterDirection.Output;

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("GET_EO_Lock_Status_Approve", paramIn, ref paramOut, true)))
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

        public bool SET_SAP_IO_Number(int EOID, string parSAPIONum, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[1] = new SqlParameter("@p_SAP_No", parSAPIONum);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_SAP_IO_Number", paramIn, ref paramOut, true)))
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

        public bool SET_Smart_Clearance_Number(int EOID, string parSmartClearanceNum, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[1] = new SqlParameter("@p_SMART_Clearance_Number", parSmartClearanceNum);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_SMART_Clearance_Number", paramIn, ref paramOut, true)))
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



        public bool GET_EO_FYI_Recipient_Approvers(int p_Plant_ID, int p_Category_ID, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", p_Plant_ID);
                paramIn[1] = new SqlParameter("@p_User_Name", p_Category_ID);


                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("GET_EO_FYI_Recipient_Approvers", paramIn, ref paramOut, true)))
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

        public bool SET_EO_Stage(int EOID, string stage, string UserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[1] = new SqlParameter("@Current_Stage", stage);
                paramIn[2] = new SqlParameter("@p_User_Name", UserName);


                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Stage", paramIn, ref paramOut, true)))
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

        public bool addEOCommentsTest(int EOID, string comments, string user, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[1] = new SqlParameter("@p_Comment", comments);
                paramIn[2] = new SqlParameter("@p_User_Name", user);


                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_EO_Comments", paramIn, ref paramOut, true)))
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
        public bool GET_EO_Total_Cost(int intEOID, string strSatge, string strStageMoving, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[2];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", intEOID);
                paramIn[1] = new SqlParameter("@p_Stage", strSatge);
                paramIn[2] = new SqlParameter("@p_sStageMoving", strStageMoving);
                paramOut[0] = new SqlParameter("@p_dTotalCost", strStageMoving);
                paramOut[0].Direction = ParameterDirection.Output;



                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("GET_EO_Total_Cost", paramIn, ref paramOut, true)))
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

        public bool addingMailDetails(string Mail_From, string Mail_To_List, string Mail_CC_List, string Mail_BCC_List, string Mail_Subject, string Mail_Function_Name, string Mail_From_Machine)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];

            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Mail_From", Mail_From);
                paramIn[1] = new SqlParameter("@Mail_To_List", Mail_To_List);
                paramIn[2] = new SqlParameter("@Mail_CC_List", Mail_CC_List);
                paramIn[3] = new SqlParameter("@Mail_BCC_List", Mail_BCC_List);
                paramIn[4] = new SqlParameter("@Mail_Subject", Mail_Subject);
                paramIn[5] = new SqlParameter("@Mail_Function_Name", Mail_Function_Name);
                paramIn[6] = new SqlParameter("@Mail_From_Machine", Mail_From_Machine);






                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryExecuteNonQuery("dbo.SET_MUREO_Mail_Log", paramIn)))
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

        public bool AddConGrpNames(int ConAppID, int EOID, int ConGrpID, string parApprovarName, string IsResponded, string Comment, string UserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                DataSet objDs = null;
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_Con_App_ID", ConAppID);
                paramIn[1] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[2] = new SqlParameter("@p_Concurrence_Group_ID", ConGrpID);




                if (parApprovarName == "")
                    paramIn[3] = new SqlParameter("@p_Approver_Name", DBNull.Value);
                else
                    paramIn[3] = new SqlParameter("@p_Approver_Name", parApprovarName);

                if (IsResponded.ToString() == "")
                    paramIn[4] = new SqlParameter("@p_Is_Responded", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_Is_Responded", IsResponded);

                if (Comment.ToString() == "")
                    paramIn[5] = new SqlParameter("@p_Email_Sentence", DBNull.Value);
                else
                    paramIn[5] = new SqlParameter("@p_Email_Sentence", Comment);

                if (UserName.ToString() == "")
                    paramIn[6] = new SqlParameter("@p_User_Name", DBNull.Value);
                else
                    paramIn[6] = new SqlParameter("@p_User_Name", UserName);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if (objDBPool.SPQueryDatasetOutputParam("[dbo].SET_EO_Concurrence_Approvers", paramIn, ref objDs, ref paramOut))
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

        public bool setPrescreenStatus(int EOID, int ConAppID, string IsResponded, string Comment, string UserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[5];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                DataSet objDs = null;
                //SqlParameterCollection spc = null;

                paramIn[0] = new SqlParameter("@p_EO_ID", EOID);
                paramIn[1] = new SqlParameter("@p_Prescreener_ID", ConAppID);






                if (IsResponded.ToString() == "")
                    paramIn[2] = new SqlParameter("@p_Is_Responded", DBNull.Value);
                else
                    paramIn[2] = new SqlParameter("@p_Is_Responded", IsResponded);

                if (Comment.ToString() == "")
                    paramIn[3] = new SqlParameter("@p_Comments", DBNull.Value);
                else
                    paramIn[3] = new SqlParameter("@p_Comments", Comment);

                if (UserName.ToString() == "")
                    paramIn[4] = new SqlParameter("@p_User_Name", DBNull.Value);
                else
                    paramIn[4] = new SqlParameter("@p_User_Name", UserName);

                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                objDBPool = new DBPool();
                if (objDBPool.SPQueryDatasetOutputParam("[dbo].Update_Prescreener_Approvers_conformation", paramIn, ref objDs, ref paramOut))
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

        public bool GET_EO_Mail_Reminders(ref DataSet ds)
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
                if (objDBPool.SPQueryDatasetwithoutParameters("GET_EO_Comments", ref ds))
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



        public bool FillFuzzyDataGrid(string parSearchString, string parSortBy, int parLimit, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Search_Value", parSearchString);
                paramIn[1] = new SqlParameter("@p_Sort_By", parSortBy);
                paramIn[2] = new SqlParameter("@p_Row_Count", parLimit);



                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Search", paramIn, ref objDS)))
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
        //public static int setPrescreenStatus(objEO objeo)
        //{
        //    try
        //    {
        //        SqlClient.SqlParameter[,] sqlparams;
        //        DataSet ConGrp;
        //        sqlparams[0] = new SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
        //        sqlparams[0].Value = objeo.EOID;
        //        sqlparams[1] = new SqlClient.SqlParameter("@p_Prescreener_ID", SqlDbType.Int);
        //        sqlparams[1].Value = objeo.ConAppID;
        //        sqlparams[2] = new SqlClient.SqlParameter("@p_Is_Responded", SqlDbType.VarChar);
        //        sqlparams[2].Value = objeo.IsResponded;
        //        sqlparams[3] = new SqlClient.SqlParameter("@p_Comments", SqlDbType.VarChar);
        //        sqlparams[3].Value = objeo.Comment;
        //        sqlparams[4] = new SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
        //        sqlparams[4].Value = objeo.UserName;
        //        sqlparams[5] = new SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int);
        //        sqlparams[5].Direction = ParameterDirection.Output;
        //        sqlparams[5].Value = Convert.DBNull;
        //        DatabaseHelper.ExecuteNonQuery("[dbo].Update_Prescreener_Approvers_conformation", sqlparams);
        //        return sqlparams[5].Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool FillSearchDataGrid(string sqlText, string parSearchFor, string parProjName, string parEventName, string parProjLead, string parPlantName, string parEONumber, string parProjectDate, string parOrderBy, int parCount, string parSearchType, ref DataSet objDS)
        { //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[10];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                if (parSearchFor.ToString().Trim() == "")
                {
                    paramIn[0] = new SqlParameter("@SearchFor", DBNull.Value);
                }
                else
                    paramIn[0] = new SqlParameter("@SearchFor", parSearchFor);

                if (parProjName.ToString().Trim() == "")
                {
                    paramIn[1] = new SqlParameter("@ProjName", DBNull.Value);
                }
                else
                    paramIn[1] = new SqlParameter("@ProjName", parProjName);

                if (parEventName.ToString().Trim() == "")
                {
                    paramIn[2] = new SqlParameter("@EventName", DBNull.Value);
                }
                else
                    paramIn[2] = new SqlParameter("@EventName", parEventName);

                if (parProjLead.ToString().Trim() == "")
                {
                    paramIn[3] = new SqlParameter("@ProjLead", DBNull.Value);
                }
                else
                    paramIn[3] = new SqlParameter("@ProjLead", parProjLead);

                if (parPlantName.ToString().Trim() == "")
                {
                    paramIn[4] = new SqlParameter("@PlantName", DBNull.Value);
                }
                else
                    paramIn[4] = new SqlParameter("@PlantName", parPlantName);

                if (parEONumber.ToString().Trim() == "")
                {
                    paramIn[5] = new SqlParameter("@EONumber", DBNull.Value);
                }
                else
                    paramIn[5] = new SqlParameter("@EONumber", parEONumber);

                if (parProjectDate.ToString().Trim() == "")
                {
                    paramIn[6] = new SqlParameter("@ProjectCreateDate", DBNull.Value);
                }
                else
                    paramIn[6] = new SqlParameter("@ProjectCreateDate", parProjectDate);

                if (parOrderBy.ToString().Trim() == "")
                {
                    paramIn[7] = new SqlParameter("@OrderBy", DBNull.Value);
                }
                else
                    paramIn[7] = new SqlParameter("@OrderBy", parOrderBy);

                //if (parCount.ToString().Trim() == "")
                //{
                //    paramIn[8] = new SqlParameter("@TopCount", DBNull.Value);
                //}
                //else
                paramIn[8] = new SqlParameter("@TopCount", parCount);


                if (parSearchType.ToString().Trim() == "")
                {
                    paramIn[9] = new SqlParameter("@SearchType", DBNull.Value);
                }
                else
                    paramIn[9] = new SqlParameter("@SearchType", parSearchType);











                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("Static_Search", paramIn, ref objDS)))
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




        #endregion

        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;
        }
    }
}
