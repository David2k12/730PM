<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuzzySearch.aspx.cs" Inherits="MUREOUI.Common.FuzzySearch" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/LeftNavigationControl.ascx" TagName="LeftNavigationControl"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>FuzzySearch</title>
   	<LINK href="../StyleSheets/MUREO.css"type="text/css" rel="stylesheet">
   	<script type="text/javascript" language="javascript">
   	    function AllowNumeric(e) {
   	        var iKeyCode = 0;
   	        if (window.event)
   	            iKeyCode = window.event.keyCode
   	        else if (e)
   	            iKeyCode = e.which;
   	        if ((iKeyCode > 47 && iKeyCode < 58))
   	            return true;
   	        else
   	            return false;
   	    }
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="mainTable" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table id="innerTable1" cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td valign="top" width="20%">
                            <uc2:LeftNavigationControl ID="LeftNavigationControl1" runat="server" />
                        </td>
                        <td valign="top" width="80%">
                            <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
                                <tbody>
                                    <tr valign="middle" bgcolor="#ffffcc">
                                        <td class="FormHeader" valign="top">
                                            Concurrence Status
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="center">
                                            <table id="tblSerchProjEvent" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="tblsub1" cellspacing="5" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td class="FieldNames" align="right" width="30%">
                                                            <b>Search for: &nbsp; </b>
                                                        </td>
                                                        <td valign="top" width="20%" class="warning" style="font-weight:bold; color:red; font-family:Verdana; font-size:12px">
                                                            <asp:TextBox ID="txtSearchWord" Width="200px" runat="server"></asp:TextBox>&nbsp;<b><span style="color:Red"> (if
                                                            blank show all records)</span></b>
                                                        </td>
                                                        <td width="50%">
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td colspan="3" class="warning" style="font-weight:bold; color:red; font-family:Verdana; font-size:12px">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <b><span style="color:Red">(Search on Eo Title)</span></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" align="right" width="30%">
                                                        </td>
                                                        <td width="20%">
                                                            <b>Options</b>
                                                        </td>
                                                        <td width="50%">
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" align="right" width="20%">
                                                            &nbsp;Sort search results by:&nbsp;&nbsp;
                                                        </td>
                                                        <td width="50%">
                                                            <asp:DropDownList ID="drpSearchSort" Width="200px" runat="server" AutoPostBack="True">
                                                                <asp:ListItem Value="rel">Relevance</asp:ListItem>
                                                                <asp:ListItem Value="lm">Last Modified</asp:ListItem>
                                                                <asp:ListItem Value="fm">First Modified</asp:ListItem>
                                                                <asp:ListItem Value="kco">keep current order</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="FieldNames" width="30%">
                                                            &nbsp;Limit number of results to:&nbsp;
                                                        </td>
                                                        <td class="warning" onkeypress="javascript: return AllowNumeric(event);" align="left"
                                                            width="20%" style="font-weight:bold; color:red; font-family:Verdana; font-size:12px">
                                                            <asp:TextBox ID="txtLimitSearch" runat="server" Width="50px" MaxLength="2">0</asp:TextBox>&nbsp;<b><span style="color:Red">(zero
                                                            means&nbsp;All)</span></b>
                                                        </td>
                                                        <td class="warning" width="50%">
                                                        </td>
                                                    </tr>
                                                    <tr height="10">
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%">
                                                            <td id="rdList" width="20%" runat="server">
                                                                <asp:RadioButtonList ID="rdbSearchType" runat="server" Width="297px">
                                                                    <asp:ListItem Value="0">Use word variants(&quot;cat&quot; will also find &quot;cats&quot;)</asp:ListItem>
                                                                    <asp:ListItem Value="1">Fuzzy search</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td width="50%">
                                                            </td>
                                                            <tr height="10">
                                                                <td colspan="3">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="3">
                                                                    <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="../Images/search.gif" 
                                                                        onclick="imgSearch_Click"></asp:ImageButton>&nbsp;
                                                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                                                        CausesValidation="False" onclick="imgCancel_Click">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                </tbody>
                                            </table>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                                ShowMessageBox="True" DisplayMode="List"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                        </td>
                                    </tr>
                                </tbody>
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
