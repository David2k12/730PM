<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeApprover.aspx.cs" Inherits="MUREOUI.Common.ChangeApprover" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bottomMargin="0" leftMargin="0" topMargin="0" onload="window.focus();" rightMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="45">
					<TD></TD>
				</TR>
				<tr align="center">
					<td><B>
							<asp:Label id="lbltitle" runat="server"> Please select approver from below dropdown</asp:Label></B>
					</td>
				</tr>
				<TR height="15">
					<TD></TD>
				</TR>
				<tr align="center">
					<td><asp:dropdownlist id="drpApprover" runat="server" Width="224px"></asp:dropdownlist></td>
				</tr>
				<TR height="25">
					<TD><asp:textbox id="txtBackUpName" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox></TD>
				</TR>
				<tr align="center">
					<td><asp:imagebutton id="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" 
                            onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;&nbsp;
						<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                            onclick="imgCancel_Click1"></asp:imagebutton></td>
				</tr>
			</table>
		</form>
	</body>
</html>
