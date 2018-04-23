using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using DevExpress.Xpo;
using System.Diagnostics;
using DevExpress.XtraScheduler.Xml;
using DevExpress.XtraScheduler.UI;

namespace DevExpress.Calendar.Parts {
    
    public partial class AppointmentEditor : DevExpress.XtraBars.Ribbon.RibbonForm, IDisposable {
        
        public class Controller : AppointmentFormController {

            #region Notes
            public string Notes {
                get {
                    object value = EditedAppointmentCopy.CustomFields["Notes"];

                    if (value == null) {
                        return string.Empty;
                    }

                    return (string)value;
                }
                set {
                    EditedAppointmentCopy.CustomFields["Notes"] = value;
                }
            }

            string SourceNotes {
                get {
                    object value = SourceAppointment.CustomFields["Notes"];

                    if (value == null) {
                        return string.Empty;
                    }

                    return (string)value;
                }
                set {
                    SourceAppointment.CustomFields["Notes"] = value;
                }
            }

            #endregion

            #region CompletionStatus
            public int CompletionStatus {
                get {
                    object value = EditedAppointmentCopy.CustomFields["CompletionStatus"];

                    if (value == null) {
                        return (int)Model.Appointment.CompletionCode.NotStarted;
                    }

                    return (int)value;
                }
                set {
                    EditedAppointmentCopy.CustomFields["CompletionStatus"] = value;
                }
            }

            int SourceCompletionStatus {
                get {
                    object value = SourceAppointment.CustomFields["CompletionStatus"];

                    if (value == null) {
                        return (int)Model.Appointment.CompletionCode.NotStarted;
                    }

                    return (int)value;
                }
                set {
                    SourceAppointment.CustomFields["CompletionStatus"] = value;
                }
            }
            #endregion

            #region ItemType
            public int ItemType {
                get {
                    object value = EditedAppointmentCopy.CustomFields["ItemType"];

                    if (value == null) {
                        return (int)Model.Appointment.ItemCode.Task;
                    }

                    return (int)value;
                }
                set {
                    EditedAppointmentCopy.CustomFields["ItemType"] = value;
                }
            }

            int SourceItemType {
                get {
                    object value = SourceAppointment.CustomFields["ItemType"];

                    if (value == null) {
                        return (int)Model.Appointment.ItemCode.Task;
                    }

                    return (int)value;
                }
                set {
                    SourceAppointment.CustomFields["ItemType"] = value;
                }
            }
            #endregion

            public Controller(SchedulerControl control, Appointment apt)
                : base(control, apt) {
            }

            public override bool IsAppointmentChanged() {
                if (base.IsAppointmentChanged()) {
                    return true;
                }

                return SourceCompletionStatus != CompletionStatus 
                    || Notes != SourceNotes || ItemType != SourceItemType;
            }

            protected override void ApplyCustomFieldsValues() {
                SourceCompletionStatus = CompletionStatus;
                SourceNotes = Notes;
                SourceItemType = ItemType;
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            
            base.Dispose(disposing);
        }

        int _suspendUpdateCount;
        
        protected bool IsUpdateSuspended { 
            get { 
                return _suspendUpdateCount > 0; 
            } 
        }

        protected void SuspendUpdate() {
            _suspendUpdateCount++;
        }

        protected void ResumeUpdate() {
            if (_suspendUpdateCount > 0) {
                _suspendUpdateCount--;
            }
        }

        public AppointmentEditor() {
            InitializeComponent();
        }
        
        Controller _controller;
        SchedulerControl _scheduler;
        Appointment _appointment;

        object _ResourceId;

        public AppointmentEditor(SchedulerControl scheduler, Appointment appointment) {

            _controller = new Controller(scheduler, appointment);
            _appointment = appointment;
            _scheduler = scheduler;
					
            SuspendUpdate();
            try {
                
                InitializeComponent();

            } finally {
                ResumeUpdate();
            }

            InitForm();

		}
       
