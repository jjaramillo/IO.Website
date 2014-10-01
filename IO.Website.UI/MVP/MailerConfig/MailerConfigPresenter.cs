using IO.Website.DAL.Entities;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IO.Website.UI.MVP.MailerConfig
{
    internal class MailerConfigPresenter : BasePresenter<IMailerConfigView>
    {
        public MailerConfigPresenter(IMailerConfigView view, SPWeb web)
            : base(view, web) { }

        public void CleanAspNetMailParameters()
        {
            _View.MailServerAddress = string.Empty;
            _View.Password = string.Empty;
            _View.UserName = string.Empty;
            _View.UseSSL = false;
            _View.Port = 0;
        }

        public void ShowAspNetMailParameters() { _View.ShowAspNetMailParameters(); }

        public void HideAspNetMailParameters() { _View.HideAspNetMailParameters(); }

        public void TestMailSettings() 
        {
            string smtpServer = string.Empty;
            SmtpClient smtpClient = default(SmtpClient);
            if (_View.UseSharepointDefaultConfig)
            {
                if (!SPUtility.IsEmailServerSet(_Web))
                    throw new Exception("El servidor de correo no se encuentra configurado para este sitio");
                smtpServer = SPAdministrationWebApplication.Local.OutboundMailServiceInstance.Server.Address;
                smtpClient = new SmtpClient(smtpServer);
            }
            else {
                smtpClient = new SmtpClient(_View.MailServerAddress, _View.Port);
                smtpClient.EnableSsl = _View.UseSSL;
                smtpClient.Credentials = new NetworkCredential(_View.UserName, _View.Password);

            }

       
            MailMessage mailMessage = new MailMessage(_View.OutboundMailAddress, _View.InboundMailAddress);

            mailMessage.Subject = "Correo de Prueba de IO";
            mailMessage.Body = "Esto es un correo de prueba enviado por la caracteristica de configuracion de envios de correos electronicos. Por favor ignore este mensaje.";
            mailMessage.IsBodyHtml = false;           

            smtpClient.Send(mailMessage);
        }

        public void Save()
        {
            MailConfigEntity mailConfig = new MailConfigEntity();
            mailConfig.InboundMailAddress = _View.InboundMailAddress;
            mailConfig.MailServerAddress = _View.MailServerAddress;
            mailConfig.OutboundMailAddress = _View.OutboundMailAddress;
            mailConfig.Password = _View.Password;
            mailConfig.Port = _View.Port;
            mailConfig.UserName = _View.UserName;
            mailConfig.UseSharepointDefaultConfig = _View.UseSharepointDefaultConfig;
            mailConfig.UseSSL = _View.UseSSL;
            string parameterValue = string.Empty;
            using(TextWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(mailConfig.GetType());
                serializer.Serialize(writer, mailConfig);
                parameterValue = writer.ToString();
            }
            SPWeb rootWeb = _Web.Site.RootWeb;
            rootWeb.AllowUnsafeUpdates = true;
            if (rootWeb.Properties.ContainsKey("MailConfig"))
            {
                rootWeb.Properties["MailConfig"] = parameterValue;
            }
            else 
            {
                rootWeb.Properties.Add("MailConfig",  parameterValue);
            }
            rootWeb.Properties.Update();
            rootWeb.AllowUnsafeUpdates = false;
            
        }

        public void Load()
        {
            SPWeb rootWeb = _Web.Site.RootWeb;
            string parameterValue = rootWeb.Properties.ContainsKey("MailConfig") ? rootWeb.Properties["MailConfig"] : string.Empty;
            if (!string.IsNullOrEmpty(parameterValue))
            {                
                XmlSerializer serializer = new XmlSerializer(typeof(MailConfigEntity));
                TextReader reader = new StringReader(parameterValue);
                MailConfigEntity mailConfig = (MailConfigEntity)serializer.Deserialize(reader);

                _View.InboundMailAddress = mailConfig.InboundMailAddress;
                _View.OutboundMailAddress = mailConfig.OutboundMailAddress;
                _View.Port = mailConfig.Port = mailConfig.Port;
                _View.MailServerAddress = mailConfig.MailServerAddress;
                _View.UseSSL = mailConfig.UseSSL;
                _View.UserName = mailConfig.UserName;
                _View.UseSharepointDefaultConfig = mailConfig.UseSharepointDefaultConfig;
            }
        }
    }
}
