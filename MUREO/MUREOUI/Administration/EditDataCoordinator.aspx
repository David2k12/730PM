<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDataCoordinator.aspx.cs" Inherits="MUREOUI.Administration.EditDataCoordinator" %>
<%@Register tagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx"%>
<%@Register tagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx"%>
<%@Register tagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EditDataCoordinator</title>
    <LINK href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
		<script type="text/javascript" language="javascript">		   
		    function AddBooksingUser() {
		        var popres;
		        popres = document.getElementById('txtCOName').value;
		        var strtxtAuthApprover = document.getElementById("<%=txtCOName.ClientID %>").id;
		        var hdntxtAuthApprover = document.getElementById("<%=hdntxtCOName.ClientID %>").id;
		        if (popres == "")
		            window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        else
		            window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
//		        var popResult;
//		        var CoName = document.getElementById('txtCoName').value;
//		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + CoName, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('txtCoName').value = popResult;
//		        }
//		        if (document.getElementById('txtCoName').value == 'undefined') {
//		            document.getElementById('txtCoName').value = CoName;
//		        }
		    }
//		    function AddBookMultiUser() {
//		        var popResult;
//		        var strTxtCoName = document.getElementById("<%=txtCOName.ClientID %>").value;
//		        var hdntxtCOName = document.getElementById("<%=hdntxtCOName.ClientID %>").id;
//		        popResult = window.open('../Common/ShowUser.aspx?ID=' + strTxtCoName + '&Hidd=' + hdntxtCOName, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('<%= txtCOName.ClientID %>').value = popResult;
//		            return true;
//		        }
//		        if (document.getElementById('<%= txtCOName.ClientID %>').value == 'undefined') {
//		            document.getElementById('<%= txtCOName.ClientID %>').value = strTxtCoName;
//		            return false;
//		        }
//		    }

		</script>
</head>
<body>
   <form id="Form1" method="post" runat="server">
			<TABLE id="maintbl" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD><uc1:headercontrol id="HeaderControl" runat="server"></uc1:headercontrol></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl1" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD vAlign="top" align="left" width="20%"><uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin></TD>
								<TD vAlign="top" align="center" width="80%">
									<TABLE id="tbl2" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD vAlign="middle" align="center" colSpan="5"><!--	<table id="tbl3" cellpadding="0" cellspacing="0" width="90%" style="BORDER-RIGHT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-BOTTOM: #898989 1px solid">
												<tr>
													<td colspan="6" bgcolor="#f8f8f8" align="center">-->
												<TABLE id="Table1" width="100%">
													<TR vAlign="middle" bgColor="#ffffcc">
														<TD class="FormHeader" align="center">Edit Data Coordinator</TD>
													</TR>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR>
														<TD style="HEIGHT: 21px" align="center" colSpan="2"><asp:imagebutton id="imgSubmit" 
                                                                Runat="server" ImageUrl="../Images/submit.gif" ToolTip="Submit" 
                                                                onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
															<asp:imagebutton id="imgCancel" Runat="server" ImageUrl="../images/cancel.gif" 
                                                                CausesValidation="False" ToolTip="Cancel" onclick="imgCancel_Click"></asp:imagebutton>&nbsp;
														</TD>
													</TR>
													<TR>
														<TD class="astrisk" align="center" colSpan="2">*- Mandatory Fields</TD>
													</TR>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR>
														<TD vAlign="top" align="center">
															<TABLE id="tbl3" height="3" width="100%" align="center" border="0">
																<TR>
																	<TD class="FieldNames" vAlign="top" align="left" width="50%">Category:</TD>
																	<TD vAlign="top" align="left" class="astrisk"><asp:dropdownlist id="drpCategory" runat="server" Width="232px"></asp:dropdownlist>&nbsp;*</TD>
																</TR>
																<TR>
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames" vAlign="top" align="left">Approver:
																	</TD>
																	<TD vAlign="top" align="left" class="astrisk"><asp:textbox id="txtCOName" runat="server" Width="232px" ReadOnly="True"></asp:textbox>&nbsp;<asp:imagebutton id="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif"  ></asp:imagebutton>&nbsp;*</TD>
																</TR>
																<TR height="1">
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames" vAlign="top" align="left">&nbsp;Phone Number:</TD>
																	<TD vAlign="top" align="left" class="astrisk"><asp:textbox id="txtPhone" runat="server" Width="232px"></asp:textbox>&nbsp;*</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD width="100%"><uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol></TD>
				</TR>
                <asp:HiddenField ID="hdntxtCOName" runat="server" />
			</TABLE>
		</form>
</body>
</html>
