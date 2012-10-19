<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCoachingBox.aspx.cs" Inherits="MUREOUI.Administration.AddCoachingBox" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddCoachingBox</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td><uc1:header id="adminHomeHeader" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td>
						<table cellspacing="0" cellpadding="0" width="100%" border="1">
							<tr>
								<td valign="top" align="left" width="20%"><uc1:leftnavigation id="adminLeftNavigation" runat="server"></uc1:leftnavigation></td>
								<td valign="top" align="center" width="80%">
									<table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
										<TR valign="middle" bgColor="#ffffcc">
											<TD align="center" colSpan="5"><FONT face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><STRONG></STRONG></FONT>
												<DIV><STRONG><FONT class="FormHeader" face="Arial" color="#0000ff" size="4">Create Coaching 
															Message</FONT></STRONG></DIV>
											</TD>
										</TR>
										<TR>
											<TD align="center"><asp:imagebutton id="imgSubmit" runat="server" ToolTip="Submit"
                                                    ImageUrl="../Images/submit.gif" onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" ToolTip="Cancel"
                                                    onclick="imgCancel_Click"></asp:imagebutton></TD>
										</TR>
										<tr height="1">
											<TD class="astrisk" align="center">*- Mandatory Fields</TD>
										</tr>
										<tr height="1">
											<td>&nbsp;</td>
										</tr>
										
										<TR>
											<TD>
												<TABLE id="Table2" cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
													<TR>
														<TD class="FieldNames">Message Name:</TD>
														<TD><asp:textbox id="txtBoxMsgName" runat="server" Width="232px"></asp:textbox><FONT color="#ff3333">*</FONT></TD>
													</TR>
													<TR>
														<TD colSpan="2">&nbsp;
														</TD>
													</TR>
													<TR>
														<TD class="FieldNames">Message:</TD>
														<TD><asp:textbox id="txtBoxMsg" runat="server" Width="232px" TextMode="MultiLine" Height="100px"></asp:textbox><FONT color="#ff3333">*</FONT></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				<tr>
					<td><uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></td>
				</tr>
			</table>
			</table></form>
</body>
</html>
