<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmViewProject.aspx.cs"
    Inherits="MUREOUI.Common.frmViewProject" %>

<%@ Register TagPrefix="uc3" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc2" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>frmViewProject</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        //Screen Resolution code

        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }

    </script>
</head>
<body ms_positioning="GridLayout" onload="setScreenRes();">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" height="100%">
                <tr>
                    <td colspan="2" valign="top" style="height: 25px">
                        <uc2:HeaderControl ID="HeaderControl1" runat="server"></uc2:HeaderControl>
                    </td>
                </tr>
                <tr align="center" class="FormHeader" valign="top">
                    <td align="center" colspan="2" class="FormHeader" valign="top">
                        <asp:Label ID="lblHeading" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="8">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="imgEdit" OnClick="imgEdit_Click" runat="server" ImageUrl="../Images/edit.gif">
                        </asp:ImageButton>&nbsp;
                        <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../images/cancel-but.gif"
                            CausesValidation="False"></asp:ImageButton>
                    </td>
                </tr>
                <tr>
                    <td width="80%">
                        <div id="divTest" style="overflow: auto; width: 100%; height: 300px">
                            <table cellspacing="0" cellpadding="0" width="80%" border="0" align="center">
                                <tr height="10">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="FieldNames" width="45%">
                                        Category:&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblCategoryValue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="15">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="FieldNames">
                                        Brand Segment:&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblBrandValue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="15">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="FieldNames">
                                        Project Name:&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPrjNameValue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="15">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="FieldNames">
                                        Project Type:&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPrjTypeValue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="15">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="FieldNames">
                                        Project Lead:&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPrjLeadValue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="15">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="FieldNames">
                                        POC for Data Collection:&nbsp;&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPOCValue" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="15">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:Label ID="lblEdit" runat="server" ForeColor="#3333ff" Font-Bold="True">Edit History</asp:Label>
                                    </td>
                                </tr>
                                <tr height="5">
                                    <td colspan="2" align="left">
                                        <hr>
                                        <asp:DataGrid ID="dgdShowHistory" runat="server" AutoGenerateColumns="False" Width="30%">
                                            
                                            <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                            <HeaderStyle Font-Bold="true" BackColor="#FFCC00"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn DataField="Rev_Editor" HeaderText="Edited By"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Created_Date" HeaderText="Edited Date"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
