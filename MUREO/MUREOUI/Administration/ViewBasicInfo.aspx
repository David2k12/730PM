<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBasicInfo.aspx.cs"
    Inherits="MUREOUI.Administration.ViewBasicInfo" %>

<%@ Register TagPrefix="uc1" TagName="LeftNavigationControl" Src="../UserControls/LeftNavigationControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FooterControl" Src="../UserControls/FooterControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderControl" Src="../UserControls/HeaderControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="LeftNavigationControlForAdmin" Src="../UserControls/LeftNavigationControlForAdmin.ascx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>ViewBasicInfo</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
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
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="GridLayout">
    <form id="frmViewBasicInfo" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="maintbl" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <uc1:HeaderControl ID="HeaderControl1" runat="server"></uc1:HeaderControl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <tr>
                                <td valign="top" align="left" width="20%">
                                    <uc1:LeftNavigationControlForAdmin ID="LeftNavigationControlForAdmin1" runat="server">
                                    </uc1:LeftNavigationControlForAdmin>
                                </td>
                                <td valign="top" align="center">
                                    <table id="tbl2" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="middle" align="center" colspan="5">
                                                <table id="tbl4" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr valign="middle" bgcolor="#ffffcc">
                                                        <td colspan="5" class="FormHeader">
                                                            Maintain&nbsp;Basic Information
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:ImageButton ID="imgAdd" OnClick="imgAdd_Click" runat="server" ImageUrl="../Images/create-basic-information.gif"
                                                                AlternateText="Create Basic Information"></asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgExpnadAll" OnClick="imgExpnadAll_Click" runat="server" ImageUrl="../Images/expandall.gif">
                                                            </asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgCollapseall" OnClick="imgCollapseall_Click" runat="server"
                                                                ImageUrl="../Images/collpaseall.gif"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid;
                                                                border-color: #000000; border-bottom: 1px solid" width="100%" cellpadding="0"
                                                                cellspacing="0">
                                                                <tr>
                                                                    <td align="center">
                                                                        <%--<asp:DataGrid CellPadding="0" CellSpacing="0" ID="drgdCatBasicInfo" runat="server"
                                                                    GridLines="None" Width="100%" HeaderStyle-CssClass="SubHeader" AutoGenerateColumns="False"
                                                                    BorderColor="black">
                                                                    <AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                                                    <HeaderStyle CssClass="SubHeader"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn HeaderText="Key">
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="SubHeader"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgCategory1" CommandName="Category1" ImageUrl="../Images/arrow1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="imgCategory2" CommandName="Category2" ImageUrl="../Images/arrow_down1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:Label ID="lblKeyName" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn HeaderText="Value">
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("Category_ID")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkCategoryName" CommandName="CatName" runat="server" Text='<%# Eval("Category_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>--%>
                                                                        <dx:ASPxGridView ID="drgdCatBasicInfo" OnHtmlRowPrepared="drgdCatBasicInfo_HtmlRowPrepared"
                                                                            KeyFieldName="Category_ID" Width="100%" runat="server" AutoGenerateColumns="False">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" VisibleIndex="1"
                                                                                    Caption="Key">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgCategory1" OnCommand="imgCategory1_Command"
                                                                                            CommandName="Category1" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="imgCategory2" OnCommand="imgCategory2_Command"
                                                                                            CommandName="Category2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblKeyName" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="Value"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("Category_ID")%>' Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkCategoryName" OnCommand="lnkCategoryName_Command" CommandName='<%# Eval("Category_ID")%>'
                                                                                            runat="server" Text='<%# Eval("Category_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="50" Position="Bottom">
                                                                            </SettingsPager>
                                                                            <Settings GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <!-- grid for EO type-->
                                                                        <%--<asp:DataGrid ID="dgrdEOType" ShowHeader="False" ShowFooter="False" CellPadding="0"
                                                                    CellSpacing="0" runat="server" BorderWidth="0px" GridLines="None" Width="100%"
                                                                    AutoGenerateColumns="False" BorderColor="Gainsboro">
                                                                    <AlternatingItemStyle CssClass="AlternateRow1"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="AlternateRow2"></ItemStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgEOType1" CommandName="EO1" ImageUrl="../Images/arrow1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="imgEOType2" CommandName="EO2" ImageUrl="../Images/arrow_down1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:Label ID="lblEO" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEOTypeID" runat="server" Text='<%# Eval("EO_Type_Id")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkEOTypeName" CommandName="EOType" runat="server" Text='<%# Eval("EO_Type_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>--%>
                                                                        <dx:ASPxGridView ID="dgrdEOType" KeyFieldName="EO_Type_ID" Width="100%" runat="server"
                                                                            AutoGenerateColumns="False" OnHtmlRowPrepared="dgrdEOType_HtmlRowPrepared">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="EOType"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgEOType1" OnCommand="imgEOType1_Command" CommandName="EO1"
                                                                                            ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="imgEOType2" OnCommand="imgEOType2_Command" CommandName="EO2"
                                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblEO" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="EOTypeName"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblEOTypeID" runat="server" Text='<%# Eval("EO_Type_ID")%>' Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkEOTypeName" OnCommand="lnkEOTypeName_Command" CommandName='<%# Eval("EO_Type_ID")%>'
                                                                                            runat="server" Text='<%# Eval("EO_Type_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="50" Position="Bottom">
                                                                            </SettingsPager>
                                                                            <Settings ShowColumnHeaders="false" GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <!--grid ends for EO Type -->
                                                                        <!-- grid for Function type-->
                                                                        <%-- <asp:DataGrid CellPadding="0" CellSpacing="0" ID="dgrdFunction" ShowHeader="False"
                                                                    ShowFooter="False" runat="server" BorderColor="black" AutoGenerateColumns="False"
                                                                    Width="100%" GridLines="None" BorderWidth="0px">
                                                                    <AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="Imagefun1" CommandName="Fun1" ImageUrl="../Images/arrow1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="Imagefun2" CommandName="Fun2" ImageUrl="../Images/arrow_down1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:Label ID="lblfunc" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblfunId" runat="server" Text='<%# Eval("Function_Id")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkfunction" CommandName="Function" runat="server" Text='<%# Eval("Function_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>--%>
                                                                        <dx:ASPxGridView ID="dgrdFunction" KeyFieldName="function_ID" Width="100%" runat="server"
                                                                            AutoGenerateColumns="False" OnHtmlRowPrepared="dgrdFunction_HtmlRowPrepared">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="FunctionName"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" OnCommand="Imagefun1_Command" ID="Imagefun1" CommandName="Fun1"
                                                                                            ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" OnCommand="Imagefun2_Command" ID="Imagefun2" CommandName="Fun2"
                                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblfunc" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="Function Name"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblfunId" runat="server" Text='<%# Eval("function_ID")%>' Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkfunction" OnCommand="lnkfunction_Command" CommandName='<%# Eval("function_ID")%>'
                                                                                            runat="server" Text='<%# Eval("function_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="50" Position="Bottom">
                                                                            </SettingsPager>
                                                                            <Settings ShowColumnHeaders="false" GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <!--grid ends for Function -->
                                                                        <!-- grid for Machine type-->
                                                                        <%--<asp:DataGrid ID="dgrdMachine" CellPadding="0" CellSpacing="0" runat="server" ShowHeader="False"
                                                                    ShowFooter="False" BorderColor="black" AutoGenerateColumns="False" Width="100%"
                                                                    GridLines="None" BorderWidth="0px">
                                                                    <AlternatingItemStyle CssClass="AlternateRow1"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="AlternateRow2"></ItemStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="ImageMachine1" CommandName="Machine1" ImageUrl="../Images/arrow1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="ImageMachine2" CommandName="Machine2" ImageUrl="../Images/arrow_down1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:Label ID="lblMachine" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Eval("Machine_Id")%>' Visible="False">
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkMachine" CommandName="Machine" runat="server" Text='<%# Eval("Machine_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>--%>
                                                                        <dx:ASPxGridView ID="dgrdMachine" KeyFieldName="Machine_ID" Width="100%" runat="server"
                                                                            AutoGenerateColumns="False" OnHtmlRowPrepared="dgrdMachine_HtmlRowPrepared">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="MachineName"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="ImageMachine1" OnCommand="ImageMachine1_Command"
                                                                                            CommandName="Machine1" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="ImageMachine2" OnCommand="ImageMachine2_Command"
                                                                                            CommandName="Machine2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblMachine" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="Machine Name"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblMachineID" runat="server" Text='<%# Eval("Machine_ID")%>' Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkMachine" OnCommand="lnkMachine_Command" CommandName='<%# Eval("Machine_ID")%>'
                                                                                            runat="server" Text='<%# Eval("Machine_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="50" Position="Bottom">
                                                                            </SettingsPager>
                                                                            <Settings ShowColumnHeaders="false" GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <!--grid ends for Machine -->
                                                                        <!-- grid for PlantBasicInfo-->
                                                                        <%--<asp:DataGrid CellPadding="0" CellSpacing="0" ShowHeader="False" ShowFooter="False"
                                                                    ID="drgdPlantBasicInfo" runat="server" BorderWidth="0px" GridLines="None" Width="100%"
                                                                    AutoGenerateColumns="False" BorderColor="Gainsboro">
                                                                    <AlternatingItemStyle CssClass="AlternateRow2"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="AlternateRow1"></ItemStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="imgPlant1" CommandName="Plant1" ImageUrl="../Images/arrow1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="imgPlant2" CommandName="Plant2" ImageUrl="../Images/arrow_down1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:Label ID="lblplantName" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPlantID" runat="server" Text='<%# Eval("Plant_ID")%>' Visible="False">
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkPlantName" CommandName="PlantName" runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>--%>
                                                                        <dx:ASPxGridView ID="drgdPlantBasicInfo" OnHtmlRowPrepared="drgdPlantBasicInfo_HtmlRowPrepared"
                                                                            KeyFieldName="Plant_ID" Width="100%" runat="server" AutoGenerateColumns="False">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="Plant"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgPlant1" OnCommand="imgPlant1_Command" CommandName="Plant1"
                                                                                            ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="imgPlant2" OnCommand="imgPlant2_Command" CommandName="Plant2"
                                                                                            ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblplantName" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="Plant Name"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblPlantID" runat="server" Text='<%# Eval("Plant_ID")%>' Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkPlantName" OnCommand="lnkPlantName_Command" CommandName='<%# Eval("Plant_ID")%>'
                                                                                            runat="server" Text='<%# Eval("Plant_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="50" Position="Bottom">
                                                                            </SettingsPager>
                                                                            <Settings ShowColumnHeaders="false" GridLines="None" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <!--grid ends for PlantBasicInfo -->
                                                                        <!--grid begin for Project Type -->
                                                                        <%--<asp:DataGrid ID="dgrdProjectType" CellPadding="0" CellSpacing="0" ShowHeader="False"
                                                                    ShowFooter="False" runat="server" BorderColor="black" AutoGenerateColumns="False"
                                                                    Width="100%" GridLines="None" BorderWidth="0px">
                                                                    <AlternatingItemStyle CssClass="AlternateRow1"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="AlternateRow2"></ItemStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton runat="server" ID="ImgProjType1" CommandName="ProjType1" ImageUrl="../Images/arrow1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:ImageButton runat="server" ID="ImgProjType2" CommandName="ProjType2" ImageUrl="../Images/arrow_down1.gif">
                                                                                </asp:ImageButton>
                                                                                <asp:Label ID="lblProjType" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemStyle Width="50%"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblProjTypeID" runat="server" Text='<%# Eval("Project_Type_Id")%>'
                                                                                    Visible="False">
                                                                                </asp:Label>
                                                                                <asp:LinkButton ID="lnkProjTypeName" CommandName="ProjType" runat="server" Text='<%# Eval("Project_Type_Name")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>--%>
                                                                        <dx:ASPxGridView ID="dgrdProjectType" KeyFieldName="Project_Type_ID" Width="100%"
                                                                            runat="server" AutoGenerateColumns="False" OnHtmlRowPrepared="dgrdProjectType_HtmlRowPrepared">
                                                                            <Columns>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="ProjectType"
                                                                                    VisibleIndex="1">
                                                                                    <DataItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="ImgProjType1" OnCommand="ImgProjType1_Command"
                                                                                            CommandName="ProjType1" ImageUrl="../Images/arrow1.gif"></asp:ImageButton>
                                                                                        <asp:ImageButton runat="server" ID="ImgProjType2" OnCommand="ImgProjType2_Command"
                                                                                            CommandName="ProjType2" ImageUrl="../Images/arrow_down1.gif"></asp:ImageButton>
                                                                                        <asp:Label ID="lblProjType" runat="server" Text='<%# Eval("KeyName")%>'>
                                                                                        </asp:Label>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                                <dx:GridViewDataColumn CellStyle-HorizontalAlign="Left" Width="20%" Caption="Project TypeName"
                                                                                    VisibleIndex="2">
                                                                                    <DataItemTemplate>
                                                                                        <asp:Label ID="lblProjTypeID" runat="server" Text='<%# Eval("Project_Type_ID")%>'
                                                                                            Visible="False">
                                                                                        </asp:Label>
                                                                                        <asp:LinkButton ID="lnkProjTypeName" OnCommand="lnkProjTypeName_Command" CommandName='<%# Eval("Project_Type_ID")%>'
                                                                                            runat="server" Text='<%# Eval("Project_Type_Name")%>'>
                                                                                        </asp:LinkButton>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataColumn>
                                                                            </Columns>
                                                                            <SettingsPager PageSize="50" Position="Bottom">
                                                                            </SettingsPager>
                                                                            <Settings ShowColumnHeaders="false" GridLines="None" ShowGroupedColumns="false" />
                                                                            <Styles>
                                                                                <Header BackColor="#FFCC00" Font-Bold="true">
                                                                                </Header>
                                                                            </Styles>
                                                                        </dx:ASPxGridView>
                                                                        <!--grid ends for Project Type -->
                                                                    </td>
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
                        </table>
                        <uc1:FooterControl ID="FooterControl1" runat="server"></uc1:FooterControl>
                    </td>
                </tr>
            </table>
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
