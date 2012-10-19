<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovedPreliminaryEOs.aspx.cs"
    Inherits="MUREOUI.Reports.ApprovedPreliminaryEOs" %>

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
    <title>Approved Preliminary EOs</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <%--    <script language="javascript">

        function setScreenRes() {
            document.getElementById("division1").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            document.getElementById("division2").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            if (screen.width == 1024) {
                document.getElementById("division1").style.width = (screen.width - 780);
                document.getElementById("division2").style.width = (screen.width - 280);
            }
            else if (screen.width == 1280) {
                document.getElementById("division1").style.width = (screen.width - 835);
                document.getElementById("division2").style.width = (screen.width - 475);
            }
            else if (screen.width == 1600) {
                document.getElementById("division1").style.width = (screen.width - 1020);
                document.getElementById("division2").style.width = (screen.width - 640);
            }
            else if (screen.width == 1920) {
                document.getElementById("division1").style.width = (screen.width - 1152);
                document.getElementById("division2").style.width = (screen.width - 760);
            }


        }
    </script>--%>
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
    <%--  position: absolute;
            width: 400px;
            left: 500px;
            top: 200px;
            height: 400px;
            opacity: 0.4;
            filter: alpha(opacity=40); /* For IE8 and earlier */--%>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td valign="top">
                        <HeadControl:HeaderControl ID="HeaderControl" runat="server"></HeadControl:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td class="FormHeader" valign="top" colspan="3">
                                                Approved Preliminary EOs&nbsp;
                                            </td>
                                        </tr>
                                        <tr height="10">
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
                                            <td valign="top" align="left" width="300px">
                                                <div id="division1" style="overflow: auto; width: 300px; height: 300px">
                                                    <dx:ASPxGridView ID="dgdAppPrelimEOTree" Width="280px" KeyFieldName="Index" runat="server"
                                                        AutoGenerateColumns="False" OnHtmlRowPrepared="dgdAppPrelimEOTree_HtmlRowPrepared"
                                                        OnPageIndexChanged="dgdAppPrelimEOTree_PageIndexChanged">
                                                        <Columns>
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="50%" Caption="Plant"
                                                                VisibleIndex="0">
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
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="50%" Caption="EO Type"
                                                                VisibleIndex="1">
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
                                                    <%--<asp:DataGrid ID="dgdAppPrelimEOTree" runat="server" BorderWidth="1px" GridLines="None"
                                                Width="100%" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False" BorderColor="black"
                                                PageSize="12">
                                                <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Plant">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle Wrap="False"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgPlant1" CommandName="PlantExpand" ImageUrl="../Images/arrow1.gif">
                                                            </asp:ImageButton>
                                                            <asp:ImageButton runat="server" ID="imgPlant2" CommandName="PlantCollapse" ImageUrl="../Images/arrow_down1.gif">
                                                            </asp:ImageButton>
                                                            <asp:Label ID="lblPlantId" runat="server" Visible="true" Text='<%#Eval("Plant_ID")%>'>
                                                            </asp:Label>
                                                            <asp:Label ID="lblPlantName" runat="server" Text='<%#Eval("Plant_Name")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="EO Type">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle Wrap="False"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgEOMode1" CommandName="EOModeExpand" ImageUrl="../Images/arrow1.gif">
                                                            </asp:ImageButton>
                                                            <asp:ImageButton runat="server" ID="imgEOMode2" CommandName="EOModeCollapse" ImageUrl="../Images/arrow_down1.gif">
                                                            </asp:ImageButton>
                                                            <asp:Label ID="lblPlanID" runat="server" Visible="False" Text='<%#Eval("Plant_ID")%>'>
                                                            </asp:Label>
                                                            <asp:Label ID="lblEOMode" runat="server" Text='<%#Eval("EO_Mode")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>OnHtmlRowPrepared="dgdPrelimSelectedEO_HtmlRowPrepared"
                                                OnPageIndexChanged="dgdPrelimSelectedEO_PageIndexChanged"
                                            </asp:DataGrid>--%></div>
                                            </td>
                                            <td id="tdDivider" runat="server" width="2px" bgcolor="#0066ff">
                                            </td>
                                            <td width="748px" valign="top">
                                                <div id="division2" style="overflow: auto; width: 750px; height: 300px">
                                                    <table border="0" width="100%" cellpadding="0" cellspacing="5">
                                                        <tr>
                                                            <td width="10%" align="right">
                                                                <asp:Label ID="lblPlant" runat="server">Plant: </asp:Label>
                                                            </td>
                                                            <td width="25%">
                                                                <asp:Label ID="lblPlantVal" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="15%" align="right">
                                                                <asp:Label ID="lblEOModeType" runat="server">EO Type: </asp:Label>
                                                            </td>
                                                            <td width="25%">
                                                                <asp:Label ID="lblEOTypeVal" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <dx:ASPxGridView ID="dgdPrelimSelectedEO" KeyFieldName="EO_ID" Width="100%" runat="server"
                                                        AutoGenerateColumns="False" OnPageIndexChanged="dgdPrelimSelectedEO_PageIndexChanged">
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
                                                            <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Open as Read Only"
                                                                VisibleIndex="3">
                                                                <DataItemTemplate>
                                                                    <%--<asp:ImageButton ID="ImgReadOnlyEO" ToolTip="Open as Read Only" Style="cursor: pointer"
                                                                        OnCommand="ImgReadOnlyEO_Command" CommandArgument='<%#Eval("Current_Stage")%>'
                                                                        CommandName='<%#Eval("EO_ID")%>' runat="server" ImageUrl="../Images/actn037.gif">
                                                                    </asp:ImageButton>--%>
                                                                    <dx:ASPxButton Image-Url="../Images/actn037.gif" ID="ImgReadOnlyEO" OnCommand="ImgReadOnlyEO_Command"
                                                                        CommandArgument='<%#Eval("Current_Stage")%>' CommandName='<%#Eval("EO_ID")%>'
                                                                        ToolTip="Open as Read Only" Style="cursor: pointer" runat="server">
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                            <dx:GridViewDataColumn FieldName="Current_Stage" EditCellStyle-HorizontalAlign="Justify"
                                                                Width="20%" Caption="Current Stage" VisibleIndex="4" />
                                                            <dx:GridViewDataColumn FieldName="Stage_Status" EditCellStyle-HorizontalAlign="Justify"
                                                                Width="20%" Caption="Status" VisibleIndex="5" />
                                                            <dx:GridViewDataColumn FieldName="Plant_Name" EditCellStyle-HorizontalAlign="Justify"
                                                                Width="20%" Caption="Plant" VisibleIndex="6" />
                                                            <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Last Modified"
                                                                VisibleIndex="7">
                                                                <DataItemTemplate>
                                                                    <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypModifiedDate_Command"
                                                                        runat="server" ID="hypModifiedDate" Text='<%# Eval("Modified_Date")%>'>
                                                                    </asp:LinkButton>
                                                                    <asp:Label ID="lblISApprovar" runat="server" Visible="False" Text='<%# Eval("Is_Approver")%>'>
                                                                    </asp:Label>
                                                                </DataItemTemplate>
                                                            </dx:GridViewDataColumn>
                                                        </Columns>
                                                        <SettingsPager PageSize="10" Position="Bottom" NextPageButton-Image-ToolTip="Next"
                                                            PrevPageButton-Image-ToolTip="Previous">
                                                        </SettingsPager>
                                                        <Settings GridLines="None" />
                                                        <Styles>
                                                            <Header Font-Bold="true" BackColor="#FFCC00">
                                                            </Header>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                    <%--<asp:datagrid id="dgdPrelimSelectedEO" runat="server" BorderWidth="1px" GridLines="None" Width="100%"
														HeaderStyle-CssClass="subHeader" AutoGenerateColumns="False" BorderColor="Black" DataKeyField="EO_ID"
														AllowPaging="True" CellSpacing="2" AllowSorting="True">
														<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" CssClass="AlternateRow1"></ItemStyle>
														<HeaderStyle Wrap="False" CssClass="subHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn SortExpression="EO_Number" HeaderText="EO Num">
																<HeaderStyle Wrap="False"></HeaderStyle>
																<ItemTemplate>
																	<asp:Label ID="lblEOID" Runat=server Visible=False text='<%#Eval("EO_ID")%>'>
																	</asp:Label>
																	<asp:LinkButton CommandName="EONum_Link" Runat =server ID=hypEONumber text='<%#Eval("EO_Number")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="EO_Title" HeaderText="EO Title">
																<HeaderStyle Wrap="False"></HeaderStyle>
																<ItemTemplate>
																	<asp:LinkButton CommandName ="EOTitle_Link" Runat=server ID =hypEOTitle text='<%#Eval("EO_Title")%>'>
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
																	<asp:LinkButton CommandName="ModifiedDate_Link" Runat=server ID=hypModifiedDate text='<%#Eval("Modified_Date")%>'>
																	</asp:LinkButton>
																	<asp:Label ID="lblISApprovar" Runat=server Visible=False text='<%#Eval("Is_Approver")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Left"></PagerStyle>
													</asp:datagrid>--%></div>
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
