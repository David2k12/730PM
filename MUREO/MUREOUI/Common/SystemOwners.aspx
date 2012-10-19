<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemOwners.aspx.cs" Inherits="MUREOUI.Common.SystemOwners" %>

<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/LeftNavigationControl.ascx" tagname="LeftNavigationControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SystemOwners</title>
</head>
<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="maintbl" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
                        <uc3:HeaderControl ID="HeaderControl1" runat="server" />
                    </td>
				</tr>
				<tr>
					<td vAlign="top">
						<table width="100%" cellpadding="0" cellspacing="0" border="1">
							<tr>
								<td width="20%">
                                    <uc2:LeftNavigationControl ID="LeftNavigationControl1" runat="server" />
                                </td>
								<td vAlign="top">
									<table id="tbl2" cellSpacing="0" cellPadding="0">
										<tr vAlign="middle" bgColor="#ffffcc">
											<td align="center" colSpan="5"><font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong>&nbsp; 
														Site System Owners </strong></font>
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="left" valign="top" width="100%" colspan="2">
												<div style="OVERFLOW: auto; HEIGHT: 330px">
													<table width="100%">
														<tr>
															<td width="100%" colspan="2">
																<asp:datagrid id="dtgrdPurchaseContact" Runat="server" BorderWidth="1px" GridLines="None" Width="100%"
																	HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False" BorderColor="Black" CellSpacing="2">
																	<EditItemStyle CssClass="AlternateRow1"></EditItemStyle>
																	<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																	<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																	<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Plant">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle Wrap="False" Width="20%"></ItemStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblPlantName" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"Plant_Name")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Phone Number">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblPhNumber" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"Phone_Number")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="System Owner">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblSysOwnerName" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"System_Owner_Name")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid></td>
														</tr>
													</table>
												</div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
                        <uc1:FooterControl ID="FooterControl1" runat="server" />
                    </td>
				</tr>
			</table>
		</form>
	</body>
</html>
