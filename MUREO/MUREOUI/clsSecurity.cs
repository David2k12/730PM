using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Net;
using System.Text;
using System.Globalization;

namespace MUREOUI.Common
{
    public class clsSecurity
    {
        #region " Global Variables "
        string lsEncryptTicket;
        private const string HTTPContentType = "text/xml";
        private const string HTTPMethod = "GET";
        private const int HTTPTimeOut = 20000000;
        string ReturnedData;
        HttpWebRequest HTTPObj;
        HttpWebResponse HTTPResponse;
        StreamReader srTemp;
        StreamWriter swTemp;
        string lsLDAPUrl;
        XmlDocument xmldocUser;
        XmlNodeList nodesUserName;
        XmlNodeList nodesMailID;
        XmlNodeList nodesSN;
        XmlNodeList node;
        bool lbReturn;
        string sessionId;
        StringBuilder adminType = new StringBuilder();
        string _lsLDAPUrl;
        string strUserData;
        bool bChkAuth;
        #endregion

        //**************************************************
        //Name   	    :	UserName 
        //Written BY	:	Srinivasachary.n
        //parameters    :	
        //Purpose	    :   To get Login user name.
        //Returns       :   Login User Name
        //Program Change History:
        //<Date>			   <Editor>	      	<Rev>		<Description>
        //05-15-09           Srinivasachary.n                 Created
        //'***************************************************

        public string UserName
        {
            get
            {
                string lsIdentityName = string.Empty;
                lsIdentityName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                return getUserFullName(lsIdentityName.Substring(lsIdentityName.LastIndexOf("\\") + 1).ToLower());
                // return lsIdentityName.Substring(lsIdentityName.LastIndexOf("\\") + 1).ToLower();
                // return "srinivasachary.ns";
                // return "shrivastava.as";
                // return "devineni.pd";
                // return "brown.m.64";
                // return "conde.s.1";
                // return "gade.ig";
                //return "Surendra Bolla-SU";
                // return "Nagendra Prasad-NA";
                // return "todorov.d";
                // return "Malone.d.2";
                // return "Jeffrey Chan-JJ";
            }
        }

        //****************************************************
        //Name   	    :	CurrentDomain 
        //Written BY	:	Srinivasachary.n
        //parameters   :	
        //Purpose	    :   To get Login user Domain.
        //Returns      :   Login User Name
        //Program Change History:
        //<Date>			   <Editor>	      	<Rev>		<Description>
        //05-15-09           Srinivasachary.n                 Created
        //'***************************************************

        private string CurrentDomain
        {
            get
            {
                string lsDomainName = null;
                lsDomainName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                return lsDomainName.Substring(0, lsDomainName.LastIndexOf("/"));
            }
        }

        //**************************************************
        //Name   	    :	UserRole 
        //Written BY	:	Srinivasachary.n
        //parameters    :	
        //Purpose	    :   To get Login user Role.
        //Returns       :   Login User Name
        //Program Change History:
        //<Date>			   <Editor>	      	<Rev>		<Description>
        //05-15-09           Srinivasachary.n                 Created
        //'***************************************************
        //public string UserRole()
        //{
        //    string functionReturnValue = null;
        //    string lsDomainName = null;
        //    lsDomainName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        //    lsDomainName = lsDomainName.Substring(0, lsDomainName.LastIndexOf("\\"));
        //    if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\FAMG-MUREO_Admin"))
        //    {
        //        functionReturnValue = "MUREO_Admin";
        //    }
        //    else if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\GXBG-CCT Vendors"))
        //    {
        //        functionReturnValue = "MUREO_Editors";
        //    }
        //    else if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\GXBG-Customs Compliance Users"))
        //    {
        //        functionReturnValue = "MUREO_Readers";
        //    }
        //    return functionReturnValue;
        //}

        public string UserRole()
        {
            string functionReturnValue = null;
            string lsDomainName = null;
            lsDomainName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            lsDomainName = lsDomainName.Substring(0, lsDomainName.LastIndexOf("\\"));
            if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\FAMG-MUREO_Admin"))
            {
                functionReturnValue = "MUREO_Admin";
            }
            else if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\MUREO_Admin"))
            {
                functionReturnValue = "MUREO_Admin";
            }
            else if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\FAMG-MUREO_Editors"))
            {
                functionReturnValue = "MUREO_Editors";
            }
            else if (System.Threading.Thread.CurrentPrincipal.IsInRole(lsDomainName + "\\FAMG-MUREO_Readers"))
            {
                functionReturnValue = "MUREO_Readers";
            }
            else
            {
                functionReturnValue = "MUREO_Readers";
            }                   
            return functionReturnValue;     
        }



