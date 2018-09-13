using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Emailer
{
    public partial class Index : System.Web.UI.Page
    {
        public class EmailCredentials
        {
            public string From { get; set; }
            public string To { get; set; }
            public string BCC { get; set; }
            public string Mail { get; set; }
            public string Subject { get; set; }
            public string SMTPMail { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int _Port { get; set; }
            public bool _SSL { get; set; }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


       
       
    

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text.Length > 0)
                {
                    string myIP = string.Empty;
                    try
                    {
                        string hostName = Dns.GetHostName();
                        myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();  
                    }
                    catch (Exception)
                    {
                    }
                   


                    EmailCredentials objEmail = new EmailCredentials();

                    System.Net.Mime.ContentType mimeType = new System.Net.Mime.ContentType("text/html");

                    objEmail.From = "From Email Address";
                    objEmail.UserName = "username";
                    objEmail.Password = "password";
                    objEmail.To = "mohsinansari3011@gmail.com";

                    if (txtbcc.Text.Trim().Length>0)
                    {
                        objEmail.BCC = txtbcc.Text.Trim();
                    }
                    
                    
                    
                    
                    objEmail.SMTPMail = "smtp.gmail.com";
                    objEmail._Port = 587;
                    objEmail._SSL = true;
                    objEmail.Subject = "This Email is generated from Email tester!! by " + myIP;
                    objEmail.Mail = txtemail.Text.Trim();


                    if (SendMail(objEmail))
                    {
                        lblMessage.Text = "Email Sent Successfully!!!";
                    }
                    else
                    {
                        lblMessage.Text = "Email Sending Error!!";
                    }
                }
                else
                {
                    lblMessage.Text = "Please Paste html content to send it as an email!!";
                }

            }
            catch (Exception ex)
            {
                
                 lblMessage.Text = ex.Message;
            }
        }


        public bool SendMail(EmailCredentials objEmail)
        {
            bool Issent = false;

            try
            {
                MailMessage MailMsg = new MailMessage();
                MailMsg.Subject = objEmail.Subject;
                MailMsg.From = new MailAddress(objEmail.From);

                if (objEmail.To.Contains(","))
                {
                    foreach (var EmailTo in objEmail.To.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        MailMsg.To.Add(new MailAddress(EmailTo));
                    }
                }
                else
                {
                    MailMsg.To.Add(new MailAddress(objEmail.To));
                }


                if (objEmail.BCC != null)
                {
                    if (objEmail.BCC.Length > 0)
                    {
                        if (objEmail.BCC.Contains(","))
                        {
                            foreach (var EmailBCC in objEmail.BCC.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                MailMsg.Bcc.Add(new MailAddress(EmailBCC));
                            }
                        }
                        else
                        {
                            MailMsg.Bcc.Add(new MailAddress(objEmail.BCC));
                        }
                    }
                    
                }
                


                //MailMsg.To.Add(new MailAddress(To));
                MailMsg.Priority = MailPriority.High;
                MailMsg.Body = objEmail.Mail;
                MailMsg.IsBodyHtml = true;
                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Host = objEmail.SMTPMail;
                SmtpMail.UseDefaultCredentials = false;
                NetworkCredential basicInfo = new NetworkCredential(objEmail.UserName, objEmail.Password);
                SmtpMail.Credentials = basicInfo;
                SmtpMail.Port = objEmail._Port;
                SmtpMail.EnableSsl = objEmail._SSL;
                SmtpMail.Send(MailMsg);

                Issent = true;
            }
            catch (Exception)
            {
                Issent = false;
            }

            return Issent;
        }
    }
}