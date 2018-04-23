using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.Xpo;
using System.Configuration;
using DevExpress.Data.Filtering;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Services.Client;
using System.Threading;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;

namespace DevExpress.Calendar.Parts {
    public partial class Home : DevExpress.XtraEditors.XtraUserControl, ICalendar {

        #region OnResize
        int _ratio = -1;

        void CalculateRatio() {
            _ratio = (this.gridControl.Height * 100) / this.Height;
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            if (_ratio > 0) {
                this.gridControl.Height = (this._ratio * this.Height) / 100;
            }
        }
        #endregion

        Model.Resource FindUserByUserName(string userName) {
            if (string.IsNullOrEmpty(userName)) {

                return null;
            }

            Collection<Model.Resource> dataSource
                = schedulerStorage.Resources.DataSource as Collection<Model.Resource>;

            if (dataSource == null) {

                return null;
            }

            foreach (Model.Resource r in dataSource) {

                if (!string.IsNullOrEmpty(r.UserName)
                    && r.UserName.ToLower().Contains(userName.ToLower())) {

                    return r;
                }
            }

            return null;
        }

        Model.Resource FindResourceByID(Guid id) {

            Collection<Model.Resource> dataSource
                = schedulerStorage.Resources.DataSource as Collection<Model.Resource>;

            if (dataSource == null) {

                return null;
            }

            foreach (Model.Resource r in dataSource) {

                if (!string.IsNullOrEmpty(r.UserName)
                    && r.ID == id) {

                    return r;
                }
            }

            return null;
        }

        static Collection<Model.Resource> CreateDataSourceForResources() {

            var Query = from p in new Model.Service(Program.Service).Resources
                        orderby p.Name
                        select p;
            {

                Collection<Model.Resource> dataSource = new Collection<Model.Resource>();

                foreach (Model.Resource resource in Query) {
                    dataSource.Add(resource);
                }

                return dataSource;

            }


        }

        static BindingList<Model.Appointment> CreateDataSourceForTasks() {
            
            return new BindingList<Model.Appointment>();
        }

        static BindingList<Model.Appointment> CreateDataSourceForAppointments() {

            return new BindingList<Model.Appointment>();
        }
        
