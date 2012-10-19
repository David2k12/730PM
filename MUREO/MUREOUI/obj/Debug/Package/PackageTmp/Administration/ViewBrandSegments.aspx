<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBrandSegments.aspx.cs"
    Inherits="MUREOUI.Administration.ViewBrandSegments" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewBrandSegments</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        function confirmBrandSegDelete(BrandSegment, userName, recCheck) {
            var popResult;
            popResult = window.showModalDialog('../Administration/AdminConfirm.aspx?BrandSegId=' + BrandSegment + '&userName=' + userName, null, 'dialogWidth:370px;dialogHeight:220px');
            
            if (popResult == "T") {

                alert("The record was deleted successfully.");
                window.location = "../Administration/ViewBrandSegments.aspx";
            }


        }
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

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
    <form id="frmViewBrandSegments" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl1" runat="server"></uc1:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td valign="top" align="left" width="20%">
                                    <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                    </uc1:LeftNavigationControlForAdmin>
                                </td>
                                <td valign="top" align="center">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="middle" align="center">
                                                <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr valign="middle" bgcolor="#ffffcc">
                                                        <td class="FormHeader">
                                                            Maintain&nbsp;Brand Segments
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Maintain&nbsp;Brand Segments
                                                        </td>
                                                        <tr height="10">
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:ImageButton ID="imgAdd" runat="server" 
                                                                    AlternateText="Create Brand Segment" 
                                                                    ImageUrl="../Images/create-brand-segment.gif" OnClick="imgAdd_Click" 
                                                                    ToolTip="Create Brand Segment" />
                                                                &nbsp;<asp:ImageButton ID="imgExpnadAll" runat="server" 
                                                                    ImageUrl="../Images/expandall.gif" OnClick="imgExpnadAll_Click" 
                                                                    ToolTip="Expand All" />
                                                                <asp:ImageButton ID="Imagebutton1" runat="server" AlternateText="Collapse All" 
                                                                    ImageUrl="../Images/collpaseall.gif" OnClick="Imagebutton1_Click" 
                                                                    ToolTip="Collapse All" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="100%">
                                                                <div ID="divTest" style="overflow: auto; width: 100%; height: 300px">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="100%">
                                                                                <dx:ASPxGridView ID="drgdBrandSegment" runat="server" AllowSorting="True" 
                                                                                    AutoGenerateColumns="False" Border-BorderColor="Black" 
                                                                                    KeyFieldName="Brand_Segment_ID" 
                                                                                    OnHtmlRowPrepared="drgdBrandSegment_HtmlRowPrepared" 
                                                                                    OnPageIndexChanged="drgdBrandSegment_PageIndexChanged" Width="100%">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataColumn Caption="Category" 
                                                                                            EditCellStyle-HorizontalAlign="Justify" VisibleIndex="0" Width="30%">
                                                                                            <editcellstyle horizontalalign="Justify">
                                                                                            </editcellstyle>
                                                                                            <dataitemtemplate>
                                                                                                <asp:ImageButton ID="imgCategory1" runat="server" CommandName="Category1" 
                                                                                                    ImageUrl="../Images/arrow1.gif" OnCommand="imgCategory1_Command" />
                                                                                                <asp:ImageButton ID="imgCategory2" runat="server" CommandName="Category2" 
                                                                                                    ImageUrl="../Images/arrow_down1.gif" OnCommand="imgCategory2_Command" />
                                                                                                <asp:Label ID="lblCategoryName" runat="server" 
                                                                                                    Text='<%# Eval("Category_Name")%>'> </asp:Label>
                                                                                            </dataitemtemplate>
                                                                                            <cellstyle horizontalalign="Left">
                                                                                            </cellstyle>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn Caption="Brand Segment" 
                                                                                            EditCellStyle-HorizontalAlign="Justify" VisibleIndex="1" Width="50%">
                                                                                            <editcellstyle horizontalalign="Justify">
                                                                                            </editcellstyle>
                                                                                            <dataitemtemplate>
                                                                                                <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("Category_ID")%>' 
                                                                                                    Visible="false"> </asp:Label>
                                                                                                <asp:Label ID="lblCName" runat="server" Text='<%# Eval("Category_Name")%>' 
                                                                                                    Visible="false"> </asp:Label>
                                                                                                <asp:Label ID="lblBrandSegmentID" runat="server" 
                                                                                                    Text='<%# Eval("Brand_Segment_ID")%>' Visible="false"> </asp:Label>
                                                                                                <asp:LinkButton ID="lnkbrandSegmentName" runat="server" CommandName="BrandName" 
                                                                                                    OnCommand="lnkbrandSegmentName_Command" Text='<%# Eval("Brand_Segment_Name")%>' 
                                                                                                    ToolTip="View Brand Segment">
                                                                                                </asp:LinkButton>
                                                                                            </dataitemtemplate>
                                                                                            <cellstyle horizontalalign="Left">
                                                                                            </cellstyle>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn Caption="Delete Brand" 
                                                                                            CellStyle-HorizontalAlign="Center" EditCellStyle-HorizontalAlign="Justify" 
                                                                                            HeaderStyle-HorizontalAlign="Center" VisibleIndex="3" Width="20%">
                                                                                            <dataitemtemplate>
                                                                                                <asp:ImageButton ID="ImgRemoveBrandSegment" runat="server" 
                                                                                                    CommandArgument='<%#Eval("Brand_Segment_ID")%>' 
                                                                                                    CommandName="RemoveBrandSegment" ImageUrl="../Images/remove-icon.gif" 
                                                                                                    OnCommand="ImgRemoveBrandSegment_Command" Style="cursor: pointer" 
                                                                                                    ToolTip="Delete Brand" />
                                                                                            </dataitemtemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                    </Columns>
                                                                                    <settingspager mode="ShowAllRecords">
                                                                                    </settingspager>
                                                                                    <styles>
                                                                                        <header backcolor="#FFCC00" cssclass="SubHeader" font-bold="True">
                                                                                        </header>
                                                                                    </styles>
                                                                                    <Settings GridLines="None" />
                                                                                    <border bordercolor="Black"></border>
                                                                                </dx:ASPxGridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
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
            <input id="response" type="hidden" name="response">
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    </form>
</body>
</html>
