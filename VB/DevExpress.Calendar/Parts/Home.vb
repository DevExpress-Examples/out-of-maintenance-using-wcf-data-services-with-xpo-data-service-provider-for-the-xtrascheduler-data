Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraScheduler
Imports DevExpress.Xpo
Imports System.Configuration
Imports DevExpress.Data.Filtering
Imports System.Linq
Imports System.Security.Principal
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.Utils
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Data.Services.Client
Imports System.Threading
Imports System.Diagnostics
Imports DevExpress.XtraGrid.Views.Grid

Namespace DevExpress.Calendar.Parts
	Partial Public Class Home
		Inherits DevExpress.XtraEditors.XtraUserControl
		Implements ICalendar

		#Region "OnResize"
		Private _ratio As Integer = -1

		Private Sub CalculateRatio()
            _ratio = CType((Me.gridControl.Height * 100) / Me.Height, Integer)
		End Sub

		Protected Overrides Sub OnResize(ByVal e As EventArgs)
			MyBase.OnResize(e)
			If _ratio > 0 Then
                Me.gridControl.Height = CType((Me._ratio * Me.Height) / 100, Integer)
			End If
		End Sub
		#End Region

		Private Function FindUserByUserName(ByVal userName As String) As Model.Resource
			If String.IsNullOrEmpty(userName) Then

				Return Nothing
			End If

			Dim dataSource As Collection(Of Model.Resource) = TryCast(schedulerStorage.Resources.DataSource, Collection(Of Model.Resource))

			If dataSource Is Nothing Then

				Return Nothing
			End If

			For Each r As Model.Resource In dataSource

				If (Not String.IsNullOrEmpty(r.UserName)) AndAlso r.UserName.ToLower().Contains(userName.ToLower()) Then

					Return r
				End If
			Next r

			Return Nothing
		End Function

		Private Function FindResourceByID(ByVal id As Guid) As Model.Resource

			Dim dataSource As Collection(Of Model.Resource) = TryCast(schedulerStorage.Resources.DataSource, Collection(Of Model.Resource))

			If dataSource Is Nothing Then

				Return Nothing
			End If

			For Each r As Model.Resource In dataSource

				If (Not String.IsNullOrEmpty(r.UserName)) AndAlso r.ID = id Then

					Return r
				End If
			Next r

			Return Nothing
		End Function

		Private Shared Function CreateDataSourceForResources() As Collection(Of Model.Resource)

			Dim Query = _
				From p In New Model.Service(Program.Service).Resources _
				Order By p.Name _
				Select p

				Dim dataSource As New Collection(Of Model.Resource)()

				For Each resource As Model.Resource In Query
					dataSource.Add(resource)
				Next resource

				Return dataSource



		End Function

		Private Shared Function CreateDataSourceForTasks() As BindingList(Of Model.Appointment)

			Return New BindingList(Of Model.Appointment)()
		End Function

		Private Shared Function CreateDataSourceForAppointments() As BindingList(Of Model.Appointment)

			Return New BindingList(Of Model.Appointment)()
		End Function

		Public Sub Fill(ByVal e As TimeInterval, ByVal resource As Model.Resource, ByVal uri As Uri)

#If DEBUG Then
			Debug.WriteLine(e)
