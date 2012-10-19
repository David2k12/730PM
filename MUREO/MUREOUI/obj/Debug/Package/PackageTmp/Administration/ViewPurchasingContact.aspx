<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPurchasingContact.aspx.cs"
    Inherits="MUREOUI.Administration.ViewPurchasingContact" %>

<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>ViewPurchasingContact</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <uc1:Header ID="Header1" runat="server"></uc1:Header>
            </td>
        </tr>
        <tr>
            <td style="height: 320px">
                <table width="100%" cellpadding="0" cellspacing="0" border="1">
                    <tr>
                        <td width="20%">
                            <uc1:LeftNavigation ID="LeftNavigation1" runat="server"></uc1:LeftNavigation>
                        </td>
                        <td valign="top">
                            <table id="tbl2" width="100%">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" align="center">
                                        View EO Purchasing Contact
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:HiddenField ID="txthiddenPlantID" runat="server" />
                                        <asp:HiddenField ID="txthiddenMaterialID" runat="server" />
                                        <asp:HiddenField ID="txthiddenPurchaseContactId" runat="server" />
                                        <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/edit.gif"></asp:ImageButton>&nbsp;
                                        <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../images/cancel.gif" CausesValidation="False">
                                        </asp:ImageButton>&nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="../images/delete.gif" Visible="False">
                                        </asp:ImageButton>
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
                                                    <asp:Label ID="lblPlantName" Width="200" runat="server"></asp:Label>
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
                                                    <asp:Label ID="lblMaterialType" runat="server" Width="200"></asp:Label>
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
                                                    <asp:Label ID="lblApprover" Width="200" runat="server"></asp:Label>
                                                </td>
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
                                                        <asp:Label ID="lblPhoneNumber" Width="200" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr height="1">
                                                    <td>
                                                        &nbsp;
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
    </form>
</body>
</html>
