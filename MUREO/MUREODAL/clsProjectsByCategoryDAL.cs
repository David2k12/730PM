using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsProjectsByCategoryDAL
    {
        string m_strLastError;
        bool bReturn = false;
        public bool FillProjectsByCategoryBODAL(string spname, ref DataSet objds)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                //SqlParameterCollection spc = null;


                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetwithoutParameters(spname, ref objds)))
                    //Set the status to true here.
                    bReturn = true;
                else
                    //Get the last error from DBPool here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable

                m_strLastError = ex.StackTrace;
            }
            finally
            {

                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }
        public bool FillProjectsByBrandDAL(int categoryID, int brandID, ref DataSet ds, string SPName)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            SqlParameter[] paramIn = new SqlParameter[2];

            try
            {
                paramIn[0] = new SqlParameter("@p_Category_ID", categoryID);
                paramIn[1] = new SqlParameter("@p_Brand_Segment_ID", brandID);
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDataset(SPName, paramIn, ref ds)))
                    //Set the status to true here.
                    bReturn = true;
                else
                    //Get the last error from DBPool here.
                    m_strLastError = objDBPool.GetLastError();
            }
            catch (Exception ex)
            {
                //Set the error to this variable

                m_strLastError = ex.StackTrace;
            }
            finally
            {

                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }
    }
}
