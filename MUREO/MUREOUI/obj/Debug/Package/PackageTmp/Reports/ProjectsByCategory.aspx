<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsByCategory.aspx.cs"
    Inherits="MUREOUI.Reports.ProjectsByCategory" %>


<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    <%@ Register src="~/UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Projects by Category</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function NavigateAdjstrtDt() {
            //window.open('../Common/frmAdjEventStartDt.aspx');
            window.open('../Common/frmAdjEventStartDt.aspx', 'AdjEventStartDt', 'top=250,left=300,width=500,height=150,menubar=no,resizable=no');
            return false;
        }
        function NavigateDataExport() {
            window.open('../Common/DataExport.aspx', 'DataExport', 'top=250,left=300,width=340,height=200,menubar=no,resizable=no');
            return false;
        }
        function setScreenRes() {
            document.getElementById("division1").style.height = (screen.height - 440); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            document.getElementById("division2").style.height = (screen.height - 500); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            //document.getElementById("tdDivider").style.height   = (screen.height - 520) ;
            if (screen.width == 1024) {
                document.getElementById("division1").style.width = (screen.width - 604);
                document.getElementById("division2").style.width = (screen.width - 474);
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
<body ms_positioning="GridLayout" bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="hdID" type="hidden" runat="server">
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top">
                            <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="360px">
                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="center">
                                            <table id="tbl4" border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                <tbody>
                                                    <tr valign="middle" bgcolor="#ffffcc">
                                                        <td class="FormHeader" align="center">
                                                            <div>
                                                                Projects by Category
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:ImageButton ID="imgMyEvents" OnClick="imgMyEvents_Click" runat="server" AlternateText="MyEvents"
                                                                ImageUrl="../Images/myevents.gif"></asp:ImageButton>&nbsp;&nbsp;
                                                            <asp:ImageButton ID="imgEventsbyCategory" OnClick="imgEventsbyCategory_Click" runat="server"
                                                                AlternateText="Events By Category" ImageUrl="../Images/events-by-category.gif">
                                                            </asp:ImageButton>&nbsp;&nbsp;
                                                            <asp:ImageButton ID="imgOpenDataExportPage" runat="server" AlternateText="Open Data Export Page"
                                                                ImageUrl="../Images/opendata-export-page.gif"></asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgAdjStartDate" runat="server" AlternateText="Adjust Start Date"
                                                                ImageUrl="../Images/adjust-start-dates.gif"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:ImageButton ID="imgExpnadAll" OnClick="imgExpnadAll_Click" runat="server" AlternateText="Expand All"
                                                                ImageUrl="../Images/expandall.gif"></asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgCollapseAll" OnClick="imgCollapseAll_Click" runat="server"
                                                                AlternateText="Collapse All" ImageUrl="../Images/collpaseall.gif"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="900px">
                                                                <tbody>
                                                                    <tr height="10">
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td valign="top" align="left" width="300px">
                                                                            <div id="division1" style="overflow: auto; width: 300px; height: 400px">
                                                                                <dx:ASPxGridView ID="drgdProjByCategory" KeyFieldName="Index" Width="280px" runat="server"
                                                                                    AutoGenerateColumns="False" OnHtmlRowPrepared="drgdProjByCategory_HtmlRowPrepared"
                                                                                    OnPageIndexChanged="drgdProjByCategory_PageIndexChanged">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Category"
                                                                                            VisibleIndex="0">
                                                                                            <DataItemTemplate>
                                                                                                <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgCategory1" OnCommand="imgCategory1_Command"
                                                                                                    CommandName="CategoryExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                                <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgCategory2" OnCommand="imgCategory2_Command"
                                                                                                    CommandName="CategoryCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                                <asp:Label Visible="False" ID="lblCategoryID" runat="server" Text='<%# Eval("Category_ID")%>'>
                                                                                                   </asp:Label>
                                                                                                <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("Category_Name")%>'>
                                                                                                   </asp:Label>&nbsp;
                                                                                               </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Brand"
                                                                                            VisibleIndex="1">
                                                                                            <DataItemTemplate>
                                                                                                <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgBrandSegment1" OnCommand="imgBrandSegment1_Command"
                                                                                                    CommandName="BrandSegmentExpand" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                                <asp:ImageButton runat="server" Style="cursor: pointer" ID="imgBrandSegment2" OnCommand="imgBrandSegment2_Command"
                                                                                                    CommandName="BrandSegmentCollapse" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                                <asp:Label ID="lblCatID" Visible="False" runat="server" Text='<%# Eval("Category_ID")%>'>
                                                                                                   </asp:Label>
                                                                                                <asp:Label ID="lblBrandSegmentID" Visible="False" runat="server" Text='<%# Eval("Brand_Segment_ID")%>'>
                                                                                                   </asp:Label>
                                                                                                <asp:Label ID="lblbrandSegmentName" runat="server" Text='<%# Eval("Brand_Segment_Name")%>'>
                                                                                                   </asp:Label>&nbsp;
                                                                                               </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                    </Columns>
                                                                                    <SettingsPager Mode="ShowAllRecords">
                                                                                    </SettingsPager>
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Styles>
                                                                                        <Header Font-Bold="true" BackColor="#FFCC00">
                                                                                        </Header>
                                                                                    </Styles>
                                                                                </dx:ASPxGridView>
                                                                                <%--<asp:DataGrid ID="drgdProjByCategory" runat="server" BorderWidth="1px" GridLines="None"
                                                                            Width="100%" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False" BorderColor="black"
                                                                            PageSize="12">
                                                                            <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                                            <Columns>
                                                                                <asp:TemplateColumn HeaderText="Category">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgCategory1" CommandName="CategoryExpand" ImageUrl="../Images/arrow1.gif">
                                                                                        </asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="imgCategory2" CommandName="CategoryCollapse"
                                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label Visible="False" ID="lblCategoryID" runat="server" Text='<%# Eval("Category_ID")%>'>
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("Category_Name")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="Brand">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgBrandSegment1" CommandName="BrandSegmentExpand"
                                                                                            ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="imgBrandSegment2" CommandName="BrandSegmentCollapse"
                                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblCatID" Visible="False" runat="server" Text='<%# Eval("Category_ID")%>'>
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblBrandSegmentID" Visible="True" runat="server" Text='<%# Eval("Brand_Segment_ID")%>'>
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblbrandSegmentName" runat="server" Text='<%# Eval("Brand_Segment_Name")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid>--%></div>
                                                                        </td>
                                                                        <td valign="top" align="left" width="500px">
                                                                            <table border="0" width="500px" cellspacing="5" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="25%" align="right">
                                                                                        <asp:Label ID="lblCategoryHead" runat="server" Visible="True">Category : </asp:Label>
                                                                                    </td>
                                                                                    <td width="25%">
                                                                                        <asp:Label ID="lblCategory" runat="server" Visible="False"></asp:Label>
                                                                                    </td>
                                                                                    <td width="25%" align="right">
                                                                                        <asp:Label ID="lblBrandHead" runat="server" Visible="True">Brand : </asp:Label>
                                                                                    </td>
                                                                                    <td width="25%">
                                                                                        <asp:Label ID="lblBrand" runat="server" Visible="False"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <div id="division2" style="overflow: auto; width: 600px; height: 300px">
                                                                                <dx:ASPxGridView ID="dgProjects" runat="server" AllowSorting="True" Width="600px"
                                                                                    HeaderStyle-CssClass="subHeader" GridLines="None" AutoGenerateColumns="False"
                                                                                    CssClass="SubHeader" AllowPaging="True" cellspacing="2" OnPageIndexChanged="dgProjects_PageIndexChanged">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataColumn FieldName="Project_Name" Caption="Project" VisibleIndex="1"
                                                                                            Width="200px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="lnkProject" CommandArgument='<%# Eval("Project_ID") %>' OnCommand="lnkProject_Command"
                                                                                                    CommandName="Project_Links" runat="server" Text=' <%# Eval("Project_Name")%>'>
                                                                                                   </asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn FieldName="Project_Type_Name" Caption="Project Type" VisibleIndex="2"
                                                                                            Width="200px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Project_Type_Name")%>'>
                                                                                                   </asp:Label>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn FieldName="Project_Lead" Caption="Project Lead" VisibleIndex="3"
                                                                                            Width="100px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Project_Lead")%>'>
                                                                                                   </asp:Label>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn FieldName="Point_Of_Contact" Caption="POC for Data" VisibleIndex="4"
                                                                                            Width="50px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Point_Of_Contact")%>'>
                                                                                                   </asp:Label>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                        <dx:GridViewDataColumn FieldName="Modified_Date" Caption="Modified Date" VisibleIndex="5"
                                                                                            Width="50px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("Modified_Date")%>'>
                                                                                                   </asp:Label>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataColumn>
                                                                                    </Columns>
                                                                                    <SettingsPager PageSize="10" Position="Bottom" NextPageButton-Image-ToolTip="Next"
                                                                                        PrevPageButton-Image-ToolTip="Previous">
                                                                                    </SettingsPager>
                                                                                    <Settings GridLines="None" />
                                                                                    <Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Settings GridLines="None" /><Styles>
                                                                                        <Header Font-Bold="true" BackColor="#FFCC00">
                                                                                        </Header>
                                                                                    </Styles>
                                                                                </dx:ASPxGridView>
                                                                                <%--<asp:DataGrid ID="dgProjects" GridLines="None" Width="100%" AutoGenerateColumns="False"
                                                                            runat="server" DataKeyField="Project_ID" AllowPaging="True" CellSpacing="2" AllowSorting="True"
                                                                            BorderColor="Black" BorderWidth="1px">
                                                                            <AlternatingItemStyle CssClass="AlterNateRow2"></AlternatingItemStyle>
                                                                            <ItemStyle CssClass="AlterNateRow1"></ItemStyle>
                                                                            <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                                            <Columns>
                                                                                <asp:TemplateColumn SortExpression="Project_Name" HeaderText="Project">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="Linkbutton1" CommandName="Project_Links" runat="server">
																									<%# Eval("Project_Name")%>
                                                                                        </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn SortExpression="Project_Type_Name" HeaderText="Project Type">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Project_Type_Name")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn SortExpression="Project_Lead" HeaderText="Project Lead">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Project_Lead")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn SortExpression="Point_Of_Contact" HeaderText="POC for Data">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Point_Of_Contact")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn SortExpression="Modified_Date" HeaderText="Modified Date">
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Modified_Date")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                            <PagerStyle Visible="False" NextPageText="" PrevPageText="" HorizontalAlign="Center">
                                                                            </PagerStyle>
                                                                        </asp:DataGrid>--%></div>
                                                                            <p align="center">
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>                      
                            <uc2:FooterControl ID="FooterControl1" runat="server" />
                        </td>
                    </tr>
                </tbody>
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
