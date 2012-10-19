<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainBrandSegments.aspx.cs" Inherits="MUREOUI.Administration.MaintainBrandSegments" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MaintainBrandSegments</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function CheckCategory(sender, args) {
            if ((document.getElementById('drpCategory').selectedIndex == 0) || (document.getElementById('drpCategory').selectedIndex == -1)) 
                args.IsValid = false;
            else 
                args.IsValid = true;
        }
    </script>
</head>
<body>
    <form id="frmMaintainBrandSegments" method="post" runat="server">
			<table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
				
					<tr>
						<td><uc1:headercontrol id="HeaderControl1" runat="server"></uc1:headercontrol></td>
					</tr>
					<tr>
						<td>
							<table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
								<tr>
									<td valign="top" align="left" width="20%">
										<uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin>
									</td>
									<td valign="top" align="center">
										<table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
											<tr>
												<td valign="middle" align="center" colspan="5">
													<table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
														<tr class="FormHeader" id="trCrBs" runat="server">
															<td colspan="2">Create Brand Segment</td>
														</tr>
														<tr class="FormHeader" id="trEdBs" runat="server">
															<td colspan="2">Edit Brand Segment</td>
														</tr>
														<tr>
															<td>&nbsp;</td>
														</tr>
														<tr>
															<td align="center" colspan="2"><asp:imagebutton id="imgSubmit" runat="server" 
                                                                    ImageUrl="../Images/submit.gif" onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;&nbsp;
																<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton></td>
														</tr>
														<TR>
															<TD class="astrisk" align="center" colspan="2">*- Mandatory Fields</TD>
														</TR>
														<tr>
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr height="35">
															<td class="FieldNames" align="right" width="23%">Category&nbsp;:</td>
															<td align="left" width="35%">&nbsp;
																<asp:dropdownlist id="drpCategory" runat="server" Width="274px"
                                                                    AutoPostBack="True" onselectedindexchanged="drpCategory_SelectedIndexChanged"></asp:dropdownlist><font class="astrisk">*</font>
																<asp:customvalidator id="cstvdCategory" runat="server" ClientValidationFunction="CheckCategory" ControlToValidate="drpCategory"
																	Display="None" ErrorMessage="Please select Category."></asp:customvalidator></td>
														</tr>
														<tr height="10">
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td class="FieldNames" valign="top">Brand Segment&nbsp;:
															</td>
															<td valign="top" align="left">&nbsp;
																<asp:textbox id="txtBrandSegment" MaxLength="50"  onpaste="return false" runat="server" Width="274px"></asp:textbox><font class="astrisk">*</font>
																<asp:requiredfieldvalidator id="rqvdValue" runat="server" ControlToValidate="txtBrandSegment" Display="None"
																	ErrorMessage="Please enter/select Brand Segment."></asp:requiredfieldvalidator></td>
														</tr>
														<tr height="10">
															<td colspan="2">&nbsp;</td>
														</tr>
														<tr>
															<td class="FieldNames" valign="top">Brand Segments&nbsp;:</td>
															<td valign="top" align="left">&nbsp;
																<asp:listbox id="lbBrandSegment" runat="server" Width="274px"
                                                                    AutoPostBack="True" 
                                                                    onselectedindexchanged="lbBrandSegment_SelectedIndexChanged"></asp:listbox></FONT></td>
														</tr>
														<tr height="10">
															<td colspan="2"><asp:validationsummary id="vdsmBrandSegment" runat="server" DisplayMode="List" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
														</tr>
														<tr height="50">
															<td>&nbsp;</td>
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
				
			</table>
		</form>
</body>
</html>
