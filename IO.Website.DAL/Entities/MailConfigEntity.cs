using System;

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
    }    
}
