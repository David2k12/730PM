using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MUREODAL;
using System.Data;

namespace MUREOBAL
{
    public class ViewDataCoordinatorsBO
    {
        string m_strLastError;

        public bool GetDataCoordinatorDetailsBO(int Co_ID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ViewDataCoordinatorsDAL objViewDataCoordi = null;
            DBPool objDBPool = null;
            try
            {
                objViewDataCoordi = new ViewDataCoordinatorsDAL();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objViewDataCoordi.GetDataCoordinatorDetailsDA(Co_ID, ref objDS))
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

        public bool InsertDataCoordinatorBO(int Co_ID, int Category_ID, string Co_Name, string Phone_Number, string User_Name, string Status, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ViewDataCoordinatorsDAL objViewDataCoordi = null;
            DBPool objDBPool = null;
            try
            {
                objViewDataCoordi = new ViewDataCoordinatorsDAL();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objViewDataCoordi.InsertDataCoordinatorDA(Co_ID, Category_ID, Co_Name, Phone_Number, User_Name, Status, ref paramOut))
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
                objViewDataCoordi = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
