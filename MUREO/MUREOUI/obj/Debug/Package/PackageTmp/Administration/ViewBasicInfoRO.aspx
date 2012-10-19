<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBasicInfoRO.aspx.cs" Inherits="MUREOUI.Administration.ViewBasicInfoRO" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewBasicInfoRO</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
				<TBODY>
					<tr>
						<td><uc1:headercontrol id="HeaderControl1" runat="server"></uc1:headercontrol></td>
					</tr>
					<tr>
						<td>
							<table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
								<tr>
									<td valign="top" align="left" width="20%"><uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin2" runat="server"></uc1:leftnavigationcontrolforadmin></td>
									<td valign="top" align="center">
										<table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td valign="middle" align="center" colspan="5">
													<table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
														<tr class="FormHeader">
															<td colspan="2">View Basic Information</td>
														</tr>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td align="center" colspan="2"><asp:imagebutton id="imgEdit" 
                                                                    ImageUrl="../Images/edit.gif" Runat="server" onclick="imgEdit_Click"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
																<asp:imagebutton id="imgDelete" runat="server" ImageUrl="../Images/delete.gif" 
                                                                    AlternateText="Delete" onclick="imgDelete_Click"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
																<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton></td>
														</tr>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr height="35">
															<td class="FieldNames" align="right" width="48%">Key :</td>
															<td align="left" width="52%">&nbsp;
																<asp:Label id="lblKeyText" runat="server"></asp:Label><asp:label id="lblKey" runat="server" Visible="False"></asp:label></td>
														</tr>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td class="FieldNames" valign="top" align="right">Value&nbsp;:
															</td>
															<td valign="top" align="left">&nbsp;
																<asp:label id="lblValue" runat="server"></asp:label><asp:label id="lblKeyValue" runat="server" Visible="False"></asp:label></td>
														</tr>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr height="10">
															<td style="HEIGHT: 20px" colspan="2"></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr height="5">
												<td colspan="5">&nbsp;</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol></td>
					</tr>
					<tr>
						<td></td>
					</tr>
				</TBODY>
			</table>
		</form>
</body>
</html>
