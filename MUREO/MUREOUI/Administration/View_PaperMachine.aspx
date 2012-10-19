<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_PaperMachine.aspx.cs"
    Inherits="MUREOUI.Administration.View_PaperMachine" %>

<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>View_PaperMachine</title>
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
                        <uc1:Header ID="Header1" runat="server"></uc1:Header>
                    </td>
                </tr>
                <tr>
                    <td style="height: 320px">
                        <table width="100%" cellpadding="0" cellspacing="0" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" width="100%">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td class="FormHeader" align="center">
                                                View Paper Machine
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:HiddenField ID="txthiddenPlantID" runat="server" />
                                                <asp:HiddenField ID="txthiddenMachineID" runat="server" />
                                                <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/edit.gif"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../images/cancel.gif" CausesValidation="False">
                                                </asp:ImageButton>&nbsp;
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
                                                            Plant:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:Label ID="lblPlantName" runat="server" Width="200"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Machine Name:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:Label ID="lblMachineName" runat="server" Width="200"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr height="1">
                                                        <td>
                                                            &nbsp;
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
