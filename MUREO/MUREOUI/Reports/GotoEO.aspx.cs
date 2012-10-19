using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MUREOBAL;

namespace MUREOUI.Reports
{
    public partial class GotoEO : System.Web.UI.Page
    {
        DataSet dsEONumber;
        EOBA objEOBA = new EOBA();

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                FillEONumbers();
            }
        }

        public void NoDataForDropDown()
        {
            dynamic strJavascript = null;
            strJavascript = "<script>alert('" + ConfigurationSettings.AppSettings["NoRecords"] + "')</script>";
            Page.RegisterStartupScript("clientscript", strJavascript);
        }

        public void FillEONumbers()
        {
            dsEONumber = new DataSet();
            //dsEONumber = ClsMyEOs.FetchEONumbers();
            if (objEOBA.FetchEONumbers(ref dsEONumber))
            {
                if (dsEONumber == null)
                {
                    NoDataForDropDown();
                    drpEONumber.Items.Insert(0, "None");
                    drpEONumber.Items[0].Value = "0";
                    return;
                }
                else if (dsEONumber.Tables.Count == 0)
                {
                    NoDataForDropDown();
                    drpEONumber.Items.Insert(0, "None");
                    drpEONumber.Items[0].Value = "0";
                    return;
                }
                else if (dsEONumber.Tables[0].Rows.Count == 0)
                {
                    NoDataForDropDown();
                    drpEONumber.Items.Insert(0, "None");
                    drpEONumber.Items[0].Value = "0";
                    return;
                }
                else
                {
                    drpEONumber.DataSource = dsEONumber.Tables[0].DefaultView;
                    drpEONumber.DataTextField = "EO_Number";
                    drpEONumber.DataValueField = "EO_ID";
                    drpEONumber.DataBind();
                    drpEONumber.Items.Insert(0, "Please select your EO Number");
                    drpEONumber.Items[0].Value = "0";
                }
            }
        }

       protected void imgOpenEOEdit_Click(object sender, ImageClickEventArgs e)
        {
            if (drpEONumber.SelectedIndex == 0)
            {
                Page.RegisterStartupScript("clientscript", "<script>alert('Please select an EO Number');</script>");
            }
            else
            {
                dsEONumber = new DataSet();
                //dsEONumber = ClsMyEOs.FetchEONumbers();
                if (objEOBA.FetchEONumbers(ref dsEONumber))
                {
                    string strEONumber = null;
                    string strEOType = null;
                    int intEOID = 0;
                    strEONumber = drpEONumber.SelectedItem.Text;

                    foreach (DataRow dr in dsEONumber.Tables[0].Rows)
                    {
                        if (strEONumber == Convert.ToString(dr[1]))
                        {
                            strEOType = Convert.ToString(dr[2]);
                            intEOID = Convert.ToInt32(drpEONumber.SelectedValue);
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    if (strEOType.ToUpper() == "E")
                    {
                        string script = null;
                        script = "<script>window.open('../Common/NewEO.aspx?From=ForEOEdit&EOID=" + intEOID + "','EditEO','');window.close();</script>";
                        Page.RegisterStartupScript("clientscript", script);
                        //Response.Redirect(String.Format("../Common/NewEO.aspx?From={0}&EOID={1}", "ForEOEdit", intEOID))
                    }
                    else
                    {
                        string script = null;
                        script = "<script>window.open('../Common/SiteTest.aspx?From=Edit&EOID=" + intEOID + "','EditSiteTest','');window.close();</script>";
                        Page.RegisterStartupScript("clientscript", script);
                        //Response.Redirect(String.Format("../Common/SiteTest.aspx?From={0}&EoID={1}", "EDIT", intEOID))
                    }
                }
            }
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            string script = null;
            script = "<script>window.returnValue ='' ;";
            script = script + "window.close(); </script>";
            Page.RegisterStartupScript("clientscript", script);
        }

        protected void imgEOReadOnly_Click(object sender, ImageClickEventArgs e)
        {
            if (drpEONumber.SelectedIndex == 0)
            {
                Page.RegisterStartupScript("clientscript", "<script>alert('Please select an EO Number');</script>");
            }
            else
            {
                //dsEONumber = ClsMyEOs.FetchEONumbers();
                if (objEOBA.FetchEONumbers(ref dsEONumber))
                {
                    string strEONumber = null;
                    string strEOType = null;
                    int intEOID = 0;
                    strEONumber = drpEONumber.SelectedItem.Text;
                    foreach (DataRow dr in dsEONumber.Tables[0].Rows)
                    {
                        if (strEONumber==Convert.ToString(dr[1]))
                        {
                            strEOType = Convert.ToString(dr[2]);
                            intEOID = Convert.ToInt32(drpEONumber.SelectedValue);
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    if (strEOType.ToUpper() == "E")
                    {
                        string script = null;
                        script = "<script>window.open('../Common/ViewEO.aspx?EO_ID=" + intEOID + "','ViewEO','');window.close();</script>";
                        Page.RegisterStartupScript("clientscript", script);

                        //Response.Redirect("../Common/ViewEO.aspx?EO_ID=" + intEOID.ToString())
                    }
                    else
                    {
                        string script = null;
                        script = "<script>window.open('../Common/ViewSiteTest.aspx?EoID=" + intEOID + "','ViewSiteTest','');window.close();</script>";
                        Page.RegisterStartupScript("clientscript", script);

                        //Response.Redirect(String.Format("../Common/ViewSiteTest.aspx?EoID={0}", intEOID))
                    }
                }
            }
        }

    }
}