using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREODAL
{
    public class clsBrandSegmentDA
    {
        string m_strLastError;

        public bool FillAllCategoryBrandSegment(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                if (objDBPool.SPQueryDatasetNoParams("GET_MUR_Brand_Segment_By_Category", ref objDS))
                {
                    //Set the status to true here.
                    bReturn = true;
                }
                else
                {
                    //Get the last error from DBPool here.
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
                //Dispose the Objects
                objDBPool = null;
            }
            return bReturn;//Return the status here.
        }

        public bool FillCategory(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            m_strLastError = string.Empty;
            DBPool objDBPool = null;

            try
            {
                objDBPool = new DBPool();
                //Input Parameter List
                if (objDBPool.SPQueryDatasetNoParams("GET_MUR_Category", ref objDS))
                {
                    //Set the status to true here.
                    bReturn = true;
                }
                else
                {
                    //Get the last error from DBPool here.
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
                //Dispose the Objects
                objDBPool = null;
            }
            return bReturn;//Return the status here.
        }

        public bool FillCategoryName(int intCategoryID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[0].Value = intCategoryID;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Brand_Segment_By_Category", paramIn, ref objDS)))
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
                paramIn = null;
                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }

        public bool UpdateBrandSegment(int intBrandSegID, int intCatID, string strBrandName, string strStatus, string strUserName, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[5];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@p_Brand_Segment_ID", SqlDbType.Int);
                paramIn[0].Value = intBrandSegID;

                paramIn[1] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[1].Value = intCatID;

                paramIn[2] = new SqlParameter("@p_Brand_Segment_Name", SqlDbType.VarChar);
                paramIn[2].Value = strBrandName;

                paramIn[3] = new SqlParameter("@p_Status", SqlDbType.VarChar);
                paramIn[3].Value = strStatus;

                paramIn[4] = new SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[4].Value = strUserName;

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("SET_MUR_Brand_Segment", paramIn, ref paramOut, true)))
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
                paramIn = null;
                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }

        public bool DeleteBrandSegment(int intBrandSegID, string strUserName, string strCheck, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[3];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                paramIn[0] = new SqlParameter("@Brand_Segment_ID", SqlDbType.Int);
                paramIn[0].Value = intBrandSegID;

                paramIn[1] = new SqlParameter("@User_Name", SqlDbType.VarChar);
                paramIn[1].Value = strUserName;

                paramIn[2] = new SqlParameter("@Check", SqlDbType.Char);
                paramIn[2].Value = Convert.ToChar(strCheck);

                paramOut = new SqlParameter[1];
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("Delete_Brand_Segment", paramIn, ref paramOut, true)))
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
                paramIn = null;
                objDBPool = null;
            }
            //Return status here
            return bReturn;
        }
    }
}