#End If

			Dim schedulerDataSource As BindingList(Of Model.Appointment) = TryCast(schedulerStorage.Appointments.DataSource, BindingList(Of Model.Appointment))

			If schedulerDataSource Is Nothing Then

				Return
			End If

			SyncLock schedulerDataSource

				Dim service As New DevExpress.Calendar.Model.Service(uri)

				Dim now As DateTime = DateTime.UtcNow

				Dim start As DateTime = e.Start.ToUniversalTime()
				Dim [end] As DateTime = e.End.ToUniversalTime()

				Dim weekStart As DateTime = now.AddDays(-7)
				Dim weekEnd As DateTime = now.AddDays(7)

				Dim query As DataServiceQuery(Of Model.Appointment)

				If resource Is Nothing Then

					query = CType(service.Appointments.Where(Function(s) (s.Finish <= now AndAlso s.CompletionStatus >= 0) OrElse (s.AppointmentType = CInt(Fix(AppointmentType.Pattern))) OrElse ((s.Start >= start AndAlso s.Start <= [end]) OrElse (s.Finish >= start AndAlso s.Finish <= [end])) OrElse ((s.Start >= weekStart AndAlso s.Start <= weekEnd) OrElse (s.Finish >= weekStart AndAlso s.Finish <= weekEnd))), DataServiceQuery(Of Model.Appointment))

				Else

					query = CType(service.Appointments.Where(Function(s) (s.Resource.ID = resource.ID) AndAlso ((s.AppointmentType = CInt(Fix(AppointmentType.Pattern))) OrElse (s.Finish <= now AndAlso s.CompletionStatus >= 0) OrElse ((s.Start >= start AndAlso s.Start <= [end]) OrElse (s.Finish >= start AndAlso s.Finish <= [end])) OrElse ((s.Start >= weekStart AndAlso s.Start <= weekEnd) OrElse (s.Finish >= weekStart AndAlso s.Finish <= weekEnd)))), DataServiceQuery(Of Model.Appointment))
				End If

				Using TempWaitCursor As WaitCursor = New WaitCursor()

					SuspendLayout()

					schedulerControl.BeginUpdate()
					schedulerStorage.BeginUpdate()

					gridControl.BeginUpdate()
					gridView.BeginUpdate()

					Try

						Dim taskDataSource As BindingList(Of Model.Appointment) = TryCast(gridControl.DataSource, BindingList(Of Model.Appointment))

						schedulerDataSource.Clear()

						If taskDataSource IsNot Nothing Then
							taskDataSource.Clear()
						End If

						If query IsNot Nothing Then

							For Each s As DevExpress.Calendar.Model.Appointment In query
								Dim local As DevExpress.Calendar.Model.Appointment = s.Clone(DateTimeKind.Local)

								schedulerDataSource.Add(local)

								If taskDataSource IsNot Nothing Then
									If local.AppointmentType = CInt(Fix(AppointmentType.Normal)) Then
										taskDataSource.Add(local)
									End If
								End If
							Next s
						End If

					Finally

						gridView.EndUpdate()
						gridControl.EndUpdate()

						schedulerStorage.EndUpdate()
						schedulerControl.EndUpdate()

						ResumeLayout()
					End Try

				End Using
			End SyncLock
		End Sub

		Private Sub DoFilterUserChanged(ByVal sender As Object, ByVal bRefreshDataSource As Boolean)

			schedulerControl.BeginUpdate()
			schedulerStorage.BeginUpdate()

			Try

				gridControl.BeginUpdate()
				Try

					Dim user As Model.Resource = TryCast(sender, Model.Resource)

					If user IsNot Nothing Then

						schedulerControl.Views.DayView.ResourcesPerPage = 1
						schedulerControl.Views.MonthView.ResourcesPerPage = 1
						schedulerControl.Views.TimelineView.ResourcesPerPage = 1
						schedulerControl.Views.WeekView.ResourcesPerPage = 1
						schedulerControl.Views.WorkWeekView.ResourcesPerPage = 1
						schedulerControl.GroupType = SchedulerGroupType.None
						gridColumnAssignedTo.Visible = False
						gridColumnAssignedTo.OptionsColumn.ShowInCustomizationForm = False

					Else

						schedulerControl.GroupType = SchedulerGroupType.Resource
						schedulerControl.Views.DayView.ResourcesPerPage = 5
						schedulerControl.Views.MonthView.ResourcesPerPage = 5
						schedulerControl.Views.TimelineView.ResourcesPerPage = 5
						schedulerControl.Views.WeekView.ResourcesPerPage = 5
						schedulerControl.Views.WorkWeekView.ResourcesPerPage = 5
						gridColumnAssignedTo.Visible = True
						gridColumnAssignedTo.OptionsColumn.ShowInCustomizationForm = True

					End If

					If bRefreshDataSource Then
						schedulerControl.RefreshData()
					End If

				Finally
					gridControl.EndUpdate()
				End Try

			Finally

				schedulerStorage.EndUpdate()
				schedulerControl.EndUpdate()
			End Try

		End Sub

		Private Sub OnFilterUserChanged(ByVal sender As Object, ByVal e As EventArgs)
			DoFilterUserChanged(sender, True)
		End Sub

		Private Sub OnFilterResource(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
			If Filter.Current.User Is Nothing Then

				e.Cancel = False

			Else

				e.Cancel = (CType(e.Object.GetSourceObject(schedulerStorage), Model.Resource)).ID <> Filter.Current.User.ID
			End If
		End Sub

		Public Sub New()
			InitializeComponent()

			AddHandler Filter.Current.UserChanged, AddressOf OnFilterUserChanged

			schedulerStorage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("ItemType", "ItemType", FieldValueType.Integer))

			schedulerStorage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("CompletionStatus", "CompletionStatus", FieldValueType.Integer))

			schedulerStorage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("Notes", "Notes", FieldValueType.String))

			schedulerStorage.Appointments.Mappings.AllDay = "IsAllDay"
			schedulerStorage.Appointments.Mappings.Description = "Description"
			schedulerStorage.Appointments.Mappings.End = "Finish"
			schedulerStorage.Appointments.Mappings.Label = "Label"
			schedulerStorage.Appointments.Mappings.Location = "Location"

			' schedulerStorage.Appointments.Mappings.RecurrenceInfo = "Recurrence"; 
			' schedulerStorage.Appointments.Mappings.ReminderInfo = "Reminder"; 

			schedulerStorage.Appointments.Mappings.Start = "Start"
			schedulerStorage.Appointments.Mappings.Status = "Status"
			schedulerStorage.Appointments.Mappings.Subject = "Subject"
			schedulerStorage.Appointments.Mappings.Type = "AppointmentType"

			schedulerStorage.Appointments.Mappings.ResourceId = "AssignedTo"
			schedulerStorage.Resources.Mappings.Id = "ID"
			schedulerStorage.Resources.Mappings.Caption = "DisplayText"

			AddHandler schedulerStorage.AppointmentsChanged, AddressOf OnAppointmentsChanged
			AddHandler schedulerStorage.AppointmentsInserted, AddressOf OnAppointmentsInserted
			AddHandler schedulerStorage.AppointmentDeleting, AddressOf OnAppointmentsDeleting
			AddHandler schedulerStorage.FetchAppointments, AddressOf OnAppointmentsFetch
			AddHandler schedulerStorage.FilterResource, AddressOf OnFilterResource

			schedulerControl.Start = DateTime.Today
			schedulerControl.GroupType = SchedulerGroupType.Resource
			schedulerControl.ResourceNavigator.Visibility = ResourceNavigatorVisibility.Auto
			schedulerControl.Views.DayView.ResourcesPerPage = 4

			AddHandler schedulerControl.EditAppointmentFormShowing, AddressOf EditAppointmentFormShowing

			AddHandler gridView.KeyDown, AddressOf OnKeyDown
			AddHandler gridView.RowUpdated, AddressOf OnRowUpdated
			AddHandler gridView.InitNewRow, AddressOf OnInitNewRow
			AddHandler gridView.CustomDrawCell, AddressOf OnCustomDrawCell
			AddHandler gridView.CustomUnboundColumnData, AddressOf OnCustomUnboundColumnData

			If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then

				schedulerStorage.Appointments.DataSource = CreateDataSourceForAppointments()
				schedulerStorage.Resources.DataSource = CreateDataSourceForResources()
				gridControl.DataSource = CreateDataSourceForTasks()

				For Each r As Model.Resource In CType(schedulerStorage.Resources.DataSource, Collection(Of Model.Resource))

					repositoryResourcesComboBox.Items.Add(r)
				Next r

				DoFilterUserChanged(Filter.Current.User, False)

			End If

			CalculateRatio()

		End Sub

		Private isDirty As Boolean
		Private lastFetchedInterval As New TimeInterval()
		Private lastFetchedResource As Model.Resource = Nothing

		Private Sub OnAppointmentsFetch(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)

			Dim start As DateTime = e.Interval.Start
			Dim [end] As DateTime = e.Interval.End

			If isDirty OrElse (Not lastFetchedInterval.Contains(e.Interval)) OrElse lastFetchedResource IsNot Filter.Current.User Then

				isDirty = False

				lastFetchedInterval = New TimeInterval(start - TimeSpan.FromDays(7), [end] + TimeSpan.FromDays(7))

				lastFetchedResource = Filter.Current.User

				schedulerControl.Enabled = False
				dateNavigator.Enabled = False
				gridControl.Enabled = False

				Try

					Fill(lastFetchedInterval, Filter.Current.User, Program.Service)

				Finally

					schedulerControl.Enabled = True
					dateNavigator.Enabled = True
					gridControl.Enabled = True

				End Try

			End If

		End Sub

		Public Sub Create(ByVal itemType As Model.Appointment.ItemCode) Implements ICalendar.Create

			Dim appointment As Appointment = schedulerStorage.CreateAppointment(AppointmentType.Normal)

			appointment.CustomFields("ItemType") = itemType
			appointment.CustomFields("CompletionStatus") = CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
			appointment.Start = DateTime.Now
			appointment.End = DateTime.Now

			Using editror As New AppointmentEditor(schedulerControl, appointment)

				editror.LookAndFeel.ParentLookAndFeel = Me.LookAndFeel.ParentLookAndFeel

				editror.ShowDialog()

			End Using

			If appointment.Type = AppointmentType.Pattern AndAlso schedulerControl.SelectedAppointments.Contains(appointment) Then

				schedulerControl.SelectedAppointments.Remove(appointment)
			End If

			schedulerControl.Refresh()
			gridControl.RefreshDataSource()
		End Sub

		Private Sub EditAppointmentFormShowing(ByVal sender As Object, ByVal e As AppointmentFormEventArgs)

			Dim appointment As Appointment = e.Appointment

			Using editror As New AppointmentEditor(CType(sender, SchedulerControl), appointment)

				editror.LookAndFeel.ParentLookAndFeel = Me.LookAndFeel.ParentLookAndFeel
				e.DialogResult = editror.ShowDialog()
			End Using

			e.Handled = True

			If appointment.Type = AppointmentType.Pattern AndAlso schedulerControl.SelectedAppointments.Contains(appointment) Then
				schedulerControl.SelectedAppointments.Remove(appointment)
			End If

			schedulerControl.Refresh()
			gridControl.RefreshDataSource()

		End Sub

		Private Sub OnAppointmentsDeleting(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)

			Using TempWaitCursor As WaitCursor = New WaitCursor()

				Dim obj As Model.Appointment = TryCast(e.Object.GetSourceObject(CType(sender, SchedulerStorage)), Model.Appointment)

				Delete(obj)

			End Using

		End Sub

		Private Sub OnAppointmentsInserted(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)

			Using TempWaitCursor As WaitCursor = New WaitCursor()
				Dim service As New Model.Service(Program.Service)

				For Each apt As Appointment In e.Objects

					Dim defaultValue As Model.Appointment.ItemCode = If(apt.AllDay, Model.Appointment.ItemCode.Task, Model.Appointment.ItemCode.Event)

					If apt.CustomFields("ItemType") Is Nothing Then
						apt.CustomFields("ItemType") = defaultValue
					End If

					If apt.CustomFields("CompletionStatus") Is Nothing Then
						apt.CustomFields("CompletionStatus") = CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
					End If

					If Filter.Current.User IsNot Nothing Then
                        If apt.ResourceId Is Nothing OrElse Not (TypeOf apt.ResourceId Is Guid) OrElse (CType(apt.ResourceId, Guid) = Guid.Empty) Then

                            apt.ResourceId = Filter.Current.User.ID
                        End If
					End If

					Dim obj As Model.Appointment = TryCast(apt.GetSourceObject(CType(sender, SchedulerStorage)), Model.Appointment)

					If obj IsNot Nothing Then

						Dim bIsNew As Boolean = False

						If obj.ID = Guid.Empty Then

							bIsNew = True
							obj.ID = Guid.NewGuid()
						End If

						If obj.AssignedTo Is Nothing AndAlso Filter.Current.User IsNot Nothing Then

							obj.AssignedTo = Filter.Current.User.ID
						End If

						obj.ItemType = CInt(Fix(apt.CustomFields("ItemType")))
						obj.CompletionStatus = CInt(Fix(apt.CustomFields("CompletionStatus")))

						Dim utc As Model.Appointment = obj.Clone(DateTimeKind.Utc)

						If bIsNew Then

							service.AddToAppointments(utc)
						Else

							service.AttachTo("Appointments", utc)
							service.UpdateObject(utc)
						End If

						Dim taskDataSource As BindingList(Of Model.Appointment) = TryCast(gridControl.DataSource, BindingList(Of Model.Appointment))

						If taskDataSource IsNot Nothing Then

                            If obj IsNot Nothing AndAlso (Not taskDataSource.Any(Function(it As Model.Appointment) it.ID = obj.ID) AndAlso obj.AppointmentType = CInt(Fix(AppointmentType.Normal))) Then

                                taskDataSource.Add(obj)
                            End If
						End If

					End If
				Next apt

				service.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch)
			End Using

		End Sub

		Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)

			Using TempWaitCursor As WaitCursor = New WaitCursor()

				Dim bRefreshScheduler As Boolean = False

				Dim service As New Model.Service(Program.Service)

				For Each apt As Appointment In e.Objects

					Dim obj As Model.Appointment = TryCast(apt.GetSourceObject(CType(sender, SchedulerStorage)), Model.Appointment)

					If obj IsNot Nothing Then

						Dim utc As Model.Appointment = obj.Clone(DateTimeKind.Utc)

						service.AttachTo("Appointments", utc)
						service.UpdateObject(utc)

						If (Not bRefreshScheduler) Then
							If Filter.Current.User IsNot Nothing AndAlso ((Not obj.AssignedTo.HasValue) OrElse obj.AssignedTo.Value <> Filter.Current.User.ID) Then
								bRefreshScheduler = True
							End If
						End If
					End If

				Next apt

				Try

					service.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch)

				Catch [error] As DataServiceRequestException

					If TypeOf [error].InnerException Is DataServiceClientException AndAlso (CType([error].InnerException, DataServiceClientException)).StatusCode = 404 Then

						Return
					End If

					If [error].Response.BatchStatusCode = 404 Then
						Return
					End If