        public bool IsExists(string str, string val)
        {
            bool res = false;
            if (!str.Contains(","))
            {
                if (str == val)
                    res = true;
            }
            else
            {
                string[] strarr = str.Split(',');
                foreach (string strval in strarr)
                {
                    if (strval == val)
                    {
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        //**************************************************
        //Name   	    :	getUserFullName 
        //Written BY	:	Srinivasachary.n
        //parameters    :	
        //Purpose	    :   To get User full name.
        //Returns       :   Login User Name
        //Program Change History:
        //<Date>			   <Editor>	      	<Rev>		<Description>
        //05-15-09           Srinivasachary.n                 Created
        //'***************************************************

        public string getUserFullName(string searchString)
        {
            // searchString = "reddy.j"
            string UserName = searchString;
            try
            {
                ///'=========P&G=====
                string ReturnedData = null;
                HttpWebRequest HTTPObj = default(HttpWebRequest);
                HttpWebResponse HTTPResponse = default(HttpWebResponse);
                StreamReader srTemp = default(StreamReader);
                int i = 0;

                string LDAPURL = null;
                //LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=" & LastName.ToLower & "*)(sn=" & FirstName.ToLower & "*))&xatr=*"   ' ExtHandle,employeeType,uid,sn,givenName
                //LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=ram*)(sn=moh*))&xatr=ExtHandle,sn,givenName,uid"
                LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(ExtHandle=" + searchString.Trim() + ")&xatr=ExtHandle,sn,givenName,uid";
                //LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(ExtHandle=bolla.su)&xatr=ExtHandle,sn,givenName,uid";
                //cn
                //sn
                //telephoneNumber
                //givenName
                //initials
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
                System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
                Userxmldocument.LoadXml(ReturnedData);

                XmlNodeList node = default(XmlNodeList);
                node = Userxmldocument.GetElementsByTagName("node");

                int j = 0;
                int iInStr = 0;
                int iArrayLn = 0;
                bool bCheck = false;

                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList m_nodelist = default(XmlNodeList);
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

                string strName = string.Empty;
                string[] strNameValue = new string[4];

                for (j = 0; j <= nodecount - 1; j++)
                {
                    //Each m_node In m_nodelist
                    if (i <= 3)
                    {
                        strName += m_nodelist[j].ChildNodes.Item(0).InnerText;
                        strNameValue[i] = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        if (i == 3)
                        {
                            UserName = PropCase(strNameValue[2] + " " + strNameValue[1]) + "-" + (strNameValue[3].Substring((strNameValue[3].IndexOf(".") + 1))).ToUpper();
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
            }
            catch (System.Net.WebException ex)
            {
            }
            catch (Exception ex)
            {
                //lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected"
            }
            //Response.Write(ex.ToString())
            return UserName.Replace(".", "-");
        }

        //**************************************************
        //Name   	    :	getUserTelephoneNumber 
        //Written BY	:	Srinivasachary.n
        //parameters    :	
        //Purpose	    :   To get User TelephoneNumber.
        //Returns       :   Login User Name
        //Program Change History:
        //<Date>			   <Editor>	      	<Rev>		<Description>
        //05-15-09           Srinivasachary.n                 Created
        //'***************************************************

        public string getUserMail(string searchString)
        {
            string TelephoneNumber = "";
            try
            {

                ///'=========P&G=====
                string ReturnedData = null;
                HttpWebRequest HTTPObj = default(HttpWebRequest);
                HttpWebResponse HTTPResponse = default(HttpWebResponse);
                StreamReader srTemp = default(StreamReader);

                int i = 0;

                string LDAPURL = null;
                //LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=" & LastName.ToLower & "*)(sn=" & FirstName.ToLower & "*))&xatr=*"   ' ExtHandle,employeeType,uid,sn,givenName
                //LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=ram*)(sn=moh*))&xatr=ExtHandle,sn,givenName,uid"
                LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(ExtHandle=" + searchString.Trim() + ")&xatr=cn,mail";
                //cn
                //sn
                //telephoneNumber
                //givenName
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


                System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
                Userxmldocument.LoadXml(ReturnedData);
                XmlNodeList node = default(XmlNodeList);
                node = Userxmldocument.GetElementsByTagName("node");

                int j = 0;
                int iInStr = 0;
                int iArrayLn = 0;
                bool bCheck = false;

                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList m_nodelist = default(XmlNodeList);
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

                string strName = string.Empty;
                string[] strNameValue = new string[4];

                for (j = 0; j <= nodecount - 1; j++)
                {
                    //Each m_node In m_nodelist
                    if (i <= 1)
                    {
                        strName += m_nodelist[j].ChildNodes.Item(0).InnerText;
                        strNameValue[i] = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        if (i == 1)
                        {
                            TelephoneNumber = strNameValue[0];
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
            }
            catch (System.Net.WebException ex)
            {
            }
            catch (Exception ex)
            {
                //lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected"
            }
            //Response.Write(ex.ToString())
            return TelephoneNumber;
        }

        public string getUserTelephoneNumber(string searchString)
        {
            string TelephoneNumber = "";
            int intPosition;
            try
            {
                if ((searchString.Trim() != ""))
                {
                    // strApprName = ApprName
                    intPosition = searchString.IndexOf(" ");
                    searchString = searchString.Substring(intPosition);
                    searchString = searchString.Replace("-", ".");
                }
            }
            catch (Exception ex)
            {
            }
            try
            {
                // '''=========P&G=====
                string ReturnedData;
                HttpWebRequest HTTPObj;
                HttpWebResponse HTTPResponse;
                StreamReader srTemp;
                StreamWriter swTemp;
                int i = 0;
                string LDAPURL;
                // LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=" & LastName.ToLower & "*)(sn=" & FirstName.ToLower & "*))&xatr=*"   ' ExtHandle,employeeType,uid,sn,givenName
                //             LDAPURL = "http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(%26(givenName=ram*)(sn=moh*))&xatr=ExtHandle,sn,givenName,uid"
                LDAPURL = ("http://wirekey.pg.com/xgdsauth/xfetch.plx?xsysid=xcsp&xsyspw=xcsppw1&xfilter=(ExtHandle="
                            + (searchString.Trim() + ")&xatr=cn,telephoneNumber"));
                HTTPObj = ((HttpWebRequest)(WebRequest.Create(LDAPURL)));
                HTTPObj.ContentType = HTTPContentType;
                HTTPObj.Method = HTTPMethod;
                HTTPObj.Timeout = HTTPTimeOut;
                HTTPObj.KeepAlive = false;
                HTTPResponse = ((HttpWebResponse)(HTTPObj.GetResponse()));
                if ((HTTPResponse.StatusCode != HttpStatusCode.OK))
                {
                    ReturnedData = string.Empty;
                }
                else
                {
                    srTemp = new System.IO.StreamReader(HTTPResponse.GetResponseStream());
                    ReturnedData = srTemp.ReadToEnd();
                    HTTPResponse.Close();
                }
                System.Xml.XmlDocument Userxmldocument = new System.Xml.XmlDocument();
                Userxmldocument.LoadXml(ReturnedData);
                XmlNodeList nodesUserName;
                XmlNodeList nodesMailID;
                XmlNodeList nodesSN;
                XmlNodeList node;
                node = Userxmldocument.GetElementsByTagName("node");
                int j;
                int k;
                int iInStr = 0;
                string[] strNameMail;
                string[] gstrName;
                string[] gstrTnumber;
                int iArrayLn = 0;
                bool bCheck = false;
                XmlDocument m_xmld;
                XmlNodeList m_nodelist;
                XmlNodeList m_Childnodelist;
                XmlNode m_node;
                // Create the XML Document
                m_xmld = new XmlDocument();
                // Load the Xml file
                m_xmld.LoadXml(ReturnedData);
                // Server.MapPath("../login/XMLFile1.xml"))
                // Get the list of name nodes 
                m_nodelist = m_xmld.SelectNodes("/fetch-service/directory-entries/entry/attr");
                // Loop through the nodes
                int nodecount;
                nodecount = m_nodelist.Count;
                int Childnodecount;
                string strName;
                string[] strNameValue = new string[3];
                for (j = 0; (j
                            <= (nodecount - 1)); j++)
                {
                    // Each m_node In m_nodelist
                    if ((i <= 1))
                    {
                        strName = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        strNameValue[i] = m_nodelist[j].ChildNodes.Item(0).InnerText;
                        if ((i == 1))
                        {
                            TelephoneNumber = strNameValue[1];
                        }
                    }
                    else
                    {
                        i = -1;
                        strName = "";
                        j--;
                    }
                    i++;
                }
            }
            catch (System.Net.WebException ex)
            {
                // lblTitle.Text = "Unable to connect to server.  This may be because VPN is not connected"
            }
            catch (Exception ex)
            {
                // Response.Write(ex.ToString())
            }
            return TelephoneNumber;
        }


        public string PropCase(string strText)
        {
            return new CultureInfo("en").TextInfo.ToTitleCase(strText.ToLower());
        }
    }
}
