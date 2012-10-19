<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_ConvertMachine.aspx.cs"
    Inherits="MUREOUI.Administration.View_ConvertMachine" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/LeftNavigationControlForAdmin.ascx" TagName="LeftNavigationControlForAdmin"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View_ConvertMachine</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
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
            <td style="height: 320px">
                <table width="100%" cellspacing="0" cellpadding="0" border="1">
                    <tr>
                        <td width="20%">
                            left<uc2:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server" />
                        </td>
                        <td valign="top">
                            <table id="tbl2" width="100%">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" align="center">
                                        View Convert Machine
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:HiddenField ID="hdntxthiddenPlantID" runat="server" />                                        
                                        <asp:HiddenField ID="hdntxthiddenMachineID" runat="server" />
                                        <asp:HiddenField ID="hdntxthiddenCategoryId" runat="server" />
                                        
                                        <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl="../Images/edit.gif" 
                                            onclick="imgSubmit_Click1"></asp:ImageButton>&nbsp;
                                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../images/cancel.gif" 
                                            CausesValidation="False" onclick="imgCancel_Click1">
                                        </asp:ImageButton>&nbsp;
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
                                                    Category:&nbsp;&nbsp;
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="lblCategory" runat="server" Width="200"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FieldNames" valign="top" align="right" width="50%">
                                                    Plant:&nbsp;&nbsp;
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="lblPlantName" runat="server" Width="200"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr height="1">
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="FieldNames" valign="top" align="right">
                                                    Machine Name:&nbsp;&nbsp;
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="lblMachineName" runat="server" Width="200"></asp:Label>
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
                <uc3:FooterControl ID="FooterControl1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
