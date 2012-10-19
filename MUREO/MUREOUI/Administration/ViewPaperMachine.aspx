<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPaperMachine.aspx.cs"
    Inherits="MUREOUI.Administration.ViewPaperMachine" %>

<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>ViewPaperMachine</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    <script language="javascript">   

        function confirmMachineDelete(MachineName) {


            var msg = 'Are you sure you want to delete this Paper Machine  ' + '\'' + MachineName + '\' ?'


            if (confirm(msg))
                document.getElementById("<%=hdnresponse.ClientID %>").value = "Y"
            else {
                document.getElementById("<%=hdnresponse.ClientID %>").value = "N"
                return false;
            }

            /*var retVal = callMsgBoxYesNo(msg)	
            alert(retVal)
            if (retVal == 6)
            document.getElementById("Response").value= "Y"
            else
            document.getElementById("Response").value= "N" */

            //var answer = window.alert("Do you want to eat sardine salad?", 2, 2);    
            //alert(answer);

            //var retVal = callMsgBox2("jagan");

        }
			
    </script>
    <script language="vbscript">
			function callMsgBoxYesNo(strMsg)
				'second parameter is msgBox type
				callMsgBoxYesNo = MsgBox(strMsg,4)
			End Function
    </script>
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
        .viscol
        {
            display: block;
        }
       .popupControl
        {
            position: absolute;
            top: 300px;
            left: 500px;
            width: 100%;
            height: 100%;
            opacity: 0.9;
            z-index: 499;
        }
    </style>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" height="100%">
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl" runat="server"></uc1:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="1" height="100%">
                            <tr>
                                <td valign="top" width="20%">
                                    <uc1:LeftNavigationControl ID="LeftNavigationControl" runat="server"></uc1:LeftNavigationControl>
                                </td>
                                <td valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" height="100%">
                                        <tr valign="middle" bgcolor="#ffffcc">
                                            <td valign="top" class="FormHeader">
                                                Maintain Paper Machines
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgAddPaperMachine" OnClick="imgAddPaperMachine_Click" runat="server"
                                                    ImageUrl="../Images/create-paper-machine.gif"></asp:ImageButton>&nbsp;&nbsp;
                                                <asp:ImageButton ID="imgExpnadAll" OnClick="imgExpnadAll_Click" runat="server" ImageUrl="../Images/expandall.gif">
                                                </asp:ImageButton>
                                                <asp:ImageButton ID="imgCollapseAll" OnClick="imgCollapseAll_Click" runat="server"
                                                    ImageUrl="../Images/collpaseall.gif"></asp:ImageButton>
                                            </td>
                                        </tr>                                       
                                        <tr>
                                            <td valign="top" align="left" width="100%">
                                                <div  style="overflow: auto; width: 100%; height: 300px">
                                                    <table width="100%" align="center">
                                                        <tr>
                                                            <td valign="top" width="100%">
                                                                <%--<asp:datagrid id="drgdMachinesByPlant" runat="server" BorderWidth="1px" GridLines="None" Width="100%"
																	HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False" BorderColor="black" CellSpacing="2">
																	<AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
																	<ItemStyle CssClass="AlternateRow1"></ItemStyle>
																	<HeaderStyle CssClass="SubHeader"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Plant">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle Wrap="False" Width="20%"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton Runat="server" ID="imgPlant1" CommandName="Plant1" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
																				<asp:ImageButton Runat="server" ID="imgPlant2" CommandName="Plant2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
																				<asp:Label ID="lblPlantName" Runat="server" text='<%# Eval("Plant_Name")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Machine">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemTemplate>
																				<asp:Label ID="lblPlantID" Runat="server" text='<%# Eval("Plant_ID")%>'>
																				</asp:Label>
																				<asp:Label ID="lblMachineID" Runat="server" text='<%# Eval("Machine_ID")%>'>
																				</asp:Label>
																				<asp:LinkButton ID="lnkMachineName" CommandName="MachineName_Link" Runat="server">
																					<%# Eval("Machine_Name")%>
																				</asp:LinkButton>
																				<asp:Label ID="lblMachineName" Visible=False Runat="server" text='<%# Eval("Machine_Name")%>'>
																				</asp:Label>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="Delete Machine">
																			<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																			<ItemStyle Wrap="False"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton Runat="server" ID="ImgRemoveMachine" CommandName="RemoveMachine" CommandArgument = '<%# Eval("Machine_ID")%>' ImageUrl="../Images/remove-icon.gif">
																				</asp:ImageButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid>--%>
                                                                <dx:ASPxGridView ID="drgdMachinesByPlant" KeyFieldName="Index" Width="100%" runat="server"
                                                                    AutoGenerateColumns="False" OnHtmlRowPrepared="drgdMachinesByPlant_HtmlRowPrepared"
                                                                    OnPageIndexChanged="drgdMachinesByPlant_PageIndexChanged">
                                                                    <Columns>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Plant"
                                                                            VisibleIndex="1">
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgPlant1" OnCommand="imgPlant1_Command" CommandName="Plant1"
                                                                                    ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="imgPlant2" OnCommand="imgPlant2_Command" CommandName="Plant2"
                                                                                    ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                <asp:Label ID="lblPlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                </asp:Label>&nbsp;
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Machine"
                                                                            VisibleIndex="2">
                                                                            <DataItemTemplate>
                                                                                <asp:Label ID="lblPlantID" Visible="false" runat="server" Text='<%# Eval("Plant_ID")%>'>
                                                                                </asp:Label>
                                                                                <asp:Label ID="lblMachineID" Visible="false" runat="server" Text='<%# Eval("Machine_ID")%>'>
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkMachineName" CommandName='<%# Eval("Plant_ID")%>' CommandArgument='<%# Eval("Machine_ID")%>'
                                                                                    OnCommand="lnkMachineName_Command" Text='<%# Eval("Machine_Name")%>' runat="server">
																					<%# Eval("Machine_Name")%>
                                                                                </asp:LinkButton>
                                                                                <asp:Label ID="lblMachineName" Visible="False" runat="server" Text='<%# Eval("Machine_Name")%>'>
                                                                                </asp:Label>&nbsp;
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                        <dx:GridViewDataColumn CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                            EditCellStyle-HorizontalAlign="Justify" Width="20%" Caption="Delete Machine"
                                                                            VisibleIndex="3">
                                                                            <DataItemTemplate>
                                                                                <asp:ImageButton runat="server" ToolTip="Delete Machine" Style="cursor: pointer"
                                                                                    ID="ImgRemoveMachine" OnCommand="ImgRemoveMachine_Command" CommandArgument='<%# Eval("Machine_ID")%>'
                                                                                    ImageUrl="../Images/remove-icon.gif"></asp:ImageButton>&nbsp;
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataColumn>
                                                                    </Columns>
                                                                    <SettingsPager Mode="ShowAllRecords">
                                                                    </SettingsPager>
                                                                    <Settings GridLines="None" />
                                                                    <Styles>
                                                                        <Header Font-Bold="true" BackColor="#FFCC00">
                                                                        </Header>
                                                                    </Styles>
                                                                </dx:ASPxGridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:FooterControl ID="FooterControl" runat="server"></uc1:FooterControl>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnresponse" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uprg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
           <div class="popupControl">
                <asp:Image ID="Image1" Height="150px" Width="150px" runat="server" ImageUrl="~/Images/loading28.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
