using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MUREOPROP
{
    public class ObjSiteTest
    {
        #region "Declarations"
        string m_strLastError;
        bool bReturn = false;
        private int intSiteTestID;
        
        private int intPlantType;
        
        private string strCurrentStage;
        
        private int intEONumber;
        
        private string intSAPIONumber;
        
        private int intCategoryID;
        
        private string strStatus;
        
        private string strStageStatus;
        
        private string strBrands;
        
        private string intEOID;
        
        private int intProjectID;
        
        private int intPlantID;
        
        private string strEvents;
        
        private string strTitle;
        
        private string strEONumber;
        
        private string strOriginator;
        
        private string strCoOrginator;
        
        private string strOfficeNumber;
        
        private string strPhoneNumber;
        
        private string strCommsntsToApprover;
        
        private string strPreStatus;
        
        private string strPreIsRouted;
        
        private string strFinalStatus;
        
        private string strFinalIsRouted;
        
        private string strCloseOutStatus;
        
        private string strCloseOutIsRouted;
        
        private DateTime dtTestStartDate;
        
        private DateTime dtTestEndDate;
        
        private string strDescription;
        
        private string strObjective;
        
        private string strMemo;
        
        private string strAffectedLinesMachines;
        
        private string strFinalReportDue;
        
        private string strTestPlans;
        
        private string strOthersupportingDoc;
        
        private string strStMode;
        
        // Final Report
        private string strFinalReportAttachment;
        
        private string strAdditionalInfo;
        
        private string strNewChemicalChange;
        
        private string strNewRawMaterialChange;
        
        private string strNewEquipProcessSystem;
        
        private string strNewJobTaskChange;
        
        private string strIsChemicalApprovalNeeded;
        
        // Chemical Approval Description
        private string strPrecautionUSE;
        
        private string strPrecautionSAMPLING;
        
        private string strPrecautionStorage;
        
        private string strPrecautionEquipment;
        
        private string strDisposalUnUsedChemical;
        
        private string strSpillResponse;
        
        private string strPotentialEnvironmentalImpact;
        
        private string strUserName;
        
        //  Pilot Paper Machine
        private string strRunInvestigateModule;
        
        private string strTestCoordinator;
        
        private Decimal decimalPPMNumberOfDays;
        
        private DateTime dtPPMPreferredRunDate;
        
        private DateTime dtPPMEarliestRunDates;
        
        private DateTime dtPPMLatestRunDates;
        
        private string strPPMConsumerTestProduction;
        
        private int intEquDryingFormat;
        
        private int intEquPMFormat;
        
        private int intEquHeadboxType;
        
        private string strMatIsKarlinal;
        
        private Decimal decimalMatKarlinalGallons;
        
        private string strMatCPNBelts;
        
        private string strMatPatterPerBelt;
        
        private string strPPMOtherUniqueReq;
        
        private string strPPMOtherEquipment;
        
        private string strPPMOtherMaterial;
        
        private string strPPMOtherOther;
        
        // End Of Pilot Paper Machine
        //  Converting Lines
        private string strConvTestCoordinator;
        
        private Decimal decimalConvNumberOfDays;
        
        private DateTime dtConvPreferredRunDate;
        
        private DateTime dtConvEarliestRunDates;
        
        private DateTime dtConvLatestRunDates;
        
        private string strConvConsumerTestProduction;
        
        private int intEquPreferredConvLine;
        
        private int intEquAltConvLine;
        
        private int intEquELSetup;
        
        private string strEquEmbossPattern;
        
        private string strEquHotMelt;
        
        private string strEquIsExtrusionHeads;
        
        private Decimal decimlaEquExtrusionHeadsCount;
        
        private string strEquIsHeadsHeated;
        
        private string strEquIsStream;
        
        private string strNewStorageConcers;
        
        private string strMatIsStdProcessInk;
        
        private Decimal decimlaMatYellowGallons;
        
        private Decimal decimlaMatCyanGallons;
        
        private Decimal decimlaMatMagentaGallons;
        
        private Decimal decimlaMatBlackGallons;
        
        private string strConvOtherUniqueReq;
        
        private string strConvOtherEquipment;
        
        private string strConvOtherMaterial;
        
        private string strConvOtherOther;
        
        private int intSiteTest;
        
        private int intConAppID;
        
        // Concurrence Group
        private string strConGrpName;
        
        private string strApprNameList;
        
        private string strIsMailSent;
        
        private DateTime dtEmailSentDate;
        
        private string strIsResponded;
        
        private string strComment;
        
        private string strPlantName;
        
        private DateTime dtRespondedDate;
        
        private int intConGrpID;
        
        private string strTwoTabRoute;
        
        private string strSmart_Clearance_Number;
        #endregion

        #region "Properties"

        // End OF Converting Lines
        // @p_Conv_Test_Coordinator    VARCHAR(100) ,
        // @p_Conv_Number_Of_Days        DECIMAL(9,2),
        // @p_Conv_Preferred_Run_Date        DATETIME,
        // @p_Conv_Earliest_Run_Dates        DATETIME,
        // @p_Conv_Latest_Run_Dates        DATETIME,
        // @p_Conv_Consumer_Test_Production    CHAR(1) ,
        // @p_Equ_Preferred_Conv_Line    INT,
        // @p_Equ_Alt_Conv_Line        INT,
        // @p_Equ_EL_Setup            INT,
        // @p_Equ_Emboss_Pattern        VARCHAR(100),
        // @p_Equ_Hot_Melt            CHAR(1) ,
        // @p_Equ_Is_Extrusion_Heads    CHAR(1) ,
        // @p_Equ_Extrusion_Heads_Count    DECIMAL(9,2),
        // @p_Equ_Is_Heads_Heated        CHAR(1) ,
        // @p_Equ_Is_Stream        CHAR(1) ,
        // @p_Mat_Is_Std_Process_Ink    CHAR(1) ,
        // @p_Mat_Yellow_Gallons        DECIMAL(9,2),
        // @p_Mat_Magenta_Gallons        DECIMAL(9,2),
        // @p_Mat_Cyan_Gallons        DECIMAL(9,2),
        // @p_Mat_Black_Gallons        DECIMAL(9,2),
        // @p_Conv_Other_Unique_Req        VARCHAR(100),
        // @p_Conv_Other_Equipment        VARCHAR(1000),
        // @p_Conv_Other_Material        VARCHAR(1000),
        // @p_Conv_Other_Other            VARCHAR(1000),
        // @p_Run_Investigate_Module    CHAR(1),
        // @p_Test_COordinator        VARCHAR(100),
        // @p_PPM_Number_Of_Days        DECIMAL(9,2),
        // @p_PPM_Preferred_Run_Date        DATETIME,
        // @p_PPM_Earliest_Run_Dates        DATETIME,
        // @p_PPM_Latest_Run_Dates        DATETIME,
        // @p_PPM_Consumer_Test_Production    CHAR(1),
        // @p_Equ_Drying_Format        INT,
        // @p_Equ_PM_Format        INT,
        // @p_Equ_Headbox_Type        INT,
        // @p_Mat_Is_Karlinal        CHAR(1),
        // @p_Mat_Karlinal_Gallons        DECIMAL(9,2),
        // @p_Mat_CPN_Belts        CHAR(1),
        // @p_Mat_Patter_Per_Belt        VARCHAR(100),
        // @p_PPM_Other_Unique_Req        VARCHAR(100),
        // @p_PPM_Other_Equipment        VARCHAR(1000),
        // @p_PPM_Other_Material        VARCHAR(1000),
        // @p_PPM_Other_Other    
        //     'Chemical Approval Description
        // @p_Precaution_USE        VARCHAR(1000),
        // @p_Precaution_SAMPLING        VARCHAR(1000),
        // @p_Precaution_STORAGE        VARCHAR(1000),
        // @p_Precaution_EQUIPMENT        VARCHAR(1000),
        // @p_Disposal_UnUsed_Chemical    VARCHAR(1000),
        // @p_Spill_Response        VARCHAR(1000),
        // @p_Potential_Environmental_Impact    VARCHAR(1000),
        // @p_User_Name             VARCHAR(100),
        // @p_Status            CHAR(1) = 'A',
        // @p_Result_No             INT OUTPUT)
        // @p_Final_Report_Attachment    VARCHAR(1000),
        //                 @p_Additional_Info        VARCHAR(1000),
        //                 @p_New_Chemical_Change        CHAR(1),
        //                 @p_New_Raw_Material_Change    CHAR(1),
        //                 @p_New_Equip_Process_System    CHAR(1),
        //                 @p_New_Job_Task_Change        CHAR(1),
        //                 @p_Is_Chemical_Approval_Needed    CHAR(1)    ,    
        // @p_Test_Start_Date        DATETIME,
        // @p_Test_End_Date        DATETIME,
        // @p_Description            VARCHAR(1000),
        // @p_Objective            VARCHAR(1000),
        // @p_Memo                VARCHAR(1000),
        // @p_Affected_Lines_Machines    VARCHAR(1000),
        // @p_Final_Report_Due        VARCHAR(1000),
        // @p_Test_Plans            VARCHAR(1000),
        // @p_Other_Supporting_Doc        VARCHAR(1000),
        // @p_ST_Mode    
        public string TwoTabRoute {
            get {
                return strTwoTabRoute;
            }
            set {
                strTwoTabRoute = value;
            }
        }
        
        public string Smart_Clearance_Number {
            get {
                return strSmart_Clearance_Number;
            }
            set {
                strSmart_Clearance_Number = value;
            }
        }
        
        public string PlantName {
            get {
                return strPlantName;
            }
            set {
                strPlantName = value;
            }
        }
        
        public string StageStatus {
            get {
                return strStageStatus;
            }
            set {
                strStageStatus = value;
            }
        }
        
        public int ConAppID {
            get {
                return intConAppID;
            }
            set {
                intConAppID = value;
            }
        }
        
        public int ConGrpID {
            get {
                return intConGrpID;
            }
            set {
                intConGrpID = value;
            }
        }
        
        public string Comment {
            get {
                return strComment;
            }
            set {
                strComment = value;
            }
        }
        
        public int SiteTestID {
            get {
                return intSiteTestID;
            }
            set {
                intSiteTestID = value;
            }
        }
        
        public int SiteTest {
            get {
                return intSiteTest;
            }
            set {
                intSiteTest = value;
            }
        }
        
        public int PlantType {
            get {
                return intPlantType;
            }
            set {
                intPlantType = value;
            }
        }
        
        public string CurrentStage {
            get {
                return strCurrentStage;
            }
            set {
                strCurrentStage = value;
            }
        }
        
        public string IsResponded {
            get {
                return strIsResponded;
            }
            set {
                strIsResponded = value;
            }
        }
        
        public DateTime RespondedDate {
            get {
                return dtRespondedDate;
            }
            set {
                dtRespondedDate = value;
            }
        }
        
        public string ApprNameList {
            get {
                return strApprNameList;
            }
            set {
                strApprNameList = value;
            }
        }
        
        public string IsMailSent {
            get {
                return strIsMailSent;
            }
            set {
                strIsMailSent = value;
            }
        }
        
        public string ConGrpName {
            get {
                return strConGrpName;
            }
            set {
                strConGrpName = value;
            }
        }
        
        public string Status {
            get {
                return strStatus;
            }
            set {
                strStatus = value;
            }
        }
        
        public string Title {
            get {
                return strTitle;
            }
            set {
                strTitle = value;
            }
        }
        
        public string EONumber {
            get {
                return strEONumber;
            }
            set {
                strEONumber = value;
            }
        }
        
        public string SAPIONumber {
            get {
                return intSAPIONumber;
            }
            set {
                intSAPIONumber = value;
            }
        }
        
        public int CategoryID {
            get {
                return intCategoryID;
            }
            set {
                intCategoryID = value;
            }
        }
        
        public string Brands {
            get {
                return strBrands;
            }
            set {
                strBrands = value;
            }
        }
        
        public string EOID {
            get {
                return intEOID;
            }
            set {
                intEOID = value;
            }
        }
        
        public int ProjectID {
            get {
                return intProjectID;
            }
            set {
                intProjectID = value;
            }
        }
        
        public int PlantID {
            get {
                return intPlantID;
            }
            set {
                intPlantID = value;
            }
        }
        
        public string EventIDs {
            get {
                return strEvents;
            }
            set {
                strEvents = value;
            }
        }
        
        public string Originator {
            get {
                return strOriginator;
            }
            set {
                strOriginator = value;
            }
        }
        
        public string CoOrginator {
            get {
                return strCoOrginator;
            }
            set {
                strCoOrginator = value;
            }
        }
        
        public string OfficeNumber {
            get {
                return strOfficeNumber;
            }
            set {
                strOfficeNumber = value;
            }
        }
        
        public string PhoneNumber {
            get {
                return strPhoneNumber;
            }
            set {
                strPhoneNumber = value;
            }
        }
        
        public string CommsntsToApprover {
            get {
                return strCommsntsToApprover;
            }
            set {
                strCommsntsToApprover = value;
            }
        }
        
        public DateTime TestStartDate {
            get {
                return dtTestStartDate;
            }
            set {
                dtTestStartDate = value;
            }
        }
        
        public DateTime EmailSentDate {
            get {
                return dtEmailSentDate;
            }
            set {
                dtEmailSentDate = value;
            }
        }
        
        public DateTime TestEndDate {
            get {
                return dtTestEndDate;
            }
            set {
                dtTestEndDate = value;
            }
        }
        
        public string Description {
            get {
                return strDescription;
            }
            set {
                strDescription = value;
            }
        }
        
        public string Objective {
            get {
                return strObjective;
            }
            set {
                strObjective = value;
            }
        }
        
        public string Memo {
            get {
                return strMemo;
            }
            set {
                strMemo = value;
            }
        }
        
        public string AffectedLinesMachines {
            get {
                return strAffectedLinesMachines;
            }
            set {
                strAffectedLinesMachines = value;
            }
        }
        
        public string FinalReportDue {
            get {
                return strFinalReportDue;
            }
            set {
                strFinalReportDue = value;
            }
        }
        
        public string TestPlans {
            get {
                return strTestPlans;
            }
            set {
                strTestPlans = value;
            }
        }
        
        public string OtherSupprtingDoc {
            get {
                return strOthersupportingDoc;
            }
            set {
                strOthersupportingDoc = value;
            }
        }
        
        public string StMode {
            get {
                return strStMode;
            }
            set {
                strStMode = value;
            }
        }
        
        public string FinalReportAttachment {
            get {
                return strFinalReportAttachment;
            }
            set {
                strFinalReportAttachment = value;
            }
        }
        
        public string AdditionalInfo {
            get {
                return strAdditionalInfo;
            }
            set {
                strAdditionalInfo = value;
            }
        }
        
        public string NewChemicalChange {
            get {
                return strNewChemicalChange;
            }
            set {
                strNewChemicalChange = value;
            }
        }
        
        public string NewRawMaterialChange {
            get {
                return strNewRawMaterialChange;
            }
            set {
                strNewRawMaterialChange = value;
            }
        }
        
        public string NewEquipProcessSystem {
            get {
                return strNewEquipProcessSystem;
            }
            set {
                strNewEquipProcessSystem = value;
            }
        }
        
        public string NewJobTaskChange {
            get {
                return strNewJobTaskChange;
            }
            set {
                strNewJobTaskChange = value;
            }
        }
        
        public string NewStorageConcers {
            get {
                return strNewStorageConcers;
            }
            set {
                strNewStorageConcers = value;
            }
        }
        
        public string IsChemicalApprovalNeeded {
            get {
                return strIsChemicalApprovalNeeded;
            }
            set {
                strIsChemicalApprovalNeeded = value;
            }
        }
        
        public string PrecautionUSE {
            get {
                return strPrecautionUSE;
            }
            set {
                strPrecautionUSE = value;
            }
        }
        
        public string PrecautionSAMPLING {
            get {
                return strPrecautionSAMPLING;
            }
            set {
                strPrecautionSAMPLING = value;
            }
        }
        
        public string PrecautionStorage {
            get {
                return strPrecautionStorage;
            }
            set {
                strPrecautionStorage = value;
            }
        }
        
        public string PrecautionEquipment {
            get {
                return strPrecautionEquipment;
            }
            set {
                strPrecautionEquipment = value;
            }
        }
        
        public string DisposalUnUsedChemical {
            get {
                return strDisposalUnUsedChemical;
            }
            set {
                strDisposalUnUsedChemical = value;
            }
        }
        
        public string SpillResponse {
            get {
                return strSpillResponse;
            }
            set {
                strSpillResponse = value;
            }
        }
        
        public string PotentialEnvironmentalImpact {
            get {
                return strPotentialEnvironmentalImpact;
            }
            set {
                strPotentialEnvironmentalImpact = value;
            }
        }
        
        public string UserName {
            get {
                return strUserName;
            }
            set {
                strUserName = value;
            }
        }
        
        public string RunInvestigateModule {
            get {
                return strRunInvestigateModule;
            }
            set {
                strRunInvestigateModule = value;
            }
        }
        
        public string TestCoordinator {
            get {
                return strTestCoordinator;
            }
            set {
                strTestCoordinator = value;
            }
        }
        
        public Decimal PPMNumberOfDays {
            get {
                return decimalPPMNumberOfDays;
            }
            set {
                decimalPPMNumberOfDays = value;
            }
        }
        
        public DateTime PPMPreferredRunDate {
            get {
                return dtPPMPreferredRunDate;
            }
            set {
                dtPPMPreferredRunDate = value;
            }
        }
        
        public DateTime PPMEarliestRunDates {
            get {
                return dtPPMEarliestRunDates;
            }
            set {
                dtPPMEarliestRunDates = value;
            }
        }
        
        public DateTime PPMLatestRunDates {
            get {
                return dtPPMLatestRunDates;
            }
            set {
                dtPPMLatestRunDates = value;
            }
        }
        
        public string PPMConsumerTestProduction {
            get {
                return strPPMConsumerTestProduction;
            }
            set {
                strPPMConsumerTestProduction = value;
            }
        }
        
        public int EquPMFormat {
            get {
                return intEquPMFormat;
            }
            set {
                intEquPMFormat = value;
            }
        }
        
        public int EquDryingFormat {
            get {
                return intEquDryingFormat;
            }
            set {
                intEquDryingFormat = value;
            }
        }
        
        public int EquHeadboxType {
            get {
                return intEquHeadboxType;
            }
            set {
                intEquHeadboxType = value;
            }
        }
        
        public string MatIsKarlinal {
            get {
                return strMatIsKarlinal;
            }
            set {
                strMatIsKarlinal = value;
            }
        }
        
        public Decimal MatKarlinalGallons {
            get {
                return decimalMatKarlinalGallons;
            }
            set {
                decimalMatKarlinalGallons = value;
            }
        }
        
        public string MatCPNBelts {
            get {
                return strMatCPNBelts;
            }
            set {
                strMatCPNBelts = value;
            }
        }
        
        public string MatPatterPerBelt {
            get {
                return strMatPatterPerBelt;
            }
            set {
                strMatPatterPerBelt = value;
            }
        }
        
        public string PPMOtherUniqueReq {
            get {
                return strPPMOtherUniqueReq;
            }
            set {
                strPPMOtherUniqueReq = value;
            }
        }
        
        public string PPMOtherEquipment {
            get {
                return strPPMOtherEquipment;
            }
            set {
                strPPMOtherEquipment = value;
            }
        }
        
        public string PPMOtherMaterial {
            get {
                return strPPMOtherMaterial;
            }
            set {
                strPPMOtherMaterial = value;
            }
        }
        
        public string PPMOtherOther {
            get {
                return strPPMOtherOther;
            }
            set {
                strPPMOtherOther = value;
            }
        }
        
        public string ConvTestCoordinator {
            get {
                return strConvTestCoordinator;
            }
            set {
                strConvTestCoordinator = value;
            }
        }
        
        public Decimal ConvNumberOfDays {
            get {
                return decimalConvNumberOfDays;
            }
            set {
                decimalConvNumberOfDays = value;
            }
        }
        
        public DateTime ConvPreferredRunDate {
            get {
                return dtConvPreferredRunDate;
            }
            set {
                dtConvPreferredRunDate = value;
            }
        }
        
        public DateTime ConvEarliestRunDates {
            get {
                return dtConvEarliestRunDates;
            }
            set {
                dtConvEarliestRunDates = value;
            }
        }
        
        public string ConvConsumerTestProduction {
            get {
                return strConvConsumerTestProduction;
            }
            set {
                strConvConsumerTestProduction = value;
            }
        }
        
        public int EquPreferredConvLine {
            get {
                return intEquPreferredConvLine;
            }
            set {
                intEquPreferredConvLine = value;
            }
        }
        
        public int EquAltConvLine {
            get {
                return intEquAltConvLine;
            }
            set {
                intEquAltConvLine = value;
            }
        }
        
        public int EquELSetup {
            get {
                return intEquELSetup;
            }
            set {
                intEquELSetup = value;
            }
        }
        
        public string EquEmbossPattern {
            get {
                return strEquEmbossPattern;
            }
            set {
                strEquEmbossPattern = value;
            }
        }
        
        public string EquHotMelt {
            get {
                return strEquHotMelt;
            }
            set {
                strEquHotMelt = value;
            }
        }
        
        public string EquIsExtrusionHeads {
            get {
                return strEquIsExtrusionHeads;
            }
            set {
                strEquIsExtrusionHeads = value;
            }
        }
        
        public string EquIsHeadsHeated {
            get {
                return strEquIsHeadsHeated;
            }
            set {
                strEquIsHeadsHeated = value;
            }
        }
        
        public string EquIsStream {
            get {
                return strEquIsStream;
            }
            set {
                strEquIsStream = value;
            }
        }
        
        public Decimal EquExtrusionHeadsCount {
            get {
                return decimlaEquExtrusionHeadsCount;
            }
            set {
                decimlaEquExtrusionHeadsCount = value;
            }
        }
        
        public string MatIsStdProcessInk {
            get {
                return strMatIsStdProcessInk;
            }
            set {
                strMatIsStdProcessInk = value;
            }
        }
        
        public Decimal MatYellowGallons {
            get {
                return decimlaMatYellowGallons;
            }
            set {
                decimlaMatYellowGallons = value;
            }
        }
        
        public Decimal MatCyanGallons {
            get {
                return decimlaMatCyanGallons;
            }
            set {
                decimlaMatCyanGallons = value;
            }
        }
        
        public Decimal MatMagentaGallons {
            get {
                return decimlaMatMagentaGallons;
            }
            set {
                decimlaMatMagentaGallons = value;
            }
        }
        
        public Decimal MatBlackGallons {
            get {
                return decimlaMatBlackGallons;
            }
            set {
                decimlaMatBlackGallons = value;
            }
        }
        
        public string ConvOtherUniqueReq {
            get {
                return strConvOtherUniqueReq;
            }
            set {
                strConvOtherUniqueReq = value;
            }
        }
        
        public string ConvOtherEquipment {
            get {
                return strConvOtherEquipment;
            }
            set {
                strConvOtherEquipment = value;
            }
        }
        
        public string ConvOtherMaterial {
            get {
                return strConvOtherMaterial;
            }
            set {
                strConvOtherMaterial = value;
            }
        }
        
        public string ConvOtherOther {
            get {
                return strConvOtherOther;
            }
            set {
                strConvOtherOther = value;
            }
        }
        
        public DateTime ConvLatestRunDates {
            get {
                return dtConvLatestRunDates;
            }
            set {
                dtConvLatestRunDates = value;
            }
        }
        #endregion

        #region "Methods"
        //public bool SetEOMandatory(ObjSiteTest objSiteTest, ref SqlParameter[] paramOut)
        //{
        //    //Variable Declarations
        //    bool bReturn = false;
        //    SqlParameter[] paramIn = new SqlParameter[17];
        //    paramOut = new SqlParameter[2];
        //    DBPool objDBPool = null;
        //    //DataSet ds = null;
        //    try
        //    {
        //        //SqlParameterCollection spc = null;
        //        paramIn[0] = new SqlParameter("@p_EO_ID", objSiteTest.EOID);
        //        paramIn[1] = new SqlParameter("@p_EO_Title", objSiteTest.Title);
        //        paramIn[2] = new SqlParameter("@p_Event_ID_List", objSiteTest.EventIDs);
        //        paramIn[3] = new SqlParameter("@p_Project_ID", objSiteTest.ProjectID);
        //        paramIn[4] = new SqlParameter("@p_Plant_ID", objSiteTest.PlantID);
        //        paramIn[5] = new SqlParameter("@p_Category_ID", objSiteTest.CategoryID);
        //        paramIn[6] = new SqlParameter("@p_Originator", objSiteTest.Originator);
        //        paramIn[7] = new SqlParameter("@p_Office_Num", objSiteTest.OfficeNumber);
        //        paramIn[8] = new SqlParameter("@p_Phone_Num", objSiteTest.PhoneNumber);
        //        paramIn[9] = new SqlParameter("@p_Brand_Seg_ID_List", objSiteTest.Brands);
        //        paramIn[10] = new SqlParameter("@p_CoOriginator", objSiteTest.CoOrginator);
        //        paramIn[11] = new SqlParameter("@p_Comments_To_Approver", objSiteTest.CommsntsToApprover);
        //        paramIn[12] = new SqlParameter("@p_Current_Stage", DBNull.Value);
        //        paramIn[13] = new SqlParameter("@p_Stage_Status", objSiteTest.StageStatus);
        //        paramIn[14] = new SqlParameter("@p_EO_Mode", "S");
        //        if ((objSiteTest.TwoTabRoute == ""))
        //        {
        //            paramIn[15] = new SqlParameter("@p_Two_Tab_Routing", "N");
        //        }
        //        else
        //        {
        //            paramIn[15] = new SqlParameter("@p_Two_Tab_Routing", objSiteTest.TwoTabRoute);
        //        }
        //        if ((objSiteTest.Smart_Clearance_Number == ""))
        //        {
        //            paramIn[16] = new SqlParameter("@p_SMART_Clearance_Number", DBNull.Value);
        //        }
        //        else
        //        {
        //            paramIn[16] = new SqlParameter("@p_SMART_Clearance_Number", objSiteTest.Smart_Clearance_Number);
        //        }




        //        paramOut[0] = new SqlParameter("@p_New_EO_ID", SqlDbType.Int);
        //        paramOut[0].Direction = ParameterDirection.Output;
        //        paramOut[1] = new SqlParameter("@p_Result_No", SqlDbType.Int);
        //        paramOut[1].Direction = ParameterDirection.Output;
        //        objDBPool = new DBPool();
        //        if ((objDBPool.SPQueryOutputParam("SET_EO_Mandatory", paramIn, ref paramOut, true)))
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
        #endregion
    }
}
