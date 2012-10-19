<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainConcurrenceGroup.aspx.cs"
    Inherits="MUREOUI.Administration.MaintainConcurrenceGroup" %>

<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>MaintainConcurrenceGroup</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function confirmPurchasingContactDelete(Contact) {

            var msg = 'Are you sure you want to delete this Concurrence Group ' + '\'' + Contact + '\' ?'
            if (!confirm(msg)) {
                document.getElementById("<%=hdnresponse.ClientID %>").value = "N"
                return false;
            }
            else
                document.getElementById("<%=hdnresponse.ClientID %>").value = "Y"
        }
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

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
<body  ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="scp1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upbudget" runat="server">
        <ContentTemplate>
            <table id="maintbl" height="100%" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:Header ID="Header1" runat="server"></uc1:Header>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td valign="top" width="20%" height="100%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" height="100%" cellspacing="0" cellpadding="0" align="center">
                                        <tr class="FormHeader">
                                            <td>
                                                Maintain Concurrence Groups
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgAddConcuGrp" OnClick="imgAddConcuGrp_Click" runat="server"
                                                    AlternateText="Add Concurrence Group." ToolTip="Create Concurrence Group" ImageUrl="../Images/create-concurrence-group.gif">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgExpnadAll" OnClick="imgExpnadAll_Click" runat="server" ImageUrl="../Images/expandall.gif"
                                                    ToolTip="Expand All"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCollapseAll" OnClick="imgCollapseAll_Click" runat="server"
                                                    ImageUrl="../Images/collpaseall.gif" ToolTip="Collapse All"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="710px" align="left">
                                                <div id="divTest" style="overflow: auto; width: 710px; height: 600px">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <%--  <asp:DataGrid ID="dtgrdConcurrenceGroup" runat="server" BorderColor="Black" AutoGenerateColumns="False"
                                                            HeaderStyle-CssClass="SubHeader" Width="100%" GridLines="None" BorderWidth="1px"
                                                            Height="100%" CellSpacing="2">
                                                            <AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
                                                            <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                                            <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="Plant ">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="imgPlant1" CommandName="Plant1" ImageUrl="../Images/arrow1.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:ImageButton runat="server" ID="imgPlant2" CommandName="Plant2" ImageUrl="../Images/arrow_down1.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Concurrence Group">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlantID" runat="server" Visible="False" Text='<%# Eval("Plant_ID")%>'>
                                                                        </asp:Label>
                                                                        <asp:Label ID="lblPName" runat="server" Visible="False" Text='<%# Eval("Plant_Name")%>'>
                                                                        </asp:Label>
                                                                        <asp:LinkButton ID="lnkconGrpName" CommandName="ConGrpName_Link" runat="server">
																					<%# Eval("Concurrence_Group_Name")%>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblconGrpName" Visible="False" runat="server" Text='<%#Eval("Concurrence_Group_Name")%>'>
                                                                        </asp:Label>
                                                                        <asp:Label ID="lblconGrpID" runat="server" Visible="False" Text='<%#Eval("Concurrence_Group_ID")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Concurrence List">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApproverName" runat="server" Text='<%# Eval("Approver_Name")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Delete Group?">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="ImgRemoveApprover" CommandName="RemoveApprover"
                                                                            CommandArgument='<%# Eval("Concurrence_Group_ID")%>'
                                                                            ImageUrl="../Images/remove-icon.gif"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>--%>
                                                                <dx:ASPxGridView ID="dtgrdConcurrenceGroup" KeyFieldName="Concurrence_Group_ID" Width="700px"
                                                                    runat="server" AutoGenerateColumns="False" OnHtmlRowPrepared="dtgrdConcurrenceGroup_HtmlRowPrepared"
                                                                    OnPageIndexChanged="dtgrdConcurrenceGroup_PageIndexChanged">
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant"
                                                                            VisibleIndex="1">
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgPlant1" OnCommand="imgPlant1_Command" CommandName="Plant1"
                                                                                    ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="imgPlant2" OnCommand="imgPlant2_Command" CommandName="Plant2"
                                                                                    ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'> </asp:Label>&nbsp;
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="40%" Caption="Concurrence Group"
                                                                            VisibleIndex="2">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblPlantID" runat="server" Visible="False" Text='<%# Eval("Plant_ID")%>'> </asp:Label>
                                                                                <asp:Label ID="lblPName" runat="server" Visible="False" Text='<%# Eval("Plant_Name")%>'> </asp:Label>
                                                                                <asp:LinkButton ID="lnkconGrpName" OnCommand="lnkconGrpName_Command" ToolTip="View Concurrence Group"
                                                                                    Text='<%# Eval("Concurrence_Group_Name")%>' Concurrence_Group_Name='<%#Eval("Concurrence_Group_Name")%>'
                                                                                    Plant_Name='<%# Eval("Plant_Name")%>' Plant_ID='<%# Eval("Plant_ID")%>' CommandArgument='<%# Eval("Approver_Name")%>'
                                                                                    CommandName='<%#Eval("Concurrence_Group_ID")%>' runat="server"> <%# Eval("Concurrence_Group_Name")%></asp:LinkButton>
                                                                                <asp:Label ID="lblconGrpName" Visible="False" runat="server" Text='<%#Eval("Concurrence_Group_Name")%>'> </asp:Label>
                                                                                <asp:Label ID="lblconGrpID" runat="server" Visible="False" Text='<%#Eval("Concurrence_Group_ID")%>'> </asp:Label>&nbsp;
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Concurrence List"
                                                                            VisibleIndex="3">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblApproverName" runat="server" Text='<%# Eval("Approver_Name")%>'> </asp:Label>&nbsp;
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Delete Group?"
                                                                            VisibleIndex="4">
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" Style="cursor: pointer" ID="ImgRemoveApprover" OnCommand="ImgRemoveApprover_Command"
                                                                                    CommandName='<%# Eval("Concurrence_Group_ID")%>' ToolTip="Delete Group" CommandArgument='<%# Eval("Concurrence_Group_ID")%>'
                                                                                    ImageUrl="../Images/remove-icon.gif"></asp:ImageButton>&nbsp;
                                                                            </DataItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <CellStyle HorizontalAlign="Center">
                                                                            </CellStyle>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <SettingsPager Mode="ShowAllRecords">
                                                                    </SettingsPager>
                                                                    <Settings GridLines="None" />
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
            <input type="hidden" runat="server" id="hdnresponse" name="response">
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="upbudget">
        <ProgressTemplate>
          <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
