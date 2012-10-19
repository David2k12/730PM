<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EODelete.aspx.cs" Inherits="MUREOUI.Reports.EODelete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EODelete</title>
		<base target="_self">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		    function btnClose() {
		        window.close();
		    }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="FirstTable" cellSpacing="0" cellPadding="0" width="50%" align="center" runat="server">
				<tr>
					<td>&nbsp;                    
                    </td>
				</tr>
				<tr id="DeleteEO" runat="server">
					<td align="center">Are you sure you want to delete this EO?</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr id="DeleteSite" runat="server">
					<td align="center">Are you sure you want to delete this Site Test?</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center"><asp:button id="btnDeleteYes" runat="server" Text="Yes" 
                            Width="75px" onclick="btnDeleteYes_Click1"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnDeleteNo" runat="server" Text="No" Width="75px" 
                            onclick="btnDeleteNo_Click1"></asp:button></td>
				</tr>
			</table>
			<table id="SecondTable" cellSpacing="0" cellPadding="0" width="50%" align="center" runat="server">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr id="DeleteEOEvents" runat="server">
					<td align="center">Do you want to delete all the events which are associated to 
						this EO?</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr id="DeleteSiteEvents" runat="server">
					<td align="center">Do you want to delete all the events which are associated to 
						this Site Test?</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center"><asp:button id="btnConfirmYes" runat="server" Text="Yes" 
                            Width="75px" onclick="btnConfirmYes_Click1"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;
						<asp:button id="btnConfirmNo" runat="server" Text="No" Width="75px" 
                            onclick="btnConfirmNo_Click1"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

