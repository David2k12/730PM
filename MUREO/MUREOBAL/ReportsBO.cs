using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MUREODAL;

namespace MUREOUI
{
    public class ReportsBO
    {
        string m_strLastError;
        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GET_MUR_Projects_By_Plant()
        //Written BY	    :	Chary
        //parameters     :	None
        //Purpose	    :   To get all the projects associated with plant
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/21/08                 Chary              1.0           created
        //***************************************************
        ////
        //public DataSet GET_MUR_Projects_By_Plant(int intPlantID)
        //{
        //    ReportsDALC objEventsByProjects = new ReportsDALC();
        //    return objEventsByProjects.GET_MUR_Projects_By_Plant(intPlantID);
        //}

        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GET_MUR_Plant()
        //Written BY	    :	Chary
        //parameters     :	None
        //Purpose	    :   To getting Plant information
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/19/08                 Chary              1.0           created
        //***************************************************
        //
        //public DataSet GET_MUR_Events_By_Project_Or_Plant(int intPlantID, int intProjectID)
        //{
        //    ReportsDALC objEventsByProjects = new ReportsDALC();
        //    return objEventsByProjects.GET_MUR_Events_By_Project_Or_Plant(intPlantID, intProjectID);
        //}

        //
        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GET_MUR_Plant()
        //Written BY	    :	Chary
        //parameters     :	None
        //Purpose	    :   To getting Plant information
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/19/08                 Chary              1.0           created
        //***************************************************
        ////
        //public DataSet GET_MUR_Plant()
        //{
        //    ReportsDALC objEventsByProjects = new ReportsDALC();
        //    return objEventsByProjects.GET_MUR_Plant;
        //}


        //**************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	GET_MUR_Project()
        //Written BY	    :	Chary
        //parameters     :	None
        //Purpose	    :   To getting Project information
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //05/19/08                 Chary              1.0           created
        ////***************************************************
        ////
        //public DataSet GET_MUR_Project()
        //{
        //    ReportsDALC objEventsByProjects = new ReportsDALC();
        //    return objEventsByProjects.GET_MUR_Project;
        //}


        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillProjectsByCategory()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Project by category from database.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07                 Bharath             1.0           created
        ////***************************************************
        ////
        //public DataSet FillProjectsByCategoryBO()
        //{
        //    ReportsDALC objProjectsByCategory = new ReportsDALC();
        //    return objProjectsByCategory.FillProjectsByCategoryDALC();
        //}
        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillProjectsByCategory()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Project by category from database.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/17/07                 Bharath             1.0           created
        //***************************************************
        ////
        //public DataSet FillEventsByProjectTypeBO()
        //{
        //    ReportsDALC objEventsByProjects = new ReportsDALC();
        //    return objEventsByProjects.FillEventsByProjectTypeDALC();
        //}





        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillEventsByProjectTypDetailseBO()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Events by PRojects from database.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/24/07                 Bharath             1.0           created
        //***************************************************
        ////
        //public DataSet FillEventsByProjectTypDetailseBO(int intProjectTypeID, int intBrandID, int intPlantID, int intProjectID)
        //{
        //    ReportsDALC objEventsByProjects = new ReportsDALC();
        //    return objEventsByProjects.FillEventsByProjectTypDetailseDALC(intProjectTypeID, intBrandID, intPlantID, intProjectID);
        //}
        ////
        ////  ************************************************
        ////Developed by   :	Vertex Computer Systems, Inc.,
        ////Name   	    :	FillMyEventsBO()
        ////Written BY	    :	Bharath
        ////parameters     :	None
        ////Purpose	    :   To getting Logged User Events from database.
        ////Returns        :   to GUI
        ////Program Change History:
        ////<Date>			         <Editor>	      	<Rev>		<Description>
        ////07/25/07                 Bharath             1.0           created
        ////***************************************************
        ////
        //public DataSet FillMyEventsBO(string strUserName)
        //{
        //    ReportsDALC objMyEvents = new ReportsDALC();
        //    return objMyEvents.FillMyEventsDALC(strUserName);
        //}
        ////
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillEventsByProjectTypDetailseBO()
        //Written BY	    :	Bharath
        //parameters     :	None
        //Purpose	    :   To getting Event details from database.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>			         <Editor>	      	<Rev>		<Description>
        //07/25/07                 Bharath             1.0           created
        //***************************************************
        //
        public bool FillMyEventDetailseBO(string strUserName, ref DataSet dsMyEventDetails)
        {

            //This will be returned back.
            bool bReturn = false;
            //Init the data access layer object here
            ReportsDALC objEODA = null;
            DBPool objDBPool = null;
            try
            {
                objEODA = new ReportsDALC();
                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Call the data access function here
                if (objEODA.FillMyEventsDetailseDALC(strUserName, ref dsMyEventDetails))
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
        //
        //  ************************************************
        //Developed by   :	Vertex Computer Systems, Inc.,
        //Name   	    :	FillProjectsByBrand()
        //Written BY	    :	Raja Ramesh Varma
        //parameters     :	Category ID, Brand ID
        //Purpose	    :   For getting project details from database.
        //Returns        :   to GUI
        //Program Change History:
        //<Date>	        	         <Editor>	      	<Rev>		<Description>
        //08/27/2007               Raja Ramesh Varma     1.0           created
        //***************************************************
        ////
        //public DataSet FillProjectsByBrand(int categoryID, int brandID)
        //{
        //    ReportsDALC objReports = new ReportsDALC();
        //    return objReports.FillProjectsByBrand(categoryID, brandID);
        //}

    }
}