<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYI.aspx.cs" Inherits="MUREOUI.Common.FYI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FYI</title>
    <base target="_self" />
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function AddBookMultiUser() {
            var strTxtPrjLead = document.getElementById("<%=txtUserNames.ClientID %>").id;
            var hdntxtprjlead = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
            window.open('ShowUsers.aspx?ID=' + strTxtPrjLead + '&Hidd=' + hdntxtprjlead, 'ShowUsers', 'menubar=0,resizable=1,width=800,height=450');
            return false;
        }

//        function AddBookMultiUser() {
//            var popResult;
//            popResult = window.showModalDialog('ShowUsers.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            //popResult = window.showModalDialog('ShowUser.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:500px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtUserNames').value = popResult;
//            }
//            if (document.getElementById('txtUserNames').value == 'undefined') {
//                document.getElementById('txtUserNames').value = "";
//            }
//        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table id="tblMail" style="z-index: 101; left: 40px; position: absolute; top: 16px"
        cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td><asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                <b>FYI Name:</b>
                <asp:TextBox ID="txtUserNames" ReadOnly="True" runat="server" Width="250px"></asp:TextBox><font
                    class="astrisk">*</font>
                <asp:ImageButton ID="imgAddressBook" CausesValidation="False" ImageUrl="../Images/addressbook.gif"
                    runat="server"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <!--<TR>
					<TD><asp:linkbutton id="lnkAddBook" runat="server">LookUp Names</asp:linkbutton></TD>
				</TR>-->
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>Please enter your comments below...</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtComments" runat="server" Width="408px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr height="10">
            <td>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgSendFYI" runat="server" ImageUrl="../Images/Send-FYI.jpg"
                    CausesValidation="true" onclick="imgSendFYI_Click"></asp:ImageButton>&nbsp;
                <asp:ImageButton ID="imgCanc" runat="server" ImageUrl="../Images/Cancel.gif" 
                    CausesValidation="False" onclick="imgCanc_Click">
                </asp:ImageButton>
                <asp:ValidationSummary ID="fyiVdsummary" runat="server" ShowSummary="False" ShowMessageBox="True"
                    BorderStyle="None" DisplayMode="List"></asp:ValidationSummary>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="ReqvdApproverName" runat="server" ErrorMessage="Enter FYI Name."
                    ControlToValidate="txtUserNames" Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
