using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;
using MUREOPROP;

namespace MUREOBAL
{
    public class EOBA
    {
        string m_strLastError;

        public bool SET_EO_Lock_Release(string parEOID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Lock_Release(parEOID, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_Lock_Users(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.GET_EO_Lock_Users(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_Extract_Cost_Sheet_Data(string dtFromDate, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Extract_Cost_Sheet_Data(dtFromDate, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillDropDownWithBrands(int parCategoryid, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillDropDownWithBrands(parCategoryid, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillDropDownWithConvertingMachine(int parCategoryId, string parPlantId,ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillDropDownWithConvertingMachine(parCategoryId, parPlantId, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillDropDownWithPaperMachine(int parPlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillDropDownWithPaperMachine(parPlantID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FetchEONumbers(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.FetchEONumbers(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddPrescreenGrpNames(int EoID, int preScreneGrpId, string emailSentance, string userName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.AddPrescreenGrpNames(EoID, preScreneGrpId, emailSentance, userName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillPrescreneGroups(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.FillPrescreneGroups(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillConGroups(int PlantID, int ConGrpID,ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillConGroups(PlantID, ConGrpID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool SET_EO_FYI(int intFYIID,int intEOID ,string strApproverNames, string strcomments,ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_FYI(intFYIID, intEOID, strApproverNames, strcomments, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_FYI(int intEOID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_FYI(intEOID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Lock_Status(string parEOID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Lock_Status(parEOID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GETEOFunctionsApproverPlant(string strFunctionName, int PlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.GETEOFunctionsApproverPlant(strFunctionName, PlantID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GETEOFunctionsAdditionalApprover4Plant(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.GETEOFunctionsAdditionalApprover4Plant(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GETEOFunctionsAdditionalApprover3Plant(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.GETEOFunctionsAdditionalApprover3Plant(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GETEOFunctionsAdditionalApprover2Plant(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.GETEOFunctionsAdditionalApprover2Plant(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GETEOFunctionsAdditionalApprover1Plant(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.GETEOFunctionsAdditionalApprover1Plant(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillDropDownSeedData(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.FillDropDownSeedData(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillDropDownSeedData1(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.FillDropDownSeedData1(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillListBoxWithEventsByEoID(int p_Project_ID, int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillListBoxWithEventsByEoID(p_Project_ID, p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_MUR_Projects_By_Category_Brand_Segment(int p_Category_ID, string p_Brand_Segment_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_MUR_Projects_By_Category_Brand_Segment(p_Category_ID, p_Brand_Segment_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Approval_Groups_By_Plant_Brand_EOMode(int p_Plant_ID, string p_Brand_ID_List, char p_EOMode, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Approval_Groups_By_Plant_Brand_EOMode(p_Plant_ID, p_Brand_ID_List, p_EOMode, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetAttachmentsInfoCO(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GetAttachmentsInfoCO(intAttachmentID, EoId, sectionName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetAttachmentsInfo(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GetAttachmentsInfo(intAttachmentID, EoId, sectionName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetAttachmentsInfoFinal(int intAttachmentID, int EoId, string sectionName, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GetAttachmentsInfoFinal(intAttachmentID, EoId, sectionName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Is_Approved(int p_EO_ID, string p_Function_Name, string p_Approver_Name, string p_Stage, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Is_Approved(p_EO_ID, p_Function_Name, p_Approver_Name, p_Stage, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillListBoxWithBrands(string p_Category_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FillListBoxWithBrands(p_Category_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Data_Coordinator_By_Category(string p_Category_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Data_Coordinator_By_Category(p_Category_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_Budget_Centre_ID(int p_SO_ID, int Plant_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_Budget_Centre_ID(p_SO_ID, Plant_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Approval_Groups_Details(int p_Approval_Group_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Approval_Groups_Details(p_Approval_Group_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        //public bool GETGSRAData(int p_EO_ID, ref DataSet objDS)
        //{
        //    //This will be returned back.
        //    bool bReturn = false;
        //    //Init the data access layer object here
        //    EODA objEODA = new  EODA();
        //    try
        //    {
        //        //Call the data access function here
        //        if (objEODA.GETGSRAData(p_EO_ID, ref objDS))
        //            bReturn = true;
        //        else
        //            //Get the last error from DA class here.
        //            m_strLastError = objEODA.GetLastError();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Set the error to this variable
        //        m_strLastError = ex.StackTrace;
        //    }
        //    finally
        //    { //Free objects here
        //        objEODA = null;
        //    }
        //    //Return the status here
        //    return bReturn;
        //}

        public bool GET_EO_Final_Approvers_List(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Final_Approvers_List(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Preliminary(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Preliminary(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Final(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Final(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool getPreGroupUsers(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.getPreGroupUsers(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GETGSRAData(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GETGSRAData(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GETPSRAData(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GETPSRAData(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GET_EO_Closeout(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Closeout(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GETEOMandatory(int p_EO_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GETEOMandatory(p_EO_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FetchMigratedEventInfo(string p_Event_ID_List, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.FetchMigratedEventInfo(p_Event_ID_List, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GETEOSeedDataByEventIDs(string p_Event_IDs, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GETEOSeedDataByEventIDs(p_Event_IDs, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool UpdateGCASNo(int GCAS_ID, int GCAS_Material_Number, string GCAS_Site_Short_Name, char New_To_Site, char New_To_Category, char Intermediate, char Type_Developmental, char Type_Regulated, char Type_Contingent, char Type_Needs_Activation, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.UpdateGCASNo(GCAS_ID, GCAS_Material_Number, GCAS_Site_Short_Name, New_To_Site, New_To_Category, Intermediate, Type_Developmental, Type_Regulated, Type_Contingent, Type_Needs_Activation, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddGCASNo(int EO_ID, int GCAS_Material_Number, string GCAS_Site_Short_Name, char New_To_Site, char New_To_Category, char Intermediate, char Type_Developmental, char Type_Regulated, char Type_Contingent, char Type_Needs_Activation, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.AddGCASNo(EO_ID, GCAS_Material_Number, GCAS_Site_Short_Name, New_To_Site, New_To_Category, Intermediate, Type_Developmental, Type_Regulated, Type_Contingent, Type_Needs_Activation, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Check_And_Lock(int p_EO_ID, string Locked_By, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Check_And_Lock(p_EO_ID, Locked_By, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Delete_Upon_Error(int parEOID, char parMode, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Delete_Upon_Error(parEOID, parMode, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeleteGCSANo(int GCAS_ID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.DeleteGCSANo(GCAS_ID, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeletePSRANo(int PSRA_Info_ID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.DeletePSRANo(PSRA_Info_ID, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_DELETE_Upon_EDIT(int parEOID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_DELETE_Upon_EDIT(parEOID, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SubmitCommonAttachments(string fName, byte[] fContent, string sConType, int EoID, string sectionName, string SPName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SubmitCommonAttachments(fName, fContent, sConType, EoID, sectionName, SPName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SetEOMandatory(objEO objEO, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SetEOMandatory(objEO, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Preliminary(objEO objEO, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Preliminary(objEO, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Final(objEO objEO, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Final(objEO, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Closeout(objEO objEO, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Closeout(objEO, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Lock_Release_User(int p_EO_ID, string username)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Lock_Release_User(p_EO_ID, username))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddBackUpApprover(int conAppID, string BUapproverName)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.AddBackUpApprover(conAppID, BUapproverName))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SetApprovarStatus(int parEOID, string parStage, string parFunctionName, string parApprovarName, char parApprovarStatus, string parBackupApprovarName, ref DataSet objDS, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SetApprovarStatus(parEOID, parStage, parFunctionName, parApprovarName, parApprovarStatus, parBackupApprovarName, ref objDS, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddPSRANo(int EO_ID, string CT_Tracking_Number, string Supplier_Name, string Material_Application, string Material_Usage_Amount, string PSRA_Level, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.AddPSRANo(EO_ID, CT_Tracking_Number, Supplier_Name, Material_Application, Material_Usage_Amount, PSRA_Level, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool updatePSRANo(int PSRA_Info_ID, string CT_Tracking_Number, string Supplier_Name, string Material_Application, string Material_Usage_Amount, string PSRA_Level, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.updatePSRANo(PSRA_Info_ID, CT_Tracking_Number, Supplier_Name, Material_Application, Material_Usage_Amount, PSRA_Level, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeleteCommonAttachments(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.DeleteCommonAttachments(attchIDs, EoID, sectionName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeleteCommonAttachmentsFinal(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.DeleteCommonAttachmentsFinal(attchIDs, EoID, sectionName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeleteCommonAttachmentsCloseOut(string attchIDs, int EoID, string sectionName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.DeleteCommonAttachmentsCloseOut(attchIDs, EoID, sectionName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SetEOEvenMerge(Int32 p_EO_ID)
        {

            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SetEOEvenMerge(p_EO_ID))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool SET_MUR_Delete_Multiple_Events(string p_Event_IDs, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_MUR_Delete_Multiple_Events(p_Event_IDs, strUserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetBudgetCenterDetailsDA(int Budget_Center_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GetBudgetCenterDetailsDA(Budget_Center_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;
        }

        #region "Murali"
        public bool FillEORegion(ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                objEODA = new EODA();
                //Call the data access function here
                if (objEODA.FillEORegion(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
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
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Lock_Status_Approve(parEOID, UserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_FYI_Recipient_Approvers(int p_Plant_ID, int p_Category_ID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_FYI_Recipient_Approvers(p_Plant_ID, p_Category_ID, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }


        public bool SET_EO_Stage(int intEOID, string stage, string UserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_EO_Stage(intEOID,stage, UserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool addEOCommentsTest(int intEOID, string comments, string user, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.addEOCommentsTest(intEOID, comments, user, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }


        public bool getEOComments(int EOID, ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.getEOComments(EOID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_Mail_Reminders(ref DataSet ds)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Mail_Reminders(ref ds))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
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
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Can_Route(EOID, stage, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_SAP_IO_Number(int EOID, string parSAPIONum, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_SAP_IO_Number(EOID, parSAPIONum, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_Smart_Clearance_Number(int EOID, string parSmartClearanceNum, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.SET_Smart_Clearance_Number(EOID, parSmartClearanceNum, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_Total_Cost(int intEOID, string strSatge, string strStageMoving, ref SqlParameter[] paramOut)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.GET_EO_Total_Cost(intEOID, strSatge, strStageMoving, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool addingMailDetails(string Mail_From, string Mail_To_List, string Mail_CC_List, string Mail_BCC_List, string Mail_Subject, string Mail_Function_Name, string Mail_From_Machine)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.addingMailDetails(Mail_From, Mail_To_List, Mail_CC_List, Mail_BCC_List, Mail_Subject, Mail_Function_Name, Mail_From_Machine))
                    bReturn = true;
                else
                    //Get the last error from DA class here.)
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddConGrpNames(int ConAppID, int EOID, int ConGrpID, string parApprovarName, string IsResponded, string Comment, string UserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.AddConGrpNames(ConAppID,EOID, ConGrpID, parApprovarName, IsResponded,  Comment,  UserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.)
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool setPrescreenStatus(int EOID, int ConAppID, string IsResponded, string Comment, string UserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            EODA objEODA = new EODA();
            try
            {
                //Call the data access function here
                if (objEODA.setPrescreenStatus(EOID, ConAppID, IsResponded, Comment, UserName, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.)
                    m_strLastError = objEODA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        #endregion


    }
}
