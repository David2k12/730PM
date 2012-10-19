using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class BudgetCtrDA
    {
        string m_strLastError = string.Empty;
        ////
        ////  ************************************************
        ////Name   	    :	FillEOBudgetAreaDA
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Plant_ID
        ////Purpose	    :   To get Area info of all budget centers
        ////Returns        :   Dataset
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 08-06-07          Vijay Selvaganapathy                    Created
        ////***************************************************


        //public static DataSet FillEOBudgetAreaDA(int Area_Id)
        //{

        //    System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[1];
        //    sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_Area_ID ", SqlDbType.Int);
        //    sqlparams[0].Value = Area_Id;

        //    return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Area", sqlparams);


        //}

        public bool FillEOBudgetAreaDA(Int32 p_Area_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Area_ID", p_Area_ID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Area", paramIn, ref objDS)))
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


        public bool InsertEOBudgetCenterDA(int Budget_Center_ID, string Budget_Center_Name, int Plant_ID, int Area_ID, string Towel_Appr_Name, string Bath_Appr_Name, string Tissue_Appr_Name, string Default_Appr_Name, string SAP_Cost_Coordinator_Appr_Name, string UserName, char Status, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[11];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Budget_Center_ID", Budget_Center_ID);
                paramIn[1] = new SqlParameter("@p_Budget_Center_Name", Budget_Center_Name);
                paramIn[2] = new SqlParameter("@p_Plant_ID", Plant_ID);
                paramIn[3] = new SqlParameter("@p_Area_ID", Area_ID);
                paramIn[4] = new SqlParameter("@p_Towel_Approver_Name", Towel_Appr_Name);
                paramIn[5] = new SqlParameter("@p_Bath_Approver_Name", Bath_Appr_Name);
                paramIn[6] = new SqlParameter("@p_Tissue_Approver_Name", Tissue_Appr_Name);
                paramIn[7] = new SqlParameter("@p_Default_Approver_Name", Default_Appr_Name);
                paramIn[8] = new SqlParameter("@p_SAP_Cost_Center_Coordinator", SAP_Cost_Coordinator_Appr_Name);
                paramIn[9] = new SqlParameter("@p_User_Name", UserName);
                paramIn[10] = new SqlParameter("@p_Status", Status);
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Budget_Center", paramIn, ref resout, true)))
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
        ////
        ////  ************************************************
        ////Name   	    :	InsertEOBudgetCenterDA
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Plant_ID
        ////Purpose	    :   To insert/update new/existing Budget Center
        ////Returns        :   0 - success, 1 - failure, 9 - Database problem
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 08-06-07          Vijay Selvaganapathy                    Created
        ////***************************************************

        //public static int InsertEOBudgetCenterDA(int Budget_Center_ID, string Budget_Center_Name, int Plant_ID, int Area_ID, string Towel_Appr_Name, string Bath_Appr_Name, string Tissue_Appr_Name, string Default_Appr_Name, string SAP_Cost_Coordinator_Appr_Name, string UserName,
        //char Status)
        //{

        //    System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[12];
        //    sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_Budget_Center_ID ", SqlDbType.Int);
        //    sqlparams[0].Value = Budget_Center_ID;
        //    sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_Budget_Center_Name ", SqlDbType.VarChar, 100);
        //    sqlparams[1].Value = Budget_Center_Name;
        //    sqlparams[2] = new System.Data.SqlClient.SqlParameter("@p_Plant_ID ", SqlDbType.Int);
        //    sqlparams[2].Value = Plant_ID;
        //    sqlparams[3] = new System.Data.SqlClient.SqlParameter("@p_Area_ID ", SqlDbType.Int);
        //    sqlparams[3].Value = Area_ID;
        //    sqlparams[4] = new System.Data.SqlClient.SqlParameter("@p_Towel_Approver_Name ", SqlDbType.VarChar, 100);
        //    sqlparams[4].Value = Towel_Appr_Name;
        //    sqlparams[5] = new System.Data.SqlClient.SqlParameter("@p_Bath_Approver_Name ", SqlDbType.VarChar, 100);
        //    sqlparams[5].Value = Bath_Appr_Name;
        //    sqlparams[6] = new System.Data.SqlClient.SqlParameter("@p_Tissue_Approver_Name  ", SqlDbType.VarChar, 100);
        //    sqlparams[6].Value = Tissue_Appr_Name;
        //    sqlparams[7] = new System.Data.SqlClient.SqlParameter("@p_Default_Approver_Name ", SqlDbType.VarChar, 100);
        //    sqlparams[7].Value = Default_Appr_Name;
        //    sqlparams[8] = new System.Data.SqlClient.SqlParameter("@p_SAP_Cost_Center_Coordinator ", SqlDbType.VarChar, 100);
        //    sqlparams[8].Value = SAP_Cost_Coordinator_Appr_Name;
        //    sqlparams[9] = new System.Data.SqlClient.SqlParameter("@p_User_Name ", SqlDbType.VarChar, 100);
        //    sqlparams[9].Value = UserName;
        //    sqlparams[10] = new System.Data.SqlClient.SqlParameter("@p_Status ", SqlDbType.Char, 1);
        //    sqlparams[10].Value = Status;
        //    sqlparams[11] = new System.Data.SqlClient.SqlParameter("@p_Result_No ", SqlDbType.Int);
        //    sqlparams[11].Direction = ParameterDirection.Output;

        //    DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Budget_Center", sqlparams);
        //    return sqlparams[11].Value;

        //}

        ////
        ////  ************************************************
        ////Name   	    :	GetBudgetCenterDetails
        ////Written BY	    :	Vijay Selvaganapathy
        ////parameters     :	Plant_ID
        ////Purpose	    :   To insert/update new/existing Budget Center
        ////Returns        :   Budget center info data set
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        //// 08-06-07          Vijay Selvaganapathy                    Created
        ////***************************************************

        public bool GetBudgetCenterDetailsDA(Int32 Budget_Center_ID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Budget_Center_Id", Budget_Center_ID);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Budget_Center", paramIn, ref objDS)))
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

        //public static DataSet GetBudgetCenterDetailsDA(int Budget_Center_ID)
        //{

        //    System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[1];

        //    sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_Budget_Center_Id", SqlDbType.Int);
        //    sqlparams[0].Value = Budget_Center_ID;

        //    return DatabaseHelper.ExecuteDataSet("dbo.GET_EO_Budget_Center", sqlparams);


        //}

    }
}