#If DEBUG Then
					Debugger.Break()
#End If
					Throw
				End Try

				gridControl.RefreshDataSource()

				If bRefreshScheduler Then
					isDirty = True
					schedulerControl.RefreshData()
				End If

			End Using

		End Sub

		Private Sub OnDrawAppointmentBackground(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs) Handles schedulerControl.CustomDrawAppointmentBackground
			Dim viewInfo As AppointmentViewInfo = TryCast(e.ObjectInfo, AppointmentViewInfo)
			If viewInfo IsNot Nothing Then

				Dim color As Color = Color.Black
				Try

					Select Case CType(viewInfo.Appointment.CustomFields("ItemType"), Model.Appointment.ItemCode)
						Case Model.Appointment.ItemCode.Appointment
							color = Color.FromArgb(&HF7, &HB4, &H7F)
						Case Model.Appointment.ItemCode.Meeting
							color = Color.FromArgb(&HB3, &HD4, &H97)
						Case Model.Appointment.ItemCode.Event
							color = Color.FromArgb(&H8B, &H9E, &HBF)
						Case Model.Appointment.ItemCode.Task
							color = Color.FromArgb(&HD7, &HE2, &HF3)
						Case Model.Appointment.ItemCode.Project
							color = Color.FromArgb(&HBE, &H86, &HA1)
						Case Else
							Return
					End Select

				Catch
					color = Color.FromArgb(&HF7, &HB4, &H7F)
				End Try

				Dim r As Rectangle = e.Bounds

				If viewInfo.Selected Then
					e.DrawDefault()
					r.Inflate(-2, -2)
				End If

				Dim br As Brush = e.Cache.GetSolidBrush(color)
				e.Graphics.FillRectangle(br, r)

				e.Handled = True
			End If
		End Sub

		Private Sub OnInitAppointmentDisplayText(ByVal sender As Object, ByVal e As AppointmentDisplayTextEventArgs) Handles schedulerControl.InitAppointmentDisplayText
			Try

				Dim itemType As Model.Appointment.ItemCode = CType(e.Appointment.CustomFields("ItemType"), Model.Appointment.ItemCode)

				e.Text = System.Enum.GetName(GetType(Model.Appointment.ItemCode), itemType) & ": " & e.Appointment.Subject

			Catch
			End Try
		End Sub

		Private Sub OnCustomDrawCell(ByVal sender As Object, ByVal e As XtraGrid.Views.Base.RowCellCustomDrawEventArgs)

			If e.Column Is gridColumnIsCompleted Then

				Return
			End If

			Dim obj As Model.Appointment = TryCast(e.Column.View.GetRow(e.RowHandle), Model.Appointment)

			If e.Column Is gridColumnAssignedTo Then

				Dim displayText As String = String.Empty


				If obj IsNot Nothing Then

					Dim resource As Model.Resource = If(obj.AssignedTo.HasValue, FindResourceByID(obj.AssignedTo.Value), Nothing)

					If resource IsNot Nothing Then

						displayText = resource.DisplayText
					End If

				End If

				e.DisplayText = displayText

			End If

			Dim fontColor As Color = e.Appearance.ForeColor
			Dim fontStyle As FontStyle = e.Appearance.Font.Style

			If obj IsNot Nothing Then

				If obj.CompletionStatus >= 0 AndAlso obj.Finish <= DateTime.Now AndAlso (Not obj.IsAllDay) Then

					fontColor = Color.FromArgb(&HCF, &H45, &H55)
					fontStyle = FontStyle.Bold

				ElseIf obj.CompletionStatus >= 0 AndAlso obj.IsAllDay AndAlso obj.Finish < DateTime.Now.Date Then

					fontColor = Color.FromArgb(&HCF, &H45, &H55)
					fontStyle = FontStyle.Bold

				ElseIf obj.CompletionStatus < 0 Then

					fontColor = Color.Silver
					fontStyle = FontStyle.Strikeout
				End If


			End If

			e.Cache.FillRectangle(e.Appearance.GetBackBrush(e.Cache), e.Bounds)

			Dim rect As Rectangle = e.Bounds

			If e.Appearance.HAlignment = HorzAlignment.Near Then

				rect.Offset(2, 0)
			End If

			e.Cache.DrawString(e.DisplayText, e.Cache.GetFont(e.Appearance.Font, fontStyle), e.Cache.GetSolidBrush(fontColor), rect, e.Appearance.GetStringFormat())

			e.Handled = True

		End Sub

		Private Sub OnCustomUnboundColumnData(ByVal sender As Object, ByVal e As XtraGrid.Views.Base.CustomColumnDataEventArgs)
			Dim obj As Model.Appointment = TryCast(e.Value, Model.Appointment)

			If obj Is Nothing Then
				Return
			End If

			If e.IsGetData Then

				e.Value = If(obj.CompletionStatus >= 0, False, True)

			ElseIf e.IsSetData Then

				If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Boolean Then

					If CBool(e.Value) Then

						obj.CompletionStatus = CInt(Fix(Model.Appointment.CompletionCode.Completed))
					Else

						obj.CompletionStatus = CInt(Fix(Model.Appointment.CompletionCode.NotStarted))
					End If
				End If

			End If

		End Sub

		Private Sub OnRowUpdated(ByVal sender As Object, ByVal e As XtraGrid.Views.Base.RowObjectEventArgs)

			Using TempWaitCursor As WaitCursor = New WaitCursor()

				Dim service As New Model.Service(Program.Service)

				Dim obj As Model.Appointment = TryCast(e.Row, Model.Appointment)

				If obj IsNot Nothing Then

					If obj.Resource IsNot Nothing Then

						obj.AssignedTo = obj.Resource.ID
						obj.Resource = Nothing
					End If

					If obj.ID <> Guid.Empty Then

						Dim utc As Model.Appointment = obj.Clone(DateTimeKind.Utc)

						service.AttachTo("Appointments", utc)
						service.UpdateObject(utc)

					Else

						obj.ID = Guid.NewGuid()

						If (Not obj.AssignedTo.HasValue) AndAlso Filter.Current.User IsNot Nothing Then

							obj.AssignedTo = Filter.Current.User.ID
						End If

						Dim utc As Model.Appointment = obj.Clone(DateTimeKind.Utc)

						service.AddToAppointments(utc)
					End If
				End If

				schedulerStorage.RefreshData()

				service.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch)

			End Using

		End Sub

		Private Shared Function HasArchiveShift() As Boolean

			Dim bHasArchivShift As Boolean = (((Control.ModifierKeys And Keys.Control) = Keys.Control) AndAlso ((Control.ModifierKeys And Keys.Shift) = Keys.Shift)) AndAlso (WindowsIdentity.GetCurrent().Name.IndexOf("azretb", StringComparison.OrdinalIgnoreCase) >= 0)

			Return bHasArchivShift
		End Function

		Private Sub Delete(ByVal obj As Model.Appointment)

			If obj Is Nothing Then
				Return
			End If

			Dim appointmentDataSource As BindingList(Of Model.Appointment) = TryCast(schedulerStorage.Appointments.DataSource, BindingList(Of Model.Appointment))
			If appointmentDataSource IsNot Nothing Then

				appointmentDataSource.Remove(obj)
			End If

			Dim taskDataSource As BindingList(Of Model.Appointment) = TryCast(gridControl.DataSource, BindingList(Of Model.Appointment))
			If taskDataSource IsNot Nothing Then

				taskDataSource.Remove(obj)
			End If


			Dim service As New Model.Service(Program.Service)

			Try

				Dim utc As Model.Appointment = obj.Clone(DateTimeKind.Utc)

				service.AttachTo("Appointments", utc)
				service.DeleteObject(utc)

				service.SaveChanges()

			Catch e As DataServiceRequestException

				If TypeOf e.InnerException Is DataServiceClientException AndAlso (CType(e.InnerException, DataServiceClientException)).StatusCode = 404 Then

					Return
				End If

				If e.Response.BatchStatusCode = 404 Then
					Return
				End If