        public void Fill(
            TimeInterval e,
            Model.Resource resource, Uri uri) {

#if DEBUG
            Debug.WriteLine(e);
#endif

            BindingList<Model.Appointment> schedulerDataSource

                    = schedulerStorage.Appointments.DataSource as BindingList<Model.Appointment>;

            if (schedulerDataSource == null) {

                return;
            }

            lock (schedulerDataSource) {

                DevExpress.Calendar.Model.Service service
                    = new DevExpress.Calendar.Model.Service(uri);

                DateTime now = DateTime.UtcNow;

                DateTime start = e.Start.ToUniversalTime();
                DateTime end = e.End.ToUniversalTime();

                DateTime weekStart = now.AddDays(-7);
                DateTime weekEnd = now.AddDays(7);

                DataServiceQuery<Model.Appointment> query;

                if (resource == null) {

                    query = (DataServiceQuery<Model.Appointment>)service.Appointments.Where(s =>

                                    /* always include incomplete items */
                                    (s.Finish <= now && s.CompletionStatus >= 0)

                                        ||

                                    /* always include recurrence templates */
                                    (s.AppointmentType == (int)AppointmentType.Pattern)

                                        ||

                                    ((s.Start >= start && s.Start <= end) || (s.Finish >= start && s.Finish <= end))

                                        ||

                                    /* always include todays */
                                    ((s.Start >= weekStart && s.Start <= weekEnd) || (s.Finish >= weekStart && s.Finish <= weekEnd))

                    );

                } else {

                    query

                        = (DataServiceQuery<Model.Appointment>)service.Appointments.Where(s =>

                            (
                                    s.Resource.ID == resource.ID
                            )

                                    &&

                            (
                                /* always include recurrence templates */
                                    (s.AppointmentType == (int)AppointmentType.Pattern)

                                        ||

                                    /* always include incomplete items */
                                    (s.Finish <= now && s.CompletionStatus >= 0)

                                        ||

                                    ((s.Start >= start && s.Start <= end) || (s.Finish >= start && s.Finish <= end))

                                        ||

                                    /* always include todays */
                                    ((s.Start >= weekStart && s.Start <= weekEnd) || (s.Finish >= weekStart && s.Finish <= weekEnd))

                            )

                          );
                }

                using (new WaitCursor()) {

                    SuspendLayout();

                    schedulerControl.BeginUpdate();
                    schedulerStorage.BeginUpdate();

                    gridControl.BeginUpdate();
                    gridView.BeginUpdate();

                    try {

                        BindingList<Model.Appointment> taskDataSource = gridControl.DataSource as BindingList<Model.Appointment>;

                        schedulerDataSource.Clear();

                        if (taskDataSource != null) {
                            taskDataSource.Clear();
                        }

                        if (query != null) {

                            foreach (DevExpress.Calendar.Model.Appointment s in query) {
                                DevExpress.Calendar.Model.Appointment local = s.Clone(DateTimeKind.Local);
                                
                                schedulerDataSource.Add(local);

                                if (taskDataSource != null) {
                                    if (local.AppointmentType == (int)AppointmentType.Normal) {
                                        taskDataSource.Add(local);
                                    }
                                }
                            }
                        }

                    } finally {

                        gridView.EndUpdate();
                        gridControl.EndUpdate();

                        schedulerStorage.EndUpdate();
                        schedulerControl.EndUpdate();

                        ResumeLayout();
                    }

                }
            }
        }

        void DoFilterUserChanged(object sender, bool bRefreshDataSource) {

            schedulerControl.BeginUpdate();
            schedulerStorage.BeginUpdate();

            try {

                gridControl.BeginUpdate();
                try {

                    Model.Resource user = sender as Model.Resource;

                    if (user != null) {

                        schedulerControl.Views.DayView.ResourcesPerPage = 1;
                        schedulerControl.Views.MonthView.ResourcesPerPage = 1;
                        schedulerControl.Views.TimelineView.ResourcesPerPage = 1;
                        schedulerControl.Views.WeekView.ResourcesPerPage = 1;
                        schedulerControl.Views.WorkWeekView.ResourcesPerPage = 1;
                        schedulerControl.GroupType = SchedulerGroupType.None;
                        gridColumnAssignedTo.Visible = false;
                        gridColumnAssignedTo.OptionsColumn.ShowInCustomizationForm = false;

                    } else {

                        schedulerControl.GroupType = SchedulerGroupType.Resource;
                        schedulerControl.Views.DayView.ResourcesPerPage = 5;
                        schedulerControl.Views.MonthView.ResourcesPerPage = 5;
                        schedulerControl.Views.TimelineView.ResourcesPerPage = 5;
                        schedulerControl.Views.WeekView.ResourcesPerPage = 5;
                        schedulerControl.Views.WorkWeekView.ResourcesPerPage = 5;
                        gridColumnAssignedTo.Visible = true;
                        gridColumnAssignedTo.OptionsColumn.ShowInCustomizationForm = true;

                    }

                    if (bRefreshDataSource) {
                        schedulerControl.RefreshData();
                    }

                } finally {
                    gridControl.EndUpdate();
                }

            } finally {

                schedulerStorage.EndUpdate();
                schedulerControl.EndUpdate();
            }

        }

        void OnFilterUserChanged(object sender, EventArgs e) {
            DoFilterUserChanged(sender, true);
        }

        void OnFilterResource(object sender, PersistentObjectCancelEventArgs e) {
            if (Filter.Current.User == null) {

                e.Cancel = false;

            } else {

                e.Cancel = ((Model.Resource)e.Object.GetSourceObject(schedulerStorage)).ID
                    != Filter.Current.User.ID;
            }
        }

