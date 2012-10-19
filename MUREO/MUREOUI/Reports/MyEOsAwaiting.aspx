<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyEOsAwaiting.aspx.cs"
    Inherits="MUREOUI.Reports.MyEOsAwaiting" %>

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
    <title>MyEOsAwaiting</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
    </script>
</head>
<body onload="setScreenRes();">
    <form id="Form1" method="post" runat="server">
    <table id="mainTable" cellspacing="0" cellpadding="0" width="100%" height="100%">
        <tr>
            <td valign="top">
                <HeadControl:HeaderControl ID="Headercontrol1" runat="server"></HeadControl:HeaderControl>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table id="innerTable1" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td valign="top" width="80%">
                            <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" valign="top">
                                        My Site Tests Awaiting Close-Out
                                    </td>
                                </tr>
                                <tr height="8">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ImageButton ID="imgCreateEO" runat="server" AlternateText="Create a New EO"
                                            ImageUrl="../Images/create-eo.gif" OnClick="imgCreateEO_Click"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr height="8">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <div id="divTest" style="overflow: auto; width: 98%; height: 330px">
                                            <%--  <asp:datagrid id="dgdMyEOsAwaiting" runat="server" BorderColor="Black" AutoGenerateColumns="False"
														HeaderStyle-CssClass="subHeader" Width="100%" GridLines="None" BorderWidth="1px" AllowPaging="True" DataKeyField="EO_ID" OnItemCommand="DisplayBoundColumnValues"
														cellspacing="2" AllowSorting="True">
														<AlternatingItemStyle CssClass="Alternaterow2"></AlternatingItemStyle>
														<ItemStyle CssClass="AlternateRow1"></ItemStyle>
														<HeaderStyle CssClass="subHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn SortExpression="EO_Number" HeaderText="EO Num">
																<ItemTemplate>
																	<asp:Label ID="lblEOID" Runat=server Visible=False text='<%#DataBinder.Eval(Container.Dataitem,"EO_ID")%>'>
																	</asp:Label>
																	<asp:LinkButton CommandName="EONum_Link" Runat =server ID=hypEONumber text='<%# DataBinder.Eval(Container.DataItem,"EO_Number")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Originator" SortExpression="Originator" HeaderText="Originator"></asp:BoundColumn>
															<asp:TemplateColumn SortExpression="EO_Title" HeaderText="EO Title">
																<ItemTemplate>
																	<asp:LinkButton CommandName ="EOTitle_Link" Runat=server ID =hypEOTitle text='<%# DataBinder.Eval(Container.DataItem,"EO_Title")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Open as Read Only">
																<ItemTemplate>
																	<asp:ImageButton id="ImgReadOnlyEO" CommandName="ReadOnly" Runat="server" ImageUrl="../Images/actn037.gif"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Current_Stage" HeaderText="Current Stage"></asp:BoundColumn>
															<asp:BoundColumn DataField="Status" SortExpression="Stage_Status" HeaderText="Status"></asp:BoundColumn>
															<asp:BoundColumn DataField="Brand_Segment_Name" SortExpression="Brand_Segment_Name" HeaderText="Brand"></asp:BoundColumn>
															<asp:BoundColumn DataField="Plant_Name" SortExpression="Plant_Name" HeaderText="Plant"></asp:BoundColumn>
															<asp:BoundColumn DataField="Modified_Date" SortExpression="Modified_Date" HeaderText="Last Modified"></asp:BoundColumn>
														</Columns>
														<PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Center"></PagerStyle>
													</asp:datagrid>--%>
                                            <dx:ASPxGridView ID="dgdMyEOsAwaiting" KeyFieldName="EO_ID" Width="100%" runat="server"
                                                AutoGenerateColumns="False" OnPageIndexChanged="dgdMyEOsAwaiting_PageIndexChanged">
                                                <Columns>
                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="EO Num" VisibleIndex="0">
                                                        <DataItemTemplate>
                                                            <asp:Label ID="lblEOID" runat="server" Visible="false" Text='<%# Eval("EO_ID")%>'>
                                                            </asp:Label>
                                                            <asp:LinkButton CommandArgument='<%# Eval("Current_Stage")%>' CommandName='<%# Eval("EO_ID") %>'
                                                                runat="server" OnCommand="hypEONumber_Command" ID="hypEONumber" Text='<%# Eval("EO_Number")%>'>
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn FieldName="Originator" EditCellStyle-HorizontalAlign="Justify"
                                                        Caption="Originator" VisibleIndex="1" />
                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="EO Title"
                                                        VisibleIndex="2">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                OnCommand="hypEOTitle_Command" runat="server" ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Open as Read Only"
                                                        VisibleIndex="3">
                                                        <DataItemTemplate>
                                                            <asp:ImageButton ID="ImgReadOnlyEO" OnCommand="ImgReadOnlyEO_Command" CommandArgument='<%#Eval("Current_Stage")%>'
                                                                CommandName='<%#Eval("EO_ID")%>' runat="server" ImageUrl="../Images/actn037.gif">
                                                            </asp:ImageButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Current Stage"
                                                        VisibleIndex="4">
                                                        <DataItemTemplate>
                                                            <asp:Label ID="lblCurrentStage" Text='<%# Eval("Current_Stage") %>' runat="server" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Status" VisibleIndex="5">
                                                        <DataItemTemplate>
                                                            <asp:Label ID="lblStageStatus" Text='<%# Eval("Status") %>' runat="server" />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn FieldName="Brand_Segment_Name" EditCellStyle-HorizontalAlign="Justify"
                                                        Caption="Brand" VisibleIndex="6" />
                                                    <dx:GridViewDataColumn FieldName="Plant_Name" EditCellStyle-HorizontalAlign="Justify"
                                                        Caption="Plant" VisibleIndex="7" />
                                                    <%-- <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Last Modified"
                                                        VisibleIndex="8">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' OnCommand="hypModifiedDate_Command"
                                                                runat="server" ID="hypModifiedDate" Text='<%# Eval("Modified_Date")%>'>
                                                            </asp:LinkButton>
                                                            <asp:Label ID="lblISApprovar" runat="server" Visible="False" Text='<%# Eval("Is_Approver")%>'>
                                                            </asp:Label>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>--%>
                                                    <dx:GridViewDataColumn FieldName="Modified_Date" EditCellStyle-HorizontalAlign="Justify"
                                                        Caption="Last Modified" VisibleIndex="7" />
                                                </Columns>
                                                <SettingsPager PageSize="20" Position="Bottom">
                                                </SettingsPager>
                                                <Styles>
                                                    <Header HorizontalAlign="Center" BackColor="#FFCC00" Font-Bold="true">
                                                    </Header>
                                                </Styles>
                                            </dx:ASPxGridView>
                                        </div>
                                        <%--<p align="center"><asp:imagebutton id="imgPrevious"  runat="server" AlternateText="Previous"
														ImageUrl="../Images/previous-Page.gif" CommandArgument="Prev"></asp:imagebutton>&nbsp;&nbsp;
													<asp:imagebutton id="imgNext" runat="server" AlternateText="Next" ImageUrl="../Images/next-Page.gif"
														CommandArgument="Next"></asp:imagebutton></p>--%>
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
                <FootControl:FooterControl ID="Footercontrol1" runat="server"></FootControl:FooterControl>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
