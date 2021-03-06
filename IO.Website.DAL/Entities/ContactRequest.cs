﻿using IO.Website.DAL.Support;
using Jjaramillo.SP2013.Transactions.Commands.ListItem;
using Microsoft.SharePoint;
using System;
using System.Runtime.Serialization;
using IO.Website.Support;
using Microsoft.SharePoint.Administration;
using System.Collections.Generic;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class ContactRequest : BaseEntity
    {
        private string _FirstName;
        private string _LastName;
        private string _Company;
        private string _Email;
        private string _Phone;
        private string _Mobile;
        private string _City;
        private string _Subject;
        private string _OtherSubject;

        [DataMember]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.NAME, value);
            }
        }

        [DataMember]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.LAST_NAME, value);
            }
        }

        [DataMember]
        public string Company
        {
            get { return _Company; }
            set
            {
                _Company = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.COMPANY, value);
            }
        }

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.EMAIL, value);
            }
        }

        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.PHONE, value);
            }
        }

        [DataMember]
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                _Mobile = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.MOBILE, value);
            }
        }

        [DataMember]
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.CITY, value);
            }
        }

        [DataMember]
        public string Subject
        {
            get { return _Subject; }
            set
            {
                _Subject = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.SUBJECT, value);
            }
        }

        [DataMember]
        public string OtherSubject
        {
            get { return _OtherSubject; }
            set
            {
                _OtherSubject = value;
                _PropertyBag.AddOrUpdateProperty(SiteColumns.OTHER_SUBJECT, value);
            }
        }

        public ContactRequest(SPListItem item)
            : base(item)
        {
            _FirstName = item.GetSiteColumnStringValue(SiteColumns.NAME, string.Empty);
            _LastName = item.GetSiteColumnStringValue(SiteColumns.LAST_NAME, string.Empty);
            _Company = item.GetSiteColumnStringValue(SiteColumns.COMPANY, string.Empty);
            _Email = item.GetSiteColumnStringValue(SiteColumns.EMAIL, string.Empty);
            _Phone = item.GetSiteColumnStringValue(SiteColumns.PHONE, string.Empty);
            _Mobile = item.GetSiteColumnStringValue(SiteColumns.MOBILE, string.Empty);
            _City = item.GetSiteColumnStringValue(SiteColumns.CITY, string.Empty);
            _Subject = item.GetSiteColumnStringValue(SiteColumns.SUBJECT, string.Empty);
            _OtherSubject = item.GetSiteColumnStringValue(SiteColumns.OTHER_SUBJECT, string.Empty);
        }

        public ContactRequest(string firstName, string lastName, string company, string email, string phone, string mobile, string city, string subject, string otherSubject)
            : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            Email = email;
            Phone = phone;
            Mobile = mobile;
            City = city;
            Subject = subject;
            OtherSubject = otherSubject;
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
                        web.AllowUnsafeUpdates = true;

                        AddListItemCommand addListItemCommand = new AddListItemCommand(ContentTypes.CONTACT_REQUEST_ID, _PropertyBag, targetList, web);
                        addListItemCommand.Execute();

                        _ID = addListItemCommand.ListItem.ID;
                        web.AllowUnsafeUpdates = false;

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
                            string.Format("Buen dia.\nSe ha recibido un registro de solicitd de contacto de parte de {0} {1}.\nPara ver la informacion completa del registro siga esta url\n{2}\nSaludos.\nEl equipo web de IO."
                            , this._FirstName, this._LastName, this._LastName, string.Format("{0}/_layouts/15/listform.aspx?PageType=4&ListId={1}&ID={2}&ContentTypeID={3}", web.Url, addListItemCommand.List.ID, addListItemCommand.ListItem.ID, addListItemCommand.ListItem.ContentTypeId));

                        aspNetMailHelper.SendTextMail(this._Email, mailConfigurationSettings.InboundMailAddress, "Registro de Solicitud de Contacto", messageBody);
                    }
                }
            });

        }

        public void Save(string listUrl)
        {
            SPWeb web = SPContext.Current.Web;
            SPList targetList = web.GetList(string.Format("{0}/{1}", web.Url, listUrl));
            try
            {

                web.AllowUnsafeUpdates = true;
                AddListItemCommand addListItemCommand = new AddListItemCommand(ContentTypes.CONTACT_REQUEST_ID, _PropertyBag, targetList, web);
                addListItemCommand.Execute();
                _ID = addListItemCommand.ListItem.ID;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                web.AllowUnsafeUpdates = false;
            }

        }

    }
}
