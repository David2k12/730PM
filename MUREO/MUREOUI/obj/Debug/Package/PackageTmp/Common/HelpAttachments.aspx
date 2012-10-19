<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpAttachments.aspx.cs" Inherits="MUREOUI.Common.HelpAttachments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HelpAttachments</title>
    <script language="javascript" type="text/javascript">
        function btnCancel_onclick() {
            window.close()
        }
		</script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table align="center">
        <tr height="6">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
					<td align="center">&nbsp;
						<asp:HyperLink id="hyplnkProjects" runat="server" NavigateUrl="Templates\Help_Mureo_Intro_projEvents_.doc">Help-Mureo-Projects/Events</asp:HyperLink></td>
				</tr>
				<tr>
					<td align="center">&nbsp;
						<asp:HyperLink id="hyplnkAdmin" runat="server" NavigateUrl="Templates\Help_Mureo_Administration.doc">Help-Mureo-Administration</asp:HyperLink></td>
				</tr>
				<tr>
					<td align="center">&nbsp;
						<asp:HyperLink id="hyplnkEO" runat="server" NavigateUrl="Templates\Help_Mur_EoSiteTest.doc">Help-Mureo-Eo/Sitetest</asp:HyperLink></td>
				</tr>
                <tr>
					<td align="center">&nbsp; <IMG id="IMG1" onclick="btnCancel_onclick()" alt="" src="../Images/cancel.gif" runat="server">&nbsp;
					</td>
				</tr>
    </table>
    </form>
</body>
</html>
