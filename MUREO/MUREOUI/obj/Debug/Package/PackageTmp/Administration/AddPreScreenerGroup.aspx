<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPreScreenerGroup.aspx.cs" Inherits="MUREOUI.Administration.AddPreScreenerGroup" %>
<%@Register tagPrefix="NavigationControl" tagname="LeftNavigationControl" src="../UserControls/LeftNavigationControlForAdmin.ascx"%>
<%@Register tagPrefix="HeadControl" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx"%>
<%@Register tagPrefix="FootControl" TagName="FooterControl" src="../UserControls/FooterControl.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddPreScreenerGroup</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript">
         function AddBookMultiUser() {
//             var popResult;
//             var strTxtPreScreenGrpName = document.getElementById('<%=txtPreScreenerGroup.ClientID %>').id;
//             var hdntxtPreScreenName = document.getElementById('<%=hdntxtPrjLead.ClientID %>').id;
//             popResult = window.open('../Common/ShowUser.aspx?ID=' + strTxtPreScreenGrpName + '&Hidd=' + hdntxtPreScreenName, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:450px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//             if (popResult != "") {
//                 document.getElementById('<%= txtPreScreenerGroup.ClientID %>').value = popResult;
//                 return true;
//             }
//             if (document.getElementById('<%= txtPreScreenerGroup.ClientID %>').value == 'undefined') {
//                 document.getElementById('<%= txtPreScreenerGroup.ClientID %>').value = strTxtPreScreenGrpName;
//                 return false;
             //             }
             var popres;
             popres = document.getElementById('txtPreScreenerGroup').value;
             var strtxtAuthApprover = document.getElementById("<%=txtPreScreenerGroup.ClientID %>").id;
             var hdntxtAuthApprover = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
             if (popres == "")
                 window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
             else
                 window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
             return false;
         }

         function AddBookMultiUser1() {
//             var popResult;
//             var strTxtPreScreenName = document.getElementById('<%=txtPreScreenerBackup.ClientID %>').id;
//             var hdntxtPreScreenName1 = document.getElementById('<%=hdntxtPrjLead1.ClientID %>').id;
//             popResult = window.open('../Common/ShowUser.aspx?ID=' + strTxtPreScreenName + '&Hidd=' + hdntxtPreScreenName1, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:450px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//             if (popResult != "") {
//                 document.getElementById('<%= txtPreScreenerBackup.ClientID %>').value = popResult;
//                 return true;
//             }
//             if (document.getElementById('<%= txtPreScreenerBackup.ClientID %>').value == 'undefined') {
//                 document.getElementById('<%= txtPreScreenerBackup.ClientID %>').value = strTxtPreScreenName;
//                 return false;
             //             }
             var popres;
             popres = document.getElementById('txtPreScreenerBackup').value;
             var strtxtAuthApprover = document.getElementById("<%=txtPreScreenerBackup.ClientID %>").id;
             var hdntxtAuthApprover = document.getElementById("<%=hdntxtPrjLead1.ClientID %>").id;
             if (popres == "")
                 window.open('../Common/ShowUser.aspx?ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
             else
                 window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtAuthApprover + '&Hidd=' + hdntxtAuthApprover, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
             return false;
         }
         

         function NoSpecialCharacters() {
             var k;
             k = event.keyCode;
             if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
                 return true;
             }
             else {
                 return false;
             }
         }

         function Validate() {
             if (document.getElementById("txtPreScreener").value == "") {
                 alert("Please enter prescreener name.");
                 return false;
             }

             if (document.getElementById("txtPreScreenerGroup").value == "") {
                 alert("Please select prescreener group name.");
                 return false;
             }

         }

    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table id="mainTable" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td><HEADCONTROL:HEADERCONTROL id="HeaderControl" runat="server"></HEADCONTROL:HEADERCONTROL></td>
				</tr>
				<tr>
					<td>
						<table id="innerTable1" cellspacing="0" cellpadding="0" width="100%" border="1">
							<tr>
								<td valign="top" width="20%"><NAVIGATIONCONTROL:LEFTNAVIGATIONCONTROL id="LeftNavigationControl" runat="server"></NAVIGATIONCONTROL:LEFTNAVIGATIONCONTROL></td>
								<td valign="top" width="100%">
									<table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
										<tr valign="middle" style="background-color:#ffffcc" id="trCrPs" runat="server">
											<td class="FormHeader" valign="top" colspan="2">Create PreScreener
											</td>
										</tr>
										<tr valign="middle" style="background-color:#ffffcc" id="trEdPS" runat="server">
											<td class="FormHeader" valign="top" colspan="2">Edit PreScreener
											</td>
										</tr>
										<tr valign="middle" style="background-color:#ffffcc" id="trViPs" runat="server">
											<td class="FormHeader" valign="top" colspan="2">View PreScreener
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="center" colspan="2"><asp:imagebutton id="imgSaveExit" runat="server" 
                                                    ImageUrl="../Images/submit.gif" AlternateText="Submit" ToolTip="Submit"
                                                    onclick="imgSaveExit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgEdit" runat="server" ImageUrl="../Images/edit.gif" ToolTip="Edit"
                                                    onclick="imgEdit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" ToolTip="Cancel"
                                                    onclick="imgCancel_Click"></asp:imagebutton></td>
										</tr>
										<tr id="trMFields" runat="server">
											<TD class="astrisk" align="center" colspan="2">*- Mandatory Fields</TD>
										</tr>
										<tr>
											<td colspan="2">&nbsp;</td>
										</tr>
										<tr>
											<td align="right" width="50%" class="FieldNames"><asp:label id="lblPrescreener" runat="server">Prescreener Group Name:</asp:label>&nbsp;&nbsp;</td>
											<td onkeypress="javascript: return NoSpecialCharacters(event);" align="left" width="50%"><asp:label id="lblPreScreenerDB" runat="server"></asp:label><asp:textbox id="txtPreScreener" runat="server"></asp:textbox><FONT color="#ff3333">
													<asp:label id="lblComp1" runat="server" CssClass="astrisk">*</asp:label></FONT></td>
										</tr>
										<tr>
											<td colspan="2">&nbsp;</td>
										</tr>
										<tr>
											<td align="right" width="50%" class="FieldNames"><asp:label id="lblPrescreenerName" runat="server">Prescreener Name:</asp:label>&nbsp;&nbsp;</td>
											<td width="50%"><asp:label id="lblPreScreenerNameDB" runat="server"></asp:label><asp:textbox id="txtPreScreenerGroup" runat="server" ReadOnly="True" Width="232px"></asp:textbox>&nbsp;
												<asp:ImageButton id="imgAddressBook1" ToolTip="Click to look up Prescreener Group Name" runat="server" ImageUrl="../Images/addressbook.gif" AlternateText="Click to look up name"></asp:ImageButton>&nbsp;<FONT color="#ff3333">
													<asp:label id="lblComp2" runat="server" CssClass="astrisk">*</asp:label></FONT></td>
										</tr>
										<tr>
											<td colspan="2">&nbsp;</td>
										</tr>
										<tr>
											<td align="right" width="50%" class="FieldNames"><asp:label id="Label3" CssClass="FieldNames" runat="server">Prescreener Backup Name:</asp:label>&nbsp;&nbsp;</td>
											<td align="left" width="50%"><asp:label id="lblPreScreenerBackupDB" runat="server"></asp:label><asp:textbox id="txtPreScreenerBackup" runat="server" ReadOnly="True" Width="232px"></asp:textbox>&nbsp;
												<asp:ImageButton id="imgAddressBook2" ToolTip="Click to look up Prescreener Backup Name" runat="server" ImageUrl="../Images/addressbook.gif" AlternateText="Click to look up name"></asp:ImageButton>&nbsp;
												<asp:ImageButton id="imgDeletePrescreener" runat="server" ToolTip="Delete Prescreener Backup Name" 
                                                    AlternateText="Delete" ImageUrl="../Images/del-name.jpg" 
                                                    onclick="imgDeletePrescreener_Click"></asp:ImageButton></td>
										</tr>
										<tr>
											<td colspan="2">&nbsp;</td>
										</tr>
										<tr>
											<td></td>
										</tr>
                                        <asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                                        <asp:HiddenField ID="hdntxtPrjLead1" runat="server" />
									</table>
							<tr>
								<td></td>
							</tr>
						</table>
						<FOOTCONTROL:FOOTERCONTROL id="FooterControl" runat="server"></FOOTCONTROL:FOOTERCONTROL></td>
				</tr>
			</table>
		</form>
</body>
</html>
