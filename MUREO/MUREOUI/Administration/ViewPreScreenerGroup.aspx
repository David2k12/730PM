<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPreScreenerGroup.aspx.cs"
    Inherits="MUREOUI.Administration.ViewPreScreenerGroup" %>

<%@ Register TagPrefix="NavigationControl" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="HeadControl" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="FootControl" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewPreScreenerGroup</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <script type="text/javascript" language="javascript">
        function confirmDelete() {
            if (!confirm('Are you sure u want to delete this Prescreener Group?')) {
                document.getElementById("<%= hdnResponse.ClientID %>").value = "N"
                return false;
            }
            else {
                document.getElementById("<%= hdnResponse.ClientID %>").value = "Y"
                return true;
            }
        }
    </script>
    <table id="mainTable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <HeadControl:HeaderControl ID="HeaderControl" runat="server"></HeadControl:HeaderControl>
            </td>
        </tr>
        <tr>
            <td>
                <table id="innerTable1" cellspacing="0" cellpadding="0" width="100%" border="1">
                    <tr>
                        <td valign="top" width="20%">
                            <NavigationControl:LeftNavigationControl ID="LeftNavigationControl" runat="server">
                            </NavigationControl:LeftNavigationControl>
                        </td>
                        <td valign="top" width="80%">
                            <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
                                <tr valign="top" style="background-color: #ffffcc">
                                    <td class="FormHeader" valign="top">
                                        Maintain PreScreeners
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ImageButton ID="btnCreateNewPrescreen" runat="server" ImageUrl="../Images/create-new-prescreener.jpg"
                                            ToolTip="Create New Prescreener" AlternateText="Click to create a new prescreener"
                                            OnClick="btnCreateNewPrescreen_Click"></asp:ImageButton>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <table width="100%">
                                            <tr>
                                                <td width="100%" align="left">
                                                    <dx:ASPxGridView ID="dgdPreScreener" OnHtmlRowPrepared="dgdPreScreener_HtmlRowPrepared"
                                                        KeyFieldName="PreScreener_Group_ID" Width="100%" runat="server" AutoGenerateColumns="False"
                                                        OnPageIndexChanged="dgdPreScreener_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataColumn FieldName="PreScreener_Group_Name" Caption="Prescreener Group Name"
                                                                Width="30%" EditCellStyle-HorizontalAlign="Left" VisibleIndex="1">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="25%" Caption="Prescreener"
                                                                VisibleIndex="2">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton ID="hylPrescreeners" CommandName="Screener_Link" CommandArgument='<%# Eval("PreScreener_Group_ID") %>'
                                                                        runat="server" OnCommand="hylPrescreeners_Command" Text='<%# Eval("Primary_Approver_Name")%>'>
                                                                    </asp:LinkButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Backup_Approver_Name" Caption="Prescreener Backup"
                                                                Width="25%" VisibleIndex="3">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Center" Width="20%" Caption="Delete Group"
                                                                VisibleIndex="4">
                                                                <DataItemTemplate>
                                                                    <asp:ImageButton ID="imgbDelete" ToolTip="Delete Group" Style="cursor: pointer" CommandArgument='<%# Eval("PreScreener_Group_ID") %>'
                                                                        runat="server" OnCommand="imgbDelete_Command" CommandName="Delete" ImageUrl="../Images/remove-icon.gif">
                                                                    </asp:ImageButton>
                                                                </DataItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
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
                                    </td>
                                </tr>
                                <asp:HiddenField ID="hdnResponse" runat="server" />
                            </table>
                            <tr>
                                <td>
                                </td>
                            </tr>
                </table>
                <FootControl:FooterControl ID="FooterControl" runat="server"></FootControl:FooterControl>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