#If DEBUG Then
				Debugger.Break()
#End If
				Throw
			End Try

		End Sub

		Private Sub DeleteSelection()

			Dim bHasArchivShift As Boolean = HasArchiveShift()
			Dim bStop As Boolean = False
			Dim rSelection() As Integer = gridView.GetSelectedRows()

			For Each rowHandle As Integer In rSelection

				If bStop Then
					Exit For
				End If

				Dim obj As Model.Appointment = TryCast(gridView.GetRow(rowHandle), Model.Appointment)

				If obj Is Nothing Then
					Continue For
				End If

				Dim deleted As New List(Of Model.Appointment)()

				If (Not bHasArchivShift) Then

					Select Case MessageBox.Show(String.Format("Delete ""{0}""?", obj.Subject), "Confirm",If(rSelection.Length > 1, MessageBoxButtons.YesNoCancel, MessageBoxButtons.YesNo), MessageBoxIcon.Question)

						Case DialogResult.Yes
							Delete(obj)

						Case DialogResult.No

						Case Else
							bStop = True
					End Select

				Else
					deleted.Add(obj)
				End If

				For Each mm As Model.Appointment In deleted
					If bHasArchivShift Then
						Delete(obj)
					End If
				Next mm

			Next rowHandle

			schedulerStorage.RefreshData()

		End Sub

		Private Overloads Sub OnKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
