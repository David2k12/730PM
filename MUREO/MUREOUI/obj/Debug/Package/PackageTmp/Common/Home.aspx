<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MUREOUI.Common.Home" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MUREO Home Page</title>
    <script language="javascript" type="text/javascript">

        function IsPopupBlocker() {

            var oWin = window.open("", "testpopupblocker", "width=0,height=0,top=5000,left=5000");
            if (oWin == null || typeof (oWin) == "undefined") {
                alert("This application requires Pop-up Blocker to be turned off to function normally. \n Please turn-off Pop-up Blocker before entering any data to avoid loss of data.");
            }
            else {
                oWin.close();
            }
        }
    </script>
    <script language="javascript" type="text/javascript">

        function test() {
            document.getElementById('tdHomeDesc').style.display = "";
            document.getElementById('tdPrjList').style.display = "none";
            document.getElementById('tdnewEvent').style.display = "none";
            document.getElementById('tdnewProj').style.display = "none";

        }
        function test1() {
            document.getElementById('tdHomeDesc').style.display = "";
            document.getElementById('tdPrjList').style.display = "none";
            document.getElementById('tdnewEvent').style.display = "none";
            document.getElementById('tdnewProj').style.display = "none";

        }
        function NewProj() {

            if (document.getElementById('tdnewProj').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdnewProj').style.display = "";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none";
                document.getElementById('tdMyEO').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none";
                document.getElementById('tdChkConStatus').style.display = "none";
                document.getElementById('tdAllEs').style.display = "none";
            }

            if (document.getElementById('tdnewProj').style.display = "") {
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none";
                document.getElementById('tdMyEO').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none";
                document.getElementById('tdChkConStatus').style.display = "none";
                document.getElementById('tdAllEs').style.display = "none";
            }

        }



        function NewEvent() {
            if (document.getElementById('tdnewEvent').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdnewEvent').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }
        function ProjectList() {


            if (document.getElementById('tdPrjList').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none";
                document.getElementById('tdPrjList').style.display = "";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdPrjList').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }
        function NewEO() {
            if (document.getElementById('tdNewEO').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none";
                document.getElementById('tdNewEO').style.display = "";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdNewEO').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }
        }
        function SearchPrjEvent() {
            if (document.getElementById('tdserPrj').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none";
                document.getElementById('tdserPrj').style.display = "";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdserPrj').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }
        }

        function ApprovedEO() {
            if (document.getElementById('tdApprEO').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none";
                document.getElementById('tdApprEO').style.display = "";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"

            }

            if (document.getElementById('tdApprEO').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }
        }
        function ApprovedEOS() {
            if (document.getElementById('tdApprEOS').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdApprEOS').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }
        }
        function ArchivedEO() {

            if (document.getElementById('tdArchEO').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdArchEO').style.display = ""
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdArchEO').style.display = "") {
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }
        function CancelledEO() {

            if (document.getElementById('tdCancelledEO').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = ""
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdCancelledEO').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }

        function MyEO() {

            if (document.getElementById('tdMyEO').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdMyEO').style.display = ""
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdMyEO').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }
        function MyApprovalCon() {

            if (document.getElementById('tdMyApprCon').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = ""
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdMyApprCon').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdMyEO').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }

        function MySiteTestCloseOut() {

            if (document.getElementById('tdSTAWCO').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = ""
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdSTAWCO').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdMyEO').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }
        function ChkConStatus() {

            if (document.getElementById('tdChkConStatus').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = ""
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdAllEs').style.display = "none"
            }

            if (document.getElementById('tdChkConStatus').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdMyEO').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }

        function AllESTests() {

            if (document.getElementById('tdAllEs').style.display = "none") {
                document.getElementById('tdHomeDesc').style.display = "none"
                document.getElementById('tdAllEs').style.display = ""
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdMyApprCon').style.display = "none"
                document.getElementById('tdMyEO').style.display = "none"
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdArchEO').style.display = "none"
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
            }

            if (document.getElementById('tdAllEs').style.display = "") {
                document.getElementById('tdHomeDesc').style.display = "";
                document.getElementById('tdMyEO').style.display = "none";
                document.getElementById('tdnewProj').style.display = "none";
                document.getElementById('tdCancelledEO').style.display = "none"
                document.getElementById('tdnewEvent').style.display = "none";
                document.getElementById('tdPrjList').style.display = "none";
                document.getElementById('tdNewEO').style.display = "none";
                document.getElementById('tdserPrj').style.display = "none";
                document.getElementById('tdApprEO').style.display = "none";
                document.getElementById('tdApprEOS').style.display = "none";
                document.getElementById('tdArchEO').style.display = "none";
                document.getElementById('tdMyApprCon').style.display = "none";
                document.getElementById('tdSTAWCO').style.display = "none"
                document.getElementById('tdChkConStatus').style.display = "none"
                document.getElementById('tdAllEs').style.display = "none"
            }

        }


        function defaultHome() {

            document.getElementById('tdHomeDesc').style.display = "";
            document.getElementById('tdPrjList').style.display = "none";
            document.getElementById('tdnewEvent').style.display = "none";
            document.getElementById('tdnewProj').style.display = "none";
            document.getElementById('tdNewEO').style.display = "none";
            document.getElementById('tdserPrj').style.display = "none";
            document.getElementById('tdApprEO').style.display = "none";
            document.getElementById('tdApprEOS').style.display = "none";
            document.getElementById('tdArchEO').style.display = "none"
            document.getElementById('tdCancelledEO').style.display = "none";
            document.getElementById('tdMyEO').style.display = "none";
            document.getElementById('tdMyApprCon').style.display = "none";
            document.getElementById('tdSTAWCO').style.display = "none"
            document.getElementById('tdChkConStatus').style.display = "none"
            document.getElementById('tdAllEs').style.display = "none"

        }
    </script>
</head>
<body onload = "defaultHome()">
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td>
                    <uc2:HeaderControl ID="HeaderControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" height="100%">
                        <tr>
                            <td width="20%">
                                <table cellspacing="0" cellpadding="3" width="100%" border="0" height="100%">
                                    <tr>
                                        <td valign="top" bgcolor="#f5f5f5">
                                            <table cellspacing="0" cellpadding="5" width="100%" align="center" border="0">
                                              
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="NewProj()" style="border-bottom: #0000cc 1px solid" width="82%"
                                                            id="tdMainNewProject" runat="server">
                                                            <a style="text-decoration: none" href="../Common/frmNewProject.aspx"><font face="Arial, Helvetica, sans-serif"
                                                                size="2">New Project</font></a>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="NewEvent()" style="border-bottom: #0000cc 1px solid" id="tdMainNewEvent"
                                                            runat="server">
                                                            <a id="A1" style="text-decoration: none" href="../Common/frmNewEvent.aspx" runat="server">
                                                                <font face="Arial, Helvetica, sans-serif" size="2">New Event</font></a>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="NewEO()" style="border-bottom: #0000cc 1px solid" id="tdMainNewEo"
                                                            runat="server">
                                                            <a style="text-decoration: none" href="../Common/NewEO.aspx?ses=YES"><font face="Arial, Helvetica, sans-serif"
                                                                size="2">New EO</font></a>
                                                        </td>
                                                    </tr>
                                                     <tr onmouseout="defaultHome()">
                                                        <td style="border-bottom: #0000cc 1px solid">
                                                            <a style="text-decoration: none" href="../Reports/MyEvents.aspx">
                                                                <font face="Arial, Helvetica, sans-serif" size="2">My Events</font></a>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="ProjectList()" style="border-bottom: #0000cc 1px solid">
                                                            <a style="text-decoration: none" href="../Reports/ProjectsByCategory.aspx?Form=ProjectsByCategory">
                                                                <font face="Arial, Helvetica, sans-serif" size="2">Project List</font></a>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="SearchPrjEvent()" style="border-bottom: #0000cc 1px solid">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Common/SearchProjEvents.aspx">Search Projects/Events</a></font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="ApprovedEO()" style="border-bottom: #0000cc 1px solid">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/ApprovedPreliminaryEOs.aspx">Approved Preliminary EO</a></font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="ApprovedEOS()" style="border-bottom: #0000cc 1px solid">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/ApprovedEOs.aspx">Approved EO's</a></font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td id="Td1" onmouseover="ArchivedEO()" style="border-bottom: #0000cc 1px solid"
                                                            runat="server">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/ArchivedEOs.aspx">Archived EO's/SiteTests</a></font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="CancelledEO()" style="border-bottom: #0000cc 1px solid">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/CancelledEOs.aspx">Cancelled EO's </a></font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="MyEO()" style="border-bottom: #0000cc 1px solid" id="tdEoSitetest"
                                                            runat="server">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/MYEOs.aspx">My EO's/Site Tests</a>&nbsp;</font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="MyApprovalCon()" style="border-bottom: #0000cc 1px solid" id="tdMyApproval"
                                                            runat="server">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/MyApprovals.aspx">My Approvals/Concurrences</a> </font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="MySiteTestCloseOut()" style="border-bottom: #0000cc 1px solid" id="tdMySiteColse"
                                                            runat="server">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/MyEOsAwaiting.aspx">My SiteTests Awaiting Close Out</a></font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="ChkConStatus()" style="border-bottom: #0000cc 1px solid">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/ConcurrenceStatus.aspx">Check Concurrence Status</a> </font>
                                                        </td>
                                                    </tr>
                                                    <tr onmouseout="defaultHome()">
                                                        <td onmouseover="AllESTests()" style="border-bottom: #0000cc 1px solid">
                                                            <font face="Arial, Helvetica, sans-serif" size="2"><a style="text-decoration: none"
                                                                href="../Reports/AllEOs.aspx">All EO's/Site Tests</a></font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdTemporary1" runat="server">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdTemporary2" runat="server">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdTemporary3" runat="server">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdTemporary4" runat="server">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdTemporary5" runat="server">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td id="tdTemporary6" runat="server">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                      
                                            </table>
                                        </td>
                                        <td width="80%">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr>
                                                    <td id="Td2" style="height: 57px" runat="server">
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdHomeDesc" valign="middle">
                                                                    <font color="#0033ff">
                                                                        <p align="justify">
                                                                            <b>Welcome to Procter &amp; Gamble Experimental Order Systems. This is an electronic
                                                                                process for completing all the experimental order applications. The system works
                                                                                in real time, allowing up to the minute updates on approval status. In addition
                                                                                email alerts are sent out to notify of any changes. </b>
                                                                        </p>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdnewProj" valign="middle">
                                                                    <font color="#0033ff">
                                                                        <p align="justify">
                                                                            <b>Create new Project. </b>
                                                                        </p>
                                                                    </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdnewEvent" runat="server">
                                                                    <font color="#0033ff"><b>Create new Event.</b> </font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdPrjList" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Open Project List page to generate reports like Projects By
                                                                        Category, Events by Category and My Events.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdNewEO" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Create new Experimental Order.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdserPrj" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Search Projects and Events information.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdApprEO" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "Approved Preliminary EO's" report. </b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdApprEOS" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "Approved EO's" report.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdArchEO" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "Archived EO's/SiteTests" report. </b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdCancelledEO" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "Cancelled EO's" report. </b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdMyEO" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "My EO's/Site Tests" report.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdMyApprCon" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "My Approvals/Concurrences" report.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdSTAWCO" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "My SiteTests Awaiting Close Out" report.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdChkConStatus" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "Check Concurrence Status" report.</b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="40%" align="center">
                                                            <tr>
                                                                <td id="tdAllEs" valign="middle" runat="server">
                                                                    <font color="#0033ff"><b>Generate "All EO's/Site Tests" report. </b></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <p>
                                    &nbsp;</p>
                                <p>
                                    &nbsp;</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:FooterControl ID="FooterControl1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    </TR></TBODY></TABLE> </form>
</body>
</html>
