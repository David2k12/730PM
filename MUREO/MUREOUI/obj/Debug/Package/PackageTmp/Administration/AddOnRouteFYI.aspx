<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOnRouteFYI.aspx.cs" Inherits="MUREOUI.Administration.AddOnRouteFYI" %>
<%@Register tagPrefix="FootControl" TagName="FooterControl" src="../UserControls/FooterControl.ascx"%>
<%@Register tagPrefix="HeadControl" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx"%>
<%@Register tagPrefix="NavigationControl" tagname="LeftNavigationControl" src="../UserControls/LeftNavigationControlForAdmin.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddOnRouteFYI</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function AddBookMultiUser() {
            var popResult;
            var strTxtFYIName = document.getElementById('<%=txtFYIRoutedName.ClientID %>').id;
            var hdntxtFYIName = document.getElementById('<%=hdntxtPrjLead.ClientID %>').id;
            popResult = window.open('../Common/ShowUser.aspx?ID=' + strTxtFYIName + '&Hidd=' + hdntxtFYIName, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:450px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            if (popResult != "") {
                document.getElementById('<%= txtFYIRoutedName.ClientID %>').value = popResult;
                return true;
            }
            if (document.getElementById('<%= txtFYIRoutedName.ClientID %>').value == 'undefined') {
                document.getElementById('<%= txtFYIRoutedName.ClientID %>').value = strTxtFYIName;
                return false;
            }
        }
        
        function CheckCategory(sender, args) {
            if (document.getElementById('drpCategoryDB').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckRegion(sender, args) {
            if (document.getElementById('drpRegionDB').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckPlantSite(sender, args) {
            if (document.getElementById('drpPlantSiteDB').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
        function Validate() {
            if (document.getElementById("drpRegionDB").selectedIndex == 0) {
                alert("Please select a Region");
                return false;
            }

            if (document.getElementById("drpCategoryDB").selectedIndex == 0) {
                alert("Please select a Category");
                return false;
            }

            if (document.getElementById("drpPlantSiteDB").selectedIndex == 0) {
                alert("Please select a Site");
                return false;
            }

            if (document.getElementById("txtFYIRoutedName").value == "") {
                alert("Please select atleast one name for FYI Recipients");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table id="mainTable" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td><HEADCONTROL:HEADERCONTROL id="HeaderControl" runat="server"></HEADCONTROL:HEADERCONTROL>
                      <asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                    </td>
				</tr>
				<tr>
					<td>
						<table id="innerTable1" cellspacing="0" cellpadding="0" width="100%" border="1">
							<tr>
								<td valign="top" width="20%"><NAVIGATIONCONTROL:LEFTNAVIGATIONCONTROL id="LeftNavigationControl" runat="server"></NAVIGATIONCONTROL:LEFTNAVIGATIONCONTROL></td>
								<td valign="top" width="80%">
									<table id="innerTable2" cellspacing="0" cellpadding="0" width="100%">
										<tr id="trcrFYI" valign="middle" style="background-color:#ffffcc" runat="server">
											<td class="FormHeader" valign="top" colspan="2">Create FYI Recipients on Route
											</td>
										</tr>
										<tr id="trEdFYI" valign="middle" style="background-color:#ffffcc" runat="server">
											<td class="FormHeader" valign="top" colspan="2">Edit FYI Recipients on Route
											</td>
										</tr>
										<tr id="trViewFYI" valign="middle" style="background-color:#ffffcc" runat="server">
											<td class="FormHeader" valign="top" colspan="2">View FYI Recipients on Route
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr valign="middle">
											<td align="center" colspan="2"><asp:imagebutton id="imgSaveExit" runat="server" 
                                                    ImageUrl="../Images/submit.gif" onclick="imgSaveExit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgEdit" runat="server" ImageUrl="../Images/edit.gif" 
                                                    onclick="imgEdit_Click"></asp:imagebutton>&nbsp;
												<asp:imagebutton id="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:imagebutton>
												<asp:ImageButton id="imgDelete" runat="server" ImageUrl="../Images/delete.gif" AlternateText="Delete"
													Visible="False" ></asp:ImageButton></td>
										</tr>
										<tr id="trMFields" runat="server">
											<td class="astrisk" align="center" colspan="2">*- Mandatory Fields</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td class="FieldNames" align="right" width="50%">Region:&nbsp;&nbsp;</td>
											<td align="left" width="50%"><asp:label id="lblRegionDB" runat="server"></asp:label><asp:dropdownlist id="drpRegionDB" runat="server" Width="200px" ></asp:dropdownlist><asp:label id="lblComp1" runat="server" CssClass="astrisk">*</asp:label>&nbsp;
												<asp:customvalidator id="csvRegion" runat="server" Display="None" ClientValidationFunction="CheckRegion"
													ControlToValidate="drpRegionDB" ErrorMessage="Please select a region."></asp:customvalidator></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td class="FieldNames" align="right" width="50%">Category:&nbsp;&nbsp;</td>
											<td align="left" width="50%"><asp:label id="lblCategoryDB" runat="server"></asp:label><asp:dropdownlist id="drpCategoryDB" runat="server" Width="200px"></asp:dropdownlist><asp:label id="lblComp2" runat="server" CssClass="astrisk">*</asp:label><asp:customvalidator id="csvCategory" runat="server" Display="None" ClientValidationFunction="CheckCategory"
													ControlToValidate="drpCategoryDB" ErrorMessage="Please select a category."></asp:customvalidator></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td class="FieldNames" align="right" width="50%">Site:&nbsp;&nbsp;</td>
											<td align="left" width="50%"><asp:label id="lblSiteDB" runat="server"></asp:label><asp:dropdownlist id="drpPlantSiteDB" runat="server" Width="200px"></asp:dropdownlist><asp:label id="lblComp3" runat="server" CssClass="astrisk">*</asp:label><asp:customvalidator id="csvPlantSite" runat="server" Display="None" ClientValidationFunction="CheckPlantSite"
													ControlToValidate="drpPlantSiteDB" ErrorMessage="Please select a plant."></asp:customvalidator></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr height="20">
											<td class="FieldNames" align="right" width="50%">FYI Recipients:&nbsp;&nbsp;<br>
												<asp:label id="lblFYIRouterName" runat="server" CssClass="Warning">(Names for the FYI message sent when EO is "Routed")&nbsp;&nbsp;</asp:label></td>
											<td align="left" valign="top" width="50%"><asp:label id="lblFYIMessageNameDB" runat="server"></asp:label><asp:textbox id="txtFYIRoutedName" runat="server" Width="200px" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;&nbsp;<asp:imagebutton id="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif"></asp:imagebutton>
												<asp:label id="lblComp4" runat="server" CssClass="astrisk">*</asp:label></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
                                      
									</table>
									<asp:ValidationSummary id="validSumFYI" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
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
