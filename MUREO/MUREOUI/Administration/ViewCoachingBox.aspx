<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCoachingBox.aspx.cs" Inherits="MUREOUI.Administration.ViewCoachingBox" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewCoachingBox</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="adminHomeHeader" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table4" cellspacing="0" cellpadding="0" width="100%" border="1">
							<TR>
								<TD valign="top" align="left" width="20%"><uc1:leftnavigation id="adminLeftNavigation" runat="server"></uc1:leftnavigation></TD>
								<TD valign="top" align="center" width="80%">
									<TABLE id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
										<TR valign="middle" bgColor="#ffffcc">
											<TD align="center" colSpan="5"><FONT face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><STRONG></STRONG></FONT>
												<DIV><STRONG><FONT class="FormHeader" face="Arial" color="#0000ff">View Coaching Message</FONT></STRONG></DIV>
											</TD>
										</TR>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<TR>
											<TD align="center"><asp:imagebutton id="imgEdit" runat="server" ToolTip="Edit" 
                                                    ImageUrl="../Images/edit.gif" onclick="imgEdit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                                    ToolTip="Cancel" onclick="imgCancel_Click"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD colSpan="2">&nbsp;
												<TABLE id="Table2" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
													<TR>
														<TD class="FieldNames" width="50%">Message Name:&nbsp;&nbsp;</TD>
														<TD align="left"><asp:label id="lblMsgName" runat="server" Width="50%"></asp:label></TD>
													</TR>
													<TR>
														<TD colSpan="2">&nbsp;</TD>
													</TR>
													<TR>
														<TD class="FieldNames" width="50%">Message:&nbsp;&nbsp;</TD>
														<TD align="left"><asp:label id="lblMsg" runat="server" Width="300px"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD valign="middle" align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				<TR>
					<TD><uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
