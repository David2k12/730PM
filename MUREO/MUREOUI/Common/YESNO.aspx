<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YESNO.aspx.cs" Inherits="MUREOUI.Common.YESNO" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>YESNO</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
</head>
<body>
    <form id="form1" runat="server">
   <table id="" border="0" cellpadding="0" cellspacing="0" style="Z-INDEX: 101; LEFT: 48px; POSITION: absolute; TOP: 40px">
				<tr height="30">
					<td colspan="2"></td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblMessage" runat="server">Please add GCAS Material. Do you wish add now?</asp:Label></td>
				</tr>
				<tr height="30">
					<td colSpan="2"></td>
				</tr>
				<tr>
					<td align="right" width="50%">
						<asp:Button id="btnYes" runat="server" Width="75px" Text="Yes" 
                            onclick="btnYes_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</td>
					<td>
						<asp:Button id="btnNo" runat="server" Width="75px" Text="No" 
                            onclick="btnNo_Click"></asp:Button>&nbsp;
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
