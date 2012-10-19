<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMigrateEvent.aspx.cs" Inherits="MUREOUI.Common.EditMigrateEvent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    	<LINK href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
		<script language="javascript">

		    var dtCh = "/";
		    var minYear = 1900;
		    var maxYear = 2100;
		    function isInteger(s) {
		        var i;
		        for (i = 0; i < s.length; i++) {
		            // Check that current character is number.
		            var c = s.charAt(i); if (((c < "0") || (c > "9"))) return false;
		        }
		        // All characters are numbers.
		        return true;
		    }

		    function stripCharsInBag(s, bag) {
		        var i;
		        var returnString = "";
		        // Search through string's characters one by one.
		        // If character is not in bag, append to returnString.
		        for (i = 0; i < s.length; i++) {
		            var c = s.charAt(i);
		            if (bag.indexOf(c) == -1) returnString += c;
		        }
		        return returnString;
		    }

		    function daysInFebruary(year) {
		        // February has 29 days in any year evenly divisible by four,
		        // EXCEPT for centurial years which are not also divisible by 400.
		        return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
		    }

		    function DaysArray(n) {
		        for (var i = 1; i <= n; i++) {
		            this[i] = 31
		            if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
		            if (i == 2) { this[i] = 29 }
		        }
		        return this
		    }

		    function isDate(dtStr) {
		        dtStr = document.getElementById('txtDate').value;
		        if (dtStr != "") {
		            var daysInMonth = DaysArray(12);
		            var pos1 = dtStr.indexOf(dtCh);
		            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
		            var strMonth = dtStr.substring(0, pos1);
		            var strDay = dtStr.substring(pos1 + 1, pos2);
		            var strYear = dtStr.substring(pos2 + 1);
		            strYr = strYear;

		            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
		            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
		            for (var i = 1; i <= 3; i++) {
		                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
		            }
		            month = parseInt(strMonth);
		            day = parseInt(strDay);
		            year = parseInt(strYr);

		            if (pos1 == -1 || pos2 == -1) {
		                alert("The date format should be : mm/dd/yyyy");
		                document.getElementById('txtDate').value = "";
		                document.getElementById('txtDate').focus();
		                return false;
		            }
		            if (strMonth.length < 1 || month < 1 || month > 12) {
		                alert("Please enter a valid month");
		                document.getElementById('txtDate').value = "";
		                document.getElementById('txtDate').focus();
		                return false;
		            }
		            if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
		                alert("Please enter a valid day");
		                document.getElementById('txtDate').value = "";
		                document.getElementById('txtDate').focus();
		                return false;
		            }
		            if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
		                alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear);
		                document.getElementById('txtDate').value = "";
		                document.getElementById('txtDate').focus();
		                return false;
		            }
		            if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
		                alert("Please enter a valid date");
		                document.getElementById('txtDate').value = "";
		                document.getElementById('txtDate').focus();
		                return false;
		            }
		            //return true;
		        }

		        if (dtStr != "") {
		            var mydate = new Date()
		            var theyear = mydate.getFullYear()
		            var themonth = mydate.getMonth() + 1
		            var thetoday = mydate.getDate()

		            //if (thetoday<10)
		            //{
		            //thetoday="0"+thetoday;
		            //}
		            //var todaysDate=themonth+"/"+thetoday+"/"+theyear

		            //alert(strMonth+ '--' + strDay + '--' + strYear +'Compring'+themonth+ '--' + thetoday + '--' + theyear);

		            //if (dtStr < todaysDate)
		            if (parseInt(strYear) >= parseInt(theyear)) {
		                //alert('greater than current year');
		                if ((strMonth >= themonth && strYear >= theyear) || ((strMonth > 0 && strMonth < 12) && strYear > theyear)) {
		                    //alert('month is greater');
		                    if ((parseInt(strDay) >= parseInt(thetoday) && strYear >= theyear) || (parseInt(strMonth) > parseInt(themonth) && strYear >= theyear) || (parseInt(strDay) < parseInt(thetoday) && parseInt(strYear) > parseInt(theyear))) {
		                        //alert('day is greater');
		                    }
		                    else {
		                        alert('Desired start date should not be less than current date');
		                        document.getElementById('txtDate').value = "";
		                        document.getElementById('txtDate').focus();
		                        return;
		                    }
		                }
		                else {
		                    alert('Desired start date should not be less than current date');
		                    document.getElementById('txtDate').value = "";
		                    document.getElementById('txtDate').focus();
		                    return;
		                }
		            }
		            else {
		                alert('Desired start date should not be less than current date');
		                document.getElementById('txtDate').value = "";
		                document.getElementById('txtDate').focus();
		                return;
		            }


		        }
		    }


		    function OpenDateToWindow() {
		        var txtFromValue = document.getElementById("txtDate").value;
		        window.open('calendar.aspx?formname=Form1.txtDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');
		    }

		    function AddBookMultiUser() {
		        var strTxtPrjLead = document.getElementById("<%=txtAuthors.ClientID %>").id;
		        var hdntxtprjlead = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
		        window.open('ShowUsers.aspx?ID=' + strTxtPrjLead + '&Hidd=' + hdntxtprjlead, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
		        return false;
		    }

//		    function AddBookMultiUser() {
//		        var popResult;
//		        var popres;
//		        popres = document.getElementById('txtAuthors').value;
//		        if (popres != "") {
//		            popResult = window.showModalDialog('ShowUsers.aspx?ShowUserList=' + popres, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		            if (popResult != "")
//		            { document.getElementById('txtAuthors').value = popResult; }
//		            if (document.getElementById('txtAuthors').value == 'undefined') {
//		                document.getElementById('txtAuthors').value = "";
//		            }
//		        }
//		        else {
//		            popResult = window.showModalDialog('ShowUsers.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//		            if (popResult != "")
//		            { document.getElementById('txtAuthors').value = popResult; }
//		            if (document.getElementById('txtAuthors').value == 'undefined') {
//		                document.getElementById('txtAuthors').value = "";
//		            }
//		        }
//		    }

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

		    function AllowDateNumbers(e) {
		        var iKeyCode = 0;
		        if (window.event)
		            iKeyCode = window.event.keyCode
		        else if (e)
		            iKeyCode = e.which;
		        if ((iKeyCode == 46) || (iKeyCode >= 47 && iKeyCode < 58))
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
		            return;
		        }

		        if (!(k >= 0 && k <= 250)) {
		            alert("Please enter the numbers from 0 to 250 only.");
		            document.getElementById(contrlName).value = "";
		            document.getElementById(contrlName).focus();
		            return;
		        }
		    }

		    function CountDecimalsValueThree(val, contrlName) {
		        var k = val;
		        var j = 0;
		        if (k != "") {
		            if (k > 3.0) {
		                for (var i = 0; i < k.length; i++) {
		                    var a = k.charAt(i);
		                    if (a == ".") {
		                        j++;
		                    }
		                }
		                if (j > 1) {
		                    alert("Please enter decimal value");
		                    document.getElementById(contrlName).value = "";
		                    document.getElementById(contrlName).focus();
		                }
		            }
		            else {
		                alert("# Days on Hold should be greater than 3.");
		                document.getElementById(contrlName).value = "";
		                document.getElementById(contrlName).focus();
		            }
		        }
		    }

		    function CountDecimalsandNumbers(val, contrlName) {
		        var k = val;
		        var j = 0;

		        for (var i = 0; i < k.length; i++) {
		            var a = k.charAt(i);
		            if (a == ".")
		                j++;
		        }
		        if (j > 1) {
		            alert("Please enter decimal value.");
		            document.getElementById(contrlName).value = "";
		            document.getElementById(contrlName).focus();
		            return;
		        }

		        if (k >= 0 && k <= 100) {
		        }
		        else {
		            alert("Please enter the numbers from 0 to 100 only.")
		            document.getElementById(contrlName).value = "";
		            document.getElementById(contrlName).focus();
		            return;
		        }
		    }



		    function CalculateLostDays() {
		        var intPaper;
		        var intConverting;
		        var intCombining;
		        if (document.getElementById('drpPaper').selectedIndex != 0) {
		            intPaper = (((100 - parseFloat(document.getElementById('txtPTons').value)) / 100) * parseFloat(document.getElementById('txtPUptime').value)) + parseFloat(document.getElementById('txtPDowntime').value);
		            //document.getElementById('txtPLostValue').value = (((100 -parseFloat(document.getElementById('txtPTons').value)) / 100) * parseFloat(document.getElementById('txtPUptime').value)) + parseFloat(document.getElementById('txtPDowntime').value);
		            document.getElementById('txtPLostValue').value = Math.round(intPaper * 100) / 100;
		        }
		        /*else
		        {
		        alert('Please select paper machine.');
		        }*/
		        if (document.getElementById('drpConLine').selectedIndex != 0) {
		            intConverting = ((parseFloat(document.getElementById('txtConBroke').value) / 100) * parseFloat(document.getElementById('txtConUpTime').value)) + parseFloat(document.getElementById('txtConDownTime').value);
		            //document.getElementById('txtConLostValue').value = ((parseFloat(document.getElementById('txtConBroke').value) / 100) * parseFloat(document.getElementById('txtConUpTime').value)) + parseFloat(document.getElementById('txtConDownTime').value);
		            document.getElementById('txtConLostValue').value = Math.round(intConverting * 100) / 100;
		        }
		        /*else
		        {
		        alert('Please select converting line.');
		        }*/
		        if (document.getElementById('drpComLine').selectedIndex != 0) {
		            intCombining = ((parseFloat(document.getElementById('txtComBroke').value) / 100) * parseFloat(document.getElementById('txtComUpTime').value)) + parseFloat(document.getElementById('txtComDownTime').value);
		            //document.getElementById('txtComLostValue').value = ((parseFloat(document.getElementById('txtComBroke').value) / 100) * parseFloat(document.getElementById('txtComUpTime').value)) + parseFloat(document.getElementById('txtComDownTime').value);
		            document.getElementById('txtComLostValue').value = Math.round(intCombining * 100) / 100;
		        }
		        /*else
		        {
		        alert('Please select combining line.');
		        }*/
		    }
		    function CalculatePaperMachine() {
		        var intResult;
		        if (document.getElementById('drpPaper').selectedIndex != 0) {
		            intResult = (((100 - parseFloat(document.getElementById('txtPTons').value)) / 100) * parseFloat(document.getElementById('txtPUptime').value)) + parseFloat(document.getElementById('txtPDowntime').value);
		            //document.getElementById('txtPLostValue').value = (((100 -parseFloat(document.getElementById('txtPTons').value)) / 100) * parseFloat(document.getElementById('txtPUptime').value)) + parseFloat(document.getElementById('txtPDowntime').value);
		            document.getElementById('txtPLostValue').value = Math.round(intResult * 100) / 100;
		            if (isNaN(document.getElementById('txtPLostValue').value)) {
		                document.getElementById('txtPLostValue').value = 0;
		            }
		        }
		        /*else
		        {
		        alert('Please select paper machine.');
		        }*/
		    }
		    function CalculateConvertingLine() {
		        var intResult;
		        if (document.getElementById('drpConLine').selectedIndex != 0) {
		            intResult = ((parseFloat(document.getElementById('txtConBroke').value) / 100) * parseFloat(document.getElementById('txtConUpTime').value)) + parseFloat(document.getElementById('txtConDownTime').value);
		            //document.getElementById('txtConLostValue').value = ((parseFloat(document.getElementById('txtConBroke').value) / 100) * parseFloat(document.getElementById('txtConUpTime').value)) + parseFloat(document.getElementById('txtConDownTime').value);
		            document.getElementById('txtConLostValue').value = Math.round(intResult * 100) / 100;
		            if (isNaN(document.getElementById('txtConLostValue').value)) {
		                document.getElementById('txtConLostValue').value = 0;
		            }
		        }
		        /*else
		        {
		        alert('Please select converting line.');
		        }*/
		    }
		    function CalculateCombiningMachine() {
		        var intResult;
		        if (document.getElementById('drpComLine').selectedIndex != 0) {
		            intResult = ((parseFloat(document.getElementById('txtComBroke').value) / 100) * parseFloat(document.getElementById('txtComUpTime').value)) + parseFloat(document.getElementById('txtComDownTime').value);
		            //document.getElementById('txtComLostValue').value = ((parseFloat(document.getElementById('txtComBroke').value) / 100) * parseFloat(document.getElementById('txtComUpTime').value)) + parseFloat(document.getElementById('txtComDownTime').value);
		            document.getElementById('txtComLostValue').value = Math.round(intResult * 100) / 100;
		            if (isNaN(document.getElementById('txtComLostValue').value)) {
		                document.getElementById('txtComLostValue').value = 0;
		            }
		        }
		        //else
		        //{
		        //alert('Please select combining line.');
		        //}
		    }
		</script>
