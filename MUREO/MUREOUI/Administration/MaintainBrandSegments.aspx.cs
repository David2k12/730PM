using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOUI.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace MUREOUI.Administration
{
    public partial class MaintainBrandSegments : System.Web.UI.Page
    {
        DataSet dsCategory = null;
        string strScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["CatID"]) == "Add")
                {
                    trEdBs.Visible = false;
                    trCrBs.Visible = true;
                    fillcategory();
                    fillBrandNames();
                }
                else
                {
                    trCrBs.Visible = false;
                    trEdBs.Visible = true;

                    fillcategory();
                    drpCategory.SelectedValue = Convert.ToString(Request.QueryString["CatID"]);
                    fillBrandNames();
                    txtBrandSegment.Text = Convert.ToString(Request.QueryString["Brandname"]);
                    //lbBrandSegment.SelectedItem.Selected = Convert.ToString(Request.QueryString["Brandname")
                    lbBrandSegment.Items[lbBrandSegment.Items.IndexOf(lbBrandSegment.Items.FindByText(Convert.ToString(Request.QueryString["Brandname"])))].Selected = true;
                }
            }

        }
        private void fillcategory()
        {
            clsBrandSegmentBO objfillCategory = null;
            try
            {
                dsCategory = new DataSet();
                objfillCategory = new clsBrandSegmentBO();
                //dsCategory = objfillCategory.FillCategory;
                if (objfillCategory.FillCategory(ref dsCategory))
                {
                    if ((dsCategory != null))
                    {
                        if (!(dsCategory.Tables.Count == 0))
                        {
                            if (!(dsCategory.Tables[0].Rows.Count == 0))
                            {
                                drpCategory.DataSource = dsCategory.Tables[0];
                                drpCategory.DataTextField = "Category_Name";
                                drpCategory.DataValueField = "Category_ID";
                                drpCategory.DataBind();
                                drpCategory.Items.Insert(0, "--Select Category--");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsCategory = null;
                objfillCategory = null;
            }

        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillBrandNames();
            txtBrandSegment.Text = string.Empty;
        }

        private void fillBrandNames()
        {
            DataSet dsBrands = null;
            clsBrandSegmentBO objfillCategory = null;
            try
            {
                dsBrands = new DataSet();
                objfillCategory = new clsBrandSegmentBO();
                int intCategoryid;
                if (drpCategory.SelectedItem.Text == "--Select Category--")
                {
                    intCategoryid = -1;
                    txtBrandSegment.Text = string.Empty;
                }
                else
                {
                    intCategoryid = Convert.ToInt32(drpCategory.SelectedValue);
                }
                //if ()
                //{
                //    //dsBrands = objfillCategory.FillBrandByCategory(-1);
                //    if(objfillCategory.FillCategoryName(-1,ref dsBrands))
                //    txtBrandSegment.Text = string.Empty;
                //}
                //else
                //{
                //    dsBrands = objfillCategory.FillBrandByCategory(drpCategory.SelectedValue);
                //}

                if (objfillCategory.FillCategoryName(intCategoryid, ref dsBrands))
                {
                    if ((dsBrands != null))
                    {
                        if (!(dsBrands.Tables.Count == 0))
                        {
                            if (!(dsBrands.Tables[0].Rows.Count == 0))
                            {
                                lbBrandSegment.DataSource = dsBrands;
                                lbBrandSegment.DataTextField = "Brand_Segment_Name";
                                lbBrandSegment.DataValueField = "Brand_Segment_ID";
                                lbBrandSegment.DataBind();
                                lbBrandSegment.Items.Insert(0, "--Select Brand Segment--");
                            }
                            else
                            {
                                dsBrands.Clear();
                                lbBrandSegment.DataSource = dsBrands;
                                lbBrandSegment.DataBind();
                            }
                        }
                        else
                        {
                            dsBrands.Clear();
                            lbBrandSegment.DataSource = dsBrands;
                            lbBrandSegment.DataBind();
                        }
                    }
                    else
                    {
                        dsBrands.Clear();
                        lbBrandSegment.DataSource = dsBrands;
                        lbBrandSegment.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                dsBrands = null;
                objfillCategory = null;
            }

        }

        protected void lbBrandSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBrandSegment.SelectedItem.Text == "--Select Brand Segment--")
            {
                txtBrandSegment.Text = string.Empty;
            }
            else
            {
                txtBrandSegment.Text = lbBrandSegment.SelectedItem.Text;
            }

        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {   
            if (Convert.ToString(Request.QueryString["CatID"]) == "Add")
            {
                InsertBrandSegments();
            }
            else
            {
                UpdateBrandSegments();
            }

        }

        public void InsertBrandSegments()
        {
            int intResults = 0;
            clsBrandSegmentBO objfillCategory = null;
            clsSecurity objclsSecurity = null;
            int intBrandSegID = 0;
            
            SqlParameter[] paramOut =   new SqlParameter[1];
            try
            {
                objfillCategory = new clsBrandSegmentBO();
                objclsSecurity = new clsSecurity();
                if ((lbBrandSegment.SelectedIndex == -1) ||(lbBrandSegment.SelectedItem.Text == "--Select Brand Segment--"))
                {
                    intBrandSegID = 0;
                }
                //else if (lbBrandSegment.SelectedItem.Text == "--Select Brand Segment--")
                //{
                //    intBrandSegID = 0;
                //}
                else
                {
                    intBrandSegID = Convert.ToInt32(lbBrandSegment.SelectedItem.Value);
                }

                int intCatID = Convert.ToInt32(drpCategory.SelectedValue);
                string strBrandName = txtBrandSegment.Text;
                string strStatus = "A";
                //string lsIdentityName = null;
                
                //lsIdentityName = System.Threading.Thread.CurrentPrincipal.Identity.Name();
                //string strUserName = Strings.Right(lsIdentityName, Strings.Len(lsIdentityName) - lsIdentityName.LastIndexOf("\\") - 1);
               
                //intResults = objfillCategory.UpdateBrandSegment(intBrandSegID, intCatID, strBrandName, strStstus, strUserName);
                if (objfillCategory.UpdateBrandSegment(intBrandSegID, intCatID, strBrandName, strStatus, objclsSecurity.UserName, ref paramOut))
                {
                    intResults = Convert.ToInt32(paramOut[0].Value);
                    if (intResults == 0)
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertSuccess") + "');window.navigate('../Administration/ViewBrandSegments.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertSuccess"] + "');window.location='../Administration/ViewBrandSegments.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "InsertSuccess", strScript);
                    }
                    else if (intResults == 1)
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertDuplicateError") + "');window.navigate('../Administration/ViewBrandSegments.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertDuplicateError"] + "');window.location='../Administration/ViewBrandSegments.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "InsertDuplicateError", strScript);
                    }
                    else
                    {
                        // script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertError") + "');window.navigate('../Administration/ViewBrandSegments.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertError"] + "');window.location='../Administration/ViewBrandSegments.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "InsertError", strScript);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsSecurity = null;
                objfillCategory = null;
                paramOut = null;
            }



        }
        public void UpdateBrandSegments()
        {
            int intResults = 0;
            clsBrandSegmentBO objfillCategory = null;
            SqlParameter[] paramOut = null;
            clsSecurity objclsSecurity=null;
            int intBrandSegID = 0;
            //= lbBrandSegment.SelectedItem.Value

            //if (lbBrandSegment.SelectedIndex == -1)
            if ((lbBrandSegment.SelectedIndex == -1) || (lbBrandSegment.SelectedItem.Text == "--Select Brand Segment--"))
            {
                intBrandSegID = 0;
            }
            //else if (lbBrandSegment.SelectedItem.Text == "--Select Brand Segment--")
            //{
            //    intBrandSegID = 0;
            //}
            else
            {
                intBrandSegID = Convert.ToInt32(lbBrandSegment.SelectedItem.Value);
            }

            try
            {
                objfillCategory = new clsBrandSegmentBO();
                paramOut = new SqlParameter[1];
                objclsSecurity=new clsSecurity();
                int intCatID = Convert.ToInt32(drpCategory.SelectedValue);
                string strBrandName = txtBrandSegment.Text;
                string strStatus = "A";
                //string lsIdentityName = null;
                //string script = null;
                //lsIdentityName = System.Threading.Thread.CurrentPrincipal.Identity.Name();
                //string strUserName = Strings.Right(lsIdentityName, Strings.Len(lsIdentityName) - lsIdentityName.LastIndexOf("\\") - 1);
                //intResults = objfillCategory.UpdateBrandSegment(intBrandSegID, intCatID, strBrandName, strStstus, strUserName);

                if (objfillCategory.UpdateBrandSegment(intBrandSegID, intCatID, strBrandName, strStatus, objclsSecurity.UserName, ref paramOut))
                {
                    intResults = Convert.ToInt32(paramOut[0].Value);
                    if (intResults == 0)
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateSuccess") + "');window.navigate('../Administration/ViewBrandSegments.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateSuccess"] + "');window.location='../Administration/ViewBrandSegments.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", strScript);
                    }
                    else if (intResults == 1)
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("InsertDuplicateError") + "');window.navigate('../Administration/ViewBrandSegments.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["InsertDuplicateError"] + "');window.location='../Administration/ViewBrandSegments.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "InsertDuplicateError", strScript);

                    }
                    else
                    {
                        //script = "<script>alert('" + ConfigurationSettings.AppSettings("UpdateError") + "');window.navigate('../Administration/ViewBrandSegments.aspx');</script>";
                        //Page.RegisterStartupScript("clientscript", script);
                        strScript = "<script>alert('" + ConfigurationManager.AppSettings["UpdateError"] + "');window.location='../Administration/ViewBrandSegments.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", strScript);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                objclsSecurity = null;
                objfillCategory = null;
                paramOut = null;
            }

        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewBrandSegments.aspx");
        }
    }
}