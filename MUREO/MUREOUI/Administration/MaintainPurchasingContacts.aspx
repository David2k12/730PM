<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainPurchasingContacts.aspx.cs"
    Inherits="MUREOUI.Administration.MaintainPurchasingContacts" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>MaintainPurchasingContacts</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">

</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <script language="javascript">

            function confirmPurchasingContactDelete(Contact) {
                var msg = 'Are you sure you want to delete this Purchasing Contact ' + '\'' + Contact + '\' ?'
                if (!confirm(msg)) {
                    document.getElementById("<%=hdnresponse.ClientID %>").value = "N"
                    return false;
                }
                else {
                    document.getElementById("<%=hdnresponse.ClientID %>").value = "Y"
                    return true;
                }

            }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:Header ID="Header1" runat="server"></uc1:Header>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%" align="center">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td align="center" colspan="5">
                                                <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong>&nbsp;Maintain
                                                    Purchasing Contacts </strong></font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgAddPContact" OnClick="imgAddPContact_Click" runat="server"
                                                    ImageUrl="../Images/create-new-purchase.gif" AlternateText="Add Concurrence Group.">
                                                </asp:ImageButton>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr width="100%">
                                            <td align="left" colspan="5" valign="top">
                                                <div style="overflow: auto; height: 330px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <%--	<asp:datagrid id="dtgrdPurchaseContact" Runat="server" BorderColor="Black" AutoGenerateColumns="False"
																	HeaderStyle-CssClass="SubHeader" Width="100%" GridLines="None" BorderWidth="1px" CellSpacing="2">
																	<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																	<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																	<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Plant">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle Wrap="False" Width="20%"></ItemStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblPlantName" Runat="server" text='<%# Eval("Plant_Name")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Material Type">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="Label3" Runat="server" text='<%# Eval("Material_Type_Name")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Purchasing Contact">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblPlantID" Runat="server" Visible=False text='<%# Eval("Plant_ID")%>'>
																				</asp:Label>
																				<asp:Label ID="lblPName" Runat="server" Visible=False text='<%# Eval("Plant_Name")%>'>
																				</asp:Label>
																				<asp:Label ID="lblPContactID" Runat="server" Visible=False text='<%# Eval("Purchase_Contact_ID")%>'>
																				</asp:Label>
																				<asp:Label ID="lblMaterialID" Runat="server" Visible=False text='<%# Eval("Material_Type_ID")%>'>
																				</asp:Label>
																				<asp:Label ID="lblMname" Runat="server" Visible=False text='<%# Eval("Material_Type_Name")%>'>
																				</asp:Label>
																				<asp:Label ID="lblPhNo" Visible=False Runat="server" text='<%# Eval("Phone_Number")%>'>
																				</asp:Label>
																				<asp:LinkButton ID="lnkApproverName" CommandName="MachineName_Link" Runat="server">
																					<%# Eval("Approver_Name")%>
																				</asp:LinkButton>
																				<asp:Label ID="lblApproverName" Visible=False Runat="server" text='<%# Eval("Approver_Name")%>'>
																				</asp:Label>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Phone Number">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblPhNumber" Runat="server" text='<%# Eval("Phone_Number")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Remove Purchasing Contact?">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle Wrap="False"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton Runat="server" ID="imgDeleteGroup" CommandName="DeletePcontact" CommandArgument='<%# Eval("Purchase_Contact_ID")%>' ImageUrl="../Images/remove-icon.gif">
																				</asp:ImageButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid>--%>
                                                                <dx:ASPxGridView ID="dtgrdPurchaseContact" KeyFieldName="Purchase_Contact_ID" Width="100%"
                                                                    runat="server" AutoGenerateColumns="False" OnHtmlRowPrepared="dtgrdPurchaseContact_HtmlRowPrepared"
                                                                    OnPageIndexChanged="dtgrdPurchaseContact_PageIndexChanged">
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant Name"
                                                                            VisibleIndex="0">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Material Type"
                                                                            VisibleIndex="1">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Material_Type_Name")%>'>
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Purchasing Contact"
                                                                            VisibleIndex="2">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblPlantID" runat="server" Visible="False" Text='<%# Eval("Plant_ID")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblPName" runat="server" Visible="False" Text='<%# Eval("Plant_Name")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblPContactID" runat="server" Visible="False" Text='<%# Eval("Purchase_Contact_ID")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblMaterialID" runat="server" Visible="False" Text='<%# Eval("Material_Type_ID")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblMname" runat="server" Visible="False" Text='<%# Eval("Material_Type_Name")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblPhNo" Visible="False" runat="server" Text='<%# Eval("Phone_Number")%>'>
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkApproverName" OnCommand="lnkApproverName_Command" PlantName='<%# Eval("Plant_Name")%>'
                                                                                    MaterialType='<%# Eval("Material_Type_Name")%>' phno='<%# Eval("Phone_Number")%>'
                                                                                    PContactID='<%# Eval("Purchase_Contact_ID")%>' CommandArgument='<%# Eval("Plant_ID")%>'
                                                                                    ApproverName='<%# Eval("Approver_Name")%>' CommandName='<%# Eval("Material_Type_ID")%>'
                                                                                    runat="server">
																					<%# Eval("Approver_Name")%>
                                                                                </asp:LinkButton>
                                                                                <asp:Label ID="lblApproverName" Visible="False" runat="server" Text='<%# Eval("Approver_Name")%>'>
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Phone Number"
                                                                            VisibleIndex="3">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblPhNumber" runat="server" Text='<%# Eval("Phone_Number")%>'>
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                            EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Remove Purchasing Contact"
                                                                            VisibleIndex="4">
                                                                            <DataItemTemplate>
                                                                                <%-- <asp:ImageButton runat="server" style="cursor:pointer" ToolTip="Remove Purchasing Contact" ID="imgDeleteGroup" OnCommand="imgDeleteGroup_Command" CommandName='<%# Eval("Purchase_Contact_ID")%>'
                                                                            CommandArgument='<%# Eval("Purchase_Contact_ID")%>'
                                                                            ImageUrl="../Images/remove-icon.gif"></asp:ImageButton>--%>
                                                                                <dx:ASPxButton Image-Url="../Images/remove-icon.gif" ID="imgDeleteGroup" OnCommand="imgDeleteGroup_Command"
                                                                                    CommandName='<%# Eval("Purchase_Contact_ID")%>' CommandArgument='<%# Eval("Purchase_Contact_ID")%>'
                                                                                    ToolTip="Remove Purchasing Contact" Style="cursor: pointer" runat="server">
                                                                                </dx:ASPxButton>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <SettingsPager PageSize="20" NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous"
                                                                        Position="Bottom">
                                                                    </SettingsPager>
                                                                    <Settings GridLines="None" />
                                                                    <Styles>
                                                                        <Header Font-Bold="true" BackColor="#FFCC00">
                                                                        </Header>
                                                                    </Styles>
                                                                </dx:ASPxGridView>
                                                            </td>
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
                        <uc1:Footer ID="adminHomeFooter" runat="server"></uc1:Footer>
                    </td>
                </tr>
            </table>
            <%--<input id="response" type="hidden" name="response">--%>
            <asp:HiddenField ID="hdnresponse" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
