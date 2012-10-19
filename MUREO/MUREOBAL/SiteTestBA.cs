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
    public class SiteTestBA
    {
        string m_strLastError;

        public bool GetMessage(int helpID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.GetMessage(helpID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool UpdateSiteTest(ObjSiteTest objSiteTestProp, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.UpdateSiteTest(objSiteTestProp, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddSiteTest(ObjSiteTest objSiteTestProp, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.AddSiteTest(objSiteTestProp, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SetEOMandatory(ObjSiteTest objEO, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.SetEOMandatory(objEO, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetAffectedMachine(int EventID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.GetAffectedMachine(EventID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillEquipment(int EquipID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.FillEquipment(EquipID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillSiteTest(int EquipID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.GetsiteTest(EquipID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetSitetestID(ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SiteTestDA objSiteTestDA = new SiteTestDA();
            try
            {
                //Call the data access function here
                if (objSiteTestDA.GetSitetestID(ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objSiteTestDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objSiteTestDA = null;
            }
            //Return the status here
            return bReturn;

        }

    }
}
