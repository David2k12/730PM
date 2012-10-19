<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSystemOwner.aspx.cs" Inherits="MUREOUI.Administration.AddSystemOwner" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddSystemOwner</title>
    <link href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript">
    function AddBookMultiUser() {
        var popResult;
        var strTxtSoName = document.getElementById('<%=txtSystemOwner.ClientID %>').id;
        var hdntxtSoName = document.getElementById('<%=hdntxtCOName.ClientID %>').id;
        popResult = window.open('../Common/ShowUser.aspx?ID=' + strTxtSoName + '&Hidd=' + hdntxtSoName, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
        if (popResult != "") {
            document.getElementById('<%= txtSystemOwner.ClientID %>').value = popResult;
            return true;
        }
        if (document.getElementById('<%= txtSystemOwner.ClientID %>').value == 'undefined') {
            document.getElementById('<%= txtSystemOwner.ClientID %>').value = strTxtSoName;
            return false;
        }
    }
    function AllowPhoneChk(e) {
        var iKeyCode = 0;
        if (window.event)
            iKeyCode = window.event.keyCode
        else if (e)
            iKeyCode = e.which;
        if ((iKeyCode == 40) || (iKeyCode == 41) || (iKeyCode == 43) || (iKeyCode == 45) || (iKeyCode > 47 && iKeyCode < 58))
            return true;
        else
            return false;
    }

    function CheckPlantName(sender, args) {
        if (document.getElementById('<%= drpPlantName.ClientID %>').selectedIndex == 0) {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }
</script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td>
						<table cellspacing="0" cellpadding="0" width="100%" border="1">
							<tr>
								<td width="20%"><uc1:leftnavigation id="LeftNavigation1" runat="server"></uc1:leftnavigation></td>
								<td valign="top">
									<table id="tbl2" width="100%">
										<tr id="trCrSo" valign="middle" bgColor="#ffffcc" runat="server">
											<td class="FormHeader" align="center">Create EO Site System Owner
											</td>
										</tr>
										<tr id="trEdSo" valign="middle" bgColor="#ffffcc" runat="server">
											<td class="FormHeader" align="center">Edit EO Site System Owner
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="center">
                                            <%--<asp:textbox id="txtHiddenPurchaseContactID" width="0" Runat="server"></asp:textbox>--%>
                                            <asp:HiddenField ID="txtHiddenPurchaseContactID" runat="server" />
                                                <asp:imagebutton id="imgSubmit" Runat="server" ImageUrl="../Images/submit.gif" ToolTip="Submit"
                                                    onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" Runat="server" ImageUrl="../images/cancel.gif" ToolTip="Cancel"
                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton>&nbsp;
											</td>
										</tr>
										<tr height="1">
											<TD class="astrisk" align="center">*- Mandatory Fieldsatory Fields</TD>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td valign="top">
												<table id="tbl3" height="3" width="100%" align="left" border="0">
													<tr>
														<td class="FieldNames" valign="top" align="right">Plant:&nbsp;&nbsp;</td>
														<td valign="top"><asp:dropdownlist id="drpPlantName" Runat="server" AutoPostBack="false" Width="200"></asp:dropdownlist><FONT class="astrisk">*</FONT>
														</td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" valign="top" align="right">System Owner Name:&nbsp;&nbsp;</td>
														<td valign="top"><asp:textbox id="txtSystemOwner" Runat="server" Width="200" ReadOnly="True" MaxLength="50"></asp:textbox><FONT class="astrisk">*</FONT>
															<asp:imagebutton id="imgAddressBook" ToolTip="Address Book" Runat="server" ImageUrl="../Images/addressbook.gif" CausesValidation="False"></asp:imagebutton></td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" valign="top" align="right">Phone Number:&nbsp;&nbsp;
														</td>
														<td valign="top"><asp:textbox id="txtPhoneNumber" Runat="server" Width="200" MaxLength="15"></asp:textbox></td>
													</tr>
													<tr height="1">
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td><asp:validationsummary id="PurchaseValidationSummary" runat="server" ShowSummary="False" ShowMessageBox="True"
																BorderStyle="None" DisplayMode="List"></asp:validationsummary><asp:customvalidator id="cstvdPlantName" runat="server" ClientValidationFunction="CheckPlantName" ErrorMessage="Please Select Plant."
																ControlToValidate="drpPlantName" Display="None"></asp:customvalidator><asp:requiredfieldvalidator id="ReqvdSysOwnerName" runat="server" ErrorMessage="Enter System Owner Name." ControlToValidate="txtSystemOwner"
																Display="None"></asp:requiredfieldvalidator></td>
													</tr>
												</table>
											</td>
										</tr>
                                        <asp:HiddenField ID="hdntxtCOName" runat="server" />
									</table>
								</td>
							</tr>
                             
						</table>
					</td>
				</tr>
				<tr>
					<td><uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></td>
				</tr>
			</table>
           
		</form>
</body>
</html>
