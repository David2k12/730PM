using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREOBAL
{
    public class ChangeOriginatorBO
    {
        string m_strLastError;

        public bool GET_EO_NUMBERS(ref DataSet objDS)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ChangeOriginatorDA objChangeOriginatorDA = new ChangeOriginatorDA();
            try
            {
                //Call the data access function here
                if (objChangeOriginatorDA.GET_EO_NUMBERS(ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objChangeOriginatorDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objChangeOriginatorDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool GET_EO_Change_Originator(string strEONumber, ref DataSet objDS)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ChangeOriginatorDA objChangeOriginatorDA = new ChangeOriginatorDA();
            try
            {
                //Call the data access function here
                if (objChangeOriginatorDA.GET_EO_Change_Originator(strEONumber, ref objDS))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objChangeOriginatorDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objChangeOriginatorDA = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_Change_Originator(int p_EO_ID, string p_Originator, string p_CoOriginator, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ChangeOriginatorDA objChangeOriginatorDA = new ChangeOriginatorDA();
            try
            {
                //Call the data access function here
                if (objChangeOriginatorDA.SET_EO_Change_Originator(p_EO_ID,  p_Originator,  p_CoOriginator, ref paramOut))
                    bReturn = true;
                else
                    //Get the last error from DA class here.
                    m_strLastError = objChangeOriginatorDA.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                objChangeOriginatorDA = null;
            }
            //Return the status here
            return bReturn;

        }
    }
}
