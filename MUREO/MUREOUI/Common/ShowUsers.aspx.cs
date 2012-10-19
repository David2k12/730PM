using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;

namespace MUREOUI
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        int gintAdminCount;      
        protected string sContentType = "text/xml";
        protected string sMethod = "POST";
        protected int iTimeout = 200000;
        public int gintUserCount = 0;
        public int nodecount = 0;
        //-------------
        private const string HTTPContentType = "text/xml";
        private const string HTTPMethod = "GET";
        private const int HTTPTimeOut = 200000;     
        string strFirstLastName=string.Empty;

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here
            //get the Priveleges session
            //Session["SiteAdmin"] = "Surendra,Bolla";
            string lstrSiteAdmin = null;
            int lintAdminCount = 0;
            string[] arrPriveleges = null;
            lstrSiteAdmin = null;
            //if the logged in user is a site admin then get the No of priveleges
            if (!(lstrSiteAdmin == null))
            {
                int lintCountIndex = lstrSiteAdmin.LastIndexOf(",");
                //get the Number of Site Admin priveleges the logged in User is Having
                lintAdminCount = Convert.ToInt32(lstrSiteAdmin.Substring(lintCountIndex + 1));
                gintAdminCount = lintAdminCount;
                arrPriveleges = lstrSiteAdmin.Split(',');
            }
            if(Request.QueryString["ID"]!=null)
            {
            hdnUserName.Value=Convert.ToString(Request.QueryString["ID"]);
            }
            if (Request.QueryString["Hidd"] != null)
            {
                hdnStore.Value = Convert.ToString(Request.QueryString["Hidd"]);
            }
            
            if (!IsPostBack)
            {
                //Page.RegisterHiddenField("__EVENTTARGET", "btnLastGo")
                txtFirstName.Attributes.Add("onblur", "javascript: SetFocusonControl();");
                txtLastName.Attributes.Add("onblur", "javascript: SetFocusonControl();");
                lstUsers.Items.Clear();
                lstSelectedUsers.Items.Clear();
                ShowUsers("aa*");
                if (lstUsers.Items.Count == 0)
                {
                    lblTitle.Text = "No records found";
                }
                //code for reading the values from existing form and filling up the right hand side listbox.
                string strReadExistingNames = null;
                string[] strDivideString = null;
                if (Request.QueryString["ShowUserList"]!=null)
                strReadExistingNames = Request.QueryString["ShowUserList"];
                try
                {
                    strReadExistingNames = strReadExistingNames.Replace(";", ",");
                }
                catch (Exception ex)
                {
                }

                if (!string.IsNullOrEmpty(strReadExistingNames))
                {
                    strDivideString = strReadExistingNames.Split(new char[]{','}, strReadExistingNames.Length);

                    for (int i = 0; i <= strDivideString.Length - 1; i++)
                    {
                        lstSelectedUsers.Items.Insert(i, strDivideString[i]);
                    }
                }
            }
        }
        private void ShowUsers(string searchString)
        {
            try
            {
                ///'=========P&G=====
                string ReturnedData = null;
                HttpWebRequest HTTPObj = default(HttpWebRequest);
                HttpWebResponse HTTPResponse = default(HttpWebResponse);
                StreamReader srTemp = default(StreamReader);
                StreamWriter swTemp = default(StreamWriter);
                int i = 0;
                string LDAPURL = null;
                LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(givenName=" + searchString.Trim() + ")&xatr=ExtHandle,sn,givenName,uid";
                HTTPObj = (HttpWebRequest)WebRequest.Create(LDAPURL);
                HTTPObj.ContentType = HTTPContentType;
                HTTPObj.Method = HTTPMethod;
                HTTPObj.Timeout = HTTPTimeOut;
                HTTPObj.KeepAlive = false;
                HTTPResponse = (HttpWebResponse)HTTPObj.GetResponse();
                if (HTTPResponse.StatusCode != HttpStatusCode.OK)
                {
                    ReturnedData = String.Empty;
                }
                else
                {
                    srTemp = new System.IO.StreamReader(HTTPResponse.GetResponseStream());
                    ReturnedData = srTemp.ReadToEnd();
                    HTTPResponse.Close();
                }
                System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
                Userxmldocument.LoadXml(ReturnedData);
                XmlNodeList nodesUserName = default(XmlNodeList);
                XmlNodeList nodesMailID = default(XmlNodeList);
                XmlNodeList nodesSN = default(XmlNodeList);
                XmlNodeList node = default(XmlNodeList);
                node = Userxmldocument.GetElementsByTagName("node");
                int j = 0;
                int k = 0;
                int iInStr = 0;
                string[] strNameMail = null;
                //Dim strLastNameMail() As String
                string[] gstrName = null;
                string[] gstrTnumber = null;
                int iArrayLn = 0;
                bool bCheck = false;
                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList m_nodelist = default(XmlNodeList);
                XmlNodeList m_Childnodelist = default(XmlNodeList);
                XmlNode m_node = default(XmlNode);
                //Create the XML Document
                m_xmld = new XmlDocument();
                //Load the Xml file
                m_xmld.LoadXml(ReturnedData);
                //Server.MapPath("../login/XMLFile1.xml"))
                //Get the list of name nodes 
                m_nodelist = m_xmld.SelectNodes("/fetch-service/directory-entries/entry/attr");
                //Loop through the nodes
                int nodecount = 0;
                nodecount = m_nodelist.Count;
                int Childnodecount = 0;
                string strName = null;
                string[] strNameValue = new string[4];
                //Each m_node In m_nodelist
                for (j = 0; j <= nodecount-1; j++)
                {
                    if (i <= 3)
                    {
                        Array.Resize(ref strNameMail, iArrayLn + 1);
                        //ReDim Preserve strLastNameMail(iArrayLn) 'jagan

                        Array.Resize(ref gstrTnumber, iArrayLn + 1);
                        strName += m_nodelist[j].ChildNodes.Item(0).InnerText;
                        strNameValue[i] = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        if (i == 3)
                        {
                            //Response.Write(strName & "<br>")
                            gstrTnumber[iArrayLn] = strNameValue[0];
                            // strNameMail(iArrayLn) = strNameValue(2) & " " & strNameValue(1) & " (" & strNameValue(3) & ")"
                            //modified by abdul
                            string stt = Left(strNameValue[2], 1).ToUpper() + Mid(strNameValue[2], 1).ToLower() + " " + Left(strNameValue[1], 1).ToUpper() + Mid(strNameValue[1], 1).ToLower() + "-" + (strNameValue[3].Substring((strNameValue[3].IndexOf(".") + 1))).ToUpper();
                            if(!string.IsNullOrEmpty(stt))
                            strNameMail[iArrayLn] = stt;
                            //strLastNameMail(iArrayLn) = UCase(Left(strNameValue(2), 2)) & LCase(Mid(strNameValue(2), 1)) & " " & UCase(Left(strNameValue(1), 1)) & LCase(Mid(strNameValue(1), 2)) & "-" & (strNameValue(3).Substring((strNameValue(3).IndexOf(".") + 1))).ToUpper
                            iArrayLn = iArrayLn + 1;
                            bCheck = true;
                        }
                    }
                    else
                    {
                        i = -1;
                        strName = "";
                        j -= 1;
                    }
                    i += 1;
                }
                if ((bCheck == true))
                {
                    //Sorting alphabetically, based on first name
                    //strNameMail.Sort(strNameMail)
                    SortedList SLUsers = new SortedList();
                    for (j = 0; j < strNameMail.Length-1; j++)
                    {
                        if (!string.IsNullOrEmpty(strNameMail[j]))
                        SLUsers.Add(strNameMail[j], gstrTnumber[j]);
                    }

                    //For j = 0 To UBound(strLastNameMail)
                    //    SLUsers.Add(strLastNameMail(j), gstrTnumber(j))
                    //Next
                    //Filling the values in list box
                    for (j = 0; j <=strNameMail.Length-1; j++)
                    {
                        lstUsers.Items.Add(new ListItem(Convert.ToString(SLUsers.GetKey(j))));
                        lstUsers.Items[j].Value =Convert.ToString(SLUsers.GetByIndex(j));
                    }
                }
                lstSelectedUsers.Items.Clear();
                if (!this.Page.IsPostBack)
                {
                    //When the user click on the address book icon in the GBUContacts Edit page
                    if ((Request.QueryString["Gno"] == "1"))
                    {
                        string strGbu = null;
                        string[] strarrGbu = null;
                        strGbu = Session["storeHseTextVar"].ToString();
                        if (strGbu.Contains(";"))
                        {
                            strarrGbu =strGbu.Split(';');
                        }
                        if ((strarrGbu == null))
                        {
                            lstSelectedUsers.Items.Add(strGbu);
                        }
                        else
                        {
                            for (i = 0; i <= strarrGbu.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(strarrGbu[i]);
                            }
                        }
                    }
                    //Adding names in selected list box for project team
                    if ((Request.QueryString["no"] == "1"))
                    {
                        string[] sPreviousSeperated = null;
                        if ((!string.IsNullOrEmpty(Session["txtPTValue"].ToString())))
                        {
                            sPreviousSeperated = (Convert.ToString(Session["txtPTValue"])).Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                        //Adding names in selected list box for Who can edit
                    }
                    else if ((Request.QueryString["no"] == "2"))
                    {
                        string[] sPreviousSeperated = null;
                        // Session["txtWCEValue") = Request.QueryString["txtPTValueStr2")
                        if ((!string.IsNullOrEmpty(Session["txtWCEValue"].ToString())))
                        {
                            sPreviousSeperated = (Convert.ToString(Session["txtWCEValue"])).Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                        //Adding names in selected list box for Project Leader
                    }
                    else if ((Request.QueryString["no"] == "3"))
                    {
                        string[] sPreviousSeperated = null;
                        // Session["txtPLValue") = Request.QueryString["txtPTValueStr3")
                        if ((!string.IsNullOrEmpty(Session["txtPLValue"].ToString())))
                        {
                            sPreviousSeperated = (Convert.ToString(Session["txtPLValue"])).Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                        //Adding names in selected list box for approver
                    }
                    else if ((Request.QueryString["no"] == "5"))
                    {
                        string[] sPreviousSeperated = null;
                        //Session["txtAppValue") = Request.QueryString["txtPTValueStr5")
                        if ((!string.IsNullOrEmpty(Session["txtAppValue"].ToString())))
                        {
                            sPreviousSeperated = (Convert.ToString(Session["txtAppValue"])).Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                        //Adding names in selected list box for GBU HSE Resources
                    }
                    else if ((Request.QueryString["no"] == "4"))
                    {
                        string[] sPreviousSeperated = null;
                        string sLblTxtValue = "";
                        //Session["txtHRValue") = Request.QueryString["txtPTValueStr4")
                        if ((!string.IsNullOrEmpty(Session["txtHRValue"].ToString())))
                        {
                            sLblTxtValue = Session["txtHRValue"].ToString();
                        }
                        if ((!string.IsNullOrEmpty(sLblTxtValue)))
                        {
                            sPreviousSeperated = sLblTxtValue.Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                        //Adding names in selected list box for Site HSE Resources
                    }
                    else if ((Request.QueryString["no"] == "7"))
                    {
                        string[] sPreviousSeperated = null;
                        string sLblTxtValue = "";
                        Session["txtSiteHRValue"] = Request.QueryString["txtPTValueStr7"];
                        if ((!string.IsNullOrEmpty(Session["txtSiteHRValue"].ToString())))
                        {
                            sLblTxtValue = Session["txtSiteHRValue"].ToString();
                        }
                        if ((!string.IsNullOrEmpty(sLblTxtValue)))
                        {
                            sPreviousSeperated = sLblTxtValue.Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1 ; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                    }
                    else if ((Request.QueryString["no"].ToString() == "8"))
                    {
                        string[] sPreviousSeperated = null;
                        string sLblTxtValue = "";
                        Session["txtRegionHRValue"] = Request.QueryString["txtPTValueStr8"].ToString();
                        if ((!string.IsNullOrEmpty(Session["txtRegionHRValue"].ToString())))
                        {
                            sLblTxtValue = Session["txtRegionHRValue"].ToString();
                        }
                        if ((!string.IsNullOrEmpty(sLblTxtValue)))
                        {
                            sPreviousSeperated = sLblTxtValue.Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                    }
                    else if ((Request.QueryString["no"] == "9"))
                    {
                        string[] sPreviousSeperated = null;
                        string sLblTxtValue = "";
                        Session["txtCountryHRValue"] = Request.QueryString["txtPTValueStr9"];
                        if ((!string.IsNullOrEmpty(Session["txtCountryHRValue"].ToString())))
                        {
                            sLblTxtValue = Session["txtCountryHRValue"].ToString();
                        }
                        if ((!string.IsNullOrEmpty(sLblTxtValue)))
                        {
                            sPreviousSeperated = sLblTxtValue.Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1 ; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                        //Adding names in selected list box for originator
                    }
                    else if ((Request.QueryString["no"] == "6"))
                    {
                        string[] sPreviousSeperated = null;
                        //Session["txtOrValue") = Request.QueryString["txtPTValueStr6")
                        if ((!string.IsNullOrEmpty(Session["txtOrValue"].ToString())))
                        {
                            sPreviousSeperated = (Convert.ToString(Session["txtOrValue"])).Split(',');
                            for (i = 0; i <= sPreviousSeperated.Length-1; i++)
                            {
                                lstSelectedUsers.Items.Add(sPreviousSeperated[i]);
                            }
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected";
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }
        }
        private void btnNextList_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                int i = 0;
                int j = 0;
                bool bSelected = false;
                string sAllPLs = null;
                //= ""
                //If lstSelectedUsers.Items.Count = 1 Then
                //    Response.Write("<script>alert('You can select only one user')</script>")
                //    Return
                //Else
                for (i = 0; i <= lstUsers.Items.Count - 1; i++)
                {
                    if (lstUsers.Items[i].Selected)
                    {
                        bSelected = true;
                        string sPL = lstUsers.Items[i].Text.Trim();
                        int iParIndex = sPL.IndexOf("(");
                        if ((iParIndex > 0))
                        {
                            int iDotIndex = sPL.IndexOf(".");
                            if ((iDotIndex > 0))
                            {
                                string strFirstLastName = sPL.Substring(0, iParIndex).Trim();
                                string strAfterFirstDot = sPL.Substring(iDotIndex, sPL.Length - iDotIndex - 1).Trim();
                                sAllPLs += strFirstLastName.Trim() + strAfterFirstDot.Replace(".", "-").ToUpper().Trim();
                                for (j = 0; j <= lstSelectedUsers.Items.Count - 1; j++)
                                {
                                    if (string.IsNullOrEmpty(lstSelectedUsers.Items[j].Text))
                                    {
                                        lstSelectedUsers.Items.RemoveAt(j);
                                    }
                                    if (lstSelectedUsers.Items.Count > 0)
                                    {
                                        if ((lstSelectedUsers.Items[j].Text.Trim() == sAllPLs.Trim()))
                                        {
                                            Response.Write("<script>alert('Selected User(s) are already in the list');</script>");
                                            return;
                                        }
                                    }
                                }
                                lstSelectedUsers.Items.Add(sAllPLs.Trim());
                                sAllPLs = "";
                            }
                            else
                            {
                                sAllPLs += sPL.Trim();
                            }
                        }

                    }
                }
                // End If
                if (((Request.QueryString["no"] == "5") & (lstSelectedUsers.Items.Count == 1)))
                {
                    Response.Write("<script>alert('Please select only one user for Project Approver field')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }
        }       
        private string getEmail(string exthandle)
        {
            string UserName = "";
            string mailId = "";
            try
            {
                //exthandle = "peter.jp"
                ///'=========P&G=====
                string ReturnedData = null;
                HttpWebRequest HTTPObj = default(HttpWebRequest);
                HttpWebResponse HTTPResponse = default(HttpWebResponse);
                StreamReader srTemp = default(StreamReader);
                StreamWriter swTemp = default(StreamWriter);
                int i = 0;
                string LDAPURL = null;
                LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(ExtHandle=" + exthandle.Trim() + ")&xatr=mail,cn,initials";
                HTTPObj = (HttpWebRequest)WebRequest.Create(LDAPURL);
                HTTPObj.ContentType = HTTPContentType;
                HTTPObj.Method = HTTPMethod;
                HTTPObj.Timeout = HTTPTimeOut;
                HTTPObj.KeepAlive = false;
                HTTPResponse = (HttpWebResponse)HTTPObj.GetResponse();
                if (HTTPResponse.StatusCode != HttpStatusCode.OK)
                {
                    ReturnedData = String.Empty;
                }
                else
                {
                    srTemp = new System.IO.StreamReader(HTTPResponse.GetResponseStream());
                    ReturnedData = srTemp.ReadToEnd();
                    HTTPResponse.Close();
                }
                System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
                Userxmldocument.LoadXml(ReturnedData);
                XmlNodeList nodesUserName = default(XmlNodeList);
                XmlNodeList nodesMailID = default(XmlNodeList);
                XmlNodeList nodesSN = default(XmlNodeList);
                XmlNodeList node = default(XmlNodeList);
                node = Userxmldocument.GetElementsByTagName("node");
                int j = 0;
                int k = 0;
                int iInStr = 0;
                string[] strNameMail = null;
                string[] gstrName = null;
                string[] gstrTnumber = null;
                int iArrayLn = 0;
                bool bCheck = false;
                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList m_nodelist = default(XmlNodeList);
                XmlNodeList m_Childnodelist = default(XmlNodeList);
                XmlNode m_node = default(XmlNode);
                //Create the XML Document
                m_xmld = new XmlDocument();
                //Load the Xml file
                m_xmld.LoadXml(ReturnedData);
                //Server.MapPath("../login/XMLFile1.xml"))
                //Get the list of name nodes 
                m_nodelist = m_xmld.SelectNodes("/fetch-service/directory-entries/entry/attr");
                //Loop through the nodes
                int nodecount = 0;
                nodecount = m_nodelist.Count;
                int Childnodecount = 0;
                //For j = 0 To nodecount - 1 'Each m_node In m_nodelist
                if (nodecount == 3)
                {
                    mailId = m_nodelist[0].ChildNodes.Item(0).InnerText;
                    //   Session["SelMailID") = mailId
                    UserName = m_nodelist[1].ChildNodes.Item(0).InnerText + "-" + m_nodelist[2].ChildNodes.Item(0).InnerText;
                    Session["SelUserName"] = UserName;
                }
                else if (nodecount == 2)
                {
                    string cn = null;
                    string initials = null;
                    for (j = 0; j <= nodecount - 1; j++)
                    {
                        if (m_nodelist[j].Attributes.GetNamedItem("name").Value.Trim().ToUpper()== "MAIL")
                        {
                            mailId = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        }
                        else if (m_nodelist[j].Attributes.GetNamedItem("name").Value.Trim().ToUpper() == "CN")
                        {
                            cn = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        }
                        else if (m_nodelist[j].Attributes.GetNamedItem("name").Value.Trim().ToUpper() == "INITIALS")
                        {
                            initials = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        }
                    }
                    if (!string.IsNullOrEmpty(initials))
                    {
                        //UserName = m_nodelist[0].ChildNodes.Item(0).InnerText & "-" & m_nodelist(1).ChildNodes.Item(0).InnerText
                        UserName = cn + "-" + initials;
                    }
                    else
                    {
                        UserName = cn;
                    }
                    Session["SelUserName"] = UserName;
                }
                //Next
            }
            catch (System.Net.WebException ex)
            {
                //lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected"
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }
            return mailId;
        }

        private void btnRemove_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {

            try
            {
                bool bSelected = false;

                if ((lstSelectedUsers.Items.Count > 0))
                {
                    int i = 0;
                    for (i = 0; i <= lstSelectedUsers.Items.Count - 1; i++)
                    {
                        if (lstSelectedUsers.Items[i].Selected)
                        {
                            lstSelectedUsers.Items.RemoveAt(i);
                            bSelected = true;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }

                if ((bSelected == false))
                {
                    Response.Write("<script>alert('Please select a user from the list to remove')</script>");
                }

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }

        }

        private void btnRemoveAll_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            lstSelectedUsers.Items.Clear();
        }


        private void btnLastGo_Click(System.Object sender, System.Web.UI.ImageClickEventArgs e)
        {
            

        }


        private void SearchString(string strType, string strFirstName, string strLastName)
        {
            //lblTitle.Text = "Select User";
            //lstUsers.Items.Clear();


            //try
            //{
            //    string ReturnedData = null;
            //    HttpWebRequest HTTPObj = default(HttpWebRequest);
            //    HttpWebResponse HTTPResponse = default(HttpWebResponse);
            //    StreamReader srTemp = default(StreamReader);
            //    StreamWriter swTemp = default(StreamWriter);
            //    int i = 0;
            //    string LDAPURL = null;

            //    if ((strType.Trim() == "F"))
            //    {
            //        //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(givenname=" & strFirstName.Trim() & "*)&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
            //        //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(givenname=" & strFirstName.Trim() & "*)&attributes=givenname,sn,mail&scope=subtree"
            //        LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(givenName=" + strFirstName.Trim() + "*)&xatr=ExtHandle,sn,givenName,uid";
            //    }
            //    else if ((strType.Trim() == "L"))
            //    {
            //        //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(sn=" & strLastName.Trim() & "*)&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
            //        //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(sn=" & strLastName.Trim() & "*)&attributes=givenname,sn,mail&scope=subtree"
            //        LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(sn=" + strLastName.Trim() + "*)&xatr=ExtHandle,sn,givenName,uid";
            //    }
            //    else if ((strType.Trim() == "FL"))
            //    {
            //        //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(%26(givenname=" & strFirstName.Trim() & "*)(sn=" & strLastName.Trim() & "*))&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
            //        //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(%26(givenname=" & strFirstName.Trim() & "*)(sn=" & strLastName.Trim() & "*))&attributes=givenname,sn,mail&scope=subtree"
            //        LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=" + strFirstName.Trim() + "*)(sn=" + strLastName.Trim() + "*))&xatr=ExtHandle,sn,givenName,uid";
            //    }

            //    HTTPObj = (HttpWebRequest)WebRequest.Create(LDAPURL);
            //    HTTPObj.ContentType = HTTPContentType;
            //    HTTPObj.Method = HTTPMethod;
            //    HTTPObj.Timeout = HTTPTimeOut;
            //    HTTPObj.KeepAlive = false;

            //    HTTPResponse = (HttpWebResponse)HTTPObj.GetResponse();
            //    if (HTTPResponse.StatusCode != HttpStatusCode.OK)
            //    {
            //        ReturnedData = String.Empty;
            //    }
            //    else
            //    {
            //        srTemp = new System.IO.StreamReader(HTTPResponse.GetResponseStream());
            //        ReturnedData = srTemp.ReadToEnd();
            //        HTTPResponse.Close();
            //    }

            //    if ((ReturnedData.Trim().IndexOf("error code 4 - Sizelimit Exceeded") != -1))
            //    {
            //        lblTitle.Text = "Search result exceeded size limit, narrow your search criteria.";
            //        return;
            //    }

            //    System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
            //    Userxmldocument.LoadXml(ReturnedData);
            //    XmlNodeList nodesUserName = default(XmlNodeList);
            //    XmlNodeList nodesMailID = default(XmlNodeList);
            //    XmlNodeList nodesSN = default(XmlNodeList);
            //    XmlNodeList node = default(XmlNodeList);
            //    node = Userxmldocument.GetElementsByTagName("node");

            //    int j = 0;
            //    int k = 0;
            //    int iInStr = 0;
            //    int iDotPos = 0;
            //    string strName = null;
            //    string[] strNameMail = null;
            //    //Dim strLastNameMail() As String
            //    string[] gstrName = null;
            //    string[] gstrTnumber = null;

            //    int iArrayLn = 0;
            //    bool bCheck = false;

            //    XmlDocument m_xmld = default(XmlDocument);
            //    XmlNodeList m_nodelist = default(XmlNodeList);
            //    XmlNodeList m_Childnodelist = default(XmlNodeList);
            //    XmlNode m_node = default(XmlNode);
            //    //Create the XML Document
            //    m_xmld = new XmlDocument();
            //    //Load the Xml file
            //    m_xmld.LoadXml(ReturnedData);
            //    //Server.MapPath("../login/XMLFile1.xml"))
            //    //Get the list of name nodes 
            //    m_nodelist = m_xmld.SelectNodes("/fetch-service/directory-entries/entry/attr");
            //    //Loop through the nodes
            //    int nodecount = 0;
            //    nodecount = m_nodelist.Count;
            //    int Childnodecount = 0;
            //    //Dim strName As String
            //    string[] strNameValue = new string[4];

            //    //Each m_node In m_nodelist
            //    for (j = 0; j <= nodecount - 1; j++)
            //    {

            //        if (i <= 3)
            //        {
            //            Array.Resize(ref strNameMail, iArrayLn + 1);
            //            //ReDim Preserve strLastNameMail(iArrayLn)

            //            Array.Resize(ref gstrTnumber, iArrayLn + 1);

            //            //strName &= m_nodelist[j].ChildNodes.Item(0).InnerText
            //            strNameValue[i] = m_nodelist[j].ChildNodes.Item(0).InnerText;
            //            if (i == 3)
            //            {
            //                //Response.Write(strName & "<br>")
            //                gstrTnumber[iArrayLn] = strNameValue[0];
            //                //strNameMail(iArrayLn) = strNameValue(2) & " " & strNameValue(1) & " (" & strNameValue(3) & ")"
            //                //modified by abdul
            //                strNameMail[iArrayLn] = Left(strNameValue[2], 1).ToUpper() + Mid(strNameValue[2], 2).ToLower() + " " + Left(strNameValue[1], 1).ToUpper() + Mid(strNameValue[1], 2).ToLower() + "-" + (strNameValue[3].Substring((strNameValue[3].IndexOf(".") + 1))).ToUpper();
            //                //strLastNameMail(iArrayLn) = UCase(Left(strNameValue(2), 2)) & LCase(Mid(strNameValue(2), 1)) & " " & UCase(Left(strNameValue(1), 1)) & LCase(Mid(strNameValue(1), 2)) & "-" & (strNameValue(3).Substring((strNameValue(3).IndexOf(".") + 1))).ToUpper
            //                iArrayLn = iArrayLn + 1;
            //                bCheck = true;
            //            }


            //        }
            //        else
            //        {
            //            i = -1;
            //            strName = "";
            //            j -= 1;
            //        }
            //        i += 1;
            //    }

            //    if ((bCheck == true))
            //    {
            //        //Sorting alphabetically, based on first name
            //        //strNameMail.Sort(strNameMail)

            //        SortedList SLUsers = new SortedList();
            //        for (j = 0; j <= strNameMail.Length-1; j++)
            //        {
            //            SLUsers.Add(strNameMail[j], gstrTnumber[j]);
            //        }

            //        //For j = 0 To UBound(strLastNameMail)
            //        //    SLUsers.Add(strLastNameMail(j), gstrTnumber(j))
            //        //Next

            //        //Filling the values in list box
            //        for (j = 0; j <= strNameMail.Length-1; j++)
            //        {
            //            lstUsers.Items.Add(new ListItem(Convert.ToString(SLUsers.GetKey(j))));
            //            lstUsers.Items[j].Value =Convert.ToString(SLUsers.GetByIndex(j));
            //        }
            //    }

            //    if ((lstUsers.Items.Count == 0))
            //    {
            //        lblTitle.Text = "No match found with the search";
            //    }

            //}
            //catch (System.Net.WebException ex)
            //{
            //    lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected";
            //}
            //catch (Exception ex)
            //{
            //    //Response.Write(ex.ToString())
            //}

            lblTitle.Text = "Select User";
            lstUsers.Items.Clear();


            try
            {
                string ReturnedData = null;
                HttpWebRequest HTTPObj = default(HttpWebRequest);
                HttpWebResponse HTTPResponse = default(HttpWebResponse);
                StreamReader srTemp = default(StreamReader);
                StreamWriter swTemp = default(StreamWriter);
                int i = 0;
                string LDAPURL = null;

                //if ((strType.Trim() == "F"))
                //{
                //    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(givenname=" & strFirstName.Trim() & "*)&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
                //    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(givenname=" & strFirstName.Trim() & "*)&attributes=givenname,sn,mail&scope=subtree"
                //    LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(givenName=" + strFirstName.Trim() + "*)&xatr=ExtHandle,sn,givenName,uid";
                //}
                //else if ((strType.Trim() == "L"))
                //{
                //    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(sn=" & strLastName.Trim() & "*)&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
                //    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(sn=" & strLastName.Trim() & "*)&attributes=givenname,sn,mail&scope=subtree"
                //    LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(sn=" + strLastName.Trim() + "*)&xatr=ExtHandle,sn,givenName,uid";
                //}
                //else if ((strType.Trim() == "FL"))
                //{
                //    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(%26(givenname=" & strFirstName.Trim() & "*)(sn=" & strLastName.Trim() & "*))&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
                //    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(%26(givenname=" & strFirstName.Trim() & "*)(sn=" & strLastName.Trim() & "*))&attributes=givenname,sn,mail&scope=subtree"
                //    LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=" + strFirstName.Trim() + "*)(sn=" + strLastName.Trim() + "*))&xatr=ExtHandle,sn,givenName,uid";
                //}

                if ((strType.Trim() == "F"))
                {
                    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(givenname=" & strFirstName.Trim() & "*)&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
                    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(givenname=" & strFirstName.Trim() & "*)&attributes=givenname,sn,mail&scope=subtree"
                    LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(givenName=" + strFirstName.Trim() + "*)&xatr=ExtHandle,sn,givenName,uid";
                }
                else if ((strType.Trim() == "L"))
                {
                    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(sn=" & strLastName.Trim() & "*)&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
                    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(sn=" & strLastName.Trim() & "*)&attributes=givenname,sn,mail&scope=subtree"
                    LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(sn=" + strLastName.Trim() + "*)&xatr=ExtHandle,sn,givenName,uid";
                }
                else if ((strType.Trim() == "FL"))
                {
                    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(%26(givenname=" & strFirstName.Trim() & "*)(sn=" & strLastName.Trim() & "*))&attributes=givenname,sn,mail&context=ou=people,ou=pg,o=world"
                    //LDAPURL = "http://peoplefinder.internal.pg.com/GDSDataServlet.jrun?format=xml&filter=(%26(givenname=" & strFirstName.Trim() & "*)(sn=" & strLastName.Trim() & "*))&attributes=givenname,sn,mail&scope=subtree"
                    LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=" + strFirstName.Trim() + "*)(sn=" + strLastName.Trim() + "*))&xatr=ExtHandle,sn,givenName,uid";
                }
                HTTPObj = (HttpWebRequest)WebRequest.Create(LDAPURL);
                HTTPObj.ContentType = HTTPContentType;
                HTTPObj.Method = HTTPMethod;
                HTTPObj.Timeout = HTTPTimeOut;
                HTTPObj.KeepAlive = false;

                HTTPResponse = (HttpWebResponse)HTTPObj.GetResponse();
                if (HTTPResponse.StatusCode != HttpStatusCode.OK)
                {
                    ReturnedData = string.Empty;
                }
                else
                {
                    srTemp = new System.IO.StreamReader(HTTPResponse.GetResponseStream());
                    ReturnedData = srTemp.ReadToEnd();
                    HTTPResponse.Close();
                }

                if ((ReturnedData.Trim().IndexOf("error code 4 - Sizelimit Exceeded") != -1))
                {
                    lblTitle.Text = "Search result exceeded size limit, narrow your search criteria.";
                    return;
                }

                System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
                Userxmldocument.LoadXml(ReturnedData);
                XmlNodeList nodesUserName = default(XmlNodeList);
                XmlNodeList nodesMailID = default(XmlNodeList);
                XmlNodeList nodesSN = default(XmlNodeList);
                XmlNodeList node = default(XmlNodeList);
                node = Userxmldocument.GetElementsByTagName("node");

                int j = 0;
                int k = 0;
                int iInStr = 0;
                int iDotPos = 0;
                string strName = null;
                string[] strNameMail = null;
                //Dim strLastNameMail() As String
                string[] gstrName = null;
                string[] gstrTnumber = null;

                int iArrayLn = 0;
                bool bCheck = false;

                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList m_nodelist = default(XmlNodeList);
                XmlNodeList m_Childnodelist = default(XmlNodeList);
                XmlNode m_node = default(XmlNode);
                //Create the XML Document
                m_xmld = new XmlDocument();
                //Load the Xml file
                m_xmld.LoadXml(ReturnedData);
                //Server.MapPath("../login/XMLFile1.xml"))
                //Get the list of name nodes 
                m_nodelist = m_xmld.SelectNodes("/fetch-service/directory-entries/entry/attr");
                //Loop through the nodes
                int nodecount = 0;
                nodecount = m_nodelist.Count;
                int Childnodecount = 0;
                //Dim strName As String
                string[] strNameValue = new string[4];

                //Each m_node In m_nodelist
                for (j = 0; j <= nodecount - 1; j++)
                {

                    if (i <= 3)
                    {
                        Array.Resize(ref strNameMail, iArrayLn + 1);
                        //ReDim Preserve strLastNameMail(iArrayLn)

                        Array.Resize(ref gstrTnumber, iArrayLn + 1);

                        //strName &= m_nodelist[j].ChildNodes.Item(0).InnerText
                        strNameValue[i] = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        if (i == 3)
                        {
                            //Response.Write(strName & "<br>")
                            gstrTnumber[iArrayLn] = strNameValue[0];
                            //strNameMail(iArrayLn) = strNameValue(2) & " " & strNameValue(1) & " (" & strNameValue(3) & ")"
                            //modified by abdul
                            //strNameMail[iArrayLn] = Left(strNameValue[2], 1).ToUpper() + Mid(strNameValue[2], 2).ToLower() + " " + Left(strNameValue[1], 1).ToUpper() + Mid(strNameValue[1], 2).ToLower() + "-" + (strNameValue[3].Substring((strNameValue[3].IndexOf(".") + 1))).ToUpper();

                            strNameMail[iArrayLn] =Left(strNameValue[2], 1).ToUpper() + Mid(strNameValue[2], 1).ToLower() + " " + Left(strNameValue[1], 1).ToUpper() + Mid(strNameValue[1], 1).ToLower() + "-" + (strNameValue[3].Substring((strNameValue[3].IndexOf(".") + 1))).ToUpper();
                            //strLastNameMail(iArrayLn) = UCase(Left(strNameValue(2), 2)) & LCase(Mid(strNameValue(2), 1)) & " " & UCase(Left(strNameValue(1), 1)) & LCase(Mid(strNameValue(1), 2)) & "-" & (strNameValue(3).Substring((strNameValue(3).IndexOf(".") + 1))).ToUpper
                            iArrayLn = iArrayLn + 1;
                            bCheck = true;
                        }


                    }
                    else
                    {
                        i = -1;
                        strName = "";
                        j -= 1;
                    }
                    i += 1;
                }

                if ((bCheck == true))
                {
                    //Sorting alphabetically, based on first name
                    //strNameMail.Sort(strNameMail)

                    SortedList SLUsers = new SortedList();
                    for (j = 0; j <= strNameMail.Length-1; j++)
                    {
                        SLUsers.Add(strNameMail[j], gstrTnumber[j]);
                    }

                    //For j = 0 To UBound(strLastNameMail)
                    //    SLUsers.Add(strLastNameMail(j), gstrTnumber(j))
                    //Next

                    //Filling the values in list box
                    for (j = 0; j <= strNameMail.Length-1; j++)
                    {
                        lstUsers.Items.Add(new ListItem(Convert.ToString(SLUsers.GetKey(j))));
                        lstUsers.Items[j].Value =Convert.ToString(SLUsers.GetByIndex(j));
                    }
                }

                if ((lstUsers.Items.Count == 0))
                {
                    lblTitle.Text = "No match found with the search";
                }

            }
            catch (System.Net.WebException ex)
            {
                lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected";
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }


        }

        protected void SearchByFirstName()
        {
            if (this.txtFirstName.Text != string.Empty)
            {
                lstUsers.Items.Clear();
                SearchString("F", this.txtFirstName.Text, "");
            }
        }

        protected void SearchByLastName()
        {
            if (this.txtLastName.Text != string.Empty)
            {
                SearchString("L", "", this.txtLastName.Text);
            }
        }

        private void txtFirstName_TextChanged(object sender, System.EventArgs e)
        {
            //Page.RegisterStartupScript("clientscript", "<script>document.getElementById('txtFirstName').focus();</script>")
            if (txtFirstName.Text.ToUpper() == "NULL" || txtFirstName.Text.ToUpper() == "NULL")
            {
                string script = null;
                script = "<script>alert('System cannot search using the given text as they are keywords');</script>";                
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                return;
            }
            SearchByFirstName();
            if (this.txtFirstName.Text != string.Empty & this.txtLastName.Text != string.Empty)
            {
                SearchString("FL", this.txtFirstName.Text, this.txtLastName.Text);
            }
            //Page.RegisterStartupScript("clientscript", "<script>document.getElementById('btnLastGo').focus();</script>")
        }

        private void txtLastName_TextChanged(object sender, System.EventArgs e)
        {
            // Page.RegisterStartupScript("clientscript", "<script>document.getElementById('txtLastName').focus();</script>")
            if (txtLastName.Text.ToUpper() == "NULL" || txtLastName.Text.ToUpper() == "NULL")
            {
                string script = null;
                script = "<script>alert('System cannot search using the given text as they are keywords');</script>";                
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                return;
            }
            SearchByLastName();
            if (this.txtFirstName.Text != string.Empty & this.txtLastName.Text != string.Empty)
            {
                SearchString("FL", this.txtFirstName.Text, this.txtLastName.Text);
            }
            // Page.RegisterStartupScript("clientscript", "<script>document.getElementById('btnLastGo').focus();</script>")
        }


        private void lstUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }






        private void Button2_Click(System.Object sender, System.EventArgs e)
        {
        }

       


       



        public string Left(string s, int len)
        {
            if (s == null)
                return s;
            else if (len == 0 || s.Length == 0)
                return "";
            else if (s.Length <= len)
                return s;
            else
                return s.Substring(0, len);
        }

        public string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }

        protected void imdAdd_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                int i = 0;
                int j = 0;
                bool bSelected = false;
                bool bAlreadySelected = false;
                //Dim oneNotSelected As Boolean = False
                string sAllPLs = null;
                //= ""
                //If lstSelectedUsers.Items.Count = 1 Then
                //    Response.Write("<script>alert('You can select only one user')</script>")
                //    Return
                //Else
                //For i = 0 To lstUsers.Items.Count - 1
                //    If lstUsers.Items[i].Selected = False Then
                //        oneNotSelected = True
                //    Else
                //        oneNotSelected = False
                //    End If
                //Next
                //If oneNotSelected = True Then
                //    Dim script As String
                //    script = "<script>alert('Please select a user.');</script> "
                //    Page.RegisterStartupScript("clientscript", script)
                //    Exit Sub
                //End If
                if (lstUsers.SelectedIndex < 0)
                {
                    string script = null;
                    script = "<script>alert('Please select atleast one user');</script> ";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    //Response.Write("<script>alert('You can select only one user')</script>")
                    return;
                }

                for (i = 0; i <= lstUsers.Items.Count - 1; i++)
                {
                    for (j = 0; j <= lstSelectedUsers.Items.Count - 1; j++)
                    {
                        if (lstUsers.Items[i].Selected == true)
                        {
                            if (lstUsers.Items[i].Text == lstSelectedUsers.Items[j].Text)
                            {
                                bAlreadySelected = true;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                }

                if (bAlreadySelected == true)
                {
                    string script = null;
                    script = "<script>alert('user already selected.');</script> ";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    return;
                }

                for (i = 0; i <= lstUsers.Items.Count - 1; i++)
                {
                    if (lstUsers.Items[i].Selected)
                    {
                        bSelected = true;
                        string sPL = lstUsers.Items[i].Text.Trim();
                        int iParIndex = sPL.IndexOf("(");
                        if ((iParIndex > 0))
                        {
                            int iParIndexEnd = sPL.IndexOf(")");

                            //Dim exthandle As String = sPL.Substring(iParIndex)
                            //sPL.Substring(iParIndex + 1, sPL.Length - iParIndex - 2).Trim()
                            int iDotIndex = sPL.IndexOf(")");
                            if ((iDotIndex > 0))
                            {
                                //Dim strFirstLastName As String = sPL.Substring(iParIndex + 1, sPL.Length - iParIndex - 2).Trim()
                                //Dim strFirstLastName As String = sPL.Substring(iParIndex + 1, sPL.Length - iParIndex - 2).Trim()
                                //Dim strFirstLastName As String = sPL.Substring(0, iParIndex).Trim()
                                string strFirstLastName = sPL;

                                Session["strFirstLastName"] = strFirstLastName;
                                sAllPLs += strFirstLastName.Trim();
                                for (j = 0; j <= lstSelectedUsers.Items.Count - 1; j++)
                                {
                                    if (string.IsNullOrEmpty(lstSelectedUsers.Items[j].Text))
                                    {
                                        lstSelectedUsers.Items.RemoveAt(j);
                                    }
                                    if (lstSelectedUsers.Items.Count > 0)
                                    {
                                        if ((lstSelectedUsers.Items[j].Text.Trim() == sAllPLs.Trim()))
                                        {
                                            string script = null;
                                            script = "<script>alert('Selected item is already in the list');</script> ";
                                            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                                            //Response.Write("<script>alert('Selected item is already in the list');</script>")
                                            return;
                                        }
                                    }
                                }
                                lstSelectedUsers.Items.Add(sAllPLs.Trim());
                                sAllPLs = "";
                            }
                            else
                            {
                                string[] sName = sPL.Split('(');
                                sPL = sName[0];
                                lstSelectedUsers.Items.Add(sPL.Trim());
                                sAllPLs += sPL.Trim();
                            }
                        }
                        else
                        {
                            lstSelectedUsers.Items.Add(sPL.Trim());
                        }
                    }
                }
                // End If
                if (((Request.QueryString["no"] == "5") & (lstSelectedUsers.Items.Count == 1)))
                {
                    string script = null;
                    script = "<script>alert('You can select only one user for Project Approver field');</script> ";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    //Response.Write("<script>alert('You can select only one user for Project Approver field')</script>")
                    return;
                }

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }
        }

        protected void imgRemove_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                //int i = 0;
                if (lstSelectedUsers.SelectedIndex < 0)
                {
                    string script = null;
                    script = "<script>alert('Please select atleast one user');</script> ";
                    ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                    return;
                }
                for (int i = lstSelectedUsers.Items.Count - 1; i >= 0; i--)
                {
                    lstSelectedUsers.Items.Remove(lstSelectedUsers.SelectedItem);
                }
                lstSelectedUsers.SelectedIndex = -1;
                lstUsers.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString())
            }
        }

        protected void btnLastGo_Click1(object sender, ImageClickEventArgs e)
        {
            if (txtFirstName.Text.ToUpper() == "NULL" || txtFirstName.Text.ToUpper() == "NULL" || txtLastName.Text.ToUpper() == "NULL" || txtLastName.Text.ToUpper() == "NULL")
            {
                string script = null;
                script = "<script>alert('System cannot search using the given text as they are keywords');</script>";
                ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                return;
            }
            if (((string.IsNullOrEmpty(txtFirstName.Text.Trim())) & (string.IsNullOrEmpty(txtLastName.Text.Trim()))))
            {
                Response.Write("<script>alert('Enter first name or last name to search for');</script>");
                return;
            }

            //'Calling sub to search with last name/first name
            if (((!string.IsNullOrEmpty(txtFirstName.Text.Trim())) & (!string.IsNullOrEmpty(txtLastName.Text.Trim()))))
            {
                SearchString("FL", txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            }
            else if ((!string.IsNullOrEmpty(txtFirstName.Text.Trim())))
            {
                SearchString("F", txtFirstName.Text.Trim(), "");
            }
            else if ((!string.IsNullOrEmpty(txtLastName.Text.Trim())))
            {
                SearchString("L", "", txtLastName.Text.Trim());
            }
        }

        protected void btnSubmit_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                //lstSelectedUsers.Items.Add("Timothy Vara-TR-1")
                //lstSelectedUsers.Items.Insert(1, "Timothy Vara-TR-2")
                if (lstSelectedUsers.Items.Count == 0)
                {
                    //Response.Write("<script>alert('Please Select a UserName');window.navigate('ShowUsers.aspx')</script>")
                    string script1 = null;
                    script1 = "<script>alert('Please Select a UserName');</script>";
                    ClientScript.RegisterStartupScript(GetType(),"clientscript", script1);
                }
                string strNames = string.Empty;
                string strCorrectedNames = null;
                int intCorrectedNameLen = 0;
                string strNamesGbu = string.Empty;
                int i = 0;
                int intChrCount = 0;
                int j = 0;
                string s1 = null;
                string s0 = null;
                string s2 = null;
                string s = null;
                for (i = 0; i <= lstSelectedUsers.Items.Count - 1; i++)
                {
                    j = 0;
                    strNames = lstSelectedUsers.Items[i].Text;
                    if (!(strNames == string.Empty))
                    {
                        strCorrectedNames = strNames;
                        intCorrectedNameLen = strCorrectedNames.Length;
                        for (intChrCount = 0; intChrCount <= intCorrectedNameLen - 1; intChrCount++)
                        {
                            char ch = '\0';
                            ch = strCorrectedNames[intChrCount];
                            if (Convert.ToString(ch) == "-")
                            {
                                j = j + 1;
                            }
                        }
                        if (j > 1)
                        {
                            s0 = strNames.Substring(0, strNames.LastIndexOf("-"));
                            s1 = strNames.Substring(strNames.LastIndexOf("-"));
                            s1 = s1.Replace("-", ".");
                            s2 = s0 + s1;
                            strNames = s2;
                        }
                    }

                    if (i == 0)
                    {
                        s = strNames;
                    }
                    else
                    {
                        s = s + "," + strNames;
                    }

                    //If strNames = String.Empty Then
                    //    strNames = lstSelectedUsers.Items[i].Text
                    //    Dim iParIndex As Integer = strNames.IndexOf("(")
                    //    'Modified by abdul
                    //    If Not iparindex = -1 Then
                    //        strNames = strNames.Substring(0, iParIndex).Trim()
                    //    End If
                    //Else
                    //    Dim iParIndex As Integer = lstSelectedUsers.Items[i].Text.IndexOf("(")
                    //    'Modified by abdul
                    //    If Not iparIndex = -1 Then
                    //        strNames = strNames & "," & lstSelectedUsers.Items[i].Text.Substring(0, iParIndex).Trim()
                    //    Else
                    //        strNames = strNames & "," & lstSelectedUsers.Items[i].Text
                    //    End If
                    //End If
                }
                //string script = null;
                //script = "<script> var o = new Object();  o.forename ='"+s+"'; window.returnValue = o;";
                //script = script + "window.close(); </script>";
                //ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
                if (!string.IsNullOrEmpty(s))
                {
                    string strScript = "<script> window.opener.document.forms(0)." + hdnUserName.Value + ".value = '";
                    strScript += s + "';";
                    strScript += "window.opener.document.forms(0)." + hdnStore.Value + ".value = '";
                    strScript += s + "';";
                    strScript += " window.close();";
                    strScript += "</" + "script>";
                    ClientScript.RegisterClientScriptBlock(typeof(Page), "anything", strScript);
                }
            }
            catch (Exception ex)
            {
                // Response.Write(ex.ToString())
            }
        }

        protected void imgCancel_Click1(object sender, ImageClickEventArgs e)
        {
            string script = null;
            script = "<script>window.returnValue ='';";
            script = script + "window.close(); </script>";
            ClientScript.RegisterStartupScript(GetType(), "clientscript", script);
        }

    }
}