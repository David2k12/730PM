<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBrandSegment.aspx.cs" Inherits="MUREOUI.Administration.ViewBrandSegment" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigation" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../UserControls/FooterControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewBrandSegment</title>
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table id="maintbl" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td>
						<table width="100%" cellpadding="0" cellspacing="0" border="1">
							<tr>
								<td width="20%"><uc1:leftnavigation id="LeftNavigation1" runat="server"></uc1:leftnavigation></td>
								<td valign="top">
									<table id="tbl2" width="100%">
										<tr valign="middle" bgColor="#ffffcc">
											<td class="FormHeader" align="center">Edit Brand Segment
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="center" colspan="2">
                                            <%--<asp:TextBox id="txthdnCategoryID" Runat="server" Width="0"></asp:TextBox>--%>
                                            <asp:HiddenField ID="hdnCategoryID" runat="server" />
                                            <%--<asp:TextBox id="txthdnBrandName" Runat="server" Width="0"></asp:TextBox>--%>
                                            <asp:HiddenField ID="hdnBrandName" runat="server" />
												<asp:ImageButton id="imgSubmit" Runat="server" ImageUrl="../Images/edit.gif" 
                                                    onclick="imgSubmit_Click"></asp:ImageButton>&nbsp;
												<asp:ImageButton id="imgCancel" Runat="server" ImageUrl="../images/cancel.gif" 
                                                    CausesValidation="False" onclick="imgCancel_Click"></asp:ImageButton>&nbsp;
											</td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td valign="top">
												<table id="tbl3" height="3" width="100%" align="left" border="0">
													<tr>
														<td class="FieldNames" valign="top" align="right" width="50%">Category:&nbsp;&nbsp;</td>
														<td valign="top"><asp:label id="lblCategory" Runat="server" Width="200"></asp:label></td>
													</tr>
													<tr>
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class="FieldNames" valign="top" align="right">Brand Segment:&nbsp;&nbsp;
														</td>
														<td valign="top"><asp:Label id="lblBrandSegment" Runat="server" width="200"></asp:Label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><uc1:footer id="adminHomeFooter" runat="server"></uc1:footer></td>
				</tr>
			</table>
		</form>
</body>
</html>
