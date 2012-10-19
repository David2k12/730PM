<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewComments.aspx.cs" Inherits="MUREOUI.Common.ViewComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewComments</title>
    <LINK href="../StyleSheets/MUREO.css" type="text/css" rel="stylesheet">
    	<script>
    	    function Close() {
    	        if (confirm("Are you sure, you want to close the window?")) {
    	            window.close();
    	        }
    	    }

    	    function AddComment() {
    	        var comments;
    	        comments = window.prompt("Enter Comment");

    	        if (comments != null) {

    	            document.getElementById("hdComments").value = comments;
    	            return true;

    	        }
    	        return false;
    	    }
		</script>
</head>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="Javascript:window.focus();" rightMargin="0">
    <form id="Form1" method="post" runat="server">
			<input id="hdComments" type="hidden" runat="server">
			<table cellSpacing="5" cellPadding="5" width="100%">
				<tr>
					<td></td>
				</tr>
				<tr>
					<td><asp:Button ID="btnAddComment" Runat="server" Text="Add Comment" 
                            onclick="btnAddComment_Click"></asp:Button>&nbsp;&nbsp;
						<asp:button ID="btnView" Runat="server" Text="View Comments" 
                            onclick="btnView_Click"></asp:button>&nbsp;&nbsp;
						<img src="../Images/Cancel.gif" onclick="Close();" onmouseover="javascript:style.cursor='hand'">
					</td>
				</tr>
				<tr>
					<td>
						<asp:datagrid id="dgComments" BorderWidth="1px" runat="server" GridLines="None" AutoGenerateColumns="False"
							Width="100%" BorderStyle="Solid" onitemdatabound="dgComments_ItemDataBound">
							<ItemStyle CssClass="AlternateRow1"></ItemStyle>
							<AlternatingItemStyle CssClass="AlternateROw2"></AlternatingItemStyle>
							<HeaderStyle CssClass="SubHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="User Name / Date" ItemStyle-Width="60%">
									<ItemTemplate>
										<asp:Label ID="lblUser" Runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Pre Comments" ItemStyle-Width="40%" HeaderText="Comments"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
			</table>
		</form>
</body>
</html>