</head>
<body onload="window.focus();" MS_POSITIONING="GridLayout">
    <form id="Form1" runat="server">
   <table cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
				<TBODY>
					<tr align="center">
						<td class="FormHeader" colSpan="5">Edit Event</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr align="center">
						<td><asp:imagebutton id="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" 
                                onclick="imgSubmit_Click"></asp:imagebutton>&nbsp;
							<asp:imagebutton id="ingCancel" runat="server" ImageUrl="../Images/cancel.gif" 
                                onclick="ingCancel_Click"></asp:imagebutton>&nbsp;&nbsp;<asp:HiddenField ID="hdntxtPrjLead" runat="server" /></td>
					</tr>
					<TR>
						<TD class="astrisk" align="center" colSpan="2">*- Mandatory Fields</TD>
					</TR>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td align="center" width="100%">
							<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TBODY>
									<tr width="100%">
										<td align="center" width="100%">
											<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
												<TBODY>
													<tr height="5">
														<td colSpan="5"></td>
													</tr>
													<tr align="left">
														<td colSpan="5">
															<table style="BORDER-BOTTOM: #b1c9e8 thin solid; BORDER-LEFT: #b1c9e8 thin solid; BORDER-TOP: #b1c9e8 thin solid; BORDER-RIGHT: #b1c9e8 thin solid"
																cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr bgColor="#ccffff">
																	<td align="center"><asp:label id="lblEventCategory" runat="server" Font-Bold="True" ForeColor="Black">Category</asp:label></td>
																	<td align="center"><asp:label id="lblBrandSegment" runat="server" Font-Bold="True" ForeColor="Black">Brand Segments</asp:label></td>
																	<td align="center"><asp:label id="lblProject" Font-Bold="True" ForeColor="#000000" Runat="server">Project</asp:label></td>
																</tr>
																<tr height="8">
																	<td colSpan="3"></td>
																</tr>
																<tr>
																	<td align="center"><asp:label id="lblCategoryDB" runat="server"></asp:label></td>
																	<td align="center"><asp:label id="lblBrandSegmentDB" runat="server"></asp:label></td>
																	<td align="center"><asp:label id="lblProjectValue" Runat="server"></asp:label></td>
																</tr>
																<tr>
																	<td colSpan="3">&nbsp;</td>
																</tr>
																<tr bgColor="#ccffff">
																	<td align="center" colSpan="2"><asp:label id="lblEOName" Font-Bold="True" ForeColor="#000000" Runat="server">Event Name</asp:label></td>
																	<td align="center"><asp:label id="lblEventType" Font-Bold="True" ForeColor="#000000" Runat="server">Event Type</asp:label></td>
																</tr>
																<tr height="8">
																	<td colSpan="3"></td>
																</tr>
																<tr>
																	<td align="center" colSpan="2"><asp:label id="lblEONameValue" Runat="server"></asp:label></td>
																	<TD align="center"><asp:label id="lblEventTypeValue" Runat="server"></asp:label></TD>
																</tr>
															</table>
														</td>
													</tr>
													<tr align="left">
														<td colSpan="5" height="10">&nbsp;
														</td>
													</tr>
													<tr align="left">
														<td colSpan="5">
															<table style="BORDER-BOTTOM: #b1c9e8 thin solid; BORDER-LEFT: #b1c9e8 thin solid; BORDER-TOP: #b1c9e8 thin solid; BORDER-RIGHT: #b1c9e8 thin solid"
																cellSpacing="0" cellPadding="0" border="0">
																<TBODY>
																	<tr align="center" bgColor="#ccffff">
																		<td><asp:label id="lblPlant" Font-Bold="True" ForeColor="#000000" Runat="server">Plant</asp:label></td>
																		<td><asp:label id="lblDSDate" Font-Bold="True" ForeColor="#000000" Runat="server">Desired Start Date</asp:label></td>
																		<td><asp:label id="lblShippable" Font-Bold="True" ForeColor="#000000" Runat="server">Is this Product Shippable?</asp:label></td>
																		<td id="tdGDays" runat="server"><asp:label id="lblGDays" Font-Bold="True" ForeColor="#000000" Runat="server">On Hold for > 3 Days</asp:label></td>
																		<td id="tdDays" runat="server"><asp:label id="lblDays" Font-Bold="True" ForeColor="#000000" Runat="server"># Days on Hold</asp:label></td>
																	</tr>
																	<tr height="8">
																		<td colSpan="5"></td>
																	</tr>
																	<tr align="center">
																		<td align="center" valign="top" width="30%"><asp:label id="lblPlantValue" Runat="server"></asp:label></td>
																		<td onkeypress="javascript: return AllowDateNumbers(event);" align="center" valign="top" width="30%"><asp:textbox id="txtDate" tabIndex="1" Runat="server" Width="120px"></asp:textbox><IMG id="img2" style="CURSOR: hand" onclick="OpenDateToWindow()" alt="To Date" src="../Images/calendar.gif"
																				runat="server">
																			<asp:label id="Label3" Font-Bold="True" ForeColor="#ff3333" Runat="server">*</asp:label><br>
																			Format MM/DD/YYYY</td>
																		<td align="center" valign="top" width="15%"><asp:label id="lblShippableValue" Runat="server" Visible="False"></asp:label>
                                                                            <asp:radiobuttonlist id="rdbShippable" tabIndex="8" runat="server" 
                                                                                AutoPostBack="true" onselectedindexchanged="rdbShippable_SelectedIndexChanged1">
																				<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
																				<asp:ListItem Value="Y">Yes</asp:ListItem>
																			</asp:radiobuttonlist></td>
														</td>
														<td id="tdrdbDays" align="center" valign="top" width="15%" runat="server"><asp:label id="lblGDaysValue" Runat="server" Visible="False"></asp:label>
                                                            <asp:radiobuttonlist id="rdbOnhold" tabIndex="9" runat="server" 
                                                                AutoPostBack="true" onselectedindexchanged="rdbOnhold_SelectedIndexChanged1">
																<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
																<asp:ListItem Value="Y">Yes</asp:ListItem>
															</asp:radiobuttonlist></td>
														<td onkeypress="javascript: return AllowNumeric(event);" id="tdtxtDays" align="center" valign="top"
															runat="server"><asp:label id="lblDaysValue" Runat="server" Visible="False"></asp:label><asp:textbox id="txtDays" tabIndex="10" Runat="server" Width="80PX" MaxLength="4"></asp:textbox></td>
													</tr>
												</TBODY>
											</table>
										</td>
									</tr>
									<tr>
										<td colSpan="5">&nbsp;</td>
									</tr>
									<tr align="center">
										<td colSpan="5">
											<table style="BORDER-BOTTOM: #b1c9e8 thin solid; BORDER-LEFT: #b1c9e8 thin solid; BORDER-TOP: #b1c9e8 thin solid; BORDER-RIGHT: #b1c9e8 thin solid"
												cellSpacing="0" cellPadding="1" width="100%" border="0">
												<TBODY>
													<tr bgColor="#ccffff">
														<td align="center"><asp:label id="lblPaper" Font-Bold="True" ForeColor="#000000" Runat="server">Paper Machine</asp:label></td>
														<td align="center"><asp:label id="lblPTotalLost" Font-Bold="True" ForeColor="#000000" Runat="server">Total Lost<br>Paper Making Days</asp:label></td>
														<td align="center" colSpan="3"><asp:label id="lblPComments" Font-Bold="True" ForeColor="#000000" Runat="server">Specific<br>Comments for Planning</asp:label></td>
													</tr>
													<tr height="8">
														<td colSpan="5"></td>
													</tr>
													<tr>
														<td width="20%" align="center" valign="top"><asp:dropdownlist id="drpPaper" tabIndex="2" Runat="server" 
                                                                Width="125px" AutoPostBack="True" 
                                                                onselectedindexchanged="drpPaper_SelectedIndexChanged1">
																<asp:ListItem Value="0">Select Plant First</asp:ListItem>
															</asp:dropdownlist><asp:label id="Label10" Font-Bold="True" ForeColor="#ff3333" Runat="server">*</asp:label></td>
														<td onkeypress="javascript: return AllowNumeric(event);" align="center" valign="top" width="20%"><asp:label id="lblPLostValue" Runat="server" Visible="False">0</asp:label><asp:textbox id="txtPLostValue" tabIndex="3" runat="server" Width="120px" ReadOnly="false">0</asp:textbox></td>
														<td align="center" valign="top" width="60%" colSpan="3"><asp:textbox id="txtPComments" tabIndex="4" Runat="server" Width="350px"></asp:textbox></td>
													</tr>
												</TBODY>
											</table>
										</td>
									</tr>
									<tr align="left">
										<td colSpan="5" height="10">&nbsp;
										</td>
									</tr>
									<tr align="left">
										<td colSpan="5">
											<table style="BORDER-BOTTOM: #b1c9e8 thin solid; BORDER-LEFT: #b1c9e8 thin solid; BORDER-TOP: #b1c9e8 thin solid; BORDER-RIGHT: #b1c9e8 thin solid"
												cellSpacing="0" cellPadding="1" width="100%" align="center" border="0">
												<TBODY>
													<tr bgColor="#ccffff">
														<td align="center"><asp:label id="lblConLine" Font-Bold="True" ForeColor="#000000" Runat="server">Converting Line</asp:label></td>
														<td align="center"><asp:label id="lblConLost" Font-Bold="True" ForeColor="#000000" Runat="server">Total Lost<br>Converting Days</asp:label></td>
														<td align="center" colSpan="3"><asp:label id="lblConComments" Font-Bold="True" ForeColor="#000000" Runat="server">Specific<br>Comments for Planning</asp:label></td>
													</tr>
													<tr height="8">
														<td colSpan="5"></td>
													</tr>
													<tr>
														<td width="20%" align="center" valign="top"><asp:dropdownlist id="drpConLine" tabIndex="5" Runat="server" 
                                                                Width="125px" AutoPostBack="True" 
                                                                onselectedindexchanged="drpConLine_SelectedIndexChanged1">
																<asp:ListItem Value="0">None</asp:ListItem>
															</asp:dropdownlist><asp:label id="Label12" Font-Bold="True" ForeColor="#ff3333" Runat="server">*</asp:label></td>
														<td onkeypress="javascript: return AllowNumeric(event);" align="center" valign="top" width="20%"><asp:label id="lblConLostValue" Runat="server" Visible="False">0</asp:label><asp:textbox id="txtConLostValue" tabIndex="6" runat="server" Width="120px" ReadOnly="false">0</asp:textbox></td>
														<td align="center" valign="top" width="60%" colSpan="3"><asp:textbox id="txtConComments" tabIndex="7" Runat="server" Width="350px"></asp:textbox></td>
													</tr>
												</TBODY>
											</table>
										</td>
									</tr>
									<tr align="left" height="8">
										<td colSpan="5">&nbsp;</td>
									</tr>
									<tr align="left">
										<td colSpan="5">
											<table style="BORDER-BOTTOM: #b1c9e8 thin solid; BORDER-LEFT: #b1c9e8 thin solid; BORDER-TOP: #b1c9e8 thin solid; BORDER-RIGHT: #b1c9e8 thin solid"
												cellSpacing="0" cellPadding="1" width="100%" align="center" border="0">
												<tr bgColor="#ccffff">
													<td align="center"><asp:label id="lblComLine" Font-Bold="True" ForeColor="#000000" Runat="server">Combining Line</asp:label><br>
													</td>
													<td align="center"><asp:label id="lblComLost" Font-Bold="True" ForeColor="#000000" Runat="server">Total Lost<br>Combining Days</asp:label><br>
													</td>
													<td colSpan="3">&nbsp;</td>
												</tr>
												<tr height="8">
													<td colSpan="5"></td>
												</tr>
												<tr>
													<td width="20%" align="center" valign="top"><asp:dropdownlist id="drpComLine" tabIndex="8" Runat="server" Width="125px" AutoPostBack="true">
															<asp:ListItem Value="0">None</asp:ListItem>
														</asp:dropdownlist><asp:label id="Label11" Font-Bold="True" ForeColor="#ff3333" Runat="server">*</asp:label></td>
													<td onkeypress="javascript: return AllowNumeric(event);" align="center" valign="top" width="20%"><asp:label id="lblComLostValue" Runat="server" Visible="False">0</asp:label><asp:textbox id="txtComLostValue" tabIndex="9" runat="server" Width="120px">0</asp:textbox></td>
													<td width="60%" colSpan="3" align="center" valign="top">&nbsp;</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td colSpan="5">&nbsp;</td>
									</tr>
									<tr align="center">
										<td colSpan="5">
											<table style="BORDER-BOTTOM: #b1c9e8 thin solid; BORDER-LEFT: #b1c9e8 thin solid; BORDER-TOP: #b1c9e8 thin solid; BORDER-RIGHT: #b1c9e8 thin solid"
												cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td></td>
													<td></td>
													<td align="center" bgColor="#ccffff"><asp:label id="lblCategory" Font-Bold="True" ForeColor="#000000" Runat="server">Category</asp:label></td>
													<td></td>
													<td></td>
												</tr>
												<tr height="8">
													<td colSpan="5"></td>
												</tr>
												<tr>
													<td></td>
													<td></td>
													<td align="center"><asp:label id="lblSelCategory" ForeColor="#000000" Runat="server"></asp:label></td>
													<td></td>
													<td></td>
												</tr>
												<tr align="center" bgColor="#ccffff">
													<td align="center"><asp:label id="lblBrand" Font-Bold="True" ForeColor="#000000" Runat="server">Brand Type</asp:label></td>
													<td align="center"><asp:label id="lblPrjType" Font-Bold="True" ForeColor="#000000" Runat="server">Project Type</asp:label></td>
													<td align="center"><asp:label id="lblPrjLeader" Font-Bold="True" ForeColor="#000000" Runat="server">Project Leader</asp:label></td>
													<td align="center"><asp:label id="lblPOC" Font-Bold="True" ForeColor="#000000" Runat="server">POC</asp:label></td>
													<td align="center"><asp:label id="lblOriginator" Font-Bold="True" ForeColor="#000000" Runat="server">Originator</asp:label><br>
													</td>
												</tr>
												<tr height="8">
													<td colSpan="5"></td>
												</tr>
												<tr>
													<td align="center" height="10"><asp:label id="lblBrandValue" ForeColor="#000000" Runat="server"></asp:label></td>
													<td align="center" height="10"><asp:label id="lblPrjTypeValue" ForeColor="#000000" Runat="server"></asp:label></td>
													<td align="center" height="10"><asp:label id="lblPrjLeaderValue" ForeColor="#000000" Runat="server"></asp:label></td>
													<td align="center" height="10"><asp:label id="lblPOCValue" ForeColor="#000000" Runat="server"></asp:label></td>
													<td align="center" height="10"><asp:label id="lblOriginatorValue" ForeColor="#000000" Runat="server"></asp:label></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr height="8">
										<td colSpan="5"></td>
									</tr>
									<tr >
										<td colSpan="5" align="center" valign="top"><asp:label id="lblAuthors1" Font-Bold="True" ForeColor="#0033ff" Runat="server">Other Authors:</asp:label>&nbsp;<asp:textbox 
                                                id="txtAuthors" tabIndex="10" Runat="server" Width="511px" Enabled="False" 
                                                EnableViewState=true MaxLength="2000" ViewStateMode="Enabled"></asp:textbox><asp:imagebutton id="imgAddressBook" tabIndex="11" Runat="server" ImageUrl="../Images/addressbook.gif"
												CausesValidation="False"></asp:imagebutton>&nbsp;
											<asp:imagebutton id="imgDeleteName" tabIndex="12" runat="server" ImageUrl="../Images/del-name.jpg"
												AlternateText="Del" onclick="imgDeleteName_Click"></asp:imagebutton></td>
									</tr>
									<tr height="8">
										<td colSpan="5"></td>
									</tr>
									<tr>
										<td style="HEIGHT: 6px" align="left" colSpan="5"><asp:label id="lblEdit1" Font-Bold="True" ForeColor="#3333ff" Runat="server">Edit History</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
									</tr>
									<tr>
										<td colSpan="5"></td>
									</tr>
									<tr>
										<td colSpan="5">
											<hr>
											<asp:datagrid id="dgdShowHistory" runat="server" Width="30%" AutoGenerateColumns="False" CssClass="SubHeader">
												<AlternatingItemStyle CssClass="Alternaterow2"></AlternatingItemStyle>
												<ItemStyle CssClass="AlternateRow1"></ItemStyle>
												<HeaderStyle CssClass="subHeader"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="Rev_Editor" HeaderText="Edited By"></asp:BoundColumn>
													<asp:BoundColumn DataField="Created_Date" HeaderText="Edited Date"></asp:BoundColumn>
												</Columns>
											</asp:datagrid></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE>
    </form>
</body>
</html>
