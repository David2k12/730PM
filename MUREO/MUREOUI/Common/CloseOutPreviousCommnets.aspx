<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloseOutPreviousCommnets.aspx.cs" Inherits="MUREOUI.Common.CloseOutPreviousCommnets" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>CloseOutPreviousCommnets</title>
		<base target =_self> 
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
  <table id="maintbl" cellpadding="0" cellspacing="0" width="100%">
				<tr height="5">
					<td>
					</td>
				</tr>
				<tr class="SubHeader">
					<td>Previous Comments
					</td>
				</tr>
				<tr height="5">
					<td>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="lblCloseOutPreviousCommnets" runat="server"></asp:Label>&nbsp;
					</td>
				</tr>
				<tr height="25">
					<td>
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:Button id="Button1" runat="server" Text="ok" Width="75px" 
                            onclick="Button1_Click1"></asp:Button>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
