Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports DevExpress.XtraScheduler
Imports DevExpress.Xpo
Imports System.Diagnostics
Imports DevExpress.XtraScheduler.Xml
Imports DevExpress.XtraScheduler.UI

Namespace DevExpress.Calendar.Parts

	Partial Public Class AppointmentEditor
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm
		Implements IDisposable

		Public Class Controller
			Inherits AppointmentFormController

			#Region "Notes"
			Public Property Notes() As String
				Get
					Dim value As Object = EditedAppointmentCopy.CustomFields("Notes")

					If value Is Nothing Then
						Return String.Empty
					End If

					Return CStr(value)
				End Get
				Set(ByVal value As String)
					EditedAppointmentCopy.CustomFields("Notes") = value
				End Set
			End Property

			Private Property SourceNotes() As String
				Get
					Dim value As Object = SourceAppointment.CustomFields("Notes")

					If value Is Nothing Then
						Return String.Empty
					End If

					Return CStr(value)
				End Get
				Set(ByVal value As String)
					SourceAppointment.CustomFields("Notes") = value
				End Set
			End Property

			#End Region

			#Region "CompletionStatus"
			Public Property CompletionStatus() As Integer
				Get
					Dim value As Object = EditedAppointmentCopy.CustomFields("CompletionStatus")

					If value Is Nothing Then
						Return CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
					End If

					Return CInt(Fix(value))
				End Get
				Set(ByVal value As Integer)
					EditedAppointmentCopy.CustomFields("CompletionStatus") = value
				End Set
			End Property

			Private Property SourceCompletionStatus() As Integer
				Get
					Dim value As Object = SourceAppointment.CustomFields("CompletionStatus")

					If value Is Nothing Then
						Return CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
					End If

					Return CInt(Fix(value))
				End Get
				Set(ByVal value As Integer)
					SourceAppointment.CustomFields("CompletionStatus") = value
				End Set
			End Property
			#End Region

			#Region "ItemType"
			Public Property ItemType() As Integer
				Get
					Dim value As Object = EditedAppointmentCopy.CustomFields("ItemType")

					If value Is Nothing Then
						Return CInt(Fix(Model.Appointment.ItemCode.Task))
					End If

					Return CInt(Fix(value))
				End Get
				Set(ByVal value As Integer)
					EditedAppointmentCopy.CustomFields("ItemType") = value
				End Set
			End Property

			Private Property SourceItemType() As Integer
				Get
					Dim value As Object = SourceAppointment.CustomFields("ItemType")

					If value Is Nothing Then
						Return CInt(Fix(Model.Appointment.ItemCode.Task))
					End If

					Return CInt(Fix(value))
				End Get
				Set(ByVal value As Integer)
					SourceAppointment.CustomFields("ItemType") = value
				End Set
			End Property
			#End Region

			Public Sub New(ByVal control As SchedulerControl, ByVal apt As Appointment)
				MyBase.New(control, apt)
			End Sub

			Public Overrides Function IsAppointmentChanged() As Boolean
				If MyBase.IsAppointmentChanged() Then
					Return True
				End If

				Return SourceCompletionStatus <> CompletionStatus OrElse Notes <> SourceNotes OrElse ItemType <> SourceItemType
			End Function

			Protected Overrides Sub ApplyCustomFieldsValues()
				SourceCompletionStatus = CompletionStatus
				SourceNotes = Notes
				SourceItemType = ItemType
			End Sub
		End Class

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If

			MyBase.Dispose(disposing)
		End Sub

		Private _suspendUpdateCount As Integer

		Protected ReadOnly Property IsUpdateSuspended() As Boolean
			Get
				Return _suspendUpdateCount > 0
			End Get
		End Property

		Protected Sub SuspendUpdate()
			_suspendUpdateCount += 1
		End Sub

		Protected Sub ResumeUpdate()
			If _suspendUpdateCount > 0 Then
				_suspendUpdateCount -= 1
			End If
		End Sub

		Public Sub New()
			InitializeComponent()
		End Sub

		Private _controller As Controller
		Private _scheduler As SchedulerControl
		Private _appointment As Appointment

		Private _ResourceId As Object

		Public Sub New(ByVal scheduler As SchedulerControl, ByVal appointment As Appointment)

			_controller = New Controller(scheduler, appointment)
			_appointment = appointment
			_scheduler = scheduler

			SuspendUpdate()
			Try

				InitializeComponent()

			Finally
				ResumeUpdate()
			End Try

			InitForm()

		End Sub

		Private Sub InitForm()
			SuspendUpdate()
			Try
				_ResourceId = _controller.ResourceId

				startDateEdit.DateTime = _controller.Start
				startTimeEdit.Time = _controller.Start
				endDateEdit.DateTime = _controller.End
				endTimeEdit.Time = _controller.End

				endTimeEdit.Properties.AllowNullInput = Utils.DefaultBoolean.True
				startTimeEdit.Properties.AllowNullInput = Utils.DefaultBoolean.True

				If _controller.AllDay Then
					startTimeEdit.EditValue = Nothing
					endTimeEdit.EditValue = Nothing
				End If

				subjectEdit.Text = _controller.Subject

				Select Case _controller.CompletionStatus
					Case CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
						statusEdit.SelectedIndex = 0

					Case CInt(Fix(Model.Appointment.CompletionCode.InProgress))
						statusEdit.SelectedIndex = 1

					Case CInt(Fix(Model.Appointment.CompletionCode.Canceled))
						statusEdit.SelectedIndex = 2

					Case CInt(Fix(Model.Appointment.CompletionCode.Completed))
						statusEdit.SelectedIndex = 3

					Case Else
						statusEdit.SelectedIndex = -1
				End Select


			Finally
				ResumeUpdate()
			End Try

			InitTitle()
		End Sub

		Private Sub InitTitle()

			Dim itemType As String = System.Enum.GetName(GetType(Model.Appointment.ItemCode), (CType(_controller.ItemType, Model.Appointment.ItemCode)))

			ribbonHomePage.Text = itemType

			If _controller.IsNewAppointment Then

				Text = "New " & itemType

			Else

				Text = "Edit " & itemType
			End If
		End Sub

		Private Sub OnSaveAndClose(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barButtonItemSaveAndClose.ItemClick
			If (Not _controller.IsConflictResolved()) Then
				Return
			End If

			_controller.ResourceId = _ResourceId

			Select Case statusEdit.SelectedIndex
				Case 0
					_controller.CompletionStatus = CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
				Case 1
					_controller.CompletionStatus = CInt(Fix(Model.Appointment.CompletionCode.InProgress))
				Case 2
					_controller.CompletionStatus = CInt(Fix(Model.Appointment.CompletionCode.Canceled))
				Case 3
					_controller.CompletionStatus = CInt(Fix(Model.Appointment.CompletionCode.Completed))
				Case Else
			End Select

			_controller.Subject = subjectEdit.Text.Trim()

			Dim startTime As DateTime

			If startTimeEdit.EditValue IsNot Nothing Then
				startTime = startTimeEdit.Time
			Else
				startTime = DateTime.MinValue
			End If

			Dim endTime As DateTime

			If endTimeEdit.EditValue IsNot Nothing Then
				endTime = endTimeEdit.Time
			Else
				endTime = DateTime.MaxValue
			End If

			_controller.Start = New DateTime(startDateEdit.DateTime.Year, startDateEdit.DateTime.Month, startDateEdit.DateTime.Day, startTime.Hour, startTime.Minute, startTime.Second)


			_controller.AllDay = startTimeEdit.EditValue Is Nothing AndAlso endTimeEdit.EditValue Is Nothing

			If _controller.AllDay Then
				_controller.End = _controller.Start.AddDays(1)
			Else
				_controller.End = New DateTime(endDateEdit.DateTime.Year, endDateEdit.DateTime.Month, endDateEdit.DateTime.Day, endTime.Hour, endTime.Minute, endTime.Second)
			End If

			_controller.Description = richEditControl.Text
			_controller.Notes = richEditControl.RtfText

			_controller.ApplyChanges()

			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub

	End Class
End Namespace