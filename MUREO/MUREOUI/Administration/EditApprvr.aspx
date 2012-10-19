<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditApprvr.aspx.cs" Inherits="MUREOUI.Administration.EditApprvr" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Edit Approver</title>
    <meta content="False" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function AddBooksingUser() {
//            var popResult;
//            var apprvr = document.getElementById('txtApprover').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + apprvr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtApprover').value = popResult;
//            }
//            if (document.getElementById('txtApprover').value == 'undefined') {
//                document.getElementById('txtApprover').value = apprvr;
            //            }
            var popres;
            popres = document.getElementById('txtApprover').value;
            var strtxtApprover = document.getElementById("<%=txtApprover.ClientID %>").id;
            var hdntxtApprover = document.getElementById("<%=hdntxtApprover.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtApprover + '&Hidd=' + hdntxtApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtApprover + '&Hidd=' + hdntxtApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td>
                            <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="left" width="20%">
                                            <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                            </uc1:LeftNavigationControlForAdmin>
                                        </td>
                                        <td valign="top" align="center" width="80%">
                                            <table id="tbl5" cellspacing="0" cellpadding="0" width="100%">
                                                <tr height="5">
                                                    <td>
                                                        <table id="tbl2" width="100%">
                                                            <tr valign="middle" bgcolor="#ffffcc">
                                                                <td class="FormHeader" align="center">
                                                                    Edit EO Authorized Approver
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton>&nbsp;
                                                                    <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" ImageUrl="../images/cancel.gif" runat="server" CausesValidation="False">
                                                                    </asp:ImageButton>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="astrisk" align="center">
                                                                    *- Mandatory Fields
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="center">
                                                                    <table id="tbl3" height="3" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%" valign="top" align="right">
                                                                                Approver:
                                                                            </td>
                                                                            <td valign="top" class="astrisk" align="left">
                                                                                <asp:TextBox ID="txtApprover" runat="server" Width="232px" MaxLength="200"></asp:TextBox>&nbsp;
                                                                                <asp:ImageButton ID="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                                </asp:ImageButton>&nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="1">
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%" valign="top" align="right">
                                                                                Function:
                                                                            </td>
                                                                            <td valign="top" class="astrisk" align="left">
                                                                                <asp:DropDownList ID="drpFunction" runat="server" Width="232px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="1">
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%" valign="top" align="right" style="height: 23px">
                                                                                &nbsp;Site:
                                                                            </td>
                                                                            <td valign="top" style="height: 23px" class="astrisk" align="left">
                                                                                <asp:DropDownList ID="drpPlant" runat="server" Width="232px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
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
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField ID="hdntxtApprover" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
