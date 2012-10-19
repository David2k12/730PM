<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBudgetCenter.aspx.cs"
    Inherits="MUREOUI.Administration.AddBudgetCenter" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Add Budget Center</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function AddBookSingUser1() {
            var popres;
            popres = document.getElementById("<%=txtTowel.ClientID %>").value;
            var strtxtTowel = document.getElementById("<%=txtTowel.ClientID %>").id;
            var hdntxtTowel = document.getElementById("<%=hdntxtTowel.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtTowel + '&Hidd=' + hdntxtTowel, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtTowel + '&Hidd=' + hdntxtTowel, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var towel_appr = document.getElementById('txtTowel').value
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + towel_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtTowel').value = popResult;
            //		        }
            //		        if (document.getElementById('txtTowel').value == 'undefined') {
            //		            document.getElementById('txtTowel').value = towel_appr;
            //		        }
        }
        function AddBookSingUser2() {
            var popres;
            popres = document.getElementById("<%=txtBath.ClientID %>").value;
            var strtxtBath = document.getElementById("<%=txtBath.ClientID %>").id;
            var hdntxtBath = document.getElementById("<%=hdntxtBath.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtBath + '&Hidd=' + hdntxtBath, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtBath + '&Hidd=' + hdntxtBath, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var bath_appr = document.getElementById('txtBath').value
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + bath_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtBath').value = popResult;
            //		        }
            //		        if (document.getElementById('txtBath').value == 'undefined') {
            //		            document.getElementById('txtBath').value = bath_appr;
            //		        }
        }
        function AddBookSingUser3() {
            var popres;
            popres = document.getElementById("<%=txtTissue.ClientID %>").value;
            var strtxtTissue = document.getElementById("<%=txtTissue.ClientID %>").id;
            var hdntxtTissue = document.getElementById("<%=hdntxtTissue.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtTissue + '&Hidd=' + hdntxtTissue, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtTissue + '&Hidd=' + hdntxtTissue, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
            //		        var popResult;
            //		        var tissue_appr = document.getElementById('txtTissue').value
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + tissue_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtTissue').value = popResult;
            //		        }
            //		        if (document.getElementById('txtTissue').value == 'undefined') {
            //		            document.getElementById('txtTissue').value = tissue_appr;
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
            //		        var default_appr = document.getElementById('txtDefault').value
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
            //		        var SAPCCC = document.getElementById('txtSAPCCC').value
            //		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + SAPCCC, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            //		        if (popResult != "") {
            //		            document.getElementById('txtSAPCCC').value = popResult;
            //		        }
            //		        if (document.getElementById('txtSAPCCC').value == 'undefined') {
            //		            document.getElementById('txtSAPCCC').value = SAPCCC;
            //		        }
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
        function ConfirmDelete() {            
                if (confirm('Are you sure you want to delete the SAP Cost Center Coordinator name? Click OK to delete or CANCEL to abort.')) {
                    //return true;
                    document.getElementById("<%=txtSAPCCC.ClientID %>").value = "";
                    document.getElementById("<%=hdntxtSAPCCC.ClientID %>").value = "";                    
                    return false;
                }
                else {
                    return false;
                }                       
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
      <asp:ScriptManager ID="scp1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upbudget" runat="server">
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
                                                                <strong><font face="Arial" color="#0000ff" size="4" class="FormHeader">Create Budget
                                                                    Center&nbsp;</font></strong></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="5">
                                                            <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" ValidationGroup="Save" runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton>&nbsp;
                                                            <asp:ValidationSummary ID="AddEditBudgetcenter" ValidationGroup="Save" runat="server" DisplayMode="List" ShowSummary="False"
                                                                        ShowMessageBox="True"></asp:ValidationSummary>
                                                            <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table id="Table1" cellspacing="0" cellpadding="1" width="100%" border="0">
                                                                <tr>
                                                                    <td class="astrisk" align="center" colspan="2">
                                                                        <p>
                                                                            * - Mandatory Fields</p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        <font size="3">Budget Center Number and Name: </font>
                                                                    </td>
                                                                    <td width="50%" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                        <asp:TextBox ID="txtBdgtCtrName" runat="server" Width="232px"></asp:TextBox>
                                                                        <asp:Label ID="lblAstrx" runat="server" CssClass="Astrisk">*</asp:Label>&nbsp;
                                                                          <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtBdgtCtrName" runat="server" ControlToValidate="txtBdgtCtrName"
                                                                                     ErrorMessage="Please enter Budget Center Name" />  
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                    </td>
                                                                    <td class="FieldNamesLeft" width="50%">
                                                                        Ex:0510- R&amp;D Global Leadline
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" width="50%">
                                                                        Plant:
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        <asp:DropDownList ID="drpPlant" runat="server" Width="232px">
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="Label1" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                         <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqdrpPlant" runat="server" ControlToValidate="drpPlant"
                                                                                    InitialValue="-- Select a Plant --" ErrorMessage="Please select a Plant" />
                                                                        
                                                                        
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames">
                                                                        Area:
                                                                    </td>
                                                                    <td class="astrisk">
                                                                        <asp:DropDownList ID="drpArea" runat="server" Width="232px">
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="Label2" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                        <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqdrpArea" runat="server" ControlToValidate="drpArea"
                                                                                    InitialValue="-- Select a Area --" ErrorMessage="Please select a Area" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2">
                                                                        <strong>Budget Center Approvers</strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" style="height: 25px">
                                                                        Bounty:
                                                                    </td>
                                                                    <td style="height: 25px">
                                                                        <asp:TextBox ID="txtTowel" runat="server" Width="231px" ReadOnly="True"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdntxtTowel" runat="server" />
                                                                        <asp:ImageButton ID="imgAddrbkTowel" ToolTip="Please select a Bounty Approver" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:Label ID="Label3" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                        <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtTowel" runat="server" ControlToValidate="txtTowel"
                                                                                     ErrorMessage="Please select a Bounty Approver" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames" style="height: 25px">
                                                                        Charmin:
                                                                    </td>
                                                                    <td style="height: 25px">
                                                                        <asp:TextBox ID="txtBath" runat="server" Width="231px" ReadOnly="True"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdntxtBath" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrbkBath" ToolTip="Please select a Charmin Approver" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:Label ID="Label4" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                        <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtBath" runat="server" ControlToValidate="txtBath"
                                                                                     ErrorMessage="Please select a Charmin Approver" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames">
                                                                        Puffs:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTissue" runat="server" Width="231px" ReadOnly="True"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdntxtTissue" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrbkTissue" ToolTip="Please select a Puffs Approver" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:Label ID="Label5" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                        <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtTissue" runat="server" ControlToValidate="txtTissue"
                                                                                     ErrorMessage="Please select a Puffs Approver" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames">
                                                                        Default:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDefault" runat="server" Width="231px" ReadOnly="True"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdntxtDefault" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrbkDefault" ToolTip="Please select a Default Approver" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                        </asp:ImageButton>
                                                                        <asp:Label ID="Label21" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                          <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtDefault" runat="server" ControlToValidate="txtDefault"
                                                                                     ErrorMessage="Please select a Default Approver" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="FieldNames">
                                                                        SAP Cost Center Coordinator:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSAPCCC" runat="server" Width="231px" ReadOnly="True"></asp:TextBox>
                                                                        <asp:HiddenField ID="hdntxtSAPCCC" runat="server" />
                                                                        <asp:ImageButton ID="ImgAddrBkSAPCC" ToolTip="Please select a SAP Cost Center Coordinator" runat="server" ImageUrl="../Images/addressbook.gif">
                                                                        </asp:ImageButton>&nbsp;
                                                                        <asp:ImageButton ID="imgDeleteSAPCCC" OnClientClicks="return ConfirmDelete()" ToolTip="Delete SAP Cost Center Coordinator" runat="server" ImageUrl="../Images/del-name.jpg">
                                                                        </asp:ImageButton>                                                                        
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
    </ContentTemplate></asp:UpdatePanel>
    &nbsp;</form>    
</body>
</html>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          