        public Home() {
            InitializeComponent();

            Filter.Current.UserChanged += OnFilterUserChanged;

            schedulerStorage.Appointments.CustomFieldMappings.Add(
                new AppointmentCustomFieldMapping("ItemType", "ItemType", FieldValueType.Integer));
            
            schedulerStorage.Appointments.CustomFieldMappings.Add(
                new AppointmentCustomFieldMapping("CompletionStatus", "CompletionStatus", FieldValueType.Integer));

            schedulerStorage.Appointments.CustomFieldMappings.Add(
                new AppointmentCustomFieldMapping("Notes", "Notes", FieldValueType.String));

            schedulerStorage.Appointments.Mappings.AllDay = "IsAllDay";
            schedulerStorage.Appointments.Mappings.Description = "Description";
            schedulerStorage.Appointments.Mappings.End = "Finish";
            schedulerStorage.Appointments.Mappings.Label = "Label";
            schedulerStorage.Appointments.Mappings.Location = "Location";

            /* schedulerStorage.Appointments.Mappings.RecurrenceInfo = "Recurrence"; */
            /* schedulerStorage.Appointments.Mappings.ReminderInfo = "Reminder"; */

            schedulerStorage.Appointments.Mappings.Start = "Start";
            schedulerStorage.Appointments.Mappings.Status = "Status";
            schedulerStorage.Appointments.Mappings.Subject = "Subject";
            schedulerStorage.Appointments.Mappings.Type = "AppointmentType";

            schedulerStorage.Appointments.Mappings.ResourceId = "AssignedTo";
            schedulerStorage.Resources.Mappings.Id = "ID";
            schedulerStorage.Resources.Mappings.Caption = "DisplayText";

            schedulerStorage.AppointmentsChanged += OnAppointmentsChanged;
            schedulerStorage.AppointmentsInserted += OnAppointmentsInserted;
            schedulerStorage.AppointmentDeleting += OnAppointmentsDeleting;
            schedulerStorage.FetchAppointments += OnAppointmentsFetch;
            schedulerStorage.FilterResource += OnFilterResource;

            schedulerControl.Start = DateTime.Today;
            schedulerControl.GroupType = SchedulerGroupType.Resource;
            schedulerControl.ResourceNavigator.Visibility = ResourceNavigatorVisibility.Auto;
            schedulerControl.Views.DayView.ResourcesPerPage = 4;

            schedulerControl.EditAppointmentFormShowing += EditAppointmentFormShowing;

            gridView.KeyDown += OnKeyDown;
            gridView.RowUpdated += OnRowUpdated;
            gridView.InitNewRow += OnInitNewRow;
            gridView.CustomDrawCell += OnCustomDrawCell;
            gridView.CustomUnboundColumnData += OnCustomUnboundColumnData;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) {

                schedulerStorage.Appointments.DataSource = CreateDataSourceForAppointments();
                schedulerStorage.Resources.DataSource = CreateDataSourceForResources();
                gridControl.DataSource = CreateDataSourceForTasks();

                foreach(Model.Resource r
                            in (Collection<Model.Resource>)schedulerStorage.Resources.DataSource) {
                    
                    repositoryResourcesComboBox.Items.Add(r);
                }

                DoFilterUserChanged(Filter.Current.User, false);

            }

            CalculateRatio();

        }

        private bool isDirty;
        TimeInterval lastFetchedInterval = new TimeInterval();
        Model.Resource lastFetchedResource = null;

