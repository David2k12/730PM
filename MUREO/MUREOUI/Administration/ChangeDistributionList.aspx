<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDistributionList.aspx.cs"
    Inherits="MUREOUI.Administration.ChangeDistributionList" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/LeftNavigationControlForAdmin.ascx" TagName="LeftNavigationControlForAdmin"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChangeDistributionList</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function closeWindow(s) {
            window.close();
        }
        function doHourglass() {
            document.body.style.cursor = 'wait';
        }

        function undoHourglass() {
            document.body.style.cursor = 'auto';
        }


        function AddBooksingUserCCEO() {
//            var popResult;
//            var approver = document.getElementById('txtCCEO').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtCCEO').value = popResult;
//            }
//            if (document.getElementById('txtCCEO').value == 'undefined') {
//                document.getElementById('txtCCEO').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtCCEO').value;
            var strtxtAuthApprover = document.getElementById("<%=txtCCEO.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtCCEO.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }

        function AddBooksingUserMDC() {
//            var popResult;
//            var approver = document.getElementById('txtMDC').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtMDC').value = popResult;
//            }
//            if (document.getElementById('txtMDC').value == 'undefined') {
//                document.getElementById('txtMDC').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtMDC').value;
            var strtxtAuthApprover = document.getElementById("<%=txtMDC.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtMDC.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }
        function AddBooksingUserPC() {
//            var popResult;
//            var approver = document.getElementById('txtPC').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtPC').value = popResult;
//            }
//            if (document.getElementById('txtPC').value == 'undefined') {
//                document.getElementById('txtPC').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtPC').value;
            var strtxtAuthApprover = document.getElementById("<%=txtPC.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtPC.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }

        function AddBooksingUserAS() {
//            var popResult;
//            var approver = document.getElementById('txtAS').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtAS').value = popResult;
//            }
//            if (document.getElementById('txtAS').value == 'undefined') {
//                document.getElementById('txtAS').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtAS').value;
            var strtxtAuthApprover = document.getElementById("<%=txtAS.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtAS.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }
    </script>
</head>
<body onfocus="undoHourglass();" bottommargin="0" onbeforeunload="doHourglass();"
    leftmargin="0" topmargin="0" rightmargin="0" onunload="doHourglass();" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td>
                    <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                        <tr>
                            <td valign="top" align="left" width="20%">
                                <uc2:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server" />
                                <asp:HiddenField ID="hdntxtCCEO" runat="server" />
                                <asp:HiddenField ID="hdntxtMDC" runat="server" />
                                <asp:HiddenField ID="hdntxtPC" runat="server" />
                                <asp:HiddenField ID="hdntxtAS" runat="server" />
                            </td>
                            <td valign="top" align="center" width="80%">
                                <table id="tbl2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr valign="middle" bgcolor="#ffffcc">
                                        <td class="FormHeader" align="center" colspan="2">
                                            Change Distribution List
                                        </td>
                                    </tr>
                                    <tr height="20">
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FieldNames" style="height: 26px" width="46%">
                                            CloseOut Complete EO : &nbsp;
                                        </td>
                                        <td align="left" style="height: 26px">
                                            <asp:TextBox ID="txtCCEO" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;
                                            <asp:ImageButton ID="imgAddBookCCEO" ToolTip="Please select CloseOut Complete EO" runat="server" ImageUrl="../Images/addressbook.gif">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr height="20">
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="FieldNames">
                                            Master Data Coordinator :&nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMDC" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;
                                            <asp:ImageButton ID="imgAddBookMDC" ToolTip="Please select Master Data Coordinator" runat="server" ImageUrl="../Images/addressbook.gif">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr height="20">
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FieldNames">
                                            Purchasing Contacts : &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPC" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;
                                            <asp:ImageButton ID="imgAddressBookPC" ToolTip="Please select Purchasing Contacts" runat="server" ImageUrl="../Images/addressbook.gif">
                                            </asp:ImageButton>&nbsp;
                                        </td>
                                    </tr>
                                    <tr height="20">
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="FieldNames">
                                            Analytical Services : &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAS" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;
                                            <asp:ImageButton ID="imageAddBookAS" ToolTip="Please select Analytical Services" runat="server" ImageUrl="../Images/addressbook.gif">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr height="20">
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:ImageButton ID="imgUpdate" runat="server" ImageUrl="../Images/submit.gif" OnClick="imgUpdate_Click">
                                            </asp:ImageButton>&nbsp;
                                            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" OnClick="imgCancel_Click">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" height="20">
                                        </td>
                                    </tr>
                                    <tr height="5">
                                        <td align="center" colspan="2">
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
                    <uc3:FooterControl ID="FooterControl1" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    </TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
</body>
</html>
