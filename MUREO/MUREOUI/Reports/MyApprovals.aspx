<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyApprovals.aspx.cs" Inherits="MUREOUI.Reports.MyApprovals" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MyApprovals</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        //Screen Resolution code

        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="mainTable" width="100%">
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="innerTable1" width="100%">
                    <tr>
                        <td valign="top" width="80%">
                            <table id="innerTable2" width="100%">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" valign="top">
                                        My Approvals/Concurrences
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ImageButton ID="imgCreateEO" runat="server" AlternateText="Create a New EO" ToolTip="Create a New EO"
                                            ImageUrl="../Images/create-eo.gif" onclick="imgCreateEO_Click"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <div id="divTest" style="overflow: auto; width: 995px; height: 330px">
                                            <dx:ASPxGridView ID="dgdAprvlConcurrencenew" runat="server" 
                                                KeyFieldName="EO_ID" onhtmlrowprepared="dgdAprvlConcurrencenew_HtmlRowPrepared" 
                                                onpageindexchanged="dgdAprvlConcurrencenew_PageIndexChanged">
                                                <Columns>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="EO Num" HeaderStyle-Wrap="True"
                                                        VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                          EO Num
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <asp:Label Visible="False" ID="lblEOID" runat="server" Text='<%#Eval("EO_ID")%>'> </asp:Label>
                                                            <asp:LinkButton CommandName='<%#Eval("EO_ID")%>' CommandArgument='<%# Eval("Current_Stage") %>' OnCommand="EONumLink_Command" runat="server" ID="hypEONumber" Text='<%#Eval("EO_Number")%>'>
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" FieldName="Originator" Caption="Originator"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="2">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="EO Title" HeaderStyle-Wrap="True"
                                                        VisibleIndex="3" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            EO Title
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <asp:LinkButton CommandName='<%#Eval("EO_ID")%>'  CommandArgument='<%# Eval("Current_Stage") %>' OnCommand="EOTitleLink_Command" runat="server" ID="hypEOTitle" Text='<%#Eval("EO_Title")%>'>
                                                            </asp:LinkButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Check Approvals"
                                                        HeaderStyle-Wrap="True" VisibleIndex="4" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Check Approvals
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <asp:ImageButton ID="imgCheckApproval" CommandName='<%#Eval("EO_ID")%>' CommandArgument='<%# Eval("Current_Stage") %>' runat="server" OnCommand="imgCheckApproval_Click"
                                                                ImageUrl="../Images/actn045.gif"></asp:ImageButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Open as Read Only"
                                                        HeaderStyle-Wrap="True" VisibleIndex="5" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Open as Read Only
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <asp:ImageButton ID="ImgReadOnlyEO" CommandName='<%#Eval("EO_ID")%>' CommandArgument='<%# Eval("Current_Stage") %>' OnCommand="ImgReadOnlyEO_Click"
                                                                runat="server" ImageUrl="../Images/actn037.gif"></asp:ImageButton>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" FieldName="Current_Stage" Caption="Current Stage"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="6">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" FieldName="Stage_Status" Caption="Status"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="7">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" FieldName="Brand_Segment_Name" Caption="Brand"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="8">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" FieldName="Plant_Name" Caption="Plant"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="9">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Visible="true" FieldName="Modified_Date" Caption="Last Modified"
                                                        FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="10">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager PageSize="20" Position="Bottom">
                                                </SettingsPager>
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
        <tr>
            <td>
                <uc2:FooterControl ID="FooterControl1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
