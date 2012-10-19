<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewApprovers.aspx.cs"
    Inherits="MUREOUI.Administration.WebForm2" %>

<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>View Approvers</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function confirmApproverDelete(Approver_Name, Approver_Depend) {
            if (Approver_Depend == 'True') {
                if (confirm('This approver is assigned to an existing approver group slate(s)\n Are you sure you want to delete this approver ' + '\'' + Approver_Name + '\' ?')) {
                    document.getElementById("<%=hdnresponse.ClientID%>").value = "Y"
                    return true;
                }
                else {
                    document.getElementById("<%=hdnresponse.ClientID%>").value = "N"
                    return false;
                }
            }
            else {
                var msg = 'Are you sure you want to delete this Approver ' + '\'' + Approver_Name + '\' ?'
                if (!confirm(msg)) {
                    document.getElementById("<%=hdnresponse.ClientID%>").value = "N"
                    return false;
                }
                else {
                    document.getElementById("<%=hdnresponse.ClientID%>").value = "Y"
                    return true;
                }
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
                                                                <td align="center" style="height: 27px">
                                                                    <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                                    </font>
                                                                    <div>
                                                                        <strong class="FormHeader">Maintain Authorized Approvers</strong></div>
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
                                                                            ToolTip="Create Approver" ImageUrl="../Images/create-approver.gif"></asp:ImageButton>&nbsp;&nbsp;
                                                                        <asp:ImageButton ID="imgExpand" OnClick="imgExpand_Click" runat="server" ImageUrl="../Images/expandall.gif"
                                                                            ToolTip="Expand All"></asp:ImageButton>&nbsp;&nbsp;
                                                                        <asp:ImageButton ID="imgCollapse" OnClick="imgCollapse_Click" runat="server" ImageUrl="../Images/collpaseall.gif"
                                                                            ToolTip="Collapse All"></asp:ImageButton></p>
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
                                                                        <%-- <dx:ASPxGridView ID="drgdAppGrp" KeyFieldName="Approver_ID" Width="100%" runat="server"
                                                                            AutoGenerateColumns="False" OnHtmlRowPrepared="drgdAppGrp_HtmlRowPrepared" OnPageIndexChanged="drgdAppGrp_PageIndexChanged">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Function Name"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgFunction1" CommandName='<%# Eval("Function_ID")%>'
                                                                                            OnCommand="imgFunction1_Command" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgFunction2" OnCommand="imgFunction2_Command"
                                                                                            CommandName="Function2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblFunctionID" runat="server" Text='<%# Eval("Function_ID")%>'> </asp:Label>
                                                                                        <asp:Label ID="lblFunctionName" runat="server" Text='<%# Eval("Function_Name")%>'> </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Approver Name"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblFunctID" runat="server" Text='<%# Eval("Function_ID")%>' Visible="False"> </asp:Label>
                                                                                        <asp:Label ID="lblApprvrID" runat="server" Text='<%# Eval("Approver_ID")%>' Visible="False"> </asp:Label>
                                                                                        <asp:Label ID="lblPlantID" runat="server" Text='<%# Eval("Plant_ID")%>' Visible="False"> </asp:Label>
                                                                                        <asp:LinkButton ID="lnkApproverName" ToolTip="View Approver" OnCommand="lnkApproverName_Command"
                                                                                            CommandArgument='<%# Eval("Approver_Name")%>' runat="server" Text='<%# Eval("Approver_Name")%>'> </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                                                    EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Delete Approver"
                                                                                    VisibleIndex="3">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" OnCommand="RemoveApprover_Command" ID="ImgRemoveApprover"
                                                                                            CommandName="RemoveApprover" ToolTip="Delete Approver" Style="cursor: pointer"
                                                                                            CommandArgument='<%# Eval("Approver_ID")%>' ImageUrl="../Images/remove-icon.gif">
                                                                                        </asp:ImageButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant Name"
                                                                                    VisibleIndex="4">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'> </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager Mode="ShowAllRecords">
                                                                            </SettingsPager>
                                                                            <Settings GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>--%>
                                                                        <dx:ASPxGridView ID="drgdAppGrp" KeyFieldName="Approver_ID" Width="100%" runat="server"
                                                                            AutoGenerateColumns="False" OnHtmlRowPrepared="drgdAppGrp_OnHtmlRowPrepared">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Function Name"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>                                                                                   
                                                                                        <dx:ASPxButton Image-Url="../Images/arrow1.gif" EnableDefaultAppearance="false" ID="imgFunction1" OnCommand="imgFunction1_Command"
                                                                                            CommandName='<%# Eval("Function_ID")%>' functionID='<%# Eval("Function_ID")%>' Text='<%# Eval("Function_Name")%>' Style="cursor: pointer" runat="server">
                                                                                        </dx:ASPxButton>
                                                                                        <dx:ASPxButton Image-Url="../Images/arrow_down1.gif" EnableDefaultAppearance="false" ID="imgFunction2" OnCommand="imgFunction2_Command"
                                                                                            Style="cursor: pointer" functionID='<%# Eval("Function_ID")%>' Text='<%# Eval("Function_Name")%>' runat="server" Visible="false">
                                                                                        </dx:ASPxButton>
                                                                                        <%--    <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgFunction1" CommandName='<%# Eval("Function_ID")%>'
                                                                                            OnCommand="imgFunction1_Command" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton Visible="false" runat="server" Style="cursor: pointer" ID="imgFunction2" OnCommand="imgFunction2_Command"
                                                                                            CommandName="Function2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>--%>
                                                                                        <asp:Label ID="lblFunctionID" Visible="false" runat="server" Text='<%# Eval("Function_ID")%>'> </asp:Label>
                                                                                        <%--<dx:ASPxLabel ID="lblFunctionName" runat="server" functionID='<%# Eval("Function_ID")%>'
                                                                                            Text='<%# Eval("Function_Name")%>'></dx:ASPxLabel>--%>
                                                                                        <%--<asp:Label ID="lblFunctionName" runat="server" functionID='<%# Eval("Function_ID")%>'
                                                                                            Text='<%# Eval("Function_Name")%>'> </asp:Label>--%>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <tr>
                                                                                            <td colspan="30%">
                                                                                                <div style="position: relative; left: 15px; overflow: auto">
                                                                                                    <dx:ASPxGridView ID="drgdAppNames" Visible="false" KeyFieldName="Approver_ID" Width="100%"
                                                                                                        runat="server" AutoGenerateColumns="False" OnHtmlRowPrepared="drgdAppNames_HtmlRowPrepared">
                                                                                                        <Columns>
                                                                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Approver Name"
                                                                                                                VisibleIndex="2">
                                                                                                                <DataItemTemplate>
                                                                                                                    <asp:Label ID="lblFunctID" runat="server" Text='<%# Eval("Function_ID")%>' Visible="False"> </asp:Label>
                                                                                                                    <asp:Label ID="lblApprvrID" runat="server" Text='<%# Eval("Approver_ID")%>' Visible="False"> </asp:Label>
                                                                                                                    <asp:Label ID="lblPlantID" runat="server" Text='<%# Eval("Plant_ID")%>' Visible="False"> </asp:Label>
                                                                                                                    <asp:LinkButton ID="lnkApproverName" ToolTip="View Approver" OnCommand="lnkApproverName_Command"
                                                                                                                        CommandArgument='<%# Eval("Approver_Name")%>' runat="server" Text='<%# Eval("Approver_Name")%>'> </asp:LinkButton>
                                                                                                                </DataItemTemplate>
                                                                                                            </dx:GridViewDataColumn>
                                                                                                            <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                                                                                EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Delete Approver"
                                                                                                                VisibleIndex="3">
                                                                                                                <DataItemTemplate>
                                                                                                                    <asp:ImageButton runat="server" OnCommand="RemoveApprover_Command" ID="ImgRemoveApprover"
                                                                                                                        CommandName="RemoveApprover" ToolTip="Delete Approver" Style="cursor: pointer"
                                                                                                                        CommandArgument='<%# Eval("Approver_ID")%>' ImageUrl="../Images/remove-icon.gif">
                                                                                                                    </asp:ImageButton>
                                                                                                                </DataItemTemplate>
                                                                                                            </dx:GridViewDataColumn>
                                                                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant Name"
                                                                                                                VisibleIndex="4">
                                                                                                                <DataItemTemplate>
                                                                                                                    <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'> </asp:Label>
                                                                                                                </DataItemTemplate>
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
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <%-- <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Approver Name"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblFunctID" runat="server" Text='<%# Eval("Function_ID")%>' Visible="False"> </asp:Label>
                                                                                        <asp:Label ID="lblApprvrID" runat="server" Text='<%# Eval("Approver_ID")%>' Visible="False"> </asp:Label>
                                                                                        <asp:Label ID="lblPlantID" runat="server" Text='<%# Eval("Plant_ID")%>' Visible="False"> </asp:Label>
                                                                                        <asp:LinkButton ID="lnkApproverName" ToolTip="View Approver" OnCommand="lnkApproverName_Command"
                                                                                            CommandArgument='<%# Eval("Approver_Name")%>' runat="server" Text='<%# Eval("Approver_Name")%>'> </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                                                    EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Delete Approver"
                                                                                    VisibleIndex="3">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" OnCommand="RemoveApprover_Command" ID="ImgRemoveApprover"
                                                                                            CommandName="RemoveApprover" ToolTip="Delete Approver" Style="cursor: pointer"
                                                                                            CommandArgument='<%# Eval("Approver_ID")%>' ImageUrl="../Images/remove-icon.gif">
                                                                                        </asp:ImageButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant Name"
                                                                                    VisibleIndex="4">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'> </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>--%>
                                                                            </Columns>
                                                                            <SettingsPager Mode="ShowAllRecords">
                                                                            </SettingsPager>
                                                                            <Settings GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
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
            <input type="hidden" runat="server" id="hdnresponse" name="response">
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
