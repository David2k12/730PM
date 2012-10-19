<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDataCoordinator.aspx.cs" Inherits="MUREOUI.Administration.AddDataCoordinator" %>
<%@Register tagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx"%>
<%@Register tagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx"%>
<%@Register tagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddDataCoordinator</title>
    <LINK href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" language="javascript">

        function AddBookMultiUser() {
            var popResult;
            var strTxtCoName = document.getElementById("<%=txtCoName.ClientID %>").id;
            var hdntxtCOName = document.getElementById("<%=hdntxtCOName.ClientID %>").id;
            popResult = window.open('../Common/ShowUser.aspx?ID=' + strTxtCoName + '&Hidd=' + hdntxtCOName, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            if (popResult != "") {
                document.getElementById('<%= txtCoName.ClientID %>').value = popResult;
                return true;
            }
            if (document.getElementById('<%= txtCoName.ClientID %>').value == 'undefined') {
                document.getElementById('<%= txtCoName.ClientID %>').value = strTxtCoName;
                return false;
            }
        }
		</script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<TABLE id="maintbl" cellspacing="0" cellpadding="0" width="100%">
				<TR>
					<TD><uc1:headercontrol id="HeaderControl" runat="server"></uc1:headercontrol></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
							<TR>
								<TD valign="top" align="left" width="20%"><uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin></TD>
								<TD valign="top" align="center" width="80%">
									<TABLE id="tbl2" cellspacing="0" cellpadding="0" width="100%">
										<TR>
                                         
											<TD valign="middle" align="center" colspan="5"><!--	<table id="tbl3" cellpadding="0" cellspacing="0" width="90%" style="BORDER-RIGHT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-BOTTOM: #898989 1px solid">
												<tr>
													<td colspan="6" bgcolor="#f8f8f8" align="center">-->
												<TABLE id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
													<TR valign="middle" bgColor="#ffffcc">
														<TD style="HEIGHT: 27px" align="center" colspan="5"><FONT face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><STRONG></STRONG></FONT>
															<DIV class="FormHeader"><FONT class="FormHeader" color="#000000">Create Data 
																	Coordinator</FONT></DIV>
														</TD>
													</TR>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR>
														<TD style="HEIGHT: 27px" align="center" colspan="5"><asp:imagebutton id="imgSubmit" ToolTip="Submit"
                                                                runat="server" ImageUrl="../Images/submit.gif" onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
															<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" ToolTip="Cancel"
                                                                onclick="imgCancel_Click"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD class="astrisk" align="center">*- Mandatory Fields</TD>
													</TR>
												</TABLE>
												<br>
												<TABLE id="tbl3" height="3" width="100%" align="center" border="0">
													<TR>
														<TD class="FieldNames" valign="top" align="right">Category:</TD>
														<TD class="astrisk" valign="top" align="left">
															<asp:dropdownlist id="drpCategory" runat="server" Width="216px"></asp:dropdownlist>&nbsp;*</TD>
													</TR>
													<TR height="1">
														<TD width="50%">&nbsp;</TD>
													</TR>
													<TR>
														<TD class="FieldNames" valign="top" align="right">Approver:
														</TD>
														<TD class="astrisk" valign="top" align="left" >
															<asp:textbox id="txtCoName" runat="server" Width="216px" ReadOnly="True"></asp:textbox>&nbsp;
															<asp:imagebutton id="imgAddressBook" ToolTip="Address Book" runat="server" ImageUrl="../Images/addressbook.gif"></asp:imagebutton>*</TD>
													</TR>
													<TR height="1">
														<TD>&nbsp;</TD>
													</TR>
													<TR>
														<TD class="FieldNames" valign="top" align="right">&nbsp;Phone Number:</TD>
														<TD class="astrisk" valign="top" align="left">
															<asp:textbox id="txtPhoneNum" runat="server" Width="216px"></asp:textbox>&nbsp;*</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
                                        <asp:HiddenField ID="hdntxtCOName" runat="server" />
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol></TD>
				</TR>
			</TABLE>
            
		</form>
</body>
</html>
