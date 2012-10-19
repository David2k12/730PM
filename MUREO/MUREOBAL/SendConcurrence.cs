using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using  MUREODAL;

namespace MUREOBAL
{
    public class SendConcurrence
    {
        string m_strLastError;

        public bool FillConGroups(int PlantID, int ConGrpID, ref DataSet dsMyEventDetails)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SendConcurrenceDAL objEODA = null;
            DBPool objDBPool = null;
            try
            {
                objEODA = new SendConcurrenceDAL();
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Call the data access function here
                if (objEODA.FillConGrpNames(PlantID, ConGrpID, ref dsMyEventDetails))
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
                objEODA = null;
            }
            //Return the status here
            return bReturn;

            //return SendConcurrence.FillConGrpNames(PlantID, ConGrpID);
        }
        //Public Shared Function AddSiteTestConcurrenceGrp(ByVal PlantID As Integer, ByVal ConGrpID As Integer) As DataSet
        //    Return DataAccess.MUREO.DATA.SendConcurrence.FillConGrpNames(PlantID, ConGrpID)
        ////End Function
        //public static int AddSiteTestConcurrenceGrp(ObjSiteTest objSiteTest)
        //{
        //    System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[11];
        //    //@p_EO_ID
        //    sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_EO_Con_App_ID", SqlDbType.Int);
        //    sqlparams[0].Value = objSiteTest.ConAppID;
        //    //@p_EO_Title
        //    sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
        //    sqlparams[1].Value = objSiteTest.EOID;
        //    //@p_Event_ID_List
        //    sqlparams[2] = new System.Data.SqlClient.SqlParameter("@p_Concurrence_Group_Name", SqlDbType.VarChar);
        //    sqlparams[2].Value = objSiteTest.ConGrpName;
        //    //@p_Project_ID
        //    sqlparams[3] = new System.Data.SqlClient.SqlParameter("@p_Approvers_Name_List", SqlDbType.VarChar);
        //    sqlparams[3].Value = objSiteTest.ApprNameList;
        //    //@p_Plant_ID
        //    sqlparams[4] = new System.Data.SqlClient.SqlParameter("@p_Is_Email_Sent", SqlDbType.VarChar);
        //    sqlparams[4].Value = objSiteTest.IsMailSent;
        //    //@p_Category_ID
        //    sqlparams[5] = new System.Data.SqlClient.SqlParameter("@p_Email_Sent_Date", SqlDbType.DateTime);
        //    sqlparams[5].Value = objSiteTest.EmailSentDate;
        //    //@p_Originator
        //    sqlparams[6] = new System.Data.SqlClient.SqlParameter("@p_Is_Responded", SqlDbType.VarChar);
        //    sqlparams[6].Value = objSiteTest.IsResponded;
        //    //@p_Office_Num
        //    sqlparams[7] = new System.Data.SqlClient.SqlParameter("@p_Responded_Date", SqlDbType.DateTime);
        //    sqlparams[7].Value = Convert.DBNull;
        //    sqlparams[8] = new System.Data.SqlClient.SqlParameter("@p_Email_Sentence", SqlDbType.VarChar);
        //    sqlparams[8].Value = objSiteTest.Comment;
        //    sqlparams[9] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
        //    sqlparams[9].Value = objSiteTest.UserName;
        //    sqlparams[10] = new System.Data.SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int);
        //    sqlparams[10].Direction = ParameterDirection.Output;
        //    sqlparams[10].Value = Convert.DBNull;
        //    //@p_Phone_Num
        //    DatabaseHelper.ExecuteNonQuery("SET_EO_Concurrence_Approvers", sqlparams);
        //    //If Not sqlparams(14).Value Is DBNull.Value Then
        //    //    Return CInt(sqlparams(14).Value)
        //    //Else
        //    //    Return -1
        //    //End If
        //    return sqlparams[10].Value;

        //}

