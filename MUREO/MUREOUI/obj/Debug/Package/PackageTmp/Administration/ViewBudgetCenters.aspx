<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBudgetCenters.aspx.cs"
    Inherits="MUREOUI.Administration.ViewBudgetCenters" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>ViewBudgetCenters</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function confirmBudgetCenterDelete(Budget_Center_Name, Scope_Depend) {

            if (Scope_Depend == 'True') {
                if (confirm('There is already a scope option defined for this budget center\n Are you sure you want to delete this budget center ' + '\'' + Budget_Center_Name + '\' ?')) {
                    document.getElementById("<%= hdnResponse.ClientID %>").value = "Y"
                    return true;
                }
                else {
                    document.getElementById("<%= hdnResponse.ClientID %>").value = "N"
                    return false;
                }
            }
            else {               
                var msg = 'Are you sure you want to delete this Budget Center ' + '\'' + Budget_Center_Name + '\' ?'
                if (!confirm(msg)) {
                    document.getElementById("<%= hdnResponse.ClientID %>").value = "N"
                    return false;
                }
                else {
                    document.getElementById("<%= hdnResponse.ClientID %>").value = "Y"
                    return true;
                }
            }

            /*  var msg = 'Are you sure you want to delete this Budget Center '+'\''+ Budget_Center_Name + '\' ?'
            if (!confirm(msg)) 
            document.getElementById("Response").value= "N"
            else 		  
            document.getElementById("Response").value= "Y"*/


        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
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
                                            <td align="center">
                                                <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr height="5">
                                                        <td colspan="5">
                                                            <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                                <tr valign="middle" bgcolor="#ffffcc">
                                                                    <td align="center" colspan="5">
                                                                        <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                                        </font>
                                                                        <div>
                                                                            <strong><font class="FormHeader" face="Arial" color="#0000ff" size="4">Maintain Budget
                                                                                Centers</font></strong></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:ImageButton ID="imgCreateBdgtCtr" OnClick="imgCreateBdgtCtr_Click" runat="server"
                                                                            ImageUrl="../Images/create-budget-center.gif" ToolTip="Create Budget Center"
                                                                            AlternateText="Create Budget Center"></asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <br>
                                                                        <div style="overflow: auto; width: 780px; height: 400px">
                                                                            <%--<asp:datagrid id="drgBudget" runat="server" CellSpacing="2" BorderColor="Black" BorderWidth="1px"
																				GridLines="None" Width="100%" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False">
																				<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																				<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																				<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																				<Columns>
																					<asp:BoundColumn Visible="False" DataField="Budget_Center_ID" HeaderText="BudgetCenterID"></asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="Budget Center">
																						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																						<ItemTemplate>
																							<asp:linkbutton ID="lblBdgtCtrName" Runat="server" CommandName ="View_BudgetCenter" CommandArgument = '<%# DataBinder.Eval(Container.Dataitem,"Budget_Center_ID")%>' text='<%# DataBinder.Eval(Container.Dataitem,"Budget_Center_Name")%>'>
																							</asp:linkbutton>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="Plant">
																						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
																						<ItemTemplate>
																							<asp:Label ID="lblPlant" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"Plant_Name")%>'>
																							</asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="DeleteBudgetCenter">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																						<ItemTemplate>
																							<asp:ImageButton ID="ImgDeleteBudgetCenter" Runat="server" CommandName="DeleteBudgetCenter" CommandArgument = '<%# DataBinder.Eval(Container.Dataitem,"Budget_Center_ID") %>' ImageUrl="../Images/remove-icon.gif" >
																							</asp:ImageButton>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="Approvers">
																						<HeaderStyle HorizontalAlign="Left" Width="50%"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle"></ItemStyle>
																						<ItemTemplate>
																							<asp:Label ID="lblApproverName" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"Approvers")%>'>
																							</asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																			</asp:datagrid>--%>
                                                                            <dx:ASPxGridView ID="drgBudget" OnHtmlRowPrepared="drgBudget_HtmlRowPrepared" KeyFieldName="Budget_Center_ID"
                                                                                Width="100%" runat="server" AutoGenerateColumns="False" OnPageIndexChanged="drgBudget_PageIndexChanged">
                                                                                <Columns>
                                                                                    <dx:GridViewDataColumn FieldName="Budget_Center_ID" Visible="false" Caption="BudgetCenterID"
                                                                                        VisibleIndex="1" />
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Budget Center"
                                                                                        VisibleIndex="2">
                                                                                        <DataItemTemplate>
                                                                                            <asp:LinkButton ID="lblBdgtCtrName" runat="server" BudgetCenterID='<%# Eval("Budget_Center_ID") %>'
                                                                                                ToolTip="View Budget Center" OnCommand="lblBdgtCtrName_Command" CommandName="View_BudgetCenter"
                                                                                                CommandArgument='<%# Eval("Budget_Center_ID")%>' Text='<%# Eval("Budget_Center_Name")%>'>
                                                                                            </asp:LinkButton>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Plant"
                                                                                        VisibleIndex="3">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblPlant" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Delete Budget Center"
                                                                                        VisibleIndex="4">
                                                                                        <DataItemTemplate>
                                                                                            <%--<asp:ImageButton ID="ImgDeleteBudgetCenter" style="cursor:pointer" runat="server" OnCommand="ImgDeleteBudgetCenter_Command" ToolTip="Delete Budget Center"
                                                                                                CommandName="DeleteBudgetCenter" CommandArgument='<%# Eval("Budget_Center_ID") %>'
                                                                                                ImageUrl="../Images/remove-icon.gif"></asp:ImageButton>--%>
                                                                                            <dx:ASPxButton Image-Url="../Images/remove-icon.gif" ID="ImgDeleteBudgetCenter" OnCommand="ImgDeleteBudgetCenter_Command"
                                                                                                CommandName="DeleteBudgetCenter" CommandArgument='<%# Eval("Budget_Center_ID") %>'
                                                                                                ToolTip="Delete Budget Center" Style="cursor: pointer" runat="server">
                                                                                            </dx:ASPxButton>
                                                                                        </DataItemTemplate>
                                                                                        <CellStyle HorizontalAlign="Center">
                                                                                        </CellStyle>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Approvers"
                                                                                        VisibleIndex="4">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblApproverName" runat="server" Text='<%# Eval("Approvers")%>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                        <CellStyle HorizontalAlign="Left">
                                                                                        </CellStyle>
                                                                                    </dx:GridViewDataColumn>
                                                                                </Columns>
                                                                                <SettingsPager PageSize="20" Position="Bottom">
                                                                                </SettingsPager>
                                                                                <Styles>
                                                                                    <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                    </Header>
                                                                                    <AlternatingRow CssClass="AlternateRow2">
                                                                                    </AlternatingRow>
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
            <asp:HiddenField ID="hdnResponse" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
