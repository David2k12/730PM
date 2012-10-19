<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBudgetCenter.aspx.cs"
    Inherits="MUREOUI.Administration.WebForm3" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>ViewBudgetCenter</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td valign="top" align="left" width="20%">
                                    <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                    </uc1:LeftNavigationControlForAdmin>
                                </td>
                                <td valign="top" align="center" width="80%">
                                    <table id="tbl5" cellspacing="0" cellpadding="0" width="100%">
                                        <tr height="5">
                                            <td>
                                                <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr valign="middle" bgcolor="#ffffcc">
                                                        <td align="center" colspan="5" class="FormHeader">
                                                            View Budget Center
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:ImageButton ID="imgEdit" OnClick="imgEdit_click" runat="server" ImageUrl="../Images/edit.gif" ToolTip="Edit">
                                                            </asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif" ToolTip="Cancel">
                                                            </asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table id="Table3" cellspacing="0" cellpadding="0" align="center" border="0" width="100%">
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        <font class="FieldNamesLeft" size="3">Budget Center Number and Name:</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblBudgetCenterName" runat="server" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        Plant:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPlant" runat="server" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        Area:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblArea" runat="server" Width="50%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2">
                                                                        <strong>Budget Center Approvers</strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        Bounty:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTowel" runat="server" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        Charmin:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblBath" runat="server" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        Puffs:
                                                                    </td>
                                                                    <td style="height: 20px">
                                                                        <asp:Label ID="lblTissue" runat="server" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames">
                                                                        Default:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDefault" runat="server" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        SAP Cost Center Coordinator:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSAPCCC" runat="server" Width="100%"></asp:Label>
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
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
