using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class clsBrandSegmentBO
    {
        string m_strLastError;


        public bool FillAllCategoryBrandSegment(ref DataSet objDS)
        {

            //Variable Declarations
            //This will be returned back.
            bool bReturn = false;
            clsBrandSegmentDA objclsBrandSegmentDA = null;
            DBPool objDBPool = null;
            //Init the data access layer object here

            try
            {
                //Initialize the data access layer object here
                objclsBrandSegmentDA = new clsBrandSegmentDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBrandSegmentDA.FillAllCategoryBrandSegment(ref objDS))
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
                objclsBrandSegmentDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;//Return the status here
        }

        public bool FillCategory(ref DataSet objDS)
        {

            //Variable Declarations
            //This will be returned back.
            bool bReturn = false;
            clsBrandSegmentDA objclsBrandSegmentDA = null;
            DBPool objDBPool = null;
            //Init the data access layer object here

            try
            {
                //Initialize the data access layer object here
                objclsBrandSegmentDA = new clsBrandSegmentDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBrandSegmentDA.FillCategory(ref objDS))
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
                objclsBrandSegmentDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;//Return the status here
        }

        public bool FillCategoryName(int intCategoryID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBrandSegmentDA objclsBrandSegmentDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsBrandSegmentDA = new clsBrandSegmentDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBrandSegmentDA.FillCategoryName(intCategoryID, ref objDS))
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
                objclsBrandSegmentDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool UpdateBrandSegment(int intBrandSegID, int intCatID, string strBrandName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBrandSegmentDA objclsBrandSegmentDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsBrandSegmentDA = new clsBrandSegmentDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBrandSegmentDA.UpdateBrandSegment(intBrandSegID, intCatID, strBrandName, strStatus, strUserName, ref paramOut))
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
                objclsBrandSegmentDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool DeleteBrandSegment(int intBrandSegID, string strUserName, string strCheck, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsBrandSegmentDA objclsBrandSegmentDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsBrandSegmentDA = new clsBrandSegmentDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsBrandSegmentDA.DeleteBrandSegment(intBrandSegID, strUserName, strCheck, ref paramOut))
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
                objclsBrandSegmentDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;

        }

    }
}
