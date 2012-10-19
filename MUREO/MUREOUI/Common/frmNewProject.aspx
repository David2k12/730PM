<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNewProject.aspx.cs"
    Inherits="MUREOUI.frmNewProject" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc1" %>
<%@ Register Src="~/UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc2" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN">
<html>
<head>
    <title>Project</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" language="javascript">

        String.prototype.trim = function () {
            return this.replace(/^\s+|\s+$/g, "");
        }
        String.prototype.ltrim = function () {
            return this.replace(/^\s+/, "");
        }
        String.prototype.rtrim = function () {
            return this.replace(/\s+$/, "");
        }
        function AddBookMultiUser() {
            var popres;
            popres = document.getElementById('txtPrjLead').value;
            var strTxtPrjLead = document.getElementById("<%=txtPrjLead.ClientID %>").id;
            var hdntxtprjlead = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
            if (popres == "")
                window.open('ShowUsers.aspx?ID=' + strTxtPrjLead + '&Hidd=' + hdntxtprjlead, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('ShowUsers.aspx?ShowUserList=' + popres + '&ID=' + strTxtPrjLead + '&Hidd=' + hdntxtprjlead, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }
        function AddBookMultiUser1() {
            var strPOC = document.getElementById("<%=txtPOC.ClientID %>").id;
            var hdnPOC = document.getElementById("<%=hdnPOC.ClientID %>").id;
            var popres;
            popres = document.getElementById('txtPOC').value;
            if (popres == "")
                window.open('ShowUsers.aspx?ID=' + strPOC + '&Hidd=' + hdnPOC, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            else
                window.open('ShowUsers.aspx?ShowUserList=' + popres + '&ID=' + strPOC + '&Hidd=' + hdnPOC, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');
            return false;
        }

        function NoSpecialCharacters() {
            var k;
            k = event.keyCode;
            if (!(k == 35) && !(k == 36) && !(k == 37) && !(k == 94) && !(k == 61) && !(k == 42)) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
    <%--		<script language="javascript">

		 
		    //new code
		    function AddBookMultiUser() {
		        var popResult;
		        var popres;
		        var strTxtPrjLead = document.getElementById('txtPrjLead').value;
                var strTxtPrjLead = document.getElementById('txtPrjLead').value;
		        popres = document.getElementById('txtPrjLead').value;
		        if (popres != "") {
		            popResult = window.showModalDialog('ShowUsers.aspx?ShowUserList=' + popres +' &ID='+, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');		          		            
		            if (popResult != "") {
		                document.getElementById('txtPrjLead').value = popResult;
		                document.getElementById("<%= hdntxtPrjLead.ClientID %>").value = popResult;
                     }
		            if (document.getElementById('txtPrjLead').value == 'undefined') {
		                document.getElementById('txtPrjLead').value = strTxtPrjLead;
		                document.getElementById("<%= hdntxtPrjLead.ClientID %>").value = strTxtPrjLead;
		            }
		            return false;
		        }
		        else {
		            popResult = window.showModalDialog('ShowUsers.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');		           
		            if (popResult != "") {
		                document.getElementById('txtPrjLead').value = popResult;
		                document.getElementById("<%= hdntxtPrjLead.ClientID %>").value = popResult;
                     }
		            if (document.getElementById('txtPrjLead').value == 'undefined') {
		                document.getElementById('txtPrjLead').value = strTxtPrjLead;
		                document.getElementById("<%= hdntxtPrjLead.ClientID %>").value = strTxtPrjLead;
		            }
		            return false;
		        }
		    }

		    //Previous code
		    /* function AddBookMultiUser()
		    {	var popResult;
		    popResult=window.showModalDialog('ShowUsers.aspx?from=CheckingUser','ShowUsers','status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
		    if(popResult!="")
		    {document.getElementById('txtPrjLead').value = popResult;} 
		    if (document.getElementById('txtPrjLead').value == 'undefined')
		    {
		    document.getElementById('txtPrjLead').value = "";
		    }
		    }
		    */


		    function AddBookMultiUser1() {		      
		        var popResult;
		        var popres;
		        popres = document.getElementById('txtPOC').value;
		        var strPOC = document.getElementById('txtPOC').value;
		        if (popres != "") {
		           window.showModalDialog('ShowUsers.aspx?ShowUserList=' + popres, 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');		           
		            return false; 
		            if (popResult != "") {
		                document.getElementById('txtPOC').value = popResult;
		                document.getElementById("<%= hdnPOC.ClientID %>").value = popResult;
                     }
		            if (document.getElementById('txtPOC').value == 'undefined') {
		                document.getElementById('txtPOC').value = strPOC;
		                document.getElementById("<%= hdnPOC.ClientID %>").value = strPOC;
		            }
		            return false;
		        }
		        else {
		            popResult = window.showModalDialog('ShowUsers.aspx', 'ShowUsers', 'status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');		            		          
		            if (popResult != "") {
		                document.getElementById('txtPOC').value = popResult;
		                document.getElementById("<%= hdnPOC.ClientID %>").value = popResult;
                     }
		            if (document.getElementById('txtPOC').value == 'undefined') {
		                document.getElementById('txtPOC').value = strPOC;
		                document.getElementById("<%= hdnPOC.ClientID %>").value = strPOC;
		            }
		            return false;
		        }
		    }


		    //Previous code
		    /*function AddBookMultiUser1()
		    {
		    var popResult;
		    popResult=window.showModalDialog('ShowUsers.aspx?from=CheckingUser','ShowUsers','status:no; dialogWidth:800px; dialogHeight:550px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No');
		    if(popResult!="")
		    {document.getElementById('txtPOC').value = popResult;} 
		    if (document.getElementById('txtPOC').value == 'undefined')
		    {
		    document.getElementById('txtPOC').value = "";
		    }
		    }*/
		
		</script>--%>
    <script language="javascript" type="text/javascript">

        function CheckCategory(sender, args) {
            if (document.getElementById('drpCategory').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckBrand(sender, args) {
            if (document.getElementById('drpBrand').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function CheckProjectType(sender, args) {
            if (document.getElementById('drpPrjType').selectedIndex == 0) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
        function ValidateFocus() {
            e = document.getElementById('drpCategory');
            f = document.getElementById('drpBrand');
            g = document.getElementById('drpPrjType');

            if (e.value == "0") {
                document.getElementById('drpCategory').focus();
            }
            else if (f.value == "0") {
                document.getElementById('drpBrand').focus();
            }
            else if (document.getElementById('txtPrjName').value == "") {
                document.getElementById('txtPrjName').focus();
            }
            else if (g.value == "0") {
                document.getElementById('drpPrjType').focus();
            }
        }

        function ConfirmDelete(messageval, cntrlName) {
            if (document.getElementById(cntrlName).value != "") {
                var agree = confirm(messageval);
                if (agree == true) {
                    //return true;
                    document.getElementById(cntrlName).value = "";
                    if(cntrlName=="txtPrjLead")
                        document.getElementById("<%=hdntxtPrjLead.ClientID %>").value = "";
                    if (cntrlName == "txtPOC")
                        document.getElementById("<%=hdnPOC.ClientID %>").value = "";
                    return false;
                }
                else {
                    return false;
                }
            }
            return false;
        }

    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table height="96%" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnImgPrevID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="Formheader" align="center">
                        <asp:Label ID="lblHeading" runat="server">New Project</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="imgSubmit_CreateNewProject" runat="server" ImageUrl="../Images/submit-create-new-proj.gif"
                            AlternateText="Submit &amp; Create New Project" OnClick="imgSubmit_CreateNewProject_Click">
                        </asp:ImageButton>&nbsp;&nbsp;
                        <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl="../Images/submit.gif" OnClick="imgSubmit_Click">
                        </asp:ImageButton>&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="../Images/cancel.gif" CausesValidation="False"
                            OnClick="imgCancel_Click"></asp:ImageButton>&nbsp;&nbsp;
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="../Images/New-Delete.gif"
                            CausesValidation="False" OnClick="imgDelete_Click"></asp:ImageButton>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="astrisk" align="center">
                        *- Mandatory Fields
                    </td>
                </tr>
                
                <tr>
                    <%--<td width="20%">
                    <uc3:leftnavigationcontrol id="LeftNavigationControl1" runat="server"></uc3:leftnavigationcontrol>
                    </td>--%>
                    <td valign="top">
                        <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
                                            <tbody>
                                                <tr height="10">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FieldNames" align="right" width="45%">
                                                        Category:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" width="20%">
                                                        <asp:dropdownlist id="drpCategory" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" Runat="server" Width="158px" AutoPostBack="true"></asp:dropdownlist>
                                                       <%-- <dx:ASPxComboBox ID="drpCategory" runat="server" Style="margin-top: 0px" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                                        </dx:ASPxComboBox>--%>
                                                    </td>
                                                    <td>
                                                        <font class="astrisk">*</font>
                                                        <asp:CustomValidator ID="cstvdCategory" runat="server" ClientValidationFunction="CheckCategory"
                                                            ControlToValidate="drpCategory" Display="None" ErrorMessage="Please select Category."></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr height="15">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FieldNames" align="right">
                                                        Brand Segment:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:dropdownlist id="drpBrand" Runat="server" Width="158px" > </asp:dropdownlist>
                                                       <%-- <dx:ASPxComboBox ID="drpBrand" runat="server" ClientIDMode="AutoID" ValueType="System.String">
                                                            <Items>
                                                                <dx:ListEditItem Selected="True" Text="None" />
                                                            </Items>
                                                        </dx:ASPxComboBox>--%>
                                                    </td>
                                                    <td>
                                                        <font class="astrisk">*</font>
                                                        <asp:CustomValidator ID="cstvdBrand" runat="server" ClientValidationFunction="CheckBrand"
                                                            ControlToValidate="drpBrand" Display="None" ErrorMessage="Please select Brand Segment."></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr height="15">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FieldNames" onkeypress="javascript: return NoSpecialCharacters(event);"
                                                        align="right">
                                                        Project Name:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtPrjName" runat="server" Width="170px" MaxLength="100"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <font class="astrisk">*</font>
                                                        <asp:RequiredFieldValidator ID="reqvdProjectName" runat="server" ControlToValidate="txtPrjName"
                                                            Display="None" ErrorMessage="Please enter Project Name."></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr height="15">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FieldNames" align="right">
                                                        Project Type:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <%--<dx:ASPxComboBox ID="drpPrjType" runat="server" ClientIDMode="AutoID" SelectedIndex="0"
                                                            ValueType="System.String">
                                                            <Items>
                                                                <dx:ListEditItem Selected="True" Text="None" />
                                                            </Items>
                                                        </dx:ASPxComboBox>--%>
                                                        <asp:DropDownList ID="drpPrjType" runat="server"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <font class="astrisk">*</font>
                                                        <asp:CustomValidator ID="cstvdProjectType" runat="server" ClientValidationFunction="CheckProjectType"
                                                            ControlToValidate="drpPrjType" Display="None" ErrorMessage="Please select Project Type."></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr height="15">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FieldNames" align="right">
                                                        Project Lead:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtPrjLead" runat="server" Width="170px" MaxLength="1000" ReadOnly="True"></asp:TextBox>&nbsp;
                                                        <asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgLeadAddressBook" runat="server" ImageUrl="..\Images\addressbook.gif"
                                                            CausesValidation="False" ToolTip="Lookup Names"></asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgDeleteLead" runat="server" ImageUrl="../Images/del-name.jpg"
                                                            AlternateText="Delete" CausesValidation="False"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr height="15">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="FieldNames" align="right">
                                                        POC for Data Collection:&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtPOC" runat="server" Width="170px" MaxLength="1000" ReadOnly="True"></asp:TextBox>&nbsp;
                                                        <asp:HiddenField ID="hdnPOC" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgPOCAddressBook" runat="server" ImageUrl="..\Images\addressbook.gif"
                                                            CausesValidation="False" ToolTip="Lookup Names"></asp:ImageButton>&nbsp;
                                                        <asp:ImageButton ID="imgDeletePOC" runat="server" ImageUrl="../Images/del-name.jpg"
                                                            AlternateText="Delete" CausesValidation="False"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                                            ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left">
                                                        <asp:Label ID="lblEdit" runat="server" ForeColor="#3333ff" Font-Bold="True">Edit History</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <hr>
                                                        <dx:ASPxGridView ID="dgdShowHistory" Visible="false" runat="server" Width="100%" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <dx:GridViewDataColumn Width="50%" FieldName="Rev_Editor" Caption="Edited By" VisibleIndex="1" />
                                                                <dx:GridViewDataColumn Width="50%" FieldName="Created_Date" Caption="Edited Date" VisibleIndex="2" />
                                                            </Columns>
                                                            <SettingsPager PageSize="5">
                                                            </SettingsPager>
                                                            <Styles>
                                                                 
                                                                <Header Font-Bold="true" BackColor="#FFCC00">
                                                                </Header>
                                                            </Styles>
                                                        </dx:ASPxGridView>
                                                        <asp:Label ID="lblUser" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
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
            </table>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="imgSubmit" />
        <asp:PostBackTrigger ControlID="imgSubmit_CreateNewProject" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
