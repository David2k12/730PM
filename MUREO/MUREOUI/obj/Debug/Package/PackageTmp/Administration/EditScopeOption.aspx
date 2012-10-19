<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditScopeOption.aspx.cs"
    Inherits="MUREOUI.Administration.EditScopeOption" %>

<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>EditScopeOption</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function AddBookSingUser1() {
            var popres;
            popres = document.getElementById("<%=txtBounty.ClientID %>").value;
            var strtxtBounty = document.getElementById("<%=txtBounty.ClientID %>").id;
            var hdntxtBounty = document.getElementById("<%=hdntxtBounty.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtBounty + '&Hidd=' + hdntxtBounty, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtBounty + '&Hidd=' + hdntxtBounty, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var bounty_appr = document.getElementById('txtBounty').value
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + bounty_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtBounty').value = popResult;
            //		        }
            //		        if (document.getElementById('txtBounty').value == 'undefined') {
            //		            document.getElementById('txtBounty').value = bounty_appr;
            //		        }
        }

        function AddBookSingUser2() {
            var popres;
            popres = document.getElementById("<%=txtCharmin.ClientID %>").value;
            var strtxtCharmin = document.getElementById("<%=txtCharmin.ClientID %>").id;
            var hdntxtCharmin = document.getElementById("<%=hdntxtCharmin.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtCharmin + '&Hidd=' + hdntxtCharmin, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtCharmin + '&Hidd=' + hdntxtCharmin, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var charmin_appr = document.getElementById('txtCharmin').value;
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + charmin_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');

            //		        if (popResult != "") {
            //		            document.getElementById('txtCharmin').value = popResult;
            //		        }
            //		        if (document.getElementById('txtCharmin').value == 'undefined') {
            //		            document.getElementById('txtCharmin').value = charmin_appr;
            //		        }
        }

        function AddBookSingUser3() {
            var popres;
            popres = document.getElementById("<%=txtPuffs.ClientID %>").value;
            var strtxtPuffs = document.getElementById("<%=txtPuffs.ClientID %>").id;
            var hdntxtPuffs = document.getElementById("<%=hdntxtPuffs.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtPuffs + '&Hidd=' + hdntxtPuffs, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtPuffs + '&Hidd=' + hdntxtPuffs, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var puffs_appr = document.getElementById('txtPuffs').value;
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + puffs_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtPuffs').value = popResult;
            //		        }
            //		        if (document.getElementById('txtPuffs').value == 'undefined') {
            //		            document.getElementById('txtPuffs').value = puffs_appr;
            //		        }
        }

        function AddBookSingUser4() {
            var popres;
            popres = document.getElementById("<%=txtDefault.ClientID %>").value;
            var strtxtDefault = document.getElementById("<%=txtDefault.ClientID %>").id;
            var hdntxtDefault = document.getElementById("<%=hdntxtDefault.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtDefault + '&Hidd=' + hdntxtDefault, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtDefault + '&Hidd=' + hdntxtDefault, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var default_appr = document.getElementById('txtDefault').value;
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + default_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtDefault').value = popResult;
            //		        }
            //		        if (document.getElementById('txtDefault').value == 'undefined') {
            //		            document.getElementById('txtDefault').value = default_appr;

            //		        }
        }

        function AddBookSingUser5() {
            var popres;
            popres = document.getElementById("<%=txtSAPCCC.ClientID %>").value;
            var strtxtSAPCCC = document.getElementById("<%=txtSAPCCC.ClientID %>").id;
            var hdntxtSAPCCC = document.getElementById("<%=hdntxtSAPCCC.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtSAPCCC + '&Hidd=' + hdntxtSAPCCC, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtSAPCCC + '&Hidd=' + hdntxtSAPCCC, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var SAPCCC = document.getElementById('txtSAPCCC').value;

            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + SAPCCC, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtSAPCCC').value = popResult;
            //		        }
            //		        if (document.getElementById('txtSAPCCC').value == 'undefined') {
            //		            document.getElementById('txtSAPCCC').value = SAPCCC;
            //		        }
        }
        function deleteuser() {
            document.getElementById("<%=txtSAPCCC.ClientID %>").value = "";
            document.getElementById("<%=hdntxtSAPCCC.ClientID %>").value = "";
            return false;
        }

        function NoSpecialCharacters() {
            var k;
            k = event.keyCode;

            if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
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
                        <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td valign="top" align="left" width="20%">
                                    <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                    </uc1:LeftNavigationControlForAdmin>
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
                                                                <strong><font class="FormHeader" face="Arial" color="#0000ff" size="4">Edit EO Scope
                                                                    Option</font></strong></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="5">
                                                            <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif">
                                                            </asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif">
                                                            </asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="astrisk" align="center" colspan="2">
                                                            *- Mandatory Fields
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        <font size="3">Scope Option: </font>
                                                                    </td>
                                                                    <td class="astrisk" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                        &nbsp;<asp:TextBox ID="txtScopeOption" runat="server" Width="232px"></asp:TextBox>&nbsp;*&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        &nbsp;<asp:DropDownList ID="drpBudget" runat="server" Width="232px" AutoPostBack="True"
                                                                            Visible="False">
                                                                        </asp:DropDownList>
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2">
                                                                        <strong></strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        &nbsp;<asp:TextBox ID="txtBounty" runat="server" Width="232px" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                                                        <asp:HiddenField ID="hdntxtBounty" runat="server" />
                                                                        <asp:ImageButton ID="imgAddrbkTowel" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                            Visible="False"></asp:ImageButton>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        &nbsp;<asp:TextBox ID="txtCharmin" runat="server" Width="232px" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                                                        <asp:HiddenField ID="hdntxtCharmin" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrbkBath" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                            Visible="False"></asp:ImageButton>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        &nbsp;<asp:TextBox ID="txtPuffs" runat="server" Width="232px" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                                                        <asp:HiddenField ID="hdntxtPuffs" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrbkTissue" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                            Visible="False"></asp:ImageButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        &nbsp;<asp:TextBox ID="txtDefault" runat="server" Width="232px" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                                                        <asp:HiddenField ID="hdntxtDefault" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrbkDefault" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                            Visible="False"></asp:ImageButton>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        <asp:Label ID="Label1" runat="server" Visible="False">SAP Cost Center Coordinator:</asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;<asp:TextBox ID="txtSAPCCC" runat="server" Width="232px" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                                                        <asp:HiddenField ID="hdntxtSAPCCC" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrBkSAPCC" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                            Visible="False"></asp:ImageButton>&nbsp;
                                                                        <asp:ImageButton ID="imgDeleteSAPCC" OnClientClick="return deleteuser();" ImageUrl="../Images/del-name.jpg"
                                                                            runat="server" Visible="False"></asp:ImageButton>
                                                                        <!--<asp:ImageButton id="imgDeleteSAPCCC" runat="server" ImageUrl="../Images/delete.gif"></asp:ImageButton>-->
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
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
