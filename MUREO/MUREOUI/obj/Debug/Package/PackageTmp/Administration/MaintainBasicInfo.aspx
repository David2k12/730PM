<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainBasicInfo.aspx.cs" Inherits="MUREOUI.Administration.MaintainBasicInfo" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MaintainBasicInfo</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript">
    function CheckKey(sender, args) {
        if ((document.getElementById('drpkey').selectedIndex == 0) || (document.getElementById('drpkey').selectedIndex == -1)) {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        } 
    }
    function NoSpecialCharacters() {
        var k;
        k = event.keyCode;

        if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42) && !(k == 38)) {
            return true;
        }
        else {
            //alert("Enter characters and Digits Only")
            return false;
        }
    }
</script>
</head>
<body>
    <form id="frmMaintainBrandSegments" method="post" runat="server">
			<table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
				<TBODY>
					<tr>
						<td><uc1:headercontrol id="HeaderControl1" runat="server"></uc1:headercontrol></td>
					</tr>
					<tr>
						<td>
							<table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
								<tr>
									<td valign="top" align="left" width="20%"><uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin2" runat="server"></uc1:leftnavigationcontrolforadmin></td>
									<td valign="top" align="center">
										<table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td valign="middle" align="center" colspan="5">
													<table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
														<tr class="FormHeader" id="trCrBi" runat="server">
															<td colspan="2">Create Basic Information</td>
														</tr>
														<tr class="FormHeader" id="trEdBi" runat="server">
															<td colspan="2">Edit Basic Information</td>
														</tr>
														<tr>
															<td>&nbsp;</td>
														</tr>
														<tr>
															<td align="center" colspan="2">
																<asp:ImageButton id="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" ToolTip="Submit"
                                                                    onclick="imgSubmit_Click"></asp:ImageButton>&nbsp;&nbsp;
																<asp:ImageButton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" ToolTip="Cancel"
                                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:ImageButton></td>
														</tr>
														<TR>
															<TD class="astrisk" align="center" colspan="2">*- Mandatory Fields</TD>
														</TR>
														<tr>
															<td>&nbsp;</td>
														</tr>
														<tr height="35">
															<td class="FieldNames" width="25%">&nbsp;Key :</td>
															<td align="left" width="35%">&nbsp;
																<asp:dropdownlist id="drpkey" runat="server" AutoPostBack="True" Width="150px" 
                                                                    onselectedindexchanged="drpkey_SelectedIndexChanged">
																	<asp:ListItem Value="0">-- Select Basic Key --</asp:ListItem>
																	<asp:ListItem Value="1">Category</asp:ListItem>
																	<asp:ListItem Value="2">EOType</asp:ListItem>
																	<asp:ListItem Value="3">Function</asp:ListItem>
																	<asp:ListItem Value="4">Machine</asp:ListItem>
																	<asp:ListItem Value="5">Plant</asp:ListItem>
																	<asp:ListItem Value="6">Project Type</asp:ListItem>
																</asp:dropdownlist>
																<font class="astrisk">*</font>
																<asp:CustomValidator id="cstvdKey" runat="server" ErrorMessage="Please select Key." Display="None" ControlToValidate="drpkey"
																	ClientValidationFunction="CheckKey"></asp:CustomValidator></td>
														</tr>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td class="FieldNames" valign="top">
																Value&nbsp;:
															</td>
															<td valign="top" align="left" onkeypress="javascript: return NoSpecialCharacters(event);">&nbsp;
																<asp:TextBox id="txtKeyValue" MaxLength="50" runat="server" Width="150px"></asp:TextBox>
																<font class="astrisk">*</font>
																<asp:RequiredFieldValidator id="rfvValue" runat="server" ControlToValidate="txtKeyValue" Display="None" ErrorMessage="Please enter/select Value."></asp:RequiredFieldValidator></td>
														</tr>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td class="FieldNames" valign="top">Values&nbsp;:</td>
															<td valign="top" align="left">&nbsp;
																<asp:ListBox id="lbKeyValues" runat="server" AutoPostBack="True" Width="150px" 
                                                                    onselectedindexchanged="lbKeyValues_SelectedIndexChanged"></asp:ListBox><font class="astrisk"></font></td>
														</tr>
														<tr>
															<td></td>
															<td></td>
														</tr>
														<tr height="10">
															<td colspan="2" style="HEIGHT: 20px">
																<asp:ValidationSummary id="vdsmBasicInfo" runat="server" ShowMessageBox="True" ShowSummary="False" DisplayMode="List"></asp:ValidationSummary></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr height="5">
												<td colspan="5">&nbsp;</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol></td>
					</tr>
					<tr>
						<td></td>
					</tr>
				</TBODY>
			</table>
		</form>
</body>
</html>
