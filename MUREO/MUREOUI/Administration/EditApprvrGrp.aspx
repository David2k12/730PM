<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditApprvrGrp.aspx.cs"
    Inherits="MUREOUI.Administration.EditApprvrGrp" %>

<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Edit Approver Group</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function AddBookMultiUser() {
            var popResult;
            popResult = window.showModalDialog('../Common/ShowUsers.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            document.getElementById('txtAuthApprover').value = popResult;
        }
        function AddBooksingUser() {
            var popResult;
            popResult = window.showModalDialog('../Common/ShowUser.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            document.getElementById('txtAuthApprover').value = popResult;
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
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                                                        <strong><font class="FormHeader" face="Arial" color="#0000ff" size="4">Edit Authorized&nbsp;Approval
                                                                            Slates</font></strong></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:ImageButton ID="ImgSubmit" OnClick="ImgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif">
                                                                    </asp:ImageButton>&nbsp;
                                                                    <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
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
                                                                <td align="center">
                                                                    <table id="Table2" cellspacing="1" cellpadding="1" width="70%" border="0">
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 20px">
                                                                                Category:
                                                                            </td>
                                                                            <td class="astrisk" style="height: 20px" align="left">
                                                                                <asp:DropDownList ID="drpCategory" runat="server" Width="176px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 20px">
                                                                                Brand:
                                                                            </td>
                                                                            <td class="astrisk" style="height: 20px" align="left">
                                                                                <asp:DropDownList ID="drpBrand" runat="server" Width="176px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 20px">
                                                                                Plant:
                                                                            </td>
                                                                            <td class="astrisk" style="height: 20px" align="left">
                                                                                <asp:DropDownList ID="drpPlant" runat="server" OnSelectedIndexChanged="drpPlant_SelectedIndexChanged"
                                                                                    Width="176px" AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 20px">
                                                                                EO/Site Test/Other:
                                                                            </td>
                                                                            <td style="height: 20px" align="left">
                                                                                <asp:RadioButtonList ID="rblEOorSite" runat="server" Width="176px" AutoPostBack="True"
                                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                    <asp:ListItem Value="EO">EO</asp:ListItem>
                                                                                    <asp:ListItem Value="Site Test">Site Test</asp:ListItem>
                                                                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                                &nbsp;
                                                                                <asp:Label ID="lblAstrisk" runat="server" CssClass="Astrisk">*</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 20px">
                                                                                Approver Group Name:
                                                                            </td>
                                                                            <td class="astrisk" align="left" style="height: 20px" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <asp:TextBox ID="txtApproverGroup" runat="server" Width="246px"></asp:TextBox>&nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site HS&amp;E Resource:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpSiteHSE" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 20px">
                                                                                GBU&nbsp;HS&amp;E Resource:
                                                                            </td>
                                                                            <td align="left" style="height: 20px">
                                                                                <asp:DropDownList ID="drpGBUHSE" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Planning:
                                                                            </td>
                                                                            <td align="left" class="astrisk">
                                                                                <asp:DropDownList ID="drpSitePlan" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Central Planning:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpCentralPlan" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Leadership:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpSiteLeader" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Finance:
                                                                            </td>
                                                                            <td align="left" class="astrisk">
                                                                                <asp:DropDownList ID="drpSiteFinance" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                *
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames" style="height: 23px">
                                                                                PS Initiative Manager:
                                                                            </td>
                                                                            <td align="left" style="height: 23px">
                                                                                <asp:DropDownList ID="drpPSInitiative" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Products Research:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpProductsResearch" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="PSRAField" runat="server" visible="False">
                                                                            <td class="FieldNames">
                                                                                PS&amp;RA:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpPSRA" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Timing Gate Exception:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpTimingGate" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site QA:
                                                                            </td>
                                                                            <td align="left" class="astrisk">
                                                                                <asp:DropDownList ID="drpQA" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Central QA:
                                                                            </td>
                                                                            <td align="left" class="astrisk">
                                                                                <asp:DropDownList ID="drpCentralQA" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Standards Office:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpStdOffice" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Contact:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpSiteContact" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trSAP" runat="server">
                                                                            <td class="FieldNames">
                                                                                SAP Cost Center Coordinator:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpSAPCCC" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional approver #1:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpAdditionalAppr1" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional approver #2:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpAdditionalAppr2" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional approver #3:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpAdditionalAppr3" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional approver #4:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="drpAdditionalAppr4" runat="server" Width="274px">
                                                                                </asp:DropDownList>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
