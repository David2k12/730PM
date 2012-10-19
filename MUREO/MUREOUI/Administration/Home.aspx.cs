using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUREOUI.Administration
{
    public partial class Home : System.Web.UI.Page
    {
        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
        }

       

        //private void maintainConcurrenceGrups_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("../Administration/MaintainConcurrenceGroup.aspx");
        //}

      

        protected void maintainApproverNames_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewApprovers.aspx");
        }

        protected void maintainApproverGroups_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewApprovalGroup.aspx");
        }

        protected void maintainBudgetCenters_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewBudgetCenters.aspx");
        }

        protected void maintaineoScopeOptions_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewEOScopeOptions.aspx");
        }

        protected void maintainDataCoordinatorName_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewDataCoordinators.aspx");
        }

        protected void maintainPurchasingContacts_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/MaintainPurchasingContacts.aspx");
        }

        protected void maintainConcGrp_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/MaintainConcurrenceGroup.aspx");
        }

        protected void ViewCancelEO_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Reports/CancelledEOs.aspx");
        }

        protected void maintainSystemOwners_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/MaintainSystemOwner.aspx");
        }

        protected void maintainOnrouteFyi_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewOnRouteFYI.aspx");
        }

        protected void maintainPrescreenGroups_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewPreScreenerGroup.aspx");
        }

        protected void maintainCoachingBox_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewCoachingBoxes.aspx");
        }

        protected void maintainBasicInfo_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewBasicInfo.aspx");
        }

        protected void maintainBrandSegment_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewBrandSegments.aspx");
        }

        protected void maintainPaperMachine_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewPaperMachine.aspx");
        }

        protected void maintainConvertingMachine_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ViewCategories.aspx");
        }

        protected void lockedEOs_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/LockEos.aspx");
        }

        protected void Imagebutton1_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ChangeOriginator.aspx");
        }

        protected void Imagebutton2_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Administration/ChangeDistributionList.aspx");
        }

        

    }
}