        void InitForm() {
            SuspendUpdate();
            try {
                _ResourceId = _controller.ResourceId;

                startDateEdit.DateTime = _controller.Start;
                startTimeEdit.Time = _controller.Start;
                endDateEdit.DateTime = _controller.End;
                endTimeEdit.Time = _controller.End;

                endTimeEdit.Properties.AllowNullInput = Utils.DefaultBoolean.True;
                startTimeEdit.Properties.AllowNullInput = Utils.DefaultBoolean.True;
                
                if (_controller.AllDay) {
                    startTimeEdit.EditValue = null;
                    endTimeEdit.EditValue = null;
                }

                subjectEdit.Text = _controller.Subject;

                switch (_controller.CompletionStatus) {
                    case (int)Model.Appointment.CompletionCode.NotStarted:
                        statusEdit.SelectedIndex = 0;
                        break;

                    case (int)Model.Appointment.CompletionCode.InProgress:
                        statusEdit.SelectedIndex = 1;
                        break;

                    case (int)Model.Appointment.CompletionCode.Canceled:
                        statusEdit.SelectedIndex = 2;
                        break;

                    case (int)Model.Appointment.CompletionCode.Completed:
                        statusEdit.SelectedIndex = 3;
                        break;

                    default:
                        statusEdit.SelectedIndex = -1;
                        break;
                }


            } finally {
                ResumeUpdate();
            }

            InitTitle();
        }
        
        void InitTitle() {
            
            string itemType = Enum.GetName(typeof(Model.Appointment.ItemCode), 
                        ((Model.Appointment.ItemCode)_controller.ItemType));

            ribbonHomePage.Text = itemType;

            if (_controller.IsNewAppointment) {

                Text = "New " + itemType;

            } else {
                
                Text = "Edit " + itemType;
            }
        }

        private void OnSaveAndClose(object sender, ItemClickEventArgs e) {
            if (!_controller.IsConflictResolved()) {
                return;
            }

            _controller.ResourceId = _ResourceId;

            switch (statusEdit.SelectedIndex) {
                case 0:
                    _controller.CompletionStatus = (int)Model.Appointment.CompletionCode.NotStarted;
                    break;
                case 1:
                    _controller.CompletionStatus = (int)Model.Appointment.CompletionCode.InProgress;
                    break;
                case 2:
                    _controller.CompletionStatus = (int)Model.Appointment.CompletionCode.Canceled;
                    break;
                case 3:
                    _controller.CompletionStatus = (int)Model.Appointment.CompletionCode.Completed;
                    break;
                default:
                    break;
            }            
            
            _controller.Subject = subjectEdit.Text.Trim();

            DateTime startTime;

            if (startTimeEdit.EditValue != null)
                startTime = startTimeEdit.Time;
            else
                startTime = DateTime.MinValue;

            DateTime endTime;

            if (endTimeEdit.EditValue != null)
                endTime = endTimeEdit.Time;
            else
                endTime = DateTime.MaxValue;

            _controller.Start = new DateTime(
                    startDateEdit.DateTime.Year,
                    startDateEdit.DateTime.Month,
                    startDateEdit.DateTime.Day,
                    startTime.Hour,
                    startTime.Minute,
                    startTime.Second);


            _controller.AllDay = startTimeEdit.EditValue == null &&
                endTimeEdit.EditValue == null;

            if (_controller.AllDay) {
                _controller.End = _controller.Start.AddDays(1);
            } else {
                _controller.End = new DateTime(
                        endDateEdit.DateTime.Year,
                        endDateEdit.DateTime.Month,
                        endDateEdit.DateTime.Day,
                        endTime.Hour,
                        endTime.Minute,
                        endTime.Second);
            }

            _controller.Description = richEditControl.Text;
            _controller.Notes = richEditControl.RtfText;
           
            _controller.ApplyChanges();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}