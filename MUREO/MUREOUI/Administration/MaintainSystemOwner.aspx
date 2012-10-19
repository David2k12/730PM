<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainSystemOwner.aspx.cs"
    Inherits="MUREOUI.Administration.MaintainSystemOwner" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MaintainSystemOwner</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <script type="text/javascript" language="javascript">
        function confirmSystemOwnerDelete() {

            var msg = 'Are you sure you want to delete this System Owner?'
            if (!confirm(msg)) {
                document.getElementById('hdnResponse').value = "N"
                return false;
            }
            else {
                document.getElementById('hdnResponse').value = "Y"
                return true;
            }

        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:Header ID="Header1" runat="server"></uc1:Header>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" cellpadding="0" cellspacing="0" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr valign="middle" style="background-color: #ffffcc">
                                            <td align="center" colspan="5">
                                                <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong>&nbsp;Maintain
                                                    Site System Owners </strong></font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgAddSysOwner" runat="server" ImageUrl="../Images/Create-New-Site-System-Owne.gif"
                                                    ToolTip="Create New Site System Owner" AlternateText="Add Site System Owner."
                                                    OnClick="imgAddSysOwner_Click"></asp:ImageButton>&nbsp;
                                            </td>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" width="100%" colspan="2">
                                                    <div>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="100%" colspan="2">
                                                                    <dx:ASPxGridView ID="dtgrdPurchaseContact" OnHtmlRowPrepared="dtgrdPurchaseContact_HtmlRowPrepared"
                                                                        KeyFieldName="Sys_Owner_ID" AllowSorting="True" Border-BorderWidth="1px" Width="100%"
                                                                        runat="server" AutoGenerateColumns="False" OnPageIndexChanged="dtgrdPurchaseContact_PageIndexChanged">
                                                                        <Columns>
                                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Left" Width="20%" Caption="Plant"
                                                                                VisibleIndex="0">
                                                                                <DataItemTemplate>
                                                                                    <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                    </asp:Label>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Left" Caption="Phone Number"
                                                                                VisibleIndex="1">
                                                                                <DataItemTemplate>
                                                                                    <asp:Label ID="lblPhNumber" runat="server" Text='<%# Eval("Phone_Number")%>'>
                                                                                    </asp:Label>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Left" Caption="System Owner"
                                                                                VisibleIndex="2">
                                                                                <DataItemTemplate>
                                                                                    <asp:Label ID="lblPlantID" runat="server" Visible="false" Text='<%# Eval("Plant_ID")%>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="lblPName" runat="server" Visible="false" Text='<%# Eval("Plant_Name")%>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="lblSysOwnID" runat="server" Visible="false" Text='<%# Eval("Sys_Owner_ID")%>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="lblSysOwnerName" runat="server" Visible="false" Text='<%# Eval("System_Owner_Name")%>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="lblPhNo" Visible="false" runat="server" Text='<%# Eval("Phone_Number")%>'>
                                                                                    </asp:Label>
                                                                                    <asp:LinkButton ID="lnkSysOwnerName" runat="server" ToolTip="View System Owner" OnCommand="lnkSysOwnerName_Command"
                                                                                        CommandName="OwnerName_Link" CommandArgument='<%# Eval("Sys_Owner_ID")%>' Text='<%# Eval("System_Owner_Name")%>'>
                                                                                    </asp:LinkButton>
                                                                                    <asp:Label ID="lblOwnerName" Visible="false" runat="server" Text='<%# Eval("System_Owner_Name")%>'>
                                                                                    </asp:Label>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Center" Width="20%" Caption="Remove Site System Owner?"
                                                                                VisibleIndex="3">
                                                                                <DataItemTemplate>
                                                                                    <%--<asp:ImageButton Runat="server" ID="imgDeleteGroup" OnCommand="imgDeleteGroup_Command" CommandName="DeletePcontact" CommandArgument='<%# Eval("Sys_Owner_ID")%>' ImageUrl="../Images/remove-icon.gif" ToolTip="Remove Site System Owner?" style="cursor:pointer">
																				</asp:ImageButton>--%>
                                                                                    <dx:ASPxButton Image-Url="../Images/remove-icon.gif" ID="imgDeleteGroup" OnCommand="imgDeleteGroup_Command"
                                                                                        CommandName="DeletePcontact" CommandArgument='<%# Eval("Sys_Owner_ID")%>' ToolTip="Remove Site System Owner?"
                                                                                        Style="cursor: pointer" runat="server">
                                                                                    </dx:ASPxButton>
                                                                                </DataItemTemplate>
                                                                                <CellStyle HorizontalAlign="Center">
                                                                                </CellStyle>
                                                                            </dx:GridViewDataColumn>
                                                                        </Columns>
                                                                        <SettingsPager PageSize="10" Position="Bottom">
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
            <asp:HiddenField ID="hdnResponse" runat="server" />
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
