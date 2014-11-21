using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace IO.Website.Services.Features.IOWebsiteMessageSize
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f5597ca0-2878-4a8a-8713-05cff9b39f65")]
    public class IOWebsiteMessageSizeEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWebService contentService = SPWebService.ContentService;
            contentService.ClientRequestServiceSettings.MaxReceivedMessageSize = -1;
            SPWcfServiceSettings wcfSettings = new SPWcfServiceSettings();
            wcfSettings.MaxReceivedMessageSize = Int32.MaxValue;            
            contentService.WcfServiceSettings["workwithusrequestservice.svc"] = wcfSettings;
            contentService.Update();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWebService contentService = SPWebService.ContentService;    
            contentService.WcfServiceSettings.Remove("workwithusrequestservice.svc");
            contentService.ClientRequestServiceSettings.MaxReceivedMessageSize = 0;
            contentService.Update();
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
