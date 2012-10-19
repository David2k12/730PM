<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyEvents.aspx.cs" Inherits="MUREOUI.MyEvents" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>My Events</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function confirmDelete() {
            var chkGBUselected = 0;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i];
                if ((elm.type == 'checkbox') && (elm.checked == true)) {
                    chkGBUselected = 1;
                    break;
                }
            }
            if (chkGBUselected == 1) {
                if (!confirm('Are you sure you want to delete?')) {
                    for (i = 0; i < Form1.length; i++) {
                        if ((elm.type == 'checkbox') && (elm.checked == true)) {
                            //alert("Here" + Form1.elements[i].checked );
                            Form1.elements[i].checked = false;
                        }
                    }
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                alert("Please select Event(s)");
                return false;
            }

        }

        function confirmMigrate() {
            var chkGBUselected = 0;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i];
                if ((elm.type == 'checkbox') && (elm.checked == true)) {
                    chkGBUselected = 1;
                    break;
                }
            }
            if (chkGBUselected == 1) {
                if (!confirm('Are you sure you want to Migrate?')) {
                    for (i = 0; i < Form1.length; i++) {
                        if ((elm.type == 'checkbox') && (elm.checked == true)) {
                            //alert("Here" + Form1.elements[i].checked );
                            Form1.elements[i].checked = false;
                        }
                    }
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                alert("Please select Event(s)");
                return false;
            }

        }
        function NavigateAdjstrtDt() {
            window.open('../Common/frmAdjEventStartDt.aspx', 'AdjEventStartDt', 'top=250,left=300,width=400,height=150,menubar=no,resizable=no');
            return false;
        }

        function NavigateDataExport() {
            window.open('../Common/DataExport.aspx', 'DataExport', 'top=250,left=300,width=340,height=200,menubar=no,resizable=no');
            return false;
        }

        function CheckChanged(obj) {
            var count = parseInt(document.getElementById("hdCount").value);

            if (obj.checked == true)
                count++;
            else
                count--;

            document.getElementById("hdCount").value = count;
        }

        function CheckMigrate() {
            if (confirmMigrate() == true) {
                var count = parseInt(document.getElementById("hdCount").value);

                if (count == 0) {
                    alert("Select atlest one Event to migrate.");
                    return false;
                }
            }
            else {
                return false;
            }
        }

        //Screen Resolution code

        function setScreenRes() {
            /*document.getElementById("division1").style.height = (screen.height - 520) ;//"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            document.getElementById("division2").style.height = (screen.height - 520) ;
            if (screen.width ==1024)
            {
            document.getElementById("division1").style.width  = (screen.width - 614);
            document.getElementById("division2").style.width  = (screen.width - 474);
            }
            else if (screen.width ==1280)
            {
            document.getElementById("division1").style.width  = (screen.width - 835);
            document.getElementById("division2").style.width  = (screen.width - 475);
            }
            else if (screen.width ==1600)
            {
            document.getElementById("division1").style.width  = (screen.width - 1020);
            document.getElementById("division2").style.width  = (screen.width - 640);
            }
            else if (screen.width ==1920)
            {
            document.getElementById("division1").style.width  = (screen.width - 1152);
            document.getElementById("division2").style.width  = (screen.width - 760);
            } */

        }
    </script>
       <style type="text/css">       
    .hiddencol
    {
        display:none;
    }
    .viscol
    {
        display:block;               
    }
    </style>
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" onload="setScreenRes();" rightmargin="0"
    ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input id="hdCount" type="hidden" value="0" name="Hidden1" runat="server">
    <input id="hdID" type="hidden" runat="server">
    <table id="maintbl" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td>
                     <uc1:headercontrol id="HeaderControl" runat="server"></uc1:headercontrol>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="center">
                                            <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                <tr valign="middle" bgcolor="#ffffcc">
                                                    <td class="FormHeader" align="center">
                                                        My Events
                                                    </td>
                                                </tr>
                                                <tr height="10">
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:ImageButton ID="imgEventsbyCategory" OnClick="imgEventsbyCategory_Click" runat="server"
                                                            AlternateText="Events By Category" 
                                                            ImageUrl="~/Images/events-by-category.gif">
                                                        </asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgProjectsbyCategory" OnClick="imgProjectsbyCategory_Click"
                                                            runat="server" AlternateText="Project by Category" 
                                                            ImageUrl="~/Images/project-by-category.gif">
                                                        </asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgOpenDataExportPage" runat="server" AlternateText="Opend Data Export Page"
                                                            ImageUrl="~/Images/opendata-export-page.gif"></asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgAdjStartDate" ToolTip="Adjust Start Dates" runat="server" 
                                                            ImageUrl="~/Images/adjust-start-dates.gif">
                                                        </asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:ImageButton ID="btnMigrate" OnClick="btnMigrate_Click" runat="server" AlternateText="Migrate Event(s) Data"
                                                            ImageUrl="~/Images/migrate-Events-data.gif"></asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgDeleteEvents" OnClick="imgDeleteEvents_Click" ToolTip="Delete Event(s) Data" runat="server"
                                                            ImageUrl="~/Images/deleteEvent.gif" AlternateText="Delete Events"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" align="center" width="100%">
                                                                    <div id="division2" style="overflow: auto; height: 350px">
                                                                        <dx:ASPxGridView ID="dgEventDetails" Width="90%" runat="server" headerstyle-cssclass="subHeader"
                                                                            gridlines="None" AutoGenerateColumns="False" CssClass="SubHeader" allowpaging="True"
                                                                            cellspacing="2" ClientIDMode="AutoID" OnBeforeColumnSortingGrouping="dgEventDetails_CustomColumnSor"
                                                                            OnPageIndexChanged="dgEventDetails_PageIndexChanged">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn Visible="false" FieldName="Event_ID" Caption="Event_ID">
                                                                                </dx:GridViewDataColumn>
                                                                                <%--<dx:GridViewDataColumn Visible="false" FieldName="Modified_Date" Caption="Modified_Date">
                                                                                </dx:GridViewDataColumn>--%>
                                                                                <dx:GridViewDataColumn Caption="Check">
                                                                                    <DataItemTemplate>
                                                                                        <asp:CheckBox ID="chkEvent" EventID='<%# Eval("Event_ID") %>' Brand_Segment_Name='<%# Eval("Brand_Segment_Name") %>'
                                                                                            Category_Name='<%# Eval("Category_Name") %>' Plant_Name='<%# Eval("Plant_Name") %>'
                                                                                            Event_Name='<%# Eval("Event_Name") %>' onclick="return CheckChanged(this);" runat="server">
                                                                                        </asp:CheckBox>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn Caption="Event">
                                                                                    <DataItemTemplate>
                                                                                        <asp:LinkButton ID="Linkbutton1" OnCommand="Linkbutton1_Command" CommandName='<%# Eval("Event_ID") %>'
                                                                                            runat="server">
																							                        <%# DataBinder.Eval(Container.DataItem,"Event_Name")%>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn Visible="false" FieldName="Project_ID" Caption="Project_ID">
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn Visible="false" FieldName="Machine_IDs" Caption="Machine_IDs">
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn FieldName="Plant_Name" Caption="Site" >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn FieldName="Category_Name" Caption="Category" >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn FieldName="Brand_Segment_Name" Caption="Brand Segment" >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn FieldName="Machine_Names" Caption="Machine Names" >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn FieldName="Desired_Start_Date" Caption="Desired Start Date"
                                                                                    >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn FieldName="Modified_Date" Caption="Modified Date"
                                                                                    >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn  FieldName="Modified_By" Caption="Modified By"
                                                                                    >
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn Visible="false" FieldName="Event_Name" Caption="Event_Name">
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="10" Position="Bottom" NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous">
                                                                            </SettingsPager>
                                                                            <Styles>                                                                               
                                                                                <Header Font-Bold="true" BackColor="#FFCC00">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <%--<asp:DataGrid ID="dgEventDetails" PageSize="30" AllowPaging="True" DataKeyField="Event_ID"
                                                                    PagerStyle-Mode="NumericPages" CellSpacing="2" AllowSorting="True" runat="server"
                                                                    BorderColor="Black" AutoGenerateColumns="False" HeaderStyle-CssClass="SubHeader"
                                                                    Width="100%" GridLines="None" BorderWidth="1px">
                                                                    <AlternatingItemStyle CssClass="AlternateROw2"></AlternatingItemStyle>s
                                                                    <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                                                    <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:BoundColumn Visible="False" DataField="Event_ID" HeaderText="Event_ID"></asp:BoundColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkEvent" runat="server"></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn SortExpression="Event_Name" HeaderText="Event">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="Linkbutton1" CommandName="Event_Name" runat="server">
																							<%# DataBinder.Eval(Container.DataItem,"Event_Name")%>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:BoundColumn Visible="False" DataField="Project_ID" HeaderText="Project_ID">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn Visible="False" DataField="Machine_IDs" HeaderText="Machine_IDs">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Plant_Name" SortExpression="Plant_Name" HeaderText="Site">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Category_Name" SortExpression="Category_Name" HeaderText="Category">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Brand_Segment_name" SortExpression="Brand_Segment_name"
                                                                            HeaderText="Brand Segment"></asp:BoundColumn>
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
                                                                    <PagerStyle Visible="False" NextPageText="" PrevPageText="" Mode="NumericPages">
                                                                    </PagerStyle>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                          <uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
