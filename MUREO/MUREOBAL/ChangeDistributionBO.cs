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
    public class ChangeDistributionBO
    {
       ChangeDistributionDA objChangeDistributionDA = new ChangeDistributionDA();
        string m_strLastError;
        Boolean bReturn = false;
        public bool GET_EO_OnRoute_FYI_Distribution_List(ref DataSet objDS)
        {
            //Init the data access layer object here

            try
            {
                //Call the data access function here
                if (objChangeDistributionDA.GET_EO_OnRoute_FYI_Distribution_List(ref objDS))
                    bReturn = true;
                //else
                ////Get the last error from DA class here.
                //m_strLastError=objClsEventDAL.GetLastError();

            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objClsEventDAL = null;
            }
            //Return the status here
            return bReturn;

        }

        public bool SET_EO_OnRoute_FYI_Distribution_List(string strParamLIst, string strUserName, ref SqlParameter[] paramOut)
        {
            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ChangeDistributionBO objChangeDistributionBO = new ChangeDistributionBO();
            try
            {
                //Call the data access function here
                if (objChangeDistributionDA.SET_EO_OnRoute_FYI_Distribution_List(strParamLIst, strUserName, ref paramOut))
                    bReturn = true;
              //  else
                    //Get the last error from DA class here.
                   
            }
            catch (Exception ex)
            {
                //Set the error to this variable
                m_strLastError = ex.StackTrace;
            }
            finally
            { //Free objects here
                //objEODA = null;
            }
            //Return the status here
            return bReturn;

        }

        //public static int SET_EO_OnRoute_FYI_Distribution_List(string strParamLIst, string strUserName) {
        //    return DataAccess.MUREO.DATA.ChangeDistributionListDAC.SET_EO_OnRoute_FYI_Distribution_List(strParamLIst, strUserName);
    }
}
