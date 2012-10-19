<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveYesNo.aspx.cs" Inherits="MUREOUI.Common.ApproveYesNo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ApproveYesNo</title>
    <base target="_self">
    <script language="javascript">
		    function hourglass() { document.body.style.cursor = "wait"; } </script>
</head>
<body bottomMargin="0" leftMargin="0" topMargin="0" onload="window.focus();" rightMargin="0"
		MS_POSITIONING="GridLayout">
   <form id="Form1" method="post" runat="server">
			<table id="tabMain" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="TR1" runat="server">
					<td>
						<table id="tab1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="40">
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblYesNo" runat="server">Are you sure  to approve this EO.</asp:label></td>
							</tr>
							<TR>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblDecline" runat="server">Are you sure  to decline this EO.</asp:label>
								</TD>
							</TR>
							<tr height="30">
								<td></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnYes" runat="server" Text="Yes" Width="75px"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnNo" runat="server" Text="No" Width="75px"></asp:button></td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="TR3" runat="server">
					<td>
						<table id="tab3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>Enter Comments here :
									<asp:textbox id="txtCommnets" runat="server" Width="416px" TextMode="MultiLine"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp;&nbsp;
									<asp:button id="btnSubmit" runat="server" Text="ok" Width="48px"></asp:button></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
</body>
</html>
