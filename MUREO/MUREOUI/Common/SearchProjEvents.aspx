<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchProjEvents.aspx.cs"
    Inherits="MUREOUI.Common.SearchProjEvents" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="../UserControls/LeftNavigationControl.ascx" TagName="LeftNavigationControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Projects / Events</title>
   <link type="text/javascript" href="../StyleSheets/MUREO.css" />
    <script language="javascript" type="text/javascript">
        function OpenWindow() {
            window.open('ProjEventsResults.aspx', 'Search Results', 'width=400,height=300,top=125,left=450');
        }

        function AllowNumeric(e) {
            var iKeyCode = 0;
            if (window.event)
                iKeyCode = window.event.keyCode
            else if (e)
                iKeyCode = e.which;
            if ((iKeyCode == 46) || (iKeyCode > 47 && iKeyCode < 58))
                return true;
            else
                return false;
        }

        function CheckPlantSite(sender, args) {
            if (document.getElementById('drpPlantDB').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckProjectLead(sender, args) {
            if (document.getElementById('drpProjLeadDB').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckProjectType(sender, args) {
            if (document.getElementById('drpProjNameDB').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }



        function ValidateFocus() {
            e = document.getElementById('drpCategory');
            f = document.getElementById('drpBrand');
            g = document.getElementById('drpPrjType');

            if (e.value == "0") {
                document.getElementById('drpCategory').focus();
            }
            else if (f.value == "0") {
                document.getElementById('drpBrand').focus();
            }
            else if (document.getElementById('txtPrjName').value == "") {
                document.getElementById('txtPrjName').focus();
            }
            else if (g.value == "0") {
                document.getElementById('drpPrjType').focus();
            }

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
                            <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" valign="top">Search Projects / Events
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <table id="tblSerchProjEvent" cellspacing="6" cellpadding="0" width="100%">
                                            <tr height="30">
                                                <td width="30%">
                                                </td>
                                                <td align="left" width="70%">
                                                    <b>Search for
                                                        <asp:DropDownList ID="drpSearchKey" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSearchKey_SelectedIndexChanged">
                                                            <asp:ListItem Value="any">Any</asp:ListItem>
                                                            <asp:ListItem Value="all">All</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp; following words:</b>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="tblsub1" cellspacing="8" cellpadding="0" width="100%">
                                            <tr height="30">
                                                <td class="FieldNames" align="right" width="30%">
                                                    Project Name:&nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:DropDownList ID="drpProjNameDB" runat="server" AutoPostBack="True" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FieldNames" align="right" width="30%">
                                                    Event Name:&nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:TextBox ID="txtEONameDB" runat="server" Width="195px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FieldNames" align="right" width="30%">
                                                    Project Lead:&nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:DropDownList ID="drpProjLeadDB" runat="server" AutoPostBack="True" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr height="30">
                                                <td class="FieldNames" align="right" width="30%">
                                                    Plant:&nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:DropDownList ID="drpPlantDB" runat="server" AutoPostBack="True" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FieldNames" align="right" width="30%">
                                                    EO #:&nbsp;
                                                </td>
                                                <td width="70%" align="left">
                                                    <asp:TextBox ID="txtEONumberDB" runat="server" Width="195px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table id="tblsub2" cellspacing="8" cellpadding="0" width="100%">
                                            <tbody>
                                                <tr valign="middle">
                                                    <td class="FieldNames" align="right" width="30%">
                                                        Project Creation Date:&nbsp;
                                                    </td>
                                                    <td  class="warning" valign="middle" align="left" width="70%" style="font-weight:bold; color:red; font-family:Verdana; font-size:12px">
                                                        <asp:TextBox ID="txtPrjCreationDate" runat="server" Width="195px"></asp:TextBox>&nbsp;Note:Date
                                                        Format shoud be MM/DD/YYYY
                                                    </td>
                                                </tr>
                                                <tr valign="middle" height="25">
                                                    <td width="30%">
                                                    </td>
                                                    <td valign="middle" align="left" width="70%">
                                                        <asp:RadioButtonList ID="rdbSortType" runat="server" Width="248px" Font-Bold="True"
                                                            OnSelectedIndexChanged="rdbSortType_SelectedIndexChanged">
                                                            <asp:ListItem Value="exact">Find exact word matches only</asp:ListItem>
                                                            <asp:ListItem Value="like">Find like word matches only</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="30">
                                                    <td class="FieldNames" align="right" width="30%">
                                                        Limit number of results to:&nbsp;
                                                    </td>
                                                    <td class="warning" onkeypress="javascript: return AllowNumeric(event);" align="left"
                                                        width="70%" style="font-weight:bold; color:red; font-family:Verdana; font-size:12px">
                                                        <asp:TextBox ID="txtLimit" runat="server" Width="50px" MaxLength="5">0</asp:TextBox>&nbsp;
                                                        (zero means no limit)
                                                    </td>
                                                </tr>
                                                <tr height="30">
                                                    <td class="FieldNames" align="right" width="30%">
                                                        Sort search results by:&nbsp;
                                                    </td>
                                                    <td width="70%" valign="middle" align="left" >
                                                        <asp:DropDownList ID="drpSearchSort" runat="server" AutoPostBack="True" Width="200px">
                                                            <asp:ListItem Value="Relevance">Relevance</asp:ListItem>
                                                            <asp:ListItem Value="oldestfirst">Oldest First(by date)</asp:ListItem>
                                                            <asp:ListItem Value="newestfirst">Newest First(by date)</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr height="25">
                                                    <td width="30%">
                                                    </td>
                                                    <td align="left" width="70%">
                                                        <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="../Images/search.gif" OnClick="imgSearch_Click">
                                                        </asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" CausesValidation="False"
                                                            OnClick="imgCancel_Click"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr height="30">
                                                    <td width="30%">
                                                        <asp:ValidationSummary ID="validSummsearch" runat="server" DisplayMode="List" ShowSummary="False"
                                                            ShowMessageBox="True"></asp:ValidationSummary>
                                                    </td>
                                                    <td width="70%">
                                                        <asp:CompareValidator ID="cvdDateValidator" runat="server" ErrorMessage="Please enter a valid date(mm/dd/yyyy) for 'Project Creation Date' option."
                                                            ControlToValidate="txtPrjCreationDate" Display="None" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                                                        <asp:RegularExpressionValidator ID="revLimitNumbers" runat="server" Display="None"
                                                            ControlToValidate="txtLimit" ErrorMessage="Please enter numbers only for 'Limit number of results to' option."
                                                            ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr height="30">
                                                    <td align="center" colspan="2">
                                                        <dx:ASPxGridView ID="dgdSearchProject1" runat="server" ridLines="None" HeaderStyle-CssClass="subHeader"
                                                            AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="200" OnPageIndexChanged="dgdSearchProject1_PageIndexChanged">
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
                                                                        <dx:ASPxLabel Visible="True" ID="lblPrjLead" Text=' <%# String.Format("Project_Lead : {0} ", Eval("Project_Lead"))%>'
                                                                            runat="server">
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
                                                            <Settings ShowHorizontalScrollBar="True" ShowGroupPanel="true" ShowFooter="True" />
                                                            <SettingsPager PageSize="50" Position="Bottom" Visible="true" NextPageButton-Image-ToolTip="Next" PrevPageButton-Image-ToolTip="Previous">
                                                            </SettingsPager>
                                                        </dx:ASPxGridView>
                                                    </td>
                                                </tr>
                                            </tbody>
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
                <uc2:FooterControl ID="FooterControl1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
