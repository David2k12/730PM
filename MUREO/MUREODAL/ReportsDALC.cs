using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MUREODAL;

namespace MUREOUI
{
    public class ReportsDALC
    {
        #region "Functions"
        string m_strLastError=string.Empty;
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GET_MUR_Events_By_Project_Or_Plant()
        //Written BY	    :	Chary
        //parameters     :	None
        //Purpose	    :   To get all the projects associated with plant
        //Returns        :   to Bussiness Object
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/21/08              Chary             1.0           created
        ////***************************************************
        ////
        //public DataSet GET_MUR_Projects_By_Plant(int intPlantID)
        //{
        //    System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[1];
        //    @params[0] = new System.Data.SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int);
        //    @params[0].Value = intPlantID;
        //    return DatabaseHelper.ExecuteDataSet("GET_MUR_Projects_By_Plant", @params);
        //}



        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	GET_MUR_Events_By_Project_Or_Plant()
        ////Written BY	    :	Chary
        ////parameters     :	None
        ////Purpose	    :   To getting Events information
        ////Returns        :   to Bussiness Object
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////05/19/08              Chary             1.0           created
        ////***************************************************
        ////
        //public DataSet GET_MUR_Events_By_Project_Or_Plant(int intPlantID, int intProjectID)
        //{
        //    System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[2];
        //    @params[0] = new System.Data.SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int);
        //    @params[0].Value = intPlantID;
        //    @params[1] = new System.Data.SqlClient.SqlParameter("@p_Project_ID", SqlDbType.Int);
        //    @params[1].Value = intProjectID;
        //    return DatabaseHelper.ExecuteDataSet("GET_MUR_Events_By_Project_Or_Plant", @params);
        //}

        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	GET_MUR_Project()
        ////Written BY	    :	Chary
        ////parameters     :	None
        ////Purpose	    :   To getting Project information
        ////Returns        :   to Bussiness Object
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////05/19/08              Chary             1.0           created
        ////***************************************************
        ////
        //public DataSet GET_MUR_Project()
        //{
        //    return DatabaseHelper.ExecuteDataSet("GET_MUR_Project");
        //}

        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	GET_MUR_Plant()
        ////Written BY	    :	Chary
        ////parameters     :	None
        ////Purpose	    :   To getting plant information
        ////Returns        :   to Bussiness Object
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////05/19/08              Chary             1.0           created
        ////***************************************************
        ////
        //public DataSet GET_MUR_Plant()
        //{
        //    System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[1];
        //    @params[0] = new System.Data.SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int);
        //    @params[0].Value = 0;
        //    return DatabaseHelper.ExecuteDataSet("GET_MUR_Plant", @params);
        //}


        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillProjectsByCategory()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Project by category details from database.
        //Returns        :   to Bussiness Object
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07                 Bharath             1.0           created
        //***************************************************
        //
        //public DataSet FillProjectsByCategoryDALC()
        //{
        //    return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Projects_By_Category");
        //}
        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillEventsByProjectTypeDALC()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Events by Project deatails from database.
        //Returns        :   to Bussiness Object
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/24/07                 Bharath             1.0           created
        //***************************************************
        //
        //public DataSet FillEventsByProjectTypeDALC()
        //{
        //    return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Events_By_Project_Type");
        //}
        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillEventsByProjectTypDetailseDALC()
        //Written BY	    :	Bharath
        //parameters     :	Project Type,brand,project,plant id
        //Purpose	    :   To getting Events by Project deatails based on project,brand,plant id
        //Returns        :   to Bussiness Object
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/24/07                 Bharath             1.0           created
        //***************************************************
        //
        //public DataSet FillEventsByProjectTypDetailseDALC(int intProjectTypeID, int intBrandID, int intPlantID, int intProjectID)
        //{
        //    System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[4];

        //    @params[0] = new System.Data.SqlClient.SqlParameter("@p_Project_Type_ID", SqlDbType.Int);
        //    @params[0].Value = intProjectTypeID;

        //    @params[1] = new System.Data.SqlClient.SqlParameter("@p_Brand_Segment_ID", SqlDbType.Int);
        //    @params[1].Value = intBrandID;

        //    @params[2] = new System.Data.SqlClient.SqlParameter("@p_Plant_ID", SqlDbType.Int);
        //    @params[2].Value = intPlantID;

        //    @params[3] = new System.Data.SqlClient.SqlParameter("@p_Project_ID", SqlDbType.Int);
        //    @params[3].Value = intProjectID;

        //    return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_Events_By_Project_Type_Details", @params);
        //}
        ////
        ////  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillMyEventsDALC()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Logged User Events from database.
        //Returns        :   to Bussiness Object
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath             1.0           created
        //***************************************************
        ////
        //public DataSet FillMyEventsDALC(string strUserName)
        //{

        //    System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[1];

        //    if (string.IsNullOrEmpty(strUserName))
        //    {
        //        @params[0] = new System.Data.SqlClient.SqlParameter("@p_User_Name", Convert.DBNull);
        //    }
        //    else
        //    {
        //        @params[0] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
        //        @params[0].Value = strUserName;
        //    }


        //    return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_MyEvents_By_Project_Type", @params);
        //}

        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillMyEventsDetailseDALC()
        //Written BY	    :	Bharath
        //parameters     :	Project Type,project,plant id
        //Purpose	    :   To getting Events  deatails based on Project Type,project,plant id
        //Returns        :   to Bussiness Object
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath             1.0           created
        //***************************************************
        //
        public bool FillMyEventsDetailseDALC(string strUserName, ref DataSet objDS)
        {

            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_User_Name", strUserName);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_MyEvents_By_Project_Type_Details", paramIn, ref objDS)))
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

            //System.Data.SqlClient.SqlParameter[] @params = new SqlClient.SqlParameter[1];

            //@params[0] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
            //@params[0].Value = strUserName;

            //return DatabaseHelper.ExecuteDataSet("dbo.GET_MUR_MyEvents_By_Project_Type_Details", @params);
        }
        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillProjectsByBrand()
        //Written BY	    :	Raja Ramesh Varma
        //parameters     :	Category ID, Brand ID
        //Purpose	    :   For getting project details from database.
        //Returns        :   to Business object
        //Program Change History:
        //<Date>	        	         <Editor>	      	<Rev>		<Description>
        //08/27/2007               Raja Ramesh Varma     1.0           created
        //***************************************************
        ////
        //public DataSet FillProjectsByBrand(int categoryID, int brandID)
        //{
        //    System.Data.SqlClient.SqlParameter[] @params = new System.Data.SqlClient.SqlParameter[2];

        //    @params[0] = new System.Data.SqlClient.SqlParameter("@p_Category_ID", SqlDbType.Int);
        //    @params[0].Value = categoryID;

        //    @params[1] = new System.Data.SqlClient.SqlParameter("@p_Brand_Segment_ID", SqlDbType.Int);
        //    @params[1].Value = brandID;

        //    return DatabaseHelper.ExecuteDataSet("GET_MUR_Projects_By_Category_Details", @params);
        //}
        #endregion

    }
}