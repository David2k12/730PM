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
    public class MachinesByCategoryBA
    {
        string m_strLastError;
        public bool FillMachinesByCategory(ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objMachinesByCategoryDA = new MachinesByCategoryDA();
            try
            {
                //Call the data access function here
                if (objMachinesByCategoryDA.FillMachinesByCategory(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objMachinesByCategoryDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objMachinesByCategoryDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool FillMachinesByPlant(ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objMachinesByCategoryDA = new MachinesByCategoryDA();
            try
            {
                //Call the data access function here
                if (objMachinesByCategoryDA.FillMachinesByPlant(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objMachinesByCategoryDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objMachinesByCategoryDA = null;
            }
            //Return the status here
            return bReturn;
        }

        public bool DeleteMachine(int intMachineID, string strUserName, ref Int32 objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objMachinesByCategoryDA = new MachinesByCategoryDA();
            try
            {
                //Call the data access function here
                if (objMachinesByCategoryDA.DeleteMachine(intMachineID,strUserName,ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objMachinesByCategoryDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objMachinesByCategoryDA = null;
            }
            //Return the status here
            return bReturn;
        }
    }
}
