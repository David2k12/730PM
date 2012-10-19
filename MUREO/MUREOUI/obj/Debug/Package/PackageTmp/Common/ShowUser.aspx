<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUser.aspx.cs" Inherits="MUREOUI.Common.ShowUser" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>ShowUser</title>
    <base target="_self">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script language="javascript">
        function SetFocusonControl() {
            var k;
            k = event.keyCode;

            if (k == 13) {
                //event.returnValue=true;
                document.getElementById('btnLastGo').focus();
            }
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="frmShowUser" method="post" runat="server">
    <table width="85%" align="center">
        <tr class="FormHeader" height="10">
            <th width="100%">
                <asp:Label ID="lblTitle" CssClass="HeaderText" runat="server">
							Select User</b>
                </asp:Label><br>
            </th>
        </tr>
        <tr>
            <th width="100%">
                <table width="100%" align="center">
                    <tr>
                        <th valign="top" width="40%">
                            <table width="100%">
                                <tr>
                                    <th class="FieldNames">
                                        <asp:HiddenField ID="hdnUserName" runat="server" />
                                        <asp:HiddenField ID="hdnStore" runat="server" />
                                        First Name &nbsp;&nbsp;Last Name&nbsp;- Initial&nbsp;
                                    </th>
                                </tr>
                                <tr>
                                    <th valign="top">
                                        <asp:ListBox ID="lstUsers" runat="server" Width="300" Rows="15"></asp:ListBox>
                                    </th>
                                </tr>
                            </table>
                        </th>
                        <th style="width: 81px" valign="top" align="center">
                            <p>
                                <br>
                                <br>
                                &nbsp;</p>
                            <p>
                                <br>
                                <asp:ImageButton ID="imdAdd" OnClick="imdAdd_Click" runat="server" ImageUrl="../Images/next.gif"></asp:ImageButton></p>
                            <p>
                                &nbsp;</p>
                            <p>
                                <asp:ImageButton ID="imgRemove" OnClick="ImgBtnRemove_Click" runat="server" ImageUrl="../Images/previous.gif">
                                </asp:ImageButton><br>
                                &nbsp;</p>
                        </th>
                        <td valign="top" width="50%">
                            <table width="100%">
                                <tr>
                                    <th class="FieldNames" width="100%">
                                        Selected User
                                    </th>
                                </tr>
                                <tr>
                                    <th width="100%">
                                        <asp:ListBox ID="lstSelectedUsers" runat="server" Width="300px" Rows="15" SelectionMode="Multiple">
                                        </asp:ListBox>
                                    </th>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </th>
        </tr>
        <tr>
            <td width="100%">
                <table width="100%" align="center">
                    <tr>
                        <td align="left" width="100%" colspan="2">
                            <asp:Label ID="lblSelectMess" runat="server" CssClass="Warning" ForeColor="Red">Hit the ">" button only after requested user have been selected.</asp:Label>
                        </td>
                    </tr>
                    <tr class="FieldNames">
                        <td align="center" width="100%">
                            Search with First Name:&nbsp;
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp; Last
                            Name:&nbsp;&nbsp;
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>&nbsp;</FONT>
                        </td>
                        <td class="MediumHeaderLinks" align="center" width="100%">
                            <asp:ImageButton ID="btnLastGo" TabIndex="3" runat="server" ImageUrl="../Images/search.gif"
                                AlternateText="search" ToolTip="Click To Search" CausesValidation="False" 
                                onclick="btnLastGo_Click1"></asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <th>
                <br>
                <asp:ImageButton ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" ImageUrl="../Images/submit.gif" ToolTip="Submit"
                    CausesValidation="False"></asp:ImageButton>
                    <asp:ImageButton ID="btnSubmitCon" OnClick="btnSubmitCon_Click" Visible="false" runat="server" ImageUrl="../Images/submit.gif" ToolTip="Submit"
                    CausesValidation="False"></asp:ImageButton><asp:ImageButton ID="btnSubmitPreScreen" OnClick="btnSubmitPreScreen_Click" Visible="false" runat="server" ImageUrl="../Images/submit.gif" ToolTip="Submit"
                    CausesValidation="False"></asp:ImageButton>&nbsp;
                <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif" ToolTip="Cancel"
                    CausesValidation="False"></asp:ImageButton>&nbsp;
            </th>
        </tr>
        <tr>
            <th>
                <br>
            </th>
        </tr>
    </table>
    </form>
</body>
</html>
