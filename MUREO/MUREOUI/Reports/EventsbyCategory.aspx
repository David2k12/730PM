<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventsbyCategory.aspx.cs"
    ValidateRequest="false" Inherits="MUREOUI.Reports.EventsbyCategory" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Events by Category</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="GridLayout">

    <form id="Form1" method="post" runat="server">
    <script language="javascript">
        function NavigateAdjstrtDt() {
            window.open('../Common/frmAdjEventStartDt.aspx', 'AdjEventStartDt', 'top=250,left=300,width=500,height=150,menubar=no,resizable=no');
            return false;
        }
        function NavigateDataExport() {
            window.open('../Common/DataExport.aspx', 'DataExport', 'top=250,left=300,width=340,height=200,menubar=no,resizable=no');
            return false;
        }

        function CheckChanged(obj) {
            if (document.getElementById("<%= hdCount.ClientID %>").value != "") {
                var count = parseInt(document.getElementById("<%= hdCount.ClientID %>").value);

                if (obj.checked == true)
                    count++;
                else
                    count--;

                document.getElementById("<%= hdCount.ClientID %>").value = count;
            }
        }

        function CheckMigrate() {
            var count = parseInt(document.getElementById("<%= hdCount.ClientID %>").value);

            if (count == 0) {
                alert("Select atlest one Event to migrate.");
                return false;
            }
        }

        function selprojectplant() {
            var selPlant = 0;
            var selProject = 0;
            if (document.getElementById('drpPlant').options(0).selected)
                selPlant = 1;
            if (document.getElementById('drpProject').options(0).selected)
                selProject = 1;
            if (selPlant == 1 && selProject == 1) {
                alert('Please select Plant' + '\n' + 'Please select Project');
                return false;
            }
            else if (selPlant == 1) {
                alert('Please select Plant');
                return false;
            }
            else if (selProject == 1) {
                alert('Please select Project');
                return false;
            }
        }
				
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <input id="hdID" type="hidden" runat="server">
            <asp:HiddenField ID="hdCount" runat="server" />
            <table id="maintbl" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td valign="top">
                        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top" align="left">
                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                            <tr valign="middle">
                                                <td class="FormHeader" align="center">
                                                    <!--<IMG height="44" src="../images/familycare-logo.gif" width="46">-->
                                                    Events by Category
                                                </td>
                                            </tr>
                                            <tr height="10">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;
                                                    <asp:ImageButton ID="imgMyEvents" ToolTip="My Events" runat="server" ImageUrl="../Images/myevents.gif"
                                                        OnClick="imgMyEvents_Click"></asp:ImageButton>&nbsp;<asp:ImageButton ID="imgProjectsbyCategory"
                                                            runat="server" ImageUrl="../Images/projs-by-category.gif" AlternateText="Project By Category"
                                                            OnClick="imgProjectsbyCategory_Click"></asp:ImageButton>&nbsp;
                                                    <asp:ImageButton ID="imgOpenDataExportPage" runat="server" ImageUrl="../Images/opendata-export-page.gif"
                                                        AlternateText="Open Data Export Page"></asp:ImageButton>&nbsp;
                                                    <asp:ImageButton ID="imgAdjStartDate" runat="server" ImageUrl="../Images/adjust-start-dates.gif"
                                                        AlternateText="Adjust Start Dates"></asp:ImageButton>&nbsp;
                                                    <asp:ImageButton ID="btnMigrate" ToolTip="Migrate Event(s) Data" runat="server" ImageUrl="../Images/migrate-Events-data.gif"
                                                        OnClick="btnMigrate_Click"></asp:ImageButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="30">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;&nbsp;&nbsp; Plant :
                                                    <asp:DropDownList ID="drpPlant" runat="server" AutoPostBack="True" Width="200px"
                                                        OnSelectedIndexChanged="drpPlant_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <font class="astrisk" color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="20">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 3px" align="center">
                                                    &nbsp;Project :
                                                    <asp:DropDownList ID="drpProject" runat="server" AutoPostBack="True" Width="200px">
                                                    </asp:DropDownList>
                                                    <font class="astrisk" color="red">*</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="20">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="20">
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="../Images/search.gif" OnClick="btnSearch_Click">
                                                    </asp:ImageButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                        <tr align="center">
                                                            <td valign="top" align="center">
                                                                <div id="division2" style="width: 950px; height: 300px; overflow: auto" align="center">
                                                                    <dx:ASPxGridView ID="dgEventDetails" KeyFieldName="Event_ID" Width="90%" runat="server" headerstyle-cssclass="subHeader"
                                                                        AutoGenerateColumns="False" CssClass="SubHeader"
                                                                        cellspacing="2" OnHtmlRowPrepared="dgEventDetails_HtmlRowPrepared"
                                                                        OnBeforeColumnSortingGrouping="dgEventDetails_CustomColumnSor" OnPageIndexChanged="dgEventDetails_PageIndexChanged">
                                                                        <Columns>
                                                                            <dx:GridViewDataColumn VisibleIndex="0" Visible="false" FieldName="Event_ID" Caption="Event_ID">
                                                                            </dx:GridViewDataColumn >
                                                                            <dx:GridViewDataColumn Caption="Check" VisibleIndex="1">
                                                                                <DataItemTemplate>
                                                                                    <asp:CheckBox ID="chkEvent" EventID='<%# Eval("Event_ID") %>' Brand_Segment_Name='<%# Eval("Brand_Segment_Name") %>'
                                                                                        Category_Name='<%# Eval("Category_Name") %>' Plant_Name='<%# Eval("Plant_Name") %>'
                                                                                        Event_Name='<%# Eval("Event_Name") %>' onclick="return CheckChanged(this);" runat="server">
                                                                                    </asp:CheckBox>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Caption="Event"  VisibleIndex="2">
                                                                                <DataItemTemplate>
                                                                                    <asp:LinkButton ID="Linkbutton1" Text='<%# Eval("Event_Name")%>' OnCommand="Linkbutton1_Command"
                                                                                        CommandName='<%# Eval("Event_ID") %>' runat="server">
																							                        
                                                                                               </asp:LinkButton>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Visible="false" FieldName="Project_ID" Caption="Project_ID" VisibleIndex="3">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Visible="false" FieldName="Machine_IDs" Caption="Machine_IDs" VisibleIndex="4">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Visible="false" FieldName="Plant_Name"  Caption="Site"  VisibleIndex="5">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Visible="false" FieldName="Category_Name"  Caption="Category"  VisibleIndex="6">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn  Visible="false" FieldName="Brand_Segment_Name"  Caption="Brand Segment"  VisibleIndex="7">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn FieldName="Machine_Names"  Caption="Machine Names"  VisibleIndex="8">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn FieldName="Desired_Start_Date" Caption="Desired Start Date"
                                                                                SortOrder="Ascending" VisibleIndex="9">
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn FieldName="Modified_Date" VisibleIndex="10" Caption="Modified Date" >
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn FieldName="Modified_By" VisibleIndex="11" Caption="Modified By" >
                                                                            </dx:GridViewDataColumn>
                                                                            <dx:GridViewDataColumn Visible="false" VisibleIndex="12" FieldName="Event_Name" Caption="Event_Name">
                                                                            </dx:GridViewDataColumn>
                                                                        </Columns>
                                                                        <SettingsPager PageSize="10" Position="Bottom" NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous">
                                                                        </SettingsPager>
                                                                        <Styles>                                                                          
                                                                            <Header Font-Bold="true" BackColor="#FFCC00">
                                                                            </Header>
                                                                        </Styles>
                                                                    </dx:ASPxGridView>
                                                                    <%--<asp:DataGrid ID="dgEventDetails" Width="100%" BorderWidth="1px" BorderColor="Black"
                                                                AllowSorting="True" CellSpacing="2" AllowPaging="True" PagerStyle-Mode="NextPrev"
                                                                DataKeyField="Event_ID" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="SubHeader"
                                                                GridLines="None" onitemcommand="dgEventDetails_ItemCommand" 
                                                                onitemdatabound="dgEventDetails_ItemDataBound" 
                                                                onsortcommand="dgEventDetails_ItemSortCommand">
                                                                <AlternatingItemStyle CssClass="AlternateROw2"></AlternatingItemStyle>
                                                                <ItemStyle CssClass="AlternateRow1" HorizontalAlign=Left></ItemStyle>
                                                                <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                                <Columns>
                                                                    <asp:BoundColumn Visible="False" DataField="Event_ID" HeaderText="Event_ID"></asp:BoundColumn>
                                                                    <asp:TemplateColumn ItemStyle-HorizontalAlign=Left>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkEvent" runat="server"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn SortExpression="Event_Name" HeaderText="Event">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="Linkbutton1" CommandName="Event_Name" runat="server">
																						<%# Eval("Event_Name")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:BoundColumn Visible="False" DataField="Project_ID" HeaderText="Project_ID">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn Visible="False" DataField="Machine_IDs" HeaderText="Machine_IDs">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Machine_Names" SortExpression="Machine_Names" HeaderText="Machine Names">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Desired_Start_Date" SortExpression="Desired_Start_Date"
                                                                        HeaderText="Desired Start Date"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Modified_Date" SortExpression="Modified_Date" HeaderText="Modified Date">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Modified_By" SortExpression="Modified_By" HeaderText="Modified By">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn Visible="False" DataField="Event_Name" HeaderText="Event_Name">
                                                                    </asp:BoundColumn>
                                                                </Columns>
                                                             
                                                            </asp:DataGrid>--%></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
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
            </table>
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
