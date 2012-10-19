<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MUREOUI.Administration.Home" %>
<%@ Register src="../UserControls/LeftNavigationControlForAdmin.ascx" tagname="LeftNavigationControlForAdmin" tagprefix="uc2" %>
<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc3" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administration Home Page </title>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" border="1">
                    <tr width="200%">
                        <td width="20%">
                            &nbsp;
                            <uc2:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" 
                                runat="server" />
                        </td>
                        <td valign="top">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="maintainApproverNames" runat="server" 
                                            ImageUrl="..\Images\Maintain-Approver-Names.gif" ToolTip="Maintain Approver Names" 
                                            onclick="maintainApproverNames_Click1">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="maintainApproverGroups" runat="server" 
                                            ImageUrl="..\Images\Maintain-Approver-Groups.gif" ToolTip="Maintain Approver Groups"
                                            onclick="maintainApproverGroups_Click1">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="maintainBudgetCenters" runat="server" 
                                            ImageUrl="..\Images\Maintain-Budget-Centers.gif" ToolTip="Maintain Budget Centers"
                                            onclick="maintainBudgetCenters_Click1">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="maintaineoScopeOptions" runat="server" 
                                            ImageUrl="..\Images\Maintain-EO-Scope-Options.gif" ToolTip="Maintain EO Scope Options"
                                            onclick="maintaineoScopeOptions_Click1">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="maintainDataCoordinatorName" runat="server" ImageUrl="..\Images\Maintain-Data-Coordinator-N.gif" ToolTip="Maintain Data Coordinator Names"
                                        onclick="maintainDataCoordinatorName_Click1">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="maintainPurchasingContacts" runat="server" ImageUrl="..\Images\Maintain-Purchasing-Contact.gif" ToolTip="Maintain Purchasing Contact"
                                        onclick="maintainPurchasingContacts_Click1">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="maintainConcGrp" runat="server" 
                                            ImageUrl="..\Images\Maintain-Concurrence-Groups.gif" onclick="maintainConcGrp_Click1" ToolTip="Maintain Concurrence Groups"
                                         >
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="ViewCancelEO" runat="server" 
                                            ImageUrl="..\Images\View-Cancelled-EOsSite-Test.gif" onclick="ViewCancelEO_Click1" ToolTip="View Cancelled EO(s)/Site Tests"
                                        >
                                        </asp:ImageButton>&nbsp;&nbsp;
                                    </td>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="maintainSystemOwners" runat="server" ToolTip="Maintain System Owners"
                                                ImageUrl="..\Images\Maintain-System-Owners.gif" onclick="maintainSystemOwners_Click1"
                                             >
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="maintainOnrouteFyi" runat="server" ToolTip="Maintain OnRoute FYI"
                                                ImageUrl="..\Images\Maintain-OnRoute-FYI.gif" onclick="maintainOnrouteFyi_Click1"
                                            >
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="maintainPrescreenGroups" runat="server" ToolTip="Maintain Prescreen Groups"
                                                ImageUrl="..\Images\Maintain-Prescreen-Groups.gif" onclick="maintainPrescreenGroups_Click1"
                                            >
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="maintainCoachingBox" runat="server" ToolTip="Maintain Coaching Box"
                                                ImageUrl="..\Images\Maintain-Coaching-Box.gif" onclick="maintainCoachingBox_Click1"
                                             >
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="maintainBasicInfo" runat="server" ToolTip="Maintain Basic Information"
                                                ImageUrl="..\Images\Maintain-Basic-Information.gif" 
                                                onclick="maintainBasicInfo_Click1">
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="maintainBrandSegment" runat="server" ToolTip="Maintain Brand Segment"
                                                ImageUrl="..\Images\Maintain-Brand-Segment.gif" 
                                                onclick="maintainBrandSegment_Click1">
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="maintainPaperMachine" runat="server" ToolTip="Maintain Paper Machine"
                                                ImageUrl="..\Images\maintain-paper-machine4.gif" 
                                                onclick="maintainPaperMachine_Click1">
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="maintainConvertingMachine" runat="server" ToolTip="Maintain Converting Machine"
                                                ImageUrl="..\Images\Maintain-Converting--Machin.gif" 
                                                onclick="maintainConvertingMachine_Click1">
                                            </asp:ImageButton>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="lockedEOs" runat="server" ToolTip="LockedEO(s)"
                                                ImageUrl="..\Images\lockedEOS.gif" onclick="lockedEOs_Click1">
                                            </asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="Imagebutton1" ImageUrl="..\Images\maintainEOOriginator.gif" ToolTip="Maintain EO Originator"
                                                runat="server" onclick="Imagebutton1_Click1"></asp:ImageButton>&nbsp;&nbsp;
                                            <asp:ImageButton ID="Imagebutton2" ImageUrl="..\Images\maintainDistributionList.gif" ToolTip="Maintain Distribution List"
                                                runat="server" onclick="Imagebutton2_Click1"></asp:ImageButton>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                            </table>
                        </td>
                    </tr>
                    <tr width="200%">
                        <td width="20%">
                            &nbsp;</td>
                        <td valign="top">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <tr>
                <td>
                    <uc3:FooterControl ID="FooterControl1" runat="server" />
                </td>
            </tr>
    </table>
    </TABLE></form>
</body>
</html>
