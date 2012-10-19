<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewApprovalGroup.aspx.cs"
    Inherits="MUREOUI.Administration.ViewApprovalGroup" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/LeftNavigationControlForAdmin.ascx" TagName="LeftNavigationControlForAdmin"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc3" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>View Approval Group</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td>
                            <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="left" width="20%">
                                            <uc2:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server" />
                                        </td>
                                        <td valign="top" align="center" width="80%">
                                            <table id="tbl5" cellspacing="0" cellpadding="0" width="100%">
                                                <tr style="height: 5">
                                                    <td align="center">
                                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                            <tr valign="middle" bgcolor="#ffffcc">
                                                                <td align="center" colspan="5">
                                                                    <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                                    </font>
                                                                    <div>
                                                                        <strong><font face="Arial" color="#0000ff" size="4" class="FormHeader">Maintain Authorized&nbsp;Approval
                                                                            Slates</font></strong></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:ImageButton ID="imgCreateAppGrp" OnClick="imgCreateAppGrp_Click" runat="server"
                                                                        ImageUrl="../Images/create-approval-group.gif" ToolTip="Create Approval Group">
                                                                    </asp:ImageButton>&nbsp;&nbsp;
                                                                    <asp:ImageButton ID="imgSearchAppr" OnClick="imgSearchAppr_Click" runat="server"
                                                                        ImageUrl="../Images/Search-Approvers.gif" ToolTip="Search Approvers"></asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <div style="overflow: auto; width: 780px; height: 400px">
                                                                        <dx:ASPxGridView ID="drgAppGrp" KeyFieldName="Approval_Group_ID" OnHtmlRowPrepared="drgAppGrp_HtmlRowPrepared"
                                                                            OnPageIndexChanged="drgAppGrp_PageIndexChanged" runat="server" AutoGenerateColumns="False"
                                                                            Width="100%">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" CellStyle-HorizontalAlign="Left"
                                                                                    Width="5%" FieldName="Approval_Group_ID" Caption="AppGrpID" Visible="false" VisibleIndex="1" />
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" EditCellStyle-HorizontalAlign="Justify"
                                                                                    Width="30%" Caption="Approval Group" VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:LinkButton ID="lnkAppGroupName" CommandName='<%# Eval("Approval_Group_ID")%>'
                                                                                            OnCommand="lnkAppGroupName_Command" runat="server" Text='<%# Eval("Approval_Group_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" CellStyle-HorizontalAlign="center"
                                                                                    Width="5%" Caption="Delete Group" VisibleIndex="3">
                                                                                    <DataItemTemplate>
                                                                                      <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                            <ContentTemplate>--%>
                                                                                               <%-- <asp:ImageButton runat="server" ID="imgDeleteGroup" Style="cursor: pointer" OnCommand="imgDeleteGroup_Command"
                                                                                                    ToolTip="Delete Group" CommandName='<%# Eval("Approval_Group_ID")%>' ImageUrl="../Images/remove-icon.gif">
                                                                                                </asp:ImageButton>--%>
                                                                                                <dx:ASPxButton Image-Url="../Images/remove-icon.gif" ID="imgDeleteGroup" OnCommand="imgDeleteGroup_Command"
                                                                                                    CommandName='<%# Eval("Approval_Group_ID")%>' ToolTip="Delete Group" 
                                                                                                    Style="cursor: pointer" runat="server">
                                                                                                </dx:ASPxButton>
                                                                                            <%--</ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="imgDeleteGroup" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>--%>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" CellStyle-HorizontalAlign="Left"
                                                                                    Width="60%" Caption="Approvers" VisibleIndex="4">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblApprovers" runat="server" Text='<%# Eval("Names")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="10" NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous">
                                                                            </SettingsPager>
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true" HorizontalAlign="Center">
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
                            <uc3:FooterControl ID="FooterControl1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>         
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
