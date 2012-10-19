using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsSystemOwnerBO
    {
        string m_strLastError;
        public bool FillSystemOwner(ref DataSet objDS)
        {

            //Variable Declarations
            //This will be returned back.
            bool bReturn = false;
            clsSystemOwnerDA objclsSystemOwnerDA = null;
            DBPool objDBPool = null;
            //Init the data access layer object here

            try
            {
                //Initialize the data access layer object here
                objclsSystemOwnerDA = new clsSystemOwnerDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsSystemOwnerDA.FillSystemOwner(ref objDS))
                {
                    //Set the status to true here.
                    bReturn = true;
                }
                else
                {
                    //Get the last error from DA class here.
                    m_strLastError = objDBPool.GetLastError();
                }
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            {
                //Dispose objects here
                objclsSystemOwnerDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;//Return the status here
        }

        public bool InsUpdateEoSystemOwner(int PlantID, string SystemOwnerName, string PhoneNumber, int SysOwnID, string strUserName,string strStatus, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsSystemOwnerDA objclsSystemOwnerDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsSystemOwnerDA = new clsSystemOwnerDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsSystemOwnerDA.InsUpdateEoSystemOwner(PlantID, SystemOwnerName, PhoneNumber, SysOwnID, strUserName,strStatus, ref paramOut))
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
                objclsSystemOwnerDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeleteSysOwner(int SysOwnID, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsSystemOwnerDA objclsSystemOwnerDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsSystemOwnerDA = new clsSystemOwnerDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsSystemOwnerDA.DeleteSysOwner(SysOwnID,ref paramOut))
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
                objclsSystemOwnerDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
