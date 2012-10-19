<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNewEvent.aspx.cs" Inherits="MUREOUI.frmNewEvent" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc1" %>

<%@ Register src="~/UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>New Event</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
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

                        }
                        else {
                            alert('Desired start date should not be less than current date');
                            document.getElementById('txtDate').value = "";
                            document.getElementById('txtDate').focus();
                            //alert('Day is greater');
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


        //New Code
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

        //Previous Code
        /*var popResult;
        popResult=window.showModalDialog('ShowUsers.aspx?from=CheckingUser','ShowUsers','status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
        if(popResult!="")
        {document.getElementById('txtAuthors').value = popResult;} 
        if (document.getElementById('txtAuthors').value == 'undefined')
        {
        document.getElementById('txtAuthors').value = "";
        }
        }*/

        function OpenDateToWindow() {
            var txtFromValue = document.getElementById("txtDate").value

            window.open('../Common/calendar.aspx?formname=Form1.txtDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');
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

        function NoSpecialCharacters() {
            var k;
            k = event.keyCode;

            if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
                //event.returnValue=true;
                return true;
            }
            else {
                //alert("Enter characters and Digits Only")
                //event.returnValue=false;
                return false;
            }
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
                alert("Please enter decimal value.");
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

        function checkPaperValues() {
            //alert("jagan checkPaperValues");
            //Form1.txtPLostValue.value = '0';
            //Form1.lblPLostValue.value = '0';
            //Form1.txtPComments.value = '';
            //document.getElementById('lblPLostValue').innerText = "0";
            //document.getElementById("txtPLostValue").innerText= "0";
            //document.getElementById("txtPComments").innerText= "";
        }
        function cheComLineValues() {
            //alert("jagan cheComLineValues");
            //document.getElementById('lblComLostValue').value= 0;
            //document.getElementById('txtComLostValue').value= 0;
            Form1.txtComLostValue.value = '0';

        }

        function cheConLineValues() {
            //alert("jagan cheConLineValues");
            //document.getElementById('lblConLostValue').value= 0;
            //document.getElementById('txtConLostValue').value= 0;
            //document.getElementById('txtConComments').value= "";
            Form1.txtConLostValue.value = '0';
            Form1.txtConComments.value = '';
        }


        function CalculatePaperMachine() {
            //alert("hello");
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
            //alert("hello");
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
            //alert("hello");
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
            document.getElementById("divTest").style.height = (screen.height - 440); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

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
<body>
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                <!--opening of second table-->
                <tbody>
                    <tr>
                        <td>
                            <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                            <asp:HiddenField ID="hdnAuthors" runat="server" />
                        </td>
                    </tr>
                    <tr align="center" style="width: 100%">
                        <td class="FormHeader">
                            <asp:Label ID="lblHeading" runat="server" ForeColor="#3333ff" Font-Bold="True">New Event</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <table cellspacing="0" cellpadding="0" width="755" align="center" border="0">
                                <tr align="left">
                                    <td colspan="5">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr align="center">
                                                <td width="9%" valign="top">
                                                    <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" AlternateText="Submit" ToolTip="Submit"
                                                        OnClick="imgSubmit_Click"></asp:ImageButton>
                                                </td>
                                                <td width="28%" valign="top">
                                                    <asp:ImageButton ID="imgSaveCreateNew" runat="server" ImageUrl="../Images/submit-create-new-event.gif" ToolTip="Submit &amp; Create New Event"
                                                        AlternateText="Submit &amp; Create New Event" OnClick="imgSaveCreateNew_Click">
                                                    </asp:ImageButton>
                                                </td>
                                                <td width="30%" valign="top">
                                                    <asp:ImageButton ID="imgSaveCreate" runat="server" ImageUrl="../Images/Save-Create-Event-on-Same.gif" ToolTip="Submit &amp; Create Event on Same Machine"
                                                        AlternateText="Submit and Create Event on Same Machine" OnClick="imgSaveCreate_Click">
                                                    </asp:ImageButton>
                                                </td>
                                                <td width="20%" valign="top">
                                                    <asp:ImageButton ID="imgMigSiteTest" runat="server" ImageUrl="../Images/Migrate-to-Site-Test.gif" ToolTip="Migrate to Site Test"
                                                        AlternateText="Migrate to Site Test" OnClick="imgMigSiteTest_Click"></asp:ImageButton>
                                                </td>
                                                <td width="9%" valign="top">
                                                    <asp:ImageButton ID="imgCancel" runat="server" ToolTip="Cancel" ImageUrl="../Images/cancel.gif" CausesValidation="False"
                                                        OnClick="imgCancel_Click"></asp:ImageButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
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
                        <td align="center" width="100%">
                            <div id="divTest" style="overflow: auto; width: 100%; height: 100%; z-index: 0;">
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <!-- opening of inner table1 -->
                                    <tbody>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="850" align="center" border="0">
                                                    <tr align="left">
                                                        <td>
                                                            <table style="border-right: #b1c9e8 thin solid; border-top: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                                border-bottom: #b1c9e8 thin solid" cellspacing="0" cellpadding="0" width="100%"
                                                                border="0">
                                                                <tr align="center" bgcolor="#ccffff">
                                                                    <td width="35%">
                                                                        <asp:Label ID="Label7" runat="server" ForeColor="Black" Font-Bold="True" CssClass="FormFields">Category</asp:Label>
                                                                    </td>
                                                                    <td width="35%">
                                                                        <asp:Label ID="lblBrandSegments" runat="server" ForeColor="Black" Font-Bold="True"
                                                                            CssClass="FormFields">Brand Segments</asp:Label>
                                                                    </td>
                                                                    <td width="35%">
                                                                        <asp:Label ID="lblProject" runat="server" ForeColor="#000000" Font-Bold="True">Project</asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr height="8">
                                                                    <td colspan="3">
                                                                    </td>
                                                                </tr>
                                                                <tr align="center">
                                                                    <td width="35%">
                                                                        <asp:DropDownList ID="drpCategoryDB" runat="server" AutoPostBack="True" Width="200px"
                                                                            TabIndex="1" OnSelectedIndexChanged="drpCategoryDB_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <font color="#ff3333">* </font>
                                                                    </td>
                                                        </td>
                                                        <td width="35%">
                                                            <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>--%>
                                                            <asp:DropDownList ID="drpBrandSegmentDB" runat="server" AutoPostBack="True" Width="200px"
                                                                TabIndex="2" OnSelectedIndexChanged="drpBrandSegmentDB_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Select Category First</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <font color="#ff3333">*</font>
                                                            <%--   </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                        </td>
                                                        <td width="35%">
                                                            <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>--%>
                                                            <asp:DropDownList ID="drpProject" runat="server" AutoPostBack="True" Width="200px"
                                                                TabIndex="3" OnSelectedIndexChanged="drpProject_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">None</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="Label1" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label>
                                                            <%--   </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr align="center" bgcolor="#ccffff">
                                                        <!--<td bgcolor="#cccccc" colspan="1"></td>-->
                                                        <td width="60%" colspan="2">
                                                            <asp:Label ID="lblEOName" runat="server" ForeColor="#000000" Font-Bold="True">Event Name</asp:Label>
                                                        </td>
                                                        <td width="40%" colspan="1">
                                                            <asp:Label ID="lblEventType" runat="server" ForeColor="#000000" Font-Bold="True">Event Type</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr height="8">
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <!--<td colspan="1"></td>-->
                                                        <td onkeypress="javascript: return NoSpecialCharacters(event);" width="60%" colspan="2">
                                                            <asp:TextBox ID="txtEOName" runat="server" Width="400px" TabIndex="4"></asp:TextBox><font
                                                                color="#ff3333">*</font>
                                                        </td>
                                                        <td width="40%" colspan="1">
                                                            <%--   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>--%>
                                                            <asp:DropDownList ID="drpEventType" runat="server" Width="200px" TabIndex="5">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="Label5" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label>
                                                            <%--    </ContentTemplate>
                                                                    </asp:UpdatePanel>--%>
                                                        </td>
                                                    </tr>
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
                                                <table style="border-right: #b1c9e8 thin solid; border-top: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                    border-bottom: #b1c9e8 thin solid" cellspacing="0" cellpadding="0" width="100%"
                                                    border="0">
                                                    <!--style="BORDER-RIGHT: #ccffff thin solid; BORDER-TOP: #ccffff thin solid; BORDER-LEFT: #ccffff thin solid; BORDER-BOTTOM: #ccffff thin solid">-->
                                                    <tr align="center" bgcolor="#ccffff">
                                                        <td>
                                                            <asp:Label ID="lblPlant" runat="server" ForeColor="#000000" Font-Bold="True">Plant</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDSDate" runat="server" ForeColor="#000000" Font-Bold="True">Desired Start Date</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShippable" runat="server" ForeColor="#000000" Font-Bold="True">Is this Product Shippable?</asp:Label>
                                                        </td>
                                                        <td >
                                                        <div id="tdGDays" runat="server">
                                                        
                                                            <asp:Label ID="lblGDays" runat="server" ForeColor="#000000" Font-Bold="True">On Hold for > 3 Days</asp:Label>
                                                            </div>
                                                        </td>
                                                        <td >
                                                        <div id="tdDays" runat="server">
                                                            <asp:Label ID="lblDays" runat="server" ForeColor="#000000" Font-Bold="True"># Days on Hold</asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr height="8">
                                                        <td colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td valign="top" width="30%">
                                                            <%--  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>--%>
                                                            <asp:DropDownList ID="drpPlant" runat="server" AutoPostBack="true" Width="180px"
                                                                TabIndex="6" OnSelectedIndexChanged="drpPlant_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Select a Plant</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="Label2" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label>
                                                            <%--</ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                        </td>
                                                        <td onkeypress="javascript: return AllowDateNumbers(event);" valign="top" width="30%">
                                                            <asp:TextBox ID="txtDate" Enabled="false" runat="server" Width="120px" TabIndex="7"></asp:TextBox>&nbsp;&nbsp;<img
                                                                id="img2" style="cursor: hand" onclick="OpenDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                runat="server"><asp:Label ID="Label3" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label><br>
                                                            Format MM/DD/YYYY
                                                        </td>
                                                        <td valign="top" width="15%" valign="top">
                                                            <asp:RadioButtonList ID="rdbShippable" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" TabIndex="8"
                                                                OnSelectedIndexChanged="rdbShippable_SelectedIndexChanged">
                                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td  width="15%"  valign="top"> 
                                                        <div id="tdrdbDays" runat="server">
                                                            <asp:RadioButtonList ID="rdbOnhold" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" TabIndex="9"
                                                                OnSelectedIndexChanged="rdbOnhold_SelectedIndexChanged">
                                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </div>
                                                        </td>
                                                        <td onkeypress="javascript: return AllowNumeric(event);"  valign="top"
                                                            >
                                                            <div id="tdtxtDays" runat="server">
                                                            <asp:TextBox ID="txtDays" runat="server" Width="80PX" MaxLength="4" TabIndex="10"></asp:TextBox></div>
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
                                                <asp:Label ID="Label4" runat="server" ForeColor="#ff3300" Font-Bold="True">*Atleast one of the following is required Paper Machine,Converting Line or Combiner</asp:Label>
                                            </td>
                                        </tr>
                                        <tr height="8">
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="5">
                                                <table style="border-right: #b1c9e8 thin solid; border-top: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                    border-bottom: #b1c9e8 thin solid" cellspacing="0" cellpadding="1" width="100%"
                                                    border="0">
                                                    <tbody>
                                                        <tr bgcolor="#ccffff">
                                                            <td style="height: 39px" align="center" colspan="1">
                                                                <asp:Label ID="lblPaper" runat="server" ForeColor="#000000" Font-Bold="True">Paper Machine</asp:Label>
                                                            </td>
                                                            <td style="height: 39px" align="center" colspan="1">
                                                                <asp:Label ID="lblPTotalLost" runat="server" ForeColor="#000000" Font-Bold="True">Total  Number of<br> Papermaking Days</asp:Label>
                                                            </td>
                                                            <td style="height: 39px" align="center" colspan="3">
                                                                <asp:Label ID="lblPComments" runat="server" ForeColor="#000000" Font-Bold="True">Specific<br>Comments for Planning</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 8">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%" valign="top" align="center">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>--%>
                                                                <asp:DropDownList ID="drpPaper" runat="server" AutoPostBack="True" Width="170px"
                                                                    TabIndex="11" OnSelectedIndexChanged="drpPaper_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Select Plant First</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="Label10" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label>
                                                                <%--</ContentTemplate>
                                                                            </asp:UpdatePanel>--%>
                                                            </td>
                                                            <td onkeypress="javascript: return AllowNumeric(event);" valign="top" align="center" width="20%">
                                                                <asp:Label ID="lblPLostValue" runat="server" Visible="False">0</asp:Label><asp:TextBox
                                                                    ID="txtPLostValue" runat="server" Width="120px" TabIndex="12">0</asp:TextBox>
                                                            </td>
                                                            <td align="center" colspan="3" valign="top">
                                                                <asp:TextBox ID="txtPComments" runat="server" Width="350px" Rows="2" TextMode="MultiLine"
                                                                    TabIndex="13"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" style="height: 8">
                                            <td style="height: 18px" colspan="5">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td colspan="5">
                                                <table style="border-right: #b1c9e8 thin solid; border-top: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                    border-bottom: #b1c9e8 thin solid" cellspacing="0" cellpadding="1" width="100%"
                                                    align="center" border="0">
                                                    <tbody>
                                                        <tr bgcolor="#ccffff">
                                                            <td align="center" colspan="1">
                                                                <asp:Label ID="lblConLine" runat="server" ForeColor="#000000" Font-Bold="True">Converting Line</asp:Label>
                                                            </td>
                                                            <td align="center" colspan="1">
                                                                <asp:Label ID="lblConLost" runat="server" ForeColor="#000000" Font-Bold="True">Total  Number of<br>Converting Days</asp:Label>
                                                            </td>
                                                            <td align="center" colspan="3">
                                                                <asp:Label ID="lblConComments" runat="server" ForeColor="#000000" Font-Bold="True">Specific<br>Comments for Planning</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr height="8">
                                                            <td colspan="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" width="30%" valign="top">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                        <ContentTemplate>--%>
                                                                <asp:DropDownList ID="drpConLine" runat="server" AutoPostBack="True" Width="170px"
                                                                    TabIndex="14" OnSelectedIndexChanged="drpConLine_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">None</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="Label12" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label>
                                                                <%--  </ContentTemplate>
                                                                            </asp:UpdatePanel>--%>
                                                            </td>
                                                            <td onkeypress="javascript: return AllowNumeric(event);" valign="top" align="center" width="20%">
                                                                <asp:Label ID="lblConLostValue" runat="server" Visible="False">0</asp:Label><asp:TextBox
                                                                    ID="txtConLostValue" runat="server" Width="120px" TabIndex="15">0</asp:TextBox>
                                                            </td>
                                                            <td align="center" colspan="3" valign="top">
                                                                <asp:TextBox ID="txtConComments" runat="server" Width="350" Rows="2" TextMode="MultiLine"
                                                                    TabIndex="16"></asp:TextBox>
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
                                                <table style="border-right: #b1c9e8 thin solid; border-top: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                    border-bottom: #b1c9e8 thin solid" cellspacing="0" cellpadding="1" width="100%"
                                                    align="center" border="0">
                                                    <tr bgcolor="#ccffff">
                                                        <td align="center" colspan="1">
                                                            <asp:Label ID="lblComLine" runat="server" ForeColor="#000000" Font-Bold="True">Combining Line</asp:Label><br>
                                                        </td>
                                                        <td align="center" colspan="1">
                                                            <asp:Label ID="lblComLost" runat="server" ForeColor="#000000" Font-Bold="True">Total  Number of<br>Combining Days</asp:Label><br>
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
                                                        <td align="center" width="30%" valign="top">
                                                            <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>--%>
                                                            <asp:DropDownList ID="drpComLine" runat="server" AutoPostBack="true" Width="170px"
                                                                TabIndex="17" OnSelectedIndexChanged="drpComLine_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">None</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="Label11" runat="server" ForeColor="#ff3333" Font-Bold="True">*</asp:Label>
                                                            <%--    </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                        </td>
                                                        <td onkeypress="javascript: return AllowNumeric(event);" valign="top" align="center" width="20%">
                                                            <asp:Label ID="lblComLostValue" runat="server" Visible="False">0</asp:Label><asp:TextBox
                                                                ID="txtComLostValue" runat="server" Width="120px" TabIndex="18">0</asp:TextBox>
                                                        </td>
                                                        <td colspan="3" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr height="8">
                                            <td colspan="5">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="5">
                                                <table style="border-right: #b1c9e8 thin solid; border-top: #b1c9e8 thin solid; border-left: #b1c9e8 thin solid;
                                                    border-bottom: #b1c9e8 thin solid" cellspacing="0" cellpadding="0" width="100%"
                                                    align="center" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td align="center" bgcolor="#ccffff">
                                                                <asp:Label ID="lblCategory" runat="server" ForeColor="#000000" Font-Bold="True">Category</asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                        </tr>
                                        <tr height="8">
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20">
                                            </td>
                                            <td height="20">
                                            </td>
                                            <td align="center" height="20">
                                                <asp:Label ID="lblSelCategory" runat="server" ForeColor="#000000"></asp:Label>
                                            </td>
                                            <td height="20">
                                            </td>
                                            <td height="20">
                                            </td>
                                        </tr>
                                        <tr align="center" bgcolor="#ccffff">
                                            <td align="center">
                                                <asp:Label ID="lblBrand" runat="server" ForeColor="#000000" Font-Bold="True">Brand Type</asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblPrjType" runat="server" ForeColor="#000000" Font-Bold="True">Project Type</asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblPrjLeader" runat="server" ForeColor="#000000" Font-Bold="True">Project Leader</asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblPOC" runat="server" ForeColor="#000000" Font-Bold="True">POC</asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblOriginator" runat="server" ForeColor="#000000" Font-Bold="True">Originator</asp:Label><br>
                                            </td>
                                        </tr>
                                        <tr height="8">
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="20">
                                                <asp:Label ID="lblBrandValue" runat="server" ForeColor="#000000"></asp:Label>
                                            </td>
                                            <td align="center" height="20">
                                                <asp:Label ID="lblPrjTypeValue" runat="server" ForeColor="#000000"></asp:Label>
                                            </td>
                                            <td align="center" height="20">
                                                <asp:Label ID="lblPrjLeaderValue" runat="server" ForeColor="#000000"></asp:Label>
                                            </td>
                                            <td align="center" height="20">
                                                <asp:Label ID="lblPOCValue" runat="server" ForeColor="#000000"></asp:Label>
                                            </td>
                                            <td align="center" height="20">
                                                <asp:Label ID="lblOriginatorValue" runat="server" ForeColor="#000000"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr height="8">
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="left" valign="top">
                                                <asp:Label ID="lblAuthors1" runat="server" ForeColor="#0033ff" Font-Bold="True">Other Authors:</asp:Label><asp:TextBox
                                                    ID="txtAuthors" runat="server" Width="600" ReadOnly="True"></asp:TextBox>&nbsp;<asp:ImageButton
                                                        ID="imgAddressBook" runat="server" ImageUrl="../Images/addressbook.gif" CausesValidation="False"
                                                        TabIndex="19"></asp:ImageButton>&nbsp;
                                                <asp:ImageButton ID="imgDeleteName" runat="server" ImageUrl="../Images/del-name.jpg"
                                                    AlternateText="del" TabIndex="20"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr height="8">
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="left">
                                                <asp:Label ID="lblEdit1" runat="server" ForeColor="#3333ff" Font-Bold="True">Edit History</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="right">
                                                <hr>
                                                <asp:Label ID="lblUser" runat="server"></asp:Label><asp:ValidationSummary ID="vsNewEvent"
                                                    runat="server" DisplayMode="List" ShowMessageBox="True"></asp:ValidationSummary>
                                            </td>
                                        </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                  <tr>
                  <td>footer<uc2:FooterControl ID="FooterControl1" runat="server" />
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
    <!-- Closing of second table-->
    </form>
    <%--</td></tr></tbody></table>--%>
</body>
</html>

