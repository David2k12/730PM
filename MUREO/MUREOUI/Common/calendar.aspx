<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="MUREOUI.Common.calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
		<title>Choose a Date</title>
	</HEAD>
	<body>
		<form id="Form1" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center">
						<asp:Calendar id="calPCS" runat="server" showtitle="true" 
                            DayNameFormat="FirstTwoLetters" SelectionMode="Day"
							BackColor="#ffffff" FirstDayOfWeek="Monday" BorderColor="#000000" ForeColor="#00000" Height="60"
							Width="120" ondayrender="calPCS_DayRender" onselectionchanged="calPCS_SelectionChanged">
							<TitleStyle backcolor="#000080" forecolor="#ffffff" />
							<NextPrevStyle backcolor="#000080" forecolor="#ffffff" />
							<TodayDayStyle ForeColor="#cc0099"></TodayDayStyle>
							<OtherMonthDayStyle forecolor="#c0c0c0" />
						</asp:Calendar>
						<asp:Literal id="ltlDate" runat="server"></asp:Literal>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
