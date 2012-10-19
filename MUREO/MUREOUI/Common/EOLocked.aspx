<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EOLocked.aspx.cs" Inherits="MUREOUI.Common.EOLocked" %>

<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EOLocked</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <uc1:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr valign="top">
            <td>
                <div align="center">
                    <b><font face="Arial" color="#ff1f10" size="4">Document Is Already In Edit Mode</font></b><br>
                    <br>
                    <hr align="center" width="100%" size="2">
                    <br>
                    <i><font face="Arial" color="#000080">
                        <asp:Label ID="lblLockOwnerContent" runat="server">Lock Owner</asp:Label>(phone
                        number: </font></i><font face="Arial" color="#000080">
                            <asp:Label ID="lblPhnumContent" runat="server">Phone Number</asp:Label></font><font
                                face="Arial" color="#000080">)</font><i><font face="Arial" color="#000080"> already
                                    has opened this document in edit mode.</font></i><br>
                </div>
                <br>
                <font face="Arial Narrow">If multiple users were allowed to edit documents at the same
                    time, it could result in data loss, or data destruction. Therefore, to maximize
                    the usefulness of this database we have locked documents that are in edit mode.</font><br>
                <font face="Arial Narrow">If you retry your edit in a few minutes, the other user may
                    have finished editing the document.</font>
                <div align="center">
                    <br>
                    <b><font face="Arial" color="#ff3300" size="6">Please Try Again in a Few Minutes</font></b><br>
                </div>
                <br>
                <b><font face="Arial" color="#ff3300" size="4">If this problem continues, please contact Jeff Chan (513-634-0584) or Rebecca Pagels (*292-2757) or Sharika Anderson (570-419-0596) and provide the following
                    information so that he can remove the lock - </font></b>
                <br>
                <br>
                <b><font face="Arial" color="#000080">EO Title -
                    <asp:Label ID="lblEOTitle" runat="server">EO Title</asp:Label></font></b><br>
                <b><font face="Arial" color="#000080">Lock Owner -
                    <asp:Label ID="lblLockOwner" runat="server">Lock Owner</asp:Label></font></b><br>
                <b><font face="Arial" color="#000080">Phone Number -
                    <asp:Label ID="lblPhnum" runat="server">Phone Number</asp:Label></font></b>
            </td>
        </tr>
    </table>
    <div align="center">
        <br /><br /><br />
        <font face="Arial">If this problem persists, please contact your EO Administrator!</font><br>
    </div>
    <table width="100%" border="0">
        <tr>
            <td>
                <uc2:FooterControl ID="FooterControl1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
