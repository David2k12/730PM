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
    public class PlantMachineBA
    {
        string m_strLastError;

        public bool FillPlantMachines(int PlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.FillPlantMachines(PlantID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetPlantName(int PlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.FillPlantMachines(PlantID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool GetConPlantName(int PlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.FillPlantMachines(PlantID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillMachineNames(int PlantID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.FillMachineNames(PlantID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool AddMachineNames(int PlantID, string MachineName, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.AddMachineNames(PlantID, MachineName, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        //public bool EditMachineNameDALC(int PlantID, string MachineName, int intMachineID, ref DataSet objDS)
        //{
        //    //This will be returned back.
        //    bool bReturn = false;
        //    //Init the data access layer object here
        //    PlantMachineDA objPlantMachineDA = new PlantMachineDA();
        //    try
        //    {
        //        //Call the data access function here
        //        if (objPlantMachineDA.EditMachineNameDALC(PlantID, MachineName,intMachineID, ref objDS))
        //            bReturn = true;
        //        else
        //            //Get the last error from DA class here.
        //            m_strLastError = objPlantMachineDA.GetLastError();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Set the error to this variable
        //        m_strLastError = ex.StackTrace;
        //    }
        //    finally
        //    { //Free objects here
        //        objPlantMachineDA = null;
        //    }
        //    //Return the status here
        //    return bReturn;
        //}

        public bool FillCategoryNames(ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.FillCategoryNames(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillConvertMachineNames(int PlantID, int CategoryID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.FillConvertMachineNames(PlantID, CategoryID, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool AddConvertMachineNames(int PlantID, int CategoryID, string MachineName, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.AddConvertMachineNames(PlantID, CategoryID, MachineName,ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }
        public bool UpdateConvertMachineNames(int PlantID, int CategoryID, string MachineName, int intMachineID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objPlantMachineDA = new PlantMachineDA();
            try
            {
                //Call the data access function here
                if (objPlantMachineDA.UpdateConvertMachineNames(PlantID, CategoryID, MachineName, intMachineID,ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objPlantMachineDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objPlantMachineDA = null;
            }
            //Return the status here
            return bReturn;
        }


    }
}
