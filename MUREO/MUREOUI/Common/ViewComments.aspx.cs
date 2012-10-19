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
    public partial class ViewComments : System.Web.UI.Page
    {
        DataSet dsComments = null;
        int EOID = 0;
        EOBA objEOBA = new EOBA();
        clsSecurity objSecurity = new clsSecurity();
        SqlParameter[] paramOut = null;

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            btnAddComment.Attributes.Add("onClick", "javascript:return AddComment();");
            if (Request.QueryString["EOID"] != null)
            {
                EOID = Convert.ToInt32(Request.QueryString["EOID"]);
            }

            if (!Page.IsPostBack)
            {
                getEOComments();
            }
        }

        private void addComment(string comments)
        {
            if (!string.IsNullOrEmpty(comments.Trim()))
            {
                //objClsEO.addEOComments(EOID, comments, System.Security.UserName);
                if (objEOBA.addEOCommentsTest(EOID, comments, objSecurity.UserName, ref paramOut))
                {

                }
            }
            getEOComments();
        }
        private void getEOComments()
        {
            dsComments = new DataSet();
            //dsComments = objClsEO.getEOComments(EOID);
            if (objEOBA.getEOComments(EOID, ref dsComments))
            {
                if ((dsComments != null) & dsComments.Tables[0].Rows.Count > 0)
                {
                    dgComments.DataSource = dsComments;
                    dgComments.DataBind();
                }
            }
        }

       protected void dgComments_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblUser = (Label)e.Item.FindControl("lblUser");
                lblUser.Text = "Created By " + dsComments.Tables[0].Rows[e.Item.ItemIndex]["Created_By"] + " On " + dsComments.Tables[0].Rows[e.Item.ItemIndex]["Created_Date"];
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            string comments = hdComments.Value;
            addComment(comments);
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            getEOComments();
        }
       
    }
}