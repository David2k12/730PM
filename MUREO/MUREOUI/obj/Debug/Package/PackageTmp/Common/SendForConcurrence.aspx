<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendForConcurrence.aspx.cs"
    Inherits="MUREOUI.Common.SendForConcurrence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SendForConcurrence</title>
    <base target="_self">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/EO.css" type="text/css" rel="stylesheet">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function closeWindow(s) {
            window.close();
        }
        function doHourglass() {
            document.body.style.cursor = 'wait';
        }

        function undoHourglass() {
            document.body.style.cursor = 'auto';
        }
    </script>
</head>
<body onfocus="undoHourglass();" onbeforeunload="doHourglass();" onunload="doHourglass();"
    ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table id="tblMain" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td align="left">
                <b>Concurrence&nbsp;Group&nbsp;Names:&nbsp;</b>
            </td>
            <td>
                <asp:ListBox ID="lbConcGrp" runat="server" Width="300px" SelectionMode="Multiple">
                </asp:ListBox>
                <font class="astrisk">*</font>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr height="6">
            <td>
            </td>
        </tr>
        <tr align="left">
            <td align="left">
                <b>Please enter your comments below...</b>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:TextBox ID="txtComments" runat="server" Width="350px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr height="6">
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:ImageButton ID="imgSendCon" runat="server" ImageUrl="../Images/Send-For-Concurrence.jpg"
                    OnClick="imgSendCon_Click"></asp:ImageButton>&nbsp;
                <asp:ImageButton ID="imgNewCancel" runat="server" ImageUrl="../Images/Cancel.gif"
                    CausesValidation="False" OnClick="imgNewCancel_Click"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="reqdBrandSegmt" runat="server" ControlToValidate="lbConcGrp"
                    Display="None" ErrorMessage="Please select Concurrence Group Name(s)."></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="vdsmEO" Style="z-index: 101; left: 16px; position: absolute;
                        top: 72px" runat="server" DisplayMode="List" ShowSummary="False" ShowMessageBox="True">
                    </asp:ValidationSummary>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
