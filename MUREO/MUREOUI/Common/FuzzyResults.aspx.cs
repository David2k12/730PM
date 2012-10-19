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
using MUREOUI.Common;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace MUREOUI.Common
{
    public partial class FuzzyResults : System.Web.UI.Page
    {
        DataSet dsFuzzy = null;
        
        string strSearchWord = String.Empty;
        string strSort = String.Empty;
        int intLimit;
        int intType;
        string strType = String.Empty;
        string strGlobalSort = String.Empty;
        int strGlobalLimit;
        string strGlobalType = String.Empty;
        string strGlobalSearchWord = String.Empty;
        ClsSearch objclsSearch = new ClsSearch();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            strSearchWord = Request.QueryString["strSearch"];
            strSort = Request.QueryString["sort"];
            if ((strSort == "rel"))
            {
                strSort = "Relevance";
            }
            else if ((strSort == "lm"))
            {
                strSort = "Last Modified";
            }
            else if ((strSort == "fm"))
            {
                strSort = "First Modified";
            }
            else if ((strSort == "kco"))
            {
                strSort = "Keep Current Order";
            }
            intLimit = Convert.ToInt32(Request.QueryString["limit"]);
            intType = Convert.ToInt32(Request.QueryString["Type"]);
            if ((intType == 0))
            {
                strType = "Exact";
            }
            else
            {
                strType = "Like";
            }
            FillSearchData(strSearchWord, strSort, intLimit, strType);
        }

        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Common/FuzzySearch.aspx");
        }
       
        protected void PagerButtonClick(object sender, ImageClickEventArgs e)
        {
            //PagerButton_Command(sender,  e);

         
        }

        void FillSearchData(string strSearchWord, string strSort, int intLimit, string strType)
        {
            try
            {
                dsFuzzy = null;
               // dsFuzzy = ClsSearch.FillFuzzyDataGrid(strSearchWord, strSort, intLimit);
                strGlobalSearchWord = strSearchWord;
                strGlobalSort = strSort;
                strGlobalLimit = intLimit;
                strGlobalType = strType;
                if(objclsSearch.FillFuzzyDataGrid(strSearchWord, strSort, intLimit, ref dsFuzzy))
                {
                    if ((dsFuzzy == null))
                    {
                        lblSearhcResult.Visible = true;
                        dgdFuzzyResultsnew.Visible = false;
                        return;
                    }
                    else if ((dsFuzzy.Tables.Count == 0))
                    {
                        lblSearhcResult.Visible = true;
                        dgdFuzzyResultsnew.Visible = false;
                        return;
                    }
                    else if ((dsFuzzy.Tables[0].Rows.Count == 0))
                    {
                        lblSearhcResult.Visible = true;
                        dgdFuzzyResultsnew.Visible = false;
                        return;
                    }
                    else
                    {
                        lblSearhcResult.Visible = false;
                        dgdFuzzyResultsnew.Visible = true;
                        dgdFuzzyResultsnew.DataSource = dsFuzzy.Tables[0].DefaultView;
                        if ((dsFuzzy.Tables[0].Rows.Count <= dgdFuzzyResultsnew.PageCount))
                        {
                        
                            // If dgdCancelledEO.CurrentPageIndex <> 0 Then
                            // dgdCancelledEO.CurrentPageIndex -= 1
                            // End If
                        }
                        else
                        {
                           
                        }
                        dgdFuzzyResultsnew.DataBind();
                    }
                }
                
            }
            catch (Exception ex)
            {
                string script;
                script = ("alert('"
                            + (ex.Message + "');"));
                //Page.RegisterStartupScript("error_message", script);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
            }
        }

        protected void dgdFuzzyResultsnew_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgdFuzzyResultsnew.PageIndex = e.NewPageIndex;
            FillSearchData(strGlobalSearchWord, strGlobalSort, strGlobalLimit, strGlobalType);
        }


        protected void dgdFuzzyResultsnew_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
             
                if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;
                if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                {
                   // e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
  
                }
          
        }
        protected void ReadOnly_Click(object sender, CommandEventArgs e)
        {
            try
            {
                if ((e.CommandName == "ReadOnly"))
                {
                    ImageButton ImgReadOnlyEO = (ImageButton)sender;
                    GridViewDataRowTemplateContainer gvd = (GridViewDataRowTemplateContainer)ImgReadOnlyEO.Parent;
                    int rowno = gvd.ItemIndex;
                    int intEOID = Convert.ToInt32(dgdFuzzyResultsnew.KeyFieldName[rowno]);
                    Response.Redirect(("../Common/ViewEO.aspx?EO_ID=" + intEOID.ToString()));
                }      

            }
            catch (Exception exc)
            {

            }
        }

        protected void dgdFuzzyResultsnew_PageIndexChanged1(object sender, EventArgs e)
        {
            //dgdFuzzyResultsnew.PageIndex = e
            //FillSearchData(strGlobalSearchWord, strGlobalSort, strGlobalLimit, strGlobalType);
        }

    }
}