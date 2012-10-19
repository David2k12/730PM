<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjEventsResults.aspx.cs"
    Inherits="MUREOUI.Common.ProjEventsResults" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/LeftNavigationControl.ascx" TagName="LeftNavigationControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProjEventsResults</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
    </script>
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
                            <uc3:LeftNavigationControl ID="LeftNavigationControl1" runat="server" />
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
                                        <asp:ImageButton ID="imgClose" runat="server" AlternateText="Back" ImageUrl="../Images/Back.gif"
                                            OnClick="imgClose_Click"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="FormFields">
                                        <div id="divTest" style="overflow: auto; width: 100%; height: 300px">
                                            <dx:ASPxGridView ID="dgdSearchProject" runat="server" GridLines="None" HeaderStyle-CssClass="subHeader"
                                                AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanged="dgdSearchProject_PageIndexChanged">
                                                <Columns>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Project Name" HeaderStyle-Wrap="True"
                                                        VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Project Name
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Visible="False" ID="lblEOId" Text=' <%# String.Format("EO_id : {0} ", Eval("EO_id"))%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="False" ID="lblEONum" Text=' <%# String.Format("EO_Number : {0} ", Eval("EO_Number"))%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="False" ID="lblPrjId" Text=' <%# String.Format("Project_Id : {0} ", Eval("Project_Id"))%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="True" ID="lblPrjName" Text='<%#Eval("Project_Name")%>' runat="server">
                                                            </dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Project Lead" HeaderStyle-Wrap="True"
                                                        VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Project Lead
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Visible="True" ID="lblPrjLead" Text='<%#Eval("Project_Lead")%>' runat="server">
                                                            </dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Event Name" HeaderStyle-Wrap="True"
                                                        VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Event Name
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Visible="False" ID="lblEventId" Text=' <%# String.Format("Event_Id : {0} ", Eval("Event_Id"))%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="True" ID="lblEventName" Text='<%#Eval("Event_Name")%>' runat="server">
                                                            </dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Plant Name" HeaderStyle-Wrap="True"
                                                        VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                        <CellStyle HorizontalAlign="Left">
                                                        </CellStyle>
                                                        <HeaderCaptionTemplate>
                                                            Plant Name
                                                        </HeaderCaptionTemplate>
                                                        <DataItemTemplate>
                                                            <dx:ASPxLabel Visible="False" ID="lblPlantId" Text=' <%# String.Format("Plant_Id : {0} ", Eval("Plant_Id"))%>'
                                                                runat="server">
                                                            </dx:ASPxLabel>
                                                            <dx:ASPxLabel Visible="True" ID="lblPlantName" Text='<%#Eval("Plant_Name")%>' runat="server">
                                                            </dx:ASPxLabel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <SettingsPager NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous" PageSize="20" Position="Bottom" Visible="true" Summary-Position="Inside"
                                                    Summary-Visible="True">
                                                </SettingsPager>
                                                <Styles>
                                                    <Header BackColor="#FFCC00" Font-Bold="true">
                                                    </Header>
                                                </Styles>
                                            </dx:ASPxGridView>
                                            <asp:Label ID="lblSearhcResult" runat="server">No record(s) found in the database.</asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        &nbsp;
                                        <asp:ImageButton ID="imgPrevious" Visible="false" runat="server" ImageUrl="../Images/previous-Page.gif"
                                            CommandArgument="Prev" OnClick="PagerButtonClick"></asp:ImageButton>&nbsp;
                                        <asp:ImageButton ID="imgNext" Visible="false" runat="server" ImageUrl="../Images/next-Page.gif"
                                            CommandArgument="Next" OnClick="PagerButtonClick"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
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
