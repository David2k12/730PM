<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchApproverNames.aspx.cs"
    Inherits="MUREOUI.Administration.SearchApproverNames" %>

<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SearchApproverNames</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function CheckApproverName(sender, args) {
            if (document.getElementById('drpApproverName').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
        function AddBooksingUser() {
            var popres;
            popres = document.getElementById('txtNewApproverName').value;
            var strtxtNewApproverName = document.getElementById("<%=txtNewApproverName.ClientID %>").id;
            var hdntxtNewApproverName = document.getElementById("<%=hdntxtNewApproverName.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtNewApproverName + '&Hidd=' + hdntxtNewApproverName, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtNewApproverName + '&Hidd=' + hdntxtNewApproverName, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //            var popResult;
            //            var pCont = document.getElementById('txtNewApproverName').value
            //            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + pCont, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //            if (popResult != "") {
            //                document.getElementById('txtNewApproverName').value = popResult;
            //            }
            //            if (document.getElementById('txtNewApproverName').value == 'undefined') {
            //                document.getElementById('txtNewApproverName').value = "";
            //            }
        }


        function CheckFunctionName(sender, args) {
            if (document.getElementById('drpFunction').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
        function NoSpecialCharacters() {
            var k;
            k = event.keyCode;

            if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42) && !(k == 38)) {
                return true;
            }
            else {
                //alert("Enter characters and Digits Only")
                return false;
            }
        }
		
		
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="scp1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upbudget" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:Header ID="Header1" runat="server"></uc1:Header>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%" align="center">
                                        <tr class="FormHeader">
                                            <td>
                                                Search Approver Names
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="astrisk" align="center" colspan="2">
                                                *- Mandatory Fields
                                            </td>
                                        </tr>
                                        <tr height="10">
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="overflow: auto; height: 330px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="FieldNames" valign="top" align="right" width="50%">
                                                                <asp:HiddenField ID="hdntxtNewApproverName" runat="server" />
                                                                Approver Name:&nbsp;&nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="drpApproverName" runat="server" Width="200">
                                                                </asp:DropDownList>
                                                                <font class="astrisk">*</font>
                                                            </td>
                                                        </tr>
                                                        <tr height="1">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="FieldNames" style="height: 25px" valign="top" align="right">
                                                                Function:&nbsp;&nbsp;
                                                            </td>
                                                            <td style="height: 25px" valign="top">
                                                                <asp:DropDownList ID="drpFunction" runat="server" Width="200">
                                                                </asp:DropDownList>
                                                                <font class="astrisk">*</font>
                                                            </td>
                                                        </tr>
                                                        <tr height="1">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:ImageButton ID="imgOK" OnClick="imgOK_Click" TabIndex="5" runat="server" ImageUrl="../Images/ok.gif">
                                                                </asp:ImageButton>&nbsp;
                                                                <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" TabIndex="6" runat="server"
                                                                    ImageUrl="../images/cancel.gif" CausesValidation="False"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <%--<asp:datagrid id="dgrdApproverGroups" Runat="server" Width="50%" BorderColor="black" AutoGenerateColumns="False"
																	HeaderStyle-CssClass="SubHeader" GridLines="None" BorderWidth="1px">
																	<Columns>
																		<asp:TemplateColumn HeaderText="Select ">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="chkAppGrp" Runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Approver Group Name">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblApprGrpName" Runat=server text='<%#DataBinder.Eval(Container.Dataitem,"Approval_Group_Name")%>' >
																				</asp:Label>
																				<asp:Label ID="lblApprGrpID" Runat=server text='<%#DataBinder.Eval(Container.Dataitem,"Approval_Group_ID")%>' Visible=False>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid>--%>
                                                                <dx:ASPxGridView ID="dgrdApproverGroups" KeyFieldName="Approval_Group_ID" Width="50%"
                                                                    runat="server" AutoGenerateColumns="False">
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="5%" Caption="Select"
                                                                            VisibleIndex="1">
                                                                            <DataItemTemplate>
                                                                                <asp:CheckBox ID="chkAppGrp" runat="server"></asp:CheckBox>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="30%" Caption="Approver Group Name"
                                                                            VisibleIndex="2">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblApprGrpName" runat="server" Text='<%#Eval("Approval_Group_Name")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblApprGrpID" runat="server" Text='<%#Eval("Approval_Group_ID")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <SettingsPager Mode="ShowAllRecords">
                                                                    </SettingsPager>                                                                  
                                                                    <Styles>
                                                                        <Header Font-Bold="true" BackColor="#FFCC00">
                                                                        </Header>
                                                                    </Styles>
                                                                </dx:ASPxGridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="FieldNames" valign="top" align="right">
                                                                New Approver Name:&nbsp;&nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txtNewApproverName" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox><font
                                                                    class="astrisk">*</font>
                                                                <asp:ImageButton ID="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                    CausesValidation="False"></asp:ImageButton>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imgChgApprName" OnClick="imgChgApprName_Click" runat="server"
                                                                    ImageUrl="../Images/Change-Approver-Name.gif"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ValidationSummary ID="approverValdSummary" runat="server" ShowSummary="False"
                                                                    ShowMessageBox="True" BorderStyle="None" DisplayMode="List"></asp:ValidationSummary>
                                                                <asp:CustomValidator ID="cstvdApprName" runat="server" ClientValidationFunction="CheckApproverName"
                                                                    ErrorMessage="Please Select New Approver Name." ControlToValidate="drpApproverName"
                                                                    Display="None"></asp:CustomValidator><asp:CustomValidator ID="cstvdFuncName" runat="server"
                                                                        ClientValidationFunction="CheckFunctionName" ErrorMessage="Please Select Function Name."
                                                                        ControlToValidate="drpFunction" Display="None"></asp:CustomValidator>
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
                        <uc1:Footer ID="adminHomeFooter" runat="server"></uc1:Footer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
