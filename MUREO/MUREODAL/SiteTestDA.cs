using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MUREOPROP;

namespace MUREODAL
{
    public class SiteTestDA
    {
        string m_strLastError;

        public string GetLastError()
        {
            //Return last error message here
            return m_strLastError;
        }

        public bool GetMessage(int helpID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@Help_Page_ID", helpID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Help_Page_Value", paramIn, ref objDS)))
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

        public bool UpdateSiteTest(ObjSiteTest objSiteTestProp, ref SqlParameter[] paramOut)
        {//Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[71];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //@p_EO_ID
                paramIn[0] = new System.Data.SqlClient.SqlParameter("@p_Site_Test_ID", SqlDbType.Int);
                paramIn[0].Value = objSiteTestProp.SiteTestID;
                //@p_EO_Title
                paramIn[1] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[1].Value = objSiteTestProp.EOID;
                //@p_Event_ID_List
                paramIn[2] = new System.Data.SqlClient.SqlParameter("@p_Test_Start_Date", SqlDbType.DateTime);
                if (objSiteTestProp.TestStartDate == System.DateTime.MinValue)
                {
                    paramIn[2].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[2].Value = objSiteTestProp.TestStartDate;
                }
                //@p_Project_ID
                paramIn[3] = new System.Data.SqlClient.SqlParameter("@p_Test_End_Date", SqlDbType.DateTime);
                if (objSiteTestProp.TestEndDate == System.DateTime.MinValue)
                {
                    paramIn[3].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[3].Value = objSiteTestProp.TestEndDate;
                }
                //@p_Plant_ID
                paramIn[4] = new System.Data.SqlClient.SqlParameter("@p_Description", SqlDbType.VarChar);
                paramIn[4].Value = objSiteTestProp.Description;
                //@p_Category_ID
                paramIn[5] = new System.Data.SqlClient.SqlParameter("@p_Objective", SqlDbType.VarChar);
                paramIn[5].Value = objSiteTestProp.Objective;
                //@p_Originator
                paramIn[6] = new System.Data.SqlClient.SqlParameter("@p_Memo", SqlDbType.VarChar);
                paramIn[6].Value = objSiteTestProp.Memo;
                //@p_Office_Num
                paramIn[7] = new System.Data.SqlClient.SqlParameter("@p_Affected_Lines_Machines", SqlDbType.VarChar);
                paramIn[7].Value = objSiteTestProp.AffectedLinesMachines;
                //@p_Phone_Num
                paramIn[8] = new System.Data.SqlClient.SqlParameter("@p_Final_Report_Due", SqlDbType.VarChar);
                paramIn[8].Value = objSiteTestProp.FinalReportDue;
                //@p_Brand_Seg_ID_List
                paramIn[9] = new System.Data.SqlClient.SqlParameter("@p_Test_Plans", SqlDbType.VarChar);
                paramIn[9].Value = objSiteTestProp.TestPlans;

                paramIn[10] = new System.Data.SqlClient.SqlParameter("@p_Other_Supporting_Doc", SqlDbType.VarChar);
                paramIn[10].Value = objSiteTestProp.OtherSupprtingDoc;

                paramIn[11] = new System.Data.SqlClient.SqlParameter("@p_ST_Mode", SqlDbType.Char);
                paramIn[11].Value = objSiteTestProp.StMode;

                paramIn[12] = new System.Data.SqlClient.SqlParameter("@p_Final_Report_Attachment", SqlDbType.VarChar);
                paramIn[12].Value = objSiteTestProp.FinalReportAttachment;

                paramIn[13] = new System.Data.SqlClient.SqlParameter("@p_Additional_Info ", SqlDbType.VarChar);
                paramIn[13].Value = objSiteTestProp.AdditionalInfo;
                //objSiteTestProp.CloseOutStatus

                paramIn[14] = new System.Data.SqlClient.SqlParameter("@p_New_Chemical_Change", SqlDbType.Char);
                paramIn[14].Value = objSiteTestProp.NewChemicalChange;
                paramIn[15] = new System.Data.SqlClient.SqlParameter("@p_New_Raw_Material_Change", SqlDbType.Char);
                paramIn[15].Value = objSiteTestProp.NewRawMaterialChange;

                paramIn[16] = new System.Data.SqlClient.SqlParameter("@p_New_Equip_Process_System", SqlDbType.VarChar);
                paramIn[16].Value = objSiteTestProp.NewEquipProcessSystem;
                //@p_Stage_Status 
                paramIn[17] = new System.Data.SqlClient.SqlParameter("@p_New_Job_Task_Change ", SqlDbType.VarChar);
                paramIn[17].Value = objSiteTestProp.NewJobTaskChange;
                //objSiteTestProp.CloseOutStatus
                //@p_New_EO_ID
                paramIn[18] = new System.Data.SqlClient.SqlParameter("@p_Is_Chemical_Approval_Needed", SqlDbType.Char);
                paramIn[18].Value = objSiteTestProp.IsChemicalApprovalNeeded;


                //Convert Line
                paramIn[19] = new System.Data.SqlClient.SqlParameter("@p_Conv_Test_Coordinator", SqlDbType.VarChar);
                paramIn[19].Value = objSiteTestProp.ConvTestCoordinator;
                paramIn[20] = new System.Data.SqlClient.SqlParameter("@p_Conv_Number_Of_Days", SqlDbType.Decimal);
                paramIn[20].Value = objSiteTestProp.ConvNumberOfDays;

                paramIn[21] = new System.Data.SqlClient.SqlParameter("@p_Conv_Preferred_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.ConvPreferredRunDate == System.DateTime.MinValue)
                {
                    paramIn[21].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[21].Value = objSiteTestProp.ConvPreferredRunDate;
                }

                paramIn[22] = new System.Data.SqlClient.SqlParameter("@p_Conv_Earliest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.ConvEarliestRunDates == System.DateTime.MinValue)
                {
                    paramIn[22].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[22].Value = objSiteTestProp.ConvEarliestRunDates;
                }
                //objSiteTestProp.CloseOutStatus

                paramIn[23] = new System.Data.SqlClient.SqlParameter("@p_Conv_Latest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.ConvLatestRunDates == System.DateTime.MinValue)
                {
                    paramIn[23].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[23].Value = objSiteTestProp.ConvLatestRunDates;
                }
                paramIn[24] = new System.Data.SqlClient.SqlParameter("@p_Conv_Consumer_Test_Production", SqlDbType.Char);
                paramIn[24].Value = objSiteTestProp.ConvConsumerTestProduction;

                paramIn[25] = new System.Data.SqlClient.SqlParameter("@p_Equ_Preferred_Conv_Line", SqlDbType.Int);
                paramIn[25].Value = objSiteTestProp.EquPreferredConvLine;



                paramIn[26] = new System.Data.SqlClient.SqlParameter("@p_Equ_Alt_Conv_Line ", SqlDbType.Int);
                paramIn[26].Value = objSiteTestProp.EquAltConvLine;



                paramIn[26] = new System.Data.SqlClient.SqlParameter("@p_Equ_Alt_Conv_Line ", SqlDbType.Int);
                paramIn[26].Value = objSiteTestProp.EquAltConvLine;
                //objSiteTestProp.CloseOutStatus

                paramIn[27] = new System.Data.SqlClient.SqlParameter("@p_Equ_EL_Setup", SqlDbType.Int);
                paramIn[27].Value = objSiteTestProp.EquELSetup;
                paramIn[28] = new System.Data.SqlClient.SqlParameter("@p_Equ_Emboss_Pattern", SqlDbType.VarChar);
                paramIn[28].Value = objSiteTestProp.EquEmbossPattern;

                paramIn[29] = new System.Data.SqlClient.SqlParameter("@p_Equ_Hot_Melt", SqlDbType.Char);
                paramIn[29].Value = objSiteTestProp.EquHotMelt;

                paramIn[30] = new System.Data.SqlClient.SqlParameter("@p_Equ_Is_Extrusion_Heads", SqlDbType.Char);
                paramIn[30].Value = objSiteTestProp.EquIsExtrusionHeads;

                paramIn[31] = new System.Data.SqlClient.SqlParameter("@p_Equ_Extrusion_Heads_Count", SqlDbType.Decimal);
                paramIn[31].Value = objSiteTestProp.EquExtrusionHeadsCount;

                paramIn[32] = new System.Data.SqlClient.SqlParameter("@p_Equ_Is_Heads_Heated", SqlDbType.Char);
                paramIn[32].Value = objSiteTestProp.EquIsHeadsHeated;

                paramIn[33] = new System.Data.SqlClient.SqlParameter("@p_Equ_Is_Stream", SqlDbType.Char);
                paramIn[33].Value = objSiteTestProp.EquIsStream;

                paramIn[34] = new System.Data.SqlClient.SqlParameter("@p_Mat_Is_Std_Process_Ink ", SqlDbType.Char);
                paramIn[34].Value = objSiteTestProp.MatIsStdProcessInk;
                //objSiteTestProp.CloseOutStatus

                paramIn[35] = new System.Data.SqlClient.SqlParameter("@p_Mat_Yellow_Gallons", SqlDbType.Decimal);
                paramIn[35].Value = objSiteTestProp.MatYellowGallons;
                paramIn[36] = new System.Data.SqlClient.SqlParameter("@p_Mat_Magenta_Gallons", SqlDbType.Decimal);
                paramIn[36].Value = objSiteTestProp.MatMagentaGallons;

                paramIn[37] = new System.Data.SqlClient.SqlParameter("@p_Mat_Cyan_Gallons", SqlDbType.Decimal);
                paramIn[37].Value = objSiteTestProp.MatCyanGallons;

                paramIn[38] = new System.Data.SqlClient.SqlParameter("@p_Mat_Black_Gallons ", SqlDbType.Decimal);
                paramIn[38].Value = objSiteTestProp.MatBlackGallons;

                paramIn[39] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Unique_Req", SqlDbType.VarChar);
                paramIn[39].Value = objSiteTestProp.ConvOtherUniqueReq;

                paramIn[40] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Equipment", SqlDbType.VarChar);
                paramIn[40].Value = objSiteTestProp.ConvOtherEquipment;

                paramIn[41] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Material", SqlDbType.VarChar);
                paramIn[41].Value = objSiteTestProp.ConvOtherMaterial;

                paramIn[42] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Other ", SqlDbType.VarChar);
                paramIn[42].Value = objSiteTestProp.ConvOtherOther;
                //objSiteTestProp.CloseOutStatus

                //End of Convert Line

                //Paper Machine
                paramIn[43] = new System.Data.SqlClient.SqlParameter("@p_Run_Investigate_Module", SqlDbType.Char);
                paramIn[43].Value = objSiteTestProp.RunInvestigateModule;
                paramIn[44] = new System.Data.SqlClient.SqlParameter("@p_Test_COordinator", SqlDbType.VarChar);
                paramIn[44].Value = objSiteTestProp.TestCoordinator;

                paramIn[45] = new System.Data.SqlClient.SqlParameter("@p_PPM_Number_Of_Days", SqlDbType.Decimal);
                paramIn[45].Value = objSiteTestProp.PPMNumberOfDays;

                paramIn[46] = new System.Data.SqlClient.SqlParameter("@p_PPM_Preferred_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.PPMPreferredRunDate == System.DateTime.MinValue)
                {
                    paramIn[46].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[46].Value = objSiteTestProp.PPMPreferredRunDate;
                }

                paramIn[47] = new System.Data.SqlClient.SqlParameter("@p_PPM_Earliest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.PPMEarliestRunDates == System.DateTime.MinValue)
                {
                    paramIn[47].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[47].Value = objSiteTestProp.PPMEarliestRunDates;
                }
                paramIn[48] = new System.Data.SqlClient.SqlParameter("@p_PPM_Latest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.PPMLatestRunDates == System.DateTime.MinValue)
                {
                    paramIn[48].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[48].Value = objSiteTestProp.PPMLatestRunDates;
                }

                paramIn[49] = new System.Data.SqlClient.SqlParameter("@p_PPM_Consumer_Test_Production", SqlDbType.Char);
                paramIn[49].Value = objSiteTestProp.PPMConsumerTestProduction;
                paramIn[50] = new System.Data.SqlClient.SqlParameter("@p_Equ_Drying_Format", SqlDbType.Int);
                paramIn[50].Value = objSiteTestProp.EquDryingFormat;
                paramIn[51] = new System.Data.SqlClient.SqlParameter("@p_Equ_PM_Format", SqlDbType.Int);
                paramIn[51].Value = objSiteTestProp.EquPMFormat;
                paramIn[52] = new System.Data.SqlClient.SqlParameter("@p_Equ_Headbox_Type", SqlDbType.Int);
                paramIn[52].Value = objSiteTestProp.EquHeadboxType;

                paramIn[53] = new System.Data.SqlClient.SqlParameter("@p_Mat_Is_Karlinal", SqlDbType.Char);
                paramIn[53].Value = objSiteTestProp.MatIsKarlinal;

                paramIn[54] = new System.Data.SqlClient.SqlParameter("@p_Mat_Karlinal_Gallons", SqlDbType.Decimal);
                paramIn[54].Value = objSiteTestProp.MatKarlinalGallons;

                paramIn[55] = new System.Data.SqlClient.SqlParameter("@p_Mat_CPN_Belts", SqlDbType.Char);
                paramIn[55].Value = objSiteTestProp.MatCPNBelts;

                paramIn[56] = new System.Data.SqlClient.SqlParameter("@p_Mat_Patter_Per_Belt ", SqlDbType.VarChar);
                paramIn[56].Value = objSiteTestProp.MatPatterPerBelt;

                paramIn[57] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Unique_Req", SqlDbType.VarChar);
                paramIn[57].Value = objSiteTestProp.PPMOtherUniqueReq;

                paramIn[58] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Equipment", SqlDbType.VarChar);
                paramIn[58].Value = objSiteTestProp.PPMOtherEquipment;

                paramIn[59] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Material", SqlDbType.VarChar);
                paramIn[59].Value = objSiteTestProp.PPMOtherMaterial;

                paramIn[60] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Other ", SqlDbType.VarChar);
                paramIn[60].Value = objSiteTestProp.PPMOtherOther;

                //End of Paper Machine

                //Chemical Approval Description

                paramIn[61] = new System.Data.SqlClient.SqlParameter("@p_Precaution_USE", SqlDbType.VarChar);
                paramIn[61].Value = objSiteTestProp.PrecautionUSE;
                paramIn[62] = new System.Data.SqlClient.SqlParameter("@p_Precaution_SAMPLING", SqlDbType.VarChar);
                paramIn[62].Value = objSiteTestProp.PrecautionSAMPLING;

                paramIn[63] = new System.Data.SqlClient.SqlParameter("@p_Precaution_STORAGE", SqlDbType.VarChar);
                paramIn[63].Value = objSiteTestProp.PrecautionStorage;

                paramIn[64] = new System.Data.SqlClient.SqlParameter("@p_Precaution_EQUIPMENT", SqlDbType.VarChar);
                paramIn[64].Value = objSiteTestProp.PrecautionEquipment;

                paramIn[65] = new System.Data.SqlClient.SqlParameter("@p_Disposal_UnUsed_Chemical", SqlDbType.VarChar);
                paramIn[65].Value = objSiteTestProp.DisposalUnUsedChemical;

                paramIn[66] = new System.Data.SqlClient.SqlParameter("@p_Spill_Response", SqlDbType.VarChar);
                paramIn[66].Value = objSiteTestProp.SpillResponse;


                paramIn[67] = new System.Data.SqlClient.SqlParameter("@p_Potential_Environmental_Impact", SqlDbType.VarChar);
                paramIn[67].Value = objSiteTestProp.PotentialEnvironmentalImpact;

                paramIn[68] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[68].Value = objSiteTestProp.UserName;

                paramIn[69] = new System.Data.SqlClient.SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[69].Value = "A";
                paramIn[70] = new System.Data.SqlClient.SqlParameter("@p_New_Storage_Concers", SqlDbType.VarChar);
                paramIn[70].Value = objSiteTestProp.NewStorageConcers;


                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Site_Test", paramIn, ref paramOut, true)))
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

        public bool AddSiteTest(ObjSiteTest objSiteTestProp, ref SqlParameter[] paramOut)
        {//Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[71];
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //@p_EO_ID
                paramIn[0] = new System.Data.SqlClient.SqlParameter("@p_Site_Test_ID", SqlDbType.Int);
                paramIn[0].Value = 0;
                //@p_EO_Title
                paramIn[1] = new System.Data.SqlClient.SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[1].Value = objSiteTestProp.EOID;
                //@p_Event_ID_List
                paramIn[2] = new System.Data.SqlClient.SqlParameter("@p_Test_Start_Date", SqlDbType.DateTime);
                if (objSiteTestProp.TestStartDate == System.DateTime.MinValue)
                {
                    paramIn[2].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[2].Value = objSiteTestProp.TestStartDate;
                }

                //@p_Project_ID
                paramIn[3] = new System.Data.SqlClient.SqlParameter("@p_Test_End_Date", SqlDbType.DateTime);
                if (objSiteTestProp.TestEndDate == System.DateTime.MinValue)
                {
                    paramIn[3].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[3].Value = objSiteTestProp.TestEndDate;
                }

                //@p_Plant_ID
                paramIn[4] = new System.Data.SqlClient.SqlParameter("@p_Description", SqlDbType.VarChar);
                paramIn[4].Value = objSiteTestProp.Description;
                //@p_Category_ID
                paramIn[5] = new System.Data.SqlClient.SqlParameter("@p_Objective", SqlDbType.VarChar);
                paramIn[5].Value = objSiteTestProp.Objective;
                //@p_Originator
                paramIn[6] = new System.Data.SqlClient.SqlParameter("@p_Memo", SqlDbType.VarChar);
                paramIn[6].Value = objSiteTestProp.Memo;
                //@p_Office_Num
                paramIn[7] = new System.Data.SqlClient.SqlParameter("@p_Affected_Lines_Machines", SqlDbType.VarChar);
                paramIn[7].Value = objSiteTestProp.AffectedLinesMachines;
                //@p_Phone_Num
                paramIn[8] = new System.Data.SqlClient.SqlParameter("@p_Final_Report_Due", SqlDbType.VarChar);
                paramIn[8].Value = objSiteTestProp.FinalReportDue;
                //@p_Brand_Seg_ID_List
                paramIn[9] = new System.Data.SqlClient.SqlParameter("@p_Test_Plans", SqlDbType.VarChar);
                paramIn[9].Value = objSiteTestProp.TestPlans;

                paramIn[10] = new System.Data.SqlClient.SqlParameter("@p_Other_Supporting_Doc", SqlDbType.VarChar);
                paramIn[10].Value = objSiteTestProp.OtherSupprtingDoc;

                paramIn[11] = new System.Data.SqlClient.SqlParameter("@p_ST_Mode", SqlDbType.Char);
                paramIn[11].Value = objSiteTestProp.StMode;

                paramIn[12] = new System.Data.SqlClient.SqlParameter("@p_Final_Report_Attachment", SqlDbType.VarChar);
                paramIn[12].Value = objSiteTestProp.FinalReportAttachment;

                paramIn[13] = new System.Data.SqlClient.SqlParameter("@p_Additional_Info ", SqlDbType.VarChar);
                paramIn[13].Value = objSiteTestProp.AdditionalInfo;
                //objSiteTestProp.CloseOutStatus

                paramIn[14] = new System.Data.SqlClient.SqlParameter("@p_New_Chemical_Change", SqlDbType.Char);
                paramIn[14].Value = objSiteTestProp.NewChemicalChange;
                paramIn[15] = new System.Data.SqlClient.SqlParameter("@p_New_Raw_Material_Change", SqlDbType.Char);
                paramIn[15].Value = objSiteTestProp.NewRawMaterialChange;

                paramIn[16] = new System.Data.SqlClient.SqlParameter("@p_New_Equip_Process_System", SqlDbType.VarChar);
                paramIn[16].Value = objSiteTestProp.NewEquipProcessSystem;
                //@p_Stage_Status 
                paramIn[17] = new System.Data.SqlClient.SqlParameter("@p_New_Job_Task_Change ", SqlDbType.VarChar);
                paramIn[17].Value = objSiteTestProp.NewJobTaskChange;
                //objSiteTestProp.CloseOutStatus
                //@p_New_EO_ID
                paramIn[18] = new System.Data.SqlClient.SqlParameter("@p_Is_Chemical_Approval_Needed", SqlDbType.Char);
                paramIn[18].Value = objSiteTestProp.IsChemicalApprovalNeeded;


                //Convert Line
                paramIn[19] = new System.Data.SqlClient.SqlParameter("@p_Conv_Test_Coordinator", SqlDbType.VarChar);
                paramIn[19].Value = objSiteTestProp.ConvTestCoordinator;
                paramIn[20] = new System.Data.SqlClient.SqlParameter("@p_Conv_Number_Of_Days", SqlDbType.Decimal);
                paramIn[20].Value = objSiteTestProp.ConvNumberOfDays;

                paramIn[21] = new System.Data.SqlClient.SqlParameter("@p_Conv_Preferred_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.ConvPreferredRunDate == System.DateTime.MinValue)
                {
                    paramIn[21].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[21].Value = objSiteTestProp.ConvPreferredRunDate;
                }

                paramIn[22] = new System.Data.SqlClient.SqlParameter("@p_Conv_Earliest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.ConvEarliestRunDates == System.DateTime.MinValue)
                {
                    paramIn[22].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[22].Value = objSiteTestProp.ConvEarliestRunDates;
                }
                //objSiteTestProp.CloseOutStatus

                paramIn[23] = new System.Data.SqlClient.SqlParameter("@p_Conv_Latest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.ConvLatestRunDates == System.DateTime.MinValue)
                {
                    paramIn[23].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[23].Value = objSiteTestProp.ConvLatestRunDates;
                }


                paramIn[24] = new System.Data.SqlClient.SqlParameter("@p_Conv_Consumer_Test_Production", SqlDbType.Char);
                paramIn[24].Value = objSiteTestProp.ConvConsumerTestProduction;

                paramIn[25] = new System.Data.SqlClient.SqlParameter("@p_Equ_Preferred_Conv_Line", SqlDbType.Int);
                paramIn[25].Value = objSiteTestProp.EquPreferredConvLine;



                paramIn[26] = new System.Data.SqlClient.SqlParameter("@p_Equ_Alt_Conv_Line ", SqlDbType.Int);
                paramIn[26].Value = objSiteTestProp.EquAltConvLine;



                paramIn[26] = new System.Data.SqlClient.SqlParameter("@p_Equ_Alt_Conv_Line ", SqlDbType.Int);
                paramIn[26].Value = objSiteTestProp.EquAltConvLine;
                //objSiteTestProp.CloseOutStatus

                paramIn[27] = new System.Data.SqlClient.SqlParameter("@p_Equ_EL_Setup", SqlDbType.Int);
                paramIn[27].Value = objSiteTestProp.EquELSetup;
                paramIn[28] = new System.Data.SqlClient.SqlParameter("@p_Equ_Emboss_Pattern", SqlDbType.VarChar);
                paramIn[28].Value = objSiteTestProp.EquEmbossPattern;

                paramIn[29] = new System.Data.SqlClient.SqlParameter("@p_Equ_Hot_Melt", SqlDbType.Char);
                paramIn[29].Value = objSiteTestProp.EquHotMelt;

                paramIn[30] = new System.Data.SqlClient.SqlParameter("@p_Equ_Is_Extrusion_Heads", SqlDbType.Char);
                paramIn[30].Value = objSiteTestProp.EquIsExtrusionHeads;

                paramIn[31] = new System.Data.SqlClient.SqlParameter("@p_Equ_Extrusion_Heads_Count", SqlDbType.Decimal);
                paramIn[31].Value = objSiteTestProp.EquExtrusionHeadsCount;

                paramIn[32] = new System.Data.SqlClient.SqlParameter("@p_Equ_Is_Heads_Heated", SqlDbType.Char);
                paramIn[32].Value = objSiteTestProp.EquIsHeadsHeated;

                paramIn[33] = new System.Data.SqlClient.SqlParameter("@p_Equ_Is_Stream", SqlDbType.Char);
                paramIn[33].Value = objSiteTestProp.EquIsStream;

                paramIn[34] = new System.Data.SqlClient.SqlParameter("@p_Mat_Is_Std_Process_Ink ", SqlDbType.Char);
                paramIn[34].Value = objSiteTestProp.MatIsStdProcessInk;
                //objSiteTestProp.CloseOutStatus

                paramIn[35] = new System.Data.SqlClient.SqlParameter("@p_Mat_Yellow_Gallons", SqlDbType.Decimal);
                paramIn[35].Value = objSiteTestProp.MatYellowGallons;
                paramIn[36] = new System.Data.SqlClient.SqlParameter("@p_Mat_Magenta_Gallons", SqlDbType.Decimal);
                paramIn[36].Value = objSiteTestProp.MatMagentaGallons;

                paramIn[37] = new System.Data.SqlClient.SqlParameter("@p_Mat_Cyan_Gallons", SqlDbType.Decimal);
                paramIn[37].Value = objSiteTestProp.MatCyanGallons;

                paramIn[38] = new System.Data.SqlClient.SqlParameter("@p_Mat_Black_Gallons ", SqlDbType.Decimal);
                paramIn[38].Value = objSiteTestProp.MatBlackGallons;

                paramIn[39] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Unique_Req", SqlDbType.VarChar);
                paramIn[39].Value = objSiteTestProp.ConvOtherUniqueReq;

                paramIn[40] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Equipment", SqlDbType.VarChar);
                paramIn[40].Value = objSiteTestProp.ConvOtherEquipment;

                paramIn[41] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Material", SqlDbType.VarChar);
                paramIn[41].Value = objSiteTestProp.ConvOtherMaterial;

                paramIn[42] = new System.Data.SqlClient.SqlParameter("@p_Conv_Other_Other ", SqlDbType.VarChar);
                paramIn[42].Value = objSiteTestProp.ConvOtherOther;
                //objSiteTestProp.CloseOutStatus

                //End of Convert Line

                //Paper Machine
                paramIn[43] = new System.Data.SqlClient.SqlParameter("@p_Run_Investigate_Module", SqlDbType.Char);
                paramIn[43].Value = objSiteTestProp.RunInvestigateModule;
                paramIn[44] = new System.Data.SqlClient.SqlParameter("@p_Test_COordinator", SqlDbType.VarChar);
                paramIn[44].Value = objSiteTestProp.TestCoordinator;

                paramIn[45] = new System.Data.SqlClient.SqlParameter("@p_PPM_Number_Of_Days", SqlDbType.Decimal);
                paramIn[45].Value = objSiteTestProp.PPMNumberOfDays;

                paramIn[46] = new System.Data.SqlClient.SqlParameter("@p_PPM_Preferred_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.PPMPreferredRunDate == System.DateTime.MinValue)
                {
                    paramIn[46].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[46].Value = objSiteTestProp.PPMPreferredRunDate;
                }

                paramIn[47] = new System.Data.SqlClient.SqlParameter("@p_PPM_Earliest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.PPMEarliestRunDates == System.DateTime.MinValue)
                {
                    paramIn[47].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[47].Value = objSiteTestProp.PPMEarliestRunDates;

                }
                paramIn[48] = new System.Data.SqlClient.SqlParameter("@p_PPM_Latest_Run_Dates", SqlDbType.DateTime);
                if (objSiteTestProp.PPMLatestRunDates == System.DateTime.MinValue)
                {
                    paramIn[48].Value = Convert.DBNull;
                }
                else
                {
                    paramIn[48].Value = objSiteTestProp.PPMLatestRunDates;
                }


                paramIn[49] = new System.Data.SqlClient.SqlParameter("@p_PPM_Consumer_Test_Production", SqlDbType.Char);
                paramIn[49].Value = objSiteTestProp.PPMConsumerTestProduction;
                paramIn[50] = new System.Data.SqlClient.SqlParameter("@p_Equ_Drying_Format", SqlDbType.Int);
                paramIn[50].Value = objSiteTestProp.EquDryingFormat;
                paramIn[51] = new System.Data.SqlClient.SqlParameter("@p_Equ_PM_Format", SqlDbType.Int);
                paramIn[51].Value = objSiteTestProp.EquPMFormat;
                paramIn[52] = new System.Data.SqlClient.SqlParameter("@p_Equ_Headbox_Type", SqlDbType.Int);
                paramIn[52].Value = objSiteTestProp.EquHeadboxType;

                paramIn[53] = new System.Data.SqlClient.SqlParameter("@p_Mat_Is_Karlinal", SqlDbType.Char);
                paramIn[53].Value = objSiteTestProp.MatIsKarlinal;

                paramIn[54] = new System.Data.SqlClient.SqlParameter("@p_Mat_Karlinal_Gallons", SqlDbType.Decimal);
                paramIn[54].Value = objSiteTestProp.MatKarlinalGallons;

                paramIn[55] = new System.Data.SqlClient.SqlParameter("@p_Mat_CPN_Belts", SqlDbType.Char);
                paramIn[55].Value = objSiteTestProp.MatCPNBelts;

                paramIn[56] = new System.Data.SqlClient.SqlParameter("@p_Mat_Patter_Per_Belt ", SqlDbType.VarChar);
                paramIn[56].Value = objSiteTestProp.MatPatterPerBelt;

                paramIn[57] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Unique_Req", SqlDbType.VarChar);
                paramIn[57].Value = objSiteTestProp.PPMOtherUniqueReq;

                paramIn[58] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Equipment", SqlDbType.VarChar);
                paramIn[58].Value = objSiteTestProp.PPMOtherEquipment;

                paramIn[59] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Material", SqlDbType.VarChar);
                paramIn[59].Value = objSiteTestProp.PPMOtherMaterial;

                paramIn[60] = new System.Data.SqlClient.SqlParameter("@p_PPM_Other_Other ", SqlDbType.VarChar);
                paramIn[60].Value = objSiteTestProp.PPMOtherOther;

                //End of Paper Machine

                //Chemical Approval Description

                paramIn[61] = new System.Data.SqlClient.SqlParameter("@p_Precaution_USE", SqlDbType.VarChar);
                paramIn[61].Value = objSiteTestProp.PrecautionUSE;
                paramIn[62] = new System.Data.SqlClient.SqlParameter("@p_Precaution_SAMPLING", SqlDbType.VarChar);
                paramIn[62].Value = objSiteTestProp.PrecautionSAMPLING;

                paramIn[63] = new System.Data.SqlClient.SqlParameter("@p_Precaution_STORAGE", SqlDbType.VarChar);
                paramIn[63].Value = objSiteTestProp.PrecautionStorage;

                paramIn[64] = new System.Data.SqlClient.SqlParameter("@p_Precaution_EQUIPMENT", SqlDbType.VarChar);
                paramIn[64].Value = objSiteTestProp.PrecautionEquipment;

                paramIn[65] = new System.Data.SqlClient.SqlParameter("@p_Disposal_UnUsed_Chemical", SqlDbType.VarChar);
                paramIn[65].Value = objSiteTestProp.DisposalUnUsedChemical;

                paramIn[66] = new System.Data.SqlClient.SqlParameter("@p_Spill_Response", SqlDbType.VarChar);
                paramIn[66].Value = objSiteTestProp.SpillResponse;


                paramIn[67] = new System.Data.SqlClient.SqlParameter("@p_Potential_Environmental_Impact", SqlDbType.VarChar);
                paramIn[67].Value = objSiteTestProp.PotentialEnvironmentalImpact;

                paramIn[68] = new System.Data.SqlClient.SqlParameter("@p_User_Name", SqlDbType.VarChar);
                paramIn[68].Value = objSiteTestProp.UserName;

                paramIn[69] = new System.Data.SqlClient.SqlParameter("@p_Status", SqlDbType.Char);
                paramIn[69].Value = "A";
                paramIn[70] = new System.Data.SqlClient.SqlParameter("@p_New_Storage_Concers", SqlDbType.VarChar);
                paramIn[70].Value = objSiteTestProp.NewStorageConcers;
             
                paramOut[0] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Site_Test", paramIn, ref paramOut, true)))
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

        public bool SetEOMandatory(ObjSiteTest objEO, ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[17];
            paramOut = new SqlParameter[2];
            DBPool objDBPool = null;
            try
            {
                //SqlParameterCollection spc = null;
                paramIn[0] = new SqlParameter("@p_EO_ID", SqlDbType.Int);
                paramIn[0].Value = objEO.EOID;
                if (objEO.Title == "")
                    paramIn[1] = new SqlParameter("@p_EO_Title", DBNull.Value);
                else
                    paramIn[1] = new SqlParameter("@p_EO_Title", objEO.Title);

                paramIn[2] = new SqlParameter("@p_Event_ID_List", objEO.EventIDs);
                paramIn[3] = new SqlParameter("@p_Project_ID", objEO.ProjectID);
                paramIn[4] = new SqlParameter("@p_Plant_ID", objEO.PlantID);
                paramIn[5] = new SqlParameter("@p_Category_ID", SqlDbType.Int);
                paramIn[5].Value = objEO.CategoryID;


                if (objEO.Originator == "")
                    paramIn[6] = new SqlParameter("@p_Originator", DBNull.Value);
                else
                    paramIn[6] = new SqlParameter("@p_Originator", objEO.Originator);

                if (objEO.OfficeNumber == "")
                    paramIn[7] = new SqlParameter("@p_Office_Num", DBNull.Value);
                else
                    paramIn[7] = new SqlParameter("@p_Office_Num", objEO.OfficeNumber);

                if (objEO.PhoneNumber == "")
                    paramIn[8] = new SqlParameter("@p_Phone_Num", DBNull.Value);
                else
                    paramIn[8] = new SqlParameter("@p_Phone_Num", objEO.PhoneNumber);

                if (objEO.Brands == "")
                    paramIn[9] = new SqlParameter("@p_Brand_Seg_ID_List", DBNull.Value);
                else
                    paramIn[9] = new SqlParameter("@p_Brand_Seg_ID_List", objEO.Brands);

                if (objEO.CoOrginator == "")
                    paramIn[10] = new SqlParameter("@p_CoOriginator", DBNull.Value);
                else
                    paramIn[10] = new SqlParameter("@p_CoOriginator", objEO.CoOrginator);


                if (objEO.CommsntsToApprover == "")
                    paramIn[11] = new SqlParameter("@p_Comments_To_Approver", DBNull.Value);
                else
                    paramIn[11] = new SqlParameter("@p_Comments_To_Approver", objEO.CommsntsToApprover);

                paramIn[12] = new SqlParameter("@p_Current_Stage", DBNull.Value);

                if (objEO.StageStatus == "")
                    paramIn[13] = new SqlParameter("@p_Stage_Status", DBNull.Value);
                else
                    paramIn[13] = new SqlParameter("@p_Stage_Status", objEO.StageStatus);

                paramIn[14] = new SqlParameter("@p_EO_Mode", "S");
                   

                if (objEO.TwoTabRoute == "")
                    paramIn[15] = new SqlParameter("@p_Two_Tab_Routing", DBNull.Value);
                else
                    paramIn[15] = new SqlParameter("@p_Two_Tab_Routing", objEO.TwoTabRoute);

                if (objEO.Smart_Clearance_Number == "" || objEO.Smart_Clearance_Number == null)
                    paramIn[16] = new SqlParameter("@p_SMART_Clearance_Number", DBNull.Value);
                else
                    paramIn[16] = new SqlParameter("@p_SMART_Clearance_Number", objEO.Smart_Clearance_Number);


                paramOut[0] = new SqlParameter("@p_New_EO_ID", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                paramOut[1] = new SqlParameter("@p_Result_No", SqlDbType.Int);
                paramOut[1].Direction = ParameterDirection.Output;

                objDBPool = new DBPool();
                if ((objDBPool.SPQueryOutputParam("SET_EO_Mandatory", paramIn, ref paramOut, true)))
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

        public bool GetAffectedMachine(int EventID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Event_ID", EventID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_MUR_Event", paramIn, ref objDS)))
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

        public bool FillEquipment(int EquipID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_Equipment_Type_ID", EquipID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Equipments", paramIn, ref objDS)))
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

        public bool GetSitetestID(ref SqlParameter[] paramOut)
        {
            //Variable Declarations
            bool bReturn = false;
            paramOut = new SqlParameter[1];
            DBPool objDBPool = null;
            //DataSet ds = null;
            try
            {
                paramOut[0] = new SqlParameter("@p_Max_Site_Test_ID", SqlDbType.Int);
                paramOut[0].Direction = ParameterDirection.Output;
                paramOut[0].Value = DBNull.Value;
                objDBPool = new DBPool();
                if ((objDBPool.SPQueryDatasetwithonlyoutParameters("GET_Max_Site_Test_ID", ref paramOut)))
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

        public bool GetsiteTest(int EquipID, ref DataSet objDS)
        {
            //Variable Declarations
            bool bReturn = false;
            SqlParameter[] paramIn = new SqlParameter[1];
            DBPool objDBPool = null;
            try
            {
                //Set procedure params here
                paramIn[0] = new SqlParameter("@p_EO_ID", EquipID);

                //Instantiate DBPool Object here
                objDBPool = new DBPool();
                //Calling the SPQueryDataset which is in the DBPOOL.
                if ((objDBPool.SPQueryDataset("GET_EO_Site_Test", paramIn, ref objDS)))
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
