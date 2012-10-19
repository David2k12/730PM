<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEditEvent.aspx.cs" Inherits="MUREOUI.Common.frmEditEvent" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Event</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
<!--
        function showusersAppd(txtID) {
            if (txtID == 'imgAddressBook') {

                if (document.Form1.txtAuthors.text != "")
                    window.open('LookUpNames.aspx?formname1=Form1.txtAuthors&Gno=1', null, 'height=450,width=700,status=no,menubar=no,toolbar=no');
                else
                    window.open('LookUpNames.aspx?formname1=Form1.txtAuthors&Gno=2', null, 'height=450,width=700,status=no,menubar=no,toolbar=no');
            }
        }
        function showusersAppd(txtID) {
            if (txtID == 'lnkAuthors') {

                if (document.Form1.txtAuthors.text != "")
                    window.open('LookUpNames.aspx?formname1=Form1.txtAuthors&Gno=1', null, 'height=450,width=700,status=no,menubar=no,toolbar=no');
                else
                    window.open('LookUpNames.aspx?formname1=Form1.txtAuthors&Gno=2', null, 'height=450,width=700,status=no,menubar=no,toolbar=no');
            }

        }
        function OpenDateToWindow() {
            var txtFromValue = document.getElementById("txtDate").value;
            window.open('calendar.aspx?formname=Form1.txtDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');
        }

        //-->

        //New Code

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

        function AddBookMultiUser() {
            var popResult;
            var popres;
            var strAuthors = document.getElementById('txtAuthors').id;
            var hdnAuthors = document.getElementById('hdnAuthors').id;
            popres = document.getElementById('txtAuthors').value;
            if (popres == "")
                window.open('ShowUsers.aspx?ID=' + strAuthors + '&Hidd=' + hdnAuthors, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('ShowUsers.aspx?ShowUserList=' + popres + '&ID=' + strAuthors + '&Hidd=' + hdnAuthors, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
//            var popResult;
//            var popres;
//            var strAuthors = document.getElementById('txtAuthors').value;
//            popres = document.getElementById('txtAuthors').value;
//            if (popres != "") {
//                popResult = window.showModalDialog('ShowUsers.aspx?ShowUserList=' + popres, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//                if (popResult != "")
//                { document.getElementById('txtAuthors').value = popResult; }
//                if (document.getElementById('txtAuthors').value == 'undefined') {
//                    document.getElementById('txtAuthors').value = strAuthors;
//                }
//            }
//            else {
//                popResult = window.showModalDialog('ShowUsers.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//                if (popResult != "")
//                { document.getElementById('txtAuthors').value = popResult; }
//                if (document.getElementById('txtAuthors').value == 'undefined') {
//                    document.getElementById('txtAuthors').value = strAuthors;
//                }
//            }
        }

        function ConfirmDelete(messageVal, cntrlName) {
            if (document.getElementById(cntrlName).value != "") {
                var agree = confirm(messageVal);
                if (agree == true) {
                    //return true;
                    document.getElementById(cntrlName).value = "";
                }
                else {
                    //return false;
                }
            }
        }
        //Previous Code
        /*function AddBookMultiUser()
        {
        var popResult;
        popResult=window.showModalDialog('ShowUsers.aspx?from=CheckingUser','ShowUsers','status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
        if(popResult!="")
        {document.getElementById('txtAuthors').value = popResult;} 
        if (document.getElementById('txtAuthors').value == 'undefined')
        {
        document.getElementById('txtAuthors').value = "";
        }
        }*/

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

        //Screen Resolution code
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
        }
    </script>
    <style type="text/css">
        .popupControl
        {
            position: absolute;
            top: 300px;
            left: 700px;
            width: 100%;
            height: 100%;
            opacity: 0.9;
            z-index: 499;
        }
    </style>
</head>
<body bottommargin="0"  leftmargin="0" topmargin="0" rightmargin="0"
    ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table height="500px" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                <tbody>
                    <tr>
                        <td>
                            <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                            <asp:HiddenField ID="hdnAuthors" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="FormHeader" valign="top" align="center">
                            <asp:Label ID="lblHeading" Font-Bold="True" ForeColor="#3333ff" runat="server" Width="795">Edit Event</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="astrisk" align="center" colspan="2">
                            *- Mandatory Fields
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:ImageButton ID="imgSubmit" OnClick="imgSubmit_Click" runat="server" ImageUrl="../Images/submit.gif"></asp:ImageButton>&nbsp;
                            <asp:ImageButton ID="imgMigSiteTest" OnClick="imgMigSiteTest_Click" runat="server" ImageUrl="../Images/Migrate-to-Site-Test.gif"
                                AlternateText="Migrate to Site Test"></asp:ImageButton>&nbsp;
                            <asp:ImageButton ID="imgDelete" OnClick="imgDelete_Click" runat="server" ImageUrl="../Images/New-Delete.gif"
                                CausesValidation="False"></asp:ImageButton>&nbsp;
                            <asp:ImageButton ID="imgCancel" OnClick="imgCancel_Click" runat="server" ImageUrl="../Images/cancel.gif" CausesValidation="False">
                            </asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%">
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <div id="divTest" style="z-index: 0; width: 100%; height: 550px; overflow: auto">
                                                <table cellspacing="0" cellpadding="0" width="795" align="center" border="0">
                                                    <tbody>
                                                        <tr height="5">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td colspan="5">
                                                                <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                    border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                                    cellpadding="0" width="100%" border="0">
                                                                    <tr align="center" bgcolor="#ccffff">
                                                                        <td width="35%" valign="top" align="center">
                                                                            <asp:Label ID="lblEventCategory" runat="server" Font-Bold="True" ForeColor="Black"
                                                                                CssClass="FormFields">Category</asp:Label>
                                                                        </td>
                                                                        <td width="35%" valign="top" align="center">
                                                                            <asp:Label ID="lblBrandSegments" runat="server" Font-Bold="True" ForeColor="Black"
                                                                                CssClass="FormFields">Brand Segments</asp:Label>
                                                                        </td>
                                                                        <td width="35%" valign="top" align="center">
                                                                            <asp:Label ID="lblProject" Font-Bold="True" ForeColor="#000000" runat="server">Project</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="center" valign="top" align="center">
                                                                        <td width="35%">
                                                                            <asp:DropDownList ID="drpCategoryDB" TabIndex="1" runat="server" Width="200px" OnSelectedIndexChanged="drpCategoryDB_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                            <font color="#ff3333">*</font>
                                                                        </td>
                                                                        <td width="35%" valign="top" align="center">
                                                                            <asp:DropDownList ID="drpBrandSegmentDB" TabIndex="2" OnSelectedIndexChanged="drpBrandSegmentDB_SelectedIndexChanged"
                                                                                runat="server" Width="200px" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                            <font color="#ff3333">*</font>
                                                                        </td>
                                                                        <td width="35%" valign="top" align="center">
                                                                            <asp:DropDownList ID="drpProject" OnSelectedIndexChanged="drpProject_SelectedIndexChanged"
                                                                                TabIndex="3" runat="server" Width="200px" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="Label1" Font-Bold="True" ForeColor="#ff3333" runat="server">*</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="center" bgcolor="#ccffff">
                                                                        <!--<td bgColor="#cccccc" colSpan="1"></td>-->
                                                                        <td width="60%" colspan="2" valign="top" align="center">
                                                                            <asp:Label ID="lblEOName" Font-Bold="True" ForeColor="#000000" runat="server">Event Name</asp:Label>
                                                                        </td>
                                                                        <td width="40%" valign="top" align="center">
                                                                            <asp:Label ID="lblEventType" Font-Bold="True" ForeColor="#000000" runat="server">Event Type</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="center">
                                                                        <!--<td colSpan="1"></td>-->
                                                                        <td onkeypress="javascript: return NoSpecialCharacters(event);" width="60%" colspan="2" valign="top" align="center">
                                                                            <asp:TextBox ID="txtEOName" TabIndex="4" runat="server" Width="400px"></asp:TextBox><font
                                                                                color="#ff3333">*</font>
                                                                        </td>
                                                                        <td width="40%" valign="top" align="center">
                                                                            <asp:DropDownList ID="drpEventType" TabIndex="5" runat="server" Width="200px">
                                                                                <asp:ListItem Value="0">Select Event Type</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="Label5" Font-Bold="True" ForeColor="#ff3333" runat="server">*</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr align="left" height="8">
                                                            <td colspan="5">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td colspan="5">
                                                                <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                    border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                                    cellpadding="0" width="100%" border="0">
                                                                    <tr align="center" bgcolor="#ccffff" valign="top" align="center">
                                                                        <td>
                                                                            <asp:Label ID="lblPlant" Font-Bold="True" ForeColor="#000000" runat="server">Plant</asp:Label>
                                                                        </td>
                                                                        <td valign="top" align="center">
                                                                            <asp:Label ID="lblDSDate" Font-Bold="True" ForeColor="#000000" runat="server">Desired Start Date</asp:Label>
                                                                        </td>
                                                                        <td valign="top" align="center">
                                                                            <asp:Label ID="lblShippable" Font-Bold="True" ForeColor="#000000" runat="server">Is this Product Shippable?</asp:Label>
                                                                        </td valign="top" align="center">
                                                                        <td id="tdGDays" runat="server">
                                                                            <asp:Label ID="lblGDays" Font-Bold="True" ForeColor="#000000" runat="server">On Hold for > 3 Days</asp:Label>
                                                                        </td valign="top" align="center">
                                                                        <td id="tdDays" runat="server" valign="top" align="center">
                                                                            <asp:Label ID="lblDays" Font-Bold="True" ForeColor="#000000" runat="server"># Days on Hold</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="center">
                                                                        <td  width="30%" valign="top" align="center">
                                                                            <asp:DropDownList ID="drpPlant" OnSelectedIndexChanged="drpPlant_SelectedIndexChanged"
                                                                                TabIndex="6" runat="server" Width="150px" AutoPostBack="true">
                                                                                <asp:ListItem Value="0">Select a Plant</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="Label2" Font-Bold="True" ForeColor="#ff3333" runat="server">*</asp:Label>
                                                                        </td>
                                                                        <td onkeypress="javascript: return AllowDateNumbers(event);" valign="top" align="center" width="30%">
                                                                            <asp:TextBox ID="txtDate" TabIndex="7" runat="server" Width="120px"></asp:TextBox><img
                                                                                id="img2" style="cursor: hand" onclick="OpenDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                                runat="server"><asp:Label ID="Label3" TabIndex="8" Font-Bold="True" ForeColor="#ff3333"
                                                                                    runat="server">*</asp:Label><br>
                                                                            Format MM/DD/YYYY
                                                                        </td>
                                                                        <td valign="top" align="center" width="15%">
                                                                            <asp:RadioButtonList ID="rdbShippable" OnSelectedIndexChanged="rdbShippable_SelectedIndexChanged" TabIndex="8" runat="server" AutoPostBack="true">
                                                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td id="tdrdbDays" valign="top" align="center" width="15%" runat="server">
                                                                            <asp:RadioButtonList ID="rdbOnhold" OnSelectedIndexChanged="rdbOnhold_SelectedIndexChanged" TabIndex="9" runat="server" AutoPostBack="true">
                                                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td onkeypress="javascript: return AllowNumeric(event);" id="tdtxtDays" valign="top" align="center"
                                                                            runat="server">
                                                                            <asp:TextBox ID="txtDays" TabIndex="10" runat="server" Width="80PX" MaxLength="4"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr height="8">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td colspan="5">
                                                                <asp:Label ID="Label4" Font-Bold="True" ForeColor="#ff3300" runat="server">*Atleast one of the following is required Paper Machine,Converting Line or Combiner</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr height="8">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td colspan="5">
                                                                <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                    border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                                    cellpadding="1" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr bgcolor="#ccffff">
                                                                            <td valign="top" align="center">
                                                                                <asp:Label ID="lblPaper" Font-Bold="True" ForeColor="#000000" runat="server">Paper Machine</asp:Label>
                                                                            </td>
                                                                            <td valign="top" align="center">
                                                                                <asp:Label ID="lblPTotalLost" Font-Bold="True" ForeColor="#000000" runat="server">Total  Number of <br> Papermaking Days</asp:Label>
                                                                            </td>
                                                                            <td valign="top" align="center" colspan="3">
                                                                                <asp:Label ID="lblPComments" Font-Bold="True" ForeColor="#000000" runat="server">Specific<br>Comments for Planning</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="8">
                                                                            <td colspan="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="20%" valign="top" align="center">
                                                                                <asp:DropDownList ID="drpPaper" OnSelectedIndexChanged="drpPaper_SelectedIndexChanged"
                                                                                    TabIndex="11" runat="server" Width="170px" AutoPostBack="True">
                                                                                    <asp:ListItem Value="0">Select Plant First</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:Label ID="Label10" Font-Bold="True" ForeColor="#ff3333" runat="server">*</asp:Label>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);" valign="top" align="center" width="20%">
                                                                                <asp:Label ID="lblPLostValue" runat="server" Visible="False">0</asp:Label><asp:TextBox
                                                                                    ID="txtPLostValue" TabIndex="12" runat="server" Width="120px" ReadOnly="false">0</asp:TextBox>
                                                                            </td>
                                                                            <td valign="top" align="center" width="60%" colspan="3">
                                                                                <asp:TextBox ID="txtPComments" TabIndex="13" runat="server" Width="350px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td colspan="5" height="10">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td colspan="5">
                                                                <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                    border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                                    cellpadding="1" width="100%" align="center" border="0">
                                                                    <tbody>
                                                                        <tr bgcolor="#ccffff">
                                                                            <td valign="top" align="center">
                                                                                <asp:Label ID="lblConLine" Font-Bold="True" ForeColor="#000000" runat="server">Converting Line</asp:Label>
                                                                            </td>
                                                                            <td valign="top" align="center">
                                                                                <asp:Label ID="lblConLost" Font-Bold="True" ForeColor="#000000" runat="server">Total Number of<br>Converting Days</asp:Label>
                                                                            </td>
                                                                            <td valign="top" align="center" colspan="3">
                                                                                <asp:Label ID="lblConComments" Font-Bold="True" ForeColor="#000000" runat="server">Specific Comments for Planning</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="8">
                                                                            <td style="height: 16px" colspan="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="20%" valign="top" align="center">
                                                                                <asp:DropDownList ID="drpConLine" OnSelectedIndexChanged="drpConLine_SelectedIndexChanged"
                                                                                    TabIndex="14" runat="server" Width="170px" AutoPostBack="True">
                                                                                    <asp:ListItem Value="0">None</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:Label ID="Label12" Font-Bold="True" ForeColor="#ff3333" runat="server">*</asp:Label>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);" valign="top" align="center" width="20%">
                                                                                <asp:Label ID="lblConLostValue" runat="server" Visible="False">0</asp:Label><asp:TextBox
                                                                                    ID="txtConLostValue" TabIndex="15" runat="server" Width="120px" ReadOnly="false">0</asp:TextBox>
                                                                            </td>
                                                                            <td valign="top" align="center" width="60%" colspan="3">
                                                                                <asp:TextBox ID="txtConComments" TabIndex="16" runat="server" Width="350px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr align="left" height="8">
                                                            <td colspan="5">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td colspan="5">
                                                                <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                    border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                                    cellpadding="1" width="100%" align="center" border="0">
                                                                    <tr bgcolor="#ccffff">
                                                                        <td valign="top" align="center">
                                                                            <asp:Label ID="lblComLine" Font-Bold="True" ForeColor="#000000" runat="server">Combining Line</asp:Label><br>
                                                                        </td>
                                                                        <td valign="top" align="center">
                                                                            <asp:Label ID="lblComLost" Font-Bold="True" ForeColor="#000000" runat="server">Total  Number of<br>Combining Days</asp:Label><br>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="20%" valign="top" align="center">
                                                                            <asp:DropDownList ID="drpComLine" OnSelectedIndexChanged="drpComLine_SelectedIndexChanged"
                                                                                TabIndex="17" runat="server" Width="170px" AutoPostBack="true">
                                                                                <asp:ListItem Value="0">None</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="Label11" Font-Bold="True" ForeColor="#ff3333" runat="server">*</asp:Label>
                                                                        </td>
                                                                        <td onkeypress="javascript: return AllowNumeric(event);" valign="top" align="center" width="20%">
                                                                            <asp:Label ID="lblComLostValue" runat="server" Visible="False">0</asp:Label><asp:TextBox
                                                                                ID="txtComLostValue" TabIndex="18" runat="server" Width="120px">0</asp:TextBox>
                                                                        </td>
                                                                        <td width="60%" valign="top" align="center" colspan="3">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td colspan="5">
                                                                <table style="border-bottom: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                    border-top: #b1c9e8 thin solid; border-right: #b1c9e8 thin solid" cellspacing="0"
                                                                    cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td valign="top" align="center" bgcolor="#ccffff">
                                                                            <asp:Label ID="lblCategory" Font-Bold="True" ForeColor="#000000" runat="server">Category</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td valign="top" align="center">
                                                                            <asp:Label ID="lblSelCategory" ForeColor="#000000" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr valign="top" align="center" bgcolor="#ccffff">
                                                                        <td align="center">
                                                                            <asp:Label ID="lblBrand" Font-Bold="True" ForeColor="#000000" runat="server">Brand Type</asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblPrjType" Font-Bold="True" ForeColor="#000000" runat="server">Project Type</asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblPrjLeader" Font-Bold="True" ForeColor="#000000" runat="server">Project Leader</asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblPOC" Font-Bold="True" ForeColor="#000000" runat="server">POC</asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblOriginator" Font-Bold="True" ForeColor="#000000" runat="server">Originator</asp:Label><br>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="8">
                                                                        <td colspan="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="center" height="10">
                                                                            <asp:Label ID="lblBrandValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" align="center" height="10">
                                                                            <asp:Label ID="lblPrjTypeValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" align="center" height="10">
                                                                            <asp:Label ID="lblPrjLeaderValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" align="center" height="10">
                                                                            <asp:Label ID="lblPOCValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" align="center" height="10">
                                                                            <asp:Label ID="lblOriginatorValue" ForeColor="#000000" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr height="8">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td colspan="5" valign="top" align="center">
                                                                <asp:Label ID="lblAuthors1" Font-Bold="True" ForeColor="#0033ff" runat="server">Other Authors:</asp:Label>&nbsp;<asp:TextBox
                                                                    ID="txtAuthors" TabIndex="19" runat="server" Width="600" ReadOnly="True"></asp:TextBox><asp:ImageButton
                                                                        ID="imgAddressBook" TabIndex="20" runat="server" ImageUrl="../Images/addressbook.gif"
                                                                        CausesValidation="False"></asp:ImageButton>&nbsp;
                                                                <asp:ImageButton ID="imgDeleteName" OnClick="imgDeleteName_Click" TabIndex="21" runat="server" ImageUrl="../Images/del-name.jpg"
                                                                    AlternateText="Del"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr height="8">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 6px" valign="top" align="left" colspan="5">
                                                                <asp:Label ID="lblEdit1" Font-Bold="True" ForeColor="#3333ff" runat="server">Edit History</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5" valign="top" align="left">
                                                                <hr>
                                                                <asp:DataGrid ID="dgdShowHistory" runat="server" Width="30%" AutoGenerateColumns="False">
																	
																	<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																	<HeaderStyle Font-Bold="true" BackColor="#FFCC00"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="Rev_Editor" HeaderText="Edited By"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Created_Date" HeaderText="Edited Date"></asp:BoundColumn>
                                                                    </Columns>
                                                                </asp:DataGrid><asp:ValidationSummary ID="vsNewEvent" runat="server" ShowMessageBox="True"
                                                                    DisplayMode="List"></asp:ValidationSummary>
                                                                <asp:Label ID="lblUser" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc2:FooterControl ID="FooterControl1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
