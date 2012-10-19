<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainEOScopeBudget.aspx.cs"
    Inherits="MUREOUI.Administration.MaintainEOScopeBudget" %>

<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>View Suggested Budget Center</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="maintbl" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 320px">
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td width="20%"><uc1:leftnavigation id="LeftNavigation1" runat="server"></uc1:leftnavigation></td>
								<td vAlign="top">
									<table id="tbl2" width="100%">
										<tr vAlign="middle" bgColor="#ffffcc">
											<td class="FormHeader" align="center">View Suggested Budget Center
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="center" colSpan="2"><asp:imagebutton id="imgSubmit" OnClick="imgSubmit_Click" Runat="server" ImageUrl="../Images/edit.gif"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" OnClick="imgCancel_Click" Runat="server" ImageUrl="../images/cancel.gif" CausesValidation="False"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgDelete"  Runat="server" ImageUrl="../images/delete.gif" Visible="False"></asp:imagebutton></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td vAlign="top">
												<table id="tbl3" height="3" width="100%" align="left" border="0">
													<tr>
														<td class="FieldNames" vAlign="top" align="right" width="42%"><asp:label id="lblScopeID" runat="server" Visible="False"></asp:label>EO 
															Scope Name:&nbsp;&nbsp;</td>
														<td vAlign="top"><asp:label id="lblScopeName" Width="360px" Runat="server"></asp:label></td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" vAlign="top" align="right" width="42%"><asp:label id="lblPlantID" runat="server" Visible="False"></asp:label>Plant:&nbsp;&nbsp;
														</td>
														<td vAlign="top"><asp:label id="lblPlantName" Runat="server" width="368px"></asp:label></td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" style="HEIGHT: 15px" vAlign="top" align="right" width="42%"><asp:label id="lblBudgetID" runat="server" Visible="False"></asp:label>Budget 
															Center Name:&nbsp;&nbsp;</td>
														<td style="HEIGHT: 15px" vAlign="top"><asp:label id="lblBudgetCenter" Width="368px" Runat="server"></asp:label></td>
													<tr height="1">
														<td colSpan="2">&nbsp;</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
