<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YESNOPSRA.aspx.cs" Inherits="MUREOUI.Common.YESNOPSRA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>YESNOPSRA</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
</head>
<body>
    <form id="form1" runat="server">
    <table id="" border="0" cellpadding="0" cellspacing="0" style="z-index: 101; left: 48px;
        position: absolute; top: 40px">
        <tr height="30">
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server">Please add PS & RA. Do you wish add now?</asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td align="right" width="50%">
                <asp:Button ID="btnYes" runat="server" Width="75px" Text="Yes"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="btnNo" runat="server" Width="75px" Text="No"></asp:Button>&nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
