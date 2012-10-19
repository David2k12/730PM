<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddApprvrGrp.aspx.cs" Inherits="MUREOUI.Administration.WebForm1" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%--<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Add Approver Group</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="stylesheet" type="text/css" href="../StyleSheets/MUREO.css">
    <script language="javascript">
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
    <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td style="height: 23px">
                    <uc1:headercontrol id="HeaderControl" runat="server"></uc1:headercontrol>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="tbl1" border="1" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td valign="top" width="20%" align="left">
                                    <uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin>
                                </td>
                                <td valign="top" width="80%" align="center">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table id="tbl5" cellspacing="0" cellpadding="0" width="100%">
                                                <tr height="5">
                                                    <td>
                                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                            <tr valign="middle" bgcolor="#ffffcc">
                                                                <td align="center">
                                                                    <font color="#0000ff" size="4" face="Arial, Helvetica, sans-serif"><strong></strong>
                                                                    </font>
                                                                    <div>
                                                                        <strong><font class="FormHeader" color="#0000ff" size="4" face="Arial">Create Authorized&nbsp;Approval
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
                                                                    <asp:ImageButton ID="ImgSubmit" ValidationGroup="Save" OnClick="ImgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif">
                                                                    </asp:ImageButton>&nbsp;
                                                                    <asp:ValidationSummary ID="AddApprGrpValSum" ValidationGroup="Save" runat="server" DisplayMode="List" ShowSummary="False"
                                                                        ShowMessageBox="True"></asp:ValidationSummary>
                                                                    <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif">
                                                                    </asp:ImageButton>
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
                                                                <td>
                                                                    <table id="Table2" border="0" cellspacing="1" cellpadding="1" width="100%">
                                                                        <tr>
                                                                            <td style="height: 20px" class="FieldNames">
                                                                                Category:
                                                                            </td>
                                                                            <td style="height: 20px" class="astrisk">
                                                                                <asp:DropDownList ID="drpCategory" ValidationGroup="Save" runat="server" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"
                                                                                    AutoPostBack="True" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                                <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqdrpCategory" runat="server" ControlToValidate="drpCategory"
                                                                                    InitialValue="-- Select a Category --" ErrorMessage="Please select a Category" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px" class="FieldNames">
                                                                                Brand:
                                                                            </td>
                                                                            <td style="height: 20px" class="astrisk">
                                                                                <asp:DropDownList ID="drpBrand" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px" class="FieldNames">
                                                                                Plant:
                                                                            </td>
                                                                            <td style="height: 20px" class="astrisk">
                                                                                <asp:DropDownList ID="drpPlant" ValidationGroup="Save" runat="server" AutoPostBack="True" Width="274px"
                                                                                    OnSelectedIndexChanged="drpPlant_SelectedIndexChanged1">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="ReqdrpPlant" runat="server" ControlToValidate="drpPlant"
                                                                                    InitialValue="-- Select a Plant --" ErrorMessage="Please select a Plant" />
                                                                                &nbsp;*
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px" class="FieldNames">
                                                                                EO/Site Test/Other:
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                                <asp:RadioButtonList ID="rblEOorSite" runat="server" ValidationGroup="Save" AutoPostBack="True" Width="176px"
                                                                                    RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="EO">EO</asp:ListItem>
                                                                                    <asp:ListItem Value="Site Test">Site Test</asp:ListItem>
                                                                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                                &nbsp;<asp:Label ID="lbltst" CssClass="astrisk" runat="server">*</asp:Label>
                                                                                <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="ReqrblEOorSite" runat="server" ControlToValidate="rblEOorSite"
                                                                                    ErrorMessage="Please select anyone EO/Site Test/Other" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px" class="FieldNames">
                                                                                Approver Group Name:
                                                                            </td>
                                                                            <td style="height: 20px" class="astrisk" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <asp:TextBox ID="txtAppGrp" ValidationGroup="Save" runat="server" Width="274px"></asp:TextBox>&nbsp;*
                                                                                <asp:RequiredFieldValidator ValidationGroup="Save" Display="None" ID="ReqtxtAppGrp" runat="server" ControlToValidate="txtAppGrp"
                                                                                    ErrorMessage="Please enter Approver Group Name" />
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
                                                                            <td>
                                                                                <asp:DropDownList ID="drpSiteHSE" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px" class="FieldNames">
                                                                                GBU&nbsp;HS&amp;E Resource:
                                                                            </td>
                                                                            <td style="height: 20px">
                                                                                <asp:DropDownList ID="drpGBUHSE" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Planning:
                                                                            </td>
                                                                            <td class="astrisk">
                                                                                <asp:DropDownList ID="drpSitePlan" ValidationGroup="Save" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                                <asp:RequiredFieldValidator ValidationGroup="Save" Display="None" ID="ReqdrpSitePlan" runat="server" ControlToValidate="drpSitePlan"
                                                                                    InitialValue="-- Select an approver --" ErrorMessage="Please select Site Planning Approver" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Central Planning:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpCentralPlan" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Leadership:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpSiteLeader" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Finance:
                                                                            </td>
                                                                            <td class="astrisk">
                                                                                <asp:DropDownList ID="drpSiteFinance" ValidationGroup="Save" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                                <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="ReqdrpSiteFinance" runat="server"
                                                                                    ControlToValidate="drpSiteFinance" InitialValue="-- Select an approver --" ErrorMessage="Please select Site Finance Approver" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 23px" class="FieldNames">
                                                                                PS Initiative Manager:
                                                                            </td>
                                                                            <td style="height: 23px">
                                                                                <asp:DropDownList ID="drpPSInitiative" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Products Research:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpProductsResearch" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="PSRAFieldName" runat="server" visible="False">
                                                                            <td class="FieldNames">
                                                                                PS&amp;RA:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpPSRA" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Timing Gate Exception:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpTimingGate" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site QA:
                                                                            </td>
                                                                            <td class="astrisk">
                                                                                <asp:DropDownList ID="drpQA" ValidationGroup="Save" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                                &nbsp;*
                                                                                <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="ReqdrpQA" runat="server" ControlToValidate="drpQA"
                                                                                    InitialValue="-- Select an approver --" ErrorMessage="Please select Site QA Approver" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Central QA:
                                                                            </td>
                                                                            <td class="astrisk">
                                                                                <asp:DropDownList ID="drpCentralQA" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Standards Office:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpStdOffice" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Site Contact:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpSiteContact" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trSAP" runat="server">
                                                                            <td class="FieldNames">
                                                                                SAP Cost Center Coordinator:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpSAPCCC" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional Approver #1:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpAdditionalAppr1" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional Approver #2:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpAdditionalAppr2" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional Approver #3:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpAdditionalAppr3" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="FieldNames">
                                                                                Additional Approver #4:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpAdditionalAppr4" runat="server" Width="274px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="ImgSubmit" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:footercontrol id="FooterControl1" class="FieldNames" runat="server"></uc1:footercontrol>
                </td>
            </tr>
        </tbody>
    </table> 
    </form>    
</body>
</html>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   