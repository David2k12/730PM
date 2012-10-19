<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGrp.aspx.cs" Inherits="MUREOUI.Administration.ViewGrp" %>

<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>View Approver Group</title>
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
                                                                        <strong><font face="Arial" color="#0000ff" size="4" class="FormHeader">View Authorized&nbsp;Approval
                                                                            Slate</font></strong></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:ImageButton ID="ImgEdit" OnClick="ImgEdit_Click" runat="server" ImageUrl="../Images/edit.gif">
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
                                                            <tr>
                                                                <td align="center">
                                                                    <div style="width: 640px; height: 550px; overflow: auto">
                                                                        <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0" align="center">
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 20px">
                                                                                    Category:
                                                                                </td>
                                                                                <td style="height: 20px" align="left">
                                                                                    <asp:Label ID="lblCat" runat="server" Width="160px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 20px">
                                                                                    Brand:
                                                                                </td>
                                                                                <td style="height: 20px" align="left">
                                                                                    <asp:Label ID="lblBrd" runat="server" Width="160px"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 20px">
                                                                                    Plant:
                                                                                </td>
                                                                                <td style="height: 20px" align="left">
                                                                                    <asp:Label ID="lblPlt" runat="server" Width="248px"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 20px">
                                                                                    EO/Site Test/Other:
                                                                                </td>
                                                                                <td style="height: 20px" align="left">
                                                                                    <asp:Label ID="lblE" runat="server" Width="160px"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 20px">
                                                                                    Approver Group Name:
                                                                                </td>
                                                                                <td style="height: 20px" align="left">
                                                                                    <asp:Label ID="lblAppGrp" runat="server" Width="248px"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 308px; height: 20px">
                                                                                </td>
                                                                                <td style="height: 20px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Site HS&amp;E Resource:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblSiteHSE" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 20px">
                                                                                    GBU&nbsp;HS&amp;E Resource:
                                                                                </td>
                                                                                <td align="left" style="height: 20px">
                                                                                    <asp:Label ID="lblGBUHSE" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Site Planning:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblSitePlan" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Central Planning:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblCentralPlan" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 21px">
                                                                                    Site Leadership:
                                                                                </td>
                                                                                <td align="left" style="height: 21px">
                                                                                    <asp:Label ID="lblSiteLeader" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Site Finance:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblSiteFinance" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 23px">
                                                                                    PS Initiative Manager:
                                                                                </td>
                                                                                <td align="left" style="height: 23px">
                                                                                    <asp:Label ID="lblPSInitiative" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Products Research:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblProductsResearch" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="PSRAFieldNames" runat="server" visible="False">
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    PS&amp;RA:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblPSRA" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Timing Gate Exception:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblTimingGate" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 21px">
                                                                                    Site QA:
                                                                                </td>
                                                                                <td align="left" style="height: 21px">
                                                                                    <asp:Label ID="lblQA" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px; height: 21px">
                                                                                    Central QA:
                                                                                </td>
                                                                                <td align="left" style="height: 21px">
                                                                                    <asp:Label ID="lblCentralQA" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Standards Office:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblStdOffice" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Site Contact:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblSiteContact" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trSap" runat="server">
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    SAP Cost Center Coordinator:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblSAPCCC" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trAdditionalAppr1" runat="server">
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Additional approver #1:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblAdditionalAppr1" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trAdditionalAppr2" runat="server">
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Additional approver #2:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblAdditionalAppr2" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trAdditionalAppr3" runat="server">
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Additional approver #3:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblAdditionalAppr3" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trAdditionalAppr4" runat="server">
                                                                                <td class="FieldNames" style="width: 308px">
                                                                                    Additional approver #4:
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblAdditionalAppr4" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
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
