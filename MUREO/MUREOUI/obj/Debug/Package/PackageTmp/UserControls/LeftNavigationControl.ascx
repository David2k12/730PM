<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftNavigationControl.ascx.cs" Inherits="MUREOUI.UserControls.LeftNavigationControl" %>
<HTML>
	<HEAD>
		<title>Untitled Document</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../StyleSheets/Mureo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<table cellSpacing="0" cellPadding="3" width="100%" border="0">
			<tr>
				<td vAlign="top" bgColor="#f5f5f5"><br>
					<table id="LNcontrol" cellSpacing="0" cellPadding="5" width="100%" align="center" border="0">
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid" width="82%" id="tdNewProject" runat="server"><A style="TEXT-DECORATION: none" href="../Common/frmNewProject.aspx"><font class="LeftNavigationText">New 
									Project</A></FONT></td>
						</tr>
						<tr>
							<td class="LeftNavigationText" style="BORDER-BOTTOM: #0000cc 1px solid" id="tdNewEvent"
								runat="server"><A style="TEXT-DECORATION: none" href="../Common/frmNewEvent.aspx"><font class="LeftNavigationText">New 
										Event</font></A></td>
						</tr>
						<tr>
							<td class="LeftNavigationText" style="BORDER-BOTTOM: #0000cc 1px solid" id="tdNewEO"
								runat="server"><A style="TEXT-DECORATION: none" href="../Common/NewEO.aspx"><font class="LeftNavigationText">New 
										EO</font></A></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/ProjectsByCategory.aspx?Form=ProjectsByCategory">Project 
									List</font></A></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Common/SearchProjEvents.aspx">Search 
										Projects/Events</A></font></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/ApprovedPreliminaryEOs.aspx">Approved 
										Preliminary EO</A></font></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/ApprovedEOs.aspx">Approved 
										EO's</A></font></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/ArchivedEOs.aspx">Archived 
										EO's/SiteTests</A></font></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/CancelledEOs.aspx">Cancelled 
										EO's </A></font>
							</td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid" id="tdEoSitetest" runat="server"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/MYEOs.aspx">My 
										EO's/Site Tests</A></font></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid" id="tdMyApproval" runat="server"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/MyApprovals.aspx">My 
										Approvals/Concurrences</A> </font>
							</td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid" id="tdMySiteCloseOut" runat="server"><font class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/MyEOsAwaiting.aspx">My 
										SiteTests Awaiting Close Out</A></font></td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><font class="LeftNavigationText"> <A style="TEXT-DECORATION: none" href="../Reports/ConcurrenceStatus.aspx">
										Check Concurrence Status</A> </font>
							</td>
						</tr>
						<tr>
							<td style="BORDER-BOTTOM: #0000cc 1px solid"><FONT class="LeftNavigationText"><A style="TEXT-DECORATION: none" href="../Reports/AllEOs.aspx">
									All EO's/Site Tests</FONT></A></td>
						</tr>
						<tr>
							<td id="tdTemporary1" runat="server">&nbsp;</td>
						</tr>
						<tr>
							<td id="tdTemporary2" runat="server">&nbsp;</td>
						</tr>
						<tr>
							<td id="tdTemporary3" runat="server">&nbsp;</td>
						</tr>
						<tr>
							<td id="tdTemporary4" runat="server">&nbsp;</td>
						</tr>
						<tr>
							<td id="tdTemporary5" runat="server">&nbsp;</td>
						</tr>
						<tr>
							<td id="tdTemporary6" runat="server">&nbsp;</td>
						</tr>
					</table>
					<P>&nbsp;</P>
				</td>
			</tr>
		</table>
	</body>
</HTML>