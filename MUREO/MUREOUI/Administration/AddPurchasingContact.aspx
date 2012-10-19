<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPurchasingContact.aspx.cs"
    Inherits="MUREOUI.Administration.AddPurchasingContact" %>

<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>AddPurchasingContact</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function AddBooksingUser() {

            var popres;
            popres = document.getElementById('txtApprover').value;
            var strtxtApprover = document.getElementById("<%=txtApprover.ClientID %>").id;
            var hdntxtApprover = document.getElementById("<%=hdntxtApprover.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtApprover + '&Hidd=' + hdntxtApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtApprover + '&Hidd=' + hdntxtApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var pCont = document.getElementById('txtApprover').value
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + pCont, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtApprover').value = popResult;
            //		        }
            //		        if (document.getElementById('txtApprover').value == 'undefined') {
            //		            document.getElementById('txtApprover').value = sysOwner;
            //		        }
            //		        return false;
        }

        //		    function AddBookMultiUser1() {
        //		        var popResult;
        //		        popResult = window.showModalDialog('../Common/ShowUsers.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
        //		        if (popResult != "")
        //		        { document.getElementById('txtApprover').value = popResult; }
        //		        if (document.getElementById('txtApprover').value == 'undefined') {
        //		            document.getElementById('txtApprover').value = "";
        //		        }
        //		    }
        function AddBookMultiUser() {
            var popResult;
            var popres;
            popres = document.getElementById('txtApprover').value;
            if (popres != "") {
                popResult = window.showModalDialog('../Common/ShowUsers.aspx?ShowUserList=' + popres, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
                if (popResult != "")
                { document.getElementById('txtApprover').value = popResult; }
                if (document.getElementById('txtApprover').value == 'undefined') {
                    document.getElementById('txtApprover').value = "";
                }
            }
            else {
                popResult = window.showModalDialog('../Common/ShowUsers.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
                if (popResult != "")
                { document.getElementById('txtApprover').value = popResult; }
                if (document.getElementById('txtApprover').value == 'undefined') {
                    document.getElementById('txtApprover').value = "";
                }
            }
        }

        function AllowPhoneChk(e) {
            var iKeyCode = 0;
            if (window.event)
                iKeyCode = window.event.keyCode
            else if (e)
                iKeyCode = e.which;
            if ((iKeyCode == 40) || (iKeyCode == 41) || (iKeyCode == 43) || (iKeyCode == 45) || (iKeyCode > 47 && iKeyCode < 58))
                return true;
            else
                return false;
        }


        function CheckPlantName(sender, args) {
            if (document.getElementById('drpPlantName').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }


        function CheckMaterialType(sender, args) {
            if (document.getElementById('drpMaterialType').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
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
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" width="100%">
                                        <tr id="trCreatePC" valign="middle" bgcolor="#ffffcc" runat="server">
                                            <td class="FormHeader" align="center">
                                                Create EO Purchasing Contact
                                            </td>
                                        </tr>
                                        <tr id="trEditPC" valign="middle" bgcolor="#ffffcc" runat="server">
                                            <td class="FormHeader" align="center">
                                                Edit EO Purchasing Contact
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:HiddenField ID="txtHiddenPurchaseContactID" runat="server" />
                                                <asp:ImageButton ID="imgSubmit" ValidationGroup="Save" OnClick="imgSubmit_Click"
                                                    runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../images/cancel.gif"
                                                    CausesValidation="False"></asp:ImageButton>&nbsp;
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
                                            <td valign="top">
                                                <table id="tbl3" height="3" width="100%" align="left" border="0">
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right" width="50%">
                                                            Plant:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="drpPlantName" runat="server" Width="200">
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
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Material Type:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="drpMaterialType" runat="server" Width="200">
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
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Approver Name:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:TextBox ID="txtApprover" runat="server" Width="200" ReadOnly="True" MaxLength="50"></asp:TextBox><font
                                                                class="astrisk">*</font>
                                                            <asp:HiddenField ID="hdntxtApprover" runat="server" />
                                                            <asp:ImageButton ID="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                CausesValidation="False"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr height="1">
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Phone Number:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <%--onkeypress="javascript: return AllowPhoneChk(event);"--%>
                                                            <asp:TextBox ID="txtPhoneNumber" runat="server" Width="200" MaxLength="15"></asp:TextBox>
                                                           <%-- <asp:RegularExpressionValidator ID="regphnoe" runat="server" ControlToValidate="txtPhoneNumber"
                                                                ValidationGroup="Save" Display="None" ForeColor="Red" ErrorMessage="Please enter valid Phone Number." ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr height="1">
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ValidationSummary ID="PurchaseValidationSummary" runat="server" ValidationGroup="Save"
                                                                ShowSummary="False" ShowMessageBox="True" BorderStyle="None" DisplayMode="List">
                                                            </asp:ValidationSummary>
                                                            <asp:CustomValidator ID="cstvdPlantName" ValidationGroup="Save" runat="server" ClientValidationFunction="CheckPlantName"
                                                                ErrorMessage="Please Select Plant Name." ControlToValidate="drpPlantName" Display="None"></asp:CustomValidator><asp:CustomValidator
                                                                    ID="cstvdMaterialType" ValidationGroup="Save" runat="server" ClientValidationFunction="CheckMaterialType"
                                                                    ErrorMessage="Please Select Material Type." ControlToValidate="drpMaterialType"
                                                                    Display="None"></asp:CustomValidator><asp:RequiredFieldValidator ValidationGroup="Save"
                                                                        ID="ReqvdApproverName" runat="server" ErrorMessage="Please Select Approver Name."
                                                                        ControlToValidate="txtApprover" Display="None"></asp:RequiredFieldValidator>
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
                        <uc1:Footer ID="adminHomeFooter" runat="server"></uc1:Footer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
