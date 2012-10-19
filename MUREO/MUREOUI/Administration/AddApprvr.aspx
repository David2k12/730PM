<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddApprvr.aspx.cs" Inherits="MUREOUI.Administration.AddApprvr" %>

<%--<%@Register tagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx"%>--%>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Add Approver</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function AddBookMultiUser() {
            var popResult;
            popResult = window.showModalDialog('../Common/ShowUsers.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            if (popResult != "") {
                document.getElementById('txtAuthApprover').value = popResult;
            }
            if (document.getElementById('txtAuthApprover').value == 'undefined') {
                document.getElementById('txtAuthApprover').value = "";
            }
        }

        function AddBooksingUser() {
            //            var popResult;
            //            var approver = document.getElementById('txtAuthApprover').value
            //            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //            if (popResult != "") {
            //                document.getElementById('txtAuthApprover').value = popResult;
            //            }
            //            if (document.getElementById('txtAuthApprover').value == 'undefined') {
            //                document.getElementById('txtAuthApprover').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtAuthApprover').value;
            var strtxtAuthApprover = document.getElementById("<%=txtAuthApprover.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtAuthApprover.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
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
                        <td style="height: 23px">
                            <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                                <tbody>
                                    <tr>
                                        <td valign="top" align="left" width="20%">
                                            <uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin>
                                        </td>
                                        <td valign="top" align="center" width="80%">
                                            <table id="tbl5" cellspacing="0" cellpadding="0" width="100%">
                                                <tr height="5">
                                                    <td>
                                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                            <tr valign="middle" bgcolor="#ffffcc">
                                                                <td align="center" colspan="5">
                                                                    <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                                    </font>
                                                                    <div>
                                                                        <strong><font class="FormHeader" face="Arial" color="#0000ff" size="4">Create Authorized&nbsp;Approver</font></strong></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:HiddenField ID="hdntxtAuthApprover" runat="server" />
                                                                    <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" ValidationGroup="Save"
                                                                        runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton>&nbsp;
                                                                    <asp:ValidationSummary ID="AddAuthApprov" ValidationGroup="Save" runat="server" DisplayMode="List"
                                                                        ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                                                                    <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif"></asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr height="10">
                                                                <td align="center" class="astrisk">
                                                                    *- Mandatory Fields
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%">
                                                                                New Approver:
                                                                            </td>
                                                                            <td width="50%">
                                                                                <p class="astrisk">
                                                                                    <asp:TextBox ID="txtAuthApprover" runat="server" MaxLength="200" Width="232px"></asp:TextBox>&nbsp;
                                                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtAuthApprover"
                                                                                        runat="server" ControlToValidate="txtAuthApprover" ErrorMessage="Please select an Approver from the address book" />
                                                                                    <asp:ImageButton ID="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                                    </asp:ImageButton>&nbsp;*
                                                                                </p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%">
                                                                                Function:
                                                                            </td>
                                                                            <td>
                                                                                <p class="astrisk" align="left">
                                                                                    <asp:DropDownList ID="drpFunction" runat="server" Width="232px">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;*
                                                                                    <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="ReqdrpFunction"
                                                                                        runat="server" ControlToValidate="drpFunction" InitialValue="-- Select a Function --"
                                                                                        ErrorMessage="Please select Function Name" />
                                                                                </p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" width="50%">
                                                                                Site:
                                                                            </td>
                                                                            <td class="astrisk">
                                                                                <asp:DropDownList ID="drpPlant" runat="server" Width="232px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                                <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqdrpPlant"
                                                                                    runat="server" ControlToValidate="drpPlant" InitialValue="-- Select a Plant --"
                                                                                    ErrorMessage="Please select Plant Name" />
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
        <Triggers>
        <asp:PostBackTrigger ControlID="imgSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
    </TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
</body>
</html>
