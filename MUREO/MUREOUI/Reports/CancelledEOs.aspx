<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelledEOs.aspx.cs" Inherits="MUREOUI.Reports.CancelledEOs" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>CancelledEOs</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function confirmReactivate() {
            if (!confirm('Are you sure you want to reactivate this EO?')) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table id="mainTable" cellspacing="0" cellpadding="0" width="100%" style="height: 80px">
        <tr style="height: 20px">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="innerTable1" style="height: 80px" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <%--<td vAlign="top" width="20%"><NAVIGATIONCONTROL:LEFTNAVIGATIONCONTROL id="LeftNavigationControl" runat="server"></NAVIGATIONCONTROL:LEFTNAVIGATIONCONTROL></td>--%>
                        <td valign="top" width="80%">
                            <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%" style="height: 80px">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" valign="top">
                                        Maintain Cancelled EOs
                                    </td>
                                </tr>
                                <tr height="8">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ImageButton ID="imgCreateEO" runat="server" AlternateText="Create a New EO"
                                            ImageUrl="../Images/create-eo.gif"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr height="8">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <div style="overflow: auto; width: 995px; height: 325px">
                                            <%-- <asp:datagrid id="dgdCancelledEO" runat="server" AllowSorting="True" BorderWidth="1px" BorderColor="Black"
														DataKeyField="EO_ID" Width="100%" HeaderStyle-CssClass="subHeader" GridLines="None" AutoGenerateColumns="False" OnItemCommand="DisplayBoundColumnValues"
														AllowPaging="True" CellSpacing="2">
														<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
														<ItemStyle CssClass="AlternateRow1"></ItemStyle>
														<HeaderStyle CssClass="subHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn SortExpression="EO_Number" HeaderText="EO #">
																<ItemTemplate>
																	<asp:Label ID="lblEOID" Runat=server Visible=false text='<%#Eval("EO_ID")%>'>
																	</asp:Label>
																	<asp:LinkButton CommandName="EONum_Link" Runat =server ID=hypEONumber text='<%# Eval("EO_Number")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="EO_Title" HeaderText="EO Title">
																<ItemTemplate>
																	<asp:LinkButton CommandName ="EOTitle_Link" Runat=server ID ="hypEOTitle" text='<%# Eval("EO_Title")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="EO_Title" HeaderText="Originator">
																<ItemTemplate>
																	<asp:Label  Runat=server ID ="lblOriginator" text='<%# Eval("Originator")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															
															<asp:BoundColumn DataField="Current_Stage" SortExpression="Current_Stage" HeaderText="Current Stage"></asp:BoundColumn>
															<asp:BoundColumn DataField="S_C_D_Status" SortExpression="S_C_D_Status" HeaderText="Status"></asp:BoundColumn>
															<asp:BoundColumn DataField="Brand_Segment_Name" SortExpression="Brand_Segment_Name" HeaderText="Brand"></asp:BoundColumn>
															<asp:BoundColumn DataField="Plant_Name" SortExpression="Plant_Name" HeaderText="Plant"></asp:BoundColumn>
															<asp:TemplateColumn SortExpression="Modified_Date" HeaderText="Last Modified">
																<ItemTemplate>
																	<asp:LinkButton CommandName="ModifiedDate_Link" Runat=server ID=hypModifiedDate text='<%# Eval("Modified_Date")%>'>
																	</asp:LinkButton>
																	<asp:Label ID="lblISApprovar" Runat=server Visible=False text='<%#Eval("Is_Approver")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Center" PageButtonCount="1"></PagerStyle>
													</asp:datagrid>--%>
                                            <dx:ASPxGridView ID="dgdCancelledEO" runat="server" AllowSorting="True" Width="100%"
                                                HeaderStyle-CssClass="subHeader" GridLines="None" AutoGenerateColumns="False"
                                                CssClass="SubHeader" AllowPaging="True" CellSpacing="2" ClientIDMode="AutoID"
                                                OnPageIndexChanged="dgdCancelledEO_PageIndexChanged">
                                                <Columns>
                                                    <dx:GridViewDataColumn Caption="EO" VisibleIndex="1" Width="15%">
                                                        <DataItemTemplate>
                                                            <%--<asp:Label ID="lblEOID" Runat="server" Visible="false" text='<%#Eval("EO_ID")%>'>
																	</asp:Label>--%>
                                                            <asp:LinkButton CommandName='<%# Eval("EO_ID") %>' CurrentStage='<%# Eval("Current_Stage") %>'
                                                                OnCommand='EONum_Link_Command' runat="server" ID="hypEONumber" Text='<%# Eval("EO_Number")%>'>
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="EO Title" VisibleIndex="2" Width="15%">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton CommandName='<%# Eval("EO_ID") %>' CurrentStage='<%# Eval("Current_Stage") %>'
                                                                OnCommand="EOTitle_Link_Command" runat="server" ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="Originator" VisibleIndex="3" Width="15%">
                                                        <DataItemTemplate>
                                                           <%-- <asp:LinkButton CommandName='<%# Eval("EO_ID") %>' CurrentStage='<%# Eval("Current_Stage") %>'
                                                                OnCommand="hypModifiedDate_Command" runat="server" ID="hypModifiedDate" Text='<%# Eval("Modified_Date")%>'>
                                                            </asp:LinkButton>--%>
                                                            <asp:Label runat="server" ID="lblOriginator" Text='<%# Eval("Originator") %>'>
                                                            </asp:Label>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn FieldName="Current_Stage" Caption="Current Stage" VisibleIndex="4" />
                                                    <dx:GridViewDataColumn FieldName="S_C_D_Status" Caption="Status" VisibleIndex="5" />
                                                    <dx:GridViewDataColumn FieldName="Brand_Segment_Name" Caption="Brand" Visible="False"
                                                        VisibleIndex="6" />
                                                    <dx:GridViewDataColumn FieldName="Plant_Name" Caption="Plant" VisibleIndex="7" />
                                                    <dx:GridViewDataColumn Caption="Last Modified" VisibleIndex="8" Width="15%">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton ID="Linkbutton1" CommandName='<%# Eval("EO_ID") %>' CurrentStage='<%# Eval("Current_Stage") %>'
                                                                OnCommand="hypModifiedDate_Command" runat="server">
																									<%# Eval("Modified_Date")%>
                                                            </asp:LinkButton>
                                                            <asp:Label ID="lblISApprovar" runat="server" Visible="False" Text='<%# Eval("Is_Approver")%>'>
                                                            </asp:Label>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <SettingsPager PageSize="10" Position="Bottom" NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous">
                                                </SettingsPager>
                                                <Settings GridLines="Horizontal" />
                                                <Styles>
                                                    <Header Font-Bold="true" BackColor="#FFCC00">
                                                    </Header>
                                                </Styles>
                                            </dx:ASPxGridView>
                                            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:mureoConnectionString %>" 
                                                        SelectCommand="GET_EO_S_C_D_Status" SelectCommandType="StoredProcedure">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="Cc" Name="p_S_C_D_Status" Type="String" />
                                                            <asp:Parameter DefaultValue="Surendra Bolla-SU" Name="p_User_Name" 
                                                                Type="String" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>--%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <tr>
                                <td>
                                    <uc2:FooterControl ID="FooterControl1" runat="server" />
                                </td>
                            </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
