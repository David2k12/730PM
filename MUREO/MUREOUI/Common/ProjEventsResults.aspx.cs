using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOPROP;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Mail;
using System.Text;
namespace MUREOUI.Common
{
    public partial class ProjEventsResults : System.Web.UI.Page
    {
        DataSet dsSearchData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgNext.Visible = false;
                imgPrevious.Visible = false;
                FillDataGrid();
            }
        }
        public void FillDataGrid()
        {
            int intSearchResult;
            Response.Write(Request.QueryString["par1"]);
            intSearchResult = Convert.ToInt32(Session["dsSearchResult"].ToString().Trim());
            if ((intSearchResult == 1))
            {
                lblSearhcResult.Visible = true;
                dgdSearchProject.Visible = false;
                return;
            }
            else if ((intSearchResult == 0))
            {
                dsSearchData = new DataSet();
                dsSearchData = (DataSet)Session["dsSearch"];
                dgdSearchProject.Visible = true;
                dgdSearchProject.DataSource = dsSearchData;
                if ((dsSearchData.Tables[0].Rows.Count <= dgdSearchProject.PageCount))
                {
                    imgNext.Visible = false;
                    imgPrevious.Visible = false;
                }
                else
                {
                    imgNext.Visible = false;
                    imgPrevious.Visible = false;
                }
                dgdSearchProject.DataBind();
                lblSearhcResult.Visible = false;
          }
        }

        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Common/SearchProjEvents.aspx");
        }

        protected void PagerButtonClick(object sender, ImageClickEventArgs e)
        {
            //string arg = sender.CommandArgument;
            //switch (arg)
            //{
            //    case "Next":
            //        if ((dgdSearchProject.PageIndex
            //                    == (dgdSearchProject.PageCount - 1)))
            //        {
            //            // Dim jvScript As String
            //            // jvScript = "<script>alert('" & ConfigurationSettings.AppSettings("DataGridLastPage") & "');</script>"
            //            // Page.RegisterStartupScript("ClientScript", jvScript)
            //            imgNext.Enabled = false;
            //            imgPrevious.Enabled = true;
            //        }
            //        else if (((dgdSearchProject.PageIndex > 0)
            //                    && (dgdSearchProject.PageIndex
            //                    < (dgdSearchProject.PageCount - 1))))
            //        {
            //            imgNext.Enabled = true;
            //            imgPrevious.Enabled = true;
            //        }
            //        if ((dgdSearchProject.PageIndex
            //                    < (dgdSearchProject.PageCount - 1)))
            //        {
            //            dgdSearchProject.PageIndex++;
            //        }
            //        break;
            //    case "Prev":
            //        if ((dgdSearchProject.PageIndex == 0))
            //        {
            //            // Dim jvScript As String
            //            // jvScript = "<script>alert('" & ConfigurationSettings.AppSettings("DataGridFirstPage") & "');</script>"
            //            // Page.RegisterStartupScript("ClientScript", jvScript)
            //            imgPrevious.Enabled = false;
            //            imgNext.Enabled = true;
            //        }
            //        else if (((dgdSearchProject.PageIndex > 0)
            //                    && (dgdSearchProject.PageIndex
            //                    < (dgdSearchProject.PageCount - 1))))
            //        {
            //            imgPrevious.Enabled = true;
            //            imgNext.Enabled = true;
            //        }
            //        if ((dgdSearchProject.PageIndex > 0))
            //        {
            //            dgdSearchProject.PageIndex--;
            //        }
            //        // Case "Last"
            //        // dgdMyEO.CurrentPageIndex = (dgdMyEO.PageCount - 1)
            //        // Case Else
            //        // dgdMyEO.CurrentPageIndex = Convert.ToInt32(arg)
            //        break;
            //}
            //FillDataGrid();
        }

        protected void dgdSearchProject_PageIndexChanged(object sender, EventArgs e)
        {
            if (Session["dsSearch"] != null)
            {
                //dgdSearchProject.PageIndex = -1;

                dgdSearchProject.DataSource = (DataSet)Session["dsSearch"];
                dgdSearchProject.DataBind();
            }
        }
    }
}