<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="ArchivedEOs.aspx.cs"
    Inherits="MUREOUI.Reports.ArchivedEOs" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ArchivedEOs</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function setScreenRes() {
            document.getElementById("division1").style.height = (screen.height - 440); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            document.getElementById("division2").style.height = (screen.height - 480); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            if (screen.width == 1024) {
                document.getElementById("division1").style.width = (screen.width - 680);
                document.getElementById("division2").style.width = (screen.width - 380);
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
<body onload="setScreenRes();">
    <form id="Form1" method="post" runat="server">
    <table id="maintbl" cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
        <tr>
            <td valign="top">
                <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" align="center">
                            <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                <tr valign="middle" style="background-color: #ffffcc">
                                    <td class="FormHeader" align="center" colspan="5">
                                        Archived EOs/Site Tests
                                    </td>
                                </tr>
                                <tr height="10">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ImageButton ID="imgCreateNewEO" runat="server" ImageUrl="../Images/create-eo.gif"
                                            AlternateText="Click to create a new FYI" OnClick="imgCreateNewEO_Click"></asp:ImageButton>&nbsp;&nbsp;&nbsp;<asp:ImageButton
                                                ID="imgExpnadAll" runat="server" ImageUrl="../Images/expandall.gif" OnClick="imgExpnadAll_Click">
                                            </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="imgCollapseAll" runat="server" ImageUrl="../Images/collpaseall.gif"
                                            AlternateText="Collapse All" OnClick="imgCollapseAll_Click"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr height="10">
                                    <td align="center">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table id="innertable" border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="20px">
                                                    &nbsp;
                                                </td>
                                                <td valign="top" align="left" width="240px">
                                                    <div id="division1" style="overflow: auto; width: 250PX; height: 300px">
                                                        <dx:ASPxGridView ID="dgdArchivedEOs" KeyFieldName="Plant_ID" Width="100%" runat="server"
                                                            AutoGenerateColumns="false" OnHtmlRowPrepared="dgdArchivedEOs_HtmlRowPrepared"
                                                            OnPageIndexChanged="dgdArchivedEOs_PageIndexChanged">
                                                            <Columns>
                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Plant" VisibleIndex="1">
                                                                    <DataItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="imgPlant1" OnCommand="imgPlant1_Command" CommandArgument='<%#Eval("Plant_ID")%>'
                                                                            CommandName='<%#Eval("EO_Mode")%>' ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                        <asp:ImageButton runat="server" ID="imgPlant2" CommandName="PlantNameCollapse" ImageUrl="../Images/arrow_down1.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:Label ID="lblPlantID" Visible="false" runat="server" Text='<%# Eval("Plant_ID")%>'>
                                                                        </asp:Label>
                                                                        <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                        </asp:Label>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="Stage" VisibleIndex="2">
                                                                    <DataItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="imgStage1" OnCommand="imgStage1_Command" CommandName="StageExpand"
                                                                            ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                        <asp:ImageButton runat="server" ID="imgStage2" OnCommand="imgStage2_Command" CommandName="StageCollpase"
                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                        <asp:Label ID="lblStage" runat="server" Text='<%# Eval("Stage_Status")%>'>
                                                                        </asp:Label>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="EO Type"
                                                                    VisibleIndex="3">
                                                                    <DataItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="imgEOMode1" OnCommand="imgEOMode1_Command" CommandArgument='<%#Eval("Plant_ID")%>'
                                                                            CommandName='<%# Eval("EO_Mode")%>' ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                        <asp:ImageButton runat="server" ID="imgEOMode2" OnCommand="imgEOMode2_Command" CommandName="EOModeCollpase"
                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                        <asp:Label ID="lblPlanID" runat="server" Visible="false" Text='<%# Eval("Plant_ID")%>'>
                                                                        </asp:Label>
                                                                        <asp:Label ID="lblEOMode" runat="server" Text='<%# Eval("EO_Mode")%>'>
                                                                        </asp:Label>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                            </Columns>
                                                            <SettingsPager mode="ShowAllRecords">
                                                            </SettingsPager>
                                                            <Settings GridLines="None" />
                                                            <Styles>
                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                </Header>
                                                            </Styles>
                                                        </dx:ASPxGridView>
                                                    </div>
                                                </td>
                                                <td id="tdDivider" runat="server" width="5px" style="background-color: #0066ff">
                                                </td>
                                                <td valign="top" align="left" width="100%">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="15%" align="right">
                                                                <asp:Label ID="lblPlant" runat="server">Plant: </asp:Label>
                                                            </td>
                                                            <td width="15%">
                                                                <asp:Label ID="lblPlantNameVal" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="15%" align="right">
                                                                <asp:Label ID="lblStagelb" runat="server">Stage: </asp:Label>
                                                            </td>
                                                            <td width="15%">
                                                                <asp:Label ID="lblStageVal" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="15%" align="right">
                                                                <asp:Label ID="lblEOTypelb" runat="server">EO Type: </asp:Label>
                                                            </td>
                                                            <td width="15%">
                                                                <asp:Label ID="lblEOTypeVal" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div id="division2" style="overflow: auto; width: 100%; height: 300px">
                                                        <dx:ASPxGridView ID="dgdArchSelectedEO" KeyFieldName="EO_ID" Width="100%" runat="server"
                                                            AutoGenerateColumns="False" OnHtmlRowPrepared="dgdArchSelectedEO_HtmlRowPrepared">
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
                                                                    Caption="Originator" VisibleIndex="2" />
                                                                <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Caption="EO Title"
                                                                    VisibleIndex="1">
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
                                                                        <asp:Label ID="lblStageStatus" Text='<%# Eval("Stage_Status") %>' runat="server" />
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn FieldName="EO_Mode" EditCellStyle-HorizontalAlign="Justify"
                                                                    Caption="EO Type" VisibleIndex="6" />
                                                                <dx:GridViewDataColumn FieldName="Brand_Segment_Name" EditCellStyle-HorizontalAlign="Justify"
                                                                    Caption="Brand" VisibleIndex="7" />
                                                                <dx:GridViewDataColumn FieldName="Plant_Name" EditCellStyle-HorizontalAlign="Justify"
                                                                    Caption="Plant" VisibleIndex="8" />
                                                                <dx:GridViewDataColumn Caption="Last Modified" VisibleIndex="9">
                                                                    <DataItemTemplate>
                                                                        <asp:LinkButton OnCommand="hypModifiedDate_Command" CommandName='<%# Eval("EO_ID") %>'
                                                                            CommandArgument='<%# Eval("Current_Stage")%>' runat="server" ID="hypModifiedDate"
                                                                            Text='<%# Eval("Modified_Date")%>'>
                                                                        </asp:LinkButton>
                                                                        <asp:Label runat="server" ID="lblModiLink" Visible="False" Text='<%# Eval("Modified_Date")%>'>
                                                                        </asp:Label>
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                            </Columns>
                                                            <SettingsPager PageSize="20" Position="Bottom">
                                                            </SettingsPager>
                                                            <Styles>
                                                                <Header HorizontalAlign="Center" BackColor="#FFCC00" Font-Bold="true">
                                                                </Header>
                                                            </Styles>
                                                        </dx:ASPxGridView>
                                                    </div>
                                                    <%--<p align="center">
																		<asp:ImageButton id="imgPrevious" runat="server" AlternateText="Previous" ImageUrl="../Images/previous-Page.gif"
																			CommandArgument="Prev" OnClick="PagerButtonClick"></asp:ImageButton>&nbsp;&nbsp;
																		<asp:ImageButton id="imgNext" runat="server" ImageUrl="../Images/next-Page.gif" CommandArgument="Next"
																			OnClick="PagerButtonClick"></asp:ImageButton>
																	</p>--%>
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
    </form>
</body>
</html>
