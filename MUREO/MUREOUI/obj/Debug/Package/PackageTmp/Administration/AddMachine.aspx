<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMachine.aspx.cs" Inherits="MUREOUI.Administration.AddMachine" %>

<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Maintain Paper Machine Information</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
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
                                        <table width="100%">
                                            <tr>
                                                <td valign="top">
                                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td valign="top" align="center">
                                                                <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                                    <tr valign="middle" bgcolor="#ffffcc" id="trCrPM" runat="server">
                                                                        <td class="FormHeader" align="center" colspan="2">
                                                                            Create Paper Machine
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="middle" bgcolor="#ffffcc" id="trEdPM" runat="server">
                                                                        <td class="FormHeader" align="center" colspan="2">
                                                                            Edit Paper Machine
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:ImageButton ID="imgSubmit" ImageUrl="../Images/submit.gif"
                                                                                runat="server" onclick="imgSubmit_Click"></asp:ImageButton>&nbsp;
                                                                            <asp:ImageButton ID="imgCancel" ImageUrl="../images/cancel.gif"
                                                                                runat="server" CausesValidation="False" onclick="imgCancel_Click"></asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trMFields" runat="server">
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
                                                                        <td valign="top">
                                                                            <table id="tbl3" border="0">
                                                                                <tr>
                                                                                    <td class="FieldNames" valign="top" align="right">
                                                                                        Plant Name:&nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:DropDownList ID="drpPlantName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPlantName_SelectedIndexChanged"
                                                                                            Width="200">
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
                                                                                    <td class="FieldNames" valign="top" align="right" rowspan="2">
                                                                                        Machine Name:&nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td valign="top" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                        <asp:TextBox ID="txtMachineName" runat="server" Width="200" MaxLength="50"></asp:TextBox><font
                                                                                            class="astrisk">*</font>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="FieldNames" valign="top" align="right">
                                                                                        Machine Names:&nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:ListBox ID="lstMachineName" 
                                                                                            runat="server" AutoPostBack="True" Width="200" Height="70" 
                                                                                            onselectedindexchanged="lstMachineName_SelectedIndexChanged"></asp:ListBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:HiddenField ID="txthiddenMachineID" runat="server" />
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                                                                BorderStyle="None" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
                                                                            <asp:CustomValidator ID="cstdvdPlantName" runat="server" Display="None" ControlToValidate="drpPlantName"
                                                                                ErrorMessage="Please select Plant Name." ClientValidationFunction="CheckPlantName"></asp:CustomValidator>
                                                                            <asp:RequiredFieldValidator ID="ReqvdMachineName" runat="server" Display="None" ControlToValidate="txtMachineName"
                                                                                ErrorMessage="Please enter Machine Name."></asp:RequiredFieldValidator>
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
                                    <td colspan="2">
                                        <uc1:Footer ID="Footer1" runat="server"></uc1:Footer>
                                    </td>
                                </tr>
                            </table>
                            </form>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
