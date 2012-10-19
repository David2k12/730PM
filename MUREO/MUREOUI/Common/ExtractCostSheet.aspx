<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtractCostSheet.aspx.cs"
    Inherits="MUREOUI.Common.ExtractCostSheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Extract EO Cost Sheet</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function doHourglass() {
            document.body.style.cursor = 'wait';
        }
        function undoHourglass() {
            document.body.style.cursor = 'auto';
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table id="maintbl" style="width: 336px; height: 194px" cellspacing="0" cellpadding="0"
        width="336">
        <tr>
            <td>
                <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" align="center" width="80%">
                            <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="AttachmentMsg" style="height: 152px" valign="middle" align="left" colspan="5">
                                        <!--	<table id="tbl3" cellpadding="0" cellspacing="0" width="90%" style="BORDER-RIGHT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-BOTTOM: #898989 1px solid"> <tr> <td colspan="6" bgcolor="#f8f8f8" align="center">-->
                                        <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                            <tr valign="middle" bgcolor="#ffffcc">
                                                <td style="height: 43px" align="center" colspan="5">
                                                    <font face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><strong></strong>
                                                    </font>
                                                    <div class="FormHeader">
                                                        Open Extract EO Cost Sheet</div>
                                                </td>
                                            </tr>
                                            <tr id="hide" height="10" runat="server">
                                                <td class="DataGridBorderColor" align="left">
                                                    <p class="AttachmentMsg" align="justify">
                                                        The spreadsheet below is a template for extacting EO Cost sheet data. Please click
                                                        on the image below&nbsp;to start the data extract.</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:ImageButton ID="ImgExport" runat="server" 
                                                        ImageUrl="../Images/excelicon.gif" onclick="ImgExport_Click1">
                                                    </asp:ImageButton>
                                                </td>
                                            </tr>
                                        </table>
                                        GetEOCostExtractionTemplate-v01.xls
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
