<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCoachingBoxes.aspx.cs" Inherits="MUREOUI.Administration.ViewCoachingBoxes" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewCoachingBoxes</title>
    	<link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" language="javascript">
            function confirmBrandSegDelete() {
                document.getElementById('hdnResponse').value = "Y"
                return true;
//                if (!confirm('Are you sure u want to delete this Message Name?')) {
//                    document.getElementById('hdnResponse').value = "N"
//                    return false;
//                }
//                else {

//                    document.getElementById('hdnResponse').value = "Y"
//                    return true;
//                }
            }

            function BrandSegDelete(BrandSegment, userName) {
                var popResult;
                popResult = window.showModalDialog('../Administration/AddCoachingConfirm.aspx?BrandSegId=' + BrandSegment + '&userName=' + userName, null, 'dialogWidth:370px;dialogHeight:220px');
                if (popResult == "T") {
                    alert("The record was deleted successfully.");
                    window.location = "../Administration/ViewCoachingBoxes.aspx";
                }


            }
        </script>
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
										<TR valign="middle" style="background-color:#ffffcc">
											<TD align="center" colSpan="5"><FONT face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><STRONG></STRONG></FONT>
												<DIV><STRONG><FONT class="FormHeader" face="Arial" color="#0000ff">Maintain Coaching 
															Messages</FONT></STRONG></DIV>
											</TD>
										</TR>
										<TR>
											<TD>&nbsp;
											</TD>
										</TR>
										<TR>
											<TD align="center"><asp:imagebutton id="imgAdd" runat="server" ToolTip="Create Coaching Box" ImageUrl="../Images/create-coaching-box.gif" onclick="imgAdd_Click" />
											</TD>
										</TR>
										
										<TR>
											<TD>&nbsp;
											</TD>
										</TR>
										<TR>
											<TD valign="top" align="left" width="100%">
												<div style="OVERFLOW: auto;  HEIGHT: 330px">
													<table width="100%">
														<tr style="width:100%">
															<td width="100%">
																<%--<asp:datagrid id="dgdCoach" runat="server" AutoGenerateColumns="False" BorderWidth="1px" GridLines="None"
																	Width="100%" HeaderStyle-CssClass="SubHeader" BorderColor="Black" cellspacing="2">
																	<EditItemStyle CssClass="AlternateRow1"></EditItemStyle>
																	<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																	<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																	<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Message Name">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Left"></ItemStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblCoachMsgID" runat="server" Text ='<%# DataBinder.Eval(Container.Dataitem,"Help_Page_ID")%>' Visible=false>
																				</asp:Label>
																				<asp:linkbutton ID="lnkCoachMsgName" Runat="server" CommandName ="View_Coach" CommandArgument = '<%# DataBinder.Eval(Container.Dataitem,"Help_Page_ID")%>' text='<%# DataBinder.Eval(Container.Dataitem,"Key_Name")%>'>
																				</asp:linkbutton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Message">
																			<HeaderStyle HorizontalAlign="Left" Width="60%"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Left"></ItemStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblMsg" Runat ="server" Text='<%# DataBinder.Eval(Container.Dataitem,"Key_Value")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Delete Message">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle Wrap="False"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton Runat="server" ID="imgDeleteGroup" CommandName="DeleteMessage" CommandArgument='<%# DataBinder.Eval(Container.Dataitem,"Help_Page_ID")%>' ImageUrl="../Images/remove-icon.gif">
																				</asp:ImageButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid>--%>
                                                               
                                                                 <dx:ASPxGridView ID="dgdCoach" OnHtmlRowPrepared="dgdCoach_HtmlRowPrepared" KeyFieldName="Help_Page_ID" AllowSorting="True"
                                                                                Width="100%" runat="server" AutoGenerateColumns="False">
                                                                                <Columns>
                                                                                   
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Left" Width="25%" Caption="Message Name"
                                                                                        VisibleIndex="0">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblCoachMsgID" runat="server" Text='<%# Eval("Help_Page_ID")%>' Visible="false">
																				</asp:Label>
																				<asp:linkbutton ID="lnkCoachMsgName" Runat="server" OnCommand="lnkCoachMsgName_Command" CommandName ="View_Coach" CommandArgument = '<%# Eval("Help_Page_ID")%>' Text='<%# Eval("Key_Name")%>' ToolTip="View Message Name">
																				</asp:linkbutton>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Left" Width="60%" Caption="Message"
                                                                                        VisibleIndex="1">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblMsg" Runat ="server" Text='<%# Eval("Key_Value")%>'>
																				</asp:Label>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Center" Width="20%" Caption="Delete Message"
                                                                                        VisibleIndex="4">
                                                                                        <DataItemTemplate>
                                                                                            <asp:ImageButton Runat="server" ID="imgDeleteGroup" ToolTip="Delete Message" OnCommand="imgDeleteGroup_Command" CommandName="DeleteMessage" CommandArgument='<%# Eval("Help_Page_ID")%>' ImageUrl="../Images/remove-icon.gif" style="cursor:pointer">
																				</asp:ImageButton>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                   
                                                                                </Columns>
                                                                                <SettingsPager PageSize="20" Position="Bottom">
                                                                                </SettingsPager>
                                                                                <Styles>
                                                                                    <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                    </Header>
                                                                                </Styles>
                                                                            </dx:ASPxGridView>
                                                                
                                                                </td>
														</tr>
													</table>
												</div>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>

						</TABLE>
					</TD>
				<TR>
					<td><uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></td>
				</TR>
                <asp:HiddenField ID="hdnResponse" runat="server" />
			</TABLE>
		</form>
</body>
</html>
