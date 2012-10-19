<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSiteTest.aspx.cs" Inherits="MUREOUI.Common.ViewSiteTest" %>

<%@ Register src="../UserControls/FooterControl.ascx" tagname="FooterControl" tagprefix="uc1" %>
<%@ Register src="../UserControls/HeaderControl.ascx" tagname="HeaderControl" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewSiteTest</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">
        function setScreenRes() {
            document.getElementById("divTest").style.height = (screen.height - 420); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";

        }
        function printStage(stage) {
            if (parseInt(stage) == 1) {
                window.open("../Common/ViewSiteTest.aspx?EoID=" + document.getElementById('txthdnEOID').value + "&mode=Print", "PrintWindow");
            }
            return false;
        }
    </script>
</head>
<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
				<tr id="trheader" runat="server">
					<td>
						<table width="100%">
							<tr>
								<td colSpan="3">
                                    <uc2:HeaderControl ID="HeaderControl1" runat="server" />
                                </td>
							<tr>
								<td align="center" colSpan="3" height="40"><asp:imagebutton id="btnPrintStage" runat="server" CausesValidation="False" ImageUrl="../Images/print-stage.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr valign="top">
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td class="FormHeader" colSpan="4">Site Test</td>
							</tr>
							<tr>
								<td>
									<table border="1" width="100%">
										<tr>
											<td width="20%"><span class="FieldNames">EO #:</span>&nbsp;&nbsp;
												<asp:label id="lblEONum" Runat="server"></asp:label><asp:textbox id="txthdnEOID" Runat="server" width="0" Style="display: none"></asp:textbox></td>
											<td width="35%">
											</td>
											<td width="55%" colSpan="2"><span class="FieldNames">Title: </span>
												<asp:label id="lblTitle" Runat="server" Width="246px"></asp:label></td>
										</tr>
										<tr>
											<td vAlign="top">
												<table>
													<tr>
														<td vAlign="top" colSpan="2"><span class="FieldNames">Category:</span>&nbsp;&nbsp;
															<asp:label id="lblCategory" Runat="server" Width="86px"></asp:label><asp:textbox id="txthdnPlantType" Runat="server" width="0" Style="display: none"></asp:textbox><asp:textbox id="txthdnCategoryId" Runat="server" width="0" Style="display: none"></asp:textbox><asp:textbox id="txthdnEventID" Runat="server" width="0" Style="display: none"></asp:textbox></td>
													</tr>
													<tr>
														<td vAlign="top" width="45%"><span class="FieldNames">Brand:</span></td>
														<td width="55%"><asp:label id="lblBrandsDB" Runat="server"></asp:label></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="15%">
												<table cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td style="width:30%" ><span class="FieldNames">Plant:</span></td>
														<td><asp:label id="lblPlantName" Runat="server"></asp:label><asp:textbox id="txthdnPlantID" Runat="server" width="0" Style="display: none"></asp:textbox></td>
													</tr>
													<tr height="25">
														<td><span class="FieldNames">Project:</span></td>
														<td><asp:label id="lblProject" Runat="server"></asp:label><asp:textbox id="txthdnProjectID" Runat="server" width="0" Style="display: none"></asp:textbox></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Events:</span></td>
														<td><asp:label id="lblEventDB" Runat="server"></asp:label></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="25%">
												<table border="0">
													<tr width="50%">
														<td class="FieldNames" width="45%" align="left">
														Selected Brand:
														<td><asp:label id="lblEOSelectedBrandDB" runat="server"></asp:label><asp:label id="lblBrandIDList" runat="server" Width="0" Visible="False" Style="display: none"></asp:label></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="45%">
												<table cellSpacing="0" cellPadding="0" width="100%">
													<tr height="30">
														<td width="45%"><span class="FieldNames">Originator:</span>
														</td>
														<td width="55%"><asp:label id="lblOriginator" Runat="server" Width="100%"></asp:label></td>
													</tr>
													<tr height="30">
														<td><span class="FieldNames">Office #:</span>
														</td>
														<td><asp:label id="lblOfficeNum" Runat="server" Width="100%"></asp:label></td>
													</tr>
													<tr height="30">
														<td><span class="FieldNames">Phone #:</span>
														</td>
														<td><asp:label id="lblPhoneNum" Runat="server" Width="100%"></asp:label></td>
													</tr>
													<tr height="30">
														<td><span class="FieldNames">Co-Originator:</span>
														</td>
														<td><asp:label id="lblCoOriginator" Runat="server" Width="100%"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br>
									<table cellSpacing="0" cellPadding="0" width="100%" border="1">
										<tr>
											<td width="50%">
												<table width="100%">
													<tr>
														<td vAlign="top" width="50%"><span class="FieldNames">Test Start Date:</span></td>
														<td width="50%"><asp:label id="lblStartDate" Runat="server"></asp:label></td>
													</tr>
													<tr height="30">
														<td vAlign="top" width="50%"><span class="FieldNames">Test Start Time:</span></td>
														<td width="50%"><asp:label id="lblStartTime" Runat="server"></asp:label>&nbsp;&nbsp;
														</td>
													</tr>
												</table>
											</td>
											<td width="50%">
												<table width="100%">
													<tr>
														<td vAlign="top" width="50%"><span class="FieldNames">Test End Date:</span></td>
														<td width="50%"><asp:label id="lblEndDate" Runat="server"></asp:label></td>
													</tr>
													<tr height="30">
														<td vAlign="top" width="50%"><span class="FieldNames">Test End Time:</span></td>
														<td width="50%"><asp:label id="lblEndTime" Runat="server"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br>
									<table cellSpacing="0" cellPadding="0" width="100%" border="1">
										<tr id="tr1">
											<td width="50%">
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Descrption:</span><br>
															<asp:label id="lblDescription" Runat="server" Width="366px" Height="82px"></asp:label><br>
															<br>
															<span class="FieldNames">Objective:</span><br>
															<asp:label id="lblObjective" Runat="server" Width="366px" Height="82px"></asp:label><br>
															<br>
															<span class="FieldNames">Memo:</span><br>
															<asp:label id="lblMemo" Runat="server" Width="366px" Height="82px"></asp:label></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="50%">
												<table width="100%">
													<tr>
														<td colSpan="2"><span class="FieldNames">Affected Line(s)/Machine(s):</span><br>
															<asp:label id="lblAffectedMachines" Runat="server" Width="366px" Height="82px"></asp:label><br>
															<br>
															<span class="FieldNames">Final Report Due:</span><br>
															<asp:label id="lblReportDue" Runat="server" Width="366px" Height="82px"></asp:label></td>
													</tr>
													<!--<tr>
											<td width="50%"><asp:button id="btnTPTemplate" runat="server" Width="190px" Text="Test Plan Template"></asp:button></td>
											<td width="50%"><asp:button id="btnBounty" runat="server" Width="190px" Text="Bounty Test Request"></asp:button></td>
										</tr>
										<tr>
											<td><asp:button id="btnExpTP" runat="server" Width="190px" Text="Example of Test Plan"></asp:button></td>
											<td><asp:button id="btnCTR" runat="server" Width="190px" Text="Charmin Test Request"></asp:button></td>
										</tr>
										<tr>
											<td><asp:button id="btnFRT" runat="server" Width="190px" Text="Final Report Template"></asp:button></td>
											<td><asp:button id="btnPML" runat="server" Width="190px" Text="Paper Making Lab Request"></asp:button></td>
										</tr>
										<tr>
											<td><asp:button id="btnExFR" runat="server" Width="190px" Text="Example of Final Report"></asp:button></td>
											<td><asp:button id="btnUTR" runat="server" Width="190px" Text="Ultra Test Request Form"></asp:button></td>
										</tr>
										<tr>
											<td></td>
											<td><asp:button id="btnNTR" runat="server" Width="190px" Text="Napkin Test Request Form"></asp:button></td>
										</tr>--></table>
											</td>
										</tr>
									</table>
									<br>
									<!-- starting table for Converting -->
									<table id="tblConverting" width="100%" runat="server">
										<tr>
											<td class="SubHeader">Converting</td>
										</tr>
										<tr>
											<td class="SubHeader">Click here to get more detailed list of info to attach with 
												your plan</td>
										</tr>
										<tr>
											<td>
												<table width="100%">
													<tr>
														<td width="50%"><span class="FieldNames">Converting Test Coordinator:</span></td>
														<td width="50%"><asp:label id="lblCoordinator" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Number of Converting Days:</span></td>
														<td><asp:label id="lblDays" Runat="server"></asp:label>Days</td>
													</tr>
													<tr>
														<td><span class="FieldNames">Preferred Run Dates:</span></td>
														<td><asp:label id="lblPreRunDates" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Earliest Run Dates:</span></td>
														<td><asp:label id="lblEarlRunDates" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Latest Run Dates:</span></td>
														<td><asp:label id="lblLRDates" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Consumer Test Production:</span></td>
														<td><asp:label id="lblrdCTPYes" Runat="server"></asp:label></td>
													</tr>
												</table>
												<!--Equipment -->
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Equipment</span></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td width="50%"><span class="FieldNames">Preferred Converting Line:</span>
														</td>
														<td><asp:label id="lblPrefConline" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Alternate Converting Line:</span>
														</td>
														<td><asp:label id="lblAltConvLine" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">E/L setup:</span>
														</td>
														<td><asp:label id="lblElsetup" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">If E/L setup is required,Enter the preferred 
																Emboss Pattern: </span>
														</td>
														<td><asp:label id="lblEquEmbossPattern" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Hot Melt:</span>
														</td>
														<td><asp:label id="lblHotMelt" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Are Extrusion Heads needed?</span></td>
														<td><asp:label id="lblExtrHeads" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">How many Extrusion Heads are needed?</span></td>
														<td><asp:label id="lblExtrusionHeads" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Do the heads need to be heated?</span></td>
														<td><asp:label id="lblrbHeadsHeated" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Is Streams Required?</span></td>
														<td><asp:label id="lblrbIstreamreqd" Runat="server"></asp:label></td>
													</tr>
												</table>
												<!--End Of Equipment-->
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Materials</span></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td width="50%"><span class="FieldNames">Do you need Standard Process Inks for your 
																run?</span></td>
														<td><asp:label id="lblrbInk" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">If Standard Inks are required, how many gallons are 
																needed:</span></td>
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td><span class="FieldNames">Yellow:</span></td>
														<td><asp:label id="lblYellow" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Magneta:</span></td>
														<td><asp:label id="lblMagneta" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Cyan:</span></td>
														<td><asp:label id="lblCyan" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Black:</span></td>
														<td><asp:label id="lblBlack" Runat="server"></asp:label></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Other</span></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td colSpan="2"><span class="FieldNames">Unique Requests</span>
														</td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Equipment:</span></td>
														<td><asp:label id="lblOtheEquipment" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Materials:</span></td>
														<td><asp:label id="lblOtherMat" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Other:</span></td>
														<td><asp:label id="lblOther" Runat="server"></asp:label></td>
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
											<td class="SubHeader">Pilot Paper Machine</td>
										</tr>
										<tr>
											<td class="SubHeader">Click here to get the PPM initial Setup sheet for printing 
												out</td>
										</tr>
										<tr>
											<td>
												<table width="100%">
													<tr>
														<td width="50%"><span class="FieldNames">Have you run or investigated the PPM Models?</span></td>
														<td width="50%"><asp:label id="lblrbPPMMOdel" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">PPM Test Coordinator:</span></td>
														<td width="50%"><asp:label id="lblPPMCoordiator" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Number of PM Days:</span></td>
														<td><asp:label id="lblPMDays" Runat="server"></asp:label>Days</td>
													</tr>
													<tr>
														<td><span class="FieldNames">Preferred Run Dates:</span></td>
														<td><asp:label id="lblPPMPRDate" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Earliest Run Dates:</span></td>
														<td><asp:label id="lblPPMERDate" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Latest Run Dates:</span></td>
														<td><asp:label id="lblPPMLRDates" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Consumer Test Production:</span></td>
														<td><asp:label id="lblrbPPMCTP" Runat="server"></asp:label></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Equipment</span></td>
													</tr>
												</table>
												<br>
												<table width="100%">
													<tr>
														<td width="50%"><span class="FieldNames">Drying Format:</span></td>
														<td width="50%"><asp:label id="lblDrying" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">PM Format:</span></td>
														<td width="50%"><asp:label id="lblFormat" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Headbox Type:</span></td>
														<td width="50%"><asp:label id="lblHeadbox" Runat="server"></asp:label></td>
													</tr>
												</table>
												<br>
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Materials</span></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td width="50%"><span class="FieldNames">Is Karlinal required?</span></td>
														<td width="50%"><asp:label id="lblrbKarli" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">If Yes, how many gallon buckets are needed?</span></td>
														<td><asp:label id="lblGallons" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">New CPN belts:</span></td>
														<td><asp:label id="lblrdCPN" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">No of patterns per new belt:</span></td>
														<td><asp:label id="lblPatterns" Runat="server"></asp:label></td>
													</tr>
												</table>
												<br>
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Other</span></td>
													</tr>
												</table>
												<table width="100%">
													<tr>
														<td colSpan="2"><span class="FieldNames">Unique Requests</span></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Equipment:</span></td>
														<td><asp:label id="lblEquip" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Materials (Chemicals or Pulp):</span></td>
														<td><asp:label id="lblMaterials" Runat="server"></asp:label></td>
													</tr>
													<tr>
														<td width="50%"><span class="FieldNames">Other:</span></td>
														<td><asp:label id="lblOtherPPM" Runat="server"></asp:label></td>
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
											<td class="SubHeader">Test Plans</td>
										</tr>
										<tr>
											<td>
												<asp:datagrid id="dgrdTestPlan" Runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False"
													BorderColor="black" HeaderStyle-CssClass="SubHeader" CellSpacing=2 CellPadding=2 ShowHeader=False>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkTestPlan" CommandName="Final_Click" Visible="true" Runat="server" CausesValidation="False">
																	<asp:Label text='<%#Eval("Test_Plan_Attachment_File_Name")%>' Runat ="server" ID="lblTestSubFileName" Visible=true >
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label text='<%#Eval("Test_Plan_Attach_ID")%>' Runat ="server" ID="lblattachID" Visible=false >
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid>
											</td>
										</tr>
									</table>
									<table width="100%">
										<tr>
											<td class="SubHeader">Other Supporting Documentation</td>
										</tr>
										<tr>
											<td>
												<asp:datagrid id="dgrdSupAttach" Runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False"
													BorderColor="black" HeaderStyle-CssClass="SubHeader"   CellSpacing=2 CellPadding=2 ShowHeader=False>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkSupAttach" CommandName="Final_Click" Visible="true" Runat="server" CausesValidation="False">
																	<asp:Label text='<%#Eval("Other_Supporting_Doc_Attachment_File_Name")%>' Runat ="server" ID="lblSupFileName" Visible=true>
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label text='<%#Eval("Other_Supporting_Doc_Attach_ID")%>' Runat ="server" ID="lblSupFullfName" Visible=false>
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid>
											</td>
										</tr>
									</table>
									<table width="100%">
										<tr>
											<td class="SubHeader">Final Report</td>
										</tr>
										<tr>
											<td>
												<asp:datagrid id="dgrdAttachment" Runat="server" Width="100%" GridLines="None" AutoGenerateColumns="False"
													BorderColor="black"   CellSpacing=2 CellPadding=2 ShowHeader=False>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkFinalattachment" CommandName="Final_Click" Visible="true" Runat="server"
																	CausesValidation="False">
																	<asp:Label text='<%#Eval("Final_Report_Attachment_File_Name")%>' Runat ="server" ID="lblFileName" Visible=true >
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label text='<%#Eval("Final_Report_Attach_ID")%>' Runat ="server" ID="lblFullfname" Visible=false >
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid>
											</td>
										</tr>
									</table>
									<table width="100%">
										<tr>
											<td class="SubHeader">Additional Information</td>
										</tr>
										<tr>
											<td><asp:label id="lblAddInfo" Runat="server"></asp:label></td>
										</tr>
									</table>
									<br>
									<table cellSpacing="0" cellPadding="0" width="100%" border="1">
										<tr>
											<td width="75%"><span class="FieldNames">Does this project involve a new chemical or a 
													change in the use of an existing chemical?</span></td>
											<td width="25%"><asp:label id="lblrbChange" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td><span class="FieldNames">Does this project involve a new raw material or a change 
													in the physical properties of an existing raw material?</span></td>
											<td><asp:label id="lblrbRM" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td><span class="FieldNames">Does this project require new equipment/process/supporting 
													systems or a change in existing equipment/process/supporting systems?</span></td>
											<td><asp:label id="lblrbEqp" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td><span class="FieldNames">Does this project require a new job/task or a change in 
													the way a job/task is performed?</span></td>
											<td><asp:label id="lblrbJob" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td><span class="FieldNames">Are there sample storage concerns?</span></td>
											<td><asp:label id="lblrbStg" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td style="HEIGHT: 19px"><span class="FieldNames">Is a chemical approval needed?</span></td>
											<td style="HEIGHT: 19px"><asp:label id="lblrbAppr" Runat="server"></asp:label></td>
										</tr>
										<tr id="trApproval" runat="server">
											<td colSpan="2">
												<table width="100%">
													<tr>
														<td><span class="FieldNames">Please complete the following...</span>
														</td>
													</tr>
													<tr>
														<td><span class="FieldNames">What precautions are necessary for use?</span><br>
															<asp:label id="lblPrecautions" Runat="server" Width="560px"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">What precautions are necessary for Sampling?</span><br>
															<asp:label id="lblSampling" Runat="server" Width="560px"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">What precautions are necessary for Storage?</span><br>
															<asp:label id="lblStorage" Runat="server" Width="560px"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">What precautions are necessary for Equipment?</span><br>
															<asp:label id="lblEquipment" Runat="server" Width="560px"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">Whar is disposal procedure for Unused Chemical?</span><br>
															<asp:label id="lblDispose" Runat="server" Width="560px"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">What is the appropriate spill response?</span><br>
															<asp:label id="lblSpill" Runat="server" Width="560px"></asp:label></td>
													</tr>
													<tr>
														<td><span class="FieldNames">What are the potential environmental impacts?</span><br>
															<asp:label id="lblEnvImpacts" Runat="server" Width="560px"></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td><span class="FieldNames">Note: For chemical disposal plans, contact MEG. Remember 
													to make necessary arrangements to return/dispose of all unused chemical.</span>
											</td>
										</tr>
										<tr>
											<td id="tdLstConAppr" runat="server"><span class="FieldNames">List Of Concurrence 
													Approvers</span></td>
										</tr>
										<tr>
											<td><asp:datagrid id="dlstConcGrp" Runat="server" Width="100%" BorderWidth="1px" HeaderStyle-CssClass="SubHeader"
													BorderColor="black" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2">
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:Label text='<%#Eval("Created_Date")%>' Runat ="server" ID="lblDay">
																</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:Label text='<%#Eval("Concurrence_Group_Name")%>' Runat ="server" ID="lblConGrpName">
																</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Approver Name">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemTemplate>
																<asp:Label text='<%#Eval("Approver_Name")%>' Runat ="server" ID="lblapprName">
																</asp:Label>
																</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:Label text='<%#Eval("Is_Responded")%>' Runat ="server" ID="lnkapprName" Visible=true >
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Backup Approver">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemTemplate>
																<asp:Label text='<%#Eval("Backup_Approver_Name")%>' Runat ="server" ID="lblBackUpApprover" Visible=True >
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td><asp:datagrid id="dgrdRevHis" Runat="server" width="100%" BorderWidth="1px" HeaderStyle-CssClass="SubHeader"
													BorderColor="black" AutoGenerateColumns="True" GridLines="None"></asp:datagrid></td>
										</tr>
										<tr>
											<td><asp:datagrid id="dgrdFYI" Runat="server" width="100%" BorderWidth="1px" HeaderStyle-CssClass="SubHeader"
													BorderColor="black" AutoGenerateColumns="True" GridLines="None"></asp:datagrid></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trFooter" runat="server">
					<td colSpan="3">
                        <uc1:FooterControl ID="FooterControl1" runat="server" />
                    </td>
				</tr>
			</table>
		</form>
	</body>
</html>
