using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data.SqlClient;
using System.Data;

namespace MUREOBAL
{
    public class PurchasingContact
    {
        string m_strLastError = string.Empty;
        public bool DeletePurchasingContact(int PurchaseContactID,ref SqlParameter[] resout)
        {
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PurchasingContactDA objclsEvent = null;
            try
            {
                objclsEvent = new PurchasingContactDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.DeletePurchasingContact(PurchaseContactID, ref resout))
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
        public bool UpdateEoPurchasingContact(int PlantID, Int32 MaterialTypeID, string ApproverName, string PhoneNumber, Int32 PurchaseContactID, ref SqlParameter[] resout)
        {
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PurchasingContactDA objclsEvent = null;
            try
            {
                objclsEvent = new PurchasingContactDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.UpdateEoPurchasingContact(PlantID, MaterialTypeID, ApproverName, PhoneNumber, PurchaseContactID, ref resout))
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
        public bool AddEoPurchasingContact(int PlantID, Int32 MaterialTypeID, string ApproverName, string PhoneNumber, ref SqlParameter[] resout)
        {
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PurchasingContactDA objclsEvent = null;
            try
            {
                objclsEvent = new PurchasingContactDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.AddEoPurchasingContact(PlantID, MaterialTypeID, ApproverName, PhoneNumber, ref resout))
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
        public bool FillPurchaseContact(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PurchasingContactDA objclsEvent = null;
            try
            {
                objclsEvent = new PurchasingContactDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillPurchaseContact(ref objDS))
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

        public bool FillMaterial(ref DataSet objDS)
        {

            //This will be returned back.
            DBPool objDBPool = null;
            bool bReturn = false;
            //Init the data access layer object here
            PurchasingContactDA objclsEvent = null;
            try
            {
                objclsEvent = new PurchasingContactDA();
                objDBPool = new DBPool();
                //Call the data access function here
                if (objclsEvent.FillMaterial(ref objDS))
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