        //public static int UpdateSiteTestConcurrenceGrp(ObjSiteTest objSiteTest)
        //{
        //    System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[11];
        //    //@p_EO_ID
        //    sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_EO_Con_App_ID", SqlDbType.Int);
        //    sqlparams[0].Value = 0;
        //    //@p_EO_Title
        //    sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
        //    sqlparams[1].Value = objSiteTest.EOID;
        //    //@p_Event_ID_List
        //    sqlparams[2] = new System.Data.SqlClient.SqlParameter("@p_Concurrence_Group_Name", SqlDbType.VarChar);
        //    sqlparams[2].Value = objSiteTest.ConGrpName;
        //    //@p_Project_ID
        //    sqlparams[3] = new System.Data.SqlClient.SqlParameter("@p_Approvers_Name_List", SqlDbType.VarChar);
        //    sqlparams[3].Value = objSiteTest.ApprNameList;
        //    //@p_Plant_ID
        //    sqlparams[4] = new System.Data.SqlClient.SqlParameter("@p_Is_Email_Sent", SqlDbType.VarChar);
        //    sqlparams[4].Value = objSiteTest.IsMailSent;
        //    //@p_Category_ID
        //    sqlparams[5] = new System.Data.SqlClient.SqlParameter("@p_Email_Sent_Date", SqlDbType.DateTime);
        //    sqlparams[5].Value = objSiteTest.EmailSentDate;
        //    //@p_Originator
        //    sqlparams[6] = new System.Data.SqlClient.SqlParameter("@p_Is_Responded", SqlDbType.VarChar);
        //    sqlparams[6].Value = objSiteTest.IsResponded;
        //    //@p_Office_Num
        //    sqlparams[7] = new System.Data.SqlClient.SqlParameter("@p_Responded_Date", SqlDbType.DateTime);
        //    sqlparams[7].Value = Convert.DBNull;
        //    sqlparams[8] = new System.Data.SqlClient.SqlParameter("@p_Email_Sentence", SqlDbType.VarChar);
        //    sqlparams[8].Value = objSiteTest.Comment;
        //    sqlparams[9] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
        //    sqlparams[9].Value = objSiteTest.UserName;
        //    sqlparams[10] = new System.Data.SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int);
        //    sqlparams[10].Direction = ParameterDirection.Output;
        //    sqlparams[10].Value = Convert.DBNull;
        //    //@p_Phone_Num
        //    DatabaseHelper.ExecuteNonQuery("SET_EO_Concurrence_Approvers", sqlparams);
        //    //If Not sqlparams(14).Value Is DBNull.Value Then
        //    //    Return CInt(sqlparams(14).Value)
        //    //Else
        //    //    Return -1
        //    //End If
        //    return sqlparams[10].Value;

        //}
        //public static int AddConGrpNames(ObjSiteTest objSiteTest)
        //{
        //    try
        //    {
        //        System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[8];
        //        DataSet ConGrp = null;
        //        sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_EO_Con_App_ID", SqlDbType.Int);
        //        sqlparams[0].Value = objSiteTest.ConAppID;
        //        sqlparams[1] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
        //        sqlparams[1].Value = objSiteTest.EOID;
        //        sqlparams[2] = new System.Data.SqlClient.SqlParameter("@p_Concurrence_Group_ID", SqlDbType.Int);
        //        sqlparams[2].Value = objSiteTest.ConGrpID;
        //        sqlparams[3] = new System.Data.SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar);
        //        sqlparams[3].Value = objSiteTest.ApprNameList;
        //        sqlparams[4] = new System.Data.SqlClient.SqlParameter("@p_Is_Responded", SqlDbType.VarChar);
        //        sqlparams[4].Value = objSiteTest.IsResponded;
        //        sqlparams[5] = new System.Data.SqlClient.SqlParameter("@p_Email_Sentence", SqlDbType.VarChar);
        //        sqlparams[5].Value = objSiteTest.Comment;
        //        sqlparams[6] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
        //        sqlparams[6].Value = objSiteTest.UserName;
        //        sqlparams[7] = new System.Data.SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int);
        //        sqlparams[7].Direction = ParameterDirection.Output;
        //        sqlparams[7].Value = Convert.DBNull;

        //        DatabaseHelper.ExecuteNonQuery("[dbo].SET_EO_Concurrence_Approvers", sqlparams);
        //        return sqlparams[7].Value;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool AddBackUpApprover(int conAppID, string BUapproverName)
        {
            try
            {
                
                //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            SendConcurrenceDAL objEODA = null;
            DBPool objDBPool = null;
            try
            {
                objEODA = new SendConcurrenceDAL();
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Call the data access function here
                if (objEODA.AddBackUpApprover(conAppID, BUapproverName))
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
                objEODA = null;
            }
            //Return the status here
            return bReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public static DataSet getConGroupUsers(int EoId)
        //{
        //    System.Data.SqlClient.SqlParameter[] sqlparams = new SqlClient.SqlParameter[1];
        //    //@p_EO_ID
        //    sqlparams[0] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
        //    sqlparams[0].Value = EoId;
        //    return DatabaseHelper.ExecuteDataSet("GET_EO_Concurrence_Approvers", sqlparams);


        //}

    }
}
