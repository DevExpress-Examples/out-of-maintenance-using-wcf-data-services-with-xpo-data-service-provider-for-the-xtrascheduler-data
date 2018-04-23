namespace DevExpress.Calendar.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DevExpress.Xpo;
    using DevExpress.Xpo.Metadata;
#if !WIN
    using DevExpress.Xpo.Services;
    using DevExpress.Data.Services;
#endif

#if !WIN
    [ResourceSetName("Resources")]
#endif
    [Persistent("Resources")]
    public partial class Resource : XPCustomObject {
        public Resource(Session session)
            : base(session) {
        }

        public Resource() {            
        }

        public Resource(Session session, XPClassInfo classInfo)
            : base(session, classInfo) {
        }         

        Guid _id;
        [Key(AutoGenerate = true)]
        public Guid ID {
            get {
                return _id;
            }
            set {
                SetPropertyValue("ID", ref _id, value);
            }
        }

        string _email;
        [Size(256)]
        public string Email {
            get {
                return _email;
            }
            set {
                SetPropertyValue("Email", ref _email, value);
            }
        }

        string _userName;
        [Size(256)]
        public string UserName {
            get {
                return _userName;
            }
            set {
                SetPropertyValue("UserName", ref _userName, value);
            }
        }

        string _name;
        [Size(256)]
        public string Name {
            get {
                return _name;
            }
            set {
                SetPropertyValue("Name", ref _name, value);
            }
        }

        [Association("Appointments-Resources", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Appointment> Appointments {
            get {
                return GetCollection<Appointment>("Appointments");
            }
        }
    }
}