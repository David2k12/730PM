using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;
using System.Data.SqlClient;

namespace MUREOUI.Administration
{
    public partial class LockEos : System.Web.UI.Page
    {
        DataSet dsLockedEos;
        //BusinessObject.MUREO.BusinessObject.ClsEO objClsEo = new BusinessObject.MUREO.BusinessObject.ClsEO();
        int rowCount;
        string EoIdList;
        string script;
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;

        private void Page_Load(object sender, EventArgs e)
        {
            //Page.SmartNavigation = true;
            if (!Page.IsPostBack)
            {
                FillLockedEOs();
            }
        }

        private void FillLockedEOs()
        {
            dsLockedEos = new DataSet();
            //dsLockedEos = objClsEo.GET_EO_Lock_Users();
            if (objEOBA.GET_EO_Lock_Users(ref dsLockedEos))
            {

                if (dsLockedEos == null)
                {
                    NoRecords();

                }
                else if (dsLockedEos.Tables.Count == 0)
                {
                    NoRecords();

                }
                else if (dsLockedEos.Tables[0].Rows.Count == 0)
                {
                    NoRecords();

                }
                else
                {
                    dtgrdLockEo.DataSource = dsLockedEos;
                    dtgrdLockEo.DataBind();
                }
            }
        }

        protected void NoRecords()
        {
            string script = "alert('" + ConfigurationManager.AppSettings["NoRecords"] + "'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
        }
      

        protected void lockedEOs_Click(object sender, ImageClickEventArgs e)
        {
            if (dtgrdLockEo.Items.Count > 0)
            {
                for (rowCount = 0; rowCount <= dtgrdLockEo.Items.Count - 1; rowCount++)
                {
                    CheckBox chkEoID = (CheckBox)dtgrdLockEo.Items[rowCount].FindControl("chkEoID");
                    if (chkEoID.Checked == true)
                    {
                        if (string.IsNullOrEmpty(EoIdList))
                        {
                            Label lblEoIDs = (Label)dtgrdLockEo.Items[rowCount].FindControl("lblEoIDs");
                            EoIdList = lblEoIDs.Text;
                        }
                        else
                        {
                            Label lblEoIDs = (Label)dtgrdLockEo.Items[rowCount].FindControl("lblEoIDs");
                            EoIdList = EoIdList + "," + lblEoIDs.Text;
                        }
                    }
                    else
                    {
                        //GrpIdList = ""
                    }
                }

                if (!string.IsNullOrEmpty(EoIdList))
                {
                    //int x = objClsEo.SET_EO_Lock_Release(EoIdList);
                    int result = 0;
                    paramOut = new SqlParameter[1];
                    if (objEOBA.SET_EO_Lock_Release(EoIdList, ref paramOut))
                    {
                        //result = Convert.ToInt32(paramOut[0].Value);
                        //Display insert success/failure message
                        if (result == 0)
                        {
                            script = "alert('" + ConfigurationManager.AppSettings["UnlockEo"] + "');window.location='../Administration/Home.aspx' ";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                        else
                        {
                            script = "alert('" + ConfigurationManager.AppSettings["UnlockEo"] + "');window.location='../Administration/Home.aspx' ";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);
                        }
                    }

                    /*if (x == 0)
                    {
                        script = "<script>alert('" + ConfigurationSettings.AppSettings["UnlockEo"] + "');window.navigate('../Administration/Home.aspx');</script>";
                        Page.RegisterStartupScript("clientscript", script);
                    }
                    else
                    {
                        script = "<script>alert('" + ConfigurationSettings.AppSettings["UnlockEo"] + "');window.navigate('../Administration/Home.aspx');</script>";
                        Page.RegisterStartupScript("clientscript", script);
                    }*/
                }
                else
                {
                   // script = "<script>alert('" + ConfigurationSettings.AppSettings["SelectEoID"] + "');</script>";
                    //Page.RegisterStartupScript("clientscript", script);

                    script = "alert('" + ConfigurationManager.AppSettings["SelectEoID"] + "'); ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "script", script, true);

                }
            }
        }

        protected void dtgrdLockEo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            //If delete command event
            if (e.CommandName == "EOTitle_Link")
            {
                Label lblEoIDs = (Label)dtgrdLockEo.Items[rowCount].FindControl("lblEoIDs");
                Response.Redirect("~/Common/ViewEO.aspx?EO_ID=" + lblEoIDs.Text.ToString());
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administration/Home.aspx");
        }

    }
}