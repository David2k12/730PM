using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUREOPROP
{
    public class objEOSiteTest
    {
        private string strEvents;
        private int intPlantID;
        private int intEOID;
        private int intProjectID;
        private int intCategoryID;
        private string strBrands;
        private string strEONumber;
        private string strTitle;
        private string strCoOrginator;
        private string strOfficeNumber;
        private string strPhoneNumber;
        private string strMachineInfo;
        private string CommentsToApprover;
        private string strStatus;
        private string strStageStatus;
        private string strEOMode;
        private string str2TabRoute;

        private string strOriginator;
        public string Originator
        {
            get { return strOriginator; }
            set { strOriginator = value; }
        }
        public string Tab2Route
        {
            get { return str2TabRoute; }
            set { str2TabRoute = value; }
        }

        public string EOMode
        {
            get { return strEOMode; }
            set { strEOMode = value; }
        }
        public string StageStatus
        {
            get { return strStageStatus; }
            set { strStageStatus = value; }
        }
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        public string strCommentsToApprover
        {
            get { return CommentsToApprover; }
            set { strCommentsToApprover = value; }
        }

        public int EOID
        {
            get { return intEOID; }
            set { intEOID = value; }
        }

        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        public string EffectedMachineInfo
        {
            get { return strMachineInfo; }
            set { strMachineInfo = value; }
        }

        public string EONumber
        {
            get { return strEONumber; }
            set { strEONumber = value; }
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


        public string CoOrginator
        {
            get { return strCoOrginator; }
            set { strCoOrginator = value; }
        }

        public string OfficeNumber
        {
            get { return strOfficeNumber; }
            set { strOfficeNumber = value; }
        }

        public string PhoneNumber
        {
            get { return strPhoneNumber; }
            set { strPhoneNumber = value; }
        }
    }

}
