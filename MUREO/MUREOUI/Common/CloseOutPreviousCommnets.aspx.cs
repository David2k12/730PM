using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MUREOBAL;
using MUREOPROP;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mail;

namespace MUREOUI.Common
{
    public partial class CloseOutPreviousCommnets : System.Web.UI.Page
    {
        clsSecurity objSecurity = new clsSecurity();
        EOBA objEOBA = new EOBA();
        SqlParameter[] paramOut = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = null;
                string strcommets = string.Empty;

                if (objEOBA.GET_EO_Closeout(Convert.ToInt32(Request.QueryString["EOID"]), ref ds))
                {
                    if (!(ds == null))
                    {
                        if (!(ds.Tables.Count == 0))
                        {
                            if (!(ds.Tables[4].Rows.Count == 0))
                            {
                                if (!(ds.Tables[4].Rows[0]["Comments_Approvers"] == System.DBNull.Value))
                                {
                                    strcommets = ds.Tables[4].Rows[0]["Comments_Approvers"].ToString().Trim();
                                }
                            }
                        }
                    }
                    if (!(strcommets == ""))
                    {

                      
                        string[] str = null;
                        int i;
                        str = strcommets.Split('~');
                        for (i = 0; (i<= (str.Length - 1)); i++)
                        {
                            lblCloseOutPreviousCommnets.Text = (lblCloseOutPreviousCommnets.Text + ("<br>" + str[i]));
                        }
                    }
                    else
                    {
                        lblCloseOutPreviousCommnets.Text = "No comments exist";
                    }
                }


            }
            catch (Exception ex)
            {
            }
        }

     
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string script;
            script = "<script>window.close();</script>";
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
        }
    }
}