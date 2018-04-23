namespace DevExpress.Calendar.Parts {
    partial class Home {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryResourcesComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnAppointmentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemIsCompletedEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemDueDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryResourcesComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemIsCompletedEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDueDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDueDateEdit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator
            // 
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateNavigator.HotDate = null;
            this.dateNavigator.Location = new System.Drawing.Point(4, 0);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.SchedulerControl = this.schedulerControl;
            this.dateNavigator.Size = new System.Drawing.Size(191, 496);
            this.dateNavigator.TabIndex = 4;
            // 
            // schedulerControl
            // 
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(0, 32);
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Monday;
            this.schedulerControl.OptionsView.NavigationButtons.NextCaption = "Next";
            this.schedulerControl.OptionsView.NavigationButtons.PrevCaption = "Previous";
            this.schedulerControl.ResourceNavigator.Visibility = DevExpress.XtraScheduler.ResourceNavigatorVisibility.Never;
            this.schedulerControl.Size = new System.Drawing.Size(685, 184);
            this.schedulerControl.Start = new System.DateTime(2010, 7, 22, 0, 0, 0, 0);
            this.schedulerControl.Storage = this.schedulerStorage;
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Views.DayView.ResourcesPerPage = 1;
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.MonthView.ResourcesPerPage = 1;
            this.schedulerControl.Views.TimelineView.ResourcesPerPage = 1;
            this.schedulerControl.Views.WeekView.ResourcesPerPage = 1;
            this.schedulerControl.Views.WorkWeekView.ResourcesPerPage = 1;
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.InitAppointmentDisplayText += new DevExpress.XtraScheduler.AppointmentDisplayTextEventHandler(this.OnInitAppointmentDisplayText);
            this.schedulerControl.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.schedulerControl_PopupMenuShowing);
            this.schedulerControl.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.OnDrawAppointmentBackground);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(195, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 496);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.schedulerControl);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Controls.Add(this.splitterControl2);
            this.panel1.Controls.Add(this.gridControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 496);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 5);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(685, 27);
            this.panelControl1.TabIndex = 9;
            this.panelControl1.Visible = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl2.Location = new System.Drawing.Point(0, 216);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(685, 5);
            this.splitterControl2.TabIndex = 8;
            this.splitterControl2.TabStop = false;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl.Location = new System.Drawing.Point(0, 221);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDueDateEdit,
            this.repositoryResourcesComboBox,
            this.repositoryItemIsCompletedEdit});
            this.gridControl.Size = new System.Drawing.Size(685, 275);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView1});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSubject,
            this.gridColumnDue,
            this.gridColumnAssignedTo,
            this.gridColumnAppointmentType,
            this.gridColumnIsCompleted});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.Name = "gridView";
            this.gridView.NewItemRowText = "Click here to add a new task";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsDetail.AllowZoomDetail = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsDetail.SmartDetailExpand = false;
            this.gridView.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView.OptionsView.ShowColumnHeaders = false;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnDue, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnSubject
            // 
            this.gridColumnSubject.Caption = "Subject";
            this.gridColumnSubject.FieldName = "Subject";
            this.gridColumnSubject.Name = "gridColumnSubject";
            this.gridColumnSubject.Visible = true;
            this.gridColumnSubject.VisibleIndex = 0;
            this.gridColumnSubject.Width = 574;
            // 
            // gridColumnDue
            // 
            this.gridColumnDue.Caption = "Due";
            this.gridColumnDue.DisplayFormat.FormatString = "D";
            this.gridColumnDue.FieldName = "Finish";
            this.gridColumnDue.Name = "gridColumnDue";
            this.gridColumnDue.Width = 153;
            // 
            // gridColumnAssignedTo
            // 
            this.gridColumnAssignedTo.Caption = "Assigned To";
            this.gridColumnAssignedTo.ColumnEdit = this.repositoryResourcesComboBox;
            this.gridColumnAssignedTo.FieldName = "Resource";
            this.gridColumnAssignedTo.Name = "gridColumnAssignedTo";
            this.gridColumnAssignedTo.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.gridColumnAssignedTo.Visible = true;
            this.gridColumnAssignedTo.VisibleIndex = 1;
            this.gridColumnAssignedTo.Width = 82;
            // 
            // repositoryResourcesComboBox
            // 
            this.repositoryResourcesComboBox.AutoHeight = false;
            this.repositoryResourcesComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryResourcesComboBox.Name = "repositoryResourcesComboBox";
            this.repositoryResourcesComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridColumnAppointmentType
            // 
            this.gridColumnAppointmentType.Caption = "Appointment Type";
            this.gridColumnAppointmentType.FieldName = "AppointmentType";
            this.gridColumnAppointmentType.Name = "gridColumnAppointmentType";
            this.gridColumnAppointmentType.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumnIsCompleted
            // 
            this.gridColumnIsCompleted.Caption = "Completion Status";
            this.gridColumnIsCompleted.ColumnEdit = this.repositoryItemIsCompletedEdit;
            this.gridColumnIsCompleted.FieldName = "ColumnIsCompleted";
            this.gridColumnIsCompleted.Name = "gridColumnIsCompleted";
            this.gridColumnIsCompleted.OptionsColumn.FixedWidth = true;
            this.gridColumnIsCompleted.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumnIsCompleted.Visible = true;
            this.gridColumnIsCompleted.VisibleIndex = 2;
            this.gridColumnIsCompleted.Width = 32;
            // 
            // repositoryItemIsCompletedEdit
            // 
            this.repositoryItemIsCompletedEdit.AutoHeight = false;
            this.repositoryItemIsCompletedEdit.Name = "repositoryItemIsCompletedEdit";
            // 
            // repositoryItemDueDateEdit
            // 
            this.repositoryItemDueDateEdit.AutoHeight = false;
            this.repositoryItemDueDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDueDateEdit.Name = "repositoryItemDueDateEdit";
            this.repositoryItemDueDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.dateNavigator);
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.Size = new System.Drawing.Size(889, 500);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryResourcesComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemIsCompletedEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDueDateEdit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDueDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraScheduler.SchedulerStorage schedulerStorage;
        private XtraScheduler.DateNavigator dateNavigator;
        private XtraEditors.SplitterControl splitterControl1;
        private XtraScheduler.SchedulerControl schedulerControl;
        private System.Windows.Forms.Panel panel1;
        private XtraEditors.SplitterControl splitterControl2;
        private XtraGrid.GridControl gridControl;
        private XtraGrid.Views.Grid.GridView gridView;
        private XtraGrid.Columns.GridColumn gridColumnSubject;
        private XtraGrid.Columns.GridColumn gridColumnDue;
        private XtraGrid.Columns.GridColumn gridColumnAssignedTo;
        private XtraEditors.Repository.RepositoryItemComboBox repositoryResourcesComboBox;
        private XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDueDateEdit;
        private XtraGrid.Views.Grid.GridView gridView1;
        private XtraGrid.Columns.GridColumn gridColumnAppointmentType;
        private XtraGrid.Columns.GridColumn gridColumnIsCompleted;
        private XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemIsCompletedEdit;
        private XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
    }
}
