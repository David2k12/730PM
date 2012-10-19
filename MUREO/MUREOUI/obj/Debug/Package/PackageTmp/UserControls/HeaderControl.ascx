<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderControl.ascx.cs" Inherits="MUREOUI.UserControls.HeaderControl" %>

<HTML>
	<HEAD>
		<title>Untitled Document</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		    function OpenHelpWindow() {
		        //window.open('../common/Templates/MUREO_UserManual.doc');
		        var popResult;
		        popResult = window.open('../Common/HelpAttachments.aspx', 'null', 'dialogHeight:250px;dialogWidth:500px');
		    }
		    function OpenFAQWindow() {
		        alert('Under Construction');
		    }
		    function GlobalTeamSpaceWindow() {
		        var aw = screen.availWidth;
		        var ah = screen.availHeight;
		        //window.open('http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf','NewWin','locationbar=yes,toolbar=yes,scrollbars=yes,resize=yes, width = ' + aw + ',height = ' + ah + ',top = 0, left = 0')
		        window.open('http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf', 'NewWin', 'locationbar=yes,scrollbars=yes,resizable=yes,width=900,height=500,top=125,left=100')
		    }
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr>
                <td background="../images/bg.gif" colspan="5">
                    <div align="center">
                        <img src="../images/banner.jpg" width="1000" height="102"></div>
                </td>
            </tr>
			<tr>
				<td width="111" background="../images/menu_bg.gif">&nbsp;</td>
				<td width="20" background="../images/menu_bg.gif"><IMG height="23" src="../Images/menu_left_corner_bit.gif" width="20"></td>
				<td class="HomeTabs" width="1001">
					<div align="center"><IMG height="15" src="../images/link_bullet.gif" width="2"> <A style="TEXT-DECORATION: none" href="../Common/Home.aspx">
							<STRONG><font class="HomeTabs">Home</A></FONT></STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<IMG id="imgSysOwner" height="15" src="../images/link_bullet.gif" width="2" runat="server">
						<strong><A style="TEXT-DECORATION: none" href="../Administration/MaintainSystemOwner.aspx">
								<font class="HomeTabs">
									<asp:label id="lblSysOwner" Runat="server">System Owners</asp:label></font></A>
							<A style="TEXT-DECORATION: none" href="../Common/SystemOwners.aspx"><font class="HomeTabs">
									<asp:label id="lblSysOwnerUsers" Runat="server">System Owners</asp:label></font></A>
						</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <IMG height="15" src="../images/link_bullet.gif" width="2">
						<a>
							<asp:linkbutton id="lbGlobal" style="TEXT-DECORATION: none" Runat="server" ForeColor="#003399" CausesValidation="False">
								<strong><font class="HomeTabs">Global Team Space</font></strong></asp:linkbutton></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<IMG height="15" src="../images/link_bullet.gif" width="2">
						<asp:linkbutton id="lbHelp" style="TEXT-DECORATION: none" Runat="server" ForeColor="#003399" CausesValidation="False">
							<STRONG><font class="HomeTabs">Help</font></STRONG>
						</asp:linkbutton>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <IMG height="15" src="../images/link_bullet.gif" width="2"></A>
						<asp:linkbutton id="lbFaq" style="TEXT-DECORATION: none" Runat="server" ForeColor="#003399" CausesValidation="False">
							<STRONG><font class="HomeTabs">FAQ</font></A></STRONG></asp:linkbutton></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<IMG id="imgadmin" height="15" src="../images/link_bullet.gif" width="2" runat="server">
						<A style="TEXT-DECORATION: none" href="../Administration/Home.aspx"><STRONG><font class="HomeTabs">
									<asp:label id="lblAdmin" Runat="server">Administration</asp:label></A></FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<DIV></DIV>
						</STRONG></div>
				</td>
				<td width="20" background="../images/menu_bg.gif"><IMG height="23" src="../images/menu_right_corner_bit.gif" width="20"></td>
				<td width="113" background="../images/menu_bg.gif">&nbsp;</td>
			</tr>
			<tr>
				<td background="../images/menu_bg.gif" colSpan="5" height="3"></td>
			</tr>
		</table>
	</body>
</HTML>

