using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MUREODAL;
using System.Data;
using System.Data.SqlClient;
namespace MUREOBAL
{

    namespace MUREODAL
    {
        public class MURDAL
        {
            string m_strLastError;
            public bool GetEventsCountDAL(int ProjectID, ref SqlParameter[] paramOut)
            {
                //Variable Declarations
                bool bReturn = false;
                SqlParameter[] paramIn = new SqlParameter[1];
                paramOut = new SqlParameter[1];
               DBPool objDBPool = null;
                //DataSet ds = null;
                try
                {
                    //SqlParameterCollection spc = null;
                    paramIn[0] = new SqlParameter("@p_Project_ID", ProjectID);
                    paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                    paramOut[0].Direction = ParameterDirection.Output;
                    objDBPool = new DBPool();
                    if ((objDBPool.SPQueryOutputParam("GET_Events_Count", paramIn, ref paramOut, true)))
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
            //   public bool FetchProjectDetailsDAL(int ProjectID, ref DataSet  ds)
            //{
            //    //Variable Declarations
            //    bool bReturn = false;
            //    SqlParameter[] paramIn = new SqlParameter[1];
                
            //   DBPool objDBPool = null;
               
            //    try
            //    {
            //        //SqlParameterCollection spc = null;
            //        paramIn[0] = new SqlParameter("@p_Project_ID", ProjectID);
                   
            //        objDBPool = new DBPool();
            //        if ((objDBPool.SPQueryInputParam("GET_MUR_Project", paramIn, ref ds)))
            //            //Set the status to true here.
            //            bReturn = true;
            //        else
            //            //Get the last error from DBPool here.
            //            m_strLastError = objDBPool.GetLastError();
            //    }
            //    catch (Exception ex)
            //    {
            //        //Set the error to this variable

            //        m_strLastError = ex.StackTrace;
            //    }
            //    finally
            //    {
            //        paramIn = null;
            //        objDBPool = null;
            //    }
            //    //Return status here
            //    return bReturn;
            //}
            //   public bool FetchCategoryDAL(int ProjectID, ref DataSet ds)
            //   {
            //       //Variable Declarations
            //       bool bReturn = false;
            //       DBPool objDBPool = null;
            //       SqlParameter[] paramIn = new SqlParameter[1];
                   
            //       try
            //       {
            //           paramIn[0] = new SqlParameter("@p_Project_ID", ProjectID);
                       
            //           objDBPool = new DBPool();
            //           if ((objDBPool.SPQueryDataset("GET_MUR_Project",paramIn, ref ds)))
            //               //Set the status to true here.
            //               bReturn = true;
            //           else
            //               //Get the last error from DBPool here.
            //               m_strLastError = objDBPool.GetLastError();
            //       }
            //       catch (Exception ex)
            //       {
            //           //Set the error to this variable

            //           m_strLastError = ex.StackTrace;
            //       }
            //       finally
            //       {
                      
            //           objDBPool = null;
            //       }
            //       //Return status here
            //       return bReturn;
            //   }
            //   public bool FetchProjectTypeDAL(int ProjectID, ref DataSet ds)
            //   {
            //       //Variable Declarations
            //       bool bReturn = false;
            //       DBPool objDBPool = null;
            //       SqlParameter[] paramIn = new SqlParameter[1];

            //       try
            //       {
            //           paramIn[0] = new SqlParameter("@p_Project_Type_ID", ProjectID);

            //           objDBPool = new DBPool();
            //           if ((objDBPool.SPQueryDataset("GET_MUR_Project_Type", paramIn, ref ds)))
            //               //Set the status to true here.
            //               bReturn = true;
            //           else
            //               //Get the last error from DBPool here.
            //               m_strLastError = objDBPool.GetLastError();
            //       }
            //       catch (Exception ex)
            //       {
            //           //Set the error to this variable

            //           m_strLastError = ex.StackTrace;
            //       }
            //       finally
            //       {

            //           objDBPool = null;
            //       }
            //       //Return status here
            //       return bReturn;
            //   }
            public bool FetchDataSetUsingSqlParametersDAL(int ProjectID, ref DataSet ds,string SP_Name,string parameter)
            {
                //Variable Declarations
                bool bReturn = false;
                DBPool objDBPool = null;
                SqlParameter[] paramIn = new SqlParameter[1];

                try
                {
                    paramIn[0] = new SqlParameter(parameter, ProjectID);

                    objDBPool = new DBPool();
                    if ((objDBPool.SPQueryDataset(SP_Name, paramIn, ref ds)))
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
            public bool FillHistoryofProjectDAL(string ProjectID, ref DataSet ds)
               {
                   //Variable Declarations
                   bool bReturn = false;
                   DBPool objDBPool = null;
                   SqlParameter[] paramIn = new SqlParameter[1];

                   try
                   {
                       paramIn[0] = new SqlParameter("@p_Project_ID", ProjectID);

                       objDBPool = new DBPool();
                       if ((objDBPool.SPQueryDataset("GET_MUR_Project", paramIn, ref ds)))
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
            public bool ProjectInsertDAL(int intPrjID, int intPrjType, int intBrand, string strPrjName, string strLead, string strPOC, string strStatus, string strUser, ref SqlParameter[] paramOut)
            {
                //Variable Declarations
                bool bReturn = false;
                SqlParameter[] paramIn = new SqlParameter[8];
                paramOut = new SqlParameter[1];
                DBPool objDBPool = null;
                //DataSet ds = null;
                try
                {
                    //SqlParameterCollection spc = null;
                    paramIn[0] = new SqlParameter("@p_Project_ID", intPrjID);
                   
                    paramIn[1] = new SqlParameter("@p_Project_Type_ID", intPrjType) ;
                      paramIn[2] = new SqlParameter("@p_Brand_Segment_ID", intBrand); 
                       paramIn[3] = new SqlParameter("@p_Project_Name", strPrjName);
                        paramIn[4]= new SqlParameter("@p_Project_Lead", strLead);
                       paramIn[5]= new SqlParameter("@p_Point_Of_Contact", strPOC);
                       paramIn[6]= new SqlParameter("@p_Status", strStatus);
                       paramIn[7] = new SqlParameter("@p_User_Name", strUser);
                     paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                    paramOut[0].Direction = ParameterDirection.Output;
                    objDBPool = new DBPool();
                    if ((objDBPool.SPQueryOutputParam("SET_MUR_Project", paramIn, ref paramOut, true)))
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
            public bool GetProjectIDDAL(string projectName,Int32 BrandID,Int32 intPrjTypeID, ref SqlParameter[] paramOut)
            {
                //Variable Declarations
                bool bReturn = false;
                SqlParameter[] paramIn = new SqlParameter[3];
                paramOut = new SqlParameter[1];
                DBPool objDBPool = null;
                //DataSet ds = null;
                try
                {
                    //SqlParameterCollection spc = null;
                    paramIn[0] = new SqlParameter("@p_Brand_Segment_ID", BrandID);
                    paramIn[1] = new SqlParameter("@p_Project_Type_ID", intPrjTypeID);
                    paramIn[2] = new SqlParameter("@p_Project_Name", projectName);
                    paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                    paramOut[0].Direction = ParameterDirection.Output;
                    objDBPool = new DBPool();
                    if ((objDBPool.SPQueryOutputParam("GET_MUR_Project_ID", paramIn, ref paramOut, true)))
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
               public string GetLastError()
            {
                //Return last error message here
                return m_strLastError;
            }
             
        
            
        }

    }
}