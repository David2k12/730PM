<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCoachingBox.aspx.cs" Inherits="MUREOUI.Administration.EditCoachingBox" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EditCoachingBox</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:header id="adminHomeHeader" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table4" cellspacing="0" cellpadding="0" width="100%">
							<TR>
								<TD valign="top" align="left" width="20%">
									<uc1:leftnavigation id="adminLeftNavigation" runat="server"></uc1:leftnavigation></TD>
								<TD valign="top" align="center" width="80%">
									<TABLE id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
										<TR valign="middle" bgColor="#ffffcc">
											<TD align="center" colSpan="5"><FONT face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><STRONG></STRONG></FONT>
												<DIV><STRONG><FONT class="FormHeader" face="Arial" color="#0000ff">Edit Coaching Message</FONT></STRONG></DIV>
											</TD>
										</TR>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<TR>
											<TD align="center">
												<asp:imagebutton id="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" 
                                                    onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                                    onclick="imgCancel_Click"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD class="astrisk" align="center" colSpan="2">*- Mandatory Fields</TD>
										</TR>
										<TR>
											<TD colSpan="2">&nbsp;
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table2" cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
													<TR>
														<TD class="FieldNames">Message Name:&nbsp;&nbsp;</TD>
														<TD>
															<asp:textbox id="txtBoxMsgName" runat="server" Width="232px"></asp:textbox><FONT color="#ff3333">*</FONT></TD>
													</TR>
													<TR>
														<TD colSpan="2">&nbsp;
														</TD>
													</TR>
													<TR>
														<TD class="FieldNames">Message:&nbsp;&nbsp;</TD>
														<TD>
															<asp:textbox id="txtBoxMsg" runat="server" Width="232px" TextMode="MultiLine" Height="100px"></asp:textbox><FONT color="#ff3333">*</FONT></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				<TR>
					<TD>
						<uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
