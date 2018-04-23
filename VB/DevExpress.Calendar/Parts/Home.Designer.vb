Imports Microsoft.VisualBasic
Imports System
Namespace DevExpress.Calendar.Parts
	Partial Public Class Home
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerStorage = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			Me.dateNavigator = New DevExpress.XtraScheduler.DateNavigator()
			Me.schedulerControl = New DevExpress.XtraScheduler.SchedulerControl()
			Me.splitterControl1 = New DevExpress.XtraEditors.SplitterControl()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.splitterControl2 = New DevExpress.XtraEditors.SplitterControl()
			Me.gridControl = New DevExpress.XtraGrid.GridControl()
			Me.gridView = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridColumnSubject = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnDue = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnAssignedTo = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryResourcesComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
			Me.gridColumnAppointmentType = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumnIsCompleted = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemIsCompletedEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
			Me.repositoryItemDueDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			CType(Me.schedulerStorage, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerControl, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panel1.SuspendLayout()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryResourcesComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemIsCompletedEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemDueDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemDueDateEdit.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dateNavigator
			' 
			Me.dateNavigator.Dock = System.Windows.Forms.DockStyle.Left
			Me.dateNavigator.HotDate = Nothing
			Me.dateNavigator.Location = New System.Drawing.Point(4, 0)
			Me.dateNavigator.Name = "dateNavigator"
			Me.dateNavigator.SchedulerControl = Me.schedulerControl
			Me.dateNavigator.Size = New System.Drawing.Size(191, 496)
			Me.dateNavigator.TabIndex = 4
			' 
			' schedulerControl
			' 
			Me.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl.Location = New System.Drawing.Point(0, 32)
			Me.schedulerControl.Name = "schedulerControl"
			Me.schedulerControl.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Monday
			Me.schedulerControl.OptionsView.NavigationButtons.NextCaption = "Next"
			Me.schedulerControl.OptionsView.NavigationButtons.PrevCaption = "Previous"
			Me.schedulerControl.ResourceNavigator.Visibility = DevExpress.XtraScheduler.ResourceNavigatorVisibility.Never
			Me.schedulerControl.Size = New System.Drawing.Size(685, 184)
			Me.schedulerControl.Start = New System.DateTime(2010, 7, 22, 0, 0, 0, 0)
			Me.schedulerControl.Storage = Me.schedulerStorage
			Me.schedulerControl.TabIndex = 0
			Me.schedulerControl.Views.DayView.ResourcesPerPage = 1
			Me.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl.Views.MonthView.ResourcesPerPage = 1
			Me.schedulerControl.Views.TimelineView.ResourcesPerPage = 1
			Me.schedulerControl.Views.WeekView.ResourcesPerPage = 1
			Me.schedulerControl.Views.WorkWeekView.ResourcesPerPage = 1
			Me.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
'			Me.schedulerControl.InitAppointmentDisplayText += New DevExpress.XtraScheduler.AppointmentDisplayTextEventHandler(Me.OnInitAppointmentDisplayText);
'			Me.schedulerControl.PopupMenuShowing += New DevExpress.XtraScheduler.PopupMenuShowingEventHandler(Me.schedulerControl_PopupMenuShowing);
'			Me.schedulerControl.CustomDrawAppointmentBackground += New DevExpress.XtraScheduler.CustomDrawObjectEventHandler(Me.OnDrawAppointmentBackground);
			' 
			' splitterControl1
			' 
			Me.splitterControl1.Location = New System.Drawing.Point(195, 0)
			Me.splitterControl1.Name = "splitterControl1"
			Me.splitterControl1.Size = New System.Drawing.Size(5, 496)
			Me.splitterControl1.TabIndex = 5
			Me.splitterControl1.TabStop = False
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.schedulerControl)
			Me.panel1.Controls.Add(Me.panel2)
			Me.panel1.Controls.Add(Me.panelControl1)
			Me.panel1.Controls.Add(Me.splitterControl2)
			Me.panel1.Controls.Add(Me.gridControl)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panel1.Location = New System.Drawing.Point(200, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(685, 496)
			Me.panel1.TabIndex = 3
			' 
			' panel2
			' 
			Me.panel2.BackColor = System.Drawing.Color.Transparent
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel2.Location = New System.Drawing.Point(0, 27)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(685, 5)
			Me.panel2.TabIndex = 10
			Me.panel2.Visible = False
			' 
			' panelControl1
			' 
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(685, 27)
			Me.panelControl1.TabIndex = 9
			Me.panelControl1.Visible = False
			' 
			' splitterControl2
			' 
			Me.splitterControl2.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.splitterControl2.Location = New System.Drawing.Point(0, 216)
			Me.splitterControl2.Name = "splitterControl2"
			Me.splitterControl2.Size = New System.Drawing.Size(685, 5)
			Me.splitterControl2.TabIndex = 8
			Me.splitterControl2.TabStop = False
			' 
			' gridControl
			' 
			Me.gridControl.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.gridControl.Location = New System.Drawing.Point(0, 221)
			Me.gridControl.MainView = Me.gridView
			Me.gridControl.Name = "gridControl"
			Me.gridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemDueDateEdit, Me.repositoryResourcesComboBox, Me.repositoryItemIsCompletedEdit})
			Me.gridControl.Size = New System.Drawing.Size(685, 275)
			Me.gridControl.TabIndex = 7
			Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView, Me.gridView1})
			' 
			' gridView
			' 
			Me.gridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumnSubject, Me.gridColumnDue, Me.gridColumnAssignedTo, Me.gridColumnAppointmentType, Me.gridColumnIsCompleted})
			Me.gridView.GridControl = Me.gridControl
			Me.gridView.GroupCount = 1
			Me.gridView.Name = "gridView"
			Me.gridView.NewItemRowText = "Click here to add a new task"
			Me.gridView.OptionsBehavior.AutoExpandAllGroups = True
			Me.gridView.OptionsDetail.AllowZoomDetail = False
			Me.gridView.OptionsDetail.EnableMasterViewMode = False
			Me.gridView.OptionsDetail.ShowDetailTabs = False
			Me.gridView.OptionsDetail.SmartDetailExpand = False
			Me.gridView.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003
			Me.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
			Me.gridView.OptionsView.ShowColumnHeaders = False
			Me.gridView.OptionsView.ShowDetailButtons = False
			Me.gridView.OptionsView.ShowGroupPanel = False
			Me.gridView.OptionsView.ShowIndicator = False
			Me.gridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.gridColumnDue, DevExpress.Data.ColumnSortOrder.Ascending)})
			' 
			' gridColumnSubject
			' 
			Me.gridColumnSubject.Caption = "Subject"
			Me.gridColumnSubject.FieldName = "Subject"
			Me.gridColumnSubject.Name = "gridColumnSubject"
			Me.gridColumnSubject.Visible = True
			Me.gridColumnSubject.VisibleIndex = 0
			Me.gridColumnSubject.Width = 574
			' 
			' gridColumnDue
			' 
			Me.gridColumnDue.Caption = "Due"
			Me.gridColumnDue.DisplayFormat.FormatString = "D"
			Me.gridColumnDue.FieldName = "Finish"
			Me.gridColumnDue.Name = "gridColumnDue"
			Me.gridColumnDue.Width = 153
			' 
			' gridColumnAssignedTo
			' 
			Me.gridColumnAssignedTo.Caption = "Assigned To"
			Me.gridColumnAssignedTo.ColumnEdit = Me.repositoryResourcesComboBox
			Me.gridColumnAssignedTo.FieldName = "Resource"
			Me.gridColumnAssignedTo.Name = "gridColumnAssignedTo"
			Me.gridColumnAssignedTo.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
			Me.gridColumnAssignedTo.Visible = True
			Me.gridColumnAssignedTo.VisibleIndex = 1
			Me.gridColumnAssignedTo.Width = 82
			' 
			' repositoryResourcesComboBox
			' 
			Me.repositoryResourcesComboBox.AutoHeight = False
			Me.repositoryResourcesComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repositoryResourcesComboBox.Name = "repositoryResourcesComboBox"
			Me.repositoryResourcesComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
			' 
			' gridColumnAppointmentType
			' 
			Me.gridColumnAppointmentType.Caption = "Appointment Type"
			Me.gridColumnAppointmentType.FieldName = "AppointmentType"
			Me.gridColumnAppointmentType.Name = "gridColumnAppointmentType"
			Me.gridColumnAppointmentType.OptionsColumn.ShowInCustomizationForm = False
			' 
			' gridColumnIsCompleted
			' 
			Me.gridColumnIsCompleted.Caption = "Completion Status"
			Me.gridColumnIsCompleted.ColumnEdit = Me.repositoryItemIsCompletedEdit
			Me.gridColumnIsCompleted.FieldName = "ColumnIsCompleted"
			Me.gridColumnIsCompleted.Name = "gridColumnIsCompleted"
			Me.gridColumnIsCompleted.OptionsColumn.FixedWidth = True
			Me.gridColumnIsCompleted.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
			Me.gridColumnIsCompleted.Visible = True
			Me.gridColumnIsCompleted.VisibleIndex = 2
			Me.gridColumnIsCompleted.Width = 32
			' 
			' repositoryItemIsCompletedEdit
			' 
			Me.repositoryItemIsCompletedEdit.AutoHeight = False
			Me.repositoryItemIsCompletedEdit.Name = "repositoryItemIsCompletedEdit"
			' 
			' repositoryItemDueDateEdit
			' 
			Me.repositoryItemDueDateEdit.AutoHeight = False
			Me.repositoryItemDueDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repositoryItemDueDateEdit.Name = "repositoryItemDueDateEdit"
			Me.repositoryItemDueDateEdit.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl
			Me.gridView1.Name = "gridView1"
			' 
			' Home
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.splitterControl1)
			Me.Controls.Add(Me.dateNavigator)
			Me.Name = "Home"
			Me.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
			Me.Size = New System.Drawing.Size(889, 500)
			CType(Me.schedulerStorage, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateNavigator, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerControl, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panel1.ResumeLayout(False)
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryResourcesComboBox, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemIsCompletedEdit, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemDueDateEdit.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemDueDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private schedulerStorage As XtraScheduler.SchedulerStorage
		Private dateNavigator As XtraScheduler.DateNavigator
		Private splitterControl1 As XtraEditors.SplitterControl
		Private WithEvents schedulerControl As XtraScheduler.SchedulerControl
		Private panel1 As System.Windows.Forms.Panel
		Private splitterControl2 As XtraEditors.SplitterControl
		Private gridControl As XtraGrid.GridControl
		Private gridView As XtraGrid.Views.Grid.GridView
		Private gridColumnSubject As XtraGrid.Columns.GridColumn
		Private gridColumnDue As XtraGrid.Columns.GridColumn
		Private gridColumnAssignedTo As XtraGrid.Columns.GridColumn
		Private repositoryResourcesComboBox As XtraEditors.Repository.RepositoryItemComboBox
		Private repositoryItemDueDateEdit As XtraEditors.Repository.RepositoryItemDateEdit
		Private gridView1 As XtraGrid.Views.Grid.GridView
		Private gridColumnAppointmentType As XtraGrid.Columns.GridColumn
		Private gridColumnIsCompleted As XtraGrid.Columns.GridColumn
		Private repositoryItemIsCompletedEdit As XtraEditors.Repository.RepositoryItemCheckEdit
		Private panelControl1 As XtraEditors.PanelControl
		Private panel2 As System.Windows.Forms.Panel
	End Class
End Namespace
