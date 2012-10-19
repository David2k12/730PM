using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.Common;
using System.Data.OleDb;
using System.Web;
using System.Configuration;

/// -----------------------------------------------------------------------------
/// Project	 : DBPool
/// Class	 : Pool
/// 
/// -----------------------------------------------------------------------------
/// <summary>
///     Pool Class - Helper class to perform Database calls
/// </summary>
/// <remarks>
/// </remarks>
/// <history>
/// 	[Raj]	03/19/2010	Created
/// </history>
/// -----------------------------------------------------------------------------
/// 

namespace MUREODAL
{
    public class DBPool
    {
        // Member variables
        DbConnection m_AdoConnection;
        DbTransaction m_AdoTransaction;
        string m_strErrorMessage;
        string m_strConnString;
        bool m_bOracle = false;

        public bool GetConnection()
        {

            bool bReturn = false;
            bReturn = false;
            try
            {
                if ((m_AdoConnection != null))
                {
                    if (m_AdoConnection.State == ConnectionState.Open)
                    {
                    }
                    else
                    {
                        m_AdoConnection.Open();
                    }
                }
                else
                {
                    if (!m_bOracle)
                    {
                        m_AdoConnection = new SqlConnection(m_strConnString);
                    }
                    else
                    {
                        m_AdoConnection = new OracleConnection(m_strConnString);
                    }
                    m_AdoConnection.Open();
                }
                bReturn = true;
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
            }
            return bReturn;
        }

        public bool OpenConnection(string strConnectString)
        {
            bool bReturn = false;
            bReturn = false;
            try
            {
                m_strConnString = strConnectString;
                if ((GetConnection()))
                {
                    bReturn = true;
                }
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
            }
            return bReturn;
        }

        public bool BeginTrans()
        {
            try
            {
                m_AdoTransaction = null;
                m_AdoTransaction = m_AdoConnection.BeginTransaction();
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
                return false;
            }
            return true;
        }

        public bool AbortTrans()
        {
            try
            {
                m_AdoTransaction.Rollback();
                m_AdoTransaction = null;
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
                return false;
            }
            return true;
        }

        public bool CommitTrans()
        {
            try
            {
                m_AdoTransaction.Commit();
                m_AdoTransaction = null;
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
                return false;
            }
            return true;
        }