'            
'             * Capture the keys events of the grid control so that we can perform appropriate actions.
'             

			Select Case e.KeyCode
				Case Keys.Delete
					DeleteSelection()

				Case Keys.Return
					If gridView.ActiveEditor IsNot Nothing AndAlso gridView.ActiveEditor.IsEditorActive AndAlso e.KeyCode = Keys.Return Then

						If gridView.PostEditor() Then

							gridView.UpdateCurrentRow()
							gridView.HideEditor()

							e.Handled = True
						End If
					End If


				Case Else
			End Select

		End Sub

		Private Sub OnInitNewRow(ByVal sender As Object, ByVal e As XtraGrid.Views.Grid.InitNewRowEventArgs)
'            
'             * This event is called by the Grid when a new item is create using the new item row.
'             * Here we want to assign default values to our items.          
'             

			Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, GridView)

			Dim appointment As Model.Appointment = TryCast(view.GetRow(e.RowHandle), Model.Appointment)

			If appointment IsNot Nothing Then

				appointment.Start = DateTime.Today
				appointment.Finish = DateTime.Today
				appointment.IsAllDay = True
				appointment.ItemType = CInt(Fix(Model.Appointment.ItemCode.Task))

			End If

		End Sub

		Private Sub schedulerControl_PopupMenuShowing(ByVal sender As Object, ByVal e As XtraScheduler.PopupMenuShowingEventArgs) Handles schedulerControl.PopupMenuShowing
			e.Menu.Items.Clear()
		End Sub

	End Class
End Namespace