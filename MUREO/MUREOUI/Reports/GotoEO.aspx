<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GotoEO.aspx.cs" Inherits="MUREOUI.Reports.GotoEO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GotoEO</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function closeForm() {
            window.close();
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr align="center">
            <td class="FormHeader" align="center">
                <asp:Label ID="lblHeading" runat="server">Goto EO</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <b>EO number to Open:</b>&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="drpEONumber" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgOpenEOEdit" runat="server" AlternateText="Open EO for Edit."
                    ImageUrl="../Images/open-eo-for-edit.gif" onclick="imgOpenEOEdit_Click"></asp:ImageButton>&nbsp;&nbsp;
                <asp:ImageButton ID="imgEOReadOnly" runat="server" AlternateText="Open EO as Read Only"
                    ImageUrl="../Images/open-EO-as-read-only.gif" 
                    onclick="imgEOReadOnly_Click"></asp:ImageButton>&nbsp;&nbsp;
                <asp:ImageButton ID="imgCancel" runat="server" AlternateText="Cancel" 
                    ImageUrl="../Images/cancel.gif" onclick="imgCancel_Click">
                </asp:ImageButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
