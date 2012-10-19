using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class PlantMachine
    {
        string m_strLastError = string.Empty;
        public bool GetPlantName(Int32 PlantID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objclsEvent = null;
            try
            {
                objclsEvent = new PlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetPlantName(PlantID, ref objDS))
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
        public bool EditMachineNameBO(int PlantID, string MachineName, Int32 intMachineID, ref SqlParameter[] resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objclsEvent = null;
            try
            {
                objclsEvent = new PlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.EditMachineNameDALC(PlantID, MachineName, intMachineID, ref resout))
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
        public bool AddMachineNames(int PlantID, string MachineName, ref SqlParameter[] resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objclsEvent = null;
            try
            {
                objclsEvent = new PlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.AddMachineNames(PlantID, MachineName,ref resout))
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
        public bool FillMachineNames(Int32 PlantID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objclsEvent = null;
            try
            {
                objclsEvent = new PlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillMachineNames(PlantID, ref objDS))
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
        public bool GetConPlantName(Int32 Concurrence_Group_Id, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objclsEvent = null;
            try
            {
                objclsEvent = new PlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetConPlantName(Concurrence_Group_Id, ref objDS))
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
        public bool FillPlantMachines(Int32 PlantID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PlantMachineDA objclsEvent = null;
            try
            {
                objclsEvent = new PlantMachineDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillPlantNames(PlantID, ref objDS))
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
