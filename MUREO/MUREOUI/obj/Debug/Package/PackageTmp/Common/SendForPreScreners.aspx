<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendForPreScreners.aspx.cs" Inherits="MUREOUI.Common.SendForPreScreners" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SendForPreScreners</title>
    <base target="_self">
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
<BODY onfocus="undoHourglass();" onbeforeunload="doHourglass();" onunload="doHourglass();"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblMain" style="Z-INDEX: 101; POSITION: absolute; TOP: 16px; LEFT: 40px" cellSpacing="0"
				cellPadding="0" border="0">
				<TR>
					<td class="FieldNames" style="HEIGHT: 60px">Prescreen Group Names&nbsp;&nbsp;&nbsp;
						<asp:dropdownlist id="ddlPrescrenNames" Runat="server" Width="216px"></asp:dropdownlist></td>
				</TR>
				<tr height="6">
					<td></td>
				</tr>
				<TR align="left">
					<TD align="left"><b>Please enter your comments below...</b>
					</TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtComments" runat="server" Width="464px"></asp:textbox></TD>
				</TR>
				<TR height="6">
					<TD></TD>
				</TR>
				<TR>
					<TD align="center"><asp:imagebutton id="imgSendCon" runat="server" 
                            ImageUrl="../Images/Send-For-Prescreeners.jpg" onclick="imgSendCon_Click"></asp:imagebutton>&nbsp;
						<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/Cancel.gif" 
                            CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton></TD>
				</TR>
			</table>
		</form>
	</BODY>
</html>
