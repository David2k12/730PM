using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class BudgetCtrBO
    {
        string m_strLastError = string.Empty;
        public bool FillEOBudgetAreaBO(Int32 p_Area_ID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            BudgetCtrDA objclsEvent = null;
            try
            {
                objclsEvent = new BudgetCtrDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillEOBudgetAreaDA(p_Area_ID, ref objDS))
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
        public bool GetBudgetCenterDetailsBO(Int32 Budget_Center_ID, ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            BudgetCtrDA objclsEvent = null;
            try
            {
                objclsEvent = new BudgetCtrDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.GetBudgetCenterDetailsDA(Budget_Center_ID, ref objDS))
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
        public bool InsertEOBudgetCenterBO(int Budget_Center_ID, string Budget_Center_Name, int Plant_ID, int Area_ID, string Towel_Appr_Name, string Bath_Appr_Name, string Tissue_Appr_Name, string Default_Appr_Name, string SAP_Cost_Coordinator_Appr_Name, string UserName, char Status, ref SqlParameter[] resout)
        {
            //return DataAccess.MUREO.DATA.Approver.InsertEOApprovalGroupDA(ApproverGroupID, ApprovalGroupName, BrandSegID, PlantID, EOMode, ApproverList, Status, UserName);

            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            BudgetCtrDA objclsEvent = null;
            try
            {
                objclsEvent = new BudgetCtrDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.InsertEOBudgetCenterDA(Budget_Center_ID, Budget_Center_Name, Plant_ID, Area_ID, Towel_Appr_Name, Bath_Appr_Name, Tissue_Appr_Name, Default_Appr_Name, SAP_Cost_Coordinator_Appr_Name, UserName, Status, ref resout))
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
