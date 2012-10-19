<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="NewEO.aspx.cs" Inherits="MUREOUI.Common.NewEO" EnableViewStateMac="false" EnableEventValidation="false" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New EO</title>
    <link href="../StyleSheets/EO.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/EO.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/MUREO.css" rel="stylesheet" type="text/css" />
    <script language="javascript"> 
		<!--
            function HandleOnCheck() {
                var hdnFir = document.getElementById("hdnFirst");
                var selectedIndex, selectedValue
                if (document.getElementById("chkMaterialsBrands") != null) {
                    objInputs = document.getElementById("chkMaterialsBrands").getElementsByTagName("INPUT");
                    hdnFir.value = "Editing";
                    for (i = 0; i < objInputs.length; i++) {
                        if (objInputs[i].type == "checkbox") {
                            if (objInputs[i].checked) {
                                selectedIndex = i;
                                selectedValue = objInputs[i].nextSibling.innerText
                                document.getElementById("hdnIndex").value = i;

                                objInputs.checked = false;
                            }
                        }
                    }
                }
            }

            var objChkd;

            function HandleOnCheck1() {

                if (document.getElementById("hdnFirst").value == "Editing") {
                    if (document.getElementById("chkMaterialsBrands") != null) {
                        objInputs = document.getElementById("chkMaterialsBrands").getElementsByTagName("INPUT");
                        objInputs[document.getElementById("hdnIndex").value].checked = false;
                    }
                }


                var chkLst = document.getElementById('chkMaterialsBrands');
                if (objChkd && objChkd.checked)
                    objChkd.checked = false;
                objChkd = event.srcElement;
                document.getElementById("hdnFirst").value = "None";
                document.getElementById("hdnIndex").value = "None";
            }
            // 
            //var milisec = 0;
            //var seconds = 60;



            function CheckProductConsumerOption() {

                var OptionProdConsumerNo = document.getElementById("rblProductConsumers_1").checked;

                if (OptionProdConsumerNo) {
                    //alert('No SMART Clearance is needed with the response(s) given');
                }
                else {
                }
                var OptionProdApprovedNo = document.getElementById("rblProductApproved_1").checked;
                var OptionProdConsumerYes = document.getElementById("rblProductConsumers_0").checked;

                if (OptionProdConsumerYes && OptionProdApprovedNo) {
                    document.getElementById("divPSRAAddedRawMaterials").style.display = 'block';

                }



                if (OptionProdConsumerNo && OptionProdApprovedNo) {
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                
                    document.getElementById("divPSRAAddedRawMaterials").style.display = 'none';
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                    var list = document.getElementById("rblRawMaterialsQ1");
                    var options = document.getElementsByName("rblRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                    //alert('No SMART Clearance is needed with the response(s) given');
                }

                var OptionProdApprovedYes = document.getElementById("rblProductApproved_0").checked;

                if (OptionProdConsumerYes && OptionProdApprovedYes) {
                    document.getElementById("divPSRAAddedRawMaterials").style.display = 'none';
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                    var list = document.getElementById("rblRawMaterialsQ1");
                    var options = document.getElementsByName("rblRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                    //alert('No SMART Clearance is needed with the response(s) given');
                }

                var OptionProdConsumerYes = document.getElementById("rblProductConsumers_0").checked;
                var OptionProdConsumerNo = document.getElementById("rblProductConsumers_1").checked;
                var OptionProdApprovedYes = document.getElementById("rblProductApproved_0").checked;
                var OptionProdApprovedNo = document.getElementById("rblProductApproved_1").checked;

                if (OptionProdConsumerYes && OptionProdApprovedYes) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdConsumerNo && OptionProdApprovedNo) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdConsumerNo && OptionProdApprovedYes) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }
            }


            function CheckProductApprovedOption() {
                var OptionProdConsumerYes = document.getElementById("rblProductConsumers_0").checked;
                var OptionProdConsumerNo = document.getElementById("rblProductConsumers_1").checked;
                var OptionProdApprovedYes = document.getElementById("rblProductApproved_0").checked;
                var OptionProdApprovedNo = document.getElementById("rblProductApproved_1").checked;

                if (OptionProdApprovedYes && OptionProdConsumerYes) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdApprovedNo && OptionProdConsumerNo) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdApprovedYes && OptionProdConsumerNo) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }




                if (OptionProdApprovedYes) {


                    document.getElementById("divPSRAAddedRawMaterials").style.display = 'none';

                    var list = document.getElementById("rblRawMaterialsQ1");
                    var options = document.getElementsByName("rblRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                }
                else {
                }

                var OptionProdConsumerYes = document.getElementById("rblProductConsumers_0").checked;
                var OptionProdApprovedNo = document.getElementById("rblProductApproved_1").checked;

                if (OptionProdConsumerYes && OptionProdApprovedNo) {
                    document.getElementById("divPSRAAddedRawMaterials").style.display = 'block';

                    var list = document.getElementById("rblRawMaterialsQ1");
                    var options = document.getElementsByName("rblRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                }
                else {
                    document.getElementById("divPSRAAddedRawMaterials").style.display = 'none';
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                    var list = document.getElementById("rblRawMaterialsQ1");
                    var options = document.getElementsByName("rblRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }


                }
            }



            function CheckRMQ1() {
                var OptionRMQ1No = document.getElementById("rblRawMaterialsQ1_1").checked;


                if (OptionRMQ1No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                var OptionRMQ2No = document.getElementById("rblRawMaterialsQ2_1").checked;
                var OptionRMQ3No = document.getElementById("rblRawMaterialsQ3_1").checked;
                var OptionRMQ4No = document.getElementById("rblRawMaterialsQ4_1").checked;

                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearance').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                    document.getElementById("hdnSmartValue").value = document.getElementById('lblCoOrdinator').innerText;
                }
                else {
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function CheckRMQ2() {
                var OptionRMQ2No = document.getElementById("rblRawMaterialsQ2_1").checked;


                if (OptionRMQ2No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                var OptionRMQ1No = document.getElementById("rblRawMaterialsQ1_1").checked;
                var OptionRMQ3No = document.getElementById("rblRawMaterialsQ3_1").checked;
                var OptionRMQ4No = document.getElementById("rblRawMaterialsQ4_1").checked;
                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearance').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                    document.getElementById("hdnSmartValue").value = document.getElementById('lblCoOrdinator').innerText;
                }
                else {
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function CheckRMQ3() {
                var OptionRMQ3No = document.getElementById("rblRawMaterialsQ3_1").checked;


                if (OptionRMQ3No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                var OptionRMQ2No = document.getElementById("rblRawMaterialsQ2_1").checked;
                var OptionRMQ1No = document.getElementById("rblRawMaterialsQ1_1").checked;
                var OptionRMQ4No = document.getElementById("rblRawMaterialsQ4_1").checked;
                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearance').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                    document.getElementById("hdnSmartValue").value = document.getElementById('lblCoOrdinator').innerText;
                }
                else {
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function CheckRMQ4() {
                var OptionRMQ4No = document.getElementById("rblRawMaterialsQ4_1").checked;
                var OptionRMQ2No = document.getElementById("rblRawMaterialsQ2_1").checked;
                var OptionRMQ3No = document.getElementById("rblRawMaterialsQ3_1").checked;
                var OptionRMQ1No = document.getElementById("rblRawMaterialsQ1_1").checked;
                if (OptionRMQ4No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearance').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                    document.getElementById("hdnSmartValue").value = document.getElementById('lblCoOrdinator').innerText;
                }
                else {
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }






            function CheckSMARTText() {
                var OptionRMQ1No = document.getElementById("rblRawMaterialsQ1_1").checked;
                var OptionRMQ2No = document.getElementById("rblRawMaterialsQ2_1").checked;
                var OptionRMQ3No = document.getElementById("rblRawMaterialsQ3_1").checked;
                var OptionRMQ4No = document.getElementById("rblRawMaterialsQ4_1").checked;
                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                    document.getElementById('txtSmartClearance').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                    document.getElementById("hdnSmartValue").value = document.getElementById('lblCoOrdinator').innerText;
                }
                else {
                    document.getElementById('txtSmartClearance').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                    document.getElementById("hdnSmartValue").value = "Approval Not Needed";
                }


            }


            //Added for Final Tab

            function FinalHandleOnCheck() {
       
                var hdnFinalFir = document.getElementById("hdnFinalFirst");
                var selectedIndex, selectedValue
                if (document.getElementById("chkFinalMaterialsBrands") != null) {
                    objFinalInputs = document.getElementById("chkFinalMaterialsBrands").getElementsByTagName("INPUT");
                    hdnFinalFir.value = "Editing";
                    for (i = 0; i < objFinalInputs.length; i++) {
                        if (objFinalInputs[i].type == "checkbox") {
                            if (objFinalInputs[i].checked) {
                                selectedIndex = i;
                                selectedValue = objFinalInputs[i].nextSibling.innerText
                                document.getElementById("hdnFinalIndex").value = i;
                                objFinalInputs.checked = false;
                            }
                        }
                    }
                }
            }

            var objFinalChkd;

            function FinalHandleOnCheck1() {

                if (document.getElementById("hdnFinalFirst").value == "Editing") {
                    if (document.getElementById("chkFinalMaterialsBrands") != null) {
                        objFinalInputs = document.getElementById("chkFinalMaterialsBrands").getElementsByTagName("INPUT");
                        objFinalInputs[document.getElementById("hdnFinalIndex").value].checked = false;
                    }
                }

                var chkFinalLst = document.getElementById('chkFinalMaterialsBrands');
                if (objFinalChkd && objFinalChkd.checked)
                    objFinalChkd.checked = false;
                objFinalChkd = event.srcElement;
                document.getElementById("hdnFinalFirst").value = "None";
                document.getElementById("hdnFinalIndex").value = "None";
            }

            function CheckFinalProductConsumerOption() {

                var OptionProdConsumerYes = document.getElementById("rblFinalProductConsumerOption_0").checked;
                var OptionProdConsumerNo = document.getElementById("rblFinalProductConsumerOption_1").checked;
                var OptionProdApprovedYes = document.getElementById("rblFinalProductApprovedOption_0").checked;
                var OptionProdApprovedNo = document.getElementById("rblFinalProductApprovedOption_1").checked;

                if (OptionProdConsumerYes && OptionProdApprovedYes) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdConsumerNo && OptionProdApprovedNo) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdConsumerNo && OptionProdApprovedYes) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }




                var OptionFinalProdConsumerNo = document.getElementById("rblFinalProductConsumerOption_1").checked;

                if (OptionFinalProdConsumerNo) {


                    //alert('No SMART Clearance is needed with the response(s) given');
                }
                else {
                }
                var OptionFinalProdApprovedNo = document.getElementById("rblFinalProductApprovedOption_1").checked;

                var OptionFinalProdConsumerYes = document.getElementById("rblFinalProductConsumerOption_0").checked;

                if (OptionFinalProdConsumerYes && OptionFinalProdApprovedNo) {
                    document.getElementById("tblPSRAFinal2").style.display = 'block';

                }
                if (OptionFinalProdConsumerNo && OptionFinalProdApprovedNo) {
                    document.getElementById("tblPSRAFinal2").style.display = 'none';
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";


                    var Finallist = document.getElementById("rblFinalRawMaterialsQ1");
                    var Finaloptions = document.getElementsByName("rblFinalRawMaterialsQ1");
                    for (x = 0; x < Finaloptions.length; ++x) {
                        if (Finaloptions[x].type == "radio" && Finaloptions[x].checked) {
                            Finaloptions[x].checked = false;

                        }
                    }
                    var Finallist1 = document.getElementById("rblFinalRawMaterialsQ2");
                    var Finaloptions1 = document.getElementsByName("rblFinalRawMaterialsQ2");
                    for (x = 0; x < Finaloptions1.length; ++x) {
                        if (Finaloptions1[x].type == "radio" && Finaloptions1[x].checked) {
                            Finaloptions1[x].checked = false;

                        }
                    }
                    var Finallist2 = document.getElementById("rblFinalRawMaterialsQ3");
                    var Finaloptions2 = document.getElementsByName("rblFinalRawMaterialsQ3");
                    for (x = 0; x < Finaloptions2.length; ++x) {
                        if (Finaloptions2[x].type == "radio" && Finaloptions2[x].checked) {
                            Finaloptions2[x].checked = false;

                        }
                    }
                    var Finallist3 = document.getElementById("rblFinalRawMaterialsQ4");
                    var Finaloptions3 = document.getElementsByName("rblFinalRawMaterialsQ4");
                    for (x = 0; x < Finaloptions3.length; ++x) {
                        if (Finaloptions3[x].type == "radio" && Finaloptions3[x].checked) {
                            Finaloptions3[x].checked = false;

                        }
                    }
                }

                var OptionFinalProdApprovedYes = document.getElementById("rblFinalProductApprovedOption_0").checked;

                if (OptionFinalProdConsumerYes && OptionFinalProdApprovedYes) {
                    document.getElementById("tblPSRAFinal2").style.display = 'none';
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";

                    var Finalxlist = document.getElementById("rblFinalRawMaterialsQ1");
                    var Finalxoptions = document.getElementsByName("rblFinalRawMaterialsQ1");
                    for (x = 0; x < Finalxoptions.length; ++x) {
                        if (Finalxoptions[x].type == "radio" && Finalxoptions[x].checked) {
                            Finalxoptions[x].checked = false;

                        }
                    }
                    var Finalxlist1 = document.getElementById("rblFinalRawMaterialsQ2");
                    var Finalxoptions1 = document.getElementsByName("rblFinalRawMaterialsQ2");
                    for (x = 0; x < Finalxoptions1.length; ++x) {
                        if (Finalxoptions1[x].type == "radio" && Finalxoptions1[x].checked) {
                            Finalxoptions1[x].checked = false;

                        }
                    }
                    var Finalxlist2 = document.getElementById("rblFinalRawMaterialsQ3");
                    var Finalxoptions2 = document.getElementsByName("rblFinalRawMaterialsQ3");
                    for (x = 0; x < Finalxoptions2.length; ++x) {
                        if (Finalxoptions2[x].type == "radio" && Finalxoptions2[x].checked) {
                            Finalxoptions2[x].checked = false;

                        }
                    }
                    var Finalxlist3 = document.getElementById("rblFinalRawMaterialsQ4");
                    var Finalxoptions3 = document.getElementsByName("rblFinalRawMaterialsQ4");
                    for (x = 0; x < Finalxoptions3.length; ++x) {
                        if (Finalxoptions3[x].type == "radio" && Finalxoptions3[x].checked) {
                            Finalxoptions3[x].checked = false;

                        }
                    }
                }



            }


            function CheckFinalProductApprovedOption() {

                var OptionProdConsumerYes = document.getElementById("rblFinalProductConsumerOption_0").checked;
                var OptionProdConsumerNo = document.getElementById("rblFinalProductConsumerOption_1").checked;
                var OptionProdApprovedYes = document.getElementById("rblFinalProductApprovedOption_0").checked;
                var OptionProdApprovedNo = document.getElementById("rblFinalProductApprovedOption_1").checked;

                if (OptionProdApprovedYes && OptionProdConsumerYes) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdApprovedNo && OptionProdConsumerNo) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                if (OptionProdApprovedYes && OptionProdConsumerNo) {
                    alert('No SMART Clearance is needed with the response(s) given');
                }

                var OptionFinalProdApprovedYes = document.getElementById("rblFinalProductApprovedOption_0").checked;

                if (OptionFinalProdApprovedYes) {


                    document.getElementById("tblPSRAFinal2").style.display = 'none';

                    var list = document.getElementById("rblFinalRawMaterialsQ1");
                    var options = document.getElementsByName("rblFinalRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblFinalRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblFinalRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblFinalRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblFinalRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblFinalRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblFinalRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                }
                else {
                }

                var OptionProdConsumerYes = document.getElementById("rblFinalProductConsumerOption_0").checked;
                var OptionProdApprovedNo = document.getElementById("rblFinalProductApprovedOption_1").checked;

                if (OptionProdConsumerYes && OptionProdApprovedNo) {
                    document.getElementById("tblPSRAFinal2").style.display = 'block';

                    var list = document.getElementById("rblFinalRawMaterialsQ1");
                    var options = document.getElementsByName("rblFinalRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblFinalRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblFinalRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblFinalRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblFinalRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblFinalRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblFinalRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                }
                else {
                    document.getElementById("tblPSRAFinal2").style.display = 'none';
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";

                    var list = document.getElementById("rblFinalRawMaterialsQ1");
                    var options = document.getElementsByName("rblFinalRawMaterialsQ1");
                    for (x = 0; x < options.length; ++x) {
                        if (options[x].type == "radio" && options[x].checked) {
                            options[x].checked = false;

                        }
                    }
                    var list1 = document.getElementById("rblFinalRawMaterialsQ2");
                    var options1 = document.getElementsByName("rblFinalRawMaterialsQ2");
                    for (x = 0; x < options1.length; ++x) {
                        if (options1[x].type == "radio" && options1[x].checked) {
                            options1[x].checked = false;

                        }
                    }
                    var list2 = document.getElementById("rblFinalRawMaterialsQ3");
                    var options2 = document.getElementsByName("rblFinalRawMaterialsQ3");
                    for (x = 0; x < options2.length; ++x) {
                        if (options2[x].type == "radio" && options2[x].checked) {
                            options2[x].checked = false;

                        }
                    }
                    var list3 = document.getElementById("rblFinalRawMaterialsQ4");
                    var options3 = document.getElementsByName("rblFinalRawMaterialsQ4");
                    for (x = 0; x < options3.length; ++x) {
                        if (options3[x].type == "radio" && options3[x].checked) {
                            options3[x].checked = false;

                        }
                    }
                }
            }


            function CheckFinalRMQ1() {
                var OptionRMQ1No = document.getElementById("rblFinalRawMaterialsQ1_1").checked;


                if (OptionRMQ1No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                var OptionRMQ2No = document.getElementById("rblFinalRawMaterialsQ2_1").checked;
                var OptionRMQ3No = document.getElementById("rblFinalRawMaterialsQ3_1").checked;
                var OptionRMQ4No = document.getElementById("rblFinalRawMaterialsQ4_1").checked;

                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearanceFinal').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                    
                }
                else {
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblFinalRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblFinalRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblFinalRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblFinalRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function CheckFinalRMQ2() {
                var OptionRMQ2No = document.getElementById("rblFinalRawMaterialsQ2_1").checked;


                if (OptionRMQ2No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                var OptionRMQ1No = document.getElementById("rblFinalRawMaterialsQ1_1").checked;
                var OptionRMQ3No = document.getElementById("rblFinalRawMaterialsQ3_1").checked;
                var OptionRMQ4No = document.getElementById("rblFinalRawMaterialsQ4_1").checked;
                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearanceFinal').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                }
                else {
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblFinalRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblFinalRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblFinalRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblFinalRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function CheckFinalRMQ3() {
                var OptionRMQ3No = document.getElementById("rblFinalRawMaterialsQ3_1").checked;


                if (OptionRMQ3No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                var OptionRMQ2No = document.getElementById("rblFinalRawMaterialsQ2_1").checked;
                var OptionRMQ1No = document.getElementById("rblFinalRawMaterialsQ1_1").checked;
                var OptionRMQ4No = document.getElementById("rblFinalRawMaterialsQ4_1").checked;
                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearanceFinal').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                }
                else {
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblFinalRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblFinalRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblFinalRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblFinalRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function CheckFinalRMQ4() {
                var OptionRMQ4No = document.getElementById("rblFinalRawMaterialsQ4_1").checked;


                var OptionRMQ2No = document.getElementById("rblFinalRawMaterialsQ2_1").checked;
                var OptionRMQ3No = document.getElementById("rblFinalRawMaterialsQ3_1").checked;
                var OptionRMQ1No = document.getElementById("rblFinalRawMaterialsQ1_1").checked;
                if (OptionRMQ4No) {
                    alert('Submit a SMART Request if you answered "No" to any of the Raw Materials Questions.\nContact a PS&RA Rep for help.\nAdd SMART Clearance # to MUR EO in approval step.');
                }

                if (OptionRMQ1No || OptionRMQ2No || OptionRMQ3No || OptionRMQ4No) {
                    document.getElementById('txtSmartClearanceFinal').value = document.getElementById('lblCoOrdinator').innerText;
                    document.getElementById('lblSmartClearanceDB').innerHTML = " ";
                    document.getElementById("hdnSmart").value = "In Process";
                }
                else {
                    document.getElementById('txtSmartClearanceFinal').value = "Approval Not Needed";
                    document.getElementById('lblSmartClearanceDB').innerHTML = "Not Needed";
                    document.getElementById("hdnSmart").value = "Not Needed";
                }
                var OptionRMQ1Yes = document.getElementById("rblFinalRawMaterialsQ1_0").checked;
                var OptionRMQ2Yes = document.getElementById("rblFinalRawMaterialsQ2_0").checked;
                var OptionRMQ3Yes = document.getElementById("rblFinalRawMaterialsQ3_0").checked;
                var OptionRMQ4Yes = document.getElementById("rblFinalRawMaterialsQ4_0").checked;

                if (OptionRMQ1Yes && OptionRMQ2Yes && OptionRMQ3Yes && OptionRMQ4Yes) {
                    alert('No Smart Clearance is needed with Response(s) given');
                }
            }

            function display(seconds, milisec) {

                if (milisec <= 0) {
                    milisec = 9;
                    seconds -= 1;
                }

                if (seconds <= -1) {
                    milisec = 0;
                    seconds += 1;
                    window.navigate("EOTimeLock.aspx");
                }
                else {

                    milisec -= 1;
                    setTimeout("display(" + seconds + "," + milisec + ")", 100)
                }
            } 
		--> 
		</script>
	<script language="javascript">

	    function display3434() {
	        if (confirm('Are you sure you want to delete?')) {
	            document.getElementById('TextBox1').value = "1";
	            return true;
	        }
	        else {
	            document.getElementById('TextBox1').value = "2";
	            return false;
	        }
	    }




	    function OpenHelpWindow() {
	        window.open('../common/Templates/MUREO_UserManual.doc');
	    }
	    function OpenFAQWindow() {
	        alert('Under Construction');
	    }
	    function GlobalTeamSpaceWindow() {
	        var aw = screen.availWidth;
	        var ah = screen.availHeight;
	        window.open('http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf', 'NewWin', 'locationbar=yes,toolbar=yes,scrollbars=yes,resize=yes, width = ' + aw + ',height = ' + ah + ',top = 0, left = 0')
	    }
			
	</script>
	<script language="javascript">
	    function confirmAttachmentDelete() {
	        alert('Attachment will be deleted from the database after the EO is submitted');
	    }

	    function confirmAttachmentAdd() {
	        alert('Attachment will be inserted into the database after the EO is submitted');
	    }

	    function IsPopupBlocker() {
	        var oWin = window.open("", "testpopupblocker", "width=0,height=0,top=5000,left=5000");
	        if (oWin == null || typeof (oWin) == "undefined") {
	            alert("This application requires Pop-up Blocker to be turned off to function normally. \n Please turn-off Pop-up Blocker before entering any data to avoid loss of data.");
	        }
	        else {
	            oWin.close();
	        }
	    }

	    // Code added by srilakshmi
	    function concurenceConfirm(ConAppID, EoId, appStatus, ConGrpID, AppName) {

	        var popResult;
	        popResult = window.open('PreScreenApproverConfirm.aspx?EOID=' + EoId + '&EoStage=CONCURENCE&ConAppID=' + ConAppID + '&appStatus=' + appStatus + '&ConGrpID=' + ConGrpID + '&AppName=' + AppName, null, 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');

	        if (popResult == "T") {
	            if (appStatus == "Declined") {
	                alert('Concurrence is declined successfully');
	            }
	            else {
	                alert('Your concurrence is registered successfully.');
	            }
	            window.navigate('../Reports/MyApprovals.aspx');
	        }
	    }
	    function AddBooksingUserForBakUp(btn) {
//	        var popResult;
//	        popResult = window.showModalDialog('ShowUser.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:500px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
//	        document.NewEO.hdnApprover.value = popResult;
//	        if (popResult != "") {
//	            document.getElementById('hdnApprover').value = popResult;
//	        }
//	        if (document.getElementById('hdnApprover').value == 'undefined') {
//	            document.getElementById('hdnApprover').value = "";
	        //	        }
	 
	        document.getElementById("<%=hdnConAppID.ClientID %>").value = btn.getAttribute('lblConAppID');
	        document.getElementById("<%=hdnOrigAppr.ClientID %>").value = btn.getAttribute('lblOrigAppr');
	        
	        var hdntxtAuthApprover = btn.getAttribute('hdnApprClientID');
	      	     
	        var btnApp = btn.getAttribute('btnApp');
	        window.open('../Common/ShowUser.aspx?btnApp=' + btnApp + '&Hidd=' + hdntxtAuthApprover + '&Type=C', 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');	       
//	        window.open('ShowUsers.aspx?ID=&Hidd=', 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
	        return false;
	    }


	    function preScreenConfirm(PSAppID, EoId, appStatus, ConGrpID, AppName) {
	        var popResult;
	        popResult = window.open('PreScreenApproverConfirm.aspx?EOID=' + EoId + '&EoStage=PRESCREEN&PSAppID=' + PSAppID + '&appStatus=' + appStatus + '&ConGrpID=' + ConGrpID + '&AppName=' + AppName, null, 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');

	        if (popResult == "T") {
	            if (appStatus == "Declined") {
	                alert('Prescreen alignment is declined successfully.');
	            }
	            else {
	                alert('Your prescreen alignment is confirmed successfully.');
	            }
	            window.navigate('../Reports/MyApprovals.aspx');
	        }
	    }

	    function ApproverConfirm(EoId, EoStage, appFunName, appStatus) {
	        var popResult;
	        var browserName = navigator.appName;
	        //alert(browserName);
	        if (browserName == "Microsoft Internet Explorer") {
	            //alert(browserName);
	            popResult = window.showModalDialog('ApproverConfirm.aspx?EOID=' + EoId + '&EoStage=' + EoStage + '&appFunName=' + appFunName + '&appStatus=' + appStatus, null, 'dialogWidth:450px;dialogHeight:270px');
	            if (popResult == "T") {
	                if (appStatus == "N") {
	                    alert('Declined Successfully');
	                }
	                else {
	                    alert('Approval is successfully completed');
	                }

	                window.navigate('../Reports/MyApprovals.aspx');
	            }
	        }
	        else {
	            //popResult = window.open('ApproverConfirm.aspx?EOID=' + EoId + '&EoStage=' + EoStage + '&appFunName=' + appFunName + '&appStatus=' + appStatus, null, 'dialogWidth:450px;dialogHeight:270px');
	            popResult = window.open('ApproverConfirm.aspx?EOID=' + EoId + '&EoStage=' + EoStage + '&appFunName=' + appFunName + '&appStatus=' + appStatus, null, 'location = 0, status = 0, scrollbars = 0, toolbar = 0, menubar = 0, resizable = 0, width = 500, height = 180');
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

	    function txtBudgetOwnerOther() {
	        if (document.NewEO.txtBudgetOwnerFinal.value = "") {
	            document.NewEO.txtBudgetOwnerFinal.value = document.NewEO.txtBudgetOwner.value

	        }

	    }

	    function EOTypeOther() {
	        
	        for (var i = 0; i < document.NewEO.lbEOTypeDB.options.length; i++) {
	            if ('Other - Please specify below' == document.getElementById('lbEOTypeDB').options(i).text) {
	                if (!document.getElementById('lbEOTypeDB').options(i).selected) {
	                    document.NewEO.txtEOTypeOther.value = "";
	                }
	            }
	        }
	    }

	    function EOScopeOther() {
	        for (var i = 0; i < document.NewEO.drpEOScopeDB.options.length; i++) {
	            if ('Other - Please specify below' == document.getElementById('drpEOScopeDB').options(i).text) {
	                if (!document.getElementById('drpEOScopeDB').options(i).selected) {
	                    document.NewEO.txtEOScopeOther.value = "";
	                }
	            }
	        }
	    }


	    function PSRAOther() {
	        if (document.getElementById('divPSRARemoved').style.display != "none") {
	            for (var i = 0; i < document.NewEO.lbPSRADB.options.length; i++) {
	                if ('Other - Please specify below' == document.getElementById('lbPSRADB').options(i).text) {
	                    if (!document.getElementById('lbPSRADB').options(i).selected) {
	                        document.NewEO.txtPSRAOther.value = "";
	                    }
	                }
	            }
	        }
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

	    function isDate2(dtStr, ctrlName) {
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
	                    /*if  ((parseInt(strDay)>=parseInt(thetoday)  && strYear>=theyear) || (parseInt(strDay)<parseInt(thetoday)  && parseInt(strYear)>parseInt(theyear)))
	                    {
	                    //alert('day is greater');
	                    }*/
	                    if ((parseInt(strDay) >= parseInt(thetoday) && strYear >= theyear) || (parseInt(strMonth) > parseInt(themonth) && strYear >= theyear) || (parseInt(strDay) < parseInt(thetoday) && parseInt(strYear) > parseInt(theyear))) {
	                    }
	                    else {
	                        alert('Completion date should be greater than the current date');
	                        document.getElementById(ctrlName).focus();
	                        document.getElementById(ctrlName).value = "";
	                        return;
	                    }
	                }
	                else {
	                    alert('Completion date should be greater than the current date');
	                    document.getElementById(ctrlName).focus();
	                    document.getElementById(ctrlName).value = "";
	                    return;
	                }
	            }
	            else {
	                alert('Completion date should be greater than the current date');
	                document.getElementById(ctrlName).focus();
	                document.getElementById(ctrlName).value = "";
	                return;
	            }


	        }
	    }

	    function isDate1(dtStr, ctrlName) {
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
	                    /*if  ((parseInt(strDay)>=parseInt(thetoday)  && strYear>=theyear) || (parseInt(strDay)<parseInt(thetoday)  && parseInt(strYear)>parseInt(theyear)))
	                    {
	                    //alert('day is greater');
	                    }*/
	                    if ((parseInt(strDay) >= parseInt(thetoday) && strYear >= theyear) || (parseInt(strMonth) > parseInt(themonth) && strYear >= theyear) || (parseInt(strDay) < parseInt(thetoday) && parseInt(strYear) > parseInt(theyear))) {
	                    }
	                    else {
	                        alert('Planned start date should be greater than the current date');
	                        document.getElementById(ctrlName).focus();
	                        document.getElementById(ctrlName).value = "";
	                        return;
	                    }
	                }
	                else {
	                    alert('Planned start date should be greater than the current date');
	                    document.getElementById(ctrlName).focus();
	                    document.getElementById(ctrlName).value = "";
	                    return;
	                }
	            }
	            else {
	                alert('Planned start date should be greater than the current date');
	                document.getElementById(ctrlName).focus();
	                document.getElementById(ctrlName).value = "";
	                return;
	            }


	        }
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


	    function OpenCostSheetAttach() {
	        window.open('../Common/Templates/EO 0809 COST WORKSHEET_080408.xls');
	    }

	    function OpenGCASProcesstrainingAttach() {
	        window.open('../Common/Templates/New GCAS Process training.doc');
	    }

	    function openUMOFMasterBlankForm() {
	        window.open('../Common/Templates/UMOF Master Blank Form 03072006.xls');
	    }

	    function openFormulaCardTemplate() {
	        window.open('../Common/Templates/FC Exception Template r030722.xls');
	    }

	    function openFamilyCareHSE() {
	        window.open('http://bdc-intra614.internal.pg.com/GLOBAL/inet/Engineer/hse/people/people.nsf/Home?Openform');
	    }

	    function openTestPlanTemplate() {
	        window.open('../Common/Templates/EO Test Plan template 030703.doc');
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

	    function CountDecimals1(val, contrlName) {

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

	        var ValidChars = "0123456789.";
	        var Char;
	        var sText = val; //document.getElementById("TextBox1").value;

	        if (sText == ".") {
	            alert("Please enter decimal value.");
	            document.getElementById(contrlName).value = "";
	            document.getElementById(contrlName).focus();
	            return;
	        }

	        for (i = 0; i < sText.length; i++) {
	            Char = sText.charAt(i);
	            if (ValidChars.indexOf(Char) == -1) {
	                arguments.IsValid = false;
	                alert("Please enter decimal value.");
	                document.getElementById(contrlName).value = "";
	                document.getElementById(contrlName).focus();
	                return;
	            }
	        }

	    }

	    //for recaluculate 

	    function CountDecimals2(val, contrlName) {
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

	        var ValidChars = "0123456789.";
	        var Char;
	        var sText = val; //document.getElementById("TextBox1").value;

	        if (sText == ".") {
	            alert("Please enter decimal value.");
	            document.getElementById(contrlName).value = "";
	            document.getElementById(contrlName).focus();
	            return;
	        }

	        for (i = 0; i < sText.length; i++) {
	            Char = sText.charAt(i);
	            if (ValidChars.indexOf(Char) == -1) {
	                arguments.IsValid = false;
	                alert("Please enter decimal value.");
	                document.getElementById(contrlName).value = "";
	                document.getElementById(contrlName).focus();
	                return;
	            }
	        }
	        calTotalCost()
	    }

	    function calTotalCost() {

	        var sCostNewMaterials = document.getElementById('txtCostNewMaterials').value;
	        var sEOEquipment = document.getElementById('txtEOEquipment').value;
	        var sExecutionCost = document.getElementById('txtExecutionCost').value;

	        if (sCostNewMaterials == "") {
	            sCostNewMaterials = 0
	        }

	        if (sEOEquipment == "") {
	            sEOEquipment = 0
	        }

	        if (sExecutionCost == "") {
	            sExecutionCost = 0
	        }
           
            document.getElementById('lbPreSpending').value = parseFloat(sCostNewMaterials) + parseFloat(sEOEquipment);
            document.getElementById("hdnPreSpendingValue").value = parseFloat(sCostNewMaterials) + parseFloat(sEOEquipment);
	        document.getElementById('lbTotalCost').value = parseFloat(sCostNewMaterials) + parseFloat(sEOEquipment) + parseFloat(sExecutionCost);
	        document.getElementById("hdnTotalCostValue").value = parseFloat(sCostNewMaterials) + parseFloat(sEOEquipment) + parseFloat(sExecutionCost);
	    }

	    function confirmDelete() {
	        if (!confirm('Are you sure you want to delete?')) {
	            return false;
	        }
	        else {
	            return true;
	        }
	    }


	    function T() {
	        for (i = 0; i < Form1.length; i++) {
	            if (Form1.elements[i].type == "radio") {
	                if (Form1.elements[i].name == "rbRawMaterial" || Form1.elements[i].name == "rbParentRolls" || Form1.elements[i].name == "rbInterMaterials" || Form1.elements[i].name == "rbRegulatedProduct" || Form1.elements[i].name == "rbShipped" || Form1.elements[i].name == "rbTestProductedShipped" || Form1.elements[i].name == "rbGCASNumber") {
	                    if (Form1.elements[i].checked == true) {
	                        if (Form1.elements[i].value == "yes") {
	                            if (!confirm('Are you sure you want to delete?')) {
	                                return false;
	                            }
	                            else {
	                                return true;
	                            }
	                        }
	                    }
	                }
	            }
	        }
	    }

	    function RefreshPage() {
	        window.document.forms(0).submit();
	    }
	    function Concgrp() {
	        var popResult;
	        var plantId = document.getElementById('txtPlantID').value;
	        var EoID = document.getElementById('txtEOID').value;
	        popResult = window.open('SendForConcurrence.aspx?PlantID=' + plantId + '&From=EO&EoID=' + EoID, 'null', 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');
	        //document.getElementById('t1').value = popResult;
	    }
	    function AddPreScreners() {
//	        var popResult;
//	        var EoID = document.getElementById('txtEOID').value;
//	        popResult = window.open('SendForPreScreners.aspx?EoID=' + EoID, 'null', 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');
	        //document.getElementById('t1').value = popResult;

	        var popResult;
	        var plantId = document.getElementById('txtPlantID').value;
	        var EoID = document.getElementById('txtEOID').value;
	        popResult = window.open('SendForPreScreners.aspx?PlantID=' + plantId + '&From=EO&EoID=' + EoID, 'null', 'height=250,width=650,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes');
	    }

	    //'jagan code ending 
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

	    //Code by Vijay added on 09/21/07
	    function ShowIntermediate() // New Materials and Brand Section
	    {
	        alert('Materials that we(P&G) make and supply to ourself such as \n\n' + 'Finished product cores\n' + 'Sulfite pulp\n' + 'Perfume\n' + 'Lotion');
	    }

	    function ShowChemical() // HS&E Section		
	    {
	        alert('Some examples of changes include the following:\n  ' + '- concentration\n  ' + '- usage rate\n  ' + '- application(either different method or process area)\n  ' + '- vendor\n\n' +
		    'If you are unsure whether or not your project involves a chemical change, consult a HS&E resource.');
	    }

	    function ShowRawMaterial() // HS&E Section		
	    {
	        alert('Some examples of changes include the following:\n  ' + '- composition\n  ' + '- usage rate\n  ' + '- application\n  ' + '- vendor\n  ' +
		    '- packaging(additional or change in physical properties)\n\n' +
		    'If you are unsure whether or not your project involves a raw material change, consult a HS&E resource.');

	    }

	    function ShowEquipment() // HS&E Section		
	    {
	        alert('Some examples of changes include the following:\n  ' + '- modifications\n' + '  - upgrades  \n' + '  - speedups  \n' +
	'  - change outs  \n' + '  - removal  \n' + '  - relocation\n\n' +
	'If you are unsure whether or not your project involves an equipment/ process/ supporting system change, consult a HS&E resource.');
	    }

	    function ShowJobTask() // HS&E Section		
	    {
	        alert('Some examples of changes include the following:\n  ' + '- motions\n' + '  - frequency of job/task or motions\n' + '  - amount of time working on equipment\n' +
		    '  - exposure to a hazard(chemical,fire or health)\n' + '  - prodecures(incl.SOPs)\n' + '  - traffic patterns\n\n' +
	'If you are unsure whether or not your project involves an job/task change, consult a HS&E resource.');
	    }

	    function NavigateHere() // HS&E Section
	    {
	        location.href = 'http://intraprod1.internal.pg.com/technet/tech_dev/engineer/hse/T_thse/HSE_Change_Manage.htm';
	    }

	    function NavigateNotebookTraining()  // Packing & Disposition Section
	    {
	        location.href = 'http://intraprod1.internal.pg.com/technet/tech_dev/globreg/corp/lnb/pages/default.html';
	    }

	    function NavigateFormulaCard() //Formula Card Information Section
	    {
	        location.href = 'http://intraprod61.internal.pg.com/global/fam/gts/fcwebbase01.nsf/da7c90b2d2c90cf98525691b005e1980/eb93dc0730da7db185256cd90074ecf5?OpenDocument';
	    }
	    function viewComments(id) {
	        window.open("ViewComments.aspx?EOID=" + id, "winComments", "height=400,width=750,status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes,alwaysRaised=yes");
	        return false;
	    }

	    function PreRouteMandatory() {

	        var s;
	        if ((document.getElementById('drpCategoryDB').selectedIndex == 0) || (document.getElementById('drpCategoryDB').selectedIndex == -1)) {
	            s = "Please select Category.";

	        }
	        else
	        { s = "" }
	        if ((document.getElementById('drpEOProjectsDB').selectedIndex == 0) || (document.getElementById('drpEOProjectsDB').selectedIndex == -1)) {
	            if (s != "") {
	                s = s + '\n' + "Please select Project.";
	            }
	            else
	            { s = "Please select Project."; }
	        }
	        if ((document.getElementById('drpPlant').selectedIndex == 0) || (document.getElementById('drpPlant').selectedIndex == -1)) {
	            if (s != "")
	            { s = s + '\n' + "Please select Plant."; }
	            else
	            { s = "Please select Plant."; }
	        }

	        if (document.getElementById('lbEOEventsDB').options.length == 0) {
	            if (s != "")
	            { s = s + '\n' + "Please select Event(s)."; }
	            else
	            { s = "Please select Event(s)."; }
	        }

	        var i = 0;
	        if (document.getElementById('lbEOEventsDB').options.length != 0) {
	            for (len = 0; len < document.getElementById('lbEOEventsDB').options.length; len++) {
	                if (document.getElementById('lbEOEventsDB').options[len].selected)
	                    i++;
	            }
	            if (i > 0)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select Event(s)."; }
	                else
	                { s = "Please select Event(s)."; }
	            }
	        }



	        var frm = document.forms[0];
	        var rbrw = 0;
	       var intrbParentrolls = 0;
	        var rbInterMaterials = 0;
	        var rbRegulatedProduct = 0;
	        var chkGMPClassify = 0;
	        var rbShipped = 0;
	        var rbTestProductedShipped = 0;
	        var rbGCASNumber = 0;
	        var rbChemical = 0;
	        var rbNewRawMaterial = 0;
	        var rbNewEquipment = 0;
	        var rbNewJobTask = 0;
	        var rbPalletPattern = 0;
	        var rbBroke = 0;
	        var rbPrintedBroke = 0;
	        var rbInkCoverage = 0;


	        for (i = 0; i < frm.length; i++) {
	            if (frm.elements[i].type == "radio") {
	                if (frm.elements[i].name == "rbRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbrw == 0)))
	                        rbrw = 1;

	               if (frm.elements[i].name == "rbParentRolls")
	                    if (!((frm.elements[i].checked == false) && (intrbParentrolls == 0)))
	                        intrbParentrolls = 1; 

	                if (frm.elements[i].name == "rbInterMaterials")
	                    if (!((frm.elements[i].checked == false) && (rbInterMaterials == 0)))
	                        rbInterMaterials = 1;

	                if (frm.elements[i].name == "rbRegulatedProduct")
	                    if (!((frm.elements[i].checked == false) && (rbRegulatedProduct == 0)))
	                        rbRegulatedProduct = 1;

	                /*if (frm.elements[i].name == "rbGMPClassify") 
	                if (!((frm.elements[i].checked == false) && (rbGMPClassify == 0)))
	                rbGMPClassify = 1;*/

	                if (frm.elements[i].name == "rbShipped")
	                    if (!((frm.elements[i].checked == false) && (rbShipped == 0)))
	                        rbShipped = 1;

	                if (frm.elements[i].name == "rbTestProductedShipped")
	                    if (!((frm.elements[i].checked == false) && (rbTestProductedShipped == 0)))
	                        rbTestProductedShipped = 1;

	                if (frm.elements[i].name == "rbGCASNumber")
	                    if (!((frm.elements[i].checked == false) && (rbGCASNumber == 0)))
	                        rbGCASNumber = 1;

	                if (frm.elements[i].name == "rbChemical")
	                    if (!((frm.elements[i].checked == false) && (rbChemical == 0)))
	                        rbChemical = 1;


	                if (frm.elements[i].name == "rbNewRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbNewRawMaterial == 0)))
	                        rbNewRawMaterial = 1;


	                if (frm.elements[i].name == "rbNewEquipment")
	                    if (!((frm.elements[i].checked == false) && (rbNewEquipment == 0)))
	                        rbNewEquipment = 1;


	                if (frm.elements[i].name == "rbNewJobTask")
	                    if (!((frm.elements[i].checked == false) && (rbNewJobTask == 0)))
	                        rbNewJobTask = 1;


	                if (frm.elements[i].name == "rbPalletPattern")
	                    if (!((frm.elements[i].checked == false) && (rbPalletPattern == 0)))
	                        rbPalletPattern = 1;

	                if (frm.elements[i].name == "rbBroke")
	                    if (!((frm.elements[i].checked == false) && (rbBroke == 0)))
	                        rbBroke = 1;

	                if (frm.elements[i].name == "rbPrintedBroke")
	                    if (!((frm.elements[i].checked == false) && (rbPrintedBroke == 0)))
	                        rbPrintedBroke = 1;

	                /*if (frm.elements[i].name == "rbInkCoverage") 
	                if (!((frm.elements[i].checked == false) && (rbInkCoverage == 0)))
	                rbInkCoverage = 1;*/

	            }
	        }

	        if (rbrw == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Raw and/or Packing Materials."; }
	            else
	            { s = "Please select Raw and/or Packing Materials."; }

	       if (intrbParentrolls == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Will the EO produce Parent Rolls."; }
	            else
	            { s = "Please select Will the EO produce Parent Rolls."; } 

	        if (rbInterMaterials == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select any other Intermediate Materials."; }
	            else
	            { s = "Please select any other Intermediate Materials."; }
	        if (document.getElementById('divProdRegulatedProductQ1').style.display != "none") {
	            if (rbRegulatedProduct == 0)
	                if (s != "")
	                { s = s + '\n' + "Please select production of Regulated Product."; }
	                else
	                { s = "Please select production of Regulated Product."; }
	        }

	        /*if(document.getElementById('divProdRegulatedProductQ2').style.display!="none")		
	        {
	        if(rbGMPClassify == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select appropriate GMP Classification.";}
	        else
	        {s = "Please select appropriate GMP Classification.";}
	        }*/

	        if (rbShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  EO be shipped to the trade as a current brand."; }
	            else
	            { s = "Please select  EO be shipped to the trade as a current brand."; }

	        if (rbTestProductedShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select plant for consumer/lab evaluation."; }
	            else
	            { s = "Please select plant for consumer/lab evaluation."; }

	        if (rbGCASNumber == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  Contingent GCAS #s unique."; }
	            else
	            { s = "Please select  Contingent GCAS #s unique."; }

	        if (rbChemical == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new chemical or a change."; }
	            else
	            { s = "Please select new chemical or a change."; }


	        if (rbNewRawMaterial == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new raw material or a change."; }
	            else
	            { s = "Please select new raw material or a change."; }

	        if (rbNewEquipment == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new equipment/ process/ supporting systems or a change."; }
	            else
	            { s = "Please select new equipment/ process/ supporting systems or a change."; }

	        if (rbNewJobTask == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new job/task or a change."; }
	            else
	            { s = "Please select new job/task or a change."; }

	        if (rbPalletPattern == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select product using a unique pallet pattern."; }
	            else
	            { s = "Please select product using a unique pallet pattern."; }

	        if (rbBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select EO generate greater than normal broke."; }
	            else
	            { s = "Please select EO generate greater than normal broke."; }

	        if (rbPrintedBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select printed broke."; }
	            else
	            { s = "Please select printed broke."; }

	        /*if(rbInkCoverage == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select amount of ink coverage.";}
	        else
	        {s = "Please select amount of ink coverage.";}*/

	        if ((document.getElementById('drpPrelimApproval').selectedIndex == 0) || (document.getElementById('drpPrelimApproval').selectedIndex == -1)) {
	            if (s != "")
	            { s = s + '\n' + "Please select Approval Group."; }
	            else
	            { s = "Please select Approval Group."; }
	        }

	        if (document.getElementById('divPSRARemoved').style.display != "none") {
	            if ((document.getElementById('lbPSRADB').selectedIndex == 0) || (document.getElementById('lbPSRADB').selectedIndex == -1)) {
	                if (s != "")
	                { s = s + '\n' + "Please select PS&RA."; }
	                else
	                { s = "Please select PS&RA."; }
	            }
	        }

	        if (document.getElementById('txtBudgetOwner').value == "") {

	            if (s != "")
	            { s = s + '\n' + "Please select Budget Owner."; }
	            else
	            { s = "Please select Budget Owner."; }
	        }


	        if (document.getElementById('txtSiteContact').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site Contact."; }
	            else
	            { s = "Please select Site Contact."; }
	        }

	        if (document.getElementById('txtSiteHSE').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site HS&E Resource."; }
	            else
	            { s = "Please select Site HS&E Resource."; }
	        }

	        if (document.getElementById('txtSitePlanning').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site Planning."; }
	            else
	            { s = "Please select Site Planning."; }
	        }


	        if (document.getElementById('txtQAPre').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site QA."; }
	            else
	            { s = "Please select Site QA."; }
	        }
	        if (document.getElementById('txtCentralQAPre').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Central QA."; }
	            else
	            { s = "Please select Central QA."; }
	        }


	        if (document.getElementById('txtCentralPlanning').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Central Planning."; }
	            else
	            { s = "Please select Central Planning."; }
	        }

	        if (document.getElementById('txtTimingGate').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Timing Gate."; }
	            else
	            { s = "Please select Timing Gate."; }
	        }

	        if (document.getElementById('txtGBUHSE').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select GBU HS&E Resource."; }
	            else
	            { s = "Please select GBU HS&E Resource."; }
	        }

	        if (document.getElementById('txtStandardOffice').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Standard Office."; }
	            else
	            { s = "Please select Standard Office."; }
	        }

	        if (document.getElementById('txtAdditionalApp1').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver1."; }
	            else
	            { s = "Please select Additional Approver1."; }
	        }

	        if (document.getElementById('txtAdditionalApp2').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver2."; }
	            else
	            { s = "Please select Additional Approver2."; }
	        }

	        if (document.getElementById('txtAdditionalApp3').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver3."; }
	            else
	            { s = "Please select Additional Approver3."; }
	        }

	        if (document.getElementById('txtAdditionalApp4').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver4."; }
	            else
	            { s = "Please select Additional Approver4."; }
	        }

	        if (document.getElementById('txtSAPCost').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select SAP Cost."; }
	            else
	            { s = "Please select SAP Cost."; }
	        }
	        if (document.getElementById('divPSRARemoved').style.display != "none") {
	            if ((document.getElementById('lbPSRADB').selectedIndex == 0) || (document.getElementById('lbPSRADB').selectedIndex == -1)) {
	                if (s != "")
	                { s = s + '\n' + "Please select PS&RA."; }
	                else
	                { s = "Please select PS&RA."; }
	            }

	        }

	        if (document.getElementById('txtStartDate').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please enter Start Date."; }
	            else
	            { s = "Please Enter Start Date."; }
	        }

	        if (document.getElementById('drpBudgetCenterDB').options(0).selected)
	            if (s != "")
	            { s = s + '\n' + "Please select selected budget center."; }
	            else
	            { s = "Please select selected budget center."; }



	        if (s != "") {
	            alert(s);
	            document.getElementById('t11').value = 1;
	            var a = s.split(".");

	            if (a[0] == "Please select Category")
	                document.getElementById('drpCategoryDB').focus();
	            else if (a[0] == "Please select selected budget center")
	                document.getElementById('drpBudgetCenterDB').focus();
	            else if (a[0] == "Please select Project")
	                document.getElementById('drpEOProjectsDB').focus();
	            else if (a[0] == "Please select Plant")
	                document.getElementById('drpPlant').focus();
	            else if (a[0] == "Please enter EO title")
	                document.getElementById('txtTitle').focus();
	            else if (a[0] == "Please select Event(s)")
	                document.getElementById('lbEOEventsDB').focus();
	            else if (a[0] == "Please select Site QA")
                {
	                document.getElementById('txtQAPre').disabled = false;
	                document.getElementById('txtQAPre').focus();
	                document.getElementById('txtQAPre').disabled = true;
	            }
	            else if (a[0] == "Please select Central QA")
                {
	                document.getElementById('txtCentralQAPre').disabled = false;
	                document.getElementById('txtCentralQAPre').focus();
	                document.getElementById('txtCentralQAPre').disabled = true;
	            }
	            else if (a[0] == "Please select PS&RA")
	                document.getElementById('lbPSRADB').focus();
	            else if (a[0] == "Please select Budget Owner")
                {
	                document.getElementById('txtBudgetOwner').disabled = false;
	                document.getElementById('txtBudgetOwner').focus();
	                document.getElementById('txtBudgetOwner').disabled = true;
	            }
	            else if (a[0] == "Please select Site Contact")
                {
	                document.getElementById('txtSiteContact').disabled = false;
	                document.getElementById('txtSiteContact').focus();
	                document.getElementById('txtSiteContact').disabled = true;
	            }
	            else if (a[0] == "Please select Site HS&E Resource")
                {
	                document.getElementById('txtSiteHSE').disabled = false;
	                document.getElementById('txtSiteHSE').focus();
	                document.getElementById('txtSiteHSE').disabled = true;
	            }
	            else if (a[0] == "Please select Site Planning")
                {
	                document.getElementById('txtSitePlanning').disabled = false;
	                document.getElementById('txtSitePlanning').focus();
	                document.getElementById('txtSitePlanning').disabled = true;
	            }
	            else if (a[0] == "Please select Central Planning")
                {
	                document.getElementById('txtCentralPlanning').disabled = false;
	                document.getElementById('txtCentralPlanning').focus();
	                document.getElementById('txtCentralPlanning').disabled = true;
	            }
	            else if (a[0] == "Please select Timing Gate")
                {
	                document.getElementById('txtTimingGate').disabled = false;
	                document.getElementById('txtTimingGate').focus();
	                document.getElementById('txtTimingGate').disabled = true;
	            }
	            else if (a[0] == "Please select Standard Office")
                {
	                document.getElementById('txtStandardOffice').disabled = false;
	                document.getElementById('txtStandardOffice').focus();
	                document.getElementById('txtStandardOffice').disabled = true;
	            }
	            else if (a[0] == "Please select GBU HS&E Resource")
                {
	                document.getElementById('txtGBUHSE').disabled = false;
	                document.getElementById('txtGBUHSE').focus();
	                document.getElementById('txtGBUHSE').disabled = true;
	            }
	            else if (a[0] == "Please select SAP Cost")
                {
	                document.getElementById('txtSAPCost').disabled = false;
	                document.getElementById('txtSAPCost').focus();
	                document.getElementById('txtSAPCost').disabled = true;
	            }
	            else if (a[0] == "Please select Additional Approver1")
                {
	                document.getElementById('txtAdditionalApp1').disabled = false;
	                document.getElementById('txtAdditionalApp1').focus();
	                document.getElementById('txtAdditionalApp1').disabled = true;
	            }
	            else if (a[0] == "Please select Additional Approver2")
                {
	                document.getElementById('txtAdditionalApp2').disabled = false;
	                document.getElementById('txtAdditionalApp2').focus();
	                document.getElementById('txtAdditionalApp2').disabled = true;
	            }
	            else if (a[0] == "Please select Additional Approver3")
                {
	                document.getElementById('txtAdditionalApp3').disabled = false;
	                document.getElementById('txtAdditionalApp3').focus();
	                document.getElementById('txtAdditionalApp3').disabled = true;
	            }
	            else if (a[0] == "Please select Additional Approver4")
                {
	                document.getElementById('txtAdditionalApp4').disabled = false;
	                document.getElementById('txtAdditionalApp4').focus();
	                document.getElementById('txtAdditionalApp4').disabled = true;
	            }
	            else if (a[0] == "Please enter Start Date")
	                document.getElementById('txtHidDateFocus').focus();
	            else if (a[0] == "Please select Raw and/or Packing Materials")
	                document.getElementById('rbRawMaterial').focus();
	            else if (a[0] == "Please select Will the EO produce Parent Rolls")
	                document.getElementById('rbParentRolls').focus(); 
	            else if (a[0] == "Please select any other Intermediate Materials")
	                document.getElementById('rbInterMaterials').focus();
	            else if (a[0] == "Please select production of Regulated Product")
	                document.getElementById('rbRegulatedProduct').focus();
	            /*else if (a[0]=="Please select appropriate GMP Classification")
	            document.getElementById('rbGMPClassify').focus();*/

	            else if (a[0] == "Please select  EO be shipped to the trade as a current brand")
	                document.getElementById('rbShipped').focus();

	            else if (a[0] == "Please select plant for consumer/lab evaluation")
	                document.getElementById('rbTestProductedShipped').focus();

	            else if (a[0] == "Please select  Contingent GCAS #s unique")
	                document.getElementById('rbGCASNumber').focus();

	            else if (a[0] == "Please select new chemical or a change")
	                document.getElementById('rbChemical').focus();

	            else if (a[0] == "Please select new raw material or a change")
	                document.getElementById('rbNewRawMaterial').focus();

	            else if (a[0] == "Please select new equipment/ process/ supporting systems or a change")
	                document.getElementById('rbNewEquipment').focus();

	            else if (a[0] == "Please select new job/task or a change")
	                document.getElementById('rbNewJobTask').focus();

	            else if (a[0] == "Please select product using a unique pallet pattern")
	                document.getElementById('rbPalletPattern').focus();

	            else if (a[0] == "Please select EO generate greater than normal broke")
	                document.getElementById('rbBroke').focus();

	            else if (a[0] == "Please select printed broke")
	                document.getElementById('rbPrintedBroke').focus();

	            else if (a[0] == "Please select amount of ink coverage")
	                document.getElementById('rbInkCoverage').focus();
	        }
	        else {

	            document.getElementById('t11').value = "";
	        }
	    }


	    //Added for PCR
	    function PreRouteMandatoryPCR() {



	        var s;
	        if ((document.getElementById('drpCategoryDB').selectedIndex == 0) || (document.getElementById('drpCategoryDB').selectedIndex == -1)) {
	            s = "Please select Category.";
	        }
	        else
	        { s = "" }
	        if ((document.getElementById('drpEOProjectsDB').selectedIndex == 0) || (document.getElementById('drpEOProjectsDB').selectedIndex == -1)) {
	            if (s != "") {
	                s = s + '\n' + "Please select Project.";
	            }
	            else
	            { s = "Please select Project."; }
	        }
	        if ((document.getElementById('drpPlant').selectedIndex == 0) || (document.getElementById('drpPlant').selectedIndex == -1)) {
	            if (s != "")
	            { s = s + '\n' + "Please select Plant."; }
	            else
	            { s = "Please select Plant."; }
	        }

	        if (document.getElementById('lbEOEventsDB').options.length == 0) {
	            if (s != "")
	            { s = s + '\n' + "Please select Event(s)."; }
	            else
	            { s = "Please select Event(s)."; }
	        }

	        var i = 0;
	        if (document.getElementById('lbEOEventsDB').options.length != 0) {
	            for (len = 0; len < document.getElementById('lbEOEventsDB').options.length; len++) {
	                if (document.getElementById('lbEOEventsDB').options[len].selected)
	                    i++;
	            }
	            if (i > 0)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select Event(s)."; }
	                else
	                { s = "Please select Event(s)."; }
	            }
	        }

	   

	        var frm = document.forms[0];
	        var rbrw = 0;
	        var intrbParentrolls = 0;
	        var rbInterMaterials = 0;
	        var rbRegulatedProduct = 0;
	        var chkGMPClassify = 0;
	        var rbShipped = 0;
	        var rbTestProductedShipped = 0;
	        var rbGCASNumber = 0;
	        var rbChemical = 0;
	        var rbNewRawMaterial = 0;
	        var rbNewEquipment = 0;
	        var rbNewJobTask = 0;

	        //Added for MUREO PCRs
	        var rblProductConsumers = 0;
	        var rblProductApproved = 0;

	        var rbPalletPattern = 0;
	        var rbBroke = 0;
	        var rbPrintedBroke = 0;
	        var rbInkCoverage = 0;


	        for (i = 0; i < frm.length; i++) {
	            if (frm.elements[i].type == "radio") {
	                if (frm.elements[i].name == "rbRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbrw == 0)))
	                        rbrw = 1;

	                if (frm.elements[i].name == "rbParentRolls")
	                    if (!((frm.elements[i].checked == false) && (intrbParentrolls == 0)))
	                        intrbParentrolls = 1;

	                if (frm.elements[i].name == "rbInterMaterials")
	                    if (!((frm.elements[i].checked == false) && (rbInterMaterials == 0)))
	                        rbInterMaterials = 1;

	                if (frm.elements[i].name == "rbRegulatedProduct")
	                    if (!((frm.elements[i].checked == false) && (rbRegulatedProduct == 0)))
	                        rbRegulatedProduct = 1;

	                /*	if (frm.elements[i].name == "rbGMPClassify") 
	                if (!((frm.elements[i].checked == false) && (rbGMPClassify == 0)))
	                rbGMPClassify = 1;*/

	                if (frm.elements[i].name == "rbShipped")
	                    if (!((frm.elements[i].checked == false) && (rbShipped == 0)))
	                        rbShipped = 1;

	                if (frm.elements[i].name == "rbTestProductedShipped")
	                    if (!((frm.elements[i].checked == false) && (rbTestProductedShipped == 0)))
	                        rbTestProductedShipped = 1;

	                if (frm.elements[i].name == "rbGCASNumber")
	                    if (!((frm.elements[i].checked == false) && (rbGCASNumber == 0)))
	                        rbGCASNumber = 1;

	                if (frm.elements[i].name == "rbChemical")
	                    if (!((frm.elements[i].checked == false) && (rbChemical == 0)))
	                        rbChemical = 1;


	                if (frm.elements[i].name == "rbNewRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbNewRawMaterial == 0)))
	                        rbNewRawMaterial = 1;


	                if (frm.elements[i].name == "rbNewEquipment")
	                    if (!((frm.elements[i].checked == false) && (rbNewEquipment == 0)))
	                        rbNewEquipment = 1;


	                if (frm.elements[i].name == "rbNewJobTask")
	                    if (!((frm.elements[i].checked == false) && (rbNewJobTask == 0)))
	                        rbNewJobTask = 1;

	                /* Added for MUREO PCRs */

	                if (frm.elements[i].name == "rblProductConsumers")
	                    if (!((frm.elements[i].checked == false) && (rblProductConsumers == 0)))
	                        rblProductConsumers = 1;

	                if (frm.elements[i].name == "rblProductApproved")
	                    if (!((frm.elements[i].checked == false) && (rblProductApproved == 0)))
	                        rblProductApproved = 1;

	                if (frm.elements[i].name == "rbPalletPattern")
	                    if (!((frm.elements[i].checked == false) && (rbPalletPattern == 0)))
	                        rbPalletPattern = 1;

	                if (frm.elements[i].name == "rbBroke")
	                    if (!((frm.elements[i].checked == false) && (rbBroke == 0)))
	                        rbBroke = 1;

	                if (frm.elements[i].name == "rbPrintedBroke")
	                    if (!((frm.elements[i].checked == false) && (rbPrintedBroke == 0)))
	                        rbPrintedBroke = 1;

	                /*if (frm.elements[i].name == "rbInkCoverage") 
	                if (!((frm.elements[i].checked == false) && (rbInkCoverage == 0)))
	                rbInkCoverage = 1;*/

	            }
	        }



	        if (rbrw == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Raw and/or Packing Materials."; }
	            else
	            { s = "Please select Raw and/or Packing Materials."; }

	        if (intrbParentrolls == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Will the EO produce Parent Rolls."; }
	            else
	            { s = "Please select Will the EO produce Parent Rolls."; } 

	        if (rbInterMaterials == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select any other Intermediate Materials."; }
	            else
	            { s = "Please select any other Intermediate Materials."; }

	        if (rbRegulatedProduct == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select production of Regulated Product."; }
	            else
	            { s = "Please select production of Regulated Product."; }

	        /*if(rbGMPClassify == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select appropriate GMP Classification.";}
	        else
	        {s = "Please select appropriate GMP Classification.";}*/



	        if (rbShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  EO be shipped to the trade as a current brand."; }
	            else
	            { s = "Please select  EO be shipped to the trade as a current brand."; }

	        var result = "False";
	        objInputs = document.getElementById("chkMaterialsBrands").getElementsByTagName("INPUT");

	        for (i = 0; i < objInputs.length; i++) {
	            if (objInputs[i].type == "checkbox") {
	                if (objInputs[i].checked) {
	                    result = "true";


	                }
	            }

	        }

	        if (result == "False") {
	            if (s != "")
	            { s = s + '\n' + "Please select New Materials and Brands."; }
	            else
	            { s = "Please select New Materials and Brands."; }

	        }


	        if (rbTestProductedShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select plant for consumer/lab evaluation."; }
	            else
	            { s = "Please select plant for consumer/lab evaluation."; }

	        if (rbGCASNumber == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  Contingent GCAS #s unique."; }
	            else
	            { s = "Please select  Contingent GCAS #s unique."; }

	        if (rbChemical == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new chemical or a change."; }
	            else
	            { s = "Please select new chemical or a change."; }


	        if (rbNewRawMaterial == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new raw material or a change."; }
	            else
	            { s = "Please select new raw material or a change."; }

	        if (rbNewEquipment == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new equipment/ process/ supporting systems or a change."; }
	            else
	            { s = "Please select new equipment/ process/ supporting systems or a change."; }

	        if (rbNewJobTask == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new job/task or a change."; }
	            else
	            { s = "Please select new job/task or a change."; }


	        /* Added for MUREO PCRs */



	        if (rblProductConsumers == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select if Product goes to consumers."; }
	            else
	            { s = "Please select if Product goes to consumers."; }


	        if (rblProductApproved == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select if you are using an approved FC or ATS."; }
	            else
	            { s = "Please select if you are using an approved FC or ATS."; }

	        var OptionProdApprovedNo = document.getElementById("rblProductApproved_1").checked;

	        var OptionProdConsumerYes = document.getElementById("rblProductConsumers_0").checked;

	        if (OptionProdConsumerYes && OptionProdApprovedNo) {

	            if (document.getElementById("rblRawMaterialsQ1_0").checked || document.getElementById("rblRawMaterialsQ1_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved at the appropriate level (1-5)."; }
	                else
	                { s = "Please select if Raw Materials approved at the appropriate level (1-5)."; }
	            }

	            if (document.getElementById("rblRawMaterialsQ2_0").checked || document.getElementById("rblRawMaterialsQ2_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved for the appropriate region (NA, Mexico)."; }
	                else
	                { s = "Please select if Raw Materials approved for the appropriate region (NA, Mexico)."; }
	            }
	            if (document.getElementById("rblRawMaterialsQ3_0").checked || document.getElementById("rblRawMaterialsQ3_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved for the application (tissue, towel)."; }
	                else
	                { s = "Please select if Raw Materials approved for the application (tissue, towel)."; }
	            }
	            if (document.getElementById("rblRawMaterialsQ4_0").checked || document.getElementById("rblRawMaterialsQ4_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved at the previously approved application rate."; }
	                else
	                { s = "Please select if Raw Materials approved at the previously approved application rate."; }
	            }

	        }


	        if (rbPalletPattern == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select product using a unique pallet pattern."; }
	            else
	            { s = "Please select product using a unique pallet pattern."; }

	        if (rbBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select EO generate greater than normal broke."; }
	            else
	            { s = "Please select EO generate greater than normal broke."; }

	        if (rbPrintedBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select printed broke."; }
	            else
	            { s = "Please select printed broke."; }

	        /*if(rbInkCoverage == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select amount of ink coverage.";}
	        else
	        {s = "Please select amount of ink coverage.";}*/

	        if ((document.getElementById('drpPrelimApproval').selectedIndex == 0) || (document.getElementById('drpPrelimApproval').selectedIndex == -1)) {
	            if (s != "")
	            { s = s + '\n' + "Please select Approval Group."; }
	            else
	            { s = "Please select Approval Group."; }
	        }

	        /* if ((document.getElementById('lbPSRADB').selectedIndex==0)||(document.getElementById('lbPSRADB').selectedIndex==-1))
	        {
	        if (s!="") 
	        {s = s + '\n' + "Please select PS&RA.";}
	        else
	        {s ="Please select PS&RA.";}
	        } */
	        if (document.getElementById('txtBudgetOwner').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Budget Owner."; }
	            else
	            { s = "Please select Budget Owner."; }
	        }


	        if (document.getElementById('txtSiteContact').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site Contact."; }
	            else
	            { s = "Please select Site Contact."; }
	        }

	        if (document.getElementById('txtSiteHSE').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site HS&E Resource."; }
	            else
	            { s = "Please select Site HS&E Resource."; }
	        }

	        if (document.getElementById('txtSitePlanning').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site Planning."; }
	            else
	            { s = "Please select Site Planning."; }
	        }


	        if (document.getElementById('txtQAPre').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Site QA."; }
	            else
	            { s = "Please select Site QA."; }
	        }
	        if (document.getElementById('txtCentralQAPre').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Central QA."; }
	            else
	            { s = "Please select Central QA."; }
	        }


	        if (document.getElementById('txtCentralPlanning').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Central Planning."; }
	            else
	            { s = "Please select Central Planning."; }
	        }

	        if (document.getElementById('txtTimingGate').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Timing Gate."; }
	            else
	            { s = "Please select Timing Gate."; }
	        }

	        if (document.getElementById('txtGBUHSE').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select GBU HS&E Resource."; }
	            else
	            { s = "Please select GBU HS&E Resource."; }
	        }

	        if (document.getElementById('txtStandardOffice').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Standard Office."; }
	            else
	            { s = "Please select Standard Office."; }
	        }

	        if (document.getElementById('txtAdditionalApp1').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver1."; }
	            else
	            { s = "Please select Additional Approver1."; }
	        }

	        if (document.getElementById('txtAdditionalApp2').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver2."; }
	            else
	            { s = "Please select Additional Approver2."; }
	        }


	        if (document.getElementById('txtAdditionalApp3').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver3."; }
	            else
	            { s = "Please select Additional Approver3."; }
	        }


	        if (document.getElementById('txtAdditionalApp4').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select Additional Approver4."; }
	            else
	            { s = "Please select Additional Approver4."; }
	        }

	        if (document.getElementById('txtSAPCost').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please select SAP Cost."; }
	            else
	            { s = "Please select SAP Cost."; }
	        }

	        if (document.getElementById('txtStartDate').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please enter Start Date."; }
	            else
	            { s = "Please Enter Start Date."; }
	        }

	        if (document.getElementById('drpBudgetCenterDB').options(0).selected)
	            if (s != "")
	            { s = s + '\n' + "Please select selected budget center."; }
	            else
	            { s = "Please select selected budget center."; }
	        if (s != "") {
	            alert(s);
	            document.getElementById('t11').value = 1;
	            var a = s.split(".");
	            if (a[0] == "Please select Category")
	                document.getElementById('drpCategoryDB').focus();
	            else if (a[0] == "Please select selected budget center")
	                document.getElementById('drpBudgetCenterDB').focus();
	            else if (a[0] == "Please select Project")
	                document.getElementById('drpEOProjectsDB').focus();
	            else if (a[0] == "Please select Plant")
	                document.getElementById('drpPlant').focus();
	            else if (a[0] == "Please enter EO title")
	                document.getElementById('txtTitle').focus();
	            else if (a[0] == "Please select Event(s)")
	                document.getElementById('lbEOEventsDB').focus();
	            else if (a[0] == "Please select Site QA")
                {
	                document.getElementById('txtQAPre').disabled = false;
	                document.getElementById('txtQAPre').focus();
	                document.getElementById('txtQAPre').disabled = true;
	            }
	            else if (a[0] == "Please select Central QA")
                {
	                document.getElementById('txtCentralQAPre').disabled = false;
	                document.getElementById('txtCentralQAPre').focus();
	                document.getElementById('txtCentralQAPre').disabled = true;
	            }
	            /*else if (a[0]=="Please select PS&RA")
	            document.getElementById('lbPSRADB').focus(); */
	            else if (a[0] == "Please select Budget Owner")
                {
	                document.getElementById('txtBudgetOwner').disabled = false;
	                document.getElementById('txtBudgetOwner').focus();
	                document.getElementById('txtBudgetOwner').disabled = true;
	            }
	            else if (a[0] == "Please select Site Contact") {
	                document.getElementById('txtSiteContact').disabled = false;
	                document.getElementById('txtSiteContact').focus();
	                document.getElementById('txtSiteContact').disabled = true;
	            }
	            else if (a[0] == "Please select Site HS&E Resource") {
	                document.getElementById('txtSiteHSE').disabled = false;
	                document.getElementById('txtSiteHSE').focus();
	                document.getElementById('txtSiteHSE').disabled = true;
	            }
	            else if (a[0] == "Please select Site Planning") 
                {
	                document.getElementById('txtSitePlanning').disabled = false;
	                document.getElementById('txtSitePlanning').focus();
	                document.getElementById('txtSitePlanning').disabled = true;
	            }
	            else if (a[0] == "Please select Central Planning")
                 {
                    document.getElementById('txtCentralPlanning').disabled = false;
	                document.getElementById('txtCentralPlanning').focus();
	                document.getElementById('txtCentralPlanning').disabled = true;
                 }
	            else if (a[0] == "Please select Timing Gate")
                 {
                    document.getElementById('txtTimingGate').disabled = false;
	                document.getElementById('txtTimingGate').focus();
	                document.getElementById('txtTimingGate').disabled = true;
                 }
	            else if (a[0] == "Please select Standard Office")
                 {
                    document.getElementById('txtStandardOffice').disabled = false;
	                document.getElementById('txtStandardOffice').focus();
	                document.getElementById('txtStandardOffice').disabled = true;
                 }
	            else if (a[0] == "Please select GBU HS&E Resource")
                {
                    document.getElementById('txtGBUHSE').disabled = false;
	                document.getElementById('txtGBUHSE').focus();
	                document.getElementById('txtGBUHSE').disabled = true;
                 }
	            else if (a[0] == "Please select SAP Cost")
                {
                    document.getElementById('txtSAPCost').disabled = false;
	                document.getElementById('txtSAPCost').focus();
	                document.getElementById('txtSAPCost').disabled = true;
                 }
	            else if (a[0] == "Please select Additional Approver1")
                 {
                    document.getElementById('txtAdditionalApp1').disabled = false;
	                document.getElementById('txtAdditionalApp1').focus();
	                document.getElementById('txtAdditionalApp1').disabled = true;
                 }
	            else if (a[0] == "Please select Additional Approver2")
                 {
                    document.getElementById('txtAdditionalApp2').disabled = false;
	                document.getElementById('txtAdditionalApp2').focus();
	                document.getElementById('txtAdditionalApp2').disabled = true;
                 }
	            else if (a[0] == "Please select Additional Approver3")
                 {
                    document.getElementById('txtAdditionalApp3').disabled = false;
	                document.getElementById('txtAdditionalApp3').focus();
	                document.getElementById('txtAdditionalApp3').disabled = true;
                 }
	            else if (a[0] == "Please select Additional Approver4")
                 {
                    document.getElementById('txtAdditionalApp4').disabled = false;
	                document.getElementById('txtAdditionalApp4').focus();
	                document.getElementById('txtAdditionalApp4').disabled = true;
                 }
	            else if (a[0] == "Please enter Start Date")
	                document.getElementById('txtHidDateFocus').focus();
	            else if (a[0] == "Please select Raw and/or Packing Materials")
	                document.getElementById('rbRawMaterial').focus();
	            else if (a[0] == "Please select Will the EO produce Parent Rolls")
	                document.getElementById('rbParentRolls').focus();
	            else if (a[0] == "Please select any other Intermediate Materials") {
	                document.getElementById('rbInterMaterials').focus();
	            }

	            else if (a[0] == "Please select New Materials and Brands")
	                document.getElementById("chkMaterialsBrands").focus();

	            else if (a[0] == "Please select plant for consumer/lab evaluation")
	                document.getElementById('rbTestProductedShipped').focus();

	            else if (a[0] == "Please select  Contingent GCAS #s unique")
	                document.getElementById('rbGCASNumber').focus();

	            else if (a[0] == "Please select new chemical or a change")
	                document.getElementById('rbChemical').focus();

	            else if (a[0] == "Please select new raw material or a change")
	                document.getElementById('rbNewRawMaterial').focus();

	            else if (a[0] == "Please select new equipment/ process/ supporting systems or a change")
	                document.getElementById('rbNewEquipment').focus();

	            else if (a[0] == "Please select new job/task or a change")
	                document.getElementById('rbNewJobTask').focus();

	            /* Added for MUREO PCRS */

	            else if (a[0] == "Please select if Product goes to consumers")
	                document.getElementById('rblProductConsumers').focus();

	            else if (a[0] == "Please select if you are using an approved FC or ATS")
	                document.getElementById('rblProductApproved').focus();

	            else if (a[0] == "Please select if Raw Materials approved at the appropriate level (1-5)")
	                document.getElementById('rblRawMaterialsQ1').focus();


	            else if (a[0] == "Please select if Raw Materials approved for the appropriate region (NA, Mexico)")
	                document.getElementById('rblRawMaterialsQ2').focus();


	            else if (a[0] == "Please select if Raw Materials approved for the application (tissue, towel)")
	                document.getElementById('rblRawMaterialsQ3').focus();


	            else if (a[0] == "Please select if Raw Materials approved at the previously approved application rate")
	                document.getElementById('rblRawMaterialsQ4').focus();


	            else if (a[0] == "Please select product using a unique pallet pattern")
	                document.getElementById('rbPalletPattern').focus();

	            else if (a[0] == "Please select EO generate greater than normal broke")
	                document.getElementById('rbBroke').focus();

	            else if (a[0] == "Please select printed broke")
	                document.getElementById('rbPrintedBroke').focus();

	            else if (a[0] == "Please select amount of ink coverage")
	                document.getElementById('rbInkCoverage').focus();
	        }
	        else {

	            document.getElementById('t11').value = "";
	        }


	    }

	    //for 2 tab route
	    function TwotabRouteMandatory() {
	        var s;
	        if ((document.getElementById('drpCategoryDB').selectedIndex == 0) || (document.getElementById('drpCategoryDB').selectedIndex == -1)) {
	            s = "Please select Category.";
	        }
	        else
	        { s = "" }
	        if ((document.getElementById('drpEOProjectsDB').selectedIndex == 0) || (document.getElementById('drpEOProjectsDB').selectedIndex == -1)) {
	            if (s != "") {
	                s = s + '\n' + "Please select Project.";
	            }
	            else
	            { s = "Please select Project."; }
	        }
	        if ((document.getElementById('drpPlant').selectedIndex == 0) || (document.getElementById('drpPlant').selectedIndex == -1)) {
	            if (s != "")
	            { s = s + '\n' + "Please select Plant."; }
	            else
	            { s = "Please select Plant."; }
	        }

	        if (document.getElementById('lbEOEventsDB').options.length == 0) {
	            if (s != "")
	            { s = s + '\n' + "Please select Event(s)."; }
	            else
	            { s = "Please select Event(s)."; }
	        }

	        var i = 0;
	        if (document.getElementById('lbEOEventsDB').options.length != 0) {
	            for (len = 0; len < document.getElementById('lbEOEventsDB').options.length; len++) {
	                if (document.getElementById('lbEOEventsDB').options[len].selected)
	                    i++;
	            }
	            if (i > 0)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select Event(s)."; }
	                else
	                { s = "Please select Event(s)."; }
	            }
	        }
	        var frm = document.forms[0];
	        var rbrw = 0;
	       var intrbParentrolls = 0;
	        var rbInterMaterials = 0;
	        var rbRegulatedProduct = 0;
	        var chkGMPClassify = 0;
	        var rbShipped = 0;
	        var rbTestProductedShipped = 0;
	        var rbGCASNumber = 0;
	        var rbChemical = 0;
	        var rbNewRawMaterial = 0;
	        var rbNewEquipment = 0;
	        var rbNewJobTask = 0;
	        var rbPalletPattern = 0;
	        var rbBroke = 0;
	        var rbPrintedBroke = 0;
	        var rbInkCoverage = 0;


	        for (i = 0; i < frm.length; i++) {
	            if (frm.elements[i].type == "radio") {
	                if (frm.elements[i].name == "rbRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbrw == 0)))
	                        rbrw = 1;

	                if (frm.elements[i].name == "rbParentRolls")
	                    if (!((frm.elements[i].checked == false) && (intrbParentrolls == 0)))
	                        intrbParentrolls = 1; 

	                if (frm.elements[i].name == "rbInterMaterials")
	                    if (!((frm.elements[i].checked == false) && (rbInterMaterials == 0)))
	                        rbInterMaterials = 1;

	                if (frm.elements[i].name == "rbRegulatedProduct")
	                    if (!((frm.elements[i].checked == false) && (rbRegulatedProduct == 0)))
	                        rbRegulatedProduct = 1;

	                /*if (frm.elements[i].name == "rbGMPClassify") 
	                if (!((frm.elements[i].checked == false) && (rbGMPClassify == 0)))
	                rbGMPClassify = 1;*/

	                if (frm.elements[i].name == "rbShipped")
	                    if (!((frm.elements[i].checked == false) && (rbShipped == 0)))
	                        rbShipped = 1;

	                if (frm.elements[i].name == "rbTestProductedShipped")
	                    if (!((frm.elements[i].checked == false) && (rbTestProductedShipped == 0)))
	                        rbTestProductedShipped = 1;

	                if (frm.elements[i].name == "rbGCASNumber")
	                    if (!((frm.elements[i].checked == false) && (rbGCASNumber == 0)))
	                        rbGCASNumber = 1;

	                if (frm.elements[i].name == "rbChemical")
	                    if (!((frm.elements[i].checked == false) && (rbChemical == 0)))
	                        rbChemical = 1;


	                if (frm.elements[i].name == "rbNewRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbNewRawMaterial == 0)))
	                        rbNewRawMaterial = 1;


	                if (frm.elements[i].name == "rbNewEquipment")
	                    if (!((frm.elements[i].checked == false) && (rbNewEquipment == 0)))
	                        rbNewEquipment = 1;


	                if (frm.elements[i].name == "rbNewJobTask")
	                    if (!((frm.elements[i].checked == false) && (rbNewJobTask == 0)))
	                        rbNewJobTask = 1;


	                if (frm.elements[i].name == "rbPalletPattern")
	                    if (!((frm.elements[i].checked == false) && (rbPalletPattern == 0)))
	                        rbPalletPattern = 1;

	                if (frm.elements[i].name == "rbBroke")
	                    if (!((frm.elements[i].checked == false) && (rbBroke == 0)))
	                        rbBroke = 1;

	                if (frm.elements[i].name == "rbPrintedBroke")
	                    if (!((frm.elements[i].checked == false) && (rbPrintedBroke == 0)))
	                        rbPrintedBroke = 1;

	                /*if (frm.elements[i].name == "rbInkCoverage") 
	                if (!((frm.elements[i].checked == false) && (rbInkCoverage == 0)))
	                rbInkCoverage = 1;*/

	            }
	        }
	        if (rbrw == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Raw and/or Packing Materials."; }
	            else
	            { s = "Please select Raw and/or Packing Materials."; }

	        if (intrbParentrolls == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Will the EO produce Parent Rolls."; }
	            else
	            { s = "Please select Will the EO produce Parent Rolls."; } 


	        if (rbInterMaterials == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select any other Intermediate Materials."; }
	            else
	            { s = "Please select any other Intermediate Materials."; }

	        if (rbRegulatedProduct == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select production of Regulated Product."; }
	            else
	            { s = "Please select production of Regulated Product."; }

	        /*if(rbGMPClassify == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select appropriate GMP Classification.";}
	        else
	        {s = "Please select appropriate GMP Classification.";}*/

	        if (rbShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  EO be shipped to the trade as a current brand."; }
	            else
	            { s = "Please select  EO be shipped to the trade as a current brand."; }

	        if (rbTestProductedShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select plant for consumer/lab evaluation."; }
	            else
	            { s = "Please select plant for consumer/lab evaluation."; }

	        if (rbGCASNumber == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  Contingent GCAS #s unique."; }
	            else
	            { s = "Please select  Contingent GCAS #s unique."; }

	        if (rbChemical == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new chemical or a change."; }
	            else
	            { s = "Please select new chemical or a change."; }


	        if (rbNewRawMaterial == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new raw material or a change."; }
	            else
	            { s = "Please select new raw material or a change."; }

	        if (rbNewEquipment == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new equipment/ process/ supporting systems or a change."; }
	            else
	            { s = "Please select new equipment/ process/ supporting systems or a change."; }

	        if (rbNewJobTask == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new job/task or a change."; }
	            else
	            { s = "Please select new job/task or a change."; }

	        if (rbPalletPattern == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select product using a unique pallet pattern."; }
	            else
	            { s = "Please select product using a unique pallet pattern."; }

	        if (rbBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select EO generate greater than normal broke."; }
	            else
	            { s = "Please select EO generate greater than normal broke."; }

	        if (rbPrintedBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select printed broke."; }
	            else
	            { s = "Please select printed broke."; }

	        /*if(rbInkCoverage == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select amount of ink coverage.";}
	        else
	        {s = "Please select amount of ink coverage.";}*/




	        if (document.getElementById('txtStartDate').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please enter Start Date."; }
	            else
	            { s = "Please Enter Start Date."; }
	        }


	        if (document.getElementById('drpBudgetCenterDB').options(0).selected)
	            if (s != "")
	            { s = s + '\n' + "Please select selected budget center."; }
	            else
	            { s = "Please select selected budget center."; }


	        if (s != "") {
	            alert(s);
	            document.getElementById('t11').value = 1;
	            var a = s.split(".");
	            if (a[0] == "Please select Category")
	                document.getElementById('drpCategoryDB').focus();
	            else if (a[0] == "Please select selected budget center")
	                document.getElementById('drpBudgetCenterDB').focus();
	            else if (a[0] == "Please select Project")
	                document.getElementById('drpEOProjectsDB').focus();
	            else if (a[0] == "Please select Plant")
	                document.getElementById('drpPlant').focus();
	            else if (a[0] == "Please enter EO title")
	                document.getElementById('txtTitle').focus();
	            else if (a[0] == "Please select Event(s)")
	                document.getElementById('lbEOEventsDB').focus();
	            /*else if (a[0]=="Please select PS&RA")
	            document.getElementById('lbPSRADB').focus();*/
	            else if (a[0] == "Please enter Start Date")
	                document.getElementById('txtStartDate').focus();


	            else if (a[0] == "Please select Raw and/or Packing Materials")
	                document.getElementById('rbRawMaterial').focus();
	            else if (a[0] == "Please select Will the EO produce Parent Rolls")
	                document.getElementById('rbParentRolls').focus(); 
	            else if (a[0] == "Please select any other Intermediate Materials")
	                document.getElementById('rbInterMaterials').focus();
	            else if (a[0] == "Please select production of Regulated Product")
	                document.getElementById('rbRegulatedProduct').focus();
	            /*else if (a[0]=="Please select appropriate GMP Classification")
	            document.getElementById('rbGMPClassify').focus();*/

	            else if (a[0] == "Please select  EO be shipped to the trade as a current brand")
	                document.getElementById('rbShipped').focus();

	            else if (a[0] == "Please select plant for consumer/lab evaluation")
	                document.getElementById('rbTestProductedShipped').focus();

	            else if (a[0] == "Please select  Contingent GCAS #s unique")
	                document.getElementById('rbGCASNumber').focus();

	            else if (a[0] == "Please select new chemical or a change")
	                document.getElementById('rbChemical').focus();

	            else if (a[0] == "Please select new raw material or a change")
	                document.getElementById('rbNewRawMaterial').focus();

	            else if (a[0] == "Please select new equipment/ process/ supporting systems or a change")
	                document.getElementById('rbNewEquipment').focus();

	            else if (a[0] == "Please select new job/task or a change")
	                document.getElementById('rbNewJobTask').focus();

	            else if (a[0] == "Please select product using a unique pallet pattern")
	                document.getElementById('rbPalletPattern').focus();

	            else if (a[0] == "Please select EO generate greater than normal broke")
	                document.getElementById('rbBroke').focus();

	            else if (a[0] == "Please select printed broke")
	                document.getElementById('rbPrintedBroke').focus();

	            else if (a[0] == "Please select amount of ink coverage")
	                document.getElementById('rbInkCoverage').focus();

	        }
	        else
	            document.getElementById('t11').value = "";

	    }

	    //MUREO PCR

	    function TwotabRouteMandatoryPCR() {
	        var s;
	        if ((document.getElementById('drpCategoryDB').selectedIndex == 0) || (document.getElementById('drpCategoryDB').selectedIndex == -1)) {
	            s = "Please select Category.";
	        }
	        else
	        { s = "" }
	        if ((document.getElementById('drpEOProjectsDB').selectedIndex == 0) || (document.getElementById('drpEOProjectsDB').selectedIndex == -1)) {
	            if (s != "") {
	                s = s + '\n' + "Please select Project.";
	            }
	            else
	            { s = "Please select Project."; }
	        }
	        if ((document.getElementById('drpPlant').selectedIndex == 0) || (document.getElementById('drpPlant').selectedIndex == -1)) {
	            if (s != "")
	            { s = s + '\n' + "Please select Plant."; }
	            else
	            { s = "Please select Plant."; }
	        }

	        if (document.getElementById('lbEOEventsDB').options.length == 0) {
	            if (s != "")
	            { s = s + '\n' + "Please select Event(s)."; }
	            else
	            { s = "Please select Event(s)."; }
	        }

	        var i = 0;
	        if (document.getElementById('lbEOEventsDB').options.length != 0) {
	            for (len = 0; len < document.getElementById('lbEOEventsDB').options.length; len++) {
	                if (document.getElementById('lbEOEventsDB').options[len].selected)
	                    i++;
	            }
	            if (i > 0)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select Event(s)."; }
	                else
	                { s = "Please select Event(s)."; }
	            }
	        }
	        var frm = document.forms[0];
	        var rbrw = 0; 
	        var intrbParentrolls = 0;
	        var rbInterMaterials = 0;
	        var rbRegulatedProduct = 0;
	        var chkGMPClassify = 0;
	        var rbShipped = 0;
	        var rbTestProductedShipped = 0;
	        var rbGCASNumber = 0;
	        var rbChemical = 0;
	        var rbNewRawMaterial = 0;
	        var rbNewEquipment = 0;
	        var rbNewJobTask = 0;

	        //Added for MUREO PCRs
	        var rblProductConsumers = 0;
	        var rblProductApproved = 0;


	        var rbPalletPattern = 0;
	        var rbBroke = 0;
	        var rbPrintedBroke = 0;
	        var rbInkCoverage = 0;


	        for (i = 0; i < frm.length; i++) {
	            if (frm.elements[i].type == "radio") {
	                if (frm.elements[i].name == "rbRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbrw == 0)))
	                        rbrw = 1;

	                if (frm.elements[i].name == "rbParentRolls")
	                    if (!((frm.elements[i].checked == false) && (intrbParentrolls == 0)))
	                        intrbParentrolls = 1; 

	                if (frm.elements[i].name == "rbInterMaterials")
	                    if (!((frm.elements[i].checked == false) && (rbInterMaterials == 0)))
	                        rbInterMaterials = 1;

	                if (frm.elements[i].name == "rbRegulatedProduct")
	                    if (!((frm.elements[i].checked == false) && (rbRegulatedProduct == 0)))
	                        rbRegulatedProduct = 1;
	                /*	
	                if (frm.elements[i].name == "rbGMPClassify") 
	                if (!((frm.elements[i].checked == false) && (rbGMPClassify == 0)))
	                rbGMPClassify = 1;*/

	                if (frm.elements[i].name == "rbShipped")
	                    if (!((frm.elements[i].checked == false) && (rbShipped == 0)))
	                        rbShipped = 1;

	                if (frm.elements[i].name == "rbTestProductedShipped")
	                    if (!((frm.elements[i].checked == false) && (rbTestProductedShipped == 0)))
	                        rbTestProductedShipped = 1;

	                if (frm.elements[i].name == "rbGCASNumber")
	                    if (!((frm.elements[i].checked == false) && (rbGCASNumber == 0)))
	                        rbGCASNumber = 1;

	                if (frm.elements[i].name == "rbChemical")
	                    if (!((frm.elements[i].checked == false) && (rbChemical == 0)))
	                        rbChemical = 1;


	                if (frm.elements[i].name == "rbNewRawMaterial")
	                    if (!((frm.elements[i].checked == false) && (rbNewRawMaterial == 0)))
	                        rbNewRawMaterial = 1;


	                if (frm.elements[i].name == "rbNewEquipment")
	                    if (!((frm.elements[i].checked == false) && (rbNewEquipment == 0)))
	                        rbNewEquipment = 1;


	                if (frm.elements[i].name == "rbNewJobTask")
	                    if (!((frm.elements[i].checked == false) && (rbNewJobTask == 0)))
	                        rbNewJobTask = 1;

	                /* Added for MUREO PCRs */

	                if (frm.elements[i].name == "rblProductConsumers")
	                    if (!((frm.elements[i].checked == false) && (rblProductConsumers == 0)))
	                        rblProductConsumers = 1;

	                if (frm.elements[i].name == "rblProductApproved")
	                    if (!((frm.elements[i].checked == false) && (rblProductApproved == 0)))
	                        rblProductApproved = 1;


	                if (frm.elements[i].name == "rbPalletPattern")
	                    if (!((frm.elements[i].checked == false) && (rbPalletPattern == 0)))
	                        rbPalletPattern = 1;

	                if (frm.elements[i].name == "rbBroke")
	                    if (!((frm.elements[i].checked == false) && (rbBroke == 0)))
	                        rbBroke = 1;

	                if (frm.elements[i].name == "rbPrintedBroke")
	                    if (!((frm.elements[i].checked == false) && (rbPrintedBroke == 0)))
	                        rbPrintedBroke = 1;

	                /*if (frm.elements[i].name == "rbInkCoverage") 
	                if (!((frm.elements[i].checked == false) && (rbInkCoverage == 0)))
	                rbInkCoverage = 1;*/

	            }
	        }

	        /*Added on 07/23/2010*/

	        if (document.getElementById('drpBudgetCenterDB').options(0).selected)
	            if (s != "")
	            { s = s + '\n' + "Please select selected budget center."; }
	            else
	            { s = "Please select selected budget center."; }



	        if (rbrw == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Raw and/or Packing Materials."; }
	            else
	            { s = "Please select Raw and/or Packing Materials."; }

	         if (intrbParentrolls == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select Will the EO produce Parent Rolls."; }
	            else
	            { s = "Please select Will the EO produce Parent Rolls."; } 


	        if (rbInterMaterials == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select any other Intermediate Materials."; }
	            else
	            { s = "Please select any other Intermediate Materials."; }

	        if (rbRegulatedProduct == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select production of Regulated Product."; }
	            else
	            { s = "Please select production of Regulated Product."; }

	        /*if(rbGMPClassify == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select appropriate GMP Classification.";}
	        else
	        {s = "Please select appropriate GMP Classification.";}*/

	        if (rbShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  EO be shipped to the trade as a current brand."; }
	            else
	            { s = "Please select  EO be shipped to the trade as a current brand."; }

	        var result = "False";
	        objInputs = document.getElementById("chkMaterialsBrands").getElementsByTagName("INPUT");

	        for (i = 0; i < objInputs.length; i++) {
	            if (objInputs[i].type == "checkbox") {
	                if (objInputs[i].checked) {
	                    result = "true";


	                }
	            }

	        }

	        if (result == "False") {
	            if (s != "")
	            { s = s + '\n' + "Please select New Materials and Brands."; }
	            else
	            { s = "Please select New Materials and Brands."; }

	        }



	        if (rbTestProductedShipped == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select plant for consumer/lab evaluation."; }
	            else
	            { s = "Please select plant for consumer/lab evaluation."; }

	        if (rbGCASNumber == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select  Contingent GCAS #s unique."; }
	            else
	            { s = "Please select  Contingent GCAS #s unique."; }

	        if (rbChemical == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new chemical or a change."; }
	            else
	            { s = "Please select new chemical or a change."; }


	        if (rbNewRawMaterial == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new raw material or a change."; }
	            else
	            { s = "Please select new raw material or a change."; }

	        if (rbNewEquipment == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new equipment/ process/ supporting systems or a change."; }
	            else
	            { s = "Please select new equipment/ process/ supporting systems or a change."; }

	        if (rbNewJobTask == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select new job/task or a change."; }
	            else
	            { s = "Please select new job/task or a change."; }

	        /* Added for MUREO PCRs */



	        if (rblProductConsumers == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select if Product goes to consumers."; }
	            else
	            { s = "Please select if Product goes to consumers."; }


	        if (rblProductApproved == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select if you are using an approved FC or ATS."; }
	            else
	            { s = "Please select if you are using an approved FC or ATS."; }


	        var OptionProdApprovedNo = document.getElementById("rblProductApproved_1").checked;

	        var OptionProdConsumerYes = document.getElementById("rblProductConsumers_0").checked;

	        if (OptionProdConsumerYes && OptionProdApprovedNo) {

	            if (document.getElementById("rblRawMaterialsQ1_0").checked || document.getElementById("rblRawMaterialsQ1_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved at the appropriate level (1-5)."; }
	                else
	                { s = "Please select if Raw Materials approved at the appropriate level (1-5)."; }
	            }

	            if (document.getElementById("rblRawMaterialsQ2_0").checked || document.getElementById("rblRawMaterialsQ2_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved for the appropriate region (NA, Mexico)."; }
	                else
	                { s = "Please select if Raw Materials approved for the appropriate region (NA, Mexico)."; }
	            }
	            if (document.getElementById("rblRawMaterialsQ3_0").checked || document.getElementById("rblRawMaterialsQ3_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved for the application (tissue, towel)."; }
	                else
	                { s = "Please select if Raw Materials approved for the application (tissue, towel)."; }
	            }
	            if (document.getElementById("rblRawMaterialsQ4_0").checked || document.getElementById("rblRawMaterialsQ4_1").checked)
	            { }
	            else {
	                if (s != "")
	                { s = s + '\n' + "Please select if Raw Materials approved at the previously approved application rate."; }
	                else
	                { s = "Please select if Raw Materials approved at the previously approved application rate."; }
	            }

	        }


	        if (rbPalletPattern == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select product using a unique pallet pattern."; }
	            else
	            { s = "Please select product using a unique pallet pattern."; }

	        if (rbBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select EO generate greater than normal broke."; }
	            else
	            { s = "Please select EO generate greater than normal broke."; }

	        if (rbPrintedBroke == 0)
	            if (s != "")
	            { s = s + '\n' + "Please select printed broke."; }
	            else
	            { s = "Please select printed broke."; }

	        /*if(rbInkCoverage == 0)
	        if (s!="") 
	        {s = s + '\n' + "Please select amount of ink coverage.";}
	        else
	        {s = "Please select amount of ink coverage.";}*/




	        if (document.getElementById('txtStartDate').value == "") {
	            if (s != "")
	            { s = s + '\n' + "Please enter Start Date."; }
	            else
	            { s = "Please Enter Start Date."; }
	        }





	        if (s != "") {
	            alert(s);
	            document.getElementById('t11').value = 1;
	            var a = s.split(".");
	            if (a[0] == "Please select Category")
	                document.getElementById('drpCategoryDB').focus();
	            else if (a[0] == "Please select selected budget center")
	                document.getElementById('drpBudgetCenterDB').focus();
	            else if (a[0] == "Please select Project")
	                document.getElementById('drpEOProjectsDB').focus();
	            else if (a[0] == "Please select Plant")
	                document.getElementById('drpPlant').focus();
	            else if (a[0] == "Please enter EO title")
	                document.getElementById('txtTitle').focus();
	            else if (a[0] == "Please select Event(s)")
	                document.getElementById('lbEOEventsDB').focus();
	            /*else if (a[0]=="Please select PS&RA")
	            document.getElementById('lbPSRADB').focus();*/
	            else if (a[0] == "Please enter Start Date")
	                document.getElementById('txtStartDate').focus();


	            else if (a[0] == "Please select Raw and/or Packing Materials")
	                document.getElementById('rbRawMaterial').focus();
	             else if (a[0] == "Please select Will the EO produce Parent Rolls")
	                document.getElementById('rbParentRolls').focus(); 
	            else if (a[0] == "Please select any other Intermediate Materials")
	                document.getElementById('rbInterMaterials').focus();

	            else if (a[0] == "Please select New Materials and Brands")
	                document.getElementById("chkMaterialsBrands").focus();

	            else if (a[0] == "Please select production of Regulated Product")
	                document.getElementById('rbRegulatedProduct').focus();
	            /*else if (a[0]=="Please select appropriate GMP Classification")
	            document.getElementById('rbGMPClassify').focus();*/

	            else if (a[0] == "Please select  EO be shipped to the trade as a current brand")
	                document.getElementById('rbShipped').focus();

	            else if (a[0] == "Please select plant for consumer/lab evaluation")
	                document.getElementById('rbTestProductedShipped').focus();

	            else if (a[0] == "Please select  Contingent GCAS #s unique")
	                document.getElementById('rbGCASNumber').focus();

	            else if (a[0] == "Please select new chemical or a change")
	                document.getElementById('rbChemical').focus();

	            else if (a[0] == "Please select new raw material or a change")
	                document.getElementById('rbNewRawMaterial').focus();

	            else if (a[0] == "Please select new equipment/ process/ supporting systems or a change")
	                document.getElementById('rbNewEquipment').focus();

	            else if (a[0] == "Please select new job/task or a change")
	                document.getElementById('rbNewJobTask').focus();

	            /* Added for MUREO PCRS */

	            else if (a[0] == "Please select if Product goes to consumers")
	                document.getElementById('rblProductConsumers').focus();

	            else if (a[0] == "Please select if you are using an approved FC or ATS")
	                document.getElementById('rblProductApproved').focus();

	            else if (a[0] == "Please select if Raw Materials approved at the appropriate level (1-5)")
	                document.getElementById('rblRawMaterialsQ1').focus();


	            else if (a[0] == "Please select if Raw Materials approved for the appropriate region (NA, Mexico)")
	                document.getElementById('rblRawMaterialsQ2').focus();


	            else if (a[0] == "Please select if Raw Materials approved for the application (tissue, towel)")
	                document.getElementById('rblRawMaterialsQ3').focus();


	            else if (a[0] == "Please select if Raw Materials approved at the previously approved application rate")
	                document.getElementById('rblRawMaterialsQ4').focus();


	            else if (a[0] == "Please select product using a unique pallet pattern")
	                document.getElementById('rbPalletPattern').focus();

	            else if (a[0] == "Please select EO generate greater than normal broke")
	                document.getElementById('rbBroke').focus();

	            else if (a[0] == "Please select printed broke")
	                document.getElementById('rbPrintedBroke').focus();

	            else if (a[0] == "Please select amount of ink coverage")
	                document.getElementById('rbInkCoverage').focus();

	        }
	        else
	            document.getElementById('t11').value = "";

	    }

	    //for PreFinalRoute Mandatory


	    function CatCheck(sender, args) {
	        if ((document.getElementById('drpCategoryDB').selectedIndex == 0) || (document.getElementById('drpCategoryDB').selectedIndex == -1)) {
	            args.IsValid = false;
	        }
	        else {
	            args.IsValid = true;
	        }
	    }


	    function PlantCheck(sender, args) {
	        if ((document.getElementById('drpPlant').selectedIndex == 0) || (document.getElementById('drpPlant').selectedIndex == -1)) {
	            args.IsValid = false;
	        }
	        else {
	            args.IsValid = true;
	        }
	    }

	    function ProjeCheck(sender, args) {
	        if ((document.getElementById('drpEOProjectsDB').selectedIndex == 0) || (document.getElementById('drpEOProjectsDB').selectedIndex == -1)) {
	            args.IsValid = false;
	        }
	        else {
	            args.IsValid = true;
	        }
	    }
		
		
	</script>
	<script language="javascript">
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

	    function PhNumber(e) {
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

	    // checking for only one decimal in numeric text boxes	
	    /*function CountDecimals(val,contrlName)
	    {
	    var k = val;
	    var j = 0;
	    for(var i=0;i < k.length;i++)
	    {
	    var a = k.charAt(i);
	    if (a == ".")
	    j++;
	    }
	    if (j > 1) 
	    {
	    alert("Please enter decimal value"); 
	    document.getElementById(contrlName).value = "";
	    document.getElementById(contrlName).focus();
	    }} */

	    //		function AddBooksingUser() {
	    //		  
	    //		    var popResult;
	    //		    popResult = window.showModalDialog('ShowUser.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:500px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
	    //		    if (popResult != "") {
	    //		        alert(popResult);
	    //            document.getElementById('txtCooriginator').value = popResult; }
	    //		    if (document.getElementById('txtCooriginator').value == 'undefined') {
	    //		        document.getElementById('txtCooriginator').value = "";
	    //		    }
	    //		}

	    function AddBooksingUser() {
	        var strTxtPrjLead = document.getElementById("<%=txtCooriginator.ClientID %>").id;
	        var hdntxtprjlead = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
	        window.open('ShowUsers.aspx?ID=' + strTxtPrjLead + '&Hidd=' + hdntxtprjlead, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
	        return false;
	    }


	    //for accept
	    function OpenApproveYesNoAccept() {
	        var popResult;
	        var EoID = document.getElementById('TxtAppYes').value;
	        popResult = window.showModalDialog('ApproveYesNo.aspx?EOID=' + EoID + '&Type=A', null, 'dialogHeight:200px;dialogWidth:400px');
	        document.getElementById('TxtAppYes').value = popResult;
	    }




	    // for decline 

	    function OpenApproveYesNoDecline() {
	        var popResult;
	        var EoID = document.getElementById('TxtAppYes').value;
	        popResult = window.showModalDialog('ApproveYesNo.aspx?EOID=' + EoID + '&Type=D', null, 'dialogHeight:200px;dialogWidth:400px');
	        document.getElementById('TxtAppYes').value = popResult;
	    }


	    function ShowGCASWindow(EoID) {
	        //jagan 16-12-07
	        var popResult;
	        //var EoID = document.getElementById('textBoxEOID').value;
	        popResult = window.open('GCASNumber.aspx?EOID=' + EoID, null, 'height=570, width=590, left=280, top=120');
	        document.getElementById('txttest').value = popResult;


	    }

	    function ShowPSRAWindow(EoID) {
	        //jagan 16-12-07
	        var popResult;
	        //var EoID = document.getElementById('textBoxEOID').value;
	        popResult = window.open('PSRA.aspx?EOID=' + EoID, null, 'height=290,width=450,status=yes,toolbar=no,menubar=no,location=no,top=230,left=270');
	        document.getElementById('txtPSRAtest').value = popResult;
	    }

	    function OpenDateToWindow() {
	        var txtFromValue = document.getElementById("txtStartDate").value
	        window.open('calendar.aspx?formname=NewEO.txtStartDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');
	    }

	    function OpenDateToWindow1() {
	        var txtFromValue = document.getElementById("txtCloseCompletionDate").value;
	        window.open('calendar.aspx?formname=NewEO.txtCloseCompletionDate&value=' + txtFromValue, 'calendar_window', 'width=210,height=270,top=125,left=450');
	    }
	    function AddBookMultiUser() {
	        var popResult;
	        popResult = window.showModalDialog('ShowUsers.aspx?from=CheckingUser', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
	        if (popResult != "")
	        { document.getElementById('txtCooriginator').value = popResult; }
	        if (document.getElementById('txtCooriginator').value == 'undefined') {
	            document.getElementById('txtCooriginator').value = "";
	        }
	    }

	    //Screen Resolution code
	    function setScreenRes() {
	        document.getElementById("divTest").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

	    }
	</script>
     <style type="text/css">
        .popupControl
        {
            position: absolute;
            top: 240px;
            left: 650px;
            width: 100%;
            height: 100%;
            opacity: 0.9;
            z-index: 499;
        }
    </style>
    <%--onload="setScreenRes();"--%>
</head>
  <body  bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="NewEO" method="post" name="NewEoForm" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" EnablePartialRendering="true">
            </asp:ScriptManager>
        </div>
         <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
        <ProgressTemplate>
            <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
         <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnGCASValue" runat="server" />
			<input id="hdnFirst" value="0" type="hidden" name="hdnFirst" runat="server"> 
            <input id="hdnIndex" type="hidden" name="hdnIndex" runat="server">
			<%--<input id="hdnFinalFirst" value="0" type="hidden" name="hdnFinalFirst" runat="server">--%>
            <asp:HiddenField ID="hdnFinalFirst" runat="server" />
			<input id="hdnFinalIndex" type="hidden" name="hdnFinalIndex" runat="server"> 
            <input id="hdnSmart" type="hidden" name="hdnSmart" runat="server">
               <input id="hdnSmartValue" type="hidden" name="hdnSmartValue" runat="server">
                 <input id="hdnPreSpendingValue" type="hidden" name="hdnPreSpendingValue" runat="server">
                 <input id="hdnTotalCostValue" type="hidden" name="hdnTotalCostValue" runat="server">
            <input id="hdnBudgetOwner" type="hidden" name="hdnBudgetOwner" runat="server">
            <input id="hdnBudgetOwnerFinal" type="hidden" name="hdnBudgetOwnerFinal" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="left" height="100%">
				<tr>
					<td>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td background="../images/bg.gif" colSpan="5">
									<div align="center"><IMG src="../images/banner.jpg" width="1000" height="102"></div>
								</td>
							</tr>
							<tr>
								<td background="../images/menu_bg.gif" width="111">&nbsp;</td>
								<td background="../images/menu_bg.gif" width="20"><IMG src="../Images/menu_left_corner_bit.gif" width="20" height="23"></td>
								<td class="HomeTabs" width="1001">
									<div align="center"><IMG id="imghome" src="../images/link_bullet.gif" width="2" height="15" runat="server">&nbsp;
										<asp:linkbutton id="lnkHome" onclick="lnkHome_Click" runat="server" CausesValidation="False">
											<StrONG><font class="HomeTabs">Home</font></StrONG></asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<IMG id="imgSysOwner" src="../images/link_bullet.gif" width="2" height="15" runat="server">
										<strong><A style="TEXT-DECORATION: none" href="../Administration/MaintainSystemOwner.aspx">
												<font class="HomeTabs">
													<asp:label id="lblSysOwner" Runat="server">System Owners</asp:label></font></A><A style="TEXT-DECORATION: none" href="../Common/SystemOwners.aspx"><font class="HomeTabs"><asp:label id="lblSysOwnerUsers" Runat="server">System Owners</asp:label></font></A></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<IMG src="../images/link_bullet.gif" width="2" height="15">
										<asp:linkbutton style="TEXT-DECORATION: none" id="lbGlobal" CausesValidation="False" Runat="server"
											ForeColor="#003399">
											<strong><font class="HomeTabs">Global Team Space</font></strong></asp:linkbutton></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<IMG src="../images/link_bullet.gif" width="2" height="15">
										<asp:linkbutton style="TEXT-DECORATION: none" id="lbHelp" CausesValidation="False" Runat="server"
											ForeColor="#003399">
											<StrONG><font class="HomeTabs">Help</font></StrONG>
										</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <IMG src="../images/link_bullet.gif" width="2" height="15">
										<asp:linkbutton style="TEXT-DECORATION: none" id="lbFaq" OnClick="lbFaq_Click" CausesValidation="False" Runat="server"
											ForeColor="#003399">
											<StrONG><font class="HomeTabs">FAQ</font></A></StrONG></asp:linkbutton></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<IMG id="imgadmin" src="../images/link_bullet.gif" width="2" height="15" runat="server">&nbsp;
										<asp:linkbutton id="lnkAdmin" OnClick="lnkAdmin_Click" runat="server" CausesValidation="False">
											<StrONG><font class="HomeTabs">Administration</font></StrONG></asp:linkbutton><StrONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</StrONG>
									</div>
								</td>
								<td background="../images/menu_bg.gif" width="20"><IMG src="../images/menu_right_corner_bit.gif" width="20" height="23"></td>
								<td background="../images/menu_bg.gif" width="113">&nbsp;</td>
							</tr>
							<tr>
								<td height="3" background="../images/menu_bg.gif" colSpan="5"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top"><asp:validationsummary style="Z-INDEX: 101; POSITION: absolute; TOP: 48px; LEFT: 0px" id="vdsmEO" runat="server"
							DESIGNTIMEDRAGDROP="12886" DisplayMode="List" ShowSummary="False" ShowMessageBox="true"></asp:validationsummary>
                            <asp:textbox style="Z-INDEX: 103; POSITION: absolute; TOP: 24px; LEFT: 0px; DISPLAY: none" id="t1" runat="server"
							Width="0px" Wrap="False"></asp:textbox>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
						</table>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td background="../Images/menu-head-bg.gif" width="100%" align="center"><asp:label id="lbEODocument" runat="server" Font-Bold="true" Font-Size="18">EO Document</asp:label></td>
							</tr>
						</table>
						<table border="0" cellPadding="2" width="50%" align="center">
							<tr>
								<TD width="10%" align="center"><asp:imagebutton id="imgEditEo" runat="server" ImageUrl="../Images/edit-eo.gif" Visible="False"></asp:imagebutton></TD>
								<TD width="10%" align="center"><asp:imagebutton id="btnPrintStage" runat="server" 
                                        CausesValidation="False" ImageUrl="../Images/printstage.gif" 
                                        onclick="btnPrintStage_Click1"></asp:imagebutton></TD>
								<TD width="10%" align="center"><asp:imagebutton id="imgSaveResume" tabIndex="200" 
                                        runat="server" ImageUrl="../Images/save_resume.jpg" 
                                        onclick="imgSaveResume_Click"></asp:imagebutton></TD>
								<td width="10%" align="center"><asp:imagebutton id="btnSave" runat="server" 
                                        ImageUrl="../Images/save_exit.jpg" onclick="btnSave_Click"></asp:imagebutton></td>
								<td width="10%" align="center"><asp:imagebutton id="btnSaveandExit" runat="server" 
                                        CausesValidation="False" ImageUrl="../Images/cancel.gif" 
                                        onclick="btnSaveandExit_Click1"></asp:imagebutton></td>
								<TD width="10%" align="center">
                                    <asp:imagebutton id="imgPreRoute" runat="server" 
                                        CausesValidation="False" ImageUrl="../Images/Preliminary-Route.gif" 
                                        onclick="imgPreRoute_Click1" style="width: 126px"></asp:imagebutton></TD>
								<td width="10%" align="center"><asp:imagebutton id="imgPreFinalRoute" 
                                        runat="server" CausesValidation="False" ImageUrl="../Images/Final-Route.gif" 
                                        onclick="imgPreFinalRoute_Click1"></asp:imagebutton></td>
								<TD width="10%" align="center"><asp:imagebutton id="imgCloseOutRoute" 
                                        runat="server" CausesValidation="False" 
                                        ImageUrl="../Images/Close-Out-Route.gif" onclick="imgCloseOutRoute_Click1"></asp:imagebutton></TD>
								<td width="15%" align="center"><asp:imagebutton id="btnExportPilotLine" runat="server" CausesValidation="False" ImageUrl="..\Images\export-pilotline-to1.gif"
										Visible="False"></asp:imagebutton></td> <!--As per the new PCR on 27-Feb-2009 this export pilot line data functionlity is not required so set the visibility false by Murthy (Moved from 5th psoition to last)--></tr>
							<tr>
								<td width="10%" align="center"></td>
								<td width="10%" align="center"></td>
								<td width="10%" align="center"></td>
								<td width="10%" align="center"><asp:textbox id="txtEOID" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox></td>
								<td width="10%" align="center"><asp:imagebutton id="btnFYI" runat="server" 
                                        CausesValidation="False" ImageUrl="../Images/fyi1.gif" onclick="btnFYI_Click"></asp:imagebutton></td>
								<td width="10%" align="center"><asp:imagebutton id="imgbtnCopyToAnalyse" runat="server" ImageUrl="../Images/copy-to--revise.jpg"
										Visible="False"></asp:imagebutton></td>
								<td width="10%" align="center"><asp:imagebutton id="imgbtnCopyNew" runat="server" ImageUrl="../Images/copy-to-create-new.jpg" Visible="False"></asp:imagebutton></td>
								<td width="10%" align="center"><asp:textbox id="TextBox1" runat="server"  Width="0px" style="DISPLAY: none"></asp:textbox></td>
								<td width="15%" align="center"><asp:textbox id="textBoxEOID" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox><asp:textbox id="txtBackUpName" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox></td>
							</tr>
						</table>
                       <%-- <div style="width:1250px">--%>
						<table id="tblScroll" width="100%">
							<tr>
								<td>
									<!--chary-->
									<div id="divTest">
										<table id="tblTop" width="100%" runat="server">
											<tr>
												<td class="FieldNames" style="width: 15%">Current Stage :</td>
												<td width="16%"><asp:label id="lbCurrentStageDB" runat="server">Label</asp:label></td>
												<td class="FieldNames">Status :</td>
												<td width="18%"><asp:label id="lbStatusDB" runat="server">Label</asp:label><asp:label id="lblClosed" runat="server" Visible="False">Closed</asp:label></td>
												<td class="FieldNames">Title :</td>
												<td onkeypress="javascript: return NoSpecialCharacters(event);" width="25%"><asp:textbox id="txtTitle" tabIndex="6" runat="server" Width="230px" Rows="50"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</td>
											</tr>
											<tr>
												<td></td>
												<td width="15%"></td>
												<td class="FieldNames" width="15%"></td>
												<td width="10%"></td>
												<td class="FieldNames" width="10%"></td>
												<td width="25%"><asp:label id="Label10" runat="server" CssClass="NoteMsg">NOTE: Change the EO Title before <br> Preliminary Routing</asp:label></td>
											</tr>
											<tr>
												<td class="FieldNames">EO # :</td>
												<td width="15%"><asp:label id="lbEONumberDB" runat="server">New EO</asp:label></td>
												<td class="FieldNames" width="10%">
													<P>&nbsp;</P>
												</td>
												<td width="25%"><asp:textbox id="t11" runat="server" Width="0px" Visible="true" style="DISPLAY: none"></asp:textbox></td>
												<td class="FieldNames" width="10%">Originator :</td>
												<td width="20%"><asp:label id="lblCoOrdinator" runat="server">Label</asp:label></td>
											</tr>
											<tr>
												<td class="FieldNames"><asp:label id="lblSmartClearanceDBText" runat="server" Visible="False">SMART Clearance # :</asp:label></td>
												<td width="15%"><asp:label id="lblSmartClearanceDB" runat="server" Visible="False"></asp:label></td>
												<td class="FieldNames" width="10%">Selected Brand :</td>
												<td width="25%"><asp:label id="lblEOSelectedBrandDB" runat="server"></asp:label><asp:label id="lblBrandIDList" runat="server" Visible="False"></asp:label></td>
												<td class="FieldNames" width="10%">Office # :</td>
												<td width="20%"><asp:textbox id="txtOfficeNumber" tabIndex="7" runat="server" Width="230px" MaxLength="20"></asp:textbox></td>
											</tr>
											<tr>
												<td class="FieldNames">SAPIO # :</td>
												<td width="25%"><asp:label id="lbSAPIODB" runat="server">Not Assigned</asp:label></td>
												<td class="FieldNames" width="10%">Project :</td>
												<td width="25%"><asp:dropdownlist id="drpEOProjectsDB" tabIndex="3" runat="server" 
                                                        Width="230px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpEOProjectsDB_SelectedIndexChanged"></asp:dropdownlist><FONT class="astrisk" color="red">*</FONT>
													<asp:customvalidator id="cstdProj" runat="server" ControlToValidate="drpEOProjectsDB" Display="None"
														ErrorMessage="Please select Project." ClientValidationFunction="ProjeCheck"></asp:customvalidator></td>
												<td class="FieldNames" width="10%">Phone # :</td>
												<td width="20%"><asp:textbox id="txtPhoneNumberDB" tabIndex="8" runat="server" Width="230px" MaxLength="20"></asp:textbox></td>
											</tr>
											<tr>
												<td class="FieldNames">Category :</td>
												<td width="25%" align="left">
                                                    <asp:DropDownList ID="drpCategoryDB" runat="server" AutoPostBack="true" 
                                                        tabIndex="1" Width="230px" OnSelectedIndexChanged="drpCategoryDB_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                   <FONT class="astrisk" color="red">*</FONT><br />
                                                   <asp:customvalidator id="cstvdCategory" runat="server" ControlToValidate="drpCategoryDB" Display="None"
														ErrorMessage="Please select Category." ClientValidationFunction="CatCheck"></asp:customvalidator></td>
												<td class="FieldNames" width="10%">Plant :</td>
												<td width="15%"><asp:dropdownlist id="drpPlant" tabIndex="4" runat="server" 
                                                        Width="230px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpPlant_SelectedIndexChanged"></asp:dropdownlist><FONT class="astrisk" color="red">*</FONT>
													<asp:customvalidator id="cstdPlant" runat="server" ControlToValidate="drpPlant" Display="None" ErrorMessage="Please select Plant."
														ClientValidationFunction="PlantCheck"></asp:customvalidator></td>
												<td class="FieldNames" width="10%">Co-Originator :</td>
												<td width="20%"><asp:textbox id="txtCooriginator" tabIndex="9" runat="server" Width="230px" Enabled="false"></asp:textbox><asp:imagebutton id="imgPOCAddressBook" runat="server" CausesValidation="False" ImageUrl="..\Images\addressbook.gif"
														ToolTip="Lookup Names"></asp:imagebutton></td>
											</tr>
											<tr>
												<td class="FieldNames">&nbsp;Brand(s) :</td>
												<td width="25%"><asp:listbox id="lbEOBrandsDB" tabIndex="2" runat="server" 
                                                        Width="230px" AutoPostBack="true"
														SelectionMode="Multiple" onselectedindexchanged="lbEOBrandsDB_SelectedIndexChanged"></asp:listbox></td>
												<td class="FieldNames" width="10%">Event(s) :</td>
												<td width="15%"><asp:listbox id="lbEOEventsDB" tabIndex="5" runat="server" Width="230px" SelectionMode="Multiple"></asp:listbox><FONT class="astrisk" color="red">*</FONT>
													<asp:requiredfieldvalidator id="rqvdEvents" runat="server" ControlToValidate="lbEOEventsDB" Display="None" ErrorMessage="Please select Event(s)."></asp:requiredfieldvalidator></td>
												<td class="FieldNames" width="10%">EO Mode :</td>
												<td vAlign="top" width="20%">&nbsp;
													<asp:radiobuttonlist id="rbEOType" tabIndex="10" runat="server" Width="238px" AutoPostBack="true" RepeatDirection="Horizontal">
														<asp:ListItem Value="E" Selected="true">EO</asp:ListItem>
														<asp:ListItem Value="S">Site Test</asp:ListItem>
														<asp:ListItem Value="O">Other</asp:ListItem>
														<asp:ListItem Value="H">Hub</asp:ListItem>
													</asp:radiobuttonlist></td>
											</tr>
										</table>
										<br>
                                        <%--opening top section - Readonly--%>
										<table style="BORDER-BOTTOM: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-RIGHT: #898989 1px solid"
											id="tblTopReadonly" width="100%" runat="server">
											<tr>
												<td class="FieldNames">Current Stage :</td>
												<td width="15%"><asp:label id="lblCurStage" runat="server"></asp:label></td>
												<td class="FieldNames">Status :</td>
												<td width="15%"><asp:label id="lblstatus" runat="server"></asp:label></td>
												<td class="FieldNames">Title :</td>
												<td width="25%"><FONT class="astrisk" color="#000000"><asp:label id="lblTitle" runat="server"></asp:label></FONT></td>
											</tr>
											<tr>
												<td class="FieldNames">EO # :</td>
												<td width="15%"><asp:textbox id="txtPlantID" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox><asp:label id="lblEOnum" runat="server"></asp:label></td>
												<td class="FieldNames" width="15%"></td>
												<td width="15%"></td>
												<td class="FieldNames" width="15%">Originator :</td>
												<td width="25%"><asp:label id="lblOriginator" runat="server"></asp:label></td>
											</tr>
											<tr>
												<td class="FieldNames"><asp:label id="lblSmartClearanceText" runat="server" Visible="False" CssClass="FieldNames">SMART Clearance # :</asp:label></td>
												<td width="15%"><asp:label id="lblSmartClearance" runat="server" Visible="False"></asp:label></td>
												<td class="FieldNames" width="15%">Selected Brand :</td>
												<td width="15%"><asp:label id="lblSelBrands" runat="server"></asp:label></td>
												<td class="FieldNames" width="15%">Office # :</td>
												<td width="25%"><asp:label id="lblOfficeNo" runat="server"></asp:label></td>
											</tr>
											<tr>
												<td style="HEIGHT: 20px" class="FieldNames">SAPIO # :</td>
												<td style="HEIGHT: 20px" width="15%"><asp:label id="lblSAPIO" runat="server"></asp:label></td>
												<td style="HEIGHT: 20px" class="FieldNames" width="15%">Projects :</td>
												<td style="HEIGHT: 20px" width="15%"><FONT class="astrisk" color="#000000"><asp:label id="lblProjects" runat="server"></asp:label></FONT></td>
												<td style="HEIGHT: 20px" class="FieldNames" width="15%">Phone # :</td>
												<td style="HEIGHT: 20px" width="25%"><asp:label id="lblPhno" runat="server"></asp:label></td>
											</tr>
											<tr>
												<td class="FieldNames">Category :</td>
												<td width="15%"><FONT class="astrisk" color="#000000"><asp:label id="lblCategory" runat="server"></asp:label></FONT></td>
												<td class="FieldNames" width="15%">Plant :</td>
												<td width="15%"><FONT class="astrisk" color="#000000"><asp:label id="lblPlant" runat="server"></asp:label></FONT></td>
												<td class="FieldNames" width="15%">Co-Originator :</td>
												<td width="25%"><asp:label id="lblCoOrginator" runat="server"></asp:label></td>
											</tr>
											<tr>
												<td class="FieldNames">&nbsp;Brands :</td>
												<td width="15%"><asp:label id="lblBrands" runat="server"></asp:label></td>
												<td class="FieldNames" width="15%">Events :</td>
												<td width="15%"><asp:label id="lblEvents" runat="server"></asp:label></td>
												<td class="FieldNames" vAlign="top" width="15%">Eo Mode :</td>
												<td vAlign="top" width="25%"><asp:label id="lblEOMode" runat="server"></asp:label></td>
											</tr>
										</table>
                                        <%--closing top section -ReadOnly--%>
										<br>
                                        <%--opening of EventinfoData Grid section when migrate from events report--%>
										<table id="MigratedEventInfoTable" border="0" cellSpacing="0" cellPadding="0" width="100%"
											runat="server">
											<tr>
												<td align="center"><asp:datagrid id="dgdMigratedEventInfo" runat="server" 
                                                        Visible="False" BorderColor="#404040" AutoGenerateColumns="False"
														DataKeyField="Event_ID" onitemcommand="dgdMigratedEventInfo_ItemCommand">
														<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
														<ItemStyle CssClass="AlternateRow1"></ItemStyle>
														<HeaderStyle CssClass="Header"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Event Name">
																<ItemTemplate>
																	<asp:Label ID="lblEventID" Runat="server" Visible="false" text='<%# Eval("Event_ID") %>'>
																	</asp:Label>
																	<asp:LinkButton CommandName="EventName_Link" CausesValidation="false" Runat="server" ID="hypEventName" text='<%# Eval("Event_Name")%>'>
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Plant_Name" HeaderText="Site"></asp:BoundColumn>
															<asp:BoundColumn DataField="Machine_Name" HeaderText="Line/Machine"></asp:BoundColumn>
															<asp:BoundColumn DataField="Project_Name" HeaderText="Project"></asp:BoundColumn>
															<asp:BoundColumn DataField="Desired_Start_Date" HeaderText="Start Date"></asp:BoundColumn>
															<asp:BoundColumn DataField="Total_Lost_Days" HeaderText="Days Needed"></asp:BoundColumn>
														</Columns>
													</asp:datagrid></td>
											</tr>
										</table>
                                        <%--closing of EventinfoData Grid section when migrate from events report--%>
										<table border="2" cellSpacing="0" cellPadding="0" width="100%"> <!-- Tab Navigation Table -->
													<tr>
													<td width="9%"><asp:imagebutton id="btnTabPreliminary" runat="server" 
                                                            CausesValidation="False" ImageUrl="../Images/preliminary-nor.gif"
															AlternateText="Preliminary" ImageAlign="Left" onclick="btnTabPreliminary_Click"></asp:imagebutton></td>
													<td width="9%"><asp:imagebutton id="btnTabFinal" runat="server" 
                                                            CausesValidation="False" ImageUrl="../Images/final-nor.gif"
															AlternateText="Final" ImageAlign="Left" onclick="btnTabFinal_Click"></asp:imagebutton>
													<td width="9%"><asp:imagebutton id="btnTabCloseOut" runat="server" 
                                                            CausesValidation="False" ImageUrl="../Images/close-out-nor.gif"
															AlternateText="Close-Out" ImageAlign="Left" onclick="btnTabCloseOut_Click"></asp:imagebutton></td>
													<td width="73%"></td>
												</tr>
												<tr>
													<td width="100%" colSpan="4">
														<table border="0" cellSpacing="0" width="100%">
															<tr>
																<td background="../Images/menu-head-bg.gif" width="20%"><asp:label id="lblStageLevel" runat="server">Preliminary</asp:label></td>
																<td background="../Images/menu-head-bg.gif" width="20%"><asp:label id="lblStatusLevel" runat="server" Visible="False">Status</asp:label>&nbsp;<asp:label id="lblStatusType" runat="server"></asp:label></td>
																<td background="../Images/menu-head-bg.gif" width="20%"></td>
																<td background="../Images/menu-head-bg.gif" width="40%"></td>
															</tr>
														</table>
													</td>
												</tr>
												<tr id="FirstSectionPreliminary" runat="server">
                                                    <%--opening preliminary general section --%>
													<td style="HEIGHT: 579px" width="100%" colSpan="4">
														<TABLE id="GeneralPreliminary" class="AlternateSection1" width="100%"> <!-- Preliminary General Navigation Table -->
															<tr>
																<td width="25%" align="right">EO Type :&nbsp;</td>
																<td width="25%"><asp:listbox id="lbEOTypeDB" tabIndex="11" runat="server" Width="230px" SelectionMode="Multiple"></asp:listbox></td>
																<td style="WIDTH: 309px" width="309" align="right">EO Scope/Project Phase :&nbsp;</td>
																<td width="25%"><asp:dropdownlist id="drpEOScopeDB" tabIndex="13" runat="server" 
                                                                        Width="230px" AutoPostBack="true" 
                                                                        onselectedindexchanged="drpEOScopeDB_SelectedIndexChanged"></asp:dropdownlist></td>
															</tr>
															<tr>
																<td></td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);" vAlign="top"><asp:label id="lblEOTypeOther" runat="server" CssClass="NoteMsg">If Other is selected, <br>please enter a new type of EO :             </asp:label><asp:textbox id="txtEOTypeOther" tabIndex="12" runat="server" Width="230px" MaxLength="50"></asp:textbox></td>
																<td style="WIDTH: 309px"></td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);"><asp:label id="lbEOScopeMessage" runat="server" CssClass="NoteMsg">If Other is selected, <br>please enter a new EO Scope/Project Phase :</asp:label><BR>
																	<asp:textbox id="txtEOScopeOther" tabIndex="14" runat="server" Width="230px" MaxLength="50"></asp:textbox></td>
															</tr>
														</TABLE>
														<TABLE id="Table2" class="AlternateSection1" width="100%">
															<tr>
																<td width="25%" align="right">Brief Description :&nbsp;</td>
																<td width="75%"><asp:textbox id="txtBriefDescription" tabIndex="15" runat="server" Width="650px" Rows="2" MaxLength="1000"
																		ToolTip="Please enter Brief Description of max 1000 characters." TextMode="MultiLine"></asp:textbox>&nbsp;
																	<asp:label id="Label4" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 Characters</asp:label></td>
															</tr>
														</TABLE>
														<TABLE id="Table3" class="AlternateSection1" width="100%">
															<tr>
																<td width="75%" align="left">50/50 Estimate of Total Papermaking Time Required, 
																	Including Set-up and Tear-down :</td>
																<td onkeypress="javascript: return AllowNumeric(event);" width="25%">&nbsp;&nbsp;
																	<asp:textbox id="txtPaperMaking" tabIndex="16" runat="server" Width="100px" MaxLength="6" ReadOnly="true"></asp:textbox>&nbsp;Day(s)</td>
															</tr>
															<tr>
																<td width="75%" align="left"><b>50/50 Estimate of Total Converting Time Required, 
																		Including Set-up and Tear-down :</b></td>
																<td onkeypress="javascript: return AllowNumeric(event);" width="25%">&nbsp;&nbsp;
																	<asp:textbox id="txtConvertingTime" tabIndex="17" runat="server" Width="100px" MaxLength="6"
																		ReadOnly="true"></asp:textbox>&nbsp;Day(s)</td>
															</tr>
															<tr>
																<td width="75%" align="left">Estimated Total Cost of New Materials Being Ordered 
																	Prior to Final EO Approval :</td>
																<td onkeypress="javascript: return AllowNumeric(event);" width="25%">$
																	<asp:textbox id="txtCostNewMaterials" tabIndex="18" runat="server" Width="100px" MaxLength="8"></asp:textbox></td>
															</tr>
															<tr>
																<td width="75%" align="left">Estimated Cost of Any EO Specific Equipment Being 
																	Ordered Prior to Final EO Approval :</td>
																<td onkeypress="javascript: return AllowNumeric(event);" width="25%">$
																	<asp:textbox id="txtEOEquipment" tabIndex="19" runat="server" Width="100px" MaxLength="8"></asp:textbox></td>
															</tr>
															<tr>
																<td width="75%" align="left">Total Pre-Spending :</td>
																<td width="25%">$
																	<asp:textbox id="lbPreSpending" tabIndex="20" runat="server" Width="100px" ReadOnly="true" BorderColor="#ffffff"
																		BackColor="LightSteelBlue" BorderStyle="None"></asp:textbox></td>
															</tr>
															<tr>
																<td width="75%" align="left">EO Execution Cost :</td>
																<td onkeypress="javascript: return AllowNumeric(event);" width="25%">$
																	<asp:textbox id="txtExecutionCost" tabIndex="21" runat="server" Width="100px" MaxLength="8"></asp:textbox></td>
															</tr>
															<tr>
																<td width="75%" align="left">Total Cost :</td>
																<td width="25%">$
																	<asp:textbox id="lbTotalCost" tabIndex="22" runat="server" Width="100px" ReadOnly="true" BorderColor="#ffffff"
																		BackColor="LightSteelBlue" BorderStyle="None"></asp:textbox></td>
															</tr>
															<tr>
																<td width="75%"></td>
																<td width="25%"><asp:linkbutton id="lnkRecal" tabIndex="23" runat="server" 
                                                                        CausesValidation="False" onclick="lnkRecal_Click1">Re Calculate</asp:linkbutton></td>
															</tr>
														</TABLE>
														<BR>
														<TABLE id="Table4" class="AlternateSection1" width="100%">
															<tr>
																<td width="100%" colSpan="2">
                                                                   <asp:UpdatePanel ID="upllink" runat="server">
                                                                <ContentTemplate>                                                                
                                                                <asp:linkbutton id="lnkCostSheetTemplate" runat="server" CausesValidation="False" onclick="lnkCostSheetTemplate_Click">Click Here to go to the Cost Sheet template </asp:linkbutton>
                                                                  </ContentTemplate>
                                                                        <Triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkCostSheetTemplate" />
                                                                        </Triggers>
                                                                </asp:UpdatePanel>
                                                                        </td>
															</tr>
															<tr>
																<td style="WIDTH: 610px" width="610" align="right">Suggested Budget Center 
																	:&nbsp;&nbsp;</td>
																<td width="50%"><asp:textbox id="txtSelectedBudgCenter" runat="server" Width="300px" MaxLength="50"></asp:textbox></td>
															</tr>
															<tr>
																<td style="WIDTH: 610px; HEIGHT: 21px" width="610" align="right">Selected&nbsp;Budget 
																	Center : &nbsp;</td>
																<td style="HEIGHT: 21px" width="50%"><asp:dropdownlist id="drpBudgetCenterDB" 
                                                                        runat="server" Width="300px" AutoPostBack="true" 
                                                                        onselectedindexchanged="drpBudgetCenterDB_SelectedIndexChanged"></asp:dropdownlist><FONT class="astrisk" color="red">*</FONT></td>
															</tr>
															<tr>
																<td style="WIDTH: 610px" width="610"></td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);" width="50%"><asp:label id="lblOhterBudMessage" runat="server" Width="288px" CssClass="NoteMsg" Height="20px">If "Other" is selected, Please enter your Budget Center or Department number below:</asp:label><BR>
																	<br /><asp:textbox id="txtOtherBudgetCenter" runat="server" Width="300px" MaxLength="50" Enabled="False"></asp:textbox></td>
															</tr>
															<tr>
																<td style="WIDTH: 610px" width="610" align="right"></td>
																<td width="50%"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%--closing of General Preliminary --%>
																								<tr id="TrGeneralPreliminaryRO" runat="server">
                                                    <%--opening preliminary general section -- Read only--%>
													<td width="100%" colSpan="4">
														<TABLE id="TABLE9" class="AlternateSection1" width="100%"> <!-- Preliminary General Navigation Table -->
															<tr>
																<TD style="HEIGHT: 19px" width="25%" align="right">EO Type :&nbsp;</TD>
																<TD style="HEIGHT: 19px" width="25%"><asp:label id="lblEOType" runat="server"></asp:label></TD>
																<TD style="HEIGHT: 19px" width="25%" align="right">EO Scope/Project Phase :&nbsp;</TD>
																<TD style="HEIGHT: 19px" width="25%"><asp:label id="lblEOScopeProjectPhase" runat="server"></asp:label></TD>
															</tr>
															<TR>
																<td align="right">Other EO Type :&nbsp;</td>
																<td>
																	<P><asp:label id="lblOtherEOType" runat="server"></asp:label></P>
																</td>
																<td align="right">Other EO Scope/Project Phase :&nbsp;</td>
																<td><asp:label id="lblEOScopeProjectPhaseOther" runat="server"></asp:label></td>
															</TR>
														</TABLE>
														<TABLE id="Table10" class="AlternateSection1" width="100%">
															<TR>
																<TD width="25%" align="right">Brief Description :&nbsp;</TD>
																<TD width="75%"><asp:label id="lblBriefDecription" runat="server"></asp:label></TD>
															</TR>
														</TABLE>
														<BR>
														<TABLE id="Table11" class="AlternateSection1" width="100%">
															<TR>
																<TD width="75%" align="left">50/50 Estimate of Total Papermaking Time Required, 
																	Including Set-up and Tear-down :</TD>
																<TD onkeypress="javascript: return AllowNumeric(event);" width="25%"><asp:label id="lblTotPaperMakingTime" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left"><b>50/50 Estimate of Total Converting Time Required, 
																		Including Set-up and Tear-down :</b></TD>
																<TD onkeypress="javascript: return AllowNumeric(event);" width="25%"><asp:label id="lblTotPaperConvertingTime" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Estimated Total Cost of New Materials Being Ordered 
																	Prior to Final EO Approval :</TD>
																<TD onkeypress="javascript: return AllowNumeric(event);" width="25%"><asp:label id="lblTotCostOfNewMaterials" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Estimated Cost of Any EO Specific Equipment Being 
																	Ordered Prior to Final EO Approval :</TD>
																<TD onkeypress="javascript: return AllowNumeric(event);" width="25%"><asp:label id="lblTotCostOfanyEPSpecific" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Total Pre-Spending :</TD>
																<TD width="25%"><asp:label id="lblTotPreSpending" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">EO Execution Cost :</TD>
																<TD onkeypress="javascript: return AllowNumeric(event);" width="25%"><asp:label id="lblEoExecutionCost" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Total Cost :</TD>
																<TD width="25%"><asp:label id="lblTotCost" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%"></TD>
																<TD width="25%"></TD>
															</TR>
														</TABLE>
														<BR>
														<TABLE id="Table12" class="AlternateSection1" width="100%">
															<TR>
																<TD style="WIDTH: 612px" width="612" align="right">Suggested Budget Center :
																</TD>
																<TD width="50%"><asp:label id="lblSelectedBudgetCenter" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 612px" width="612" align="right">Selected&nbsp;Budget Center :</TD>
																<TD width="50%"><asp:label id="lblSuggestedBudCenter" runat="server"></asp:label></TD>
															</TR>
															<tr>
																<td style="WIDTH: 612px" width="612" align="right">Other Selected&nbsp;Budget 
																	Center :</td>
																<td width="50%"><asp:label id="lblOtherSuggestedBudCenter" runat="server"></asp:label></td>
															</tr>
														</TABLE>
													</td>
												</tr>

                                                <%--closing of General Preliminary --Read Only--%>
												<tr id="NewMaterialandBrands" runat="server">
                                                    <%-- Opening of Material Brands --%>
													<td width="100%" colSpan="4">
														<TABLE id="Table1" class="AlternateSection2" width="100%">
															<tr>
																<td class="Header" width="100%" colSpan="2">New Materials and Brands</td>
															<tr>
																<td width="75%" align="left">
																	<P>Do new Raw and/or Packing Materials need to be activated for this EO or EO Site?<BR>
																		<asp:label id="Label29" runat="server" Width="288px" CssClass="NoteMsg" Height="20px">If 'Yes', please list the GCAS numbers below</asp:label><asp:label id="Label30" runat="server" Width="500px" CssClass="NoteMsg" Height="20px">If these codes are not already established in GMDB, please complete a GMDB request.</asp:label></P>
																</td>
																<td width="25%"><asp:radiobuttonlist id="rbRawMaterial" runat="server" 
                                                                        AutoPostBack="true" RepeatDirection="Horizontal" 
                                                                        onselectedindexchanged="rbRawMaterial_SelectedIndexChanged">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<TR>
																<TD width="75%" align="left">
																	<P>Will the EO produce Parent Rolls that need to be tracked and controlled 
																		separately from normal production?<BR>
																		<asp:label id="Label31" runat="server" Width="288px" CssClass="NoteMsg" Height="20px">If 'Yes', please list the GCAS numbers below</asp:label><asp:label id="Label32" runat="server" Width="500px" CssClass="NoteMsg" Height="20px">If these codes are not already established in GMDB, please complete a GMDB request.</asp:label></P>
																</TD>
																<TD width="25%"><asp:radiobuttonlist id="rbParentRolls" runat="server" 
                                                                        AutoPostBack="True" RepeatDirection="Horizontal" 
                                                                        onselectedindexchanged="rbParentRolls_SelectedIndexChanged">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></TD>
															</TR>
															<tr>
																<td width="75%" align="left">Will the EO produce or involve any other
																	<asp:linkbutton id="lnkInterMaterials" runat="server" CausesValidation="False" 
                                                                       >Intermediate Materials</asp:linkbutton>&nbsp;that 
																	are new to this site?</td>
																<td width="25%"><asp:radiobuttonlist id="rbInterMaterials" runat="server" 
                                                                        AutoPostBack="true" RepeatDirection="Horizontal" 
                                                                        onselectedindexchanged="rbInterMaterials_SelectedIndexChanged">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td colSpan="2">
																	<table width="100%" height="100%">
																		<tr>
																			<td width="75%" align="left"><B>Is this EO for the production of Regulated Product?</B></td>
																			<td width="25%"><asp:radiobuttonlist id="rbRegulatedProduct" runat="server" RepeatDirection="Horizontal">
																					<asp:ListItem Value="Yes">Yes</asp:ListItem>
																					<asp:ListItem Value="No">No</asp:ListItem>
																				</asp:radiobuttonlist></td>
																		</tr>
																	</table>
																</td>
															<tr>
																<td colSpan="2">
																	<table width="100%" height="100%">
																		<tr>
																			<td width="75%" align="left"><B>For ALL regulated products, please mark the appropriate 
																					GMP Classification</B></td>
																			<td width="25%">Cosmetic
																				<asp:checkbox id="chkGMPClassify" Runat="server" Text=""></asp:checkbox></td>
																		</tr>
																	</table>
																</td>
															<tr>
																<td width="75%" align="left">Will any product from the EO be shipped to the trade 
																	as a current brand?</td>
																<td width="25%"><asp:radiobuttonlist id="rbShipped" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr id="trMaterialsBrandsNewRow1" runat="server" Visible="false">
																<td width="75%" align="left"><br>
																	If any EO product will be shipped into existing brand codes (blind shipping), 
																	you must determine if a P&amp;G Policy 37 exception is needed.&nbsp;&nbsp;Refer 
																	to the Family Care Job Aid for more information.&nbsp; If an exception is 
																	needed, it must be approved prior to running the EO.
																	<br>
																	<br>
																	Link to Job Aid (on MUR EO Teamspace):
																	<br>
																	<br>
																	<a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc"
																		target="_blank">http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc</a>
																	<br>
																</td>
																<td width="25%"></td>
															</tr>
															<tr>
																<td colSpan="2">
																	<div style="DISPLAY: none" id="divMaterialsBrandsNewRow2" runat="server">
																		<table>
																			<tr>
																				<td width="75%" align="left"><br>
																					<asp:label id="lblMaterialsBrands" Runat="server" Font-Bold="true" Font-Size="14px">Please Select one of the following:</asp:label><br>
																					<br>
																					<asp:checkboxlist id="chkMaterialsBrands" Runat="server" Font-Bold="true" Font-Size="14px" RepeatDirection="Vertical">
																						<asp:ListItem Value="I understand Policy 37 requirements for Family Care. &#160;A Policy 37 exception is not required for this EO">I understand Policy 37 requirements for Family Care. &#160;A Policy 37 exception is not required for this EO</asp:ListItem>
																						<asp:ListItem Value="A Policy 37 exception is required and will be complete before executing this EO.">A Policy 37 exception is required and will be complete before executing this EO.</asp:ListItem>
																						<asp:ListItem Value="This EO is already covered by an existing Policy 37 exception.">This EO is already covered by an existing Policy 37 exception.</asp:ListItem>
																					</asp:checkboxlist></td>
																				<td width="25%"></td>
																			</tr>
																		</table>
																	</div>
																</td>
															</tr>
															<tr>
																<td width="75%" align="left">Will any test product/samples be shipped out of the 
																	plant for consumer/lab evaluation?</td>
																<td width="25%"><asp:radiobuttonlist id="rbTestProductedShipped" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td width="75%" align="left">Will you be using any Contingent GCAS #s unique to 
																	product and not ordered via UMOF?</td>
																<td width="25%"><asp:radiobuttonlist id="rbGCASNumber" runat="server" CssClass="FormatToControls" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td width="75%" colSpan="2" align="left">If you checked "Yes" to any of the 
																	questions above, please list all new materials including Regulated and 
																	Developmental to ensure proper SAP establishment.</td>
															</tr>
															<tr>
																<td width="75%" colSpan="2"><asp:imagebutton id="btnAddGCAS" runat="server" 
                                                                        CausesValidation="False" ImageUrl="../Images/add-gcas.gif" 
                                                                        onclick="btnAddGCAS_Click"></asp:imagebutton><asp:textbox id="txttest" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox><asp:textbox id="txtGCASYESNOOptionValue" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox></td>
															</tr>
															<tr>
																<td width="75%" colSpan="2" align="center">
                                                                    <asp:datagrid id="dgdGCASInfo" BorderWidth="1" GridLines="Both"
                                                                        runat="server" Width="70%" BorderColor="#404040" AutoGenerateColumns="true" 
																		HeaderStyle-CssClass="SubHeaderGrid" onitemcommand="dgdGCASInfo_ItemCommand" onitemdatabound="dgdGCASInfo_ItemDataBound">
																		<HeaderStyle CssClass="Header"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn>
																				<ItemTemplate>
																					<asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" Visible="true"
																						ID="Linkbutton1"></asp:LinkButton>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn>
																				<ItemTemplate>
																					<asp:LinkButton runat="server" Text="Delete" CommandName="Del" CausesValidation="false" ID="lnkDel"></asp:LinkButton>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid></td>
															</tr>
															<tr>
																<td width="75%" colSpan="2">
                                                                   <asp:UpdatePanel ID="upNewGCASNumber" runat="server">
                                                                <ContentTemplate>
                                                                <asp:linkbutton id="lnkNewGCASNumber" runat="server" 
                                                                        CausesValidation="False" onclick="lnkNewGCASNumber_Click">Click Here to view the steps needed to initiate a new GCAS Number </asp:linkbutton>
                                                                         </ContentTemplate>
                                                                        <Triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkNewGCASNumber" />
                                                                        </Triggers>
                                                                </asp:UpdatePanel>
                                                                        </td>
															</tr>
															<tr>
																<td width="75%" colSpan="2">
                                                                    <asp:UpdatePanel ID="upUMOF" runat="server">
                                                                <ContentTemplate>
                                                                <asp:linkbutton id="lnkUMOF" runat="server" 
                                                                        CausesValidation="False" onclick="lnkUMOF_Click">Click Here to go to the UMOF template </asp:linkbutton>
                                                                          </ContentTemplate>
                                                                        <Triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkUMOF" />
                                                                        </Triggers>
                                                                          </asp:UpdatePanel>
                                                                        </td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%--Closing of NewMaterialBrands --%>
												<tr id="NewMaterialandBrandsReadOnly" runat="server">
                                                    <%-- Opening of Material Brands - ReadOnly --%>
													<td width="100%" colSpan="4">
														<TABLE id="tblNewMaterialandBrandsReadOnly" class="AlternateSection2" width="100%">
															<TR>
																<TD class="Header" width="100%" colSpan="2">New Materials and Brands</TD>
															<TR>
																<TD width="75%" align="left">
																	<P>Do new Raw and/or Packing Materials need to be activated for this EO or EO Site?</P>
																</TD>
																<TD width="25%"><asp:label id="lblNewRawPackMaterials" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">
																	<P>Will the EO produce Parent Rolls that need to be tracked and controlled 
																		separately from normal production?</P>
																</TD>
																<TD width="25%"><asp:label id="lblParentRolls" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Will the EO produce or involve any other
																	<asp:linkbutton id="Linkbutton9" runat="server" CausesValidation="False">Intermediate Materials</asp:linkbutton>&nbsp;that 
																	are new to this site?</TD>
																<TD width="25%"><asp:label id="lblEOProduceOrInvolve" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Is this EO for the production of Regulated Product?</TD>
																<TD width="25%"><asp:label id="lblIsRegulatedProduct" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">For ALL regulated products, please mark the 
																	appropriate GMP Classification</TD>
																<TD width="25%"><asp:label id="lblGMPClassification" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Will any product from the EO be shipped to the trade 
																	as a current brand?</TD>
																<TD width="25%"><asp:label id="lblCurrentBrand" runat="server"></asp:label></TD>
															</TR>
															<TR id="trProdRegulatedProductRAQ1" runat="server" Visible="false">
																<TD width="75%" align="left"><br>
																	If any EO product will be shipped into existing brand codes (blind shipping), 
																	you must determine if a P&amp;G Policy 37 exception is needed.&nbsp;&nbsp;Refer 
																	to the Family Care Job Aid for more information.&nbsp; If an exception is 
																	needed, it must be approved prior to running the EO.
																	<br>
																	<br>
																	Link to Job Aid (on MUR EO Teamspace):
																	<br>
																	<br>
																	<a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc"
																		target="_blank">http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc</a>
																	<br>
																</TD>
																<TD width="25%"></TD>
															</TR>
															<TR id="trProdRegulatedProductRAQ2" runat="server" Visible="false">
																<TD width="75%" align="left"><br>
																	Please Select one of the following:
																	<br>
																	<asp:checkboxlist id="chkMaterialsBrandsReadOnly" Runat="server" Visible="False" RepeatDirection="Vertical"
																		Enabled="False">
																		<asp:ListItem Value="I understand Policy 37 requirements for Family Care.  A Policy 37 exception is not required for this EO"></asp:ListItem>
																		<asp:ListItem Value="A Policy 37 exception is required and will be complete before executing this EO."></asp:ListItem>
																		<asp:ListItem Value="This EO is already covered by an existing Policy 37 exception."></asp:ListItem>
																	</asp:checkboxlist><br>
																	<table width="100%">
																		<tr>
																			<td width="5%" align="left"><asp:label id="lblYesNoMat1" Runat="server" Font-Bold="True" Font-Size="14px"></asp:label></td>
																			<td width="95%" align="left"><asp:label id="lblMat1" Runat="server" Font-Bold="True" Font-Size="14px">I understand Policy 37 requirements for Family Care.  A Policy 37 exception is not required for this EO</asp:label></td>
																		</tr>
																		<tr>
																			<td width="5%" align="left"><asp:label id="lblYesNoMat2" Runat="server" Font-Bold="True" Font-Size="14px"></asp:label></td>
																			<td width="95%" align="left"><asp:label id="lblMat2" Runat="server" Font-Bold="True" Font-Size="14px">A Policy 37 exception is required and will be complete before executing this EO.</asp:label></td>
																		</tr>
																		<tr>
																			<td width="5%" align="left"><asp:label id="lblYesNoMat3" Runat="server" Font-Bold="True" Font-Size="14px"></asp:label></td>
																			<td width="95%" align="left"><asp:label id="lblMat3" Runat="server" Font-Bold="True" Font-Size="14px">This EO is already covered by an existing Policy 37 exception.</asp:label></td>
																		</tr>
																	</table>
																	<br>
																</TD>
																<TD width="25%"></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Will any test product/samples be shipped out of the 
																	plant for consumer/lab evaluation?</TD>
																<TD width="25%"><asp:label id="lblLabEvaluation" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" align="left">Will you be using any Contingent GCAS #s unique to 
																	product and not ordered via UMOF?</TD>
																<TD width="25%"><asp:label id="lblUMOF" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD width="75%" colSpan="2" align="left">If you checked "Yes" to any of the 
																	questions above, please list all new materials including Regulated and 
																	Developmental to ensure proper SAP establishment.</TD>
															</TR>
															<TR>
																<TD width="75%" colSpan="2"></TD>
															</TR>
															<TR>
																<TD width="75%" colSpan="2" align="center">
                                                                <asp:datagrid id="dgdGCASInfoRO" runat="server" Width="70%" BorderColor="#404040" AutoGenerateColumns="true"
																		HeaderStyle-CssClass="SubHeaderGrid">
                                                                    <HeaderStyle CssClass="Header" />
																	</asp:datagrid></TD>
															</TR>
															<TR>
																<TD width="75%" colSpan="2"></TD>
															</TR>
															<TR>
																<TD width="75%" colSpan="2"></TD>
															</TR>
														</TABLE>
													</td>
												</tr>
                                                <%--Closing of NewMaterialBrands - ReadOnly --%>
												<tr id="HSandSE" runat="server">
                                                    <%-- Opening of HS and SE--%>
													<td width="100%" colSpan="4">
														<TABLE id="TableHSandSE" class="AlternateSection1" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2"><asp:label id="Label17" runat="server">HS&E</asp:label></td>
															</tr>
															<tr>
																<td width="100%" colSpan="2">&nbsp;
																	<asp:label id="Label33" runat="server" CssClass="NoteMsg">Please choose the following that apply to this EO.</asp:label></td>
															</tr>
															<tr>
																<td width="100%" colSpan="2">A “YES” to any of the following questions for this 
																	test request will require HS&amp;E approval on the final stage routing.</td>
															</tr>
															<tr>
																<td width="100%" colSpan="2">Please consult your
																	<asp:linkbutton id="lnkHSE" runat="server" CausesValidation="False">Family Care HS&E contact </asp:linkbutton>&nbsp;for 
																	further information on HS&amp;E reviews.</td>
															</tr>
															<tr>
																<td height="20" width="100%" colSpan="2"></td>
															</tr>
															<tr>
																<td width="75%">Does this project involve a
																	<asp:linkbutton id="lnkNewChemical" runat="server" CausesValidation="False">new chemical or a change </asp:linkbutton>&nbsp;in 
																	the use of an existing chemical?</td>
																<td width="25%"><asp:radiobuttonlist id="rbChemical" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td borderColorLight="#000000" width="75%">Does this project involve a
																	<asp:linkbutton id="lnkNewRawMaterial" runat="server" CausesValidation="False"> new raw material or a change</asp:linkbutton>&nbsp;in 
																	the physical properties of an existing raw material?</td>
																<td borderColorLight="#000000" width="25%"><asp:radiobuttonlist id="rbNewRawMaterial" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td width="75%">Does this project require
																	<asp:linkbutton id="lnkNewEquipment" runat="server" CausesValidation="False"> new equipment/ process/ supporting systems or a change</asp:linkbutton>&nbsp;in 
																	existing equipment/process/ supporting system?</td>
																<td width="25%"><asp:radiobuttonlist id="rbNewEquipment" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td style="HEIGHT: 3px" width="75%">Does this project require a
																	<asp:linkbutton id="lnkNewJob" runat="server" CausesValidation="False"> new job/task or a change </asp:linkbutton>&nbsp;in 
																	the way a job/ task is performed?</td>
																<td style="HEIGHT: 3px" width="25%"><asp:radiobuttonlist id="rbNewJobTask" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="Yes">Yes</asp:ListItem>
																		<asp:ListItem Value="No">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td width="75%"></td>
																<td width="25%"></td>
															</tr>
															<tr>
																<td width="75%">If you answered “YES” to one or more of the above questions, click
																	<asp:linkbutton id="lnkHere" runat="server" CausesValidation="False">here</asp:linkbutton>&nbsp;for 
																	Additional Information</td>
																<td width="25%"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%--Closing of HS and SE --%>
												<tr id="HSandSEReadOnly" runat="server">
													<td width="100%" colSpan="4">
														<TABLE id="tblHSandSEReadOnly" class="AlternateSection1" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">HS&amp;E</td>
															</tr>
															<tr>
																<td width="100%" colSpan="2">&nbsp;</td>
															</tr>
															<tr>
																<td width="100%" colSpan="2">A “YES” to any of the following questions for this 
																	test request will require HS&amp;E approval on the final stage routing.</td>
															</tr>
															<tr>
																<td width="100%" colSpan="2">Please consult your
																	<asp:linkbutton id="Linkbutton16" runat="server" CausesValidation="False">Family Care HS&E contact </asp:linkbutton>&nbsp;for 
																	further information on HS&amp;E reviews.</td>
															</tr>
															<tr>
																<td width="75%">Does this project involve a
																	<asp:linkbutton id="Linkbutton17" runat="server" CausesValidation="False">new chemical or a change </asp:linkbutton>&nbsp;in 
																	the use of an existing chemical?</td>
																<td width="25%"><asp:label id="lblExistingChemical" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td borderColorLight="#000000" width="75%">Does this project involve a
																	<asp:linkbutton id="Linkbutton18" runat="server" CausesValidation="False"> new raw material or a change</asp:linkbutton>&nbsp;in 
																	the physical properties of an existing raw material?</td>
																<td borderColorLight="#000000" width="25%"><asp:label id="lblPhysicalProperties" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="75%">Does this project require
																	<asp:linkbutton id="Linkbutton19" runat="server" CausesValidation="False"> new equipment/ process/ supporting systems or a change</asp:linkbutton>&nbsp;in 
																	existing equipment/process/ supporting system?</td>
																<td width="25%"><asp:label id="lblEqupProcessSupSystem" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td style="HEIGHT: 3px" width="75%">Does this project require a
																	<asp:linkbutton id="Linkbutton20" runat="server" CausesValidation="False"> new job/task or a change </asp:linkbutton>&nbsp;in 
																	the way a job/ task is performed?</td>
																<td style="HEIGHT: 3px" width="25%"><asp:label id="lblNewJobTask" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="75%"></td>
																<td width="25%"></td>
															</tr>
															<tr>
																<td width="75%">If you answered “YES” to one or more of the above questions, click
																	<asp:linkbutton id="Linkbutton21" runat="server" CausesValidation="False">here</asp:linkbutton>&nbsp;for 
																	Additional Information</td>
																<td width="25%"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
												<tr id="PSandRA" runat="server">
                                                    <%--opening of PSRA--%>
													<td width="100%" colSpan="4">
														<TABLE id="Table5" class="AlternateSection2" width="100%">
															<tr style="width:100%">
																<td class="Header" bgColor="#6699ff" width="100%">PS&amp;RA</td>
															</tr>
															<tr style="width:100%">
																<td width="100%">
																	<div id="divPSRAAdded" runat="server">
																		<table class="AlternateSection2" width="100%">
																			<tr style="width:100%">
																				<td width="75%">Will any product go to consumers?</td>
																				<td width="25%"><asp:radiobuttonlist id="rblProductConsumers" onclick="CheckProductConsumerOption();" Runat="server"
																						RepeatDirection="Horizontal">
																						<asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
																						<asp:ListItem Selected="False" Value="No"></asp:ListItem>
																					</asp:radiobuttonlist></td>
																			</tr>
																			<tr style="width:100%">
																				<td width="75%">Are you using an approved FC or ATS? ("approved" means current 
																					version in CSS)
																				</td>
																				<td width="25%"><asp:radiobuttonlist id="rblProductApproved" onclick="CheckProductApprovedOption();" Runat="server" RepeatDirection="Horizontal">
																						<asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
																						<asp:ListItem Selected="False" Value="No"></asp:ListItem>
																					</asp:radiobuttonlist></td>
																			</tr>
																		</table>
																	</div>
																</td>
															</tr>
															<tr style="width:100%">
																<td width="100%">
																	<div id="divPSRAAddedRawMaterials" runat="server" style="DISPLAY: none">
																		<table class="AlternateSection2" width="100%">
																			<tr style="width:100%">
																				<td width="75%">Are all Raw Materials approved at the appropriate level (1-5)?</td>
																				<td width="25%"><asp:radiobuttonlist id="rblRawMaterialsQ1" onclick="CheckRMQ1();" Runat="server" RepeatDirection="Horizontal">
																						<asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
																						<asp:ListItem Selected="False" Value="No"></asp:ListItem>
																					</asp:radiobuttonlist></td>
																			</TR>
																			<tr style="width:100%">
																				<td width="75%">Are all Raw Materials approved for the appropriate region (NA, 
																					Mexico)?</td>
																				<td width="25%"><asp:radiobuttonlist id="rblRawMaterialsQ2" onclick="CheckRMQ2();" Runat="server" RepeatDirection="Horizontal">
																						<asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
																						<asp:ListItem Selected="False" Value="No"></asp:ListItem>
																					</asp:radiobuttonlist></td>
																			</TR>
																			<tr style="width:100%">
																				<td width="75%">Are all Raw Materials approved for the application (tissue, towel)?</td>
																				<td width="25%"><asp:radiobuttonlist id="rblRawMaterialsQ3" onclick="CheckRMQ3();" Runat="server" RepeatDirection="Horizontal">
																						<asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
																						<asp:ListItem Selected="False" Value="No"></asp:ListItem>
																					</asp:radiobuttonlist></td>
																			</TR>
																			<tr style="width:100%">
																				<td width="75%">Are all Raw Materials approved at the previously approved 
																					application rate?</td>
																				<td width="25%"><asp:radiobuttonlist id="rblRawMaterialsQ4" onclick="CheckRMQ4();" Runat="server" RepeatDirection="Horizontal">
																						<asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
																						<asp:ListItem Selected="False" Value="No"></asp:ListItem>
																					</asp:radiobuttonlist></td>
																			</TR>
																			<tr style="width:100%">
																				<td width="75%"><br>
																					Link to One Point Lesson (OPL) for PS&amp;RA questions:<br>
																					<br>
																					<a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B"
																						target="_blank">http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B</a>
																					<br>
																				</td>
																				<td width="25%"></td>
																			</TR>
																		</table>
																	</div>
																</td>
															</tr>
															<tr style="width:100%">
																<td width="100%">
																	<div id="divPSRARemoved" runat="server" style="DISPLAY: none">
																		<table id="Table8" class="AlternateSection2" width="100%" runat="server">
																			<TR width="100%">
																				<TD style="HEIGHT: 14px" width="100%"><asp:label id="Label34" runat="server" Visible="True" CssClass="NoteMsg">NOTE: PS&amp;RA Approval Required if any apply. If you are not sure, contact Burney Schwab (634-7879)</asp:label></TD>
																			</TR>
																			<TR width="100%">
																				<TD width="100%"><asp:listbox id="lbPSRADB" runat="server" Width="300px" SelectionMode="Multiple"></asp:listbox></TD>
																			</TR>
																			<TR width="100%">
																				<TD width="100%"><asp:linkbutton id="lnkViewSelection" runat="server" CausesValidation="False">View Selections</asp:linkbutton></TD>
																			</TR>
																			<TR>
																				<TD width="50%"><asp:label id="lblSelectedPSRA" runat="server"></asp:label></TD>
																			</TR>
																			<TR width="100%">
																				<TD width="100%"><asp:label id="lblPSRAMessage2" runat="server" ForeColor="Green" Font-Bold="True">Please provide additional information if you selected "Other":</asp:label><asp:textbox id="txtPSRAOther" runat="server" Width="600px" Rows="2" MaxLength="1000" ToolTip="Please enter PSRA Additional information of max 1000 characters."
																						TextMode="MultiLine"></asp:textbox>&nbsp;
																					<asp:label id="Label3" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 Characters</asp:label></TD>
																			</TR>
																			<TR width="100%">
																				<TD width="100%"><asp:imagebutton id="btnAddPSRA" runat="server" CausesValidation="False" ImageUrl="../Images/add-ps-ra-information.gif"></asp:imagebutton><asp:textbox id="txtPSRAtest" runat="server" Width="0px"></asp:textbox><asp:textbox id="txtPSRAYESNOOptionValue" runat="server" Width="0px"></asp:textbox></TD>
																			</TR>
																		</table>
																	</div>
																</td>
															</tr>
															<tr style="width:100%">
																<td width="100%" align="center"><asp:datagrid id="dgdPSRAInfo" runat="server" 
                                                                        Width="75%" BorderColor="#404040" AutoGenerateColumns="true" 
                                                                        onitemcommand="dgdPSRAInfo_ItemCommand">
																		<HeaderStyle CssClass="Header"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn>
																				<ItemTemplate>
																					<asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" ID="lnkPSRAEdit"
																						Visible="true"></asp:LinkButton>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn>
																				<ItemTemplate>
																					<asp:LinkButton runat="server" Text="Delete" CommandName="Del" CausesValidation="false" ID="lnkPSRADel"></asp:LinkButton>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%--Closing of PSRA--%>
												<tr id="PSandRAReadOnly" runat="server" Visible="true">
													<td width="100%" colSpan="4">
														<TABLE id="tblPSandRAReadOnly" class="AlternateSection2" width="100%">
															<TR width="100%">
																<TD class="Header" bgColor="#6699ff" width="100%"><asp:label id="Label48" runat="server">PS&RA</asp:label></TD>
															</TR>
															<TR width="100%">
																<TD style="HEIGHT: 14px" width="100%"><asp:label id="Label49" runat="server" CssClass="NoteMsg">NOTE: PS&amp;RA Approval Required if any apply. If you are not sure, contact Burney Schwab (634-7879)</asp:label></TD>
															</TR>
															<TR id="PSR1" runat="server" Visible="True" width="100%">
																<TD width="100%"><asp:label id="lblPSRADB" runat="server"></asp:label></TD>
															</TR>
															<TR id="PSR2" runat="server" Visible="True" width="100%">
																<TD width="100%"></TD>
															</TR>
															<TR id="PSR3" runat="server" Visible="True" width="100%">
																<TD width="100%"><asp:label id="Label50" runat="server" ForeColor="Green" Font-Bold="True"> Additional information if you selected "Other":</asp:label><asp:label id="lblOtherPSRADB" runat="server"></asp:label></TD>
															</TR>
															<TR id="PSR4" runat="server" Visible="True" width="100%">
																<TD width="100%"></TD>
															</TR>
															<TR id="PSR5" runat="server" Visible="True" width="100%">
																<TD width="100%" align="center"><asp:datagrid id="dgdPSRAInfoRO" runat="server" Width="75%" AutoGenerateColumns="true" BorderColor="#404040">
																		<HeaderStyle CssClass="Header"></HeaderStyle>
																	</asp:datagrid></TD>
															</TR>
															<tr id="TRPSRAChanged" runat="server" Visible="False" width="100%">
																<td width="100%">
																	<table class="AlternateSection2" width="100%">
																		<tr style="width:100%">
																			<td width="75%">Will any product go to consumers?</td>
																			<td width="25%"><asp:label id="lblReadonlyPSR1" Runat="server"></asp:label></td>
																		</TR>
																		<tr style="width:100%">
																			<td width="75%">Are you using an approved FC or ATS? ("approved" means current 
																				version in CSS)
																			</td>
																			<td width="25%"><asp:label id="lblReadonlyPSR2" Runat="server"></asp:label></td>
																		</tr>
																	</table>
																</td>
															</tr>
															<tr id="TRPSRAChanged1" runat="server" Visible="False" width="100%">
																<td>
																	<table class="AlternateSection2" width="100%">
																		<tr style="width:100%">
																			<td width="75%">Are all Raw Materials approved at the appropriate level (1-5)?</td>
																			<td width="25%"><asp:label id="lblReadonlyPSR3" Runat="server"></asp:label></td>
																		</TR>
																		<tr style="width:100%">
																			<td width="75%">Are all Raw Materials approved for the appropriate region (NA, 
																				Mexico)?</td>
																			<td width="25%"><asp:label id="lblReadonlyPSR4" Runat="server"></asp:label></td>
																		</TR>
																		<tr style="width:100%">
																			<td width="75%">Are all Raw Materials approved for the application (tissue, towel)?</td>
																			<td width="25%"><asp:label id="lblReadonlyPSR5" Runat="server"></asp:label></td>
																		</TR>
																		<tr style="width:100%">
																			<td width="75%">Are all Raw Materials approved at the previously approved 
																				application rate?</td>
																			<td width="25%"><asp:label id="lblReadonlyPSR6" Runat="server"></asp:label></td>
																		</TR>
																		<tr style="width:100%">
																			<td width="75%"><br>
																				Link to One Point Lesson (OPL) for PS&amp;RA questions:<br>
																				<br>
																				<a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B"
																					target="_blank">http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B</a>
																				<br>
																			</td>
																			<td width="25%"></td>
																		</TR>
																	</table>
																</td>
															</tr>
														</TABLE>
													</td>
												</tr>
												<tr id="PlanningandBudgetInfo" runat="server">
                                                    <%-- Opening of Planning and Budget Info --%>
													<td width="100%" colSpan="4">
														<TABLE id="TablePlanning" class="AlternateSection1" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">Planning and Budget 
																	Information</td>
															</tr>
															<tr>
																<td width="60%">Requested by EO Originator :</td>
																<td width="40%"></td>
															</tr>
															<tr>
																<td width="60%">Line(s)/Machine(s) :</td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);" width="40%"><asp:textbox id="txtMachine" runat="server" Width="200px" MaxLength="100"></asp:textbox></td>
															</tr>
															<tr>
																<td width="60%">Planned Start Date :</td>
																<td onkeypress="javascript: return AllowDateNumbers(event);" width="40%"><asp:textbox id="txtStartDate" runat="server" Width="200px" MaxLength="10"></asp:textbox><IMG style="CURSOR: hand" id="img2" onclick="OpenDateToWindow()" alt="To Date" src="../Images/calendar.gif"
																		runat="server"><asp:label id="Label22" runat="server">(e.g. 10/20/2010)</asp:label>
																	<asp:textbox id="txtHidDateFocus" runat="server" Width="0px" style="DISPLAY: none"></asp:textbox></td>
															</tr>
															<tr>
																<td width="60%"></td>
																<td width="40%"></td>
															</tr>
														</TABLE>
														<TABLE id="TablePlanning2" class="AlternateSection1" width="100%">
															<tr>
																<td width="60%">Please list the Formula Card Number(s) being used/altered for this 
																	EO :</td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);" width="40%"><asp:textbox id="txtFormulaCardNumber" runat="server" Width="200px" MaxLength="100"></asp:textbox></td>
															</tr>
															<tr>
																<td width="60%">Please list the IPS (Individual Pack Standard) GCAS Number(s) being 
																	used for this EO :</td>
																<td width="40%"><asp:textbox id="txtIPSGCAS" runat="server" Width="200px" MaxLength="50"></asp:textbox></td>
															</tr>
															<tr>
																<td width="60%"></td>
																<td width="40%"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%-- Closing of Planning and Budget Info --%>
												<tr id="PlanningandBudgetInfoReadOnly" runat="server">
													<td width="100%" colSpan="4">
														<TABLE id="tblPlanningandBudgetInfoReadOnly" class="AlternateSection1" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">Planning and Budget 
																	Information</td>
															</tr>
															<tr>
																<td width="60%">Requested by EO Originator :</td>
																<td width="40%"></td>
															</tr>
															<tr>
																<td width="60%">Lines(s)/Machine(s) :</td>
																<td width="40%"><asp:label id="lblLinesMachineRO" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="60%">Planned Start Date :</td>
																<td width="40%"><asp:label id="lblPlannesStDateRO" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="60%"></td>
																<td width="40%"></td>
															</tr>
														</TABLE>
														<TABLE id="tblPlanningandBudgetInfoReadonly2" class="AlternateSection1" width="100%">
															<tr>
																<td width="60%">Please list the Formula Card Number(s) being used/altered for this 
																	EO :</td>
																<td width="40%"><asp:label id="lblFormulaCardNORO" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="60%">Please list the IPS (Individual Pack Standard) GCAS Number(s) being 
																	used for this EO :</td>
																<td width="40%"><asp:label id="lblIPSGCAS" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="60%"></td>
																<td width="40%"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
												<tr id="ProductionandPackaging" class="AlternateSection2" runat="server">
                                                    <%-- Opening of Production and packaging --%>
													<td colSpan="4">
														<TABLE id="TableProduction" class="AlternateSection2" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">Production and 
																	Packaging</td>
															</tr>
															<tr>
																<td width="60%">Format(s) :</td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);" width="40%"><asp:textbox id="txtFormat" runat="server" Width="200px" MaxLength="50"></asp:textbox></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%-- Closing of Production and packaging --%>
												<tr id="ProductionandPackagingReadOnly" class="AlternateSection2" runat="server">
													<td colSpan="4">
														<TABLE id="tblProductionandPackagingReadOnly" class="AlternateSection2" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">Production and 
																	Packaging</td>
															</tr>
															<tr>
																<td width="60%">Format(s) :</td>
																<td width="40%"><asp:label id="lblFormats" runat="server"></asp:label></td>
															</tr>
														</TABLE>
													</td>
												</tr>
												<tr id="PackagingandDispositionPreliminary" runat="server">
                                                    <%-- opening of PackagingandDispositionPreliminary--%>
													<td width="100%" colSpan="4">
														<TABLE id="TablePackaging" class="AlternateSection1" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">Packaging / 
																	Disposition Information</td>
															</tr>
															<tr>
																<td style="HEIGHT: 72px" width="50%">Will any product be packed?</td>
																<td style="HEIGHT: 72px" width="50%"><asp:listbox id="lbProductPackedDB" runat="server" Width="300px" SelectionMode="Multiple"></asp:listbox></td>
															</tr>
															<tr>
																<td width="50%"><asp:checkbox id="chkCurrentPackaging" runat="server" Text="Current Packaging"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkExperimentalPackaging" runat="server" Text="Experimental Packaging"></asp:checkbox></td>
																<td width="50%"><asp:listbox id="lbPackaging" runat="server" Width="300px" SelectionMode="Multiple">
																		<asp:ListItem Value="0">Select Package</asp:ListItem>
																		<asp:ListItem Value="1">Brown Box</asp:ListItem>
																		<asp:ListItem Value="2">LCP</asp:ListItem>
																	</asp:listbox></td>
															<tr>
																<td style="HEIGHT: 14px" width="50%">Please select a type from below :
																	<asp:checkbox id="chkClearPoly" runat="server" Text="Clear Poly"></asp:checkbox>&nbsp;&nbsp;<asp:checkbox id="chkBlankKDF" runat="server" Text="Blank KDF"></asp:checkbox></td>
																<td style="HEIGHT: 14px" width="50%"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 22px" width="50%">Product Disposition :</td>
																<td style="HEIGHT: 22px" width="50%"><asp:dropdownlist id="drpProductDispositionDB" runat="server" Width="300px"></asp:dropdownlist></td>
															</tr>
															<tr>
																<td style="HEIGHT: 10px" width="50%">Additional Comments :</td>
																<td style="HEIGHT: 10px" width="50%"><asp:textbox id="txtAdditionalComments" runat="server" Width="400px" Rows="2" MaxLength="1000"
																		ToolTip="Please enter Additional comments of max 1000 characters." TextMode="MultiLine"></asp:textbox>&nbsp;
																	<asp:label id="Label7" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 Characters</asp:label></td>
															</tr>
															<tr>
																<td vAlign="top" width="50%">Will this EO produce product using a unique pallet 
																	pattern OR a sku that will require additional stability testing?</td>
																<td width="50%"><asp:radiobuttonlist id="rbPalletPattern" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="yes">Yes</asp:ListItem>
																		<asp:ListItem Value="no">No</asp:ListItem>
																	</asp:radiobuttonlist><asp:label id="lblPackagingMessage3" runat="server">if yes, which :</asp:label><asp:checkboxlist id="chkStackShipTesting" runat="server" Width="238px" RepeatDirection="Horizontal">
																		<asp:ListItem Value="stacktesting">Stack Testing</asp:ListItem>
																		<asp:ListItem Value="shiptesting">Ship Testing</asp:ListItem>
																	</asp:checkboxlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
															</tr>
															<tr>
																<td vAlign="top" width="50%">Material Disposition :</td>
																<td width="50%"><asp:dropdownlist id="drpMaterialDispositionDB" runat="server" Width="300px"></asp:dropdownlist><BR>
																	<asp:label id="lblPackagingComments" runat="server">Additional Comments: </asp:label><BR>
																	<asp:textbox id="txtMaterialComments" runat="server" Width="400px" Rows="2" MaxLength="1000"
																		ToolTip="Please enter Additional comments of max 1000 characters." TextMode="MultiLine"></asp:textbox>&nbsp;
																	<asp:label id="Label15" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 Characters</asp:label></td>
															</tr>
															<tr>
																<td style="HEIGHT: 22px" width="50%"></td>
																<td style="HEIGHT: 22px" width="50%"></td>
															</tr>
															<tr>
																<td width="50%">Broke Disposition :</td>
																<td width="50%"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 43px" vAlign="top" width="50%">Will this EO generate greater 
																	than normal broke (log and/or loose)?</td>
																<td style="HEIGHT: 43px" width="50%"><asp:radiobuttonlist id="rbBroke" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="yes">Yes</asp:ListItem>
																		<asp:ListItem Value="no">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td vAlign="top" width="50%">Will any broke be printed broke?</td>
																<td width="50%"><asp:radiobuttonlist id="rbPrintedBroke" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="yes">Yes</asp:ListItem>
																		<asp:ListItem Value="no">No</asp:ListItem>
																	</asp:radiobuttonlist>If yes to printed broke, will any broke have an increase 
																	in the amount of ink coverage on the product?<asp:radiobuttonlist id="rbInkCoverage" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="yes">Yes</asp:ListItem>
																		<asp:ListItem Value="no">No</asp:ListItem>
																	</asp:radiobuttonlist></td>
															</tr>
															<tr>
																<td width="50%"></td>
																<td width="50%"></td>
															</tr>
															<tr>
																<td width="50%">Please attach any additional items pertaining to this EO here :</td>
																<td width="50%"><INPUT style="WIDTH: 465px; HEIGHT: 22px" id="txtAddPertaingEO" contentEditable="false"
																		size="58" type="file" name="txtAddPertaingEO" runat="server"></td>
															</tr>
															<tr>
																<td width="50%"><asp:placeholder id="p1" runat="server"></asp:placeholder></td>
																<td width="50%"><asp:listbox id="lbAddItemsEO" runat="server" Width="380px" Font-Size="XX-Small" CssClass="txtbox"
																		Height="50px"></asp:listbox>&nbsp;<asp:imagebutton id="imgAddAttachments" 
                                                                        runat="server" CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                                        onclick="imgAddAttachments_Click"></asp:imagebutton>&nbsp;&nbsp;<asp:imagebutton 
                                                                        id="imgDeleteAttach" runat="server" CausesValidation="False" 
                                                                        ImageUrl="../Images/delete.gif" onclick="imgDeleteAttach_Click"></asp:imagebutton>&nbsp;
																</td>
															</tr>
															<tr>
																<td width="50%"></td>
																<td width="50%"><asp:datagrid id="dgrdAttachment" Runat="server" Width="380px" 
                                                                        BorderColor="black" AutoGenerateColumns="False"
																		HeaderStyle-CssClass="SubHeader" GridLines="None" BorderWidth="1px" onitemcommand="dgrdAttachment_ItemCommand">
																		<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn>
																				<ItemTemplate>
                                                                                <asp:UpdatePanel ID="updpanlnkFinalattachment" runat="server" ><ContentTemplate>
																					<asp:LinkButton ID="lnkFinalattachment" CommandName="Final_Click" Visible="true" Runat="server"
																						CausesValidation="False">
																						<asp:Label text='<%# Eval("PDI_Attachment_File_Name")%>' Runat ="server" ID="lblFullfname" Visible=true >
																						</asp:Label>
																					</asp:LinkButton>
																					<asp:Label text='<%# Eval("PDI_Attach_ID")%>' Runat ="server" ID="lblFileName" Visible="false" >
																					</asp:Label></ContentTemplate>
                                                                                    <Triggers><asp:PostBackTrigger ControlID="lnkFinalattachment" /></Triggers> 
                                                                                    </asp:UpdatePanel>
																				</ItemTemplate>
																			</asp:TemplateColumn> 
																		</Columns>
																	</asp:datagrid></td>
															</tr>
															<tr>
																<td width="50%">Cincinnati Resources, please enter the number of your Lab Notebook 
																	(ex. WHS0867) here :<BR>
																	Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
																	634-7600</td>
																<td onkeypress="javascript: return NoSpecialCharacters(event);" width="50%"><asp:textbox id="txtLabNoteBook" runat="server" Width="200px" MaxLength="50"></asp:textbox></td>
															</tr>
															<tr>
																<td width="50%"></td>
																<td width="50%"></td>
															</tr>
															<TR>
																<TD width="50%">If you require training in the use of a Lab Notebook, click on the 
																	link below to begin the self paced web-based training.<BR>
																	NOTE: This training should take roughly 1.5 hours to complete.<BR>
																	<asp:linkbutton id="lnkNoteBookTraining" runat="server" CausesValidation="False">Interactive Lab Notebook Training</asp:linkbutton></TD>
																<TD width="50%"></TD>
															</TR>
															<tr>
																<td width="50%"><asp:label id="Label35" runat="server" CssClass="NoteMsg">Please enter any Comments to the Approvers here :</asp:label></td>
																<td width="50%"><asp:textbox id="txtPackagingComments" runat="server" Width="400px" MaxLength="1000" ToolTip="Please enter comments to Approvers of max 1000 characters."
																		TextMode="MultiLine"></asp:textbox>&nbsp;
																	<asp:label id="Label16" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 Characters</asp:label></td>
															</tr>
															<tr>
																<td width="50%"></td>
																<td width="50%"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%-- Closing of PackagingandDispositionPreliminary--%>
												<tr id="PackagingandDispositionPreliminaryReadOnly" runat="server">
													<td width="100%" colSpan="4">
														<TABLE id="tblPackagingandDispositionPreliminaryReadOnly" class="AlternateSection1" width="100%">
															<tr>
																<td class="Header" bgColor="#6699ff" width="100%" colSpan="2">Packaging / 
																	Disposition Information</td>
															</tr>
															<tr>
																<td style="HEIGHT: 24px" width="50%">Will any product be packed?</td>
																<td style="HEIGHT: 24px" width="50%"><asp:label id="lblProdBePacked" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="50%">Current Packaging :<asp:label id="lblCurrentPackagingRO" runat="server"></asp:label>&nbsp;&nbsp; 
																	Experimental Packaging :
																	<asp:label id="lblExperimPackagingRO" runat="server"></asp:label></td>
																<td width="50%"><asp:label id="lblPackaging" runat="server"></asp:label></td>
															<tr>
																<td style="HEIGHT: 14px" width="50%">Please select a type from below :&nbsp; 
																	Current Poly :
																	<asp:label id="lblClearPolyRO" runat="server"></asp:label>&nbsp; Blank KDF :
																	<asp:label id="lblBlankKDFRO" runat="server"></asp:label></td>
																<td style="HEIGHT: 14px" width="50%"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 22px" width="50%">Product Disposition :</td>
																<td style="HEIGHT: 22px" width="50%"><asp:label id="lbProductDisposition" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td style="HEIGHT: 10px" width="50%">Additional Comments :</td>
																<td style="HEIGHT: 10px" width="50%"><asp:label id="lbAdditionalCommnets" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td vAlign="top" width="50%">Will this EO produce product using a unique pallet 
																	pattern OR a sku that will require additional stability testing?</td>
																<td width="50%">
																	<P><asp:label id="lblUniquePallet" runat="server"></asp:label></P>
																	<P><asp:label id="Label54" runat="server">if yes, which :</asp:label></P>
																	<P>Stack Testing :
																		<asp:label id="lblStackTesting" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp; 
																		Ship Testing :
																		<asp:label id="lblShipTesting" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;</P>
																	<P><asp:label id="lblClearPoly" runat="server"></asp:label>&nbsp;
																		<asp:label id="lblBlankKDF" runat="server"></asp:label></P>
																</td>
															</tr>
															<tr>
																<td vAlign="top" width="50%">Material Disposition :</td>
																<td width="50%"><asp:label id="lblMaterialDisposition" runat="server"></asp:label><BR>
																	<asp:label id="Label55" runat="server">Additional Comments: </asp:label><BR>
																	<asp:label id="lblAdditionalMaterialDisposition" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="50%">Broke Disposition :</td>
																<td width="50%"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 39px" width="50%">Will this EO generate greater than normal 
																	broke (log and/or loose)?</td>
																<td style="HEIGHT: 39px" width="50%"><asp:label id="lblEOGraterNormalBroke" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td vAlign="top" width="50%">Will any broke be printed broke?</td>
																<td width="50%">
																	<P><asp:label id="lblPrinyBrokeRO" runat="server"></asp:label>&nbsp;</P>
																	<P>If yes to printed broke, will any broke have an increase in the amount of ink 
																		coverage on the product?</P>
																	<P><asp:label id="lblinkCovBrokeRO" runat="server"></asp:label></P>
																</td>
															</tr>
															<tr>
																<td width="50%">Please attach any additional items pertaining to this EO here :</td>
																<td width="50%"><asp:datagrid id="dgrdAttachment_ReadOnly" Runat="server" 
                                                                        Width="380px" BorderColor="black" AutoGenerateColumns="False"
																		HeaderStyle-CssClass="SubHeader" GridLines="None" ShowHeader="False" CellPadding="1" CellSpacing="1" 
                                                                        onitemcommand="dgrdAttachment_ReadOnly_ItemCommand1">
																		<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn>
																				<ItemTemplate>
                                                                                          <asp:UpdatePanel ID="updpanlnkFinalattachmentrO" runat="server" ><ContentTemplate>
																					<asp:LinkButton ID="lnkFinalattachmentrO" CommandName="Final_Click" Visible="true" Runat="server"
																						CausesValidation="False">
																						<asp:Label text='<%# Eval("PDI_Attachment_File_Name")%>' Runat ="server" ID="lblFullfnameRO" Visible=true >
																						</asp:Label>
																					</asp:LinkButton>
																					<asp:Label text='<%# Eval("PDI_Attach_ID")%>' Runat ="server" ID="lblFileNameRO" Visible="false" >
																					</asp:Label></ContentTemplate>
                                                                                    <Triggers><asp:PostBackTrigger ControlID="lnkFinalattachmentrO" /></Triggers> 
                                                                                    </asp:UpdatePanel>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid></td>
															</tr>
															<tr>
																<td width="50%">Cincinnati Resources, please enter the number of your Lab Notebook 
																	(ex. WHS0867) here :<BR>
																	Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
																	634-7600</td>
																<td width="50%"><asp:label id="lblLabNoteBookRO" runat="server"></asp:label></td>
															</tr>
															<tr>
																<td width="50%">If you require training in the use of a Lab Notebook, click on the 
																	link below to begin the self paced web-based training.<BR>
																	NOTE: This training should take roughly 1.5 hours to complete.<BR>
																</td>
																<td width="50%"></td>
															</tr>
															<tr>
																<td width="50%"><asp:label id="Label56" runat="server" CssClass="NoteMsg"> Comments to the Approvers :</asp:label></td>
																<td width="50%"><asp:label id="lblApproverComments" runat="server"></asp:label></td>
															</tr>
														</TABLE>
													</td>
												</tr>
												<!-- added by varma for View Comments -->
												<tr>
													<td width="100%" colSpan="4" align="left"><asp:hyperlink id="hylComments" Runat="server" Visible="False" NavigateUrl="javascript:void(0);">View Previous Comments</asp:hyperlink>
                                                  </td>
												</tr>
												<!-- end of section added by varma for View Comments -->
												<tr id="PreliminaryApprovals" runat="server">
                                                    <%-- opening of Preliminary Approvals --%>
													<td width="100%" colSpan="4">
														<TABLE id="TableApprovals" class="AlternateSection2" border="1" rules="all" width="100%">
															<tr>
																<td style="WIDTH: 703px" class="Header" bgColor="#6699ff" width="703" colSpan="3">Approvals</td>
															</tr>
															<tr>
																<td style="WIDTH: 703px" width="703" colSpan="3">Your approval group is :<asp:dropdownlist 
                                                                        id="drpPrelimApproval" runat="server" Width="300px" AutoPostBack="true" 
                                                                        onselectedindexchanged="drpPrelimApproval_SelectedIndexChanged"></asp:dropdownlist></td>
															</tr>
															<tr>
																<td style="WIDTH: 703px" width="703" colSpan="3">You can override these values by 
																	selecting the correct approver from the list.</td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Budget Owner :
																	<asp:label id="lblAPPBO" runat="server" Visible="False">Budget Center</asp:label></td>
																<td width="25%"><asp:textbox id="txtBudgetOwner" runat="server" Width="230px" 
                                                                        Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkBOChangeApp" runat="server" CausesValidation="False" 
                                                                        onclick="lnkBOChangeApp_Click">Change Approver</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">GBU HS&amp;E Resource :&nbsp;
																	<asp:label id="lblApprGBUHSE" runat="server" Visible="False">GBU HS&E Resource</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtGBUHSE" runat="server" Width="230px" 
                                                                        Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkGBUChangeApp" runat="server" CausesValidation="False" 
                                                                        onclick="lnkGBUChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkGBUFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkGBUFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Site HS&amp;E Resource :&nbsp;
																	<asp:label id="lblAppHSESite" runat="server" Visible="False">Site HS&E Resource</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtSiteHSE" runat="server" Width="230px" 
                                                                        Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkSiteHSEChangeApp" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSiteHSEChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkHSEFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkHSEFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 8px" vAlign="top" width="30%">Site Contact :
																	<asp:label id="lblAppSiteContact" runat="server" Visible="False">Site Contact</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td style="HEIGHT: 8px" width="30%"><asp:textbox id="txtSiteContact" runat="server" 
                                                                        Width="230px" Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkSiteContaChangeApp" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSiteContaChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkSiteContFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkSiteContFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Site Planning :
																	<asp:label id="lblAppSiteplan" runat="server" Visible="False">Site Planning</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtSitePlanning" runat="server" Width="230px" 
                                                                        Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkSitePlanChangeApp" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSitePlanChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkSitePlanFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkSitePlanFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Site QA (Brand Leader) :&nbsp;
																	<asp:label id="lblAppQAPrelim" runat="server" Visible="False">QA</asp:label><BR>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtQAPre" runat="server" Width="230px" 
                                                                        Enabled="False"></asp:textbox><BR>
																	<asp:linkbutton id="lnkQAPreChangeApp" runat="server" CausesValidation="False" 
                                                                        onclick="lnkQAPreChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkQAPreFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkQAPreFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Central QA :&nbsp;
																	<asp:label id="lblAppCentralQAPrelim" runat="server" Visible="False">Central QA</asp:label><BR>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtCentralQAPre" runat="server" Width="230px" 
                                                                         Enabled="False"></asp:textbox><BR>
																	<asp:linkbutton id="lnkCenralQAPreChangeApp" runat="server" 
                                                                        CausesValidation="False" onclick="lnkCenralQAPreChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkCentralQAPreFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkCentralQAPreFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 35px" vAlign="top" width="30%">Central Planning :&nbsp;
																	<asp:label id="lblAppCentralPlan" runat="server" Visible="False">Central Planning</asp:label></td>
																<td style="HEIGHT: 35px" vAlign="top" width="30%">
                                                                    <asp:textbox id="txtCentralPlanning" runat="server" Width="230px" 
                                                                         Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkCenPlanChangeApp" runat="server" 
                                                                        CausesValidation="False" onclick="lnkCenPlanChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkCentralPlanFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkCentralPlanFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">SAP Cost Center Coordinator :&nbsp;
																	<asp:label id="lblAppSAPCost" runat="server" Visible="False">SAP Cost Center Coordinator</asp:label></td>
																<td width="30%"><asp:textbox id="txtSAPCost" runat="server" Width="230px" 
                                                                         Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkSAPChangeApp" runat="server" CausesValidation="False" 
                                                                        onclick="lnkSAPChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkSAPFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkSAPFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<!--Added on 01/20/2010 
															For MUREO PCRs
															By: David-->
															<tr>
																<td vAlign="top" width="30%">SMART Clearance :&nbsp;    
																	<asp:label id="lblAppSmartClearance" runat="server" Visible="False">SMART Clearance </asp:label></td>
																<td width="30%"><asp:textbox id="txtSmartClearance" runat="server" Width="230px" 
                                                                         Enabled="False">Approval Not Needed</asp:textbox><br>
																	<asp:linkbutton id="lnkSmartClearanceApp" runat="server" Visible="false"
                                                                        CausesValidation="False" onclick="lnkSmartClearanceApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkSmartClearanceFYI" runat="server" Visible="false"
                                                                        CausesValidation="False"  onclick="lnkSmartClearanceFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 8px" vAlign="top" width="30%">Timing Gate Exception :&nbsp;
																	<asp:label id="lblAppTiminingGate" runat="server" Visible="False">Timing Gate Exception</asp:label></td>
																<td style="HEIGHT: 8px" width="30%"><asp:textbox id="txtTimingGate" runat="server" 
                                                                        Width="230px" Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkTGateChangeApp" runat="server" CausesValidation="False" 
                                                                        onclick="lnkTGateChangeApp_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkTGateFYI" runat="server" CausesValidation="False" 
                                                                        onclick="lnkTGateFYI_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Standards Office :&nbsp;
																	<asp:label id="lblAppStandsOffice" runat="server" Visible="False">Standards Office</asp:label></td>
																<td width="30%"><asp:textbox id="txtStandardOffice" runat="server" Width="230px" 
                                                                        Enabled="False"></asp:textbox><br>
																	<asp:linkbutton id="lnkStandsOffChangeApp" runat="server" 
                                                                        CausesValidation="False" onclick="lnkStandsOffChangeApp_Click">Change Approver</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Additional Approver1 :&nbsp;
																	<asp:label id="lblAdditionalApprover1a" runat="server" Visible="False">Additional approver #1</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtAdditionalApp1" runat="server" Width="230px" 
                                                                         Enabled="False">Approval Not Needed</asp:textbox><br>
																	<asp:linkbutton id="lnkAdditionalApp1" runat="server" CausesValidation="False" 
                                                                        onclick="lnkAdditionalApp1_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkAdditionalApp1FYIPrelim" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApp1FYIPrelim_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Additional Approver2 :&nbsp;
																	<asp:label id="lblAdditionalApprover2a" runat="server" Visible="False">Additional approver #2</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtAdditionalApp2" runat="server" Width="230px" 
                                                                         Enabled="False">Approval Not Needed</asp:textbox><br>
																	<asp:linkbutton id="lnkAdditionalApp2" runat="server" CausesValidation="False" 
                                                                        onclick="lnkAdditionalApp2_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkAdditionalApp2FYIPrelim" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApp2FYIPrelim_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Additional Approver3 :&nbsp;
																	<asp:label id="lblAdditionalApprover3a" runat="server" Visible="False">Additional approver #3</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtAdditionalApp3" runat="server" Width="230px" 
                                                                         Enabled="False">Approval Not Needed</asp:textbox><br>
																	<asp:linkbutton id="lnkAdditionalApp3" runat="server" CausesValidation="False" 
                                                                        onclick="lnkAdditionalApp3_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkAdditionalApp3FYIPrelim" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApp3FYIPrelim_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td vAlign="top" width="30%">Additional Approver4 :&nbsp;
																	<asp:label id="lblAdditionalApprover4a" runat="server" Visible="False">Additional approver #4</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="30%"><asp:textbox id="txtAdditionalApp4" runat="server" Width="230px" 
                                                                         Enabled="False">Approval Not Needed</asp:textbox><br>
																	<asp:linkbutton id="lnkAdditionalApp4" runat="server" CausesValidation="False" 
                                                                        onclick="lnkAdditionalApp4_Click">Change Approver</asp:linkbutton>&nbsp;
																	<asp:linkbutton id="lnkAdditionalApp4FYIPrelim" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApp4FYIPrelim_Click">FYI Not Necessary</asp:linkbutton></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
															<tr>
																<td style="HEIGHT: 20px" width="30%"></td>
																<td style="HEIGHT: 20px" width="30%"></td>
																<td style="WIDTH: 168px; HEIGHT: 20px" width="168"></td>
															</tr>
															<tr>
																<td width="30%"></td>
																<td width="30%"></td>
																<td style="WIDTH: 168px" width="168"></td>
															</tr>
														</TABLE>
													</td>
												</tr>
                                                <%-- Closing of Preliminary Approvals --%>
												<tr id="PreliminaryApprovalsReadOnly" runat="server">
													<td width="100%" colSpan="4">
														<TABLE id="tblPreliminaryApprovals" class="AlternateSection2" border="1" rules="all" width="100%">
															<tr>
																<td class="Header" colSpan="5">Approvals</td>
																<td class="Header"></td>
																<td class="Header"></td>
																<td class="Header" bgColor="#6699ff" width="100%"></td>
															</tr>
															<tr>
																<td colSpan="5">Your approval group is :
																	<asp:label id="lblPreliminaryAppGrp" runat="server"></asp:label></td>
																<td></td>
																<td></td>
																<td width="100%"></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgBudgetNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgBudgetYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Budget Owner :
																	<asp:label id="Label57" runat="server" Visible="False">Label</asp:label></td>
																<td width="25%"><asp:label id="lblBORO" runat="server"></asp:label><br>
																</td>
																<td width="10%"><asp:linkbutton id="lnkBudgetApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkBudgetApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkBudgetDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkBudgetDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreBOPreComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreBOBackUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPreBOBackUp_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgGbuHseNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgGbuHseYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">GBU HS&amp;E Resource :&nbsp;
																	<asp:label id="Label58" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="25%"><asp:label id="lblGBUHSERO" runat="server"></asp:label></td>
																<td width="10%"><asp:linkbutton id="lnkGBUHSEApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkGBUHSEApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkGBUHSEDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkGBUHSEDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreGBUHSEPreComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreGBUHSEBackUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPreGBUHSEBackUp_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgSiteHseNo" Runat="server" Visible="False" imageurl="..\Images\No.jpg"></asp:image><asp:image id="imgSiteHseYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Site HS&amp;E Resource :&nbsp;
																	<asp:label id="Label59" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="25%"><asp:label id="lblSiteHSERO" runat="server"></asp:label></td>
																<td width="10%"><asp:linkbutton id="lnkSiteHSEApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSiteHSEApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkSiteHSEDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSiteHSEDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreSiteHSEComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPresiteHSEBackUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPresiteHSEBackUp_Click">Back Up</asp:linkbutton></td>
															</tr>
															<TR>
																<td vAlign="top" width="3%"><asp:image id="imgSiteContactNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgSiteContactYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<TD vAlign="top" width="22%">Site Contact :
																	<asp:label id="Label60" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)</TD>
																<TD width="25%"><asp:label id="lblSiteContactRO" runat="server"></asp:label><br>
																	&nbsp;</TD>
																<TD width="10%"><asp:linkbutton id="lnkSiteContactApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSiteContactApproved_Click">Approve</asp:linkbutton></TD>
																<TD width="10%"><asp:linkbutton id="lnkSiteContactDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSiteContactDeclined_Click">Decline</asp:linkbutton></TD>
																<TD width="20%"><asp:linkbutton id="lnkPreSiteCotactComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></TD>
																<TD width="10%"><asp:linkbutton id="lnkPresiteContactBackUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkPresiteContactBackUp_Click">Back Up</asp:linkbutton></TD>
															</TR>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgSitePlanningNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgSitePlanningYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Site Planning :
																	<asp:label id="Label61" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="25%"><br>
																	<asp:label id="lblSitePlanningRO" runat="server"></asp:label></td>
																<td width="10%"><asp:linkbutton id="lnkSitePlanningApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSitePlanningApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkSitePlanningDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSitePlanningDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreSitePlanComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreSitePlanBackUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPreSitePlanBackUp_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"></td>
																<td vAlign="top" width="22%">Site QA (Brand Leader) :
																	<asp:label id="Label6" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="25%"><br>
																	<asp:label id="lblQAPreRO" runat="server"></asp:label></td>
																<td width="10%"></td>
																<td width="10%"></td>
																<td width="20%"></td>
																<td width="10%"></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"></td>
																<td vAlign="top" width="22%">Central QA :
																	<asp:label id="Label12" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)</td>
																<td width="25%"><br>
																	<asp:label id="lblCentralQAPreRO" runat="server"></asp:label></td>
																<td width="10%"></td>
																<td width="10%"></td>
																<td width="20%"></td>
																<td width="10%"></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgCentralPlanningNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgCentralPlanningYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td width="22%">Central Planning :&nbsp;
																	<asp:label id="Label62" runat="server" Visible="False">Label</asp:label></td>
																<td vAlign="top" width="25%"><br>
																	<asp:label id="lblCenPlanningRO" runat="server"></asp:label></td>
																<td width="10%"><asp:linkbutton id="lnkCentralPlanningApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkCentralPlanningApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkCentralPlanningDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkCentralPlanningDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreCentralPlanComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreCentralPlanBackU" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkPreCentralPlanBackU_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgSapNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgSapYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">SAP Cost Center Coordinator :&nbsp;
																	<asp:label id="Label63" runat="server" Visible="False">Label</asp:label></td>
																<td width="25%"><br>
																	<asp:label id="lblSAPRO" runat="server"></asp:label></td>
																<td width="10%"><asp:linkbutton id="lnkSAPCostCenterApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSAPCostCenterApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkSAPCostCenterDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkSAPCostCenterDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreSAPComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreSAPBackU" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPreSAPBackU_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgSmartClearanceNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgSmartClearanceYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">SMART Clearance :&nbsp;
																	<asp:label id="lblSMARTCLEARANCECoord" runat="server" Visible="False">Label</asp:label></td>
																<td width="25%"><br>
																	<asp:label id="lblSmartClearancePRO" runat="server"></asp:label></td>
																<td width="10%"></td>
																<td width="10%"></td>
																<td width="20%"></td>
																<td width="10%"><asp:linkbutton id="lnkPreSmartClearanceBackU" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkPreSmartClearanceBackU_Click">Back up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgTimingGateNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgTimingGateYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Timing Gate Exception :&nbsp;
																	<asp:label id="Label64" runat="server" Visible="False">Label</asp:label></td>
																<td style="HEIGHT: 8px" width="25%"><br>
																	<asp:label id="lblTimingGateRO" runat="server"></asp:label></td>
																<td width="10%"><asp:linkbutton id="lnkTimingGateApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkTimingGateApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkTimingGateDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkTimingGateDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreTimeGateComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreTimingGateUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPreTimingGateUp_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgStandardOfficeNo" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgStandardOfficeYes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Standards Office :&nbsp;
																	<asp:label id="Label65" runat="server" Visible="False">Label</asp:label></td>
																<td width="25%"><asp:label id="lblStansOffRO" runat="server"></asp:label><br>
																</td>
																<td width="10%"><asp:linkbutton id="lnkStandardOfficeApproved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkStandardOfficeApproved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkStandardOfficeDeclined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkStandardOfficeDeclined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkPreStandsOfficeComments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkPreStandsOfficeUp" runat="server" 
                                                                        CausesValidation="False" Visible="False" onclick="lnkPreStandsOfficeUp_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgAdditionalApprover1No" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgAdditionalApprover1Yes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Additional Approver1 :&nbsp;
																	<asp:label id="Label23" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)
																</td>
																<td width="25%"><asp:label id="lblAdditionalApprover1RO" runat="server"></asp:label><br>
																</td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover1Approved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover1Approved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover1Declined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover1Declined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkAdditionalApprover1Comments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover1Up" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkAdditionalApprover1Up_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgAdditionalApprover2No" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgAdditionalApprover2Yes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Additional Approver2 :&nbsp;
																	<asp:label id="Label24" runat="server" Visible="False">Label</asp:label><br>
																	(FYI Only - NO Approval Required)
																</td>
																<td width="25%"><asp:label id="lblAdditionalApprover2RO" runat="server"></asp:label><br>
																</td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover2Approved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover2Approved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover2Declined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover2Declined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkAdditionalApprover2Comments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover2Up" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkAdditionalApprover2Up_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgAdditionalApprover3No" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgAdditionalApprover3Yes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Additional Approver3 :&nbsp;
																	<asp:label id="Label25" runat="server" Visible="False">Label</asp:label>
																	<br>
																	(FYI Only - NO Approval Required)
																</td>
																<td width="25%"><asp:label id="lblAdditionalApprover3RO" runat="server"></asp:label><br>
																</td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover3Approved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover3Approved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover3Declined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover3Declined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkAdditionalApprover3Comments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover3Up" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkAdditionalApprover3Up_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td vAlign="top" width="3%"><asp:image id="imgAdditionalApprover4No" Runat="server" Visible="False" imageurl="../Images/No.jpg"></asp:image><asp:image id="imgAdditionalApprover4Yes" Runat="server" Visible="False" imageurl="../Images/Yes.jpg"></asp:image></td>
																<td vAlign="top" width="22%">Additional Approver4 :&nbsp;
																	<asp:label id="Label27" runat="server" Visible="False">Label</asp:label>
																	<br>
																	(FYI Only - NO Approval Required)
																</td>
																<td width="25%"><asp:label id="lblAdditionalApprover4RO" runat="server"></asp:label><br>
																</td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover4Approved" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover4Approved_Click">Approve</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover4Declined" runat="server" 
                                                                        CausesValidation="False" onclick="lnkAdditionalApprover4Declined_Click">Decline</asp:linkbutton></td>
																<td width="20%"><asp:linkbutton id="lnkAdditionalApprover4Comments" runat="server" CausesValidation="False" Visible="False">View Previous Comments</asp:linkbutton></td>
																<td width="10%"><asp:linkbutton id="lnkAdditionalApprover4Up" runat="server" 
                                                                        CausesValidation="False" Visible="False" 
                                                                        onclick="lnkAdditionalApprover4Up_Click">Back Up</asp:linkbutton></td>
															</tr>
															<tr>
																<td width="3%"></td>
																<td width="22%"></td>
																<td width="25%"></td>
																<td width="10%"></td>
																<td width="10%"></td>
																<td width="20%"></td>
																<td width="10%"></td>
															</tr>
                                                            <tr>
															    <td width="3%">
                                                                </td>
                                                                <td width="22%">
                                                                </td>
                                                                <td width="25%">
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="10%">
                                                                </td>
												</tr>
										</table>
								</td>
							</tr>
							</table>
						</div></td>  
				</tr>
              
			                <%-- Closing of Preliminary Revision --%><%-- Preliminary tab items closed--%>
                            <%-- ====================================================================================================== --%>
                            <%-- Final Tab Items followed --%>
                            <tr ID="FinalBudgetCenter" runat="server">
                                <%-- opening final Budget Center --%>
                                <td colSpan="4" width="100%">
                                    <table border="0" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td width="50%">
                                                Budget</td>
                                            <td width="50%">
                                                <asp:Label ID="lblBudgetCenterFinalDB" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of final Budget Center --%>
                            <tr ID="FinalBudgetCenterReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table border="0" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td width="50%">
                                                Budget</td>
                                            <td width="50%">
                                                <asp:Label ID="Label68" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="FinalPackagingandDisposition" runat="server">
                                <%-- opening of FinalPackagingandDisposition--%>
                                <td colSpan="4" width="100%">
                                    <table id="TableFinalpackaging" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td bgColor="#6699ff" class="Header" colSpan="2" width="100%">
                                                Packaging / Disposition Information</td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Will any product be packed?</td>
                                            <td width="50%">
                                                <asp:ListBox ID="lbFinalPackagingInfoDB" runat="server" 
                                                    SelectionMode="Multiple" Width="300px"></asp:ListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                <asp:CheckBox ID="chkCurPack" runat="server" Text="Current Packaging" />
                                                <asp:CheckBox ID="chkExpPack" runat="server" Text="Experimental Packaging" />
                                            </td>
                                            <td width="50%">
                                                <asp:ListBox ID="lbFinalPackage" runat="server" SelectionMode="Multiple" 
                                                    Width="300px">
                                                    <asp:ListItem Value="0">Select Package</asp:ListItem>
                                                    <asp:ListItem Value="1">Brown Box</asp:ListItem>
                                                    <asp:ListItem Value="2">LCP</asp:ListItem>
                                                </asp:ListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Please select a type from below:</td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:CheckBox ID="chkCurrentPoly" runat="server" Text="Current Poly" />
                                                <asp:CheckBox ID="chkBlankKGF" runat="server" Text="Blank KDF" />
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Product Disposition:</td>
                                            <td width="50%">
                                                <asp:DropDownList ID="drpFinalProductDispositionDB" runat="server" 
                                                    Width="300px">
                                                </asp:DropDownList>
                                                <br>
                                                    Additional Comments:<br>
                                                        <asp:TextBox ID="txtProductDisposition" runat="server" MaxLength="1000" 
                                                            TextMode="MultiLine" 
                                                            ToolTip="Please enter additional comments of max 1000 characters." 
                                                            Width="350px"></asp:TextBox>
                                                        &nbsp;
                                                        <asp:Label ID="Label18" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 
                                                        Characters</asp:Label>
                                                        
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Will this EO produce product using a unique pallet pattern OR a sku that will 
                                                require additional stability testing?</td>
                                            <td vAlign="bottom" width="50%">
                                                <asp:RadioButtonList ID="rbUniqPallet" runat="server" CssClass="   " 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="no">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                If Yes, which type:
                                                <p>
                                                    <asp:CheckBoxList ID="chkFinalStackShip" runat="server" 
                                                        RepeatDirection="Horizontal" Width="238px">
                                                        <asp:ListItem Value="stacktesting">Stack Testing</asp:ListItem>
                                                        <asp:ListItem Value="shiptesting">Ship Testing</asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Material Disposition:</td>
                                            <td width="50%">
                                                <asp:DropDownList ID="drpFinalMaterialDispositionDBFinal" runat="server" 
                                                    Width="300px">
                                                </asp:DropDownList>
                                                <br>
                                                    Additional Comments<br>
                                                        <asp:TextBox ID="txtMaterialDisposition" runat="server" MaxLength="1000" 
                                                            TextMode="MultiLine" 
                                                            ToolTip="Please enter additional comments of max 1000 characters." 
                                                            Width="350px"></asp:TextBox>
                                                        &nbsp;
                                                        <asp:Label ID="Label19" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 
                                                        Characters</asp:Label>
                                           
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Broke Disposition:</td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Will this EO generate greater than normal broke (log and/or loose)?</td>
                                            <td width="50%">
                                                <asp:RadioButtonList ID="rbBrokeDisposition" runat="server" CssClass="   " 
                                                    RepeatDirection="Horizontal" Width="64px">
                                                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="no">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Will any broke be printed broke?</td>
                                            <td vAlign="bottom" width="50%">
                                                <asp:RadioButtonList ID="rbPrintBrokeFinal" runat="server" CssClass="   " 
                                                    RepeatDirection="Horizontal" Width="64px">
                                                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="no">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                If yes to printed broke, will any broke have an increase in the amount of ink 
                                                coverage on the product?<asp:RadioButtonList ID="rbPrintedBrokeInk" 
                                                    runat="server" CssClass="   " RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="no">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <!-- jagan code start 12-28-07 TowtabRoutePrelimData  -->
                            <tr ID="trTowtabRoutePrelimData" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="GeneralPreliminary-TwotabRoute" class="AlternateSection1" 
                                        width="100%">
                                        <!-- Preliminary General Navigation Table -->
                                        <tr>
                                            <td colSpan="4">
                                                <asp:Label ID="PreliminaryMsg1" Runat="server" CssClass="NoteMsg">NOTE: The 
                                                Preliminary Data has not been approved yet as the Originator has chosen to have 
                                                the Preliminary data approved at the same time as the final data.</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="HEIGHT: 19px" width="25%">
                                                EO Type : &nbsp;</td>
                                            <td style="HEIGHT: 19px" width="25%">
                                                <asp:Label ID="lblEOType_TwoTbRte" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" style="HEIGHT: 19px" width="25%">
                                                EO Scope/Project Phase :&nbsp;</td>
                                            <td style="HEIGHT: 19px" width="25%">
                                                <asp:Label ID="lblEOScopeProjectPhase_TwoTbRte" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="AlternateSection1" width="100%">
                                        <tr>
                                            <td align="right" width="25%">
                                                Brief Description : &nbsp;</td>
                                            <td width="75%">
                                                <asp:Label ID="lblBriefDecription_TwoTbRte" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="WIDTH: 612px" width="612">
                                                Budget Center :&nbsp;&nbsp;</td>
                                            <td width="50%">
                                                <asp:Label ID="lblSuggestedBudCenter_TwoTbRte" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colSpan="2" width="75%">
                                                <asp:DataGrid ID="dgdGCASInfoRO_TwoTbRte" runat="server" 
                                                    AutoGenerateColumns="true" BorderColor="#404040" 
                                                    HeaderStyle-CssClass="SubHeaderGrid" Width="70%">
                                                    <HeaderStyle CssClass="Header" />
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                <table class="AlternateSection1" width="100%">
                                                    <tr>
                                                        <td bgColor="#6699ff" class="Header" colSpan="2" width="100%">
                                                            HS&amp;E</td>
                                                    </tr>
                                                    <tr>
                                                        <td colSpan="2" width="100%">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colSpan="2" width="100%">
                                                            A “YES” to any of the following questions for this test request will require 
                                                            HS&amp;E approval on the final stage routing.</td>
                                                    </tr>
                                                    <tr>
                                                        <td colSpan="2" width="100%">
                                                            Please consult your
                                                            <asp:LinkButton ID="Linkbutton2" runat="server" CausesValidation="False">Family 
                                                            Care HS&amp;E contact
                                                            </asp:LinkButton>
                                                            &nbsp;for further information on HS&amp;E reviews.</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="75%">
                                                            Does this project involve a
                                                            <asp:LinkButton ID="Linkbutton3" runat="server" CausesValidation="False">new 
                                                            chemical or a change
                                                            </asp:LinkButton>
                                                            &nbsp;in the use of an existing chemical?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblExistingChemical_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td borderColorLight="#000000" width="75%">
                                                            Does this project involve a
                                                            <asp:LinkButton ID="Linkbutton5" runat="server" CausesValidation="False"> new 
                                                            raw material or a change</asp:LinkButton>
                                                            &nbsp;in the physical properties of an existing raw material?</td>
                                                        <td borderColorLight="#000000" width="25%">
                                                            <asp:Label ID="lblPhysicalProperties_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="75%">
                                                            Does this project require
                                                            <asp:LinkButton ID="Linkbutton6" runat="server" CausesValidation="False"> new 
                                                            equipment/ process/ supporting systems or a change</asp:LinkButton>
                                                            &nbsp;in existing equipment/process/ supporting system?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblEqupProcessSupSystem_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="HEIGHT: 3px" width="75%">
                                                            Does this project require a
                                                            <asp:LinkButton ID="Linkbutton7" runat="server" CausesValidation="False"> new 
                                                            job/task or a change
                                                            </asp:LinkButton>
                                                            &nbsp;in the way a job/ task is performed?</td>
                                                        <td style="HEIGHT: 3px" width="25%">
                                                            <asp:Label ID="lblNewJobTask_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="75%">
                                                        </td>
                                                        <td width="25%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="75%">
                                                            If you answered “YES” to one or more of the above questions, click
                                                            <asp:LinkButton ID="Linkbutton8" runat="server" CausesValidation="False">here</asp:LinkButton>
                                                            &nbsp;for Additional Information</td>
                                                        <td width="25%">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr ID="trPSRASec" runat="server" visible="False">
                                            <td colSpan="2" width="100%">
                                                <table class="AlternateSection2" width="100%">
                                                    <tr style="width:100%">
                                                        <td bgColor="#6699ff" class="Header" width="100%">
                                                            PS &amp; RA</td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td style="HEIGHT: 14px" width="100%">
                                                            <asp:Label ID="PreliminaryMsg2" Runat="server" CssClass="NoteMsg">NOTE: PS&amp;RA 
                                                            Approval Required if any apply. If you are not sure, contact Burney Schwab 
                                                            (634-7879)</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="100%">
                                                            <asp:Label ID="lblPSRADB_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="100%">
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="100%">
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td align="center" width="100%">
                                                            <asp:DataGrid ID="dgdPSRAInfoRO_TwoTbRte" runat="server" 
                                                                AutoGenerateColumns="true" BorderColor="#404040" Width="75%">
                                                                <HeaderStyle CssClass="Header" />
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                <table class="AlternateSection1" width="100%">
                                                    <tr>
                                                        <td bgColor="#6699ff" class="Header" colSpan="2" width="100%">
                                                            Planning and Budget Information</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="60%">
                                                            Lines(s)/Machine(s) :</td>
                                                        <td width="40%">
                                                            <asp:Label ID="lblLinesMachineRO_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="60%">
                                                            Planned Start Date :</td>
                                                        <td width="40%">
                                                            <asp:Label ID="lblPlannesStDateRO_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="60%">
                                                        </td>
                                                        <td width="40%">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td bgColor="#6699ff" class="Header" colSpan="2" width="100%">
                                                            Production and Packaging</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="60%">
                                                            Format(s) :</td>
                                                        <td width="40%">
                                                            <asp:Label ID="lblFormats_TwoTbRte" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                  
                                </td>
                            </tr>
                            <!-- jagan code End 12-28-07 TowtabRoutePrelimData  -->
                            <tr ID="FinalPackagingandDispositionReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="tblFinalPackagingandDisposition" class="AlternateSection2" 
                                        width="100%">
                                        <tr>
                                            <td bgColor="#6699ff" class="Header" colSpan="2" width="100%">
                                                Packaging / Disposition Information</td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Will any product be packed?</td>
                                            <td width="50%">
                                                <asp:Label ID="lblProdPackFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="HEIGHT: 18px" width="50%">
                                                Current Packaging :<asp:Label ID="lblCurPackageFinalRO" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp; Experimental Packaging :
                                                <asp:Label ID="lblExpPackFinalRO" runat="server"></asp:Label>
                                            </td>
                                            <td style="HEIGHT: 18px" width="50%">
                                                <asp:Label ID="lblProdTypeFinalRo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Please select a type from below:</td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Current Poly :<asp:Label ID="lblCurPolyFinalRO" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Blank KDF :
                                                <asp:Label ID="lblBlankKDFFinalRO" runat="server"></asp:Label>
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Product Disposition:</td>
                                            <td width="50%">
                                                <asp:Label ID="lblProDispositionFinalRO" runat="server"></asp:Label>
                                                <br>
                                                    Additional Comments:<br>
                                                        <asp:Label ID="lblProDispositionFinalAddCommRO" runat="server"></asp:Label>
                                                        <
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Will this EO produce product using a unique pallet pattern OR a sku that will 
                                                require additional stability testing?</td>
                                            <td vAlign="bottom" width="50%">
                                                <p>
                                                    <asp:Label ID="lblPalletFinalRO" runat="server"></asp:Label>
                                                </p>
                                                <p>
                                                    &nbsp;If Yes, which type:</p>
                                                <p>
                                                    <asp:Label ID="lblStockShipTesting" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Material Disposition:</td>
                                            <td width="50%">
                                                <asp:Label ID="lblMaterialDispositionreadonly" runat="server"></asp:Label>
                                                <br>
                                                    Additional Comments<br>
                                                        <asp:Label ID="lblMaterialDispositionComments" runat="server"></asp:Label>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Broke Disposition:</td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Will this EO generate greater than normal broke (log and/or loose)?</td>
                                            <td width="50%">
                                                <asp:Label ID="lblEOGraterThanNormalBroke" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="50%">
                                                Will any broke be printed broke?</td>
                                            <td vAlign="bottom" width="50%">
                                                <p>
                                                    <asp:Label ID="lblPrintBroke" runat="server"></asp:Label>
                                                </p>
                                                <p>
                                                    If yes to printed broke, will any broke have an increase in the amount of ink 
                                                    coverage on the product?</p>
                                                <p>
                                                    <asp:Label ID="lblinkConerage" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="FinalCostSheet" runat="server">
                                <%-- opening of Costsheet --%>
                                <td colSpan="4" width="100%">
                                    <table id="FinalCostSheetINTable" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td bgColor="#6699ff" class="Header" colSpan="3" width="100%">
                                                Cost Sheet</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" style="HEIGHT: 18px" width="100%">
                                                Preliminary Selected Budget Center :
                                                <asp:Label ID="lblPreSelectedBudgetCenter" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                <asp:UpdatePanel ID="updpnlCostSheetCloseOut" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkCostSheetCloseOut" runat="server" 
                                                            CausesValidation="False" onclick="lnkCostSheetCloseOut_Click">Click Here to 
                                                        go to the Cost Sheet template
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                    <triggers>
                                                        <asp:PostBackTrigger ControlID="lnkCostSheetCloseOut" />
                                                    </triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                <p>
                                                    Please attach your cost sheet here:
                                                    <input id="CSAttachments" runat="server" contenteditable="false" 
                                                        name="CSAttachments" size="50" style="WIDTH: 465px" type="file">
                                                    </input>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colSpan="3" width="100%">
                                                <asp:ListBox ID="lbCostSheetAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="382px"></asp:ListBox>
                                                &nbsp;&nbsp;
                                                <asp:ImageButton ID="imgAddAttachFinalCostSheet" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttachFinalCostSheet_Click" />
                                                &nbsp;
                                                <asp:ImageButton ID="imgDelAttachFinalCostSheet" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttachFinalCostSheet_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colSpan="3" width="100%">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:DataGrid ID="dgrdCostSheetFinal" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" BorderWidth="1px" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdCostSheetFinal_ItemCommand" Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkCostSheetFinal" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkCostSheetFinal" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameCostSheetFinal" Runat="server" 
                                                                            text='<%# Eval("Cost_Sheet_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameCostSheetFinal" Runat="server" 
                                                                            text='<%# Eval("Cost_Sheet_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkCostSheetFinal" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%">
                                                Estimated amount from the Preliminary Stage:</td>
                                            <td onkeypress="javascript: return AllowNumeric(event);" width="30%">
                                                $<asp:TextBox ID="txtEstimatedAmount" runat="server" ReadOnly="true" 
                                                    Width="130px"></asp:TextBox>
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="40%">
                                                Is the total cost from the cost sheet attachment different from the Preliminary 
                                                estimate?</td>
                                            <td onkeypress="javascript: return AllowNumeric(event);" width="30%">
                                                <asp:RadioButtonList ID="rbCostSheetDiff" runat="server" AutoPostBack="true" 
                                                    CssClass="   " OnSelectedIndexChanged="rbCostSheetDiff_SelectedIndexChanged" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="no">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                If &#39;yes&#39;, please enter the cost from the cost sheet attachment:<asp:TextBox 
                                                    ID="txtCostSheetDiff" runat="server" Enabled="False" MaxLength="8" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td width="30%">
                                                <asp:Label ID="lblCostSheetTotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%">
                                            </td>
                                            <td width="30%">
                                            </td>
                                            <td width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                Please add your comments here:&nbsp;<asp:TextBox ID="txtCostSheetComments" 
                                                    runat="server" MaxLength="1000" TextMode="MultiLine" 
                                                    ToolTip="Please add comments of max 1000 characters." Width="400px"></asp:TextBox>
                                                &nbsp;
                                                <asp:Label ID="Label43" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 
                                                Characters</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" style="HEIGHT: 78px" width="100%">
                                                <p>
                                                    Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
                                                    634-7600</p>
                                                <p>
                                                    If you require training in the use of a Lab Notebook, click on the link below to 
                                                    begin the self paced web-based training.</p>
                                                <p>
                                                    <asp:Label ID="Label39" runat="server" CssClass="NoteMsg">NOTE: This training 
                                                    should take roughly 1.5 hours to complete.</asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" style="HEIGHT: 18px" width="100%">
                                                <asp:LinkButton ID="lnkLabNoteBook" runat="server" CausesValidation="False">Interactive 
                                                Lab Notebook training</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of Costsheet --%>
                            <tr ID="FinalCostSheetReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="tblFinalCostSheetReadOnly" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td bgcolor="#6699ff" class="Header" colspan="4" width="100%">
                                                Cost Sheet</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" width="100%">
                                                Preliminary Selected Budget Center :
                                                <asp:Label ID="lblPreSelBudgetCenterLock" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Cost Sheet Attachment :</td>
                                            <td colSpan="3" width="50%">
                                                <asp:DataGrid ID="dgrdCostSheetFinal_ReadOnly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdCostSheetFinal_ReadOnly_ItemCommand" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkCostSheetFinalRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkCostSheetFinalRO" Runat="server" 
                                                                            CausesValidation="False" CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameCostSheetFinalRO" Runat="server" 
                                                                            text='<%# Eval("Cost_Sheet_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameCostSheetFinalRO" Runat="server" 
                                                                            text='<%# Eval("Cost_Sheet_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkCostSheetFinalRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" width="100%">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td width="40%">
                                                Estimated amount from the Preliminary Stage:</td>
                                            <td width="30%">
                                                <asp:Label ID="lblEstimateAmount" runat="server"></asp:Label>
                                            </td>
                                            <td colspan="2" width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="40%">
                                                Is the total cost from the cost sheet attachment different from the Preliminary 
                                                estimate?</td>
                                            <td width="30%">
                                                <p>
                                                    <asp:Label ID="lblTotCostsheet" runat="server"></asp:Label>
                                                </p>
                                                <p>
                                                    If &#39;yes&#39;, please enter the cost from the cost sheet attachment:
                                                    <asp:Label ID="lblYesOptionTotCostsheet" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                            <td colspan="2" width="30%">
                                                <asp:Label ID="Label71" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%">
                                            </td>
                                            <td width="30%">
                                            </td>
                                            <td colspan="2" width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" width="100%">
                                                Please add your comments here:&nbsp;
                                                <asp:Label ID="lblCostSheetAddCommentsFinalRO" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="HEIGHT: 78px" width="100%">
                                                <p>
                                                    Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
                                                    634-7600</p>
                                                <p>
                                                    If you require training in the use of a Lab Notebook, click on the link below to 
                                                    begin the self paced web-based training.</p>
                                                <p>
                                                    <asp:Label ID="Label72" runat="server" CssClass="NoteMsg">NOTE: This training 
                                                    should take roughly 1.5 hours to complete.</asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <!-- added-->
                            <tr ID="TrFinalQA" runat="server">
                                <%-- opening of Test Plans --%>
                                <td colSpan="4" width="100%">
                                    <table id="TableFinalQA" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" width="100%">
                                                QA Information</td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                Please attach any additional items pertaining to this EO here :</td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <input id="FinalQAAttach" runat="server" contenteditable="false" 
                                                    name="txtTPAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="lbFinalQAAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="465px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttachFinalQA" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttachFinalQA_Click" />
                                                &nbsp;<asp:ImageButton ID="imgDelAttachFinalQA" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttachFinalQA_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" width="100%">
                                                <asp:DataGrid ID="dgrdQAFinalTabAttachment" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" BorderWidth="1px" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdQAFinalTabAttachment_ItemCommand" Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanLinkbutton4" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="Linkbutton4" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameQA" Runat="server" 
                                                                            text='<%# Eval("QA_Info_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameQA" Runat="server" 
                                                                            text='<%# Eval("QA_Info_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="Linkbutton4" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of Test Plans --%>
                            <tr ID="TrFinalQARO" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableFinalQARO" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colspan="2" width="100%">
                                                QA Information</td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                QA Information Attachment :</td>
                                            <td>
                                                <asp:DataGrid ID="dgrdQAFinalTabAttachment_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdQAFinalTabAttachment_Readonly_ItemCommand" 
                                                    ShowHeader="False" Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanLinkbutton4RO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="Linkbutton4RO" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameQARO" Runat="server" 
                                                                            text='<%# Eval("QA_Info_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameQARO" Runat="server" 
                                                                            text='<%# Eval("QA_Info_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="Linkbutton4RO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <!-- done-->
                            <tr ID="FinalFormulaCardInformation" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableCost" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="3" width="100%">
                                                Formula Card Information</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="HEIGHT: 35px" width="50%">
                                                <p>
                                                    Final EO Formula Card Information Click&nbsp;<asp:LinkButton ID="lnkFormulaClick" 
                                                        runat="server" CausesValidation="False">Here</asp:LinkButton>
                                                    &nbsp;for help in marking up your Formula Cards</p>
                                            </td>
                                            <td align="left" style="HEIGHT: 35px" width="50%">
                                                <asp:TextBox ID="txtFinal" runat="server" MaxLength="100" Width="248px"></asp:TextBox>
                                                <asp:DropDownList ID="drpFinalFormulaCardDB" runat="server" 
                                                    style="DISPLAY: none" Width="0px">
                                                </asp:DropDownList>
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                Please attach Formula Card or Exception Document Here:</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                <asp:UpdatePanel ID="updpnlFormulaCardTemplate" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkFormulaCardTemplate" runat="server" 
                                                            CausesValidation="False" onclick="lnkFormulaCardTemplate_Click1">Click Here 
                                                        to go to the Formula Card Exception template
                                                        </asp:LinkButton>
                                                        &nbsp;<input id="txtFCAttachment" runat="server" contenteditable="false" 
                                                            name="txtFCAttachment" size="50" style="WIDTH: 465px" type="file">
                                                        </input>
                                                    </ContentTemplate>
                                                    <triggers>
                                                        <asp:PostBackTrigger ControlID="lnkFormulaCardTemplate" />
                                                    </triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                <asp:ListBox ID="lbFormulaCardAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchFinalFormulaCard" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchFinalFormulaCard_Click" />
                                                &nbsp;<asp:ImageButton ID="imgDelAttchFinalFormulaCard" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchFinalFormulaCard_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                <asp:DataGrid ID="dgrdFormulaCard" Runat="server" AutoGenerateColumns="False" 
                                                    BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                    HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdFormulaCard_ItemCommand" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkFormulaCard" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkFormulaCard" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameFormulaCard" Runat="server" 
                                                                            text='<%# Eval("Formula_Cards_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameFormulaCard" Runat="server" 
                                                                            text='<%# Eval("Formula_Cards_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkFormulaCard" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of FinalPackagingandDisposition--%>
                            <tr ID="FinalFormulaCardInformationReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="tblFinalFormulaCardInformationReadOnly" class="AlternateSection1" 
                                        width="100%">
                                        <tr>
                                            <td class="Header" colSpan="4" width="100%">
                                                Formula Card Information</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="4" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="HEIGHT: 35px" width="50%">
                                                Final EO Formula Card Information Click&nbsp;<asp:LinkButton ID="Linkbutton46" 
                                                    runat="server" CausesValidation="False">Here</asp:LinkButton>
                                                &nbsp;for help in marking up your Formula Cards
                                            </td>
                                            <td colSpan="3" style="HEIGHT: 35px" width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="4" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Formula Card or Exception Document Attachment :</td>
                                            <td width="50%">
                                                <asp:DataGrid ID="dgrdFormulaCard_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdFormulaCard_Readonly_ItemCommand" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkFormulaCardRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkFormulaCardRO" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameFormulaCardRO" Runat="server" 
                                                                            text='<%# Eval("Formula_Cards_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameFormulaCardRO" Runat="server" 
                                                                            text='<%# Eval("Formula_Cards_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkFormulaCardRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="4" width="100%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="FinalTestPlans" runat="server">
                                <%-- opening of Test Plans --%>
                                <td colSpan="4" width="100%">
                                    <table id="TableQA" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" width="100%">
                                                Test Plans</td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:UpdatePanel ID="upTestPlanTemplate" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkTestPlanTemplate2" runat="server" 
                                                            CausesValidation="False" onclick="lnkTestPlanTemplate2_Click">Click Here to 
                                                        go to the Test Plan template
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                    <triggers>
                                                        <asp:PostBackTrigger ControlID="lnkTestPlanTemplate2" />
                                                    </triggers>
                                                </asp:UpdatePanel>
                                                &nbsp;<input id="txtTPAttachment" runat="server" contenteditable="false" 
                                                    name="txtTPAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="lbTestPlansAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="465px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchFinalTestPlans" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchFinalTestPlans_Click" />
                                                &nbsp;<asp:ImageButton ID="imgDelAttchFinalTestPlans" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchFinalTestPlans_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="4" width="100%">
                                                <asp:DataGrid ID="dgrdTestPlansFinal" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" BorderWidth="1px" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdTestPlansFinal_ItemCommand1" Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkTestPlansFinal" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkTestPlansFinal" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameTestPlansFinal" Runat="server" 
                                                                            text='<%# Eval("Test_Plans_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameTestPlansFinal" Runat="server" 
                                                                            text='<%# Eval("Test_Plans_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkTestPlansFinal" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of Test Plans --%>
                            <tr ID="FinalTestPlansReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableQARO" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                Test Plans</td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Test Plans Attachment :
                                            </td>
                                            <td>
                                                <asp:DataGrid ID="dgrdTestPlansFinal_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdTestPlansFinal_Readonly_ItemCommand1" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkTestPlansFinalRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkTestPlansFinalRO" Runat="server" 
                                                                            CausesValidation="False" CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameTestPlansFinalRO" Runat="server" 
                                                                            text='<%# Eval("Test_Plans_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameTestPlansFinalRO" Runat="server" 
                                                                            text='<%# Eval("Test_Plans_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkTestPlansFinalRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="LabSamplingPlans" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableLab" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" style="HEIGHT: 21px" width="100%">
                                                Lab Sampling Plans</td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                Please select the lab you intend to use for your testing:
                                                <asp:CheckBox ID="chkCenAnaLab" runat="server" Text="Central Analytical Lab" />
                                                <asp:CheckBox ID="chkSiteTestLab" runat="server" Text="Site Testing Labs" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <input id="txtLSAttachment" runat="server" contenteditable="false" 
                                                    name="txtLSAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:ListBox ID="lbLabSampleAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchFinalLabSamples" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchFinalLabSamples_Click" />
                                                &nbsp;<asp:ImageButton ID="imgDelAttchFinalLabSamples" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchFinalLabSamples_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:DataGrid ID="dgrdLabSamp" Runat="server" AutoGenerateColumns="False" 
                                                    BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                    HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdLabSamp_ItemCommand1" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkLabSamp" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkLabSamp" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameLabSamp" Runat="server" 
                                                                            text='<%# Eval("Lab_Sampling_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameLabSamp" Runat="server" 
                                                                            text='<%# Eval("Lab_Sampling_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkLabSamp" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="LabSamplingPlansReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableLabRO" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="3" style="HEIGHT: 21px" width="100%">
                                                Lab Sampling Plans</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                Please select the lab you intend to use for your testing:&nbsp; Central Analytical 
                                                Lab
                                                <asp:Label ID="lblCentralAnalyticalLab" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;Site Testing Labs
                                                <asp:Label ID="lblSiteTestingLabs" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Lab Sampling Plans Attachment :</td>
                                            <td>
                                                <asp:DataGrid ID="dgrdLabSamp_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdLabSamp_Readonly_ItemCommand1" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkLabSampRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkLabSampRO" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameLabSampRO" Runat="server" 
                                                                            text='<%# Eval("Lab_Sampling_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameLabSampRO" Runat="server" 
                                                                            text='<%# Eval("Lab_Sampling_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkLabSampRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="FinalProductTestFlowMatrix" runat="server">
                                <%--opening of Test Flow Matrix --%>
                                <td colSpan="4" width="100%">
                                    <table id="TableProductrO" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" width="100%">
                                                Product or Detailed Test Flow Matrix</td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <input id="txtPTFAttachment" runat="server" contenteditable="false" 
                                                    name="txtPTFAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="lbFlowMatrixAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchFinalFlowMatrix" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchFinalFlowMatrix_Click" />
                                                &nbsp;<asp:ImageButton ID="imgDelAttchFinalFlowMatrix" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchFinalFlowMatrix_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="4" width="100%">
                                                <asp:DataGrid ID="dgrdTestMatrix" Runat="server" AutoGenerateColumns="False" 
                                                    BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                    HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdTestMatrix_ItemCommand1" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkTestMatrix" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkTestMatrix" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameTestMatrix" Runat="server" 
                                                                            text='<%# Eval("Matrix_Attachment_File_Name")%>' Visible="true"> </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameTestMatrix" Runat="server" 
                                                                            text='<%# Eval("Matrix_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkTestMatrix" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;</td>
                            </tr>
                            <tr ID="FinalProductTestFlowMatrixReadonly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableProduct" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                Product or Detailed Test Flow Matrix</td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Product or Detailed Test Flow Matrix Attachment :</td>
                                            <td>
                                                <asp:DataGrid ID="dgrdTestMatrix_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdTestMatrix_Readonly_ItemCommand1" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkTestMatrixRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkTestMatrixRO" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameTestMatrixRO" Runat="server" 
                                                                            text='<%# Eval("Matrix_Attachment_File_Name")%>' Visible="true"> </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameTestMatrixRO" Runat="server" 
                                                                            text='<%# Eval("Matrix_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkTestMatrixRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="FinalOtherSupportingDoc" runat="server">
                                <%-- opening of FinalOtherSupportingDoc--%>
                                <td colSpan="4" width="100%">
                                    <table id="TableOtherRO" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                Other Supporting Documentation</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                <input id="txtODAttachment" runat="server" contenteditable="false" 
                                                    name="txtODAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                <asp:ListBox ID="lbSupDocAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchFinalOtherSup" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchFinalOtherSup_Click" />
                                                &nbsp;<asp:ImageButton ID="imgDelAttchFinalOtherSup" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchFinalOtherSup_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                <asp:DataGrid ID="dgrdOtherDocFinal" Runat="server" AutoGenerateColumns="False" 
                                                    BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                    HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdOtherDocFinal_ItemCommand1" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkOtherDocFinal" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkOtherDocFinal" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameOtherDocFinal" Runat="server" 
                                                                            text='<%# Eval("Other_Docs_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameOtherDocFinal" Runat="server" 
                                                                            text='<%# Eval("Others_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkOtherDocFinal" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:Label ID="Label38" runat="server" CssClass="NoteMsg">Please enter any 
                                                Comments to the Approvers here:</asp:Label>
                                            </td>
                                            <td width="50%">
                                                <asp:TextBox ID="txtApproverComments" runat="server" MaxLength="1000" 
                                                    TextMode="MultiLine" 
                                                    ToolTip="Please enter any comments to the approvers of max 1000 characters." 
                                                    Width="400px"></asp:TextBox>
                                                &nbsp;
                                                <asp:Label ID="Label20" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 
                                                Characters</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                Previous Comments</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of FinalOtherSupportingDoc--%>
                            <tr ID="FinalOtherSupportingDocReadonly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableOther" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                Other Supporting Documentation</td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Other Supporting DocumentationAttachment :</td>
                                            <td width="50%">
                                                <asp:DataGrid ID="dgrdOtherDocFinal_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdOtherDocFinal_Readonly_ItemCommand1" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkOtherDocFinalRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkOtherDocFinalRO" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameOtherDocFinalRO" Runat="server" 
                                                                            text='<%# Eval("Other_Docs_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameOtherDocFinalRO" Runat="server" 
                                                                            text='<%# Eval("Others_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkOtherDocFinalRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:Label ID="Label73" runat="server" CssClass="NoteMsg"> Comments to the 
                                                Approvers :</asp:Label>
                                            </td>
                                            <td width="50%">
                                                <asp:Label ID="lblSupDocCommnets" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                                Previous Comments</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="100%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="trFinalMaterialsBrandshead" runat="server">
                                <td class="Header" colSpan="4" width="100%">
                                    New Materials and Brands</td>
                            </tr>
                            <tr ID="trFinalMaterialsBrandsRadioBefore" runat="server" 
                                class="AlternateSection1">
                                <td colSpan="4">
                                    <table class="AlternateSection1" width="100%">
                                        <tr>
                                            <td align="left" width="75%">
                                                <p>
                                                    Do new Raw and/or Packing Materials need to be activated for this EO or EO Site?<br>
                                                        <asp:Label ID="lblMat1Text" runat="server" CssClass="NoteMsg" Height="20px" 
                                                            Width="288px">If &#39;Yes&#39;, please list the GCAS numbers below</asp:Label>
                                                        <asp:Label ID="lblMat2Text" runat="server" CssClass="NoteMsg" Height="20px" 
                                                            Width="500px">If these codes are not already established in GMDB, please 
                                                        complete a GMDB request.</asp:Label>
                                                </p>
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rbRawMaterialFinal" runat="server" AutoPostBack="true" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                <p>
                                                    Will the EO produce Parent Rolls that need to be tracked and controlled 
                                                    separately from normal production?<br>
                                                        <asp:Label ID="lblMat3Text" runat="server" CssClass="NoteMsg" Height="20px" 
                                                            Width="288px">If &#39;Yes&#39;, please list the GCAS numbers below</asp:Label>
                                                        <asp:Label ID="lblMat4Text" runat="server" CssClass="NoteMsg" Height="20px" 
                                                            Width="500px">If these codes are not already established in GMDB, please 
                                                        complete a GMDB request.</asp:Label>
                                                   
                                                </p>
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rbParentRollsFinal" runat="server" AutoPostBack="True" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will the EO produce or involve any other
                                                <asp:LinkButton ID="lnkInterMaterialsFinal" runat="server" 
                                                    CausesValidation="False">Intermediate Materials</asp:LinkButton>
                                                &nbsp;that are new to this site?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rbInterMaterialsFinal" runat="server" 
                                                    AutoPostBack="true" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will any product from the EO be shipped to the trade as a current brand?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rbShippedFinal" runat="server" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="trFinalMaterialsBrands" runat="server">
                                <td colSpan="4" width="100%">
                                    <table ID="tblMaterialsBrandsFinal" runat="server" class="AlternateSection1" 
                                        width="100%">
                                        <tr ID="trFinalMaterialsStatement" runat="server">
                                            <td align="left" width="75%">
                                                <br>If any EO product will be shipped into existing brand codes (blind 
                                                shipping), you must determine if a P&amp;G Policy 37 exception is needed.&nbsp;&nbsp;Refer to 
                                                the Family Care Job Aid for more information.&nbsp; If an exception is needed, it 
                                                must be approved prior to running the EO.
                                                <br>
                                                <br>Link to Job Aid (on MUR EO Teamspace):
                                                <br>
                                                <br>
                                                <a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc" 
                                                    target="_blank">
                                                http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc</a>
                                                
                                            </td>
                                            <td width="25%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2">
                                                <div ID="Div1" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td align="left" width="75%">
                                                                <br>
                                                                <asp:Label ID="Label14" Runat="server" Font-Bold="true" Font-Size="14px">Please 
                                                                Select one of the following:</asp:Label>
                                                                <br>
                                                                <br>
                                                                <asp:CheckBoxList ID="chkFinalMaterialsBrands" Runat="server" Font-Bold="true" 
                                                                    Font-Size="14px" RepeatDirection="Vertical">
                                                                    <asp:ListItem Value="I understand Policy 37 requirements for Family Care. &nbsp;A Policy 37 exception is not required for this EO">I 
                                                                    understand Policy 37 requirements for Family Care. &nbsp;A Policy 37 exception is not 
                                                                    required for this EO</asp:ListItem>
                                                                    <asp:ListItem Value="A Policy 37 exception is required and will be complete before executing this EO.">A 
                                                                    Policy 37 exception is required and will be complete before executing this EO.</asp:ListItem>
                                                                    <asp:ListItem Value="This EO is already covered by an existing Policy 37 exception.">This 
                                                                    EO is already covered by an existing Policy 37 exception.</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                               
                                                            </td>
                                                            <td width="25%">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="trFinalMaterialsBrandsRadioAfter" runat="server" 
                                class="AlternateSection1">
                                <td colSpan="4">
                                    <table class="AlternateSection1" width="100%">
                                        <tr>
                                            <td align="left" width="75%">
                                                Will any test product/samples be shipped out of the plant for consumer/lab 
                                                evaluation?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rbTestProductedShippedFinal" runat="server" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will you be using any Contingent GCAS #s unique to product and not ordered via 
                                                UMOF?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rbGCASNumberFinal" runat="server" 
                                                    CssClass="FormatToControls" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="NewMaterialandBrandsReadOnlyFinal" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="tblNewMaterialandBrandsReadOnlyFinal" runat="server" 
                                        class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colspan="2" width="100%">
                                                New Materials and Brands</td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                <p>
                                                    Do new Raw and/or Packing Materials need to be activated for this EO or EO Site?</p>
                                            </td>
                                            <td width="25%">
                                                <asp:Label ID="lblNewRawPackMaterialsFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                <p>
                                                    Will the EO produce Parent Rolls that need to be tracked and controlled 
                                                    separately from normal production?</p>
                                            </td>
                                            <td width="25%">
                                                <asp:Label ID="lblParentRollsFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will the EO produce or involve any other
                                                <asp:LinkButton ID="lnkFinalInt" runat="server" CausesValidation="False">Intermediate 
                                                Materials</asp:LinkButton>
                                                &nbsp;that are new to this site?</td>
                                            <td width="25%">
                                                <asp:Label ID="lblEOProduceOrInvolveFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Is this EO for the production of Regulated Product?</td>
                                            <td width="25%">
                                                <asp:Label ID="lblIsRegulatedProductFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                For ALL regulated products, please mark the appropriate GMP Classification</td>
                                            <td width="25%">
                                                <asp:Label ID="lblGMPClassificationFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will any product from the EO be shipped to the trade as a current brand?</td>
                                            <td width="25%">
                                                <asp:Label ID="lblCurrentBrandFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trProdRegulatedProductRAQ1Final" runat="server" visible="false">
                                            <td align="left" width="75%">
                                                <br>If any EO product will be shipped into existing brand codes (blind 
                                                shipping), you must determine if a P&amp;G Policy 37 exception is needed.&nbsp;&nbsp;Refer to 
                                                the Family Care Job Aid for more information.&nbsp; If an exception is needed, it 
                                                must be approved prior to running the EO.
                                                <br>
                                                <br>Link to Job Aid (on MUR EO Teamspace):
                                                <br>
                                                <br>
                                                <a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc" 
                                                    target="_blank">
                                                http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc</a>
                                               
                                            </td>
                                            <td width="25%">
                                            </td>
                                        </tr>
                                        <tr id="trProdRegulatedProductRAQ2Final" runat="server" visible="false">
                                            <td align="left" width="75%">
                                                <br>Please Select one of the following:
                                                <br>
                                                <asp:CheckBoxList ID="chkMaterialsBrandsReadOnlyFinal" Runat="server" 
                                                    Enabled="False" RepeatDirection="Vertical" Visible="False">
                                                    <asp:ListItem Value="I understand Policy 37 requirements for Family Care. &nbsp;A Policy 37 exception is not required for this EO"></asp:ListItem>
                                                    <asp:ListItem Value="A Policy 37 exception is required and will be complete before executing this EO."></asp:ListItem>
                                                    <asp:ListItem Value="This EO is already covered by an existing Policy 37 exception."></asp:ListItem>
                                                </asp:CheckBoxList>
                                                <br>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" width="5%">
                                                            <asp:Label ID="lblYesNoMat1Final" Runat="server" Font-Bold="True" 
                                                                Font-Size="14px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="95%">
                                                            <asp:Label ID="lblMat1Final" Runat="server" Font-Bold="True" Font-Size="14px">I 
                                                            understand Policy 37 requirements for Family Care. &nbsp;A Policy 37 exception is not 
                                                            required for this EO</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="5%">
                                                            <asp:Label ID="lblYesNoMat2Final" Runat="server" Font-Bold="True" 
                                                                Font-Size="14px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="95%">
                                                            <asp:Label ID="lblMat2Final" Runat="server" Font-Bold="True" Font-Size="14px">A 
                                                            Policy 37 exception is required and will be complete before executing this EO.</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="5%">
                                                            <asp:Label ID="lblYesNoMat3Final" Runat="server" Font-Bold="True" 
                                                                Font-Size="14px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="95%">
                                                            <asp:Label ID="lblMat3Final" Runat="server" Font-Bold="True" Font-Size="14px">This 
                                                            EO is already covered by an existing Policy 37 exception.</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                            </td>
                                            <td width="25%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will any test product/samples be shipped out of the plant for consumer/lab 
                                                evaluation?</td>
                                            <td width="25%">
                                                <asp:Label ID="lblLabEvaluationFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="75%">
                                                Will you be using any Contingent GCAS #s unique to product and not ordered via 
                                                UMOF?</td>
                                            <td width="25%">
                                                <asp:Label ID="lblUMOFFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="trFinalPSRAhead" runat="server">
                                <td class="Header" colSpan="4" width="100%">
                                    PS &amp; RA</td>
                            </tr>
                            <tr ID="trFinalPSRA" runat="server">
                                <td colSpan="4" width="100%">
                                    <table ID="tblPSRAFinal1" runat="server" class="AlternateSection2" width="100%">
                                        <tr style="width:100%">
                                            <td width="75%">
                                                Will any product go to consumers?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rblFinalProductConsumerOption" Runat="server" 
                                                    onclick="CheckFinalProductConsumerOption();" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Selected="False" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td width="75%">
                                                Are you using an approved FC or ATS? (&quot;approved&quot; means current version in CSS)
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rblFinalProductApprovedOption" Runat="server" 
                                                    onclick="CheckFinalProductApprovedOption();" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Selected="False" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table ID="tblPSRAFinal2" runat="server" class="AlternateSection2" width="100%">
                                        <tr style="width:100%">
                                            <td width="75%">
                                                Are all Raw Materials approved at the appropriate level (1-5)?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rblFinalRawMaterialsQ1" Runat="server" 
                                                    onclick="CheckFinalRMQ1();" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Selected="False" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td width="75%">
                                                Are all Raw Materials approved for the appropriate region (NA, Mexico)?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rblFinalRawMaterialsQ2" Runat="server" 
                                                    onclick="CheckFinalRMQ2();" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Selected="False" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td width="75%">
                                                Are all Raw Materials approved for the application (tissue, towel)?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rblFinalRawMaterialsQ3" Runat="server" 
                                                    onclick="CheckFinalRMQ3();" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Selected="False" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td width="75%">
                                                Are all Raw Materials approved at the previously approved application rate?</td>
                                            <td width="25%">
                                                <asp:RadioButtonList ID="rblFinalRawMaterialsQ4" Runat="server" 
                                                    onclick="CheckFinalRMQ4();" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="False" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Selected="False" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td width="75%">
                                                <br>Link to One Point Lesson (OPL) for PS&amp;RA questions:<br>
                                                <br>
                                                <a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B" 
                                                    target="_blank">
                                                http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B</a>
                                                
                                            </td>
                                            <td width="25%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="PSandRAReadOnlyFinal" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="tblPSandRAReadOnlyFinal" class="AlternateSection2" width="100%">
                                        <tr width="100%">
                                            <td bgcolor="#6699ff" class="Header" width="100%">
                                                <asp:Label ID="labelPSRAFinal101" runat="server">PS&amp;RA</asp:Label>
                                            </td>
                                        </tr>
                                        <tr width="100%">
                                            <td width="100%">
                                                <asp:Label ID="labelPSRAFinal102" runat="server" CssClass="NoteMsg">NOTE: PS&amp;RA 
                                                Approval Required if any apply. If you are not sure, contact Burney Schwab 
                                                (634-7879)</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="PSR1Final" runat="server" width="100%">
                                            <td width="100%">
                                                <asp:Label ID="lblPSRADBFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="PSR2Final" runat="server" width="100%">
                                            <td width="100%">
                                            </td>
                                        </tr>
                                        <tr id="PSR3Final" runat="server" width="100%">
                                            <td width="100%">
                                                <asp:Label ID="labelPSRAFinal103" runat="server" Font-Bold="True" 
                                                    ForeColor="Green"> Additional information if you selected &quot;Other&quot;:</asp:Label>
                                                <asp:Label ID="lblOtherPSRADBFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="PSR4Final" runat="server" width="100%">
                                            <td width="100%">
                                            </td>
                                        </tr>
                                        <tr id="PSR5Final" runat="server" width="100%">
                                            <td align="center" width="100%">
                                                <asp:DataGrid ID="Datagrid1" runat="server" AutoGenerateColumns="true" 
                                                    BorderColor="#404040" Width="75%">
                                                    <HeaderStyle CssClass="Header" />
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td width="100%">
                                                <table class="AlternateSection2" width="100%">
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            Will any product go to consumers?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblReadonlyPSR1Final" Runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            Are you using an approved FC or ATS? (&quot;approved&quot; means current version in CSS)
                                                        </td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblReadonlyPSR2Final" Runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td>
                                                <table class="AlternateSection2" width="100%">
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            Are all Raw Materials approved at the appropriate level (1-5)?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblReadonlyPSR3Final" Runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            Are all Raw Materials approved for the appropriate region (NA, Mexico)?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblReadonlyPSR4Final" Runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            Are all Raw Materials approved for the application (tissue, towel)?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblReadonlyPSR5Final" Runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            Are all Raw Materials approved at the previously approved application rate?</td>
                                                        <td width="25%">
                                                            <asp:Label ID="lblReadonlyPSR6Final" Runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width:100%">
                                                        <td width="75%">
                                                            <br>Link to One Point Lesson (OPL) for PS&amp;RA questions:<br>
                                                            <br>
                                                            <a href="http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B" 
                                                                target="_blank">
                                                            http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B</a>
                                                           
                                                        </td>
                                                        <td width="25%">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="FinalApprovals" runat="server" valign="top">
                                <%-- opening of FinalApprovals --%>
                                <td colSpan="4" width="100%">
                                    <table id="TableINFinalApproval" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="3" width="100%">
                                                Approvals</td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Your approval group is:</td>
                                            <td colSpan="2" width="50%">
                                                <asp:DropDownList ID="drpAppGrpFinal" runat="server" AutoPostBack="true" 
                                                    Width="300px">
                                                </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="3" width="100%">
                                                <asp:Label ID="Label37" runat="server" CssClass="NoteMsg">You can override these 
                                                values by selecting the correct approver from the list.</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px; HEIGHT: 45px" width="457">
                                                PS Initiative Manager:
                                                <asp:Label ID="lblPSIntiativeFinalAppgrp" runat="server" Visible="False">PS Initiative Manager</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px; HEIGHT: 45px" width="247">
                                                <asp:TextBox ID="txtPSInitiative" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkPSIntiativeChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkPSIntiativeChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkPSIntiativeFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkPSIntiativeFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                              
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Products Research:
                                                <asp:Label ID="lblFinalAppgrpprodResearch" runat="server" Visible="False">Products Research</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtProductsResearch" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkProdResearchChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkProdResearchChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkProdResearchFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkProdResearchFYI_Click">FYI Not Necessary</asp:LinkButton>
                                              
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Budget Owner:
                                                <asp:Label ID="lblFinalAppgrpBO" runat="server" Visible="False">Budget Center</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtBudgetOwnerFinal" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkBudgetOwnerChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkBudgetOwnerChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkBudgetOwnerFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkBudgetOwnerFYI_Click" Visible="False">FYI Not Necessary</asp:LinkButton>
                                             
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                GBU HS&amp;E Resource:
                                                <asp:Label ID="lblFinalAppgrpGBUHSE" runat="server" Visible="False">GBU HS&E Resource</asp:Label>
                                                <br>(FYI Only - NO Approval Required)<br>
                                              
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtGBUHSEFinal" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkGBUHSEChangeApp" runat="server" CausesValidation="False" 
                                                    onclick="lnkGBUHSEChangeApp_Click">Change Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkGBUHSEFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkGBUHSEFYI_Click">FYI Not Necessary</asp:LinkButton>
                                              
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Site HS&amp;E Resource:
                                                <asp:Label ID="lblFinalAppgrpSiteHSE" runat="server" Visible="False">Site HS&E Resource</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtSiteHSEFinal" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSiteHSEFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteHSEFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;<asp:LinkButton ID="lnkSiteHSEFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkSiteHSEFYI_Click">FYI Not Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                SAP Cost Center Coordinator:
                                                <asp:Label ID="lblFinalAppgrpSAP" runat="server" Visible="False">SAP Cost Center Coordinator</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtSAPCostCenter" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSAPFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSAPFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSAPFinalFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkSAPFinalFYI_Click" Visible="False">FYI Not Necessary</asp:LinkButton>
                                              
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                SMART Clearance:
                                                <asp:Label ID="lblFinalAppgrpSMARTClearance" runat="server" Visible="False">SMART Clearance</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtSMARTClearanceFinal" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSMARTClearanceFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSMARTClearanceFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSMARTClearanceFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkSMARTClearanceFinalFYI_Click" 
                                                    Visible="False">FYI Not Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Site Planning:
                                                <asp:Label ID="lblFinalAppgrpSitePlan" runat="server" Visible="False">Site Planning</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtSitePlanFinal" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSitePlanFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSitePlanFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSitePlanFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkSitePlanFinalFYI_Click" Visible="False">FYI 
                                                Not Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px; HEIGHT: 20px" width="457">
                                                Site Contact:
                                                <asp:Label ID="lblFinalAppgrpSiteContact" runat="server" Visible="False">Site Contact</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px; HEIGHT: 20px" width="247">
                                                <asp:TextBox ID="txtSiteContactFinal" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSiteContactFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteContactFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSiteContacyFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteContacyFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Site Finance:
                                                <asp:Label ID="lblFinalAppgrpSiteFinance" runat="server" Visible="False">Site Finance</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtSiteFinance" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSiteFinanceFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteFinanceFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSiteFinanceFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteFinanceFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Site Leadership:
                                                <asp:Label ID="lblFinalAppgrpSiteLeaderShip" runat="server" Visible="False">Site Leadership</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtSiteLeaderShip" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSiteLeaderFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteLeaderFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSiteLeadershipFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteLeadershipFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr ID="trPSRAFINALAPPROVAL" runat="server" Visible="False">
                                            <td style="WIDTH: 457px; HEIGHT: 44px" width="457">
                                                PS&amp;RA:
                                                <asp:Label ID="lblFinalAppgrpPSRA" runat="server" Visible="False">PS&amp;RA</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px; HEIGHT: 44px" width="247">
                                                <asp:TextBox ID="txtPSRAFinal" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkPSRAFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkPSRAFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkPSRAFinalFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkPSRAFinalFYI_Click">FYI Not Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Timing Gate Exception:
                                                <asp:Label ID="lblFinalAppgrpTimingGate" runat="server" Visible="False">Timing Gate Exception</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalTimingGate" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkTimiGateFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkTimiGateFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkTimiggateFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkTimiggateFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Site QA (Brand Leader):
                                                <asp:Label ID="lblFinalAppgrpQA" runat="server" Visible="False">QA</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalQA" runat="server" Enabled="False" Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkQAFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkQAFinalChangeApp_Click">Change Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkQAFinalFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkQAFinalFYI_Click">FYI Not Necessary</asp:LinkButton>
                                              
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Central QA:
                                                <asp:Label ID="lblFinalAppgrpCentralQA" runat="server" Visible="False">Central QA</asp:Label>
                                                <br>(FYI Only - NO Approval Required)<br>
                                               
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalCentralQA" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkCentralQAFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkCentralQAFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkCentralQAFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkCentralQAFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Standards Office:
                                                <asp:Label ID="lblFinalAppgrpStandsOffice" runat="server" Height="16px" 
                                                    Visible="False">Standards Office</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalStandardsOffice" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkStanOfficeFinalChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkStanOfficeFinalChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkStandsOfficeFinalFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkStandsOfficeFinalFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Additional Approver1:
                                                <asp:Label ID="lblFinalAdditionalApprover1" runat="server" Height="16px" 
                                                    Visible="False">Additional approver #1</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalAdditionalApprover1" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkAdditionalApp1Final" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp1Final_Click1">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkAdditionalApp1FYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp1FYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Additional Approver2:
                                                <asp:Label ID="lblFinalAdditionalApprover2" runat="server" Height="16px" 
                                                    Visible="False">Additional approver #2</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalAdditionalApprover2" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkAdditionalApp2Final" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp2Final_Click1">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkAdditionalApp2FYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp2FYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                                
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Additional Approver3:
                                                <asp:Label ID="lblFinalAdditionalApprover3" runat="server" Height="16px" 
                                                    Visible="False">Additional approver #3</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalAdditionalApprover3" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkAdditionalApp3Final" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp3Final_Click1">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkAdditionalApp3FYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp3FYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                                
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 457px" width="457">
                                                Additional Approver4:
                                                <asp:Label ID="lblFinalAdditionalApprover4" runat="server" Height="16px" 
                                                    Visible="False">Additional approver #4</asp:Label>
                                            </td>
                                            <td style="WIDTH: 247px" width="247">
                                                <asp:TextBox ID="txtFinalAdditionalApprover4" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkAdditionalApp4Final" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp4Final_Click1">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkAdditionalApp4FYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkAdditionalApp4FYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                              
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of FinalApprovals --%>
                            <tr ID="FinalApprovalsReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="tblFinalApprovalsReadOnly" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="4" width="100%">
                                                Approvals</td>
                                        </tr>
                                        <tr>
                                            <td width="20%">
                                                Please select the type of EO this will be:</td>
                                            <td colSpan="3">
                                                <asp:Label ID="lblEOModeFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr height="5">
                                            <td colSpan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%">
                                                Your approval group is:</td>
                                            <td colSpan="3">
                                                <asp:Label ID="lblApprovalGrpFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="4">
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="1" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td vAlign="top" width="3%">
                                                <asp:Image ID="imgFinalPSIniNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalPSIniYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td width="22%">
                                                PS Initiative Manager:
                                                <asp:Label ID="Label75" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td width="25%">
                                                <asp:Label ID="lblPSInitiativeAppGrp" runat="server"></asp:Label>
                                                
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkPSIniApproved" runat="server" CausesValidation="False" 
                                                    onclick="lnkPSIniApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkPSIniDeclined" runat="server" CausesValidation="False" 
                                                    onclick="lnkPSIniDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td width="20%">
                                                <asp:LinkButton ID="lnkFinBOPSIniComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkFinalPSIntiaBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalPSIntiaBackUp_Click" Visible="False">Back 
                                                Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top" width="3%">
                                                <asp:Image ID="imgFinalProdResNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalProdResYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td width="22%">
                                                Products Research:
                                                <asp:Label ID="Label76" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td width="25%">
                                                <asp:Label ID="lblProdResearchAppGrp" runat="server"></asp:Label>
                                               
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkProdResearchApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkProdResearchApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkProdResearchDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkProdResearchDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td width="20%">
                                                <asp:LinkButton ID="lnkFinProdReseComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkFinalProdReasBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalProdReasBackUp_Click" Visible="False">Back 
                                                Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalBONo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalBOYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                Budget Owner:
                                                <asp:Label ID="Label79" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBOFinalAppGrp" runat="server"></asp:Label>
                                               
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinBudgetApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinBudgetApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinBudgetDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinBudgetDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinBOComments" runat="server" CausesValidation="False" 
                                                    Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalBOBackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinalBOBackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalGBUHSENo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalGBUHSEYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                GBU HS&amp;E Resource
                                                <asp:Label ID="Label80" runat="server" Visible="False">Label</asp:Label>
                                                <br>(FYI Only - NO Approval Required)<br>
                                                
                                            </td>
                                            <td vAlign="top">
                                                <asp:Label ID="lblGBUHSEFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinGBUHSEApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinGBUHSEApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinGBUHSEDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinGBUHSEDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinGBUComments" runat="server" CausesValidation="False" 
                                                    Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalGBUBackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinalGBUBackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalSiteHSENo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalSiteHSEYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                Site HS&amp;E Resource:
                                                <asp:Label ID="Label81" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSiteHSEFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteHSEApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteHSEApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteHSEDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteHSEDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteHSEComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSiteHSEBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalSiteHSEBackUp_Click" Visible="False">Back 
                                                Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalSAPNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalSAPYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                SAP Cost Center Coordinator:
                                                <asp:Label ID="Label82" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSAPCostCenterFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSAPApproved" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinSAPApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSAPDeclined" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinSAPDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSAPComments" runat="server" CausesValidation="False" 
                                                    Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSAPBackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinalSAPBackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalSMARTClearanceNo" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgFinalSMARTClearanceYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                SMART Clearance :
                                                <asp:Label ID="Label21" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSMARTClearanceFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSMARTClearanceApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSMARTClearanceApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSMARTClearanceDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSMARTClearanceDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSMARTClearanceComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSMARTClearanceBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalSMARTClearanceBackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalSitePlanNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalSitePlanYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                Site Planning:
                                                <asp:Label ID="Label83" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSiteplanningFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSitePlanningApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSitePlanningApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSitePlanningDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSitePlanningDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSitePlanComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSitePlnaBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalSitePlnaBackUp_Click" Visible="False">Back 
                                                Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgSiteConNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgSiteConYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                Site Contact:
                                                <asp:Label ID="Label85" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSiteContactFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteContactApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteContactApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteContactDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteContactDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteConComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSiteBackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinalSiteBackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalSiteFinanceNo" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgFinalSiteFinanceYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Site Finance:
                                                <asp:Label ID="Label87" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSiteFinanceFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteFinanceApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteFinanceApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteFinananceDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteFinananceDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteFinaComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSiteSiteFanBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalSiteSiteFanBackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalSiteLeaderNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalSiteLeaderYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Site Leadership
                                                <asp:Label ID="Label88" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSiteLeadeshipFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteLeadershipApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteLeadershipApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteLeadershipDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinSiteLeadershipDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinSiteLeadComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalSiteSiteLeadBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalSiteSiteLeadBackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr ID="trPSRAFinalappr" runat="server" Visible="False">
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalPSRANo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalPSRAYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                PS&amp;RA:
                                                <asp:Label ID="Label89" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPSRAFinalAppGrp" runat="server"></asp:Label>
                                                &nbsp;</td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinPSRAApproved" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinPSRAApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinPSRADeclined" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinPSRADeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinPSRAComments" runat="server" CausesValidation="False" 
                                                    Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalPSRABackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinalPSRABackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalTimingGateNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalTimingGateYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Timing Gate Exception:
                                                <asp:Label ID="Label90" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTimingGateFinalAppGrp" runat="server"></asp:Label>
                                                &nbsp;</td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinTimingGateApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinTimingGateApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinTimingGateDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinTimingGateDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinTimingGateComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalTimingGateBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinalTimingGateBackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Image ID="imgFinalQANo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalQAYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                Site QA (Brand Leader):
                                                <asp:Label ID="Label91" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblQAFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinQAApproved" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinQAApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinQADeclined" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinQADeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinQAComments" runat="server" CausesValidation="False" 
                                                    Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalQABackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkFinalQABackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalCentralQANo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalCentralQAYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Central QA:
                                                <asp:Label ID="Label13" runat="server" Visible="False">Label</asp:Label>
                                                <br>(FYI Only - NO Approval Required)<br>
                                               
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCentralQAFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinCentralQAApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinCentralQAApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinCentralQADeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinCentralQADeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinCentralQAComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinalCentralQABackUp" runat="server" 
                                                    CausesValidation="False" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalStandsNo" Runat="server" imageurl="../Images/No.jpg" 
                                                    Visible="False" />
                                                <asp:Image ID="imgFinalStandsYes" Runat="server" imageurl="../Images/Yes.jpg" 
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                Standards Office:
                                                <asp:Label ID="Label92" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblStandsOfficeFinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinStandardOfficeApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinStandardOfficeApproved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinStandardOfficeDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinStandardOfficeDeclined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinStandsOffComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkStndsOffiBackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkStndsOffiBackUp_Click" Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalAdditionalApprover1No" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgFinalAdditionalApprover1Yes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Additional Approver1:
                                                <asp:Label ID="Label26" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdditionalApprover1FinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover1Approved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover1Approved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover1Declined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover1Declined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover1Comments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover1BackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover1BackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalAdditionalApprover2No" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgFinalAdditionalApprover2Yes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Additional Approver2:
                                                <asp:Label ID="Label28" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdditionalApprover2FinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover2Approved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover2Approved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover2Declined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover2Declined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover2Comments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover2BackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover2BackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalAdditionalApprover3No" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgFinalAdditionalApprover3Yes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Additional Approver3:
                                                <asp:Label ID="Label41" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdditionalApprover3FinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover3Approved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover3Approved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover3Declined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover3Declined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover3Comments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover3BackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover3BackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgFinalAdditionalApprover4No" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgFinalAdditionalApprover4Yes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Additional Approver4:
                                                <asp:Label ID="Label44" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdditionalApprover4FinalAppGrp" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover4Approved" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover4Approved_Click">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover4Declined" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover4Declined_Click">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover4Comments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkFinAdditionalApprover4BackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkFinAdditionalApprover4BackUp_Click" 
                                                    Visible="False">Back Up</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Final Tab details completed--%>
                            <%-- ====================================================================================================== --%>
                            <%-- Opening of Closeout Tab Details --%>
                            <tr ID="CloseFirstSection" runat="server">
                                <%-- opening of CloseFirstSection--%>
                                <td colSpan="4" width="100%">
                                    <table id="TableCloseout" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                <asp:Label ID="Label36" runat="server">Label</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <p>
                                                    Cincinnati Resources, please enter the number of your Lab Notebook (ex. WHS0867) 
                                                    here:</p>
                                                <p>
                                                    Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
                                                    634-7600</p>
                                            </td>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="50%">
                                                <asp:TextBox ID="txtCloseLabNoteBook" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Completion Date:</td>
                                            <td onkeypress="javascript: return AllowDateNumbers(event);" width="50%">
                                                <asp:TextBox ID="txtCloseCompletionDate" runat="server" MaxLength="10" 
                                                    Width="200px"></asp:TextBox>
                                                <img id="Img1" runat="server" alt="To Date" onclick="OpenDateToWindow1()" 
                                                    src="../Images/calendar.gif" style="CURSOR: hand">
                                                    <asp:Label ID="Label2" runat="server">(e.g. 10/20/2010)</asp:Label>
                                                </img>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of CloseFirstSection--%>
                            <tr ID="CloseFirstSectionReadonly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableCloseoutrO" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                <asp:Label ID="Label95" runat="server">Label</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <p>
                                                    Cincinnati Resources, number of your Lab Notebook (ex. WHS0867) here:</p>
                                                <p>
                                                    Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
                                                    634-7600</p>
                                            </td>
                                            <td width="50%">
                                                <asp:Label ID="lblLabNoteBookNumberFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Completion Date:</td>
                                            <td width="50%">
                                                <asp:Label ID="lblComplateionDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="CloseActualCostSheet" runat="server">
                                <%-- opening of CloseActualCostSheet--%>
                                <td colSpan="4" width="100%">
                                    <table id="TableCostSheet" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colSpan="2" width="100%">
                                                Actual Cost Sheet</td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="50%">
                                                Preliminary Selected Budget Center :
                                                <asp:Label ID="lblPreCOSelectedBudgetCenter" runat="server"></asp:Label>
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colSpan="2" width="50%">
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Attach Final Cost Sheet:</td>
                                            <td width="50%">
                                                <input id="txtACAttachment" runat="server" contenteditable="false" 
                                                    name="txtACAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                                <asp:ListBox ID="lbFinalCostAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchCOFinalCost" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchCOFinalCost_Click" />
                                                &nbsp;
                                                <asp:ImageButton ID="imgDelAttchCOFinalCost" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchCOFinalCost_Click" />
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                                <asp:DataGrid ID="dgrdActualCostCloseOut" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" BorderWidth="1px" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdActualCostCloseOut_ItemCommand1" Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkActualCostCloseOut" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkActualCostCloseOut" Runat="server" 
                                                                            CausesValidation="False" CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameActualCostCloseOut" Runat="server" 
                                                                            text='<%# Eval("Actual_Cost_Sheet_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameActualCostCloseOut" Runat="server" 
                                                                            text='<%# Eval("Actual_Cost_Sheet_Attach_ID")%>' Visible="false">
                                                                        </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkActualCostCloseOut" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Please enter the total from the Cost Sheet Attachment:</td>
                                            <td onkeypress="javascript: return AllowNumeric(event);" width="50%">
                                                <asp:TextBox ID="txtTotalCostSheetAttach" runat="server" MaxLength="8" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of CloseActualCostSheet--%>
                            <tr ID="CloseActualCostSheetReadonly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableCostSheetRO" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colspan="2" width="100%">
                                                Actual Cost Sheet</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                Preliminary Selected Budget Center :
                                                <asp:Label ID="lblPreCOSelBudgetCenterLock" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr height="3">
                                            <td colSpan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Total from the Cost Sheet Attachment:</td>
                                            <td width="50%">
                                                <asp:DataGrid ID="dgrdActualCostCloseOut_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdActualCostCloseOut_Readonly_ItemCommand1" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkActualCostCloseOutRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkActualCostCloseOutRO" Runat="server" 
                                                                            CausesValidation="False" CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameActualCostCloseOutRO" Runat="server" 
                                                                            text='<%# Eval("Actual_Cost_Sheet_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameActualCostCloseOutRO" Runat="server" 
                                                                            text='<%# Eval("Actual_Cost_Sheet_Attach_ID")%>' Visible="false">
                                                                        </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkActualCostCloseOutRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr height="3">
                                            <td colSpan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                Final Cost Sheet:</td>
                                            <td width="50%">
                                                <asp:Label ID="lblAttchFinalCost" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr height="3">
                                            <td colSpan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="CloseInitialLearningReport" runat="server">
                                <%-- opening of CloseInitialLearningReport --%>
                                <td colSpan="4" width="100%">
                                    <table ID="TableILR" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header">
                                                Intial Learining Report</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input id="txtILR" runat="server" contenteditable="false" 
                                                    name="txtACAttachment" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="lbILR" runat="server" CssClass="txtbox" Font-Size="XX-Small" 
                                                    Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddILR" runat="server" CausesValidation="False" 
                                                    ImageUrl="../Images/add.gif" onclick="imgAddILR_Click1" />
                                                &nbsp;<asp:ImageButton ID="imgDelILR" runat="server" CausesValidation="False" 
                                                    ImageUrl="../Images/delete.gif" onclick="imgDelILR_Click1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td ID="Td2" runat="server">
                                                <asp:DataGrid ID="dgrdILR" Runat="server" AutoGenerateColumns="False" 
                                                    BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                    HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdILR_ItemCommand1" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkILR" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkILR" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblsubFileNameILR" Runat="server" 
                                                                            text='<%# Eval("Initial_Learning_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameILR" Runat="server" 
                                                                            text='<%# Eval("Initial_Learning_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkILR" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of CloseInitialLearningReport --%>
                            <tr ID="CloseInitialLearningReportReadOnly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableTestPlansro" class="AlternateSection2" width="100%">
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Header" colspan="2">
                                                Intial Learining Report</td>
                                            <tr height="3">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="50%">
                                                    Intial Learining Report Attachment:</td>
                                                <td width="50%">
                                                    <asp:DataGrid ID="dgrdILR_Readonly" Runat="server" AutoGenerateColumns="False" 
                                                        BorderColor="black" CellPadding="1" CellSpacing="1" GridLines="None" 
                                                        HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdILR_Readonly_ItemCommand1" 
                                                        ShowHeader="False" Width="380px">
                                                        <HeaderStyle CssClass="SubHeader" />
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="updpanlnkILRRO" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lnkILRRO" Runat="server" CausesValidation="False" 
                                                                                CommandName="Final_Click" Visible="true">
                                                                            <asp:Label ID="lblsubFileNameILRRO" Runat="server" 
                                                                                text='<%# Eval("Initial_Learning_Attachment_File_Name")%>' Visible="true">
                                                                            </asp:Label>
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lblFileNameILRRO" Runat="server" 
                                                                                text='<%# Eval("Initial_Learning_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                        </ContentTemplate>
                                                                        <triggers>
                                                                            <asp:PostBackTrigger ControlID="lnkILRRO" />
                                                                        </triggers>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr height="3">
                                                <td>
                                                </td>
                                            </tr>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="CloseTestPlansUsed" runat="server">
                                <%-- opening of CloseTestPlansUsed--%>
                                <td colSpan="4" width="100%">
                                    <table id="TableTestPlansco" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colspan="2" width="100%">
                                                Test Plans Used</td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                                <asp:UpdatePanel ID="upCloseTestPlanTemplate" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkCloseTestPlanTemplate2" runat="server" 
                                                            CausesValidation="False" onclick="lnkCloseTestPlanTemplate2_Click">Click 
                                                        Here to go to the Test Plan template
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                    <triggers>
                                                        <asp:PostBackTrigger ControlID="lnkCloseTestPlanTemplate2" />
                                                    </triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td width="50%">
                                                <input id="txtTPAttach" runat="server" contenteditable="false" 
                                                    name="txtTPAttach" size="50" style="WIDTH: 465px" type="file">
                                                </input>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                                <asp:ListBox ID="lbTestPlanUsedAttach" runat="server" CssClass="txtbox" 
                                                    Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                &nbsp;<asp:ImageButton ID="imgAddAttchCOTestPlan" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/add.gif" 
                                                    onclick="imgAddAttchCOTestPlan_Click1" />
                                                &nbsp;
                                                <asp:ImageButton ID="imgDelAttchCOTestPlan" runat="server" 
                                                    CausesValidation="False" ImageUrl="../Images/delete.gif" 
                                                    onclick="imgDelAttchCOTestPlan_Click1" />
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%">
                                            </td>
                                            <td width="50%">
                                                <asp:DataGrid ID="dgrdTestPlansCloseOut" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" BorderWidth="1px" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                    onitemcommand="dgrdTestPlansCloseOut_ItemCommand1" Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkTestPlansCloseOut" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkTestPlansCloseOut" Runat="server" 
                                                                            CausesValidation="False" CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameTestPlansCloseOut" Runat="server" 
                                                                            text='<%# Eval("Plans_Used_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameTestPlansCloseOut" Runat="server" 
                                                                            text='<%# Eval("Plans_Used_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkTestPlansCloseOut" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of CloseTestPlansUsed--%>
                            <tr ID="CloseTestPlansUsedReadonly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableTestPlans" class="AlternateSection2" width="100%">
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Header" colspan="2" width="100%">
                                                Test Plans Used</td>
                                            <tr height="3">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="50%">
                                                    Test Plans Used Attachment:</td>
                                                <td width="50%">
                                                    <asp:DataGrid ID="dgrdTestPlansCloseOut_Readonly" Runat="server" 
                                                        AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                        GridLines="None" HeaderStyle-CssClass="SubHeader" 
                                                        onitemcommand="dgrdTestPlansCloseOut_Readonly_ItemCommand1" ShowHeader="False" 
                                                        Width="380px">
                                                        <HeaderStyle CssClass="SubHeader" />
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="updpanlnkTestPlansCloseOutRO" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lnkTestPlansCloseOutRO" Runat="server" 
                                                                                CausesValidation="False" CommandName="Final_Click" Visible="true">
                                                                            <asp:Label ID="lblFullfnameTestPlansCloseOutRO" Runat="server" 
                                                                                text='<%# Eval("Plans_Used_Attachment_File_Name")%>' Visible="true">
                                                                            </asp:Label>
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lblFileNameTestPlansCloseOutRO" Runat="server" 
                                                                                text='<%# Eval("Plans_Used_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                        </ContentTemplate>
                                                                        <triggers>
                                                                            <asp:PostBackTrigger ControlID="lnkTestPlansCloseOutRO" />
                                                                        </triggers>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="CloseOutReport" runat="server">
                                <%-- opening of CloseoutReport --%>
                                <td colSpan="4" width="100%">
                                    <table id="Table6" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colspan="3" width="100%">
                                                Close Out Report</td>
                                        </tr>
                                        <tr id="trCloseOutReportAttach">
                                            <td colspan="3">
                                                <table ID="tblCloseOutAttachments">
                                                    <tr>
                                                        <td>
                                                            <input id="txtCOReport" runat="server" contenteditable="false" 
                                                                name="txtTPAttach" size="50" style="WIDTH: 465px" type="file">
                                                            </input>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox ID="lbCOReport" runat="server" CssClass="txtbox" 
                                                                Font-Size="XX-Small" Height="50px" Width="380px"></asp:ListBox>
                                                            &nbsp;<asp:ImageButton ID="imgAddlbCOReport" runat="server" CausesValidation="False" 
                                                                ImageUrl="../Images/add.gif" onclick="imgAddlbCOReport_Click1" />
                                                            &nbsp;<asp:ImageButton ID="imgDellbCOReport" runat="server" CausesValidation="False" 
                                                                ImageUrl="../Images/delete.gif" onclick="imgDellbCOReport_Click1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DataGrid ID="dgrdCOReport" Runat="server" AutoGenerateColumns="False" 
                                                                BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                                HeaderStyle-CssClass="SubHeader" onitemcommand="dgrdCOReport_ItemCommand1" 
                                                                Width="380px">
                                                                <HeaderStyle CssClass="SubHeader" />
                                                                <Columns>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:UpdatePanel ID="updpanlnkCOReport" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="lnkCOReport" Runat="server" CausesValidation="False" 
                                                                                        CommandName="Final_Click" Visible="true">
                                                                                    <asp:Label ID="lblFullfnameCOReport" Runat="server" 
                                                                                        text='<%# Eval("Closeout_Report_Attachment_File_Name")%>' Visible="true">
                                                                                    </asp:Label>
                                                                                    </asp:LinkButton>
                                                                                    <asp:Label ID="lblFileNameCOReport" Runat="server" 
                                                                                        text='<%# Eval("Closeout_Report_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                                </ContentTemplate>
                                                                                <triggers>
                                                                                    <asp:PostBackTrigger ControlID="lnkCOReport" />
                                                                                </triggers>
                                                                            </asp:UpdatePanel>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" width="100%">
                                                Please list any keywords from the Close-Out Report</td>
                                        </tr>
                                        <tr>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="33%">
                                                <asp:Label ID="lbl1" runat="server">1)</asp:Label>
                                                &nbsp;<asp:TextBox ID="txtCloseKeyworkd1" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="33%">
                                                <asp:Label ID="lbl2" runat="server">2)</asp:Label>
                                                &nbsp;<asp:TextBox ID="txtCloseKeyworkd2" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="34%">
                                                <asp:Label ID="lbl3" runat="server">3)</asp:Label>
                                                &nbsp;<asp:TextBox ID="txtCloseKeyworkd3" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="33%">
                                                <asp:Label ID="lbl4" runat="server">4)</asp:Label>
                                                &nbsp;<asp:TextBox ID="txtCloseKeyworkd4" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="33%">
                                                <asp:Label ID="lbl5" runat="server">5)</asp:Label>
                                                &nbsp;<asp:TextBox ID="txtCloseKeyworkd5" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td onkeypress="javascript: return NoSpecialCharacters(event);" width="34%">
                                                <asp:Label ID="lbl6" runat="server">6)</asp:Label>
                                                &nbsp;<asp:TextBox ID="txtCloseKeyworkd6" runat="server" MaxLength="50" 
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="TableTestPlansSub" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td width="50%">
                                                Please enter any Comments to the Approvers here :</td>
                                            <td width="50%">
                                                <asp:TextBox ID="txtCloseApproverComments" runat="server" MaxLength="1000" 
                                                    TextMode="MultiLine" 
                                                    ToolTip="Please enter comments to the approvers of max 1000 characters." 
                                                    Width="400px"></asp:TextBox>
                                                &nbsp;
                                                <asp:Label ID="Label42" runat="server" CssClass="NoteMsg">NOTE: Limit to 1000 
                                                Characters</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" width="100%">
                                                &nbsp;
                                                <asp:LinkButton ID="lnkCloseOutPreviousCommnets" runat="server" 
                                                    onclick="lnkCloseOutPreviousCommnets_Click">Previous Comments</asp:LinkButton>
                                                &nbsp;
                                                <asp:Label ID="Label1" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of CloseoutReport --%>
                            <tr ID="CloseoutReportRO" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="Table7" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td class="Header" colspan="3" width="100%">
                                                Close Out Report</td>
                                        </tr>
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr id="trCloseOutReportAttachRO">
                                            <td width="50%">
                                                Close Out Report Attachments:</td>
                                            <td width="50%">
                                                &nbsp;&nbsp;&nbsp;<asp:DataGrid ID="dgrdCOReport_Readonly" Runat="server" 
                                                    AutoGenerateColumns="False" BorderColor="black" CellPadding="1" CellSpacing="1" 
                                                    GridLines="None" HeaderStyle-CssClass="SubHeader" ShowHeader="False" 
                                                    Width="380px">
                                                    <HeaderStyle CssClass="SubHeader" />
                                                    <Columns>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updpanlnkCOReportRO" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkCOReportRO" Runat="server" CausesValidation="False" 
                                                                            CommandName="Final_Click" Visible="true">
                                                                        <asp:Label ID="lblFullfnameCOReportRO" Runat="server" 
                                                                            text='<%# Eval("Closeout_Report_Attachment_File_Name")%>' Visible="true">
                                                                        </asp:Label>
                                                                        </asp:LinkButton>
                                                                        <asp:Label ID="lblFileNameCOReportRO" Runat="server" 
                                                                            text='<%# Eval("Closeout_Report_Attach_ID")%>' Visible="false"> </asp:Label>
                                                                    </ContentTemplate>
                                                                    <triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkCOReportRO" />
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" width="100%">
                                                Keywords from the Close-Out Report</td>
                                        </tr>
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%">
                                                1)&nbsp;<asp:Label ID="lblCloseKeyword1" runat="server"></asp:Label>
                                            </td>
                                            <td width="25%">
                                                2)&nbsp;<asp:Label ID="lblCloseKeyword2" runat="server"></asp:Label>
                                            </td>
                                            <td width="25%">
                                                3)&nbsp;<asp:Label ID="lblCloseKeyword3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%">
                                                4)&nbsp;<asp:Label ID="lblCloseKeyword4" runat="server"></asp:Label>
                                            </td>
                                            <td width="25%">
                                                5)&nbsp;<asp:Label ID="lblCloseKeyword5" runat="server"></asp:Label>
                                            </td>
                                            <td width="25%">
                                                6)&nbsp;<asp:Label ID="lblCloseKeyword6" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="TableTestPlansSub" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td width="50%">
                                                Comments to the Approvers here :</td>
                                            <td width="50%">
                                                <asp:Label ID="lblAppCommentsFinal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" width="100%">
                                                <asp:LinkButton ID="lnkCloseOutPreviousCommnetsRO" runat="server" 
                                                    onclick="lnkCloseOutPreviousCommnetsRO_Click">Previous Comments :</asp:LinkButton>
                                                &nbsp;
                                                <asp:Label ID="lblCloseOutPreviousCommnets" runat="server" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="CloseApprovals" runat="server">
                                <%-- opening of CloseApprovals--%>
                                <td colSpan="4" width="100%">
                                    <table id="TableApproval" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colspan="3" style="HEIGHT: 18px" width="100%">
                                                Approvals</td>
                                        </tr>
                                        <tr>
                                            <td style="HEIGHT: 22px" width="50%">
                                                Your approval group is :</td>
                                            <td colspan="2" style="HEIGHT: 22px" width="50%">
                                                <asp:DropDownList ID="drpCloseApprovalGroup" runat="server" AutoPostBack="True" 
                                                    Width="300px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" width="100%">
                                                <asp:Label ID="Label40" runat="server" CssClass="NoteMsg">You can override these 
                                                values by selecting the correct approver from the list.</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="HEIGHT: 45px" width="30%">
                                                Site Finance :&nbsp;
                                                <asp:Label ID="lblCOAppgrpSiteFinance" runat="server" Visible="False">Site Finance</asp:Label>
                                            </td>
                                            <td style="HEIGHT: 45px" width="30%">
                                                <asp:TextBox ID="txtCloseSiteFinance" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkSiteFinaceCOChangeApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteFinaceCOChangeApp_Click">Change 
                                                Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkSiteFinanceCOFYI" runat="server" 
                                                    CausesValidation="False" onclick="lnkSiteFinanceCOFYI_Click">FYI Not 
                                                Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                                Budget Owner :&nbsp;
                                                <asp:Label ID="lblCOAppgrpBO" runat="server" Visible="False">Budget Center</asp:Label>
                                            </td>
                                            <td width="30%">
                                                <asp:TextBox ID="txtCloseBudgetOwner" runat="server" Enabled="False" 
                                                    Width="230px"></asp:TextBox>
                                                <br>
                                                <asp:LinkButton ID="lnkBOCOChangeApp" runat="server" CausesValidation="False" 
                                                    onclick="lnkBOCOChangeApp_Click">Change Approver</asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lnkBOCOFYI" runat="server" CausesValidation="False" 
                                                    onclick="lnkBOCOFYI_Click">FYI Not Necessary</asp:LinkButton>
                                               
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td height="10" width="30%">
                                            </td>
                                            <td width="40%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                                Originator :</td>
                                            <td width="30%">
                                                <asp:Label ID="lblCloseOriginatorDB" runat="server"></asp:Label>
                                            </td>
                                            <td width="40%">
                                                <asp:LinkButton ID="lnkApproveCloseoutEO" runat="server" 
                                                    onclick="lnkApproveCloseoutEO_Click1" Visible="False">Complete this EO</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td width="30%">
                                            </td>
                                            <td width="40%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- Closing of CloseApprovals--%>
                            <tr ID="CloseApprovalsReadonly" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableApprovalRO" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td class="Header" colspan="4" style="HEIGHT: 18px" width="100%">
                                                Approvals</td>
                                        </tr>
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%">
                                                Your approval group is :</td>
                                            <td colspan="3">
                                                <asp:Label ID="lblAppgrpCO" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr height="3">
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="1" class="AlternateSection2" width="100%">
                                        <tr>
                                            <td vAlign="top" width="3%">
                                                <asp:Image ID="imgCloseOutSiteFinanceNo" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgCloseOutSiteFinanceYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td width="25%">
                                                Site Finance :&nbsp;
                                                <asp:Label ID="Label105" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblSiteFinanceAppCO" runat="server"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkCloseSiteFinanceApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkCloseSiteFinanceApproved_Click1">Approve</asp:LinkButton>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkCloseSiteFinanceDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkCloseSiteFinanceDeclined_Click1">Decline</asp:LinkButton>
                                            </td>
                                            <td width="20%">
                                                <asp:LinkButton ID="lnkCOSiteFinanceComments" runat="server" 
                                                    CausesValidation="False" Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkCOSiteFinaBackUp" runat="server" 
                                                    CausesValidation="False" onclick="lnkCOSiteFinaBackUp_Click1" Visible="False">Back 
                                                Up</asp:LinkButton>
                                                <asp:TextBox ID="TxtAppYes" runat="server" style="DISPLAY: none" Width="0px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td vAlign="top">
                                                <asp:Image ID="imgCloseOutBudgetOwnerNo" Runat="server" 
                                                    imageurl="../Images/No.jpg" Visible="False" />
                                                <asp:Image ID="imgCloseOutBudgetOwnerYes" Runat="server" 
                                                    imageurl="../Images/Yes.jpg" Visible="False" />
                                            </td>
                                            <td>
                                                Budget Owner :&nbsp;<asp:Label ID="Label106" runat="server" Visible="False">Label</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBOAppCO" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkCloseBudgetApproved" runat="server" 
                                                    CausesValidation="False" onclick="lnkCloseBudgetApproved_Click1">Approve</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkCloseBudgetDeclined" runat="server" 
                                                    CausesValidation="False" onclick="lnkCloseBudgetDeclined_Click1">Decline</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkCOBOComments" runat="server" CausesValidation="False" 
                                                    Visible="False">View Previous Comments</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkCOBOBackUp" runat="server" CausesValidation="False" 
                                                    onclick="lnkCOBOBackUp_Click1" Visible="False">Back Up</asp:LinkButton>
                                                <asp:TextBox ID="TxtAppNo" runat="server" style="DISPLAY: none" Width="0px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="CloseRevision" runat="server">
                                <td colSpan="4" width="100%">
                                    <table id="TableLast" width="100%">
                                        <tr>
                                            <td style="HEIGHT: 21px" width="100%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr ID="PreliminaryRevision" runat="server">
                                <%-- opening of Preliminary Revision --%>
                                <td colSpan="4" width="100%">
                                    <table id="TableFinal" class="AlternateSection1" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <asp:LinkButton ID="lnkbeforeFinTabRouApp" runat="server" 
                                                    CausesValidation="False" onclick="lnkbeforeFinTabRouApp_Click1">Click here 
                                                to enter the data on the final tab before routing to the approvers</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                            </td>
                                        </tr>
                                        <!-- jagan code --->
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkConGrp" Runat="server" CausesValidation="False" 
                                                                onclick="lnkConGrp_Click" Visible="False">Concurence Group</asp:LinkButton>
                                                            <div style="display:none">
                                                                <asp:Button ID="btnApp" runat="server" OnClick="btnApp_Click" Text="btnApp" />
                                                                <asp:Button ID="btnConApp" runat="server" OnClick="btnConApp_Click" 
                                                                    Text="btnConApp" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="hdnConAppID" runat="server" />
                                                            <asp:HiddenField ID="hdnOrigAppr" runat="server" />
                                                            <asp:DataGrid ID="dgrConcurenceGrp" Runat="server" AutoGenerateColumns="False" 
                                                                BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                                HeaderStyle-CssClass="SubHeader" onitemcommand="dgrConcurenceGrp_ItemCommand" 
                                                                onitemdatabound="dgrConcurenceGrp_ItemDataBound" ShowHeader="False" 
                                                                Visible="False" Width="100%">
                                                                <HeaderStyle CssClass="SubHeader" />
                                                                <Columns>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label5" Runat="server" text='<%# Eval("Created_Date")%>'>
                                                                            </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblConGrpName" Runat="server" 
                                                                                text='<%# Eval("Concurrence_Group_Name")%>'> </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Label ID="lblConGrpID" Runat="server" 
                                                                                text='<%# Eval("Concurrence_Group_ID")%>' Visible="false"> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblapprName" Runat="server" text='<%# Eval("Approver_Name")%>'>
                                                                            </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:HiddenField ID="hdndgrConcurenceGrpName" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="Response">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label9" Runat="server" text='<%# Eval("Is_Responded")%>'>
                                                                            </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkApproval" Runat="server" CausesValidation="False" 
                                                                                CommandName="Approval_Link" Visible="False" Width="120px">Concur
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lblConAppGrpID" Runat="server" 
                                                                                text='<%# Eval("Concurrence_Group_ID")%>' Visible="false"> </asp:Label>
                                                                            <asp:Label ID="lnkapprName" Runat="server" text='<%# Eval("Approver_Name")%>' 
                                                                                Visible="false"> </asp:Label>
                                                                            <asp:Label ID="lblConAppID" Runat="server" text='<%# Eval("EO_Con_App_ID")%>' 
                                                                                Visible="false"> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDeclined" Runat="server" CausesValidation="False" 
                                                                                CommandName="Declined_Link" Visible="False" Width="120px">
                                                                            <asp:Label ID="lnkDecApprName" Runat="server" 
                                                                                text='<%# Eval("Approver_Name")%>' Visible="false"> </asp:Label>
                                                                            Decline
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lblConDecGrpID" Runat="server" 
                                                                                text='<%# Eval("Concurrence_Group_ID")%>' Visible="false"> </asp:Label>
                                                                            <asp:Label ID="lblConDecAppID" Runat="server" 
                                                                                text='<%# Eval("EO_Con_App_ID")%>' Visible="false"> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkBackUp" Runat="server" CausesValidation="False" 
                                                                                CommandName="Backup_Link" Visible="False">
                                                                            <asp:Label ID="lnkBakApprName" Runat="server" 
                                                                                text='<%# Eval("Approver_Name")%>' Visible="false"> </asp:Label>
                                                                            BackUp
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                            <asp:TextBox ID="hdnApprover" runat="server" style="DISPLAY: none" Width="0"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkPreScreener" Runat="server" CausesValidation="False" 
                                                                onclick="lnkPreScreener_Click" Visible="False">Prescreeners Group</asp:LinkButton>
                                                            <div style="display:none">
                                                                <asp:Button ID="btnAppPreScreen" runat="server" OnClick="btnAppPreScreen_Click" 
                                                                    Text="btnAppPreScreen" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="hdnPreAppID" runat="server" />
                                                            <asp:HiddenField ID="hdnPreOrigAppr" runat="server" />
                                                            <asp:DataGrid ID="dgrPrescrenners" Runat="server" AutoGenerateColumns="False" 
                                                                BorderColor="black" BorderWidth="1px" GridLines="None" 
                                                                HeaderStyle-CssClass="SubHeader" onitemcommand="dgrPrescrenners_ItemCommand" 
                                                                ShowHeader="False" Visible="False" Width="100%">
                                                                <HeaderStyle CssClass="SubHeader" />
                                                                <Columns>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label11" Runat="server" text="<%#DateTime.Now.ToString()%>">
                                                                            </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPreScreenerGrpName" Runat="server" 
                                                                                text='<%# Eval("Prescreener_Group_Name")%>'> </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp; </asp:label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPreScreenerAppID" Runat="server" 
                                                                                text='<%# Eval("Approver_Name")%>'> </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp; </asp:label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label8" Runat="server" text='<%# Eval("is_responded")%>' 
                                                                                Width="150px"> </asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp; </asp:label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPreApproval" Runat="server" CausesValidation="False" 
                                                                                CommandName="Approval_Link" Visible="False" Width="120px"> Approve
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lnkPreapprName" Runat="server" 
                                                                                text='<%# Eval("Approver_Name")%>' Visible="false"> </asp:Label>
                                                                            <asp:Label ID="lblPreConAppID" Runat="server" text='<%# Eval("EO_ps_App_ID")%>' 
                                                                                Visible="false"> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPreDeclined" Runat="server" CausesValidation="False" 
                                                                                CommandName="Declined_Link" Visible="False" Width="120px">
                                                                            <asp:Label ID="lnkPreDecApprName" Runat="server" 
                                                                                text='<%# Eval("Approver_Name")%>' Visible="false"> </asp:Label>
                                                                            Decline
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                            <asp:TextBox ID="hdnPreApprover" runat="server" style="DISPLAY: none" Width="0"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <!-- End of the jagan code -->
                                        <tr>
                                            <td style="HEIGHT: 20px" width="100%">
                                                <asp:Label ID="lblRevisionHistory" runat="server">Revision History</asp:Label>
                                                <asp:DataGrid ID="dgrdRevHistory" runat="server" ShowHeader="False">
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:Label ID="lblApprovals" runat="server">Approvals</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:DataGrid ID="dgrdAppHistory" runat="server" ShowFooter="True" 
                                                    ShowHeader="False">
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:TextBox ID="txtMessage" Runat="server" style="DISPLAY: none" Width="0px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" width="100%">
                                    <uc2:FooterControl ID="FooterControl1" runat="server" />
                                </td>
                            </tr>
              
			</table>
                        </div>
                    <asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                    <asp:TextBox ID="hdnApprover1" runat="server" style="DISPLAY: none" Width="0"></asp:TextBox>
            </ContentTemplate>
            <Triggers> 
                <asp:PostBackTrigger ControlID="imgAddAttachments" /> 
                <asp:PostBackTrigger ControlID="imgAddAttachFinalCostSheet" /> 
                <asp:PostBackTrigger ControlID="imgAddAttachFinalQA" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchFinalFormulaCard" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchFinalTestPlans" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchFinalLabSamples" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchFinalFlowMatrix" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchFinalOtherSup" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchCOFinalCost" /> 
                <asp:PostBackTrigger ControlID="imgAddILR" /> 
                <asp:PostBackTrigger ControlID="imgAddAttchCOTestPlan" /> 
                <asp:PostBackTrigger ControlID="imgAddlbCOReport" /> 
            </Triggers>
    </asp:UpdatePanel>
     
			</form>
	</body>
</html>


