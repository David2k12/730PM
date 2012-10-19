<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEOScopeBudget.aspx.cs"
    Inherits="MUREOUI.Administration.ViewEOScopeBudget" %>

<%--<%@Register tagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx"%>--%>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>View Suggested Budget Center</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function confirmApproverDelete(Approver_Name, Approver_Depend) {
            if (Approver_Depend == 'True') {
                if (confirm('This approver is assigned to an existing approver group slate(s)\n Are you sure you want to delete this approver ' + '\'' + Approver_Name + '\' ?'))
                    document.getElementById("<%=hdnresponse.ClientID %>").value = "Y"
                else
                    document.getElementById("<%=hdnresponse.ClientID %>").value = "N"
            }
            else {
                var msg = 'Are you sure you want to delete this Approver ' + '\'' + Approver_Name + '\' ?'
                if (!confirm(msg))
                    document.getElementById("<%=hdnresponse.ClientID %>").value = "N"
                else
                    document.getElementById("<%=hdnresponse.ClientID %>").value = "Y"
            }
        }
    </script>
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
        .viscol
        {
            display: block;
        }
        .popupControl
        {
            position: absolute;
            top: 300px;
            left: 500px;
            width: 100%;
            height: 100%;         
            opacity: 0.9;
            z-index: 499;
        }
    </style>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td>
                            <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="left" width="20%">
                                            <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                            </uc1:LeftNavigationControlForAdmin>
                                        </td>
                                        <td valign="top" align="center" width="80%">
                                            <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td valign="middle" align="center">
                                                        <!--	<table id="tbl3" cellpadding="0" cellspacing="0" width="90%" style="BORDER-RIGHT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-BOTTOM: #898989 1px solid">
												<tr>
													<td colspan="6" bgcolor="#f8f8f8" align="center">-->
                                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                            <tr valign="middle" bgcolor="#ffffcc">
                                                                <td style="height: 27px" align="center">
                                                                    <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                                    </font>
                                                                    <div>
                                                                        <strong class="FormHeader">Maintain Suggested Budget Center</strong></div>
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
                                                                            ImageUrl="../Images/Create-Suggested-Budget-Center.gif"></asp:ImageButton>&nbsp;&nbsp;
                                                                        <asp:ImageButton ID="imgExpand" OnClick="imgExpand_Click" runat="server" ImageUrl="../Images/expandall.gif">
                                                                        </asp:ImageButton>&nbsp;&nbsp;
                                                                        <asp:ImageButton ID="imgCollapse" OnClick="imgCollapse_Click" runat="server" ImageUrl="../Images/collpaseall.gif">
                                                                        </asp:ImageButton></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <div style="overflow: auto; height: 330px">
                                                                        <%-- <asp:datagrid id="drgdEOScopeBudget" runat="server" PageSize="12" BorderColor="Black" AutoGenerateColumns="False"
																			HeaderStyle-CssClass="SubHeader" Width="100%" GridLines="None" BorderWidth="1px" CellSpacing="2">
																			<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																			<ItemStyle CssClass="AlterNateRow1"></ItemStyle>
																			<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="EO Scope Name">
																					<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																					<ItemStyle Wrap="False"></ItemStyle>
																					<ItemTemplate>
																						<asp:ImageButton Runat="server" ID="imgFunction1" CommandName="Function1" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																						<asp:ImageButton Runat="server" ID="imgFunction2" CommandName="Function2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																						<asp:Label ID="lblEOScopeID" Runat="server" Visible=False text='<%# Eval("SO_ID")%>'>
																						</asp:Label>
																						<asp:Label ID="lblEOScopeName" Runat="server" text='<%# Eval("Scope_Option_Name")%>'>
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Plant">
																					<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																					<ItemStyle Wrap="False"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label ID="lblScopeID" Visible=False Runat="server" text='<%# Eval("SO_ID")%>'>
																						</asp:Label>
																						<asp:Label ID="lblPlantID" Runat="server" Visible=False text='<%# Eval("Plant_ID")%>'>
																						</asp:Label>
																						<asp:Label ID = "lblBudgetID" Runat="server" text = '<%# Eval("Budget_Center_ID")%>' Runat="server" Visible=False>
																						</asp:Label>
																						<asp:LinkButton ID="lnkPlantName" CommandName="View_Plant" CommandArgument = '<%# Eval("Plant_Name")%>' Runat="server" text ='<%# Eval("Plant_Name")%>' >
																						</asp:LinkButton>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Suggested Budget center name">
																					<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																					<ItemStyle Wrap="False"></ItemStyle>
																					<ItemTemplate>
																						<asp:Label ID = "lblBudgetName" Runat="server" text = '<%# Eval("Budget_Center_Name")%>' Visible =True >
																						</asp:Label>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid>--%>
                                                                        <dx:ASPxGridView ID="drgdEOScopeBudget" OnHtmlRowPrepared="drgdEOScopeBudget_HtmlRowPrepared"
                                                                            KeyFieldName="Budget_Center_ID" Width="100%" runat="server" OnPageIndexChanged="drgdEOScopeBudget_PageIndexChanged"
                                                                            AutoGenerateColumns="False">
                                                                            <%--OnHtmlRowPrepared="drgdAppGrp_HtmlRowPrepared" OnPageIndexChanged="drgdAppGrp_PageIndexChanged"--%>
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" EditCellStyle-HorizontalAlign="Justify"
                                                                                    Width="20%" Caption="EO Scope Name" VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgFunction1" OnCommand="imgFunction1_Command"
                                                                                            CommandName="Function1" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgFunction2" OnCommand="imgFunction2_Command"
                                                                                            CommandName="Function2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblEOScopeID" runat="server" Visible="False" Text='<%# Eval("SO_ID")%>'>
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblEOScopeName" runat="server" Text='<%# Eval("Scope_Option_Name")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" EditCellStyle-HorizontalAlign="Justify"
                                                                                    Width="20%" Caption="Plant" VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblScopeID" Visible="false" runat="server" Text='<%# Eval("SO_ID")%>'>
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblPlantID" runat="server" Visible="False" Text='<%# Eval("Plant_ID")%>'>
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblBudgetID" runat="server" Text='<%# Eval("Budget_Center_ID")%>'
                                                                                            runat="server" Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkPlantName" OnCommand="lnkPlantName_Command" ScopeName='<%# Eval("Scope_Option_Name")%>'
                                                                                            BudgetName='<%# Eval("Budget_Center_Name")%>' PlantID='<%# Eval("Plant_ID")%>'
                                                                                            BudgetID='<%# Eval("Budget_Center_ID")%>' ScopeID='<%# Eval("SO_ID")%>' CommandName="View_Plant"
                                                                                            CommandArgument='<%# Eval("Plant_Name")%>' runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" EditCellStyle-HorizontalAlign="Justify"
                                                                                    Width="20%" Caption="Suggested Budget center name" VisibleIndex="3">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblBudgetName" runat="server" Text='<%# Eval("Budget_Center_Name")%>'
                                                                                            Visible="True">
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager Mode="ShowAllRecords">
                                                                            </SettingsPager>
                                                                            <Settings GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%--<input id="response" type="hidden" name="response">--%>
            <asp:HiddenField ID="hdnresponse" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
           <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
    <%--    </TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>--%>
</body>
</html>
