<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEOScope.aspx.cs" Inherits="MUREOUI.Administration.ViewEOScope" %>

<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>ViewEOScope</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                                            <div class="FormHeader">
                                                                View EO Scope Option</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="5">
                                                            <asp:ImageButton ID="imgEdit" OnClick="imgEdit_Click" runat="server" ImageUrl="../Images/edit.gif">
                                                            </asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif">
                                                            </asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td class="DataGridBorderColor" align="center">
                                                            <p align="center">
                                                                <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                    <tr>
                                                                        <td class="FieldNames" width="50%">
                                                                            <font size="3">Scope Option: </font>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblScope" runat="server" Width="100%"></asp:Label>
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
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblBudget" runat="server" Width="100%" Visible="False"></asp:Label>
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
                                                                        <td align="center" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="FieldNames" width="50%">
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblBounty" runat="server" Width="232px" Visible="False"></asp:Label>
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
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblCharmin" runat="server" Width="232px" Visible="False"></asp:Label>
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
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblPuffs" runat="server" Width="232px" Visible="False"></asp:Label>
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
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblDefault" runat="server" Width="232px" Visible="False"></asp:Label>
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
                                                                        <td>
                                                                            &nbsp;&nbsp;<asp:Label ID="lblSAPCCC" runat="server" Width="232px" Visible="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </p>
                                                            <div>
                                                            </div>
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
