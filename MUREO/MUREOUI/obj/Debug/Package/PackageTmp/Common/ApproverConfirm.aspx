<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproverConfirm.aspx.cs"
    Inherits="MUREOUI.Common.ApproverConfirm" EnableViewStateMac="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ApproverConfirm</title>
    <base target="_self">
    <%-- <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">--%>
    <script language="javascript" type="text/javascript">
        function hourglass() {
            document.body.style.cursor = "wait";
            }

        function closeWindow(s) {
            window.close();

        }

        function test() {
            alert("Sending mails. Please wait a moment..");

        }


        function doHourglass() {
            document.body.style.cursor = 'wait';
        }

        function undoHourglass() {
            document.body.style.cursor = 'auto';
        }     
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="tabMain" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr id="trYesNo" align="center" runat="server">
            <td>
                <table id="tab1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                    <tr height="40">
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblYesNo" runat="server">Are you sure  to approve this EO?</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblDecline" runat="server">Are you sure  to decline this EO?</asp:Label>
                        </td>
                    </tr>
                    <tr height="30">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnYes" runat="server" Text="Yes" Width="75px" OnClick="btnYes_Click">
                            </asp:Button>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnNo" runat="server" Text="No" Width="75px"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="TrSmartClearance" align="center" runat="server">
            <td>
                <table id="tabSMARTClearance" cellspacing="0" cellpadding="0" width="100%" align="center"
                    border="0">
                    <tr>
                        <td align="center">
                            Enter SMART Clearance # here :
                            <asp:TextBox ID="txtSmartClearance" runat="server" Width="250px" TextMode="MultiLine"
                                MaxLength="53"></asp:TextBox>&nbsp;
                            <asp:RegularExpressionValidator ID="rgvdSmart" Display="None" ErrorMessage="Please enter value in this format: sets of 9-character strings of any format (number or letter) separated by a comma and space (up to 5 strings or 53 characters) EXAMPLE: RQ1234567, RQ0000000."
                                ValidationExpression="^(|\w{9}(, \w{9}){0,4})$" ControlToValidate="txtSmartClearance"
                                runat="server"></asp:RegularExpressionValidator>
                        </td>
                        <asp:RequiredFieldValidator ID="rqdSmart" runat="server" Display="None" ErrorMessage="Please enter Smart Clearance Number"
                            ControlToValidate="txtSmartClearance"></asp:RequiredFieldValidator>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="TrSAPIO" align="center" runat="server">
            <td>
                <table id="tabSAPIO" cellspacing="0" cellpadding="0" width="100%" align="center"
                    border="0">
                    <tr>
                        <td align="center">
                            Enter SAPIO # here :
                            <asp:TextBox ID="txtSAPIO" runat="server" Width="250px" TextMode="SingleLine" MaxLength="20"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trComments" align="center" runat="server">
            <td>
                <table id="tab3" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                    <tr height="10">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            Enter Comments here :&nbsp;&nbsp; &nbsp;
                            <asp:TextBox ID="txtCommnets" runat="server" Width="375px" TextMode="MultiLine" Height="56px"
                                ViewStateMode="Enabled"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr height="10">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
      
                            <asp:Button ID="btnSubmit" runat="server" Width="75px" Text="Ok" OnClientClick="test()" OnClick="btnSubmit_Click1">
                            </asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="vdsmSmart" runat="server" DisplayMode="BulletList"></asp:ValidationSummary>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
