<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEOScopeOptions.aspx.cs"
    Inherits="MUREOUI.Administration.ViewEOScopeOptions" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>ViewEOScopeOptions</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function confirmScopeDelete(Scope_Option_Name) {

            var msg = 'Are you sure you want to delete this scope option ' + '\'' + Scope_Option_Name + '\' ?'
            if (!confirm(msg)) {
                document.getElementById("<%=hdnresponse.ClientID %>").value = "N";
                return false;
            }
            else {
                document.getElementById("<%=hdnresponse.ClientID %>").value = "Y";
                return true;
            }
        }
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
    </script>
</head>
<body ms_positioning="GridLayout" onload="setScreenRes();">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td style="height: 23px">
                        <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td valign="top" align="left" width="20%">
                                    <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                    </uc1:LeftNavigationControlForAdmin>
                                </td>
                                <td valign="top" align="center" width="80%">
                                    <table id="tbl5" cellspacing="0" cellpadding="0" width="100%">
                                        <tr height="5">
                                            <td>
                                                <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr valign="middle" bgcolor="#ffffcc">
                                                        <td style="height: 27px" align="center" colspan="5">
                                                            <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                            </font>
                                                            <div class="FormHeader">
                                                                Maintain EO Scope Options</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="DataGridBorderColor" align="center">
                                                            <p>
                                                                <asp:ImageButton ID="imgCreateApprover" OnClick="imgCreateApprover_Click" runat="server"
                                                                    ImageUrl="../Images/create-eo-scope-option.gif"></asp:ImageButton>&nbsp;&nbsp;
                                                                <asp:ImageButton ID="imgSuggestBudgetCenter" OnClick="imgSuggestBudgetCenter_Click"
                                                                    runat="server" ImageUrl="../Images/Suggested-Budget-Centers.gif" AlternateText="SuggestedBudgetCenter">
                                                                </asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <div id="divtest" style="overflow: auto; width: 780px; height: 400px">
                                                                <dx:ASPxGridView ID="drgEOScope" OnHtmlRowPrepared="drgEOScope_HtmlRowPrepared" KeyFieldName="SO_ID"
                                                                    Width="100%" runat="server" OnPageIndexChanged="drgEOScope_PageIndexChanged"
                                                                    AutoGenerateColumns="False">
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Scope Option"
                                                                            VisibleIndex="1">
                                                                            <DataItemTemplate>
                                                                                <asp:LinkButton ID="lnkScopeName" OnCommand="lnkScopeName_Command" CommandName="View_Scope"
                                                                                    CommandArgument='<%# Eval("SO_ID")%>' runat="server" Text='<%# Eval("Scope_Option_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                            EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Delete EO Scope Option"
                                                                            VisibleIndex="2">
                                                                            <DataItemTemplate>
                                                                                <%--<asp:ImageButton runat="server" ID="ImgRemoveScope" ToolTip="Delete EO Scope Option" style="cursor:pointer" OnCommand="ImgRemoveScope_Command"
                                                                                    CommandName="RemoveScope" CommandArgument='<%#Eval("SO_ID")%>' ImageUrl="../Images/remove-icon.gif">
                                                                                </asp:ImageButton>--%>
                                                                                <dx:ASPxButton Image-Url="../Images/remove-icon.gif" ID="ImgRemoveScope" OnCommand="ImgRemoveScope_Command"
                                                                                    CommandName="RemoveScope" CommandArgument='<%#Eval("SO_ID")%>' ToolTip="Delete EO Scope Option"
                                                                                    Style="cursor: pointer" runat="server">
                                                                                </dx:ASPxButton>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Delete BudgetCenter"
                                                                            VisibleIndex="3" Visible="false">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblBudgetCenter" runat="server" Text='<%# Eval("Budget_Center_Name")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblBudgetCenterID" runat="server" Text='<%# Eval("Budget_Center_ID")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Approver Name"
                                                                            VisibleIndex="4" Visible="false">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblApprovers" runat="server" Text='<%#"<b>Bounty:</b>" + Eval("Bounty_Approver_Name")+"  <b>Charmin:</b>"+ Eval("Charmin_Approver_Name")+"  <b>Puffs:</b>"+ Eval("Puffs_Approver_Name")+"  <b>Default:</b>"+ Eval("Default_Approver_Name")+"  <b>SAP Cost Center Coordinator:</b>"+Eval("SAP_CCC_Approver_Name")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <SettingsPager PageSize="10" Position="Bottom" NextPageButton-Image-ToolTip="Next"
                                                                        PrevPageButton-Image-ToolTip="Previous">
                                                                    </SettingsPager>
                                                                    <Styles>
                                                                        <Header BackColor="#FFCC00" Font-Bold="true">
                                                                        </Header>
                                                                    </Styles>
                                                                </dx:ASPxGridView>
                                                                <%--<asp:datagrid id="drgEOScope" runat="server" BorderWidth="1px" GridLines="None" HeaderStyle-CssClass="SubHeader"
																	AutoGenerateColumns="False" BorderColor="Black" PageSize="12" Width="100%" CellSpacing="2">
																	<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																	<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																	<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Scope Option">
																			<HeaderStyle HorizontalAlign="Left" Width="50%"></HeaderStyle>
																			<ItemStyle Wrap="False"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton ID="lnkScopeName" CommandName="View_Scope" CommandArgument = '<%# Eval("SO_ID")%>' Runat="server" text ='<%# Eval("Scope_Option_Name")%>' >
																				</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Delete EO Scope Option">
																			<HeaderStyle HorizontalAlign="Left" Width="25%" VerticalAlign="Top"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton Runat="server" ID="ImgRemoveScope" CommandName="RemoveScope" CommandArgument = '<%#Eval("SO_ID")%>' ImageUrl="../Images/remove-icon.gif">
																				</asp:ImageButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle HorizontalAlign="Left" Width="0%"></HeaderStyle>
																			<ItemStyle Wrap="False"></ItemStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblBudgetCenter" Runat="server" text='<%# Eval("Budget_Center_Name")%>' Visible=False>
																				</asp:Label>
																				<asp:Label ID="lblBudgetCenterID" Runat="server" text='<%# Eval("Budget_Center_ID")%>' Visible ="False">
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle HorizontalAlign="Left" Width="0%"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Justify" VerticalAlign="Top"></ItemStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblApprovers" Runat="server" text ='<%#"<b>Bounty:</b>" + Eval("Bounty_Approver_Name")+"  <b>Charmin:</b>"+Eval("Charmin_Approver_Name")+"  <b>Puffs:</b>"+Eval("Puffs_Approver_Name")+"  <b>Default:</b>"+Eval("Default_Approver_Name")+"  <b>SAP Cost Center Coordinator:</b>"+Eval("SAP_CCC_Approver_Name")%>' Visible=False>
																				</asp:Label>	
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid>--%></div>
                                                        </td>
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
                    <td>
                        <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnresponse" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
