<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmViewEvent.aspx.cs" Inherits="MUREOUI.Common.frmViewEvent" %>

<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>frmViewEvent</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        //Screen Resolution code
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
    </script>
</head>
<body ms_positioning="GridLayout" onload="setScreenRes();" bottommargin="0" topmargin="0"
    rightmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" height="100%">
        <tbody>
            <tr>
                <td style="height: 20px">
                    <uc2:HeaderControl ID="HeaderControl1" runat="server" />
                </td>
            </tr>
            <tr align="center">
                <td class="FormHeader" valign="top">
                    View Event
                </td>
            </tr>
            <tr height="5">
                <td>
                </td>
            </tr>
            <tr align="center" valign="top">
                <td>
                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="../Images/edit.gif" 
                        onclick="imgEdit_Click"></asp:ImageButton>&nbsp;
                    <asp:ImageButton ID="ingCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                        onclick="ingCancel_Click"></asp:ImageButton>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tbody>
                            <tr>
                                <td align="center">
                                    <div id="divTest" style="width: 100%; height: 300px; overflow: auto">
                                        <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
                                            <tbody>
                                                <tr height="5">
                                                    <td colspan="5">
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5">
                                                        <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                            border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                            cellpadding="0" width="100%" border="0">
                                                            <tr bgcolor="#ccffff">
                                                                <td align="center">
                                                                    <asp:Label ID="lblEventCategory" runat="server" ForeColor="Black" Font-Bold="True">Category</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblBrandSegment" runat="server" ForeColor="Black" Font-Bold="True">Brand Segments</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblProject" ForeColor="#000000" Font-Bold="True" runat="server">Project</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr height="8">
                                                                <td colspan="3">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Label ID="lblCategoryDB" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblBrandSegmentDB" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblProjectValue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr bgcolor="#ccffff">
                                                                <td align="center" colspan="2">
                                                                    <asp:Label ID="lblEOName" ForeColor="#000000" Font-Bold="True" runat="server">Event Name</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblEventType" ForeColor="#000000" Font-Bold="True" runat="server">Event Type</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr height="8">
                                                                <td colspan="3">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:Label ID="lblEONameValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblEventTypeValue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5" height="10">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5">
                                                        <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                            border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                            cellpadding="0" border="0">
                                                            <tr align="center" bgcolor="#ccffff">
                                                                <td>
                                                                    <asp:Label ID="lblPlant" ForeColor="#000000" Font-Bold="True" runat="server">Plant</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblDSDate" ForeColor="#000000" Font-Bold="True" runat="server">Desired Start Date</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblShippable" ForeColor="#000000" Font-Bold="True" runat="server">Is this Product Shippable?</asp:Label>
                                                                </td>
                                                                <td id="tdGDays" runat="server">
                                                                    <asp:Label ID="lblGDays" ForeColor="#000000" Font-Bold="True" runat="server">On Hold for > 3 Days</asp:Label>
                                                                </td>
                                                                <td id="tdDays" runat="server">
                                                                    <asp:Label ID="lblDays" ForeColor="#000000" Font-Bold="True" runat="server"># Days on Hold</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr height="8">
                                                                <td colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td align="center" width="30%">
                                                                    <asp:Label ID="lblPlantValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center" width="30%">
                                                                    <asp:Label ID="lblDSDateValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center" width="15%">
                                                                    <asp:Label ID="lblShippableValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td id="tdrdbDays" align="center" width="15%" runat="server">
                                                                    <asp:Label ID="lblGDaysValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblDaysValue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td colspan="5">
                                                        <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                            border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                            cellpadding="1" width="100%" align="center" border="0">
                                                            <tbody>
                                                                <tr bgcolor="#ccffff">
                                                                    <td align="center">
                                                                        <asp:Label ID="lblPaper" ForeColor="#000000" Font-Bold="True" runat="server">Paper Machine</asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblPTotalLost" ForeColor="#000000" Font-Bold="True" runat="server">Total Number of<br> Papermaking Days</asp:Label>
                                                                    </td>
                                                                    <td align="center" colspan="3">
                                                                        <asp:Label ID="lblPComments" ForeColor="#000000" Font-Bold="True" runat="server">Specific<br>Comments for Planning</asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr height="8">
                                                                    <td colspan="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" width="20%">
                                                                        <asp:Label ID="lblPaperValue" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" width="20%">
                                                                        <asp:Label ID="lblPTotalLostValue" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" width="60%" colspan="3">
                                                                        <asp:Label ID="lblPCommentsValue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5" height="10">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5">
                                                        <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                            border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                            cellpadding="1" width="100%" border="0">
                                                            <tbody>
                                                                <tr bgcolor="#ccffff">
                                                                    <td align="center">
                                                                        <asp:Label ID="lblConLine" ForeColor="#000000" Font-Bold="True" runat="server">Converting Line</asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblConLost" ForeColor="#000000" Font-Bold="True" runat="server">Total Number of<br>Converting Days</asp:Label>
                                                                    </td>
                                                                    <td align="center" colspan="3">
                                                                        <asp:Label ID="lblConComments" ForeColor="#000000" Font-Bold="True" runat="server">Specific<br>Comments for Planning</asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr height="8">
                                                                    <td colspan="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" width="20%">
                                                                        <asp:Label ID="lblConLineValue" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" width="20%">
                                                                        <asp:Label ID="lblConLostValue" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center" width="60%" colspan="3">
                                                                        <asp:Label ID="lblConCommentsValue" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5" height="10">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td colspan="5">
                                                        <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                            border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                            cellpadding="1" width="100%" align="center" border="0">
                                                            <tr bgcolor="#ccffff">
                                                                <td align="center">
                                                                    <asp:Label ID="lblComLine" ForeColor="#000000" Font-Bold="True" runat="server">Combining Line</asp:Label><br>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblComLost" ForeColor="#000000" Font-Bold="True" runat="server">Total Number of<br>Combining Days</asp:Label><br>
                                                                </td>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr height="8">
                                                                <td colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" width="20%">
                                                                    <asp:Label ID="lblComLineValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center" width="20%">
                                                                    <asp:Label ID="lblComLostValue" runat="server"></asp:Label>
                                                                </td>
                                                                <td colspan="3" width="60%">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                            border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                            cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td align="center" bgcolor="#ccffff">
                                                                    <asp:Label ID="lblCategory" ForeColor="#000000" Font-Bold="True" runat="server">Category</asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr height="8">
                                                                <td colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblSelCategory" ForeColor="#000000" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr align="center" bgcolor="#ccffff">
                                                                <td align="center">
                                                                    <asp:Label ID="lblBrand" ForeColor="#000000" Font-Bold="True" runat="server">BrandType</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblPrjType" ForeColor="#000000" Font-Bold="True" runat="server">Project Type</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblPrjLeader" ForeColor="#000000" Font-Bold="True" runat="server">Project Leader</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblPOC" ForeColor="#000000" Font-Bold="True" runat="server">POC</asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblOriginator" ForeColor="#000000" Font-Bold="True" runat="server">Originator</asp:Label><br>
                                                                </td>
                                                            </tr>
                                                            <tr height="8">
                                                                <td colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Label ID="lblBrandValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblPrjTypeValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblPrjLeaderValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblPOCValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblOriginatorValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" align="left">
                                                        <asp:Label ID="lblAuthors1" ForeColor="#0033ff" Font-Bold="True" runat="server">Other Authors :</asp:Label><asp:Label
                                                            ID="lblAuthorsValue" ForeColor="#0033ff" Font-Bold="True" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" align="left">
                                                        <asp:Label ID="lblEdit1" ForeColor="#3333ff" Font-Bold="True" runat="server">Edit History</asp:Label>
                                                        <hr>
                                                        <asp:DataGrid ID="dgdShowHistory" runat="server"  AutoGenerateColumns="False"
                                                            Width="30%">
                                                              
                                                                    <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                                                    <HeaderStyle Font-Bold="true" BackColor="#FFCC00"></HeaderStyle>

                                                            <Columns>
                                                                <asp:BoundColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" DataField="Rev_Editor" HeaderText="Edited By"></asp:BoundColumn>
                                                                <asp:BoundColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" DataField="Created_Date" HeaderText="Edited Date"></asp:BoundColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:Label ID="lblUser" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:FooterControl ID="FooterControl1" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
