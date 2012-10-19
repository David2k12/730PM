<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUsers.aspx.cs" Inherits="MUREOUI.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ShowUsers</title>
		<base target="_self">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script language="javascript" type="text/javascript">
		    function SetFocusonControl() {
		        var k;
		        k = event.keyCode;

		        if (k == 13) {
		            //event.returnValue=true;
		            document.getElementById('btnLastGo').focus();
		        }
		    }	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmShowUsers" method="post" runat="server">
			<table width="85%" align="center">
				<tr class="FormHeader" height="10">
					<th width="100%">
                    <asp:HiddenField ID="hdnUserName" runat="server" />
                    <asp:HiddenField ID="hdnStore" runat="server" />
						<asp:label id="lblTitle" Runat="server" CssClass="HeaderText">
							Select User</b>
						</asp:label><br>
					</th>
				</tr>
				<tr>
					<th width="100%">
						<table width="100%" align="center">
							<tr>
								<th vAlign="top" width="40%">
									<table width="100%">
										<tr>
											<th class="FieldNames">
												First Name &nbsp;&nbsp;Last Name - Initial
											</th>
										</tr>
										<tr>
											<th vAlign="top">
												<asp:listbox id="lstUsers" Runat="server" Rows="15" Width="300" SelectionMode="Multiple"></asp:listbox></th></tr>
									</table>
								</th>
								<th style="WIDTH: 81px" vAlign="top" align="center">
									<P><br>
										<br>
										<br>
										&nbsp;</P>
									<P><asp:imagebutton id="imdAdd" tabIndex="1" runat="server" 
                                            ImageUrl="../Images/next.gif" onclick="imdAdd_Click1"></asp:imagebutton><br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<br>
										&nbsp;</P>
									<P><asp:imagebutton id="imgRemove" tabIndex="2" runat="server" 
                                            ImageUrl="../Images/previous.gif" onclick="imgRemove_Click1"></asp:imagebutton></P>
								</th>
								<td vAlign="top" width="50%">
									<table width="100%">
										<tr>
											<th class="FieldNames" width="100%">
												Selected User
											</th>
										</tr>
										<tr>
											<th width="100%">
												<asp:listbox id="lstSelectedUsers" tabIndex="3" Runat="server" Rows="15" Width="300px" SelectionMode="Multiple"></asp:listbox></th></tr>
									</table>
								</td>
							</tr>
						</table>
					</th>
				</tr>
				<tr>
					<td width="100%">
						<table width="100%" align="center">
							<tr>
								<td align="left" width="100%" colSpan="2"><asp:label id="lblSelectMess" runat="server" CssClass="Warning" ForeColor="Red">To select multiple users, hold down the "Control Key"(Ctrl) while selecting. Hit the ">" button only after all requested users have been selected.</asp:label></td>
							</tr>
							<tr class="FieldNames">
								<td onkeypress="javascript: return SetFocusonControl(event);" align="center" width="100%">Search 
									with First Name:&nbsp;
									<asp:textbox id="txtFirstName" tabIndex="4" Runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp; 
									Last Name:&nbsp;&nbsp;
									<asp:textbox id="txtLastName" tabIndex="5" Runat="server"></asp:textbox>&nbsp;</FONT>
								</td>
								<td class="MediumHeaderLinks" align="center" width="100%">
                                    <asp:imagebutton id="btnLastGo" tabIndex="6" Runat="server" 
                                        ImageUrl="../Images/search.gif" CausesValidation="False"
										ToolTip="Click To Search" AlternateText="search" onclick="btnLastGo_Click1"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<th>
						<br>
						<asp:imagebutton id="btnSubmit" tabIndex="7" Runat="server" 
                            ImageUrl="../Images/submit.gif" CausesValidation="False"
							ToolTip="Submit" onclick="btnSubmit_Click1"></asp:imagebutton>&nbsp;
						<asp:imagebutton id="imgCancel" tabIndex="8" Runat="server" 
                            ImageUrl="../Images/cancel.gif" CausesValidation="False"
							ToolTip="Cancel" onclick="imgCancel_Click1"></asp:imagebutton>&nbsp;
					</th>
				</tr>
				<tr>
					<th>
						<br>
						<asp:literal id="lblWindowOpener" Runat="server"></asp:literal></th></tr>
			</table>
		</form>
	</body>
</HTML>
