namespace DevExpress.Calendar.Model {
    using System;
    using DevExpress.Xpo;
    using DevExpress.XtraScheduler;
    using DevExpress.XtraScheduler.Xml;
#if !WIN
    using DevExpress.Xpo.Services;
    using DevExpress.Data.Services;
#endif

#if !WIN
    [ResourceSetName("Appointments")]
#endif
    [Persistent("Appointments")]
    public partial class Appointment : XPCustomObject {
        public Appointment(Session session) 
            : base(session) { 
        }

        public Appointment() {
        }

        public Appointment(Session session, DevExpress.Xpo.Metadata.XPClassInfo classInfo)
            : base(session, classInfo) {            
        }

        public override void AfterConstruction() {
            base.AfterConstruction();
        }

        protected override void OnDeleted() {
            base.OnDeleted();
        }
        
        Guid _id;
        [Key(AutoGenerate = true)]
        public Guid ID {
            get {
                return _id;
            }
            set {
                SetPropertyValue<Guid>("ID", ref _id, value);
            }
        }

        bool _isAllDay;
        public bool IsAllDay {
            get { 
                return _isAllDay; 
            }
            set { 
                SetPropertyValue<bool>("IsAllDay", ref _isAllDay, value); 
            }
        }

        string _description;
        [Size(SizeAttribute.Unlimited)]
        public string Description {
            get { 
                return _description; 
            }
            set { 
                SetPropertyValue<string>("Description", ref _description, value); 
            }
        }

        string _notes;
        [Size(SizeAttribute.Unlimited)]
        public string Notes {
            get {
                return _notes;
            }
            set {
                SetPropertyValue<string>("Notes", ref _notes, value);
            }
        }

        int _label;
        public int Label {
            get { 
                return _label; 
            }
            set { 
                SetPropertyValue<int>("Label", ref _label, value); 
            }
        }

        string _location;
        public string Location {
            get { 
                return _location; 
            }
            set {
                SetPropertyValue<string>("Location", ref _location, value); 
            }
        }

        string _recurrence;
        [Size(SizeAttribute.Unlimited)]
        public string Recurrence {
            get { 
                return _recurrence; 
            }
            set {
                SetPropertyValue<string>("Recurrence", ref _recurrence, value); 
            }
        }

        string _reminder;
        [Size(SizeAttribute.Unlimited)]
        public string Reminder {
            get { 
                return _reminder; 
            }
            set { 
                SetPropertyValue<string>("Reminder", ref _reminder, value); 
            }
        }

        [NonPersistent]
        public bool IsCompleted {
            get {
                return CompletionStatus < 0;
            }
            set {
                CompletionStatus = value ? 
                    (int)CompletionCode.Completed : (int)CompletionCode.NotStarted;
            }
        }

        int _completionStatus;
        public int CompletionStatus {
            get {
                return _completionStatus;
            }
            set {
                SetPropertyValue<int>("CompletionStatus", ref _completionStatus, value);
            }
        }

        DateTime _start;
        public DateTime Start {
            get { 
                return _start; 
            }
            set { 
                SetPropertyValue<DateTime>("Start", ref _start, value); 
            }
        }

        DateTime _finish;
        public DateTime Finish {
            get {
                return _finish;
            }
            set {
                SetPropertyValue<DateTime>("Finish", ref _finish, value);
            }
        }

        int _status;
        public int Status {
            get { 
                return _status; 
            }
            set { 
                SetPropertyValue<int>("Status", ref _status, value); 
            }
        }

        string _subject;
        public string Subject {
            get { 
                return _subject; 
            }
            set { 
                SetPropertyValue<string>("Subject", ref _subject, value); 
            }
        }

        int _itemType;
        public int ItemType {
            get {
                return _itemType;
            }
            set {
                SetPropertyValue<int>("ItemType", ref _itemType, value);
            }
        }

        int _appointmentType;
        public int AppointmentType {
            get { 
                return _appointmentType; 
            }
            set { 
                SetPropertyValue<int>("AppointmentType", ref _appointmentType, value); 
            }
        }

#if RESOURCE_SHARING
        [Association("Appointments-Resources", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Resource> Resources {
            get {
                return GetCollection<Resource>("Resources");
            }
        }
#else        
        Resource _resource;
        [Association("Appointments-Resources", UseAssociationNameAsIntermediateTableName = true)]
        public Resource Resource {
            get {
                return _resource;
            }
            set {
                SetPropertyValue<Resource>("Resource", ref _resource, value);
            }
        }

        [Visible]
        [NonPersistent]
        public Nullable<Guid> AssignedTo {
            get {
                return _resource != null 
                    ? new Nullable<Guid>(_resource.ID) : null;
            }
            set {
                Resource = this.Session.GetObjectByKey<Resource>(value);
            }
        }
#endif

#if RESOURCES
        [NonPersistent()]
#if !WIN
        [Visible]
#endif
        public string Resources {
            get {
                ResourceIdCollection resources = new ResourceIdCollection();
                
                for (int i = 0; i < Participants.Count; i++) {
                    resources.Add(Participants[i].ID);
                }

                return new AppointmentResourceIdCollectionXmlPersistenceHelper(resources).ToXml();
            }
            set {
                ResourceIdCollection resources = new ResourceIdCollection();
                
                if (!string.IsNullOrEmpty(value)) {
                    resources
                        = AppointmentResourceIdCollectionXmlPersistenceHelper.ObjectFromXml(resources, value);
                }
                
                Participants.SuspendChangedEvents();
                try {
                    while (Participants.Count > 0) {
                        Participants.Remove(Participants[0]);
                    }

                    for (int i = 0; i < resources.Count; i++) {
                        Participant resource = this.Session.GetObjectByKey<Participant>(resources[i]);
                        if (resource != null) {
                            Participants.Add(resource);
                        }
                    }

                } finally {
                    Participants.ResumeChangedEvents();
                }
            }
        }
#endif
         
    }

}