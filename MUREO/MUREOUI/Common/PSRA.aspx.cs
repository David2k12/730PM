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
    public partial class PSRA : System.Web.UI.Page
    {
        #region "Variable Declaration"
        string strAllValues;
        static DataTable dtGCAS;
        public DataRow drGCAS;
        //ClsEO objClsEO = new ClsEO();
        EOBA objEOBA = new EOBA();
        
        #endregion


        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            //txtMaterialUsage.Attributes.Add("onblur", "javascript: CountDecimalsValueThree(this.value,'txtMaterialUsage');")
            if (!IsPostBack)
            {
                dtGCAS = MakeNamesTable();
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["EOID"]))
                    {
                        DataSet ds = null;
                        int i = 0;
                        if (objEOBA.GET_EO_Preliminary(Convert.ToInt32(Request.QueryString["EOID"]),ref ds))
                        {
                            if ((ds != null))
                            {
                                if (!(ds.Tables.Count == 0))
                                {
                                    if (!(ds.Tables[5].Rows.Count == 0))
                                    {
                                        for (i = 0; i <= ds.Tables[5].Rows.Count - 1; i++)
                                        {
                                            drGCAS = dtGCAS.NewRow();
                                            drGCAS["CT Tracking Number"] = ds.Tables[5].Rows[i][0];
                                            drGCAS["Supplier Name"] = ds.Tables[5].Rows[i][1];
                                            drGCAS["Material Application"] = ds.Tables[5].Rows[i][2];
                                            drGCAS["Material Usage Amount"] = ds.Tables[5].Rows[i][3];
                                            drGCAS["PS&RA Level"] = ds.Tables[5].Rows[i][4];
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
                catch (Exception ex)
                {
                }
                if (!string.IsNullOrEmpty(Request.QueryString["rownum"]))
                {
                    tblPSRA.Width = "80%";
                    tblPSRA.Align = "Center";
                    ImgEdit.Visible = true;
                    btnAddAnother.Visible = false;
                    btnClear.Visible = false;
                    imgAddClose.Visible = false;
                    txtCTTrackingNumber.Text = Request.QueryString["CTnum"].ToString().Trim();
                    txtSupplierName.Text = Request.QueryString["SupName"].ToString().Trim();
                    txtMaterial.Text = Request.QueryString["MatApplication"].ToString().Trim();
                    txtMaterialUsage.Text = Request.QueryString["MatUsageAmount"].ToString().Trim();
                    txtPSRALevel.Text = Request.QueryString["PSRALevel"].ToString().Trim();
                }
                else
                {
                    tblPSRA.Width = "50%";
                    btnAddAnother.Visible = true;
                    btnClear.Visible = true;
                    imgAddClose.Visible = true;
                    ImgEdit.Visible = false;
                }
            }
        }

        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("PSRATable");
            // Add three column objects to the table.
            DataColumn CTTrackingNumber = new DataColumn();
            CTTrackingNumber.DataType = System.Type.GetType("System.String");
            CTTrackingNumber.ColumnName = "CT Tracking Number";
            namesTable.Columns.Add(CTTrackingNumber);

            DataColumn SupplierName = new DataColumn();
            SupplierName.DataType = System.Type.GetType("System.String");
            SupplierName.ColumnName = "Supplier Name";
            namesTable.Columns.Add(SupplierName);

            DataColumn MaterialApplication = new DataColumn();
            MaterialApplication.DataType = System.Type.GetType("System.String");
            MaterialApplication.ColumnName = "Material Application";
            namesTable.Columns.Add(MaterialApplication);

            DataColumn MaterialUsageAmount = new DataColumn();
            MaterialUsageAmount.DataType = System.Type.GetType("System.String");
            MaterialUsageAmount.ColumnName = "Material Usage Amount";
            namesTable.Columns.Add(MaterialUsageAmount);

            DataColumn PSRALevel = new DataColumn();
            PSRALevel.DataType = System.Type.GetType("System.String");
            PSRALevel.ColumnName = "PS&RA Level";
            namesTable.Columns.Add(PSRALevel);

            // Return the new DataTable.
            return namesTable;
        }

        private int addPSARANO()
        {
            int intResult = 0;
             SqlParameter[] paramOut = null;
            if(objEOBA.AddPSRANo(Convert.ToInt32(Request.QueryString["EOID"]), txtCTTrackingNumber.Text.Trim(), txtSupplierName.Text.Trim(), txtMaterial.Text.Trim(), txtMaterialUsage.Text.Trim(), txtPSRALevel.Text.Trim(), ref paramOut))
            intResult =  Convert.ToInt32(paramOut[0].Value);
            return intResult;

        }

        private object updatePSRANo()
        {
            int intResult = 0;
             SqlParameter[] paramOut = null;
            if(objEOBA.updatePSRANo(Convert.ToInt32(Request.QueryString["rownum"]), txtCTTrackingNumber.Text.Trim(), txtSupplierName.Text.Trim(), txtMaterial.Text.Trim(), txtMaterialUsage.Text.Trim(), txtPSRALevel.Text.Trim(), ref paramOut))
            intResult =  Convert.ToInt32(paramOut[0].Value);
            return intResult;
        }

        private void ImgEdit_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {

            updatePSRANo();
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

        protected void btnAddAnother_Click(object sender, ImageClickEventArgs e)
        {
            addPSARANO();
            string script = null;
            script = "<script>alert('PSRA added');</script>";
            Page.RegisterStartupScript("clientscript", script);
            txtCTTrackingNumber.Text = "";
            txtMaterial.Text = "";
            txtMaterialUsage.Text = "";
            txtPSRALevel.Text = "";
            txtSupplierName.Text = "";
        }

        protected void imgAddClose_Click(object sender, ImageClickEventArgs e)
        {
            addPSARANO();
            string script = null;
            script = "<script>window.returnValue ='' ;";
            script = script + "window.opener.RefreshPage();window.close();</script>";
            Page.RegisterStartupScript("clientscript", script);
        }

        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtCTTrackingNumber.Text = "";
            txtMaterial.Text = "";
            txtMaterialUsage.Text = "";
            txtPSRALevel.Text = "";
            txtSupplierName.Text = "";
        }
    }
}