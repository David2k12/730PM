<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOnRouteFYI.aspx.cs"
    Inherits="MUREOUI.Administration.ViewOnRouteFYI" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="FootControl" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="HeadControl" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="NavigationControl" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewOnRouteFYI</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
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
<body>
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td class="FormHeader" valign="top">
                                                Maintain On Route FYI Recipients
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgCreateNewFYI" runat="server" AlternateText="Click to create a new FYI"
                                                    ImageUrl="../Images/create-new-fyi-list.gif" OnClick="imgCreateNewFYI_Click">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgExpandAll" runat="server" ImageUrl="../Images/expandall.gif"
                                                    OnClick="imgExpandAll_Click"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCollapseAll" runat="server" AlternateText="Collapse All"
                                                    ImageUrl="../Images/collpaseall.gif" OnClick="imgCollapseAll_Click"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="center" width="100%">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <dx:ASPxGridView ID="dgdOnRouteFYI" KeyFieldName="FYI_Recipient_ID" Width="100%"
                                                                runat="server" AllowSorting="True" AutoGenerateColumns="False" OnHtmlRowPrepared="dgdOnRouteFYI_HtmlRowPrepared"
                                                                OnPageIndexChanged="dgdOnRouteFYI_PageIndexChanged">
                                                                <Columns>
                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Region"
                                                                        VisibleIndex="0">
                                                                        <DataItemTemplate>
                                                                            <asp:ImageButton runat="server" ID="imgRegion1" OnCommand="imgRegion1_Command" CommandName="Region1"
                                                                                ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                            <asp:ImageButton runat="server" ID="imgRegion2" OnCommand="imgRegion2_Command" CommandName="Region2"
                                                                                ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                            <asp:Label ID="lblRegionId" runat="server" Visible="False" Text='<%# Eval("Region_ID")%>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="lblRegionName" runat="server" Text='<%# Eval("Region_Name")%>'>
                                                                            </asp:Label>
                                                                        </DataItemTemplate>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant"
                                                                        VisibleIndex="1">
                                                                        <DataItemTemplate>
                                                                            <asp:ImageButton runat="server" ID="imgplant1" OnCommand="imgplant1_Command" ImageUrl="../Images/arrow1.gif">
                                                                            </asp:ImageButton>
                                                                            <asp:ImageButton runat="server" ID="imgplant2" OnCommand="imgplant2_Command" ImageUrl="../Images/arrow_down1.gif">
                                                                            </asp:ImageButton>
                                                                            <asp:Label ID="lblPlantId" runat="server" Visible="False" Text='<%# Eval("Plant_ID")%>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                            </asp:Label>
                                                                        </DataItemTemplate>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Category"
                                                                        VisibleIndex="2">
                                                                        <DataItemTemplate>
                                                                            <asp:Label ID="lblCategoryId" runat="server" Visible="False" Text='<%# Eval("Category_ID")%>'>
                                                                            </asp:Label>
                                                                            <asp:LinkButton ID="lnkCategoryName" OnCommand="lnkCategoryName_Command" ToolTip="View Category"
                                                                                CommandName="Category_Link" CommandArgument='<%# Eval("FYI_Recipient_ID")%>' runat="server"
                                                                                Text='<%# Eval("Category_Name")%>'>
                                                                            </asp:LinkButton>
                                                                        </DataItemTemplate>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn Caption="FYI Recipients" VisibleIndex="3">
                                                                        <DataItemTemplate>
                                                                            <asp:Label ID="lblRecipientName" runat="server" Text='<%# Eval("Approver_Name")%>'>
                                                                            </asp:Label>
                                                                        </DataItemTemplate>
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </dx:GridViewDataColumn>
                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Left" Caption="RecipientID"
                                                                        Visible="false" VisibleIndex="4">
                                                                        <DataItemTemplate>
                                                                            <asp:Label ID="lblRecipientID" runat="server" Text='<%# Eval("FYI_Recipient_ID")%>'>
                                                                            </asp:Label>
                                                                        </DataItemTemplate>
                                                                    </dx:GridViewDataColumn>
                                                                </Columns>
                                                                <SettingsPager Mode="ShowAllRecords">
                                                                </SettingsPager>
                                                                <Settings GridLines="None" />
                                                                <Styles>
                                                                    <Header CssClass="SubHeader" BackColor="#FFCC00" Font-Bold="true">
                                                                    </Header>
                                                                    <AlternatingRow CssClass="AlternateRow2">
                                                                    </AlternatingRow>
                                                                </Styles>
                                                            </dx:ASPxGridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
