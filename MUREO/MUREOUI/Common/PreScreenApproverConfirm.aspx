<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreScreenApproverConfirm.aspx.cs" Inherits="MUREOUI.Common.PreScreenApproverConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ApproverConfirm</title>
		<base target="_self">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		    function closeWindow(s) {
		        window.close();
		    }
		</script>
</head>
<body>
    <form id="form1" runat="server">
    	<table id="tabMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr id="trYesNo" align="center" runat="server">
					<td>
						<table id="tab1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr height="40">
								<td></td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td align="center"><asp:label id="lblYesNo" runat="server"> Are you  aligned to this test?</asp:label></td>
							</tr>
							<tr>
								<td align="center"><asp:label id="lblDecline" runat="server" Visible="False">Are you sure  to decline this EO.</asp:label></td>
							</tr>
							<tr height="30">
								<td></td>
							</tr>
							<tr>
								<td align="center"><asp:button id="btnYes" runat="server" Width="75px" Text="Yes" 
                                        onclick="btnYes_Click1"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnNo" runat="server" Width="75px" Text="Cancel"></asp:button>&nbsp;&nbsp;</td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trSAPIO" align="center" runat="server">
					<td>
						<table id="tabSAPIO" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td align="center">Enter SAPIO # here :
									<asp:textbox id="txtSAPIO" runat="server" Width="250px" TextMode="SingleLine" MaxLength="20"></asp:textbox>&nbsp;</td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trComments" align="center" runat="server">
					<td>
						<table id="tab3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr height="10">
								<td></td>
							</tr>
							<tr>
								<td align="center">Enter Comments here :&nbsp;&nbsp; &nbsp;
									<asp:textbox id="txtCommnets" runat="server" Width="375px" TextMode="MultiLine" Height="56px"></asp:textbox>&nbsp;</td>
							</tr>
							<tr height="10">
								<td></td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td align="center"><asp:button id="btnSubmit" runat="server" Width="75px" Text="OK" 
                                        onclick="btnSubmit_Click1"></asp:button></td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