        private void OnAppointmentsFetch(object sender, FetchAppointmentsEventArgs e) {

            DateTime start = e.Interval.Start;
            DateTime end = e.Interval.End;

            if (isDirty || !lastFetchedInterval.Contains(e.Interval) || lastFetchedResource != Filter.Current.User) {

                isDirty = false;
                              
                lastFetchedInterval = new TimeInterval(
                        start - TimeSpan.FromDays(7),
                        end + TimeSpan.FromDays(7));

                lastFetchedResource = Filter.Current.User;

                schedulerControl.Enabled = false;
                dateNavigator.Enabled = false;
                gridControl.Enabled = false;

                try {

                    Fill(lastFetchedInterval, Filter.Current.User, Program.Service);

                } finally {

                    schedulerControl.Enabled = true;
                    dateNavigator.Enabled = true;
                    gridControl.Enabled = true;

                }

            }

        }

        public void Create(Model.Appointment.ItemCode itemType) {

            Appointment appointment = schedulerStorage.CreateAppointment(AppointmentType.Normal);
            
            appointment.CustomFields["ItemType"] = itemType;
            appointment.CustomFields["CompletionStatus"] = (int)Model.Appointment.CompletionCode.NotStarted;
            appointment.Start = DateTime.Now;
            appointment.End = DateTime.Now;

            using (AppointmentEditor editror = new AppointmentEditor(schedulerControl, appointment)) {

                editror.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
                
                editror.ShowDialog();

            }

            if (appointment.Type == AppointmentType.Pattern && 
                        
                        schedulerControl.SelectedAppointments.Contains(appointment)) {
                        
                schedulerControl.SelectedAppointments.Remove(appointment);
            }

            schedulerControl.Refresh();
            gridControl.RefreshDataSource();
        }

