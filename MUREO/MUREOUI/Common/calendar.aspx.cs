using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Common
{
    public partial class calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string lsValue;
            if (!IsPostBack)
            {
                lsValue = Request.QueryString["value"];
                if ((lsValue != ""))
                {
                    calPCS.VisibleDate = DateTime.Parse(lsValue);
                    calPCS.SelectedDate = DateTime.Parse(lsValue);
                    calPCS.SelectedDayStyle.Font.Bold = true;
                }
            }
        }

        protected void calPCS_SelectionChanged(object sender, EventArgs e)
        {
            string strjscript;
            int lintCount;
            string[] lsFieldNames;
            if ((calPCS.SelectedDate >=Convert.ToDateTime( System.DateTime.Now.Date)))
            {
                char[] delimeter = new char[] { ','};
                lsFieldNames = Request.QueryString["formname"].Split(delimeter);
                strjscript = "<script language=\'javascript\'>";
                for (lintCount = 0; (lintCount
                            <= (lsFieldNames.Length - 1)); lintCount++)
                {
                    strjscript = (strjscript + ("window.opener." + lsFieldNames[lintCount]));
                    strjscript = (strjscript + (".value = \'"
                                + (calPCS.SelectedDate.ToString("MM/dd/yyyy") + "\';")));
                }
                strjscript = (strjscript + ("window.close();</script" + ">"));
                ltlDate.Text = strjscript;
            }
            else
            {
                ltlDate.Text = "<br><font color=red>Selected  Date should not<br> be less than current Date</font>";
            }
        }

        protected void calPCS_DayRender(object sender, DayRenderEventArgs e)
        {
            if ((e.Day.Date.ToString("d") == DateTime.Now.ToString("d")))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray;
            }
        }
    }
}