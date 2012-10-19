<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GCASNumber.aspx.cs" Inherits="MUREOUI.Common.GCASNumber" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GCASNumber</title>
    <script>

        function GCASNumber(sender, args) {
            if (document.getElementById('txtGCASNumber').value.length < 8) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            } 
        }

        function btnCancel_onclick() {
            window.close()
        }
        function AllowNumeric(e) {
            var iKeyCode = 0;
            if (window.event)
                iKeyCode = window.event.keyCode
            else if (e)
                iKeyCode = e.which;
            if (iKeyCode > 47 && iKeyCode < 58)
                return true;
            else
                return false;
        }
        function GCASLen(val) {
            if (val.length < 8) {
                alert("GCAS number should be  8 numbers");
                document.getElementById('txtGCASNumber').value = "";
                document.getElementById('txtGCASNumber').focus();
            }
        }
		</script>
</head>
<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout"
		onLoad="window.focus();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="2" cellPadding="2" width="60%" align="center" border="0">
				<tr>
					<td width="30%"><asp:label id="lbkGCASNumber" runat="server">GCAS (Material) Number :</asp:label><br>
					</td>
					<td onkeypress="javascript: return AllowNumeric(event);" vAlign="bottom" width="40%">
						<P style="COLOR: red"><asp:textbox id="txtGCASNumber" runat="server" MaxLength="8"></asp:textbox><font color="red">*</font>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="GCAS Number cannot be blank."
								ControlToValidate="txtGCASNumber"></asp:requiredfieldvalidator><br>
							<asp:customvalidator id="cstdPlant" runat="server" Display="None" ErrorMessage="GCAS number should be  8 Digits."
								ControlToValidate="txtGCASNumber" ClientValidationFunction="GCASNumber"></asp:customvalidator>&nbsp;(GCAS 
							Number should be 8 digits)</P>
					</td>
				</tr>
				<tr>
					<td width="40%">
						<P><asp:label id="lblGCASSite" runat="server">GCAS Site:</asp:label></P>
						<asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
					<td><asp:checkboxlist id="cbGCASSite" runat="server">
							<asp:ListItem Value="AY">Albany(AY)</asp:ListItem>
							<asp:ListItem Value="AZ">Apizaco(AZ)</asp:ListItem>
							<asp:ListItem Value="BE">Box Elder(BE)</asp:ListItem>
							<asp:ListItem Value="CG">Cape Girardeau(CG)</asp:ListItem>
							<asp:ListItem Value="GB">Green Bay(GB)</asp:ListItem>
							<asp:ListItem Value="OX">Oxnard(ox)</asp:ListItem>
							<asp:ListItem Value="MP">Mehoopany(MP)</asp:ListItem>
							<asp:ListItem Value="ContractManufacturing">Contract Manufacturing</asp:ListItem>
						</asp:checkboxlist></td>
				</tr>
				<tr>
					<td width="30%"><asp:label id="lblNewSite" runat="server">New to Site?</asp:label></td>
					<td width="40%"><asp:radiobuttonlist id="rbNewSite" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="Yes">Yes</asp:ListItem>
							<asp:ListItem Value="No" Selected="True">No</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td width="30%"><asp:label id="lblNewCategory" runat="server">New to Category?</asp:label></td>
					<td width="40%"><asp:radiobuttonlist id="rbNewCategory" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="Yes">Yes</asp:ListItem>
							<asp:ListItem Value="No" Selected="True">No</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td width="30%"><asp:label id="lblIntermediate" runat="server">Intermediate?</asp:label></td>
					<td width="40%"><asp:radiobuttonlist id="rbIntermediate" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="Yes">Yes</asp:ListItem>
							<asp:ListItem Value="No" Selected="True">No</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td width="30%"><asp:label id="lbltype" runat="server">Type:</asp:label></td>
					<td width="40%"><asp:checkboxlist id="cbType" runat="server">
							<asp:ListItem Value="Developmental">Developmental</asp:ListItem>
							<asp:ListItem Value="Regulated">Regulated</asp:ListItem>
							<asp:ListItem Value="Contingent">Contingent</asp:ListItem>
							<asp:ListItem Value="NeedsActivation">Needs Activation</asp:ListItem>
						</asp:checkboxlist></td>
				</tr>
			</table>
			<table cellSpacing="2" cellPadding="0" width="30%" align="center" border="0">
				<TR>
					<TD align="center" width="20%"></TD>
					<TD align="center" width="10%"></TD>
				</TR>
				<tr>
					<td align="center" width="20%"><asp:imagebutton id="btnAnotherGCASNum" 
                            runat="server" ImageUrl="../Images/Add-Another-GCAS-Number.gif" 
                            onclick="btnAnotherGCASNum_Click"></asp:imagebutton></td>
					<td align="center" width="10%"><asp:imagebutton id="btnClear" runat="server" 
                            ImageUrl="../Images/Clear-Values.gif" CausesValidation="False" 
                            onclick="btnClear_Click"></asp:imagebutton></td>
				</tr>
				<tr>
					<td align="center" width="20%"><asp:imagebutton id="btnAddandClose" runat="server" 
                            ImageUrl="../Images/Apply-and-Close-Window.gif" onclick="btnAddandClose_Click"></asp:imagebutton>&nbsp;
						<asp:ImageButton id="ImgEdit" runat="server" ImageUrl="../Images/submit.gif" 
                            onclick="ImgEdit_Click"></asp:ImageButton></td>
					<td align="center" width="10%"><IMG onclick="btnCancel_onclick()" runat="server" alt="" src="../Images/cancel.gif" id="IMG1">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</html>
