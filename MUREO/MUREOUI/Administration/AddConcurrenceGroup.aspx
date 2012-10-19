<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddConcurrenceGroup.aspx.cs"
    Inherits="MUREOUI.Administration.AddConcurrenceGroup" %>

<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>AddConcurrenceGroup</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function AddBookMultiUse1r() {
            var popResult;
            popResult = window.showModalDialog('../Common/ShowUser.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            if (popResult != "")
            { document.getElementById('txtNameforGroup').value = popResult; }
            if (document.getElementById('txtNameforGroup').value == 'undefined') {
                document.getElementById('txtNameforGroup').value = "";
            }
        }
        function AddBookMultiUser() {
            var popres;
            popres = document.getElementById('<%=txtNameforGroup.ClientID %>').value;
            var strtxtNameforGroup = document.getElementById("<%=txtNameforGroup.ClientID %>").id;
            var hdntxtNameforGroup = document.getElementById("<%=hdntxtNameforGroup.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUsers.aspx?ID=' + strtxtNameforGroup + '&Hidd=' + hdntxtNameforGroup, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUsers.aspx?ShowUserList=' + popres + '&ID=' + strtxtNameforGroup + '&Hidd=' + hdntxtNameforGroup, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;

        }

        function test() 
        {
            //alert(document.getElementById("txtNameforGroup").value.length);
            if (document.getElementById("txtNameforGroup").value.length > 1000) {
                alert("Approver Name length should not exceed 1000 characters");
                document.getElementById("txtNameforGroup").value = "";
                return false;
            }
            else
                return true;
        }

        function CheckPlantName(sender, args) {
            if (document.getElementById('drpPlantName').selectedIndex == 0) {
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
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td width="20%">
                                    <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                                </td>
                                <td valign="top">
                                    <table id="tbl2" width="100%">
                                        <tr id="trCrCG" valign="middle" bgcolor="#ffffcc" runat="server">
                                            <td class="FormHeader" align="center">
                                                Create Concurrence Group
                                            </td>
                                        </tr>
                                        <tr id="trEdCG" valign="middle" bgcolor="#ffffcc" runat="server">
                                            <td class="FormHeader" align="center">
                                                Edit Concurrence Group
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:HiddenField ID="txtHiddenConGrpID" runat="server"/><asp:ImageButton
                                                    ID="imgSubmit" OnClientClick="if (!test()) return false;" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../images/cancel.gif" CausesValidation="False">
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
                                            <td valign="top">
                                                <table id="tbl3" height="3" width="100%" align="left" border="0">
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right" width="50%">
                                                            Plant:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="drpPlantName" runat="server">
                                                            </asp:DropDownList>
                                                            <font class="astrisk">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Concurrence Group Name:&nbsp;&nbsp;
                                                        </td>
                                                        <td onkeypress="javascript: return NoSpecialCharacters(event);" valign="top">
                                                            <asp:TextBox ID="txtConcurrenceGroupName" runat="server" Width="200" MaxLength="100"></asp:TextBox><font
                                                                class="astrisk">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" valign="top" align="right">
                                                            Approver Name for the Group:&nbsp;&nbsp;
                                                        </td>
                                                        <td valign="top">
                                                            <asp:TextBox ID="txtNameforGroup" runat="server" Width="200" MaxLength="50" ReadOnly="True"></asp:TextBox>
                                                            <asp:HiddenField ID="hdntxtNameforGroup" runat="server" />
                                                            
                                                            
                                                            <font
                                                                class="astrisk">*</font>
                                                            <asp:ImageButton ID="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                CausesValidation="False"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:CustomValidator ID="cstdvdPlantName" runat="server" ErrorMessage="Please select Plant Name."
                                        Display="None" ControlToValidate="drpPlantName" ClientValidationFunction="CheckPlantName"></asp:CustomValidator><asp:RequiredFieldValidator
                                            ID="reqvdConcurrenceGroupName" runat="server" ErrorMessage="Please enter Concurrence Group Name."
                                            Display="None" ControlToValidate="txtConcurrenceGroupName"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                ID="reqvdNameForGrp" runat="server" ErrorMessage="Please enter Name For Group."
                                                Display="None" ControlToValidate="txtNameforGroup"></asp:RequiredFieldValidator><asp:ValidationSummary
                                                    ID="CgrpValidationSummary" runat="server" Width="184px" ShowSummary="False" ShowMessageBox="True"
                                                    DisplayMode="List"></asp:ValidationSummary>
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
