<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminConfirm.aspx.cs" Inherits="MUREOUI.Administration.AdminConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BrandConfirm</title>
    <base target="_self" />
    <script type="text/javascript" language="javascript">
        function closeWindow(s) {
            window.close();
        }
    </script>
</head>
<body onload="window.focus();">
   <form id="Form1" method="post" runat="server">
			<table id="tabMain" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td>
						<table id="tab1" cellspacing="0" cellpadding="0" width="100%" border="0">
							<TR height="40">
								<TD></TD>
							</TR>
							<tr>
								<td align="center">Are you sure you want to delete this Brand Segment.</td>
							</tr>
							<tr height="30">
								<td></td>
							</tr>
							<tr>
								<td align="center">
									<asp:button id="btnYes" runat="server" Text="Yes" Width="75px" 
                                        CausesValidation=False onclick="btnYes_Click"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnNo" runat="server" Text="No" Width="75px" 
                                        CausesValidation=False ></asp:button></td>
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
