<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PSRA.aspx.cs" Inherits="MUREOUI.Common.PSRA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PSRA</title>
    <script>
        function NoSpecialCharacters() {
            var k;
            k = event.keyCode;

            if (!(k == 35) && !(k == 36) && !(k == 38) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
                //event.returnValue=true;
                return true;
            }
            else {
                //alert("Enter characters and Digits Only")
                //event.returnValue=false;
                return false;
            }
        }

        function btnCancel_onclick() {
            window.close()
        }
        function AllowNum(e) {
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

        function AllowNumeric(e) {
            var iKeyCode = 0;
            if (window.event)
                iKeyCode = window.event.keyCode
            else if (e)
                iKeyCode = e.which;
            if ((iKeyCode == 46) || (iKeyCode > 47 && iKeyCode < 58))
                return true;
            else
                return false;
        }


        function CountDecimals(val, contrlName) {
            var k = val;
            var j = 0;
            for (var i = 0; i < k.length; i++) {
                var a = k.charAt(i);
                if (a == ".")
                    j++;
            }

            if (j > 1) {
                alert("Please enter decimal value");
                document.getElementById(contrlName).value = "";
                document.getElementById(contrlName).focus();
            }
        }
				
		</script>
</head>
<body MS_POSITIONING="GridLayout" onLoad="window.focus();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="5" cellPadding="0" width="40%" align="center" border="0" id="tblPSRA"
				runat="server">
				<TR>
					<TD align="center" width="55%" colSpan="2">
						<asp:label id="lblReqFields" Runat="server" ForeColor="#ff3333" Font-Bold="True">*Required Fields</asp:label></TD>
					<TD width="50%"></TD>
				</TR>
				<tr>
					<td width="55%"><asp:label id="lblCTTracking" runat="server">CT Tracking Number :</asp:label><br>
					</td>
					<td onkeypress="javascript: return NoSpecialCharacters(event);" width="50%"><asp:textbox id="txtCTTrackingNumber" runat="server" MaxLength="20"></asp:textbox><font color="red">*</font><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="CT Tracking Number cannot be blank."
							ControlToValidate="txtCTTrackingNumber" Display="None"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td width="20%"><asp:label id="lblSupplierName" runat="server">Supplier Name : </asp:label>&nbsp;</td>
					<td width="30%" onkeypress="javascript: return NoSpecialCharacters(event);"><asp:textbox id="txtSupplierName" runat="server" MaxLength="15"></asp:textbox></td>
				</tr>
				<tr>
					<td width="20%"><asp:label id="lblMaterial" runat="server">Material Application :</asp:label></td>
					<td width="30%" onkeypress="javascript: return NoSpecialCharacters(event);"><asp:textbox id="txtMaterial" runat="server" MaxLength="15"></asp:textbox></td>
				</tr>
				<tr>
					<td width="20%"><asp:label id="lblMaterialUsage" runat="server">Material Usage Amount :</asp:label></td>
					<td onkeypress="javascript: return NoSpecialCharacters(event);" width="30%"><asp:textbox id="txtMaterialUsage" runat="server" MaxLength="10"></asp:textbox></td>
				</tr>
				<tr>
					<td width="20%"><asp:label id="lblPSRA" runat="server">PS&RA Level :</asp:label></td>
					<td width="30%" onkeypress="javascript: return NoSpecialCharacters(event);"><asp:textbox id="txtPSRALevel" runat="server" MaxLength="15"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center" width="20%"><asp:imagebutton id="btnAddAnother" runat="server" 
                            ImageUrl="../Images/apply-another-code.gif" onclick="btnAddAnother_Click"></asp:imagebutton></td>
					<td align="center" width="30%"><asp:imagebutton id="btnClear" runat="server" 
                            ImageUrl="../Images/Clear-Values.gif" CausesValidation="False" 
                            onclick="btnClear_Click"></asp:imagebutton>
					</td>
				</tr>
				<tr>
					<td align="center" width="20%">
						<P align="center"><asp:imagebutton id="imgAddClose" runat="server" 
                                ImageUrl="../Images/Apply-and-Close-Window.gif" onclick="imgAddClose_Click"></asp:imagebutton>
							<asp:ImageButton id="ImgEdit" runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton></P>
					</td>
					<td align="center" width="30%"><IMG id="IMG1" onclick="btnCancel_onclick()" alt="" src="../Images/cancel.gif" runat="server">
					</td>
				</tr>
				<TR>
					<TD align="center" width="20%"></TD>
					<TD align="center" width="30%"><asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</table>
		</form>
	</body>
</html>
