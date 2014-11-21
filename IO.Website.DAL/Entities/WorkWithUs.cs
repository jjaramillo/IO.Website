using IO.Website.DAL.Support;
using IO.Website.Support;
using Jjaramillo.SP2013.Transactions.Commands.File;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class WorkWithUs : BaseEntity
    {
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _FileName;
        private byte[] _FileContents;

        [DataMember]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public byte[] FileContents
        {
            get { return _FileContents; }
            set { _FileContents = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public WorkWithUs(string firstName, string lastName, string email, string fileName, string fileContents)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _Email = email;
            _FileContents = Encoding.GetEncoding(28591).GetBytes(fileContents);
            _FileName = fileName;
        }

        public WorkWithUs(SPListItem item)
            : base(item)
        {
            _FirstName = item.GetSiteColumnStringValue(SiteColumns.NAME, string.Empty);
            _LastName = item.GetSiteColumnStringValue(SiteColumns.LAST_NAME, string.Empty);
            _Email = item.GetSiteColumnStringValue(SiteColumns.EMAIL, string.Empty);
        }

        public void Save(string contextUrl, string listUrl)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(contextUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList targetList = web.GetList(string.Format("{0}/{1}", web.Url, listUrl));
                        Hashtable fieldValues = new Hashtable();
                        fieldValues.Add(SiteColumns.NAME, _FirstName);
                        fieldValues.Add(SiteColumns.LAST_NAME, _LastName);
                        fieldValues.Add(SiteColumns.EMAIL, _Email);
                        web.AllowUnsafeUpdates = true;
                        AddFileItemCommand addFileItemCommand = new AddFileItemCommand(string.Format("{0}_{1}", Guid.NewGuid(), _FileName), _FileContents, fieldValues, ContentTypes.WORK_WITH_US_REQUEST_ID, true, targetList, web);
                        addFileItemCommand.Execute();
                        _ID = addFileItemCommand.ListItem.ID;

                        SPWeb rootWeb = site.RootWeb;
                        MailConfigEntity mailConfigurationSettings = MailConfigEntity.Get(rootWeb);

                        AspNetMailHelper aspNetMailHelper = default(AspNetMailHelper);
                        if (mailConfigurationSettings.UseSharepointDefaultConfig)
                        {
                            aspNetMailHelper = new AspNetMailHelper(SPAdministrationWebApplication.Local.OutboundMailServiceInstance.Server.Address);
                        }
                        else
                        {
                            aspNetMailHelper = new AspNetMailHelper(mailConfigurationSettings.MailServerAddress, mailConfigurationSettings.Port, mailConfigurationSettings.UseSSL
                                , mailConfigurationSettings.UserName, mailConfigurationSettings.Password);
                        }

                        string messageBody =
                            string.Format("Buen dia.\nSe ha recibido un registro de trabaje con nosotros de {0} {1}.\nPara ver la informacion completa del registro siga esta url\n{2}\nSaludos.\nEl equipo web de IO."
                            , this._FirstName, this._LastName, string.Format("{0}/_layouts/15/listform.aspx?PageType=4&ListId={1}&ID={2}&ContentTypeID={3}", web.Url, addFileItemCommand.List.ID, addFileItemCommand.ListItem.ID, addFileItemCommand.ListItem.ContentTypeId));

                        aspNetMailHelper.SendTextMail(this._Email, mailConfigurationSettings.InboundMailAddress, "Registro de Solicitud de Demo", messageBody);
                    }
                }
            });
        }

        public void Save(string listUrl) { }
    }
}
