<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EOTimeLock.aspx.cs" Inherits="MUREOUI.Common.EOTimeLock" %>

<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body MS_POSITIONING="GridLayout" bottommargin="0" topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form2" method="post" runat="server">
			<DIV align="center">
				<table border="0" cellspacing="0" cellpadding="0" align="center" width="100%">
					<tr>
						<td>
							<uc2:HeaderControl ID="HeaderControl1" runat="server" />
                        </td>
					</tr>
					<tr valign="top">
						<td><div align="center"><b><font size="4" color="#ff1f10" face="Arial">Your Edit Has Timed Out</font></b><br>
								<b><font size="4" color="#ff1f10" face="Arial">NOTE: You may have lost some of your 
										data!!</font></b><br>
								<hr width="100%" size="2" align="center">
								<br>
								<i><font color="#003366" face="Arial">You have had this document in edit mode for more 
										than 60 minutes..</font></i><br>
							</div>
							<br>
							<font face="Arial Narrow">This database employs a "timeout" feature to facilitate 
								the locking of documents to prevent data loss from multiple people trying to 
								edit the same document at the same time.</font><div align="center"><br>
								<b><font size="6" color="#ff3300" face="Arial">Please Edit The Document Again Later</font></b></div>
						</td>
					</tr>
				</table>
			</DIV>
			<br>
			<br>
			<br>
			<div align="center"><font face="Arial">If this problems persists, please contact your 
					EO Administrator</font><br>
			</div>
			<table width="100%" border="0" align="center">
				<tr>
					<td>
						<uc1:FooterControl ID="FooterControl1" runat="server" />
                    </td>
				</tr>
			</table>
		</form>
	</body>
</html>
