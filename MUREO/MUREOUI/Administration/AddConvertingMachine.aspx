<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddConvertingMachine.aspx.cs"
    Inherits="MUREOUI.Administration.AddConvertingMachine" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/LeftNavigationControlForAdmin.ascx" TagName="LeftNavigationControlForAdmin"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddConvertingMachine</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        function CheckPlantName(sender, args) {
            if (document.getElementById('drpPlantName').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckCategoryName(sender, args) {
            if (document.getElementById('drpCategoryName').selectedIndex == 0) {
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
<body>
    <form id="form1" runat="server">
    <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                    <tr>
                        <td width="200" style="width: 200px">
                            <uc2:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td valign="top" align="center" colspan="4">
                                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                            <tr id="trCCM" runat="server">
                                                                <td class="FormHeader" align="center" colspan="5">
                                                                    Create Convert Machine
                                                                </td>
                                                            </tr>
                                                            <tr id="trECM" runat="server">
                                                                <td class="FormHeader" align="center" colspan="5">
                                                                    Edit Convert Machine
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                    <asp:ImageButton ID="imgSubmit" TabIndex="5" ImageUrl="../Images/submit.gif" 
                                                                        runat="server" onclick="imgSubmit_Click">
                                                                    </asp:ImageButton>&nbsp;
                                                                    <asp:ImageButton ID="imgCancel" TabIndex="6" ImageUrl="../images/cancel.gif" runat="server"
                                                                        CausesValidation="False" onclick="imgCancel_Click"></asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="astrisk" align="center" colspan="4">
                                                                    *- Mandatory Fields
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table border="0">
                                                                        <tr>
                                                                            <td class="FieldNames" valign="top" align="right">
                                                                                Category Name:&nbsp;&nbsp;
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:DropDownList ID="drpCategoryName" TabIndex="1" runat="server" AutoPostBack="True"
                                                                                    Width="200" onselectedindexchanged="drpCategoryName_SelectedIndexChanged">
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
                                                                                Plant Name:&nbsp;&nbsp;
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:DropDownList ID="drpPlantName" TabIndex="2" runat="server" AutoPostBack="True"
                                                                                    Width="200" onselectedindexchanged="drpPlantName_SelectedIndexChanged">
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
                                                                                Machine Name:&nbsp;&nbsp;
                                                                            </td>
                                                                            <td valign="top" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <asp:TextBox ID="txtMachineName" TabIndex="3" runat="server" Width="200" MaxLength="50"></asp:TextBox><font
                                                                                    class="astrisk">*</font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <td valign="top">
                                                                        <table border="0">
                                                                            <tr>
                                                                                <td class="FieldNames" valign="top" align="right">
                                                                                    Machine Names:&nbsp;&nbsp;
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:ListBox ID="lstMachineName" TabIndex="4" runat="server" AutoPostBack="True"
                                                                                        Width="208px" Height="72px" 
                                                                                        onselectedindexchanged="lstMachineName_SelectedIndexChanged"></asp:ListBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                   
                                                                    <asp:HiddenField ID="hdntxthiddenMachineID" runat="server" />
                                                                    <asp:CustomValidator
                                                                        ID="cstvdCategoryName" runat="server" ClientValidationFunction="CheckCategoryName"
                                                                        ControlToValidate="drpCategoryName" Display="None" ErrorMessage="Please select Category Name."></asp:CustomValidator><asp:CustomValidator
                                                                            ID="cstdvdPlantName" runat="server" ClientValidationFunction="CheckPlantName"
                                                                            ControlToValidate="drpPlantName" Display="None" ErrorMessage="Please select Plant Name."></asp:CustomValidator><asp:RequiredFieldValidator
                                                                                ID="reqvdMachineName" runat="server" ControlToValidate="txtMachineName" Display="None"
                                                                                ErrorMessage="Please enter Machine Name."></asp:RequiredFieldValidator>
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
                        <td colspan="3">
                            <uc3:FooterControl ID="FooterControl1" runat="server" />
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="184px" DisplayMode="List"
                    ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
