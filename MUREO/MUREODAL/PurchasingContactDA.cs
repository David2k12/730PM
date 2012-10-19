using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MUREODAL
{
    public class PurchasingContactDA
    {
        string m_strLastError = string.Empty;
        // Public Shared Function DeletePurchasingContact(ByVal PurchaseContactID As Integer) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Purchase_Contact_ID", SqlDbType.Int)
        //        sqlparams(0).Value = PurchaseContactID
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //        sqlparams(1).Value = 1
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_Material_Type_ID", SqlDbType.Int)
        //        sqlparams(2).Value = 1
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar)
        //        sqlparams(3).Value = Convert.DBNull
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Phone_Number ", SqlDbType.VarChar)
        //        sqlparams(4).Value = Convert.DBNull
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.Char)
        //        sqlparams(5).Value = Convert.DBNull
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_Status", SqlDbType.VarChar)
        //        sqlparams(6).Value = "I"
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = Convert.DBNull

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Purchasing_Contact", sqlparams)

        //        Return sqlparams(7).Value

        //    Catch ex As Exception
        //        Throw ex

        //    End Try
        //End Function

        public bool DeletePurchasingContact(Int32 PurchaseContactID, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Purchase_Contact_ID", PurchaseContactID);
                paramIn[1] = new SqlParameter("@p_Plant_ID", 1);
                paramIn[2] = new SqlParameter("@p_Material_Type_ID", 1);
                paramIn[3] = new SqlParameter("@p_Approver_Name", "");
                paramIn[4] = new SqlParameter("@p_Phone_Number", "");
                paramIn[5] = new SqlParameter("@p_User_Name", ""); 
                paramIn[6] = new SqlParameter("@p_Status", "I");               
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Purchasing_Contact", paramIn, ref resout, true)))
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
        //Public Shared Function UpdateEoPurchasingContact(ByVal PlantID As Integer, ByVal MaterialTypeID As Integer, ByVal ApproverName As String, ByVal PhoneNumber As String, ByVal PurchaseContactID As Integer) As Int32
        //    Try
        //        Dim sqlparams(7) As SqlClient.SqlParameter
        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Purchase_Contact_ID", SqlDbType.Int)
        //        sqlparams(0).Value = PurchaseContactID
        //        sqlparams(1) = New SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int)
        //        sqlparams(1).Value = PlantID
        //        sqlparams(2) = New SqlClient.SqlParameter("@p_Material_Type_ID", SqlDbType.Int)
        //        sqlparams(2).Value = MaterialTypeID
        //        sqlparams(3) = New SqlClient.SqlParameter("@p_Approver_Name", SqlDbType.VarChar)
        //        sqlparams(3).Value = ApproverName
        //        sqlparams(4) = New SqlClient.SqlParameter("@p_Phone_Number ", SqlDbType.VarChar)
        //        sqlparams(4).Value = PhoneNumber
        //        sqlparams(5) = New SqlClient.SqlParameter("@p_User_Name", SqlDbType.Char)
        //        sqlparams(5).Value = Convert.DBNull
        //        sqlparams(6) = New SqlClient.SqlParameter("@p_Status", SqlDbType.VarChar)
        //        sqlparams(6).Value = "A"
        //        sqlparams(7) = New SqlClient.SqlParameter("@p_Result_No", SqlDbType.Int)
        //        sqlparams(7).Direction = ParameterDirection.Output
        //        sqlparams(7).Value = Convert.DBNull

        //        DatabaseHelper.ExecuteNonQuery("dbo.SET_EO_Purchasing_Contact", sqlparams)

        //        Return sqlparams(7).Value

        //    Catch ex As Exception
        //        Throw ex
        ////    End Try
        ////End Function
        //        Public Shared Function FillMaterial() As DataSet
        //    Try
        //        Dim sqlparams(0) As SqlClient.SqlParameter
        //        Dim plantDataSet As DataSet

        //        sqlparams(0) = New SqlClient.SqlParameter("@p_Material_Type_ID", SqlDbType.Int)
        //        sqlparams(0).Value = 0

        //        Return DatabaseHelper.ExecuteDataSet("GET_EO_Material_Type", sqlparams)


        //    Catch ex As Exception
        //        Throw ex

        //    End Try
        //End Function
        public bool FillMaterial(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Material_Type_ID", 0);
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Material_Type", paramIn, ref objDS)))
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
        public bool UpdateEoPurchasingContact(int PlantID, Int32 MaterialTypeID, string ApproverName, string PhoneNumber,Int32 PurchaseContactID, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[7];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Purchase_Contact_ID", PurchaseContactID);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[2] = new SqlParameter("@p_Material_Type_ID", MaterialTypeID);
                paramIn[3] = new SqlParameter("@p_Approver_Name", ApproverName);
                paramIn[4] = new SqlParameter("@p_Phone_Number", PhoneNumber);
                //string lsIdentityName = null;
                //string UserName = null;
                //lsIdentityName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                //UserName = Right(lsIdentityName, lsIdentityName.Length - lsIdentityName.LastIndexOf("\\") - 1);
                paramIn[5] = new SqlParameter("@p_User_Name", "");
                paramIn[6] = new SqlParameter("@p_Status", 'A');
                
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Purchasing_Contact", paramIn, ref resout, true)))
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
        public bool FillPurchaseContact(ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDatasetNoParams("GET_EO_Purchasing_Contacts", ref objDS)))
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

        public bool AddEoPurchasingContact(int PlantID, Int32 MaterialTypeID, string ApproverName, string PhoneNumber, ref SqlParameter[] resout)
        {
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[6];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Purchase_Contact_ID", 0);
                paramIn[1] = new SqlParameter("@p_Plant_ID", PlantID);
                paramIn[2] = new SqlParameter("@p_Material_Type_ID", MaterialTypeID);
                paramIn[3] = new SqlParameter("@p_Approver_Name", ApproverName);
                paramIn[4] = new SqlParameter("@p_Phone_Number", PhoneNumber);
                string lsIdentityName = null;
                string UserName = null;
                lsIdentityName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                UserName =Right(lsIdentityName, lsIdentityName.Length - lsIdentityName.LastIndexOf("\\") - 1);
                paramIn[5] = new SqlParameter("@p_User_Name", UserName);              
                resout[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                resout[0].Direction = ParameterDirection.Output;
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryOutputParam("dbo.SET_EO_Purchasing_Contact", paramIn, ref resout, true)))
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

        public string Right(string value, int length)
        {
            return value.Substring(value.Length - length);
        }




    }
}
