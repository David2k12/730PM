<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConcurrenceStatus.aspx.cs"
    Inherits="MUREOUI.Reports.ConcurrenceStatus" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ConcurrenceStatus</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">

        function NavigateEOExport() {
            window.open('../Common/EOExport.aspx', 'EOExport', 'top=250,left=300,width=350,height=200,menubar=no,resizable=no');
        }
        function NavigateSpecificEO() {
            window.open('../Reports/GotoEO.aspx', 'GotoEO', 'top=250,left=300,width=500,height=150,menubar=no,resizable=no');
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
<body>
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
                                <!--	<TD vAlign="top" align="left" width="20%"><uc1:leftnavigationcontrol id="LeftNavigationControl" runat="server"></uc1:leftnavigationcontrol>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD vAlign="top" align="center" width="80%">-->
                                <td valign="top">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="middle" align="center" colspan="5">
                                                <!--	<table id="tbl3" cellpadding="0" cellspacing="0" width="90%" style="BORDER-RIGHT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-BOTTOM: #898989 1px solid">
												<tr>
													<td colspan="6" bgcolor="#f8f8f8" align="center">-->
                                                <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr valign="middle" bgcolor="#ffffcc">
                                                        <td style="height: 27px" align="center" colspan="5">
                                                            <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                            </font>
                                                            <div>
                                                                <strong class="FormHeader">Concurrence Status</strong></div>
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td class="DataGridBorderColor" style="height: 67px" align="center">
                                                            <p>
                                                                <asp:ImageButton ID="imgCreateEO" runat="server" ImageUrl="../Images/create-eo.gif"
                                                                    OnClick="imgCreateEO_Click"></asp:ImageButton>&nbsp;<asp:ImageButton ID="imgExpandAll"
                                                                        runat="server" ImageUrl="../Images/expandall.gif" OnClick="imgExpandAll_Click">
                                                                </asp:ImageButton>&nbsp;
                                                                <asp:ImageButton ID="imgCollapseAll" runat="server" ImageUrl="../Images/collpaseall.gif"
                                                                    OnClick="imgCollapseAll_Click"></asp:ImageButton>&nbsp;
                                                                <asp:ImageButton ID="imgGotoEO" runat="server" ImageUrl="../Images/goto-eo.gif">
                                                                </asp:ImageButton>&nbsp;
                                                                <asp:ImageButton ID="imgExport" runat="server" ImageUrl="../Images/opendata-export-page.gif">
                                                                </asp:ImageButton>&nbsp;
                                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../Images/search.gif"
                                                                    OnClick="ImageButton3_Click"></asp:ImageButton><!--	<asp:imagebutton id="imgExpand" runat="server" ImageUrl="../Images/expandall.gif"></asp:imagebutton>&nbsp;&nbsp;
																		<asp:imagebutton id="imgCollapse" runat="server" ImageUrl="../Images/collpaseall.gif"></asp:imagebutton> --></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table id="tblSplit" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="1%">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="top" align="left" width="40%">
                                                                        <div style="overflow: auto; width: 330px; height: 300px">
                                                                            <%--<asp:datagrid id="dgdStatus" runat="server" PageSize="12" BorderColor="Black" AutoGenerateColumns="False"
																				HeaderStyle-CssClass="SubHeader" Width="100%" GridLines="None" BorderWidth="1px">
																				<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderText="Status">
																						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																						<ItemStyle Wrap="False"></ItemStyle>
																						<ItemTemplate>
																							<asp:ImageButton Runat="server" ID="imgStatusExpand" CommandName="StatusExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																							<asp:ImageButton Runat="server" ID="imgStatusCollapse" CommandName="StatusCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																							<asp:Label ID="lblEOID" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"EO_ID")%>' Visible="False">
																							</asp:Label>
																							<asp:Label ID="lblStatus" Runat="server" text='<%# DataBinder.Eval(Container.Dataitem,"Status")%>'>
																							</asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="EO Details">
																						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																						<ItemStyle Wrap="False"></ItemStyle>
																						<ItemTemplate>
																							<asp:ImageButton Runat="server" ID="imgEO1" CommandName="EOExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																							<asp:ImageButton Runat="server" ID="imgEO2" CommandName="EOCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																							<asp:Linkbutton ID="lnkEO" Runat="server" CommandName="View_EO" CommandArgument ='<%# DataBinder.Eval(Container.Dataitem,"EO_ID")%>' text='<%# DataBinder.Eval(Container.Dataitem,"EO")%>'>
																							</asp:Linkbutton>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																			</asp:datagrid>--%>
                                                                            <dx:ASPxGridView ID="dgdStatus" KeyFieldName="EO_ID" Width="100%" runat="server"
                                                                                AutoGenerateColumns="False" OnHtmlRowPrepared="dgdStatus_HtmlRowPrepared">
                                                                                <Columns>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Status"
                                                                                        VisibleIndex="1">
                                                                                        <DataItemTemplate>
                                                                                            <asp:ImageButton runat="server" ID="imgStatusExpand" OnCommand="imgStatusExpand_Command"
                                                                                                CommandName="StatusExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                            <asp:ImageButton runat="server" ID="imgStatusCollapse" OnCommand="imgStatusCollapse_Command"
                                                                                                CommandName="StatusCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                            <asp:Label ID="lblEOID" runat="server" Text='<%# Eval("EO_ID")%>' Visible="false">
                                                                                            </asp:Label>
                                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="EO Details"
                                                                                        VisibleIndex="2">
                                                                                        <DataItemTemplate>
                                                                                            <asp:ImageButton EO='<%# Eval("EO")%>' CommandName='<%# Eval("Status")%>' CommandArgument='<%# Eval("EO_ID")%>'
                                                                                                runat="server" ID="imgEO1" OnCommand="imgEO1_Command" ImageUrl="../Images/arrow1.gif">
                                                                                            </asp:ImageButton>
                                                                                            <asp:ImageButton OnCommand="imgEO2_Command" runat="server" ID="imgEO2" CommandName="EOCollapse"
                                                                                                ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                            <asp:LinkButton ID="lnkEO" runat="server" OnCommand="lnkEO_Command" CommandName='<%# Eval("Status")%>'
                                                                                                CommandArgument='<%# Eval("EO_ID")%>' Text='<%# Eval("EO")%>'>
                                                                                            </asp:LinkButton>
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
                                                                    <td width="1%" bgcolor="#0066ff" id="bar" runat="server">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="top" align="left">
                                                                        <asp:ImageButton ID="imgReadOnly" ImageUrl="../Images/actn037.gif" Visible="False"
                                                                            runat="server"></asp:ImageButton>&nbsp;
                                                                    </td>
                                                                    <td valign="top" align="left" width="100%">
                                                                        <div style="overflow: auto; width: 100%; height: 400px">
                                                                            <asp:Label ID="lblEOHead" Visible="False" runat="server">EO: </asp:Label><asp:Label
                                                                                ID="lblEOdisp" Visible="False" runat="server"></asp:Label><asp:Label ID="lbEOID"
                                                                                    runat="server" Visible="False"></asp:Label><br>
                                                                            <dx:ASPxGridView ID="dgdEODetails" KeyFieldName="Email_Sent" Width="100%" runat="server"
                                                                                AutoGenerateColumns="False">
                                                                                <Columns>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Email Sent"
                                                                                        VisibleIndex="0">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email_Sent_Date") + " " +Eval("Email_Sent")%>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="User Name"
                                                                                        VisibleIndex="1">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblUser" runat="server" Text='<%# Eval("User_Name") %>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                    <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Response"
                                                                                        VisibleIndex="4">
                                                                                        <DataItemTemplate>
                                                                                            <asp:Label ID="lblRespond" runat="server" Text='<%# Eval("Is_Responded") %>'>
                                                                                            </asp:Label>
                                                                                        </DataItemTemplate>
                                                                                    </dx:GridViewDataColumn>
                                                                                </Columns>
                                                                                <SettingsPager PageSize="20" Position="Bottom" NextPageButton-Image-ToolTip="Next"
                                                                                    PrevPageButton-Image-ToolTip="Previous">
                                                                                </SettingsPager>
                                                                                <Settings GridLines="None" />
                                                                                <Styles>
                                                                                    <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                    </Header>
                                                                                </Styles>
                                                                            </dx:ASPxGridView>
                                                                        </div>
                                                                    </td>
                                                                    <td width="2%">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
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
    <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="popupControl">
                 <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