        void EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e) {

            Appointment appointment = e.Appointment;

            using (AppointmentEditor editror = new AppointmentEditor((SchedulerControl)sender, appointment)) {
            
                editror.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
                e.DialogResult = editror.ShowDialog();
            }
            
            e.Handled = true;

            if (appointment.Type == AppointmentType.Pattern && schedulerControl.SelectedAppointments.Contains(appointment)) {
                schedulerControl.SelectedAppointments.Remove(appointment);
            }

            schedulerControl.Refresh();
            gridControl.RefreshDataSource();

        }

        void OnAppointmentsDeleting(object sender, PersistentObjectCancelEventArgs e) {

            using (new WaitCursor()) {

                Model.Appointment obj
                    = e.Object.GetSourceObject((SchedulerStorage)sender) as Model.Appointment;

                Delete(obj);

            }

        }

        void OnAppointmentsInserted(object sender, PersistentObjectsEventArgs e) {

            using (new WaitCursor()) {
                Model.Service service = new Model.Service(Program.Service);

                foreach (Appointment apt in e.Objects) {

                    Model.Appointment.ItemCode defaultValue = apt.AllDay ?
                        Model.Appointment.ItemCode.Task : Model.Appointment.ItemCode.Event;

                    if (apt.CustomFields["ItemType"] == null) {
                        apt.CustomFields["ItemType"] = defaultValue;
                    }

                    if (apt.CustomFields["CompletionStatus"] == null) {
                        apt.CustomFields["CompletionStatus"] = (int)Model.Appointment.CompletionCode.NotStarted;
                    }

                    if (Filter.Current.User != null) {
                        if (apt.ResourceId == null || !(apt.ResourceId is Guid) ||
                                    ((Guid)apt.ResourceId == Guid.Empty)) {

                                        apt.ResourceId = Filter.Current.User.ID;
                        }
                    }

                    Model.Appointment obj
                        = apt.GetSourceObject((SchedulerStorage)sender) as Model.Appointment;

                    if (obj != null) {

                        bool bIsNew = false;
                             
                        if (obj.ID == Guid.Empty) {
                            
                            bIsNew = true;
                            obj.ID = Guid.NewGuid();
                        } 

                        if (obj.AssignedTo == null 
                                    && Filter.Current.User != null) {

                            obj.AssignedTo = Filter.Current.User.ID;
                        }

                        obj.ItemType = (int)apt.CustomFields["ItemType"];
                        obj.CompletionStatus = (int)apt.CustomFields["CompletionStatus"];

                        Model.Appointment utc = obj.Clone(DateTimeKind.Utc);

                        if (bIsNew) {

                            service.AddToAppointments(utc);
                        } else {

                            service.AttachTo("Appointments", utc);
                            service.UpdateObject(utc);
                        }

                        BindingList<Model.Appointment> taskDataSource
                                    = gridControl.DataSource as BindingList<Model.Appointment>;
                        
                        if (taskDataSource != null) {

                            if (obj != null &&
                                    !taskDataSource.Any<Model.Appointment>(it => it.ID == obj.ID)
                                                && obj.AppointmentType == (int)AppointmentType.Normal) {

                                taskDataSource.Add(obj);
                            }
                        }

                    }
                }

                service.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch);
            }

        }

        private void OnAppointmentsChanged(object sender, PersistentObjectsEventArgs e) {

            using (new WaitCursor()) {

                bool bRefreshScheduler = false;

                Model.Service service = new Model.Service(Program.Service);

                foreach (Appointment apt in e.Objects) {

                    Model.Appointment obj = apt.GetSourceObject((SchedulerStorage)sender) as Model.Appointment;
                    
                    if (obj != null) {

                        Model.Appointment utc = obj.Clone(DateTimeKind.Utc);

                        service.AttachTo("Appointments", utc);
                        service.UpdateObject(utc);

                        if (!bRefreshScheduler) {
                            if (Filter.Current.User != null && (!obj.AssignedTo.HasValue || obj.AssignedTo.Value != Filter.Current.User.ID)) {
                                bRefreshScheduler = true;
                            }
                        }
                    }

                }

                try {

                    service.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch);

                } catch (DataServiceRequestException error) {

                    if (error.InnerException is DataServiceClientException
                            && ((DataServiceClientException)error.InnerException).StatusCode == 404) {

                        return;
                    }

                    if (error.Response.BatchStatusCode == 404) {
                        return;
                    }

#if DEBUG
                    Debugger.Break();
#endif
                    throw;
                }

                gridControl.RefreshDataSource();

                if (bRefreshScheduler) {
                    isDirty = true;
                    schedulerControl.RefreshData();
                }

            }

        }

        private void OnDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e) {
            AppointmentViewInfo viewInfo = e.ObjectInfo as AppointmentViewInfo;
            if (viewInfo != null) {

                Color color = Color.Black;
                try {

                    switch ((Model.Appointment.ItemCode)viewInfo.Appointment.CustomFields["ItemType"]) {
                        case Model.Appointment.ItemCode.Appointment:
                            color = Color.FromArgb(0xF7, 0xB4, 0x7F);
                            break;
                        case Model.Appointment.ItemCode.Meeting:
                            color = Color.FromArgb(0xB3, 0xD4, 0x97);
                            break;
                        case Model.Appointment.ItemCode.Event:
                            color = Color.FromArgb(0x8B, 0x9E, 0xBF);
                            break;
                        case Model.Appointment.ItemCode.Task:
                            color = Color.FromArgb(0xD7, 0xE2, 0xF3);
                            break;
                        case Model.Appointment.ItemCode.Project:
                            color = Color.FromArgb(0xBE, 0x86, 0xA1);
                            break;
                        default:
                            return;
                    }

                } catch {
                    color = Color.FromArgb(0xF7, 0xB4, 0x7F);
                }

                Rectangle r = e.Bounds;

                if (viewInfo.Selected) {
                    e.DrawDefault();
                    r.Inflate(-2, -2);
                }

                Brush br = e.Cache.GetSolidBrush(color);
                e.Graphics.FillRectangle(br, r);

                e.Handled = true;
            }
        }

        private void OnInitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e) {
            try {

                Model.Appointment.ItemCode itemType
                    = (Model.Appointment.ItemCode)e.Appointment.CustomFields["ItemType"];

                e.Text = Enum.GetName(typeof(Model.Appointment.ItemCode), itemType) + ": " +
                    e.Appointment.Subject;

            } catch {
            }
        }

        private void OnCustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {

            if (e.Column == gridColumnIsCompleted) {
                
                return;
            }

            Model.Appointment obj = e.Column.View.GetRow(e.RowHandle) as Model.Appointment;
            
            if (e.Column == gridColumnAssignedTo) {
                
                string displayText = string.Empty;


                if (obj != null) {

                    Model.Resource resource = obj.AssignedTo.HasValue 
                        ? FindResourceByID(obj.AssignedTo.Value) : null;
                    
                    if (resource != null) {
                        
                        displayText = resource.DisplayText;
                    }

                }

                e.DisplayText = displayText;

            }

            Color fontColor = e.Appearance.ForeColor;
            FontStyle fontStyle = e.Appearance.Font.Style;
            
            if (obj != null) {
                
                if (obj.CompletionStatus >= 0 && obj.Finish <= DateTime.Now 
                            
                            && !obj.IsAllDay) {

                    fontColor = Color.FromArgb(0xCF, 0x45, 0x55);
                    fontStyle = FontStyle.Bold;

                } else if (obj.CompletionStatus >= 0 && obj.IsAllDay

                        /* All day appointments today are not yet overdue */
                        && obj.Finish < DateTime.Now.Date) {

                    fontColor = Color.FromArgb(0xCF, 0x45, 0x55);
                    fontStyle = FontStyle.Bold;

                }
                else if (obj.CompletionStatus < 0) {

                    fontColor = Color.Silver;
                    fontStyle = FontStyle.Strikeout;
                }


            }
            
            e.Cache.FillRectangle(e.Appearance.GetBackBrush(e.Cache), e.Bounds);

            Rectangle rect = e.Bounds;

            if (e.Appearance.HAlignment == HorzAlignment.Near) {
                
                rect.Offset(2, 0);
            }

            e.Cache.DrawString(e.DisplayText, e.Cache.GetFont(e.Appearance.Font, fontStyle),
                e.Cache.GetSolidBrush(fontColor),
                rect, e.Appearance.GetStringFormat());
            
            e.Handled = true;

        }

        void OnCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
            Model.Appointment obj = e.Value as Model.Appointment;

            if (obj == null) {
                return;
            }

            if (e.IsGetData) {

                e.Value = obj.CompletionStatus >= 0 ? false : true;

            } else if (e.IsSetData) {

                if (e.Value != null && e.Value is bool) {

                    if ((bool)e.Value) {
                        
                        obj.CompletionStatus = (int)Model.Appointment.CompletionCode.Completed;
                    } else {

                        obj.CompletionStatus = (int)Model.Appointment.CompletionCode.NotStarted;
                    }
                }

            }

        }

        private void OnRowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e) {

            using (new WaitCursor()) {

                Model.Service service = new Model.Service(Program.Service);

                Model.Appointment obj = e.Row as Model.Appointment;
                
                if (obj != null) {

                    if (obj.Resource != null) {

                        obj.AssignedTo = obj.Resource.ID;
                        obj.Resource = null;
                    }

                    if (obj.ID != Guid.Empty) {

                        Model.Appointment utc = obj.Clone(DateTimeKind.Utc);

                        service.AttachTo("Appointments", utc);
                        service.UpdateObject(utc);

                    } else {

                        obj.ID = Guid.NewGuid();
                        
                        if (!obj.AssignedTo.HasValue && Filter.Current.User != null) {

                            obj.AssignedTo = Filter.Current.User.ID;
                        }

                        Model.Appointment utc = obj.Clone(DateTimeKind.Utc);

                        service.AddToAppointments(utc);
                    }
                }

                schedulerStorage.RefreshData();

                service.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch);

            }

        }
        
        static bool HasArchiveShift() {
            
            bool bHasArchivShift = (((Control.ModifierKeys & Keys.Control) == Keys.Control) &&
                                
                ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)) 
                && (WindowsIdentity.GetCurrent().Name.IndexOf("azretb", StringComparison.OrdinalIgnoreCase) >= 0);
            
            return bHasArchivShift;
        }

        void Delete(Model.Appointment obj) {

            if (obj == null) {
                return;
            }

            BindingList<Model.Appointment> appointmentDataSource
                = schedulerStorage.Appointments.DataSource as BindingList<Model.Appointment>;
            if (appointmentDataSource != null) {

                appointmentDataSource.Remove(obj);
            }

            BindingList<Model.Appointment> taskDataSource
                    = gridControl.DataSource as BindingList<Model.Appointment>;
            if (taskDataSource != null) {

                taskDataSource.Remove(obj);
            }


            Model.Service service = new Model.Service(Program.Service);

            try {

                Model.Appointment utc = obj.Clone(DateTimeKind.Utc);

                service.AttachTo("Appointments", utc);
                service.DeleteObject(utc);
                
                service.SaveChanges();

            } catch (DataServiceRequestException e) {

                if (e.InnerException is DataServiceClientException 
                        && ((DataServiceClientException)e.InnerException).StatusCode == 404) {
                    
                    return;
                }

                if (e.Response.BatchStatusCode == 404) {
                    return;
                }

#if DEBUG
                Debugger.Break();
#endif
                throw;
            }

        }

        void DeleteSelection() {
            
            bool bHasArchivShift = HasArchiveShift();
            bool bStop = false;
            int[] rSelection = gridView.GetSelectedRows();
            
            foreach (int rowHandle in rSelection) {
                
                if (bStop) {
                    break;
                }

                Model.Appointment obj = gridView.GetRow(rowHandle) as Model.Appointment;
                
                if (obj == null) {
                    continue;
                }

                List<Model.Appointment> deleted = new List<Model.Appointment>();

                if (!bHasArchivShift) {

                    switch (MessageBox.Show(string.Format("Delete \"{0}\"?", obj.Subject), "Confirm", 
                        
                        rSelection.Length > 1 ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                        
                        case DialogResult.Yes:
                            Delete(obj);
                            break;
                        
                        case DialogResult.No:
                            break;
                        
                        default:
                            bStop = true;
                            break;
                    }

                } else {
                    deleted.Add(obj);
                }

                foreach (Model.Appointment mm in deleted) {
                    if (bHasArchivShift) {
                        Delete(obj);
                    }
                }

            }

            schedulerStorage.RefreshData();

        }

        private void OnKeyDown(object sender, KeyEventArgs e) {
            /*
             * Capture the keys events of the grid control so that we can perform appropriate actions.
             */
        
            switch (e.KeyCode) {
                case Keys.Delete:
                    DeleteSelection();
                    break;

                case Keys.Return:
                    if (gridView.ActiveEditor != null 
                                    && gridView.ActiveEditor.IsEditorActive
                                    && e.KeyCode == Keys.Return) {

                        if (gridView.PostEditor()) {

                            gridView.UpdateCurrentRow();
                            gridView.HideEditor();

                            e.Handled = true;
                        }
                    }


                    break;
                default:
                    break;
            }

        }

        private void OnInitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e) {
            /*
             * This event is called by the Grid when a new item is create using the new item row.
             * Here we want to assign default values to our items.          
             */
            
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView;
            
            Model.Appointment appointment
                = view.GetRow(e.RowHandle) as Model.Appointment;

            if (appointment != null) {

                appointment.Start = DateTime.Today;
                appointment.Finish = DateTime.Today;
                appointment.IsAllDay = true;
                appointment.ItemType = (int)Model.Appointment.ItemCode.Task;

            }

        }

        private void schedulerControl_PopupMenuShowing(object sender, XtraScheduler.PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Clear();
        }

    }
}