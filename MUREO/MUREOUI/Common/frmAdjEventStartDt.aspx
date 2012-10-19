<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdjEventStartDt.aspx.cs" Inherits="MUREOUI.Common.frmAdjEventStartDt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdjustEventStartDate</title>
    <LINK href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function AllowNumeric(e) {
            var iKeyCode = 0;
            if (window.event)
                iKeyCode = window.event.keyCode
            else if (e)
                iKeyCode = e.which;
            if (iKeyCode > 47 && iKeyCode < 58)
                return true
            else
                return false;
        }

        function close1() {
            window.close();
        }

        function CheckProjectName(sender, args) {
            if (document.getElementById('drpProject').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
		
		</script>
</head>
<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
				<tr>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
							<tr align="center">
								<td class="FormHeader" align="center" colSpan="2"><asp:label id="lblHeading" Runat="server">Adjust Event Start Dates</asp:label></td>
							</tr>
							<tr height="20">
								<td></td>
							</tr>
							<tr>
								<td class="FieldNames">Project:&nbsp;&nbsp;</td>
								<td><asp:dropdownlist id="drpProject" Runat="server" Width="280px"></asp:dropdownlist><FONT class="astrisk">*
										<asp:customvalidator id="csvProjectName" runat="server" ErrorMessage="Please select a project." Display="None"
											ControlToValidate="drpProject" ClientValidationFunction="CheckProjectName"></asp:customvalidator></FONT></td>
							</tr>
							<tr>
								<td class="FieldNames" style="HEIGHT: 24px">Day(s)&nbsp;to adjust?:&nbsp;&nbsp;</td>
								<td onkeypress="javascript: return AllowNumeric(event);" style="HEIGHT: 24px"><asp:textbox id="txtWeeks" Runat="server" MaxLength="3"></asp:textbox><FONT class="astrisk">*</FONT>
									<asp:requiredfieldvalidator id="rfvWeeks" runat="server" ErrorMessage="Please enter a number for days to adjust."
										Display="None" ControlToValidate="txtWeeks"></asp:requiredfieldvalidator></td>
							</tr>
							<tr height="20">
								<td colSpan="2"></td>
							</tr>
							<tr>
								<td colSpan="2"><asp:validationsummary id="vdsAdjustEventStart" runat="server" ShowMessageBox="True" ShowSummary="False"
										DisplayMode="List"></asp:validationsummary></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:imagebutton id="imgSubmit" Runat="server" 
                                        ImageUrl="../Images/submit.gif" onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
									<asp:imagebutton id="imgCancel" Runat="server" ImageUrl="../images/cancel.gif" 
                                        CausesValidation="False" onclick="btnCancel_Click"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
