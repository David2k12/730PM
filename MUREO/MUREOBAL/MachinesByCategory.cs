using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;

namespace MUREOBAL
{
    public class MachinesByCategory
    {
        string m_strLastError = string.Empty;
        public bool DeleteMachine(Int32 intMachineID, String strUserName, ref Int32 resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objclsEvent = null;
            try
            {
                objclsEvent = new MachinesByCategoryDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.DeleteMachine(intMachineID, strUserName,ref resout))
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
        public bool FillMachinesByCategory(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objclsEvent = null;
            try
            {
                objclsEvent = new MachinesByCategoryDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillMachinesByCategory(ref objDS))
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
        public bool FillMachinesByPlant(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objclsEvent = null;
            try
            {
                objclsEvent = new MachinesByCategoryDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillMachinesByPlant(ref objDS))
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
        public bool GetCategoryName(Int32 CategoryID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            MachinesByCategoryDA objclsEvent = null;
            try
            {
                objclsEvent = new MachinesByCategoryDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetCategoryName(CategoryID, ref objDS))
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
    }
}
