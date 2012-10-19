using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;

namespace MUREOUI.Common
{
    public partial class SystemOwners : System.Web.UI.Page
    {
        DataSet dsSystemOwner;
        Int32 returnvalue;
        string Script;

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillSystemOwners();
            }
        }


        private void FillSystemOwners()
        {
            dsSystemOwner = new DataSet();
            clsSystemOwnerBO objclsSystemOwnerBO = new clsSystemOwnerBO();
            //dsSystemOwner = BusinessObject.MUREO.BusinessObject.SystemOwner.FillSystemOwner();
            if (objclsSystemOwnerBO.FillSystemOwner(ref dsSystemOwner))
            {
                if (dsSystemOwner == null)
                {

                }
                else if (dsSystemOwner.Tables.Count == 0)
                {
                }
                else if (dsSystemOwner.Tables[0].Rows.Count == 0)
                {
                    dtgrdPurchaseContact.Visible = false;
                }
                else
                {
                    dtgrdPurchaseContact.DataSource = dsSystemOwner;
                    dtgrdPurchaseContact.DataBind();
                }
            }
        }
    }
}