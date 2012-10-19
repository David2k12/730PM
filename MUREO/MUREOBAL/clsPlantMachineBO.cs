using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsPlantMachineBO
    {
        string m_strLastError;

        public bool FillCategoryNames(ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.FillCategoryNames(ref objDS))
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
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillPlantNames(int intPlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.FillPlantNames(intPlantID, ref objDS))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetPlantName(int intPlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.GetPlantName(intPlantID, ref objDS))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GetConPlantName(int intconGrpID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.GetConPlantName(intconGrpID, ref objDS))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillMachineNames(int intPlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.FillMachineNames(intPlantID, ref objDS))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddMachineNames(int intPlantID, string MachineName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.AddMachineNames(intPlantID, MachineName, ref paramOut))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool EditMachineNameDALC(int intPlantID, string MachineName, int intMachineID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.EditMachineNameDALC(intPlantID, MachineName,intMachineID, ref paramOut))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool FillConvertMachineNames(int intPlantID, int intCategoryID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.FillConvertMachineNames(intPlantID,intCategoryID, ref objDS))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool AddConvertMachineNames(int PlantID, int intCategoryID, string MachineName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.AddConvertMachineNames(PlantID, intCategoryID, MachineName, ref paramOut))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }


        public bool UpdateConvertMachineNames(int PlantID, int intCategoryID, string MachineName, int intMachineID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsPlantMachineDA objclsPlantMachineDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsPlantMachineDA = new clsPlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsPlantMachineDA.UpdateConvertMachineNames(PlantID, intCategoryID, MachineName,intMachineID, ref paramOut))
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
                objDBPool = null;
                objclsPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
