<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuzzyResults.aspx.cs" Inherits="MUREOUI.Common.FuzzyResults" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/LeftNavigationControl.ascx" TagName="LeftNavigationControl"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc3" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FuzzyResults</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table id="mainTable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="innerTable1" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td valign="top" width="20%">
                            <uc2:LeftNavigationControl ID="LeftNavigationControl1" runat="server" />
                        </td>
                        <td valign="top" width="80%">
                            <table id="MainTable" width="100%" border="0">
                                <tr>
                                    <td class="FormHeader">
                                        <b>Search Results</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        &nbsp;
                                        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/Back.gif" AlternateText="Back"
                                            OnClick="imgClose_Click"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="FormFields" align="left">
                                        <asp:Label ID="lblSearhcResult" runat="server">No record(s) found in the database.</asp:Label>
                                        <div  style="overflow:scroll;width:800px;height:400px">
                                            <dx:ASPxGridView ID="dgdFuzzyResultsnew" width="1000px" runat="server" OnHtmlRowPrepared="dgdFuzzyResultsnew_HtmlRowPrepared"
                                                OnPageIndexChanged="dgdFuzzyResultsnew_PageIndexChanged1" KeyFieldName="EO_ID" HeaderStyle-CssClass="subHeader">
                                                <Columns>
                                                    <dx:GridViewDataColumn width="300px" CellStyle-HorizontalAlign="Left" Caption="EO Title" HeaderStyle-Wrap="True"
                                                        VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            EO Title
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Visible="False" ID="lblEOId" runat="server" Text=' <%# String.Format("EO_id : {0} ", Eval("EO_ID"))%>'>
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="true" ID="lblEONum" runat="server" Text='<%#Eval("EO_Title")%>'>
                                                            </dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" width="200px" Caption="Open as Read Only"
                                                        HeaderStyle-Wrap="True" VisibleIndex="2" FixedStyle="Left" Settings-AllowSort="True">                                                      
                                                        <HeaderCaptionTemplate>
                                                            Open as Read Only
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <asp:ImageButton ID="ImgReadOnlyEO" style="cursor:pointer" ToolTip="Open as Read Only" OnCommand="ReadOnly_Click" CommandName="ReadOnly"
                                                                runat="server" ImageUrl="../Images/actn037.gif"></asp:ImageButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn width="200px" CellStyle-HorizontalAlign="Left" Caption="Email Sent" HeaderStyle-Wrap="True"
                                                        VisibleIndex="3" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Email Sent
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Visible="true" ID="lblEOEmailSentDate" Text='<%#Eval("EO_Title")%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="true" ID="lblEOEmailSentTo" Text='<%#Eval("Email_Sent")%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataTextColumn width="200px" Visible="true" FieldName="User_Name" Caption="User Name"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="4">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn width="100px" Visible="true" FieldName="Is_Responded" Caption="Response"
                                                        VisibleIndex="5" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager PageSize="10" Position="Bottom">
                                                </SettingsPager>
                                                <Styles>
                                                    <Header Font-Bold="true" BackColor="#FFCC00">
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
        <tr>
            <td>
                <uc3:FooterControl ID="FooterControl1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
