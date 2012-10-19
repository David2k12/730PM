using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Common
{
    public partial class GCASNumber : System.Web.UI.Page
    {
        #region "Variable Declaration"

        public DataSet dsGCAS = new DataSet();
        static DataTable dtGCAS;
        public DataRow drGCAS;
        public DataSet dsGlobal;
        string stGCASSite;
        string stNewtoSite;
        int intLoop;
        string stNewtoCategory;
        string stIntermediate;
        string stGCASType;
        EOBA objEOBA = new EOBA();

        string strAllValues;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["rownum"]))
            {
                ImgEdit.Visible = true;
                btnAnotherGCASNum.Visible = false;
                btnClear.Visible = false;
                btnAddandClose.Visible = false;
            }
            else
            {
                ImgEdit.Visible = false;
                btnAnotherGCASNum.Visible = true;
                btnClear.Visible = true;
                btnAddandClose.Visible = true;
            }

            if (!Page.IsPostBack)
            {
                dtGCAS = MakeNamesTable();
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["EOID"]))
                    {
                        DataSet ds = new DataSet();
                        int i = 0;
                        if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                        {
                            if ((ds != null))
                            {
                                if (!(ds.Tables.Count == 0))
                                {
                                    if (!(ds.Tables[3].Rows.Count == 0))
                                    {
                                        for (i = 0; i <= ds.Tables[3].Rows.Count - 1; i++)
                                        {
                                            drGCAS = dtGCAS.NewRow();
                                            drGCAS["GCAS (Materials)"] = ds.Tables[3].Rows[i][0];
                                            drGCAS["Site"] = ds.Tables[3].Rows[i][1];
                                            drGCAS["New To Site"] = ds.Tables[3].Rows[i][2];
                                            drGCAS["New To Category"] = ds.Tables[3].Rows[i][3];
                                            drGCAS["Intermediate"] = ds.Tables[3].Rows[i][4];
                                            drGCAS["Type"] = ds.Tables[3].Rows[i][5];
                                            if (dtGCAS.Rows.Count > 0)
                                            {
                                                dtGCAS.Rows.InsertAt(drGCAS, dtGCAS.Rows.Count + 1);
                                            }
                                            else
                                            {
                                                dtGCAS.Rows.Add(drGCAS);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
                catch (Exception)
                {

                    throw;
                }
                if (Request.QueryString["GCASNumber"] != null)
                txtGCASNumber.Text = Request.QueryString["GCASNumber"];

                 string[] strSiteArr = null ;

                if (Request.QueryString["Site"] != null)
                {
                    strSiteArr = Request.QueryString["Site"].Split(',');
                }

                if (Request.QueryString["NewToSite"] != null)
                {
                    if (Request.QueryString["NewToSite"] == "Yes")
                    {
                        rbNewSite.Items[0].Selected = true;
                        rbNewSite.Items[1].Selected = false;
                    }
                    else
                    {
                        rbNewSite.Items[0].Selected = false;
                        rbNewSite.Items[1].Selected = true;
                    }
                }

                if (Request.QueryString["Category"] != null)
                {
                    if (Request.QueryString["Category"] == "Yes")
                    {
                        rbNewCategory.Items[0].Selected = true;
                        rbNewCategory.Items[1].Selected = false;
                    }
                    else
                    {
                        rbNewCategory.Items[1].Selected = true;
                    }
                }

                if (Request.QueryString["Intermediate"] != null)
                {
                    if (Request.QueryString["Intermediate"] == "Yes")
                    {
                        rbIntermediate.Items[0].Selected = true;
                        rbIntermediate.Items[1].Selected = false;
                    }
                    else
                    {
                        rbIntermediate.Items[0].Selected = false;
                        rbIntermediate.Items[1].Selected = true;
                    }
                }

                int intArr = 0;
                if (strSiteArr != null && strSiteArr.Length > 0)
                {
                    for (intArr = 0; intArr <= strSiteArr.Length - 1; intArr++)
                    {
                        if (strSiteArr[intArr] == "AY")
                        {
                            cbGCASSite.Items[0].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "AZ")
                        {
                            cbGCASSite.Items[1].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "BE")
                        {
                            cbGCASSite.Items[2].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "CG")
                        {
                            cbGCASSite.Items[3].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "GB")
                        {
                            cbGCASSite.Items[4].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "OX")
                        {
                            cbGCASSite.Items[5].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "MP")
                        {
                            cbGCASSite.Items[6].Selected = true;
                        }
                        else if (strSiteArr[intArr] == "ContractManufacturing")
                        {
                            cbGCASSite.Items[7].Selected = true;
                        }
                    }
                }

                 string[] strTypeArr = null;
                if (Request.QueryString["Type"] != null)
                {
                    strTypeArr =  Request.QueryString["Type"].Split(',');
                }
                int intTypeArr = 0;
                if (strTypeArr != null && strTypeArr.Length > 0)
                {
                    for (intTypeArr = 0; intTypeArr <= strTypeArr.Length - 1; intTypeArr++)
                    {
                        if (strTypeArr[intTypeArr].Trim() == "Developmental")
                        {
                            cbType.Items[0].Selected = true;
                        }
                        else if (strTypeArr[intTypeArr].Trim() == "Regulated")
                        {
                            cbType.Items[1].Selected = true;
                        }
                        else if (strTypeArr[intTypeArr].Trim() == "Contingent")
                        {
                            cbType.Items[2].Selected = true;
                        }
                        else if (strTypeArr[intTypeArr].Trim() == "Needs Activation")
                        {
                            cbType.Items[3].Selected = true;
                        }
                    }
                }

            }

        }

        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("GCASTable");
            // Add three column objects to the table.
            DataColumn GCASColumn = new DataColumn();
            GCASColumn.DataType = System.Type.GetType("System.Int32");
            GCASColumn.ColumnName = "GCAS (Materials)";
            namesTable.Columns.Add(GCASColumn);

            DataColumn siteColumn = new DataColumn();
            siteColumn.DataType = System.Type.GetType("System.String");
            siteColumn.ColumnName = "Site";
            namesTable.Columns.Add(siteColumn);

            DataColumn NewsiteColumn = new DataColumn();
            siteColumn.DataType = System.Type.GetType("System.String");
            NewsiteColumn.ColumnName = "New To Site";
            namesTable.Columns.Add(NewsiteColumn);

            DataColumn categoryColumn = new DataColumn();
            categoryColumn.DataType = System.Type.GetType("System.String");
            categoryColumn.ColumnName = "New To Category";
            namesTable.Columns.Add(categoryColumn);

            DataColumn interColumn = new DataColumn();
            interColumn.DataType = System.Type.GetType("System.String");
            interColumn.ColumnName = "Intermediate";
            namesTable.Columns.Add(interColumn);

            DataColumn TypeColumn = new DataColumn();
            TypeColumn.DataType = System.Type.GetType("System.String");
            TypeColumn.ColumnName = "Type";
            namesTable.Columns.Add(TypeColumn);
            // Return the new DataTable.
            return namesTable;
        }

        public void SiteData()
        {
            stGCASSite = string.Empty;
            for (intLoop = 0; intLoop <= cbGCASSite.Items.Count - 1; intLoop++)
            {
                if (cbGCASSite.Items[intLoop].Selected == true)
                {
                    if (string.IsNullOrEmpty(stGCASSite))
                    {
                        stGCASSite = cbGCASSite.Items[intLoop].Value;
                    }
                    else
                    {
                        stGCASSite = stGCASSite + "," + cbGCASSite.Items[intLoop].Value;
                    }
                }
            }
        }

        private void cbGCASSite_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            SiteData();
        }

        public void NewSite()
        {
            if (rbNewSite.Items[0].Selected == true)
            {
                stNewtoSite = "Yes";
            }
            else if (rbNewSite.Items[1].Selected == true)
            {
                stNewtoSite = "No";
            }
        }

        public void NewCategory()
        {
            if (rbNewCategory.Items[0].Selected == true)
            {
                stNewtoCategory = "Yes";
            }
            else if (rbNewCategory.Items[1].Selected == true)
            {
                stNewtoCategory = "No";
            }
        }

        private void rbNewCategory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            NewCategory();
        }

        public void Intermediate()
        {
            if (rbIntermediate.Items[0].Selected == true)
            {
                stIntermediate = "Yes";
            }
            else if (rbIntermediate.Items[1].Selected == true)
            {
                stIntermediate = "No";
            }
        }

        private void rbIntermediate_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Intermediate();
        }

        public void Type()
        {
            stGCASType = string.Empty;
            for (intLoop = 0; intLoop <= cbType.Items.Count - 1; intLoop++)
            {
                if (cbType.Items[intLoop].Selected == true)
                {
                    if (string.IsNullOrEmpty(stGCASType))
                    {
                        stGCASType = cbType.Items[intLoop].Text;
                    }
                    else
                    {
                        stGCASType = stGCASType + "," + cbType.Items[intLoop].Text;
                    }
                }
            }
        }

        private void cbType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Type();
        }

        private int addGCASNO()
        {
            int intResult = 0;
            string strGCASSite = null;
            string strNewtoSite = null;
            string strNewtoCategory = null;
            string strIntermediate = null;
            string strTpDevelop = null;
            string strTpRegulated = null;
            string strTpContingent = null;
            string strTpNeedActivation = null;

            //strGCASSite
            for (intLoop = 0; intLoop <= cbGCASSite.Items.Count - 1; intLoop++)
            {
                if (cbGCASSite.Items[intLoop].Selected == true)
                {
                    if (string.IsNullOrEmpty(strGCASSite))
                    {
                        strGCASSite = cbGCASSite.Items[intLoop].Value;
                    }
                    else
                    {
                        strGCASSite = strGCASSite + "," + cbGCASSite.Items[intLoop].Value;
                    }
                }
            }
            if (string.IsNullOrEmpty(strGCASSite))
            {
                strGCASSite = "No";
            }

            //strNewtoSite
            if (rbNewSite.Items[0].Selected == true)
            {
                strNewtoSite = "Y";
            }
            else if (rbNewSite.Items[1].Selected == true)
            {
                strNewtoSite = "N";
            }

            //strNewtoCategory
            if (rbNewCategory.Items[0].Selected == true)
            {
                strNewtoCategory = "Y";
            }
            else if (rbNewCategory.Items[1].Selected == true)
            {
                strNewtoCategory = "N";
            }

            if (rbIntermediate.Items[0].Selected == true)
            {
                strIntermediate = "Y";
            }
            else if (rbIntermediate.Items[1].Selected == true)
            {
                strIntermediate = "N";
            }

            for (intLoop = 0; intLoop <= cbType.Items.Count - 1; intLoop++)
            {
                if (cbType.Items[intLoop].Selected == true)
                {
                    if (intLoop == 0)
                    {
                        strTpDevelop = "Y";
                    }
                    else if (intLoop == 1)
                    {
                        strTpRegulated = "Y";
                    }
                    else if (intLoop == 2)
                    {
                        strTpContingent = "Y";
                    }
                    else if (intLoop == 3)
                    {
                        strTpNeedActivation = "Y";
                    }
                }
                else
                {
                    if (intLoop == 0)
                    {
                        strTpDevelop = "N";
                    }
                    else if (intLoop == 1)
                    {
                        strTpRegulated = "N";
                    }
                    else if (intLoop == 2)
                    {
                        strTpContingent = "N";
                    }
                    else if (intLoop == 3)
                    {
                        strTpNeedActivation = "N";
                    }
                }
            }

            SqlParameter[] paramOut = null;
            if (objEOBA.AddGCASNo(Convert.ToInt32(Request.QueryString["EOID"]), Convert.ToInt32(txtGCASNumber.Text), strGCASSite, Convert.ToChar(strNewtoSite), Convert.ToChar(strNewtoCategory), Convert.ToChar(strIntermediate), Convert.ToChar(strTpDevelop), Convert.ToChar(strTpRegulated), Convert.ToChar(strTpContingent), Convert.ToChar(strTpNeedActivation), ref paramOut))
                intResult = Convert.ToInt32(paramOut[0].Value);
            else
                intResult = 0;
            return intResult;
        }

        private int updateGCASNO()
        {
            int intResult = 0;
            string strGCASSite = null;
            string strNewtoSite = null;
            string strNewtoCategory = null;
            string strIntermediate = null;
            string strTpDevelop = null;
            string strTpRegulated = null;
            string strTpContingent = null;
            string strTpNeedActivation = null;

            //strGCASSite
            for (intLoop = 0; intLoop <= cbGCASSite.Items.Count - 1; intLoop++)
            {
                if (cbGCASSite.Items[intLoop].Selected == true)
                {
                    if (string.IsNullOrEmpty(strGCASSite))
                    {
                        strGCASSite = cbGCASSite.Items[intLoop].Value;
                    }
                    else
                    {
                        strGCASSite = strGCASSite + "," + cbGCASSite.Items[intLoop].Value;
                    }
                }
            }
            if (string.IsNullOrEmpty(strGCASSite))
            {
                strGCASSite = "No";
            }

            //strNewtoSite
            if (rbNewSite.Items[0].Selected == true)
            {
                strNewtoSite = "Y";
            }
            else if (rbNewSite.Items[1].Selected == true)
            {
                strNewtoSite = "N";
            }

            //strNewtoCategory
            if (rbNewCategory.Items[0].Selected == true)
            {
                strNewtoCategory = "Y";
            }
            else if (rbNewCategory.Items[1].Selected == true)
            {
                strNewtoCategory = "N";
            }

            if (rbIntermediate.Items[0].Selected == true)
            {
                strIntermediate = "Y";
            }
            else if (rbIntermediate.Items[1].Selected == true)
            {
                strIntermediate = "N";
            }
            for (intLoop = 0; intLoop <= cbType.Items.Count - 1; intLoop++)
            {
                if (cbType.Items[intLoop].Selected == true)
                {
                    if (intLoop == 0)
                    {
                        strTpDevelop = "Y";
                    }
                    else if (intLoop == 1)
                    {
                        strTpRegulated = "Y";
                    }
                    else if (intLoop == 2)
                    {
                        strTpContingent = "Y";
                    }
                    else if (intLoop == 3)
                    {
                        strTpNeedActivation = "Y";
                    }
                }
                else
                {
                    if (intLoop == 0)
                    {
                        strTpDevelop = "N";
                    }
                    else if (intLoop == 1)
                    {
                        strTpRegulated = "N";
                    }
                    else if (intLoop == 2)
                    {
                        strTpContingent = "N";
                    }
                    else if (intLoop == 3)
                    {
                        strTpNeedActivation = "N";
                    }
                }
            }
            SqlParameter[] paramOut = null;
            if (objEOBA.UpdateGCASNo(Convert.ToInt32(Request.QueryString["rownum"]), Convert.ToInt32(txtGCASNumber.Text), strGCASSite.ToString(), Convert.ToChar(strNewtoSite), Convert.ToChar(strNewtoCategory), Convert.ToChar(strIntermediate), Convert.ToChar(strTpDevelop), Convert.ToChar(strTpRegulated), Convert.ToChar(strTpContingent), Convert.ToChar(strTpNeedActivation), ref paramOut))
                intResult = Convert.ToInt32(paramOut[0].Value);
            else
                intResult = 0;
            return intResult;

        }
        

        protected void btnAnotherGCASNum_Click(object sender, ImageClickEventArgs e)
        {
            addGCASNO();
            string script = null;
            script = "<script>alert('GCAS number added');</script>";
            Page.RegisterStartupScript("clientscript", script);
            txtGCASNumber.Text = "";
            cbGCASSite.Items[0].Selected = false;
            cbGCASSite.Items[1].Selected = false;
            cbGCASSite.Items[2].Selected = false;
            cbGCASSite.Items[3].Selected = false;
            cbGCASSite.Items[4].Selected = false;
            cbGCASSite.Items[5].Selected = false;
            cbGCASSite.Items[6].Selected = false;
            rbIntermediate.Items[0].Selected = false;
            rbIntermediate.Items[1].Selected = true;
            rbNewCategory.Items[0].Selected = false;
            rbNewCategory.Items[1].Selected = true;
            rbNewSite.Items[0].Selected = false;
            rbNewSite.Items[1].Selected = true;
            cbGCASSite.Items[0].Selected = false;
            cbGCASSite.Items[1].Selected = false;
            cbType.Items[0].Selected = false;
            cbType.Items[1].Selected = false;
            cbType.Items[2].Selected = false;
            cbType.Items[3].Selected = false;
        }

        protected void btnAddandClose_Click(object sender, ImageClickEventArgs e)
        {
            addGCASNO();
            string script = null;
            script = "<script>window.returnValue ='' ;";
            script = script + "window.opener.RefreshPage();window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

        protected void ImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            updateGCASNO();
            if (!(strAllValues == string.Empty))
            {
                string script = null;
                script = "<script>window.returnValue = '" + strAllValues + "';";
                script = script + "window.opener.RefreshPage();window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
            else
            {
                string script = null;
                script = "<script>window.returnValue ='' ;";
                script = script + "window.opener.RefreshPage();window.close();</script>";
                Page.RegisterStartupScript("clientscript", script);
            }
        }

        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtGCASNumber.Text = "";
            cbGCASSite.Items[0].Selected = false;
            cbGCASSite.Items[1].Selected = false;
            cbGCASSite.Items[2].Selected = false;
            cbGCASSite.Items[3].Selected = false;
            cbGCASSite.Items[4].Selected = false;
            cbGCASSite.Items[5].Selected = false;
            cbGCASSite.Items[6].Selected = false;
            cbGCASSite.Items[7].Selected = false;
            rbIntermediate.Items[0].Selected = false;
            rbIntermediate.Items[1].Selected = true;
            rbNewCategory.Items[0].Selected = false;
            rbNewCategory.Items[1].Selected = true;
            rbNewSite.Items[0].Selected = false;
            rbNewSite.Items[1].Selected = true;
            cbGCASSite.Items[0].Selected = false;
            cbGCASSite.Items[1].Selected = false;
            cbType.Items[0].Selected = false;
            cbType.Items[1].Selected = false;
            cbType.Items[2].Selected = false;
            cbType.Items[3].Selected = false;
           
        }
    }
}