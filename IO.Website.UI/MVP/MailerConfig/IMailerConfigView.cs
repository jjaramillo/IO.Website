using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO.Website.UI.MVP.MailerConfig
{
    internal interface IMailerConfigView : IView
    {
        bool UseSharepointDefaultConfig { get; set; }
        bool UseSSL { get; set; }
        string MailServerAddress { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string InboundMailAddress { get; set; }
        string OutboundMailAddress { get; set; }
        int Port { get; set; }

        void ShowAspNetMailParameters();
        void HideAspNetMailParameters();
    }
}
