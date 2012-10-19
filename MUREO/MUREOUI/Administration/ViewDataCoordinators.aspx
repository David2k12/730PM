<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDataCoordinators.aspx.cs"
    Inherits="MUREOUI.Administration.ViewDataCoordinators" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ViewDataCoordinators</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function confirmCODelete(CO_Name) {
            var msg = 'Are you sure you want to delete this data coordinator ' + '\'' + CO_Name + '\' ?'
            if (!confirm(msg)) {
                document.getElementById("<%=hdnResponse.ClientID %>").value = "N"
                return false;
            }
            else {
                document.getElementById("<%=hdnResponse.ClientID %>").value = "Y"
                return true;
            }

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
                                                                            <strong><font face="Arial" color="#0000ff" size="4" class="FormHeader">Maintain Data
                                                                                Coordinators</font></strong></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:ImageButton ID="imgCreateBdgtCtr" runat="server" ToolTip="Create Data Coordinator"
                                                                            ImageUrl="../Images/create-data-coordinator.gif" OnClick="imgCreateBdgtCtr_Click">
                                                                        </asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <div style="overflow: auto; height: 500px">
                                                                            <dx:ASPxGridView ID="drgCo" runat="server" KeyFieldName="DO_ID" Width="100%" Styles-Header-CssClass="SubHeader"
                                                                                AllowSorting="True" AutoGenerateColumns="False" Border-BorderColor="Black" CellSpacing="2"
                                                                                OnHtmlRowPrepared="drgCo_HtmlRowPrepared" OnPageIndexChanged="drgCo_PageIndexChanged">
                                                                                <Columns>
                                                                                    <dx:GridViewDataColumn Visible="False" FieldName="DO_ID" Caption="CoordinatorID" />
                                                                                    <dx:GridViewDataColumn Caption="Category" Width="40%">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblCategory" Text='<%# Eval("Category_Name")%>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn Caption="Data Coordinator" Width="40%">
                                                                                        <DataItemTemplate>
                                                                                            <asp:LinkButton ID="lnkCOName" OnCommand="lnkCOName_Command" CommandName="View_CO"
                                                                                                ToolTip="View Data Coordinator" CommandArgument='<%# Eval("DO_ID")%>' runat="server"
                                                                                                Text='<%# Eval("Data_Coordinator_Name")%>'>
                                                                                            </asp:LinkButton>
                                                                                        </DataItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <CellStyle Wrap="False">
                                                                                        </CellStyle>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn Caption="Phone Number" Width="30%">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblPhone" Text='<%# Eval("Phone_Number")%>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                        <CellStyle Wrap="False">
                                                                                        </CellStyle>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn Caption="Delete Data Coordinator" Width="30%">
                                                                                        <DataItemTemplate>
                                                                                            <%--  <asp:ImageButton ID="ImgDeleteCo" OnCommand="ImgDeleteCo_Command" CommandName="DeleteCo"
                                                                                        CommandArgument='<%# Eval("DO_ID")%>' ToolTip="Delete Data Coordinator" Style="cursor: pointer"
                                                                                        runat="server" ImageUrl="../Images/remove-icon.gif"></asp:ImageButton>--%>
                                                                                            <dx:ASPxButton Image-Url="../Images/remove-icon.gif" ID="ImgDeleteCo" OnCommand="ImgDeleteCo_Command"
                                                                                                CommandName="DeleteCo" CommandArgument='<%# Eval("DO_ID")%>' ToolTip="Delete Data Coordinator"
                                                                                                Style="cursor: pointer" runat="server">
                                                                                            </dx:ASPxButton>
                                                                                        </DataItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        <CellStyle HorizontalAlign="Center" Wrap="False">
                                                                                        </CellStyle>
                                                                                    </dx:GridViewDataColumn>
                                                                                </Columns>
                                                                                <Styles>
                                                                                    <Header BackColor="#FFCC00" HorizontalAlign="Left" Font-Bold="True">
                                                                                    </Header>
                                                                                    <Cell HorizontalAlign="Left">
                                                                                    </Cell>
                                                                                </Styles>
                                                                                <Border BorderColor="Black"></Border>
                                                                            </dx:ASPxGridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <asp:HiddenField ID="hdnResponse" runat="server" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<input id="response" type="hidden" name="response" />--%>
    </form>
</body>
</html>
