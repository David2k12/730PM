<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyEOScopeBudget.aspx.cs"
    Inherits="MUREOUI.Administration.ModifyEOScopeBudget" %>

<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Suggested Budget Center</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">


        function CheckBudget(sender, args) {
            if (document.getElementById('drpBudgetName').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckPlantName(sender, args) {
            if (document.getElementById('drpPlant').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckEOScope(sender, args) {
            if (document.getElementById('drpEOScopeName').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
		
		
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="scp1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upbudget" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:Header ID="Header1" runat="server"></uc1:Header>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" width="100%">
                                        <tr id="trCreatePC" valign="middle" bgcolor="#ffffcc" runat="server">
                                            <td class="FormHeader" align="center">
                                                Create&nbsp;Suggested&nbsp;Budget Center&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trEditPC" valign="middle" bgcolor="#ffffcc" runat="server">
                                            <td class="FormHeader" align="center">
                                                Edit&nbsp;Suggested&nbsp;Budget Center
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../images/cancel.gif"
                                                    CausesValidation="False"></asp:ImageButton>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="astrisk" align="center">
                                                *- Mandatory Fields
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table id="tbl3" height="3" width="100%" align="left" border="0">
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right" width="50%">
                                                            EO Scope Name:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="drpEOScopeName" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                            <font class="astrisk"></font>
                                                            <asp:Label ID="lblCompulsory1" runat="server" CssClass="astrisk">*</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr height="1">
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Plant:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="drpPlant" runat="server" Width="200" OnSelectedIndexChanged="drpPlant_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <font class="astrisk"></font>
                                                            <asp:Label ID="lblCompulsory2" runat="server" CssClass="astrisk">*</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr height="1">
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Budget Center Name:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <font class="astrisk">
                                                                <asp:DropDownList ID="drpBudgetName" runat="server" Width="200px">
                                                                </asp:DropDownList>
                                                                &nbsp;*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            &nbsp;
                                                        </td>
                                                        <td onkeypress="javascript: return AllowPhoneChk(event);" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ValidationSummary ID="PurchaseValidationSummary" runat="server" ShowSummary="False"
                                                                ShowMessageBox="True" BorderStyle="None" DisplayMode="List"></asp:ValidationSummary>
                                                            <asp:CustomValidator ID="cstvScope" runat="server" Display="None" ErrorMessage="Please select EO Scope Name."
                                                                ClientValidationFunction="CheckEOScope" ControlToValidate="drpEOScopeName"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cstvdPlantName" runat="server" ClientValidationFunction="CheckPlantName"
                                                                ErrorMessage="Please select Plant" Display="None" ControlToValidate="drpPlant"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cstvdMaterialType" runat="server" ClientValidationFunction="CheckBudget"
                                                                ErrorMessage="Please select Budget Center Name" Display="None"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:Footer ID="adminHomeFooter" runat="server"></uc1:Footer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
