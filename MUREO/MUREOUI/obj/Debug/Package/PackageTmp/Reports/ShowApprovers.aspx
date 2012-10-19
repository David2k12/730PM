<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowApprovers.aspx.cs"
    Inherits="MUREOUI.Reports.ShowApprovers" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<base target="_self">
    <title>ShowApprovers</title>
    <link href="../StyleSheets/MUREO.css" />
    <meta content="JavaScript" name="vs_defaultClientScript">
    <script language="javascript" type="text/javascript">
        function btnClose()
         {
             
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="ShowApprovers" cellspacing="0" cellpadding="0" width="85%" align="center">
            <tr>
                <td height="100px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" width="85%">
                    <div id="divTest" style="width: 100%; overflow: auto">
                        <dx:ASPxGridView ID="dgdApprovalsnew" runat="server">
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="true" FieldName="Function_Name" Caption="Function_Name"
                                    FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="1">
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" FieldName="Approver_Name" Caption="Approver_Name"
                                    FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="2">
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="true" FieldName="Approval_Status" Caption="Approval_Status"
                                    FixedStyle="Left" Settings-AllowSort="True" VisibleIndex="3">
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager PageSize="20" Position="Bottom">
                            </SettingsPager>                         
                            <Styles>
                                <Header Font-Bold="true" BackColor="#FFCC00">
                                </Header>
                            </Styles>
                        </dx:ASPxGridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                    <asp:Button ID="btnOK" runat="server" Text="OK" onclick="btnOK_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
