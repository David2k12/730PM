<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeOriginator.aspx.cs" Inherits="MUREOUI.Administration.ChangeOriginator" %>
<%@ Register src="../UserControls/LeftNavigationControlForAdmin.ascx" tagname="LeftNavigationControlForAdmin" tagprefix="uc4" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc5" %>
<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChangeOriginator</title>
    <LINK href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function closeWindow(s) {
            window.close();
        }
        function doHourglass() {
            document.body.style.cursor = 'wait';
        }

        function undoHourglass() {
            document.body.style.cursor = 'auto';
        }
        function AddBooksingUserOrg() {
//            var popResult;
//            var approver = document.getElementById('txtOriginator').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtOriginator').value = popResult;
//            }
//            if (document.getElementById('txtOriginator').value == 'undefined') {
//                document.getElementById('txtOriginator').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtOriginator').value;
            var strtxtAuthApprover = document.getElementById("<%=txtOriginator.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtOriginator.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }

        function AddBooksingUserCoorgi() {
//            var popResult;
//            var approver = document.getElementById('txtCoOriginator').value
//            popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + approver, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "") {
//                document.getElementById('txtCoOriginator').value = popResult;
//            }
//            if (document.getElementById('txtCoOriginator').value == 'undefined') {
//                document.getElementById('txtCoOriginator').value = approver;
            //            }
            var popres;
            popres = document.getElementById('txtCoOriginator').value;
            var strtxtAuthApprover = document.getElementById("<%=txtCoOriginator.ClientID %>").id;
            var hdntxtAuthApprover = document.getElementById("<%=hdntxtCoOriginator.ClientID %>").id;
            if (popres == "")
                window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }
        function CheckSelected() {
            if (!document.getElementById('drpEONumber').options(0).selected)
                return true;
            else {
                alert('Please select EO Number');
                return false;
            }

        }

        function CheckSelected_Submit() {
            if (!document.getElementById('drpEONumber').options(0).selected) {
                if (document.getElementById('txtOriginator').value != '')
                    return true;
                else {
                    alert('Please click on Search ');
                    return false;
                }
            }
            else {
                alert('Please select EO Number');
                return false;
            }
        }

        function Clear() {
        
            document.getElementById("<%=txtCoOriginator.ClientID %>").value = '';
            document.getElementById("<%=txtOriginator.ClientID %>").value = '';
        }
        
		</script>
</head>
<body onfocus="undoHourglass();" bottomMargin="0" onbeforeunload="doHourglass();" leftMargin="0"
		topMargin="0" rightMargin="0" onunload="doHourglass();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="maintbl" cellSpacing="0" cellPadding="0" width="100%">
				<TBODY>
					<tr>
						<td>
                            <uc5:HeaderControl ID="HeaderControl1" runat="server" />
                            <asp:HiddenField ID="hdntxtOriginator" runat="server" />
                            <asp:HiddenField ID="hdntxtCoOriginator" runat="server" />
                        </td>
					</tr>
					<tr>
						<td>
							<table id="tbl1" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<tr>
									<td vAlign="top" align="left" width="20%">
                                        <uc4:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" 
                                            runat="server" />
                                    </td>
									<td vAlign="top" align="center" width="80%">
										<table id="tbl2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR vAlign="middle" bgColor="#ffffcc">
												<TD class="FormHeader" align="center" colSpan="2">Change Originator</TD>
											</TR>
											<tr height="20">
												<td align="center" colSpan="2"></td>
											</tr>
											<tr>
												<td class="FieldNames" style="HEIGHT: 26px" width="46%">EO Number: &nbsp;
												</td>
												<td align="left" style="HEIGHT: 26px"><asp:dropdownlist id="drpEONumber" runat="server" Width="150px" OnChange="javascript: Clear();"></asp:dropdownlist></td>
											</tr>
											<TR height="20">
												<TD align="center" colSpan="2"></TD>
											</TR>
											<tr>
												<td align="center" colSpan="2">
                                                    <asp:imagebutton id="imgSubmit" runat="server" 
                                                        ImageUrl="../Images/search.gif" onclick="imgSubmit_Click1" ></asp:imagebutton></td>
											</tr>
											<TR height="20">
												<TD align="center" colSpan="2"></TD>
											</TR>
											<tr>
												<td class="FieldNames">Originaor: &nbsp;
												</td>
												<td align="left"><asp:textbox id="txtOriginator" runat="server" ReadOnly="True" Width="150px"></asp:textbox>&nbsp;
													<asp:imagebutton id="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif"></asp:imagebutton>&nbsp;</td>
											</tr>
											<tr height="5">
												<td align="center" colSpan="2"></td>
											</tr>
											<tr>
												<td class="FieldNames">Co Originator: &nbsp;
												</td>
												<td align="left"><asp:textbox id="txtCoOriginator" runat="server" ReadOnly="True" Width="150px"></asp:textbox>&nbsp;
													<asp:imagebutton id="imageAddBook" runat="server" ImageUrl="../Images/addressbook.gif"></asp:imagebutton></td>
											</tr>
											<tr height="20">
												<td align="center" colSpan="2"></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;<asp:imagebutton 
                                                        id="imgUpdate" runat="server" ImageUrl="../Images/submit.gif" onclick="imgUpdate_Click" 
                                                       ></asp:imagebutton>&nbsp;
													<asp:imagebutton id="Imagebutton1" runat="server" 
                                                        ImageUrl="../Images/cancel.gif" onclick="Imagebutton1_Click" ></asp:imagebutton></td>
											</tr>
											<TR>
												<TD align="center" colSpan="2" height="20"></TD>
											</TR>
											<tr height="5">
												<td align="center" colSpan="2"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
                            <uc6:FooterControl ID="FooterControl1" runat="server" />
                        </td>
					</tr>
				</TBODY>
			</table>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</html>
