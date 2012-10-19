<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDataCoordinator.aspx.cs" Inherits="MUREOUI.Administration.ViewDataCoordinator" %>
<%@Register tagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx"%>
<%@Register tagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx"%>
<%@Register tagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewDataCoordinator</title>
    <LINK href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<TABLE id="maintbl" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:headercontrol id="HeaderControl" runat="server"></uc1:headercontrol></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl1" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD vAlign="top" align="left" width="20%"><uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin></TD>
								<TD vAlign="top" align="center" width="80%">
									<TABLE id="tbl2" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD vAlign="middle" align="center" colSpan="5"><!--	<table id="tbl3" cellpadding="0" cellspacing="0" width="90%" style="BORDER-RIGHT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-BOTTOM: #898989 1px solid">
												<tr>
													<td colspan="6" bgcolor="#f8f8f8" align="center">-->
												<TABLE id="Table1" width="100%">
													<TR vAlign="middle" bgColor="#ffffcc">
														<TD class="FormHeader" align="center">View Data Coordinator</TD>
													</TR>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR>
														<TD align="center" colSpan="2"><asp:imagebutton id="imgEdit" Runat="server" 
                                                                ImageUrl="../Images/edit.gif" onclick="imgEdit_Click"></asp:imagebutton>&nbsp;
															<asp:imagebutton id="imgCancel" Runat="server" ImageUrl="../images/cancel.gif" 
                                                                CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton>&nbsp;
														</TD>
													</TR>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR>
														<TD vAlign="top" align="center">
															<TABLE id="tbl3" height="3" width="100%" align="center" border="0">
																<TR>
																	<TD class="FieldNames" vAlign="top" align="right" style="HEIGHT: 21px">Category:</TD>
																	<TD vAlign="top" align="left" style="HEIGHT: 21px"><asp:label id="lblCategory" runat="server" Width="232px"></asp:label></TD>
																</TR>
																<TR height="1">
																	<TD width="50%">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames" vAlign="top" align="right">Approver:
																	</TD>
																	<TD vAlign="top" align="left"><asp:label id="lblCo" runat="server" Width="232px"></asp:label></TD>
																</TR>
																<TR height="1">
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames" vAlign="top" align="right">&nbsp;Phone Number:</TD>
																	<TD vAlign="top" align="left"><asp:label id="lblPhone" runat="server" Width="200px"></asp:label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD width="100%"><uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol></TD>
				</TR>
			</TABLE>
		</form>
</body>
</html>
