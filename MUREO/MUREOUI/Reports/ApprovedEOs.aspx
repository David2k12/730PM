<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovedEOs.aspx.cs" Inherits="MUREOUI.Reports.ApprovedEOs" %>

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
    <title>Approved EOs</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
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
<body ms_positioning="GridLayout" bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="mainTable" cellspacing="0" cellpadding="0" width="750px" height="100%">
                <tr>
                    <td valign="top">
                        <HeadControl:HeaderControl ID="HeaderControl" runat="server"></HeadControl:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table id="innerTable1" cellspacing="0" cellpadding="0" width="700px">
                            <tr>
                                <td valign="top">
                                    <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td class="FormHeader" valign="top" colspan="3">
                                                Approved EOs&nbsp;
                                            </td>
                                        </tr>
                                        <tr height="5">
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:ImageButton ID="imgCreateNewEO" OnClick="imgCreateNewEO_Click" runat="server"
                                                    ImageUrl="../Images/create-eo.gif" AlternateText="Click to create a new FYI">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgExpandAll" OnClick="imgExpandAll_Click" runat="server" ImageUrl="../Images/expandall.gif">
                                                </asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCollapseAll" OnClick="imgCollapseAll_Click" runat="server"
                                                    ImageUrl="../Images/collpaseall.gif" AlternateText="Collapse All"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" width="350px">
                                                <div id="division1" style="overflow: auto; width: 350px; height: 350px">
                                                    <%--<asp:datagrid id="dgdAppEOTree" runat="server" BorderWidth="1px" GridLines="None" Width="100%"
														HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False" BorderColor="black">
														<HeaderStyle CssClass="SubHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Plant">
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																<ItemStyle Wrap="False"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton Runat="server" ID="imgPlant1" CommandName="PlantExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																	<asp:ImageButton Runat="server" ID="imgPlant2" CommandName="PlantCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																	<asp:Label ID="lblPlantId" Runat=server Visible =False text='<%# DataBinder.Eval(Container.Dataitem,"Plant_ID")%>'>
																	</asp:Label>
																	<asp:Label ID="lblPlantName" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"Plant_Name")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="EO Type">
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																<ItemStyle Wrap="False"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton Runat="server" ID="imgEOMode1" CommandName="EOModeExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																	<asp:ImageButton Runat="server" ID="imgEOMode2" CommandName="EOModeCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																	<asp:Label ID="lblPlanID" Runat=server Visible =False text='<%# DataBinder.Eval(Container.Dataitem,"Plant_ID")%>'>
																	</asp:Label>
																	<asp:Label ID="lblEOMode" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"EO_Mode")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>--%>
                                                    <dx:ASPxGridView ID="dgdAppEOTree" KeyFieldName="Index" Width="300px" runat="server"
                                                        AutoGenerateColumns="False" OnHtmlRowPrepared="dgdAppEOTree_HtmlRowPrepared"
                                                        OnPageIndexChanged="dgdAppEOTree_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant"
                                                                VisibleIndex="1">
                                                                <DataItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgPlant1" OnCommand="imgPlant1_Command" CommandName="PlantExpand"
                                                                        ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                    <asp:ImageButton runat="server" ID="imgPlant2" OnCommand="imgPlant2_Command" CommandName="PlantCollapse"
                                                                        ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                    <asp:Label ID="lblPlantId" runat="server" Visible="false" Text='<%#Eval("Plant_ID")%>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="lblPlantName" runat="server" Text='<%#Eval("Plant_Name")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="EO Type"
                                                                VisibleIndex="2">
                                                                <DataItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgEOMode1" OnCommand="imgEOMode1_Command" CommandArgument='<%#Eval("Plant_ID")%>'
                                                                        CommandName='<%#Eval("EO_Mode")%>' ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                    <asp:ImageButton runat="server" ID="imgEOMode2" OnCommand="imgEOMode2_Command" CommandName="EOModeCollapse"
                                                                        ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                    <asp:Label ID="lblPlanID" runat="server" Visible="False" Text='<%#Eval("Plant_ID")%>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="lblEOMode" runat="server" Text='<%#Eval("EO_Mode")%>'>
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
                                            <td id="tdDivider" runat="server" width="2px" bgcolor="#0066ff">
                                            </td>
                                            <td width="700px" valign="top">
                                                <table border="0" cellpadding="0" cellspacing="5" width="100%">
                                                    <tr>
                                                        <td width="25%" align="right">
                                                            <asp:Label ID="lblPlantlb" runat="server">Plant :</asp:Label>
                                                        </td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblPlantVal" runat="server"></asp:Label>
                                                        </td>
                                                        <td width="25%" align="right">
                                                            <asp:Label ID="lblEOTypelb" runat="server">EO Type :</asp:Label>
                                                        </td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblEOTypeVal" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div id="division2" style="overflow: auto; width: 700px; height: 300px"> 
                                                    <dx:ASPxGridView ID="dgdPrelimSelectedEO" KeyFieldName="EO_ID" Width="680px" runat="server"
                                                        AutoGenerateColumns="False" OnHtmlRowPrepared="dgdPrelimSelectedEO_HtmlRowPrepared"
                                                        OnPageIndexChanged="dgdPrelimSelectedEO_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="EO Num"
                                                                VisibleIndex="0">
                                                                <DataItemTemplate>
                                                                    <asp:Label ID="lblEOID" runat="server" Visible="False" Text='<%#Eval("EO_ID")%>'>
                                                                    </asp:Label>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypEONumber_Command"
                                                                        runat="server" ID="hypEONumber" Text='<%# Eval("EO_Number")%>'>
                                                                    </asp:LinkButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="EO Title"
                                                                VisibleIndex="1">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypEOTitle_Command" runat="server"
                                                                        ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                                    </asp:LinkButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Originator" EditCellStyle-HorizontalAlign="Justify"
                                                                Width="20%" Caption="Originator" VisibleIndex="2" />
                                                            <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                                EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Open as Read Only"
                                                                VisibleIndex="3">
                                                                <DataItemTemplate>
                                                                    <%-- <asp:ImageButton ID="ImgReadOnlyEO" Style="cursor: pointer" ToolTip="Open as Read Only"
                                                                        OnCommand="ImgReadOnlyEO_Command" CommandArgument='<%#Eval("Current_Stage")%>'
                                                                        CommandName='<%#Eval("EO_ID")%>' runat="server" ImageUrl="../Images/actn037.gif">
                                                                    </asp:ImageButton>--%>
                                                                    <dx:ASPxButton Image-Url="../Images/actn037.gif" ID="ImgReadOnlyEO" OnCommand="ImgReadOnlyEO_Command"
                                                                        CommandArgument='<%#Eval("Current_Stage")%>' CommandName='<%#Eval("EO_ID")%>'
                                                                        ToolTip="Open as Read Only" Style="cursor: pointer" runat="server">
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Current Stage"
                                                                VisibleIndex="4">
                                                                <DataItemTemplate>
                                                                    <asp:Label ID="lblCurrentStage" Text='<%# Eval("Current_Stage") %>' runat="server" />
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Status"
                                                                VisibleIndex="5">
                                                                <DataItemTemplate>
                                                                    <asp:Label ID="lblStageStatus" Text='<%# Eval("Stage_Status") %>' runat="server" />
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Brand_Segment_Name" EditCellStyle-HorizontalAlign="Justify"
                                                                Width="20%" Caption="Brand" VisibleIndex="6" />
                                                            <dx:GridViewDataColumn FieldName="Plant_Name" EditCellStyle-HorizontalAlign="Justify"
                                                                Width="20%" Caption="Plant" VisibleIndex="7" />
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Last Modified"
                                                                VisibleIndex="8">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypModifiedDate_Command"
                                                                        runat="server" ID="hypModifiedDate" Text='<%# Eval("Modified_Date")%>'>
                                                                    </asp:LinkButton>
                                                                    <asp:Label ID="lblISApprovar" runat="server" Visible="False" Text='<%# Eval("Is_Approver")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                        </Columns>
                                                        <SettingsPager PageSize="20" Position="Bottom" NextPageButton-Image-ToolTip="Next"
                                                            PrevPageButton-Image-ToolTip="Previous">
                                                        </SettingsPager>
                                                        <Settings GridLines="None" />
                                                        <Styles>
                                                            <Header Font-Bold="true" BackColor="#FFCC00">
                                                            </Header>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                    <%--<asp:datagrid id="dgdAppSelectedEO" runat="server" BorderWidth="1px" GridLines="None" Width="100%"
														HeaderStyle-CssClass="subHeader" AutoGenerateColumns="False" BorderColor="Black" DataKeyField="EO_ID"
														AllowPaging="True" CellSpacing="2" AllowSorting="True">
														<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" CssClass="AlternateRow1"></ItemStyle>
														<HeaderStyle Wrap="False" CssClass="subHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn SortExpression="EO_Number" HeaderText="EO Num">
																<HeaderStyle Wrap="False"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label ID="lblEOID" Runat=server Visible=False text='<%#DataBinder.Eval(Container.Dataitem,"EO_ID")%>'>
																	</asp:Label>
																	<asp:LinkButton CommandName="EONum_Link" Runat =server ID=hypEONumber text='<%# DataBinder.Eval(Container.DataItem,"EO_Number")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="EO_Title" HeaderText="EO Title">
																<HeaderStyle Wrap="False"></HeaderStyle>
																<ItemTemplate>
																	<asp:LinkButton CommandName ="EOTitle_Link" Runat=server ID =hypEOTitle text='<%# DataBinder.Eval(Container.DataItem,"EO_Title")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Originator" SortExpression="Originator" HeaderText="Originator"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Open as Read Only">
																<HeaderStyle Wrap="False"></HeaderStyle>
																<ItemTemplate>
																	<asp:ImageButton id="ImgReadOnlyEO" CommandName="ReadOnly" Runat="server" ImageUrl="../Images/actn037.gif"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Current_Stage" SortExpression="Current_Stage" HeaderText="Current Stage">
																<HeaderStyle Wrap="False"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Stage_Status" SortExpression="Stage_Status" HeaderText="Status"></asp:BoundColumn>
															<asp:BoundColumn DataField="Brand_Segment_Name" SortExpression="Brand_Segment_Name" HeaderText="Brand">
																<HeaderStyle Wrap="False"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Plant_Name" SortExpression="Plant_Name" HeaderText="Plant"></asp:BoundColumn>
															<asp:TemplateColumn SortExpression="Modified_Date" HeaderText="Last Modified">
																<ItemTemplate>
																	<asp:LinkButton CommandName="ModifiedDate_Link" Runat=server ID=hypModifiedDate text='<%# DataBinder.Eval(Container.DataItem,"Modified_Date")%>'>
																	</asp:LinkButton>
																	<asp:Label ID="lblISApprovar" Runat=server Visible=False text='<%#DataBinder.Eval(Container.Dataitem,"Is_Approver")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Left"></PagerStyle>
													</asp:datagrid>--%></div>
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
