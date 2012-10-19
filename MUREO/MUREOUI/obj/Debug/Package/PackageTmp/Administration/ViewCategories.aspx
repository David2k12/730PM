<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCategories.aspx.cs"
    Inherits="MUREOUI.Administration.ViewCategories" %>

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
    <title>ViewCategories</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
   
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
    <form id="form1" runat="server">
     <script language="javascript">
         function setScreenRes() {
             document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

         }
         function confirmConMachineDelete(MachineName) {
             var msg = 'Are you sure you want to delete this Machine ' + '\'' + MachineName + '\' ?'

             if (confirm(msg)) {
                 document.getElementById("<%=hdnResponse.ClientID %>").value = "Y"
             }
             else {
                 document.getElementById("<%=hdnResponse.ClientID %>").value = "N"
                 return false;
             }
         }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1" style="vertical-align: middle;">
                            <tr>
                                <td valign="top" align="left" width="20%">
                                    <uc2:LeftNavigationControl ID="LeftNavigationControl1" runat="server" />
                                </td>
                                <td valign="top" width="80%">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td class="FormHeader">
                                                Maintain Convert Machines
                                            </td>
                                        </tr>
                                        <tr style="height: 1;">
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgConvertAdd" runat="server" ImageUrl="../Images/create-convert-machine.gif"
                                                    OnClick="imgConvertAdd_Click"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgExpnadAll" runat="server" ImageUrl="../Images/expandall.gif"
                                                    OnClick="imgExpnadAll_Click"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCollapseAll" runat="server" ImageUrl="../Images/collpaseall.gif"
                                                    OnClick="imgCollapseAll_Click"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr style="height: 1;">
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td valign="top" align="center" width="100%">
                                                <div id="divTest" style="width: 100%; height: 300px; overflow: auto">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <dx:ASPxGridView ID="drgdMachinesByCategoryNew" runat="server" OnHtmlRowPrepared="drgdMachinesByCategoryNew_HtmlRowPrepared"
                                                                    KeyFieldName="Category_ID" Width="100%">
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Category" HeaderStyle-Wrap="True"
                                                                            VisibleIndex="1" FixedStyle="Left" Settings-AllowSort="True">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <HeaderCaptionTemplate>
                                                                                Category
                                                                            </HeaderCaptionTemplate>
                                                                            <Settings AllowSort="True"></Settings>
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgCategory1" ImageUrl="~/Images/arrow1.gif"
                                                                                    OnCommand="imgCategory1_Command" CommandName="CommandExpand" />
                                                                                <asp:ImageButton runat="server" ID="imgCategory2" ImageUrl="~/Images/arrow_down1.gif"
                                                                                    OnCommand="imgCategory2_Command" CommandName="CommandCollapse" />
                                                                                <asp:Label Visible="True" ID="lblCategoryName" runat="server" Text='<%#Eval("Category_Name")%>'></asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Plant" HeaderStyle-Wrap="True"
                                                                            VisibleIndex="2" FixedStyle="Left" Settings-AllowSort="True">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <HeaderCaptionTemplate>
                                                                                Plant
                                                                            </HeaderCaptionTemplate>
                                                                            <Settings AllowSort="True"></Settings>
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgPlant1" ImageUrl="~/Images/arrow1.gif" OnCommand="imgPlant1_Command"
                                                                                    CommandName="PlantExpand" />
                                                                                <asp:ImageButton runat="server" ID="imgPlant2" ImageUrl="~/Images/arrow_down1.gif"
                                                                                    OnCommand="imgPlant2_Command" CommandName="PlantCollapse" />
                                                                                <asp:Label Visible="True" ID="lblPlantName" runat="server" Text='<%#Eval("Plant_Name")%>'></asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Caption="Machine" HeaderStyle-Wrap="True"
                                                                            VisibleIndex="3" FixedStyle="Left" Settings-AllowSort="True">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                            <CellStyle HorizontalAlign="Left">
                                                                            </CellStyle>
                                                                            <HeaderCaptionTemplate>
                                                                                Machine
                                                                            </HeaderCaptionTemplate>
                                                                            <Settings AllowSort="True"></Settings>
                                                                            <DataItemTemplate>
                                                                                <asp:Label Visible="False" ID="lblCategoryID" runat="server" Text='<%#Eval("Category_ID")%>'></asp:Label>
                                                                                <asp:Label Visible="False" ID="lblMachineID" runat="server" Text='<%#Eval("Machine_ID")%>'></asp:Label>
                                                                                <asp:Label Visible="False" ID="lblPlantID" runat="server" Text='<%#Eval("Plant_ID")%>'></asp:Label>
                                                                                <asp:Label Visible="False" ID="lblMachineName" runat="server" Text='<%#Eval("Machine_Name")%>'></asp:Label>
                                                                                <asp:LinkButton ID="lnkMachineName" OnCommand="lnkMachineName_Command" Machine_ID='<%#Eval("Machine_ID")%>'
                                                                                    Machine_Name='<%#Eval("Machine_Name")%>' CommandArgument='<%#Eval("Plant_ID")%>'
                                                                                    CommandName='<%#Eval("Category_ID")%>' runat="server" Text='<%#Eval("Machine_Name")%>'></asp:LinkButton>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center"
                                                                            Caption="DeleteMachine" HeaderStyle-Wrap="True" VisibleIndex="4" FixedStyle="Left"
                                                                            Settings-AllowSort="True">
                                                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                                                            <HeaderCaptionTemplate>
                                                                                Delete Machine
                                                                            </HeaderCaptionTemplate>
                                                                            <Settings AllowSort="True"></Settings>
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" Style="cursor: pointer" ToolTip="Delete Machine"
                                                                                    ID="ImgRemoveMachine" CommandArgument='<%# Eval("Machine_ID") %>' OnCommand="ImgRemoveMachine_Command" CommandName="RemoveMachine" ImageUrl="~/Images/remove-icon.gif" />
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <Settings GridLines="None" />
                                                                    <SettingsPager Mode="ShowAllRecords">
                                                                    </SettingsPager>
                                                                    <Styles>
                                                                        <Header Font-Bold="true" BackColor="#FFCC00">
                                                                        </Header>
                                                                    </Styles>
                                                                </dx:ASPxGridView>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                        <asp:HiddenField ID="hdnResponse" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc3:FooterControl ID="FooterControl1" runat="server" />
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
