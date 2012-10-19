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
    public partial class SearchProjEvents : System.Web.UI.Page
    {
        DataSet dsSeedData;
        DataSet dsSearchData;
        string strSearchKey;
        string strProjectName;
        string strEOName;
        string strProjectLead;
        string strPlantName;
        string strEONumber;
        string strEventName;
        string strProjectDate;
        string strArrangeOrder;
        int intLimitCount;
        string strSortType;
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownData(1, "Project_Name", "Project_ID", "--Select a Project--", drpProjNameDB);
                FillDropDownData(2, "Plant_Name", "Plant_ID", "--Select a Plant--", drpPlantDB);
                FillProjectLeadData(0, "Project_Lead", "Project_ID", "--Select Project Lead--", drpProjLeadDB);
                rdbSortType.SelectedIndex = 0;
                dgdSearchProject1.Visible = false;
            }
            Session.Remove("dsSearchResult");
            Session.Remove("dsSearch");
        }

        public void FillDropDownData(int tabValue, string colName1, string colName2, string optionalValue, DropDownList drpName)
        {
            dsSeedData = new DataSet();

            if (objEOBA.FillDropDownSeedData(ref dsSeedData))
            {
                // For Each dtRow As DataRow In dsSeedData.Tables(0).Rows
                drpName.DataSource = dsSeedData.Tables[tabValue].DefaultView;
                drpName.DataTextField = colName1;
                drpName.DataValueField = colName2;
                drpName.DataBind();
                drpName.Items.Insert(0, optionalValue);
            }


        }

        public void FillProjectLeadData(int tabValue, string colName1, string colName2, string optionalValue, DropDownList drpName)
        {

            if (objEOBA.FillDropDownSeedData1(ref dsSeedData))
            {
                // For Each dtRow As DataRow In dsSeedData.Tables(0).Rows
                drpName.DataSource = dsSeedData.Tables[tabValue].DefaultView;
                drpName.DataTextField = colName1;
                drpName.DataValueField = colName2;
                drpName.DataBind();
                drpName.Items.Insert(0, optionalValue);
            }
            // For Each dtRow As DataRow In dsSeedData.Tables(0).Rows
            drpName.DataSource = dsSeedData.Tables[tabValue].DefaultView;
            drpName.DataTextField = colName1;
            drpName.DataValueField = colName2;
            drpName.DataBind();
            drpName.Items.Insert(0, optionalValue);
        }

        public void SearchWithAny()
        {
            if ((drpProjNameDB.SelectedIndex > 0))
            {
                strProjectName = drpProjNameDB.SelectedItem.Text;
            }
            else
            {
                strProjectName = String.Empty;
                // strProjectName = Convert.ToString(Convert.DBNull.Value)
            }
            if ((txtEONameDB.Text != ""))
            {
                strEOName = txtEONameDB.Text;
            }
            else
            {
                strEOName = String.Empty;
                //  strEOName = Convert.ToString(Convert.DBNull.Value)
            }
            if ((drpProjLeadDB.SelectedIndex > 0))
            {
                strProjectLead = drpProjLeadDB.SelectedItem.Text;
            }
            else
            {
                strProjectLead = String.Empty;
                // strProjectLead = Convert.ToString(Convert.DBNull.Value)
            }
            if ((drpPlantDB.SelectedIndex > 0))
            {
                strPlantName = drpPlantDB.SelectedItem.Text;
            }
            else
            {
                strPlantName = String.Empty;
                // strPlantName = Convert.ToString(Convert.DBNull.Value)
            }
            if ((txtEONumberDB.Text != ""))
            {
                strEONumber = txtEONumberDB.Text;
            }
            else
            {
                strEONumber = String.Empty;
                // strEONumber = Convert.ToString(Convert.DBNull.Value)
            }
            if ((txtPrjCreationDate.Text != ""))
            {
                strProjectDate = txtPrjCreationDate.Text;
            }
            else
            {
                strProjectDate = String.Empty;
            }
            if ((drpSearchSort.SelectedValue == "Relevance"))
            {
                strArrangeOrder = "Asc";
            }
            else if ((drpSearchSort.SelectedValue == "newestfirst"))
            {
                strArrangeOrder = "Desc";
            }
            else if ((drpSearchSort.SelectedValue == "oldestfirst"))
            {
                strArrangeOrder = "Asc";
            }
            if (((txtLimit.Text == "")
                        || (txtLimit.Text == String.Empty)))
            {
                txtLimit.Text = "0";
            }
            intLimitCount = Convert.ToInt32(txtLimit.Text.ToString().Trim());
            if ((rdbSortType.SelectedValue == "exact"))
            {
                strSortType = "Normal";
            }
            else if ((rdbSortType.SelectedValue == "like"))
            {
                strSortType = "Like";
            }
            ClsSearch objSearch = new ClsSearch();
            if (objSearch.FillSearchDataGrid("Static_Search", "any", strProjectName, strEOName, strProjectLead, strPlantName, strEONumber, strProjectDate, strArrangeOrder, intLimitCount, strSortType, ref dsSearchData))
            {
                if ((dsSearchData == null))
                {
                    Session["dsSearchResult"] = 1;
                }
                else if ((dsSearchData.Tables.Count == 0))
                {
                    // dgdSearchProject.Visible = False
                    Session["dsSearchResult"] = 1;
                }
                else if ((dsSearchData.Tables[0].Rows.Count == 0))
                {
                    Session["dsSearchResult"] = 1;
                }
                else
                {
                    Session["dsSearchResult"] = 0;
                    Session["dsSearch"] = dsSearchData;
                    // dgdSearchProject.Visible = True
                    // dgdSearchProject.DataSource = dsSearchData.Tables(0).DefaultView
                    // dgdSearchProject.DataBind()
                }
            }
            // dsSearchData = ClsSearch.FillSearchDataGrid);

        }

        public void SearchWithAll()
        {
            // Check whether all fields are filled up for All condition
            if ((drpProjNameDB.SelectedIndex > 0))
            {
                strProjectName = drpProjNameDB.SelectedItem.Text;
            }
            else
            {
                strProjectName = String.Empty;
                // strProjectName = Convert.ToString(Convert.DBNull.Value)
            }
            if ((txtEONameDB.Text != ""))
            {
                strEOName = txtEONameDB.Text;
            }
            else
            {
                strEOName = String.Empty;
                //  strEOName = Convert.ToString(Convert.DBNull.Value)
            }
            if ((drpProjLeadDB.SelectedIndex > 0))
            {
                strProjectLead = drpProjLeadDB.SelectedItem.Text;
            }
            else
            {
                strProjectLead = String.Empty;
                // strProjectLead = Convert.ToString(Convert.DBNull.Value)
            }
            if ((drpPlantDB.SelectedIndex > 0))
            {
                strPlantName = drpPlantDB.SelectedItem.Text;
            }
            else
            {
                strPlantName = String.Empty;
                // strPlantName = Convert.ToString(Convert.DBNull.Value)
            }
            if ((txtEONumberDB.Text != ""))
            {
                strEONumber = txtEONumberDB.Text;
            }
            else
            {
                strEONumber = String.Empty;
                // strEONumber = Convert.ToString(Convert.DBNull.Value)
            }
            if ((txtPrjCreationDate.Text != ""))
            {
                strProjectDate = txtPrjCreationDate.Text;
            }
            else
            {
                strProjectDate = String.Empty;
            }
            if ((drpSearchSort.SelectedValue == "Relevance"))
            {
                strArrangeOrder = "Asc";
            }
            else if ((drpSearchSort.SelectedValue == "newestfirst"))
            {
                strArrangeOrder = "Desc";
            }
            else if ((drpSearchSort.SelectedValue == "oldestfirst"))
            {
                strArrangeOrder = "Asc";
            }
            if (((txtLimit.Text == "")
                        || (txtLimit.Text == String.Empty)))
            {
                txtLimit.Text = "0";
            }
            intLimitCount = Convert.ToInt32(txtLimit.Text.ToString().Trim());
            if ((rdbSortType.SelectedValue == "exact"))
            {
                strSortType = "Normal";
            }
            else if ((rdbSortType.SelectedValue == "like"))
            {
                strSortType = "Like";
            }
            dsSearchData = new DataSet();
            ClsSearch objSearch = new ClsSearch();

            if (objSearch.FillSearchDataGrid("Static_Search", "all", strProjectName, strEOName, strProjectLead, strPlantName, strEONumber, strProjectDate, strArrangeOrder, intLimitCount, strSortType, ref dsSearchData))
            {
                if ((dsSearchData == null))
                {
                    Session["dsSearchResult"] = 1;
                }
                else if ((dsSearchData.Tables.Count == 0))
                {
                    // dgdSearchProject.Visible = False
                    Session["dsSearchResult"] = 1;
                }
                else if ((dsSearchData.Tables[0].Rows.Count == 0))
                {
                    Session["dsSearchResult"] = 1;
                }
                else
                {
                    Session["dsSearchResult"] = 0;
                    Session["dsSearch"] = dsSearchData;
                    // dgdSearchProject.Visible = True
                    // dgdSearchProject.DataSource = dsSearchData.Tables(0).DefaultView
                    // dgdSearchProject.DataBind()
                }
            }

        }

        protected void drpSearchKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((drpSearchKey.SelectedItem.Text == "Any"))
            {
                // imgSearch.CausesValidation = False
                // dgdSearchProject.DataSource = Nothing
            }
            else if ((drpSearchKey.SelectedItem.Text == "All"))
            {
                // imgSearch.CausesValidation = True
                // dgdSearchProject.DataSource = Nothing
            }
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            string script;
            dgdSearchProject1.DataSource = null;
            strSearchKey = drpSearchKey.SelectedItem.Text;
            if ((strSearchKey == "Any"))
            {
                SearchWithAny();
            }
            else
            {
                SearchWithAll();
            }
            // script = "<script>"
            // script = script + "window.showModalDialog('ProjEventsResults.aspx','Search Projects/Events','status:no; dialogWidth:800px; dialogHeight:500px; help:no; scroll:Yes; menubar:no; resizable:Yes; Maximize:No')</script>"
            // Page.RegisterStartupScript("clientscript", script)
            // script = "<script>"
            // script = script + "window.open('ProjEventsResults.aspx','null','width=800,height=500,top=100,left=100');</script> "
            // Page.RegisterStartupScript("clientscript", script)
            Response.Redirect("../Common/ProjEventsResults.aspx");
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Common/Home.aspx");
        }

        protected void rdbSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((rdbSortType.SelectedValue == "exact"))
            {
                strSortType = "Normal";
            }
            else if ((rdbSortType.SelectedValue == "like"))
            {
                strSortType = "Like";
            }
        }

        protected void dgdSearchProject1_PageIndexChanged(object sender, EventArgs e)
        {
           
        }
    }


}