<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LockEos.aspx.cs" Inherits="MUREOUI.Administration.LockEos" %>

<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/LeftNavigationControlForAdmin.ascx" tagname="LeftNavigationControlForAdmin" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LockEos</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
</head>
<body >

    <form id="Form1" method="post" runat="server">
    <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <uc2:HeaderControl ID="HeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table cellspacing="0" cellpadding="0" width="100%" border="1">
                    <tr>
                        <td width="20%">
                            <uc3:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" 
                                runat="server" />
                        </td>
                        <td valign="top">
                            <table id="tbl2" cellspacing="0" cellpadding="0" width="100%" align="center">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td align="center" colspan="5">
                                        <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong>&nbsp;Locked
                                            EOs </strong></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        &nbsp;
                                        <asp:ImageButton ID="lockedEOs" runat="server" 
                                            ImageUrl="..\Images\UnlockEOs.gif" OnClick="lockedEOs_Click">
                                        </asp:ImageButton>&nbsp;&nbsp;
                                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/Cancel.gif" 
                                            CausesValidation="False" OnClick="imgCancel_Click">
                                        </asp:ImageButton>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="width:100%">
                                    <td valign="top" align="left" colspan="5">
                                        <div style="overflow: auto; height: 330px">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:DataGrid ID="dtgrdLockEo" runat="server" BorderColor="Black" AutoGenerateColumns="False"
                                                            HeaderStyle-CssClass="SubHeader" Width="100%" GridLines="None" BorderWidth="1px"
                                                            CellSpacing="2" onitemcommand="dtgrdLockEo_ItemCommand">
                                                                                                                       
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="Select ">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkEoID" runat="server"></asp:CheckBox>
                                                                        <asp:Label ID="lblEoIDs" runat="server" Text='<%# Eval("EO_ID")%>'
                                                                            Visible="False">
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="EO Num">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle Wrap="False" Width="20%"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEoNum" runat="server" Text='<%# Eval("EO_Number")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="EO Title">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle Wrap="false" Width="20%"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton CommandName="EOTitle_Link" runat="server" ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblEoID" runat="server" Visible="False" Text='<%# Eval("EO_ID")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Locked By">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLockedBy" runat="server" Text='<%# Eval("Locked_By")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn HeaderText="Locked DateTime">
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLockedDateTime" runat="server" Text='<%# Eval("Locked_DateTime")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                            <HeaderStyle CssClass="SubHeader" BackColor="#FFCC00" />
                                                        </asp:DataGrid>
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
        <tr>
            <td>
                <uc1:FooterControl ID="FooterControl1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
