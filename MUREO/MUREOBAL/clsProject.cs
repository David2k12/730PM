using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsProject
    {
        string m_strLastError;
        bool bReturn = false;

        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;
        }

        public bool GetEventsCount(int projectID, ref SqlParameter[] paramOut)
        {
            //Init the data access layer object here
            MUREODAL.MURDAL objMurDal = new MUREODAL.MURDAL();

            try
            {
                //Call the data access function here
                if (objMurDal.GetEventsCountDAL(projectID, ref paramOut))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objMurDal.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objKeywordDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillHistoryofProject(string projectID, ref DataSet objds)
        {
            //Init the data access layer object here
            MUREODAL.MURDAL objMurDal = new MUREODAL.MURDAL();

            try
            {
                //Call the data access function here

                if (objMurDal.FillHistoryofProjectDAL(projectID, ref objds))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objMurDal.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objKeywordDA = null;
            }
            //Return the status here
            return bReturn;

        }
        //Generic Method takes parameters and returns dataset
        public bool FetchDataSetUsingSqlParameters(int projectID, ref DataSet objds, string SP_Name, string parameter)
        {
            //Init the data access layer object here
            MUREODAL.MURDAL objMurDal = new MUREODAL.MURDAL();

            try
            {
                //Call the data access function here
                if (objMurDal.FetchDataSetUsingSqlParametersDAL(projectID, ref objds, SP_Name, parameter))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objMurDal.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objMurDal = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool ProjectInsert(int intPrjID, int intPrjType, int intBrand, string strPrjName, string strLead, string strPOC, string strStatus, string strUser, ref SqlParameter[] paramOut)
        {
            //Init the data access layer object here
            MUREODAL.MURDAL objMurDal = new MUREODAL.MURDAL();

            try
            {
                //Call the data access function here
                if (objMurDal.ProjectInsertDAL(intPrjID, intPrjType, intBrand, strPrjName, strLead, strPOC, strStatus, strUser, ref paramOut))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objMurDal.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objKeywordDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetProjectID(string projectName, int BrandID, int intPrjTypeID, ref SqlParameter[] paramOut)
        {
            //Init the data access layer object here
            MUREODAL.MURDAL objMurDal = new MUREODAL.MURDAL();

            try
            {
                //Call the data access function here
                if (objMurDal.GetProjectIDDAL(projectName, BrandID, intPrjTypeID, ref paramOut))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objMurDal.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objKeywordDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool DeleteProject(int intPrjID, int intPrjType, int intBrand, string strPrjName, string strLead, string strPOC, string strStatus, string strUser, ref SqlParameter[] paramOut)
        {
            //Init the data access layer object here
            MUREODAL.MURDAL objMurDal = new MUREODAL.MURDAL();

            try
            {
                //Call the data access function here
                if (objMurDal.ProjectInsertDAL(intPrjID, intPrjType, intBrand, strPrjName, strLead, strPOC, strStatus, strUser, ref paramOut))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objMurDal.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objKeywordDA = null;
            }
            //Return the status here
            return bReturn;
        }


        public bool FillHistoryofProject(Int32 parProjectId, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsProjectDA objEODA = new clsProjectDA();
            try
            {
                //Call the data access function here
                if (objEODA.FillHistoryofProject(parProjectId, ref objDS))
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

        public bool FetchProjectDetails(Int32 parProjectId, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsProjectDA objEODA = new clsProjectDA();
            try
            {
                //Call the data access function here
                if (objEODA.FetchProjectDetails(parProjectId, ref objDS))
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

        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GetDr()
        //Written BY	    :	UdayaSri
        //parameters     :	ProjectID,weeks,User
        //Purpose	    :   To get Event Start Date
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //08/21/07                 Abdul             2.0           Modified where one of the parameters 
        //will now be days instead of Weeks i.e arparams(1)
        //***************************************************

        public bool EventStartDate(int intPrjID, string strWeeks, string strUser, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsProjectDA objEODA = null;
            DBPool objDBPool = null;
            try
            {
                objEODA = new clsProjectDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objEODA.EventStartDate(intPrjID, strWeeks, strUser,ref paramOut))
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
                objEODA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

    }
}
