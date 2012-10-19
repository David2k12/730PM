<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalRouteConfirm.aspx.cs" Inherits="MUREOUI.Common.FinalRouteConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>RouteConfirm</title>
		<base target="_self">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		    function hourglass() { document.body.style.cursor = "wait"; } 
		    function ConfirmRoute(EOID, stage) {
		        //alert("Hi");
		        if (confirm('Are you sure you want to Route?')) {
		            //return true;
		            window.open('FinalRouteConfirm.aspx?EOID= + EOID + &Stage=FINAL&APPROVED=YES');
		        }
		        else {
		            window.close();
		        }
		    }  
		</script>
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
<body>
    <form id="form1" runat="server">
   	<table id="tabMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr id="trYesNo" align="center" runat="server">
					<td>
						<table id="tab1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
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
								<td align="center"><asp:label id="lblYesNo" runat="server">Are you sure  to route this EO?</asp:label></td>
							</tr>
							<TR>
								<TD align="center"></TD>
							</TR>
							<tr height="30">
								<td></td>
							</tr>
							<tr>
								<td align="center"><asp:button id="btnYes" runat="server" Width="75px" Text="Yes" 
                                        onclick="btnYes_Click1"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnNo" runat="server" Width="75px" Text="No" 
                                        onclick="btnNo_Click1"></asp:button></td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr height="30">
					<td></td>
				</tr>
				<tr id="TrPreliminary" align="center" runat="server">
					<td>
						<table id="TblPreliminary" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="0">
							<TR>
								<TD align="center">Preliminary Route Completed Successfully</TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr id="TrFinal" align="center" runat="server">
					<td>
						<table id="TblFinal" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center">Final Route Completed Successfully</TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr id="TrCloseOut" align="center" runat="server">
					<td>
						<table id="TblCloseOut" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center">CloseOut Route Completed Successfully</TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr height="30">
					<td></td>
				</tr>
				<tr id="TrOK" align="center" runat="server">
					<td>
						<table id="TblOK" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center">
									<asp:Button id="btnOk" runat="server" Width="50px" Text="Ok" 
                                        onclick="btnOk_Click1"></asp:Button></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
