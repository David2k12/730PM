using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUREOPROP
{
    public class objEO
    {
        private string strCurrentStage;
        private int intEONumber;
        private string intSAPIONumber;
        private int intCategoryID;
        private string strStatus;
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
        private string strCurrentStagePre;
        private string strStageStatus;
        // Primary tab values
        private string strEOtype;
        private int intEOScopeProjectType;
        private string strNewTypeOfEOType;
        private string strNewTypeofEOScope;
        private string strBriefDesc;
        private double dblTotPaperMaking;
        private double dblTotConverting;
        private double dblTotCostNewMaterials;
        private double dblCostofEOSpecific;
        private double dblTotPreSpend;
        private double dblEOExecuCost;
        private double dblTotCost;
        private int intSujBudgetCenter;
        private string strOtherBudgCenter;
        private string strSelectedBudgCenter;
        //section : New Materials and Brands 
        private string strNewRawPackage;
        private string strEOProduce;
        private string strEOProduceInterMaterial;
        private string strEOProduceRegProd;
        private string strappropriateGMP;
        private string strEOShippedTrade;

        private string strTestProdSample;
        //Added on 01/20/2010 
        //For MUREO PCRs
        //By: David

        private bool boolProdSelectIs_Understood_Policy_37;
        private bool boolProdSelectIs_Exception_Policy_37;

        private bool boolProdSelectIs_EO_Covered_Policy_37;
        private bool boolIs_Product_Go_To_Customers;

        private bool boolIs_Using_Approved_FC_R_ATS;
        private bool boolIs_Approved_At_Level;
        private bool boolIs_Approved_For_Region;
        private bool boolIs_Approved_For_Application;

        private bool boolIs_Approved_At_Prev_Application_Rate;
        private string strIs_Product_Go_To_Customers;

        private string strIs_Using_Approved_FC_R_ATS;
        private string strIs_Approved_At_Level;
        private string strIs_Approved_For_Region;
        private string strIs_Approved_For_Application;

        private string strIs_Approved_For_Application_Rate;
        //to be removed

        private string strTestProdSelectionCheckbox;
        private string strGCASUMOF;
        // GCAS numbers 
        private int intIsGCASRec;
        private string strGCASXMLStr;
        //section : HS&E
        private string strNewChemExistChem;
        private string strNewRawExistRaw;
        private string strNewEqipExistEuip;
        private string strNewjobExistjob;
        //section : PS&RA
        private string strPSRAType;
        private string intOtherPSRAType;
        // need to send PSRA numbers here
        private int intIsPSRA;
        private string strPSRAXMLStr;
        private string strPSRAIDList;
        private string strPSRAAdditionalInfo;
        //Section :Planning and Budget Information
        private int intPlantSite;
        private string strLineMachine;
        //Private strPlannedStartDate As String
        private System.DateTime strPlannedStartDate;
        private string strFormulaCardNumber;
        private string strIGCASNumber;
        //Section : Production and Packaging
        private string strFormats;
        private string strPPLabNotebookNumber;
        private string strPPAttachment;
        //Section : Packaging / Disposition Information
        private string strProductPacked;
        private string strCurPackage;
        private string strExpPackage;
        private string strPackagingList;
        private string strClearPoly;
        private string strBlankKDF;
        private int intProdDisposition;
        private string strAddCommnets;
        private string strPalletPatternYesNo;
        private string strStacTesting;
        private string strShipTesting;
        private int intMaterialDisposition;
        private string strMaterialDispoOtherComments;
        private string strEOgengreaternormalbroke;
        private string strPrintBroke;
        private string strPrintBrokeYesOption;
        private string strAdditionalItems;
        private string strLabNoteBook;
        private string strApproverCommnets;
        //Approval Section
        private string strEOSiteTestOther;
        private int intApprovalGroup;
        private string strBudgetOwner;
        private string strGBUHSEResource;
        private string strSiteHSEResource;
        private string strSiteContact;
        private string strSitePlanning;
        private string strCentralPlanning;
        private string strSAPCostCenter;
        private string strTimingGateException;
        private string strStandardsOffice;
        private string strFuncIDAppNameList;
        private string strRevHistoryDesc;
        private string strAppHistoryDesc;
        private string strPrevComments;
        //Final Tab 
        //-- Final Document section
        private string strBudgetCenterFinal;
        private string strNewChemicalChange;
        private string strNewRawMaterialChange;
        //Section : Packaging / Disposition Information in final tab
        private string strCurrentPackage;
        private string strCurrentPackagingType;
        private string strExperimentPackage;
        private string strProductPack;
        private string strBlankKDFFinal;
        private string strClearPolyFinal;
        private int intProdDispo;
        private string strOtherProdDispo;
        private string strEOUniquePalletPaterns;
        private string strEOUniqPaletPatStackTesing;
        private string strEOUniqPaletPatShipTesing;
        private int intMaterialDispostion;
        private string strMaterialDispoAddCommnets;
        private string strEOGraterNormalBroke;
        private string strEOPrintedBroke;
        private string strEOPrintedBrokeIncCov;
        private string strPDIAttachment;
        private string strPDILabNotebookNumber;
        //Section : Cost Sheet in final tab
        private string strAttaCostSheet;
        private string strFinalAttachQA;
        private decimal strEstmAmtCostSheet;
        // RadioButton
        private string strTotDiffCostSheet;
        private decimal strTotDiffCostSheetYesOpt;

        private string strAddCommnetsCostSheet;
        //Section : Formula Card Information in final tab
        private string intEOFormulaCardInformation;
        private string strattachFormulaCard;
        //Section : Test Plans in final tab
        private string strTestPlantAttachments;
        //Section : Lab Sampling Plans in final tab
        private string strCentralAnalyticalLab;
        private string strSiteTestingLab;
        private string strAttchLabforTesting;
        //Section : Product or Detailed Test Flow Matrix in final tab
        private string strProdDetailTest;
        //Section : Other Supporting Documentation in final tab
        private string strOtherSupAttach;
        private string strComments;
        //Section Approvals in final tab
        private string strTypeOfEO;
        private int strAppGrp;
        private string strFuncIDAppNameListFinal;
        private string strPSInitiativeManager;
        private string strProductsResearch;
        private string strBudgetOwnerfinal;
        private string strSiteHSEResourcefinal;
        private string strSAPCostCenterCoordi;
        private string strSitePlanningFinal;
        private string strSiteContactFinal;
        private string strSiteFinanceFinal;
        private string strSiteLeadershipfinal;
        private string strPSRAFinal;
        private string strTimingGateExceptionFinal;
        private string strQAFinal;
        private string strStandardsOfficeFinal;
        //thee lables in Final Tab
        //Close-Out Tab
        private string strLabNoteBookCO;
        //Private strCompletionDate As String
        private System.DateTime strCompletionDate;
        //Section : Actual Cost Sheet in Close out tab
        private string strAttFinalCostSheetCO;
        private string strAttCOILR;
        private decimal strTotCostSheetCO;
        //Section : Initial Learning Report
        private string strILRAttachment;
        //Section : Test Plans Used in close out tab
        private string strAttchTestPlanTepmpalteCO;
        private string strAttCOReport;
        //Section : Close Out Report in close out tab
        private string strKeyWords1CO;
        private string strKeyWords2CO;
        private string strKeyWords3CO;
        private string strKeyWords4CO;
        private string strKeyWords5CO;
        private string strKeyWords6CO;
        private string strCommentsApproverCO;
        //Section : Approvals in close out tab
        private string strEoTypeCloseOut;
        private int intAppGroupCloseOut;
        private string strSiteFinanceCO;
        private string strBudgetOwnerCO;
        private string strFuncIDAppNameListCloseOut;
        private string strFinalCurrentStage;
        private string strFinalStageStatus;
        private string strCloseOutCurrentStage;
        private string strCloseOutStageStatus;

        private string strTwoTabRoute;
        //for concurrence & Pre Screnners
        private string strIsResponded;
        private string strApprNameList;
        private string strComment;
        private string strUserName;
        private int intConAppID;

        private int intConGrpID;

        //Added for PCRs
        private string strNewRawPackageFinal;
        private string strParentRollsFinal;
        private string strInterMaterialFinal;
        private string strCurrentBrandFinal;
        private string strConsLabEvalFinal;
        private string strGCASFinal;
        private bool boolProdSelectIs_Understood_Policy_37Final = false;
        private bool boolProdSelectIs_Exception_Policy_37Final = false;
        private bool boolProdSelectIs_EO_Covered_Policy_37Final = false;
        private bool boolIs_Product_Go_To_CustomersFinal;
        private string strIs_Product_Go_To_CustomersFinal;
        private bool boolIs_Using_Approved_FC_R_ATSFinal;
        private string strIs_Using_Approved_FC_R_ATSFinal;
        private bool boolIs_Approved_At_LevelFinal;
        private string strIs_Approved_At_LevelFinal;
        private bool boolIs_Approved_For_RegionFinal;
        private string strIs_Approved_For_RegionFinal;
        private bool boolIs_Approved_For_ApplicationFinal;
        private string strIs_Approved_For_ApplicationFinal;
        private bool boolIs_Approved_At_Prev_Application_RateFinal;
        private string strIs_Approved_For_Application_RateFinal;
        private string strSmart_Clearance_Number;


        public string TwoTabRoute
        {
            get { return strTwoTabRoute; }
            set { strTwoTabRoute = value; }
        }
        public string FinalCurrentStagePre
        {
            get { return strFinalCurrentStage; }
            set { strFinalCurrentStage = value; }
        }

        public string FinalStageStatus
        {
            get { return strFinalStageStatus; }
            set { strFinalStageStatus = value; }
        }

        public string CloseOutCurrentStage
        {
            get { return strCloseOutCurrentStage; }
            set { strCloseOutCurrentStage = value; }
        }

        public string CloseOutStageStatus
        {
            get { return strCloseOutStageStatus; }
            set { strCloseOutStageStatus = value; }
        }

        public string CurrentStagePre
        {
            get { return strCurrentStagePre; }
            set { strCurrentStagePre = value; }
        }

        public string StageStatus
        {
            get { return strStageStatus; }
            set { strStageStatus = value; }
        }

        public string CurrentStage
        {
            get { return strCurrentStage; }
            set { strCurrentStage = value; }
        }

        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        public string EONumber
        {
            get { return strEONumber; }
            set { strEONumber = value; }
        }

        public string SAPIONumber
        {
            get { return intSAPIONumber; }
            set { intSAPIONumber = value; }
        }

        public int CategoryID
        {
            get { return intCategoryID; }
            set { intCategoryID = value; }
        }

        public string Brands
        {
            get { return strBrands; }
            set { strBrands = value; }
        }

        public string EOID
        {
            get { return intEOID; }
            set { intEOID = value; }
        }

        public int ProjectID
        {
            get { return intProjectID; }
            set { intProjectID = value; }
        }

        public int PlantID
        {
            get { return intPlantID; }
            set { intPlantID = value; }
        }

        public string EventIDs
        {
            get { return strEvents; }
            set { strEvents = value; }
        }

        public string Originator
        {
            get { return strOriginator; }
            set { strOriginator = value; }
        }

        public string CoOrginator
        {
            get { return strCoOrginator; }
            set { strCoOrginator = value; }
        }

        //Public Property OfficeNumber() As Integer
        //    Get
        //        Return strOfficeNumber
        //    End Get
        //    Set(ByVal Value As Integer)
        //        strOfficeNumber = Value
        //    End Set
        //End Property

        public string OfficeNumber
        {
            get { return strOfficeNumber; }
            set { strOfficeNumber = value; }
        }


        //Public Property PhoneNumber() As Integer
        //    Get
        //        Return strPhoneNumber
        //    End Get
        //    Set(ByVal Value As Integer)
        //        strPhoneNumber = Value
        //    End Set
        //End Property

        public string PhoneNumber
        {
            get { return strPhoneNumber; }
            set { strPhoneNumber = value; }
        }

        public string CommsntsToApprover
        {
            get { return strCommsntsToApprover; }
            set { strCommsntsToApprover = value; }
        }

        public string PreStatus
        {
            get { return strPreStatus; }
            set { strPreStatus = value; }
        }

        public string PreIsRouted
        {
            get { return strPreIsRouted; }
            set { strPreIsRouted = value; }
        }

        public string FinalStatus
        {
            get { return strFinalStatus; }
            set { strFinalStatus = value; }
        }

        public string FinalIsRouted
        {
            get { return strFinalIsRouted; }
            set { strFinalIsRouted = value; }
        }

        public string CloseOutStatus
        {
            get { return strCloseOutStatus; }
            set { strCloseOutStatus = value; }
        }

        public string CloseOutIsRouted
        {
            get { return strCloseOutIsRouted; }
            set { strCloseOutIsRouted = value; }
        }
        // Primary tab properties
        //@p_EO_Type_ID_List
        public string EOType
        {
            get { return strEOtype; }
            set { strEOtype = value; }
        }
        //@p_Scope_Type_ID	
        public int EOScopeProjectType
        {
            get { return intEOScopeProjectType; }
            set { intEOScopeProjectType = value; }
        }
        //@p_New_EO_Type_Name	
        public string NewTypeOfEOType
        {
            get { return strNewTypeOfEOType; }
            set { strNewTypeOfEOType = value; }
        }
        //@p_New_Scope_Type_Name	
        public string NewTypeOfEOScope
        {
            get { return strNewTypeofEOScope; }
            set { strNewTypeofEOScope = value; }
        }
        //@p_Description
        public string BriefDesc
        {
            get { return strBriefDesc; }
            set { strBriefDesc = value; }
        }
        //@p_Paper_Making_Days
        public double TotPaperMaking
        {
            get { return dblTotPaperMaking; }
            set { dblTotPaperMaking = Convert.ToDouble(value); }
        }
        //@p_Converting_Time_Days
        public double TotConverting
        {
            get { return dblTotConverting; }
            set { dblTotConverting = value; }
        }
        //@p_Material_Cost
        public double TotCostNewMaterials
        {
            get { return dblTotCostNewMaterials; }
            set { dblTotCostNewMaterials = value; }
        }
        //@p_Specific_Cost	
        public double CostofEOSpecific
        {
            get { return dblCostofEOSpecific; }
            set { dblCostofEOSpecific = value; }
        }
        //@p_Total_Pre_Spending
        public double TotPreSpend
        {
            get { return dblTotPreSpend; }
            set { dblTotPreSpend = value; }
        }
        //@p_EO_Executing_Cost	
        public double EOExecuCost
        {
            get { return dblEOExecuCost; }
            set { dblEOExecuCost = value; }
        }
        //@p_Total_Cost
        public double TotCost
        {
            get { return dblTotCost; }
            set { dblTotCost = value; }
        }
        //@p_Budget_Center_ID
        public int SujBudgetCenter
        {
            get { return intSujBudgetCenter; }
            set { intSujBudgetCenter = value; }
        }
        //@p_Other_Center_Number	
        public string OtherBudgCenter
        {
            get { return strOtherBudgCenter; }
            set { strOtherBudgCenter = value; }
        }
        //@p_Suggested_Budget_Center_Name
        public string SelectedBudgCenter
        {
            get { return strSelectedBudgCenter; }
            set { strSelectedBudgCenter = value; }
        }
        //Section : New Materials and Brands
        //@p_Raw_Pack_Mat	
        public string NewRawPackage
        {
            get { return strNewRawPackage; }
            set { strNewRawPackage = value; }
        }
        //@p_Parent_Rolls	
        public string EOProduce
        {
            get { return strEOProduce; }
            set { strEOProduce = value; }
        }
        //@p_Intermediate_Mat
        public string EOProduceInterMaterial
        {
            get { return strEOProduceInterMaterial; }
            set { strEOProduceInterMaterial = value; }
        }
        //@p_Regulated_Prod
        public string EOProduceRegProd
        {
            get { return strEOProduceRegProd; }
            set { strEOProduceRegProd = value; }
        }
        //@p_GMP_Classsify
        public string appropriateGMP
        {
            get { return strappropriateGMP; }
            set { strappropriateGMP = value; }
        }
        //@p_Current_Brand
        public string EOShippedTrade
        {
            get { return strEOShippedTrade; }
            set { strEOShippedTrade = value; }
        }
        //@p_Cons_Lab_Eval
        public string TestProdSample
        {
            get { return strTestProdSample; }
            set { strTestProdSample = value; }
        }


        //Added on 01/20/2010 
        //For MUREO PCRs
        //By: David


        //@p_Is_Understood_Policy_37
        public bool ProdSelectIs_Understood_Policy_37
        {
            get { return boolProdSelectIs_Understood_Policy_37; }
            set { boolProdSelectIs_Understood_Policy_37 = value; }
        }
        //@p_Is_Exception_Policy_37
        public bool ProdSelectIs_Exception_Policy_37
        {
            get { return boolProdSelectIs_Exception_Policy_37; }
            set { boolProdSelectIs_Exception_Policy_37 = value; }
        }
        //@p_Is_EO_Covered_Policy_37
        public bool ProdSelectIs_EO_Covered_Policy_37
        {
            get { return boolProdSelectIs_EO_Covered_Policy_37; }
            set { boolProdSelectIs_EO_Covered_Policy_37 = value; }
        }

        //@p_Is_Product_Go_To_Customers
        public bool Is_Product_Go_To_Customers
        {
            get { return boolIs_Product_Go_To_Customers; }
            set { boolIs_Product_Go_To_Customers = value; }
        }

        public string Is_Product_Go_To_CustomersNull
        {
            get { return strIs_Product_Go_To_Customers; }
            set { strIs_Product_Go_To_Customers = value; }
        }

        //@p_Is_Using_Approved_FC_R_ATS
        public bool Is_Using_Approved_FC_R_ATS
        {
            get { return boolIs_Using_Approved_FC_R_ATS; }
            set { boolIs_Using_Approved_FC_R_ATS = value; }
        }


        public string Is_Using_Approved_FC_R_ATSNull
        {
            get { return strIs_Using_Approved_FC_R_ATS; }
            set { strIs_Using_Approved_FC_R_ATS = value; }
        }

        //@p_Is_Approved_At_Level
        public bool Is_Approved_At_Level
        {
            get { return boolIs_Approved_At_Level; }
            set { boolIs_Approved_At_Level = value; }
        }
        public string Is_Approved_At_LevelNull
        {
            get { return strIs_Approved_At_Level; }
            set { strIs_Approved_At_Level = value; }
        }

        //@p_Is_Approved_For_Region
        public bool Is_Approved_For_Region
        {
            get { return boolIs_Approved_For_Region; }
            set { boolIs_Approved_For_Region = value; }
        }
        public string Is_Approved_At_RegionNull
        {
            get { return strIs_Approved_For_Region; }
            set { strIs_Approved_For_Region = value; }
        }

        //@p_Is_Approved_For_Application
        public bool Is_Approved_For_Application
        {
            get { return boolIs_Approved_For_Application; }
            set { boolIs_Approved_For_Application = value; }
        }
        public string Is_Approved_At_ApplicationNull
        {
            get { return strIs_Approved_For_Application; }
            set { strIs_Approved_For_Application = value; }
        }

        //@p_Is_Approved_At_Prev_Application_Rate
        public bool Is_Approved_At_Prev_Application_Rate
        {
            get { return boolIs_Approved_At_Prev_Application_Rate; }
            set { boolIs_Approved_At_Prev_Application_Rate = value; }
        }
        public string Is_Approved_At_Application_RateNull
        {
            get { return strIs_Approved_For_Application_Rate; }
            set { strIs_Approved_For_Application_Rate = value; }
        }




        //to be removed
        public string TestProdSelectionCheckbox
        {
            get { return strTestProdSelectionCheckbox; }
            set { strTestProdSelectionCheckbox = value; }
        }
        //@p_GCAS
        public string GCASUMOF
        {
            get { return strGCASUMOF; }
            set { strGCASUMOF = value; }
        }

        // need to send GCAS numbers here

        //@p_Is_GCAS_Rec
        public int IsGCASRec
        {
            get { return intIsGCASRec; }
            set { intIsGCASRec = value; }
        }
        //@p_GCAS_XML_Str
        public string GCASXMLStr
        {
            get { return strGCASXMLStr; }
            set { strGCASXMLStr = value; }
        }
        //Section : HS&E
        //@p_Chemical_Change
        public string NewChemExistChem
        {
            get { return strNewChemExistChem; }
            set { strNewChemExistChem = value; }
        }
        //@p_Raw_Material_Change
        public string NewRawExistRaw
        {
            get { return strNewRawExistRaw; }
            set { strNewRawExistRaw = value; }
        }
        //@p_Equipment_Change
        public string NewEqipExistEuip
        {
            get { return strNewEqipExistEuip; }
            set { strNewEqipExistEuip = value; }
        }
        //@p_Job_Task_Change
        public string NewjobExistjob
        {
            get { return strNewjobExistjob; }
            set { strNewjobExistjob = value; }
        }
        //PS&RA section

        public string PSRAType
        {
            get { return strPSRAType; }
            set { strPSRAType = value; }
        }

        public string OtherPSRAType
        {
            get { return intOtherPSRAType; }
            set { intOtherPSRAType = value; }
        }
        // need to send PSRA numbers here
        //@p_Is_PSRA
        public int IsPSRA
        {
            get { return intIsPSRA; }
            set { intIsPSRA = value; }
        }
        //@p_PSRA_XML_Str	
        public string PSRAXMLStr
        {
            get { return strPSRAXMLStr; }
            set { strPSRAXMLStr = value; }
        }
        //@p_PSRA_ID_List		
        public string PSRAIDList
        {
            get { return strPSRAIDList; }
            set { strPSRAIDList = value; }
        }

        //@p_PSRA_Additional_Info		
        public string PSRAAdditionalInfo
        {
            get { return strPSRAAdditionalInfo; }
            set { strPSRAAdditionalInfo = value; }
        }
        //Section :Planning and Budget Information

        //@p_Plant_ID
        public int PlantSite
        {
            get { return intPlantSite; }
            set { intPlantSite = value; }
        }
        //@p_Lines_Machines
        public string LineMachine
        {
            get { return strLineMachine; }
            set { strLineMachine = value; }
        }
        //@p_Planned_Start_Date
        public System.DateTime PlannedStartDate
        {
            get { return strPlannedStartDate; }
            set { strPlannedStartDate = value; }
        }
        //@p_Formula_Card_Number
        public string FormulaCardNumber
        {
            get { return strFormulaCardNumber; }
            set { strFormulaCardNumber = value; }
        }
        //@p_IGCAS_Number
        public string IGCASNumber
        {
            get { return strIGCASNumber; }
            set { strIGCASNumber = value; }
        }
        //Section : Production and Packaging
        //@p_PP_Format
        public string Formats
        {
            get { return strFormats; }
            set { strFormats = value; }
        }
        //@p_PP_Attachment
        public string PPAttachment
        {
            get { return strPPAttachment; }
            set { strPPAttachment = value; }
        }
        //@p_PP_Lab_Notebook_Number
        public string PPLabNotebookNumber
        {
            get { return strPPLabNotebookNumber; }
            set { strPPLabNotebookNumber = value; }
        }

        //Section : Packaging / Disposition Information
        //@p_Prod_Pack_ID_List
        public string ProductPacked
        {
            get { return strProductPacked; }
            set { strProductPacked = value; }
        }
        //@p_Current_Packaging
        public string CurPackage
        {
            get { return strCurPackage; }
            set { strCurPackage = value; }
        }
        //@p_Experimental_Packaging
        public string ExpPackage
        {
            get { return strExpPackage; }
            set { strExpPackage = value; }
        }
        //@p_Current_Packaging_Type
        public string PackagingList
        {
            get { return strPackagingList; }
            set { strPackagingList = value; }
        }
        //@p_Exp_Pack_Clear_Poly
        public string ClearPoly
        {
            get { return strClearPoly; }
            set { strClearPoly = value; }
        }
        //@p_Exp_Pack_Blank_KDF
        public string BlankKDF
        {
            get { return strBlankKDF; }
            set { strBlankKDF = value; }
        }
        //@p_Prod_Disp_ID
        public int ProdDisposition
        {
            get { return intProdDisposition; }
            set { intProdDisposition = value; }
        }
        //@p_Prod_Disp_Add_Comments
        public string AddCommnets
        {
            get { return strAddCommnets; }
            set { strAddCommnets = value; }
        }
        //@p_Pallet_Patter_SKU
        public string PalletPatternYesNo
        {
            get { return strPalletPatternYesNo; }
            set { strPalletPatternYesNo = value; }
        }
        //@p_Stack_Testing
        public string StacTesting
        {
            get { return strStacTesting; }
            set { strStacTesting = value; }
        }
        //@p_Ship_Testing	
        public string ShipTesting
        {
            get { return strShipTesting; }
            set { strShipTesting = value; }
        }
        //@p_Material_Disposition_ID
        public int MaterialDisposition
        {
            get { return intMaterialDisposition; }
            set { intMaterialDisposition = value; }
        }
        //@p_Mat_Disp_Add_Comments
        public string MaterialDispoOtherComments
        {
            get { return strMaterialDispoOtherComments; }
            set { strMaterialDispoOtherComments = value; }
        }
        //@p_Broke_Disp_Normal	
        public string EOgengreaternormalbroke
        {
            get { return strEOgengreaternormalbroke; }
            set { strEOgengreaternormalbroke = value; }
        }
        //@p_Printer_Broke
        public string PrintBroke
        {
            get { return strPrintBroke; }
            set { strPrintBroke = value; }
        }
        //@p_Ink_Coverage
        public string PrintBrokeYesOption
        {
            get { return strPrintBrokeYesOption; }
            set { strPrintBrokeYesOption = value; }
        }
        //@p_PDI_Attachments	
        public string AdditionalItems
        {
            get { return strAdditionalItems; }
            set { strAdditionalItems = value; }
        }
        //@p_PDI_Lab_Notebook_Number
        public string LabNoteBook
        {
            get { return strLabNoteBook; }
            set { strLabNoteBook = value; }
        }

        public string ApproverCommnets
        {
            get { return strApproverCommnets; }
            set { strApproverCommnets = value; }
        }
        //Section : Approvals
        //@p_EO_Mode
        public string EOSiteTestOther
        {
            get { return strEOSiteTestOther; }
            set { strEOSiteTestOther = value; }
        }
        //@p_Approval_Group_ID
        public int ApprovalGroup
        {
            get { return intApprovalGroup; }
            set { intApprovalGroup = value; }
        }

        public string FuncIDAppNameList
        {
            get { return strFuncIDAppNameList; }
            set { strFuncIDAppNameList = value; }
        }

        //@p_App_History_Desc
        public string AppHistoryDesc
        {
            get { return strAppHistoryDesc; }
            set { strAppHistoryDesc = value; }
        }
        //@p_Rev_History_Desc	
        public string RevHistoryDesc
        {
            get { return strRevHistoryDesc; }
            set { strRevHistoryDesc = value; }
        }

        //@p_Prev_Comments		
        public string PrevComments
        {
            get { return strPrevComments; }
            set { strPrevComments = value; }
        }

        //Final Tab 
        //@p_Budget_Center_ID
        public string BudgetCenterFinal
        {
            get { return strBudgetCenterFinal; }
            set { strBudgetCenterFinal = value; }
        }
        //@p_New_Chemical_Change
        public string NewChemicalChange
        {
            get { return strNewChemicalChange; }
            set { strNewChemicalChange = value; }
        }
        //@p_New_RawMaterial_Change
        public string NewRawMaterialChange
        {
            get { return strNewRawMaterialChange; }
            set { strNewRawMaterialChange = value; }
        }
        //Section : Packaging / Disposition Information
        public string ProductPack
        {
            get { return strProductPack; }
            set { strProductPack = value; }
        }
        //@p_Current_Packaging
        public string CurrentPackage
        {
            get { return strCurrentPackage; }
            set { strCurrentPackage = value; }
        }
        //@p_Current_Packaging_Type
        public string CurrentPackagingType
        {
            get { return strCurrentPackagingType; }
            set { strCurrentPackagingType = value; }
        }
        //@p_Experimental_Packaging
        public string ExperimentPackage
        {
            get { return strExperimentPackage; }
            set { strExperimentPackage = value; }
        }
        //@p_Exp_Pack_Clear_Poly	
        public string ClearPolyFinal
        {
            get { return strClearPolyFinal; }
            set { strClearPolyFinal = value; }
        }
        //@p_Exp_Pack_Blank_KDF
        public string BlankKDFFinal
        {
            get { return strBlankKDFFinal; }
            set { strBlankKDFFinal = value; }
        }
        //@p_Prod_Disp_ID
        public int ProdDispoID
        {
            get { return intProdDispo; }
            set { intProdDispo = value; }
        }
        //@p_Prod_Disp_Add_Comments	
        public string OtherProdDispo
        {
            get { return strOtherProdDispo; }
            set { strOtherProdDispo = value; }
        }
        //@p_Pallet_Patter_SKU	
        public string EOUniquePalletPaerns
        {
            get { return strEOUniquePalletPaterns; }
            set { strEOUniquePalletPaterns = value; }
        }
        //@p_Stack_Testing		
        //@p_Ship_Testing	
        public string EOUniqPaletPatStackTesing
        {
            get { return strEOUniqPaletPatStackTesing; }
            set { strEOUniqPaletPatStackTesing = value; }
        }
        public string EOUniqPaletPatShipTesing
        {
            get { return strEOUniqPaletPatShipTesing; }
            set { strEOUniqPaletPatShipTesing = value; }
        }
        //@p_Material_Disposition_ID
        public int MaterialDispostion
        {
            get { return intMaterialDispostion; }
            set { intMaterialDispostion = value; }
        }
        //@p_Mat_Disp_Add_Comments
        public string MaterialDispoAddCommnets
        {
            get { return strMaterialDispoAddCommnets; }
            set { strMaterialDispoAddCommnets = value; }
        }
        //@p_Broke_Disp_Normal
        public string EOGraterNormalBroke
        {
            get { return strEOGraterNormalBroke; }
            set { strEOGraterNormalBroke = value; }
        }
        //@p_Printer_Broke
        public string EOPrintedBroke
        {
            get { return strEOPrintedBroke; }
            set { strEOPrintedBroke = value; }
        }
        //@p_Ink_Coverage	
        public string EOPrintedBrokeIncCov
        {
            get { return strEOPrintedBrokeIncCov; }
            set { strEOPrintedBrokeIncCov = value; }
        }

        //@p_PDI_Lab_Notebook_Number	

        public string PDILabNotebookNumber
        {
            get { return strPDILabNotebookNumber; }
            set { strPDILabNotebookNumber = value; }
        }
        //@p_PDI_Attachment	

        public string PDIAttachment
        {
            get { return strPDIAttachment; }
            set { strPDIAttachment = value; }
        }
        //Section : Cost Sheet in final tab
        //@p_CS_Attachments		
        public string AttaCostSheet
        {
            get { return strAttaCostSheet; }
            set { strAttaCostSheet = value; }
        }

        //@p_QA_Info_Attachment
        public string FinalAttachQA
        {
            get { return strFinalAttachQA; }
            set { strFinalAttachQA = value; }
        }

        //@p_Amount_Preliminary_Stage
        public decimal EstmAmtCostSheet
        {
            get { return strEstmAmtCostSheet; }
            set { strEstmAmtCostSheet = value; }
        }
        //@p_Total_Cost_Diff
        public string TotDiffCostSheet
        {
            get { return strTotDiffCostSheet; }
            set { strTotDiffCostSheet = value; }
        }
        //@p_Cost_Cost_Sheet		
        public decimal TotDiffCostSheetYesOpt
        {
            get { return strTotDiffCostSheetYesOpt; }
            set { strTotDiffCostSheetYesOpt = value; }
        }
        //@p_CS_Comments
        public string AddCommnetsCostSheet
        {
            get { return strAddCommnetsCostSheet; }
            set { strAddCommnetsCostSheet = value; }
        }
        //Section : Formula Card Information in final tab
        //@p_Formula_Card_Info
        public string EOFormulaCardInformation
        {
            get { return intEOFormulaCardInformation; }
            set { intEOFormulaCardInformation = value; }
        }
        //@p_FC_Attachment
        public string AttachFormulaCard
        {
            get { return strattachFormulaCard; }
            set { strattachFormulaCard = value; }
        }
        //Section: Test Plans in final tab
        //@p_TP_Attachment		
        public string TestPlantAttachments
        {
            get { return strTestPlantAttachments; }
            set { strTestPlantAttachments = value; }
        }
        //Section : Lab Sampling Plans in final tab
        //@p_Central_Analytical_Lab
        public string CentralAnalyticalLab
        {
            get { return strCentralAnalyticalLab; }
            set { strCentralAnalyticalLab = value; }
        }
        //@p_Site_Testing_Lab
        public string SiteTestingLab
        {
            get { return strSiteTestingLab; }
            set { strSiteTestingLab = value; }
        }
        //@p_LS_Attachment	
        public string AttchLabforTesting
        {
            get { return strAttchLabforTesting; }
            set { strAttchLabforTesting = value; }
        }

        //Section:Product or Detailed Test Flow Matrix in final tab
        //@p_PTF_Attachment	
        public string ProdDetailTest
        {
            get { return strProdDetailTest; }
            set { strProdDetailTest = value; }
        }
        //Section:Other Supporting Documents 
        //@p_OD_Attachment
        public string OtherSupAttach
        {
            get { return strOtherSupAttach; }
            set { strOtherSupAttach = value; }
        }
        //@p_Comments_Approvers
        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
        }
        //Section Approvals in final tab
        //@p_EO_Mode
        public string TypeOfEO
        {
            get { return strTypeOfEO; }
            set { strTypeOfEO = value; }
        }
        //@p_Approval_Group_ID
        public int AppGrp
        {
            get { return strAppGrp; }
            set { strAppGrp = value; }
        }
        //@p_FuncID_App_Name_List
        public string FuncIDAppNameListFinal
        {
            get { return strFuncIDAppNameListFinal; }
            set { strFuncIDAppNameListFinal = value; }
        }
        public string PSInitiativeManager
        {
            get { return strPSInitiativeManager; }
            set { strPSInitiativeManager = value; }
        }

        public string ProductsResearch
        {
            get { return strProductsResearch; }
            set { strProductsResearch = value; }
        }

        public string BudgetOwnerfinal
        {
            get { return strBudgetOwnerfinal; }
            set { strBudgetOwnerfinal = value; }
        }


        public string SiteHSEResourcefinal
        {
            get { return strSiteHSEResourcefinal; }
            set { strSiteHSEResourcefinal = value; }
        }

        public string SAPCostCenterCoordi
        {
            get { return strSAPCostCenterCoordi; }
            set { strSAPCostCenterCoordi = value; }
        }

        public string SitePlanningfinal
        {
            get { return strSitePlanningFinal; }
            set { strSitePlanningFinal = value; }
        }

        public string SiteContactFinal
        {
            get { return strSiteContactFinal; }
            set { strSiteContactFinal = value; }
        }

        public string SiteFinance
        {
            get { return strSiteFinanceFinal; }
            set { strSiteFinanceFinal = value; }
        }

        public string SiteLeadershipFinal
        {
            get { return strSiteLeadershipfinal; }
            set { strSiteLeadershipfinal = value; }
        }


        public string TimingGateExceptionFinal
        {
            get { return strTimingGateExceptionFinal; }
            set { strTimingGateExceptionFinal = value; }
        }

        public string QAFinal
        {
            get { return strQAFinal; }
            set { strQAFinal = value; }
        }

        public string StandardsOfficeFinal
        {
            get { return strStandardsOfficeFinal; }
            set { strStandardsOfficeFinal = value; }
        }
        //thee lables in Final Tab
        //Close-Out Tab
        //@p_Lab_NoteBook_Num
        public string LabNoteBookCO
        {
            get { return strLabNoteBookCO; }
            set { strLabNoteBookCO = value; }
        }
        //@p_Completion_Date
        public System.DateTime CompletionDate
        {
            get { return strCompletionDate; }
            set { strCompletionDate = value; }
        }
        //Section : Actual Cost Sheet in Close out tab
        //@p_AC_Attachment 
        public string AttFinalCostSheetCO
        {
            get { return strAttFinalCostSheetCO; }
            set { strAttFinalCostSheetCO = value; }
        }
        //@p_AC_Attachment 
        public string AttCOILR
        {
            get { return strAttCOILR; }
            set { strAttCOILR = value; }
        }
        //@p_Total_CostSheet 
        public decimal TotCostSheetCO
        {
            get { return strTotCostSheetCO; }
            set { strTotCostSheetCO = value; }
        }

        //Section : Initial Learning Report
        //@p_ILR_Attachment
        public string ILRAttachment
        {
            get { return strILRAttachment; }
            set { strILRAttachment = value; }
        }

        //Section : Test Plans Used in close out tab
        //@p_TP_Attachment
        public string AttchTestPlanTepmpalteCO
        {
            get { return strAttchTestPlanTepmpalteCO; }
            set { strAttchTestPlanTepmpalteCO = value; }
        }

        //@p_TP_Attachment
        public string AttCOReport
        {
            get { return strAttCOReport; }
            set { strAttCOReport = value; }
        }

        //Section : Close Out Report in close out tab
        public string KeyWords1CO
        {
            get { return strKeyWords1CO; }
            set { strKeyWords1CO = value; }
        }

        public string KeyWords2CO
        {
            get { return strKeyWords2CO; }
            set { strKeyWords2CO = value; }
        }

        public string KeyWords3CO
        {
            get { return strKeyWords3CO; }
            set { strKeyWords3CO = value; }
        }

        public string KeyWords4CO
        {
            get { return strKeyWords4CO; }
            set { strKeyWords4CO = value; }
        }

        public string KeyWords5CO
        {
            get { return strKeyWords5CO; }
            set { strKeyWords5CO = value; }
        }

        public string KeyWords6CO
        {
            get { return strKeyWords6CO; }
            set { strKeyWords6CO = value; }
        }
        //@p_Comments_Approver
        public string CommentsApproverCO
        {
            get { return strCommentsApproverCO; }
            set { strCommentsApproverCO = value; }
        }
        //Section : Approvals in close out tab
        //@p_EO_Mode	
        public string EoTypeCloseOut
        {
            get { return strEoTypeCloseOut; }
            set { strEoTypeCloseOut = value; }
        }
        //@p_Approval_Group_ID
        public int AppGroupCloseOut
        {
            get { return intAppGroupCloseOut; }
            set { intAppGroupCloseOut = value; }
        }

        public string SiteFinanceCloseOut
        {
            get { return strSiteFinanceCO; }
            set { strSiteFinanceCO = value; }
        }


        public string BudgetOwnerCloseOut
        {
            get { return strBudgetOwnerCO; }
            set { strBudgetOwnerCO = value; }
        }
        //@p_FuncID_App_Name_List	
        public string FuncIDAppNameListCloseOut
        {
            get { return strFuncIDAppNameListCloseOut; }
            set { strFuncIDAppNameListCloseOut = value; }
        }

        //For Concurrence & Pre Screnners
        public string IsResponded
        {
            get { return strIsResponded; }
            set { strIsResponded = value; }
        }
        public string ApprNameList
        {
            get { return strApprNameList; }
            set { strApprNameList = value; }
        }
        public int ConAppID
        {
            get { return intConAppID; }
            set { intConAppID = value; }
        }
        public int ConGrpID
        {
            get { return intConGrpID; }
            set { intConGrpID = value; }
        }
        public string Comment
        {
            get { return strComment; }
            set { strComment = value; }
        }
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        //Added on 07/12/2010 
        //For MUREO PCRs
        //By: David

        //Section : New Materials and Brands
        //@p_Raw_Pack_Mat	
        public string NewRawPackageFinal
        {
            get { return strNewRawPackageFinal; }
            set { strNewRawPackageFinal = value; }
        }
        //@p_Parent_Rolls	
        public string ParentRollsFinal
        {
            get { return strParentRollsFinal; }
            set { strParentRollsFinal = value; }
        }
        //@p_Intermediate_Mat
        public string InterMaterialFinal
        {
            get { return strInterMaterialFinal; }
            set { strInterMaterialFinal = value; }
        }
        //@p_Current_Brand
        public string CurrentBrandFinal
        {
            get { return strCurrentBrandFinal; }
            set { strCurrentBrandFinal = value; }
        }
        //@p_Cons_Lab_Eval
        public string ConsLabEvalFinal
        {
            get { return strConsLabEvalFinal; }
            set { strConsLabEvalFinal = value; }
        }
        //@p_GCAS 
        public string GCASFinal
        {
            get { return strGCASFinal; }
            set { strGCASFinal = value; }
        }


        //@p_Is_Understood_Policy_37Final
        public bool ProdSelectIs_Understood_Policy_37Final
        {
            get { return boolProdSelectIs_Understood_Policy_37Final; }
            set { boolProdSelectIs_Understood_Policy_37Final = value; }
        }
        //@p_Is_Exception_Policy_37Final
        public bool ProdSelectIs_Exception_Policy_37Final
        {
            get { return boolProdSelectIs_Exception_Policy_37Final; }
            set { boolProdSelectIs_Exception_Policy_37Final = value; }
        }
        //@p_Is_EO_Covered_Policy_37Final
        public bool ProdSelectIs_EO_Covered_Policy_37Final
        {
            get { return boolProdSelectIs_EO_Covered_Policy_37Final; }
            set { boolProdSelectIs_EO_Covered_Policy_37Final = value; }
        }

        //@p_Is_Product_Go_To_Customers
        public bool Is_Product_Go_To_CustomersFinal
        {
            get { return boolIs_Product_Go_To_CustomersFinal; }
            set { boolIs_Product_Go_To_CustomersFinal = value; }
        }

        public string Is_Product_Go_To_CustomersNullFinal
        {
            get { return strIs_Product_Go_To_CustomersFinal; }
            set { strIs_Product_Go_To_CustomersFinal = value; }
        }

        //@p_Is_Using_Approved_FC_R_ATS
        public bool Is_Using_Approved_FC_R_ATSFinal
        {
            get { return boolIs_Using_Approved_FC_R_ATSFinal; }
            set { boolIs_Using_Approved_FC_R_ATSFinal = value; }
        }


        public string Is_Using_Approved_FC_R_ATSNullFinal
        {
            get { return strIs_Using_Approved_FC_R_ATSFinal; }
            set { strIs_Using_Approved_FC_R_ATSFinal = value; }
        }

        //@p_Is_Approved_At_Level
        public bool Is_Approved_At_LevelFinal
        {
            get { return boolIs_Approved_At_LevelFinal; }
            set { boolIs_Approved_At_LevelFinal = value; }
        }
        public string Is_Approved_At_LevelNullFinal
        {
            get { return strIs_Approved_At_LevelFinal; }
            set { strIs_Approved_At_LevelFinal = value; }
        }

        //@p_Is_Approved_For_Region
        public bool Is_Approved_For_RegionFinal
        {
            get { return boolIs_Approved_For_RegionFinal; }
            set { boolIs_Approved_For_RegionFinal = value; }
        }
        public string Is_Approved_At_RegionNullFinal
        {
            get { return strIs_Approved_For_RegionFinal; }
            set { strIs_Approved_For_RegionFinal = value; }
        }

        //@p_Is_Approved_For_Application
        public bool Is_Approved_For_ApplicationFinal
        {
            get { return boolIs_Approved_For_ApplicationFinal; }
            set { boolIs_Approved_For_ApplicationFinal = value; }
        }
        public string Is_Approved_At_ApplicationNullFinal
        {
            get { return strIs_Approved_For_ApplicationFinal; }
            set { strIs_Approved_For_ApplicationFinal = value; }
        }

        //@p_Is_Approved_At_Prev_Application_Rate
        public bool Is_Approved_At_Prev_Application_RateFinal
        {
            get { return boolIs_Approved_At_Prev_Application_RateFinal; }
            set { boolIs_Approved_At_Prev_Application_RateFinal = value; }
        }
        public string Is_Approved_At_Application_RateNullFinal
        {
            get { return strIs_Approved_For_Application_RateFinal; }
            set { strIs_Approved_For_Application_RateFinal = value; }
        }

        public string Smart_Clearance_Number
        {
            get { return strSmart_Clearance_Number; }
            set { strSmart_Clearance_Number = value; }
        }
    }
}
