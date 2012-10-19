<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteTest.aspx.cs" Inherits="MUREOUI.Common.SiteTest" %>

<%@ Register Src="../UserControls/HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/FooterControl.ascx" TagName="FooterControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SiteTest</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script type="text/javascript">
        //This function is to check the listbox item selection while deleting attachments.
        function CheckListBoxAttSelect(listBoxID) {
            //alert(listBoxID);
            //alert(document.getElementById(listBoxID));
            var sel = document.getElementById(listBoxID);
            //alert(sel.value);
            var listLength = sel.options.length;
            //alert(listLength);
            var i1 = 0;
            for (var i = 0; i < listLength; i++) {
                if (sel.options[i].selected) {
                    i1 = 1;
                }
            }
            if (i1 == 0) {
                alert("Please select file to delete"); return false;
            }
            else {
                var answer = confirm("Are you sure? You want to delete?")
                if (answer) { return true; }
                else
                { return false; }
            }

        }


        function confirmAttachmentDelete() {
            if (!confirm('Attachment will be deleted from the database after the Site Test is submitted')) {
                return false;
            }
            else {
                return true;
            }
        }

        function confirmAttachmentAdd() {
            if (!confirm('Attachment will be inserted into the database after the Site Test is submitted')) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
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

        function isStartDate(dtStr, ctrlName, ctName) {
            //dtStr= document.getElementById('txtDate').value;
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
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strMonth.length < 1 || month < 1 || month > 12) {
                    alert("Please enter a valid month");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
                    alert("Please enter a valid day");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
                    alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear);
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
                    alert("Please enter a valid date");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                //return true;
            }

            if (dtStr != "") {
                var mydate = new Date()
                var theyear = mydate.getFullYear()
                var themonth = mydate.getMonth() + 1
                var thetoday = mydate.getDate()

                /*if (thetoday<10)
                {
                thetoday="0"+thetoday;
                }*/
                //var todaysDate=themonth+"/"+thetoday+"/"+theyear

                //alert(strMonth+ '--' + strDay + '--' + strYear +'Compring'+themonth+ '--' + thetoday + '--' + theyear);

                //if (dtStr < todaysDate)
                if (parseInt(strYear) >= parseInt(theyear)) {
                    //alert('greater than current year');
                    if ((strMonth >= themonth && strYear >= theyear) || ((strMonth > 0 && strMonth < 12) && strYear > theyear)) {
                        //alert('month is greater');
                        if ((parseInt(strDay) >= parseInt(thetoday) && strYear >= theyear) || (parseInt(strMonth) > parseInt(themonth) && strYear >= theyear) || (parseInt(strDay) < parseInt(thetoday) && parseInt(strYear) > parseInt(theyear))) {
                            //alert('day is greater');
                            //alert("Here");
                            var s = document.getElementById('txtStartDate').value
                            /* alert(s)*/
                            var str = new String(s)
                            str = str.split("/")
                            var starDate = new Date();
                            var i;
                            starDate.setDate(str[1])
                            starDate.setMonth(str[0] - 1)
                            starDate.setFullYear(str[2])
                            //alert("Test Start Date:"+starDate)
                            startDate = document.getElementById('txtStartDate').value;
                            // alert(startDate)
                            /*txtEndDate.Text = startDate.AddDays(CDec(txtPMDays.Text)).Date
                            document.getElementById('txthdnDays').value= document.getElementById(contrlName).value*/
                            //if( document.getElementById('txtPMDays').
                            i = parseInt(document.getElementById(ctName).value);
                            //i=parseInt(document.getElementById('txtPMDays').value)
                            if (isNaN(i) == 1) {
                                i = 0;
                                // alert("Vale:"+i);
                                starDate.setDate(starDate.getDate() + i);
                            }
                            else {
                                //alert("Vale:"+i)
                                starDate.setDate(starDate.getDate() + i);
                            }
                            //alert("getDate:"+starDate.getDate())
                            // alert("Test End Date:"+starDate)
                            //alert("Month:"+starDate.getMonth())

                            var endDate = (starDate.getMonth() + 1) + "/" + starDate.getDate() + "/" + starDate.getFullYear()
                            /*alert(endDate)*/
                            document.getElementById('txtEndDate').value = endDate
                            //}



                        }
                        else {
                            alert('Date should not be less than current date');
                            document.getElementById(ctrlName).focus();
                            document.getElementById(ctrlName).value = "";
                            return;
                        }
                    }
                    else {
                        alert('Date should not be less than current date');
                        document.getElementById(ctrlName).focus();
                        document.getElementById(ctrlName).value = "";
                        return;
                    }
                }
                else {
                    alert('Date should not be less than current date');
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return;
                }
            }



            var sd = document.getElementById('txtStartDate').value;
            var ed = document.getElementById('txtEndDate').value;
            var sdate = new Date(sd);
            var edate = new Date(ed);
            //alert(sdate.getDate());


            if (sd != "") {
                if (ed != "") {
                    if (sdate > edate) {
                        alert('End Date should be greater than OR Equal to the Start Date');
                        document.getElementById(ctrlName).focus();
                        document.getElementById(ctrlName).value = "";
                        return;
                    }
                    //return true;
                }
            }
            if (sd == "") {
                document.getElementById('txtEndDate').value = "";

            }
        }

        function isTestDate(dtStr, ctrlName) {
            //dtStr= document.getElementById('txtDate').value;
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
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strMonth.length < 1 || month < 1 || month > 12) {
                    alert("Please enter a valid month");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
                    alert("Please enter a valid day");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
                    alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear);
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
                    alert("Please enter a valid date");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                //return true;
            }

            if (dtStr != "") {
                var mydate = new Date()
                var theyear = mydate.getFullYear()
                var themonth = mydate.getMonth() + 1
                var thetoday = mydate.getDate()

                /*if (thetoday<10)
                {
                thetoday="0"+thetoday;
                }*/
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
                            alert('Date should not be less than current date');
                            document.getElementById(ctrlName).focus();
                            document.getElementById(ctrlName).value = "";
                            return;
                        }
                    }
                    else {
                        alert('Date should not be less than current date');
                        document.getElementById(ctrlName).focus();
                        document.getElementById(ctrlName).value = "";
                        return;
                    }
                }
                else {
                    alert('Date should not be less than current date');
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return;
                }
            }



            var sd = document.getElementById('txtStartDate').value;
            var ed = document.getElementById('txtEndDate').value;
            var sdate = new Date(sd);
            var edate = new Date(ed);
            //alert(sdate.getDate());


            if (sd != "") {
                if (ed != "") {
                    if (sdate > edate) {
                        alert('End Date should be greater than OR Equal to the Start Date');
                        document.getElementById(ctrlName).focus();
                        document.getElementById(ctrlName).value = "";
                        return;
                    }
                    //return true;
                }
            }
            if (sd == "") {
                document.getElementById('txtEndDate').value = "";

            }
        }

        function isDate(dtStr, ctrlName) {
            //dtStr= document.getElementById('txtDate').value;
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
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strMonth.length < 1 || month < 1 || month > 12) {
                    alert("Please enter a valid month");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
                    alert("Please enter a valid day");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
                    alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear);
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
                    alert("Please enter a valid date");
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return false;
                }
                //return true;
            }

            if (dtStr != "") {
                var mydate = new Date()
                var theyear = mydate.getFullYear()
                var themonth = mydate.getMonth() + 1
                var thetoday = mydate.getDate()

                /*if (thetoday<10)
                {
                thetoday="0"+thetoday;
                }*/
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
                            alert('Date should not be less than current date');
                            document.getElementById(ctrlName).focus();
                            document.getElementById(ctrlName).value = "";
                            return;
                        }
                    }
                    else {
                        alert('Date should not be less than current date');
                        document.getElementById(ctrlName).focus();
                        document.getElementById(ctrlName).value = "";
                        return;
                    }
                }
                else {
                    alert('Date should not be less than current date');
                    document.getElementById(ctrlName).focus();
                    document.getElementById(ctrlName).value = "";
                    return;
                }
            }



            /*var sd=document.getElementById('txtStartDate').value
            var ed=document.getElementById('txtEndDate').value
		 
            if (sd!="")
            {
            if (ed!="")
            {
            if (sd > ed)
            {
            alert('End Date should be greater than OR Equal to the Start Date');
            document.getElementById(ctrlName).focus();
            document.getElementById(ctrlName).value = "";	
            return;
            }
            //return true;
            }
            }*/
        }


        function tt() {
            var popResult;
            var plantId = document.getElementById('txthdnPlantID').value
            var EoID = document.getElementById('txthdnEoID').value
            /*var oName=document.getElementById('txtOriginator').value*/
            /*alert(oName)*/
            /*alert(plantId)*/

            popResult = window.open('SendForConcurrence.aspx?PlantID=' + plantId + '&From=SiteTest&EoID=' + EoID, 'null', 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');
            document.getElementById('t1').value = popResult;
            
        }

        function test123() {
            alert("Hai");
        }
        function AllowPhoneChk(e) {
            var iKeyCode = 0;
            if (window.event)
                iKeyCode = window.event.keyCode
            else if (e)
                iKeyCode = e.which;
            if ((iKeyCode == 40) || (iKeyCode == 41) || (iKeyCode == 43) || (iKeyCode == 45) || (iKeyCode > 47 && iKeyCode < 58))
                return true;
            else
                return false;
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

        function CatCheck(sender, args) {
            if ((document.getElementById('ddlCategory').selectedIndex == 0) || (document.getElementById('ddlCategory').selectedIndex == -1)) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
//        function AddBooksingUser() {
//            var popResult;
//            popResult = window.showModalDialog('ShowUser.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:500px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//            if (popResult != "")
//            { document.getElementById('txtCooriginator').value = popResult; }
//            if (document.getElementById('txtCooriginator').value == 'undefined') {
//                document.getElementById('txtCooriginator').value = "";
//            }
        //        }

        function AddBooksingUser() {
            var strTxtPrjLead = document.getElementById("<%=txtCoOriginator.ClientID %>").id;
            var hdntxtprjlead = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
            window.open('ShowUsers.aspx?ID=' + strTxtPrjLead + '&Hidd=' + hdntxtprjlead, 'ShowUsers', 'menubar=0,resizable=1,width=800,height=450');
            return false;
        }


        function AddBooksingUserForBakUp(btn) {
       
            document.getElementById("<%=hdnConAppID.ClientID %>").value = btn.getAttribute('lblConAppID');
            document.getElementById("<%=hdnOrigAppr.ClientID %>").value = btn.getAttribute('lblOrigAppr');

            var hdntxtAuthApprover = btn.getAttribute('hdnApprClientID');

            var btnApp = btn.getAttribute('btnApp');
            window.open('../Common/ShowUser.aspx?btnApp=' + btnApp + '&Hidd=' + hdntxtAuthApprover + '&Type=C', 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
       
            return false;
        }

        function concurenceConfirm(ConAppID, EoId, appStatus, ConGrpID, AppName) {

            var popResult;
            /* popResult = window.showModalDialog('PreScreenApproverConfirm.aspx?EOID=' + EoId + '&EoStage=CONCURENCE&ConAppID=' + ConAppID + '&appStatus=' + appStatus + '&ConGrpID=' + ConGrpID + '&AppName=' + AppName + '&FormName=SITETEST', null, 'dialogWidth:400px;dialogHeight:230px');*/
            popResult = window.open('PreScreenApproverConfirm.aspx?EOID=' + EoId + '&EoStage=CONCURENCE&ConAppID=' + ConAppID + '&appStatus=' + appStatus + '&ConGrpID=' + ConGrpID + '&AppName=' + AppName + '&FormName=SITETEST', null, 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');

            if (popResult == "T") {
                if (appStatus == "Declined") {
                    alert('Concurrence is declined successfully.');
                }
                else {
                    alert('Your concurrence is registered successfully.');
                }

                window.navigate('../Reports/MyApprovals.aspx');
            }
        }
        function test() {
            //alert("Here");
        }
        /* function AddBooksingUserForBakUp() {
            var popResult;
            popResult = window.showModalDialog('ShowUser.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:500px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
            if (popResult != "")
            { document.getElementById('hdnApprover').value = popResult; }
            if (document.getElementById('hdnApprover').value == 'undefined') {
                document.getElementById('hdnApprover').value = "";
            }
        }*/

        function EventCheck(sender, args) {
            var i = 0;
            alert("Hai");
            alert(document.getElementById('lbEOEventsDB').options.length);
            if (document.getElementById('lbEOEventsDB').options.length != 0) {
                for (len = 0; len < document.getElementById('lbEOEventsDB').options.length; len++) {
                    if (document.getElementById('lbEOEventsDB').options[len].selected)
                        i++;
                }
                if (i > 0)
                    alert("h");
                else
                    alert("h");
            }
            else
                alert("b");
        }
        function BrandCheck(sender, args) {
            var i = 0;
            alert("Hai");
            alert(document.getElementById('lbEOEventsDB').options.length);
            if (document.getElementById('lbEOEventsDB').options.length != 0) {
                for (len = 0; len < document.getElementById('lbEOEventsDB').options.length; len++) {
                    if (document.getElementById('lbEOEventsDB').options[len].selected)
                        i++;
                }
                if (i > 0)
                    alert("h");
                else
                    alert("h");
            }
            else
                alert("b");
        }


        function PlantCheck(sender, args) {
            if ((document.getElementById('drpPlant').selectedIndex == 0) || (document.getElementById('drpPlant').selectedIndex == -1)) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
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

        function PhNumber() {
            var k;
            k = event.keyCode;

            if ((k == 40) && !(k == 41) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
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
        function AllowNumericOnly(e) {
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


        // checking for only one decimal in numeric text boxes	
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
            else if (!(k >= 0 && k <= 250)) {
                alert("Please enter the numbers from 0 to 250 only.");
                document.getElementById(contrlName).value = "";
                document.getElementById(contrlName).focus();
                return;
            }

            else {
                /*alert(document.getElementById(contrlName).value)
                if (document.getElementById(contrlName)=="txtPMDays" || document.getElementById(contrlName)=="txtDays")
                {
                document.getElementById('txtEndDate').value=*/
                var s = document.getElementById('txtStartDate').value
                /* alert(s)*/
                var str = new String(s)
                str = str.split("/")
                var starDate = new Date();
                var i;
                starDate.setDate(str[1])
                starDate.setMonth(str[0] - 1)
                starDate.setFullYear(str[2])
                //alert("Test Start Date:"+starDate)
                /*startDate=document.getElementById('txtStartDate').value
                alert(startDate)*/
                /*txtEndDate.Text = startDate.AddDays(CDec(txtPMDays.Text)).Date
                document.getElementById('txthdnDays').value= document.getElementById(contrlName).value*/
                i = parseInt(document.getElementById(contrlName).value)
                if (isNaN(i) == 1) {
                    i = 0;
                    //alert("Vale:"+i)
                    starDate.setDate(starDate.getDate() + i);
                }
                else {
                    //alert("Vale:"+i)
                    starDate.setDate(starDate.getDate() + i);
                }
                //alert("getDate:"+starDate.getDate())
                // alert("Test End Date:"+starDate)
                //alert("Month:"+starDate.getMonth())

                var endDate = (starDate.getMonth() + 1) + "/" + starDate.getDate() + "/" + starDate.getFullYear()
                /*alert(endDate)*/
                document.getElementById('txtEndDate').value = endDate
                //}

            }
        }
        function CountDecimalsOnly(val, contrlName) {
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






        function ProjeCheck(sender, args) {
            if ((document.getElementById('ddlProject').selectedIndex == 0) || (document.getElementById('ddlProject').selectedIndex == -1)) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
        function OpenPreRunDateToWindow() {

            var txtFromValue = document.getElementById("txtPreRunDates").value;
            window.open('calendar.aspx?formname=Form1.txtPreRunDates&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');
        }
        function OpenEarRunDateToWindow() {
            var txtFromValue = document.getElementById("txtEarlRunDates").value;
            window.open('calendar.aspx?formname=Form1.txtEarlRunDates&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }
        function OpenLateRunDateToWindow() {
            var txtFromValue = document.getElementById("txtLRDates").value;
            window.open('calendar.aspx?formname=Form1.txtLRDates&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }
        function OpenPPMPRDateToWindow() {
            var txtFromValue = document.getElementById("txtPPMPRDate").value;
            window.open('calendar.aspx?formname=Form1.txtPPMPRDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }

        function OpenPPMERDateToWindow() {
            var txtFromValue = document.getElementById("txtPPMERDate").value;
            window.open('calendar.aspx?formname=Form1.txtPPMERDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }
        function OpenPPMLRDateToWindow() {
            var txtFromValue = document.getElementById("txtPPMLRDates").value;
            window.open('calendar.aspx?formname=Form1.txtPPMLRDates&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }
        function OpenTestStartDateToWindow() {
            var txtFromValue = document.getElementById("txtStartDate").value;
            window.open('calendar.aspx?formname=Form1.txtStartDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }
        function OpenTestEndDateToWindow() {
            var txtFromValue = document.getElementById("txtEndDate").value;
            window.open('calendar.aspx?formname=Form1.txtEndDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');

        }

        function changewidth() {
            var d = document.getElementById('scrollUserTable')
            var resolution = screen.width + ' x ' + screen.height
            alert('Your resolution is: ' + resolution);

            //if(resolution == "1024 x 768")
            if (screen.width == "1024") {
                //alert("Here");
                document.getElementById('scrollUserTable').style.width = "995px";
                document.getElementById('scrollUserTable').style.height = "105px";
                alert("if")
                //dstyle = "overflow: auto; height: 200; width: 1015;";

            }
            else if (resolution == "1152 x 864") {
                //dstyle = "overflow: auto; height: 200; width: 1270;";
                document.getElementById('scrollUserTable').style = "overflow: auto; height: 200px; width: 1142px;"
                alert("else if")

            }

        }

        //Screen Resolution code

        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
		
		
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table height="100%" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100%">
                        <table cellspacing="0" cellpadding="0" width="100%" border="1" align="center">
                            <tr>
                                <td class="FormHeader" valign="top" colspan="4">
                                    Site Test
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                <asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                                    <asp:TextBox ID="txtHiddenConGrpID" Width="0" runat="server" Style="display: none"></asp:TextBox>
                                    <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" OnClick="imgSubmit_Click">
                                    </asp:ImageButton>&nbsp;
                                    <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/Cancel.gif" CausesValidation="False"
                                        OnClick="imgCancel_Click"></asp:ImageButton>&nbsp; &nbsp;<asp:ImageButton ID="btnFYI"
                                            runat="server" ImageUrl="../Images/fyi1.gif" CausesValidation="False" OnClick="btnFYI_Click">
                                        </asp:ImageButton>&nbsp;
                                    <asp:TextBox ID="t11" runat="server" Width="0" Style="display: none"></asp:TextBox>
                                </td>
                                <tr align="left">
                                    <td valign="top">
                                        <div id="divTest" style="z-index: 0; width: 100%; overflow: auto">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="25%">
                                                                    <span class="FieldNames">EO #:</span>&nbsp;&nbsp;
                                                                    <asp:Label ID="lblEONum" runat="server"></asp:Label>
                                                                </td>
                                                                <td width="25%">
                                                                </td>
                                                                <!--  Copy -->
                                                                <td onkeypress="javascript: return NoSpecialCharacters(event);" width="65%" colspan="2">
                                                                    <span class="FieldNames">Title: </span>
                                                                    <asp:TextBox ID="txtTitle" runat="server" Width="300px" MaxLength="50"></asp:TextBox><font
                                                                        class="astrisk" color="red">*</font>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                                        <tr height="25">
                                                                            <td>
                                                                                <span class="FieldNames">Category:</span> &nbsp;&nbsp;
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="142px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                    <font class="astrisk" color="red">*</font>
                                                                                </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <span class="FieldNames">Brand:</span> &nbsp;&nbsp;&nbsp;
                                                                                <td>
                                                                                    <asp:ListBox ID="lbEOBrandsDB" runat="server" Width="139px" AutoPostBack="True" SelectionMode="Multiple"
                                                                                        Height="104px" OnSelectedIndexChanged="lbEOBrandsDB_SelectedIndexChanged"></asp:ListBox>
                                                                                    <font class="astrisk" color="red">*</font>
                                                                                </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                                        <tr height="25">
                                                                            <td>
                                                                                <span class="FieldNames">Project:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlProject" runat="server" Width="142px" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <font class="astrisk" color="red">*</font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Events :</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:ListBox ID="lbEOEventsDB" runat="server" Width="144px" SelectionMode="Multiple"
                                                                                    Height="104px"></asp:ListBox>
                                                                                <font class="astrisk" color="red">*</font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="50">
                                                                            <td>
                                                                                <span class="FieldNames">Selected Brand:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblEoSelectedBrandDB" runat="server"></asp:Label><asp:Label ID="lblBrandIDList"
                                                                                    runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" width="21%">
                                                                    <span class="FieldNames">Plant:</span>
                                                                    <asp:DropDownList ID="drpPlant" runat="server" Width="142px" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="drpPlant_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <font class="astrisk" color="red">*</font>
                                                                </td>
                                                                <td valign="top" width="100%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                                        <tr height="30">
                                                                            <td width="35%">
                                                                                <span class="FieldNames">Originator:</span><asp:TextBox ID="txthdnSiteTestID" runat="server"
                                                                                    Width="0" Style="display: none"></asp:TextBox><asp:TextBox ID="txthdnPlantID" runat="server"
                                                                                        Width="0" Style="display: none"></asp:TextBox><asp:TextBox ID="txthdnPlantType" runat="server"
                                                                                            Width="0" Style="display: none"></asp:TextBox>
                                                                                <asp:TextBox ID="txthdnEoID" runat="server" Width="0" Style="display: none"></asp:TextBox>
                                                                            </td>
                                                                            <td width="65%">
                                                                                <asp:Label ID="lblOriginator" runat="server" Width="100%"></asp:Label><asp:TextBox
                                                                                    ID="txtOriginator" runat="server" Width="0" Style="display: none"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="30">
                                                                            <td>
                                                                                <span class="FieldNames">Office #:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtOfficeNum" runat="server" Width="134px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="30">
                                                                            <td>
                                                                                <span class="FieldNames">Phone #:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPhoneNum" runat="server" Width="134px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="40">
                                                                            <td>
                                                                                <span class="FieldNames">Co-Originator:</span>
                                                                            </td>
                                                                            <td width="65%">
                                                                                <asp:TextBox ID="txtCoOriginator" runat="server" Width="134px" ReadOnly="True"></asp:TextBox><asp:ImageButton
                                                                                    ID="imgPOCAddressBook" runat="server" ImageUrl="..\Images\addressbook.gif" CausesValidation="False"
                                                                                    ToolTip="Lookup Names"></asp:ImageButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <span class="FieldNames">Test Start Date:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox><img id="Img7" style="cursor: hand"
                                                                                    onclick="OpenTestStartDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">
                                                                                <br>
                                                                                (eg: 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="30">
                                                                            <td valign="top" width="50%">
                                                                                <span class="FieldNames">Test Start Time:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:DropDownList ID="drpDay" runat="server">
                                                                                    <asp:ListItem Value="0" Selected="True">00</asp:ListItem>
                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;
                                                                                <asp:DropDownList ID="drpMonth" runat="server">
                                                                                    <asp:ListItem Value="0">00</asp:ListItem>
                                                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                                                    <asp:ListItem Value="9">09</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                                                    <asp:ListItem Value="32">32</asp:ListItem>
                                                                                    <asp:ListItem Value="33">33</asp:ListItem>
                                                                                    <asp:ListItem Value="34">34</asp:ListItem>
                                                                                    <asp:ListItem Value="35">35</asp:ListItem>
                                                                                    <asp:ListItem Value="36">36</asp:ListItem>
                                                                                    <asp:ListItem Value="37">37</asp:ListItem>
                                                                                    <asp:ListItem Value="38">38</asp:ListItem>
                                                                                    <asp:ListItem Value="39">39</asp:ListItem>
                                                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                                                    <asp:ListItem Value="41">41</asp:ListItem>
                                                                                    <asp:ListItem Value="42">42</asp:ListItem>
                                                                                    <asp:ListItem Value="43">43</asp:ListItem>
                                                                                    <asp:ListItem Value="44">44</asp:ListItem>
                                                                                    <asp:ListItem Value="45">45</asp:ListItem>
                                                                                    <asp:ListItem Value="46">46</asp:ListItem>
                                                                                    <asp:ListItem Value="47">47</asp:ListItem>
                                                                                    <asp:ListItem Value="48">48</asp:ListItem>
                                                                                    <asp:ListItem Value="49">49</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                                                    <asp:ListItem Value="51">51</asp:ListItem>
                                                                                    <asp:ListItem Value="52">52</asp:ListItem>
                                                                                    <asp:ListItem Value="53">53</asp:ListItem>
                                                                                    <asp:ListItem Value="54">54</asp:ListItem>
                                                                                    <asp:ListItem Value="55">55</asp:ListItem>
                                                                                    <asp:ListItem Value="56">56</asp:ListItem>
                                                                                    <asp:ListItem Value="57">57</asp:ListItem>
                                                                                    <asp:ListItem Value="58">58</asp:ListItem>
                                                                                    <asp:ListItem Value="59">59</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;<asp:DropDownList ID="drpPart" runat="server">
                                                                                    <asp:ListItem Value="AM">AM</asp:ListItem>
                                                                                    <asp:ListItem Value="PM">PM</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="50%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <span class="FieldNames">Test End Date:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox><img id="Img8" style="cursor: hand"
                                                                                    onclick="OpenTestEndDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">
                                                                                <br>
                                                                                (eg: 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr height="30">
                                                                            <td valign="top" width="50%">
                                                                                <span class="FieldNames">Test End Time:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:DropDownList ID="drpEndTime" runat="server">
                                                                                    <asp:ListItem Value="0" Selected="True">00</asp:ListItem>
                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;
                                                                                <asp:DropDownList ID="drpEndMin" runat="server">
                                                                                    <asp:ListItem Value="0">00</asp:ListItem>
                                                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                                                    <asp:ListItem Value="6">06</asp:ListItem>
                                                                                    <asp:ListItem Value="7">07</asp:ListItem>
                                                                                    <asp:ListItem Value="8">08</asp:ListItem>
                                                                                    <asp:ListItem Value="9">09</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                                                    <asp:ListItem Value="32">32</asp:ListItem>
                                                                                    <asp:ListItem Value="33">33</asp:ListItem>
                                                                                    <asp:ListItem Value="34">34</asp:ListItem>
                                                                                    <asp:ListItem Value="35">35</asp:ListItem>
                                                                                    <asp:ListItem Value="36">36</asp:ListItem>
                                                                                    <asp:ListItem Value="37">37</asp:ListItem>
                                                                                    <asp:ListItem Value="38">38</asp:ListItem>
                                                                                    <asp:ListItem Value="39">39</asp:ListItem>
                                                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                                                    <asp:ListItem Value="41">41</asp:ListItem>
                                                                                    <asp:ListItem Value="42">42</asp:ListItem>
                                                                                    <asp:ListItem Value="43">43</asp:ListItem>
                                                                                    <asp:ListItem Value="44">44</asp:ListItem>
                                                                                    <asp:ListItem Value="45">45</asp:ListItem>
                                                                                    <asp:ListItem Value="46">46</asp:ListItem>
                                                                                    <asp:ListItem Value="47">47</asp:ListItem>
                                                                                    <asp:ListItem Value="48">48</asp:ListItem>
                                                                                    <asp:ListItem Value="49">49</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                                                    <asp:ListItem Value="51">51</asp:ListItem>
                                                                                    <asp:ListItem Value="52">52</asp:ListItem>
                                                                                    <asp:ListItem Value="53">53</asp:ListItem>
                                                                                    <asp:ListItem Value="54">54</asp:ListItem>
                                                                                    <asp:ListItem Value="55">55</asp:ListItem>
                                                                                    <asp:ListItem Value="56">56</asp:ListItem>
                                                                                    <asp:ListItem Value="57">57</asp:ListItem>
                                                                                    <asp:ListItem Value="58">58</asp:ListItem>
                                                                                    <asp:ListItem Value="59">59</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;
                                                                                <asp:DropDownList ID="drpEndPart" runat="server">
                                                                                    <asp:ListItem Value="AM">AM</asp:ListItem>
                                                                                    <asp:ListItem Value="PM">PM</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Descrption:</span><br>
                                                                                <asp:TextBox ID="txtDescription" runat="server" Width="366px" TextMode="MultiLine"
                                                                                    Height="82px"></asp:TextBox><br>
                                                                                <br>
                                                                                <span class="FieldNames">Objective:</span><br>
                                                                                <asp:TextBox ID="txtObjective" runat="server" Width="366px" TextMode="MultiLine"
                                                                                    Height="82px"></asp:TextBox><br>
                                                                                <br>
                                                                                <span class="FieldNames">Memo:</span><br>
                                                                                <asp:TextBox ID="txtMemo" runat="server" Width="366px" TextMode="MultiLine" Height="82px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" width="50%">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" colspan="2">
                                                                                <span class="FieldNames">Affected Line(s)/Machine(s):</span><br>
                                                                                <asp:TextBox ID="txtAffected" runat="server" Width="230px"></asp:TextBox><br>
                                                                                <br>
                                                                                <span class="FieldNames" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                    Final Report Due:</span><br>
                                                                                <asp:TextBox ID="txtReportDue" runat="server" Width="222px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:UpdatePanel ID="upTplanTemp" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:ImageButton ID="imgTplanTemp" runat="server" ImageUrl="../Images/Test-Plan-Template.jpg"
                                                                                            CausesValidation="False" OnClick="imgTplanTemp_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgTplanTemp" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td>
                                                                             									
                                                                                <asp:UpdatePanel ID="upimgBounTestReq" runat="server">
                                                                                    <ContentTemplate>
                                                                                    <asp:ImageButton ID="imgBounTestReq" runat="server" ImageUrl="../Images/Bounty-Test-Request.jpg"
                                                                                    CausesValidation="False" OnClick="imgBounTestReq_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgBounTestReq" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:UpdatePanel ID="upExTestPlan" runat="server">
                                                                                    <ContentTemplate>
                                                                                    <asp:ImageButton ID="imgExTestPlan" runat="server" ImageUrl="../Images/Example-of-Test-Plan.jpg"
                                                                                    CausesValidation="False" OnClick="imgExTestPlan_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgExTestPlan" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                                
                                                                            </td>
                                                                            <td>
                                                                             									
                                                                                <asp:UpdatePanel ID="upimgCharTeReq" runat="server">
                                                                                    <ContentTemplate>
                                                                                    <asp:ImageButton ID="imgCharTeReq" runat="server" ImageUrl="../Images/Charmin-Test-Request.jpg"
                                                                                    CausesValidation="False" OnClick="imgCharTeReq_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgCharTeReq" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                                
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:UpdatePanel ID="upimgFinRepTemp" runat="server">
                                                                                    <ContentTemplate>
                                                                                    <asp:ImageButton ID="imgFinRepTemp" runat="server" ImageUrl="../Images/Final-Report-Template.jpg"
                                                                                    CausesValidation="False" OnClick="imgFinRepTemp_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgFinRepTemp" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td>
                                                                             									
                                                                                <asp:UpdatePanel ID="upimgPapMakLabReq" runat="server">
                                                                                    <ContentTemplate>
                                                                                     <asp:ImageButton ID="imgPapMakLabReq" runat="server" ImageUrl="../Images/Paper-Making-Lab-Request.jpg"
                                                                                    CausesValidation="False" OnClick="imgPapMakLabReq_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgPapMakLabReq" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td> 									
                                                                                <asp:UpdatePanel ID="upimgExFinRep" runat="server">
                                                                                    <ContentTemplate>
                                                                                    <asp:ImageButton ID="imgExFinRep" runat="server" ImageUrl="../Images/Example-of-Final-Report.jpg"
                                                                                    CausesValidation="False" OnClick="imgExFinRep_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgExFinRep" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                                
                                                                            </td>
                                                                            <td>
                                                                             									
                                                                                <asp:UpdatePanel ID="upimgTesRequ" runat="server">
                                                                                    <ContentTemplate>   <asp:ImageButton ID="imgTesRequ" runat="server" ImageUrl="../Images/Ultra-Test-Request-Form.jpg"
                                                                                    CausesValidation="False" OnClick="imgTesRequ_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgTesRequ" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                             
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:UpdatePanel ID="upimgNapTeReq" runat="server">
                                                                                    <ContentTemplate>
                                                                                    <asp:ImageButton ID="imgNapTeReq" runat="server" ImageUrl="../Images/Napkin-Test-Request-Form.jpg"
                                                                                    CausesValidation="False" OnClick="imgNapTeReq_Click"></asp:ImageButton>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="imgNapTeReq" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <!-- starting table for Converting -->
                                                        <table id="tblConverting" width="100%" runat="server">
                                                            <tr>
                                                                <td class="SubHeader">
                                                                    Converting
                                                                </td>
                                                            </tr>
                                                            <tr align="left">
                                                                <td align="left">
                                                                    <span style="font-weight:bold">
                                                                        <asp:UpdatePanel ID="uplnkinfoconv" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:LinkButton ID="lnkinfoconv" runat="server" OnClick="lnkinfoconv_Click">Click here to get more detailed list of info to attach with your plan</asp:LinkButton>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="lnkinfoconv" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">Converting Test Coordinator:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Number of Converting Days:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtDays" runat="server" MaxLength="3"></asp:TextBox>Days
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Preferred Run Dates:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPreRunDates" runat="server"></asp:TextBox><img id="img2" style="cursor: hand"
                                                                                    onclick="OpenPreRunDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">&nbsp; (eg 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Earliest Run Dates:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEarlRunDates" runat="server"></asp:TextBox><img id="Img3" style="cursor: hand"
                                                                                    onclick="OpenEarRunDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">&nbsp; (eg 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Latest Run Dates:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLRDates" runat="server"></asp:TextBox><img id="Img4" style="cursor: hand"
                                                                                    onclick="OpenLateRunDateToWindow()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">&nbsp; (eg 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Consumer Test Production:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rdCTPYes" runat="server" GroupName="CTP" Text="Yes"></asp:RadioButton><asp:RadioButton
                                                                                    ID="rdCTPNo" runat="server" GroupName="CTP" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <!-- Equipment -->
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Equipment</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                Preferred Converting Line:&nbsp;&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlPrefConline" runat="server" Width="152px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Alternate Converting Line: </span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlaltConvLine" runat="server" Width="152px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">E/L Setup:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlElSetup" runat="server" Width="152px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <span class="FieldNames">If E/L Setup is required,Enter the prferred Emboss Pattern:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEquEmbossPattern" runat="server" MaxLength="100"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Hot Melt:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbHotMeltYes" runat="server" Text="Yes"></asp:RadioButton><asp:RadioButton
                                                                                    ID="rbHotMeltNo" runat="server" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Are Extrusion Heads needed?</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbextrHeadsYes" runat="server" Text="Yes"></asp:RadioButton><asp:RadioButton
                                                                                    ID="rbextrHeadsNo" runat="server" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">How many Extrusion Heads are needed?</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtExtrusionHeads" runat="server" MaxLength="6"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Do the heads need to be heated?</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbHeadsHeatedYes" runat="server" Text="Yes"></asp:RadioButton><asp:RadioButton
                                                                                    ID="rbHeadsHeatedNo" runat="server" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Is stream required?</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbStreamreqdYes" runat="server" Text="Yes"></asp:RadioButton><asp:RadioButton
                                                                                    ID="rbStreamreqdNo" runat="server" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <!-- End Of EQuip -->
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Materials</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                Do you need Standard Process Inks for your run?
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rdInkYes" runat="server" Text="Yes" OnCheckedChanged="rdInkYes_CheckedChanged">
                                                                                </asp:RadioButton>
                                                                                <asp:RadioButton ID="rdInkNo" runat="server" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">If Standard Inks are required, how many gallons are needed:</span>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Yellow:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtYellow" runat="server" MaxLength="6"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Magneta:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtMagneta" runat="server" MaxLength="6"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Cyan:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtCyan" runat="server" MaxLength="6"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Black:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtBlack" runat="server" MaxLength="6"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Other</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                Unique Requests
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="50%">
                                                                                <span class="FieldNames">Equipment:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtOtherEquipment" runat="server" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                    Materials:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtOtherMat" runat="server" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames" onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                    Other:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtOther" runat="server" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <!-- end of table for Converting -->
                                                        <!-- starting table for PPM -->
                                                        <table id="tblPPM" width="100%" runat="server">
                                                            <tr>
                                                                <td class="SubHeader">
                                                                    Pilot Paper Machine
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span style="font-weight:bold">
                                                                        <asp:UpdatePanel ID="uplnkinfoPPM" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:LinkButton ID="lnkinfoPPM" runat="server" OnClick="lnkinfoPPM_Click">Click here to get the PPM initial Setup sheet for printing 
																out</asp:LinkButton>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="lnkinfoPPM" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">Have you run or investigated the PPM Models?</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:RadioButton ID="rbPPMModelsYes" runat="server" AutoPostBack="True" GroupName="PPM"
                                                                                    Text="Yes"></asp:RadioButton>
                                                                                <asp:RadioButton ID="rbPPMModelsNo" runat="server" AutoPostBack="True" GroupName="PPM"
                                                                                    Text="No" OnCheckedChanged="rbPPMModelsNo_CheckedChanged"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">PPM Test Coordinator:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:Label ID="lblPPMCoordiator" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Number of PM Days:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtPMDays" runat="server" MaxLength="3"></asp:TextBox>Days
                                                                                <asp:TextBox ID="txthdnDays" runat="server" Width="0" MaxLength="3" Style="display: none"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Preferred Run Dates:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPPMPRDate" runat="server"></asp:TextBox><img id="Img1" style="cursor: hand"
                                                                                    onclick="OpenPPMPRDateToWindow()()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">
                                                                                &nbsp;(eg 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Earliest Run Dates:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPPMERDate" runat="server"></asp:TextBox><img id="Img5" style="cursor: hand"
                                                                                    onclick="OpenPPMERDateToWindow()()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">
                                                                                &nbsp;(eg 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Latest Run Dates:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPPMLRDates" runat="server"></asp:TextBox><img id="Img6" style="cursor: hand"
                                                                                    onclick="OpenPPMLRDateToWindow()()" alt="To Date" src="../Images/calendar.gif"
                                                                                    runat="server">
                                                                                &nbsp;(eg 10/20/2010)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Consumer Test Production:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbPPMCTPYes" runat="server" GroupName="PPMCTP" Text="Yes"></asp:RadioButton><asp:RadioButton
                                                                                    ID="rbPPMCTPNo" runat="server" GroupName="PPMCTP" Text="No"></asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Equipment</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">Drying Format:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:DropDownList ID="drpDrying" runat="server" Width="160px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">PM Format:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:DropDownList ID="drpFormat" runat="server" Width="160px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">Headbox Type:</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:DropDownList ID="drpHeadbox" runat="server" Width="160px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Materials</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <span class="FieldNames">Is Karlinal required?</span>
                                                                            </td>
                                                                            <td width="50%">
                                                                                <asp:RadioButton ID="rbKarliYes" runat="server" AutoPostBack="True" GroupName="Karli"
                                                                                    Text="Yes" OnCheckedChanged="rbKarliYes_CheckedChanged"></asp:RadioButton><asp:RadioButton
                                                                                        ID="rbKarliNo" runat="server" AutoPostBack="True" GroupName="Karli" Text="No">
                                                                                </asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">If Yes, how many gallon buckets are needed?</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return AllowNumeric(event);">
                                                                                <asp:TextBox ID="txtGallons" runat="server" MaxLength="6"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">New CPN belts:</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rdCPNYes" runat="server" AutoPostBack="True" GroupName="CPN"
                                                                                    Text="Yes" OnCheckedChanged="rdCPNYes_CheckedChanged"></asp:RadioButton><asp:RadioButton
                                                                                        ID="rbCPNNo" runat="server" AutoPostBack="True" GroupName="CPN" Text="No">
                                                                                </asp:RadioButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">No of patterns per new belt:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <asp:TextBox ID="txtPatterns" runat="server" MaxLength="100"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Other</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <span class="FieldNames">Unique Requests</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="50%">
                                                                                <span class="FieldNames">Equipment</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEquip" runat="server" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Materials (Chemicals or Pulp):</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <asp:TextBox ID="txtMaterials" runat="server" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Other:</span>
                                                                            </td>
                                                                            <td onkeypress="javascript: return NoSpecialCharacters(event);">
                                                                                <asp:TextBox ID="txtPPMOther" runat="server" MaxLength="1000"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <!-- End of Table for PPM -->
                                                        <!-- End of Dynamic table -->
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="SubHeader">
                                                                    Test Plans
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="fTestPlan" style="width: 278px; height: 22px" type="file" size="27" name="fTestPlan"
                                                                        runat="server">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:ListBox ID="lbTestPlansAttach" runat="server" Width="512px"></asp:ListBox>
                                                        &nbsp;<asp:ImageButton ID="imgAddAttchFinalTestPlans" runat="server" ImageUrl="../Images/add.gif"
                                                            CausesValidation="False" OnClick="imgAddAttchFinalTestPlans_Click"></asp:ImageButton>
                                                        &nbsp;&nbsp;<asp:ImageButton ID="imgDelAttchFinalTestPlans" runat="server" ImageUrl="../Images/delete.gif"
                                                            CausesValidation="False" OnClick="imgDelAttchFinalTestPlans_Click" OnClientClick="return CheckListBoxAttSelect('lbTestPlansAttach');"></asp:ImageButton>&nbsp;
                                                        <br>
                                                        <asp:DataGrid ID="dgrdTestPlan" runat="server" Width="500px" GridLines="None" AutoGenerateColumns="False"
                                                            BorderColor="black" HeaderStyle-CssClass="SubHeader" BorderWidth="1px" 
                                                            OnItemCommand="dgrdTestPlan_ItemCommand">
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                     <asp:UpdatePanel ID="updpanlnkTestPlan" runat="server" ><ContentTemplate>
                                                                        <asp:LinkButton ID="lnkTestPlan" CommandName="Final_Click" Visible="true" runat="server"
                                                                            CausesValidation="False">
                                                                            <asp:Label Text='<%#Eval("Test_Plan_Attachment_File_Name")%>' runat="server" ID="lblTestSubFileName"
                                                                                Visible="true">
                                                                            </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label Text='<%#Eval("Test_Plan_Attach_ID")%>' runat="server" ID="lblattachID"
                                                                            Visible="false">
                                                                        </asp:Label></ContentTemplate>
                                                                                    <Triggers><asp:PostBackTrigger ControlID="lnkTestPlan" /></Triggers> 
                                                                                    </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid><br>
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="SubHeader">
                                                                    Other Supporting Documentation
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="fSuppDocs" style="width: 278px; height: 22px" type="file" size="27" name="fSuppDocs"
                                                                        runat="server">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:ListBox ID="lbSupDocAttach" runat="server" Width="512px"></asp:ListBox>
                                                        &nbsp;<asp:ImageButton ID="imgAddAttchFinalOtherSup" runat="server" ImageUrl="../Images/add.gif"
                                                            CausesValidation="False" OnClick="imgAddAttchFinalOtherSup_Click"></asp:ImageButton>
                                                        &nbsp;&nbsp;<asp:ImageButton ID="imgDelAttchFinalOtherSup" runat="server" ImageUrl="../Images/delete.gif"
                                                            CausesValidation="False" OnClick="imgDelAttchFinalOtherSup_Click" OnClientClick="return CheckListBoxAttSelect('lbSupDocAttach');"></asp:ImageButton>&nbsp;
                                                        <br>
                                                        <asp:DataGrid ID="dgrdSupAttach" runat="server" Width="500px" GridLines="None" AutoGenerateColumns="False"
                                                            BorderColor="black" HeaderStyle-CssClass="SubHeader" BorderWidth="1px" 
                                                            OnItemCommand="dgrdSupAttach_ItemCommand">
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                    <asp:UpdatePanel ID="updpanlnkSupAttach" runat="server" ><ContentTemplate>
                                                                        <asp:LinkButton ID="lnkSupAttach" CommandName="Final_Click" Visible="true" runat="server"
                                                                            CausesValidation="False">
                                                                            <asp:Label Text='<%#Eval("Other_Supporting_Doc_Attachment_File_Name")%>' runat="server"
                                                                                ID="lblSupFileName" Visible="true">
                                                                            </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label Text='<%#Eval("Other_Supporting_Doc_Attach_ID")%>' runat="server" ID="lblSupFullfName"
                                                                            Visible="false">
                                                                        </asp:Label>
                                                                        </ContentTemplate>
                                                                                    <Triggers><asp:PostBackTrigger ControlID="lnkSupAttach" /></Triggers> 
                                                                                    </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid><br>
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="SubHeader">
                                                                    Final Report
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="fFinalReport" style="width: 278px; height: 22px" type="file" size="27"
                                                                        name="fFinalReport" runat="server">&nbsp;&nbsp;&nbsp;
                                                                    <asp:ImageButton ID="imgCloseOutThitSite" runat="server" ImageUrl="../Images/Close-out-This-Site-Test.jpg"
                                                                        CausesValidation="False" OnClick="imgCloseOutThitSite_Click"></asp:ImageButton>&nbsp;&nbsp;&nbsp;<asp:ImageButton
                                                                            ID="imgAdminCloseOut" runat="server" ImageUrl="../Images/Admin-Close-out.jpg"
                                                                            CausesValidation="False" OnClick="imgAdminCloseOut_Click"></asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:ListBox ID="lbFinalReportAttach" runat="server" Width="512px"></asp:ListBox>
                                                        &nbsp;<asp:ImageButton ID="imgAddFinalReport" runat="server" ImageUrl="../Images/add.gif"
                                                            CausesValidation="False" OnClick="imgAddFinalReport_Click"></asp:ImageButton>
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton ID="imgDelFinalReport" runat="server" ImageUrl="../Images/delete.gif"
                                                            CausesValidation="False" OnClick="imgDelFinalReport_Click" OnClientClick="return CheckListBoxAttSelect('lbFinalReportAttach');"></asp:ImageButton>&nbsp;
                                                        &nbsp;
                                                        <br>
                                                        <asp:DataGrid ID="dgrdAttachment" runat="server" Width="500px" GridLines="None" AutoGenerateColumns="False"
                                                            BorderColor="black" HeaderStyle-CssClass="SubHeader" BorderWidth="1px" 
                                                            OnItemCommand="dgrdAttachment_ItemCommand">
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                     <asp:UpdatePanel ID="updpanlnkFinalattachment" runat="server" ><ContentTemplate>
                                                                        <asp:LinkButton ID="lnkFinalattachment" CommandName="Final_Click" Visible="true"
                                                                            runat="server" CausesValidation="False">
                                                                            <asp:Label Text='<%#Eval("Final_Report_Attachment_File_Name")%>' runat="server" ID="lblFileName"
                                                                                Visible="true">
                                                                            </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label Text='<%#Eval("Final_Report_Attach_ID")%>' runat="server" ID="lblFullfname"
                                                                            Visible="false">
                                                                        </asp:Label></ContentTemplate>
                                                                                    <Triggers><asp:PostBackTrigger ControlID="lnkFinalattachment" /></Triggers> 
                                                                                    </asp:UpdatePanel>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid><br>
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="SubHeader" align="left">
                                                                    Additional Information
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtAddInfo" runat="server" Width="369px" TextMode="MultiLine" Height="102px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="1">
                                                            <tr>
                                                                <td width="75%">
                                                                    <span class="FieldNames">Does this project involve a new chemical or a change in the
                                                                        use of an existing chemical?</span>
                                                                </td>
                                                                <td width="25%">
                                                                    <asp:RadioButton ID="changeYes" runat="server" GroupName="Change" Text="Yes"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                                                        ID="changeNo" runat="server" GroupName="Change" Text="No"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="FieldNames">Does this project involve a new raw material or a change in
                                                                        the physical properties of an existing raw material?</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="RMYes" runat="server" GroupName="RawMat" Text="Yes"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                                                        ID="RMNo" runat="server" GroupName="RawMat" Text="No"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="FieldNames">Does this project require new equipment/process/supporting
                                                                        systems or a change in existing equipment/process/supporting systems?</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="eqpYes" runat="server" GroupName="Equip" Text="Yes"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                                                        ID="eqpNo" runat="server" GroupName="Equip" Text="No"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="FieldNames">Does this project require a new job/task or a change in the
                                                                        way a job/task is performed?</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="jobYes" runat="server" GroupName="Job" Text="Yes"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                                                        ID="jobNo" runat="server" GroupName="Job" Text="No"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="FieldNames">Are there sample storage concerns?</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="stgYes" runat="server" GroupName="Storage" Text="Yes"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                                                        ID="stgNo" runat="server" GroupName="Storage" Text="No"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                          
                                                            <tr>
                                                                <td style="height: 19px">
                                                                    <span class="FieldNames">Is a chemical approval needed?</span>
                                                                </td>
                                                                <td style="height: 19px">
                                                                    <asp:RadioButton ID="apprYes" runat="server" AutoPostBack="True" GroupName="Approval"
                                                                        Text="Yes" OnCheckedChanged="apprYes_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                                                            ID="apprNo" runat="server" AutoPostBack="True" GroupName="Approval" Text="No"
                                                                            OnCheckedChanged="apprNo_CheckedChanged"></asp:RadioButton>
                                                                </td>
                                                            </tr>
                                                            <tr id="trApproval" runat="server">
                                                                <td colspan="2">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Please complete the following...</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What precautions are necessary for use?</span><br>
                                                                                <asp:TextBox ID="txtPrecautions" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What precautions are necessary for Sampling?</span><br>
                                                                                <asp:TextBox ID="txtSampling" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What precautions are necessary for Storage?</span><br>
                                                                                <asp:TextBox ID="txtStorage" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What precautions are necessary for Equipment?</span><br>
                                                                                <asp:TextBox ID="txtEquipment" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What is disposal procedure for Unused Chemical?</span><br>
                                                                                <asp:TextBox ID="txtDispose" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What is the appropriate spill response?</span><br>
                                                                                <asp:TextBox ID="txtSpill" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">What are the potential environmental impacts?</span><br>
                                                                                <asp:TextBox ID="txtEnvImpacts" runat="server" Width="560px" MaxLength="1000" TextMode="MultiLine"
                                                                                    Height="98px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="FieldNames">Note: For chemical disposal plans, contact MEG. Remember to
                                                                                    make necessary arrangements to return/dispose of all unused chemical.</span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                                 <tr bordercolor="#ffffff">
                                                                <td>
                                                                       <table border="0" width="100%">
                                                                        <tr id="trSenGrp" bordercolor="#ffffff" runat="server">
                                                                            <td style="height: 20px">
                                                                                <asp:LinkButton ID="lnkSendconGrp" runat="server" CausesValidation="False" OnClick="lnkSendconGrp_Click"><b>
																					Send for Concurrence</b>
                                                                                </asp:LinkButton>
                                                                             
                                                                                  <div style="display:none" >
                                                                                    <asp:Button ID="btnConApp" runat="server" Text="btnConApp" OnClick="btnConApp_Click" />
                                                                            <asp:Button ID="btnApp" runat="server" Text="btnApp" OnClick="btnApp_Click" />
                                                                            </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnConAppID" runat="server" />
                                                                                <asp:HiddenField ID="hdnOrigAppr" runat="server" />
                                                                                <asp:DataGrid ID="dlstConcGrp" runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False"
                                                                                    BorderColor="black" HeaderStyle-CssClass="SubHeader" BorderWidth="1px" ShowHeader="False"
                                                                                    OnItemCommand="dlstConcGrp_ItemCommand" OnItemDataBound="dlstConcGrp_ItemDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateColumn>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label Text='<%#Eval("Created_Date")%>' runat="server" ID="lblDay" Width="150px">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label Text='<%#Eval("Concurrence_Group_Name")%>' runat="server" ID="lblConGrpName"
                                                                                                    Width="120px">
                                                                                                </asp:Label>
                                                                                                <asp:Label Text='<%#Eval("Concurrence_Group_ID")%>' runat="server" ID="lblConGrpID"
                                                                                                    Visible="False">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label Text='<%#Eval("Approver_Name")%>' runat="server" ID="lblapprName" Width="120px">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label Text='<%#Eval("Is_Responded")%>' runat="server" ID="Label2" Width="120px">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkApproval" CommandName="Approval_Link" Visible="False" runat="server"
                                                                                                    CausesValidation="False" Width="80px">
																		                  
																		            Concur
                                                                                                </asp:LinkButton>
                                                                                                <asp:Label Text='<%# Eval("Concurrence_Group_ID")%>' runat="server" ID="lblConAppGrpID"
                                                                                                    Visible="false">
                                                                                                </asp:Label>
                                                                                                <asp:Label Text='<%#Eval("Approver_Name")%>' runat="server" ID="lnkapprName" Visible="False">
                                                                                                </asp:Label>
                                                                                                <asp:Label Text='<%#Eval("EO_Con_App_ID")%>' runat="server" ID="lblConAppID" Visible="False">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkDeclined" CommandName="Declined_Link" Visible="False" runat="server"
                                                                                                    CausesValidation="False" Width="80px">
                                                                                                    <asp:Label Text='<%#Eval("Approver_Name")%>' runat="server" ID="lnkDecApprName" Visible="False">
                                                                                                    </asp:Label>
                                                                                                    Decline
                                                                                                </asp:LinkButton>
                                                                                                <asp:Label Text='<%# Eval("Concurrence_Group_ID")%>' runat="server" ID="lblConDecGrpID"
                                                                                                    Visible="false">
                                                                                                </asp:Label>
                                                                                                <asp:Label Text='<%# Eval("EO_Con_App_ID")%>' runat="server" ID="lblConDecAppID"
                                                                                                    Visible="false">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkBackUp" CommandName="Backup_Link" Visible="False" runat="server"
                                                                                                    CausesValidation="False" Width="80px">
                                                                                                    <asp:Label Text='<%#Eval("Approver_Name")%>' runat="server" ID="lnkBakApprName" Visible="False">
                                                                                                    </asp:Label>
                                                                                                    BackUp
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label Text='<%#Eval("EO_Con_App_ID")%>' runat="server" ID="Label1" Visible="False">
                                                                                                </asp:Label>
                                                                                                <asp:Label Text='<%#Eval("Backup_Approver_Name")%>' runat="server" ID="lblBackUpApprover"
                                                                                                    Visible="True">
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                    </Columns>
                                                                                </asp:DataGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trRevHis" runat="server">
                                                                            <td>
                                                                                <span class="FieldNames">
                                                                                    <asp:Label ID="lblRevHistory" runat="server"><b>Revision History</b></asp:Label></span><!--<asp:linkbutton id=lnkRevisionHistory Runat="server" CausesValidation="False">Revision History</asp:linkbutton>-->
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DataGrid ID="dgrdRevHis" Width="100%" runat="server" GridLines="None" AutoGenerateColumns="True"
                                                                                    BorderColor="black" HeaderStyle-CssClass="SubHeader" BorderWidth="1px" ShowHeader="False">
                                                                                </asp:DataGrid>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="hdnApprover" runat="server" Width="0" Style="display: none"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:TextBox ID="t1" runat="server" Width="0" Style="display: none"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td bordercolor="#ffffff" width="100%">
                                        <asp:CustomValidator ID="cstdProj" runat="server" ClientValidationFunction="ProjeCheck"
                                            ErrorMessage="Please select Project." Display="None" ControlToValidate="ddlProject"></asp:CustomValidator><asp:CustomValidator
                                                ID="cstvdCategory" runat="server" ClientValidationFunction="CatCheck" ErrorMessage="Please select Category."
                                                Display="None" ControlToValidate="ddlCategory"></asp:CustomValidator><asp:CustomValidator
                                                    ID="cstdPlant" runat="server" ClientValidationFunction="PlantCheck" ErrorMessage="Please select Plant."
                                                    Display="None" ControlToValidate="drpPlant"></asp:CustomValidator><asp:RequiredFieldValidator
                                                        ID="reqdVdEvents" runat="server" ErrorMessage="Please select Event(s)." Display="None"
                                                        ControlToValidate="lbEOEventsDB"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                            ID="reqdBrandSegmt" runat="server" ErrorMessage="Please select BrandSegments(s)."
                                                            Display="None" ControlToValidate="lbEOBrandsDB"></asp:RequiredFieldValidator>
                                        <asp:ValidationSummary ID="vdsmEO" Style="z-index: 101; position: absolute; top: 72px;
                                            left: 16px" runat="server" DisplayMode="List" ShowSummary="False" ShowMessageBox="True">
                                        </asp:ValidationSummary>
                                        <p>
                                            &nbsp;</p>
                                    </td>
                                </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trFooter" runat="server">
                    <td colspan="3">
                        <uc2:FooterControl ID="FooterControl1" runat="server" />
                    </td>
                </tr>
            </table>
            <input name="posX" id="posX" type="hidden" value="0" runat="server">
            <input name="posY" id="posY" type="hidden" value="0" runat="server">
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgAddAttchFinalTestPlans" />
            <asp:PostBackTrigger ControlID="imgAddAttchFinalOtherSup" />
            <asp:PostBackTrigger ControlID="imgAddFinalReport" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
