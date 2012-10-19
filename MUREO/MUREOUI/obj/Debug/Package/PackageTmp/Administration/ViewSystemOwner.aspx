<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSystemOwner.aspx.cs" Inherits="MUREOUI.Administration.ViewSystemOwner" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewSystemOwner</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
   
</head>
<body>
   <form id="Form1" method="post" runat="server">
			<table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td>
						<table width="100%" cellspacing="0" cellpadding="0" border="1">
							<tr>
								<td width="20%"><uc1:leftnavigation id="LeftNavigation1" runat="server"></uc1:leftnavigation></td>
								<td valign="top">
									<table id="tbl2" width="100%">
										<tr valign="middle" bgColor="#ffffcc">
											<td class="FormHeader" align="center">View EO Site System Owner
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="center" colspan="2">
                                           <%-- <asp:textbox id="txthiddenPlantID" Runat="server" Width="0"></asp:textbox>--%>
                                           <asp:HiddenField ID="txthiddenPlantID" runat="server" />
                                           <%-- <asp:textbox id="txthiddenSysOwnId" runat="server" Width="0"></asp:textbox>--%>
                                              <asp:HiddenField ID="txthiddenSysOwnId" runat="server" />
                                            <asp:imagebutton id="imgSubmit" Runat="server" ImageUrl="../Images/edit.gif" ToolTip="Edit"
                                                    onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" Runat="server" ImageUrl="../images/cancel.gif" ToolTip="Cancel"
                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgDelete" Runat="server" ImageUrl="../images/delete.gif" ToolTip="Delete"
                                                    Visible="False" onclick="imgDelete_Click"></asp:imagebutton></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td valign="top">
												<table id="tbl3" height="3" width="100%" align="left" border="0">
													<tr>
														<td class="FieldNames" valign="top" align="right" width="50%">Plant:&nbsp;&nbsp;</td>
														<td valign="top"><asp:label id="lblPlantName" Runat="server" Width="200"></asp:label></td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" valign="top" align="right">System Owner Name:&nbsp;&nbsp;</td>
														<td valign="top"><asp:label id="lblApprover" Runat="server" Width="200"></asp:label></td>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" valign="top" align="right">Phone Number:&nbsp;&nbsp;
														</td>
														<td valign="top"><asp:label id="lblPhoneNumber" Runat="server" Width="200"></asp:label></td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
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
</html>
