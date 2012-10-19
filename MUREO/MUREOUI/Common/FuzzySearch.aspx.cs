using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Common
{
    public partial class FuzzySearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtLimitSearch.Text = "0";
                txtSearchWord.Text = "";
                drpSearchSort.SelectedValue = "rel";
                rdbSearchType.Items[0].Selected = true;
                rdbSearchType.Items[1].Selected = false;
                rdList.Visible = false;
            }
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            if ((txtLimitSearch.Text.ToString().Trim() == ""))
            {
                txtLimitSearch.Text = "0";
            }
            if ((int.Parse(txtLimitSearch.Text) > 50))
            {
                string script;
                script = "alert('Please enter the limit less than 50.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
            else
            {
                //string strformatted = string.Format("../Common/FuzzyResults.aspx?strSearch={0}&sort={1}&limit={2}", txtSearchWord.Text.Trim, drpSearchSort.SelectedValue, txtLimitSearch.Text.Trim);
                Response.Redirect("../Common/FuzzyResults.aspx?strSearch=" + txtSearchWord.Text.ToString().Trim() + "&sort=" + drpSearchSort.SelectedValue.ToString() + "&limit=" + txtLimitSearch.Text.ToString().Trim());
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Common/Home.aspx");
        }
    }
}