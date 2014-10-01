using Microsoft.SharePoint;
using System;
using System.IO;
using System.Xml.Serialization;

namespace IO.Website.DAL.Entities
{
    [Serializable]
    public class MailConfigEntity
    {
        public bool UseSharepointDefaultConfig { get; set; }

        public string MailServerAddress { get; set; }

        public bool UseSSL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string InboundMailAddress { get; set; }

        public string OutboundMailAddress { get; set; }

        public int Port { get; set; }

        public static MailConfigEntity Get(SPWeb rootWeb)
        {
            MailConfigEntity mailConfigElement = default(MailConfigEntity);
            string parameterValue = rootWeb.Properties.ContainsKey("MailConfig") ? rootWeb.Properties["MailConfig"] : string.Empty;
            if (!string.IsNullOrEmpty(parameterValue))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MailConfigEntity));
                TextReader reader = new StringReader(parameterValue);
                mailConfigElement = (MailConfigEntity)serializer.Deserialize(reader);                
            }

            return mailConfigElement;
        }

        public void Save(SPWeb rootWeb)
        {
            string parameterValue = string.Empty;
            using (TextWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                parameterValue = writer.ToString();
            }
            
            rootWeb.AllowUnsafeUpdates = true;
            if (rootWeb.Properties.ContainsKey("MailConfig"))
            {
                rootWeb.Properties["MailConfig"] = parameterValue;
            }
            else
            {
                rootWeb.Properties.Add("MailConfig", parameterValue);
            }
            rootWeb.Properties.Update();
            rootWeb.AllowUnsafeUpdates = false;
        }
    }    
}
