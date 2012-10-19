<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEO.aspx.cs" Inherits="MUREOUI.Common.ViewEO" %>
<%@ Register TagPrefix="HeaderControl" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>ViewEOTest</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../StyleSheets/EO.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
		<script>
		    function printStage(stage) {
		        if (parseInt(stage) == 1) {

		            window.open("../Common/ViewEO.aspx?view=" + document.getElementById('hidEOstage').value + "&mode=print&EO_ID=" + document.getElementById('hidEOID').value, "PrintWindow");
		        }
		        return false;
		    }
		</script>
		<form id="Form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="85%">
				<tr id="trHeader" runat="server">
					<td>
						<table width="100%">
							<tr>
								<td width="100%">
									<HeaderControl:HEADER id="Head1" runat="Server"></HeaderControl:HEADER></td>
							</tr>
							<tr>
								<td align="center" width="100%" background="../Images/menu-head-bg.gif">
									<asp:Label ID="lbEODocument" runat="server" Font-Bold="True" Font-Size="18">EODocument</asp:Label></td>
							</tr>
							<tr>
								<td align="center" height="40">
									<asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" Visible="False" ImageUrl="../Images/edit-eo.gif"></asp:ImageButton>&nbsp;<asp:ImageButton ID="btnPrintStage"  runat="server" ImageUrl="../Images/printstage.gif" CausesValidation="False"></asp:ImageButton></td>
							</tr>
							<tr>
								<td height="10">
									&nbsp;<input id="hidEOID" type="hidden" runat="server" NAME="hidEOID"><input id="hidEOstage" type="hidden" name="Hidden1" runat="server"></td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- Start of mandatory table row -->
				<tr id="trPHeader" runat="server">
					<td height="50">
						<asp:Label ID="lblPrintHeader" Font-Bold="True" Font-Size="18px" Font-Italic="True" runat="server"></asp:Label></td>
				</tr>
				<tr id="trMandatory">
					<td>
						<!-- Start of Mandatory Table Common to all tabs-->
						<table id="tblMAndatory" style="BORDER-BOTTOM: #898989 1px solid; BORDER-LEFT: #898989 1px solid; BORDER-TOP: #898989 1px solid; BORDER-RIGHT: #898989 1px solid"
							width="100%">
							<tr>
								<td class="FieldNames">
									Current Stage :</td>
								<td width="15%">
									<asp:Label ID="lblCurStage" runat="server"></asp:Label></td>
								<td class="FieldNames">
									Status :</td>
								<td width="15%">
									<asp:Label ID="lblstatus" runat="server"></asp:Label></td>
								<td class="FieldNames">
									Title :</td>
								<td width="25%">
									<font color="#000000">
										<asp:Label ID="lblTitle" runat="server"></asp:Label></font></td>
							</tr>
							<tr>
								<td class="FieldNames">
									EO # :</td>
								<td width="15%">
									<asp:Label ID="lblEOnum" runat="server"></asp:Label></td>
								<td class="FieldNames" width="15%">
								</td>
								<td width="15%">
								</td>
								<td width="15%">
								</td>
								<td width="25%">
								</td>
							</tr>
							<tr>
								<td class="FieldNames">
									<asp:Label ID="lblSmartClearanceDBText" runat="server" CssClass="FieldNames" Visible="False">SMART Clearance # :</asp:Label></td>
								<td width="15%">
									<asp:Label ID="lblSmartClearanceDB" runat="server" Visible="False"></asp:Label></td>
								<td class="FieldNames" width="15%">
									Selected Brand :</td>
								<td width="15%">
									<asp:Label ID="lblSelBrands" runat="server"></asp:Label></td>
								<td class="FieldNames" width="15%">
									Originator :</td>
								<td width="25%">
									<asp:Label ID="lblOriginator" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td class="FieldNames">
									SAPIO # :</td>
								<td width="15%">
									<asp:Label ID="lblSAPIO" runat="server"></asp:Label></td>
								<td class="FieldNames" width="15%">
									Projects :</td>
								<td width="15%">
									<font color="#000000">
										<asp:Label ID="lblProjects" runat="server"></asp:Label></font></td>
								<td class="FieldNames" width="15%">
									Office # :</td>
								<td width="25%">
									<asp:Label ID="lblOfficeNo" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td class="FieldNames">
									Category :</td>
								<td width="15%">
									<font color="#000000">
										<asp:Label ID="lblCategory" runat="server"></asp:Label></font></td>
								<td class="FieldNames" width="15%">
									Plant :</td>
								<td width="15%">
									<font color="#000000">
										<asp:Label ID="lblPlant" runat="server"></asp:Label></font></td>
								<td class="FieldNames" width="15%">
									Phone # :</td>
								<td width="25%">
									<asp:Label ID="lblPhno" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td class="FieldNames">
									&nbsp;Brands :</td>
								<td width="15%">
									<asp:Label ID="lblBrands" runat="server"></asp:Label></td>
								<td class="FieldNames" width="15%">
									Events :</td>
								<td width="15%">
									<asp:Label ID="lblEvents" runat="server"></asp:Label></td>
								<td class="FieldNames" valign="top" width="15%">
									Co-Originator :</td>
								<td valign="top" width="25%">
									<asp:Label ID="lblCoOrginator" runat="server"></asp:Label></td>
							</tr>
						</table>
						<!-- End of Mandatory Table -->
					</td>
				</tr>
				<!-- End of mandatory table row -->
				<tr>
					<td height="30">
						&nbsp;</td>
				</tr>
				<!-- Start of Navigation Table row-->
				<tr id="trNavigation" runat="server">
					<td>
						<!--Start of Navigation Table -->
						<table id="tblNavigation" cellspacing="0" cellpadding="0" width="100%">
							<tr>
								<td width="9%">
									<asp:ImageButton ID="btnTabPreliminary" OnClick="btnTabPreliminary_Click" runat="server" ImageUrl="../Images/preliminary-nor.gif" CausesValidation="False"
										ImageAlign="Left" AlternateText="Preliminary"></asp:ImageButton></td>
								<td width="9%">
									<asp:ImageButton ID="btnTabFinal" OnClick="btnTabFinal_Click" runat="server" ImageUrl="../Images/final-nor.gif" CausesValidation="False"
										ImageAlign="Left" AlternateText="Final"></asp:ImageButton></td>
								<td width="9%">
									<asp:ImageButton ID="btnTabCloseOut" OnClick="btnTabCloseOut_Click"  runat="server" ImageUrl="../Images/close-out-nor.gif" CausesValidation="False"
										ImageAlign="Left" AlternateText="Close-Out"></asp:ImageButton></td>
								<td>
								</td>
							</tr>
							<tr>
								<td width="100%" colspan="4">
									<table cellspacing="0" width="100%" border="0">
										<tr>
											<td width="20%" background="../Images/menu-head-bg.gif">
												<asp:Label ID="lblStageLevel" runat="server"></asp:Label></td>
											<td width="20%" background="../Images/menu-head-bg.gif">
												<asp:Label ID="lblStatusLevel" runat="server" Visible="False"></asp:Label><asp:Label ID="lblStatusType" runat="server" Visible="true"></asp:Label></td>
											<td width="20%" background="../Images/menu-head-bg.gif">
											</td>
											<td width="40%" background="../Images/menu-head-bg.gif">
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<!--End of Navigation Table -->
					</td>
				</tr>
				<!--End of Navigation Table row-->
				<!--Start of Preliminary Table row-->
				<tr id="trPreliminary" runat="server">
					<td>
						<table cellspacing="5" width="100%">
							<tbody>
								<tr id="TrGeneralPreliminaryRO">
									<td>
										<table id="GeneralPreliminary" width="100%">
											<!-- Preliminary General Navigation Table -->
											<tr>
												<td align="right" width="10%">
													EO&nbsp;Type&nbsp;:
												</td>
												<td align="left" width="35%">
													<asp:Label ID="lblEOType" runat="server"></asp:Label></td>
												<td align="right" width="20%">
													EO Scope/Project Phase :</td>
												<td align="left" width="40%">
													<asp:Label ID="lblEOScopeProjectPhase" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="right">
													Other EO Type :</td>
												<td valign="top">
													<asp:Label ID="lblOtherEOType" runat="server"></asp:Label></td>
												<td align="right">
													Other EO Scope/Project Phase :</td>
												<td valign="top">
													<asp:Label ID="lblEOScopeProjectPhaseOther" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td colspan="4" height="40">
													<table class="AlternateSection1" cellspacing="0" cellpadding="0" width="100%">
														<tr>
															<td align="left" width="20%">
																Brief Description :</td>
															<td width="80%">
																<asp:Label ID="lblBriefDecription" runat="server"></asp:Label></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table class="AlternateSection1" id="Table3" width="100%">
											<tr height="20">
												<td align="left" width="75%">
													50/50 Estimate of Total Papermaking Time Required, Including Set-up and 
													Tear-down :</td>
												<td width="25%">
													<asp:Label ID="lblTotPaperMakingTime" runat="server"></asp:Label></td>
											</tr>
											<tr height="20">
												<td align="left" width="75%">
													<b>50/50 Estimate of Total Converting Time Required, Including Set-up and Tear-down 
														:</b></td>
												<td width="25%">
													<asp:Label ID="lblTotPaperConvertingTime" runat="server"></asp:Label></td>
											</tr>
											<tr height="20">
												<td align="left" width="75%">
													Estimated Total Cost of New Materials Being Ordered Prior to Final EO Approval 
													:</td>
												<td onkeypress="javascript: return AllowNumeric(event);" width="25%">
													<asp:Label ID="lblTotCostOfNewMaterials" runat="server"></asp:Label></td>
											</tr>
											<tr height="20">
												<td align="left" width="75%">
													Estimated Cost of Any EO Specific Equipment Being Ordered Prior to Final EO 
													Approval :</td>
												<td onkeypress="javascript: return AllowNumeric(event);" width="25%">
													<asp:Label ID="lblTotCostOfanyEPSpecific" runat="server"></asp:Label></td>
											</tr>
											<tr height="20">
												<td align="left" width="75%">
													Total Pre-Spending :</td>
												<td width="25%">
													<asp:Label ID="lblTotPreSpending" runat="server"></asp:Label></td>
											</tr>
											<tr height="20">
												<td align="left" width="75%">
													EO Execution Cost :</td>
												<td onkeypress="javascript: return AllowNumeric(event);" width="25%">
													<asp:Label ID="lblEoExecutionCost" runat="server"></asp:Label></td>
											</tr>
											<tr height="20">
												<td align="left" width="75%">
													Total Cost :</td>
												<td width="25%">
													<asp:Label ID="lblTotCost" runat="server"></asp:Label></td>
											</tr>
										</table>
										<table class="AlternateSection1" id="Table4" width="100%">
											<tr>
												<td width="100%" colspan="2">
												</td>
											</tr>
											<tr>
												<td style="WIDTH: 612px" align="right" width="612">
													Suggested Budget Center :
												</td>
												<td width="50%">
													<asp:Label ID="lblSuggestedBudCenter" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td style="WIDTH: 612px" align="right" width="612">
													Selected&nbsp;Budget Center :&nbsp;&nbsp;</td>
												<td width="50%">
													<asp:Label ID="lblSelectedBudgetCenter" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td style="WIDTH: 612px" align="right" width="612">
													Other&nbsp;Suggested Budget Center :&nbsp;&nbsp;</td>
												<td width="50%">
													<asp:Label ID="lblOtherSuggestedBudCenter" runat="server"></asp:Label></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="NewMaterialandBrandsReadOnly" runat="server">
									<%-- Opening of Material Brands - ReadOnly --%>
									<td width="100%" colspan="4">
										<table class="AlternateSection2" id="tblNewMaterialandBrandsReadOnly" width="100%">
											<tr>
												<td class="Header" width="100%" colspan="2">
													New Materials and Brands</td>
											<tr>
												<td align="left" width="75%">
													<p>
														Do new Raw and/or Packing Materials need to be activated for this EO or EO 
														Site?<br>
													</p>
												</td>
												<td width="25%">
													<asp:Label ID="lblNewRawPackMaterials" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													<p>
														Will the EO produce Parent Rolls that need to be tracked and controlled 
														separately from normal production?<br>
													</p>
												</td>
												<td width="25%">
													<asp:Label ID="lblParentRolls" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													Will the EO produce or involve any other Intermediate Materials that are new to 
													this site?</td>
												<td width="25%">
													<asp:Label ID="lblEOProduceOrInvolve" runat="server"></asp:Label></td>
											</tr>
											<tr id="trRM1" runat="server">
												<td align="left" width="75%">
													Is this EO for the production of Regulated Product?</td>
												<td width="25%">
													<asp:Label ID="lblIsRegulatedProduct" runat="server"></asp:Label></td>
											</tr>
											<tr id="trRM2" runat="server">
												<td align="left" width="75%">
													For ALL regulated products, please mark the appropriate GMP Classification</td>
												<td width="25%">
													<asp:Label ID="lblGMPClassification" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													Will any product from the EO be shipped to the trade as a current brand?</td>
												<td width="25%">
													<asp:Label ID="lblCurrentBrand" runat="server"></asp:Label></td>
											</tr>
											<tr id="trNewRowMaterials" runat="server" visible="False">
												<td align="left" width="75%">
													<br>
													If any EO product will be shipped into existing brand codes (blind shipping), 
													you must determine if a P&amp;G Policy 37 exception is needed.&nbsp;&nbsp;Refer 
													to the Family Care Job Aid for more information.&nbsp; If an exception is 
													needed, it must be approved prior to running the EO.
													<br>
													<br>
													Link to Job Aid (on MUR EO Teamspace):
													<br>
													<br>
													http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc
													<br>
												</td>
												<td width="25%">
												</td>
											</tr>
											<tr>
												<td align="left" width="75%">
													<asp:Label ID="lblMaterialsQ1" runat="server">
												I understand Policy 37 requirements for Family Care. 
													&nbsp;A Policy 37 exception is not required for this EO
                                                </asp:Label></td>
												<td width="25%">
													<asp:Label ID="lblMaterials1" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													<asp:Label ID="lblMaterialsQ2" runat="server">
												A Policy 37 exception is required and will be complete 
													before executing this EO.
                                                </asp:Label></td>
												<td width="25%">
													<asp:Label ID="lblMaterials2" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													<asp:Label ID="lblMaterialsQ3" runat="server">
												This EO is already covered by an existing Policy 37 
													exception.
                                                </asp:Label></td>
												<td width="25%">
													<asp:Label ID="lblMaterials3" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													Will any test product/samples be shipped out of the plant for consumer/lab 
													evaluation?</td>
												<td width="25%">
													<asp:Label ID="lblLabEvaluation" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td align="left" width="75%">
													Will you be using any Contingent GCAS #s unique to product and not ordered via 
													UMOF?</td>
												<td width="25%">
													<asp:Label ID="lblUMOF" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="75%" colspan="2">
												</td>
											</tr>
											<tr>
												<td align="center" colspan="2">
													<asp:DataGrid ID="dgdGCASInfoRO" runat="server" HeaderStyle-CssClass="SubHeaderGrid" AutoGenerateColumns="false"
														Width="100%">
														<HeaderStyle CssClass="Header"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="GCAS_Material_Number" HeaderText="GCAS(Materials)"></asp:BoundColumn>
															<asp:BoundColumn DataField="GCAS_Site_Short_Name" ItemStyle-Width="100px" HeaderText="Site"></asp:BoundColumn>
															<asp:BoundColumn DataField="New_to_Site" HeaderText="New to Site"></asp:BoundColumn>
															<asp:BoundColumn DataField="New_to_Category" HeaderText="New to Category"></asp:BoundColumn>
															<asp:BoundColumn DataField="Intermediate" HeaderText="Intermediate"></asp:BoundColumn>
															<asp:BoundColumn DataField="Type" HeaderText="Type"></asp:BoundColumn>
														</Columns>
													</asp:DataGrid></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="HSandSEReadOnly" runat="server">
									<td width="100%" colspan="4">
										<table class="AlternateSection1" id="tblHSandSEReadOnly" width="100%">
											<tr>
												<td class="Header" width="100%" bgcolor="#6699ff" colspan="2">
													HS&amp;E</td>
											</tr>
											<tr>
												<td width="100%" colspan="2">
													A “YES” to any of the following questions for this test request will require 
													HS&amp;E approval on the final stage routing.</td>
											</tr>
											<tr>
												<td width="100%" colspan="2">
													Please consult your Family Care HS&amp;E contact for further information on 
													HS&amp;E reviews.</td>
											</tr>
											<tr>
												<td width="75%">
													Does this project involve a new chemical or a change in the use of an existing 
													chemical?</td>
												<td width="25%">
													<asp:Label ID="lblExistingChemical" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td bordercolorlight="#000000" width="75%">
													Does this project involve a new raw material or a change in the physical 
													properties of an existing raw material?</td>
												<td bordercolorlight="#000000" width="25%">
													<asp:Label ID="lblPhysicalProperties" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="75%">
													Does this project require new equipment/ process/ supporting systems or a 
													change in existing equipment/process/ supporting system?</td>
												<td width="25%">
													<asp:Label ID="lblEqupProcessSupSystem" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td style="HEIGHT: 3px" width="75%">
													Does this project require a new job/task or a change in the way a job/ task is 
													performed?</td>
												<td style="HEIGHT: 3px" width="25%">
													<asp:Label ID="lblNewJobTask" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="75%">
												</td>
												<td width="25%">
												</td>
											</tr>
											<tr>
												<td width="75%">
													If you answered “YES” to one or more of the above questions, click here for 
													Additional Information</td>
												<td width="25%">
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="PSandRAReadOnly" runat="server">
									<td width="100%" colspan="4">
										<table class="AlternateSection2" id="tblPSandRAReadOnly" width="100%">
											<tbody>
												<tr width="100%">
													<td class="Header" bgcolor="#6699ff">
														<asp:Label ID="Label48" runat="server">PS&RA</asp:Label></td>
												</tr>
												<tr>
													<td style="HEIGHT: 14px">
														<asp:Label ID="Label49" runat="server" CssClass="NoteMsg">NOTE: PS&RA Approval Required if any apply. If you are not sure, contact Burney Schwab (634-7879)</asp:Label></td>
												</tr>
												<tr>
													<td>
														<asp:Label ID="lblPSRADB" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td>
														<asp:Label ID="Label50" runat="server" Font-Bold="True" ForeColor="Green"> Additional information if you selected "Other":</asp:Label><asp:Label ID="lblOtherPSRADB" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td>
													</td>
												</tr>
												<tr>
													<td align="center">
														<asp:DataGrid ID="dgdPSRAInfoRO" runat="server" AutoGenerateColumns="False" Width="75%">
															<HeaderStyle CssClass="Header"></HeaderStyle>
															<Columns>
																<asp:BoundColumn DataField="CT_Tracking_Number" HeaderText="Tracking Number"></asp:BoundColumn>
																<asp:BoundColumn DataField="Supplier_Name" HeaderText="Supplier Name"></asp:BoundColumn>
																<asp:BoundColumn DataField="Material_Application" HeaderText="Material Application"></asp:BoundColumn>
																<asp:BoundColumn DataField="Material_Usage_Amount" HeaderText="Material Usage Amount"></asp:BoundColumn>
																<asp:BoundColumn DataField="PSRA_Level" HeaderText="PSRA Level"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="PSRA_Others" HeaderText="PSRA Others"></asp:BoundColumn>
															</Columns>
														</asp:DataGrid></td>
												</tr>
												<tr>
													<td>
														<table class="AlternateSection2" width="100%">
															<tr>
																<td width="75%">
																	<asp:Label ID="lblPSRANQ1" runat="server">Will any product go to Consumers?</asp:Label></td>
																<td width="25%">
																	<asp:Label ID="lblPSRANAns1" runat="server"></asp:Label></td>
															</tr>
															<tr>
																<td width="75%">
																	<asp:Label ID="lblPSRANQ2" runat="server">Are you using an approved FC or ATS?</asp:Label></td>
																<td width="25%">
																	<asp:Label ID="lblPSRANAns2" runat="server"></asp:Label></td>
															</tr>
															<tr>
																<td width="75%">
																	<asp:Label ID="lblPSRANQ3" runat="server">Are all Raw Materials approved at the appropriate level(1-5)?</asp:Label></td>
																<td width="25%">
																	<asp:Label ID="lblPSRANAns3" runat="server"></asp:Label></td>
															</tr>
															<tr>
																<td width="75%">
																	<asp:Label ID="lblPSRANQ4" runat="server">Are all Raw Materials approved for the appropriate region(NA, Mexico)?</asp:Label></td>
																<td width="25%">
																	<asp:Label ID="lblPSRANAns4" runat="server"></asp:Label></td>
															</tr>
															<tr>
																<td width="75%">
																	<asp:Label ID="lblPSRANQ5" runat="server">Are all Raw Materials for the application (tissue, towel)?</asp:Label></td>
																<td width="25%">
																	<asp:Label ID="lblPSRANAns5" runat="server"></asp:Label></td>
															</tr>
															<tr>
																<td width="75%">
																	<asp:Label ID="lblPSRANQ6" runat="server">Are all Raw Materials at the previously approved application rate?</asp:Label></td>
																<td width="25%">
																	<asp:Label ID="lblPSRANAns6" runat="server"></asp:Label></td>
															</tr>
															<tr id="trNewPSRARow" runat="server" visible="False">
																<td width="75%">
																	Link to One Point Lesson (OPL) for PS&amp;RA questions:<br>
																	<br>
																	http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B
																	<br>
																</td>
																<td width="25%">
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</tbody>
										</table>
									</td>
								</tr>
								<tr id="PlanningandBudgetInfoReadOnly" runat="server">
									<td width="100%" colspan="4">
										<table class="AlternateSection1" id="tblPlanningandBudgetInfoReadOnly" width="100%">
											<tr>
												<td class="Header" width="100%" bgcolor="#6699ff" colspan="2">
													Planning and Budget Information</td>
											</tr>
											<tr>
												<td width="60%">
													Requested by EO Originator :</td>
												<td width="40%">
												</td>
											</tr>
											<tr>
												<td width="60%">
													Plant Site(s) :</td>
												<td width="40%">
													<asp:Label ID="lblPlantSiteRO" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="60%">
													Lines(s)/Machine(s) :</td>
												<td width="40%">
													<asp:Label ID="lblLinesMachineRO" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="60%">
													Planned Start Date :</td>
												<td width="40%">
													<asp:Label ID="lblPlannesStDateRO" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="60%">
												</td>
												<td width="40%">
												</td>
											</tr>
										</table>
										<table class="AlternateSection1" id="tblPlanningandBudgetInfoReadonly2" width="100%">
											<tr>
												<td width="60%">
													Please list the Formula Card Number(s) being used/altered for this EO :</td>
												<td width="40%">
													<asp:Label ID="lblFormulaCardNORO" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="60%">
													Please list the IPS (Individual Pack Standard) GCAS Number(s) being used for 
													this EO :</td>
												<td width="40%">
													<asp:Label ID="lblIPSGCASViewEO" runat="server"></asp:Label></td>
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
								<%-- Closing of Production and packaging --%>
								<tr class="AlternateSection2" id="ProductionandPackagingReadOnly" runat="server">
									<td colspan="4">
										<table class="AlternateSection2" id="tblProductionandPackagingReadOnly" width="100%">
											<tr>
												<td class="Header" width="100%" bgcolor="#6699ff" colspan="2">
													Production and Packaging</td>
											</tr>
											<tr>
												<td width="60%">
													Format(s) :</td>
												<td width="40%">
													<asp:Label ID="lblFormats" runat="server"></asp:Label></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="PackagingandDispositionPreliminaryReadOnly" runat="server">
									<td width="100%" colspan="4">
										<table class="AlternateSection1" id="tblPackagingandDispositionPreliminaryReadOnly" width="100%">
											<tr>
												<td class="Header" width="100%" bgcolor="#6699ff" colspan="2">
													Packaging / Disposition Information</td>
											</tr>
											<tr>
												<td style="HEIGHT: 10px" width="50%">
													Will any product be packed?</td>
												<td style="HEIGHT: 10px" width="50%">
													<asp:Label ID="lblProdBePacked" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="50%">
													Current Packaging :<asp:Label ID="lblCurrentPackagingRO" runat="server"></asp:Label>&nbsp;&nbsp;Experimental 
													Packaging :
													<asp:Label ID="lblExperimPackagingRO" runat="server"></asp:Label></td>
												<td width="50%">
													<asp:Label ID="lblPackaging" runat="server"></asp:Label></td>
											<tr>
												<td style="HEIGHT: 14px" width="50%">
													Please select a type from below :&nbsp;Clear Poly:&nbsp;
													<asp:Label ID="lblClearPolyRO" runat="server"></asp:Label>&nbsp;Blank 
													KDF:&nbsp;
													<asp:Label ID="lblBlankKDFRO" runat="server"></asp:Label></td>
												<td style="HEIGHT: 14px" width="50%">
												</td>
											</tr>
											<tr>
												<td style="HEIGHT: 22px" width="50%">
													Product Disposition :</td>
												<td style="HEIGHT: 22px" width="50%">
													<asp:Label ID="lbProductDisposition" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td style="HEIGHT: 10px" width="50%">
													Additional Comments :</td>
												<td style="HEIGHT: 10px" width="50%">
													<asp:Label ID="lbAdditionalCommnets" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td style="HEIGHT: 91px" width="50%">
													Will this EO produce product using a unique pallet pattern OR a sku that will 
													require additional stability testing?</td>
												<td style="HEIGHT: 91px" width="50%">
													<p>
														<asp:Label ID="lblUniquePallet" runat="server"></asp:Label></p>
													<p>
														<asp:Label ID="Label54" runat="server">if yes, which :</asp:Label></p>
													Stack Testing:
													<asp:Label ID="lblStackTesting" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Ship 
													Testing:&nbsp;
													<asp:Label ID="lblShipTesting" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
													<asp:Label ID="lblClearPoly" runat="server"></asp:Label>&nbsp;
													<asp:Label ID="lblBlankKDF" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="50%">
													Material Disposition :</td>
												<td width="50%">
													<asp:Label ID="lblMaterialDisposition" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="50%">
												</td>
												<td width="50%">
													<asp:Label ID="Label55" runat="server">Additional Comments: </asp:Label></td>
											</tr>
											<tr>
												<td width="50%">
												</td>
												<td width="50%">
													<asp:Label ID="lblAdditionalMaterialDisposition" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td style="HEIGHT: 22px" width="50%">
												</td>
												<td style="HEIGHT: 22px" width="50%">
												</td>
											</tr>
											<tr>
												<td width="50%">
													Broke Disposition :</td>
												<td width="50%">
												</td>
											</tr>
											<tr>
												<td style="HEIGHT: 35px" width="50%">
													Will this EO generate greater than normal broke (log and/or loose)?</td>
												<td style="HEIGHT: 35px" width="50%">
													<asp:Label ID="lblEOGraterNormalBroke" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="50%">
													Will any broke be printed broke?</td>
												<td width="50%">
													<p>
														<asp:Label ID="lblPrinyBrokeRO" runat="server"></asp:Label><br>
														If yes to printed broke, will any broke have an increase in the amount of ink 
														coverage on the product?<br>
														<asp:Label ID="lblinkCovBrokeRO" runat="server"></asp:Label></p>
												</td>
											</tr>
											<tr>
												<td width="50%">
												</td>
												<td width="50%">
												</td>
											</tr>
											<tr>
												<td width="50%">
													Please attach any additional items pertaining to this EO here :</td>
												<td width="50%">
													<asp:Label ID="lblAdditonalAttachmentsRO" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdAttachment_ReadOnly" runat="server" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
														Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
														<HeaderStyle CssClass="SubHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton ID="lnkFinalattachmentRO" CommandName="Final_Click" Visible="true" runat="server"
																		CausesValidation="False">
																		<asp:Label Text='<%# Eval("PDI_Attachment_File_Name")%>' runat="server" ID="lblFullfnameRO" Visible="true">
																		</asp:Label>
																	</asp:LinkButton>
																	<asp:Label Text='<%# Eval("PDI_Attach_ID")%>' runat="server" ID="lblFileNameRO" Visible="false">
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid></td>
											</tr>
											<tr>
												<td width="50%">
												</td>
												<td width="50%">
													&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
											</tr>
											<tr>
												<td width="50%">
													Cincinnati Resources, please enter the number of your Lab Notebook (ex. 
													WHS0867) here :<br>
													Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
													634-7600</td>
												<td width="50%">
													<asp:Label ID="lblLabNoteBookRO" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="50%">
												</td>
												<td width="50%">
												</td>
											</tr>
											<tr>
												<td width="50%">
													If you require training in the use of a Lab Notebook, click on the link below 
													to begin the self paced web-based training.<br>
													NOTE: This training should take roughly 1.5 hours to complete.<br>
													<asp:LinkButton ID="Linkbutton25" runat="server">Interactive Lab Notebook Training</asp:LinkButton></td>
												<td width="50%">
												</td>
											</tr>
											<tr>
												<td width="50%">
													<asp:Label ID="Label56" runat="server" CssClass="NoteMsg">Please enter any Comments to the Approvers here :</asp:Label></td>
												<td width="50%">
													<asp:Label ID="lblApproverComments" runat="server"></asp:Label></td>
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
								<tr id="PreliminaryApprovalsReadOnly" runat="server">
									<td width="100%" colspan="4">
										<table class="AlternateSection2" id="tblPreliminaryApprovals" rules="all" width="100%"
											border="1">
											<tbody>
												<tr>
													<td class="Header" colspan="5">
														Approvals</td>
													<td class="Header" width="100%" bgcolor="#6699ff">
													</td>
												</tr>
												<tr>
													<td colspan="5">
														Your approval group is :
														<asp:Label ID="lblPreliminaryAppGrp" runat="server"></asp:Label></td>
													<td width="100%">
													</td>
												</tr>
												<tr>
													<td valign="top" width="5%">
														<asp:Image ID="imgBudgetNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgBudgetYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top" width="50%">
														Budget Owner :</td>
													<td>
														<asp:Label ID="lblBORO" runat="server"></asp:Label><br>
													</td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgGbuHseNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgGbuHseYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														GBU HS&amp;E Resource :&nbsp;<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblGBUHSERO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgSiteHseNo" Visible="False" runat="server" ImageUrl="..\Images\No.jpg"></asp:Image><asp:Image ID="imgSiteHseYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Site HS&amp;E Resource :&nbsp;<br>
														(FYI Only - NO Approval Required)</td>
													<td width="30%">
														<asp:Label ID="lblSiteHSERO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgSiteContactNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgSiteContactYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Site Contact :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblSiteContactRO" runat="server"></asp:Label><br>
														&nbsp;</td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgSitePlanningNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgSitePlanningYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Site Planning :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<br>
														<asp:Label ID="lblSitePlanningRO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
													</td>
													<td valign="top">
														Site QA (Brand Leader) :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblQAPreRO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
													</td>
													<td valign="top">
														Central QA :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblCentralQAPreRO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td style="HEIGHT: 39px" valign="top" width="20">
														<asp:Image ID="imgCentralPlanningNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgCentralPlanningYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td style="HEIGHT: 39px">
														Central Planning :&nbsp;</td>
													<td style="HEIGHT: 39px" valign="top">
														<br>
														<asp:Label ID="lblCenPlanningRO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgSapNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgSapYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														SAP Cost Center Coordinator :&nbsp;</td>
													<td width="50%">
														<br>
														<asp:Label ID="lblSAPRO" runat="server"></asp:Label></td>
												</tr>
												<tr id="trSmartClearanceApproval" runat="server" visible="False">
													<td valign="top">
														<asp:Image ID="imgSmartClearanceNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgSmartClearanceYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														SMART Clearance&nbsp;:&nbsp;</td>
													<td width="50%">
														<asp:Label ID="lblSmartClearance" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgTimingGateNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgTimingGateYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Timing Gate Exception :&nbsp;</td>
													<td style="HEIGHT: 8px" width="30%">
														<br>
														<asp:Label ID="lblTimingGateRO" runat="server"></asp:Label></td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgStandardOfficeNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgStandardOfficeYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Standards Office :&nbsp;</td>
													<td>
														<asp:Label ID="lblStansOffRO" runat="server"></asp:Label><br>
													</td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgAdditionalApprover1No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgAdditionalApprover1Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Additional Approver1 :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblAdditionalApprover1RO" runat="server"></asp:Label><br>
													</td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgAdditionalApprover2No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgAdditionalApprover2Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Additional Approver2 :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblAdditionalApprover2RO" runat="server"></asp:Label><br>
													</td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgAdditionalApprover3No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgAdditionalApprover3Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Additional Approver3 :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblAdditionalApprover3RO" runat="server"></asp:Label><br>
													</td>
												</tr>
												<tr>
													<td valign="top">
														<asp:Image ID="imgAdditionalApprover4No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgAdditionalApprover4Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
													<td valign="top">
														Additional Approver4 :<br>
														(FYI Only - NO Approval Required)</td>
													<td>
														<asp:Label ID="lblAdditionalApprover4RO" runat="server"></asp:Label><br>
													</td>
												</tr>
											</tbody>
										</table>
									</td>
								</tr>
							</tbody>
						</table>
						<!--End of Preliminary Table-->
					</td>
				</tr>
				<!--End of Preliminary Table row-->
				<!--Start of Final Table row-->
				<tr id="trFinal" runat="server">
					<td>
						<!-- Start of Final Table -->
						<table id="tblFinal" width="100%">
							<tr id="FinalBudgetCenterReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" width="100%" border="0">
									</table>
								</td>
							</tr>
							<tr id="FinalPackagingandDispositionReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="tblFinalPackagingandDisposition" width="100%">
										<tr>
											<td class="Header" width="100%" bgcolor="#6699ff" colspan="2">
												Packaging / Disposition Information</td>
										</tr>
										<tr>
											<td width="50%">
												Will any product be packed?</td>
											<td width="50%">
												<asp:Label ID="lblFinalPackagingInfoDB" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
												Current Packaging:&nbsp;
												<asp:Label ID="lblCurPackageFinalRO" runat="server">Label</asp:Label>&nbsp;Experimental 
												Packaging:&nbsp;
												<asp:Label ID="lblExpPackFinalRO" runat="server">Label</asp:Label></td>
											<td width="50%">
												<asp:Label ID="lblProdTypeFinalRo" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
												Please select a type from below:</td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="50%">
												Current Poly:<asp:Label ID="lblCurPolyFinalRO" runat="server">Label</asp:Label>&nbsp;Blank 
												KDF:&nbsp;
												<asp:Label ID="lblBlankKDFFinalRO" runat="server">Label</asp:Label></td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="50%">
												Product Disposition:</td>
											<td width="50%">
												<asp:Label ID="lblProDispositionFinalRO" runat="server"></asp:Label><br>
												Additional Comments:<br>
												<asp:Label ID="lblProDispositionFinalAddCommRO" runat="server"></asp:Label><br>
											</td>
										</tr>
										<tr>
											<td valign="middle" width="50%">
												Will this EO produce product using a unique pallet pattern OR a sku that will 
												require additional stability testing?</td>
											<td valign="bottom" width="50%">
												<p>
													<asp:Label ID="lblPalletFinalRO" runat="server"></asp:Label></p>
												<p>
													&nbsp;If Yes, which type:</p>
												<p>
													<asp:Label ID="lblStockShipTesting" runat="server"></asp:Label></p>
											</td>
										</tr>
										<tr>
											<td width="50%">
											</td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="50%">
												Material Disposition:</td>
											<td width="50%">
												<asp:Label ID="lblMaterialDispositionreadonly" runat="server"></asp:Label><br>
												Additional Comments<br>
												<asp:Label ID="lblMaterialDispositionComments" runat="server" Width="50%"></asp:Label></td>
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
												<asp:Label ID="lblEOGraterThanNormalBroke" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
												Will any broke be printed broke?</td>
											<td valign="bottom" width="50%">
												<p>
													<asp:Label ID="lblPrintBroke" runat="server"></asp:Label></p>
												<p>
													If yes to printed broke, will any broke have an increase in the amount of ink 
													coverage on the product?</p>
												<p>
													<asp:Label ID="lblinkConerage" runat="server"></asp:Label></p>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- Costsheet --%>
							<tr id="FinalCostSheetReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="tblFinalCostSheetReadOnly" width="100%">
										<tr>
											<td class="Header" width="100%" bgcolor="#6699ff" colspan="3">
												Cost Sheet</td>
										</tr>
										<!--
										<TR>
											<TD width="100%" colSpan="3"><asp:linkbutton id="Linkbutton44" runat="server">Click Here to go to the Cost Sheet template </asp:linkbutton></TD>
										</TR>-->
										<tr>
											<td width="100%" colspan="3">
												Selected Budget Center :
												<asp:Label ID="lblPreFinalBudgetCenter" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="100%" colspan="3">
												Cost sheet&nbsp;Attachment :
												<asp:Label ID="lblCostSheetAttachments" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdCostSheetFinal_ReadOnly" runat="server" HeaderStyle-CssClass="SubHeader"
													AutoGenerateColumns="False" Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkCostSheetFinalRO" CommandName="Final_Click" Visible="true" runat="server"
																	CausesValidation="False">
																	<asp:Label Text='<%# Eval("Cost_Sheet_Attachment_File_Name")%>' runat="server" ID="lblFullfnameCostSheetFinalRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Cost_Sheet_Attach_ID")%>' runat="server" ID="lblFileNameCostSheetFinalRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
										<tr>
											<td align="center" width="100%" colspan="3">
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</td>
										</tr>
										<tr>
											<td width="40%">
												Estimated amount from the Preliminary Stage:</td>
											<td width="30%">
												<asp:Label ID="lblEstimateAmount" runat="server"></asp:Label></td>
											<td width="30%">
											</td>
										</tr>
										<tr>
											<td width="40%">
												Is the total cost from the cost sheet attachment different from the Preliminary 
												estimate?</td>
											<td width="30%">
												<p>
													<asp:Label ID="lblTotCostsheet" runat="server"></asp:Label></p>
												<p>
													If 'yes', please enter the cost from the cost sheet attachment:
													<asp:Label ID="lblYesOptionTotCostsheet" runat="server">Label</asp:Label></p>
											</td>
											<td width="30%">
												<asp:Label ID="Label71" runat="server"></asp:Label></td>
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
											<td width="100%" colspan="3">
												Please add your comments here:&nbsp;
												<asp:Label ID="lblCostSheetAddCommentsFinalRO" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td style="HEIGHT: 78px" width="100%" colspan="3">
												<p>
													Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
													634-7600
												</p>
												<p>
													If you require training in the use of a Lab Notebook, click on the link below 
													to begin the self paced web-based training.
												</p>
												<p>
													<asp:Label ID="Label72" runat="server" CssClass="NoteMsg">NOTE: This training should take roughly 1.5 hours to complete.</asp:Label></p>
											</td>
										</tr>
										<tr>
											<td style="HEIGHT: 18px" width="100%" colspan="3">
											</td>
										</tr>
										<tr>
											<td width="100%" colspan="3">
											</td>
										</tr>
									</table>
									<table class="AlternateSection2" id="TableFinalQARO" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="2">
												QA Information</td>
										</tr>
										<tr>
											<td width="50%">
												QA Information Attachment :</td>
											<td>
												<asp:Label ID="lblTableFinalQARO" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdQAFinalTabAttachment_Readonly" runat="server" HeaderStyle-CssClass="SubHeader"
													AutoGenerateColumns="False" Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="Linkbutton4RO" CommandName="Final_Click" Visible="true" runat="server" CausesValidation="False">
																	<asp:Label Text='<%# Eval("QA_Info_Attachment_File_Name")%>' runat="server" ID="lblFullfnameQARO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("QA_Info_Attach_ID")%>' runat="server" ID="lblFileNameQARO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- FinalPackagingandDisposition--%>
							<tr id="FinalFormulaCardInformationReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" id="tblFinalFormulaCardInformationReadOnly" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="4">
												Formula Card Information</td>
										</tr>
										<tr>
											<td width="100%" colspan="4">
											</td>
										</tr>
										<tr>
											<td style="HEIGHT: 35px" width="50%">
												Final EO Formula Card Information Click<asp:LinkButton ID="Linkbutton46" runat="server">Here</asp:LinkButton>for 
												help in marking up your Formula Cards
											</td>
											<td style="HEIGHT: 35px" width="50%" colspan="3">
												<asp:Label ID="lblEOFormulaCardInfoFinalRO" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="100%" colspan="4">
											</td>
										</tr>
										<tr>
											<td width="50%" colspan="3">
												Formula Card Attachment or Exception Document:</td>
											<td width="50%">
												<asp:Label ID="lblEOFormulaCardInfoAttachFinalRO" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdFormulaCard_Readonly" runat="server" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
													Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkFormulaCardRO" CommandName="Final_Click" Visible="true" runat="server" CausesValidation="False">
																	<asp:Label Text='<%# Eval("Formula_Cards_Attachment_File_Name")%>' runat="server" ID="lblFullfnameFormulaCardRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Formula_Cards_Attach_ID")%>' runat="server" ID="lblFileNameFormulaCardRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
										<tr>
											<td width="100%" colspan="4">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- Test Plans --%>
							<tr id="FinalTestPlansReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="TableQARO" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="2">
												Test Plans</td>
										</tr>
										<tr>
											<td width="50%">
												Test Plans Attachment :</td>
											<td>
												<asp:Label ID="lblTestPlanFinalRO" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdTestPlansFinal_Readonly" runat="server" HeaderStyle-CssClass="SubHeader"
													AutoGenerateColumns="False" Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkTestPlansFinalRO" CommandName="Final_Click" Visible="true" runat="server"
																	CausesValidation="False">
																	<asp:Label Text='<%# Eval("Test_Plans_Attachment_File_Name")%>' runat="server" ID="lblFullfnameTestPlansFinalRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Test_Plans_Attach_ID")%>' runat="server" ID="lblFileNameTestPlansFinalRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="LabSamplingPlansReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" id="TableLabRO" width="100%">
										<tr>
											<td class="Header" style="HEIGHT: 21px" width="100%" colspan="2">
												Lab Sampling Plans</td>
										</tr>
										<tr>
											<td width="100%" colspan="2">
												Please select the lab you intend to use for your testing:&nbsp; Central 
												Analytical Lab:&nbsp;<asp:Label ID="lblCentralAnalyticalLab" runat="server"></asp:Label>&nbsp; 
												Site Testing Labs:<asp:Label ID="lblSiteTestingLabs" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
												Lab Sampling Plans :
											</td>
											<td>
												<asp:Label ID="lblLabSamplingAttachementsFinal" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdLabSamp_Readonly" runat="server" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
													Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkLabSampRO" CommandName="Final_Click" Visible="true" runat="server" CausesValidation="False">
																	<asp:Label Text='<%# Eval("Lab_Sampling_Attachment_File_Name")%>' runat="server" ID="lblFullfnameLabSampRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Lab_Sampling_Attach_ID")%>' runat="server" ID="lblFileNameLabSampRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
										<tr>
											<td width="100%" colspan="2">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="FinalProductTestFlowMatrixReadonly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="TableProduct" width="100%">
										<tr>
											<td class="Header" style="HEIGHT: 18px" width="100%" colspan="2">
												Product or Detailed Test Flow Matrix</td>
										</tr>
										<tr>
											<td width="50%">
												Product or Detailed Test Flow Matrix Attachment :</td>
											<td>
												<asp:Label ID="lblTestFlowMatrixFinalRO" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdTestMatrix_Readonly" runat="server" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
													Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkTestMatrixRO" CommandName="Final_Click" Visible="true" runat="server" CausesValidation="False">
																	<asp:Label Text='<%# Eval("Matrix_Attachment_File_Name")%>' runat="server" ID="lblFullfnameTestMatrixRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Matrix_Attach_ID")%>' runat="server" ID="lblFileNameTestMatrixRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- FinalOtherSupportingDoc --%>
							<tr id="FinalOtherSupportingDocReadonly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" id="TableOther" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="3">
												Other Supporting Documentation</td>
										</tr>
										<tr>
											<td width="50%">
												Other Supporting Documentation Attachment :</td>
											<asp:DataGrid ID="dgrdOtherDocFinal_Readonly" runat="server" HeaderStyle-CssClass="SubHeader"
												AutoGenerateColumns="False" Width="380px" CellSpacing="1" CellPadding="1" GridLines="None"
												ShowHeader="False">
												<HeaderStyle CssClass="SubHeader"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn>
														<ItemTemplate>
															<asp:LinkButton ID="lnkOtherDocFinalRO" CommandName="Final_Click" Visible="true" runat="server"
																CausesValidation="False">
																<asp:Label Text='<%# Eval("Other_Docs_Attachment_File_Name")%>' runat="server" ID="lblFullfnameOtherDocFinalRO" Visible="true">
																</asp:Label>
															</asp:LinkButton>
															<asp:Label Text='<%# Eval("Others_Attach_ID")%>' runat="server" ID="lblFileNameOtherDocFinalRO" Visible="false">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</asp:DataGrid>
											<td>
												<asp:Label ID="lblOtheSupDocAttach" runat="server" Visible="False"></asp:Label></td>
										</tr>
										<tr>
											<td width="100%" colspan="3">
											</td>
										</tr>
										<tr>
											<td width="50%">
												<asp:Label ID="Label73" runat="server" CssClass="NoteMsg"> Approvers Comments:</asp:Label></td>
											<td width="50%">
												<asp:Label ID="lblSupDocCommnets" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="100%" colspan="2">
												Previous Comments</td>
										</tr>
										<tr>
											<td width="100%" colspan="2">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- FinalMaterialsBrands --%>
							<tr id="TrFinalMaterialsBrands" runat="server" Visible="False">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="TableFinalMaterialsBrands" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="3">
												New Materials and Brands</td>
										</tr>
										<tr>
											<td width="100%" colspan="3">
											</td>
										</tr>
										<tr>
											<td colspan="3">
												<table width="100%" class="AlternateSection2">
													<tr>
														<td align="left" width="75%">
															<p>
																Do new Raw and/or Packing Materials need to be activated for this EO or EO 
																Site?</p>
														</td>
														<td width="25%">
															<asp:Label ID="lblNewRawPackMaterialsFinal" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td align="left" width="75%">
															<p>
																Will the EO produce Parent Rolls that need to be tracked and controlled 
																separately from normal production?</p>
														</td>
														<td width="25%">
															<asp:Label ID="lblParentRollsFinal" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td align="left" width="75%">
															Will the EO produce or involve any other
															<asp:LinkButton ID="lnkFinalInt" runat="server" CausesValidation="False">Intermediate Materials</asp:LinkButton>&nbsp;that 
															are new to this site?</td>
														<td width="25%">
															<asp:Label ID="lblEOProduceOrInvolveFinal" runat="server"></asp:Label></td>
													</tr>
													<tr id="trProdRegulatedProductRQ1Final" runat="server" visible="False">
														<td align="left" width="75%">
															Is this EO for the production of Regulated Product?</td>
														<td width="25%">
															<asp:Label ID="lblIsRegulatedProductFinal" runat="server"></asp:Label></td>
													</tr>
													<tr id="trProdRegulatedProductRQ2Final" runat="server">
														<td align="left" width="75%">
															For ALL regulated products, please mark the appropriate GMP Classification</td>
														<td width="25%">
															<asp:Label ID="lblGMPClassificationFinal" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td align="left" width="75%">
															Will any product from the EO be shipped to the trade as a current brand?</td>
														<td width="25%">
															<asp:Label ID="lblCurrentBrandFinal" runat="server"></asp:Label></td>
													</tr>
													<tr id="trProdRegulatedProductRAQ1Final" runat="server">
														<td align="left" width="75%">
															<br>
															If any EO product will be shipped into existing brand codes (blind shipping), 
															you must determine if a P&amp;G Policy 37 exception is needed.&nbsp;&nbsp;Refer 
															to the Family Care Job Aid for more information.&nbsp; If an exception is 
															needed, it must be approved prior to running the EO.
															<br>
															<br>
															Link to Job Aid (on MUR EO Teamspace):
															<br>
															<br>
															http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/vwFileDrawerByAuthor/4F4A939AF07B3F5A852576EF0042DE49/$FILE/Job+Aid+for+routing+Policy+37+exceptions.doc
															<br>
														</td>
														<td width="25%">
														</td>
													</tr>
													<tr id="trProdRegulatedProductRAQ2Final" runat="server">
														<td align="left" width="75%">
															<br>
															Please Select one of the following:
															<br>
															<asp:CheckBoxList ID="chkMaterialsBrandsReadOnlyFinal" runat="server" Visible="False" RepeatDirection="Vertical"
																Enabled="False">
																<asp:ListItem Value="I understand Policy 37 requirements for Family Care.  A Policy 37 exception is not required for this EO"></asp:ListItem>
																<asp:ListItem Value="A Policy 37 exception is required and will be complete before executing this EO."></asp:ListItem>
																<asp:ListItem Value="This EO is already covered by an existing Policy 37 exception."></asp:ListItem>
															</asp:CheckBoxList><br>
															<table width="100%">
																<tr>
																	<td align="left" width="5%">
																		<asp:Label ID="lblYesNoMat1Final" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label></td>
																	<td align="left" width="95%">
																		<asp:Label ID="lblMat1Final" runat="server" Font-Bold="True" Font-Size="14px">I understand Policy 37 requirements for Family Care.  A Policy 37 exception is not required for this EO</asp:Label></td>
																</tr>
																<tr>
																	<td align="left" width="5%">
																		<asp:Label ID="lblYesNoMat2Final" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label></td>
																	<td align="left" width="95%">
																		<asp:Label ID="lblMat2Final" runat="server" Font-Bold="True" Font-Size="14px">A Policy 37 exception is required and will be complete before executing this EO.</asp:Label></td>
																</tr>
																<tr>
																	<td align="left" width="5%">
																		<asp:Label ID="lblYesNoMat3Final" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label></td>
																	<td align="left" width="95%">
																		<asp:Label ID="lblMat3Final" runat="server" Font-Bold="True" Font-Size="14px">This EO is already covered by an existing Policy 37 exception.</asp:Label></td>
																</tr>
															</table>
															<br>
														</td>
														<td width="25%">
														</td>
													</tr>
													<tr>
														<td align="left" width="75%">
															Will any test product/samples be shipped out of the plant for consumer/lab 
															evaluation?</td>
														<td width="25%">
															<asp:Label ID="lblLabEvaluationFinal" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td align="left" width="75%">
															Will you be using any Contingent GCAS #s unique to product and not ordered via 
															UMOF?</td>
														<td width="25%">
															<asp:Label ID="lblUMOFFinal" runat="server"></asp:Label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="TrPSRA" runat="server" Visible="False">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" id="TablePSRA" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="3">
												PS &amp; RA</td>
										</tr>
										<tr>
											<td colspan="3">
												<table width="100%" class="AlternateSection1">
													<tr>
													<tr>
														<td width="75%">
															Will any product go to consumers?</td>
														<td width="25%">
															<asp:Label ID="lblReadonlyPSR1Final" runat="server"></asp:Label></td>
													</tr>
													<tr>
														<td width="75%">
															Are you using an approved FC or ATS? ("approved" means current version in CSS)
														</td>
														<td width="25%">
															<asp:Label ID="lblReadonlyPSR2Final" runat="server"></asp:Label></td>
													</tr>
													<tr width="100%">
														<td width="75%">
															Are all Raw Materials approved at the appropriate level (1-5)?</td>
														<td width="25%">
															<asp:Label ID="lblReadonlyPSR3Final" runat="server"></asp:Label></td>
													</tr>
													<tr width="100%">
														<td width="75%">
															Are all Raw Materials approved for the appropriate region (NA, Mexico)?</td>
														<td width="25%">
															<asp:Label ID="lblReadonlyPSR4Final" runat="server"></asp:Label></td>
													</tr>
													<tr width="100%">
														<td width="75%">
															Are all Raw Materials approved for the application (tissue, towel)?</td>
														<td width="25%">
															<asp:Label ID="lblReadonlyPSR5Final" runat="server"></asp:Label></td>
													</tr>
													<tr width="100%">
														<td width="75%">
															Are all Raw Materials approved at the previously approved application rate?</td>
														<td width="25%">
															<asp:Label ID="lblReadonlyPSR6Final" runat="server"></asp:Label></td>
													</tr>
													<tr width="100%">
														<td width="75%">
															<br>
															Link to One Point Lesson (OPL) for PS&amp;RA questions:<br>
															<br>
															http://bdc-intra698.internal.pg.com/GLOBAL/fam/gts/fcwebbase01.nsf/All+By+Date/D60566C64E09D15C852576F1004AEB2B
															<br>
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
							<%-- FinalApprovals --%>
							<tr id="FinalApprovalsReadOnly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="tblFinalApprovalsReadOnly" rules="all" width="100%"
										border="1">
										<tr>
											<td class="Header" width="100%" colspan="4">
												Approvals</td>
										</tr>
										<tr>
											<td width="25%">
												Your approval group is:</td>
											<td colspan="3">
												<asp:Label ID="lblApprovalGrpFinal" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td colspan="4">
											</td>
										</tr>
									</table>
									<table class="AlternateSection2" width="100%" border="1">
										<tr>
											<td style="HEIGHT: 10px" valign="top" width="5%">
												<asp:Image ID="imgFinalPSIniNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalPSIniYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px; HEIGHT: 10px" width="267">
												PS Initiative Manager:</td>
											<td style="HEIGHT: 10px" width="50%">
												<asp:Label ID="lblPSInitiativeAppGrp" runat="server"></asp:Label><br>
											</td>
										</tr>
										<tr>
											<td style="HEIGHT: 3px" valign="top">
												<asp:Image ID="imgFinalProdResNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalProdResYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px; HEIGHT: 3px">
												Products Research:</td>
											<td style="HEIGHT: 3px">
												<asp:Label ID="lblProdResearchAppGrp" runat="server"></asp:Label><br>
												&nbsp;</td>
										</tr>
										<tr>
											<td style="HEIGHT: 37px" valign="top">
												<asp:Image ID="imgFinalBONo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalBOYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px; HEIGHT: 37px">
												Budget Owner:</td>
											<td style="HEIGHT: 37px">
												<asp:Label ID="lblBOFinalAppGrp" runat="server"></asp:Label><br>
												&nbsp;</td>
										</tr>
										<tr>
											<td style="HEIGHT: 37px" valign="top">
												<asp:Image ID="imgFinalGBUHSENo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalGBUHSEYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px; HEIGHT: 37px">
												GBU HS&amp;E Resource<br>
												(FYI Only - NO Approval Required)</td>
											<td style="HEIGHT: 37px" valign="top">
												<asp:Label ID="lblGBUHSEFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalSiteHSENo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalSiteHSEYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Site HS&amp;E Resource:</td>
											<td>
												<asp:Label ID="lblSiteHSEFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalSAPNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalSAPYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												SAP Cost Center Coordinator:</td>
											<td>
												<asp:Label ID="lblSAPCostCenterFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalSmartClearanceNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalSmartClearanceYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Smart Clearance:</td>
											<td>
												<asp:Label ID="lblSmartClearanceFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalSitePlanNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalSitePlanYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Site Planning:</td>
											<td>
												<asp:Label ID="lblSiteplanningFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgSiteConNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgSiteConYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Site Contact:</td>
											<td>
												<asp:Label ID="lblSiteContactFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalSiteFinanceNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalSiteFinanceYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Site Finance:</td>
											<td>
												<asp:Label ID="lblSiteFinanceFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalSiteLeaderNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalSiteLeaderYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Site Leadership</td>
											<td>
												<asp:Label ID="lblSiteLeadeshipFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr id="trFinalPSRAAppView" runat="server" Visible="False">
											<td valign="top">
												<asp:Image ID="imgFinalPSRANo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalPSRAYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td width="50%">
												PS&amp;RA:</td>
											<td>
												<asp:Label ID="lblPSRAFinalAppGrp" runat="server"></asp:Label>&nbsp;</td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalTimingGateNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalTimingGateYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Timing Gate Exception:</td>
											<td>
												<asp:Label ID="lblTimingGateFinalAppGrp" runat="server"></asp:Label>&nbsp;</td>
										</tr>
										<tr>
											<td style="HEIGHT: 7px" valign="top">
												<asp:Image ID="imgFinalQANo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalQAYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px; HEIGHT: 7px">
												Site QA (Brand Leader):</td>
											<td>
												<asp:Label ID="lblQAFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td style="HEIGHT: 7px" valign="top">
											</td>
											<td style="WIDTH: 267px; HEIGHT: 7px">
												Central QA :<br>
												(FYI Only - NO Approval Required)</td>
											<td>
												<asp:Label ID="lblCentralQAFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalStandsNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalStandsYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Standards Office:</td>
											<td>
												<asp:Label ID="lblStandsOfficeFinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalAdditionalApprover1No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalAdditionalApprover1Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Additional Approver1:</td>
											<td>
												<asp:Label ID="lblAdditionalApprover1FinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalAdditionalApprover2No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalAdditionalApprover2Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Additional Approver2:</td>
											<td>
												<asp:Label ID="lblAdditionalApprover2FinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalAdditionalApprover3No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalAdditionalApprover3Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Additional Approver3:</td>
											<td>
												<asp:Label ID="lblAdditionalApprover3FinalAppGrp" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgFinalAdditionalApprover4No" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgFinalAdditionalApprover4Yes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td style="WIDTH: 267px">
												Additional Approver4:</td>
											<td>
												<asp:Label ID="lblAdditionalApprover4FinalAppGrp" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<!-- End of Final Table -->
					</td>
				</tr>
				<!--End of Final Table row-->
				<!--Start of Close Out Table row-->
				<tr id="trCloseOut" runat="server">
					<td>
						<!-- Start of CloseOut Table -->
						<table id="tblCloseOut" width="100%">
							<%-- CloseFirstSection--%>
							<tr id="CloseFirstSectionReadonly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" id="TableCloseoutRO" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="2">
												<asp:Label ID="Label95" runat="server" Visible="False">Label</asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
												<p>
													Cincinnati Resources, please enter the number of your Lab Notebook (ex. 
													WHS0867) here:</p>
												<p>
													Note: If you need a Lab Notebook, please contact Sandy Walters at Starnet 
													634-7600</p>
											</td>
											<td width="50%">
												<asp:Label ID="lblLabNoteBookNumberFinal" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
												Completion Date:</td>
											<td width="50%">
												<asp:Label ID="lblComplateionDate" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- CloseActualCostSheet--%>
							<tr id="CloseActualCostSheetReadonly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="TableCostSheetRO" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="2">
												Actual Cost Sheet</td>
										</tr>
										<tr>
											<td width="50%" colspan="2">
												Selected Budget Center :
												<asp:Label ID="lblPreCOBudgetCenter" runat="server"></asp:Label></td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="50%">
											</td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="50%">
												Attach Final Cost Sheet :</td>
											<td width="50%">
												<asp:Label ID="lblAttchFinalCost" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="50%">
											</td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="50%">
												Please enter the total from the Cost Sheet Attachment :</td>
											<td width="50%">
												<asp:DataGrid ID="dgrdActualCostCloseOut_Readonly" runat="server" HeaderStyle-CssClass="SubHeader"
													AutoGenerateColumns="False" Width="380px" CellSpacing="1" CellPadding="1" GridLines="None"
													ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkActualCostCloseOutRO" CommandName="Final_Click" Visible="true" runat="server"
																	CausesValidation="False">
																	<asp:Label Text='<%# Eval("Actual_Cost_Sheet_Attachment_File_Name")%>' runat="server" ID="lblFullfnameActualCostCloseOutRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Actual_Cost_Sheet_Attach_ID")%>' runat="server" ID="lblFileNameActualCostCloseOutRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid><asp:Label ID="lblTotAttchFinalCost" runat="server" Visible="False"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- CloseInitialLearningReport --%>
							<tr id="CloseInitialLearningReportReadOnly" runat="server">
								<td id="Td2" colspan="4" runat="server">
									<table class="AlternateSection2" id="Table1" width="100%">
										<tr>
											<td class="Header" colspan="2">
												Intial Learining Report</td>
										</tr>
										<tr>
											<td width="50%">
												Intial Learining Report Attachment&nbsp;:&nbsp;</td>
											<td width="50%">
												<asp:Label ID="lblILRAttach" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdILR_Readonly" runat="server" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
													Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkILRRO" CommandName="Final_Click" Visible="true" runat="server" CausesValidation="False">
																	<asp:Label Text='<%# Eval("Initial_Learning_Attachment_File_Name")%>' runat="server" ID="lblsubFileNameILRRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Initial_Learning_Attach_ID")%>' runat="server" ID="lblFileNameILRRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- CloseTestPlansUsed--%>
							<tr id="CloseTestPlansUsedReadonly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="TableTestPlans" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="2">
												Test Plans Used</td>
										</tr>
										<tr>
											<td style="HEIGHT: 19px" width="50%">
												Test Plans Used Attachment :</td>
											<td style="HEIGHT: 19px" width="50%">
												<asp:Label ID="lblTestPlanUsedFinal" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdTestPlansCloseOut_Readonly" runat="server" HeaderStyle-CssClass="SubHeader"
													AutoGenerateColumns="False" Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkTestPlansCloseOutRO" CommandName="Final_Click" Visible="true" runat="server"
																	CausesValidation="False">
																	<asp:Label Text='<%# Eval("Plans_Used_Attachment_File_Name")%>' runat="server" ID="lblFullfnameTestPlansCloseOutRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Plans_Used_Attach_ID")%>' runat="server" ID="lblFileNameTestPlansCloseOutRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
									</table>
								</td>
							</tr>
							<%-- CloseoutReport --%>
							<tr id="CloseoutReportRO" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection1" id="Table2" width="100%">
										<tr>
											<td class="Header" width="100%" colspan="4">
												Close Out Report</td>
										</tr>
										<tr>
											<td style="HEIGHT: 18px" width="50%">
												Test Plans Used Attachment :
											</td>
											<td style="HEIGHT: 18px" colspan="3">
												<asp:Label ID="lblCloseoutReportRO" runat="server" Visible="False"></asp:Label><asp:DataGrid ID="dgrdCOReport_Readonly" runat="server" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
													Width="380px" CellSpacing="1" CellPadding="1" GridLines="None" ShowHeader="False">
													<HeaderStyle CssClass="SubHeader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton ID="lnkCOReportRO" CommandName="Final_Click" Visible="true" runat="server" CausesValidation="False">
																	<asp:Label Text='<%# Eval("Closeout_Report_Attachment_File_Name")%>' runat="server" ID="lblFullfnameCOReportRO" Visible="true">
																	</asp:Label>
																</asp:LinkButton>
																<asp:Label Text='<%# Eval("Closeout_Report_Attach_ID")%>' runat="server" ID="lblFileNameCOReportRO" Visible="false">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></td>
										</tr>
										<tr>
											<td width="100%" colspan="4">
												Please list any keywords from the Close-Out Report</td>
										</tr>
										<tr>
											<td width="33%">
												<asp:Label ID="Label97" runat="server">1)</asp:Label>&nbsp;
												<asp:Label ID="lblCloseKeyword1" runat="server"></asp:Label></td>
											<td width="33%">
												<asp:Label ID="Label98" runat="server">2)</asp:Label>&nbsp;
												<asp:Label ID="lblCloseKeyword2" runat="server"></asp:Label></td>
											<td width="34%" colspan="2">
												<asp:Label ID="Label99" runat="server">3)</asp:Label>&nbsp;
												<asp:Label ID="lblCloseKeyword3" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td width="33%">
												<asp:Label ID="Label100" runat="server">4)</asp:Label>&nbsp;
												<asp:Label ID="lblCloseKeyword4" runat="server"></asp:Label></td>
											<td width="33%">
												<asp:Label ID="Label101" runat="server">5)</asp:Label>&nbsp;
												<asp:Label ID="lblCloseKeyword5" runat="server"></asp:Label></td>
											<td width="34%" colspan="2">
												<asp:Label ID="Label102" runat="server">6)</asp:Label>&nbsp;
												<asp:Label ID="lblCloseKeyword6" runat="server"></asp:Label></td>
										</tr>
									</table>
									<table class="AlternateSection1" id="TableTestPlansSub" width="100%">
										<tr>
											<td width="50%">
											</td>
											<td width="50%">
											</td>
										</tr>
										<tr>
											<td width="100%" colspan="2">
												Please enter any Comments to the Approvers here :</td>
										</tr>
										<tr>
											<td width="100%" colspan="2">
												<asp:Label ID="lblAppCommentsFinal" runat="server" Width="50%"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="CloseApprovalsReadonly" runat="server">
								<td width="100%" colspan="4">
									<table class="AlternateSection2" id="TableApprovalRO" width="100%">
										<tr>
											<td class="Header" style="HEIGHT: 18px" width="100%" colspan="4">
												Approvals</td>
										</tr>
										<!--<TR>
											<TD width="20%">The type of EO this will be :</TD>
											<TD colSpan="3"><asp:label id="lblEOmodeAppCO" runat="server"></asp:label></TD>
										</TR>-->
										<tr>
											<td width="20%">
												Your approval group is :</td>
											<td colspan="3">
												<asp:Label ID="lblAppgrpCO" runat="server"></asp:Label></td>
										</tr>
									</table>
									<table class="AlternateSection2" width="100%" border="1">
										<tr>
											<td valign="top" width="5%">
												<asp:Image ID="imgCloseOutSiteFinanceNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgCloseOutSiteFinanceYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td width="50%">
												Site Finance :&nbsp;
												<asp:Label ID="Label105" runat="server" Visible="False">Label</asp:Label></td>
											<td>
												<asp:Label ID="lblSiteFinanceAppCO" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td valign="top">
												<asp:Image ID="imgCloseOutBudgetOwnerNo" Visible="False" runat="server" ImageUrl="../Images/No.jpg"></asp:Image><asp:Image ID="imgCloseOutBudgetOwnerYes" Visible="False" runat="server" ImageUrl="../Images/Yes.jpg"></asp:Image></td>
											<td>
												Budget Owner :&nbsp;
												<asp:Label ID="Label106" runat="server" Visible="False">Label</asp:Label></td>
											<td width="50%">
												<asp:Label ID="lblBOAppCO" runat="server"></asp:Label></td>
										</tr>
									</table>
									<table>
										<tr>
											<td>
												Originator :</td>
											<td>
												<asp:Label ID="lblCloseOriginatorDB" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<!-- End of CloseOut Table -->
					</td>
				</tr>
				<!-- End of CloseOut Row -->
				<tr id="trRevision" runat="server">
					<%-- Revision --%>
					<td width="100%" colspan="4">
						<table class="AlternateSection1" id="tblRevision" width="100%">
							<tr>
								<td style="HEIGHT: 20px" width="100%">
								</td>
							</tr>
							<tr>
								<td width="100%">
									<asp:Label ID="lblRevisionHistory" runat="server">Revision History</asp:Label></td>
							</tr>
							<tr>
								<td width="100%">
									<asp:DataGrid ID="dgrdRevHistory" runat="server" ShowHeader="False"></asp:DataGrid></td>
							</tr>
							<tr>
								<td width="100%">
									<p>
										<asp:Label ID="lblApprovals" runat="server">Approvals</asp:Label></p>
								</td>
							</tr>
							<tr>
								<td width="100%">
									<asp:DataGrid ID="dgrdAppHistory" runat="server" ShowHeader="False" ShowFooter="True"></asp:DataGrid></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
