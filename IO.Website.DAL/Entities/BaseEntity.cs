using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IO.Website.DAL.Entities
{
    [DataContract]
    public class BaseEntity
    {
        protected Nullable<Int32> _ID;
        protected Nullable<DateTime> _CreationDate;
        protected Nullable<DateTime> _ModifiedDate;
        protected Dictionary<string, object> _PropertyBag;

        [DataMember]
        public Nullable<Int32> ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [DataMember]
        public Nullable<DateTime> CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        [DataMember]
        public Nullable<DateTime> ModifiedDate
        {            
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        
        public BaseEntity(SPListItem item)
        {
            _PropertyBag = new Dictionary<string, object>();
            _ID = item.ID;
            _CreationDate = Convert.ToDateTime(item[SPBuiltInFieldId.Created]);
            _ModifiedDate = Convert.ToDateTime(item[SPBuiltInFieldId.Modified]);
        }

        public BaseEntity() {
            _PropertyBag = new Dictionary<string, object>();
        }
    }
}
