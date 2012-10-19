<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="MUREOUI.Common.help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Help</title>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table align="center">
        <tr height="6">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkIntro" runat="server" onclick="lnkIntro_Click">
    MUREO Introducton(Projects/Events)
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkTest" runat="server" onclick="lnkTest_Click">
    MUREO Administration
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkEo" runat="server" onclick="lnkEo_Click">
    MUREO Eo/Sitetest
                </asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
