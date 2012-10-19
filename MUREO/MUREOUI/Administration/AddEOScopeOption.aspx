<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEOScopeOption.aspx.cs" Inherits="MUREOUI.Administration.AddEOScopeOption" %>
<%@Register tagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx"%>
<%@Register tagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx"%>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AddEOScopeOption</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
		<script language="javascript">

		    function AddBookSingUser1() {
		        var popres;
		        popres = document.getElementById("<%=txtTowel.ClientID %>").value;
		        var strtxtTowel = document.getElementById("<%=txtTowel.ClientID %>").id;
		        var hdntxtTowel = document.getElementById("<%=hdntxtTowel.ClientID %>").id;
		        if (popres == "")
		            window.open('../Common/ShowUser.aspx?ID=' + strtxtTowel + '&Hidd=' + hdntxtTowel, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        else
		            window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtTowel + '&Hidd=' + hdntxtTowel, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
//		        var popResult;
//		        var towel_appr = document.getElementById('txtTowel').value
//		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + towel_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('txtTowel').value = popResult;
//		        }
//		        if (document.getElementById('txtTowel').value == 'undefined') {
//		            document.getElementById('txtTowel').value = towel_appr;
//		        }
		    }
		    function AddBookSingUser2() {
		        var popres;
		        popres = document.getElementById("<%=txtBath.ClientID %>").value;
		        var strtxtBath = document.getElementById("<%=txtBath.ClientID %>").id;
		        var hdntxtBath = document.getElementById("<%=hdntxtBath.ClientID %>").id;
		        if (popres == "")
		            window.open('../Common/ShowUser.aspx?ID=' + strtxtBath + '&Hidd=' + hdntxtBath, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        else
		            window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtBath + '&Hidd=' + hdntxtBath, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
//		        var popResult;
//		        var bath_appr = document.getElementById('txtBath').value
//		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + bath_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('txtBath').value = popResult;
//		        }
//		        if (document.getElementById('txtBath').value == 'undefined') {
//		            document.getElementById('txtBath').value = bath_appr;
//		        }
		    }
		    function AddBookSingUser3() {

		        var popres;
		        popres = document.getElementById("<%=txtTissue.ClientID %>").value;
		        var strtxtTissue = document.getElementById("<%=txtTissue.ClientID %>").id;
		        var hdntxtTissue = document.getElementById("<%=hdntxtTissue.ClientID %>").id;
		        if (popres == "")
		            window.open('../Common/ShowUser.aspx?ID=' + strtxtTissue + '&Hidd=' + hdntxtTissue, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        else
		            window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtTissue + '&Hidd=' + hdntxtTissue, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
//		        var popResult;
//		        var tissue_appr = document.getElementById('txtTissue').value
//		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + tissue_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('txtTissue').value = popResult;
//		        }
//		        if (document.getElementById('txtTissue').value == 'undefined') {
//		            document.getElementById('txtTissue').value = tissue_appr;
//		        }
		    }
		    function AddBookSingUser4() {
		        var popres;
		        popres = document.getElementById("<%=txtDefault.ClientID %>").value;
		        var strtxtDefault = document.getElementById("<%=txtDefault.ClientID %>").id;
		        var hdntxtDefault = document.getElementById("<%=hdntxtDefault.ClientID %>").id;
		        if (popres == "")
		            window.open('../Common/ShowUser.aspx?ID=' + strtxtDefault + '&Hidd=' + hdntxtDefault, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        else
		            window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtDefault + '&Hidd=' + hdntxtDefault, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
//		        var popResult;
//		        var default_appr = document.getElementById('txtDefault').value
//		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + default_appr, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('txtDefault').value = popResult;
//		        }
//		        if (document.getElementById('txtDefault').value == 'undefined') {
//		            document.getElementById('txtDefault').value = default_appr;
//		        }
		    }
		    function AddBookSingUser5() {
		        var popres;
		        popres = document.getElementById("<%=txtSAPCCC.ClientID %>").value;
		        var strtxtSAPCCC = document.getElementById("<%=txtSAPCCC.ClientID %>").id;
		        var hdntxtSAPCCC = document.getElementById("<%=hdntxtSAPCCC.ClientID %>").id;
		        if (popres == "")
		            window.open('../Common/ShowUser.aspx?ID=' + strtxtSAPCCC + '&Hidd=' + hdntxtSAPCCC, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        else
		            window.open('../Common/ShowUser.aspx?ShowUserList=' + popres + '&ID=' + strtxtSAPCCC + '&Hidd=' + hdntxtSAPCCC, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
//		        var popResult;
//		        var SAPCCC = document.getElementById('txtSAPCCC').value
//		        popResult = window.showModalDialog('../Common/ShowUser.aspx?ShowUserList=' + SAPCCC, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		        if (popResult != "") {
//		            document.getElementById('txtSAPCCC').value = popResult;
//		        }
//		        if (document.getElementById('txtSAPCCC').value == 'undefined') {
//		            document.getElementById('txtSAPCCC').value = SAPCCC;
//		        }
		    }

		    function NoSpecialCharacters() {
		        var k;
		        k = event.keyCode;

		        if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
		            return true;
		        }
		        else {
		            //alert("Enter characters and Digits Only")
		            return false;
		        }
		    }
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
          <asp:ScriptManager ID="scp1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upbudget" runat="server">
        <ContentTemplate>
			<TABLE id="maintbl" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="HEIGHT: 23px"><uc1:headercontrol id="HeaderControl" runat="server"></uc1:headercontrol></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl1" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD vAlign="top" align="left" width="20%"><uc1:leftnavigationcontrolforadmin id="LeftNavigationControlForAdmin1" runat="server"></uc1:leftnavigationcontrolforadmin></TD>
								<TD vAlign="top" align="center" width="80%">
									<TABLE id="tbl5" cellSpacing="0" cellPadding="0" width="100%">
										<TR height="5">
											<TD>
												<TABLE id="tbl4" cellSpacing="0" cellPadding="0" width="100%" align="center">
													<TR vAlign="middle" bgColor="#ffffcc">
														<TD align="center" colSpan="5"><FONT face="Arial, Helvetica, sans-serif" color="#0000ff" size="4"><STRONG></STRONG></FONT>
															<DIV><STRONG><FONT face="Arial" color="#0000ff" size="4" class="FormHeader">Create EO Scope 
																		Option</FONT></STRONG></DIV>
														</TD>
													</TR>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR>
														<TD style="HEIGHT: 20px" align="center" colSpan="5">
															<asp:imagebutton id="imgSubmit" ValidationGroup="Save" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif"></asp:imagebutton>&nbsp;
                                                             <asp:ValidationSummary ID="AddimgSubmit" ValidationGroup="Save" runat="server" DisplayMode="List" ShowSummary="False"
                                                                        ShowMessageBox="True"></asp:ValidationSummary>
															<asp:imagebutton id="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif"></asp:imagebutton></TD>
													</TR>
													<TR>
														<TD align="center">
															<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="95%" border="0">
																<TR>
																	<TD class="astrisk" align="center" colSpan="2">
																		<P class="astrisk">* - Mandatory Fields</P>
																	</TD>
																</TR>
																<tr>
																	<td>&nbsp;</td>
																</tr>
																<TR>
																	<TD class="FieldNames"><FONT size="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																			Scope Option: </FONT>
																	</TD>
																	<TD onkeypress="javascript: return NoSpecialCharacters(event);"><asp:textbox id="txtScopeOption" runat="server" Width="231px"></asp:textbox>&nbsp;
                                                                     <asp:RequiredFieldValidator Display="None" ValidationGroup="Save" ID="reqtxtScopeOption" runat="server" ControlToValidate="txtScopeOption"
                                                                                     ErrorMessage="Please enter EO Scope Option Name" />    
																		<asp:label id="lblAstrx" runat="server" CssClass="Astrisk">*</asp:label>&nbsp;<STRONG></STRONG>
																	</TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames"><!--Budget Center:--></TD>
																	<TD class="astrisk"><asp:dropdownlist id="drpBudget" runat="server" Width="232px" AutoPostBack="True" Visible="False"></asp:dropdownlist>&nbsp;
																		<asp:label id="Label1" runat="server" CssClass="Astrisk" Visible="False">*</asp:label></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2"><STRONG><!--Budget Center Approvers--></STRONG></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames" style="HEIGHT: 25px"><!--Bounty:--></TD>
																	<TD style="HEIGHT: 25px">
                                                                    <asp:textbox id="txtTowel" runat="server" Width="231px" ReadOnly="True" Visible="False"></asp:textbox>&nbsp;
                                                                    <asp:HiddenField ID="hdntxtTowel" runat="server" />
                                                                    <asp:imagebutton id="imgAddrbkTowel" runat="server" ImageUrl="../Images/addressbook.gif" Visible="False"></asp:imagebutton>&nbsp;<asp:label id="Label3" runat="server" CssClass="Astrisk" Visible="False">*</asp:label></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames" style="HEIGHT: 26px"><!--Charmin:--></TD>
																	<TD style="HEIGHT: 26px"><asp:textbox id="txtBath" runat="server" Width="231px" ReadOnly="True" Visible="False"></asp:textbox>&nbsp;<asp:imagebutton id="ImgAddrbkBath" runat="server" ImageUrl="../Images/addressbook.gif" Visible="False"></asp:imagebutton>&nbsp;<asp:label id="Label4" runat="server" CssClass="Astrisk" Visible="False">*</asp:label>
                                                                     <asp:HiddenField ID="hdntxtBath" runat="server" />
                                                                    </TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames"><!--Puffs:--></TD>
																	<TD><asp:textbox id="txtTissue" runat="server" Width="231px" ReadOnly="True" Visible="False"></asp:textbox>&nbsp;<asp:imagebutton id="ImgAddrbkTissue" runat="server" ImageUrl="../Images/addressbook.gif" Visible="False"></asp:imagebutton>&nbsp;
                                                                    <asp:HiddenField ID="hdntxtTissue" runat="server" />
                                                                    <asp:label id="Label5" runat="server" CssClass="Astrisk" Visible="False">*</asp:label></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames"><!--Default:--></TD>
																	<TD><asp:textbox id="txtDefault" runat="server" Width="231px" ReadOnly="True" Visible="False"></asp:textbox>&nbsp;
                                                                    <asp:HiddenField ID="hdntxtDefault" runat="server" />
                                                                    <asp:imagebutton id="ImgAddrbkDefault" runat="server" ImageUrl="../Images/addressbook.gif" Visible="False"></asp:imagebutton>&nbsp;<asp:label id="Label21" runat="server" CssClass="Astrisk" Visible="False">*</asp:label>&nbsp;</TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="FieldNames">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
																	<TD><asp:textbox id="txtSAPCCC" runat="server" Width="231px" ReadOnly="True" Visible="False"></asp:textbox>&nbsp;
                                                                    <asp:HiddenField ID="hdntxtSAPCCC" runat="server" />
                                                                    <asp:imagebutton id="ImgAddrBkSAPCC" runat="server" ImageUrl="../Images/addressbook.gif" Visible="False"></asp:imagebutton>&nbsp;
																		<asp:ImageButton id="imgDeleteSAPCCC" runat="server" ImageUrl="../Images/del-name.jpg" Visible="False"></asp:ImageButton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
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
					<TD><uc1:footercontrol id="FooterControl1" runat="server"></uc1:footercontrol></TD>
				</TR>
			</TABLE>
            </ContentTemplate></asp:UpdatePanel>
		</form>
	</body>
</HTML>

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     