<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewApprvr.aspx.cs" Inherits="MUREOUI.Administration.ViewApprvr" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>View Approver</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function AddBookMultiUser() {
            var popResult;
            popResult = window.showModalDialog('../Common/ShowUsers.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            document.getElementById('txtAuthApprover').value = popResult;
        }
        function AddBooksingUser() {
            var popResult;
            popResult = window.showModalDialog('../Common/ShowUser.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            document.getElementById('txtAuthApprover').value = popResult;
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
                                                                    View EO Authorized Approver
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="center">
                                                                    <asp:ImageButton ID="imgEdit" OnClick="imgEdit_Click" ImageUrl="../Images/edit.gif"
                                                                        runat="server"></asp:ImageButton>&nbsp;
                                                                    <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" ImageUrl="../images/cancel.gif"
                                                                        runat="server" CausesValidation="False"></asp:ImageButton>&nbsp;
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
                                                                            <td valign="top" align="left">
                                                                                <asp:Label ID="lblApproverName" runat="server" Width="232px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="1">
                                                                            <td width="50%">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%" valign="top" align="right">
                                                                                Function:
                                                                            </td>
                                                                            <td valign="top" align="left">
                                                                                <asp:Label ID="lblFunctionName" runat="server" Width="232px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="1">
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%" valign="top" align="right">
                                                                                &nbsp;Site:
                                                                            </td>
                                                                            <td valign="top" align="left">
                                                                                <asp:Label ID="lblSiteName" runat="server" Width="232px"></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>   
</body>
</html>