        public bool ExecuteScalarQuery(string strSQL, ref object objReturn)
        {
            DbCommand cmd = null;
            bool bReturn = false;
            bReturn = false;
            try
            {
                if ((m_AdoConnection == null))
                {
                    m_strErrorMessage = "Database connection is not opened.";
                    return bReturn;
                }
                if (!m_bOracle)
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new SqlCommand(strSQL, (SqlConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand(strSQL, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                    }
                }
                else
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new OracleCommand(strSQL, (OracleConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new OracleCommand(strSQL, (OracleConnection)m_AdoConnection, (OracleTransaction)m_AdoTransaction);
                    }
                }
                objReturn = cmd.ExecuteScalar();
                bReturn = true;
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
            return bReturn;
        }

        public bool ExecuteDML(string strSQL, ref int nRowsAffected, int nTimeOut)
        {
            DbCommand cmd = null;
            bool bReturn = false;
            bReturn = false;
            try
            {
                if ((m_AdoConnection == null))
                {
                    m_strErrorMessage = "Database connection is not opened.";
                    return bReturn;
                }

                if (!m_bOracle)
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new SqlCommand(strSQL, (SqlConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand(strSQL, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                    }
                }
                else
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new OracleCommand(strSQL, (OracleConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new OracleCommand(strSQL, (OracleConnection)m_AdoConnection, (OracleTransaction)m_AdoTransaction);
                    }
                }
                if (nTimeOut > 0)
                {
                    cmd.CommandTimeout = nTimeOut;
                }
                nRowsAffected = cmd.ExecuteNonQuery();
                bReturn = true;
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
            return bReturn;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Pupulates the results returned by the SQLQuery statement.
        /// </summary>
        /// <param name="strSQL">Select Statement string.</param>
        /// <param name="ds">DataSet - Contains the rows returned by the query.</param>
        /// <returns>
        ///     Boolean True/False
        ///     True - If the SQL got executed successfully and populated the DataSet
        ///     False - If any exception occurs.
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Raj]	19/03/2010	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool RSQuery(string strSQL, ref DataSet ds, int nTimeOut)
        {
            DbCommand cmd = null;
            DbDataAdapter da = default(DbDataAdapter);
            bool bReturn = false;
            bReturn = false;

            try
            {
                if ((m_AdoConnection == null))
                {
                    m_strErrorMessage = "Database connection is not opened.";
                    return bReturn;
                }

                if (!m_bOracle)
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new SqlCommand(strSQL, (SqlConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand(strSQL, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                    }
                }
                else
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new OracleCommand(strSQL, (OracleConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new OracleCommand(strSQL, (OracleConnection)m_AdoConnection, (OracleTransaction)m_AdoTransaction);
                    }
                }
                if (nTimeOut > 0) cmd.CommandTimeout = nTimeOut;
                if (!m_bOracle)
                {
                    da = new SqlDataAdapter((SqlCommand)cmd);
                }
                else
                {
                    da = new OracleDataAdapter((OracleCommand)cmd);
                }
                ds = new DataSet();
                da.Fill(ds);
                bReturn = true;
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                da = null;
            }
            return bReturn;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     To close connection with the database.
        ///     Note : This needs to be explicitly called whenever the openConnection method is called.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Raj]	19/03/2010	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public object CloseConnection()
        {
            // CSS: There is nothing we can do by returning a value from here. So, just dont return anything from this function.
            try
            {
                if ((m_AdoConnection != null))
                {
                    m_AdoConnection.Close();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                m_AdoConnection.Dispose();
                m_AdoConnection = null;
            }
            return true;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     To Insert and get the Identity ID for the row thats inserted.
        /// </summary>
        /// <param name="strSP">Stored Procedure Name</param>
        /// <param name="nIdentityID">Returns the RetValue of the storeproc</param>
        /// <param name="commandParameters">
        ///     ParametersArray : ColNameString, SequenceNameString, SQLString 
        ///     ColNameString : ColumnName of the table.
        ///     SeqNameString : SequenceName which contains the next identity value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        ///     Usage : ExecuteScalarSP("", nID, New SqlParameter("@ColNameString", strColumnName), New SqlParameter("@SeqNameString", strSequenceName), New SqlParameter("@SQLString", strSQL))
        /// </remarks>
        /// <history>
        /// 	[Raj]	19/03/2010	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public bool ExecuteScalarSP(string strConn, string strSP, ref int nIdentityID, params SqlParameter[] commandParameters)
        {
            // To Call this method :
            // bReturn  = objDBPool.RunInsertSPReturnInteger("", strID, New SqlParameter("@SQLString", strSQL), New SqlParameter("@ColNameString", strColumnName), New SqlParameter("@SeqNameString", strSequenceName))         
            bool bReturn = false;
            bReturn = false;
            DbCommand cmd = null;
            DbParameter prms = default(DbParameter);
            try
            {

                if ((m_AdoConnection == null))
                {
                    m_strErrorMessage = "Database connection is not opened.";
                    return bReturn;
                }
                if (!m_bOracle)
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                    }
                }
                else
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new OracleCommand(strSP, (OracleConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new OracleCommand(strSP, (OracleConnection)m_AdoConnection, (OracleTransaction)m_AdoTransaction);
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DbParameter DbPar in commandParameters)
                {
                    if (!m_bOracle)
                    {
                        prms = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                    }
                    else
                    {
                        prms = ((OracleCommand)cmd).Parameters.Add((OracleParameter)DbPar);
                    }
                    prms.Direction = ParameterDirection.Input;
                }
                if (!m_bOracle)
                {
                    prms = ((SqlCommand)cmd).Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int));
                }
                else
                {
                    prms = ((OracleCommand)cmd).Parameters.Add(new OracleParameter("@RetVal", OracleType.Number));
                }
                prms.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (!m_bOracle)
                {
                    nIdentityID = (int)((SqlCommand)cmd).Parameters["@RetVal"].Value;
                }
                else
                {
                    nIdentityID = (int)((OracleCommand)cmd).Parameters["@RetVal"].Value;
                }
                cmd.Dispose();
                bReturn = true;
            }
            catch (Exception ex)
            {
                //Throw New Exception(ex.Message)
                m_strErrorMessage = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                prms = null;
            }
            return bReturn;
        }

        public bool ExecuteSP(string strSP, ref int nIdentityID, params SqlParameter[] commandParameters)
        {
            bool bReturn = false;
            bReturn = false;
            DbCommand cmd = null;
            DbParameter prms = default(DbParameter);
            try
            {
                if ((m_AdoConnection == null))
                {
                    m_strErrorMessage = "Database connection is not opened.";
                    return bReturn;
                }
                if (!m_bOracle)
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                    }
                }
                else
                {
                    if ((m_AdoTransaction == null))
                    {
                        cmd = new OracleCommand(strSP, (OracleConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new OracleCommand(strSP, (OracleConnection)m_AdoConnection, (OracleTransaction)m_AdoTransaction);
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DbParameter DbPar in commandParameters)
                {
                    if (!m_bOracle)
                    {
                        prms = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                    }
                    else
                    {
                        prms = ((OracleCommand)cmd).Parameters.Add((OracleParameter)DbPar);
                    }
                    prms.Direction = ParameterDirection.Input;
                }
                if (!m_bOracle)
                {
                    prms = ((SqlCommand)cmd).Parameters.Add(new SqlParameter("@p_DocID", SqlDbType.Int));
                }
                else
                {
                    prms = ((OracleCommand)cmd).Parameters.Add(new OracleParameter("@p_DocID", SqlDbType.Int));
                }
                prms.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (!m_bOracle)
                {
                    nIdentityID = (int)((SqlCommand)cmd).Parameters["@p_DocID"].Value;
                }
                else
                {
                    nIdentityID = (int)((OracleCommand)cmd).Parameters["@p_DocID"].Value;
                }
                cmd.Dispose();
                bReturn = true;
            }
            catch (Exception ex)
            {
                //Throw New Exception(ex.Message)
                m_strErrorMessage = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                prms = null;
            }
            return bReturn;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     Returns the Last Error Message
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Raj]	19/03/2010	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string GetLastError()
        {
            return m_strErrorMessage;
        }

        public bool SPQueryExcuter(string strConn, string strSP, SqlParameter[] objInParams, SqlParameter[] objOutParams, bool bExNonQuery, ref SqlParameterCollection objParamCol, ref DataSet objDS)
        {
            bool bReturn = false;
            SqlCommand cmd = null;
            SqlParameter objParam = default(SqlParameter);
            SqlDataAdapter objDA = default(SqlDataAdapter);
            int nReturn = 0;

            try
            {
                //if (OpenConnection("Password=ghost5;Persist Security Info=True;User ID=GClass_admin;Initial Catalog=CCT;Data Source=bdc-sqld023.na.pg.com\\devnt2322"))
                if (OpenConnection(strConn))
                {
                    if ((m_AdoConnection == null))
                    {
                        m_strErrorMessage = "Database connection is not opened.";
                        return bReturn;
                    }

                    if ((m_AdoTransaction == null))
                    {
                        cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                    }
                    else
                    {
                        cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    if ((objInParams != null))
                    {
                        foreach (DbParameter DbPar in objInParams)
                        {
                            objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                            objParam.Direction = ParameterDirection.Input;
                        }
                    }

                    if ((objOutParams != null))
                    {
                        foreach (DbParameter DbPar in objOutParams)
                        {
                            objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                            objParam.Direction = ParameterDirection.Output;
                        }
                    }
                    if (bExNonQuery)
                    {
                        //cmd.ExecuteNonQuery();
                        //objParamCol = cmd.Parameters;

                        //Else fill the dataset here
                        objDS = new DataSet();
                        objDA = new SqlDataAdapter((SqlCommand)cmd);
                        objDA.Fill(objDS);
                    }
                    //cmd.Parameters 
                    bReturn = true;
                }
                else
                { return false; }
            }
            catch (Exception ex)
            {
                m_strErrorMessage = ex.Message;
            }
            finally
            {
                objDA = null;
                cmd = null;
            }
            return bReturn;
        }

        public bool SPQueryDataset(string strSP, SqlParameter[] objInParams, ref DataSet objDS)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlParameter objParam = default(SqlParameter);
                    SqlDataAdapter objDA = default(SqlDataAdapter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 180;

                        if ((objInParams != null))
                        {
                            foreach (DbParameter DbPar in objInParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Input;
                            }
                        }
                        objDS = new DataSet();
                        objDA = new SqlDataAdapter((SqlCommand)cmd);
                        objDA.Fill(objDS);
                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        objDA = null;
                        cmd = null;
                    }

                    return bReturn;
                }
                else
                { return false; }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SPQueryDatasetOutputParam(string strSP, SqlParameter[] objInParams, ref DataSet objDS, ref SqlParameter[] objOutParams)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlParameter objParam = default(SqlParameter);
                    SqlDataAdapter objDA = default(SqlDataAdapter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 180;

                        if ((objInParams != null))
                        {
                            foreach (DbParameter DbPar in objInParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Input;
                            }
                        }

                        if ((objOutParams != null))
                        {
                            foreach (DbParameter DbPar in objOutParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Output;
                            }
                        }
                        objDS = new DataSet();
                        objDA = new SqlDataAdapter((SqlCommand)cmd);
                        objDA.Fill(objDS);
                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        objDA = null;
                        cmd = null;
                    }

                    return bReturn;
                }
                else
                { return false; }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SPQueryOutputParam(string strSP, SqlParameter[] objInParams, ref SqlParameter[] objOutParams, bool bExNonQuery)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                // if (OpenConnection(strConn))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlParameter objParam = default(SqlParameter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;

                        if ((objInParams != null))
                        {
                            foreach (DbParameter DbPar in objInParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Input;
                            }
                        }

                        if ((objOutParams != null))
                        {
                            foreach (DbParameter DbPar in objOutParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Output;
                            }
                        }

                        if (bExNonQuery)
                        {
                            cmd.ExecuteNonQuery();
                            //objParamCol = cmd.Parameters;
                        }

                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        cmd = null;
                    }
                    return bReturn;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SPQueryExecuteNonQuery(string strSP, SqlParameter[] objInParams)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlParameter objParam = default(SqlParameter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;

                        if ((objInParams != null))
                        {
                            foreach (DbParameter DbPar in objInParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Input;
                            }
                        }

                        //if ((objOutParams != null))
                        //{
                        //    foreach (DbParameter DbPar in objOutParams)
                        //    {
                        //        objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                        //        objParam.Direction = ParameterDirection.Output;
                        //    }
                        //}

                        //if (bExNonQuery)
                        //{
                        cmd.ExecuteNonQuery();
                        //objParamCol = cmd.Parameters;
                        //}

                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        cmd = null;
                    }
                    return bReturn;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SPQueryDatasetNoParams(string strSP, ref DataSet objDS)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlDataAdapter objDA = default(SqlDataAdapter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;

                        objDS = new DataSet();
                        objDA = new SqlDataAdapter((SqlCommand)cmd);
                        objDA.Fill(objDS);
                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        objDA = null;
                        cmd = null;
                    }

                    return bReturn;
                }
                else
                { return false; }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SPQueryDatasetwithoutParameters(string strSP, ref DataSet objDS)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                // if (OpenConnection(strConn))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlParameter objParam = default(SqlParameter);
                    SqlDataAdapter objDA = default(SqlDataAdapter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 180;


                        objDS = new DataSet();
                        objDA = new SqlDataAdapter((SqlCommand)cmd);
                        objDA.Fill(objDS);
                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        objDA = null;
                        cmd = null;
                    }

                    return bReturn;
                }
                else
                { return false; }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool SPQueryDatasetwithonlyoutParameters(string strSP, ref SqlParameter[] objOutParams)
        {
            try
            {
                if (OpenConnection("Password=admin;User ID=MUREO_Admin;Initial Catalog=mureo;Data Source=BDC-SQLD002.na.pg.com\\DEVNT210"))
                // if (OpenConnection(strConn))
                {
                    bool bReturn = false;
                    SqlCommand cmd = null;
                    SqlParameter objParam = default(SqlParameter);
                    try
                    {
                        if ((m_AdoConnection == null))
                        {
                            m_strErrorMessage = "Database connection is not opened.";
                            return bReturn;
                        }

                        if ((m_AdoTransaction == null))
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection);
                        }
                        else
                        {
                            cmd = new SqlCommand(strSP, (SqlConnection)m_AdoConnection, (SqlTransaction)m_AdoTransaction);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;


                        if ((objOutParams != null))
                        {
                            foreach (DbParameter DbPar in objOutParams)
                            {
                                objParam = ((SqlCommand)cmd).Parameters.Add((SqlParameter)DbPar);
                                objParam.Direction = ParameterDirection.Output;
                            }
                        }
                        cmd.ExecuteNonQuery();
                        bReturn = true;
                    }
                    catch (Exception ex)
                    {
                        m_strErrorMessage = ex.Message;
                    }
                    finally
                    {
                        cmd = null;
                    }
                    return bReturn;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string ConfigurationManager { get; set; }
    }
}
