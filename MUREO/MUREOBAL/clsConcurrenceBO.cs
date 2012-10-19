using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MUREODAL;

namespace MUREOBAL
{
    public class clsConcurrenceBO
    {
        string m_strLastError;


        public bool GetConcurrenceStatusTreeViewBO(ref DataSet objDS)
        {

            //Variable Declarations
            //This will be returned back.
            bool bReturn = false;
            clsConcurrenceDA objclsConcurrenceDA = null;
            DBPool objDBPool = null;
            //Init the data access layer object here

            try
            {
                //Initialize the data access layer object here
                objclsConcurrenceDA = new clsConcurrenceDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsConcurrenceDA.GetConcurrenceStatusTreeViewDA(ref objDS))
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
                objclsConcurrenceDA = null;
                objDBPool = null;
            }
            //Return the status here
            return bReturn;//Return the status here
        }

        public bool GetConcurrenceStatusTreeViewDetailsBO(int intEOID, ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            clsConcurrenceDA objclsConcurrenceDA = null;
            DBPool objDBPool = null;
            try
            {
                objclsConcurrenceDA = new clsConcurrenceDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsConcurrenceDA.GetConcurrenceStatusTreeViewDetailsDA(intEOID, ref objDS))
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
                objclsConcurrenceDA = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
