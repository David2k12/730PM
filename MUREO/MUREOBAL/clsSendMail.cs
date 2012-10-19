using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;


namespace MUREOBAL
{

    public class clsSendMail
    {

        private string strSendTo;

        private string strSendCCTo;

        private string strSendBCCTo;

        private string strSendFrom;

        private string strMailSubject;

        private string strMailBody;

        public void SendMail()
        {
            strSendTo = string.Empty;
            strSendCCTo = string.Empty;
            strSendBCCTo = string.Empty;
            strSendFrom = string.Empty;
            strMailSubject = string.Empty;
            strMailBody = string.Empty;
        }

        public string SendTo
        {
            get
            {
                return strSendTo;
            }
            set
            {
                strSendTo = value;
            }
        }

        public string SendCCTo
        {
            get
            {
                return strSendCCTo;
            }
            set
            {
                strSendCCTo = value;
            }
        }

        public string SendBCCTo
        {
            get
            {
                return strSendBCCTo;
            }
            set
            {
                strSendBCCTo = value;
            }
        }

        public string SendFrom
        {
            get
            {
                return strSendFrom;
            }
            set
            {
                strSendFrom = value;
            }
        }

        public string MailSubject
        {
            get
            {
                return strMailSubject;
            }
            set
            {
                strMailSubject = value;
            }
        }

        public string MailBody
        {
            get
            {
                return strMailBody;
            }
            set
            {
                strMailBody = value;
            }
        }

        public static bool fnSendMail(clsSendMail objSendMail)
        {
            System.Threading.Thread.Sleep(10000);
            bool IsMailSend;
            string IsMailSendex = string.Empty;
            string SMTPMailServer;
            //MailMessage objMail = new MailMessage();
            IsMailSend = false;
            //SMTPMailServer = ConfigurationSettings.AppSettings.Keys["SMTP"].ToString();
            //SMTPMailServer = "smtpgwvt.pg.com";
           // SMTPMailServer = "smtpgw.pg.com";

            SMTPMailServer = "smtpgw.pg.com";

            MailAddress to;
            MailAddress from;
            string DispalyName = "";
            if ((objSendMail.SendTo != string.Empty))
            {
                to = new MailAddress(objSendMail.SendTo.ToString());
            }
            else
            {
                to = null;
            }
            if ((objSendMail.SendFrom != string.Empty))
            {

                DispalyName = objSendMail.SendFrom.ToString();

            }
            else
            {
                DispalyName = null;
            }

            //from = new MailAddress("mureo@pg.com");
            //to = new MailAddress("bolla.su@pg.com");


          MailAddress from1 = new MailAddress("mureo@pg.com", DispalyName);
          //from = new MailAddress("anild@vertexcs.com");
          //to = new MailAddress("anild@vertexcs.com");
            MailMessage objMail = new MailMessage(from1, to);

            objMail.IsBodyHtml = true;
            if ((objSendMail.SendCCTo != null) && (objSendMail.SendCCTo != string.Empty))
            {
                objMail.CC.Add(objSendMail.SendCCTo.ToString());
            }
            if ((objSendMail.SendBCCTo != null) && (objSendMail.SendBCCTo != string.Empty))
            {
                objMail.Bcc.Add(objSendMail.SendBCCTo.ToString());
            }

            // Uncomment for local use
            // objMail.To = "narasimha.mp@vertexcs.com; sreevani.j@vertexcs.com"
            // objMail.Cc = "narasimha.mp@vertexcs.com; sreevani.j@vertexcs.com; sreevani.j@vertexcs.com"
            // objMail.Bcc = "narasimha.mp@vertexcs.com"
            // objMail.From = "mureo@vertexcs.com"
            // objMail.To = "sreevani.j@vertexcs.com;vijayaramarao.d@vertexcs.com;sreevani.j@vertexcs.com"
            // objMail.Cc = "sreevani.j@vertexcs.com;vijayaramarao.d@vertexcs.com;sreevani.j@vertexcs.com"
            // objMail.Bcc = "sreevani.j@vertexcs.com;vijayaramarao.d@vertexcs.com;sreevani.j@vertexcs.com"
            // objMail.From = "sreevani.j@vertexcs.com;vijayaramarao.d@vertexcs.com;sreevani.j@vertexcs.com"
            if ((objSendMail.MailSubject != string.Empty))
            {
                objMail.Subject = objSendMail.MailSubject;
            }
            if ((objSendMail.MailBody != string.Empty))
            {
                objMail.Body = objSendMail.MailBody;
            }
            if ((SMTPMailServer != string.Empty))
            {
                try
                {

                    SmtpClient client = new SmtpClient("smtpgw.pg.com");
                    client.Send(objMail);
                    IsMailSend = true;
                   
                }

                catch (Exception)
                {
                    try
                    {

                        SmtpClient client = new SmtpClient("smtpgwvt.pg.com");
                        client.Send(objMail);
                        IsMailSend = true;
                    }
                    catch (Exception)
                    {

                        try
                        {

                            SmtpClient client = new SmtpClient("mail1.pg-VTTTTTTTTT.com");
                            client.Send(objMail);
                            IsMailSend = true;
                        }
                        catch (Exception)
                        {

                            try
                            {

                                SmtpClient client = new SmtpClient("mail3.pg-VTTTTTTTTT.com");
                                client.Send(objMail);
                                IsMailSend = true;
                            }
                            catch (Exception)
                            {

                                try
                                {

                                    SmtpClient client = new SmtpClient("mail1.pg.com");
                                    client.Send(objMail);
                                    IsMailSend = true;
                                }
                                catch (Exception)
                                {

                                    try
                                    {
                                        SmtpClient client = new SmtpClient("mail2.pg.com");
                                        client.Send(objMail);
                                        IsMailSend = true;
                                    }
                                    catch (Exception)
                                    {

                                        try
                                        {
                                            SmtpClient client = new SmtpClient("mail3.pg.com");
                                            client.Send(objMail);
                                            IsMailSend = true;
                                        }
                                        catch (Exception ex)
                                        {

                                            IsMailSend = false;
                                            IsMailSendex = ex.Message.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            return IsMailSend;
        }
    }
}