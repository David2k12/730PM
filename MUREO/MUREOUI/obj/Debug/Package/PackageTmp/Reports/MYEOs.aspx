<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="MYEOs.aspx.cs"
    Inherits="MUREOUI.Reports.MYEOs" %>

<%@ Register TagPrefix="NavigationControl" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register TagPrefix="HeadControl" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="FootControl" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>My Tests Information</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript" type="text/javascript">
        function DeleteEO(intEOID, strCurrentStage) {

            
            var hdntxtprjlead = document.getElementById("<%=hdntxtPrjLead.ClientID %>").id;
            var hdnstage = document.getElementById("<%=hdnstage.ClientID %>").id;
            var btnDel = document.getElementById("<%=btnDel.ClientID %>").id;
            var hdnvar;
            hdnvar = window.open('../Reports/EODelete.aspx?EventID=' + intEOID + '&stage=' + strCurrentStage + '&btnDel=' + btnDel, null, 'height=270, width=590, left=280, top=120');
            //hdnvar = window.open('../Reports/EODelete.aspx?EventID=' + intEOID + '&stage=' + strCurrentStage + '&HdnStat=' + hdntxtprjlead, 'ShowUsers', 'menubar=1,resizable=1,width=800,height=450');            
            //            var hdnvar = document.getElementById("<%=hdntxtPrjLead.ClientID %>").value;
            //ApproverConfirm('" & Viewstfate("EOID") & "','" & ViewState("stage") & "','Budget Center','Y')
            //popResult=window.showModalDialog('PreScreenApproverConfirm.aspx?EOID='+EoId+'&EoStage=PRESCREEN&PSAppID='+PSAppID+'&appStatus='+appStatus,null,'dialogWidth:400px;dialogHeight:230px');
            // popResult = window.showModalDialog('../Reports/EODelete.aspx?EventID=' + intEOID + '&stage=' + strCurrentStage, null, 'dialogWidth:580px;dialogHeight:150px');
            //            if (hdnvar == "E") {
            //                if (strCurrentStage == "Site Test") {
            //                    alert('Site Test and its associated Events are deleted successfully.');
            //                }
            //                else {
            //                    alert('EO and its associated Events are deleted successfully.');
            //                }

            //            }
            //            else if (hdnvar == "D") {
            //                if (strCurrentStage == "Site Test") {
            //                    alert('Site Test Deleted and its associated Events are released successfully.');
            //                }
            //                else {
            //                    alert('EO Deleted and its associated Events are released successfully.');
            //                }
            //            }
            //            else if (hdnvar == "F") {
            //                alert('Record deletion failed.');
            //            }          
            //window.opener.reload();
            //window.opener.history.go(0);
            //window.opener.location.href = window.opener.location.href;
            window.location = "MYEOs.aspx";
        }

        function DeleteMessage(hdnvar, strCurrentStage) {
            if (hdnvar == "E") {
                if (strCurrentStage == "Site Test") {
                    alert('Site Test and its associated Events are deleted successfully.');
                }
                else {
                    alert('EO and its associated Events are deleted successfully.');
                }

            }
            else if (hdnvar == "D") {
                if (strCurrentStage == "Site Test") {
                    alert('Site Test Deleted and its associated Events are released successfully.');
                }
                else {
                    alert('EO Deleted and its associated Events are released successfully.');
                }
            }
            else if (hdnvar == "F") {
                alert('Record deletion failed.');
            }
        }

        function confirmDelete() {
            if (!confirm('Are you sure you want to delete this EO / Site Test?')) {
                return false;
            }
            else {
                return true;
            }
        }
        function confirmStop() {
            if (!confirm('Are you sure you want to stop this EO?')) {
                return false;
            }
            else {
                return true;
            }
        }
        function confirmCancel() {
            if (!confirm('Are you sure you want to cancel this EO?')) {
                return false;
            }
            else {
                return true;
            }
        }

        //Screen Resolution code

        function setScreenRes() {
            document.getElementById("division1").style.height = (screen.height - 450); //"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            //document.getElementById("division2").style.height = (screen.height - 450) ;//"OVERFLOW: auto; WIDTH: 100%; HEIGHT:" + (screen.height - 300) + "px";
            /*	if (screen.width ==1024)
            {
            document.getElementById("division1").style.width  = (screen.width - 424);
            //document.getElementById("division2").style.width  = (screen.width - 649);
            }
            else if (screen.width ==1280)
            {
            document.getElementById("division1").style.width  = (screen.width - 510);
            //document.getElementById("division2").style.width  = (screen.width - 760);
            }
            else if (screen.width ==1600)
            {
            document.getElementById("division1").style.width  = (screen.width - 630);
            //document.getElementById("division2").style.width  = (screen.width - 950);
            }
            else if (screen.width ==1920)
            {
            document.getElementById("division1").style.width  = (screen.width - 750);
            //document.getElementById("division2").style.width  = (screen.width - 1142);
            }*/


        }
    </script>
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--  <asp:UpdatePanel ID="UpdatePanel1"  runat="server">       
        <ContentTemplate>--%>
    <table id="mainTable" height="100%" cellspacing="0" cellpadding="0" width="100%"
        border="0">
        <tr>
            <td style="height: 17px">
                <HeadControl:HeaderControl ID="HeaderControl" runat="server"></HeadControl:HeaderControl>
                <asp:HiddenField ID="hdntxtPrjLead" runat="server" />
                <asp:HiddenField ID="hdnstage" runat="server" />
                <div id="btndicv" style="display: none">
                    <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="DelEo" /></div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table id="innerTable1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top">
                            <table id="innerTable2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr valign="middle" bgcolor="#ffffcc">
                                    <td class="FormHeader" valign="top" colspan="3" height="27">
                                        My&nbsp;EO's/Site Tests&nbsp;
                                    </td>
                                </tr>
                                <tr height="5">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:ImageButton ID="imgCreateEO" runat="server" ImageUrl="../Images/create-eo.gif"
                                            AlternateText="Create a New EO" OnClick="imgCreateEO_Click"></asp:ImageButton>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr height="5">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="left" width="100%" colspan="3">
                                        <div id="division1" style="width: 100%; height: 300px; overflow: auto">
                                            <%--<asp:datagrid id="dgdMyEO" runat="server" OnItemCommand="DisplayBoundColumnValues" BorderWidth="1px"
														BorderColor="Black" DataKeyField="EO_ID" Width="100%" HeaderStyle-CssClass="subHeader" GridLines="None"
														AutoGenerateColumns="False" AllowPaging="True" CellSpacing="2" AllowSorting="True">
														<AlternatingItemStyle Wrap="true" CssClass="Alternaterow2"></AlternatingItemStyle>
														<ItemStyle Wrap="true" CssClass="AlternateRow1"></ItemStyle>
														<HeaderStyle Wrap="true" CssClass="subHeader"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn SortExpression="EO_Number" HeaderText="EO Num">
																<HeaderStyle Wrap="true" Width="8%"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:Label ID="lblEOID" Runat=server Visible=False text='<%#Eval("EO_ID")%>'>
																	</asp:Label>
																	<asp:LinkButton CommandName="EONum_Link" Runat=server ID=hypEONumber text='<%# Eval("EO_Number")%>' >
																	</asp:LinkButton>
																	<asp:Label Runat=server ID="lblEnum" Visible=False text='<%# Eval("EO_Number")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="EO_Title" HeaderText="EO Title">
																<HeaderStyle Wrap="true" Width="25%"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:LinkButton CommandName ="EOTitle_Link" Runat=server ID="hypEOTitle" text='<%# Eval("EO_Title")%>' >
																	</asp:LinkButton>
																	<asp:Label ID="lblEOTitle" Runat=server Visible=False text='<%#Eval("EO_Title")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Check Approvals">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton id="imgCheckApproval" CommandName="CheckApproval" Runat="server" ImageUrl="../Images/actn045.gif"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Open as Read Only">
																<HeaderStyle Wrap="true" Width="8%"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton id="ImgReadOnlyEO" CommandName="ReadOnly" Runat="server" ImageUrl="../Images/actn037.gif"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="Current_Stage" HeaderText="Current Stage">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:Label Runat=server ID="hypEOStage1" text='<%# Eval("Current_Stage")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Stage_Status" SortExpression="Stage_Status" HeaderText="Status">
																<HeaderStyle Wrap="true" Width="8%"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Brand_Segment_Name" SortExpression="Brand_Segment_Name" HeaderText="Brand">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Plant_Name" SortExpression="Plant_Name" HeaderText="Plant">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Stop this EO?">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton id="imgStopEO" Runat="server" ImageUrl="../Images/stop.gif" CommandName="Stop"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Cancel EO?">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton ID="imgCancel" Runat="server" ImageUrl="../Images/Cancel_Status.gif" CommandName="Cancel"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Delete EO?">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton ID="imgDelete" Runat="server" ImageUrl="../Images/delete_icon.gif" CommandName="Delete"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="Modified_Date" HeaderText="Last Modified">
																<HeaderStyle Wrap="true"></HeaderStyle>
																<ItemStyle Wrap="true"></ItemStyle>
																<ItemTemplate>
																	<asp:LinkButton CommandName="ModifiedDate_Link" Runat=server ID=hypModifiedDate text='<%# Eval("Modified_Date")%>'>
																	</asp:LinkButton>
																	<asp:Label Runat=server ID="lblModiLink" Visible=False text='<%# Eval("Modified_Date")%>'>
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle NextPageText="" PrevPageText="" HorizontalAlign="Center"></PagerStyle>
													</asp:datagrid>--%>
                                            <dx:ASPxGridView ID="dgdMyEO" runat="server" Width="100%" HeaderStyle-CssClass="subHeader"
                                                KeyFieldName="EO_ID" GridLines="None" AutoGenerateColumns="False" CssClass="SubHeader"
                                                OnPageIndexChanged="dgdMyEO_PageIndexChanged" OnHtmlRowPrepared="dgdMyEO_HtmlRowPrepared"
                                                CellSpacing="2">
                                                <Columns>
                                                    <dx:GridViewDataColumn Caption="EO Num" VisibleIndex="1" Width="15%">
                                                        <DataItemTemplate>
                                                            <asp:Label ID="lblEOID" runat="server" Visible="False" Text='<%#Eval("EO_ID")%>'>
                                                            </asp:Label>
                                                            <asp:LinkButton Stage_Status='<%# Eval("Stage_Status") %>' CommandName='<%# Eval("EO_ID") %>'
                                                                CommandArgument='<%# Eval("Current_Stage")%>' OnCommand="hypEONumber_Command"
                                                                runat="server" ID="hypEONumber" Text='<%# Eval("EO_Number")%>'>
                                                            </asp:LinkButton>
                                                            <asp:Label runat="server" ID="lblEnum" Visible="False" Text='<%# Eval("EO_Number")%>'>
                                                            </asp:Label>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="EO Title" VisibleIndex="2" Width="15%">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                OnCommand="EOTitle_Link_Command" runat="server" ID="hypEOTitle" Text='<%# Eval("EO_Title")%>'>
                                                            </asp:LinkButton>
                                                            <asp:Label ID="lblEOTitle" runat="server" Visible="False" Text='<%#Eval("EO_Title")%>'>
                                                            </asp:Label>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                        Caption="Check Approvals" VisibleIndex="3" Width="15%">
                                                        <DataItemTemplate>
                                                            <dx:ASPxButton Image-Url="../Images/actn045.gif" ID="imgCheckApproval" OnCommand="imgCheckApproval_Command"
                                                                CommandName='<%# Eval("EO_ID") %>' ToolTip="Check Approvals" CommandArgument='<%# Eval("Current_Stage")%>'
                                                                Style="cursor: pointer" runat="server">
                                                            </dx:ASPxButton>
                                                            <%--    <asp:ImageButton ID="imgCheckApproval" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>' style="cursor:pointer"
                                                                OnCommand="imgCheckApproval_Command" runat="server" ImageUrl="../Images/actn045.gif" ToolTip="Check Approvals">
                                                            </asp:ImageButton>--%>
                                                            &nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                        Caption="Open as Read Only" VisibleIndex="4" Width="15%">
                                                        <DataItemTemplate>
                                                            <dx:ASPxButton ID="ImgReadOnlyEO" Image-Url="../Images/actn037.gif" OnCommand="ImgReadOnlyEO_Command"
                                                                ToolTip="Open as Read Only" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                Style="cursor: pointer" runat="server">
                                                                
                                                            </dx:ASPxButton>
                                                            <%--<asp:ImageButton ID="ImgReadOnlyEO" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>' style="cursor:pointer"
                                                                OnCommand="ImgReadOnlyEO_Command" runat="server" ImageUrl="../Images/actn037.gif" ToolTip="Open as Read Only">
                                                            </asp:ImageButton>--%>&nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="Current Stage" VisibleIndex="5" Width="15%">
                                                        <DataItemTemplate>
                                                            <asp:Label runat="server" ID="hypEOStage1" Text='<%# Eval("Current_Stage")%>'>
                                                            </asp:Label>  &nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn FieldName="Stage_Status" Caption="Status" VisibleIndex="6" />
                                                    <dx:GridViewDataColumn FieldName="Brand_Segment_Name" Caption="Brand" VisibleIndex="7" />
                                                    <dx:GridViewDataColumn FieldName="Plant_Name" Caption="Plant" VisibleIndex="8" />
                                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                        Caption="Stop this EO?" VisibleIndex="9" Width="15%">
                                                        <DataItemTemplate>
                                                            <dx:ASPxButton ID="imgStopEO" Image-Url="../Images/stop.gif" OnCommand="imgStopEO_Command"
                                                                ToolTip="Stop this EO?" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                Style="cursor: pointer" runat="server">
                                                                <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to stop this EO?'); }" />
                                                            </dx:ASPxButton>
                                                            <%--<asp:ImageButton ID="imgStopEO" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>' style="cursor:pointer"
                                                                OnCommand="imgStopEO_Command" runat="server" ImageUrl="../Images/stop.gif" ToolTip="Stop this EO?"></asp:ImageButton>--%>
                                                            &nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                        Caption="Cancel EO?" VisibleIndex="10" Width="15%">
                                                        <DataItemTemplate>
                                                            <dx:ASPxButton ID="imgCancel" Image-Url="../Images/Cancel_Status.gif" OnCommand="imgCancel_Command"
                                                                ToolTip="Cancel EO?" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                Style="cursor: pointer" runat="server">
                                                                <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to cancel this EO?'); }" />
                                                            </dx:ASPxButton>
                                                            <%--  <asp:ImageButton ID="imgCancel" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>' style="cursor:pointer"
                                                                OnCommand="imgCancel_Command" runat="server" ImageUrl="../Images/Cancel_Status.gif" ToolTip="Cancel EO?">
                                                            </asp:ImageButton>--%>
                                                            &nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center"
                                                        Caption="Delete EO?" VisibleIndex="11" Width="15%">
                                                        <DataItemTemplate>
                                                            <dx:ASPxButton ID="imgDelete" OnCommand="imgDelete_Command" Image-Url="../Images/delete_icon.gif"
                                                                ToolTip="Delete EO?" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>'
                                                                Style="cursor: pointer" runat="server">
                                                                  <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('Are you sure you want to delete this EO / Site Test?'); }" />
                                                            </dx:ASPxButton>
                                                            <%--<asp:ImageButton ID="imgDelete" CommandName='<%# Eval("EO_ID") %>' CommandArgument='<%# Eval("Current_Stage")%>' style="cursor:pointer"
                                                                OnCommand="imgDelete_Command" runat="server" ImageUrl="../Images/delete_icon.gif" ToolTip="Delete EO?">
                                                            </asp:ImageButton>--%>
                                                            &nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="Last Modified" VisibleIndex="12" Width="15%">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton OnCommand="hypModifiedDate_Command" CommandName='<%# Eval("EO_ID") %>'
                                                                CommandArgument='<%# Eval("Current_Stage")%>' runat="server" ID="hypModifiedDate"
                                                                Text='<%# Eval("Modified_Date")%>'>
                                                            </asp:LinkButton>
                                                            <asp:Label runat="server" ID="lblModiLink" Visible="False" Text='<%# Eval("Modified_Date")%>'>
                                                            </asp:Label> &nbsp;
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <SettingsPager PageSize="10">
                                                </SettingsPager>
                                                <Styles>
                                                    <Header Font-Bold="true" BackColor="#FFCC00">
                                                    </Header>
                                                </Styles>
                                            </dx:ASPxGridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <FootControl:FooterControl ID="FooterControl" runat="server"></FootControl:FooterControl>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
    </form>
</body>
</html>
