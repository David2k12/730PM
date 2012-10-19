using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;

namespace MUREOUI.Administration
{
    public partial class ViewDataCoordinator : System.Web.UI.Page
    {
        string strScript = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here
            int CO_ID;
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["DO_ID"])=="")
                {
                    //string script = "<script>alert('" + ConfigurationSettings.AppSettings("ViewErr") + "Please select a data coordinator to view this form');window.location = 'ViewDataCoordinators.aspx';</script> ";
                    //Page.RegisterStartupScript("error", script);

                    strScript = "<script>alert('" + ConfigurationManager.AppSettings["ViewErr"] + "'+'Please select a data coordinator to view this form');window.location='ViewDataCoordinators.aspx';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "error", strScript);
                    return;
                }
                DataSet dsCO = null;
                ViewDataCoordinatorsBO objDataCoordinatorBO = null;
                try
                {
                    objDataCoordinatorBO = new ViewDataCoordinatorsBO();
                    dsCO = new DataSet();
                    CO_ID = Convert.ToInt32(Request.QueryString["DO_ID"]);
                    if (objDataCoordinatorBO.GetDataCoordinatorDetailsBO(CO_ID, ref dsCO))
                    {
                        if (dsCO == null)
                        {
                            NoRecords();
                        }
                        else if (dsCO.Tables.Count == 0)
                        {
                            NoRecords();
                        }
                        else if (dsCO.Tables[0].Rows.Count == 0)
                        {
                            NoRecords();
                        }
                        else
                        {
                            lblCategory.Text = Convert.ToString(dsCO.Tables[0].Rows[0]["Category_Name"]);
                            lblCo.Text = Convert.ToString(dsCO.Tables[0].Rows[0]["Data_Coordinator_Name"]);
                            lblPhone.Text = Convert.ToString(dsCO.Tables[0].Rows[0]["Phone_Number"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    objDataCoordinatorBO = null;
                    dsCO = null;
                }
            }

        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            string strCOID = Convert.ToString(Request.QueryString["DO_ID"]);
            if (strCOID != "")
            {
                Response.Redirect("~/Administration/EditDataCoordinator.aspx?CO_ID=" + Convert.ToInt32(strCOID));
            }
        }
        private void NoRecords()
        {
            strScript = "<script>alert('" + ConfigurationManager.AppSettings["NoRecords"] + "');</script> ";
            ClientScript.RegisterStartupScript(this.GetType(), "error_message", strScript);
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/ViewDataCoordinators.aspx");
        }
    }
}