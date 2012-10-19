using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MUREOBAL;
using System.Data;

namespace MUREOUI.Administration
{
    public partial class ViewBrandSegment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Response.Redirect("ViewBrandSegment.aspx?CatID=" & lblCategoryID.Text & "&Brandname=" & lnkbrandSegmentName.Text)
                clsBrandSegmentBO objBrandSegment = null;
                DataSet dsCatName = null;
                try
                {
                    objBrandSegment = new clsBrandSegmentBO();
                    dsCatName = new DataSet();
                    hdnCategoryID.Value = Convert.ToString(Request.QueryString["CatID"]);
                    hdnBrandName.Value = Convert.ToString(Request.QueryString["Brandname"]);

                    //txthdnCategoryID.Text = Convert.ToString(Request.QueryString["CatID"]);
                    //txthdnBrandName.Text = Convert.ToString(Request.QueryString["Brandname"]);

                    //dsCatName = objBrandSegment.FillCategoryName(Convert.ToInt32(Request.QueryString("CatID")));
                    if (objBrandSegment.FillCategoryName(Convert.ToInt32(Request.QueryString["CatID"]), ref dsCatName))
                    {
                        if (dsCatName == null)
                        {
                        }
                        else if (dsCatName.Tables.Count == 0)
                        {
                        }
                        else if (dsCatName.Tables[0].Rows.Count == 0)
                        {
                        }
                        else
                        {
                            lblCategory.Text = Convert.ToString(dsCatName.Tables[0].Rows[0]["Category_Name"]);
                            //lblBrandSegment.Text = txthdnBrandName.Text;
                            lblBrandSegment.Text = hdnBrandName.Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    objBrandSegment = null;
                    dsCatName = null;
                }
            }


        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/Administration/MaintainBrandSegments.aspx?CatID=" + txthdnCategoryID.Text + "&Brandname=" + lblBrandSegment.Text);
            Response.Redirect("~/Administration/MaintainBrandSegments.aspx?CatID=" + hdnCategoryID.Value + "&Brandname=" + lblBrandSegment.Text);
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewBrandSegments.aspx");
        }
    }
}