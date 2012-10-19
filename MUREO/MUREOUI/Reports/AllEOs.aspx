<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllEOs.aspx.cs" Title="AllEOs/SiteTests"
    Inherits="MUREOUI.Reports.AllEOs" %>

<%@ Register TagPrefix="FootControl" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="HeadControl" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="NavigationControl" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>All EOs</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
       

       
        function DeleteEO(intEOID, strCurrentStage) {
            var popResult;
            var btnDel = document.getElementById("<%=btnDel.ClientID %>").id;
            var hdnvar;
            hdnvar = window.open('../Reports/EODelete.aspx?EventID=' + intEOID + '&stage=' + strCurrentStage + '&btnDel=' + btnDel, null, 'height=270, width=590, left=280, top=120');
            
        }

        function DeleteMessage(hdnvar, strCurrentStage) {
            if (hdnvar == "E") {
                if (strCurrentStage == "Site Test") {
                    alert('Site Test and its associated Events are deleted successfully.');
                }
                else {
                    alert('EO and its associated Events are deleted successfully.');
                }

            }
            else if (hdnvar == "D") {
                if (strCurrentStage == "Site Test") {
                    alert('Site Test Deleted and its associated Events are released successfully.');
                }
                else {
                    alert('EO Deleted and its associated Events are released successfully.');
                }
            }
            else if (hdnvar == "F") {
                alert('Record deletion failed.');
            }
            window.location = 'AllEOs.aspx';
        }
       
       
        function NavigateSpecificEO() {
            window.open('../Reports/GotoEO.aspx', 'GotoEO', 'top=250,left=300,width=500,height=150,menubar=no,resizable=no');
            return false;
        }


        

        function RedirectPage() {
            window.open('../Common/ExtractCostSheet.aspx', 'DataExport', 'top=250,left=300,width=340,height=200,menubar=no,resizable=no');
            return false;
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
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="mainTable" height="100%" cellspacing="0" cellpadding="0" width="100%"
                border="0">
                <tr>
                    <td valign="top">
                        <HeadControl:HeaderControl ID="HeaderControl" runat="server"></HeadControl:HeaderControl>
                        <div id="btndicv" style="display: none">
                            <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="DelEo" /></div>
                    </td>
                </tr>
                <tr height="300px">
                    <td valign="top">
                        <table id="innerTable1" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td valign="top" width="80%">
                                    <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td class="FormHeader" valign="top" colspan="3">
                                                All EO's/Site Test's
                                            </td>
                                        </tr>
                                        <tr height="10">
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:ImageButton ID="imgCreateNewEO" OnClick="imgCreateNewEO_Click" runat="server"
                                                    AlternateText="Click to create a new FYI" ImageUrl="../Images/create-eo.gif">
                                                </asp:ImageButton>&nbsp;&nbsp;
                                                <asp:ImageButton ID="imgGotoEO" runat="server" AlternateText="Goto EO" ImageUrl="../Images/All-goto-eo.gif">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgExpandAll" OnClick="imgExpandAll_Click" runat="server" ImageUrl="../Images/expandall.gif">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCollapseAll" OnClick="imgCollapseAll_Click" runat="server"
                                                    AlternateText="Collapse All" ImageUrl="../Images/collpaseall.gif"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgbtnExtractEOCostSheet" runat="server" ImageUrl="../Images/Extract-EO-Cost-Sheet.gif"
                                                    AlternateText="Extract EO Cost Sheet"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr height="5">
                                            <td colspan="3">
                                                <table cellspacing="0" cellpadding="0" width="60%">
                                                    <tr>
                                                        <td width="20px" align="right">
                                                            Filter :
                                                        </td>
                                                        <td align="left" width="30px">
                                                            <asp:RadioButtonList ID="rdbAllEOFilter" OnSelectedIndexChanged="rdbAllEOFilter_SelectedIndexChanged"
                                                                runat="server" Width="300px" RepeatDirection="Horizontal" AutoPostBack="True">
                                                                <asp:ListItem Value="0">Plant and Originator</asp:ListItem>
                                                                <asp:ListItem Value="1">Originator</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="center" width="400px">
                                                <div id="division1" style="overflow: auto; width: 400px; height: 230px">
                                                    <%--<asp:datagrid id="dgdAllEOTree" runat="server" Width="100%" BorderColor="black" AutoGenerateColumns="False"
														HeaderStyle-CssClass="SubHeader" GridLines="None" BorderWidth="1px">
														<HeaderStyle CssClass="SubHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Plant">
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																<ItemStyle Wrap="False"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton Runat="server" ID="imgPlant1" CommandName="PlantExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																	<asp:ImageButton Runat="server" ID="imgPlant2" CommandName="PlantCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																	<asp:Label ID="lblPlantId" Runat=server Visible =False text='<%# Eval("Plant_ID")%>'>
																	</asp:Label>
																	<asp:Label ID="lblPlantName" Runat="server" text='<%# Eval("Plant_Name_Mode")%>'>
																	</asp:Label>
																	<asp:Label ID="lblEOMode" Runat=server Visible =False text='<%# Eval("EO_Mode")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Originator">
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																<ItemStyle Wrap="False"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton Runat="server" ID="imgOriginator1" CommandName="OriginatorExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																	<asp:ImageButton Runat="server" ID="imgOriginator2" CommandName="OriginatorCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																	<asp:Label ID="lblPlanID" Runat=server Visible =false text='<%# Eval("Plant_ID")%>'>
																	</asp:Label>
																	<asp:Label ID="lblOriginator" Runat="server" text='<%# Eval("Originator")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>--%>
                                                    <dx:ASPxGridView ID="dgdAllEOTree" KeyFieldName="Index" Width="380px" runat="server"
                                                        AutoGenerateColumns="False" OnHtmlRowPrepared="dgdAllEOTree_HtmlRowPrepared"
                                                        OnPageIndexChanged="dgdAllEOTree_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Plant"
                                                                VisibleIndex="1" CellStyle-HorizontalAlign="Left">
                                                                <DataItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgPlant1" OnCommand="imgPlant1_Command" CommandName="PlantExpand"
                                                                        ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                    <asp:ImageButton runat="server" ID="imgPlant2" OnCommand="imgPlant2_Command" CommandName="PlantCollapse"
                                                                        ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                    <asp:Label ID="lblPlantId" runat="server" Visible="False" Text='<%# Eval("Plant_ID")%>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name_Mode")%>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="lblEOMode" runat="server" Visible="False" Text='<%# Eval("EO_Mode")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Originator"
                                                                VisibleIndex="2" CellStyle-HorizontalAlign="Left">
                                                                <DataItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgOriginator1" OnCommand="imgOriginator1_Command"
                                                                        CommandName="OriginatorExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                    <asp:ImageButton runat="server" ID="imgOriginator2" OnCommand="imgOriginator2_Command"
                                                                        CommandName="OriginatorCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                    <asp:Label ID="lblPlanID" runat="server" Visible="false" Text='<%# Eval("Plant_ID")%>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="lblOriginator" runat="server" Text='<%# Eval("Originator")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                        </Columns>
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings GridLines="None" />
                                                        <Styles>
                                                            <Header Font-Bold="true" BackColor="#FFCC00">
                                                            </Header>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                    <%--<asp:DataGrid ID="dgdAllEOTreeforOriginator" runat="server" Width="100%" BorderColor="Black"
                                                AutoGenerateColumns="False" GridLines="None" BorderWidth="1px">
                                                <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Originator">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgOrg1" CommandName="ExpandOriginator" ImageUrl="../Images/arrow1.gif">
                                                            </asp:ImageButton>
                                                            <asp:ImageButton runat="server" ID="imgOrg2" CommandName="CollapseOriginator" ImageUrl="../Images/arrow_down1.gif">
                                                            </asp:ImageButton>
                                                            <asp:Label ID="lblOnlyOriginator" runat="server" Visible="True" Text='<%# Eval("Originator")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>--%>
                                                    <dx:ASPxGridView ID="dgdAllEOTreeforOriginator" KeyFieldName="Originator" Width="100%"
                                                        runat="server" AutoGenerateColumns="False" OnPageIndexChanged="dgdAllEOTreeforOriginator_PageIndexChanged"
                                                        OnHtmlRowPrepared="dgdAllEOTreeforOriginator_HtmlRowPrepared">
                                                        <Columns>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" CellStyle-HorizontalAlign="Left"
                                                                Width="20%" Caption="Originator" VisibleIndex="1">
                                                                <DataItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgOrg1" OnCommand="imgOrg1_Command" CommandName="ExpandOriginator"
                                                                        ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                    <asp:ImageButton runat="server" ID="imgOrg2" OnCommand="imgOrg2_Command" CommandName="CollapseOriginator"
                                                                        ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                    <asp:Label ID="lblOnlyOriginator" runat="server" Visible="True" Text='<%# Eval("Originator")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                        </Columns>
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings GridLines="None" />
                                                        <Styles>
                                                            <Header Font-Bold="true" BackColor="#FFCC00">
                                                            </Header>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                </div>
                                            </td>
                                            <td id="tdDivider" width="2" bgcolor="#0066ff" runat="server">
                                            </td>
                                            <td valign="top" width="748">
                                                <table cellspacing="5" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" width="25%">
                                                            <asp:Label ID="lblPlantlb" runat="server">Plant :</asp:Label>
                                                        </td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblPlantVal" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right" width="25%">
                                                            <asp:Label ID="lblOriginatorlb" runat="server">Originator :</asp:Label>
                                                        </td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblOriginatorVal" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div id="division2" style="overflow: auto; width: 675px; height: 230px">
                                                    <dx:ASPxGridView ID="dgdSelectedEO" KeyFieldName="EO_ID" Width="100%" runat="server"
                                                        AutoGenerateColumns="False" OnHtmlRowPrepared="dgdSelectedEO_HtmlRowPrepared"
                                                        OnPageIndexChanged="dgdSelectedEO_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="EO#"
                                                                VisibleIndex="0">
                                                                <DataItemTemplate>
                                                                    <asp:Label ID="lblEOID" runat="server" Visible="False" Text='<%#Eval("EO_ID")%>'>
                                                                    </asp:Label>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypEONumber_Command"
                                                                        runat="server" ID="hypEONumber" Text='<%# Eval("EO_Number")%>'>
                                                                    </asp:LinkButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="EO Title"
                                                                VisibleIndex="1">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="EOTitle_Link_Command"
                                                                        runat="server" ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                                    </asp:LinkButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="EO_Mode" EditCellStyle-HorizontalAlign="left" Width="20%"
                                                                Caption="EO Mode" VisibleIndex="2" />
                                                            <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Check Approvals" VisibleIndex="3">
                                                                <DataItemTemplate>
                                                                    <%--    <asp:ImageButton ID="imgCheckApproval" Style="cursor: pointer" ToolTip="Check Approvals"
                                                                        OnCommand="imgCheckApproval_Command" CommandArgument='<%#Eval("Current_Stage")%>'
                                                                        CommandName='<%#Eval("EO_ID")%>' runat="server" ImageUrl="../Images/actn045.gif">
                                                                    </asp:ImageButton>--%>
                                                                    <dx:ASPxButton Image-Url="../Images/actn045.gif" ID="imgCheckApproval" OnCommand="imgCheckApproval_Command"
                                                                        CommandName='<%# Eval("EO_ID") %>' ToolTip="Check Approvals" CommandArgument='<%# Eval("Current_Stage")%>'
                                                                        Style="cursor: pointer" runat="server">
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Open as Read Only"
                                                                VisibleIndex="3">
                                                                <DataItemTemplate>
                                                                    <%--    <asp:ImageButton ID="ImgReadOnlyEO" Style="cursor: pointer" ToolTip="Open as Read Only"
                                                                        OnCommand="ImgReadOnlyEO_Command" CommandArgument='<%#Eval("Current_Stage")%>'
                                                                        CommandName='<%#Eval("EO_ID")%>' runat="server" ImageUrl="../Images/actn037.gif">
                                                                    </asp:ImageButton>--%>
                                                                    <dx:ASPxButton ID="ImgReadOnlyEO" Image-Url="../Images/actn037.gif" OnCommand="ImgReadOnlyEO_Command"
                                                                        ToolTip="Open as Read Only" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                        Style="cursor: pointer" runat="server">
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Current Stage"
                                                                VisibleIndex="4">
                                                                <DataItemTemplate>
                                                                    <asp:Label ID="lblCurrentStage" Text='<%# Eval("Current_Stage") %>' runat="server" />
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Status"
                                                                VisibleIndex="5">
                                                                <DataItemTemplate>
                                                                    <asp:Label ID="lblStatus" Text='<%# Eval("Status") %>' runat="server" />
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <%-- <dx:GridViewDataColumn FieldName="Status" EditCellStyle-HorizontalAlign="left"
                                                        Width="20%" Caption="Status" VisibleIndex="5" />--%>
                                                            <%--<dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Stage Status"
                                                        VisibleIndex="5">
                                                        <DataItemTemplate>
                                                            <asp:Label ID="lblStageStatus" Text='<%# Eval("Stage_Status") %>' runat="server" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>--%>
                                                            <dx:GridViewDataColumn FieldName="Brand_Segment_Name" EditCellStyle-HorizontalAlign="left"
                                                                Width="20%" Caption="Brand" VisibleIndex="6" />
                                                            <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Stop this EO?" VisibleIndex="7">
                                                                <DataItemTemplate>
                                                                    <%--    <asp:ImageButton ID="imgStopEO" Style="cursor: pointer" ToolTip="Stop this EO" OnCommand="imgStopEO_Command"
                                                                        CommandArgument='<%#Eval("Current_Stage")%>' CommandName='<%#Eval("EO_ID")%>'
                                                                        runat="server" ImageUrl="../Images/stop.gif"></asp:ImageButton>--%>
                                                                    <dx:ASPxButton ID="imgStopEO" Image-Url="../Images/stop.gif" OnCommand="imgStopEO_Command"
                                                                        ToolTip="Stop this EO?" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                        Style="cursor: pointer" runat="server">
                                                                        <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to stop this EO?'); }" />
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                Caption="Cancel EO?" VisibleIndex="8" Width="15%">
                                                                <DataItemTemplate>
                                                                    <%--  <asp:ImageButton ID="imgCancel" Style="cursor: pointer" ToolTip="Cancel EO" CommandName='<%# Eval("EO_ID") %>'
                                                                        CommandArgument='<%# Eval("Current_Stage")%>' OnCommand="imgCancel_Command" runat="server"
                                                                        ImageUrl="../Images/Cancel_Status.gif"></asp:ImageButton>--%>
                                                                    <dx:ASPxButton ID="imgCancel" Image-Url="../Images/Cancel_Status.gif" OnCommand="imgCancel_Command"
                                                                        ToolTip="Cancel EO?" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                        Style="cursor: pointer" runat="server">
                                                                        <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to cancel this EO?'); }" />
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn Caption="Delete EO?" VisibleIndex="9" Width="15%">
                                                                <DataItemTemplate>
                                                                    <%-- <asp:ImageButton Style="cursor: pointer" ToolTip="Delete EO" CellStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-HorizontalAlign="Center" ID="imgDelete" CommandName='<%# Eval("EO_ID") %>'
                                                                        CommandArgument='<%# Eval("Current_Stage")%>' OnCommand="imgDelete_Command" runat="server"
                                                                        ImageUrl="../Images/delete_icon.gif"></asp:ImageButton>--%>
                                                                    <dx:ASPxButton ID="imgDelete" OnCommand="imgDelete_Command" Image-Url="../Images/delete_icon.gif"
                                                                        ToolTip="Delete EO?" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                        Style="cursor: pointer" runat="server">
                                                                        <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to delete this EO / Site Test?'); }" />
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Plant_Name" EditCellStyle-HorizontalAlign="left"
                                                                Width="20%" Caption="Plant" VisibleIndex="10" />
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="left" Width="20%" Caption="Last Modified"
                                                                VisibleIndex="11">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypModifiedDate_Command"
                                                                        runat="server" ID="hypModifiedDate" Text='<%# Eval("Modified_Date")%>'>
                                                                    </asp:LinkButton>
                                                                    <asp:Label ID="lblISApprovar" runat="server" Visible="False" Text='<%# Eval("Is_Approver")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                        </Columns>
                                                        <SettingsPager PageSize="20" Position="Bottom">
                                                        </SettingsPager>
                                                        <Settings GridLines="None" />
                                                        <Styles>
                                                            <Header Font-Bold="true" BackColor="#FFCC00">
                                                            </Header>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                    <%-- <asp:DataGrid ID="dgdSelectedEO" runat="server" Width="100%" BorderColor="Black"
                                                AutoGenerateColumns="False" HeaderStyle-CssClass="subHeader" GridLines="None"
                                                BorderWidth="1px" AllowSorting="True" AllowPaging="True" DataKeyField="EO_ID"
                                                OnItemCommand="DisplayBoundColumnValues" CellSpacing="2">
                                                <AlternatingItemStyle BorderColor="#ACA899" CssClass="AlternateRow2"></AlternatingItemStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="AlternateRow1"></ItemStyle>
                                                <HeaderStyle Wrap="False" CssClass="subHeader"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn SortExpression="EO_Number" HeaderText="EO # ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEOID" runat="server" Visible="False" Text='<%#Eval("EO_ID")%>'>
                                                            </asp:Label>
                                                            <asp:LinkButton CommandName="EONum_Link" runat="server" ID="hypEONumber" Text='<%# Eval("EO_Number")%>'>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn SortExpression="EO_Title" HeaderText="EO Title ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:LinkButton CommandName="EOTitle_Link" runat="server" ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="EO_Mode" SortExpression="EO_Mode" HeaderText="EO Mode ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Check Approvals">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgCheckApproval" CommandName="CheckApproval" runat="server"
                                                                ImageUrl="../Images/actn045.gif"></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Open as Read Only ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgReadOnlyEO" CommandName="ReadOnly" runat="server" ImageUrl="../Images/actn037.gif">
                                                            </asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="Current_Stage" SortExpression="Current_Stage" HeaderText="Current Stage ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Status" SortExpression="Status" HeaderText="Status ">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Brand_Segment_Name" SortExpression="Brand_Segment_Name"
                                                        HeaderText="Brand">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Stop this EO? ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgStopEO" runat="server" ImageUrl="../Images/stop.gif" CommandName="Stop">
                                                            </asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Cancel EO? ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/Cancel_Status.gif"
                                                                CommandName="Cancel"></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Delete EO? ">
                                                        <HeaderStyle Wrap="False"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="../Images/delete_icon.gif"
                                                                CommandName="Delete"></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="Plant_Name" SortExpression="Plant_Name" HeaderText="Plant ">
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn SortExpression="Modified_Date" HeaderText="Last Modified ">
                                                        <ItemTemplate>
                                                            <asp:LinkButton CommandName="ModifiedDate_Link" runat="server" ID="hypModifiedDate"
                                                                Text='<%# Eval("Modified_Date")%>'>
                                                            </asp:LinkButton>
                                                            <asp:Label ID="lblISApprovar" runat="server" Visible="False" Text='<%#Eval("Is_Approver")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Left"></PagerStyle>
                                            </asp:DataGrid>--%></div>
                                                <p align="center">
                                                </p>
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
