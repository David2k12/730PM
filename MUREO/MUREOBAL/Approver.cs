using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MUREODAL;

namespace MUREOBAL
{
    public class Approver
    {
        string m_strLastError = string.Empty;

        public bool FillEOFunctionBO(Int32 FunctionID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillEOFunctionDA(FunctionID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool FillEOApproversByFunctionBOMod(string FunctionName, Int32 PlantID, Int32 FunctionID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillEOApproversByFunctionDAMod(FunctionName, PlantID, FunctionID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetEOApproverBO(Int32 ApproverID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetEOApproverDA(ApproverID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool GetEOApprovalGroupOtherDetailsBO(Int32 Approval_Group_ID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetEOApprovalGroupOtherDetailsDA(Approval_Group_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool InsertEOApproverBO(int ApproverID, string ApproverName, int PlantID, int FunctionID, string UserName, char Status, ref SqlParameter[] resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.InsertEOApproverDA(ApproverID, ApproverName, PlantID, FunctionID, UserName, Status, ref resout))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool FillEOApprovalGroupDetailsBO(Int32 ApprovalGrpID,ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillEOApprovalGroupDetailsDA(ApprovalGrpID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool InsertEOApprovalGroupBO(int ApproverGroupID, string ApprovalGroupName, int BrandSegID, int PlantID, char EOMode, string ApproverList, char Status, string UserName, ref SqlParameter[] resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName, ref resout))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool FillEOAdditionalApprover1ByFunctionBO(Int32 Additional_Approver,ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillEOAdditionalApprover1ByFunctionDA(Additional_Approver,ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
 
        public bool FillEOApproversByFunctionBO(string FunctionName, Int32 PlantID, Int32 FunctionID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillEOApproversByFunctionDA(FunctionName, PlantID, FunctionID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillApproverPlantsBO(Int32 p_plant_ID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillApproverPlantsDA(p_plant_ID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool FillApprovalGroupCategorybyBrandBO(Int32 CategoryID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillApprovalGroupCategorybyBrandDA(CategoryID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        public bool FillApprovalGroupCategoryBO(Int32 CategoryID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            ApproverDA objclsEvent = null;
            try
            {
                objclsEvent = new ApproverDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillApprovalGroupCategoryDA(CategoryID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objclsEvent = null;
            }
            //Return the status here
            return bReturn;

        }
        ////
        ////  ************************************************
        ////Name   	    :	FillEOApprovalGroupNamesBO
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	none
        ////Purpose	    :   To get approval group name info
        ////Returns        :   Dataset containing approval group data
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-25-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet FillEOApprovalGroupNamesBO()
        //{
        //    return DataAccess.MUREO.DATA.Approver.FillEOApprovalGroupNamesDA();
        //}
        ////
        ////  ************************************************
        ////Name   	    :	FillEOApprovalGroupDetailsBO
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	none
        ////Purpose	    :   To get approval group details info
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-25-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet FillEOApprovalGroupDetailsBO(int ApprovalGrpID)
        //{
        //    return DataAccess.MUREO.DATA.Approver.FillEOApprovalGroupDetailsDA(ApprovalGrpID);
        //}
        ////
        ////  ************************************************
        ////Name   	    :	GetEOApproverDA
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	ApproverID
        ////Purpose	    :   To get approver info from db
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-26-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet GetEOApproverBO(ApproverID)
        //{
        //    return DataAccess.MUREO.DATA.Approver.GetEOApproverDA(ApproverID);
        //}
        ////
        ////  ************************************************
        ////Name   	    :	GetEOApprovalGroupOtherDetailsBO
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Approval_Group_ID
        ////Purpose	    :   To get brand segment, category and EO info from other master tables related to Approval Group
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-26-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet GetEOApprovalGroupOtherDetailsBO(int Approval_Group_ID)
        //{
        //    return DataAccess.MUREO.DATA.Approver.GetEOApprovalGroupOtherDetailsDA(Approval_Group_ID);
        //}
        ////
        ////  ************************************************
        ////Name   	    :	GetEOApprovalGroupBrandSegmentBO
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Brand_Segment_ID
        ////Purpose	    :   To get brand segment info related to Approval Group
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-26-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet GetEOApprovalGroupBrandSegmentBO(int Brand_Seg_ID)
        //{
        //    return DataAccess.MUREO.DATA.Approver.GetEOApprovalGroupBrandSegmentDA(Brand_Seg_ID);
        //}
        ////
        ////  ************************************************
        ////Name   	    :	GetEOApprovalGroupPlantDA
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Plant_ID
        ////Purpose	    :   To get plant info related to Approval Group
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-26-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet GetEOApprovalGroupPlantBO(int Plant_ID)
        //{
        //    return DataAccess.MUREO.DATA.Approver.GetEOApprovalGroupPlantDA(Plant_ID);
        //}
        ////
        ////  ************************************************
        ////Name   	    :	GetEOApprovalGroupNamesBO
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Plant_ID
        ////Purpose	    :   To get plant info related to Approval Group
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-26-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet GetEOApprovalGroupNamesBO()
        //{
        //    return DataAccess.MUREO.DATA.Approver.GetEOApprovalGroupNamesDA();
        //}
        ////
        ////  ************************************************
        ////Name   	    :	GetEOApprovalGroupApproversBO
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Approver_Group_Id
        ////Purpose	    :   To get approvers names for each approver group
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 07-26-07          Vijay Selvaganapathy                    Created
        ////***************************************************
        //public static DataSet GetEOApprovalGroupApproversBO(int Approver_Group_Id)
        //{
        //    return DataAccess.MUREO.DATA.Approver.GetEOApprovalGroupApproversDA(Approver_Group_Id);
        //}

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        